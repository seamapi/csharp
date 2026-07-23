using System.Runtime.Serialization;
using System.Text;
using JsonSubTypes;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using Seam.Model;

namespace Seam.Model
{
    [DataContract(Name = "seamModel_enrollmentAutomation_model")]
    public class EnrollmentAutomation
    {
        [JsonConstructorAttribute]
        protected EnrollmentAutomation() { }

        public EnrollmentAutomation(
            string createdAt = default,
            string credentialManagerAcsSystemId = default,
            string enrollmentAutomationId = default,
            string userIdentityId = default,
            string workspaceId = default
        )
        {
            CreatedAt = createdAt;
            CredentialManagerAcsSystemId = credentialManagerAcsSystemId;
            EnrollmentAutomationId = enrollmentAutomationId;
            UserIdentityId = userIdentityId;
            WorkspaceId = workspaceId;
        }

        [DataMember(Name = "created_at", IsRequired = true, EmitDefaultValue = false)]
        public string CreatedAt { get; set; }

        [DataMember(
            Name = "credential_manager_acs_system_id",
            IsRequired = true,
            EmitDefaultValue = false
        )]
        public string CredentialManagerAcsSystemId { get; set; }

        [DataMember(Name = "enrollment_automation_id", IsRequired = true, EmitDefaultValue = false)]
        public string EnrollmentAutomationId { get; set; }

        [DataMember(Name = "user_identity_id", IsRequired = true, EmitDefaultValue = false)]
        public string UserIdentityId { get; set; }

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
