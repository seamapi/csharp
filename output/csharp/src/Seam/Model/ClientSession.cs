using System.Runtime.Serialization;
using System.Text;
using JsonSubTypes;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using Seam.Model;

namespace Seam.Model
{
    [DataContract(Name = "seamModel_clientSession_model")]
    public class ClientSession
    {
        [JsonConstructorAttribute]
        protected ClientSession() { }

        public ClientSession(
            string clientSessionId = default,
            List<string> connectWebviewIds = default,
            List<string> connectedAccountIds = default,
            string createdAt = default,
            string? customerKey = default,
            float deviceCount = default,
            string expiresAt = default,
            string token = default,
            string? userIdentifierKey = default,
            string? userIdentityId = default,
            List<string> userIdentityIds = default,
            string workspaceId = default
        )
        {
            ClientSessionId = clientSessionId;
            ConnectWebviewIds = connectWebviewIds;
            ConnectedAccountIds = connectedAccountIds;
            CreatedAt = createdAt;
            CustomerKey = customerKey;
            DeviceCount = deviceCount;
            ExpiresAt = expiresAt;
            Token = token;
            UserIdentifierKey = userIdentifierKey;
            UserIdentityId = userIdentityId;
            UserIdentityIds = userIdentityIds;
            WorkspaceId = workspaceId;
        }

        [DataMember(Name = "client_session_id", IsRequired = true, EmitDefaultValue = false)]
        public string ClientSessionId { get; set; }

        [DataMember(Name = "connect_webview_ids", IsRequired = true, EmitDefaultValue = false)]
        public List<string> ConnectWebviewIds { get; set; }

        [DataMember(Name = "connected_account_ids", IsRequired = true, EmitDefaultValue = false)]
        public List<string> ConnectedAccountIds { get; set; }

        [DataMember(Name = "created_at", IsRequired = true, EmitDefaultValue = false)]
        public string CreatedAt { get; set; }

        [DataMember(Name = "customer_key", IsRequired = false, EmitDefaultValue = false)]
        public string? CustomerKey { get; set; }

        [DataMember(Name = "device_count", IsRequired = true, EmitDefaultValue = false)]
        public float DeviceCount { get; set; }

        [DataMember(Name = "expires_at", IsRequired = true, EmitDefaultValue = false)]
        public string ExpiresAt { get; set; }

        [DataMember(Name = "token", IsRequired = true, EmitDefaultValue = false)]
        public string Token { get; set; }

        [DataMember(Name = "user_identifier_key", IsRequired = false, EmitDefaultValue = false)]
        public string? UserIdentifierKey { get; set; }

        [DataMember(Name = "user_identity_id", IsRequired = false, EmitDefaultValue = false)]
        public string? UserIdentityId { get; set; }

        [DataMember(Name = "user_identity_ids", IsRequired = true, EmitDefaultValue = false)]
        public List<string> UserIdentityIds { get; set; }

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
