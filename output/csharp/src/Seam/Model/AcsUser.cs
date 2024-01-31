using System.Runtime.Serialization;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using JsonSubTypes;

namespace Seam.Model
{
    [DataContract(Name = "seamModel_acsUser_model")]
    public class AcsUser
    {
        [JsonConstructorAttribute]
        protected AcsUser() { }

        public AcsUser(
            string acsUserId = default,
            string acsSystemId = default,
            string? hidAcsSystemId = default,
            string workspaceId = default,
            string createdAt = default,
            string displayName = default,
            AcsUser.ExternalTypeEnum? externalType = default,
            string? externalTypeDisplayName = default,
            bool isSuspended = default,
            AcsUserAccessSchedule? accessSchedule = default,
            string? userIdentityId = default,
            string? userIdentityEmailAddress = default,
            string? userIdentityPhoneNumber = default,
            string? fullName = default,
            string? email = default,
            string? emailAddress = default,
            string? phoneNumber = default
        )
        {
            AcsUserId = acsUserId;
            AcsSystemId = acsSystemId;
            HidAcsSystemId = hidAcsSystemId;
            WorkspaceId = workspaceId;
            CreatedAt = createdAt;
            DisplayName = displayName;
            ExternalType = externalType;
            ExternalTypeDisplayName = externalTypeDisplayName;
            IsSuspended = isSuspended;
            AccessSchedule = accessSchedule;
            UserIdentityId = userIdentityId;
            UserIdentityEmailAddress = userIdentityEmailAddress;
            UserIdentityPhoneNumber = userIdentityPhoneNumber;
            FullName = fullName;
            Email = email;
            EmailAddress = emailAddress;
            PhoneNumber = phoneNumber;
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
            SaltoSiteUser = 3
        }

        [DataMember(Name = "acs_user_id", IsRequired = true, EmitDefaultValue = false)]
        public string AcsUserId { get; set; }

        [DataMember(Name = "acs_system_id", IsRequired = true, EmitDefaultValue = false)]
        public string AcsSystemId { get; set; }

        [DataMember(Name = "hid_acs_system_id", IsRequired = false, EmitDefaultValue = false)]
        public string? HidAcsSystemId { get; set; }

        [DataMember(Name = "workspace_id", IsRequired = true, EmitDefaultValue = false)]
        public string WorkspaceId { get; set; }

        [DataMember(Name = "created_at", IsRequired = true, EmitDefaultValue = false)]
        public string CreatedAt { get; set; }

        [DataMember(Name = "display_name", IsRequired = true, EmitDefaultValue = false)]
        public string DisplayName { get; set; }

        [DataMember(Name = "external_type", IsRequired = false, EmitDefaultValue = false)]
        public AcsUser.ExternalTypeEnum? ExternalType { get; set; }

        [DataMember(
            Name = "external_type_display_name",
            IsRequired = false,
            EmitDefaultValue = false
        )]
        public string? ExternalTypeDisplayName { get; set; }

        [DataMember(Name = "is_suspended", IsRequired = true, EmitDefaultValue = false)]
        public bool IsSuspended { get; set; }

        [DataMember(Name = "access_schedule", IsRequired = false, EmitDefaultValue = false)]
        public AcsUserAccessSchedule? AccessSchedule { get; set; }

        [DataMember(Name = "user_identity_id", IsRequired = false, EmitDefaultValue = false)]
        public string? UserIdentityId { get; set; }

        [DataMember(
            Name = "user_identity_email_address",
            IsRequired = false,
            EmitDefaultValue = false
        )]
        public string? UserIdentityEmailAddress { get; set; }

        [DataMember(
            Name = "user_identity_phone_number",
            IsRequired = false,
            EmitDefaultValue = false
        )]
        public string? UserIdentityPhoneNumber { get; set; }

        [DataMember(Name = "full_name", IsRequired = false, EmitDefaultValue = false)]
        public string? FullName { get; set; }

        [DataMember(Name = "email", IsRequired = false, EmitDefaultValue = false)]
        public string? Email { get; set; }

        [DataMember(Name = "email_address", IsRequired = false, EmitDefaultValue = false)]
        public string? EmailAddress { get; set; }

        [DataMember(Name = "phone_number", IsRequired = false, EmitDefaultValue = false)]
        public string? PhoneNumber { get; set; }

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

        public AcsUserAccessSchedule(string startsAt = default, string endsAt = default)
        {
            StartsAt = startsAt;
            EndsAt = endsAt;
        }

        [DataMember(Name = "starts_at", IsRequired = true, EmitDefaultValue = false)]
        public string StartsAt { get; set; }

        [DataMember(Name = "ends_at", IsRequired = true, EmitDefaultValue = false)]
        public string EndsAt { get; set; }

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
