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
