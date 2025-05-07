using System.Runtime.Serialization;
using System.Text;
using JsonSubTypes;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using Seam.Model;

namespace Seam.Model
{
    [DataContract(Name = "seamModel_device_model")]
    public class Device
    {
        [JsonConstructorAttribute]
        protected Device() { }

        public Device(
            bool? canHvacCool = default,
            bool? canHvacHeat = default,
            bool? canHvacHeatCool = default,
            bool? canProgramOfflineAccessCodes = default,
            bool? canProgramOnlineAccessCodes = default,
            bool? canRemotelyLock = default,
            bool? canRemotelyUnlock = default,
            bool? canSimulateConnection = default,
            bool? canSimulateDisconnection = default,
            bool? canSimulateRemoval = default,
            bool? canTurnOffHvac = default,
            List<Device.CapabilitiesSupportedEnum> capabilitiesSupported = default,
            string connectedAccountId = default,
            string createdAt = default,
            object? customMetadata = default,
            string deviceId = default,
            Device.DeviceTypeEnum deviceType = default,
            string displayName = default,
            List<DeviceErrors> errors = default,
            bool isManaged = default,
            DeviceLocation? location = default,
            string? nickname = default,
            DeviceProperties properties = default,
            List<DeviceWarnings> warnings = default,
            string workspaceId = default
        )
        {
            CanHvacCool = canHvacCool;
            CanHvacHeat = canHvacHeat;
            CanHvacHeatCool = canHvacHeatCool;
            CanProgramOfflineAccessCodes = canProgramOfflineAccessCodes;
            CanProgramOnlineAccessCodes = canProgramOnlineAccessCodes;
            CanRemotelyLock = canRemotelyLock;
            CanRemotelyUnlock = canRemotelyUnlock;
            CanSimulateConnection = canSimulateConnection;
            CanSimulateDisconnection = canSimulateDisconnection;
            CanSimulateRemoval = canSimulateRemoval;
            CanTurnOffHvac = canTurnOffHvac;
            CapabilitiesSupported = capabilitiesSupported;
            ConnectedAccountId = connectedAccountId;
            CreatedAt = createdAt;
            CustomMetadata = customMetadata;
            DeviceId = deviceId;
            DeviceType = deviceType;
            DisplayName = displayName;
            Errors = errors;
            IsManaged = isManaged;
            Location = location;
            Nickname = nickname;
            Properties = properties;
            Warnings = warnings;
            WorkspaceId = workspaceId;
        }

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

            [EnumMember(Value = "seam_relay")]
            SeamRelay = 15,

            [EnumMember(Value = "smartthings_lock")]
            SmartthingsLock = 16,

            [EnumMember(Value = "wyze_lock")]
            WyzeLock = 17,

            [EnumMember(Value = "yale_lock")]
            YaleLock = 18,

            [EnumMember(Value = "two_n_intercom")]
            TwoNIntercom = 19,

            [EnumMember(Value = "controlbyweb_device")]
            ControlbywebDevice = 20,

            [EnumMember(Value = "ttlock_lock")]
            TtlockLock = 21,

            [EnumMember(Value = "igloohome_lock")]
            IgloohomeLock = 22,

            [EnumMember(Value = "hubitat_lock")]
            HubitatLock = 23,

            [EnumMember(Value = "four_suites_door")]
            FourSuitesDoor = 24,

            [EnumMember(Value = "dormakaba_oracode_door")]
            DormakabaOracodeDoor = 25,

            [EnumMember(Value = "tedee_lock")]
            TedeeLock = 26,

            [EnumMember(Value = "akiles_lock")]
            AkilesLock = 27,

            [EnumMember(Value = "noiseaware_activity_zone")]
            NoiseawareActivityZone = 28,

            [EnumMember(Value = "minut_sensor")]
            MinutSensor = 29,

            [EnumMember(Value = "ecobee_thermostat")]
            EcobeeThermostat = 30,

            [EnumMember(Value = "nest_thermostat")]
            NestThermostat = 31,

            [EnumMember(Value = "honeywell_resideo_thermostat")]
            HoneywellResideoThermostat = 32,

            [EnumMember(Value = "tado_thermostat")]
            TadoThermostat = 33,

            [EnumMember(Value = "sensi_thermostat")]
            SensiThermostat = 34,

            [EnumMember(Value = "ios_phone")]
            IosPhone = 35,

            [EnumMember(Value = "android_phone")]
            AndroidPhone = 36,
        }

