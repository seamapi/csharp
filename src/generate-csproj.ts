import { writeFileSync } from 'fs'

import packageJson from '../package.json'

export const csprojTemplate = (version: string, dotNetVersions: string[]) =>
  `
<Project Sdk="Microsoft.NET.Sdk">

<PropertyGroup>
  <TargetFrameworks>${dotNetVersions
    .map((v) => `net${v}`)
    .join(';')}</TargetFrameworks>
  <ImplicitUsings>enable</ImplicitUsings>
  <Nullable>annotations</Nullable>

  <PackageId>Seam</PackageId>

  <PackageVersion>${version}</PackageVersion>

  <Authors>Seam</Authors>

  <Owners>Seam</Owners>

  <PackageReadmeFile>README.md</PackageReadmeFile>

  <PackageProjectUrl>http://github.com/seamapi/seam-connect</PackageProjectUrl>

  <PackageIcon>icon.png</PackageIcon>

  <Description>Seam API for C#</Description>

  <Copyright>Copyright (c) 2021-2023 Seam Labs, Inc.</Copyright>

  <PackageTags>api iot</PackageTags>
</PropertyGroup>

<ItemGroup>
  <None Include="icon.png" Pack="true" PackagePath="icon.png" />
  <None Include="README.md" Pack="true" PackagePath="README.md" />

  <PackageReference Include="JsonSubTypes" Version="2.0.1" />
  <PackageReference Include="Newtonsoft.Json" Version="13.0.3" />
  <PackageReference Include="Polly" Version="7.2.4" />
  <PackageReference Include="RestSharp" Version="112.1.0" />
</ItemGroup>

</Project>

`.trim()

const main = async () => {
  writeFileSync(
    './output/csharp/src/Seam/Seam.csproj',
    csprojTemplate(packageJson.version, ['6.0', '7.0']),
  )
}

main()
