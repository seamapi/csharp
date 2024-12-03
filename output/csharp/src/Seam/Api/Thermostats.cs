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
    public class Thermostats
    {
        private ISeamClient _seam;

        public Thermostats(ISeamClient seam)
        {
            _seam = seam;
        }

        [DataContract(Name = "activateClimatePresetRequest_request")]
        public class ActivateClimatePresetRequest
        {
            [JsonConstructorAttribute]
            protected ActivateClimatePresetRequest() { }

            public ActivateClimatePresetRequest(
                string climatePresetKey = default,
                string deviceId = default
            )
            {
                ClimatePresetKey = climatePresetKey;
                DeviceId = deviceId;
            }

            [DataMember(Name = "climate_preset_key", IsRequired = true, EmitDefaultValue = false)]
            public string ClimatePresetKey { get; set; }

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

        [DataContract(Name = "activateClimatePresetResponse_response")]
        public class ActivateClimatePresetResponse
        {
            [JsonConstructorAttribute]
            protected ActivateClimatePresetResponse() { }

            public ActivateClimatePresetResponse(ActionAttempt actionAttempt = default)
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

        public ActionAttempt ActivateClimatePreset(ActivateClimatePresetRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            return _seam
                .Post<ActivateClimatePresetResponse>(
                    "/thermostats/activate_climate_preset",
                    requestOptions
                )
                .Data.ActionAttempt;
        }

        public ActionAttempt ActivateClimatePreset(
            string climatePresetKey = default,
            string deviceId = default
        )
        {
            return ActivateClimatePreset(
                new ActivateClimatePresetRequest(
                    climatePresetKey: climatePresetKey,
                    deviceId: deviceId
                )
            );
        }

        public async Task<ActionAttempt> ActivateClimatePresetAsync(
            ActivateClimatePresetRequest request
        )
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            return (
                await _seam.PostAsync<ActivateClimatePresetResponse>(
                    "/thermostats/activate_climate_preset",
                    requestOptions
                )
            )
                .Data
                .ActionAttempt;
        }

        public async Task<ActionAttempt> ActivateClimatePresetAsync(
            string climatePresetKey = default,
            string deviceId = default
        )
        {
            return (
                await ActivateClimatePresetAsync(
                    new ActivateClimatePresetRequest(
                        climatePresetKey: climatePresetKey,
                        deviceId: deviceId
                    )
                )
            );
        }

        [DataContract(Name = "coolRequest_request")]
        public class CoolRequest
        {
            [JsonConstructorAttribute]
            protected CoolRequest() { }

            public CoolRequest(
                float? coolingSetPointCelsius = default,
                float? coolingSetPointFahrenheit = default,
                string deviceId = default,
                bool? sync = default
            )
            {
                CoolingSetPointCelsius = coolingSetPointCelsius;
                CoolingSetPointFahrenheit = coolingSetPointFahrenheit;
                DeviceId = deviceId;
                Sync = sync;
            }

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
            float? coolingSetPointCelsius = default,
            float? coolingSetPointFahrenheit = default,
            string deviceId = default,
            bool? sync = default
        )
        {
            return Cool(
                new CoolRequest(
                    coolingSetPointCelsius: coolingSetPointCelsius,
                    coolingSetPointFahrenheit: coolingSetPointFahrenheit,
                    deviceId: deviceId,
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
            float? coolingSetPointCelsius = default,
            float? coolingSetPointFahrenheit = default,
            string deviceId = default,
            bool? sync = default
        )
        {
            return (
                await CoolAsync(
                    new CoolRequest(
                        coolingSetPointCelsius: coolingSetPointCelsius,
                        coolingSetPointFahrenheit: coolingSetPointFahrenheit,
                        deviceId: deviceId,
                        sync: sync
                    )
                )
            );
        }

        [DataContract(Name = "createClimatePresetRequest_request")]
        public class CreateClimatePresetRequest
        {
            [JsonConstructorAttribute]
            protected CreateClimatePresetRequest() { }

            public CreateClimatePresetRequest(
                string climatePresetKey = default,
                float? coolingSetPointCelsius = default,
                float? coolingSetPointFahrenheit = default,
                string deviceId = default,
                CreateClimatePresetRequest.FanModeSettingEnum? fanModeSetting = default,
                float? heatingSetPointCelsius = default,
                float? heatingSetPointFahrenheit = default,
                CreateClimatePresetRequest.HvacModeSettingEnum? hvacModeSetting = default,
                bool? manualOverrideAllowed = default,
                string? name = default
            )
            {
                ClimatePresetKey = climatePresetKey;
                CoolingSetPointCelsius = coolingSetPointCelsius;
                CoolingSetPointFahrenheit = coolingSetPointFahrenheit;
                DeviceId = deviceId;
                FanModeSetting = fanModeSetting;
                HeatingSetPointCelsius = heatingSetPointCelsius;
                HeatingSetPointFahrenheit = heatingSetPointFahrenheit;
                HvacModeSetting = hvacModeSetting;
                ManualOverrideAllowed = manualOverrideAllowed;
                Name = name;
            }

            [JsonConverter(typeof(StringEnumConverter))]
            public enum FanModeSettingEnum
            {
                [EnumMember(Value = "auto")]
                Auto = 0,

                [EnumMember(Value = "on")]
                On = 1,

                [EnumMember(Value = "circulate")]
                Circulate = 2,
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
                HeatCool = 3,
            }

            [DataMember(Name = "climate_preset_key", IsRequired = true, EmitDefaultValue = false)]
            public string ClimatePresetKey { get; set; }

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

            [DataMember(Name = "device_id", IsRequired = true, EmitDefaultValue = false)]
            public string DeviceId { get; set; }

            [DataMember(Name = "fan_mode_setting", IsRequired = false, EmitDefaultValue = false)]
            public CreateClimatePresetRequest.FanModeSettingEnum? FanModeSetting { get; set; }

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

            [DataMember(Name = "hvac_mode_setting", IsRequired = false, EmitDefaultValue = false)]
            public CreateClimatePresetRequest.HvacModeSettingEnum? HvacModeSetting { get; set; }

            [DataMember(
                Name = "manual_override_allowed",
                IsRequired = false,
                EmitDefaultValue = false
            )]
            public bool? ManualOverrideAllowed { get; set; }

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

        public void CreateClimatePreset(CreateClimatePresetRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            _seam.Post<object>("/thermostats/create_climate_preset", requestOptions);
        }

        public void CreateClimatePreset(
            string climatePresetKey = default,
            float? coolingSetPointCelsius = default,
            float? coolingSetPointFahrenheit = default,
            string deviceId = default,
            CreateClimatePresetRequest.FanModeSettingEnum? fanModeSetting = default,
            float? heatingSetPointCelsius = default,
            float? heatingSetPointFahrenheit = default,
            CreateClimatePresetRequest.HvacModeSettingEnum? hvacModeSetting = default,
            bool? manualOverrideAllowed = default,
            string? name = default
        )
        {
            CreateClimatePreset(
                new CreateClimatePresetRequest(
                    climatePresetKey: climatePresetKey,
                    coolingSetPointCelsius: coolingSetPointCelsius,
                    coolingSetPointFahrenheit: coolingSetPointFahrenheit,
                    deviceId: deviceId,
                    fanModeSetting: fanModeSetting,
                    heatingSetPointCelsius: heatingSetPointCelsius,
                    heatingSetPointFahrenheit: heatingSetPointFahrenheit,
                    hvacModeSetting: hvacModeSetting,
                    manualOverrideAllowed: manualOverrideAllowed,
                    name: name
                )
            );
        }

        public async Task CreateClimatePresetAsync(CreateClimatePresetRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            await _seam.PostAsync<object>("/thermostats/create_climate_preset", requestOptions);
        }

        public async Task CreateClimatePresetAsync(
            string climatePresetKey = default,
            float? coolingSetPointCelsius = default,
            float? coolingSetPointFahrenheit = default,
            string deviceId = default,
            CreateClimatePresetRequest.FanModeSettingEnum? fanModeSetting = default,
            float? heatingSetPointCelsius = default,
            float? heatingSetPointFahrenheit = default,
            CreateClimatePresetRequest.HvacModeSettingEnum? hvacModeSetting = default,
            bool? manualOverrideAllowed = default,
            string? name = default
        )
        {
            await CreateClimatePresetAsync(
                new CreateClimatePresetRequest(
                    climatePresetKey: climatePresetKey,
                    coolingSetPointCelsius: coolingSetPointCelsius,
                    coolingSetPointFahrenheit: coolingSetPointFahrenheit,
                    deviceId: deviceId,
                    fanModeSetting: fanModeSetting,
                    heatingSetPointCelsius: heatingSetPointCelsius,
                    heatingSetPointFahrenheit: heatingSetPointFahrenheit,
                    hvacModeSetting: hvacModeSetting,
                    manualOverrideAllowed: manualOverrideAllowed,
                    name: name
                )
            );
        }

        [DataContract(Name = "deleteClimatePresetRequest_request")]
        public class DeleteClimatePresetRequest
        {
            [JsonConstructorAttribute]
            protected DeleteClimatePresetRequest() { }

            public DeleteClimatePresetRequest(
                string climatePresetKey = default,
                string deviceId = default
            )
            {
                ClimatePresetKey = climatePresetKey;
                DeviceId = deviceId;
            }

            [DataMember(Name = "climate_preset_key", IsRequired = true, EmitDefaultValue = false)]
            public string ClimatePresetKey { get; set; }

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

        public void DeleteClimatePreset(DeleteClimatePresetRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            _seam.Post<object>("/thermostats/delete_climate_preset", requestOptions);
        }

        public void DeleteClimatePreset(
            string climatePresetKey = default,
            string deviceId = default
        )
        {
            DeleteClimatePreset(
                new DeleteClimatePresetRequest(
                    climatePresetKey: climatePresetKey,
                    deviceId: deviceId
                )
            );
        }

        public async Task DeleteClimatePresetAsync(DeleteClimatePresetRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            await _seam.PostAsync<object>("/thermostats/delete_climate_preset", requestOptions);
        }

        public async Task DeleteClimatePresetAsync(
            string climatePresetKey = default,
            string deviceId = default
        )
        {
            await DeleteClimatePresetAsync(
                new DeleteClimatePresetRequest(
                    climatePresetKey: climatePresetKey,
                    deviceId: deviceId
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
                float? coolingSetPointCelsius = default,
                float? coolingSetPointFahrenheit = default,
                string deviceId = default,
                float? heatingSetPointCelsius = default,
                float? heatingSetPointFahrenheit = default,
                bool? sync = default
            )
            {
                CoolingSetPointCelsius = coolingSetPointCelsius;
                CoolingSetPointFahrenheit = coolingSetPointFahrenheit;
                DeviceId = deviceId;
                HeatingSetPointCelsius = heatingSetPointCelsius;
                HeatingSetPointFahrenheit = heatingSetPointFahrenheit;
                Sync = sync;
            }

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
            float? coolingSetPointCelsius = default,
            float? coolingSetPointFahrenheit = default,
            string deviceId = default,
            float? heatingSetPointCelsius = default,
            float? heatingSetPointFahrenheit = default,
            bool? sync = default
        )
        {
            return HeatCool(
                new HeatCoolRequest(
                    coolingSetPointCelsius: coolingSetPointCelsius,
                    coolingSetPointFahrenheit: coolingSetPointFahrenheit,
                    deviceId: deviceId,
                    heatingSetPointCelsius: heatingSetPointCelsius,
                    heatingSetPointFahrenheit: heatingSetPointFahrenheit,
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
            float? coolingSetPointCelsius = default,
            float? coolingSetPointFahrenheit = default,
            string deviceId = default,
            float? heatingSetPointCelsius = default,
            float? heatingSetPointFahrenheit = default,
            bool? sync = default
        )
        {
            return (
                await HeatCoolAsync(
                    new HeatCoolRequest(
                        coolingSetPointCelsius: coolingSetPointCelsius,
                        coolingSetPointFahrenheit: coolingSetPointFahrenheit,
                        deviceId: deviceId,
                        heatingSetPointCelsius: heatingSetPointCelsius,
                        heatingSetPointFahrenheit: heatingSetPointFahrenheit,
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

                [EnumMember(Value = "akiles_lock")]
                AkilesLock = 26,

                [EnumMember(Value = "noiseaware_activity_zone")]
                NoiseawareActivityZone = 27,

                [EnumMember(Value = "minut_sensor")]
                MinutSensor = 28,

                [EnumMember(Value = "ecobee_thermostat")]
                EcobeeThermostat = 29,

                [EnumMember(Value = "nest_thermostat")]
                NestThermostat = 30,

                [EnumMember(Value = "honeywell_resideo_thermostat")]
                HoneywellResideoThermostat = 31,

                [EnumMember(Value = "ios_phone")]
                IosPhone = 32,

                [EnumMember(Value = "android_phone")]
                AndroidPhone = 33,
            }

            [JsonConverter(typeof(StringEnumConverter))]
            public enum ExcludeIfEnum
            {
                [EnumMember(Value = "can_remotely_unlock")]
                CanRemotelyUnlock = 0,

                [EnumMember(Value = "can_remotely_lock")]
                CanRemotelyLock = 1,

                [EnumMember(Value = "can_program_offline_access_codes")]
                CanProgramOfflineAccessCodes = 2,

                [EnumMember(Value = "can_program_online_access_codes")]
                CanProgramOnlineAccessCodes = 3,

                [EnumMember(Value = "can_hvac_heat")]
                CanHvacHeat = 4,

                [EnumMember(Value = "can_hvac_cool")]
                CanHvacCool = 5,

                [EnumMember(Value = "can_hvac_heat_cool")]
                CanHvacHeatCool = 6,

                [EnumMember(Value = "can_turn_off_hvac")]
                CanTurnOffHvac = 7,

                [EnumMember(Value = "can_simulate_removal")]
                CanSimulateRemoval = 8,

                [EnumMember(Value = "can_simulate_connection")]
                CanSimulateConnection = 9,

                [EnumMember(Value = "can_simulate_disconnection")]
                CanSimulateDisconnection = 10,
            }

            [JsonConverter(typeof(StringEnumConverter))]
            public enum IncludeIfEnum
            {
                [EnumMember(Value = "can_remotely_unlock")]
                CanRemotelyUnlock = 0,

                [EnumMember(Value = "can_remotely_lock")]
                CanRemotelyLock = 1,

                [EnumMember(Value = "can_program_offline_access_codes")]
                CanProgramOfflineAccessCodes = 2,

                [EnumMember(Value = "can_program_online_access_codes")]
                CanProgramOnlineAccessCodes = 3,

                [EnumMember(Value = "can_hvac_heat")]
                CanHvacHeat = 4,

                [EnumMember(Value = "can_hvac_cool")]
                CanHvacCool = 5,

                [EnumMember(Value = "can_hvac_heat_cool")]
                CanHvacHeatCool = 6,

                [EnumMember(Value = "can_turn_off_hvac")]
                CanTurnOffHvac = 7,

                [EnumMember(Value = "can_simulate_removal")]
                CanSimulateRemoval = 8,

                [EnumMember(Value = "can_simulate_connection")]
                CanSimulateConnection = 9,

                [EnumMember(Value = "can_simulate_disconnection")]
                CanSimulateDisconnection = 10,
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
                HoneywellResideo = 33,

                [EnumMember(Value = "akiles")]
                Akiles = 34,
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
            return _seam.Post<ListResponse>("/thermostats/list", requestOptions).Data.Devices;
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
            return (await _seam.PostAsync<ListResponse>("/thermostats/list", requestOptions))
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

        [DataContract(Name = "setFallbackClimatePresetRequest_request")]
        public class SetFallbackClimatePresetRequest
        {
            [JsonConstructorAttribute]
            protected SetFallbackClimatePresetRequest() { }

            public SetFallbackClimatePresetRequest(
                string climatePresetKey = default,
                string deviceId = default
            )
            {
                ClimatePresetKey = climatePresetKey;
                DeviceId = deviceId;
            }

            [DataMember(Name = "climate_preset_key", IsRequired = true, EmitDefaultValue = false)]
            public string ClimatePresetKey { get; set; }

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

        public void SetFallbackClimatePreset(SetFallbackClimatePresetRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            _seam.Post<object>("/thermostats/set_fallback_climate_preset", requestOptions);
        }

        public void SetFallbackClimatePreset(
            string climatePresetKey = default,
            string deviceId = default
        )
        {
            SetFallbackClimatePreset(
                new SetFallbackClimatePresetRequest(
                    climatePresetKey: climatePresetKey,
                    deviceId: deviceId
                )
            );
        }

        public async Task SetFallbackClimatePresetAsync(SetFallbackClimatePresetRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            await _seam.PostAsync<object>(
                "/thermostats/set_fallback_climate_preset",
                requestOptions
            );
        }

        public async Task SetFallbackClimatePresetAsync(
            string climatePresetKey = default,
            string deviceId = default
        )
        {
            await SetFallbackClimatePresetAsync(
                new SetFallbackClimatePresetRequest(
                    climatePresetKey: climatePresetKey,
                    deviceId: deviceId
                )
            );
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
                On = 1,

                [EnumMember(Value = "circulate")]
                Circulate = 2,
            }

            [JsonConverter(typeof(StringEnumConverter))]
            public enum FanModeSettingEnum
            {
                [EnumMember(Value = "auto")]
                Auto = 0,

                [EnumMember(Value = "on")]
                On = 1,

                [EnumMember(Value = "circulate")]
                Circulate = 2,
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

        [DataContract(Name = "setHvacModeRequest_request")]
        public class SetHvacModeRequest
        {
            [JsonConstructorAttribute]
            protected SetHvacModeRequest() { }

            public SetHvacModeRequest(
                string deviceId = default,
                SetHvacModeRequest.HvacModeSettingEnum hvacModeSetting = default,
                float? coolingSetPointCelsius = default,
                float? coolingSetPointFahrenheit = default,
                float? heatingSetPointCelsius = default,
                float? heatingSetPointFahrenheit = default
            )
            {
                DeviceId = deviceId;
                HvacModeSetting = hvacModeSetting;
                CoolingSetPointCelsius = coolingSetPointCelsius;
                CoolingSetPointFahrenheit = coolingSetPointFahrenheit;
                HeatingSetPointCelsius = heatingSetPointCelsius;
                HeatingSetPointFahrenheit = heatingSetPointFahrenheit;
            }

            [JsonConverter(typeof(StringEnumConverter))]
            public enum HvacModeSettingEnum
            {
                [EnumMember(Value = "heat_cool")]
                HeatCool = 0,
            }

            [DataMember(Name = "device_id", IsRequired = true, EmitDefaultValue = false)]
            public string DeviceId { get; set; }

            [DataMember(Name = "hvac_mode_setting", IsRequired = true, EmitDefaultValue = false)]
            public SetHvacModeRequest.HvacModeSettingEnum HvacModeSetting { get; set; }

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

        [DataContract(Name = "setHvacModeResponse_response")]
        public class SetHvacModeResponse
        {
            [JsonConstructorAttribute]
            protected SetHvacModeResponse() { }

            public SetHvacModeResponse(ActionAttempt actionAttempt = default)
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

        public ActionAttempt SetHvacMode(SetHvacModeRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            return _seam
                .Post<SetHvacModeResponse>("/thermostats/set_hvac_mode", requestOptions)
                .Data.ActionAttempt;
        }

        public ActionAttempt SetHvacMode(
            string deviceId = default,
            SetHvacModeRequest.HvacModeSettingEnum hvacModeSetting = default,
            float? coolingSetPointCelsius = default,
            float? coolingSetPointFahrenheit = default,
            float? heatingSetPointCelsius = default,
            float? heatingSetPointFahrenheit = default
        )
        {
            return SetHvacMode(
                new SetHvacModeRequest(
                    deviceId: deviceId,
                    hvacModeSetting: hvacModeSetting,
                    coolingSetPointCelsius: coolingSetPointCelsius,
                    coolingSetPointFahrenheit: coolingSetPointFahrenheit,
                    heatingSetPointCelsius: heatingSetPointCelsius,
                    heatingSetPointFahrenheit: heatingSetPointFahrenheit
                )
            );
        }

        public async Task<ActionAttempt> SetHvacModeAsync(SetHvacModeRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            return (
                await _seam.PostAsync<SetHvacModeResponse>(
                    "/thermostats/set_hvac_mode",
                    requestOptions
                )
            )
                .Data
                .ActionAttempt;
        }

        public async Task<ActionAttempt> SetHvacModeAsync(
            string deviceId = default,
            SetHvacModeRequest.HvacModeSettingEnum hvacModeSetting = default,
            float? coolingSetPointCelsius = default,
            float? coolingSetPointFahrenheit = default,
            float? heatingSetPointCelsius = default,
            float? heatingSetPointFahrenheit = default
        )
        {
            return (
                await SetHvacModeAsync(
                    new SetHvacModeRequest(
                        deviceId: deviceId,
                        hvacModeSetting: hvacModeSetting,
                        coolingSetPointCelsius: coolingSetPointCelsius,
                        coolingSetPointFahrenheit: coolingSetPointFahrenheit,
                        heatingSetPointCelsius: heatingSetPointCelsius,
                        heatingSetPointFahrenheit: heatingSetPointFahrenheit
                    )
                )
            );
        }

        [DataContract(Name = "setTemperatureThresholdRequest_request")]
        public class SetTemperatureThresholdRequest
        {
            [JsonConstructorAttribute]
            protected SetTemperatureThresholdRequest() { }

            public SetTemperatureThresholdRequest(
                string deviceId = default,
                float? lowerLimitCelsius = default,
                float? lowerLimitFahrenheit = default,
                float? upperLimitCelsius = default,
                float? upperLimitFahrenheit = default
            )
            {
                DeviceId = deviceId;
                LowerLimitCelsius = lowerLimitCelsius;
                LowerLimitFahrenheit = lowerLimitFahrenheit;
                UpperLimitCelsius = upperLimitCelsius;
                UpperLimitFahrenheit = upperLimitFahrenheit;
            }

            [DataMember(Name = "device_id", IsRequired = true, EmitDefaultValue = false)]
            public string DeviceId { get; set; }

            [DataMember(Name = "lower_limit_celsius", IsRequired = false, EmitDefaultValue = false)]
            public float? LowerLimitCelsius { get; set; }

            [DataMember(
                Name = "lower_limit_fahrenheit",
                IsRequired = false,
                EmitDefaultValue = false
            )]
            public float? LowerLimitFahrenheit { get; set; }

            [DataMember(Name = "upper_limit_celsius", IsRequired = false, EmitDefaultValue = false)]
            public float? UpperLimitCelsius { get; set; }

            [DataMember(
                Name = "upper_limit_fahrenheit",
                IsRequired = false,
                EmitDefaultValue = false
            )]
            public float? UpperLimitFahrenheit { get; set; }

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

        public void SetTemperatureThreshold(SetTemperatureThresholdRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            _seam.Post<object>("/thermostats/set_temperature_threshold", requestOptions);
        }

        public void SetTemperatureThreshold(
            string deviceId = default,
            float? lowerLimitCelsius = default,
            float? lowerLimitFahrenheit = default,
            float? upperLimitCelsius = default,
            float? upperLimitFahrenheit = default
        )
        {
            SetTemperatureThreshold(
                new SetTemperatureThresholdRequest(
                    deviceId: deviceId,
                    lowerLimitCelsius: lowerLimitCelsius,
                    lowerLimitFahrenheit: lowerLimitFahrenheit,
                    upperLimitCelsius: upperLimitCelsius,
                    upperLimitFahrenheit: upperLimitFahrenheit
                )
            );
        }

        public async Task SetTemperatureThresholdAsync(SetTemperatureThresholdRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            await _seam.PostAsync<object>("/thermostats/set_temperature_threshold", requestOptions);
        }

        public async Task SetTemperatureThresholdAsync(
            string deviceId = default,
            float? lowerLimitCelsius = default,
            float? lowerLimitFahrenheit = default,
            float? upperLimitCelsius = default,
            float? upperLimitFahrenheit = default
        )
        {
            await SetTemperatureThresholdAsync(
                new SetTemperatureThresholdRequest(
                    deviceId: deviceId,
                    lowerLimitCelsius: lowerLimitCelsius,
                    lowerLimitFahrenheit: lowerLimitFahrenheit,
                    upperLimitCelsius: upperLimitCelsius,
                    upperLimitFahrenheit: upperLimitFahrenheit
                )
            );
        }

        [DataContract(Name = "updateClimatePresetRequest_request")]
        public class UpdateClimatePresetRequest
        {
            [JsonConstructorAttribute]
            protected UpdateClimatePresetRequest() { }

            public UpdateClimatePresetRequest(
                string climatePresetKey = default,
                float? coolingSetPointCelsius = default,
                float? coolingSetPointFahrenheit = default,
                string deviceId = default,
                UpdateClimatePresetRequest.FanModeSettingEnum? fanModeSetting = default,
                float? heatingSetPointCelsius = default,
                float? heatingSetPointFahrenheit = default,
                UpdateClimatePresetRequest.HvacModeSettingEnum? hvacModeSetting = default,
                bool manualOverrideAllowed = default,
                string? name = default
            )
            {
                ClimatePresetKey = climatePresetKey;
                CoolingSetPointCelsius = coolingSetPointCelsius;
                CoolingSetPointFahrenheit = coolingSetPointFahrenheit;
                DeviceId = deviceId;
                FanModeSetting = fanModeSetting;
                HeatingSetPointCelsius = heatingSetPointCelsius;
                HeatingSetPointFahrenheit = heatingSetPointFahrenheit;
                HvacModeSetting = hvacModeSetting;
                ManualOverrideAllowed = manualOverrideAllowed;
                Name = name;
            }

            [JsonConverter(typeof(StringEnumConverter))]
            public enum FanModeSettingEnum
            {
                [EnumMember(Value = "auto")]
                Auto = 0,

                [EnumMember(Value = "on")]
                On = 1,

                [EnumMember(Value = "circulate")]
                Circulate = 2,
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
                HeatCool = 3,
            }

            [DataMember(Name = "climate_preset_key", IsRequired = true, EmitDefaultValue = false)]
            public string ClimatePresetKey { get; set; }

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

            [DataMember(Name = "device_id", IsRequired = true, EmitDefaultValue = false)]
            public string DeviceId { get; set; }

            [DataMember(Name = "fan_mode_setting", IsRequired = false, EmitDefaultValue = false)]
            public UpdateClimatePresetRequest.FanModeSettingEnum? FanModeSetting { get; set; }

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

            [DataMember(Name = "hvac_mode_setting", IsRequired = false, EmitDefaultValue = false)]
            public UpdateClimatePresetRequest.HvacModeSettingEnum? HvacModeSetting { get; set; }

            [DataMember(
                Name = "manual_override_allowed",
                IsRequired = true,
                EmitDefaultValue = false
            )]
            public bool ManualOverrideAllowed { get; set; }

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

        public void UpdateClimatePreset(UpdateClimatePresetRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            _seam.Post<object>("/thermostats/update_climate_preset", requestOptions);
        }

        public void UpdateClimatePreset(
            string climatePresetKey = default,
            float? coolingSetPointCelsius = default,
            float? coolingSetPointFahrenheit = default,
            string deviceId = default,
            UpdateClimatePresetRequest.FanModeSettingEnum? fanModeSetting = default,
            float? heatingSetPointCelsius = default,
            float? heatingSetPointFahrenheit = default,
            UpdateClimatePresetRequest.HvacModeSettingEnum? hvacModeSetting = default,
            bool manualOverrideAllowed = default,
            string? name = default
        )
        {
            UpdateClimatePreset(
                new UpdateClimatePresetRequest(
                    climatePresetKey: climatePresetKey,
                    coolingSetPointCelsius: coolingSetPointCelsius,
                    coolingSetPointFahrenheit: coolingSetPointFahrenheit,
                    deviceId: deviceId,
                    fanModeSetting: fanModeSetting,
                    heatingSetPointCelsius: heatingSetPointCelsius,
                    heatingSetPointFahrenheit: heatingSetPointFahrenheit,
                    hvacModeSetting: hvacModeSetting,
                    manualOverrideAllowed: manualOverrideAllowed,
                    name: name
                )
            );
        }

        public async Task UpdateClimatePresetAsync(UpdateClimatePresetRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            await _seam.PostAsync<object>("/thermostats/update_climate_preset", requestOptions);
        }

        public async Task UpdateClimatePresetAsync(
            string climatePresetKey = default,
            float? coolingSetPointCelsius = default,
            float? coolingSetPointFahrenheit = default,
            string deviceId = default,
            UpdateClimatePresetRequest.FanModeSettingEnum? fanModeSetting = default,
            float? heatingSetPointCelsius = default,
            float? heatingSetPointFahrenheit = default,
            UpdateClimatePresetRequest.HvacModeSettingEnum? hvacModeSetting = default,
            bool manualOverrideAllowed = default,
            string? name = default
        )
        {
            await UpdateClimatePresetAsync(
                new UpdateClimatePresetRequest(
                    climatePresetKey: climatePresetKey,
                    coolingSetPointCelsius: coolingSetPointCelsius,
                    coolingSetPointFahrenheit: coolingSetPointFahrenheit,
                    deviceId: deviceId,
                    fanModeSetting: fanModeSetting,
                    heatingSetPointCelsius: heatingSetPointCelsius,
                    heatingSetPointFahrenheit: heatingSetPointFahrenheit,
                    hvacModeSetting: hvacModeSetting,
                    manualOverrideAllowed: manualOverrideAllowed,
                    name: name
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
