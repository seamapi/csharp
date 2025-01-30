using System.Runtime.Serialization;
using System.Text;
using JsonSubTypes;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using Seam.Model;

namespace Seam.Model
{
    [DataContract(Name = "seamModel_phone_model")]
    public class Phone
    {
        [JsonConstructorAttribute]
        protected Phone() { }

        public Phone(
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
            List<Phone.CapabilitiesSupportedEnum> capabilitiesSupported = default,
            string createdAt = default,
            object? customMetadata = default,
            string deviceId = default,
            Phone.DeviceTypeEnum deviceType = default,
            string displayName = default,
            List<Errors> errors = default,
            bool isManaged = default,
            PhoneLocation? location = default,
            string? nickname = default,
            PhoneProperties properties = default,
            List<Warnings> warnings = default,
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

            [EnumMember(Value = "android_phone")]
            AndroidPhone = 1,

            [EnumMember(Value = "ios_phone")]
            IosPhone = 2,
        }

        [JsonConverter(typeof(JsonSubtypes), "error_code")]
        [JsonSubtypes.KnownSubType(typeof(ErrorsInvalidCredentials), "invalid_credentials")]
        [JsonSubtypes.KnownSubType(typeof(ErrorsAccountDisconnected), "account_disconnected")]
        [JsonSubtypes.KnownSubType(typeof(ErrorsSubscriptionRequired), "subscription_required")]
        [JsonSubtypes.KnownSubType(typeof(ErrorsAuxiliaryHeatRunning), "auxiliary_heat_running")]
        [JsonSubtypes.KnownSubType(
            typeof(ErrorsMissingDeviceCredentials),
            "missing_device_credentials"
        )]
        [JsonSubtypes.KnownSubType(
            typeof(ErrorsTtlockLockNotPairedToGateway),
            "ttlock_lock_not_paired_to_gateway"
        )]
        [JsonSubtypes.KnownSubType(
            typeof(ErrorsSaltoSiteUserLimitReached),
            "salto_site_user_limit_reached"
        )]
        [JsonSubtypes.KnownSubType(
            typeof(ErrorsAugustLockMissingBridge),
            "august_lock_missing_bridge"
        )]
        [JsonSubtypes.KnownSubType(
            typeof(ErrorsAugustLockNotAuthorized),
            "august_lock_not_authorized"
        )]
        [JsonSubtypes.KnownSubType(
            typeof(ErrorsEmptyBackupAccessCodePool),
            "empty_backup_access_code_pool"
        )]
        [JsonSubtypes.KnownSubType(typeof(ErrorsDeviceDisconnected), "device_disconnected")]
        [JsonSubtypes.KnownSubType(typeof(ErrorsHubDisconnected), "hub_disconnected")]
        [JsonSubtypes.KnownSubType(typeof(ErrorsDeviceRemoved), "device_removed")]
        [JsonSubtypes.KnownSubType(typeof(ErrorsDeviceOffline), "device_offline")]
        public abstract class Errors
        {
            public abstract string ErrorCode { get; }

            public abstract override string ToString();
        }

        [DataContract(Name = "seamModel_errorsDeviceOffline_model")]
        public class ErrorsDeviceOffline : Errors
        {
            [JsonConstructorAttribute]
            protected ErrorsDeviceOffline() { }

            public ErrorsDeviceOffline(
                string errorCode = default,
                bool isDeviceError = default,
                string message = default
            )
            {
                ErrorCode = errorCode;
                IsDeviceError = isDeviceError;
                Message = message;
            }

            [DataMember(Name = "error_code", IsRequired = true, EmitDefaultValue = false)]
            public override string ErrorCode { get; } = "device_offline";

            [DataMember(Name = "is_device_error", IsRequired = true, EmitDefaultValue = false)]
            public bool IsDeviceError { get; set; }

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

        [DataContract(Name = "seamModel_errorsDeviceRemoved_model")]
        public class ErrorsDeviceRemoved : Errors
        {
            [JsonConstructorAttribute]
            protected ErrorsDeviceRemoved() { }

            public ErrorsDeviceRemoved(
                string errorCode = default,
                bool isDeviceError = default,
                string message = default
            )
            {
                ErrorCode = errorCode;
                IsDeviceError = isDeviceError;
                Message = message;
            }

            [DataMember(Name = "error_code", IsRequired = true, EmitDefaultValue = false)]
            public override string ErrorCode { get; } = "device_removed";

            [DataMember(Name = "is_device_error", IsRequired = true, EmitDefaultValue = false)]
            public bool IsDeviceError { get; set; }

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

