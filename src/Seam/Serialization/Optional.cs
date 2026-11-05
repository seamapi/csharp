using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Seam
{
    /// <summary>
    /// A request parameter that distinguishes being omitted, set to a value, and explicitly set
    /// to null.
    /// </summary>
    /// <remarks>
    /// <para>
    /// Used for the nullable parameters of update requests, where an omitted parameter leaves
    /// the current value unchanged and a null parameter unsets it. A value assigns implicitly,
    /// and an explicit null is always spelled <see cref="Null.Value"/>:
    /// </para>
    /// <code>
    /// new ThermostatsUpdateRequest { HvacModeSetting = "heat" }   // set a value
    /// new ThermostatsUpdateRequest { HvacModeSetting = Null.Value } // unset the value
    /// new ThermostatsUpdateRequest { }                            // leave it unchanged
    /// </code>
    /// </remarks>
    /// <summary>
    /// The non-generic view of <see cref="Optional{T}"/> used to omit unset parameters from the
    /// JSON contract.
    /// </summary>
    internal interface IOptional
    {
        bool IsSet { get; }
    }

    public readonly struct Optional<T> : IOptional
    {
        private readonly T? _value;

        private Optional(bool isSet, bool isNull, T? value)
        {
            IsSet = isSet;
            IsNull = isNull;
            _value = value;
        }

        /// <summary>An omitted parameter. This is the default.</summary>
        public static Optional<T> Unset => default;

        /// <summary>A parameter explicitly set to null.</summary>
        public static Optional<T> Null => new(true, true, default);

        public static Optional<T> Of(T value) => new(true, false, value);

        /// <summary>Whether the parameter was given at all, as a value or as null.</summary>
        public bool IsSet { get; }

        /// <summary>Whether the parameter was explicitly set to null.</summary>
        public bool IsNull { get; }

        /// <summary>
        /// The parameter value.
        /// </summary>
        /// <exception cref="InvalidOperationException">
        /// If the parameter is unset or explicitly null.
        /// </exception>
        public T Value =>
            IsSet && !IsNull
                ? _value!
                : throw new InvalidOperationException(
                    IsSet
                        ? "The parameter is explicitly null and has no value."
                        : "The parameter is unset and has no value."
                );

        public static implicit operator Optional<T>(T value) => Of(value);

        public static implicit operator Optional<T>(Null _) => Null;

        public override string ToString() =>
            !IsSet ? "unset"
            : IsNull ? "null"
            : _value?.ToString() ?? "";
    }

    /// <summary>
    /// Serializes <see cref="Optional{T}"/>: a value as itself and an explicit null as JSON
    /// null. An unset parameter is omitted from the JSON contract entirely by
    /// <see cref="SeamJson"/>, which never asks this converter to write one.
    /// </summary>
    internal sealed class OptionalJsonConverterFactory : JsonConverterFactory
    {
        public override bool CanConvert(Type typeToConvert) =>
            typeToConvert.IsGenericType
            && typeToConvert.GetGenericTypeDefinition() == typeof(Optional<>);

        public override JsonConverter CreateConverter(
            Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            var valueType = typeToConvert.GetGenericArguments()[0];
            var converterType = typeof(OptionalJsonConverter<>).MakeGenericType(valueType);

            return (JsonConverter)Activator.CreateInstance(converterType)!;
        }
    }

    internal sealed class OptionalJsonConverter<T> : JsonConverter<Optional<T>>
    {
        public override Optional<T> Read(
            ref Utf8JsonReader reader,
            Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            if (reader.TokenType == JsonTokenType.Null)
                return Optional<T>.Null;

            return Optional<T>.Of(JsonSerializer.Deserialize<T>(ref reader, options)!);
        }

        public override void Write(
            Utf8JsonWriter writer,
            Optional<T> value,
            JsonSerializerOptions options
        )
        {
            if (!value.IsSet || value.IsNull)
            {
                writer.WriteNullValue();
                return;
            }

            JsonSerializer.Serialize(writer, value.Value, options);
        }

        // An explicit null must be written, not dropped by the
        // ignore-nulls-when-writing default.
        public override bool HandleNull => true;
    }
}
