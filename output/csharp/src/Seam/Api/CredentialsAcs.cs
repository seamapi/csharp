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
    public class CredentialsAcs
    {
        private ISeamClient _seam;

        public CredentialsAcs(ISeamClient seam)
        {
            _seam = seam;
        }

        [DataContract(Name = "deleteRequest_request")]
        public class DeleteRequest
        {
            [JsonConstructorAttribute]
            protected DeleteRequest() { }

            public DeleteRequest(string acsCredentialId = default)
            {
                AcsCredentialId = acsCredentialId;
            }

            [DataMember(Name = "acs_credential_id", IsRequired = true, EmitDefaultValue = false)]
            public string AcsCredentialId { get; set; }

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
            _seam.Post<object>("/acs/credentials/delete", requestOptions);
        }

        public void Delete(string acsCredentialId = default)
        {
            Delete(new DeleteRequest(acsCredentialId: acsCredentialId));
        }

        public async Task DeleteAsync(DeleteRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            await _seam.PostAsync<object>("/acs/credentials/delete", requestOptions);
        }

        public async Task DeleteAsync(string acsCredentialId = default)
        {
            await DeleteAsync(new DeleteRequest(acsCredentialId: acsCredentialId));
        }
    }
}

namespace Seam.Client
{
    public partial class SeamClient
    {
        public Api.CredentialsAcs CredentialsAcs => new(this);
    }

    public partial interface ISeamClient
    {
        public Api.CredentialsAcs CredentialsAcs { get; }
    }
}
