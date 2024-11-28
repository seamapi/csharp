import { writeFs, generateCSharpSDK } from '@seamapi/nextlove-sdk-generator'
import { openapi } from '@seamapi/types/connect'

import packageJson from '../package.json'

async function main() {
  const filesystem = await generateCSharpSDK({
    packageVersion: packageJson.version,
    openApiSpecObject: openapi,
  })
  writeFs('./output/csharp', filesystem)
}

main()
