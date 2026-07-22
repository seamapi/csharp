// Durable model builder for the C# SDK codegen.
//
// Ports the traversal of the previous nextlove C# serializer
// (generate-csharp-sdk/templates/dataclass.ts) but produces the plain data model
// in class-model.ts instead of AST nodes. All string serialization now lives in
// the Handlebars layouts; this file only decides *what* classes, enums, unions,
// properties, and routes exist, their names, order, types, and nullability.
//
// Type resolution reads the raw OpenAPI schema (via the openapi/* parsing
// helpers) because it distinguishes int/float, Object/object, and inline enums
// in ways @seamapi/blueprint normalizes away.
// TODO: Derive types, resources, and namespaces from @seamapi/blueprint once the
// generated output is allowed to change.

import { camelCase, pascalCase, snakeCase } from 'change-case'

import type {
  CsAbstractProp,
  CsApiFile,
  CsClass,
  CsEnum,
  CsModelFile,
  CsNested,
  CsProperty,
  CsRoute,
  CsUnion,
} from './class-model.js'
import { GLOBAL_NAMESPACE } from './constants.js'
import { deepFlattenAllOfSchema } from './openapi/flatten-obj-schema.js'
import type {
  AllOfSchema,
  ObjSchema,
  OneOfSchema,
  PropertySchema,
  RefSchema,
} from './types.js'

const FALLBACK_TYPE = 'object?'

// C# keyword/identifier remapping, ported verbatim to preserve the previous
// generator's parameter and property names.
// TODO: Revisit these name workarounds once the generated output is allowed to
// change (e.g. use a verbatim identifier `@event`/`@override` instead).
const reservedKeywordMap: Record<string, string> = { override: 'mustOverride' }
const RESERVED_TOKENS = ['event']

const applyReserved = (token: string): string =>
  RESERVED_TOKENS.includes(token) ? `${token}_` : token

const withNullable = (type: string, nullable: boolean): string =>
  nullable ? `${type}?` : type

type SupportedPropertySchema = Exclude<PropertySchema, AllOfSchema>

interface TopLevelOptions {
  enumOverrides?: Record<string, string>
  base?: string
}

interface PersistentOptions {
  forceNullable?: boolean
}

interface BuiltClass {
  main: CsClass
  // Sibling classes spawned by inline-object properties, flattened in
  // discovery order; appended after `main` at the enclosing level.
  siblings: CsClass[]
  properties: CsProperty[]
}

const dataContractName = (
  name: string,
  resourceType: string,
  namespace?: string[],
): string =>
  [
    ...(namespace != null && namespace.length > 0
      ? [camelCase(namespace.join('_'))]
      : []),
    camelCase(name),
    resourceType,
  ].join('_')

const safeWrapEnumValue = (value: string): string => {
  if (!value) return 'empty'
  const code = value.charCodeAt(0)
  const isAlpha = (code > 64 && code < 91) || (code > 96 && code < 123)
  return isAlpha ? value : `_${value}`
}

const buildEnum = (
  propertyName: string,
  enumValues: Array<string | number>,
  ty: 'number' | 'string',
): CsEnum => {
  const name = pascalCase(`${propertyName}Enum`)
  const isString = ty === 'string'

  const members = [
    ...(isString
      ? [{ identifier: 'Unrecognized', assign: 0, value: 'unrecognized' }]
      : []),
    ...enumValues.map((value, i) => ({
      identifier: safeWrapEnumValue(
        typeof value === 'string' ? pascalCase(value) : `${name}${i}`,
      ),
      assign: isString ? i + 1 : i,
      value,
    })),
  ]

  return { name, isString, members }
}

const isSchemaObjectRecursive = (schemas: any[]): boolean =>
  schemas.every(
    (s: any) =>
      ('type' in s && s.type === 'object') ||
      ('allOf' in s && isSchemaObjectRecursive(s.allOf)) ||
      ('oneOf' in s && isSchemaObjectRecursive(s.oneOf)),
  )

