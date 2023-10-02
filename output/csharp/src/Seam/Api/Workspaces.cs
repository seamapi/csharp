using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using JsonSubTypes;
using Seam.Client;
using Seam.Model;

namespace Seam.Api
{
    public class Workspaces
    {
        private ISeamClient _seam;

        public Workspaces(ISeamClient seam)
        {
            _seam = seam;
        }

        [DataContract(Name = "getRequest_request")]
        public class GetRequest
        {
            [JsonConstructorAttribute]
            public GetRequest() { }
        }

        [DataContract(Name = "getResponse_response")]
        public class GetResponse
        {
            [JsonConstructorAttribute]
            protected GetResponse() { }

            public GetResponse(Workspace? workspace = default)
            {
                Workspace = workspace;
            }

            [DataMember(Name = "workspace", IsRequired = false, EmitDefaultValue = false)]
            public Workspace? Workspace { get; set; }
        }

        public Workspace Get(GetRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            return _seam.Post<GetResponse>("/workspaces/get", requestOptions).Data.Workspace;
        }

        public Workspace Get()
        {
            return Get(new GetRequest());
        }

        public async Task<Workspace> GetAsync(GetRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            return (await _seam.PostAsync<GetResponse>("/workspaces/get", requestOptions))
                .Data
                .Workspace;
        }

        public async Task<Workspace> GetAsync()
        {
            return (await GetAsync(new GetRequest()));
        }
    }
}

namespace Seam.Client
{
    public partial class SeamClient
    {
        public Api.Workspaces Workspaces => new(this);
    }

    public partial interface ISeamClient
    {
        public Api.Workspaces Workspaces { get; }
    }
}
