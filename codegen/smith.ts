import { dirname } from 'node:path'
import { fileURLToPath } from 'node:url'

import layouts from '@metalsmith/layouts'
import { blueprint, getHandlebarsPartials } from '@seamapi/smith'
import * as types from '@seamapi/types/connect'
import { deleteAsync } from 'del'
import Metalsmith from 'metalsmith'

import { helpers, routes } from './lib/index.js'

const rootDir = dirname(fileURLToPath(import.meta.url))

// The generated directories are deleted before every build so files no longer
// produced by the blueprint never linger. Handwritten runtime source lives
// outside these directories.
await deleteAsync(['./src/Seam/Routes', './src/Seam/Models'])

const partials = await getHandlebarsPartials(`${rootDir}/layouts/partials`)

// The destination is the repository root, so Metalsmith cleaning stays
// disabled to avoid deleting checked-in package source; the delete above
// prunes the generated directories instead.
//
// `omitUndocumented` excludes undocumented routes, endpoints, resources, and
// properties from the blueprint so the generated SDK contains only the public
// API surface; the codegen relies on this instead of filtering them itself.
Metalsmith(rootDir)
  .source('./content')
  .destination('../')
  .clean(false)
  .use(blueprint({ types, omitUndocumented: true }))
  .use(routes)
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
