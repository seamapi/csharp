using System.Runtime.Serialization;
using System.Text;
using JsonSubTypes;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using Seam.Model;

namespace Seam.Model
{
    [DataContract(Name = "seamModel_unmanagedAccessCode_model")]
    public class UnmanagedAccessCode
    {
        [JsonConstructorAttribute]
        protected UnmanagedAccessCode() { }

        public UnmanagedAccessCode(
            string accessCodeId = default,
            bool? cannotBeManaged = default,
            bool? cannotDeleteUnmanagedAccessCode = default,
            string? code = default,
            string createdAt = default,
            string deviceId = default,
            UnmanagedAccessCodeDormakabaOracodeMetadata? dormakabaOracodeMetadata = default,
            string? endsAt = default,
            List<UnmanagedAccessCodeErrors> errors = default,
            bool isManaged = default,
            string? name = default,
            string? startsAt = default,
            UnmanagedAccessCode.StatusEnum status = default,
            UnmanagedAccessCode.TypeEnum type = default,
            List<UnmanagedAccessCodeWarnings> warnings = default,
            string workspaceId = default
        )
        {
            AccessCodeId = accessCodeId;
            CannotBeManaged = cannotBeManaged;
            CannotDeleteUnmanagedAccessCode = cannotDeleteUnmanagedAccessCode;
            Code = code;
            CreatedAt = createdAt;
            DeviceId = deviceId;
            DormakabaOracodeMetadata = dormakabaOracodeMetadata;
            EndsAt = endsAt;
            Errors = errors;
            IsManaged = isManaged;
            Name = name;
            StartsAt = startsAt;
            Status = status;
            Type = type;
            Warnings = warnings;
            WorkspaceId = workspaceId;
        }

        [JsonConverter(typeof(JsonSubtypes), "error_code")]
        [JsonSubtypes.FallBackSubType(typeof(UnmanagedAccessCodeErrorsUnrecognized))]
        [JsonSubtypes.KnownSubType(
            typeof(UnmanagedAccessCodeErrorsBridgeDisconnected),
            "bridge_disconnected"
        )]
        [JsonSubtypes.KnownSubType(
            typeof(UnmanagedAccessCodeErrorsSubscriptionRequired),
            "subscription_required"
        )]
        [JsonSubtypes.KnownSubType(
            typeof(UnmanagedAccessCodeErrorsAuxiliaryHeatRunning),
            "auxiliary_heat_running"
        )]
        [JsonSubtypes.KnownSubType(
            typeof(UnmanagedAccessCodeErrorsMissingDeviceCredentials),
            "missing_device_credentials"
        )]
        [JsonSubtypes.KnownSubType(
            typeof(UnmanagedAccessCodeErrorsAugustLockNotAuthorized),
            "august_lock_not_authorized"
        )]
        [JsonSubtypes.KnownSubType(
            typeof(UnmanagedAccessCodeErrorsEmptyBackupAccessCodePool),
            "empty_backup_access_code_pool"
        )]
        [JsonSubtypes.KnownSubType(
            typeof(UnmanagedAccessCodeErrorsDeviceDisconnected),
            "device_disconnected"
        )]
        [JsonSubtypes.KnownSubType(
            typeof(UnmanagedAccessCodeErrorsHubDisconnected),
            "hub_disconnected"
        )]
        [JsonSubtypes.KnownSubType(
            typeof(UnmanagedAccessCodeErrorsDeviceRemoved),
            "device_removed"
        )]
        [JsonSubtypes.KnownSubType(
            typeof(UnmanagedAccessCodeErrorsDeviceOffline),
            "device_offline"
        )]
        [JsonSubtypes.KnownSubType(
            typeof(UnmanagedAccessCodeErrorsDormakabaSitesDisconnected),
            "dormakaba_sites_disconnected"
        )]
        [JsonSubtypes.KnownSubType(
            typeof(UnmanagedAccessCodeErrorsSaltoKsSubscriptionLimitExceeded),
            "salto_ks_subscription_limit_exceeded"
        )]
        [JsonSubtypes.KnownSubType(
            typeof(UnmanagedAccessCodeErrorsAccountDisconnected),
            "account_disconnected"
        )]
        [JsonSubtypes.KnownSubType(
            typeof(UnmanagedAccessCodeErrorsInsufficientPermissions),
            "insufficient_permissions"
        )]
        [JsonSubtypes.KnownSubType(
            typeof(UnmanagedAccessCodeErrorsAccessCodeInactive),
            "access_code_inactive"
        )]
        [JsonSubtypes.KnownSubType(
            typeof(UnmanagedAccessCodeErrorsConflictingExternalModification),
            "conflicting_external_modification"
        )]
        [JsonSubtypes.KnownSubType(
            typeof(UnmanagedAccessCodeErrorsNoSpaceForAccessCodeOnDevice),
            "no_space_for_access_code_on_device"
        )]
        [JsonSubtypes.KnownSubType(
            typeof(UnmanagedAccessCodeErrorsDuplicateCodeOnDevice),
            "duplicate_code_on_device"
        )]
        [JsonSubtypes.KnownSubType(
            typeof(UnmanagedAccessCodeErrorsFailedToRemoveFromDevice),
            "failed_to_remove_from_device"
        )]
        [JsonSubtypes.KnownSubType(
            typeof(UnmanagedAccessCodeErrorsFailedToSetOnDevice),
            "failed_to_set_on_device"
        )]
        [JsonSubtypes.KnownSubType(
            typeof(UnmanagedAccessCodeErrorsProviderIssue),
            "provider_issue"
        )]
        public abstract class UnmanagedAccessCodeErrors
        {
            public abstract string ErrorCode { get; }