const buildClass = (
  name: string,
  schema: ObjSchema | RefSchema,
  resourceType: 'response' | 'request' | 'model',
  namespace?: string[],
  topLevelOptions: TopLevelOptions = {},
  persistentOptions: PersistentOptions = {},
): BuiltClass => {
  const { enumOverrides: topLevelEnumOverrides, base } = topLevelOptions
  const { forceNullable = false } = persistentOptions

  const nested: CsNested[] = []
  const siblings: CsClass[] = []
  // Preserve Map insertion semantics of the original extraFields.
  const nestedByKey = new Map<string, CsNested>()

  const required =
    'required' in schema ? new Set(schema.required) : new Set<string>()
  const properties: Array<[string, PropertySchema]> =
    'properties' in schema ? Object.entries(schema.properties) : []

  const setNested = (key: string, value: CsNested): void => {
    if (!nestedByKey.has(key)) {
      nested.push(value)
    }
    nestedByKey.set(key, value)
  }

  const mapSchemaEnum = (
    propertyName: string,
    nullable: boolean,
    enumValues: Array<string | number>,
    ty: 'number' | 'string',
  ): string => {
    const csEnum = buildEnum(propertyName, enumValues, ty)
    setNested(csEnum.name, { enum: csEnum })
    return withNullable(`${name}.${csEnum.name}`, nullable)
  }

  const mapOneOfType = (
    oneOf: OneOfSchema,
    propertyName: string,
    nullable: boolean,
  ): string => {
    if (!oneOf.discriminator) {
      if (oneOf.oneOf.every((s: any) => 'type' in s && s.type === 'string')) {
        return withNullable('string', nullable)
      }
      if (isSchemaObjectRecursive(oneOf.oneOf)) {
        return withNullable('JObject', nullable)
      }
      return FALLBACK_TYPE
    }

    const built = buildUnion(
      `${name} ${propertyName}`,
      oneOf,
      resourceType,
      namespace,
    )
    setNested(built.className, { union: built })
    return withNullable(built.className, nullable)
  }

  const mapAllOfType = (
    allOf: AllOfSchema,
    propertyName: string,
    nullable: boolean,
  ): string => {
    const flattened = deepFlattenAllOfSchema(allOf)
    if (flattened != null) {
      return mapSchemaType(flattened, propertyName, nullable)
    }
    if (isSchemaObjectRecursive(allOf.allOf)) {
      return withNullable('JObject', nullable)
    }
    return FALLBACK_TYPE
  }

  // Resolves the C# type string for a property schema and, as a side effect,
  // collects the inline enums, nested object classes, and nested unions it
  // spawns. Reads the raw OpenAPI schema (oneOf/allOf/$ref/type/enum/items).
  // TODO: Derive parameter and property types from @seamapi/blueprint once the
  // generated output is allowed to change. Blueprint collapses the integer type
  // into number (losing int vs float), flattens unions differently, and does
  // not surface these inline enums, so the raw schema is used here for parity.
  const mapSchemaType = (
    schema: any,
    propertyName: string,
    nullable: boolean,
  ): string => {
    if ('$ref' in schema) {
      const refPath = schema.$ref
      if (refPath.startsWith('#/components/schemas/')) {
        return withNullable(
          pascalCase(refPath.split('/').pop() as string),
          nullable,
        )
      }
      return withNullable(refPath, nullable)
    }

    if ('oneOf' in schema) {
      if (
        schema.oneOf.every(
          (s: any) => 'type' in s && s.type === 'string' && s.enum,
        )
      ) {
        schema = {
          type: 'string',
          enum: schema.oneOf.flatMap((s: any) =>
            'type' in s && s.type === 'string' ? (s.enum ?? []) : [],
          ),
          ...schema,
        }
      } else {
        return mapOneOfType(schema, propertyName, nullable)
      }
    }

    if ('allOf' in schema) {
      return mapAllOfType(schema, propertyName, nullable)
    }

    switch (schema.type) {
      case 'string': {
        if (schema.enum && !topLevelEnumOverrides?.[propertyName]) {
          return mapSchemaEnum(propertyName, nullable, schema.enum, 'string')
        }
        return withNullable('string', nullable)
      }
      case 'integer':
        if (schema.enum) {
          return mapSchemaEnum(propertyName, nullable, schema.enum, 'number')
        }
        return withNullable('int', nullable)
      case 'boolean':
        return withNullable('bool', nullable)
      case 'object': {
        if ('additionalProperties' in schema) {
          return FALLBACK_TYPE
        }
        const newClassName = pascalCase(name + pascalCase(propertyName))
        // TODO: Remove the hardcoded DeviceProperties special case once the
        // generated output is allowed to change. It forces every property on
        // that one class nullable/optional purely to match the previous output.
        const built = buildClass(
          newClassName,
          schema as ObjSchema,
          'model',
          namespace,
          {},
          {
            ...persistentOptions,
            ...(newClassName === 'DeviceProperties' && { forceNullable: true }),
          },
        )
        siblings.push(built.main, ...built.siblings)
        return withNullable(newClassName, nullable)
      }
      case 'array':
        return withNullable(
          `List<${mapSchemaType(
            schema.items,
            propertyName,
            'nullable' in schema.items ? !!schema.items.nullable : false,
          )}>`,
          nullable,
        )
      case 'number':
        return withNullable('float', nullable)
      default:
        return 'Object'
    }
  }

  const mapTypeToProperty = ([propertyName, schema]: [
    string,
    PropertySchema,
  ]): CsProperty => {
    const isRequired =
      required.has(propertyName) &&
      !('nullable' in schema && schema.nullable) &&
      !forceNullable

    const enumOverride = topLevelEnumOverrides?.[propertyName]
    // TODO: Replace this name-based errors/warnings `message` override heuristic
    // with a general derivation of common union properties once the generated
    // output is allowed to change. It only reproduces the previous output.
    const shouldOverrideMessage =
      propertyName === 'message' &&
      (name.includes('Errors') || name.includes('Warnings')) &&
      (Object.keys(topLevelOptions.enumOverrides ?? {})[0]?.endsWith('_code') ??
        false)

    const type = mapSchemaType(
      schema,
      propertyName,
      forceNullable || ('nullable' in schema ? !!schema.nullable : !isRequired),
    )

    return {
      pascalName: pascalCase(propertyName),
      camelName: applyReserved(
        reservedKeywordMap[camelCase(propertyName)] ?? camelCase(propertyName),
      ),
      snakeName: snakeCase(propertyName),
      type,
      isRequired,
      isOverride: enumOverride != null || shouldOverrideMessage,
      getOnly: enumOverride != null,
      ...(enumOverride != null ? { initializer: `"${enumOverride}"` } : {}),
    }
  }

  const csProperties = properties.map(mapTypeToProperty)

  const main: CsClass = {
    kind: 'class',
    className: pascalCase(name),
    dataContractName: dataContractName(name, resourceType, namespace),
    ...(base != null ? { baseClass: base } : {}),
    nested,
    properties: csProperties,
  }

  return { main, siblings, properties: csProperties }
}

