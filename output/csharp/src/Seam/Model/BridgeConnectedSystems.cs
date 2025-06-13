using System.Runtime.Serialization;
using System.Text;
using JsonSubTypes;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using Seam.Model;

namespace Seam.Model
{
    [DataContract(Name = "seamModel_bridgeConnectedSystems_model")]
    public class BridgeConnectedSystems
    {
        [JsonConstructorAttribute]
        protected BridgeConnectedSystems() { }

        public BridgeConnectedSystems(
            string acsSystemDisplayName = default,
            string acsSystemId = default,
            string bridgeCreatedAt = default,
            string bridgeId = default,
            string connectedAccountCreatedAt = default,
            string connectedAccountId = default,
            string workspaceDisplayName = default,
            string workspaceId = default
        )
        {
            AcsSystemDisplayName = acsSystemDisplayName;
            AcsSystemId = acsSystemId;
            BridgeCreatedAt = bridgeCreatedAt;
            BridgeId = bridgeId;
            ConnectedAccountCreatedAt = connectedAccountCreatedAt;
            ConnectedAccountId = connectedAccountId;
            WorkspaceDisplayName = workspaceDisplayName;
            WorkspaceId = workspaceId;
        }

        [DataMember(Name = "acs_system_display_name", IsRequired = true, EmitDefaultValue = false)]
        public string AcsSystemDisplayName { get; set; }

        [DataMember(Name = "acs_system_id", IsRequired = true, EmitDefaultValue = false)]
        public string AcsSystemId { get; set; }

        [DataMember(Name = "bridge_created_at", IsRequired = true, EmitDefaultValue = false)]
        public string BridgeCreatedAt { get; set; }

        [DataMember(Name = "bridge_id", IsRequired = true, EmitDefaultValue = false)]
        public string BridgeId { get; set; }

        [DataMember(
            Name = "connected_account_created_at",
            IsRequired = true,
            EmitDefaultValue = false
        )]
        public string ConnectedAccountCreatedAt { get; set; }

        [DataMember(Name = "connected_account_id", IsRequired = true, EmitDefaultValue = false)]
        public string ConnectedAccountId { get; set; }

        [DataMember(Name = "workspace_display_name", IsRequired = true, EmitDefaultValue = false)]
        public string WorkspaceDisplayName { get; set; }

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
