using System.Runtime.Serialization;
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
        private ISeam _seam;

        public ConnectedAccounts(ISeam seam)
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
    }
}

namespace Seam.Client
{
    public partial class Seam
    {
        public Api.ConnectedAccounts ConnectedAccounts => new(this);
    }

    public partial interface ISeam
    {
        public Api.ConnectedAccounts ConnectedAccounts { get; }
    }
}
