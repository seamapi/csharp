using System.Runtime.Serialization;
using System.Text;
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
            UnmanagedDeviceProperties properties = default,
            bool? canRemotelyUnlock = default,
            bool? canRemotelyLock = default,
            bool? canProgramOnlineAccessCodes = default
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
            CanRemotelyUnlock = canRemotelyUnlock;
            CanRemotelyLock = canRemotelyLock;
            CanProgramOnlineAccessCodes = canProgramOnlineAccessCodes;
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

            [EnumMember(Value = "tedee_lock")]
            TedeeLock = 25,

            [EnumMember(Value = "noiseaware_activity_zone")]
            NoiseawareActivityZone = 26,

            [EnumMember(Value = "minut_sensor")]
            MinutSensor = 27,

            [EnumMember(Value = "ecobee_thermostat")]
            EcobeeThermostat = 28,

            [EnumMember(Value = "nest_thermostat")]
            NestThermostat = 29,

            [EnumMember(Value = "honeywell_resideo_thermostat")]
            HoneywellResideoThermostat = 30,

            [EnumMember(Value = "ios_phone")]
            IosPhone = 31,

            [EnumMember(Value = "android_phone")]
            AndroidPhone = 32
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
            Battery = 4,

            [EnumMember(Value = "phone")]
            Phone = 5
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

        [DataMember(Name = "can_remotely_unlock", IsRequired = false, EmitDefaultValue = false)]
        public bool? CanRemotelyUnlock { get; set; }

        [DataMember(Name = "can_remotely_lock", IsRequired = false, EmitDefaultValue = false)]
        public bool? CanRemotelyLock { get; set; }

        [DataMember(
            Name = "can_program_online_access_codes",
            IsRequired = false,
            EmitDefaultValue = false
        )]
        public bool? CanProgramOnlineAccessCodes { get; set; }

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
            float? batteryLevel = default,
            UnmanagedDevicePropertiesBattery? battery = default,
            bool? onlineAccessCodesEnabled = default,
            bool? offlineAccessCodesEnabled = default,
            UnmanagedDevicePropertiesModel model = default
        )
        {
            Name = name;
            Online = online;
            Manufacturer = manufacturer;
            ImageUrl = imageUrl;
            ImageAltText = imageAltText;
            BatteryLevel = batteryLevel;
            Battery = battery;
            OnlineAccessCodesEnabled = onlineAccessCodesEnabled;
            OfflineAccessCodesEnabled = offlineAccessCodesEnabled;
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

        [DataMember(Name = "battery_level", IsRequired = false, EmitDefaultValue = false)]
        public float? BatteryLevel { get; set; }

        [DataMember(Name = "battery", IsRequired = false, EmitDefaultValue = false)]
        public UnmanagedDevicePropertiesBattery? Battery { get; set; }

        [DataMember(
            Name = "online_access_codes_enabled",
            IsRequired = false,
            EmitDefaultValue = false
        )]
        public bool? OnlineAccessCodesEnabled { get; set; }

        [DataMember(
            Name = "offline_access_codes_enabled",
            IsRequired = false,
            EmitDefaultValue = false
        )]
        public bool? OfflineAccessCodesEnabled { get; set; }

        [DataMember(Name = "model", IsRequired = true, EmitDefaultValue = false)]
        public UnmanagedDevicePropertiesModel Model { get; set; }

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

    [DataContract(Name = "seamModel_unmanagedDevicePropertiesBattery_model")]
    public class UnmanagedDevicePropertiesBattery
    {
        [JsonConstructorAttribute]
        protected UnmanagedDevicePropertiesBattery() { }

        public UnmanagedDevicePropertiesBattery(
            float level = default,
            UnmanagedDevicePropertiesBattery.StatusEnum status = default
        )
        {
            Level = level;
            Status = status;
        }

        [JsonConverter(typeof(StringEnumConverter))]
        public enum StatusEnum
        {
            [EnumMember(Value = "critical")]
            Critical = 0,

            [EnumMember(Value = "low")]
            Low = 1,

            [EnumMember(Value = "good")]
            Good = 2,

            [EnumMember(Value = "full")]
            Full = 3
        }

        [DataMember(Name = "level", IsRequired = true, EmitDefaultValue = false)]
        public float Level { get; set; }

        [DataMember(Name = "status", IsRequired = true, EmitDefaultValue = false)]
        public UnmanagedDevicePropertiesBattery.StatusEnum Status { get; set; }

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

    [DataContract(Name = "seamModel_unmanagedDevicePropertiesModel_model")]
    public class UnmanagedDevicePropertiesModel
    {
        [JsonConstructorAttribute]
        protected UnmanagedDevicePropertiesModel() { }

        public UnmanagedDevicePropertiesModel(
            bool? canConnectAccessoryKeypad = default,
            string displayName = default,
            string manufacturerDisplayName = default,
            bool? hasBuiltInKeypad = default,
            bool? offlineAccessCodesSupported = default,
            bool? onlineAccessCodesSupported = default,
            bool? accessoryKeypadSupported = default
        )
        {
            CanConnectAccessoryKeypad = canConnectAccessoryKeypad;
            DisplayName = displayName;
            ManufacturerDisplayName = manufacturerDisplayName;
            HasBuiltInKeypad = hasBuiltInKeypad;
            OfflineAccessCodesSupported = offlineAccessCodesSupported;
            OnlineAccessCodesSupported = onlineAccessCodesSupported;
            AccessoryKeypadSupported = accessoryKeypadSupported;
        }

        [DataMember(
            Name = "can_connect_accessory_keypad",
            IsRequired = false,
            EmitDefaultValue = false
        )]
        public bool? CanConnectAccessoryKeypad { get; set; }

        [DataMember(Name = "display_name", IsRequired = true, EmitDefaultValue = false)]
        public string DisplayName { get; set; }

        [DataMember(
            Name = "manufacturer_display_name",
            IsRequired = true,
            EmitDefaultValue = false
        )]
        public string ManufacturerDisplayName { get; set; }

        [DataMember(Name = "has_built_in_keypad", IsRequired = false, EmitDefaultValue = false)]
        public bool? HasBuiltInKeypad { get; set; }

        [DataMember(
            Name = "offline_access_codes_supported",
            IsRequired = false,
            EmitDefaultValue = false
        )]
        public bool? OfflineAccessCodesSupported { get; set; }

        [DataMember(
            Name = "online_access_codes_supported",
            IsRequired = false,
            EmitDefaultValue = false
        )]
        public bool? OnlineAccessCodesSupported { get; set; }

        [DataMember(
            Name = "accessory_keypad_supported",
            IsRequired = false,
            EmitDefaultValue = false
        )]
        public bool? AccessoryKeypadSupported { get; set; }

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
