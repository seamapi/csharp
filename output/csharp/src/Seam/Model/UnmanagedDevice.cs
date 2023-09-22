using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using JsonSubTypes;

namespace Seam.Model
{
    [DataContract(Name = "seamModel_unmanagedDevice_model")]
    public class UnmanagedDevice
    {
        [JsonConstructorAttribute]
        protected UnmanagedDevice() { }

        public UnmanagedDevice(
            string deviceId = default,
            UnmanagedDevice.DeviceTypeEnum deviceType = default,
            string connectedAccountId = default,
            List<UnmanagedDevice.CapabilitiesSupportedEnum> capabilitiesSupported = default,
            string workspaceId = default,
            List<UnmanagedDeviceErrors> errors = default,
            List<UnmanagedDeviceWarnings> warnings = default,
            string createdAt = default,
            bool isManaged = default,
            UnmanagedDeviceProperties properties = default
        )
        {
            DeviceId = deviceId;
            DeviceType = deviceType;
            ConnectedAccountId = connectedAccountId;
            CapabilitiesSupported = capabilitiesSupported;
            WorkspaceId = workspaceId;
            Errors = errors;
            Warnings = warnings;
            CreatedAt = createdAt;
            IsManaged = isManaged;
            Properties = properties;
        }

        [JsonConverter(typeof(StringEnumConverter))]
        public enum DeviceTypeEnum
        {
            [EnumMember(Value = "akuvox_lock")]
            AkuvoxLock = 0,

            [EnumMember(Value = "august_lock")]
            AugustLock = 1,

            [EnumMember(Value = "brivo_access_point")]
            BrivoAccessPoint = 2,

            [EnumMember(Value = "butterflymx_panel")]
            ButterflymxPanel = 3,

            [EnumMember(Value = "avigilon_alta_entry")]
            AvigilonAltaEntry = 4,

            [EnumMember(Value = "doorking_lock")]
            DoorkingLock = 5,

            [EnumMember(Value = "genie_door")]
            GenieDoor = 6,

            [EnumMember(Value = "igloo_lock")]
            IglooLock = 7,

            [EnumMember(Value = "linear_lock")]
            LinearLock = 8,

            [EnumMember(Value = "lockly_lock")]
            LocklyLock = 9,

            [EnumMember(Value = "kwikset_lock")]
            KwiksetLock = 10,

            [EnumMember(Value = "nuki_lock")]
            NukiLock = 11,

            [EnumMember(Value = "salto_lock")]
            SaltoLock = 12,

            [EnumMember(Value = "schlage_lock")]
            SchlageLock = 13,

            [EnumMember(Value = "seam_relay")]
            SeamRelay = 14,

            [EnumMember(Value = "smartthings_lock")]
            SmartthingsLock = 15,

            [EnumMember(Value = "wyze_lock")]
            WyzeLock = 16,

            [EnumMember(Value = "yale_lock")]
            YaleLock = 17,

            [EnumMember(Value = "two_n_intercom")]
            TwoNIntercom = 18,

            [EnumMember(Value = "controlbyweb_device")]
            ControlbywebDevice = 19,

            [EnumMember(Value = "ttlock_lock")]
            TtlockLock = 20,

            [EnumMember(Value = "igloohome_lock")]
            IgloohomeLock = 21,

            [EnumMember(Value = "hubitat_lock")]
            HubitatLock = 22,

            [EnumMember(Value = "four_suites_door")]
            FourSuitesDoor = 23,

            [EnumMember(Value = "dormakaba_oracode_door")]
            DormakabaOracodeDoor = 24,

            [EnumMember(Value = "noiseaware_activity_zone")]
            NoiseawareActivityZone = 25,

            [EnumMember(Value = "minut_sensor")]
            MinutSensor = 26,

            [EnumMember(Value = "ecobee_thermostat")]
            EcobeeThermostat = 27,

            [EnumMember(Value = "nest_thermostat")]
            NestThermostat = 28
        }

        [JsonConverter(typeof(StringEnumConverter))]
        public enum CapabilitiesSupportedEnum
        {
            [EnumMember(Value = "access_code")]
            AccessCode = 0,

            [EnumMember(Value = "lock")]
            Lock = 1,

            [EnumMember(Value = "noise_detection")]
            NoiseDetection = 2,

            [EnumMember(Value = "thermostat")]
            Thermostat = 3,

            [EnumMember(Value = "battery")]
            Battery = 4
        }

        [DataMember(Name = "device_id", IsRequired = true, EmitDefaultValue = false)]
        public string DeviceId { get; set; }

        [DataMember(Name = "device_type", IsRequired = true, EmitDefaultValue = false)]
        public UnmanagedDevice.DeviceTypeEnum DeviceType { get; set; }

