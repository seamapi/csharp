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
    public class UsersAcs
    {
        private ISeamClient _seam;

        public UsersAcs(ISeamClient seam)
        {
            _seam = seam;
        }

        [DataContract(Name = "addToAccessGroupRequest_request")]
        public class AddToAccessGroupRequest
        {
            [JsonConstructorAttribute]
            protected AddToAccessGroupRequest() { }

            public AddToAccessGroupRequest(
                string acsAccessGroupId = default,
                string acsUserId = default
            )
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

        public void AddToAccessGroup(AddToAccessGroupRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            _seam.Post<object>("/acs/users/add_to_access_group", requestOptions);
        }

        public void AddToAccessGroup(string acsAccessGroupId = default, string acsUserId = default)
        {
            AddToAccessGroup(
                new AddToAccessGroupRequest(
                    acsAccessGroupId: acsAccessGroupId,
                    acsUserId: acsUserId
                )
            );
        }

        public async Task AddToAccessGroupAsync(AddToAccessGroupRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            await _seam.PostAsync<object>("/acs/users/add_to_access_group", requestOptions);
        }

        public async Task AddToAccessGroupAsync(
            string acsAccessGroupId = default,
            string acsUserId = default
        )
        {
            await AddToAccessGroupAsync(
                new AddToAccessGroupRequest(
                    acsAccessGroupId: acsAccessGroupId,
                    acsUserId: acsUserId
                )
            );
        }

        [DataContract(Name = "createRequest_request")]
        public class CreateRequest
        {
            [JsonConstructorAttribute]
            protected CreateRequest() { }

            public CreateRequest(
                CreateRequestAccessSchedule? accessSchedule = default,
                List<string>? acsAccessGroupIds = default,
                string acsSystemId = default,
                string? email = default,
                string? emailAddress = default,
                string fullName = default,
                string? phoneNumber = default,
                string? userIdentityId = default
            )
            {
                AccessSchedule = accessSchedule;
                AcsAccessGroupIds = acsAccessGroupIds;
                AcsSystemId = acsSystemId;
                Email = email;
                EmailAddress = emailAddress;
                FullName = fullName;
                PhoneNumber = phoneNumber;
                UserIdentityId = userIdentityId;
            }

            [DataMember(Name = "access_schedule", IsRequired = false, EmitDefaultValue = false)]
            public CreateRequestAccessSchedule? AccessSchedule { get; set; }

            [DataMember(
                Name = "acs_access_group_ids",
                IsRequired = false,
                EmitDefaultValue = false
            )]
            public List<string>? AcsAccessGroupIds { get; set; }

            [DataMember(Name = "acs_system_id", IsRequired = true, EmitDefaultValue = false)]
            public string AcsSystemId { get; set; }

            [DataMember(Name = "email", IsRequired = false, EmitDefaultValue = false)]
            public string? Email { get; set; }

            [DataMember(Name = "email_address", IsRequired = false, EmitDefaultValue = false)]
            public string? EmailAddress { get; set; }

            [DataMember(Name = "full_name", IsRequired = true, EmitDefaultValue = false)]
            public string FullName { get; set; }

            [DataMember(Name = "phone_number", IsRequired = false, EmitDefaultValue = false)]
            public string? PhoneNumber { get; set; }

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

        [DataContract(Name = "createRequestAccessSchedule_model")]
        public class CreateRequestAccessSchedule
        {
            [JsonConstructorAttribute]
            protected CreateRequestAccessSchedule() { }

            public CreateRequestAccessSchedule(string? endsAt = default, string? startsAt = default)
            {
                EndsAt = endsAt;
                StartsAt = startsAt;
            }

            [DataMember(Name = "ends_at", IsRequired = false, EmitDefaultValue = false)]
            public string? EndsAt { get; set; }

            [DataMember(Name = "starts_at", IsRequired = false, EmitDefaultValue = false)]
            public string? StartsAt { get; set; }

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

        [DataContract(Name = "createResponse_response")]
        public class CreateResponse
        {
            [JsonConstructorAttribute]
            protected CreateResponse() { }

            public CreateResponse(AcsUser acsUser = default)
            {
                AcsUser = acsUser;
            }

            [DataMember(Name = "acs_user", IsRequired = false, EmitDefaultValue = false)]
            public AcsUser AcsUser { get; set; }

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

        public AcsUser Create(CreateRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            return _seam.Post<CreateResponse>("/acs/users/create", requestOptions).Data.AcsUser;
        }

        public AcsUser Create(
            CreateRequestAccessSchedule? accessSchedule = default,
            List<string>? acsAccessGroupIds = default,
            string acsSystemId = default,
            string? email = default,
            string? emailAddress = default,
            string fullName = default,
            string? phoneNumber = default,
            string? userIdentityId = default
        )
        {
            return Create(
                new CreateRequest(
                    accessSchedule: accessSchedule,
                    acsAccessGroupIds: acsAccessGroupIds,
                    acsSystemId: acsSystemId,
                    email: email,
                    emailAddress: emailAddress,
                    fullName: fullName,
                    phoneNumber: phoneNumber,
                    userIdentityId: userIdentityId
                )
            );
        }

        public async Task<AcsUser> CreateAsync(CreateRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            return (await _seam.PostAsync<CreateResponse>("/acs/users/create", requestOptions))
                .Data
                .AcsUser;
        }

        public async Task<AcsUser> CreateAsync(
            CreateRequestAccessSchedule? accessSchedule = default,
            List<string>? acsAccessGroupIds = default,
            string acsSystemId = default,
            string? email = default,
            string? emailAddress = default,
            string fullName = default,
            string? phoneNumber = default,
            string? userIdentityId = default
        )
        {
            return (
                await CreateAsync(
                    new CreateRequest(
                        accessSchedule: accessSchedule,
                        acsAccessGroupIds: acsAccessGroupIds,
                        acsSystemId: acsSystemId,
                        email: email,
                        emailAddress: emailAddress,
                        fullName: fullName,
                        phoneNumber: phoneNumber,
                        userIdentityId: userIdentityId
                    )
                )
            );
        }

        [DataContract(Name = "deleteRequest_request")]
        public class DeleteRequest
        {
            [JsonConstructorAttribute]
            protected DeleteRequest() { }

            public DeleteRequest(string acsUserId = default)
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

        public void Delete(DeleteRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            _seam.Post<object>("/acs/users/delete", requestOptions);
        }

        public void Delete(string acsUserId = default)
        {
            Delete(new DeleteRequest(acsUserId: acsUserId));
        }

        public async Task DeleteAsync(DeleteRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            await _seam.PostAsync<object>("/acs/users/delete", requestOptions);
        }

        public async Task DeleteAsync(string acsUserId = default)
        {
            await DeleteAsync(new DeleteRequest(acsUserId: acsUserId));
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

            public GetResponse(AcsUser acsUser = default)
            {
                AcsUser = acsUser;
            }

            [DataMember(Name = "acs_user", IsRequired = false, EmitDefaultValue = false)]
            public AcsUser AcsUser { get; set; }

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

        public AcsUser Get(GetRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            return _seam.Post<GetResponse>("/acs/users/get", requestOptions).Data.AcsUser;
        }

        public AcsUser Get(string acsUserId = default)
        {
            return Get(new GetRequest(acsUserId: acsUserId));
        }

        public async Task<AcsUser> GetAsync(GetRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            return (await _seam.PostAsync<GetResponse>("/acs/users/get", requestOptions))
                .Data
                .AcsUser;
        }

        public async Task<AcsUser> GetAsync(string acsUserId = default)
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
                string? createdBefore = default,
                int? limit = default,
                string? pageCursor = default,
                string? search = default,
                string? userIdentityEmailAddress = default,
                string? userIdentityId = default,
                string? userIdentityPhoneNumber = default
            )
            {
                AcsSystemId = acsSystemId;
                CreatedBefore = createdBefore;
                Limit = limit;
                PageCursor = pageCursor;
                Search = search;
                UserIdentityEmailAddress = userIdentityEmailAddress;
                UserIdentityId = userIdentityId;
                UserIdentityPhoneNumber = userIdentityPhoneNumber;
            }

            [DataMember(Name = "acs_system_id", IsRequired = false, EmitDefaultValue = false)]
            public string? AcsSystemId { get; set; }

            [DataMember(Name = "created_before", IsRequired = false, EmitDefaultValue = false)]
            public string? CreatedBefore { get; set; }

            [DataMember(Name = "limit", IsRequired = false, EmitDefaultValue = false)]
            public int? Limit { get; set; }

            [DataMember(Name = "page_cursor", IsRequired = false, EmitDefaultValue = false)]
            public string? PageCursor { get; set; }

            [DataMember(Name = "search", IsRequired = false, EmitDefaultValue = false)]
            public string? Search { get; set; }

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

            public ListResponse(List<AcsUser> acsUsers = default)
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

        public List<AcsUser> List(ListRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            return _seam.Post<ListResponse>("/acs/users/list", requestOptions).Data.AcsUsers;
        }

        public List<AcsUser> List(
            string? acsSystemId = default,
            string? createdBefore = default,
            int? limit = default,
            string? pageCursor = default,
            string? search = default,
            string? userIdentityEmailAddress = default,
            string? userIdentityId = default,
            string? userIdentityPhoneNumber = default
        )
        {
            return List(
                new ListRequest(
                    acsSystemId: acsSystemId,
                    createdBefore: createdBefore,
                    limit: limit,
                    pageCursor: pageCursor,
                    search: search,
                    userIdentityEmailAddress: userIdentityEmailAddress,
                    userIdentityId: userIdentityId,
                    userIdentityPhoneNumber: userIdentityPhoneNumber
                )
            );
        }

        public async Task<List<AcsUser>> ListAsync(ListRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            return (await _seam.PostAsync<ListResponse>("/acs/users/list", requestOptions))
                .Data
                .AcsUsers;
        }

        public async Task<List<AcsUser>> ListAsync(
            string? acsSystemId = default,
            string? createdBefore = default,
            int? limit = default,
            string? pageCursor = default,
            string? search = default,
            string? userIdentityEmailAddress = default,
            string? userIdentityId = default,
            string? userIdentityPhoneNumber = default
        )
        {
            return (
                await ListAsync(
                    new ListRequest(
                        acsSystemId: acsSystemId,
                        createdBefore: createdBefore,
                        limit: limit,
                        pageCursor: pageCursor,
                        search: search,
                        userIdentityEmailAddress: userIdentityEmailAddress,
                        userIdentityId: userIdentityId,
                        userIdentityPhoneNumber: userIdentityPhoneNumber
                    )
                )
            );
        }

        [DataContract(Name = "listAccessibleEntrancesRequest_request")]
        public class ListAccessibleEntrancesRequest
        {
            [JsonConstructorAttribute]
            protected ListAccessibleEntrancesRequest() { }

            public ListAccessibleEntrancesRequest(
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
                    "/acs/users/list_accessible_entrances",
                    requestOptions
                )
                .Data.AcsEntrances;
        }

        public List<AcsEntrance> ListAccessibleEntrances(
            string? acsSystemId = default,
            string? acsUserId = default,
            string? userIdentityId = default
        )
        {
            return ListAccessibleEntrances(
                new ListAccessibleEntrancesRequest(
                    acsSystemId: acsSystemId,
                    acsUserId: acsUserId,
                    userIdentityId: userIdentityId
                )
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
                    "/acs/users/list_accessible_entrances",
                    requestOptions
                )
            )
                .Data
                .AcsEntrances;
        }

        public async Task<List<AcsEntrance>> ListAccessibleEntrancesAsync(
            string? acsSystemId = default,
            string? acsUserId = default,
            string? userIdentityId = default
        )
        {
            return (
                await ListAccessibleEntrancesAsync(
                    new ListAccessibleEntrancesRequest(
                        acsSystemId: acsSystemId,
                        acsUserId: acsUserId,
                        userIdentityId: userIdentityId
                    )
                )
            );
        }

        [DataContract(Name = "removeFromAccessGroupRequest_request")]
        public class RemoveFromAccessGroupRequest
        {
            [JsonConstructorAttribute]
            protected RemoveFromAccessGroupRequest() { }

            public RemoveFromAccessGroupRequest(
                string acsAccessGroupId = default,
                string acsUserId = default
            )
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

        public void RemoveFromAccessGroup(RemoveFromAccessGroupRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            _seam.Post<object>("/acs/users/remove_from_access_group", requestOptions);
        }

        public void RemoveFromAccessGroup(
            string acsAccessGroupId = default,
            string acsUserId = default
        )
        {
            RemoveFromAccessGroup(
                new RemoveFromAccessGroupRequest(
                    acsAccessGroupId: acsAccessGroupId,
                    acsUserId: acsUserId
                )
            );
        }

        public async Task RemoveFromAccessGroupAsync(RemoveFromAccessGroupRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            await _seam.PostAsync<object>("/acs/users/remove_from_access_group", requestOptions);
        }

        public async Task RemoveFromAccessGroupAsync(
            string acsAccessGroupId = default,
            string acsUserId = default
        )
        {
            await RemoveFromAccessGroupAsync(
                new RemoveFromAccessGroupRequest(
                    acsAccessGroupId: acsAccessGroupId,
                    acsUserId: acsUserId
                )
            );
        }

        [DataContract(Name = "revokeAccessToAllEntrancesRequest_request")]
        public class RevokeAccessToAllEntrancesRequest
        {
            [JsonConstructorAttribute]
            protected RevokeAccessToAllEntrancesRequest() { }

            public RevokeAccessToAllEntrancesRequest(string acsUserId = default)
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

        public void RevokeAccessToAllEntrances(RevokeAccessToAllEntrancesRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            _seam.Post<object>("/acs/users/revoke_access_to_all_entrances", requestOptions);
        }

        public void RevokeAccessToAllEntrances(string acsUserId = default)
        {
            RevokeAccessToAllEntrances(new RevokeAccessToAllEntrancesRequest(acsUserId: acsUserId));
        }

        public async Task RevokeAccessToAllEntrancesAsync(RevokeAccessToAllEntrancesRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            await _seam.PostAsync<object>(
                "/acs/users/revoke_access_to_all_entrances",
                requestOptions
            );
        }

        public async Task RevokeAccessToAllEntrancesAsync(string acsUserId = default)
        {
            await RevokeAccessToAllEntrancesAsync(
                new RevokeAccessToAllEntrancesRequest(acsUserId: acsUserId)
            );
        }

        [DataContract(Name = "suspendRequest_request")]
        public class SuspendRequest
        {
            [JsonConstructorAttribute]
            protected SuspendRequest() { }

            public SuspendRequest(string acsUserId = default)
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

        public void Suspend(SuspendRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            _seam.Post<object>("/acs/users/suspend", requestOptions);
        }

        public void Suspend(string acsUserId = default)
        {
            Suspend(new SuspendRequest(acsUserId: acsUserId));
        }

        public async Task SuspendAsync(SuspendRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            await _seam.PostAsync<object>("/acs/users/suspend", requestOptions);
        }

        public async Task SuspendAsync(string acsUserId = default)
        {
            await SuspendAsync(new SuspendRequest(acsUserId: acsUserId));
        }

        [DataContract(Name = "unsuspendRequest_request")]
        public class UnsuspendRequest
        {
            [JsonConstructorAttribute]
            protected UnsuspendRequest() { }

            public UnsuspendRequest(string acsUserId = default)
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

        public void Unsuspend(UnsuspendRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            _seam.Post<object>("/acs/users/unsuspend", requestOptions);
        }

        public void Unsuspend(string acsUserId = default)
        {
            Unsuspend(new UnsuspendRequest(acsUserId: acsUserId));
        }

        public async Task UnsuspendAsync(UnsuspendRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            await _seam.PostAsync<object>("/acs/users/unsuspend", requestOptions);
        }

        public async Task UnsuspendAsync(string acsUserId = default)
        {
            await UnsuspendAsync(new UnsuspendRequest(acsUserId: acsUserId));
        }

        [DataContract(Name = "updateRequest_request")]
        public class UpdateRequest
        {
            [JsonConstructorAttribute]
            protected UpdateRequest() { }

            public UpdateRequest(
                UpdateRequestAccessSchedule? accessSchedule = default,
                string acsUserId = default,
                string? email = default,
                string? emailAddress = default,
                string? fullName = default,
                string? hidAcsSystemId = default,
                string? phoneNumber = default
            )
            {
                AccessSchedule = accessSchedule;
                AcsUserId = acsUserId;
                Email = email;
                EmailAddress = emailAddress;
                FullName = fullName;
                HidAcsSystemId = hidAcsSystemId;
                PhoneNumber = phoneNumber;
            }

            [DataMember(Name = "access_schedule", IsRequired = false, EmitDefaultValue = false)]
            public UpdateRequestAccessSchedule? AccessSchedule { get; set; }

            [DataMember(Name = "acs_user_id", IsRequired = true, EmitDefaultValue = false)]
            public string AcsUserId { get; set; }

            [DataMember(Name = "email", IsRequired = false, EmitDefaultValue = false)]
            public string? Email { get; set; }

            [DataMember(Name = "email_address", IsRequired = false, EmitDefaultValue = false)]
            public string? EmailAddress { get; set; }

            [DataMember(Name = "full_name", IsRequired = false, EmitDefaultValue = false)]
            public string? FullName { get; set; }

            [DataMember(Name = "hid_acs_system_id", IsRequired = false, EmitDefaultValue = false)]
            public string? HidAcsSystemId { get; set; }

            [DataMember(Name = "phone_number", IsRequired = false, EmitDefaultValue = false)]
            public string? PhoneNumber { get; set; }

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

        [DataContract(Name = "updateRequestAccessSchedule_model")]
        public class UpdateRequestAccessSchedule
        {
            [JsonConstructorAttribute]
            protected UpdateRequestAccessSchedule() { }

            public UpdateRequestAccessSchedule(string endsAt = default, string startsAt = default)
            {
                EndsAt = endsAt;
                StartsAt = startsAt;
            }

            [DataMember(Name = "ends_at", IsRequired = true, EmitDefaultValue = false)]
            public string EndsAt { get; set; }

            [DataMember(Name = "starts_at", IsRequired = true, EmitDefaultValue = false)]
            public string StartsAt { get; set; }

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

        public void Update(UpdateRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            _seam.Post<object>("/acs/users/update", requestOptions);
        }

        public void Update(
            UpdateRequestAccessSchedule? accessSchedule = default,
            string acsUserId = default,
            string? email = default,
            string? emailAddress = default,
            string? fullName = default,
            string? hidAcsSystemId = default,
            string? phoneNumber = default
        )
        {
            Update(
                new UpdateRequest(
                    accessSchedule: accessSchedule,
                    acsUserId: acsUserId,
                    email: email,
                    emailAddress: emailAddress,
                    fullName: fullName,
                    hidAcsSystemId: hidAcsSystemId,
                    phoneNumber: phoneNumber
                )
            );
        }

        public async Task UpdateAsync(UpdateRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            await _seam.PostAsync<object>("/acs/users/update", requestOptions);
        }

        public async Task UpdateAsync(
            UpdateRequestAccessSchedule? accessSchedule = default,
            string acsUserId = default,
            string? email = default,
            string? emailAddress = default,
            string? fullName = default,
            string? hidAcsSystemId = default,
            string? phoneNumber = default
        )
        {
            await UpdateAsync(
                new UpdateRequest(
                    accessSchedule: accessSchedule,
                    acsUserId: acsUserId,
                    email: email,
                    emailAddress: emailAddress,
                    fullName: fullName,
                    hidAcsSystemId: hidAcsSystemId,
                    phoneNumber: phoneNumber
                )
            );
        }
    }
}

namespace Seam.Client
{
    public partial class SeamClient
    {
        public Api.UsersAcs UsersAcs => new(this);
    }

    public partial interface ISeamClient
    {
        public Api.UsersAcs UsersAcs { get; }
    }
}
