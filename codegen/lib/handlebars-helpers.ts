export const identity = (x: unknown): unknown => x

export const eq = (a: unknown, b: unknown): boolean => a === b

const escapeXml = (value: string): string =>
  value
    .replaceAll('&', '&amp;')
    .replaceAll('<', '&lt;')
    .replaceAll('>', '&gt;')
    .replaceAll('"', '&quot;')
    .replaceAll("'", '&apos;')

// Render schema prose as C# XML documentation. Prefix every line so multi-line
// Markdown remains valid compiler documentation while XML-significant input is
// harmless.
export const csDoc = (documentation?: string): string => {
  const text = documentation?.trim()
  if (!text) return ''
  return [
    '/// <summary>',
    ...escapeXml(text)
      .split(/\r?\n/u)
      .map((line) => `/// ${line}`),
    '/// </summary>',
  ].join('\n')
}

// Escape a schema-supplied deprecation reason for a C# string literal.
export const csString = (value?: string): string =>
  (value ?? 'Deprecated.').replaceAll('\\', '\\\\').replaceAll('"', '\\"')
