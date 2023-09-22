import path from 'path'
import { writeFileSync } from 'fs'
import packageJson from '../package.json'

const xml = (version: string) =>
  `
<Project Sdk="Microsoft.NET.Sdk">

  <PropertyGroup>
    <TargetFramework>net7.0</TargetFramework>
    <ImplicitUsings>enable</ImplicitUsings>
    <Nullable>annotations</Nullable>

    <PackageId>Seam</PackageId>

    <PackageVersion>${version}</PackageVersion>

    <Authors>Seam</Authors>

    <Owners>Seam</Owners>

    <PackageProjectUrl>http://github.com/seamapi/seam-connect</PackageProjectUrl>

    <PackageIcon>icon.png</PackageIcon>

    <Description>Seam API for C#</Description>

    <Copyright>Copyright (c) 2021-2023 Seam Labs, Inc.</Copyright>

    <PackageTags>api iot</PackageTags>
  </PropertyGroup>

  <ItemGroup>
    <None Include="icon.png" Pack="true" PackagePath="icon.png" />

    <PackageReference Include="JsonSubTypes" Version="2.0.1" />
    <PackageReference Include="Newtonsoft.Json" Version="13.0.3" />
    <PackageReference Include="Polly" Version="7.2.4" />
    <PackageReference Include="RestSharp" Version="110.2.0" />
  </ItemGroup>

</Project>

`.trim()

const nuspecData = xml(packageJson.version)

writeFileSync(
  path.join(process.cwd(), 'output/csharp/src/Seam/Seam.csproj'),
  nuspecData,
)
