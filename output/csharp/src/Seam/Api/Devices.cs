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
                string? customerKey = default,
                List<string>? deviceIds = default,
                string? deviceType = default,
                List<ListRequest.DeviceTypesEnum>? deviceTypes = default,
                List<ListRequest.ExcludeIfEnum>? excludeIf = default,
                List<ListRequest.IncludeIfEnum>? includeIf = default,
                float? limit = default,
                ListRequest.ManufacturerEnum? manufacturer = default,
                string? pageCursor = default,
                string? search = default,
                string? spaceId = default,
                string? unstableLocationId = default,
                string? userIdentifierKey = default
            )
            {
                ConnectWebviewId = connectWebviewId;
                ConnectedAccountId = connectedAccountId;
                ConnectedAccountIds = connectedAccountIds;
                CreatedBefore = createdBefore;
                CustomMetadataHas = customMetadataHas;
                CustomerKey = customerKey;
                DeviceIds = deviceIds;
                DeviceType = deviceType;
                DeviceTypes = deviceTypes;
                ExcludeIf = excludeIf;
                IncludeIf = includeIf;
                Limit = limit;
                Manufacturer = manufacturer;
                PageCursor = pageCursor;
                Search = search;
                SpaceId = spaceId;
                UnstableLocationId = unstableLocationId;
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

                [EnumMember(Value = "ultraloq_lock")]
                UltraloqLock = 28,

                [EnumMember(Value = "korelock_lock")]
                KorelockLock = 29,

                [EnumMember(Value = "keynest_key")]
                KeynestKey = 30,

                [EnumMember(Value = "noiseaware_activity_zone")]
                NoiseawareActivityZone = 31,

                [EnumMember(Value = "minut_sensor")]
                MinutSensor = 32,

                [EnumMember(Value = "ecobee_thermostat")]
                EcobeeThermostat = 33,

                [EnumMember(Value = "nest_thermostat")]
                NestThermostat = 34,

                [EnumMember(Value = "honeywell_resideo_thermostat")]
                HoneywellResideoThermostat = 35,

                [EnumMember(Value = "tado_thermostat")]
                TadoThermostat = 36,

                [EnumMember(Value = "sensi_thermostat")]
                SensiThermostat = 37,

                [EnumMember(Value = "smartthings_thermostat")]
                SmartthingsThermostat = 38,

                [EnumMember(Value = "ios_phone")]
                IosPhone = 39,

                [EnumMember(Value = "android_phone")]
                AndroidPhone = 40,
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

                [EnumMember(Value = "can_unlock_with_code")]
                CanUnlockWithCode = 12,

                [EnumMember(Value = "can_run_thermostat_programs")]
                CanRunThermostatPrograms = 13,

                [EnumMember(Value = "can_program_thermostat_programs_as_weekday_weekend")]
                CanProgramThermostatProgramsAsWeekdayWeekend = 14,

                [EnumMember(Value = "can_program_thermostat_programs_as_different_each_day")]
                CanProgramThermostatProgramsAsDifferentEachDay = 15,

                [EnumMember(Value = "can_program_thermostat_programs_as_same_each_day")]
                CanProgramThermostatProgramsAsSameEachDay = 16,

                [EnumMember(Value = "can_simulate_hub_connection")]
                CanSimulateHubConnection = 17,

                [EnumMember(Value = "can_simulate_hub_disconnection")]
                CanSimulateHubDisconnection = 18,

                [EnumMember(Value = "can_simulate_paid_subscription")]
                CanSimulatePaidSubscription = 19,
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

                [EnumMember(Value = "can_unlock_with_code")]
                CanUnlockWithCode = 12,

                [EnumMember(Value = "can_run_thermostat_programs")]
                CanRunThermostatPrograms = 13,

                [EnumMember(Value = "can_program_thermostat_programs_as_weekday_weekend")]
                CanProgramThermostatProgramsAsWeekdayWeekend = 14,

                [EnumMember(Value = "can_program_thermostat_programs_as_different_each_day")]
                CanProgramThermostatProgramsAsDifferentEachDay = 15,

                [EnumMember(Value = "can_program_thermostat_programs_as_same_each_day")]
                CanProgramThermostatProgramsAsSameEachDay = 16,

                [EnumMember(Value = "can_simulate_hub_connection")]
                CanSimulateHubConnection = 17,

                [EnumMember(Value = "can_simulate_hub_disconnection")]
                CanSimulateHubDisconnection = 18,

                [EnumMember(Value = "can_simulate_paid_subscription")]
                CanSimulatePaidSubscription = 19,
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

                [EnumMember(Value = "two_n")]
                TwoN = 23,

                [EnumMember(Value = "ttlock")]
                Ttlock = 24,

                [EnumMember(Value = "igloohome")]
                Igloohome = 25,

                [EnumMember(Value = "hubitat")]
                Hubitat = 26,

                [EnumMember(Value = "controlbyweb")]
                Controlbyweb = 27,

                [EnumMember(Value = "dormakaba_oracode")]
                DormakabaOracode = 28,

                [EnumMember(Value = "tedee")]
                Tedee = 29,

                [EnumMember(Value = "korelock")]
                Korelock = 30,

                [EnumMember(Value = "akiles")]
                Akiles = 31,

                [EnumMember(Value = "ecobee")]
                Ecobee = 32,

                [EnumMember(Value = "honeywell_resideo")]
                HoneywellResideo = 33,

                [EnumMember(Value = "keynest")]
                Keynest = 34,

                [EnumMember(Value = "korelock")]
                Korelock = 35,

                [EnumMember(Value = "kwikset2")]
                Kwikset2 = 36,

                [EnumMember(Value = "minut")]
                Minut = 37,

                [EnumMember(Value = "nest")]
                Nest = 38,

                [EnumMember(Value = "noiseaware")]
                Noiseaware = 39,

                [EnumMember(Value = "sensi")]
                Sensi = 40,

                [EnumMember(Value = "smartthings")]
                Smartthings = 41,

                [EnumMember(Value = "tado")]
                Tado = 42,

                [EnumMember(Value = "ultraloq")]
                Ultraloq = 43,
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

            [DataMember(Name = "customer_key", IsRequired = false, EmitDefaultValue = false)]
            public string? CustomerKey { get; set; }

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

            [DataMember(Name = "page_cursor", IsRequired = false, EmitDefaultValue = false)]
            public string? PageCursor { get; set; }

            [DataMember(Name = "search", IsRequired = false, EmitDefaultValue = false)]
            public string? Search { get; set; }

            [DataMember(Name = "space_id", IsRequired = false, EmitDefaultValue = false)]
            public string? SpaceId { get; set; }

            [DataMember(
                Name = "unstable_location_id",
                IsRequired = false,
                EmitDefaultValue = false
            )]
            public string? UnstableLocationId { get; set; }

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
            string? customerKey = default,
            List<string>? deviceIds = default,
            string? deviceType = default,
            List<ListRequest.DeviceTypesEnum>? deviceTypes = default,
            List<ListRequest.ExcludeIfEnum>? excludeIf = default,
            List<ListRequest.IncludeIfEnum>? includeIf = default,
            float? limit = default,
            ListRequest.ManufacturerEnum? manufacturer = default,
            string? pageCursor = default,
            string? search = default,
            string? spaceId = default,
            string? unstableLocationId = default,
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
                    customerKey: customerKey,
                    deviceIds: deviceIds,
                    deviceType: deviceType,
                    deviceTypes: deviceTypes,
                    excludeIf: excludeIf,
                    includeIf: includeIf,
                    limit: limit,
                    manufacturer: manufacturer,
                    pageCursor: pageCursor,
                    search: search,
                    spaceId: spaceId,
                    unstableLocationId: unstableLocationId,
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
            string? customerKey = default,
            List<string>? deviceIds = default,
            string? deviceType = default,
            List<ListRequest.DeviceTypesEnum>? deviceTypes = default,
            List<ListRequest.ExcludeIfEnum>? excludeIf = default,
            List<ListRequest.IncludeIfEnum>? includeIf = default,
            float? limit = default,
            ListRequest.ManufacturerEnum? manufacturer = default,
            string? pageCursor = default,
            string? search = default,
            string? spaceId = default,
            string? unstableLocationId = default,
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
                        customerKey: customerKey,
                        deviceIds: deviceIds,
                        deviceType: deviceType,
                        deviceTypes: deviceTypes,
                        excludeIf: excludeIf,
                        includeIf: includeIf,
                        limit: limit,
                        manufacturer: manufacturer,
                        pageCursor: pageCursor,
                        search: search,
                        spaceId: spaceId,
                        unstableLocationId: unstableLocationId,
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

                [EnumMember(Value = "beta")]
                Beta = 3,

                [EnumMember(Value = "thermostats")]
                Thermostats = 4,

                [EnumMember(Value = "noise_sensors")]
                NoiseSensors = 5,

                [EnumMember(Value = "access_control_systems")]
                AccessControlSystems = 6,
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

        [DataContract(Name = "reportProviderMetadataRequest_request")]
        public class ReportProviderMetadataRequest
        {
            [JsonConstructorAttribute]
            protected ReportProviderMetadataRequest() { }

            public ReportProviderMetadataRequest(
                List<ReportProviderMetadataRequestDevices> devices = default
            )
            {
                Devices = devices;
            }

            [DataMember(Name = "devices", IsRequired = true, EmitDefaultValue = false)]
            public List<ReportProviderMetadataRequestDevices> Devices { get; set; }

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

        [DataContract(Name = "reportProviderMetadataRequestDevices_model")]
        public class ReportProviderMetadataRequestDevices
        {
            [JsonConstructorAttribute]
            protected ReportProviderMetadataRequestDevices() { }

            public ReportProviderMetadataRequestDevices(
                string deviceId = default,
                ReportProviderMetadataRequestDevicesUltraloqMetadata? ultraloqMetadata = default
            )
            {
                DeviceId = deviceId;
                UltraloqMetadata = ultraloqMetadata;
            }

            [DataMember(Name = "device_id", IsRequired = true, EmitDefaultValue = false)]
            public string DeviceId { get; set; }

            [DataMember(Name = "ultraloq_metadata", IsRequired = false, EmitDefaultValue = false)]
            public ReportProviderMetadataRequestDevicesUltraloqMetadata? UltraloqMetadata { get; set; }

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

        [DataContract(Name = "reportProviderMetadataRequestDevicesUltraloqMetadata_model")]
        public class ReportProviderMetadataRequestDevicesUltraloqMetadata
        {
            [JsonConstructorAttribute]
            protected ReportProviderMetadataRequestDevicesUltraloqMetadata() { }

            public ReportProviderMetadataRequestDevicesUltraloqMetadata(
                ReportProviderMetadataRequestDevicesUltraloqMetadata.TimeZoneEnum timeZone = default
            )
            {
                TimeZone = timeZone;
            }

            [JsonConverter(typeof(SafeStringEnumConverter))]
            public enum TimeZoneEnum
            {
                [EnumMember(Value = "unrecognized")]
                Unrecognized = 0,

                [EnumMember(Value = "Africa/Abidjan")]
                AfricaAbidjan = 1,

                [EnumMember(Value = "Africa/Accra")]
                AfricaAccra = 2,

                [EnumMember(Value = "Africa/Addis_Ababa")]
                AfricaAddisAbaba = 3,

                [EnumMember(Value = "Africa/Algiers")]
                AfricaAlgiers = 4,

                [EnumMember(Value = "Africa/Asmera")]
                AfricaAsmera = 5,

                [EnumMember(Value = "Africa/Bamako")]
                AfricaBamako = 6,

                [EnumMember(Value = "Africa/Bangui")]
                AfricaBangui = 7,

                [EnumMember(Value = "Africa/Banjul")]
                AfricaBanjul = 8,

                [EnumMember(Value = "Africa/Bissau")]
                AfricaBissau = 9,

                [EnumMember(Value = "Africa/Blantyre")]
                AfricaBlantyre = 10,

                [EnumMember(Value = "Africa/Brazzaville")]
                AfricaBrazzaville = 11,

                [EnumMember(Value = "Africa/Bujumbura")]
                AfricaBujumbura = 12,

                [EnumMember(Value = "Africa/Cairo")]
                AfricaCairo = 13,

                [EnumMember(Value = "Africa/Casablanca")]
                AfricaCasablanca = 14,

                [EnumMember(Value = "Africa/Ceuta")]
                AfricaCeuta = 15,

                [EnumMember(Value = "Africa/Conakry")]
                AfricaConakry = 16,

                [EnumMember(Value = "Africa/Dakar")]
                AfricaDakar = 17,

                [EnumMember(Value = "Africa/Dar_es_Salaam")]
                AfricaDarEsSalaam = 18,

                [EnumMember(Value = "Africa/Djibouti")]
                AfricaDjibouti = 19,

                [EnumMember(Value = "Africa/Douala")]
                AfricaDouala = 20,

                [EnumMember(Value = "Africa/El_Aaiun")]
                AfricaElAaiun = 21,

                [EnumMember(Value = "Africa/Freetown")]
                AfricaFreetown = 22,

                [EnumMember(Value = "Africa/Gaborone")]
                AfricaGaborone = 23,

                [EnumMember(Value = "Africa/Harare")]
                AfricaHarare = 24,

                [EnumMember(Value = "Africa/Johannesburg")]
                AfricaJohannesburg = 25,

                [EnumMember(Value = "Africa/Juba")]
                AfricaJuba = 26,

                [EnumMember(Value = "Africa/Kampala")]
                AfricaKampala = 27,

                [EnumMember(Value = "Africa/Khartoum")]
                AfricaKhartoum = 28,

                [EnumMember(Value = "Africa/Kigali")]
                AfricaKigali = 29,

                [EnumMember(Value = "Africa/Kinshasa")]
                AfricaKinshasa = 30,

                [EnumMember(Value = "Africa/Lagos")]
                AfricaLagos = 31,

                [EnumMember(Value = "Africa/Libreville")]
                AfricaLibreville = 32,

                [EnumMember(Value = "Africa/Lome")]
                AfricaLome = 33,

                [EnumMember(Value = "Africa/Luanda")]
                AfricaLuanda = 34,

                [EnumMember(Value = "Africa/Lubumbashi")]
                AfricaLubumbashi = 35,

                [EnumMember(Value = "Africa/Lusaka")]
                AfricaLusaka = 36,

                [EnumMember(Value = "Africa/Malabo")]
                AfricaMalabo = 37,

                [EnumMember(Value = "Africa/Maputo")]
                AfricaMaputo = 38,

                [EnumMember(Value = "Africa/Maseru")]
                AfricaMaseru = 39,

                [EnumMember(Value = "Africa/Mbabane")]
                AfricaMbabane = 40,

                [EnumMember(Value = "Africa/Mogadishu")]
                AfricaMogadishu = 41,

                [EnumMember(Value = "Africa/Monrovia")]
                AfricaMonrovia = 42,

                [EnumMember(Value = "Africa/Nairobi")]
                AfricaNairobi = 43,

                [EnumMember(Value = "Africa/Ndjamena")]
                AfricaNdjamena = 44,

                [EnumMember(Value = "Africa/Niamey")]
                AfricaNiamey = 45,

                [EnumMember(Value = "Africa/Nouakchott")]
                AfricaNouakchott = 46,

                [EnumMember(Value = "Africa/Ouagadougou")]
                AfricaOuagadougou = 47,

                [EnumMember(Value = "Africa/Porto-Novo")]
                AfricaPortoNovo = 48,

                [EnumMember(Value = "Africa/Sao_Tome")]
                AfricaSaoTome = 49,

                [EnumMember(Value = "Africa/Tripoli")]
                AfricaTripoli = 50,

                [EnumMember(Value = "Africa/Tunis")]
                AfricaTunis = 51,

                [EnumMember(Value = "Africa/Windhoek")]
                AfricaWindhoek = 52,

                [EnumMember(Value = "America/Adak")]
                AmericaAdak = 53,

                [EnumMember(Value = "America/Anchorage")]
                AmericaAnchorage = 54,

                [EnumMember(Value = "America/Anguilla")]
                AmericaAnguilla = 55,

                [EnumMember(Value = "America/Antigua")]
                AmericaAntigua = 56,

                [EnumMember(Value = "America/Araguaina")]
                AmericaAraguaina = 57,

                [EnumMember(Value = "America/Argentina/La_Rioja")]
                AmericaArgentinaLaRioja = 58,

                [EnumMember(Value = "America/Argentina/Rio_Gallegos")]
                AmericaArgentinaRioGallegos = 59,

                [EnumMember(Value = "America/Argentina/Salta")]
                AmericaArgentinaSalta = 60,

                [EnumMember(Value = "America/Argentina/San_Juan")]
                AmericaArgentinaSanJuan = 61,

                [EnumMember(Value = "America/Argentina/San_Luis")]
                AmericaArgentinaSanLuis = 62,

                [EnumMember(Value = "America/Argentina/Tucuman")]
                AmericaArgentinaTucuman = 63,

                [EnumMember(Value = "America/Argentina/Ushuaia")]
                AmericaArgentinaUshuaia = 64,

                [EnumMember(Value = "America/Aruba")]
                AmericaAruba = 65,

                [EnumMember(Value = "America/Asuncion")]
                AmericaAsuncion = 66,

                [EnumMember(Value = "America/Bahia")]
                AmericaBahia = 67,

                [EnumMember(Value = "America/Bahia_Banderas")]
                AmericaBahiaBanderas = 68,

                [EnumMember(Value = "America/Barbados")]
                AmericaBarbados = 69,

                [EnumMember(Value = "America/Belem")]
                AmericaBelem = 70,

                [EnumMember(Value = "America/Belize")]
                AmericaBelize = 71,

                [EnumMember(Value = "America/Blanc-Sablon")]
                AmericaBlancSablon = 72,

                [EnumMember(Value = "America/Boa_Vista")]
                AmericaBoaVista = 73,

                [EnumMember(Value = "America/Bogota")]
                AmericaBogota = 74,

                [EnumMember(Value = "America/Boise")]
                AmericaBoise = 75,

                [EnumMember(Value = "America/Buenos_Aires")]
                AmericaBuenosAires = 76,

                [EnumMember(Value = "America/Cambridge_Bay")]
                AmericaCambridgeBay = 77,

                [EnumMember(Value = "America/Campo_Grande")]
                AmericaCampoGrande = 78,

                [EnumMember(Value = "America/Cancun")]
                AmericaCancun = 79,

                [EnumMember(Value = "America/Caracas")]
                AmericaCaracas = 80,

                [EnumMember(Value = "America/Catamarca")]
                AmericaCatamarca = 81,

                [EnumMember(Value = "America/Cayenne")]
                AmericaCayenne = 82,

                [EnumMember(Value = "America/Cayman")]
                AmericaCayman = 83,

                [EnumMember(Value = "America/Chicago")]
                AmericaChicago = 84,

                [EnumMember(Value = "America/Chihuahua")]
                AmericaChihuahua = 85,

                [EnumMember(Value = "America/Ciudad_Juarez")]
                AmericaCiudadJuarez = 86,

                [EnumMember(Value = "America/Coral_Harbour")]
                AmericaCoralHarbour = 87,

                [EnumMember(Value = "America/Cordoba")]
                AmericaCordoba = 88,

                [EnumMember(Value = "America/Costa_Rica")]
                AmericaCostaRica = 89,

                [EnumMember(Value = "America/Creston")]
                AmericaCreston = 90,

                [EnumMember(Value = "America/Cuiaba")]
                AmericaCuiaba = 91,

                [EnumMember(Value = "America/Curacao")]
                AmericaCuracao = 92,

                [EnumMember(Value = "America/Danmarkshavn")]
                AmericaDanmarkshavn = 93,

                [EnumMember(Value = "America/Dawson")]
                AmericaDawson = 94,

                [EnumMember(Value = "America/Dawson_Creek")]
                AmericaDawsonCreek = 95,

                [EnumMember(Value = "America/Denver")]
                AmericaDenver = 96,

                [EnumMember(Value = "America/Detroit")]
                AmericaDetroit = 97,

                [EnumMember(Value = "America/Dominica")]
                AmericaDominica = 98,

                [EnumMember(Value = "America/Edmonton")]
                AmericaEdmonton = 99,

                [EnumMember(Value = "America/Eirunepe")]
                AmericaEirunepe = 100,

                [EnumMember(Value = "America/El_Salvador")]
                AmericaElSalvador = 101,

                [EnumMember(Value = "America/Fort_Nelson")]
                AmericaFortNelson = 102,

                [EnumMember(Value = "America/Fortaleza")]
                AmericaFortaleza = 103,

                [EnumMember(Value = "America/Glace_Bay")]
                AmericaGlaceBay = 104,

                [EnumMember(Value = "America/Godthab")]
                AmericaGodthab = 105,

                [EnumMember(Value = "America/Goose_Bay")]
                AmericaGooseBay = 106,

                [EnumMember(Value = "America/Grand_Turk")]
                AmericaGrandTurk = 107,

                [EnumMember(Value = "America/Grenada")]
                AmericaGrenada = 108,

                [EnumMember(Value = "America/Guadeloupe")]
                AmericaGuadeloupe = 109,

                [EnumMember(Value = "America/Guatemala")]
                AmericaGuatemala = 110,

                [EnumMember(Value = "America/Guayaquil")]
                AmericaGuayaquil = 111,

                [EnumMember(Value = "America/Guyana")]
                AmericaGuyana = 112,

                [EnumMember(Value = "America/Halifax")]
                AmericaHalifax = 113,

                [EnumMember(Value = "America/Havana")]
                AmericaHavana = 114,

                [EnumMember(Value = "America/Hermosillo")]
                AmericaHermosillo = 115,

                [EnumMember(Value = "America/Indiana/Knox")]
                AmericaIndianaKnox = 116,

                [EnumMember(Value = "America/Indiana/Marengo")]
                AmericaIndianaMarengo = 117,

                [EnumMember(Value = "America/Indiana/Petersburg")]
                AmericaIndianaPetersburg = 118,

                [EnumMember(Value = "America/Indiana/Tell_City")]
                AmericaIndianaTellCity = 119,

                [EnumMember(Value = "America/Indiana/Vevay")]
                AmericaIndianaVevay = 120,

                [EnumMember(Value = "America/Indiana/Vincennes")]
                AmericaIndianaVincennes = 121,

                [EnumMember(Value = "America/Indiana/Winamac")]
                AmericaIndianaWinamac = 122,

                [EnumMember(Value = "America/Indianapolis")]
                AmericaIndianapolis = 123,

                [EnumMember(Value = "America/Inuvik")]
                AmericaInuvik = 124,

                [EnumMember(Value = "America/Iqaluit")]
                AmericaIqaluit = 125,

                [EnumMember(Value = "America/Jamaica")]
                AmericaJamaica = 126,

                [EnumMember(Value = "America/Jujuy")]
                AmericaJujuy = 127,

                [EnumMember(Value = "America/Juneau")]
                AmericaJuneau = 128,

                [EnumMember(Value = "America/Kentucky/Monticello")]
                AmericaKentuckyMonticello = 129,

                [EnumMember(Value = "America/Kralendijk")]
                AmericaKralendijk = 130,

                [EnumMember(Value = "America/La_Paz")]
                AmericaLaPaz = 131,

                [EnumMember(Value = "America/Lima")]
                AmericaLima = 132,

                [EnumMember(Value = "America/Los_Angeles")]
                AmericaLosAngeles = 133,

                [EnumMember(Value = "America/Louisville")]
                AmericaLouisville = 134,

                [EnumMember(Value = "America/Lower_Princes")]
                AmericaLowerPrinces = 135,

                [EnumMember(Value = "America/Maceio")]
                AmericaMaceio = 136,

                [EnumMember(Value = "America/Managua")]
                AmericaManagua = 137,

                [EnumMember(Value = "America/Manaus")]
                AmericaManaus = 138,

                [EnumMember(Value = "America/Marigot")]
                AmericaMarigot = 139,

                [EnumMember(Value = "America/Martinique")]
                AmericaMartinique = 140,

                [EnumMember(Value = "America/Matamoros")]
                AmericaMatamoros = 141,

                [EnumMember(Value = "America/Mazatlan")]
                AmericaMazatlan = 142,

                [EnumMember(Value = "America/Mendoza")]
                AmericaMendoza = 143,

                [EnumMember(Value = "America/Menominee")]
                AmericaMenominee = 144,

                [EnumMember(Value = "America/Merida")]
                AmericaMerida = 145,

                [EnumMember(Value = "America/Metlakatla")]
                AmericaMetlakatla = 146,

                [EnumMember(Value = "America/Mexico_City")]
                AmericaMexicoCity = 147,

                [EnumMember(Value = "America/Miquelon")]
                AmericaMiquelon = 148,

                [EnumMember(Value = "America/Moncton")]
                AmericaMoncton = 149,

                [EnumMember(Value = "America/Monterrey")]
                AmericaMonterrey = 150,

                [EnumMember(Value = "America/Montevideo")]
                AmericaMontevideo = 151,

                [EnumMember(Value = "America/Montreal")]
                AmericaMontreal = 152,

                [EnumMember(Value = "America/Montserrat")]
                AmericaMontserrat = 153,

                [EnumMember(Value = "America/Nassau")]
                AmericaNassau = 154,

                [EnumMember(Value = "America/New_York")]
                AmericaNewYork = 155,

                [EnumMember(Value = "America/Nipigon")]
                AmericaNipigon = 156,

                [EnumMember(Value = "America/Nome")]
                AmericaNome = 157,

                [EnumMember(Value = "America/Noronha")]
                AmericaNoronha = 158,

                [EnumMember(Value = "America/North_Dakota/Beulah")]
                AmericaNorthDakotaBeulah = 159,

                [EnumMember(Value = "America/North_Dakota/Center")]
                AmericaNorthDakotaCenter = 160,

                [EnumMember(Value = "America/North_Dakota/New_Salem")]
                AmericaNorthDakotaNewSalem = 161,

                [EnumMember(Value = "America/Ojinaga")]
                AmericaOjinaga = 162,

                [EnumMember(Value = "America/Panama")]
                AmericaPanama = 163,

                [EnumMember(Value = "America/Pangnirtung")]
                AmericaPangnirtung = 164,

                [EnumMember(Value = "America/Paramaribo")]
                AmericaParamaribo = 165,

                [EnumMember(Value = "America/Phoenix")]
                AmericaPhoenix = 166,

                [EnumMember(Value = "America/Port-au-Prince")]
                AmericaPortAuPrince = 167,

                [EnumMember(Value = "America/Port_of_Spain")]
                AmericaPortOfSpain = 168,

                [EnumMember(Value = "America/Porto_Velho")]
                AmericaPortoVelho = 169,

                [EnumMember(Value = "America/Puerto_Rico")]
                AmericaPuertoRico = 170,

                [EnumMember(Value = "America/Punta_Arenas")]
                AmericaPuntaArenas = 171,

                [EnumMember(Value = "America/Rainy_River")]
                AmericaRainyRiver = 172,

                [EnumMember(Value = "America/Rankin_Inlet")]
                AmericaRankinInlet = 173,

                [EnumMember(Value = "America/Recife")]
                AmericaRecife = 174,

                [EnumMember(Value = "America/Regina")]
                AmericaRegina = 175,

                [EnumMember(Value = "America/Resolute")]
                AmericaResolute = 176,

                [EnumMember(Value = "America/Rio_Branco")]
                AmericaRioBranco = 177,

                [EnumMember(Value = "America/Santa_Isabel")]
                AmericaSantaIsabel = 178,

                [EnumMember(Value = "America/Santarem")]
                AmericaSantarem = 179,

                [EnumMember(Value = "America/Santiago")]
                AmericaSantiago = 180,

                [EnumMember(Value = "America/Santo_Domingo")]
                AmericaSantoDomingo = 181,

                [EnumMember(Value = "America/Sao_Paulo")]
                AmericaSaoPaulo = 182,

                [EnumMember(Value = "America/Scoresbysund")]
                AmericaScoresbysund = 183,

                [EnumMember(Value = "America/Sitka")]
                AmericaSitka = 184,

                [EnumMember(Value = "America/St_Barthelemy")]
                AmericaStBarthelemy = 185,

                [EnumMember(Value = "America/St_Johns")]
                AmericaStJohns = 186,

                [EnumMember(Value = "America/St_Kitts")]
                AmericaStKitts = 187,

                [EnumMember(Value = "America/St_Lucia")]
                AmericaStLucia = 188,

                [EnumMember(Value = "America/St_Thomas")]
                AmericaStThomas = 189,

                [EnumMember(Value = "America/St_Vincent")]
                AmericaStVincent = 190,

                [EnumMember(Value = "America/Swift_Current")]
                AmericaSwiftCurrent = 191,

                [EnumMember(Value = "America/Tegucigalpa")]
                AmericaTegucigalpa = 192,

                [EnumMember(Value = "America/Thule")]
                AmericaThule = 193,

                [EnumMember(Value = "America/Thunder_Bay")]
                AmericaThunderBay = 194,

                [EnumMember(Value = "America/Tijuana")]
                AmericaTijuana = 195,

                [EnumMember(Value = "America/Toronto")]
                AmericaToronto = 196,

                [EnumMember(Value = "America/Tortola")]
                AmericaTortola = 197,

                [EnumMember(Value = "America/Vancouver")]
                AmericaVancouver = 198,

                [EnumMember(Value = "America/Whitehorse")]
                AmericaWhitehorse = 199,

                [EnumMember(Value = "America/Winnipeg")]
                AmericaWinnipeg = 200,

                [EnumMember(Value = "America/Yakutat")]
                AmericaYakutat = 201,

                [EnumMember(Value = "America/Yellowknife")]
                AmericaYellowknife = 202,

                [EnumMember(Value = "Antarctica/Casey")]
                AntarcticaCasey = 203,

                [EnumMember(Value = "Antarctica/Davis")]
                AntarcticaDavis = 204,

                [EnumMember(Value = "Antarctica/DumontDUrville")]
                AntarcticaDumontDUrville = 205,

                [EnumMember(Value = "Antarctica/Macquarie")]
                AntarcticaMacquarie = 206,

                [EnumMember(Value = "Antarctica/Mawson")]
                AntarcticaMawson = 207,

                [EnumMember(Value = "Antarctica/McMurdo")]
                AntarcticaMcMurdo = 208,

                [EnumMember(Value = "Antarctica/Palmer")]
                AntarcticaPalmer = 209,

                [EnumMember(Value = "Antarctica/Rothera")]
                AntarcticaRothera = 210,

                [EnumMember(Value = "Antarctica/Syowa")]
                AntarcticaSyowa = 211,

                [EnumMember(Value = "Antarctica/Troll")]
                AntarcticaTroll = 212,

                [EnumMember(Value = "Antarctica/Vostok")]
                AntarcticaVostok = 213,

                [EnumMember(Value = "Arctic/Longyearbyen")]
                ArcticLongyearbyen = 214,

                [EnumMember(Value = "Asia/Aden")]
                AsiaAden = 215,

                [EnumMember(Value = "Asia/Almaty")]
                AsiaAlmaty = 216,

                [EnumMember(Value = "Asia/Amman")]
                AsiaAmman = 217,

                [EnumMember(Value = "Asia/Anadyr")]
                AsiaAnadyr = 218,

                [EnumMember(Value = "Asia/Aqtau")]
                AsiaAqtau = 219,

                [EnumMember(Value = "Asia/Aqtobe")]
                AsiaAqtobe = 220,

                [EnumMember(Value = "Asia/Ashgabat")]
                AsiaAshgabat = 221,

                [EnumMember(Value = "Asia/Atyrau")]
                AsiaAtyrau = 222,

                [EnumMember(Value = "Asia/Baghdad")]
                AsiaBaghdad = 223,

                [EnumMember(Value = "Asia/Bahrain")]
                AsiaBahrain = 224,

                [EnumMember(Value = "Asia/Baku")]
                AsiaBaku = 225,

                [EnumMember(Value = "Asia/Bangkok")]
                AsiaBangkok = 226,

                [EnumMember(Value = "Asia/Barnaul")]
                AsiaBarnaul = 227,

                [EnumMember(Value = "Asia/Beirut")]
                AsiaBeirut = 228,

                [EnumMember(Value = "Asia/Bishkek")]
                AsiaBishkek = 229,

                [EnumMember(Value = "Asia/Brunei")]
                AsiaBrunei = 230,

                [EnumMember(Value = "Asia/Calcutta")]
                AsiaCalcutta = 231,

                [EnumMember(Value = "Asia/Chita")]
                AsiaChita = 232,

                [EnumMember(Value = "Asia/Choibalsan")]
                AsiaChoibalsan = 233,

                [EnumMember(Value = "Asia/Colombo")]
                AsiaColombo = 234,

                [EnumMember(Value = "Asia/Damascus")]
                AsiaDamascus = 235,

                [EnumMember(Value = "Asia/Dhaka")]
                AsiaDhaka = 236,

                [EnumMember(Value = "Asia/Dili")]
                AsiaDili = 237,

                [EnumMember(Value = "Asia/Dubai")]
                AsiaDubai = 238,

                [EnumMember(Value = "Asia/Dushanbe")]
                AsiaDushanbe = 239,

                [EnumMember(Value = "Asia/Famagusta")]
                AsiaFamagusta = 240,

                [EnumMember(Value = "Asia/Gaza")]
                AsiaGaza = 241,

                [EnumMember(Value = "Asia/Hebron")]
                AsiaHebron = 242,

                [EnumMember(Value = "Asia/Hong_Kong")]
                AsiaHongKong = 243,

                [EnumMember(Value = "Asia/Hovd")]
                AsiaHovd = 244,

                [EnumMember(Value = "Asia/Irkutsk")]
                AsiaIrkutsk = 245,

                [EnumMember(Value = "Asia/Jakarta")]
                AsiaJakarta = 246,

                [EnumMember(Value = "Asia/Jayapura")]
                AsiaJayapura = 247,

                [EnumMember(Value = "Asia/Jerusalem")]
                AsiaJerusalem = 248,

                [EnumMember(Value = "Asia/Kabul")]
                AsiaKabul = 249,

                [EnumMember(Value = "Asia/Kamchatka")]
                AsiaKamchatka = 250,

                [EnumMember(Value = "Asia/Karachi")]
                AsiaKarachi = 251,

                [EnumMember(Value = "Asia/Katmandu")]
                AsiaKatmandu = 252,

                [EnumMember(Value = "Asia/Khandyga")]
                AsiaKhandyga = 253,

                [EnumMember(Value = "Asia/Krasnoyarsk")]
                AsiaKrasnoyarsk = 254,

                [EnumMember(Value = "Asia/Kuala_Lumpur")]
                AsiaKualaLumpur = 255,

                [EnumMember(Value = "Asia/Kuching")]
                AsiaKuching = 256,

                [EnumMember(Value = "Asia/Kuwait")]
                AsiaKuwait = 257,

                [EnumMember(Value = "Asia/Macau")]
                AsiaMacau = 258,

                [EnumMember(Value = "Asia/Magadan")]
                AsiaMagadan = 259,

                [EnumMember(Value = "Asia/Makassar")]
                AsiaMakassar = 260,

                [EnumMember(Value = "Asia/Manila")]
                AsiaManila = 261,

                [EnumMember(Value = "Asia/Muscat")]
                AsiaMuscat = 262,

                [EnumMember(Value = "Asia/Nicosia")]
                AsiaNicosia = 263,

                [EnumMember(Value = "Asia/Novokuznetsk")]
                AsiaNovokuznetsk = 264,

                [EnumMember(Value = "Asia/Novosibirsk")]
                AsiaNovosibirsk = 265,

                [EnumMember(Value = "Asia/Omsk")]
                AsiaOmsk = 266,

                [EnumMember(Value = "Asia/Oral")]
                AsiaOral = 267,

                [EnumMember(Value = "Asia/Phnom_Penh")]
                AsiaPhnomPenh = 268,

                [EnumMember(Value = "Asia/Pontianak")]
                AsiaPontianak = 269,

                [EnumMember(Value = "Asia/Pyongyang")]
                AsiaPyongyang = 270,

                [EnumMember(Value = "Asia/Qatar")]
                AsiaQatar = 271,

                [EnumMember(Value = "Asia/Qostanay")]
                AsiaQostanay = 272,

                [EnumMember(Value = "Asia/Qyzylorda")]
                AsiaQyzylorda = 273,

                [EnumMember(Value = "Asia/Rangoon")]
                AsiaRangoon = 274,

                [EnumMember(Value = "Asia/Riyadh")]
                AsiaRiyadh = 275,

                [EnumMember(Value = "Asia/Saigon")]
                AsiaSaigon = 276,

                [EnumMember(Value = "Asia/Sakhalin")]
                AsiaSakhalin = 277,

                [EnumMember(Value = "Asia/Samarkand")]
                AsiaSamarkand = 278,

                [EnumMember(Value = "Asia/Seoul")]
                AsiaSeoul = 279,

                [EnumMember(Value = "Asia/Shanghai")]
                AsiaShanghai = 280,

                [EnumMember(Value = "Asia/Singapore")]
                AsiaSingapore = 281,

                [EnumMember(Value = "Asia/Srednekolymsk")]
                AsiaSrednekolymsk = 282,

                [EnumMember(Value = "Asia/Taipei")]
                AsiaTaipei = 283,

                [EnumMember(Value = "Asia/Tashkent")]
                AsiaTashkent = 284,

                [EnumMember(Value = "Asia/Tbilisi")]
                AsiaTbilisi = 285,

                [EnumMember(Value = "Asia/Tehran")]
                AsiaTehran = 286,

                [EnumMember(Value = "Asia/Thimphu")]
                AsiaThimphu = 287,

                [EnumMember(Value = "Asia/Tokyo")]
                AsiaTokyo = 288,

                [EnumMember(Value = "Asia/Tomsk")]
                AsiaTomsk = 289,

                [EnumMember(Value = "Asia/Ulaanbaatar")]
                AsiaUlaanbaatar = 290,

                [EnumMember(Value = "Asia/Urumqi")]
                AsiaUrumqi = 291,

                [EnumMember(Value = "Asia/Ust-Nera")]
                AsiaUstNera = 292,

                [EnumMember(Value = "Asia/Vientiane")]
                AsiaVientiane = 293,

                [EnumMember(Value = "Asia/Vladivostok")]
                AsiaVladivostok = 294,

                [EnumMember(Value = "Asia/Yakutsk")]
                AsiaYakutsk = 295,

                [EnumMember(Value = "Asia/Yekaterinburg")]
                AsiaYekaterinburg = 296,

                [EnumMember(Value = "Asia/Yerevan")]
                AsiaYerevan = 297,

                [EnumMember(Value = "Atlantic/Azores")]
                AtlanticAzores = 298,

                [EnumMember(Value = "Atlantic/Bermuda")]
                AtlanticBermuda = 299,

                [EnumMember(Value = "Atlantic/Canary")]
                AtlanticCanary = 300,

                [EnumMember(Value = "Atlantic/Cape_Verde")]
                AtlanticCapeVerde = 301,

                [EnumMember(Value = "Atlantic/Faeroe")]
                AtlanticFaeroe = 302,

                [EnumMember(Value = "Atlantic/Madeira")]
                AtlanticMadeira = 303,

                [EnumMember(Value = "Atlantic/Reykjavik")]
                AtlanticReykjavik = 304,

                [EnumMember(Value = "Atlantic/South_Georgia")]
                AtlanticSouthGeorgia = 305,

                [EnumMember(Value = "Atlantic/St_Helena")]
                AtlanticStHelena = 306,

                [EnumMember(Value = "Atlantic/Stanley")]
                AtlanticStanley = 307,

                [EnumMember(Value = "Australia/Adelaide")]
                AustraliaAdelaide = 308,

                [EnumMember(Value = "Australia/Brisbane")]
                AustraliaBrisbane = 309,

                [EnumMember(Value = "Australia/Broken_Hill")]
                AustraliaBrokenHill = 310,

                [EnumMember(Value = "Australia/Currie")]
                AustraliaCurrie = 311,

                [EnumMember(Value = "Australia/Darwin")]
                AustraliaDarwin = 312,

                [EnumMember(Value = "Australia/Eucla")]
                AustraliaEucla = 313,

                [EnumMember(Value = "Australia/Hobart")]
                AustraliaHobart = 314,

                [EnumMember(Value = "Australia/Lindeman")]
                AustraliaLindeman = 315,

                [EnumMember(Value = "Australia/Lord_Howe")]
                AustraliaLordHowe = 316,

                [EnumMember(Value = "Australia/Melbourne")]
                AustraliaMelbourne = 317,

                [EnumMember(Value = "Australia/Perth")]
                AustraliaPerth = 318,

                [EnumMember(Value = "Australia/Sydney")]
                AustraliaSydney = 319,

                [EnumMember(Value = "Europe/Amsterdam")]
                EuropeAmsterdam = 320,

                [EnumMember(Value = "Europe/Andorra")]
                EuropeAndorra = 321,

                [EnumMember(Value = "Europe/Astrakhan")]
                EuropeAstrakhan = 322,

                [EnumMember(Value = "Europe/Athens")]
                EuropeAthens = 323,

                [EnumMember(Value = "Europe/Belgrade")]
                EuropeBelgrade = 324,

                [EnumMember(Value = "Europe/Berlin")]
                EuropeBerlin = 325,

                [EnumMember(Value = "Europe/Bratislava")]
                EuropeBratislava = 326,

                [EnumMember(Value = "Europe/Brussels")]
                EuropeBrussels = 327,

                [EnumMember(Value = "Europe/Bucharest")]
                EuropeBucharest = 328,

                [EnumMember(Value = "Europe/Budapest")]
                EuropeBudapest = 329,

                [EnumMember(Value = "Europe/Busingen")]
                EuropeBusingen = 330,

                [EnumMember(Value = "Europe/Chisinau")]
                EuropeChisinau = 331,

                [EnumMember(Value = "Europe/Copenhagen")]
                EuropeCopenhagen = 332,

                [EnumMember(Value = "Europe/Dublin")]
                EuropeDublin = 333,

                [EnumMember(Value = "Europe/Gibraltar")]
                EuropeGibraltar = 334,

                [EnumMember(Value = "Europe/Guernsey")]
                EuropeGuernsey = 335,

                [EnumMember(Value = "Europe/Helsinki")]
                EuropeHelsinki = 336,

                [EnumMember(Value = "Europe/Isle_of_Man")]
                EuropeIsleOfMan = 337,

                [EnumMember(Value = "Europe/Istanbul")]
                EuropeIstanbul = 338,

                [EnumMember(Value = "Europe/Jersey")]
                EuropeJersey = 339,

                [EnumMember(Value = "Europe/Kaliningrad")]
                EuropeKaliningrad = 340,

                [EnumMember(Value = "Europe/Kiev")]
                EuropeKiev = 341,

                [EnumMember(Value = "Europe/Kirov")]
                EuropeKirov = 342,

                [EnumMember(Value = "Europe/Lisbon")]
                EuropeLisbon = 343,

                [EnumMember(Value = "Europe/Ljubljana")]
                EuropeLjubljana = 344,

                [EnumMember(Value = "Europe/London")]
                EuropeLondon = 345,

                [EnumMember(Value = "Europe/Luxembourg")]
                EuropeLuxembourg = 346,

                [EnumMember(Value = "Europe/Madrid")]
                EuropeMadrid = 347,

                [EnumMember(Value = "Europe/Malta")]
                EuropeMalta = 348,

                [EnumMember(Value = "Europe/Mariehamn")]
                EuropeMariehamn = 349,

                [EnumMember(Value = "Europe/Minsk")]
                EuropeMinsk = 350,

                [EnumMember(Value = "Europe/Monaco")]
                EuropeMonaco = 351,

                [EnumMember(Value = "Europe/Moscow")]
                EuropeMoscow = 352,

                [EnumMember(Value = "Europe/Oslo")]
                EuropeOslo = 353,

                [EnumMember(Value = "Europe/Paris")]
                EuropeParis = 354,

                [EnumMember(Value = "Europe/Podgorica")]
                EuropePodgorica = 355,

                [EnumMember(Value = "Europe/Prague")]
                EuropePrague = 356,

                [EnumMember(Value = "Europe/Riga")]
                EuropeRiga = 357,

                [EnumMember(Value = "Europe/Rome")]
                EuropeRome = 358,

                [EnumMember(Value = "Europe/Samara")]
                EuropeSamara = 359,

                [EnumMember(Value = "Europe/San_Marino")]
                EuropeSanMarino = 360,

                [EnumMember(Value = "Europe/Sarajevo")]
                EuropeSarajevo = 361,

                [EnumMember(Value = "Europe/Saratov")]
                EuropeSaratov = 362,

                [EnumMember(Value = "Europe/Simferopol")]
                EuropeSimferopol = 363,

                [EnumMember(Value = "Europe/Skopje")]
                EuropeSkopje = 364,

                [EnumMember(Value = "Europe/Sofia")]
                EuropeSofia = 365,

                [EnumMember(Value = "Europe/Stockholm")]
                EuropeStockholm = 366,

                [EnumMember(Value = "Europe/Tallinn")]
                EuropeTallinn = 367,

                [EnumMember(Value = "Europe/Tirane")]
                EuropeTirane = 368,

                [EnumMember(Value = "Europe/Ulyanovsk")]
                EuropeUlyanovsk = 369,

                [EnumMember(Value = "Europe/Uzhgorod")]
                EuropeUzhgorod = 370,

                [EnumMember(Value = "Europe/Vaduz")]
                EuropeVaduz = 371,

                [EnumMember(Value = "Europe/Vatican")]
                EuropeVatican = 372,

                [EnumMember(Value = "Europe/Vienna")]
                EuropeVienna = 373,

                [EnumMember(Value = "Europe/Vilnius")]
                EuropeVilnius = 374,

                [EnumMember(Value = "Europe/Volgograd")]
                EuropeVolgograd = 375,

                [EnumMember(Value = "Europe/Warsaw")]
                EuropeWarsaw = 376,

                [EnumMember(Value = "Europe/Zagreb")]
                EuropeZagreb = 377,

                [EnumMember(Value = "Europe/Zaporozhye")]
                EuropeZaporozhye = 378,

                [EnumMember(Value = "Europe/Zurich")]
                EuropeZurich = 379,

                [EnumMember(Value = "Indian/Antananarivo")]
                IndianAntananarivo = 380,

                [EnumMember(Value = "Indian/Chagos")]
                IndianChagos = 381,

                [EnumMember(Value = "Indian/Christmas")]
                IndianChristmas = 382,

                [EnumMember(Value = "Indian/Cocos")]
                IndianCocos = 383,

                [EnumMember(Value = "Indian/Comoro")]
                IndianComoro = 384,

                [EnumMember(Value = "Indian/Kerguelen")]
                IndianKerguelen = 385,

                [EnumMember(Value = "Indian/Mahe")]
                IndianMahe = 386,

                [EnumMember(Value = "Indian/Maldives")]
                IndianMaldives = 387,

                [EnumMember(Value = "Indian/Mauritius")]
                IndianMauritius = 388,

                [EnumMember(Value = "Indian/Mayotte")]
                IndianMayotte = 389,

                [EnumMember(Value = "Indian/Reunion")]
                IndianReunion = 390,

                [EnumMember(Value = "Pacific/Apia")]
                PacificApia = 391,

                [EnumMember(Value = "Pacific/Auckland")]
                PacificAuckland = 392,

                [EnumMember(Value = "Pacific/Bougainville")]
                PacificBougainville = 393,

                [EnumMember(Value = "Pacific/Chatham")]
                PacificChatham = 394,

                [EnumMember(Value = "Pacific/Easter")]
                PacificEaster = 395,

                [EnumMember(Value = "Pacific/Efate")]
                PacificEfate = 396,

                [EnumMember(Value = "Pacific/Enderbury")]
                PacificEnderbury = 397,

                [EnumMember(Value = "Pacific/Fakaofo")]
                PacificFakaofo = 398,

                [EnumMember(Value = "Pacific/Fiji")]
                PacificFiji = 399,

                [EnumMember(Value = "Pacific/Funafuti")]
                PacificFunafuti = 400,

                [EnumMember(Value = "Pacific/Galapagos")]
                PacificGalapagos = 401,

                [EnumMember(Value = "Pacific/Gambier")]
                PacificGambier = 402,

                [EnumMember(Value = "Pacific/Guadalcanal")]
                PacificGuadalcanal = 403,

                [EnumMember(Value = "Pacific/Guam")]
                PacificGuam = 404,

                [EnumMember(Value = "Pacific/Honolulu")]
                PacificHonolulu = 405,

                [EnumMember(Value = "Pacific/Johnston")]
                PacificJohnston = 406,

                [EnumMember(Value = "Pacific/Kiritimati")]
                PacificKiritimati = 407,

                [EnumMember(Value = "Pacific/Kosrae")]
                PacificKosrae = 408,

                [EnumMember(Value = "Pacific/Kwajalein")]
                PacificKwajalein = 409,

                [EnumMember(Value = "Pacific/Majuro")]
                PacificMajuro = 410,

                [EnumMember(Value = "Pacific/Marquesas")]
                PacificMarquesas = 411,

                [EnumMember(Value = "Pacific/Midway")]
                PacificMidway = 412,

                [EnumMember(Value = "Pacific/Nauru")]
                PacificNauru = 413,

                [EnumMember(Value = "Pacific/Niue")]
                PacificNiue = 414,

                [EnumMember(Value = "Pacific/Norfolk")]
                PacificNorfolk = 415,

                [EnumMember(Value = "Pacific/Noumea")]
                PacificNoumea = 416,

                [EnumMember(Value = "Pacific/Pago_Pago")]
                PacificPagoPago = 417,

                [EnumMember(Value = "Pacific/Palau")]
                PacificPalau = 418,

                [EnumMember(Value = "Pacific/Pitcairn")]
                PacificPitcairn = 419,

                [EnumMember(Value = "Pacific/Ponape")]
                PacificPonape = 420,

                [EnumMember(Value = "Pacific/Port_Moresby")]
                PacificPortMoresby = 421,

                [EnumMember(Value = "Pacific/Rarotonga")]
                PacificRarotonga = 422,

                [EnumMember(Value = "Pacific/Saipan")]
                PacificSaipan = 423,

                [EnumMember(Value = "Pacific/Tahiti")]
                PacificTahiti = 424,

                [EnumMember(Value = "Pacific/Tarawa")]
                PacificTarawa = 425,

                [EnumMember(Value = "Pacific/Tongatapu")]
                PacificTongatapu = 426,

                [EnumMember(Value = "Pacific/Truk")]
                PacificTruk = 427,

                [EnumMember(Value = "Pacific/Wake")]
                PacificWake = 428,

                [EnumMember(Value = "Pacific/Wallis")]
                PacificWallis = 429,
            }

            [DataMember(Name = "time_zone", IsRequired = true, EmitDefaultValue = false)]
            public ReportProviderMetadataRequestDevicesUltraloqMetadata.TimeZoneEnum TimeZone { get; set; }

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

        public void ReportProviderMetadata(ReportProviderMetadataRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            _seam.Post<object>("/devices/report_provider_metadata", requestOptions);
        }

        public void ReportProviderMetadata(
            List<ReportProviderMetadataRequestDevices> devices = default
        )
        {
            ReportProviderMetadata(new ReportProviderMetadataRequest(devices: devices));
        }

        public async Task ReportProviderMetadataAsync(ReportProviderMetadataRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            await _seam.PostAsync<object>("/devices/report_provider_metadata", requestOptions);
        }

        public async Task ReportProviderMetadataAsync(
            List<ReportProviderMetadataRequestDevices> devices = default
        )
        {
            await ReportProviderMetadataAsync(new ReportProviderMetadataRequest(devices: devices));
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
