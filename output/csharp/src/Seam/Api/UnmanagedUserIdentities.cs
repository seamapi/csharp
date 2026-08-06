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
    public class UnmanagedUserIdentities
    {
        private ISeamClient _seam;

        public UnmanagedUserIdentities(ISeamClient seam)
        {
            _seam = seam;
        }

        /// <summary>
        /// Request parameters for Get an Unmanaged User Identity.
        /// </summary>
        [DataContract(Name = "getRequest_request")]
        public class GetRequest
        {
            [JsonConstructorAttribute]
            protected GetRequest() { }

            public GetRequest(string userIdentityId = default)
            {
                UserIdentityId = userIdentityId;
            }

            /// <summary>
            /// ID of the unmanaged user identity that you want to get.
            /// </summary>
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

        [DataContract(Name = "getResponse_response")]
        public class GetResponse
        {
            [JsonConstructorAttribute]
            protected GetResponse() { }

            public GetResponse(UserIdentity userIdentity = default)
            {
                UserIdentity = userIdentity;
            }

            /// <summary>
            /// OK
            /// </summary>
            [DataMember(Name = "user_identity", IsRequired = false, EmitDefaultValue = false)]
            public UserIdentity UserIdentity { get; set; }

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
        /// Returns a specified unmanaged [user identity](https://docs.seam.co/capability-guides/mobile-access/managing-mobile-app-user-accounts-with-user-identities#what-is-a-user-identity) (where is_managed = false).
        /// </summary>
        public UserIdentity Get(GetRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            return _seam
                .Post<GetResponse>("/user_identities/unmanaged/get", requestOptions)
                .EnsureData("/user_identities/unmanaged/get")
                .UserIdentity;
        }

        /// <summary>
        /// Returns a specified unmanaged [user identity](https://docs.seam.co/capability-guides/mobile-access/managing-mobile-app-user-accounts-with-user-identities#what-is-a-user-identity) (where is_managed = false).
        /// </summary>
        public UserIdentity Get(string userIdentityId = default)
        {
            return Get(new GetRequest(userIdentityId: userIdentityId));
        }

        /// <summary>
        /// Returns a specified unmanaged [user identity](https://docs.seam.co/capability-guides/mobile-access/managing-mobile-app-user-accounts-with-user-identities#what-is-a-user-identity) (where is_managed = false).
        /// </summary>
        public async Task<UserIdentity> GetAsync(GetRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            return (
                await _seam.PostAsync<GetResponse>("/user_identities/unmanaged/get", requestOptions)
            )
                .EnsureData("/user_identities/unmanaged/get")
                .UserIdentity;
        }

        /// <summary>
        /// Returns a specified unmanaged [user identity](https://docs.seam.co/capability-guides/mobile-access/managing-mobile-app-user-accounts-with-user-identities#what-is-a-user-identity) (where is_managed = false).
        /// </summary>
        public async Task<UserIdentity> GetAsync(string userIdentityId = default)
        {
            return (await GetAsync(new GetRequest(userIdentityId: userIdentityId)));
        }

        /// <summary>
        /// Request parameters for List Unmanaged User Identities.
        /// </summary>
        [DataContract(Name = "listRequest_request")]
        public class ListRequest
        {
            [JsonConstructorAttribute]
            protected ListRequest() { }

            public ListRequest(
                string? createdBefore = default,
                int? limit = default,
                string? pageCursor = default,
                string? search = default
            )
            {
                CreatedBefore = createdBefore;
                Limit = limit;
                PageCursor = pageCursor;
                Search = search;
            }

            /// <summary>
            /// Timestamp by which to limit returned unmanaged user identities. Returns user identities created before this timestamp.
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
            /// String for which to search. Filters returned unmanaged user identities to include all records that satisfy a partial match using `full_name`, `phone_number`, `email_address`,  `user_identity_id` or `acs_system_id`.
            /// </summary>
            [DataMember(Name = "search", IsRequired = false, EmitDefaultValue = false)]
            public string? Search { get; set; }

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

            public ListResponse(List<object> userIdentities = default)
            {
                UserIdentities = userIdentities;
            }

            /// <summary>
            /// OK
            /// </summary>
            [DataMember(Name = "user_identities", IsRequired = false, EmitDefaultValue = false)]
            public List<object> UserIdentities { get; set; }

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
        /// Returns a list of all unmanaged [user identities](https://docs.seam.co/capability-guides/mobile-access/managing-mobile-app-user-accounts-with-user-identities#what-is-a-user-identity) (where is_managed = false).
        /// </summary>
        public List<object> List(ListRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            return _seam
                .Post<ListResponse>("/user_identities/unmanaged/list", requestOptions)
                .EnsureData("/user_identities/unmanaged/list")
                .UserIdentities;
        }

        /// <summary>
        /// Returns a list of all unmanaged [user identities](https://docs.seam.co/capability-guides/mobile-access/managing-mobile-app-user-accounts-with-user-identities#what-is-a-user-identity) (where is_managed = false).
        /// </summary>
        public List<object> List(
            string? createdBefore = default,
            int? limit = default,
            string? pageCursor = default,
            string? search = default
        )
        {
            return List(
                new ListRequest(
                    createdBefore: createdBefore,
                    limit: limit,
                    pageCursor: pageCursor,
                    search: search
                )
            );
        }

        /// <summary>
        /// Returns a list of all unmanaged [user identities](https://docs.seam.co/capability-guides/mobile-access/managing-mobile-app-user-accounts-with-user-identities#what-is-a-user-identity) (where is_managed = false).
        /// </summary>
        public async Task<List<object>> ListAsync(ListRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            return (
                await _seam.PostAsync<ListResponse>(
                    "/user_identities/unmanaged/list",
                    requestOptions
                )
            )
                .EnsureData("/user_identities/unmanaged/list")
                .UserIdentities;
        }

        /// <summary>
        /// Returns a list of all unmanaged [user identities](https://docs.seam.co/capability-guides/mobile-access/managing-mobile-app-user-accounts-with-user-identities#what-is-a-user-identity) (where is_managed = false).
        /// </summary>
        public async Task<List<object>> ListAsync(
            string? createdBefore = default,
            int? limit = default,
            string? pageCursor = default,
            string? search = default
        )
        {
            return (
                await ListAsync(
                    new ListRequest(
                        createdBefore: createdBefore,
                        limit: limit,
                        pageCursor: pageCursor,
                        search: search
                    )
                )
            );
        }

        /// <summary>
        /// Request parameters for Update an Unmanaged User Identity.
        /// </summary>
        [DataContract(Name = "updateRequest_request")]
        public class UpdateRequest
        {
            [JsonConstructorAttribute]
            protected UpdateRequest() { }

            public UpdateRequest(
                bool isManaged = default,
                string userIdentityId = default,
                string? userIdentityKey = default
            )
            {
                IsManaged = isManaged;
                UserIdentityId = userIdentityId;
                UserIdentityKey = userIdentityKey;
            }

            /// <summary>
            /// Must be set to true to convert the unmanaged user identity to managed.
            /// </summary>
            [DataMember(Name = "is_managed", IsRequired = true, EmitDefaultValue = false)]
            public bool IsManaged { get; set; }

            /// <summary>
            /// ID of the unmanaged user identity that you want to update.
            /// </summary>
            [DataMember(Name = "user_identity_id", IsRequired = true, EmitDefaultValue = false)]
            public string UserIdentityId { get; set; }

            /// <summary>
            /// Unique key for the user identity. If not provided, the existing key will be preserved.
            /// </summary>
            [DataMember(Name = "user_identity_key", IsRequired = false, EmitDefaultValue = false)]
            public string? UserIdentityKey { get; set; }

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
        /// Updates an unmanaged [user identity](https://docs.seam.co/capability-guides/mobile-access/managing-mobile-app-user-accounts-with-user-identities#what-is-a-user-identity) to make it managed.
        ///
        /// This endpoint can only be used to convert unmanaged user identities to managed ones by setting `is_managed` to `true`. It cannot be used to convert managed user identities back to unmanaged.
        /// </summary>
        public void Update(UpdateRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            _seam.Post<object>("/user_identities/unmanaged/update", requestOptions);
        }

        /// <summary>
        /// Updates an unmanaged [user identity](https://docs.seam.co/capability-guides/mobile-access/managing-mobile-app-user-accounts-with-user-identities#what-is-a-user-identity) to make it managed.
        ///
        /// This endpoint can only be used to convert unmanaged user identities to managed ones by setting `is_managed` to `true`. It cannot be used to convert managed user identities back to unmanaged.
        /// </summary>
        public void Update(
            bool isManaged = default,
            string userIdentityId = default,
            string? userIdentityKey = default
        )
        {
            Update(
                new UpdateRequest(
                    isManaged: isManaged,
                    userIdentityId: userIdentityId,
                    userIdentityKey: userIdentityKey
                )
            );
        }

        /// <summary>
        /// Updates an unmanaged [user identity](https://docs.seam.co/capability-guides/mobile-access/managing-mobile-app-user-accounts-with-user-identities#what-is-a-user-identity) to make it managed.
        ///
        /// This endpoint can only be used to convert unmanaged user identities to managed ones by setting `is_managed` to `true`. It cannot be used to convert managed user identities back to unmanaged.
        /// </summary>
        public async Task UpdateAsync(UpdateRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            await _seam.PostAsync<object>("/user_identities/unmanaged/update", requestOptions);
        }

        /// <summary>
        /// Updates an unmanaged [user identity](https://docs.seam.co/capability-guides/mobile-access/managing-mobile-app-user-accounts-with-user-identities#what-is-a-user-identity) to make it managed.
        ///
        /// This endpoint can only be used to convert unmanaged user identities to managed ones by setting `is_managed` to `true`. It cannot be used to convert managed user identities back to unmanaged.
        /// </summary>
        public async Task UpdateAsync(
            bool isManaged = default,
            string userIdentityId = default,
            string? userIdentityKey = default
        )
        {
            await UpdateAsync(
                new UpdateRequest(
                    isManaged: isManaged,
                    userIdentityId: userIdentityId,
                    userIdentityKey: userIdentityKey
                )
            );
        }
    }
}

namespace Seam.Client
{
    public partial class SeamClient
    {
        public Api.UnmanagedUserIdentities UnmanagedUserIdentities => new(this);
    }

    public partial interface ISeamClient
    {
        public Api.UnmanagedUserIdentities UnmanagedUserIdentities { get; }
    }
}
