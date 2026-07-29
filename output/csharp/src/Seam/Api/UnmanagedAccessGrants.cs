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
    public class UnmanagedAccessGrants
    {
        private ISeamClient _seam;

        public UnmanagedAccessGrants(ISeamClient seam)
        {
            _seam = seam;
        }

        /// <summary>
        /// Request parameters for Get an Unmanaged Access Grant.
        /// </summary>
        [DataContract(Name = "getRequest_request")]
        public class GetRequest
        {
            [JsonConstructorAttribute]
            protected GetRequest() { }

            public GetRequest(string accessGrantId = default)
            {
                AccessGrantId = accessGrantId;
            }

            /// <summary>
            /// ID of unmanaged Access Grant to get.
            /// </summary>
            [DataMember(Name = "access_grant_id", IsRequired = true, EmitDefaultValue = false)]
            public string AccessGrantId { get; set; }

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

            public GetResponse(AccessGrant accessGrant = default)
            {
                AccessGrant = accessGrant;
            }

            /// <summary>
            /// OK
            /// </summary>
            [DataMember(Name = "access_grant", IsRequired = false, EmitDefaultValue = false)]
            public AccessGrant AccessGrant { get; set; }

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
        /// Get an unmanaged Access Grant (where is_managed = false).
        /// </summary>
        public AccessGrant Get(GetRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            return _seam
                .Post<GetResponse>("/access_grants/unmanaged/get", requestOptions)
                .Data.AccessGrant;
        }

        /// <summary>
        /// Get an unmanaged Access Grant (where is_managed = false).
        /// </summary>
        public AccessGrant Get(string accessGrantId = default)
        {
            return Get(new GetRequest(accessGrantId: accessGrantId));
        }

        /// <summary>
        /// Get an unmanaged Access Grant (where is_managed = false).
        /// </summary>
        public async Task<AccessGrant> GetAsync(GetRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            return (
                await _seam.PostAsync<GetResponse>("/access_grants/unmanaged/get", requestOptions)
            )
                .Data
                .AccessGrant;
        }

        /// <summary>
        /// Get an unmanaged Access Grant (where is_managed = false).
        /// </summary>
        public async Task<AccessGrant> GetAsync(string accessGrantId = default)
        {
            return (await GetAsync(new GetRequest(accessGrantId: accessGrantId)));
        }

        /// <summary>
        /// Request parameters for List Unmanaged Access Grants.
        /// </summary>
        [DataContract(Name = "listRequest_request")]
        public class ListRequest
        {
            [JsonConstructorAttribute]
            protected ListRequest() { }

            public ListRequest(
                string? acsEntranceId = default,
                string? acsSystemId = default,
                float? limit = default,
                string? pageCursor = default,
                string? reservationKey = default,
                string? userIdentityId = default
            )
            {
                AcsEntranceId = acsEntranceId;
                AcsSystemId = acsSystemId;
                Limit = limit;
                PageCursor = pageCursor;
                ReservationKey = reservationKey;
                UserIdentityId = userIdentityId;
            }

            /// <summary>
            /// ID of the entrance by which you want to filter the list of unmanaged Access Grants.
            /// </summary>
            [DataMember(Name = "acs_entrance_id", IsRequired = false, EmitDefaultValue = false)]
            public string? AcsEntranceId { get; set; }

            /// <summary>
            /// ID of the access system by which you want to filter the list of unmanaged Access Grants.
            /// </summary>
            [DataMember(Name = "acs_system_id", IsRequired = false, EmitDefaultValue = false)]
            public string? AcsSystemId { get; set; }

            /// <summary>
            /// Numerical limit on the number of unmanaged access grants to return.
            /// </summary>
            [DataMember(Name = "limit", IsRequired = false, EmitDefaultValue = false)]
            public float? Limit { get; set; }

            /// <summary>
            /// Identifies the specific page of results to return, obtained from the previous page&apos;s `next_page_cursor`.
            /// </summary>
            [DataMember(Name = "page_cursor", IsRequired = false, EmitDefaultValue = false)]
            public string? PageCursor { get; set; }

            /// <summary>
            /// Filter unmanaged Access Grants by reservation_key.
            /// </summary>
            [DataMember(Name = "reservation_key", IsRequired = false, EmitDefaultValue = false)]
            public string? ReservationKey { get; set; }

            /// <summary>
            /// ID of user identity by which you want to filter the list of unmanaged Access Grants.
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

            public ListResponse(List<object> accessGrants = default)
            {
                AccessGrants = accessGrants;
            }

            /// <summary>
            /// OK
            /// </summary>
            [DataMember(Name = "access_grants", IsRequired = false, EmitDefaultValue = false)]
            public List<object> AccessGrants { get; set; }

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
        /// Gets unmanaged Access Grants (where is_managed = false).
        /// </summary>
        public List<object> List(ListRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            return _seam
                .Post<ListResponse>("/access_grants/unmanaged/list", requestOptions)
                .Data.AccessGrants;
        }

        /// <summary>
        /// Gets unmanaged Access Grants (where is_managed = false).
        /// </summary>
        public List<object> List(
            string? acsEntranceId = default,
            string? acsSystemId = default,
            float? limit = default,
            string? pageCursor = default,
            string? reservationKey = default,
            string? userIdentityId = default
        )
        {
            return List(
                new ListRequest(
                    acsEntranceId: acsEntranceId,
                    acsSystemId: acsSystemId,
                    limit: limit,
                    pageCursor: pageCursor,
                    reservationKey: reservationKey,
                    userIdentityId: userIdentityId
                )
            );
        }

        /// <summary>
        /// Gets unmanaged Access Grants (where is_managed = false).
        /// </summary>
        public async Task<List<object>> ListAsync(ListRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            return (
                await _seam.PostAsync<ListResponse>("/access_grants/unmanaged/list", requestOptions)
            )
                .Data
                .AccessGrants;
        }

        /// <summary>
        /// Gets unmanaged Access Grants (where is_managed = false).
        /// </summary>
        public async Task<List<object>> ListAsync(
            string? acsEntranceId = default,
            string? acsSystemId = default,
            float? limit = default,
            string? pageCursor = default,
            string? reservationKey = default,
            string? userIdentityId = default
        )
        {
            return (
                await ListAsync(
                    new ListRequest(
                        acsEntranceId: acsEntranceId,
                        acsSystemId: acsSystemId,
                        limit: limit,
                        pageCursor: pageCursor,
                        reservationKey: reservationKey,
                        userIdentityId: userIdentityId
                    )
                )
            );
        }

        /// <summary>
        /// Request parameters for Update an Unmanaged Access Grant.
        /// </summary>
        [DataContract(Name = "updateRequest_request")]
        public class UpdateRequest
        {
            [JsonConstructorAttribute]
            protected UpdateRequest() { }

            public UpdateRequest(
                string accessGrantId = default,
                string? accessGrantKey = default,
                bool isManaged = default
            )
            {
                AccessGrantId = accessGrantId;
                AccessGrantKey = accessGrantKey;
                IsManaged = isManaged;
            }

            /// <summary>
            /// ID of the unmanaged Access Grant to update.
            /// </summary>
            [DataMember(Name = "access_grant_id", IsRequired = true, EmitDefaultValue = false)]
            public string AccessGrantId { get; set; }

            /// <summary>
            /// Unique key for the access grant. If not provided, the existing key will be preserved.
            /// </summary>
            [DataMember(Name = "access_grant_key", IsRequired = false, EmitDefaultValue = false)]
            public string? AccessGrantKey { get; set; }

            /// <summary>
            /// Must be set to true to convert the unmanaged access grant to managed.
            /// </summary>
            [DataMember(Name = "is_managed", IsRequired = true, EmitDefaultValue = false)]
            public bool IsManaged { get; set; }

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
        /// Updates an unmanaged Access Grant to make it managed.
        ///
        /// This endpoint can only be used to convert unmanaged access grants to managed ones by setting `is_managed` to `true`. It cannot be used to convert managed access grants back to unmanaged.
        ///
        /// When converting an unmanaged access grant to managed, all associated access methods will also be converted to managed.
        /// </summary>
        public void Update(UpdateRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            _seam.Post<object>("/access_grants/unmanaged/update", requestOptions);
        }

        /// <summary>
        /// Updates an unmanaged Access Grant to make it managed.
        ///
        /// This endpoint can only be used to convert unmanaged access grants to managed ones by setting `is_managed` to `true`. It cannot be used to convert managed access grants back to unmanaged.
        ///
        /// When converting an unmanaged access grant to managed, all associated access methods will also be converted to managed.
        /// </summary>
        public void Update(
            string accessGrantId = default,
            string? accessGrantKey = default,
            bool isManaged = default
        )
        {
            Update(
                new UpdateRequest(
                    accessGrantId: accessGrantId,
                    accessGrantKey: accessGrantKey,
                    isManaged: isManaged
                )
            );
        }

        /// <summary>
        /// Updates an unmanaged Access Grant to make it managed.
        ///
        /// This endpoint can only be used to convert unmanaged access grants to managed ones by setting `is_managed` to `true`. It cannot be used to convert managed access grants back to unmanaged.
        ///
        /// When converting an unmanaged access grant to managed, all associated access methods will also be converted to managed.
        /// </summary>
        public async Task UpdateAsync(UpdateRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            await _seam.PostAsync<object>("/access_grants/unmanaged/update", requestOptions);
        }

        /// <summary>
        /// Updates an unmanaged Access Grant to make it managed.
        ///
        /// This endpoint can only be used to convert unmanaged access grants to managed ones by setting `is_managed` to `true`. It cannot be used to convert managed access grants back to unmanaged.
        ///
        /// When converting an unmanaged access grant to managed, all associated access methods will also be converted to managed.
        /// </summary>
        public async Task UpdateAsync(
            string accessGrantId = default,
            string? accessGrantKey = default,
            bool isManaged = default
        )
        {
            await UpdateAsync(
                new UpdateRequest(
                    accessGrantId: accessGrantId,
                    accessGrantKey: accessGrantKey,
                    isManaged: isManaged
                )
            );
        }
    }
}

namespace Seam.Client
{
    public partial class SeamClient
    {
        public Api.UnmanagedAccessGrants UnmanagedAccessGrants => new(this);
    }

    public partial interface ISeamClient
    {
        public Api.UnmanagedAccessGrants UnmanagedAccessGrants { get; }
    }
}
