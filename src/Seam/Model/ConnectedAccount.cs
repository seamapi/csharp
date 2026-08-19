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
    /// Represents a [connected account](https://docs.seam.co/core-concepts/connected-accounts). A connected account is an external third-party account to which your user has authorized Seam to get access, for example, an August account with a list of door locks.
    /// </summary>
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
            object customMetadata = default,
            string? customerKey = default,
            string? defaultCheckinTime = default,
            string? defaultCheckoutTime = default,
            string displayName = default,
            List<ConnectedAccountErrors> errors = default,
            string? icalFeedOrigin = default,
            string? icalUrl = default,
            string? imageUrl = default,
            string? timeZone = default,
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
            DefaultCheckinTime = defaultCheckinTime;
            DefaultCheckoutTime = defaultCheckoutTime;
            DisplayName = displayName;
            Errors = errors;
            IcalFeedOrigin = icalFeedOrigin;
            IcalUrl = icalUrl;
            ImageUrl = imageUrl;
            TimeZone = timeZone;
            UserIdentifier = userIdentifier;
            Warnings = warnings;
        }

        /// <summary>
        /// List of capabilities that were accepted during the account connection process.
        /// </summary>
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

            [EnumMember(Value = "camera")]
            Camera = 5,
        }

        [JsonConverter(typeof(JsonSubtypes), "error_code")]
        [JsonSubtypes.FallBackSubType(typeof(ConnectedAccountErrorsUnrecognized))]
        [JsonSubtypes.KnownSubType(
            typeof(ConnectedAccountErrorsDormakabaSitesDisconnected),
            "dormakaba_sites_disconnected"
        )]
        [JsonSubtypes.KnownSubType(
            typeof(ConnectedAccountErrorsSaltoKsSubscriptionLimitExceeded),
            "salto_ks_subscription_limit_exceeded"
        )]
        [JsonSubtypes.KnownSubType(
            typeof(ConnectedAccountErrorsBridgeDisconnected),
            "bridge_disconnected"
        )]
        [JsonSubtypes.KnownSubType(
            typeof(ConnectedAccountErrorsAccountDisconnected),
            "account_disconnected"
        )]
        public abstract class ConnectedAccountErrors
        {
            public abstract string ErrorCode { get; }

            public abstract string CreatedAt { get; set; }

            public abstract bool? IsBridgeError { get; set; }

            public abstract bool? IsConnectedAccountError { get; set; }

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

            /// <summary>
            /// Date and time at which Seam created the error.
            /// </summary>
            [DataMember(Name = "created_at", IsRequired = false, EmitDefaultValue = false)]
            public override string CreatedAt { get; set; }

            [DataMember(Name = "error_code", IsRequired = true, EmitDefaultValue = false)]
            public override string ErrorCode { get; } = "account_disconnected";

            /// <summary>
            /// Indicates whether the error is related to [Seam Bridge](https://docs.seam.co/capability-guides/seam-bridge).
            /// </summary>
            [DataMember(Name = "is_bridge_error", IsRequired = false, EmitDefaultValue = false)]
            public override bool? IsBridgeError { get; set; }

            /// <summary>
            /// Indicates whether the error is related specifically to the connected account.
            /// </summary>
            [DataMember(
                Name = "is_connected_account_error",
                IsRequired = false,
                EmitDefaultValue = false
            )]
            public override bool? IsConnectedAccountError { get; set; }

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

            /// <summary>
            /// Date and time at which Seam created the error.
            /// </summary>
            [DataMember(Name = "created_at", IsRequired = false, EmitDefaultValue = false)]
            public override string CreatedAt { get; set; }

            [DataMember(Name = "error_code", IsRequired = true, EmitDefaultValue = false)]
            public override string ErrorCode { get; } = "bridge_disconnected";

            /// <summary>
            /// Indicates whether the error is related to [Seam Bridge](https://docs.seam.co/capability-guides/seam-bridge).
            /// </summary>
            [DataMember(Name = "is_bridge_error", IsRequired = false, EmitDefaultValue = false)]
            public override bool? IsBridgeError { get; set; }

            /// <summary>
            /// Indicates whether the error is related specifically to the connected account.
            /// </summary>
            [DataMember(
                Name = "is_connected_account_error",
                IsRequired = false,
                EmitDefaultValue = false
            )]
            public override bool? IsConnectedAccountError { get; set; }

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

            /// <summary>
            /// Date and time at which Seam created the error.
            /// </summary>
            [DataMember(Name = "created_at", IsRequired = false, EmitDefaultValue = false)]
            public override string CreatedAt { get; set; }

            [DataMember(Name = "error_code", IsRequired = true, EmitDefaultValue = false)]
            public override string ErrorCode { get; } = "salto_ks_subscription_limit_exceeded";

            /// <summary>
            /// Indicates whether the error is related to [Seam Bridge](https://docs.seam.co/capability-guides/seam-bridge).
            /// </summary>
            [DataMember(Name = "is_bridge_error", IsRequired = false, EmitDefaultValue = false)]
            public override bool? IsBridgeError { get; set; }

            /// <summary>
            /// Indicates whether the error is related specifically to the connected account.
            /// </summary>
            [DataMember(
                Name = "is_connected_account_error",
                IsRequired = false,
                EmitDefaultValue = false
            )]
            public override bool? IsConnectedAccountError { get; set; }

            /// <summary>
            /// Detailed description of the error. Provides insights into the issue and potentially how to rectify it.
            /// </summary>
            [DataMember(Name = "message", IsRequired = false, EmitDefaultValue = false)]
            public override string Message { get; set; }

            /// <summary>
            /// Salto KS metadata associated with the connected account that has an error.
            /// </summary>
            [DataMember(Name = "salto_ks_metadata", IsRequired = false, EmitDefaultValue = false)]
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
                List<ConnectedAccountErrorsSaltoKsSubscriptionLimitExceededSaltoKsMetadataSites>? sites =
                    default
            )
            {
                Sites = sites;
            }

            /// <summary>
            /// Salto sites associated with the connected account that has an error.
            /// </summary>
            [DataMember(Name = "sites", IsRequired = false, EmitDefaultValue = false)]
            public List<ConnectedAccountErrorsSaltoKsSubscriptionLimitExceededSaltoKsMetadataSites>? Sites { get; set; }

            public override string ToString()
            {
                JsonSerializer jsonSerializer = JsonSerializer.CreateDefault(null);

                StringWriter stringWriter = new StringWriter(
                    new StringBuilder(256),
                    System.Globalization.CultureInfo.InvariantCulture
                );
                using (JsonTextWriter jsonTextWriter = new JsonTextWriter(stringWriter))
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
                string? siteId = default,
                string? siteName = default,
                int? siteUserSubscriptionLimit = default,
                int? subscribedSiteUserCount = default
            )
            {
                SiteId = siteId;
                SiteName = siteName;
                SiteUserSubscriptionLimit = siteUserSubscriptionLimit;
                SubscribedSiteUserCount = subscribedSiteUserCount;
            }

            /// <summary>
            /// ID of a Salto site associated with the connected account that has an error.
            /// </summary>
            [DataMember(Name = "site_id", IsRequired = false, EmitDefaultValue = false)]
            public string? SiteId { get; set; }

            /// <summary>
            /// Name of a Salto site associated with the connected account that has an error.
            /// </summary>
            [DataMember(Name = "site_name", IsRequired = false, EmitDefaultValue = false)]
            public string? SiteName { get; set; }

            /// <summary>
            /// Subscription limit of site users for a Salto site associated with the connected account that has an error.
            /// </summary>
            [DataMember(
                Name = "site_user_subscription_limit",
                IsRequired = false,
                EmitDefaultValue = false
            )]
            public int? SiteUserSubscriptionLimit { get; set; }

            /// <summary>
            /// Count of subscribed site users for a Salto site associated with the connected account that has an error.
            /// </summary>
            [DataMember(
                Name = "subscribed_site_user_count",
                IsRequired = false,
                EmitDefaultValue = false
            )]
            public int? SubscribedSiteUserCount { get; set; }

            public override string ToString()
            {
                JsonSerializer jsonSerializer = JsonSerializer.CreateDefault(null);

                StringWriter stringWriter = new StringWriter(
                    new StringBuilder(256),
                    System.Globalization.CultureInfo.InvariantCulture
                );
                using (JsonTextWriter jsonTextWriter = new JsonTextWriter(stringWriter))
                {
                    jsonTextWriter.IndentChar = ' ';
                    jsonTextWriter.Indentation = 2;
                    jsonTextWriter.Formatting = Formatting.Indented;
                    jsonSerializer.Serialize(jsonTextWriter, this, null);
                }

                return stringWriter.ToString();
            }
        }

        [DataContract(Name = "seamModel_connectedAccountErrorsDormakabaSitesDisconnected_model")]
        public class ConnectedAccountErrorsDormakabaSitesDisconnected : ConnectedAccountErrors
        {
            [JsonConstructorAttribute]
            protected ConnectedAccountErrorsDormakabaSitesDisconnected() { }

            public ConnectedAccountErrorsDormakabaSitesDisconnected(
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
            public override string ErrorCode { get; } = "dormakaba_sites_disconnected";

            /// <summary>
            /// Indicates whether the error is related to [Seam Bridge](https://docs.seam.co/capability-guides/seam-bridge).
            /// </summary>
            [DataMember(Name = "is_bridge_error", IsRequired = false, EmitDefaultValue = false)]
            public override bool? IsBridgeError { get; set; }

            /// <summary>
            /// Indicates whether the error is related specifically to the connected account.
            /// </summary>
            [DataMember(
                Name = "is_connected_account_error",
                IsRequired = false,
                EmitDefaultValue = false
            )]
            public override bool? IsConnectedAccountError { get; set; }

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

        [DataContract(Name = "seamModel_connectedAccountErrorsUnrecognized_model")]
        public class ConnectedAccountErrorsUnrecognized : ConnectedAccountErrors
        {
            [JsonConstructorAttribute]
            protected ConnectedAccountErrorsUnrecognized() { }

            public ConnectedAccountErrorsUnrecognized(
                string errorCode = default,
                string createdAt = default,
                bool? isBridgeError = default,
                bool? isConnectedAccountError = default,
                string message = default
            )
            {
                ErrorCode = errorCode;
                CreatedAt = createdAt;
                IsBridgeError = isBridgeError;
                IsConnectedAccountError = isConnectedAccountError;
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
            /// Indicates whether the error is related to [Seam Bridge](https://docs.seam.co/capability-guides/seam-bridge).
            /// </summary>
            [DataMember(Name = "is_bridge_error", IsRequired = false, EmitDefaultValue = false)]
            public override bool? IsBridgeError { get; set; }

            /// <summary>
            /// Indicates whether the error is related specifically to the connected account.
            /// </summary>
            [DataMember(
                Name = "is_connected_account_error",
                IsRequired = false,
                EmitDefaultValue = false
            )]
            public override bool? IsConnectedAccountError { get; set; }

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
        [JsonSubtypes.FallBackSubType(typeof(ConnectedAccountWarningsUnrecognized))]
        [JsonSubtypes.KnownSubType(
            typeof(ConnectedAccountWarningsDormakabaSitesUnapproved),
            "dormakaba_sites_unapproved"
        )]
        [JsonSubtypes.KnownSubType(typeof(ConnectedAccountWarningsSetupRequired), "setup_required")]
        [JsonSubtypes.KnownSubType(
            typeof(ConnectedAccountWarningsProviderServiceUnavailable),
            "provider_service_unavailable"
        )]
        [JsonSubtypes.KnownSubType(typeof(ConnectedAccountWarningsBeingDeleted), "being_deleted")]
        [JsonSubtypes.KnownSubType(
            typeof(ConnectedAccountWarningsAccountReauthorizationRequested),
            "account_reauthorization_requested"
        )]
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

            public abstract string CreatedAt { get; set; }

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

            /// <summary>
            /// Salto KS metadata associated with the connected account that has a warning.
            /// </summary>
            [DataMember(Name = "salto_ks_metadata", IsRequired = false, EmitDefaultValue = false)]
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
                List<ConnectedAccountWarningsSaltoKsSubscriptionLimitAlmostReachedSaltoKsMetadataSites>? sites =
                    default
            )
            {
                Sites = sites;
            }

            /// <summary>
            /// Salto sites associated with the connected account that has a warning.
            /// </summary>
            [DataMember(Name = "sites", IsRequired = false, EmitDefaultValue = false)]
            public List<ConnectedAccountWarningsSaltoKsSubscriptionLimitAlmostReachedSaltoKsMetadataSites>? Sites { get; set; }

            public override string ToString()
            {
                JsonSerializer jsonSerializer = JsonSerializer.CreateDefault(null);

                StringWriter stringWriter = new StringWriter(
                    new StringBuilder(256),
                    System.Globalization.CultureInfo.InvariantCulture
                );
                using (JsonTextWriter jsonTextWriter = new JsonTextWriter(stringWriter))
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
                string? siteId = default,
                string? siteName = default,
                int? siteUserSubscriptionLimit = default,
                int? subscribedSiteUserCount = default
            )
            {
                SiteId = siteId;
                SiteName = siteName;
                SiteUserSubscriptionLimit = siteUserSubscriptionLimit;
                SubscribedSiteUserCount = subscribedSiteUserCount;
            }

            /// <summary>
            /// ID of a Salto site associated with the connected account that has a warning.
            /// </summary>
            [DataMember(Name = "site_id", IsRequired = false, EmitDefaultValue = false)]
            public string? SiteId { get; set; }

            /// <summary>
            /// Name of a Salto site associated with the connected account that has a warning.
            /// </summary>
            [DataMember(Name = "site_name", IsRequired = false, EmitDefaultValue = false)]
            public string? SiteName { get; set; }

            /// <summary>
            /// Subscription limit of site users for a Salto site associated with the connected account that has a warning.
            /// </summary>
            [DataMember(
                Name = "site_user_subscription_limit",
                IsRequired = false,
                EmitDefaultValue = false
            )]
            public int? SiteUserSubscriptionLimit { get; set; }

            /// <summary>
            /// Count of subscribed site users for a Salto site associated with the connected account that has a warning.
            /// </summary>
            [DataMember(
                Name = "subscribed_site_user_count",
                IsRequired = false,
                EmitDefaultValue = false
            )]
            public int? SubscribedSiteUserCount { get; set; }

            public override string ToString()
            {
                JsonSerializer jsonSerializer = JsonSerializer.CreateDefault(null);

                StringWriter stringWriter = new StringWriter(
                    new StringBuilder(256),
                    System.Globalization.CultureInfo.InvariantCulture
                );
                using (JsonTextWriter jsonTextWriter = new JsonTextWriter(stringWriter))
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
            Name = "seamModel_connectedAccountWarningsAccountReauthorizationRequested_model"
        )]
        public class ConnectedAccountWarningsAccountReauthorizationRequested
            : ConnectedAccountWarnings
        {
            [JsonConstructorAttribute]
            protected ConnectedAccountWarningsAccountReauthorizationRequested() { }

            public ConnectedAccountWarningsAccountReauthorizationRequested(
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
            public override string WarningCode { get; } = "account_reauthorization_requested";

            public override string ToString()
            {
                JsonSerializer jsonSerializer = JsonSerializer.CreateDefault(null);

                StringWriter stringWriter = new StringWriter(
                    new StringBuilder(256),
                    System.Globalization.CultureInfo.InvariantCulture
                );
                using (JsonTextWriter jsonTextWriter = new JsonTextWriter(stringWriter))
                {
                    jsonTextWriter.IndentChar = ' ';
                    jsonTextWriter.Indentation = 2;
                    jsonTextWriter.Formatting = Formatting.Indented;
                    jsonSerializer.Serialize(jsonTextWriter, this, null);
                }

                return stringWriter.ToString();
            }
        }

        [DataContract(Name = "seamModel_connectedAccountWarningsBeingDeleted_model")]
        public class ConnectedAccountWarningsBeingDeleted : ConnectedAccountWarnings
        {
            [JsonConstructorAttribute]
            protected ConnectedAccountWarningsBeingDeleted() { }

            public ConnectedAccountWarningsBeingDeleted(
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

        [DataContract(Name = "seamModel_connectedAccountWarningsProviderServiceUnavailable_model")]
        public class ConnectedAccountWarningsProviderServiceUnavailable : ConnectedAccountWarnings
        {
            [JsonConstructorAttribute]
            protected ConnectedAccountWarningsProviderServiceUnavailable() { }

            public ConnectedAccountWarningsProviderServiceUnavailable(
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
            public override string WarningCode { get; } = "provider_service_unavailable";

            public override string ToString()
            {
                JsonSerializer jsonSerializer = JsonSerializer.CreateDefault(null);

                StringWriter stringWriter = new StringWriter(
                    new StringBuilder(256),
                    System.Globalization.CultureInfo.InvariantCulture
                );
                using (JsonTextWriter jsonTextWriter = new JsonTextWriter(stringWriter))
                {
                    jsonTextWriter.IndentChar = ' ';
                    jsonTextWriter.Indentation = 2;
                    jsonTextWriter.Formatting = Formatting.Indented;
                    jsonSerializer.Serialize(jsonTextWriter, this, null);
                }

                return stringWriter.ToString();
            }
        }

        [DataContract(Name = "seamModel_connectedAccountWarningsSetupRequired_model")]
        public class ConnectedAccountWarningsSetupRequired : ConnectedAccountWarnings
        {
            [JsonConstructorAttribute]
            protected ConnectedAccountWarningsSetupRequired() { }

            public ConnectedAccountWarningsSetupRequired(
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
            public override string WarningCode { get; } = "setup_required";

            public override string ToString()
            {
                JsonSerializer jsonSerializer = JsonSerializer.CreateDefault(null);

                StringWriter stringWriter = new StringWriter(
                    new StringBuilder(256),
                    System.Globalization.CultureInfo.InvariantCulture
                );
                using (JsonTextWriter jsonTextWriter = new JsonTextWriter(stringWriter))
                {
                    jsonTextWriter.IndentChar = ' ';
                    jsonTextWriter.Indentation = 2;
                    jsonTextWriter.Formatting = Formatting.Indented;
                    jsonSerializer.Serialize(jsonTextWriter, this, null);
                }

                return stringWriter.ToString();
            }
        }

        [DataContract(Name = "seamModel_connectedAccountWarningsDormakabaSitesUnapproved_model")]
        public class ConnectedAccountWarningsDormakabaSitesUnapproved : ConnectedAccountWarnings
        {
            [JsonConstructorAttribute]
            protected ConnectedAccountWarningsDormakabaSitesUnapproved() { }

            public ConnectedAccountWarningsDormakabaSitesUnapproved(
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
            public override string WarningCode { get; } = "dormakaba_sites_unapproved";

            public override string ToString()
            {
                JsonSerializer jsonSerializer = JsonSerializer.CreateDefault(null);

                StringWriter stringWriter = new StringWriter(
                    new StringBuilder(256),
                    System.Globalization.CultureInfo.InvariantCulture
                );
                using (JsonTextWriter jsonTextWriter = new JsonTextWriter(stringWriter))
                {
                    jsonTextWriter.IndentChar = ' ';
                    jsonTextWriter.Indentation = 2;
                    jsonTextWriter.Formatting = Formatting.Indented;
                    jsonSerializer.Serialize(jsonTextWriter, this, null);
                }

                return stringWriter.ToString();
            }
        }

        [DataContract(Name = "seamModel_connectedAccountWarningsUnrecognized_model")]
        public class ConnectedAccountWarningsUnrecognized : ConnectedAccountWarnings
        {
            [JsonConstructorAttribute]
            protected ConnectedAccountWarningsUnrecognized() { }

            public ConnectedAccountWarningsUnrecognized(
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
        /// List of capabilities that were accepted during the account connection process.
        /// </summary>
        [DataMember(Name = "accepted_capabilities", IsRequired = false, EmitDefaultValue = false)]
        public List<ConnectedAccount.AcceptedCapabilitiesEnum> AcceptedCapabilities { get; set; }

        /// <summary>
        /// Type of connected account.
        /// </summary>
        [DataMember(Name = "account_type", IsRequired = false, EmitDefaultValue = false)]
        public string? AccountType { get; set; }

        /// <summary>
        /// Display name for the connected account type.
        /// </summary>
        [DataMember(
            Name = "account_type_display_name",
            IsRequired = false,
            EmitDefaultValue = false
        )]
        public string AccountTypeDisplayName { get; set; }

        /// <summary>
        /// Indicates whether Seam should [import all new devices](https://docs.seam.co/core-concepts/connect-webviews/customizing-connect-webviews#automatically_manage_new_devices) for the connected account to make these devices available for management by the Seam API.
        /// </summary>
        [DataMember(
            Name = "automatically_manage_new_devices",
            IsRequired = false,
            EmitDefaultValue = false
        )]
        public bool AutomaticallyManageNewDevices { get; set; }

        /// <summary>
        /// ID of the connected account.
        /// </summary>
        [DataMember(Name = "connected_account_id", IsRequired = false, EmitDefaultValue = false)]
        public string ConnectedAccountId { get; set; }

        /// <summary>
        /// Date and time at which the connected account was created.
        /// </summary>
        [DataMember(Name = "created_at", IsRequired = false, EmitDefaultValue = false)]
        public string? CreatedAt { get; set; }

        /// <summary>
        /// Set of key:value pairs. Adding custom metadata to a resource, such as a [Connect Webview](https://docs.seam.co/core-concepts/connect-webviews/attaching-custom-data-to-the-connect-webview), [connected account](https://docs.seam.co/core-concepts/connected-accounts/adding-custom-metadata-to-a-connected-account), or [device](https://docs.seam.co/core-concepts/devices/adding-custom-metadata-to-a-device), enables you to store custom information, like customer details or internal IDs from your application. Keys set to `null` or to an empty string are omitted.
        /// </summary>
        [DataMember(Name = "custom_metadata", IsRequired = false, EmitDefaultValue = false)]
        public object CustomMetadata { get; set; }

        /// <summary>
        /// Your unique key for the customer associated with this connected account.
        /// </summary>
        [DataMember(Name = "customer_key", IsRequired = false, EmitDefaultValue = false)]
        public string? CustomerKey { get; set; }

        /// <summary>
        /// Default reservation check-in time for this connected account, as `HH:mm` (24-hour). Sourced from the connector configuration — set during the connect_webview for providers like Lodgify whose API does not expose check-in times.
        /// </summary>
        [DataMember(Name = "default_checkin_time", IsRequired = false, EmitDefaultValue = false)]
        public string? DefaultCheckinTime { get; set; }

        /// <summary>
        /// Default reservation check-out time for this connected account, as `HH:mm` (24-hour). Sourced from the connector configuration.
        /// </summary>
        [DataMember(Name = "default_checkout_time", IsRequired = false, EmitDefaultValue = false)]
        public string? DefaultCheckoutTime { get; set; }

        /// <summary>
        /// Display name for the connected account.
        /// </summary>
        [DataMember(Name = "display_name", IsRequired = false, EmitDefaultValue = false)]
        public string DisplayName { get; set; }

        /// <summary>
        /// Errors associated with the connected account.
        /// </summary>
        [DataMember(Name = "errors", IsRequired = false, EmitDefaultValue = false)]
        public List<ConnectedAccountErrors> Errors { get; set; }

        /// <summary>
        /// For iCal connected accounts, the platform that produced the feed (for example, `airbnb`, `vrbo`, or `booking`), or `unknown` when it could not be determined. Intended for rendering the source platform&apos;s logo.
        /// </summary>
        [DataMember(Name = "ical_feed_origin", IsRequired = false, EmitDefaultValue = false)]
        public string? IcalFeedOrigin { get; set; }

        /// <summary>
        /// For iCal connected accounts, the feed URL for the connection. Sourced from the connector configuration.
        /// </summary>
        [DataMember(Name = "ical_url", IsRequired = false, EmitDefaultValue = false)]
        public string? IcalUrl { get; set; }

        /// <summary>
        /// Logo URL for the connected account provider.
        /// </summary>
        [DataMember(Name = "image_url", IsRequired = false, EmitDefaultValue = false)]
        public string? ImageUrl { get; set; }

        /// <summary>
        /// IANA time zone (e.g. America/Los_Angeles) for this connected account. Sourced from the connector configuration.
        /// </summary>
        [DataMember(Name = "time_zone", IsRequired = false, EmitDefaultValue = false)]
        public string? TimeZone { get; set; }

        /// <summary>
        /// User identifier associated with the connected account.
        /// </summary>
        [Obsolete("Use `display_name` instead.")]
        [DataMember(Name = "user_identifier", IsRequired = false, EmitDefaultValue = false)]
        public ConnectedAccountUserIdentifier? UserIdentifier { get; set; }

        /// <summary>
        /// Warnings associated with the connected account.
        /// </summary>
        [DataMember(Name = "warnings", IsRequired = false, EmitDefaultValue = false)]
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

        /// <summary>
        /// API URL for the user identifier associated with the connected account.
        /// </summary>
        [DataMember(Name = "api_url", IsRequired = false, EmitDefaultValue = false)]
        public string? ApiUrl { get; set; }

        /// <summary>
        /// Email address of the user identifier associated with the connected account.
        /// </summary>
        [DataMember(Name = "email", IsRequired = false, EmitDefaultValue = false)]
        public string? Email { get; set; }

        /// <summary>
        /// Indicates whether the user identifier associated with the connected account is exclusive.
        /// </summary>
        [DataMember(Name = "exclusive", IsRequired = false, EmitDefaultValue = false)]
        public bool? Exclusive { get; set; }

        /// <summary>
        /// Phone number of the user identifier associated with the connected account.
        /// </summary>
        [DataMember(Name = "phone", IsRequired = false, EmitDefaultValue = false)]
        public string? Phone { get; set; }

        /// <summary>
        /// Username of the user identifier associated with the connected account.
        /// </summary>
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
