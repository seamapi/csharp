import { dirname } from 'node:path'
import { fileURLToPath } from 'node:url'

import layouts from '@metalsmith/layouts'
import { getHandlebarsPartials } from '@seamapi/smith'
import Metalsmith from 'metalsmith'

import { csharp, helpers } from './lib/index.js'

const rootDir = dirname(fileURLToPath(import.meta.url))

const partials = await getHandlebarsPartials(`${rootDir}/layouts/partials`)

// TODO: Clean the generated output directory before regenerating once the
// generated output is allowed to change. The previous nextlove generator
// overwrote files without deleting, so the committed output still contains
// stale files (e.g. models and routes for schemas removed from the pinned
// @seamapi/types). Deleting them here would remove those files and change the
// output, so cleaning is intentionally skipped to stay byte-identical.

Metalsmith(rootDir)
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
