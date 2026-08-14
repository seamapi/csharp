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

### Setting a value to null

The Seam API distinguishes three states for an updatable parameter:
omitted (leave the stored value unchanged), null (unset the stored value),
and a value (set it).

C#'s `null` means omitted.
The SDK removes `null` parameters from the request entirely,
so passing `null` never unsets a value.
To unset a value, pass the `Null.Value` sentinel,
which the SDK sends as JSON `null` in request bodies
and as an empty value in query strings:

```csharp
// Omits custom_metadata, leaving the stored metadata unchanged.
seam.Devices.Update(deviceId: deviceId, customMetadata: null);

// Unsets the sync key of the stored metadata.
seam.Devices.Update(
    deviceId: deviceId,
    customMetadata: new Dictionary<string, object> { ["sync"] = Null.Value }
);
```

Only pass `Null.Value` where the Seam API documents a value as nullable.
A parameter typed as a specific C# type, e.g. `string?`, does not accept the
sentinel: pass it wherever a parameter is typed `object`, and to the URL search
params serializer below.

## Advanced Usage

### Setting the request timeout

Requests time out after 30 seconds by default.
Pass the `timeout` option, in milliseconds, to override this:

```csharp
var seam = new SeamClient(apiToken: "YOUR_API_KEY", timeout: 60000);
```

The default may also be changed for every client at once:

```csharp
GlobalSeamRequestConfiguration.Instance.Timeout = 60000;
```

### Serializing URL search params

The Seam API parses URL search params as complex types.
The SDK serializes the params of every endpoint
the Seam API prefers to receive as a GET or DELETE this way.
If you call the API with your own HTTP client,
`StrictUrlSearchParamsSerializer` is exported for that purpose.
The `_strict=true` parameter is added to any non-empty query
so the Seam API uses strict, schema-aware parsing.
A query with no serializable parameters remains empty.

```csharp
using Seam.Client;

var query = StrictUrlSearchParamsSerializer.Serialize(
    new Dictionary<string, object> { ["device_ids"] = new[] { "device1", "device2" } }
);

using var client = new HttpClient();
client.DefaultRequestHeaders.Add("Authorization", "Bearer your-api-key");

var devices = await client.GetStringAsync($"https://connect.getseam.com/devices/list?{query}");
```

The serialization defines the name and value of each search param,
where every value is a string.
`UrlSearchParams` holds those pairs and renders the query string,
as [URLSearchParams] does for the [reference implementation]:

```csharp
using Seam.Client;

var searchParams = new UrlSearchParams();

StrictUrlSearchParamsSerializer.Update(
    searchParams,
    new Dictionary<string, object> { ["device_ids"] = new[] { "device1", "device2" } }
);

searchParams.Select(pair => (pair.Key, pair.Value)).ToList();
// => [("device_ids", "device1"), ("device_ids", "device2"), ("_strict", "true")]

searchParams.ToString();
// => "device_ids=device1&device_ids=device2&_strict=true"
```

Pass either the query string or the pairs to your HTTP client.
A client may percent-encode a few characters differently
than `URLSearchParams` does,
which the Seam API reads as the same params either way.

A parameter set to `null` is omitted,
while a parameter set to `Null.Value` is serialized to an empty value,
which the Seam API reads as null,
as described in [Setting a value to null](#setting-a-value-to-null).
A parameter that cannot be represented throws an `UnserializableParamError`.

The Seam API parses these params with the corresponding [parser].

[URLSearchParams]: https://developer.mozilla.org/en-US/docs/Web/API/URLSearchParams
[reference implementation]: https://github.com/seamapi/url-search-params-serializer
[parser]: https://github.com/seamapi/url-search-params-parser

## Development and Testing

### Quickstart

Install the [.NET SDK](https://dotnet.microsoft.com/download) 10.0 or later,
[just](https://just.systems/) and [Node.js](https://nodejs.org/), then run

```
$ git clone git@github.com:seamapi/csharp.git
$ cd csharp
$ npm install
$ dotnet tool restore
```

Primary development tasks are defined in the `justfile`
and available via `just`.
View them with

```
$ just --list
```

| Task              | Command            |
| ----------------- | ------------------ |
| Run the tests     | `just test`        |
| Lint              | `just lint`        |
| Format            | `just format`      |
| Build the package | `just build`       |
| Generate the SDK  | `npm run generate` |

The npm scripts only drive the codegen layer: `npm run generate`
regenerates the SDK, and `npm run lint` and `npm run format` cover the
TypeScript, JSON, YAML and Markdown sources with ESLint and
[Prettier](https://prettier.io/).
C# sources are formatted by [CSharpier](https://csharpier.com/),
pinned as a local dotnet tool in `.config/dotnet-tools.json`.

Run the full suite with

```
$ just test
```

To run the tests for a single target framework, pass it as an argument

```
$ just test net8.0
```

### Requirements

The package targets .NET 8.0 and .NET 10.0, the supported LTS releases.
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
