using System.Runtime.Serialization;
using System.Text;
using JsonSubTypes;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using Seam.Model;

namespace Seam.Model
{
    [DataContract(Name = "seamModel_unmanagedAcsCredential_model")]
    public class UnmanagedAcsCredential
    {
        [JsonConstructorAttribute]
        protected UnmanagedAcsCredential() { }

        public UnmanagedAcsCredential(
            UnmanagedAcsCredential.AccessMethodEnum accessMethod = default,
            string acsCredentialId = default,
            string? acsCredentialPoolId = default,
            string acsSystemId = default,
            string? acsUserId = default,
            UnmanagedAcsCredentialAssaAbloyVostioMetadata? assaAbloyVostioMetadata = default,
            string? cardNumber = default,
            string? code = default,
            string connectedAccountId = default,
            string createdAt = default,
            string displayName = default,
            string? endsAt = default,
            List<UnmanagedAcsCredentialErrors> errors = default,
            UnmanagedAcsCredential.ExternalTypeEnum? externalType = default,
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
            UnmanagedAcsCredentialVisionlineMetadata? visionlineMetadata = default,
            List<UnmanagedAcsCredentialWarnings> warnings = default,
            string workspaceId = default
        )
        {
            AccessMethod = accessMethod;
            AcsCredentialId = acsCredentialId;
            AcsCredentialPoolId = acsCredentialPoolId;
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
            MobileKey = 3,
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
        }

        [JsonConverter(typeof(JsonSubtypes), "warning_code")]
        [JsonSubtypes.KnownSubType(
            typeof(UnmanagedAcsCredentialWarningsNeedsToBeReissued),
            "needs_to_be_reissued"
        )]
        [JsonSubtypes.KnownSubType(
            typeof(UnmanagedAcsCredentialWarningsUnknownIssueWithAcsCredential),
            "unknown_issue_with_acs_credential"
        )]
        [JsonSubtypes.KnownSubType(
            typeof(UnmanagedAcsCredentialWarningsBeingDeleted),
            "being_deleted"
        )]
        [JsonSubtypes.KnownSubType(
            typeof(UnmanagedAcsCredentialWarningsScheduleModified),
            "schedule_modified"
        )]
        [JsonSubtypes.KnownSubType(
            typeof(UnmanagedAcsCredentialWarningsScheduleExternallyModified),
            "schedule_externally_modified"
        )]
        [JsonSubtypes.KnownSubType(
            typeof(UnmanagedAcsCredentialWarningsWaitingToBeIssued),
            "waiting_to_be_issued"
        )]
        public abstract class UnmanagedAcsCredentialWarnings
        {
            public abstract string WarningCode { get; }

            public abstract string CreatedAt { get; set; }

            public abstract string Message { get; set; }

            public abstract override string ToString();
        }

