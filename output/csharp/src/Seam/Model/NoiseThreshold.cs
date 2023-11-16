using System.Runtime.Serialization;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using JsonSubTypes;

namespace Seam.Model
{
    [DataContract(Name = "seamModel_noiseThreshold_model")]
    public class NoiseThreshold
    {
        [JsonConstructorAttribute]
        protected NoiseThreshold() { }

        public NoiseThreshold(
            string noiseThresholdId = default,
            string deviceId = default,
            string name = default,
            float? noiseThresholdNrs = default,
            string startsDailyAt = default,
            string endsDailyAt = default,
            float noiseThresholdDecibels = default
        )
        {
            NoiseThresholdId = noiseThresholdId;
            DeviceId = deviceId;
            Name = name;
            NoiseThresholdNrs = noiseThresholdNrs;
            StartsDailyAt = startsDailyAt;
            EndsDailyAt = endsDailyAt;
            NoiseThresholdDecibels = noiseThresholdDecibels;
        }

        [DataMember(Name = "noise_threshold_id", IsRequired = true, EmitDefaultValue = false)]
        public string NoiseThresholdId { get; set; }

        [DataMember(Name = "device_id", IsRequired = true, EmitDefaultValue = false)]
        public string DeviceId { get; set; }

        [DataMember(Name = "name", IsRequired = true, EmitDefaultValue = false)]
        public string Name { get; set; }

        [DataMember(Name = "noise_threshold_nrs", IsRequired = false, EmitDefaultValue = false)]
        public float? NoiseThresholdNrs { get; set; }

        [DataMember(Name = "starts_daily_at", IsRequired = true, EmitDefaultValue = false)]
        public string StartsDailyAt { get; set; }

        [DataMember(Name = "ends_daily_at", IsRequired = true, EmitDefaultValue = false)]
        public string EndsDailyAt { get; set; }

        [DataMember(Name = "noise_threshold_decibels", IsRequired = true, EmitDefaultValue = false)]
        public float NoiseThresholdDecibels { get; set; }

        public override string ToString()
        {
            JsonSerializer jsonSerializer = JsonSerializer.CreateDefault(null);

            StringWriter stringWriter = new StringWriter(
                new StringBuilder(256),
                System.Globalization.CultureInfo.InvariantCulture
            );
            using (JsonTextWriter jsonTextWriter = new JsonTextWriter(stringWriter))
            {
                jsonTextWriter.IndentChar = ' ';
                jsonTextWriter.Indentation = 2;
                jsonTextWriter.Formatting = Formatting.Indented;
                jsonSerializer.Serialize(jsonTextWriter, this, null);
            }

            return stringWriter.ToString();
        }
    }
}
