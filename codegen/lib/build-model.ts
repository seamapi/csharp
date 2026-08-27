// Model builder for the C# SDK codegen.
//
// Consumes the normalized @seamapi/blueprint and produces the plain data model
// in class-model.ts. This file decides *what* classes, enums, unions,
// properties, and routes exist, their names, order, types, and nullability.
//
// The builder depends only on the blueprint. It never reads the OpenAPI spec:
// the blueprint already resolves int vs. float (Number.isInt), enum members,
// inline objects, discriminated unions, and endpoint request/response shapes.
//
// Nullability model:
//
// - Response models deserialize leniently: no property is `required`, and a
//   property that may be absent or null gets a nullable C# type. A property
//   the schema guarantees keeps its non-nullable type with a `default!`
//   initializer, since the wire value is what satisfies it.
// - Request parameters enforce the schema locally: a required parameter is a
//   C# `required` member, an optional one is nullable (null means omitted),
//   and a nullable one is `Optional<T>` so an explicit JSON null
//   (`Null.Value`) is distinct from omission.

import type {
  ActionAttempt,
  Endpoint,
  EventResource,
  Parameter,
  Property,
  Resource,
} from '@seamapi/blueprint'
import { pascalCase, snakeCase } from 'change-case'

import type {
  CsClass,
  CsEnum,
  CsModelFile,
  CsNested,
  CsProperty,
  CsRoute,
  CsUnion,
} from './class-model.js'

