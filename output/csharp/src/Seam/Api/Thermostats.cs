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

        [DataContract(Name = "coolRequest_request")]
        public class CoolRequest
        {
            [JsonConstructorAttribute]
            protected CoolRequest() { }

            public CoolRequest(
                string deviceId = default,
                float? coolingSetPointCelsius = default,
                float? coolingSetPointFahrenheit = default,
                bool? sync = default
            )
            {
                DeviceId = deviceId;
                CoolingSetPointCelsius = coolingSetPointCelsius;
                CoolingSetPointFahrenheit = coolingSetPointFahrenheit;
                Sync = sync;
            }

            [DataMember(Name = "device_id", IsRequired = true, EmitDefaultValue = false)]
            public string DeviceId { get; set; }

            [DataMember(
                Name = "cooling_set_point_celsius",
                IsRequired = false,
                EmitDefaultValue = false
            )]
            public float? CoolingSetPointCelsius { get; set; }

            [DataMember(
                Name = "cooling_set_point_fahrenheit",
                IsRequired = false,
                EmitDefaultValue = false
            )]
            public float? CoolingSetPointFahrenheit { get; set; }

            [DataMember(Name = "sync", IsRequired = false, EmitDefaultValue = false)]
            public bool? Sync { get; set; }

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

        [DataContract(Name = "coolResponse_response")]
        public class CoolResponse
        {
            [JsonConstructorAttribute]
            protected CoolResponse() { }

            public CoolResponse(ActionAttempt actionAttempt = default)
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

        public ActionAttempt Cool(CoolRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            return _seam.Post<CoolResponse>("/thermostats/cool", requestOptions).Data.ActionAttempt;
        }

        public ActionAttempt Cool(
            string deviceId = default,
            float? coolingSetPointCelsius = default,
            float? coolingSetPointFahrenheit = default,
            bool? sync = default
        )
        {
            return Cool(
                new CoolRequest(
                    deviceId: deviceId,
                    coolingSetPointCelsius: coolingSetPointCelsius,
                    coolingSetPointFahrenheit: coolingSetPointFahrenheit,
                    sync: sync
                )
            );
        }

        public async Task<ActionAttempt> CoolAsync(CoolRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            return (await _seam.PostAsync<CoolResponse>("/thermostats/cool", requestOptions))
                .Data
                .ActionAttempt;
        }

        public async Task<ActionAttempt> CoolAsync(
            string deviceId = default,
            float? coolingSetPointCelsius = default,
            float? coolingSetPointFahrenheit = default,
            bool? sync = default
        )
        {
            return (
                await CoolAsync(
                    new CoolRequest(
                        deviceId: deviceId,
                        coolingSetPointCelsius: coolingSetPointCelsius,
                        coolingSetPointFahrenheit: coolingSetPointFahrenheit,
                        sync: sync
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

        [DataContract(Name = "heatRequest_request")]
        public class HeatRequest
        {
            [JsonConstructorAttribute]
            protected HeatRequest() { }

            public HeatRequest(
                string deviceId = default,
                float? heatingSetPointCelsius = default,
                float? heatingSetPointFahrenheit = default,
                bool? sync = default
            )
            {
                DeviceId = deviceId;
                HeatingSetPointCelsius = heatingSetPointCelsius;
                HeatingSetPointFahrenheit = heatingSetPointFahrenheit;
                Sync = sync;
            }

            [DataMember(Name = "device_id", IsRequired = true, EmitDefaultValue = false)]
            public string DeviceId { get; set; }

            [DataMember(
                Name = "heating_set_point_celsius",
                IsRequired = false,
                EmitDefaultValue = false
            )]
            public float? HeatingSetPointCelsius { get; set; }

            [DataMember(
                Name = "heating_set_point_fahrenheit",
                IsRequired = false,
                EmitDefaultValue = false
            )]
            public float? HeatingSetPointFahrenheit { get; set; }

            [DataMember(Name = "sync", IsRequired = false, EmitDefaultValue = false)]
            public bool? Sync { get; set; }

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

        [DataContract(Name = "heatResponse_response")]
        public class HeatResponse
        {
            [JsonConstructorAttribute]
            protected HeatResponse() { }

            public HeatResponse(ActionAttempt actionAttempt = default)
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

        public ActionAttempt Heat(HeatRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            return _seam.Post<HeatResponse>("/thermostats/heat", requestOptions).Data.ActionAttempt;
        }

        public ActionAttempt Heat(
            string deviceId = default,
            float? heatingSetPointCelsius = default,
            float? heatingSetPointFahrenheit = default,
            bool? sync = default
        )
        {
            return Heat(
                new HeatRequest(
                    deviceId: deviceId,
                    heatingSetPointCelsius: heatingSetPointCelsius,
                    heatingSetPointFahrenheit: heatingSetPointFahrenheit,
                    sync: sync
                )
            );
        }

        public async Task<ActionAttempt> HeatAsync(HeatRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            return (await _seam.PostAsync<HeatResponse>("/thermostats/heat", requestOptions))
                .Data
                .ActionAttempt;
        }

        public async Task<ActionAttempt> HeatAsync(
            string deviceId = default,
            float? heatingSetPointCelsius = default,
            float? heatingSetPointFahrenheit = default,
            bool? sync = default
        )
        {
            return (
                await HeatAsync(
                    new HeatRequest(
                        deviceId: deviceId,
                        heatingSetPointCelsius: heatingSetPointCelsius,
                        heatingSetPointFahrenheit: heatingSetPointFahrenheit,
                        sync: sync
                    )
                )
            );
        }

        [DataContract(Name = "heatCoolRequest_request")]
        public class HeatCoolRequest
        {
            [JsonConstructorAttribute]
            protected HeatCoolRequest() { }

            public HeatCoolRequest(
                string deviceId = default,
                float? heatingSetPointCelsius = default,
                float? heatingSetPointFahrenheit = default,
                float? coolingSetPointCelsius = default,
                float? coolingSetPointFahrenheit = default,
                bool? sync = default
            )
            {
                DeviceId = deviceId;
                HeatingSetPointCelsius = heatingSetPointCelsius;
                HeatingSetPointFahrenheit = heatingSetPointFahrenheit;
                CoolingSetPointCelsius = coolingSetPointCelsius;
                CoolingSetPointFahrenheit = coolingSetPointFahrenheit;
                Sync = sync;
            }

            [DataMember(Name = "device_id", IsRequired = true, EmitDefaultValue = false)]
            public string DeviceId { get; set; }

            [DataMember(
                Name = "heating_set_point_celsius",
                IsRequired = false,
                EmitDefaultValue = false
            )]
            public float? HeatingSetPointCelsius { get; set; }

            [DataMember(
                Name = "heating_set_point_fahrenheit",
                IsRequired = false,
                EmitDefaultValue = false
            )]
            public float? HeatingSetPointFahrenheit { get; set; }

            [DataMember(
                Name = "cooling_set_point_celsius",
                IsRequired = false,
                EmitDefaultValue = false
            )]
            public float? CoolingSetPointCelsius { get; set; }

            [DataMember(
                Name = "cooling_set_point_fahrenheit",
                IsRequired = false,
                EmitDefaultValue = false
            )]
            public float? CoolingSetPointFahrenheit { get; set; }

            [DataMember(Name = "sync", IsRequired = false, EmitDefaultValue = false)]
            public bool? Sync { get; set; }

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

        [DataContract(Name = "heatCoolResponse_response")]
        public class HeatCoolResponse
        {
            [JsonConstructorAttribute]
            protected HeatCoolResponse() { }

            public HeatCoolResponse(ActionAttempt actionAttempt = default)
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

        public ActionAttempt HeatCool(HeatCoolRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            return _seam
                .Post<HeatCoolResponse>("/thermostats/heat_cool", requestOptions)
                .Data.ActionAttempt;
        }

        public ActionAttempt HeatCool(
            string deviceId = default,
            float? heatingSetPointCelsius = default,
            float? heatingSetPointFahrenheit = default,
            float? coolingSetPointCelsius = default,
            float? coolingSetPointFahrenheit = default,
            bool? sync = default
        )
        {
            return HeatCool(
                new HeatCoolRequest(
                    deviceId: deviceId,
                    heatingSetPointCelsius: heatingSetPointCelsius,
                    heatingSetPointFahrenheit: heatingSetPointFahrenheit,
                    coolingSetPointCelsius: coolingSetPointCelsius,
                    coolingSetPointFahrenheit: coolingSetPointFahrenheit,
                    sync: sync
                )
            );
        }

        public async Task<ActionAttempt> HeatCoolAsync(HeatCoolRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            return (
                await _seam.PostAsync<HeatCoolResponse>("/thermostats/heat_cool", requestOptions)
            )
                .Data
                .ActionAttempt;
        }

        public async Task<ActionAttempt> HeatCoolAsync(
            string deviceId = default,
            float? heatingSetPointCelsius = default,
            float? heatingSetPointFahrenheit = default,
            float? coolingSetPointCelsius = default,
            float? coolingSetPointFahrenheit = default,
            bool? sync = default
        )
        {
            return (
                await HeatCoolAsync(
                    new HeatCoolRequest(
                        deviceId: deviceId,
                        heatingSetPointCelsius: heatingSetPointCelsius,
                        heatingSetPointFahrenheit: heatingSetPointFahrenheit,
                        coolingSetPointCelsius: coolingSetPointCelsius,
                        coolingSetPointFahrenheit: coolingSetPointFahrenheit,
                        sync: sync
                    )
                )
            );
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

        [DataContract(Name = "offRequest_request")]
        public class OffRequest
        {
            [JsonConstructorAttribute]
            protected OffRequest() { }

            public OffRequest(string deviceId = default, bool? sync = default)
            {
                DeviceId = deviceId;
                Sync = sync;
            }

            [DataMember(Name = "device_id", IsRequired = true, EmitDefaultValue = false)]
            public string DeviceId { get; set; }

            [DataMember(Name = "sync", IsRequired = false, EmitDefaultValue = false)]
            public bool? Sync { get; set; }

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

        [DataContract(Name = "offResponse_response")]
        public class OffResponse
        {
            [JsonConstructorAttribute]
            protected OffResponse() { }

            public OffResponse(ActionAttempt actionAttempt = default)
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

        public ActionAttempt Off(OffRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            return _seam.Post<OffResponse>("/thermostats/off", requestOptions).Data.ActionAttempt;
        }

        public ActionAttempt Off(string deviceId = default, bool? sync = default)
        {
            return Off(new OffRequest(deviceId: deviceId, sync: sync));
        }

        public async Task<ActionAttempt> OffAsync(OffRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            return (await _seam.PostAsync<OffResponse>("/thermostats/off", requestOptions))
                .Data
                .ActionAttempt;
        }

        public async Task<ActionAttempt> OffAsync(string deviceId = default, bool? sync = default)
        {
            return (await OffAsync(new OffRequest(deviceId: deviceId, sync: sync)));
        }

        [DataContract(Name = "setFanModeRequest_request")]
        public class SetFanModeRequest
        {
            [JsonConstructorAttribute]
            protected SetFanModeRequest() { }

            public SetFanModeRequest(
                string deviceId = default,
                SetFanModeRequest.FanModeEnum? fanMode = default,
                SetFanModeRequest.FanModeSettingEnum? fanModeSetting = default,
                bool? sync = default
            )
            {
                DeviceId = deviceId;
                FanMode = fanMode;
                FanModeSetting = fanModeSetting;
                Sync = sync;
            }

            [JsonConverter(typeof(StringEnumConverter))]
            public enum FanModeEnum
            {
                [EnumMember(Value = "auto")]
                Auto = 0,

                [EnumMember(Value = "on")]
                On = 1
            }

            [JsonConverter(typeof(StringEnumConverter))]
            public enum FanModeSettingEnum
            {
                [EnumMember(Value = "auto")]
                Auto = 0,

                [EnumMember(Value = "on")]
                On = 1
            }

            [DataMember(Name = "device_id", IsRequired = true, EmitDefaultValue = false)]
            public string DeviceId { get; set; }

            [DataMember(Name = "fan_mode", IsRequired = false, EmitDefaultValue = false)]
            public SetFanModeRequest.FanModeEnum? FanMode { get; set; }

            [DataMember(Name = "fan_mode_setting", IsRequired = false, EmitDefaultValue = false)]
            public SetFanModeRequest.FanModeSettingEnum? FanModeSetting { get; set; }

            [DataMember(Name = "sync", IsRequired = false, EmitDefaultValue = false)]
            public bool? Sync { get; set; }

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

        [DataContract(Name = "setFanModeResponse_response")]
        public class SetFanModeResponse
        {
            [JsonConstructorAttribute]
            protected SetFanModeResponse() { }

            public SetFanModeResponse(ActionAttempt actionAttempt = default)
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

        public ActionAttempt SetFanMode(SetFanModeRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            return _seam
                .Post<SetFanModeResponse>("/thermostats/set_fan_mode", requestOptions)
                .Data.ActionAttempt;
        }

        public ActionAttempt SetFanMode(
            string deviceId = default,
            SetFanModeRequest.FanModeEnum? fanMode = default,
            SetFanModeRequest.FanModeSettingEnum? fanModeSetting = default,
            bool? sync = default
        )
        {
            return SetFanMode(
                new SetFanModeRequest(
                    deviceId: deviceId,
                    fanMode: fanMode,
                    fanModeSetting: fanModeSetting,
                    sync: sync
                )
            );
        }

        public async Task<ActionAttempt> SetFanModeAsync(SetFanModeRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            return (
                await _seam.PostAsync<SetFanModeResponse>(
                    "/thermostats/set_fan_mode",
                    requestOptions
                )
            )
                .Data
                .ActionAttempt;
        }

        public async Task<ActionAttempt> SetFanModeAsync(
            string deviceId = default,
            SetFanModeRequest.FanModeEnum? fanMode = default,
            SetFanModeRequest.FanModeSettingEnum? fanModeSetting = default,
            bool? sync = default
        )
        {
            return (
                await SetFanModeAsync(
                    new SetFanModeRequest(
                        deviceId: deviceId,
                        fanMode: fanMode,
                        fanModeSetting: fanModeSetting,
                        sync: sync
                    )
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
                UpdateRequestDefaultClimateSetting defaultClimateSetting = default
            )
            {
                DeviceId = deviceId;
                DefaultClimateSetting = defaultClimateSetting;
            }

            [DataMember(Name = "device_id", IsRequired = true, EmitDefaultValue = false)]
            public string DeviceId { get; set; }

            [DataMember(
                Name = "default_climate_setting",
                IsRequired = true,
                EmitDefaultValue = false
            )]
            public UpdateRequestDefaultClimateSetting DefaultClimateSetting { get; set; }

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

        [DataContract(Name = "updateRequestDefaultClimateSetting_model")]
        public class UpdateRequestDefaultClimateSetting
        {
            [JsonConstructorAttribute]
            protected UpdateRequestDefaultClimateSetting() { }

            public UpdateRequestDefaultClimateSetting(
                bool? automaticHeatingEnabled = default,
                bool? automaticCoolingEnabled = default,
                UpdateRequestDefaultClimateSetting.HvacModeSettingEnum? hvacModeSetting = default,
                float? coolingSetPointCelsius = default,
                float? heatingSetPointCelsius = default,
                float? coolingSetPointFahrenheit = default,
                float? heatingSetPointFahrenheit = default,
                bool? manualOverrideAllowed = default
            )
            {
                AutomaticHeatingEnabled = automaticHeatingEnabled;
                AutomaticCoolingEnabled = automaticCoolingEnabled;
                HvacModeSetting = hvacModeSetting;
                CoolingSetPointCelsius = coolingSetPointCelsius;
                HeatingSetPointCelsius = heatingSetPointCelsius;
                CoolingSetPointFahrenheit = coolingSetPointFahrenheit;
                HeatingSetPointFahrenheit = heatingSetPointFahrenheit;
                ManualOverrideAllowed = manualOverrideAllowed;
            }

            [JsonConverter(typeof(StringEnumConverter))]
            public enum HvacModeSettingEnum
            {
                [EnumMember(Value = "off")]
                Off = 0,

                [EnumMember(Value = "heat")]
                Heat = 1,

                [EnumMember(Value = "cool")]
                Cool = 2,

                [EnumMember(Value = "heat_cool")]
                HeatCool = 3
            }

            [DataMember(
                Name = "automatic_heating_enabled",
                IsRequired = false,
                EmitDefaultValue = false
            )]
            public bool? AutomaticHeatingEnabled { get; set; }

            [DataMember(
                Name = "automatic_cooling_enabled",
                IsRequired = false,
                EmitDefaultValue = false
            )]
            public bool? AutomaticCoolingEnabled { get; set; }

            [DataMember(Name = "hvac_mode_setting", IsRequired = false, EmitDefaultValue = false)]
            public UpdateRequestDefaultClimateSetting.HvacModeSettingEnum? HvacModeSetting { get; set; }

            [DataMember(
                Name = "cooling_set_point_celsius",
                IsRequired = false,
                EmitDefaultValue = false
            )]
            public float? CoolingSetPointCelsius { get; set; }

            [DataMember(
                Name = "heating_set_point_celsius",
                IsRequired = false,
                EmitDefaultValue = false
            )]
            public float? HeatingSetPointCelsius { get; set; }

            [DataMember(
                Name = "cooling_set_point_fahrenheit",
                IsRequired = false,
                EmitDefaultValue = false
            )]
            public float? CoolingSetPointFahrenheit { get; set; }

            [DataMember(
                Name = "heating_set_point_fahrenheit",
                IsRequired = false,
                EmitDefaultValue = false
            )]
            public float? HeatingSetPointFahrenheit { get; set; }

            [DataMember(
                Name = "manual_override_allowed",
                IsRequired = false,
                EmitDefaultValue = false
            )]
            public bool? ManualOverrideAllowed { get; set; }

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
            _seam.Post<object>("/thermostats/update", requestOptions);
        }

        public void Update(
            string deviceId = default,
            UpdateRequestDefaultClimateSetting defaultClimateSetting = default
        )
        {
            Update(
                new UpdateRequest(deviceId: deviceId, defaultClimateSetting: defaultClimateSetting)
            );
        }

        public async Task UpdateAsync(UpdateRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            await _seam.PostAsync<object>("/thermostats/update", requestOptions);
        }

        public async Task UpdateAsync(
            string deviceId = default,
            UpdateRequestDefaultClimateSetting defaultClimateSetting = default
        )
        {
            await UpdateAsync(
                new UpdateRequest(deviceId: deviceId, defaultClimateSetting: defaultClimateSetting)
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
