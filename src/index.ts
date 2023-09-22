import { generateCSharpSDK } from './generate-csharp-sdk.js'
import { writeFs } from '@seamapi/nextlove-sdk-generator'
async function main() {
  const filesystem = await generateCSharpSDK()
  writeFs('./output/csharp', filesystem)
}

main()
