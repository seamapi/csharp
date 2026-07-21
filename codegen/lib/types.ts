// TEMPORARY: Verbatim port of @seamapi/nextlove-sdk-generator lib/types.ts.
// This is a frozen output-parity workaround: it exists only so the
// generated output stays byte-identical to the previous generator.
// Do not review, refactor, or improve it.
// TODO: Delete this file and drive generation from @seamapi/blueprint once
// the generated output is allowed to change.
// @ts-nocheck
export type OpenAPISchema = {
  servers: [{ url: string }]
  tags: Array<{ name: string; description: string }>
  paths: Record<string, Omit<Route, 'path'>>
  components: {
    securitySchemas: Record<
      string,
      | { type: 'apiKey'; in: 'header'; name: string }
      | { type: 'http'; scheme: 'bearer'; bearerFormat: 'API Token' }
    >
    schemas: Record<
      string,
      | {
          type: 'object'
          properties: Record<
            string,
            {
              type: 'string' | 'integer' | 'boolean' | 'array' | 'number'
              items?: { $ref: string }
              $ref?: string
            }
          >
          required?: string[]
        }
      | OneOfSchema
      | AllOfSchema
    >
  }
}

export type PropertySchema =
  | PrimitiveSchema
  | AllOfSchema
  | OneOfSchema
  | RefSchema
  | ObjSchema
  | ArraySchema

export type PrimitiveSchema =
  | {
      type: 'string'
      enum?: string[]
      format?: 'uuid' | 'date-time' | 'uri'
      nullable?: boolean
    }
  | { type: 'boolean'; enum?: boolean[]; nullable?: boolean }
  | { type: 'integer'; enum?: number[]; nullable?: boolean }
  | { type: 'number'; nullable?: boolean }

export type ArraySchema = {
  type: 'array'
  items: PropertySchema
  nullable?: boolean
}

export type ObjSchema = {
  type: 'object'
  properties: Record<string, PropertySchema>
  required: string[]
  nullable?: boolean
}

export type RefSchema = {
  $ref: string
  nullable?: boolean
}

export type AllOfSchema = {
  allOf: PropertySchema[]
}

export type OneOfSchema = {
  oneOf: PropertySchema[]
  discriminator?: {
    propertyName: string
  }
}

export type RequestResponseDef = {
  content: {
    'application/json': {
      schema:
        | ObjSchema
        | {
            oneOf: Array<ObjSchema>
          }
    }
  }
}

export type Route = {
  path: string
  post: {
    summary: string
    'x-fern-sdk-group-name': string[]
    'x-fern-sdk-method-name': string
    'x-fern-sdk-return-value': string
    'x-response-key': string | null
    responses: { 200: RequestResponseDef }
    requestBody: RequestResponseDef
    'x-undocumented'?: string
  }
}

export type SdkGeneratorOptions = {
  openApiSpecObject?: OpenAPISchema
  openApiSpecPath?: string
}
