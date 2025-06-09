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
    public class AccessGrants
    {
        private ISeamClient _seam;

        public AccessGrants(ISeamClient seam)
        {
            _seam = seam;
        }

        [DataContract(Name = "deleteRequest_request")]
        public class DeleteRequest
        {
            [JsonConstructorAttribute]
            protected DeleteRequest() { }

            public DeleteRequest(string accessGrantId = default)
            {
                AccessGrantId = accessGrantId;
            }

            [DataMember(Name = "access_grant_id", IsRequired = true, EmitDefaultValue = false)]
            public string AccessGrantId { get; set; }

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
            _seam.Post<object>("/access_grants/delete", requestOptions);
        }

        public void Delete(string accessGrantId = default)
        {
            Delete(new DeleteRequest(accessGrantId: accessGrantId));
        }

        public async Task DeleteAsync(DeleteRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            await _seam.PostAsync<object>("/access_grants/delete", requestOptions);
        }

        public async Task DeleteAsync(string accessGrantId = default)
        {
            await DeleteAsync(new DeleteRequest(accessGrantId: accessGrantId));
        }
    }
}

namespace Seam.Client
{
    public partial class SeamClient
    {
        public Api.AccessGrants AccessGrants => new(this);
    }

    public partial interface ISeamClient
    {
        public Api.AccessGrants AccessGrants { get; }
    }
}