        [DataContract(Name = "seamModel_errorsHubDisconnected_model")]
        public class ErrorsHubDisconnected : Errors
        {
            [JsonConstructorAttribute]
            protected ErrorsHubDisconnected() { }

            public ErrorsHubDisconnected(
                string errorCode = default,
                bool isDeviceError = default,
                string message = default
            )
            {
                ErrorCode = errorCode;
                IsDeviceError = isDeviceError;
                Message = message;
            }

            [DataMember(Name = "error_code", IsRequired = true, EmitDefaultValue = false)]
            public override string ErrorCode { get; } = "hub_disconnected";

            [DataMember(Name = "is_device_error", IsRequired = true, EmitDefaultValue = false)]
            public bool IsDeviceError { get; set; }

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

        [DataContract(Name = "seamModel_errorsDeviceDisconnected_model")]
        public class ErrorsDeviceDisconnected : Errors
        {
            [JsonConstructorAttribute]
            protected ErrorsDeviceDisconnected() { }

            public ErrorsDeviceDisconnected(
                string errorCode = default,
                bool isDeviceError = default,
                string message = default
            )
            {
                ErrorCode = errorCode;
                IsDeviceError = isDeviceError;
                Message = message;
            }

            [DataMember(Name = "error_code", IsRequired = true, EmitDefaultValue = false)]
            public override string ErrorCode { get; } = "device_disconnected";

            [DataMember(Name = "is_device_error", IsRequired = true, EmitDefaultValue = false)]
            public bool IsDeviceError { get; set; }

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

        [DataContract(Name = "seamModel_errorsEmptyBackupAccessCodePool_model")]
        public class ErrorsEmptyBackupAccessCodePool : Errors
        {
            [JsonConstructorAttribute]
            protected ErrorsEmptyBackupAccessCodePool() { }

            public ErrorsEmptyBackupAccessCodePool(
                string errorCode = default,
                bool isDeviceError = default,
                string message = default
            )
            {
                ErrorCode = errorCode;
                IsDeviceError = isDeviceError;
                Message = message;
            }

            [DataMember(Name = "error_code", IsRequired = true, EmitDefaultValue = false)]
            public override string ErrorCode { get; } = "empty_backup_access_code_pool";

            [DataMember(Name = "is_device_error", IsRequired = true, EmitDefaultValue = false)]
            public bool IsDeviceError { get; set; }

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

        [DataContract(Name = "seamModel_errorsAugustLockNotAuthorized_model")]
        public class ErrorsAugustLockNotAuthorized : Errors
        {
            [JsonConstructorAttribute]
            protected ErrorsAugustLockNotAuthorized() { }

            public ErrorsAugustLockNotAuthorized(
                string errorCode = default,
                bool isDeviceError = default,
                string message = default
            )
            {
                ErrorCode = errorCode;
                IsDeviceError = isDeviceError;
                Message = message;
            }

            [DataMember(Name = "error_code", IsRequired = true, EmitDefaultValue = false)]
            public override string ErrorCode { get; } = "august_lock_not_authorized";

            [DataMember(Name = "is_device_error", IsRequired = true, EmitDefaultValue = false)]
            public bool IsDeviceError { get; set; }

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

        [DataContract(Name = "seamModel_errorsAugustLockMissingBridge_model")]
        public class ErrorsAugustLockMissingBridge : Errors
        {
            [JsonConstructorAttribute]
            protected ErrorsAugustLockMissingBridge() { }

            public ErrorsAugustLockMissingBridge(
                string errorCode = default,
                bool isDeviceError = default,
                string message = default
            )
            {
                ErrorCode = errorCode;
                IsDeviceError = isDeviceError;
                Message = message;
            }

            [DataMember(Name = "error_code", IsRequired = true, EmitDefaultValue = false)]
            public override string ErrorCode { get; } = "august_lock_missing_bridge";

            [DataMember(Name = "is_device_error", IsRequired = true, EmitDefaultValue = false)]
            public bool IsDeviceError { get; set; }

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

        [DataContract(Name = "seamModel_errorsSaltoSiteUserLimitReached_model")]
        public class ErrorsSaltoSiteUserLimitReached : Errors
        {
            [JsonConstructorAttribute]
            protected ErrorsSaltoSiteUserLimitReached() { }

            public ErrorsSaltoSiteUserLimitReached(
                string errorCode = default,
                bool isDeviceError = default,
                string message = default
            )
            {
                ErrorCode = errorCode;
                IsDeviceError = isDeviceError;
                Message = message;
            }

