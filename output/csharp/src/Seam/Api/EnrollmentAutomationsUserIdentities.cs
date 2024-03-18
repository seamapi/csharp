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
    public class EnrollmentAutomationsUserIdentities
    {
        private ISeamClient _seam;

        public EnrollmentAutomationsUserIdentities(ISeamClient seam)
        {
            _seam = seam;
        }

        [DataContract(Name = "deleteRequest_request")]
        public class DeleteRequest
        {
            [JsonConstructorAttribute]
            protected DeleteRequest() { }

            public DeleteRequest(string enrollmentAutomationId = default)
            {
                EnrollmentAutomationId = enrollmentAutomationId;
            }

            [DataMember(
                Name = "enrollment_automation_id",
                IsRequired = true,
                EmitDefaultValue = false
            )]
            public string EnrollmentAutomationId { get; set; }

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
            _seam.Post<object>("/user_identities/enrollment_automations/delete", requestOptions);
        }

        public void Delete(string enrollmentAutomationId = default)
        {
            Delete(new DeleteRequest(enrollmentAutomationId: enrollmentAutomationId));
        }

        public async Task DeleteAsync(DeleteRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            await _seam.PostAsync<object>(
                "/user_identities/enrollment_automations/delete",
                requestOptions
            );
        }

        public async Task DeleteAsync(string enrollmentAutomationId = default)
        {
            await DeleteAsync(new DeleteRequest(enrollmentAutomationId: enrollmentAutomationId));
        }
    }
}

namespace Seam.Client
{
    public partial class SeamClient
    {
        public Api.EnrollmentAutomationsUserIdentities EnrollmentAutomationsUserIdentities =>
            new(this);
    }

    public partial interface ISeamClient
    {
        public Api.EnrollmentAutomationsUserIdentities EnrollmentAutomationsUserIdentities { get; }
    }
}
