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

        [DataContract(Name = "getRequest_request")]
        public class GetRequest
        {
            [JsonConstructorAttribute]
            protected GetRequest() { }

            public GetRequest(string enrollmentAutomationId = default)
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

        [DataContract(Name = "getResponse_response")]
        public class GetResponse
        {
            [JsonConstructorAttribute]
            protected GetResponse() { }

            public GetResponse(EnrollmentAutomation enrollmentAutomation = default)
            {
                EnrollmentAutomation = enrollmentAutomation;
            }

            [DataMember(
                Name = "enrollment_automation",
                IsRequired = false,
                EmitDefaultValue = false
            )]
            public EnrollmentAutomation EnrollmentAutomation { get; set; }

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

        public EnrollmentAutomation Get(GetRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            return _seam
                .Post<GetResponse>("/user_identities/enrollment_automations/get", requestOptions)
                .Data.EnrollmentAutomation;
        }

        public EnrollmentAutomation Get(string enrollmentAutomationId = default)
        {
            return Get(new GetRequest(enrollmentAutomationId: enrollmentAutomationId));
        }

        public async Task<EnrollmentAutomation> GetAsync(GetRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            return (
                await _seam.PostAsync<GetResponse>(
                    "/user_identities/enrollment_automations/get",
                    requestOptions
                )
            )
                .Data
                .EnrollmentAutomation;
        }

        public async Task<EnrollmentAutomation> GetAsync(string enrollmentAutomationId = default)
        {
            return (await GetAsync(new GetRequest(enrollmentAutomationId: enrollmentAutomationId)));
        }

        [DataContract(Name = "listRequest_request")]
        public class ListRequest
        {
            [JsonConstructorAttribute]
            protected ListRequest() { }

            public ListRequest(string userIdentityId = default)
            {
                UserIdentityId = userIdentityId;
            }

            [DataMember(Name = "user_identity_id", IsRequired = true, EmitDefaultValue = false)]
            public string UserIdentityId { get; set; }

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

            public ListResponse(List<EnrollmentAutomation> enrollmentAutomations = default)
            {
                EnrollmentAutomations = enrollmentAutomations;
            }

            [DataMember(
                Name = "enrollment_automations",
                IsRequired = false,
                EmitDefaultValue = false
            )]
            public List<EnrollmentAutomation> EnrollmentAutomations { get; set; }

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

        public List<EnrollmentAutomation> List(ListRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            return _seam
                .Post<ListResponse>("/user_identities/enrollment_automations/list", requestOptions)
                .Data.EnrollmentAutomations;
        }

        public List<EnrollmentAutomation> List(string userIdentityId = default)
        {
            return List(new ListRequest(userIdentityId: userIdentityId));
        }

        public async Task<List<EnrollmentAutomation>> ListAsync(ListRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            return (
                await _seam.PostAsync<ListResponse>(
                    "/user_identities/enrollment_automations/list",
                    requestOptions
                )
            )
                .Data
                .EnrollmentAutomations;
        }

        public async Task<List<EnrollmentAutomation>> ListAsync(string userIdentityId = default)
        {
            return (await ListAsync(new ListRequest(userIdentityId: userIdentityId)));
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