            [DataMember(Name = "error_code", IsRequired = true, EmitDefaultValue = false)]
            public override string ErrorCode { get; } = "salto_site_user_limit_reached";

            [DataMember(Name = "is_device_error", IsRequired = true, EmitDefaultValue = false)]
            public bool IsDeviceError { get; set; }

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

        [DataContract(Name = "seamModel_errorsTtlockLockNotPairedToGateway_model")]
        public class ErrorsTtlockLockNotPairedToGateway : Errors
        {
            [JsonConstructorAttribute]
            protected ErrorsTtlockLockNotPairedToGateway() { }

            public ErrorsTtlockLockNotPairedToGateway(
                string errorCode = default,
                bool isDeviceError = default,
                string message = default
            )
            {
                ErrorCode = errorCode;
                IsDeviceError = isDeviceError;
                Message = message;
            }

            [DataMember(Name = "error_code", IsRequired = true, EmitDefaultValue = false)]
            public override string ErrorCode { get; } = "ttlock_lock_not_paired_to_gateway";

            [DataMember(Name = "is_device_error", IsRequired = true, EmitDefaultValue = false)]
            public bool IsDeviceError { get; set; }

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

        [DataContract(Name = "seamModel_errorsMissingDeviceCredentials_model")]
        public class ErrorsMissingDeviceCredentials : Errors
        {
            [JsonConstructorAttribute]
            protected ErrorsMissingDeviceCredentials() { }

            public ErrorsMissingDeviceCredentials(
                string errorCode = default,
                bool isDeviceError = default,
                string message = default
            )
            {
                ErrorCode = errorCode;
                IsDeviceError = isDeviceError;
                Message = message;
            }

            [DataMember(Name = "error_code", IsRequired = true, EmitDefaultValue = false)]
            public override string ErrorCode { get; } = "missing_device_credentials";

            [DataMember(Name = "is_device_error", IsRequired = true, EmitDefaultValue = false)]
            public bool IsDeviceError { get; set; }

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

        [DataContract(Name = "seamModel_errorsAuxiliaryHeatRunning_model")]
        public class ErrorsAuxiliaryHeatRunning : Errors
        {
            [JsonConstructorAttribute]
            protected ErrorsAuxiliaryHeatRunning() { }

            public ErrorsAuxiliaryHeatRunning(
                string errorCode = default,
                bool isDeviceError = default,
                string message = default
            )
            {
                ErrorCode = errorCode;
                IsDeviceError = isDeviceError;
                Message = message;
            }

            [DataMember(Name = "error_code", IsRequired = true, EmitDefaultValue = false)]
            public override string ErrorCode { get; } = "auxiliary_heat_running";

            [DataMember(Name = "is_device_error", IsRequired = true, EmitDefaultValue = false)]
            public bool IsDeviceError { get; set; }

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

        [DataContract(Name = "seamModel_errorsSubscriptionRequired_model")]
        public class ErrorsSubscriptionRequired : Errors
        {
            [JsonConstructorAttribute]
            protected ErrorsSubscriptionRequired() { }

            public ErrorsSubscriptionRequired(
                string errorCode = default,
                bool isDeviceError = default,
                string message = default
            )
            {
                ErrorCode = errorCode;
                IsDeviceError = isDeviceError;
                Message = message;
            }

            [DataMember(Name = "error_code", IsRequired = true, EmitDefaultValue = false)]
            public override string ErrorCode { get; } = "subscription_required";

            [DataMember(Name = "is_device_error", IsRequired = true, EmitDefaultValue = false)]
            public bool IsDeviceError { get; set; }

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

        [DataContract(Name = "seamModel_errorsAccountDisconnected_model")]
        public class ErrorsAccountDisconnected : Errors
        {
            [JsonConstructorAttribute]
            protected ErrorsAccountDisconnected() { }

            public ErrorsAccountDisconnected(
                string errorCode = default,
                bool isConnectedAccountError = default,
                string message = default
            )
            {
                ErrorCode = errorCode;
                IsConnectedAccountError = isConnectedAccountError;
                Message = message;
            }

            [DataMember(Name = "error_code", IsRequired = true, EmitDefaultValue = false)]
            public override string ErrorCode { get; } = "account_disconnected";

            [DataMember(
                Name = "is_connected_account_error",
                IsRequired = true,
                EmitDefaultValue = false
            )]
            public bool IsConnectedAccountError { get; set; }

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

