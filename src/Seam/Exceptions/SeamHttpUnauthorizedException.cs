using System.Text.Json;

namespace Seam
{
    /// <summary>
    /// Raised when the Seam API rejects the request credentials.
    /// </summary>
    public class SeamHttpUnauthorizedException : SeamHttpApiException
    {
        public SeamHttpUnauthorizedException(string? requestId)
            : this(requestId, "Unauthorized") { }

        public SeamHttpUnauthorizedException(
            string? requestId,
            string message,
            JsonElement? data = null
        )
            : base("unauthorized", message, 401, requestId, data) { }
    }
}
