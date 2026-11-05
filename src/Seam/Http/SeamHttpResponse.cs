using System;

namespace Seam.Http
{
    internal sealed class SeamHttpResponse<TResponse>
    {
        private readonly TResponse _data;

        public SeamHttpResponse(
            TResponse data,
            string path,
            string responseKey,
            int statusCode,
            string? requestId,
            string body
        )
        {
            _data = data;
            Path = path;
            ResponseKey = responseKey;
            StatusCode = statusCode;
            RequestId = requestId;
            Body = body;
        }

        public string Path { get; }

        public string ResponseKey { get; }

        public int StatusCode { get; }

        public string? RequestId { get; }

        public string Body { get; }

        public TValue Read<TValue>(Func<TResponse, TValue?> select)
            where TValue : class
        {
            return Read(ResponseKey, select);
        }

        public TValue Read<TValue>(string responseKey, Func<TResponse, TValue?> select)
            where TValue : class
        {
            return select(_data)
                ?? throw new SeamHttpInvalidResponseException(
                    Path,
                    responseKey,
                    "which is missing or null",
                    StatusCode,
                    RequestId,
                    Body
                );
        }
    }
}
