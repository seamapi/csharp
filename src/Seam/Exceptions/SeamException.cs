using System;

namespace Seam
{
    /// <summary>
    /// The root of every exception the Seam SDK raises on its own behalf.
    /// </summary>
    /// <remarks>
    /// Transport failures that are not Seam API errors, such as a gateway returning HTML or a
    /// connection reset, surface as the BCL's own <see cref="System.Net.Http.HttpRequestException"/>
    /// rather than a fabricated Seam error.
    /// </remarks>
    public abstract class SeamException : Exception
    {
        protected SeamException(string message)
            : base(message) { }

        protected SeamException(string message, Exception innerException)
            : base(message, innerException) { }
    }
}
