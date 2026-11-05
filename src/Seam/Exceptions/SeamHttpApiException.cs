using System.Text.Json;

namespace Seam
{
    /// <summary>
    /// Raised when the Seam API returns an error response.
    /// </summary>
    public class SeamHttpApiException : SeamException
    {
        public SeamHttpApiException(
            string code,
            string message,
            int statusCode,
            string? requestId,
            JsonElement? data = null
        )
            : base(message)
        {
            Code = code;
            StatusCode = statusCode;
            RequestId = requestId;
            Data = data;
        }

        /// <summary>The Seam error type, e.g. <c>device_not_found</c>.</summary>
        public string Code { get; }

        /// <summary>The HTTP status code of the error response.</summary>
        public int StatusCode { get; }

        /// <summary>The <c>seam-request-id</c> response header, or null when absent.</summary>
        public string? RequestId { get; }

        /// <summary>Additional error data from the Seam error envelope, when present.</summary>
        /// <remarks>Hides <see cref="System.Exception.Data"/> to carry the Seam error payload.</remarks>
        public new JsonElement? Data { get; }
    }
}
