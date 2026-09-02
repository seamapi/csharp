using System;

namespace Seam
{
    public class SeamInvalidWebhookPayloadException : SeamException
    {
        public SeamInvalidWebhookPayloadException(string message)
            : base(message) { }

        public SeamInvalidWebhookPayloadException(string message, Exception innerException)
            : base(message, innerException) { }
    }
}
