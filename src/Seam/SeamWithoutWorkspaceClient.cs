using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Seam.Http;

namespace Seam
{
    /// <summary>
    /// A Seam API client authenticated with a personal access token but not scoped to a
    /// workspace, for listing and creating workspaces.
    /// </summary>
    /// <remarks>
    /// <code>
    /// var seam = new SeamWithoutWorkspaceClient(personalAccessToken: "seam_at...");
    /// var workspaces = await seam.Workspaces.ListAsync();
    /// </code>
    /// </remarks>
    public sealed class SeamWithoutWorkspaceClient : IDisposable
    {
        public SeamWithoutWorkspaceClient(
            string? personalAccessToken = null,
            string? endpoint = null,
            TimeSpan? timeout = null,
            int? maxRetries = null,
            HttpMessageHandler? httpMessageHandler = null
        )
        {
            var transport = new SeamHttpTransport(
                SeamHttpClientFactory.Create(
                    Http.Options.GetEndpoint(endpoint),
                    Auth.GetAuthHeadersWithoutWorkspace(personalAccessToken),
                    timeout,
                    maxRetries,
                    httpMessageHandler
                )
            );

            Client = transport.Client;
            Workspaces = new WorkspacesProxy(
                new Routes.Workspaces(transport, ActionAttemptWait.DoNotWait)
            );
        }

        public static SeamWithoutWorkspaceClient FromPersonalAccessToken(
            string personalAccessToken,
            string? endpoint = null,
            TimeSpan? timeout = null,
            int? maxRetries = null,
            HttpMessageHandler? httpMessageHandler = null
        )
        {
            return new SeamWithoutWorkspaceClient(
                personalAccessToken,
                endpoint,
                timeout,
                maxRetries,
                httpMessageHandler
            );
        }

        /// <summary>
        /// The <see cref="HttpClient"/> the SDK sends requests with, for calling the Seam API
        /// directly.
        /// </summary>
        public HttpClient Client { get; }

        public WorkspacesProxy Workspaces { get; }

        public void Dispose()
        {
            Client.Dispose();
        }

        /// <summary>
        /// The workspace operations available without a workspace in scope.
        /// </summary>
        public sealed class WorkspacesProxy
        {
            private readonly Routes.Workspaces _workspaces;

            internal WorkspacesProxy(Routes.Workspaces workspaces)
            {
                _workspaces = workspaces;
            }

            public Task<List<Models.Workspace>> ListAsync(
                Routes.Workspaces.ListRequest? request = null,
                CancellationToken cancellationToken = default
            )
            {
                return _workspaces.ListAsync(request, cancellationToken);
            }

            public Task<Models.Workspace> CreateAsync(
                Routes.Workspaces.CreateRequest request,
                CancellationToken cancellationToken = default
            )
            {
                return _workspaces.CreateAsync(request, cancellationToken);
            }
        }
    }
}
