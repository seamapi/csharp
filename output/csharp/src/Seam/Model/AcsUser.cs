using System.Runtime.Serialization;
using System.Text;
using JsonSubTypes;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;

namespace Seam.Model
{
    [DataContract(Name = "seamModel_acsUser_model")]
    public class AcsUser
    {
        [JsonConstructorAttribute]
        protected AcsUser() { }

        public AcsUser(
            AcsUserAccessSchedule? accessSchedule = default,
            string acsSystemId = default,
            string acsUserId = default,
            string createdAt = default,
            string displayName = default,
            string? email = default,
            string? emailAddress = default,
            List<JObject> errors = default,
            AcsUser.ExternalTypeEnum? externalType = default,
            string? externalTypeDisplayName = default,
            string? fullName = default,
            string? hidAcsSystemId = default,
            bool? isLatestDesiredStateSyncedWithProvider = default,
            bool isManaged = default,
            bool? isSuspended = default,
            string? latestDesiredStateSyncedWithProviderAt = default,
            string? phoneNumber = default,
            string? userIdentityEmailAddress = default,
            string? userIdentityFullName = default,
            string? userIdentityId = default,
            string? userIdentityPhoneNumber = default,
            List<JObject> warnings = default,
            string workspaceId = default
        )
        {
            AccessSchedule = accessSchedule;
            AcsSystemId = acsSystemId;
            AcsUserId = acsUserId;
            CreatedAt = createdAt;
            DisplayName = displayName;
            Email = email;
            EmailAddress = emailAddress;
            Errors = errors;
            ExternalType = externalType;
            ExternalTypeDisplayName = externalTypeDisplayName;
            FullName = fullName;
            HidAcsSystemId = hidAcsSystemId;
            IsLatestDesiredStateSyncedWithProvider = isLatestDesiredStateSyncedWithProvider;
            IsManaged = isManaged;
            IsSuspended = isSuspended;
            LatestDesiredStateSyncedWithProviderAt = latestDesiredStateSyncedWithProviderAt;
            PhoneNumber = phoneNumber;
            UserIdentityEmailAddress = userIdentityEmailAddress;
            UserIdentityFullName = userIdentityFullName;
            UserIdentityId = userIdentityId;
            UserIdentityPhoneNumber = userIdentityPhoneNumber;
            Warnings = warnings;
            WorkspaceId = workspaceId;
        }

        [JsonConverter(typeof(StringEnumConverter))]
        public enum ExternalTypeEnum
        {
            [EnumMember(Value = "pti_user")]
            PtiUser = 0,

            [EnumMember(Value = "brivo_user")]
            BrivoUser = 1,

            [EnumMember(Value = "hid_credential_manager_user")]
            HidCredentialManagerUser = 2,

            [EnumMember(Value = "salto_site_user")]
            SaltoSiteUser = 3,

            [EnumMember(Value = "latch_user")]
            LatchUser = 4,

            [EnumMember(Value = "dormakaba_community_user")]
            DormakabaCommunityUser = 5,
        }

        [DataMember(Name = "access_schedule", IsRequired = false, EmitDefaultValue = false)]
        public AcsUserAccessSchedule? AccessSchedule { get; set; }

        [DataMember(Name = "acs_system_id", IsRequired = true, EmitDefaultValue = false)]
        public string AcsSystemId { get; set; }

        [DataMember(Name = "acs_user_id", IsRequired = true, EmitDefaultValue = false)]
        public string AcsUserId { get; set; }

        [DataMember(Name = "created_at", IsRequired = true, EmitDefaultValue = false)]
        public string CreatedAt { get; set; }

        [DataMember(Name = "display_name", IsRequired = true, EmitDefaultValue = false)]
        public string DisplayName { get; set; }

        [DataMember(Name = "email", IsRequired = false, EmitDefaultValue = false)]
        public string? Email { get; set; }

        [DataMember(Name = "email_address", IsRequired = false, EmitDefaultValue = false)]
        public string? EmailAddress { get; set; }

        [DataMember(Name = "errors", IsRequired = true, EmitDefaultValue = false)]
        public List<JObject> Errors { get; set; }

        [DataMember(Name = "external_type", IsRequired = false, EmitDefaultValue = false)]
        public AcsUser.ExternalTypeEnum? ExternalType { get; set; }

        [DataMember(
            Name = "external_type_display_name",
            IsRequired = false,
            EmitDefaultValue = false
        )]
        public string? ExternalTypeDisplayName { get; set; }

        [DataMember(Name = "full_name", IsRequired = false, EmitDefaultValue = false)]
        public string? FullName { get; set; }

        [DataMember(Name = "hid_acs_system_id", IsRequired = false, EmitDefaultValue = false)]
        public string? HidAcsSystemId { get; set; }

        [DataMember(
            Name = "is_latest_desired_state_synced_with_provider",
            IsRequired = false,
            EmitDefaultValue = false
        )]
        public bool? IsLatestDesiredStateSyncedWithProvider { get; set; }

        [DataMember(Name = "is_managed", IsRequired = true, EmitDefaultValue = false)]
        public bool IsManaged { get; set; }

        [DataMember(Name = "is_suspended", IsRequired = false, EmitDefaultValue = false)]
        public bool? IsSuspended { get; set; }

        [DataMember(
            Name = "latest_desired_state_synced_with_provider_at",
            IsRequired = false,
            EmitDefaultValue = false
        )]
        public string? LatestDesiredStateSyncedWithProviderAt { get; set; }

        [DataMember(Name = "phone_number", IsRequired = false, EmitDefaultValue = false)]
        public string? PhoneNumber { get; set; }

        [DataMember(
            Name = "user_identity_email_address",
            IsRequired = false,
            EmitDefaultValue = false
        )]
        public string? UserIdentityEmailAddress { get; set; }

        [DataMember(Name = "user_identity_full_name", IsRequired = false, EmitDefaultValue = false)]
        public string? UserIdentityFullName { get; set; }

        [DataMember(Name = "user_identity_id", IsRequired = false, EmitDefaultValue = false)]
        public string? UserIdentityId { get; set; }

        [DataMember(
            Name = "user_identity_phone_number",
            IsRequired = false,
            EmitDefaultValue = false
        )]
        public string? UserIdentityPhoneNumber { get; set; }

        [DataMember(Name = "warnings", IsRequired = true, EmitDefaultValue = false)]
        public List<JObject> Warnings { get; set; }

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

    [DataContract(Name = "seamModel_acsUserAccessSchedule_model")]
    public class AcsUserAccessSchedule
    {
        [JsonConstructorAttribute]
        protected AcsUserAccessSchedule() { }

        public AcsUserAccessSchedule(string? endsAt = default, string startsAt = default)
        {
            EndsAt = endsAt;
            StartsAt = startsAt;
        }

        [DataMember(Name = "ends_at", IsRequired = false, EmitDefaultValue = false)]
        public string? EndsAt { get; set; }

        [DataMember(Name = "starts_at", IsRequired = true, EmitDefaultValue = false)]
        public string StartsAt { get; set; }

        public override string ToString()
        {
            JsonSerializer jsonSerializer = JsonSerializer.CreateDefault(null);

            StringWriter stringWriter = new StringWriter(
                new StringBuilder(256),
                System.Globalization.CultureInfo.InvariantCulture
            );
            using (JsonTextWriter jsonTextWriter = new JsonTextWriter(stringWriter))
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
