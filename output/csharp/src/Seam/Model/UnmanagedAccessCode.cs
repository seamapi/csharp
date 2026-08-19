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
    /// Represents an [unmanaged smart lock access code](https://docs.seam.co/low-level-apis/smart-locks/access-codes/migrating-existing-access-codes).
    ///
    /// An access code is a code used for a keypad or pinpad device. Unlike physical keys, which can easily be lost or duplicated, PIN codes can be customized, tracked, and altered on the fly.
    ///
    /// When you create an access code on a device in Seam, it is created as a managed access code. Access codes that exist on a device that were not created through Seam are considered unmanaged codes. We strictly limit the operations that can be performed on unmanaged codes.
    ///
    /// Prior to using Seam to manage your devices, you may have used another lock management system to manage the access codes on your devices. Where possible, we help you keep any existing access codes on devices and transition those codes to ones managed by your Seam workspace.
    ///
    /// Not all providers support unmanaged access codes. The following providers do not support unmanaged access codes:
    ///
    /// - [Kwikset](https://docs.seam.co/device-and-system-integration-guides/kwikset-locks)
    /// </summary>
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
            typeof(UnmanagedAccessCodeErrorsInsufficientPermissions),
            "insufficient_permissions"
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
            typeof(UnmanagedAccessCodeErrorsCodeConstraintsViolated),
            "code_constraints_violated"
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
            public UnmanagedAccessCodeErrorsConflictingExternalModification.ChangeTypeEnum? ChangeType { get; set; }

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

        [DataContract(Name = "seamModel_unmanagedAccessCodeErrorsCodeConstraintsViolated_model")]
        public class UnmanagedAccessCodeErrorsCodeConstraintsViolated : UnmanagedAccessCodeErrors
        {
            [JsonConstructorAttribute]
            protected UnmanagedAccessCodeErrorsCodeConstraintsViolated() { }

            public UnmanagedAccessCodeErrorsCodeConstraintsViolated(
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

        [DataContract(Name = "seamModel_unmanagedAccessCodeErrorsInsufficientPermissions_model")]
        public class UnmanagedAccessCodeErrorsInsufficientPermissions : UnmanagedAccessCodeErrors
        {
            [JsonConstructorAttribute]
            protected UnmanagedAccessCodeErrorsInsufficientPermissions() { }

            public UnmanagedAccessCodeErrorsInsufficientPermissions(
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

        /// <summary>
        /// Current status of the access code within the operational lifecycle. `set` indicates that the code is active and operational. `unset` indicates that the code exists on the provider but is not usable on the device.
        /// </summary>
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

            public abstract string? CreatedAt { get; set; }

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
            public UnmanagedAccessCodeWarningsExternalModificationInEffect.ChangeTypeEnum? ChangeType { get; set; }

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

        [DataContract(Name = "seamModel_unmanagedAccessCodeWarningsUnrecognized_model")]
        public class UnmanagedAccessCodeWarningsUnrecognized : UnmanagedAccessCodeWarnings
        {
            [JsonConstructorAttribute]
            protected UnmanagedAccessCodeWarningsUnrecognized() { }

            public UnmanagedAccessCodeWarningsUnrecognized(
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
        /// Indicates that Seam cannot convert this unmanaged access code to a managed access code. Some providers do not support management of unmanaged access codes through API integrations.
        /// </summary>
        [DataMember(Name = "cannot_be_managed", IsRequired = false, EmitDefaultValue = false)]
        public bool? CannotBeManaged { get; set; }

        /// <summary>
        /// Indicates that Seam cannot delete this unmanaged access code through the provider. If this access code needs to be deleted, it will only be possible from the manufacturer app.
        /// </summary>
        [DataMember(
            Name = "cannot_delete_unmanaged_access_code",
            IsRequired = false,
            EmitDefaultValue = false
        )]
        public bool? CannotDeleteUnmanagedAccessCode { get; set; }

        /// <summary>
        /// Code used for access. Typically, a numeric or alphanumeric string.
        /// </summary>
        [DataMember(Name = "code", IsRequired = false, EmitDefaultValue = false)]
        public string? Code { get; set; }

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
        /// Metadata for a dormakaba Oracode unmanaged access code. Only present for unmanaged access codes from dormakaba Oracode devices.
        /// </summary>
        [DataMember(
            Name = "dormakaba_oracode_metadata",
            IsRequired = false,
            EmitDefaultValue = false
        )]
        public UnmanagedAccessCodeDormakabaOracodeMetadata? DormakabaOracodeMetadata { get; set; }

        /// <summary>
        /// Date and time after which the time-bound access code becomes inactive.
        /// </summary>
        [DataMember(Name = "ends_at", IsRequired = false, EmitDefaultValue = false)]
        public string? EndsAt { get; set; }

        /// <summary>
        /// Errors associated with the [access code](https://docs.seam.co/low-level-apis/smart-locks/access-codes).
        /// </summary>
        [DataMember(Name = "errors", IsRequired = false, EmitDefaultValue = false)]
        public List<UnmanagedAccessCodeErrors> Errors { get; set; }

        /// <summary>
        /// Indicates that Seam does not manage the access code.
        /// </summary>
        [DataMember(Name = "is_managed", IsRequired = false, EmitDefaultValue = false)]
        public bool IsManaged { get; set; }

        /// <summary>
        /// Name of the access code. Enables administrators and users to identify the access code easily, especially when there are numerous access codes. Note that the name provided on Seam is used to identify the code on Seam and is not necessarily the name that will appear in the lock provider&apos;s app or on the device. This is because lock providers may have constraints on names, such as length, uniqueness, or characters that can be used. In addition, some lock providers may break down names into components such as `first_name` and `last_name`. To provide a consistent experience, Seam identifies the code on Seam by its name but may modify the name that appears on the lock provider&apos;s app or on the device. For example, Seam may add additional characters or truncate the name to meet provider constraints. To help your users identify codes set by Seam, Seam provides the name exactly as it appears on the lock provider&apos;s app or on the device as a separate property called `appearance`. This is an object with a `name` property and, optionally, `first_name` and `last_name` properties (for providers that break down a name into components).
        /// </summary>
        [DataMember(Name = "name", IsRequired = false, EmitDefaultValue = false)]
        public string? Name { get; set; }

        /// <summary>
        /// Date and time at which the time-bound access code becomes active.
        /// </summary>
        [DataMember(Name = "starts_at", IsRequired = false, EmitDefaultValue = false)]
        public string? StartsAt { get; set; }

        /// <summary>
        /// Current status of the access code within the operational lifecycle. `set` indicates that the code is active and operational. `unset` indicates that the code exists on the provider but is not usable on the device.
        /// </summary>
        [DataMember(Name = "status", IsRequired = false, EmitDefaultValue = false)]
        public UnmanagedAccessCode.StatusEnum Status { get; set; }

        /// <summary>
        /// Type of the access code. `ongoing` access codes are active continuously until deactivated manually. `time_bound` access codes have a specific duration.
        /// </summary>
        [DataMember(Name = "type", IsRequired = false, EmitDefaultValue = false)]
        public UnmanagedAccessCode.TypeEnum Type { get; set; }

        /// <summary>
        /// Warnings associated with the [access code](https://docs.seam.co/low-level-apis/smart-locks/access-codes).
        /// </summary>
        [DataMember(Name = "warnings", IsRequired = false, EmitDefaultValue = false)]
        public List<UnmanagedAccessCodeWarnings> Warnings { get; set; }

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
