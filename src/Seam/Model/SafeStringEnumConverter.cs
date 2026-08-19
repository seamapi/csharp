using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Seam.Model
{
    public class SafeStringEnumConverter : StringEnumConverter
    {
        public override object ReadJson(
            JsonReader reader,
            Type objectType,
            object existingValue,
            JsonSerializer serializer
        )
        {
            try
            {
                return base.ReadJson(reader, objectType, existingValue, serializer);
            }
            catch (JsonSerializationException)
            {
                // If the enum value can't be parsed, return the first enum value (0)
                // which should be "Unrecognized" in our enums
                return Activator.CreateInstance(objectType);
            }
        }
    }
}
