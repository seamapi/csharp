using System.Runtime.Serialization;
using System.Text;
using JsonSubTypes;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using Seam.Model;

namespace Seam.Model
{
    /// <summary>
    /// Represents a [client session](https://docs.seam.co/core-concepts/authentication/client-session-tokens). If you want to restrict your users&apos; access to their own devices, use client sessions.
    ///
    /// You create each client session with a custom `user_identifier_key`. Normally, the `user_identifier_key` is a user ID that your application provides.
    ///
    /// When calling the Seam API from your backend using an API key, you can pass the `user_identifier_key` as a parameter to limit results to the associated client session. For example, `/devices/list?user_identifier_key=123` only returns devices associated with the client session created with the `user_identifier_key` `123`.
    ///
    /// A client session has a token that you can use with the Seam JavaScript SDK to make requests from the client (browser) directly to the Seam API. The token restricts the user&apos;s access to only the devices that they own.
    ///
    /// See also [Get Started with React](https://docs.seam.co/ui-components/overview/getting-started-with-seam-components/get-started-with-react-components-and-client-session-tokens).
    /// </summary>
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

        /// <summary>
        /// ID of the client session.
        /// </summary>
        [DataMember(Name = "client_session_id", IsRequired = false, EmitDefaultValue = false)]
        public string ClientSessionId { get; set; }

        /// <summary>
        /// IDs of the [Connect Webviews](https://docs.seam.co/core-concepts/connect-webviews) associated with the [client session](https://docs.seam.co/core-concepts/authentication/client-session-tokens).
        /// </summary>
        [DataMember(Name = "connect_webview_ids", IsRequired = false, EmitDefaultValue = false)]
        public List<string> ConnectWebviewIds { get; set; }

        /// <summary>
        /// IDs of the [connected accounts](https://docs.seam.co/core-concepts/connected-accounts) associated with the [client session](https://docs.seam.co/core-concepts/authentication/client-session-tokens).
        /// </summary>
        [DataMember(Name = "connected_account_ids", IsRequired = false, EmitDefaultValue = false)]
        public List<string> ConnectedAccountIds { get; set; }

        /// <summary>
        /// Date and time at which the [client session](https://docs.seam.co/core-concepts/authentication/client-session-tokens) was created.
        /// </summary>
        [DataMember(Name = "created_at", IsRequired = false, EmitDefaultValue = false)]
        public string CreatedAt { get; set; }

        /// <summary>
        /// Customer key associated with the [client session](https://docs.seam.co/core-concepts/authentication/client-session-tokens).
        /// </summary>
        [DataMember(Name = "customer_key", IsRequired = false, EmitDefaultValue = false)]
        public string? CustomerKey { get; set; }

        /// <summary>
        /// Number of devices associated with the [client session](https://docs.seam.co/core-concepts/authentication/client-session-tokens).
        /// </summary>
        [DataMember(Name = "device_count", IsRequired = false, EmitDefaultValue = false)]
        public float DeviceCount { get; set; }

        /// <summary>
        /// Date and time at which the [client session](https://docs.seam.co/core-concepts/authentication/client-session-tokens) expires.
        /// </summary>
        [DataMember(Name = "expires_at", IsRequired = false, EmitDefaultValue = false)]
        public string ExpiresAt { get; set; }

        /// <summary>
        /// Client session token associated with the [client session](https://docs.seam.co/core-concepts/authentication/client-session-tokens).
        /// </summary>
        [DataMember(Name = "token", IsRequired = false, EmitDefaultValue = false)]
        public string Token { get; set; }

        /// <summary>
        /// Your user ID for the user associated with the [client session](https://docs.seam.co/core-concepts/authentication/client-session-tokens).
        /// </summary>
        [DataMember(Name = "user_identifier_key", IsRequired = false, EmitDefaultValue = false)]
        public string? UserIdentifierKey { get; set; }

        /// <summary>
        /// ID of the [user identity](https://docs.seam.co/capability-guides/mobile-access/managing-mobile-app-user-accounts-with-user-identities#what-is-a-user-identity) associated with the client session.
        /// </summary>
        [DataMember(Name = "user_identity_id", IsRequired = false, EmitDefaultValue = false)]
        public string? UserIdentityId { get; set; }

        /// <summary>
        /// IDs of the [user identities](https://docs.seam.co/capability-guides/mobile-access/managing-mobile-app-user-accounts-with-user-identities#what-is-a-user-identity) associated with the client session.
        /// </summary>
        [Obsolete("Use `user_identity_id` instead.")]
        [DataMember(Name = "user_identity_ids", IsRequired = false, EmitDefaultValue = false)]
        public List<string> UserIdentityIds { get; set; }

        /// <summary>
        /// ID of the workspace associated with the client session.
        /// </summary>
        [DataMember(Name = "workspace_id", IsRequired = false, EmitDefaultValue = false)]
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
