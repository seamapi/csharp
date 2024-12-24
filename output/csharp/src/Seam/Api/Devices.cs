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
    public class Devices
    {
        private ISeamClient _seam;

        public Devices(ISeamClient seam)
        {
            _seam = seam;
        }

        [DataContract(Name = "deleteRequest_request")]
        public class DeleteRequest
        {
            [JsonConstructorAttribute]
            protected DeleteRequest() { }

            public DeleteRequest(string deviceId = default)
            {
                DeviceId = deviceId;
            }

            [DataMember(Name = "device_id", IsRequired = true, EmitDefaultValue = false)]
            public string DeviceId { get; set; }

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
            _seam.Post<object>("/devices/delete", requestOptions);
        }

        public void Delete(string deviceId = default)
        {
            Delete(new DeleteRequest(deviceId: deviceId));
        }

        public async Task DeleteAsync(DeleteRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            await _seam.PostAsync<object>("/devices/delete", requestOptions);
        }

        public async Task DeleteAsync(string deviceId = default)
        {
            await DeleteAsync(new DeleteRequest(deviceId: deviceId));
        }

        [DataContract(Name = "getRequest_request")]
        public class GetRequest
        {
            [JsonConstructorAttribute]
            protected GetRequest() { }

            public GetRequest(string? deviceId = default, string? name = default)
            {
                DeviceId = deviceId;
                Name = name;
            }

            [DataMember(Name = "device_id", IsRequired = false, EmitDefaultValue = false)]
            public string? DeviceId { get; set; }

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

        [DataContract(Name = "getResponse_response")]
        public class GetResponse
        {
            [JsonConstructorAttribute]
            protected GetResponse() { }

            public GetResponse(Device device = default)
            {
                Device = device;
            }

            [DataMember(Name = "device", IsRequired = false, EmitDefaultValue = false)]
            public Device Device { get; set; }

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

        public Device Get(GetRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            return _seam.Post<GetResponse>("/devices/get", requestOptions).Data.Device;
        }

        public Device Get(string? deviceId = default, string? name = default)
        {
            return Get(new GetRequest(deviceId: deviceId, name: name));
        }

        public async Task<Device> GetAsync(GetRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            return (await _seam.PostAsync<GetResponse>("/devices/get", requestOptions)).Data.Device;
        }

        public async Task<Device> GetAsync(string? deviceId = default, string? name = default)
        {
            return (await GetAsync(new GetRequest(deviceId: deviceId, name: name)));
        }

        [DataContract(Name = "listRequest_request")]
        public class ListRequest
        {
            [JsonConstructorAttribute]
            protected ListRequest() { }

            public ListRequest(
                string? connectWebviewId = default,
                string? connectedAccountId = default,
                List<string>? connectedAccountIds = default,
                string? createdBefore = default,
                object? customMetadataHas = default,
                List<string>? deviceIds = default,
                string? deviceType = default,
                List<ListRequest.DeviceTypesEnum>? deviceTypes = default,
                List<ListRequest.ExcludeIfEnum>? excludeIf = default,
                List<ListRequest.IncludeIfEnum>? includeIf = default,
                float? limit = default,
                ListRequest.ManufacturerEnum? manufacturer = default,
                string? userIdentifierKey = default
            )
            {
                ConnectWebviewId = connectWebviewId;
                ConnectedAccountId = connectedAccountId;
                ConnectedAccountIds = connectedAccountIds;
                CreatedBefore = createdBefore;
                CustomMetadataHas = customMetadataHas;
                DeviceIds = deviceIds;
                DeviceType = deviceType;
                DeviceTypes = deviceTypes;
                ExcludeIf = excludeIf;
                IncludeIf = includeIf;
                Limit = limit;
                Manufacturer = manufacturer;
                UserIdentifierKey = userIdentifierKey;
            }

            [JsonConverter(typeof(SafeStringEnumConverter))]
            public enum DeviceTypesEnum
            {
                [EnumMember(Value = "unrecognized")]
                Unrecognized = 0,

                [EnumMember(Value = "akuvox_lock")]
                AkuvoxLock = 1,

                [EnumMember(Value = "august_lock")]
                AugustLock = 2,

                [EnumMember(Value = "brivo_access_point")]
                BrivoAccessPoint = 3,

                [EnumMember(Value = "butterflymx_panel")]
                ButterflymxPanel = 4,

                [EnumMember(Value = "avigilon_alta_entry")]
                AvigilonAltaEntry = 5,

                [EnumMember(Value = "doorking_lock")]
                DoorkingLock = 6,

                [EnumMember(Value = "genie_door")]
                GenieDoor = 7,

                [EnumMember(Value = "igloo_lock")]
                IglooLock = 8,

                [EnumMember(Value = "linear_lock")]
                LinearLock = 9,

                [EnumMember(Value = "lockly_lock")]
                LocklyLock = 10,

                [EnumMember(Value = "kwikset_lock")]
                KwiksetLock = 11,

                [EnumMember(Value = "nuki_lock")]
                NukiLock = 12,

                [EnumMember(Value = "salto_lock")]
                SaltoLock = 13,

                [EnumMember(Value = "schlage_lock")]
                SchlageLock = 14,

                [EnumMember(Value = "seam_relay")]
                SeamRelay = 15,

                [EnumMember(Value = "smartthings_lock")]
                SmartthingsLock = 16,

                [EnumMember(Value = "wyze_lock")]
                WyzeLock = 17,

                [EnumMember(Value = "yale_lock")]
                YaleLock = 18,

                [EnumMember(Value = "two_n_intercom")]
                TwoNIntercom = 19,

                [EnumMember(Value = "controlbyweb_device")]
                ControlbywebDevice = 20,

                [EnumMember(Value = "ttlock_lock")]
                TtlockLock = 21,

                [EnumMember(Value = "igloohome_lock")]
                IgloohomeLock = 22,

                [EnumMember(Value = "hubitat_lock")]
                HubitatLock = 23,

                [EnumMember(Value = "four_suites_door")]
                FourSuitesDoor = 24,

                [EnumMember(Value = "dormakaba_oracode_door")]
                DormakabaOracodeDoor = 25,

                [EnumMember(Value = "tedee_lock")]
                TedeeLock = 26,

                [EnumMember(Value = "akiles_lock")]
                AkilesLock = 27,

                [EnumMember(Value = "noiseaware_activity_zone")]
                NoiseawareActivityZone = 28,

                [EnumMember(Value = "minut_sensor")]
                MinutSensor = 29,

                [EnumMember(Value = "ecobee_thermostat")]
                EcobeeThermostat = 30,

                [EnumMember(Value = "nest_thermostat")]
                NestThermostat = 31,

                [EnumMember(Value = "honeywell_resideo_thermostat")]
                HoneywellResideoThermostat = 32,

                [EnumMember(Value = "tado_thermostat")]
                TadoThermostat = 33,

                [EnumMember(Value = "ios_phone")]
                IosPhone = 34,

                [EnumMember(Value = "android_phone")]
                AndroidPhone = 35,
            }

            [JsonConverter(typeof(SafeStringEnumConverter))]
            public enum ExcludeIfEnum
            {
                [EnumMember(Value = "unrecognized")]
                Unrecognized = 0,

                [EnumMember(Value = "can_remotely_unlock")]
                CanRemotelyUnlock = 1,

                [EnumMember(Value = "can_remotely_lock")]
                CanRemotelyLock = 2,

                [EnumMember(Value = "can_program_offline_access_codes")]
                CanProgramOfflineAccessCodes = 3,

                [EnumMember(Value = "can_program_online_access_codes")]
                CanProgramOnlineAccessCodes = 4,

                [EnumMember(Value = "can_hvac_heat")]
                CanHvacHeat = 5,

                [EnumMember(Value = "can_hvac_cool")]
                CanHvacCool = 6,

                [EnumMember(Value = "can_hvac_heat_cool")]
                CanHvacHeatCool = 7,

                [EnumMember(Value = "can_turn_off_hvac")]
                CanTurnOffHvac = 8,

                [EnumMember(Value = "can_simulate_removal")]
                CanSimulateRemoval = 9,

                [EnumMember(Value = "can_simulate_connection")]
                CanSimulateConnection = 10,

                [EnumMember(Value = "can_simulate_disconnection")]
                CanSimulateDisconnection = 11,
            }

            [JsonConverter(typeof(SafeStringEnumConverter))]
            public enum IncludeIfEnum
            {
                [EnumMember(Value = "unrecognized")]
                Unrecognized = 0,

                [EnumMember(Value = "can_remotely_unlock")]
                CanRemotelyUnlock = 1,

                [EnumMember(Value = "can_remotely_lock")]
                CanRemotelyLock = 2,

                [EnumMember(Value = "can_program_offline_access_codes")]
                CanProgramOfflineAccessCodes = 3,

                [EnumMember(Value = "can_program_online_access_codes")]
                CanProgramOnlineAccessCodes = 4,

                [EnumMember(Value = "can_hvac_heat")]
                CanHvacHeat = 5,

                [EnumMember(Value = "can_hvac_cool")]
                CanHvacCool = 6,

                [EnumMember(Value = "can_hvac_heat_cool")]
                CanHvacHeatCool = 7,

                [EnumMember(Value = "can_turn_off_hvac")]
                CanTurnOffHvac = 8,

                [EnumMember(Value = "can_simulate_removal")]
                CanSimulateRemoval = 9,

                [EnumMember(Value = "can_simulate_connection")]
                CanSimulateConnection = 10,

                [EnumMember(Value = "can_simulate_disconnection")]
                CanSimulateDisconnection = 11,
            }

            [JsonConverter(typeof(SafeStringEnumConverter))]
            public enum ManufacturerEnum
            {
                [EnumMember(Value = "unrecognized")]
                Unrecognized = 0,

                [EnumMember(Value = "akuvox")]
                Akuvox = 1,

                [EnumMember(Value = "august")]
                August = 2,

                [EnumMember(Value = "avigilon_alta")]
                AvigilonAlta = 3,

                [EnumMember(Value = "brivo")]
                Brivo = 4,

                [EnumMember(Value = "butterflymx")]
                Butterflymx = 5,

                [EnumMember(Value = "doorking")]
                Doorking = 6,

                [EnumMember(Value = "four_suites")]
                FourSuites = 7,

                [EnumMember(Value = "genie")]
                Genie = 8,

                [EnumMember(Value = "igloo")]
                Igloo = 9,

                [EnumMember(Value = "keywe")]
                Keywe = 10,

                [EnumMember(Value = "kwikset")]
                Kwikset = 11,

                [EnumMember(Value = "linear")]
                Linear = 12,

                [EnumMember(Value = "lockly")]
                Lockly = 13,

                [EnumMember(Value = "nuki")]
                Nuki = 14,

                [EnumMember(Value = "philia")]
                Philia = 15,

                [EnumMember(Value = "salto")]
                Salto = 16,

                [EnumMember(Value = "samsung")]
                Samsung = 17,

                [EnumMember(Value = "schlage")]
                Schlage = 18,

                [EnumMember(Value = "seam")]
                Seam = 19,

                [EnumMember(Value = "unknown")]
                Unknown = 20,

                [EnumMember(Value = "wyze")]
                Wyze = 21,

                [EnumMember(Value = "yale")]
                Yale = 22,

                [EnumMember(Value = "minut")]
                Minut = 23,

                [EnumMember(Value = "two_n")]
                TwoN = 24,

                [EnumMember(Value = "ttlock")]
                Ttlock = 25,

                [EnumMember(Value = "nest")]
                Nest = 26,

                [EnumMember(Value = "igloohome")]
                Igloohome = 27,

                [EnumMember(Value = "ecobee")]
                Ecobee = 28,

                [EnumMember(Value = "hubitat")]
                Hubitat = 29,

                [EnumMember(Value = "controlbyweb")]
                Controlbyweb = 30,

                [EnumMember(Value = "smartthings")]
                Smartthings = 31,

                [EnumMember(Value = "dormakaba_oracode")]
                DormakabaOracode = 32,

                [EnumMember(Value = "tedee")]
                Tedee = 33,

                [EnumMember(Value = "honeywell_resideo")]
                HoneywellResideo = 34,

                [EnumMember(Value = "akiles")]
                Akiles = 35,

                [EnumMember(Value = "tado")]
                Tado = 36,
            }

            [DataMember(Name = "connect_webview_id", IsRequired = false, EmitDefaultValue = false)]
            public string? ConnectWebviewId { get; set; }

            [DataMember(
                Name = "connected_account_id",
                IsRequired = false,
                EmitDefaultValue = false
            )]
            public string? ConnectedAccountId { get; set; }

            [DataMember(
                Name = "connected_account_ids",
                IsRequired = false,
                EmitDefaultValue = false
            )]
            public List<string>? ConnectedAccountIds { get; set; }

            [DataMember(Name = "created_before", IsRequired = false, EmitDefaultValue = false)]
            public string? CreatedBefore { get; set; }

            [DataMember(Name = "custom_metadata_has", IsRequired = false, EmitDefaultValue = false)]
            public object? CustomMetadataHas { get; set; }

            [DataMember(Name = "device_ids", IsRequired = false, EmitDefaultValue = false)]
            public List<string>? DeviceIds { get; set; }

            [DataMember(Name = "device_type", IsRequired = false, EmitDefaultValue = false)]
            public string? DeviceType { get; set; }

            [DataMember(Name = "device_types", IsRequired = false, EmitDefaultValue = false)]
            public List<ListRequest.DeviceTypesEnum>? DeviceTypes { get; set; }

            [DataMember(Name = "exclude_if", IsRequired = false, EmitDefaultValue = false)]
            public List<ListRequest.ExcludeIfEnum>? ExcludeIf { get; set; }

            [DataMember(Name = "include_if", IsRequired = false, EmitDefaultValue = false)]
            public List<ListRequest.IncludeIfEnum>? IncludeIf { get; set; }

            [DataMember(Name = "limit", IsRequired = false, EmitDefaultValue = false)]
            public float? Limit { get; set; }

            [DataMember(Name = "manufacturer", IsRequired = false, EmitDefaultValue = false)]
            public ListRequest.ManufacturerEnum? Manufacturer { get; set; }

            [DataMember(Name = "user_identifier_key", IsRequired = false, EmitDefaultValue = false)]
            public string? UserIdentifierKey { get; set; }

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

            public ListResponse(List<Device> devices = default)
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

        public List<Device> List(ListRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            return _seam.Post<ListResponse>("/devices/list", requestOptions).Data.Devices;
        }

        public List<Device> List(
            string? connectWebviewId = default,
            string? connectedAccountId = default,
            List<string>? connectedAccountIds = default,
            string? createdBefore = default,
            object? customMetadataHas = default,
            List<string>? deviceIds = default,
            string? deviceType = default,
            List<ListRequest.DeviceTypesEnum>? deviceTypes = default,
            List<ListRequest.ExcludeIfEnum>? excludeIf = default,
            List<ListRequest.IncludeIfEnum>? includeIf = default,
            float? limit = default,
            ListRequest.ManufacturerEnum? manufacturer = default,
            string? userIdentifierKey = default
        )
        {
            return List(
                new ListRequest(
                    connectWebviewId: connectWebviewId,
                    connectedAccountId: connectedAccountId,
                    connectedAccountIds: connectedAccountIds,
                    createdBefore: createdBefore,
                    customMetadataHas: customMetadataHas,
                    deviceIds: deviceIds,
                    deviceType: deviceType,
                    deviceTypes: deviceTypes,
                    excludeIf: excludeIf,
                    includeIf: includeIf,
                    limit: limit,
                    manufacturer: manufacturer,
                    userIdentifierKey: userIdentifierKey
                )
            );
        }

        public async Task<List<Device>> ListAsync(ListRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            return (await _seam.PostAsync<ListResponse>("/devices/list", requestOptions))
                .Data
                .Devices;
        }

        public async Task<List<Device>> ListAsync(
            string? connectWebviewId = default,
            string? connectedAccountId = default,
            List<string>? connectedAccountIds = default,
            string? createdBefore = default,
            object? customMetadataHas = default,
            List<string>? deviceIds = default,
            string? deviceType = default,
            List<ListRequest.DeviceTypesEnum>? deviceTypes = default,
            List<ListRequest.ExcludeIfEnum>? excludeIf = default,
            List<ListRequest.IncludeIfEnum>? includeIf = default,
            float? limit = default,
            ListRequest.ManufacturerEnum? manufacturer = default,
            string? userIdentifierKey = default
        )
        {
            return (
                await ListAsync(
                    new ListRequest(
                        connectWebviewId: connectWebviewId,
                        connectedAccountId: connectedAccountId,
                        connectedAccountIds: connectedAccountIds,
                        createdBefore: createdBefore,
                        customMetadataHas: customMetadataHas,
                        deviceIds: deviceIds,
                        deviceType: deviceType,
                        deviceTypes: deviceTypes,
                        excludeIf: excludeIf,
                        includeIf: includeIf,
                        limit: limit,
                        manufacturer: manufacturer,
                        userIdentifierKey: userIdentifierKey
                    )
                )
            );
        }

        [DataContract(Name = "listDeviceProvidersRequest_request")]
        public class ListDeviceProvidersRequest
        {
            [JsonConstructorAttribute]
            protected ListDeviceProvidersRequest() { }

            public ListDeviceProvidersRequest(
                ListDeviceProvidersRequest.ProviderCategoryEnum? providerCategory = default
            )
            {
                ProviderCategory = providerCategory;
            }

            [JsonConverter(typeof(SafeStringEnumConverter))]
            public enum ProviderCategoryEnum
            {
                [EnumMember(Value = "unrecognized")]
                Unrecognized = 0,

                [EnumMember(Value = "stable")]
                Stable = 1,

                [EnumMember(Value = "consumer_smartlocks")]
                ConsumerSmartlocks = 2,

                [EnumMember(Value = "thermostats")]
                Thermostats = 3,

                [EnumMember(Value = "noise_sensors")]
                NoiseSensors = 4,

                [EnumMember(Value = "access_control_systems")]
                AccessControlSystems = 5,
            }

            [DataMember(Name = "provider_category", IsRequired = false, EmitDefaultValue = false)]
            public ListDeviceProvidersRequest.ProviderCategoryEnum? ProviderCategory { get; set; }

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

        [DataContract(Name = "listDeviceProvidersResponse_response")]
        public class ListDeviceProvidersResponse
        {
            [JsonConstructorAttribute]
            protected ListDeviceProvidersResponse() { }

            public ListDeviceProvidersResponse(List<DeviceProvider> deviceProviders = default)
            {
                DeviceProviders = deviceProviders;
            }

            [DataMember(Name = "device_providers", IsRequired = false, EmitDefaultValue = false)]
            public List<DeviceProvider> DeviceProviders { get; set; }

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

        public List<DeviceProvider> ListDeviceProviders(ListDeviceProvidersRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            return _seam
                .Post<ListDeviceProvidersResponse>("/devices/list_device_providers", requestOptions)
                .Data.DeviceProviders;
        }

        public List<DeviceProvider> ListDeviceProviders(
            ListDeviceProvidersRequest.ProviderCategoryEnum? providerCategory = default
        )
        {
            return ListDeviceProviders(
                new ListDeviceProvidersRequest(providerCategory: providerCategory)
            );
        }

        public async Task<List<DeviceProvider>> ListDeviceProvidersAsync(
            ListDeviceProvidersRequest request
        )
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            return (
                await _seam.PostAsync<ListDeviceProvidersResponse>(
                    "/devices/list_device_providers",
                    requestOptions
                )
            )
                .Data
                .DeviceProviders;
        }

        public async Task<List<DeviceProvider>> ListDeviceProvidersAsync(
            ListDeviceProvidersRequest.ProviderCategoryEnum? providerCategory = default
        )
        {
            return (
                await ListDeviceProvidersAsync(
                    new ListDeviceProvidersRequest(providerCategory: providerCategory)
                )
            );
        }

        [DataContract(Name = "updateRequest_request")]
        public class UpdateRequest
        {
            [JsonConstructorAttribute]
            protected UpdateRequest() { }

            public UpdateRequest(
                object? customMetadata = default,
                string deviceId = default,
                bool? isManaged = default,
                string? name = default,
                UpdateRequestProperties? properties = default
            )
            {
                CustomMetadata = customMetadata;
                DeviceId = deviceId;
                IsManaged = isManaged;
                Name = name;
                Properties = properties;
            }

            [DataMember(Name = "custom_metadata", IsRequired = false, EmitDefaultValue = false)]
            public object? CustomMetadata { get; set; }

            [DataMember(Name = "device_id", IsRequired = true, EmitDefaultValue = false)]
            public string DeviceId { get; set; }

            [DataMember(Name = "is_managed", IsRequired = false, EmitDefaultValue = false)]
            public bool? IsManaged { get; set; }

            [DataMember(Name = "name", IsRequired = false, EmitDefaultValue = false)]
            public string? Name { get; set; }

            [DataMember(Name = "properties", IsRequired = false, EmitDefaultValue = false)]
            public UpdateRequestProperties? Properties { get; set; }

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

        [DataContract(Name = "updateRequestProperties_model")]
        public class UpdateRequestProperties
        {
            [JsonConstructorAttribute]
            protected UpdateRequestProperties() { }

            public UpdateRequestProperties(string? name = default)
            {
                Name = name;
            }

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

        public void Update(UpdateRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            _seam.Post<object>("/devices/update", requestOptions);
        }

        public void Update(
            object? customMetadata = default,
            string deviceId = default,
            bool? isManaged = default,
            string? name = default,
            UpdateRequestProperties? properties = default
        )
        {
            Update(
                new UpdateRequest(
                    customMetadata: customMetadata,
                    deviceId: deviceId,
                    isManaged: isManaged,
                    name: name,
                    properties: properties
                )
            );
        }

        public async Task UpdateAsync(UpdateRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            await _seam.PostAsync<object>("/devices/update", requestOptions);
        }

        public async Task UpdateAsync(
            object? customMetadata = default,
            string deviceId = default,
            bool? isManaged = default,
            string? name = default,
            UpdateRequestProperties? properties = default
        )
        {
            await UpdateAsync(
                new UpdateRequest(
                    customMetadata: customMetadata,
                    deviceId: deviceId,
                    isManaged: isManaged,
                    name: name,
                    properties: properties
                )
            );
        }
    }
}

namespace Seam.Client
{
    public partial class SeamClient
    {
        public Api.Devices Devices => new(this);
    }

    public partial interface ISeamClient
    {
        public Api.Devices Devices { get; }
    }
}
