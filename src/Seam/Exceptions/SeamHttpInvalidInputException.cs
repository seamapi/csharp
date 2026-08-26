using System;
using System.Collections.Generic;
using System.Text.Json;

namespace Seam
{
    /// <summary>
    /// A request parameter that failed validation and its error messages.
    /// </summary>
    public sealed record SeamValidationError(
        string ParameterName,
        IReadOnlyList<string> ErrorMessages
    );

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
        /// Validation errors, one entry per failed request parameter.
        /// </summary>
        public IReadOnlyList<SeamValidationError> ValidationErrors
        {
            get
            {
                if (_validationErrors is not { ValueKind: JsonValueKind.Object } validationErrors)
                    return Array.Empty<SeamValidationError>();

                var errors = new List<SeamValidationError>();
                foreach (var parameter in validationErrors.EnumerateObject())
                {
                    if (parameter.Name != "_errors")
                    {
                        errors.Add(
                            new SeamValidationError(
                                parameter.Name,
                                GetValidationErrorMessages(parameter.Name)
                            )
                        );
                    }
                }

                return errors;
            }
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
