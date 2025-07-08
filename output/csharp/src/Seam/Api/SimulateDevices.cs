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
    public class SimulateDevices
    {
        private ISeamClient _seam;

        public SimulateDevices(ISeamClient seam)
        {
            _seam = seam;
        }

        [DataContract(Name = "connectRequest_request")]
        public class ConnectRequest
        {
            [JsonConstructorAttribute]
            protected ConnectRequest() { }

            public ConnectRequest(string deviceId = default)
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

        public void Connect(ConnectRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            _seam.Post<object>("/devices/simulate/connect", requestOptions);
        }

        public void Connect(string deviceId = default)
        {
            Connect(new ConnectRequest(deviceId: deviceId));
        }

        public async Task ConnectAsync(ConnectRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            await _seam.PostAsync<object>("/devices/simulate/connect", requestOptions);
        }

        public async Task ConnectAsync(string deviceId = default)
        {
            await ConnectAsync(new ConnectRequest(deviceId: deviceId));
        }

        [DataContract(Name = "connectToHubRequest_request")]
        public class ConnectToHubRequest
        {
            [JsonConstructorAttribute]
            protected ConnectToHubRequest() { }

            public ConnectToHubRequest(string deviceId = default)
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

        public void ConnectToHub(ConnectToHubRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            _seam.Post<object>("/devices/simulate/connect_to_hub", requestOptions);
        }

        public void ConnectToHub(string deviceId = default)
        {
            ConnectToHub(new ConnectToHubRequest(deviceId: deviceId));
        }

        public async Task ConnectToHubAsync(ConnectToHubRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            await _seam.PostAsync<object>("/devices/simulate/connect_to_hub", requestOptions);
        }

        public async Task ConnectToHubAsync(string deviceId = default)
        {
            await ConnectToHubAsync(new ConnectToHubRequest(deviceId: deviceId));
        }

        [DataContract(Name = "disconnectRequest_request")]
        public class DisconnectRequest
        {
            [JsonConstructorAttribute]
            protected DisconnectRequest() { }

            public DisconnectRequest(string deviceId = default)
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

        public void Disconnect(DisconnectRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            _seam.Post<object>("/devices/simulate/disconnect", requestOptions);
        }

        public void Disconnect(string deviceId = default)
        {
            Disconnect(new DisconnectRequest(deviceId: deviceId));
        }

        public async Task DisconnectAsync(DisconnectRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            await _seam.PostAsync<object>("/devices/simulate/disconnect", requestOptions);
        }

        public async Task DisconnectAsync(string deviceId = default)
        {
            await DisconnectAsync(new DisconnectRequest(deviceId: deviceId));
        }

        [DataContract(Name = "disconnectFromHubRequest_request")]
        public class DisconnectFromHubRequest
        {
            [JsonConstructorAttribute]
            protected DisconnectFromHubRequest() { }

            public DisconnectFromHubRequest(string deviceId = default)
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

        public void DisconnectFromHub(DisconnectFromHubRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            _seam.Post<object>("/devices/simulate/disconnect_from_hub", requestOptions);
        }

        public void DisconnectFromHub(string deviceId = default)
        {
            DisconnectFromHub(new DisconnectFromHubRequest(deviceId: deviceId));
        }

        public async Task DisconnectFromHubAsync(DisconnectFromHubRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            await _seam.PostAsync<object>("/devices/simulate/disconnect_from_hub", requestOptions);
        }

        public async Task DisconnectFromHubAsync(string deviceId = default)
        {
            await DisconnectFromHubAsync(new DisconnectFromHubRequest(deviceId: deviceId));
        }

        [DataContract(Name = "removeRequest_request")]
        public class RemoveRequest
        {
            [JsonConstructorAttribute]
            protected RemoveRequest() { }

            public RemoveRequest(string deviceId = default)
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

        public void Remove(RemoveRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            _seam.Post<object>("/devices/simulate/remove", requestOptions);
        }

        public void Remove(string deviceId = default)
        {
            Remove(new RemoveRequest(deviceId: deviceId));
        }

        public async Task RemoveAsync(RemoveRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            await _seam.PostAsync<object>("/devices/simulate/remove", requestOptions);
        }

        public async Task RemoveAsync(string deviceId = default)
        {
            await RemoveAsync(new RemoveRequest(deviceId: deviceId));
        }
    }
}

namespace Seam.Client
{
    public partial class SeamClient
    {
        public Api.SimulateDevices SimulateDevices => new(this);
    }

    public partial interface ISeamClient
    {
        public Api.SimulateDevices SimulateDevices { get; }
    }
}
