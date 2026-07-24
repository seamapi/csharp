import type { Blueprint, Endpoint } from '@seamapi/blueprint'
import { pascalCase } from 'change-case'
import type Metalsmith from 'metalsmith'

import {
  buildActionAttemptFile,
  buildApiFile,
  buildEventFile,
  buildModelFile,
} from './build-model.js'

const outputRoot = 'output/csharp/src/Seam'

// Resource types that are emitted as discriminated unions rather than plain
// model classes.
const UNION_RESOURCE_TYPES = new Set(['event', 'action_attempt'])

// Derives the Api class name from a route path: the path segments in reverse,
// pascal-cased (e.g. /acs/credential_pools -> CredentialPoolsAcs).
const apiClassName = (path: string): string =>
  pascalCase(path.split('/').filter(Boolean).reverse().join('_'))

// Metalsmith plugin that generates the blueprint-derived C# SDK files: the Api
// route classes (output/csharp/src/Seam/Api/*.cs) and the resource models
// (output/csharp/src/Seam/Model/*.cs). Static, schema-independent files (the
// Client/* runtime, the static Model helpers, the .sln, the test project) are
// normal committed package source and are intentionally NOT generated here.
//
// The blueprint is placed on the Metalsmith metadata by the @seamapi/smith
// `blueprint` plugin, which must run before this one.
export const csharp = (
  files: Metalsmith.Files,
  metalsmith: Metalsmith,
): void => {
  const { blueprint } = metalsmith.metadata() as { blueprint: Blueprint }

  const writeModel = (name: string, file: unknown): void => {
    files[`${outputRoot}/Model/${name}.cs`] = {
      contents: Buffer.from('\n'),
      layout: 'model.hbs',
      ...(file as object),
    }
  }

  for (const resource of blueprint.resources) {
    if (UNION_RESOURCE_TYPES.has(resource.resourceType)) continue
    const { name, file } = buildModelFile(resource)
    writeModel(name, file)
  }

  if (blueprint.actionAttempts.length > 0) {
    const { name, file } = buildActionAttemptFile(blueprint.actionAttempts)
    writeModel(name, file)
  }

  if (blueprint.events.length > 0) {
    const { name, file } = buildEventFile(blueprint.events)
    writeModel(name, file)
  }

  // Resource types emitted as models, used to resolve endpoint return types.
  // action_attempt is not a resource but is emitted as a union model.
  const modelTypes = new Set(blueprint.resources.map((r) => r.resourceType))
  modelTypes.add('action_attempt')

  const endpointsByClass = new Map<string, Endpoint[]>()
  for (const route of blueprint.routes) {
    if (route.endpoints.length === 0) continue
    const className = apiClassName(route.path)
    const existing = endpointsByClass.get(className) ?? []
    endpointsByClass.set(className, [...existing, ...route.endpoints])
  }

  for (const [className, endpoints] of endpointsByClass) {
    const apiFile = buildApiFile(className, endpoints, modelTypes)
    files[`${outputRoot}/Api/${apiFile.className}.cs`] = {
      contents: Buffer.from('\n'),
      layout: 'api.hbs',
      ...apiFile,
    }
  }
}
