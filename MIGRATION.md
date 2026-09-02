# Migration Guide

## v1 to v2

Version 2 rebuilds the SDK on the architecture shared by the Seam SDKs for
other languages. The runtime dependencies (RestSharp, Newtonsoft.Json,
JsonSubTypes, Polly) are gone, the public surface is aligned with the other
SDKs, and the strict typing is stronger throughout.

| Change                                                                                                                  | Affects you if...                                                 |
| ----------------------------------------------------------------------------------------------------------------------- | ----------------------------------------------------------------- |
| [`SeamClient` construction changed](#seamclient-construction-changed)                                                   | You construct a client anywhere.                                  |
| [Endpoint methods are async-only and take a request object](#endpoint-methods-are-async-only-and-take-a-request-object) | You call any endpoint.                                            |
| [Route namespaces are nested](#route-namespaces-are-nested)                                                             | You call a nested route, e.g. `seam.UsersAcs`.                    |
| [Action attempts are waited for by default](#action-attempts-are-waited-for-by-default)                                 | You call an endpoint returning an action attempt.                 |
| [Errors raise a typed exception hierarchy](#errors-raise-a-typed-exception-hierarchy)                                   | You catch `SeamException`.                                        |
| [Requests are retried, and time out per attempt](#requests-are-retried-and-time-out-per-attempt)                        | You rely on requests never retrying, or on global timeout config. |
| [Required parameters fail at compile time](#required-parameters-fail-at-compile-time)                                   | You omit required parameters.                                     |
| [Nullable parameters use `Optional<T>`](#nullable-parameters-use-optionalt)                                             | You pass `Null.Value` or unset values.                            |
| [Global configuration is removed](#global-configuration-is-removed)                                                     | You use `GlobalSeamRequestConfiguration` or `RetryConfiguration`. |
| [Generated code moved and unknown values are preserved](#generated-code-moved-and-unknown-values-are-preserved)         | You reference `Seam.Api` or `Seam.Model` types directly.          |

v2 also adds features that require no migration; see
[New in v2](#new-in-v2) at the end.

### `SeamClient` construction changed

The v1 constructors took a positional `basePath` and an `apiToken`, and the
obsolete `Seam.Client.Seam` alias is removed. The client now lives in the
`Seam` namespace (not `Seam.Client`) and is constructed with an options
object or static factories:

```csharp
// v1
using Seam.Client;
var seam = new SeamClient(basePath: "https://connect.getseam.com", apiToken: "YOUR_API_KEY");

// v2
using Seam;
var seam = new SeamClient(apiKey: "YOUR_API_KEY");
// or
var seam = new SeamClient(new SeamClientOptions
{
    ApiKey = "YOUR_API_KEY",
    Endpoint = "https://connect.getseam.com",
});
```

The timeout is a `TimeSpan` option rather than an `int?` of milliseconds.

### Endpoint methods are async-only and take a request object

The four overloads per endpoint (sync and async, request-object and expanded
parameters) are replaced by one async method taking a request object and a
`CancellationToken`. Method names carry the `Async` suffix.

```csharp
// v1
var device = seam.Devices.Get(deviceId: "abc");
var device = await seam.Devices.GetAsync(deviceId: "abc");

// v2
var device = await seam.Devices.GetAsync(new() { DeviceId = "abc" });
```

Positional arguments are no longer possible: request objects are constructed
with named properties, so adding or reordering API parameters is never a
source-breaking change. Callers that must block can use
`.GetAwaiter().GetResult()`, at the usual risk of sync-over-async.

### Route namespaces are nested

Route classes were named by reversing the API path, producing flat names like
`seam.UsersAcs` and `seam.SimulateEncodersAcs`. They now nest the way the API
paths (and the other SDKs) do:

| v1                                 | v2                                  |
| ---------------------------------- | ----------------------------------- |
| `seam.UsersAcs`                    | `seam.Acs.Users`                    |
| `seam.SystemsAcs`                  | `seam.Acs.Systems`                  |
| `seam.SimulateEncodersAcs`         | `seam.Acs.Encoders.Simulate`        |
| `seam.UnmanagedDevices`            | `seam.Devices.Unmanaged`            |
| `seam.SchedulesThermostats`        | `seam.Thermostats.Schedules`        |
| `seam.NoiseThresholdsNoiseSensors` | `seam.NoiseSensors.NoiseThresholds` |

### Action attempts are waited for by default

Endpoints returning an action attempt no longer hand back a pending attempt:
the SDK polls until the attempt succeeds (10 second timeout, 1 second polling
interval), raising `SeamActionAttemptFailedException` when it fails and
`SeamActionAttemptTimeoutException` when the timeout elapses. `ActionAttempt`
now exposes `Status`, `Error`, and `ActionAttemptId` on the base class, so no
downcasting is needed to check the outcome.

```csharp
// v2: returns the finished attempt, or throws.
var actionAttempt = await seam.Locks.UnlockDoorAsync(new() { DeviceId = deviceId });

// v1 behavior (return the pending attempt immediately):
var seam = new SeamClient(new SeamClientOptions { ApiKey = "...", WaitForActionAttempt = false });
// or per call:
await seam.Locks.UnlockDoorAsync(new() { DeviceId = deviceId }, waitForActionAttempt: false);
```

### Errors raise a typed exception hierarchy

The single `SeamException` carrying a raw response body is replaced by a
hierarchy rooted at an abstract `SeamException`:

- `SeamHttpApiException` — any Seam API error, with `Code` (the Seam error
  type), `StatusCode`, `RequestId` (the `seam-request-id` header), and `Data`.
  - `SeamHttpUnauthorizedException` — 401.
  - `SeamHttpInvalidInputException` — adds `GetValidationErrorMessages(paramName)`.
- `SeamActionAttemptFailedException` / `SeamActionAttemptTimeoutException` —
  carry the `ActionAttempt`.
- `SeamInvalidOptionsException` / `SeamInvalidTokenException` — invalid client
  construction.
- `SeamInvalidWebhookPayloadException` — a webhook payload that passed
  signature verification but is not a readable Seam event. A failed signature
  still raises Svix's `WebhookVerificationException`.

A response that is not a Seam error envelope (e.g. HTML from a gateway) now
raises the standard `HttpRequestException` instead of a fabricated Seam error.

### Requests are retried, and time out per attempt

v1 never retried by default. v2 retries idempotent requests (GET, HEAD,
OPTIONS, PUT, DELETE) twice on transport errors, timeouts, 429, and 5xx, with
exponential backoff and jitter, honoring `Retry-After`. POST and PATCH are
never retried. Since reads are sent as GET, they are now retryable. The
30 second timeout applies to each attempt and raises `TimeoutException`;
cancelling your own `CancellationToken` raises `OperationCanceledException`.
Configure with `MaxRetries` and `Timeout` on `SeamClientOptions`.

### Required parameters fail at compile time

In v1, every request parameter defaulted to `null`, so a missing required
parameter failed on the server. In v2, required parameters are C# `required`
members, so omitting one is a compile error. Endpoints that require at least
one of several parameters (e.g. `/devices/get`) throw `ArgumentException`
locally before any request is sent.

### Nullable parameters use `Optional<T>`

Where the Seam API documents a parameter as nullable, the request property is
an `Optional<T>` distinguishing unset (omitted), an explicit `Null.Value`
(sent as JSON null, unsetting the stored value), and a value. Plain optional
parameters remain nullable C# types where `null` means omitted. `Null.Value`
still works inside dictionaries such as `CustomMetadata`.

### Global configuration is removed

`GlobalSeamRequestConfiguration`, `RetryConfiguration`, and the other
openapi-generator-era types (`ApiResponse`, `Multimap`, `ClientUtils`,
`RequestOptions`, `ISynchronousSeam`, `IAsynchronousSeam`) are gone. All
configuration is per client via `SeamClientOptions`, and the configured
`HttpClient` is exposed as `seam.Client`.

### Generated code moved and unknown values are preserved

Generated types moved from `Seam.Api`/`Seam.Model` to
`Seam.Routes`/`Seam.Models` and are records with init-only properties.
Enums keep the `Unrecognized` fallback member for unknown API values. Unknown
union variants (`ActionAttemptUnrecognized`, `EventUnrecognized`, ...) now
preserve the complete raw payload in their `RawJson` property instead of
discarding it.

### Checklist

1. Update `using Seam.Client;` to `using Seam;` and construct `SeamClient`
   with `apiKey:` or `SeamClientOptions`.
2. Replace sync calls with `await`ed `...Async` calls, and expanded-parameter
   calls with request objects: `GetAsync(new() { DeviceId = ... })`.
3. Update nested route names, e.g. `seam.UsersAcs` to `seam.Acs.Users`.
4. Decide how each action-attempt call should wait; pass
   `waitForActionAttempt: false` to keep v1 behavior.
5. Update `catch (SeamException)` blocks to the new exception types, and
   catch `HttpRequestException` for non-Seam transport errors.
6. Replace `GlobalSeamRequestConfiguration`/`RetryConfiguration` usage with
   `SeamClientOptions`.
7. Update references to `Seam.Model` types to `Seam.Models`.
8. Recompile: the compiler will point out every remaining call site.

### New in v2

Nothing here requires migration, but v2 also adds:

- **Personal access token authentication.** Authenticate as a Seam Console
  user scoped to a workspace, and use `SeamWithoutWorkspaceClient` to list and
  create workspaces before having one in scope:

  ```csharp
  var seam = SeamClient.FromPersonalAccessToken("YOUR_PAT", "YOUR_WORKSPACE_ID");

  var console = new SeamWithoutWorkspaceClient(personalAccessToken: "YOUR_PAT");
  var workspaces = await console.Workspaces.ListAsync();
  ```

- **Environment-based configuration.** With no options, the client reads
  `SEAM_API_KEY` or `SEAM_PERSONAL_ACCESS_TOKEN` plus `SEAM_WORKSPACE_ID`, and
  the endpoint from `SEAM_ENDPOINT`: `var seam = new SeamClient();`

- **Token format validation.** Passing the wrong kind of token (a client
  session token as an API key, an API key as a personal access token, ...)
  raises a specific `SeamInvalidTokenException` at construction instead of an
  opaque 401 from the server.

- **Pagination.** Paginated endpoints offer a `ListPager` returning a
  `SeamPaginator` with `FirstPageAsync`/`NextPageAsync`, `FlattenToListAsync`,
  and lazy `IAsyncEnumerable` iteration:

  ```csharp
  await foreach (var device in seam.Devices.ListPager(new() { Limit = 20 }).Flatten())
      Console.WriteLine(device.DeviceId);
  ```

- **Cancellation.** Every endpoint method takes a `CancellationToken`,
  threaded through retries, timeouts, and action attempt polling.

- **Automatic retries.** Idempotent requests retry transient failures with
  exponential backoff (see
  [the retry section](#requests-are-retried-and-time-out-per-attempt)).

- **Webhook verification.** `SeamWebhook` verifies an incoming webhook
  signature and parses the payload into the typed `Event` union:

  ```csharp
  var seamEvent = new SeamWebhook(secret).Verify(requestBody, requestHeaders);
  ```

- **SDK identification headers.** Every request carries `seam-sdk-name` and
  `seam-sdk-version`, so Seam support can identify the SDK from the
  `seam-request-id` of a failing request.
