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
    public class AccessMethods
    {
        private ISeamClient _seam;

        public AccessMethods(ISeamClient seam)
        {
            _seam = seam;
        }

        [DataContract(Name = "deleteRequest_request")]
        public class DeleteRequest
        {
            [JsonConstructorAttribute]
            protected DeleteRequest() { }

            public DeleteRequest(string accessMethodId = default)
            {
                AccessMethodId = accessMethodId;
            }

            [DataMember(Name = "access_method_id", IsRequired = true, EmitDefaultValue = false)]
            public string AccessMethodId { get; set; }

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
            _seam.Post<object>("/access_methods/delete", requestOptions);
        }

        public void Delete(string accessMethodId = default)
        {
            Delete(new DeleteRequest(accessMethodId: accessMethodId));
        }

        public async Task DeleteAsync(DeleteRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            await _seam.PostAsync<object>("/access_methods/delete", requestOptions);
        }

        public async Task DeleteAsync(string accessMethodId = default)
        {
            await DeleteAsync(new DeleteRequest(accessMethodId: accessMethodId));
        }
    }
}

namespace Seam.Client
{
    public partial class SeamClient
    {
        public Api.AccessMethods AccessMethods => new(this);
    }

    public partial interface ISeamClient
    {
        public Api.AccessMethods AccessMethods { get; }
    }
}
