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

        /// <summary>
        /// Request parameters for HVAC Mode Adjusted.
        /// </summary>
        [DataContract(Name = "hvacModeAdjustedRequest_request")]
        public class HvacModeAdjustedRequest
        {
            [JsonConstructorAttribute]
            protected HvacModeAdjustedRequest() { }

            public HvacModeAdjustedRequest(
                float? coolingSetPointCelsius = default,
                float? coolingSetPointFahrenheit = default,
                string deviceId = default,
                float? heatingSetPointCelsius = default,
                float? heatingSetPointFahrenheit = default,
                HvacModeAdjustedRequest.HvacModeEnum hvacMode = default
            )
            {
                CoolingSetPointCelsius = coolingSetPointCelsius;
                CoolingSetPointFahrenheit = coolingSetPointFahrenheit;
                DeviceId = deviceId;
                HeatingSetPointCelsius = heatingSetPointCelsius;
                HeatingSetPointFahrenheit = heatingSetPointFahrenheit;
                HvacMode = hvacMode;
            }

            /// <summary>
            /// HVAC mode that you want to simulate.
            /// </summary>
            [JsonConverter(typeof(SafeStringEnumConverter))]
            public enum HvacModeEnum
            {
                [EnumMember(Value = "unrecognized")]
                Unrecognized = 0,

                [EnumMember(Value = "off")]
                Off = 1,

                [EnumMember(Value = "cool")]
                Cool = 2,

                [EnumMember(Value = "heat")]
                Heat = 3,

                [EnumMember(Value = "heat_cool")]
                HeatCool = 4,
            }

            /// <summary>
            /// Cooling [set point](https://docs.seam.co/capability-guides/thermostats/understanding-thermostat-concepts/set-points) in °C that you want to simulate. You must set `cooling_set_point_celsius` or `cooling_set_point_fahrenheit`.
            /// </summary>
            [DataMember(
                Name = "cooling_set_point_celsius",
                IsRequired = false,
                EmitDefaultValue = false
            )]
            public float? CoolingSetPointCelsius { get; set; }

            /// <summary>
            /// Cooling [set point](https://docs.seam.co/capability-guides/thermostats/understanding-thermostat-concepts/set-points) in °F that you want to simulate. You must set `cooling_set_point_fahrenheit` or `cooling_set_point_celsius`.
            /// </summary>
            [DataMember(
                Name = "cooling_set_point_fahrenheit",
                IsRequired = false,
                EmitDefaultValue = false
            )]
            public float? CoolingSetPointFahrenheit { get; set; }

            /// <summary>
            /// ID of the thermostat device for which you want to simulate having adjusted the HVAC mode.
            /// </summary>
            [DataMember(Name = "device_id", IsRequired = true, EmitDefaultValue = false)]
            public string DeviceId { get; set; }

            /// <summary>
            /// Heating [set point](https://docs.seam.co/capability-guides/thermostats/understanding-thermostat-concepts/set-points) in °C that you want to simulate. You must set `heating_set_point_celsius` or `heating_set_point_fahrenheit`.
            /// </summary>
            [DataMember(
                Name = "heating_set_point_celsius",
                IsRequired = false,
                EmitDefaultValue = false
            )]
            public float? HeatingSetPointCelsius { get; set; }

            /// <summary>
            /// Heating [set point](https://docs.seam.co/capability-guides/thermostats/understanding-thermostat-concepts/set-points) in °F that you want to simulate. You must set `heating_set_point_fahrenheit` or `heating_set_point_celsius`.
            /// </summary>
            [DataMember(
                Name = "heating_set_point_fahrenheit",
                IsRequired = false,
                EmitDefaultValue = false
            )]
            public float? HeatingSetPointFahrenheit { get; set; }

            /// <summary>
            /// HVAC mode that you want to simulate.
            /// </summary>
            [DataMember(Name = "hvac_mode", IsRequired = true, EmitDefaultValue = false)]
            public HvacModeAdjustedRequest.HvacModeEnum HvacMode { get; set; }

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
        /// Simulates having adjusted the [HVAC mode](https://docs.seam.co/capability-guides/thermostats/understanding-thermostat-concepts/hvac-mode) for a [thermostat](https://docs.seam.co/capability-guides/thermostats). Only applicable for [sandbox devices](https://docs.seam.co/core-concepts/workspaces#sandbox-workspaces). See also [Testing Your Thermostat App with Simulate Endpoints](https://docs.seam.co/capability-guides/thermostats/testing-your-thermostat-app-with-simulate-endpoints).
        /// </summary>
        public void HvacModeAdjusted(HvacModeAdjustedRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            _seam.Post<object>("/thermostats/simulate/hvac_mode_adjusted", requestOptions);
        }

        /// <summary>
        /// Simulates having adjusted the [HVAC mode](https://docs.seam.co/capability-guides/thermostats/understanding-thermostat-concepts/hvac-mode) for a [thermostat](https://docs.seam.co/capability-guides/thermostats). Only applicable for [sandbox devices](https://docs.seam.co/core-concepts/workspaces#sandbox-workspaces). See also [Testing Your Thermostat App with Simulate Endpoints](https://docs.seam.co/capability-guides/thermostats/testing-your-thermostat-app-with-simulate-endpoints).
        /// </summary>
        public void HvacModeAdjusted(
            float? coolingSetPointCelsius = default,
            float? coolingSetPointFahrenheit = default,
            string deviceId = default,
            float? heatingSetPointCelsius = default,
            float? heatingSetPointFahrenheit = default,
            HvacModeAdjustedRequest.HvacModeEnum hvacMode = default
        )
        {
            HvacModeAdjusted(
                new HvacModeAdjustedRequest(
                    coolingSetPointCelsius: coolingSetPointCelsius,
                    coolingSetPointFahrenheit: coolingSetPointFahrenheit,
                    deviceId: deviceId,
                    heatingSetPointCelsius: heatingSetPointCelsius,
                    heatingSetPointFahrenheit: heatingSetPointFahrenheit,
                    hvacMode: hvacMode
                )
            );
        }

        /// <summary>
        /// Simulates having adjusted the [HVAC mode](https://docs.seam.co/capability-guides/thermostats/understanding-thermostat-concepts/hvac-mode) for a [thermostat](https://docs.seam.co/capability-guides/thermostats). Only applicable for [sandbox devices](https://docs.seam.co/core-concepts/workspaces#sandbox-workspaces). See also [Testing Your Thermostat App with Simulate Endpoints](https://docs.seam.co/capability-guides/thermostats/testing-your-thermostat-app-with-simulate-endpoints).
        /// </summary>
        public async Task HvacModeAdjustedAsync(HvacModeAdjustedRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            await _seam.PostAsync<object>(
                "/thermostats/simulate/hvac_mode_adjusted",
                requestOptions
            );
        }

        /// <summary>
        /// Simulates having adjusted the [HVAC mode](https://docs.seam.co/capability-guides/thermostats/understanding-thermostat-concepts/hvac-mode) for a [thermostat](https://docs.seam.co/capability-guides/thermostats). Only applicable for [sandbox devices](https://docs.seam.co/core-concepts/workspaces#sandbox-workspaces). See also [Testing Your Thermostat App with Simulate Endpoints](https://docs.seam.co/capability-guides/thermostats/testing-your-thermostat-app-with-simulate-endpoints).
        /// </summary>
        public async Task HvacModeAdjustedAsync(
            float? coolingSetPointCelsius = default,
            float? coolingSetPointFahrenheit = default,
            string deviceId = default,
            float? heatingSetPointCelsius = default,
            float? heatingSetPointFahrenheit = default,
            HvacModeAdjustedRequest.HvacModeEnum hvacMode = default
        )
        {
            await HvacModeAdjustedAsync(
                new HvacModeAdjustedRequest(
                    coolingSetPointCelsius: coolingSetPointCelsius,
                    coolingSetPointFahrenheit: coolingSetPointFahrenheit,
                    deviceId: deviceId,
                    heatingSetPointCelsius: heatingSetPointCelsius,
                    heatingSetPointFahrenheit: heatingSetPointFahrenheit,
                    hvacMode: hvacMode
                )
            );
        }

        /// <summary>
        /// Request parameters for Temperature Reached.
        /// </summary>
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

            /// <summary>
            /// ID of the thermostat device that you want to simulate reaching a specified temperature.
            /// </summary>
            [DataMember(Name = "device_id", IsRequired = true, EmitDefaultValue = false)]
            public string DeviceId { get; set; }

            /// <summary>
            /// Temperature in °C that you want simulate the thermostat reaching. You must set `temperature_celsius` or `temperature_fahrenheit`.
            /// </summary>
            [DataMember(Name = "temperature_celsius", IsRequired = false, EmitDefaultValue = false)]
            public float? TemperatureCelsius { get; set; }

            /// <summary>
            /// Temperature in °F that you want simulate the thermostat reaching. You must set `temperature_fahrenheit` or `temperature_celsius`.
            /// </summary>
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

        /// <summary>
        /// Simulates a [thermostat](https://docs.seam.co/capability-guides/thermostats) reaching a specified temperature. Only applicable for [sandbox devices](https://docs.seam.co/core-concepts/workspaces#sandbox-workspaces). See also [Testing Your Thermostat App with Simulate Endpoints](https://docs.seam.co/capability-guides/thermostats/testing-your-thermostat-app-with-simulate-endpoints).
        /// </summary>
        public void TemperatureReached(TemperatureReachedRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            _seam.Post<object>("/thermostats/simulate/temperature_reached", requestOptions);
        }

        /// <summary>
        /// Simulates a [thermostat](https://docs.seam.co/capability-guides/thermostats) reaching a specified temperature. Only applicable for [sandbox devices](https://docs.seam.co/core-concepts/workspaces#sandbox-workspaces). See also [Testing Your Thermostat App with Simulate Endpoints](https://docs.seam.co/capability-guides/thermostats/testing-your-thermostat-app-with-simulate-endpoints).
        /// </summary>
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

        /// <summary>
        /// Simulates a [thermostat](https://docs.seam.co/capability-guides/thermostats) reaching a specified temperature. Only applicable for [sandbox devices](https://docs.seam.co/core-concepts/workspaces#sandbox-workspaces). See also [Testing Your Thermostat App with Simulate Endpoints](https://docs.seam.co/capability-guides/thermostats/testing-your-thermostat-app-with-simulate-endpoints).
        /// </summary>
        public async Task TemperatureReachedAsync(TemperatureReachedRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            await _seam.PostAsync<object>(
                "/thermostats/simulate/temperature_reached",
                requestOptions
            );
        }

        /// <summary>
        /// Simulates a [thermostat](https://docs.seam.co/capability-guides/thermostats) reaching a specified temperature. Only applicable for [sandbox devices](https://docs.seam.co/core-concepts/workspaces#sandbox-workspaces). See also [Testing Your Thermostat App with Simulate Endpoints](https://docs.seam.co/capability-guides/thermostats/testing-your-thermostat-app-with-simulate-endpoints).
        /// </summary>
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
