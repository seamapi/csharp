import { csprojTemplate } from '../node_modules/@seamapi/nextlove-sdk-generator/lib/generate-csharp-sdk/generate-csproj.js'
import { writeFileSync } from 'fs'

import packageJson from '../package.json'

const main = async () => {
  writeFileSync(
    './output/csharp/src/Seam/Seam.csproj',
    csprojTemplate(packageJson.version, ['6.0', '7.0']),
  )
}

main()
