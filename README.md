# Seam C#

[![GitHub Actions](https://github.com/seamapi/csharp/actions/workflows/check.yml/badge.svg)](https://github.com/seamapi/csharp/actions/workflows/check.yml)

SDK for the Seam API written in C#.

## Installation

Use [NuGet](https://www.nuget.org/packages/Seam) to install.

## Usage

```csharp
using Seam.Client;

var seam = new SeamClient(apiToken: "YOUR_API_KEY");

var myDevices = seam.Devices.List();

Console.WriteLine("First Device Name: " + myDevices[0].Properties.Name);

var accessCode = seam.AccessCodes.Create(deviceId: myDevices[0].DeviceId, code: "1234");
```

## Development and Testing

### Quickstart

Install the [.NET SDK](https://dotnet.microsoft.com/download) 8.0 or later
and [Node.js](https://nodejs.org/), then run

```
$ git clone git@github.com:seamapi/csharp.git
$ cd csharp
$ npm install
$ dotnet tool restore
```

Primary development tasks are defined as npm scripts in `package.json`
and available via `npm run`.
View them with

```
$ npm run
```

| Task              | Command                                      |
| ----------------- | -------------------------------------------- |
| Run the tests     | `npm test`                                   |
| Lint              | `npm run lint:csharp` and `npm run lint`     |
| Format            | `npm run format:csharp` and `npm run format` |
| Build the package | `npm run build`                              |
| Generate the SDK  | `npm run generate`                           |

C# sources are formatted by [CSharpier](https://csharpier.com/),
pinned as a local dotnet tool in `.config/dotnet-tools.json`.
TypeScript, JSON, YAML and Markdown are formatted by
[Prettier](https://prettier.io/) via `npm run format`.

Run the full suite with

```
$ npm test
```

To run the tests for a single target framework, pass it as an argument

```
$ npm test -- --framework net8.0
```

### Requirements

The package targets .NET 6.0 and .NET 8.0.
Continuous integration exercises both target frameworks.

### Publishing

#### Automatic

New versions are released automatically from `main` by the
[Semantic Release](.github/workflows/semantic-release.yml) workflow,
which reads [Conventional Commits](https://www.conventionalcommits.org/)
and dispatches the [Version](.github/workflows/version.yml) workflow.

#### Manual

Run the [Version](.github/workflows/version.yml) workflow with the
version to cut.
It runs `npm version`, which bumps the `version` field in `package.json`,
regenerates `Seam.csproj` with that version, creates a signed `v*` git tag
and pushes it.
Pushing the tag triggers the [Publish](.github/workflows/publish.yml)
workflow, which packs the library with `dotnet pack` and pushes the
package to [NuGet](https://www.nuget.org/packages/Seam) and GitHub
Packages.

> The version lives in `package.json`, the development manifest that
> drives the codegen, and is injected into `Seam.csproj` by
> `src/generate-csproj.ts`.
> The injection runs from `src/version.ts`, wired to the `version`
> lifecycle script, which npm runs after the bump but before the commit,
> so the updated project file is part of the tagged commit and MSBuild
> surfaces the version at runtime through
> `AssemblyInformationalVersionAttribute`.
> Never edit the version in `Seam.csproj` by hand.

## License

This C# SDK is licensed under the [MIT license](LICENSE.txt).
