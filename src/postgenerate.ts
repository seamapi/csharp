import { $ } from 'execa'

const run = $({ stdio: 'inherit' })

await run`tsx src/generate-csproj.ts`
await run`dotnet tool restore`
await run`dotnet csharpier ./output/csharp`
