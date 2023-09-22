import path from 'path'
import axios from 'axios'
import { pascalCase } from 'change-case'
import {
  deepFlattenAllOfSchema,
  getParameterAndResponseSchema,
  populateFs,
  type OpenAPISchema,
  type PropertySchema,
  type Route,
} from '@seamapi/nextlove-sdk-generator'

import * as cs from './codegen.js'
import {
  type RouteInfo,
  generateDataclassFileForSchema,
  generateDataclassFileForRoutes,
} from './templates/dataclass.js'

Error.stackTraceLimit = Infinity

export const GLOBAL_NAMESPACE = ['Seam']

export const generateCSharpSDK = async () => {
  const openapi: OpenAPISchema = await axios
    .get('https://connect.getseam.com/openapi.json')
    .then((res) => res.data)
  const routes: Route[] = Object.entries(openapi.paths).map(([path, v]) => ({
    path,
    ...v,
  }))

  const fs: any = {}

  populateFs(
    // FIXME: __dirname is not giving the right path here
    path.join(process.cwd(), 'src/templates/fs'),
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

    const { parameter_schema, response_obj_type, response_arr_type, nullable } =
      getParameterAndResponseSchema(route)

    if (!response_obj_type && !response_arr_type) {
      console.log(`No response object/array ref for "${route.path}", skipping`)
      continue
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
