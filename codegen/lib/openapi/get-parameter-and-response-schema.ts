// TEMPORARY: Verbatim port of @seamapi/nextlove-sdk-generator lib/openapi/get-parameter-and-response-schema.ts.
// This is a frozen output-parity workaround: it exists only so the
// generated output stays byte-identical to the previous generator.
// Do not review, refactor, or improve it.
// TODO: Delete this file and drive generation from @seamapi/blueprint once
// the generated output is allowed to change.
// @ts-nocheck
/* eslint-disable */
import type { ObjSchema, Route } from '../types.js'
import { flattenObjSchema } from './flatten-obj-schema.js'
import { deepFlattenOneOfAndAllOfSchema } from './deep-flatten-one-of-and-all-of-schema.js'

export const getParameterAndResponseSchema = (route: Route) => {
  const response_schema =
    route.post.responses['200']?.content?.['application/json']?.schema

  const nullable = !(
    response_schema &&
    'required' in response_schema &&
    response_schema.required?.includes(route.post['x-response-key'] ?? '')
  )

  if (!response_schema) {
    return { nullable }
  }

  if (!route.post.requestBody) {
    route.post.requestBody = {
      content: {
        'application/json': { schema: { type: 'object', properties: {} } },
      },
    } as any
  }

  if (!route.post.requestBody.content?.['application/json']) {
    return { nullable }
  }

  const parameter_schema = processParameterSchema(
    route.post.requestBody.content['application/json'].schema,
  )

  const res_return_schema = (response_schema as any).properties[
    route.post['x-response-key'] ?? ''
  ]

  const response_obj_ref = res_return_schema?.$ref
  const response_arr_ref = res_return_schema?.items?.$ref

  if (route.post['x-response-key'] === 'batch') {
    return {
      response_obj_type: route.post['x-response-key'],
      response_arr_type: undefined,
      parameter_schema,
      nullable,
      response_schema,
    }
  } else if (!response_obj_ref && !response_arr_ref) {
    return {
      response_obj_type: undefined,
      response_arr_type: undefined,
      parameter_schema,
      nullable,
      response_schema,
    }
  } else {
    return {
      response_obj_type: response_obj_ref?.split('/')?.pop(),
      response_arr_type: response_arr_ref?.split('/')?.pop(),
      parameter_schema,
      res_return_schema: res_return_schema as ObjSchema | undefined,
      nullable,
      response_schema,
    }
  }
}

function processParameterSchema(
  schema:
    | ObjSchema
    | {
        oneOf: Array<ObjSchema>
      }
    | {
        allOf: Array<ObjSchema>
      },
): ObjSchema {
  const parameter_schema = flattenObjSchema(schema)

  for (const [param_name, param_value] of Object.entries(
    parameter_schema.properties,
  )) {
    if ('oneOf' in param_value || 'allOf' in param_value) {
      parameter_schema.properties[param_name] =
        deepFlattenOneOfAndAllOfSchema(param_value)
    }
  }

  return parameter_schema
}
