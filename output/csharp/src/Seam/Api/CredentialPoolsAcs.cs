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
    public class CredentialPoolsAcs
    {
        private ISeamClient _seam;

        public CredentialPoolsAcs(ISeamClient seam)
        {
            _seam = seam;
        }

        [DataContract(Name = "listRequest_request")]
        public class ListRequest
        {
            [JsonConstructorAttribute]
            protected ListRequest() { }

            public ListRequest(string acsSystemId = default)
            {
                AcsSystemId = acsSystemId;
            }

            [DataMember(Name = "acs_system_id", IsRequired = true, EmitDefaultValue = false)]
            public string AcsSystemId { get; set; }

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

            public ListResponse(List<AcsCredentialPool> acsCredentialPools = default)
            {
                AcsCredentialPools = acsCredentialPools;
            }

            [DataMember(
                Name = "acs_credential_pools",
                IsRequired = false,
                EmitDefaultValue = false
            )]
            public List<AcsCredentialPool> AcsCredentialPools { get; set; }

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

        public List<AcsCredentialPool> List(ListRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            return _seam
                .Post<ListResponse>("/acs/credential_pools/list", requestOptions)
                .Data.AcsCredentialPools;
        }

        public List<AcsCredentialPool> List(string acsSystemId = default)
        {
            return List(new ListRequest(acsSystemId: acsSystemId));
        }

        public async Task<List<AcsCredentialPool>> ListAsync(ListRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            return (
                await _seam.PostAsync<ListResponse>("/acs/credential_pools/list", requestOptions)
            )
                .Data
                .AcsCredentialPools;
        }

        public async Task<List<AcsCredentialPool>> ListAsync(string acsSystemId = default)
        {
            return (await ListAsync(new ListRequest(acsSystemId: acsSystemId)));
        }
    }
}

namespace Seam.Client
{
    public partial class SeamClient
    {
        public Api.CredentialPoolsAcs CredentialPoolsAcs => new(this);
    }

    public partial interface ISeamClient
    {
        public Api.CredentialPoolsAcs CredentialPoolsAcs { get; }
    }
}
