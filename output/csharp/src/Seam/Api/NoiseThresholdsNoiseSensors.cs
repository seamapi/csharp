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
    public class NoiseThresholdsNoiseSensors
    {
        private ISeamClient _seam;

        public NoiseThresholdsNoiseSensors(ISeamClient seam)
        {
            _seam = seam;
        }

        [DataContract(Name = "createRequest_request")]
        public class CreateRequest
        {
            [JsonConstructorAttribute]
            protected CreateRequest() { }

            public CreateRequest(
                string deviceId = default,
                string endsDailyAt = default,
                string? name = default,
                float? noiseThresholdDecibels = default,
                float? noiseThresholdNrs = default,
                string startsDailyAt = default,
                bool? sync = default
            )
            {
                DeviceId = deviceId;
                EndsDailyAt = endsDailyAt;
                Name = name;
                NoiseThresholdDecibels = noiseThresholdDecibels;
                NoiseThresholdNrs = noiseThresholdNrs;
                StartsDailyAt = startsDailyAt;
                Sync = sync;
            }

            [DataMember(Name = "device_id", IsRequired = true, EmitDefaultValue = false)]
            public string DeviceId { get; set; }

            [DataMember(Name = "ends_daily_at", IsRequired = true, EmitDefaultValue = false)]
            public string EndsDailyAt { get; set; }

            [DataMember(Name = "name", IsRequired = false, EmitDefaultValue = false)]
            public string? Name { get; set; }

            [DataMember(
                Name = "noise_threshold_decibels",
                IsRequired = false,
                EmitDefaultValue = false
            )]
            public float? NoiseThresholdDecibels { get; set; }

            [DataMember(Name = "noise_threshold_nrs", IsRequired = false, EmitDefaultValue = false)]
            public float? NoiseThresholdNrs { get; set; }

            [DataMember(Name = "starts_daily_at", IsRequired = true, EmitDefaultValue = false)]
            public string StartsDailyAt { get; set; }

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

        [DataContract(Name = "createResponse_response")]
        public class CreateResponse
        {
            [JsonConstructorAttribute]
            protected CreateResponse() { }

            public CreateResponse(NoiseThreshold noiseThreshold = default)
            {
                NoiseThreshold = noiseThreshold;
            }

            [DataMember(Name = "noise_threshold", IsRequired = false, EmitDefaultValue = false)]
            public NoiseThreshold NoiseThreshold { get; set; }

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

        public NoiseThreshold Create(CreateRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            return _seam
                .Post<CreateResponse>("/noise_sensors/noise_thresholds/create", requestOptions)
                .Data.NoiseThreshold;
        }

        public NoiseThreshold Create(
            string deviceId = default,
            string endsDailyAt = default,
            string? name = default,
            float? noiseThresholdDecibels = default,
            float? noiseThresholdNrs = default,
            string startsDailyAt = default,
            bool? sync = default
        )
        {
            return Create(
                new CreateRequest(
                    deviceId: deviceId,
                    endsDailyAt: endsDailyAt,
                    name: name,
                    noiseThresholdDecibels: noiseThresholdDecibels,
                    noiseThresholdNrs: noiseThresholdNrs,
                    startsDailyAt: startsDailyAt,
                    sync: sync
                )
            );
        }

        public async Task<NoiseThreshold> CreateAsync(CreateRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            return (
                await _seam.PostAsync<CreateResponse>(
                    "/noise_sensors/noise_thresholds/create",
                    requestOptions
                )
            )
                .Data
                .NoiseThreshold;
        }

        public async Task<NoiseThreshold> CreateAsync(
            string deviceId = default,
            string endsDailyAt = default,
            string? name = default,
            float? noiseThresholdDecibels = default,
            float? noiseThresholdNrs = default,
            string startsDailyAt = default,
            bool? sync = default
        )
        {
            return (
                await CreateAsync(
                    new CreateRequest(
                        deviceId: deviceId,
                        endsDailyAt: endsDailyAt,
                        name: name,
                        noiseThresholdDecibels: noiseThresholdDecibels,
                        noiseThresholdNrs: noiseThresholdNrs,
                        startsDailyAt: startsDailyAt,
                        sync: sync
                    )
                )
            );
        }

        [DataContract(Name = "deleteRequest_request")]
        public class DeleteRequest
        {
            [JsonConstructorAttribute]
            protected DeleteRequest() { }

            public DeleteRequest(
                string deviceId = default,
                string noiseThresholdId = default,
                bool? sync = default
            )
            {
                DeviceId = deviceId;
                NoiseThresholdId = noiseThresholdId;
                Sync = sync;
            }

            [DataMember(Name = "device_id", IsRequired = true, EmitDefaultValue = false)]
            public string DeviceId { get; set; }

            [DataMember(Name = "noise_threshold_id", IsRequired = true, EmitDefaultValue = false)]
            public string NoiseThresholdId { get; set; }

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

        public void Delete(DeleteRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            _seam.Post<object>("/noise_sensors/noise_thresholds/delete", requestOptions);
        }

        public void Delete(
            string deviceId = default,
            string noiseThresholdId = default,
            bool? sync = default
        )
        {
            Delete(
                new DeleteRequest(
                    deviceId: deviceId,
                    noiseThresholdId: noiseThresholdId,
                    sync: sync
                )
            );
        }

        public async Task DeleteAsync(DeleteRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            await _seam.PostAsync<object>("/noise_sensors/noise_thresholds/delete", requestOptions);
        }

        public async Task DeleteAsync(
            string deviceId = default,
            string noiseThresholdId = default,
            bool? sync = default
        )
        {
            await DeleteAsync(
                new DeleteRequest(
                    deviceId: deviceId,
                    noiseThresholdId: noiseThresholdId,
                    sync: sync
                )
            );
        }

        [DataContract(Name = "getRequest_request")]
        public class GetRequest
        {
            [JsonConstructorAttribute]
            protected GetRequest() { }

            public GetRequest(string noiseThresholdId = default)
            {
                NoiseThresholdId = noiseThresholdId;
            }

            [DataMember(Name = "noise_threshold_id", IsRequired = true, EmitDefaultValue = false)]
            public string NoiseThresholdId { get; set; }

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

            public GetResponse(NoiseThreshold noiseThreshold = default)
            {
                NoiseThreshold = noiseThreshold;
            }

            [DataMember(Name = "noise_threshold", IsRequired = false, EmitDefaultValue = false)]
            public NoiseThreshold NoiseThreshold { get; set; }

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

        public NoiseThreshold Get(GetRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            return _seam
                .Post<GetResponse>("/noise_sensors/noise_thresholds/get", requestOptions)
                .Data.NoiseThreshold;
        }

        public NoiseThreshold Get(string noiseThresholdId = default)
        {
            return Get(new GetRequest(noiseThresholdId: noiseThresholdId));
        }

        public async Task<NoiseThreshold> GetAsync(GetRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            return (
                await _seam.PostAsync<GetResponse>(
                    "/noise_sensors/noise_thresholds/get",
                    requestOptions
                )
            )
                .Data
                .NoiseThreshold;
        }

        public async Task<NoiseThreshold> GetAsync(string noiseThresholdId = default)
        {
            return (await GetAsync(new GetRequest(noiseThresholdId: noiseThresholdId)));
        }

        [DataContract(Name = "listRequest_request")]
        public class ListRequest
        {
            [JsonConstructorAttribute]
            protected ListRequest() { }

            public ListRequest(string deviceId = default, bool? isProgrammed = default)
            {
                DeviceId = deviceId;
                IsProgrammed = isProgrammed;
            }

            [DataMember(Name = "device_id", IsRequired = true, EmitDefaultValue = false)]
            public string DeviceId { get; set; }

            [DataMember(Name = "is_programmed", IsRequired = false, EmitDefaultValue = false)]
            public bool? IsProgrammed { get; set; }

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

            public ListResponse(List<NoiseThreshold> noiseThresholds = default)
            {
                NoiseThresholds = noiseThresholds;
            }

            [DataMember(Name = "noise_thresholds", IsRequired = false, EmitDefaultValue = false)]
            public List<NoiseThreshold> NoiseThresholds { get; set; }

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

        public List<NoiseThreshold> List(ListRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            return _seam
                .Post<ListResponse>("/noise_sensors/noise_thresholds/list", requestOptions)
                .Data.NoiseThresholds;
        }

        public List<NoiseThreshold> List(string deviceId = default, bool? isProgrammed = default)
        {
            return List(new ListRequest(deviceId: deviceId, isProgrammed: isProgrammed));
        }

        public async Task<List<NoiseThreshold>> ListAsync(ListRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            return (
                await _seam.PostAsync<ListResponse>(
                    "/noise_sensors/noise_thresholds/list",
                    requestOptions
                )
            )
                .Data
                .NoiseThresholds;
        }

        public async Task<List<NoiseThreshold>> ListAsync(
            string deviceId = default,
            bool? isProgrammed = default
        )
        {
            return (
                await ListAsync(new ListRequest(deviceId: deviceId, isProgrammed: isProgrammed))
            );
        }

        [DataContract(Name = "updateRequest_request")]
        public class UpdateRequest
        {
            [JsonConstructorAttribute]
            protected UpdateRequest() { }

            public UpdateRequest(
                string deviceId = default,
                string? endsDailyAt = default,
                string? name = default,
                float? noiseThresholdDecibels = default,
                string noiseThresholdId = default,
                float? noiseThresholdNrs = default,
                string? startsDailyAt = default,
                bool? sync = default
            )
            {
                DeviceId = deviceId;
                EndsDailyAt = endsDailyAt;
                Name = name;
                NoiseThresholdDecibels = noiseThresholdDecibels;
                NoiseThresholdId = noiseThresholdId;
                NoiseThresholdNrs = noiseThresholdNrs;
                StartsDailyAt = startsDailyAt;
                Sync = sync;
            }

            [DataMember(Name = "device_id", IsRequired = true, EmitDefaultValue = false)]
            public string DeviceId { get; set; }

            [DataMember(Name = "ends_daily_at", IsRequired = false, EmitDefaultValue = false)]
            public string? EndsDailyAt { get; set; }

            [DataMember(Name = "name", IsRequired = false, EmitDefaultValue = false)]
            public string? Name { get; set; }

            [DataMember(
                Name = "noise_threshold_decibels",
                IsRequired = false,
                EmitDefaultValue = false
            )]
            public float? NoiseThresholdDecibels { get; set; }

            [DataMember(Name = "noise_threshold_id", IsRequired = true, EmitDefaultValue = false)]
            public string NoiseThresholdId { get; set; }

            [DataMember(Name = "noise_threshold_nrs", IsRequired = false, EmitDefaultValue = false)]
            public float? NoiseThresholdNrs { get; set; }

            [DataMember(Name = "starts_daily_at", IsRequired = false, EmitDefaultValue = false)]
            public string? StartsDailyAt { get; set; }

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

        public void Update(UpdateRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            _seam.Post<object>("/noise_sensors/noise_thresholds/update", requestOptions);
        }

        public void Update(
            string deviceId = default,
            string? endsDailyAt = default,
            string? name = default,
            float? noiseThresholdDecibels = default,
            string noiseThresholdId = default,
            float? noiseThresholdNrs = default,
            string? startsDailyAt = default,
            bool? sync = default
        )
        {
            Update(
                new UpdateRequest(
                    deviceId: deviceId,
                    endsDailyAt: endsDailyAt,
                    name: name,
                    noiseThresholdDecibels: noiseThresholdDecibels,
                    noiseThresholdId: noiseThresholdId,
                    noiseThresholdNrs: noiseThresholdNrs,
                    startsDailyAt: startsDailyAt,
                    sync: sync
                )
            );
        }

        public async Task UpdateAsync(UpdateRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            await _seam.PostAsync<object>("/noise_sensors/noise_thresholds/update", requestOptions);
        }

        public async Task UpdateAsync(
            string deviceId = default,
            string? endsDailyAt = default,
            string? name = default,
            float? noiseThresholdDecibels = default,
            string noiseThresholdId = default,
            float? noiseThresholdNrs = default,
            string? startsDailyAt = default,
            bool? sync = default
        )
        {
            await UpdateAsync(
                new UpdateRequest(
                    deviceId: deviceId,
                    endsDailyAt: endsDailyAt,
                    name: name,
                    noiseThresholdDecibels: noiseThresholdDecibels,
                    noiseThresholdId: noiseThresholdId,
                    noiseThresholdNrs: noiseThresholdNrs,
                    startsDailyAt: startsDailyAt,
                    sync: sync
                )
            );
        }
    }
}

namespace Seam.Client
{
    public partial class SeamClient
    {
        public Api.NoiseThresholdsNoiseSensors NoiseThresholdsNoiseSensors => new(this);
    }

    public partial interface ISeamClient
    {
        public Api.NoiseThresholdsNoiseSensors NoiseThresholdsNoiseSensors { get; }
    }
}
