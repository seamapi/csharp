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
    public class Thermostats
    {
        private ISeamClient _seam;

        public Thermostats(ISeamClient seam)
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

            public GetResponse(Device thermostat = default)
            {
                Thermostat = thermostat;
            }

            [DataMember(Name = "thermostat", IsRequired = false, EmitDefaultValue = false)]
            public Device Thermostat { get; set; }

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
            return _seam.Post<GetResponse>("/thermostats/get", requestOptions).Data.Thermostat;
        }

        public Device Get(string? deviceId = default, string? name = default)
        {
            return Get(new GetRequest(deviceId: deviceId, name: name));
        }

        public async Task<Device> GetAsync(GetRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            return (await _seam.PostAsync<GetResponse>("/thermostats/get", requestOptions))
                .Data
                .Thermostat;
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
                string? userIdentifierKey = default
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

                [EnumMember(Value = "noiseaware_activity_zone")]
                NoiseawareActivityZone = 25,

                [EnumMember(Value = "minut_sensor")]
                MinutSensor = 26,

                [EnumMember(Value = "ecobee_thermostat")]
                EcobeeThermostat = 27,

                [EnumMember(Value = "nest_thermostat")]
                NestThermostat = 28,

                [EnumMember(Value = "ios_phone")]
                IosPhone = 29,

                [EnumMember(Value = "android_phone")]
                AndroidPhone = 30
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

                [EnumMember(Value = "noiseaware_activity_zone")]
                NoiseawareActivityZone = 25,

                [EnumMember(Value = "minut_sensor")]
                MinutSensor = 26,

                [EnumMember(Value = "ecobee_thermostat")]
                EcobeeThermostat = 27,

                [EnumMember(Value = "nest_thermostat")]
                NestThermostat = 28,

                [EnumMember(Value = "ios_phone")]
                IosPhone = 29,

                [EnumMember(Value = "android_phone")]
                AndroidPhone = 30
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
                DormakabaOracode = 31
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

            public ListResponse(List<Device> thermostats = default)
            {
                Thermostats = thermostats;
            }

            [DataMember(Name = "thermostats", IsRequired = false, EmitDefaultValue = false)]
            public List<Device> Thermostats { get; set; }

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
            return _seam.Post<ListResponse>("/thermostats/list", requestOptions).Data.Thermostats;
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
            string? userIdentifierKey = default
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
                    userIdentifierKey: userIdentifierKey
                )
            );
        }

        public async Task<List<Device>> ListAsync(ListRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            return (await _seam.PostAsync<ListResponse>("/thermostats/list", requestOptions))
                .Data
                .Thermostats;
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
            string? userIdentifierKey = default
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
                        userIdentifierKey: userIdentifierKey
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
        public Api.Thermostats Thermostats => new(this);
    }

    public partial interface ISeamClient
    {
        public Api.Thermostats Thermostats { get; }
    }
}
