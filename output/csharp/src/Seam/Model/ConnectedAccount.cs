using System.Runtime.Serialization;
using System.Text;
using JsonSubTypes;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using Seam.Model;

namespace Seam.Model
{
    [DataContract(Name = "seamModel_connectedAccount_model")]
    public class ConnectedAccount
    {
        [JsonConstructorAttribute]
        protected ConnectedAccount() { }

        public ConnectedAccount(
            List<ConnectedAccount.AcceptedCapabilitiesEnum> acceptedCapabilities = default,
            string? accountType = default,
            string accountTypeDisplayName = default,
            bool automaticallyManageNewDevices = default,
            string connectedAccountId = default,
            string? createdAt = default,
            object? customMetadata = default,
            string? customerKey = default,
            List<ConnectedAccountErrors> errors = default,
            ConnectedAccountUserIdentifier? userIdentifier = default,
            List<ConnectedAccountWarnings> warnings = default
        )
        {
            AcceptedCapabilities = acceptedCapabilities;
            AccountType = accountType;
            AccountTypeDisplayName = accountTypeDisplayName;
            AutomaticallyManageNewDevices = automaticallyManageNewDevices;
            ConnectedAccountId = connectedAccountId;
            CreatedAt = createdAt;
            CustomMetadata = customMetadata;
            CustomerKey = customerKey;
            Errors = errors;
            UserIdentifier = userIdentifier;
            Warnings = warnings;
        }

        [JsonConverter(typeof(SafeStringEnumConverter))]
        public enum AcceptedCapabilitiesEnum
        {
            [EnumMember(Value = "unrecognized")]
            Unrecognized = 0,

            [EnumMember(Value = "lock")]
            Lock = 1,

            [EnumMember(Value = "thermostat")]
            Thermostat = 2,

            [EnumMember(Value = "noise_sensor")]
            NoiseSensor = 3,

            [EnumMember(Value = "access_control")]
            AccessControl = 4,
        }

        [JsonConverter(typeof(JsonSubtypes), "error_code")]
        [JsonSubtypes.KnownSubType(
            typeof(ConnectedAccountErrorsSaltoKsSubscriptionLimitExceeded),
            "salto_ks_subscription_limit_exceeded"
        )]
        [JsonSubtypes.KnownSubType(
            typeof(ConnectedAccountErrorsBridgeDisconnected),
            "bridge_disconnected"
        )]
        [JsonSubtypes.KnownSubType(
            typeof(ConnectedAccountErrorsInvalidCredentials),
            "invalid_credentials"
        )]
        [JsonSubtypes.KnownSubType(
            typeof(ConnectedAccountErrorsAccountDisconnected),
            "account_disconnected"
        )]
        public abstract class ConnectedAccountErrors
        {
            public abstract string ErrorCode { get; }

            public abstract string Message { get; set; }

            public abstract override string ToString();
        }

        [DataContract(Name = "seamModel_connectedAccountErrorsAccountDisconnected_model")]
        public class ConnectedAccountErrorsAccountDisconnected : ConnectedAccountErrors
        {
            [JsonConstructorAttribute]
            protected ConnectedAccountErrorsAccountDisconnected() { }

