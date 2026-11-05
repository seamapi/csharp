using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Reflection;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Seam
{
    /// <summary>
    /// Declares the discriminator property of a generated discriminated union base class.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, Inherited = false)]
    public sealed class SeamUnionAttribute : Attribute
    {
        public SeamUnionAttribute(string discriminator)
        {
            Discriminator = discriminator;
        }

        /// <summary>The wire name of the discriminator property, e.g. <c>action_type</c>.</summary>
        public string Discriminator { get; }
    }

    /// <summary>
    /// Maps one discriminator value of a generated discriminated union to its variant class.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true, Inherited = false)]
    public sealed class SeamUnionVariantAttribute : Attribute
    {
        public SeamUnionVariantAttribute(string discriminatorValue, Type variantType)
        {
            DiscriminatorValue = discriminatorValue;
            VariantType = variantType;
        }

        public string DiscriminatorValue { get; }

        public Type VariantType { get; }
    }

    /// <summary>
    /// Names the fallback variant a generated discriminated union deserializes to when the
    /// discriminator value is not recognized.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, Inherited = false)]
    public sealed class SeamUnionFallbackAttribute : Attribute
    {
        public SeamUnionFallbackAttribute(Type fallbackType)
        {
            FallbackType = fallbackType;
        }

        public Type FallbackType { get; }
    }

    /// <summary>
    /// Implemented by the generated <c>…Unrecognized</c> fallback variants so the raw payload of
    /// an unknown union member is preserved rather than discarded.
    /// </summary>
    public interface ISeamUnrecognizedVariant
    {
        /// <summary>The complete raw JSON of the unrecognized union member.</summary>
        JsonElement RawJson { get; set; }
    }

    /// <summary>
    /// Serializes the generated discriminated unions: reading dispatches on the discriminator
    /// property declared by <see cref="SeamUnionAttribute"/>, falling back to the
    /// <see cref="SeamUnionFallbackAttribute"/> variant (which keeps the raw JSON) for a
    /// discriminator value the SDK does not know yet; writing serializes the runtime type.
    /// </summary>
    public sealed class SeamUnionConverter : JsonConverterFactory
    {
        public override bool CanConvert(Type typeToConvert) =>
            typeToConvert.GetCustomAttribute<SeamUnionAttribute>() != null;

        public override JsonConverter CreateConverter(
            Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            var converterType = typeof(SeamUnionConverter<>).MakeGenericType(typeToConvert);

            return (JsonConverter)Activator.CreateInstance(converterType)!;
        }
    }

    internal sealed class SeamUnionConverter<TBase> : JsonConverter<TBase>
        where TBase : class
    {
        private static readonly string Discriminator = typeof(TBase)
            .GetCustomAttribute<SeamUnionAttribute>()!
            .Discriminator;

        private static readonly ConcurrentDictionary<string, Type> VariantsByDiscriminatorValue =
            BuildVariants();

        private static readonly Type? FallbackType = typeof(TBase)
            .GetCustomAttribute<SeamUnionFallbackAttribute>()
            ?.FallbackType;

        public override TBase? Read(
            ref Utf8JsonReader reader,
            Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            using var document = JsonDocument.ParseValue(ref reader);
            var element = document.RootElement.Clone();

            string? discriminatorValue = null;
            if (
                element.ValueKind == JsonValueKind.Object
                && element.TryGetProperty(Discriminator, out var property)
                && property.ValueKind == JsonValueKind.String
            )
            {
                discriminatorValue = property.GetString();
            }

            if (
                discriminatorValue != null
                && VariantsByDiscriminatorValue.TryGetValue(discriminatorValue, out var variantType)
            )
            {
                return (TBase?)element.Deserialize(variantType, options);
            }

            if (FallbackType == null)
                throw new JsonException(
                    $"Unrecognized {typeof(TBase).Name} {Discriminator} \"{discriminatorValue}\" "
                        + "and the union declares no fallback variant."
                );

            var fallback = (TBase?)element.Deserialize(FallbackType, options);

            if (fallback is ISeamUnrecognizedVariant unrecognized)
                unrecognized.RawJson = element;

            return fallback;
        }

        public override void Write(
            Utf8JsonWriter writer,
            TBase value,
            JsonSerializerOptions options
        )
        {
            JsonSerializer.Serialize(writer, value, value.GetType(), options);
        }

        private static ConcurrentDictionary<string, Type> BuildVariants()
        {
            var variants = new ConcurrentDictionary<string, Type>(StringComparer.Ordinal);

            foreach (
                var attribute in typeof(TBase).GetCustomAttributes<SeamUnionVariantAttribute>()
            )
            {
                variants[attribute.DiscriminatorValue] = attribute.VariantType;
            }

            return variants;
        }
    }
}
