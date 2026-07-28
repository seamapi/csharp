using System.Runtime.Serialization;
using System.Text;
using JsonSubTypes;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using Seam.Model;

namespace Seam.Model
{
    /// <summary>
    /// Represents a [noise threshold](https://docs.seam.co/capability-guides/noise-sensors/configure-noise-threshold-settings) for a [noise sensor](https://docs.seam.co/capability-guides/noise-sensors). Thresholds represent the limits of noise tolerated at a property, which can be customized for each hour of the day. Each device has its own default thresholds, but you can use the Seam API to modify them.
    /// </summary>
    [DataContract(Name = "seamModel_noiseThreshold_model")]
    public class NoiseThreshold
    {
        [JsonConstructorAttribute]
        protected NoiseThreshold() { }

        public NoiseThreshold(
            string deviceId = default,
            string endsDailyAt = default,
            string name = default,
            float noiseThresholdDecibels = default,
            string noiseThresholdId = default,
            float? noiseThresholdNrs = default,
            string startsDailyAt = default
        )
        {
            DeviceId = deviceId;
            EndsDailyAt = endsDailyAt;
            Name = name;
            NoiseThresholdDecibels = noiseThresholdDecibels;
            NoiseThresholdId = noiseThresholdId;
            NoiseThresholdNrs = noiseThresholdNrs;
            StartsDailyAt = startsDailyAt;
        }

        /// <summary>
        /// Unique identifier for the device that contains the noise threshold.
        /// </summary>
        [DataMember(Name = "device_id", IsRequired = false, EmitDefaultValue = false)]
        public string DeviceId { get; set; }

        /// <summary>
        /// Time at which the noise threshold should become inactive daily.
        /// </summary>
        [DataMember(Name = "ends_daily_at", IsRequired = false, EmitDefaultValue = false)]
        public string EndsDailyAt { get; set; }

        /// <summary>
        /// Name of the noise threshold.
        /// </summary>
        [DataMember(Name = "name", IsRequired = false, EmitDefaultValue = false)]
        public string Name { get; set; }

        /// <summary>
        /// Noise level in decibels for the noise threshold.
        /// </summary>
        [DataMember(
            Name = "noise_threshold_decibels",
            IsRequired = false,
            EmitDefaultValue = false
        )]
        public float NoiseThresholdDecibels { get; set; }

        /// <summary>
        /// Unique identifier for the noise threshold.
        /// </summary>
        [DataMember(Name = "noise_threshold_id", IsRequired = false, EmitDefaultValue = false)]
        public string NoiseThresholdId { get; set; }

        /// <summary>
        /// Noise level in Noiseaware Noise Risk Score (NRS) for the noise threshold. This parameter is only relevant for [Noiseaware sensors](https://docs.seam.co/device-and-system-integration-guides/noiseaware-sensors).
        /// </summary>
        [DataMember(Name = "noise_threshold_nrs", IsRequired = false, EmitDefaultValue = false)]
        public float? NoiseThresholdNrs { get; set; }

        /// <summary>
        /// Time at which the noise threshold should become active daily.
        /// </summary>
        [DataMember(Name = "starts_daily_at", IsRequired = false, EmitDefaultValue = false)]
        public string StartsDailyAt { get; set; }

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
