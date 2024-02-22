import { writeFs, generateCSharpSDK } from '@seamapi/nextlove-sdk-generator'

import packageJson from '../package.json'

async function main() {
    const filesystem = await generateCSharpSDK(packageJson.version)
    writeFs('./output/csharp', filesystem)
}

main()
