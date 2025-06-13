using System.Runtime.Serialization;
using System.Text;
using JsonSubTypes;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using Seam.Model;

namespace Seam.Model
{
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

        [DataMember(Name = "created_at", IsRequired = true, EmitDefaultValue = false)]
        public string CreatedAt { get; set; }

        [DataMember(Name = "device_id", IsRequired = true, EmitDefaultValue = false)]
        public string DeviceId { get; set; }

        [DataMember(Name = "name", IsRequired = false, EmitDefaultValue = false)]
        public string? Name { get; set; }

        [DataMember(Name = "periods", IsRequired = true, EmitDefaultValue = false)]
        public List<ThermostatDailyProgramPeriods> Periods { get; set; }

        [DataMember(
            Name = "thermostat_daily_program_id",
            IsRequired = true,
            EmitDefaultValue = false
        )]
        public string ThermostatDailyProgramId { get; set; }

        [DataMember(Name = "workspace_id", IsRequired = true, EmitDefaultValue = false)]
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

        [DataMember(Name = "climate_preset_key", IsRequired = true, EmitDefaultValue = false)]
        public string ClimatePresetKey { get; set; }

        [DataMember(Name = "starts_at_time", IsRequired = true, EmitDefaultValue = false)]
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