        [DataContract(Name = "seamModel_errorsInvalidCredentials_model")]
        public class ErrorsInvalidCredentials : Errors
        {
            [JsonConstructorAttribute]
            protected ErrorsInvalidCredentials() { }

            public ErrorsInvalidCredentials(
                string errorCode = default,
                bool isConnectedAccountError = default,
                string message = default
            )
            {
                ErrorCode = errorCode;
                IsConnectedAccountError = isConnectedAccountError;
                Message = message;
            }

            [DataMember(Name = "error_code", IsRequired = true, EmitDefaultValue = false)]
            public override string ErrorCode { get; } = "invalid_credentials";

            [DataMember(
                Name = "is_connected_account_error",
                IsRequired = true,
                EmitDefaultValue = false
            )]
            public bool IsConnectedAccountError { get; set; }

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

        [JsonConverter(typeof(JsonSubtypes), "warning_code")]
        [JsonSubtypes.KnownSubType(
            typeof(WarningsUnknownIssueWithPhone),
            "unknown_issue_with_phone"
        )]
        [JsonSubtypes.KnownSubType(typeof(WarningsSaltoPrivacyMode), "salto_privacy_mode")]
        [JsonSubtypes.KnownSubType(typeof(WarningsSaltoOfficeMode), "salto_office_mode")]
        [JsonSubtypes.KnownSubType(
            typeof(WarningsDeviceHasFlakyConnection),
            "device_has_flaky_connection"
        )]
        [JsonSubtypes.KnownSubType(
            typeof(WarningsScheduledMaintenanceWindow),
            "scheduled_maintenance_window"
        )]
        [JsonSubtypes.KnownSubType(
            typeof(WarningsDeviceCommunicationDegraded),
            "device_communication_degraded"
        )]
        [JsonSubtypes.KnownSubType(
            typeof(WarningsTemperatureThresholdExceeded),
            "temperature_threshold_exceeded"
        )]
        [JsonSubtypes.KnownSubType(
            typeof(WarningsTtlockWeakGatewaySignal),
            "ttlock_weak_gateway_signal"
        )]
        [JsonSubtypes.KnownSubType(
            typeof(WarningsTtlockLockGatewayUnlockingNotEnabled),
            "ttlock_lock_gateway_unlocking_not_enabled"
        )]
        [JsonSubtypes.KnownSubType(
            typeof(WarningsNestThermostatInManualEcoMode),
            "nest_thermostat_in_manual_eco_mode"
        )]
        [JsonSubtypes.KnownSubType(
            typeof(WarningsThirdPartyIntegrationDetected),
            "third_party_integration_detected"
        )]
        [JsonSubtypes.KnownSubType(
            typeof(WarningsFunctionalOfflineDevice),
            "functional_offline_device"
        )]
        [JsonSubtypes.KnownSubType(
            typeof(WarningsWyzeDeviceMissingGateway),
            "wyze_device_missing_gateway"
        )]
        [JsonSubtypes.KnownSubType(
            typeof(WarningsSaltoUnknownDeviceType),
            "salto_unknown_device_type"
        )]
        [JsonSubtypes.KnownSubType(
            typeof(WarningsManyActiveBackupCodes),
            "many_active_backup_codes"
        )]
        [JsonSubtypes.KnownSubType(
            typeof(WarningsPartialBackupAccessCodePool),
            "partial_backup_access_code_pool"
        )]
        public abstract class Warnings
        {
            public abstract string WarningCode { get; }

            public abstract override string ToString();
        }

        [DataContract(Name = "seamModel_warningsPartialBackupAccessCodePool_model")]
        public class WarningsPartialBackupAccessCodePool : Warnings
        {
            [JsonConstructorAttribute]
            protected WarningsPartialBackupAccessCodePool() { }

            public WarningsPartialBackupAccessCodePool(
                string message = default,
                string warningCode = default
            )
            {
                Message = message;
                WarningCode = warningCode;
            }

            [DataMember(Name = "message", IsRequired = true, EmitDefaultValue = false)]
            public string Message { get; set; }

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

        [DataContract(Name = "seamModel_warningsManyActiveBackupCodes_model")]
        public class WarningsManyActiveBackupCodes : Warnings
        {
            [JsonConstructorAttribute]
            protected WarningsManyActiveBackupCodes() { }

            public WarningsManyActiveBackupCodes(
                string message = default,
                string warningCode = default
            )
            {
                Message = message;
                WarningCode = warningCode;
            }

