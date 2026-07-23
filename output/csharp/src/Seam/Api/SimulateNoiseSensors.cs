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

        [DataContract(Name = "triggerNoiseThresholdRequest_request")]
        public class TriggerNoiseThresholdRequest
        {
            [JsonConstructorAttribute]
            protected TriggerNoiseThresholdRequest() { }

            public TriggerNoiseThresholdRequest(string deviceId = default)
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

        public void TriggerNoiseThreshold(TriggerNoiseThresholdRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            _seam.Post<object>("/noise_sensors/simulate/trigger_noise_threshold", requestOptions);
        }

        public void TriggerNoiseThreshold(string deviceId = default)
        {
            TriggerNoiseThreshold(new TriggerNoiseThresholdRequest(deviceId: deviceId));
        }

        public async Task TriggerNoiseThresholdAsync(TriggerNoiseThresholdRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            await _seam.PostAsync<object>(
                "/noise_sensors/simulate/trigger_noise_threshold",
                requestOptions
            );
        }

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
