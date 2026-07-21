// TEMPORARY: Verbatim port of @seamapi/nextlove-sdk-generator lib/generate-csharp-sdk/generate-csharp-sdk.ts.
// This is a frozen output-parity workaround: it exists only so the
// generated output stays byte-identical to the previous generator.
// Do not review, refactor, or improve it.
// TODO: Delete this file and drive generation from @seamapi/blueprint once
// the generated output is allowed to change.
// @ts-nocheck
/* eslint-disable */
import * as url from 'url'
import path from 'path'
import { pascalCase } from 'change-case'
import { deepFlattenAllOfSchema } from './openapi/flatten-obj-schema.js'
import { getParameterAndResponseSchema } from './openapi/get-parameter-and-response-schema.js'
import { populateFs } from './populate-fs.js'
import { type OpenAPISchema, type PropertySchema, type Route } from './types.js'
import { modifySchemaForSpecialCases } from './schema-modifications.js'

import * as cs from './codegen.js'
import {
  type RouteInfo,
  generateDataclassFileForSchema,
  generateDataclassFileForRoutes,
} from './dataclass.js'
import { GLOBAL_NAMESPACE } from './constants.js'
import { getFilteredRoutes } from './openapi/get-filtered-routes.js'

Error.stackTraceLimit = Infinity

// Returns a virtual filesystem mapping paths (relative to output/csharp) to
// file contents, mirroring the nextlove generateCSharpSDK. The csproj is not
// emitted here; the untouched generate:csproj script owns it.
export const generateCSharpSdkFilesystem = (
  openapi: OpenAPISchema,
): Record<string, string> => {
  const routes: Route[] = getFilteredRoutes(openapi)

  const fs: any = {}

  populateFs(
    path.join(url.fileURLToPath(new URL('.', import.meta.url)), 'templates/fs'),
    fs,
  )

  const compilerCtx = new cs.CompilerCtx()

  const classMap: Record<string, RouteInfo[]> = {}

  for (const route of routes) {
    if (!route.post) continue
    if (!route.post['x-fern-sdk-group-name']) continue
    const group_names = [...route.post['x-fern-sdk-group-name']]
    const namespace = group_names
    group_names.reverse()
    const class_name = pascalCase(group_names.join('_'))

    const {
      parameter_schema,
      response_obj_type,
      response_arr_type,
      nullable,
      response_schema,
    } = getParameterAndResponseSchema(route)

    let is_void = false

    if (!response_obj_type && !response_arr_type) {
      if (
        !response_schema ||
        'oneOf' in response_schema ||
        (Object.keys(response_schema.properties).filter(
          (k) => k.toLowerCase() !== 'ok',
        ).length > 0 &&
          route.post['x-response-key'] !== null)
      ) {
        console.log(
          `No response object/array ref for "${route.path}", skipping`,
        )
        continue
      }

      is_void = true
    }

    if (!parameter_schema) {
      console.log(`No parameter schema for "${route.path}", skipping`)
      continue
    }

    const routeInfo: RouteInfo = {
      method_name: route.post['x-fern-sdk-method-name'],
      path: route.path,
      parameter_schema,
      response_obj_type,
      response_arr_type,
      is_void,
      return_path: route.post['x-fern-sdk-return-value'],
      namespace,
      nullable,
    }

    classMap[class_name] ??= []
    classMap[class_name]!.push(routeInfo)
  }

  for (const [class_name, routes] of Object.entries(classMap)) {
    const { classFile, className } = generateDataclassFileForRoutes(
      class_name,
      routes,
      [...GLOBAL_NAMESPACE, 'Api'],
    )

    fs[`src/Seam/Api/${className}.cs`] = classFile.serialize(compilerCtx)
  }

  Object.entries(openapi.components.schemas)
    .map(
      ([schema_name, schema]) =>
        [schema_name, schema] as [string, PropertySchema],
    )
    .forEach(([schema_name, schema]) => {
      try {
        schema = modifySchemaForSpecialCases(schema_name, schema)

        if ('allOf' in schema) {
          const flattened = deepFlattenAllOfSchema(schema)
          if (flattened == null) return

          schema = flattened
        }

        const { classFile, name } = generateDataclassFileForSchema(
          schema_name,
          schema,
          'model',
          [...GLOBAL_NAMESPACE, 'Model'],
        )

        fs[`src/Seam/Model/${name}.cs`] = classFile.serialize(compilerCtx)
      } catch (e) {
        console.log(`Failed at ${schema_name}`)
        throw e
      }
    })

  return fs
}
