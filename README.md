# Seam C#

[![GitHub Actions](https://github.com/seamapi/csharp/actions/workflows/check.yml/badge.svg)](https://github.com/seamapi/csharp/actions/workflows/check.yml)

SDK for the Seam API written in C#.

Upgrading from v1? See [MIGRATION.md](./MIGRATION.md).

## Installation

Use [NuGet](https://www.nuget.org/packages/Seam) to install.

```
dotnet add package Seam
```

## Usage

```csharp
using Seam;

var seam = new SeamClient(apiKey: "YOUR_API_KEY");

var devices = await seam.Devices.ListAsync();

Console.WriteLine($"First device: {devices[0].DisplayName}");

var device = await seam.Locks.GetAsync(new() { DeviceId = devices[0].DeviceId });
```

Endpoint methods are async, take a single request object, and accept a
`CancellationToken`. Required parameters are `required` members of the request
object, so a missing one is a compile error rather than a server round trip.
Request objects are always constructed with named properties (typically via a
target-typed `new()`), so adding or reordering API parameters never breaks
your code.

### Authentication

Authenticate with an API key, which is scoped to a single workspace:

```csharp
var seam = new SeamClient(apiKey: "YOUR_API_KEY");
// or
var seam = SeamClient.FromApiKey("YOUR_API_KEY");
```

Or with a personal access token and the workspace it acts on:

```csharp
var seam = SeamClient.FromPersonalAccessToken("YOUR_PAT", "YOUR_WORKSPACE_ID");
```

When no credential is passed, the client reads `SEAM_API_KEY` or
`SEAM_PERSONAL_ACCESS_TOKEN` plus `SEAM_WORKSPACE_ID` from the environment,
and the endpoint falls back to `SEAM_ENDPOINT`:

```csharp
var seam = new SeamClient();
```

To list and create workspaces before having one in scope, use the
workspace-less client:

```csharp
var seam = new SeamWithoutWorkspaceClient(personalAccessToken: "YOUR_PAT");
var workspaces = await seam.Workspaces.ListAsync();
```

### Action attempts

Some endpoints, e.g. unlocking a door, return an action attempt tracking the
requested action. By default, the SDK polls the action attempt until it
succeeds and returns the finished attempt, raising
`SeamActionAttemptFailedException` when it fails and
`SeamActionAttemptTimeoutException` when it is still pending after 10 seconds:

```csharp
var actionAttempt = await seam.Locks.UnlockDoorAsync(new() { DeviceId = deviceId });
```

Configure or disable waiting per client or per call with `ActionAttemptWait`:

```csharp
// Do not wait: get the pending action attempt back immediately.
var seam = new SeamClient(new SeamClientOptions
{
    ApiKey = "YOUR_API_KEY",
    WaitForActionAttempt = false,
});

// Wait longer for this one call.
var actionAttempt = await seam.Locks.UnlockDoorAsync(
    new() { DeviceId = deviceId },
    waitForActionAttempt: new ActionAttemptWait
    {
        Timeout = TimeSpan.FromSeconds(30),
        PollingInterval = TimeSpan.FromSeconds(2),
    }
);
```

### Pagination

Every paginated list endpoint offers a `ListPager` returning a
`SeamPaginator`:

```csharp
var pages = seam.Devices.ListPager(new() { Limit = 20 });

// Iterate every item lazily.
await foreach (var device in pages.Flatten())
{
    Console.WriteLine(device.DeviceId);
}

// Or fetch pages by hand.
var (devices, pagination) = await pages.FirstPageAsync();
if (pagination.HasNextPage)
{
    var (moreDevices, _) = await pages.NextPageAsync(pagination.NextPageCursor!);
}

// Or collect everything into one list.
var allDevices = await pages.FlattenToListAsync();
```

To resume pagination later, store `pagination.NextPageCursor` and pass it to
`NextPageAsync` on a new pager with the same request parameters.

### Error Handling

Seam API errors raise a typed exception carrying the Seam error code, HTTP
status code, and the `seam-request-id` to include in support requests.

#### Validation errors

When the API rejects a request because a parameter is invalid, it throws a
`SeamHttpInvalidInputException`. Look up messages for a parameter you are
already rendering, for example a field in a form:

```csharp
try
{
    await seam.Devices.ListAsync(new() { DeviceIds = ["not-a-uuid"] });
}
catch (SeamHttpInvalidInputException exception)
{
    foreach (var message in exception.GetValidationErrorMessages("device_ids"))
        Console.WriteLine(message);
}
```

Or read every parameter that failed validation to summarize the request:

```csharp
foreach (var validationError in exception.ValidationErrors)
{
    Console.WriteLine(
        $"{validationError.ParameterName}: {string.Join(", ", validationError.ErrorMessages)}"
    );
}
```

Every SDK exception derives from `SeamException`. A response that is not a
Seam error, e.g. from a gateway, surfaces as the standard
`HttpRequestException`.

### Retries and timeouts

Idempotent requests are retried twice on transport errors, timeouts, 429, and
5xx responses with exponential backoff, honoring `Retry-After`. POST and PATCH
requests are never retried, so a retry can never duplicate a write. Each
attempt times out after 30 seconds. Both are configurable:

```csharp
var seam = new SeamClient(new SeamClientOptions
{
    ApiKey = "YOUR_API_KEY",
    MaxRetries = 0,
    Timeout = TimeSpan.FromSeconds(60),
});
```

### Setting a value to null

The Seam API distinguishes three states for an updatable parameter: omitted
(leave the stored value unchanged), null (unset the stored value), and a value
(set it). C#'s `null` means omitted; the SDK removes `null` parameters from
the request entirely. Where the Seam API documents a parameter as nullable,
the request property is an `Optional<T>` that also accepts the explicit
`Null.Value` sentinel:

```csharp
// Omits every optional parameter, leaving stored values unchanged.
await seam.Thermostats.UpdateAsync(new() { DeviceId = deviceId });

// Unsets the sync key of the stored custom metadata.
await seam.Devices.UpdateAsync(new()
{
    DeviceId = deviceId,
    CustomMetadata = new Dictionary<string, object?> { ["sync"] = Null.Value },
});
```

### Webhooks

Verify and parse incoming Seam webhook events with `SeamWebhook`:

```csharp
var webhook = new SeamWebhook(Environment.GetEnvironmentVariable("SEAM_WEBHOOK_SECRET")!);

var seamEvent = webhook.Verify(requestBody, requestHeaders);

if (seamEvent is Seam.Models.EventDeviceConnected connected)
    Console.WriteLine(connected.DeviceId);
```

## Advanced usage

### Calling the API directly

The `HttpClient` the SDK sends requests with is exposed as `seam.Client`,
fully configured with the endpoint, authorization, retries, and timeouts:

```csharp
var response = await seam.Client.GetAsync("/devices/list");
```

To supply your own fully configured client instead, use
`SeamClient.FromHttpClient`, or pass an `HttpMessageHandler` to replace only
the innermost transport while keeping the SDK's pipeline:

```csharp
var seam = new SeamClient(new SeamClientOptions
{
    ApiKey = "YOUR_API_KEY",
    HttpMessageHandler = myHandler,
});
```

### Serializing URL search params

The Seam API parses URL search params as complex types. The SDK serializes
the params of every endpoint the Seam API prefers to receive as a GET or
DELETE this way. If you call the API with your own HTTP client,
`StrictUrlSearchParamsSerializer` is exported for that purpose. The
`_strict=true` parameter is added to any non-empty query so the Seam API uses
strict, schema-aware parsing.

```csharp
var query = StrictUrlSearchParamsSerializer.Serialize(
    new Dictionary<string, object?> { ["device_ids"] = new[] { "a", "b" } }
);
```

## Development and testing

Quickly run all tests with

```
just test
```

The tests run against [@seamapi/fake-seam-connect](https://github.com/seamapi/fake-seam-connect);
run `npm install` first. Generated code under `src/Seam/Routes` and
`src/Seam/Models` is produced by `npm run generate` from
[@seamapi/types](https://github.com/seamapi/types) and must not be edited by
hand.
