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
    public class UnmanagedCredentialsAcs
    {
        private ISeamClient _seam;

        public UnmanagedCredentialsAcs(ISeamClient seam)
        {
            _seam = seam;
        }

        [DataContract(Name = "getRequest_request")]
        public class GetRequest
        {
            [JsonConstructorAttribute]
            protected GetRequest() { }

            public GetRequest(string acsCredentialId = default)
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

        [DataContract(Name = "getResponse_response")]
        public class GetResponse
        {
            [JsonConstructorAttribute]
            protected GetResponse() { }

            public GetResponse(UnmanagedAcsCredential acsCredential = default)
            {
                AcsCredential = acsCredential;
            }

            [DataMember(Name = "acs_credential", IsRequired = false, EmitDefaultValue = false)]
            public UnmanagedAcsCredential AcsCredential { get; set; }

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

        public UnmanagedAcsCredential Get(GetRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            return _seam
                .Post<GetResponse>("/acs/credentials/unmanaged/get", requestOptions)
                .Data.AcsCredential;
        }

        public UnmanagedAcsCredential Get(string acsCredentialId = default)
        {
            return Get(new GetRequest(acsCredentialId: acsCredentialId));
        }

        public async Task<UnmanagedAcsCredential> GetAsync(GetRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            return (
                await _seam.PostAsync<GetResponse>("/acs/credentials/unmanaged/get", requestOptions)
            )
                .Data
                .AcsCredential;
        }

        public async Task<UnmanagedAcsCredential> GetAsync(string acsCredentialId = default)
        {
            return (await GetAsync(new GetRequest(acsCredentialId: acsCredentialId)));
        }

        [DataContract(Name = "listRequest_request")]
        public class ListRequest
        {
            [JsonConstructorAttribute]
            protected ListRequest() { }

            public ListRequest(
                string? acsUserId = default,
                string? acsSystemId = default,
                string? userIdentityId = default
            )
            {
                AcsUserId = acsUserId;
                AcsSystemId = acsSystemId;
                UserIdentityId = userIdentityId;
            }

            [DataMember(Name = "acs_user_id", IsRequired = false, EmitDefaultValue = false)]
            public string? AcsUserId { get; set; }

            [DataMember(Name = "acs_system_id", IsRequired = false, EmitDefaultValue = false)]
            public string? AcsSystemId { get; set; }

            [DataMember(Name = "user_identity_id", IsRequired = false, EmitDefaultValue = false)]
            public string? UserIdentityId { get; set; }

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

            public ListResponse(List<UnmanagedAcsCredential> acsCredentials = default)
            {
                AcsCredentials = acsCredentials;
            }

            [DataMember(Name = "acs_credentials", IsRequired = false, EmitDefaultValue = false)]
            public List<UnmanagedAcsCredential> AcsCredentials { get; set; }

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

        public List<UnmanagedAcsCredential> List(ListRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            return _seam
                .Post<ListResponse>("/acs/credentials/unmanaged/list", requestOptions)
                .Data.AcsCredentials;
        }

        public List<UnmanagedAcsCredential> List(
            string? acsUserId = default,
            string? acsSystemId = default,
            string? userIdentityId = default
        )
        {
            return List(
                new ListRequest(
                    acsUserId: acsUserId,
                    acsSystemId: acsSystemId,
                    userIdentityId: userIdentityId
                )
            );
        }

        public async Task<List<UnmanagedAcsCredential>> ListAsync(ListRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            return (
                await _seam.PostAsync<ListResponse>(
                    "/acs/credentials/unmanaged/list",
                    requestOptions
                )
            )
                .Data
                .AcsCredentials;
        }

        public async Task<List<UnmanagedAcsCredential>> ListAsync(
            string? acsUserId = default,
            string? acsSystemId = default,
            string? userIdentityId = default
        )
        {
            return (
                await ListAsync(
                    new ListRequest(
                        acsUserId: acsUserId,
                        acsSystemId: acsSystemId,
                        userIdentityId: userIdentityId
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
        public Api.UnmanagedCredentialsAcs UnmanagedCredentialsAcs => new(this);
    }

    public partial interface ISeamClient
    {
        public Api.UnmanagedCredentialsAcs UnmanagedCredentialsAcs { get; }
    }
}
