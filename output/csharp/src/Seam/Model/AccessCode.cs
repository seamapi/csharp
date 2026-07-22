using System.Runtime.Serialization;
using System.Text;
using JsonSubTypes;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using Seam.Model;

namespace Seam.Model
{
    [DataContract(Name = "seamModel_accessCode_model")]
    public class AccessCode
    {
        [JsonConstructorAttribute]
        protected AccessCode() { }

        public AccessCode(
            string accessCodeId = default,
            string? code = default,
            string? commonCodeKey = default,
            string createdAt = default,
            string deviceId = default,
            AccessCodeDormakabaOracodeMetadata? dormakabaOracodeMetadata = default,
            string? endsAt = default,
            List<AccessCodeErrors> errors = default,
            bool? isBackup = default,
            bool isBackupAccessCodeAvailable = default,
            bool isExternalModificationAllowed = default,
            bool isManaged = default,
            bool isOfflineAccessCode = default,
            bool isOneTimeUse = default,
            bool? isScheduledOnDevice = default,
            bool? isWaitingForCodeAssignment = default,
            string? name = default,
            List<AccessCodePendingMutations> pendingMutations = default,
            string? pulledBackupAccessCodeId = default,
            string? startsAt = default,
            AccessCode.StatusEnum status = default,
            AccessCode.TypeEnum type = default,
            List<AccessCodeWarnings> warnings = default,
            string workspaceId = default
        )
        {
            AccessCodeId = accessCodeId;
            Code = code;
            CommonCodeKey = commonCodeKey;
            CreatedAt = createdAt;
            DeviceId = deviceId;
            DormakabaOracodeMetadata = dormakabaOracodeMetadata;
            EndsAt = endsAt;
            Errors = errors;
            IsBackup = isBackup;
            IsBackupAccessCodeAvailable = isBackupAccessCodeAvailable;
            IsExternalModificationAllowed = isExternalModificationAllowed;
            IsManaged = isManaged;
            IsOfflineAccessCode = isOfflineAccessCode;
            IsOneTimeUse = isOneTimeUse;
            IsScheduledOnDevice = isScheduledOnDevice;
            IsWaitingForCodeAssignment = isWaitingForCodeAssignment;
            Name = name;
            PendingMutations = pendingMutations;
            PulledBackupAccessCodeId = pulledBackupAccessCodeId;
            StartsAt = startsAt;
            Status = status;
            Type = type;
            Warnings = warnings;
            WorkspaceId = workspaceId;
        }

        [JsonConverter(typeof(JsonSubtypes), "error_code")]
        [JsonSubtypes.FallBackSubType(typeof(AccessCodeErrorsUnrecognized))]
        [JsonSubtypes.KnownSubType(
            typeof(AccessCodeErrorsBridgeDisconnected),
            "bridge_disconnected"
        )]
        [JsonSubtypes.KnownSubType(
            typeof(AccessCodeErrorsSubscriptionRequired),
            "subscription_required"
        )]
        [JsonSubtypes.KnownSubType(
            typeof(AccessCodeErrorsAuxiliaryHeatRunning),
            "auxiliary_heat_running"
        )]
        [JsonSubtypes.KnownSubType(
            typeof(AccessCodeErrorsMissingDeviceCredentials),
            "missing_device_credentials"
        )]
        [JsonSubtypes.KnownSubType(
            typeof(AccessCodeErrorsAugustLockNotAuthorized),
            "august_lock_not_authorized"
        )]
        [JsonSubtypes.KnownSubType(
            typeof(AccessCodeErrorsEmptyBackupAccessCodePool),
            "empty_backup_access_code_pool"
        )]
        [JsonSubtypes.KnownSubType(
            typeof(AccessCodeErrorsDeviceDisconnected),
            "device_disconnected"
        )]
        [JsonSubtypes.KnownSubType(typeof(AccessCodeErrorsHubDisconnected), "hub_disconnected")]
        [JsonSubtypes.KnownSubType(typeof(AccessCodeErrorsDeviceRemoved), "device_removed")]
        [JsonSubtypes.KnownSubType(typeof(AccessCodeErrorsDeviceOffline), "device_offline")]
        [JsonSubtypes.KnownSubType(
            typeof(AccessCodeErrorsDormakabaSitesDisconnected),
            "dormakaba_sites_disconnected"
        )]
        [JsonSubtypes.KnownSubType(
            typeof(AccessCodeErrorsSaltoKsSubscriptionLimitExceeded),
            "salto_ks_subscription_limit_exceeded"
        )]
        [JsonSubtypes.KnownSubType(
            typeof(AccessCodeErrorsAccountDisconnected),
            "account_disconnected"
        )]
        [JsonSubtypes.KnownSubType(
            typeof(AccessCodeErrorsInsufficientPermissions),
            "insufficient_permissions"
        )]
        [JsonSubtypes.KnownSubType(
            typeof(AccessCodeErrorsAccessCodeInactive),
            "access_code_inactive"
        )]
        [JsonSubtypes.KnownSubType(
            typeof(AccessCodeErrorsConflictingExternalModification),
            "conflicting_external_modification"
        )]
        [JsonSubtypes.KnownSubType(
            typeof(AccessCodeErrorsNoSpaceForAccessCodeOnDevice),
            "no_space_for_access_code_on_device"
        )]
        [JsonSubtypes.KnownSubType(
            typeof(AccessCodeErrorsDuplicateCodeOnDevice),
            "duplicate_code_on_device"
        )]
        [JsonSubtypes.KnownSubType(
            typeof(AccessCodeErrorsFailedToRemoveFromDevice),
            "failed_to_remove_from_device"
        )]
        [JsonSubtypes.KnownSubType(
            typeof(AccessCodeErrorsFailedToSetOnDevice),
            "failed_to_set_on_device"
        )]
        [JsonSubtypes.KnownSubType(typeof(AccessCodeErrorsProviderIssue), "provider_issue")]
        public abstract class AccessCodeErrors
        {
            public abstract string ErrorCode { get; }

            public abstract string Message { get; set; }

            public abstract override string ToString();
        }

        [DataContract(Name = "seamModel_accessCodeErrorsProviderIssue_model")]
        public class AccessCodeErrorsProviderIssue : AccessCodeErrors
        {
            [JsonConstructorAttribute]
            protected AccessCodeErrorsProviderIssue() { }

            public AccessCodeErrorsProviderIssue(
                string? createdAt = default,
                string errorCode = default,
                bool isAccessCodeError = default,
                string message = default
            )
            {
                CreatedAt = createdAt;
                ErrorCode = errorCode;
                IsAccessCodeError = isAccessCodeError;
                Message = message;
            }

            [DataMember(Name = "created_at", IsRequired = false, EmitDefaultValue = false)]
            public string? CreatedAt { get; set; }

            [DataMember(Name = "error_code", IsRequired = true, EmitDefaultValue = false)]
            public override string ErrorCode { get; } = "provider_issue";

            [DataMember(Name = "is_access_code_error", IsRequired = true, EmitDefaultValue = false)]
            public bool IsAccessCodeError { get; set; }

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

        [DataContract(Name = "seamModel_accessCodeErrorsFailedToSetOnDevice_model")]
        public class AccessCodeErrorsFailedToSetOnDevice : AccessCodeErrors
        {
            [JsonConstructorAttribute]
            protected AccessCodeErrorsFailedToSetOnDevice() { }

            public AccessCodeErrorsFailedToSetOnDevice(
                string? createdAt = default,
                string errorCode = default,
                bool isAccessCodeError = default,
                string message = default
            )
            {
                CreatedAt = createdAt;
                ErrorCode = errorCode;
                IsAccessCodeError = isAccessCodeError;
                Message = message;
            }

            [DataMember(Name = "created_at", IsRequired = false, EmitDefaultValue = false)]
            public string? CreatedAt { get; set; }

            [DataMember(Name = "error_code", IsRequired = true, EmitDefaultValue = false)]
            public override string ErrorCode { get; } = "failed_to_set_on_device";

            [DataMember(Name = "is_access_code_error", IsRequired = true, EmitDefaultValue = false)]
            public bool IsAccessCodeError { get; set; }

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

        [DataContract(Name = "seamModel_accessCodeErrorsFailedToRemoveFromDevice_model")]
        public class AccessCodeErrorsFailedToRemoveFromDevice : AccessCodeErrors
        {
            [JsonConstructorAttribute]
            protected AccessCodeErrorsFailedToRemoveFromDevice() { }

            public AccessCodeErrorsFailedToRemoveFromDevice(
                string? createdAt = default,
                string errorCode = default,
                bool isAccessCodeError = default,
                string message = default
            )
            {
                CreatedAt = createdAt;
                ErrorCode = errorCode;
                IsAccessCodeError = isAccessCodeError;
                Message = message;
            }

            [DataMember(Name = "created_at", IsRequired = false, EmitDefaultValue = false)]
            public string? CreatedAt { get; set; }

            [DataMember(Name = "error_code", IsRequired = true, EmitDefaultValue = false)]
            public override string ErrorCode { get; } = "failed_to_remove_from_device";

            [DataMember(Name = "is_access_code_error", IsRequired = true, EmitDefaultValue = false)]
            public bool IsAccessCodeError { get; set; }

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

