using System;
using System.Net.Http;

namespace Seam
{
    /// <summary>
    /// Options for constructing a <see cref="SeamClient"/>.
    /// </summary>
    /// <remarks>
    /// Authenticate with either <see cref="ApiKey"/> or <see cref="PersonalAccessToken"/> plus
    /// <see cref="WorkspaceId"/>. When neither credential is given, the client reads
    /// <c>SEAM_API_KEY</c> or <c>SEAM_PERSONAL_ACCESS_TOKEN</c> (with <c>SEAM_WORKSPACE_ID</c>)
    /// from the environment, and <see cref="Endpoint"/> falls back to <c>SEAM_ENDPOINT</c>.
    /// </remarks>
    public sealed record SeamClientOptions
    {
        /// <summary>A Seam API key, scoped to a single workspace.</summary>
        public string? ApiKey { get; init; }

        /// <summary>
        /// A Seam personal access token, scoped to a Seam Console user. Requires
        /// <see cref="WorkspaceId"/>.
        /// </summary>
        public string? PersonalAccessToken { get; init; }

        /// <summary>The workspace a personal access token acts on.</summary>
        public string? WorkspaceId { get; init; }

        /// <summary>The Seam API endpoint. Defaults to <c>https://connect.getseam.com</c>.</summary>
        public string? Endpoint { get; init; }

        /// <summary>
        /// How endpoints that return an action attempt wait for it to finish. Defaults to
        /// waiting with a 10 second timeout, polling every second. Accepts a <c>bool</c>.
        /// </summary>
        public ActionAttemptWait? WaitForActionAttempt { get; init; }

        /// <summary>
        /// The timeout for each request attempt, covering connection and response. Defaults to
        /// 30 seconds. Retried attempts each get the full timeout.
        /// </summary>
        public TimeSpan? Timeout { get; init; }

        /// <summary>
        /// How many times an idempotent request is retried after a transient failure. Defaults
        /// to 2, for 3 total attempts. POST and PATCH requests are never retried.
        /// </summary>
        public int? MaxRetries { get; init; }

        /// <summary>
        /// The innermost <see cref="HttpMessageHandler"/> the client sends requests through,
        /// replacing the default <see cref="SocketsHttpHandler"/>. The SDK's retry and timeout
        /// handlers still apply. Useful for tests and custom transports.
        /// </summary>
        public HttpMessageHandler? HttpMessageHandler { get; init; }

        /// <summary>
        /// A fully configured <see cref="HttpClient"/> to use as is: its
        /// <see cref="HttpClient.BaseAddress"/> and headers must already carry the endpoint and
        /// authorization, and no SDK retry or timeout handlers are added. Cannot be combined
        /// with any other option except <see cref="WaitForActionAttempt"/>.
        /// </summary>
        public HttpClient? HttpClient { get; init; }
    }
}
