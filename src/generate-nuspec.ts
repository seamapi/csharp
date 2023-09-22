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

    <!-- Identifier that must be unique within the hosting gallery -->
    <id>Seam</id>

    <!-- Package version number that is used when resolving dependencies -->
    <version>0.0.1</version>

    <!-- Authors contain text that appears directly on the gallery -->
    <authors>Seam</authors>

    <!--
        Owners are typically nuget.org identities that allow gallery
        users to easily find other packages by the same owners.
    -->
    <owners>Seam</owners>

     <!-- Project URL provides a link for the gallery -->
    <projectUrl>http://github.com/seamapi/seam-connect</projectUrl>

     <!-- License information is displayed on the gallery -->
    <license type="expression">Copyright (c) 2021-2023 Seam Labs, Inc.</license>


    <!-- Icon is used in Visual Studio's package manager UI -->
    <icon>icon.png</icon>

    <!--
        If true, this value prompts the user to accept the license when
        installing the package.
    -->
    <requireLicenseAcceptance>true</requireLicenseAcceptance>

    <!--
        The description can be used in package manager UI. Note that the
        nuget.org gallery uses information you add in the portal.
    -->
    <description>Seam API for C#</description>

    <!-- Copyright information -->
    <copyright>Copyright (c) 2021-2023 Seam Labs, Inc.</copyright>

    <!-- Tags appear in the gallery and can be used for tag searches -->
    <tags>api iot</tags>
  </PropertyGroup>

  <ItemGroup>
    <PackageReference Include="JsonSubTypes" Version="2.0.1" />
    <PackageReference Include="Newtonsoft.Json" Version="13.0.3" />
    <PackageReference Include="Polly" Version="7.2.4" />
    <PackageReference Include="RestSharp" Version="110.2.0" />
  </ItemGroup>

</Project>

`.trim()

const nuspecData = xml(packageJson.version)

writeFileSync(
  path.join(process.cwd(), 'output/csharp/src/Co.Seam/Co.Seam.csproj'),
  nuspecData,
)
