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

            [DataMember(Name = "acs_entrance_ids", IsRequired = true, EmitDefaultValue = false)]
            public List<string> AcsEntranceIds { get; set; }

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

        public void AddAcsEntrances(AddAcsEntrancesRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            _seam.Post<object>("/spaces/add_acs_entrances", requestOptions);
        }

        public void AddAcsEntrances(List<string> acsEntranceIds = default, string spaceId = default)
        {
            AddAcsEntrances(
                new AddAcsEntrancesRequest(acsEntranceIds: acsEntranceIds, spaceId: spaceId)
            );
        }

        public async Task AddAcsEntrancesAsync(AddAcsEntrancesRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            await _seam.PostAsync<object>("/spaces/add_acs_entrances", requestOptions);
        }

        public async Task AddAcsEntrancesAsync(
            List<string> acsEntranceIds = default,
            string spaceId = default
        )
        {
            await AddAcsEntrancesAsync(
                new AddAcsEntrancesRequest(acsEntranceIds: acsEntranceIds, spaceId: spaceId)
            );
        }

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

            [DataMember(Name = "device_ids", IsRequired = true, EmitDefaultValue = false)]
            public List<string> DeviceIds { get; set; }

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

        public void AddDevices(AddDevicesRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            _seam.Post<object>("/spaces/add_devices", requestOptions);
        }

        public void AddDevices(List<string> deviceIds = default, string spaceId = default)
        {
            AddDevices(new AddDevicesRequest(deviceIds: deviceIds, spaceId: spaceId));
        }

        public async Task AddDevicesAsync(AddDevicesRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            await _seam.PostAsync<object>("/spaces/add_devices", requestOptions);
        }

        public async Task AddDevicesAsync(
            List<string> deviceIds = default,
            string spaceId = default
        )
        {
            await AddDevicesAsync(new AddDevicesRequest(deviceIds: deviceIds, spaceId: spaceId));
        }

        [DataContract(Name = "createRequest_request")]
        public class CreateRequest
        {
            [JsonConstructorAttribute]
            protected CreateRequest() { }

            public CreateRequest(
                List<string>? acsEntranceIds = default,
                List<string>? deviceIds = default,
                string name = default,
                string? spaceKey = default
            )
            {
                AcsEntranceIds = acsEntranceIds;
                DeviceIds = deviceIds;
                Name = name;
                SpaceKey = spaceKey;
            }

            [DataMember(Name = "acs_entrance_ids", IsRequired = false, EmitDefaultValue = false)]
            public List<string>? AcsEntranceIds { get; set; }

            [DataMember(Name = "device_ids", IsRequired = false, EmitDefaultValue = false)]
            public List<string>? DeviceIds { get; set; }

            [DataMember(Name = "name", IsRequired = true, EmitDefaultValue = false)]
            public string Name { get; set; }

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

        [DataContract(Name = "createResponse_response")]
        public class CreateResponse
        {
            [JsonConstructorAttribute]
            protected CreateResponse() { }

            public CreateResponse(Space space = default)
            {
                Space = space;
            }

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

        public Space Create(CreateRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            return _seam.Post<CreateResponse>("/spaces/create", requestOptions).Data.Space;
        }

        public Space Create(
            List<string>? acsEntranceIds = default,
            List<string>? deviceIds = default,
            string name = default,
            string? spaceKey = default
        )
        {
            return Create(
                new CreateRequest(
                    acsEntranceIds: acsEntranceIds,
                    deviceIds: deviceIds,
                    name: name,
                    spaceKey: spaceKey
                )
            );
        }

        public async Task<Space> CreateAsync(CreateRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            return (await _seam.PostAsync<CreateResponse>("/spaces/create", requestOptions))
                .Data
                .Space;
        }

        public async Task<Space> CreateAsync(
            List<string>? acsEntranceIds = default,
            List<string>? deviceIds = default,
            string name = default,
            string? spaceKey = default
        )
        {
            return (
                await CreateAsync(
                    new CreateRequest(
                        acsEntranceIds: acsEntranceIds,
                        deviceIds: deviceIds,
                        name: name,
                        spaceKey: spaceKey
                    )
                )
            );
        }

        [DataContract(Name = "deleteRequest_request")]
        public class DeleteRequest
        {
            [JsonConstructorAttribute]
            protected DeleteRequest() { }

            public DeleteRequest(string spaceId = default)
            {
                SpaceId = spaceId;
            }

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

        public void Delete(DeleteRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            _seam.Post<object>("/spaces/delete", requestOptions);
        }

        public void Delete(string spaceId = default)
        {
            Delete(new DeleteRequest(spaceId: spaceId));
        }

        public async Task DeleteAsync(DeleteRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            await _seam.PostAsync<object>("/spaces/delete", requestOptions);
        }

        public async Task DeleteAsync(string spaceId = default)
        {
            await DeleteAsync(new DeleteRequest(spaceId: spaceId));
        }

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

            [DataMember(Name = "space_id", IsRequired = false, EmitDefaultValue = false)]
            public string? SpaceId { get; set; }

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

        public Space Get(GetRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            return _seam.Post<GetResponse>("/spaces/get", requestOptions).Data.Space;
        }

        public Space Get(string? spaceId = default, string? spaceKey = default)
        {
            return Get(new GetRequest(spaceId: spaceId, spaceKey: spaceKey));
        }

        public async Task<Space> GetAsync(GetRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            return (await _seam.PostAsync<GetResponse>("/spaces/get", requestOptions)).Data.Space;
        }

        public async Task<Space> GetAsync(string? spaceId = default, string? spaceKey = default)
        {
            return (await GetAsync(new GetRequest(spaceId: spaceId, spaceKey: spaceKey)));
        }

        [DataContract(Name = "listRequest_request")]
        public class ListRequest
        {
            [JsonConstructorAttribute]
            protected ListRequest() { }

            public ListRequest(
                string? connectedAccountId = default,
                string? search = default,
                string? spaceKey = default
            )
            {
                ConnectedAccountId = connectedAccountId;
                Search = search;
                SpaceKey = spaceKey;
            }

            [DataMember(
                Name = "connected_account_id",
                IsRequired = false,
                EmitDefaultValue = false
            )]
            public string? ConnectedAccountId { get; set; }

            [DataMember(Name = "search", IsRequired = false, EmitDefaultValue = false)]
            public string? Search { get; set; }

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

        public List<Space> List(ListRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            return _seam.Post<ListResponse>("/spaces/list", requestOptions).Data.Spaces;
        }

        public List<Space> List(
            string? connectedAccountId = default,
            string? search = default,
            string? spaceKey = default
        )
        {
            return List(
                new ListRequest(
                    connectedAccountId: connectedAccountId,
                    search: search,
                    spaceKey: spaceKey
                )
            );
        }

        public async Task<List<Space>> ListAsync(ListRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            return (await _seam.PostAsync<ListResponse>("/spaces/list", requestOptions))
                .Data
                .Spaces;
        }

        public async Task<List<Space>> ListAsync(
            string? connectedAccountId = default,
            string? search = default,
            string? spaceKey = default
        )
        {
            return (
                await ListAsync(
                    new ListRequest(
                        connectedAccountId: connectedAccountId,
                        search: search,
                        spaceKey: spaceKey
                    )
                )
            );
        }

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

            [DataMember(Name = "acs_entrance_ids", IsRequired = true, EmitDefaultValue = false)]
            public List<string> AcsEntranceIds { get; set; }

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

        public void RemoveAcsEntrances(RemoveAcsEntrancesRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            _seam.Post<object>("/spaces/remove_acs_entrances", requestOptions);
        }

        public void RemoveAcsEntrances(
            List<string> acsEntranceIds = default,
            string spaceId = default
        )
        {
            RemoveAcsEntrances(
                new RemoveAcsEntrancesRequest(acsEntranceIds: acsEntranceIds, spaceId: spaceId)
            );
        }

        public async Task RemoveAcsEntrancesAsync(RemoveAcsEntrancesRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            await _seam.PostAsync<object>("/spaces/remove_acs_entrances", requestOptions);
        }

        public async Task RemoveAcsEntrancesAsync(
            List<string> acsEntranceIds = default,
            string spaceId = default
        )
        {
            await RemoveAcsEntrancesAsync(
                new RemoveAcsEntrancesRequest(acsEntranceIds: acsEntranceIds, spaceId: spaceId)
            );
        }

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

            [DataMember(Name = "device_ids", IsRequired = true, EmitDefaultValue = false)]
            public List<string> DeviceIds { get; set; }

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

        public void RemoveDevices(RemoveDevicesRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            _seam.Post<object>("/spaces/remove_devices", requestOptions);
        }

        public void RemoveDevices(List<string> deviceIds = default, string spaceId = default)
        {
            RemoveDevices(new RemoveDevicesRequest(deviceIds: deviceIds, spaceId: spaceId));
        }

        public async Task RemoveDevicesAsync(RemoveDevicesRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            await _seam.PostAsync<object>("/spaces/remove_devices", requestOptions);
        }

        public async Task RemoveDevicesAsync(
            List<string> deviceIds = default,
            string spaceId = default
        )
        {
            await RemoveDevicesAsync(
                new RemoveDevicesRequest(deviceIds: deviceIds, spaceId: spaceId)
            );
        }

        [DataContract(Name = "updateRequest_request")]
        public class UpdateRequest
        {
            [JsonConstructorAttribute]
            protected UpdateRequest() { }

            public UpdateRequest(
                List<string>? acsEntranceIds = default,
                List<string>? deviceIds = default,
                string? name = default,
                string? spaceId = default,
                string? spaceKey = default
            )
            {
                AcsEntranceIds = acsEntranceIds;
                DeviceIds = deviceIds;
                Name = name;
                SpaceId = spaceId;
                SpaceKey = spaceKey;
            }

            [DataMember(Name = "acs_entrance_ids", IsRequired = false, EmitDefaultValue = false)]
            public List<string>? AcsEntranceIds { get; set; }

            [DataMember(Name = "device_ids", IsRequired = false, EmitDefaultValue = false)]
            public List<string>? DeviceIds { get; set; }

            [DataMember(Name = "name", IsRequired = false, EmitDefaultValue = false)]
            public string? Name { get; set; }

            [DataMember(Name = "space_id", IsRequired = false, EmitDefaultValue = false)]
            public string? SpaceId { get; set; }

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

        [DataContract(Name = "updateResponse_response")]
        public class UpdateResponse
        {
            [JsonConstructorAttribute]
            protected UpdateResponse() { }

            public UpdateResponse(Space space = default)
            {
                Space = space;
            }

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

        public Space Update(UpdateRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            return _seam.Post<UpdateResponse>("/spaces/update", requestOptions).Data.Space;
        }

        public Space Update(
            List<string>? acsEntranceIds = default,
            List<string>? deviceIds = default,
            string? name = default,
            string? spaceId = default,
            string? spaceKey = default
        )
        {
            return Update(
                new UpdateRequest(
                    acsEntranceIds: acsEntranceIds,
                    deviceIds: deviceIds,
                    name: name,
                    spaceId: spaceId,
                    spaceKey: spaceKey
                )
            );
        }

        public async Task<Space> UpdateAsync(UpdateRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            return (await _seam.PostAsync<UpdateResponse>("/spaces/update", requestOptions))
                .Data
                .Space;
        }

        public async Task<Space> UpdateAsync(
            List<string>? acsEntranceIds = default,
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
