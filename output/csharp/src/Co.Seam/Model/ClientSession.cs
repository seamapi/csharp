using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using JsonSubTypes;

namespace Seam.Model
{
    [DataContract(Name = "coSeamModel_clientSession_model")]
    public class ClientSession
    {
        [JsonConstructorAttribute]
        protected ClientSession() { }

        public ClientSession(
            string clientSessionId = default,
            string? userIdentifierKey = default,
            string createdAt = default,
            string token = default,
            float deviceCount = default,
            List<string> connectedAccountIds = default,
            List<string> connectWebviewIds = default,
            string workspaceId = default
        )
        {
            ClientSessionId = clientSessionId;
            UserIdentifierKey = userIdentifierKey;
            CreatedAt = createdAt;
            Token = token;
            DeviceCount = deviceCount;
            ConnectedAccountIds = connectedAccountIds;
            ConnectWebviewIds = connectWebviewIds;
            WorkspaceId = workspaceId;
        }

        [DataMember(Name = "client_session_id", IsRequired = true, EmitDefaultValue = false)]
        public string ClientSessionId { get; set; }

        [DataMember(Name = "user_identifier_key", IsRequired = false, EmitDefaultValue = false)]
        public string? UserIdentifierKey { get; set; }

        [DataMember(Name = "created_at", IsRequired = true, EmitDefaultValue = false)]
        public string CreatedAt { get; set; }

        [DataMember(Name = "token", IsRequired = true, EmitDefaultValue = false)]
        public string Token { get; set; }

        [DataMember(Name = "device_count", IsRequired = true, EmitDefaultValue = false)]
        public float DeviceCount { get; set; }

        [DataMember(Name = "connected_account_ids", IsRequired = true, EmitDefaultValue = false)]
        public List<string> ConnectedAccountIds { get; set; }

        [DataMember(Name = "connect_webview_ids", IsRequired = true, EmitDefaultValue = false)]
        public List<string> ConnectWebviewIds { get; set; }

        [DataMember(Name = "workspace_id", IsRequired = true, EmitDefaultValue = false)]
        public string WorkspaceId { get; set; }
    }
}
