using System.Runtime.Serialization;
using System.Text;
using JsonSubTypes;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using Seam.Model;

namespace Seam.Model
{
    [DataContract(Name = "seamModel_thermostatSchedule_model")]
    public class ThermostatSchedule
    {
        [JsonConstructorAttribute]
        protected ThermostatSchedule() { }

        public ThermostatSchedule(
            string climatePresetKey = default,
            string createdAt = default,
            string deviceId = default,
            string endsAt = default,
            List<ThermostatScheduleErrors> errors = default,
            int maxOverridePeriodMinutes = default,
            string? name = default,
            string startsAt = default,
            string thermostatScheduleId = default,
            bool? unstableIsOverrideAllowed = default
        )
        {
            ClimatePresetKey = climatePresetKey;
            CreatedAt = createdAt;
            DeviceId = deviceId;
            EndsAt = endsAt;
            Errors = errors;
            MaxOverridePeriodMinutes = maxOverridePeriodMinutes;
            Name = name;
            StartsAt = startsAt;
            ThermostatScheduleId = thermostatScheduleId;
            UnstableIsOverrideAllowed = unstableIsOverrideAllowed;
        }

        [DataMember(Name = "climate_preset_key", IsRequired = true, EmitDefaultValue = false)]
        public string ClimatePresetKey { get; set; }

        [DataMember(Name = "created_at", IsRequired = true, EmitDefaultValue = false)]
        public string CreatedAt { get; set; }

        [DataMember(Name = "device_id", IsRequired = true, EmitDefaultValue = false)]
        public string DeviceId { get; set; }

        [DataMember(Name = "ends_at", IsRequired = true, EmitDefaultValue = false)]
        public string EndsAt { get; set; }

        [DataMember(Name = "errors", IsRequired = true, EmitDefaultValue = false)]
        public List<ThermostatScheduleErrors> Errors { get; set; }

        [DataMember(
            Name = "max_override_period_minutes",
            IsRequired = true,
            EmitDefaultValue = false
        )]
        public int MaxOverridePeriodMinutes { get; set; }

        [DataMember(Name = "name", IsRequired = false, EmitDefaultValue = false)]
        public string? Name { get; set; }

        [DataMember(Name = "starts_at", IsRequired = true, EmitDefaultValue = false)]
        public string StartsAt { get; set; }

        [DataMember(Name = "thermostat_schedule_id", IsRequired = true, EmitDefaultValue = false)]
        public string ThermostatScheduleId { get; set; }

        [DataMember(
            Name = "unstable_is_override_allowed",
            IsRequired = false,
            EmitDefaultValue = false
        )]
        public bool? UnstableIsOverrideAllowed { get; set; }

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

    [DataContract(Name = "seamModel_thermostatScheduleErrors_model")]
    public class ThermostatScheduleErrors
    {
        [JsonConstructorAttribute]
        protected ThermostatScheduleErrors() { }

        public ThermostatScheduleErrors(string errorCode = default, string message = default)
        {
            ErrorCode = errorCode;
            Message = message;
        }

        [DataMember(Name = "error_code", IsRequired = true, EmitDefaultValue = false)]
        public string ErrorCode { get; set; }

        [DataMember(Name = "message", IsRequired = true, EmitDefaultValue = false)]
        public string Message { get; set; }

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