            public abstract string Message { get; set; }

            public abstract override string ToString();
        }

        [DataContract(Name = "seamModel_unmanagedAccessCodeErrorsProviderIssue_model")]
        public class UnmanagedAccessCodeErrorsProviderIssue : UnmanagedAccessCodeErrors
        {
            [JsonConstructorAttribute]
            protected UnmanagedAccessCodeErrorsProviderIssue() { }

            public UnmanagedAccessCodeErrorsProviderIssue(
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

        [DataContract(Name = "seamModel_unmanagedAccessCodeErrorsFailedToSetOnDevice_model")]
        public class UnmanagedAccessCodeErrorsFailedToSetOnDevice : UnmanagedAccessCodeErrors
        {
            [JsonConstructorAttribute]
            protected UnmanagedAccessCodeErrorsFailedToSetOnDevice() { }

            public UnmanagedAccessCodeErrorsFailedToSetOnDevice(
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

        [DataContract(Name = "seamModel_unmanagedAccessCodeErrorsFailedToRemoveFromDevice_model")]
        public class UnmanagedAccessCodeErrorsFailedToRemoveFromDevice : UnmanagedAccessCodeErrors
        {
            [JsonConstructorAttribute]
            protected UnmanagedAccessCodeErrorsFailedToRemoveFromDevice() { }

            public UnmanagedAccessCodeErrorsFailedToRemoveFromDevice(
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

        [DataContract(Name = "seamModel_unmanagedAccessCodeErrorsDuplicateCodeOnDevice_model")]
        public class UnmanagedAccessCodeErrorsDuplicateCodeOnDevice : UnmanagedAccessCodeErrors
        {
            [JsonConstructorAttribute]
            protected UnmanagedAccessCodeErrorsDuplicateCodeOnDevice() { }

            public UnmanagedAccessCodeErrorsDuplicateCodeOnDevice(
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

        [DataContract(
            Name = "seamModel_unmanagedAccessCodeErrorsNoSpaceForAccessCodeOnDevice_model"
        )]
        public class UnmanagedAccessCodeErrorsNoSpaceForAccessCodeOnDevice
            : UnmanagedAccessCodeErrors
        {
            [JsonConstructorAttribute]
            protected UnmanagedAccessCodeErrorsNoSpaceForAccessCodeOnDevice() { }

            public UnmanagedAccessCodeErrorsNoSpaceForAccessCodeOnDevice(
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

        [DataContract(
            Name = "seamModel_unmanagedAccessCodeErrorsConflictingExternalModification_model"
        )]
        public class UnmanagedAccessCodeErrorsConflictingExternalModification
            : UnmanagedAccessCodeErrors
        {
            [JsonConstructorAttribute]
            protected UnmanagedAccessCodeErrorsConflictingExternalModification() { }

            public UnmanagedAccessCodeErrorsConflictingExternalModification(
                UnmanagedAccessCodeErrorsConflictingExternalModification.ChangeTypeEnum? changeType =
                    default,
                string? createdAt = default,
                string errorCode = default,
                bool isAccessCodeError = default,
                string message = default,
                List<UnmanagedAccessCodeErrorsConflictingExternalModificationModifiedFields>? modifiedFields =
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
            public UnmanagedAccessCodeErrorsConflictingExternalModification.ChangeTypeEnum? ChangeType { get; set; }

            [DataMember(Name = "created_at", IsRequired = false, EmitDefaultValue = false)]
            public string? CreatedAt { get; set; }

            [DataMember(Name = "error_code", IsRequired = true, EmitDefaultValue = false)]
            public override string ErrorCode { get; } = "conflicting_external_modification";

            [DataMember(Name = "is_access_code_error", IsRequired = true, EmitDefaultValue = false)]
            public bool IsAccessCodeError { get; set; }

            [DataMember(Name = "message", IsRequired = true, EmitDefaultValue = false)]
            public override string Message { get; set; }

            [DataMember(Name = "modified_fields", IsRequired = false, EmitDefaultValue = false)]
            public List<UnmanagedAccessCodeErrorsConflictingExternalModificationModifiedFields>? ModifiedFields { get; set; }

            public override string ToString()
            {
                JsonSerializer jsonSerializer = JsonSerializer.CreateDefault(null);

                StringWriter stringWriter = new StringWriter(
                    new StringBuilder(256),
                    System.Globalization.CultureInfo.InvariantCulture
                );
                using (JsonTextWriter jsonTextWriter = new JsonTextWriter(stringWriter))
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
            Name = "seamModel_unmanagedAccessCodeErrorsConflictingExternalModificationModifiedFields_model"
        )]
        public class UnmanagedAccessCodeErrorsConflictingExternalModificationModifiedFields
        {
            [JsonConstructorAttribute]
            protected UnmanagedAccessCodeErrorsConflictingExternalModificationModifiedFields() { }

            public UnmanagedAccessCodeErrorsConflictingExternalModificationModifiedFields(
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

        [DataContract(Name = "seamModel_unmanagedAccessCodeErrorsAccessCodeInactive_model")]
        public class UnmanagedAccessCodeErrorsAccessCodeInactive : UnmanagedAccessCodeErrors
        {
            [JsonConstructorAttribute]
            protected UnmanagedAccessCodeErrorsAccessCodeInactive() { }

            public UnmanagedAccessCodeErrorsAccessCodeInactive(
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

        [DataContract(Name = "seamModel_unmanagedAccessCodeErrorsInsufficientPermissions_model")]
        public class UnmanagedAccessCodeErrorsInsufficientPermissions : UnmanagedAccessCodeErrors
        {
            [JsonConstructorAttribute]
            protected UnmanagedAccessCodeErrorsInsufficientPermissions() { }

            public UnmanagedAccessCodeErrorsInsufficientPermissions(
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

        [DataContract(Name = "seamModel_unmanagedAccessCodeErrorsAccountDisconnected_model")]
        public class UnmanagedAccessCodeErrorsAccountDisconnected : UnmanagedAccessCodeErrors
        {
            [JsonConstructorAttribute]
            protected UnmanagedAccessCodeErrorsAccountDisconnected() { }

            public UnmanagedAccessCodeErrorsAccountDisconnected(
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

        [DataContract(
            Name = "seamModel_unmanagedAccessCodeErrorsSaltoKsSubscriptionLimitExceeded_model"
        )]
        public class UnmanagedAccessCodeErrorsSaltoKsSubscriptionLimitExceeded
            : UnmanagedAccessCodeErrors
        {
            [JsonConstructorAttribute]
            protected UnmanagedAccessCodeErrorsSaltoKsSubscriptionLimitExceeded() { }

            public UnmanagedAccessCodeErrorsSaltoKsSubscriptionLimitExceeded(
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

        [DataContract(Name = "seamModel_unmanagedAccessCodeErrorsDormakabaSitesDisconnected_model")]
        public class UnmanagedAccessCodeErrorsDormakabaSitesDisconnected : UnmanagedAccessCodeErrors
        {
            [JsonConstructorAttribute]
            protected UnmanagedAccessCodeErrorsDormakabaSitesDisconnected() { }

            public UnmanagedAccessCodeErrorsDormakabaSitesDisconnected(
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

        [DataContract(Name = "seamModel_unmanagedAccessCodeErrorsDeviceOffline_model")]
        public class UnmanagedAccessCodeErrorsDeviceOffline : UnmanagedAccessCodeErrors
        {
            [JsonConstructorAttribute]
            protected UnmanagedAccessCodeErrorsDeviceOffline() { }

            public UnmanagedAccessCodeErrorsDeviceOffline(
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

        [DataContract(Name = "seamModel_unmanagedAccessCodeErrorsDeviceRemoved_model")]
        public class UnmanagedAccessCodeErrorsDeviceRemoved : UnmanagedAccessCodeErrors
        {
            [JsonConstructorAttribute]
            protected UnmanagedAccessCodeErrorsDeviceRemoved() { }

            public UnmanagedAccessCodeErrorsDeviceRemoved(
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

        [DataContract(Name = "seamModel_unmanagedAccessCodeErrorsHubDisconnected_model")]
        public class UnmanagedAccessCodeErrorsHubDisconnected : UnmanagedAccessCodeErrors
        {
            [JsonConstructorAttribute]
            protected UnmanagedAccessCodeErrorsHubDisconnected() { }

            public UnmanagedAccessCodeErrorsHubDisconnected(
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

        [DataContract(Name = "seamModel_unmanagedAccessCodeErrorsDeviceDisconnected_model")]
        public class UnmanagedAccessCodeErrorsDeviceDisconnected : UnmanagedAccessCodeErrors
        {
            [JsonConstructorAttribute]
            protected UnmanagedAccessCodeErrorsDeviceDisconnected() { }

            public UnmanagedAccessCodeErrorsDeviceDisconnected(
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

        [DataContract(Name = "seamModel_unmanagedAccessCodeErrorsEmptyBackupAccessCodePool_model")]
        public class UnmanagedAccessCodeErrorsEmptyBackupAccessCodePool : UnmanagedAccessCodeErrors
        {
            [JsonConstructorAttribute]
            protected UnmanagedAccessCodeErrorsEmptyBackupAccessCodePool() { }

            public UnmanagedAccessCodeErrorsEmptyBackupAccessCodePool(
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

        [DataContract(Name = "seamModel_unmanagedAccessCodeErrorsAugustLockNotAuthorized_model")]
        public class UnmanagedAccessCodeErrorsAugustLockNotAuthorized : UnmanagedAccessCodeErrors
        {
            [JsonConstructorAttribute]
            protected UnmanagedAccessCodeErrorsAugustLockNotAuthorized() { }

            public UnmanagedAccessCodeErrorsAugustLockNotAuthorized(
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

        [DataContract(Name = "seamModel_unmanagedAccessCodeErrorsMissingDeviceCredentials_model")]
        public class UnmanagedAccessCodeErrorsMissingDeviceCredentials : UnmanagedAccessCodeErrors
        {
            [JsonConstructorAttribute]
            protected UnmanagedAccessCodeErrorsMissingDeviceCredentials() { }

            public UnmanagedAccessCodeErrorsMissingDeviceCredentials(
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

        [DataContract(Name = "seamModel_unmanagedAccessCodeErrorsAuxiliaryHeatRunning_model")]
        public class UnmanagedAccessCodeErrorsAuxiliaryHeatRunning : UnmanagedAccessCodeErrors
        {
            [JsonConstructorAttribute]
            protected UnmanagedAccessCodeErrorsAuxiliaryHeatRunning() { }

            public UnmanagedAccessCodeErrorsAuxiliaryHeatRunning(
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

        [DataContract(Name = "seamModel_unmanagedAccessCodeErrorsSubscriptionRequired_model")]
        public class UnmanagedAccessCodeErrorsSubscriptionRequired : UnmanagedAccessCodeErrors
        {
            [JsonConstructorAttribute]
            protected UnmanagedAccessCodeErrorsSubscriptionRequired() { }

            public UnmanagedAccessCodeErrorsSubscriptionRequired(
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

        [DataContract(Name = "seamModel_unmanagedAccessCodeErrorsBridgeDisconnected_model")]
        public class UnmanagedAccessCodeErrorsBridgeDisconnected : UnmanagedAccessCodeErrors
        {
            [JsonConstructorAttribute]
            protected UnmanagedAccessCodeErrorsBridgeDisconnected() { }

            public UnmanagedAccessCodeErrorsBridgeDisconnected(
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

        [DataContract(Name = "seamModel_unmanagedAccessCodeErrorsUnrecognized_model")]
        public class UnmanagedAccessCodeErrorsUnrecognized : UnmanagedAccessCodeErrors
        {
            [JsonConstructorAttribute]
            protected UnmanagedAccessCodeErrorsUnrecognized() { }

            public UnmanagedAccessCodeErrorsUnrecognized(
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

        [JsonConverter(typeof(SafeStringEnumConverter))]
        public enum StatusEnum
        {
            [EnumMember(Value = "unrecognized")]
            Unrecognized = 0,

            [EnumMember(Value = "set")]
            Set = 1,

            [EnumMember(Value = "unset")]
            Unset = 2,
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
        [JsonSubtypes.FallBackSubType(typeof(UnmanagedAccessCodeWarningsUnrecognized))]
        [JsonSubtypes.KnownSubType(
            typeof(UnmanagedAccessCodeWarningsUnknownIssueWithAccessCode),
            "unknown_issue_with_access_code"
        )]
        [JsonSubtypes.KnownSubType(
            typeof(UnmanagedAccessCodeWarningsBeingDeleted),
            "being_deleted"
        )]
        [JsonSubtypes.KnownSubType(
            typeof(UnmanagedAccessCodeWarningsUsingBackupAccessCode),
            "using_backup_access_code"
        )]
        [JsonSubtypes.KnownSubType(
            typeof(UnmanagedAccessCodeWarningsManagementTransferred),
            "management_transferred"
        )]
        [JsonSubtypes.KnownSubType(
            typeof(UnmanagedAccessCodeWarningsIglooAlgopinMustBeUsedWithin_24Hours),
            "igloo_algopin_must_be_used_within_24_hours"
        )]
        [JsonSubtypes.KnownSubType(
            typeof(UnmanagedAccessCodeWarningsThirdPartyIntegrationDetected),
            "third_party_integration_detected"
        )]
        [JsonSubtypes.KnownSubType(
            typeof(UnmanagedAccessCodeWarningsDelayInRemovingFromDevice),
            "delay_in_removing_from_device"
        )]
        [JsonSubtypes.KnownSubType(
            typeof(UnmanagedAccessCodeWarningsDelayInSettingOnDevice),
            "delay_in_setting_on_device"
        )]
        [JsonSubtypes.KnownSubType(
            typeof(UnmanagedAccessCodeWarningsExternalModificationInEffect),
            "external_modification_in_effect"
        )]
        [JsonSubtypes.KnownSubType(
            typeof(UnmanagedAccessCodeWarningsTimeFrameAdjustedForUnknownTimeZone),
            "time_frame_adjusted_for_unknown_time_zone"
        )]
        [JsonSubtypes.KnownSubType(
            typeof(UnmanagedAccessCodeWarningsCodeRotatesPeriodically),
            "code_rotates_periodically"
        )]
        public abstract class UnmanagedAccessCodeWarnings
        {
            public abstract string WarningCode { get; }

            public abstract string Message { get; set; }

            public abstract override string ToString();
        }

        [DataContract(Name = "seamModel_unmanagedAccessCodeWarningsCodeRotatesPeriodically_model")]
        public class UnmanagedAccessCodeWarningsCodeRotatesPeriodically
            : UnmanagedAccessCodeWarnings
        {
            [JsonConstructorAttribute]
            protected UnmanagedAccessCodeWarningsCodeRotatesPeriodically() { }

            public UnmanagedAccessCodeWarningsCodeRotatesPeriodically(
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
            Name = "seamModel_unmanagedAccessCodeWarningsTimeFrameAdjustedForUnknownTimeZone_model"
        )]
        public class UnmanagedAccessCodeWarningsTimeFrameAdjustedForUnknownTimeZone
            : UnmanagedAccessCodeWarnings
        {
            [JsonConstructorAttribute]
            protected UnmanagedAccessCodeWarningsTimeFrameAdjustedForUnknownTimeZone() { }

            public UnmanagedAccessCodeWarningsTimeFrameAdjustedForUnknownTimeZone(
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

        [DataContract(
            Name = "seamModel_unmanagedAccessCodeWarningsExternalModificationInEffect_model"
        )]
        public class UnmanagedAccessCodeWarningsExternalModificationInEffect
            : UnmanagedAccessCodeWarnings
        {
            [JsonConstructorAttribute]
            protected UnmanagedAccessCodeWarningsExternalModificationInEffect() { }

            public UnmanagedAccessCodeWarningsExternalModificationInEffect(
                UnmanagedAccessCodeWarningsExternalModificationInEffect.ChangeTypeEnum? changeType =
                    default,
                string? createdAt = default,
                string message = default,
                List<UnmanagedAccessCodeWarningsExternalModificationInEffectModifiedFields>? modifiedFields =
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
            public UnmanagedAccessCodeWarningsExternalModificationInEffect.ChangeTypeEnum? ChangeType { get; set; }

            [DataMember(Name = "created_at", IsRequired = false, EmitDefaultValue = false)]
            public string? CreatedAt { get; set; }

            [DataMember(Name = "message", IsRequired = true, EmitDefaultValue = false)]
            public override string Message { get; set; }

            [DataMember(Name = "modified_fields", IsRequired = false, EmitDefaultValue = false)]
            public List<UnmanagedAccessCodeWarningsExternalModificationInEffectModifiedFields>? ModifiedFields { get; set; }

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
            Name = "seamModel_unmanagedAccessCodeWarningsExternalModificationInEffectModifiedFields_model"
        )]
        public class UnmanagedAccessCodeWarningsExternalModificationInEffectModifiedFields
        {
            [JsonConstructorAttribute]
            protected UnmanagedAccessCodeWarningsExternalModificationInEffectModifiedFields() { }

            public UnmanagedAccessCodeWarningsExternalModificationInEffectModifiedFields(
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

        [DataContract(Name = "seamModel_unmanagedAccessCodeWarningsDelayInSettingOnDevice_model")]
        public class UnmanagedAccessCodeWarningsDelayInSettingOnDevice : UnmanagedAccessCodeWarnings
        {
            [JsonConstructorAttribute]
            protected UnmanagedAccessCodeWarningsDelayInSettingOnDevice() { }

            public UnmanagedAccessCodeWarningsDelayInSettingOnDevice(
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

        [DataContract(
            Name = "seamModel_unmanagedAccessCodeWarningsDelayInRemovingFromDevice_model"
        )]
        public class UnmanagedAccessCodeWarningsDelayInRemovingFromDevice
            : UnmanagedAccessCodeWarnings
        {
            [JsonConstructorAttribute]
            protected UnmanagedAccessCodeWarningsDelayInRemovingFromDevice() { }

            public UnmanagedAccessCodeWarningsDelayInRemovingFromDevice(
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

        [DataContract(
            Name = "seamModel_unmanagedAccessCodeWarningsThirdPartyIntegrationDetected_model"
        )]
        public class UnmanagedAccessCodeWarningsThirdPartyIntegrationDetected
            : UnmanagedAccessCodeWarnings
        {
            [JsonConstructorAttribute]
            protected UnmanagedAccessCodeWarningsThirdPartyIntegrationDetected() { }

            public UnmanagedAccessCodeWarningsThirdPartyIntegrationDetected(
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
            Name = "seamModel_unmanagedAccessCodeWarningsIglooAlgopinMustBeUsedWithin_24Hours_model"
        )]
        public class UnmanagedAccessCodeWarningsIglooAlgopinMustBeUsedWithin_24Hours
            : UnmanagedAccessCodeWarnings
        {
            [JsonConstructorAttribute]
            protected UnmanagedAccessCodeWarningsIglooAlgopinMustBeUsedWithin_24Hours() { }

            public UnmanagedAccessCodeWarningsIglooAlgopinMustBeUsedWithin_24Hours(
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

        [DataContract(Name = "seamModel_unmanagedAccessCodeWarningsManagementTransferred_model")]
        public class UnmanagedAccessCodeWarningsManagementTransferred : UnmanagedAccessCodeWarnings
        {
            [JsonConstructorAttribute]
            protected UnmanagedAccessCodeWarningsManagementTransferred() { }

            public UnmanagedAccessCodeWarningsManagementTransferred(
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

        [DataContract(Name = "seamModel_unmanagedAccessCodeWarningsUsingBackupAccessCode_model")]
        public class UnmanagedAccessCodeWarningsUsingBackupAccessCode : UnmanagedAccessCodeWarnings
        {
            [JsonConstructorAttribute]
            protected UnmanagedAccessCodeWarningsUsingBackupAccessCode() { }

            public UnmanagedAccessCodeWarningsUsingBackupAccessCode(
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

        [DataContract(Name = "seamModel_unmanagedAccessCodeWarningsBeingDeleted_model")]
        public class UnmanagedAccessCodeWarningsBeingDeleted : UnmanagedAccessCodeWarnings
        {
            [JsonConstructorAttribute]
            protected UnmanagedAccessCodeWarningsBeingDeleted() { }

            public UnmanagedAccessCodeWarningsBeingDeleted(
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

        [DataContract(
            Name = "seamModel_unmanagedAccessCodeWarningsUnknownIssueWithAccessCode_model"
        )]
        public class UnmanagedAccessCodeWarningsUnknownIssueWithAccessCode
            : UnmanagedAccessCodeWarnings
        {
            [JsonConstructorAttribute]
            protected UnmanagedAccessCodeWarningsUnknownIssueWithAccessCode() { }

            public UnmanagedAccessCodeWarningsUnknownIssueWithAccessCode(
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

        [DataContract(Name = "seamModel_unmanagedAccessCodeWarningsUnrecognized_model")]
        public class UnmanagedAccessCodeWarningsUnrecognized : UnmanagedAccessCodeWarnings
        {
            [JsonConstructorAttribute]
            protected UnmanagedAccessCodeWarningsUnrecognized() { }

            public UnmanagedAccessCodeWarningsUnrecognized(
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

        [DataMember(Name = "cannot_be_managed", IsRequired = false, EmitDefaultValue = false)]
        public bool? CannotBeManaged { get; set; }

        [DataMember(
            Name = "cannot_delete_unmanaged_access_code",
            IsRequired = false,
            EmitDefaultValue = false
        )]
        public bool? CannotDeleteUnmanagedAccessCode { get; set; }

        [DataMember(Name = "code", IsRequired = false, EmitDefaultValue = false)]
        public string? Code { get; set; }

        [DataMember(Name = "created_at", IsRequired = true, EmitDefaultValue = false)]
        public string CreatedAt { get; set; }

        [DataMember(Name = "device_id", IsRequired = true, EmitDefaultValue = false)]
        public string DeviceId { get; set; }

        [DataMember(
            Name = "dormakaba_oracode_metadata",
            IsRequired = false,
            EmitDefaultValue = false
        )]
        public UnmanagedAccessCodeDormakabaOracodeMetadata? DormakabaOracodeMetadata { get; set; }

        [DataMember(Name = "ends_at", IsRequired = false, EmitDefaultValue = false)]
        public string? EndsAt { get; set; }

        [DataMember(Name = "errors", IsRequired = true, EmitDefaultValue = false)]
        public List<UnmanagedAccessCodeErrors> Errors { get; set; }

        [DataMember(Name = "is_managed", IsRequired = true, EmitDefaultValue = false)]
        public bool IsManaged { get; set; }

        [DataMember(Name = "name", IsRequired = false, EmitDefaultValue = false)]
        public string? Name { get; set; }

        [DataMember(Name = "starts_at", IsRequired = false, EmitDefaultValue = false)]
        public string? StartsAt { get; set; }

        [DataMember(Name = "status", IsRequired = true, EmitDefaultValue = false)]
        public UnmanagedAccessCode.StatusEnum Status { get; set; }

        [DataMember(Name = "type", IsRequired = true, EmitDefaultValue = false)]
        public UnmanagedAccessCode.TypeEnum Type { get; set; }

        [DataMember(Name = "warnings", IsRequired = true, EmitDefaultValue = false)]
        public List<UnmanagedAccessCodeWarnings> Warnings { get; set; }

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

    [DataContract(Name = "seamModel_unmanagedAccessCodeDormakabaOracodeMetadata_model")]
    public class UnmanagedAccessCodeDormakabaOracodeMetadata
    {
        [JsonConstructorAttribute]
        protected UnmanagedAccessCodeDormakabaOracodeMetadata() { }

        public UnmanagedAccessCodeDormakabaOracodeMetadata(
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
