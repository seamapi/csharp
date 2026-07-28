using System.Runtime.Serialization;
using System.Text;
using JsonSubTypes;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
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

        /// <summary>
        /// Request parameters for Create a Client Session.
        /// </summary>
        [DataContract(Name = "createRequest_request")]
        public class CreateRequest
        {
            [JsonConstructorAttribute]
            protected CreateRequest() { }

            public CreateRequest(
                List<string>? connectWebviewIds = default,
                List<string>? connectedAccountIds = default,
                string? customerId = default,
                string? customerKey = default,
                string? expiresAt = default,
                string? userIdentifierKey = default,
                string? userIdentityId = default,
                List<string>? userIdentityIds = default
            )
            {
                ConnectWebviewIds = connectWebviewIds;
                ConnectedAccountIds = connectedAccountIds;
                CustomerId = customerId;
                CustomerKey = customerKey;
                ExpiresAt = expiresAt;
                UserIdentifierKey = userIdentifierKey;
                UserIdentityId = userIdentityId;
                UserIdentityIds = userIdentityIds;
            }

            /// <summary>
            /// IDs of the [Connect Webviews](https://docs.seam.co/core-concepts/connect-webviews) for which you want to create a client session.
            /// </summary>
            [DataMember(Name = "connect_webview_ids", IsRequired = false, EmitDefaultValue = false)]
            public List<string>? ConnectWebviewIds { get; set; }

            /// <summary>
            /// IDs of the [connected accounts](https://docs.seam.co/core-concepts/connected-accounts) for which you want to create a client session.
            /// </summary>
            [DataMember(
                Name = "connected_account_ids",
                IsRequired = false,
                EmitDefaultValue = false
            )]
            public List<string>? ConnectedAccountIds { get; set; }

            /// <summary>
            /// Customer ID that you want to associate with the new client session.
            /// </summary>
            [DataMember(Name = "customer_id", IsRequired = false, EmitDefaultValue = false)]
            public string? CustomerId { get; set; }

            /// <summary>
            /// Customer key that you want to associate with the new client session.
            /// </summary>
            [DataMember(Name = "customer_key", IsRequired = false, EmitDefaultValue = false)]
            public string? CustomerKey { get; set; }

            /// <summary>
            /// Date and time at which the client session should expire, in [ISO 8601](https://www.iso.org/iso-8601-date-and-time-format.html) format.
            /// </summary>
            [DataMember(Name = "expires_at", IsRequired = false, EmitDefaultValue = false)]
            public string? ExpiresAt { get; set; }

            /// <summary>
            /// Your user ID for the user for whom you want to create a client session.
            /// </summary>
            [DataMember(Name = "user_identifier_key", IsRequired = false, EmitDefaultValue = false)]
            public string? UserIdentifierKey { get; set; }

            /// <summary>
            /// ID of the [user identity](https://docs.seam.co/capability-guides/mobile-access/managing-mobile-app-user-accounts-with-user-identities#what-is-a-user-identity) for which you want to create a client session.
            /// </summary>
            [DataMember(Name = "user_identity_id", IsRequired = false, EmitDefaultValue = false)]
            public string? UserIdentityId { get; set; }

            /// <summary>
            /// IDs of the [user identities](https://docs.seam.co/capability-guides/mobile-access/managing-mobile-app-user-accounts-with-user-identities#what-is-a-user-identity) that you want to associate with the client session.
            /// </summary>
            [Obsolete("Use `user_identity_id` instead.")]
            [DataMember(Name = "user_identity_ids", IsRequired = false, EmitDefaultValue = false)]
            public List<string>? UserIdentityIds { get; set; }

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

        [DataContract(Name = "createResponse_response")]
        public class CreateResponse
        {
            [JsonConstructorAttribute]
            protected CreateResponse() { }

            public CreateResponse(ClientSession clientSession = default)
            {
                ClientSession = clientSession;
            }

            /// <summary>
            /// OK
            /// </summary>
            [DataMember(Name = "client_session", IsRequired = false, EmitDefaultValue = false)]
            public ClientSession ClientSession { get; set; }

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

        /// <summary>
        /// Creates a new [client session](https://docs.seam.co/core-concepts/authentication/client-session-tokens).
        /// </summary>
        public ClientSession Create(CreateRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            return _seam
                .Post<CreateResponse>("/client_sessions/create", requestOptions)
                .Data.ClientSession;
        }

        /// <summary>
        /// Creates a new [client session](https://docs.seam.co/core-concepts/authentication/client-session-tokens).
        /// </summary>
        public ClientSession Create(
            List<string>? connectWebviewIds = default,
            List<string>? connectedAccountIds = default,
            string? customerId = default,
            string? customerKey = default,
            string? expiresAt = default,
            string? userIdentifierKey = default,
            string? userIdentityId = default,
            List<string>? userIdentityIds = default
        )
        {
            return Create(
                new CreateRequest(
                    connectWebviewIds: connectWebviewIds,
                    connectedAccountIds: connectedAccountIds,
                    customerId: customerId,
                    customerKey: customerKey,
                    expiresAt: expiresAt,
                    userIdentifierKey: userIdentifierKey,
                    userIdentityId: userIdentityId,
                    userIdentityIds: userIdentityIds
                )
            );
        }

        /// <summary>
        /// Creates a new [client session](https://docs.seam.co/core-concepts/authentication/client-session-tokens).
        /// </summary>
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

        /// <summary>
        /// Creates a new [client session](https://docs.seam.co/core-concepts/authentication/client-session-tokens).
        /// </summary>
        public async Task<ClientSession> CreateAsync(
            List<string>? connectWebviewIds = default,
            List<string>? connectedAccountIds = default,
            string? customerId = default,
            string? customerKey = default,
            string? expiresAt = default,
            string? userIdentifierKey = default,
            string? userIdentityId = default,
            List<string>? userIdentityIds = default
        )
        {
            return (
                await CreateAsync(
                    new CreateRequest(
                        connectWebviewIds: connectWebviewIds,
                        connectedAccountIds: connectedAccountIds,
                        customerId: customerId,
                        customerKey: customerKey,
                        expiresAt: expiresAt,
                        userIdentifierKey: userIdentifierKey,
                        userIdentityId: userIdentityId,
                        userIdentityIds: userIdentityIds
                    )
                )
            );
        }

        /// <summary>
        /// Request parameters for Delete a Client Session.
        /// </summary>
        [DataContract(Name = "deleteRequest_request")]
        public class DeleteRequest
        {
            [JsonConstructorAttribute]
            protected DeleteRequest() { }

            public DeleteRequest(string clientSessionId = default)
            {
                ClientSessionId = clientSessionId;
            }

            /// <summary>
            /// ID of the client session that you want to delete.
            /// </summary>
            [DataMember(Name = "client_session_id", IsRequired = true, EmitDefaultValue = false)]
            public string ClientSessionId { get; set; }

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

        /// <summary>
        /// Deletes a [client session](https://docs.seam.co/core-concepts/authentication/client-session-tokens).
        /// </summary>
        public void Delete(DeleteRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            _seam.Post<object>("/client_sessions/delete", requestOptions);
        }

        /// <summary>
        /// Deletes a [client session](https://docs.seam.co/core-concepts/authentication/client-session-tokens).
        /// </summary>
        public void Delete(string clientSessionId = default)
        {
            Delete(new DeleteRequest(clientSessionId: clientSessionId));
        }

        /// <summary>
        /// Deletes a [client session](https://docs.seam.co/core-concepts/authentication/client-session-tokens).
        /// </summary>
        public async Task DeleteAsync(DeleteRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            await _seam.PostAsync<object>("/client_sessions/delete", requestOptions);
        }

        /// <summary>
        /// Deletes a [client session](https://docs.seam.co/core-concepts/authentication/client-session-tokens).
        /// </summary>
        public async Task DeleteAsync(string clientSessionId = default)
        {
            await DeleteAsync(new DeleteRequest(clientSessionId: clientSessionId));
        }

        /// <summary>
        /// Request parameters for Get a Client Session.
        /// </summary>
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

            /// <summary>
            /// ID of the client session that you want to get.
            /// </summary>
            [DataMember(Name = "client_session_id", IsRequired = false, EmitDefaultValue = false)]
            public string? ClientSessionId { get; set; }

            /// <summary>
            /// User identifier key associated with the client session that you want to get.
            /// </summary>
            [DataMember(Name = "user_identifier_key", IsRequired = false, EmitDefaultValue = false)]
            public string? UserIdentifierKey { get; set; }

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

        [DataContract(Name = "getResponse_response")]
        public class GetResponse
        {
            [JsonConstructorAttribute]
            protected GetResponse() { }

            public GetResponse(ClientSession clientSession = default)
            {
                ClientSession = clientSession;
            }

            /// <summary>
            /// OK
            /// </summary>
            [DataMember(Name = "client_session", IsRequired = false, EmitDefaultValue = false)]
            public ClientSession ClientSession { get; set; }

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

        /// <summary>
        /// Returns a specified [client session](https://docs.seam.co/core-concepts/authentication/client-session-tokens).
        /// </summary>
        public ClientSession Get(GetRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            return _seam
                .Post<GetResponse>("/client_sessions/get", requestOptions)
                .Data.ClientSession;
        }

        /// <summary>
        /// Returns a specified [client session](https://docs.seam.co/core-concepts/authentication/client-session-tokens).
        /// </summary>
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

        /// <summary>
        /// Returns a specified [client session](https://docs.seam.co/core-concepts/authentication/client-session-tokens).
        /// </summary>
        public async Task<ClientSession> GetAsync(GetRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            return (await _seam.PostAsync<GetResponse>("/client_sessions/get", requestOptions))
                .Data
                .ClientSession;
        }

        /// <summary>
        /// Returns a specified [client session](https://docs.seam.co/core-concepts/authentication/client-session-tokens).
        /// </summary>
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

        /// <summary>
        /// Request parameters for Get or Create a Client Session.
        /// </summary>
        [DataContract(Name = "getOrCreateRequest_request")]
        public class GetOrCreateRequest
        {
            [JsonConstructorAttribute]
            protected GetOrCreateRequest() { }

            public GetOrCreateRequest(
                List<string>? connectWebviewIds = default,
                List<string>? connectedAccountIds = default,
                string? expiresAt = default,
                string? userIdentifierKey = default,
                string? userIdentityId = default,
                List<string>? userIdentityIds = default
            )
            {
                ConnectWebviewIds = connectWebviewIds;
                ConnectedAccountIds = connectedAccountIds;
                ExpiresAt = expiresAt;
                UserIdentifierKey = userIdentifierKey;
                UserIdentityId = userIdentityId;
                UserIdentityIds = userIdentityIds;
            }

            /// <summary>
            /// IDs of the [Connect Webviews](https://docs.seam.co/core-concepts/connect-webviews) that you want to associate with the client session (or that are already associated with the existing client session).
            /// </summary>
            [DataMember(Name = "connect_webview_ids", IsRequired = false, EmitDefaultValue = false)]
            public List<string>? ConnectWebviewIds { get; set; }

            /// <summary>
            /// IDs of the [connected accounts](https://docs.seam.co/api/connected_accounts) that you want to associate with the client session (or that are already associated with the existing client session).
            /// </summary>
            [DataMember(
                Name = "connected_account_ids",
                IsRequired = false,
                EmitDefaultValue = false
            )]
            public List<string>? ConnectedAccountIds { get; set; }

            /// <summary>
            /// Date and time at which the client session should expire in [ISO 8601](https://www.iso.org/iso-8601-date-and-time-format.html) format. If the client session already exists, this will update the expiration before returning it.
            /// </summary>
            [DataMember(Name = "expires_at", IsRequired = false, EmitDefaultValue = false)]
            public string? ExpiresAt { get; set; }

            /// <summary>
            /// Your user ID for the user that you want to associate with the client session (or that is already associated with the existing client session).
            /// </summary>
            [DataMember(Name = "user_identifier_key", IsRequired = false, EmitDefaultValue = false)]
            public string? UserIdentifierKey { get; set; }

            /// <summary>
            /// ID of the [user identity](https://docs.seam.co/capability-guides/mobile-access/managing-mobile-app-user-accounts-with-user-identities#what-is-a-user-identity) that you want to associate with the client session (or that are already associated with the existing client session).
            /// </summary>
            [DataMember(Name = "user_identity_id", IsRequired = false, EmitDefaultValue = false)]
            public string? UserIdentityId { get; set; }

            /// <summary>
            /// IDs of the [user identities](https://docs.seam.co/capability-guides/mobile-access/managing-mobile-app-user-accounts-with-user-identities#what-is-a-user-identity) that you want to associate with the client session.
            /// </summary>
            [Obsolete("Use `user_identity_id`.")]
            [DataMember(Name = "user_identity_ids", IsRequired = false, EmitDefaultValue = false)]
            public List<string>? UserIdentityIds { get; set; }

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

        [DataContract(Name = "getOrCreateResponse_response")]
        public class GetOrCreateResponse
        {
            [JsonConstructorAttribute]
            protected GetOrCreateResponse() { }

            public GetOrCreateResponse(ClientSession clientSession = default)
            {
                ClientSession = clientSession;
            }

            /// <summary>
            /// OK
            /// </summary>
            [DataMember(Name = "client_session", IsRequired = false, EmitDefaultValue = false)]
            public ClientSession ClientSession { get; set; }

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

        /// <summary>
        /// Returns a [client session](https://docs.seam.co/core-concepts/authentication/client-session-tokens) with specific characteristics or creates a new client session with these characteristics if it does not yet exist.
        /// </summary>
        public ClientSession GetOrCreate(GetOrCreateRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            return _seam
                .Post<GetOrCreateResponse>("/client_sessions/get_or_create", requestOptions)
                .Data.ClientSession;
        }

        /// <summary>
        /// Returns a [client session](https://docs.seam.co/core-concepts/authentication/client-session-tokens) with specific characteristics or creates a new client session with these characteristics if it does not yet exist.
        /// </summary>
        public ClientSession GetOrCreate(
            List<string>? connectWebviewIds = default,
            List<string>? connectedAccountIds = default,
            string? expiresAt = default,
            string? userIdentifierKey = default,
            string? userIdentityId = default,
            List<string>? userIdentityIds = default
        )
        {
            return GetOrCreate(
                new GetOrCreateRequest(
                    connectWebviewIds: connectWebviewIds,
                    connectedAccountIds: connectedAccountIds,
                    expiresAt: expiresAt,
                    userIdentifierKey: userIdentifierKey,
                    userIdentityId: userIdentityId,
                    userIdentityIds: userIdentityIds
                )
            );
        }

        /// <summary>
        /// Returns a [client session](https://docs.seam.co/core-concepts/authentication/client-session-tokens) with specific characteristics or creates a new client session with these characteristics if it does not yet exist.
        /// </summary>
        public async Task<ClientSession> GetOrCreateAsync(GetOrCreateRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            return (
                await _seam.PostAsync<GetOrCreateResponse>(
                    "/client_sessions/get_or_create",
                    requestOptions
                )
            )
                .Data
                .ClientSession;
        }

        /// <summary>
        /// Returns a [client session](https://docs.seam.co/core-concepts/authentication/client-session-tokens) with specific characteristics or creates a new client session with these characteristics if it does not yet exist.
        /// </summary>
        public async Task<ClientSession> GetOrCreateAsync(
            List<string>? connectWebviewIds = default,
            List<string>? connectedAccountIds = default,
            string? expiresAt = default,
            string? userIdentifierKey = default,
            string? userIdentityId = default,
            List<string>? userIdentityIds = default
        )
        {
            return (
                await GetOrCreateAsync(
                    new GetOrCreateRequest(
                        connectWebviewIds: connectWebviewIds,
                        connectedAccountIds: connectedAccountIds,
                        expiresAt: expiresAt,
                        userIdentifierKey: userIdentifierKey,
                        userIdentityId: userIdentityId,
                        userIdentityIds: userIdentityIds
                    )
                )
            );
        }

        /// <summary>
        /// Request parameters for Grant Access to a Client Session.
        /// </summary>
        [DataContract(Name = "grantAccessRequest_request")]
        public class GrantAccessRequest
        {
            [JsonConstructorAttribute]
            protected GrantAccessRequest() { }

            public GrantAccessRequest(
                string? clientSessionId = default,
                List<string>? connectWebviewIds = default,
                List<string>? connectedAccountIds = default,
                string? userIdentifierKey = default,
                string? userIdentityId = default,
                List<string>? userIdentityIds = default
            )
            {
                ClientSessionId = clientSessionId;
                ConnectWebviewIds = connectWebviewIds;
                ConnectedAccountIds = connectedAccountIds;
                UserIdentifierKey = userIdentifierKey;
                UserIdentityId = userIdentityId;
                UserIdentityIds = userIdentityIds;
            }

            /// <summary>
            /// ID of the client session to which you want to grant access to resources.
            /// </summary>
            [DataMember(Name = "client_session_id", IsRequired = false, EmitDefaultValue = false)]
            public string? ClientSessionId { get; set; }

            /// <summary>
            /// IDs of the [Connect Webviews](https://docs.seam.co/core-concepts/connect-webviews) that you want to associate with the client session.
            /// </summary>
            [DataMember(Name = "connect_webview_ids", IsRequired = false, EmitDefaultValue = false)]
            public List<string>? ConnectWebviewIds { get; set; }

            /// <summary>
            /// IDs of the [connected accounts](https://docs.seam.co/core-concepts/connected-accounts) that you want to associate with the client session.
            /// </summary>
            [DataMember(
                Name = "connected_account_ids",
                IsRequired = false,
                EmitDefaultValue = false
            )]
            public List<string>? ConnectedAccountIds { get; set; }

            /// <summary>
            /// Your user ID for the user that you want to associate with the client session.
            /// </summary>
            [DataMember(Name = "user_identifier_key", IsRequired = false, EmitDefaultValue = false)]
            public string? UserIdentifierKey { get; set; }

            /// <summary>
            /// ID of the [user identity](https://docs.seam.co/capability-guides/mobile-access/managing-mobile-app-user-accounts-with-user-identities#what-is-a-user-identity) that you want to associate with the client session.
            /// </summary>
            [DataMember(Name = "user_identity_id", IsRequired = false, EmitDefaultValue = false)]
            public string? UserIdentityId { get; set; }

            /// <summary>
            /// IDs of the [user identities](https://docs.seam.co/capability-guides/mobile-access/managing-mobile-app-user-accounts-with-user-identities#what-is-a-user-identity) that you want to associate with the client session.
            /// </summary>
            [Obsolete("Use `user_identity_id`.")]
            [DataMember(Name = "user_identity_ids", IsRequired = false, EmitDefaultValue = false)]
            public List<string>? UserIdentityIds { get; set; }

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

        /// <summary>
        /// Grants a [client session](https://docs.seam.co/core-concepts/authentication/client-session-tokens) access to one or more resources, such as [Connect Webviews](https://docs.seam.co/core-concepts/connect-webviews), [user identities](https://docs.seam.co/capability-guides/mobile-access/managing-mobile-app-user-accounts-with-user-identities#what-is-a-user-identity), and so on.
        /// </summary>
        public void GrantAccess(GrantAccessRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            _seam.Post<object>("/client_sessions/grant_access", requestOptions);
        }

        /// <summary>
        /// Grants a [client session](https://docs.seam.co/core-concepts/authentication/client-session-tokens) access to one or more resources, such as [Connect Webviews](https://docs.seam.co/core-concepts/connect-webviews), [user identities](https://docs.seam.co/capability-guides/mobile-access/managing-mobile-app-user-accounts-with-user-identities#what-is-a-user-identity), and so on.
        /// </summary>
        public void GrantAccess(
            string? clientSessionId = default,
            List<string>? connectWebviewIds = default,
            List<string>? connectedAccountIds = default,
            string? userIdentifierKey = default,
            string? userIdentityId = default,
            List<string>? userIdentityIds = default
        )
        {
            GrantAccess(
                new GrantAccessRequest(
                    clientSessionId: clientSessionId,
                    connectWebviewIds: connectWebviewIds,
                    connectedAccountIds: connectedAccountIds,
                    userIdentifierKey: userIdentifierKey,
                    userIdentityId: userIdentityId,
                    userIdentityIds: userIdentityIds
                )
            );
        }

        /// <summary>
        /// Grants a [client session](https://docs.seam.co/core-concepts/authentication/client-session-tokens) access to one or more resources, such as [Connect Webviews](https://docs.seam.co/core-concepts/connect-webviews), [user identities](https://docs.seam.co/capability-guides/mobile-access/managing-mobile-app-user-accounts-with-user-identities#what-is-a-user-identity), and so on.
        /// </summary>
        public async Task GrantAccessAsync(GrantAccessRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            await _seam.PostAsync<object>("/client_sessions/grant_access", requestOptions);
        }

        /// <summary>
        /// Grants a [client session](https://docs.seam.co/core-concepts/authentication/client-session-tokens) access to one or more resources, such as [Connect Webviews](https://docs.seam.co/core-concepts/connect-webviews), [user identities](https://docs.seam.co/capability-guides/mobile-access/managing-mobile-app-user-accounts-with-user-identities#what-is-a-user-identity), and so on.
        /// </summary>
        public async Task GrantAccessAsync(
            string? clientSessionId = default,
            List<string>? connectWebviewIds = default,
            List<string>? connectedAccountIds = default,
            string? userIdentifierKey = default,
            string? userIdentityId = default,
            List<string>? userIdentityIds = default
        )
        {
            await GrantAccessAsync(
                new GrantAccessRequest(
                    clientSessionId: clientSessionId,
                    connectWebviewIds: connectWebviewIds,
                    connectedAccountIds: connectedAccountIds,
                    userIdentifierKey: userIdentifierKey,
                    userIdentityId: userIdentityId,
                    userIdentityIds: userIdentityIds
                )
            );
        }

        /// <summary>
        /// Request parameters for List Client Sessions.
        /// </summary>
        [DataContract(Name = "listRequest_request")]
        public class ListRequest
        {
            [JsonConstructorAttribute]
            protected ListRequest() { }

            public ListRequest(
                string? clientSessionId = default,
                string? connectWebviewId = default,
                string? userIdentifierKey = default,
                string? userIdentityId = default,
                bool? withoutUserIdentifierKey = default
            )
            {
                ClientSessionId = clientSessionId;
                ConnectWebviewId = connectWebviewId;
                UserIdentifierKey = userIdentifierKey;
                UserIdentityId = userIdentityId;
                WithoutUserIdentifierKey = withoutUserIdentifierKey;
            }

            /// <summary>
            /// ID of the client session that you want to retrieve.
            /// </summary>
            [DataMember(Name = "client_session_id", IsRequired = false, EmitDefaultValue = false)]
            public string? ClientSessionId { get; set; }

            /// <summary>
            /// ID of the [Connect Webview](https://docs.seam.co/core-concepts/connect-webviews) for which you want to retrieve client sessions.
            /// </summary>
            [DataMember(Name = "connect_webview_id", IsRequired = false, EmitDefaultValue = false)]
            public string? ConnectWebviewId { get; set; }

            /// <summary>
            /// Your user ID for the user by which you want to filter client sessions.
            /// </summary>
            [DataMember(Name = "user_identifier_key", IsRequired = false, EmitDefaultValue = false)]
            public string? UserIdentifierKey { get; set; }

            /// <summary>
            /// ID of the [user identity](https://docs.seam.co/capability-guides/mobile-access/managing-mobile-app-user-accounts-with-user-identities#what-is-a-user-identity) for which you want to retrieve client sessions.
            /// </summary>
            [DataMember(Name = "user_identity_id", IsRequired = false, EmitDefaultValue = false)]
            public string? UserIdentityId { get; set; }

            /// <summary>
            /// Indicates whether to retrieve only client sessions without associated user identifier keys.
            /// </summary>
            [DataMember(
                Name = "without_user_identifier_key",
                IsRequired = false,
                EmitDefaultValue = false
            )]
            public bool? WithoutUserIdentifierKey { get; set; }

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

        [DataContract(Name = "listResponse_response")]
        public class ListResponse
        {
            [JsonConstructorAttribute]
            protected ListResponse() { }

            public ListResponse(List<ClientSession> clientSessions = default)
            {
                ClientSessions = clientSessions;
            }

            /// <summary>
            /// OK
            /// </summary>
            [DataMember(Name = "client_sessions", IsRequired = false, EmitDefaultValue = false)]
            public List<ClientSession> ClientSessions { get; set; }

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

        /// <summary>
        /// Returns a list of all [client sessions](https://docs.seam.co/core-concepts/authentication/client-session-tokens).
        /// </summary>
        public List<ClientSession> List(ListRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            return _seam
                .Post<ListResponse>("/client_sessions/list", requestOptions)
                .Data.ClientSessions;
        }

        /// <summary>
        /// Returns a list of all [client sessions](https://docs.seam.co/core-concepts/authentication/client-session-tokens).
        /// </summary>
        public List<ClientSession> List(
            string? clientSessionId = default,
            string? connectWebviewId = default,
            string? userIdentifierKey = default,
            string? userIdentityId = default,
            bool? withoutUserIdentifierKey = default
        )
        {
            return List(
                new ListRequest(
                    clientSessionId: clientSessionId,
                    connectWebviewId: connectWebviewId,
                    userIdentifierKey: userIdentifierKey,
                    userIdentityId: userIdentityId,
                    withoutUserIdentifierKey: withoutUserIdentifierKey
                )
            );
        }

        /// <summary>
        /// Returns a list of all [client sessions](https://docs.seam.co/core-concepts/authentication/client-session-tokens).
        /// </summary>
        public async Task<List<ClientSession>> ListAsync(ListRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            return (await _seam.PostAsync<ListResponse>("/client_sessions/list", requestOptions))
                .Data
                .ClientSessions;
        }

        /// <summary>
        /// Returns a list of all [client sessions](https://docs.seam.co/core-concepts/authentication/client-session-tokens).
        /// </summary>
        public async Task<List<ClientSession>> ListAsync(
            string? clientSessionId = default,
            string? connectWebviewId = default,
            string? userIdentifierKey = default,
            string? userIdentityId = default,
            bool? withoutUserIdentifierKey = default
        )
        {
            return (
                await ListAsync(
                    new ListRequest(
                        clientSessionId: clientSessionId,
                        connectWebviewId: connectWebviewId,
                        userIdentifierKey: userIdentifierKey,
                        userIdentityId: userIdentityId,
                        withoutUserIdentifierKey: withoutUserIdentifierKey
                    )
                )
            );
        }

        /// <summary>
        /// Request parameters for Revoke a Client Session.
        /// </summary>
        [DataContract(Name = "revokeRequest_request")]
        public class RevokeRequest
        {
            [JsonConstructorAttribute]
            protected RevokeRequest() { }

            public RevokeRequest(string clientSessionId = default)
            {
                ClientSessionId = clientSessionId;
            }

            /// <summary>
            /// ID of the client session that you want to revoke.
            /// </summary>
            [DataMember(Name = "client_session_id", IsRequired = true, EmitDefaultValue = false)]
            public string ClientSessionId { get; set; }

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

        /// <summary>
        /// Revokes a [client session](https://docs.seam.co/core-concepts/authentication/client-session-tokens).
        ///
        /// Note that [deleting a client session](https://docs.seam.co/api/client_sessions/delete) is a separate action.
        /// </summary>
        public void Revoke(RevokeRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            _seam.Post<object>("/client_sessions/revoke", requestOptions);
        }

        /// <summary>
        /// Revokes a [client session](https://docs.seam.co/core-concepts/authentication/client-session-tokens).
        ///
        /// Note that [deleting a client session](https://docs.seam.co/api/client_sessions/delete) is a separate action.
        /// </summary>
        public void Revoke(string clientSessionId = default)
        {
            Revoke(new RevokeRequest(clientSessionId: clientSessionId));
        }

        /// <summary>
        /// Revokes a [client session](https://docs.seam.co/core-concepts/authentication/client-session-tokens).
        ///
        /// Note that [deleting a client session](https://docs.seam.co/api/client_sessions/delete) is a separate action.
        /// </summary>
        public async Task RevokeAsync(RevokeRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            await _seam.PostAsync<object>("/client_sessions/revoke", requestOptions);
        }

        /// <summary>
        /// Revokes a [client session](https://docs.seam.co/core-concepts/authentication/client-session-tokens).
        ///
        /// Note that [deleting a client session](https://docs.seam.co/api/client_sessions/delete) is a separate action.
        /// </summary>
        public async Task RevokeAsync(string clientSessionId = default)
        {
            await RevokeAsync(new RevokeRequest(clientSessionId: clientSessionId));
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
