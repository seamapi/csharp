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
    public class SimulateThermostats
    {
        private ISeamClient _seam;

        public SimulateThermostats(ISeamClient seam)
        {
            _seam = seam;
        }

        [DataContract(Name = "hvacModeAdjustedRequest_request")]
        public class HvacModeAdjustedRequest
        {
            [JsonConstructorAttribute]
            protected HvacModeAdjustedRequest() { }

            public HvacModeAdjustedRequest(
                string deviceId = default,
                HvacModeAdjustedRequest.HvacModeEnum hvacMode = default,
                float? coolingSetPointCelsius = default,
                float? coolingSetPointFahrenheit = default,
                float? heatingSetPointCelsius = default,
                float? heatingSetPointFahrenheit = default
            )
            {
                DeviceId = deviceId;
                HvacMode = hvacMode;
                CoolingSetPointCelsius = coolingSetPointCelsius;
                CoolingSetPointFahrenheit = coolingSetPointFahrenheit;
                HeatingSetPointCelsius = heatingSetPointCelsius;
                HeatingSetPointFahrenheit = heatingSetPointFahrenheit;
            }

            [JsonConverter(typeof(SafeStringEnumConverter))]
            public enum HvacModeEnum
            {
                [EnumMember(Value = "unrecognized")]
                Unrecognized = 0,

                [EnumMember(Value = "heat_cool")]
                HeatCool = 1
            }

            [DataMember(Name = "device_id", IsRequired = true, EmitDefaultValue = false)]
            public string DeviceId { get; set; }

            [DataMember(Name = "hvac_mode", IsRequired = true, EmitDefaultValue = false)]
            public HvacModeAdjustedRequest.HvacModeEnum HvacMode { get; set; }

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

        public void HvacModeAdjusted(HvacModeAdjustedRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            _seam.Post<object>("/thermostats/simulate/hvac_mode_adjusted", requestOptions);
        }

        public void HvacModeAdjusted(
            string deviceId = default,
            HvacModeAdjustedRequest.HvacModeEnum hvacMode = default,
            float? coolingSetPointCelsius = default,
            float? coolingSetPointFahrenheit = default,
            float? heatingSetPointCelsius = default,
            float? heatingSetPointFahrenheit = default
        )
        {
            HvacModeAdjusted(
                new HvacModeAdjustedRequest(
                    deviceId: deviceId,
                    hvacMode: hvacMode,
                    coolingSetPointCelsius: coolingSetPointCelsius,
                    coolingSetPointFahrenheit: coolingSetPointFahrenheit,
                    heatingSetPointCelsius: heatingSetPointCelsius,
                    heatingSetPointFahrenheit: heatingSetPointFahrenheit
                )
            );
        }

        public async Task HvacModeAdjustedAsync(HvacModeAdjustedRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            await _seam.PostAsync<object>(
                "/thermostats/simulate/hvac_mode_adjusted",
                requestOptions
            );
        }

        public async Task HvacModeAdjustedAsync(
            string deviceId = default,
            HvacModeAdjustedRequest.HvacModeEnum hvacMode = default,
            float? coolingSetPointCelsius = default,
            float? coolingSetPointFahrenheit = default,
            float? heatingSetPointCelsius = default,
            float? heatingSetPointFahrenheit = default
        )
        {
            await HvacModeAdjustedAsync(
                new HvacModeAdjustedRequest(
                    deviceId: deviceId,
                    hvacMode: hvacMode,
                    coolingSetPointCelsius: coolingSetPointCelsius,
                    coolingSetPointFahrenheit: coolingSetPointFahrenheit,
                    heatingSetPointCelsius: heatingSetPointCelsius,
                    heatingSetPointFahrenheit: heatingSetPointFahrenheit
                )
            );
        }

        [DataContract(Name = "temperatureReachedRequest_request")]
        public class TemperatureReachedRequest
        {
            [JsonConstructorAttribute]
            protected TemperatureReachedRequest() { }

            public TemperatureReachedRequest(
                string deviceId = default,
                float? temperatureCelsius = default,
                float? temperatureFahrenheit = default
            )
            {
                DeviceId = deviceId;
                TemperatureCelsius = temperatureCelsius;
                TemperatureFahrenheit = temperatureFahrenheit;
            }

            [DataMember(Name = "device_id", IsRequired = true, EmitDefaultValue = false)]
            public string DeviceId { get; set; }

            [DataMember(Name = "temperature_celsius", IsRequired = false, EmitDefaultValue = false)]
            public float? TemperatureCelsius { get; set; }

            [DataMember(
                Name = "temperature_fahrenheit",
                IsRequired = false,
                EmitDefaultValue = false
            )]
            public float? TemperatureFahrenheit { get; set; }

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

        public void TemperatureReached(TemperatureReachedRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            _seam.Post<object>("/thermostats/simulate/temperature_reached", requestOptions);
        }

        public void TemperatureReached(
            string deviceId = default,
            float? temperatureCelsius = default,
            float? temperatureFahrenheit = default
        )
        {
            TemperatureReached(
                new TemperatureReachedRequest(
                    deviceId: deviceId,
                    temperatureCelsius: temperatureCelsius,
                    temperatureFahrenheit: temperatureFahrenheit
                )
            );
        }

        public async Task TemperatureReachedAsync(TemperatureReachedRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            await _seam.PostAsync<object>(
                "/thermostats/simulate/temperature_reached",
                requestOptions
            );
        }

        public async Task TemperatureReachedAsync(
            string deviceId = default,
            float? temperatureCelsius = default,
            float? temperatureFahrenheit = default
        )
        {
            await TemperatureReachedAsync(
                new TemperatureReachedRequest(
                    deviceId: deviceId,
                    temperatureCelsius: temperatureCelsius,
                    temperatureFahrenheit: temperatureFahrenheit
                )
            );
        }
    }
}

namespace Seam.Client
{
    public partial class SeamClient
    {
        public Api.SimulateThermostats SimulateThermostats => new(this);
    }

    public partial interface ISeamClient
    {
        public Api.SimulateThermostats SimulateThermostats { get; }
    }
}
