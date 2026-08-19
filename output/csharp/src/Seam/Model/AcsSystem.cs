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
    /// Represents an [access control system](https://docs.seam.co/low-level-apis/access-systems).
    ///
    /// Within an `acs_system`, create [`acs_user`s](https://docs.seam.co/api/acs/users/object) and [`acs_credential`s](https://docs.seam.co/api/acs/credentials/object) to grant access to the `acs_user`s.
    ///
    /// For details about the resources associated with an access control system, see the [access control systems namespace](https://docs.seam.co/api/acs).
    /// </summary>
    [DataContract(Name = "seamModel_acsSystem_model")]
    public class AcsSystem
    {
        [JsonConstructorAttribute]
        protected AcsSystem() { }

        public AcsSystem(
            float? acsAccessGroupCount = default,
            string acsSystemId = default,
            float? acsUserCount = default,
            string connectedAccountId = default,
            List<string> connectedAccountIds = default,
            string createdAt = default,
            string? defaultCredentialManagerAcsSystemId = default,
            List<AcsSystemErrors> errors = default,
            AcsSystem.ExternalTypeEnum? externalType = default,
            string? externalTypeDisplayName = default,
            string imageAltText = default,
            string imageUrl = default,
            bool isCredentialManager = default,
            AcsSystemLocation location = default,
            string name = default,
            AcsSystem.SystemTypeEnum? systemType = default,
            string? systemTypeDisplayName = default,
            AcsSystemVisionlineMetadata? visionlineMetadata = default,
            List<AcsSystemWarnings> warnings = default,
            string workspaceId = default
        )
        {
            AcsAccessGroupCount = acsAccessGroupCount;
            AcsSystemId = acsSystemId;
            AcsUserCount = acsUserCount;
            ConnectedAccountId = connectedAccountId;
            ConnectedAccountIds = connectedAccountIds;
            CreatedAt = createdAt;
            DefaultCredentialManagerAcsSystemId = defaultCredentialManagerAcsSystemId;
            Errors = errors;
            ExternalType = externalType;
            ExternalTypeDisplayName = externalTypeDisplayName;
            ImageAltText = imageAltText;
            ImageUrl = imageUrl;
            IsCredentialManager = isCredentialManager;
            Location = location;
            Name = name;
            SystemType = systemType;
            SystemTypeDisplayName = systemTypeDisplayName;
            VisionlineMetadata = visionlineMetadata;
            Warnings = warnings;
            WorkspaceId = workspaceId;
        }

        [JsonConverter(typeof(JsonSubtypes), "error_code")]
        [JsonSubtypes.FallBackSubType(typeof(AcsSystemErrorsUnrecognized))]
        [JsonSubtypes.KnownSubType(
            typeof(AcsSystemErrorsProviderServiceUnavailable),
            "provider_service_unavailable"
        )]
        [JsonSubtypes.KnownSubType(
            typeof(AcsSystemErrorsSaltoKsCertificationExpired),
            "salto_ks_certification_expired"
        )]
        [JsonSubtypes.KnownSubType(
            typeof(AcsSystemErrorsAccountDisconnected),
            "account_disconnected"
        )]
        [JsonSubtypes.KnownSubType(
            typeof(AcsSystemErrorsAcsSystemDisconnected),
            "acs_system_disconnected"
        )]
        [JsonSubtypes.KnownSubType(
            typeof(AcsSystemErrorsInsufficientPermissions),
            "insufficient_permissions"
        )]
        [JsonSubtypes.KnownSubType(
            typeof(AcsSystemErrorsSaltoKsSubscriptionLimitExceeded),
            "salto_ks_subscription_limit_exceeded"
        )]
        [JsonSubtypes.KnownSubType(
            typeof(AcsSystemErrorsVisionlineInstanceUnreachable),
            "visionline_instance_unreachable"
        )]
        [JsonSubtypes.KnownSubType(
            typeof(AcsSystemErrorsBridgeDisconnected),
            "bridge_disconnected"
        )]
        [JsonSubtypes.KnownSubType(
            typeof(AcsSystemErrorsSeamBridgeDisconnected),
            "seam_bridge_disconnected"
        )]
        public abstract class AcsSystemErrors
        {
            public abstract string ErrorCode { get; }

            public abstract string CreatedAt { get; set; }

            public abstract string Message { get; set; }

            public abstract override string ToString();
        }

        [DataContract(Name = "seamModel_acsSystemErrorsSeamBridgeDisconnected_model")]
        public class AcsSystemErrorsSeamBridgeDisconnected : AcsSystemErrors
        {
            [JsonConstructorAttribute]
            protected AcsSystemErrorsSeamBridgeDisconnected() { }

            public AcsSystemErrorsSeamBridgeDisconnected(
                string createdAt = default,
                string errorCode = default,
                string message = default
            )
            {
                CreatedAt = createdAt;
                ErrorCode = errorCode;
                Message = message;
            }

            /// <summary>
            /// Date and time at which Seam created the error.
            /// </summary>
            [DataMember(Name = "created_at", IsRequired = false, EmitDefaultValue = false)]
            public override string CreatedAt { get; set; }

            [DataMember(Name = "error_code", IsRequired = true, EmitDefaultValue = false)]
            public override string ErrorCode { get; } = "seam_bridge_disconnected";

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

        [DataContract(Name = "seamModel_acsSystemErrorsBridgeDisconnected_model")]
        public class AcsSystemErrorsBridgeDisconnected : AcsSystemErrors
        {
            [JsonConstructorAttribute]
            protected AcsSystemErrorsBridgeDisconnected() { }

            public AcsSystemErrorsBridgeDisconnected(
                string createdAt = default,
                string errorCode = default,
                bool? isBridgeError = default,
                string message = default
            )
            {
                CreatedAt = createdAt;
                ErrorCode = errorCode;
                IsBridgeError = isBridgeError;
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
            /// Indicates whether the error is related to the [Seam Bridge](https://docs.seam.co/capability-guides/seam-bridge).
            /// </summary>
            [DataMember(Name = "is_bridge_error", IsRequired = false, EmitDefaultValue = false)]
            public bool? IsBridgeError { get; set; }

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

        [DataContract(Name = "seamModel_acsSystemErrorsVisionlineInstanceUnreachable_model")]
        public class AcsSystemErrorsVisionlineInstanceUnreachable : AcsSystemErrors
        {
            [JsonConstructorAttribute]
            protected AcsSystemErrorsVisionlineInstanceUnreachable() { }

            public AcsSystemErrorsVisionlineInstanceUnreachable(
                string createdAt = default,
                string errorCode = default,
                string message = default
            )
            {
                CreatedAt = createdAt;
                ErrorCode = errorCode;
                Message = message;
            }

            /// <summary>
            /// Date and time at which Seam created the error.
            /// </summary>
            [DataMember(Name = "created_at", IsRequired = false, EmitDefaultValue = false)]
            public override string CreatedAt { get; set; }

            [DataMember(Name = "error_code", IsRequired = true, EmitDefaultValue = false)]
            public override string ErrorCode { get; } = "visionline_instance_unreachable";

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

        [DataContract(Name = "seamModel_acsSystemErrorsSaltoKsSubscriptionLimitExceeded_model")]
        public class AcsSystemErrorsSaltoKsSubscriptionLimitExceeded : AcsSystemErrors
        {
            [JsonConstructorAttribute]
            protected AcsSystemErrorsSaltoKsSubscriptionLimitExceeded() { }

            public AcsSystemErrorsSaltoKsSubscriptionLimitExceeded(
                string createdAt = default,
                string errorCode = default,
                string message = default
            )
            {
                CreatedAt = createdAt;
                ErrorCode = errorCode;
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

        [DataContract(Name = "seamModel_acsSystemErrorsInsufficientPermissions_model")]
        public class AcsSystemErrorsInsufficientPermissions : AcsSystemErrors
        {
            [JsonConstructorAttribute]
            protected AcsSystemErrorsInsufficientPermissions() { }

            public AcsSystemErrorsInsufficientPermissions(
                string createdAt = default,
                string errorCode = default,
                string message = default
            )
            {
                CreatedAt = createdAt;
                ErrorCode = errorCode;
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

        [DataContract(Name = "seamModel_acsSystemErrorsAcsSystemDisconnected_model")]
        public class AcsSystemErrorsAcsSystemDisconnected : AcsSystemErrors
        {
            [JsonConstructorAttribute]
            protected AcsSystemErrorsAcsSystemDisconnected() { }

            public AcsSystemErrorsAcsSystemDisconnected(
                string createdAt = default,
                string errorCode = default,
                string message = default
            )
            {
                CreatedAt = createdAt;
                ErrorCode = errorCode;
                Message = message;
            }

            /// <summary>
            /// Date and time at which Seam created the error.
            /// </summary>
            [DataMember(Name = "created_at", IsRequired = false, EmitDefaultValue = false)]
            public override string CreatedAt { get; set; }

            [DataMember(Name = "error_code", IsRequired = true, EmitDefaultValue = false)]
            public override string ErrorCode { get; } = "acs_system_disconnected";

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

        [DataContract(Name = "seamModel_acsSystemErrorsAccountDisconnected_model")]
        public class AcsSystemErrorsAccountDisconnected : AcsSystemErrors
        {
            [JsonConstructorAttribute]
            protected AcsSystemErrorsAccountDisconnected() { }

            public AcsSystemErrorsAccountDisconnected(
                string createdAt = default,
                string errorCode = default,
                string message = default
            )
            {
                CreatedAt = createdAt;
                ErrorCode = errorCode;
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

        [DataContract(Name = "seamModel_acsSystemErrorsSaltoKsCertificationExpired_model")]
        public class AcsSystemErrorsSaltoKsCertificationExpired : AcsSystemErrors
        {
            [JsonConstructorAttribute]
            protected AcsSystemErrorsSaltoKsCertificationExpired() { }

            public AcsSystemErrorsSaltoKsCertificationExpired(
                string createdAt = default,
                string errorCode = default,
                string message = default
            )
            {
                CreatedAt = createdAt;
                ErrorCode = errorCode;
                Message = message;
            }

            /// <summary>
            /// Date and time at which Seam created the error.
            /// </summary>
            [DataMember(Name = "created_at", IsRequired = false, EmitDefaultValue = false)]
            public override string CreatedAt { get; set; }

            [DataMember(Name = "error_code", IsRequired = true, EmitDefaultValue = false)]
            public override string ErrorCode { get; } = "salto_ks_certification_expired";

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

        [DataContract(Name = "seamModel_acsSystemErrorsProviderServiceUnavailable_model")]
        public class AcsSystemErrorsProviderServiceUnavailable : AcsSystemErrors
        {
            [JsonConstructorAttribute]
            protected AcsSystemErrorsProviderServiceUnavailable() { }

            public AcsSystemErrorsProviderServiceUnavailable(
                string createdAt = default,
                string errorCode = default,
                string message = default
            )
            {
                CreatedAt = createdAt;
                ErrorCode = errorCode;
                Message = message;
            }

            /// <summary>
            /// Date and time at which Seam created the error.
            /// </summary>
            [DataMember(Name = "created_at", IsRequired = false, EmitDefaultValue = false)]
            public override string CreatedAt { get; set; }

            [DataMember(Name = "error_code", IsRequired = true, EmitDefaultValue = false)]
            public override string ErrorCode { get; } = "provider_service_unavailable";

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

        [DataContract(Name = "seamModel_acsSystemErrorsUnrecognized_model")]
        public class AcsSystemErrorsUnrecognized : AcsSystemErrors
        {
            [JsonConstructorAttribute]
            protected AcsSystemErrorsUnrecognized() { }

            public AcsSystemErrorsUnrecognized(
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

        /// <summary>
        /// Brand-specific terminology for the [access control system](https://docs.seam.co/low-level-apis/access-systems) type.
        /// </summary>
        [JsonConverter(typeof(SafeStringEnumConverter))]
        public enum ExternalTypeEnum
        {
            [EnumMember(Value = "unrecognized")]
            Unrecognized = 0,

            [EnumMember(Value = "pti_site")]
            PtiSite = 1,

            [EnumMember(Value = "avigilon_alta_org")]
            AvigilonAltaOrg = 2,

            [EnumMember(Value = "salto_ks_site")]
            SaltoKsSite = 3,

            [EnumMember(Value = "salto_space_system")]
            SaltoSpaceSystem = 4,

            [EnumMember(Value = "brivo_account")]
            BrivoAccount = 5,

            [EnumMember(Value = "hid_credential_manager_organization")]
            HidCredentialManagerOrganization = 6,

            [EnumMember(Value = "visionline_system")]
            VisionlineSystem = 7,

            [EnumMember(Value = "assa_abloy_credential_service")]
            AssaAbloyCredentialService = 8,

            [EnumMember(Value = "latch_building")]
            LatchBuilding = 9,

            [EnumMember(Value = "dormakaba_community_site")]
            DormakabaCommunitySite = 10,

            [EnumMember(Value = "dormakaba_ambiance_site")]
            DormakabaAmbianceSite = 11,

            [EnumMember(Value = "legic_connect_credential_service")]
            LegicConnectCredentialService = 12,

            [EnumMember(Value = "assa_abloy_vostio")]
            AssaAbloyVostio = 13,

            [EnumMember(Value = "assa_abloy_vostio_credential_service")]
            AssaAbloyVostioCredentialService = 14,

            [EnumMember(Value = "hotek_site")]
            HotekSite = 15,

            [EnumMember(Value = "kisi_organization")]
            KisiOrganization = 16,

            [EnumMember(Value = "akiles_organization")]
            AkilesOrganization = 17,
        }

        [JsonConverter(typeof(SafeStringEnumConverter))]
        public enum SystemTypeEnum
        {
            [EnumMember(Value = "unrecognized")]
            Unrecognized = 0,

            [EnumMember(Value = "pti_site")]
            PtiSite = 1,

            [EnumMember(Value = "avigilon_alta_org")]
            AvigilonAltaOrg = 2,

            [EnumMember(Value = "salto_ks_site")]
            SaltoKsSite = 3,

            [EnumMember(Value = "salto_space_system")]
            SaltoSpaceSystem = 4,

            [EnumMember(Value = "brivo_account")]
            BrivoAccount = 5,

            [EnumMember(Value = "hid_credential_manager_organization")]
            HidCredentialManagerOrganization = 6,

            [EnumMember(Value = "visionline_system")]
            VisionlineSystem = 7,

            [EnumMember(Value = "assa_abloy_credential_service")]
            AssaAbloyCredentialService = 8,

            [EnumMember(Value = "latch_building")]
            LatchBuilding = 9,

            [EnumMember(Value = "dormakaba_community_site")]
            DormakabaCommunitySite = 10,

            [EnumMember(Value = "dormakaba_ambiance_site")]
            DormakabaAmbianceSite = 11,

            [EnumMember(Value = "legic_connect_credential_service")]
            LegicConnectCredentialService = 12,

            [EnumMember(Value = "assa_abloy_vostio")]
            AssaAbloyVostio = 13,

            [EnumMember(Value = "assa_abloy_vostio_credential_service")]
            AssaAbloyVostioCredentialService = 14,

            [EnumMember(Value = "hotek_site")]
            HotekSite = 15,

            [EnumMember(Value = "kisi_organization")]
            KisiOrganization = 16,

            [EnumMember(Value = "akiles_organization")]
            AkilesOrganization = 17,
        }

        [JsonConverter(typeof(JsonSubtypes), "warning_code")]
        [JsonSubtypes.FallBackSubType(typeof(AcsSystemWarningsUnrecognized))]
        [JsonSubtypes.KnownSubType(
            typeof(AcsSystemWarningsUnknownIssueWithAcsSystem),
            "unknown_issue_with_acs_system"
        )]
        [JsonSubtypes.KnownSubType(typeof(AcsSystemWarningsSetupRequired), "setup_required")]
        [JsonSubtypes.KnownSubType(
            typeof(AcsSystemWarningsTimeZoneDoesNotMatchLocation),
            "time_zone_does_not_match_location"
        )]
        [JsonSubtypes.KnownSubType(
            typeof(AcsSystemWarningsSaltoKsSubscriptionLimitAlmostReached),
            "salto_ks_subscription_limit_almost_reached"
        )]
        public abstract class AcsSystemWarnings
        {
            public abstract string WarningCode { get; }

            public abstract string CreatedAt { get; set; }

            public abstract string Message { get; set; }

            public abstract override string ToString();
        }

        [DataContract(
            Name = "seamModel_acsSystemWarningsSaltoKsSubscriptionLimitAlmostReached_model"
        )]
        public class AcsSystemWarningsSaltoKsSubscriptionLimitAlmostReached : AcsSystemWarnings
        {
            [JsonConstructorAttribute]
            protected AcsSystemWarningsSaltoKsSubscriptionLimitAlmostReached() { }

            public AcsSystemWarningsSaltoKsSubscriptionLimitAlmostReached(
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

        [DataContract(Name = "seamModel_acsSystemWarningsTimeZoneDoesNotMatchLocation_model")]
        public class AcsSystemWarningsTimeZoneDoesNotMatchLocation : AcsSystemWarnings
        {
            [JsonConstructorAttribute]
            protected AcsSystemWarningsTimeZoneDoesNotMatchLocation() { }

            public AcsSystemWarningsTimeZoneDoesNotMatchLocation(
                string createdAt = default,
                string message = default,
                List<string>? misconfiguredAcsEntranceIds = default,
                string warningCode = default
            )
            {
                CreatedAt = createdAt;
                Message = message;
                MisconfiguredAcsEntranceIds = misconfiguredAcsEntranceIds;
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

            [Obsolete("this field is deprecated.")]
            [DataMember(
                Name = "misconfigured_acs_entrance_ids",
                IsRequired = false,
                EmitDefaultValue = false
            )]
            public List<string>? MisconfiguredAcsEntranceIds { get; set; }

            [DataMember(Name = "warning_code", IsRequired = true, EmitDefaultValue = false)]
            public override string WarningCode { get; } = "time_zone_does_not_match_location";

            public override string ToString()
            {
                JsonSerializer jsonSerializer = JsonSerializer.CreateDefault(null);

                StringWriter stringWriter = new StringWriter(
                    new StringBuilder(256),
                    System.Globalization.CultureInfo.InvariantCulture
                );
                using (JsonTextWriter jsonTextWriter = new JsonTextWriter(stringWriter))
                {
                    jsonTextWriter.IndentChar = ' ';
                    jsonTextWriter.Indentation = 2;
                    jsonTextWriter.Formatting = Formatting.Indented;
                    jsonSerializer.Serialize(jsonTextWriter, this, null);
                }

                return stringWriter.ToString();
            }
        }

        [DataContract(Name = "seamModel_acsSystemWarningsSetupRequired_model")]
        public class AcsSystemWarningsSetupRequired : AcsSystemWarnings
        {
            [JsonConstructorAttribute]
            protected AcsSystemWarningsSetupRequired() { }

            public AcsSystemWarningsSetupRequired(
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

        [DataContract(Name = "seamModel_acsSystemWarningsUnknownIssueWithAcsSystem_model")]
        public class AcsSystemWarningsUnknownIssueWithAcsSystem : AcsSystemWarnings
        {
            [JsonConstructorAttribute]
            protected AcsSystemWarningsUnknownIssueWithAcsSystem() { }

            public AcsSystemWarningsUnknownIssueWithAcsSystem(
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
            public override string WarningCode { get; } = "unknown_issue_with_acs_system";

            public override string ToString()
            {
                JsonSerializer jsonSerializer = JsonSerializer.CreateDefault(null);

                StringWriter stringWriter = new StringWriter(
                    new StringBuilder(256),
                    System.Globalization.CultureInfo.InvariantCulture
                );
                using (JsonTextWriter jsonTextWriter = new JsonTextWriter(stringWriter))
                {
                    jsonTextWriter.IndentChar = ' ';
                    jsonTextWriter.Indentation = 2;
                    jsonTextWriter.Formatting = Formatting.Indented;
                    jsonSerializer.Serialize(jsonTextWriter, this, null);
                }

                return stringWriter.ToString();
            }
        }

        [DataContract(Name = "seamModel_acsSystemWarningsUnrecognized_model")]
        public class AcsSystemWarningsUnrecognized : AcsSystemWarnings
        {
            [JsonConstructorAttribute]
            protected AcsSystemWarningsUnrecognized() { }

            public AcsSystemWarningsUnrecognized(
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
        /// Number of access groups in the [access control system](https://docs.seam.co/low-level-apis/access-systems).
        /// </summary>
        [DataMember(Name = "acs_access_group_count", IsRequired = false, EmitDefaultValue = false)]
        public float? AcsAccessGroupCount { get; set; }

        /// <summary>
        /// ID of the [access control system](https://docs.seam.co/low-level-apis/access-systems).
        /// </summary>
        [DataMember(Name = "acs_system_id", IsRequired = false, EmitDefaultValue = false)]
        public string AcsSystemId { get; set; }

        /// <summary>
        /// Number of users in the [access control system](https://docs.seam.co/low-level-apis/access-systems).
        /// </summary>
        [DataMember(Name = "acs_user_count", IsRequired = false, EmitDefaultValue = false)]
        public float? AcsUserCount { get; set; }

        /// <summary>
        /// ID of the connected account associated with the [access control system](https://docs.seam.co/low-level-apis/access-systems).
        /// </summary>
        [DataMember(Name = "connected_account_id", IsRequired = false, EmitDefaultValue = false)]
        public string ConnectedAccountId { get; set; }

        /// <summary>
        /// IDs of the [connected accounts](https://docs.seam.co/core-concepts/connected-accounts) associated with the [access control system](https://docs.seam.co/low-level-apis/access-systems).
        /// </summary>
        [Obsolete("Use `connected_account_id`.")]
        [DataMember(Name = "connected_account_ids", IsRequired = false, EmitDefaultValue = false)]
        public List<string> ConnectedAccountIds { get; set; }

        /// <summary>
        /// Date and time at which the [access control system](https://docs.seam.co/low-level-apis/access-systems) was created.
        /// </summary>
        [DataMember(Name = "created_at", IsRequired = false, EmitDefaultValue = false)]
        public string CreatedAt { get; set; }

        /// <summary>
        /// ID of the default credential manager `acs_system` for this [access control system](https://docs.seam.co/low-level-apis/access-systems).
        /// </summary>
        [DataMember(
            Name = "default_credential_manager_acs_system_id",
            IsRequired = false,
            EmitDefaultValue = false
        )]
        public string? DefaultCredentialManagerAcsSystemId { get; set; }

        /// <summary>
        /// Errors associated with the [access control system](https://docs.seam.co/low-level-apis/access-systems).
        /// </summary>
        [DataMember(Name = "errors", IsRequired = false, EmitDefaultValue = false)]
        public List<AcsSystemErrors> Errors { get; set; }

        /// <summary>
        /// Brand-specific terminology for the [access control system](https://docs.seam.co/low-level-apis/access-systems) type.
        /// </summary>
        [DataMember(Name = "external_type", IsRequired = false, EmitDefaultValue = false)]
        public AcsSystem.ExternalTypeEnum? ExternalType { get; set; }

        /// <summary>
        /// Display name that corresponds to the brand-specific terminology for the [access control system](https://docs.seam.co/low-level-apis/access-systems) type.
        /// </summary>
        [DataMember(
            Name = "external_type_display_name",
            IsRequired = false,
            EmitDefaultValue = false
        )]
        public string? ExternalTypeDisplayName { get; set; }

        /// <summary>
        /// Alternative text for the [access control system](https://docs.seam.co/low-level-apis/access-systems) image.
        /// </summary>
        [DataMember(Name = "image_alt_text", IsRequired = false, EmitDefaultValue = false)]
        public string ImageAltText { get; set; }

        /// <summary>
        /// URL for the image that represents the [access control system](https://docs.seam.co/low-level-apis/access-systems).
        /// </summary>
        [DataMember(Name = "image_url", IsRequired = false, EmitDefaultValue = false)]
        public string ImageUrl { get; set; }

        /// <summary>
        /// Indicates whether the `acs_system` is a credential manager.
        /// </summary>
        [DataMember(Name = "is_credential_manager", IsRequired = false, EmitDefaultValue = false)]
        public bool IsCredentialManager { get; set; }

        /// <summary>
        /// Location information for the [access control system](https://docs.seam.co/low-level-apis/access-systems).
        /// </summary>
        [DataMember(Name = "location", IsRequired = false, EmitDefaultValue = false)]
        public AcsSystemLocation Location { get; set; }

        /// <summary>
        /// Name of the [access control system](https://docs.seam.co/low-level-apis/access-systems).
        /// </summary>
        [DataMember(Name = "name", IsRequired = false, EmitDefaultValue = false)]
        public string Name { get; set; }

        [Obsolete("Use `external_type`.")]
        [DataMember(Name = "system_type", IsRequired = false, EmitDefaultValue = false)]
        public AcsSystem.SystemTypeEnum? SystemType { get; set; }

        [Obsolete("Use `external_type_display_name`.")]
        [DataMember(
            Name = "system_type_display_name",
            IsRequired = false,
            EmitDefaultValue = false
        )]
        public string? SystemTypeDisplayName { get; set; }

        /// <summary>
        /// Visionline-specific metadata for the [access control system](https://docs.seam.co/low-level-apis/access-systems).
        /// </summary>
        [DataMember(Name = "visionline_metadata", IsRequired = false, EmitDefaultValue = false)]
        public AcsSystemVisionlineMetadata? VisionlineMetadata { get; set; }

        /// <summary>
        /// Warnings associated with the [access control system](https://docs.seam.co/low-level-apis/access-systems).
        /// </summary>
        [DataMember(Name = "warnings", IsRequired = false, EmitDefaultValue = false)]
        public List<AcsSystemWarnings> Warnings { get; set; }

        /// <summary>
        /// ID of the workspace that contains the [access control system](https://docs.seam.co/low-level-apis/access-systems).
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

    [DataContract(Name = "seamModel_acsSystemLocation_model")]
    public class AcsSystemLocation
    {
        [JsonConstructorAttribute]
        protected AcsSystemLocation() { }

        public AcsSystemLocation(string? timeZone = default)
        {
            TimeZone = timeZone;
        }

        /// <summary>
        /// Time zone in which the [access control system](https://docs.seam.co/low-level-apis/access-systems) is located.
        /// </summary>
        [DataMember(Name = "time_zone", IsRequired = false, EmitDefaultValue = false)]
        public string? TimeZone { get; set; }

        public override string ToString()
        {
            JsonSerializer jsonSerializer = JsonSerializer.CreateDefault(null);

            StringWriter stringWriter = new StringWriter(
                new StringBuilder(256),
                System.Globalization.CultureInfo.InvariantCulture
            );
            using (JsonTextWriter jsonTextWriter = new JsonTextWriter(stringWriter))
            {
                jsonTextWriter.IndentChar = ' ';
                jsonTextWriter.Indentation = 2;
                jsonTextWriter.Formatting = Formatting.Indented;
                jsonSerializer.Serialize(jsonTextWriter, this, null);
            }

            return stringWriter.ToString();
        }
    }

    [DataContract(Name = "seamModel_acsSystemVisionlineMetadata_model")]
    public class AcsSystemVisionlineMetadata
    {
        [JsonConstructorAttribute]
        protected AcsSystemVisionlineMetadata() { }

        public AcsSystemVisionlineMetadata(
            string? lanAddress = default,
            string? mobileAccessUuid = default,
            string? systemId = default
        )
        {
            LanAddress = lanAddress;
            MobileAccessUuid = mobileAccessUuid;
            SystemId = systemId;
        }

        /// <summary>
        /// IP address or hostname of the main Visionline server relative to [Seam Bridge](https://docs.seam.co/capability-guides/seam-bridge) on the local network.
        /// </summary>
        [DataMember(Name = "lan_address", IsRequired = false, EmitDefaultValue = false)]
        public string? LanAddress { get; set; }

        /// <summary>
        /// Keyset loaded into a reader. Mobile keys and reader administration tools securely authenticate only with readers programmed with a matching keyset.
        /// </summary>
        [DataMember(Name = "mobile_access_uuid", IsRequired = false, EmitDefaultValue = false)]
        public string? MobileAccessUuid { get; set; }

        /// <summary>
        /// Unique ID assigned by the ASSA ABLOY licensing team that identifies each hotel in your credential manager.
        /// </summary>
        [DataMember(Name = "system_id", IsRequired = false, EmitDefaultValue = false)]
        public string? SystemId { get; set; }

        public override string ToString()
        {
            JsonSerializer jsonSerializer = JsonSerializer.CreateDefault(null);

            StringWriter stringWriter = new StringWriter(
                new StringBuilder(256),
                System.Globalization.CultureInfo.InvariantCulture
            );
            using (JsonTextWriter jsonTextWriter = new JsonTextWriter(stringWriter))
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
