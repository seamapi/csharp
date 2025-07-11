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
    public class EntrancesAcs
    {
        private ISeamClient _seam;

        public EntrancesAcs(ISeamClient seam)
        {
            _seam = seam;
        }

        [DataContract(Name = "getRequest_request")]
        public class GetRequest
        {
            [JsonConstructorAttribute]
            protected GetRequest() { }

            public GetRequest(string acsEntranceId = default)
            {
                AcsEntranceId = acsEntranceId;
            }

            [DataMember(Name = "acs_entrance_id", IsRequired = true, EmitDefaultValue = false)]
            public string AcsEntranceId { get; set; }

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

            public GetResponse(AcsEntrance acsEntrance = default)
            {
                AcsEntrance = acsEntrance;
            }

            [DataMember(Name = "acs_entrance", IsRequired = false, EmitDefaultValue = false)]
            public AcsEntrance AcsEntrance { get; set; }

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

        public AcsEntrance Get(GetRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            return _seam.Post<GetResponse>("/acs/entrances/get", requestOptions).Data.AcsEntrance;
        }

        public AcsEntrance Get(string acsEntranceId = default)
        {
            return Get(new GetRequest(acsEntranceId: acsEntranceId));
        }

        public async Task<AcsEntrance> GetAsync(GetRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            return (await _seam.PostAsync<GetResponse>("/acs/entrances/get", requestOptions))
                .Data
                .AcsEntrance;
        }

        public async Task<AcsEntrance> GetAsync(string acsEntranceId = default)
        {
            return (await GetAsync(new GetRequest(acsEntranceId: acsEntranceId)));
        }

        [DataContract(Name = "grantAccessRequest_request")]
        public class GrantAccessRequest
        {
            [JsonConstructorAttribute]
            protected GrantAccessRequest() { }

            public GrantAccessRequest(
                string acsEntranceId = default,
                string? acsUserId = default,
                string? userIdentityId = default
            )
            {
                AcsEntranceId = acsEntranceId;
                AcsUserId = acsUserId;
                UserIdentityId = userIdentityId;
            }

            [DataMember(Name = "acs_entrance_id", IsRequired = true, EmitDefaultValue = false)]
            public string AcsEntranceId { get; set; }

            [DataMember(Name = "acs_user_id", IsRequired = false, EmitDefaultValue = false)]
            public string? AcsUserId { get; set; }

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

        public void GrantAccess(GrantAccessRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            _seam.Post<object>("/acs/entrances/grant_access", requestOptions);
        }

        public void GrantAccess(
            string acsEntranceId = default,
            string? acsUserId = default,
            string? userIdentityId = default
        )
        {
            GrantAccess(
                new GrantAccessRequest(
                    acsEntranceId: acsEntranceId,
                    acsUserId: acsUserId,
                    userIdentityId: userIdentityId
                )
            );
        }

        public async Task GrantAccessAsync(GrantAccessRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            await _seam.PostAsync<object>("/acs/entrances/grant_access", requestOptions);
        }

        public async Task GrantAccessAsync(
            string acsEntranceId = default,
            string? acsUserId = default,
            string? userIdentityId = default
        )
        {
            await GrantAccessAsync(
                new GrantAccessRequest(
                    acsEntranceId: acsEntranceId,
                    acsUserId: acsUserId,
                    userIdentityId: userIdentityId
                )
            );
        }

        [DataContract(Name = "listRequest_request")]
        public class ListRequest
        {
            [JsonConstructorAttribute]
            protected ListRequest() { }

            public ListRequest(
                string? accessGrantId = default,
                string? accessMethodId = default,
                string? acsCredentialId = default,
                List<string>? acsEntranceIds = default,
                string? acsSystemId = default,
                string? connectedAccountId = default,
                string? locationId = default,
                string? search = default,
                string? spaceId = default
            )
            {
                AccessGrantId = accessGrantId;
                AccessMethodId = accessMethodId;
                AcsCredentialId = acsCredentialId;
                AcsEntranceIds = acsEntranceIds;
                AcsSystemId = acsSystemId;
                ConnectedAccountId = connectedAccountId;
                LocationId = locationId;
                Search = search;
                SpaceId = spaceId;
            }

            [DataMember(Name = "access_grant_id", IsRequired = false, EmitDefaultValue = false)]
            public string? AccessGrantId { get; set; }

            [DataMember(Name = "access_method_id", IsRequired = false, EmitDefaultValue = false)]
            public string? AccessMethodId { get; set; }

            [DataMember(Name = "acs_credential_id", IsRequired = false, EmitDefaultValue = false)]
            public string? AcsCredentialId { get; set; }

            [DataMember(Name = "acs_entrance_ids", IsRequired = false, EmitDefaultValue = false)]
            public List<string>? AcsEntranceIds { get; set; }

            [DataMember(Name = "acs_system_id", IsRequired = false, EmitDefaultValue = false)]
            public string? AcsSystemId { get; set; }

            [DataMember(
                Name = "connected_account_id",
                IsRequired = false,
                EmitDefaultValue = false
            )]
            public string? ConnectedAccountId { get; set; }

            [DataMember(Name = "location_id", IsRequired = false, EmitDefaultValue = false)]
            public string? LocationId { get; set; }

            [DataMember(Name = "search", IsRequired = false, EmitDefaultValue = false)]
            public string? Search { get; set; }

            [DataMember(Name = "space_id", IsRequired = false, EmitDefaultValue = false)]
            public string? SpaceId { get; set; }

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

            public ListResponse(List<AcsEntrance> acsEntrances = default)
            {
                AcsEntrances = acsEntrances;
            }

            [DataMember(Name = "acs_entrances", IsRequired = false, EmitDefaultValue = false)]
            public List<AcsEntrance> AcsEntrances { get; set; }

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

        public List<AcsEntrance> List(ListRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            return _seam
                .Post<ListResponse>("/acs/entrances/list", requestOptions)
                .Data.AcsEntrances;
        }

        public List<AcsEntrance> List(
            string? accessGrantId = default,
            string? accessMethodId = default,
            string? acsCredentialId = default,
            List<string>? acsEntranceIds = default,
            string? acsSystemId = default,
            string? connectedAccountId = default,
            string? locationId = default,
            string? search = default,
            string? spaceId = default
        )
        {
            return List(
                new ListRequest(
                    accessGrantId: accessGrantId,
                    accessMethodId: accessMethodId,
                    acsCredentialId: acsCredentialId,
                    acsEntranceIds: acsEntranceIds,
                    acsSystemId: acsSystemId,
                    connectedAccountId: connectedAccountId,
                    locationId: locationId,
                    search: search,
                    spaceId: spaceId
                )
            );
        }

        public async Task<List<AcsEntrance>> ListAsync(ListRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            return (await _seam.PostAsync<ListResponse>("/acs/entrances/list", requestOptions))
                .Data
                .AcsEntrances;
        }

        public async Task<List<AcsEntrance>> ListAsync(
            string? accessGrantId = default,
            string? accessMethodId = default,
            string? acsCredentialId = default,
            List<string>? acsEntranceIds = default,
            string? acsSystemId = default,
            string? connectedAccountId = default,
            string? locationId = default,
            string? search = default,
            string? spaceId = default
        )
        {
            return (
                await ListAsync(
                    new ListRequest(
                        accessGrantId: accessGrantId,
                        accessMethodId: accessMethodId,
                        acsCredentialId: acsCredentialId,
                        acsEntranceIds: acsEntranceIds,
                        acsSystemId: acsSystemId,
                        connectedAccountId: connectedAccountId,
                        locationId: locationId,
                        search: search,
                        spaceId: spaceId
                    )
                )
            );
        }

        [DataContract(Name = "listCredentialsWithAccessRequest_request")]
        public class ListCredentialsWithAccessRequest
        {
            [JsonConstructorAttribute]
            protected ListCredentialsWithAccessRequest() { }

            public ListCredentialsWithAccessRequest(
                string acsEntranceId = default,
                List<ListCredentialsWithAccessRequest.IncludeIfEnum>? includeIf = default
            )
            {
                AcsEntranceId = acsEntranceId;
                IncludeIf = includeIf;
            }

            [JsonConverter(typeof(SafeStringEnumConverter))]
            public enum IncludeIfEnum
            {
                [EnumMember(Value = "unrecognized")]
                Unrecognized = 0,

                [EnumMember(Value = "visionline_metadata.is_valid")]
                VisionlineMetadataIsValid = 1,
            }

            [DataMember(Name = "acs_entrance_id", IsRequired = true, EmitDefaultValue = false)]
            public string AcsEntranceId { get; set; }

            [DataMember(Name = "include_if", IsRequired = false, EmitDefaultValue = false)]
            public List<ListCredentialsWithAccessRequest.IncludeIfEnum>? IncludeIf { get; set; }

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

        [DataContract(Name = "listCredentialsWithAccessResponse_response")]
        public class ListCredentialsWithAccessResponse
        {
            [JsonConstructorAttribute]
            protected ListCredentialsWithAccessResponse() { }

            public ListCredentialsWithAccessResponse(List<AcsCredential> acsCredentials = default)
            {
                AcsCredentials = acsCredentials;
            }

            [DataMember(Name = "acs_credentials", IsRequired = false, EmitDefaultValue = false)]
            public List<AcsCredential> AcsCredentials { get; set; }

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

        public List<AcsCredential> ListCredentialsWithAccess(
            ListCredentialsWithAccessRequest request
        )
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            return _seam
                .Post<ListCredentialsWithAccessResponse>(
                    "/acs/entrances/list_credentials_with_access",
                    requestOptions
                )
                .Data.AcsCredentials;
        }

        public List<AcsCredential> ListCredentialsWithAccess(
            string acsEntranceId = default,
            List<ListCredentialsWithAccessRequest.IncludeIfEnum>? includeIf = default
        )
        {
            return ListCredentialsWithAccess(
                new ListCredentialsWithAccessRequest(
                    acsEntranceId: acsEntranceId,
                    includeIf: includeIf
                )
            );
        }

        public async Task<List<AcsCredential>> ListCredentialsWithAccessAsync(
            ListCredentialsWithAccessRequest request
        )
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            return (
                await _seam.PostAsync<ListCredentialsWithAccessResponse>(
                    "/acs/entrances/list_credentials_with_access",
                    requestOptions
                )
            )
                .Data
                .AcsCredentials;
        }

        public async Task<List<AcsCredential>> ListCredentialsWithAccessAsync(
            string acsEntranceId = default,
            List<ListCredentialsWithAccessRequest.IncludeIfEnum>? includeIf = default
        )
        {
            return (
                await ListCredentialsWithAccessAsync(
                    new ListCredentialsWithAccessRequest(
                        acsEntranceId: acsEntranceId,
                        includeIf: includeIf
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
        public Api.EntrancesAcs EntrancesAcs => new(this);
    }

    public partial interface ISeamClient
    {
        public Api.EntrancesAcs EntrancesAcs { get; }
    }
}
