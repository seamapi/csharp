namespace Seam.Test;

using System.Net;
using Seam.Test.Support;

public class TimeoutTests
{
    private static SeamClient CreateSeam(RecordingHandler handler, TimeSpan? timeout = null)
    {
        return new SeamClient(
            new SeamClientOptions
            {
                ApiKey = "seam_apikey1_token",
                Endpoint = "https://example.com",
                HttpMessageHandler = handler,
                Timeout = timeout,
                MaxRetries = 0,
            }
        );
    }

    [Fact]
    public async Task ATimedOutAttemptThrowsATimeoutException()
    {
        var handler = new RecordingHandler().RespondAfter(
            TimeSpan.FromSeconds(10),
            HttpStatusCode.OK
        );
        using var seam = CreateSeam(handler, timeout: TimeSpan.FromMilliseconds(200));

        await Assert.ThrowsAsync<TimeoutException>(() => seam.Devices.ListAsync());
    }

    [Fact]
    public async Task ASlowResponseWithinTheTimeoutSucceeds()
    {
        var handler = new RecordingHandler().RespondAfter(
            TimeSpan.FromMilliseconds(100),
            HttpStatusCode.OK,
            "{\"devices\":[]}"
        );
        using var seam = CreateSeam(handler, timeout: TimeSpan.FromSeconds(10));

        Assert.Empty(await seam.Devices.ListAsync());
    }

    // Cancelling the caller's token is the caller's intent, not a timeout, so it surfaces as an
    // OperationCanceledException rather than the SDK's TimeoutException.
    [Fact]
    public async Task CallerCancellationIsNotATimeout()
    {
        var handler = new RecordingHandler().RespondAfter(
            TimeSpan.FromSeconds(10),
            HttpStatusCode.OK
        );
        using var seam = CreateSeam(handler, timeout: TimeSpan.FromSeconds(30));
        using var cancellation = new CancellationTokenSource(TimeSpan.FromMilliseconds(100));

        var exception = await Assert.ThrowsAnyAsync<OperationCanceledException>(
            () => seam.Devices.ListAsync(null, cancellation.Token)
        );

        Assert.IsNotType<TimeoutException>(exception);
    }
}
