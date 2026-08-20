using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;

namespace Seam.Http
{
    /// <summary>
    /// Builds the <see cref="HttpClient"/> a Seam client sends requests with.
    /// </summary>
    /// <remarks>
    /// The client carries the endpoint, the authorization headers, and the
    /// <c>seam-sdk-name</c> and <c>seam-sdk-version</c> headers, with retry and per-attempt
    /// timeout handlers on its pipeline. The client's own whole-pipeline timeout is disabled so
    /// the timeout applies to each attempt rather than the complete sequence of attempts.
    /// </remarks>
    internal static class SeamHttpClientFactory
    {
        public static readonly TimeSpan DefaultTimeout = TimeSpan.FromSeconds(30);

        public const string SdkName = "seamapi/csharp";

        public static HttpClient Create(
            string endpoint,
            IReadOnlyDictionary<string, string> authHeaders,
            TimeSpan? timeout,
            int? maxRetries,
            HttpMessageHandler? httpMessageHandler
        )
        {
            var handler = new SeamRetryHandler(
                maxRetries ?? SeamRetryHandler.DefaultMaxRetries,
                new SeamTimeoutHandler(
                    timeout ?? DefaultTimeout,
                    httpMessageHandler ?? new SocketsHttpHandler()
                )
            );

            var client = new HttpClient(handler)
            {
                BaseAddress = new Uri(endpoint),
                Timeout = Timeout.InfiniteTimeSpan,
            };

            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json")
            );

            foreach (var (name, value) in authHeaders)
            {
                client.DefaultRequestHeaders.TryAddWithoutValidation(name, value);
            }

            // The SDK headers are set last so they always win.
            client.DefaultRequestHeaders.Remove("seam-sdk-name");
            client.DefaultRequestHeaders.TryAddWithoutValidation("seam-sdk-name", SdkName);
            client.DefaultRequestHeaders.Remove("seam-sdk-version");
            client.DefaultRequestHeaders.TryAddWithoutValidation(
                "seam-sdk-version",
                SeamVersion.Value
            );

            return client;
        }
    }
}
