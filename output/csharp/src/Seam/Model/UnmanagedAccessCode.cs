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
            List<Errors> errors = default,
            bool isManaged = default,
            string? name = default,
            string? startsAt = default,
            UnmanagedAccessCode.StatusEnum status = default,
            UnmanagedAccessCode.TypeEnum type = default,
            List<Warnings> warnings = default
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
        [JsonSubtypes.KnownSubType(
            typeof(ErrorsHubitatNoFreePositionsAvailable),
            "hubitat_no_free_positions_available"
        )]
        [JsonSubtypes.KnownSubType(
            typeof(ErrorsHubitatDeviceProgrammingDelay),
            "hubitat_device_programming_delay"
        )]
        [JsonSubtypes.KnownSubType(
            typeof(ErrorsSaltoSiteUserNotSubscribed),
            "salto_site_user_not_subscribed"
        )]
        [JsonSubtypes.KnownSubType(
            typeof(ErrorsAugustLockMissingKeypad),
            "august_lock_missing_keypad"
        )]
        [JsonSubtypes.KnownSubType(typeof(ErrorsAugustDeviceSlotsFull), "august_device_slots_full")]
        [JsonSubtypes.KnownSubType(
            typeof(ErrorsAugustDeviceProgrammingDelay),
            "august_device_programming_delay"
        )]
        [JsonSubtypes.KnownSubType(
            typeof(ErrorsAugustLockInvalidCodeLength),
            "august_lock_invalid_code_length"
        )]
        [JsonSubtypes.KnownSubType(
            typeof(ErrorsCodeModifiedExternalToSeam),
            "code_modified_external_to_seam"
        )]
        [JsonSubtypes.KnownSubType(
            typeof(ErrorsKwiksetUnableToConfirmDeletion),
            "kwikset_unable_to_confirm_deletion"
        )]
        [JsonSubtypes.KnownSubType(
            typeof(ErrorsKwiksetUnableToConfirmCode),
            "kwikset_unable_to_confirm_code"
        )]
        [JsonSubtypes.KnownSubType(
            typeof(ErrorsIgloohomeOfflineAccessCodeNoVarianceAvailable),
            "igloohome_offline_access_code_no_variance_available"
        )]
        [JsonSubtypes.KnownSubType(
            typeof(ErrorsIgloohomeBridgeOffline),
            "igloohome_bridge_offline"
        )]
        [JsonSubtypes.KnownSubType(
            typeof(ErrorsIgloohomeBridgeTooManyPendingJobs),
            "igloohome_bridge_too_many_pending_jobs"
        )]
        [JsonSubtypes.KnownSubType(
            typeof(ErrorsDuplicateCodeAttemptPrevented),
            "duplicate_code_attempt_prevented"
        )]
        [JsonSubtypes.KnownSubType(typeof(ErrorsDuplicateCodeOnDevice), "duplicate_code_on_device")]
        [JsonSubtypes.KnownSubType(
            typeof(ErrorsFailedToRemoveFromDevice),
            "failed_to_remove_from_device"
        )]
        [JsonSubtypes.KnownSubType(typeof(ErrorsFailedToSetOnDevice), "failed_to_set_on_device")]
        [JsonSubtypes.KnownSubType(
            typeof(ErrorsSmartthingsFailedToSetAfterMultipleRetries),
            "smartthings_failed_to_set_after_multiple_retries"
        )]
        [JsonSubtypes.KnownSubType(
            typeof(ErrorsSmartthingsFailedToSetAccessCode),
            "smartthings_failed_to_set_access_code"
        )]
        public abstract class Errors
        {
            public abstract string ErrorCode { get; }

            public abstract override string ToString();
        }

        [DataContract(Name = "seamModel_errorsSmartthingsFailedToSetAccessCode_model")]
        public class ErrorsSmartthingsFailedToSetAccessCode : Errors
        {
            [JsonConstructorAttribute]
            protected ErrorsSmartthingsFailedToSetAccessCode() { }

            public ErrorsSmartthingsFailedToSetAccessCode(
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

        [DataContract(Name = "seamModel_errorsSmartthingsFailedToSetAfterMultipleRetries_model")]
        public class ErrorsSmartthingsFailedToSetAfterMultipleRetries : Errors
        {
            [JsonConstructorAttribute]
            protected ErrorsSmartthingsFailedToSetAfterMultipleRetries() { }

            public ErrorsSmartthingsFailedToSetAfterMultipleRetries(
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

        [DataContract(Name = "seamModel_errorsFailedToSetOnDevice_model")]
        public class ErrorsFailedToSetOnDevice : Errors
        {
            [JsonConstructorAttribute]
            protected ErrorsFailedToSetOnDevice() { }

            public ErrorsFailedToSetOnDevice(
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

        [DataContract(Name = "seamModel_errorsFailedToRemoveFromDevice_model")]
        public class ErrorsFailedToRemoveFromDevice : Errors
        {
            [JsonConstructorAttribute]
            protected ErrorsFailedToRemoveFromDevice() { }

            public ErrorsFailedToRemoveFromDevice(
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

        [DataContract(Name = "seamModel_errorsDuplicateCodeOnDevice_model")]
        public class ErrorsDuplicateCodeOnDevice : Errors
        {
            [JsonConstructorAttribute]
            protected ErrorsDuplicateCodeOnDevice() { }

            public ErrorsDuplicateCodeOnDevice(
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

        [DataContract(Name = "seamModel_errorsDuplicateCodeAttemptPrevented_model")]
        public class ErrorsDuplicateCodeAttemptPrevented : Errors
        {
            [JsonConstructorAttribute]
            protected ErrorsDuplicateCodeAttemptPrevented() { }

            public ErrorsDuplicateCodeAttemptPrevented(
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

        [DataContract(Name = "seamModel_errorsIgloohomeBridgeTooManyPendingJobs_model")]
        public class ErrorsIgloohomeBridgeTooManyPendingJobs : Errors
        {
            [JsonConstructorAttribute]
            protected ErrorsIgloohomeBridgeTooManyPendingJobs() { }

            public ErrorsIgloohomeBridgeTooManyPendingJobs(
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

        [DataContract(Name = "seamModel_errorsIgloohomeBridgeOffline_model")]
        public class ErrorsIgloohomeBridgeOffline : Errors
        {
            [JsonConstructorAttribute]
            protected ErrorsIgloohomeBridgeOffline() { }

            public ErrorsIgloohomeBridgeOffline(
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

        [DataContract(Name = "seamModel_errorsIgloohomeOfflineAccessCodeNoVarianceAvailable_model")]
        public class ErrorsIgloohomeOfflineAccessCodeNoVarianceAvailable : Errors
        {
            [JsonConstructorAttribute]
            protected ErrorsIgloohomeOfflineAccessCodeNoVarianceAvailable() { }

            public ErrorsIgloohomeOfflineAccessCodeNoVarianceAvailable(
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

        [DataContract(Name = "seamModel_errorsKwiksetUnableToConfirmCode_model")]
        public class ErrorsKwiksetUnableToConfirmCode : Errors
        {
            [JsonConstructorAttribute]
            protected ErrorsKwiksetUnableToConfirmCode() { }

            public ErrorsKwiksetUnableToConfirmCode(
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

        [DataContract(Name = "seamModel_errorsKwiksetUnableToConfirmDeletion_model")]
        public class ErrorsKwiksetUnableToConfirmDeletion : Errors
        {
            [JsonConstructorAttribute]
            protected ErrorsKwiksetUnableToConfirmDeletion() { }

            public ErrorsKwiksetUnableToConfirmDeletion(
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

        [DataContract(Name = "seamModel_errorsCodeModifiedExternalToSeam_model")]
        public class ErrorsCodeModifiedExternalToSeam : Errors
        {
            [JsonConstructorAttribute]
            protected ErrorsCodeModifiedExternalToSeam() { }

            public ErrorsCodeModifiedExternalToSeam(
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

        [DataContract(Name = "seamModel_errorsAugustLockInvalidCodeLength_model")]
        public class ErrorsAugustLockInvalidCodeLength : Errors
        {
            [JsonConstructorAttribute]
            protected ErrorsAugustLockInvalidCodeLength() { }

            public ErrorsAugustLockInvalidCodeLength(
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

        [DataContract(Name = "seamModel_errorsAugustDeviceProgrammingDelay_model")]
        public class ErrorsAugustDeviceProgrammingDelay : Errors
        {
            [JsonConstructorAttribute]
            protected ErrorsAugustDeviceProgrammingDelay() { }

            public ErrorsAugustDeviceProgrammingDelay(
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

        [DataContract(Name = "seamModel_errorsAugustDeviceSlotsFull_model")]
        public class ErrorsAugustDeviceSlotsFull : Errors
        {
            [JsonConstructorAttribute]
            protected ErrorsAugustDeviceSlotsFull() { }

            public ErrorsAugustDeviceSlotsFull(
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

        [DataContract(Name = "seamModel_errorsAugustLockMissingKeypad_model")]
        public class ErrorsAugustLockMissingKeypad : Errors
        {
            [JsonConstructorAttribute]
            protected ErrorsAugustLockMissingKeypad() { }

            public ErrorsAugustLockMissingKeypad(
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

        [DataContract(Name = "seamModel_errorsSaltoSiteUserNotSubscribed_model")]
        public class ErrorsSaltoSiteUserNotSubscribed : Errors
        {
            [JsonConstructorAttribute]
            protected ErrorsSaltoSiteUserNotSubscribed() { }

            public ErrorsSaltoSiteUserNotSubscribed(
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

        [DataContract(Name = "seamModel_errorsHubitatDeviceProgrammingDelay_model")]
        public class ErrorsHubitatDeviceProgrammingDelay : Errors
        {
            [JsonConstructorAttribute]
            protected ErrorsHubitatDeviceProgrammingDelay() { }

            public ErrorsHubitatDeviceProgrammingDelay(
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

        [DataContract(Name = "seamModel_errorsHubitatNoFreePositionsAvailable_model")]
        public class ErrorsHubitatNoFreePositionsAvailable : Errors
        {
            [JsonConstructorAttribute]
            protected ErrorsHubitatNoFreePositionsAvailable() { }

            public ErrorsHubitatNoFreePositionsAvailable(
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
        [JsonSubtypes.KnownSubType(typeof(WarningsManagementTransferred), "management_transferred")]
        [JsonSubtypes.KnownSubType(
            typeof(WarningsIglooAlgopinMustBeUsedWithin_24Hours),
            "igloo_algopin_must_be_used_within_24_hours"
        )]
        [JsonSubtypes.KnownSubType(
            typeof(WarningsAugustDeviceProgrammingDelay),
            "august_device_programming_delay"
        )]
        [JsonSubtypes.KnownSubType(
            typeof(WarningsThirdPartyIntegrationDetected),
            "third_party_integration_detected"
        )]
        [JsonSubtypes.KnownSubType(
            typeof(WarningsDelayInRemovingFromDevice),
            "delay_in_removing_from_device"
        )]
        [JsonSubtypes.KnownSubType(
            typeof(WarningsDelayInSettingOnDevice),
            "delay_in_setting_on_device"
        )]
        [JsonSubtypes.KnownSubType(
            typeof(WarningsCodeModifiedExternalToSeam),
            "code_modified_external_to_seam"
        )]
        [JsonSubtypes.KnownSubType(
            typeof(WarningsSchlageCreationOutage),
            "schlage_creation_outage"
        )]
        [JsonSubtypes.KnownSubType(
            typeof(WarningsSchlageDetectedDuplicate),
            "schlage_detected_duplicate"
        )]
        [JsonSubtypes.KnownSubType(
            typeof(WarningsSmartthingsFailedToSetAccessCode),
            "smartthings_failed_to_set_access_code"
        )]
        public abstract class Warnings
        {
            public abstract string WarningCode { get; }

            public abstract override string ToString();
        }

        [DataContract(Name = "seamModel_warningsSmartthingsFailedToSetAccessCode_model")]
        public class WarningsSmartthingsFailedToSetAccessCode : Warnings
        {
            [JsonConstructorAttribute]
            protected WarningsSmartthingsFailedToSetAccessCode() { }

            public WarningsSmartthingsFailedToSetAccessCode(
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

        [DataContract(Name = "seamModel_warningsSchlageDetectedDuplicate_model")]
        public class WarningsSchlageDetectedDuplicate : Warnings
        {
            [JsonConstructorAttribute]
            protected WarningsSchlageDetectedDuplicate() { }

            public WarningsSchlageDetectedDuplicate(
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

        [DataContract(Name = "seamModel_warningsSchlageCreationOutage_model")]
        public class WarningsSchlageCreationOutage : Warnings
        {
            [JsonConstructorAttribute]
            protected WarningsSchlageCreationOutage() { }

            public WarningsSchlageCreationOutage(
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

        [DataContract(Name = "seamModel_warningsCodeModifiedExternalToSeam_model")]
        public class WarningsCodeModifiedExternalToSeam : Warnings
        {
            [JsonConstructorAttribute]
            protected WarningsCodeModifiedExternalToSeam() { }

            public WarningsCodeModifiedExternalToSeam(
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

        [DataContract(Name = "seamModel_warningsDelayInSettingOnDevice_model")]
        public class WarningsDelayInSettingOnDevice : Warnings
        {
            [JsonConstructorAttribute]
            protected WarningsDelayInSettingOnDevice() { }

            public WarningsDelayInSettingOnDevice(
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

        [DataContract(Name = "seamModel_warningsDelayInRemovingFromDevice_model")]
        public class WarningsDelayInRemovingFromDevice : Warnings
        {
            [JsonConstructorAttribute]
            protected WarningsDelayInRemovingFromDevice() { }

            public WarningsDelayInRemovingFromDevice(
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

        [DataContract(Name = "seamModel_warningsAugustDeviceProgrammingDelay_model")]
        public class WarningsAugustDeviceProgrammingDelay : Warnings
        {
            [JsonConstructorAttribute]
            protected WarningsAugustDeviceProgrammingDelay() { }

            public WarningsAugustDeviceProgrammingDelay(
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

        [DataContract(Name = "seamModel_warningsIglooAlgopinMustBeUsedWithin_24Hours_model")]
        public class WarningsIglooAlgopinMustBeUsedWithin_24Hours : Warnings
        {
            [JsonConstructorAttribute]
            protected WarningsIglooAlgopinMustBeUsedWithin_24Hours() { }

            public WarningsIglooAlgopinMustBeUsedWithin_24Hours(
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

        [DataContract(Name = "seamModel_warningsManagementTransferred_model")]
        public class WarningsManagementTransferred : Warnings
        {
            [JsonConstructorAttribute]
            protected WarningsManagementTransferred() { }

            public WarningsManagementTransferred(
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
        public List<Errors> Errors { get; set; }

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
        public List<Warnings> Warnings { get; set; }

        public override string ToString()
        {
            JsonSerializer jsonSerializer = JsonSerializer.CreateDefault(null);

            StringWriter stringWriter = new StringWriter(
                new StringBuilder(256),
                System.Globalization.CultureInfo.InvariantCulture
            );
            using (JsonTextWriter jsonTextWriter = new JsonTextWriter(stringWriter))
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
