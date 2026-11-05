using System;
using System.Net.Http;
using Seam.Http;

namespace Seam
{
    /// <summary>
    /// The Seam API client, scoped to a single workspace.
    /// </summary>
    /// <remarks>
    /// <code>
    /// using Seam;
    ///
    /// var seam = new SeamClient(apiKey: "seam_...");
    /// var device = await seam.Locks.GetAsync(new() { DeviceId = "..." });
    /// </code>
    /// </remarks>
    public sealed partial class SeamClient : IDisposable
    {
        private readonly bool _ownsClient;

        public SeamClient(string apiKey)
            : this(new SeamClientOptions { ApiKey = apiKey }) { }

        public SeamClient(SeamClientOptions? options = null)
        {
            options ??= new SeamClientOptions();

            if (options.HttpClient != null)
            {
                Http.Options.CheckHttpClientOptions(
                    options.HttpClient,
                    ("ApiKey", options.ApiKey),
                    ("PersonalAccessToken", options.PersonalAccessToken),
                    ("WorkspaceId", options.WorkspaceId),
                    ("Endpoint", options.Endpoint),
                    ("Timeout", options.Timeout),
                    ("MaxRetries", options.MaxRetries),
                    ("HttpMessageHandler", options.HttpMessageHandler)
                );

                Transport = new SeamHttpTransport(options.HttpClient);
                _ownsClient = false;
            }
            else
            {
                Transport = new SeamHttpTransport(
                    SeamHttpClientFactory.Create(
                        Http.Options.GetEndpoint(options.Endpoint),
                        Auth.GetAuthHeaders(
                            options.ApiKey,
                            options.PersonalAccessToken,
                            options.WorkspaceId
                        ),
                        options.Timeout,
                        options.MaxRetries,
                        options.HttpMessageHandler
                    )
                );
                _ownsClient = true;
            }

            WaitForActionAttemptDefault = options.WaitForActionAttempt ?? ActionAttemptWait.Default;
        }

        public static SeamClient FromApiKey(string apiKey, SeamClientOptions? options = null)
        {
            return new SeamClient((options ?? new SeamClientOptions()) with { ApiKey = apiKey });
        }

        public static SeamClient FromPersonalAccessToken(
            string personalAccessToken,
            string workspaceId,
            SeamClientOptions? options = null
        )
        {
            return new SeamClient(
                (options ?? new SeamClientOptions()) with
                {
                    PersonalAccessToken = personalAccessToken,
                    WorkspaceId = workspaceId,
                }
            );
        }

        public static SeamClient FromHttpClient(
            HttpClient httpClient,
            ActionAttemptWait? waitForActionAttempt = null
        )
        {
            return new SeamClient(
                new SeamClientOptions
                {
                    HttpClient = httpClient,
                    WaitForActionAttempt = waitForActionAttempt,
                }
            );
        }

        /// <summary>
        /// The <see cref="HttpClient"/> the SDK sends requests with, fully configured with the
        /// endpoint, authorization, and retry behavior, for calling the Seam API directly.
        /// </summary>
        public HttpClient Client => Transport.Client;

        internal SeamHttpTransport Transport { get; }

        internal ActionAttemptWait WaitForActionAttemptDefault { get; }

        /// <summary>
        /// Creates a paginator over any page-fetching function. Paginated endpoints offer a
        /// ready-made one via their <c>ListPager</c> method.
        /// </summary>
        public SeamPaginator<TItem> CreatePaginator<TItem>(FetchPage<TItem> fetchPage)
        {
            return new SeamPaginator<TItem>(fetchPage);
        }

        public void Dispose()
        {
            if (_ownsClient)
                Client.Dispose();
        }
    }
}
