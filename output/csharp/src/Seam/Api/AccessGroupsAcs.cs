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

        /// <summary>
        /// Request parameters for Add an ACS User to an Access Group.
        /// </summary>
        [DataContract(Name = "addUserRequest_request")]
        public class AddUserRequest
        {
            [JsonConstructorAttribute]
            protected AddUserRequest() { }

            public AddUserRequest(
                string acsAccessGroupId = default,
                string? acsUserId = default,
                string? userIdentityId = default
            )
            {
                AcsAccessGroupId = acsAccessGroupId;
                AcsUserId = acsUserId;
                UserIdentityId = userIdentityId;
            }

            /// <summary>
            /// ID of the access group to which you want to add an access system user.
            /// </summary>
            [DataMember(Name = "acs_access_group_id", IsRequired = true, EmitDefaultValue = false)]
            public string AcsAccessGroupId { get; set; }

            /// <summary>
            /// ID of the access system user that you want to add to an access group. You can only provide one of acs_user_id or user_identity_id.
            /// </summary>
            [DataMember(Name = "acs_user_id", IsRequired = false, EmitDefaultValue = false)]
            public string? AcsUserId { get; set; }

            /// <summary>
            /// ID of the desired user identity that you want to add to an access group. You can only provide one of acs_user_id or user_identity_id. If the ACS system contains an ACS user with the same `email_address` or `phone_number` as the user identity that you specify, they are linked, and the access group membership belongs to the ACS user. If the ACS system does not have a corresponding ACS user, one is created.
            /// </summary>
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

        /// <summary>
        /// Adds a specified [access system user](https://docs.seam.co/low-level-apis/access-systems/user-management) to a specified [access group](https://docs.seam.co/low-level-apis/access-systems/user-management/assigning-users-to-access-groups).
        /// </summary>
        public void AddUser(AddUserRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            _seam.Post<object>("/acs/access_groups/add_user", requestOptions);
        }

        /// <summary>
        /// Adds a specified [access system user](https://docs.seam.co/low-level-apis/access-systems/user-management) to a specified [access group](https://docs.seam.co/low-level-apis/access-systems/user-management/assigning-users-to-access-groups).
        /// </summary>
        public void AddUser(
            string acsAccessGroupId = default,
            string? acsUserId = default,
            string? userIdentityId = default
        )
        {
            AddUser(
                new AddUserRequest(
                    acsAccessGroupId: acsAccessGroupId,
                    acsUserId: acsUserId,
                    userIdentityId: userIdentityId
                )
            );
        }

        /// <summary>
        /// Adds a specified [access system user](https://docs.seam.co/low-level-apis/access-systems/user-management) to a specified [access group](https://docs.seam.co/low-level-apis/access-systems/user-management/assigning-users-to-access-groups).
        /// </summary>
        public async Task AddUserAsync(AddUserRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            await _seam.PostAsync<object>("/acs/access_groups/add_user", requestOptions);
        }

        /// <summary>
        /// Adds a specified [access system user](https://docs.seam.co/low-level-apis/access-systems/user-management) to a specified [access group](https://docs.seam.co/low-level-apis/access-systems/user-management/assigning-users-to-access-groups).
        /// </summary>
        public async Task AddUserAsync(
            string acsAccessGroupId = default,
            string? acsUserId = default,
            string? userIdentityId = default
        )
        {
            await AddUserAsync(
                new AddUserRequest(
                    acsAccessGroupId: acsAccessGroupId,
                    acsUserId: acsUserId,
                    userIdentityId: userIdentityId
                )
            );
        }

        /// <summary>
        /// Request parameters for Delete an Access Group.
        /// </summary>
        [DataContract(Name = "deleteRequest_request")]
        public class DeleteRequest
        {
            [JsonConstructorAttribute]
            protected DeleteRequest() { }

            public DeleteRequest(string acsAccessGroupId = default)
            {
                AcsAccessGroupId = acsAccessGroupId;
            }

            /// <summary>
            /// ID of the access group that you want to delete.
            /// </summary>
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

        /// <summary>
        /// Deletes a specified [access group](https://docs.seam.co/low-level-apis/access-systems/user-management/assigning-users-to-access-groups).
        /// </summary>
        public void Delete(DeleteRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            _seam.Post<object>("/acs/access_groups/delete", requestOptions);
        }

        /// <summary>
        /// Deletes a specified [access group](https://docs.seam.co/low-level-apis/access-systems/user-management/assigning-users-to-access-groups).
        /// </summary>
        public void Delete(string acsAccessGroupId = default)
        {
            Delete(new DeleteRequest(acsAccessGroupId: acsAccessGroupId));
        }

        /// <summary>
        /// Deletes a specified [access group](https://docs.seam.co/low-level-apis/access-systems/user-management/assigning-users-to-access-groups).
        /// </summary>
        public async Task DeleteAsync(DeleteRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            await _seam.PostAsync<object>("/acs/access_groups/delete", requestOptions);
        }

        /// <summary>
        /// Deletes a specified [access group](https://docs.seam.co/low-level-apis/access-systems/user-management/assigning-users-to-access-groups).
        /// </summary>
        public async Task DeleteAsync(string acsAccessGroupId = default)
        {
            await DeleteAsync(new DeleteRequest(acsAccessGroupId: acsAccessGroupId));
        }

        /// <summary>
        /// Request parameters for Get an Access Group.
        /// </summary>
        [DataContract(Name = "getRequest_request")]
        public class GetRequest
        {
            [JsonConstructorAttribute]
            protected GetRequest() { }

            public GetRequest(string acsAccessGroupId = default)
            {
                AcsAccessGroupId = acsAccessGroupId;
            }

            /// <summary>
            /// ID of the access group that you want to get.
            /// </summary>
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

            /// <summary>
            /// OK
            /// </summary>
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

        /// <summary>
        /// Returns a specified [access group](https://docs.seam.co/low-level-apis/access-systems/user-management/assigning-users-to-access-groups).
        /// </summary>
        public AcsAccessGroup Get(GetRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            return _seam
                .Post<GetResponse>("/acs/access_groups/get", requestOptions)
                .EnsureData("/acs/access_groups/get")
                .AcsAccessGroup;
        }

        /// <summary>
        /// Returns a specified [access group](https://docs.seam.co/low-level-apis/access-systems/user-management/assigning-users-to-access-groups).
        /// </summary>
        public AcsAccessGroup Get(string acsAccessGroupId = default)
        {
            return Get(new GetRequest(acsAccessGroupId: acsAccessGroupId));
        }

        /// <summary>
        /// Returns a specified [access group](https://docs.seam.co/low-level-apis/access-systems/user-management/assigning-users-to-access-groups).
        /// </summary>
        public async Task<AcsAccessGroup> GetAsync(GetRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            return (await _seam.PostAsync<GetResponse>("/acs/access_groups/get", requestOptions))
                .EnsureData("/acs/access_groups/get")
                .AcsAccessGroup;
        }

        /// <summary>
        /// Returns a specified [access group](https://docs.seam.co/low-level-apis/access-systems/user-management/assigning-users-to-access-groups).
        /// </summary>
        public async Task<AcsAccessGroup> GetAsync(string acsAccessGroupId = default)
        {
            return (await GetAsync(new GetRequest(acsAccessGroupId: acsAccessGroupId)));
        }

        /// <summary>
        /// Request parameters for List Access Groups.
        /// </summary>
        [DataContract(Name = "listRequest_request")]
        public class ListRequest
        {
            [JsonConstructorAttribute]
            protected ListRequest() { }

            public ListRequest(
                string? acsSystemId = default,
                string? acsUserId = default,
                string? search = default,
                string? userIdentityId = default
            )
            {
                AcsSystemId = acsSystemId;
                AcsUserId = acsUserId;
                Search = search;
                UserIdentityId = userIdentityId;
            }

            /// <summary>
            /// ID of the access system for which you want to retrieve all access groups.
            /// </summary>
            [DataMember(Name = "acs_system_id", IsRequired = false, EmitDefaultValue = false)]
            public string? AcsSystemId { get; set; }

            /// <summary>
            /// ID of the access system user for which you want to retrieve all access groups.
            /// </summary>
            [DataMember(Name = "acs_user_id", IsRequired = false, EmitDefaultValue = false)]
            public string? AcsUserId { get; set; }

            /// <summary>
            /// String for which to search. Filters returned access groups to include all records that satisfy a partial match using `name` or `acs_access_group_id`.
            /// </summary>
            [DataMember(Name = "search", IsRequired = false, EmitDefaultValue = false)]
            public string? Search { get; set; }

            /// <summary>
            /// ID of the user identity for which you want to retrieve all access groups.
            /// </summary>
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

            /// <summary>
            /// OK
            /// </summary>
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

        /// <summary>
        /// Returns a list of all [access groups](https://docs.seam.co/low-level-apis/access-systems/user-management/assigning-users-to-access-groups).
        /// </summary>
        public List<AcsAccessGroup> List(ListRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            return _seam
                .Post<ListResponse>("/acs/access_groups/list", requestOptions)
                .EnsureData("/acs/access_groups/list")
                .AcsAccessGroups;
        }

        /// <summary>
        /// Returns a list of all [access groups](https://docs.seam.co/low-level-apis/access-systems/user-management/assigning-users-to-access-groups).
        /// </summary>
        public List<AcsAccessGroup> List(
            string? acsSystemId = default,
            string? acsUserId = default,
            string? search = default,
            string? userIdentityId = default
        )
        {
            return List(
                new ListRequest(
                    acsSystemId: acsSystemId,
                    acsUserId: acsUserId,
                    search: search,
                    userIdentityId: userIdentityId
                )
            );
        }

        /// <summary>
        /// Returns a list of all [access groups](https://docs.seam.co/low-level-apis/access-systems/user-management/assigning-users-to-access-groups).
        /// </summary>
        public async Task<List<AcsAccessGroup>> ListAsync(ListRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            return (await _seam.PostAsync<ListResponse>("/acs/access_groups/list", requestOptions))
                .EnsureData("/acs/access_groups/list")
                .AcsAccessGroups;
        }

        /// <summary>
        /// Returns a list of all [access groups](https://docs.seam.co/low-level-apis/access-systems/user-management/assigning-users-to-access-groups).
        /// </summary>
        public async Task<List<AcsAccessGroup>> ListAsync(
            string? acsSystemId = default,
            string? acsUserId = default,
            string? search = default,
            string? userIdentityId = default
        )
        {
            return (
                await ListAsync(
                    new ListRequest(
                        acsSystemId: acsSystemId,
                        acsUserId: acsUserId,
                        search: search,
                        userIdentityId: userIdentityId
                    )
                )
            );
        }

        /// <summary>
        /// Request parameters for List Entrances Accessible to an Access Group.
        /// </summary>
        [DataContract(Name = "listAccessibleEntrancesRequest_request")]
        public class ListAccessibleEntrancesRequest
        {
            [JsonConstructorAttribute]
            protected ListAccessibleEntrancesRequest() { }

            public ListAccessibleEntrancesRequest(string acsAccessGroupId = default)
            {
                AcsAccessGroupId = acsAccessGroupId;
            }

            /// <summary>
            /// ID of the access group for which you want to retrieve all accessible entrances.
            /// </summary>
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

            /// <summary>
            /// OK
            /// </summary>
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

        /// <summary>
        /// Returns a list of all accessible entrances for a specified [access group](https://docs.seam.co/low-level-apis/access-systems/user-management/assigning-users-to-access-groups).
        /// </summary>
        public List<AcsEntrance> ListAccessibleEntrances(ListAccessibleEntrancesRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            return _seam
                .Post<ListAccessibleEntrancesResponse>(
                    "/acs/access_groups/list_accessible_entrances",
                    requestOptions
                )
                .EnsureData("/acs/access_groups/list_accessible_entrances")
                .AcsEntrances;
        }

        /// <summary>
        /// Returns a list of all accessible entrances for a specified [access group](https://docs.seam.co/low-level-apis/access-systems/user-management/assigning-users-to-access-groups).
        /// </summary>
        public List<AcsEntrance> ListAccessibleEntrances(string acsAccessGroupId = default)
        {
            return ListAccessibleEntrances(
                new ListAccessibleEntrancesRequest(acsAccessGroupId: acsAccessGroupId)
            );
        }

        /// <summary>
        /// Returns a list of all accessible entrances for a specified [access group](https://docs.seam.co/low-level-apis/access-systems/user-management/assigning-users-to-access-groups).
        /// </summary>
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
                .EnsureData("/acs/access_groups/list_accessible_entrances")
                .AcsEntrances;
        }

        /// <summary>
        /// Returns a list of all accessible entrances for a specified [access group](https://docs.seam.co/low-level-apis/access-systems/user-management/assigning-users-to-access-groups).
        /// </summary>
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

        /// <summary>
        /// Request parameters for List ACS Users in an Access Group.
        /// </summary>
        [DataContract(Name = "listUsersRequest_request")]
        public class ListUsersRequest
        {
            [JsonConstructorAttribute]
            protected ListUsersRequest() { }

            public ListUsersRequest(string acsAccessGroupId = default)
            {
                AcsAccessGroupId = acsAccessGroupId;
            }

            /// <summary>
            /// ID of the access group for which you want to retrieve all access system users.
            /// </summary>
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

            /// <summary>
            /// OK
            /// </summary>
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

        /// <summary>
        /// Returns a list of all [access system users](https://docs.seam.co/low-level-apis/access-systems/user-management) in an [access group](https://docs.seam.co/low-level-apis/access-systems/user-management/assigning-users-to-access-groups).
        /// </summary>
        public List<AcsUser> ListUsers(ListUsersRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            return _seam
                .Post<ListUsersResponse>("/acs/access_groups/list_users", requestOptions)
                .EnsureData("/acs/access_groups/list_users")
                .AcsUsers;
        }

        /// <summary>
        /// Returns a list of all [access system users](https://docs.seam.co/low-level-apis/access-systems/user-management) in an [access group](https://docs.seam.co/low-level-apis/access-systems/user-management/assigning-users-to-access-groups).
        /// </summary>
        public List<AcsUser> ListUsers(string acsAccessGroupId = default)
        {
            return ListUsers(new ListUsersRequest(acsAccessGroupId: acsAccessGroupId));
        }

        /// <summary>
        /// Returns a list of all [access system users](https://docs.seam.co/low-level-apis/access-systems/user-management) in an [access group](https://docs.seam.co/low-level-apis/access-systems/user-management/assigning-users-to-access-groups).
        /// </summary>
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
                .EnsureData("/acs/access_groups/list_users")
                .AcsUsers;
        }

        /// <summary>
        /// Returns a list of all [access system users](https://docs.seam.co/low-level-apis/access-systems/user-management) in an [access group](https://docs.seam.co/low-level-apis/access-systems/user-management/assigning-users-to-access-groups).
        /// </summary>
        public async Task<List<AcsUser>> ListUsersAsync(string acsAccessGroupId = default)
        {
            return (await ListUsersAsync(new ListUsersRequest(acsAccessGroupId: acsAccessGroupId)));
        }

        /// <summary>
        /// Request parameters for Remove an ACS User from an Access Group.
        /// </summary>
        [DataContract(Name = "removeUserRequest_request")]
        public class RemoveUserRequest
        {
            [JsonConstructorAttribute]
            protected RemoveUserRequest() { }

            public RemoveUserRequest(
                string acsAccessGroupId = default,
                string? acsUserId = default,
                string? userIdentityId = default
            )
            {
                AcsAccessGroupId = acsAccessGroupId;
                AcsUserId = acsUserId;
                UserIdentityId = userIdentityId;
            }

            /// <summary>
            /// ID of the access group from which you want to remove an access system user.
            /// </summary>
            [DataMember(Name = "acs_access_group_id", IsRequired = true, EmitDefaultValue = false)]
            public string AcsAccessGroupId { get; set; }

            /// <summary>
            /// ID of the access system user that you want to remove from an access group.
            /// </summary>
            [DataMember(Name = "acs_user_id", IsRequired = false, EmitDefaultValue = false)]
            public string? AcsUserId { get; set; }

            /// <summary>
            /// ID of the user identity associated with the user that you want to remove from an access group.
            /// </summary>
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

        /// <summary>
        /// Removes a specified [access system user](https://docs.seam.co/low-level-apis/access-systems/user-management) from a specified [access group](https://docs.seam.co/low-level-apis/access-systems/user-management/assigning-users-to-access-groups).
        /// </summary>
        public void RemoveUser(RemoveUserRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            _seam.Post<object>("/acs/access_groups/remove_user", requestOptions);
        }

        /// <summary>
        /// Removes a specified [access system user](https://docs.seam.co/low-level-apis/access-systems/user-management) from a specified [access group](https://docs.seam.co/low-level-apis/access-systems/user-management/assigning-users-to-access-groups).
        /// </summary>
        public void RemoveUser(
            string acsAccessGroupId = default,
            string? acsUserId = default,
            string? userIdentityId = default
        )
        {
            RemoveUser(
                new RemoveUserRequest(
                    acsAccessGroupId: acsAccessGroupId,
                    acsUserId: acsUserId,
                    userIdentityId: userIdentityId
                )
            );
        }

        /// <summary>
        /// Removes a specified [access system user](https://docs.seam.co/low-level-apis/access-systems/user-management) from a specified [access group](https://docs.seam.co/low-level-apis/access-systems/user-management/assigning-users-to-access-groups).
        /// </summary>
        public async Task RemoveUserAsync(RemoveUserRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            await _seam.PostAsync<object>("/acs/access_groups/remove_user", requestOptions);
        }

        /// <summary>
        /// Removes a specified [access system user](https://docs.seam.co/low-level-apis/access-systems/user-management) from a specified [access group](https://docs.seam.co/low-level-apis/access-systems/user-management/assigning-users-to-access-groups).
        /// </summary>
        public async Task RemoveUserAsync(
            string acsAccessGroupId = default,
            string? acsUserId = default,
            string? userIdentityId = default
        )
        {
            await RemoveUserAsync(
                new RemoveUserRequest(
                    acsAccessGroupId: acsAccessGroupId,
                    acsUserId: acsUserId,
                    userIdentityId: userIdentityId
                )
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
