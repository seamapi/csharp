using System;

namespace Seam
{
    /// <summary>
    /// How an endpoint that returns an action attempt waits for it to finish.
    /// </summary>
    /// <remarks>
    /// By default, every such endpoint polls the action attempt until it succeeds, returning the
    /// finished attempt, raising <see cref="SeamActionAttemptFailedException"/> when it fails,
    /// and <see cref="SeamActionAttemptTimeoutException"/> when it is still pending after
    /// <see cref="Timeout"/>. Pass <see cref="DoNotWait"/> (or <c>false</c>) to get the pending
    /// attempt back immediately instead. Set client-wide via
    /// <see cref="SeamClientOptions.WaitForActionAttempt"/> or per call via the endpoint's
    /// <c>waitForActionAttempt</c> parameter.
    /// </remarks>
    public sealed class ActionAttemptWait
    {
        /// <summary>Wait with the default timeout and polling interval.</summary>
        public static ActionAttemptWait Default { get; } = new();

        /// <summary>Return the pending action attempt immediately without waiting.</summary>
        public static ActionAttemptWait DoNotWait { get; } = new() { Enabled = false };

        public bool Enabled { get; init; } = true;

        public TimeSpan Timeout { get; init; } = TimeSpan.FromSeconds(10);

        public TimeSpan PollingInterval { get; init; } = TimeSpan.FromSeconds(1);

        public static implicit operator ActionAttemptWait(bool wait) => wait ? Default : DoNotWait;
    }
}
