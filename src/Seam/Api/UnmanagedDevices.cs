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
    public class UnmanagedDevices
    {
        private ISeamClient _seam;

        public UnmanagedDevices(ISeamClient seam)
        {
            _seam = seam;
        }

        /// <summary>
        /// Request parameters for Get an Unmanaged Device.
        /// </summary>
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

            /// <summary>
            /// ID of the unmanaged device that you want to get.
            /// </summary>
            [DataMember(Name = "device_id", IsRequired = false, EmitDefaultValue = false)]
            public string? DeviceId { get; set; }

            /// <summary>
            /// Name of the unmanaged device that you want to get.
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

        [DataContract(Name = "getResponse_response")]
        public class GetResponse
        {
            [JsonConstructorAttribute]
            protected GetResponse() { }

            public GetResponse(UnmanagedDevice device = default)
            {
                Device = device;
            }

            /// <summary>
            /// OK
            /// </summary>
            [DataMember(Name = "device", IsRequired = false, EmitDefaultValue = false)]
            public UnmanagedDevice Device { get; set; }

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
        /// Returns a specified [unmanaged device](https://docs.seam.co/core-concepts/devices/managed-and-unmanaged-devices).
        ///
        /// An unmanaged device has a limited set of visible properties and a subset of supported events. You cannot control an unmanaged device. Any [access codes](https://docs.seam.co/low-level-apis/smart-locks/access-codes/migrating-existing-access-codes) on an unmanaged device are unmanaged. To control an unmanaged device with Seam, [convert it to a managed device](https://docs.seam.co/core-concepts/devices/managed-and-unmanaged-devices#convert-an-unmanaged-device-to-managed).
        ///
        /// You must specify either `device_id` or `name`.
        /// </summary>
        public UnmanagedDevice Get(GetRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            return _seam
                .Get<GetResponse>("/devices/unmanaged/get", requestOptions)
                .EnsureData("/devices/unmanaged/get")
                .Device;
        }

        /// <summary>
        /// Returns a specified [unmanaged device](https://docs.seam.co/core-concepts/devices/managed-and-unmanaged-devices).
        ///
        /// An unmanaged device has a limited set of visible properties and a subset of supported events. You cannot control an unmanaged device. Any [access codes](https://docs.seam.co/low-level-apis/smart-locks/access-codes/migrating-existing-access-codes) on an unmanaged device are unmanaged. To control an unmanaged device with Seam, [convert it to a managed device](https://docs.seam.co/core-concepts/devices/managed-and-unmanaged-devices#convert-an-unmanaged-device-to-managed).
        ///
        /// You must specify either `device_id` or `name`.
        /// </summary>
        public UnmanagedDevice Get(string? deviceId = default, string? name = default)
        {
            return Get(new GetRequest(deviceId: deviceId, name: name));
        }

        /// <summary>
        /// Returns a specified [unmanaged device](https://docs.seam.co/core-concepts/devices/managed-and-unmanaged-devices).
        ///
        /// An unmanaged device has a limited set of visible properties and a subset of supported events. You cannot control an unmanaged device. Any [access codes](https://docs.seam.co/low-level-apis/smart-locks/access-codes/migrating-existing-access-codes) on an unmanaged device are unmanaged. To control an unmanaged device with Seam, [convert it to a managed device](https://docs.seam.co/core-concepts/devices/managed-and-unmanaged-devices#convert-an-unmanaged-device-to-managed).
        ///
        /// You must specify either `device_id` or `name`.
        /// </summary>
        public async Task<UnmanagedDevice> GetAsync(GetRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            return (await _seam.GetAsync<GetResponse>("/devices/unmanaged/get", requestOptions))
                .EnsureData("/devices/unmanaged/get")
                .Device;
        }

        /// <summary>
        /// Returns a specified [unmanaged device](https://docs.seam.co/core-concepts/devices/managed-and-unmanaged-devices).
        ///
        /// An unmanaged device has a limited set of visible properties and a subset of supported events. You cannot control an unmanaged device. Any [access codes](https://docs.seam.co/low-level-apis/smart-locks/access-codes/migrating-existing-access-codes) on an unmanaged device are unmanaged. To control an unmanaged device with Seam, [convert it to a managed device](https://docs.seam.co/core-concepts/devices/managed-and-unmanaged-devices#convert-an-unmanaged-device-to-managed).
        ///
        /// You must specify either `device_id` or `name`.
        /// </summary>
        public async Task<UnmanagedDevice> GetAsync(
            string? deviceId = default,
            string? name = default
        )
        {
            return (await GetAsync(new GetRequest(deviceId: deviceId, name: name)));
        }

        /// <summary>
        /// Request parameters for List Unmanaged Devices.
        /// </summary>
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
                string? customerKey = default,
                List<string>? deviceIds = default,
                ListRequest.DeviceTypeEnum? deviceType = default,
                List<ListRequest.DeviceTypesEnum>? deviceTypes = default,
                float? limit = default,
                ListRequest.ManufacturerEnum? manufacturer = default,
                string? pageCursor = default,
                string? search = default
            )
            {
                ConnectWebviewId = connectWebviewId;
                ConnectedAccountId = connectedAccountId;
                ConnectedAccountIds = connectedAccountIds;
                CreatedBefore = createdBefore;
                CustomerKey = customerKey;
                DeviceIds = deviceIds;
                DeviceType = deviceType;
                DeviceTypes = deviceTypes;
                Limit = limit;
                Manufacturer = manufacturer;
                PageCursor = pageCursor;
                Search = search;
            }

            /// <summary>
            /// Device type for which you want to list devices.
            /// </summary>
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

                [EnumMember(Value = "yacan_lock")]
                YacanLock = 27,

                [EnumMember(Value = "keyincode_lock")]
                KeyincodeLock = 28,

                [EnumMember(Value = "omnitec_lock")]
                OmnitecLock = 29,

                [EnumMember(Value = "kisi_lock")]
                KisiLock = 30,

                [EnumMember(Value = "aqara_lock")]
                AqaraLock = 31,

                [EnumMember(Value = "keynest_key")]
                KeynestKey = 32,

                [EnumMember(Value = "noiseaware_activity_zone")]
                NoiseawareActivityZone = 33,

                [EnumMember(Value = "minut_sensor")]
                MinutSensor = 34,

                [EnumMember(Value = "ecobee_thermostat")]
                EcobeeThermostat = 35,

                [EnumMember(Value = "nest_thermostat")]
                NestThermostat = 36,

                [EnumMember(Value = "honeywell_resideo_thermostat")]
                HoneywellResideoThermostat = 37,

                [EnumMember(Value = "tado_thermostat")]
                TadoThermostat = 38,

                [EnumMember(Value = "sensi_thermostat")]
                SensiThermostat = 39,

                [EnumMember(Value = "smartthings_thermostat")]
                SmartthingsThermostat = 40,

                [EnumMember(Value = "ios_phone")]
                IosPhone = 41,

                [EnumMember(Value = "android_phone")]
                AndroidPhone = 42,

                [EnumMember(Value = "ring_camera")]
                RingCamera = 43,
            }

            /// <summary>
            /// Array of device types for which you want to list devices.
            /// </summary>
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

                [EnumMember(Value = "yacan_lock")]
                YacanLock = 27,

                [EnumMember(Value = "keyincode_lock")]
                KeyincodeLock = 28,

                [EnumMember(Value = "omnitec_lock")]
                OmnitecLock = 29,

                [EnumMember(Value = "kisi_lock")]
                KisiLock = 30,

                [EnumMember(Value = "aqara_lock")]
                AqaraLock = 31,

                [EnumMember(Value = "keynest_key")]
                KeynestKey = 32,

                [EnumMember(Value = "noiseaware_activity_zone")]
                NoiseawareActivityZone = 33,

                [EnumMember(Value = "minut_sensor")]
                MinutSensor = 34,

                [EnumMember(Value = "ecobee_thermostat")]
                EcobeeThermostat = 35,

                [EnumMember(Value = "nest_thermostat")]
                NestThermostat = 36,

                [EnumMember(Value = "honeywell_resideo_thermostat")]
                HoneywellResideoThermostat = 37,

                [EnumMember(Value = "tado_thermostat")]
                TadoThermostat = 38,

                [EnumMember(Value = "sensi_thermostat")]
                SensiThermostat = 39,

                [EnumMember(Value = "smartthings_thermostat")]
                SmartthingsThermostat = 40,

                [EnumMember(Value = "ios_phone")]
                IosPhone = 41,

                [EnumMember(Value = "android_phone")]
                AndroidPhone = 42,

                [EnumMember(Value = "ring_camera")]
                RingCamera = 43,
            }

            /// <summary>
            /// Manufacturer for which you want to list devices.
            /// </summary>
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

                [EnumMember(Value = "two_n")]
                TwoN = 22,

                [EnumMember(Value = "ttlock")]
                Ttlock = 23,

                [EnumMember(Value = "igloohome")]
                Igloohome = 24,

                [EnumMember(Value = "controlbyweb")]
                Controlbyweb = 25,

                [EnumMember(Value = "dormakaba_oracode")]
                DormakabaOracode = 26,

                [EnumMember(Value = "tedee")]
                Tedee = 27,

                [EnumMember(Value = "keyincode")]
                Keyincode = 28,

                [EnumMember(Value = "akiles")]
                Akiles = 29,

                [EnumMember(Value = "aqara")]
                Aqara = 30,

                [EnumMember(Value = "ecobee")]
                Ecobee = 31,

                [EnumMember(Value = "honeywell_resideo")]
                HoneywellResideo = 32,

                [EnumMember(Value = "keynest")]
                Keynest = 33,

                [EnumMember(Value = "korelock")]
                Korelock = 34,

                [EnumMember(Value = "lockly")]
                Lockly = 35,

                [EnumMember(Value = "minut")]
                Minut = 36,

                [EnumMember(Value = "nest")]
                Nest = 37,

                [EnumMember(Value = "noiseaware")]
                Noiseaware = 38,

                [EnumMember(Value = "sensi")]
                Sensi = 39,

                [EnumMember(Value = "smartthings")]
                Smartthings = 40,

                [EnumMember(Value = "tado")]
                Tado = 41,

                [EnumMember(Value = "ultraloq")]
                Ultraloq = 42,

                [EnumMember(Value = "ring")]
                Ring = 43,

                [EnumMember(Value = "ical")]
                Ical = 44,

                [EnumMember(Value = "lodgify")]
                Lodgify = 45,

                [EnumMember(Value = "hostaway")]
                Hostaway = 46,

                [EnumMember(Value = "guesty")]
                Guesty = 47,

                [EnumMember(Value = "acuity_scheduling")]
                AcuityScheduling = 48,

                [EnumMember(Value = "omnitec")]
                Omnitec = 49,

                [EnumMember(Value = "kisi")]
                Kisi = 50,

                [EnumMember(Value = "slack")]
                Slack = 51,

                [EnumMember(Value = "yacan")]
                Yacan = 52,
            }

            /// <summary>
            /// ID of the Connect Webview for which you want to list devices.
            /// </summary>
            [DataMember(Name = "connect_webview_id", IsRequired = false, EmitDefaultValue = false)]
            public string? ConnectWebviewId { get; set; }

            /// <summary>
            /// ID of the connected account for which you want to list devices.
            /// </summary>
            [DataMember(
                Name = "connected_account_id",
                IsRequired = false,
                EmitDefaultValue = false
            )]
            public string? ConnectedAccountId { get; set; }

            /// <summary>
            /// Array of IDs of the connected accounts for which you want to list devices.
            /// </summary>
            [DataMember(
                Name = "connected_account_ids",
                IsRequired = false,
                EmitDefaultValue = false
            )]
            public List<string>? ConnectedAccountIds { get; set; }

            /// <summary>
            /// Timestamp by which to limit returned devices. Returns devices created before this timestamp.
            /// </summary>
            [DataMember(Name = "created_before", IsRequired = false, EmitDefaultValue = false)]
            public string? CreatedBefore { get; set; }

            /// <summary>
            /// Customer key for which you want to list devices.
            /// </summary>
            [DataMember(Name = "customer_key", IsRequired = false, EmitDefaultValue = false)]
            public string? CustomerKey { get; set; }

            /// <summary>
            /// Array of device IDs for which you want to list devices.
            /// </summary>
            [DataMember(Name = "device_ids", IsRequired = false, EmitDefaultValue = false)]
            public List<string>? DeviceIds { get; set; }

            /// <summary>
            /// Device type for which you want to list devices.
            /// </summary>
            [DataMember(Name = "device_type", IsRequired = false, EmitDefaultValue = false)]
            public ListRequest.DeviceTypeEnum? DeviceType { get; set; }

            /// <summary>
            /// Array of device types for which you want to list devices.
            /// </summary>
            [DataMember(Name = "device_types", IsRequired = false, EmitDefaultValue = false)]
            public List<ListRequest.DeviceTypesEnum>? DeviceTypes { get; set; }

            /// <summary>
            /// Numerical limit on the number of devices to return.
            /// </summary>
            [DataMember(Name = "limit", IsRequired = false, EmitDefaultValue = false)]
            public float? Limit { get; set; }

            /// <summary>
            /// Manufacturer for which you want to list devices.
            /// </summary>
            [DataMember(Name = "manufacturer", IsRequired = false, EmitDefaultValue = false)]
            public ListRequest.ManufacturerEnum? Manufacturer { get; set; }

            /// <summary>
            /// Identifies the specific page of results to return, obtained from the previous page&apos;s `next_page_cursor`.
            /// </summary>
            [DataMember(Name = "page_cursor", IsRequired = false, EmitDefaultValue = false)]
            public string? PageCursor { get; set; }

            /// <summary>
            /// String for which to search. Filters returned devices to include all records that satisfy a partial match using `device_id` (full or partial UUID prefix, minimum 4 characters), `connected_account_id`, `display_name`, `custom_metadata` or `location.location_name`.
            /// </summary>
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

            public ListResponse(List<UnmanagedDevice> devices = default)
            {
                Devices = devices;
            }

            /// <summary>
            /// OK
            /// </summary>
            [DataMember(Name = "devices", IsRequired = false, EmitDefaultValue = false)]
            public List<UnmanagedDevice> Devices { get; set; }

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
        /// Returns a list of all [unmanaged devices](https://docs.seam.co/core-concepts/devices/managed-and-unmanaged-devices).
        ///
        /// An unmanaged device has a limited set of visible properties and a subset of supported events. You cannot control an unmanaged device. Any [access codes](https://docs.seam.co/low-level-apis/smart-locks/access-codes/migrating-existing-access-codes) on an unmanaged device are unmanaged. To control an unmanaged device with Seam, [convert it to a managed device](https://docs.seam.co/core-concepts/devices/managed-and-unmanaged-devices#convert-an-unmanaged-device-to-managed).
        /// </summary>
        public List<UnmanagedDevice> List(ListRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            return _seam
                .Get<ListResponse>("/devices/unmanaged/list", requestOptions)
                .EnsureData("/devices/unmanaged/list")
                .Devices;
        }

        /// <summary>
        /// Returns a list of all [unmanaged devices](https://docs.seam.co/core-concepts/devices/managed-and-unmanaged-devices).
        ///
        /// An unmanaged device has a limited set of visible properties and a subset of supported events. You cannot control an unmanaged device. Any [access codes](https://docs.seam.co/low-level-apis/smart-locks/access-codes/migrating-existing-access-codes) on an unmanaged device are unmanaged. To control an unmanaged device with Seam, [convert it to a managed device](https://docs.seam.co/core-concepts/devices/managed-and-unmanaged-devices#convert-an-unmanaged-device-to-managed).
        /// </summary>
        public List<UnmanagedDevice> List(
            string? connectWebviewId = default,
            string? connectedAccountId = default,
            List<string>? connectedAccountIds = default,
            string? createdBefore = default,
            string? customerKey = default,
            List<string>? deviceIds = default,
            ListRequest.DeviceTypeEnum? deviceType = default,
            List<ListRequest.DeviceTypesEnum>? deviceTypes = default,
            float? limit = default,
            ListRequest.ManufacturerEnum? manufacturer = default,
            string? pageCursor = default,
            string? search = default
        )
        {
            return List(
                new ListRequest(
                    connectWebviewId: connectWebviewId,
                    connectedAccountId: connectedAccountId,
                    connectedAccountIds: connectedAccountIds,
                    createdBefore: createdBefore,
                    customerKey: customerKey,
                    deviceIds: deviceIds,
                    deviceType: deviceType,
                    deviceTypes: deviceTypes,
                    limit: limit,
                    manufacturer: manufacturer,
                    pageCursor: pageCursor,
                    search: search
                )
            );
        }

        /// <summary>
        /// Returns a list of all [unmanaged devices](https://docs.seam.co/core-concepts/devices/managed-and-unmanaged-devices).
        ///
        /// An unmanaged device has a limited set of visible properties and a subset of supported events. You cannot control an unmanaged device. Any [access codes](https://docs.seam.co/low-level-apis/smart-locks/access-codes/migrating-existing-access-codes) on an unmanaged device are unmanaged. To control an unmanaged device with Seam, [convert it to a managed device](https://docs.seam.co/core-concepts/devices/managed-and-unmanaged-devices#convert-an-unmanaged-device-to-managed).
        /// </summary>
        public async Task<List<UnmanagedDevice>> ListAsync(ListRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            return (await _seam.GetAsync<ListResponse>("/devices/unmanaged/list", requestOptions))
                .EnsureData("/devices/unmanaged/list")
                .Devices;
        }

        /// <summary>
        /// Returns a list of all [unmanaged devices](https://docs.seam.co/core-concepts/devices/managed-and-unmanaged-devices).
        ///
        /// An unmanaged device has a limited set of visible properties and a subset of supported events. You cannot control an unmanaged device. Any [access codes](https://docs.seam.co/low-level-apis/smart-locks/access-codes/migrating-existing-access-codes) on an unmanaged device are unmanaged. To control an unmanaged device with Seam, [convert it to a managed device](https://docs.seam.co/core-concepts/devices/managed-and-unmanaged-devices#convert-an-unmanaged-device-to-managed).
        /// </summary>
        public async Task<List<UnmanagedDevice>> ListAsync(
            string? connectWebviewId = default,
            string? connectedAccountId = default,
            List<string>? connectedAccountIds = default,
            string? createdBefore = default,
            string? customerKey = default,
            List<string>? deviceIds = default,
            ListRequest.DeviceTypeEnum? deviceType = default,
            List<ListRequest.DeviceTypesEnum>? deviceTypes = default,
            float? limit = default,
            ListRequest.ManufacturerEnum? manufacturer = default,
            string? pageCursor = default,
            string? search = default
        )
        {
            return (
                await ListAsync(
                    new ListRequest(
                        connectWebviewId: connectWebviewId,
                        connectedAccountId: connectedAccountId,
                        connectedAccountIds: connectedAccountIds,
                        createdBefore: createdBefore,
                        customerKey: customerKey,
                        deviceIds: deviceIds,
                        deviceType: deviceType,
                        deviceTypes: deviceTypes,
                        limit: limit,
                        manufacturer: manufacturer,
                        pageCursor: pageCursor,
                        search: search
                    )
                )
            );
        }

        /// <summary>
        /// Request parameters for Update an Unmanaged Device.
        /// </summary>
        [DataContract(Name = "updateRequest_request")]
        public class UpdateRequest
        {
            [JsonConstructorAttribute]
            protected UpdateRequest() { }

            public UpdateRequest(
                object? customMetadata = default,
                string deviceId = default,
                bool? isManaged = default
            )
            {
                CustomMetadata = customMetadata;
                DeviceId = deviceId;
                IsManaged = isManaged;
            }

            /// <summary>
            /// Custom metadata that you want to associate with the device. Supports up to 50 JSON key:value pairs, with key names up to 40 characters long that cannot contain a period (.). Set a key to `null` or to an empty string to remove that key from the custom metadata.
            /// </summary>
            [DataMember(Name = "custom_metadata", IsRequired = false, EmitDefaultValue = false)]
            public object? CustomMetadata { get; set; }

            /// <summary>
            /// ID of the unmanaged device that you want to update.
            /// </summary>
            [DataMember(Name = "device_id", IsRequired = true, EmitDefaultValue = false)]
            public string DeviceId { get; set; }

            /// <summary>
            /// Indicates whether the device is managed. Set this parameter to `true` to convert an unmanaged device to managed.
            /// </summary>
            [DataMember(Name = "is_managed", IsRequired = false, EmitDefaultValue = false)]
            public bool? IsManaged { get; set; }

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
        /// Updates a specified [unmanaged device](https://docs.seam.co/core-concepts/devices/managed-and-unmanaged-devices). To convert an unmanaged device to managed, set `is_managed` to `true`.
        ///
        /// An unmanaged device has a limited set of visible properties and a subset of supported events. You cannot control an unmanaged device. Any [access codes](https://docs.seam.co/low-level-apis/smart-locks/access-codes/migrating-existing-access-codes) on an unmanaged device are unmanaged. To control an unmanaged device with Seam, [convert it to a managed device](https://docs.seam.co/core-concepts/devices/managed-and-unmanaged-devices#convert-an-unmanaged-device-to-managed).
        /// </summary>
        public void Update(UpdateRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            _seam.Patch<object>("/devices/unmanaged/update", requestOptions);
        }

        /// <summary>
        /// Updates a specified [unmanaged device](https://docs.seam.co/core-concepts/devices/managed-and-unmanaged-devices). To convert an unmanaged device to managed, set `is_managed` to `true`.
        ///
        /// An unmanaged device has a limited set of visible properties and a subset of supported events. You cannot control an unmanaged device. Any [access codes](https://docs.seam.co/low-level-apis/smart-locks/access-codes/migrating-existing-access-codes) on an unmanaged device are unmanaged. To control an unmanaged device with Seam, [convert it to a managed device](https://docs.seam.co/core-concepts/devices/managed-and-unmanaged-devices#convert-an-unmanaged-device-to-managed).
        /// </summary>
        public void Update(
            object? customMetadata = default,
            string deviceId = default,
            bool? isManaged = default
        )
        {
            Update(
                new UpdateRequest(
                    customMetadata: customMetadata,
                    deviceId: deviceId,
                    isManaged: isManaged
                )
            );
        }

        /// <summary>
        /// Updates a specified [unmanaged device](https://docs.seam.co/core-concepts/devices/managed-and-unmanaged-devices). To convert an unmanaged device to managed, set `is_managed` to `true`.
        ///
        /// An unmanaged device has a limited set of visible properties and a subset of supported events. You cannot control an unmanaged device. Any [access codes](https://docs.seam.co/low-level-apis/smart-locks/access-codes/migrating-existing-access-codes) on an unmanaged device are unmanaged. To control an unmanaged device with Seam, [convert it to a managed device](https://docs.seam.co/core-concepts/devices/managed-and-unmanaged-devices#convert-an-unmanaged-device-to-managed).
        /// </summary>
        public async Task UpdateAsync(UpdateRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            await _seam.PatchAsync<object>("/devices/unmanaged/update", requestOptions);
        }

        /// <summary>
        /// Updates a specified [unmanaged device](https://docs.seam.co/core-concepts/devices/managed-and-unmanaged-devices). To convert an unmanaged device to managed, set `is_managed` to `true`.
        ///
        /// An unmanaged device has a limited set of visible properties and a subset of supported events. You cannot control an unmanaged device. Any [access codes](https://docs.seam.co/low-level-apis/smart-locks/access-codes/migrating-existing-access-codes) on an unmanaged device are unmanaged. To control an unmanaged device with Seam, [convert it to a managed device](https://docs.seam.co/core-concepts/devices/managed-and-unmanaged-devices#convert-an-unmanaged-device-to-managed).
        /// </summary>
        public async Task UpdateAsync(
            object? customMetadata = default,
            string deviceId = default,
            bool? isManaged = default
        )
        {
            await UpdateAsync(
                new UpdateRequest(
                    customMetadata: customMetadata,
                    deviceId: deviceId,
                    isManaged: isManaged
                )
            );
        }
    }
}

namespace Seam.Client
{
    public partial class SeamClient
    {
        public Api.UnmanagedDevices UnmanagedDevices => new(this);
    }

    public partial interface ISeamClient
    {
        public Api.UnmanagedDevices UnmanagedDevices { get; }
    }
}
