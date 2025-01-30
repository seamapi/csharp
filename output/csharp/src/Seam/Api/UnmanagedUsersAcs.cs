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
    public class UnmanagedUsersAcs
    {
        private ISeamClient _seam;

        public UnmanagedUsersAcs(ISeamClient seam)
        {
            _seam = seam;
        }

        [DataContract(Name = "getRequest_request")]
        public class GetRequest
        {
            [JsonConstructorAttribute]
            protected GetRequest() { }

            public GetRequest(string acsUserId = default)
            {
                AcsUserId = acsUserId;
            }

            [DataMember(Name = "acs_user_id", IsRequired = true, EmitDefaultValue = false)]
            public string AcsUserId { get; set; }

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

            public GetResponse(UnmanagedAcsUser acsUser = default)
            {
                AcsUser = acsUser;
            }

            [DataMember(Name = "acs_user", IsRequired = false, EmitDefaultValue = false)]
            public UnmanagedAcsUser AcsUser { get; set; }

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

        public UnmanagedAcsUser Get(GetRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            return _seam.Post<GetResponse>("/acs/users/unmanaged/get", requestOptions).Data.AcsUser;
        }

        public UnmanagedAcsUser Get(string acsUserId = default)
        {
            return Get(new GetRequest(acsUserId: acsUserId));
        }

        public async Task<UnmanagedAcsUser> GetAsync(GetRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            return (await _seam.PostAsync<GetResponse>("/acs/users/unmanaged/get", requestOptions))
                .Data
                .AcsUser;
        }

        public async Task<UnmanagedAcsUser> GetAsync(string acsUserId = default)
        {
            return (await GetAsync(new GetRequest(acsUserId: acsUserId)));
        }

        [DataContract(Name = "listRequest_request")]
        public class ListRequest
        {
            [JsonConstructorAttribute]
            protected ListRequest() { }

            public ListRequest(
                string? acsSystemId = default,
                float? limit = default,
                string? userIdentityEmailAddress = default,
                string? userIdentityId = default,
                string? userIdentityPhoneNumber = default
            )
            {
                AcsSystemId = acsSystemId;
                Limit = limit;
                UserIdentityEmailAddress = userIdentityEmailAddress;
                UserIdentityId = userIdentityId;
                UserIdentityPhoneNumber = userIdentityPhoneNumber;
            }

            [DataMember(Name = "acs_system_id", IsRequired = false, EmitDefaultValue = false)]
            public string? AcsSystemId { get; set; }

            [DataMember(Name = "limit", IsRequired = false, EmitDefaultValue = false)]
            public float? Limit { get; set; }

            [DataMember(
                Name = "user_identity_email_address",
                IsRequired = false,
                EmitDefaultValue = false
            )]
            public string? UserIdentityEmailAddress { get; set; }

            [DataMember(Name = "user_identity_id", IsRequired = false, EmitDefaultValue = false)]
            public string? UserIdentityId { get; set; }

            [DataMember(
                Name = "user_identity_phone_number",
                IsRequired = false,
                EmitDefaultValue = false
            )]
            public string? UserIdentityPhoneNumber { get; set; }

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

            public ListResponse(List<UnmanagedAcsUser> acsUsers = default)
            {
                AcsUsers = acsUsers;
            }

            [DataMember(Name = "acs_users", IsRequired = false, EmitDefaultValue = false)]
            public List<UnmanagedAcsUser> AcsUsers { get; set; }

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

        public List<UnmanagedAcsUser> List(ListRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            return _seam
                .Post<ListResponse>("/acs/users/unmanaged/list", requestOptions)
                .Data.AcsUsers;
        }

        public List<UnmanagedAcsUser> List(
            string? acsSystemId = default,
            float? limit = default,
            string? userIdentityEmailAddress = default,
            string? userIdentityId = default,
            string? userIdentityPhoneNumber = default
        )
        {
            return List(
                new ListRequest(
                    acsSystemId: acsSystemId,
                    limit: limit,
                    userIdentityEmailAddress: userIdentityEmailAddress,
                    userIdentityId: userIdentityId,
                    userIdentityPhoneNumber: userIdentityPhoneNumber
                )
            );
        }

        public async Task<List<UnmanagedAcsUser>> ListAsync(ListRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            return (
                await _seam.PostAsync<ListResponse>("/acs/users/unmanaged/list", requestOptions)
            )
                .Data
                .AcsUsers;
        }

        public async Task<List<UnmanagedAcsUser>> ListAsync(
            string? acsSystemId = default,
            float? limit = default,
            string? userIdentityEmailAddress = default,
            string? userIdentityId = default,
            string? userIdentityPhoneNumber = default
        )
        {
            return (
                await ListAsync(
                    new ListRequest(
                        acsSystemId: acsSystemId,
                        limit: limit,
                        userIdentityEmailAddress: userIdentityEmailAddress,
                        userIdentityId: userIdentityId,
                        userIdentityPhoneNumber: userIdentityPhoneNumber
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
        public Api.UnmanagedUsersAcs UnmanagedUsersAcs => new(this);
    }

    public partial interface ISeamClient
    {
        public Api.UnmanagedUsersAcs UnmanagedUsersAcs { get; }
    }
}