            [DataMember(Name = "message", IsRequired = true, EmitDefaultValue = false)]
            public string Message { get; set; }

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

        [DataContract(Name = "seamModel_warningsSaltoUnknownDeviceType_model")]
        public class WarningsSaltoUnknownDeviceType : Warnings
        {
            [JsonConstructorAttribute]
            protected WarningsSaltoUnknownDeviceType() { }

            public WarningsSaltoUnknownDeviceType(
                string message = default,
                string warningCode = default
            )
            {
                Message = message;
                WarningCode = warningCode;
            }

            [DataMember(Name = "message", IsRequired = true, EmitDefaultValue = false)]
            public string Message { get; set; }

            [DataMember(Name = "warning_code", IsRequired = true, EmitDefaultValue = false)]
            public override string WarningCode { get; } = "salto_unknown_device_type";

            public override string ToString()
            {
                JsonSerializer jsonSerializer = JsonSerializer.CreateDefault(null);

                StringWriter stringWriter = new StringWriter(
                    new StringBuilder(256),
                    System.Globalization.CultureInfo.InvariantCulture
                );
                using (JsonTextWriter jsonTextWriter = new JsonTextWriter(stringWriter))
                {
                    jsonTextWriter.IndentChar = ' ';
                    jsonTextWriter.Indentation = 2;
                    jsonTextWriter.Formatting = Formatting.Indented;
                    jsonSerializer.Serialize(jsonTextWriter, this, null);
                }

                return stringWriter.ToString();
            }
        }

        [DataContract(Name = "seamModel_warningsWyzeDeviceMissingGateway_model")]
        public class WarningsWyzeDeviceMissingGateway : Warnings
        {
            [JsonConstructorAttribute]
            protected WarningsWyzeDeviceMissingGateway() { }

            public WarningsWyzeDeviceMissingGateway(
                string message = default,
                string warningCode = default
            )
            {
                Message = message;
                WarningCode = warningCode;
            }

            [DataMember(Name = "message", IsRequired = true, EmitDefaultValue = false)]
            public string Message { get; set; }

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

        [DataContract(Name = "seamModel_warningsFunctionalOfflineDevice_model")]
        public class WarningsFunctionalOfflineDevice : Warnings
        {
            [JsonConstructorAttribute]
            protected WarningsFunctionalOfflineDevice() { }

            public WarningsFunctionalOfflineDevice(
                string message = default,
                string warningCode = default
            )
            {
                Message = message;
                WarningCode = warningCode;
            }

            [DataMember(Name = "message", IsRequired = true, EmitDefaultValue = false)]
            public string Message { get; set; }

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

        [DataContract(Name = "seamModel_warningsThirdPartyIntegrationDetected_model")]
        public class WarningsThirdPartyIntegrationDetected : Warnings
        {
            [JsonConstructorAttribute]
            protected WarningsThirdPartyIntegrationDetected() { }

            public WarningsThirdPartyIntegrationDetected(
                string message = default,
                string warningCode = default
            )
            {
                Message = message;
                WarningCode = warningCode;
            }

            [DataMember(Name = "message", IsRequired = true, EmitDefaultValue = false)]
            public string Message { get; set; }

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

        [DataContract(Name = "seamModel_warningsNestThermostatInManualEcoMode_model")]
        public class WarningsNestThermostatInManualEcoMode : Warnings
        {
            [JsonConstructorAttribute]
            protected WarningsNestThermostatInManualEcoMode() { }

            public WarningsNestThermostatInManualEcoMode(
                string message = default,
                string warningCode = default
            )
            {
                Message = message;
                WarningCode = warningCode;
            }

            [DataMember(Name = "message", IsRequired = true, EmitDefaultValue = false)]
            public string Message { get; set; }

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

        [DataContract(Name = "seamModel_warningsTtlockLockGatewayUnlockingNotEnabled_model")]
        public class WarningsTtlockLockGatewayUnlockingNotEnabled : Warnings
        {
            [JsonConstructorAttribute]
            protected WarningsTtlockLockGatewayUnlockingNotEnabled() { }

            public WarningsTtlockLockGatewayUnlockingNotEnabled(
                string message = default,
                string warningCode = default
            )
            {
                Message = message;
                WarningCode = warningCode;
            }

            [DataMember(Name = "message", IsRequired = true, EmitDefaultValue = false)]
            public string Message { get; set; }

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

        [DataContract(Name = "seamModel_warningsTtlockWeakGatewaySignal_model")]
        public class WarningsTtlockWeakGatewaySignal : Warnings
        {
            [JsonConstructorAttribute]
            protected WarningsTtlockWeakGatewaySignal() { }