const buildUnion = (
  name: string,
  schema: OneOfSchema,
  resourceType: 'response' | 'request' | 'model',
  namespace?: string[],
): CsUnion => {
  if (!schema.discriminator) {
    throw new Error(
      `OneOfSchema must have discriminator: ${JSON.stringify(schema, null, 2)}`,
    )
  }

  // TODO: Build discriminated unions from @seamapi/blueprint variant metadata
  // once the generated output is allowed to change. This reads the raw OpenAPI
  // oneOf/discriminator and reproduces the previous generator's quirks: the
  // errors/warnings-only abstract `message`, the reversed KnownSubType attribute
  // order, and the synthesized Unrecognized fallback subclass.
  const discriminator = schema.discriminator.propertyName

  const objSchemas = Array.from(
    schema.oneOf
      .reduce((map, s) => {
        if (!('type' in s && s.type === 'object')) {
          throw new Error('OneOfSchema must have object types')
        }
        const prop = s.properties[discriminator]
        if (!(
          prop &&
          'type' in prop &&
          prop.type === 'string' &&
          prop.enum &&
          prop.enum.length === 1
        )) {
          throw new Error(
            `OneOfSchema must have string discriminator: ${JSON.stringify(schema, null, 2)}`,
          )
        }
        const specificName = prop.enum[0] as string
        if (!map.has(specificName)) {
          map.set(specificName, [specificName, s as ObjSchema] as const)
        }
        return map
      }, new Map<string, readonly [string, ObjSchema]>())
      .values(),
  )

  const isErrorsOrWarnings =
    name.endsWith('errors') || name.endsWith('warnings')

  const className = pascalCase(name)

  const abstractProps: CsAbstractProp[] = [
    { type: 'string', pascalName: pascalCase(discriminator), getOnly: true },
    ...(isErrorsOrWarnings
      ? [{ type: 'string', pascalName: 'Message', getOnly: false }]
      : []),
  ]

  const subclasses: CsClass[] = []
  const specifiedClassNames: Array<[string, string]> = []

  for (const [specifiedName, subschema] of objSchemas) {
    const specifiedClassName = pascalCase(name) + pascalCase(specifiedName)
    const built = buildClass(
      specifiedClassName,
      subschema,
      resourceType,
      namespace,
      { enumOverrides: { [discriminator]: specifiedName }, base: className },
    )
    subclasses.push(built.main, ...built.siblings)
    specifiedClassNames.push([specifiedClassName, specifiedName])
  }

  const unrecognizedTypeName = `${pascalCase(name)}Unrecognized`
  const fallbackSchema: ObjSchema = {
    type: 'object',
    properties: {
      [discriminator]: { type: 'string' },
      ...(isErrorsOrWarnings ? { message: { type: 'string' } } : {}),
    },
    required: [discriminator, ...(isErrorsOrWarnings ? ['message'] : [])],
  }
  const fallback = buildClass(
    unrecognizedTypeName,
    fallbackSchema,
    resourceType,
    namespace,
    { enumOverrides: { [discriminator]: 'unrecognized' }, base: className },
  )
  subclasses.push(fallback.main, ...fallback.siblings)

  // Attribute order is the reverse of subclass definition order.
  const knownSubTypes = [...specifiedClassNames]
    .reverse()
    .map(([typeName, value]) => ({ typeName, value }))

  return {
    kind: 'union',
    className,
    discriminatorSnake: discriminator,
    knownSubTypes,
    unrecognizedTypeName,
    abstractProps,
    subclasses,
  }
}

