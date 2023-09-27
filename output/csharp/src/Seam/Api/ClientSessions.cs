using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using JsonSubTypes;
using Seam.Client;
using Seam.Model;

namespace Seam.Api
{
    public class ClientSessions
    {
        private ISeamClient _seam;

        public ClientSessions(ISeamClient seam)
        {
            _seam = seam;
        }

        [DataContract(Name = "createRequest_request")]
        public class CreateRequest
        {
            [JsonConstructorAttribute]
            protected CreateRequest() { }

            public CreateRequest(
                string? userIdentifierKey = default,
                List<string>? connectWebviewIds = default,
                List<string>? connectedAccountIds = default
            )
            {
                UserIdentifierKey = userIdentifierKey;
                ConnectWebviewIds = connectWebviewIds;
                ConnectedAccountIds = connectedAccountIds;
            }

            [DataMember(Name = "user_identifier_key", IsRequired = false, EmitDefaultValue = false)]
            public string? UserIdentifierKey { get; set; }

            [DataMember(Name = "connect_webview_ids", IsRequired = false, EmitDefaultValue = false)]
            public List<string>? ConnectWebviewIds { get; set; }

            [DataMember(
                Name = "connected_account_ids",
                IsRequired = false,
                EmitDefaultValue = false
            )]
            public List<string>? ConnectedAccountIds { get; set; }
        }

        [DataContract(Name = "createResponse_response")]
        public class CreateResponse
        {
            [JsonConstructorAttribute]
            protected CreateResponse() { }

            public CreateResponse(ClientSession clientSession = default)
            {
                ClientSession = clientSession;
            }

            [DataMember(Name = "client_session", IsRequired = false, EmitDefaultValue = false)]
            public ClientSession ClientSession { get; set; }
        }

        public ClientSession Create(CreateRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            return _seam
                .Post<CreateResponse>("/client_sessions/create", requestOptions)
                .Data.ClientSession;
        }

        public ClientSession Create(
            string? userIdentifierKey = default,
            List<string>? connectWebviewIds = default,
            List<string>? connectedAccountIds = default
        )
        {
            return Create(
                new CreateRequest(
                    userIdentifierKey: userIdentifierKey,
                    connectWebviewIds: connectWebviewIds,
                    connectedAccountIds: connectedAccountIds
                )
            );
        }

        public async Task<ClientSession> CreateAsync(CreateRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            return (
                await _seam.PostAsync<CreateResponse>("/client_sessions/create", requestOptions)
            )
                .Data
                .ClientSession;
        }

        public async Task<ClientSession> CreateAsync(
            string? userIdentifierKey = default,
            List<string>? connectWebviewIds = default,
            List<string>? connectedAccountIds = default
        )
        {
            return (
                await CreateAsync(
                    new CreateRequest(
                        userIdentifierKey: userIdentifierKey,
                        connectWebviewIds: connectWebviewIds,
                        connectedAccountIds: connectedAccountIds
                    )
                )
            );
        }

        [DataContract(Name = "getRequest_request")]
        public class GetRequest
        {
            [JsonConstructorAttribute]
            protected GetRequest() { }

            public GetRequest(
                string? clientSessionId = default,
                string? userIdentifierKey = default
            )
            {
                ClientSessionId = clientSessionId;
                UserIdentifierKey = userIdentifierKey;
            }

            [DataMember(Name = "client_session_id", IsRequired = false, EmitDefaultValue = false)]
            public string? ClientSessionId { get; set; }

            [DataMember(Name = "user_identifier_key", IsRequired = false, EmitDefaultValue = false)]
            public string? UserIdentifierKey { get; set; }
        }

        [DataContract(Name = "getResponse_response")]
        public class GetResponse
        {
            [JsonConstructorAttribute]
            protected GetResponse() { }

            public GetResponse(ClientSession clientSession = default)
            {
                ClientSession = clientSession;
            }

            [DataMember(Name = "client_session", IsRequired = false, EmitDefaultValue = false)]
            public ClientSession ClientSession { get; set; }
        }

        public ClientSession Get(GetRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            return _seam
                .Post<GetResponse>("/client_sessions/get", requestOptions)
                .Data.ClientSession;
        }

