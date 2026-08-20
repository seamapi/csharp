// Durable data model for the C# SDK codegen.
//
// These interfaces hold the resolved structure of each generated file, decoupled
// from serialization. build-model.ts produces them from the @seamapi/blueprint;
// the Handlebars layouts turn them into C#. String serialization lives entirely
// in the templates, except for the computed C# type names and the
// require-any-of validation conditions.

// A single enum member, e.g. `[EnumMember(Value = "setting")] Setting = 1,`.
export interface CsEnumMember {
  identifier: string
  assign: number
  // The value rendered inside [EnumMember(Value = ...)]. Strings are quoted by
  // the template (isString), numbers are emitted bare.
  value: string | number
  documentation?: string
  obsoleteMessage?: string
}

export interface CsEnum {
  name: string
  isString: boolean
  members: CsEnumMember[]
  documentation?: string
}

// A resolved property: one [JsonPropertyName] init property.
export interface CsProperty {
  pascalName: string
  snakeName: string
  type: string
  // Emits the C# `required` modifier: the property must be set in the object
  // initializer, enforcing required request parameters at compile time.
  isRequired: boolean
  isOverride: boolean
  // A get-only property (no init): the discriminator override.
  getOnly: boolean
  // An initializer appended to the property, e.g. ` = "LOCK_DOOR"` for a
  // discriminator or ` = default!` for a leniently-deserialized model property.
  initializer?: string
  documentation?: string
  obsoleteMessage?: string
}

// An extra member nested inside a class body (before the properties): an inline
// enum or a nested discriminated union, kept in property-processing order.
export interface CsNested {
  enum?: CsEnum
  union?: CsUnion
}

// A concrete data record: [JsonPropertyName] init properties plus nested
// enums/unions.
export interface CsClass {
  kind: 'class'
  className: string
  baseClass?: string
  // The generated `…Unrecognized` fallback variant of a union, which also
  // implements ISeamUnrecognizedVariant to preserve the raw payload.
  isUnrecognizedFallback?: boolean
  nested: CsNested[]
  properties: CsProperty[]
  // An "at least one parameter is required" endpoint constraint, validated
  // locally before the request is sent.
  requireAnyOf?: { path: string; conditions: string[] }
  documentation?: string
  obsoleteMessage?: string
}

export interface CsUnion {
  kind: 'union'
  className: string
  discriminatorSnake: string
  discriminatorPascal: string
  // [SeamUnionVariant] attributes, in variant definition order.
  knownSubTypes: Array<{ typeName: string; value: string }>
  unrecognizedTypeName: string
  // Properties shared by every variant, declared concretely on the base so
  // consumers can read them polymorphically without downcasting. Subclasses
  // inherit them rather than redeclare them.
  baseProps: CsProperty[]
  // Concrete subclasses followed by the Unrecognized fallback, in definition
  // order.
  subclasses: CsClass[]
}

export type CsDecl = CsClass | CsUnion

// A generated model file (src/Seam/Models/<Name>.cs): one or more
// top-level declarations (the main type first, then sibling classes spawned by
// inline-object properties).
export interface CsModelFile {
  decls: CsDecl[]
}

// A single route method: one async request-object method with a
// CancellationToken, plus page/pager methods for paginated endpoints.
export interface CsRoute {
  methodName: string
  path: string
  // The System.Net.Http.HttpMethod property for the endpoint's semantic HTTP
  // method, e.g. `Get` for `HttpMethod.Get`. The transport decides from the
  // method whether the request parameters travel as a query string or as a
  // JSON body.
  httpMethod: string
  request: CsClass
  // Sibling classes spawned by inline-object request/response properties,
  // rendered (nested) inside the route class after the request/response class.
  requestSiblings: CsClass[]
  responseSiblings: CsClass[]
  response?: CsClass
  // The type argument to the transport call (the response class name).
  responseTypeArg?: string
  // The response property the return value is unwrapped from (absent for void).
  returnProp?: string
  // The wire name of that property, for error messages.
  returnKey?: string
  // The declared return type, e.g. `Workspace` or `List<Workspace>` (absent
  // for void).
  returnType?: string
  isVoid: boolean
  // The endpoint returns a single action attempt: the method takes a
  // `waitForActionAttempt` option and resolves the attempt before returning.
  usesActionAttempt: boolean
  // The endpoint is paginated: the response keeps its `pagination` envelope
  // and the route also emits `<Method>PageAsync` and `<Method>Pager`.
  usesPagination: boolean
  // The item type of a paginated endpoint, e.g. `Device`.
  pageItemType?: string
  // Every request parameter is optional, so the request object itself is too.
  requestOptional: boolean
  documentation?: string
  obsoleteMessage?: string
}

// A child route client exposed as a property, e.g. `Users` on `Acs`.
export interface CsClientChild {
  className: string
  propertyName: string
}

// A generated route client file (src/Seam/Routes/<Name>.cs).
export interface CsRouteFile {
  className: string
  children: CsClientChild[]
  routes: CsRoute[]
}

// The generated SeamClient partial wiring the root route clients.
export interface CsClientRootsFile {
  roots: Array<CsClientChild & { fieldName: string }>
}
