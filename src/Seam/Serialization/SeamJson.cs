using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.Json.Serialization.Metadata;

namespace Seam
{
    /// <summary>
    /// The JSON contract shared by the SDK: request bodies, query parameters, and response
    /// models all serialize through these options.
    /// </summary>
    /// <remarks>
    /// Property names are exact wire names declared by <c>[JsonPropertyName]</c> on the
    /// generated models. A null optional parameter and an unset <see cref="Optional{T}"/> are
    /// omitted, while the <see cref="Null"/> sentinel and an explicitly null
    /// <see cref="Optional{T}"/> serialize to JSON null.
    /// </remarks>
    public static class SeamJson
    {
        public static JsonSerializerOptions Options { get; } = Create();

        private static JsonSerializerOptions Create()
        {
            var options = new JsonSerializerOptions
            {
                DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
                TypeInfoResolver = new DefaultJsonTypeInfoResolver
                {
                    Modifiers = { OmitUnsetOptionals },
                },
            };
            options.Converters.Add(new OptionalJsonConverterFactory());

            return options;
        }

        private static void OmitUnsetOptionals(JsonTypeInfo typeInfo)
        {
            foreach (var property in typeInfo.Properties)
            {
                if (
                    property.PropertyType.IsGenericType
                    && property.PropertyType.GetGenericTypeDefinition() == typeof(Optional<>)
                )
                {
                    property.ShouldSerialize = (_, value) => value is IOptional { IsSet: true };
                }
            }
        }
    }
}
