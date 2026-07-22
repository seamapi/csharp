// TEMPORARY: Verbatim port of @seamapi/nextlove-sdk-generator lib/generate-csharp-sdk/schema-modifications.ts.
// This is a frozen output-parity workaround: it exists only so the
// generated output stays byte-identical to the previous generator.
// Do not review, refactor, or improve it.
// TODO: Delete this file and drive generation from @seamapi/blueprint once
// the generated output is allowed to change.
// @ts-nocheck
import type { PropertySchema } from './types.js'

export const modifySchemaForSpecialCases = (
  schemaName: string,
  schema: PropertySchema,
): PropertySchema => {
  if (schemaName === 'action_attempt' && 'oneOf' in schema) {
    return {
      ...schema,
      discriminator: {
        propertyName: 'action_type',
      },
      oneOf: schema.oneOf.map((subschema) => {
        if ('type' in subschema && subschema.type === 'object') {
          const props = subschema.properties || {}
          const statusProp = props['status']

          if (
            statusProp &&
            'type' in statusProp &&
            statusProp.type === 'string'
          ) {
            return {
              ...subschema,
              properties: {
                ...props,
                status: {
                  ...statusProp,
                  type: 'string',
                  enum: ['pending', 'success', 'error'],
                },
              },
            }
          }
        }
        return subschema
      }),
    }
  }
  return schema
}
