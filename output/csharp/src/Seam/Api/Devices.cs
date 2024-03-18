using System.Runtime.Serialization;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using JsonSubTypes;
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
                string? connectedAccountId = default,
                List<string>? connectedAccountIds = default,
                string? connectWebviewId = default,
                ListRequest.DeviceTypeEnum? deviceType = default,
                List<ListRequest.DeviceTypesEnum>? deviceTypes = default,
                ListRequest.ManufacturerEnum? manufacturer = default,
                List<string>? deviceIds = default,
                float? limit = default,
                string? createdBefore = default,
                string? userIdentifierKey = default,
                object? customMetadataHas = default
            )
            {
                ConnectedAccountId = connectedAccountId;
                ConnectedAccountIds = connectedAccountIds;
                ConnectWebviewId = connectWebviewId;
                DeviceType = deviceType;
                DeviceTypes = deviceTypes;
                Manufacturer = manufacturer;
                DeviceIds = deviceIds;
                Limit = limit;
                CreatedBefore = createdBefore;
                UserIdentifierKey = userIdentifierKey;
                CustomMetadataHas = customMetadataHas;
            }

            [JsonConverter(typeof(StringEnumConverter))]
            public enum DeviceTypeEnum
            {
                [EnumMember(Value = "akuvox_lock")]
                AkuvoxLock = 0,

                [EnumMember(Value = "august_lock")]
                AugustLock = 1,

                [EnumMember(Value = "brivo_access_point")]
                BrivoAccessPoint = 2,

                [EnumMember(Value = "butterflymx_panel")]
                ButterflymxPanel = 3,

                [EnumMember(Value = "avigilon_alta_entry")]
                AvigilonAltaEntry = 4,

                [EnumMember(Value = "doorking_lock")]
                DoorkingLock = 5,

                [EnumMember(Value = "genie_door")]
                GenieDoor = 6,

                [EnumMember(Value = "igloo_lock")]
                IglooLock = 7,

                [EnumMember(Value = "linear_lock")]
                LinearLock = 8,

                [EnumMember(Value = "lockly_lock")]
                LocklyLock = 9,

                [EnumMember(Value = "kwikset_lock")]
                KwiksetLock = 10,

                [EnumMember(Value = "nuki_lock")]
                NukiLock = 11,

                [EnumMember(Value = "salto_lock")]
                SaltoLock = 12,

                [EnumMember(Value = "schlage_lock")]
                SchlageLock = 13,

                [EnumMember(Value = "seam_relay")]
                SeamRelay = 14,

                [EnumMember(Value = "smartthings_lock")]
                SmartthingsLock = 15,

                [EnumMember(Value = "wyze_lock")]
                WyzeLock = 16,

                [EnumMember(Value = "yale_lock")]
                YaleLock = 17,

                [EnumMember(Value = "two_n_intercom")]
                TwoNIntercom = 18,

                [EnumMember(Value = "controlbyweb_device")]
                ControlbywebDevice = 19,

                [EnumMember(Value = "ttlock_lock")]
                TtlockLock = 20,

                [EnumMember(Value = "igloohome_lock")]
                IgloohomeLock = 21,

                [EnumMember(Value = "hubitat_lock")]
                HubitatLock = 22,

                [EnumMember(Value = "four_suites_door")]
                FourSuitesDoor = 23,

                [EnumMember(Value = "dormakaba_oracode_door")]
                DormakabaOracodeDoor = 24,

                [EnumMember(Value = "tedee_lock")]
                TedeeLock = 25,

                [EnumMember(Value = "noiseaware_activity_zone")]
                NoiseawareActivityZone = 26,

                [EnumMember(Value = "minut_sensor")]
                MinutSensor = 27,

                [EnumMember(Value = "ecobee_thermostat")]
                EcobeeThermostat = 28,

                [EnumMember(Value = "nest_thermostat")]
                NestThermostat = 29,

                [EnumMember(Value = "honeywell_resideo_thermostat")]
                HoneywellResideoThermostat = 30,

                [EnumMember(Value = "ios_phone")]
                IosPhone = 31,

                [EnumMember(Value = "android_phone")]
                AndroidPhone = 32
            }

            [JsonConverter(typeof(StringEnumConverter))]
            public enum DeviceTypesEnum
            {
                [EnumMember(Value = "akuvox_lock")]
                AkuvoxLock = 0,

                [EnumMember(Value = "august_lock")]
                AugustLock = 1,

                [EnumMember(Value = "brivo_access_point")]
                BrivoAccessPoint = 2,

                [EnumMember(Value = "butterflymx_panel")]
                ButterflymxPanel = 3,

                [EnumMember(Value = "avigilon_alta_entry")]
                AvigilonAltaEntry = 4,

                [EnumMember(Value = "doorking_lock")]
                DoorkingLock = 5,

                [EnumMember(Value = "genie_door")]
                GenieDoor = 6,

                [EnumMember(Value = "igloo_lock")]
                IglooLock = 7,

                [EnumMember(Value = "linear_lock")]
                LinearLock = 8,

                [EnumMember(Value = "lockly_lock")]
                LocklyLock = 9,

                [EnumMember(Value = "kwikset_lock")]
                KwiksetLock = 10,

                [EnumMember(Value = "nuki_lock")]
                NukiLock = 11,

                [EnumMember(Value = "salto_lock")]
                SaltoLock = 12,

                [EnumMember(Value = "schlage_lock")]
                SchlageLock = 13,

                [EnumMember(Value = "seam_relay")]
                SeamRelay = 14,

                [EnumMember(Value = "smartthings_lock")]
                SmartthingsLock = 15,

                [EnumMember(Value = "wyze_lock")]
                WyzeLock = 16,

                [EnumMember(Value = "yale_lock")]
                YaleLock = 17,

                [EnumMember(Value = "two_n_intercom")]
                TwoNIntercom = 18,

                [EnumMember(Value = "controlbyweb_device")]
                ControlbywebDevice = 19,

                [EnumMember(Value = "ttlock_lock")]
                TtlockLock = 20,

                [EnumMember(Value = "igloohome_lock")]
                IgloohomeLock = 21,

                [EnumMember(Value = "hubitat_lock")]
                HubitatLock = 22,

                [EnumMember(Value = "four_suites_door")]
                FourSuitesDoor = 23,

                [EnumMember(Value = "dormakaba_oracode_door")]
                DormakabaOracodeDoor = 24,

                [EnumMember(Value = "tedee_lock")]
                TedeeLock = 25,

                [EnumMember(Value = "noiseaware_activity_zone")]
                NoiseawareActivityZone = 26,

                [EnumMember(Value = "minut_sensor")]
                MinutSensor = 27,

                [EnumMember(Value = "ecobee_thermostat")]
                EcobeeThermostat = 28,

                [EnumMember(Value = "nest_thermostat")]
                NestThermostat = 29,

                [EnumMember(Value = "honeywell_resideo_thermostat")]
                HoneywellResideoThermostat = 30,

                [EnumMember(Value = "ios_phone")]
                IosPhone = 31,

                [EnumMember(Value = "android_phone")]
                AndroidPhone = 32
            }

            [JsonConverter(typeof(StringEnumConverter))]
            public enum ManufacturerEnum
            {
                [EnumMember(Value = "akuvox")]
                Akuvox = 0,

                [EnumMember(Value = "august")]
                August = 1,

                [EnumMember(Value = "avigilon_alta")]
                AvigilonAlta = 2,

                [EnumMember(Value = "brivo")]
                Brivo = 3,

                [EnumMember(Value = "butterflymx")]
                Butterflymx = 4,

                [EnumMember(Value = "doorking")]
                Doorking = 5,

                [EnumMember(Value = "four_suites")]
                FourSuites = 6,

                [EnumMember(Value = "genie")]
                Genie = 7,

                [EnumMember(Value = "igloo")]
                Igloo = 8,

                [EnumMember(Value = "keywe")]
                Keywe = 9,

                [EnumMember(Value = "kwikset")]
                Kwikset = 10,

                [EnumMember(Value = "linear")]
                Linear = 11,

                [EnumMember(Value = "lockly")]
                Lockly = 12,

                [EnumMember(Value = "nuki")]
                Nuki = 13,

                [EnumMember(Value = "philia")]
                Philia = 14,

                [EnumMember(Value = "salto")]
                Salto = 15,

                [EnumMember(Value = "samsung")]
                Samsung = 16,

                [EnumMember(Value = "schlage")]
                Schlage = 17,

                [EnumMember(Value = "seam")]
                Seam = 18,

                [EnumMember(Value = "unknown")]
                Unknown = 19,

                [EnumMember(Value = "wyze")]
                Wyze = 20,

                [EnumMember(Value = "yale")]
                Yale = 21,

                [EnumMember(Value = "minut")]
                Minut = 22,

                [EnumMember(Value = "two_n")]
                TwoN = 23,

                [EnumMember(Value = "ttlock")]
                Ttlock = 24,

                [EnumMember(Value = "nest")]
                Nest = 25,

                [EnumMember(Value = "igloohome")]
                Igloohome = 26,

                [EnumMember(Value = "ecobee")]
                Ecobee = 27,

                [EnumMember(Value = "hubitat")]
                Hubitat = 28,

                [EnumMember(Value = "controlbyweb")]
                Controlbyweb = 29,

                [EnumMember(Value = "smartthings")]
                Smartthings = 30,

                [EnumMember(Value = "dormakaba_oracode")]
                DormakabaOracode = 31,

                [EnumMember(Value = "tedee")]
                Tedee = 32,

                [EnumMember(Value = "honeywell_resideo")]
                HoneywellResideo = 33
            }

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

            [DataMember(Name = "connect_webview_id", IsRequired = false, EmitDefaultValue = false)]
            public string? ConnectWebviewId { get; set; }

            [DataMember(Name = "device_type", IsRequired = false, EmitDefaultValue = false)]
            public ListRequest.DeviceTypeEnum? DeviceType { get; set; }

            [DataMember(Name = "device_types", IsRequired = false, EmitDefaultValue = false)]
            public List<ListRequest.DeviceTypesEnum>? DeviceTypes { get; set; }

            [DataMember(Name = "manufacturer", IsRequired = false, EmitDefaultValue = false)]
            public ListRequest.ManufacturerEnum? Manufacturer { get; set; }

            [DataMember(Name = "device_ids", IsRequired = false, EmitDefaultValue = false)]
            public List<string>? DeviceIds { get; set; }

            [DataMember(Name = "limit", IsRequired = false, EmitDefaultValue = false)]
            public float? Limit { get; set; }

            [DataMember(Name = "created_before", IsRequired = false, EmitDefaultValue = false)]
            public string? CreatedBefore { get; set; }

            [DataMember(Name = "user_identifier_key", IsRequired = false, EmitDefaultValue = false)]
            public string? UserIdentifierKey { get; set; }

            [DataMember(Name = "custom_metadata_has", IsRequired = false, EmitDefaultValue = false)]
            public object? CustomMetadataHas { get; set; }

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
            string? connectedAccountId = default,
            List<string>? connectedAccountIds = default,
            string? connectWebviewId = default,
            ListRequest.DeviceTypeEnum? deviceType = default,
            List<ListRequest.DeviceTypesEnum>? deviceTypes = default,
            ListRequest.ManufacturerEnum? manufacturer = default,
            List<string>? deviceIds = default,
            float? limit = default,
            string? createdBefore = default,
            string? userIdentifierKey = default,
            object? customMetadataHas = default
        )
        {
            return List(
                new ListRequest(
                    connectedAccountId: connectedAccountId,
                    connectedAccountIds: connectedAccountIds,
                    connectWebviewId: connectWebviewId,
                    deviceType: deviceType,
                    deviceTypes: deviceTypes,
                    manufacturer: manufacturer,
                    deviceIds: deviceIds,
                    limit: limit,
                    createdBefore: createdBefore,
                    userIdentifierKey: userIdentifierKey,
                    customMetadataHas: customMetadataHas
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
            string? connectedAccountId = default,
            List<string>? connectedAccountIds = default,
            string? connectWebviewId = default,
            ListRequest.DeviceTypeEnum? deviceType = default,
            List<ListRequest.DeviceTypesEnum>? deviceTypes = default,
            ListRequest.ManufacturerEnum? manufacturer = default,
            List<string>? deviceIds = default,
            float? limit = default,
            string? createdBefore = default,
            string? userIdentifierKey = default,
            object? customMetadataHas = default
        )
        {
            return (
                await ListAsync(
                    new ListRequest(
                        connectedAccountId: connectedAccountId,
                        connectedAccountIds: connectedAccountIds,
                        connectWebviewId: connectWebviewId,
                        deviceType: deviceType,
                        deviceTypes: deviceTypes,
                        manufacturer: manufacturer,
                        deviceIds: deviceIds,
                        limit: limit,
                        createdBefore: createdBefore,
                        userIdentifierKey: userIdentifierKey,
                        customMetadataHas: customMetadataHas
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

            [JsonConverter(typeof(StringEnumConverter))]
            public enum ProviderCategoryEnum
            {
                [EnumMember(Value = "stable")]
                Stable = 0,

                [EnumMember(Value = "consumer_smartlocks")]
                ConsumerSmartlocks = 1,

                [EnumMember(Value = "thermostats")]
                Thermostats = 2,

                [EnumMember(Value = "noise_sensors")]
                NoiseSensors = 3,

                [EnumMember(Value = "access_control_systems")]
                AccessControlSystems = 4
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
                string deviceId = default,
                UpdateRequestProperties? properties = default,
                string? name = default,
                bool? isManaged = default,
                object? customMetadata = default
            )
            {
                DeviceId = deviceId;
                Properties = properties;
                Name = name;
                IsManaged = isManaged;
                CustomMetadata = customMetadata;
            }

            [DataMember(Name = "device_id", IsRequired = true, EmitDefaultValue = false)]
            public string DeviceId { get; set; }

            [DataMember(Name = "properties", IsRequired = false, EmitDefaultValue = false)]
            public UpdateRequestProperties? Properties { get; set; }

            [DataMember(Name = "name", IsRequired = false, EmitDefaultValue = false)]
            public string? Name { get; set; }

            [DataMember(Name = "is_managed", IsRequired = false, EmitDefaultValue = false)]
            public bool? IsManaged { get; set; }

            [DataMember(Name = "custom_metadata", IsRequired = false, EmitDefaultValue = false)]
            public object? CustomMetadata { get; set; }

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
            string deviceId = default,
            UpdateRequestProperties? properties = default,
            string? name = default,
            bool? isManaged = default,
            object? customMetadata = default
        )
        {
            Update(
                new UpdateRequest(
                    deviceId: deviceId,
                    properties: properties,
                    name: name,
                    isManaged: isManaged,
                    customMetadata: customMetadata
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
            string deviceId = default,
            UpdateRequestProperties? properties = default,
            string? name = default,
            bool? isManaged = default,
            object? customMetadata = default
        )
        {
            await UpdateAsync(
                new UpdateRequest(
                    deviceId: deviceId,
                    properties: properties,
                    name: name,
                    isManaged: isManaged,
                    customMetadata: customMetadata
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
