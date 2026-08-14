// Model builder for the C# SDK codegen.
//
// Consumes the normalized @seamapi/blueprint and produces the plain data model
// in class-model.ts. This file decides *what* classes, enums, unions,
// properties, and routes exist, their names, order, types, and nullability. All
// string serialization lives in the Handlebars layouts.
//
// The builder depends only on the blueprint. It never reads the OpenAPI spec:
// the blueprint already resolves int vs. float (Number.isInt), enum members,
// inline objects, discriminated unions, and endpoint request/response shapes.

import type {
  ActionAttempt,
  Endpoint,
  EventResource,
  Parameter,
  Property,
  Resource,
} from '@seamapi/blueprint'
import { camelCase, pascalCase, snakeCase } from 'change-case'

import type {
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

const MODEL_NAMESPACE = [...GLOBAL_NAMESPACE, 'Model']

// C# reserved identifiers cannot be used verbatim as camelCase parameter or
// local names. `override` is renamed and `event` is suffixed to keep the
// generated argument names legal.
const reservedKeywordMap: Record<string, string> = { override: 'mustOverride' }
const RESERVED_TOKENS = ['event']

const applyReserved = (token: string): string =>
  RESERVED_TOKENS.includes(token) ? `${token}_` : token

const camelIdentifier = (name: string): string =>
  applyReserved(reservedKeywordMap[camelCase(name)] ?? camelCase(name))

const withNullable = (type: string, nullable: boolean): string =>
  nullable ? `${type}?` : type

const dataContractName = (
  className: string,
  resourceType: 'response' | 'request' | 'model',
  namespace?: string[],
): string =>
  [
    ...(namespace != null && namespace.length > 0
      ? [camelCase(namespace.join('_'))]
      : []),
    camelCase(className),
    resourceType,
  ].join('_')

const safeWrapEnumValue = (value: string): string => {
  if (!value) return 'empty'
  const code = value.charCodeAt(0)
  const isAlpha = (code > 64 && code < 91) || (code > 96 && code < 123)
  return isAlpha ? value : `_${value}`
}

interface EnumValue {
  name: string
  description: string
  deprecationMessage?: string
}

const buildEnum = (propertyName: string, enumValues: EnumValue[]): CsEnum => {
  const name = pascalCase(`${propertyName}Enum`)
  const members = [
    { identifier: 'Unrecognized', assign: 0, value: 'unrecognized' },
    ...enumValues.map((value, i) => ({
      identifier: safeWrapEnumValue(pascalCase(value.name)),
      assign: i + 1,
      value: value.name,
      documentation: value.description,
      ...(value.deprecationMessage != null
        ? { obsoleteMessage: value.deprecationMessage }
        : {}),
    })),
  ]
  return { name, isString: true, members }
}

// Normalized field model. Both resource/model properties and endpoint request
// parameters are normalized into this shape so a single builder can turn them
// into class-model properties, nested enums, sibling classes, and unions.
interface Field {
  name: string
  description: string
  deprecationMessage?: string
  isRequired: boolean
  nullable: boolean
  kind: Kind
}

type Kind =
  | { t: 'prim'; cs: string }
  | { t: 'enum'; values: EnumValue[] }
  | { t: 'object'; fields: Field[] }
  | { t: 'list'; item: Kind }
  | { t: 'union'; discriminator: string; variants: Variant[] }
  // A direct reference to an already-declared type (a model class or a
  // List<...> of one). Used for endpoint response wrapper properties.
  | { t: 'ref'; cs: string }

interface Variant {
  value: string
  fields: Field[]
  description?: string
  deprecationMessage?: string
}

const normalizeEnumValues = (
  values: Array<{
    name: string
    description: string
    isDeprecated: boolean
    deprecationMessage: string
  }>,
): EnumValue[] =>
  values.map((value) => ({
    name: value.name,
    description: value.description,
    ...(value.isDeprecated
      ? { deprecationMessage: value.deprecationMessage || 'Deprecated.' }
      : {}),
  }))

// Reads the single discriminator enum value carried by a union variant, e.g.
// the one member of the variant's `error_code`/`action_type` enum.
const discriminatorValue = (
  fields: Field[],
  discriminator: string,
): string | undefined => {
  const field = fields.find((f) => f.name === discriminator)
  if (field?.kind.t === 'enum') return field.kind.values[0]?.name
  return undefined
}

const normalizeItemKind = (property: Property): Kind => {
  if (property.format !== 'list') {
    throw new Error(`Expected list property, got ${property.format}`)
  }
  switch (property.itemFormat) {
    case 'string':
    case 'id':
    case 'datetime':
      return { t: 'prim', cs: 'string' }
    case 'number':
      return { t: 'prim', cs: property.isItemInt ? 'int' : 'float' }
    case 'enum':
      return { t: 'enum', values: normalizeEnumValues(property.itemEnumValues) }
    case 'record':
      return { t: 'prim', cs: 'object' }
    case 'object':
      return {
        t: 'object',
        fields: property.itemProperties.map(normalizeProperty),
      }
    case 'discriminated_object':
      return {
        t: 'union',
        discriminator: property.discriminator,
        variants: property.variants.map((variant) => {
          const fields = variant.properties.map(normalizeProperty)
          return {
            value: discriminatorValue(fields, property.discriminator) ?? '',
            fields,
          }
        }),
      }
    default:
      return { t: 'prim', cs: 'object' }
  }
}

const normalizeProperty = (property: Property): Field => {
  // Response models deserialize leniently: `IsRequired` stays false so a
  // payload that omits a field (as real responses and partial fixtures do)
  // never throws. `isOptional` and `isNullable` instead widen the C# type to
  // nullable, so a value that may be absent or null is representable.
  const base = {
    name: property.name,
    description: property.description,
    ...(property.isDeprecated
      ? { deprecationMessage: property.deprecationMessage || 'Deprecated.' }
      : {}),
    isRequired: false,
    nullable: property.isNullable || property.isOptional,
  }
  switch (property.format) {
    case 'string':
    case 'id':
    case 'datetime':
      return { ...base, kind: { t: 'prim', cs: 'string' } }
    case 'boolean':
      return { ...base, kind: { t: 'prim', cs: 'bool' } }
    case 'number':
      return {
        ...base,
        kind: { t: 'prim', cs: property.isInt ? 'int' : 'float' },
      }
    case 'record':
      return { ...base, kind: { t: 'prim', cs: 'object' } }
    case 'enum':
      return {
        ...base,
        kind: { t: 'enum', values: normalizeEnumValues(property.values) },
      }
    case 'object':
      return {
        ...base,
        kind: {
          t: 'object',
          fields: property.properties.map(normalizeProperty),
        },
      }
    case 'list':
      return { ...base, kind: { t: 'list', item: normalizeItemKind(property) } }
    default:
      return { ...base, kind: { t: 'prim', cs: 'object' } }
  }
}

const normalizeParameterItemKind = (parameter: Parameter): Kind => {
  if (parameter.format !== 'list') {
    throw new Error(`Expected list parameter, got ${parameter.format}`)
  }
  switch (parameter.itemFormat) {
    case 'string':
    case 'id':
    case 'datetime':
      return { t: 'prim', cs: 'string' }
    case 'number':
      return { t: 'prim', cs: parameter.isItemInt ? 'int' : 'float' }
    case 'boolean':
      return { t: 'prim', cs: 'bool' }
    case 'enum':
      return {
        t: 'enum',
        values: normalizeEnumValues(parameter.itemEnumValues),
      }
    case 'record':
      return { t: 'prim', cs: 'object' }
    case 'object':
      return {
        t: 'object',
        fields: parameter.itemParameters.map(normalizeParameter),
      }
    case 'discriminated_object':
      return {
        t: 'union',
        discriminator: parameter.discriminator,
        variants: parameter.variants.map((variant) => {
          const fields = variant.parameters.map(normalizeParameter)
          return {
            value: discriminatorValue(fields, parameter.discriminator) ?? '',
            fields,
          }
        }),
      }
    default:
      return { t: 'prim', cs: 'object' }
  }
}

const normalizeParameter = (parameter: Parameter): Field => {
  // Endpoint parameters carry `isRequired`; optional parameters become nullable.
  const base = {
    name: parameter.name,
    description: parameter.description,
    ...(parameter.isDeprecated
      ? { deprecationMessage: parameter.deprecationMessage || 'Deprecated.' }
      : {}),
    isRequired: parameter.isRequired,
    nullable: !parameter.isRequired,
  }
  switch (parameter.format) {
    case 'string':
    case 'id':
    case 'datetime':
      return { ...base, kind: { t: 'prim', cs: 'string' } }
    case 'boolean':
      return { ...base, kind: { t: 'prim', cs: 'bool' } }
    case 'number':
      return {
        ...base,
        kind: { t: 'prim', cs: parameter.isInt ? 'int' : 'float' },
      }
    case 'record':
      return { ...base, kind: { t: 'prim', cs: 'object' } }
    case 'enum':
      return {
        ...base,
        kind: { t: 'enum', values: normalizeEnumValues(parameter.values) },
      }
    case 'object':
      return {
        ...base,
        kind: {
          t: 'object',
          fields: parameter.parameters.map(normalizeParameter),
        },
      }
    case 'list':
      return {
        ...base,
        kind: { t: 'list', item: normalizeParameterItemKind(parameter) },
      }
    default:
      return { ...base, kind: { t: 'prim', cs: 'object' } }
  }
}

interface BuildClassOptions {
  resourceType: 'response' | 'request' | 'model'
  namespace?: string[] | undefined
  // When set, the class is a discriminated-union subclass: the discriminator
  // property is emitted as a get-only override with a constant value.
  discriminator?: { name: string; value: string; base: string }
  // Property names lifted onto the union's abstract base; emitted as overrides.
  overrideNames?: Set<string> | undefined
  documentation?: string
  obsoleteMessage?: string
}

interface BuiltClass {
  main: CsClass
  // Sibling classes spawned by inline-object properties, appended after `main`.
  siblings: CsClass[]
  properties: CsProperty[]
}

const buildClass = (
  className: string,
  fields: Field[],
  options: BuildClassOptions,
): BuiltClass => {
  const {
    resourceType,
    namespace,
    discriminator,
    overrideNames,
    documentation,
    obsoleteMessage,
  } = options
  const nested: CsNested[] = []
  const siblings: CsClass[] = []
  const nestedByKey = new Map<string, CsNested>()

  const setNested = (key: string, value: CsNested): void => {
    if (!nestedByKey.has(key)) nested.push(value)
    nestedByKey.set(key, value)
  }

  const csType = (
    kind: Kind,
    fieldName: string,
    nullable: boolean,
    documentation?: string,
  ): string => {
    switch (kind.t) {
      case 'prim':
        return withNullable(kind.cs, nullable)
      case 'ref':
        return kind.cs
      case 'enum': {
        const csEnum = {
          ...buildEnum(fieldName, kind.values),
          ...(documentation != null ? { documentation } : {}),
        }
        setNested(csEnum.name, { enum: csEnum })
        return withNullable(`${className}.${csEnum.name}`, nullable)
      }
      case 'object': {
        const childName = pascalCase(className + pascalCase(fieldName))
        const built = buildClass(childName, kind.fields, {
          resourceType: 'model',
          namespace,
        })
        siblings.push(built.main, ...built.siblings)
        return withNullable(childName, nullable)
      }
      case 'list':
        return withNullable(
          `List<${csType(kind.item, fieldName, false, documentation)}>`,
          nullable,
        )
      case 'union': {
        const unionName = pascalCase(className + pascalCase(fieldName))
        const union = buildUnion(unionName, kind.discriminator, kind.variants, {
          resourceType,
          namespace,
        })
        setNested(unionName, { union })
        return withNullable(unionName, nullable)
      }
    }
  }

  const overrideProperty = (name: string, value: string): CsProperty => ({
    pascalName: pascalCase(name),
    camelName: camelIdentifier(name),
    snakeName: snakeCase(name),
    type: 'string',
    isRequired: true,
    isOverride: true,
    getOnly: true,
    initializer: `"${value}"`,
  })

  const mapField = (field: Field): CsProperty => ({
    pascalName: pascalCase(field.name),
    camelName: camelIdentifier(field.name),
    snakeName: snakeCase(field.name),
    type: csType(field.kind, field.name, field.nullable, field.description),
    isRequired: field.isRequired,
    isOverride: overrideNames?.has(field.name) ?? false,
    getOnly: false,
    documentation: field.description,
    ...(field.deprecationMessage != null
      ? { obsoleteMessage: field.deprecationMessage }
      : {}),
  })

  const properties: CsProperty[] = []
  let emittedDiscriminator = false
  for (const field of fields) {
    if (discriminator != null && field.name === discriminator.name) {
      properties.push(overrideProperty(discriminator.name, discriminator.value))
      emittedDiscriminator = true
      continue
    }
    properties.push(mapField(field))
  }
  if (discriminator != null && !emittedDiscriminator) {
    properties.unshift(
      overrideProperty(discriminator.name, discriminator.value),
    )
  }

  const main: CsClass = {
    kind: 'class',
    className,
    dataContractName: dataContractName(className, resourceType, namespace),
    ...(discriminator != null ? { baseClass: discriminator.base } : {}),
    nested,
    properties,
    ...(documentation != null ? { documentation } : {}),
    ...(obsoleteMessage != null ? { obsoleteMessage } : {}),
  }

  return { main, siblings, properties }
}

const buildUnion = (
  className: string,
  discriminator: string,
  variants: Variant[],
  options: {
    resourceType: 'response' | 'request' | 'model'
    namespace?: string[] | undefined
  },
): CsUnion => {
  const { resourceType, namespace } = options

  // Lift properties shared by every variant onto the abstract base so consumers
  // can read them polymorphically without downcasting. Only primitive-typed
  // properties with an identical resolved C# type across all variants qualify
  // (enum/object/list types are owned by a specific subclass and cannot be
  // shared). The discriminator is lifted separately as a get-only override.
  const primType = (field: Field): string | null =>
    field.kind.t === 'prim' ? withNullable(field.kind.cs, field.nullable) : null

  const byName = new Map<string, Field[]>()
  for (const variant of variants) {
    for (const field of variant.fields) {
      if (field.name === discriminator) continue
      byName.set(field.name, [...(byName.get(field.name) ?? []), field])
    }
  }
  const liftedFields = [...byName.values()]
    .filter((fields) => fields.length === variants.length)
    .map((fields) => fields[0] as Field)
    .filter((field) => {
      const type = primType(field)
      return (
        type != null &&
        byName.get(field.name)?.every((f) => primType(f) === type)
      )
    })
  const overrideNames = new Set(liftedFields.map((f) => f.name))

  const subclasses: CsClass[] = []
  const known: Array<[string, string]> = []

  for (const variant of variants) {
    const subName = pascalCase(className + pascalCase(variant.value))
    const built = buildClass(subName, variant.fields, {
      resourceType,
      namespace,
      discriminator: {
        name: discriminator,
        value: variant.value,
        base: className,
      },
      overrideNames,
      ...(variant.description != null
        ? { documentation: variant.description }
        : {}),
      ...(variant.deprecationMessage != null
        ? { obsoleteMessage: variant.deprecationMessage }
        : {}),
    })
    subclasses.push(built.main, ...built.siblings)
    known.push([subName, variant.value])
  }

  const unrecognizedTypeName = `${className}Unrecognized`
  const fallback = buildClass(
    unrecognizedTypeName,
    // The fallback carries the lifted properties so it satisfies the abstract
    // base; they are optional since an unrecognized payload may omit them.
    liftedFields.map((field) => ({ ...field, isRequired: false })),
    {
      resourceType,
      namespace,
      discriminator: {
        name: discriminator,
        value: 'unrecognized',
        base: className,
      },
      overrideNames,
    },
  )
  subclasses.push(fallback.main, ...fallback.siblings)

  // The KnownSubType attribute order is the reverse of subclass definition order.
  const knownSubTypes = [...known]
    .reverse()
    .map(([typeName, value]) => ({ typeName, value }))

  return {
    kind: 'union',
    className,
    discriminatorSnake: discriminator,
    knownSubTypes,
    unrecognizedTypeName,
    abstractProps: [
      { type: 'string', pascalName: pascalCase(discriminator), getOnly: true },
      ...liftedFields.map((field) => ({
        type: primType(field) as string,
        pascalName: pascalCase(field.name),
        getOnly: false,
      })),
    ],
    subclasses,
  }
}

export const buildModelFile = (
  resource: Resource,
): { name: string; file: CsModelFile } => {
  const name = pascalCase(resource.resourceType)
  const built = buildClass(name, resource.properties.map(normalizeProperty), {
    resourceType: 'model',
    namespace: MODEL_NAMESPACE,
    documentation: resource.description,
    ...(resource.isDeprecated
      ? { obsoleteMessage: resource.deprecationMessage || 'Deprecated.' }
      : {}),
  })
  return { name, file: { decls: [built.main, ...built.siblings] } }
}

const buildUnionModelFile = (
  name: string,
  discriminator: string,
  variants: Variant[],
): { name: string; file: CsModelFile } => {
  const union = buildUnion(name, discriminator, variants, {
    resourceType: 'model',
    namespace: MODEL_NAMESPACE,
  })
  return { name, file: { decls: [union] } }
}

export const buildActionAttemptFile = (
  actionAttempts: ActionAttempt[],
): { name: string; file: CsModelFile } =>
  buildUnionModelFile(
    'ActionAttempt',
    'action_type',
    actionAttempts.map((actionAttempt) => ({
      value: actionAttempt.actionAttemptType,
      fields: actionAttempt.properties.map(normalizeProperty),
      description: actionAttempt.description,
      ...(actionAttempt.isDeprecated
        ? {
            deprecationMessage:
              actionAttempt.deprecationMessage || 'Deprecated.',
          }
        : {}),
    })),
  )

export const buildEventFile = (
  events: EventResource[],
): { name: string; file: CsModelFile } =>
  buildUnionModelFile(
    'Event',
    'event_type',
    events.map((event) => ({
      value: event.eventType,
      fields: event.properties.map(normalizeProperty),
      description: event.description,
      ...(event.isDeprecated
        ? { deprecationMessage: event.deprecationMessage || 'Deprecated.' }
        : {}),
    })),
  )

// Resolves the model type for a resource reference. A reference to a type that
// is not a generated model (e.g. an undocumented resource, which the blueprint
// reports as `unknown`) falls back to the untyped `object`. The batch
// find-anything endpoint is keyed by its response key, which is a model.
const resolveModel = (
  resourceType: string,
  responseKey: string,
  modelTypes: Set<string>,
): string => {
  if (modelTypes.has(resourceType)) return pascalCase(resourceType)
  if (modelTypes.has(responseKey)) return pascalCase(responseKey)
  return 'object'
}

// The C# type for an endpoint's return value, and the resource property name it
// is unwrapped from in the response body.
const responseReturn = (
  response: Endpoint['response'],
  modelTypes: Set<string>,
): { returnType: string; returnProp: string } | undefined => {
  if (response.responseType === 'void') return undefined
  const returnProp = pascalCase(response.responseKey)
  const model = resolveModel(
    response.resourceType,
    response.responseKey,
    modelTypes,
  )
  const returnType =
    response.responseType === 'resource_list' ? `List<${model}>` : model
  return { returnType, returnProp }
}

export const buildApiFile = (
  className: string,
  endpoints: Endpoint[],
  modelTypes: Set<string>,
): CsApiFile => {
  const routes: CsRoute[] = endpoints.map((endpoint) => {
    const methodName = pascalCase(endpoint.name)
    const httpMethod = pascalCase(endpoint.request.preferredMethod)

    const request = buildClass(
      pascalCase(`${endpoint.name}_request`),
      endpoint.request.parameters.map(normalizeParameter),
      {
        resourceType: 'request',
        documentation: `Request parameters for ${endpoint.title}.`,
        ...(endpoint.isDeprecated
          ? { obsoleteMessage: endpoint.deprecationMessage || 'Deprecated.' }
          : {}),
      },
    )

    const routeDocumentation = {
      documentation: endpoint.description,
      ...(endpoint.isDeprecated
        ? { obsoleteMessage: endpoint.deprecationMessage || 'Deprecated.' }
        : {}),
    }

    const returned = responseReturn(endpoint.response, modelTypes)
    const isVoid = returned == null

    if (isVoid) {
      return {
        methodName,
        path: endpoint.path,
        httpMethod,
        request: request.main,
        requestSiblings: request.siblings,
        responseSiblings: [],
        responseTypeArg: 'object',
        isVoid: true,
        params: request.properties,
        ...routeDocumentation,
      }
    }

    const { returnType, returnProp } = returned
    const responseKey = (endpoint.response as { responseKey: string })
      .responseKey
    const responseClassName = pascalCase(`${endpoint.name}_response`)
    const response = buildClass(
      responseClassName,
      [
        {
          name: responseKey,
          description: endpoint.response.description,
          isRequired: false,
          nullable: false,
          kind: { t: 'ref', cs: returnType },
        },
      ],
      { resourceType: 'response' },
    )

    return {
      methodName,
      path: endpoint.path,
      httpMethod,
      request: request.main,
      requestSiblings: request.siblings,
      response: response.main,
      responseSiblings: response.siblings,
      responseTypeArg: responseClassName,
      returnProp,
      returnType,
      isVoid: false,
      params: request.properties,
      ...routeDocumentation,
    }
  })

  return { className: pascalCase(className), routes }
}

export { GLOBAL_NAMESPACE }
