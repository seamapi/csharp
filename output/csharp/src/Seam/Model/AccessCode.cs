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
            string? pulledBackupAccessCodeId = default,
            string? startsAt = default,
            AccessCode.StatusEnum status = default,
            AccessCode.TypeEnum type = default,
            List<AccessCodeWarnings> warnings = default
        )
        {
            AccessCodeId = accessCodeId;
            Code = code;
            CommonCodeKey = commonCodeKey;
            CreatedAt = createdAt;
            DeviceId = deviceId;
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
            PulledBackupAccessCodeId = pulledBackupAccessCodeId;
            StartsAt = startsAt;
            Status = status;
            Type = type;
            Warnings = warnings;
        }

        [JsonConverter(typeof(JsonSubtypes), "error_code")]
        [JsonSubtypes.KnownSubType(
            typeof(AccessCodeErrorsInvalidCredentials),
            "invalid_credentials"
        )]
        [JsonSubtypes.KnownSubType(
            typeof(AccessCodeErrorsAccountDisconnected),
            "account_disconnected"
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
            typeof(AccessCodeErrorsTtlockLockNotPairedToGateway),
            "ttlock_lock_not_paired_to_gateway"
        )]
        [JsonSubtypes.KnownSubType(
            typeof(AccessCodeErrorsSaltoSiteUserLimitReached),
            "salto_site_user_limit_reached"
        )]
        [JsonSubtypes.KnownSubType(
            typeof(AccessCodeErrorsAugustLockMissingBridge),
            "august_lock_missing_bridge"
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
            typeof(AccessCodeErrorsHubitatNoFreePositionsAvailable),
            "hubitat_no_free_positions_available"
        )]
        [JsonSubtypes.KnownSubType(
            typeof(AccessCodeErrorsHubitatDeviceProgrammingDelay),
            "hubitat_device_programming_delay"
        )]
        [JsonSubtypes.KnownSubType(
            typeof(AccessCodeErrorsSaltoSiteUserNotSubscribed),
            "salto_site_user_not_subscribed"
        )]
        [JsonSubtypes.KnownSubType(
            typeof(AccessCodeErrorsAugustLockMissingKeypad),
            "august_lock_missing_keypad"
        )]
        [JsonSubtypes.KnownSubType(
            typeof(AccessCodeErrorsAugustDeviceSlotsFull),
            "august_device_slots_full"
        )]
        [JsonSubtypes.KnownSubType(
            typeof(AccessCodeErrorsAugustDeviceProgrammingDelay),
            "august_device_programming_delay"
        )]
        [JsonSubtypes.KnownSubType(
            typeof(AccessCodeErrorsAugustLockInvalidCodeLength),
            "august_lock_invalid_code_length"
        )]
        [JsonSubtypes.KnownSubType(
            typeof(AccessCodeErrorsCodeModifiedExternalToSeam),
            "code_modified_external_to_seam"
        )]
        [JsonSubtypes.KnownSubType(
            typeof(AccessCodeErrorsKwiksetUnableToConfirmDeletion),
            "kwikset_unable_to_confirm_deletion"
        )]
        [JsonSubtypes.KnownSubType(
            typeof(AccessCodeErrorsKwiksetUnableToConfirmCode),
            "kwikset_unable_to_confirm_code"
        )]
        [JsonSubtypes.KnownSubType(
            typeof(AccessCodeErrorsIgloohomeOfflineAccessCodeNoVarianceAvailable),
            "igloohome_offline_access_code_no_variance_available"
        )]
        [JsonSubtypes.KnownSubType(
            typeof(AccessCodeErrorsIgloohomeBridgeOffline),
            "igloohome_bridge_offline"
        )]
        [JsonSubtypes.KnownSubType(
            typeof(AccessCodeErrorsIgloohomeBridgeTooManyPendingJobs),
            "igloohome_bridge_too_many_pending_jobs"
        )]
        [JsonSubtypes.KnownSubType(
            typeof(AccessCodeErrorsDuplicateCodeAttemptPrevented),
            "duplicate_code_attempt_prevented"
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
        [JsonSubtypes.KnownSubType(
            typeof(AccessCodeErrorsSmartthingsFailedToSetAfterMultipleRetries),
            "smartthings_failed_to_set_after_multiple_retries"
        )]
        [JsonSubtypes.KnownSubType(
            typeof(AccessCodeErrorsSmartthingsFailedToSetAccessCode),
            "smartthings_failed_to_set_access_code"
        )]
        public abstract class AccessCodeErrors
        {
            public abstract string ErrorCode { get; }

            public abstract override string ToString();
        }

        [DataContract(Name = "seamModel_accessCodeErrorsSmartthingsFailedToSetAccessCode_model")]
        public class AccessCodeErrorsSmartthingsFailedToSetAccessCode : AccessCodeErrors
        {
            [JsonConstructorAttribute]
            protected AccessCodeErrorsSmartthingsFailedToSetAccessCode() { }

            public AccessCodeErrorsSmartthingsFailedToSetAccessCode(
                string errorCode = default,
                bool isAccessCodeError = default,
                string message = default
            )
            {
                ErrorCode = errorCode;
                IsAccessCodeError = isAccessCodeError;
                Message = message;
            }

            [DataMember(Name = "error_code", IsRequired = true, EmitDefaultValue = false)]
            public override string ErrorCode { get; } = "smartthings_failed_to_set_access_code";

            [DataMember(Name = "is_access_code_error", IsRequired = true, EmitDefaultValue = false)]
            public bool IsAccessCodeError { get; set; }

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

        [DataContract(
            Name = "seamModel_accessCodeErrorsSmartthingsFailedToSetAfterMultipleRetries_model"
        )]
        public class AccessCodeErrorsSmartthingsFailedToSetAfterMultipleRetries : AccessCodeErrors
        {
            [JsonConstructorAttribute]
            protected AccessCodeErrorsSmartthingsFailedToSetAfterMultipleRetries() { }

            public AccessCodeErrorsSmartthingsFailedToSetAfterMultipleRetries(
                string errorCode = default,
                bool isAccessCodeError = default,
                string message = default
            )
            {
                ErrorCode = errorCode;
                IsAccessCodeError = isAccessCodeError;
                Message = message;
            }

            [DataMember(Name = "error_code", IsRequired = true, EmitDefaultValue = false)]
            public override string ErrorCode { get; } =
                "smartthings_failed_to_set_after_multiple_retries";

            [DataMember(Name = "is_access_code_error", IsRequired = true, EmitDefaultValue = false)]
            public bool IsAccessCodeError { get; set; }

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

        [DataContract(Name = "seamModel_accessCodeErrorsFailedToSetOnDevice_model")]
        public class AccessCodeErrorsFailedToSetOnDevice : AccessCodeErrors
        {
            [JsonConstructorAttribute]
            protected AccessCodeErrorsFailedToSetOnDevice() { }

            public AccessCodeErrorsFailedToSetOnDevice(
                string errorCode = default,
                bool isAccessCodeError = default,
                string message = default
            )
            {
                ErrorCode = errorCode;
                IsAccessCodeError = isAccessCodeError;
                Message = message;
            }

            [DataMember(Name = "error_code", IsRequired = true, EmitDefaultValue = false)]
            public override string ErrorCode { get; } = "failed_to_set_on_device";

            [DataMember(Name = "is_access_code_error", IsRequired = true, EmitDefaultValue = false)]
            public bool IsAccessCodeError { get; set; }

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

        [DataContract(Name = "seamModel_accessCodeErrorsFailedToRemoveFromDevice_model")]
        public class AccessCodeErrorsFailedToRemoveFromDevice : AccessCodeErrors
        {
            [JsonConstructorAttribute]
            protected AccessCodeErrorsFailedToRemoveFromDevice() { }

            public AccessCodeErrorsFailedToRemoveFromDevice(
                string errorCode = default,
                bool isAccessCodeError = default,
                string message = default
            )
            {
                ErrorCode = errorCode;
                IsAccessCodeError = isAccessCodeError;
                Message = message;
            }

            [DataMember(Name = "error_code", IsRequired = true, EmitDefaultValue = false)]
            public override string ErrorCode { get; } = "failed_to_remove_from_device";

            [DataMember(Name = "is_access_code_error", IsRequired = true, EmitDefaultValue = false)]
            public bool IsAccessCodeError { get; set; }

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

        [DataContract(Name = "seamModel_accessCodeErrorsDuplicateCodeOnDevice_model")]
        public class AccessCodeErrorsDuplicateCodeOnDevice : AccessCodeErrors
        {
            [JsonConstructorAttribute]
            protected AccessCodeErrorsDuplicateCodeOnDevice() { }

            public AccessCodeErrorsDuplicateCodeOnDevice(
                string errorCode = default,
                bool isAccessCodeError = default,
                string message = default
            )
            {
                ErrorCode = errorCode;
                IsAccessCodeError = isAccessCodeError;
                Message = message;
            }

            [DataMember(Name = "error_code", IsRequired = true, EmitDefaultValue = false)]
            public override string ErrorCode { get; } = "duplicate_code_on_device";

            [DataMember(Name = "is_access_code_error", IsRequired = true, EmitDefaultValue = false)]
            public bool IsAccessCodeError { get; set; }

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

        [DataContract(Name = "seamModel_accessCodeErrorsDuplicateCodeAttemptPrevented_model")]
        public class AccessCodeErrorsDuplicateCodeAttemptPrevented : AccessCodeErrors
        {
            [JsonConstructorAttribute]
            protected AccessCodeErrorsDuplicateCodeAttemptPrevented() { }

            public AccessCodeErrorsDuplicateCodeAttemptPrevented(
                string errorCode = default,
                bool isAccessCodeError = default,
                string message = default
            )
            {
                ErrorCode = errorCode;
                IsAccessCodeError = isAccessCodeError;
                Message = message;
            }

            [DataMember(Name = "error_code", IsRequired = true, EmitDefaultValue = false)]
            public override string ErrorCode { get; } = "duplicate_code_attempt_prevented";

            [DataMember(Name = "is_access_code_error", IsRequired = true, EmitDefaultValue = false)]
            public bool IsAccessCodeError { get; set; }

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

        [DataContract(Name = "seamModel_accessCodeErrorsIgloohomeBridgeTooManyPendingJobs_model")]
        public class AccessCodeErrorsIgloohomeBridgeTooManyPendingJobs : AccessCodeErrors
        {
            [JsonConstructorAttribute]
            protected AccessCodeErrorsIgloohomeBridgeTooManyPendingJobs() { }

            public AccessCodeErrorsIgloohomeBridgeTooManyPendingJobs(
                string errorCode = default,
                bool isAccessCodeError = default,
                string message = default
            )
            {
                ErrorCode = errorCode;
                IsAccessCodeError = isAccessCodeError;
                Message = message;
            }

            [DataMember(Name = "error_code", IsRequired = true, EmitDefaultValue = false)]
            public override string ErrorCode { get; } = "igloohome_bridge_too_many_pending_jobs";

            [DataMember(Name = "is_access_code_error", IsRequired = true, EmitDefaultValue = false)]
            public bool IsAccessCodeError { get; set; }

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

        [DataContract(Name = "seamModel_accessCodeErrorsIgloohomeBridgeOffline_model")]
        public class AccessCodeErrorsIgloohomeBridgeOffline : AccessCodeErrors
        {
            [JsonConstructorAttribute]
            protected AccessCodeErrorsIgloohomeBridgeOffline() { }

            public AccessCodeErrorsIgloohomeBridgeOffline(
                string errorCode = default,
                bool isAccessCodeError = default,
                string message = default
            )
            {
                ErrorCode = errorCode;
                IsAccessCodeError = isAccessCodeError;
                Message = message;
            }

            [DataMember(Name = "error_code", IsRequired = true, EmitDefaultValue = false)]
            public override string ErrorCode { get; } = "igloohome_bridge_offline";

            [DataMember(Name = "is_access_code_error", IsRequired = true, EmitDefaultValue = false)]
            public bool IsAccessCodeError { get; set; }

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

        [DataContract(
            Name = "seamModel_accessCodeErrorsIgloohomeOfflineAccessCodeNoVarianceAvailable_model"
        )]
        public class AccessCodeErrorsIgloohomeOfflineAccessCodeNoVarianceAvailable
            : AccessCodeErrors
        {
            [JsonConstructorAttribute]
            protected AccessCodeErrorsIgloohomeOfflineAccessCodeNoVarianceAvailable() { }

            public AccessCodeErrorsIgloohomeOfflineAccessCodeNoVarianceAvailable(
                string errorCode = default,
                bool isAccessCodeError = default,
                string message = default
            )
            {
                ErrorCode = errorCode;
                IsAccessCodeError = isAccessCodeError;
                Message = message;
            }

            [DataMember(Name = "error_code", IsRequired = true, EmitDefaultValue = false)]
            public override string ErrorCode { get; } =
                "igloohome_offline_access_code_no_variance_available";

            [DataMember(Name = "is_access_code_error", IsRequired = true, EmitDefaultValue = false)]
            public bool IsAccessCodeError { get; set; }

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

        [DataContract(Name = "seamModel_accessCodeErrorsKwiksetUnableToConfirmCode_model")]
        public class AccessCodeErrorsKwiksetUnableToConfirmCode : AccessCodeErrors
        {
            [JsonConstructorAttribute]
            protected AccessCodeErrorsKwiksetUnableToConfirmCode() { }

            public AccessCodeErrorsKwiksetUnableToConfirmCode(
                string errorCode = default,
                bool isAccessCodeError = default,
                string message = default
            )
            {
                ErrorCode = errorCode;
                IsAccessCodeError = isAccessCodeError;
                Message = message;
            }

            [DataMember(Name = "error_code", IsRequired = true, EmitDefaultValue = false)]
            public override string ErrorCode { get; } = "kwikset_unable_to_confirm_code";

            [DataMember(Name = "is_access_code_error", IsRequired = true, EmitDefaultValue = false)]
            public bool IsAccessCodeError { get; set; }

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

        [DataContract(Name = "seamModel_accessCodeErrorsKwiksetUnableToConfirmDeletion_model")]
        public class AccessCodeErrorsKwiksetUnableToConfirmDeletion : AccessCodeErrors
        {
            [JsonConstructorAttribute]
            protected AccessCodeErrorsKwiksetUnableToConfirmDeletion() { }

            public AccessCodeErrorsKwiksetUnableToConfirmDeletion(
                string errorCode = default,
                bool isAccessCodeError = default,
                string message = default
            )
            {
                ErrorCode = errorCode;
                IsAccessCodeError = isAccessCodeError;
                Message = message;
            }

            [DataMember(Name = "error_code", IsRequired = true, EmitDefaultValue = false)]
            public override string ErrorCode { get; } = "kwikset_unable_to_confirm_deletion";

            [DataMember(Name = "is_access_code_error", IsRequired = true, EmitDefaultValue = false)]
            public bool IsAccessCodeError { get; set; }

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

        [DataContract(Name = "seamModel_accessCodeErrorsCodeModifiedExternalToSeam_model")]
        public class AccessCodeErrorsCodeModifiedExternalToSeam : AccessCodeErrors
        {
            [JsonConstructorAttribute]
            protected AccessCodeErrorsCodeModifiedExternalToSeam() { }

            public AccessCodeErrorsCodeModifiedExternalToSeam(
                string errorCode = default,
                bool isAccessCodeError = default,
                string message = default
            )
            {
                ErrorCode = errorCode;
                IsAccessCodeError = isAccessCodeError;
                Message = message;
            }

            [DataMember(Name = "error_code", IsRequired = true, EmitDefaultValue = false)]
            public override string ErrorCode { get; } = "code_modified_external_to_seam";

            [DataMember(Name = "is_access_code_error", IsRequired = true, EmitDefaultValue = false)]
            public bool IsAccessCodeError { get; set; }

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

        [DataContract(Name = "seamModel_accessCodeErrorsAugustLockInvalidCodeLength_model")]
        public class AccessCodeErrorsAugustLockInvalidCodeLength : AccessCodeErrors
        {
            [JsonConstructorAttribute]
            protected AccessCodeErrorsAugustLockInvalidCodeLength() { }

            public AccessCodeErrorsAugustLockInvalidCodeLength(
                string errorCode = default,
                bool isAccessCodeError = default,
                string message = default
            )
            {
                ErrorCode = errorCode;
                IsAccessCodeError = isAccessCodeError;
                Message = message;
            }

            [DataMember(Name = "error_code", IsRequired = true, EmitDefaultValue = false)]
            public override string ErrorCode { get; } = "august_lock_invalid_code_length";

            [DataMember(Name = "is_access_code_error", IsRequired = true, EmitDefaultValue = false)]
            public bool IsAccessCodeError { get; set; }

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

        [DataContract(Name = "seamModel_accessCodeErrorsAugustDeviceProgrammingDelay_model")]
        public class AccessCodeErrorsAugustDeviceProgrammingDelay : AccessCodeErrors
        {
            [JsonConstructorAttribute]
            protected AccessCodeErrorsAugustDeviceProgrammingDelay() { }

            public AccessCodeErrorsAugustDeviceProgrammingDelay(
                string errorCode = default,
                bool isAccessCodeError = default,
                string message = default
            )
            {
                ErrorCode = errorCode;
                IsAccessCodeError = isAccessCodeError;
                Message = message;
            }

            [DataMember(Name = "error_code", IsRequired = true, EmitDefaultValue = false)]
            public override string ErrorCode { get; } = "august_device_programming_delay";

            [DataMember(Name = "is_access_code_error", IsRequired = true, EmitDefaultValue = false)]
            public bool IsAccessCodeError { get; set; }

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

        [DataContract(Name = "seamModel_accessCodeErrorsAugustDeviceSlotsFull_model")]
        public class AccessCodeErrorsAugustDeviceSlotsFull : AccessCodeErrors
        {
            [JsonConstructorAttribute]
            protected AccessCodeErrorsAugustDeviceSlotsFull() { }

            public AccessCodeErrorsAugustDeviceSlotsFull(
                string errorCode = default,
                bool isAccessCodeError = default,
                string message = default
            )
            {
                ErrorCode = errorCode;
                IsAccessCodeError = isAccessCodeError;
                Message = message;
            }

            [DataMember(Name = "error_code", IsRequired = true, EmitDefaultValue = false)]
            public override string ErrorCode { get; } = "august_device_slots_full";

            [DataMember(Name = "is_access_code_error", IsRequired = true, EmitDefaultValue = false)]
            public bool IsAccessCodeError { get; set; }

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

        [DataContract(Name = "seamModel_accessCodeErrorsAugustLockMissingKeypad_model")]
        public class AccessCodeErrorsAugustLockMissingKeypad : AccessCodeErrors
        {
            [JsonConstructorAttribute]
            protected AccessCodeErrorsAugustLockMissingKeypad() { }

            public AccessCodeErrorsAugustLockMissingKeypad(
                string errorCode = default,
                bool isAccessCodeError = default,
                string message = default
            )
            {
                ErrorCode = errorCode;
                IsAccessCodeError = isAccessCodeError;
                Message = message;
            }

            [DataMember(Name = "error_code", IsRequired = true, EmitDefaultValue = false)]
            public override string ErrorCode { get; } = "august_lock_missing_keypad";

            [DataMember(Name = "is_access_code_error", IsRequired = true, EmitDefaultValue = false)]
            public bool IsAccessCodeError { get; set; }

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

        [DataContract(Name = "seamModel_accessCodeErrorsSaltoSiteUserNotSubscribed_model")]
        public class AccessCodeErrorsSaltoSiteUserNotSubscribed : AccessCodeErrors
        {
            [JsonConstructorAttribute]
            protected AccessCodeErrorsSaltoSiteUserNotSubscribed() { }

            public AccessCodeErrorsSaltoSiteUserNotSubscribed(
                string errorCode = default,
                bool isAccessCodeError = default,
                string message = default
            )
            {
                ErrorCode = errorCode;
                IsAccessCodeError = isAccessCodeError;
                Message = message;
            }

            [DataMember(Name = "error_code", IsRequired = true, EmitDefaultValue = false)]
            public override string ErrorCode { get; } = "salto_site_user_not_subscribed";

            [DataMember(Name = "is_access_code_error", IsRequired = true, EmitDefaultValue = false)]
            public bool IsAccessCodeError { get; set; }

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

        [DataContract(Name = "seamModel_accessCodeErrorsHubitatDeviceProgrammingDelay_model")]
        public class AccessCodeErrorsHubitatDeviceProgrammingDelay : AccessCodeErrors
        {
            [JsonConstructorAttribute]
            protected AccessCodeErrorsHubitatDeviceProgrammingDelay() { }

            public AccessCodeErrorsHubitatDeviceProgrammingDelay(
                string errorCode = default,
                bool isAccessCodeError = default,
                string message = default
            )
            {
                ErrorCode = errorCode;
                IsAccessCodeError = isAccessCodeError;
                Message = message;
            }

            [DataMember(Name = "error_code", IsRequired = true, EmitDefaultValue = false)]
            public override string ErrorCode { get; } = "hubitat_device_programming_delay";

            [DataMember(Name = "is_access_code_error", IsRequired = true, EmitDefaultValue = false)]
            public bool IsAccessCodeError { get; set; }

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

        [DataContract(Name = "seamModel_accessCodeErrorsHubitatNoFreePositionsAvailable_model")]
        public class AccessCodeErrorsHubitatNoFreePositionsAvailable : AccessCodeErrors
        {
            [JsonConstructorAttribute]
            protected AccessCodeErrorsHubitatNoFreePositionsAvailable() { }

            public AccessCodeErrorsHubitatNoFreePositionsAvailable(
                string errorCode = default,
                bool isAccessCodeError = default,
                string message = default
            )
            {
                ErrorCode = errorCode;
                IsAccessCodeError = isAccessCodeError;
                Message = message;
            }

            [DataMember(Name = "error_code", IsRequired = true, EmitDefaultValue = false)]
            public override string ErrorCode { get; } = "hubitat_no_free_positions_available";

            [DataMember(Name = "is_access_code_error", IsRequired = true, EmitDefaultValue = false)]
            public bool IsAccessCodeError { get; set; }

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

        [DataContract(Name = "seamModel_accessCodeErrorsDeviceOffline_model")]
        public class AccessCodeErrorsDeviceOffline : AccessCodeErrors
        {
            [JsonConstructorAttribute]
            protected AccessCodeErrorsDeviceOffline() { }

            public AccessCodeErrorsDeviceOffline(
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

        [DataContract(Name = "seamModel_accessCodeErrorsDeviceRemoved_model")]
        public class AccessCodeErrorsDeviceRemoved : AccessCodeErrors
        {
            [JsonConstructorAttribute]
            protected AccessCodeErrorsDeviceRemoved() { }

            public AccessCodeErrorsDeviceRemoved(
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

        [DataContract(Name = "seamModel_accessCodeErrorsHubDisconnected_model")]
        public class AccessCodeErrorsHubDisconnected : AccessCodeErrors
        {
            [JsonConstructorAttribute]
            protected AccessCodeErrorsHubDisconnected() { }

            public AccessCodeErrorsHubDisconnected(
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

        [DataContract(Name = "seamModel_accessCodeErrorsDeviceDisconnected_model")]
        public class AccessCodeErrorsDeviceDisconnected : AccessCodeErrors
        {
            [JsonConstructorAttribute]
            protected AccessCodeErrorsDeviceDisconnected() { }

            public AccessCodeErrorsDeviceDisconnected(
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

        [DataContract(Name = "seamModel_accessCodeErrorsEmptyBackupAccessCodePool_model")]
        public class AccessCodeErrorsEmptyBackupAccessCodePool : AccessCodeErrors
        {
            [JsonConstructorAttribute]
            protected AccessCodeErrorsEmptyBackupAccessCodePool() { }

            public AccessCodeErrorsEmptyBackupAccessCodePool(
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

        [DataContract(Name = "seamModel_accessCodeErrorsAugustLockNotAuthorized_model")]
        public class AccessCodeErrorsAugustLockNotAuthorized : AccessCodeErrors
        {
            [JsonConstructorAttribute]
            protected AccessCodeErrorsAugustLockNotAuthorized() { }

            public AccessCodeErrorsAugustLockNotAuthorized(
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

        [DataContract(Name = "seamModel_accessCodeErrorsAugustLockMissingBridge_model")]
        public class AccessCodeErrorsAugustLockMissingBridge : AccessCodeErrors
        {
            [JsonConstructorAttribute]
            protected AccessCodeErrorsAugustLockMissingBridge() { }

            public AccessCodeErrorsAugustLockMissingBridge(
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

        [DataContract(Name = "seamModel_accessCodeErrorsSaltoSiteUserLimitReached_model")]
        public class AccessCodeErrorsSaltoSiteUserLimitReached : AccessCodeErrors
        {
            [JsonConstructorAttribute]
            protected AccessCodeErrorsSaltoSiteUserLimitReached() { }

            public AccessCodeErrorsSaltoSiteUserLimitReached(
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

        [DataContract(Name = "seamModel_accessCodeErrorsTtlockLockNotPairedToGateway_model")]
        public class AccessCodeErrorsTtlockLockNotPairedToGateway : AccessCodeErrors
        {
            [JsonConstructorAttribute]
            protected AccessCodeErrorsTtlockLockNotPairedToGateway() { }

            public AccessCodeErrorsTtlockLockNotPairedToGateway(
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

        [DataContract(Name = "seamModel_accessCodeErrorsMissingDeviceCredentials_model")]
        public class AccessCodeErrorsMissingDeviceCredentials : AccessCodeErrors
        {
            [JsonConstructorAttribute]
            protected AccessCodeErrorsMissingDeviceCredentials() { }

            public AccessCodeErrorsMissingDeviceCredentials(
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

        [DataContract(Name = "seamModel_accessCodeErrorsAuxiliaryHeatRunning_model")]
        public class AccessCodeErrorsAuxiliaryHeatRunning : AccessCodeErrors
        {
            [JsonConstructorAttribute]
            protected AccessCodeErrorsAuxiliaryHeatRunning() { }

            public AccessCodeErrorsAuxiliaryHeatRunning(
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

        [DataContract(Name = "seamModel_accessCodeErrorsSubscriptionRequired_model")]
        public class AccessCodeErrorsSubscriptionRequired : AccessCodeErrors
        {
            [JsonConstructorAttribute]
            protected AccessCodeErrorsSubscriptionRequired() { }

            public AccessCodeErrorsSubscriptionRequired(
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

        [DataContract(Name = "seamModel_accessCodeErrorsAccountDisconnected_model")]
        public class AccessCodeErrorsAccountDisconnected : AccessCodeErrors
        {
            [JsonConstructorAttribute]
            protected AccessCodeErrorsAccountDisconnected() { }

            public AccessCodeErrorsAccountDisconnected(
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

        [DataContract(Name = "seamModel_accessCodeErrorsInvalidCredentials_model")]
        public class AccessCodeErrorsInvalidCredentials : AccessCodeErrors
        {
            [JsonConstructorAttribute]
            protected AccessCodeErrorsInvalidCredentials() { }

            public AccessCodeErrorsInvalidCredentials(
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
        [JsonSubtypes.KnownSubType(
            typeof(AccessCodeWarningsManagementTransferred),
            "management_transferred"
        )]
        [JsonSubtypes.KnownSubType(
            typeof(AccessCodeWarningsIglooAlgopinMustBeUsedWithin_24Hours),
            "igloo_algopin_must_be_used_within_24_hours"
        )]
        [JsonSubtypes.KnownSubType(
            typeof(AccessCodeWarningsAugustDeviceProgrammingDelay),
            "august_device_programming_delay"
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
            typeof(AccessCodeWarningsCodeModifiedExternalToSeam),
            "code_modified_external_to_seam"
        )]
        [JsonSubtypes.KnownSubType(typeof(AccessCodeWarningsSaltoOfficeMode), "salto_office_mode")]
        [JsonSubtypes.KnownSubType(
            typeof(AccessCodeWarningsSchlageCreationOutage),
            "schlage_creation_outage"
        )]
        [JsonSubtypes.KnownSubType(
            typeof(AccessCodeWarningsSchlageDetectedDuplicate),
            "schlage_detected_duplicate"
        )]
        [JsonSubtypes.KnownSubType(
            typeof(AccessCodeWarningsSmartthingsFailedToSetAccessCode),
            "smartthings_failed_to_set_access_code"
        )]
        public abstract class AccessCodeWarnings
        {
            public abstract string WarningCode { get; }

            public abstract override string ToString();
        }

        [DataContract(Name = "seamModel_accessCodeWarningsSmartthingsFailedToSetAccessCode_model")]
        public class AccessCodeWarningsSmartthingsFailedToSetAccessCode : AccessCodeWarnings
        {
            [JsonConstructorAttribute]
            protected AccessCodeWarningsSmartthingsFailedToSetAccessCode() { }

            public AccessCodeWarningsSmartthingsFailedToSetAccessCode(
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
            public override string WarningCode { get; } = "smartthings_failed_to_set_access_code";

            public override string ToString()
            {
                JsonSerializer jsonSerializer = JsonSerializer.CreateDefault(null);

                StringWriter stringWriter = new StringWriter(
                    new StringBuilder(256),
                    System.Globalization.CultureInfo.InvariantCulture
                );
                using (JsonTextWriter jsonTextWriter = new JsonTextWriter(stringWriter))
                {
                    jsonTextWriter.IndentChar = ' ';
                    jsonTextWriter.Indentation = 2;
                    jsonTextWriter.Formatting = Formatting.Indented;
                    jsonSerializer.Serialize(jsonTextWriter, this, null);
                }

                return stringWriter.ToString();
            }
        }

        [DataContract(Name = "seamModel_accessCodeWarningsSchlageDetectedDuplicate_model")]
        public class AccessCodeWarningsSchlageDetectedDuplicate : AccessCodeWarnings
        {
            [JsonConstructorAttribute]
            protected AccessCodeWarningsSchlageDetectedDuplicate() { }

            public AccessCodeWarningsSchlageDetectedDuplicate(
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
            public override string WarningCode { get; } = "schlage_detected_duplicate";

            public override string ToString()
            {
                JsonSerializer jsonSerializer = JsonSerializer.CreateDefault(null);

                StringWriter stringWriter = new StringWriter(
                    new StringBuilder(256),
                    System.Globalization.CultureInfo.InvariantCulture
                );
                using (JsonTextWriter jsonTextWriter = new JsonTextWriter(stringWriter))
                {
                    jsonTextWriter.IndentChar = ' ';
                    jsonTextWriter.Indentation = 2;
                    jsonTextWriter.Formatting = Formatting.Indented;
                    jsonSerializer.Serialize(jsonTextWriter, this, null);
                }

                return stringWriter.ToString();
            }
        }

        [DataContract(Name = "seamModel_accessCodeWarningsSchlageCreationOutage_model")]
        public class AccessCodeWarningsSchlageCreationOutage : AccessCodeWarnings
        {
            [JsonConstructorAttribute]
            protected AccessCodeWarningsSchlageCreationOutage() { }

            public AccessCodeWarningsSchlageCreationOutage(
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
            public override string WarningCode { get; } = "schlage_creation_outage";

            public override string ToString()
            {
                JsonSerializer jsonSerializer = JsonSerializer.CreateDefault(null);

                StringWriter stringWriter = new StringWriter(
                    new StringBuilder(256),
                    System.Globalization.CultureInfo.InvariantCulture
                );
                using (JsonTextWriter jsonTextWriter = new JsonTextWriter(stringWriter))
                {
                    jsonTextWriter.IndentChar = ' ';
                    jsonTextWriter.Indentation = 2;
                    jsonTextWriter.Formatting = Formatting.Indented;
                    jsonSerializer.Serialize(jsonTextWriter, this, null);
                }

                return stringWriter.ToString();
            }
        }

        [DataContract(Name = "seamModel_accessCodeWarningsSaltoOfficeMode_model")]
        public class AccessCodeWarningsSaltoOfficeMode : AccessCodeWarnings
        {
            [JsonConstructorAttribute]
            protected AccessCodeWarningsSaltoOfficeMode() { }

            public AccessCodeWarningsSaltoOfficeMode(
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

        [DataContract(Name = "seamModel_accessCodeWarningsCodeModifiedExternalToSeam_model")]
        public class AccessCodeWarningsCodeModifiedExternalToSeam : AccessCodeWarnings
        {
            [JsonConstructorAttribute]
            protected AccessCodeWarningsCodeModifiedExternalToSeam() { }

            public AccessCodeWarningsCodeModifiedExternalToSeam(
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
            public override string WarningCode { get; } = "code_modified_external_to_seam";

            public override string ToString()
            {
                JsonSerializer jsonSerializer = JsonSerializer.CreateDefault(null);

                StringWriter stringWriter = new StringWriter(
                    new StringBuilder(256),
                    System.Globalization.CultureInfo.InvariantCulture
                );
                using (JsonTextWriter jsonTextWriter = new JsonTextWriter(stringWriter))
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

        [DataContract(Name = "seamModel_accessCodeWarningsAugustDeviceProgrammingDelay_model")]
        public class AccessCodeWarningsAugustDeviceProgrammingDelay : AccessCodeWarnings
        {
            [JsonConstructorAttribute]
            protected AccessCodeWarningsAugustDeviceProgrammingDelay() { }

            public AccessCodeWarningsAugustDeviceProgrammingDelay(
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
            public override string WarningCode { get; } = "august_device_programming_delay";

            public override string ToString()
            {
                JsonSerializer jsonSerializer = JsonSerializer.CreateDefault(null);

                StringWriter stringWriter = new StringWriter(
                    new StringBuilder(256),
                    System.Globalization.CultureInfo.InvariantCulture
                );
                using (JsonTextWriter jsonTextWriter = new JsonTextWriter(stringWriter))
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

        public override string ToString()
        {
            JsonSerializer jsonSerializer = JsonSerializer.CreateDefault(null);

            StringWriter stringWriter = new StringWriter(
                new StringBuilder(256),
                System.Globalization.CultureInfo.InvariantCulture
            );
            using (JsonTextWriter jsonTextWriter = new JsonTextWriter(stringWriter))
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
