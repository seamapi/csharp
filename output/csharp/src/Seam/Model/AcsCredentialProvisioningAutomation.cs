using System.Runtime.Serialization;
using System.Text;
using JsonSubTypes;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using Seam.Model;

namespace Seam.Model
{
    [DataContract(Name = "seamModel_acsCredentialProvisioningAutomation_model")]
    public class AcsCredentialProvisioningAutomation
    {
        [JsonConstructorAttribute]
        protected AcsCredentialProvisioningAutomation() { }

        public AcsCredentialProvisioningAutomation(
            string acsCredentialProvisioningAutomationId = default,
            string createdAt = default,
            string credentialManagerAcsSystemId = default,
            string userIdentityId = default,
            string workspaceId = default
        )
        {
            AcsCredentialProvisioningAutomationId = acsCredentialProvisioningAutomationId;
            CreatedAt = createdAt;
            CredentialManagerAcsSystemId = credentialManagerAcsSystemId;
            UserIdentityId = userIdentityId;
            WorkspaceId = workspaceId;
        }

        [DataMember(
            Name = "acs_credential_provisioning_automation_id",
            IsRequired = true,
            EmitDefaultValue = false
        )]
        public string AcsCredentialProvisioningAutomationId { get; set; }

        [DataMember(Name = "created_at", IsRequired = true, EmitDefaultValue = false)]
        public string CreatedAt { get; set; }

        [DataMember(
            Name = "credential_manager_acs_system_id",
            IsRequired = true,
            EmitDefaultValue = false
        )]
        public string CredentialManagerAcsSystemId { get; set; }

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
