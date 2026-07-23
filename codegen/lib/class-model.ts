// Durable data model for the C# SDK codegen.
//
// These interfaces hold the resolved structure of each generated file, decoupled
// from serialization. build-model.ts produces them from the @seamapi/blueprint;
// the Handlebars layouts turn them into C#. String serialization lives entirely
// in the templates.

// A single enum member, e.g. `[EnumMember(Value = "setting")] Setting = 1,`.
export interface CsEnumMember {
  identifier: string
  assign: number
  // The value rendered inside [EnumMember(Value = ...)]. Strings are quoted by
  // the template (isString), numbers are emitted bare.
  value: string | number
}

export interface CsEnum {
  name: string
  isString: boolean
  members: CsEnumMember[]
}

// A resolved property: one [DataMember] declaration plus its constructor
// parameter and assignment (which share the property's order and type).
export interface CsProperty {
  pascalName: string
  camelName: string
  snakeName: string
  type: string
  isRequired: boolean
  isOverride: boolean
  // A get-only property (no setter): the discriminator override and enum
  // overrides.
  getOnly: boolean
  // A constant initializer appended to the property, e.g. ` = "LOCK_DOOR"`.
  initializer?: string
}

// An extra member nested inside a class body (before the properties): an inline
// enum or a nested discriminated union, kept in property-processing order.
export interface CsNested {
  enum?: CsEnum
  union?: CsUnion
}

// A concrete data class: [DataContract] + JsonConstructor ctor + public all-args
// ctor + nested enums/unions + [DataMember] properties + ToString.
export interface CsClass {
  kind: 'class'
  className: string
  dataContractName: string
  baseClass?: string
  nested: CsNested[]
  properties: CsProperty[]
}

// The abstract base of a discriminated union.
export interface CsAbstractProp {
  type: string
  pascalName: string
  getOnly: boolean
}

export interface CsUnion {
  kind: 'union'
  className: string
  discriminatorSnake: string
  // typeof(...) subtype attributes, in their emitted (reversed) order.
  knownSubTypes: Array<{ typeName: string; value: string }>
  unrecognizedTypeName: string
  abstractProps: CsAbstractProp[]
  // Concrete subclasses followed by the Unrecognized fallback, in definition
  // order.
  subclasses: CsClass[]
}

export type CsDecl = CsClass | CsUnion

// A generated model file (output/csharp/src/Seam/Model/<Name>.cs): one or more
// top-level declarations (the main type first, then sibling classes spawned by
// inline-object properties).
export interface CsModelFile {
  decls: CsDecl[]
}

// A single route method (generates four overloads: sync/async x request-object/
// expanded-params).
export interface CsRoute {
  methodName: string
  path: string
  request: CsClass
  // Sibling classes spawned by inline-object request/response properties,
  // rendered (nested) inside the Api class after the request/response class.
  requestSiblings: CsClass[]
  responseSiblings: CsClass[]
  response?: CsClass
  // The type argument to _seam.Post<T> (the response class, or `object` for void).
  responseTypeArg: string
  // The `.Data.<returnProp>` accessor tail (absent for void).
  returnProp?: string
  // The declared return type, e.g. `Webhook` or `List<Webhook>` (absent for void).
  returnType?: string
  isVoid: boolean
  // Expanded-overload parameters (the request class properties).
  params: CsProperty[]
}

// A generated Api file (output/csharp/src/Seam/Api/<Name>.cs).
export interface CsApiFile {
  className: string
  routes: CsRoute[]
}