const withNullable = (type: string, nullable: boolean): string =>
  nullable ? `${type}?` : type

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
  isNullable: boolean
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
  // Model properties: `isRequired` stays false so deserialization is lenient;
  // `isNullable` widens the C# type when the schema allows absence or null.
  const base = {
    name: property.name,
    description: property.description,
    ...(property.isDeprecated
      ? { deprecationMessage: property.deprecationMessage || 'Deprecated.' }
      : {}),
    isRequired: false,
    isNullable: property.isNullable || property.isOptional,
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
  const base = {
    name: parameter.name,
    description: parameter.description,
    ...(parameter.isDeprecated
      ? { deprecationMessage: parameter.deprecationMessage || 'Deprecated.' }
      : {}),
    isRequired: parameter.isRequired,
    isNullable: parameter.isNullable,
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
  // Requests enforce the schema locally (required members, Optional<T> for
  // nullable parameters); models deserialize leniently.
  resourceType: 'response' | 'request' | 'model'
  // When set, the class is a discriminated-union subclass: the discriminator
  // property is emitted as a get-only override with a constant value.
  discriminator?: { name: string; value: string; base: string }
  // Field names declared concretely on the union base; omitted from subclasses.
  omitNames?: Set<string> | undefined
  documentation?: string
  obsoleteMessage?: string
}

interface BuiltClass {
  main: CsClass
  // Sibling classes spawned by inline-object properties, appended after `main`.
  siblings: CsClass[]
  properties: CsProperty[]
}

// Whether a C# type needs a `default!` initializer to satisfy non-nullable
// analysis when the wire value is what actually assigns it. Value types are
// self-satisfying but `default!` is harmless and uniform.
const lenientInitializer = (type: string): string | undefined =>
  type.endsWith('?') ? undefined : 'default!'

const buildClass = (
  className: string,
  fields: Field[],
  options: BuildClassOptions,
): BuiltClass => {
  const {
    resourceType,
    discriminator,
    omitNames,
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

  // The core (non-nullable) C# type of a field, declaring any nested enum,
  // union, or sibling class it needs.
  const coreType = (
    kind: Kind,
    fieldName: string,
    documentation?: string,
  ): string => {
    switch (kind.t) {
      case 'prim':
        return kind.cs
      case 'ref':
        return kind.cs
      case 'enum': {
        const csEnum = {
          ...buildEnum(fieldName, kind.values),
          ...(documentation != null ? { documentation } : {}),
        }
        setNested(csEnum.name, { enum: csEnum })
        return `${className}.${csEnum.name}`
      }
      case 'object': {
        const childName = pascalCase(className + pascalCase(fieldName))
        const built = buildClass(childName, kind.fields, {
          resourceType: resourceType === 'request' ? 'request' : 'model',
        })
        siblings.push(built.main, ...built.siblings)
        return childName
      }
      case 'list':
        return `List<${coreType(kind.item, fieldName, documentation)}>`
      case 'union': {
        const unionName = pascalCase(className + pascalCase(fieldName))
        const union = buildUnion(unionName, kind.discriminator, kind.variants, {
          resourceType,
        })
        setNested(unionName, { union })
        return unionName
      }
    }
  }

  const mapField = (field: Field): CsProperty => {
    const core = coreType(field.kind, field.name, field.description)

    let type: string
    let isRequired = false
    let initializer: string | undefined

    if (resourceType === 'request') {
      // Optionality composes with nullability rather than replacing it: an
      // optional parameter is omitted by leaving it null (or unset), while
      // only a nullable parameter accepts an explicit Null.Value.
      type = field.isNullable ? `Optional<${core}>` : core
      isRequired = field.isRequired
      if (!field.isRequired && !field.isNullable) {
        type = withNullable(type, true)
      }
    } else {
      type = withNullable(core, field.isNullable)
      initializer = lenientInitializer(type)
    }

    return {
      pascalName: pascalCase(field.name),
      snakeName: snakeCase(field.name),
      type,
      isRequired,
      isOverride: false,
      getOnly: false,
      ...(initializer != null ? { initializer } : {}),
      documentation: field.description,
      ...(field.deprecationMessage != null
        ? { obsoleteMessage: field.deprecationMessage }
        : {}),
    }
  }

  const properties: CsProperty[] = []
  for (const field of fields) {
    if (field.name === discriminator?.name) continue
    if (omitNames?.has(field.name) ?? false) continue
    properties.push(mapField(field))
  }
  if (discriminator != null) {
    properties.unshift({
      pascalName: pascalCase(discriminator.name),
      snakeName: snakeCase(discriminator.name),
      type: 'string',
      isRequired: false,
      isOverride: true,
      getOnly: true,
      initializer: `"${discriminator.value}"`,
    })
  }

  const main: CsClass = {
    kind: 'class',
    className,
    ...(discriminator != null ? { baseClass: discriminator.base } : {}),
    nested,
    properties,
    ...(documentation != null ? { documentation } : {}),
    ...(obsoleteMessage != null ? { obsoleteMessage } : {}),
  }

  return { main, siblings, properties }
}

interface BuildUnionOptions {
  resourceType: 'response' | 'request' | 'model'
  // Field names removed from every variant in favor of `extraBaseProps`
  // declared on the base with a shared type, e.g. the action attempt
  // status/error contract the runtime resolver depends on.
  omitFieldNames?: string[]
  extraBaseProps?: CsProperty[]
}

const buildUnion = (
  className: string,
  discriminator: string,
  variants: Variant[],
  options: BuildUnionOptions,
): CsUnion => {
  const { resourceType, omitFieldNames = [], extraBaseProps = [] } = options
  const omitted = new Set(omitFieldNames)

  // Lift properties shared by every variant onto the base so consumers can
  // read them polymorphically without downcasting. Only primitive-typed
  // properties with an identical resolved C# type across all variants qualify
  // (enum/object/list types are owned by a specific subclass and cannot be
  // shared). Lifted properties are declared concretely on the base and
  // omitted from the subclasses, which inherit them.
  const primType = (field: Field): string | null =>
    field.kind.t === 'prim'
      ? withNullable(field.kind.cs, field.isNullable)
      : null

  const byName = new Map<string, Field[]>()
  for (const variant of variants) {
    for (const field of variant.fields) {
      if (field.name === discriminator || omitted.has(field.name)) continue
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
  const omitNames = new Set([
    ...liftedFields.map((f) => f.name),
    ...omitFieldNames,
  ])

  const baseProps: CsProperty[] = [
    ...liftedFields.map((field): CsProperty => {
      const type = primType(field) as string
      return {
        pascalName: pascalCase(field.name),
        snakeName: snakeCase(field.name),
        type,
        isRequired: false,
        isOverride: false,
        getOnly: false,
        ...(lenientInitializer(type) != null
          ? { initializer: lenientInitializer(type) as string }
          : {}),
        documentation: field.description,
        ...(field.deprecationMessage != null
          ? { obsoleteMessage: field.deprecationMessage }
          : {}),
      }
    }),
    ...extraBaseProps,
  ]

  const subclasses: CsClass[] = []
  const known: Array<[string, string]> = []

  for (const variant of variants) {
    const subName = pascalCase(className + pascalCase(variant.value))
    const built = buildClass(subName, variant.fields, {
      resourceType,
      discriminator: {
        name: discriminator,
        value: variant.value,
        base: className,
      },
      omitNames,
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
  const fallback = buildClass(unrecognizedTypeName, [], {
    resourceType,
    discriminator: {
      name: discriminator,
      value: 'unrecognized',
      base: className,
    },
  })
  subclasses.push({ ...fallback.main, isUnrecognizedFallback: true })

  const knownSubTypes = known.map(([typeName, value]) => ({ typeName, value }))

  return {
    kind: 'union',
    className,
    discriminatorSnake: discriminator,
    discriminatorPascal: pascalCase(discriminator),
    knownSubTypes,
    unrecognizedTypeName,
    baseProps,
    subclasses,
  }
}

export const buildModelFile = (
  resource: Resource,
): { name: string; file: CsModelFile } => {
  const name = pascalCase(resource.resourceType)
  const built = buildClass(name, resource.properties.map(normalizeProperty), {
    resourceType: 'model',
    documentation: resource.description,
    ...(resource.isDeprecated
      ? { obsoleteMessage: resource.deprecationMessage || 'Deprecated.' }
      : {}),
  })
  return { name, file: { decls: [built.main, ...built.siblings] } }
}

const normalizeActionAttemptProperty = (property: Property): Field => {
  const field = normalizeProperty(property)
  const statuses = property.actionAttemptStatuses
  if (statuses == null) return field
  const statusList = statuses.map((status) => `\`${status}\``).join(' or ')
  const note =
    statuses.length === 0
      ? 'Always null.'
      : `Null unless the action attempt \`status\` is ${statusList}.`
  const description = [field.description, note]
    .filter((part) => part !== '')
    .join('\n\n')
  return { ...field, isNullable: true, description }
}

export const buildActionAttemptFile = (
  actionAttempts: ActionAttempt[],
): { name: string; file: CsModelFile } => {
  // The status and error of every action attempt share one wire shape, so they
  // are declared once on the base with the runtime-owned ActionAttemptStatus
  // and ActionAttemptError types the action attempt resolver depends on.
  const union = buildUnion(
    'ActionAttempt',
    'action_type',
    actionAttempts.map((actionAttempt) => ({
      value: actionAttempt.actionAttemptType,
      fields: actionAttempt.properties.map(normalizeActionAttemptProperty),
      description: actionAttempt.description,
      ...(actionAttempt.isDeprecated
        ? {
            deprecationMessage:
              actionAttempt.deprecationMessage || 'Deprecated.',
          }
        : {}),
    })),
    {
      resourceType: 'model',
      omitFieldNames: ['status', 'error'],
      extraBaseProps: [
        {
          pascalName: 'Status',
          snakeName: 'status',
          type: 'ActionAttemptStatus',
          isRequired: false,
          isOverride: false,
          getOnly: false,
          documentation: 'The status of the action attempt.',
        },
        {
          pascalName: 'Error',
          snakeName: 'error',
          type: 'ActionAttemptError?',
          isRequired: false,
          isOverride: false,
          getOnly: false,
          documentation: 'The error of a failed action attempt, or null.',
        },
      ],
    },
  )
  return { name: 'ActionAttempt', file: { decls: [union] } }
}

export const buildEventFile = (
  events: EventResource[],
): { name: string; file: CsModelFile } => {
  const union = buildUnion(
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
    { resourceType: 'model' },
  )
  return { name: 'Event', file: { decls: [union] } }
}

// Resolves the model type for a resource reference. A reference to a type that
// is not a generated model (e.g. an undocumented resource, which the blueprint
// reports as `unknown`) has no class to deserialize into, so the endpoint is
// generated as returning void. The batch find-anything endpoint is keyed by
// its response key, which is a model.
const resolveModel = (
  resourceType: string,
  responseKey: string,
  modelTypes: Set<string>,
): string | undefined => {
  if (modelTypes.has(resourceType)) return pascalCase(resourceType)
  if (modelTypes.has(responseKey)) return pascalCase(responseKey)
  return undefined
}

// The C# type for an endpoint's return value, and the resource property name it
// is unwrapped from in the response body.
const responseReturn = (
  response: Endpoint['response'],
  modelTypes: Set<string>,
):
  | { returnType: string; returnProp: string; model: string; isList: boolean }
  | undefined => {
  if (response.responseType === 'void') return undefined
  const returnProp = pascalCase(response.responseKey)
  const model = resolveModel(
    response.resourceType,
    response.responseKey,
    modelTypes,
  )
  if (model == null) return undefined
  const isList = response.responseType === 'resource_list'
  const returnType = isList ? `List<${model}>` : model
  return { returnType, returnProp, model, isList }
}

// The C# condition under which a request property counts as not given, for
// the require-any-of validation of "at least one parameter" endpoints.
const notGivenCondition = (property: CsProperty): string =>
  property.type.startsWith('Optional<')
    ? `!${property.pascalName}.IsSet`
    : `${property.pascalName} == null`

export const buildRoute = (
  endpoint: Endpoint,
  modelTypes: Set<string>,
): CsRoute => {
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

  // An endpoint that requires parameters without any individual parameter
  // being required needs at least one of them, checked locally before the
  // request is sent.
  const requiresAnyParameter =
    endpoint.request.hasRequiredParameters &&
    endpoint.request.parameters.every((parameter) => !parameter.isRequired)
  if (requiresAnyParameter) {
    request.main.requireAnyOf = {
      path: endpoint.path,
      conditions: request.properties.map(notGivenCondition),
    }
  }

  // The request object is only optional when the endpoint requires nothing.
  const requestOptional = !endpoint.request.hasRequiredParameters

  const routeDocumentation = {
    documentation: endpoint.description,
    ...(endpoint.isDeprecated
      ? { obsoleteMessage: endpoint.deprecationMessage || 'Deprecated.' }
      : {}),
  }

  const returned = responseReturn(endpoint.response, modelTypes)

  if (returned == null) {
    return {
      methodName,
      path: endpoint.path,
      httpMethod,
      request: request.main,
      requestSiblings: request.siblings,
      responseSiblings: [],
      isVoid: true,
      usesActionAttempt: false,
      usesPagination: false,
      requestOptional,
      ...routeDocumentation,
    }
  }

  const { returnType, returnProp, model, isList } = returned
  const responseKey = (endpoint.response as { responseKey: string }).responseKey
  const usesActionAttempt = model === 'ActionAttempt' && !isList
  const usesPagination = endpoint.hasPagination && isList

  const responseClassName = pascalCase(`${endpoint.name}_response`)
  const responseFields: Field[] = [
    {
      name: responseKey,
      description: endpoint.response.description,
      isRequired: false,
      isNullable: true,
      kind: { t: 'ref', cs: returnType },
    },
    ...(usesPagination
      ? [
          {
            name: 'pagination',
            description: 'The pagination metadata for the page of results.',
            isRequired: false,
            isNullable: true,
            kind: { t: 'ref', cs: 'Pagination' } as Kind,
          },
        ]
      : []),
  ]
  const response = buildClass(responseClassName, responseFields, {
    resourceType: 'response',
  })

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
    returnKey: snakeCase(responseKey),
    returnType,
    isVoid: false,
    usesActionAttempt,
    usesPagination,
    ...(usesPagination ? { pageItemType: model } : {}),
    requestOptional,
    ...routeDocumentation,
  }
}