        [DataContract(Name = "seamModel_accessCodeErrorsDuplicateCodeOnDevice_model")]
        public class AccessCodeErrorsDuplicateCodeOnDevice : AccessCodeErrors
        {
            [JsonConstructorAttribute]
            protected AccessCodeErrorsDuplicateCodeOnDevice() { }

            public AccessCodeErrorsDuplicateCodeOnDevice(
                string? createdAt = default,
                string errorCode = default,
                bool isAccessCodeError = default,
                string? managedAccessCodeId = default,
                string message = default,
                string? unmanagedAccessCodeId = default
            )
            {
                CreatedAt = createdAt;
                ErrorCode = errorCode;
                IsAccessCodeError = isAccessCodeError;
                ManagedAccessCodeId = managedAccessCodeId;
                Message = message;
                UnmanagedAccessCodeId = unmanagedAccessCodeId;
            }

            [DataMember(Name = "created_at", IsRequired = false, EmitDefaultValue = false)]
            public string? CreatedAt { get; set; }

            [DataMember(Name = "error_code", IsRequired = true, EmitDefaultValue = false)]
            public override string ErrorCode { get; } = "duplicate_code_on_device";

            [DataMember(Name = "is_access_code_error", IsRequired = true, EmitDefaultValue = false)]
            public bool IsAccessCodeError { get; set; }

            [DataMember(
                Name = "managed_access_code_id",
                IsRequired = false,
                EmitDefaultValue = false
            )]
            public string? ManagedAccessCodeId { get; set; }

            [DataMember(Name = "message", IsRequired = true, EmitDefaultValue = false)]
            public override string Message { get; set; }

            [DataMember(
                Name = "unmanaged_access_code_id",
                IsRequired = false,
                EmitDefaultValue = false
            )]
            public string? UnmanagedAccessCodeId { get; set; }

            public override string ToString()
            {
                JsonSerializer jsonSerializer = JsonSerializer.CreateDefault(null);

                StringWriter stringWriter = new StringWriter(
                    new StringBuilder(256),
                    System.Globalization.CultureInfo.InvariantCulture
                );
                using (JsonTextWriter jsonTextWriter = new JsonTextWriter(stringWriter))
                {
                    jsonTextWriter.IndentChar = ' ';
                    jsonTextWriter.Indentation = 2;
                    jsonTextWriter.Formatting = Formatting.Indented;
                    jsonSerializer.Serialize(jsonTextWriter, this, null);
                }

                return stringWriter.ToString();
            }
        }

        [DataContract(Name = "seamModel_accessCodeErrorsNoSpaceForAccessCodeOnDevice_model")]
        public class AccessCodeErrorsNoSpaceForAccessCodeOnDevice : AccessCodeErrors
        {
            [JsonConstructorAttribute]
            protected AccessCodeErrorsNoSpaceForAccessCodeOnDevice() { }

            public AccessCodeErrorsNoSpaceForAccessCodeOnDevice(
                string? createdAt = default,
                string errorCode = default,
                bool isAccessCodeError = default,
                string message = default
            )
            {
                CreatedAt = createdAt;
                ErrorCode = errorCode;
                IsAccessCodeError = isAccessCodeError;
                Message = message;
            }

            [DataMember(Name = "created_at", IsRequired = false, EmitDefaultValue = false)]
            public string? CreatedAt { get; set; }

            [DataMember(Name = "error_code", IsRequired = true, EmitDefaultValue = false)]
            public override string ErrorCode { get; } = "no_space_for_access_code_on_device";

            [DataMember(Name = "is_access_code_error", IsRequired = true, EmitDefaultValue = false)]
            public bool IsAccessCodeError { get; set; }

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

        [DataContract(Name = "seamModel_accessCodeErrorsConflictingExternalModification_model")]
        public class AccessCodeErrorsConflictingExternalModification : AccessCodeErrors
        {
            [JsonConstructorAttribute]
            protected AccessCodeErrorsConflictingExternalModification() { }

            public AccessCodeErrorsConflictingExternalModification(
                AccessCodeErrorsConflictingExternalModification.ChangeTypeEnum? changeType =
                    default,
                string? createdAt = default,
                string errorCode = default,
                bool isAccessCodeError = default,
                string message = default,
                List<AccessCodeErrorsConflictingExternalModificationModifiedFields>? modifiedFields =
                    default
            )
            {
                ChangeType = changeType;
                CreatedAt = createdAt;
                ErrorCode = errorCode;
                IsAccessCodeError = isAccessCodeError;
                Message = message;
                ModifiedFields = modifiedFields;
            }

            [JsonConverter(typeof(SafeStringEnumConverter))]
            public enum ChangeTypeEnum
            {
                [EnumMember(Value = "unrecognized")]
                Unrecognized = 0,

                [EnumMember(Value = "modified")]
                Modified = 1,

                [EnumMember(Value = "removed")]
                Removed = 2,
            }

            [DataMember(Name = "change_type", IsRequired = false, EmitDefaultValue = false)]
            public AccessCodeErrorsConflictingExternalModification.ChangeTypeEnum? ChangeType { get; set; }

            [DataMember(Name = "created_at", IsRequired = false, EmitDefaultValue = false)]
            public string? CreatedAt { get; set; }

            [DataMember(Name = "error_code", IsRequired = true, EmitDefaultValue = false)]
            public override string ErrorCode { get; } = "conflicting_external_modification";

            [DataMember(Name = "is_access_code_error", IsRequired = true, EmitDefaultValue = false)]
            public bool IsAccessCodeError { get; set; }

            [DataMember(Name = "message", IsRequired = true, EmitDefaultValue = false)]
            public override string Message { get; set; }

            [DataMember(Name = "modified_fields", IsRequired = false, EmitDefaultValue = false)]
            public List<AccessCodeErrorsConflictingExternalModificationModifiedFields>? ModifiedFields { get; set; }

            public override string ToString()
            {
                JsonSerializer jsonSerializer = JsonSerializer.CreateDefault(null);

                StringWriter stringWriter = new StringWriter(
                    new StringBuilder(256),
                    System.Globalization.CultureInfo.InvariantCulture
                );
                using (JsonTextWriter jsonTextWriter = new JsonTextWriter(stringWriter))
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
            Name = "seamModel_accessCodeErrorsConflictingExternalModificationModifiedFields_model"
        )]
        public class AccessCodeErrorsConflictingExternalModificationModifiedFields
        {
            [JsonConstructorAttribute]
            protected AccessCodeErrorsConflictingExternalModificationModifiedFields() { }

            public AccessCodeErrorsConflictingExternalModificationModifiedFields(
                string field = default,
                string? from = default,
                string? to = default
            )
            {
                Field = field;
                From = from;
                To = to;
            }

            [DataMember(Name = "field", IsRequired = true, EmitDefaultValue = false)]
            public string Field { get; set; }

            [DataMember(Name = "from", IsRequired = false, EmitDefaultValue = false)]
            public string? From { get; set; }

            [DataMember(Name = "to", IsRequired = false, EmitDefaultValue = false)]
            public string? To { get; set; }

            public override string ToString()
            {
                JsonSerializer jsonSerializer = JsonSerializer.CreateDefault(null);

                StringWriter stringWriter = new StringWriter(
                    new StringBuilder(256),
                    System.Globalization.CultureInfo.InvariantCulture
                );
                using (JsonTextWriter jsonTextWriter = new JsonTextWriter(stringWriter))
                {
                    jsonTextWriter.IndentChar = ' ';
                    jsonTextWriter.Indentation = 2;
                    jsonTextWriter.Formatting = Formatting.Indented;
                    jsonSerializer.Serialize(jsonTextWriter, this, null);
                }

                return stringWriter.ToString();
            }
        }

        [DataContract(Name = "seamModel_accessCodeErrorsAccessCodeInactive_model")]
        public class AccessCodeErrorsAccessCodeInactive : AccessCodeErrors
        {
            [JsonConstructorAttribute]
            protected AccessCodeErrorsAccessCodeInactive() { }

            public AccessCodeErrorsAccessCodeInactive(
                string? createdAt = default,
                string errorCode = default,
                bool isAccessCodeError = default,
                string message = default
            )
            {
                CreatedAt = createdAt;
                ErrorCode = errorCode;
                IsAccessCodeError = isAccessCodeError;
                Message = message;
            }

            [DataMember(Name = "created_at", IsRequired = false, EmitDefaultValue = false)]
            public string? CreatedAt { get; set; }

            [DataMember(Name = "error_code", IsRequired = true, EmitDefaultValue = false)]
            public override string ErrorCode { get; } = "access_code_inactive";

            [DataMember(Name = "is_access_code_error", IsRequired = true, EmitDefaultValue = false)]
            public bool IsAccessCodeError { get; set; }

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

        [DataContract(Name = "seamModel_accessCodeErrorsInsufficientPermissions_model")]
        public class AccessCodeErrorsInsufficientPermissions : AccessCodeErrors
        {
            [JsonConstructorAttribute]
            protected AccessCodeErrorsInsufficientPermissions() { }

