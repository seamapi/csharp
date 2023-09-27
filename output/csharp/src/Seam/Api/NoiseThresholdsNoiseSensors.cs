using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using JsonSubTypes;
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
                bool? sync = default,
                string? name = default,
                string startsDailyAt = default,
                string endsDailyAt = default,
                float noiseThresholdDecibels = default,
                float noiseThresholdNrs = default
            )
            {
                DeviceId = deviceId;
                Sync = sync;
                Name = name;
                StartsDailyAt = startsDailyAt;
                EndsDailyAt = endsDailyAt;
                NoiseThresholdDecibels = noiseThresholdDecibels;
                NoiseThresholdNrs = noiseThresholdNrs;
            }

            [DataMember(Name = "device_id", IsRequired = true, EmitDefaultValue = false)]
            public string DeviceId { get; set; }

            [DataMember(Name = "sync", IsRequired = false, EmitDefaultValue = false)]
            public bool? Sync { get; set; }

            [DataMember(Name = "name", IsRequired = false, EmitDefaultValue = false)]
            public string? Name { get; set; }

            [DataMember(Name = "starts_daily_at", IsRequired = true, EmitDefaultValue = false)]
            public string StartsDailyAt { get; set; }

            [DataMember(Name = "ends_daily_at", IsRequired = true, EmitDefaultValue = false)]
            public string EndsDailyAt { get; set; }

            [DataMember(
                Name = "noise_threshold_decibels",
                IsRequired = false,
                EmitDefaultValue = false
            )]
            public float NoiseThresholdDecibels { get; set; }

            [DataMember(Name = "noise_threshold_nrs", IsRequired = false, EmitDefaultValue = false)]
            public float NoiseThresholdNrs { get; set; }
        }

        [DataContract(Name = "createResponse_response")]
        public class CreateResponse
        {
            [JsonConstructorAttribute]
            protected CreateResponse() { }

            public CreateResponse(ActionAttempt actionAttempt = default)
            {
                ActionAttempt = actionAttempt;
            }

            [DataMember(Name = "action_attempt", IsRequired = false, EmitDefaultValue = false)]
            public ActionAttempt ActionAttempt { get; set; }
        }

        public ActionAttempt Create(CreateRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            return _seam
                .Post<CreateResponse>("/noise_sensors/noise_thresholds/create", requestOptions)
                .Data.ActionAttempt;
        }

        public ActionAttempt Create(
            string deviceId = default,
            bool? sync = default,
            string? name = default,
            string startsDailyAt = default,
            string endsDailyAt = default,
            float noiseThresholdDecibels = default,
            float noiseThresholdNrs = default
        )
        {
            return Create(
                new CreateRequest(
                    deviceId: deviceId,
                    sync: sync,
                    name: name,
                    startsDailyAt: startsDailyAt,
                    endsDailyAt: endsDailyAt,
                    noiseThresholdDecibels: noiseThresholdDecibels,
                    noiseThresholdNrs: noiseThresholdNrs
                )
            );
        }

        public async Task<ActionAttempt> CreateAsync(CreateRequest request)
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
                .ActionAttempt;
        }

        public async Task<ActionAttempt> CreateAsync(
            string deviceId = default,
            bool? sync = default,
            string? name = default,
            string startsDailyAt = default,
            string endsDailyAt = default,
            float noiseThresholdDecibels = default,
            float noiseThresholdNrs = default
        )
        {
            return (
                await CreateAsync(
                    new CreateRequest(
                        deviceId: deviceId,
                        sync: sync,
                        name: name,
                        startsDailyAt: startsDailyAt,
                        endsDailyAt: endsDailyAt,
                        noiseThresholdDecibels: noiseThresholdDecibels,
                        noiseThresholdNrs: noiseThresholdNrs
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
                string noiseThresholdId = default,
                string deviceId = default,
                bool? sync = default
            )
            {
                NoiseThresholdId = noiseThresholdId;
                DeviceId = deviceId;
                Sync = sync;
            }

            [DataMember(Name = "noise_threshold_id", IsRequired = true, EmitDefaultValue = false)]
            public string NoiseThresholdId { get; set; }

            [DataMember(Name = "device_id", IsRequired = true, EmitDefaultValue = false)]
            public string DeviceId { get; set; }

            [DataMember(Name = "sync", IsRequired = false, EmitDefaultValue = false)]
            public bool? Sync { get; set; }
        }

        [DataContract(Name = "deleteResponse_response")]
        public class DeleteResponse
        {
            [JsonConstructorAttribute]
            protected DeleteResponse() { }

            public DeleteResponse(ActionAttempt actionAttempt = default)
            {
                ActionAttempt = actionAttempt;
            }

            [DataMember(Name = "action_attempt", IsRequired = false, EmitDefaultValue = false)]
            public ActionAttempt ActionAttempt { get; set; }
        }

        public ActionAttempt Delete(DeleteRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            return _seam
                .Post<DeleteResponse>("/noise_sensors/noise_thresholds/delete", requestOptions)
                .Data.ActionAttempt;
        }

        public ActionAttempt Delete(
            string noiseThresholdId = default,
            string deviceId = default,
            bool? sync = default
        )
        {
            return Delete(
                new DeleteRequest(
                    noiseThresholdId: noiseThresholdId,
                    deviceId: deviceId,
                    sync: sync
                )
            );
        }

        public async Task<ActionAttempt> DeleteAsync(DeleteRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            return (
                await _seam.PostAsync<DeleteResponse>(
                    "/noise_sensors/noise_thresholds/delete",
                    requestOptions
                )
            )
                .Data
                .ActionAttempt;
        }

        public async Task<ActionAttempt> DeleteAsync(
            string noiseThresholdId = default,
            string deviceId = default,
            bool? sync = default
        )
        {
            return (
                await DeleteAsync(
                    new DeleteRequest(
                        noiseThresholdId: noiseThresholdId,
                        deviceId: deviceId,
                        sync: sync
                    )
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

            public ListRequest(string deviceId = default)
            {
                DeviceId = deviceId;
            }

            [DataMember(Name = "device_id", IsRequired = true, EmitDefaultValue = false)]
            public string DeviceId { get; set; }
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
        }

        public List<NoiseThreshold> List(ListRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            return _seam
                .Post<ListResponse>("/noise_sensors/noise_thresholds/list", requestOptions)
                .Data.NoiseThresholds;
        }

        public List<NoiseThreshold> List(string deviceId = default)
        {
            return List(new ListRequest(deviceId: deviceId));
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

        public async Task<List<NoiseThreshold>> ListAsync(string deviceId = default)
        {
            return (await ListAsync(new ListRequest(deviceId: deviceId)));
        }

        [DataContract(Name = "updateRequest_request")]
        public class UpdateRequest
        {
            [JsonConstructorAttribute]
            protected UpdateRequest() { }

            public UpdateRequest(
                string noiseThresholdId = default,
                string deviceId = default,
                bool? sync = default,
                string? name = default,
                string? startsDailyAt = default,
                string? endsDailyAt = default,
                float noiseThresholdDecibels = default,
                float noiseThresholdNrs = default
            )
            {
                NoiseThresholdId = noiseThresholdId;
                DeviceId = deviceId;
                Sync = sync;
                Name = name;
                StartsDailyAt = startsDailyAt;
                EndsDailyAt = endsDailyAt;
                NoiseThresholdDecibels = noiseThresholdDecibels;
                NoiseThresholdNrs = noiseThresholdNrs;
            }

            [DataMember(Name = "noise_threshold_id", IsRequired = true, EmitDefaultValue = false)]
            public string NoiseThresholdId { get; set; }

            [DataMember(Name = "device_id", IsRequired = true, EmitDefaultValue = false)]
            public string DeviceId { get; set; }

            [DataMember(Name = "sync", IsRequired = false, EmitDefaultValue = false)]
            public bool? Sync { get; set; }

            [DataMember(Name = "name", IsRequired = false, EmitDefaultValue = false)]
            public string? Name { get; set; }

            [DataMember(Name = "starts_daily_at", IsRequired = false, EmitDefaultValue = false)]
            public string? StartsDailyAt { get; set; }

            [DataMember(Name = "ends_daily_at", IsRequired = false, EmitDefaultValue = false)]
            public string? EndsDailyAt { get; set; }

            [DataMember(
                Name = "noise_threshold_decibels",
                IsRequired = false,
                EmitDefaultValue = false
            )]
            public float NoiseThresholdDecibels { get; set; }

            [DataMember(Name = "noise_threshold_nrs", IsRequired = false, EmitDefaultValue = false)]
            public float NoiseThresholdNrs { get; set; }
        }

        [DataContract(Name = "updateResponse_response")]
        public class UpdateResponse
        {
            [JsonConstructorAttribute]
            protected UpdateResponse() { }

            public UpdateResponse(ActionAttempt actionAttempt = default)
            {
                ActionAttempt = actionAttempt;
            }

            [DataMember(Name = "action_attempt", IsRequired = false, EmitDefaultValue = false)]
            public ActionAttempt ActionAttempt { get; set; }
        }

        public ActionAttempt Update(UpdateRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            return _seam
                .Post<UpdateResponse>("/noise_sensors/noise_thresholds/update", requestOptions)
                .Data.ActionAttempt;
        }

        public ActionAttempt Update(
            string noiseThresholdId = default,
            string deviceId = default,
            bool? sync = default,
            string? name = default,
            string? startsDailyAt = default,
            string? endsDailyAt = default,
            float noiseThresholdDecibels = default,
            float noiseThresholdNrs = default
        )
        {
            return Update(
                new UpdateRequest(
                    noiseThresholdId: noiseThresholdId,
                    deviceId: deviceId,
                    sync: sync,
                    name: name,
                    startsDailyAt: startsDailyAt,
                    endsDailyAt: endsDailyAt,
                    noiseThresholdDecibels: noiseThresholdDecibels,
                    noiseThresholdNrs: noiseThresholdNrs
                )
            );
        }

        public async Task<ActionAttempt> UpdateAsync(UpdateRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            return (
                await _seam.PostAsync<UpdateResponse>(
                    "/noise_sensors/noise_thresholds/update",
                    requestOptions
                )
            )
                .Data
                .ActionAttempt;
        }

        public async Task<ActionAttempt> UpdateAsync(
            string noiseThresholdId = default,
            string deviceId = default,
            bool? sync = default,
            string? name = default,
            string? startsDailyAt = default,
            string? endsDailyAt = default,
            float noiseThresholdDecibels = default,
            float noiseThresholdNrs = default
        )
        {
            return (
                await UpdateAsync(
                    new UpdateRequest(
                        noiseThresholdId: noiseThresholdId,
                        deviceId: deviceId,
                        sync: sync,
                        name: name,
                        startsDailyAt: startsDailyAt,
                        endsDailyAt: endsDailyAt,
                        noiseThresholdDecibels: noiseThresholdDecibels,
                        noiseThresholdNrs: noiseThresholdNrs
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
        public Api.NoiseThresholdsNoiseSensors NoiseThresholdsNoiseSensors => new(this);
    }

    public partial interface ISeamClient
    {
        public Api.NoiseThresholdsNoiseSensors NoiseThresholdsNoiseSensors { get; }
    }
}
