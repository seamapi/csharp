using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Seam
{
    /// <summary>
    /// Serializes the generated string enums by their <see cref="EnumMemberAttribute"/> wire
    /// values, mapping an unknown wire value to the <c>Unrecognized</c> member.
    /// </summary>
    /// <remarks>
    /// The Seam API adds enum values over time, so a wire value the SDK does not know yet must
    /// deserialize rather than throw. Every generated enum declares <c>Unrecognized = 0</c> for
    /// this; the raw wire value of an unrecognized member is not preserved.
    /// </remarks>
    public sealed class SeamStringEnumConverter : JsonConverterFactory
    {
        public override bool CanConvert(Type typeToConvert) => typeToConvert.IsEnum;

        public override JsonConverter CreateConverter(
            Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            var converterType = typeof(SeamStringEnumConverter<>).MakeGenericType(typeToConvert);

            return (JsonConverter)Activator.CreateInstance(converterType)!;
        }
    }

    internal sealed class SeamStringEnumConverter<TEnum> : JsonConverter<TEnum>
        where TEnum : struct, Enum
    {
        private static readonly ConcurrentDictionary<string, TEnum> MembersByWireValue = Build();

        private static readonly Dictionary<TEnum, string> WireValuesByMember = BuildReverse();

        public override TEnum Read(
            ref Utf8JsonReader reader,
            Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            var wireValue = reader.GetString();

            if (wireValue != null && MembersByWireValue.TryGetValue(wireValue, out var member))
                return member;

            return default;
        }

        public override void Write(
            Utf8JsonWriter writer,
            TEnum value,
            JsonSerializerOptions options
        )
        {
            if (!WireValuesByMember.TryGetValue(value, out var wireValue))
                throw new JsonException(
                    $"The enum {typeof(TEnum).Name} member {value} has no wire value."
                );

            writer.WriteStringValue(wireValue);
        }

        private static ConcurrentDictionary<string, TEnum> Build()
        {
            var members = new ConcurrentDictionary<string, TEnum>(StringComparer.Ordinal);

            foreach (
                var field in typeof(TEnum).GetFields(BindingFlags.Public | BindingFlags.Static)
            )
            {
                var wireValue =
                    field.GetCustomAttribute<EnumMemberAttribute>()?.Value ?? field.Name;
                members[wireValue] = (TEnum)field.GetValue(null)!;
            }

            return members;
        }

        private static Dictionary<TEnum, string> BuildReverse()
        {
            var wireValues = new Dictionary<TEnum, string>();

            foreach (
                var field in typeof(TEnum).GetFields(BindingFlags.Public | BindingFlags.Static)
            )
            {
                var wireValue =
                    field.GetCustomAttribute<EnumMemberAttribute>()?.Value ?? field.Name;
                wireValues[(TEnum)field.GetValue(null)!] = wireValue;
            }

            return wireValues;
        }
    }
}
