namespace Seam.Test;

using Seam.Models;
using Seam.Test.Support;

public class WaitForActionAttemptTests : FakeSeamConnectTest
{
    private async Task<ActionAttempt> PendingActionAttemptAsync(SeamClient seam)
    {
        var actionAttempt = await seam.Locks.UnlockDoorAsync(
            new() { DeviceId = Seed("august_device_1") }
        );

        Assert.Equal(ActionAttemptStatus.Pending, actionAttempt.Status);

        await SetStatusAsync(seam, actionAttempt, "pending");

        return actionAttempt;
    }

    private Task SetStatusAsync(
        SeamClient seam,
        ActionAttempt actionAttempt,
        string status,
        object? error = null
    )
    {
        return PostFakeAsync(
            seam,
            "/_fake/update_action_attempt",
            error == null
                ? new { action_attempt_id = actionAttempt.ActionAttemptId, status }
                : new
                {
                    action_attempt_id = actionAttempt.ActionAttemptId,
                    status,
                    error,
                }
        );
    }

    [Fact]
    public async Task WaitsByDefault()
    {
        var actionAttempt = await CreateSeam()
            .Locks.UnlockDoorAsync(new() { DeviceId = Seed("august_device_1") });

        Assert.Equal(ActionAttemptStatus.Success, actionAttempt.Status);
    }

    [Fact]
    public async Task ClientDefaultCanDisableWaiting()
    {
        var seam = CreateSeam(waitForActionAttempt: false);

        var actionAttempt = await seam.Locks.UnlockDoorAsync(
            new() { DeviceId = Seed("august_device_1") }
        );

        Assert.Equal(ActionAttemptStatus.Pending, actionAttempt.Status);
    }

    // The options form of the client default has to wait just like `true` does; treating it as
    // "no waiting" would hand back a pending attempt with no indication anything was skipped.
    [Fact]
    public async Task ClientDefaultCanBeAnOptionsObject()
    {
        var seam = CreateSeam(
            waitForActionAttempt: new ActionAttemptWait
            {
                Timeout = TimeSpan.FromSeconds(5),
                PollingInterval = TimeSpan.FromMilliseconds(50),
            }
        );

        var actionAttempt = await seam.Locks.UnlockDoorAsync(
            new() { DeviceId = Seed("august_device_1") }
        );

        Assert.Equal(ActionAttemptStatus.Success, actionAttempt.Status);
    }

    [Fact]
    public async Task PerCallOptionCanDisableWaiting()
    {
        var actionAttempt = await CreateSeam()
            .Locks.UnlockDoorAsync(
                new() { DeviceId = Seed("august_device_1") },
                waitForActionAttempt: false
            );

        Assert.Equal(ActionAttemptStatus.Pending, actionAttempt.Status);
    }

    [Fact]
    public async Task PerCallOptionCanEnableWaiting()
    {
        var seam = CreateSeam(waitForActionAttempt: false);

        var actionAttempt = await seam.Locks.UnlockDoorAsync(
            new() { DeviceId = Seed("august_device_1") },
            waitForActionAttempt: true
        );

        Assert.Equal(ActionAttemptStatus.Success, actionAttempt.Status);
    }

    [Fact]
    public async Task ReturnsAnAlreadySuccessfulActionAttempt()
    {
        var seam = CreateSeam(waitForActionAttempt: false);

        var actionAttempt = await seam.Locks.UnlockDoorAsync(
            new() { DeviceId = Seed("august_device_1") }
        );
        await SetStatusAsync(seam, actionAttempt, "success");

        var resolved = await seam.ActionAttempts.GetAsync(
            new() { ActionAttemptId = actionAttempt.ActionAttemptId },
            waitForActionAttempt: true
        );

        Assert.Equal(ActionAttemptStatus.Success, resolved.Status);
        Assert.Equal(actionAttempt.ActionAttemptId, resolved.ActionAttemptId);
    }

    // Proves the resolver really re-reads the action attempt: it starts out pending and is moved
    // to success by something outside the resolver, the way the other SDK suites do it.
    [Fact]
    public async Task WaitsForAnActionAttemptResolvedOutOfBand()
    {
        var seam = CreateSeam(waitForActionAttempt: false);
        var actionAttempt = await PendingActionAttemptAsync(seam);

        var resolver = Task.Run(async () =>
        {
            await Task.Delay(TimeSpan.FromMilliseconds(500));
            await SetStatusAsync(seam, actionAttempt, "success");
        });

        var resolved = await seam.ActionAttempts.GetAsync(
            new() { ActionAttemptId = actionAttempt.ActionAttemptId },
            waitForActionAttempt: new ActionAttemptWait
            {
                Timeout = TimeSpan.FromSeconds(15),
                PollingInterval = TimeSpan.FromMilliseconds(100),
            }
        );

        Assert.Equal(ActionAttemptStatus.Success, resolved.Status);
        await resolver;
    }

