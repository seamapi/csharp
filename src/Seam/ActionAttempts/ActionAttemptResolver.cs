using System;
using System.Diagnostics;
using System.Net.Http;
using System.Text.Json.Serialization;
using System.Threading;
using System.Threading.Tasks;
using Seam.Http;

namespace Seam
{
    /// <summary>
    /// Waits for an action attempt to reach a terminal state.
    /// </summary>
    /// <remarks>
    /// A successful attempt is returned as is, a failed one raises, and a pending one is polled
    /// until it finishes or the timeout elapses. The timeout is checked before each poll so the
    /// resolver never sleeps past the deadline. Cancelling the caller's token raises
    /// <see cref="System.OperationCanceledException"/>, distinct from the Seam timeout.
    /// </remarks>
    internal static class ActionAttemptResolver
    {
        public static async Task<Models.ActionAttempt> ResolveAsync(
            Models.ActionAttempt actionAttempt,
            SeamHttpTransport transport,
            ActionAttemptWait wait,
            CancellationToken cancellationToken
        )
        {
            if (!wait.Enabled)
                return actionAttempt;

            var elapsed = Stopwatch.StartNew();
            var deadlineReached = false;

            while (true)
            {
                if (actionAttempt.Status == Models.ActionAttemptStatus.Success)
                    return actionAttempt;

                if (actionAttempt.Status == Models.ActionAttemptStatus.Error)
                    throw new SeamActionAttemptFailedException(actionAttempt);

                var remaining = wait.Timeout - elapsed.Elapsed;

                if (deadlineReached || remaining <= TimeSpan.Zero)
                    throw new SeamActionAttemptTimeoutException(actionAttempt, wait.Timeout);

                deadlineReached = wait.PollingInterval >= remaining;

                await Task.Delay(
                        deadlineReached ? remaining : wait.PollingInterval,
                        cancellationToken
                    )
                    .ConfigureAwait(false);

                actionAttempt = await GetActionAttemptAsync(
                        transport,
                        actionAttempt.ActionAttemptId,
                        cancellationToken
                    )
                    .ConfigureAwait(false);
            }
        }

        /// <summary>
        /// Fetches the action attempt directly through the transport, rather than through the
        /// generated endpoint method, so waiting does not recurse.
        /// </summary>
        private static async Task<Models.ActionAttempt> GetActionAttemptAsync(
            SeamHttpTransport transport,
            string actionAttemptId,
            CancellationToken cancellationToken
        )
        {
            var response = await transport
                .SendAsync<GetActionAttemptResponse>(
                    HttpMethod.Get,
                    "/action_attempts/get",
                    new GetActionAttemptRequest { ActionAttemptId = actionAttemptId },
                    "action_attempt",
                    cancellationToken
                )
                .ConfigureAwait(false);

            return response.Read(r => r.ActionAttempt);
        }

        private sealed record GetActionAttemptRequest
        {
            [JsonPropertyName("action_attempt_id")]
            public required string ActionAttemptId { get; init; }
        }

        private sealed record GetActionAttemptResponse
        {
            [JsonPropertyName("action_attempt")]
            public Models.ActionAttempt? ActionAttempt { get; init; }
        }
    }
}
