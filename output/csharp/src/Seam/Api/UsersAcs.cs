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

        /// <summary>
        /// Request parameters for Add an ACS User to an Access Group.
        /// </summary>
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

            /// <summary>
            /// ID of the access group to which you want to add an access system user.
            /// </summary>
            [DataMember(Name = "acs_access_group_id", IsRequired = true, EmitDefaultValue = false)]
            public string AcsAccessGroupId { get; set; }

            /// <summary>
            /// ID of the access system user that you want to add to an access group.
            /// </summary>
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

        /// <summary>
        /// Adds a specified [access system user](https://docs.seam.co/low-level-apis/access-systems/user-management) to a specified [access group](https://docs.seam.co/low-level-apis/access-systems/user-management/assigning-users-to-access-groups).
        /// </summary>
        public void AddToAccessGroup(AddToAccessGroupRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            _seam.Post<object>("/acs/users/add_to_access_group", requestOptions);
        }

        /// <summary>
        /// Adds a specified [access system user](https://docs.seam.co/low-level-apis/access-systems/user-management) to a specified [access group](https://docs.seam.co/low-level-apis/access-systems/user-management/assigning-users-to-access-groups).
        /// </summary>
        public void AddToAccessGroup(string acsAccessGroupId = default, string acsUserId = default)
        {
            AddToAccessGroup(
                new AddToAccessGroupRequest(
                    acsAccessGroupId: acsAccessGroupId,
                    acsUserId: acsUserId
                )
            );
        }

        /// <summary>
        /// Adds a specified [access system user](https://docs.seam.co/low-level-apis/access-systems/user-management) to a specified [access group](https://docs.seam.co/low-level-apis/access-systems/user-management/assigning-users-to-access-groups).
        /// </summary>
        public async Task AddToAccessGroupAsync(AddToAccessGroupRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            await _seam.PostAsync<object>("/acs/users/add_to_access_group", requestOptions);
        }

        /// <summary>
        /// Adds a specified [access system user](https://docs.seam.co/low-level-apis/access-systems/user-management) to a specified [access group](https://docs.seam.co/low-level-apis/access-systems/user-management/assigning-users-to-access-groups).
        /// </summary>
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

        /// <summary>
        /// Request parameters for Create an ACS User.
        /// </summary>
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

            /// <summary>
            /// `starts_at` and `ends_at` timestamps for the new access system user&apos;s access. If you specify an `access_schedule`, you may include both `starts_at` and `ends_at`. If you omit `starts_at`, it defaults to the current time. `ends_at` is optional and must be a time in the future and after `starts_at`.
            /// </summary>
            [DataMember(Name = "access_schedule", IsRequired = false, EmitDefaultValue = false)]
            public CreateRequestAccessSchedule? AccessSchedule { get; set; }

            /// <summary>
            /// Array of access group IDs to indicate the access groups to which you want to add the new access system user.
            /// </summary>
            [DataMember(
                Name = "acs_access_group_ids",
                IsRequired = false,
                EmitDefaultValue = false
            )]
            public List<string>? AcsAccessGroupIds { get; set; }

            /// <summary>
            /// ID of the access system to which you want to add the new access system user.
            /// </summary>
            [DataMember(Name = "acs_system_id", IsRequired = true, EmitDefaultValue = false)]
            public string AcsSystemId { get; set; }

            [Obsolete("use email_address.")]
            [DataMember(Name = "email", IsRequired = false, EmitDefaultValue = false)]
            public string? Email { get; set; }

            /// <summary>
            /// Email address of the [access system user](https://docs.seam.co/low-level-apis/access-systems/user-management).
            /// </summary>
            [DataMember(Name = "email_address", IsRequired = false, EmitDefaultValue = false)]
            public string? EmailAddress { get; set; }

            /// <summary>
            /// Full name of the new access system user.
            /// </summary>
            [DataMember(Name = "full_name", IsRequired = true, EmitDefaultValue = false)]
            public string FullName { get; set; }

            /// <summary>
            /// Phone number of the [access system user](https://docs.seam.co/low-level-apis/access-systems/user-management) in E.164 format (for example, `+15555550100`).
            /// </summary>
            [DataMember(Name = "phone_number", IsRequired = false, EmitDefaultValue = false)]
            public string? PhoneNumber { get; set; }

            /// <summary>
            /// ID of the user identity with which you want to associate the new access system user.
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

            /// <summary>
            /// Ending timestamp for the new access system user&apos;s access.
            /// </summary>
            [DataMember(Name = "ends_at", IsRequired = false, EmitDefaultValue = false)]
            public string? EndsAt { get; set; }

            /// <summary>
            /// Starting timestamp for the new access system user&apos;s access.
            /// </summary>
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

            /// <summary>
            /// OK
            /// </summary>
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

        /// <summary>
        /// Creates a new [access system user](https://docs.seam.co/low-level-apis/access-systems/user-management).
        /// </summary>
        public AcsUser Create(CreateRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            return _seam
                .Post<CreateResponse>("/acs/users/create", requestOptions)
                .EnsureData("/acs/users/create")
                .AcsUser;
        }

        /// <summary>
        /// Creates a new [access system user](https://docs.seam.co/low-level-apis/access-systems/user-management).
        /// </summary>
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

        /// <summary>
        /// Creates a new [access system user](https://docs.seam.co/low-level-apis/access-systems/user-management).
        /// </summary>
        public async Task<AcsUser> CreateAsync(CreateRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            return (await _seam.PostAsync<CreateResponse>("/acs/users/create", requestOptions))
                .EnsureData("/acs/users/create")
                .AcsUser;
        }

        /// <summary>
        /// Creates a new [access system user](https://docs.seam.co/low-level-apis/access-systems/user-management).
        /// </summary>
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

        /// <summary>
        /// Request parameters for Delete an ACS User.
        /// </summary>
        [DataContract(Name = "deleteRequest_request")]
        public class DeleteRequest
        {
            [JsonConstructorAttribute]
            protected DeleteRequest() { }

            public DeleteRequest(
                string? acsSystemId = default,
                string? acsUserId = default,
                string? userIdentityId = default
            )
            {
                AcsSystemId = acsSystemId;
                AcsUserId = acsUserId;
                UserIdentityId = userIdentityId;
            }

            /// <summary>
            /// ID of the access system that you want to delete. You must provide acs_system_id with user_identity_id.
            /// </summary>
            [DataMember(Name = "acs_system_id", IsRequired = false, EmitDefaultValue = false)]
            public string? AcsSystemId { get; set; }

            /// <summary>
            /// ID of the access system user that you want to delete. You must provide either acs_user_id or user_identity_id
            /// </summary>
            [DataMember(Name = "acs_user_id", IsRequired = false, EmitDefaultValue = false)]
            public string? AcsUserId { get; set; }

            /// <summary>
            /// ID of the user identity that you want to delete. You must provide either acs_user_id or user_identity_id. If you provide user_identity_id, you must also provide acs_system_id.
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
        /// Deletes a specified [access system user](https://docs.seam.co/low-level-apis/access-systems/user-management) and invalidates the access system user&apos;s [credentials](https://docs.seam.co/low-level-apis/access-systems/managing-credentials).
        /// </summary>
        public void Delete(DeleteRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            _seam.Post<object>("/acs/users/delete", requestOptions);
        }

        /// <summary>
        /// Deletes a specified [access system user](https://docs.seam.co/low-level-apis/access-systems/user-management) and invalidates the access system user&apos;s [credentials](https://docs.seam.co/low-level-apis/access-systems/managing-credentials).
        /// </summary>
        public void Delete(
            string? acsSystemId = default,
            string? acsUserId = default,
            string? userIdentityId = default
        )
        {
            Delete(
                new DeleteRequest(
                    acsSystemId: acsSystemId,
                    acsUserId: acsUserId,
                    userIdentityId: userIdentityId
                )
            );
        }

        /// <summary>
        /// Deletes a specified [access system user](https://docs.seam.co/low-level-apis/access-systems/user-management) and invalidates the access system user&apos;s [credentials](https://docs.seam.co/low-level-apis/access-systems/managing-credentials).
        /// </summary>
        public async Task DeleteAsync(DeleteRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            await _seam.PostAsync<object>("/acs/users/delete", requestOptions);
        }

        /// <summary>
        /// Deletes a specified [access system user](https://docs.seam.co/low-level-apis/access-systems/user-management) and invalidates the access system user&apos;s [credentials](https://docs.seam.co/low-level-apis/access-systems/managing-credentials).
        /// </summary>
        public async Task DeleteAsync(
            string? acsSystemId = default,
            string? acsUserId = default,
            string? userIdentityId = default
        )
        {
            await DeleteAsync(
                new DeleteRequest(
                    acsSystemId: acsSystemId,
                    acsUserId: acsUserId,
                    userIdentityId: userIdentityId
                )
            );
        }

        /// <summary>
        /// Request parameters for Get an ACS User.
        /// </summary>
        [DataContract(Name = "getRequest_request")]
        public class GetRequest
        {
            [JsonConstructorAttribute]
            protected GetRequest() { }

            public GetRequest(
                string? acsSystemId = default,
                string? acsUserId = default,
                string? userIdentityId = default
            )
            {
                AcsSystemId = acsSystemId;
                AcsUserId = acsUserId;
                UserIdentityId = userIdentityId;
            }

            /// <summary>
            /// ID of the access system that you want to get. You can only provide acs_user_id or user_identity_id.
            /// </summary>
            [DataMember(Name = "acs_system_id", IsRequired = false, EmitDefaultValue = false)]
            public string? AcsSystemId { get; set; }

            /// <summary>
            /// ID of the access system user that you want to get. You can only provide acs_user_id or user_identity_id.
            /// </summary>
            [DataMember(Name = "acs_user_id", IsRequired = false, EmitDefaultValue = false)]
            public string? AcsUserId { get; set; }

            /// <summary>
            /// ID of the user identity that you want to get. You can only provide acs_user_id or user_identity_id.
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

        [DataContract(Name = "getResponse_response")]
        public class GetResponse
        {
            [JsonConstructorAttribute]
            protected GetResponse() { }

            public GetResponse(AcsUser acsUser = default)
            {
                AcsUser = acsUser;
            }

            /// <summary>
            /// OK
            /// </summary>
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

        /// <summary>
        /// Returns a specified [access system user](https://docs.seam.co/low-level-apis/access-systems/user-management).
        /// </summary>
        public AcsUser Get(GetRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            return _seam
                .Post<GetResponse>("/acs/users/get", requestOptions)
                .EnsureData("/acs/users/get")
                .AcsUser;
        }

        /// <summary>
        /// Returns a specified [access system user](https://docs.seam.co/low-level-apis/access-systems/user-management).
        /// </summary>
        public AcsUser Get(
            string? acsSystemId = default,
            string? acsUserId = default,
            string? userIdentityId = default
        )
        {
            return Get(
                new GetRequest(
                    acsSystemId: acsSystemId,
                    acsUserId: acsUserId,
                    userIdentityId: userIdentityId
                )
            );
        }

        /// <summary>
        /// Returns a specified [access system user](https://docs.seam.co/low-level-apis/access-systems/user-management).
        /// </summary>
        public async Task<AcsUser> GetAsync(GetRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            return (await _seam.PostAsync<GetResponse>("/acs/users/get", requestOptions))
                .EnsureData("/acs/users/get")
                .AcsUser;
        }

        /// <summary>
        /// Returns a specified [access system user](https://docs.seam.co/low-level-apis/access-systems/user-management).
        /// </summary>
        public async Task<AcsUser> GetAsync(
            string? acsSystemId = default,
            string? acsUserId = default,
            string? userIdentityId = default
        )
        {
            return (
                await GetAsync(
                    new GetRequest(
                        acsSystemId: acsSystemId,
                        acsUserId: acsUserId,
                        userIdentityId: userIdentityId
                    )
                )
            );
        }

        /// <summary>
        /// Request parameters for List ACS Users.
        /// </summary>
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

            /// <summary>
            /// ID of the `acs_system` for which you want to retrieve all access system users.
            /// </summary>
            [DataMember(Name = "acs_system_id", IsRequired = false, EmitDefaultValue = false)]
            public string? AcsSystemId { get; set; }

            /// <summary>
            /// Timestamp by which to limit returned access system users. Returns users created before this timestamp.
            /// </summary>
            [DataMember(Name = "created_before", IsRequired = false, EmitDefaultValue = false)]
            public string? CreatedBefore { get; set; }

            /// <summary>
            /// Maximum number of records to return per page.
            /// </summary>
            [DataMember(Name = "limit", IsRequired = false, EmitDefaultValue = false)]
            public int? Limit { get; set; }

            /// <summary>
            /// Identifies the specific page of results to return, obtained from the previous page&apos;s `next_page_cursor`.
            /// </summary>
            [DataMember(Name = "page_cursor", IsRequired = false, EmitDefaultValue = false)]
            public string? PageCursor { get; set; }

            /// <summary>
            /// String for which to search. Filters returned access system users to include all records that satisfy a partial match using `full_name`, `phone_number`, `email_address`, `acs_user_id`, `user_identity_id`, `user_identity_full_name` or `user_identity_phone_number`.
            /// </summary>
            [DataMember(Name = "search", IsRequired = false, EmitDefaultValue = false)]
            public string? Search { get; set; }

            /// <summary>
            /// Email address of the user identity for which you want to retrieve all access system users.
            /// </summary>
            [DataMember(
                Name = "user_identity_email_address",
                IsRequired = false,
                EmitDefaultValue = false
            )]
            public string? UserIdentityEmailAddress { get; set; }

            /// <summary>
            /// ID of the user identity for which you want to retrieve all access system users.
            /// </summary>
            [DataMember(Name = "user_identity_id", IsRequired = false, EmitDefaultValue = false)]
            public string? UserIdentityId { get; set; }

            /// <summary>
            /// Phone number of the user identity for which you want to retrieve all access system users, in [E.164 format](https://www.itu.int/rec/T-REC-E.164/en) (for example, `+15555550100`).
            /// </summary>
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
        /// Returns a list of all [access system users](https://docs.seam.co/low-level-apis/access-systems/user-management).
        /// </summary>
        public List<AcsUser> List(ListRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            return _seam
                .Post<ListResponse>("/acs/users/list", requestOptions)
                .EnsureData("/acs/users/list")
                .AcsUsers;
        }

        /// <summary>
        /// Returns a list of all [access system users](https://docs.seam.co/low-level-apis/access-systems/user-management).
        /// </summary>
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

        /// <summary>
        /// Returns a list of all [access system users](https://docs.seam.co/low-level-apis/access-systems/user-management).
        /// </summary>
        public async Task<List<AcsUser>> ListAsync(ListRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            return (await _seam.PostAsync<ListResponse>("/acs/users/list", requestOptions))
                .EnsureData("/acs/users/list")
                .AcsUsers;
        }

        /// <summary>
        /// Returns a list of all [access system users](https://docs.seam.co/low-level-apis/access-systems/user-management).
        /// </summary>
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

        /// <summary>
        /// Request parameters for List ACS User-Accessible Entrances.
        /// </summary>
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

            /// <summary>
            /// ID of the access system for which you want to list accessible entrances. You can only provide acs_system_id with user_identity_id.
            /// </summary>
            [DataMember(Name = "acs_system_id", IsRequired = false, EmitDefaultValue = false)]
            public string? AcsSystemId { get; set; }

            /// <summary>
            /// ID of the access system user for whom you want to list accessible entrances. You can only provide acs_user_id or user_identity_id.
            /// </summary>
            [DataMember(Name = "acs_user_id", IsRequired = false, EmitDefaultValue = false)]
            public string? AcsUserId { get; set; }

            /// <summary>
            /// ID of the user identity for whom you want to list accessible entrances. You can only provide acs_user_id or user_identity_id.
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
        /// Lists the [entrances](https://docs.seam.co/api/acs/entrances) to which a specified [access system user](https://docs.seam.co/low-level-apis/access-systems/user-management) has access.
        /// </summary>
        public List<AcsEntrance> ListAccessibleEntrances(ListAccessibleEntrancesRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            return _seam
                .Post<ListAccessibleEntrancesResponse>(
                    "/acs/users/list_accessible_entrances",
                    requestOptions
                )
                .EnsureData("/acs/users/list_accessible_entrances")
                .AcsEntrances;
        }

        /// <summary>
        /// Lists the [entrances](https://docs.seam.co/api/acs/entrances) to which a specified [access system user](https://docs.seam.co/low-level-apis/access-systems/user-management) has access.
        /// </summary>
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

        /// <summary>
        /// Lists the [entrances](https://docs.seam.co/api/acs/entrances) to which a specified [access system user](https://docs.seam.co/low-level-apis/access-systems/user-management) has access.
        /// </summary>
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
                .EnsureData("/acs/users/list_accessible_entrances")
                .AcsEntrances;
        }

        /// <summary>
        /// Lists the [entrances](https://docs.seam.co/api/acs/entrances) to which a specified [access system user](https://docs.seam.co/low-level-apis/access-systems/user-management) has access.
        /// </summary>
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

        /// <summary>
        /// Request parameters for Remove an ACS User from an Access Group.
        /// </summary>
        [DataContract(Name = "removeFromAccessGroupRequest_request")]
        public class RemoveFromAccessGroupRequest
        {
            [JsonConstructorAttribute]
            protected RemoveFromAccessGroupRequest() { }

            public RemoveFromAccessGroupRequest(
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
            /// ID of the access system user that you want to remove from an access group. You can only provide acs_user_id or user_identity_id.
            /// </summary>
            [DataMember(Name = "acs_user_id", IsRequired = false, EmitDefaultValue = false)]
            public string? AcsUserId { get; set; }

            /// <summary>
            /// ID of the user identity that you want to remove from an access group. You can only provide acs_user_id or user_identity_id.
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
        public void RemoveFromAccessGroup(RemoveFromAccessGroupRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            _seam.Post<object>("/acs/users/remove_from_access_group", requestOptions);
        }

        /// <summary>
        /// Removes a specified [access system user](https://docs.seam.co/low-level-apis/access-systems/user-management) from a specified [access group](https://docs.seam.co/low-level-apis/access-systems/user-management/assigning-users-to-access-groups).
        /// </summary>
        public void RemoveFromAccessGroup(
            string acsAccessGroupId = default,
            string? acsUserId = default,
            string? userIdentityId = default
        )
        {
            RemoveFromAccessGroup(
                new RemoveFromAccessGroupRequest(
                    acsAccessGroupId: acsAccessGroupId,
                    acsUserId: acsUserId,
                    userIdentityId: userIdentityId
                )
            );
        }

        /// <summary>
        /// Removes a specified [access system user](https://docs.seam.co/low-level-apis/access-systems/user-management) from a specified [access group](https://docs.seam.co/low-level-apis/access-systems/user-management/assigning-users-to-access-groups).
        /// </summary>
        public async Task RemoveFromAccessGroupAsync(RemoveFromAccessGroupRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            await _seam.PostAsync<object>("/acs/users/remove_from_access_group", requestOptions);
        }

        /// <summary>
        /// Removes a specified [access system user](https://docs.seam.co/low-level-apis/access-systems/user-management) from a specified [access group](https://docs.seam.co/low-level-apis/access-systems/user-management/assigning-users-to-access-groups).
        /// </summary>
        public async Task RemoveFromAccessGroupAsync(
            string acsAccessGroupId = default,
            string? acsUserId = default,
            string? userIdentityId = default
        )
        {
            await RemoveFromAccessGroupAsync(
                new RemoveFromAccessGroupRequest(
                    acsAccessGroupId: acsAccessGroupId,
                    acsUserId: acsUserId,
                    userIdentityId: userIdentityId
                )
            );
        }

        /// <summary>
        /// Request parameters for Revoke ACS User Access to All Entrances.
        /// </summary>
        [DataContract(Name = "revokeAccessToAllEntrancesRequest_request")]
        public class RevokeAccessToAllEntrancesRequest
        {
            [JsonConstructorAttribute]
            protected RevokeAccessToAllEntrancesRequest() { }

            public RevokeAccessToAllEntrancesRequest(
                string? acsSystemId = default,
                string? acsUserId = default,
                string? userIdentityId = default
            )
            {
                AcsSystemId = acsSystemId;
                AcsUserId = acsUserId;
                UserIdentityId = userIdentityId;
            }

            /// <summary>
            /// ID of the access system for which you want to revoke access. You can only provide acs_system_id with user_identity_id.
            /// </summary>
            [DataMember(Name = "acs_system_id", IsRequired = false, EmitDefaultValue = false)]
            public string? AcsSystemId { get; set; }

            /// <summary>
            /// ID of the access system user for whom you want to revoke access. You can only provide acs_user_id or user_identity_id.
            /// </summary>
            [DataMember(Name = "acs_user_id", IsRequired = false, EmitDefaultValue = false)]
            public string? AcsUserId { get; set; }

            /// <summary>
            /// ID of the user identity for whom you want to revoke access. You can only provide acs_user_id or user_identity_id.
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
        /// Revokes access to all [entrances](https://docs.seam.co/api/acs/entrances) for a specified [access system user](https://docs.seam.co/low-level-apis/access-systems/user-management).
        /// </summary>
        public void RevokeAccessToAllEntrances(RevokeAccessToAllEntrancesRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            _seam.Post<object>("/acs/users/revoke_access_to_all_entrances", requestOptions);
        }

        /// <summary>
        /// Revokes access to all [entrances](https://docs.seam.co/api/acs/entrances) for a specified [access system user](https://docs.seam.co/low-level-apis/access-systems/user-management).
        /// </summary>
        public void RevokeAccessToAllEntrances(
            string? acsSystemId = default,
            string? acsUserId = default,
            string? userIdentityId = default
        )
        {
            RevokeAccessToAllEntrances(
                new RevokeAccessToAllEntrancesRequest(
                    acsSystemId: acsSystemId,
                    acsUserId: acsUserId,
                    userIdentityId: userIdentityId
                )
            );
        }

        /// <summary>
        /// Revokes access to all [entrances](https://docs.seam.co/api/acs/entrances) for a specified [access system user](https://docs.seam.co/low-level-apis/access-systems/user-management).
        /// </summary>
        public async Task RevokeAccessToAllEntrancesAsync(RevokeAccessToAllEntrancesRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            await _seam.PostAsync<object>(
                "/acs/users/revoke_access_to_all_entrances",
                requestOptions
            );
        }

        /// <summary>
        /// Revokes access to all [entrances](https://docs.seam.co/api/acs/entrances) for a specified [access system user](https://docs.seam.co/low-level-apis/access-systems/user-management).
        /// </summary>
        public async Task RevokeAccessToAllEntrancesAsync(
            string? acsSystemId = default,
            string? acsUserId = default,
            string? userIdentityId = default
        )
        {
            await RevokeAccessToAllEntrancesAsync(
                new RevokeAccessToAllEntrancesRequest(
                    acsSystemId: acsSystemId,
                    acsUserId: acsUserId,
                    userIdentityId: userIdentityId
                )
            );
        }

        /// <summary>
        /// Request parameters for Suspend an ACS User.
        /// </summary>
        [DataContract(Name = "suspendRequest_request")]
        public class SuspendRequest
        {
            [JsonConstructorAttribute]
            protected SuspendRequest() { }

            public SuspendRequest(
                string? acsSystemId = default,
                string? acsUserId = default,
                string? userIdentityId = default
            )
            {
                AcsSystemId = acsSystemId;
                AcsUserId = acsUserId;
                UserIdentityId = userIdentityId;
            }

            /// <summary>
            /// ID of the access system that you want to suspend. You can only provide acs_user_id or the combination of acs_system_id and user_identity_id.
            /// </summary>
            [DataMember(Name = "acs_system_id", IsRequired = false, EmitDefaultValue = false)]
            public string? AcsSystemId { get; set; }

            /// <summary>
            /// ID of the access system user that you want to suspend. You can only provide acs_user_id or the combination of acs_system_id and user_identity_id.
            /// </summary>
            [DataMember(Name = "acs_user_id", IsRequired = false, EmitDefaultValue = false)]
            public string? AcsUserId { get; set; }

            /// <summary>
            /// ID of the user identity that you want to suspend. You can only provide acs_user_id or the combination of acs_system_id and user_identity_id.
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
        /// [Suspends](https://docs.seam.co/low-level-apis/access-systems/user-management/suspending-and-unsuspending-users#suspend-an-acs-user) a specified [access system user](https://docs.seam.co/low-level-apis/access-systems/user-management). Suspending an access system user revokes their access temporarily. To restore an access system user&apos;s access, you can [unsuspend](https://docs.seam.co/api/acs/users/unsuspend) them.
        /// </summary>
        public void Suspend(SuspendRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            _seam.Post<object>("/acs/users/suspend", requestOptions);
        }

        /// <summary>
        /// [Suspends](https://docs.seam.co/low-level-apis/access-systems/user-management/suspending-and-unsuspending-users#suspend-an-acs-user) a specified [access system user](https://docs.seam.co/low-level-apis/access-systems/user-management). Suspending an access system user revokes their access temporarily. To restore an access system user&apos;s access, you can [unsuspend](https://docs.seam.co/api/acs/users/unsuspend) them.
        /// </summary>
        public void Suspend(
            string? acsSystemId = default,
            string? acsUserId = default,
            string? userIdentityId = default
        )
        {
            Suspend(
                new SuspendRequest(
                    acsSystemId: acsSystemId,
                    acsUserId: acsUserId,
                    userIdentityId: userIdentityId
                )
            );
        }

        /// <summary>
        /// [Suspends](https://docs.seam.co/low-level-apis/access-systems/user-management/suspending-and-unsuspending-users#suspend-an-acs-user) a specified [access system user](https://docs.seam.co/low-level-apis/access-systems/user-management). Suspending an access system user revokes their access temporarily. To restore an access system user&apos;s access, you can [unsuspend](https://docs.seam.co/api/acs/users/unsuspend) them.
        /// </summary>
        public async Task SuspendAsync(SuspendRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            await _seam.PostAsync<object>("/acs/users/suspend", requestOptions);
        }

        /// <summary>
        /// [Suspends](https://docs.seam.co/low-level-apis/access-systems/user-management/suspending-and-unsuspending-users#suspend-an-acs-user) a specified [access system user](https://docs.seam.co/low-level-apis/access-systems/user-management). Suspending an access system user revokes their access temporarily. To restore an access system user&apos;s access, you can [unsuspend](https://docs.seam.co/api/acs/users/unsuspend) them.
        /// </summary>
        public async Task SuspendAsync(
            string? acsSystemId = default,
            string? acsUserId = default,
            string? userIdentityId = default
        )
        {
            await SuspendAsync(
                new SuspendRequest(
                    acsSystemId: acsSystemId,
                    acsUserId: acsUserId,
                    userIdentityId: userIdentityId
                )
            );
        }

        /// <summary>
        /// Request parameters for Unsuspend an ACS User.
        /// </summary>
        [DataContract(Name = "unsuspendRequest_request")]
        public class UnsuspendRequest
        {
            [JsonConstructorAttribute]
            protected UnsuspendRequest() { }

            public UnsuspendRequest(
                string? acsSystemId = default,
                string? acsUserId = default,
                string? userIdentityId = default
            )
            {
                AcsSystemId = acsSystemId;
                AcsUserId = acsUserId;
                UserIdentityId = userIdentityId;
            }

            /// <summary>
            /// ID of the access system of the user that you want to unsuspend. You can only provide acs_system_id with user_identity_id.
            /// </summary>
            [DataMember(Name = "acs_system_id", IsRequired = false, EmitDefaultValue = false)]
            public string? AcsSystemId { get; set; }

            /// <summary>
            /// ID of the access system user that you want to unsuspend. You can only provide acs_user_id or the combination of acs_system_id and user_identity_id.
            /// </summary>
            [DataMember(Name = "acs_user_id", IsRequired = false, EmitDefaultValue = false)]
            public string? AcsUserId { get; set; }

            /// <summary>
            /// ID of the user identity that you want to unsuspend. You can only provide acs_user_id or the combination of acs_system_id and user_identity_id.
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
        /// [Unsuspends](https://docs.seam.co/low-level-apis/access-systems/user-management/suspending-and-unsuspending-users#unsuspend-an-acs-user) a specified suspended [access system user](https://docs.seam.co/low-level-apis/access-systems/user-management). While [suspending an access system user](https://docs.seam.co/api/acs/users/suspend) revokes their access temporarily, unsuspending the access system user restores their access.
        /// </summary>
        public void Unsuspend(UnsuspendRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            _seam.Post<object>("/acs/users/unsuspend", requestOptions);
        }

        /// <summary>
        /// [Unsuspends](https://docs.seam.co/low-level-apis/access-systems/user-management/suspending-and-unsuspending-users#unsuspend-an-acs-user) a specified suspended [access system user](https://docs.seam.co/low-level-apis/access-systems/user-management). While [suspending an access system user](https://docs.seam.co/api/acs/users/suspend) revokes their access temporarily, unsuspending the access system user restores their access.
        /// </summary>
        public void Unsuspend(
            string? acsSystemId = default,
            string? acsUserId = default,
            string? userIdentityId = default
        )
        {
            Unsuspend(
                new UnsuspendRequest(
                    acsSystemId: acsSystemId,
                    acsUserId: acsUserId,
                    userIdentityId: userIdentityId
                )
            );
        }

        /// <summary>
        /// [Unsuspends](https://docs.seam.co/low-level-apis/access-systems/user-management/suspending-and-unsuspending-users#unsuspend-an-acs-user) a specified suspended [access system user](https://docs.seam.co/low-level-apis/access-systems/user-management). While [suspending an access system user](https://docs.seam.co/api/acs/users/suspend) revokes their access temporarily, unsuspending the access system user restores their access.
        /// </summary>
        public async Task UnsuspendAsync(UnsuspendRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            await _seam.PostAsync<object>("/acs/users/unsuspend", requestOptions);
        }

        /// <summary>
        /// [Unsuspends](https://docs.seam.co/low-level-apis/access-systems/user-management/suspending-and-unsuspending-users#unsuspend-an-acs-user) a specified suspended [access system user](https://docs.seam.co/low-level-apis/access-systems/user-management). While [suspending an access system user](https://docs.seam.co/api/acs/users/suspend) revokes their access temporarily, unsuspending the access system user restores their access.
        /// </summary>
        public async Task UnsuspendAsync(
            string? acsSystemId = default,
            string? acsUserId = default,
            string? userIdentityId = default
        )
        {
            await UnsuspendAsync(
                new UnsuspendRequest(
                    acsSystemId: acsSystemId,
                    acsUserId: acsUserId,
                    userIdentityId: userIdentityId
                )
            );
        }

        /// <summary>
        /// Request parameters for Update an ACS User.
        /// </summary>
        [DataContract(Name = "updateRequest_request")]
        public class UpdateRequest
        {
            [JsonConstructorAttribute]
            protected UpdateRequest() { }

            public UpdateRequest(
                UpdateRequestAccessSchedule? accessSchedule = default,
                string? acsSystemId = default,
                string? acsUserId = default,
                string? email = default,
                string? emailAddress = default,
                string? fullName = default,
                string? hidAcsSystemId = default,
                string? phoneNumber = default,
                string? userIdentityId = default
            )
            {
                AccessSchedule = accessSchedule;
                AcsSystemId = acsSystemId;
                AcsUserId = acsUserId;
                Email = email;
                EmailAddress = emailAddress;
                FullName = fullName;
                HidAcsSystemId = hidAcsSystemId;
                PhoneNumber = phoneNumber;
                UserIdentityId = userIdentityId;
            }

            /// <summary>
            /// `starts_at` and `ends_at` timestamps for the access system user&apos;s access. If you specify an `access_schedule`, you may include both `starts_at` and `ends_at`. If you omit `starts_at`, it defaults to the current time. `ends_at` is optional and must be a time in the future and after `starts_at`.
            /// </summary>
            [DataMember(Name = "access_schedule", IsRequired = false, EmitDefaultValue = false)]
            public UpdateRequestAccessSchedule? AccessSchedule { get; set; }

            /// <summary>
            /// ID of the access system that you want to update. You can only provide acs_system_id with user_identity_id.
            /// </summary>
            [DataMember(Name = "acs_system_id", IsRequired = false, EmitDefaultValue = false)]
            public string? AcsSystemId { get; set; }

            /// <summary>
            /// ID of the access system user that you want to update. You can only provide acs_user_id or user_identity_id.
            /// </summary>
            [DataMember(Name = "acs_user_id", IsRequired = false, EmitDefaultValue = false)]
            public string? AcsUserId { get; set; }

            [Obsolete("use email_address.")]
            [DataMember(Name = "email", IsRequired = false, EmitDefaultValue = false)]
            public string? Email { get; set; }

            /// <summary>
            /// Email address of the [access system user](https://docs.seam.co/low-level-apis/access-systems/user-management).
            /// </summary>
            [DataMember(Name = "email_address", IsRequired = false, EmitDefaultValue = false)]
            public string? EmailAddress { get; set; }

            /// <summary>
            /// Full name of the [access system user](https://docs.seam.co/low-level-apis/access-systems/user-management).
            /// </summary>
            [DataMember(Name = "full_name", IsRequired = false, EmitDefaultValue = false)]
            public string? FullName { get; set; }

            /// <summary>
            /// ID of the HID access control system associated with the user.
            /// </summary>
            [DataMember(Name = "hid_acs_system_id", IsRequired = false, EmitDefaultValue = false)]
            public string? HidAcsSystemId { get; set; }

            /// <summary>
            /// Phone number of the [access system user](https://docs.seam.co/low-level-apis/access-systems/user-management) in E.164 format (for example, `+15555550100`).
            /// </summary>
            [DataMember(Name = "phone_number", IsRequired = false, EmitDefaultValue = false)]
            public string? PhoneNumber { get; set; }

            /// <summary>
            /// ID of the user identity that you want to update. You can only provide acs_user_id or user_identity_id. If you provide user_identity_id, you must also provide acs_system_id.
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

        [DataContract(Name = "updateRequestAccessSchedule_model")]
        public class UpdateRequestAccessSchedule
        {
            [JsonConstructorAttribute]
            protected UpdateRequestAccessSchedule() { }

            public UpdateRequestAccessSchedule(string? endsAt = default, string? startsAt = default)
            {
                EndsAt = endsAt;
                StartsAt = startsAt;
            }

            /// <summary>
            /// Ending timestamp for the access system user&apos;s access.
            /// </summary>
            [DataMember(Name = "ends_at", IsRequired = false, EmitDefaultValue = false)]
            public string? EndsAt { get; set; }

            /// <summary>
            /// Starting timestamp for the access system user&apos;s access.
            /// </summary>
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

        /// <summary>
        /// Updates the properties of a specified [access system user](https://docs.seam.co/low-level-apis/access-systems/user-management).
        /// </summary>
        public void Update(UpdateRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            _seam.Post<object>("/acs/users/update", requestOptions);
        }

        /// <summary>
        /// Updates the properties of a specified [access system user](https://docs.seam.co/low-level-apis/access-systems/user-management).
        /// </summary>
        public void Update(
            UpdateRequestAccessSchedule? accessSchedule = default,
            string? acsSystemId = default,
            string? acsUserId = default,
            string? email = default,
            string? emailAddress = default,
            string? fullName = default,
            string? hidAcsSystemId = default,
            string? phoneNumber = default,
            string? userIdentityId = default
        )
        {
            Update(
                new UpdateRequest(
                    accessSchedule: accessSchedule,
                    acsSystemId: acsSystemId,
                    acsUserId: acsUserId,
                    email: email,
                    emailAddress: emailAddress,
                    fullName: fullName,
                    hidAcsSystemId: hidAcsSystemId,
                    phoneNumber: phoneNumber,
                    userIdentityId: userIdentityId
                )
            );
        }

        /// <summary>
        /// Updates the properties of a specified [access system user](https://docs.seam.co/low-level-apis/access-systems/user-management).
        /// </summary>
        public async Task UpdateAsync(UpdateRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            await _seam.PostAsync<object>("/acs/users/update", requestOptions);
        }

        /// <summary>
        /// Updates the properties of a specified [access system user](https://docs.seam.co/low-level-apis/access-systems/user-management).
        /// </summary>
        public async Task UpdateAsync(
            UpdateRequestAccessSchedule? accessSchedule = default,
            string? acsSystemId = default,
            string? acsUserId = default,
            string? email = default,
            string? emailAddress = default,
            string? fullName = default,
            string? hidAcsSystemId = default,
            string? phoneNumber = default,
            string? userIdentityId = default
        )
        {
            await UpdateAsync(
                new UpdateRequest(
                    accessSchedule: accessSchedule,
                    acsSystemId: acsSystemId,
                    acsUserId: acsUserId,
                    email: email,
                    emailAddress: emailAddress,
                    fullName: fullName,
                    hidAcsSystemId: hidAcsSystemId,
                    phoneNumber: phoneNumber,
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
        public Api.UsersAcs UsersAcs => new(this);
    }

    public partial interface ISeamClient
    {
        public Api.UsersAcs UsersAcs { get; }
    }
}
