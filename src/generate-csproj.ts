import { readFileSync, writeFileSync } from 'node:fs'

const { version } = JSON.parse(
  readFileSync(new URL('../package.json', import.meta.url), 'utf-8'),
)

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

  <Version>${version}</Version>

  <Authors>Seam Labs, Inc.</Authors>

  <Owners>Seam</Owners>

  <Description>SDK for the Seam API written in C#.</Description>

  <Copyright>Copyright (c) 2021-2026 Seam Labs, Inc.</Copyright>

  <PackageTags>seam;api;iot</PackageTags>

  <PackageLicenseExpression>MIT</PackageLicenseExpression>

  <PackageReadmeFile>README.md</PackageReadmeFile>

  <PackageIcon>icon.png</PackageIcon>

  <PackageProjectUrl>https://github.com/seamapi/csharp</PackageProjectUrl>

  <RepositoryUrl>https://github.com/seamapi/csharp</RepositoryUrl>

  <RepositoryType>git</RepositoryType>

  <GenerateDocumentationFile>true</GenerateDocumentationFile>

  <NoWarn>$(NoWarn);CS1591</NoWarn>
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
    csprojTemplate(version, ['6.0', '8.0']),
  )
}

main()
