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

        /// <summary>
        /// Request parameters for Create an Access Grant.
        /// </summary>
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

            /// <summary>
            /// ID of user identity for whom access is being granted.
            /// </summary>
            [DataMember(Name = "user_identity_id", IsRequired = false, EmitDefaultValue = false)]
            public string? UserIdentityId { get; set; }

            /// <summary>
            /// When used, creates a new user identity with the given details, and grants them access.
            /// </summary>
            [DataMember(Name = "user_identity", IsRequired = false, EmitDefaultValue = false)]
            public CreateRequestUserIdentity? UserIdentity { get; set; }

            /// <summary>
            /// Unique key for the access grant within the workspace.
            /// </summary>
            [DataMember(Name = "access_grant_key", IsRequired = false, EmitDefaultValue = false)]
            public string? AccessGrantKey { get; set; }

            /// <summary>
            /// Set of IDs of the [entrances](https://docs.seam.co/api/acs/systems/list) to which access is being granted.
            /// </summary>
            [DataMember(Name = "acs_entrance_ids", IsRequired = false, EmitDefaultValue = false)]
            public List<string>? AcsEntranceIds { get; set; }

            /// <summary>
            /// ID of the customization profile to apply to the Access Grant and its access methods.
            /// </summary>
            [DataMember(
                Name = "customization_profile_id",
                IsRequired = false,
                EmitDefaultValue = false
            )]
            public string? CustomizationProfileId { get; set; }

            /// <summary>
            /// Set of IDs of the [devices](https://docs.seam.co/api/devices/list) to which access is being granted.
            /// </summary>
            [DataMember(Name = "device_ids", IsRequired = false, EmitDefaultValue = false)]
            public List<string>? DeviceIds { get; set; }

            /// <summary>
            /// Date and time at which the validity of the new grant ends, in [ISO 8601](https://www.iso.org/iso-8601-date-and-time-format.html) format. Must be a time in the future and after `starts_at`.
            /// </summary>
            [DataMember(Name = "ends_at", IsRequired = false, EmitDefaultValue = false)]
            public string? EndsAt { get; set; }

            [Obsolete("Create a space first, then reference it using `space_ids`.")]
            [DataMember(Name = "location", IsRequired = false, EmitDefaultValue = false)]
            public CreateRequestLocation? Location { get; set; }

            [Obsolete("Use `space_ids`.")]
            [DataMember(Name = "location_ids", IsRequired = false, EmitDefaultValue = false)]
            public List<string>? LocationIds { get; set; }

            /// <summary>
            /// Name for the access grant.
            /// </summary>
            [DataMember(Name = "name", IsRequired = false, EmitDefaultValue = false)]
            public string? Name { get; set; }

            [DataMember(
                Name = "requested_access_methods",
                IsRequired = true,
                EmitDefaultValue = false
            )]
            public List<CreateRequestRequestedAccessMethods> RequestedAccessMethods { get; set; }

            /// <summary>
            /// Reservation key for the access grant.
            /// </summary>
            [DataMember(Name = "reservation_key", IsRequired = false, EmitDefaultValue = false)]
            public string? ReservationKey { get; set; }

            /// <summary>
            /// Set of IDs of existing spaces to which access is being granted.
            /// </summary>
            [DataMember(Name = "space_ids", IsRequired = false, EmitDefaultValue = false)]
            public List<string>? SpaceIds { get; set; }

            /// <summary>
            /// Set of keys of existing spaces to which access is being granted.
            /// </summary>
            [DataMember(Name = "space_keys", IsRequired = false, EmitDefaultValue = false)]
            public List<string>? SpaceKeys { get; set; }

            /// <summary>
            /// Date and time at which the validity of the new grant starts, in [ISO 8601](https://www.iso.org/iso-8601-date-and-time-format.html) format.
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

            /// <summary>
            /// Unique email address for the user identity.
            /// </summary>
            [DataMember(Name = "email_address", IsRequired = false, EmitDefaultValue = false)]
            public string? EmailAddress { get; set; }

            /// <summary>
            /// Full name of the user associated with the user identity.
            /// </summary>
            [DataMember(Name = "full_name", IsRequired = false, EmitDefaultValue = false)]
            public string? FullName { get; set; }

            /// <summary>
            /// Unique phone number for the user identity in [E.164 format](https://www.itu.int/rec/T-REC-E.164/en) (for example, +15555550100).
            /// </summary>
            [DataMember(Name = "phone_number", IsRequired = false, EmitDefaultValue = false)]
            public string? PhoneNumber { get; set; }

            /// <summary>
            /// Unique key for the user identity.
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

            [Obsolete("Use `acs_entrance_ids` at the top level.")]
            [DataMember(Name = "acs_entrance_ids", IsRequired = false, EmitDefaultValue = false)]
            public List<string>? AcsEntranceIds { get; set; }

            [Obsolete("Use `device_ids` at the top level.")]
            [DataMember(Name = "device_ids", IsRequired = false, EmitDefaultValue = false)]
            public List<string>? DeviceIds { get; set; }

            /// <summary>
            /// Name of the location.
            /// </summary>
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
                int? instantKeyMaxUseCount = default,
                CreateRequestRequestedAccessMethods.ModeEnum? mode = default
            )
            {
                Code = code;
                InstantKeyMaxUseCount = instantKeyMaxUseCount;
                Mode = mode;
            }

            /// <summary>
            /// Access method mode. Supported values: `code`, `card`, `mobile_key`, `cloud_key`.
            /// </summary>
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

                [EnumMember(Value = "cloud_key")]
                CloudKey = 4,
            }

            /// <summary>
            /// Specific PIN code to use for this access method. Only applicable when mode is &apos;code&apos;.
            /// </summary>
            [DataMember(Name = "code", IsRequired = false, EmitDefaultValue = false)]
            public string? Code { get; set; }

            /// <summary>
            /// Maximum number of times the instant key can be used. Only applicable when mode is &apos;mobile_key&apos;. Defaults to 1 if not specified.
            /// </summary>
            [DataMember(
                Name = "instant_key_max_use_count",
                IsRequired = false,
                EmitDefaultValue = false
            )]
            public int? InstantKeyMaxUseCount { get; set; }

            /// <summary>
            /// Access method mode. Supported values: `code`, `card`, `mobile_key`, `cloud_key`.
            /// </summary>
            [DataMember(Name = "mode", IsRequired = false, EmitDefaultValue = false)]
            public CreateRequestRequestedAccessMethods.ModeEnum? Mode { get; set; }

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
        /// Creates a new [Access Grant](https://docs.seam.co/use-cases/granting-access/access-grants). Access Grants are the default and recommended way to grant a user access to any physical space, irrespective of the locking hardware. They work with both standalone smart locks (using `device_ids`) and access control systems (using `acs_entrance_ids` or `space_ids`), and can issue PIN codes, key cards, and mobile keys through a single request.
        /// </summary>
        public AccessGrant Create(CreateRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            return _seam
                .Post<CreateResponse>("/access_grants/create", requestOptions)
                .EnsureData("/access_grants/create")
                .AccessGrant;
        }

        /// <summary>
        /// Creates a new [Access Grant](https://docs.seam.co/use-cases/granting-access/access-grants). Access Grants are the default and recommended way to grant a user access to any physical space, irrespective of the locking hardware. They work with both standalone smart locks (using `device_ids`) and access control systems (using `acs_entrance_ids` or `space_ids`), and can issue PIN codes, key cards, and mobile keys through a single request.
        /// </summary>
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

        /// <summary>
        /// Creates a new [Access Grant](https://docs.seam.co/use-cases/granting-access/access-grants). Access Grants are the default and recommended way to grant a user access to any physical space, irrespective of the locking hardware. They work with both standalone smart locks (using `device_ids`) and access control systems (using `acs_entrance_ids` or `space_ids`), and can issue PIN codes, key cards, and mobile keys through a single request.
        /// </summary>
        public async Task<AccessGrant> CreateAsync(CreateRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            return (await _seam.PostAsync<CreateResponse>("/access_grants/create", requestOptions))
                .EnsureData("/access_grants/create")
                .AccessGrant;
        }

        /// <summary>
        /// Creates a new [Access Grant](https://docs.seam.co/use-cases/granting-access/access-grants). Access Grants are the default and recommended way to grant a user access to any physical space, irrespective of the locking hardware. They work with both standalone smart locks (using `device_ids`) and access control systems (using `acs_entrance_ids` or `space_ids`), and can issue PIN codes, key cards, and mobile keys through a single request.
        /// </summary>
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

        /// <summary>
        /// Request parameters for Delete an Access Grant.
        /// </summary>
        [DataContract(Name = "deleteRequest_request")]
        public class DeleteRequest
        {
            [JsonConstructorAttribute]
            protected DeleteRequest() { }

            public DeleteRequest(string accessGrantId = default)
            {
                AccessGrantId = accessGrantId;
            }

            /// <summary>
            /// ID of Access Grant to delete.
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

        /// <summary>
        /// Delete an Access Grant.
        /// </summary>
        public void Delete(DeleteRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            _seam.Post<object>("/access_grants/delete", requestOptions);
        }

        /// <summary>
        /// Delete an Access Grant.
        /// </summary>
        public void Delete(string accessGrantId = default)
        {
            Delete(new DeleteRequest(accessGrantId: accessGrantId));
        }

        /// <summary>
        /// Delete an Access Grant.
        /// </summary>
        public async Task DeleteAsync(DeleteRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            await _seam.PostAsync<object>("/access_grants/delete", requestOptions);
        }

        /// <summary>
        /// Delete an Access Grant.
        /// </summary>
        public async Task DeleteAsync(string accessGrantId = default)
        {
            await DeleteAsync(new DeleteRequest(accessGrantId: accessGrantId));
        }

        /// <summary>
        /// Request parameters for Get an Access Grant.
        /// </summary>
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

            /// <summary>
            /// ID of Access Grant to get.
            /// </summary>
            [DataMember(Name = "access_grant_id", IsRequired = false, EmitDefaultValue = false)]
            public string? AccessGrantId { get; set; }

            /// <summary>
            /// Unique key of Access Grant to get.
            /// </summary>
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
        /// Get an Access Grant.
        /// </summary>
        public AccessGrant Get(GetRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            return _seam
                .Get<GetResponse>("/access_grants/get", requestOptions)
                .EnsureData("/access_grants/get")
                .AccessGrant;
        }

        /// <summary>
        /// Get an Access Grant.
        /// </summary>
        public AccessGrant Get(string? accessGrantId = default, string? accessGrantKey = default)
        {
            return Get(
                new GetRequest(accessGrantId: accessGrantId, accessGrantKey: accessGrantKey)
            );
        }

        /// <summary>
        /// Get an Access Grant.
        /// </summary>
        public async Task<AccessGrant> GetAsync(GetRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            return (await _seam.GetAsync<GetResponse>("/access_grants/get", requestOptions))
                .EnsureData("/access_grants/get")
                .AccessGrant;
        }

        /// <summary>
        /// Get an Access Grant.
        /// </summary>
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

        /// <summary>
        /// Request parameters for Get related Access Grant resources.
        /// </summary>
        [DataContract(Name = "getRelatedRequest_request")]
        public class GetRelatedRequest
        {
            [JsonConstructorAttribute]
            protected GetRelatedRequest() { }

            public GetRelatedRequest(
                List<string>? accessGrantIds = default,
                List<string>? accessGrantKeys = default,
                List<GetRelatedRequest.ExcludeEnum>? exclude = default,
                List<GetRelatedRequest.IncludeEnum>? include = default
            )
            {
                AccessGrantIds = accessGrantIds;
                AccessGrantKeys = accessGrantKeys;
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

                [EnumMember(Value = "access_methods")]
                AccessMethods = 8,
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

                [EnumMember(Value = "access_methods")]
                AccessMethods = 8,
            }

            /// <summary>
            /// IDs of the access grants that you want to get along with their related resources.
            /// </summary>
            [DataMember(Name = "access_grant_ids", IsRequired = false, EmitDefaultValue = false)]
            public List<string>? AccessGrantIds { get; set; }

            /// <summary>
            /// Keys of the access grants that you want to get along with their related resources.
            /// </summary>
            [DataMember(Name = "access_grant_keys", IsRequired = false, EmitDefaultValue = false)]
            public List<string>? AccessGrantKeys { get; set; }

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

            /// <summary>
            /// OK
            /// </summary>
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

        /// <summary>
        /// Gets all related resources for one or more Access Grants.
        /// </summary>
        public Batch GetRelated(GetRelatedRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            return _seam
                .Post<GetRelatedResponse>("/access_grants/get_related", requestOptions)
                .EnsureData("/access_grants/get_related")
                .Batch;
        }

        /// <summary>
        /// Gets all related resources for one or more Access Grants.
        /// </summary>
        public Batch GetRelated(
            List<string>? accessGrantIds = default,
            List<string>? accessGrantKeys = default,
            List<GetRelatedRequest.ExcludeEnum>? exclude = default,
            List<GetRelatedRequest.IncludeEnum>? include = default
        )
        {
            return GetRelated(
                new GetRelatedRequest(
                    accessGrantIds: accessGrantIds,
                    accessGrantKeys: accessGrantKeys,
                    exclude: exclude,
                    include: include
                )
            );
        }

        /// <summary>
        /// Gets all related resources for one or more Access Grants.
        /// </summary>
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
                .EnsureData("/access_grants/get_related")
                .Batch;
        }

        /// <summary>
        /// Gets all related resources for one or more Access Grants.
        /// </summary>
        public async Task<Batch> GetRelatedAsync(
            List<string>? accessGrantIds = default,
            List<string>? accessGrantKeys = default,
            List<GetRelatedRequest.ExcludeEnum>? exclude = default,
            List<GetRelatedRequest.IncludeEnum>? include = default
        )
        {
            return (
                await GetRelatedAsync(
                    new GetRelatedRequest(
                        accessGrantIds: accessGrantIds,
                        accessGrantKeys: accessGrantKeys,
                        exclude: exclude,
                        include: include
                    )
                )
            );
        }

        /// <summary>
        /// Request parameters for List Access Grants.
        /// </summary>
        [DataContract(Name = "listRequest_request")]
        public class ListRequest
        {
            [JsonConstructorAttribute]
            protected ListRequest() { }

            public ListRequest(
                string? accessCodeId = default,
                List<string>? accessGrantIds = default,
                string? accessGrantKey = default,
                string? acsEntranceId = default,
                string? acsSystemId = default,
                string? customerKey = default,
                string? deviceId = default,
                float? limit = default,
                string? locationId = default,
                string? pageCursor = default,
                string? reservationKey = default,
                string? spaceId = default,
                string? userIdentityId = default
            )
            {
                AccessCodeId = accessCodeId;
                AccessGrantIds = accessGrantIds;
                AccessGrantKey = accessGrantKey;
                AcsEntranceId = acsEntranceId;
                AcsSystemId = acsSystemId;
                CustomerKey = customerKey;
                DeviceId = deviceId;
                Limit = limit;
                LocationId = locationId;
                PageCursor = pageCursor;
                ReservationKey = reservationKey;
                SpaceId = spaceId;
                UserIdentityId = userIdentityId;
            }

            /// <summary>
            /// ID of the access code by which you want to filter the list of Access Grants.
            /// </summary>
            [DataMember(Name = "access_code_id", IsRequired = false, EmitDefaultValue = false)]
            public string? AccessCodeId { get; set; }

            /// <summary>
            /// IDs of the access grants to retrieve.
            /// </summary>
            [DataMember(Name = "access_grant_ids", IsRequired = false, EmitDefaultValue = false)]
            public List<string>? AccessGrantIds { get; set; }

            /// <summary>
            /// Filter Access Grants by access_grant_key. Use null to filter for Access Grants without an access_grant_key.
            /// </summary>
            [DataMember(Name = "access_grant_key", IsRequired = false, EmitDefaultValue = false)]
            public string? AccessGrantKey { get; set; }

            /// <summary>
            /// ID of the entrance by which you want to filter the list of Access Grants.
            /// </summary>
            [DataMember(Name = "acs_entrance_id", IsRequired = false, EmitDefaultValue = false)]
            public string? AcsEntranceId { get; set; }

            /// <summary>
            /// ID of the access system by which you want to filter the list of Access Grants.
            /// </summary>
            [DataMember(Name = "acs_system_id", IsRequired = false, EmitDefaultValue = false)]
            public string? AcsSystemId { get; set; }

            /// <summary>
            /// Customer key for which you want to list access grants.
            /// </summary>
            [DataMember(Name = "customer_key", IsRequired = false, EmitDefaultValue = false)]
            public string? CustomerKey { get; set; }

            /// <summary>
            /// ID of the device by which you want to filter the list of Access Grants.
            /// </summary>
            [DataMember(Name = "device_id", IsRequired = false, EmitDefaultValue = false)]
            public string? DeviceId { get; set; }

            /// <summary>
            /// Numerical limit on the number of access grants to return.
            /// </summary>
            [DataMember(Name = "limit", IsRequired = false, EmitDefaultValue = false)]
            public float? Limit { get; set; }

            [Obsolete("Use `space_id`.")]
            [DataMember(Name = "location_id", IsRequired = false, EmitDefaultValue = false)]
            public string? LocationId { get; set; }

            /// <summary>
            /// Identifies the specific page of results to return, obtained from the previous page&apos;s `next_page_cursor`.
            /// </summary>
            [DataMember(Name = "page_cursor", IsRequired = false, EmitDefaultValue = false)]
            public string? PageCursor { get; set; }

            /// <summary>
            /// Filter Access Grants by reservation_key.
            /// </summary>
            [DataMember(Name = "reservation_key", IsRequired = false, EmitDefaultValue = false)]
            public string? ReservationKey { get; set; }

            /// <summary>
            /// ID of the space by which you want to filter the list of Access Grants.
            /// </summary>
            [DataMember(Name = "space_id", IsRequired = false, EmitDefaultValue = false)]
            public string? SpaceId { get; set; }

            /// <summary>
            /// ID of user identity by which you want to filter the list of Access Grants.
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

            public ListResponse(List<AccessGrant> accessGrants = default)
            {
                AccessGrants = accessGrants;
            }

            /// <summary>
            /// OK
            /// </summary>
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

        /// <summary>
        /// Gets an Access Grant.
        /// </summary>
        public List<AccessGrant> List(ListRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            return _seam
                .Post<ListResponse>("/access_grants/list", requestOptions)
                .EnsureData("/access_grants/list")
                .AccessGrants;
        }

        /// <summary>
        /// Gets an Access Grant.
        /// </summary>
        public List<AccessGrant> List(
            string? accessCodeId = default,
            List<string>? accessGrantIds = default,
            string? accessGrantKey = default,
            string? acsEntranceId = default,
            string? acsSystemId = default,
            string? customerKey = default,
            string? deviceId = default,
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
                    accessCodeId: accessCodeId,
                    accessGrantIds: accessGrantIds,
                    accessGrantKey: accessGrantKey,
                    acsEntranceId: acsEntranceId,
                    acsSystemId: acsSystemId,
                    customerKey: customerKey,
                    deviceId: deviceId,
                    limit: limit,
                    locationId: locationId,
                    pageCursor: pageCursor,
                    reservationKey: reservationKey,
                    spaceId: spaceId,
                    userIdentityId: userIdentityId
                )
            );
        }

        /// <summary>
        /// Gets an Access Grant.
        /// </summary>
        public async Task<List<AccessGrant>> ListAsync(ListRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            return (await _seam.PostAsync<ListResponse>("/access_grants/list", requestOptions))
                .EnsureData("/access_grants/list")
                .AccessGrants;
        }

        /// <summary>
        /// Gets an Access Grant.
        /// </summary>
        public async Task<List<AccessGrant>> ListAsync(
            string? accessCodeId = default,
            List<string>? accessGrantIds = default,
            string? accessGrantKey = default,
            string? acsEntranceId = default,
            string? acsSystemId = default,
            string? customerKey = default,
            string? deviceId = default,
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
                        accessCodeId: accessCodeId,
                        accessGrantIds: accessGrantIds,
                        accessGrantKey: accessGrantKey,
                        acsEntranceId: acsEntranceId,
                        acsSystemId: acsSystemId,
                        customerKey: customerKey,
                        deviceId: deviceId,
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

        /// <summary>
        /// Request parameters for Add Requested Access Methods to Access Grant.
        /// </summary>
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

            /// <summary>
            /// ID of the Access Grant to add access methods to.
            /// </summary>
            [DataMember(Name = "access_grant_id", IsRequired = true, EmitDefaultValue = false)]
            public string AccessGrantId { get; set; }

            /// <summary>
            /// Array of requested access methods to add to the access grant.
            /// </summary>
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
                int? instantKeyMaxUseCount = default,
                RequestAccessMethodsRequestRequestedAccessMethods.ModeEnum? mode = default
            )
            {
                Code = code;
                InstantKeyMaxUseCount = instantKeyMaxUseCount;
                Mode = mode;
            }

            /// <summary>
            /// Access method mode. Supported values: `code`, `card`, `mobile_key`, `cloud_key`.
            /// </summary>
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

                [EnumMember(Value = "cloud_key")]
                CloudKey = 4,
            }

            /// <summary>
            /// Specific PIN code to use for this access method. Only applicable when mode is &apos;code&apos;.
            /// </summary>
            [DataMember(Name = "code", IsRequired = false, EmitDefaultValue = false)]
            public string? Code { get; set; }

            /// <summary>
            /// Maximum number of times the instant key can be used. Only applicable when mode is &apos;mobile_key&apos;. Defaults to 1 if not specified.
            /// </summary>
            [DataMember(
                Name = "instant_key_max_use_count",
                IsRequired = false,
                EmitDefaultValue = false
            )]
            public int? InstantKeyMaxUseCount { get; set; }

            /// <summary>
            /// Access method mode. Supported values: `code`, `card`, `mobile_key`, `cloud_key`.
            /// </summary>
            [DataMember(Name = "mode", IsRequired = false, EmitDefaultValue = false)]
            public RequestAccessMethodsRequestRequestedAccessMethods.ModeEnum? Mode { get; set; }

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
        /// Adds additional requested access methods to an existing Access Grant.
        /// </summary>
        public AccessGrant RequestAccessMethods(RequestAccessMethodsRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            return _seam
                .Post<RequestAccessMethodsResponse>(
                    "/access_grants/request_access_methods",
                    requestOptions
                )
                .EnsureData("/access_grants/request_access_methods")
                .AccessGrant;
        }

        /// <summary>
        /// Adds additional requested access methods to an existing Access Grant.
        /// </summary>
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

        /// <summary>
        /// Adds additional requested access methods to an existing Access Grant.
        /// </summary>
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
                .EnsureData("/access_grants/request_access_methods")
                .AccessGrant;
        }

        /// <summary>
        /// Adds additional requested access methods to an existing Access Grant.
        /// </summary>
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

        /// <summary>
        /// Request parameters for Update an Access Grant.
        /// </summary>
        [DataContract(Name = "updateRequest_request")]
        public class UpdateRequest
        {
            [JsonConstructorAttribute]
            protected UpdateRequest() { }

            public UpdateRequest(
                string? accessGrantId = default,
                string? accessGrantKey = default,
                string? endsAt = default,
                string? name = default,
                string? startsAt = default
            )
            {
                AccessGrantId = accessGrantId;
                AccessGrantKey = accessGrantKey;
                EndsAt = endsAt;
                Name = name;
                StartsAt = startsAt;
            }

            /// <summary>
            /// ID of the Access Grant to update. Provide either `access_grant_id` or `access_grant_key`.
            /// </summary>
            [DataMember(Name = "access_grant_id", IsRequired = false, EmitDefaultValue = false)]
            public string? AccessGrantId { get; set; }

            /// <summary>
            /// Key of the Access Grant to update. Provide either `access_grant_id` or `access_grant_key`.
            /// </summary>
            [DataMember(Name = "access_grant_key", IsRequired = false, EmitDefaultValue = false)]
            public string? AccessGrantKey { get; set; }

            /// <summary>
            /// Date and time at which the validity of the grant ends, in [ISO 8601](https://www.iso.org/iso-8601-date-and-time-format.html) format. Must be a time in the future and after `starts_at`.
            /// </summary>
            [DataMember(Name = "ends_at", IsRequired = false, EmitDefaultValue = false)]
            public string? EndsAt { get; set; }

            /// <summary>
            /// Display name for the access grant.
            /// </summary>
            [DataMember(Name = "name", IsRequired = false, EmitDefaultValue = false)]
            public string? Name { get; set; }

            /// <summary>
            /// Date and time at which the validity of the grant starts, in [ISO 8601](https://www.iso.org/iso-8601-date-and-time-format.html) format.
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
        /// Updates an existing Access Grant&apos;s time window.
        /// </summary>
        public void Update(UpdateRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            _seam.Patch<object>("/access_grants/update", requestOptions);
        }

        /// <summary>
        /// Updates an existing Access Grant&apos;s time window.
        /// </summary>
        public void Update(
            string? accessGrantId = default,
            string? accessGrantKey = default,
            string? endsAt = default,
            string? name = default,
            string? startsAt = default
        )
        {
            Update(
                new UpdateRequest(
                    accessGrantId: accessGrantId,
                    accessGrantKey: accessGrantKey,
                    endsAt: endsAt,
                    name: name,
                    startsAt: startsAt
                )
            );
        }

        /// <summary>
        /// Updates an existing Access Grant&apos;s time window.
        /// </summary>
        public async Task UpdateAsync(UpdateRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            await _seam.PatchAsync<object>("/access_grants/update", requestOptions);
        }

        /// <summary>
        /// Updates an existing Access Grant&apos;s time window.
        /// </summary>
        public async Task UpdateAsync(
            string? accessGrantId = default,
            string? accessGrantKey = default,
            string? endsAt = default,
            string? name = default,
            string? startsAt = default
        )
        {
            await UpdateAsync(
                new UpdateRequest(
                    accessGrantId: accessGrantId,
                    accessGrantKey: accessGrantKey,
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
