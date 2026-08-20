using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Seam.Http
{
    /// <summary>
    /// Retries transient failures for idempotent requests.
    /// </summary>
    /// <remarks>
    /// <para>
    /// Only GET, HEAD, OPTIONS, PUT, and DELETE are retried, so a retried request can never
    /// duplicate a write: POST and PATCH fail on the first transient error. A request is retried
    /// on a transport error, a timed out attempt, a 429, or a 5xx.
    /// </para>
    /// <para>
    /// The delay before each retry is an exponential backoff with jitter, compared with, rather
    /// than replaced by, the server's <c>Retry-After</c> so a server asking for a longer wait is
    /// honored.
    /// </para>
    /// </remarks>
    internal sealed class SeamRetryHandler : DelegatingHandler
    {
        public const int DefaultMaxRetries = 2;

        private const double InitialDelaySeconds = 0.2;

        private const double JitterMultiplier = 1.2;

        private static readonly HashSet<HttpMethod> IdempotentMethods =
            new()
            {
                HttpMethod.Get,
                HttpMethod.Head,
                HttpMethod.Options,
                HttpMethod.Put,
                HttpMethod.Delete,
            };

        private readonly int _maxRetries;

        public SeamRetryHandler(int maxRetries, HttpMessageHandler innerHandler)
            : base(innerHandler)
        {
            _maxRetries = Math.Max(0, maxRetries);
        }

        protected override async Task<HttpResponseMessage> SendAsync(
            HttpRequestMessage request,
            CancellationToken cancellationToken
        )
        {
            var maxRetries = IdempotentMethods.Contains(request.Method) ? _maxRetries : 0;

            for (var retryCount = 1; ; retryCount++)
            {
                HttpResponseMessage? response = null;
                Exception? transientException = null;

                try
                {
                    response = await base.SendAsync(request, cancellationToken)
                        .ConfigureAwait(false);
                }
                catch (Exception exception)
                    when (exception is HttpRequestException or TimeoutException)
                {
                    transientException = exception;
                }

                if (response != null && !IsRetryableStatus(response))
                    return response;

                if (retryCount > maxRetries)
                {
                    if (transientException != null)
                        throw transientException;

                    return response!;
                }

                var delay = GetDelay(retryCount, response);
                response?.Dispose();

                await Task.Delay(delay, cancellationToken).ConfigureAwait(false);
            }
        }

        private static bool IsRetryableStatus(HttpResponseMessage response)
        {
            var statusCode = (int)response.StatusCode;

            return statusCode == 429 || (statusCode >= 500 && statusCode <= 599);
        }

        private static TimeSpan GetDelay(int retryCount, HttpResponseMessage? response)
        {
            var backoff = InitialDelaySeconds * Math.Pow(2.0, retryCount - 1);
            var jitteredBackoff = TimeSpan.FromSeconds(
                backoff * (1.0 + Random.Shared.NextDouble() * (JitterMultiplier - 1.0))
            );

            var retryAfter = GetRetryAfter(response);

            return retryAfter > jitteredBackoff ? retryAfter : jitteredBackoff;
        }

        private static TimeSpan GetRetryAfter(HttpResponseMessage? response)
        {
            var retryAfter = response?.Headers.RetryAfter;

            if (retryAfter == null)
                return TimeSpan.Zero;

            if (retryAfter.Delta is { } delta)
                return delta;

            if (retryAfter.Date is { } date)
            {
                var delay = date - DateTimeOffset.UtcNow;

                return delay > TimeSpan.Zero ? delay : TimeSpan.Zero;
            }

            return TimeSpan.Zero;
        }
    }
}
