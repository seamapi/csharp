import type { CsProperty } from './class-model.js'

export const identity = (x: unknown): unknown => x

export const eq = (a: unknown, b: unknown): boolean => a === b

// Comma-joined constructor / method parameter list: `Type name = default, ...`.
export const csParams = (properties: CsProperty[]): string =>
  (properties ?? []).map((p) => `${p.type} ${p.camelName} = default`).join(', ')

// Comma-joined named-argument list for `new XRequest(...)`: `name: name, ...`.
export const csNamedArgs = (properties: CsProperty[]): string =>
  (properties ?? []).map((p) => `${p.camelName}: ${p.camelName}`).join(', ')
