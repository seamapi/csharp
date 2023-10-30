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
    public class UnmanagedAccessCodes
    {
        private ISeamClient _seam;

        public UnmanagedAccessCodes(ISeamClient seam)
        {
            _seam = seam;
        }

        [DataContract(Name = "deleteRequest_request")]
        public class DeleteRequest
        {
            [JsonConstructorAttribute]
            protected DeleteRequest() { }

            public DeleteRequest(string accessCodeId = default, bool? sync = default)
            {
                AccessCodeId = accessCodeId;
                Sync = sync;
            }

            [DataMember(Name = "access_code_id", IsRequired = true, EmitDefaultValue = false)]
            public string AccessCodeId { get; set; }

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

        [DataContract(Name = "deleteResponse_response")]
        public class DeleteResponse
        {
            [JsonConstructorAttribute]
            protected DeleteResponse() { }

            public DeleteResponse(ActionAttempt actionAttempt = default)
            {
                ActionAttempt = actionAttempt;
            }

            [DataMember(Name = "action_attempt", IsRequired = false, EmitDefaultValue = false)]
            public ActionAttempt ActionAttempt { get; set; }

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

        public ActionAttempt Delete(DeleteRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            return _seam
                .Post<DeleteResponse>("/access_codes/unmanaged/delete", requestOptions)
                .Data.ActionAttempt;
        }

        public ActionAttempt Delete(string accessCodeId = default, bool? sync = default)
        {
            return Delete(new DeleteRequest(accessCodeId: accessCodeId, sync: sync));
        }

        public async Task<ActionAttempt> DeleteAsync(DeleteRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            return (
                await _seam.PostAsync<DeleteResponse>(
                    "/access_codes/unmanaged/delete",
                    requestOptions
                )
            )
                .Data
                .ActionAttempt;
        }

        public async Task<ActionAttempt> DeleteAsync(
            string accessCodeId = default,
            bool? sync = default
        )
        {
            return (await DeleteAsync(new DeleteRequest(accessCodeId: accessCodeId, sync: sync)));
        }
    }
}

namespace Seam.Client
{
    public partial class SeamClient
    {
        public Api.UnmanagedAccessCodes UnmanagedAccessCodes => new(this);
    }

    public partial interface ISeamClient
    {
        public Api.UnmanagedAccessCodes UnmanagedAccessCodes { get; }
    }
}
