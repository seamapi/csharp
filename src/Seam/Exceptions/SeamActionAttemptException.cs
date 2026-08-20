using System;

namespace Seam
{
    /// <summary>
    /// Base class for the exceptions raised while resolving an action attempt.
    /// </summary>
    public abstract class SeamActionAttemptException : SeamException
    {
        protected SeamActionAttemptException(string message, Models.ActionAttempt actionAttempt)
            : base(message)
        {
            ActionAttempt = actionAttempt;
        }

        public Models.ActionAttempt ActionAttempt { get; }
    }

    /// <summary>
    /// Raised when an action attempt finishes in the error state.
    /// </summary>
    public class SeamActionAttemptFailedException : SeamActionAttemptException
    {
        public SeamActionAttemptFailedException(Models.ActionAttempt actionAttempt)
            : base(actionAttempt.Error?.Message ?? "Action attempt failed", actionAttempt)
        {
            Code = actionAttempt.Error?.Type ?? "unknown_error";
        }

        /// <summary>The action attempt error type.</summary>
        public string Code { get; }
    }

    /// <summary>
    /// Raised when an action attempt does not finish within the timeout.
    /// </summary>
    /// <remarks>
    /// The action attempt it carries is the last one observed, which is still pending.
    /// </remarks>
    public class SeamActionAttemptTimeoutException : SeamActionAttemptException
    {
        public SeamActionAttemptTimeoutException(
            Models.ActionAttempt actionAttempt,
            TimeSpan timeout
        )
            : base(
                $"Timed out waiting for action attempt after {timeout.TotalSeconds}s",
                actionAttempt
            )
        {
            Timeout = timeout;
        }

        public TimeSpan Timeout { get; }
    }
}
