using System.Runtime.Serialization;
using System.Text;
using JsonSubTypes;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using Seam.Model;

namespace Seam.Model
{
    [DataContract(Name = "seamModel_phoneSession_model")]
    public class PhoneSession
    {
        [JsonConstructorAttribute]
        protected PhoneSession() { }

        public PhoneSession(
            List<PhoneSessionProviderSessions> providerSessions = default,
            PhoneSessionUserIdentity userIdentity = default,
            string workspaceId = default
        )
        {
            ProviderSessions = providerSessions;
            UserIdentity = userIdentity;
            WorkspaceId = workspaceId;
        }

        [DataMember(Name = "provider_sessions", IsRequired = true, EmitDefaultValue = false)]
        public List<PhoneSessionProviderSessions> ProviderSessions { get; set; }

        [DataMember(Name = "user_identity", IsRequired = true, EmitDefaultValue = false)]
        public PhoneSessionUserIdentity UserIdentity { get; set; }

        [DataMember(Name = "workspace_id", IsRequired = true, EmitDefaultValue = false)]
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

    [DataContract(Name = "seamModel_phoneSessionProviderSessions_model")]
    public class PhoneSessionProviderSessions
    {
        [JsonConstructorAttribute]
        protected PhoneSessionProviderSessions() { }

        public PhoneSessionProviderSessions(
            List<PhoneSessionProviderSessionsAcsCredentials> acsCredentials = default,
            PhoneSessionProviderSessionsPhoneRegistration phoneRegistration = default
        )
        {
            AcsCredentials = acsCredentials;
            PhoneRegistration = phoneRegistration;
        }

        [DataMember(Name = "acs_credentials", IsRequired = true, EmitDefaultValue = false)]
        public List<PhoneSessionProviderSessionsAcsCredentials> AcsCredentials { get; set; }

        [DataMember(Name = "phone_registration", IsRequired = true, EmitDefaultValue = false)]
        public PhoneSessionProviderSessionsPhoneRegistration PhoneRegistration { get; set; }

        public override string ToString()
        {
            JsonSerializer jsonSerializer = JsonSerializer.CreateDefault(null);

            StringWriter stringWriter = new StringWriter(
                new StringBuilder(256),
                System.Globalization.CultureInfo.InvariantCulture
            );
            using (JsonTextWriter jsonTextWriter = new JsonTextWriter(stringWriter))
            {
                jsonTextWriter.IndentChar = ' ';
                jsonTextWriter.Indentation = 2;
                jsonTextWriter.Formatting = Formatting.Indented;
                jsonSerializer.Serialize(jsonTextWriter, this, null);
            }

            return stringWriter.ToString();
        }
    }

    [DataContract(Name = "seamModel_phoneSessionProviderSessionsAcsCredentials_model")]
    public class PhoneSessionProviderSessionsAcsCredentials
    {
        [JsonConstructorAttribute]
        protected PhoneSessionProviderSessionsAcsCredentials() { }

        public PhoneSessionProviderSessionsAcsCredentials(
            PhoneSessionProviderSessionsAcsCredentials.AccessMethodEnum accessMethod = default,
            string? acsCredentialId = default,
            string? acsCredentialPoolId = default,
            List<PhoneSessionProviderSessionsAcsCredentialsAcsEntrances> acsEntrances = default,
            string acsSystemId = default,
            string? acsUserId = default,
            PhoneSessionProviderSessionsAcsCredentialsAssaAbloyVostioMetadata? assaAbloyVostioMetadata =
                default,
            string? cardNumber = default,
            string? code = default,
            string connectedAccountId = default,
            string createdAt = default,
            string displayName = default,
            string? endsAt = default,
            List<PhoneSessionProviderSessionsAcsCredentialsErrors> errors = default,
            PhoneSessionProviderSessionsAcsCredentials.ExternalTypeEnum? externalType = default,
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
            PhoneSessionProviderSessionsAcsCredentialsVisionlineMetadata? visionlineMetadata =
                default,
            List<PhoneSessionProviderSessionsAcsCredentialsWarnings> warnings = default,
            string workspaceId = default
        )
        {
            AccessMethod = accessMethod;
            AcsCredentialId = acsCredentialId;
            AcsCredentialPoolId = acsCredentialPoolId;
            AcsEntrances = acsEntrances;
            AcsSystemId = acsSystemId;
            AcsUserId = acsUserId;
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
            MobileKey = 3
        }

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
            HotekCard = 10
        }

        [JsonConverter(typeof(JsonSubtypes), "warning_code")]
        [JsonSubtypes.FallBackSubType(
            typeof(PhoneSessionProviderSessionsAcsCredentialsWarningsUnknown)
        )]
        [JsonSubtypes.KnownSubType(
            typeof(PhoneSessionProviderSessionsAcsCredentialsWarningsNeedsToBeReissued),
            "needs_to_be_reissued"
        )]
        [JsonSubtypes.KnownSubType(
            typeof(PhoneSessionProviderSessionsAcsCredentialsWarningsUnknownIssueWithAcsCredential),
            "unknown_issue_with_acs_credential"
        )]
        [JsonSubtypes.KnownSubType(
            typeof(PhoneSessionProviderSessionsAcsCredentialsWarningsBeingDeleted),
            "being_deleted"
        )]
        [JsonSubtypes.KnownSubType(
            typeof(PhoneSessionProviderSessionsAcsCredentialsWarningsScheduleModified),
            "schedule_modified"
        )]
        [JsonSubtypes.KnownSubType(
            typeof(PhoneSessionProviderSessionsAcsCredentialsWarningsScheduleExternallyModified),
            "schedule_externally_modified"
        )]
        [JsonSubtypes.KnownSubType(
            typeof(PhoneSessionProviderSessionsAcsCredentialsWarningsWaitingToBeIssued),
            "waiting_to_be_issued"
        )]
        public abstract class PhoneSessionProviderSessionsAcsCredentialsWarnings
        {
            public abstract string WarningCode { get; }

            public abstract string Message { get; set; }

            public abstract override string ToString();
        }

