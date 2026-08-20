using System.Collections.Generic;
using System.Net;
using System.Text.Json;

namespace Seam
{
    /// <summary>
    /// Verifies and parses incoming Seam webhook events.
    /// </summary>
    /// <remarks>
    /// Named SeamWebhook rather than Webhook to leave that name to the webhook resource returned
    /// by the API. Verification failures raise
    /// <see cref="Svix.Exceptions.WebhookVerificationException"/>.
    /// <code>
    /// var webhook = new SeamWebhook(Environment.GetEnvironmentVariable("SEAM_WEBHOOK_SECRET")!);
    /// var seamEvent = webhook.Verify(requestBody, requestHeaders);
    /// </code>
    /// </remarks>
    public sealed class SeamWebhook
    {
        private readonly Svix.Webhook _webhook;

        /// <param name="secret">The webhook secret from the Seam Console.</param>
        public SeamWebhook(string secret)
        {
            _webhook = new Svix.Webhook(secret);
        }

        /// <summary>
        /// Verifies an incoming webhook request and returns the event it carries.
        /// </summary>
        /// <param name="payload">The raw HTTP request body.</param>
        /// <param name="headers">The HTTP request headers.</param>
        /// <exception cref="Svix.Exceptions.WebhookVerificationException">
        /// When the signature does not match.
        /// </exception>
        public Models.Event Verify(string payload, IReadOnlyDictionary<string, string> headers)
        {
            var normalizedHeaders = new WebHeaderCollection();
            foreach (var (name, value) in headers)
            {
                normalizedHeaders.Add(name.ToLowerInvariant(), value);
            }

            _webhook.Verify(payload, normalizedHeaders);

            return JsonSerializer.Deserialize<Models.Event>(payload, SeamJson.Options)
                ?? throw new Svix.Exceptions.WebhookVerificationException(
                    "The verified webhook payload did not contain an event"
                );
        }
    }
}