export const buildModelFile = (
  schemaName: string,
  schema: SupportedPropertySchema,
  namespace: string[],
): { name: string; file: CsModelFile } => {
  const name = pascalCase(schemaName)

  if ('oneOf' in schema) {
    const union = buildUnion(name, schema, 'model', namespace)
    return { name, file: { decls: [union] } }
  }

  if ('$ref' in schema || schema.type === 'object') {
    const built = buildClass(name, schema, 'model', namespace)
    return { name, file: { decls: [built.main, ...built.siblings] } }
  }

  throw new Error(
    `Unsupported schema: ${JSON.stringify({ schema, name }, null, 2)}`,
  )
}

export const buildApiFile = (
  className: string,
  routes: Array<{
    methodName: string
    path: string
    parameterSchema: ObjSchema
    responseObjType: string | undefined
    responseArrType: string | undefined
    isVoid: boolean
    nullable: boolean
    returnPath: string
  }>,
): CsApiFile => {
  const csRoutes: CsRoute[] = routes.map((route) => {
    const method = pascalCase(route.methodName)
    const request = buildClass(
      pascalCase(`${route.methodName}_request`),
      route.parameterSchema,
      'request',
    )

    if (!route.responseObjType && !route.responseArrType && !route.isVoid) {
      throw new Error('Invalid response type')
    }

    // TODO: Derive the response type and nullability from
    // @seamapi/blueprint endpoint.response once the generated output is allowed
    // to change. Only the array element honors `nullable`; a non-array response
    // is never marked nullable, reproducing a quirk of the previous generator
    // (its nullable flag was misrouted and never applied to object responses).
    const returnType = route.isVoid
      ? undefined
      : route.responseArrType
        ? `List<${pascalCase(route.responseArrType)}${route.nullable ? '?' : ''}>`
        : pascalCase(route.responseObjType as string)

    const responseName = pascalCase(`${route.methodName}_response`)
    const response = route.isVoid
      ? undefined
      : buildClass(
          responseName,
          {
            type: 'object',
            required: [],
            properties: {
              [pascalCase(route.returnPath)]: {
                $ref: returnType as string,
                nullable: route.nullable,
              } as unknown as PropertySchema,
            },
          },
          'response',
        )

    return {
      methodName: method,
      path: route.path,
      request: request.main,
      requestSiblings: request.siblings,
      ...(response != null
        ? { response: response.main, responseSiblings: response.siblings }
        : { responseSiblings: [] as CsClass[] }),
      responseTypeArg: response != null ? responseName : 'object',
      ...(route.isVoid ? {} : { returnProp: pascalCase(route.returnPath) }),
      ...(returnType != null ? { returnType } : {}),
      isVoid: route.isVoid,
      params: request.properties,
    }
  })

  return { className: pascalCase(className), routes: csRoutes }
}

export { GLOBAL_NAMESPACE }
