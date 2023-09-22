using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using JsonSubTypes;

namespace Seam.Model
{
    [DataContract(Name = "seamModel_climateSettingSchedule_model")]
    public class ClimateSettingSchedule
    {
        [JsonConstructorAttribute]
        protected ClimateSettingSchedule() { }

        public ClimateSettingSchedule(
            string climateSettingScheduleId = default,
            ClimateSettingSchedule.ScheduleTypeEnum scheduleType = default,
            string deviceId = default,
            string? name = default,
            string scheduleStartsAt = default,
            string scheduleEndsAt = default,
            string createdAt = default,
            bool? automaticHeatingEnabled = default,
            bool? automaticCoolingEnabled = default,
            ClimateSettingSchedule.HvacModeSettingEnum? hvacModeSetting = default,
            float coolingSetPointCelsius = default,
            float heatingSetPointCelsius = default,
            float coolingSetPointFahrenheit = default,
            float heatingSetPointFahrenheit = default,
            bool? manualOverrideAllowed = default
        )
        {
            ClimateSettingScheduleId = climateSettingScheduleId;
            ScheduleType = scheduleType;
            DeviceId = deviceId;
            Name = name;
            ScheduleStartsAt = scheduleStartsAt;
            ScheduleEndsAt = scheduleEndsAt;
            CreatedAt = createdAt;
            AutomaticHeatingEnabled = automaticHeatingEnabled;
            AutomaticCoolingEnabled = automaticCoolingEnabled;
            HvacModeSetting = hvacModeSetting;
            CoolingSetPointCelsius = coolingSetPointCelsius;
            HeatingSetPointCelsius = heatingSetPointCelsius;
            CoolingSetPointFahrenheit = coolingSetPointFahrenheit;
            HeatingSetPointFahrenheit = heatingSetPointFahrenheit;
            ManualOverrideAllowed = manualOverrideAllowed;
        }

        [JsonConverter(typeof(StringEnumConverter))]
        public enum ScheduleTypeEnum
        {
            [EnumMember(Value = "time_bound")]
            TimeBound = 0
        }

        [JsonConverter(typeof(StringEnumConverter))]
        public enum HvacModeSettingEnum
        {
            [EnumMember(Value = "off")]
            Off = 0,

            [EnumMember(Value = "heat")]
            Heat = 1,

            [EnumMember(Value = "cool")]
            Cool = 2,

            [EnumMember(Value = "heat_cool")]
            HeatCool = 3
        }

        [DataMember(
            Name = "climate_setting_schedule_id",
            IsRequired = true,
            EmitDefaultValue = false
        )]
        public string ClimateSettingScheduleId { get; set; }

        [DataMember(Name = "schedule_type", IsRequired = true, EmitDefaultValue = false)]
        public ClimateSettingSchedule.ScheduleTypeEnum ScheduleType { get; set; }

        [DataMember(Name = "device_id", IsRequired = true, EmitDefaultValue = false)]
        public string DeviceId { get; set; }

        [DataMember(Name = "name", IsRequired = false, EmitDefaultValue = false)]
        public string? Name { get; set; }

        [DataMember(Name = "schedule_starts_at", IsRequired = true, EmitDefaultValue = false)]
        public string ScheduleStartsAt { get; set; }

        [DataMember(Name = "schedule_ends_at", IsRequired = true, EmitDefaultValue = false)]
        public string ScheduleEndsAt { get; set; }

        [DataMember(Name = "created_at", IsRequired = true, EmitDefaultValue = false)]
        public string CreatedAt { get; set; }

        [DataMember(
            Name = "automatic_heating_enabled",
            IsRequired = false,
            EmitDefaultValue = false
        )]
        public bool? AutomaticHeatingEnabled { get; set; }

        [DataMember(
            Name = "automatic_cooling_enabled",
            IsRequired = false,
            EmitDefaultValue = false
        )]
        public bool? AutomaticCoolingEnabled { get; set; }

        [DataMember(Name = "hvac_mode_setting", IsRequired = false, EmitDefaultValue = false)]
        public ClimateSettingSchedule.HvacModeSettingEnum? HvacModeSetting { get; set; }

        [DataMember(
            Name = "cooling_set_point_celsius",
            IsRequired = false,
            EmitDefaultValue = false
        )]
        public float CoolingSetPointCelsius { get; set; }

        [DataMember(
            Name = "heating_set_point_celsius",
            IsRequired = false,
            EmitDefaultValue = false
        )]
        public float HeatingSetPointCelsius { get; set; }

        [DataMember(
            Name = "cooling_set_point_fahrenheit",
            IsRequired = false,
            EmitDefaultValue = false
        )]
        public float CoolingSetPointFahrenheit { get; set; }

        [DataMember(
            Name = "heating_set_point_fahrenheit",
            IsRequired = false,
            EmitDefaultValue = false
        )]
        public float HeatingSetPointFahrenheit { get; set; }

        [DataMember(Name = "manual_override_allowed", IsRequired = false, EmitDefaultValue = false)]
        public bool? ManualOverrideAllowed { get; set; }
    }
}
