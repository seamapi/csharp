namespace Seam.Test;

using System.Net;
using Seam.Test.Support;

public class RetryTests
{
    private const string DevicesBody = "{\"devices\":[]}";

    private const string ActionAttemptBody = """
        {"action_attempt":{"action_type":"UNLOCK_DOOR","action_attempt_id":"attempt1","status":"pending"}}
        """;

    private static SeamClient CreateSeam(
        RecordingHandler handler,
        int? maxRetries = null,
        TimeSpan? timeout = null
    )
    {
        return new SeamClient(
            new SeamClientOptions
            {
                ApiKey = "seam_apikey1_token",
                Endpoint = "https://example.com",
                HttpMessageHandler = handler,
                MaxRetries = maxRetries,
                Timeout = timeout,
                WaitForActionAttempt = false,
            }
        );
    }

    private static Task UnlockDoorAsync(SeamClient seam)
    {
        return seam.Locks.UnlockDoorAsync(new() { DeviceId = "device1" });
    }

    [Fact]
    public async Task DoesNotRetryPostOnServiceUnavailable()
    {
        var handler = new RecordingHandler().RespondWith(
            HttpStatusCode.ServiceUnavailable,
            "unavailable",
            "text/plain"
        );
        using var seam = CreateSeam(handler);

        await Assert.ThrowsAsync<HttpRequestException>(() => UnlockDoorAsync(seam));

        Assert.Equal(1, handler.AttemptCount);
    }

    [Fact]
    public async Task DoesNotRetryPostOnConnectionFailure()
    {
        var handler = new RecordingHandler().FailWith(
            new HttpRequestException("Connection refused")
        );
        using var seam = CreateSeam(handler);

        await Assert.ThrowsAsync<HttpRequestException>(() => UnlockDoorAsync(seam));

        Assert.Equal(1, handler.AttemptCount);
    }

    [Fact]
    public async Task DoesNotRetryPostOnTimeout()
    {
        var handler = new RecordingHandler().RespondAfter(
            TimeSpan.FromSeconds(10),
            HttpStatusCode.OK,
            ActionAttemptBody
        );
        using var seam = CreateSeam(handler, timeout: TimeSpan.FromMilliseconds(200));

        await Assert.ThrowsAsync<TimeoutException>(() => UnlockDoorAsync(seam));

        Assert.Equal(1, handler.AttemptCount);
    }

    [Fact]
    public async Task RetriesIdempotentRequestsOnTimeout()
    {
        var handler = new RecordingHandler()
            .RespondAfter(TimeSpan.FromSeconds(10), HttpStatusCode.OK)
            .RespondWith(HttpStatusCode.OK, DevicesBody);
        using var seam = CreateSeam(handler, timeout: TimeSpan.FromMilliseconds(200));

        var devices = await seam.Devices.ListAsync();

        Assert.Empty(devices);
        Assert.Equal(2, handler.AttemptCount);
    }

    [Fact]
    public async Task RetriesIdempotentRequestsOnServiceUnavailable()
    {
        var handler = new RecordingHandler()
            .RespondWith(HttpStatusCode.ServiceUnavailable, "unavailable", "text/plain")
            .RespondWith(HttpStatusCode.OK, DevicesBody);
        using var seam = CreateSeam(handler);

        var devices = await seam.Devices.ListAsync();

        Assert.Empty(devices);
        Assert.Equal(2, handler.AttemptCount);
    }

    [Fact]
    public async Task RetriesIdempotentRequestsOnTooManyRequests()
    {
        var handler = new RecordingHandler()
            .RespondWith(
                HttpStatusCode.TooManyRequests,
                "slow down",
                "text/plain",
                new Dictionary<string, string> { ["Retry-After"] = "0" }
            )
            .RespondWith(HttpStatusCode.OK, DevicesBody);
        using var seam = CreateSeam(handler);

        var devices = await seam.Devices.ListAsync();

        Assert.Empty(devices);
        Assert.Equal(2, handler.AttemptCount);
    }

    [Fact]
    public async Task RetriesIdempotentRequestsOnConnectionFailure()
    {
        var handler = new RecordingHandler()
            .FailWith(new HttpRequestException("Connection reset"))
            .RespondWith(HttpStatusCode.OK, DevicesBody);
        using var seam = CreateSeam(handler);

        var devices = await seam.Devices.ListAsync();

        Assert.Empty(devices);
        Assert.Equal(2, handler.AttemptCount);
    }

    [Fact]
    public async Task StopsRetryingOnceRetriesAreExhausted()
    {
        var handler = new RecordingHandler().RespondWith(
            HttpStatusCode.ServiceUnavailable,
            "unavailable",
            "text/plain"
        );
        using var seam = CreateSeam(handler);

        var exception = await Assert.ThrowsAsync<HttpRequestException>(
            () => seam.Devices.ListAsync()
        );

        Assert.Equal(HttpStatusCode.ServiceUnavailable, exception.StatusCode);
        Assert.Equal(3, handler.AttemptCount);
    }

    [Fact]
    public async Task DoesNotRetryWhenRetriesAreDisabled()
    {
        var handler = new RecordingHandler().RespondWith(
            HttpStatusCode.ServiceUnavailable,
            "unavailable",
            "text/plain"
        );
        using var seam = CreateSeam(handler, maxRetries: 0);

        await Assert.ThrowsAsync<HttpRequestException>(() => seam.Devices.ListAsync());

        Assert.Equal(1, handler.AttemptCount);
    }
}
