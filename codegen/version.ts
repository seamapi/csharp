import { readFile } from 'node:fs/promises'
import { fileURLToPath } from 'node:url'

import { $ } from 'execa'

const csprojFile = './src/Seam/Seam.csproj'

const main = async (): Promise<void> => {
  const { version } = await readPackageJson()

  if (version == null) {
    throw new Error('Missing version in package.json')
  }

  await $({ stdio: 'inherit' })`tsx codegen/generate-csproj.ts`

  const data = await readFile(
    fileURLToPath(new URL(`../${csprojFile}`, import.meta.url)),
  )

  if (!data.toString().includes(`<Version>${version}</Version>`)) {
    throw new Error(`Could not find version ${version} in ${csprojFile}`)
  }

  // eslint-disable-next-line no-console
  console.log(`✓ Version ${version} injected into ${csprojFile}`)

  const { command } = await $`git add ${csprojFile}`
  // eslint-disable-next-line no-console
  console.log(`✓ Staged with '${command}'`)
}

const readPackageJson = async (): Promise<{ version?: string }> => {
  const pkgBuff = await readFile(
    fileURLToPath(new URL('../package.json', import.meta.url)),
  )
  return JSON.parse(pkgBuff.toString())
}

await main()
