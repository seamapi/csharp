using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Seam.Http
{
    /// <summary>
    /// Applies the request timeout to each individual attempt.
    /// </summary>
    /// <remarks>
    /// This handler sits inside <see cref="SeamRetryHandler"/> so the timeout covers each
    /// attempt rather than the complete sequence of attempts, and the owning
    /// <see cref="HttpClient"/> disables its own whole-pipeline timeout. A timed out attempt
    /// throws <see cref="TimeoutException"/>, distinct from the
    /// <see cref="OperationCanceledException"/> of a caller's own cancellation.
    /// </remarks>
    public sealed class SeamTimeoutHandler : DelegatingHandler
    {
        private readonly TimeSpan _timeout;

        public SeamTimeoutHandler(TimeSpan timeout, HttpMessageHandler innerHandler)
            : base(innerHandler)
        {
            _timeout = timeout;
        }

        protected override async Task<HttpResponseMessage> SendAsync(
            HttpRequestMessage request,
            CancellationToken cancellationToken
        )
        {
            if (_timeout == Timeout.InfiniteTimeSpan)
                return await base.SendAsync(request, cancellationToken).ConfigureAwait(false);

            using var timeoutSource = CancellationTokenSource.CreateLinkedTokenSource(
                cancellationToken
            );
            timeoutSource.CancelAfter(_timeout);

            try
            {
                return await base.SendAsync(request, timeoutSource.Token).ConfigureAwait(false);
            }
            catch (OperationCanceledException exception)
                when (!cancellationToken.IsCancellationRequested)
            {
                throw new TimeoutException(
                    $"The request did not complete within the timeout of {_timeout.TotalSeconds}s.",
                    exception
                );
            }
        }
    }
}
