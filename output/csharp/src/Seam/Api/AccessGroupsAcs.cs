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
    public class AccessGroupsAcs
    {
        private ISeamClient _seam;

        public AccessGroupsAcs(ISeamClient seam)
        {
            _seam = seam;
        }

        [DataContract(Name = "addUserRequest_request")]
        public class AddUserRequest
        {
            [JsonConstructorAttribute]
            protected AddUserRequest() { }

            public AddUserRequest(string acsAccessGroupId = default, string acsUserId = default)
            {
                AcsAccessGroupId = acsAccessGroupId;
                AcsUserId = acsUserId;
            }

            [DataMember(Name = "acs_access_group_id", IsRequired = true, EmitDefaultValue = false)]
            public string AcsAccessGroupId { get; set; }

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

        public void AddUser(AddUserRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            _seam.Post<object>("/acs/access_groups/add_user", requestOptions);
        }

        public void AddUser(string acsAccessGroupId = default, string acsUserId = default)
        {
            AddUser(new AddUserRequest(acsAccessGroupId: acsAccessGroupId, acsUserId: acsUserId));
        }

        public async Task AddUserAsync(AddUserRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            await _seam.PostAsync<object>("/acs/access_groups/add_user", requestOptions);
        }

        public async Task AddUserAsync(
            string acsAccessGroupId = default,
            string acsUserId = default
        )
        {
            await AddUserAsync(
                new AddUserRequest(acsAccessGroupId: acsAccessGroupId, acsUserId: acsUserId)
            );
        }

        [DataContract(Name = "getRequest_request")]
        public class GetRequest
        {
            [JsonConstructorAttribute]
            protected GetRequest() { }

            public GetRequest(string acsAccessGroupId = default)
            {
                AcsAccessGroupId = acsAccessGroupId;
            }

            [DataMember(Name = "acs_access_group_id", IsRequired = true, EmitDefaultValue = false)]
            public string AcsAccessGroupId { get; set; }

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

            public GetResponse(AcsAccessGroup acsAccessGroup = default)
            {
                AcsAccessGroup = acsAccessGroup;
            }

            [DataMember(Name = "acs_access_group", IsRequired = false, EmitDefaultValue = false)]
            public AcsAccessGroup AcsAccessGroup { get; set; }

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

        public AcsAccessGroup Get(GetRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            return _seam
                .Post<GetResponse>("/acs/access_groups/get", requestOptions)
                .Data.AcsAccessGroup;
        }

        public AcsAccessGroup Get(string acsAccessGroupId = default)
        {
            return Get(new GetRequest(acsAccessGroupId: acsAccessGroupId));
        }

        public async Task<AcsAccessGroup> GetAsync(GetRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            return (await _seam.PostAsync<GetResponse>("/acs/access_groups/get", requestOptions))
                .Data
                .AcsAccessGroup;
        }

        public async Task<AcsAccessGroup> GetAsync(string acsAccessGroupId = default)
        {
            return (await GetAsync(new GetRequest(acsAccessGroupId: acsAccessGroupId)));
        }

        [DataContract(Name = "listRequest_request")]
        public class ListRequest
        {
            [JsonConstructorAttribute]
            protected ListRequest() { }

            public ListRequest(
                string? acsSystemId = default,
                string? acsUserId = default,
                string? userIdentityId = default
            )
            {
                AcsSystemId = acsSystemId;
                AcsUserId = acsUserId;
                UserIdentityId = userIdentityId;
            }

            [DataMember(Name = "acs_system_id", IsRequired = false, EmitDefaultValue = false)]
            public string? AcsSystemId { get; set; }

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

        [DataContract(Name = "listResponse_response")]
        public class ListResponse
        {
            [JsonConstructorAttribute]
            protected ListResponse() { }

            public ListResponse(List<AcsAccessGroup> acsAccessGroups = default)
            {
                AcsAccessGroups = acsAccessGroups;
            }

            [DataMember(Name = "acs_access_groups", IsRequired = false, EmitDefaultValue = false)]
            public List<AcsAccessGroup> AcsAccessGroups { get; set; }

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

        public List<AcsAccessGroup> List(ListRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            return _seam
                .Post<ListResponse>("/acs/access_groups/list", requestOptions)
                .Data.AcsAccessGroups;
        }

        public List<AcsAccessGroup> List(
            string? acsSystemId = default,
            string? acsUserId = default,
            string? userIdentityId = default
        )
        {
            return List(
                new ListRequest(
                    acsSystemId: acsSystemId,
                    acsUserId: acsUserId,
                    userIdentityId: userIdentityId
                )
            );
        }

        public async Task<List<AcsAccessGroup>> ListAsync(ListRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            return (await _seam.PostAsync<ListResponse>("/acs/access_groups/list", requestOptions))
                .Data
                .AcsAccessGroups;
        }

        public async Task<List<AcsAccessGroup>> ListAsync(
            string? acsSystemId = default,
            string? acsUserId = default,
            string? userIdentityId = default
        )
        {
            return (
                await ListAsync(
                    new ListRequest(
                        acsSystemId: acsSystemId,
                        acsUserId: acsUserId,
                        userIdentityId: userIdentityId
                    )
                )
            );
        }

        [DataContract(Name = "listAccessibleEntrancesRequest_request")]
        public class ListAccessibleEntrancesRequest
        {
            [JsonConstructorAttribute]
            protected ListAccessibleEntrancesRequest() { }

            public ListAccessibleEntrancesRequest(string acsAccessGroupId = default)
            {
                AcsAccessGroupId = acsAccessGroupId;
            }

            [DataMember(Name = "acs_access_group_id", IsRequired = true, EmitDefaultValue = false)]
            public string AcsAccessGroupId { get; set; }

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

        [DataContract(Name = "listAccessibleEntrancesResponse_response")]
        public class ListAccessibleEntrancesResponse
        {
            [JsonConstructorAttribute]
            protected ListAccessibleEntrancesResponse() { }

            public ListAccessibleEntrancesResponse(List<AcsEntrance> acsEntrances = default)
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

        public List<AcsEntrance> ListAccessibleEntrances(ListAccessibleEntrancesRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            return _seam
                .Post<ListAccessibleEntrancesResponse>(
                    "/acs/access_groups/list_accessible_entrances",
                    requestOptions
                )
                .Data.AcsEntrances;
        }

        public List<AcsEntrance> ListAccessibleEntrances(string acsAccessGroupId = default)
        {
            return ListAccessibleEntrances(
                new ListAccessibleEntrancesRequest(acsAccessGroupId: acsAccessGroupId)
            );
        }

        public async Task<List<AcsEntrance>> ListAccessibleEntrancesAsync(
            ListAccessibleEntrancesRequest request
        )
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            return (
                await _seam.PostAsync<ListAccessibleEntrancesResponse>(
                    "/acs/access_groups/list_accessible_entrances",
                    requestOptions
                )
            )
                .Data
                .AcsEntrances;
        }

        public async Task<List<AcsEntrance>> ListAccessibleEntrancesAsync(
            string acsAccessGroupId = default
        )
        {
            return (
                await ListAccessibleEntrancesAsync(
                    new ListAccessibleEntrancesRequest(acsAccessGroupId: acsAccessGroupId)
                )
            );
        }

        [DataContract(Name = "listUsersRequest_request")]
        public class ListUsersRequest
        {
            [JsonConstructorAttribute]
            protected ListUsersRequest() { }

            public ListUsersRequest(string acsAccessGroupId = default)
            {
                AcsAccessGroupId = acsAccessGroupId;
            }

            [DataMember(Name = "acs_access_group_id", IsRequired = true, EmitDefaultValue = false)]
            public string AcsAccessGroupId { get; set; }

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

        [DataContract(Name = "listUsersResponse_response")]
        public class ListUsersResponse
        {
            [JsonConstructorAttribute]
            protected ListUsersResponse() { }

            public ListUsersResponse(List<AcsUser> acsUsers = default)
            {
                AcsUsers = acsUsers;
            }

            [DataMember(Name = "acs_users", IsRequired = false, EmitDefaultValue = false)]
            public List<AcsUser> AcsUsers { get; set; }

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

        public List<AcsUser> ListUsers(ListUsersRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            return _seam
                .Post<ListUsersResponse>("/acs/access_groups/list_users", requestOptions)
                .Data.AcsUsers;
        }

        public List<AcsUser> ListUsers(string acsAccessGroupId = default)
        {
            return ListUsers(new ListUsersRequest(acsAccessGroupId: acsAccessGroupId));
        }

        public async Task<List<AcsUser>> ListUsersAsync(ListUsersRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            return (
                await _seam.PostAsync<ListUsersResponse>(
                    "/acs/access_groups/list_users",
                    requestOptions
                )
            )
                .Data
                .AcsUsers;
        }

        public async Task<List<AcsUser>> ListUsersAsync(string acsAccessGroupId = default)
        {
            return (await ListUsersAsync(new ListUsersRequest(acsAccessGroupId: acsAccessGroupId)));
        }

        [DataContract(Name = "removeUserRequest_request")]
        public class RemoveUserRequest
        {
            [JsonConstructorAttribute]
            protected RemoveUserRequest() { }

            public RemoveUserRequest(string acsAccessGroupId = default, string acsUserId = default)
            {
                AcsAccessGroupId = acsAccessGroupId;
                AcsUserId = acsUserId;
            }

            [DataMember(Name = "acs_access_group_id", IsRequired = true, EmitDefaultValue = false)]
            public string AcsAccessGroupId { get; set; }

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

        public void RemoveUser(RemoveUserRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            _seam.Post<object>("/acs/access_groups/remove_user", requestOptions);
        }

        public void RemoveUser(string acsAccessGroupId = default, string acsUserId = default)
        {
            RemoveUser(
                new RemoveUserRequest(acsAccessGroupId: acsAccessGroupId, acsUserId: acsUserId)
            );
        }

        public async Task RemoveUserAsync(RemoveUserRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            await _seam.PostAsync<object>("/acs/access_groups/remove_user", requestOptions);
        }

        public async Task RemoveUserAsync(
            string acsAccessGroupId = default,
            string acsUserId = default
        )
        {
            await RemoveUserAsync(
                new RemoveUserRequest(acsAccessGroupId: acsAccessGroupId, acsUserId: acsUserId)
            );
        }
    }
}

namespace Seam.Client
{
    public partial class SeamClient
    {
        public Api.AccessGroupsAcs AccessGroupsAcs => new(this);
    }

    public partial interface ISeamClient
    {
        public Api.AccessGroupsAcs AccessGroupsAcs { get; }
    }
}
