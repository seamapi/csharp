using System;

namespace Seam
{
    public class SeamHttpInvalidResponseException : SeamException
    {
        public SeamHttpInvalidResponseException(
            string path,
            string responseKey,
            string reason,
            int statusCode,
            string? requestId,
            string responseBody,
            Exception? innerException = null
        )
            : base(
                $"Seam returned an invalid response for {path}: expected \"{responseKey}\", {reason}",
                innerException
            )
        {
            Path = path;
            ResponseKey = responseKey;
            StatusCode = statusCode;
            RequestId = requestId;
            ResponseBody = responseBody;
        }

        public string Path { get; }

        public string ResponseKey { get; }

        public int StatusCode { get; }

        public string? RequestId { get; }

        public string ResponseBody { get; }
    }
}
