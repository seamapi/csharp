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

        /// <summary>
        /// Request parameters for Get an Entrance.
        /// </summary>
        [DataContract(Name = "getRequest_request")]
        public class GetRequest
        {
            [JsonConstructorAttribute]
            protected GetRequest() { }

            public GetRequest(string acsEntranceId = default)
            {
                AcsEntranceId = acsEntranceId;
            }

            /// <summary>
            /// ID of the entrance that you want to get.
            /// </summary>
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

            /// <summary>
            /// OK
            /// </summary>
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

        /// <summary>
        /// Returns a specified [access system entrance](https://docs.seam.co/low-level-apis/access-systems/retrieving-entrance-details).
        /// </summary>
        public AcsEntrance Get(GetRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            return _seam.Post<GetResponse>("/acs/entrances/get", requestOptions).Data.AcsEntrance;
        }

        /// <summary>
        /// Returns a specified [access system entrance](https://docs.seam.co/low-level-apis/access-systems/retrieving-entrance-details).
        /// </summary>
        public AcsEntrance Get(string acsEntranceId = default)
        {
            return Get(new GetRequest(acsEntranceId: acsEntranceId));
        }

        /// <summary>
        /// Returns a specified [access system entrance](https://docs.seam.co/low-level-apis/access-systems/retrieving-entrance-details).
        /// </summary>
        public async Task<AcsEntrance> GetAsync(GetRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            return (await _seam.PostAsync<GetResponse>("/acs/entrances/get", requestOptions))
                .Data
                .AcsEntrance;
        }

        /// <summary>
        /// Returns a specified [access system entrance](https://docs.seam.co/low-level-apis/access-systems/retrieving-entrance-details).
        /// </summary>
        public async Task<AcsEntrance> GetAsync(string acsEntranceId = default)
        {
            return (await GetAsync(new GetRequest(acsEntranceId: acsEntranceId)));
        }

        /// <summary>
        /// Request parameters for Grant an ACS User Access to an Entrance.
        /// </summary>
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

            /// <summary>
            /// ID of the entrance to which you want to grant an access system user access.
            /// </summary>
            [DataMember(Name = "acs_entrance_id", IsRequired = true, EmitDefaultValue = false)]
            public string AcsEntranceId { get; set; }

            /// <summary>
            /// ID of the access system user to whom you want to grant access to an entrance. You can only provide one of acs_user_id or user_identity_id.
            /// </summary>
            [DataMember(Name = "acs_user_id", IsRequired = false, EmitDefaultValue = false)]
            public string? AcsUserId { get; set; }

            /// <summary>
            /// ID of the user identity to whom you want to grant access to an entrance. You can only provide one of acs_user_id or user_identity_id. If the ACS system contains an ACS user with the same `email_address` or `phone_number` as the user identity that you specify, they are linked, and the access group membership belongs to the ACS user. If the ACS system does not have a corresponding ACS user, one is created.
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
        /// Grants a specified [access system user](https://docs.seam.co/low-level-apis/access-systems/user-management) access to a specified [access system entrance](https://docs.seam.co/low-level-apis/access-systems/retrieving-entrance-details).
        /// </summary>
        public void GrantAccess(GrantAccessRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            _seam.Post<object>("/acs/entrances/grant_access", requestOptions);
        }

        /// <summary>
        /// Grants a specified [access system user](https://docs.seam.co/low-level-apis/access-systems/user-management) access to a specified [access system entrance](https://docs.seam.co/low-level-apis/access-systems/retrieving-entrance-details).
        /// </summary>
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

        /// <summary>
        /// Grants a specified [access system user](https://docs.seam.co/low-level-apis/access-systems/user-management) access to a specified [access system entrance](https://docs.seam.co/low-level-apis/access-systems/retrieving-entrance-details).
        /// </summary>
        public async Task GrantAccessAsync(GrantAccessRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            await _seam.PostAsync<object>("/acs/entrances/grant_access", requestOptions);
        }

        /// <summary>
        /// Grants a specified [access system user](https://docs.seam.co/low-level-apis/access-systems/user-management) access to a specified [access system entrance](https://docs.seam.co/low-level-apis/access-systems/retrieving-entrance-details).
        /// </summary>
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

        /// <summary>
        /// Request parameters for List Entrances.
        /// </summary>
        [DataContract(Name = "listRequest_request")]
        public class ListRequest
        {
            [JsonConstructorAttribute]
            protected ListRequest() { }

            public ListRequest(
                string? acsCredentialId = default,
                List<string>? acsEntranceIds = default,
                string? acsSystemId = default,
                string? connectedAccountId = default,
                string? customerKey = default,
                int? limit = default,
                string? locationId = default,
                string? pageCursor = default,
                string? search = default,
                string? spaceId = default
            )
            {
                AcsCredentialId = acsCredentialId;
                AcsEntranceIds = acsEntranceIds;
                AcsSystemId = acsSystemId;
                ConnectedAccountId = connectedAccountId;
                CustomerKey = customerKey;
                Limit = limit;
                LocationId = locationId;
                PageCursor = pageCursor;
                Search = search;
                SpaceId = spaceId;
            }

            /// <summary>
            /// ID of the credential for which you want to retrieve all entrances.
            /// </summary>
            [DataMember(Name = "acs_credential_id", IsRequired = false, EmitDefaultValue = false)]
            public string? AcsCredentialId { get; set; }

            /// <summary>
            /// IDs of the entrances for which you want to retrieve all entrances.
            /// </summary>
            [DataMember(Name = "acs_entrance_ids", IsRequired = false, EmitDefaultValue = false)]
            public List<string>? AcsEntranceIds { get; set; }

            /// <summary>
            /// ID of the access system for which you want to retrieve all entrances.
            /// </summary>
            [DataMember(Name = "acs_system_id", IsRequired = false, EmitDefaultValue = false)]
            public string? AcsSystemId { get; set; }

            /// <summary>
            /// ID of the connected account for which you want to retrieve all entrances.
            /// </summary>
            [DataMember(
                Name = "connected_account_id",
                IsRequired = false,
                EmitDefaultValue = false
            )]
            public string? ConnectedAccountId { get; set; }

            /// <summary>
            /// Customer key for which you want to list entrances.
            /// </summary>
            [DataMember(Name = "customer_key", IsRequired = false, EmitDefaultValue = false)]
            public string? CustomerKey { get; set; }

            /// <summary>
            /// Maximum number of records to return per page.
            /// </summary>
            [DataMember(Name = "limit", IsRequired = false, EmitDefaultValue = false)]
            public int? Limit { get; set; }

            [Obsolete("Use `space_id`.")]
            [DataMember(Name = "location_id", IsRequired = false, EmitDefaultValue = false)]
            public string? LocationId { get; set; }

            /// <summary>
            /// Identifies the specific page of results to return, obtained from the previous page&apos;s `next_page_cursor`.
            /// </summary>
            [DataMember(Name = "page_cursor", IsRequired = false, EmitDefaultValue = false)]
            public string? PageCursor { get; set; }

            /// <summary>
            /// String for which to search. Filters returned entrances to include all records that satisfy a partial match using `display_name`.
            /// </summary>
            [DataMember(Name = "search", IsRequired = false, EmitDefaultValue = false)]
            public string? Search { get; set; }

            /// <summary>
            /// ID of the space for which you want to list entrances.
            /// </summary>
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
        /// Returns a list of all [access system entrances](https://docs.seam.co/low-level-apis/access-systems/retrieving-entrance-details).
        /// </summary>
        public List<AcsEntrance> List(ListRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            return _seam
                .Post<ListResponse>("/acs/entrances/list", requestOptions)
                .Data.AcsEntrances;
        }

        /// <summary>
        /// Returns a list of all [access system entrances](https://docs.seam.co/low-level-apis/access-systems/retrieving-entrance-details).
        /// </summary>
        public List<AcsEntrance> List(
            string? acsCredentialId = default,
            List<string>? acsEntranceIds = default,
            string? acsSystemId = default,
            string? connectedAccountId = default,
            string? customerKey = default,
            int? limit = default,
            string? locationId = default,
            string? pageCursor = default,
            string? search = default,
            string? spaceId = default
        )
        {
            return List(
                new ListRequest(
                    acsCredentialId: acsCredentialId,
                    acsEntranceIds: acsEntranceIds,
                    acsSystemId: acsSystemId,
                    connectedAccountId: connectedAccountId,
                    customerKey: customerKey,
                    limit: limit,
                    locationId: locationId,
                    pageCursor: pageCursor,
                    search: search,
                    spaceId: spaceId
                )
            );
        }

        /// <summary>
        /// Returns a list of all [access system entrances](https://docs.seam.co/low-level-apis/access-systems/retrieving-entrance-details).
        /// </summary>
        public async Task<List<AcsEntrance>> ListAsync(ListRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            return (await _seam.PostAsync<ListResponse>("/acs/entrances/list", requestOptions))
                .Data
                .AcsEntrances;
        }

        /// <summary>
        /// Returns a list of all [access system entrances](https://docs.seam.co/low-level-apis/access-systems/retrieving-entrance-details).
        /// </summary>
        public async Task<List<AcsEntrance>> ListAsync(
            string? acsCredentialId = default,
            List<string>? acsEntranceIds = default,
            string? acsSystemId = default,
            string? connectedAccountId = default,
            string? customerKey = default,
            int? limit = default,
            string? locationId = default,
            string? pageCursor = default,
            string? search = default,
            string? spaceId = default
        )
        {
            return (
                await ListAsync(
                    new ListRequest(
                        acsCredentialId: acsCredentialId,
                        acsEntranceIds: acsEntranceIds,
                        acsSystemId: acsSystemId,
                        connectedAccountId: connectedAccountId,
                        customerKey: customerKey,
                        limit: limit,
                        locationId: locationId,
                        pageCursor: pageCursor,
                        search: search,
                        spaceId: spaceId
                    )
                )
            );
        }

        /// <summary>
        /// Request parameters for List Credentials with Access to an Entrance.
        /// </summary>
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

            /// <summary>
            /// Conditions that credentials must meet to be included in the returned list.
            /// </summary>
            [JsonConverter(typeof(SafeStringEnumConverter))]
            public enum IncludeIfEnum
            {
                [EnumMember(Value = "unrecognized")]
                Unrecognized = 0,

                [EnumMember(Value = "visionline_metadata.is_valid")]
                VisionlineMetadataIsValid = 1,
            }

            /// <summary>
            /// ID of the entrance for which you want to list all credentials that grant access.
            /// </summary>
            [DataMember(Name = "acs_entrance_id", IsRequired = true, EmitDefaultValue = false)]
            public string AcsEntranceId { get; set; }

            /// <summary>
            /// Conditions that credentials must meet to be included in the returned list.
            /// </summary>
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

            /// <summary>
            /// OK
            /// </summary>
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

        /// <summary>
        /// Returns a list of all [credentials](https://docs.seam.co/low-level-apis/access-systems/managing-credentials) with access to a specified [entrance](https://docs.seam.co/low-level-apis/access-systems/retrieving-entrance-details).
        /// </summary>
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

        /// <summary>
        /// Returns a list of all [credentials](https://docs.seam.co/low-level-apis/access-systems/managing-credentials) with access to a specified [entrance](https://docs.seam.co/low-level-apis/access-systems/retrieving-entrance-details).
        /// </summary>
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

        /// <summary>
        /// Returns a list of all [credentials](https://docs.seam.co/low-level-apis/access-systems/managing-credentials) with access to a specified [entrance](https://docs.seam.co/low-level-apis/access-systems/retrieving-entrance-details).
        /// </summary>
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

        /// <summary>
        /// Returns a list of all [credentials](https://docs.seam.co/low-level-apis/access-systems/managing-credentials) with access to a specified [entrance](https://docs.seam.co/low-level-apis/access-systems/retrieving-entrance-details).
        /// </summary>
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

        /// <summary>
        /// Request parameters for Unlock an Entrance.
        /// </summary>
        [DataContract(Name = "unlockRequest_request")]
        public class UnlockRequest
        {
            [JsonConstructorAttribute]
            protected UnlockRequest() { }

            public UnlockRequest(string acsCredentialId = default, string acsEntranceId = default)
            {
                AcsCredentialId = acsCredentialId;
                AcsEntranceId = acsEntranceId;
            }

            /// <summary>
            /// ID of the cloud_key credential to use for the unlock operation.
            /// </summary>
            [DataMember(Name = "acs_credential_id", IsRequired = true, EmitDefaultValue = false)]
            public string AcsCredentialId { get; set; }

            /// <summary>
            /// ID of the entrance to unlock.
            /// </summary>
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

        [DataContract(Name = "unlockResponse_response")]
        public class UnlockResponse
        {
            [JsonConstructorAttribute]
            protected UnlockResponse() { }

            public UnlockResponse(ActionAttempt actionAttempt = default)
            {
                ActionAttempt = actionAttempt;
            }

            /// <summary>
            /// OK
            /// </summary>
            [DataMember(Name = "action_attempt", IsRequired = false, EmitDefaultValue = false)]
            public ActionAttempt ActionAttempt { get; set; }

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
        /// Remotely unlocks a specified [entrance](https://docs.seam.co/low-level-apis/access-systems/retrieving-entrance-details) using a cloud_key credential. Returns an action attempt that tracks the progress of the unlock operation.
        /// </summary>
        public ActionAttempt Unlock(UnlockRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            return _seam
                .Post<UnlockResponse>("/acs/entrances/unlock", requestOptions)
                .Data.ActionAttempt;
        }

        /// <summary>
        /// Remotely unlocks a specified [entrance](https://docs.seam.co/low-level-apis/access-systems/retrieving-entrance-details) using a cloud_key credential. Returns an action attempt that tracks the progress of the unlock operation.
        /// </summary>
        public ActionAttempt Unlock(
            string acsCredentialId = default,
            string acsEntranceId = default
        )
        {
            return Unlock(
                new UnlockRequest(acsCredentialId: acsCredentialId, acsEntranceId: acsEntranceId)
            );
        }

        /// <summary>
        /// Remotely unlocks a specified [entrance](https://docs.seam.co/low-level-apis/access-systems/retrieving-entrance-details) using a cloud_key credential. Returns an action attempt that tracks the progress of the unlock operation.
        /// </summary>
        public async Task<ActionAttempt> UnlockAsync(UnlockRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            return (await _seam.PostAsync<UnlockResponse>("/acs/entrances/unlock", requestOptions))
                .Data
                .ActionAttempt;
        }

        /// <summary>
        /// Remotely unlocks a specified [entrance](https://docs.seam.co/low-level-apis/access-systems/retrieving-entrance-details) using a cloud_key credential. Returns an action attempt that tracks the progress of the unlock operation.
        /// </summary>
        public async Task<ActionAttempt> UnlockAsync(
            string acsCredentialId = default,
            string acsEntranceId = default
        )
        {
            return (
                await UnlockAsync(
                    new UnlockRequest(
                        acsCredentialId: acsCredentialId,
                        acsEntranceId: acsEntranceId
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