        [DataContract(Name = "seamModel_unmanagedAcsCredentialWarningsWaitingToBeIssued_model")]
        public class UnmanagedAcsCredentialWarningsWaitingToBeIssued
            : UnmanagedAcsCredentialWarnings
        {
            [JsonConstructorAttribute]
            protected UnmanagedAcsCredentialWarningsWaitingToBeIssued() { }

            public UnmanagedAcsCredentialWarningsWaitingToBeIssued(
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
            public override string CreatedAt { get; set; }

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
            Name = "seamModel_unmanagedAcsCredentialWarningsScheduleExternallyModified_model"
        )]
        public class UnmanagedAcsCredentialWarningsScheduleExternallyModified
            : UnmanagedAcsCredentialWarnings
        {
            [JsonConstructorAttribute]
            protected UnmanagedAcsCredentialWarningsScheduleExternallyModified() { }

            public UnmanagedAcsCredentialWarningsScheduleExternallyModified(
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
            public override string CreatedAt { get; set; }

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

        [DataContract(Name = "seamModel_unmanagedAcsCredentialWarningsScheduleModified_model")]
        public class UnmanagedAcsCredentialWarningsScheduleModified : UnmanagedAcsCredentialWarnings
        {
            [JsonConstructorAttribute]
            protected UnmanagedAcsCredentialWarningsScheduleModified() { }

            public UnmanagedAcsCredentialWarningsScheduleModified(
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
            public override string CreatedAt { get; set; }

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

        [DataContract(Name = "seamModel_unmanagedAcsCredentialWarningsBeingDeleted_model")]
        public class UnmanagedAcsCredentialWarningsBeingDeleted : UnmanagedAcsCredentialWarnings
        {
            [JsonConstructorAttribute]
            protected UnmanagedAcsCredentialWarningsBeingDeleted() { }

            public UnmanagedAcsCredentialWarningsBeingDeleted(
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
            public override string CreatedAt { get; set; }

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
            Name = "seamModel_unmanagedAcsCredentialWarningsUnknownIssueWithAcsCredential_model"
        )]
        public class UnmanagedAcsCredentialWarningsUnknownIssueWithAcsCredential
            : UnmanagedAcsCredentialWarnings
        {
            [JsonConstructorAttribute]
            protected UnmanagedAcsCredentialWarningsUnknownIssueWithAcsCredential() { }

            public UnmanagedAcsCredentialWarningsUnknownIssueWithAcsCredential(
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
            public override string CreatedAt { get; set; }

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

        [DataContract(Name = "seamModel_unmanagedAcsCredentialWarningsNeedsToBeReissued_model")]
        public class UnmanagedAcsCredentialWarningsNeedsToBeReissued
            : UnmanagedAcsCredentialWarnings
        {
            [JsonConstructorAttribute]
            protected UnmanagedAcsCredentialWarningsNeedsToBeReissued() { }

            public UnmanagedAcsCredentialWarningsNeedsToBeReissued(
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
            public override string CreatedAt { get; set; }

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

        [DataMember(Name = "access_method", IsRequired = true, EmitDefaultValue = false)]
        public UnmanagedAcsCredential.AccessMethodEnum AccessMethod { get; set; }

        [DataMember(Name = "acs_credential_id", IsRequired = true, EmitDefaultValue = false)]
        public string AcsCredentialId { get; set; }

        [DataMember(Name = "acs_credential_pool_id", IsRequired = false, EmitDefaultValue = false)]
        public string? AcsCredentialPoolId { get; set; }

        [DataMember(Name = "acs_system_id", IsRequired = true, EmitDefaultValue = false)]
        public string AcsSystemId { get; set; }

        [DataMember(Name = "acs_user_id", IsRequired = false, EmitDefaultValue = false)]
        public string? AcsUserId { get; set; }

        [DataMember(
            Name = "assa_abloy_vostio_metadata",
            IsRequired = false,
            EmitDefaultValue = false
        )]
        public UnmanagedAcsCredentialAssaAbloyVostioMetadata? AssaAbloyVostioMetadata { get; set; }

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
        public List<UnmanagedAcsCredentialErrors> Errors { get; set; }

        [DataMember(Name = "external_type", IsRequired = false, EmitDefaultValue = false)]
        public UnmanagedAcsCredential.ExternalTypeEnum? ExternalType { get; set; }

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
        public UnmanagedAcsCredentialVisionlineMetadata? VisionlineMetadata { get; set; }

        [DataMember(Name = "warnings", IsRequired = true, EmitDefaultValue = false)]
        public List<UnmanagedAcsCredentialWarnings> Warnings { get; set; }

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

    [DataContract(Name = "seamModel_unmanagedAcsCredentialAssaAbloyVostioMetadata_model")]
    public class UnmanagedAcsCredentialAssaAbloyVostioMetadata
    {
        [JsonConstructorAttribute]
        protected UnmanagedAcsCredentialAssaAbloyVostioMetadata() { }

        public UnmanagedAcsCredentialAssaAbloyVostioMetadata(
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

    [DataContract(Name = "seamModel_unmanagedAcsCredentialErrors_model")]
    public class UnmanagedAcsCredentialErrors
    {
        [JsonConstructorAttribute]
        protected UnmanagedAcsCredentialErrors() { }

        public UnmanagedAcsCredentialErrors(string errorCode = default, string message = default)
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

    [DataContract(Name = "seamModel_unmanagedAcsCredentialVisionlineMetadata_model")]
    public class UnmanagedAcsCredentialVisionlineMetadata
    {
        [JsonConstructorAttribute]
        protected UnmanagedAcsCredentialVisionlineMetadata() { }

        public UnmanagedAcsCredentialVisionlineMetadata(
            bool? autoJoin = default,
            UnmanagedAcsCredentialVisionlineMetadata.CardFunctionTypeEnum cardFunctionType =
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
            Staff = 2,
        }

        [DataMember(Name = "auto_join", IsRequired = false, EmitDefaultValue = false)]
        public bool? AutoJoin { get; set; }

        [DataMember(Name = "card_function_type", IsRequired = true, EmitDefaultValue = false)]
        public UnmanagedAcsCredentialVisionlineMetadata.CardFunctionTypeEnum CardFunctionType { get; set; }

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
}