            public ConnectedAccountErrorsAccountDisconnected(
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
            public override string ErrorCode { get; } = "account_disconnected";

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

        [DataContract(Name = "seamModel_connectedAccountErrorsInvalidCredentials_model")]
        public class ConnectedAccountErrorsInvalidCredentials : ConnectedAccountErrors
        {
            [JsonConstructorAttribute]
            protected ConnectedAccountErrorsInvalidCredentials() { }

            public ConnectedAccountErrorsInvalidCredentials(
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

        [DataContract(Name = "seamModel_connectedAccountErrorsBridgeDisconnected_model")]
        public class ConnectedAccountErrorsBridgeDisconnected : ConnectedAccountErrors
        {
            [JsonConstructorAttribute]
            protected ConnectedAccountErrorsBridgeDisconnected() { }

            public ConnectedAccountErrorsBridgeDisconnected(
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

        [DataContract(
            Name = "seamModel_connectedAccountErrorsSaltoKsSubscriptionLimitExceeded_model"
        )]
        public class ConnectedAccountErrorsSaltoKsSubscriptionLimitExceeded : ConnectedAccountErrors
        {
            [JsonConstructorAttribute]
            protected ConnectedAccountErrorsSaltoKsSubscriptionLimitExceeded() { }

            public ConnectedAccountErrorsSaltoKsSubscriptionLimitExceeded(
                string createdAt = default,
                string errorCode = default,
                bool? isBridgeError = default,
                bool? isConnectedAccountError = default,
                string message = default,
                ConnectedAccountErrorsSaltoKsSubscriptionLimitExceededSaltoKsMetadata saltoKsMetadata =
                    default
            )
            {
                CreatedAt = createdAt;
                ErrorCode = errorCode;
                IsBridgeError = isBridgeError;
                IsConnectedAccountError = isConnectedAccountError;
                Message = message;
                SaltoKsMetadata = saltoKsMetadata;
            }

            [DataMember(Name = "created_at", IsRequired = true, EmitDefaultValue = false)]
            public string CreatedAt { get; set; }

            [DataMember(Name = "error_code", IsRequired = true, EmitDefaultValue = false)]
            public override string ErrorCode { get; } = "salto_ks_subscription_limit_exceeded";

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

            [DataMember(Name = "salto_ks_metadata", IsRequired = true, EmitDefaultValue = false)]
            public ConnectedAccountErrorsSaltoKsSubscriptionLimitExceededSaltoKsMetadata SaltoKsMetadata { get; set; }

            public override string ToString()
            {
                JsonSerializer jsonSerializer = JsonSerializer.CreateDefault(null);

                StringWriter stringWriter = new StringWriter(
                    new StringBuilder(256),
                    System.Globalization.CultureInfo.InvariantCulture
                );
                using (JsonTextWriter jsonTextWriter = new JsonTextWriter(stringWriter))
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
            Name = "seamModel_connectedAccountErrorsSaltoKsSubscriptionLimitExceededSaltoKsMetadata_model"
        )]
        public class ConnectedAccountErrorsSaltoKsSubscriptionLimitExceededSaltoKsMetadata
        {
            [JsonConstructorAttribute]
            protected ConnectedAccountErrorsSaltoKsSubscriptionLimitExceededSaltoKsMetadata() { }

            public ConnectedAccountErrorsSaltoKsSubscriptionLimitExceededSaltoKsMetadata(
                List<ConnectedAccountErrorsSaltoKsSubscriptionLimitExceededSaltoKsMetadataSites> sites =
                    default
            )
            {
                Sites = sites;
            }

            [DataMember(Name = "sites", IsRequired = true, EmitDefaultValue = false)]
            public List<ConnectedAccountErrorsSaltoKsSubscriptionLimitExceededSaltoKsMetadataSites> Sites { get; set; }

            public override string ToString()
            {
                JsonSerializer jsonSerializer = JsonSerializer.CreateDefault(null);

                StringWriter stringWriter = new StringWriter(
                    new StringBuilder(256),
                    System.Globalization.CultureInfo.InvariantCulture
                );
                using (JsonTextWriter jsonTextWriter = new JsonTextWriter(stringWriter))
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
            Name = "seamModel_connectedAccountErrorsSaltoKsSubscriptionLimitExceededSaltoKsMetadataSites_model"
        )]
        public class ConnectedAccountErrorsSaltoKsSubscriptionLimitExceededSaltoKsMetadataSites
        {
            [JsonConstructorAttribute]
            protected ConnectedAccountErrorsSaltoKsSubscriptionLimitExceededSaltoKsMetadataSites()
            { }

            public ConnectedAccountErrorsSaltoKsSubscriptionLimitExceededSaltoKsMetadataSites(
                string siteId = default,
                string siteName = default,
                int siteUserSubscriptionLimit = default,
                int subscribedSiteUserCount = default
            )
            {
                SiteId = siteId;
                SiteName = siteName;
                SiteUserSubscriptionLimit = siteUserSubscriptionLimit;
                SubscribedSiteUserCount = subscribedSiteUserCount;
            }

            [DataMember(Name = "site_id", IsRequired = true, EmitDefaultValue = false)]
            public string SiteId { get; set; }

            [DataMember(Name = "site_name", IsRequired = true, EmitDefaultValue = false)]
            public string SiteName { get; set; }

            [DataMember(
                Name = "site_user_subscription_limit",
                IsRequired = true,
                EmitDefaultValue = false
            )]
            public int SiteUserSubscriptionLimit { get; set; }

            [DataMember(
                Name = "subscribed_site_user_count",
                IsRequired = true,
                EmitDefaultValue = false
            )]
            public int SubscribedSiteUserCount { get; set; }

            public override string ToString()
            {
                JsonSerializer jsonSerializer = JsonSerializer.CreateDefault(null);

                StringWriter stringWriter = new StringWriter(
                    new StringBuilder(256),
                    System.Globalization.CultureInfo.InvariantCulture
                );
                using (JsonTextWriter jsonTextWriter = new JsonTextWriter(stringWriter))
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
            typeof(ConnectedAccountWarningsSaltoKsSubscriptionLimitAlmostReached),
            "salto_ks_subscription_limit_almost_reached"
        )]
        [JsonSubtypes.KnownSubType(
            typeof(ConnectedAccountWarningsUnknownIssueWithConnectedAccount),
            "unknown_issue_with_connected_account"
        )]
        [JsonSubtypes.KnownSubType(
            typeof(ConnectedAccountWarningsScheduledMaintenanceWindow),
            "scheduled_maintenance_window"
        )]
        public abstract class ConnectedAccountWarnings
        {
            public abstract string WarningCode { get; }

            public abstract string Message { get; set; }

            public abstract override string ToString();
        }

        [DataContract(Name = "seamModel_connectedAccountWarningsScheduledMaintenanceWindow_model")]
        public class ConnectedAccountWarningsScheduledMaintenanceWindow : ConnectedAccountWarnings
        {
            [JsonConstructorAttribute]
            protected ConnectedAccountWarningsScheduledMaintenanceWindow() { }

            public ConnectedAccountWarningsScheduledMaintenanceWindow(
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
            public string CreatedAt { get; set; }

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

        [DataContract(
            Name = "seamModel_connectedAccountWarningsUnknownIssueWithConnectedAccount_model"
        )]
        public class ConnectedAccountWarningsUnknownIssueWithConnectedAccount
            : ConnectedAccountWarnings
        {
            [JsonConstructorAttribute]
            protected ConnectedAccountWarningsUnknownIssueWithConnectedAccount() { }

            public ConnectedAccountWarningsUnknownIssueWithConnectedAccount(
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
            public string CreatedAt { get; set; }

            [DataMember(Name = "message", IsRequired = true, EmitDefaultValue = false)]
            public override string Message { get; set; }

            [DataMember(Name = "warning_code", IsRequired = true, EmitDefaultValue = false)]
            public override string WarningCode { get; } = "unknown_issue_with_connected_account";

            public override string ToString()
            {
                JsonSerializer jsonSerializer = JsonSerializer.CreateDefault(null);

                StringWriter stringWriter = new StringWriter(
                    new StringBuilder(256),
                    System.Globalization.CultureInfo.InvariantCulture
                );
                using (JsonTextWriter jsonTextWriter = new JsonTextWriter(stringWriter))
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
            Name = "seamModel_connectedAccountWarningsSaltoKsSubscriptionLimitAlmostReached_model"
        )]
        public class ConnectedAccountWarningsSaltoKsSubscriptionLimitAlmostReached
            : ConnectedAccountWarnings
        {
            [JsonConstructorAttribute]
            protected ConnectedAccountWarningsSaltoKsSubscriptionLimitAlmostReached() { }

            public ConnectedAccountWarningsSaltoKsSubscriptionLimitAlmostReached(
                string createdAt = default,
                string message = default,
                ConnectedAccountWarningsSaltoKsSubscriptionLimitAlmostReachedSaltoKsMetadata saltoKsMetadata =
                    default,
                string warningCode = default
            )
            {
                CreatedAt = createdAt;
                Message = message;
                SaltoKsMetadata = saltoKsMetadata;
                WarningCode = warningCode;
            }

            [DataMember(Name = "created_at", IsRequired = true, EmitDefaultValue = false)]
            public string CreatedAt { get; set; }

            [DataMember(Name = "message", IsRequired = true, EmitDefaultValue = false)]
            public override string Message { get; set; }

            [DataMember(Name = "salto_ks_metadata", IsRequired = true, EmitDefaultValue = false)]
            public ConnectedAccountWarningsSaltoKsSubscriptionLimitAlmostReachedSaltoKsMetadata SaltoKsMetadata { get; set; }

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

        [DataContract(
            Name = "seamModel_connectedAccountWarningsSaltoKsSubscriptionLimitAlmostReachedSaltoKsMetadata_model"
        )]
        public class ConnectedAccountWarningsSaltoKsSubscriptionLimitAlmostReachedSaltoKsMetadata
        {
            [JsonConstructorAttribute]
            protected ConnectedAccountWarningsSaltoKsSubscriptionLimitAlmostReachedSaltoKsMetadata()
            { }

            public ConnectedAccountWarningsSaltoKsSubscriptionLimitAlmostReachedSaltoKsMetadata(
                List<ConnectedAccountWarningsSaltoKsSubscriptionLimitAlmostReachedSaltoKsMetadataSites> sites =
                    default
            )
            {
                Sites = sites;
            }

            [DataMember(Name = "sites", IsRequired = true, EmitDefaultValue = false)]
            public List<ConnectedAccountWarningsSaltoKsSubscriptionLimitAlmostReachedSaltoKsMetadataSites> Sites { get; set; }

            public override string ToString()
            {
                JsonSerializer jsonSerializer = JsonSerializer.CreateDefault(null);

                StringWriter stringWriter = new StringWriter(
                    new StringBuilder(256),
                    System.Globalization.CultureInfo.InvariantCulture
                );
                using (JsonTextWriter jsonTextWriter = new JsonTextWriter(stringWriter))
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
            Name = "seamModel_connectedAccountWarningsSaltoKsSubscriptionLimitAlmostReachedSaltoKsMetadataSites_model"
        )]
        public class ConnectedAccountWarningsSaltoKsSubscriptionLimitAlmostReachedSaltoKsMetadataSites
        {
            [JsonConstructorAttribute]
            protected ConnectedAccountWarningsSaltoKsSubscriptionLimitAlmostReachedSaltoKsMetadataSites()
            { }

            public ConnectedAccountWarningsSaltoKsSubscriptionLimitAlmostReachedSaltoKsMetadataSites(
                string siteId = default,
                string siteName = default,
                int siteUserSubscriptionLimit = default,
                int subscribedSiteUserCount = default
            )
            {
                SiteId = siteId;
                SiteName = siteName;
                SiteUserSubscriptionLimit = siteUserSubscriptionLimit;
                SubscribedSiteUserCount = subscribedSiteUserCount;
            }

            [DataMember(Name = "site_id", IsRequired = true, EmitDefaultValue = false)]
            public string SiteId { get; set; }

            [DataMember(Name = "site_name", IsRequired = true, EmitDefaultValue = false)]
            public string SiteName { get; set; }

            [DataMember(
                Name = "site_user_subscription_limit",
                IsRequired = true,
                EmitDefaultValue = false
            )]
            public int SiteUserSubscriptionLimit { get; set; }

            [DataMember(
                Name = "subscribed_site_user_count",
                IsRequired = true,
                EmitDefaultValue = false
            )]
            public int SubscribedSiteUserCount { get; set; }

            public override string ToString()
            {
                JsonSerializer jsonSerializer = JsonSerializer.CreateDefault(null);

                StringWriter stringWriter = new StringWriter(
                    new StringBuilder(256),
                    System.Globalization.CultureInfo.InvariantCulture
                );
                using (JsonTextWriter jsonTextWriter = new JsonTextWriter(stringWriter))
                {
                    jsonTextWriter.IndentChar = ' ';
                    jsonTextWriter.Indentation = 2;
                    jsonTextWriter.Formatting = Formatting.Indented;
                    jsonSerializer.Serialize(jsonTextWriter, this, null);
                }

                return stringWriter.ToString();
            }
        }

        [DataMember(Name = "accepted_capabilities", IsRequired = true, EmitDefaultValue = false)]
        public List<ConnectedAccount.AcceptedCapabilitiesEnum> AcceptedCapabilities { get; set; }

        [DataMember(Name = "account_type", IsRequired = false, EmitDefaultValue = false)]
        public string? AccountType { get; set; }

        [DataMember(
            Name = "account_type_display_name",
            IsRequired = true,
            EmitDefaultValue = false
        )]
        public string AccountTypeDisplayName { get; set; }

        [DataMember(
            Name = "automatically_manage_new_devices",
            IsRequired = true,
            EmitDefaultValue = false
        )]
        public bool AutomaticallyManageNewDevices { get; set; }

        [DataMember(Name = "connected_account_id", IsRequired = true, EmitDefaultValue = false)]
        public string ConnectedAccountId { get; set; }

        [DataMember(Name = "created_at", IsRequired = false, EmitDefaultValue = false)]
        public string? CreatedAt { get; set; }

        [DataMember(Name = "custom_metadata", IsRequired = true, EmitDefaultValue = false)]
        public object? CustomMetadata { get; set; }

        [DataMember(Name = "customer_key", IsRequired = false, EmitDefaultValue = false)]
        public string? CustomerKey { get; set; }

        [DataMember(Name = "errors", IsRequired = true, EmitDefaultValue = false)]
        public List<ConnectedAccountErrors> Errors { get; set; }

        [DataMember(Name = "user_identifier", IsRequired = false, EmitDefaultValue = false)]
        public ConnectedAccountUserIdentifier? UserIdentifier { get; set; }

        [DataMember(Name = "warnings", IsRequired = true, EmitDefaultValue = false)]
        public List<ConnectedAccountWarnings> Warnings { get; set; }

        public override string ToString()
        {
            JsonSerializer jsonSerializer = JsonSerializer.CreateDefault(null);

            StringWriter stringWriter = new StringWriter(
                new StringBuilder(256),
                System.Globalization.CultureInfo.InvariantCulture
            );
            using (JsonTextWriter jsonTextWriter = new JsonTextWriter(stringWriter))
            {
                jsonTextWriter.IndentChar = ' ';
                jsonTextWriter.Indentation = 2;
                jsonTextWriter.Formatting = Formatting.Indented;
                jsonSerializer.Serialize(jsonTextWriter, this, null);
            }

            return stringWriter.ToString();
        }
    }

    [DataContract(Name = "seamModel_connectedAccountUserIdentifier_model")]
    public class ConnectedAccountUserIdentifier
    {
        [JsonConstructorAttribute]
        protected ConnectedAccountUserIdentifier() { }

        public ConnectedAccountUserIdentifier(
            string? apiUrl = default,
            string? email = default,
            bool? exclusive = default,
            string? phone = default,
            string? username = default
        )
        {
            ApiUrl = apiUrl;
            Email = email;
            Exclusive = exclusive;
            Phone = phone;
            Username = username;
        }

        [DataMember(Name = "api_url", IsRequired = false, EmitDefaultValue = false)]
        public string? ApiUrl { get; set; }

        [DataMember(Name = "email", IsRequired = false, EmitDefaultValue = false)]
        public string? Email { get; set; }

        [DataMember(Name = "exclusive", IsRequired = false, EmitDefaultValue = false)]
        public bool? Exclusive { get; set; }

        [DataMember(Name = "phone", IsRequired = false, EmitDefaultValue = false)]
        public string? Phone { get; set; }

        [DataMember(Name = "username", IsRequired = false, EmitDefaultValue = false)]
        public string? Username { get; set; }

        public override string ToString()
        {
            JsonSerializer jsonSerializer = JsonSerializer.CreateDefault(null);

            StringWriter stringWriter = new StringWriter(
                new StringBuilder(256),
                System.Globalization.CultureInfo.InvariantCulture
            );
            using (JsonTextWriter jsonTextWriter = new JsonTextWriter(stringWriter))
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
