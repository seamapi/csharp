using System.Runtime.Serialization;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using JsonSubTypes;
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
            public ListRequest() { }

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

        public List<ConnectedAccount> List()
        {
            return List(new ListRequest());
        }

        public async Task<List<ConnectedAccount>> ListAsync(ListRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            return (await _seam.PostAsync<ListResponse>("/connected_accounts/list", requestOptions))
                .Data
                .ConnectedAccounts;
        }

        public async Task<List<ConnectedAccount>> ListAsync()
        {
            return (await ListAsync(new ListRequest()));
        }

        [DataContract(Name = "updateRequest_request")]
        public class UpdateRequest
        {
            [JsonConstructorAttribute]
            protected UpdateRequest() { }

            public UpdateRequest(
                string connectedAccountId = default,
                bool? automaticallyManageNewDevices = default
            )
            {
                ConnectedAccountId = connectedAccountId;
                AutomaticallyManageNewDevices = automaticallyManageNewDevices;
            }

            [DataMember(Name = "connected_account_id", IsRequired = true, EmitDefaultValue = false)]
            public string ConnectedAccountId { get; set; }

            [DataMember(
                Name = "automatically_manage_new_devices",
                IsRequired = false,
                EmitDefaultValue = false
            )]
            public bool? AutomaticallyManageNewDevices { get; set; }

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

        [DataContract(Name = "updateResponse_response")]
        public class UpdateResponse
        {
            [JsonConstructorAttribute]
            protected UpdateResponse() { }

            public UpdateResponse(ConnectedAccount connectedAccount = default)
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

        public ConnectedAccount Update(UpdateRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            return _seam
                .Post<UpdateResponse>("/connected_accounts/update", requestOptions)
                .Data.ConnectedAccount;
        }

        public ConnectedAccount Update(
            string connectedAccountId = default,
            bool? automaticallyManageNewDevices = default
        )
        {
            return Update(
                new UpdateRequest(
                    connectedAccountId: connectedAccountId,
                    automaticallyManageNewDevices: automaticallyManageNewDevices
                )
            );
        }

        public async Task<ConnectedAccount> UpdateAsync(UpdateRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            return (
                await _seam.PostAsync<UpdateResponse>("/connected_accounts/update", requestOptions)
            )
                .Data
                .ConnectedAccount;
        }

        public async Task<ConnectedAccount> UpdateAsync(
            string connectedAccountId = default,
            bool? automaticallyManageNewDevices = default
        )
        {
            return (
                await UpdateAsync(
                    new UpdateRequest(
                        connectedAccountId: connectedAccountId,
                        automaticallyManageNewDevices: automaticallyManageNewDevices
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
        public Api.ConnectedAccounts ConnectedAccounts => new(this);
    }

    public partial interface ISeamClient
    {
        public Api.ConnectedAccounts ConnectedAccounts { get; }
    }
}
