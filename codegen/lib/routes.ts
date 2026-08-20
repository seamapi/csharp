// The Metalsmith plugin that generates the C# SDK source files.
//
// The blueprint from @seamapi/blueprint is the only input: it drives the
// resource models written to src/Seam/Models, the route client classes written
// to src/Seam/Routes, and the SeamClient partial wiring the root clients.

import type { Blueprint } from '@seamapi/blueprint'
import { camelCase, pascalCase } from 'change-case'
import type Metalsmith from 'metalsmith'

import {
  buildActionAttemptFile,
  buildEventFile,
  buildModelFile,
  buildRoute,
} from './build-model.js'
import type { CsClientChild, CsRoute } from './class-model.js'

const outputRoot = 'src/Seam'

// Resource types that are emitted as discriminated unions rather than plain
// model classes.
const UNION_RESOURCE_TYPES = new Set(['event', 'action_attempt'])

interface Client {
  className: string
  segments: string[]
  children: CsClientChild[]
  routes: CsRoute[]
}

// Metalsmith plugin that generates the blueprint-derived C# SDK files: the
// route client classes (src/Seam/Routes/*.cs) and the resource models
// (src/Seam/Models/*.cs). Static, schema-independent files (the handwritten
// runtime, the .sln, the test project) are normal committed package source and
// are intentionally NOT generated here.
//
// The blueprint is placed on the Metalsmith metadata by the @seamapi/smith
// `blueprint` plugin, which must run before this one.
export const routes = (
  files: Metalsmith.Files,
  metalsmith: Metalsmith,
): void => {
  const { blueprint } = metalsmith.metadata() as { blueprint: Blueprint }

  const writeModel = (name: string, file: unknown): void => {
    files[`${outputRoot}/Models/${name}.cs`] = {
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

  // Route client classes, one file per client. Each route path maps to a
  // client class, e.g. /acs/users to AcsUsers, wired to a property on its
  // parent client (Acs) or, for top-level routes, on the SeamClient itself.
  const classMap = new Map<string, Client>()

  const ensureClient = (segments: string[]): Client => {
    const className = pascalCase(segments.join('_'))
    const existing = classMap.get(className)
    if (existing != null) return existing

    const client: Client = { className, segments, children: [], routes: [] }
    classMap.set(className, client)

    if (segments.length > 1) {
      const parent = ensureClient(segments.slice(0, -1))
      parent.children.push({
        className,
        propertyName: pascalCase(segments.at(-1) as string),
      })
    }

    return client
  }

  for (const route of blueprint.routes) {
    if (route.endpoints.length === 0) continue

    const segments = route.path.split('/').filter((s) => s.length > 0)
    const client = ensureClient(segments)

    for (const endpoint of route.endpoints) {
      client.routes.push(buildRoute(endpoint, modelTypes))
    }
  }

  const clients = [...classMap.values()]

  for (const client of clients) {
    files[`${outputRoot}/Routes/${client.className}.cs`] = {
      contents: Buffer.from('\n'),
      layout: 'route.hbs',
      className: client.className,
      children: client.children,
      routes: client.routes,
    }
  }

  const roots = clients
    .filter((client) => client.segments.length === 1)
    .map((client) => ({
      className: client.className,
      propertyName: client.className,
      fieldName: camelCase(client.className),
    }))
    .sort((a, b) => a.className.localeCompare(b.className))

  files[`${outputRoot}/Routes/SeamClientRoutes.cs`] = {
    contents: Buffer.from('\n'),
    layout: 'client-routes.hbs',
    roots,
  }
}
