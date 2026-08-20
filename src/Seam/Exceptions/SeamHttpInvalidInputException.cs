using System;
using System.Collections.Generic;
using System.Text.Json;

namespace Seam
{
    /// <summary>
    /// Raised when the Seam API rejects the request parameters.
    /// </summary>
    public class SeamHttpInvalidInputException : SeamHttpApiException
    {
        private readonly JsonElement? _validationErrors;

        public SeamHttpInvalidInputException(
            string message,
            int statusCode,
            string? requestId,
            JsonElement? data = null,
            JsonElement? validationErrors = null
        )
            : base("invalid_input", message, statusCode, requestId, data)
        {
            _validationErrors = validationErrors;
        }

        /// <summary>
        /// The validation messages for a request parameter, or an empty list when that parameter
        /// has none.
        /// </summary>
        public IReadOnlyList<string> GetValidationErrorMessages(string paramName)
        {
            if (
                _validationErrors is not { ValueKind: JsonValueKind.Object } validationErrors
                || !validationErrors.TryGetProperty(paramName, out var param)
                || param.ValueKind != JsonValueKind.Object
                || !param.TryGetProperty("_errors", out var errors)
                || errors.ValueKind != JsonValueKind.Array
            )
            {
                return Array.Empty<string>();
            }

            var messages = new List<string>();
            foreach (var error in errors.EnumerateArray())
            {
                if (error.ValueKind == JsonValueKind.String)
                    messages.Add(error.GetString()!);
            }

            return messages;
        }
    }
}