        [DataMember(Name = "connected_account_id", IsRequired = true, EmitDefaultValue = false)]
        public string ConnectedAccountId { get; set; }

        [DataMember(Name = "capabilities_supported", IsRequired = true, EmitDefaultValue = false)]
        public List<UnmanagedDevice.CapabilitiesSupportedEnum> CapabilitiesSupported { get; set; }

        [DataMember(Name = "workspace_id", IsRequired = true, EmitDefaultValue = false)]
        public string WorkspaceId { get; set; }

        [DataMember(Name = "errors", IsRequired = true, EmitDefaultValue = false)]
        public List<UnmanagedDeviceErrors> Errors { get; set; }

        [DataMember(Name = "warnings", IsRequired = true, EmitDefaultValue = false)]
        public List<UnmanagedDeviceWarnings> Warnings { get; set; }

        [DataMember(Name = "created_at", IsRequired = true, EmitDefaultValue = false)]
        public string CreatedAt { get; set; }

        [DataMember(Name = "is_managed", IsRequired = true, EmitDefaultValue = false)]
        public bool IsManaged { get; set; }

        [DataMember(Name = "properties", IsRequired = true, EmitDefaultValue = false)]
        public UnmanagedDeviceProperties Properties { get; set; }
    }

    [DataContract(Name = "seamModel_unmanagedDeviceErrors_model")]
    public class UnmanagedDeviceErrors
    {
        [JsonConstructorAttribute]
        protected UnmanagedDeviceErrors() { }

        public UnmanagedDeviceErrors(string errorCode = default, string message = default)
        {
            ErrorCode = errorCode;
            Message = message;
        }

        [DataMember(Name = "error_code", IsRequired = true, EmitDefaultValue = false)]
        public string ErrorCode { get; set; }

        [DataMember(Name = "message", IsRequired = true, EmitDefaultValue = false)]
        public string Message { get; set; }
    }

    [DataContract(Name = "seamModel_unmanagedDeviceWarnings_model")]
    public class UnmanagedDeviceWarnings
    {
        [JsonConstructorAttribute]
        protected UnmanagedDeviceWarnings() { }

        public UnmanagedDeviceWarnings(string warningCode = default, string message = default)
        {
            WarningCode = warningCode;
            Message = message;
        }

        [DataMember(Name = "warning_code", IsRequired = true, EmitDefaultValue = false)]
        public string WarningCode { get; set; }

        [DataMember(Name = "message", IsRequired = true, EmitDefaultValue = false)]
        public string Message { get; set; }
    }

    [DataContract(Name = "seamModel_unmanagedDeviceProperties_model")]
    public class UnmanagedDeviceProperties
    {
        [JsonConstructorAttribute]
        protected UnmanagedDeviceProperties() { }

        public UnmanagedDeviceProperties(
            string name = default,
            bool online = default,
            string? manufacturer = default,
            string? imageUrl = default,
            string? imageAltText = default,
            UnmanagedDevicePropertiesModel model = default
        )
        {
            Name = name;
            Online = online;
            Manufacturer = manufacturer;
            ImageUrl = imageUrl;
            ImageAltText = imageAltText;
            Model = model;
        }

        [DataMember(Name = "name", IsRequired = true, EmitDefaultValue = false)]
        public string Name { get; set; }

        [DataMember(Name = "online", IsRequired = true, EmitDefaultValue = false)]
        public bool Online { get; set; }

        [DataMember(Name = "manufacturer", IsRequired = false, EmitDefaultValue = false)]
        public string? Manufacturer { get; set; }

        [DataMember(Name = "image_url", IsRequired = false, EmitDefaultValue = false)]
        public string? ImageUrl { get; set; }

        [DataMember(Name = "image_alt_text", IsRequired = false, EmitDefaultValue = false)]
        public string? ImageAltText { get; set; }

        [DataMember(Name = "model", IsRequired = true, EmitDefaultValue = false)]
        public UnmanagedDevicePropertiesModel Model { get; set; }
    }

    [DataContract(Name = "seamModel_unmanagedDevicePropertiesModel_model")]
    public class UnmanagedDevicePropertiesModel
    {
        [JsonConstructorAttribute]
        protected UnmanagedDevicePropertiesModel() { }

        public UnmanagedDevicePropertiesModel(
            string displayName = default,
            string manufacturerDisplayName = default
        )
        {
            DisplayName = displayName;
            ManufacturerDisplayName = manufacturerDisplayName;
        }

        [DataMember(Name = "display_name", IsRequired = true, EmitDefaultValue = false)]
        public string DisplayName { get; set; }

        [DataMember(
            Name = "manufacturer_display_name",
            IsRequired = true,
            EmitDefaultValue = false
        )]
        public string ManufacturerDisplayName { get; set; }
    }
}
