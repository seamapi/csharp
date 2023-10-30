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
            string workspaceId = default,
            string createdAt = default,
            string displayName = default,
            AcsUser.ExternalTypeEnum externalType = default,
            string externalTypeDisplayName = default,
            bool isSuspended = default,
            string? fullName = default,
            string? email = default,
            string? phoneNumber = default
        )
        {
            AcsUserId = acsUserId;
            AcsSystemId = acsSystemId;
            WorkspaceId = workspaceId;
            CreatedAt = createdAt;
            DisplayName = displayName;
            ExternalType = externalType;
            ExternalTypeDisplayName = externalTypeDisplayName;
            IsSuspended = isSuspended;
            FullName = fullName;
            Email = email;
            PhoneNumber = phoneNumber;
        }

        [JsonConverter(typeof(StringEnumConverter))]
        public enum ExternalTypeEnum
        {
            [EnumMember(Value = "pti_user")]
            PtiUser = 0
        }

        [DataMember(Name = "acs_user_id", IsRequired = true, EmitDefaultValue = false)]
        public string AcsUserId { get; set; }

        [DataMember(Name = "acs_system_id", IsRequired = true, EmitDefaultValue = false)]
        public string AcsSystemId { get; set; }

        [DataMember(Name = "workspace_id", IsRequired = true, EmitDefaultValue = false)]
        public string WorkspaceId { get; set; }

        [DataMember(Name = "created_at", IsRequired = true, EmitDefaultValue = false)]
        public string CreatedAt { get; set; }

        [DataMember(Name = "display_name", IsRequired = true, EmitDefaultValue = false)]
        public string DisplayName { get; set; }

        [DataMember(Name = "external_type", IsRequired = true, EmitDefaultValue = false)]
        public AcsUser.ExternalTypeEnum ExternalType { get; set; }

        [DataMember(
            Name = "external_type_display_name",
            IsRequired = true,
            EmitDefaultValue = false
        )]
        public string ExternalTypeDisplayName { get; set; }

        [DataMember(Name = "is_suspended", IsRequired = true, EmitDefaultValue = false)]
        public bool IsSuspended { get; set; }

        [DataMember(Name = "full_name", IsRequired = false, EmitDefaultValue = false)]
        public string? FullName { get; set; }

        [DataMember(Name = "email", IsRequired = false, EmitDefaultValue = false)]
        public string? Email { get; set; }

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
}
