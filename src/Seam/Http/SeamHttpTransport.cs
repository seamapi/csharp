using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace Seam.Http
{
    /// <summary>
    /// Executes Seam API requests: GET and DELETE carry their parameters as URL search
    /// parameters per the Seam serialization standard, every other method sends a JSON body,
    /// and a Seam error response raises the matching <see cref="SeamHttpApiException"/>.
    /// </summary>
    /// <remarks>
    /// A response that is not a Seam error envelope, such as a gateway returning HTML, raises
    /// the <see cref="HttpRequestException"/> the transport would have raised on its own rather
    /// than a fabricated Seam error.
    /// </remarks>
    internal sealed class SeamHttpTransport
    {
        public SeamHttpTransport(HttpClient client)
        {
            if (client.BaseAddress == null)
                throw new SeamInvalidOptionsException(
                    "The HttpClient option requires a client with a BaseAddress"
                );

            Client = client;
        }

        public HttpClient Client { get; }

        public async Task<SeamHttpResponse<TResponse>> SendAsync<TResponse>(
            HttpMethod method,
            string path,
            object? parameters,
            string responseKey,
            CancellationToken cancellationToken
        )
        {
            using var response = await ExecuteAsync(method, path, parameters, cancellationToken)
                .ConfigureAwait(false);

            var statusCode = (int)response.StatusCode;
            var requestId = GetRequestId(response);

            var body = await response
                .Content.ReadAsStringAsync(cancellationToken)
                .ConfigureAwait(false);

            if (body.Length == 0)
                throw new SeamHttpInvalidResponseException(
                    path,
                    responseKey,
                    "got an empty body",
                    statusCode,
                    requestId,
                    body
                );

            TResponse? data;
            try
            {
                data = JsonSerializer.Deserialize<TResponse>(body, SeamJson.Options);
            }
            catch (JsonException exception)
            {
                throw new SeamHttpInvalidResponseException(
                    path,
                    responseKey,
                    "which could not be deserialized",
                    statusCode,
                    requestId,
                    body,
                    exception
                );
            }

            if (data == null)
                throw new SeamHttpInvalidResponseException(
                    path,
                    responseKey,
                    "got null instead of a response object",
                    statusCode,
                    requestId,
                    body
                );

            return new SeamHttpResponse<TResponse>(
                data,
                path,
                responseKey,
                statusCode,
                requestId,
                body
            );
        }

        public async Task SendAsync(
            HttpMethod method,
            string path,
            object? parameters,
            CancellationToken cancellationToken
        )
        {
            using var response = await ExecuteAsync(method, path, parameters, cancellationToken)
                .ConfigureAwait(false);
        }

        private async Task<HttpResponseMessage> ExecuteAsync(
            HttpMethod method,
            string path,
            object? parameters,
            CancellationToken cancellationToken
        )
        {
            using var request = CreateRequest(method, path, parameters);

            var response = await Client.SendAsync(request, cancellationToken).ConfigureAwait(false);

            if (response.IsSuccessStatusCode)
                return response;

            using (response)
            {
                throw await ToExceptionAsync(response, cancellationToken).ConfigureAwait(false);
            }
        }

        private static HttpRequestMessage CreateRequest(
            HttpMethod method,
            string path,
            object? parameters
        )
        {
            if (CarriesDataInQuery(method))
            {
                var query =
                    parameters == null
                        ? ""
                        : StrictUrlSearchParamsSerializer.Serialize(ToSearchParams(parameters));

                var uri = query.Length > 0 ? $"{path}?{query}" : path;

                return new HttpRequestMessage(method, uri);
            }

            var body = JsonSerializer.Serialize(
                parameters ?? new object(),
                parameters?.GetType() ?? typeof(object),
                SeamJson.Options
            );

            return new HttpRequestMessage(method, path)
            {
                Content = new StringContent(body, Encoding.UTF8, "application/json"),
            };
        }

        private static bool CarriesDataInQuery(HttpMethod method) =>
            method == HttpMethod.Get || method == HttpMethod.Delete;

        private static async Task<Exception> ToExceptionAsync(
            HttpResponseMessage response,
            CancellationToken cancellationToken
        )
        {
            var statusCode = (int)response.StatusCode;
            var requestId = GetRequestId(response);
            var error = await GetErrorAsync(response, cancellationToken).ConfigureAwait(false);

            if (statusCode == 401)
            {
                if (error is not { } unauthorizedError)
                    return new SeamHttpUnauthorizedException(requestId);

                return new SeamHttpUnauthorizedException(
                    requestId,
                    unauthorizedError.GetProperty("message").GetString()!,
                    GetData(unauthorizedError)
                );
            }

            if (error is not { } seamError)
            {
                try
                {
                    response.EnsureSuccessStatusCode();
                }
                catch (HttpRequestException exception)
                {
                    return exception;
                }
            }
            else
            {
                var type = seamError.GetProperty("type").GetString()!;
                var message = seamError.GetProperty("message").GetString()!;
                var data = GetData(seamError);

                if (type == "invalid_input")
                {
                    JsonElement? validationErrors = seamError.TryGetProperty(
                        "validation_errors",
                        out var validationErrorsElement
                    )
                        ? validationErrorsElement
                        : null;

                    return new SeamHttpInvalidInputException(
                        message,
                        statusCode,
                        requestId,
                        data,
                        validationErrors
                    );
                }

                return new SeamHttpApiException(type, message, statusCode, requestId, data);
            }

            // Unreachable: EnsureSuccessStatusCode always throws for a non-success status.
            return new HttpRequestException($"Request failed with status code {statusCode}.");
        }

        /// <summary>
        /// The error from a Seam error envelope, i.e. JSON holding an <c>error</c> object with a
        /// string <c>type</c> and <c>message</c>, or null when the response is not one.
        /// </summary>
        private static async Task<JsonElement?> GetErrorAsync(
            HttpResponseMessage response,
            CancellationToken cancellationToken
        )
        {
            var contentType = response.Content.Headers.ContentType?.MediaType;

            if (contentType != "application/json")
                return null;

            var body = await response
                .Content.ReadAsStringAsync(cancellationToken)
                .ConfigureAwait(false);

            JsonElement root;
            try
            {
                using var document = JsonDocument.Parse(body);
                root = document.RootElement.Clone();
            }
            catch (JsonException)
            {
                return null;
            }

            if (
                root.ValueKind != JsonValueKind.Object
                || !root.TryGetProperty("error", out var error)
                || error.ValueKind != JsonValueKind.Object
                || !error.TryGetProperty("type", out var type)
                || type.ValueKind != JsonValueKind.String
                || !error.TryGetProperty("message", out var message)
                || message.ValueKind != JsonValueKind.String
            )
            {
                return null;
            }

            return error;
        }

        private static JsonElement? GetData(JsonElement error) =>
            error.TryGetProperty("data", out var data) ? data : null;

        private static string? GetRequestId(HttpResponseMessage response) =>
            response.Headers.TryGetValues("seam-request-id", out var values)
                ? values.FirstOrDefault()
                : null;

        /// <summary>
        /// Converts a request object to search parameters through the JSON contract, so query
        /// and body parameters share names and values.
        /// </summary>
        /// <remarks>
        /// An unset parameter is absent from the JSON contract, so a null can only be the
        /// <see cref="Null"/> sentinel and is restored as one.
        /// </remarks>
        internal static IDictionary ToSearchParams(object data)
        {
            var element = JsonSerializer.SerializeToElement(data, data.GetType(), SeamJson.Options);

            if (ToSearchParamValue(element) is not IDictionary parameters)
                throw new ArgumentException(
                    $"Request data must serialize to an object, got {element.ValueKind}",
                    nameof(data)
                );

            return parameters;
        }

        private static object? ToSearchParamValue(JsonElement element)
        {
            switch (element.ValueKind)
            {
                case JsonValueKind.Object:
                    var parameters = new Dictionary<string, object?>();
                    foreach (var property in element.EnumerateObject())
                    {
                        parameters[property.Name] = ToSearchParamValue(property.Value);
                    }
                    return parameters;
                case JsonValueKind.Array:
                    return element.EnumerateArray().Select(ToSearchParamValue).ToList();
                case JsonValueKind.Null:
                case JsonValueKind.Undefined:
                    return Null.Value;
                case JsonValueKind.String:
                    return element.GetString();
                case JsonValueKind.True:
                    return true;
                case JsonValueKind.False:
                    return false;
                case JsonValueKind.Number:
                    if (element.TryGetInt64(out var integer))
                        return integer;
                    if (element.TryGetDecimal(out var dec))
                        return dec;
                    return element.GetDouble();
                default:
                    throw new InvalidOperationException(
                        $"Unexpected JSON value kind {element.ValueKind}"
                    );
            }
        }
    }
}