        [DataContract(
            Name = "seamModel_phoneSessionProviderSessionsAcsCredentialsWarningsWaitingToBeIssued_model"
        )]
        public class PhoneSessionProviderSessionsAcsCredentialsWarningsWaitingToBeIssued
            : PhoneSessionProviderSessionsAcsCredentialsWarnings
        {
            [JsonConstructorAttribute]
            protected PhoneSessionProviderSessionsAcsCredentialsWarningsWaitingToBeIssued() { }

            public PhoneSessionProviderSessionsAcsCredentialsWarningsWaitingToBeIssued(
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

        [DataContract(
            Name = "seamModel_phoneSessionProviderSessionsAcsCredentialsWarningsScheduleExternallyModified_model"
        )]
        public class PhoneSessionProviderSessionsAcsCredentialsWarningsScheduleExternallyModified
            : PhoneSessionProviderSessionsAcsCredentialsWarnings
        {
            [JsonConstructorAttribute]
            protected PhoneSessionProviderSessionsAcsCredentialsWarningsScheduleExternallyModified()
            { }

            public PhoneSessionProviderSessionsAcsCredentialsWarningsScheduleExternallyModified(
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

        [DataContract(
            Name = "seamModel_phoneSessionProviderSessionsAcsCredentialsWarningsScheduleModified_model"
        )]
        public class PhoneSessionProviderSessionsAcsCredentialsWarningsScheduleModified
            : PhoneSessionProviderSessionsAcsCredentialsWarnings
        {
            [JsonConstructorAttribute]
            protected PhoneSessionProviderSessionsAcsCredentialsWarningsScheduleModified() { }

            public PhoneSessionProviderSessionsAcsCredentialsWarningsScheduleModified(
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

        [DataContract(
            Name = "seamModel_phoneSessionProviderSessionsAcsCredentialsWarningsBeingDeleted_model"
        )]
        public class PhoneSessionProviderSessionsAcsCredentialsWarningsBeingDeleted
            : PhoneSessionProviderSessionsAcsCredentialsWarnings
        {
            [JsonConstructorAttribute]
            protected PhoneSessionProviderSessionsAcsCredentialsWarningsBeingDeleted() { }

            public PhoneSessionProviderSessionsAcsCredentialsWarningsBeingDeleted(
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
            Name = "seamModel_phoneSessionProviderSessionsAcsCredentialsWarningsUnknownIssueWithAcsCredential_model"
        )]
        public class PhoneSessionProviderSessionsAcsCredentialsWarningsUnknownIssueWithAcsCredential
            : PhoneSessionProviderSessionsAcsCredentialsWarnings
        {
            [JsonConstructorAttribute]
            protected PhoneSessionProviderSessionsAcsCredentialsWarningsUnknownIssueWithAcsCredential()
            { }

            public PhoneSessionProviderSessionsAcsCredentialsWarningsUnknownIssueWithAcsCredential(
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

        [DataContract(
            Name = "seamModel_phoneSessionProviderSessionsAcsCredentialsWarningsNeedsToBeReissued_model"
        )]
        public class PhoneSessionProviderSessionsAcsCredentialsWarningsNeedsToBeReissued
            : PhoneSessionProviderSessionsAcsCredentialsWarnings
        {
            [JsonConstructorAttribute]
            protected PhoneSessionProviderSessionsAcsCredentialsWarningsNeedsToBeReissued() { }

            public PhoneSessionProviderSessionsAcsCredentialsWarningsNeedsToBeReissued(
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

        [DataContract(
            Name = "seamModel_phoneSessionProviderSessionsAcsCredentialsWarningsUnknown_model"
        )]
        public class PhoneSessionProviderSessionsAcsCredentialsWarningsUnknown
            : PhoneSessionProviderSessionsAcsCredentialsWarnings
        {
            [JsonConstructorAttribute]
            protected PhoneSessionProviderSessionsAcsCredentialsWarningsUnknown() { }

            public PhoneSessionProviderSessionsAcsCredentialsWarningsUnknown(
                string warningCode = default,
                string message = default
            )
            {
                WarningCode = warningCode;
                Message = message;
            }

            [DataMember(Name = "warning_code", IsRequired = true, EmitDefaultValue = false)]
            public override string WarningCode { get; } = "unknown";

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

        [DataMember(Name = "access_method", IsRequired = true, EmitDefaultValue = false)]
        public PhoneSessionProviderSessionsAcsCredentials.AccessMethodEnum AccessMethod { get; set; }

        [DataMember(Name = "acs_credential_id", IsRequired = false, EmitDefaultValue = false)]
        public string? AcsCredentialId { get; set; }

        [DataMember(Name = "acs_credential_pool_id", IsRequired = false, EmitDefaultValue = false)]
        public string? AcsCredentialPoolId { get; set; }

        [DataMember(Name = "acs_entrances", IsRequired = true, EmitDefaultValue = false)]
        public List<PhoneSessionProviderSessionsAcsCredentialsAcsEntrances> AcsEntrances { get; set; }

        [DataMember(Name = "acs_system_id", IsRequired = true, EmitDefaultValue = false)]
        public string AcsSystemId { get; set; }

        [DataMember(Name = "acs_user_id", IsRequired = false, EmitDefaultValue = false)]
        public string? AcsUserId { get; set; }

        [DataMember(
            Name = "assa_abloy_vostio_metadata",
            IsRequired = false,
            EmitDefaultValue = false
        )]
        public PhoneSessionProviderSessionsAcsCredentialsAssaAbloyVostioMetadata? AssaAbloyVostioMetadata { get; set; }

        [DataMember(Name = "card_number", IsRequired = false, EmitDefaultValue = false)]
        public string? CardNumber { get; set; }

        [DataMember(Name = "code", IsRequired = false, EmitDefaultValue = false)]
        public string? Code { get; set; }

        [DataMember(Name = "connected_account_id", IsRequired = true, EmitDefaultValue = false)]
        public string ConnectedAccountId { get; set; }

        [DataMember(Name = "created_at", IsRequired = true, EmitDefaultValue = false)]
        public string CreatedAt { get; set; }

        [DataMember(Name = "display_name", IsRequired = true, EmitDefaultValue = false)]
        public string DisplayName { get; set; }

        [DataMember(Name = "ends_at", IsRequired = false, EmitDefaultValue = false)]
        public string? EndsAt { get; set; }

        [DataMember(Name = "errors", IsRequired = true, EmitDefaultValue = false)]
        public List<PhoneSessionProviderSessionsAcsCredentialsErrors> Errors { get; set; }

        [DataMember(Name = "external_type", IsRequired = false, EmitDefaultValue = false)]
        public PhoneSessionProviderSessionsAcsCredentials.ExternalTypeEnum? ExternalType { get; set; }

        [DataMember(
            Name = "external_type_display_name",
            IsRequired = false,
            EmitDefaultValue = false
        )]
        public string? ExternalTypeDisplayName { get; set; }

        [DataMember(Name = "is_issued", IsRequired = false, EmitDefaultValue = false)]
        public bool? IsIssued { get; set; }

        [DataMember(
            Name = "is_latest_desired_state_synced_with_provider",
            IsRequired = false,
            EmitDefaultValue = false
        )]
        public bool? IsLatestDesiredStateSyncedWithProvider { get; set; }

        [DataMember(Name = "is_managed", IsRequired = true, EmitDefaultValue = false)]
        public bool IsManaged { get; set; }

        [DataMember(
            Name = "is_multi_phone_sync_credential",
            IsRequired = false,
            EmitDefaultValue = false
        )]
        public bool? IsMultiPhoneSyncCredential { get; set; }

        [DataMember(Name = "is_one_time_use", IsRequired = false, EmitDefaultValue = false)]
        public bool? IsOneTimeUse { get; set; }

        [DataMember(Name = "issued_at", IsRequired = false, EmitDefaultValue = false)]
        public string? IssuedAt { get; set; }

        [DataMember(
            Name = "latest_desired_state_synced_with_provider_at",
            IsRequired = false,
            EmitDefaultValue = false
        )]
        public string? LatestDesiredStateSyncedWithProviderAt { get; set; }

        [DataMember(
            Name = "parent_acs_credential_id",
            IsRequired = false,
            EmitDefaultValue = false
        )]
        public string? ParentAcsCredentialId { get; set; }

        [DataMember(Name = "starts_at", IsRequired = false, EmitDefaultValue = false)]
        public string? StartsAt { get; set; }

        [DataMember(Name = "user_identity_id", IsRequired = false, EmitDefaultValue = false)]
        public string? UserIdentityId { get; set; }

        [DataMember(Name = "visionline_metadata", IsRequired = false, EmitDefaultValue = false)]
        public PhoneSessionProviderSessionsAcsCredentialsVisionlineMetadata? VisionlineMetadata { get; set; }

        [DataMember(Name = "warnings", IsRequired = true, EmitDefaultValue = false)]
        public List<PhoneSessionProviderSessionsAcsCredentialsWarnings> Warnings { get; set; }

        [DataMember(Name = "workspace_id", IsRequired = true, EmitDefaultValue = false)]
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

    [DataContract(Name = "seamModel_phoneSessionProviderSessionsAcsCredentialsAcsEntrances_model")]
    public class PhoneSessionProviderSessionsAcsCredentialsAcsEntrances
    {
        [JsonConstructorAttribute]
        protected PhoneSessionProviderSessionsAcsCredentialsAcsEntrances() { }

        public PhoneSessionProviderSessionsAcsCredentialsAcsEntrances(
            string acsEntranceId = default,
            string acsSystemId = default,
            PhoneSessionProviderSessionsAcsCredentialsAcsEntrancesAssaAbloyVostioMetadata? assaAbloyVostioMetadata =
                default,
            bool? canUnlockWithCard = default,
            bool? canUnlockWithCode = default,
            bool? canUnlockWithMobileKey = default,
            string connectedAccountId = default,
            string createdAt = default,
            string displayName = default,
            PhoneSessionProviderSessionsAcsCredentialsAcsEntrancesDormakabaAmbianceMetadata? dormakabaAmbianceMetadata =
                default,
            PhoneSessionProviderSessionsAcsCredentialsAcsEntrancesDormakabaCommunityMetadata? dormakabaCommunityMetadata =
                default,
            List<PhoneSessionProviderSessionsAcsCredentialsAcsEntrancesErrors> errors = default,
            PhoneSessionProviderSessionsAcsCredentialsAcsEntrancesHotekMetadata? hotekMetadata =
                default,
            PhoneSessionProviderSessionsAcsCredentialsAcsEntrancesLatchMetadata? latchMetadata =
                default,
            PhoneSessionProviderSessionsAcsCredentialsAcsEntrancesSaltoKsMetadata? saltoKsMetadata =
                default,
            PhoneSessionProviderSessionsAcsCredentialsAcsEntrancesSaltoSpaceMetadata? saltoSpaceMetadata =
                default,
            PhoneSessionProviderSessionsAcsCredentialsAcsEntrancesVisionlineMetadata? visionlineMetadata =
                default
        )
        {
            AcsEntranceId = acsEntranceId;
            AcsSystemId = acsSystemId;
            AssaAbloyVostioMetadata = assaAbloyVostioMetadata;
            CanUnlockWithCard = canUnlockWithCard;
            CanUnlockWithCode = canUnlockWithCode;
            CanUnlockWithMobileKey = canUnlockWithMobileKey;
            ConnectedAccountId = connectedAccountId;
            CreatedAt = createdAt;
            DisplayName = displayName;
            DormakabaAmbianceMetadata = dormakabaAmbianceMetadata;
            DormakabaCommunityMetadata = dormakabaCommunityMetadata;
            Errors = errors;
            HotekMetadata = hotekMetadata;
            LatchMetadata = latchMetadata;
            SaltoKsMetadata = saltoKsMetadata;
            SaltoSpaceMetadata = saltoSpaceMetadata;
            VisionlineMetadata = visionlineMetadata;
        }

        [DataMember(Name = "acs_entrance_id", IsRequired = true, EmitDefaultValue = false)]
        public string AcsEntranceId { get; set; }

        [DataMember(Name = "acs_system_id", IsRequired = true, EmitDefaultValue = false)]
        public string AcsSystemId { get; set; }

        [DataMember(
            Name = "assa_abloy_vostio_metadata",
            IsRequired = false,
            EmitDefaultValue = false
        )]
        public PhoneSessionProviderSessionsAcsCredentialsAcsEntrancesAssaAbloyVostioMetadata? AssaAbloyVostioMetadata { get; set; }

        [DataMember(Name = "can_unlock_with_card", IsRequired = false, EmitDefaultValue = false)]
        public bool? CanUnlockWithCard { get; set; }

        [DataMember(Name = "can_unlock_with_code", IsRequired = false, EmitDefaultValue = false)]
        public bool? CanUnlockWithCode { get; set; }

        [DataMember(
            Name = "can_unlock_with_mobile_key",
            IsRequired = false,
            EmitDefaultValue = false
        )]
        public bool? CanUnlockWithMobileKey { get; set; }

        [DataMember(Name = "connected_account_id", IsRequired = true, EmitDefaultValue = false)]
        public string ConnectedAccountId { get; set; }

        [DataMember(Name = "created_at", IsRequired = true, EmitDefaultValue = false)]
        public string CreatedAt { get; set; }

        [DataMember(Name = "display_name", IsRequired = true, EmitDefaultValue = false)]
        public string DisplayName { get; set; }

        [DataMember(
            Name = "dormakaba_ambiance_metadata",
            IsRequired = false,
            EmitDefaultValue = false
        )]
        public PhoneSessionProviderSessionsAcsCredentialsAcsEntrancesDormakabaAmbianceMetadata? DormakabaAmbianceMetadata { get; set; }

        [DataMember(
            Name = "dormakaba_community_metadata",
            IsRequired = false,
            EmitDefaultValue = false
        )]
        public PhoneSessionProviderSessionsAcsCredentialsAcsEntrancesDormakabaCommunityMetadata? DormakabaCommunityMetadata { get; set; }

        [DataMember(Name = "errors", IsRequired = true, EmitDefaultValue = false)]
        public List<PhoneSessionProviderSessionsAcsCredentialsAcsEntrancesErrors> Errors { get; set; }

        [DataMember(Name = "hotek_metadata", IsRequired = false, EmitDefaultValue = false)]
        public PhoneSessionProviderSessionsAcsCredentialsAcsEntrancesHotekMetadata? HotekMetadata { get; set; }

        [DataMember(Name = "latch_metadata", IsRequired = false, EmitDefaultValue = false)]
        public PhoneSessionProviderSessionsAcsCredentialsAcsEntrancesLatchMetadata? LatchMetadata { get; set; }

        [DataMember(Name = "salto_ks_metadata", IsRequired = false, EmitDefaultValue = false)]
        public PhoneSessionProviderSessionsAcsCredentialsAcsEntrancesSaltoKsMetadata? SaltoKsMetadata { get; set; }

        [DataMember(Name = "salto_space_metadata", IsRequired = false, EmitDefaultValue = false)]
        public PhoneSessionProviderSessionsAcsCredentialsAcsEntrancesSaltoSpaceMetadata? SaltoSpaceMetadata { get; set; }

        [DataMember(Name = "visionline_metadata", IsRequired = false, EmitDefaultValue = false)]
        public PhoneSessionProviderSessionsAcsCredentialsAcsEntrancesVisionlineMetadata? VisionlineMetadata { get; set; }

        public override string ToString()
        {
            JsonSerializer jsonSerializer = JsonSerializer.CreateDefault(null);

            StringWriter stringWriter = new StringWriter(
                new StringBuilder(256),
                System.Globalization.CultureInfo.InvariantCulture
            );
            using (JsonTextWriter jsonTextWriter = new JsonTextWriter(stringWriter))
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
        Name = "seamModel_phoneSessionProviderSessionsAcsCredentialsAcsEntrancesAssaAbloyVostioMetadata_model"
    )]
    public class PhoneSessionProviderSessionsAcsCredentialsAcsEntrancesAssaAbloyVostioMetadata
    {
        [JsonConstructorAttribute]
        protected PhoneSessionProviderSessionsAcsCredentialsAcsEntrancesAssaAbloyVostioMetadata()
        { }

        public PhoneSessionProviderSessionsAcsCredentialsAcsEntrancesAssaAbloyVostioMetadata(
            string doorName = default,
            float? doorNumber = default,
            PhoneSessionProviderSessionsAcsCredentialsAcsEntrancesAssaAbloyVostioMetadata.DoorTypeEnum doorType =
                default,
            string? pmsId = default,
            bool? standOpen = default
        )
        {
            DoorName = doorName;
            DoorNumber = doorNumber;
            DoorType = doorType;
            PmsId = pmsId;
            StandOpen = standOpen;
        }

        [JsonConverter(typeof(SafeStringEnumConverter))]
        public enum DoorTypeEnum
        {
            [EnumMember(Value = "unrecognized")]
            Unrecognized = 0,

            [EnumMember(Value = "CommonDoor")]
            CommonDoor = 1,

            [EnumMember(Value = "EntranceDoor")]
            EntranceDoor = 2,

            [EnumMember(Value = "GuestDoor")]
            GuestDoor = 3,

            [EnumMember(Value = "Elevator")]
            Elevator = 4
        }

        [DataMember(Name = "door_name", IsRequired = true, EmitDefaultValue = false)]
        public string DoorName { get; set; }

        [DataMember(Name = "door_number", IsRequired = false, EmitDefaultValue = false)]
        public float? DoorNumber { get; set; }

        [DataMember(Name = "door_type", IsRequired = true, EmitDefaultValue = false)]
        public PhoneSessionProviderSessionsAcsCredentialsAcsEntrancesAssaAbloyVostioMetadata.DoorTypeEnum DoorType { get; set; }

        [DataMember(Name = "pms_id", IsRequired = false, EmitDefaultValue = false)]
        public string? PmsId { get; set; }

        [DataMember(Name = "stand_open", IsRequired = false, EmitDefaultValue = false)]
        public bool? StandOpen { get; set; }

        public override string ToString()
        {
            JsonSerializer jsonSerializer = JsonSerializer.CreateDefault(null);

            StringWriter stringWriter = new StringWriter(
                new StringBuilder(256),
                System.Globalization.CultureInfo.InvariantCulture
            );
            using (JsonTextWriter jsonTextWriter = new JsonTextWriter(stringWriter))
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
        Name = "seamModel_phoneSessionProviderSessionsAcsCredentialsAcsEntrancesDormakabaAmbianceMetadata_model"
    )]
    public class PhoneSessionProviderSessionsAcsCredentialsAcsEntrancesDormakabaAmbianceMetadata
    {
        [JsonConstructorAttribute]
        protected PhoneSessionProviderSessionsAcsCredentialsAcsEntrancesDormakabaAmbianceMetadata()
        { }

        public PhoneSessionProviderSessionsAcsCredentialsAcsEntrancesDormakabaAmbianceMetadata(
            string accessPointName = default
        )
        {
            AccessPointName = accessPointName;
        }

        [DataMember(Name = "access_point_name", IsRequired = true, EmitDefaultValue = false)]
        public string AccessPointName { get; set; }

        public override string ToString()
        {
            JsonSerializer jsonSerializer = JsonSerializer.CreateDefault(null);

            StringWriter stringWriter = new StringWriter(
                new StringBuilder(256),
                System.Globalization.CultureInfo.InvariantCulture
            );
            using (JsonTextWriter jsonTextWriter = new JsonTextWriter(stringWriter))
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
        Name = "seamModel_phoneSessionProviderSessionsAcsCredentialsAcsEntrancesDormakabaCommunityMetadata_model"
    )]
    public class PhoneSessionProviderSessionsAcsCredentialsAcsEntrancesDormakabaCommunityMetadata
    {
        [JsonConstructorAttribute]
        protected PhoneSessionProviderSessionsAcsCredentialsAcsEntrancesDormakabaCommunityMetadata()
        { }

        public PhoneSessionProviderSessionsAcsCredentialsAcsEntrancesDormakabaCommunityMetadata(
            string accessPointName = default,
            string accessPointProfile = default
        )
        {
            AccessPointName = accessPointName;
            AccessPointProfile = accessPointProfile;
        }

        [DataMember(Name = "access_point_name", IsRequired = true, EmitDefaultValue = false)]
        public string AccessPointName { get; set; }

        [DataMember(Name = "access_point_profile", IsRequired = true, EmitDefaultValue = false)]
        public string AccessPointProfile { get; set; }

        public override string ToString()
        {
            JsonSerializer jsonSerializer = JsonSerializer.CreateDefault(null);

            StringWriter stringWriter = new StringWriter(
                new StringBuilder(256),
                System.Globalization.CultureInfo.InvariantCulture
            );
            using (JsonTextWriter jsonTextWriter = new JsonTextWriter(stringWriter))
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
        Name = "seamModel_phoneSessionProviderSessionsAcsCredentialsAcsEntrancesErrors_model"
    )]
    public class PhoneSessionProviderSessionsAcsCredentialsAcsEntrancesErrors
    {
        [JsonConstructorAttribute]
        protected PhoneSessionProviderSessionsAcsCredentialsAcsEntrancesErrors() { }

        public PhoneSessionProviderSessionsAcsCredentialsAcsEntrancesErrors(
            string errorCode = default,
            string message = default
        )
        {
            ErrorCode = errorCode;
            Message = message;
        }

        [DataMember(Name = "error_code", IsRequired = true, EmitDefaultValue = false)]
        public string ErrorCode { get; set; }

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
        Name = "seamModel_phoneSessionProviderSessionsAcsCredentialsAcsEntrancesHotekMetadata_model"
    )]
    public class PhoneSessionProviderSessionsAcsCredentialsAcsEntrancesHotekMetadata
    {
        [JsonConstructorAttribute]
        protected PhoneSessionProviderSessionsAcsCredentialsAcsEntrancesHotekMetadata() { }

        public PhoneSessionProviderSessionsAcsCredentialsAcsEntrancesHotekMetadata(
            string displayName = default,
            PhoneSessionProviderSessionsAcsCredentialsAcsEntrancesHotekMetadata.DoorTypeEnum doorType =
                default,
            string roomNumber = default
        )
        {
            DisplayName = displayName;
            DoorType = doorType;
            RoomNumber = roomNumber;
        }

        [JsonConverter(typeof(SafeStringEnumConverter))]
        public enum DoorTypeEnum
        {
            [EnumMember(Value = "unrecognized")]
            Unrecognized = 0,

            [EnumMember(Value = "common_area")]
            CommonArea = 1,

            [EnumMember(Value = "guest")]
            Guest = 2
        }

        [DataMember(Name = "display_name", IsRequired = true, EmitDefaultValue = false)]
        public string DisplayName { get; set; }

        [DataMember(Name = "door_type", IsRequired = true, EmitDefaultValue = false)]
        public PhoneSessionProviderSessionsAcsCredentialsAcsEntrancesHotekMetadata.DoorTypeEnum DoorType { get; set; }

        [DataMember(Name = "room_number", IsRequired = true, EmitDefaultValue = false)]
        public string RoomNumber { get; set; }

        public override string ToString()
        {
            JsonSerializer jsonSerializer = JsonSerializer.CreateDefault(null);

            StringWriter stringWriter = new StringWriter(
                new StringBuilder(256),
                System.Globalization.CultureInfo.InvariantCulture
            );
            using (JsonTextWriter jsonTextWriter = new JsonTextWriter(stringWriter))
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
        Name = "seamModel_phoneSessionProviderSessionsAcsCredentialsAcsEntrancesLatchMetadata_model"
    )]
    public class PhoneSessionProviderSessionsAcsCredentialsAcsEntrancesLatchMetadata
    {
        [JsonConstructorAttribute]
        protected PhoneSessionProviderSessionsAcsCredentialsAcsEntrancesLatchMetadata() { }

        public PhoneSessionProviderSessionsAcsCredentialsAcsEntrancesLatchMetadata(
            string accessibilityType = default,
            string doorName = default,
            string doorType = default,
            bool isConnected = default
        )
        {
            AccessibilityType = accessibilityType;
            DoorName = doorName;
            DoorType = doorType;
            IsConnected = isConnected;
        }

        [DataMember(Name = "accessibility_type", IsRequired = true, EmitDefaultValue = false)]
        public string AccessibilityType { get; set; }

        [DataMember(Name = "door_name", IsRequired = true, EmitDefaultValue = false)]
        public string DoorName { get; set; }

        [DataMember(Name = "door_type", IsRequired = true, EmitDefaultValue = false)]
        public string DoorType { get; set; }

        [DataMember(Name = "is_connected", IsRequired = true, EmitDefaultValue = false)]
        public bool IsConnected { get; set; }

        public override string ToString()
        {
            JsonSerializer jsonSerializer = JsonSerializer.CreateDefault(null);

            StringWriter stringWriter = new StringWriter(
                new StringBuilder(256),
                System.Globalization.CultureInfo.InvariantCulture
            );
            using (JsonTextWriter jsonTextWriter = new JsonTextWriter(stringWriter))
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
        Name = "seamModel_phoneSessionProviderSessionsAcsCredentialsAcsEntrancesSaltoKsMetadata_model"
    )]
    public class PhoneSessionProviderSessionsAcsCredentialsAcsEntrancesSaltoKsMetadata
    {
        [JsonConstructorAttribute]
        protected PhoneSessionProviderSessionsAcsCredentialsAcsEntrancesSaltoKsMetadata() { }

        public PhoneSessionProviderSessionsAcsCredentialsAcsEntrancesSaltoKsMetadata(
            string batteryLevel = default,
            string doorName = default,
            bool? intrusionAlarm = default,
            bool? leftOpenAlarm = default,
            string lockType = default,
            string lockedState = default,
            bool? online = default,
            bool? privacyMode = default
        )
        {
            BatteryLevel = batteryLevel;
            DoorName = doorName;
            IntrusionAlarm = intrusionAlarm;
            LeftOpenAlarm = leftOpenAlarm;
            LockType = lockType;
            LockedState = lockedState;
            Online = online;
            PrivacyMode = privacyMode;
        }

        [DataMember(Name = "battery_level", IsRequired = true, EmitDefaultValue = false)]
        public string BatteryLevel { get; set; }

        [DataMember(Name = "door_name", IsRequired = true, EmitDefaultValue = false)]
        public string DoorName { get; set; }

        [DataMember(Name = "intrusion_alarm", IsRequired = false, EmitDefaultValue = false)]
        public bool? IntrusionAlarm { get; set; }

        [DataMember(Name = "left_open_alarm", IsRequired = false, EmitDefaultValue = false)]
        public bool? LeftOpenAlarm { get; set; }

        [DataMember(Name = "lock_type", IsRequired = true, EmitDefaultValue = false)]
        public string LockType { get; set; }

        [DataMember(Name = "locked_state", IsRequired = true, EmitDefaultValue = false)]
        public string LockedState { get; set; }

        [DataMember(Name = "online", IsRequired = false, EmitDefaultValue = false)]
        public bool? Online { get; set; }

        [DataMember(Name = "privacy_mode", IsRequired = false, EmitDefaultValue = false)]
        public bool? PrivacyMode { get; set; }

        public override string ToString()
        {
            JsonSerializer jsonSerializer = JsonSerializer.CreateDefault(null);

            StringWriter stringWriter = new StringWriter(
                new StringBuilder(256),
                System.Globalization.CultureInfo.InvariantCulture
            );
            using (JsonTextWriter jsonTextWriter = new JsonTextWriter(stringWriter))
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
        Name = "seamModel_phoneSessionProviderSessionsAcsCredentialsAcsEntrancesSaltoSpaceMetadata_model"
    )]
    public class PhoneSessionProviderSessionsAcsCredentialsAcsEntrancesSaltoSpaceMetadata
    {
        [JsonConstructorAttribute]
        protected PhoneSessionProviderSessionsAcsCredentialsAcsEntrancesSaltoSpaceMetadata() { }

        public PhoneSessionProviderSessionsAcsCredentialsAcsEntrancesSaltoSpaceMetadata(
            string? doorDescription = default,
            string? doorId = default,
            string? doorName = default,
            string? extDoorId = default,
            string? roomDescription = default,
            string? roomName = default
        )
        {
            DoorDescription = doorDescription;
            DoorId = doorId;
            DoorName = doorName;
            ExtDoorId = extDoorId;
            RoomDescription = roomDescription;
            RoomName = roomName;
        }

        [DataMember(Name = "door_description", IsRequired = false, EmitDefaultValue = false)]
        public string? DoorDescription { get; set; }

        [DataMember(Name = "door_id", IsRequired = false, EmitDefaultValue = false)]
        public string? DoorId { get; set; }

        [DataMember(Name = "door_name", IsRequired = false, EmitDefaultValue = false)]
        public string? DoorName { get; set; }

        [DataMember(Name = "ext_door_id", IsRequired = false, EmitDefaultValue = false)]
        public string? ExtDoorId { get; set; }

        [DataMember(Name = "room_description", IsRequired = false, EmitDefaultValue = false)]
        public string? RoomDescription { get; set; }

        [DataMember(Name = "room_name", IsRequired = false, EmitDefaultValue = false)]
        public string? RoomName { get; set; }

        public override string ToString()
        {
            JsonSerializer jsonSerializer = JsonSerializer.CreateDefault(null);

            StringWriter stringWriter = new StringWriter(
                new StringBuilder(256),
                System.Globalization.CultureInfo.InvariantCulture
            );
            using (JsonTextWriter jsonTextWriter = new JsonTextWriter(stringWriter))
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
        Name = "seamModel_phoneSessionProviderSessionsAcsCredentialsAcsEntrancesVisionlineMetadata_model"
    )]
    public class PhoneSessionProviderSessionsAcsCredentialsAcsEntrancesVisionlineMetadata
    {
        [JsonConstructorAttribute]
        protected PhoneSessionProviderSessionsAcsCredentialsAcsEntrancesVisionlineMetadata() { }

        public PhoneSessionProviderSessionsAcsCredentialsAcsEntrancesVisionlineMetadata(
            PhoneSessionProviderSessionsAcsCredentialsAcsEntrancesVisionlineMetadata.DoorCategoryEnum doorCategory =
                default,
            string doorName = default,
            List<PhoneSessionProviderSessionsAcsCredentialsAcsEntrancesVisionlineMetadataProfiles>? profiles =
                default
        )
        {
            DoorCategory = doorCategory;
            DoorName = doorName;
            Profiles = profiles;
        }

        [JsonConverter(typeof(SafeStringEnumConverter))]
        public enum DoorCategoryEnum
        {
            [EnumMember(Value = "unrecognized")]
            Unrecognized = 0,

            [EnumMember(Value = "entrance")]
            Entrance = 1,

            [EnumMember(Value = "guest")]
            Guest = 2,

            [EnumMember(Value = "elevator reader")]
            ElevatorReader = 3,

            [EnumMember(Value = "common")]
            Common = 4,

            [EnumMember(Value = "common (PMS)")]
            CommonPms = 5
        }

        [DataMember(Name = "door_category", IsRequired = true, EmitDefaultValue = false)]
        public PhoneSessionProviderSessionsAcsCredentialsAcsEntrancesVisionlineMetadata.DoorCategoryEnum DoorCategory { get; set; }

        [DataMember(Name = "door_name", IsRequired = true, EmitDefaultValue = false)]
        public string DoorName { get; set; }

        [DataMember(Name = "profiles", IsRequired = false, EmitDefaultValue = false)]
        public List<PhoneSessionProviderSessionsAcsCredentialsAcsEntrancesVisionlineMetadataProfiles>? Profiles { get; set; }

        public override string ToString()
        {
            JsonSerializer jsonSerializer = JsonSerializer.CreateDefault(null);

            StringWriter stringWriter = new StringWriter(
                new StringBuilder(256),
                System.Globalization.CultureInfo.InvariantCulture
            );
            using (JsonTextWriter jsonTextWriter = new JsonTextWriter(stringWriter))
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
        Name = "seamModel_phoneSessionProviderSessionsAcsCredentialsAcsEntrancesVisionlineMetadataProfiles_model"
    )]
    public class PhoneSessionProviderSessionsAcsCredentialsAcsEntrancesVisionlineMetadataProfiles
    {
        [JsonConstructorAttribute]
        protected PhoneSessionProviderSessionsAcsCredentialsAcsEntrancesVisionlineMetadataProfiles()
        { }

        public PhoneSessionProviderSessionsAcsCredentialsAcsEntrancesVisionlineMetadataProfiles(
            string visionlineDoorProfileId = default,
            PhoneSessionProviderSessionsAcsCredentialsAcsEntrancesVisionlineMetadataProfiles.VisionlineDoorProfileTypeEnum visionlineDoorProfileType =
                default
        )
        {
            VisionlineDoorProfileId = visionlineDoorProfileId;
            VisionlineDoorProfileType = visionlineDoorProfileType;
        }

        [JsonConverter(typeof(SafeStringEnumConverter))]
        public enum VisionlineDoorProfileTypeEnum
        {
            [EnumMember(Value = "unrecognized")]
            Unrecognized = 0,

            [EnumMember(Value = "BLE")]
            Ble = 1,

            [EnumMember(Value = "commonDoor")]
            CommonDoor = 2,

            [EnumMember(Value = "touch")]
            Touch = 3
        }

        [DataMember(
            Name = "visionline_door_profile_id",
            IsRequired = true,
            EmitDefaultValue = false
        )]
        public string VisionlineDoorProfileId { get; set; }

        [DataMember(
            Name = "visionline_door_profile_type",
            IsRequired = true,
            EmitDefaultValue = false
        )]
        public PhoneSessionProviderSessionsAcsCredentialsAcsEntrancesVisionlineMetadataProfiles.VisionlineDoorProfileTypeEnum VisionlineDoorProfileType { get; set; }

        public override string ToString()
        {
            JsonSerializer jsonSerializer = JsonSerializer.CreateDefault(null);

            StringWriter stringWriter = new StringWriter(
                new StringBuilder(256),
                System.Globalization.CultureInfo.InvariantCulture
            );
            using (JsonTextWriter jsonTextWriter = new JsonTextWriter(stringWriter))
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
        Name = "seamModel_phoneSessionProviderSessionsAcsCredentialsAssaAbloyVostioMetadata_model"
    )]
    public class PhoneSessionProviderSessionsAcsCredentialsAssaAbloyVostioMetadata
    {
        [JsonConstructorAttribute]
        protected PhoneSessionProviderSessionsAcsCredentialsAssaAbloyVostioMetadata() { }

        public PhoneSessionProviderSessionsAcsCredentialsAssaAbloyVostioMetadata(
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

        [DataMember(Name = "auto_join", IsRequired = false, EmitDefaultValue = false)]
        public bool? AutoJoin { get; set; }

        [DataMember(Name = "door_names", IsRequired = false, EmitDefaultValue = false)]
        public List<string>? DoorNames { get; set; }

        [DataMember(Name = "endpoint_id", IsRequired = false, EmitDefaultValue = false)]
        public string? EndpointId { get; set; }

        [DataMember(Name = "key_id", IsRequired = false, EmitDefaultValue = false)]
        public string? KeyId { get; set; }

        [DataMember(Name = "key_issuing_request_id", IsRequired = false, EmitDefaultValue = false)]
        public string? KeyIssuingRequestId { get; set; }

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

    [DataContract(Name = "seamModel_phoneSessionProviderSessionsAcsCredentialsErrors_model")]
    public class PhoneSessionProviderSessionsAcsCredentialsErrors
    {
        [JsonConstructorAttribute]
        protected PhoneSessionProviderSessionsAcsCredentialsErrors() { }

        public PhoneSessionProviderSessionsAcsCredentialsErrors(
            string errorCode = default,
            string message = default
        )
        {
            ErrorCode = errorCode;
            Message = message;
        }

        [DataMember(Name = "error_code", IsRequired = true, EmitDefaultValue = false)]
        public string ErrorCode { get; set; }

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
        Name = "seamModel_phoneSessionProviderSessionsAcsCredentialsVisionlineMetadata_model"
    )]
    public class PhoneSessionProviderSessionsAcsCredentialsVisionlineMetadata
    {
        [JsonConstructorAttribute]
        protected PhoneSessionProviderSessionsAcsCredentialsVisionlineMetadata() { }

        public PhoneSessionProviderSessionsAcsCredentialsVisionlineMetadata(
            bool? autoJoin = default,
            PhoneSessionProviderSessionsAcsCredentialsVisionlineMetadata.CardFunctionTypeEnum cardFunctionType =
                default,
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

        [JsonConverter(typeof(SafeStringEnumConverter))]
        public enum CardFunctionTypeEnum
        {
            [EnumMember(Value = "unrecognized")]
            Unrecognized = 0,

            [EnumMember(Value = "guest")]
            Guest = 1,

            [EnumMember(Value = "staff")]
            Staff = 2
        }

        [DataMember(Name = "auto_join", IsRequired = false, EmitDefaultValue = false)]
        public bool? AutoJoin { get; set; }

        [DataMember(Name = "card_function_type", IsRequired = true, EmitDefaultValue = false)]
        public PhoneSessionProviderSessionsAcsCredentialsVisionlineMetadata.CardFunctionTypeEnum CardFunctionType { get; set; }

        [DataMember(Name = "card_id", IsRequired = false, EmitDefaultValue = false)]
        public string? CardId { get; set; }

        [DataMember(Name = "common_acs_entrance_ids", IsRequired = false, EmitDefaultValue = false)]
        public List<string>? CommonAcsEntranceIds { get; set; }

        [DataMember(Name = "credential_id", IsRequired = false, EmitDefaultValue = false)]
        public string? CredentialId { get; set; }

        [DataMember(Name = "guest_acs_entrance_ids", IsRequired = false, EmitDefaultValue = false)]
        public List<string>? GuestAcsEntranceIds { get; set; }

        [DataMember(Name = "is_valid", IsRequired = false, EmitDefaultValue = false)]
        public bool? IsValid { get; set; }

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

    [DataContract(Name = "seamModel_phoneSessionProviderSessionsPhoneRegistration_model")]
    public class PhoneSessionProviderSessionsPhoneRegistration
    {
        [JsonConstructorAttribute]
        protected PhoneSessionProviderSessionsPhoneRegistration() { }

        public PhoneSessionProviderSessionsPhoneRegistration(
            bool isBeingActivated = default,
            string phoneRegistrationId = default,
            string? providerName = default,
            Object providerState = default
        )
        {
            IsBeingActivated = isBeingActivated;
            PhoneRegistrationId = phoneRegistrationId;
            ProviderName = providerName;
            ProviderState = providerState;
        }

        [DataMember(Name = "is_being_activated", IsRequired = true, EmitDefaultValue = false)]
        public bool IsBeingActivated { get; set; }

        [DataMember(Name = "phone_registration_id", IsRequired = true, EmitDefaultValue = false)]
        public string PhoneRegistrationId { get; set; }

        [DataMember(Name = "provider_name", IsRequired = false, EmitDefaultValue = false)]
        public string? ProviderName { get; set; }

        [DataMember(Name = "provider_state", IsRequired = false, EmitDefaultValue = false)]
        public Object ProviderState { get; set; }

        public override string ToString()
        {
            JsonSerializer jsonSerializer = JsonSerializer.CreateDefault(null);

            StringWriter stringWriter = new StringWriter(
                new StringBuilder(256),
                System.Globalization.CultureInfo.InvariantCulture
            );
            using (JsonTextWriter jsonTextWriter = new JsonTextWriter(stringWriter))
            {
                jsonTextWriter.IndentChar = ' ';
                jsonTextWriter.Indentation = 2;
                jsonTextWriter.Formatting = Formatting.Indented;
                jsonSerializer.Serialize(jsonTextWriter, this, null);
            }

            return stringWriter.ToString();
        }
    }

    [DataContract(Name = "seamModel_phoneSessionUserIdentity_model")]
    public class PhoneSessionUserIdentity
    {
        [JsonConstructorAttribute]
        protected PhoneSessionUserIdentity() { }

        public PhoneSessionUserIdentity(
            List<string> acsUserIds = default,
            string createdAt = default,
            string displayName = default,
            string? emailAddress = default,
            List<PhoneSessionUserIdentityErrors> errors = default,
            string? fullName = default,
            string? phoneNumber = default,
            string userIdentityId = default,
            string? userIdentityKey = default,
            List<PhoneSessionUserIdentityWarnings> warnings = default,
            string workspaceId = default
        )
        {
            AcsUserIds = acsUserIds;
            CreatedAt = createdAt;
            DisplayName = displayName;
            EmailAddress = emailAddress;
            Errors = errors;
            FullName = fullName;
            PhoneNumber = phoneNumber;
            UserIdentityId = userIdentityId;
            UserIdentityKey = userIdentityKey;
            Warnings = warnings;
            WorkspaceId = workspaceId;
        }

        [JsonConverter(typeof(JsonSubtypes), "error_code")]
        [JsonSubtypes.FallBackSubType(typeof(PhoneSessionUserIdentityErrorsUnknown))]
        [JsonSubtypes.KnownSubType(
            typeof(PhoneSessionUserIdentityErrorsIssueWithAcsUser),
            "issue_with_acs_user"
        )]
        public abstract class PhoneSessionUserIdentityErrors
        {
            public abstract string ErrorCode { get; }

            public abstract string Message { get; set; }

            public abstract override string ToString();
        }

        [DataContract(Name = "seamModel_phoneSessionUserIdentityErrorsIssueWithAcsUser_model")]
        public class PhoneSessionUserIdentityErrorsIssueWithAcsUser : PhoneSessionUserIdentityErrors
        {
            [JsonConstructorAttribute]
            protected PhoneSessionUserIdentityErrorsIssueWithAcsUser() { }

            public PhoneSessionUserIdentityErrorsIssueWithAcsUser(
                string acsSystemId = default,
                string acsUserId = default,
                string createdAt = default,
                string errorCode = default,
                string message = default
            )
            {
                AcsSystemId = acsSystemId;
                AcsUserId = acsUserId;
                CreatedAt = createdAt;
                ErrorCode = errorCode;
                Message = message;
            }

            [DataMember(Name = "acs_system_id", IsRequired = true, EmitDefaultValue = false)]
            public string AcsSystemId { get; set; }

            [DataMember(Name = "acs_user_id", IsRequired = true, EmitDefaultValue = false)]
            public string AcsUserId { get; set; }

            [DataMember(Name = "created_at", IsRequired = true, EmitDefaultValue = false)]
            public string CreatedAt { get; set; }

            [DataMember(Name = "error_code", IsRequired = true, EmitDefaultValue = false)]
            public override string ErrorCode { get; } = "issue_with_acs_user";

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

        [DataContract(Name = "seamModel_phoneSessionUserIdentityErrorsUnknown_model")]
        public class PhoneSessionUserIdentityErrorsUnknown : PhoneSessionUserIdentityErrors
        {
            [JsonConstructorAttribute]
            protected PhoneSessionUserIdentityErrorsUnknown() { }

            public PhoneSessionUserIdentityErrorsUnknown(
                string errorCode = default,
                string message = default
            )
            {
                ErrorCode = errorCode;
                Message = message;
            }

            [DataMember(Name = "error_code", IsRequired = true, EmitDefaultValue = false)]
            public override string ErrorCode { get; } = "unknown";

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

        [JsonConverter(typeof(JsonSubtypes), "warning_code")]
        [JsonSubtypes.FallBackSubType(typeof(PhoneSessionUserIdentityWarningsUnknown))]
        [JsonSubtypes.KnownSubType(
            typeof(PhoneSessionUserIdentityWarningsAcsUserProfileDoesNotMatchUserIdentity),
            "acs_user_profile_does_not_match_user_identity"
        )]
        [JsonSubtypes.KnownSubType(
            typeof(PhoneSessionUserIdentityWarningsBeingDeleted),
            "being_deleted"
        )]
        public abstract class PhoneSessionUserIdentityWarnings
        {
            public abstract string WarningCode { get; }

            public abstract string Message { get; set; }

            public abstract override string ToString();
        }

        [DataContract(Name = "seamModel_phoneSessionUserIdentityWarningsBeingDeleted_model")]
        public class PhoneSessionUserIdentityWarningsBeingDeleted : PhoneSessionUserIdentityWarnings
        {
            [JsonConstructorAttribute]
            protected PhoneSessionUserIdentityWarningsBeingDeleted() { }

            public PhoneSessionUserIdentityWarningsBeingDeleted(
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
            Name = "seamModel_phoneSessionUserIdentityWarningsAcsUserProfileDoesNotMatchUserIdentity_model"
        )]
        public class PhoneSessionUserIdentityWarningsAcsUserProfileDoesNotMatchUserIdentity
            : PhoneSessionUserIdentityWarnings
        {
            [JsonConstructorAttribute]
            protected PhoneSessionUserIdentityWarningsAcsUserProfileDoesNotMatchUserIdentity() { }

            public PhoneSessionUserIdentityWarningsAcsUserProfileDoesNotMatchUserIdentity(
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
            public override string WarningCode { get; } =
                "acs_user_profile_does_not_match_user_identity";

            public override string ToString()
            {
                JsonSerializer jsonSerializer = JsonSerializer.CreateDefault(null);

                StringWriter stringWriter = new StringWriter(
                    new StringBuilder(256),
                    System.Globalization.CultureInfo.InvariantCulture
                );
                using (JsonTextWriter jsonTextWriter = new JsonTextWriter(stringWriter))
                {
                    jsonTextWriter.IndentChar = ' ';
                    jsonTextWriter.Indentation = 2;
                    jsonTextWriter.Formatting = Formatting.Indented;
                    jsonSerializer.Serialize(jsonTextWriter, this, null);
                }

                return stringWriter.ToString();
            }
        }

        [DataContract(Name = "seamModel_phoneSessionUserIdentityWarningsUnknown_model")]
        public class PhoneSessionUserIdentityWarningsUnknown : PhoneSessionUserIdentityWarnings
        {
            [JsonConstructorAttribute]
            protected PhoneSessionUserIdentityWarningsUnknown() { }

            public PhoneSessionUserIdentityWarningsUnknown(
                string warningCode = default,
                string message = default
            )
            {
                WarningCode = warningCode;
                Message = message;
            }

            [DataMember(Name = "warning_code", IsRequired = true, EmitDefaultValue = false)]
            public override string WarningCode { get; } = "unknown";

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

        [DataMember(Name = "acs_user_ids", IsRequired = true, EmitDefaultValue = false)]
        public List<string> AcsUserIds { get; set; }

        [DataMember(Name = "created_at", IsRequired = true, EmitDefaultValue = false)]
        public string CreatedAt { get; set; }

        [DataMember(Name = "display_name", IsRequired = true, EmitDefaultValue = false)]
        public string DisplayName { get; set; }

        [DataMember(Name = "email_address", IsRequired = false, EmitDefaultValue = false)]
        public string? EmailAddress { get; set; }

        [DataMember(Name = "errors", IsRequired = true, EmitDefaultValue = false)]
        public List<PhoneSessionUserIdentityErrors> Errors { get; set; }

        [DataMember(Name = "full_name", IsRequired = false, EmitDefaultValue = false)]
        public string? FullName { get; set; }

        [DataMember(Name = "phone_number", IsRequired = false, EmitDefaultValue = false)]
        public string? PhoneNumber { get; set; }

        [DataMember(Name = "user_identity_id", IsRequired = true, EmitDefaultValue = false)]
        public string UserIdentityId { get; set; }

        [DataMember(Name = "user_identity_key", IsRequired = false, EmitDefaultValue = false)]
        public string? UserIdentityKey { get; set; }

        [DataMember(Name = "warnings", IsRequired = true, EmitDefaultValue = false)]
        public List<PhoneSessionUserIdentityWarnings> Warnings { get; set; }

        [DataMember(Name = "workspace_id", IsRequired = true, EmitDefaultValue = false)]
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
}