            public WarningsTtlockWeakGatewaySignal(
                string message = default,
                string warningCode = default
            )
            {
                Message = message;
                WarningCode = warningCode;
            }

            [DataMember(Name = "message", IsRequired = true, EmitDefaultValue = false)]
            public string Message { get; set; }

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

        [DataContract(Name = "seamModel_warningsTemperatureThresholdExceeded_model")]
        public class WarningsTemperatureThresholdExceeded : Warnings
        {
            [JsonConstructorAttribute]
            protected WarningsTemperatureThresholdExceeded() { }

            public WarningsTemperatureThresholdExceeded(
                string message = default,
                string warningCode = default
            )
            {
                Message = message;
                WarningCode = warningCode;
            }

            [DataMember(Name = "message", IsRequired = true, EmitDefaultValue = false)]
            public string Message { get; set; }

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

        [DataContract(Name = "seamModel_warningsDeviceCommunicationDegraded_model")]
        public class WarningsDeviceCommunicationDegraded : Warnings
        {
            [JsonConstructorAttribute]
            protected WarningsDeviceCommunicationDegraded() { }

            public WarningsDeviceCommunicationDegraded(
                string message = default,
                string warningCode = default
            )
            {
                Message = message;
                WarningCode = warningCode;
            }

            [DataMember(Name = "message", IsRequired = true, EmitDefaultValue = false)]
            public string Message { get; set; }

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

        [DataContract(Name = "seamModel_warningsScheduledMaintenanceWindow_model")]
        public class WarningsScheduledMaintenanceWindow : Warnings
        {
            [JsonConstructorAttribute]
            protected WarningsScheduledMaintenanceWindow() { }

            public WarningsScheduledMaintenanceWindow(
                string message = default,
                string warningCode = default
            )
            {
                Message = message;
                WarningCode = warningCode;
            }

            [DataMember(Name = "message", IsRequired = true, EmitDefaultValue = false)]
            public string Message { get; set; }

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

        [DataContract(Name = "seamModel_warningsDeviceHasFlakyConnection_model")]
        public class WarningsDeviceHasFlakyConnection : Warnings
        {
            [JsonConstructorAttribute]
            protected WarningsDeviceHasFlakyConnection() { }

            public WarningsDeviceHasFlakyConnection(
                string message = default,
                string warningCode = default
            )
            {
                Message = message;
                WarningCode = warningCode;
            }

            [DataMember(Name = "message", IsRequired = true, EmitDefaultValue = false)]
            public string Message { get; set; }

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

        [DataContract(Name = "seamModel_warningsSaltoOfficeMode_model")]
        public class WarningsSaltoOfficeMode : Warnings
        {
            [JsonConstructorAttribute]
            protected WarningsSaltoOfficeMode() { }

            public WarningsSaltoOfficeMode(string message = default, string warningCode = default)
            {
                Message = message;
                WarningCode = warningCode;
            }

            [DataMember(Name = "message", IsRequired = true, EmitDefaultValue = false)]
            public string Message { get; set; }

            [DataMember(Name = "warning_code", IsRequired = true, EmitDefaultValue = false)]
            public override string WarningCode { get; } = "salto_office_mode";

            public override string ToString()
            {
                JsonSerializer jsonSerializer = JsonSerializer.CreateDefault(null);

                StringWriter stringWriter = new StringWriter(
                    new StringBuilder(256),
                    System.Globalization.CultureInfo.InvariantCulture
                );
                using (JsonTextWriter jsonTextWriter = new JsonTextWriter(stringWriter))
                {
                    jsonTextWriter.IndentChar = ' ';
                    jsonTextWriter.Indentation = 2;
                    jsonTextWriter.Formatting = Formatting.Indented;
                    jsonSerializer.Serialize(jsonTextWriter, this, null);
                }

                return stringWriter.ToString();
            }
        }

        [DataContract(Name = "seamModel_warningsSaltoPrivacyMode_model")]
        public class WarningsSaltoPrivacyMode : Warnings
        {
            [JsonConstructorAttribute]
            protected WarningsSaltoPrivacyMode() { }

            public WarningsSaltoPrivacyMode(string message = default, string warningCode = default)
            {
                Message = message;
                WarningCode = warningCode;
            }

            [DataMember(Name = "message", IsRequired = true, EmitDefaultValue = false)]
            public string Message { get; set; }

