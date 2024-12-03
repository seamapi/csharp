import {
  writeFs,
  generateCSharpSDK,
  type OpenAPISchema,
} from '@seamapi/nextlove-sdk-generator'
import { openapi } from '@seamapi/types/connect'

import packageJson from '../package.json'

async function main() {
  const filesystem = await generateCSharpSDK({
    packageVersion: packageJson.version,
    openApiSpecObject: openapi as unknown as OpenAPISchema,
  })
  writeFs('./output/csharp', filesystem)
}

main()
