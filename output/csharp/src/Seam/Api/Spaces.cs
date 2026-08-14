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
    public class Spaces
    {
        private ISeamClient _seam;

        public Spaces(ISeamClient seam)
        {
            _seam = seam;
        }

        /// <summary>
        /// Request parameters for Add Entrances to a Space.
        /// </summary>
        [DataContract(Name = "addAcsEntrancesRequest_request")]
        public class AddAcsEntrancesRequest
        {
            [JsonConstructorAttribute]
            protected AddAcsEntrancesRequest() { }

            public AddAcsEntrancesRequest(
                List<string> acsEntranceIds = default,
                string spaceId = default
            )
            {
                AcsEntranceIds = acsEntranceIds;
                SpaceId = spaceId;
            }

            /// <summary>
            /// IDs of the entrances that you want to add to the space.
            /// </summary>
            [DataMember(Name = "acs_entrance_ids", IsRequired = true, EmitDefaultValue = false)]
            public List<string> AcsEntranceIds { get; set; }

            /// <summary>
            /// ID of the space to which you want to add entrances.
            /// </summary>
            [DataMember(Name = "space_id", IsRequired = true, EmitDefaultValue = false)]
            public string SpaceId { get; set; }

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
        /// Adds [entrances](https://docs.seam.co/low-level-apis/access-systems/retrieving-entrance-details) to a specific space.
        /// </summary>
        public void AddAcsEntrances(AddAcsEntrancesRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            _seam.Put<object>("/spaces/add_acs_entrances", requestOptions);
        }

        /// <summary>
        /// Adds [entrances](https://docs.seam.co/low-level-apis/access-systems/retrieving-entrance-details) to a specific space.
        /// </summary>
        public void AddAcsEntrances(List<string> acsEntranceIds = default, string spaceId = default)
        {
            AddAcsEntrances(
                new AddAcsEntrancesRequest(acsEntranceIds: acsEntranceIds, spaceId: spaceId)
            );
        }

        /// <summary>
        /// Adds [entrances](https://docs.seam.co/low-level-apis/access-systems/retrieving-entrance-details) to a specific space.
        /// </summary>
        public async Task AddAcsEntrancesAsync(AddAcsEntrancesRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            await _seam.PutAsync<object>("/spaces/add_acs_entrances", requestOptions);
        }

        /// <summary>
        /// Adds [entrances](https://docs.seam.co/low-level-apis/access-systems/retrieving-entrance-details) to a specific space.
        /// </summary>
        public async Task AddAcsEntrancesAsync(
            List<string> acsEntranceIds = default,
            string spaceId = default
        )
        {
            await AddAcsEntrancesAsync(
                new AddAcsEntrancesRequest(acsEntranceIds: acsEntranceIds, spaceId: spaceId)
            );
        }

        /// <summary>
        /// Request parameters for Add a Connected Account to a Space.
        /// </summary>
        [DataContract(Name = "addConnectedAccountRequest_request")]
        public class AddConnectedAccountRequest
        {
            [JsonConstructorAttribute]
            protected AddConnectedAccountRequest() { }

            public AddConnectedAccountRequest(
                string connectedAccountId = default,
                string spaceId = default
            )
            {
                ConnectedAccountId = connectedAccountId;
                SpaceId = spaceId;
            }

            /// <summary>
            /// ID of the connected account that you want to add to the space.
            /// </summary>
            [DataMember(Name = "connected_account_id", IsRequired = true, EmitDefaultValue = false)]
            public string ConnectedAccountId { get; set; }

            /// <summary>
            /// ID of the space to which you want to add the connected account.
            /// </summary>
            [DataMember(Name = "space_id", IsRequired = true, EmitDefaultValue = false)]
            public string SpaceId { get; set; }

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
        /// Adds a [connected account](https://docs.seam.co/core-concepts/connected-accounts) to a specific space.
        /// </summary>
        public void AddConnectedAccount(AddConnectedAccountRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            _seam.Put<object>("/spaces/add_connected_account", requestOptions);
        }

        /// <summary>
        /// Adds a [connected account](https://docs.seam.co/core-concepts/connected-accounts) to a specific space.
        /// </summary>
        public void AddConnectedAccount(
            string connectedAccountId = default,
            string spaceId = default
        )
        {
            AddConnectedAccount(
                new AddConnectedAccountRequest(
                    connectedAccountId: connectedAccountId,
                    spaceId: spaceId
                )
            );
        }

        /// <summary>
        /// Adds a [connected account](https://docs.seam.co/core-concepts/connected-accounts) to a specific space.
        /// </summary>
        public async Task AddConnectedAccountAsync(AddConnectedAccountRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            await _seam.PutAsync<object>("/spaces/add_connected_account", requestOptions);
        }

        /// <summary>
        /// Adds a [connected account](https://docs.seam.co/core-concepts/connected-accounts) to a specific space.
        /// </summary>
        public async Task AddConnectedAccountAsync(
            string connectedAccountId = default,
            string spaceId = default
        )
        {
            await AddConnectedAccountAsync(
                new AddConnectedAccountRequest(
                    connectedAccountId: connectedAccountId,
                    spaceId: spaceId
                )
            );
        }

        /// <summary>
        /// Request parameters for Add Devices to a Space.
        /// </summary>
        [DataContract(Name = "addDevicesRequest_request")]
        public class AddDevicesRequest
        {
            [JsonConstructorAttribute]
            protected AddDevicesRequest() { }

            public AddDevicesRequest(List<string> deviceIds = default, string spaceId = default)
            {
                DeviceIds = deviceIds;
                SpaceId = spaceId;
            }

            /// <summary>
            /// IDs of the devices that you want to add to the space.
            /// </summary>
            [DataMember(Name = "device_ids", IsRequired = true, EmitDefaultValue = false)]
            public List<string> DeviceIds { get; set; }

            /// <summary>
            /// ID of the space to which you want to add devices.
            /// </summary>
            [DataMember(Name = "space_id", IsRequired = true, EmitDefaultValue = false)]
            public string SpaceId { get; set; }

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
        /// Adds devices to a specific space.
        /// </summary>
        public void AddDevices(AddDevicesRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            _seam.Put<object>("/spaces/add_devices", requestOptions);
        }

        /// <summary>
        /// Adds devices to a specific space.
        /// </summary>
        public void AddDevices(List<string> deviceIds = default, string spaceId = default)
        {
            AddDevices(new AddDevicesRequest(deviceIds: deviceIds, spaceId: spaceId));
        }

        /// <summary>
        /// Adds devices to a specific space.
        /// </summary>
        public async Task AddDevicesAsync(AddDevicesRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            await _seam.PutAsync<object>("/spaces/add_devices", requestOptions);
        }

        /// <summary>
        /// Adds devices to a specific space.
        /// </summary>
        public async Task AddDevicesAsync(
            List<string> deviceIds = default,
            string spaceId = default
        )
        {
            await AddDevicesAsync(new AddDevicesRequest(deviceIds: deviceIds, spaceId: spaceId));
        }

        /// <summary>
        /// Request parameters for Create a Space.
        /// </summary>
        [DataContract(Name = "createRequest_request")]
        public class CreateRequest
        {
            [JsonConstructorAttribute]
            protected CreateRequest() { }

            public CreateRequest(
                List<string>? acsEntranceIds = default,
                List<string>? connectedAccountIds = default,
                CreateRequestCustomerData? customerData = default,
                string? customerKey = default,
                List<string>? deviceIds = default,
                string name = default,
                string? spaceKey = default
            )
            {
                AcsEntranceIds = acsEntranceIds;
                ConnectedAccountIds = connectedAccountIds;
                CustomerData = customerData;
                CustomerKey = customerKey;
                DeviceIds = deviceIds;
                Name = name;
                SpaceKey = spaceKey;
            }

            /// <summary>
            /// IDs of the entrances that you want to add to the new space.
            /// </summary>
            [DataMember(Name = "acs_entrance_ids", IsRequired = false, EmitDefaultValue = false)]
            public List<string>? AcsEntranceIds { get; set; }

            /// <summary>
            /// IDs of connected accounts to associate with the new space. Persisted on seam.location_third_party_account so the UI can show which provider account(s) a space came from.
            /// </summary>
            [DataMember(
                Name = "connected_account_ids",
                IsRequired = false,
                EmitDefaultValue = false
            )]
            public List<string>? ConnectedAccountIds { get; set; }

            /// <summary>
            /// Reservation/stay-related defaults for the space.
            /// </summary>
            [DataMember(Name = "customer_data", IsRequired = false, EmitDefaultValue = false)]
            public CreateRequestCustomerData? CustomerData { get; set; }

            /// <summary>
            /// Customer key for which you want to create the space.
            /// </summary>
            [DataMember(Name = "customer_key", IsRequired = false, EmitDefaultValue = false)]
            public string? CustomerKey { get; set; }

            /// <summary>
            /// IDs of the devices that you want to add to the new space.
            /// </summary>
            [DataMember(Name = "device_ids", IsRequired = false, EmitDefaultValue = false)]
            public List<string>? DeviceIds { get; set; }

            /// <summary>
            /// Name of the space that you want to create.
            /// </summary>
            [DataMember(Name = "name", IsRequired = true, EmitDefaultValue = false)]
            public string Name { get; set; }

            /// <summary>
            /// Unique key for the space within the workspace.
            /// </summary>
            [DataMember(Name = "space_key", IsRequired = false, EmitDefaultValue = false)]
            public string? SpaceKey { get; set; }

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

        [DataContract(Name = "createRequestCustomerData_model")]
        public class CreateRequestCustomerData
        {
            [JsonConstructorAttribute]
            protected CreateRequestCustomerData() { }

            public CreateRequestCustomerData(
                string? address = default,
                string? defaultCheckinTime = default,
                string? defaultCheckoutTime = default,
                string? timeZone = default
            )
            {
                Address = address;
                DefaultCheckinTime = defaultCheckinTime;
                DefaultCheckoutTime = defaultCheckoutTime;
                TimeZone = timeZone;
            }

            /// <summary>
            /// Postal address for the space.
            /// </summary>
            [DataMember(Name = "address", IsRequired = false, EmitDefaultValue = false)]
            public string? Address { get; set; }

            /// <summary>
            /// Default check-in time for reservations at the space, as HH:mm or HH:mm:ss.
            /// </summary>
            [DataMember(
                Name = "default_checkin_time",
                IsRequired = false,
                EmitDefaultValue = false
            )]
            public string? DefaultCheckinTime { get; set; }

            /// <summary>
            /// Default check-out time for reservations at the space, as HH:mm or HH:mm:ss.
            /// </summary>
            [DataMember(
                Name = "default_checkout_time",
                IsRequired = false,
                EmitDefaultValue = false
            )]
            public string? DefaultCheckoutTime { get; set; }

            /// <summary>
            /// IANA time zone for the space, e.g. America/Los_Angeles.
            /// </summary>
            [DataMember(Name = "time_zone", IsRequired = false, EmitDefaultValue = false)]
            public string? TimeZone { get; set; }

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

            public CreateResponse(Space space = default)
            {
                Space = space;
            }

            /// <summary>
            /// OK
            /// </summary>
            [DataMember(Name = "space", IsRequired = false, EmitDefaultValue = false)]
            public Space Space { get; set; }

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
        /// Creates a new space.
        /// </summary>
        public Space Create(CreateRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            return _seam
                .Post<CreateResponse>("/spaces/create", requestOptions)
                .EnsureData("/spaces/create")
                .Space;
        }

        /// <summary>
        /// Creates a new space.
        /// </summary>
        public Space Create(
            List<string>? acsEntranceIds = default,
            List<string>? connectedAccountIds = default,
            CreateRequestCustomerData? customerData = default,
            string? customerKey = default,
            List<string>? deviceIds = default,
            string name = default,
            string? spaceKey = default
        )
        {
            return Create(
                new CreateRequest(
                    acsEntranceIds: acsEntranceIds,
                    connectedAccountIds: connectedAccountIds,
                    customerData: customerData,
                    customerKey: customerKey,
                    deviceIds: deviceIds,
                    name: name,
                    spaceKey: spaceKey
                )
            );
        }

        /// <summary>
        /// Creates a new space.
        /// </summary>
        public async Task<Space> CreateAsync(CreateRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            return (await _seam.PostAsync<CreateResponse>("/spaces/create", requestOptions))
                .EnsureData("/spaces/create")
                .Space;
        }

        /// <summary>
        /// Creates a new space.
        /// </summary>
        public async Task<Space> CreateAsync(
            List<string>? acsEntranceIds = default,
            List<string>? connectedAccountIds = default,
            CreateRequestCustomerData? customerData = default,
            string? customerKey = default,
            List<string>? deviceIds = default,
            string name = default,
            string? spaceKey = default
        )
        {
            return (
                await CreateAsync(
                    new CreateRequest(
                        acsEntranceIds: acsEntranceIds,
                        connectedAccountIds: connectedAccountIds,
                        customerData: customerData,
                        customerKey: customerKey,
                        deviceIds: deviceIds,
                        name: name,
                        spaceKey: spaceKey
                    )
                )
            );
        }

        /// <summary>
        /// Request parameters for Delete a Space.
        /// </summary>
        [DataContract(Name = "deleteRequest_request")]
        public class DeleteRequest
        {
            [JsonConstructorAttribute]
            protected DeleteRequest() { }

            public DeleteRequest(string spaceId = default)
            {
                SpaceId = spaceId;
            }

            /// <summary>
            /// ID of the space that you want to delete.
            /// </summary>
            [DataMember(Name = "space_id", IsRequired = true, EmitDefaultValue = false)]
            public string SpaceId { get; set; }

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
        /// Deletes a space.
        /// </summary>
        public void Delete(DeleteRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            _seam.Post<object>("/spaces/delete", requestOptions);
        }

        /// <summary>
        /// Deletes a space.
        /// </summary>
        public void Delete(string spaceId = default)
        {
            Delete(new DeleteRequest(spaceId: spaceId));
        }

        /// <summary>
        /// Deletes a space.
        /// </summary>
        public async Task DeleteAsync(DeleteRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            await _seam.PostAsync<object>("/spaces/delete", requestOptions);
        }

        /// <summary>
        /// Deletes a space.
        /// </summary>
        public async Task DeleteAsync(string spaceId = default)
        {
            await DeleteAsync(new DeleteRequest(spaceId: spaceId));
        }

        /// <summary>
        /// Request parameters for Get a Space.
        /// </summary>
        [DataContract(Name = "getRequest_request")]
        public class GetRequest
        {
            [JsonConstructorAttribute]
            protected GetRequest() { }

            public GetRequest(string? spaceId = default, string? spaceKey = default)
            {
                SpaceId = spaceId;
                SpaceKey = spaceKey;
            }

            /// <summary>
            /// ID of the space that you want to get.
            /// </summary>
            [DataMember(Name = "space_id", IsRequired = false, EmitDefaultValue = false)]
            public string? SpaceId { get; set; }

            /// <summary>
            /// Unique key of the space that you want to get.
            /// </summary>
            [DataMember(Name = "space_key", IsRequired = false, EmitDefaultValue = false)]
            public string? SpaceKey { get; set; }

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

            public GetResponse(Space space = default)
            {
                Space = space;
            }

            /// <summary>
            /// OK
            /// </summary>
            [DataMember(Name = "space", IsRequired = false, EmitDefaultValue = false)]
            public Space Space { get; set; }

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
        /// Gets a space.
        /// </summary>
        public Space Get(GetRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            return _seam
                .Get<GetResponse>("/spaces/get", requestOptions)
                .EnsureData("/spaces/get")
                .Space;
        }

        /// <summary>
        /// Gets a space.
        /// </summary>
        public Space Get(string? spaceId = default, string? spaceKey = default)
        {
            return Get(new GetRequest(spaceId: spaceId, spaceKey: spaceKey));
        }

        /// <summary>
        /// Gets a space.
        /// </summary>
        public async Task<Space> GetAsync(GetRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            return (await _seam.GetAsync<GetResponse>("/spaces/get", requestOptions))
                .EnsureData("/spaces/get")
                .Space;
        }

        /// <summary>
        /// Gets a space.
        /// </summary>
        public async Task<Space> GetAsync(string? spaceId = default, string? spaceKey = default)
        {
            return (await GetAsync(new GetRequest(spaceId: spaceId, spaceKey: spaceKey)));
        }

        /// <summary>
        /// Request parameters for Get related Space resources.
        /// </summary>
        [DataContract(Name = "getRelatedRequest_request")]
        public class GetRelatedRequest
        {
            [JsonConstructorAttribute]
            protected GetRelatedRequest() { }

            public GetRelatedRequest(
                List<GetRelatedRequest.ExcludeEnum>? exclude = default,
                List<GetRelatedRequest.IncludeEnum>? include = default,
                List<string>? spaceIds = default,
                List<string>? spaceKeys = default
            )
            {
                Exclude = exclude;
                Include = include;
                SpaceIds = spaceIds;
                SpaceKeys = spaceKeys;
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

                [EnumMember(Value = "access_methods")]
                AccessMethods = 6,
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

                [EnumMember(Value = "access_methods")]
                AccessMethods = 6,
            }

            [DataMember(Name = "exclude", IsRequired = false, EmitDefaultValue = false)]
            public List<GetRelatedRequest.ExcludeEnum>? Exclude { get; set; }

            [DataMember(Name = "include", IsRequired = false, EmitDefaultValue = false)]
            public List<GetRelatedRequest.IncludeEnum>? Include { get; set; }

            /// <summary>
            /// IDs of the spaces that you want to get along with their related resources.
            /// </summary>
            [DataMember(Name = "space_ids", IsRequired = false, EmitDefaultValue = false)]
            public List<string>? SpaceIds { get; set; }

            /// <summary>
            /// Keys of the spaces that you want to get along with their related resources.
            /// </summary>
            [DataMember(Name = "space_keys", IsRequired = false, EmitDefaultValue = false)]
            public List<string>? SpaceKeys { get; set; }

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
        /// Gets all related resources for one or more Spaces.
        /// </summary>
        public Batch GetRelated(GetRelatedRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            return _seam
                .Post<GetRelatedResponse>("/spaces/get_related", requestOptions)
                .EnsureData("/spaces/get_related")
                .Batch;
        }

        /// <summary>
        /// Gets all related resources for one or more Spaces.
        /// </summary>
        public Batch GetRelated(
            List<GetRelatedRequest.ExcludeEnum>? exclude = default,
            List<GetRelatedRequest.IncludeEnum>? include = default,
            List<string>? spaceIds = default,
            List<string>? spaceKeys = default
        )
        {
            return GetRelated(
                new GetRelatedRequest(
                    exclude: exclude,
                    include: include,
                    spaceIds: spaceIds,
                    spaceKeys: spaceKeys
                )
            );
        }

        /// <summary>
        /// Gets all related resources for one or more Spaces.
        /// </summary>
        public async Task<Batch> GetRelatedAsync(GetRelatedRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            return (
                await _seam.PostAsync<GetRelatedResponse>("/spaces/get_related", requestOptions)
            )
                .EnsureData("/spaces/get_related")
                .Batch;
        }

        /// <summary>
        /// Gets all related resources for one or more Spaces.
        /// </summary>
        public async Task<Batch> GetRelatedAsync(
            List<GetRelatedRequest.ExcludeEnum>? exclude = default,
            List<GetRelatedRequest.IncludeEnum>? include = default,
            List<string>? spaceIds = default,
            List<string>? spaceKeys = default
        )
        {
            return (
                await GetRelatedAsync(
                    new GetRelatedRequest(
                        exclude: exclude,
                        include: include,
                        spaceIds: spaceIds,
                        spaceKeys: spaceKeys
                    )
                )
            );
        }

        /// <summary>
        /// Request parameters for List Spaces.
        /// </summary>
        [DataContract(Name = "listRequest_request")]
        public class ListRequest
        {
            [JsonConstructorAttribute]
            protected ListRequest() { }

            public ListRequest(
                string? customerKey = default,
                float? limit = default,
                string? pageCursor = default,
                string? search = default,
                string? spaceKey = default
            )
            {
                CustomerKey = customerKey;
                Limit = limit;
                PageCursor = pageCursor;
                Search = search;
                SpaceKey = spaceKey;
            }

            /// <summary>
            /// Customer key for which you want to list spaces.
            /// </summary>
            [DataMember(Name = "customer_key", IsRequired = false, EmitDefaultValue = false)]
            public string? CustomerKey { get; set; }

            /// <summary>
            /// Maximum number of records to return per page.
            /// </summary>
            [DataMember(Name = "limit", IsRequired = false, EmitDefaultValue = false)]
            public float? Limit { get; set; }

            /// <summary>
            /// Identifies the specific page of results to return, obtained from the previous page&apos;s `next_page_cursor`.
            /// </summary>
            [DataMember(Name = "page_cursor", IsRequired = false, EmitDefaultValue = false)]
            public string? PageCursor { get; set; }

            /// <summary>
            /// String for which to search. Filters returned spaces to include all records that satisfy a partial match using `name`, `space_key`, or `customer_key`.
            /// </summary>
            [DataMember(Name = "search", IsRequired = false, EmitDefaultValue = false)]
            public string? Search { get; set; }

            /// <summary>
            /// Filter spaces by space_key.
            /// </summary>
            [DataMember(Name = "space_key", IsRequired = false, EmitDefaultValue = false)]
            public string? SpaceKey { get; set; }

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

            public ListResponse(List<Space> spaces = default)
            {
                Spaces = spaces;
            }

            /// <summary>
            /// OK
            /// </summary>
            [DataMember(Name = "spaces", IsRequired = false, EmitDefaultValue = false)]
            public List<Space> Spaces { get; set; }

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
        /// Returns a list of all spaces.
        /// </summary>
        public List<Space> List(ListRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            return _seam
                .Post<ListResponse>("/spaces/list", requestOptions)
                .EnsureData("/spaces/list")
                .Spaces;
        }

        /// <summary>
        /// Returns a list of all spaces.
        /// </summary>
        public List<Space> List(
            string? customerKey = default,
            float? limit = default,
            string? pageCursor = default,
            string? search = default,
            string? spaceKey = default
        )
        {
            return List(
                new ListRequest(
                    customerKey: customerKey,
                    limit: limit,
                    pageCursor: pageCursor,
                    search: search,
                    spaceKey: spaceKey
                )
            );
        }

        /// <summary>
        /// Returns a list of all spaces.
        /// </summary>
        public async Task<List<Space>> ListAsync(ListRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            return (await _seam.PostAsync<ListResponse>("/spaces/list", requestOptions))
                .EnsureData("/spaces/list")
                .Spaces;
        }

        /// <summary>
        /// Returns a list of all spaces.
        /// </summary>
        public async Task<List<Space>> ListAsync(
            string? customerKey = default,
            float? limit = default,
            string? pageCursor = default,
            string? search = default,
            string? spaceKey = default
        )
        {
            return (
                await ListAsync(
                    new ListRequest(
                        customerKey: customerKey,
                        limit: limit,
                        pageCursor: pageCursor,
                        search: search,
                        spaceKey: spaceKey
                    )
                )
            );
        }

        /// <summary>
        /// Request parameters for Remove Entrances from a Space.
        /// </summary>
        [DataContract(Name = "removeAcsEntrancesRequest_request")]
        public class RemoveAcsEntrancesRequest
        {
            [JsonConstructorAttribute]
            protected RemoveAcsEntrancesRequest() { }

            public RemoveAcsEntrancesRequest(
                List<string> acsEntranceIds = default,
                string spaceId = default
            )
            {
                AcsEntranceIds = acsEntranceIds;
                SpaceId = spaceId;
            }

            /// <summary>
            /// IDs of the entrances that you want to remove from the space.
            /// </summary>
            [DataMember(Name = "acs_entrance_ids", IsRequired = true, EmitDefaultValue = false)]
            public List<string> AcsEntranceIds { get; set; }

            /// <summary>
            /// ID of the space from which you want to remove entrances.
            /// </summary>
            [DataMember(Name = "space_id", IsRequired = true, EmitDefaultValue = false)]
            public string SpaceId { get; set; }

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
        /// Removes [entrances](https://docs.seam.co/low-level-apis/access-systems/retrieving-entrance-details) from a specific space.
        /// </summary>
        public void RemoveAcsEntrances(RemoveAcsEntrancesRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            _seam.Post<object>("/spaces/remove_acs_entrances", requestOptions);
        }

        /// <summary>
        /// Removes [entrances](https://docs.seam.co/low-level-apis/access-systems/retrieving-entrance-details) from a specific space.
        /// </summary>
        public void RemoveAcsEntrances(
            List<string> acsEntranceIds = default,
            string spaceId = default
        )
        {
            RemoveAcsEntrances(
                new RemoveAcsEntrancesRequest(acsEntranceIds: acsEntranceIds, spaceId: spaceId)
            );
        }

        /// <summary>
        /// Removes [entrances](https://docs.seam.co/low-level-apis/access-systems/retrieving-entrance-details) from a specific space.
        /// </summary>
        public async Task RemoveAcsEntrancesAsync(RemoveAcsEntrancesRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            await _seam.PostAsync<object>("/spaces/remove_acs_entrances", requestOptions);
        }

        /// <summary>
        /// Removes [entrances](https://docs.seam.co/low-level-apis/access-systems/retrieving-entrance-details) from a specific space.
        /// </summary>
        public async Task RemoveAcsEntrancesAsync(
            List<string> acsEntranceIds = default,
            string spaceId = default
        )
        {
            await RemoveAcsEntrancesAsync(
                new RemoveAcsEntrancesRequest(acsEntranceIds: acsEntranceIds, spaceId: spaceId)
            );
        }

        /// <summary>
        /// Request parameters for Remove a Connected Account from a Space.
        /// </summary>
        [DataContract(Name = "removeConnectedAccountRequest_request")]
        public class RemoveConnectedAccountRequest
        {
            [JsonConstructorAttribute]
            protected RemoveConnectedAccountRequest() { }

            public RemoveConnectedAccountRequest(
                string connectedAccountId = default,
                string spaceId = default
            )
            {
                ConnectedAccountId = connectedAccountId;
                SpaceId = spaceId;
            }

            /// <summary>
            /// ID of the connected account that you want to remove from the space.
            /// </summary>
            [DataMember(Name = "connected_account_id", IsRequired = true, EmitDefaultValue = false)]
            public string ConnectedAccountId { get; set; }

            /// <summary>
            /// ID of the space from which you want to remove the connected account.
            /// </summary>
            [DataMember(Name = "space_id", IsRequired = true, EmitDefaultValue = false)]
            public string SpaceId { get; set; }

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
        /// Removes a [connected account](https://docs.seam.co/core-concepts/connected-accounts) from a specific space.
        /// </summary>
        public void RemoveConnectedAccount(RemoveConnectedAccountRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            _seam.Post<object>("/spaces/remove_connected_account", requestOptions);
        }

        /// <summary>
        /// Removes a [connected account](https://docs.seam.co/core-concepts/connected-accounts) from a specific space.
        /// </summary>
        public void RemoveConnectedAccount(
            string connectedAccountId = default,
            string spaceId = default
        )
        {
            RemoveConnectedAccount(
                new RemoveConnectedAccountRequest(
                    connectedAccountId: connectedAccountId,
                    spaceId: spaceId
                )
            );
        }

        /// <summary>
        /// Removes a [connected account](https://docs.seam.co/core-concepts/connected-accounts) from a specific space.
        /// </summary>
        public async Task RemoveConnectedAccountAsync(RemoveConnectedAccountRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            await _seam.PostAsync<object>("/spaces/remove_connected_account", requestOptions);
        }

        /// <summary>
        /// Removes a [connected account](https://docs.seam.co/core-concepts/connected-accounts) from a specific space.
        /// </summary>
        public async Task RemoveConnectedAccountAsync(
            string connectedAccountId = default,
            string spaceId = default
        )
        {
            await RemoveConnectedAccountAsync(
                new RemoveConnectedAccountRequest(
                    connectedAccountId: connectedAccountId,
                    spaceId: spaceId
                )
            );
        }

        /// <summary>
        /// Request parameters for Remove Devices from a Space.
        /// </summary>
        [DataContract(Name = "removeDevicesRequest_request")]
        public class RemoveDevicesRequest
        {
            [JsonConstructorAttribute]
            protected RemoveDevicesRequest() { }

            public RemoveDevicesRequest(List<string> deviceIds = default, string spaceId = default)
            {
                DeviceIds = deviceIds;
                SpaceId = spaceId;
            }

            /// <summary>
            /// IDs of the devices that you want to remove from the space.
            /// </summary>
            [DataMember(Name = "device_ids", IsRequired = true, EmitDefaultValue = false)]
            public List<string> DeviceIds { get; set; }

            /// <summary>
            /// ID of the space from which you want to remove devices.
            /// </summary>
            [DataMember(Name = "space_id", IsRequired = true, EmitDefaultValue = false)]
            public string SpaceId { get; set; }

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
        /// Removes devices from a specific space.
        /// </summary>
        public void RemoveDevices(RemoveDevicesRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            _seam.Post<object>("/spaces/remove_devices", requestOptions);
        }

        /// <summary>
        /// Removes devices from a specific space.
        /// </summary>
        public void RemoveDevices(List<string> deviceIds = default, string spaceId = default)
        {
            RemoveDevices(new RemoveDevicesRequest(deviceIds: deviceIds, spaceId: spaceId));
        }

        /// <summary>
        /// Removes devices from a specific space.
        /// </summary>
        public async Task RemoveDevicesAsync(RemoveDevicesRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            await _seam.PostAsync<object>("/spaces/remove_devices", requestOptions);
        }

        /// <summary>
        /// Removes devices from a specific space.
        /// </summary>
        public async Task RemoveDevicesAsync(
            List<string> deviceIds = default,
            string spaceId = default
        )
        {
            await RemoveDevicesAsync(
                new RemoveDevicesRequest(deviceIds: deviceIds, spaceId: spaceId)
            );
        }

        /// <summary>
        /// Request parameters for Update a Space.
        /// </summary>
        [DataContract(Name = "updateRequest_request")]
        public class UpdateRequest
        {
            [JsonConstructorAttribute]
            protected UpdateRequest() { }

            public UpdateRequest(
                List<string>? acsEntranceIds = default,
                UpdateRequestCustomerData? customerData = default,
                List<string>? deviceIds = default,
                string? name = default,
                string? spaceId = default,
                string? spaceKey = default
            )
            {
                AcsEntranceIds = acsEntranceIds;
                CustomerData = customerData;
                DeviceIds = deviceIds;
                Name = name;
                SpaceId = spaceId;
                SpaceKey = spaceKey;
            }

            /// <summary>
            /// IDs of the entrances that you want to set for the space. If specified, this will replace all existing entrances.
            /// </summary>
            [DataMember(Name = "acs_entrance_ids", IsRequired = false, EmitDefaultValue = false)]
            public List<string>? AcsEntranceIds { get; set; }

            /// <summary>
            /// Reservation/stay-related defaults for the space. Only the keys you provide are updated; omit a key to leave it unchanged. Pass null on a key to clear it.
            /// </summary>
            [DataMember(Name = "customer_data", IsRequired = false, EmitDefaultValue = false)]
            public UpdateRequestCustomerData? CustomerData { get; set; }

            /// <summary>
            /// IDs of the devices that you want to set for the space. If specified, this will replace all existing devices.
            /// </summary>
            [DataMember(Name = "device_ids", IsRequired = false, EmitDefaultValue = false)]
            public List<string>? DeviceIds { get; set; }

            /// <summary>
            /// Name of the space.
            /// </summary>
            [DataMember(Name = "name", IsRequired = false, EmitDefaultValue = false)]
            public string? Name { get; set; }

            /// <summary>
            /// ID of the space that you want to update.
            /// </summary>
            [DataMember(Name = "space_id", IsRequired = false, EmitDefaultValue = false)]
            public string? SpaceId { get; set; }

            /// <summary>
            /// Unique key of the space that you want to update.
            /// </summary>
            [DataMember(Name = "space_key", IsRequired = false, EmitDefaultValue = false)]
            public string? SpaceKey { get; set; }

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

        [DataContract(Name = "updateRequestCustomerData_model")]
        public class UpdateRequestCustomerData
        {
            [JsonConstructorAttribute]
            protected UpdateRequestCustomerData() { }

            public UpdateRequestCustomerData(
                string? address = default,
                string? defaultCheckinTime = default,
                string? defaultCheckoutTime = default,
                string? timeZone = default
            )
            {
                Address = address;
                DefaultCheckinTime = defaultCheckinTime;
                DefaultCheckoutTime = defaultCheckoutTime;
                TimeZone = timeZone;
            }

            /// <summary>
            /// Postal address for the space.
            /// </summary>
            [DataMember(Name = "address", IsRequired = false, EmitDefaultValue = false)]
            public string? Address { get; set; }

            /// <summary>
            /// Default check-in time for reservations at the space, as HH:mm or HH:mm:ss.
            /// </summary>
            [DataMember(
                Name = "default_checkin_time",
                IsRequired = false,
                EmitDefaultValue = false
            )]
            public string? DefaultCheckinTime { get; set; }

            /// <summary>
            /// Default check-out time for reservations at the space, as HH:mm or HH:mm:ss.
            /// </summary>
            [DataMember(
                Name = "default_checkout_time",
                IsRequired = false,
                EmitDefaultValue = false
            )]
            public string? DefaultCheckoutTime { get; set; }

            /// <summary>
            /// IANA time zone for the space, e.g. America/Los_Angeles.
            /// </summary>
            [DataMember(Name = "time_zone", IsRequired = false, EmitDefaultValue = false)]
            public string? TimeZone { get; set; }

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

        [DataContract(Name = "updateResponse_response")]
        public class UpdateResponse
        {
            [JsonConstructorAttribute]
            protected UpdateResponse() { }

            public UpdateResponse(Space space = default)
            {
                Space = space;
            }

            /// <summary>
            /// OK
            /// </summary>
            [DataMember(Name = "space", IsRequired = false, EmitDefaultValue = false)]
            public Space Space { get; set; }

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
        /// Updates an existing space.
        /// </summary>
        public Space Update(UpdateRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            return _seam
                .Patch<UpdateResponse>("/spaces/update", requestOptions)
                .EnsureData("/spaces/update")
                .Space;
        }

        /// <summary>
        /// Updates an existing space.
        /// </summary>
        public Space Update(
            List<string>? acsEntranceIds = default,
            UpdateRequestCustomerData? customerData = default,
            List<string>? deviceIds = default,
            string? name = default,
            string? spaceId = default,
            string? spaceKey = default
        )
        {
            return Update(
                new UpdateRequest(
                    acsEntranceIds: acsEntranceIds,
                    customerData: customerData,
                    deviceIds: deviceIds,
                    name: name,
                    spaceId: spaceId,
                    spaceKey: spaceKey
                )
            );
        }

        /// <summary>
        /// Updates an existing space.
        /// </summary>
        public async Task<Space> UpdateAsync(UpdateRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            return (await _seam.PatchAsync<UpdateResponse>("/spaces/update", requestOptions))
                .EnsureData("/spaces/update")
                .Space;
        }

        /// <summary>
        /// Updates an existing space.
        /// </summary>
        public async Task<Space> UpdateAsync(
            List<string>? acsEntranceIds = default,
            UpdateRequestCustomerData? customerData = default,
            List<string>? deviceIds = default,
            string? name = default,
            string? spaceId = default,
            string? spaceKey = default
        )
        {
            return (
                await UpdateAsync(
                    new UpdateRequest(
                        acsEntranceIds: acsEntranceIds,
                        customerData: customerData,
                        deviceIds: deviceIds,
                        name: name,
                        spaceId: spaceId,
                        spaceKey: spaceKey
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
        public Api.Spaces Spaces => new(this);
    }

    public partial interface ISeamClient
    {
        public Api.Spaces Spaces { get; }
    }
}