            [DataMember(Name = "warning_code", IsRequired = true, EmitDefaultValue = false)]
            public override string WarningCode { get; } = "salto_privacy_mode";

            public override string ToString()
            {
                JsonSerializer jsonSerializer = JsonSerializer.CreateDefault(null);

                StringWriter stringWriter = new StringWriter(
                    new StringBuilder(256),
                    System.Globalization.CultureInfo.InvariantCulture
                );
                using (JsonTextWriter jsonTextWriter = new JsonTextWriter(stringWriter))
                {
                    jsonTextWriter.IndentChar = ' ';
                    jsonTextWriter.Indentation = 2;
                    jsonTextWriter.Formatting = Formatting.Indented;
                    jsonSerializer.Serialize(jsonTextWriter, this, null);
                }

                return stringWriter.ToString();
            }
        }

        [DataContract(Name = "seamModel_warningsUnknownIssueWithPhone_model")]
        public class WarningsUnknownIssueWithPhone : Warnings
        {
            [JsonConstructorAttribute]
            protected WarningsUnknownIssueWithPhone() { }

            public WarningsUnknownIssueWithPhone(
                string message = default,
                string warningCode = default
            )
            {
                Message = message;
                WarningCode = warningCode;
            }

            [DataMember(Name = "message", IsRequired = true, EmitDefaultValue = false)]
            public string Message { get; set; }

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
        public List<Phone.CapabilitiesSupportedEnum> CapabilitiesSupported { get; set; }

        [DataMember(Name = "created_at", IsRequired = true, EmitDefaultValue = false)]
        public string CreatedAt { get; set; }

        [DataMember(Name = "custom_metadata", IsRequired = true, EmitDefaultValue = false)]
        public object? CustomMetadata { get; set; }

        [DataMember(Name = "device_id", IsRequired = true, EmitDefaultValue = false)]
        public string DeviceId { get; set; }

        [DataMember(Name = "device_type", IsRequired = true, EmitDefaultValue = false)]
        public Phone.DeviceTypeEnum DeviceType { get; set; }

        [DataMember(Name = "display_name", IsRequired = true, EmitDefaultValue = false)]
        public string DisplayName { get; set; }

        [DataMember(Name = "errors", IsRequired = true, EmitDefaultValue = false)]
        public List<Errors> Errors { get; set; }

        [DataMember(Name = "is_managed", IsRequired = true, EmitDefaultValue = false)]
        public bool IsManaged { get; set; }

        [DataMember(Name = "location", IsRequired = false, EmitDefaultValue = false)]
        public PhoneLocation? Location { get; set; }

        [DataMember(Name = "nickname", IsRequired = false, EmitDefaultValue = false)]
        public string? Nickname { get; set; }

        [DataMember(Name = "properties", IsRequired = true, EmitDefaultValue = false)]
        public PhoneProperties Properties { get; set; }

        [DataMember(Name = "warnings", IsRequired = true, EmitDefaultValue = false)]
        public List<Warnings> Warnings { get; set; }

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

    [DataContract(Name = "seamModel_phoneLocation_model")]
    public class PhoneLocation
    {
        [JsonConstructorAttribute]
        protected PhoneLocation() { }

        public PhoneLocation(string? locationName = default, string? timezone = default)
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

    [DataContract(Name = "seamModel_phoneProperties_model")]
    public class PhoneProperties
    {
        [JsonConstructorAttribute]
        protected PhoneProperties() { }

        public PhoneProperties(
            PhonePropertiesAssaAbloyCredentialServiceMetadata? assaAbloyCredentialServiceMetadata =
                default,
            PhonePropertiesSaltoSpaceCredentialServiceMetadata? saltoSpaceCredentialServiceMetadata =
                default
        )
        {
            AssaAbloyCredentialServiceMetadata = assaAbloyCredentialServiceMetadata;
            SaltoSpaceCredentialServiceMetadata = saltoSpaceCredentialServiceMetadata;
        }

        [DataMember(
            Name = "assa_abloy_credential_service_metadata",
            IsRequired = false,
            EmitDefaultValue = false
        )]
        public PhonePropertiesAssaAbloyCredentialServiceMetadata? AssaAbloyCredentialServiceMetadata { get; set; }

        [DataMember(
            Name = "salto_space_credential_service_metadata",
            IsRequired = false,
            EmitDefaultValue = false
        )]
        public PhonePropertiesSaltoSpaceCredentialServiceMetadata? SaltoSpaceCredentialServiceMetadata { get; set; }

