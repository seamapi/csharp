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
                string? pageCursor = default,
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
                PageCursor = pageCursor;
                UnstableLocationId = unstableLocationId;
                UserIdentifierKey = userIdentifierKey;
            }

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

                [EnumMember(Value = "noiseaware")]
                Noiseaware = 1,

                [EnumMember(Value = "minut")]
                Minut = 2,
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

            [DataMember(Name = "page_cursor", IsRequired = false, EmitDefaultValue = false)]
            public string? PageCursor { get; set; }

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
            return _seam.Post<ListResponse>("/noise_sensors/list", requestOptions).Data.Devices;
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
            string? pageCursor = default,
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
                    pageCursor: pageCursor,
                    unstableLocationId: unstableLocationId,
                    userIdentifierKey: userIdentifierKey
                )
            );
        }

        public async Task<List<Device>> ListAsync(ListRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            return (await _seam.PostAsync<ListResponse>("/noise_sensors/list", requestOptions))
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
            string? pageCursor = default,
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
                        pageCursor: pageCursor,
                        unstableLocationId: unstableLocationId,
                        userIdentifierKey: userIdentifierKey
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
