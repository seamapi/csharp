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
    public class Locks
    {
        private ISeamClient _seam;

        public Locks(ISeamClient seam)
        {
            _seam = seam;
        }

        [DataContract(Name = "configureAutoLockRequest_request")]
        public class ConfigureAutoLockRequest
        {
            [JsonConstructorAttribute]
            protected ConfigureAutoLockRequest() { }

            public ConfigureAutoLockRequest(
                float? autoLockDelaySeconds = default,
                bool autoLockEnabled = default,
                string deviceId = default
            )
            {
                AutoLockDelaySeconds = autoLockDelaySeconds;
                AutoLockEnabled = autoLockEnabled;
                DeviceId = deviceId;
            }

            [DataMember(
                Name = "auto_lock_delay_seconds",
                IsRequired = false,
                EmitDefaultValue = false
            )]
            public float? AutoLockDelaySeconds { get; set; }

            [DataMember(Name = "auto_lock_enabled", IsRequired = true, EmitDefaultValue = false)]
            public bool AutoLockEnabled { get; set; }

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

        [DataContract(Name = "configureAutoLockResponse_response")]
        public class ConfigureAutoLockResponse
        {
            [JsonConstructorAttribute]
            protected ConfigureAutoLockResponse() { }

            public ConfigureAutoLockResponse(ActionAttempt actionAttempt = default)
            {
                ActionAttempt = actionAttempt;
            }

            [DataMember(Name = "action_attempt", IsRequired = false, EmitDefaultValue = false)]
            public ActionAttempt ActionAttempt { get; set; }

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

        public ActionAttempt ConfigureAutoLock(ConfigureAutoLockRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            return _seam
                .Post<ConfigureAutoLockResponse>("/locks/configure_auto_lock", requestOptions)
                .Data.ActionAttempt;
        }

        public ActionAttempt ConfigureAutoLock(
            float? autoLockDelaySeconds = default,
            bool autoLockEnabled = default,
            string deviceId = default
        )
        {
            return ConfigureAutoLock(
                new ConfigureAutoLockRequest(
                    autoLockDelaySeconds: autoLockDelaySeconds,
                    autoLockEnabled: autoLockEnabled,
                    deviceId: deviceId
                )
            );
        }

        public async Task<ActionAttempt> ConfigureAutoLockAsync(ConfigureAutoLockRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            return (
                await _seam.PostAsync<ConfigureAutoLockResponse>(
                    "/locks/configure_auto_lock",
                    requestOptions
                )
            )
                .Data
                .ActionAttempt;
        }

        public async Task<ActionAttempt> ConfigureAutoLockAsync(
            float? autoLockDelaySeconds = default,
            bool autoLockEnabled = default,
            string deviceId = default
        )
        {
            return (
                await ConfigureAutoLockAsync(
                    new ConfigureAutoLockRequest(
                        autoLockDelaySeconds: autoLockDelaySeconds,
                        autoLockEnabled: autoLockEnabled,
                        deviceId: deviceId
                    )
                )
            );
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
            return _seam.Post<GetResponse>("/locks/get", requestOptions).Data.Device;
        }

        public Device Get(string? deviceId = default, string? name = default)
        {
            return Get(new GetRequest(deviceId: deviceId, name: name));
        }

        public async Task<Device> GetAsync(GetRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            return (await _seam.PostAsync<GetResponse>("/locks/get", requestOptions)).Data.Device;
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
                ListRequest.DeviceTypeEnum? deviceType = default,
                List<ListRequest.DeviceTypesEnum>? deviceTypes = default,
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
                Limit = limit;
                Manufacturer = manufacturer;
                PageCursor = pageCursor;
                Search = search;
                SpaceId = spaceId;
                UnstableLocationId = unstableLocationId;
                UserIdentifierKey = userIdentifierKey;
            }

            [JsonConverter(typeof(SafeStringEnumConverter))]
            public enum DeviceTypeEnum
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

                [EnumMember(Value = "four_suites_door")]
                FourSuitesDoor = 22,

                [EnumMember(Value = "dormakaba_oracode_door")]
                DormakabaOracodeDoor = 23,

                [EnumMember(Value = "tedee_lock")]
                TedeeLock = 24,

                [EnumMember(Value = "akiles_lock")]
                AkilesLock = 25,

                [EnumMember(Value = "ultraloq_lock")]
                UltraloqLock = 26,

                [EnumMember(Value = "keyincode_lock")]
                KeyincodeLock = 27,

                [EnumMember(Value = "omnitec_lock")]
                OmnitecLock = 28,

                [EnumMember(Value = "kisi_lock")]
                KisiLock = 29,

                [EnumMember(Value = "aqara_lock")]
                AqaraLock = 30,
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

                [EnumMember(Value = "four_suites_door")]
                FourSuitesDoor = 22,

                [EnumMember(Value = "dormakaba_oracode_door")]
                DormakabaOracodeDoor = 23,

                [EnumMember(Value = "tedee_lock")]
                TedeeLock = 24,

                [EnumMember(Value = "akiles_lock")]
                AkilesLock = 25,

                [EnumMember(Value = "ultraloq_lock")]
                UltraloqLock = 26,

                [EnumMember(Value = "keyincode_lock")]
                KeyincodeLock = 27,

                [EnumMember(Value = "omnitec_lock")]
                OmnitecLock = 28,

                [EnumMember(Value = "kisi_lock")]
                KisiLock = 29,

                [EnumMember(Value = "aqara_lock")]
                AqaraLock = 30,
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

                [EnumMember(Value = "brivo")]
                Brivo = 3,

                [EnumMember(Value = "butterflymx")]
                Butterflymx = 4,

                [EnumMember(Value = "avigilon_alta")]
                AvigilonAlta = 5,

                [EnumMember(Value = "doorking")]
                Doorking = 6,

                [EnumMember(Value = "genie")]
                Genie = 7,

                [EnumMember(Value = "igloo")]
                Igloo = 8,

                [EnumMember(Value = "linear")]
                Linear = 9,

                [EnumMember(Value = "lockly")]
                Lockly = 10,

                [EnumMember(Value = "kwikset")]
                Kwikset = 11,

                [EnumMember(Value = "nuki")]
                Nuki = 12,

                [EnumMember(Value = "salto")]
                Salto = 13,

                [EnumMember(Value = "schlage")]
                Schlage = 14,

                [EnumMember(Value = "seam")]
                Seam = 15,

                [EnumMember(Value = "wyze")]
                Wyze = 16,

                [EnumMember(Value = "yale")]
                Yale = 17,

                [EnumMember(Value = "two_n")]
                TwoN = 18,

                [EnumMember(Value = "controlbyweb")]
                Controlbyweb = 19,

                [EnumMember(Value = "ttlock")]
                Ttlock = 20,

                [EnumMember(Value = "igloohome")]
                Igloohome = 21,

                [EnumMember(Value = "four_suites")]
                FourSuites = 22,

                [EnumMember(Value = "dormakaba_oracode")]
                DormakabaOracode = 23,

                [EnumMember(Value = "tedee")]
                Tedee = 24,

                [EnumMember(Value = "keyincode")]
                Keyincode = 25,

                [EnumMember(Value = "akiles")]
                Akiles = 26,

                [EnumMember(Value = "aqara")]
                Aqara = 27,

                [EnumMember(Value = "korelock")]
                Korelock = 28,

                [EnumMember(Value = "smartthings")]
                Smartthings = 29,

                [EnumMember(Value = "ultraloq")]
                Ultraloq = 30,

                [EnumMember(Value = "omnitec")]
                Omnitec = 31,

                [EnumMember(Value = "kisi")]
                Kisi = 32,
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
            public ListRequest.DeviceTypeEnum? DeviceType { get; set; }

            [DataMember(Name = "device_types", IsRequired = false, EmitDefaultValue = false)]
            public List<ListRequest.DeviceTypesEnum>? DeviceTypes { get; set; }

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
            return _seam.Post<ListResponse>("/locks/list", requestOptions).Data.Devices;
        }

        public List<Device> List(
            string? connectWebviewId = default,
            string? connectedAccountId = default,
            List<string>? connectedAccountIds = default,
            string? createdBefore = default,
            object? customMetadataHas = default,
            string? customerKey = default,
            List<string>? deviceIds = default,
            ListRequest.DeviceTypeEnum? deviceType = default,
            List<ListRequest.DeviceTypesEnum>? deviceTypes = default,
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
            return (await _seam.PostAsync<ListResponse>("/locks/list", requestOptions))
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
            ListRequest.DeviceTypeEnum? deviceType = default,
            List<ListRequest.DeviceTypesEnum>? deviceTypes = default,
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

        [DataContract(Name = "lockDoorRequest_request")]
        public class LockDoorRequest
        {
            [JsonConstructorAttribute]
            protected LockDoorRequest() { }

            public LockDoorRequest(string deviceId = default)
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

        [DataContract(Name = "lockDoorResponse_response")]
        public class LockDoorResponse
        {
            [JsonConstructorAttribute]
            protected LockDoorResponse() { }

            public LockDoorResponse(ActionAttempt actionAttempt = default)
            {
                ActionAttempt = actionAttempt;
            }

            [DataMember(Name = "action_attempt", IsRequired = false, EmitDefaultValue = false)]
            public ActionAttempt ActionAttempt { get; set; }

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

        public ActionAttempt LockDoor(LockDoorRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            return _seam
                .Post<LockDoorResponse>("/locks/lock_door", requestOptions)
                .Data.ActionAttempt;
        }

        public ActionAttempt LockDoor(string deviceId = default)
        {
            return LockDoor(new LockDoorRequest(deviceId: deviceId));
        }

        public async Task<ActionAttempt> LockDoorAsync(LockDoorRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            return (await _seam.PostAsync<LockDoorResponse>("/locks/lock_door", requestOptions))
                .Data
                .ActionAttempt;
        }

        public async Task<ActionAttempt> LockDoorAsync(string deviceId = default)
        {
            return (await LockDoorAsync(new LockDoorRequest(deviceId: deviceId)));
        }

        [DataContract(Name = "unlockDoorRequest_request")]
        public class UnlockDoorRequest
        {
            [JsonConstructorAttribute]
            protected UnlockDoorRequest() { }

            public UnlockDoorRequest(string deviceId = default)
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

        [DataContract(Name = "unlockDoorResponse_response")]
        public class UnlockDoorResponse
        {
            [JsonConstructorAttribute]
            protected UnlockDoorResponse() { }

            public UnlockDoorResponse(ActionAttempt actionAttempt = default)
            {
                ActionAttempt = actionAttempt;
            }

            [DataMember(Name = "action_attempt", IsRequired = false, EmitDefaultValue = false)]
            public ActionAttempt ActionAttempt { get; set; }

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

        public ActionAttempt UnlockDoor(UnlockDoorRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            return _seam
                .Post<UnlockDoorResponse>("/locks/unlock_door", requestOptions)
                .Data.ActionAttempt;
        }

        public ActionAttempt UnlockDoor(string deviceId = default)
        {
            return UnlockDoor(new UnlockDoorRequest(deviceId: deviceId));
        }

        public async Task<ActionAttempt> UnlockDoorAsync(UnlockDoorRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            return (await _seam.PostAsync<UnlockDoorResponse>("/locks/unlock_door", requestOptions))
                .Data
                .ActionAttempt;
        }

        public async Task<ActionAttempt> UnlockDoorAsync(string deviceId = default)
        {
            return (await UnlockDoorAsync(new UnlockDoorRequest(deviceId: deviceId)));
        }
    }
}

namespace Seam.Client
{
    public partial class SeamClient
    {
        public Api.Locks Locks => new(this);
    }

    public partial interface ISeamClient
    {
        public Api.Locks Locks { get; }
    }
}
