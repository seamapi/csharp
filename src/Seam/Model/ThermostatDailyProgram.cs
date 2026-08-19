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
    /// Represents a thermostat daily program, consisting of a set of periods, each of which has a starting time and the key that identifies the climate preset to apply at the starting time.
    /// </summary>
    [DataContract(Name = "seamModel_thermostatDailyProgram_model")]
    public class ThermostatDailyProgram
    {
        [JsonConstructorAttribute]
        protected ThermostatDailyProgram() { }

        public ThermostatDailyProgram(
            string createdAt = default,
            string deviceId = default,
            string? name = default,
            List<ThermostatDailyProgramPeriods> periods = default,
            string thermostatDailyProgramId = default,
            string workspaceId = default
        )
        {
            CreatedAt = createdAt;
            DeviceId = deviceId;
            Name = name;
            Periods = periods;
            ThermostatDailyProgramId = thermostatDailyProgramId;
            WorkspaceId = workspaceId;
        }

        /// <summary>
        /// Date and time at which the thermostat daily program was created.
        /// </summary>
        [DataMember(Name = "created_at", IsRequired = false, EmitDefaultValue = false)]
        public string CreatedAt { get; set; }

        /// <summary>
        /// ID of the thermostat device on which the thermostat daily program is configured.
        /// </summary>
        [DataMember(Name = "device_id", IsRequired = false, EmitDefaultValue = false)]
        public string DeviceId { get; set; }

        /// <summary>
        /// User-friendly name to identify the thermostat daily program.
        /// </summary>
        [DataMember(Name = "name", IsRequired = false, EmitDefaultValue = false)]
        public string? Name { get; set; }

        /// <summary>
        /// Array of thermostat daily program periods.
        /// </summary>
        [DataMember(Name = "periods", IsRequired = false, EmitDefaultValue = false)]
        public List<ThermostatDailyProgramPeriods> Periods { get; set; }

        /// <summary>
        /// ID of the thermostat daily program.
        /// </summary>
        [DataMember(
            Name = "thermostat_daily_program_id",
            IsRequired = false,
            EmitDefaultValue = false
        )]
        public string ThermostatDailyProgramId { get; set; }

        /// <summary>
        /// ID of the workspace that contains the thermostat daily program.
        /// </summary>
        [DataMember(Name = "workspace_id", IsRequired = false, EmitDefaultValue = false)]
        public string WorkspaceId { get; set; }

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

    [DataContract(Name = "seamModel_thermostatDailyProgramPeriods_model")]
    public class ThermostatDailyProgramPeriods
    {
        [JsonConstructorAttribute]
        protected ThermostatDailyProgramPeriods() { }

        public ThermostatDailyProgramPeriods(
            string climatePresetKey = default,
            string startsAtTime = default
        )
        {
            ClimatePresetKey = climatePresetKey;
            StartsAtTime = startsAtTime;
        }

        /// <summary>
        /// Key of the [climate preset](https://docs.seam.co/capability-guides/thermostats/creating-and-managing-climate-presets) to activate at the `starts_at_time`.
        /// </summary>
        [DataMember(Name = "climate_preset_key", IsRequired = false, EmitDefaultValue = false)]
        public string ClimatePresetKey { get; set; }

        /// <summary>
        /// Time at which the thermostat daily program period starts, in [ISO 8601](https://www.iso.org/iso-8601-date-and-time-format.html) format.
        /// </summary>
        [DataMember(Name = "starts_at_time", IsRequired = false, EmitDefaultValue = false)]
        public string StartsAtTime { get; set; }

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
