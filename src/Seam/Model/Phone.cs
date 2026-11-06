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
    /// Represents an app user&apos;s mobile phone.
    /// </summary>
    [DataContract(Name = "seamModel_phone_model")]
    public class Phone
    {
        [JsonConstructorAttribute]
        protected Phone() { }

        public Phone(
            string createdAt = default,
            object customMetadata = default,
            string deviceId = default,
            Phone.DeviceTypeEnum deviceType = default,
            string displayName = default,
            List<PhoneErrors> errors = default,
            string? nickname = default,
            PhoneProperties properties = default,
            List<PhoneWarnings> warnings = default,
            string workspaceId = default
        )
        {
            CreatedAt = createdAt;
            CustomMetadata = customMetadata;
            DeviceId = deviceId;
            DeviceType = deviceType;
            DisplayName = displayName;
            Errors = errors;
            Nickname = nickname;
            Properties = properties;
            Warnings = warnings;
            WorkspaceId = workspaceId;
        }

        /// <summary>
        /// Type of the phone device, such as `ios_phone` or `android_phone`.
        /// </summary>
        [JsonConverter(typeof(SafeStringEnumConverter))]
        public enum DeviceTypeEnum
        {
            [EnumMember(Value = "unrecognized")]
            Unrecognized = 0,

            [EnumMember(Value = "ios_phone")]
            IosPhone = 1,

            [EnumMember(Value = "android_phone")]
            AndroidPhone = 2,
        }

        [JsonConverter(typeof(JsonSubtypes), "error_code")]
        [JsonSubtypes.FallBackSubType(typeof(PhoneErrorsUnrecognized))]
        [JsonSubtypes.KnownSubType(typeof(PhoneErrorsBridgeDisconnected), "bridge_disconnected")]
        [JsonSubtypes.KnownSubType(
            typeof(PhoneErrorsSubscriptionRequired),
            "subscription_required"
        )]
        [JsonSubtypes.KnownSubType(
            typeof(PhoneErrorsAuxiliaryHeatRunning),
            "auxiliary_heat_running"
        )]
        [JsonSubtypes.KnownSubType(
            typeof(PhoneErrorsMissingDeviceCredentials),
            "missing_device_credentials"
        )]
        [JsonSubtypes.KnownSubType(
            typeof(PhoneErrorsAugustLockNotAuthorized),
            "august_lock_not_authorized"
        )]
        [JsonSubtypes.KnownSubType(
            typeof(PhoneErrorsEmptyBackupAccessCodePool),
            "empty_backup_access_code_pool"
        )]
        [JsonSubtypes.KnownSubType(typeof(PhoneErrorsDeviceDisconnected), "device_disconnected")]
        [JsonSubtypes.KnownSubType(typeof(PhoneErrorsHubDisconnected), "hub_disconnected")]
        [JsonSubtypes.KnownSubType(typeof(PhoneErrorsDeviceRemoved), "device_removed")]
        [JsonSubtypes.KnownSubType(typeof(PhoneErrorsDeviceOffline), "device_offline")]
        [JsonSubtypes.KnownSubType(
            typeof(PhoneErrorsDormakabaSitesDisconnected),
            "dormakaba_sites_disconnected"
        )]
        [JsonSubtypes.KnownSubType(
            typeof(PhoneErrorsInsufficientPermissions),
            "insufficient_permissions"
        )]
        [JsonSubtypes.KnownSubType(
            typeof(PhoneErrorsSaltoKsSubscriptionLimitExceeded),
            "salto_ks_subscription_limit_exceeded"
        )]
        [JsonSubtypes.KnownSubType(typeof(PhoneErrorsAccountDisconnected), "account_disconnected")]
        public abstract class PhoneErrors
        {
            public abstract string ErrorCode { get; }

            public abstract string CreatedAt { get; set; }

            public abstract string Message { get; set; }

            public abstract override string ToString();
        }

        [DataContract(Name = "seamModel_phoneErrorsAccountDisconnected_model")]
        public class PhoneErrorsAccountDisconnected : PhoneErrors
        {
            [JsonConstructorAttribute]
            protected PhoneErrorsAccountDisconnected() { }

            public PhoneErrorsAccountDisconnected(
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
            /// Indicates that the error is a [connected account](https://www.seam.co/docs/api/connected_accounts/object) error.
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

        [DataContract(Name = "seamModel_phoneErrorsSaltoKsSubscriptionLimitExceeded_model")]
        public class PhoneErrorsSaltoKsSubscriptionLimitExceeded : PhoneErrors
        {
            [JsonConstructorAttribute]
            protected PhoneErrorsSaltoKsSubscriptionLimitExceeded() { }

            public PhoneErrorsSaltoKsSubscriptionLimitExceeded(
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
            /// Indicates that the error is a [connected account](https://www.seam.co/docs/api/connected_accounts/object) error.
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

        [DataContract(Name = "seamModel_phoneErrorsInsufficientPermissions_model")]
        public class PhoneErrorsInsufficientPermissions : PhoneErrors
        {
            [JsonConstructorAttribute]
            protected PhoneErrorsInsufficientPermissions() { }

            public PhoneErrorsInsufficientPermissions(
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
            public override string ErrorCode { get; } = "insufficient_permissions";

            /// <summary>
            /// Indicates that the error is a [connected account](https://www.seam.co/docs/api/connected_accounts/object) error.
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

        [DataContract(Name = "seamModel_phoneErrorsDormakabaSitesDisconnected_model")]
        public class PhoneErrorsDormakabaSitesDisconnected : PhoneErrors
        {
            [JsonConstructorAttribute]
            protected PhoneErrorsDormakabaSitesDisconnected() { }

            public PhoneErrorsDormakabaSitesDisconnected(
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
            /// Indicates that the error is a [connected account](https://www.seam.co/docs/api/connected_accounts/object) error.
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

        [DataContract(Name = "seamModel_phoneErrorsDeviceOffline_model")]
        public class PhoneErrorsDeviceOffline : PhoneErrors
        {
            [JsonConstructorAttribute]
            protected PhoneErrorsDeviceOffline() { }

            public PhoneErrorsDeviceOffline(
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

        [DataContract(Name = "seamModel_phoneErrorsDeviceRemoved_model")]
        public class PhoneErrorsDeviceRemoved : PhoneErrors
        {
            [JsonConstructorAttribute]
            protected PhoneErrorsDeviceRemoved() { }

            public PhoneErrorsDeviceRemoved(
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

        [DataContract(Name = "seamModel_phoneErrorsHubDisconnected_model")]
        public class PhoneErrorsHubDisconnected : PhoneErrors
        {
            [JsonConstructorAttribute]
            protected PhoneErrorsHubDisconnected() { }

            public PhoneErrorsHubDisconnected(
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

        [DataContract(Name = "seamModel_phoneErrorsDeviceDisconnected_model")]
        public class PhoneErrorsDeviceDisconnected : PhoneErrors
        {
            [JsonConstructorAttribute]
            protected PhoneErrorsDeviceDisconnected() { }

            public PhoneErrorsDeviceDisconnected(
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

        [DataContract(Name = "seamModel_phoneErrorsEmptyBackupAccessCodePool_model")]
        public class PhoneErrorsEmptyBackupAccessCodePool : PhoneErrors
        {
            [JsonConstructorAttribute]
            protected PhoneErrorsEmptyBackupAccessCodePool() { }

            public PhoneErrorsEmptyBackupAccessCodePool(
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

        [DataContract(Name = "seamModel_phoneErrorsAugustLockNotAuthorized_model")]
        public class PhoneErrorsAugustLockNotAuthorized : PhoneErrors
        {
            [JsonConstructorAttribute]
            protected PhoneErrorsAugustLockNotAuthorized() { }

            public PhoneErrorsAugustLockNotAuthorized(
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

        [DataContract(Name = "seamModel_phoneErrorsMissingDeviceCredentials_model")]
        public class PhoneErrorsMissingDeviceCredentials : PhoneErrors
        {
            [JsonConstructorAttribute]
            protected PhoneErrorsMissingDeviceCredentials() { }

            public PhoneErrorsMissingDeviceCredentials(
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

        [DataContract(Name = "seamModel_phoneErrorsAuxiliaryHeatRunning_model")]
        public class PhoneErrorsAuxiliaryHeatRunning : PhoneErrors
        {
            [JsonConstructorAttribute]
            protected PhoneErrorsAuxiliaryHeatRunning() { }

            public PhoneErrorsAuxiliaryHeatRunning(
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

        [DataContract(Name = "seamModel_phoneErrorsSubscriptionRequired_model")]
        public class PhoneErrorsSubscriptionRequired : PhoneErrors
        {
            [JsonConstructorAttribute]
            protected PhoneErrorsSubscriptionRequired() { }

            public PhoneErrorsSubscriptionRequired(
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

        [DataContract(Name = "seamModel_phoneErrorsBridgeDisconnected_model")]
        public class PhoneErrorsBridgeDisconnected : PhoneErrors
        {
            [JsonConstructorAttribute]
            protected PhoneErrorsBridgeDisconnected() { }

            public PhoneErrorsBridgeDisconnected(
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
            /// Indicates whether the error is related to [Seam Bridge](https://www.seam.co/docs/capability-guides/seam-bridge).
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

        [DataContract(Name = "seamModel_phoneErrorsUnrecognized_model")]
        public class PhoneErrorsUnrecognized : PhoneErrors
        {
            [JsonConstructorAttribute]
            protected PhoneErrorsUnrecognized() { }

            public PhoneErrorsUnrecognized(
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
        [JsonSubtypes.FallBackSubType(typeof(PhoneWarningsUnrecognized))]
        [JsonSubtypes.KnownSubType(
            typeof(PhoneWarningsCloudRecordingNotEnabled),
            "cloud_recording_not_enabled"
        )]
        [JsonSubtypes.KnownSubType(
            typeof(PhoneWarningsMaxAccessCodesReached),
            "max_access_codes_reached"
        )]
        [JsonSubtypes.KnownSubType(
            typeof(PhoneWarningsUnreliableOnlineStatus),
            "unreliable_online_status"
        )]
        [JsonSubtypes.KnownSubType(
            typeof(PhoneWarningsAccessoryKeypadLowBattery),
            "accessory_keypad_low_battery"
        )]
        [JsonSubtypes.KnownSubType(
            typeof(PhoneWarningsAccessoryKeypadSetupRequired),
            "accessory_keypad_setup_required"
        )]
        [JsonSubtypes.KnownSubType(
            typeof(PhoneWarningsKeynestUnsupportedLocker),
            "keynest_unsupported_locker"
        )]
        [JsonSubtypes.KnownSubType(typeof(PhoneWarningsProviderIssue), "provider_issue")]
        [JsonSubtypes.KnownSubType(
            typeof(PhoneWarningsHubRequiredForAdditionalCapabilities),
            "hub_required_for_additional_capabilities"
        )]
        [JsonSubtypes.KnownSubType(
            typeof(PhoneWarningsTwoNDeviceMissingTimezone),
            "two_n_device_missing_timezone"
        )]
        [JsonSubtypes.KnownSubType(typeof(PhoneWarningsTimeZoneMismatch), "time_zone_mismatch")]
        [JsonSubtypes.KnownSubType(typeof(PhoneWarningsTimeZoneUnknown), "time_zone_unknown")]
        [JsonSubtypes.KnownSubType(
            typeof(PhoneWarningsUltraloqTimeZoneUnknown),
            "ultraloq_time_zone_unknown"
        )]
        [JsonSubtypes.KnownSubType(
            typeof(PhoneWarningsLocklyTimeZoneNotConfigured),
            "lockly_time_zone_not_configured"
        )]
        [JsonSubtypes.KnownSubType(
            typeof(PhoneWarningsUnknownIssueWithPhone),
            "unknown_issue_with_phone"
        )]
        [JsonSubtypes.KnownSubType(
            typeof(PhoneWarningsSaltoKsLockAccessCodeSupportRemoved),
            "salto_ks_lock_access_code_support_removed"
        )]
        [JsonSubtypes.KnownSubType(
            typeof(PhoneWarningsSaltoKsSubscriptionLimitAlmostReached),
            "salto_ks_subscription_limit_almost_reached"
        )]
        [JsonSubtypes.KnownSubType(typeof(PhoneWarningsPrivacyMode), "privacy_mode")]
        [JsonSubtypes.KnownSubType(
            typeof(PhoneWarningsSaltoKsPrivacyMode),
            "salto_ks_privacy_mode"
        )]
        [JsonSubtypes.KnownSubType(typeof(PhoneWarningsSaltoKsOfficeMode), "salto_ks_office_mode")]
        [JsonSubtypes.KnownSubType(
            typeof(PhoneWarningsDeviceHasFlakyConnection),
            "device_has_flaky_connection"
        )]
        [JsonSubtypes.KnownSubType(
            typeof(PhoneWarningsScheduledMaintenanceWindow),
            "scheduled_maintenance_window"
        )]
        [JsonSubtypes.KnownSubType(
            typeof(PhoneWarningsDeviceCommunicationDegraded),
            "device_communication_degraded"
        )]
        [JsonSubtypes.KnownSubType(
            typeof(PhoneWarningsTemperatureThresholdExceeded),
            "temperature_threshold_exceeded"
        )]
        [JsonSubtypes.KnownSubType(typeof(PhoneWarningsPowerSavingMode), "power_saving_mode")]
        [JsonSubtypes.KnownSubType(
            typeof(PhoneWarningsTtlockWeakGatewaySignal),
            "ttlock_weak_gateway_signal"
        )]
        [JsonSubtypes.KnownSubType(
            typeof(PhoneWarningsTtlockLockGatewayUnlockingNotEnabled),
            "ttlock_lock_gateway_unlocking_not_enabled"
        )]
        [JsonSubtypes.KnownSubType(
            typeof(PhoneWarningsThirdPartyIntegrationDetected),
            "third_party_integration_detected"
        )]
        [JsonSubtypes.KnownSubType(
            typeof(PhoneWarningsManyActiveBackupCodes),
            "many_active_backup_codes"
        )]
        [JsonSubtypes.KnownSubType(
            typeof(PhoneWarningsPartialBackupAccessCodePool),
            "partial_backup_access_code_pool"
        )]
        public abstract class PhoneWarnings
        {
            public abstract string WarningCode { get; }

            public abstract string CreatedAt { get; set; }

            public abstract string Message { get; set; }

            public abstract override string ToString();
        }

        [DataContract(Name = "seamModel_phoneWarningsPartialBackupAccessCodePool_model")]
        public class PhoneWarningsPartialBackupAccessCodePool : PhoneWarnings
        {
            [JsonConstructorAttribute]
            protected PhoneWarningsPartialBackupAccessCodePool() { }

            public PhoneWarningsPartialBackupAccessCodePool(
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

        [DataContract(Name = "seamModel_phoneWarningsManyActiveBackupCodes_model")]
        public class PhoneWarningsManyActiveBackupCodes : PhoneWarnings
        {
            [JsonConstructorAttribute]
            protected PhoneWarningsManyActiveBackupCodes() { }

            public PhoneWarningsManyActiveBackupCodes(
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

        [DataContract(Name = "seamModel_phoneWarningsThirdPartyIntegrationDetected_model")]
        public class PhoneWarningsThirdPartyIntegrationDetected : PhoneWarnings
        {
            [JsonConstructorAttribute]
            protected PhoneWarningsThirdPartyIntegrationDetected() { }

            public PhoneWarningsThirdPartyIntegrationDetected(
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

        [DataContract(Name = "seamModel_phoneWarningsTtlockLockGatewayUnlockingNotEnabled_model")]
        public class PhoneWarningsTtlockLockGatewayUnlockingNotEnabled : PhoneWarnings
        {
            [JsonConstructorAttribute]
            protected PhoneWarningsTtlockLockGatewayUnlockingNotEnabled() { }

            public PhoneWarningsTtlockLockGatewayUnlockingNotEnabled(
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

        [DataContract(Name = "seamModel_phoneWarningsTtlockWeakGatewaySignal_model")]
        public class PhoneWarningsTtlockWeakGatewaySignal : PhoneWarnings
        {
            [JsonConstructorAttribute]
            protected PhoneWarningsTtlockWeakGatewaySignal() { }

            public PhoneWarningsTtlockWeakGatewaySignal(
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

        [DataContract(Name = "seamModel_phoneWarningsPowerSavingMode_model")]
        public class PhoneWarningsPowerSavingMode : PhoneWarnings
        {
            [JsonConstructorAttribute]
            protected PhoneWarningsPowerSavingMode() { }

            public PhoneWarningsPowerSavingMode(
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

        [DataContract(Name = "seamModel_phoneWarningsTemperatureThresholdExceeded_model")]
        public class PhoneWarningsTemperatureThresholdExceeded : PhoneWarnings
        {
            [JsonConstructorAttribute]
            protected PhoneWarningsTemperatureThresholdExceeded() { }

            public PhoneWarningsTemperatureThresholdExceeded(
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

        [DataContract(Name = "seamModel_phoneWarningsDeviceCommunicationDegraded_model")]
        public class PhoneWarningsDeviceCommunicationDegraded : PhoneWarnings
        {
            [JsonConstructorAttribute]
            protected PhoneWarningsDeviceCommunicationDegraded() { }

            public PhoneWarningsDeviceCommunicationDegraded(
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

        [DataContract(Name = "seamModel_phoneWarningsScheduledMaintenanceWindow_model")]
        public class PhoneWarningsScheduledMaintenanceWindow : PhoneWarnings
        {
            [JsonConstructorAttribute]
            protected PhoneWarningsScheduledMaintenanceWindow() { }

            public PhoneWarningsScheduledMaintenanceWindow(
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

        [DataContract(Name = "seamModel_phoneWarningsDeviceHasFlakyConnection_model")]
        public class PhoneWarningsDeviceHasFlakyConnection : PhoneWarnings
        {
            [JsonConstructorAttribute]
            protected PhoneWarningsDeviceHasFlakyConnection() { }

            public PhoneWarningsDeviceHasFlakyConnection(
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

        [DataContract(Name = "seamModel_phoneWarningsSaltoKsOfficeMode_model")]
        public class PhoneWarningsSaltoKsOfficeMode : PhoneWarnings
        {
            [JsonConstructorAttribute]
            protected PhoneWarningsSaltoKsOfficeMode() { }

            public PhoneWarningsSaltoKsOfficeMode(
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

        [DataContract(Name = "seamModel_phoneWarningsSaltoKsPrivacyMode_model")]
        public class PhoneWarningsSaltoKsPrivacyMode : PhoneWarnings
        {
            [JsonConstructorAttribute]
            protected PhoneWarningsSaltoKsPrivacyMode() { }

            public PhoneWarningsSaltoKsPrivacyMode(
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

        [DataContract(Name = "seamModel_phoneWarningsPrivacyMode_model")]
        public class PhoneWarningsPrivacyMode : PhoneWarnings
        {
            [JsonConstructorAttribute]
            protected PhoneWarningsPrivacyMode() { }

            public PhoneWarningsPrivacyMode(
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

        [DataContract(Name = "seamModel_phoneWarningsSaltoKsSubscriptionLimitAlmostReached_model")]
        public class PhoneWarningsSaltoKsSubscriptionLimitAlmostReached : PhoneWarnings
        {
            [JsonConstructorAttribute]
            protected PhoneWarningsSaltoKsSubscriptionLimitAlmostReached() { }

            public PhoneWarningsSaltoKsSubscriptionLimitAlmostReached(
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

        [DataContract(Name = "seamModel_phoneWarningsSaltoKsLockAccessCodeSupportRemoved_model")]
        public class PhoneWarningsSaltoKsLockAccessCodeSupportRemoved : PhoneWarnings
        {
            [JsonConstructorAttribute]
            protected PhoneWarningsSaltoKsLockAccessCodeSupportRemoved() { }

            public PhoneWarningsSaltoKsLockAccessCodeSupportRemoved(
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

        [DataContract(Name = "seamModel_phoneWarningsUnknownIssueWithPhone_model")]
        public class PhoneWarningsUnknownIssueWithPhone : PhoneWarnings
        {
            [JsonConstructorAttribute]
            protected PhoneWarningsUnknownIssueWithPhone() { }

            public PhoneWarningsUnknownIssueWithPhone(
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

        [DataContract(Name = "seamModel_phoneWarningsLocklyTimeZoneNotConfigured_model")]
        public class PhoneWarningsLocklyTimeZoneNotConfigured : PhoneWarnings
        {
            [JsonConstructorAttribute]
            protected PhoneWarningsLocklyTimeZoneNotConfigured() { }

            public PhoneWarningsLocklyTimeZoneNotConfigured(
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

        [DataContract(Name = "seamModel_phoneWarningsUltraloqTimeZoneUnknown_model")]
        public class PhoneWarningsUltraloqTimeZoneUnknown : PhoneWarnings
        {
            [JsonConstructorAttribute]
            protected PhoneWarningsUltraloqTimeZoneUnknown() { }

            public PhoneWarningsUltraloqTimeZoneUnknown(
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

        [DataContract(Name = "seamModel_phoneWarningsTimeZoneUnknown_model")]
        public class PhoneWarningsTimeZoneUnknown : PhoneWarnings
        {
            [JsonConstructorAttribute]
            protected PhoneWarningsTimeZoneUnknown() { }

            public PhoneWarningsTimeZoneUnknown(
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

        [DataContract(Name = "seamModel_phoneWarningsTimeZoneMismatch_model")]
        public class PhoneWarningsTimeZoneMismatch : PhoneWarnings
        {
            [JsonConstructorAttribute]
            protected PhoneWarningsTimeZoneMismatch() { }

            public PhoneWarningsTimeZoneMismatch(
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

        [DataContract(Name = "seamModel_phoneWarningsTwoNDeviceMissingTimezone_model")]
        public class PhoneWarningsTwoNDeviceMissingTimezone : PhoneWarnings
        {
            [JsonConstructorAttribute]
            protected PhoneWarningsTwoNDeviceMissingTimezone() { }

            public PhoneWarningsTwoNDeviceMissingTimezone(
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

        [DataContract(Name = "seamModel_phoneWarningsHubRequiredForAdditionalCapabilities_model")]
        public class PhoneWarningsHubRequiredForAdditionalCapabilities : PhoneWarnings
        {
            [JsonConstructorAttribute]
            protected PhoneWarningsHubRequiredForAdditionalCapabilities() { }

            public PhoneWarningsHubRequiredForAdditionalCapabilities(
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

        [DataContract(Name = "seamModel_phoneWarningsProviderIssue_model")]
        public class PhoneWarningsProviderIssue : PhoneWarnings
        {
            [JsonConstructorAttribute]
            protected PhoneWarningsProviderIssue() { }

            public PhoneWarningsProviderIssue(
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

        [DataContract(Name = "seamModel_phoneWarningsKeynestUnsupportedLocker_model")]
        public class PhoneWarningsKeynestUnsupportedLocker : PhoneWarnings
        {
            [JsonConstructorAttribute]
            protected PhoneWarningsKeynestUnsupportedLocker() { }

            public PhoneWarningsKeynestUnsupportedLocker(
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

        [DataContract(Name = "seamModel_phoneWarningsAccessoryKeypadSetupRequired_model")]
        public class PhoneWarningsAccessoryKeypadSetupRequired : PhoneWarnings
        {
            [JsonConstructorAttribute]
            protected PhoneWarningsAccessoryKeypadSetupRequired() { }

            public PhoneWarningsAccessoryKeypadSetupRequired(
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

        [DataContract(Name = "seamModel_phoneWarningsAccessoryKeypadLowBattery_model")]
        public class PhoneWarningsAccessoryKeypadLowBattery : PhoneWarnings
        {
            [JsonConstructorAttribute]
            protected PhoneWarningsAccessoryKeypadLowBattery() { }

            public PhoneWarningsAccessoryKeypadLowBattery(
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
            public override string WarningCode { get; } = "accessory_keypad_low_battery";

            public override string ToString()
            {
                JsonSerializer jsonSerializer = JsonSerializer.CreateDefault(null);

                StringWriter stringWriter = new StringWriter(
                    new StringBuilder(256),
                    System.Globalization.CultureInfo.InvariantCulture
                );
                using (JsonTextWriter jsonTextWriter = new JsonTextWriter(stringWriter))
                {
                    jsonTextWriter.IndentChar = ' ';
                    jsonTextWriter.Indentation = 2;
                    jsonTextWriter.Formatting = Formatting.Indented;
                    jsonSerializer.Serialize(jsonTextWriter, this, null);
                }

                return stringWriter.ToString();
            }
        }

        [DataContract(Name = "seamModel_phoneWarningsUnreliableOnlineStatus_model")]
        public class PhoneWarningsUnreliableOnlineStatus : PhoneWarnings
        {
            [JsonConstructorAttribute]
            protected PhoneWarningsUnreliableOnlineStatus() { }

            public PhoneWarningsUnreliableOnlineStatus(
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

        [DataContract(Name = "seamModel_phoneWarningsMaxAccessCodesReached_model")]
        public class PhoneWarningsMaxAccessCodesReached : PhoneWarnings
        {
            [JsonConstructorAttribute]
            protected PhoneWarningsMaxAccessCodesReached() { }

            public PhoneWarningsMaxAccessCodesReached(
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

        [DataContract(Name = "seamModel_phoneWarningsCloudRecordingNotEnabled_model")]
        public class PhoneWarningsCloudRecordingNotEnabled : PhoneWarnings
        {
            [JsonConstructorAttribute]
            protected PhoneWarningsCloudRecordingNotEnabled() { }

            public PhoneWarningsCloudRecordingNotEnabled(
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
            public override string WarningCode { get; } = "cloud_recording_not_enabled";

            public override string ToString()
            {
                JsonSerializer jsonSerializer = JsonSerializer.CreateDefault(null);

                StringWriter stringWriter = new StringWriter(
                    new StringBuilder(256),
                    System.Globalization.CultureInfo.InvariantCulture
                );
                using (JsonTextWriter jsonTextWriter = new JsonTextWriter(stringWriter))
                {
                    jsonTextWriter.IndentChar = ' ';
                    jsonTextWriter.Indentation = 2;
                    jsonTextWriter.Formatting = Formatting.Indented;
                    jsonSerializer.Serialize(jsonTextWriter, this, null);
                }

                return stringWriter.ToString();
            }
        }

        [DataContract(Name = "seamModel_phoneWarningsUnrecognized_model")]
        public class PhoneWarningsUnrecognized : PhoneWarnings
        {
            [JsonConstructorAttribute]
            protected PhoneWarningsUnrecognized() { }

            public PhoneWarningsUnrecognized(
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
        /// Date and time at which the phone was created.
        /// </summary>
        [DataMember(Name = "created_at", IsRequired = false, EmitDefaultValue = false)]
        public string CreatedAt { get; set; }

        /// <summary>
        /// Optional [custom metadata](https://www.seam.co/docs/core-concepts/devices/adding-custom-metadata-to-a-device) for the phone.
        /// </summary>
        [DataMember(Name = "custom_metadata", IsRequired = false, EmitDefaultValue = false)]
        public object CustomMetadata { get; set; }

        /// <summary>
        /// ID of the phone.
        /// </summary>
        [DataMember(Name = "device_id", IsRequired = false, EmitDefaultValue = false)]
        public string DeviceId { get; set; }

        /// <summary>
        /// Type of the phone device, such as `ios_phone` or `android_phone`.
        /// </summary>
        [DataMember(Name = "device_type", IsRequired = false, EmitDefaultValue = false)]
        public Phone.DeviceTypeEnum DeviceType { get; set; }

        /// <summary>
        /// Display name of the phone. Defaults to `nickname` (if it is set) or `properties.appearance.name`, otherwise. Enables administrators and users to identify the phone easily, especially when there are numerous phones.
        /// </summary>
        [DataMember(Name = "display_name", IsRequired = false, EmitDefaultValue = false)]
        public string DisplayName { get; set; }

        /// <summary>
        /// Array of errors associated with the device. Each error object within the array contains two fields: `error_code` and `message`. `error_code` is a string that uniquely identifies the type of error, enabling quick recognition and categorization of the issue. `message` provides a more detailed description of the error, offering insights into the issue and potentially how to rectify it.
        /// </summary>
        [DataMember(Name = "errors", IsRequired = false, EmitDefaultValue = false)]
        public List<PhoneErrors> Errors { get; set; }

        /// <summary>
        /// Optional nickname to describe the phone, settable through Seam.
        /// </summary>
        [DataMember(Name = "nickname", IsRequired = false, EmitDefaultValue = false)]
        public string? Nickname { get; set; }

        /// <summary>
        /// Properties of the phone.
        /// </summary>
        [DataMember(Name = "properties", IsRequired = false, EmitDefaultValue = false)]
        public PhoneProperties Properties { get; set; }

        /// <summary>
        /// Array of warnings associated with the device. Each warning object within the array contains two fields: `warning_code` and `message`. `warning_code` is a string that uniquely identifies the type of warning, enabling quick recognition and categorization of the issue. `message` provides a more detailed description of the warning, offering insights into the issue and potentially how to rectify it.
        /// </summary>
        [DataMember(Name = "warnings", IsRequired = false, EmitDefaultValue = false)]
        public List<PhoneWarnings> Warnings { get; set; }

        /// <summary>
        /// ID of the workspace that contains the phone.
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

        /// <summary>
        /// ASSA ABLOY Credential Service metadata for the phone.
        /// </summary>
        [DataMember(
            Name = "assa_abloy_credential_service_metadata",
            IsRequired = false,
            EmitDefaultValue = false
        )]
        public PhonePropertiesAssaAbloyCredentialServiceMetadata? AssaAbloyCredentialServiceMetadata { get; set; }

        /// <summary>
        /// Salto Space credential service metadata for the phone.
        /// </summary>
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
            List<PhonePropertiesAssaAbloyCredentialServiceMetadataEndpoints>? endpoints = default,
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
        public List<PhonePropertiesAssaAbloyCredentialServiceMetadataEndpoints>? Endpoints { get; set; }

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
        Name = "seamModel_phonePropertiesAssaAbloyCredentialServiceMetadataEndpoints_model"
    )]
    public class PhonePropertiesAssaAbloyCredentialServiceMetadataEndpoints
    {
        [JsonConstructorAttribute]
        protected PhonePropertiesAssaAbloyCredentialServiceMetadataEndpoints() { }

        public PhonePropertiesAssaAbloyCredentialServiceMetadataEndpoints(
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

    [DataContract(Name = "seamModel_phonePropertiesSaltoSpaceCredentialServiceMetadata_model")]
    public class PhonePropertiesSaltoSpaceCredentialServiceMetadata
    {
        [JsonConstructorAttribute]
        protected PhonePropertiesSaltoSpaceCredentialServiceMetadata() { }

        public PhonePropertiesSaltoSpaceCredentialServiceMetadata(bool? hasActivePhone = default)
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
}
