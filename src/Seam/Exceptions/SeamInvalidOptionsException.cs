namespace Seam
{
    /// <summary>
    /// Raised when a Seam client is constructed with missing or mutually exclusive options.
    /// </summary>
    public class SeamInvalidOptionsException : SeamException
    {
        public SeamInvalidOptionsException(string message)
            : base($"Seam received invalid options: {message}") { }
    }
}
