using System.Runtime.Serialization;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using JsonSubTypes;

namespace Seam.Model
{
    [DataContract(Name = "seamModel_device_model")]
    public class Device
    {
        [JsonConstructorAttribute]
        protected Device() { }

        public Device(
            string deviceId = default,
            Device.DeviceTypeEnum deviceType = default,
            string? nickname = default,
            string displayName = default,
            List<Device.CapabilitiesSupportedEnum> capabilitiesSupported = default,
            DeviceProperties properties = default,
            DeviceLocation? location = default,
            string connectedAccountId = default,
            string workspaceId = default,
            List<DeviceErrors> errors = default,
            List<DeviceWarnings> warnings = default,
            string createdAt = default,
            bool isManaged = default,
            object? customMetadata = default,
            bool? canRemotelyUnlock = default,
            bool? canRemotelyLock = default,
            bool? canProgramOnlineAccessCodes = default
        )
        {
            DeviceId = deviceId;
            DeviceType = deviceType;
            Nickname = nickname;
            DisplayName = displayName;
            CapabilitiesSupported = capabilitiesSupported;
            Properties = properties;
            Location = location;
            ConnectedAccountId = connectedAccountId;
            WorkspaceId = workspaceId;
            Errors = errors;
            Warnings = warnings;
            CreatedAt = createdAt;
            IsManaged = isManaged;
            CustomMetadata = customMetadata;
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
        public Device.DeviceTypeEnum DeviceType { get; set; }

        [DataMember(Name = "nickname", IsRequired = false, EmitDefaultValue = false)]
        public string? Nickname { get; set; }

        [DataMember(Name = "display_name", IsRequired = true, EmitDefaultValue = false)]
        public string DisplayName { get; set; }

        [DataMember(Name = "capabilities_supported", IsRequired = true, EmitDefaultValue = false)]
        public List<Device.CapabilitiesSupportedEnum> CapabilitiesSupported { get; set; }

        [DataMember(Name = "properties", IsRequired = true, EmitDefaultValue = false)]
        public DeviceProperties Properties { get; set; }

        [DataMember(Name = "location", IsRequired = false, EmitDefaultValue = false)]
        public DeviceLocation? Location { get; set; }

        [DataMember(Name = "connected_account_id", IsRequired = true, EmitDefaultValue = false)]
        public string ConnectedAccountId { get; set; }

        [DataMember(Name = "workspace_id", IsRequired = true, EmitDefaultValue = false)]
        public string WorkspaceId { get; set; }

        [DataMember(Name = "errors", IsRequired = true, EmitDefaultValue = false)]
        public List<DeviceErrors> Errors { get; set; }

        [DataMember(Name = "warnings", IsRequired = true, EmitDefaultValue = false)]
        public List<DeviceWarnings> Warnings { get; set; }

        [DataMember(Name = "created_at", IsRequired = true, EmitDefaultValue = false)]
        public string CreatedAt { get; set; }

        [DataMember(Name = "is_managed", IsRequired = true, EmitDefaultValue = false)]
        public bool IsManaged { get; set; }

        [DataMember(Name = "custom_metadata", IsRequired = false, EmitDefaultValue = false)]
        public object? CustomMetadata { get; set; }

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

    [DataContract(Name = "seamModel_deviceProperties_model")]
    public class DeviceProperties
    {
        [JsonConstructorAttribute]
        protected DeviceProperties() { }

        public DeviceProperties(
            bool? online = default,
            string? name = default,
            DevicePropertiesAccessoryKeypad? accessoryKeypad = default,
            DevicePropertiesAppearance? appearance = default,
            DevicePropertiesModel? model = default,
            bool? hasDirectPower = default,
            float? batteryLevel = default,
            DevicePropertiesBattery? battery = default,
            string? manufacturer = default,
            string? imageUrl = default,
            string? imageAltText = default,
            string? serialNumber = default,
            bool? onlineAccessCodesEnabled = default,
            bool? offlineAccessCodesEnabled = default,
            bool? supportsAccessoryKeypad = default,
            bool? supportsOfflineAccessCodes = default,
            DevicePropertiesAssaAbloyCredentialServiceMetadata? assaAbloyCredentialServiceMetadata =
                default,
            DevicePropertiesAugustMetadata? augustMetadata = default,
            DevicePropertiesAvigilonAltaMetadata? avigilonAltaMetadata = default,
            DevicePropertiesSchlageMetadata? schlageMetadata = default,
            DevicePropertiesSmartthingsMetadata? smartthingsMetadata = default,
            DevicePropertiesLocklyMetadata? locklyMetadata = default,
            DevicePropertiesNukiMetadata? nukiMetadata = default,
            DevicePropertiesKwiksetMetadata? kwiksetMetadata = default,
            DevicePropertiesSaltoMetadata? saltoMetadata = default,
            DevicePropertiesGenieMetadata? genieMetadata = default,
            DevicePropertiesBrivoMetadata? brivoMetadata = default,
            DevicePropertiesIglooMetadata? iglooMetadata = default,
            DevicePropertiesNoiseawareMetadata? noiseawareMetadata = default,
            DevicePropertiesMinutMetadata? minutMetadata = default,
            DevicePropertiesFourSuitesMetadata? fourSuitesMetadata = default,
            DevicePropertiesTwoNMetadata? twoNMetadata = default,
            DevicePropertiesControlbywebMetadata? controlbywebMetadata = default,
            DevicePropertiesTtlockMetadata? ttlockMetadata = default,
            DevicePropertiesSeamBridgeMetadata? seamBridgeMetadata = default,
            DevicePropertiesIgloohomeMetadata? igloohomeMetadata = default,
            DevicePropertiesNestMetadata? nestMetadata = default,
            DevicePropertiesEcobeeMetadata? ecobeeMetadata = default,
            DevicePropertiesHoneywellResideoMetadata? honeywellResideoMetadata = default,
            DevicePropertiesHubitatMetadata? hubitatMetadata = default,
            DevicePropertiesDormakabaOracodeMetadata? dormakabaOracodeMetadata = default,
            DevicePropertiesWyzeMetadata? wyzeMetadata = default,
            DevicePropertiesTedeeMetadata? tedeeMetadata = default,
            List<float>? experimentalSupportedCodeFromAccessCodesLengths = default,
            List<JObject>? codeConstraints = default,
            List<float>? supportedCodeLengths = default,
            float? maxActiveCodesSupported = default,
            bool? supportsBackupAccessCodePool = default,
            bool? hasNativeEntryEvents = default,
            bool? locked = default,
            DevicePropertiesKeypadBattery? keypadBattery = default,
            bool? doorOpen = default
        )
        {
            Online = online;
            Name = name;
            AccessoryKeypad = accessoryKeypad;
            Appearance = appearance;
            Model = model;
            HasDirectPower = hasDirectPower;
            BatteryLevel = batteryLevel;
            Battery = battery;
            Manufacturer = manufacturer;
            ImageUrl = imageUrl;
            ImageAltText = imageAltText;
            SerialNumber = serialNumber;
            OnlineAccessCodesEnabled = onlineAccessCodesEnabled;
            OfflineAccessCodesEnabled = offlineAccessCodesEnabled;
            SupportsAccessoryKeypad = supportsAccessoryKeypad;
            SupportsOfflineAccessCodes = supportsOfflineAccessCodes;
            AssaAbloyCredentialServiceMetadata = assaAbloyCredentialServiceMetadata;
            AugustMetadata = augustMetadata;
            AvigilonAltaMetadata = avigilonAltaMetadata;
            SchlageMetadata = schlageMetadata;
            SmartthingsMetadata = smartthingsMetadata;
            LocklyMetadata = locklyMetadata;
            NukiMetadata = nukiMetadata;
            KwiksetMetadata = kwiksetMetadata;
            SaltoMetadata = saltoMetadata;
            GenieMetadata = genieMetadata;
            BrivoMetadata = brivoMetadata;
            IglooMetadata = iglooMetadata;
            NoiseawareMetadata = noiseawareMetadata;
            MinutMetadata = minutMetadata;
            FourSuitesMetadata = fourSuitesMetadata;
            TwoNMetadata = twoNMetadata;
            ControlbywebMetadata = controlbywebMetadata;
            TtlockMetadata = ttlockMetadata;
            SeamBridgeMetadata = seamBridgeMetadata;
            IgloohomeMetadata = igloohomeMetadata;
            NestMetadata = nestMetadata;
            EcobeeMetadata = ecobeeMetadata;
            HoneywellResideoMetadata = honeywellResideoMetadata;
            HubitatMetadata = hubitatMetadata;
            DormakabaOracodeMetadata = dormakabaOracodeMetadata;
            WyzeMetadata = wyzeMetadata;
            TedeeMetadata = tedeeMetadata;
            ExperimentalSupportedCodeFromAccessCodesLengths =
                experimentalSupportedCodeFromAccessCodesLengths;
            CodeConstraints = codeConstraints;
            SupportedCodeLengths = supportedCodeLengths;
            MaxActiveCodesSupported = maxActiveCodesSupported;
            SupportsBackupAccessCodePool = supportsBackupAccessCodePool;
            HasNativeEntryEvents = hasNativeEntryEvents;
            Locked = locked;
            KeypadBattery = keypadBattery;
            DoorOpen = doorOpen;
        }

        [DataMember(Name = "online", IsRequired = false, EmitDefaultValue = false)]
        public bool? Online { get; set; }

        [DataMember(Name = "name", IsRequired = false, EmitDefaultValue = false)]
        public string? Name { get; set; }

        [DataMember(Name = "accessory_keypad", IsRequired = false, EmitDefaultValue = false)]
        public DevicePropertiesAccessoryKeypad? AccessoryKeypad { get; set; }

        [DataMember(Name = "appearance", IsRequired = false, EmitDefaultValue = false)]
        public DevicePropertiesAppearance? Appearance { get; set; }

        [DataMember(Name = "model", IsRequired = false, EmitDefaultValue = false)]
        public DevicePropertiesModel? Model { get; set; }

        [DataMember(Name = "has_direct_power", IsRequired = false, EmitDefaultValue = false)]
        public bool? HasDirectPower { get; set; }

        [DataMember(Name = "battery_level", IsRequired = false, EmitDefaultValue = false)]
        public float? BatteryLevel { get; set; }

        [DataMember(Name = "battery", IsRequired = false, EmitDefaultValue = false)]
        public DevicePropertiesBattery? Battery { get; set; }

        [DataMember(Name = "manufacturer", IsRequired = false, EmitDefaultValue = false)]
        public string? Manufacturer { get; set; }

        [DataMember(Name = "image_url", IsRequired = false, EmitDefaultValue = false)]
        public string? ImageUrl { get; set; }

        [DataMember(Name = "image_alt_text", IsRequired = false, EmitDefaultValue = false)]
        public string? ImageAltText { get; set; }

        [DataMember(Name = "serial_number", IsRequired = false, EmitDefaultValue = false)]
        public string? SerialNumber { get; set; }

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

        [DataMember(
            Name = "supports_accessory_keypad",
            IsRequired = false,
            EmitDefaultValue = false
        )]
        public bool? SupportsAccessoryKeypad { get; set; }

        [DataMember(
            Name = "supports_offline_access_codes",
            IsRequired = false,
            EmitDefaultValue = false
        )]
        public bool? SupportsOfflineAccessCodes { get; set; }

        [DataMember(
            Name = "assa_abloy_credential_service_metadata",
            IsRequired = false,
            EmitDefaultValue = false
        )]
        public DevicePropertiesAssaAbloyCredentialServiceMetadata? AssaAbloyCredentialServiceMetadata { get; set; }

        [DataMember(Name = "august_metadata", IsRequired = false, EmitDefaultValue = false)]
        public DevicePropertiesAugustMetadata? AugustMetadata { get; set; }

        [DataMember(Name = "avigilon_alta_metadata", IsRequired = false, EmitDefaultValue = false)]
        public DevicePropertiesAvigilonAltaMetadata? AvigilonAltaMetadata { get; set; }

        [DataMember(Name = "schlage_metadata", IsRequired = false, EmitDefaultValue = false)]
        public DevicePropertiesSchlageMetadata? SchlageMetadata { get; set; }

        [DataMember(Name = "smartthings_metadata", IsRequired = false, EmitDefaultValue = false)]
        public DevicePropertiesSmartthingsMetadata? SmartthingsMetadata { get; set; }

        [DataMember(Name = "lockly_metadata", IsRequired = false, EmitDefaultValue = false)]
        public DevicePropertiesLocklyMetadata? LocklyMetadata { get; set; }

        [DataMember(Name = "nuki_metadata", IsRequired = false, EmitDefaultValue = false)]
        public DevicePropertiesNukiMetadata? NukiMetadata { get; set; }

        [DataMember(Name = "kwikset_metadata", IsRequired = false, EmitDefaultValue = false)]
        public DevicePropertiesKwiksetMetadata? KwiksetMetadata { get; set; }

        [DataMember(Name = "salto_metadata", IsRequired = false, EmitDefaultValue = false)]
        public DevicePropertiesSaltoMetadata? SaltoMetadata { get; set; }

        [DataMember(Name = "genie_metadata", IsRequired = false, EmitDefaultValue = false)]
        public DevicePropertiesGenieMetadata? GenieMetadata { get; set; }

        [DataMember(Name = "brivo_metadata", IsRequired = false, EmitDefaultValue = false)]
        public DevicePropertiesBrivoMetadata? BrivoMetadata { get; set; }

        [DataMember(Name = "igloo_metadata", IsRequired = false, EmitDefaultValue = false)]
        public DevicePropertiesIglooMetadata? IglooMetadata { get; set; }

        [DataMember(Name = "noiseaware_metadata", IsRequired = false, EmitDefaultValue = false)]
        public DevicePropertiesNoiseawareMetadata? NoiseawareMetadata { get; set; }

        [DataMember(Name = "minut_metadata", IsRequired = false, EmitDefaultValue = false)]
        public DevicePropertiesMinutMetadata? MinutMetadata { get; set; }

        [DataMember(Name = "four_suites_metadata", IsRequired = false, EmitDefaultValue = false)]
        public DevicePropertiesFourSuitesMetadata? FourSuitesMetadata { get; set; }

        [DataMember(Name = "two_n_metadata", IsRequired = false, EmitDefaultValue = false)]
        public DevicePropertiesTwoNMetadata? TwoNMetadata { get; set; }

        [DataMember(Name = "controlbyweb_metadata", IsRequired = false, EmitDefaultValue = false)]
        public DevicePropertiesControlbywebMetadata? ControlbywebMetadata { get; set; }

        [DataMember(Name = "ttlock_metadata", IsRequired = false, EmitDefaultValue = false)]
        public DevicePropertiesTtlockMetadata? TtlockMetadata { get; set; }

        [DataMember(Name = "seam_bridge_metadata", IsRequired = false, EmitDefaultValue = false)]
        public DevicePropertiesSeamBridgeMetadata? SeamBridgeMetadata { get; set; }

        [DataMember(Name = "igloohome_metadata", IsRequired = false, EmitDefaultValue = false)]
        public DevicePropertiesIgloohomeMetadata? IgloohomeMetadata { get; set; }

        [DataMember(Name = "nest_metadata", IsRequired = false, EmitDefaultValue = false)]
        public DevicePropertiesNestMetadata? NestMetadata { get; set; }

        [DataMember(Name = "ecobee_metadata", IsRequired = false, EmitDefaultValue = false)]
        public DevicePropertiesEcobeeMetadata? EcobeeMetadata { get; set; }

        [DataMember(
            Name = "honeywell_resideo_metadata",
            IsRequired = false,
            EmitDefaultValue = false
        )]
        public DevicePropertiesHoneywellResideoMetadata? HoneywellResideoMetadata { get; set; }

        [DataMember(Name = "hubitat_metadata", IsRequired = false, EmitDefaultValue = false)]
        public DevicePropertiesHubitatMetadata? HubitatMetadata { get; set; }

        [DataMember(
            Name = "dormakaba_oracode_metadata",
            IsRequired = false,
            EmitDefaultValue = false
        )]
        public DevicePropertiesDormakabaOracodeMetadata? DormakabaOracodeMetadata { get; set; }

        [DataMember(Name = "wyze_metadata", IsRequired = false, EmitDefaultValue = false)]
        public DevicePropertiesWyzeMetadata? WyzeMetadata { get; set; }

        [DataMember(Name = "tedee_metadata", IsRequired = false, EmitDefaultValue = false)]
        public DevicePropertiesTedeeMetadata? TedeeMetadata { get; set; }

        [DataMember(
            Name = "experimental_supported_code_from_access_codes_lengths",
            IsRequired = false,
            EmitDefaultValue = false
        )]
        public List<float>? ExperimentalSupportedCodeFromAccessCodesLengths { get; set; }

        [DataMember(Name = "code_constraints", IsRequired = false, EmitDefaultValue = false)]
        public List<JObject>? CodeConstraints { get; set; }

        [DataMember(Name = "supported_code_lengths", IsRequired = false, EmitDefaultValue = false)]
        public List<float>? SupportedCodeLengths { get; set; }

        [DataMember(
            Name = "max_active_codes_supported",
            IsRequired = false,
            EmitDefaultValue = false
        )]
        public float? MaxActiveCodesSupported { get; set; }

        [DataMember(
            Name = "supports_backup_access_code_pool",
            IsRequired = false,
            EmitDefaultValue = false
        )]
        public bool? SupportsBackupAccessCodePool { get; set; }

        [DataMember(Name = "has_native_entry_events", IsRequired = false, EmitDefaultValue = false)]
        public bool? HasNativeEntryEvents { get; set; }

        [DataMember(Name = "locked", IsRequired = false, EmitDefaultValue = false)]
        public bool? Locked { get; set; }

        [DataMember(Name = "keypad_battery", IsRequired = false, EmitDefaultValue = false)]
        public DevicePropertiesKeypadBattery? KeypadBattery { get; set; }

        [DataMember(Name = "door_open", IsRequired = false, EmitDefaultValue = false)]
        public bool? DoorOpen { get; set; }

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

    [DataContract(Name = "seamModel_devicePropertiesAccessoryKeypad_model")]
    public class DevicePropertiesAccessoryKeypad
    {
        [JsonConstructorAttribute]
        protected DevicePropertiesAccessoryKeypad() { }

        public DevicePropertiesAccessoryKeypad(bool? isConnected = default)
        {
            IsConnected = isConnected;
        }

        [DataMember(Name = "is_connected", IsRequired = false, EmitDefaultValue = false)]
        public bool? IsConnected { get; set; }

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

    [DataContract(Name = "seamModel_devicePropertiesAppearance_model")]
    public class DevicePropertiesAppearance
    {
        [JsonConstructorAttribute]
        protected DevicePropertiesAppearance() { }

        public DevicePropertiesAppearance(string? name = default)
        {
            Name = name;
        }

        [DataMember(Name = "name", IsRequired = false, EmitDefaultValue = false)]
        public string? Name { get; set; }

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

    [DataContract(Name = "seamModel_devicePropertiesModel_model")]
    public class DevicePropertiesModel
    {
        [JsonConstructorAttribute]
        protected DevicePropertiesModel() { }

        public DevicePropertiesModel(
            bool? canConnectAccessoryKeypad = default,
            string? displayName = default,
            string? manufacturerDisplayName = default,
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

        [DataMember(Name = "display_name", IsRequired = false, EmitDefaultValue = false)]
        public string? DisplayName { get; set; }

        [DataMember(
            Name = "manufacturer_display_name",
            IsRequired = false,
            EmitDefaultValue = false
        )]
        public string? ManufacturerDisplayName { get; set; }

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

    [DataContract(Name = "seamModel_devicePropertiesBattery_model")]
    public class DevicePropertiesBattery
    {
        [JsonConstructorAttribute]
        protected DevicePropertiesBattery() { }

        public DevicePropertiesBattery(
            float? level = default,
            DevicePropertiesBattery.StatusEnum? status = default
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

        [DataMember(Name = "level", IsRequired = false, EmitDefaultValue = false)]
        public float? Level { get; set; }

        [DataMember(Name = "status", IsRequired = false, EmitDefaultValue = false)]
        public DevicePropertiesBattery.StatusEnum? Status { get; set; }

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

    [DataContract(Name = "seamModel_devicePropertiesAssaAbloyCredentialServiceMetadata_model")]
    public class DevicePropertiesAssaAbloyCredentialServiceMetadata
    {
        [JsonConstructorAttribute]
        protected DevicePropertiesAssaAbloyCredentialServiceMetadata() { }

        public DevicePropertiesAssaAbloyCredentialServiceMetadata(
            bool? hasActiveEndpoint = default,
            List<DevicePropertiesAssaAbloyCredentialServiceMetadataEndpoints>? endpoints = default
        )
        {
            HasActiveEndpoint = hasActiveEndpoint;
            Endpoints = endpoints;
        }

        [DataMember(Name = "has_active_endpoint", IsRequired = false, EmitDefaultValue = false)]
        public bool? HasActiveEndpoint { get; set; }

        [DataMember(Name = "endpoints", IsRequired = false, EmitDefaultValue = false)]
        public List<DevicePropertiesAssaAbloyCredentialServiceMetadataEndpoints>? Endpoints { get; set; }

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

    [DataContract(
        Name = "seamModel_devicePropertiesAssaAbloyCredentialServiceMetadataEndpoints_model"
    )]
    public class DevicePropertiesAssaAbloyCredentialServiceMetadataEndpoints
    {
        [JsonConstructorAttribute]
        protected DevicePropertiesAssaAbloyCredentialServiceMetadataEndpoints() { }

        public DevicePropertiesAssaAbloyCredentialServiceMetadataEndpoints(
            string? endpointId = default,
            bool? isActive = default
        )
        {
            EndpointId = endpointId;
            IsActive = isActive;
        }

        [DataMember(Name = "endpoint_id", IsRequired = false, EmitDefaultValue = false)]
        public string? EndpointId { get; set; }

        [DataMember(Name = "is_active", IsRequired = false, EmitDefaultValue = false)]
        public bool? IsActive { get; set; }

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

    [DataContract(Name = "seamModel_devicePropertiesAugustMetadata_model")]
    public class DevicePropertiesAugustMetadata
    {
        [JsonConstructorAttribute]
        protected DevicePropertiesAugustMetadata() { }

        public DevicePropertiesAugustMetadata(
            string? lockId = default,
            string? lockName = default,
            string? houseName = default,
            bool? hasKeypad = default,
            string? keypadBatteryLevel = default,
            string? model = default,
            string? houseId = default
        )
        {
            LockId = lockId;
            LockName = lockName;
            HouseName = houseName;
            HasKeypad = hasKeypad;
            KeypadBatteryLevel = keypadBatteryLevel;
            Model = model;
            HouseId = houseId;
        }

        [DataMember(Name = "lock_id", IsRequired = false, EmitDefaultValue = false)]
        public string? LockId { get; set; }

        [DataMember(Name = "lock_name", IsRequired = false, EmitDefaultValue = false)]
        public string? LockName { get; set; }

        [DataMember(Name = "house_name", IsRequired = false, EmitDefaultValue = false)]
        public string? HouseName { get; set; }

        [DataMember(Name = "has_keypad", IsRequired = false, EmitDefaultValue = false)]
        public bool? HasKeypad { get; set; }

        [DataMember(Name = "keypad_battery_level", IsRequired = false, EmitDefaultValue = false)]
        public string? KeypadBatteryLevel { get; set; }

        [DataMember(Name = "model", IsRequired = false, EmitDefaultValue = false)]
        public string? Model { get; set; }

        [DataMember(Name = "house_id", IsRequired = false, EmitDefaultValue = false)]
        public string? HouseId { get; set; }

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

    [DataContract(Name = "seamModel_devicePropertiesAvigilonAltaMetadata_model")]
    public class DevicePropertiesAvigilonAltaMetadata
    {
        [JsonConstructorAttribute]
        protected DevicePropertiesAvigilonAltaMetadata() { }

        public DevicePropertiesAvigilonAltaMetadata(
            string? entryName = default,
            string? orgName = default,
            float? zoneId = default,
            string? zoneName = default,
            float? siteId = default,
            string? siteName = default
        )
        {
            EntryName = entryName;
            OrgName = orgName;
            ZoneId = zoneId;
            ZoneName = zoneName;
            SiteId = siteId;
            SiteName = siteName;
        }

        [DataMember(Name = "entry_name", IsRequired = false, EmitDefaultValue = false)]
        public string? EntryName { get; set; }

        [DataMember(Name = "org_name", IsRequired = false, EmitDefaultValue = false)]
        public string? OrgName { get; set; }

        [DataMember(Name = "zone_id", IsRequired = false, EmitDefaultValue = false)]
        public float? ZoneId { get; set; }

        [DataMember(Name = "zone_name", IsRequired = false, EmitDefaultValue = false)]
        public string? ZoneName { get; set; }

        [DataMember(Name = "site_id", IsRequired = false, EmitDefaultValue = false)]
        public float? SiteId { get; set; }

        [DataMember(Name = "site_name", IsRequired = false, EmitDefaultValue = false)]
        public string? SiteName { get; set; }

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

    [DataContract(Name = "seamModel_devicePropertiesSchlageMetadata_model")]
    public class DevicePropertiesSchlageMetadata
    {
        [JsonConstructorAttribute]
        protected DevicePropertiesSchlageMetadata() { }

        public DevicePropertiesSchlageMetadata(
            string? deviceId = default,
            string? deviceName = default,
            float? accessCodeLength = default,
            string? model = default
        )
        {
            DeviceId = deviceId;
            DeviceName = deviceName;
            AccessCodeLength = accessCodeLength;
            Model = model;
        }

        [DataMember(Name = "device_id", IsRequired = false, EmitDefaultValue = false)]
        public string? DeviceId { get; set; }

        [DataMember(Name = "device_name", IsRequired = false, EmitDefaultValue = false)]
        public string? DeviceName { get; set; }

        [DataMember(Name = "access_code_length", IsRequired = false, EmitDefaultValue = false)]
        public float? AccessCodeLength { get; set; }

        [DataMember(Name = "model", IsRequired = false, EmitDefaultValue = false)]
        public string? Model { get; set; }

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

    [DataContract(Name = "seamModel_devicePropertiesSmartthingsMetadata_model")]
    public class DevicePropertiesSmartthingsMetadata
    {
        [JsonConstructorAttribute]
        protected DevicePropertiesSmartthingsMetadata() { }

        public DevicePropertiesSmartthingsMetadata(
            string? deviceId = default,
            string? deviceName = default,
            string? model = default,
            string? locationId = default
        )
        {
            DeviceId = deviceId;
            DeviceName = deviceName;
            Model = model;
            LocationId = locationId;
        }

        [DataMember(Name = "device_id", IsRequired = false, EmitDefaultValue = false)]
        public string? DeviceId { get; set; }

        [DataMember(Name = "device_name", IsRequired = false, EmitDefaultValue = false)]
        public string? DeviceName { get; set; }

        [DataMember(Name = "model", IsRequired = false, EmitDefaultValue = false)]
        public string? Model { get; set; }

        [DataMember(Name = "location_id", IsRequired = false, EmitDefaultValue = false)]
        public string? LocationId { get; set; }

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

    [DataContract(Name = "seamModel_devicePropertiesLocklyMetadata_model")]
    public class DevicePropertiesLocklyMetadata
    {
        [JsonConstructorAttribute]
        protected DevicePropertiesLocklyMetadata() { }

        public DevicePropertiesLocklyMetadata(
            string? deviceId = default,
            string? deviceName = default,
            string? model = default
        )
        {
            DeviceId = deviceId;
            DeviceName = deviceName;
            Model = model;
        }

        [DataMember(Name = "device_id", IsRequired = false, EmitDefaultValue = false)]
        public string? DeviceId { get; set; }

        [DataMember(Name = "device_name", IsRequired = false, EmitDefaultValue = false)]
        public string? DeviceName { get; set; }

        [DataMember(Name = "model", IsRequired = false, EmitDefaultValue = false)]
        public string? Model { get; set; }

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

    [DataContract(Name = "seamModel_devicePropertiesNukiMetadata_model")]
    public class DevicePropertiesNukiMetadata
    {
        [JsonConstructorAttribute]
        protected DevicePropertiesNukiMetadata() { }

        public DevicePropertiesNukiMetadata(
            string? deviceId = default,
            string? deviceName = default,
            bool? keypadBatteryCritical = default
        )
        {
            DeviceId = deviceId;
            DeviceName = deviceName;
            KeypadBatteryCritical = keypadBatteryCritical;
        }

        [DataMember(Name = "device_id", IsRequired = false, EmitDefaultValue = false)]
        public string? DeviceId { get; set; }

        [DataMember(Name = "device_name", IsRequired = false, EmitDefaultValue = false)]
        public string? DeviceName { get; set; }

        [DataMember(Name = "keypad_battery_critical", IsRequired = false, EmitDefaultValue = false)]
        public bool? KeypadBatteryCritical { get; set; }

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

    [DataContract(Name = "seamModel_devicePropertiesKwiksetMetadata_model")]
    public class DevicePropertiesKwiksetMetadata
    {
        [JsonConstructorAttribute]
        protected DevicePropertiesKwiksetMetadata() { }

        public DevicePropertiesKwiksetMetadata(
            string? deviceId = default,
            string? deviceName = default,
            string? modelNumber = default
        )
        {
            DeviceId = deviceId;
            DeviceName = deviceName;
            ModelNumber = modelNumber;
        }

        [DataMember(Name = "device_id", IsRequired = false, EmitDefaultValue = false)]
        public string? DeviceId { get; set; }

        [DataMember(Name = "device_name", IsRequired = false, EmitDefaultValue = false)]
        public string? DeviceName { get; set; }

        [DataMember(Name = "model_number", IsRequired = false, EmitDefaultValue = false)]
        public string? ModelNumber { get; set; }

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

    [DataContract(Name = "seamModel_devicePropertiesSaltoMetadata_model")]
    public class DevicePropertiesSaltoMetadata
    {
        [JsonConstructorAttribute]
        protected DevicePropertiesSaltoMetadata() { }

        public DevicePropertiesSaltoMetadata(
            string? lockId = default,
            string? customerReference = default,
            string? lockType = default,
            string? batteryLevel = default,
            string? lockedState = default,
            string? model = default
        )
        {
            LockId = lockId;
            CustomerReference = customerReference;
            LockType = lockType;
            BatteryLevel = batteryLevel;
            LockedState = lockedState;
            Model = model;
        }

        [DataMember(Name = "lock_id", IsRequired = false, EmitDefaultValue = false)]
        public string? LockId { get; set; }

        [DataMember(Name = "customer_reference", IsRequired = false, EmitDefaultValue = false)]
        public string? CustomerReference { get; set; }

        [DataMember(Name = "lock_type", IsRequired = false, EmitDefaultValue = false)]
        public string? LockType { get; set; }

        [DataMember(Name = "battery_level", IsRequired = false, EmitDefaultValue = false)]
        public string? BatteryLevel { get; set; }

        [DataMember(Name = "locked_state", IsRequired = false, EmitDefaultValue = false)]
        public string? LockedState { get; set; }

        [DataMember(Name = "model", IsRequired = false, EmitDefaultValue = false)]
        public string? Model { get; set; }

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

    [DataContract(Name = "seamModel_devicePropertiesGenieMetadata_model")]
    public class DevicePropertiesGenieMetadata
    {
        [JsonConstructorAttribute]
        protected DevicePropertiesGenieMetadata() { }

        public DevicePropertiesGenieMetadata(
            string? deviceName = default,
            string? doorName = default
        )
        {
            DeviceName = deviceName;
            DoorName = doorName;
        }

        [DataMember(Name = "device_name", IsRequired = false, EmitDefaultValue = false)]
        public string? DeviceName { get; set; }

        [DataMember(Name = "door_name", IsRequired = false, EmitDefaultValue = false)]
        public string? DoorName { get; set; }

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

    [DataContract(Name = "seamModel_devicePropertiesBrivoMetadata_model")]
    public class DevicePropertiesBrivoMetadata
    {
        [JsonConstructorAttribute]
        protected DevicePropertiesBrivoMetadata() { }

        public DevicePropertiesBrivoMetadata(string? deviceName = default)
        {
            DeviceName = deviceName;
        }

        [DataMember(Name = "device_name", IsRequired = false, EmitDefaultValue = false)]
        public string? DeviceName { get; set; }

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

    [DataContract(Name = "seamModel_devicePropertiesIglooMetadata_model")]
    public class DevicePropertiesIglooMetadata
    {
        [JsonConstructorAttribute]
        protected DevicePropertiesIglooMetadata() { }

        public DevicePropertiesIglooMetadata(
            string? deviceId = default,
            string? bridgeId = default,
            string? model = default
        )
        {
            DeviceId = deviceId;
            BridgeId = bridgeId;
            Model = model;
        }

        [DataMember(Name = "device_id", IsRequired = false, EmitDefaultValue = false)]
        public string? DeviceId { get; set; }

        [DataMember(Name = "bridge_id", IsRequired = false, EmitDefaultValue = false)]
        public string? BridgeId { get; set; }

        [DataMember(Name = "model", IsRequired = false, EmitDefaultValue = false)]
        public string? Model { get; set; }

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

    [DataContract(Name = "seamModel_devicePropertiesNoiseawareMetadata_model")]
    public class DevicePropertiesNoiseawareMetadata
    {
        [JsonConstructorAttribute]
        protected DevicePropertiesNoiseawareMetadata() { }

        public DevicePropertiesNoiseawareMetadata(
            DevicePropertiesNoiseawareMetadata.DeviceModelEnum? deviceModel = default,
            float? noiseLevelNrs = default,
            float? noiseLevelDecibel = default,
            string? deviceName = default,
            string? deviceId = default
        )
        {
            DeviceModel = deviceModel;
            NoiseLevelNrs = noiseLevelNrs;
            NoiseLevelDecibel = noiseLevelDecibel;
            DeviceName = deviceName;
            DeviceId = deviceId;
        }

        [JsonConverter(typeof(StringEnumConverter))]
        public enum DeviceModelEnum
        {
            [EnumMember(Value = "indoor")]
            Indoor = 0,

            [EnumMember(Value = "outdoor")]
            Outdoor = 1
        }

        [DataMember(Name = "device_model", IsRequired = false, EmitDefaultValue = false)]
        public DevicePropertiesNoiseawareMetadata.DeviceModelEnum? DeviceModel { get; set; }

        [DataMember(Name = "noise_level_nrs", IsRequired = false, EmitDefaultValue = false)]
        public float? NoiseLevelNrs { get; set; }

        [DataMember(Name = "noise_level_decibel", IsRequired = false, EmitDefaultValue = false)]
        public float? NoiseLevelDecibel { get; set; }

        [DataMember(Name = "device_name", IsRequired = false, EmitDefaultValue = false)]
        public string? DeviceName { get; set; }

        [DataMember(Name = "device_id", IsRequired = false, EmitDefaultValue = false)]
        public string? DeviceId { get; set; }

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

    [DataContract(Name = "seamModel_devicePropertiesMinutMetadata_model")]
    public class DevicePropertiesMinutMetadata
    {
        [JsonConstructorAttribute]
        protected DevicePropertiesMinutMetadata() { }

        public DevicePropertiesMinutMetadata(
            string? deviceId = default,
            string? deviceName = default,
            DevicePropertiesMinutMetadataLatestSensorValues? latestSensorValues = default
        )
        {
            DeviceId = deviceId;
            DeviceName = deviceName;
            LatestSensorValues = latestSensorValues;
        }

        [DataMember(Name = "device_id", IsRequired = false, EmitDefaultValue = false)]
        public string? DeviceId { get; set; }

        [DataMember(Name = "device_name", IsRequired = false, EmitDefaultValue = false)]
        public string? DeviceName { get; set; }

        [DataMember(Name = "latest_sensor_values", IsRequired = false, EmitDefaultValue = false)]
        public DevicePropertiesMinutMetadataLatestSensorValues? LatestSensorValues { get; set; }

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

    [DataContract(Name = "seamModel_devicePropertiesMinutMetadataLatestSensorValues_model")]
    public class DevicePropertiesMinutMetadataLatestSensorValues
    {
        [JsonConstructorAttribute]
        protected DevicePropertiesMinutMetadataLatestSensorValues() { }

        public DevicePropertiesMinutMetadataLatestSensorValues(
            DevicePropertiesMinutMetadataLatestSensorValuesTemperature? temperature = default,
            DevicePropertiesMinutMetadataLatestSensorValuesSound? sound = default,
            DevicePropertiesMinutMetadataLatestSensorValuesHumidity? humidity = default,
            DevicePropertiesMinutMetadataLatestSensorValuesPressure? pressure = default,
            DevicePropertiesMinutMetadataLatestSensorValuesAccelerometerZ? accelerometerZ = default
        )
        {
            Temperature = temperature;
            Sound = sound;
            Humidity = humidity;
            Pressure = pressure;
            AccelerometerZ = accelerometerZ;
        }

        [DataMember(Name = "temperature", IsRequired = false, EmitDefaultValue = false)]
        public DevicePropertiesMinutMetadataLatestSensorValuesTemperature? Temperature { get; set; }

        [DataMember(Name = "sound", IsRequired = false, EmitDefaultValue = false)]
        public DevicePropertiesMinutMetadataLatestSensorValuesSound? Sound { get; set; }

        [DataMember(Name = "humidity", IsRequired = false, EmitDefaultValue = false)]
        public DevicePropertiesMinutMetadataLatestSensorValuesHumidity? Humidity { get; set; }

        [DataMember(Name = "pressure", IsRequired = false, EmitDefaultValue = false)]
        public DevicePropertiesMinutMetadataLatestSensorValuesPressure? Pressure { get; set; }

        [DataMember(Name = "accelerometer_z", IsRequired = false, EmitDefaultValue = false)]
        public DevicePropertiesMinutMetadataLatestSensorValuesAccelerometerZ? AccelerometerZ { get; set; }

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

    [DataContract(
        Name = "seamModel_devicePropertiesMinutMetadataLatestSensorValuesTemperature_model"
    )]
    public class DevicePropertiesMinutMetadataLatestSensorValuesTemperature
    {
        [JsonConstructorAttribute]
        protected DevicePropertiesMinutMetadataLatestSensorValuesTemperature() { }

        public DevicePropertiesMinutMetadataLatestSensorValuesTemperature(
            string? time = default,
            float? value = default
        )
        {
            Time = time;
            Value = value;
        }

        [DataMember(Name = "time", IsRequired = false, EmitDefaultValue = false)]
        public string? Time { get; set; }

        [DataMember(Name = "value", IsRequired = false, EmitDefaultValue = false)]
        public float? Value { get; set; }

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

    [DataContract(Name = "seamModel_devicePropertiesMinutMetadataLatestSensorValuesSound_model")]
    public class DevicePropertiesMinutMetadataLatestSensorValuesSound
    {
        [JsonConstructorAttribute]
        protected DevicePropertiesMinutMetadataLatestSensorValuesSound() { }

        public DevicePropertiesMinutMetadataLatestSensorValuesSound(
            string? time = default,
            float? value = default
        )
        {
            Time = time;
            Value = value;
        }

        [DataMember(Name = "time", IsRequired = false, EmitDefaultValue = false)]
        public string? Time { get; set; }

        [DataMember(Name = "value", IsRequired = false, EmitDefaultValue = false)]
        public float? Value { get; set; }

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

    [DataContract(Name = "seamModel_devicePropertiesMinutMetadataLatestSensorValuesHumidity_model")]
    public class DevicePropertiesMinutMetadataLatestSensorValuesHumidity
    {
        [JsonConstructorAttribute]
        protected DevicePropertiesMinutMetadataLatestSensorValuesHumidity() { }

        public DevicePropertiesMinutMetadataLatestSensorValuesHumidity(
            string? time = default,
            float? value = default
        )
        {
            Time = time;
            Value = value;
        }

        [DataMember(Name = "time", IsRequired = false, EmitDefaultValue = false)]
        public string? Time { get; set; }

        [DataMember(Name = "value", IsRequired = false, EmitDefaultValue = false)]
        public float? Value { get; set; }

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

    [DataContract(Name = "seamModel_devicePropertiesMinutMetadataLatestSensorValuesPressure_model")]
    public class DevicePropertiesMinutMetadataLatestSensorValuesPressure
    {
        [JsonConstructorAttribute]
        protected DevicePropertiesMinutMetadataLatestSensorValuesPressure() { }

        public DevicePropertiesMinutMetadataLatestSensorValuesPressure(
            string? time = default,
            float? value = default
        )
        {
            Time = time;
            Value = value;
        }

        [DataMember(Name = "time", IsRequired = false, EmitDefaultValue = false)]
        public string? Time { get; set; }

        [DataMember(Name = "value", IsRequired = false, EmitDefaultValue = false)]
        public float? Value { get; set; }

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

    [DataContract(
        Name = "seamModel_devicePropertiesMinutMetadataLatestSensorValuesAccelerometerZ_model"
    )]
    public class DevicePropertiesMinutMetadataLatestSensorValuesAccelerometerZ
    {
        [JsonConstructorAttribute]
        protected DevicePropertiesMinutMetadataLatestSensorValuesAccelerometerZ() { }

        public DevicePropertiesMinutMetadataLatestSensorValuesAccelerometerZ(
            string? time = default,
            float? value = default
        )
        {
            Time = time;
            Value = value;
        }

        [DataMember(Name = "time", IsRequired = false, EmitDefaultValue = false)]
        public string? Time { get; set; }

        [DataMember(Name = "value", IsRequired = false, EmitDefaultValue = false)]
        public float? Value { get; set; }

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

    [DataContract(Name = "seamModel_devicePropertiesFourSuitesMetadata_model")]
    public class DevicePropertiesFourSuitesMetadata
    {
        [JsonConstructorAttribute]
        protected DevicePropertiesFourSuitesMetadata() { }

        public DevicePropertiesFourSuitesMetadata(
            float? deviceId = default,
            string? deviceName = default,
            float? recloseDelayInSeconds = default
        )
        {
            DeviceId = deviceId;
            DeviceName = deviceName;
            RecloseDelayInSeconds = recloseDelayInSeconds;
        }

        [DataMember(Name = "device_id", IsRequired = false, EmitDefaultValue = false)]
        public float? DeviceId { get; set; }

        [DataMember(Name = "device_name", IsRequired = false, EmitDefaultValue = false)]
        public string? DeviceName { get; set; }

        [DataMember(
            Name = "reclose_delay_in_seconds",
            IsRequired = false,
            EmitDefaultValue = false
        )]
        public float? RecloseDelayInSeconds { get; set; }

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

    [DataContract(Name = "seamModel_devicePropertiesTwoNMetadata_model")]
    public class DevicePropertiesTwoNMetadata
    {
        [JsonConstructorAttribute]
        protected DevicePropertiesTwoNMetadata() { }

        public DevicePropertiesTwoNMetadata(float? deviceId = default, string? deviceName = default)
        {
            DeviceId = deviceId;
            DeviceName = deviceName;
        }

        [DataMember(Name = "device_id", IsRequired = false, EmitDefaultValue = false)]
        public float? DeviceId { get; set; }

        [DataMember(Name = "device_name", IsRequired = false, EmitDefaultValue = false)]
        public string? DeviceName { get; set; }

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

    [DataContract(Name = "seamModel_devicePropertiesControlbywebMetadata_model")]
    public class DevicePropertiesControlbywebMetadata
    {
        [JsonConstructorAttribute]
        protected DevicePropertiesControlbywebMetadata() { }

        public DevicePropertiesControlbywebMetadata(
            string? deviceId = default,
            string? deviceName = default,
            string? relayName = default
        )
        {
            DeviceId = deviceId;
            DeviceName = deviceName;
            RelayName = relayName;
        }

        [DataMember(Name = "device_id", IsRequired = false, EmitDefaultValue = false)]
        public string? DeviceId { get; set; }

        [DataMember(Name = "device_name", IsRequired = false, EmitDefaultValue = false)]
        public string? DeviceName { get; set; }

        [DataMember(Name = "relay_name", IsRequired = false, EmitDefaultValue = false)]
        public string? RelayName { get; set; }

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

    [DataContract(Name = "seamModel_devicePropertiesTtlockMetadata_model")]
    public class DevicePropertiesTtlockMetadata
    {
        [JsonConstructorAttribute]
        protected DevicePropertiesTtlockMetadata() { }

        public DevicePropertiesTtlockMetadata(float? lockId = default, string? lockAlias = default)
        {
            LockId = lockId;
            LockAlias = lockAlias;
        }

        [DataMember(Name = "lock_id", IsRequired = false, EmitDefaultValue = false)]
        public float? LockId { get; set; }

        [DataMember(Name = "lock_alias", IsRequired = false, EmitDefaultValue = false)]
        public string? LockAlias { get; set; }

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

    [DataContract(Name = "seamModel_devicePropertiesSeamBridgeMetadata_model")]
    public class DevicePropertiesSeamBridgeMetadata
    {
        [JsonConstructorAttribute]
        protected DevicePropertiesSeamBridgeMetadata() { }

        public DevicePropertiesSeamBridgeMetadata(
            DevicePropertiesSeamBridgeMetadata.UnlockMethodEnum? unlockMethod = default,
            float? deviceNum = default,
            string? name = default
        )
        {
            UnlockMethod = unlockMethod;
            DeviceNum = deviceNum;
            Name = name;
        }

        [JsonConverter(typeof(StringEnumConverter))]
        public enum UnlockMethodEnum
        {
            [EnumMember(Value = "bridge")]
            Bridge = 0,

            [EnumMember(Value = "doorking")]
            Doorking = 1
        }

        [DataMember(Name = "unlock_method", IsRequired = false, EmitDefaultValue = false)]
        public DevicePropertiesSeamBridgeMetadata.UnlockMethodEnum? UnlockMethod { get; set; }

        [DataMember(Name = "device_num", IsRequired = false, EmitDefaultValue = false)]
        public float? DeviceNum { get; set; }

        [DataMember(Name = "name", IsRequired = false, EmitDefaultValue = false)]
        public string? Name { get; set; }

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

    [DataContract(Name = "seamModel_devicePropertiesIgloohomeMetadata_model")]
    public class DevicePropertiesIgloohomeMetadata
    {
        [JsonConstructorAttribute]
        protected DevicePropertiesIgloohomeMetadata() { }

        public DevicePropertiesIgloohomeMetadata(
            string? deviceId = default,
            string? deviceName = default,
            string? bridgeId = default,
            string? bridgeName = default
        )
        {
            DeviceId = deviceId;
            DeviceName = deviceName;
            BridgeId = bridgeId;
            BridgeName = bridgeName;
        }

        [DataMember(Name = "device_id", IsRequired = false, EmitDefaultValue = false)]
        public string? DeviceId { get; set; }

        [DataMember(Name = "device_name", IsRequired = false, EmitDefaultValue = false)]
        public string? DeviceName { get; set; }

        [DataMember(Name = "bridge_id", IsRequired = false, EmitDefaultValue = false)]
        public string? BridgeId { get; set; }

        [DataMember(Name = "bridge_name", IsRequired = false, EmitDefaultValue = false)]
        public string? BridgeName { get; set; }

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

    [DataContract(Name = "seamModel_devicePropertiesNestMetadata_model")]
    public class DevicePropertiesNestMetadata
    {
        [JsonConstructorAttribute]
        protected DevicePropertiesNestMetadata() { }

        public DevicePropertiesNestMetadata(
            string? nestDeviceId = default,
            string? deviceName = default,
            string? customName = default
        )
        {
            NestDeviceId = nestDeviceId;
            DeviceName = deviceName;
            CustomName = customName;
        }

        [DataMember(Name = "nest_device_id", IsRequired = false, EmitDefaultValue = false)]
        public string? NestDeviceId { get; set; }

        [DataMember(Name = "device_name", IsRequired = false, EmitDefaultValue = false)]
        public string? DeviceName { get; set; }

        [DataMember(Name = "custom_name", IsRequired = false, EmitDefaultValue = false)]
        public string? CustomName { get; set; }

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

    [DataContract(Name = "seamModel_devicePropertiesEcobeeMetadata_model")]
    public class DevicePropertiesEcobeeMetadata
    {
        [JsonConstructorAttribute]
        protected DevicePropertiesEcobeeMetadata() { }

        public DevicePropertiesEcobeeMetadata(
            string? ecobeeDeviceId = default,
            string? deviceName = default
        )
        {
            EcobeeDeviceId = ecobeeDeviceId;
            DeviceName = deviceName;
        }

        [DataMember(Name = "ecobee_device_id", IsRequired = false, EmitDefaultValue = false)]
        public string? EcobeeDeviceId { get; set; }

        [DataMember(Name = "device_name", IsRequired = false, EmitDefaultValue = false)]
        public string? DeviceName { get; set; }

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

    [DataContract(Name = "seamModel_devicePropertiesHoneywellResideoMetadata_model")]
    public class DevicePropertiesHoneywellResideoMetadata
    {
        [JsonConstructorAttribute]
        protected DevicePropertiesHoneywellResideoMetadata() { }

        public DevicePropertiesHoneywellResideoMetadata(
            string? honeywellResideoDeviceId = default,
            string? deviceName = default
        )
        {
            HoneywellResideoDeviceId = honeywellResideoDeviceId;
            DeviceName = deviceName;
        }

        [DataMember(
            Name = "honeywell_resideo_device_id",
            IsRequired = false,
            EmitDefaultValue = false
        )]
        public string? HoneywellResideoDeviceId { get; set; }

        [DataMember(Name = "device_name", IsRequired = false, EmitDefaultValue = false)]
        public string? DeviceName { get; set; }

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

    [DataContract(Name = "seamModel_devicePropertiesHubitatMetadata_model")]
    public class DevicePropertiesHubitatMetadata
    {
        [JsonConstructorAttribute]
        protected DevicePropertiesHubitatMetadata() { }

        public DevicePropertiesHubitatMetadata(
            string? deviceId = default,
            string? deviceName = default,
            string? deviceLabel = default
        )
        {
            DeviceId = deviceId;
            DeviceName = deviceName;
            DeviceLabel = deviceLabel;
        }

        [DataMember(Name = "device_id", IsRequired = false, EmitDefaultValue = false)]
        public string? DeviceId { get; set; }

        [DataMember(Name = "device_name", IsRequired = false, EmitDefaultValue = false)]
        public string? DeviceName { get; set; }

        [DataMember(Name = "device_label", IsRequired = false, EmitDefaultValue = false)]
        public string? DeviceLabel { get; set; }

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

    [DataContract(Name = "seamModel_devicePropertiesDormakabaOracodeMetadata_model")]
    public class DevicePropertiesDormakabaOracodeMetadata
    {
        [JsonConstructorAttribute]
        protected DevicePropertiesDormakabaOracodeMetadata() { }

        public DevicePropertiesDormakabaOracodeMetadata(
            float? doorId = default,
            string? doorName = default,
            float? deviceId = default,
            float? siteId = default,
            string? siteName = default,
            string? ianaTimezone = default,
            List<DevicePropertiesDormakabaOracodeMetadataPredefinedTimeSlots>? predefinedTimeSlots =
                default
        )
        {
            DoorId = doorId;
            DoorName = doorName;
            DeviceId = deviceId;
            SiteId = siteId;
            SiteName = siteName;
            IanaTimezone = ianaTimezone;
            PredefinedTimeSlots = predefinedTimeSlots;
        }

        [DataMember(Name = "door_id", IsRequired = false, EmitDefaultValue = false)]
        public float? DoorId { get; set; }

        [DataMember(Name = "door_name", IsRequired = false, EmitDefaultValue = false)]
        public string? DoorName { get; set; }

        [DataMember(Name = "device_id", IsRequired = false, EmitDefaultValue = false)]
        public float? DeviceId { get; set; }

        [DataMember(Name = "site_id", IsRequired = false, EmitDefaultValue = false)]
        public float? SiteId { get; set; }

        [DataMember(Name = "site_name", IsRequired = false, EmitDefaultValue = false)]
        public string? SiteName { get; set; }

        [DataMember(Name = "iana_timezone", IsRequired = false, EmitDefaultValue = false)]
        public string? IanaTimezone { get; set; }

        [DataMember(Name = "predefined_time_slots", IsRequired = false, EmitDefaultValue = false)]
        public List<DevicePropertiesDormakabaOracodeMetadataPredefinedTimeSlots>? PredefinedTimeSlots { get; set; }

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

    [DataContract(
        Name = "seamModel_devicePropertiesDormakabaOracodeMetadataPredefinedTimeSlots_model"
    )]
    public class DevicePropertiesDormakabaOracodeMetadataPredefinedTimeSlots
    {
        [JsonConstructorAttribute]
        protected DevicePropertiesDormakabaOracodeMetadataPredefinedTimeSlots() { }

        public DevicePropertiesDormakabaOracodeMetadataPredefinedTimeSlots(
            string? name = default,
            float? prefix = default,
            string? checkInTime = default,
            string? checkOutTime = default,
            bool? is_24Hour = default,
            bool? isBiweeklyMode = default,
            bool? isOneShot = default,
            bool? isMaster = default,
            float? extDormakabaOracodeUserLevelPrefix = default,
            string? dormakabaOracodeUserLevelId = default
        )
        {
            Name = name;
            Prefix = prefix;
            CheckInTime = checkInTime;
            CheckOutTime = checkOutTime;
            Is_24Hour = is_24Hour;
            IsBiweeklyMode = isBiweeklyMode;
            IsOneShot = isOneShot;
            IsMaster = isMaster;
            ExtDormakabaOracodeUserLevelPrefix = extDormakabaOracodeUserLevelPrefix;
            DormakabaOracodeUserLevelId = dormakabaOracodeUserLevelId;
        }

        [DataMember(Name = "name", IsRequired = false, EmitDefaultValue = false)]
        public string? Name { get; set; }

        [DataMember(Name = "prefix", IsRequired = false, EmitDefaultValue = false)]
        public float? Prefix { get; set; }

        [DataMember(Name = "check_in_time", IsRequired = false, EmitDefaultValue = false)]
        public string? CheckInTime { get; set; }

        [DataMember(Name = "check_out_time", IsRequired = false, EmitDefaultValue = false)]
        public string? CheckOutTime { get; set; }

        [DataMember(Name = "is_24_hour", IsRequired = false, EmitDefaultValue = false)]
        public bool? Is_24Hour { get; set; }

        [DataMember(Name = "is_biweekly_mode", IsRequired = false, EmitDefaultValue = false)]
        public bool? IsBiweeklyMode { get; set; }

        [DataMember(Name = "is_one_shot", IsRequired = false, EmitDefaultValue = false)]
        public bool? IsOneShot { get; set; }

        [DataMember(Name = "is_master", IsRequired = false, EmitDefaultValue = false)]
        public bool? IsMaster { get; set; }

        [DataMember(
            Name = "ext_dormakaba_oracode_user_level_prefix",
            IsRequired = false,
            EmitDefaultValue = false
        )]
        public float? ExtDormakabaOracodeUserLevelPrefix { get; set; }

        [DataMember(
            Name = "dormakaba_oracode_user_level_id",
            IsRequired = false,
            EmitDefaultValue = false
        )]
        public string? DormakabaOracodeUserLevelId { get; set; }

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

    [DataContract(Name = "seamModel_devicePropertiesWyzeMetadata_model")]
    public class DevicePropertiesWyzeMetadata
    {
        [JsonConstructorAttribute]
        protected DevicePropertiesWyzeMetadata() { }

        public DevicePropertiesWyzeMetadata(
            string? deviceId = default,
            string? deviceName = default,
            string? productName = default,
            string? productType = default,
            string? productModel = default,
            string? deviceInfoModel = default
        )
        {
            DeviceId = deviceId;
            DeviceName = deviceName;
            ProductName = productName;
            ProductType = productType;
            ProductModel = productModel;
            DeviceInfoModel = deviceInfoModel;
        }

        [DataMember(Name = "device_id", IsRequired = false, EmitDefaultValue = false)]
        public string? DeviceId { get; set; }

        [DataMember(Name = "device_name", IsRequired = false, EmitDefaultValue = false)]
        public string? DeviceName { get; set; }

        [DataMember(Name = "product_name", IsRequired = false, EmitDefaultValue = false)]
        public string? ProductName { get; set; }

        [DataMember(Name = "product_type", IsRequired = false, EmitDefaultValue = false)]
        public string? ProductType { get; set; }

        [DataMember(Name = "product_model", IsRequired = false, EmitDefaultValue = false)]
        public string? ProductModel { get; set; }

        [DataMember(Name = "device_info_model", IsRequired = false, EmitDefaultValue = false)]
        public string? DeviceInfoModel { get; set; }

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

    [DataContract(Name = "seamModel_devicePropertiesTedeeMetadata_model")]
    public class DevicePropertiesTedeeMetadata
    {
        [JsonConstructorAttribute]
        protected DevicePropertiesTedeeMetadata() { }

        public DevicePropertiesTedeeMetadata(
            float? deviceId = default,
            string? serialNumber = default,
            string? deviceName = default,
            string? deviceModel = default,
            float? bridgeId = default,
            string? bridgeName = default
        )
        {
            DeviceId = deviceId;
            SerialNumber = serialNumber;
            DeviceName = deviceName;
            DeviceModel = deviceModel;
            BridgeId = bridgeId;
            BridgeName = bridgeName;
        }

        [DataMember(Name = "device_id", IsRequired = false, EmitDefaultValue = false)]
        public float? DeviceId { get; set; }

        [DataMember(Name = "serial_number", IsRequired = false, EmitDefaultValue = false)]
        public string? SerialNumber { get; set; }

        [DataMember(Name = "device_name", IsRequired = false, EmitDefaultValue = false)]
        public string? DeviceName { get; set; }

        [DataMember(Name = "device_model", IsRequired = false, EmitDefaultValue = false)]
        public string? DeviceModel { get; set; }

        [DataMember(Name = "bridge_id", IsRequired = false, EmitDefaultValue = false)]
        public float? BridgeId { get; set; }

        [DataMember(Name = "bridge_name", IsRequired = false, EmitDefaultValue = false)]
        public string? BridgeName { get; set; }

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

    [DataContract(Name = "seamModel_devicePropertiesKeypadBattery_model")]
    public class DevicePropertiesKeypadBattery
    {
        [JsonConstructorAttribute]
        protected DevicePropertiesKeypadBattery() { }

        public DevicePropertiesKeypadBattery(float? level = default)
        {
            Level = level;
        }

        [DataMember(Name = "level", IsRequired = false, EmitDefaultValue = false)]
        public float? Level { get; set; }

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

    [DataContract(Name = "seamModel_deviceLocation_model")]
    public class DeviceLocation
    {
        [JsonConstructorAttribute]
        protected DeviceLocation() { }

        public DeviceLocation(string? locationName = default, string? timezone = default)
        {
            LocationName = locationName;
            Timezone = timezone;
        }

        [DataMember(Name = "location_name", IsRequired = false, EmitDefaultValue = false)]
        public string? LocationName { get; set; }

        [DataMember(Name = "timezone", IsRequired = false, EmitDefaultValue = false)]
        public string? Timezone { get; set; }

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

    [DataContract(Name = "seamModel_deviceErrors_model")]
    public class DeviceErrors
    {
        [JsonConstructorAttribute]
        protected DeviceErrors() { }

        public DeviceErrors(string errorCode = default, string message = default)
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

    [DataContract(Name = "seamModel_deviceWarnings_model")]
    public class DeviceWarnings
    {
        [JsonConstructorAttribute]
        protected DeviceWarnings() { }

        public DeviceWarnings(string warningCode = default, string message = default)
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
}
