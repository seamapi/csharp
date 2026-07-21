import { readdirSync, readFileSync } from 'node:fs'
import { join, relative } from 'node:path'

// Recursively reads a directory into a virtual filesystem object, keyed by the
// path of each file relative to `dir`. Replaces the nextlove populateFs (which
// depended on @nodelib/fs.walk) with a dependency-free equivalent.
export const populateFs = (
  dir: string,
  filesystem: Record<string, string>,
): void => {
  const walk = (current: string): void => {
    for (const entry of readdirSync(current, { withFileTypes: true })) {
      const filePath = join(current, entry.name)
      if (entry.isDirectory()) {
        walk(filePath)
      } else {
        filesystem[relative(dir, filePath)] = readFileSync(filePath, 'utf-8')
      }
    }
  }

  walk(dir)
}
