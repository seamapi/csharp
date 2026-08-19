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
    public class SimulateNoiseSensors
    {
        private ISeamClient _seam;

        public SimulateNoiseSensors(ISeamClient seam)
        {
            _seam = seam;
        }

        /// <summary>
        /// Request parameters for Simulate Triggering a Noise Threshold.
        /// </summary>
        [DataContract(Name = "triggerNoiseThresholdRequest_request")]
        public class TriggerNoiseThresholdRequest
        {
            [JsonConstructorAttribute]
            protected TriggerNoiseThresholdRequest() { }

            public TriggerNoiseThresholdRequest(string deviceId = default)
            {
                DeviceId = deviceId;
            }

            /// <summary>
            /// ID of the device for which you want to simulate the triggering of a noise threshold.
            /// </summary>
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

        /// <summary>
        /// Simulates the triggering of a [noise threshold](https://docs.seam.co/capability-guides/noise-sensors/configure-noise-threshold-settings) for a [noise sensor](https://docs.seam.co/capability-guides/noise-sensors) in a [sandbox workspace](https://docs.seam.co/core-concepts/workspaces#sandbox-workspaces).
        /// </summary>
        public void TriggerNoiseThreshold(TriggerNoiseThresholdRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            _seam.Post<object>("/noise_sensors/simulate/trigger_noise_threshold", requestOptions);
        }

        /// <summary>
        /// Simulates the triggering of a [noise threshold](https://docs.seam.co/capability-guides/noise-sensors/configure-noise-threshold-settings) for a [noise sensor](https://docs.seam.co/capability-guides/noise-sensors) in a [sandbox workspace](https://docs.seam.co/core-concepts/workspaces#sandbox-workspaces).
        /// </summary>
        public void TriggerNoiseThreshold(string deviceId = default)
        {
            TriggerNoiseThreshold(new TriggerNoiseThresholdRequest(deviceId: deviceId));
        }

        /// <summary>
        /// Simulates the triggering of a [noise threshold](https://docs.seam.co/capability-guides/noise-sensors/configure-noise-threshold-settings) for a [noise sensor](https://docs.seam.co/capability-guides/noise-sensors) in a [sandbox workspace](https://docs.seam.co/core-concepts/workspaces#sandbox-workspaces).
        /// </summary>
        public async Task TriggerNoiseThresholdAsync(TriggerNoiseThresholdRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            await _seam.PostAsync<object>(
                "/noise_sensors/simulate/trigger_noise_threshold",
                requestOptions
            );
        }

        /// <summary>
        /// Simulates the triggering of a [noise threshold](https://docs.seam.co/capability-guides/noise-sensors/configure-noise-threshold-settings) for a [noise sensor](https://docs.seam.co/capability-guides/noise-sensors) in a [sandbox workspace](https://docs.seam.co/core-concepts/workspaces#sandbox-workspaces).
        /// </summary>
        public async Task TriggerNoiseThresholdAsync(string deviceId = default)
        {
            await TriggerNoiseThresholdAsync(new TriggerNoiseThresholdRequest(deviceId: deviceId));
        }
    }
}

namespace Seam.Client
{
    public partial class SeamClient
    {
        public Api.SimulateNoiseSensors SimulateNoiseSensors => new(this);
    }

    public partial interface ISeamClient
    {
        public Api.SimulateNoiseSensors SimulateNoiseSensors { get; }
    }
}