        [JsonConverter(typeof(JsonSubtypes), "error_code")]
        [JsonSubtypes.KnownSubType(typeof(DeviceErrorsBridgeDisconnected), "bridge_disconnected")]
        [JsonSubtypes.KnownSubType(typeof(DeviceErrorsInvalidCredentials), "invalid_credentials")]
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
            typeof(DeviceErrorsTtlockLockNotPairedToGateway),
            "ttlock_lock_not_paired_to_gateway"
        )]
        [JsonSubtypes.KnownSubType(
            typeof(DeviceErrorsAugustLockMissingBridge),
            "august_lock_missing_bridge"
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

            [DataMember(Name = "created_at", IsRequired = true, EmitDefaultValue = false)]
            public override string CreatedAt { get; set; }

            [DataMember(Name = "error_code", IsRequired = true, EmitDefaultValue = false)]
            public override string ErrorCode { get; } = "account_disconnected";

            [DataMember(
                Name = "is_connected_account_error",
                IsRequired = true,
                EmitDefaultValue = false
            )]
            public bool IsConnectedAccountError { get; set; }

            [DataMember(Name = "is_device_error", IsRequired = true, EmitDefaultValue = false)]
            public bool IsDeviceError { get; set; }

            [DataMember(Name = "message", IsRequired = true, EmitDefaultValue = false)]
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

            [DataMember(Name = "created_at", IsRequired = true, EmitDefaultValue = false)]
            public override string CreatedAt { get; set; }

            [DataMember(Name = "error_code", IsRequired = true, EmitDefaultValue = false)]
            public override string ErrorCode { get; } = "salto_ks_subscription_limit_exceeded";

            [DataMember(
                Name = "is_connected_account_error",
                IsRequired = true,
                EmitDefaultValue = false
            )]
            public bool IsConnectedAccountError { get; set; }

            [DataMember(Name = "is_device_error", IsRequired = true, EmitDefaultValue = false)]
            public bool IsDeviceError { get; set; }

            [DataMember(Name = "message", IsRequired = true, EmitDefaultValue = false)]
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

            [DataMember(Name = "created_at", IsRequired = true, EmitDefaultValue = false)]
            public override string CreatedAt { get; set; }

            [DataMember(Name = "error_code", IsRequired = true, EmitDefaultValue = false)]
            public override string ErrorCode { get; } = "device_offline";

            [DataMember(Name = "is_device_error", IsRequired = true, EmitDefaultValue = false)]
            public bool IsDeviceError { get; set; }

            [DataMember(Name = "message", IsRequired = true, EmitDefaultValue = false)]
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

            [DataMember(Name = "created_at", IsRequired = true, EmitDefaultValue = false)]
            public override string CreatedAt { get; set; }

            [DataMember(Name = "error_code", IsRequired = true, EmitDefaultValue = false)]
            public override string ErrorCode { get; } = "device_removed";

            [DataMember(Name = "is_device_error", IsRequired = true, EmitDefaultValue = false)]
            public bool IsDeviceError { get; set; }

            [DataMember(Name = "message", IsRequired = true, EmitDefaultValue = false)]
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

            [DataMember(Name = "created_at", IsRequired = true, EmitDefaultValue = false)]
            public override string CreatedAt { get; set; }

            [DataMember(Name = "error_code", IsRequired = true, EmitDefaultValue = false)]
            public override string ErrorCode { get; } = "hub_disconnected";

            [DataMember(Name = "is_device_error", IsRequired = true, EmitDefaultValue = false)]
            public bool IsDeviceError { get; set; }

            [DataMember(Name = "message", IsRequired = true, EmitDefaultValue = false)]
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

            [DataMember(Name = "created_at", IsRequired = true, EmitDefaultValue = false)]
            public override string CreatedAt { get; set; }

            [DataMember(Name = "error_code", IsRequired = true, EmitDefaultValue = false)]
            public override string ErrorCode { get; } = "device_disconnected";

            [DataMember(Name = "is_device_error", IsRequired = true, EmitDefaultValue = false)]
            public bool IsDeviceError { get; set; }

            [DataMember(Name = "message", IsRequired = true, EmitDefaultValue = false)]
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

            [DataMember(Name = "created_at", IsRequired = true, EmitDefaultValue = false)]
            public override string CreatedAt { get; set; }

            [DataMember(Name = "error_code", IsRequired = true, EmitDefaultValue = false)]
            public override string ErrorCode { get; } = "empty_backup_access_code_pool";

            [DataMember(Name = "is_device_error", IsRequired = true, EmitDefaultValue = false)]
            public bool IsDeviceError { get; set; }

            [DataMember(Name = "message", IsRequired = true, EmitDefaultValue = false)]
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

            [DataMember(Name = "created_at", IsRequired = true, EmitDefaultValue = false)]
            public override string CreatedAt { get; set; }

            [DataMember(Name = "error_code", IsRequired = true, EmitDefaultValue = false)]
            public override string ErrorCode { get; } = "august_lock_not_authorized";

            [DataMember(Name = "is_device_error", IsRequired = true, EmitDefaultValue = false)]
            public bool IsDeviceError { get; set; }

            [DataMember(Name = "message", IsRequired = true, EmitDefaultValue = false)]
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

        [DataContract(Name = "seamModel_deviceErrorsAugustLockMissingBridge_model")]
        public class DeviceErrorsAugustLockMissingBridge : DeviceErrors
        {
            [JsonConstructorAttribute]
            protected DeviceErrorsAugustLockMissingBridge() { }

            public DeviceErrorsAugustLockMissingBridge(
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

            [DataMember(Name = "created_at", IsRequired = true, EmitDefaultValue = false)]
            public override string CreatedAt { get; set; }

            [DataMember(Name = "error_code", IsRequired = true, EmitDefaultValue = false)]
            public override string ErrorCode { get; } = "august_lock_missing_bridge";

            [DataMember(Name = "is_device_error", IsRequired = true, EmitDefaultValue = false)]
            public bool IsDeviceError { get; set; }

            [DataMember(Name = "message", IsRequired = true, EmitDefaultValue = false)]
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

        [DataContract(Name = "seamModel_deviceErrorsTtlockLockNotPairedToGateway_model")]
        public class DeviceErrorsTtlockLockNotPairedToGateway : DeviceErrors
        {
            [JsonConstructorAttribute]
            protected DeviceErrorsTtlockLockNotPairedToGateway() { }

            public DeviceErrorsTtlockLockNotPairedToGateway(
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

            [DataMember(Name = "created_at", IsRequired = true, EmitDefaultValue = false)]
            public override string CreatedAt { get; set; }

            [DataMember(Name = "error_code", IsRequired = true, EmitDefaultValue = false)]
            public override string ErrorCode { get; } = "ttlock_lock_not_paired_to_gateway";

            [DataMember(Name = "is_device_error", IsRequired = true, EmitDefaultValue = false)]
            public bool IsDeviceError { get; set; }

            [DataMember(Name = "message", IsRequired = true, EmitDefaultValue = false)]
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

            [DataMember(Name = "created_at", IsRequired = true, EmitDefaultValue = false)]
            public override string CreatedAt { get; set; }

            [DataMember(Name = "error_code", IsRequired = true, EmitDefaultValue = false)]
            public override string ErrorCode { get; } = "missing_device_credentials";

            [DataMember(Name = "is_device_error", IsRequired = true, EmitDefaultValue = false)]
            public bool IsDeviceError { get; set; }

            [DataMember(Name = "message", IsRequired = true, EmitDefaultValue = false)]
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

            [DataMember(Name = "created_at", IsRequired = true, EmitDefaultValue = false)]
            public override string CreatedAt { get; set; }

            [DataMember(Name = "error_code", IsRequired = true, EmitDefaultValue = false)]
            public override string ErrorCode { get; } = "auxiliary_heat_running";

            [DataMember(Name = "is_device_error", IsRequired = true, EmitDefaultValue = false)]
            public bool IsDeviceError { get; set; }

            [DataMember(Name = "message", IsRequired = true, EmitDefaultValue = false)]
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

            [DataMember(Name = "created_at", IsRequired = true, EmitDefaultValue = false)]
            public override string CreatedAt { get; set; }

            [DataMember(Name = "error_code", IsRequired = true, EmitDefaultValue = false)]
            public override string ErrorCode { get; } = "subscription_required";

            [DataMember(Name = "is_device_error", IsRequired = true, EmitDefaultValue = false)]
            public bool IsDeviceError { get; set; }

            [DataMember(Name = "message", IsRequired = true, EmitDefaultValue = false)]
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

        [DataContract(Name = "seamModel_deviceErrorsInvalidCredentials_model")]
        public class DeviceErrorsInvalidCredentials : DeviceErrors
        {
            [JsonConstructorAttribute]
            protected DeviceErrorsInvalidCredentials() { }

            public DeviceErrorsInvalidCredentials(
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

            [DataMember(Name = "created_at", IsRequired = true, EmitDefaultValue = false)]
            public override string CreatedAt { get; set; }

            [DataMember(Name = "error_code", IsRequired = true, EmitDefaultValue = false)]
            public override string ErrorCode { get; } = "invalid_credentials";

            [DataMember(Name = "is_bridge_error", IsRequired = false, EmitDefaultValue = false)]
            public bool? IsBridgeError { get; set; }

            [DataMember(
                Name = "is_connected_account_error",
                IsRequired = false,
                EmitDefaultValue = false
            )]
            public bool? IsConnectedAccountError { get; set; }

            [DataMember(Name = "message", IsRequired = true, EmitDefaultValue = false)]
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

            [DataMember(Name = "created_at", IsRequired = true, EmitDefaultValue = false)]
            public override string CreatedAt { get; set; }

            [DataMember(Name = "error_code", IsRequired = true, EmitDefaultValue = false)]
            public override string ErrorCode { get; } = "bridge_disconnected";

            [DataMember(Name = "is_bridge_error", IsRequired = false, EmitDefaultValue = false)]
            public bool? IsBridgeError { get; set; }

            [DataMember(
                Name = "is_connected_account_error",
                IsRequired = false,
                EmitDefaultValue = false
            )]
            public bool? IsConnectedAccountError { get; set; }

            [DataMember(Name = "message", IsRequired = true, EmitDefaultValue = false)]
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
        [JsonSubtypes.KnownSubType(
            typeof(DeviceWarningsLocklyTimeZoneNotConfigured),
            "lockly_time_zone_not_configured"
        )]
        [JsonSubtypes.KnownSubType(
            typeof(DeviceWarningsUnknownIssueWithPhone),
            "unknown_issue_with_phone"
        )]
        [JsonSubtypes.KnownSubType(
            typeof(DeviceWarningsSaltoKsSubscriptionLimitAlmostReached),
            "salto_ks_subscription_limit_almost_reached"
        )]
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
        [JsonSubtypes.KnownSubType(
            typeof(DeviceWarningsTtlockWeakGatewaySignal),
            "ttlock_weak_gateway_signal"
        )]
        [JsonSubtypes.KnownSubType(
            typeof(DeviceWarningsTtlockLockGatewayUnlockingNotEnabled),
            "ttlock_lock_gateway_unlocking_not_enabled"
        )]
        [JsonSubtypes.KnownSubType(
            typeof(DeviceWarningsNestThermostatInManualEcoMode),
            "nest_thermostat_in_manual_eco_mode"
        )]
        [JsonSubtypes.KnownSubType(
            typeof(DeviceWarningsThirdPartyIntegrationDetected),
            "third_party_integration_detected"
        )]
        [JsonSubtypes.KnownSubType(
            typeof(DeviceWarningsFunctionalOfflineDevice),
            "functional_offline_device"
        )]
        [JsonSubtypes.KnownSubType(
            typeof(DeviceWarningsWyzeDeviceMissingGateway),
            "wyze_device_missing_gateway"
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

            [DataMember(Name = "created_at", IsRequired = true, EmitDefaultValue = false)]
            public override string CreatedAt { get; set; }

            [DataMember(Name = "message", IsRequired = true, EmitDefaultValue = false)]
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

            [DataMember(Name = "created_at", IsRequired = true, EmitDefaultValue = false)]
            public override string CreatedAt { get; set; }

            [DataMember(Name = "message", IsRequired = true, EmitDefaultValue = false)]
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

        [DataContract(Name = "seamModel_deviceWarningsWyzeDeviceMissingGateway_model")]
        public class DeviceWarningsWyzeDeviceMissingGateway : DeviceWarnings
        {
            [JsonConstructorAttribute]
            protected DeviceWarningsWyzeDeviceMissingGateway() { }

            public DeviceWarningsWyzeDeviceMissingGateway(
                string createdAt = default,
                string message = default,
                string warningCode = default
            )
            {
                CreatedAt = createdAt;
                Message = message;
                WarningCode = warningCode;
            }

            [DataMember(Name = "created_at", IsRequired = true, EmitDefaultValue = false)]
            public override string CreatedAt { get; set; }

            [DataMember(Name = "message", IsRequired = true, EmitDefaultValue = false)]
            public override string Message { get; set; }

            [DataMember(Name = "warning_code", IsRequired = true, EmitDefaultValue = false)]
            public override string WarningCode { get; } = "wyze_device_missing_gateway";

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

        [DataContract(Name = "seamModel_deviceWarningsFunctionalOfflineDevice_model")]
        public class DeviceWarningsFunctionalOfflineDevice : DeviceWarnings
        {
            [JsonConstructorAttribute]
            protected DeviceWarningsFunctionalOfflineDevice() { }

            public DeviceWarningsFunctionalOfflineDevice(
                string createdAt = default,
                string message = default,
                string warningCode = default
            )
            {
                CreatedAt = createdAt;
                Message = message;
                WarningCode = warningCode;
            }

            [DataMember(Name = "created_at", IsRequired = true, EmitDefaultValue = false)]
            public override string CreatedAt { get; set; }

            [DataMember(Name = "message", IsRequired = true, EmitDefaultValue = false)]
            public override string Message { get; set; }

            [DataMember(Name = "warning_code", IsRequired = true, EmitDefaultValue = false)]
            public override string WarningCode { get; } = "functional_offline_device";

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

            [DataMember(Name = "created_at", IsRequired = true, EmitDefaultValue = false)]
            public override string CreatedAt { get; set; }

            [DataMember(Name = "message", IsRequired = true, EmitDefaultValue = false)]
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

        [DataContract(Name = "seamModel_deviceWarningsNestThermostatInManualEcoMode_model")]
        public class DeviceWarningsNestThermostatInManualEcoMode : DeviceWarnings
        {
            [JsonConstructorAttribute]
            protected DeviceWarningsNestThermostatInManualEcoMode() { }

            public DeviceWarningsNestThermostatInManualEcoMode(
                string createdAt = default,
                string message = default,
                string warningCode = default
            )
            {
                CreatedAt = createdAt;
                Message = message;
                WarningCode = warningCode;
            }

            [DataMember(Name = "created_at", IsRequired = true, EmitDefaultValue = false)]
            public override string CreatedAt { get; set; }

            [DataMember(Name = "message", IsRequired = true, EmitDefaultValue = false)]
            public override string Message { get; set; }

            [DataMember(Name = "warning_code", IsRequired = true, EmitDefaultValue = false)]
            public override string WarningCode { get; } = "nest_thermostat_in_manual_eco_mode";

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

            [DataMember(Name = "created_at", IsRequired = true, EmitDefaultValue = false)]
            public override string CreatedAt { get; set; }

            [DataMember(Name = "message", IsRequired = true, EmitDefaultValue = false)]
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

            [DataMember(Name = "created_at", IsRequired = true, EmitDefaultValue = false)]
            public override string CreatedAt { get; set; }

            [DataMember(Name = "message", IsRequired = true, EmitDefaultValue = false)]
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

            [DataMember(Name = "created_at", IsRequired = true, EmitDefaultValue = false)]
            public override string CreatedAt { get; set; }

            [DataMember(Name = "message", IsRequired = true, EmitDefaultValue = false)]
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

            [DataMember(Name = "created_at", IsRequired = true, EmitDefaultValue = false)]
            public override string CreatedAt { get; set; }

            [DataMember(Name = "message", IsRequired = true, EmitDefaultValue = false)]
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

            [DataMember(Name = "created_at", IsRequired = true, EmitDefaultValue = false)]
            public override string CreatedAt { get; set; }

            [DataMember(Name = "message", IsRequired = true, EmitDefaultValue = false)]
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

            [DataMember(Name = "created_at", IsRequired = true, EmitDefaultValue = false)]
            public override string CreatedAt { get; set; }

            [DataMember(Name = "message", IsRequired = true, EmitDefaultValue = false)]
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

            [DataMember(Name = "created_at", IsRequired = true, EmitDefaultValue = false)]
            public override string CreatedAt { get; set; }

            [DataMember(Name = "message", IsRequired = true, EmitDefaultValue = false)]
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

            [DataMember(Name = "created_at", IsRequired = true, EmitDefaultValue = false)]
            public override string CreatedAt { get; set; }

            [DataMember(Name = "message", IsRequired = true, EmitDefaultValue = false)]
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

            [DataMember(Name = "created_at", IsRequired = true, EmitDefaultValue = false)]
            public override string CreatedAt { get; set; }

            [DataMember(Name = "message", IsRequired = true, EmitDefaultValue = false)]
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

            [DataMember(Name = "created_at", IsRequired = true, EmitDefaultValue = false)]
            public override string CreatedAt { get; set; }

            [DataMember(Name = "message", IsRequired = true, EmitDefaultValue = false)]
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

            [DataMember(Name = "created_at", IsRequired = true, EmitDefaultValue = false)]
            public override string CreatedAt { get; set; }

            [DataMember(Name = "message", IsRequired = true, EmitDefaultValue = false)]
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

        [DataMember(Name = "can_hvac_cool", IsRequired = false, EmitDefaultValue = false)]
        public bool? CanHvacCool { get; set; }

        [DataMember(Name = "can_hvac_heat", IsRequired = false, EmitDefaultValue = false)]
        public bool? CanHvacHeat { get; set; }

        [DataMember(Name = "can_hvac_heat_cool", IsRequired = false, EmitDefaultValue = false)]
        public bool? CanHvacHeatCool { get; set; }

        [DataMember(
            Name = "can_program_offline_access_codes",
            IsRequired = false,
            EmitDefaultValue = false
        )]
        public bool? CanProgramOfflineAccessCodes { get; set; }

        [DataMember(
            Name = "can_program_online_access_codes",
            IsRequired = false,
            EmitDefaultValue = false
        )]
        public bool? CanProgramOnlineAccessCodes { get; set; }

        [DataMember(Name = "can_remotely_lock", IsRequired = false, EmitDefaultValue = false)]
        public bool? CanRemotelyLock { get; set; }

        [DataMember(Name = "can_remotely_unlock", IsRequired = false, EmitDefaultValue = false)]
        public bool? CanRemotelyUnlock { get; set; }

        [DataMember(Name = "can_simulate_connection", IsRequired = false, EmitDefaultValue = false)]
        public bool? CanSimulateConnection { get; set; }

        [DataMember(
            Name = "can_simulate_disconnection",
            IsRequired = false,
            EmitDefaultValue = false
        )]
        public bool? CanSimulateDisconnection { get; set; }

        [DataMember(Name = "can_simulate_removal", IsRequired = false, EmitDefaultValue = false)]
        public bool? CanSimulateRemoval { get; set; }

        [DataMember(Name = "can_turn_off_hvac", IsRequired = false, EmitDefaultValue = false)]
        public bool? CanTurnOffHvac { get; set; }

        [DataMember(Name = "capabilities_supported", IsRequired = true, EmitDefaultValue = false)]
        public List<Device.CapabilitiesSupportedEnum> CapabilitiesSupported { get; set; }

        [DataMember(Name = "connected_account_id", IsRequired = true, EmitDefaultValue = false)]
        public string ConnectedAccountId { get; set; }

        [DataMember(Name = "created_at", IsRequired = true, EmitDefaultValue = false)]
        public string CreatedAt { get; set; }

        [DataMember(Name = "custom_metadata", IsRequired = true, EmitDefaultValue = false)]
        public object? CustomMetadata { get; set; }

        [DataMember(Name = "device_id", IsRequired = true, EmitDefaultValue = false)]
        public string DeviceId { get; set; }

        [DataMember(Name = "device_type", IsRequired = true, EmitDefaultValue = false)]
        public Device.DeviceTypeEnum DeviceType { get; set; }

        [DataMember(Name = "display_name", IsRequired = true, EmitDefaultValue = false)]
        public string DisplayName { get; set; }

        [DataMember(Name = "errors", IsRequired = true, EmitDefaultValue = false)]
        public List<DeviceErrors> Errors { get; set; }

        [DataMember(Name = "is_managed", IsRequired = true, EmitDefaultValue = false)]
        public bool IsManaged { get; set; }

        [DataMember(Name = "location", IsRequired = false, EmitDefaultValue = false)]
        public DeviceLocation? Location { get; set; }

        [DataMember(Name = "nickname", IsRequired = false, EmitDefaultValue = false)]
        public string? Nickname { get; set; }

        [DataMember(Name = "properties", IsRequired = true, EmitDefaultValue = false)]
        public DeviceProperties Properties { get; set; }

        [DataMember(Name = "warnings", IsRequired = true, EmitDefaultValue = false)]
        public List<DeviceWarnings> Warnings { get; set; }

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

    [DataContract(Name = "seamModel_deviceProperties_model")]
    public class DeviceProperties
    {
        [JsonConstructorAttribute]
        protected DeviceProperties() { }

        public DeviceProperties(
            DevicePropertiesAccessoryKeypad? accessoryKeypad = default,
            DevicePropertiesAppearance? appearance = default,
            DevicePropertiesBattery? battery = default,
            float? batteryLevel = default,
            List<string>? currentlyTriggeringNoiseThresholdIds = default,
            bool? hasDirectPower = default,
            string? imageAltText = default,
            string? imageUrl = default,
            string? manufacturer = default,
            DevicePropertiesModel? model = default,
            string? name = default,
            float? noiseLevelDecibels = default,
            bool? offlineAccessCodesEnabled = default,
            bool? online = default,
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
            DevicePropertiesHubitatMetadata? hubitatMetadata = default,
            DevicePropertiesIglooMetadata? iglooMetadata = default,
            DevicePropertiesIgloohomeMetadata? igloohomeMetadata = default,
            DevicePropertiesKwiksetMetadata? kwiksetMetadata = default,
            DevicePropertiesLocklyMetadata? locklyMetadata = default,
            DevicePropertiesMinutMetadata? minutMetadata = default,
            DevicePropertiesNestMetadata? nestMetadata = default,
            DevicePropertiesNoiseawareMetadata? noiseawareMetadata = default,
            DevicePropertiesNukiMetadata? nukiMetadata = default,
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
            DevicePropertiesVisionlineMetadata? visionlineMetadata = default,
            DevicePropertiesWyzeMetadata? wyzeMetadata = default,
            List<float>? experimentalSupportedCodeFromAccessCodesLengths = default,
            List<JObject>? codeConstraints = default,
            bool? doorOpen = default,
            bool? hasNativeEntryEvents = default,
            DevicePropertiesKeypadBattery? keypadBattery = default,
            bool? locked = default,
            float? maxActiveCodesSupported = default,
            List<float>? supportedCodeLengths = default,
            bool? supportsBackupAccessCodePool = default,
            DevicePropertiesActiveThermostatSchedule? activeThermostatSchedule = default,
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
            HubitatMetadata = hubitatMetadata;
            IglooMetadata = iglooMetadata;
            IgloohomeMetadata = igloohomeMetadata;
            KwiksetMetadata = kwiksetMetadata;
            LocklyMetadata = locklyMetadata;
            MinutMetadata = minutMetadata;
            NestMetadata = nestMetadata;
            NoiseawareMetadata = noiseawareMetadata;
            NukiMetadata = nukiMetadata;
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
            VisionlineMetadata = visionlineMetadata;
            WyzeMetadata = wyzeMetadata;
            ExperimentalSupportedCodeFromAccessCodesLengths =
                experimentalSupportedCodeFromAccessCodesLengths;
            CodeConstraints = codeConstraints;
            DoorOpen = doorOpen;
            HasNativeEntryEvents = hasNativeEntryEvents;
            KeypadBattery = keypadBattery;
            Locked = locked;
            MaxActiveCodesSupported = maxActiveCodesSupported;
            SupportedCodeLengths = supportedCodeLengths;
            SupportsBackupAccessCodePool = supportsBackupAccessCodePool;
            ActiveThermostatSchedule = activeThermostatSchedule;
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
            ThermostatDailyPrograms = thermostatDailyPrograms;
            ThermostatWeeklyProgram = thermostatWeeklyProgram;
        }

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

        [DataMember(Name = "accessory_keypad", IsRequired = false, EmitDefaultValue = false)]
        public DevicePropertiesAccessoryKeypad? AccessoryKeypad { get; set; }

        [DataMember(Name = "appearance", IsRequired = false, EmitDefaultValue = false)]
        public DevicePropertiesAppearance? Appearance { get; set; }

        [DataMember(Name = "battery", IsRequired = false, EmitDefaultValue = false)]
        public DevicePropertiesBattery? Battery { get; set; }

        [DataMember(Name = "battery_level", IsRequired = false, EmitDefaultValue = false)]
        public float? BatteryLevel { get; set; }

        [DataMember(
            Name = "currently_triggering_noise_threshold_ids",
            IsRequired = false,
            EmitDefaultValue = false
        )]
        public List<string>? CurrentlyTriggeringNoiseThresholdIds { get; set; }

        [DataMember(Name = "has_direct_power", IsRequired = false, EmitDefaultValue = false)]
        public bool? HasDirectPower { get; set; }

        [DataMember(Name = "image_alt_text", IsRequired = false, EmitDefaultValue = false)]
        public string? ImageAltText { get; set; }

        [DataMember(Name = "image_url", IsRequired = false, EmitDefaultValue = false)]
        public string? ImageUrl { get; set; }

        [DataMember(Name = "manufacturer", IsRequired = false, EmitDefaultValue = false)]
        public string? Manufacturer { get; set; }

        [DataMember(Name = "model", IsRequired = false, EmitDefaultValue = false)]
        public DevicePropertiesModel? Model { get; set; }

        [DataMember(Name = "name", IsRequired = false, EmitDefaultValue = false)]
        public string? Name { get; set; }

        [DataMember(Name = "noise_level_decibels", IsRequired = false, EmitDefaultValue = false)]
        public float? NoiseLevelDecibels { get; set; }

        [DataMember(
            Name = "offline_access_codes_enabled",
            IsRequired = false,
            EmitDefaultValue = false
        )]
        public bool? OfflineAccessCodesEnabled { get; set; }

        [DataMember(Name = "online", IsRequired = false, EmitDefaultValue = false)]
        public bool? Online { get; set; }

        [DataMember(
            Name = "online_access_codes_enabled",
            IsRequired = false,
            EmitDefaultValue = false
        )]
        public bool? OnlineAccessCodesEnabled { get; set; }

        [DataMember(Name = "serial_number", IsRequired = false, EmitDefaultValue = false)]
        public string? SerialNumber { get; set; }

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

        [DataMember(
            Name = "salto_space_credential_service_metadata",
            IsRequired = false,
            EmitDefaultValue = false
        )]
        public DevicePropertiesSaltoSpaceCredentialServiceMetadata? SaltoSpaceCredentialServiceMetadata { get; set; }

        [DataMember(Name = "akiles_metadata", IsRequired = false, EmitDefaultValue = false)]
        public DevicePropertiesAkilesMetadata? AkilesMetadata { get; set; }

        [DataMember(
            Name = "assa_abloy_vostio_metadata",
            IsRequired = false,
            EmitDefaultValue = false
        )]
        public DevicePropertiesAssaAbloyVostioMetadata? AssaAbloyVostioMetadata { get; set; }

        [DataMember(Name = "august_metadata", IsRequired = false, EmitDefaultValue = false)]
        public DevicePropertiesAugustMetadata? AugustMetadata { get; set; }

        [DataMember(Name = "avigilon_alta_metadata", IsRequired = false, EmitDefaultValue = false)]
        public DevicePropertiesAvigilonAltaMetadata? AvigilonAltaMetadata { get; set; }

        [DataMember(Name = "brivo_metadata", IsRequired = false, EmitDefaultValue = false)]
        public DevicePropertiesBrivoMetadata? BrivoMetadata { get; set; }

        [DataMember(Name = "controlbyweb_metadata", IsRequired = false, EmitDefaultValue = false)]
        public DevicePropertiesControlbywebMetadata? ControlbywebMetadata { get; set; }

        [DataMember(
            Name = "dormakaba_oracode_metadata",
            IsRequired = false,
            EmitDefaultValue = false
        )]
        public DevicePropertiesDormakabaOracodeMetadata? DormakabaOracodeMetadata { get; set; }

        [DataMember(Name = "ecobee_metadata", IsRequired = false, EmitDefaultValue = false)]
        public DevicePropertiesEcobeeMetadata? EcobeeMetadata { get; set; }

        [DataMember(Name = "four_suites_metadata", IsRequired = false, EmitDefaultValue = false)]
        public DevicePropertiesFourSuitesMetadata? FourSuitesMetadata { get; set; }

        [DataMember(Name = "genie_metadata", IsRequired = false, EmitDefaultValue = false)]
        public DevicePropertiesGenieMetadata? GenieMetadata { get; set; }

        [DataMember(
            Name = "honeywell_resideo_metadata",
            IsRequired = false,
            EmitDefaultValue = false
        )]
        public DevicePropertiesHoneywellResideoMetadata? HoneywellResideoMetadata { get; set; }

        [DataMember(Name = "hubitat_metadata", IsRequired = false, EmitDefaultValue = false)]
        public DevicePropertiesHubitatMetadata? HubitatMetadata { get; set; }

        [DataMember(Name = "igloo_metadata", IsRequired = false, EmitDefaultValue = false)]
        public DevicePropertiesIglooMetadata? IglooMetadata { get; set; }

        [DataMember(Name = "igloohome_metadata", IsRequired = false, EmitDefaultValue = false)]
        public DevicePropertiesIgloohomeMetadata? IgloohomeMetadata { get; set; }

        [DataMember(Name = "kwikset_metadata", IsRequired = false, EmitDefaultValue = false)]
        public DevicePropertiesKwiksetMetadata? KwiksetMetadata { get; set; }

        [DataMember(Name = "lockly_metadata", IsRequired = false, EmitDefaultValue = false)]
        public DevicePropertiesLocklyMetadata? LocklyMetadata { get; set; }

        [DataMember(Name = "minut_metadata", IsRequired = false, EmitDefaultValue = false)]
        public DevicePropertiesMinutMetadata? MinutMetadata { get; set; }

        [DataMember(Name = "nest_metadata", IsRequired = false, EmitDefaultValue = false)]
        public DevicePropertiesNestMetadata? NestMetadata { get; set; }

        [DataMember(Name = "noiseaware_metadata", IsRequired = false, EmitDefaultValue = false)]
        public DevicePropertiesNoiseawareMetadata? NoiseawareMetadata { get; set; }

        [DataMember(Name = "nuki_metadata", IsRequired = false, EmitDefaultValue = false)]
        public DevicePropertiesNukiMetadata? NukiMetadata { get; set; }

        [DataMember(Name = "salto_ks_metadata", IsRequired = false, EmitDefaultValue = false)]
        public DevicePropertiesSaltoKsMetadata? SaltoKsMetadata { get; set; }

        [DataMember(Name = "salto_metadata", IsRequired = false, EmitDefaultValue = false)]
        public DevicePropertiesSaltoMetadata? SaltoMetadata { get; set; }

        [DataMember(Name = "schlage_metadata", IsRequired = false, EmitDefaultValue = false)]
        public DevicePropertiesSchlageMetadata? SchlageMetadata { get; set; }

        [DataMember(Name = "seam_bridge_metadata", IsRequired = false, EmitDefaultValue = false)]
        public DevicePropertiesSeamBridgeMetadata? SeamBridgeMetadata { get; set; }

        [DataMember(Name = "sensi_metadata", IsRequired = false, EmitDefaultValue = false)]
        public DevicePropertiesSensiMetadata? SensiMetadata { get; set; }

        [DataMember(Name = "smartthings_metadata", IsRequired = false, EmitDefaultValue = false)]
        public DevicePropertiesSmartthingsMetadata? SmartthingsMetadata { get; set; }

        [DataMember(Name = "tado_metadata", IsRequired = false, EmitDefaultValue = false)]
        public DevicePropertiesTadoMetadata? TadoMetadata { get; set; }

        [DataMember(Name = "tedee_metadata", IsRequired = false, EmitDefaultValue = false)]
        public DevicePropertiesTedeeMetadata? TedeeMetadata { get; set; }

        [DataMember(Name = "ttlock_metadata", IsRequired = false, EmitDefaultValue = false)]
        public DevicePropertiesTtlockMetadata? TtlockMetadata { get; set; }

        [DataMember(Name = "two_n_metadata", IsRequired = false, EmitDefaultValue = false)]
        public DevicePropertiesTwoNMetadata? TwoNMetadata { get; set; }

        [DataMember(Name = "visionline_metadata", IsRequired = false, EmitDefaultValue = false)]
        public DevicePropertiesVisionlineMetadata? VisionlineMetadata { get; set; }

        [DataMember(Name = "wyze_metadata", IsRequired = false, EmitDefaultValue = false)]
        public DevicePropertiesWyzeMetadata? WyzeMetadata { get; set; }

        [DataMember(
            Name = "experimental_supported_code_from_access_codes_lengths",
            IsRequired = false,
            EmitDefaultValue = false
        )]
        public List<float>? ExperimentalSupportedCodeFromAccessCodesLengths { get; set; }

        [DataMember(Name = "code_constraints", IsRequired = false, EmitDefaultValue = false)]
        public List<JObject>? CodeConstraints { get; set; }

        [DataMember(Name = "door_open", IsRequired = false, EmitDefaultValue = false)]
        public bool? DoorOpen { get; set; }

        [DataMember(Name = "has_native_entry_events", IsRequired = false, EmitDefaultValue = false)]
        public bool? HasNativeEntryEvents { get; set; }

        [DataMember(Name = "keypad_battery", IsRequired = false, EmitDefaultValue = false)]
        public DevicePropertiesKeypadBattery? KeypadBattery { get; set; }

        [DataMember(Name = "locked", IsRequired = false, EmitDefaultValue = false)]
        public bool? Locked { get; set; }

        [DataMember(
            Name = "max_active_codes_supported",
            IsRequired = false,
            EmitDefaultValue = false
        )]
        public float? MaxActiveCodesSupported { get; set; }

        [DataMember(Name = "supported_code_lengths", IsRequired = false, EmitDefaultValue = false)]
        public List<float>? SupportedCodeLengths { get; set; }

        [DataMember(
            Name = "supports_backup_access_code_pool",
            IsRequired = false,
            EmitDefaultValue = false
        )]
        public bool? SupportsBackupAccessCodePool { get; set; }

        [DataMember(
            Name = "active_thermostat_schedule",
            IsRequired = false,
            EmitDefaultValue = false
        )]
        public DevicePropertiesActiveThermostatSchedule? ActiveThermostatSchedule { get; set; }

        [DataMember(
            Name = "available_climate_presets",
            IsRequired = false,
            EmitDefaultValue = false
        )]
        public List<DevicePropertiesAvailableClimatePresets>? AvailableClimatePresets { get; set; }

        [DataMember(
            Name = "available_fan_mode_settings",
            IsRequired = false,
            EmitDefaultValue = false
        )]
        public List<DeviceProperties.AvailableFanModeSettingsEnum>? AvailableFanModeSettings { get; set; }

        [DataMember(
            Name = "available_hvac_mode_settings",
            IsRequired = false,
            EmitDefaultValue = false
        )]
        public List<DeviceProperties.AvailableHvacModeSettingsEnum>? AvailableHvacModeSettings { get; set; }

        [DataMember(Name = "current_climate_setting", IsRequired = false, EmitDefaultValue = false)]
        public DevicePropertiesCurrentClimateSetting? CurrentClimateSetting { get; set; }

        [DataMember(Name = "default_climate_setting", IsRequired = false, EmitDefaultValue = false)]
        public DevicePropertiesDefaultClimateSetting? DefaultClimateSetting { get; set; }

        [DataMember(
            Name = "fallback_climate_preset_key",
            IsRequired = false,
            EmitDefaultValue = false
        )]
        public string? FallbackClimatePresetKey { get; set; }

        [DataMember(Name = "fan_mode_setting", IsRequired = false, EmitDefaultValue = false)]
        public DeviceProperties.FanModeSettingEnum? FanModeSetting { get; set; }

        [DataMember(Name = "is_cooling", IsRequired = false, EmitDefaultValue = false)]
        public bool? IsCooling { get; set; }

        [DataMember(Name = "is_fan_running", IsRequired = false, EmitDefaultValue = false)]
        public bool? IsFanRunning { get; set; }

        [DataMember(Name = "is_heating", IsRequired = false, EmitDefaultValue = false)]
        public bool? IsHeating { get; set; }

        [DataMember(
            Name = "is_temporary_manual_override_active",
            IsRequired = false,
            EmitDefaultValue = false
        )]
        public bool? IsTemporaryManualOverrideActive { get; set; }

        [DataMember(
            Name = "max_cooling_set_point_celsius",
            IsRequired = false,
            EmitDefaultValue = false
        )]
        public float? MaxCoolingSetPointCelsius { get; set; }

        [DataMember(
            Name = "max_cooling_set_point_fahrenheit",
            IsRequired = false,
            EmitDefaultValue = false
        )]
        public float? MaxCoolingSetPointFahrenheit { get; set; }

        [DataMember(
            Name = "max_heating_set_point_celsius",
            IsRequired = false,
            EmitDefaultValue = false
        )]
        public float? MaxHeatingSetPointCelsius { get; set; }

        [DataMember(
            Name = "max_heating_set_point_fahrenheit",
            IsRequired = false,
            EmitDefaultValue = false
        )]
        public float? MaxHeatingSetPointFahrenheit { get; set; }

        [DataMember(
            Name = "min_cooling_set_point_celsius",
            IsRequired = false,
            EmitDefaultValue = false
        )]
        public float? MinCoolingSetPointCelsius { get; set; }

        [DataMember(
            Name = "min_cooling_set_point_fahrenheit",
            IsRequired = false,
            EmitDefaultValue = false
        )]
        public float? MinCoolingSetPointFahrenheit { get; set; }

        [DataMember(
            Name = "min_heating_cooling_delta_celsius",
            IsRequired = false,
            EmitDefaultValue = false
        )]
        public float? MinHeatingCoolingDeltaCelsius { get; set; }

        [DataMember(
            Name = "min_heating_cooling_delta_fahrenheit",
            IsRequired = false,
            EmitDefaultValue = false
        )]
        public float? MinHeatingCoolingDeltaFahrenheit { get; set; }

        [DataMember(
            Name = "min_heating_set_point_celsius",
            IsRequired = false,
            EmitDefaultValue = false
        )]
        public float? MinHeatingSetPointCelsius { get; set; }

        [DataMember(
            Name = "min_heating_set_point_fahrenheit",
            IsRequired = false,
            EmitDefaultValue = false
        )]
        public float? MinHeatingSetPointFahrenheit { get; set; }

        [DataMember(Name = "relative_humidity", IsRequired = false, EmitDefaultValue = false)]
        public float? RelativeHumidity { get; set; }

        [DataMember(Name = "temperature_celsius", IsRequired = false, EmitDefaultValue = false)]
        public float? TemperatureCelsius { get; set; }

        [DataMember(Name = "temperature_fahrenheit", IsRequired = false, EmitDefaultValue = false)]
        public float? TemperatureFahrenheit { get; set; }

        [DataMember(Name = "temperature_threshold", IsRequired = false, EmitDefaultValue = false)]
        public DevicePropertiesTemperatureThreshold? TemperatureThreshold { get; set; }

        [DataMember(
            Name = "thermostat_daily_programs",
            IsRequired = false,
            EmitDefaultValue = false
        )]
        public List<DevicePropertiesThermostatDailyPrograms>? ThermostatDailyPrograms { get; set; }

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
            bool? isConnected = default
        )
        {
            Battery = battery;
            IsConnected = isConnected;
        }

        [DataMember(Name = "battery", IsRequired = false, EmitDefaultValue = false)]
        public DevicePropertiesAccessoryKeypadBattery? Battery { get; set; }

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

    [DataContract(Name = "seamModel_devicePropertiesAccessoryKeypadBattery_model")]
    public class DevicePropertiesAccessoryKeypadBattery
    {
        [JsonConstructorAttribute]
        protected DevicePropertiesAccessoryKeypadBattery() { }

        public DevicePropertiesAccessoryKeypadBattery(float? level = default)
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

    [DataContract(Name = "seamModel_devicePropertiesModel_model")]
    public class DevicePropertiesModel
    {
        [JsonConstructorAttribute]
        protected DevicePropertiesModel() { }

        public DevicePropertiesModel(
            bool? accessoryKeypadSupported = default,
            bool? canConnectAccessoryKeypad = default,
            string? displayName = default,
            bool? hasBuiltInKeypad = default,
            string? manufacturerDisplayName = default,
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

        [DataMember(
            Name = "accessory_keypad_supported",
            IsRequired = false,
            EmitDefaultValue = false
        )]
        public bool? AccessoryKeypadSupported { get; set; }

        [DataMember(
            Name = "can_connect_accessory_keypad",
            IsRequired = false,
            EmitDefaultValue = false
        )]
        public bool? CanConnectAccessoryKeypad { get; set; }

        [DataMember(Name = "display_name", IsRequired = false, EmitDefaultValue = false)]
        public string? DisplayName { get; set; }

        [DataMember(Name = "has_built_in_keypad", IsRequired = false, EmitDefaultValue = false)]
        public bool? HasBuiltInKeypad { get; set; }

        [DataMember(
            Name = "manufacturer_display_name",
            IsRequired = false,
            EmitDefaultValue = false
        )]
        public string? ManufacturerDisplayName { get; set; }

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

        [DataMember(Name = "endpoints", IsRequired = false, EmitDefaultValue = false)]
        public List<DevicePropertiesAssaAbloyCredentialServiceMetadataEndpoints>? Endpoints { get; set; }

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

    [DataContract(Name = "seamModel_devicePropertiesSaltoSpaceCredentialServiceMetadata_model")]
    public class DevicePropertiesSaltoSpaceCredentialServiceMetadata
    {
        [JsonConstructorAttribute]
        protected DevicePropertiesSaltoSpaceCredentialServiceMetadata() { }

        public DevicePropertiesSaltoSpaceCredentialServiceMetadata(bool? hasActivePhone = default)
        {
            HasActivePhone = hasActivePhone;
        }

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

        [DataMember(Name = "member_group_id", IsRequired = false, EmitDefaultValue = false)]
        public string? MemberGroupId { get; set; }

        [DataMember(Name = "gadget_id", IsRequired = false, EmitDefaultValue = false)]
        public string? GadgetId { get; set; }

        [DataMember(Name = "gadget_name", IsRequired = false, EmitDefaultValue = false)]
        public string? GadgetName { get; set; }

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

        [DataMember(Name = "has_keypad", IsRequired = false, EmitDefaultValue = false)]
        public bool? HasKeypad { get; set; }

        [DataMember(Name = "house_id", IsRequired = false, EmitDefaultValue = false)]
        public string? HouseId { get; set; }

        [DataMember(Name = "house_name", IsRequired = false, EmitDefaultValue = false)]
        public string? HouseName { get; set; }

        [DataMember(Name = "keypad_battery_level", IsRequired = false, EmitDefaultValue = false)]
        public string? KeypadBatteryLevel { get; set; }

        [DataMember(Name = "lock_id", IsRequired = false, EmitDefaultValue = false)]
        public string? LockId { get; set; }

        [DataMember(Name = "lock_name", IsRequired = false, EmitDefaultValue = false)]
        public string? LockName { get; set; }

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

        [DataMember(Name = "entry_name", IsRequired = false, EmitDefaultValue = false)]
        public string? EntryName { get; set; }

        [DataMember(
            Name = "entry_relays_total_count",
            IsRequired = false,
            EmitDefaultValue = false
        )]
        public float? EntryRelaysTotalCount { get; set; }

        [DataMember(Name = "org_name", IsRequired = false, EmitDefaultValue = false)]
        public string? OrgName { get; set; }

        [DataMember(Name = "site_id", IsRequired = false, EmitDefaultValue = false)]
        public float? SiteId { get; set; }

        [DataMember(Name = "site_name", IsRequired = false, EmitDefaultValue = false)]
        public string? SiteName { get; set; }

        [DataMember(Name = "zone_id", IsRequired = false, EmitDefaultValue = false)]
        public float? ZoneId { get; set; }

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

    [DataContract(Name = "seamModel_devicePropertiesDormakabaOracodeMetadata_model")]
    public class DevicePropertiesDormakabaOracodeMetadata
    {
        [JsonConstructorAttribute]
        protected DevicePropertiesDormakabaOracodeMetadata() { }

        public DevicePropertiesDormakabaOracodeMetadata(
            object? deviceId = default,
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

        [DataMember(Name = "device_id", IsRequired = false, EmitDefaultValue = false)]
        public object? DeviceId { get; set; }

        [DataMember(Name = "door_id", IsRequired = false, EmitDefaultValue = false)]
        public float? DoorId { get; set; }

        [DataMember(Name = "door_is_wireless", IsRequired = false, EmitDefaultValue = false)]
        public bool? DoorIsWireless { get; set; }

        [DataMember(Name = "door_name", IsRequired = false, EmitDefaultValue = false)]
        public string? DoorName { get; set; }

        [DataMember(Name = "iana_timezone", IsRequired = false, EmitDefaultValue = false)]
        public string? IanaTimezone { get; set; }

        [DataMember(Name = "predefined_time_slots", IsRequired = false, EmitDefaultValue = false)]
        public List<DevicePropertiesDormakabaOracodeMetadataPredefinedTimeSlots>? PredefinedTimeSlots { get; set; }

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
            float? extDormakabaOracodeUserLevelPrefix = default,
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
            ExtDormakabaOracodeUserLevelPrefix = extDormakabaOracodeUserLevelPrefix;
            Is_24Hour = is_24Hour;
            IsBiweeklyMode = isBiweeklyMode;
            IsMaster = isMaster;
            IsOneShot = isOneShot;
            Name = name;
            Prefix = prefix;
        }

        [DataMember(Name = "check_in_time", IsRequired = false, EmitDefaultValue = false)]
        public string? CheckInTime { get; set; }

        [DataMember(Name = "check_out_time", IsRequired = false, EmitDefaultValue = false)]
        public string? CheckOutTime { get; set; }

        [DataMember(
            Name = "dormakaba_oracode_user_level_id",
            IsRequired = false,
            EmitDefaultValue = false
        )]
        public string? DormakabaOracodeUserLevelId { get; set; }

        [DataMember(
            Name = "ext_dormakaba_oracode_user_level_prefix",
            IsRequired = false,
            EmitDefaultValue = false
        )]
        public float? ExtDormakabaOracodeUserLevelPrefix { get; set; }

        [DataMember(Name = "is_24_hour", IsRequired = false, EmitDefaultValue = false)]
        public bool? Is_24Hour { get; set; }

        [DataMember(Name = "is_biweekly_mode", IsRequired = false, EmitDefaultValue = false)]
        public bool? IsBiweeklyMode { get; set; }

        [DataMember(Name = "is_master", IsRequired = false, EmitDefaultValue = false)]
        public bool? IsMaster { get; set; }

        [DataMember(Name = "is_one_shot", IsRequired = false, EmitDefaultValue = false)]
        public bool? IsOneShot { get; set; }

        [DataMember(Name = "name", IsRequired = false, EmitDefaultValue = false)]
        public string? Name { get; set; }

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

        [DataMember(Name = "device_name", IsRequired = false, EmitDefaultValue = false)]
        public string? DeviceName { get; set; }

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

        [DataMember(Name = "device_name", IsRequired = false, EmitDefaultValue = false)]
        public string? DeviceName { get; set; }

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

    [DataContract(Name = "seamModel_devicePropertiesHubitatMetadata_model")]
    public class DevicePropertiesHubitatMetadata
    {
        [JsonConstructorAttribute]
        protected DevicePropertiesHubitatMetadata() { }

        public DevicePropertiesHubitatMetadata(
            string? deviceId = default,
            string? deviceLabel = default,
            string? deviceName = default
        )
        {
            DeviceId = deviceId;
            DeviceLabel = deviceLabel;
            DeviceName = deviceName;
        }

        [DataMember(Name = "device_id", IsRequired = false, EmitDefaultValue = false)]
        public string? DeviceId { get; set; }

        [DataMember(Name = "device_label", IsRequired = false, EmitDefaultValue = false)]
        public string? DeviceLabel { get; set; }

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
            string? bridgeId = default,
            string? deviceId = default,
            string? model = default
        )
        {
            BridgeId = bridgeId;
            DeviceId = deviceId;
            Model = model;
        }

        [DataMember(Name = "bridge_id", IsRequired = false, EmitDefaultValue = false)]
        public string? BridgeId { get; set; }

        [DataMember(Name = "device_id", IsRequired = false, EmitDefaultValue = false)]
        public string? DeviceId { get; set; }

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
            string? keypadId = default
        )
        {
            BridgeId = bridgeId;
            BridgeName = bridgeName;
            DeviceId = deviceId;
            DeviceName = deviceName;
            KeypadId = keypadId;
        }

        [DataMember(Name = "bridge_id", IsRequired = false, EmitDefaultValue = false)]
        public string? BridgeId { get; set; }

        [DataMember(Name = "bridge_name", IsRequired = false, EmitDefaultValue = false)]
        public string? BridgeName { get; set; }

        [DataMember(Name = "device_id", IsRequired = false, EmitDefaultValue = false)]
        public string? DeviceId { get; set; }

        [DataMember(Name = "device_name", IsRequired = false, EmitDefaultValue = false)]
        public string? DeviceName { get; set; }

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

        [DataMember(Name = "accelerometer_z", IsRequired = false, EmitDefaultValue = false)]
        public DevicePropertiesMinutMetadataLatestSensorValuesAccelerometerZ? AccelerometerZ { get; set; }

        [DataMember(Name = "humidity", IsRequired = false, EmitDefaultValue = false)]
        public DevicePropertiesMinutMetadataLatestSensorValuesHumidity? Humidity { get; set; }

        [DataMember(Name = "pressure", IsRequired = false, EmitDefaultValue = false)]
        public DevicePropertiesMinutMetadataLatestSensorValuesPressure? Pressure { get; set; }

        [DataMember(Name = "sound", IsRequired = false, EmitDefaultValue = false)]
        public DevicePropertiesMinutMetadataLatestSensorValuesSound? Sound { get; set; }

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

        [DataMember(Name = "device_custom_name", IsRequired = false, EmitDefaultValue = false)]
        public string? DeviceCustomName { get; set; }

        [DataMember(Name = "device_name", IsRequired = false, EmitDefaultValue = false)]
        public string? DeviceName { get; set; }

        [DataMember(Name = "display_name", IsRequired = false, EmitDefaultValue = false)]
        public string? DisplayName { get; set; }

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

        [DataMember(Name = "device_id", IsRequired = false, EmitDefaultValue = false)]
        public string? DeviceId { get; set; }

        [DataMember(Name = "device_model", IsRequired = false, EmitDefaultValue = false)]
        public DevicePropertiesNoiseawareMetadata.DeviceModelEnum? DeviceModel { get; set; }

        [DataMember(Name = "device_name", IsRequired = false, EmitDefaultValue = false)]
        public string? DeviceName { get; set; }

        [DataMember(Name = "noise_level_decibel", IsRequired = false, EmitDefaultValue = false)]
        public float? NoiseLevelDecibel { get; set; }

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

        [DataMember(Name = "device_id", IsRequired = false, EmitDefaultValue = false)]
        public string? DeviceId { get; set; }

        [DataMember(Name = "device_name", IsRequired = false, EmitDefaultValue = false)]
        public string? DeviceName { get; set; }

        [DataMember(Name = "keypad_2_paired", IsRequired = false, EmitDefaultValue = false)]
        public bool? Keypad_2Paired { get; set; }

        [DataMember(Name = "keypad_battery_critical", IsRequired = false, EmitDefaultValue = false)]
        public bool? KeypadBatteryCritical { get; set; }

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

    [DataContract(Name = "seamModel_devicePropertiesSaltoKsMetadata_model")]
    public class DevicePropertiesSaltoKsMetadata
    {
        [JsonConstructorAttribute]
        protected DevicePropertiesSaltoKsMetadata() { }

        public DevicePropertiesSaltoKsMetadata(
            string? batteryLevel = default,
            string? customerReference = default,
            string? lockId = default,
            string? lockType = default,
            string? lockedState = default,
            string? model = default
        )
        {
            BatteryLevel = batteryLevel;
            CustomerReference = customerReference;
            LockId = lockId;
            LockType = lockType;
            LockedState = lockedState;
            Model = model;
        }

        [DataMember(Name = "battery_level", IsRequired = false, EmitDefaultValue = false)]
        public string? BatteryLevel { get; set; }

        [DataMember(Name = "customer_reference", IsRequired = false, EmitDefaultValue = false)]
        public string? CustomerReference { get; set; }

        [DataMember(Name = "lock_id", IsRequired = false, EmitDefaultValue = false)]
        public string? LockId { get; set; }

        [DataMember(Name = "lock_type", IsRequired = false, EmitDefaultValue = false)]
        public string? LockType { get; set; }

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
            string? model = default
        )
        {
            BatteryLevel = batteryLevel;
            CustomerReference = customerReference;
            LockId = lockId;
            LockType = lockType;
            LockedState = lockedState;
            Model = model;
        }

        [DataMember(Name = "battery_level", IsRequired = false, EmitDefaultValue = false)]
        public string? BatteryLevel { get; set; }

        [DataMember(Name = "customer_reference", IsRequired = false, EmitDefaultValue = false)]
        public string? CustomerReference { get; set; }

        [DataMember(Name = "lock_id", IsRequired = false, EmitDefaultValue = false)]
        public string? LockId { get; set; }

        [DataMember(Name = "lock_type", IsRequired = false, EmitDefaultValue = false)]
        public string? LockType { get; set; }

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

        [DataMember(Name = "device_num", IsRequired = false, EmitDefaultValue = false)]
        public float? DeviceNum { get; set; }

        [DataMember(Name = "name", IsRequired = false, EmitDefaultValue = false)]
        public string? Name { get; set; }

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
            string? productType = default
        )
        {
            DeviceId = deviceId;
            DeviceName = deviceName;
            ProductType = productType;
        }

        [DataMember(Name = "device_id", IsRequired = false, EmitDefaultValue = false)]
        public string? DeviceId { get; set; }

        [DataMember(Name = "device_name", IsRequired = false, EmitDefaultValue = false)]
        public string? DeviceName { get; set; }

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

        [DataMember(Name = "device_id", IsRequired = false, EmitDefaultValue = false)]
        public string? DeviceId { get; set; }

        [DataMember(Name = "device_name", IsRequired = false, EmitDefaultValue = false)]
        public string? DeviceName { get; set; }

        [DataMember(Name = "location_id", IsRequired = false, EmitDefaultValue = false)]
        public string? LocationId { get; set; }

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

        [DataMember(Name = "device_type", IsRequired = false, EmitDefaultValue = false)]
        public string? DeviceType { get; set; }

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

        [DataMember(Name = "bridge_id", IsRequired = false, EmitDefaultValue = false)]
        public float? BridgeId { get; set; }

        [DataMember(Name = "bridge_name", IsRequired = false, EmitDefaultValue = false)]
        public string? BridgeName { get; set; }

        [DataMember(Name = "device_id", IsRequired = false, EmitDefaultValue = false)]
        public float? DeviceId { get; set; }

        [DataMember(Name = "device_model", IsRequired = false, EmitDefaultValue = false)]
        public string? DeviceModel { get; set; }

        [DataMember(Name = "device_name", IsRequired = false, EmitDefaultValue = false)]
        public string? DeviceName { get; set; }

        [DataMember(Name = "keypad_id", IsRequired = false, EmitDefaultValue = false)]
        public float? KeypadId { get; set; }

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
            List<DevicePropertiesTtlockMetadataWirelessKeypads>? wirelessKeypads = default
        )
        {
            FeatureValue = featureValue;
            Features = features;
            HasGateway = hasGateway;
            LockAlias = lockAlias;
            LockId = lockId;
            WirelessKeypads = wirelessKeypads;
        }

        [DataMember(Name = "feature_value", IsRequired = false, EmitDefaultValue = false)]
        public string? FeatureValue { get; set; }

        [DataMember(Name = "features", IsRequired = false, EmitDefaultValue = false)]
        public DevicePropertiesTtlockMetadataFeatures? Features { get; set; }

        [DataMember(Name = "has_gateway", IsRequired = false, EmitDefaultValue = false)]
        public bool? HasGateway { get; set; }

        [DataMember(Name = "lock_alias", IsRequired = false, EmitDefaultValue = false)]
        public string? LockAlias { get; set; }

        [DataMember(Name = "lock_id", IsRequired = false, EmitDefaultValue = false)]
        public float? LockId { get; set; }

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
            bool? incompleteKeyboardPasscode = default,
            bool? lockCommand = default,
            bool? passcode = default,
            bool? passcodeManagement = default,
            bool? unlockViaGateway = default,
            bool? wifi = default
        )
        {
            IncompleteKeyboardPasscode = incompleteKeyboardPasscode;
            LockCommand = lockCommand;
            Passcode = passcode;
            PasscodeManagement = passcodeManagement;
            UnlockViaGateway = unlockViaGateway;
            Wifi = wifi;
        }

        [DataMember(
            Name = "incomplete_keyboard_passcode",
            IsRequired = false,
            EmitDefaultValue = false
        )]
        public bool? IncompleteKeyboardPasscode { get; set; }

        [DataMember(Name = "lock_command", IsRequired = false, EmitDefaultValue = false)]
        public bool? LockCommand { get; set; }

        [DataMember(Name = "passcode", IsRequired = false, EmitDefaultValue = false)]
        public bool? Passcode { get; set; }

        [DataMember(Name = "passcode_management", IsRequired = false, EmitDefaultValue = false)]
        public bool? PasscodeManagement { get; set; }

        [DataMember(Name = "unlock_via_gateway", IsRequired = false, EmitDefaultValue = false)]
        public bool? UnlockViaGateway { get; set; }

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

        [DataMember(Name = "wireless_keypad_id", IsRequired = false, EmitDefaultValue = false)]
        public float? WirelessKeypadId { get; set; }

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

    [DataContract(Name = "seamModel_devicePropertiesVisionlineMetadata_model")]
    public class DevicePropertiesVisionlineMetadata
    {
        [JsonConstructorAttribute]
        protected DevicePropertiesVisionlineMetadata() { }

        public DevicePropertiesVisionlineMetadata(string? encoderId = default)
        {
            EncoderId = encoderId;
        }

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

        [DataMember(Name = "device_id", IsRequired = false, EmitDefaultValue = false)]
        public string? DeviceId { get; set; }

        [DataMember(Name = "device_info_model", IsRequired = false, EmitDefaultValue = false)]
        public string? DeviceInfoModel { get; set; }

        [DataMember(Name = "device_name", IsRequired = false, EmitDefaultValue = false)]
        public string? DeviceName { get; set; }

        [DataMember(Name = "keypad_uuid", IsRequired = false, EmitDefaultValue = false)]
        public string? KeypadUuid { get; set; }

        [DataMember(Name = "locker_status_hardlock", IsRequired = false, EmitDefaultValue = false)]
        public float? LockerStatusHardlock { get; set; }

        [DataMember(Name = "product_model", IsRequired = false, EmitDefaultValue = false)]
        public string? ProductModel { get; set; }

        [DataMember(Name = "product_name", IsRequired = false, EmitDefaultValue = false)]
        public string? ProductName { get; set; }

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

    [DataContract(Name = "seamModel_devicePropertiesActiveThermostatSchedule_model")]
    public class DevicePropertiesActiveThermostatSchedule
    {
        [JsonConstructorAttribute]
        protected DevicePropertiesActiveThermostatSchedule() { }

        public DevicePropertiesActiveThermostatSchedule(
            string? climatePresetKey = default,
            string? createdAt = default,
            string? deviceId = default,
            string? endsAt = default,
            List<DevicePropertiesActiveThermostatScheduleErrors>? errors = default,
            bool? isOverrideAllowed = default,
            int? maxOverridePeriodMinutes = default,
            string? name = default,
            string? startsAt = default,
            string? thermostatScheduleId = default
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
        }

        [DataMember(Name = "climate_preset_key", IsRequired = false, EmitDefaultValue = false)]
        public string? ClimatePresetKey { get; set; }

        [DataMember(Name = "created_at", IsRequired = false, EmitDefaultValue = false)]
        public string? CreatedAt { get; set; }

        [DataMember(Name = "device_id", IsRequired = false, EmitDefaultValue = false)]
        public string? DeviceId { get; set; }

        [DataMember(Name = "ends_at", IsRequired = false, EmitDefaultValue = false)]
        public string? EndsAt { get; set; }

        [DataMember(Name = "errors", IsRequired = false, EmitDefaultValue = false)]
        public List<DevicePropertiesActiveThermostatScheduleErrors>? Errors { get; set; }

        [DataMember(Name = "is_override_allowed", IsRequired = false, EmitDefaultValue = false)]
        public bool? IsOverrideAllowed { get; set; }

        [DataMember(
            Name = "max_override_period_minutes",
            IsRequired = false,
            EmitDefaultValue = false
        )]
        public int? MaxOverridePeriodMinutes { get; set; }

        [DataMember(Name = "name", IsRequired = false, EmitDefaultValue = false)]
        public string? Name { get; set; }

        [DataMember(Name = "starts_at", IsRequired = false, EmitDefaultValue = false)]
        public string? StartsAt { get; set; }

        [DataMember(Name = "thermostat_schedule_id", IsRequired = false, EmitDefaultValue = false)]
        public string? ThermostatScheduleId { get; set; }

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
            string? errorCode = default,
            string? message = default
        )
        {
            ErrorCode = errorCode;
            Message = message;
        }

        [DataMember(Name = "error_code", IsRequired = false, EmitDefaultValue = false)]
        public string? ErrorCode { get; set; }

        [DataMember(Name = "message", IsRequired = false, EmitDefaultValue = false)]
        public string? Message { get; set; }

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
            bool? canDelete = default,
            bool? canEdit = default,
            bool? canProgram = default,
            string? climatePresetKey = default,
            float? coolingSetPointCelsius = default,
            float? coolingSetPointFahrenheit = default,
            string? displayName = default,
            DevicePropertiesAvailableClimatePresets.FanModeSettingEnum? fanModeSetting = default,
            float? heatingSetPointCelsius = default,
            float? heatingSetPointFahrenheit = default,
            DevicePropertiesAvailableClimatePresets.HvacModeSettingEnum? hvacModeSetting = default,
            bool? manualOverrideAllowed = default,
            string? name = default
        )
        {
            CanDelete = canDelete;
            CanEdit = canEdit;
            CanProgram = canProgram;
            ClimatePresetKey = climatePresetKey;
            CoolingSetPointCelsius = coolingSetPointCelsius;
            CoolingSetPointFahrenheit = coolingSetPointFahrenheit;
            DisplayName = displayName;
            FanModeSetting = fanModeSetting;
            HeatingSetPointCelsius = heatingSetPointCelsius;
            HeatingSetPointFahrenheit = heatingSetPointFahrenheit;
            HvacModeSetting = hvacModeSetting;
            ManualOverrideAllowed = manualOverrideAllowed;
            Name = name;
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
        }

        [DataMember(Name = "can_delete", IsRequired = false, EmitDefaultValue = false)]
        public bool? CanDelete { get; set; }

        [DataMember(Name = "can_edit", IsRequired = false, EmitDefaultValue = false)]
        public bool? CanEdit { get; set; }

        [DataMember(Name = "can_program", IsRequired = false, EmitDefaultValue = false)]
        public bool? CanProgram { get; set; }

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

        [DataMember(Name = "display_name", IsRequired = false, EmitDefaultValue = false)]
        public string? DisplayName { get; set; }

        [DataMember(Name = "fan_mode_setting", IsRequired = false, EmitDefaultValue = false)]
        public DevicePropertiesAvailableClimatePresets.FanModeSettingEnum? FanModeSetting { get; set; }

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
        public DevicePropertiesAvailableClimatePresets.HvacModeSettingEnum? HvacModeSetting { get; set; }

        [DataMember(Name = "manual_override_allowed", IsRequired = false, EmitDefaultValue = false)]
        public bool? ManualOverrideAllowed { get; set; }

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

    [DataContract(Name = "seamModel_devicePropertiesCurrentClimateSetting_model")]
    public class DevicePropertiesCurrentClimateSetting
    {
        [JsonConstructorAttribute]
        protected DevicePropertiesCurrentClimateSetting() { }

        public DevicePropertiesCurrentClimateSetting(
            bool? canDelete = default,
            bool? canEdit = default,
            bool? canProgram = default,
            string? climatePresetKey = default,
            float? coolingSetPointCelsius = default,
            float? coolingSetPointFahrenheit = default,
            string? displayName = default,
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
            CanProgram = canProgram;
            ClimatePresetKey = climatePresetKey;
            CoolingSetPointCelsius = coolingSetPointCelsius;
            CoolingSetPointFahrenheit = coolingSetPointFahrenheit;
            DisplayName = displayName;
            FanModeSetting = fanModeSetting;
            HeatingSetPointCelsius = heatingSetPointCelsius;
            HeatingSetPointFahrenheit = heatingSetPointFahrenheit;
            HvacModeSetting = hvacModeSetting;
            ManualOverrideAllowed = manualOverrideAllowed;
            Name = name;
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
        }

        [DataMember(Name = "can_delete", IsRequired = false, EmitDefaultValue = false)]
        public bool? CanDelete { get; set; }

        [DataMember(Name = "can_edit", IsRequired = false, EmitDefaultValue = false)]
        public bool? CanEdit { get; set; }

        [DataMember(Name = "can_program", IsRequired = false, EmitDefaultValue = false)]
        public bool? CanProgram { get; set; }

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

        [DataMember(Name = "display_name", IsRequired = false, EmitDefaultValue = false)]
        public string? DisplayName { get; set; }

        [DataMember(Name = "fan_mode_setting", IsRequired = false, EmitDefaultValue = false)]
        public DevicePropertiesCurrentClimateSetting.FanModeSettingEnum? FanModeSetting { get; set; }

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
        public DevicePropertiesCurrentClimateSetting.HvacModeSettingEnum? HvacModeSetting { get; set; }

        [DataMember(Name = "manual_override_allowed", IsRequired = false, EmitDefaultValue = false)]
        public bool? ManualOverrideAllowed { get; set; }

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

    [DataContract(Name = "seamModel_devicePropertiesDefaultClimateSetting_model")]
    public class DevicePropertiesDefaultClimateSetting
    {
        [JsonConstructorAttribute]
        protected DevicePropertiesDefaultClimateSetting() { }

        public DevicePropertiesDefaultClimateSetting(
            bool? canDelete = default,
            bool? canEdit = default,
            bool? canProgram = default,
            string? climatePresetKey = default,
            float? coolingSetPointCelsius = default,
            float? coolingSetPointFahrenheit = default,
            string? displayName = default,
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
            CanProgram = canProgram;
            ClimatePresetKey = climatePresetKey;
            CoolingSetPointCelsius = coolingSetPointCelsius;
            CoolingSetPointFahrenheit = coolingSetPointFahrenheit;
            DisplayName = displayName;
            FanModeSetting = fanModeSetting;
            HeatingSetPointCelsius = heatingSetPointCelsius;
            HeatingSetPointFahrenheit = heatingSetPointFahrenheit;
            HvacModeSetting = hvacModeSetting;
            ManualOverrideAllowed = manualOverrideAllowed;
            Name = name;
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
        }

        [DataMember(Name = "can_delete", IsRequired = false, EmitDefaultValue = false)]
        public bool? CanDelete { get; set; }

        [DataMember(Name = "can_edit", IsRequired = false, EmitDefaultValue = false)]
        public bool? CanEdit { get; set; }

        [DataMember(Name = "can_program", IsRequired = false, EmitDefaultValue = false)]
        public bool? CanProgram { get; set; }

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

        [DataMember(Name = "display_name", IsRequired = false, EmitDefaultValue = false)]
        public string? DisplayName { get; set; }

        [DataMember(Name = "fan_mode_setting", IsRequired = false, EmitDefaultValue = false)]
        public DevicePropertiesDefaultClimateSetting.FanModeSettingEnum? FanModeSetting { get; set; }

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
        public DevicePropertiesDefaultClimateSetting.HvacModeSettingEnum? HvacModeSetting { get; set; }

        [DataMember(Name = "manual_override_allowed", IsRequired = false, EmitDefaultValue = false)]
        public bool? ManualOverrideAllowed { get; set; }

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

        [DataMember(Name = "lower_limit_celsius", IsRequired = false, EmitDefaultValue = false)]
        public float? LowerLimitCelsius { get; set; }

        [DataMember(Name = "lower_limit_fahrenheit", IsRequired = false, EmitDefaultValue = false)]
        public float? LowerLimitFahrenheit { get; set; }

        [DataMember(Name = "upper_limit_celsius", IsRequired = false, EmitDefaultValue = false)]
        public float? UpperLimitCelsius { get; set; }

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
            string? createdAt = default,
            string? deviceId = default,
            string? name = default,
            List<DevicePropertiesThermostatDailyProgramsPeriods>? periods = default,
            string? thermostatDailyProgramId = default
        )
        {
            CreatedAt = createdAt;
            DeviceId = deviceId;
            Name = name;
            Periods = periods;
            ThermostatDailyProgramId = thermostatDailyProgramId;
        }

        [DataMember(Name = "created_at", IsRequired = false, EmitDefaultValue = false)]
        public string? CreatedAt { get; set; }

        [DataMember(Name = "device_id", IsRequired = false, EmitDefaultValue = false)]
        public string? DeviceId { get; set; }

        [DataMember(Name = "name", IsRequired = false, EmitDefaultValue = false)]
        public string? Name { get; set; }

        [DataMember(Name = "periods", IsRequired = false, EmitDefaultValue = false)]
        public List<DevicePropertiesThermostatDailyProgramsPeriods>? Periods { get; set; }

        [DataMember(
            Name = "thermostat_daily_program_id",
            IsRequired = false,
            EmitDefaultValue = false
        )]
        public string? ThermostatDailyProgramId { get; set; }

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
            string? climatePresetKey = default,
            string? startsAtTime = default
        )
        {
            ClimatePresetKey = climatePresetKey;
            StartsAtTime = startsAtTime;
        }

        [DataMember(Name = "climate_preset_key", IsRequired = false, EmitDefaultValue = false)]
        public string? ClimatePresetKey { get; set; }

        [DataMember(Name = "starts_at_time", IsRequired = false, EmitDefaultValue = false)]
        public string? StartsAtTime { get; set; }

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
            string? createdAt = default,
            string? deviceId = default,
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
            DeviceId = deviceId;
            FridayProgramId = fridayProgramId;
            MondayProgramId = mondayProgramId;
            SaturdayProgramId = saturdayProgramId;
            SundayProgramId = sundayProgramId;
            ThursdayProgramId = thursdayProgramId;
            TuesdayProgramId = tuesdayProgramId;
            WednesdayProgramId = wednesdayProgramId;
        }

        [DataMember(Name = "created_at", IsRequired = false, EmitDefaultValue = false)]
        public string? CreatedAt { get; set; }

        [DataMember(Name = "device_id", IsRequired = false, EmitDefaultValue = false)]
        public string? DeviceId { get; set; }

        [DataMember(Name = "friday_program_id", IsRequired = false, EmitDefaultValue = false)]
        public string? FridayProgramId { get; set; }

        [DataMember(Name = "monday_program_id", IsRequired = false, EmitDefaultValue = false)]
        public string? MondayProgramId { get; set; }

        [DataMember(Name = "saturday_program_id", IsRequired = false, EmitDefaultValue = false)]
        public string? SaturdayProgramId { get; set; }

        [DataMember(Name = "sunday_program_id", IsRequired = false, EmitDefaultValue = false)]
        public string? SundayProgramId { get; set; }

        [DataMember(Name = "thursday_program_id", IsRequired = false, EmitDefaultValue = false)]
        public string? ThursdayProgramId { get; set; }

        [DataMember(Name = "tuesday_program_id", IsRequired = false, EmitDefaultValue = false)]
        public string? TuesdayProgramId { get; set; }

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