            public AccessCodeErrorsInsufficientPermissions(
                string? createdAt = default,
                string errorCode = default,
                bool isAccessCodeError = default,
                string message = default
            )
            {
                CreatedAt = createdAt;
                ErrorCode = errorCode;
                IsAccessCodeError = isAccessCodeError;
                Message = message;
            }

            [DataMember(Name = "created_at", IsRequired = false, EmitDefaultValue = false)]
            public string? CreatedAt { get; set; }

            [DataMember(Name = "error_code", IsRequired = true, EmitDefaultValue = false)]
            public override string ErrorCode { get; } = "insufficient_permissions";

            [DataMember(Name = "is_access_code_error", IsRequired = true, EmitDefaultValue = false)]
            public bool IsAccessCodeError { get; set; }

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

        [DataContract(Name = "seamModel_accessCodeErrorsAccountDisconnected_model")]
        public class AccessCodeErrorsAccountDisconnected : AccessCodeErrors
        {
            [JsonConstructorAttribute]
            protected AccessCodeErrorsAccountDisconnected() { }

            public AccessCodeErrorsAccountDisconnected(
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
            public string CreatedAt { get; set; }

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

        [DataContract(Name = "seamModel_accessCodeErrorsSaltoKsSubscriptionLimitExceeded_model")]
        public class AccessCodeErrorsSaltoKsSubscriptionLimitExceeded : AccessCodeErrors
        {
            [JsonConstructorAttribute]
            protected AccessCodeErrorsSaltoKsSubscriptionLimitExceeded() { }

            public AccessCodeErrorsSaltoKsSubscriptionLimitExceeded(
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
            public string CreatedAt { get; set; }

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

        [DataContract(Name = "seamModel_accessCodeErrorsDormakabaSitesDisconnected_model")]
        public class AccessCodeErrorsDormakabaSitesDisconnected : AccessCodeErrors
        {
            [JsonConstructorAttribute]
            protected AccessCodeErrorsDormakabaSitesDisconnected() { }

            public AccessCodeErrorsDormakabaSitesDisconnected(
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
            public string CreatedAt { get; set; }

            [DataMember(Name = "error_code", IsRequired = true, EmitDefaultValue = false)]
            public override string ErrorCode { get; } = "dormakaba_sites_disconnected";

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

        [DataContract(Name = "seamModel_accessCodeErrorsDeviceOffline_model")]
        public class AccessCodeErrorsDeviceOffline : AccessCodeErrors
        {
            [JsonConstructorAttribute]
            protected AccessCodeErrorsDeviceOffline() { }

            public AccessCodeErrorsDeviceOffline(
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
            public string CreatedAt { get; set; }

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

        [DataContract(Name = "seamModel_accessCodeErrorsDeviceRemoved_model")]
        public class AccessCodeErrorsDeviceRemoved : AccessCodeErrors
        {
            [JsonConstructorAttribute]
            protected AccessCodeErrorsDeviceRemoved() { }

            public AccessCodeErrorsDeviceRemoved(
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
            public string CreatedAt { get; set; }

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

        [DataContract(Name = "seamModel_accessCodeErrorsHubDisconnected_model")]
        public class AccessCodeErrorsHubDisconnected : AccessCodeErrors
        {
            [JsonConstructorAttribute]
            protected AccessCodeErrorsHubDisconnected() { }

            public AccessCodeErrorsHubDisconnected(
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
            public string CreatedAt { get; set; }

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

        [DataContract(Name = "seamModel_accessCodeErrorsDeviceDisconnected_model")]
        public class AccessCodeErrorsDeviceDisconnected : AccessCodeErrors
        {
            [JsonConstructorAttribute]
            protected AccessCodeErrorsDeviceDisconnected() { }

            public AccessCodeErrorsDeviceDisconnected(
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
            public string CreatedAt { get; set; }

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

        [DataContract(Name = "seamModel_accessCodeErrorsEmptyBackupAccessCodePool_model")]
        public class AccessCodeErrorsEmptyBackupAccessCodePool : AccessCodeErrors
        {
            [JsonConstructorAttribute]
            protected AccessCodeErrorsEmptyBackupAccessCodePool() { }

            public AccessCodeErrorsEmptyBackupAccessCodePool(
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
            public string CreatedAt { get; set; }

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

        [DataContract(Name = "seamModel_accessCodeErrorsAugustLockNotAuthorized_model")]
        public class AccessCodeErrorsAugustLockNotAuthorized : AccessCodeErrors
        {
            [JsonConstructorAttribute]
            protected AccessCodeErrorsAugustLockNotAuthorized() { }

            public AccessCodeErrorsAugustLockNotAuthorized(
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
            public string CreatedAt { get; set; }

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

        [DataContract(Name = "seamModel_accessCodeErrorsMissingDeviceCredentials_model")]
        public class AccessCodeErrorsMissingDeviceCredentials : AccessCodeErrors
        {
            [JsonConstructorAttribute]
            protected AccessCodeErrorsMissingDeviceCredentials() { }

            public AccessCodeErrorsMissingDeviceCredentials(
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
            public string CreatedAt { get; set; }

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

        [DataContract(Name = "seamModel_accessCodeErrorsAuxiliaryHeatRunning_model")]
        public class AccessCodeErrorsAuxiliaryHeatRunning : AccessCodeErrors
        {
            [JsonConstructorAttribute]
            protected AccessCodeErrorsAuxiliaryHeatRunning() { }

            public AccessCodeErrorsAuxiliaryHeatRunning(
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
            public string CreatedAt { get; set; }

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

        [DataContract(Name = "seamModel_accessCodeErrorsSubscriptionRequired_model")]
        public class AccessCodeErrorsSubscriptionRequired : AccessCodeErrors
        {
            [JsonConstructorAttribute]
            protected AccessCodeErrorsSubscriptionRequired() { }

            public AccessCodeErrorsSubscriptionRequired(
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
            public string CreatedAt { get; set; }

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

        [DataContract(Name = "seamModel_accessCodeErrorsBridgeDisconnected_model")]
        public class AccessCodeErrorsBridgeDisconnected : AccessCodeErrors
        {
            [JsonConstructorAttribute]
            protected AccessCodeErrorsBridgeDisconnected() { }

            public AccessCodeErrorsBridgeDisconnected(
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
            public string CreatedAt { get; set; }

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

        [DataContract(Name = "seamModel_accessCodeErrorsUnrecognized_model")]
        public class AccessCodeErrorsUnrecognized : AccessCodeErrors
        {
            [JsonConstructorAttribute]
            protected AccessCodeErrorsUnrecognized() { }

            public AccessCodeErrorsUnrecognized(
                string errorCode = default,
                string message = default
            )
            {
                ErrorCode = errorCode;
                Message = message;
            }

            [DataMember(Name = "error_code", IsRequired = true, EmitDefaultValue = false)]
            public override string ErrorCode { get; } = "unrecognized";

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

        [JsonConverter(typeof(JsonSubtypes), "mutation_code")]
        [JsonSubtypes.FallBackSubType(typeof(AccessCodePendingMutationsUnrecognized))]
        [JsonSubtypes.KnownSubType(
            typeof(AccessCodePendingMutationsUpdatingTimeFrame),
            "updating_time_frame"
        )]
        [JsonSubtypes.KnownSubType(typeof(AccessCodePendingMutationsUpdatingName), "updating_name")]
        [JsonSubtypes.KnownSubType(typeof(AccessCodePendingMutationsUpdatingCode), "updating_code")]
        [JsonSubtypes.KnownSubType(typeof(AccessCodePendingMutationsDeleting), "deleting")]
        [JsonSubtypes.KnownSubType(
            typeof(AccessCodePendingMutationsDeferringCreation),
            "deferring_creation"
        )]
        [JsonSubtypes.KnownSubType(typeof(AccessCodePendingMutationsCreating), "creating")]
        public abstract class AccessCodePendingMutations
        {
            public abstract string MutationCode { get; }

            public abstract override string ToString();
        }

        [DataContract(Name = "seamModel_accessCodePendingMutationsCreating_model")]
        public class AccessCodePendingMutationsCreating : AccessCodePendingMutations
        {
            [JsonConstructorAttribute]
            protected AccessCodePendingMutationsCreating() { }

            public AccessCodePendingMutationsCreating(
                string createdAt = default,
                string message = default,
                string mutationCode = default
            )
            {
                CreatedAt = createdAt;
                Message = message;
                MutationCode = mutationCode;
            }

            [DataMember(Name = "created_at", IsRequired = true, EmitDefaultValue = false)]
            public string CreatedAt { get; set; }

            [DataMember(Name = "message", IsRequired = true, EmitDefaultValue = false)]
            public string Message { get; set; }

            [DataMember(Name = "mutation_code", IsRequired = true, EmitDefaultValue = false)]
            public override string MutationCode { get; } = "creating";

            public override string ToString()
            {
                JsonSerializer jsonSerializer = JsonSerializer.CreateDefault(null);

                StringWriter stringWriter = new StringWriter(
                    new StringBuilder(256),
                    System.Globalization.CultureInfo.InvariantCulture
                );
                using (JsonTextWriter jsonTextWriter = new JsonTextWriter(stringWriter))
                {
                    jsonTextWriter.IndentChar = ' ';
                    jsonTextWriter.Indentation = 2;
                    jsonTextWriter.Formatting = Formatting.Indented;
                    jsonSerializer.Serialize(jsonTextWriter, this, null);
                }

                return stringWriter.ToString();
            }
        }

        [DataContract(Name = "seamModel_accessCodePendingMutationsDeferringCreation_model")]
        public class AccessCodePendingMutationsDeferringCreation : AccessCodePendingMutations
        {
            [JsonConstructorAttribute]
            protected AccessCodePendingMutationsDeferringCreation() { }

            public AccessCodePendingMutationsDeferringCreation(
                string createdAt = default,
                string message = default,
                string mutationCode = default,
                string scheduledAt = default
            )
            {
                CreatedAt = createdAt;
                Message = message;
                MutationCode = mutationCode;
                ScheduledAt = scheduledAt;
            }

            [DataMember(Name = "created_at", IsRequired = true, EmitDefaultValue = false)]
            public string CreatedAt { get; set; }

            [DataMember(Name = "message", IsRequired = true, EmitDefaultValue = false)]
            public string Message { get; set; }

            [DataMember(Name = "mutation_code", IsRequired = true, EmitDefaultValue = false)]
            public override string MutationCode { get; } = "deferring_creation";

            [DataMember(Name = "scheduled_at", IsRequired = true, EmitDefaultValue = false)]
            public string ScheduledAt { get; set; }

            public override string ToString()
            {
                JsonSerializer jsonSerializer = JsonSerializer.CreateDefault(null);

                StringWriter stringWriter = new StringWriter(
                    new StringBuilder(256),
                    System.Globalization.CultureInfo.InvariantCulture
                );
                using (JsonTextWriter jsonTextWriter = new JsonTextWriter(stringWriter))
                {
                    jsonTextWriter.IndentChar = ' ';
                    jsonTextWriter.Indentation = 2;
                    jsonTextWriter.Formatting = Formatting.Indented;
                    jsonSerializer.Serialize(jsonTextWriter, this, null);
                }

                return stringWriter.ToString();
            }
        }

        [DataContract(Name = "seamModel_accessCodePendingMutationsDeleting_model")]
        public class AccessCodePendingMutationsDeleting : AccessCodePendingMutations
        {
            [JsonConstructorAttribute]
            protected AccessCodePendingMutationsDeleting() { }

            public AccessCodePendingMutationsDeleting(
                string createdAt = default,
                string message = default,
                string mutationCode = default
            )
            {
                CreatedAt = createdAt;
                Message = message;
                MutationCode = mutationCode;
            }

            [DataMember(Name = "created_at", IsRequired = true, EmitDefaultValue = false)]
            public string CreatedAt { get; set; }

            [DataMember(Name = "message", IsRequired = true, EmitDefaultValue = false)]
            public string Message { get; set; }

            [DataMember(Name = "mutation_code", IsRequired = true, EmitDefaultValue = false)]
            public override string MutationCode { get; } = "deleting";

            public override string ToString()
            {
                JsonSerializer jsonSerializer = JsonSerializer.CreateDefault(null);

                StringWriter stringWriter = new StringWriter(
                    new StringBuilder(256),
                    System.Globalization.CultureInfo.InvariantCulture
                );
                using (JsonTextWriter jsonTextWriter = new JsonTextWriter(stringWriter))
                {
                    jsonTextWriter.IndentChar = ' ';
                    jsonTextWriter.Indentation = 2;
                    jsonTextWriter.Formatting = Formatting.Indented;
                    jsonSerializer.Serialize(jsonTextWriter, this, null);
                }

                return stringWriter.ToString();
            }
        }

        [DataContract(Name = "seamModel_accessCodePendingMutationsUpdatingCode_model")]
        public class AccessCodePendingMutationsUpdatingCode : AccessCodePendingMutations
        {
            [JsonConstructorAttribute]
            protected AccessCodePendingMutationsUpdatingCode() { }

            public AccessCodePendingMutationsUpdatingCode(
                string createdAt = default,
                AccessCodePendingMutationsUpdatingCodeFrom from = default,
                string message = default,
                string mutationCode = default,
                AccessCodePendingMutationsUpdatingCodeTo to = default
            )
            {
                CreatedAt = createdAt;
                From = from;
                Message = message;
                MutationCode = mutationCode;
                To = to;
            }

            [DataMember(Name = "created_at", IsRequired = true, EmitDefaultValue = false)]
            public string CreatedAt { get; set; }

            [DataMember(Name = "from", IsRequired = true, EmitDefaultValue = false)]
            public AccessCodePendingMutationsUpdatingCodeFrom From { get; set; }

            [DataMember(Name = "message", IsRequired = true, EmitDefaultValue = false)]
            public string Message { get; set; }

            [DataMember(Name = "mutation_code", IsRequired = true, EmitDefaultValue = false)]
            public override string MutationCode { get; } = "updating_code";

            [DataMember(Name = "to", IsRequired = true, EmitDefaultValue = false)]
            public AccessCodePendingMutationsUpdatingCodeTo To { get; set; }

            public override string ToString()
            {
                JsonSerializer jsonSerializer = JsonSerializer.CreateDefault(null);

                StringWriter stringWriter = new StringWriter(
                    new StringBuilder(256),
                    System.Globalization.CultureInfo.InvariantCulture
                );
                using (JsonTextWriter jsonTextWriter = new JsonTextWriter(stringWriter))
                {
                    jsonTextWriter.IndentChar = ' ';
                    jsonTextWriter.Indentation = 2;
                    jsonTextWriter.Formatting = Formatting.Indented;
                    jsonSerializer.Serialize(jsonTextWriter, this, null);
                }

                return stringWriter.ToString();
            }
        }

        [DataContract(Name = "seamModel_accessCodePendingMutationsUpdatingCodeFrom_model")]
        public class AccessCodePendingMutationsUpdatingCodeFrom
        {
            [JsonConstructorAttribute]
            protected AccessCodePendingMutationsUpdatingCodeFrom() { }

            public AccessCodePendingMutationsUpdatingCodeFrom(string? code = default)
            {
                Code = code;
            }

            [DataMember(Name = "code", IsRequired = false, EmitDefaultValue = false)]
            public string? Code { get; set; }

            public override string ToString()
            {
                JsonSerializer jsonSerializer = JsonSerializer.CreateDefault(null);

                StringWriter stringWriter = new StringWriter(
                    new StringBuilder(256),
                    System.Globalization.CultureInfo.InvariantCulture
                );
                using (JsonTextWriter jsonTextWriter = new JsonTextWriter(stringWriter))
                {
                    jsonTextWriter.IndentChar = ' ';
                    jsonTextWriter.Indentation = 2;
                    jsonTextWriter.Formatting = Formatting.Indented;
                    jsonSerializer.Serialize(jsonTextWriter, this, null);
                }

                return stringWriter.ToString();
            }
        }

        [DataContract(Name = "seamModel_accessCodePendingMutationsUpdatingCodeTo_model")]
        public class AccessCodePendingMutationsUpdatingCodeTo
        {
            [JsonConstructorAttribute]
            protected AccessCodePendingMutationsUpdatingCodeTo() { }

            public AccessCodePendingMutationsUpdatingCodeTo(string? code = default)
            {
                Code = code;
            }

            [DataMember(Name = "code", IsRequired = false, EmitDefaultValue = false)]
            public string? Code { get; set; }

            public override string ToString()
            {
                JsonSerializer jsonSerializer = JsonSerializer.CreateDefault(null);

                StringWriter stringWriter = new StringWriter(
                    new StringBuilder(256),
                    System.Globalization.CultureInfo.InvariantCulture
                );
                using (JsonTextWriter jsonTextWriter = new JsonTextWriter(stringWriter))
                {
                    jsonTextWriter.IndentChar = ' ';
                    jsonTextWriter.Indentation = 2;
                    jsonTextWriter.Formatting = Formatting.Indented;
                    jsonSerializer.Serialize(jsonTextWriter, this, null);
                }

                return stringWriter.ToString();
            }
        }

        [DataContract(Name = "seamModel_accessCodePendingMutationsUpdatingName_model")]
        public class AccessCodePendingMutationsUpdatingName : AccessCodePendingMutations
        {
            [JsonConstructorAttribute]
            protected AccessCodePendingMutationsUpdatingName() { }

            public AccessCodePendingMutationsUpdatingName(
                string createdAt = default,
                AccessCodePendingMutationsUpdatingNameFrom from = default,
                string message = default,
                string mutationCode = default,
                AccessCodePendingMutationsUpdatingNameTo to = default
            )
            {
                CreatedAt = createdAt;
                From = from;
                Message = message;
                MutationCode = mutationCode;
                To = to;
            }

            [DataMember(Name = "created_at", IsRequired = true, EmitDefaultValue = false)]
            public string CreatedAt { get; set; }

            [DataMember(Name = "from", IsRequired = true, EmitDefaultValue = false)]
            public AccessCodePendingMutationsUpdatingNameFrom From { get; set; }

            [DataMember(Name = "message", IsRequired = true, EmitDefaultValue = false)]
            public string Message { get; set; }

            [DataMember(Name = "mutation_code", IsRequired = true, EmitDefaultValue = false)]
            public override string MutationCode { get; } = "updating_name";

            [DataMember(Name = "to", IsRequired = true, EmitDefaultValue = false)]
            public AccessCodePendingMutationsUpdatingNameTo To { get; set; }

            public override string ToString()
            {
                JsonSerializer jsonSerializer = JsonSerializer.CreateDefault(null);

                StringWriter stringWriter = new StringWriter(
                    new StringBuilder(256),
                    System.Globalization.CultureInfo.InvariantCulture
                );
                using (JsonTextWriter jsonTextWriter = new JsonTextWriter(stringWriter))
                {
                    jsonTextWriter.IndentChar = ' ';
                    jsonTextWriter.Indentation = 2;
                    jsonTextWriter.Formatting = Formatting.Indented;
                    jsonSerializer.Serialize(jsonTextWriter, this, null);
                }

                return stringWriter.ToString();
            }
        }

        [DataContract(Name = "seamModel_accessCodePendingMutationsUpdatingNameFrom_model")]
        public class AccessCodePendingMutationsUpdatingNameFrom
        {
            [JsonConstructorAttribute]
            protected AccessCodePendingMutationsUpdatingNameFrom() { }

            public AccessCodePendingMutationsUpdatingNameFrom(string? name = default)
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

        [DataContract(Name = "seamModel_accessCodePendingMutationsUpdatingNameTo_model")]
        public class AccessCodePendingMutationsUpdatingNameTo
        {
            [JsonConstructorAttribute]
            protected AccessCodePendingMutationsUpdatingNameTo() { }

            public AccessCodePendingMutationsUpdatingNameTo(string? name = default)
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

        [DataContract(Name = "seamModel_accessCodePendingMutationsUpdatingTimeFrame_model")]
        public class AccessCodePendingMutationsUpdatingTimeFrame : AccessCodePendingMutations
        {
            [JsonConstructorAttribute]
            protected AccessCodePendingMutationsUpdatingTimeFrame() { }

            public AccessCodePendingMutationsUpdatingTimeFrame(
                string createdAt = default,
                AccessCodePendingMutationsUpdatingTimeFrameFrom from = default,
                string message = default,
                string mutationCode = default,
                AccessCodePendingMutationsUpdatingTimeFrameTo to = default
            )
            {
                CreatedAt = createdAt;
                From = from;
                Message = message;
                MutationCode = mutationCode;
                To = to;
            }

            [DataMember(Name = "created_at", IsRequired = true, EmitDefaultValue = false)]
            public string CreatedAt { get; set; }

            [DataMember(Name = "from", IsRequired = true, EmitDefaultValue = false)]
            public AccessCodePendingMutationsUpdatingTimeFrameFrom From { get; set; }

            [DataMember(Name = "message", IsRequired = true, EmitDefaultValue = false)]
            public string Message { get; set; }

            [DataMember(Name = "mutation_code", IsRequired = true, EmitDefaultValue = false)]
            public override string MutationCode { get; } = "updating_time_frame";

            [DataMember(Name = "to", IsRequired = true, EmitDefaultValue = false)]
            public AccessCodePendingMutationsUpdatingTimeFrameTo To { get; set; }

            public override string ToString()
            {
                JsonSerializer jsonSerializer = JsonSerializer.CreateDefault(null);

                StringWriter stringWriter = new StringWriter(
                    new StringBuilder(256),
                    System.Globalization.CultureInfo.InvariantCulture
                );
                using (JsonTextWriter jsonTextWriter = new JsonTextWriter(stringWriter))
                {
                    jsonTextWriter.IndentChar = ' ';
                    jsonTextWriter.Indentation = 2;
                    jsonTextWriter.Formatting = Formatting.Indented;
                    jsonSerializer.Serialize(jsonTextWriter, this, null);
                }

                return stringWriter.ToString();
            }
        }

        [DataContract(Name = "seamModel_accessCodePendingMutationsUpdatingTimeFrameFrom_model")]
        public class AccessCodePendingMutationsUpdatingTimeFrameFrom
        {
            [JsonConstructorAttribute]
            protected AccessCodePendingMutationsUpdatingTimeFrameFrom() { }

            public AccessCodePendingMutationsUpdatingTimeFrameFrom(
                string? endsAt = default,
                string? startsAt = default
            )
            {
                EndsAt = endsAt;
                StartsAt = startsAt;
            }

            [DataMember(Name = "ends_at", IsRequired = false, EmitDefaultValue = false)]
            public string? EndsAt { get; set; }

            [DataMember(Name = "starts_at", IsRequired = false, EmitDefaultValue = false)]
            public string? StartsAt { get; set; }

            public override string ToString()
            {
                JsonSerializer jsonSerializer = JsonSerializer.CreateDefault(null);

                StringWriter stringWriter = new StringWriter(
                    new StringBuilder(256),
                    System.Globalization.CultureInfo.InvariantCulture
                );
                using (JsonTextWriter jsonTextWriter = new JsonTextWriter(stringWriter))
                {
                    jsonTextWriter.IndentChar = ' ';
                    jsonTextWriter.Indentation = 2;
                    jsonTextWriter.Formatting = Formatting.Indented;
                    jsonSerializer.Serialize(jsonTextWriter, this, null);
                }

                return stringWriter.ToString();
            }
        }

        [DataContract(Name = "seamModel_accessCodePendingMutationsUpdatingTimeFrameTo_model")]
        public class AccessCodePendingMutationsUpdatingTimeFrameTo
        {
            [JsonConstructorAttribute]
            protected AccessCodePendingMutationsUpdatingTimeFrameTo() { }

            public AccessCodePendingMutationsUpdatingTimeFrameTo(
                string? endsAt = default,
                string? startsAt = default
            )
            {
                EndsAt = endsAt;
                StartsAt = startsAt;
            }

            [DataMember(Name = "ends_at", IsRequired = false, EmitDefaultValue = false)]
            public string? EndsAt { get; set; }

            [DataMember(Name = "starts_at", IsRequired = false, EmitDefaultValue = false)]
            public string? StartsAt { get; set; }

            public override string ToString()
            {
                JsonSerializer jsonSerializer = JsonSerializer.CreateDefault(null);

                StringWriter stringWriter = new StringWriter(
                    new StringBuilder(256),
                    System.Globalization.CultureInfo.InvariantCulture
                );
                using (JsonTextWriter jsonTextWriter = new JsonTextWriter(stringWriter))
                {
                    jsonTextWriter.IndentChar = ' ';
                    jsonTextWriter.Indentation = 2;
                    jsonTextWriter.Formatting = Formatting.Indented;
                    jsonSerializer.Serialize(jsonTextWriter, this, null);
                }

                return stringWriter.ToString();
            }
        }

        [DataContract(Name = "seamModel_accessCodePendingMutationsUnrecognized_model")]
        public class AccessCodePendingMutationsUnrecognized : AccessCodePendingMutations
        {
            [JsonConstructorAttribute]
            protected AccessCodePendingMutationsUnrecognized() { }

            public AccessCodePendingMutationsUnrecognized(string mutationCode = default)
            {
                MutationCode = mutationCode;
            }

            [DataMember(Name = "mutation_code", IsRequired = true, EmitDefaultValue = false)]
            public override string MutationCode { get; } = "unrecognized";

            public override string ToString()
            {
                JsonSerializer jsonSerializer = JsonSerializer.CreateDefault(null);

                StringWriter stringWriter = new StringWriter(
                    new StringBuilder(256),
                    System.Globalization.CultureInfo.InvariantCulture
                );
                using (JsonTextWriter jsonTextWriter = new JsonTextWriter(stringWriter))
                {
                    jsonTextWriter.IndentChar = ' ';
                    jsonTextWriter.Indentation = 2;
                    jsonTextWriter.Formatting = Formatting.Indented;
                    jsonSerializer.Serialize(jsonTextWriter, this, null);
                }

                return stringWriter.ToString();
            }
        }

        [JsonConverter(typeof(SafeStringEnumConverter))]
        public enum StatusEnum
        {
            [EnumMember(Value = "unrecognized")]
            Unrecognized = 0,

            [EnumMember(Value = "setting")]
            Setting = 1,

            [EnumMember(Value = "set")]
            Set = 2,

            [EnumMember(Value = "unset")]
            Unset = 3,

            [EnumMember(Value = "removing")]
            Removing = 4,

            [EnumMember(Value = "unknown")]
            Unknown = 5,
        }

        [JsonConverter(typeof(SafeStringEnumConverter))]
        public enum TypeEnum
        {
            [EnumMember(Value = "unrecognized")]
            Unrecognized = 0,

            [EnumMember(Value = "time_bound")]
            TimeBound = 1,

            [EnumMember(Value = "ongoing")]
            Ongoing = 2,
        }

        [JsonConverter(typeof(JsonSubtypes), "warning_code")]
        [JsonSubtypes.FallBackSubType(typeof(AccessCodeWarningsUnrecognized))]
        [JsonSubtypes.KnownSubType(
            typeof(AccessCodeWarningsUnknownIssueWithAccessCode),
            "unknown_issue_with_access_code"
        )]
        [JsonSubtypes.KnownSubType(typeof(AccessCodeWarningsBeingDeleted), "being_deleted")]
        [JsonSubtypes.KnownSubType(
            typeof(AccessCodeWarningsUsingBackupAccessCode),
            "using_backup_access_code"
        )]
        [JsonSubtypes.KnownSubType(
            typeof(AccessCodeWarningsManagementTransferred),
            "management_transferred"
        )]
        [JsonSubtypes.KnownSubType(
            typeof(AccessCodeWarningsIglooAlgopinMustBeUsedWithin_24Hours),
            "igloo_algopin_must_be_used_within_24_hours"
        )]
        [JsonSubtypes.KnownSubType(
            typeof(AccessCodeWarningsThirdPartyIntegrationDetected),
            "third_party_integration_detected"
        )]
        [JsonSubtypes.KnownSubType(
            typeof(AccessCodeWarningsDelayInRemovingFromDevice),
            "delay_in_removing_from_device"
        )]
        [JsonSubtypes.KnownSubType(
            typeof(AccessCodeWarningsDelayInSettingOnDevice),
            "delay_in_setting_on_device"
        )]
        [JsonSubtypes.KnownSubType(
            typeof(AccessCodeWarningsExternalModificationInEffect),
            "external_modification_in_effect"
        )]
        [JsonSubtypes.KnownSubType(
            typeof(AccessCodeWarningsTimeFrameAdjustedForUnknownTimeZone),
            "time_frame_adjusted_for_unknown_time_zone"
        )]
        [JsonSubtypes.KnownSubType(
            typeof(AccessCodeWarningsCodeRotatesPeriodically),
            "code_rotates_periodically"
        )]
        public abstract class AccessCodeWarnings
        {
            public abstract string WarningCode { get; }

            public abstract string Message { get; set; }

            public abstract override string ToString();
        }

        [DataContract(Name = "seamModel_accessCodeWarningsCodeRotatesPeriodically_model")]
        public class AccessCodeWarningsCodeRotatesPeriodically : AccessCodeWarnings
        {
            [JsonConstructorAttribute]
            protected AccessCodeWarningsCodeRotatesPeriodically() { }

            public AccessCodeWarningsCodeRotatesPeriodically(
                string? createdAt = default,
                string message = default,
                string warningCode = default
            )
            {
                CreatedAt = createdAt;
                Message = message;
                WarningCode = warningCode;
            }

            [DataMember(Name = "created_at", IsRequired = false, EmitDefaultValue = false)]
            public string? CreatedAt { get; set; }

            [DataMember(Name = "message", IsRequired = true, EmitDefaultValue = false)]
            public override string Message { get; set; }

            [DataMember(Name = "warning_code", IsRequired = true, EmitDefaultValue = false)]
            public override string WarningCode { get; } = "code_rotates_periodically";

            public override string ToString()
            {
                JsonSerializer jsonSerializer = JsonSerializer.CreateDefault(null);

                StringWriter stringWriter = new StringWriter(
                    new StringBuilder(256),
                    System.Globalization.CultureInfo.InvariantCulture
                );
                using (JsonTextWriter jsonTextWriter = new JsonTextWriter(stringWriter))
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
            Name = "seamModel_accessCodeWarningsTimeFrameAdjustedForUnknownTimeZone_model"
        )]
        public class AccessCodeWarningsTimeFrameAdjustedForUnknownTimeZone : AccessCodeWarnings
        {
            [JsonConstructorAttribute]
            protected AccessCodeWarningsTimeFrameAdjustedForUnknownTimeZone() { }

            public AccessCodeWarningsTimeFrameAdjustedForUnknownTimeZone(
                string? createdAt = default,
                string message = default,
                string warningCode = default
            )
            {
                CreatedAt = createdAt;
                Message = message;
                WarningCode = warningCode;
            }

            [DataMember(Name = "created_at", IsRequired = false, EmitDefaultValue = false)]
            public string? CreatedAt { get; set; }

            [DataMember(Name = "message", IsRequired = true, EmitDefaultValue = false)]
            public override string Message { get; set; }

            [DataMember(Name = "warning_code", IsRequired = true, EmitDefaultValue = false)]
            public override string WarningCode { get; } =
                "time_frame_adjusted_for_unknown_time_zone";

            public override string ToString()
            {
                JsonSerializer jsonSerializer = JsonSerializer.CreateDefault(null);

                StringWriter stringWriter = new StringWriter(
                    new StringBuilder(256),
                    System.Globalization.CultureInfo.InvariantCulture
                );
                using (JsonTextWriter jsonTextWriter = new JsonTextWriter(stringWriter))
                {
                    jsonTextWriter.IndentChar = ' ';
                    jsonTextWriter.Indentation = 2;
                    jsonTextWriter.Formatting = Formatting.Indented;
                    jsonSerializer.Serialize(jsonTextWriter, this, null);
                }

                return stringWriter.ToString();
            }
        }

        [DataContract(Name = "seamModel_accessCodeWarningsExternalModificationInEffect_model")]
        public class AccessCodeWarningsExternalModificationInEffect : AccessCodeWarnings
        {
            [JsonConstructorAttribute]
            protected AccessCodeWarningsExternalModificationInEffect() { }

            public AccessCodeWarningsExternalModificationInEffect(
                AccessCodeWarningsExternalModificationInEffect.ChangeTypeEnum? changeType = default,
                string? createdAt = default,
                string message = default,
                List<AccessCodeWarningsExternalModificationInEffectModifiedFields>? modifiedFields =
                    default,
                string warningCode = default
            )
            {
                ChangeType = changeType;
                CreatedAt = createdAt;
                Message = message;
                ModifiedFields = modifiedFields;
                WarningCode = warningCode;
            }

            [JsonConverter(typeof(SafeStringEnumConverter))]
            public enum ChangeTypeEnum
            {
                [EnumMember(Value = "unrecognized")]
                Unrecognized = 0,

                [EnumMember(Value = "modified")]
                Modified = 1,

                [EnumMember(Value = "removed")]
                Removed = 2,
            }

            [DataMember(Name = "change_type", IsRequired = false, EmitDefaultValue = false)]
            public AccessCodeWarningsExternalModificationInEffect.ChangeTypeEnum? ChangeType { get; set; }

            [DataMember(Name = "created_at", IsRequired = false, EmitDefaultValue = false)]
            public string? CreatedAt { get; set; }

            [DataMember(Name = "message", IsRequired = true, EmitDefaultValue = false)]
            public override string Message { get; set; }

            [DataMember(Name = "modified_fields", IsRequired = false, EmitDefaultValue = false)]
            public List<AccessCodeWarningsExternalModificationInEffectModifiedFields>? ModifiedFields { get; set; }

            [DataMember(Name = "warning_code", IsRequired = true, EmitDefaultValue = false)]
            public override string WarningCode { get; } = "external_modification_in_effect";

            public override string ToString()
            {
                JsonSerializer jsonSerializer = JsonSerializer.CreateDefault(null);

                StringWriter stringWriter = new StringWriter(
                    new StringBuilder(256),
                    System.Globalization.CultureInfo.InvariantCulture
                );
                using (JsonTextWriter jsonTextWriter = new JsonTextWriter(stringWriter))
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
            Name = "seamModel_accessCodeWarningsExternalModificationInEffectModifiedFields_model"
        )]
        public class AccessCodeWarningsExternalModificationInEffectModifiedFields
        {
            [JsonConstructorAttribute]
            protected AccessCodeWarningsExternalModificationInEffectModifiedFields() { }

            public AccessCodeWarningsExternalModificationInEffectModifiedFields(
                string field = default,
                string? from = default,
                string? to = default
            )
            {
                Field = field;
                From = from;
                To = to;
            }

            [DataMember(Name = "field", IsRequired = true, EmitDefaultValue = false)]
            public string Field { get; set; }

            [DataMember(Name = "from", IsRequired = false, EmitDefaultValue = false)]
            public string? From { get; set; }

            [DataMember(Name = "to", IsRequired = false, EmitDefaultValue = false)]
            public string? To { get; set; }

            public override string ToString()
            {
                JsonSerializer jsonSerializer = JsonSerializer.CreateDefault(null);

                StringWriter stringWriter = new StringWriter(
                    new StringBuilder(256),
                    System.Globalization.CultureInfo.InvariantCulture
                );
                using (JsonTextWriter jsonTextWriter = new JsonTextWriter(stringWriter))
                {
                    jsonTextWriter.IndentChar = ' ';
                    jsonTextWriter.Indentation = 2;
                    jsonTextWriter.Formatting = Formatting.Indented;
                    jsonSerializer.Serialize(jsonTextWriter, this, null);
                }

                return stringWriter.ToString();
            }
        }

        [DataContract(Name = "seamModel_accessCodeWarningsDelayInSettingOnDevice_model")]
        public class AccessCodeWarningsDelayInSettingOnDevice : AccessCodeWarnings
        {
            [JsonConstructorAttribute]
            protected AccessCodeWarningsDelayInSettingOnDevice() { }

            public AccessCodeWarningsDelayInSettingOnDevice(
                string? createdAt = default,
                string message = default,
                string warningCode = default
            )
            {
                CreatedAt = createdAt;
                Message = message;
                WarningCode = warningCode;
            }

            [DataMember(Name = "created_at", IsRequired = false, EmitDefaultValue = false)]
            public string? CreatedAt { get; set; }

            [DataMember(Name = "message", IsRequired = true, EmitDefaultValue = false)]
            public override string Message { get; set; }

            [DataMember(Name = "warning_code", IsRequired = true, EmitDefaultValue = false)]
            public override string WarningCode { get; } = "delay_in_setting_on_device";

            public override string ToString()
            {
                JsonSerializer jsonSerializer = JsonSerializer.CreateDefault(null);

                StringWriter stringWriter = new StringWriter(
                    new StringBuilder(256),
                    System.Globalization.CultureInfo.InvariantCulture
                );
                using (JsonTextWriter jsonTextWriter = new JsonTextWriter(stringWriter))
                {
                    jsonTextWriter.IndentChar = ' ';
                    jsonTextWriter.Indentation = 2;
                    jsonTextWriter.Formatting = Formatting.Indented;
                    jsonSerializer.Serialize(jsonTextWriter, this, null);
                }

                return stringWriter.ToString();
            }
        }

        [DataContract(Name = "seamModel_accessCodeWarningsDelayInRemovingFromDevice_model")]
        public class AccessCodeWarningsDelayInRemovingFromDevice : AccessCodeWarnings
        {
            [JsonConstructorAttribute]
            protected AccessCodeWarningsDelayInRemovingFromDevice() { }

            public AccessCodeWarningsDelayInRemovingFromDevice(
                string? createdAt = default,
                string message = default,
                string warningCode = default
            )
            {
                CreatedAt = createdAt;
                Message = message;
                WarningCode = warningCode;
            }

            [DataMember(Name = "created_at", IsRequired = false, EmitDefaultValue = false)]
            public string? CreatedAt { get; set; }

            [DataMember(Name = "message", IsRequired = true, EmitDefaultValue = false)]
            public override string Message { get; set; }

            [DataMember(Name = "warning_code", IsRequired = true, EmitDefaultValue = false)]
            public override string WarningCode { get; } = "delay_in_removing_from_device";

            public override string ToString()
            {
                JsonSerializer jsonSerializer = JsonSerializer.CreateDefault(null);

                StringWriter stringWriter = new StringWriter(
                    new StringBuilder(256),
                    System.Globalization.CultureInfo.InvariantCulture
                );
                using (JsonTextWriter jsonTextWriter = new JsonTextWriter(stringWriter))
                {
                    jsonTextWriter.IndentChar = ' ';
                    jsonTextWriter.Indentation = 2;
                    jsonTextWriter.Formatting = Formatting.Indented;
                    jsonSerializer.Serialize(jsonTextWriter, this, null);
                }

                return stringWriter.ToString();
            }
        }

        [DataContract(Name = "seamModel_accessCodeWarningsThirdPartyIntegrationDetected_model")]
        public class AccessCodeWarningsThirdPartyIntegrationDetected : AccessCodeWarnings
        {
            [JsonConstructorAttribute]
            protected AccessCodeWarningsThirdPartyIntegrationDetected() { }

            public AccessCodeWarningsThirdPartyIntegrationDetected(
                string? createdAt = default,
                string message = default,
                string warningCode = default
            )
            {
                CreatedAt = createdAt;
                Message = message;
                WarningCode = warningCode;
            }

            [DataMember(Name = "created_at", IsRequired = false, EmitDefaultValue = false)]
            public string? CreatedAt { get; set; }

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

        [DataContract(
            Name = "seamModel_accessCodeWarningsIglooAlgopinMustBeUsedWithin_24Hours_model"
        )]
        public class AccessCodeWarningsIglooAlgopinMustBeUsedWithin_24Hours : AccessCodeWarnings
        {
            [JsonConstructorAttribute]
            protected AccessCodeWarningsIglooAlgopinMustBeUsedWithin_24Hours() { }

            public AccessCodeWarningsIglooAlgopinMustBeUsedWithin_24Hours(
                string? createdAt = default,
                string message = default,
                string warningCode = default
            )
            {
                CreatedAt = createdAt;
                Message = message;
                WarningCode = warningCode;
            }

            [DataMember(Name = "created_at", IsRequired = false, EmitDefaultValue = false)]
            public string? CreatedAt { get; set; }

            [DataMember(Name = "message", IsRequired = true, EmitDefaultValue = false)]
            public override string Message { get; set; }

            [DataMember(Name = "warning_code", IsRequired = true, EmitDefaultValue = false)]
            public override string WarningCode { get; } =
                "igloo_algopin_must_be_used_within_24_hours";

            public override string ToString()
            {
                JsonSerializer jsonSerializer = JsonSerializer.CreateDefault(null);

                StringWriter stringWriter = new StringWriter(
                    new StringBuilder(256),
                    System.Globalization.CultureInfo.InvariantCulture
                );
                using (JsonTextWriter jsonTextWriter = new JsonTextWriter(stringWriter))
                {
                    jsonTextWriter.IndentChar = ' ';
                    jsonTextWriter.Indentation = 2;
                    jsonTextWriter.Formatting = Formatting.Indented;
                    jsonSerializer.Serialize(jsonTextWriter, this, null);
                }

                return stringWriter.ToString();
            }
        }

        [DataContract(Name = "seamModel_accessCodeWarningsManagementTransferred_model")]
        public class AccessCodeWarningsManagementTransferred : AccessCodeWarnings
        {
            [JsonConstructorAttribute]
            protected AccessCodeWarningsManagementTransferred() { }

            public AccessCodeWarningsManagementTransferred(
                string? createdAt = default,
                string message = default,
                string warningCode = default
            )
            {
                CreatedAt = createdAt;
                Message = message;
                WarningCode = warningCode;
            }

            [DataMember(Name = "created_at", IsRequired = false, EmitDefaultValue = false)]
            public string? CreatedAt { get; set; }

            [DataMember(Name = "message", IsRequired = true, EmitDefaultValue = false)]
            public override string Message { get; set; }

            [DataMember(Name = "warning_code", IsRequired = true, EmitDefaultValue = false)]
            public override string WarningCode { get; } = "management_transferred";

            public override string ToString()
            {
                JsonSerializer jsonSerializer = JsonSerializer.CreateDefault(null);

                StringWriter stringWriter = new StringWriter(
                    new StringBuilder(256),
                    System.Globalization.CultureInfo.InvariantCulture
                );
                using (JsonTextWriter jsonTextWriter = new JsonTextWriter(stringWriter))
                {
                    jsonTextWriter.IndentChar = ' ';
                    jsonTextWriter.Indentation = 2;
                    jsonTextWriter.Formatting = Formatting.Indented;
                    jsonSerializer.Serialize(jsonTextWriter, this, null);
                }

                return stringWriter.ToString();
            }
        }

        [DataContract(Name = "seamModel_accessCodeWarningsUsingBackupAccessCode_model")]
        public class AccessCodeWarningsUsingBackupAccessCode : AccessCodeWarnings
        {
            [JsonConstructorAttribute]
            protected AccessCodeWarningsUsingBackupAccessCode() { }

            public AccessCodeWarningsUsingBackupAccessCode(
                string? createdAt = default,
                string message = default,
                string warningCode = default
            )
            {
                CreatedAt = createdAt;
                Message = message;
                WarningCode = warningCode;
            }

            [DataMember(Name = "created_at", IsRequired = false, EmitDefaultValue = false)]
            public string? CreatedAt { get; set; }

            [DataMember(Name = "message", IsRequired = true, EmitDefaultValue = false)]
            public override string Message { get; set; }

            [DataMember(Name = "warning_code", IsRequired = true, EmitDefaultValue = false)]
            public override string WarningCode { get; } = "using_backup_access_code";

            public override string ToString()
            {
                JsonSerializer jsonSerializer = JsonSerializer.CreateDefault(null);

                StringWriter stringWriter = new StringWriter(
                    new StringBuilder(256),
                    System.Globalization.CultureInfo.InvariantCulture
                );
                using (JsonTextWriter jsonTextWriter = new JsonTextWriter(stringWriter))
                {
                    jsonTextWriter.IndentChar = ' ';
                    jsonTextWriter.Indentation = 2;
                    jsonTextWriter.Formatting = Formatting.Indented;
                    jsonSerializer.Serialize(jsonTextWriter, this, null);
                }

                return stringWriter.ToString();
            }
        }

        [DataContract(Name = "seamModel_accessCodeWarningsBeingDeleted_model")]
        public class AccessCodeWarningsBeingDeleted : AccessCodeWarnings
        {
            [JsonConstructorAttribute]
            protected AccessCodeWarningsBeingDeleted() { }

            public AccessCodeWarningsBeingDeleted(
                string? createdAt = default,
                string message = default,
                string warningCode = default
            )
            {
                CreatedAt = createdAt;
                Message = message;
                WarningCode = warningCode;
            }

            [DataMember(Name = "created_at", IsRequired = false, EmitDefaultValue = false)]
            public string? CreatedAt { get; set; }

            [DataMember(Name = "message", IsRequired = true, EmitDefaultValue = false)]
            public override string Message { get; set; }

            [DataMember(Name = "warning_code", IsRequired = true, EmitDefaultValue = false)]
            public override string WarningCode { get; } = "being_deleted";

            public override string ToString()
            {
                JsonSerializer jsonSerializer = JsonSerializer.CreateDefault(null);

                StringWriter stringWriter = new StringWriter(
                    new StringBuilder(256),
                    System.Globalization.CultureInfo.InvariantCulture
                );
                using (JsonTextWriter jsonTextWriter = new JsonTextWriter(stringWriter))
                {
                    jsonTextWriter.IndentChar = ' ';
                    jsonTextWriter.Indentation = 2;
                    jsonTextWriter.Formatting = Formatting.Indented;
                    jsonSerializer.Serialize(jsonTextWriter, this, null);
                }

                return stringWriter.ToString();
            }
        }

        [DataContract(Name = "seamModel_accessCodeWarningsUnknownIssueWithAccessCode_model")]
        public class AccessCodeWarningsUnknownIssueWithAccessCode : AccessCodeWarnings
        {
            [JsonConstructorAttribute]
            protected AccessCodeWarningsUnknownIssueWithAccessCode() { }

            public AccessCodeWarningsUnknownIssueWithAccessCode(
                string? createdAt = default,
                string message = default,
                string warningCode = default
            )
            {
                CreatedAt = createdAt;
                Message = message;
                WarningCode = warningCode;
            }

            [DataMember(Name = "created_at", IsRequired = false, EmitDefaultValue = false)]
            public string? CreatedAt { get; set; }

            [DataMember(Name = "message", IsRequired = true, EmitDefaultValue = false)]
            public override string Message { get; set; }

            [DataMember(Name = "warning_code", IsRequired = true, EmitDefaultValue = false)]
            public override string WarningCode { get; } = "unknown_issue_with_access_code";

            public override string ToString()
            {
                JsonSerializer jsonSerializer = JsonSerializer.CreateDefault(null);

                StringWriter stringWriter = new StringWriter(
                    new StringBuilder(256),
                    System.Globalization.CultureInfo.InvariantCulture
                );
                using (JsonTextWriter jsonTextWriter = new JsonTextWriter(stringWriter))
                {
                    jsonTextWriter.IndentChar = ' ';
                    jsonTextWriter.Indentation = 2;
                    jsonTextWriter.Formatting = Formatting.Indented;
                    jsonSerializer.Serialize(jsonTextWriter, this, null);
                }

                return stringWriter.ToString();
            }
        }

        [DataContract(Name = "seamModel_accessCodeWarningsUnrecognized_model")]
        public class AccessCodeWarningsUnrecognized : AccessCodeWarnings
        {
            [JsonConstructorAttribute]
            protected AccessCodeWarningsUnrecognized() { }

            public AccessCodeWarningsUnrecognized(
                string warningCode = default,
                string message = default
            )
            {
                WarningCode = warningCode;
                Message = message;
            }

            [DataMember(Name = "warning_code", IsRequired = true, EmitDefaultValue = false)]
            public override string WarningCode { get; } = "unrecognized";

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

        [DataMember(Name = "access_code_id", IsRequired = true, EmitDefaultValue = false)]
        public string AccessCodeId { get; set; }

        [DataMember(Name = "code", IsRequired = false, EmitDefaultValue = false)]
        public string? Code { get; set; }

        [DataMember(Name = "common_code_key", IsRequired = false, EmitDefaultValue = false)]
        public string? CommonCodeKey { get; set; }

        [DataMember(Name = "created_at", IsRequired = true, EmitDefaultValue = false)]
        public string CreatedAt { get; set; }

        [DataMember(Name = "device_id", IsRequired = true, EmitDefaultValue = false)]
        public string DeviceId { get; set; }

        [DataMember(
            Name = "dormakaba_oracode_metadata",
            IsRequired = false,
            EmitDefaultValue = false
        )]
        public AccessCodeDormakabaOracodeMetadata? DormakabaOracodeMetadata { get; set; }

        [DataMember(Name = "ends_at", IsRequired = false, EmitDefaultValue = false)]
        public string? EndsAt { get; set; }

        [DataMember(Name = "errors", IsRequired = true, EmitDefaultValue = false)]
        public List<AccessCodeErrors> Errors { get; set; }

        [DataMember(Name = "is_backup", IsRequired = false, EmitDefaultValue = false)]
        public bool? IsBackup { get; set; }

        [DataMember(
            Name = "is_backup_access_code_available",
            IsRequired = true,
            EmitDefaultValue = false
        )]
        public bool IsBackupAccessCodeAvailable { get; set; }

        [DataMember(
            Name = "is_external_modification_allowed",
            IsRequired = true,
            EmitDefaultValue = false
        )]
        public bool IsExternalModificationAllowed { get; set; }

        [DataMember(Name = "is_managed", IsRequired = true, EmitDefaultValue = false)]
        public bool IsManaged { get; set; }

        [DataMember(Name = "is_offline_access_code", IsRequired = true, EmitDefaultValue = false)]
        public bool IsOfflineAccessCode { get; set; }

        [DataMember(Name = "is_one_time_use", IsRequired = true, EmitDefaultValue = false)]
        public bool IsOneTimeUse { get; set; }

        [DataMember(Name = "is_scheduled_on_device", IsRequired = false, EmitDefaultValue = false)]
        public bool? IsScheduledOnDevice { get; set; }

        [DataMember(
            Name = "is_waiting_for_code_assignment",
            IsRequired = false,
            EmitDefaultValue = false
        )]
        public bool? IsWaitingForCodeAssignment { get; set; }

        [DataMember(Name = "name", IsRequired = false, EmitDefaultValue = false)]
        public string? Name { get; set; }

        [DataMember(Name = "pending_mutations", IsRequired = true, EmitDefaultValue = false)]
        public List<AccessCodePendingMutations> PendingMutations { get; set; }

        [DataMember(
            Name = "pulled_backup_access_code_id",
            IsRequired = false,
            EmitDefaultValue = false
        )]
        public string? PulledBackupAccessCodeId { get; set; }

        [DataMember(Name = "starts_at", IsRequired = false, EmitDefaultValue = false)]
        public string? StartsAt { get; set; }

        [DataMember(Name = "status", IsRequired = true, EmitDefaultValue = false)]
        public AccessCode.StatusEnum Status { get; set; }

        [DataMember(Name = "type", IsRequired = true, EmitDefaultValue = false)]
        public AccessCode.TypeEnum Type { get; set; }

        [DataMember(Name = "warnings", IsRequired = true, EmitDefaultValue = false)]
        public List<AccessCodeWarnings> Warnings { get; set; }

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

    [DataContract(Name = "seamModel_accessCodeDormakabaOracodeMetadata_model")]
    public class AccessCodeDormakabaOracodeMetadata
    {
        [JsonConstructorAttribute]
        protected AccessCodeDormakabaOracodeMetadata() { }

        public AccessCodeDormakabaOracodeMetadata(
            bool? isCancellable = default,
            bool? isEarlyCheckinAble = default,
            bool? isExtendable = default,
            bool? isOverridable = default,
            string? siteName = default,
            float? stayId = default,
            string? userLevelId = default,
            string? userLevelName = default
        )
        {
            IsCancellable = isCancellable;
            IsEarlyCheckinAble = isEarlyCheckinAble;
            IsExtendable = isExtendable;
            IsOverridable = isOverridable;
            SiteName = siteName;
            StayId = stayId;
            UserLevelId = userLevelId;
            UserLevelName = userLevelName;
        }

        [DataMember(Name = "is_cancellable", IsRequired = false, EmitDefaultValue = false)]
        public bool? IsCancellable { get; set; }

        [DataMember(Name = "is_early_checkin_able", IsRequired = false, EmitDefaultValue = false)]
        public bool? IsEarlyCheckinAble { get; set; }

        [DataMember(Name = "is_extendable", IsRequired = false, EmitDefaultValue = false)]
        public bool? IsExtendable { get; set; }

        [DataMember(Name = "is_overridable", IsRequired = false, EmitDefaultValue = false)]
        public bool? IsOverridable { get; set; }

        [DataMember(Name = "site_name", IsRequired = false, EmitDefaultValue = false)]
        public string? SiteName { get; set; }

        [DataMember(Name = "stay_id", IsRequired = false, EmitDefaultValue = false)]
        public float? StayId { get; set; }

        [DataMember(Name = "user_level_id", IsRequired = false, EmitDefaultValue = false)]
        public string? UserLevelId { get; set; }

        [DataMember(Name = "user_level_name", IsRequired = false, EmitDefaultValue = false)]
        public string? UserLevelName { get; set; }

        public override string ToString()
        {
            JsonSerializer jsonSerializer = JsonSerializer.CreateDefault(null);

            StringWriter stringWriter = new StringWriter(
                new StringBuilder(256),
                System.Globalization.CultureInfo.InvariantCulture
            );
            using (JsonTextWriter jsonTextWriter = new JsonTextWriter(stringWriter))
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
