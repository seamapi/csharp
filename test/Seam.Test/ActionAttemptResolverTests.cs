namespace Seam.Test;

using System.Diagnostics;
using System.Net;
using Seam.Test.Support;

public class ActionAttemptResolverTests
{
    private const string PendingBody = """
        {"action_attempt":{"action_type":"UNLOCK_DOOR","action_attempt_id":"attempt1","status":"pending"}}
        """;

    private const string SuccessBody = """
        {"action_attempt":{"action_type":"UNLOCK_DOOR","action_attempt_id":"attempt1","status":"success","result":{}}}
        """;

    private static SeamClient CreateSeam(RecordingHandler handler)
    {
        return new SeamClient(
            new SeamClientOptions
            {
                ApiKey = "seam_apikey1_token",
                Endpoint = "https://example.com",
                HttpMessageHandler = handler,
                MaxRetries = 0,
            }
        );
    }

    private static Task<Models.ActionAttempt> UnlockDoorAsync(
        SeamClient seam,
        ActionAttemptWait wait
    )
    {
        return seam.Locks.UnlockDoorAsync(
            new() { DeviceId = "device1" },
            waitForActionAttempt: wait
        );
    }

    [Fact]
    public async Task PollsOnceWhenTheIntervalExceedsTheTimeout()
    {
        var handler = new RecordingHandler().RespondWith(HttpStatusCode.OK, PendingBody);
        using var seam = CreateSeam(handler);
        var elapsed = Stopwatch.StartNew();

        var exception = await Assert.ThrowsAsync<SeamActionAttemptTimeoutException>(
            () =>
                UnlockDoorAsync(
                    seam,
                    new ActionAttemptWait
                    {
                        Timeout = TimeSpan.FromMilliseconds(200),
                        PollingInterval = TimeSpan.FromSeconds(30),
                    }
                )
        );

        Assert.Equal(2, handler.AttemptCount);
        Assert.True(elapsed.Elapsed < TimeSpan.FromSeconds(10));
        Assert.Equal("Timed out waiting for action attempt after 0.2s", exception.Message);
        Assert.Equal("attempt1", exception.ActionAttempt.ActionAttemptId);
    }

    [Fact]
    public async Task TimesOutWithoutPollingWhenTheTimeoutIsZero()
    {
        var handler = new RecordingHandler().RespondWith(HttpStatusCode.OK, PendingBody);
        using var seam = CreateSeam(handler);

        await Assert.ThrowsAsync<SeamActionAttemptTimeoutException>(
            () => UnlockDoorAsync(seam, new ActionAttemptWait { Timeout = TimeSpan.Zero })
        );

        Assert.Equal(1, handler.AttemptCount);
    }

    [Fact]
    public async Task KeepsPollingUntilTheDeadline()
    {
        var handler = new RecordingHandler().RespondWith(HttpStatusCode.OK, PendingBody);
        using var seam = CreateSeam(handler);

        await Assert.ThrowsAsync<SeamActionAttemptTimeoutException>(
            () =>
                UnlockDoorAsync(
                    seam,
                    new ActionAttemptWait
                    {
                        Timeout = TimeSpan.FromMilliseconds(500),
                        PollingInterval = TimeSpan.FromMilliseconds(100),
                    }
                )
        );

        Assert.InRange(handler.AttemptCount, 3, 7);
    }

    [Fact]
    public async Task PollsThroughTheActionAttemptsGetQuery()
    {
        var handler = new RecordingHandler()
            .RespondWith(HttpStatusCode.OK, PendingBody)
            .RespondWith(HttpStatusCode.OK, SuccessBody);
        using var seam = CreateSeam(handler);

        var actionAttempt = await UnlockDoorAsync(
            seam,
            new ActionAttemptWait { PollingInterval = TimeSpan.FromMilliseconds(10) }
        );

        Assert.Equal(Models.ActionAttemptStatus.Success, actionAttempt.Status);
        Assert.Equal(2, handler.AttemptCount);
        var poll = handler.Requests[1];
        Assert.Equal(HttpMethod.Get, poll.Method);
        Assert.Equal(
            "/action_attempts/get?action_attempt_id=attempt1&_strict=true",
            poll.Uri.PathAndQuery
        );
        Assert.Equal("", poll.Body);
    }

    [Fact]
    public void RejectsANegativeTimeout()
    {
        var exception = Assert.Throws<SeamInvalidOptionsException>(
            () => new ActionAttemptWait { Timeout = TimeSpan.FromSeconds(-1) }
        );

        Assert.Equal(
            "Seam received invalid options: The Timeout option must not be negative, got -00:00:01",
            exception.Message
        );
    }

    [Theory]
    [InlineData(0)]
    [InlineData(-1)]
    public void RejectsAPollingIntervalThatIsNotPositive(int milliseconds)
    {
        var interval = TimeSpan.FromMilliseconds(milliseconds);

        var exception = Assert.Throws<SeamInvalidOptionsException>(
            () => new ActionAttemptWait { PollingInterval = interval }
        );

        Assert.Equal(
            $"Seam received invalid options: The PollingInterval option must be greater than zero, got {interval}",
            exception.Message
        );
    }

    [Fact]
    public void RejectsAnInfinitePollingInterval()
    {
        Assert.Throws<SeamInvalidOptionsException>(
            () => new ActionAttemptWait { PollingInterval = Timeout.InfiniteTimeSpan }
        );
    }

    [Fact]
    public void AcceptsAZeroTimeout()
    {
        Assert.Equal(TimeSpan.Zero, new ActionAttemptWait { Timeout = TimeSpan.Zero }.Timeout);
    }
}
