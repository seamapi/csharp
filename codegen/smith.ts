import { dirname } from 'node:path'
import { fileURLToPath } from 'node:url'

import layouts from '@metalsmith/layouts'
import { blueprint, getHandlebarsPartials } from '@seamapi/smith'
import * as types from '@seamapi/types/connect'
import Metalsmith from 'metalsmith'

import { csharp, helpers } from './lib/index.js'

const rootDir = dirname(fileURLToPath(import.meta.url))

const partials = await getHandlebarsPartials(`${rootDir}/layouts/partials`)

// The destination is the repository root, so cleaning is left disabled to avoid
// deleting checked-in package source. Generated files no longer produced by the
// blueprint are pruned by removing them from version control.
Metalsmith(rootDir)
  .source('./content')
  .destination('../')
  .clean(false)
  .use(blueprint({ types }))
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