        public ClientSession Get(
            string? clientSessionId = default,
            string? userIdentifierKey = default
        )
        {
            return Get(
                new GetRequest(
                    clientSessionId: clientSessionId,
                    userIdentifierKey: userIdentifierKey
                )
            );
        }

        public async Task<ClientSession> GetAsync(GetRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            return (await _seam.PostAsync<GetResponse>("/client_sessions/get", requestOptions))
                .Data
                .ClientSession;
        }

        public async Task<ClientSession> GetAsync(
            string? clientSessionId = default,
            string? userIdentifierKey = default
        )
        {
            return (
                await GetAsync(
                    new GetRequest(
                        clientSessionId: clientSessionId,
                        userIdentifierKey: userIdentifierKey
                    )
                )
            );
        }

        [DataContract(Name = "listRequest_request")]
        public class ListRequest
        {
            [JsonConstructorAttribute]
            protected ListRequest() { }

            public ListRequest(
                string? clientSessionId = default,
                string? userIdentifierKey = default,
                string? connectWebviewId = default,
                bool? withoutUserIdentifierKey = default
            )
            {
                ClientSessionId = clientSessionId;
                UserIdentifierKey = userIdentifierKey;
                ConnectWebviewId = connectWebviewId;
                WithoutUserIdentifierKey = withoutUserIdentifierKey;
            }

            [DataMember(Name = "client_session_id", IsRequired = false, EmitDefaultValue = false)]
            public string? ClientSessionId { get; set; }

            [DataMember(Name = "user_identifier_key", IsRequired = false, EmitDefaultValue = false)]
            public string? UserIdentifierKey { get; set; }

            [DataMember(Name = "connect_webview_id", IsRequired = false, EmitDefaultValue = false)]
            public string? ConnectWebviewId { get; set; }

            [DataMember(
                Name = "without_user_identifier_key",
                IsRequired = false,
                EmitDefaultValue = false
            )]
            public bool? WithoutUserIdentifierKey { get; set; }
        }

        [DataContract(Name = "listResponse_response")]
        public class ListResponse
        {
            [JsonConstructorAttribute]
            protected ListResponse() { }

            public ListResponse(List<ClientSession> clientSessions = default)
            {
                ClientSessions = clientSessions;
            }

            [DataMember(Name = "client_sessions", IsRequired = false, EmitDefaultValue = false)]
            public List<ClientSession> ClientSessions { get; set; }
        }

        public List<ClientSession> List(ListRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            return _seam
                .Post<ListResponse>("/client_sessions/list", requestOptions)
                .Data.ClientSessions;
        }

        public List<ClientSession> List(
            string? clientSessionId = default,
            string? userIdentifierKey = default,
            string? connectWebviewId = default,
            bool? withoutUserIdentifierKey = default
        )
        {
            return List(
                new ListRequest(
                    clientSessionId: clientSessionId,
                    userIdentifierKey: userIdentifierKey,
                    connectWebviewId: connectWebviewId,
                    withoutUserIdentifierKey: withoutUserIdentifierKey
                )
            );
        }

        public async Task<List<ClientSession>> ListAsync(ListRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            return (await _seam.PostAsync<ListResponse>("/client_sessions/list", requestOptions))
                .Data
                .ClientSessions;
        }

        public async Task<List<ClientSession>> ListAsync(
            string? clientSessionId = default,
            string? userIdentifierKey = default,
            string? connectWebviewId = default,
            bool? withoutUserIdentifierKey = default
        )
        {
            return (
                await ListAsync(
                    new ListRequest(
                        clientSessionId: clientSessionId,
                        userIdentifierKey: userIdentifierKey,
                        connectWebviewId: connectWebviewId,
                        withoutUserIdentifierKey: withoutUserIdentifierKey
                    )
                )
            );
        }
    }
}

namespace Seam.Client
{
    public partial class SeamClient
    {
        public Api.ClientSessions ClientSessions => new(this);
    }

    public partial interface ISeamClient
    {
        public Api.ClientSessions ClientSessions { get; }
    }
}
