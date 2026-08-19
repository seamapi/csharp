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
    public class NoiseSensors
    {
        private ISeamClient _seam;

        public NoiseSensors(ISeamClient seam)
        {
            _seam = seam;
        }

        /// <summary>
        /// Request parameters for List Noise Sensors.
        /// </summary>
        [DataContract(Name = "listRequest_request")]
        public class ListRequest
        {
            [JsonConstructorAttribute]
            protected ListRequest() { }

            public ListRequest(
                string? connectWebviewId = default,
                string? connectedAccountId = default,
                string? customerKey = default,
                ListRequest.DeviceTypeEnum? deviceType = default,
                List<ListRequest.DeviceTypesEnum>? deviceTypes = default,
                ListRequest.ManufacturerEnum? manufacturer = default
            )
            {
                ConnectWebviewId = connectWebviewId;
                ConnectedAccountId = connectedAccountId;
                CustomerKey = customerKey;
                DeviceType = deviceType;
                DeviceTypes = deviceTypes;
                Manufacturer = manufacturer;
            }

            /// <summary>
            /// Device type of the noise sensors that you want to list.
            /// </summary>
            [JsonConverter(typeof(SafeStringEnumConverter))]
            public enum DeviceTypeEnum
            {
                [EnumMember(Value = "unrecognized")]
                Unrecognized = 0,

                [EnumMember(Value = "noiseaware_activity_zone")]
                NoiseawareActivityZone = 1,

                [EnumMember(Value = "minut_sensor")]
                MinutSensor = 2,
            }

            /// <summary>
            /// Device types of the noise sensors that you want to list.
            /// </summary>
            [JsonConverter(typeof(SafeStringEnumConverter))]
            public enum DeviceTypesEnum
            {
                [EnumMember(Value = "unrecognized")]
                Unrecognized = 0,

                [EnumMember(Value = "noiseaware_activity_zone")]
                NoiseawareActivityZone = 1,

                [EnumMember(Value = "minut_sensor")]
                MinutSensor = 2,
            }

            /// <summary>
            /// Manufacturers of the noise sensors that you want to list.
            /// </summary>
            [JsonConverter(typeof(SafeStringEnumConverter))]
            public enum ManufacturerEnum
            {
                [EnumMember(Value = "unrecognized")]
                Unrecognized = 0,

                [EnumMember(Value = "minut")]
                Minut = 1,

                [EnumMember(Value = "noiseaware")]
                Noiseaware = 2,
            }

            /// <summary>
            /// ID of the Connect Webview for which you want to list devices.
            /// </summary>
            [DataMember(Name = "connect_webview_id", IsRequired = false, EmitDefaultValue = false)]
            public string? ConnectWebviewId { get; set; }

            /// <summary>
            /// ID of the connected account for which you want to list devices.
            /// </summary>
            [DataMember(
                Name = "connected_account_id",
                IsRequired = false,
                EmitDefaultValue = false
            )]
            public string? ConnectedAccountId { get; set; }

            /// <summary>
            /// Customer key for which you want to list devices.
            /// </summary>
            [DataMember(Name = "customer_key", IsRequired = false, EmitDefaultValue = false)]
            public string? CustomerKey { get; set; }

            /// <summary>
            /// Device type of the noise sensors that you want to list.
            /// </summary>
            [DataMember(Name = "device_type", IsRequired = false, EmitDefaultValue = false)]
            public ListRequest.DeviceTypeEnum? DeviceType { get; set; }

            /// <summary>
            /// Device types of the noise sensors that you want to list.
            /// </summary>
            [DataMember(Name = "device_types", IsRequired = false, EmitDefaultValue = false)]
            public List<ListRequest.DeviceTypesEnum>? DeviceTypes { get; set; }

            /// <summary>
            /// Manufacturers of the noise sensors that you want to list.
            /// </summary>
            [DataMember(Name = "manufacturer", IsRequired = false, EmitDefaultValue = false)]
            public ListRequest.ManufacturerEnum? Manufacturer { get; set; }

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

            /// <summary>
            /// OK
            /// </summary>
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

        /// <summary>
        /// Returns a list of all [noise sensors](https://docs.seam.co/capability-guides/noise-sensors).
        /// </summary>
        public List<Device> List(ListRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            return _seam
                .Get<ListResponse>("/noise_sensors/list", requestOptions)
                .EnsureData("/noise_sensors/list")
                .Devices;
        }

        /// <summary>
        /// Returns a list of all [noise sensors](https://docs.seam.co/capability-guides/noise-sensors).
        /// </summary>
        public List<Device> List(
            string? connectWebviewId = default,
            string? connectedAccountId = default,
            string? customerKey = default,
            ListRequest.DeviceTypeEnum? deviceType = default,
            List<ListRequest.DeviceTypesEnum>? deviceTypes = default,
            ListRequest.ManufacturerEnum? manufacturer = default
        )
        {
            return List(
                new ListRequest(
                    connectWebviewId: connectWebviewId,
                    connectedAccountId: connectedAccountId,
                    customerKey: customerKey,
                    deviceType: deviceType,
                    deviceTypes: deviceTypes,
                    manufacturer: manufacturer
                )
            );
        }

        /// <summary>
        /// Returns a list of all [noise sensors](https://docs.seam.co/capability-guides/noise-sensors).
        /// </summary>
        public async Task<List<Device>> ListAsync(ListRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            return (await _seam.GetAsync<ListResponse>("/noise_sensors/list", requestOptions))
                .EnsureData("/noise_sensors/list")
                .Devices;
        }

        /// <summary>
        /// Returns a list of all [noise sensors](https://docs.seam.co/capability-guides/noise-sensors).
        /// </summary>
        public async Task<List<Device>> ListAsync(
            string? connectWebviewId = default,
            string? connectedAccountId = default,
            string? customerKey = default,
            ListRequest.DeviceTypeEnum? deviceType = default,
            List<ListRequest.DeviceTypesEnum>? deviceTypes = default,
            ListRequest.ManufacturerEnum? manufacturer = default
        )
        {
            return (
                await ListAsync(
                    new ListRequest(
                        connectWebviewId: connectWebviewId,
                        connectedAccountId: connectedAccountId,
                        customerKey: customerKey,
                        deviceType: deviceType,
                        deviceTypes: deviceTypes,
                        manufacturer: manufacturer
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
        public Api.NoiseSensors NoiseSensors => new(this);
    }

    public partial interface ISeamClient
    {
        public Api.NoiseSensors NoiseSensors { get; }
    }
}
