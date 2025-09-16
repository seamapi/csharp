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
                MobileKey = 3
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

        [DataContract(Name = "listRequest_request")]
        public class ListRequest
        {
            [JsonConstructorAttribute]
            protected ListRequest() { }

            public ListRequest(
                string? accessGrantKey = default,
                string? acsEntranceId = default,
                string? acsSystemId = default,
                string? customerKey = default,
                string? locationId = default,
                string? spaceId = default,
                string? userIdentityId = default
            )
            {
                AccessGrantKey = accessGrantKey;
                AcsEntranceId = acsEntranceId;
                AcsSystemId = acsSystemId;
                CustomerKey = customerKey;
                LocationId = locationId;
                SpaceId = spaceId;
                UserIdentityId = userIdentityId;
            }

            [DataMember(Name = "access_grant_key", IsRequired = false, EmitDefaultValue = false)]
            public string? AccessGrantKey { get; set; }

            [DataMember(Name = "acs_entrance_id", IsRequired = false, EmitDefaultValue = false)]
            public string? AcsEntranceId { get; set; }

            [DataMember(Name = "acs_system_id", IsRequired = false, EmitDefaultValue = false)]
            public string? AcsSystemId { get; set; }

            [DataMember(Name = "customer_key", IsRequired = false, EmitDefaultValue = false)]
            public string? CustomerKey { get; set; }

            [DataMember(Name = "location_id", IsRequired = false, EmitDefaultValue = false)]
            public string? LocationId { get; set; }

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
            string? accessGrantKey = default,
            string? acsEntranceId = default,
            string? acsSystemId = default,
            string? customerKey = default,
            string? locationId = default,
            string? spaceId = default,
            string? userIdentityId = default
        )
        {
            return List(
                new ListRequest(
                    accessGrantKey: accessGrantKey,
                    acsEntranceId: acsEntranceId,
                    acsSystemId: acsSystemId,
                    customerKey: customerKey,
                    locationId: locationId,
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
            string? accessGrantKey = default,
            string? acsEntranceId = default,
            string? acsSystemId = default,
            string? customerKey = default,
            string? locationId = default,
            string? spaceId = default,
            string? userIdentityId = default
        )
        {
            return (
                await ListAsync(
                    new ListRequest(
                        accessGrantKey: accessGrantKey,
                        acsEntranceId: acsEntranceId,
                        acsSystemId: acsSystemId,
                        customerKey: customerKey,
                        locationId: locationId,
                        spaceId: spaceId,
                        userIdentityId: userIdentityId
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
