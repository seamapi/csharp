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

        private readonly TimeSpan _timeout = TimeSpan.FromSeconds(10);

        private readonly TimeSpan _pollingInterval = TimeSpan.FromSeconds(1);

        public bool Enabled { get; init; } = true;

        public TimeSpan Timeout
        {
            get => _timeout;
            init =>
                _timeout =
                    value >= TimeSpan.Zero
                        ? value
                        : throw new SeamInvalidOptionsException(
                            $"The Timeout option must not be negative, got {value}"
                        );
        }

        public TimeSpan PollingInterval
        {
            get => _pollingInterval;
            init =>
                _pollingInterval =
                    value > TimeSpan.Zero
                        ? value
                        : throw new SeamInvalidOptionsException(
                            $"The PollingInterval option must be greater than zero, got {value}"
                        );
        }

        public static implicit operator ActionAttemptWait(bool wait) => wait ? Default : DoNotWait;
    }
}
