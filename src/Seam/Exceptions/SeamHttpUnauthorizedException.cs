namespace Seam
{
    /// <summary>
    /// Raised when the Seam API rejects the request credentials.
    /// </summary>
    public class SeamHttpUnauthorizedException : SeamHttpApiException
    {
        public SeamHttpUnauthorizedException(string? requestId)
            : base("unauthorized", "Unauthorized", 401, requestId) { }
    }
}
