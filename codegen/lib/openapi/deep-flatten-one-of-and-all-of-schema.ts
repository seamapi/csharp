// TEMPORARY: Verbatim port of @seamapi/nextlove-sdk-generator lib/openapi/deep-flatten-one-of-and-all-of-schema.ts.
// This is a frozen output-parity workaround: it exists only so the
// generated output stays byte-identical to the previous generator.
// Do not review, refactor, or improve it.
// TODO: Delete this file and drive generation from @seamapi/blueprint once
// the generated output is allowed to change.
// @ts-nocheck
/* eslint-disable */
import type {
  AllOfSchema,
  ArraySchema,
  ObjSchema,
  OneOfSchema,
  PrimitiveSchema,
  PropertySchema,
} from '../types.js'

export function deepFlattenOneOfAndAllOfSchema(schema: PropertySchema) {
  if ('oneOf' in schema) {
    return flattenOneOf(schema)
  } else if ('allOf' in schema) {
    return flattenAllOf(schema)
  } else if (
    'type' in schema &&
    schema.type === 'object' &&
    schema.properties
  ) {
    return flattenObject(schema)
  } else if ('type' in schema && schema.type === 'array' && schema.items) {
    return flattenArray(schema)
  } else {
    // For primitive types, return the schema as is
    return schema
  }
}

function flattenOneOf(one_of_schema: OneOfSchema): ObjSchema | PrimitiveSchema {
  const flattened_schema = {
    type: 'object',
    properties: {},
    required: [],
  } as ObjSchema

  for (const sub_schema of one_of_schema.oneOf) {
    const flattened_sub_schema = deepFlattenOneOfAndAllOfSchema(sub_schema)

    // Check if the sub-schema is a primitive schema
    if (
      'type' in flattened_sub_schema &&
      !('properties' in flattened_sub_schema)
    ) {
      return { type: flattened_sub_schema.type } as PrimitiveSchema
    }

    if ('$ref' in flattened_sub_schema) {
      console.error('$ref not currently supported when flattening oneOf')
      continue
    }

    // Merge properties
    Object.assign(flattened_schema.properties, flattened_sub_schema.properties)

    // Update required array with common properties
    flattened_schema.required =
      flattened_schema.required.length === 0
        ? flattened_sub_schema.required
        : flattened_schema.required.filter((prop) =>
            flattened_sub_schema.required.includes(prop),
          )
  }

  return flattened_schema
}

function flattenAllOf(all_of_schema: AllOfSchema): ObjSchema | PrimitiveSchema {
  const flattened_schema = {
    type: 'object',
    properties: {},
    required: [],
  } as ObjSchema

  for (const sub_Schema of all_of_schema.allOf) {
    const flattened_sub_schema = deepFlattenOneOfAndAllOfSchema(sub_Schema)

    // Check if the sub-schema is a primitive schema
    if (
      'type' in flattened_sub_schema &&
      !('properties' in flattened_sub_schema)
    ) {
      return { type: flattened_sub_schema.type } as PrimitiveSchema
    }

    if ('$ref' in flattened_sub_schema) {
      console.error('$ref not currently supported when flattening allOf')
      continue
    }

    // Merge properties
    Object.assign(flattened_schema.properties, flattened_sub_schema.properties)

    // Merge required array
    flattened_schema.required = [
      ...new Set([
        ...flattened_schema.required,
        ...flattened_sub_schema.required,
      ]),
    ]
  }

  return flattened_schema
}

function flattenObject(obj_schema: ObjSchema) {
  const flattened_schema = {
    type: 'object',
    properties: {},
    required: obj_schema.required || [],
  } as ObjSchema

  for (const prop in obj_schema.properties) {
    flattened_schema.properties[prop] = deepFlattenOneOfAndAllOfSchema(
      obj_schema.properties[prop]!,
    )
  }

  return flattened_schema
}

function flattenArray(array_schema: ArraySchema): ArraySchema {
  const flattened_schema = {
    type: 'array',
    items: deepFlattenOneOfAndAllOfSchema(array_schema.items),
  } as ArraySchema

  return flattened_schema
}
