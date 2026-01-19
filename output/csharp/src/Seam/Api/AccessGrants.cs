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
    public class AccessGrants
    {
        private ISeamClient _seam;

        public AccessGrants(ISeamClient seam)
        {
            _seam = seam;
        }

        [DataContract(Name = "createRequest_request")]
        public class CreateRequest
        {
            [JsonConstructorAttribute]
            protected CreateRequest() { }

            public CreateRequest(
                string? userIdentityId = default,
                CreateRequestUserIdentity? userIdentity = default,
                string? accessGrantKey = default,
                List<string>? acsEntranceIds = default,
                string? customizationProfileId = default,
                List<string>? deviceIds = default,
                string? endsAt = default,
                CreateRequestLocation? location = default,
                List<string>? locationIds = default,
                string? name = default,
                List<CreateRequestRequestedAccessMethods> requestedAccessMethods = default,
                string? reservationKey = default,
                List<string>? spaceIds = default,
                List<string>? spaceKeys = default,
                string? startsAt = default
            )
            {
                UserIdentityId = userIdentityId;
                UserIdentity = userIdentity;
                AccessGrantKey = accessGrantKey;
                AcsEntranceIds = acsEntranceIds;
                CustomizationProfileId = customizationProfileId;
                DeviceIds = deviceIds;
                EndsAt = endsAt;
                Location = location;
                LocationIds = locationIds;
                Name = name;
                RequestedAccessMethods = requestedAccessMethods;
                ReservationKey = reservationKey;
                SpaceIds = spaceIds;
                SpaceKeys = spaceKeys;
                StartsAt = startsAt;
            }

            [DataMember(Name = "user_identity_id", IsRequired = false, EmitDefaultValue = false)]
            public string? UserIdentityId { get; set; }

            [DataMember(Name = "user_identity", IsRequired = false, EmitDefaultValue = false)]
            public CreateRequestUserIdentity? UserIdentity { get; set; }

            [DataMember(Name = "access_grant_key", IsRequired = false, EmitDefaultValue = false)]
            public string? AccessGrantKey { get; set; }

            [DataMember(Name = "acs_entrance_ids", IsRequired = false, EmitDefaultValue = false)]
            public List<string>? AcsEntranceIds { get; set; }

            [DataMember(
                Name = "customization_profile_id",
                IsRequired = false,
                EmitDefaultValue = false
            )]
            public string? CustomizationProfileId { get; set; }

            [DataMember(Name = "device_ids", IsRequired = false, EmitDefaultValue = false)]
            public List<string>? DeviceIds { get; set; }

            [DataMember(Name = "ends_at", IsRequired = false, EmitDefaultValue = false)]
            public string? EndsAt { get; set; }

            [DataMember(Name = "location", IsRequired = false, EmitDefaultValue = false)]
            public CreateRequestLocation? Location { get; set; }

            [DataMember(Name = "location_ids", IsRequired = false, EmitDefaultValue = false)]
            public List<string>? LocationIds { get; set; }

            [DataMember(Name = "name", IsRequired = false, EmitDefaultValue = false)]
            public string? Name { get; set; }

            [DataMember(
                Name = "requested_access_methods",
                IsRequired = true,
                EmitDefaultValue = false
            )]
            public List<CreateRequestRequestedAccessMethods> RequestedAccessMethods { get; set; }

            [DataMember(Name = "reservation_key", IsRequired = false, EmitDefaultValue = false)]
            public string? ReservationKey { get; set; }

            [DataMember(Name = "space_ids", IsRequired = false, EmitDefaultValue = false)]
            public List<string>? SpaceIds { get; set; }

            [DataMember(Name = "space_keys", IsRequired = false, EmitDefaultValue = false)]
            public List<string>? SpaceKeys { get; set; }

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

        [DataContract(Name = "createRequestUserIdentity_model")]
        public class CreateRequestUserIdentity
        {
            [JsonConstructorAttribute]
            protected CreateRequestUserIdentity() { }

            public CreateRequestUserIdentity(
                string? emailAddress = default,
                string? fullName = default,
                string? phoneNumber = default,
                string? userIdentityKey = default
            )
            {
                EmailAddress = emailAddress;
                FullName = fullName;
                PhoneNumber = phoneNumber;
                UserIdentityKey = userIdentityKey;
            }

            [DataMember(Name = "email_address", IsRequired = false, EmitDefaultValue = false)]
            public string? EmailAddress { get; set; }

            [DataMember(Name = "full_name", IsRequired = false, EmitDefaultValue = false)]
            public string? FullName { get; set; }

            [DataMember(Name = "phone_number", IsRequired = false, EmitDefaultValue = false)]
            public string? PhoneNumber { get; set; }

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

        [DataContract(Name = "createRequestLocation_model")]
        public class CreateRequestLocation
        {
            [JsonConstructorAttribute]
            protected CreateRequestLocation() { }

            public CreateRequestLocation(
                List<string>? acsEntranceIds = default,
                List<string>? deviceIds = default,
                string? name = default
            )
            {
                AcsEntranceIds = acsEntranceIds;
                DeviceIds = deviceIds;
                Name = name;
            }

            [DataMember(Name = "acs_entrance_ids", IsRequired = false, EmitDefaultValue = false)]
            public List<string>? AcsEntranceIds { get; set; }

            [DataMember(Name = "device_ids", IsRequired = false, EmitDefaultValue = false)]
            public List<string>? DeviceIds { get; set; }

            [DataMember(Name = "name", IsRequired = false, EmitDefaultValue = false)]
            public string? Name { get; set; }

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

        [DataContract(Name = "createRequestRequestedAccessMethods_model")]
        public class CreateRequestRequestedAccessMethods
        {
            [JsonConstructorAttribute]
            protected CreateRequestRequestedAccessMethods() { }

            public CreateRequestRequestedAccessMethods(
                string? code = default,
                CreateRequestRequestedAccessMethods.ModeEnum mode = default
            )
            {
                Code = code;
                Mode = mode;
            }

            [JsonConverter(typeof(SafeStringEnumConverter))]
            public enum ModeEnum
            {
                [EnumMember(Value = "unrecognized")]
                Unrecognized = 0,

                [EnumMember(Value = "code")]
                Code = 1,

                [EnumMember(Value = "card")]
                Card = 2,

                [EnumMember(Value = "mobile_key")]
                MobileKey = 3,
            }

            [DataMember(Name = "code", IsRequired = false, EmitDefaultValue = false)]
            public string? Code { get; set; }

            [DataMember(Name = "mode", IsRequired = true, EmitDefaultValue = false)]
            public CreateRequestRequestedAccessMethods.ModeEnum Mode { get; set; }

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

            public CreateResponse(AccessGrant accessGrant = default)
            {
                AccessGrant = accessGrant;
            }

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

        public AccessGrant Create(CreateRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            return _seam
                .Post<CreateResponse>("/access_grants/create", requestOptions)
                .Data.AccessGrant;
        }

        public AccessGrant Create(
            string? userIdentityId = default,
            CreateRequestUserIdentity? userIdentity = default,
            string? accessGrantKey = default,
            List<string>? acsEntranceIds = default,
            string? customizationProfileId = default,
            List<string>? deviceIds = default,
            string? endsAt = default,
            CreateRequestLocation? location = default,
            List<string>? locationIds = default,
            string? name = default,
            List<CreateRequestRequestedAccessMethods> requestedAccessMethods = default,
            string? reservationKey = default,
            List<string>? spaceIds = default,
            List<string>? spaceKeys = default,
            string? startsAt = default
        )
        {
            return Create(
                new CreateRequest(
                    userIdentityId: userIdentityId,
                    userIdentity: userIdentity,
                    accessGrantKey: accessGrantKey,
                    acsEntranceIds: acsEntranceIds,
                    customizationProfileId: customizationProfileId,
                    deviceIds: deviceIds,
                    endsAt: endsAt,
                    location: location,
                    locationIds: locationIds,
                    name: name,
                    requestedAccessMethods: requestedAccessMethods,
                    reservationKey: reservationKey,
                    spaceIds: spaceIds,
                    spaceKeys: spaceKeys,
                    startsAt: startsAt
                )
            );
        }

        public async Task<AccessGrant> CreateAsync(CreateRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            return (await _seam.PostAsync<CreateResponse>("/access_grants/create", requestOptions))
                .Data
                .AccessGrant;
        }

        public async Task<AccessGrant> CreateAsync(
            string? userIdentityId = default,
            CreateRequestUserIdentity? userIdentity = default,
            string? accessGrantKey = default,
            List<string>? acsEntranceIds = default,
            string? customizationProfileId = default,
            List<string>? deviceIds = default,
            string? endsAt = default,
            CreateRequestLocation? location = default,
            List<string>? locationIds = default,
            string? name = default,
            List<CreateRequestRequestedAccessMethods> requestedAccessMethods = default,
            string? reservationKey = default,
            List<string>? spaceIds = default,
            List<string>? spaceKeys = default,
            string? startsAt = default
        )
        {
            return (
                await CreateAsync(
                    new CreateRequest(
                        userIdentityId: userIdentityId,
                        userIdentity: userIdentity,
                        accessGrantKey: accessGrantKey,
                        acsEntranceIds: acsEntranceIds,
                        customizationProfileId: customizationProfileId,
                        deviceIds: deviceIds,
                        endsAt: endsAt,
                        location: location,
                        locationIds: locationIds,
                        name: name,
                        requestedAccessMethods: requestedAccessMethods,
                        reservationKey: reservationKey,
                        spaceIds: spaceIds,
                        spaceKeys: spaceKeys,
                        startsAt: startsAt
                    )
                )
            );
        }

        [DataContract(Name = "deleteRequest_request")]
        public class DeleteRequest
        {
            [JsonConstructorAttribute]
            protected DeleteRequest() { }

            public DeleteRequest(string accessGrantId = default)
            {
                AccessGrantId = accessGrantId;
            }

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

        public void Delete(DeleteRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            _seam.Post<object>("/access_grants/delete", requestOptions);
        }

        public void Delete(string accessGrantId = default)
        {
            Delete(new DeleteRequest(accessGrantId: accessGrantId));
        }

        public async Task DeleteAsync(DeleteRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            await _seam.PostAsync<object>("/access_grants/delete", requestOptions);
        }

        public async Task DeleteAsync(string accessGrantId = default)
        {
            await DeleteAsync(new DeleteRequest(accessGrantId: accessGrantId));
        }

        [DataContract(Name = "getRequest_request")]
        public class GetRequest
        {
            [JsonConstructorAttribute]
            protected GetRequest() { }

            public GetRequest(string? accessGrantId = default, string? accessGrantKey = default)
            {
                AccessGrantId = accessGrantId;
                AccessGrantKey = accessGrantKey;
            }

            [DataMember(Name = "access_grant_id", IsRequired = false, EmitDefaultValue = false)]
            public string? AccessGrantId { get; set; }

            [DataMember(Name = "access_grant_key", IsRequired = false, EmitDefaultValue = false)]
            public string? AccessGrantKey { get; set; }

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

        public AccessGrant Get(GetRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            return _seam.Post<GetResponse>("/access_grants/get", requestOptions).Data.AccessGrant;
        }

        public AccessGrant Get(string? accessGrantId = default, string? accessGrantKey = default)
        {
            return Get(
                new GetRequest(accessGrantId: accessGrantId, accessGrantKey: accessGrantKey)
            );
        }

        public async Task<AccessGrant> GetAsync(GetRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            return (await _seam.PostAsync<GetResponse>("/access_grants/get", requestOptions))
                .Data
                .AccessGrant;
        }

        public async Task<AccessGrant> GetAsync(
            string? accessGrantId = default,
            string? accessGrantKey = default
        )
        {
            return (
                await GetAsync(
                    new GetRequest(accessGrantId: accessGrantId, accessGrantKey: accessGrantKey)
                )
            );
        }

        [DataContract(Name = "getRelatedRequest_request")]
        public class GetRelatedRequest
        {
            [JsonConstructorAttribute]
            protected GetRelatedRequest() { }

            public GetRelatedRequest(
                List<string> accessGrantIds = default,
                List<GetRelatedRequest.ExcludeEnum>? exclude = default,
                List<GetRelatedRequest.IncludeEnum>? include = default
            )
            {
                AccessGrantIds = accessGrantIds;
                Exclude = exclude;
                Include = include;
            }

            [JsonConverter(typeof(SafeStringEnumConverter))]
            public enum ExcludeEnum
            {
                [EnumMember(Value = "unrecognized")]
                Unrecognized = 0,

                [EnumMember(Value = "spaces")]
                Spaces = 1,

                [EnumMember(Value = "devices")]
                Devices = 2,

                [EnumMember(Value = "acs_entrances")]
                AcsEntrances = 3,

                [EnumMember(Value = "connected_accounts")]
                ConnectedAccounts = 4,

                [EnumMember(Value = "acs_systems")]
                AcsSystems = 5,

                [EnumMember(Value = "user_identities")]
                UserIdentities = 6,

                [EnumMember(Value = "acs_access_groups")]
                AcsAccessGroups = 7,
            }

            [JsonConverter(typeof(SafeStringEnumConverter))]
            public enum IncludeEnum
            {
                [EnumMember(Value = "unrecognized")]
                Unrecognized = 0,

                [EnumMember(Value = "spaces")]
                Spaces = 1,

                [EnumMember(Value = "devices")]
                Devices = 2,

                [EnumMember(Value = "acs_entrances")]
                AcsEntrances = 3,

                [EnumMember(Value = "connected_accounts")]
                ConnectedAccounts = 4,

                [EnumMember(Value = "acs_systems")]
                AcsSystems = 5,

                [EnumMember(Value = "user_identities")]
                UserIdentities = 6,

                [EnumMember(Value = "acs_access_groups")]
                AcsAccessGroups = 7,
            }

            [DataMember(Name = "access_grant_ids", IsRequired = true, EmitDefaultValue = false)]
            public List<string> AccessGrantIds { get; set; }

            [DataMember(Name = "exclude", IsRequired = false, EmitDefaultValue = false)]
            public List<GetRelatedRequest.ExcludeEnum>? Exclude { get; set; }

            [DataMember(Name = "include", IsRequired = false, EmitDefaultValue = false)]
            public List<GetRelatedRequest.IncludeEnum>? Include { get; set; }

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

        [DataContract(Name = "getRelatedResponse_response")]
        public class GetRelatedResponse
        {
            [JsonConstructorAttribute]
            protected GetRelatedResponse() { }

            public GetRelatedResponse(Batch batch = default)
            {
                Batch = batch;
            }

            [DataMember(Name = "batch", IsRequired = false, EmitDefaultValue = false)]
            public Batch Batch { get; set; }

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

        public Batch GetRelated(GetRelatedRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            return _seam
                .Post<GetRelatedResponse>("/access_grants/get_related", requestOptions)
                .Data.Batch;
        }

        public Batch GetRelated(
            List<string> accessGrantIds = default,
            List<GetRelatedRequest.ExcludeEnum>? exclude = default,
            List<GetRelatedRequest.IncludeEnum>? include = default
        )
        {
            return GetRelated(
                new GetRelatedRequest(
                    accessGrantIds: accessGrantIds,
                    exclude: exclude,
                    include: include
                )
            );
        }

        public async Task<Batch> GetRelatedAsync(GetRelatedRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            return (
                await _seam.PostAsync<GetRelatedResponse>(
                    "/access_grants/get_related",
                    requestOptions
                )
            )
                .Data
                .Batch;
        }

        public async Task<Batch> GetRelatedAsync(
            List<string> accessGrantIds = default,
            List<GetRelatedRequest.ExcludeEnum>? exclude = default,
            List<GetRelatedRequest.IncludeEnum>? include = default
        )
        {
            return (
                await GetRelatedAsync(
                    new GetRelatedRequest(
                        accessGrantIds: accessGrantIds,
                        exclude: exclude,
                        include: include
                    )
                )
            );
        }

        [DataContract(Name = "listRequest_request")]
        public class ListRequest
        {
            [JsonConstructorAttribute]
            protected ListRequest() { }

            public ListRequest(
                List<string>? accessGrantIds = default,
                string? accessGrantKey = default,
                string? acsEntranceId = default,
                string? acsSystemId = default,
                string? customerKey = default,
                float? limit = default,
                string? locationId = default,
                string? pageCursor = default,
                string? reservationKey = default,
                string? spaceId = default,
                string? userIdentityId = default
            )
            {
                AccessGrantIds = accessGrantIds;
                AccessGrantKey = accessGrantKey;
                AcsEntranceId = acsEntranceId;
                AcsSystemId = acsSystemId;
                CustomerKey = customerKey;
                Limit = limit;
                LocationId = locationId;
                PageCursor = pageCursor;
                ReservationKey = reservationKey;
                SpaceId = spaceId;
                UserIdentityId = userIdentityId;
            }

            [DataMember(Name = "access_grant_ids", IsRequired = false, EmitDefaultValue = false)]
            public List<string>? AccessGrantIds { get; set; }

            [DataMember(Name = "access_grant_key", IsRequired = false, EmitDefaultValue = false)]
            public string? AccessGrantKey { get; set; }

            [DataMember(Name = "acs_entrance_id", IsRequired = false, EmitDefaultValue = false)]
            public string? AcsEntranceId { get; set; }

            [DataMember(Name = "acs_system_id", IsRequired = false, EmitDefaultValue = false)]
            public string? AcsSystemId { get; set; }

            [DataMember(Name = "customer_key", IsRequired = false, EmitDefaultValue = false)]
            public string? CustomerKey { get; set; }

            [DataMember(Name = "limit", IsRequired = false, EmitDefaultValue = false)]
            public float? Limit { get; set; }

            [DataMember(Name = "location_id", IsRequired = false, EmitDefaultValue = false)]
            public string? LocationId { get; set; }

            [DataMember(Name = "page_cursor", IsRequired = false, EmitDefaultValue = false)]
            public string? PageCursor { get; set; }

            [DataMember(Name = "reservation_key", IsRequired = false, EmitDefaultValue = false)]
            public string? ReservationKey { get; set; }

            [DataMember(Name = "space_id", IsRequired = false, EmitDefaultValue = false)]
            public string? SpaceId { get; set; }

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

            public ListResponse(List<AccessGrant> accessGrants = default)
            {
                AccessGrants = accessGrants;
            }

            [DataMember(Name = "access_grants", IsRequired = false, EmitDefaultValue = false)]
            public List<AccessGrant> AccessGrants { get; set; }

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

        public List<AccessGrant> List(ListRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            return _seam
                .Post<ListResponse>("/access_grants/list", requestOptions)
                .Data.AccessGrants;
        }

        public List<AccessGrant> List(
            List<string>? accessGrantIds = default,
            string? accessGrantKey = default,
            string? acsEntranceId = default,
            string? acsSystemId = default,
            string? customerKey = default,
            float? limit = default,
            string? locationId = default,
            string? pageCursor = default,
            string? reservationKey = default,
            string? spaceId = default,
            string? userIdentityId = default
        )
        {
            return List(
                new ListRequest(
                    accessGrantIds: accessGrantIds,
                    accessGrantKey: accessGrantKey,
                    acsEntranceId: acsEntranceId,
                    acsSystemId: acsSystemId,
                    customerKey: customerKey,
                    limit: limit,
                    locationId: locationId,
                    pageCursor: pageCursor,
                    reservationKey: reservationKey,
                    spaceId: spaceId,
                    userIdentityId: userIdentityId
                )
            );
        }

        public async Task<List<AccessGrant>> ListAsync(ListRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            return (await _seam.PostAsync<ListResponse>("/access_grants/list", requestOptions))
                .Data
                .AccessGrants;
        }

        public async Task<List<AccessGrant>> ListAsync(
            List<string>? accessGrantIds = default,
            string? accessGrantKey = default,
            string? acsEntranceId = default,
            string? acsSystemId = default,
            string? customerKey = default,
            float? limit = default,
            string? locationId = default,
            string? pageCursor = default,
            string? reservationKey = default,
            string? spaceId = default,
            string? userIdentityId = default
        )
        {
            return (
                await ListAsync(
                    new ListRequest(
                        accessGrantIds: accessGrantIds,
                        accessGrantKey: accessGrantKey,
                        acsEntranceId: acsEntranceId,
                        acsSystemId: acsSystemId,
                        customerKey: customerKey,
                        limit: limit,
                        locationId: locationId,
                        pageCursor: pageCursor,
                        reservationKey: reservationKey,
                        spaceId: spaceId,
                        userIdentityId: userIdentityId
                    )
                )
            );
        }

        [DataContract(Name = "requestAccessMethodsRequest_request")]
        public class RequestAccessMethodsRequest
        {
            [JsonConstructorAttribute]
            protected RequestAccessMethodsRequest() { }

            public RequestAccessMethodsRequest(
                string accessGrantId = default,
                List<RequestAccessMethodsRequestRequestedAccessMethods> requestedAccessMethods =
                    default
            )
            {
                AccessGrantId = accessGrantId;
                RequestedAccessMethods = requestedAccessMethods;
            }

            [DataMember(Name = "access_grant_id", IsRequired = true, EmitDefaultValue = false)]
            public string AccessGrantId { get; set; }

            [DataMember(
                Name = "requested_access_methods",
                IsRequired = true,
                EmitDefaultValue = false
            )]
            public List<RequestAccessMethodsRequestRequestedAccessMethods> RequestedAccessMethods { get; set; }

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

        [DataContract(Name = "requestAccessMethodsRequestRequestedAccessMethods_model")]
        public class RequestAccessMethodsRequestRequestedAccessMethods
        {
            [JsonConstructorAttribute]
            protected RequestAccessMethodsRequestRequestedAccessMethods() { }

            public RequestAccessMethodsRequestRequestedAccessMethods(
                string? code = default,
                RequestAccessMethodsRequestRequestedAccessMethods.ModeEnum mode = default
            )
            {
                Code = code;
                Mode = mode;
            }

            [JsonConverter(typeof(SafeStringEnumConverter))]
            public enum ModeEnum
            {
                [EnumMember(Value = "unrecognized")]
                Unrecognized = 0,

                [EnumMember(Value = "code")]
                Code = 1,

                [EnumMember(Value = "card")]
                Card = 2,

                [EnumMember(Value = "mobile_key")]
                MobileKey = 3,
            }

            [DataMember(Name = "code", IsRequired = false, EmitDefaultValue = false)]
            public string? Code { get; set; }

            [DataMember(Name = "mode", IsRequired = true, EmitDefaultValue = false)]
            public RequestAccessMethodsRequestRequestedAccessMethods.ModeEnum Mode { get; set; }

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

        [DataContract(Name = "requestAccessMethodsResponse_response")]
        public class RequestAccessMethodsResponse
        {
            [JsonConstructorAttribute]
            protected RequestAccessMethodsResponse() { }

            public RequestAccessMethodsResponse(AccessGrant accessGrant = default)
            {
                AccessGrant = accessGrant;
            }

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

        public AccessGrant RequestAccessMethods(RequestAccessMethodsRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            return _seam
                .Post<RequestAccessMethodsResponse>(
                    "/access_grants/request_access_methods",
                    requestOptions
                )
                .Data.AccessGrant;
        }

        public AccessGrant RequestAccessMethods(
            string accessGrantId = default,
            List<RequestAccessMethodsRequestRequestedAccessMethods> requestedAccessMethods = default
        )
        {
            return RequestAccessMethods(
                new RequestAccessMethodsRequest(
                    accessGrantId: accessGrantId,
                    requestedAccessMethods: requestedAccessMethods
                )
            );
        }

        public async Task<AccessGrant> RequestAccessMethodsAsync(
            RequestAccessMethodsRequest request
        )
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            return (
                await _seam.PostAsync<RequestAccessMethodsResponse>(
                    "/access_grants/request_access_methods",
                    requestOptions
                )
            )
                .Data
                .AccessGrant;
        }

        public async Task<AccessGrant> RequestAccessMethodsAsync(
            string accessGrantId = default,
            List<RequestAccessMethodsRequestRequestedAccessMethods> requestedAccessMethods = default
        )
        {
            return (
                await RequestAccessMethodsAsync(
                    new RequestAccessMethodsRequest(
                        accessGrantId: accessGrantId,
                        requestedAccessMethods: requestedAccessMethods
                    )
                )
            );
        }

        [DataContract(Name = "updateRequest_request")]
        public class UpdateRequest
        {
            [JsonConstructorAttribute]
            protected UpdateRequest() { }

            public UpdateRequest(
                string accessGrantId = default,
                string? endsAt = default,
                string? name = default,
                string? startsAt = default
            )
            {
                AccessGrantId = accessGrantId;
                EndsAt = endsAt;
                Name = name;
                StartsAt = startsAt;
            }

            [DataMember(Name = "access_grant_id", IsRequired = true, EmitDefaultValue = false)]
            public string AccessGrantId { get; set; }

            [DataMember(Name = "ends_at", IsRequired = false, EmitDefaultValue = false)]
            public string? EndsAt { get; set; }

            [DataMember(Name = "name", IsRequired = false, EmitDefaultValue = false)]
            public string? Name { get; set; }

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

        public void Update(UpdateRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            _seam.Post<object>("/access_grants/update", requestOptions);
        }

        public void Update(
            string accessGrantId = default,
            string? endsAt = default,
            string? name = default,
            string? startsAt = default
        )
        {
            Update(
                new UpdateRequest(
                    accessGrantId: accessGrantId,
                    endsAt: endsAt,
                    name: name,
                    startsAt: startsAt
                )
            );
        }

        public async Task UpdateAsync(UpdateRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            await _seam.PostAsync<object>("/access_grants/update", requestOptions);
        }

        public async Task UpdateAsync(
            string accessGrantId = default,
            string? endsAt = default,
            string? name = default,
            string? startsAt = default
        )
        {
            await UpdateAsync(
                new UpdateRequest(
                    accessGrantId: accessGrantId,
                    endsAt: endsAt,
                    name: name,
                    startsAt: startsAt
                )
            );
        }
    }
}

namespace Seam.Client
{
    public partial class SeamClient
    {
        public Api.AccessGrants AccessGrants => new(this);
    }

    public partial interface ISeamClient
    {
        public Api.AccessGrants AccessGrants { get; }
    }
}
