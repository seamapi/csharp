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
    public class ConnectedAccounts
    {
        private ISeamClient _seam;

        public ConnectedAccounts(ISeamClient seam)
        {
            _seam = seam;
        }

        [DataContract(Name = "deleteRequest_request")]
        public class DeleteRequest
        {
            [JsonConstructorAttribute]
            protected DeleteRequest() { }

            public DeleteRequest(string connectedAccountId = default, bool? sync = default)
            {
                ConnectedAccountId = connectedAccountId;
                Sync = sync;
            }

            [DataMember(Name = "connected_account_id", IsRequired = true, EmitDefaultValue = false)]
            public string ConnectedAccountId { get; set; }

            [DataMember(Name = "sync", IsRequired = false, EmitDefaultValue = false)]
            public bool? Sync { get; set; }

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

        public void Delete(DeleteRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            _seam.Post<object>("/connected_accounts/delete", requestOptions);
        }

        public void Delete(string connectedAccountId = default, bool? sync = default)
        {
            Delete(new DeleteRequest(connectedAccountId: connectedAccountId, sync: sync));
        }

        public async Task DeleteAsync(DeleteRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            await _seam.PostAsync<object>("/connected_accounts/delete", requestOptions);
        }

        public async Task DeleteAsync(string connectedAccountId = default, bool? sync = default)
        {
            await DeleteAsync(
                new DeleteRequest(connectedAccountId: connectedAccountId, sync: sync)
            );
        }

        [DataContract(Name = "getRequest_request")]
        public class GetRequest
        {
            [JsonConstructorAttribute]
            protected GetRequest() { }

            public GetRequest(string? connectedAccountId = default, string? email = default)
            {
                ConnectedAccountId = connectedAccountId;
                Email = email;
            }

            [DataMember(
                Name = "connected_account_id",
                IsRequired = false,
                EmitDefaultValue = false
            )]
            public string? ConnectedAccountId { get; set; }

            [DataMember(Name = "email", IsRequired = false, EmitDefaultValue = false)]
            public string? Email { get; set; }

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

            public GetResponse(ConnectedAccount connectedAccount = default)
            {
                ConnectedAccount = connectedAccount;
            }

            [DataMember(Name = "connected_account", IsRequired = false, EmitDefaultValue = false)]
            public ConnectedAccount ConnectedAccount { get; set; }

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

        public ConnectedAccount Get(GetRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            return _seam
                .Post<GetResponse>("/connected_accounts/get", requestOptions)
                .Data.ConnectedAccount;
        }

        public ConnectedAccount Get(string? connectedAccountId = default, string? email = default)
        {
            return Get(new GetRequest(connectedAccountId: connectedAccountId, email: email));
        }

        public async Task<ConnectedAccount> GetAsync(GetRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            return (await _seam.PostAsync<GetResponse>("/connected_accounts/get", requestOptions))
                .Data
                .ConnectedAccount;
        }

        public async Task<ConnectedAccount> GetAsync(
            string? connectedAccountId = default,
            string? email = default
        )
        {
            return (
                await GetAsync(new GetRequest(connectedAccountId: connectedAccountId, email: email))
            );
        }

        [DataContract(Name = "listRequest_request")]
        public class ListRequest
        {
            [JsonConstructorAttribute]
            protected ListRequest() { }

            public ListRequest(
                object? customMetadataHas = default,
                string? customerKey = default,
                int? limit = default,
                string? pageCursor = default,
                string? search = default,
                string? userIdentifierKey = default
            )
            {
                CustomMetadataHas = customMetadataHas;
                CustomerKey = customerKey;
                Limit = limit;
                PageCursor = pageCursor;
                Search = search;
                UserIdentifierKey = userIdentifierKey;
            }

            [DataMember(Name = "custom_metadata_has", IsRequired = false, EmitDefaultValue = false)]
            public object? CustomMetadataHas { get; set; }

            [DataMember(Name = "customer_key", IsRequired = false, EmitDefaultValue = false)]
            public string? CustomerKey { get; set; }

            [DataMember(Name = "limit", IsRequired = false, EmitDefaultValue = false)]
            public int? Limit { get; set; }

            [DataMember(Name = "page_cursor", IsRequired = false, EmitDefaultValue = false)]
            public string? PageCursor { get; set; }

            [DataMember(Name = "search", IsRequired = false, EmitDefaultValue = false)]
            public string? Search { get; set; }

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

        [DataContract(Name = "listResponse_response")]
        public class ListResponse
        {
            [JsonConstructorAttribute]
            protected ListResponse() { }

            public ListResponse(List<ConnectedAccount> connectedAccounts = default)
            {
                ConnectedAccounts = connectedAccounts;
            }

            [DataMember(Name = "connected_accounts", IsRequired = false, EmitDefaultValue = false)]
            public List<ConnectedAccount> ConnectedAccounts { get; set; }

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

        public List<ConnectedAccount> List(ListRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            return _seam
                .Post<ListResponse>("/connected_accounts/list", requestOptions)
                .Data.ConnectedAccounts;
        }

        public List<ConnectedAccount> List(
            object? customMetadataHas = default,
            string? customerKey = default,
            int? limit = default,
            string? pageCursor = default,
            string? search = default,
            string? userIdentifierKey = default
        )
        {
            return List(
                new ListRequest(
                    customMetadataHas: customMetadataHas,
                    customerKey: customerKey,
                    limit: limit,
                    pageCursor: pageCursor,
                    search: search,
                    userIdentifierKey: userIdentifierKey
                )
            );
        }

        public async Task<List<ConnectedAccount>> ListAsync(ListRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            return (await _seam.PostAsync<ListResponse>("/connected_accounts/list", requestOptions))
                .Data
                .ConnectedAccounts;
        }

        public async Task<List<ConnectedAccount>> ListAsync(
            object? customMetadataHas = default,
            string? customerKey = default,
            int? limit = default,
            string? pageCursor = default,
            string? search = default,
            string? userIdentifierKey = default
        )
        {
            return (
                await ListAsync(
                    new ListRequest(
                        customMetadataHas: customMetadataHas,
                        customerKey: customerKey,
                        limit: limit,
                        pageCursor: pageCursor,
                        search: search,
                        userIdentifierKey: userIdentifierKey
                    )
                )
            );
        }

        [DataContract(Name = "syncRequest_request")]
        public class SyncRequest
        {
            [JsonConstructorAttribute]
            protected SyncRequest() { }

            public SyncRequest(string connectedAccountId = default)
            {
                ConnectedAccountId = connectedAccountId;
            }

            [DataMember(Name = "connected_account_id", IsRequired = true, EmitDefaultValue = false)]
            public string ConnectedAccountId { get; set; }

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

        public void Sync(SyncRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            _seam.Post<object>("/connected_accounts/sync", requestOptions);
        }

        public void Sync(string connectedAccountId = default)
        {
            Sync(new SyncRequest(connectedAccountId: connectedAccountId));
        }

        public async Task SyncAsync(SyncRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            await _seam.PostAsync<object>("/connected_accounts/sync", requestOptions);
        }

        public async Task SyncAsync(string connectedAccountId = default)
        {
            await SyncAsync(new SyncRequest(connectedAccountId: connectedAccountId));
        }

        [DataContract(Name = "updateRequest_request")]
        public class UpdateRequest
        {
            [JsonConstructorAttribute]
            protected UpdateRequest() { }

            public UpdateRequest(
                List<UpdateRequest.AcceptedCapabilitiesEnum>? acceptedCapabilities = default,
                bool? automaticallyManageNewDevices = default,
                string connectedAccountId = default,
                object? customMetadata = default
            )
            {
                AcceptedCapabilities = acceptedCapabilities;
                AutomaticallyManageNewDevices = automaticallyManageNewDevices;
                ConnectedAccountId = connectedAccountId;
                CustomMetadata = customMetadata;
            }

            [JsonConverter(typeof(SafeStringEnumConverter))]
            public enum AcceptedCapabilitiesEnum
            {
                [EnumMember(Value = "unrecognized")]
                Unrecognized = 0,

                [EnumMember(Value = "lock")]
                Lock = 1,

                [EnumMember(Value = "thermostat")]
                Thermostat = 2,

                [EnumMember(Value = "noise_sensor")]
                NoiseSensor = 3,

                [EnumMember(Value = "access_control")]
                AccessControl = 4,
            }

            [DataMember(
                Name = "accepted_capabilities",
                IsRequired = false,
                EmitDefaultValue = false
            )]
            public List<UpdateRequest.AcceptedCapabilitiesEnum>? AcceptedCapabilities { get; set; }

            [DataMember(
                Name = "automatically_manage_new_devices",
                IsRequired = false,
                EmitDefaultValue = false
            )]
            public bool? AutomaticallyManageNewDevices { get; set; }

            [DataMember(Name = "connected_account_id", IsRequired = true, EmitDefaultValue = false)]
            public string ConnectedAccountId { get; set; }

            [DataMember(Name = "custom_metadata", IsRequired = false, EmitDefaultValue = false)]
            public object? CustomMetadata { get; set; }

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

        public void Update(UpdateRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            _seam.Post<object>("/connected_accounts/update", requestOptions);
        }

        public void Update(
            List<UpdateRequest.AcceptedCapabilitiesEnum>? acceptedCapabilities = default,
            bool? automaticallyManageNewDevices = default,
            string connectedAccountId = default,
            object? customMetadata = default
        )
        {
            Update(
                new UpdateRequest(
                    acceptedCapabilities: acceptedCapabilities,
                    automaticallyManageNewDevices: automaticallyManageNewDevices,
                    connectedAccountId: connectedAccountId,
                    customMetadata: customMetadata
                )
            );
        }

        public async Task UpdateAsync(UpdateRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            await _seam.PostAsync<object>("/connected_accounts/update", requestOptions);
        }

        public async Task UpdateAsync(
            List<UpdateRequest.AcceptedCapabilitiesEnum>? acceptedCapabilities = default,
            bool? automaticallyManageNewDevices = default,
            string connectedAccountId = default,
            object? customMetadata = default
        )
        {
            await UpdateAsync(
                new UpdateRequest(
                    acceptedCapabilities: acceptedCapabilities,
                    automaticallyManageNewDevices: automaticallyManageNewDevices,
                    connectedAccountId: connectedAccountId,
                    customMetadata: customMetadata
                )
            );
        }
    }
}

namespace Seam.Client
{
    public partial class SeamClient
    {
        public Api.ConnectedAccounts ConnectedAccounts => new(this);
    }

    public partial interface ISeamClient
    {
        public Api.ConnectedAccounts ConnectedAccounts { get; }
    }
}
