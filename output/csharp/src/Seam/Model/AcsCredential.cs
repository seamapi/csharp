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
    /// Means by which an [access control system user](https://docs.seam.co/low-level-apis/access-systems/user-management) gains access at an [entrance](https://docs.seam.co/low-level-apis/access-systems/retrieving-entrance-details). The `acs_credential` object represents a [credential](https://docs.seam.co/low-level-apis/access-systems/managing-credentials) that provides an ACS user access within an [access control system](https://docs.seam.co/low-level-apis/access-systems).
    ///
    /// An access control system generally uses digital means of access to authorize a user trying to get through a specific entrance. Examples of credentials include plastic key cards, mobile keys, biometric identifiers, and PIN codes. The electronic nature of these credentials, as well as the fact that access is centralized, enables both the rapid provisioning and rescinding of access and the ability to compile access audit logs.
    ///
    /// For each `acs_credential`, you define the access method. You can also specify additional properties, such as a PIN code, depending on the credential type.
    ///
    /// For granting a person access to a space, [Access Grants](https://docs.seam.co/use-cases/granting-access) are the default and recommended approach. Use the lower-level ACS credential API directly only when you specifically need to manage individual credentials.
    /// </summary>
    [DataContract(Name = "seamModel_acsCredential_model")]
    public class AcsCredential
    {
        [JsonConstructorAttribute]
        protected AcsCredential() { }

        public AcsCredential(
            AcsCredential.AccessMethodEnum accessMethod = default,
            string acsCredentialId = default,
            string? acsCredentialPoolId = default,
            string acsSystemId = default,
            string? acsUserId = default,
            AcsCredentialAkilesMetadata? akilesMetadata = default,
            AcsCredentialAssaAbloyVostioMetadata? assaAbloyVostioMetadata = default,
            string? cardNumber = default,
            string? code = default,
            string connectedAccountId = default,
            string createdAt = default,
            string displayName = default,
            string? endsAt = default,
            List<AcsCredentialErrors> errors = default,
            AcsCredential.ExternalTypeEnum? externalType = default,
            string? externalTypeDisplayName = default,
            bool? isIssued = default,
            bool? isLatestDesiredStateSyncedWithProvider = default,
            bool isManaged = default,
            bool? isMultiPhoneSyncCredential = default,
            bool? isOneTimeUse = default,
            string? issuedAt = default,
            string? latestDesiredStateSyncedWithProviderAt = default,
            string? parentAcsCredentialId = default,
            string? startsAt = default,
            string? userIdentityId = default,
            AcsCredentialVisionlineMetadata? visionlineMetadata = default,
            List<AcsCredentialWarnings> warnings = default,
            string workspaceId = default
        )
        {
            AccessMethod = accessMethod;
            AcsCredentialId = acsCredentialId;
            AcsCredentialPoolId = acsCredentialPoolId;
            AcsSystemId = acsSystemId;
            AcsUserId = acsUserId;
            AkilesMetadata = akilesMetadata;
            AssaAbloyVostioMetadata = assaAbloyVostioMetadata;
            CardNumber = cardNumber;
            Code = code;
            ConnectedAccountId = connectedAccountId;
            CreatedAt = createdAt;
            DisplayName = displayName;
            EndsAt = endsAt;
            Errors = errors;
            ExternalType = externalType;
            ExternalTypeDisplayName = externalTypeDisplayName;
            IsIssued = isIssued;
            IsLatestDesiredStateSyncedWithProvider = isLatestDesiredStateSyncedWithProvider;
            IsManaged = isManaged;
            IsMultiPhoneSyncCredential = isMultiPhoneSyncCredential;
            IsOneTimeUse = isOneTimeUse;
            IssuedAt = issuedAt;
            LatestDesiredStateSyncedWithProviderAt = latestDesiredStateSyncedWithProviderAt;
            ParentAcsCredentialId = parentAcsCredentialId;
            StartsAt = startsAt;
            UserIdentityId = userIdentityId;
            VisionlineMetadata = visionlineMetadata;
            Warnings = warnings;
            WorkspaceId = workspaceId;
        }

        /// <summary>
        /// Access method for the [credential](https://docs.seam.co/low-level-apis/access-systems/managing-credentials). Supported values: `code`, `card`, `mobile_key`, `cloud_key`.
        /// </summary>
        [JsonConverter(typeof(SafeStringEnumConverter))]
        public enum AccessMethodEnum
        {
            [EnumMember(Value = "unrecognized")]
            Unrecognized = 0,

            [EnumMember(Value = "code")]
            Code = 1,

            [EnumMember(Value = "card")]
            Card = 2,

            [EnumMember(Value = "mobile_key")]
            MobileKey = 3,

            [EnumMember(Value = "cloud_key")]
            CloudKey = 4,
        }

        /// <summary>
        /// Brand-specific terminology for the [credential](https://docs.seam.co/low-level-apis/access-systems/managing-credentials) type. Supported values: `pti_card`, `brivo_credential`, `hid_credential`, `visionline_card`.
        /// </summary>
        [JsonConverter(typeof(SafeStringEnumConverter))]
        public enum ExternalTypeEnum
        {
            [EnumMember(Value = "unrecognized")]
            Unrecognized = 0,

            [EnumMember(Value = "pti_card")]
            PtiCard = 1,

            [EnumMember(Value = "brivo_credential")]
            BrivoCredential = 2,

            [EnumMember(Value = "hid_credential")]
            HidCredential = 3,

            [EnumMember(Value = "visionline_card")]
            VisionlineCard = 4,

            [EnumMember(Value = "salto_ks_credential")]
            SaltoKsCredential = 5,

            [EnumMember(Value = "assa_abloy_vostio_key")]
            AssaAbloyVostioKey = 6,

            [EnumMember(Value = "salto_space_key")]
            SaltoSpaceKey = 7,

            [EnumMember(Value = "latch_access")]
            LatchAccess = 8,

            [EnumMember(Value = "dormakaba_ambiance_credential")]
            DormakabaAmbianceCredential = 9,

            [EnumMember(Value = "hotek_card")]
            HotekCard = 10,

            [EnumMember(Value = "salto_ks_tag")]
            SaltoKsTag = 11,

            [EnumMember(Value = "avigilon_alta_credential")]
            AvigilonAltaCredential = 12,

            [EnumMember(Value = "kisi_credential")]
            KisiCredential = 13,

            [EnumMember(Value = "akiles_credential")]
            AkilesCredential = 14,
        }

        [JsonConverter(typeof(JsonSubtypes), "warning_code")]
        [JsonSubtypes.FallBackSubType(typeof(AcsCredentialWarningsUnrecognized))]
        [JsonSubtypes.KnownSubType(
            typeof(AcsCredentialWarningsRequestedCodeUnavailable),
            "requested_code_unavailable"
        )]
        [JsonSubtypes.KnownSubType(
            typeof(AcsCredentialWarningsNeedsToBeReissued),
            "needs_to_be_reissued"
        )]
        [JsonSubtypes.KnownSubType(
            typeof(AcsCredentialWarningsUnknownIssueWithAcsCredential),
            "unknown_issue_with_acs_credential"
        )]
        [JsonSubtypes.KnownSubType(typeof(AcsCredentialWarningsBeingDeleted), "being_deleted")]
        [JsonSubtypes.KnownSubType(
            typeof(AcsCredentialWarningsScheduleModified),
            "schedule_modified"
        )]
        [JsonSubtypes.KnownSubType(
            typeof(AcsCredentialWarningsScheduleExternallyModified),
            "schedule_externally_modified"
        )]
        [JsonSubtypes.KnownSubType(
            typeof(AcsCredentialWarningsWaitingToBeIssued),
            "waiting_to_be_issued"
        )]
        public abstract class AcsCredentialWarnings
        {
            public abstract string WarningCode { get; }

            public abstract string CreatedAt { get; set; }

            public abstract string Message { get; set; }

            public abstract override string ToString();
        }

        [DataContract(Name = "seamModel_acsCredentialWarningsWaitingToBeIssued_model")]
        public class AcsCredentialWarningsWaitingToBeIssued : AcsCredentialWarnings
        {
            [JsonConstructorAttribute]
            protected AcsCredentialWarningsWaitingToBeIssued() { }

            public AcsCredentialWarningsWaitingToBeIssued(
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
            public override string WarningCode { get; } = "waiting_to_be_issued";

            public override string ToString()
            {
                JsonSerializer jsonSerializer = JsonSerializer.CreateDefault(null);

                StringWriter stringWriter = new StringWriter(
                    new StringBuilder(256),
                    System.Globalization.CultureInfo.InvariantCulture
                );
                using (JsonTextWriter jsonTextWriter = new JsonTextWriter(stringWriter))
                {
                    jsonTextWriter.IndentChar = ' ';
                    jsonTextWriter.Indentation = 2;
                    jsonTextWriter.Formatting = Formatting.Indented;
                    jsonSerializer.Serialize(jsonTextWriter, this, null);
                }

                return stringWriter.ToString();
            }
        }

        [DataContract(Name = "seamModel_acsCredentialWarningsScheduleExternallyModified_model")]
        public class AcsCredentialWarningsScheduleExternallyModified : AcsCredentialWarnings
        {
            [JsonConstructorAttribute]
            protected AcsCredentialWarningsScheduleExternallyModified() { }

            public AcsCredentialWarningsScheduleExternallyModified(
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
            public override string WarningCode { get; } = "schedule_externally_modified";

            public override string ToString()
            {
                JsonSerializer jsonSerializer = JsonSerializer.CreateDefault(null);

                StringWriter stringWriter = new StringWriter(
                    new StringBuilder(256),
                    System.Globalization.CultureInfo.InvariantCulture
                );
                using (JsonTextWriter jsonTextWriter = new JsonTextWriter(stringWriter))
                {
                    jsonTextWriter.IndentChar = ' ';
                    jsonTextWriter.Indentation = 2;
                    jsonTextWriter.Formatting = Formatting.Indented;
                    jsonSerializer.Serialize(jsonTextWriter, this, null);
                }

                return stringWriter.ToString();
            }
        }

        [DataContract(Name = "seamModel_acsCredentialWarningsScheduleModified_model")]
        public class AcsCredentialWarningsScheduleModified : AcsCredentialWarnings
        {
            [JsonConstructorAttribute]
            protected AcsCredentialWarningsScheduleModified() { }

            public AcsCredentialWarningsScheduleModified(
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
            public override string WarningCode { get; } = "schedule_modified";

            public override string ToString()
            {
                JsonSerializer jsonSerializer = JsonSerializer.CreateDefault(null);

                StringWriter stringWriter = new StringWriter(
                    new StringBuilder(256),
                    System.Globalization.CultureInfo.InvariantCulture
                );
                using (JsonTextWriter jsonTextWriter = new JsonTextWriter(stringWriter))
                {
                    jsonTextWriter.IndentChar = ' ';
                    jsonTextWriter.Indentation = 2;
                    jsonTextWriter.Formatting = Formatting.Indented;
                    jsonSerializer.Serialize(jsonTextWriter, this, null);
                }

                return stringWriter.ToString();
            }
        }

        [DataContract(Name = "seamModel_acsCredentialWarningsBeingDeleted_model")]
        public class AcsCredentialWarningsBeingDeleted : AcsCredentialWarnings
        {
            [JsonConstructorAttribute]
            protected AcsCredentialWarningsBeingDeleted() { }

            public AcsCredentialWarningsBeingDeleted(
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

        [DataContract(Name = "seamModel_acsCredentialWarningsUnknownIssueWithAcsCredential_model")]
        public class AcsCredentialWarningsUnknownIssueWithAcsCredential : AcsCredentialWarnings
        {
            [JsonConstructorAttribute]
            protected AcsCredentialWarningsUnknownIssueWithAcsCredential() { }

            public AcsCredentialWarningsUnknownIssueWithAcsCredential(
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
            public override string WarningCode { get; } = "unknown_issue_with_acs_credential";

            public override string ToString()
            {
                JsonSerializer jsonSerializer = JsonSerializer.CreateDefault(null);

                StringWriter stringWriter = new StringWriter(
                    new StringBuilder(256),
                    System.Globalization.CultureInfo.InvariantCulture
                );
                using (JsonTextWriter jsonTextWriter = new JsonTextWriter(stringWriter))
                {
                    jsonTextWriter.IndentChar = ' ';
                    jsonTextWriter.Indentation = 2;
                    jsonTextWriter.Formatting = Formatting.Indented;
                    jsonSerializer.Serialize(jsonTextWriter, this, null);
                }

                return stringWriter.ToString();
            }
        }

        [DataContract(Name = "seamModel_acsCredentialWarningsNeedsToBeReissued_model")]
        public class AcsCredentialWarningsNeedsToBeReissued : AcsCredentialWarnings
        {
            [JsonConstructorAttribute]
            protected AcsCredentialWarningsNeedsToBeReissued() { }

            public AcsCredentialWarningsNeedsToBeReissued(
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
            public override string WarningCode { get; } = "needs_to_be_reissued";

            public override string ToString()
            {
                JsonSerializer jsonSerializer = JsonSerializer.CreateDefault(null);

                StringWriter stringWriter = new StringWriter(
                    new StringBuilder(256),
                    System.Globalization.CultureInfo.InvariantCulture
                );
                using (JsonTextWriter jsonTextWriter = new JsonTextWriter(stringWriter))
                {
                    jsonTextWriter.IndentChar = ' ';
                    jsonTextWriter.Indentation = 2;
                    jsonTextWriter.Formatting = Formatting.Indented;
                    jsonSerializer.Serialize(jsonTextWriter, this, null);
                }

                return stringWriter.ToString();
            }
        }

        [DataContract(Name = "seamModel_acsCredentialWarningsRequestedCodeUnavailable_model")]
        public class AcsCredentialWarningsRequestedCodeUnavailable : AcsCredentialWarnings
        {
            [JsonConstructorAttribute]
            protected AcsCredentialWarningsRequestedCodeUnavailable() { }

            public AcsCredentialWarningsRequestedCodeUnavailable(
                string createdAt = default,
                string message = default,
                string newCode = default,
                string originalCode = default,
                string warningCode = default
            )
            {
                CreatedAt = createdAt;
                Message = message;
                NewCode = newCode;
                OriginalCode = originalCode;
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
            /// The PIN code that was assigned instead.
            /// </summary>
            [DataMember(Name = "new_code", IsRequired = false, EmitDefaultValue = false)]
            public string NewCode { get; set; }

            /// <summary>
            /// The originally requested PIN code that could not be used.
            /// </summary>
            [DataMember(Name = "original_code", IsRequired = false, EmitDefaultValue = false)]
            public string OriginalCode { get; set; }

            [DataMember(Name = "warning_code", IsRequired = true, EmitDefaultValue = false)]
            public override string WarningCode { get; } = "requested_code_unavailable";

            public override string ToString()
            {
                JsonSerializer jsonSerializer = JsonSerializer.CreateDefault(null);

                StringWriter stringWriter = new StringWriter(
                    new StringBuilder(256),
                    System.Globalization.CultureInfo.InvariantCulture
                );
                using (JsonTextWriter jsonTextWriter = new JsonTextWriter(stringWriter))
                {
                    jsonTextWriter.IndentChar = ' ';
                    jsonTextWriter.Indentation = 2;
                    jsonTextWriter.Formatting = Formatting.Indented;
                    jsonSerializer.Serialize(jsonTextWriter, this, null);
                }

                return stringWriter.ToString();
            }
        }

        [DataContract(Name = "seamModel_acsCredentialWarningsUnrecognized_model")]
        public class AcsCredentialWarningsUnrecognized : AcsCredentialWarnings
        {
            [JsonConstructorAttribute]
            protected AcsCredentialWarningsUnrecognized() { }

            public AcsCredentialWarningsUnrecognized(
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
        /// Access method for the [credential](https://docs.seam.co/low-level-apis/access-systems/managing-credentials). Supported values: `code`, `card`, `mobile_key`, `cloud_key`.
        /// </summary>
        [DataMember(Name = "access_method", IsRequired = false, EmitDefaultValue = false)]
        public AcsCredential.AccessMethodEnum AccessMethod { get; set; }

        /// <summary>
        /// ID of the [credential](https://docs.seam.co/low-level-apis/access-systems/managing-credentials).
        /// </summary>
        [DataMember(Name = "acs_credential_id", IsRequired = false, EmitDefaultValue = false)]
        public string AcsCredentialId { get; set; }

        /// <summary>
        /// ID of the credential pool to which the credential belongs.
        /// </summary>
        [DataMember(Name = "acs_credential_pool_id", IsRequired = false, EmitDefaultValue = false)]
        public string? AcsCredentialPoolId { get; set; }

        /// <summary>
        /// ID of the [access control system](https://docs.seam.co/low-level-apis/access-systems) that contains the [credential](https://docs.seam.co/low-level-apis/access-systems/managing-credentials).
        /// </summary>
        [DataMember(Name = "acs_system_id", IsRequired = false, EmitDefaultValue = false)]
        public string AcsSystemId { get; set; }

        /// <summary>
        /// ID of the [ACS user](https://docs.seam.co/low-level-apis/access-systems/user-management) to whom the [credential](https://docs.seam.co/low-level-apis/access-systems/managing-credentials) belongs.
        /// </summary>
        [DataMember(Name = "acs_user_id", IsRequired = false, EmitDefaultValue = false)]
        public string? AcsUserId { get; set; }

        /// <summary>
        /// Akiles-specific metadata for the [credential](https://docs.seam.co/low-level-apis/access-systems/managing-credentials).
        /// </summary>
        [DataMember(Name = "akiles_metadata", IsRequired = false, EmitDefaultValue = false)]
        public AcsCredentialAkilesMetadata? AkilesMetadata { get; set; }

        /// <summary>
        /// Vostio-specific metadata for the [credential](https://docs.seam.co/low-level-apis/access-systems/managing-credentials).
        /// </summary>
        [DataMember(
            Name = "assa_abloy_vostio_metadata",
            IsRequired = false,
            EmitDefaultValue = false
        )]
        public AcsCredentialAssaAbloyVostioMetadata? AssaAbloyVostioMetadata { get; set; }

        /// <summary>
        /// Number of the card associated with the [credential](https://docs.seam.co/low-level-apis/access-systems/managing-credentials).
        /// </summary>
        [DataMember(Name = "card_number", IsRequired = false, EmitDefaultValue = false)]
        public string? CardNumber { get; set; }

        /// <summary>
        /// Access (PIN) code for the [credential](https://docs.seam.co/low-level-apis/access-systems/managing-credentials).
        /// </summary>
        [DataMember(Name = "code", IsRequired = false, EmitDefaultValue = false)]
        public string? Code { get; set; }

        /// <summary>
        /// ID of the [connected account](https://docs.seam.co/core-concepts/connected-accounts) to which the [credential](https://docs.seam.co/low-level-apis/access-systems/managing-credentials) belongs.
        /// </summary>
        [DataMember(Name = "connected_account_id", IsRequired = false, EmitDefaultValue = false)]
        public string ConnectedAccountId { get; set; }

        /// <summary>
        /// Date and time at which the [credential](https://docs.seam.co/low-level-apis/access-systems/managing-credentials) was created.
        /// </summary>
        [DataMember(Name = "created_at", IsRequired = false, EmitDefaultValue = false)]
        public string CreatedAt { get; set; }

        /// <summary>
        /// Display name that corresponds to the [credential](https://docs.seam.co/low-level-apis/access-systems/managing-credentials) type.
        /// </summary>
        [DataMember(Name = "display_name", IsRequired = false, EmitDefaultValue = false)]
        public string DisplayName { get; set; }

        /// <summary>
        /// Date and time at which the [credential](https://docs.seam.co/low-level-apis/access-systems/managing-credentials) validity ends, in [ISO 8601](https://www.iso.org/iso-8601-date-and-time-format.html) format. Must be a time in the future and after `starts_at`.
        /// </summary>
        [DataMember(Name = "ends_at", IsRequired = false, EmitDefaultValue = false)]
        public string? EndsAt { get; set; }

        /// <summary>
        /// Errors associated with the [credential](https://docs.seam.co/low-level-apis/access-systems/managing-credentials).
        /// </summary>
        [DataMember(Name = "errors", IsRequired = false, EmitDefaultValue = false)]
        public List<AcsCredentialErrors> Errors { get; set; }

        /// <summary>
        /// Brand-specific terminology for the [credential](https://docs.seam.co/low-level-apis/access-systems/managing-credentials) type. Supported values: `pti_card`, `brivo_credential`, `hid_credential`, `visionline_card`.
        /// </summary>
        [DataMember(Name = "external_type", IsRequired = false, EmitDefaultValue = false)]
        public AcsCredential.ExternalTypeEnum? ExternalType { get; set; }

        /// <summary>
        /// Display name that corresponds to the brand-specific terminology for the [credential](https://docs.seam.co/low-level-apis/access-systems/managing-credentials) type.
        /// </summary>
        [DataMember(
            Name = "external_type_display_name",
            IsRequired = false,
            EmitDefaultValue = false
        )]
        public string? ExternalTypeDisplayName { get; set; }

        /// <summary>
        /// Indicates whether the [credential](https://docs.seam.co/low-level-apis/access-systems/managing-credentials) has been encoded onto a card.
        /// </summary>
        [DataMember(Name = "is_issued", IsRequired = false, EmitDefaultValue = false)]
        public bool? IsIssued { get; set; }

        /// <summary>
        /// Indicates whether the latest state of the [credential](https://docs.seam.co/low-level-apis/access-systems/managing-credentials) has been synced from Seam to the provider.
        /// </summary>
        [DataMember(
            Name = "is_latest_desired_state_synced_with_provider",
            IsRequired = false,
            EmitDefaultValue = false
        )]
        public bool? IsLatestDesiredStateSyncedWithProvider { get; set; }

        /// <summary>
        /// Indicates whether Seam manages the credential.
        /// </summary>
        [DataMember(Name = "is_managed", IsRequired = false, EmitDefaultValue = false)]
        public bool IsManaged { get; set; }

        /// <summary>
        /// Indicates whether the [credential](https://docs.seam.co/low-level-apis/access-systems/managing-credentials) is a [multi-phone sync credential](https://docs.seam.co/capability-guides/mobile-access/issuing-mobile-credentials-from-an-access-control-system#what-are-multi-phone-sync-credentials).
        /// </summary>
        [DataMember(
            Name = "is_multi_phone_sync_credential",
            IsRequired = false,
            EmitDefaultValue = false
        )]
        public bool? IsMultiPhoneSyncCredential { get; set; }

        /// <summary>
        /// Indicates whether the [credential](https://docs.seam.co/low-level-apis/access-systems/managing-credentials) can only be used once. If `true`, the code becomes invalid after the first use.
        /// </summary>
        [DataMember(Name = "is_one_time_use", IsRequired = false, EmitDefaultValue = false)]
        public bool? IsOneTimeUse { get; set; }

        /// <summary>
        /// Date and time at which the [credential](https://docs.seam.co/low-level-apis/access-systems/managing-credentials) was encoded onto a card.
        /// </summary>
        [DataMember(Name = "issued_at", IsRequired = false, EmitDefaultValue = false)]
        public string? IssuedAt { get; set; }

        /// <summary>
        /// Date and time at which the state of the [credential](https://docs.seam.co/low-level-apis/access-systems/managing-credentials) was most recently synced from Seam to the provider.
        /// </summary>
        [DataMember(
            Name = "latest_desired_state_synced_with_provider_at",
            IsRequired = false,
            EmitDefaultValue = false
        )]
        public string? LatestDesiredStateSyncedWithProviderAt { get; set; }

        /// <summary>
        /// ID of the parent [credential](https://docs.seam.co/low-level-apis/access-systems/managing-credentials).
        /// </summary>
        [DataMember(
            Name = "parent_acs_credential_id",
            IsRequired = false,
            EmitDefaultValue = false
        )]
        public string? ParentAcsCredentialId { get; set; }

        /// <summary>
        /// Date and time at which the [credential](https://docs.seam.co/low-level-apis/access-systems/managing-credentials) validity starts, in [ISO 8601](https://www.iso.org/iso-8601-date-and-time-format.html) format.
        /// </summary>
        [DataMember(Name = "starts_at", IsRequired = false, EmitDefaultValue = false)]
        public string? StartsAt { get; set; }

        /// <summary>
        /// ID of the [user identity](https://docs.seam.co/api/user_identities) to whom the [credential](https://docs.seam.co/low-level-apis/access-systems/managing-credentials) belongs.
        /// </summary>
        [DataMember(Name = "user_identity_id", IsRequired = false, EmitDefaultValue = false)]
        public string? UserIdentityId { get; set; }

        /// <summary>
        /// Visionline-specific metadata for the [credential](https://docs.seam.co/low-level-apis/access-systems/managing-credentials).
        /// </summary>
        [DataMember(Name = "visionline_metadata", IsRequired = false, EmitDefaultValue = false)]
        public AcsCredentialVisionlineMetadata? VisionlineMetadata { get; set; }

        /// <summary>
        /// Warnings associated with the [credential](https://docs.seam.co/low-level-apis/access-systems/managing-credentials).
        /// </summary>
        [DataMember(Name = "warnings", IsRequired = false, EmitDefaultValue = false)]
        public List<AcsCredentialWarnings> Warnings { get; set; }

        /// <summary>
        /// ID of the workspace that contains the [credential](https://docs.seam.co/low-level-apis/access-systems/managing-credentials).
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

    [DataContract(Name = "seamModel_acsCredentialAkilesMetadata_model")]
    public class AcsCredentialAkilesMetadata
    {
        [JsonConstructorAttribute]
        protected AcsCredentialAkilesMetadata() { }

        public AcsCredentialAkilesMetadata(string? memberPinId = default)
        {
            MemberPinId = memberPinId;
        }

        /// <summary>
        /// ID of the Akiles member PIN.
        /// </summary>
        [DataMember(Name = "member_pin_id", IsRequired = false, EmitDefaultValue = false)]
        public string? MemberPinId { get; set; }

        public override string ToString()
        {
            JsonSerializer jsonSerializer = JsonSerializer.CreateDefault(null);

            StringWriter stringWriter = new StringWriter(
                new StringBuilder(256),
                System.Globalization.CultureInfo.InvariantCulture
            );
            using (JsonTextWriter jsonTextWriter = new JsonTextWriter(stringWriter))
            {
                jsonTextWriter.IndentChar = ' ';
                jsonTextWriter.Indentation = 2;
                jsonTextWriter.Formatting = Formatting.Indented;
                jsonSerializer.Serialize(jsonTextWriter, this, null);
            }

            return stringWriter.ToString();
        }
    }

    [DataContract(Name = "seamModel_acsCredentialAssaAbloyVostioMetadata_model")]
    public class AcsCredentialAssaAbloyVostioMetadata
    {
        [JsonConstructorAttribute]
        protected AcsCredentialAssaAbloyVostioMetadata() { }

        public AcsCredentialAssaAbloyVostioMetadata(
            bool? autoJoin = default,
            List<string>? doorNames = default,
            string? endpointId = default,
            string? keyId = default,
            string? keyIssuingRequestId = default,
            List<string>? overrideGuestAcsEntranceIds = default
        )
        {
            AutoJoin = autoJoin;
            DoorNames = doorNames;
            EndpointId = endpointId;
            KeyId = keyId;
            KeyIssuingRequestId = keyIssuingRequestId;
            OverrideGuestAcsEntranceIds = overrideGuestAcsEntranceIds;
        }

        /// <summary>
        /// Indicates whether the credential should auto-join. For an auto-join credential, Seam automatically issues an override card if there are no other cards and a joiner card if there are existing cards on the doors.
        /// </summary>
        [DataMember(Name = "auto_join", IsRequired = false, EmitDefaultValue = false)]
        public bool? AutoJoin { get; set; }

        /// <summary>
        /// Names of the doors to which to grant access in the Vostio access system.
        /// </summary>
        [DataMember(Name = "door_names", IsRequired = false, EmitDefaultValue = false)]
        public List<string>? DoorNames { get; set; }

        /// <summary>
        /// Endpoint ID in the Vostio access system.
        /// </summary>
        [DataMember(Name = "endpoint_id", IsRequired = false, EmitDefaultValue = false)]
        public string? EndpointId { get; set; }

        /// <summary>
        /// Key ID in the Vostio access system.
        /// </summary>
        [DataMember(Name = "key_id", IsRequired = false, EmitDefaultValue = false)]
        public string? KeyId { get; set; }

        /// <summary>
        /// Key issuing request ID in the Vostio access system.
        /// </summary>
        [DataMember(Name = "key_issuing_request_id", IsRequired = false, EmitDefaultValue = false)]
        public string? KeyIssuingRequestId { get; set; }

        /// <summary>
        /// IDs of the guest entrances to override in the Vostio access system.
        /// </summary>
        [DataMember(
            Name = "override_guest_acs_entrance_ids",
            IsRequired = false,
            EmitDefaultValue = false
        )]
        public List<string>? OverrideGuestAcsEntranceIds { get; set; }

        public override string ToString()
        {
            JsonSerializer jsonSerializer = JsonSerializer.CreateDefault(null);

            StringWriter stringWriter = new StringWriter(
                new StringBuilder(256),
                System.Globalization.CultureInfo.InvariantCulture
            );
            using (JsonTextWriter jsonTextWriter = new JsonTextWriter(stringWriter))
            {
                jsonTextWriter.IndentChar = ' ';
                jsonTextWriter.Indentation = 2;
                jsonTextWriter.Formatting = Formatting.Indented;
                jsonSerializer.Serialize(jsonTextWriter, this, null);
            }

            return stringWriter.ToString();
        }
    }

    [DataContract(Name = "seamModel_acsCredentialErrors_model")]
    public class AcsCredentialErrors
    {
        [JsonConstructorAttribute]
        protected AcsCredentialErrors() { }

        public AcsCredentialErrors(
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
        public string CreatedAt { get; set; }

        [DataMember(Name = "error_code", IsRequired = false, EmitDefaultValue = false)]
        public string ErrorCode { get; set; }

        [DataMember(Name = "message", IsRequired = false, EmitDefaultValue = false)]
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

    [DataContract(Name = "seamModel_acsCredentialVisionlineMetadata_model")]
    public class AcsCredentialVisionlineMetadata
    {
        [JsonConstructorAttribute]
        protected AcsCredentialVisionlineMetadata() { }

        public AcsCredentialVisionlineMetadata(
            bool? autoJoin = default,
            AcsCredentialVisionlineMetadata.CardFunctionTypeEnum? cardFunctionType = default,
            string? cardId = default,
            List<string>? commonAcsEntranceIds = default,
            string? credentialId = default,
            List<string>? guestAcsEntranceIds = default,
            bool? isValid = default,
            List<string>? joinerAcsCredentialIds = default
        )
        {
            AutoJoin = autoJoin;
            CardFunctionType = cardFunctionType;
            CardId = cardId;
            CommonAcsEntranceIds = commonAcsEntranceIds;
            CredentialId = credentialId;
            GuestAcsEntranceIds = guestAcsEntranceIds;
            IsValid = isValid;
            JoinerAcsCredentialIds = joinerAcsCredentialIds;
        }

        /// <summary>
        /// Card function type in the Visionline access system.
        /// </summary>
        [JsonConverter(typeof(SafeStringEnumConverter))]
        public enum CardFunctionTypeEnum
        {
            [EnumMember(Value = "unrecognized")]
            Unrecognized = 0,

            [EnumMember(Value = "guest")]
            Guest = 1,

            [EnumMember(Value = "staff")]
            Staff = 2,
        }

        /// <summary>
        /// Indicates whether the credential should auto-join. For an auto-join credential, Seam automatically issues an override card if there are no other cards and a joiner card if there are existing cards on the doors.
        /// </summary>
        [DataMember(Name = "auto_join", IsRequired = false, EmitDefaultValue = false)]
        public bool? AutoJoin { get; set; }

        /// <summary>
        /// Card function type in the Visionline access system.
        /// </summary>
        [DataMember(Name = "card_function_type", IsRequired = false, EmitDefaultValue = false)]
        public AcsCredentialVisionlineMetadata.CardFunctionTypeEnum? CardFunctionType { get; set; }

        /// <summary>
        /// ID of the card in the Visionline access system.
        /// </summary>
        [DataMember(Name = "card_id", IsRequired = false, EmitDefaultValue = false)]
        public string? CardId { get; set; }

        /// <summary>
        /// Common entrance IDs in the Visionline access system.
        /// </summary>
        [DataMember(Name = "common_acs_entrance_ids", IsRequired = false, EmitDefaultValue = false)]
        public List<string>? CommonAcsEntranceIds { get; set; }

        /// <summary>
        /// ID of the credential in the Visionline access system.
        /// </summary>
        [DataMember(Name = "credential_id", IsRequired = false, EmitDefaultValue = false)]
        public string? CredentialId { get; set; }

        /// <summary>
        /// Guest entrance IDs in the Visionline access system.
        /// </summary>
        [DataMember(Name = "guest_acs_entrance_ids", IsRequired = false, EmitDefaultValue = false)]
        public List<string>? GuestAcsEntranceIds { get; set; }

        /// <summary>
        /// Indicates whether the credential is valid.
        /// </summary>
        [DataMember(Name = "is_valid", IsRequired = false, EmitDefaultValue = false)]
        public bool? IsValid { get; set; }

        /// <summary>
        /// IDs of the credentials to which you want to join.
        /// </summary>
        [DataMember(
            Name = "joiner_acs_credential_ids",
            IsRequired = false,
            EmitDefaultValue = false
        )]
        public List<string>? JoinerAcsCredentialIds { get; set; }

        public override string ToString()
        {
            JsonSerializer jsonSerializer = JsonSerializer.CreateDefault(null);

            StringWriter stringWriter = new StringWriter(
                new StringBuilder(256),
                System.Globalization.CultureInfo.InvariantCulture
            );
            using (JsonTextWriter jsonTextWriter = new JsonTextWriter(stringWriter))
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
