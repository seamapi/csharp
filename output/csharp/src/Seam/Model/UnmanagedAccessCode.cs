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
            string? code = default,
            string createdAt = default,
            string deviceId = default,
            string? endsAt = default,
            List<UnmanagedAccessCodeErrors> errors = default,
            bool isManaged = default,
            string? name = default,
            string? startsAt = default,
            UnmanagedAccessCode.StatusEnum status = default,
            UnmanagedAccessCode.TypeEnum type = default,
            List<UnmanagedAccessCodeWarnings> warnings = default
        )
        {
            AccessCodeId = accessCodeId;
            Code = code;
            CreatedAt = createdAt;
            DeviceId = deviceId;
            EndsAt = endsAt;
            Errors = errors;
            IsManaged = isManaged;
            Name = name;
            StartsAt = startsAt;
            Status = status;
            Type = type;
            Warnings = warnings;
        }

        [JsonConverter(typeof(JsonSubtypes), "error_code")]
        [JsonSubtypes.KnownSubType(
            typeof(UnmanagedAccessCodeErrorsInvalidCredentials),
            "invalid_credentials"
        )]
        [JsonSubtypes.KnownSubType(
            typeof(UnmanagedAccessCodeErrorsAccountDisconnected),
            "account_disconnected"
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
            typeof(UnmanagedAccessCodeErrorsTtlockLockNotPairedToGateway),
            "ttlock_lock_not_paired_to_gateway"
        )]
        [JsonSubtypes.KnownSubType(
            typeof(UnmanagedAccessCodeErrorsSaltoSiteUserLimitReached),
            "salto_site_user_limit_reached"
        )]
        [JsonSubtypes.KnownSubType(
            typeof(UnmanagedAccessCodeErrorsAugustLockMissingBridge),
            "august_lock_missing_bridge"
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
            typeof(UnmanagedAccessCodeErrorsHubitatNoFreePositionsAvailable),
            "hubitat_no_free_positions_available"
        )]
        [JsonSubtypes.KnownSubType(
            typeof(UnmanagedAccessCodeErrorsHubitatDeviceProgrammingDelay),
            "hubitat_device_programming_delay"
        )]
        [JsonSubtypes.KnownSubType(
            typeof(UnmanagedAccessCodeErrorsSaltoSiteUserNotSubscribed),
            "salto_site_user_not_subscribed"
        )]
        [JsonSubtypes.KnownSubType(
            typeof(UnmanagedAccessCodeErrorsAugustLockMissingKeypad),
            "august_lock_missing_keypad"
        )]
        [JsonSubtypes.KnownSubType(
            typeof(UnmanagedAccessCodeErrorsAugustDeviceSlotsFull),
            "august_device_slots_full"
        )]
        [JsonSubtypes.KnownSubType(
            typeof(UnmanagedAccessCodeErrorsAugustDeviceProgrammingDelay),
            "august_device_programming_delay"
        )]
        [JsonSubtypes.KnownSubType(
            typeof(UnmanagedAccessCodeErrorsAugustLockInvalidCodeLength),
            "august_lock_invalid_code_length"
        )]
        [JsonSubtypes.KnownSubType(
            typeof(UnmanagedAccessCodeErrorsCodeModifiedExternalToSeam),
            "code_modified_external_to_seam"
        )]
        [JsonSubtypes.KnownSubType(
            typeof(UnmanagedAccessCodeErrorsKwiksetUnableToConfirmDeletion),
            "kwikset_unable_to_confirm_deletion"
        )]
        [JsonSubtypes.KnownSubType(
            typeof(UnmanagedAccessCodeErrorsKwiksetUnableToConfirmCode),
            "kwikset_unable_to_confirm_code"
        )]
        [JsonSubtypes.KnownSubType(
            typeof(UnmanagedAccessCodeErrorsIgloohomeOfflineAccessCodeNoVarianceAvailable),
            "igloohome_offline_access_code_no_variance_available"
        )]
        [JsonSubtypes.KnownSubType(
            typeof(UnmanagedAccessCodeErrorsIgloohomeBridgeOffline),
            "igloohome_bridge_offline"
        )]
        [JsonSubtypes.KnownSubType(
            typeof(UnmanagedAccessCodeErrorsIgloohomeBridgeTooManyPendingJobs),
            "igloohome_bridge_too_many_pending_jobs"
        )]
        [JsonSubtypes.KnownSubType(
            typeof(UnmanagedAccessCodeErrorsDuplicateCodeAttemptPrevented),
            "duplicate_code_attempt_prevented"
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
            typeof(UnmanagedAccessCodeErrorsSmartthingsFailedToSetAfterMultipleRetries),
            "smartthings_failed_to_set_after_multiple_retries"
        )]
        [JsonSubtypes.KnownSubType(
            typeof(UnmanagedAccessCodeErrorsSmartthingsFailedToSetAccessCode),
            "smartthings_failed_to_set_access_code"
        )]
        public abstract class UnmanagedAccessCodeErrors
        {
            public abstract string ErrorCode { get; }

            public abstract override string ToString();
        }

        [DataContract(
            Name = "seamModel_unmanagedAccessCodeErrorsSmartthingsFailedToSetAccessCode_model"
        )]
        public class UnmanagedAccessCodeErrorsSmartthingsFailedToSetAccessCode
            : UnmanagedAccessCodeErrors
        {
            [JsonConstructorAttribute]
            protected UnmanagedAccessCodeErrorsSmartthingsFailedToSetAccessCode() { }

            public UnmanagedAccessCodeErrorsSmartthingsFailedToSetAccessCode(
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
            Name = "seamModel_unmanagedAccessCodeErrorsSmartthingsFailedToSetAfterMultipleRetries_model"
        )]
        public class UnmanagedAccessCodeErrorsSmartthingsFailedToSetAfterMultipleRetries
            : UnmanagedAccessCodeErrors
        {
            [JsonConstructorAttribute]
            protected UnmanagedAccessCodeErrorsSmartthingsFailedToSetAfterMultipleRetries() { }

            public UnmanagedAccessCodeErrorsSmartthingsFailedToSetAfterMultipleRetries(
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

        [DataContract(Name = "seamModel_unmanagedAccessCodeErrorsFailedToSetOnDevice_model")]
        public class UnmanagedAccessCodeErrorsFailedToSetOnDevice : UnmanagedAccessCodeErrors
        {
            [JsonConstructorAttribute]
            protected UnmanagedAccessCodeErrorsFailedToSetOnDevice() { }

            public UnmanagedAccessCodeErrorsFailedToSetOnDevice(
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

        [DataContract(Name = "seamModel_unmanagedAccessCodeErrorsFailedToRemoveFromDevice_model")]
        public class UnmanagedAccessCodeErrorsFailedToRemoveFromDevice : UnmanagedAccessCodeErrors
        {
            [JsonConstructorAttribute]
            protected UnmanagedAccessCodeErrorsFailedToRemoveFromDevice() { }

            public UnmanagedAccessCodeErrorsFailedToRemoveFromDevice(
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

        [DataContract(Name = "seamModel_unmanagedAccessCodeErrorsDuplicateCodeOnDevice_model")]
        public class UnmanagedAccessCodeErrorsDuplicateCodeOnDevice : UnmanagedAccessCodeErrors
        {
            [JsonConstructorAttribute]
            protected UnmanagedAccessCodeErrorsDuplicateCodeOnDevice() { }

            public UnmanagedAccessCodeErrorsDuplicateCodeOnDevice(
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

        [DataContract(
            Name = "seamModel_unmanagedAccessCodeErrorsDuplicateCodeAttemptPrevented_model"
        )]
        public class UnmanagedAccessCodeErrorsDuplicateCodeAttemptPrevented
            : UnmanagedAccessCodeErrors
        {
            [JsonConstructorAttribute]
            protected UnmanagedAccessCodeErrorsDuplicateCodeAttemptPrevented() { }

            public UnmanagedAccessCodeErrorsDuplicateCodeAttemptPrevented(
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

        [DataContract(
            Name = "seamModel_unmanagedAccessCodeErrorsIgloohomeBridgeTooManyPendingJobs_model"
        )]
        public class UnmanagedAccessCodeErrorsIgloohomeBridgeTooManyPendingJobs
            : UnmanagedAccessCodeErrors
        {
            [JsonConstructorAttribute]
            protected UnmanagedAccessCodeErrorsIgloohomeBridgeTooManyPendingJobs() { }

            public UnmanagedAccessCodeErrorsIgloohomeBridgeTooManyPendingJobs(
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

        [DataContract(Name = "seamModel_unmanagedAccessCodeErrorsIgloohomeBridgeOffline_model")]
        public class UnmanagedAccessCodeErrorsIgloohomeBridgeOffline : UnmanagedAccessCodeErrors
        {
            [JsonConstructorAttribute]
            protected UnmanagedAccessCodeErrorsIgloohomeBridgeOffline() { }

            public UnmanagedAccessCodeErrorsIgloohomeBridgeOffline(
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
            Name = "seamModel_unmanagedAccessCodeErrorsIgloohomeOfflineAccessCodeNoVarianceAvailable_model"
        )]
        public class UnmanagedAccessCodeErrorsIgloohomeOfflineAccessCodeNoVarianceAvailable
            : UnmanagedAccessCodeErrors
        {
            [JsonConstructorAttribute]
            protected UnmanagedAccessCodeErrorsIgloohomeOfflineAccessCodeNoVarianceAvailable() { }

            public UnmanagedAccessCodeErrorsIgloohomeOfflineAccessCodeNoVarianceAvailable(
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

        [DataContract(Name = "seamModel_unmanagedAccessCodeErrorsKwiksetUnableToConfirmCode_model")]
        public class UnmanagedAccessCodeErrorsKwiksetUnableToConfirmCode : UnmanagedAccessCodeErrors
        {
            [JsonConstructorAttribute]
            protected UnmanagedAccessCodeErrorsKwiksetUnableToConfirmCode() { }

            public UnmanagedAccessCodeErrorsKwiksetUnableToConfirmCode(
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

        [DataContract(
            Name = "seamModel_unmanagedAccessCodeErrorsKwiksetUnableToConfirmDeletion_model"
        )]
        public class UnmanagedAccessCodeErrorsKwiksetUnableToConfirmDeletion
            : UnmanagedAccessCodeErrors
        {
            [JsonConstructorAttribute]
            protected UnmanagedAccessCodeErrorsKwiksetUnableToConfirmDeletion() { }

            public UnmanagedAccessCodeErrorsKwiksetUnableToConfirmDeletion(
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

        [DataContract(Name = "seamModel_unmanagedAccessCodeErrorsCodeModifiedExternalToSeam_model")]
        public class UnmanagedAccessCodeErrorsCodeModifiedExternalToSeam : UnmanagedAccessCodeErrors
        {
            [JsonConstructorAttribute]
            protected UnmanagedAccessCodeErrorsCodeModifiedExternalToSeam() { }

            public UnmanagedAccessCodeErrorsCodeModifiedExternalToSeam(
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

        [DataContract(
            Name = "seamModel_unmanagedAccessCodeErrorsAugustLockInvalidCodeLength_model"
        )]
        public class UnmanagedAccessCodeErrorsAugustLockInvalidCodeLength
            : UnmanagedAccessCodeErrors
        {
            [JsonConstructorAttribute]
            protected UnmanagedAccessCodeErrorsAugustLockInvalidCodeLength() { }

            public UnmanagedAccessCodeErrorsAugustLockInvalidCodeLength(
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

        [DataContract(
            Name = "seamModel_unmanagedAccessCodeErrorsAugustDeviceProgrammingDelay_model"
        )]
        public class UnmanagedAccessCodeErrorsAugustDeviceProgrammingDelay
            : UnmanagedAccessCodeErrors
        {
            [JsonConstructorAttribute]
            protected UnmanagedAccessCodeErrorsAugustDeviceProgrammingDelay() { }

            public UnmanagedAccessCodeErrorsAugustDeviceProgrammingDelay(
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

        [DataContract(Name = "seamModel_unmanagedAccessCodeErrorsAugustDeviceSlotsFull_model")]
        public class UnmanagedAccessCodeErrorsAugustDeviceSlotsFull : UnmanagedAccessCodeErrors
        {
            [JsonConstructorAttribute]
            protected UnmanagedAccessCodeErrorsAugustDeviceSlotsFull() { }

            public UnmanagedAccessCodeErrorsAugustDeviceSlotsFull(
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

        [DataContract(Name = "seamModel_unmanagedAccessCodeErrorsAugustLockMissingKeypad_model")]
        public class UnmanagedAccessCodeErrorsAugustLockMissingKeypad : UnmanagedAccessCodeErrors
        {
            [JsonConstructorAttribute]
            protected UnmanagedAccessCodeErrorsAugustLockMissingKeypad() { }

            public UnmanagedAccessCodeErrorsAugustLockMissingKeypad(
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

        [DataContract(Name = "seamModel_unmanagedAccessCodeErrorsSaltoSiteUserNotSubscribed_model")]
        public class UnmanagedAccessCodeErrorsSaltoSiteUserNotSubscribed : UnmanagedAccessCodeErrors
        {
            [JsonConstructorAttribute]
            protected UnmanagedAccessCodeErrorsSaltoSiteUserNotSubscribed() { }

            public UnmanagedAccessCodeErrorsSaltoSiteUserNotSubscribed(
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

        [DataContract(
            Name = "seamModel_unmanagedAccessCodeErrorsHubitatDeviceProgrammingDelay_model"
        )]
        public class UnmanagedAccessCodeErrorsHubitatDeviceProgrammingDelay
            : UnmanagedAccessCodeErrors
        {
            [JsonConstructorAttribute]
            protected UnmanagedAccessCodeErrorsHubitatDeviceProgrammingDelay() { }

            public UnmanagedAccessCodeErrorsHubitatDeviceProgrammingDelay(
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

        [DataContract(
            Name = "seamModel_unmanagedAccessCodeErrorsHubitatNoFreePositionsAvailable_model"
        )]
        public class UnmanagedAccessCodeErrorsHubitatNoFreePositionsAvailable
            : UnmanagedAccessCodeErrors
        {
            [JsonConstructorAttribute]
            protected UnmanagedAccessCodeErrorsHubitatNoFreePositionsAvailable() { }

            public UnmanagedAccessCodeErrorsHubitatNoFreePositionsAvailable(
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

        [DataContract(Name = "seamModel_unmanagedAccessCodeErrorsDeviceOffline_model")]
        public class UnmanagedAccessCodeErrorsDeviceOffline : UnmanagedAccessCodeErrors
        {
            [JsonConstructorAttribute]
            protected UnmanagedAccessCodeErrorsDeviceOffline() { }

            public UnmanagedAccessCodeErrorsDeviceOffline(
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

        [DataContract(Name = "seamModel_unmanagedAccessCodeErrorsDeviceRemoved_model")]
        public class UnmanagedAccessCodeErrorsDeviceRemoved : UnmanagedAccessCodeErrors
        {
            [JsonConstructorAttribute]
            protected UnmanagedAccessCodeErrorsDeviceRemoved() { }

            public UnmanagedAccessCodeErrorsDeviceRemoved(
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

        [DataContract(Name = "seamModel_unmanagedAccessCodeErrorsHubDisconnected_model")]
        public class UnmanagedAccessCodeErrorsHubDisconnected : UnmanagedAccessCodeErrors
        {
            [JsonConstructorAttribute]
            protected UnmanagedAccessCodeErrorsHubDisconnected() { }

            public UnmanagedAccessCodeErrorsHubDisconnected(
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

        [DataContract(Name = "seamModel_unmanagedAccessCodeErrorsDeviceDisconnected_model")]
        public class UnmanagedAccessCodeErrorsDeviceDisconnected : UnmanagedAccessCodeErrors
        {
            [JsonConstructorAttribute]
            protected UnmanagedAccessCodeErrorsDeviceDisconnected() { }

            public UnmanagedAccessCodeErrorsDeviceDisconnected(
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

        [DataContract(Name = "seamModel_unmanagedAccessCodeErrorsEmptyBackupAccessCodePool_model")]
        public class UnmanagedAccessCodeErrorsEmptyBackupAccessCodePool : UnmanagedAccessCodeErrors
        {
            [JsonConstructorAttribute]
            protected UnmanagedAccessCodeErrorsEmptyBackupAccessCodePool() { }

            public UnmanagedAccessCodeErrorsEmptyBackupAccessCodePool(
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

        [DataContract(Name = "seamModel_unmanagedAccessCodeErrorsAugustLockNotAuthorized_model")]
        public class UnmanagedAccessCodeErrorsAugustLockNotAuthorized : UnmanagedAccessCodeErrors
        {
            [JsonConstructorAttribute]
            protected UnmanagedAccessCodeErrorsAugustLockNotAuthorized() { }

            public UnmanagedAccessCodeErrorsAugustLockNotAuthorized(
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

        [DataContract(Name = "seamModel_unmanagedAccessCodeErrorsAugustLockMissingBridge_model")]
        public class UnmanagedAccessCodeErrorsAugustLockMissingBridge : UnmanagedAccessCodeErrors
        {
            [JsonConstructorAttribute]
            protected UnmanagedAccessCodeErrorsAugustLockMissingBridge() { }

            public UnmanagedAccessCodeErrorsAugustLockMissingBridge(
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

        [DataContract(Name = "seamModel_unmanagedAccessCodeErrorsSaltoSiteUserLimitReached_model")]
        public class UnmanagedAccessCodeErrorsSaltoSiteUserLimitReached : UnmanagedAccessCodeErrors
        {
            [JsonConstructorAttribute]
            protected UnmanagedAccessCodeErrorsSaltoSiteUserLimitReached() { }

            public UnmanagedAccessCodeErrorsSaltoSiteUserLimitReached(
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

        [DataContract(
            Name = "seamModel_unmanagedAccessCodeErrorsTtlockLockNotPairedToGateway_model"
        )]
        public class UnmanagedAccessCodeErrorsTtlockLockNotPairedToGateway
            : UnmanagedAccessCodeErrors
        {
            [JsonConstructorAttribute]
            protected UnmanagedAccessCodeErrorsTtlockLockNotPairedToGateway() { }

            public UnmanagedAccessCodeErrorsTtlockLockNotPairedToGateway(
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

        [DataContract(Name = "seamModel_unmanagedAccessCodeErrorsMissingDeviceCredentials_model")]
        public class UnmanagedAccessCodeErrorsMissingDeviceCredentials : UnmanagedAccessCodeErrors
        {
            [JsonConstructorAttribute]
            protected UnmanagedAccessCodeErrorsMissingDeviceCredentials() { }

            public UnmanagedAccessCodeErrorsMissingDeviceCredentials(
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

        [DataContract(Name = "seamModel_unmanagedAccessCodeErrorsAuxiliaryHeatRunning_model")]
        public class UnmanagedAccessCodeErrorsAuxiliaryHeatRunning : UnmanagedAccessCodeErrors
        {
            [JsonConstructorAttribute]
            protected UnmanagedAccessCodeErrorsAuxiliaryHeatRunning() { }

            public UnmanagedAccessCodeErrorsAuxiliaryHeatRunning(
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

        [DataContract(Name = "seamModel_unmanagedAccessCodeErrorsSubscriptionRequired_model")]
        public class UnmanagedAccessCodeErrorsSubscriptionRequired : UnmanagedAccessCodeErrors
        {
            [JsonConstructorAttribute]
            protected UnmanagedAccessCodeErrorsSubscriptionRequired() { }

            public UnmanagedAccessCodeErrorsSubscriptionRequired(
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

        [DataContract(Name = "seamModel_unmanagedAccessCodeErrorsAccountDisconnected_model")]
        public class UnmanagedAccessCodeErrorsAccountDisconnected : UnmanagedAccessCodeErrors
        {
            [JsonConstructorAttribute]
            protected UnmanagedAccessCodeErrorsAccountDisconnected() { }

            public UnmanagedAccessCodeErrorsAccountDisconnected(
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

        [DataContract(Name = "seamModel_unmanagedAccessCodeErrorsInvalidCredentials_model")]
        public class UnmanagedAccessCodeErrorsInvalidCredentials : UnmanagedAccessCodeErrors
        {
            [JsonConstructorAttribute]
            protected UnmanagedAccessCodeErrorsInvalidCredentials() { }

            public UnmanagedAccessCodeErrorsInvalidCredentials(
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

            [EnumMember(Value = "set")]
            Set = 1,
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
            typeof(UnmanagedAccessCodeWarningsManagementTransferred),
            "management_transferred"
        )]
        [JsonSubtypes.KnownSubType(
            typeof(UnmanagedAccessCodeWarningsIglooAlgopinMustBeUsedWithin_24Hours),
            "igloo_algopin_must_be_used_within_24_hours"
        )]
        [JsonSubtypes.KnownSubType(
            typeof(UnmanagedAccessCodeWarningsAugustDeviceProgrammingDelay),
            "august_device_programming_delay"
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
            typeof(UnmanagedAccessCodeWarningsCodeModifiedExternalToSeam),
            "code_modified_external_to_seam"
        )]
        [JsonSubtypes.KnownSubType(
            typeof(UnmanagedAccessCodeWarningsSchlageCreationOutage),
            "schlage_creation_outage"
        )]
        [JsonSubtypes.KnownSubType(
            typeof(UnmanagedAccessCodeWarningsSchlageDetectedDuplicate),
            "schlage_detected_duplicate"
        )]
        [JsonSubtypes.KnownSubType(
            typeof(UnmanagedAccessCodeWarningsSmartthingsFailedToSetAccessCode),
            "smartthings_failed_to_set_access_code"
        )]
        public abstract class UnmanagedAccessCodeWarnings
        {
            public abstract string WarningCode { get; }

            public abstract override string ToString();
        }

        [DataContract(
            Name = "seamModel_unmanagedAccessCodeWarningsSmartthingsFailedToSetAccessCode_model"
        )]
        public class UnmanagedAccessCodeWarningsSmartthingsFailedToSetAccessCode
            : UnmanagedAccessCodeWarnings
        {
            [JsonConstructorAttribute]
            protected UnmanagedAccessCodeWarningsSmartthingsFailedToSetAccessCode() { }

            public UnmanagedAccessCodeWarningsSmartthingsFailedToSetAccessCode(
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

        [DataContract(Name = "seamModel_unmanagedAccessCodeWarningsSchlageDetectedDuplicate_model")]
        public class UnmanagedAccessCodeWarningsSchlageDetectedDuplicate
            : UnmanagedAccessCodeWarnings
        {
            [JsonConstructorAttribute]
            protected UnmanagedAccessCodeWarningsSchlageDetectedDuplicate() { }

            public UnmanagedAccessCodeWarningsSchlageDetectedDuplicate(
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

        [DataContract(Name = "seamModel_unmanagedAccessCodeWarningsSchlageCreationOutage_model")]
        public class UnmanagedAccessCodeWarningsSchlageCreationOutage : UnmanagedAccessCodeWarnings
        {
            [JsonConstructorAttribute]
            protected UnmanagedAccessCodeWarningsSchlageCreationOutage() { }

            public UnmanagedAccessCodeWarningsSchlageCreationOutage(
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

        [DataContract(
            Name = "seamModel_unmanagedAccessCodeWarningsCodeModifiedExternalToSeam_model"
        )]
        public class UnmanagedAccessCodeWarningsCodeModifiedExternalToSeam
            : UnmanagedAccessCodeWarnings
        {
            [JsonConstructorAttribute]
            protected UnmanagedAccessCodeWarningsCodeModifiedExternalToSeam() { }

            public UnmanagedAccessCodeWarningsCodeModifiedExternalToSeam(
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

        [DataContract(Name = "seamModel_unmanagedAccessCodeWarningsDelayInSettingOnDevice_model")]
        public class UnmanagedAccessCodeWarningsDelayInSettingOnDevice : UnmanagedAccessCodeWarnings
        {
            [JsonConstructorAttribute]
            protected UnmanagedAccessCodeWarningsDelayInSettingOnDevice() { }

            public UnmanagedAccessCodeWarningsDelayInSettingOnDevice(
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

        [DataContract(
            Name = "seamModel_unmanagedAccessCodeWarningsDelayInRemovingFromDevice_model"
        )]
        public class UnmanagedAccessCodeWarningsDelayInRemovingFromDevice
            : UnmanagedAccessCodeWarnings
        {
            [JsonConstructorAttribute]
            protected UnmanagedAccessCodeWarningsDelayInRemovingFromDevice() { }

            public UnmanagedAccessCodeWarningsDelayInRemovingFromDevice(
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

        [DataContract(
            Name = "seamModel_unmanagedAccessCodeWarningsThirdPartyIntegrationDetected_model"
        )]
        public class UnmanagedAccessCodeWarningsThirdPartyIntegrationDetected
            : UnmanagedAccessCodeWarnings
        {
            [JsonConstructorAttribute]
            protected UnmanagedAccessCodeWarningsThirdPartyIntegrationDetected() { }

            public UnmanagedAccessCodeWarningsThirdPartyIntegrationDetected(
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

        [DataContract(
            Name = "seamModel_unmanagedAccessCodeWarningsAugustDeviceProgrammingDelay_model"
        )]
        public class UnmanagedAccessCodeWarningsAugustDeviceProgrammingDelay
            : UnmanagedAccessCodeWarnings
        {
            [JsonConstructorAttribute]
            protected UnmanagedAccessCodeWarningsAugustDeviceProgrammingDelay() { }

            public UnmanagedAccessCodeWarningsAugustDeviceProgrammingDelay(
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
            Name = "seamModel_unmanagedAccessCodeWarningsIglooAlgopinMustBeUsedWithin_24Hours_model"
        )]
        public class UnmanagedAccessCodeWarningsIglooAlgopinMustBeUsedWithin_24Hours
            : UnmanagedAccessCodeWarnings
        {
            [JsonConstructorAttribute]
            protected UnmanagedAccessCodeWarningsIglooAlgopinMustBeUsedWithin_24Hours() { }

            public UnmanagedAccessCodeWarningsIglooAlgopinMustBeUsedWithin_24Hours(
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

        [DataContract(Name = "seamModel_unmanagedAccessCodeWarningsManagementTransferred_model")]
        public class UnmanagedAccessCodeWarningsManagementTransferred : UnmanagedAccessCodeWarnings
        {
            [JsonConstructorAttribute]
            protected UnmanagedAccessCodeWarningsManagementTransferred() { }

            public UnmanagedAccessCodeWarningsManagementTransferred(
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

        [DataMember(Name = "created_at", IsRequired = true, EmitDefaultValue = false)]
        public string CreatedAt { get; set; }

        [DataMember(Name = "device_id", IsRequired = true, EmitDefaultValue = false)]
        public string DeviceId { get; set; }

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

        public override string ToString()
        {
            JsonSerializer jsonSerializer = JsonSerializer.CreateDefault(null);

            StringWriter stringWriter = new StringWriter(
                new StringBuilder(256),
                System.Globalization.CultureInfo.InvariantCulture
            );
            using (JsonTextWriter jsonTextWriter = new JsonTextWriter(stringWriter))
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