        public override string ToString()
        {
            JsonSerializer jsonSerializer = JsonSerializer.CreateDefault(null);

            StringWriter stringWriter = new StringWriter(
                new StringBuilder(256),
                System.Globalization.CultureInfo.InvariantCulture
            );
            using (JsonTextWriter jsonTextWriter = new JsonTextWriter(stringWriter))
            {
                jsonTextWriter.IndentChar = ' ';
                jsonTextWriter.Indentation = 2;
                jsonTextWriter.Formatting = Formatting.Indented;
                jsonSerializer.Serialize(jsonTextWriter, this, null);
            }

            return stringWriter.ToString();
        }
    }

    [DataContract(Name = "seamModel_phonePropertiesAssaAbloyCredentialServiceMetadata_model")]
    public class PhonePropertiesAssaAbloyCredentialServiceMetadata
    {
        [JsonConstructorAttribute]
        protected PhonePropertiesAssaAbloyCredentialServiceMetadata() { }

        public PhonePropertiesAssaAbloyCredentialServiceMetadata(
            List<PhonePropertiesAssaAbloyCredentialServiceMetadataEndpoints> endpoints = default,
            bool hasActiveEndpoint = default
        )
        {
            Endpoints = endpoints;
            HasActiveEndpoint = hasActiveEndpoint;
        }

        [DataMember(Name = "endpoints", IsRequired = true, EmitDefaultValue = false)]
        public List<PhonePropertiesAssaAbloyCredentialServiceMetadataEndpoints> Endpoints { get; set; }

        [DataMember(Name = "has_active_endpoint", IsRequired = true, EmitDefaultValue = false)]
        public bool HasActiveEndpoint { get; set; }

        public override string ToString()
        {
            JsonSerializer jsonSerializer = JsonSerializer.CreateDefault(null);

            StringWriter stringWriter = new StringWriter(
                new StringBuilder(256),
                System.Globalization.CultureInfo.InvariantCulture
            );
            using (JsonTextWriter jsonTextWriter = new JsonTextWriter(stringWriter))
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
        Name = "seamModel_phonePropertiesAssaAbloyCredentialServiceMetadataEndpoints_model"
    )]
    public class PhonePropertiesAssaAbloyCredentialServiceMetadataEndpoints
    {
        [JsonConstructorAttribute]
        protected PhonePropertiesAssaAbloyCredentialServiceMetadataEndpoints() { }

        public PhonePropertiesAssaAbloyCredentialServiceMetadataEndpoints(
            string endpointId = default,
            bool isActive = default
        )
        {
            EndpointId = endpointId;
            IsActive = isActive;
        }

        [DataMember(Name = "endpoint_id", IsRequired = true, EmitDefaultValue = false)]
        public string EndpointId { get; set; }

        [DataMember(Name = "is_active", IsRequired = true, EmitDefaultValue = false)]
        public bool IsActive { get; set; }

        public override string ToString()
        {
            JsonSerializer jsonSerializer = JsonSerializer.CreateDefault(null);

            StringWriter stringWriter = new StringWriter(
                new StringBuilder(256),
                System.Globalization.CultureInfo.InvariantCulture
            );
            using (JsonTextWriter jsonTextWriter = new JsonTextWriter(stringWriter))
            {
                jsonTextWriter.IndentChar = ' ';
                jsonTextWriter.Indentation = 2;
                jsonTextWriter.Formatting = Formatting.Indented;
                jsonSerializer.Serialize(jsonTextWriter, this, null);
            }

            return stringWriter.ToString();
        }
    }

    [DataContract(Name = "seamModel_phonePropertiesSaltoSpaceCredentialServiceMetadata_model")]
    public class PhonePropertiesSaltoSpaceCredentialServiceMetadata
    {
        [JsonConstructorAttribute]
        protected PhonePropertiesSaltoSpaceCredentialServiceMetadata() { }

        public PhonePropertiesSaltoSpaceCredentialServiceMetadata(bool hasActivePhone = default)
        {
            HasActivePhone = hasActivePhone;
        }

        [DataMember(Name = "has_active_phone", IsRequired = true, EmitDefaultValue = false)]
        public bool HasActivePhone { get; set; }

        public override string ToString()
        {
            JsonSerializer jsonSerializer = JsonSerializer.CreateDefault(null);

            StringWriter stringWriter = new StringWriter(
                new StringBuilder(256),
                System.Globalization.CultureInfo.InvariantCulture
            );
            using (JsonTextWriter jsonTextWriter = new JsonTextWriter(stringWriter))
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
