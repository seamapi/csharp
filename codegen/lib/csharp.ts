import * as types from '@seamapi/types/connect'
import type Metalsmith from 'metalsmith'

import { generateCSharpSdkFilesystem } from './generate-csharp-sdk.js'
import type { OpenAPISchema } from './types.js'

// Root of the generated C# SDK, relative to the Metalsmith destination.
const outputRoot = 'output/csharp'

// Metalsmith plugin that generates the C# SDK files.
//
// The generation logic is a verbatim port of @seamapi/nextlove-sdk-generator
// (see ./generate-csharp-sdk.js and the other TEMPORARY-bannered files); it
// consumes the raw OpenAPI spec from @seamapi/types rather than
// @seamapi/blueprint so the generated output stays byte-identical to the
// previous generator. Each generated file is emitted with the passthrough
// default layout: the plugin already produces the full file contents.
//
// TODO: Drive iteration and structure from metalsmith.metadata().blueprint
// once the generated output is allowed to change. The blueprint plugin is not
// wired into the pipeline yet: the port does not use blueprint data, and
// @seamapi/blueprint does not currently parse the pinned @seamapi/types.
export const csharp = (files: Metalsmith.Files): void => {
  const openapi = types.openapi as unknown as OpenAPISchema
  const filesystem = generateCSharpSdkFilesystem(openapi)

  for (const [filepath, contents] of Object.entries(filesystem)) {
    files[`${outputRoot}/${filepath}`] = {
      contents: Buffer.from(contents),
      layout: 'default.hbs',
    }
  }
}
