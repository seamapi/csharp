using System;
using Newtonsoft.Json;

namespace Seam.Client
{
    /// <summary>
    /// The explicit null sentinel used by request parameters.
    /// </summary>
    /// <remarks>
    /// <para>
    /// C# has a single absence value, <c>null</c>, but the Seam API distinguishes an omitted
    /// parameter from a parameter explicitly set to null. In an update request, an omitted
    /// parameter leaves the current value unchanged, while a null parameter unsets it.
    /// </para>
    /// <para>
    /// Since sending null is rarely intended and unsetting a value cannot be undone, <c>null</c>
    /// means the safe option of omitting the parameter. Sending null is explicit and always
    /// spelled <c>Null.Value</c>, which serializes to JSON <c>null</c> in a request body and to
    /// an empty value in a query string.
    /// </para>
    /// <code>
    /// UrlSearchParamsSerializer.Serialize(
    ///     new Dictionary&lt;string, object&gt; { ["name"] = Null.Value, ["limit"] = 20 }
    /// );
    /// // => "limit=20&amp;name="
    /// </code>
    /// </remarks>
    [JsonConverter(typeof(NullJsonConverter))]
    public sealed class Null
    {
        /// <summary>
        /// The sentinel for a parameter explicitly set to null.
        /// </summary>
        public static readonly Null Value = new Null();

        private Null() { }

        public override string ToString()
        {
            return "null";
        }
    }

    /// <summary>
    /// Writes the <see cref="Null"/> sentinel as JSON null.
    /// </summary>
    /// <remarks>
    /// Declared on <see cref="Null"/> itself so the sentinel serializes to null under any
    /// serializer settings, including ones a caller supplies.
    /// </remarks>
    internal class NullJsonConverter : JsonConverter
    {
        public override bool CanRead => false;

        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(Null);
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            writer.WriteNull();
        }

        public override object ReadJson(
            JsonReader reader,
            Type objectType,
            object existingValue,
            JsonSerializer serializer
        )
        {
            throw new NotSupportedException("The Null sentinel cannot be deserialized.");
        }
    }
}
