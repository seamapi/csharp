import { dirname } from 'node:path'
import { fileURLToPath } from 'node:url'

import layouts from '@metalsmith/layouts'
import { createBlueprint, TypesModuleSchema } from '@seamapi/blueprint'
import { getHandlebarsPartials } from '@seamapi/smith'
import * as types from '@seamapi/types/connect'
import Metalsmith from 'metalsmith'

import { csharp, helpers } from './lib/index.js'

const rootDir = dirname(fileURLToPath(import.meta.url))

const partials = await getHandlebarsPartials(`${rootDir}/layouts/partials`)

// Build the blueprint with undocumented routes, endpoints, resources, and
// properties omitted so the generated SDK contains only the public API surface.
// The codegen relies on this instead of filtering undocumented items itself.
const blueprint = await createBlueprint(TypesModuleSchema.parse({ ...types }), {
  omitUndocumented: true,
})

// The destination is the repository root, so cleaning is left disabled to avoid
// deleting checked-in package source. Generated files no longer produced by the
// blueprint are pruned by removing them from version control.
Metalsmith(rootDir)
  .metadata({ blueprint })
  .source('./content')
  .destination('../')
  .clean(false)
  .use(csharp)
  .use(
    layouts({
      default: 'default.hbs',
      engineOptions: {
        noEscape: true,
        helpers,
        partials,
      },
    }),
  )
  .build((err) => {
    if (err != null) throw err
  })
