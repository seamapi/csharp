using System.Runtime.Serialization;
using System.Text;
using JsonSubTypes;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;

namespace Seam.Model
{
    [DataContract(Name = "seamModel_event_model")]
    public class Event
    {
        [JsonConstructorAttribute]
        protected Event() { }

        public Event(
            string? acsCredentialId = default,
            string? acsSystemId = default,
            string? acsUserId = default,
            string? actionAttemptId = default,
            string? clientSessionId = default,
            string? climatePresetKey = default,
            float? coolingSetPointCelsius = default,
            float? coolingSetPointFahrenheit = default,
            string createdAt = default,
            string? deviceId = default,
            string? enrollmentAutomationId = default,
            string eventDescription = default,
            string eventId = default,
            string eventType = default,
            string? fanModeSetting = default,
            float? heatingSetPointCelsius = default,
            float? heatingSetPointFahrenheit = default,
            string? hvacModeSetting = default,
            bool? isFallbackClimatePreset = default,
            string? method = default,
            string occurredAt = default,
            string? thermostatScheduleId = default,
            string workspaceId = default
        )
        {
            AcsCredentialId = acsCredentialId;
            AcsSystemId = acsSystemId;
            AcsUserId = acsUserId;
            ActionAttemptId = actionAttemptId;
            ClientSessionId = clientSessionId;
            ClimatePresetKey = climatePresetKey;
            CoolingSetPointCelsius = coolingSetPointCelsius;
            CoolingSetPointFahrenheit = coolingSetPointFahrenheit;
            CreatedAt = createdAt;
            DeviceId = deviceId;
            EnrollmentAutomationId = enrollmentAutomationId;
            EventDescription = eventDescription;
            EventId = eventId;
            EventType = eventType;
            FanModeSetting = fanModeSetting;
            HeatingSetPointCelsius = heatingSetPointCelsius;
            HeatingSetPointFahrenheit = heatingSetPointFahrenheit;
            HvacModeSetting = hvacModeSetting;
            IsFallbackClimatePreset = isFallbackClimatePreset;
            Method = method;
            OccurredAt = occurredAt;
            ThermostatScheduleId = thermostatScheduleId;
            WorkspaceId = workspaceId;
        }

        [DataMember(Name = "acs_credential_id", IsRequired = false, EmitDefaultValue = false)]
        public string? AcsCredentialId { get; set; }

        [DataMember(Name = "acs_system_id", IsRequired = false, EmitDefaultValue = false)]
        public string? AcsSystemId { get; set; }

        [DataMember(Name = "acs_user_id", IsRequired = false, EmitDefaultValue = false)]
        public string? AcsUserId { get; set; }

        [DataMember(Name = "action_attempt_id", IsRequired = false, EmitDefaultValue = false)]
        public string? ActionAttemptId { get; set; }

        [DataMember(Name = "client_session_id", IsRequired = false, EmitDefaultValue = false)]
        public string? ClientSessionId { get; set; }

        [DataMember(Name = "climate_preset_key", IsRequired = false, EmitDefaultValue = false)]
        public string? ClimatePresetKey { get; set; }

        [DataMember(
            Name = "cooling_set_point_celsius",
            IsRequired = false,
            EmitDefaultValue = false
        )]
        public float? CoolingSetPointCelsius { get; set; }

        [DataMember(
            Name = "cooling_set_point_fahrenheit",
            IsRequired = false,
            EmitDefaultValue = false
        )]
        public float? CoolingSetPointFahrenheit { get; set; }

        [DataMember(Name = "created_at", IsRequired = true, EmitDefaultValue = false)]
        public string CreatedAt { get; set; }

        [DataMember(Name = "device_id", IsRequired = false, EmitDefaultValue = false)]
        public string? DeviceId { get; set; }

        [DataMember(
            Name = "enrollment_automation_id",
            IsRequired = false,
            EmitDefaultValue = false
        )]
        public string? EnrollmentAutomationId { get; set; }

        [DataMember(Name = "event_description", IsRequired = true, EmitDefaultValue = false)]
        public string EventDescription { get; set; }

        [DataMember(Name = "event_id", IsRequired = true, EmitDefaultValue = false)]
        public string EventId { get; set; }

        [DataMember(Name = "event_type", IsRequired = true, EmitDefaultValue = false)]
        public string EventType { get; set; }

        [DataMember(Name = "fan_mode_setting", IsRequired = false, EmitDefaultValue = false)]
        public string? FanModeSetting { get; set; }

        [DataMember(
            Name = "heating_set_point_celsius",
            IsRequired = false,
            EmitDefaultValue = false
        )]
        public float? HeatingSetPointCelsius { get; set; }

        [DataMember(
            Name = "heating_set_point_fahrenheit",
            IsRequired = false,
            EmitDefaultValue = false
        )]
        public float? HeatingSetPointFahrenheit { get; set; }

        [DataMember(Name = "hvac_mode_setting", IsRequired = false, EmitDefaultValue = false)]
        public string? HvacModeSetting { get; set; }

        [DataMember(
            Name = "is_fallback_climate_preset",
            IsRequired = false,
            EmitDefaultValue = false
        )]
        public bool? IsFallbackClimatePreset { get; set; }

        [DataMember(Name = "method", IsRequired = false, EmitDefaultValue = false)]
        public string? Method { get; set; }

        [DataMember(Name = "occurred_at", IsRequired = true, EmitDefaultValue = false)]
        public string OccurredAt { get; set; }

        [DataMember(Name = "thermostat_schedule_id", IsRequired = false, EmitDefaultValue = false)]
        public string? ThermostatScheduleId { get; set; }

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
}
