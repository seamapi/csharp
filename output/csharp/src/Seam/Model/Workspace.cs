using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using JsonSubTypes;

namespace Seam.Model
{
    [DataContract(Name = "seamModel_workspace_model")]
    public class Workspace
    {
        [JsonConstructorAttribute]
        protected Workspace() { }

        public Workspace(
            string workspaceId = default,
            string name = default,
            bool isSandbox = default,
            string? connectPartnerName = default
        )
        {
            WorkspaceId = workspaceId;
            Name = name;
            IsSandbox = isSandbox;
            ConnectPartnerName = connectPartnerName;
        }

        [DataMember(Name = "workspace_id", IsRequired = true, EmitDefaultValue = false)]
        public string WorkspaceId { get; set; }

        [DataMember(Name = "name", IsRequired = true, EmitDefaultValue = false)]
        public string Name { get; set; }

        [DataMember(Name = "is_sandbox", IsRequired = true, EmitDefaultValue = false)]
        public bool IsSandbox { get; set; }

        [DataMember(Name = "connect_partner_name", IsRequired = false, EmitDefaultValue = false)]
        public string? ConnectPartnerName { get; set; }
    }
}
