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
    /// Represents a [device](https://docs.seam.co/core-concepts/devices) that has been connected to Seam.
    /// </summary>
    [DataContract(Name = "seamModel_device_model")]
    public class Device
    {
        [JsonConstructorAttribute]
        protected Device() { }

        public Device(
            bool? canConfigureAutoLock = default,
            bool? canHvacCool = default,
            bool? canHvacHeat = default,
            bool? canHvacHeatCool = default,
            bool? canProgramOfflineAccessCodes = default,
            bool? canProgramOnlineAccessCodes = default,
            bool? canProgramThermostatProgramsAsDifferentEachDay = default,
            bool? canProgramThermostatProgramsAsSameEachDay = default,
            bool? canProgramThermostatProgramsAsWeekdayWeekend = default,
            bool? canRemotelyLock = default,
            bool? canRemotelyUnlock = default,
            bool? canRunThermostatPrograms = default,
            bool? canSimulateConnection = default,
            bool? canSimulateDisconnection = default,
            bool? canSimulateHubConnection = default,
            bool? canSimulateHubDisconnection = default,
            bool? canSimulatePaidSubscription = default,
            bool? canSimulateRemoval = default,
            bool? canTurnOffHvac = default,
            bool? canUnlockWithCode = default,
            List<Device.CapabilitiesSupportedEnum> capabilitiesSupported = default,
            string connectedAccountId = default,
            string createdAt = default,
            object customMetadata = default,
            string deviceId = default,
            DeviceDeviceManufacturer? deviceManufacturer = default,
            DeviceDeviceProvider? deviceProvider = default,
            Device.DeviceTypeEnum deviceType = default,
            string displayName = default,
            List<DeviceErrors> errors = default,
            bool isManaged = default,
            DeviceLocation? location = default,
            string? nickname = default,
            DeviceProperties properties = default,
            List<string> spaceIds = default,
            List<DeviceWarnings> warnings = default,
            string workspaceId = default
        )
        {
            CanConfigureAutoLock = canConfigureAutoLock;
            CanHvacCool = canHvacCool;
            CanHvacHeat = canHvacHeat;
            CanHvacHeatCool = canHvacHeatCool;
            CanProgramOfflineAccessCodes = canProgramOfflineAccessCodes;
            CanProgramOnlineAccessCodes = canProgramOnlineAccessCodes;
            CanProgramThermostatProgramsAsDifferentEachDay =
                canProgramThermostatProgramsAsDifferentEachDay;
            CanProgramThermostatProgramsAsSameEachDay = canProgramThermostatProgramsAsSameEachDay;
            CanProgramThermostatProgramsAsWeekdayWeekend =
                canProgramThermostatProgramsAsWeekdayWeekend;
            CanRemotelyLock = canRemotelyLock;
            CanRemotelyUnlock = canRemotelyUnlock;
            CanRunThermostatPrograms = canRunThermostatPrograms;
            CanSimulateConnection = canSimulateConnection;
            CanSimulateDisconnection = canSimulateDisconnection;
            CanSimulateHubConnection = canSimulateHubConnection;
            CanSimulateHubDisconnection = canSimulateHubDisconnection;
            CanSimulatePaidSubscription = canSimulatePaidSubscription;
            CanSimulateRemoval = canSimulateRemoval;
            CanTurnOffHvac = canTurnOffHvac;
            CanUnlockWithCode = canUnlockWithCode;
            CapabilitiesSupported = capabilitiesSupported;
            ConnectedAccountId = connectedAccountId;
            CreatedAt = createdAt;
            CustomMetadata = customMetadata;
            DeviceId = deviceId;
            DeviceManufacturer = deviceManufacturer;
            DeviceProvider = deviceProvider;
            DeviceType = deviceType;
            DisplayName = displayName;
            Errors = errors;
            IsManaged = isManaged;
            Location = location;
            Nickname = nickname;
            Properties = properties;
            SpaceIds = spaceIds;
            Warnings = warnings;
            WorkspaceId = workspaceId;
        }

        /// <summary>
        /// Collection of capabilities that the device supports when connected to Seam. Values are `access_code`, which indicates that the device can manage and utilize digital PIN codes for secure access; `lock`, which indicates that the device controls a door locking mechanism, enabling the remote opening and closing of doors and other entry points; `noise_detection`, which indicates that the device supports monitoring and responding to ambient noise levels; `thermostat`, which indicates that the device can regulate and adjust indoor temperatures; `battery`, which indicates that the device can manage battery life and health; and `phone`, which indicates that the device is a mobile device, such as a smartphone. **Important:** Superseded by [capability flags](https://docs.seam.co/capability-guides/device-and-system-capabilities#capability-flags).
        /// </summary>
        [JsonConverter(typeof(SafeStringEnumConverter))]
        public enum CapabilitiesSupportedEnum
        {
            [EnumMember(Value = "unrecognized")]
            Unrecognized = 0,

            [EnumMember(Value = "access_code")]
            AccessCode = 1,

            [EnumMember(Value = "lock")]
            Lock = 2,

            [EnumMember(Value = "noise_detection")]
            NoiseDetection = 3,

            [EnumMember(Value = "thermostat")]
            Thermostat = 4,

            [EnumMember(Value = "battery")]
            Battery = 5,

            [EnumMember(Value = "phone")]
            Phone = 6,
        }

        /// <summary>
        /// Type of the device.
        /// </summary>
        [JsonConverter(typeof(SafeStringEnumConverter))]
        public enum DeviceTypeEnum
        {
            [EnumMember(Value = "unrecognized")]
            Unrecognized = 0,

            [EnumMember(Value = "akuvox_lock")]
            AkuvoxLock = 1,

            [EnumMember(Value = "august_lock")]
            AugustLock = 2,

            [EnumMember(Value = "brivo_access_point")]
            BrivoAccessPoint = 3,

            [EnumMember(Value = "butterflymx_panel")]
            ButterflymxPanel = 4,

            [EnumMember(Value = "avigilon_alta_entry")]
            AvigilonAltaEntry = 5,

            [EnumMember(Value = "doorking_lock")]
            DoorkingLock = 6,

            [EnumMember(Value = "genie_door")]
            GenieDoor = 7,

            [EnumMember(Value = "igloo_lock")]
            IglooLock = 8,

            [EnumMember(Value = "linear_lock")]
            LinearLock = 9,

            [EnumMember(Value = "lockly_lock")]
            LocklyLock = 10,

            [EnumMember(Value = "kwikset_lock")]
            KwiksetLock = 11,

            [EnumMember(Value = "nuki_lock")]
            NukiLock = 12,

            [EnumMember(Value = "salto_lock")]
            SaltoLock = 13,

            [EnumMember(Value = "schlage_lock")]
            SchlageLock = 14,

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

            [EnumMember(Value = "four_suites_door")]
            FourSuitesDoor = 22,

            [EnumMember(Value = "dormakaba_oracode_door")]
            DormakabaOracodeDoor = 23,

            [EnumMember(Value = "tedee_lock")]
            TedeeLock = 24,

            [EnumMember(Value = "akiles_lock")]
            AkilesLock = 25,

            [EnumMember(Value = "ultraloq_lock")]
            UltraloqLock = 26,

            [EnumMember(Value = "keyincode_lock")]
            KeyincodeLock = 27,

            [EnumMember(Value = "omnitec_lock")]
            OmnitecLock = 28,

            [EnumMember(Value = "kisi_lock")]
            KisiLock = 29,

            [EnumMember(Value = "keynest_key")]
            KeynestKey = 30,

            [EnumMember(Value = "noiseaware_activity_zone")]
            NoiseawareActivityZone = 31,

            [EnumMember(Value = "minut_sensor")]
            MinutSensor = 32,

            [EnumMember(Value = "ecobee_thermostat")]
            EcobeeThermostat = 33,

            [EnumMember(Value = "nest_thermostat")]
            NestThermostat = 34,

            [EnumMember(Value = "honeywell_resideo_thermostat")]
            HoneywellResideoThermostat = 35,

            [EnumMember(Value = "tado_thermostat")]
            TadoThermostat = 36,

            [EnumMember(Value = "sensi_thermostat")]
            SensiThermostat = 37,

            [EnumMember(Value = "smartthings_thermostat")]
            SmartthingsThermostat = 38,

            [EnumMember(Value = "ios_phone")]
            IosPhone = 39,

            [EnumMember(Value = "android_phone")]
            AndroidPhone = 40,

            [EnumMember(Value = "ring_camera")]
            RingCamera = 41,
        }

        [JsonConverter(typeof(JsonSubtypes), "error_code")]
        [JsonSubtypes.FallBackSubType(typeof(DeviceErrorsUnrecognized))]
        [JsonSubtypes.KnownSubType(typeof(DeviceErrorsBridgeDisconnected), "bridge_disconnected")]
        [JsonSubtypes.KnownSubType(
            typeof(DeviceErrorsSubscriptionRequired),
            "subscription_required"
        )]
        [JsonSubtypes.KnownSubType(
            typeof(DeviceErrorsAuxiliaryHeatRunning),
            "auxiliary_heat_running"
        )]
        [JsonSubtypes.KnownSubType(
            typeof(DeviceErrorsMissingDeviceCredentials),
            "missing_device_credentials"
        )]
        [JsonSubtypes.KnownSubType(
            typeof(DeviceErrorsAugustLockNotAuthorized),
            "august_lock_not_authorized"
        )]
        [JsonSubtypes.KnownSubType(
            typeof(DeviceErrorsEmptyBackupAccessCodePool),
            "empty_backup_access_code_pool"
        )]
        [JsonSubtypes.KnownSubType(typeof(DeviceErrorsDeviceDisconnected), "device_disconnected")]
        [JsonSubtypes.KnownSubType(typeof(DeviceErrorsHubDisconnected), "hub_disconnected")]
        [JsonSubtypes.KnownSubType(typeof(DeviceErrorsDeviceRemoved), "device_removed")]
        [JsonSubtypes.KnownSubType(typeof(DeviceErrorsDeviceOffline), "device_offline")]
        [JsonSubtypes.KnownSubType(
            typeof(DeviceErrorsDormakabaSitesDisconnected),
            "dormakaba_sites_disconnected"
        )]
        [JsonSubtypes.KnownSubType(
            typeof(DeviceErrorsSaltoKsSubscriptionLimitExceeded),
            "salto_ks_subscription_limit_exceeded"
        )]
        [JsonSubtypes.KnownSubType(typeof(DeviceErrorsAccountDisconnected), "account_disconnected")]
        public abstract class DeviceErrors
        {
            public abstract string ErrorCode { get; }

            public abstract string CreatedAt { get; set; }

            public abstract string Message { get; set; }

            public abstract override string ToString();
        }

        [DataContract(Name = "seamModel_deviceErrorsAccountDisconnected_model")]
        public class DeviceErrorsAccountDisconnected : DeviceErrors
        {
            [JsonConstructorAttribute]
            protected DeviceErrorsAccountDisconnected() { }

            public DeviceErrorsAccountDisconnected(
                string createdAt = default,
                string errorCode = default,
                bool isConnectedAccountError = default,
                bool isDeviceError = default,
                string message = default
            )
            {
                CreatedAt = createdAt;
                ErrorCode = errorCode;
                IsConnectedAccountError = isConnectedAccountError;
                IsDeviceError = isDeviceError;
                Message = message;
            }

            /// <summary>
            /// Date and time at which Seam created the error.
            /// </summary>
            [DataMember(Name = "created_at", IsRequired = false, EmitDefaultValue = false)]
            public override string CreatedAt { get; set; }

            [DataMember(Name = "error_code", IsRequired = true, EmitDefaultValue = false)]
            public override string ErrorCode { get; } = "account_disconnected";

            /// <summary>
            /// Indicates that the error is a [connected account](https://docs.seam.co/api/connected_accounts) error.
            /// </summary>
            [DataMember(
                Name = "is_connected_account_error",
                IsRequired = false,
                EmitDefaultValue = false
            )]
            public bool IsConnectedAccountError { get; set; }

            /// <summary>
            /// Indicates that the error is not a device error.
            /// </summary>
            [DataMember(Name = "is_device_error", IsRequired = false, EmitDefaultValue = false)]
            public bool IsDeviceError { get; set; }

            /// <summary>
            /// Detailed description of the error. Provides insights into the issue and potentially how to rectify it.
            /// </summary>
            [DataMember(Name = "message", IsRequired = false, EmitDefaultValue = false)]
            public override string Message { get; set; }

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

        [DataContract(Name = "seamModel_deviceErrorsSaltoKsSubscriptionLimitExceeded_model")]
        public class DeviceErrorsSaltoKsSubscriptionLimitExceeded : DeviceErrors
        {
            [JsonConstructorAttribute]
            protected DeviceErrorsSaltoKsSubscriptionLimitExceeded() { }

            public DeviceErrorsSaltoKsSubscriptionLimitExceeded(
                string createdAt = default,
                string errorCode = default,
                bool isConnectedAccountError = default,
                bool isDeviceError = default,
                string message = default
            )
            {
                CreatedAt = createdAt;
                ErrorCode = errorCode;
                IsConnectedAccountError = isConnectedAccountError;
                IsDeviceError = isDeviceError;
                Message = message;
            }

            /// <summary>
            /// Date and time at which Seam created the error.
            /// </summary>
            [DataMember(Name = "created_at", IsRequired = false, EmitDefaultValue = false)]
            public override string CreatedAt { get; set; }

            [DataMember(Name = "error_code", IsRequired = true, EmitDefaultValue = false)]
            public override string ErrorCode { get; } = "salto_ks_subscription_limit_exceeded";

            /// <summary>
            /// Indicates that the error is a [connected account](https://docs.seam.co/api/connected_accounts) error.
            /// </summary>
            [DataMember(
                Name = "is_connected_account_error",
                IsRequired = false,
                EmitDefaultValue = false
            )]
            public bool IsConnectedAccountError { get; set; }

            /// <summary>
            /// Indicates that the error is not a device error.
            /// </summary>
            [DataMember(Name = "is_device_error", IsRequired = false, EmitDefaultValue = false)]
            public bool IsDeviceError { get; set; }

            /// <summary>
            /// Detailed description of the error. Provides insights into the issue and potentially how to rectify it.
            /// </summary>
            [DataMember(Name = "message", IsRequired = false, EmitDefaultValue = false)]
            public override string Message { get; set; }

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

        [DataContract(Name = "seamModel_deviceErrorsDormakabaSitesDisconnected_model")]
        public class DeviceErrorsDormakabaSitesDisconnected : DeviceErrors
        {
            [JsonConstructorAttribute]
            protected DeviceErrorsDormakabaSitesDisconnected() { }

            public DeviceErrorsDormakabaSitesDisconnected(
                string createdAt = default,
                string errorCode = default,
                bool isConnectedAccountError = default,
                bool isDeviceError = default,
                string message = default
            )
            {
                CreatedAt = createdAt;
                ErrorCode = errorCode;
                IsConnectedAccountError = isConnectedAccountError;
                IsDeviceError = isDeviceError;
                Message = message;
            }

            /// <summary>
            /// Date and time at which Seam created the error.
            /// </summary>
            [DataMember(Name = "created_at", IsRequired = false, EmitDefaultValue = false)]
            public override string CreatedAt { get; set; }

            [DataMember(Name = "error_code", IsRequired = true, EmitDefaultValue = false)]
            public override string ErrorCode { get; } = "dormakaba_sites_disconnected";

            /// <summary>
            /// Indicates that the error is a [connected account](https://docs.seam.co/api/connected_accounts) error.
            /// </summary>
            [DataMember(
                Name = "is_connected_account_error",
                IsRequired = false,
                EmitDefaultValue = false
            )]
            public bool IsConnectedAccountError { get; set; }

            /// <summary>
            /// Indicates that the error is not a device error.
            /// </summary>
            [DataMember(Name = "is_device_error", IsRequired = false, EmitDefaultValue = false)]
            public bool IsDeviceError { get; set; }

            /// <summary>
            /// Detailed description of the error. Provides insights into the issue and potentially how to rectify it.
            /// </summary>
            [DataMember(Name = "message", IsRequired = false, EmitDefaultValue = false)]
            public override string Message { get; set; }

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

        [DataContract(Name = "seamModel_deviceErrorsDeviceOffline_model")]
        public class DeviceErrorsDeviceOffline : DeviceErrors
        {
            [JsonConstructorAttribute]
            protected DeviceErrorsDeviceOffline() { }

            public DeviceErrorsDeviceOffline(
                string createdAt = default,
                string errorCode = default,
                bool isDeviceError = default,
                string message = default
            )
            {
                CreatedAt = createdAt;
                ErrorCode = errorCode;
                IsDeviceError = isDeviceError;
                Message = message;
            }

            /// <summary>
            /// Date and time at which Seam created the error.
            /// </summary>
            [DataMember(Name = "created_at", IsRequired = false, EmitDefaultValue = false)]
            public override string CreatedAt { get; set; }

            [DataMember(Name = "error_code", IsRequired = true, EmitDefaultValue = false)]
            public override string ErrorCode { get; } = "device_offline";

            /// <summary>
            /// Indicates that the error is a device error.
            /// </summary>
            [DataMember(Name = "is_device_error", IsRequired = false, EmitDefaultValue = false)]
            public bool IsDeviceError { get; set; }

            /// <summary>
            /// Detailed description of the error. Provides insights into the issue and potentially how to rectify it.
            /// </summary>
            [DataMember(Name = "message", IsRequired = false, EmitDefaultValue = false)]
            public override string Message { get; set; }

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

        [DataContract(Name = "seamModel_deviceErrorsDeviceRemoved_model")]
        public class DeviceErrorsDeviceRemoved : DeviceErrors
        {
            [JsonConstructorAttribute]
            protected DeviceErrorsDeviceRemoved() { }

            public DeviceErrorsDeviceRemoved(
                string createdAt = default,
                string errorCode = default,
                bool isDeviceError = default,
                string message = default
            )
            {
                CreatedAt = createdAt;
                ErrorCode = errorCode;
                IsDeviceError = isDeviceError;
                Message = message;
            }

            /// <summary>
            /// Date and time at which Seam created the error.
            /// </summary>
            [DataMember(Name = "created_at", IsRequired = false, EmitDefaultValue = false)]
            public override string CreatedAt { get; set; }

            [DataMember(Name = "error_code", IsRequired = true, EmitDefaultValue = false)]
            public override string ErrorCode { get; } = "device_removed";

            /// <summary>
            /// Indicates that the error is a device error.
            /// </summary>
            [DataMember(Name = "is_device_error", IsRequired = false, EmitDefaultValue = false)]
            public bool IsDeviceError { get; set; }

            /// <summary>
            /// Detailed description of the error. Provides insights into the issue and potentially how to rectify it.
            /// </summary>
            [DataMember(Name = "message", IsRequired = false, EmitDefaultValue = false)]
            public override string Message { get; set; }

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

        [DataContract(Name = "seamModel_deviceErrorsHubDisconnected_model")]
        public class DeviceErrorsHubDisconnected : DeviceErrors
        {
            [JsonConstructorAttribute]
            protected DeviceErrorsHubDisconnected() { }

            public DeviceErrorsHubDisconnected(
                string createdAt = default,
                string errorCode = default,
                bool isDeviceError = default,
                string message = default
            )
            {
                CreatedAt = createdAt;
                ErrorCode = errorCode;
                IsDeviceError = isDeviceError;
                Message = message;
            }

            /// <summary>
            /// Date and time at which Seam created the error.
            /// </summary>
            [DataMember(Name = "created_at", IsRequired = false, EmitDefaultValue = false)]
            public override string CreatedAt { get; set; }

            [DataMember(Name = "error_code", IsRequired = true, EmitDefaultValue = false)]
            public override string ErrorCode { get; } = "hub_disconnected";

            /// <summary>
            /// Indicates that the error is a device error.
            /// </summary>
            [DataMember(Name = "is_device_error", IsRequired = false, EmitDefaultValue = false)]
            public bool IsDeviceError { get; set; }

            /// <summary>
            /// Detailed description of the error. Provides insights into the issue and potentially how to rectify it.
            /// </summary>
            [DataMember(Name = "message", IsRequired = false, EmitDefaultValue = false)]
            public override string Message { get; set; }

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

        [DataContract(Name = "seamModel_deviceErrorsDeviceDisconnected_model")]
        public class DeviceErrorsDeviceDisconnected : DeviceErrors
        {
            [JsonConstructorAttribute]
            protected DeviceErrorsDeviceDisconnected() { }

            public DeviceErrorsDeviceDisconnected(
                string createdAt = default,
                string errorCode = default,
                bool isDeviceError = default,
                string message = default
            )
            {
                CreatedAt = createdAt;
                ErrorCode = errorCode;
                IsDeviceError = isDeviceError;
                Message = message;
            }

            /// <summary>
            /// Date and time at which Seam created the error.
            /// </summary>
            [DataMember(Name = "created_at", IsRequired = false, EmitDefaultValue = false)]
            public override string CreatedAt { get; set; }

            [DataMember(Name = "error_code", IsRequired = true, EmitDefaultValue = false)]
            public override string ErrorCode { get; } = "device_disconnected";

            /// <summary>
            /// Indicates that the error is a device error.
            /// </summary>
            [DataMember(Name = "is_device_error", IsRequired = false, EmitDefaultValue = false)]
            public bool IsDeviceError { get; set; }

            /// <summary>
            /// Detailed description of the error. Provides insights into the issue and potentially how to rectify it.
            /// </summary>
            [DataMember(Name = "message", IsRequired = false, EmitDefaultValue = false)]
            public override string Message { get; set; }

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

        [DataContract(Name = "seamModel_deviceErrorsEmptyBackupAccessCodePool_model")]
        public class DeviceErrorsEmptyBackupAccessCodePool : DeviceErrors
        {
            [JsonConstructorAttribute]
            protected DeviceErrorsEmptyBackupAccessCodePool() { }

            public DeviceErrorsEmptyBackupAccessCodePool(
                string createdAt = default,
                string errorCode = default,
                bool isDeviceError = default,
                string message = default
            )
            {
                CreatedAt = createdAt;
                ErrorCode = errorCode;
                IsDeviceError = isDeviceError;
                Message = message;
            }

            /// <summary>
            /// Date and time at which Seam created the error.
            /// </summary>
            [DataMember(Name = "created_at", IsRequired = false, EmitDefaultValue = false)]
            public override string CreatedAt { get; set; }

            [DataMember(Name = "error_code", IsRequired = true, EmitDefaultValue = false)]
            public override string ErrorCode { get; } = "empty_backup_access_code_pool";

            /// <summary>
            /// Indicates that the error is a device error.
            /// </summary>
            [DataMember(Name = "is_device_error", IsRequired = false, EmitDefaultValue = false)]
            public bool IsDeviceError { get; set; }

            /// <summary>
            /// Detailed description of the error. Provides insights into the issue and potentially how to rectify it.
            /// </summary>
            [DataMember(Name = "message", IsRequired = false, EmitDefaultValue = false)]
            public override string Message { get; set; }

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

        [DataContract(Name = "seamModel_deviceErrorsAugustLockNotAuthorized_model")]
        public class DeviceErrorsAugustLockNotAuthorized : DeviceErrors
        {
            [JsonConstructorAttribute]
            protected DeviceErrorsAugustLockNotAuthorized() { }

            public DeviceErrorsAugustLockNotAuthorized(
                string createdAt = default,
                string errorCode = default,
                bool isDeviceError = default,
                string message = default
            )
            {
                CreatedAt = createdAt;
                ErrorCode = errorCode;
                IsDeviceError = isDeviceError;
                Message = message;
            }

            /// <summary>
            /// Date and time at which Seam created the error.
            /// </summary>
            [DataMember(Name = "created_at", IsRequired = false, EmitDefaultValue = false)]
            public override string CreatedAt { get; set; }

            [DataMember(Name = "error_code", IsRequired = true, EmitDefaultValue = false)]
            public override string ErrorCode { get; } = "august_lock_not_authorized";

            /// <summary>
            /// Indicates that the error is a device error.
            /// </summary>
            [DataMember(Name = "is_device_error", IsRequired = false, EmitDefaultValue = false)]
            public bool IsDeviceError { get; set; }

            /// <summary>
            /// Detailed description of the error. Provides insights into the issue and potentially how to rectify it.
            /// </summary>
            [DataMember(Name = "message", IsRequired = false, EmitDefaultValue = false)]
            public override string Message { get; set; }

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

        [DataContract(Name = "seamModel_deviceErrorsMissingDeviceCredentials_model")]
        public class DeviceErrorsMissingDeviceCredentials : DeviceErrors
        {
            [JsonConstructorAttribute]
            protected DeviceErrorsMissingDeviceCredentials() { }

            public DeviceErrorsMissingDeviceCredentials(
                string createdAt = default,
                string errorCode = default,
                bool isDeviceError = default,
                string message = default
            )
            {
                CreatedAt = createdAt;
                ErrorCode = errorCode;
                IsDeviceError = isDeviceError;
                Message = message;
            }

            /// <summary>
            /// Date and time at which Seam created the error.
            /// </summary>
            [DataMember(Name = "created_at", IsRequired = false, EmitDefaultValue = false)]
            public override string CreatedAt { get; set; }

            [DataMember(Name = "error_code", IsRequired = true, EmitDefaultValue = false)]
            public override string ErrorCode { get; } = "missing_device_credentials";

            /// <summary>
            /// Indicates that the error is a device error.
            /// </summary>
            [DataMember(Name = "is_device_error", IsRequired = false, EmitDefaultValue = false)]
            public bool IsDeviceError { get; set; }

            /// <summary>
            /// Detailed description of the error. Provides insights into the issue and potentially how to rectify it.
            /// </summary>
            [DataMember(Name = "message", IsRequired = false, EmitDefaultValue = false)]
            public override string Message { get; set; }

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

        [DataContract(Name = "seamModel_deviceErrorsAuxiliaryHeatRunning_model")]
        public class DeviceErrorsAuxiliaryHeatRunning : DeviceErrors
        {
            [JsonConstructorAttribute]
            protected DeviceErrorsAuxiliaryHeatRunning() { }

            public DeviceErrorsAuxiliaryHeatRunning(
                string createdAt = default,
                string errorCode = default,
                bool isDeviceError = default,
                string message = default
            )
            {
                CreatedAt = createdAt;
                ErrorCode = errorCode;
                IsDeviceError = isDeviceError;
                Message = message;
            }

            /// <summary>
            /// Date and time at which Seam created the error.
            /// </summary>
            [DataMember(Name = "created_at", IsRequired = false, EmitDefaultValue = false)]
            public override string CreatedAt { get; set; }

            [DataMember(Name = "error_code", IsRequired = true, EmitDefaultValue = false)]
            public override string ErrorCode { get; } = "auxiliary_heat_running";

            /// <summary>
            /// Indicates that the error is a device error.
            /// </summary>
            [DataMember(Name = "is_device_error", IsRequired = false, EmitDefaultValue = false)]
            public bool IsDeviceError { get; set; }

            /// <summary>
            /// Detailed description of the error. Provides insights into the issue and potentially how to rectify it.
            /// </summary>
            [DataMember(Name = "message", IsRequired = false, EmitDefaultValue = false)]
            public override string Message { get; set; }

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

        [DataContract(Name = "seamModel_deviceErrorsSubscriptionRequired_model")]
        public class DeviceErrorsSubscriptionRequired : DeviceErrors
        {
            [JsonConstructorAttribute]
            protected DeviceErrorsSubscriptionRequired() { }

            public DeviceErrorsSubscriptionRequired(
                string createdAt = default,
                string errorCode = default,
                bool isDeviceError = default,
                string message = default
            )
            {
                CreatedAt = createdAt;
                ErrorCode = errorCode;
                IsDeviceError = isDeviceError;
                Message = message;
            }

            /// <summary>
            /// Date and time at which Seam created the error.
            /// </summary>
            [DataMember(Name = "created_at", IsRequired = false, EmitDefaultValue = false)]
            public override string CreatedAt { get; set; }

            [DataMember(Name = "error_code", IsRequired = true, EmitDefaultValue = false)]
            public override string ErrorCode { get; } = "subscription_required";

            /// <summary>
            /// Indicates that the error is a device error.
            /// </summary>
            [DataMember(Name = "is_device_error", IsRequired = false, EmitDefaultValue = false)]
            public bool IsDeviceError { get; set; }

            /// <summary>
            /// Detailed description of the error. Provides insights into the issue and potentially how to rectify it.
            /// </summary>
            [DataMember(Name = "message", IsRequired = false, EmitDefaultValue = false)]
            public override string Message { get; set; }

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

        [DataContract(Name = "seamModel_deviceErrorsBridgeDisconnected_model")]
        public class DeviceErrorsBridgeDisconnected : DeviceErrors
        {
            [JsonConstructorAttribute]
            protected DeviceErrorsBridgeDisconnected() { }

            public DeviceErrorsBridgeDisconnected(
                string createdAt = default,
                string errorCode = default,
                bool? isBridgeError = default,
                bool? isConnectedAccountError = default,
                string message = default
            )
            {
                CreatedAt = createdAt;
                ErrorCode = errorCode;
                IsBridgeError = isBridgeError;
                IsConnectedAccountError = isConnectedAccountError;
                Message = message;
            }

            /// <summary>
            /// Date and time at which Seam created the error.
            /// </summary>
            [DataMember(Name = "created_at", IsRequired = false, EmitDefaultValue = false)]
            public override string CreatedAt { get; set; }

            [DataMember(Name = "error_code", IsRequired = true, EmitDefaultValue = false)]
            public override string ErrorCode { get; } = "bridge_disconnected";

            /// <summary>
            /// Indicates whether the error is related to [Seam Bridge](https://docs.seam.co/capability-guides/seam-bridge).
            /// </summary>
            [DataMember(Name = "is_bridge_error", IsRequired = false, EmitDefaultValue = false)]
            public bool? IsBridgeError { get; set; }

            /// <summary>
            /// Indicates whether the error is related specifically to the connected account.
            /// </summary>
            [DataMember(
                Name = "is_connected_account_error",
                IsRequired = false,
                EmitDefaultValue = false
            )]
            public bool? IsConnectedAccountError { get; set; }

            /// <summary>
            /// Detailed description of the error. Provides insights into the issue and potentially how to rectify it.
            /// </summary>
            [DataMember(Name = "message", IsRequired = false, EmitDefaultValue = false)]
            public override string Message { get; set; }

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

        [DataContract(Name = "seamModel_deviceErrorsUnrecognized_model")]
        public class DeviceErrorsUnrecognized : DeviceErrors
        {
            [JsonConstructorAttribute]
            protected DeviceErrorsUnrecognized() { }

            public DeviceErrorsUnrecognized(
                string errorCode = default,
                string createdAt = default,
                string message = default
            )
            {
                ErrorCode = errorCode;
                CreatedAt = createdAt;
                Message = message;
            }

            [DataMember(Name = "error_code", IsRequired = true, EmitDefaultValue = false)]
            public override string ErrorCode { get; } = "unrecognized";

            /// <summary>
            /// Date and time at which Seam created the error.
            /// </summary>
            [DataMember(Name = "created_at", IsRequired = false, EmitDefaultValue = false)]
            public override string CreatedAt { get; set; }

            /// <summary>
            /// Detailed description of the error. Provides insights into the issue and potentially how to rectify it.
            /// </summary>
            [DataMember(Name = "message", IsRequired = false, EmitDefaultValue = false)]
            public override string Message { get; set; }

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

        [JsonConverter(typeof(JsonSubtypes), "warning_code")]
        [JsonSubtypes.FallBackSubType(typeof(DeviceWarningsUnrecognized))]
        [JsonSubtypes.KnownSubType(
            typeof(DeviceWarningsInsufficientPermissions),
            "insufficient_permissions"
        )]
        [JsonSubtypes.KnownSubType(
            typeof(DeviceWarningsMaxAccessCodesReached),
            "max_access_codes_reached"
        )]
        [JsonSubtypes.KnownSubType(
            typeof(DeviceWarningsUnreliableOnlineStatus),
            "unreliable_online_status"
        )]
        [JsonSubtypes.KnownSubType(
            typeof(DeviceWarningsAccessoryKeypadSetupRequired),
            "accessory_keypad_setup_required"
        )]
        [JsonSubtypes.KnownSubType(
            typeof(DeviceWarningsKeynestUnsupportedLocker),
            "keynest_unsupported_locker"
        )]
        [JsonSubtypes.KnownSubType(typeof(DeviceWarningsProviderIssue), "provider_issue")]
        [JsonSubtypes.KnownSubType(
            typeof(DeviceWarningsHubRequiredForAdditionalCapabilities),
            "hub_required_for_additional_capabilities"
        )]
        [JsonSubtypes.KnownSubType(
            typeof(DeviceWarningsTwoNDeviceMissingTimezone),
            "two_n_device_missing_timezone"
        )]
        [JsonSubtypes.KnownSubType(typeof(DeviceWarningsTimeZoneMismatch), "time_zone_mismatch")]
        [JsonSubtypes.KnownSubType(typeof(DeviceWarningsTimeZoneUnknown), "time_zone_unknown")]
        [JsonSubtypes.KnownSubType(
            typeof(DeviceWarningsUltraloqTimeZoneUnknown),
            "ultraloq_time_zone_unknown"
        )]
        [JsonSubtypes.KnownSubType(
            typeof(DeviceWarningsLocklyTimeZoneNotConfigured),
            "lockly_time_zone_not_configured"
        )]
        [JsonSubtypes.KnownSubType(
            typeof(DeviceWarningsUnknownIssueWithPhone),
            "unknown_issue_with_phone"
        )]
        [JsonSubtypes.KnownSubType(
            typeof(DeviceWarningsSaltoKsLockAccessCodeSupportRemoved),
            "salto_ks_lock_access_code_support_removed"
        )]
        [JsonSubtypes.KnownSubType(
            typeof(DeviceWarningsSaltoKsSubscriptionLimitAlmostReached),
            "salto_ks_subscription_limit_almost_reached"
        )]
        [JsonSubtypes.KnownSubType(typeof(DeviceWarningsPrivacyMode), "privacy_mode")]
        [JsonSubtypes.KnownSubType(
            typeof(DeviceWarningsSaltoKsPrivacyMode),
            "salto_ks_privacy_mode"
        )]
        [JsonSubtypes.KnownSubType(typeof(DeviceWarningsSaltoKsOfficeMode), "salto_ks_office_mode")]
        [JsonSubtypes.KnownSubType(
            typeof(DeviceWarningsDeviceHasFlakyConnection),
            "device_has_flaky_connection"
        )]
        [JsonSubtypes.KnownSubType(
            typeof(DeviceWarningsScheduledMaintenanceWindow),
            "scheduled_maintenance_window"
        )]
        [JsonSubtypes.KnownSubType(
            typeof(DeviceWarningsDeviceCommunicationDegraded),
            "device_communication_degraded"
        )]
        [JsonSubtypes.KnownSubType(
            typeof(DeviceWarningsTemperatureThresholdExceeded),
            "temperature_threshold_exceeded"
        )]
        [JsonSubtypes.KnownSubType(typeof(DeviceWarningsPowerSavingMode), "power_saving_mode")]
        [JsonSubtypes.KnownSubType(
            typeof(DeviceWarningsTtlockWeakGatewaySignal),
            "ttlock_weak_gateway_signal"
        )]
        [JsonSubtypes.KnownSubType(
            typeof(DeviceWarningsTtlockLockGatewayUnlockingNotEnabled),
            "ttlock_lock_gateway_unlocking_not_enabled"
        )]
        [JsonSubtypes.KnownSubType(
            typeof(DeviceWarningsThirdPartyIntegrationDetected),
            "third_party_integration_detected"
        )]
        [JsonSubtypes.KnownSubType(
            typeof(DeviceWarningsManyActiveBackupCodes),
            "many_active_backup_codes"
        )]
        [JsonSubtypes.KnownSubType(
            typeof(DeviceWarningsPartialBackupAccessCodePool),
            "partial_backup_access_code_pool"
        )]
        public abstract class DeviceWarnings
        {
            public abstract string WarningCode { get; }

            public abstract string CreatedAt { get; set; }

            public abstract string Message { get; set; }

            public abstract override string ToString();
        }

        [DataContract(Name = "seamModel_deviceWarningsPartialBackupAccessCodePool_model")]
        public class DeviceWarningsPartialBackupAccessCodePool : DeviceWarnings
        {
            [JsonConstructorAttribute]
            protected DeviceWarningsPartialBackupAccessCodePool() { }

            public DeviceWarningsPartialBackupAccessCodePool(
                string createdAt = default,
                string message = default,
                string warningCode = default
            )
            {
                CreatedAt = createdAt;
                Message = message;
                WarningCode = warningCode;
            }

            /// <summary>
            /// Date and time at which Seam created the warning.
            /// </summary>
            [DataMember(Name = "created_at", IsRequired = false, EmitDefaultValue = false)]
            public override string CreatedAt { get; set; }

            /// <summary>
            /// Detailed description of the warning. Provides insights into the issue and potentially how to rectify it.
            /// </summary>
            [DataMember(Name = "message", IsRequired = false, EmitDefaultValue = false)]
            public override string Message { get; set; }

            [DataMember(Name = "warning_code", IsRequired = true, EmitDefaultValue = false)]
            public override string WarningCode { get; } = "partial_backup_access_code_pool";

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

        [DataContract(Name = "seamModel_deviceWarningsManyActiveBackupCodes_model")]
        public class DeviceWarningsManyActiveBackupCodes : DeviceWarnings
        {
            [JsonConstructorAttribute]
            protected DeviceWarningsManyActiveBackupCodes() { }

            public DeviceWarningsManyActiveBackupCodes(
                string createdAt = default,
                string message = default,
                string warningCode = default
            )
            {
                CreatedAt = createdAt;
                Message = message;
                WarningCode = warningCode;
            }

            /// <summary>
            /// Date and time at which Seam created the warning.
            /// </summary>
            [DataMember(Name = "created_at", IsRequired = false, EmitDefaultValue = false)]
            public override string CreatedAt { get; set; }

            /// <summary>
            /// Detailed description of the warning. Provides insights into the issue and potentially how to rectify it.
            /// </summary>
            [DataMember(Name = "message", IsRequired = false, EmitDefaultValue = false)]
            public override string Message { get; set; }

            [DataMember(Name = "warning_code", IsRequired = true, EmitDefaultValue = false)]
            public override string WarningCode { get; } = "many_active_backup_codes";

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

        [DataContract(Name = "seamModel_deviceWarningsThirdPartyIntegrationDetected_model")]
        public class DeviceWarningsThirdPartyIntegrationDetected : DeviceWarnings
        {
            [JsonConstructorAttribute]
            protected DeviceWarningsThirdPartyIntegrationDetected() { }

            public DeviceWarningsThirdPartyIntegrationDetected(
                string createdAt = default,
                string message = default,
                string warningCode = default
            )
            {
                CreatedAt = createdAt;
                Message = message;
                WarningCode = warningCode;
            }

            /// <summary>
            /// Date and time at which Seam created the warning.
            /// </summary>
            [DataMember(Name = "created_at", IsRequired = false, EmitDefaultValue = false)]
            public override string CreatedAt { get; set; }

            /// <summary>
            /// Detailed description of the warning. Provides insights into the issue and potentially how to rectify it.
            /// </summary>
            [DataMember(Name = "message", IsRequired = false, EmitDefaultValue = false)]
            public override string Message { get; set; }

            [DataMember(Name = "warning_code", IsRequired = true, EmitDefaultValue = false)]
            public override string WarningCode { get; } = "third_party_integration_detected";

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

        [DataContract(Name = "seamModel_deviceWarningsTtlockLockGatewayUnlockingNotEnabled_model")]
        public class DeviceWarningsTtlockLockGatewayUnlockingNotEnabled : DeviceWarnings
        {
            [JsonConstructorAttribute]
            protected DeviceWarningsTtlockLockGatewayUnlockingNotEnabled() { }

            public DeviceWarningsTtlockLockGatewayUnlockingNotEnabled(
                string createdAt = default,
                string message = default,
                string warningCode = default
            )
            {
                CreatedAt = createdAt;
                Message = message;
                WarningCode = warningCode;
            }

            /// <summary>
            /// Date and time at which Seam created the warning.
            /// </summary>
            [DataMember(Name = "created_at", IsRequired = false, EmitDefaultValue = false)]
            public override string CreatedAt { get; set; }

            /// <summary>
            /// Detailed description of the warning. Provides insights into the issue and potentially how to rectify it.
            /// </summary>
            [DataMember(Name = "message", IsRequired = false, EmitDefaultValue = false)]
            public override string Message { get; set; }

            [DataMember(Name = "warning_code", IsRequired = true, EmitDefaultValue = false)]
            public override string WarningCode { get; } =
                "ttlock_lock_gateway_unlocking_not_enabled";

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

        [DataContract(Name = "seamModel_deviceWarningsTtlockWeakGatewaySignal_model")]
        public class DeviceWarningsTtlockWeakGatewaySignal : DeviceWarnings
        {
            [JsonConstructorAttribute]
            protected DeviceWarningsTtlockWeakGatewaySignal() { }

            public DeviceWarningsTtlockWeakGatewaySignal(
                string createdAt = default,
                string message = default,
                string warningCode = default
            )
            {
                CreatedAt = createdAt;
                Message = message;
                WarningCode = warningCode;
            }

            /// <summary>
            /// Date and time at which Seam created the warning.
            /// </summary>
            [DataMember(Name = "created_at", IsRequired = false, EmitDefaultValue = false)]
            public override string CreatedAt { get; set; }

            /// <summary>
            /// Detailed description of the warning. Provides insights into the issue and potentially how to rectify it.
            /// </summary>
            [DataMember(Name = "message", IsRequired = false, EmitDefaultValue = false)]
            public override string Message { get; set; }

            [DataMember(Name = "warning_code", IsRequired = true, EmitDefaultValue = false)]
            public override string WarningCode { get; } = "ttlock_weak_gateway_signal";

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

        [DataContract(Name = "seamModel_deviceWarningsPowerSavingMode_model")]
        public class DeviceWarningsPowerSavingMode : DeviceWarnings
        {
            [JsonConstructorAttribute]
            protected DeviceWarningsPowerSavingMode() { }

            public DeviceWarningsPowerSavingMode(
                string createdAt = default,
                string message = default,
                string warningCode = default
            )
            {
                CreatedAt = createdAt;
                Message = message;
                WarningCode = warningCode;
            }

            /// <summary>
            /// Date and time at which Seam created the warning.
            /// </summary>
            [DataMember(Name = "created_at", IsRequired = false, EmitDefaultValue = false)]
            public override string CreatedAt { get; set; }

            /// <summary>
            /// Detailed description of the warning. Provides insights into the issue and potentially how to rectify it.
            /// </summary>
            [DataMember(Name = "message", IsRequired = false, EmitDefaultValue = false)]
            public override string Message { get; set; }

            [DataMember(Name = "warning_code", IsRequired = true, EmitDefaultValue = false)]
            public override string WarningCode { get; } = "power_saving_mode";

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

        [DataContract(Name = "seamModel_deviceWarningsTemperatureThresholdExceeded_model")]
        public class DeviceWarningsTemperatureThresholdExceeded : DeviceWarnings
        {
            [JsonConstructorAttribute]
            protected DeviceWarningsTemperatureThresholdExceeded() { }

            public DeviceWarningsTemperatureThresholdExceeded(
                string createdAt = default,
                string message = default,
                string warningCode = default
            )
            {
                CreatedAt = createdAt;
                Message = message;
                WarningCode = warningCode;
            }

            /// <summary>
            /// Date and time at which Seam created the warning.
            /// </summary>
            [DataMember(Name = "created_at", IsRequired = false, EmitDefaultValue = false)]
            public override string CreatedAt { get; set; }

            /// <summary>
            /// Detailed description of the warning. Provides insights into the issue and potentially how to rectify it.
            /// </summary>
            [DataMember(Name = "message", IsRequired = false, EmitDefaultValue = false)]
            public override string Message { get; set; }

            [DataMember(Name = "warning_code", IsRequired = true, EmitDefaultValue = false)]
            public override string WarningCode { get; } = "temperature_threshold_exceeded";

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

        [DataContract(Name = "seamModel_deviceWarningsDeviceCommunicationDegraded_model")]
        public class DeviceWarningsDeviceCommunicationDegraded : DeviceWarnings
        {
            [JsonConstructorAttribute]
            protected DeviceWarningsDeviceCommunicationDegraded() { }

            public DeviceWarningsDeviceCommunicationDegraded(
                string createdAt = default,
                string message = default,
                string warningCode = default
            )
            {
                CreatedAt = createdAt;
                Message = message;
                WarningCode = warningCode;
            }

            /// <summary>
            /// Date and time at which Seam created the warning.
            /// </summary>
            [DataMember(Name = "created_at", IsRequired = false, EmitDefaultValue = false)]
            public override string CreatedAt { get; set; }

            /// <summary>
            /// Detailed description of the warning. Provides insights into the issue and potentially how to rectify it.
            /// </summary>
            [DataMember(Name = "message", IsRequired = false, EmitDefaultValue = false)]
            public override string Message { get; set; }

            [DataMember(Name = "warning_code", IsRequired = true, EmitDefaultValue = false)]
            public override string WarningCode { get; } = "device_communication_degraded";

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

        [DataContract(Name = "seamModel_deviceWarningsScheduledMaintenanceWindow_model")]
        public class DeviceWarningsScheduledMaintenanceWindow : DeviceWarnings
        {
            [JsonConstructorAttribute]
            protected DeviceWarningsScheduledMaintenanceWindow() { }

            public DeviceWarningsScheduledMaintenanceWindow(
                string createdAt = default,
                string message = default,
                string warningCode = default
            )
            {
                CreatedAt = createdAt;
                Message = message;
                WarningCode = warningCode;
            }

            /// <summary>
            /// Date and time at which Seam created the warning.
            /// </summary>
            [DataMember(Name = "created_at", IsRequired = false, EmitDefaultValue = false)]
            public override string CreatedAt { get; set; }

            /// <summary>
            /// Detailed description of the warning. Provides insights into the issue and potentially how to rectify it.
            /// </summary>
            [DataMember(Name = "message", IsRequired = false, EmitDefaultValue = false)]
            public override string Message { get; set; }

            [DataMember(Name = "warning_code", IsRequired = true, EmitDefaultValue = false)]
            public override string WarningCode { get; } = "scheduled_maintenance_window";

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

        [DataContract(Name = "seamModel_deviceWarningsDeviceHasFlakyConnection_model")]
        public class DeviceWarningsDeviceHasFlakyConnection : DeviceWarnings
        {
            [JsonConstructorAttribute]
            protected DeviceWarningsDeviceHasFlakyConnection() { }

            public DeviceWarningsDeviceHasFlakyConnection(
                string createdAt = default,
                string message = default,
                string warningCode = default
            )
            {
                CreatedAt = createdAt;
                Message = message;
                WarningCode = warningCode;
            }

            /// <summary>
            /// Date and time at which Seam created the warning.
            /// </summary>
            [DataMember(Name = "created_at", IsRequired = false, EmitDefaultValue = false)]
            public override string CreatedAt { get; set; }

            /// <summary>
            /// Detailed description of the warning. Provides insights into the issue and potentially how to rectify it.
            /// </summary>
            [DataMember(Name = "message", IsRequired = false, EmitDefaultValue = false)]
            public override string Message { get; set; }

            [DataMember(Name = "warning_code", IsRequired = true, EmitDefaultValue = false)]
            public override string WarningCode { get; } = "device_has_flaky_connection";

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

        [DataContract(Name = "seamModel_deviceWarningsSaltoKsOfficeMode_model")]
        public class DeviceWarningsSaltoKsOfficeMode : DeviceWarnings
        {
            [JsonConstructorAttribute]
            protected DeviceWarningsSaltoKsOfficeMode() { }

            public DeviceWarningsSaltoKsOfficeMode(
                string createdAt = default,
                string message = default,
                string warningCode = default
            )
            {
                CreatedAt = createdAt;
                Message = message;
                WarningCode = warningCode;
            }

            /// <summary>
            /// Date and time at which Seam created the warning.
            /// </summary>
            [DataMember(Name = "created_at", IsRequired = false, EmitDefaultValue = false)]
            public override string CreatedAt { get; set; }

            /// <summary>
            /// Detailed description of the warning. Provides insights into the issue and potentially how to rectify it.
            /// </summary>
            [DataMember(Name = "message", IsRequired = false, EmitDefaultValue = false)]
            public override string Message { get; set; }

            [DataMember(Name = "warning_code", IsRequired = true, EmitDefaultValue = false)]
            public override string WarningCode { get; } = "salto_ks_office_mode";

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

        [DataContract(Name = "seamModel_deviceWarningsSaltoKsPrivacyMode_model")]
        public class DeviceWarningsSaltoKsPrivacyMode : DeviceWarnings
        {
            [JsonConstructorAttribute]
            protected DeviceWarningsSaltoKsPrivacyMode() { }

            public DeviceWarningsSaltoKsPrivacyMode(
                string createdAt = default,
                string message = default,
                string warningCode = default
            )
            {
                CreatedAt = createdAt;
                Message = message;
                WarningCode = warningCode;
            }

            /// <summary>
            /// Date and time at which Seam created the warning.
            /// </summary>
            [DataMember(Name = "created_at", IsRequired = false, EmitDefaultValue = false)]
            public override string CreatedAt { get; set; }

            /// <summary>
            /// Detailed description of the warning. Provides insights into the issue and potentially how to rectify it.
            /// </summary>
            [DataMember(Name = "message", IsRequired = false, EmitDefaultValue = false)]
            public override string Message { get; set; }

            [DataMember(Name = "warning_code", IsRequired = true, EmitDefaultValue = false)]
            public override string WarningCode { get; } = "salto_ks_privacy_mode";

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

        [DataContract(Name = "seamModel_deviceWarningsPrivacyMode_model")]
        public class DeviceWarningsPrivacyMode : DeviceWarnings
        {
            [JsonConstructorAttribute]
            protected DeviceWarningsPrivacyMode() { }

            public DeviceWarningsPrivacyMode(
                string createdAt = default,
                string message = default,
                string warningCode = default
            )
            {
                CreatedAt = createdAt;
                Message = message;
                WarningCode = warningCode;
            }

            /// <summary>
            /// Date and time at which Seam created the warning.
            /// </summary>
            [DataMember(Name = "created_at", IsRequired = false, EmitDefaultValue = false)]
            public override string CreatedAt { get; set; }

            /// <summary>
            /// Detailed description of the warning. Provides insights into the issue and potentially how to rectify it.
            /// </summary>
            [DataMember(Name = "message", IsRequired = false, EmitDefaultValue = false)]
            public override string Message { get; set; }

            [DataMember(Name = "warning_code", IsRequired = true, EmitDefaultValue = false)]
            public override string WarningCode { get; } = "privacy_mode";

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

        [DataContract(Name = "seamModel_deviceWarningsSaltoKsSubscriptionLimitAlmostReached_model")]
        public class DeviceWarningsSaltoKsSubscriptionLimitAlmostReached : DeviceWarnings
        {
            [JsonConstructorAttribute]
            protected DeviceWarningsSaltoKsSubscriptionLimitAlmostReached() { }

            public DeviceWarningsSaltoKsSubscriptionLimitAlmostReached(
                string createdAt = default,
                string message = default,
                string warningCode = default
            )
            {
                CreatedAt = createdAt;
                Message = message;
                WarningCode = warningCode;
            }

            /// <summary>
            /// Date and time at which Seam created the warning.
            /// </summary>
            [DataMember(Name = "created_at", IsRequired = false, EmitDefaultValue = false)]
            public override string CreatedAt { get; set; }

            /// <summary>
            /// Detailed description of the warning. Provides insights into the issue and potentially how to rectify it.
            /// </summary>
            [DataMember(Name = "message", IsRequired = false, EmitDefaultValue = false)]
            public override string Message { get; set; }

            [DataMember(Name = "warning_code", IsRequired = true, EmitDefaultValue = false)]
            public override string WarningCode { get; } =
                "salto_ks_subscription_limit_almost_reached";

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

        [DataContract(Name = "seamModel_deviceWarningsSaltoKsLockAccessCodeSupportRemoved_model")]
        public class DeviceWarningsSaltoKsLockAccessCodeSupportRemoved : DeviceWarnings
        {
            [JsonConstructorAttribute]
            protected DeviceWarningsSaltoKsLockAccessCodeSupportRemoved() { }

            public DeviceWarningsSaltoKsLockAccessCodeSupportRemoved(
                string createdAt = default,
                string message = default,
                string warningCode = default
            )
            {
                CreatedAt = createdAt;
                Message = message;
                WarningCode = warningCode;
            }

            /// <summary>
            /// Date and time at which Seam created the warning.
            /// </summary>
            [DataMember(Name = "created_at", IsRequired = false, EmitDefaultValue = false)]
            public override string CreatedAt { get; set; }

            /// <summary>
            /// Detailed description of the warning. Provides insights into the issue and potentially how to rectify it.
            /// </summary>
            [DataMember(Name = "message", IsRequired = false, EmitDefaultValue = false)]
            public override string Message { get; set; }

            [DataMember(Name = "warning_code", IsRequired = true, EmitDefaultValue = false)]
            public override string WarningCode { get; } =
                "salto_ks_lock_access_code_support_removed";

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

        [DataContract(Name = "seamModel_deviceWarningsUnknownIssueWithPhone_model")]
        public class DeviceWarningsUnknownIssueWithPhone : DeviceWarnings
        {
            [JsonConstructorAttribute]
            protected DeviceWarningsUnknownIssueWithPhone() { }

            public DeviceWarningsUnknownIssueWithPhone(
                string createdAt = default,
                string message = default,
                string warningCode = default
            )
            {
                CreatedAt = createdAt;
                Message = message;
                WarningCode = warningCode;
            }

            /// <summary>
            /// Date and time at which Seam created the warning.
            /// </summary>
            [DataMember(Name = "created_at", IsRequired = false, EmitDefaultValue = false)]
            public override string CreatedAt { get; set; }

            /// <summary>
            /// Detailed description of the warning. Provides insights into the issue and potentially how to rectify it.
            /// </summary>
            [DataMember(Name = "message", IsRequired = false, EmitDefaultValue = false)]
            public override string Message { get; set; }

            [DataMember(Name = "warning_code", IsRequired = true, EmitDefaultValue = false)]
            public override string WarningCode { get; } = "unknown_issue_with_phone";

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

        [DataContract(Name = "seamModel_deviceWarningsLocklyTimeZoneNotConfigured_model")]
        public class DeviceWarningsLocklyTimeZoneNotConfigured : DeviceWarnings
        {
            [JsonConstructorAttribute]
            protected DeviceWarningsLocklyTimeZoneNotConfigured() { }

            public DeviceWarningsLocklyTimeZoneNotConfigured(
                string createdAt = default,
                string message = default,
                string warningCode = default
            )
            {
                CreatedAt = createdAt;
                Message = message;
                WarningCode = warningCode;
            }

            /// <summary>
            /// Date and time at which Seam created the warning.
            /// </summary>
            [DataMember(Name = "created_at", IsRequired = false, EmitDefaultValue = false)]
            public override string CreatedAt { get; set; }

            /// <summary>
            /// Detailed description of the warning. Provides insights into the issue and potentially how to rectify it.
            /// </summary>
            [DataMember(Name = "message", IsRequired = false, EmitDefaultValue = false)]
            public override string Message { get; set; }

            [DataMember(Name = "warning_code", IsRequired = true, EmitDefaultValue = false)]
            public override string WarningCode { get; } = "lockly_time_zone_not_configured";

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

        [DataContract(Name = "seamModel_deviceWarningsUltraloqTimeZoneUnknown_model")]
        public class DeviceWarningsUltraloqTimeZoneUnknown : DeviceWarnings
        {
            [JsonConstructorAttribute]
            protected DeviceWarningsUltraloqTimeZoneUnknown() { }

            public DeviceWarningsUltraloqTimeZoneUnknown(
                string createdAt = default,
                string message = default,
                string warningCode = default
            )
            {
                CreatedAt = createdAt;
                Message = message;
                WarningCode = warningCode;
            }

            /// <summary>
            /// Date and time at which Seam created the warning.
            /// </summary>
            [DataMember(Name = "created_at", IsRequired = false, EmitDefaultValue = false)]
            public override string CreatedAt { get; set; }

            /// <summary>
            /// Detailed description of the warning. Provides insights into the issue and potentially how to rectify it.
            /// </summary>
            [DataMember(Name = "message", IsRequired = false, EmitDefaultValue = false)]
            public override string Message { get; set; }

            [DataMember(Name = "warning_code", IsRequired = true, EmitDefaultValue = false)]
            public override string WarningCode { get; } = "ultraloq_time_zone_unknown";

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

        [DataContract(Name = "seamModel_deviceWarningsTimeZoneUnknown_model")]
        public class DeviceWarningsTimeZoneUnknown : DeviceWarnings
        {
            [JsonConstructorAttribute]
            protected DeviceWarningsTimeZoneUnknown() { }

            public DeviceWarningsTimeZoneUnknown(
                string createdAt = default,
                string message = default,
                string warningCode = default
            )
            {
                CreatedAt = createdAt;
                Message = message;
                WarningCode = warningCode;
            }

            /// <summary>
            /// Date and time at which Seam created the warning.
            /// </summary>
            [DataMember(Name = "created_at", IsRequired = false, EmitDefaultValue = false)]
            public override string CreatedAt { get; set; }

            /// <summary>
            /// Detailed description of the warning. Provides insights into the issue and potentially how to rectify it.
            /// </summary>
            [DataMember(Name = "message", IsRequired = false, EmitDefaultValue = false)]
            public override string Message { get; set; }

            [DataMember(Name = "warning_code", IsRequired = true, EmitDefaultValue = false)]
            public override string WarningCode { get; } = "time_zone_unknown";

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

        [DataContract(Name = "seamModel_deviceWarningsTimeZoneMismatch_model")]
        public class DeviceWarningsTimeZoneMismatch : DeviceWarnings
        {
            [JsonConstructorAttribute]
            protected DeviceWarningsTimeZoneMismatch() { }

            public DeviceWarningsTimeZoneMismatch(
                string createdAt = default,
                string message = default,
                string warningCode = default
            )
            {
                CreatedAt = createdAt;
                Message = message;
                WarningCode = warningCode;
            }

            /// <summary>
            /// Date and time at which Seam created the warning.
            /// </summary>
            [DataMember(Name = "created_at", IsRequired = false, EmitDefaultValue = false)]
            public override string CreatedAt { get; set; }

            /// <summary>
            /// Detailed description of the warning. Provides insights into the issue and potentially how to rectify it.
            /// </summary>
            [DataMember(Name = "message", IsRequired = false, EmitDefaultValue = false)]
            public override string Message { get; set; }

            [DataMember(Name = "warning_code", IsRequired = true, EmitDefaultValue = false)]
            public override string WarningCode { get; } = "time_zone_mismatch";

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

        [DataContract(Name = "seamModel_deviceWarningsTwoNDeviceMissingTimezone_model")]
        public class DeviceWarningsTwoNDeviceMissingTimezone : DeviceWarnings
        {
            [JsonConstructorAttribute]
            protected DeviceWarningsTwoNDeviceMissingTimezone() { }

            public DeviceWarningsTwoNDeviceMissingTimezone(
                string createdAt = default,
                string message = default,
                string warningCode = default
            )
            {
                CreatedAt = createdAt;
                Message = message;
                WarningCode = warningCode;
            }

            /// <summary>
            /// Date and time at which Seam created the warning.
            /// </summary>
            [DataMember(Name = "created_at", IsRequired = false, EmitDefaultValue = false)]
            public override string CreatedAt { get; set; }

            /// <summary>
            /// Detailed description of the warning. Provides insights into the issue and potentially how to rectify it.
            /// </summary>
            [DataMember(Name = "message", IsRequired = false, EmitDefaultValue = false)]
            public override string Message { get; set; }

            [DataMember(Name = "warning_code", IsRequired = true, EmitDefaultValue = false)]
            public override string WarningCode { get; } = "two_n_device_missing_timezone";

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

        [DataContract(Name = "seamModel_deviceWarningsHubRequiredForAdditionalCapabilities_model")]
        public class DeviceWarningsHubRequiredForAdditionalCapabilities : DeviceWarnings
        {
            [JsonConstructorAttribute]
            protected DeviceWarningsHubRequiredForAdditionalCapabilities() { }

            public DeviceWarningsHubRequiredForAdditionalCapabilities(
                string createdAt = default,
                string message = default,
                string warningCode = default
            )
            {
                CreatedAt = createdAt;
                Message = message;
                WarningCode = warningCode;
            }

            /// <summary>
            /// Date and time at which Seam created the warning.
            /// </summary>
            [DataMember(Name = "created_at", IsRequired = false, EmitDefaultValue = false)]
            public override string CreatedAt { get; set; }

            /// <summary>
            /// Detailed description of the warning. Provides insights into the issue and potentially how to rectify it.
            /// </summary>
            [DataMember(Name = "message", IsRequired = false, EmitDefaultValue = false)]
            public override string Message { get; set; }

            [DataMember(Name = "warning_code", IsRequired = true, EmitDefaultValue = false)]
            public override string WarningCode { get; } =
                "hub_required_for_additional_capabilities";

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

        [DataContract(Name = "seamModel_deviceWarningsProviderIssue_model")]
        public class DeviceWarningsProviderIssue : DeviceWarnings
        {
            [JsonConstructorAttribute]
            protected DeviceWarningsProviderIssue() { }

            public DeviceWarningsProviderIssue(
                string createdAt = default,
                string message = default,
                string warningCode = default
            )
            {
                CreatedAt = createdAt;
                Message = message;
                WarningCode = warningCode;
            }

            /// <summary>
            /// Date and time at which Seam created the warning.
            /// </summary>
            [DataMember(Name = "created_at", IsRequired = false, EmitDefaultValue = false)]
            public override string CreatedAt { get; set; }

            /// <summary>
            /// Detailed description of the warning. Provides insights into the issue and potentially how to rectify it.
            /// </summary>
            [DataMember(Name = "message", IsRequired = false, EmitDefaultValue = false)]
            public override string Message { get; set; }

            [DataMember(Name = "warning_code", IsRequired = true, EmitDefaultValue = false)]
            public override string WarningCode { get; } = "provider_issue";

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

        [DataContract(Name = "seamModel_deviceWarningsKeynestUnsupportedLocker_model")]
        public class DeviceWarningsKeynestUnsupportedLocker : DeviceWarnings
        {
            [JsonConstructorAttribute]
            protected DeviceWarningsKeynestUnsupportedLocker() { }

            public DeviceWarningsKeynestUnsupportedLocker(
                string createdAt = default,
                string message = default,
                string warningCode = default
            )
            {
                CreatedAt = createdAt;
                Message = message;
                WarningCode = warningCode;
            }

            /// <summary>
            /// Date and time at which Seam created the warning.
            /// </summary>
            [DataMember(Name = "created_at", IsRequired = false, EmitDefaultValue = false)]
            public override string CreatedAt { get; set; }

            /// <summary>
            /// Detailed description of the warning. Provides insights into the issue and potentially how to rectify it.
            /// </summary>
            [DataMember(Name = "message", IsRequired = false, EmitDefaultValue = false)]
            public override string Message { get; set; }

            [DataMember(Name = "warning_code", IsRequired = true, EmitDefaultValue = false)]
            public override string WarningCode { get; } = "keynest_unsupported_locker";

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

        [DataContract(Name = "seamModel_deviceWarningsAccessoryKeypadSetupRequired_model")]
        public class DeviceWarningsAccessoryKeypadSetupRequired : DeviceWarnings
        {
            [JsonConstructorAttribute]
            protected DeviceWarningsAccessoryKeypadSetupRequired() { }

            public DeviceWarningsAccessoryKeypadSetupRequired(
                string createdAt = default,
                string message = default,
                string warningCode = default
            )
            {
                CreatedAt = createdAt;
                Message = message;
                WarningCode = warningCode;
            }

            /// <summary>
            /// Date and time at which Seam created the warning.
            /// </summary>
            [DataMember(Name = "created_at", IsRequired = false, EmitDefaultValue = false)]
            public override string CreatedAt { get; set; }

            /// <summary>
            /// Detailed description of the warning. Provides insights into the issue and potentially how to rectify it.
            /// </summary>
            [DataMember(Name = "message", IsRequired = false, EmitDefaultValue = false)]
            public override string Message { get; set; }

            [DataMember(Name = "warning_code", IsRequired = true, EmitDefaultValue = false)]
            public override string WarningCode { get; } = "accessory_keypad_setup_required";

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

        [DataContract(Name = "seamModel_deviceWarningsUnreliableOnlineStatus_model")]
        public class DeviceWarningsUnreliableOnlineStatus : DeviceWarnings
        {
            [JsonConstructorAttribute]
            protected DeviceWarningsUnreliableOnlineStatus() { }

            public DeviceWarningsUnreliableOnlineStatus(
                string createdAt = default,
                string message = default,
                string warningCode = default
            )
            {
                CreatedAt = createdAt;
                Message = message;
                WarningCode = warningCode;
            }

            /// <summary>
            /// Date and time at which Seam created the warning.
            /// </summary>
            [DataMember(Name = "created_at", IsRequired = false, EmitDefaultValue = false)]
            public override string CreatedAt { get; set; }

            /// <summary>
            /// Detailed description of the warning. Provides insights into the issue and potentially how to rectify it.
            /// </summary>
            [DataMember(Name = "message", IsRequired = false, EmitDefaultValue = false)]
            public override string Message { get; set; }

            [DataMember(Name = "warning_code", IsRequired = true, EmitDefaultValue = false)]
            public override string WarningCode { get; } = "unreliable_online_status";

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

        [DataContract(Name = "seamModel_deviceWarningsMaxAccessCodesReached_model")]
        public class DeviceWarningsMaxAccessCodesReached : DeviceWarnings
        {
            [JsonConstructorAttribute]
            protected DeviceWarningsMaxAccessCodesReached() { }

            public DeviceWarningsMaxAccessCodesReached(
                int activeAccessCodeCount = default,
                string createdAt = default,
                int maxActiveAccessCodeCount = default,
                string message = default,
                string warningCode = default
            )
            {
                ActiveAccessCodeCount = activeAccessCodeCount;
                CreatedAt = createdAt;
                MaxActiveAccessCodeCount = maxActiveAccessCodeCount;
                Message = message;
                WarningCode = warningCode;
            }

            /// <summary>
            /// Number of active access codes on the device when the warning was set.
            /// </summary>
            [DataMember(
                Name = "active_access_code_count",
                IsRequired = false,
                EmitDefaultValue = false
            )]
            public int ActiveAccessCodeCount { get; set; }

            /// <summary>
            /// Date and time at which Seam created the warning.
            /// </summary>
            [DataMember(Name = "created_at", IsRequired = false, EmitDefaultValue = false)]
            public override string CreatedAt { get; set; }

            /// <summary>
            /// Maximum number of active access codes supported by the device.
            /// </summary>
            [DataMember(
                Name = "max_active_access_code_count",
                IsRequired = false,
                EmitDefaultValue = false
            )]
            public int MaxActiveAccessCodeCount { get; set; }

            /// <summary>
            /// Detailed description of the warning. Provides insights into the issue and potentially how to rectify it.
            /// </summary>
            [DataMember(Name = "message", IsRequired = false, EmitDefaultValue = false)]
            public override string Message { get; set; }

            [DataMember(Name = "warning_code", IsRequired = true, EmitDefaultValue = false)]
            public override string WarningCode { get; } = "max_access_codes_reached";

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

        [DataContract(Name = "seamModel_deviceWarningsInsufficientPermissions_model")]
        public class DeviceWarningsInsufficientPermissions : DeviceWarnings
        {
            [JsonConstructorAttribute]
            protected DeviceWarningsInsufficientPermissions() { }

            public DeviceWarningsInsufficientPermissions(
                string createdAt = default,
                string message = default,
                string warningCode = default
            )
            {
                CreatedAt = createdAt;
                Message = message;
                WarningCode = warningCode;
            }

            /// <summary>
            /// Date and time at which Seam created the warning.
            /// </summary>
            [DataMember(Name = "created_at", IsRequired = false, EmitDefaultValue = false)]
            public override string CreatedAt { get; set; }

            /// <summary>
            /// Detailed description of the warning. Provides insights into the issue and potentially how to rectify it.
            /// </summary>
            [DataMember(Name = "message", IsRequired = false, EmitDefaultValue = false)]
            public override string Message { get; set; }

            [DataMember(Name = "warning_code", IsRequired = true, EmitDefaultValue = false)]
            public override string WarningCode { get; } = "insufficient_permissions";

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

        [DataContract(Name = "seamModel_deviceWarningsUnrecognized_model")]
        public class DeviceWarningsUnrecognized : DeviceWarnings
        {
            [JsonConstructorAttribute]
            protected DeviceWarningsUnrecognized() { }

            public DeviceWarningsUnrecognized(
                string warningCode = default,
                string createdAt = default,
                string message = default
            )
            {
                WarningCode = warningCode;
                CreatedAt = createdAt;
                Message = message;
            }

            [DataMember(Name = "warning_code", IsRequired = true, EmitDefaultValue = false)]
            public override string WarningCode { get; } = "unrecognized";

            /// <summary>
            /// Date and time at which Seam created the warning.
            /// </summary>
            [DataMember(Name = "created_at", IsRequired = false, EmitDefaultValue = false)]
            public override string CreatedAt { get; set; }

            /// <summary>
            /// Detailed description of the warning. Provides insights into the issue and potentially how to rectify it.
            /// </summary>
            [DataMember(Name = "message", IsRequired = false, EmitDefaultValue = false)]
            public override string Message { get; set; }

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

        /// <summary>
        /// Indicates whether the lock supports configuring automatic locking.
        /// </summary>
        [DataMember(Name = "can_configure_auto_lock", IsRequired = false, EmitDefaultValue = false)]
        public bool? CanConfigureAutoLock { get; set; }

        /// <summary>
        /// Indicates whether the thermostat supports cooling.
        /// </summary>
        [DataMember(Name = "can_hvac_cool", IsRequired = false, EmitDefaultValue = false)]
        public bool? CanHvacCool { get; set; }

        /// <summary>
        /// Indicates whether the thermostat supports heating.
        /// </summary>
        [DataMember(Name = "can_hvac_heat", IsRequired = false, EmitDefaultValue = false)]
        public bool? CanHvacHeat { get; set; }

        /// <summary>
        /// Indicates whether the thermostat supports simultaneous heating and cooling.
        /// </summary>
        [DataMember(Name = "can_hvac_heat_cool", IsRequired = false, EmitDefaultValue = false)]
        public bool? CanHvacHeatCool { get; set; }

        /// <summary>
        /// Indicates whether the device supports programming offline access codes.
        /// </summary>
        [DataMember(
            Name = "can_program_offline_access_codes",
            IsRequired = false,
            EmitDefaultValue = false
        )]
        public bool? CanProgramOfflineAccessCodes { get; set; }

        /// <summary>
        /// Indicates whether the device supports programming online access codes.
        /// </summary>
        [DataMember(
            Name = "can_program_online_access_codes",
            IsRequired = false,
            EmitDefaultValue = false
        )]
        public bool? CanProgramOnlineAccessCodes { get; set; }

        /// <summary>
        /// Indicates whether the thermostat supports different climate programs for each day of the week.
        /// </summary>
        [DataMember(
            Name = "can_program_thermostat_programs_as_different_each_day",
            IsRequired = false,
            EmitDefaultValue = false
        )]
        public bool? CanProgramThermostatProgramsAsDifferentEachDay { get; set; }

        /// <summary>
        /// Indicates whether the thermostat supports a single climate program applied to every day.
        /// </summary>
        [DataMember(
            Name = "can_program_thermostat_programs_as_same_each_day",
            IsRequired = false,
            EmitDefaultValue = false
        )]
        public bool? CanProgramThermostatProgramsAsSameEachDay { get; set; }

        /// <summary>
        /// Indicates whether the thermostat supports weekday/weekend climate programs.
        /// </summary>
        [DataMember(
            Name = "can_program_thermostat_programs_as_weekday_weekend",
            IsRequired = false,
            EmitDefaultValue = false
        )]
        public bool? CanProgramThermostatProgramsAsWeekdayWeekend { get; set; }

        /// <summary>
        /// Indicates whether the device supports remote locking.
        /// </summary>
        [DataMember(Name = "can_remotely_lock", IsRequired = false, EmitDefaultValue = false)]
        public bool? CanRemotelyLock { get; set; }

        /// <summary>
        /// Indicates whether the device supports remote unlocking.
        /// </summary>
        [DataMember(Name = "can_remotely_unlock", IsRequired = false, EmitDefaultValue = false)]
        public bool? CanRemotelyUnlock { get; set; }

        /// <summary>
        /// Indicates whether the thermostat supports running climate programs.
        /// </summary>
        [DataMember(
            Name = "can_run_thermostat_programs",
            IsRequired = false,
            EmitDefaultValue = false
        )]
        public bool? CanRunThermostatPrograms { get; set; }

        /// <summary>
        /// Indicates whether the device supports simulating connection in a sandbox.
        /// </summary>
        [DataMember(Name = "can_simulate_connection", IsRequired = false, EmitDefaultValue = false)]
        public bool? CanSimulateConnection { get; set; }

        /// <summary>
        /// Indicates whether the device supports simulating disconnection in a sandbox.
        /// </summary>
        [DataMember(
            Name = "can_simulate_disconnection",
            IsRequired = false,
            EmitDefaultValue = false
        )]
        public bool? CanSimulateDisconnection { get; set; }

        /// <summary>
        /// Indicates whether the hub supports simulating connection in a sandbox.
        /// </summary>
        [DataMember(
            Name = "can_simulate_hub_connection",
            IsRequired = false,
            EmitDefaultValue = false
        )]
        public bool? CanSimulateHubConnection { get; set; }

        /// <summary>
        /// Indicates whether the hub supports simulating disconnection in a sandbox.
        /// </summary>
        [DataMember(
            Name = "can_simulate_hub_disconnection",
            IsRequired = false,
            EmitDefaultValue = false
        )]
        public bool? CanSimulateHubDisconnection { get; set; }

        /// <summary>
        /// Indicates whether the device supports simulating a paid subscription in a sandbox.
        /// </summary>
        [DataMember(
            Name = "can_simulate_paid_subscription",
            IsRequired = false,
            EmitDefaultValue = false
        )]
        public bool? CanSimulatePaidSubscription { get; set; }

        /// <summary>
        /// Indicates whether the device supports simulating removal in a sandbox.
        /// </summary>
        [DataMember(Name = "can_simulate_removal", IsRequired = false, EmitDefaultValue = false)]
        public bool? CanSimulateRemoval { get; set; }

        /// <summary>
        /// Indicates whether the thermostat can be turned off.
        /// </summary>
        [DataMember(Name = "can_turn_off_hvac", IsRequired = false, EmitDefaultValue = false)]
        public bool? CanTurnOffHvac { get; set; }

        /// <summary>
        /// Indicates whether the lock supports unlocking with an access code.
        /// </summary>
        [DataMember(Name = "can_unlock_with_code", IsRequired = false, EmitDefaultValue = false)]
        public bool? CanUnlockWithCode { get; set; }

        /// <summary>
        /// Collection of capabilities that the device supports when connected to Seam. Values are `access_code`, which indicates that the device can manage and utilize digital PIN codes for secure access; `lock`, which indicates that the device controls a door locking mechanism, enabling the remote opening and closing of doors and other entry points; `noise_detection`, which indicates that the device supports monitoring and responding to ambient noise levels; `thermostat`, which indicates that the device can regulate and adjust indoor temperatures; `battery`, which indicates that the device can manage battery life and health; and `phone`, which indicates that the device is a mobile device, such as a smartphone. **Important:** Superseded by [capability flags](https://docs.seam.co/capability-guides/device-and-system-capabilities#capability-flags).
        /// </summary>
        [DataMember(Name = "capabilities_supported", IsRequired = false, EmitDefaultValue = false)]
        public List<Device.CapabilitiesSupportedEnum> CapabilitiesSupported { get; set; }

        /// <summary>
        /// Unique identifier for the account associated with the device.
        /// </summary>
        [DataMember(Name = "connected_account_id", IsRequired = false, EmitDefaultValue = false)]
        public string ConnectedAccountId { get; set; }

        /// <summary>
        /// Date and time at which the device object was created.
        /// </summary>
        [DataMember(Name = "created_at", IsRequired = false, EmitDefaultValue = false)]
        public string CreatedAt { get; set; }

        /// <summary>
        /// Set of key:value pairs. Adding custom metadata to a resource, such as a [Connect Webview](https://docs.seam.co/core-concepts/connect-webviews/attaching-custom-data-to-the-connect-webview), [connected account](https://docs.seam.co/core-concepts/connected-accounts/adding-custom-metadata-to-a-connected-account), or [device](https://docs.seam.co/core-concepts/devices/adding-custom-metadata-to-a-device), enables you to store custom information, like customer details or internal IDs from your application.
        /// </summary>
        [DataMember(Name = "custom_metadata", IsRequired = false, EmitDefaultValue = false)]
        public object CustomMetadata { get; set; }

        /// <summary>
        /// ID of the device.
        /// </summary>
        [DataMember(Name = "device_id", IsRequired = false, EmitDefaultValue = false)]
        public string DeviceId { get; set; }

        /// <summary>
        /// Manufacturer of the device. Represents the hardware brand, which may differ from the provider.
        /// </summary>
        [DataMember(Name = "device_manufacturer", IsRequired = false, EmitDefaultValue = false)]
        public DeviceDeviceManufacturer? DeviceManufacturer { get; set; }

        /// <summary>
        /// Provider of the device. Represents the third-party service through which the device is controlled.
        /// </summary>
        [DataMember(Name = "device_provider", IsRequired = false, EmitDefaultValue = false)]
        public DeviceDeviceProvider? DeviceProvider { get; set; }

        /// <summary>
        /// Type of the device.
        /// </summary>
        [DataMember(Name = "device_type", IsRequired = false, EmitDefaultValue = false)]
        public Device.DeviceTypeEnum DeviceType { get; set; }

        /// <summary>
        /// Display name of the device, defaults to nickname (if it is set) or `properties.appearance.name`, otherwise. Enables administrators and users to identify the device easily, especially when there are numerous devices.
        /// </summary>
        [DataMember(Name = "display_name", IsRequired = false, EmitDefaultValue = false)]
        public string DisplayName { get; set; }

        /// <summary>
        /// Array of errors associated with the device. Each error object within the array contains two fields: `error_code` and `message`. `error_code` is a string that uniquely identifies the type of error, enabling quick recognition and categorization of the issue. `message` provides a more detailed description of the error, offering insights into the issue and potentially how to rectify it.
        /// </summary>
        [DataMember(Name = "errors", IsRequired = false, EmitDefaultValue = false)]
        public List<DeviceErrors> Errors { get; set; }

        /// <summary>
        /// Indicates whether Seam manages the device. See also [Managed and Unmanaged Devices](https://docs.seam.co/core-concepts/devices/managed-and-unmanaged-devices).
        /// </summary>
        [DataMember(Name = "is_managed", IsRequired = false, EmitDefaultValue = false)]
        public bool IsManaged { get; set; }

        /// <summary>
        /// Location information for the device.
        /// </summary>
        [DataMember(Name = "location", IsRequired = false, EmitDefaultValue = false)]
        public DeviceLocation? Location { get; set; }

        /// <summary>
        /// Optional nickname to describe the device, settable through Seam.
        /// </summary>
        [DataMember(Name = "nickname", IsRequired = false, EmitDefaultValue = false)]
        public string? Nickname { get; set; }

        /// <summary>
        /// Properties of the device.
        /// </summary>
        [DataMember(Name = "properties", IsRequired = false, EmitDefaultValue = false)]
        public DeviceProperties Properties { get; set; }

        /// <summary>
        /// IDs of the spaces the device is in.
        /// </summary>
        [DataMember(Name = "space_ids", IsRequired = false, EmitDefaultValue = false)]
        public List<string> SpaceIds { get; set; }

        /// <summary>
        /// Array of warnings associated with the device. Each warning object within the array contains two fields: `warning_code` and `message`. `warning_code` is a string that uniquely identifies the type of warning, enabling quick recognition and categorization of the issue. `message` provides a more detailed description of the warning, offering insights into the issue and potentially how to rectify it.
        /// </summary>
        [DataMember(Name = "warnings", IsRequired = false, EmitDefaultValue = false)]
        public List<DeviceWarnings> Warnings { get; set; }

        /// <summary>
        /// Unique identifier for the Seam workspace associated with the device.
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

    [DataContract(Name = "seamModel_deviceDeviceManufacturer_model")]
    public class DeviceDeviceManufacturer
    {
        [JsonConstructorAttribute]
        protected DeviceDeviceManufacturer() { }

        public DeviceDeviceManufacturer(
            string displayName = default,
            string? imageUrl = default,
            string manufacturer = default
        )
        {
            DisplayName = displayName;
            ImageUrl = imageUrl;
            Manufacturer = manufacturer;
        }

        /// <summary>
        /// Display name for the manufacturer, such as `August`, `Yale`, `Salto`, and so on.
        /// </summary>
        [DataMember(Name = "display_name", IsRequired = false, EmitDefaultValue = false)]
        public string DisplayName { get; set; }

        /// <summary>
        /// Image URL for the manufacturer logo.
        /// </summary>
        [DataMember(Name = "image_url", IsRequired = false, EmitDefaultValue = false)]
        public string? ImageUrl { get; set; }

        /// <summary>
        /// Manufacturer identifier, such as `august`, `yale`, `salto`, and so on.
        /// </summary>
        [DataMember(Name = "manufacturer", IsRequired = false, EmitDefaultValue = false)]
        public string Manufacturer { get; set; }

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

    [DataContract(Name = "seamModel_deviceDeviceProvider_model")]
    public class DeviceDeviceProvider
    {
        [JsonConstructorAttribute]
        protected DeviceDeviceProvider() { }

        public DeviceDeviceProvider(
            string deviceProviderName = default,
            string displayName = default,
            string? imageUrl = default,
            string providerCategory = default
        )
        {
            DeviceProviderName = deviceProviderName;
            DisplayName = displayName;
            ImageUrl = imageUrl;
            ProviderCategory = providerCategory;
        }

        /// <summary>
        /// Device provider name. Corresponds to the integration type, such as `august`, `schlage`, `yale_access`, and so on.
        /// </summary>
        [DataMember(Name = "device_provider_name", IsRequired = false, EmitDefaultValue = false)]
        public string DeviceProviderName { get; set; }

        /// <summary>
        /// Display name for the device provider type.
        /// </summary>
        [DataMember(Name = "display_name", IsRequired = false, EmitDefaultValue = false)]
        public string DisplayName { get; set; }

        /// <summary>
        /// Image URL for the device provider.
        /// </summary>
        [DataMember(Name = "image_url", IsRequired = false, EmitDefaultValue = false)]
        public string? ImageUrl { get; set; }

        /// <summary>
        /// Provider category. Indicates the third-party provider type, such as `stable`, for stable integrations, or `internal`, for internal integrations.
        /// </summary>
        [DataMember(Name = "provider_category", IsRequired = false, EmitDefaultValue = false)]
        public string ProviderCategory { get; set; }

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

        public DeviceLocation(
            string? locationName = default,
            string? timeZone = default,
            string? timezone = default
        )
        {
            LocationName = locationName;
            TimeZone = timeZone;
            Timezone = timezone;
        }

        /// <summary>
        /// Name of the device location.
        /// </summary>
        [DataMember(Name = "location_name", IsRequired = false, EmitDefaultValue = false)]
        public string? LocationName { get; set; }

        /// <summary>
        /// Time zone of the device location.
        /// </summary>
        [DataMember(Name = "time_zone", IsRequired = false, EmitDefaultValue = false)]
        public string? TimeZone { get; set; }

        /// <summary>
        /// Time zone of the device location.
        /// </summary>
        [Obsolete("Use `time_zone` instead.")]
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

    [DataContract(Name = "seamModel_deviceProperties_model")]
    public class DeviceProperties
    {
        [JsonConstructorAttribute]
        protected DeviceProperties() { }

        public DeviceProperties(
            DevicePropertiesAccessoryKeypad? accessoryKeypad = default,
            DevicePropertiesAppearance appearance = default,
            DevicePropertiesBattery? battery = default,
            float? batteryLevel = default,
            List<string>? currentlyTriggeringNoiseThresholdIds = default,
            bool? hasDirectPower = default,
            string? imageAltText = default,
            string? imageUrl = default,
            string? manufacturer = default,
            DevicePropertiesModel model = default,
            string name = default,
            float? noiseLevelDecibels = default,
            bool? offlineAccessCodesEnabled = default,
            bool online = default,
            bool? onlineAccessCodesEnabled = default,
            string? serialNumber = default,
            bool? supportsAccessoryKeypad = default,
            bool? supportsOfflineAccessCodes = default,
            DevicePropertiesAssaAbloyCredentialServiceMetadata? assaAbloyCredentialServiceMetadata =
                default,
            DevicePropertiesSaltoSpaceCredentialServiceMetadata? saltoSpaceCredentialServiceMetadata =
                default,
            DevicePropertiesAkilesMetadata? akilesMetadata = default,
            DevicePropertiesAssaAbloyVostioMetadata? assaAbloyVostioMetadata = default,
            DevicePropertiesAugustMetadata? augustMetadata = default,
            DevicePropertiesAvigilonAltaMetadata? avigilonAltaMetadata = default,
            DevicePropertiesBrivoMetadata? brivoMetadata = default,
            DevicePropertiesControlbywebMetadata? controlbywebMetadata = default,
            DevicePropertiesDormakabaOracodeMetadata? dormakabaOracodeMetadata = default,
            DevicePropertiesEcobeeMetadata? ecobeeMetadata = default,
            DevicePropertiesFourSuitesMetadata? fourSuitesMetadata = default,
            DevicePropertiesGenieMetadata? genieMetadata = default,
            DevicePropertiesHoneywellResideoMetadata? honeywellResideoMetadata = default,
            DevicePropertiesIglooMetadata? iglooMetadata = default,
            DevicePropertiesIgloohomeMetadata? igloohomeMetadata = default,
            DevicePropertiesKeynestMetadata? keynestMetadata = default,
            DevicePropertiesKisiMetadata? kisiMetadata = default,
            DevicePropertiesKorelockMetadata? korelockMetadata = default,
            DevicePropertiesKwiksetMetadata? kwiksetMetadata = default,
            DevicePropertiesLocklyMetadata? locklyMetadata = default,
            DevicePropertiesMinutMetadata? minutMetadata = default,
            DevicePropertiesNestMetadata? nestMetadata = default,
            DevicePropertiesNoiseawareMetadata? noiseawareMetadata = default,
            DevicePropertiesNukiMetadata? nukiMetadata = default,
            DevicePropertiesOmnitecMetadata? omnitecMetadata = default,
            DevicePropertiesRingMetadata? ringMetadata = default,
            DevicePropertiesSaltoKsMetadata? saltoKsMetadata = default,
            DevicePropertiesSaltoMetadata? saltoMetadata = default,
            DevicePropertiesSchlageMetadata? schlageMetadata = default,
            DevicePropertiesSeamBridgeMetadata? seamBridgeMetadata = default,
            DevicePropertiesSensiMetadata? sensiMetadata = default,
            DevicePropertiesSmartthingsMetadata? smartthingsMetadata = default,
            DevicePropertiesTadoMetadata? tadoMetadata = default,
            DevicePropertiesTedeeMetadata? tedeeMetadata = default,
            DevicePropertiesTtlockMetadata? ttlockMetadata = default,
            DevicePropertiesTwoNMetadata? twoNMetadata = default,
            DevicePropertiesUltraloqMetadata? ultraloqMetadata = default,
            DevicePropertiesVisionlineMetadata? visionlineMetadata = default,
            DevicePropertiesWyzeMetadata? wyzeMetadata = default,
            float? autoLockDelaySeconds = default,
            bool? autoLockEnabled = default,
            bool? backupAccessCodePoolEnabled = default,
            List<DevicePropertiesCodeConstraints>? codeConstraints = default,
            bool? doorOpen = default,
            bool? hasNativeEntryEvents = default,
            DevicePropertiesKeypadBattery? keypadBattery = default,
            bool? locked = default,
            float? maxActiveCodesSupported = default,
            List<DevicePropertiesOfflineTimeFrameOptions>? offlineTimeFrameOptions = default,
            List<DevicePropertiesOnlineTimeFrameOptions>? onlineTimeFrameOptions = default,
            List<float>? supportedCodeLengths = default,
            bool? supportsBackupAccessCodePool = default,
            DevicePropertiesActiveThermostatSchedule? activeThermostatSchedule = default,
            string? activeThermostatScheduleId = default,
            List<DeviceProperties.AvailableClimatePresetModesEnum>? availableClimatePresetModes =
                default,
            List<DevicePropertiesAvailableClimatePresets>? availableClimatePresets = default,
            List<DeviceProperties.AvailableFanModeSettingsEnum>? availableFanModeSettings = default,
            List<DeviceProperties.AvailableHvacModeSettingsEnum>? availableHvacModeSettings =
                default,
            DevicePropertiesCurrentClimateSetting? currentClimateSetting = default,
            DevicePropertiesDefaultClimateSetting? defaultClimateSetting = default,
            string? fallbackClimatePresetKey = default,
            DeviceProperties.FanModeSettingEnum? fanModeSetting = default,
            bool? isCooling = default,
            bool? isFanRunning = default,
            bool? isHeating = default,
            bool? isTemporaryManualOverrideActive = default,
            float? maxCoolingSetPointCelsius = default,
            float? maxCoolingSetPointFahrenheit = default,
            float? maxHeatingSetPointCelsius = default,
            float? maxHeatingSetPointFahrenheit = default,
            float? maxThermostatDailyProgramPeriodsPerDay = default,
            float? maxUniqueClimatePresetsPerThermostatWeeklyProgram = default,
            float? minCoolingSetPointCelsius = default,
            float? minCoolingSetPointFahrenheit = default,
            float? minHeatingCoolingDeltaCelsius = default,
            float? minHeatingCoolingDeltaFahrenheit = default,
            float? minHeatingSetPointCelsius = default,
            float? minHeatingSetPointFahrenheit = default,
            float? relativeHumidity = default,
            float? temperatureCelsius = default,
            float? temperatureFahrenheit = default,
            DevicePropertiesTemperatureThreshold? temperatureThreshold = default,
            float? thermostatDailyProgramPeriodPrecisionMinutes = default,
            List<DevicePropertiesThermostatDailyPrograms>? thermostatDailyPrograms = default,
            DevicePropertiesThermostatWeeklyProgram? thermostatWeeklyProgram = default
        )
        {
            AccessoryKeypad = accessoryKeypad;
            Appearance = appearance;
            Battery = battery;
            BatteryLevel = batteryLevel;
            CurrentlyTriggeringNoiseThresholdIds = currentlyTriggeringNoiseThresholdIds;
            HasDirectPower = hasDirectPower;
            ImageAltText = imageAltText;
            ImageUrl = imageUrl;
            Manufacturer = manufacturer;
            Model = model;
            Name = name;
            NoiseLevelDecibels = noiseLevelDecibels;
            OfflineAccessCodesEnabled = offlineAccessCodesEnabled;
            Online = online;
            OnlineAccessCodesEnabled = onlineAccessCodesEnabled;
            SerialNumber = serialNumber;
            SupportsAccessoryKeypad = supportsAccessoryKeypad;
            SupportsOfflineAccessCodes = supportsOfflineAccessCodes;
            AssaAbloyCredentialServiceMetadata = assaAbloyCredentialServiceMetadata;
            SaltoSpaceCredentialServiceMetadata = saltoSpaceCredentialServiceMetadata;
            AkilesMetadata = akilesMetadata;
            AssaAbloyVostioMetadata = assaAbloyVostioMetadata;
            AugustMetadata = augustMetadata;
            AvigilonAltaMetadata = avigilonAltaMetadata;
            BrivoMetadata = brivoMetadata;
            ControlbywebMetadata = controlbywebMetadata;
            DormakabaOracodeMetadata = dormakabaOracodeMetadata;
            EcobeeMetadata = ecobeeMetadata;
            FourSuitesMetadata = fourSuitesMetadata;
            GenieMetadata = genieMetadata;
            HoneywellResideoMetadata = honeywellResideoMetadata;
            IglooMetadata = iglooMetadata;
            IgloohomeMetadata = igloohomeMetadata;
            KeynestMetadata = keynestMetadata;
            KisiMetadata = kisiMetadata;
            KorelockMetadata = korelockMetadata;
            KwiksetMetadata = kwiksetMetadata;
            LocklyMetadata = locklyMetadata;
            MinutMetadata = minutMetadata;
            NestMetadata = nestMetadata;
            NoiseawareMetadata = noiseawareMetadata;
            NukiMetadata = nukiMetadata;
            OmnitecMetadata = omnitecMetadata;
            RingMetadata = ringMetadata;
            SaltoKsMetadata = saltoKsMetadata;
            SaltoMetadata = saltoMetadata;
            SchlageMetadata = schlageMetadata;
            SeamBridgeMetadata = seamBridgeMetadata;
            SensiMetadata = sensiMetadata;
            SmartthingsMetadata = smartthingsMetadata;
            TadoMetadata = tadoMetadata;
            TedeeMetadata = tedeeMetadata;
            TtlockMetadata = ttlockMetadata;
            TwoNMetadata = twoNMetadata;
            UltraloqMetadata = ultraloqMetadata;
            VisionlineMetadata = visionlineMetadata;
            WyzeMetadata = wyzeMetadata;
            AutoLockDelaySeconds = autoLockDelaySeconds;
            AutoLockEnabled = autoLockEnabled;
            BackupAccessCodePoolEnabled = backupAccessCodePoolEnabled;
            CodeConstraints = codeConstraints;
            DoorOpen = doorOpen;
            HasNativeEntryEvents = hasNativeEntryEvents;
            KeypadBattery = keypadBattery;
            Locked = locked;
            MaxActiveCodesSupported = maxActiveCodesSupported;
            OfflineTimeFrameOptions = offlineTimeFrameOptions;
            OnlineTimeFrameOptions = onlineTimeFrameOptions;
            SupportedCodeLengths = supportedCodeLengths;
            SupportsBackupAccessCodePool = supportsBackupAccessCodePool;
            ActiveThermostatSchedule = activeThermostatSchedule;
            ActiveThermostatScheduleId = activeThermostatScheduleId;
            AvailableClimatePresetModes = availableClimatePresetModes;
            AvailableClimatePresets = availableClimatePresets;
            AvailableFanModeSettings = availableFanModeSettings;
            AvailableHvacModeSettings = availableHvacModeSettings;
            CurrentClimateSetting = currentClimateSetting;
            DefaultClimateSetting = defaultClimateSetting;
            FallbackClimatePresetKey = fallbackClimatePresetKey;
            FanModeSetting = fanModeSetting;
            IsCooling = isCooling;
            IsFanRunning = isFanRunning;
            IsHeating = isHeating;
            IsTemporaryManualOverrideActive = isTemporaryManualOverrideActive;
            MaxCoolingSetPointCelsius = maxCoolingSetPointCelsius;
            MaxCoolingSetPointFahrenheit = maxCoolingSetPointFahrenheit;
            MaxHeatingSetPointCelsius = maxHeatingSetPointCelsius;
            MaxHeatingSetPointFahrenheit = maxHeatingSetPointFahrenheit;
            MaxThermostatDailyProgramPeriodsPerDay = maxThermostatDailyProgramPeriodsPerDay;
            MaxUniqueClimatePresetsPerThermostatWeeklyProgram =
                maxUniqueClimatePresetsPerThermostatWeeklyProgram;
            MinCoolingSetPointCelsius = minCoolingSetPointCelsius;
            MinCoolingSetPointFahrenheit = minCoolingSetPointFahrenheit;
            MinHeatingCoolingDeltaCelsius = minHeatingCoolingDeltaCelsius;
            MinHeatingCoolingDeltaFahrenheit = minHeatingCoolingDeltaFahrenheit;
            MinHeatingSetPointCelsius = minHeatingSetPointCelsius;
            MinHeatingSetPointFahrenheit = minHeatingSetPointFahrenheit;
            RelativeHumidity = relativeHumidity;
            TemperatureCelsius = temperatureCelsius;
            TemperatureFahrenheit = temperatureFahrenheit;
            TemperatureThreshold = temperatureThreshold;
            ThermostatDailyProgramPeriodPrecisionMinutes =
                thermostatDailyProgramPeriodPrecisionMinutes;
            ThermostatDailyPrograms = thermostatDailyPrograms;
            ThermostatWeeklyProgram = thermostatWeeklyProgram;
        }

        /// <summary>
        /// Climate preset modes that the thermostat supports, such as &quot;home&quot;, &quot;away&quot;, &quot;wake&quot;, &quot;sleep&quot;, &quot;occupied&quot;, and &quot;unoccupied&quot;.
        /// </summary>
        [JsonConverter(typeof(SafeStringEnumConverter))]
        public enum AvailableClimatePresetModesEnum
        {
            [EnumMember(Value = "unrecognized")]
            Unrecognized = 0,

            [EnumMember(Value = "home")]
            Home = 1,

            [EnumMember(Value = "away")]
            Away = 2,

            [EnumMember(Value = "wake")]
            Wake = 3,

            [EnumMember(Value = "sleep")]
            Sleep = 4,

            [EnumMember(Value = "occupied")]
            Occupied = 5,

            [EnumMember(Value = "unoccupied")]
            Unoccupied = 6,
        }

        /// <summary>
        /// Fan mode settings that the thermostat supports.
        /// </summary>
        [JsonConverter(typeof(SafeStringEnumConverter))]
        public enum AvailableFanModeSettingsEnum
        {
            [EnumMember(Value = "unrecognized")]
            Unrecognized = 0,

            [EnumMember(Value = "auto")]
            Auto = 1,

            [EnumMember(Value = "on")]
            On = 2,

            [EnumMember(Value = "circulate")]
            Circulate = 3,
        }

        /// <summary>
        /// HVAC mode settings that the thermostat supports.
        /// </summary>
        [JsonConverter(typeof(SafeStringEnumConverter))]
        public enum AvailableHvacModeSettingsEnum
        {
            [EnumMember(Value = "unrecognized")]
            Unrecognized = 0,

            [EnumMember(Value = "off")]
            Off = 1,

            [EnumMember(Value = "heat")]
            Heat = 2,

            [EnumMember(Value = "cool")]
            Cool = 3,

            [EnumMember(Value = "heat_cool")]
            HeatCool = 4,

            [EnumMember(Value = "eco")]
            Eco = 5,
        }

        [JsonConverter(typeof(SafeStringEnumConverter))]
        public enum FanModeSettingEnum
        {
            [EnumMember(Value = "unrecognized")]
            Unrecognized = 0,

            [EnumMember(Value = "auto")]
            Auto = 1,

            [EnumMember(Value = "on")]
            On = 2,

            [EnumMember(Value = "circulate")]
            Circulate = 3,
        }

        /// <summary>
        /// Accessory keypad properties and state.
        /// </summary>
        [DataMember(Name = "accessory_keypad", IsRequired = false, EmitDefaultValue = false)]
        public DevicePropertiesAccessoryKeypad? AccessoryKeypad { get; set; }

        /// <summary>
        /// Appearance-related properties, as reported by the device.
        /// </summary>
        [DataMember(Name = "appearance", IsRequired = false, EmitDefaultValue = false)]
        public DevicePropertiesAppearance Appearance { get; set; }

        /// <summary>
        /// Represents the current status of the battery charge level.
        /// </summary>
        [DataMember(Name = "battery", IsRequired = false, EmitDefaultValue = false)]
        public DevicePropertiesBattery? Battery { get; set; }

        /// <summary>
        /// Indicates the battery level of the device as a decimal value between 0 and 1, inclusive.
        /// </summary>
        [DataMember(Name = "battery_level", IsRequired = false, EmitDefaultValue = false)]
        public float? BatteryLevel { get; set; }

        /// <summary>
        /// Array of noise threshold IDs that are currently triggering.
        /// </summary>
        [DataMember(
            Name = "currently_triggering_noise_threshold_ids",
            IsRequired = false,
            EmitDefaultValue = false
        )]
        public List<string>? CurrentlyTriggeringNoiseThresholdIds { get; set; }

        /// <summary>
        /// Indicates whether the device has direct power.
        /// </summary>
        [DataMember(Name = "has_direct_power", IsRequired = false, EmitDefaultValue = false)]
        public bool? HasDirectPower { get; set; }

        /// <summary>
        /// Alt text for the device image.
        /// </summary>
        [DataMember(Name = "image_alt_text", IsRequired = false, EmitDefaultValue = false)]
        public string? ImageAltText { get; set; }

        /// <summary>
        /// Image URL for the device.
        /// </summary>
        [DataMember(Name = "image_url", IsRequired = false, EmitDefaultValue = false)]
        public string? ImageUrl { get; set; }

        /// <summary>
        /// Manufacturer of the device. When a device, such as a smart lock, is connected through a smart hub, the manufacturer of the device might be different from that of the smart hub.
        /// </summary>
        [DataMember(Name = "manufacturer", IsRequired = false, EmitDefaultValue = false)]
        public string? Manufacturer { get; set; }

        /// <summary>
        /// Device model-related properties.
        /// </summary>
        [DataMember(Name = "model", IsRequired = false, EmitDefaultValue = false)]
        public DevicePropertiesModel Model { get; set; }

        /// <summary>
        /// Name of the device.
        /// </summary>
        [Obsolete("use device.display_name instead")]
        [DataMember(Name = "name", IsRequired = false, EmitDefaultValue = false)]
        public string Name { get; set; }

        /// <summary>
        /// Indicates current noise level in decibels, if the device supports noise detection.
        /// </summary>
        [DataMember(Name = "noise_level_decibels", IsRequired = false, EmitDefaultValue = false)]
        public float? NoiseLevelDecibels { get; set; }

        /// <summary>
        /// Indicates whether it is currently possible to use offline access codes for the device.
        /// </summary>
        [Obsolete("use device.can_program_offline_access_codes")]
        [DataMember(
            Name = "offline_access_codes_enabled",
            IsRequired = false,
            EmitDefaultValue = false
        )]
        public bool? OfflineAccessCodesEnabled { get; set; }

        /// <summary>
        /// Indicates whether the device is online.
        /// </summary>
        [DataMember(Name = "online", IsRequired = false, EmitDefaultValue = false)]
        public bool Online { get; set; }

        /// <summary>
        /// Indicates whether it is currently possible to use online access codes for the device.
        /// </summary>
        [Obsolete("use device.can_program_online_access_codes")]
        [DataMember(
            Name = "online_access_codes_enabled",
            IsRequired = false,
            EmitDefaultValue = false
        )]
        public bool? OnlineAccessCodesEnabled { get; set; }

        /// <summary>
        /// Serial number of the device.
        /// </summary>
        [DataMember(Name = "serial_number", IsRequired = false, EmitDefaultValue = false)]
        public string? SerialNumber { get; set; }

        [Obsolete("use device.properties.model.can_connect_accessory_keypad")]
        [DataMember(
            Name = "supports_accessory_keypad",
            IsRequired = false,
            EmitDefaultValue = false
        )]
        public bool? SupportsAccessoryKeypad { get; set; }

        [Obsolete("use offline_access_codes_enabled")]
        [DataMember(
            Name = "supports_offline_access_codes",
            IsRequired = false,
            EmitDefaultValue = false
        )]
        public bool? SupportsOfflineAccessCodes { get; set; }

        /// <summary>
        /// ASSA ABLOY Credential Service metadata for the phone.
        /// </summary>
        [DataMember(
            Name = "assa_abloy_credential_service_metadata",
            IsRequired = false,
            EmitDefaultValue = false
        )]
        public DevicePropertiesAssaAbloyCredentialServiceMetadata? AssaAbloyCredentialServiceMetadata { get; set; }

        /// <summary>
        /// Salto Space credential service metadata for the phone.
        /// </summary>
        [DataMember(
            Name = "salto_space_credential_service_metadata",
            IsRequired = false,
            EmitDefaultValue = false
        )]
        public DevicePropertiesSaltoSpaceCredentialServiceMetadata? SaltoSpaceCredentialServiceMetadata { get; set; }

        /// <summary>
        /// Metadata for an Akiles device.
        /// </summary>
        [DataMember(Name = "akiles_metadata", IsRequired = false, EmitDefaultValue = false)]
        public DevicePropertiesAkilesMetadata? AkilesMetadata { get; set; }

        /// <summary>
        /// Metadata for an ASSA ABLOY Vostio system.
        /// </summary>
        [DataMember(
            Name = "assa_abloy_vostio_metadata",
            IsRequired = false,
            EmitDefaultValue = false
        )]
        public DevicePropertiesAssaAbloyVostioMetadata? AssaAbloyVostioMetadata { get; set; }

        /// <summary>
        /// Metadata for an August device.
        /// </summary>
        [DataMember(Name = "august_metadata", IsRequired = false, EmitDefaultValue = false)]
        public DevicePropertiesAugustMetadata? AugustMetadata { get; set; }

        /// <summary>
        /// Metadata for an Avigilon Alta system.
        /// </summary>
        [DataMember(Name = "avigilon_alta_metadata", IsRequired = false, EmitDefaultValue = false)]
        public DevicePropertiesAvigilonAltaMetadata? AvigilonAltaMetadata { get; set; }

        /// <summary>
        /// Metadata for a Brivo device.
        /// </summary>
        [DataMember(Name = "brivo_metadata", IsRequired = false, EmitDefaultValue = false)]
        public DevicePropertiesBrivoMetadata? BrivoMetadata { get; set; }

        /// <summary>
        /// Metadata for a ControlByWeb device.
        /// </summary>
        [DataMember(Name = "controlbyweb_metadata", IsRequired = false, EmitDefaultValue = false)]
        public DevicePropertiesControlbywebMetadata? ControlbywebMetadata { get; set; }

        /// <summary>
        /// Metadata for a dormakaba Oracode device.
        /// </summary>
        [DataMember(
            Name = "dormakaba_oracode_metadata",
            IsRequired = false,
            EmitDefaultValue = false
        )]
        public DevicePropertiesDormakabaOracodeMetadata? DormakabaOracodeMetadata { get; set; }

        /// <summary>
        /// Metadata for an ecobee device.
        /// </summary>
        [DataMember(Name = "ecobee_metadata", IsRequired = false, EmitDefaultValue = false)]
        public DevicePropertiesEcobeeMetadata? EcobeeMetadata { get; set; }

        /// <summary>
        /// Metadata for a 4SUITES device.
        /// </summary>
        [DataMember(Name = "four_suites_metadata", IsRequired = false, EmitDefaultValue = false)]
        public DevicePropertiesFourSuitesMetadata? FourSuitesMetadata { get; set; }

        /// <summary>
        /// Metadata for a Genie device.
        /// </summary>
        [DataMember(Name = "genie_metadata", IsRequired = false, EmitDefaultValue = false)]
        public DevicePropertiesGenieMetadata? GenieMetadata { get; set; }

        /// <summary>
        /// Metadata for a Honeywell Resideo device.
        /// </summary>
        [DataMember(
            Name = "honeywell_resideo_metadata",
            IsRequired = false,
            EmitDefaultValue = false
        )]
        public DevicePropertiesHoneywellResideoMetadata? HoneywellResideoMetadata { get; set; }

        /// <summary>
        /// Metadata for an igloo device.
        /// </summary>
        [DataMember(Name = "igloo_metadata", IsRequired = false, EmitDefaultValue = false)]
        public DevicePropertiesIglooMetadata? IglooMetadata { get; set; }

        /// <summary>
        /// Metadata for an igloohome device.
        /// </summary>
        [DataMember(Name = "igloohome_metadata", IsRequired = false, EmitDefaultValue = false)]
        public DevicePropertiesIgloohomeMetadata? IgloohomeMetadata { get; set; }

        /// <summary>
        /// Metadata for a KeyNest device.
        /// </summary>
        [DataMember(Name = "keynest_metadata", IsRequired = false, EmitDefaultValue = false)]
        public DevicePropertiesKeynestMetadata? KeynestMetadata { get; set; }

        /// <summary>
        /// Metadata for a Kisi device.
        /// </summary>
        [DataMember(Name = "kisi_metadata", IsRequired = false, EmitDefaultValue = false)]
        public DevicePropertiesKisiMetadata? KisiMetadata { get; set; }

        /// <summary>
        /// Metadata for a Korelock device.
        /// </summary>
        [DataMember(Name = "korelock_metadata", IsRequired = false, EmitDefaultValue = false)]
        public DevicePropertiesKorelockMetadata? KorelockMetadata { get; set; }

        /// <summary>
        /// Metadata for a Kwikset device.
        /// </summary>
        [DataMember(Name = "kwikset_metadata", IsRequired = false, EmitDefaultValue = false)]
        public DevicePropertiesKwiksetMetadata? KwiksetMetadata { get; set; }

        /// <summary>
        /// Metadata for a Lockly device.
        /// </summary>
        [DataMember(Name = "lockly_metadata", IsRequired = false, EmitDefaultValue = false)]
        public DevicePropertiesLocklyMetadata? LocklyMetadata { get; set; }

        /// <summary>
        /// Metadata for a Minut device.
        /// </summary>
        [DataMember(Name = "minut_metadata", IsRequired = false, EmitDefaultValue = false)]
        public DevicePropertiesMinutMetadata? MinutMetadata { get; set; }

        /// <summary>
        /// Metadata for a Google Nest device.
        /// </summary>
        [DataMember(Name = "nest_metadata", IsRequired = false, EmitDefaultValue = false)]
        public DevicePropertiesNestMetadata? NestMetadata { get; set; }

        /// <summary>
        /// Metadata for a NoiseAware device.
        /// </summary>
        [DataMember(Name = "noiseaware_metadata", IsRequired = false, EmitDefaultValue = false)]
        public DevicePropertiesNoiseawareMetadata? NoiseawareMetadata { get; set; }

        /// <summary>
        /// Metadata for a Nuki device.
        /// </summary>
        [DataMember(Name = "nuki_metadata", IsRequired = false, EmitDefaultValue = false)]
        public DevicePropertiesNukiMetadata? NukiMetadata { get; set; }

        /// <summary>
        /// Metadata for an Omnitec device.
        /// </summary>
        [DataMember(Name = "omnitec_metadata", IsRequired = false, EmitDefaultValue = false)]
        public DevicePropertiesOmnitecMetadata? OmnitecMetadata { get; set; }

        /// <summary>
        /// Metadata for a Ring device.
        /// </summary>
        [DataMember(Name = "ring_metadata", IsRequired = false, EmitDefaultValue = false)]
        public DevicePropertiesRingMetadata? RingMetadata { get; set; }

        /// <summary>
        /// Metadata for a Salto KS device.
        /// </summary>
        [DataMember(Name = "salto_ks_metadata", IsRequired = false, EmitDefaultValue = false)]
        public DevicePropertiesSaltoKsMetadata? SaltoKsMetadata { get; set; }

        /// <summary>
        /// Metada for a Salto device.
        /// </summary>
        [Obsolete("Use `salto_ks_metadata ` instead.")]
        [DataMember(Name = "salto_metadata", IsRequired = false, EmitDefaultValue = false)]
        public DevicePropertiesSaltoMetadata? SaltoMetadata { get; set; }

        /// <summary>
        /// Metadata for a Schlage device.
        /// </summary>
        [DataMember(Name = "schlage_metadata", IsRequired = false, EmitDefaultValue = false)]
        public DevicePropertiesSchlageMetadata? SchlageMetadata { get; set; }

        /// <summary>
        /// Metadata for Seam Bridge.
        /// </summary>
        [DataMember(Name = "seam_bridge_metadata", IsRequired = false, EmitDefaultValue = false)]
        public DevicePropertiesSeamBridgeMetadata? SeamBridgeMetadata { get; set; }

        /// <summary>
        /// Metadata for a Sensi device.
        /// </summary>
        [DataMember(Name = "sensi_metadata", IsRequired = false, EmitDefaultValue = false)]
        public DevicePropertiesSensiMetadata? SensiMetadata { get; set; }

        /// <summary>
        /// Metadata for a SmartThings device.
        /// </summary>
        [DataMember(Name = "smartthings_metadata", IsRequired = false, EmitDefaultValue = false)]
        public DevicePropertiesSmartthingsMetadata? SmartthingsMetadata { get; set; }

        /// <summary>
        /// Metadata for a tado° device.
        /// </summary>
        [DataMember(Name = "tado_metadata", IsRequired = false, EmitDefaultValue = false)]
        public DevicePropertiesTadoMetadata? TadoMetadata { get; set; }

        /// <summary>
        /// Metadata for a Tedee device.
        /// </summary>
        [DataMember(Name = "tedee_metadata", IsRequired = false, EmitDefaultValue = false)]
        public DevicePropertiesTedeeMetadata? TedeeMetadata { get; set; }

        /// <summary>
        /// Metadata for a TTLock device.
        /// </summary>
        [DataMember(Name = "ttlock_metadata", IsRequired = false, EmitDefaultValue = false)]
        public DevicePropertiesTtlockMetadata? TtlockMetadata { get; set; }

        /// <summary>
        /// Metadata for a 2N device.
        /// </summary>
        [DataMember(Name = "two_n_metadata", IsRequired = false, EmitDefaultValue = false)]
        public DevicePropertiesTwoNMetadata? TwoNMetadata { get; set; }

        /// <summary>
        /// Metadata for an Ultraloq device.
        /// </summary>
        [DataMember(Name = "ultraloq_metadata", IsRequired = false, EmitDefaultValue = false)]
        public DevicePropertiesUltraloqMetadata? UltraloqMetadata { get; set; }

        /// <summary>
        /// Metadata for an ASSA ABLOY Visionline system.
        /// </summary>
        [DataMember(Name = "visionline_metadata", IsRequired = false, EmitDefaultValue = false)]
        public DevicePropertiesVisionlineMetadata? VisionlineMetadata { get; set; }

        /// <summary>
        /// Metadata for a Wyze device.
        /// </summary>
        [DataMember(Name = "wyze_metadata", IsRequired = false, EmitDefaultValue = false)]
        public DevicePropertiesWyzeMetadata? WyzeMetadata { get; set; }

        /// <summary>
        /// The delay in seconds before the lock automatically locks after being unlocked.
        /// </summary>
        [DataMember(Name = "auto_lock_delay_seconds", IsRequired = false, EmitDefaultValue = false)]
        public float? AutoLockDelaySeconds { get; set; }

        /// <summary>
        /// Indicates whether automatic locking is enabled.
        /// </summary>
        [DataMember(Name = "auto_lock_enabled", IsRequired = false, EmitDefaultValue = false)]
        public bool? AutoLockEnabled { get; set; }

        /// <summary>
        /// Indicates whether the [backup access code pool](https://docs.seam.co/low-level-apis/smart-locks/access-codes/backup-access-codes) is currently enabled for the device. To disable it, set this to `false` using [/devices/update](https://docs.seam.co/api/devices/update).
        /// </summary>
        [DataMember(
            Name = "backup_access_code_pool_enabled",
            IsRequired = false,
            EmitDefaultValue = false
        )]
        public bool? BackupAccessCodePoolEnabled { get; set; }

        /// <summary>
        /// Constraints on access codes for the device. Seam represents each constraint as an object with a `constraint_type` property. Depending on the constraint type, there may also be additional properties. Note that some constraints are manufacturer- or device-specific.
        /// </summary>
        [DataMember(Name = "code_constraints", IsRequired = false, EmitDefaultValue = false)]
        public List<DevicePropertiesCodeConstraints>? CodeConstraints { get; set; }

        /// <summary>
        /// Indicates whether the door is open.
        /// </summary>
        [DataMember(Name = "door_open", IsRequired = false, EmitDefaultValue = false)]
        public bool? DoorOpen { get; set; }

        /// <summary>
        /// Indicates whether the device supports native entry events.
        /// </summary>
        [DataMember(Name = "has_native_entry_events", IsRequired = false, EmitDefaultValue = false)]
        public bool? HasNativeEntryEvents { get; set; }

        /// <summary>
        /// Keypad battery status.
        /// </summary>
        [DataMember(Name = "keypad_battery", IsRequired = false, EmitDefaultValue = false)]
        public DevicePropertiesKeypadBattery? KeypadBattery { get; set; }

        /// <summary>
        /// Indicates whether the lock is locked.
        /// </summary>
        [DataMember(Name = "locked", IsRequired = false, EmitDefaultValue = false)]
        public bool? Locked { get; set; }

        /// <summary>
        /// Maximum number of active access codes that the device supports.
        /// </summary>
        [DataMember(
            Name = "max_active_codes_supported",
            IsRequired = false,
            EmitDefaultValue = false
        )]
        public float? MaxActiveCodesSupported { get; set; }

        /// <summary>
        /// Time frames that may be requested when creating an offline access code, expressed as a list of options. The caller picks one option (by matching the requested duration when the options&apos; duration ranges do not overlap, or by `display_name` when they do) and satisfies that one option&apos;s rules. When `undefined`, any time frame works.
        /// </summary>
        [DataMember(
            Name = "offline_time_frame_options",
            IsRequired = false,
            EmitDefaultValue = false
        )]
        public List<DevicePropertiesOfflineTimeFrameOptions>? OfflineTimeFrameOptions { get; set; }

        /// <summary>
        /// Time frames that may be requested when creating an online access code, expressed as a list of options. The caller picks one option (by matching the requested duration when the options&apos; duration ranges do not overlap, or by `display_name` when they do) and satisfies that one option&apos;s rules. When `undefined`, any time frame works.
        /// </summary>
        [DataMember(
            Name = "online_time_frame_options",
            IsRequired = false,
            EmitDefaultValue = false
        )]
        public List<DevicePropertiesOnlineTimeFrameOptions>? OnlineTimeFrameOptions { get; set; }

        /// <summary>
        /// Supported code lengths for access codes.
        /// </summary>
        [DataMember(Name = "supported_code_lengths", IsRequired = false, EmitDefaultValue = false)]
        public List<float>? SupportedCodeLengths { get; set; }

        /// <summary>
        /// Indicates whether the device supports a [backup access code pool](https://docs.seam.co/low-level-apis/smart-locks/access-codes/backup-access-codes).
        /// </summary>
        [DataMember(
            Name = "supports_backup_access_code_pool",
            IsRequired = false,
            EmitDefaultValue = false
        )]
        public bool? SupportsBackupAccessCodePool { get; set; }

        /// <summary>
        /// Active [thermostat schedule](https://docs.seam.co/capability-guides/thermostats/creating-and-managing-thermostat-schedules).
        /// </summary>
        [Obsolete("Use `active_thermostat_schedule_id` with `/thermostats/schedules/get` instead.")]
        [DataMember(
            Name = "active_thermostat_schedule",
            IsRequired = false,
            EmitDefaultValue = false
        )]
        public DevicePropertiesActiveThermostatSchedule? ActiveThermostatSchedule { get; set; }

        /// <summary>
        /// ID of the active [thermostat schedule](https://docs.seam.co/capability-guides/thermostats/creating-and-managing-thermostat-schedules).
        /// </summary>
        [DataMember(
            Name = "active_thermostat_schedule_id",
            IsRequired = false,
            EmitDefaultValue = false
        )]
        public string? ActiveThermostatScheduleId { get; set; }

        /// <summary>
        /// Climate preset modes that the thermostat supports, such as &quot;home&quot;, &quot;away&quot;, &quot;wake&quot;, &quot;sleep&quot;, &quot;occupied&quot;, and &quot;unoccupied&quot;.
        /// </summary>
        [DataMember(
            Name = "available_climate_preset_modes",
            IsRequired = false,
            EmitDefaultValue = false
        )]
        public List<DeviceProperties.AvailableClimatePresetModesEnum>? AvailableClimatePresetModes { get; set; }

        /// <summary>
        /// Available [climate presets](https://docs.seam.co/capability-guides/thermostats/creating-and-managing-climate-presets) for the thermostat.
        /// </summary>
        [DataMember(
            Name = "available_climate_presets",
            IsRequired = false,
            EmitDefaultValue = false
        )]
        public List<DevicePropertiesAvailableClimatePresets>? AvailableClimatePresets { get; set; }

        /// <summary>
        /// Fan mode settings that the thermostat supports.
        /// </summary>
        [DataMember(
            Name = "available_fan_mode_settings",
            IsRequired = false,
            EmitDefaultValue = false
        )]
        public List<DeviceProperties.AvailableFanModeSettingsEnum>? AvailableFanModeSettings { get; set; }

        /// <summary>
        /// HVAC mode settings that the thermostat supports.
        /// </summary>
        [DataMember(
            Name = "available_hvac_mode_settings",
            IsRequired = false,
            EmitDefaultValue = false
        )]
        public List<DeviceProperties.AvailableHvacModeSettingsEnum>? AvailableHvacModeSettings { get; set; }

        /// <summary>
        /// Current climate setting.
        /// </summary>
        [DataMember(Name = "current_climate_setting", IsRequired = false, EmitDefaultValue = false)]
        public DevicePropertiesCurrentClimateSetting? CurrentClimateSetting { get; set; }

        [Obsolete("use fallback_climate_preset_key to specify a fallback climate preset instead.")]
        [DataMember(Name = "default_climate_setting", IsRequired = false, EmitDefaultValue = false)]
        public DevicePropertiesDefaultClimateSetting? DefaultClimateSetting { get; set; }

        /// <summary>
        /// Key of the [fallback climate preset](https://docs.seam.co/capability-guides/thermostats/creating-and-managing-climate-presets/setting-the-fallback-climate-preset) for the thermostat.
        /// </summary>
        [DataMember(
            Name = "fallback_climate_preset_key",
            IsRequired = false,
            EmitDefaultValue = false
        )]
        public string? FallbackClimatePresetKey { get; set; }

        [Obsolete("Use `current_climate_setting.fan_mode_setting` instead.")]
        [DataMember(Name = "fan_mode_setting", IsRequired = false, EmitDefaultValue = false)]
        public DeviceProperties.FanModeSettingEnum? FanModeSetting { get; set; }

        /// <summary>
        /// Indicates whether the connected HVAC system is currently cooling, as reported by the thermostat.
        /// </summary>
        [DataMember(Name = "is_cooling", IsRequired = false, EmitDefaultValue = false)]
        public bool? IsCooling { get; set; }

        /// <summary>
        /// Indicates whether the fan in the connected HVAC system is currently running, as reported by the thermostat.
        /// </summary>
        [DataMember(Name = "is_fan_running", IsRequired = false, EmitDefaultValue = false)]
        public bool? IsFanRunning { get; set; }

        /// <summary>
        /// Indicates whether the connected HVAC system is currently heating, as reported by the thermostat.
        /// </summary>
        [DataMember(Name = "is_heating", IsRequired = false, EmitDefaultValue = false)]
        public bool? IsHeating { get; set; }

        /// <summary>
        /// Indicates whether the current thermostat settings differ from the most recent active program or schedule that Seam activated. For this condition to occur, `current_climate_setting.manual_override_allowed` must also be `true`.
        /// </summary>
        [DataMember(
            Name = "is_temporary_manual_override_active",
            IsRequired = false,
            EmitDefaultValue = false
        )]
        public bool? IsTemporaryManualOverrideActive { get; set; }

        /// <summary>
        /// Maximum [cooling set point](https://docs.seam.co/capability-guides/thermostats/understanding-thermostat-concepts/set-points#cooling-set-point) in °C.
        /// </summary>
        [DataMember(
            Name = "max_cooling_set_point_celsius",
            IsRequired = false,
            EmitDefaultValue = false
        )]
        public float? MaxCoolingSetPointCelsius { get; set; }

        /// <summary>
        /// Maximum [cooling set point](https://docs.seam.co/capability-guides/thermostats/understanding-thermostat-concepts/set-points#cooling-set-point) in °F.
        /// </summary>
        [DataMember(
            Name = "max_cooling_set_point_fahrenheit",
            IsRequired = false,
            EmitDefaultValue = false
        )]
        public float? MaxCoolingSetPointFahrenheit { get; set; }

        /// <summary>
        /// Maximum [heating set point](https://docs.seam.co/capability-guides/thermostats/understanding-thermostat-concepts/set-points#heating-set-point) in °C.
        /// </summary>
        [DataMember(
            Name = "max_heating_set_point_celsius",
            IsRequired = false,
            EmitDefaultValue = false
        )]
        public float? MaxHeatingSetPointCelsius { get; set; }

        /// <summary>
        /// Maximum [heating set point](https://docs.seam.co/capability-guides/thermostats/understanding-thermostat-concepts/set-points#heating-set-point) in °F.
        /// </summary>
        [DataMember(
            Name = "max_heating_set_point_fahrenheit",
            IsRequired = false,
            EmitDefaultValue = false
        )]
        public float? MaxHeatingSetPointFahrenheit { get; set; }

        /// <summary>
        /// Maximum number of periods that the thermostat can support per day. For example, if the thermostat supports 4 periods per day, this value is 4.
        /// </summary>
        [DataMember(
            Name = "max_thermostat_daily_program_periods_per_day",
            IsRequired = false,
            EmitDefaultValue = false
        )]
        public float? MaxThermostatDailyProgramPeriodsPerDay { get; set; }

        /// <summary>
        /// Maximum number of climate presets that the thermostat can support for weekly programming.
        /// </summary>
        [DataMember(
            Name = "max_unique_climate_presets_per_thermostat_weekly_program",
            IsRequired = false,
            EmitDefaultValue = false
        )]
        public float? MaxUniqueClimatePresetsPerThermostatWeeklyProgram { get; set; }

        /// <summary>
        /// Minimum [cooling set point](https://docs.seam.co/capability-guides/thermostats/understanding-thermostat-concepts/set-points#cooling-set-point) in °C.
        /// </summary>
        [DataMember(
            Name = "min_cooling_set_point_celsius",
            IsRequired = false,
            EmitDefaultValue = false
        )]
        public float? MinCoolingSetPointCelsius { get; set; }

        /// <summary>
        /// Minimum [cooling set point](https://docs.seam.co/capability-guides/thermostats/understanding-thermostat-concepts/set-points#cooling-set-point) in °F.
        /// </summary>
        [DataMember(
            Name = "min_cooling_set_point_fahrenheit",
            IsRequired = false,
            EmitDefaultValue = false
        )]
        public float? MinCoolingSetPointFahrenheit { get; set; }

        /// <summary>
        /// Minimum [temperature difference](https://docs.seam.co/capability-guides/thermostats/understanding-thermostat-concepts/set-points#minimum-heating-cooling-temperature-delta) in °C between the cooling and heating set points when in heat-cool (auto) mode.
        /// </summary>
        [DataMember(
            Name = "min_heating_cooling_delta_celsius",
            IsRequired = false,
            EmitDefaultValue = false
        )]
        public float? MinHeatingCoolingDeltaCelsius { get; set; }

        /// <summary>
        /// Minimum [temperature difference](https://docs.seam.co/capability-guides/thermostats/understanding-thermostat-concepts/set-points#minimum-heating-cooling-temperature-delta) in °F between the cooling and heating set points when in heat-cool (auto) mode.
        /// </summary>
        [DataMember(
            Name = "min_heating_cooling_delta_fahrenheit",
            IsRequired = false,
            EmitDefaultValue = false
        )]
        public float? MinHeatingCoolingDeltaFahrenheit { get; set; }

        /// <summary>
        /// Minimum [heating set point](https://docs.seam.co/capability-guides/thermostats/understanding-thermostat-concepts/set-points#heating-set-point) in °C.
        /// </summary>
        [DataMember(
            Name = "min_heating_set_point_celsius",
            IsRequired = false,
            EmitDefaultValue = false
        )]
        public float? MinHeatingSetPointCelsius { get; set; }

        /// <summary>
        /// Minimum [heating set point](https://docs.seam.co/capability-guides/thermostats/understanding-thermostat-concepts/set-points#heating-set-point) in °F.
        /// </summary>
        [DataMember(
            Name = "min_heating_set_point_fahrenheit",
            IsRequired = false,
            EmitDefaultValue = false
        )]
        public float? MinHeatingSetPointFahrenheit { get; set; }

        /// <summary>
        /// Reported relative humidity, as a value between 0 and 1, inclusive.
        /// </summary>
        [DataMember(Name = "relative_humidity", IsRequired = false, EmitDefaultValue = false)]
        public float? RelativeHumidity { get; set; }

        /// <summary>
        /// Reported temperature in °C.
        /// </summary>
        [DataMember(Name = "temperature_celsius", IsRequired = false, EmitDefaultValue = false)]
        public float? TemperatureCelsius { get; set; }

        /// <summary>
        /// Reported temperature in °F.
        /// </summary>
        [DataMember(Name = "temperature_fahrenheit", IsRequired = false, EmitDefaultValue = false)]
        public float? TemperatureFahrenheit { get; set; }

        /// <summary>
        /// Current [temperature threshold](https://docs.seam.co/capability-guides/thermostats/setting-and-monitoring-temperature-thresholds) set for the thermostat.
        /// </summary>
        [DataMember(Name = "temperature_threshold", IsRequired = false, EmitDefaultValue = false)]
        public DevicePropertiesTemperatureThreshold? TemperatureThreshold { get; set; }

        /// <summary>
        /// Precision of the thermostat&apos;s period in minutes. For example, if the thermostat supports 15-minute periods, this value is 15. All values are relative to the top of the hour, so for 15 minutes, the periods would be 0, 15, 30, and 45 minutes past the hour.
        /// </summary>
        [DataMember(
            Name = "thermostat_daily_program_period_precision_minutes",
            IsRequired = false,
            EmitDefaultValue = false
        )]
        public float? ThermostatDailyProgramPeriodPrecisionMinutes { get; set; }

        /// <summary>
        /// Configured [daily programs](https://docs.seam.co/capability-guides/thermostats/creating-and-managing-thermostat-programs) for the thermostat.
        /// </summary>
        [DataMember(
            Name = "thermostat_daily_programs",
            IsRequired = false,
            EmitDefaultValue = false
        )]
        public List<DevicePropertiesThermostatDailyPrograms>? ThermostatDailyPrograms { get; set; }

        /// <summary>
        /// Current [weekly program](https://docs.seam.co/capability-guides/thermostats/creating-and-managing-thermostat-programs) for the thermostat.
        /// </summary>
        [DataMember(
            Name = "thermostat_weekly_program",
            IsRequired = false,
            EmitDefaultValue = false
        )]
        public DevicePropertiesThermostatWeeklyProgram? ThermostatWeeklyProgram { get; set; }

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

        public DevicePropertiesAccessoryKeypad(
            DevicePropertiesAccessoryKeypadBattery? battery = default,
            bool isConnected = default
        )
        {
            Battery = battery;
            IsConnected = isConnected;
        }

        /// <summary>
        /// Keypad battery properties.
        /// </summary>
        [DataMember(Name = "battery", IsRequired = false, EmitDefaultValue = false)]
        public DevicePropertiesAccessoryKeypadBattery? Battery { get; set; }

        /// <summary>
        /// Indicates if an accessory keypad is connected to the device.
        /// </summary>
        [DataMember(Name = "is_connected", IsRequired = false, EmitDefaultValue = false)]
        public bool IsConnected { get; set; }

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

    [DataContract(Name = "seamModel_devicePropertiesAccessoryKeypadBattery_model")]
    public class DevicePropertiesAccessoryKeypadBattery
    {
        [JsonConstructorAttribute]
        protected DevicePropertiesAccessoryKeypadBattery() { }

        public DevicePropertiesAccessoryKeypadBattery(float level = default)
        {
            Level = level;
        }

        [DataMember(Name = "level", IsRequired = false, EmitDefaultValue = false)]
        public float Level { get; set; }

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

        public DevicePropertiesAppearance(string name = default)
        {
            Name = name;
        }

        /// <summary>
        /// Name of the device as seen from the provider API and application, not settable through Seam.
        /// </summary>
        [DataMember(Name = "name", IsRequired = false, EmitDefaultValue = false)]
        public string Name { get; set; }

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
            float level = default,
            DevicePropertiesBattery.StatusEnum status = default
        )
        {
            Level = level;
            Status = status;
        }

        /// <summary>
        /// Represents the current status of the battery charge level. Values are `critical`, which indicates an extremely low level, suggesting imminent shutdown or an urgent need for charging; `low`, which signifies that the battery is under the preferred threshold and should be charged soon; `good`, which denotes a satisfactory charge level, adequate for normal use without the immediate need for recharging; and `full`, which represents a battery that is fully charged, providing the maximum duration of usage.
        /// </summary>
        [JsonConverter(typeof(SafeStringEnumConverter))]
        public enum StatusEnum
        {
            [EnumMember(Value = "unrecognized")]
            Unrecognized = 0,

            [EnumMember(Value = "critical")]
            Critical = 1,

            [EnumMember(Value = "low")]
            Low = 2,

            [EnumMember(Value = "good")]
            Good = 3,

            [EnumMember(Value = "full")]
            Full = 4,
        }

        /// <summary>
        /// Battery charge level as a value between 0 and 1, inclusive.
        /// </summary>
        [DataMember(Name = "level", IsRequired = false, EmitDefaultValue = false)]
        public float Level { get; set; }

        /// <summary>
        /// Represents the current status of the battery charge level. Values are `critical`, which indicates an extremely low level, suggesting imminent shutdown or an urgent need for charging; `low`, which signifies that the battery is under the preferred threshold and should be charged soon; `good`, which denotes a satisfactory charge level, adequate for normal use without the immediate need for recharging; and `full`, which represents a battery that is fully charged, providing the maximum duration of usage.
        /// </summary>
        [DataMember(Name = "status", IsRequired = false, EmitDefaultValue = false)]
        public DevicePropertiesBattery.StatusEnum Status { get; set; }

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
            bool? accessoryKeypadSupported = default,
            bool? canConnectAccessoryKeypad = default,
            string displayName = default,
            bool? hasBuiltInKeypad = default,
            string manufacturerDisplayName = default,
            bool? offlineAccessCodesSupported = default,
            bool? onlineAccessCodesSupported = default
        )
        {
            AccessoryKeypadSupported = accessoryKeypadSupported;
            CanConnectAccessoryKeypad = canConnectAccessoryKeypad;
            DisplayName = displayName;
            HasBuiltInKeypad = hasBuiltInKeypad;
            ManufacturerDisplayName = manufacturerDisplayName;
            OfflineAccessCodesSupported = offlineAccessCodesSupported;
            OnlineAccessCodesSupported = onlineAccessCodesSupported;
        }

        [Obsolete("use device.properties.model.can_connect_accessory_keypad")]
        [DataMember(
            Name = "accessory_keypad_supported",
            IsRequired = false,
            EmitDefaultValue = false
        )]
        public bool? AccessoryKeypadSupported { get; set; }

        /// <summary>
        /// Indicates whether the device can connect a accessory keypad.
        /// </summary>
        [DataMember(
            Name = "can_connect_accessory_keypad",
            IsRequired = false,
            EmitDefaultValue = false
        )]
        public bool? CanConnectAccessoryKeypad { get; set; }

        /// <summary>
        /// Display name of the device model.
        /// </summary>
        [DataMember(Name = "display_name", IsRequired = false, EmitDefaultValue = false)]
        public string DisplayName { get; set; }

        /// <summary>
        /// Indicates whether the device has a built in accessory keypad.
        /// </summary>
        [DataMember(Name = "has_built_in_keypad", IsRequired = false, EmitDefaultValue = false)]
        public bool? HasBuiltInKeypad { get; set; }

        /// <summary>
        /// Display name that corresponds to the manufacturer-specific terminology for the device.
        /// </summary>
        [DataMember(
            Name = "manufacturer_display_name",
            IsRequired = false,
            EmitDefaultValue = false
        )]
        public string ManufacturerDisplayName { get; set; }

        [Obsolete("use device.can_program_offline_access_codes.")]
        [DataMember(
            Name = "offline_access_codes_supported",
            IsRequired = false,
            EmitDefaultValue = false
        )]
        public bool? OfflineAccessCodesSupported { get; set; }

        [Obsolete("use device.can_program_online_access_codes.")]
        [DataMember(
            Name = "online_access_codes_supported",
            IsRequired = false,
            EmitDefaultValue = false
        )]
        public bool? OnlineAccessCodesSupported { get; set; }

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
            List<DevicePropertiesAssaAbloyCredentialServiceMetadataEndpoints>? endpoints = default,
            bool? hasActiveEndpoint = default
        )
        {
            Endpoints = endpoints;
            HasActiveEndpoint = hasActiveEndpoint;
        }

        /// <summary>
        /// Endpoints associated with the phone.
        /// </summary>
        [DataMember(Name = "endpoints", IsRequired = false, EmitDefaultValue = false)]
        public List<DevicePropertiesAssaAbloyCredentialServiceMetadataEndpoints>? Endpoints { get; set; }

        /// <summary>
        /// Indicates whether the credential service has active endpoints associated with the phone.
        /// </summary>
        [DataMember(Name = "has_active_endpoint", IsRequired = false, EmitDefaultValue = false)]
        public bool? HasActiveEndpoint { get; set; }

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

        /// <summary>
        /// ID of the associated endpoint.
        /// </summary>
        [DataMember(Name = "endpoint_id", IsRequired = false, EmitDefaultValue = false)]
        public string? EndpointId { get; set; }

        /// <summary>
        /// Indicated whether the endpoint is active.
        /// </summary>
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

    [DataContract(Name = "seamModel_devicePropertiesSaltoSpaceCredentialServiceMetadata_model")]
    public class DevicePropertiesSaltoSpaceCredentialServiceMetadata
    {
        [JsonConstructorAttribute]
        protected DevicePropertiesSaltoSpaceCredentialServiceMetadata() { }

        public DevicePropertiesSaltoSpaceCredentialServiceMetadata(bool? hasActivePhone = default)
        {
            HasActivePhone = hasActivePhone;
        }

        /// <summary>
        /// Indicates whether the credential service has an active associated phone.
        /// </summary>
        [DataMember(Name = "has_active_phone", IsRequired = false, EmitDefaultValue = false)]
        public bool? HasActivePhone { get; set; }

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

    [DataContract(Name = "seamModel_devicePropertiesAkilesMetadata_model")]
    public class DevicePropertiesAkilesMetadata
    {
        [JsonConstructorAttribute]
        protected DevicePropertiesAkilesMetadata() { }

        public DevicePropertiesAkilesMetadata(
            string? memberGroupId = default,
            string? gadgetId = default,
            string? gadgetName = default,
            string? productName = default
        )
        {
            MemberGroupId = memberGroupId;
            GadgetId = gadgetId;
            GadgetName = gadgetName;
            ProductName = productName;
        }

        /// <summary>
        /// Group ID to which to add users for an Akiles device.
        /// </summary>
        [DataMember(Name = "member_group_id", IsRequired = false, EmitDefaultValue = false)]
        public string? MemberGroupId { get; set; }

        /// <summary>
        /// Gadget ID for an Akiles device.
        /// </summary>
        [DataMember(Name = "gadget_id", IsRequired = false, EmitDefaultValue = false)]
        public string? GadgetId { get; set; }

        /// <summary>
        /// Gadget name for an Akiles device.
        /// </summary>
        [DataMember(Name = "gadget_name", IsRequired = false, EmitDefaultValue = false)]
        public string? GadgetName { get; set; }

        /// <summary>
        /// Product name for an Akiles device.
        /// </summary>
        [DataMember(Name = "product_name", IsRequired = false, EmitDefaultValue = false)]
        public string? ProductName { get; set; }

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

    [DataContract(Name = "seamModel_devicePropertiesAssaAbloyVostioMetadata_model")]
    public class DevicePropertiesAssaAbloyVostioMetadata
    {
        [JsonConstructorAttribute]
        protected DevicePropertiesAssaAbloyVostioMetadata() { }

        public DevicePropertiesAssaAbloyVostioMetadata(string? encoderName = default)
        {
            EncoderName = encoderName;
        }

        /// <summary>
        /// Encoder name for an ASSA ABLOY Vostio system.
        /// </summary>
        [DataMember(Name = "encoder_name", IsRequired = false, EmitDefaultValue = false)]
        public string? EncoderName { get; set; }

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
            bool? hasKeypad = default,
            string? houseId = default,
            string? houseName = default,
            string? keypadBatteryLevel = default,
            string? lockId = default,
            string? lockName = default,
            string? model = default
        )
        {
            HasKeypad = hasKeypad;
            HouseId = houseId;
            HouseName = houseName;
            KeypadBatteryLevel = keypadBatteryLevel;
            LockId = lockId;
            LockName = lockName;
            Model = model;
        }

        /// <summary>
        /// Indicates whether an August device has a keypad.
        /// </summary>
        [DataMember(Name = "has_keypad", IsRequired = false, EmitDefaultValue = false)]
        public bool? HasKeypad { get; set; }

        /// <summary>
        /// House ID for an August device.
        /// </summary>
        [DataMember(Name = "house_id", IsRequired = false, EmitDefaultValue = false)]
        public string? HouseId { get; set; }

        /// <summary>
        /// House name for an August device.
        /// </summary>
        [DataMember(Name = "house_name", IsRequired = false, EmitDefaultValue = false)]
        public string? HouseName { get; set; }

        /// <summary>
        /// Keypad battery level for an August device.
        /// </summary>
        [DataMember(Name = "keypad_battery_level", IsRequired = false, EmitDefaultValue = false)]
        public string? KeypadBatteryLevel { get; set; }

        /// <summary>
        /// Lock ID for an August device.
        /// </summary>
        [DataMember(Name = "lock_id", IsRequired = false, EmitDefaultValue = false)]
        public string? LockId { get; set; }

        /// <summary>
        /// Lock name for an August device.
        /// </summary>
        [DataMember(Name = "lock_name", IsRequired = false, EmitDefaultValue = false)]
        public string? LockName { get; set; }

        /// <summary>
        /// Model for an August device.
        /// </summary>
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

    [DataContract(Name = "seamModel_devicePropertiesAvigilonAltaMetadata_model")]
    public class DevicePropertiesAvigilonAltaMetadata
    {
        [JsonConstructorAttribute]
        protected DevicePropertiesAvigilonAltaMetadata() { }

        public DevicePropertiesAvigilonAltaMetadata(
            string? entryName = default,
            float? entryRelaysTotalCount = default,
            string? orgName = default,
            float? siteId = default,
            string? siteName = default,
            float? zoneId = default,
            string? zoneName = default
        )
        {
            EntryName = entryName;
            EntryRelaysTotalCount = entryRelaysTotalCount;
            OrgName = orgName;
            SiteId = siteId;
            SiteName = siteName;
            ZoneId = zoneId;
            ZoneName = zoneName;
        }

        /// <summary>
        /// Entry name for an Avigilon Alta system.
        /// </summary>
        [DataMember(Name = "entry_name", IsRequired = false, EmitDefaultValue = false)]
        public string? EntryName { get; set; }

        /// <summary>
        /// Total count of entry relays for an Avigilon Alta system.
        /// </summary>
        [DataMember(
            Name = "entry_relays_total_count",
            IsRequired = false,
            EmitDefaultValue = false
        )]
        public float? EntryRelaysTotalCount { get; set; }

        /// <summary>
        /// Organization name for an Avigilon Alta system.
        /// </summary>
        [DataMember(Name = "org_name", IsRequired = false, EmitDefaultValue = false)]
        public string? OrgName { get; set; }

        /// <summary>
        /// Site ID for an Avigilon Alta system.
        /// </summary>
        [DataMember(Name = "site_id", IsRequired = false, EmitDefaultValue = false)]
        public float? SiteId { get; set; }

        /// <summary>
        /// Site name for an Avigilon Alta system.
        /// </summary>
        [DataMember(Name = "site_name", IsRequired = false, EmitDefaultValue = false)]
        public string? SiteName { get; set; }

        /// <summary>
        /// Zone ID for an Avigilon Alta system.
        /// </summary>
        [DataMember(Name = "zone_id", IsRequired = false, EmitDefaultValue = false)]
        public float? ZoneId { get; set; }

        /// <summary>
        /// Zone name for an Avigilon Alta system.
        /// </summary>
        [DataMember(Name = "zone_name", IsRequired = false, EmitDefaultValue = false)]
        public string? ZoneName { get; set; }

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

        public DevicePropertiesBrivoMetadata(
            bool? activationEnabled = default,
            string? deviceName = default
        )
        {
            ActivationEnabled = activationEnabled;
            DeviceName = deviceName;
        }

        /// <summary>
        /// Indicates whether the Brivo access point has activation (remote unlock) enabled.
        /// </summary>
        [DataMember(Name = "activation_enabled", IsRequired = false, EmitDefaultValue = false)]
        public bool? ActivationEnabled { get; set; }

        /// <summary>
        /// Device name for a Brivo device.
        /// </summary>
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

        /// <summary>
        /// Device ID for a ControlByWeb device.
        /// </summary>
        [DataMember(Name = "device_id", IsRequired = false, EmitDefaultValue = false)]
        public string? DeviceId { get; set; }

        /// <summary>
        /// Device name for a ControlByWeb device.
        /// </summary>
        [DataMember(Name = "device_name", IsRequired = false, EmitDefaultValue = false)]
        public string? DeviceName { get; set; }

        /// <summary>
        /// Relay name for a ControlByWeb device.
        /// </summary>
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

    [DataContract(Name = "seamModel_devicePropertiesDormakabaOracodeMetadata_model")]
    public class DevicePropertiesDormakabaOracodeMetadata
    {
        [JsonConstructorAttribute]
        protected DevicePropertiesDormakabaOracodeMetadata() { }

        public DevicePropertiesDormakabaOracodeMetadata(
            DevicePropertiesDormakabaOracodeMetadataDeviceId? deviceId = default,
            float? doorId = default,
            bool? doorIsWireless = default,
            string? doorName = default,
            string? ianaTimezone = default,
            List<DevicePropertiesDormakabaOracodeMetadataPredefinedTimeSlots>? predefinedTimeSlots =
                default,
            float? siteId = default,
            string? siteName = default
        )
        {
            DeviceId = deviceId;
            DoorId = doorId;
            DoorIsWireless = doorIsWireless;
            DoorName = doorName;
            IanaTimezone = ianaTimezone;
            PredefinedTimeSlots = predefinedTimeSlots;
            SiteId = siteId;
            SiteName = siteName;
        }

        /// <summary>
        /// Device ID for a dormakaba Oracode device.
        /// </summary>
        [DataMember(Name = "device_id", IsRequired = false, EmitDefaultValue = false)]
        public DevicePropertiesDormakabaOracodeMetadataDeviceId? DeviceId { get; set; }

        /// <summary>
        /// Door ID for a dormakaba Oracode device.
        /// </summary>
        [DataMember(Name = "door_id", IsRequired = false, EmitDefaultValue = false)]
        public float? DoorId { get; set; }

        /// <summary>
        /// Indicates whether a door is wireless for a dormakaba Oracode device.
        /// </summary>
        [DataMember(Name = "door_is_wireless", IsRequired = false, EmitDefaultValue = false)]
        public bool? DoorIsWireless { get; set; }

        /// <summary>
        /// Door name for a dormakaba Oracode device.
        /// </summary>
        [DataMember(Name = "door_name", IsRequired = false, EmitDefaultValue = false)]
        public string? DoorName { get; set; }

        /// <summary>
        /// IANA time zone for a dormakaba Oracode device.
        /// </summary>
        [DataMember(Name = "iana_timezone", IsRequired = false, EmitDefaultValue = false)]
        public string? IanaTimezone { get; set; }

        /// <summary>
        /// Predefined time slots for a dormakaba Oracode device.
        /// </summary>
        [DataMember(Name = "predefined_time_slots", IsRequired = false, EmitDefaultValue = false)]
        public List<DevicePropertiesDormakabaOracodeMetadataPredefinedTimeSlots>? PredefinedTimeSlots { get; set; }

        /// <summary>
        /// Site ID for a dormakaba Oracode device.
        /// </summary>
        [Obsolete("Previously marked as \"@DEPRECATED.\"")]
        [DataMember(Name = "site_id", IsRequired = false, EmitDefaultValue = false)]
        public float? SiteId { get; set; }

        /// <summary>
        /// Site name for a dormakaba Oracode device.
        /// </summary>
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

    [DataContract(Name = "seamModel_devicePropertiesDormakabaOracodeMetadataDeviceId_model")]
    public class DevicePropertiesDormakabaOracodeMetadataDeviceId
    {
        [JsonConstructorAttribute]
        public DevicePropertiesDormakabaOracodeMetadataDeviceId() { }

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
            string? checkInTime = default,
            string? checkOutTime = default,
            string? dormakabaOracodeUserLevelId = default,
            float? dormakabaOracodeUserLevelPrefix = default,
            bool? is_24Hour = default,
            bool? isBiweeklyMode = default,
            bool? isMaster = default,
            bool? isOneShot = default,
            string? name = default,
            float? prefix = default
        )
        {
            CheckInTime = checkInTime;
            CheckOutTime = checkOutTime;
            DormakabaOracodeUserLevelId = dormakabaOracodeUserLevelId;
            DormakabaOracodeUserLevelPrefix = dormakabaOracodeUserLevelPrefix;
            Is_24Hour = is_24Hour;
            IsBiweeklyMode = isBiweeklyMode;
            IsMaster = isMaster;
            IsOneShot = isOneShot;
            Name = name;
            Prefix = prefix;
        }

        /// <summary>
        /// Check in time for a time slot for a dormakaba Oracode device.
        /// </summary>
        [DataMember(Name = "check_in_time", IsRequired = false, EmitDefaultValue = false)]
        public string? CheckInTime { get; set; }

        /// <summary>
        /// Checkout time for a time slot for a dormakaba Oracode device.
        /// </summary>
        [DataMember(Name = "check_out_time", IsRequired = false, EmitDefaultValue = false)]
        public string? CheckOutTime { get; set; }

        /// <summary>
        /// ID of a user level for a dormakaba Oracode device.
        /// </summary>
        [DataMember(
            Name = "dormakaba_oracode_user_level_id",
            IsRequired = false,
            EmitDefaultValue = false
        )]
        public string? DormakabaOracodeUserLevelId { get; set; }

        /// <summary>
        /// Prefix for a user level for a dormakaba Oracode device.
        /// </summary>
        [DataMember(
            Name = "dormakaba_oracode_user_level_prefix",
            IsRequired = false,
            EmitDefaultValue = false
        )]
        public float? DormakabaOracodeUserLevelPrefix { get; set; }

        /// <summary>
        /// Indicates whether a time slot for a dormakaba Oracode device is a 24-hour time slot.
        /// </summary>
        [DataMember(Name = "is_24_hour", IsRequired = false, EmitDefaultValue = false)]
        public bool? Is_24Hour { get; set; }

        /// <summary>
        /// Indicates whether a time slot for a dormakaba Oracode device is in biweekly mode.
        /// </summary>
        [DataMember(Name = "is_biweekly_mode", IsRequired = false, EmitDefaultValue = false)]
        public bool? IsBiweeklyMode { get; set; }

        /// <summary>
        /// Indicates whether a time slot for a dormakaba Oracode device is a master time slot.
        /// </summary>
        [DataMember(Name = "is_master", IsRequired = false, EmitDefaultValue = false)]
        public bool? IsMaster { get; set; }

        /// <summary>
        /// Indicates whether a time slot for a dormakaba Oracode device is a one-shot time slot.
        /// </summary>
        [DataMember(Name = "is_one_shot", IsRequired = false, EmitDefaultValue = false)]
        public bool? IsOneShot { get; set; }

        /// <summary>
        /// Name of a time slot for a dormakaba Oracode device.
        /// </summary>
        [DataMember(Name = "name", IsRequired = false, EmitDefaultValue = false)]
        public string? Name { get; set; }

        /// <summary>
        /// Prefix for a time slot for a dormakaba Oracode device.
        /// </summary>
        [DataMember(Name = "prefix", IsRequired = false, EmitDefaultValue = false)]
        public float? Prefix { get; set; }

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
            string? deviceName = default,
            string? ecobeeDeviceId = default
        )
        {
            DeviceName = deviceName;
            EcobeeDeviceId = ecobeeDeviceId;
        }

        /// <summary>
        /// Device name for an ecobee device.
        /// </summary>
        [DataMember(Name = "device_name", IsRequired = false, EmitDefaultValue = false)]
        public string? DeviceName { get; set; }

        /// <summary>
        /// Device ID for an ecobee device.
        /// </summary>
        [DataMember(Name = "ecobee_device_id", IsRequired = false, EmitDefaultValue = false)]
        public string? EcobeeDeviceId { get; set; }

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

        /// <summary>
        /// Device ID for a 4SUITES device.
        /// </summary>
        [DataMember(Name = "device_id", IsRequired = false, EmitDefaultValue = false)]
        public float? DeviceId { get; set; }

        /// <summary>
        /// Device name for a 4SUITES device.
        /// </summary>
        [DataMember(Name = "device_name", IsRequired = false, EmitDefaultValue = false)]
        public string? DeviceName { get; set; }

        /// <summary>
        /// Reclose delay, in seconds, for a 4SUITES device.
        /// </summary>
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

        /// <summary>
        /// Lock name for a Genie device.
        /// </summary>
        [DataMember(Name = "device_name", IsRequired = false, EmitDefaultValue = false)]
        public string? DeviceName { get; set; }

        /// <summary>
        /// Door name for a Genie device.
        /// </summary>
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

    [DataContract(Name = "seamModel_devicePropertiesHoneywellResideoMetadata_model")]
    public class DevicePropertiesHoneywellResideoMetadata
    {
        [JsonConstructorAttribute]
        protected DevicePropertiesHoneywellResideoMetadata() { }

        public DevicePropertiesHoneywellResideoMetadata(
            string? deviceName = default,
            string? honeywellResideoDeviceId = default
        )
        {
            DeviceName = deviceName;
            HoneywellResideoDeviceId = honeywellResideoDeviceId;
        }

        /// <summary>
        /// Device name for a Honeywell Resideo device.
        /// </summary>
        [DataMember(Name = "device_name", IsRequired = false, EmitDefaultValue = false)]
        public string? DeviceName { get; set; }

        /// <summary>
        /// Device ID for a Honeywell Resideo device.
        /// </summary>
        [DataMember(
            Name = "honeywell_resideo_device_id",
            IsRequired = false,
            EmitDefaultValue = false
        )]
        public string? HoneywellResideoDeviceId { get; set; }

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
            string? bridgeId = default,
            string? deviceId = default,
            string? model = default
        )
        {
            BridgeId = bridgeId;
            DeviceId = deviceId;
            Model = model;
        }

        /// <summary>
        /// Bridge ID for an igloo device.
        /// </summary>
        [DataMember(Name = "bridge_id", IsRequired = false, EmitDefaultValue = false)]
        public string? BridgeId { get; set; }

        /// <summary>
        /// Device ID for an igloo device.
        /// </summary>
        [DataMember(Name = "device_id", IsRequired = false, EmitDefaultValue = false)]
        public string? DeviceId { get; set; }

        /// <summary>
        /// Model for an igloo device.
        /// </summary>
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

    [DataContract(Name = "seamModel_devicePropertiesIgloohomeMetadata_model")]
    public class DevicePropertiesIgloohomeMetadata
    {
        [JsonConstructorAttribute]
        protected DevicePropertiesIgloohomeMetadata() { }

        public DevicePropertiesIgloohomeMetadata(
            string? bridgeId = default,
            string? bridgeName = default,
            string? deviceId = default,
            string? deviceName = default,
            bool? isAccessoryKeypadLinkedToBridge = default,
            string? keypadId = default
        )
        {
            BridgeId = bridgeId;
            BridgeName = bridgeName;
            DeviceId = deviceId;
            DeviceName = deviceName;
            IsAccessoryKeypadLinkedToBridge = isAccessoryKeypadLinkedToBridge;
            KeypadId = keypadId;
        }

        /// <summary>
        /// Bridge ID for an igloohome device.
        /// </summary>
        [DataMember(Name = "bridge_id", IsRequired = false, EmitDefaultValue = false)]
        public string? BridgeId { get; set; }

        /// <summary>
        /// Bridge name for an igloohome device.
        /// </summary>
        [DataMember(Name = "bridge_name", IsRequired = false, EmitDefaultValue = false)]
        public string? BridgeName { get; set; }

        /// <summary>
        /// Device ID for an igloohome device.
        /// </summary>
        [DataMember(Name = "device_id", IsRequired = false, EmitDefaultValue = false)]
        public string? DeviceId { get; set; }

        /// <summary>
        /// Device name for an igloohome device.
        /// </summary>
        [DataMember(Name = "device_name", IsRequired = false, EmitDefaultValue = false)]
        public string? DeviceName { get; set; }

        /// <summary>
        /// Indicates whether a keypad is linked to a bridge for an igloohome device.
        /// </summary>
        [DataMember(
            Name = "is_accessory_keypad_linked_to_bridge",
            IsRequired = false,
            EmitDefaultValue = false
        )]
        public bool? IsAccessoryKeypadLinkedToBridge { get; set; }

        /// <summary>
        /// Keypad ID for an igloohome device.
        /// </summary>
        [DataMember(Name = "keypad_id", IsRequired = false, EmitDefaultValue = false)]
        public string? KeypadId { get; set; }

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

    [DataContract(Name = "seamModel_devicePropertiesKeynestMetadata_model")]
    public class DevicePropertiesKeynestMetadata
    {
        [JsonConstructorAttribute]
        protected DevicePropertiesKeynestMetadata() { }

        public DevicePropertiesKeynestMetadata(
            string? address = default,
            float? currentOrLastStoreId = default,
            string? currentStatus = default,
            string? currentUserCompany = default,
            string? currentUserEmail = default,
            string? currentUserName = default,
            string? currentUserPhoneNumber = default,
            float? defaultOfficeId = default,
            string? deviceName = default,
            float? fobId = default,
            string? handoverMethod = default,
            bool? hasPhoto = default,
            bool? isQuadientLocker = default,
            string? keyId = default,
            string? keyNotes = default,
            string? keynestAppUser = default,
            string? lastMovement = default,
            string? propertyId = default,
            string? propertyPostcode = default,
            string? statusType = default,
            string? subscriptionPlan = default
        )
        {
            Address = address;
            CurrentOrLastStoreId = currentOrLastStoreId;
            CurrentStatus = currentStatus;
            CurrentUserCompany = currentUserCompany;
            CurrentUserEmail = currentUserEmail;
            CurrentUserName = currentUserName;
            CurrentUserPhoneNumber = currentUserPhoneNumber;
            DefaultOfficeId = defaultOfficeId;
            DeviceName = deviceName;
            FobId = fobId;
            HandoverMethod = handoverMethod;
            HasPhoto = hasPhoto;
            IsQuadientLocker = isQuadientLocker;
            KeyId = keyId;
            KeyNotes = keyNotes;
            KeynestAppUser = keynestAppUser;
            LastMovement = lastMovement;
            PropertyId = propertyId;
            PropertyPostcode = propertyPostcode;
            StatusType = statusType;
            SubscriptionPlan = subscriptionPlan;
        }

        /// <summary>
        /// Address for a KeyNest device.
        /// </summary>
        [DataMember(Name = "address", IsRequired = false, EmitDefaultValue = false)]
        public string? Address { get; set; }

        /// <summary>
        /// Current or last store ID for a KeyNest device.
        /// </summary>
        [DataMember(
            Name = "current_or_last_store_id",
            IsRequired = false,
            EmitDefaultValue = false
        )]
        public float? CurrentOrLastStoreId { get; set; }

        /// <summary>
        /// Current status for a KeyNest device.
        /// </summary>
        [DataMember(Name = "current_status", IsRequired = false, EmitDefaultValue = false)]
        public string? CurrentStatus { get; set; }

        /// <summary>
        /// Current user company for a KeyNest device.
        /// </summary>
        [DataMember(Name = "current_user_company", IsRequired = false, EmitDefaultValue = false)]
        public string? CurrentUserCompany { get; set; }

        /// <summary>
        /// Current user email for a KeyNest device.
        /// </summary>
        [DataMember(Name = "current_user_email", IsRequired = false, EmitDefaultValue = false)]
        public string? CurrentUserEmail { get; set; }

        /// <summary>
        /// Current user name for a KeyNest device.
        /// </summary>
        [DataMember(Name = "current_user_name", IsRequired = false, EmitDefaultValue = false)]
        public string? CurrentUserName { get; set; }

        /// <summary>
        /// Current user phone number for a KeyNest device.
        /// </summary>
        [DataMember(
            Name = "current_user_phone_number",
            IsRequired = false,
            EmitDefaultValue = false
        )]
        public string? CurrentUserPhoneNumber { get; set; }

        /// <summary>
        /// Default office ID for a KeyNest device.
        /// </summary>
        [DataMember(Name = "default_office_id", IsRequired = false, EmitDefaultValue = false)]
        public float? DefaultOfficeId { get; set; }

        /// <summary>
        /// Device name for a KeyNest device.
        /// </summary>
        [DataMember(Name = "device_name", IsRequired = false, EmitDefaultValue = false)]
        public string? DeviceName { get; set; }

        /// <summary>
        /// Fob ID for a KeyNest device.
        /// </summary>
        [DataMember(Name = "fob_id", IsRequired = false, EmitDefaultValue = false)]
        public float? FobId { get; set; }

        /// <summary>
        /// Handover method for a KeyNest device.
        /// </summary>
        [DataMember(Name = "handover_method", IsRequired = false, EmitDefaultValue = false)]
        public string? HandoverMethod { get; set; }

        /// <summary>
        /// Whether the KeyNest device has a photo.
        /// </summary>
        [DataMember(Name = "has_photo", IsRequired = false, EmitDefaultValue = false)]
        public bool? HasPhoto { get; set; }

        /// <summary>
        /// Whether the key is in a locker that does not support the access codes API.
        /// </summary>
        [DataMember(Name = "is_quadient_locker", IsRequired = false, EmitDefaultValue = false)]
        public bool? IsQuadientLocker { get; set; }

        /// <summary>
        /// Key ID for a KeyNest device.
        /// </summary>
        [DataMember(Name = "key_id", IsRequired = false, EmitDefaultValue = false)]
        public string? KeyId { get; set; }

        /// <summary>
        /// Key notes for a KeyNest device.
        /// </summary>
        [DataMember(Name = "key_notes", IsRequired = false, EmitDefaultValue = false)]
        public string? KeyNotes { get; set; }

        /// <summary>
        /// KeyNest app user for a KeyNest device.
        /// </summary>
        [DataMember(Name = "keynest_app_user", IsRequired = false, EmitDefaultValue = false)]
        public string? KeynestAppUser { get; set; }

        /// <summary>
        /// Last movement timestamp for a KeyNest device.
        /// </summary>
        [DataMember(Name = "last_movement", IsRequired = false, EmitDefaultValue = false)]
        public string? LastMovement { get; set; }

        /// <summary>
        /// Property ID for a KeyNest device.
        /// </summary>
        [DataMember(Name = "property_id", IsRequired = false, EmitDefaultValue = false)]
        public string? PropertyId { get; set; }

        /// <summary>
        /// Property postcode for a KeyNest device.
        /// </summary>
        [DataMember(Name = "property_postcode", IsRequired = false, EmitDefaultValue = false)]
        public string? PropertyPostcode { get; set; }

        /// <summary>
        /// Status type for a KeyNest device.
        /// </summary>
        [DataMember(Name = "status_type", IsRequired = false, EmitDefaultValue = false)]
        public string? StatusType { get; set; }

        /// <summary>
        /// Subscription plan for a KeyNest device.
        /// </summary>
        [DataMember(Name = "subscription_plan", IsRequired = false, EmitDefaultValue = false)]
        public string? SubscriptionPlan { get; set; }

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

    [DataContract(Name = "seamModel_devicePropertiesKisiMetadata_model")]
    public class DevicePropertiesKisiMetadata
    {
        [JsonConstructorAttribute]
        protected DevicePropertiesKisiMetadata() { }

        public DevicePropertiesKisiMetadata(
            string? description = default,
            float? lockId = default,
            string? lockName = default,
            string? placeName = default
        )
        {
            Description = description;
            LockId = lockId;
            LockName = lockName;
            PlaceName = placeName;
        }

        /// <summary>
        /// Description for a Kisi device.
        /// </summary>
        [DataMember(Name = "description", IsRequired = false, EmitDefaultValue = false)]
        public string? Description { get; set; }

        /// <summary>
        /// Lock ID for a Kisi device.
        /// </summary>
        [DataMember(Name = "lock_id", IsRequired = false, EmitDefaultValue = false)]
        public float? LockId { get; set; }

        /// <summary>
        /// Lock name for a Kisi device.
        /// </summary>
        [DataMember(Name = "lock_name", IsRequired = false, EmitDefaultValue = false)]
        public string? LockName { get; set; }

        /// <summary>
        /// Place name for a Kisi device.
        /// </summary>
        [DataMember(Name = "place_name", IsRequired = false, EmitDefaultValue = false)]
        public string? PlaceName { get; set; }

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

    [DataContract(Name = "seamModel_devicePropertiesKorelockMetadata_model")]
    public class DevicePropertiesKorelockMetadata
    {
        [JsonConstructorAttribute]
        protected DevicePropertiesKorelockMetadata() { }

        public DevicePropertiesKorelockMetadata(
            string? deviceId = default,
            string? deviceName = default,
            string? firmwareVersion = default,
            string? locationId = default,
            string? modelCode = default,
            string? serialNumber = default,
            float? wifiSignalStrength = default
        )
        {
            DeviceId = deviceId;
            DeviceName = deviceName;
            FirmwareVersion = firmwareVersion;
            LocationId = locationId;
            ModelCode = modelCode;
            SerialNumber = serialNumber;
            WifiSignalStrength = wifiSignalStrength;
        }

        /// <summary>
        /// Device ID for a Korelock device.
        /// </summary>
        [DataMember(Name = "device_id", IsRequired = false, EmitDefaultValue = false)]
        public string? DeviceId { get; set; }

        /// <summary>
        /// Device name for a Korelock device.
        /// </summary>
        [DataMember(Name = "device_name", IsRequired = false, EmitDefaultValue = false)]
        public string? DeviceName { get; set; }

        /// <summary>
        /// Firmware version for a Korelock device.
        /// </summary>
        [DataMember(Name = "firmware_version", IsRequired = false, EmitDefaultValue = false)]
        public string? FirmwareVersion { get; set; }

        /// <summary>
        /// Location ID for a Korelock device. Required for timebound access codes.
        /// </summary>
        [DataMember(Name = "location_id", IsRequired = false, EmitDefaultValue = false)]
        public string? LocationId { get; set; }

        /// <summary>
        /// Model code for a Korelock device.
        /// </summary>
        [DataMember(Name = "model_code", IsRequired = false, EmitDefaultValue = false)]
        public string? ModelCode { get; set; }

        /// <summary>
        /// Serial number for a Korelock device.
        /// </summary>
        [DataMember(Name = "serial_number", IsRequired = false, EmitDefaultValue = false)]
        public string? SerialNumber { get; set; }

        /// <summary>
        /// WiFi signal strength (0-1) for a Korelock device.
        /// </summary>
        [DataMember(Name = "wifi_signal_strength", IsRequired = false, EmitDefaultValue = false)]
        public float? WifiSignalStrength { get; set; }

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

        /// <summary>
        /// Device ID for a Kwikset device.
        /// </summary>
        [DataMember(Name = "device_id", IsRequired = false, EmitDefaultValue = false)]
        public string? DeviceId { get; set; }

        /// <summary>
        /// Device name for a Kwikset device.
        /// </summary>
        [DataMember(Name = "device_name", IsRequired = false, EmitDefaultValue = false)]
        public string? DeviceName { get; set; }

        /// <summary>
        /// Model number for a Kwikset device.
        /// </summary>
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

        /// <summary>
        /// Device ID for a Lockly device.
        /// </summary>
        [DataMember(Name = "device_id", IsRequired = false, EmitDefaultValue = false)]
        public string? DeviceId { get; set; }

        /// <summary>
        /// Device name for a Lockly device.
        /// </summary>
        [DataMember(Name = "device_name", IsRequired = false, EmitDefaultValue = false)]
        public string? DeviceName { get; set; }

        /// <summary>
        /// Model for a Lockly device.
        /// </summary>
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

        /// <summary>
        /// Device ID for a Minut device.
        /// </summary>
        [DataMember(Name = "device_id", IsRequired = false, EmitDefaultValue = false)]
        public string? DeviceId { get; set; }

        /// <summary>
        /// Device name for a Minut device.
        /// </summary>
        [DataMember(Name = "device_name", IsRequired = false, EmitDefaultValue = false)]
        public string? DeviceName { get; set; }

        /// <summary>
        /// Latest sensor values for a Minut device.
        /// </summary>
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
            DevicePropertiesMinutMetadataLatestSensorValuesAccelerometerZ? accelerometerZ = default,
            DevicePropertiesMinutMetadataLatestSensorValuesHumidity? humidity = default,
            DevicePropertiesMinutMetadataLatestSensorValuesPressure? pressure = default,
            DevicePropertiesMinutMetadataLatestSensorValuesSound? sound = default,
            DevicePropertiesMinutMetadataLatestSensorValuesTemperature? temperature = default
        )
        {
            AccelerometerZ = accelerometerZ;
            Humidity = humidity;
            Pressure = pressure;
            Sound = sound;
            Temperature = temperature;
        }

        /// <summary>
        /// Latest accelerometer Z-axis reading for a Minut device.
        /// </summary>
        [DataMember(Name = "accelerometer_z", IsRequired = false, EmitDefaultValue = false)]
        public DevicePropertiesMinutMetadataLatestSensorValuesAccelerometerZ? AccelerometerZ { get; set; }

        /// <summary>
        /// Latest humidity reading for a Minut device.
        /// </summary>
        [DataMember(Name = "humidity", IsRequired = false, EmitDefaultValue = false)]
        public DevicePropertiesMinutMetadataLatestSensorValuesHumidity? Humidity { get; set; }

        /// <summary>
        /// Latest pressure reading for a Minut device.
        /// </summary>
        [DataMember(Name = "pressure", IsRequired = false, EmitDefaultValue = false)]
        public DevicePropertiesMinutMetadataLatestSensorValuesPressure? Pressure { get; set; }

        /// <summary>
        /// Latest sound reading for a Minut device.
        /// </summary>
        [DataMember(Name = "sound", IsRequired = false, EmitDefaultValue = false)]
        public DevicePropertiesMinutMetadataLatestSensorValuesSound? Sound { get; set; }

        /// <summary>
        /// Latest temperature reading for a Minut device.
        /// </summary>
        [DataMember(Name = "temperature", IsRequired = false, EmitDefaultValue = false)]
        public DevicePropertiesMinutMetadataLatestSensorValuesTemperature? Temperature { get; set; }

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

        /// <summary>
        /// Time of latest accelerometer Z-axis reading for a Minut device.
        /// </summary>
        [DataMember(Name = "time", IsRequired = false, EmitDefaultValue = false)]
        public string? Time { get; set; }

        /// <summary>
        /// Value of latest accelerometer Z-axis reading for a Minut device.
        /// </summary>
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

        /// <summary>
        /// Time of latest humidity reading for a Minut device.
        /// </summary>
        [DataMember(Name = "time", IsRequired = false, EmitDefaultValue = false)]
        public string? Time { get; set; }

        /// <summary>
        /// Value of latest humidity reading for a Minut device.
        /// </summary>
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

        /// <summary>
        /// Time of latest pressure reading for a Minut device.
        /// </summary>
        [DataMember(Name = "time", IsRequired = false, EmitDefaultValue = false)]
        public string? Time { get; set; }

        /// <summary>
        /// Value of latest pressure reading for a Minut device.
        /// </summary>
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

        /// <summary>
        /// Time of latest sound reading for a Minut device.
        /// </summary>
        [DataMember(Name = "time", IsRequired = false, EmitDefaultValue = false)]
        public string? Time { get; set; }

        /// <summary>
        /// Value of latest sound reading for a Minut device.
        /// </summary>
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

        /// <summary>
        /// Time of latest temperature reading for a Minut device.
        /// </summary>
        [DataMember(Name = "time", IsRequired = false, EmitDefaultValue = false)]
        public string? Time { get; set; }

        /// <summary>
        /// Value of latest temperature reading for a Minut device.
        /// </summary>
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

    [DataContract(Name = "seamModel_devicePropertiesNestMetadata_model")]
    public class DevicePropertiesNestMetadata
    {
        [JsonConstructorAttribute]
        protected DevicePropertiesNestMetadata() { }

        public DevicePropertiesNestMetadata(
            string? deviceCustomName = default,
            string? deviceName = default,
            string? displayName = default,
            string? nestDeviceId = default
        )
        {
            DeviceCustomName = deviceCustomName;
            DeviceName = deviceName;
            DisplayName = displayName;
            NestDeviceId = nestDeviceId;
        }

        /// <summary>
        /// Custom device name for a Google Nest device. The device owner sets this value.
        /// </summary>
        [DataMember(Name = "device_custom_name", IsRequired = false, EmitDefaultValue = false)]
        public string? DeviceCustomName { get; set; }

        /// <summary>
        /// Device name for a Google Nest device. Google sets this value.
        /// </summary>
        [DataMember(Name = "device_name", IsRequired = false, EmitDefaultValue = false)]
        public string? DeviceName { get; set; }

        /// <summary>
        /// Display name for a Google Nest device.
        /// </summary>
        [DataMember(Name = "display_name", IsRequired = false, EmitDefaultValue = false)]
        public string? DisplayName { get; set; }

        /// <summary>
        /// Device ID for a Google Nest device.
        /// </summary>
        [DataMember(Name = "nest_device_id", IsRequired = false, EmitDefaultValue = false)]
        public string? NestDeviceId { get; set; }

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
            string? deviceId = default,
            DevicePropertiesNoiseawareMetadata.DeviceModelEnum? deviceModel = default,
            string? deviceName = default,
            float? noiseLevelDecibel = default,
            float? noiseLevelNrs = default
        )
        {
            DeviceId = deviceId;
            DeviceModel = deviceModel;
            DeviceName = deviceName;
            NoiseLevelDecibel = noiseLevelDecibel;
            NoiseLevelNrs = noiseLevelNrs;
        }

        /// <summary>
        /// Device model for a NoiseAware device.
        /// </summary>
        [JsonConverter(typeof(SafeStringEnumConverter))]
        public enum DeviceModelEnum
        {
            [EnumMember(Value = "unrecognized")]
            Unrecognized = 0,

            [EnumMember(Value = "indoor")]
            Indoor = 1,

            [EnumMember(Value = "outdoor")]
            Outdoor = 2,
        }

        /// <summary>
        /// Device ID for a NoiseAware device.
        /// </summary>
        [DataMember(Name = "device_id", IsRequired = false, EmitDefaultValue = false)]
        public string? DeviceId { get; set; }

        /// <summary>
        /// Device model for a NoiseAware device.
        /// </summary>
        [DataMember(Name = "device_model", IsRequired = false, EmitDefaultValue = false)]
        public DevicePropertiesNoiseawareMetadata.DeviceModelEnum? DeviceModel { get; set; }

        /// <summary>
        /// Device name for a NoiseAware device.
        /// </summary>
        [DataMember(Name = "device_name", IsRequired = false, EmitDefaultValue = false)]
        public string? DeviceName { get; set; }

        /// <summary>
        /// Noise level, in decibels, for a NoiseAware device.
        /// </summary>
        [DataMember(Name = "noise_level_decibel", IsRequired = false, EmitDefaultValue = false)]
        public float? NoiseLevelDecibel { get; set; }

        /// <summary>
        /// Noise level, expressed as a Noise Risk Score (NRS), for a NoiseAware device.
        /// </summary>
        [DataMember(Name = "noise_level_nrs", IsRequired = false, EmitDefaultValue = false)]
        public float? NoiseLevelNrs { get; set; }

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
            bool? keypad_2Paired = default,
            bool? keypadBatteryCritical = default,
            bool? keypadPaired = default
        )
        {
            DeviceId = deviceId;
            DeviceName = deviceName;
            Keypad_2Paired = keypad_2Paired;
            KeypadBatteryCritical = keypadBatteryCritical;
            KeypadPaired = keypadPaired;
        }

        /// <summary>
        /// Device ID for a Nuki device.
        /// </summary>
        [DataMember(Name = "device_id", IsRequired = false, EmitDefaultValue = false)]
        public string? DeviceId { get; set; }

        /// <summary>
        /// Device name for a Nuki device.
        /// </summary>
        [DataMember(Name = "device_name", IsRequired = false, EmitDefaultValue = false)]
        public string? DeviceName { get; set; }

        /// <summary>
        /// Indicates whether keypad 2 is paired for a Nuki device.
        /// </summary>
        [DataMember(Name = "keypad_2_paired", IsRequired = false, EmitDefaultValue = false)]
        public bool? Keypad_2Paired { get; set; }

        /// <summary>
        /// Indicates whether the keypad battery is in a critical state for a Nuki device.
        /// </summary>
        [DataMember(Name = "keypad_battery_critical", IsRequired = false, EmitDefaultValue = false)]
        public bool? KeypadBatteryCritical { get; set; }

        /// <summary>
        /// Indicates whether the keypad is paired for a Nuki device.
        /// </summary>
        [DataMember(Name = "keypad_paired", IsRequired = false, EmitDefaultValue = false)]
        public bool? KeypadPaired { get; set; }

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

    [DataContract(Name = "seamModel_devicePropertiesOmnitecMetadata_model")]
    public class DevicePropertiesOmnitecMetadata
    {
        [JsonConstructorAttribute]
        protected DevicePropertiesOmnitecMetadata() { }

        public DevicePropertiesOmnitecMetadata(
            bool? hasGateway = default,
            string? lockAlias = default,
            float? lockId = default,
            string? lockMac = default,
            string? lockName = default,
            string? timeZone = default,
            float? timezoneRawOffsetMs = default
        )
        {
            HasGateway = hasGateway;
            LockAlias = lockAlias;
            LockId = lockId;
            LockMac = lockMac;
            LockName = lockName;
            TimeZone = timeZone;
            TimezoneRawOffsetMs = timezoneRawOffsetMs;
        }

        /// <summary>
        /// Whether the Omnitec lock has a connected gateway for remote operations.
        /// </summary>
        [DataMember(Name = "has_gateway", IsRequired = false, EmitDefaultValue = false)]
        public bool? HasGateway { get; set; }

        /// <summary>
        /// Operator-assigned alias for an Omnitec device.
        /// </summary>
        [DataMember(Name = "lock_alias", IsRequired = false, EmitDefaultValue = false)]
        public string? LockAlias { get; set; }

        /// <summary>
        /// Lock ID for an Omnitec device.
        /// </summary>
        [DataMember(Name = "lock_id", IsRequired = false, EmitDefaultValue = false)]
        public float? LockId { get; set; }

        /// <summary>
        /// Bluetooth MAC address for an Omnitec device.
        /// </summary>
        [DataMember(Name = "lock_mac", IsRequired = false, EmitDefaultValue = false)]
        public string? LockMac { get; set; }

        /// <summary>
        /// Lock name for an Omnitec device.
        /// </summary>
        [DataMember(Name = "lock_name", IsRequired = false, EmitDefaultValue = false)]
        public string? LockName { get; set; }

        /// <summary>
        /// IANA time zone for the Omnitec device, used to schedule time-bound access codes at the correct local time (accounting for DST).
        /// </summary>
        [DataMember(Name = "time_zone", IsRequired = false, EmitDefaultValue = false)]
        public string? TimeZone { get; set; }

        /// <summary>
        /// Static UTC offset of the Omnitec lock in milliseconds. Does not account for DST.
        /// </summary>
        [DataMember(Name = "timezone_raw_offset_ms", IsRequired = false, EmitDefaultValue = false)]
        public float? TimezoneRawOffsetMs { get; set; }

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

    [DataContract(Name = "seamModel_devicePropertiesRingMetadata_model")]
    public class DevicePropertiesRingMetadata
    {
        [JsonConstructorAttribute]
        protected DevicePropertiesRingMetadata() { }

        public DevicePropertiesRingMetadata(
            string? deviceId = default,
            string? deviceName = default
        )
        {
            DeviceId = deviceId;
            DeviceName = deviceName;
        }

        /// <summary>
        /// Device ID for a Ring device.
        /// </summary>
        [DataMember(Name = "device_id", IsRequired = false, EmitDefaultValue = false)]
        public string? DeviceId { get; set; }

        /// <summary>
        /// Device name for a Ring device.
        /// </summary>
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

    [DataContract(Name = "seamModel_devicePropertiesSaltoKsMetadata_model")]
    public class DevicePropertiesSaltoKsMetadata
    {
        [JsonConstructorAttribute]
        protected DevicePropertiesSaltoKsMetadata() { }

        public DevicePropertiesSaltoKsMetadata(
            string? batteryLevel = default,
            string? customerReference = default,
            bool? hasCustomPinSubscription = default,
            string? lockId = default,
            string? lockType = default,
            string? lockedState = default,
            string? model = default,
            string? siteId = default,
            string? siteName = default
        )
        {
            BatteryLevel = batteryLevel;
            CustomerReference = customerReference;
            HasCustomPinSubscription = hasCustomPinSubscription;
            LockId = lockId;
            LockType = lockType;
            LockedState = lockedState;
            Model = model;
            SiteId = siteId;
            SiteName = siteName;
        }

        /// <summary>
        /// Battery level for a Salto KS device.
        /// </summary>
        [DataMember(Name = "battery_level", IsRequired = false, EmitDefaultValue = false)]
        public string? BatteryLevel { get; set; }

        /// <summary>
        /// Customer reference for a Salto KS device.
        /// </summary>
        [DataMember(Name = "customer_reference", IsRequired = false, EmitDefaultValue = false)]
        public string? CustomerReference { get; set; }

        /// <summary>
        /// Indicates whether the site has a Salto KS subscription that supports custom PINs.
        /// </summary>
        [DataMember(
            Name = "has_custom_pin_subscription",
            IsRequired = false,
            EmitDefaultValue = false
        )]
        public bool? HasCustomPinSubscription { get; set; }

        /// <summary>
        /// Lock ID for a Salto KS device.
        /// </summary>
        [DataMember(Name = "lock_id", IsRequired = false, EmitDefaultValue = false)]
        public string? LockId { get; set; }

        /// <summary>
        /// Lock type for a Salto KS device.
        /// </summary>
        [DataMember(Name = "lock_type", IsRequired = false, EmitDefaultValue = false)]
        public string? LockType { get; set; }

        /// <summary>
        /// Locked state for a Salto KS device.
        /// </summary>
        [DataMember(Name = "locked_state", IsRequired = false, EmitDefaultValue = false)]
        public string? LockedState { get; set; }

        /// <summary>
        /// Model for a Salto KS device.
        /// </summary>
        [DataMember(Name = "model", IsRequired = false, EmitDefaultValue = false)]
        public string? Model { get; set; }

        /// <summary>
        /// Site ID for the Salto KS site to which the device belongs.
        /// </summary>
        [DataMember(Name = "site_id", IsRequired = false, EmitDefaultValue = false)]
        public string? SiteId { get; set; }

        /// <summary>
        /// Site name for the Salto KS site to which the device belongs.
        /// </summary>
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

    [DataContract(Name = "seamModel_devicePropertiesSaltoMetadata_model")]
    public class DevicePropertiesSaltoMetadata
    {
        [JsonConstructorAttribute]
        protected DevicePropertiesSaltoMetadata() { }

        public DevicePropertiesSaltoMetadata(
            string? batteryLevel = default,
            string? customerReference = default,
            string? lockId = default,
            string? lockType = default,
            string? lockedState = default,
            string? model = default,
            string? siteId = default,
            string? siteName = default
        )
        {
            BatteryLevel = batteryLevel;
            CustomerReference = customerReference;
            LockId = lockId;
            LockType = lockType;
            LockedState = lockedState;
            Model = model;
            SiteId = siteId;
            SiteName = siteName;
        }

        /// <summary>
        /// Battery level for a Salto device.
        /// </summary>
        [DataMember(Name = "battery_level", IsRequired = false, EmitDefaultValue = false)]
        public string? BatteryLevel { get; set; }

        /// <summary>
        /// Customer reference for a Salto device.
        /// </summary>
        [DataMember(Name = "customer_reference", IsRequired = false, EmitDefaultValue = false)]
        public string? CustomerReference { get; set; }

        /// <summary>
        /// Lock ID for a Salto device.
        /// </summary>
        [DataMember(Name = "lock_id", IsRequired = false, EmitDefaultValue = false)]
        public string? LockId { get; set; }

        /// <summary>
        /// Lock type for a Salto device.
        /// </summary>
        [DataMember(Name = "lock_type", IsRequired = false, EmitDefaultValue = false)]
        public string? LockType { get; set; }

        /// <summary>
        /// Locked state for a Salto device.
        /// </summary>
        [DataMember(Name = "locked_state", IsRequired = false, EmitDefaultValue = false)]
        public string? LockedState { get; set; }

        /// <summary>
        /// Model for a Salto device.
        /// </summary>
        [DataMember(Name = "model", IsRequired = false, EmitDefaultValue = false)]
        public string? Model { get; set; }

        /// <summary>
        /// Site ID for the Salto KS site to which the device belongs.
        /// </summary>
        [DataMember(Name = "site_id", IsRequired = false, EmitDefaultValue = false)]
        public string? SiteId { get; set; }

        /// <summary>
        /// Site name for the Salto KS site to which the device belongs.
        /// </summary>
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
            string? model = default
        )
        {
            DeviceId = deviceId;
            DeviceName = deviceName;
            Model = model;
        }

        /// <summary>
        /// Device ID for a Schlage device.
        /// </summary>
        [DataMember(Name = "device_id", IsRequired = false, EmitDefaultValue = false)]
        public string? DeviceId { get; set; }

        /// <summary>
        /// Device name for a Schlage device.
        /// </summary>
        [DataMember(Name = "device_name", IsRequired = false, EmitDefaultValue = false)]
        public string? DeviceName { get; set; }

        /// <summary>
        /// Model for a Schlage device.
        /// </summary>
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

    [DataContract(Name = "seamModel_devicePropertiesSeamBridgeMetadata_model")]
    public class DevicePropertiesSeamBridgeMetadata
    {
        [JsonConstructorAttribute]
        protected DevicePropertiesSeamBridgeMetadata() { }

        public DevicePropertiesSeamBridgeMetadata(
            float? deviceNum = default,
            string? name = default,
            DevicePropertiesSeamBridgeMetadata.UnlockMethodEnum? unlockMethod = default
        )
        {
            DeviceNum = deviceNum;
            Name = name;
            UnlockMethod = unlockMethod;
        }

        /// <summary>
        /// Unlock method for Seam Bridge.
        /// </summary>
        [JsonConverter(typeof(SafeStringEnumConverter))]
        public enum UnlockMethodEnum
        {
            [EnumMember(Value = "unrecognized")]
            Unrecognized = 0,

            [EnumMember(Value = "bridge")]
            Bridge = 1,

            [EnumMember(Value = "doorking")]
            Doorking = 2,
        }

        /// <summary>
        /// Device number for Seam Bridge.
        /// </summary>
        [DataMember(Name = "device_num", IsRequired = false, EmitDefaultValue = false)]
        public float? DeviceNum { get; set; }

        /// <summary>
        /// Name for Seam Bridge.
        /// </summary>
        [DataMember(Name = "name", IsRequired = false, EmitDefaultValue = false)]
        public string? Name { get; set; }

        /// <summary>
        /// Unlock method for Seam Bridge.
        /// </summary>
        [DataMember(Name = "unlock_method", IsRequired = false, EmitDefaultValue = false)]
        public DevicePropertiesSeamBridgeMetadata.UnlockMethodEnum? UnlockMethod { get; set; }

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

    [DataContract(Name = "seamModel_devicePropertiesSensiMetadata_model")]
    public class DevicePropertiesSensiMetadata
    {
        [JsonConstructorAttribute]
        protected DevicePropertiesSensiMetadata() { }

        public DevicePropertiesSensiMetadata(
            string? deviceId = default,
            string? deviceName = default,
            bool? dualSetpointsNotSupported = default,
            string? productType = default
        )
        {
            DeviceId = deviceId;
            DeviceName = deviceName;
            DualSetpointsNotSupported = dualSetpointsNotSupported;
            ProductType = productType;
        }

        /// <summary>
        /// Device ID for a Sensi device.
        /// </summary>
        [DataMember(Name = "device_id", IsRequired = false, EmitDefaultValue = false)]
        public string? DeviceId { get; set; }

        /// <summary>
        /// Device name for a Sensi device.
        /// </summary>
        [DataMember(Name = "device_name", IsRequired = false, EmitDefaultValue = false)]
        public string? DeviceName { get; set; }

        /// <summary>
        /// Set to true when the device does not support the /dual-setpoints API endpoint.
        /// </summary>
        [DataMember(
            Name = "dual_setpoints_not_supported",
            IsRequired = false,
            EmitDefaultValue = false
        )]
        public bool? DualSetpointsNotSupported { get; set; }

        /// <summary>
        /// Product type for a Sensi device.
        /// </summary>
        [DataMember(Name = "product_type", IsRequired = false, EmitDefaultValue = false)]
        public string? ProductType { get; set; }

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
            string? locationId = default,
            string? model = default
        )
        {
            DeviceId = deviceId;
            DeviceName = deviceName;
            LocationId = locationId;
            Model = model;
        }

        /// <summary>
        /// Device ID for a SmartThings device.
        /// </summary>
        [DataMember(Name = "device_id", IsRequired = false, EmitDefaultValue = false)]
        public string? DeviceId { get; set; }

        /// <summary>
        /// Device name for a SmartThings device.
        /// </summary>
        [DataMember(Name = "device_name", IsRequired = false, EmitDefaultValue = false)]
        public string? DeviceName { get; set; }

        /// <summary>
        /// Location ID for a SmartThings device.
        /// </summary>
        [DataMember(Name = "location_id", IsRequired = false, EmitDefaultValue = false)]
        public string? LocationId { get; set; }

        /// <summary>
        /// Model for a SmartThings device.
        /// </summary>
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

    [DataContract(Name = "seamModel_devicePropertiesTadoMetadata_model")]
    public class DevicePropertiesTadoMetadata
    {
        [JsonConstructorAttribute]
        protected DevicePropertiesTadoMetadata() { }

        public DevicePropertiesTadoMetadata(
            string? deviceType = default,
            string? serialNo = default
        )
        {
            DeviceType = deviceType;
            SerialNo = serialNo;
        }

        /// <summary>
        /// Device type for a tado° device.
        /// </summary>
        [DataMember(Name = "device_type", IsRequired = false, EmitDefaultValue = false)]
        public string? DeviceType { get; set; }

        /// <summary>
        /// Serial number for a tado° device.
        /// </summary>
        [DataMember(Name = "serial_no", IsRequired = false, EmitDefaultValue = false)]
        public string? SerialNo { get; set; }

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
            float? bridgeId = default,
            string? bridgeName = default,
            float? deviceId = default,
            string? deviceModel = default,
            string? deviceName = default,
            float? keypadId = default,
            string? serialNumber = default
        )
        {
            BridgeId = bridgeId;
            BridgeName = bridgeName;
            DeviceId = deviceId;
            DeviceModel = deviceModel;
            DeviceName = deviceName;
            KeypadId = keypadId;
            SerialNumber = serialNumber;
        }

        /// <summary>
        /// Bridge ID for a Tedee device.
        /// </summary>
        [DataMember(Name = "bridge_id", IsRequired = false, EmitDefaultValue = false)]
        public float? BridgeId { get; set; }

        /// <summary>
        /// Bridge name for a Tedee device.
        /// </summary>
        [DataMember(Name = "bridge_name", IsRequired = false, EmitDefaultValue = false)]
        public string? BridgeName { get; set; }

        /// <summary>
        /// Device ID for a Tedee device.
        /// </summary>
        [DataMember(Name = "device_id", IsRequired = false, EmitDefaultValue = false)]
        public float? DeviceId { get; set; }

        /// <summary>
        /// Device model for a Tedee device.
        /// </summary>
        [DataMember(Name = "device_model", IsRequired = false, EmitDefaultValue = false)]
        public string? DeviceModel { get; set; }

        /// <summary>
        /// Device name for a Tedee device.
        /// </summary>
        [DataMember(Name = "device_name", IsRequired = false, EmitDefaultValue = false)]
        public string? DeviceName { get; set; }

        /// <summary>
        /// Keypad ID for a Tedee device.
        /// </summary>
        [DataMember(Name = "keypad_id", IsRequired = false, EmitDefaultValue = false)]
        public float? KeypadId { get; set; }

        /// <summary>
        /// Serial number for a Tedee device.
        /// </summary>
        [DataMember(Name = "serial_number", IsRequired = false, EmitDefaultValue = false)]
        public string? SerialNumber { get; set; }

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

        public DevicePropertiesTtlockMetadata(
            string? featureValue = default,
            DevicePropertiesTtlockMetadataFeatures? features = default,
            bool? hasGateway = default,
            string? lockAlias = default,
            float? lockId = default,
            float? timezoneRawOffsetMs = default,
            List<DevicePropertiesTtlockMetadataWirelessKeypads>? wirelessKeypads = default
        )
        {
            FeatureValue = featureValue;
            Features = features;
            HasGateway = hasGateway;
            LockAlias = lockAlias;
            LockId = lockId;
            TimezoneRawOffsetMs = timezoneRawOffsetMs;
            WirelessKeypads = wirelessKeypads;
        }

        /// <summary>
        /// Feature value for a TTLock device.
        /// </summary>
        [DataMember(Name = "feature_value", IsRequired = false, EmitDefaultValue = false)]
        public string? FeatureValue { get; set; }

        /// <summary>
        /// Features for a TTLock device.
        /// </summary>
        [DataMember(Name = "features", IsRequired = false, EmitDefaultValue = false)]
        public DevicePropertiesTtlockMetadataFeatures? Features { get; set; }

        /// <summary>
        /// Indicates whether a TTLock device has a gateway.
        /// </summary>
        [DataMember(Name = "has_gateway", IsRequired = false, EmitDefaultValue = false)]
        public bool? HasGateway { get; set; }

        /// <summary>
        /// Lock alias for a TTLock device.
        /// </summary>
        [DataMember(Name = "lock_alias", IsRequired = false, EmitDefaultValue = false)]
        public string? LockAlias { get; set; }

        /// <summary>
        /// Lock ID for a TTLock device.
        /// </summary>
        [DataMember(Name = "lock_id", IsRequired = false, EmitDefaultValue = false)]
        public float? LockId { get; set; }

        /// <summary>
        /// Lock-side timezone offset in milliseconds east of UTC, as configured in the TTLock app. Source of truth for the lock&apos;s wall-clock interpretation of access code start/end times — a misconfigured value here is the typical cause of customer &quot;codes offset by N hours&quot; reports. Diagnostic only; Seam does not convert times based on this value.
        /// </summary>
        [DataMember(Name = "timezone_raw_offset_ms", IsRequired = false, EmitDefaultValue = false)]
        public float? TimezoneRawOffsetMs { get; set; }

        /// <summary>
        /// Wireless keypads for a TTLock device.
        /// </summary>
        [DataMember(Name = "wireless_keypads", IsRequired = false, EmitDefaultValue = false)]
        public List<DevicePropertiesTtlockMetadataWirelessKeypads>? WirelessKeypads { get; set; }

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

    [DataContract(Name = "seamModel_devicePropertiesTtlockMetadataFeatures_model")]
    public class DevicePropertiesTtlockMetadataFeatures
    {
        [JsonConstructorAttribute]
        protected DevicePropertiesTtlockMetadataFeatures() { }

        public DevicePropertiesTtlockMetadataFeatures(
            bool? autoLockTimeConfig = default,
            bool? incompleteKeyboardPasscode = default,
            bool? lockCommand = default,
            bool? passcode = default,
            bool? passcodeManagement = default,
            bool? unlockViaGateway = default,
            bool? wifi = default
        )
        {
            AutoLockTimeConfig = autoLockTimeConfig;
            IncompleteKeyboardPasscode = incompleteKeyboardPasscode;
            LockCommand = lockCommand;
            Passcode = passcode;
            PasscodeManagement = passcodeManagement;
            UnlockViaGateway = unlockViaGateway;
            Wifi = wifi;
        }

        /// <summary>
        /// Indicates whether a TTLock device supports auto-lock time configuration.
        /// </summary>
        [DataMember(Name = "auto_lock_time_config", IsRequired = false, EmitDefaultValue = false)]
        public bool? AutoLockTimeConfig { get; set; }

        /// <summary>
        /// Indicates whether a TTLock device supports an incomplete keyboard passcode.
        /// </summary>
        [DataMember(
            Name = "incomplete_keyboard_passcode",
            IsRequired = false,
            EmitDefaultValue = false
        )]
        public bool? IncompleteKeyboardPasscode { get; set; }

        /// <summary>
        /// Indicates whether a TTLock device supports the lock command.
        /// </summary>
        [DataMember(Name = "lock_command", IsRequired = false, EmitDefaultValue = false)]
        public bool? LockCommand { get; set; }

        /// <summary>
        /// Indicates whether a TTLock device supports a passcode.
        /// </summary>
        [DataMember(Name = "passcode", IsRequired = false, EmitDefaultValue = false)]
        public bool? Passcode { get; set; }

        /// <summary>
        /// Indicates whether a TTLock device supports passcode management.
        /// </summary>
        [DataMember(Name = "passcode_management", IsRequired = false, EmitDefaultValue = false)]
        public bool? PasscodeManagement { get; set; }

        /// <summary>
        /// Indicates whether a TTLock device supports unlock via gateway.
        /// </summary>
        [DataMember(Name = "unlock_via_gateway", IsRequired = false, EmitDefaultValue = false)]
        public bool? UnlockViaGateway { get; set; }

        /// <summary>
        /// Indicates whether a TTLock device supports Wi-Fi.
        /// </summary>
        [DataMember(Name = "wifi", IsRequired = false, EmitDefaultValue = false)]
        public bool? Wifi { get; set; }

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

    [DataContract(Name = "seamModel_devicePropertiesTtlockMetadataWirelessKeypads_model")]
    public class DevicePropertiesTtlockMetadataWirelessKeypads
    {
        [JsonConstructorAttribute]
        protected DevicePropertiesTtlockMetadataWirelessKeypads() { }

        public DevicePropertiesTtlockMetadataWirelessKeypads(
            float? wirelessKeypadId = default,
            string? wirelessKeypadName = default
        )
        {
            WirelessKeypadId = wirelessKeypadId;
            WirelessKeypadName = wirelessKeypadName;
        }

        /// <summary>
        /// ID for a wireless keypad for a TTLock device.
        /// </summary>
        [DataMember(Name = "wireless_keypad_id", IsRequired = false, EmitDefaultValue = false)]
        public float? WirelessKeypadId { get; set; }

        /// <summary>
        /// Name for a wireless keypad for a TTLock device.
        /// </summary>
        [DataMember(Name = "wireless_keypad_name", IsRequired = false, EmitDefaultValue = false)]
        public string? WirelessKeypadName { get; set; }

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

        /// <summary>
        /// Device ID for a 2N device.
        /// </summary>
        [DataMember(Name = "device_id", IsRequired = false, EmitDefaultValue = false)]
        public float? DeviceId { get; set; }

        /// <summary>
        /// Device name for a 2N device.
        /// </summary>
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

    [DataContract(Name = "seamModel_devicePropertiesUltraloqMetadata_model")]
    public class DevicePropertiesUltraloqMetadata
    {
        [JsonConstructorAttribute]
        protected DevicePropertiesUltraloqMetadata() { }

        public DevicePropertiesUltraloqMetadata(
            string? deviceId = default,
            string? deviceName = default,
            string? deviceType = default,
            string? timeZone = default
        )
        {
            DeviceId = deviceId;
            DeviceName = deviceName;
            DeviceType = deviceType;
            TimeZone = timeZone;
        }

        /// <summary>
        /// Device ID for an Ultraloq device.
        /// </summary>
        [DataMember(Name = "device_id", IsRequired = false, EmitDefaultValue = false)]
        public string? DeviceId { get; set; }

        /// <summary>
        /// Device name for an Ultraloq device.
        /// </summary>
        [DataMember(Name = "device_name", IsRequired = false, EmitDefaultValue = false)]
        public string? DeviceName { get; set; }

        /// <summary>
        /// Device type for an Ultraloq device.
        /// </summary>
        [DataMember(Name = "device_type", IsRequired = false, EmitDefaultValue = false)]
        public string? DeviceType { get; set; }

        /// <summary>
        /// IANA timezone for the Ultraloq device.
        /// </summary>
        [DataMember(Name = "time_zone", IsRequired = false, EmitDefaultValue = false)]
        public string? TimeZone { get; set; }

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

    [DataContract(Name = "seamModel_devicePropertiesVisionlineMetadata_model")]
    public class DevicePropertiesVisionlineMetadata
    {
        [JsonConstructorAttribute]
        protected DevicePropertiesVisionlineMetadata() { }

        public DevicePropertiesVisionlineMetadata(string? encoderId = default)
        {
            EncoderId = encoderId;
        }

        /// <summary>
        /// Encoder ID for an ASSA ABLOY Visionline system.
        /// </summary>
        [DataMember(Name = "encoder_id", IsRequired = false, EmitDefaultValue = false)]
        public string? EncoderId { get; set; }

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
            string? deviceInfoModel = default,
            string? deviceName = default,
            string? keypadUuid = default,
            float? lockerStatusHardlock = default,
            string? productModel = default,
            string? productName = default,
            string? productType = default
        )
        {
            DeviceId = deviceId;
            DeviceInfoModel = deviceInfoModel;
            DeviceName = deviceName;
            KeypadUuid = keypadUuid;
            LockerStatusHardlock = lockerStatusHardlock;
            ProductModel = productModel;
            ProductName = productName;
            ProductType = productType;
        }

        /// <summary>
        /// Device ID for a Wyze device.
        /// </summary>
        [DataMember(Name = "device_id", IsRequired = false, EmitDefaultValue = false)]
        public string? DeviceId { get; set; }

        /// <summary>
        /// Device information model for a Wyze device.
        /// </summary>
        [DataMember(Name = "device_info_model", IsRequired = false, EmitDefaultValue = false)]
        public string? DeviceInfoModel { get; set; }

        /// <summary>
        /// Device name for a Wyze device.
        /// </summary>
        [DataMember(Name = "device_name", IsRequired = false, EmitDefaultValue = false)]
        public string? DeviceName { get; set; }

        /// <summary>
        /// Keypad UUID for a Wyze device.
        /// </summary>
        [DataMember(Name = "keypad_uuid", IsRequired = false, EmitDefaultValue = false)]
        public string? KeypadUuid { get; set; }

        /// <summary>
        /// Locker status (hardlock) for a Wyze device.
        /// </summary>
        [DataMember(Name = "locker_status_hardlock", IsRequired = false, EmitDefaultValue = false)]
        public float? LockerStatusHardlock { get; set; }

        /// <summary>
        /// Product model for a Wyze device.
        /// </summary>
        [DataMember(Name = "product_model", IsRequired = false, EmitDefaultValue = false)]
        public string? ProductModel { get; set; }

        /// <summary>
        /// Product name for a Wyze device.
        /// </summary>
        [DataMember(Name = "product_name", IsRequired = false, EmitDefaultValue = false)]
        public string? ProductName { get; set; }

        /// <summary>
        /// Product type for a Wyze device.
        /// </summary>
        [DataMember(Name = "product_type", IsRequired = false, EmitDefaultValue = false)]
        public string? ProductType { get; set; }

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

    [DataContract(Name = "seamModel_devicePropertiesCodeConstraints_model")]
    public class DevicePropertiesCodeConstraints
    {
        [JsonConstructorAttribute]
        protected DevicePropertiesCodeConstraints() { }

        public DevicePropertiesCodeConstraints(
            DevicePropertiesCodeConstraints.ConstraintTypeEnum constraintType = default,
            float? maxLength = default,
            float? minLength = default
        )
        {
            ConstraintType = constraintType;
            MaxLength = maxLength;
            MinLength = minLength;
        }

        [JsonConverter(typeof(SafeStringEnumConverter))]
        public enum ConstraintTypeEnum
        {
            [EnumMember(Value = "unrecognized")]
            Unrecognized = 0,

            [EnumMember(Value = "no_zeros")]
            NoZeros = 1,

            [EnumMember(Value = "cannot_start_with_12")]
            CannotStartWith_12 = 2,

            [EnumMember(Value = "no_triple_consecutive_ints")]
            NoTripleConsecutiveInts = 3,

            [EnumMember(Value = "cannot_specify_pin_code")]
            CannotSpecifyPinCode = 4,

            [EnumMember(Value = "pin_code_matches_existing_set")]
            PinCodeMatchesExistingSet = 5,

            [EnumMember(Value = "start_date_in_future")]
            StartDateInFuture = 6,

            [EnumMember(Value = "no_ascending_or_descending_sequence")]
            NoAscendingOrDescendingSequence = 7,

            [EnumMember(Value = "at_least_three_unique_digits")]
            AtLeastThreeUniqueDigits = 8,

            [EnumMember(Value = "cannot_contain_089")]
            CannotContain_089 = 9,

            [EnumMember(Value = "cannot_contain_0789")]
            CannotContain_0789 = 10,

            [EnumMember(Value = "unique_first_four_digits")]
            UniqueFirstFourDigits = 11,

            [EnumMember(Value = "no_all_same_digits")]
            NoAllSameDigits = 12,

            [EnumMember(Value = "name_length")]
            NameLength = 13,

            [EnumMember(Value = "name_must_be_unique")]
            NameMustBeUnique = 14,
        }

        [DataMember(Name = "constraint_type", IsRequired = false, EmitDefaultValue = false)]
        public DevicePropertiesCodeConstraints.ConstraintTypeEnum ConstraintType { get; set; }

        /// <summary>
        /// Maximum name length constraint for access codes.
        /// </summary>
        [DataMember(Name = "max_length", IsRequired = false, EmitDefaultValue = false)]
        public float? MaxLength { get; set; }

        /// <summary>
        /// Minimum name length constraint for access codes.
        /// </summary>
        [DataMember(Name = "min_length", IsRequired = false, EmitDefaultValue = false)]
        public float? MinLength { get; set; }

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

        public DevicePropertiesKeypadBattery(float level = default)
        {
            Level = level;
        }

        /// <summary>
        /// Keypad battery charge level.
        /// </summary>
        [DataMember(Name = "level", IsRequired = false, EmitDefaultValue = false)]
        public float Level { get; set; }

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

    [DataContract(Name = "seamModel_devicePropertiesOfflineTimeFrameOptions_model")]
    public class DevicePropertiesOfflineTimeFrameOptions
    {
        [JsonConstructorAttribute]
        protected DevicePropertiesOfflineTimeFrameOptions() { }

        public DevicePropertiesOfflineTimeFrameOptions(
            string displayName = default,
            string? endDateRecurrenceRule = default,
            bool? matchingStartEndTime = default,
            string? maxDuration = default,
            string? minDuration = default,
            string? startDateRecurrenceRule = default,
            List<DevicePropertiesOfflineTimeFrameOptionsTimePairs>? timePairs = default,
            string? timeZone = default
        )
        {
            DisplayName = displayName;
            EndDateRecurrenceRule = endDateRecurrenceRule;
            MatchingStartEndTime = matchingStartEndTime;
            MaxDuration = maxDuration;
            MinDuration = minDuration;
            StartDateRecurrenceRule = startDateRecurrenceRule;
            TimePairs = timePairs;
            TimeZone = timeZone;
        }

        /// <summary>
        /// Label for this option. For a single-option device, the product name (for example, `algoPIN` or `SmartPIN`); for a multi-option device, a label that distinguishes it (for example, `Hourly` or `Fixed start times`).
        /// </summary>
        [DataMember(Name = "display_name", IsRequired = false, EmitDefaultValue = false)]
        public string DisplayName { get; set; }

        /// <summary>
        /// iCalendar recurrence rule (RRULE) that the end date must fall on. Constrains which calendar dates are selectable, independent of the time-of-day rules.
        /// </summary>
        [DataMember(
            Name = "end_date_recurrence_rule",
            IsRequired = false,
            EmitDefaultValue = false
        )]
        public string? EndDateRecurrenceRule { get; set; }

        /// <summary>
        /// When `true`, the start and end must fall at the same time of day (the caller picks which). Mutually exclusive with `time_pairs`.
        /// </summary>
        [DataMember(Name = "matching_start_end_time", IsRequired = false, EmitDefaultValue = false)]
        public bool? MatchingStartEndTime { get; set; }

        /// <summary>
        /// Maximum duration this option covers, as an ISO 8601 duration (for example, `PT672H` or `P367D`). Omitted when there is no maximum.
        /// </summary>
        [DataMember(Name = "max_duration", IsRequired = false, EmitDefaultValue = false)]
        public string? MaxDuration { get; set; }

        /// <summary>
        /// Minimum duration this option covers, as an ISO 8601 duration (for example, `PT1H` or `P29D`). Omitted when there is no minimum.
        /// </summary>
        [DataMember(Name = "min_duration", IsRequired = false, EmitDefaultValue = false)]
        public string? MinDuration { get; set; }

        /// <summary>
        /// iCalendar recurrence rule (RRULE) that the start date must fall on (for example, `FREQ=MONTHLY;BYDAY=1MO,3MO`). Constrains which calendar dates are selectable, independent of the time-of-day rules.
        /// </summary>
        [DataMember(
            Name = "start_date_recurrence_rule",
            IsRequired = false,
            EmitDefaultValue = false
        )]
        public string? StartDateRecurrenceRule { get; set; }

        /// <summary>
        /// Fixed start/end time pairings the caller chooses from. Mutually exclusive with `matching_start_end_time`.
        /// </summary>
        [DataMember(Name = "time_pairs", IsRequired = false, EmitDefaultValue = false)]
        public List<DevicePropertiesOfflineTimeFrameOptionsTimePairs>? TimePairs { get; set; }

        /// <summary>
        /// IANA time zone for interpreting `time_pairs` and the date recurrence rules. Present only when the option fixes times or dates.
        /// </summary>
        [DataMember(Name = "time_zone", IsRequired = false, EmitDefaultValue = false)]
        public string? TimeZone { get; set; }

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

    [DataContract(Name = "seamModel_devicePropertiesOfflineTimeFrameOptionsTimePairs_model")]
    public class DevicePropertiesOfflineTimeFrameOptionsTimePairs
    {
        [JsonConstructorAttribute]
        protected DevicePropertiesOfflineTimeFrameOptionsTimePairs() { }

        public DevicePropertiesOfflineTimeFrameOptionsTimePairs(
            string displayName = default,
            string endTime = default,
            string startTime = default
        )
        {
            DisplayName = displayName;
            EndTime = endTime;
            StartTime = startTime;
        }

        /// <summary>
        /// Label for the start/end time pairing.
        /// </summary>
        [DataMember(Name = "display_name", IsRequired = false, EmitDefaultValue = false)]
        public string DisplayName { get; set; }

        /// <summary>
        /// End time of day as a 24-hour `HH:MM` value, interpreted in the option&apos;s `time_zone`. An `end_time` earlier on the clock than `start_time` means the end falls on a later date.
        /// </summary>
        [DataMember(Name = "end_time", IsRequired = false, EmitDefaultValue = false)]
        public string EndTime { get; set; }

        /// <summary>
        /// Start time of day as a 24-hour `HH:MM` value, interpreted in the option&apos;s `time_zone`.
        /// </summary>
        [DataMember(Name = "start_time", IsRequired = false, EmitDefaultValue = false)]
        public string StartTime { get; set; }

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

    [DataContract(Name = "seamModel_devicePropertiesOnlineTimeFrameOptions_model")]
    public class DevicePropertiesOnlineTimeFrameOptions
    {
        [JsonConstructorAttribute]
        protected DevicePropertiesOnlineTimeFrameOptions() { }

        public DevicePropertiesOnlineTimeFrameOptions(
            string displayName = default,
            string? endDateRecurrenceRule = default,
            bool? matchingStartEndTime = default,
            string? maxDuration = default,
            string? minDuration = default,
            string? startDateRecurrenceRule = default,
            List<DevicePropertiesOnlineTimeFrameOptionsTimePairs>? timePairs = default,
            string? timeZone = default
        )
        {
            DisplayName = displayName;
            EndDateRecurrenceRule = endDateRecurrenceRule;
            MatchingStartEndTime = matchingStartEndTime;
            MaxDuration = maxDuration;
            MinDuration = minDuration;
            StartDateRecurrenceRule = startDateRecurrenceRule;
            TimePairs = timePairs;
            TimeZone = timeZone;
        }

        /// <summary>
        /// Label for this option. For a single-option device, the product name (for example, `algoPIN` or `SmartPIN`); for a multi-option device, a label that distinguishes it (for example, `Hourly` or `Fixed start times`).
        /// </summary>
        [DataMember(Name = "display_name", IsRequired = false, EmitDefaultValue = false)]
        public string DisplayName { get; set; }

        /// <summary>
        /// iCalendar recurrence rule (RRULE) that the end date must fall on. Constrains which calendar dates are selectable, independent of the time-of-day rules.
        /// </summary>
        [DataMember(
            Name = "end_date_recurrence_rule",
            IsRequired = false,
            EmitDefaultValue = false
        )]
        public string? EndDateRecurrenceRule { get; set; }

        /// <summary>
        /// When `true`, the start and end must fall at the same time of day (the caller picks which). Mutually exclusive with `time_pairs`.
        /// </summary>
        [DataMember(Name = "matching_start_end_time", IsRequired = false, EmitDefaultValue = false)]
        public bool? MatchingStartEndTime { get; set; }

        /// <summary>
        /// Maximum duration this option covers, as an ISO 8601 duration (for example, `PT672H` or `P367D`). Omitted when there is no maximum.
        /// </summary>
        [DataMember(Name = "max_duration", IsRequired = false, EmitDefaultValue = false)]
        public string? MaxDuration { get; set; }

        /// <summary>
        /// Minimum duration this option covers, as an ISO 8601 duration (for example, `PT1H` or `P29D`). Omitted when there is no minimum.
        /// </summary>
        [DataMember(Name = "min_duration", IsRequired = false, EmitDefaultValue = false)]
        public string? MinDuration { get; set; }

        /// <summary>
        /// iCalendar recurrence rule (RRULE) that the start date must fall on (for example, `FREQ=MONTHLY;BYDAY=1MO,3MO`). Constrains which calendar dates are selectable, independent of the time-of-day rules.
        /// </summary>
        [DataMember(
            Name = "start_date_recurrence_rule",
            IsRequired = false,
            EmitDefaultValue = false
        )]
        public string? StartDateRecurrenceRule { get; set; }

        /// <summary>
        /// Fixed start/end time pairings the caller chooses from. Mutually exclusive with `matching_start_end_time`.
        /// </summary>
        [DataMember(Name = "time_pairs", IsRequired = false, EmitDefaultValue = false)]
        public List<DevicePropertiesOnlineTimeFrameOptionsTimePairs>? TimePairs { get; set; }

        /// <summary>
        /// IANA time zone for interpreting `time_pairs` and the date recurrence rules. Present only when the option fixes times or dates.
        /// </summary>
        [DataMember(Name = "time_zone", IsRequired = false, EmitDefaultValue = false)]
        public string? TimeZone { get; set; }

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

    [DataContract(Name = "seamModel_devicePropertiesOnlineTimeFrameOptionsTimePairs_model")]
    public class DevicePropertiesOnlineTimeFrameOptionsTimePairs
    {
        [JsonConstructorAttribute]
        protected DevicePropertiesOnlineTimeFrameOptionsTimePairs() { }

        public DevicePropertiesOnlineTimeFrameOptionsTimePairs(
            string displayName = default,
            string endTime = default,
            string startTime = default
        )
        {
            DisplayName = displayName;
            EndTime = endTime;
            StartTime = startTime;
        }

        /// <summary>
        /// Label for the start/end time pairing.
        /// </summary>
        [DataMember(Name = "display_name", IsRequired = false, EmitDefaultValue = false)]
        public string DisplayName { get; set; }

        /// <summary>
        /// End time of day as a 24-hour `HH:MM` value, interpreted in the option&apos;s `time_zone`. An `end_time` earlier on the clock than `start_time` means the end falls on a later date.
        /// </summary>
        [DataMember(Name = "end_time", IsRequired = false, EmitDefaultValue = false)]
        public string EndTime { get; set; }

        /// <summary>
        /// Start time of day as a 24-hour `HH:MM` value, interpreted in the option&apos;s `time_zone`.
        /// </summary>
        [DataMember(Name = "start_time", IsRequired = false, EmitDefaultValue = false)]
        public string StartTime { get; set; }

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

    [DataContract(Name = "seamModel_devicePropertiesActiveThermostatSchedule_model")]
    public class DevicePropertiesActiveThermostatSchedule
    {
        [JsonConstructorAttribute]
        protected DevicePropertiesActiveThermostatSchedule() { }

        public DevicePropertiesActiveThermostatSchedule(
            string climatePresetKey = default,
            string createdAt = default,
            string deviceId = default,
            string endsAt = default,
            List<DevicePropertiesActiveThermostatScheduleErrors> errors = default,
            bool? isOverrideAllowed = default,
            int? maxOverridePeriodMinutes = default,
            string? name = default,
            string startsAt = default,
            string thermostatScheduleId = default,
            string workspaceId = default
        )
        {
            ClimatePresetKey = climatePresetKey;
            CreatedAt = createdAt;
            DeviceId = deviceId;
            EndsAt = endsAt;
            Errors = errors;
            IsOverrideAllowed = isOverrideAllowed;
            MaxOverridePeriodMinutes = maxOverridePeriodMinutes;
            Name = name;
            StartsAt = startsAt;
            ThermostatScheduleId = thermostatScheduleId;
            WorkspaceId = workspaceId;
        }

        /// <summary>
        /// Key of the [climate preset](https://docs.seam.co/capability-guides/thermostats/creating-and-managing-climate-presets) to use for the [thermostat schedule](https://docs.seam.co/capability-guides/thermostats/creating-and-managing-thermostat-schedules).
        /// </summary>
        [DataMember(Name = "climate_preset_key", IsRequired = false, EmitDefaultValue = false)]
        public string ClimatePresetKey { get; set; }

        /// <summary>
        /// Date and time at which the [thermostat schedule](https://docs.seam.co/capability-guides/thermostats/creating-and-managing-thermostat-schedules) was created.
        /// </summary>
        [DataMember(Name = "created_at", IsRequired = false, EmitDefaultValue = false)]
        public string CreatedAt { get; set; }

        /// <summary>
        /// ID of the desired [thermostat](https://docs.seam.co/capability-guides/thermostats) device.
        /// </summary>
        [DataMember(Name = "device_id", IsRequired = false, EmitDefaultValue = false)]
        public string DeviceId { get; set; }

        /// <summary>
        /// Date and time at which the [thermostat schedule](https://docs.seam.co/capability-guides/thermostats/creating-and-managing-thermostat-schedules) ends, in [ISO 8601](https://www.iso.org/iso-8601-date-and-time-format.html) format.
        /// </summary>
        [DataMember(Name = "ends_at", IsRequired = false, EmitDefaultValue = false)]
        public string EndsAt { get; set; }

        /// <summary>
        /// Errors associated with the [thermostat schedule](https://docs.seam.co/capability-guides/thermostats/creating-and-managing-thermostat-schedules).
        /// </summary>
        [DataMember(Name = "errors", IsRequired = false, EmitDefaultValue = false)]
        public List<DevicePropertiesActiveThermostatScheduleErrors> Errors { get; set; }

        /// <summary>
        /// Indicates whether a person at the thermostat can change the thermostat&apos;s settings after the [thermostat schedule](https://docs.seam.co/capability-guides/thermostats/creating-and-managing-thermostat-schedules) starts.
        /// </summary>
        [DataMember(Name = "is_override_allowed", IsRequired = false, EmitDefaultValue = false)]
        public bool? IsOverrideAllowed { get; set; }

        /// <summary>
        /// Number of minutes for which a person at the thermostat can change the thermostat&apos;s settings after the activation of the scheduled [climate preset](https://docs.seam.co/capability-guides/thermostats/creating-and-managing-climate-presets). See also [Specifying Manual Override Permissions](https://docs.seam.co/capability-guides/thermostats/creating-and-managing-thermostat-schedules#specifying-manual-override-permissions).
        /// </summary>
        [DataMember(
            Name = "max_override_period_minutes",
            IsRequired = false,
            EmitDefaultValue = false
        )]
        public int? MaxOverridePeriodMinutes { get; set; }

        /// <summary>
        /// User-friendly name to identify the [thermostat schedule](https://docs.seam.co/capability-guides/thermostats/creating-and-managing-thermostat-schedules).
        /// </summary>
        [DataMember(Name = "name", IsRequired = false, EmitDefaultValue = false)]
        public string? Name { get; set; }

        /// <summary>
        /// Date and time at which the [thermostat schedule](https://docs.seam.co/capability-guides/thermostats/creating-and-managing-thermostat-schedules) starts, in [ISO 8601](https://www.iso.org/iso-8601-date-and-time-format.html) format.
        /// </summary>
        [DataMember(Name = "starts_at", IsRequired = false, EmitDefaultValue = false)]
        public string StartsAt { get; set; }

        /// <summary>
        /// ID of the [thermostat schedule](https://docs.seam.co/capability-guides/thermostats/creating-and-managing-thermostat-schedules).
        /// </summary>
        [DataMember(Name = "thermostat_schedule_id", IsRequired = false, EmitDefaultValue = false)]
        public string ThermostatScheduleId { get; set; }

        /// <summary>
        /// ID of the workspace that contains the thermostat schedule.
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

    [DataContract(Name = "seamModel_devicePropertiesActiveThermostatScheduleErrors_model")]
    public class DevicePropertiesActiveThermostatScheduleErrors
    {
        [JsonConstructorAttribute]
        protected DevicePropertiesActiveThermostatScheduleErrors() { }

        public DevicePropertiesActiveThermostatScheduleErrors(
            string createdAt = default,
            string errorCode = default,
            string message = default
        )
        {
            CreatedAt = createdAt;
            ErrorCode = errorCode;
            Message = message;
        }

        /// <summary>
        /// Date and time at which Seam created the error.
        /// </summary>
        [DataMember(Name = "created_at", IsRequired = false, EmitDefaultValue = false)]
        public string CreatedAt { get; set; }

        /// <summary>
        /// Unique identifier of the type of error. Enables quick recognition and categorization of the issue.
        /// </summary>
        [DataMember(Name = "error_code", IsRequired = false, EmitDefaultValue = false)]
        public string ErrorCode { get; set; }

        /// <summary>
        /// Detailed description of the error. Provides insights into the issue and potentially how to rectify it.
        /// </summary>
        [DataMember(Name = "message", IsRequired = false, EmitDefaultValue = false)]
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

    [DataContract(Name = "seamModel_devicePropertiesAvailableClimatePresets_model")]
    public class DevicePropertiesAvailableClimatePresets
    {
        [JsonConstructorAttribute]
        protected DevicePropertiesAvailableClimatePresets() { }

        public DevicePropertiesAvailableClimatePresets(
            bool canDelete = default,
            bool canEdit = default,
            bool canUseWithThermostatDailyPrograms = default,
            string climatePresetKey = default,
            DevicePropertiesAvailableClimatePresets.ClimatePresetModeEnum? climatePresetMode =
                default,
            float? coolingSetPointCelsius = default,
            float? coolingSetPointFahrenheit = default,
            string displayName = default,
            DevicePropertiesAvailableClimatePresetsEcobeeMetadata? ecobeeMetadata = default,
            DevicePropertiesAvailableClimatePresets.FanModeSettingEnum? fanModeSetting = default,
            float? heatingSetPointCelsius = default,
            float? heatingSetPointFahrenheit = default,
            DevicePropertiesAvailableClimatePresets.HvacModeSettingEnum? hvacModeSetting = default,
            bool manualOverrideAllowed = default,
            string? name = default
        )
        {
            CanDelete = canDelete;
            CanEdit = canEdit;
            CanUseWithThermostatDailyPrograms = canUseWithThermostatDailyPrograms;
            ClimatePresetKey = climatePresetKey;
            ClimatePresetMode = climatePresetMode;
            CoolingSetPointCelsius = coolingSetPointCelsius;
            CoolingSetPointFahrenheit = coolingSetPointFahrenheit;
            DisplayName = displayName;
            EcobeeMetadata = ecobeeMetadata;
            FanModeSetting = fanModeSetting;
            HeatingSetPointCelsius = heatingSetPointCelsius;
            HeatingSetPointFahrenheit = heatingSetPointFahrenheit;
            HvacModeSetting = hvacModeSetting;
            ManualOverrideAllowed = manualOverrideAllowed;
            Name = name;
        }

        /// <summary>
        /// The climate preset mode for the thermostat, based on the available climate preset modes reported by the device.
        /// </summary>
        [JsonConverter(typeof(SafeStringEnumConverter))]
        public enum ClimatePresetModeEnum
        {
            [EnumMember(Value = "unrecognized")]
            Unrecognized = 0,

            [EnumMember(Value = "home")]
            Home = 1,

            [EnumMember(Value = "away")]
            Away = 2,

            [EnumMember(Value = "wake")]
            Wake = 3,

            [EnumMember(Value = "sleep")]
            Sleep = 4,

            [EnumMember(Value = "occupied")]
            Occupied = 5,

            [EnumMember(Value = "unoccupied")]
            Unoccupied = 6,
        }

        /// <summary>
        /// Desired [fan mode setting](https://docs.seam.co/capability-guides/thermostats/configure-current-climate-settings#fan-mode-settings), such as `on`, `auto`, or `circulate`.
        /// </summary>
        [JsonConverter(typeof(SafeStringEnumConverter))]
        public enum FanModeSettingEnum
        {
            [EnumMember(Value = "unrecognized")]
            Unrecognized = 0,

            [EnumMember(Value = "auto")]
            Auto = 1,

            [EnumMember(Value = "on")]
            On = 2,

            [EnumMember(Value = "circulate")]
            Circulate = 3,
        }

        /// <summary>
        /// Desired [HVAC mode](https://docs.seam.co/capability-guides/thermostats/understanding-thermostat-concepts/hvac-mode) setting, such as `heat`, `cool`, `heat_cool`, or `off`.
        /// </summary>
        [JsonConverter(typeof(SafeStringEnumConverter))]
        public enum HvacModeSettingEnum
        {
            [EnumMember(Value = "unrecognized")]
            Unrecognized = 0,

            [EnumMember(Value = "off")]
            Off = 1,

            [EnumMember(Value = "heat")]
            Heat = 2,

            [EnumMember(Value = "cool")]
            Cool = 3,

            [EnumMember(Value = "heat_cool")]
            HeatCool = 4,

            [EnumMember(Value = "eco")]
            Eco = 5,
        }

        /// <summary>
        /// Indicates whether the [climate preset](https://docs.seam.co/capability-guides/thermostats/creating-and-managing-climate-presets) key can be deleted.
        /// </summary>
        [DataMember(Name = "can_delete", IsRequired = false, EmitDefaultValue = false)]
        public bool CanDelete { get; set; }

        /// <summary>
        /// Indicates whether the [climate preset](https://docs.seam.co/capability-guides/thermostats/creating-and-managing-climate-presets) key can be edited.
        /// </summary>
        [DataMember(Name = "can_edit", IsRequired = false, EmitDefaultValue = false)]
        public bool CanEdit { get; set; }

        /// <summary>
        /// Indicates whether the [climate preset](https://docs.seam.co/capability-guides/thermostats/creating-and-managing-climate-presets) key can be programmed in a thermostat daily program.
        /// </summary>
        [DataMember(
            Name = "can_use_with_thermostat_daily_programs",
            IsRequired = false,
            EmitDefaultValue = false
        )]
        public bool CanUseWithThermostatDailyPrograms { get; set; }

        /// <summary>
        /// Unique key to identify the [climate preset](https://docs.seam.co/capability-guides/thermostats/creating-and-managing-climate-presets).
        /// </summary>
        [DataMember(Name = "climate_preset_key", IsRequired = false, EmitDefaultValue = false)]
        public string ClimatePresetKey { get; set; }

        /// <summary>
        /// The climate preset mode for the thermostat, based on the available climate preset modes reported by the device.
        /// </summary>
        [DataMember(Name = "climate_preset_mode", IsRequired = false, EmitDefaultValue = false)]
        public DevicePropertiesAvailableClimatePresets.ClimatePresetModeEnum? ClimatePresetMode { get; set; }

        /// <summary>
        /// Temperature to which the thermostat should cool (in °C). See also [Set Points](https://docs.seam.co/capability-guides/thermostats/understanding-thermostat-concepts/set-points).
        /// </summary>
        [DataMember(
            Name = "cooling_set_point_celsius",
            IsRequired = false,
            EmitDefaultValue = false
        )]
        public float? CoolingSetPointCelsius { get; set; }

        /// <summary>
        /// Temperature to which the thermostat should cool (in °F). See also [Set Points](https://docs.seam.co/capability-guides/thermostats/understanding-thermostat-concepts/set-points).
        /// </summary>
        [DataMember(
            Name = "cooling_set_point_fahrenheit",
            IsRequired = false,
            EmitDefaultValue = false
        )]
        public float? CoolingSetPointFahrenheit { get; set; }

        /// <summary>
        /// Display name for the [climate preset](https://docs.seam.co/capability-guides/thermostats/creating-and-managing-climate-presets).
        /// </summary>
        [DataMember(Name = "display_name", IsRequired = false, EmitDefaultValue = false)]
        public string DisplayName { get; set; }

        /// <summary>
        /// Metadata specific to the Ecobee climate, if applicable.
        /// </summary>
        [DataMember(Name = "ecobee_metadata", IsRequired = false, EmitDefaultValue = false)]
        public DevicePropertiesAvailableClimatePresetsEcobeeMetadata? EcobeeMetadata { get; set; }

        /// <summary>
        /// Desired [fan mode setting](https://docs.seam.co/capability-guides/thermostats/configure-current-climate-settings#fan-mode-settings), such as `on`, `auto`, or `circulate`.
        /// </summary>
        [DataMember(Name = "fan_mode_setting", IsRequired = false, EmitDefaultValue = false)]
        public DevicePropertiesAvailableClimatePresets.FanModeSettingEnum? FanModeSetting { get; set; }

        /// <summary>
        /// Temperature to which the thermostat should heat (in °C). See also [Set Points](https://docs.seam.co/capability-guides/thermostats/understanding-thermostat-concepts/set-points).
        /// </summary>
        [DataMember(
            Name = "heating_set_point_celsius",
            IsRequired = false,
            EmitDefaultValue = false
        )]
        public float? HeatingSetPointCelsius { get; set; }

        /// <summary>
        /// Temperature to which the thermostat should heat (in °F). See also [Set Points](https://docs.seam.co/capability-guides/thermostats/understanding-thermostat-concepts/set-points).
        /// </summary>
        [DataMember(
            Name = "heating_set_point_fahrenheit",
            IsRequired = false,
            EmitDefaultValue = false
        )]
        public float? HeatingSetPointFahrenheit { get; set; }

        /// <summary>
        /// Desired [HVAC mode](https://docs.seam.co/capability-guides/thermostats/understanding-thermostat-concepts/hvac-mode) setting, such as `heat`, `cool`, `heat_cool`, or `off`.
        /// </summary>
        [DataMember(Name = "hvac_mode_setting", IsRequired = false, EmitDefaultValue = false)]
        public DevicePropertiesAvailableClimatePresets.HvacModeSettingEnum? HvacModeSetting { get; set; }

        /// <summary>
        /// Indicates whether a person at the thermostat can change the thermostat&apos;s settings. See [Specifying Manual Override Permissions](https://docs.seam.co/capability-guides/thermostats/creating-and-managing-thermostat-schedules#specifying-manual-override-permissions).
        /// </summary>
        [Obsolete("Use 'thermostat_schedule.is_override_allowed'")]
        [DataMember(Name = "manual_override_allowed", IsRequired = false, EmitDefaultValue = false)]
        public bool ManualOverrideAllowed { get; set; }

        /// <summary>
        /// User-friendly name to identify the [climate preset](https://docs.seam.co/capability-guides/thermostats/creating-and-managing-climate-presets).
        /// </summary>
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

    [DataContract(Name = "seamModel_devicePropertiesAvailableClimatePresetsEcobeeMetadata_model")]
    public class DevicePropertiesAvailableClimatePresetsEcobeeMetadata
    {
        [JsonConstructorAttribute]
        protected DevicePropertiesAvailableClimatePresetsEcobeeMetadata() { }

        public DevicePropertiesAvailableClimatePresetsEcobeeMetadata(
            string? climateRef = default,
            bool? isOptimized = default,
            DevicePropertiesAvailableClimatePresetsEcobeeMetadata.OwnerEnum? owner = default
        )
        {
            ClimateRef = climateRef;
            IsOptimized = isOptimized;
            Owner = owner;
        }

        /// <summary>
        /// Indicates whether the climate preset is owned by the user or the system.
        /// </summary>
        [JsonConverter(typeof(SafeStringEnumConverter))]
        public enum OwnerEnum
        {
            [EnumMember(Value = "unrecognized")]
            Unrecognized = 0,

            [EnumMember(Value = "user")]
            User = 1,

            [EnumMember(Value = "system")]
            System = 2,
        }

        /// <summary>
        /// Reference to the Ecobee climate, if applicable.
        /// </summary>
        [DataMember(Name = "climate_ref", IsRequired = false, EmitDefaultValue = false)]
        public string? ClimateRef { get; set; }

        /// <summary>
        /// Indicates if the climate preset is optimized by Ecobee.
        /// </summary>
        [DataMember(Name = "is_optimized", IsRequired = false, EmitDefaultValue = false)]
        public bool? IsOptimized { get; set; }

        /// <summary>
        /// Indicates whether the climate preset is owned by the user or the system.
        /// </summary>
        [DataMember(Name = "owner", IsRequired = false, EmitDefaultValue = false)]
        public DevicePropertiesAvailableClimatePresetsEcobeeMetadata.OwnerEnum? Owner { get; set; }

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

    [DataContract(Name = "seamModel_devicePropertiesCurrentClimateSetting_model")]
    public class DevicePropertiesCurrentClimateSetting
    {
        [JsonConstructorAttribute]
        protected DevicePropertiesCurrentClimateSetting() { }

        public DevicePropertiesCurrentClimateSetting(
            bool? canDelete = default,
            bool? canEdit = default,
            bool? canUseWithThermostatDailyPrograms = default,
            string? climatePresetKey = default,
            DevicePropertiesCurrentClimateSetting.ClimatePresetModeEnum? climatePresetMode =
                default,
            float? coolingSetPointCelsius = default,
            float? coolingSetPointFahrenheit = default,
            string? displayName = default,
            DevicePropertiesCurrentClimateSettingEcobeeMetadata? ecobeeMetadata = default,
            DevicePropertiesCurrentClimateSetting.FanModeSettingEnum? fanModeSetting = default,
            float? heatingSetPointCelsius = default,
            float? heatingSetPointFahrenheit = default,
            DevicePropertiesCurrentClimateSetting.HvacModeSettingEnum? hvacModeSetting = default,
            bool? manualOverrideAllowed = default,
            string? name = default
        )
        {
            CanDelete = canDelete;
            CanEdit = canEdit;
            CanUseWithThermostatDailyPrograms = canUseWithThermostatDailyPrograms;
            ClimatePresetKey = climatePresetKey;
            ClimatePresetMode = climatePresetMode;
            CoolingSetPointCelsius = coolingSetPointCelsius;
            CoolingSetPointFahrenheit = coolingSetPointFahrenheit;
            DisplayName = displayName;
            EcobeeMetadata = ecobeeMetadata;
            FanModeSetting = fanModeSetting;
            HeatingSetPointCelsius = heatingSetPointCelsius;
            HeatingSetPointFahrenheit = heatingSetPointFahrenheit;
            HvacModeSetting = hvacModeSetting;
            ManualOverrideAllowed = manualOverrideAllowed;
            Name = name;
        }

        /// <summary>
        /// The climate preset mode for the thermostat, based on the available climate preset modes reported by the device.
        /// </summary>
        [JsonConverter(typeof(SafeStringEnumConverter))]
        public enum ClimatePresetModeEnum
        {
            [EnumMember(Value = "unrecognized")]
            Unrecognized = 0,

            [EnumMember(Value = "home")]
            Home = 1,

            [EnumMember(Value = "away")]
            Away = 2,

            [EnumMember(Value = "wake")]
            Wake = 3,

            [EnumMember(Value = "sleep")]
            Sleep = 4,

            [EnumMember(Value = "occupied")]
            Occupied = 5,

            [EnumMember(Value = "unoccupied")]
            Unoccupied = 6,
        }

        /// <summary>
        /// Desired [fan mode setting](https://docs.seam.co/capability-guides/thermostats/configure-current-climate-settings#fan-mode-settings), such as `on`, `auto`, or `circulate`.
        /// </summary>
        [JsonConverter(typeof(SafeStringEnumConverter))]
        public enum FanModeSettingEnum
        {
            [EnumMember(Value = "unrecognized")]
            Unrecognized = 0,

            [EnumMember(Value = "auto")]
            Auto = 1,

            [EnumMember(Value = "on")]
            On = 2,

            [EnumMember(Value = "circulate")]
            Circulate = 3,
        }

        /// <summary>
        /// Desired [HVAC mode](https://docs.seam.co/capability-guides/thermostats/understanding-thermostat-concepts/hvac-mode) setting, such as `heat`, `cool`, `heat_cool`, or `off`.
        /// </summary>
        [JsonConverter(typeof(SafeStringEnumConverter))]
        public enum HvacModeSettingEnum
        {
            [EnumMember(Value = "unrecognized")]
            Unrecognized = 0,

            [EnumMember(Value = "off")]
            Off = 1,

            [EnumMember(Value = "heat")]
            Heat = 2,

            [EnumMember(Value = "cool")]
            Cool = 3,

            [EnumMember(Value = "heat_cool")]
            HeatCool = 4,

            [EnumMember(Value = "eco")]
            Eco = 5,
        }

        /// <summary>
        /// Indicates whether the [climate preset](https://docs.seam.co/capability-guides/thermostats/creating-and-managing-climate-presets) key can be deleted.
        /// </summary>
        [DataMember(Name = "can_delete", IsRequired = false, EmitDefaultValue = false)]
        public bool? CanDelete { get; set; }

        /// <summary>
        /// Indicates whether the [climate preset](https://docs.seam.co/capability-guides/thermostats/creating-and-managing-climate-presets) key can be edited.
        /// </summary>
        [DataMember(Name = "can_edit", IsRequired = false, EmitDefaultValue = false)]
        public bool? CanEdit { get; set; }

        /// <summary>
        /// Indicates whether the [climate preset](https://docs.seam.co/capability-guides/thermostats/creating-and-managing-climate-presets) key can be programmed in a thermostat daily program.
        /// </summary>
        [DataMember(
            Name = "can_use_with_thermostat_daily_programs",
            IsRequired = false,
            EmitDefaultValue = false
        )]
        public bool? CanUseWithThermostatDailyPrograms { get; set; }

        /// <summary>
        /// Unique key to identify the [climate preset](https://docs.seam.co/capability-guides/thermostats/creating-and-managing-climate-presets).
        /// </summary>
        [DataMember(Name = "climate_preset_key", IsRequired = false, EmitDefaultValue = false)]
        public string? ClimatePresetKey { get; set; }

        /// <summary>
        /// The climate preset mode for the thermostat, based on the available climate preset modes reported by the device.
        /// </summary>
        [DataMember(Name = "climate_preset_mode", IsRequired = false, EmitDefaultValue = false)]
        public DevicePropertiesCurrentClimateSetting.ClimatePresetModeEnum? ClimatePresetMode { get; set; }

        /// <summary>
        /// Temperature to which the thermostat should cool (in °C). See also [Set Points](https://docs.seam.co/capability-guides/thermostats/understanding-thermostat-concepts/set-points).
        /// </summary>
        [DataMember(
            Name = "cooling_set_point_celsius",
            IsRequired = false,
            EmitDefaultValue = false
        )]
        public float? CoolingSetPointCelsius { get; set; }

        /// <summary>
        /// Temperature to which the thermostat should cool (in °F). See also [Set Points](https://docs.seam.co/capability-guides/thermostats/understanding-thermostat-concepts/set-points).
        /// </summary>
        [DataMember(
            Name = "cooling_set_point_fahrenheit",
            IsRequired = false,
            EmitDefaultValue = false
        )]
        public float? CoolingSetPointFahrenheit { get; set; }

        /// <summary>
        /// Display name for the [climate preset](https://docs.seam.co/capability-guides/thermostats/creating-and-managing-climate-presets).
        /// </summary>
        [DataMember(Name = "display_name", IsRequired = false, EmitDefaultValue = false)]
        public string? DisplayName { get; set; }

        /// <summary>
        /// Metadata specific to the Ecobee climate, if applicable.
        /// </summary>
        [DataMember(Name = "ecobee_metadata", IsRequired = false, EmitDefaultValue = false)]
        public DevicePropertiesCurrentClimateSettingEcobeeMetadata? EcobeeMetadata { get; set; }

        /// <summary>
        /// Desired [fan mode setting](https://docs.seam.co/capability-guides/thermostats/configure-current-climate-settings#fan-mode-settings), such as `on`, `auto`, or `circulate`.
        /// </summary>
        [DataMember(Name = "fan_mode_setting", IsRequired = false, EmitDefaultValue = false)]
        public DevicePropertiesCurrentClimateSetting.FanModeSettingEnum? FanModeSetting { get; set; }

        /// <summary>
        /// Temperature to which the thermostat should heat (in °C). See also [Set Points](https://docs.seam.co/capability-guides/thermostats/understanding-thermostat-concepts/set-points).
        /// </summary>
        [DataMember(
            Name = "heating_set_point_celsius",
            IsRequired = false,
            EmitDefaultValue = false
        )]
        public float? HeatingSetPointCelsius { get; set; }

        /// <summary>
        /// Temperature to which the thermostat should heat (in °F). See also [Set Points](https://docs.seam.co/capability-guides/thermostats/understanding-thermostat-concepts/set-points).
        /// </summary>
        [DataMember(
            Name = "heating_set_point_fahrenheit",
            IsRequired = false,
            EmitDefaultValue = false
        )]
        public float? HeatingSetPointFahrenheit { get; set; }

        /// <summary>
        /// Desired [HVAC mode](https://docs.seam.co/capability-guides/thermostats/understanding-thermostat-concepts/hvac-mode) setting, such as `heat`, `cool`, `heat_cool`, or `off`.
        /// </summary>
        [DataMember(Name = "hvac_mode_setting", IsRequired = false, EmitDefaultValue = false)]
        public DevicePropertiesCurrentClimateSetting.HvacModeSettingEnum? HvacModeSetting { get; set; }

        /// <summary>
        /// Indicates whether a person at the thermostat can change the thermostat&apos;s settings. See [Specifying Manual Override Permissions](https://docs.seam.co/capability-guides/thermostats/creating-and-managing-thermostat-schedules#specifying-manual-override-permissions).
        /// </summary>
        [Obsolete("Use 'thermostat_schedule.is_override_allowed'")]
        [DataMember(Name = "manual_override_allowed", IsRequired = false, EmitDefaultValue = false)]
        public bool? ManualOverrideAllowed { get; set; }

        /// <summary>
        /// User-friendly name to identify the [climate preset](https://docs.seam.co/capability-guides/thermostats/creating-and-managing-climate-presets).
        /// </summary>
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

    [DataContract(Name = "seamModel_devicePropertiesCurrentClimateSettingEcobeeMetadata_model")]
    public class DevicePropertiesCurrentClimateSettingEcobeeMetadata
    {
        [JsonConstructorAttribute]
        protected DevicePropertiesCurrentClimateSettingEcobeeMetadata() { }

        public DevicePropertiesCurrentClimateSettingEcobeeMetadata(
            string? climateRef = default,
            bool? isOptimized = default,
            DevicePropertiesCurrentClimateSettingEcobeeMetadata.OwnerEnum? owner = default
        )
        {
            ClimateRef = climateRef;
            IsOptimized = isOptimized;
            Owner = owner;
        }

        /// <summary>
        /// Indicates whether the climate preset is owned by the user or the system.
        /// </summary>
        [JsonConverter(typeof(SafeStringEnumConverter))]
        public enum OwnerEnum
        {
            [EnumMember(Value = "unrecognized")]
            Unrecognized = 0,

            [EnumMember(Value = "user")]
            User = 1,

            [EnumMember(Value = "system")]
            System = 2,
        }

        /// <summary>
        /// Reference to the Ecobee climate, if applicable.
        /// </summary>
        [DataMember(Name = "climate_ref", IsRequired = false, EmitDefaultValue = false)]
        public string? ClimateRef { get; set; }

        /// <summary>
        /// Indicates if the climate preset is optimized by Ecobee.
        /// </summary>
        [DataMember(Name = "is_optimized", IsRequired = false, EmitDefaultValue = false)]
        public bool? IsOptimized { get; set; }

        /// <summary>
        /// Indicates whether the climate preset is owned by the user or the system.
        /// </summary>
        [DataMember(Name = "owner", IsRequired = false, EmitDefaultValue = false)]
        public DevicePropertiesCurrentClimateSettingEcobeeMetadata.OwnerEnum? Owner { get; set; }

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

    [DataContract(Name = "seamModel_devicePropertiesDefaultClimateSetting_model")]
    public class DevicePropertiesDefaultClimateSetting
    {
        [JsonConstructorAttribute]
        protected DevicePropertiesDefaultClimateSetting() { }

        public DevicePropertiesDefaultClimateSetting(
            bool? canDelete = default,
            bool? canEdit = default,
            bool? canUseWithThermostatDailyPrograms = default,
            string? climatePresetKey = default,
            DevicePropertiesDefaultClimateSetting.ClimatePresetModeEnum? climatePresetMode =
                default,
            float? coolingSetPointCelsius = default,
            float? coolingSetPointFahrenheit = default,
            string? displayName = default,
            DevicePropertiesDefaultClimateSettingEcobeeMetadata? ecobeeMetadata = default,
            DevicePropertiesDefaultClimateSetting.FanModeSettingEnum? fanModeSetting = default,
            float? heatingSetPointCelsius = default,
            float? heatingSetPointFahrenheit = default,
            DevicePropertiesDefaultClimateSetting.HvacModeSettingEnum? hvacModeSetting = default,
            bool? manualOverrideAllowed = default,
            string? name = default
        )
        {
            CanDelete = canDelete;
            CanEdit = canEdit;
            CanUseWithThermostatDailyPrograms = canUseWithThermostatDailyPrograms;
            ClimatePresetKey = climatePresetKey;
            ClimatePresetMode = climatePresetMode;
            CoolingSetPointCelsius = coolingSetPointCelsius;
            CoolingSetPointFahrenheit = coolingSetPointFahrenheit;
            DisplayName = displayName;
            EcobeeMetadata = ecobeeMetadata;
            FanModeSetting = fanModeSetting;
            HeatingSetPointCelsius = heatingSetPointCelsius;
            HeatingSetPointFahrenheit = heatingSetPointFahrenheit;
            HvacModeSetting = hvacModeSetting;
            ManualOverrideAllowed = manualOverrideAllowed;
            Name = name;
        }

        /// <summary>
        /// The climate preset mode for the thermostat, based on the available climate preset modes reported by the device.
        /// </summary>
        [JsonConverter(typeof(SafeStringEnumConverter))]
        public enum ClimatePresetModeEnum
        {
            [EnumMember(Value = "unrecognized")]
            Unrecognized = 0,

            [EnumMember(Value = "home")]
            Home = 1,

            [EnumMember(Value = "away")]
            Away = 2,

            [EnumMember(Value = "wake")]
            Wake = 3,

            [EnumMember(Value = "sleep")]
            Sleep = 4,

            [EnumMember(Value = "occupied")]
            Occupied = 5,

            [EnumMember(Value = "unoccupied")]
            Unoccupied = 6,
        }

        /// <summary>
        /// Desired [fan mode setting](https://docs.seam.co/capability-guides/thermostats/configure-current-climate-settings#fan-mode-settings), such as `on`, `auto`, or `circulate`.
        /// </summary>
        [JsonConverter(typeof(SafeStringEnumConverter))]
        public enum FanModeSettingEnum
        {
            [EnumMember(Value = "unrecognized")]
            Unrecognized = 0,

            [EnumMember(Value = "auto")]
            Auto = 1,

            [EnumMember(Value = "on")]
            On = 2,

            [EnumMember(Value = "circulate")]
            Circulate = 3,
        }

        /// <summary>
        /// Desired [HVAC mode](https://docs.seam.co/capability-guides/thermostats/understanding-thermostat-concepts/hvac-mode) setting, such as `heat`, `cool`, `heat_cool`, or `off`.
        /// </summary>
        [JsonConverter(typeof(SafeStringEnumConverter))]
        public enum HvacModeSettingEnum
        {
            [EnumMember(Value = "unrecognized")]
            Unrecognized = 0,

            [EnumMember(Value = "off")]
            Off = 1,

            [EnumMember(Value = "heat")]
            Heat = 2,

            [EnumMember(Value = "cool")]
            Cool = 3,

            [EnumMember(Value = "heat_cool")]
            HeatCool = 4,

            [EnumMember(Value = "eco")]
            Eco = 5,
        }

        /// <summary>
        /// Indicates whether the [climate preset](https://docs.seam.co/capability-guides/thermostats/creating-and-managing-climate-presets) key can be deleted.
        /// </summary>
        [DataMember(Name = "can_delete", IsRequired = false, EmitDefaultValue = false)]
        public bool? CanDelete { get; set; }

        /// <summary>
        /// Indicates whether the [climate preset](https://docs.seam.co/capability-guides/thermostats/creating-and-managing-climate-presets) key can be edited.
        /// </summary>
        [DataMember(Name = "can_edit", IsRequired = false, EmitDefaultValue = false)]
        public bool? CanEdit { get; set; }

        /// <summary>
        /// Indicates whether the [climate preset](https://docs.seam.co/capability-guides/thermostats/creating-and-managing-climate-presets) key can be programmed in a thermostat daily program.
        /// </summary>
        [DataMember(
            Name = "can_use_with_thermostat_daily_programs",
            IsRequired = false,
            EmitDefaultValue = false
        )]
        public bool? CanUseWithThermostatDailyPrograms { get; set; }

        /// <summary>
        /// Unique key to identify the [climate preset](https://docs.seam.co/capability-guides/thermostats/creating-and-managing-climate-presets).
        /// </summary>
        [DataMember(Name = "climate_preset_key", IsRequired = false, EmitDefaultValue = false)]
        public string? ClimatePresetKey { get; set; }

        /// <summary>
        /// The climate preset mode for the thermostat, based on the available climate preset modes reported by the device.
        /// </summary>
        [DataMember(Name = "climate_preset_mode", IsRequired = false, EmitDefaultValue = false)]
        public DevicePropertiesDefaultClimateSetting.ClimatePresetModeEnum? ClimatePresetMode { get; set; }

        /// <summary>
        /// Temperature to which the thermostat should cool (in °C). See also [Set Points](https://docs.seam.co/capability-guides/thermostats/understanding-thermostat-concepts/set-points).
        /// </summary>
        [DataMember(
            Name = "cooling_set_point_celsius",
            IsRequired = false,
            EmitDefaultValue = false
        )]
        public float? CoolingSetPointCelsius { get; set; }

        /// <summary>
        /// Temperature to which the thermostat should cool (in °F). See also [Set Points](https://docs.seam.co/capability-guides/thermostats/understanding-thermostat-concepts/set-points).
        /// </summary>
        [DataMember(
            Name = "cooling_set_point_fahrenheit",
            IsRequired = false,
            EmitDefaultValue = false
        )]
        public float? CoolingSetPointFahrenheit { get; set; }

        /// <summary>
        /// Display name for the [climate preset](https://docs.seam.co/capability-guides/thermostats/creating-and-managing-climate-presets).
        /// </summary>
        [DataMember(Name = "display_name", IsRequired = false, EmitDefaultValue = false)]
        public string? DisplayName { get; set; }

        /// <summary>
        /// Metadata specific to the Ecobee climate, if applicable.
        /// </summary>
        [DataMember(Name = "ecobee_metadata", IsRequired = false, EmitDefaultValue = false)]
        public DevicePropertiesDefaultClimateSettingEcobeeMetadata? EcobeeMetadata { get; set; }

        /// <summary>
        /// Desired [fan mode setting](https://docs.seam.co/capability-guides/thermostats/configure-current-climate-settings#fan-mode-settings), such as `on`, `auto`, or `circulate`.
        /// </summary>
        [DataMember(Name = "fan_mode_setting", IsRequired = false, EmitDefaultValue = false)]
        public DevicePropertiesDefaultClimateSetting.FanModeSettingEnum? FanModeSetting { get; set; }

        /// <summary>
        /// Temperature to which the thermostat should heat (in °C). See also [Set Points](https://docs.seam.co/capability-guides/thermostats/understanding-thermostat-concepts/set-points).
        /// </summary>
        [DataMember(
            Name = "heating_set_point_celsius",
            IsRequired = false,
            EmitDefaultValue = false
        )]
        public float? HeatingSetPointCelsius { get; set; }

        /// <summary>
        /// Temperature to which the thermostat should heat (in °F). See also [Set Points](https://docs.seam.co/capability-guides/thermostats/understanding-thermostat-concepts/set-points).
        /// </summary>
        [DataMember(
            Name = "heating_set_point_fahrenheit",
            IsRequired = false,
            EmitDefaultValue = false
        )]
        public float? HeatingSetPointFahrenheit { get; set; }

        /// <summary>
        /// Desired [HVAC mode](https://docs.seam.co/capability-guides/thermostats/understanding-thermostat-concepts/hvac-mode) setting, such as `heat`, `cool`, `heat_cool`, or `off`.
        /// </summary>
        [DataMember(Name = "hvac_mode_setting", IsRequired = false, EmitDefaultValue = false)]
        public DevicePropertiesDefaultClimateSetting.HvacModeSettingEnum? HvacModeSetting { get; set; }

        /// <summary>
        /// Indicates whether a person at the thermostat can change the thermostat&apos;s settings. See [Specifying Manual Override Permissions](https://docs.seam.co/capability-guides/thermostats/creating-and-managing-thermostat-schedules#specifying-manual-override-permissions).
        /// </summary>
        [Obsolete("Use 'thermostat_schedule.is_override_allowed'")]
        [DataMember(Name = "manual_override_allowed", IsRequired = false, EmitDefaultValue = false)]
        public bool? ManualOverrideAllowed { get; set; }

        /// <summary>
        /// User-friendly name to identify the [climate preset](https://docs.seam.co/capability-guides/thermostats/creating-and-managing-climate-presets).
        /// </summary>
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

    [DataContract(Name = "seamModel_devicePropertiesDefaultClimateSettingEcobeeMetadata_model")]
    public class DevicePropertiesDefaultClimateSettingEcobeeMetadata
    {
        [JsonConstructorAttribute]
        protected DevicePropertiesDefaultClimateSettingEcobeeMetadata() { }

        public DevicePropertiesDefaultClimateSettingEcobeeMetadata(
            string? climateRef = default,
            bool? isOptimized = default,
            DevicePropertiesDefaultClimateSettingEcobeeMetadata.OwnerEnum? owner = default
        )
        {
            ClimateRef = climateRef;
            IsOptimized = isOptimized;
            Owner = owner;
        }

        /// <summary>
        /// Indicates whether the climate preset is owned by the user or the system.
        /// </summary>
        [JsonConverter(typeof(SafeStringEnumConverter))]
        public enum OwnerEnum
        {
            [EnumMember(Value = "unrecognized")]
            Unrecognized = 0,

            [EnumMember(Value = "user")]
            User = 1,

            [EnumMember(Value = "system")]
            System = 2,
        }

        /// <summary>
        /// Reference to the Ecobee climate, if applicable.
        /// </summary>
        [DataMember(Name = "climate_ref", IsRequired = false, EmitDefaultValue = false)]
        public string? ClimateRef { get; set; }

        /// <summary>
        /// Indicates if the climate preset is optimized by Ecobee.
        /// </summary>
        [DataMember(Name = "is_optimized", IsRequired = false, EmitDefaultValue = false)]
        public bool? IsOptimized { get; set; }

        /// <summary>
        /// Indicates whether the climate preset is owned by the user or the system.
        /// </summary>
        [DataMember(Name = "owner", IsRequired = false, EmitDefaultValue = false)]
        public DevicePropertiesDefaultClimateSettingEcobeeMetadata.OwnerEnum? Owner { get; set; }

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

    [DataContract(Name = "seamModel_devicePropertiesTemperatureThreshold_model")]
    public class DevicePropertiesTemperatureThreshold
    {
        [JsonConstructorAttribute]
        protected DevicePropertiesTemperatureThreshold() { }

        public DevicePropertiesTemperatureThreshold(
            float? lowerLimitCelsius = default,
            float? lowerLimitFahrenheit = default,
            float? upperLimitCelsius = default,
            float? upperLimitFahrenheit = default
        )
        {
            LowerLimitCelsius = lowerLimitCelsius;
            LowerLimitFahrenheit = lowerLimitFahrenheit;
            UpperLimitCelsius = upperLimitCelsius;
            UpperLimitFahrenheit = upperLimitFahrenheit;
        }

        /// <summary>
        /// Lower limit in °C within the current [temperature threshold](https://docs.seam.co/capability-guides/thermostats/setting-and-monitoring-temperature-thresholds) set for the thermostat.
        /// </summary>
        [DataMember(Name = "lower_limit_celsius", IsRequired = false, EmitDefaultValue = false)]
        public float? LowerLimitCelsius { get; set; }

        /// <summary>
        /// Lower limit in °F within the current [temperature threshold](https://docs.seam.co/capability-guides/thermostats/setting-and-monitoring-temperature-thresholds) set for the thermostat.
        /// </summary>
        [DataMember(Name = "lower_limit_fahrenheit", IsRequired = false, EmitDefaultValue = false)]
        public float? LowerLimitFahrenheit { get; set; }

        /// <summary>
        /// Upper limit in °C within the current [temperature threshold](https://docs.seam.co/capability-guides/thermostats/setting-and-monitoring-temperature-thresholds) set for the thermostat.
        /// </summary>
        [DataMember(Name = "upper_limit_celsius", IsRequired = false, EmitDefaultValue = false)]
        public float? UpperLimitCelsius { get; set; }

        /// <summary>
        /// Upper limit in °F within the current [temperature threshold](https://docs.seam.co/capability-guides/thermostats/setting-and-monitoring-temperature-thresholds) set for the thermostat.
        /// </summary>
        [DataMember(Name = "upper_limit_fahrenheit", IsRequired = false, EmitDefaultValue = false)]
        public float? UpperLimitFahrenheit { get; set; }

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

    [DataContract(Name = "seamModel_devicePropertiesThermostatDailyPrograms_model")]
    public class DevicePropertiesThermostatDailyPrograms
    {
        [JsonConstructorAttribute]
        protected DevicePropertiesThermostatDailyPrograms() { }

        public DevicePropertiesThermostatDailyPrograms(
            string createdAt = default,
            string deviceId = default,
            string? name = default,
            List<DevicePropertiesThermostatDailyProgramsPeriods> periods = default,
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
        public List<DevicePropertiesThermostatDailyProgramsPeriods> Periods { get; set; }

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

    [DataContract(Name = "seamModel_devicePropertiesThermostatDailyProgramsPeriods_model")]
    public class DevicePropertiesThermostatDailyProgramsPeriods
    {
        [JsonConstructorAttribute]
        protected DevicePropertiesThermostatDailyProgramsPeriods() { }

        public DevicePropertiesThermostatDailyProgramsPeriods(
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

    [DataContract(Name = "seamModel_devicePropertiesThermostatWeeklyProgram_model")]
    public class DevicePropertiesThermostatWeeklyProgram
    {
        [JsonConstructorAttribute]
        protected DevicePropertiesThermostatWeeklyProgram() { }

        public DevicePropertiesThermostatWeeklyProgram(
            string createdAt = default,
            string? fridayProgramId = default,
            string? mondayProgramId = default,
            string? saturdayProgramId = default,
            string? sundayProgramId = default,
            string? thursdayProgramId = default,
            string? tuesdayProgramId = default,
            string? wednesdayProgramId = default
        )
        {
            CreatedAt = createdAt;
            FridayProgramId = fridayProgramId;
            MondayProgramId = mondayProgramId;
            SaturdayProgramId = saturdayProgramId;
            SundayProgramId = sundayProgramId;
            ThursdayProgramId = thursdayProgramId;
            TuesdayProgramId = tuesdayProgramId;
            WednesdayProgramId = wednesdayProgramId;
        }

        /// <summary>
        /// Date and time at which the thermostat weekly program was created.
        /// </summary>
        [DataMember(Name = "created_at", IsRequired = false, EmitDefaultValue = false)]
        public string CreatedAt { get; set; }

        /// <summary>
        /// ID of the thermostat daily program to run on Fridays.
        /// </summary>
        [DataMember(Name = "friday_program_id", IsRequired = false, EmitDefaultValue = false)]
        public string? FridayProgramId { get; set; }

        /// <summary>
        /// ID of the thermostat daily program to run on Mondays.
        /// </summary>
        [DataMember(Name = "monday_program_id", IsRequired = false, EmitDefaultValue = false)]
        public string? MondayProgramId { get; set; }

        /// <summary>
        /// ID of the thermostat daily program to run on Saturdays.
        /// </summary>
        [DataMember(Name = "saturday_program_id", IsRequired = false, EmitDefaultValue = false)]
        public string? SaturdayProgramId { get; set; }

        /// <summary>
        /// ID of the thermostat daily program to run on Sundays.
        /// </summary>
        [DataMember(Name = "sunday_program_id", IsRequired = false, EmitDefaultValue = false)]
        public string? SundayProgramId { get; set; }

        /// <summary>
        /// ID of the thermostat daily program to run on Thursdays.
        /// </summary>
        [DataMember(Name = "thursday_program_id", IsRequired = false, EmitDefaultValue = false)]
        public string? ThursdayProgramId { get; set; }

        /// <summary>
        /// ID of the thermostat daily program to run on Tuesdays.
        /// </summary>
        [DataMember(Name = "tuesday_program_id", IsRequired = false, EmitDefaultValue = false)]
        public string? TuesdayProgramId { get; set; }

        /// <summary>
        /// ID of the thermostat daily program to run on Wednesdays.
        /// </summary>
        [DataMember(Name = "wednesday_program_id", IsRequired = false, EmitDefaultValue = false)]
        public string? WednesdayProgramId { get; set; }

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
