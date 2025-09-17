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
    public class UserIdentities
    {
        private ISeamClient _seam;

        public UserIdentities(ISeamClient seam)
        {
            _seam = seam;
        }

        [DataContract(Name = "addAcsUserRequest_request")]
        public class AddAcsUserRequest
        {
            [JsonConstructorAttribute]
            protected AddAcsUserRequest() { }

            public AddAcsUserRequest(string acsUserId = default, string userIdentityId = default)
            {
                AcsUserId = acsUserId;
                UserIdentityId = userIdentityId;
            }

            [DataMember(Name = "acs_user_id", IsRequired = true, EmitDefaultValue = false)]
            public string AcsUserId { get; set; }

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

        public void AddAcsUser(AddAcsUserRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            _seam.Post<object>("/user_identities/add_acs_user", requestOptions);
        }

        public void AddAcsUser(string acsUserId = default, string userIdentityId = default)
        {
            AddAcsUser(new AddAcsUserRequest(acsUserId: acsUserId, userIdentityId: userIdentityId));
        }

        public async Task AddAcsUserAsync(AddAcsUserRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            await _seam.PostAsync<object>("/user_identities/add_acs_user", requestOptions);
        }

        public async Task AddAcsUserAsync(
            string acsUserId = default,
            string userIdentityId = default
        )
        {
            await AddAcsUserAsync(
                new AddAcsUserRequest(acsUserId: acsUserId, userIdentityId: userIdentityId)
            );
        }

        [DataContract(Name = "createRequest_request")]
        public class CreateRequest
        {
            [JsonConstructorAttribute]
            protected CreateRequest() { }

            public CreateRequest(
                List<string>? acsSystemIds = default,
                string? emailAddress = default,
                string? fullName = default,
                string? phoneNumber = default,
                string? userIdentityKey = default
            )
            {
                AcsSystemIds = acsSystemIds;
                EmailAddress = emailAddress;
                FullName = fullName;
                PhoneNumber = phoneNumber;
                UserIdentityKey = userIdentityKey;
            }

            [DataMember(Name = "acs_system_ids", IsRequired = false, EmitDefaultValue = false)]
            public List<string>? AcsSystemIds { get; set; }

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

        [DataContract(Name = "createResponse_response")]
        public class CreateResponse
        {
            [JsonConstructorAttribute]
            protected CreateResponse() { }

            public CreateResponse(UserIdentity userIdentity = default)
            {
                UserIdentity = userIdentity;
            }

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

        public UserIdentity Create(CreateRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            return _seam
                .Post<CreateResponse>("/user_identities/create", requestOptions)
                .Data.UserIdentity;
        }

        public UserIdentity Create(
            List<string>? acsSystemIds = default,
            string? emailAddress = default,
            string? fullName = default,
            string? phoneNumber = default,
            string? userIdentityKey = default
        )
        {
            return Create(
                new CreateRequest(
                    acsSystemIds: acsSystemIds,
                    emailAddress: emailAddress,
                    fullName: fullName,
                    phoneNumber: phoneNumber,
                    userIdentityKey: userIdentityKey
                )
            );
        }

        public async Task<UserIdentity> CreateAsync(CreateRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            return (
                await _seam.PostAsync<CreateResponse>("/user_identities/create", requestOptions)
            )
                .Data
                .UserIdentity;
        }

        public async Task<UserIdentity> CreateAsync(
            List<string>? acsSystemIds = default,
            string? emailAddress = default,
            string? fullName = default,
            string? phoneNumber = default,
            string? userIdentityKey = default
        )
        {
            return (
                await CreateAsync(
                    new CreateRequest(
                        acsSystemIds: acsSystemIds,
                        emailAddress: emailAddress,
                        fullName: fullName,
                        phoneNumber: phoneNumber,
                        userIdentityKey: userIdentityKey
                    )
                )
            );
        }

        [DataContract(Name = "deleteRequest_request")]
        public class DeleteRequest
        {
            [JsonConstructorAttribute]
            protected DeleteRequest() { }

            public DeleteRequest(string userIdentityId = default)
            {
                UserIdentityId = userIdentityId;
            }

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

        public void Delete(DeleteRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            _seam.Post<object>("/user_identities/delete", requestOptions);
        }

        public void Delete(string userIdentityId = default)
        {
            Delete(new DeleteRequest(userIdentityId: userIdentityId));
        }

        public async Task DeleteAsync(DeleteRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            await _seam.PostAsync<object>("/user_identities/delete", requestOptions);
        }

        public async Task DeleteAsync(string userIdentityId = default)
        {
            await DeleteAsync(new DeleteRequest(userIdentityId: userIdentityId));
        }

        [DataContract(Name = "generateInstantKeyRequest_request")]
        public class GenerateInstantKeyRequest
        {
            [JsonConstructorAttribute]
            protected GenerateInstantKeyRequest() { }

            public GenerateInstantKeyRequest(
                string? customizationProfileId = default,
                float? maxUseCount = default,
                string userIdentityId = default
            )
            {
                CustomizationProfileId = customizationProfileId;
                MaxUseCount = maxUseCount;
                UserIdentityId = userIdentityId;
            }

            [DataMember(
                Name = "customization_profile_id",
                IsRequired = false,
                EmitDefaultValue = false
            )]
            public string? CustomizationProfileId { get; set; }

            [DataMember(Name = "max_use_count", IsRequired = false, EmitDefaultValue = false)]
            public float? MaxUseCount { get; set; }

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

        [DataContract(Name = "generateInstantKeyResponse_response")]
        public class GenerateInstantKeyResponse
        {
            [JsonConstructorAttribute]
            protected GenerateInstantKeyResponse() { }

            public GenerateInstantKeyResponse(InstantKey instantKey = default)
            {
                InstantKey = instantKey;
            }

            [DataMember(Name = "instant_key", IsRequired = false, EmitDefaultValue = false)]
            public InstantKey InstantKey { get; set; }

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

        public InstantKey GenerateInstantKey(GenerateInstantKeyRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            return _seam
                .Post<GenerateInstantKeyResponse>(
                    "/user_identities/generate_instant_key",
                    requestOptions
                )
                .Data.InstantKey;
        }

        public InstantKey GenerateInstantKey(
            string? customizationProfileId = default,
            float? maxUseCount = default,
            string userIdentityId = default
        )
        {
            return GenerateInstantKey(
                new GenerateInstantKeyRequest(
                    customizationProfileId: customizationProfileId,
                    maxUseCount: maxUseCount,
                    userIdentityId: userIdentityId
                )
            );
        }

        public async Task<InstantKey> GenerateInstantKeyAsync(GenerateInstantKeyRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            return (
                await _seam.PostAsync<GenerateInstantKeyResponse>(
                    "/user_identities/generate_instant_key",
                    requestOptions
                )
            )
                .Data
                .InstantKey;
        }

        public async Task<InstantKey> GenerateInstantKeyAsync(
            string? customizationProfileId = default,
            float? maxUseCount = default,
            string userIdentityId = default
        )
        {
            return (
                await GenerateInstantKeyAsync(
                    new GenerateInstantKeyRequest(
                        customizationProfileId: customizationProfileId,
                        maxUseCount: maxUseCount,
                        userIdentityId: userIdentityId
                    )
                )
            );
        }

        [DataContract(Name = "getRequest_request")]
        public class GetRequest
        {
            [JsonConstructorAttribute]
            protected GetRequest() { }

            public GetRequest(string? userIdentityId = default, string? userIdentityKey = default)
            {
                UserIdentityId = userIdentityId;
                UserIdentityKey = userIdentityKey;
            }

            [DataMember(Name = "user_identity_id", IsRequired = false, EmitDefaultValue = false)]
            public string? UserIdentityId { get; set; }

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

        [DataContract(Name = "getResponse_response")]
        public class GetResponse
        {
            [JsonConstructorAttribute]
            protected GetResponse() { }

            public GetResponse(UserIdentity userIdentity = default)
            {
                UserIdentity = userIdentity;
            }

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

        public UserIdentity Get(GetRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            return _seam
                .Post<GetResponse>("/user_identities/get", requestOptions)
                .Data.UserIdentity;
        }

        public UserIdentity Get(string? userIdentityId = default, string? userIdentityKey = default)
        {
            return Get(
                new GetRequest(userIdentityId: userIdentityId, userIdentityKey: userIdentityKey)
            );
        }

        public async Task<UserIdentity> GetAsync(GetRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            return (await _seam.PostAsync<GetResponse>("/user_identities/get", requestOptions))
                .Data
                .UserIdentity;
        }

        public async Task<UserIdentity> GetAsync(
            string? userIdentityId = default,
            string? userIdentityKey = default
        )
        {
            return (
                await GetAsync(
                    new GetRequest(userIdentityId: userIdentityId, userIdentityKey: userIdentityKey)
                )
            );
        }

        [DataContract(Name = "grantAccessToDeviceRequest_request")]
        public class GrantAccessToDeviceRequest
        {
            [JsonConstructorAttribute]
            protected GrantAccessToDeviceRequest() { }

            public GrantAccessToDeviceRequest(
                string deviceId = default,
                string userIdentityId = default
            )
            {
                DeviceId = deviceId;
                UserIdentityId = userIdentityId;
            }

            [DataMember(Name = "device_id", IsRequired = true, EmitDefaultValue = false)]
            public string DeviceId { get; set; }

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

        public void GrantAccessToDevice(GrantAccessToDeviceRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            _seam.Post<object>("/user_identities/grant_access_to_device", requestOptions);
        }

        public void GrantAccessToDevice(string deviceId = default, string userIdentityId = default)
        {
            GrantAccessToDevice(
                new GrantAccessToDeviceRequest(deviceId: deviceId, userIdentityId: userIdentityId)
            );
        }

        public async Task GrantAccessToDeviceAsync(GrantAccessToDeviceRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            await _seam.PostAsync<object>(
                "/user_identities/grant_access_to_device",
                requestOptions
            );
        }

        public async Task GrantAccessToDeviceAsync(
            string deviceId = default,
            string userIdentityId = default
        )
        {
            await GrantAccessToDeviceAsync(
                new GrantAccessToDeviceRequest(deviceId: deviceId, userIdentityId: userIdentityId)
            );
        }

        [DataContract(Name = "listRequest_request")]
        public class ListRequest
        {
            [JsonConstructorAttribute]
            protected ListRequest() { }

            public ListRequest(
                string? credentialManagerAcsSystemId = default,
                string? search = default
            )
            {
                CredentialManagerAcsSystemId = credentialManagerAcsSystemId;
                Search = search;
            }

            [DataMember(
                Name = "credential_manager_acs_system_id",
                IsRequired = false,
                EmitDefaultValue = false
            )]
            public string? CredentialManagerAcsSystemId { get; set; }

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

            public ListResponse(List<UserIdentity> userIdentities = default)
            {
                UserIdentities = userIdentities;
            }

            [DataMember(Name = "user_identities", IsRequired = false, EmitDefaultValue = false)]
            public List<UserIdentity> UserIdentities { get; set; }

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

        public List<UserIdentity> List(ListRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            return _seam
                .Post<ListResponse>("/user_identities/list", requestOptions)
                .Data.UserIdentities;
        }

        public List<UserIdentity> List(
            string? credentialManagerAcsSystemId = default,
            string? search = default
        )
        {
            return List(
                new ListRequest(
                    credentialManagerAcsSystemId: credentialManagerAcsSystemId,
                    search: search
                )
            );
        }

        public async Task<List<UserIdentity>> ListAsync(ListRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            return (await _seam.PostAsync<ListResponse>("/user_identities/list", requestOptions))
                .Data
                .UserIdentities;
        }

        public async Task<List<UserIdentity>> ListAsync(
            string? credentialManagerAcsSystemId = default,
            string? search = default
        )
        {
            return (
                await ListAsync(
                    new ListRequest(
                        credentialManagerAcsSystemId: credentialManagerAcsSystemId,
                        search: search
                    )
                )
            );
        }

        [DataContract(Name = "listAccessibleDevicesRequest_request")]
        public class ListAccessibleDevicesRequest
        {
            [JsonConstructorAttribute]
            protected ListAccessibleDevicesRequest() { }

            public ListAccessibleDevicesRequest(string userIdentityId = default)
            {
                UserIdentityId = userIdentityId;
            }

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

        [DataContract(Name = "listAccessibleDevicesResponse_response")]
        public class ListAccessibleDevicesResponse
        {
            [JsonConstructorAttribute]
            protected ListAccessibleDevicesResponse() { }

            public ListAccessibleDevicesResponse(List<Device> devices = default)
            {
                Devices = devices;
            }

            [DataMember(Name = "devices", IsRequired = false, EmitDefaultValue = false)]
            public List<Device> Devices { get; set; }

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

        public List<Device> ListAccessibleDevices(ListAccessibleDevicesRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            return _seam
                .Post<ListAccessibleDevicesResponse>(
                    "/user_identities/list_accessible_devices",
                    requestOptions
                )
                .Data.Devices;
        }

        public List<Device> ListAccessibleDevices(string userIdentityId = default)
        {
            return ListAccessibleDevices(
                new ListAccessibleDevicesRequest(userIdentityId: userIdentityId)
            );
        }

        public async Task<List<Device>> ListAccessibleDevicesAsync(
            ListAccessibleDevicesRequest request
        )
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            return (
                await _seam.PostAsync<ListAccessibleDevicesResponse>(
                    "/user_identities/list_accessible_devices",
                    requestOptions
                )
            )
                .Data
                .Devices;
        }

        public async Task<List<Device>> ListAccessibleDevicesAsync(string userIdentityId = default)
        {
            return (
                await ListAccessibleDevicesAsync(
                    new ListAccessibleDevicesRequest(userIdentityId: userIdentityId)
                )
            );
        }

        [DataContract(Name = "listAcsSystemsRequest_request")]
        public class ListAcsSystemsRequest
        {
            [JsonConstructorAttribute]
            protected ListAcsSystemsRequest() { }

            public ListAcsSystemsRequest(string userIdentityId = default)
            {
                UserIdentityId = userIdentityId;
            }

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

        [DataContract(Name = "listAcsSystemsResponse_response")]
        public class ListAcsSystemsResponse
        {
            [JsonConstructorAttribute]
            protected ListAcsSystemsResponse() { }

            public ListAcsSystemsResponse(List<AcsSystem> acsSystems = default)
            {
                AcsSystems = acsSystems;
            }

            [DataMember(Name = "acs_systems", IsRequired = false, EmitDefaultValue = false)]
            public List<AcsSystem> AcsSystems { get; set; }

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

        public List<AcsSystem> ListAcsSystems(ListAcsSystemsRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            return _seam
                .Post<ListAcsSystemsResponse>("/user_identities/list_acs_systems", requestOptions)
                .Data.AcsSystems;
        }

        public List<AcsSystem> ListAcsSystems(string userIdentityId = default)
        {
            return ListAcsSystems(new ListAcsSystemsRequest(userIdentityId: userIdentityId));
        }

        public async Task<List<AcsSystem>> ListAcsSystemsAsync(ListAcsSystemsRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            return (
                await _seam.PostAsync<ListAcsSystemsResponse>(
                    "/user_identities/list_acs_systems",
                    requestOptions
                )
            )
                .Data
                .AcsSystems;
        }

        public async Task<List<AcsSystem>> ListAcsSystemsAsync(string userIdentityId = default)
        {
            return (
                await ListAcsSystemsAsync(new ListAcsSystemsRequest(userIdentityId: userIdentityId))
            );
        }

        [DataContract(Name = "listAcsUsersRequest_request")]
        public class ListAcsUsersRequest
        {
            [JsonConstructorAttribute]
            protected ListAcsUsersRequest() { }

            public ListAcsUsersRequest(string userIdentityId = default)
            {
                UserIdentityId = userIdentityId;
            }

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

        [DataContract(Name = "listAcsUsersResponse_response")]
        public class ListAcsUsersResponse
        {
            [JsonConstructorAttribute]
            protected ListAcsUsersResponse() { }

            public ListAcsUsersResponse(List<AcsUser> acsUsers = default)
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

        public List<AcsUser> ListAcsUsers(ListAcsUsersRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            return _seam
                .Post<ListAcsUsersResponse>("/user_identities/list_acs_users", requestOptions)
                .Data.AcsUsers;
        }

        public List<AcsUser> ListAcsUsers(string userIdentityId = default)
        {
            return ListAcsUsers(new ListAcsUsersRequest(userIdentityId: userIdentityId));
        }

        public async Task<List<AcsUser>> ListAcsUsersAsync(ListAcsUsersRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            return (
                await _seam.PostAsync<ListAcsUsersResponse>(
                    "/user_identities/list_acs_users",
                    requestOptions
                )
            )
                .Data
                .AcsUsers;
        }

        public async Task<List<AcsUser>> ListAcsUsersAsync(string userIdentityId = default)
        {
            return (
                await ListAcsUsersAsync(new ListAcsUsersRequest(userIdentityId: userIdentityId))
            );
        }

        [DataContract(Name = "removeAcsUserRequest_request")]
        public class RemoveAcsUserRequest
        {
            [JsonConstructorAttribute]
            protected RemoveAcsUserRequest() { }

            public RemoveAcsUserRequest(string acsUserId = default, string userIdentityId = default)
            {
                AcsUserId = acsUserId;
                UserIdentityId = userIdentityId;
            }

            [DataMember(Name = "acs_user_id", IsRequired = true, EmitDefaultValue = false)]
            public string AcsUserId { get; set; }

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

        public void RemoveAcsUser(RemoveAcsUserRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            _seam.Post<object>("/user_identities/remove_acs_user", requestOptions);
        }

        public void RemoveAcsUser(string acsUserId = default, string userIdentityId = default)
        {
            RemoveAcsUser(
                new RemoveAcsUserRequest(acsUserId: acsUserId, userIdentityId: userIdentityId)
            );
        }

        public async Task RemoveAcsUserAsync(RemoveAcsUserRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            await _seam.PostAsync<object>("/user_identities/remove_acs_user", requestOptions);
        }

        public async Task RemoveAcsUserAsync(
            string acsUserId = default,
            string userIdentityId = default
        )
        {
            await RemoveAcsUserAsync(
                new RemoveAcsUserRequest(acsUserId: acsUserId, userIdentityId: userIdentityId)
            );
        }

        [DataContract(Name = "revokeAccessToDeviceRequest_request")]
        public class RevokeAccessToDeviceRequest
        {
            [JsonConstructorAttribute]
            protected RevokeAccessToDeviceRequest() { }

            public RevokeAccessToDeviceRequest(
                string deviceId = default,
                string userIdentityId = default
            )
            {
                DeviceId = deviceId;
                UserIdentityId = userIdentityId;
            }

            [DataMember(Name = "device_id", IsRequired = true, EmitDefaultValue = false)]
            public string DeviceId { get; set; }

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

        public void RevokeAccessToDevice(RevokeAccessToDeviceRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            _seam.Post<object>("/user_identities/revoke_access_to_device", requestOptions);
        }

        public void RevokeAccessToDevice(string deviceId = default, string userIdentityId = default)
        {
            RevokeAccessToDevice(
                new RevokeAccessToDeviceRequest(deviceId: deviceId, userIdentityId: userIdentityId)
            );
        }

        public async Task RevokeAccessToDeviceAsync(RevokeAccessToDeviceRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            await _seam.PostAsync<object>(
                "/user_identities/revoke_access_to_device",
                requestOptions
            );
        }

        public async Task RevokeAccessToDeviceAsync(
            string deviceId = default,
            string userIdentityId = default
        )
        {
            await RevokeAccessToDeviceAsync(
                new RevokeAccessToDeviceRequest(deviceId: deviceId, userIdentityId: userIdentityId)
            );
        }

        [DataContract(Name = "updateRequest_request")]
        public class UpdateRequest
        {
            [JsonConstructorAttribute]
            protected UpdateRequest() { }

            public UpdateRequest(
                string? emailAddress = default,
                string? fullName = default,
                string? phoneNumber = default,
                string userIdentityId = default,
                string? userIdentityKey = default
            )
            {
                EmailAddress = emailAddress;
                FullName = fullName;
                PhoneNumber = phoneNumber;
                UserIdentityId = userIdentityId;
                UserIdentityKey = userIdentityKey;
            }

            [DataMember(Name = "email_address", IsRequired = false, EmitDefaultValue = false)]
            public string? EmailAddress { get; set; }

            [DataMember(Name = "full_name", IsRequired = false, EmitDefaultValue = false)]
            public string? FullName { get; set; }

            [DataMember(Name = "phone_number", IsRequired = false, EmitDefaultValue = false)]
            public string? PhoneNumber { get; set; }

            [DataMember(Name = "user_identity_id", IsRequired = true, EmitDefaultValue = false)]
            public string UserIdentityId { get; set; }

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

        public void Update(UpdateRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            _seam.Post<object>("/user_identities/update", requestOptions);
        }

        public void Update(
            string? emailAddress = default,
            string? fullName = default,
            string? phoneNumber = default,
            string userIdentityId = default,
            string? userIdentityKey = default
        )
        {
            Update(
                new UpdateRequest(
                    emailAddress: emailAddress,
                    fullName: fullName,
                    phoneNumber: phoneNumber,
                    userIdentityId: userIdentityId,
                    userIdentityKey: userIdentityKey
                )
            );
        }

        public async Task UpdateAsync(UpdateRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            await _seam.PostAsync<object>("/user_identities/update", requestOptions);
        }

        public async Task UpdateAsync(
            string? emailAddress = default,
            string? fullName = default,
            string? phoneNumber = default,
            string userIdentityId = default,
            string? userIdentityKey = default
        )
        {
            await UpdateAsync(
                new UpdateRequest(
                    emailAddress: emailAddress,
                    fullName: fullName,
                    phoneNumber: phoneNumber,
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
        public Api.UserIdentities UserIdentities => new(this);
    }

    public partial interface ISeamClient
    {
        public Api.UserIdentities UserIdentities { get; }
    }
}
