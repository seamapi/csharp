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
    /// Represents a smart lock [access code](https://docs.seam.co/low-level-apis/smart-locks/access-codes).
    ///
    /// An access code is a code used for a keypad or pinpad device. Unlike physical keys, which can easily be lost or duplicated, PIN codes can be customized, tracked, and altered on the fly. Using the Seam Access Code API, you can easily generate access codes on the hundreds of door lock models with which we integrate.
    ///
    /// Seam supports programming two types of access codes: [ongoing](https://docs.seam.co/low-level-apis/smart-locks/access-codes#ongoing-access-codes) and [time-bound](https://docs.seam.co/low-level-apis/smart-locks/access-codes#time-bound-access-codes). To differentiate between the two, refer to the `type` property of the access code. Ongoing codes display as `ongoing`, whereas time-bound codes are labeled `time_bound`. An ongoing access code is active, until it has been removed from the device. To specify an ongoing access code, leave both `starts_at` and `ends_at` empty. A time-bound access code will be programmed at the `starts_at` time and removed at the `ends_at` time.
    ///
    /// In addition, for certain devices, Seam also supports [offline access codes](https://docs.seam.co/low-level-apis/smart-locks/access-codes#offline-access-codes). Offline access (PIN) codes are designed for door locks that might not always maintain an internet connection. For this type of access code, the device manufacturer uses encryption keys (tokens) to create server-based registries of algorithmically-generated offline PIN codes. Because the tokens remain synchronized with the managed devices, the locks do not require an active internet connection—and you do not need to be near the locks—to create an offline access code. Then, owners or managers can share these offline codes with users through a variety of mechanisms, such as messaging applications. That is, lock users do not need to install a smartphone application to receive an offline access code.
    ///
    /// For granting a person access to a space, [Access Grants](https://docs.seam.co/use-cases/granting-access) are the default and recommended approach and work across both standalone smart locks and access systems. Use the lower-level Access Codes API directly only when you specifically need to manage individual PIN codes.
    /// </summary>
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
            typeof(AccessCodeErrorsInsufficientPermissions),
            "insufficient_permissions"
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
            typeof(AccessCodeErrorsCodeConstraintsViolated),
            "code_constraints_violated"
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

            /// <summary>
            /// Date and time at which Seam created the error.
            /// </summary>
            [DataMember(Name = "created_at", IsRequired = false, EmitDefaultValue = false)]
            public string? CreatedAt { get; set; }

            [DataMember(Name = "error_code", IsRequired = true, EmitDefaultValue = false)]
            public override string ErrorCode { get; } = "provider_issue";

            /// <summary>
            /// Indicates that this is an access code error.
            /// </summary>
            [DataMember(
                Name = "is_access_code_error",
                IsRequired = false,
                EmitDefaultValue = false
            )]
            public bool IsAccessCodeError { get; set; }

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

            /// <summary>
            /// Date and time at which Seam created the error.
            /// </summary>
            [DataMember(Name = "created_at", IsRequired = false, EmitDefaultValue = false)]
            public string? CreatedAt { get; set; }

            [DataMember(Name = "error_code", IsRequired = true, EmitDefaultValue = false)]
            public override string ErrorCode { get; } = "failed_to_set_on_device";

            /// <summary>
            /// Indicates that this is an access code error.
            /// </summary>
            [DataMember(
                Name = "is_access_code_error",
                IsRequired = false,
                EmitDefaultValue = false
            )]
            public bool IsAccessCodeError { get; set; }

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

            /// <summary>
            /// Date and time at which Seam created the error.
            /// </summary>
            [DataMember(Name = "created_at", IsRequired = false, EmitDefaultValue = false)]
            public string? CreatedAt { get; set; }

            [DataMember(Name = "error_code", IsRequired = true, EmitDefaultValue = false)]
            public override string ErrorCode { get; } = "failed_to_remove_from_device";

            /// <summary>
            /// Indicates that this is an access code error.
            /// </summary>
            [DataMember(
                Name = "is_access_code_error",
                IsRequired = false,
                EmitDefaultValue = false
            )]
            public bool IsAccessCodeError { get; set; }

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

            /// <summary>
            /// Date and time at which Seam created the error.
            /// </summary>
            [DataMember(Name = "created_at", IsRequired = false, EmitDefaultValue = false)]
            public string? CreatedAt { get; set; }

            [DataMember(Name = "error_code", IsRequired = true, EmitDefaultValue = false)]
            public override string ErrorCode { get; } = "duplicate_code_on_device";

            /// <summary>
            /// Indicates that this is an access code error.
            /// </summary>
            [DataMember(
                Name = "is_access_code_error",
                IsRequired = false,
                EmitDefaultValue = false
            )]
            public bool IsAccessCodeError { get; set; }

            /// <summary>
            /// ID of the managed access code that conflicts with this managed access code, when Seam can identify it.
            /// </summary>
            [DataMember(
                Name = "managed_access_code_id",
                IsRequired = false,
                EmitDefaultValue = false
            )]
            public string? ManagedAccessCodeId { get; set; }

            /// <summary>
            /// Detailed description of the error. Provides insights into the issue and potentially how to rectify it.
            /// </summary>
            [DataMember(Name = "message", IsRequired = false, EmitDefaultValue = false)]
            public override string Message { get; set; }

            /// <summary>
            /// ID of the unmanaged access code that conflicts with this managed access code, when Seam can identify it.
            /// </summary>
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

            /// <summary>
            /// Date and time at which Seam created the error.
            /// </summary>
            [DataMember(Name = "created_at", IsRequired = false, EmitDefaultValue = false)]
            public string? CreatedAt { get; set; }

            [DataMember(Name = "error_code", IsRequired = true, EmitDefaultValue = false)]
            public override string ErrorCode { get; } = "no_space_for_access_code_on_device";

            /// <summary>
            /// Indicates that this is an access code error.
            /// </summary>
            [DataMember(
                Name = "is_access_code_error",
                IsRequired = false,
                EmitDefaultValue = false
            )]
            public bool IsAccessCodeError { get; set; }

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

            /// <summary>
            /// Indicates the type of external modification. `modified` means the code&apos;s PIN or schedule was changed. `removed` means the code was deleted from the device.
            /// </summary>
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

            /// <summary>
            /// Indicates the type of external modification. `modified` means the code&apos;s PIN or schedule was changed. `removed` means the code was deleted from the device.
            /// </summary>
            [DataMember(Name = "change_type", IsRequired = false, EmitDefaultValue = false)]
            public AccessCodeErrorsConflictingExternalModification.ChangeTypeEnum? ChangeType { get; set; }

            /// <summary>
            /// Date and time at which Seam created the error.
            /// </summary>
            [DataMember(Name = "created_at", IsRequired = false, EmitDefaultValue = false)]
            public string? CreatedAt { get; set; }

            [DataMember(Name = "error_code", IsRequired = true, EmitDefaultValue = false)]
            public override string ErrorCode { get; } = "conflicting_external_modification";

            /// <summary>
            /// Indicates that this is an access code error.
            /// </summary>
            [DataMember(
                Name = "is_access_code_error",
                IsRequired = false,
                EmitDefaultValue = false
            )]
            public bool IsAccessCodeError { get; set; }

            /// <summary>
            /// Detailed description of the error. Provides insights into the issue and potentially how to rectify it.
            /// </summary>
            [DataMember(Name = "message", IsRequired = false, EmitDefaultValue = false)]
            public override string Message { get; set; }

            /// <summary>
            /// List of fields that were changed externally, with their previous and new values.
            /// </summary>
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

            /// <summary>
            /// The name of the field that was changed (e.g. `code`, `starts_at`, `ends_at`).
            /// </summary>
            [DataMember(Name = "field", IsRequired = false, EmitDefaultValue = false)]
            public string Field { get; set; }

            /// <summary>
            /// The previous value of the field.
            /// </summary>
            [DataMember(Name = "from", IsRequired = false, EmitDefaultValue = false)]
            public string? From { get; set; }

            /// <summary>
            /// The new value of the field.
            /// </summary>
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

            /// <summary>
            /// Date and time at which Seam created the error.
            /// </summary>
            [DataMember(Name = "created_at", IsRequired = false, EmitDefaultValue = false)]
            public string? CreatedAt { get; set; }

            [DataMember(Name = "error_code", IsRequired = true, EmitDefaultValue = false)]
            public override string ErrorCode { get; } = "access_code_inactive";

            /// <summary>
            /// Indicates that this is an access code error.
            /// </summary>
            [DataMember(
                Name = "is_access_code_error",
                IsRequired = false,
                EmitDefaultValue = false
            )]
            public bool IsAccessCodeError { get; set; }

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

        [DataContract(Name = "seamModel_accessCodeErrorsCodeConstraintsViolated_model")]
        public class AccessCodeErrorsCodeConstraintsViolated : AccessCodeErrors
        {
            [JsonConstructorAttribute]
            protected AccessCodeErrorsCodeConstraintsViolated() { }

            public AccessCodeErrorsCodeConstraintsViolated(
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

            /// <summary>
            /// Date and time at which Seam created the error.
            /// </summary>
            [DataMember(Name = "created_at", IsRequired = false, EmitDefaultValue = false)]
            public string? CreatedAt { get; set; }

            [DataMember(Name = "error_code", IsRequired = true, EmitDefaultValue = false)]
            public override string ErrorCode { get; } = "code_constraints_violated";

            /// <summary>
            /// Indicates that this is an access code error.
            /// </summary>
            [DataMember(
                Name = "is_access_code_error",
                IsRequired = false,
                EmitDefaultValue = false
            )]
            public bool IsAccessCodeError { get; set; }

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

            /// <summary>
            /// Date and time at which Seam created the error.
            /// </summary>
            [DataMember(Name = "created_at", IsRequired = false, EmitDefaultValue = false)]
            public string CreatedAt { get; set; }

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

            /// <summary>
            /// Date and time at which Seam created the error.
            /// </summary>
            [DataMember(Name = "created_at", IsRequired = false, EmitDefaultValue = false)]
            public string CreatedAt { get; set; }

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

        [DataContract(Name = "seamModel_accessCodeErrorsInsufficientPermissions_model")]
        public class AccessCodeErrorsInsufficientPermissions : AccessCodeErrors
        {
            [JsonConstructorAttribute]
            protected AccessCodeErrorsInsufficientPermissions() { }

            public AccessCodeErrorsInsufficientPermissions(
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
            public string CreatedAt { get; set; }

            [DataMember(Name = "error_code", IsRequired = true, EmitDefaultValue = false)]
            public override string ErrorCode { get; } = "insufficient_permissions";

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

            /// <summary>
            /// Date and time at which Seam created the error.
            /// </summary>
            [DataMember(Name = "created_at", IsRequired = false, EmitDefaultValue = false)]
            public string CreatedAt { get; set; }

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

            /// <summary>
            /// Date and time at which Seam created the error.
            /// </summary>
            [DataMember(Name = "created_at", IsRequired = false, EmitDefaultValue = false)]
            public string CreatedAt { get; set; }

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

            /// <summary>
            /// Date and time at which Seam created the error.
            /// </summary>
            [DataMember(Name = "created_at", IsRequired = false, EmitDefaultValue = false)]
            public string CreatedAt { get; set; }

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

            /// <summary>
            /// Date and time at which Seam created the error.
            /// </summary>
            [DataMember(Name = "created_at", IsRequired = false, EmitDefaultValue = false)]
            public string CreatedAt { get; set; }

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

            /// <summary>
            /// Date and time at which Seam created the error.
            /// </summary>
            [DataMember(Name = "created_at", IsRequired = false, EmitDefaultValue = false)]
            public string CreatedAt { get; set; }

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

            /// <summary>
            /// Date and time at which Seam created the error.
            /// </summary>
            [DataMember(Name = "created_at", IsRequired = false, EmitDefaultValue = false)]
            public string CreatedAt { get; set; }

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

            /// <summary>
            /// Date and time at which Seam created the error.
            /// </summary>
            [DataMember(Name = "created_at", IsRequired = false, EmitDefaultValue = false)]
            public string CreatedAt { get; set; }

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

            /// <summary>
            /// Date and time at which Seam created the error.
            /// </summary>
            [DataMember(Name = "created_at", IsRequired = false, EmitDefaultValue = false)]
            public string CreatedAt { get; set; }

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

            /// <summary>
            /// Date and time at which Seam created the error.
            /// </summary>
            [DataMember(Name = "created_at", IsRequired = false, EmitDefaultValue = false)]
            public string CreatedAt { get; set; }

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

            /// <summary>
            /// Date and time at which Seam created the error.
            /// </summary>
            [DataMember(Name = "created_at", IsRequired = false, EmitDefaultValue = false)]
            public string CreatedAt { get; set; }

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

            /// <summary>
            /// Date and time at which Seam created the error.
            /// </summary>
            [DataMember(Name = "created_at", IsRequired = false, EmitDefaultValue = false)]
            public string CreatedAt { get; set; }

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

            public abstract string CreatedAt { get; set; }

            public abstract string Message { get; set; }

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

            /// <summary>
            /// Date and time at which the mutation was created.
            /// </summary>
            [DataMember(Name = "created_at", IsRequired = false, EmitDefaultValue = false)]
            public override string CreatedAt { get; set; }

            /// <summary>
            /// Detailed description of the mutation.
            /// </summary>
            [DataMember(Name = "message", IsRequired = false, EmitDefaultValue = false)]
            public override string Message { get; set; }

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

            /// <summary>
            /// Date and time at which the mutation was created.
            /// </summary>
            [DataMember(Name = "created_at", IsRequired = false, EmitDefaultValue = false)]
            public override string CreatedAt { get; set; }

            /// <summary>
            /// Detailed description of the mutation.
            /// </summary>
            [DataMember(Name = "message", IsRequired = false, EmitDefaultValue = false)]
            public override string Message { get; set; }

            [DataMember(Name = "mutation_code", IsRequired = true, EmitDefaultValue = false)]
            public override string MutationCode { get; } = "deferring_creation";

            /// <summary>
            /// Date and time at which Seam will attempt to program this access code on the device.
            /// </summary>
            [DataMember(Name = "scheduled_at", IsRequired = false, EmitDefaultValue = false)]
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

            /// <summary>
            /// Date and time at which the mutation was created.
            /// </summary>
            [DataMember(Name = "created_at", IsRequired = false, EmitDefaultValue = false)]
            public override string CreatedAt { get; set; }

            /// <summary>
            /// Detailed description of the mutation.
            /// </summary>
            [DataMember(Name = "message", IsRequired = false, EmitDefaultValue = false)]
            public override string Message { get; set; }

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

            /// <summary>
            /// Date and time at which the mutation was created.
            /// </summary>
            [DataMember(Name = "created_at", IsRequired = false, EmitDefaultValue = false)]
            public override string CreatedAt { get; set; }

            /// <summary>
            /// Previous code configuration.
            /// </summary>
            [DataMember(Name = "from", IsRequired = false, EmitDefaultValue = false)]
            public AccessCodePendingMutationsUpdatingCodeFrom From { get; set; }

            /// <summary>
            /// Detailed description of the mutation.
            /// </summary>
            [DataMember(Name = "message", IsRequired = false, EmitDefaultValue = false)]
            public override string Message { get; set; }

            [DataMember(Name = "mutation_code", IsRequired = true, EmitDefaultValue = false)]
            public override string MutationCode { get; } = "updating_code";

            /// <summary>
            /// New code configuration.
            /// </summary>
            [DataMember(Name = "to", IsRequired = false, EmitDefaultValue = false)]
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

            /// <summary>
            /// Previous PIN code.
            /// </summary>
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

            /// <summary>
            /// New PIN code.
            /// </summary>
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

            /// <summary>
            /// Date and time at which the mutation was created.
            /// </summary>
            [DataMember(Name = "created_at", IsRequired = false, EmitDefaultValue = false)]
            public override string CreatedAt { get; set; }

            /// <summary>
            /// Previous name configuration.
            /// </summary>
            [DataMember(Name = "from", IsRequired = false, EmitDefaultValue = false)]
            public AccessCodePendingMutationsUpdatingNameFrom From { get; set; }

            /// <summary>
            /// Detailed description of the mutation.
            /// </summary>
            [DataMember(Name = "message", IsRequired = false, EmitDefaultValue = false)]
            public override string Message { get; set; }

            [DataMember(Name = "mutation_code", IsRequired = true, EmitDefaultValue = false)]
            public override string MutationCode { get; } = "updating_name";

            /// <summary>
            /// New name configuration.
            /// </summary>
            [DataMember(Name = "to", IsRequired = false, EmitDefaultValue = false)]
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

            /// <summary>
            /// Previous access code name.
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

        [DataContract(Name = "seamModel_accessCodePendingMutationsUpdatingNameTo_model")]
        public class AccessCodePendingMutationsUpdatingNameTo
        {
            [JsonConstructorAttribute]
            protected AccessCodePendingMutationsUpdatingNameTo() { }

            public AccessCodePendingMutationsUpdatingNameTo(string? name = default)
            {
                Name = name;
            }

            /// <summary>
            /// New access code name.
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

            /// <summary>
            /// Date and time at which the mutation was created.
            /// </summary>
            [DataMember(Name = "created_at", IsRequired = false, EmitDefaultValue = false)]
            public override string CreatedAt { get; set; }

            /// <summary>
            /// Previous time frame configuration.
            /// </summary>
            [DataMember(Name = "from", IsRequired = false, EmitDefaultValue = false)]
            public AccessCodePendingMutationsUpdatingTimeFrameFrom From { get; set; }

            /// <summary>
            /// Detailed description of the mutation.
            /// </summary>
            [DataMember(Name = "message", IsRequired = false, EmitDefaultValue = false)]
            public override string Message { get; set; }

            [DataMember(Name = "mutation_code", IsRequired = true, EmitDefaultValue = false)]
            public override string MutationCode { get; } = "updating_time_frame";

            /// <summary>
            /// New time frame configuration.
            /// </summary>
            [DataMember(Name = "to", IsRequired = false, EmitDefaultValue = false)]
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

            /// <summary>
            /// Previous end time for the access code.
            /// </summary>
            [DataMember(Name = "ends_at", IsRequired = false, EmitDefaultValue = false)]
            public string? EndsAt { get; set; }

            /// <summary>
            /// Previous start time for the access code.
            /// </summary>
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

            /// <summary>
            /// New end time for the access code.
            /// </summary>
            [DataMember(Name = "ends_at", IsRequired = false, EmitDefaultValue = false)]
            public string? EndsAt { get; set; }

            /// <summary>
            /// New start time for the access code.
            /// </summary>
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

            public AccessCodePendingMutationsUnrecognized(
                string mutationCode = default,
                string createdAt = default,
                string message = default
            )
            {
                MutationCode = mutationCode;
                CreatedAt = createdAt;
                Message = message;
            }

            [DataMember(Name = "mutation_code", IsRequired = true, EmitDefaultValue = false)]
            public override string MutationCode { get; } = "unrecognized";

            /// <summary>
            /// Date and time at which the mutation was created.
            /// </summary>
            [DataMember(Name = "created_at", IsRequired = false, EmitDefaultValue = false)]
            public override string CreatedAt { get; set; }

            /// <summary>
            /// Detailed description of the mutation.
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
        /// Current status of the access code within the operational lifecycle. Values are `setting`, a transitional phase that indicates that the code is being configured or activated; `set`, which indicates that the code is active and operational; `unset`, which indicates a deactivated or unused state, either before activation or after deliberate deactivation; `removing`, which indicates a transitional period in which the code is being deleted or made inactive; and `unknown`, which indicates an indeterminate state, due to reasons such as system errors or incomplete data, that highlights a potential need for system review or troubleshooting. See also [Lifecycle of Access Codes](https://docs.seam.co/low-level-apis/smart-locks/access-codes/lifecycle-of-access-codes).
        /// </summary>
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

        /// <summary>
        /// Type of the access code. `ongoing` access codes are active continuously until deactivated manually. `time_bound` access codes have a specific duration.
        /// </summary>
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

            public abstract string? CreatedAt { get; set; }

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

            /// <summary>
            /// Date and time at which Seam created the warning.
            /// </summary>
            [DataMember(Name = "created_at", IsRequired = false, EmitDefaultValue = false)]
            public override string? CreatedAt { get; set; }

            /// <summary>
            /// Detailed description of the warning. Provides insights into the issue and potentially how to rectify it.
            /// </summary>
            [DataMember(Name = "message", IsRequired = false, EmitDefaultValue = false)]
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

            /// <summary>
            /// Date and time at which Seam created the warning.
            /// </summary>
            [DataMember(Name = "created_at", IsRequired = false, EmitDefaultValue = false)]
            public override string? CreatedAt { get; set; }

            /// <summary>
            /// Detailed description of the warning. Provides insights into the issue and potentially how to rectify it.
            /// </summary>
            [DataMember(Name = "message", IsRequired = false, EmitDefaultValue = false)]
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

            /// <summary>
            /// Indicates the type of external modification. `modified` means the code&apos;s PIN or schedule was changed. `removed` means the code was deleted from the device.
            /// </summary>
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

            /// <summary>
            /// Indicates the type of external modification. `modified` means the code&apos;s PIN or schedule was changed. `removed` means the code was deleted from the device.
            /// </summary>
            [DataMember(Name = "change_type", IsRequired = false, EmitDefaultValue = false)]
            public AccessCodeWarningsExternalModificationInEffect.ChangeTypeEnum? ChangeType { get; set; }

            /// <summary>
            /// Date and time at which Seam created the warning.
            /// </summary>
            [DataMember(Name = "created_at", IsRequired = false, EmitDefaultValue = false)]
            public override string? CreatedAt { get; set; }

            /// <summary>
            /// Detailed description of the warning. Provides insights into the issue and potentially how to rectify it.
            /// </summary>
            [DataMember(Name = "message", IsRequired = false, EmitDefaultValue = false)]
            public override string Message { get; set; }

            /// <summary>
            /// List of fields that were changed externally, with their previous and new values.
            /// </summary>
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

            /// <summary>
            /// The name of the field that was changed (e.g. `code`, `starts_at`, `ends_at`).
            /// </summary>
            [DataMember(Name = "field", IsRequired = false, EmitDefaultValue = false)]
            public string Field { get; set; }

            /// <summary>
            /// The previous value of the field.
            /// </summary>
            [DataMember(Name = "from", IsRequired = false, EmitDefaultValue = false)]
            public string? From { get; set; }

            /// <summary>
            /// The new value of the field.
            /// </summary>
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

            /// <summary>
            /// Date and time at which Seam created the warning.
            /// </summary>
            [DataMember(Name = "created_at", IsRequired = false, EmitDefaultValue = false)]
            public override string? CreatedAt { get; set; }

            /// <summary>
            /// Detailed description of the warning. Provides insights into the issue and potentially how to rectify it.
            /// </summary>
            [DataMember(Name = "message", IsRequired = false, EmitDefaultValue = false)]
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

            /// <summary>
            /// Date and time at which Seam created the warning.
            /// </summary>
            [DataMember(Name = "created_at", IsRequired = false, EmitDefaultValue = false)]
            public override string? CreatedAt { get; set; }

            /// <summary>
            /// Detailed description of the warning. Provides insights into the issue and potentially how to rectify it.
            /// </summary>
            [DataMember(Name = "message", IsRequired = false, EmitDefaultValue = false)]
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

            /// <summary>
            /// Date and time at which Seam created the warning.
            /// </summary>
            [DataMember(Name = "created_at", IsRequired = false, EmitDefaultValue = false)]
            public override string? CreatedAt { get; set; }

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

            /// <summary>
            /// Date and time at which Seam created the warning.
            /// </summary>
            [DataMember(Name = "created_at", IsRequired = false, EmitDefaultValue = false)]
            public override string? CreatedAt { get; set; }

            /// <summary>
            /// Detailed description of the warning. Provides insights into the issue and potentially how to rectify it.
            /// </summary>
            [DataMember(Name = "message", IsRequired = false, EmitDefaultValue = false)]
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

            /// <summary>
            /// Date and time at which Seam created the warning.
            /// </summary>
            [DataMember(Name = "created_at", IsRequired = false, EmitDefaultValue = false)]
            public override string? CreatedAt { get; set; }

            /// <summary>
            /// Detailed description of the warning. Provides insights into the issue and potentially how to rectify it.
            /// </summary>
            [DataMember(Name = "message", IsRequired = false, EmitDefaultValue = false)]
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

            /// <summary>
            /// Date and time at which Seam created the warning.
            /// </summary>
            [DataMember(Name = "created_at", IsRequired = false, EmitDefaultValue = false)]
            public override string? CreatedAt { get; set; }

            /// <summary>
            /// Detailed description of the warning. Provides insights into the issue and potentially how to rectify it.
            /// </summary>
            [DataMember(Name = "message", IsRequired = false, EmitDefaultValue = false)]
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

            /// <summary>
            /// Date and time at which Seam created the warning.
            /// </summary>
            [DataMember(Name = "created_at", IsRequired = false, EmitDefaultValue = false)]
            public override string? CreatedAt { get; set; }

            /// <summary>
            /// Detailed description of the warning. Provides insights into the issue and potentially how to rectify it.
            /// </summary>
            [DataMember(Name = "message", IsRequired = false, EmitDefaultValue = false)]
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

            /// <summary>
            /// Date and time at which Seam created the warning.
            /// </summary>
            [DataMember(Name = "created_at", IsRequired = false, EmitDefaultValue = false)]
            public override string? CreatedAt { get; set; }

            /// <summary>
            /// Detailed description of the warning. Provides insights into the issue and potentially how to rectify it.
            /// </summary>
            [DataMember(Name = "message", IsRequired = false, EmitDefaultValue = false)]
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
                string? createdAt = default,
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
            public override string? CreatedAt { get; set; }

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
        /// Unique identifier for the access code.
        /// </summary>
        [DataMember(Name = "access_code_id", IsRequired = false, EmitDefaultValue = false)]
        public string AccessCodeId { get; set; }

        /// <summary>
        /// Code used for access. Typically, a numeric or alphanumeric string.
        /// </summary>
        [DataMember(Name = "code", IsRequired = false, EmitDefaultValue = false)]
        public string? Code { get; set; }

        /// <summary>
        /// Unique identifier for a group of access codes that share the same code.
        /// </summary>
        [DataMember(Name = "common_code_key", IsRequired = false, EmitDefaultValue = false)]
        public string? CommonCodeKey { get; set; }

        /// <summary>
        /// Date and time at which the access code was created.
        /// </summary>
        [DataMember(Name = "created_at", IsRequired = false, EmitDefaultValue = false)]
        public string CreatedAt { get; set; }

        /// <summary>
        /// Unique identifier for the device associated with the access code.
        /// </summary>
        [DataMember(Name = "device_id", IsRequired = false, EmitDefaultValue = false)]
        public string DeviceId { get; set; }

        /// <summary>
        /// Metadata for a dormakaba Oracode managed access code. Only present for access codes from dormakaba Oracode devices.
        /// </summary>
        [DataMember(
            Name = "dormakaba_oracode_metadata",
            IsRequired = false,
            EmitDefaultValue = false
        )]
        public AccessCodeDormakabaOracodeMetadata? DormakabaOracodeMetadata { get; set; }

        /// <summary>
        /// Date and time after which the time-bound access code becomes inactive.
        /// </summary>
        [DataMember(Name = "ends_at", IsRequired = false, EmitDefaultValue = false)]
        public string? EndsAt { get; set; }

        /// <summary>
        /// Errors associated with the [access code](https://docs.seam.co/low-level-apis/smart-locks/access-codes).
        /// </summary>
        [DataMember(Name = "errors", IsRequired = false, EmitDefaultValue = false)]
        public List<AccessCodeErrors> Errors { get; set; }

        /// <summary>
        /// Indicates whether the access code is a backup code.
        /// </summary>
        [DataMember(Name = "is_backup", IsRequired = false, EmitDefaultValue = false)]
        public bool? IsBackup { get; set; }

        /// <summary>
        /// Indicates whether a backup access code is available for use if the primary access code is lost or compromised.
        /// </summary>
        [DataMember(
            Name = "is_backup_access_code_available",
            IsRequired = false,
            EmitDefaultValue = false
        )]
        public bool IsBackupAccessCodeAvailable { get; set; }

        /// <summary>
        /// Indicates whether changes to the access code from external sources are permitted.
        /// </summary>
        [DataMember(
            Name = "is_external_modification_allowed",
            IsRequired = false,
            EmitDefaultValue = false
        )]
        public bool IsExternalModificationAllowed { get; set; }

        /// <summary>
        /// Indicates whether Seam manages the access code.
        /// </summary>
        [DataMember(Name = "is_managed", IsRequired = false, EmitDefaultValue = false)]
        public bool IsManaged { get; set; }

        /// <summary>
        /// Indicates whether the access code is intended for use in offline scenarios. If `true`, this code can be created on a device without a network connection.
        /// </summary>
        [DataMember(Name = "is_offline_access_code", IsRequired = false, EmitDefaultValue = false)]
        public bool IsOfflineAccessCode { get; set; }

        /// <summary>
        /// Indicates whether the access code can only be used once. If `true`, the code becomes invalid after the first use.
        /// </summary>
        [DataMember(Name = "is_one_time_use", IsRequired = false, EmitDefaultValue = false)]
        public bool IsOneTimeUse { get; set; }

        /// <summary>
        /// Indicates whether the code is set on the device according to a preconfigured schedule.
        /// </summary>
        [DataMember(Name = "is_scheduled_on_device", IsRequired = false, EmitDefaultValue = false)]
        public bool? IsScheduledOnDevice { get; set; }

        /// <summary>
        /// Indicates whether the access code is waiting for a code assignment.
        /// </summary>
        [DataMember(
            Name = "is_waiting_for_code_assignment",
            IsRequired = false,
            EmitDefaultValue = false
        )]
        public bool? IsWaitingForCodeAssignment { get; set; }

        /// <summary>
        /// Name of the access code. Enables administrators and users to identify the access code easily, especially when there are numerous access codes. Note that the name provided on Seam is used to identify the code on Seam and is not necessarily the name that will appear in the lock provider&apos;s app or on the device. This is because lock providers may have constraints on names, such as length, uniqueness, or characters that can be used. In addition, some lock providers may break down names into components such as `first_name` and `last_name`. To provide a consistent experience, Seam identifies the code on Seam by its name but may modify the name that appears on the lock provider&apos;s app or on the device. For example, Seam may add additional characters or truncate the name to meet provider constraints. To help your users identify codes set by Seam, Seam provides the name exactly as it appears on the lock provider&apos;s app or on the device as a separate property called `appearance`. This is an object with a `name` property and, optionally, `first_name` and `last_name` properties (for providers that break down a name into components).
        /// </summary>
        [DataMember(Name = "name", IsRequired = false, EmitDefaultValue = false)]
        public string? Name { get; set; }

        /// <summary>
        /// Collection of pending mutations for the access code. Indicates changes that Seam is in the process of pushing to the device.
        /// </summary>
        [DataMember(Name = "pending_mutations", IsRequired = false, EmitDefaultValue = false)]
        public List<AccessCodePendingMutations> PendingMutations { get; set; }

        /// <summary>
        /// Identifier of the pulled backup access code. Used to associate the pulled backup access code with the original access code.
        /// </summary>
        [DataMember(
            Name = "pulled_backup_access_code_id",
            IsRequired = false,
            EmitDefaultValue = false
        )]
        public string? PulledBackupAccessCodeId { get; set; }

        /// <summary>
        /// Date and time at which the time-bound access code becomes active.
        /// </summary>
        [DataMember(Name = "starts_at", IsRequired = false, EmitDefaultValue = false)]
        public string? StartsAt { get; set; }

        /// <summary>
        /// Current status of the access code within the operational lifecycle. Values are `setting`, a transitional phase that indicates that the code is being configured or activated; `set`, which indicates that the code is active and operational; `unset`, which indicates a deactivated or unused state, either before activation or after deliberate deactivation; `removing`, which indicates a transitional period in which the code is being deleted or made inactive; and `unknown`, which indicates an indeterminate state, due to reasons such as system errors or incomplete data, that highlights a potential need for system review or troubleshooting. See also [Lifecycle of Access Codes](https://docs.seam.co/low-level-apis/smart-locks/access-codes/lifecycle-of-access-codes).
        /// </summary>
        [DataMember(Name = "status", IsRequired = false, EmitDefaultValue = false)]
        public AccessCode.StatusEnum Status { get; set; }

        /// <summary>
        /// Type of the access code. `ongoing` access codes are active continuously until deactivated manually. `time_bound` access codes have a specific duration.
        /// </summary>
        [DataMember(Name = "type", IsRequired = false, EmitDefaultValue = false)]
        public AccessCode.TypeEnum Type { get; set; }

        /// <summary>
        /// Warnings associated with the [access code](https://docs.seam.co/low-level-apis/smart-locks/access-codes).
        /// </summary>
        [DataMember(Name = "warnings", IsRequired = false, EmitDefaultValue = false)]
        public List<AccessCodeWarnings> Warnings { get; set; }

        /// <summary>
        /// Unique identifier for the Seam workspace associated with the access code.
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

        /// <summary>
        /// Indicates whether the stay can be cancelled via the Dormakaba Oracode API.
        /// </summary>
        [DataMember(Name = "is_cancellable", IsRequired = false, EmitDefaultValue = false)]
        public bool? IsCancellable { get; set; }

        /// <summary>
        /// Indicates whether early check-in is available for this stay.
        /// </summary>
        [DataMember(Name = "is_early_checkin_able", IsRequired = false, EmitDefaultValue = false)]
        public bool? IsEarlyCheckinAble { get; set; }

        /// <summary>
        /// Indicates whether the stay can be extended via the Dormakaba Oracode API.
        /// </summary>
        [DataMember(Name = "is_extendable", IsRequired = false, EmitDefaultValue = false)]
        public bool? IsExtendable { get; set; }

        /// <summary>
        /// Indicates whether the access code can be overridden. When false, the maximum number of overrides has been reached.
        /// </summary>
        [DataMember(Name = "is_overridable", IsRequired = false, EmitDefaultValue = false)]
        public bool? IsOverridable { get; set; }

        /// <summary>
        /// Dormakaba Oracode site name associated with this access code.
        /// </summary>
        [DataMember(Name = "site_name", IsRequired = false, EmitDefaultValue = false)]
        public string? SiteName { get; set; }

        /// <summary>
        /// Dormakaba Oracode stay ID associated with this access code.
        /// </summary>
        [DataMember(Name = "stay_id", IsRequired = false, EmitDefaultValue = false)]
        public float? StayId { get; set; }

        /// <summary>
        /// Dormakaba Oracode user level ID associated with this access code.
        /// </summary>
        [DataMember(Name = "user_level_id", IsRequired = false, EmitDefaultValue = false)]
        public string? UserLevelId { get; set; }

        /// <summary>
        /// Dormakaba Oracode user level name associated with this access code.
        /// </summary>
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
