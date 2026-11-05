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

            return ReadEvent(payload);
        }

        private static Models.Event ReadEvent(string payload)
        {
            JsonDocument document;
            try
            {
                document = JsonDocument.Parse(payload);
            }
            catch (JsonException exception)
            {
                throw new SeamInvalidWebhookPayloadException(
                    "The verified webhook payload is not valid JSON",
                    exception
                );
            }

            using (document)
            {
                var root = document.RootElement;

                if (
                    root.ValueKind != JsonValueKind.Object
                    || !root.TryGetProperty("event_id", out var eventId)
                    || eventId.ValueKind != JsonValueKind.String
                    || !root.TryGetProperty("event_type", out var eventType)
                    || eventType.ValueKind != JsonValueKind.String
                )
                {
                    throw new SeamInvalidWebhookPayloadException(
                        "The verified webhook payload did not contain a Seam event"
                    );
                }

                try
                {
                    return root.Deserialize<Models.Event>(SeamJson.Options)
                        ?? throw new SeamInvalidWebhookPayloadException(
                            "The verified webhook payload did not contain a Seam event"
                        );
                }
                catch (JsonException exception)
                {
                    throw new SeamInvalidWebhookPayloadException(
                        "The verified webhook payload could not be read as a Seam event",
                        exception
                    );
                }
            }
        }
    }
}
