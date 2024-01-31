using System.Runtime.Serialization;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using JsonSubTypes;

namespace Seam.Model
{
    [DataContract(Name = "seamModel_acsSystem_model")]
    public class AcsSystem
    {
        [JsonConstructorAttribute]
        protected AcsSystem() { }

        public AcsSystem(
            string acsSystemId = default,
            AcsSystem.ExternalTypeEnum externalType = default,
            string externalTypeDisplayName = default,
            AcsSystem.SystemTypeEnum systemType = default,
            string systemTypeDisplayName = default,
            string name = default,
            string createdAt = default,
            string workspaceId = default,
            List<string> connectedAccountIds = default
        )
        {
            AcsSystemId = acsSystemId;
            ExternalType = externalType;
            ExternalTypeDisplayName = externalTypeDisplayName;
            SystemType = systemType;
            SystemTypeDisplayName = systemTypeDisplayName;
            Name = name;
            CreatedAt = createdAt;
            WorkspaceId = workspaceId;
            ConnectedAccountIds = connectedAccountIds;
        }

        [JsonConverter(typeof(StringEnumConverter))]
        public enum ExternalTypeEnum
        {
            [EnumMember(Value = "pti_site")]
            PtiSite = 0,

            [EnumMember(Value = "alta_org")]
            AltaOrg = 1,

            [EnumMember(Value = "salto_site")]
            SaltoSite = 2,

            [EnumMember(Value = "brivo_account")]
            BrivoAccount = 3,

            [EnumMember(Value = "hid_credential_manager_organization")]
            HidCredentialManagerOrganization = 4,

            [EnumMember(Value = "visionline_system")]
            VisionlineSystem = 5,

            [EnumMember(Value = "assa_abloy_credential_service")]
            AssaAbloyCredentialService = 6
        }

        [JsonConverter(typeof(StringEnumConverter))]
        public enum SystemTypeEnum
        {
            [EnumMember(Value = "pti_site")]
            PtiSite = 0,

            [EnumMember(Value = "alta_org")]
            AltaOrg = 1,

            [EnumMember(Value = "salto_site")]
            SaltoSite = 2,

            [EnumMember(Value = "brivo_account")]
            BrivoAccount = 3,

            [EnumMember(Value = "hid_credential_manager_organization")]
            HidCredentialManagerOrganization = 4,

            [EnumMember(Value = "visionline_system")]
            VisionlineSystem = 5,

            [EnumMember(Value = "assa_abloy_credential_service")]
            AssaAbloyCredentialService = 6
        }

        [DataMember(Name = "acs_system_id", IsRequired = true, EmitDefaultValue = false)]
        public string AcsSystemId { get; set; }

        [DataMember(Name = "external_type", IsRequired = true, EmitDefaultValue = false)]
        public AcsSystem.ExternalTypeEnum ExternalType { get; set; }

        [DataMember(
            Name = "external_type_display_name",
            IsRequired = true,
            EmitDefaultValue = false
        )]
        public string ExternalTypeDisplayName { get; set; }

        [DataMember(Name = "system_type", IsRequired = true, EmitDefaultValue = false)]
        public AcsSystem.SystemTypeEnum SystemType { get; set; }

        [DataMember(Name = "system_type_display_name", IsRequired = true, EmitDefaultValue = false)]
        public string SystemTypeDisplayName { get; set; }

        [DataMember(Name = "name", IsRequired = true, EmitDefaultValue = false)]
        public string Name { get; set; }

        [DataMember(Name = "created_at", IsRequired = true, EmitDefaultValue = false)]
        public string CreatedAt { get; set; }

        [DataMember(Name = "workspace_id", IsRequired = true, EmitDefaultValue = false)]
        public string WorkspaceId { get; set; }

        [DataMember(Name = "connected_account_ids", IsRequired = true, EmitDefaultValue = false)]
        public List<string> ConnectedAccountIds { get; set; }

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