    [Fact]
    public async Task ThrowsWhenTheActionAttemptFails()
    {
        var seam = CreateSeam(waitForActionAttempt: false);

        var actionAttempt = await seam.Locks.UnlockDoorAsync(
            new() { DeviceId = Seed("august_device_1") }
        );
        await SetStatusAsync(
            seam,
            actionAttempt,
            "error",
            new { type = "foo", message = "Failed" }
        );

        var exception = await Assert.ThrowsAsync<SeamActionAttemptFailedException>(
            () =>
                seam.ActionAttempts.GetAsync(
                    new() { ActionAttemptId = actionAttempt.ActionAttemptId },
                    waitForActionAttempt: true
                )
        );

        Assert.Equal("Failed", exception.Message);
        Assert.Equal("foo", exception.Code);
        Assert.Equal(ActionAttemptStatus.Error, exception.ActionAttempt.Status);
        Assert.Equal(actionAttempt.ActionAttemptId, exception.ActionAttempt.ActionAttemptId);
        Assert.IsAssignableFrom<SeamActionAttemptException>(exception);
    }

    [Fact]
    public async Task TimesOutWhileTheActionAttemptIsPending()
    {
        var seam = CreateSeam(waitForActionAttempt: false);
        var actionAttempt = await PendingActionAttemptAsync(seam);

        var exception = await Assert.ThrowsAsync<SeamActionAttemptTimeoutException>(
            () =>
                seam.ActionAttempts.GetAsync(
                    new() { ActionAttemptId = actionAttempt.ActionAttemptId },
                    waitForActionAttempt: new ActionAttemptWait
                    {
                        Timeout = TimeSpan.FromMilliseconds(200),
                        PollingInterval = TimeSpan.FromSeconds(5),
                    }
                )
        );

        Assert.Equal(actionAttempt.ActionAttemptId, exception.ActionAttempt.ActionAttemptId);
        Assert.Contains("Timed out waiting for action attempt", exception.Message);
    }

    // Resolving fetches the action attempt through the transport rather than the route client,
    // so enabling the option on the route that reads action attempts cannot recurse.
    [Fact]
    public async Task ActionAttemptsGetDoesNotRecurse()
    {
        var seam = CreateSeam(waitForActionAttempt: false);

        var actionAttempt = await seam.Locks.UnlockDoorAsync(
            new() { DeviceId = Seed("august_device_1") }
        );
        await SetStatusAsync(seam, actionAttempt, "success");

        var resolved = await seam.ActionAttempts.GetAsync(
            new() { ActionAttemptId = actionAttempt.ActionAttemptId },
            waitForActionAttempt: new ActionAttemptWait
            {
                Timeout = TimeSpan.FromSeconds(1),
                PollingInterval = TimeSpan.FromMilliseconds(50),
            }
        );

        Assert.Equal(ActionAttemptStatus.Success, resolved.Status);
    }

    // A list of action attempts is returned as is: only a single returned attempt is ever
    // resolved, so listing must not poll pending attempts.
    [Fact]
    public async Task ListReturnsActionAttemptsWithoutResolvingThem()
    {
        var seam = CreateSeam(waitForActionAttempt: false);
        var pending = await PendingActionAttemptAsync(seam);

        var attempts = await seam.ActionAttempts.ListAsync(
            new() { ActionAttemptIds = new List<string> { pending.ActionAttemptId } }
        );

        var attempt = Assert.Single(attempts);
        Assert.Equal(pending.ActionAttemptId, attempt.ActionAttemptId);
        Assert.Equal(ActionAttemptStatus.Pending, attempt.Status);
    }

    [Fact]
    public void WaitForActionAttemptDefaultsToEnabled()
    {
        Assert.True(ActionAttemptWait.Default.Enabled);
        Assert.Equal(TimeSpan.FromSeconds(10), ActionAttemptWait.Default.Timeout);
        Assert.Equal(TimeSpan.FromSeconds(1), ActionAttemptWait.Default.PollingInterval);
        Assert.False(ActionAttemptWait.DoNotWait.Enabled);
    }
}
