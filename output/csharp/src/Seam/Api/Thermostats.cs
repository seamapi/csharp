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

            [JsonConverter(typeof(SafeStringEnumConverter))]
            public enum FanModeSettingEnum
            {
                [EnumMember(Value = "unrecognized")]
                Unrecognized = 0,

                [EnumMember(Value = "auto")]
                Auto = 1,

                [EnumMember(Value = "on")]
                On = 2,

                [EnumMember(Value = "circulate")]
                Circulate = 3,
            }

            [JsonConverter(typeof(SafeStringEnumConverter))]
            public enum HvacModeSettingEnum
            {
                [EnumMember(Value = "unrecognized")]
                Unrecognized = 0,

                [EnumMember(Value = "off")]
                Off = 1,

                [EnumMember(Value = "heat")]
                Heat = 2,

                [EnumMember(Value = "cool")]
                Cool = 3,

                [EnumMember(Value = "heat_cool")]
                HeatCool = 4,
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
                ListRequest.DeviceTypeEnum? deviceType = default,
                List<ListRequest.DeviceTypesEnum>? deviceTypes = default,
                List<ListRequest.ExcludeIfEnum>? excludeIf = default,
                List<ListRequest.IncludeIfEnum>? includeIf = default,
                float? limit = default,
                ListRequest.ManufacturerEnum? manufacturer = default,
                string? unstableLocationId = default,
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
                UnstableLocationId = unstableLocationId;
                UserIdentifierKey = userIdentifierKey;
            }

            [JsonConverter(typeof(SafeStringEnumConverter))]
            public enum DeviceTypeEnum
            {
                [EnumMember(Value = "unrecognized")]
                Unrecognized = 0,

                [EnumMember(Value = "ecobee_thermostat")]
                EcobeeThermostat = 1,

                [EnumMember(Value = "nest_thermostat")]
                NestThermostat = 2,

                [EnumMember(Value = "honeywell_resideo_thermostat")]
                HoneywellResideoThermostat = 3,

                [EnumMember(Value = "tado_thermostat")]
                TadoThermostat = 4,

                [EnumMember(Value = "sensi_thermostat")]
                SensiThermostat = 5,
            }

            [JsonConverter(typeof(SafeStringEnumConverter))]
            public enum DeviceTypesEnum
            {
                [EnumMember(Value = "unrecognized")]
                Unrecognized = 0,

                [EnumMember(Value = "ecobee_thermostat")]
                EcobeeThermostat = 1,

                [EnumMember(Value = "nest_thermostat")]
                NestThermostat = 2,

                [EnumMember(Value = "honeywell_resideo_thermostat")]
                HoneywellResideoThermostat = 3,

                [EnumMember(Value = "tado_thermostat")]
                TadoThermostat = 4,

                [EnumMember(Value = "sensi_thermostat")]
                SensiThermostat = 5,
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

                [EnumMember(Value = "ecobee")]
                Ecobee = 1,

                [EnumMember(Value = "nest")]
                Nest = 2,

                [EnumMember(Value = "honeywell_resideo")]
                HoneywellResideo = 3,

                [EnumMember(Value = "tado")]
                Tado = 4,
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
            public ListRequest.DeviceTypeEnum? DeviceType { get; set; }

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
            return _seam.Post<ListResponse>("/thermostats/list", requestOptions).Data.Devices;
        }

        public List<Device> List(
            string? connectWebviewId = default,
            string? connectedAccountId = default,
            List<string>? connectedAccountIds = default,
            string? createdBefore = default,
            object? customMetadataHas = default,
            List<string>? deviceIds = default,
            ListRequest.DeviceTypeEnum? deviceType = default,
            List<ListRequest.DeviceTypesEnum>? deviceTypes = default,
            List<ListRequest.ExcludeIfEnum>? excludeIf = default,
            List<ListRequest.IncludeIfEnum>? includeIf = default,
            float? limit = default,
            ListRequest.ManufacturerEnum? manufacturer = default,
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
                    deviceIds: deviceIds,
                    deviceType: deviceType,
                    deviceTypes: deviceTypes,
                    excludeIf: excludeIf,
                    includeIf: includeIf,
                    limit: limit,
                    manufacturer: manufacturer,
                    unstableLocationId: unstableLocationId,
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
            ListRequest.DeviceTypeEnum? deviceType = default,
            List<ListRequest.DeviceTypesEnum>? deviceTypes = default,
            List<ListRequest.ExcludeIfEnum>? excludeIf = default,
            List<ListRequest.IncludeIfEnum>? includeIf = default,
            float? limit = default,
            ListRequest.ManufacturerEnum? manufacturer = default,
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
                        deviceIds: deviceIds,
                        deviceType: deviceType,
                        deviceTypes: deviceTypes,
                        excludeIf: excludeIf,
                        includeIf: includeIf,
                        limit: limit,
                        manufacturer: manufacturer,
                        unstableLocationId: unstableLocationId,
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

            [JsonConverter(typeof(SafeStringEnumConverter))]
            public enum FanModeEnum
            {
                [EnumMember(Value = "unrecognized")]
                Unrecognized = 0,

                [EnumMember(Value = "auto")]
                Auto = 1,

                [EnumMember(Value = "on")]
                On = 2,

                [EnumMember(Value = "circulate")]
                Circulate = 3,
            }

            [JsonConverter(typeof(SafeStringEnumConverter))]
            public enum FanModeSettingEnum
            {
                [EnumMember(Value = "unrecognized")]
                Unrecognized = 0,

                [EnumMember(Value = "auto")]
                Auto = 1,

                [EnumMember(Value = "on")]
                On = 2,

                [EnumMember(Value = "circulate")]
                Circulate = 3,
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

            [JsonConverter(typeof(SafeStringEnumConverter))]
            public enum HvacModeSettingEnum
            {
                [EnumMember(Value = "unrecognized")]
                Unrecognized = 0,

                [EnumMember(Value = "heat_cool")]
                HeatCool = 1,
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

            [JsonConverter(typeof(SafeStringEnumConverter))]
            public enum FanModeSettingEnum
            {
                [EnumMember(Value = "unrecognized")]
                Unrecognized = 0,

                [EnumMember(Value = "auto")]
                Auto = 1,

                [EnumMember(Value = "on")]
                On = 2,

                [EnumMember(Value = "circulate")]
                Circulate = 3,
            }

            [JsonConverter(typeof(SafeStringEnumConverter))]
            public enum HvacModeSettingEnum
            {
                [EnumMember(Value = "unrecognized")]
                Unrecognized = 0,

                [EnumMember(Value = "off")]
                Off = 1,

                [EnumMember(Value = "heat")]
                Heat = 2,

                [EnumMember(Value = "cool")]
                Cool = 3,

                [EnumMember(Value = "heat_cool")]
                HeatCool = 4,
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
