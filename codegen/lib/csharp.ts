import * as types from '@seamapi/types/connect'
import { pascalCase } from 'change-case'
import type Metalsmith from 'metalsmith'

import { buildApiFile, buildModelFile } from './build-model.js'
import { GLOBAL_NAMESPACE } from './constants.js'
import { deepFlattenAllOfSchema } from './openapi/flatten-obj-schema.js'
import { getFilteredRoutes } from './openapi/get-filtered-routes.js'
import { getParameterAndResponseSchema } from './openapi/get-parameter-and-response-schema.js'
import { modifySchemaForSpecialCases } from './schema-modifications.js'
import type { ObjSchema, OpenAPISchema, PropertySchema } from './types.js'

const outputRoot = 'output/csharp/src/Seam'

interface RouteInfo {
  methodName: string
  path: string
  parameterSchema: ObjSchema
  responseObjType: string | undefined
  responseArrType: string | undefined
  isVoid: boolean
  nullable: boolean
  returnPath: string
}

// Metalsmith plugin that generates the schema-derived C# SDK files: the Api
// route classes (output/csharp/src/Seam/Api/*.cs) and the resource models
// (output/csharp/src/Seam/Model/*.cs). Static, schema-independent files (the
// Client/* runtime, the two static Model helpers, the .sln, the test project)
// are normal committed package source and are intentionally NOT generated here.
//
// The iteration reads the raw OpenAPI spec from @seamapi/types rather than
// @seamapi/blueprint so the generated output stays byte-identical to the
// previous generator.
// TODO: Drive iteration and structure from metalsmith.metadata().blueprint once
// the generated output is allowed to change. Blueprint is not wired into the
// pipeline: the port does not use blueprint data, and @seamapi/blueprint does
// not currently parse the pinned @seamapi/types.
export const csharp = (files: Metalsmith.Files): void => {
  const openapi = types.openapi as unknown as OpenAPISchema

  const classMap: Record<string, RouteInfo[]> = {}

  for (const route of getFilteredRoutes(openapi)) {
    if (!route.post) continue
    if (!route.post['x-fern-sdk-group-name']) continue

    const groupNames = [...route.post['x-fern-sdk-group-name']]
    groupNames.reverse()
    const className = pascalCase(groupNames.join('_'))

    const {
      parameter_schema: parameterSchema,
      response_obj_type: responseObjType,
      response_arr_type: responseArrType,
      nullable,
      response_schema: responseSchema,
    } = getParameterAndResponseSchema(route)

    let isVoid = false
    if (!responseObjType && !responseArrType) {
      if (
        !responseSchema ||
        'oneOf' in responseSchema ||
        (Object.keys(responseSchema.properties).filter(
          (k) => k.toLowerCase() !== 'ok',
        ).length > 0 &&
          route.post['x-response-key'] !== null)
      ) {
        continue
      }
      isVoid = true
    }

    if (!parameterSchema) continue

    ;(classMap[className] ??= []).push({
      methodName: route.post['x-fern-sdk-method-name'],
      path: route.path,
      parameterSchema,
      responseObjType,
      responseArrType,
      isVoid,
      nullable,
      returnPath: route.post['x-fern-sdk-return-value'],
    })
  }

  for (const [className, routes] of Object.entries(classMap)) {
    const apiFile = buildApiFile(className, routes)
    files[`${outputRoot}/Api/${apiFile.className}.cs`] = {
      contents: Buffer.from('\n'),
      layout: 'api.hbs',
      ...apiFile,
    }
  }

  for (const [schemaName, rawSchema] of Object.entries(
    openapi.components.schemas,
  )) {
    let schema = modifySchemaForSpecialCases(
      schemaName,
      rawSchema as PropertySchema,
    )

    if ('allOf' in schema) {
      const flattened = deepFlattenAllOfSchema(schema)
      if (flattened == null) continue
      schema = flattened
    }

    const { name, file } = buildModelFile(schemaName, schema, [
      ...GLOBAL_NAMESPACE,
      'Model',
    ])
    files[`${outputRoot}/Model/${name}.cs`] = {
      contents: Buffer.from('\n'),
      layout: 'model.hbs',
      ...file,
    }
  }
}
