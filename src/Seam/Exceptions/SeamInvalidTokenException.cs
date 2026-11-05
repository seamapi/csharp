namespace Seam
{
    /// <summary>
    /// Raised when a Seam client is constructed with the wrong kind of token, so the mistake
    /// produces a specific error instead of an opaque 401 from the server.
    /// </summary>
    public class SeamInvalidTokenException : SeamException
    {
        public SeamInvalidTokenException(string message)
            : base($"Seam received an invalid token: {message}") { }
    }
}
