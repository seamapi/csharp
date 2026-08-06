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

        /// <summary>
        /// Request parameters for Create a Noise Threshold.
        /// </summary>
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
                string startsDailyAt = default
            )
            {
                DeviceId = deviceId;
                EndsDailyAt = endsDailyAt;
                Name = name;
                NoiseThresholdDecibels = noiseThresholdDecibels;
                NoiseThresholdNrs = noiseThresholdNrs;
                StartsDailyAt = startsDailyAt;
            }

            /// <summary>
            /// ID of the device for which you want to create a noise threshold.
            /// </summary>
            [DataMember(Name = "device_id", IsRequired = true, EmitDefaultValue = false)]
            public string DeviceId { get; set; }

            /// <summary>
            /// Time at which the new noise threshold should become inactive daily.
            /// </summary>
            [DataMember(Name = "ends_daily_at", IsRequired = true, EmitDefaultValue = false)]
            public string EndsDailyAt { get; set; }

            /// <summary>
            /// Name of the new noise threshold.
            /// </summary>
            [DataMember(Name = "name", IsRequired = false, EmitDefaultValue = false)]
            public string? Name { get; set; }

            /// <summary>
            /// Noise level in decibels for the new noise threshold.
            /// </summary>
            [DataMember(
                Name = "noise_threshold_decibels",
                IsRequired = false,
                EmitDefaultValue = false
            )]
            public float? NoiseThresholdDecibels { get; set; }

            /// <summary>
            /// Noise level in Noiseaware Noise Risk Score (NRS) for the new noise threshold. This parameter is only relevant for [Noiseaware sensors](https://docs.seam.co/device-and-system-integration-guides/noiseaware-sensors).
            /// </summary>
            [DataMember(Name = "noise_threshold_nrs", IsRequired = false, EmitDefaultValue = false)]
            public float? NoiseThresholdNrs { get; set; }

            /// <summary>
            /// Time at which the new noise threshold should become active daily.
            /// </summary>
            [DataMember(Name = "starts_daily_at", IsRequired = true, EmitDefaultValue = false)]
            public string StartsDailyAt { get; set; }

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

            /// <summary>
            /// OK
            /// </summary>
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

        /// <summary>
        /// Creates a new [noise threshold](https://docs.seam.co/capability-guides/noise-sensors/configure-noise-threshold-settings) for a [noise sensor](https://docs.seam.co/capability-guides/noise-sensors). Thresholds represent the limits of noise tolerated at a property, which can be customized for each hour of the day. Each device has its own default thresholds, but you can use the Seam API to modify them.
        /// </summary>
        public NoiseThreshold Create(CreateRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            return _seam
                .Post<CreateResponse>("/noise_sensors/noise_thresholds/create", requestOptions)
                .EnsureData("/noise_sensors/noise_thresholds/create")
                .NoiseThreshold;
        }

        /// <summary>
        /// Creates a new [noise threshold](https://docs.seam.co/capability-guides/noise-sensors/configure-noise-threshold-settings) for a [noise sensor](https://docs.seam.co/capability-guides/noise-sensors). Thresholds represent the limits of noise tolerated at a property, which can be customized for each hour of the day. Each device has its own default thresholds, but you can use the Seam API to modify them.
        /// </summary>
        public NoiseThreshold Create(
            string deviceId = default,
            string endsDailyAt = default,
            string? name = default,
            float? noiseThresholdDecibels = default,
            float? noiseThresholdNrs = default,
            string startsDailyAt = default
        )
        {
            return Create(
                new CreateRequest(
                    deviceId: deviceId,
                    endsDailyAt: endsDailyAt,
                    name: name,
                    noiseThresholdDecibels: noiseThresholdDecibels,
                    noiseThresholdNrs: noiseThresholdNrs,
                    startsDailyAt: startsDailyAt
                )
            );
        }

        /// <summary>
        /// Creates a new [noise threshold](https://docs.seam.co/capability-guides/noise-sensors/configure-noise-threshold-settings) for a [noise sensor](https://docs.seam.co/capability-guides/noise-sensors). Thresholds represent the limits of noise tolerated at a property, which can be customized for each hour of the day. Each device has its own default thresholds, but you can use the Seam API to modify them.
        /// </summary>
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
                .EnsureData("/noise_sensors/noise_thresholds/create")
                .NoiseThreshold;
        }

        /// <summary>
        /// Creates a new [noise threshold](https://docs.seam.co/capability-guides/noise-sensors/configure-noise-threshold-settings) for a [noise sensor](https://docs.seam.co/capability-guides/noise-sensors). Thresholds represent the limits of noise tolerated at a property, which can be customized for each hour of the day. Each device has its own default thresholds, but you can use the Seam API to modify them.
        /// </summary>
        public async Task<NoiseThreshold> CreateAsync(
            string deviceId = default,
            string endsDailyAt = default,
            string? name = default,
            float? noiseThresholdDecibels = default,
            float? noiseThresholdNrs = default,
            string startsDailyAt = default
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
                        startsDailyAt: startsDailyAt
                    )
                )
            );
        }

        /// <summary>
        /// Request parameters for Delete a Noise Threshold.
        /// </summary>
        [DataContract(Name = "deleteRequest_request")]
        public class DeleteRequest
        {
            [JsonConstructorAttribute]
            protected DeleteRequest() { }

            public DeleteRequest(string deviceId = default, string noiseThresholdId = default)
            {
                DeviceId = deviceId;
                NoiseThresholdId = noiseThresholdId;
            }

            /// <summary>
            /// ID of the device that contains the noise threshold that you want to delete.
            /// </summary>
            [DataMember(Name = "device_id", IsRequired = true, EmitDefaultValue = false)]
            public string DeviceId { get; set; }

            /// <summary>
            /// ID of the noise threshold that you want to delete.
            /// </summary>
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

        /// <summary>
        /// Deletes a [noise threshold](https://docs.seam.co/capability-guides/noise-sensors/configure-noise-threshold-settings) from a [noise sensor](https://docs.seam.co/capability-guides/noise-sensors).
        /// </summary>
        public void Delete(DeleteRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            _seam.Post<object>("/noise_sensors/noise_thresholds/delete", requestOptions);
        }

        /// <summary>
        /// Deletes a [noise threshold](https://docs.seam.co/capability-guides/noise-sensors/configure-noise-threshold-settings) from a [noise sensor](https://docs.seam.co/capability-guides/noise-sensors).
        /// </summary>
        public void Delete(string deviceId = default, string noiseThresholdId = default)
        {
            Delete(new DeleteRequest(deviceId: deviceId, noiseThresholdId: noiseThresholdId));
        }

        /// <summary>
        /// Deletes a [noise threshold](https://docs.seam.co/capability-guides/noise-sensors/configure-noise-threshold-settings) from a [noise sensor](https://docs.seam.co/capability-guides/noise-sensors).
        /// </summary>
        public async Task DeleteAsync(DeleteRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            await _seam.PostAsync<object>("/noise_sensors/noise_thresholds/delete", requestOptions);
        }

        /// <summary>
        /// Deletes a [noise threshold](https://docs.seam.co/capability-guides/noise-sensors/configure-noise-threshold-settings) from a [noise sensor](https://docs.seam.co/capability-guides/noise-sensors).
        /// </summary>
        public async Task DeleteAsync(string deviceId = default, string noiseThresholdId = default)
        {
            await DeleteAsync(
                new DeleteRequest(deviceId: deviceId, noiseThresholdId: noiseThresholdId)
            );
        }

        /// <summary>
        /// Request parameters for Get a Noise Threshold.
        /// </summary>
        [DataContract(Name = "getRequest_request")]
        public class GetRequest
        {
            [JsonConstructorAttribute]
            protected GetRequest() { }

            public GetRequest(string noiseThresholdId = default)
            {
                NoiseThresholdId = noiseThresholdId;
            }

            /// <summary>
            /// ID of the noise threshold that you want to get.
            /// </summary>
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

            /// <summary>
            /// OK
            /// </summary>
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

        /// <summary>
        /// Returns a specified [noise threshold](https://docs.seam.co/capability-guides/noise-sensors/configure-noise-threshold-settings) for a [noise sensor](https://docs.seam.co/capability-guides/noise-sensors).
        /// </summary>
        public NoiseThreshold Get(GetRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            return _seam
                .Post<GetResponse>("/noise_sensors/noise_thresholds/get", requestOptions)
                .EnsureData("/noise_sensors/noise_thresholds/get")
                .NoiseThreshold;
        }

        /// <summary>
        /// Returns a specified [noise threshold](https://docs.seam.co/capability-guides/noise-sensors/configure-noise-threshold-settings) for a [noise sensor](https://docs.seam.co/capability-guides/noise-sensors).
        /// </summary>
        public NoiseThreshold Get(string noiseThresholdId = default)
        {
            return Get(new GetRequest(noiseThresholdId: noiseThresholdId));
        }

        /// <summary>
        /// Returns a specified [noise threshold](https://docs.seam.co/capability-guides/noise-sensors/configure-noise-threshold-settings) for a [noise sensor](https://docs.seam.co/capability-guides/noise-sensors).
        /// </summary>
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
                .EnsureData("/noise_sensors/noise_thresholds/get")
                .NoiseThreshold;
        }

        /// <summary>
        /// Returns a specified [noise threshold](https://docs.seam.co/capability-guides/noise-sensors/configure-noise-threshold-settings) for a [noise sensor](https://docs.seam.co/capability-guides/noise-sensors).
        /// </summary>
        public async Task<NoiseThreshold> GetAsync(string noiseThresholdId = default)
        {
            return (await GetAsync(new GetRequest(noiseThresholdId: noiseThresholdId)));
        }

        /// <summary>
        /// Request parameters for List Noise Thresholds.
        /// </summary>
        [DataContract(Name = "listRequest_request")]
        public class ListRequest
        {
            [JsonConstructorAttribute]
            protected ListRequest() { }

            public ListRequest(string deviceId = default)
            {
                DeviceId = deviceId;
            }

            /// <summary>
            /// ID of the device for which you want to list noise thresholds.
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

        [DataContract(Name = "listResponse_response")]
        public class ListResponse
        {
            [JsonConstructorAttribute]
            protected ListResponse() { }

            public ListResponse(List<NoiseThreshold> noiseThresholds = default)
            {
                NoiseThresholds = noiseThresholds;
            }

            /// <summary>
            /// OK
            /// </summary>
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

        /// <summary>
        /// Returns a list of all [noise thresholds](https://docs.seam.co/capability-guides/noise-sensors/configure-noise-threshold-settings) for a [noise sensor](https://docs.seam.co/capability-guides/noise-sensors).
        /// </summary>
        public List<NoiseThreshold> List(ListRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            return _seam
                .Post<ListResponse>("/noise_sensors/noise_thresholds/list", requestOptions)
                .EnsureData("/noise_sensors/noise_thresholds/list")
                .NoiseThresholds;
        }

        /// <summary>
        /// Returns a list of all [noise thresholds](https://docs.seam.co/capability-guides/noise-sensors/configure-noise-threshold-settings) for a [noise sensor](https://docs.seam.co/capability-guides/noise-sensors).
        /// </summary>
        public List<NoiseThreshold> List(string deviceId = default)
        {
            return List(new ListRequest(deviceId: deviceId));
        }

        /// <summary>
        /// Returns a list of all [noise thresholds](https://docs.seam.co/capability-guides/noise-sensors/configure-noise-threshold-settings) for a [noise sensor](https://docs.seam.co/capability-guides/noise-sensors).
        /// </summary>
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
                .EnsureData("/noise_sensors/noise_thresholds/list")
                .NoiseThresholds;
        }

        /// <summary>
        /// Returns a list of all [noise thresholds](https://docs.seam.co/capability-guides/noise-sensors/configure-noise-threshold-settings) for a [noise sensor](https://docs.seam.co/capability-guides/noise-sensors).
        /// </summary>
        public async Task<List<NoiseThreshold>> ListAsync(string deviceId = default)
        {
            return (await ListAsync(new ListRequest(deviceId: deviceId)));
        }

        /// <summary>
        /// Request parameters for Update a Noise Threshold.
        /// </summary>
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
                string? startsDailyAt = default
            )
            {
                DeviceId = deviceId;
                EndsDailyAt = endsDailyAt;
                Name = name;
                NoiseThresholdDecibels = noiseThresholdDecibels;
                NoiseThresholdId = noiseThresholdId;
                NoiseThresholdNrs = noiseThresholdNrs;
                StartsDailyAt = startsDailyAt;
            }

            /// <summary>
            /// ID of the device that contains the noise threshold that you want to update.
            /// </summary>
            [DataMember(Name = "device_id", IsRequired = true, EmitDefaultValue = false)]
            public string DeviceId { get; set; }

            /// <summary>
            /// Time at which the noise threshold should become inactive daily.
            /// </summary>
            [DataMember(Name = "ends_daily_at", IsRequired = false, EmitDefaultValue = false)]
            public string? EndsDailyAt { get; set; }

            /// <summary>
            /// Name of the noise threshold that you want to update.
            /// </summary>
            [DataMember(Name = "name", IsRequired = false, EmitDefaultValue = false)]
            public string? Name { get; set; }

            /// <summary>
            /// Noise level in decibels for the noise threshold.
            /// </summary>
            [DataMember(
                Name = "noise_threshold_decibels",
                IsRequired = false,
                EmitDefaultValue = false
            )]
            public float? NoiseThresholdDecibels { get; set; }

            /// <summary>
            /// ID of the noise threshold that you want to update.
            /// </summary>
            [DataMember(Name = "noise_threshold_id", IsRequired = true, EmitDefaultValue = false)]
            public string NoiseThresholdId { get; set; }

            /// <summary>
            /// Noise level in Noiseaware Noise Risk Score (NRS) for the noise threshold. This parameter is only relevant for [Noiseaware sensors](https://docs.seam.co/device-and-system-integration-guides/noiseaware-sensors).
            /// </summary>
            [DataMember(Name = "noise_threshold_nrs", IsRequired = false, EmitDefaultValue = false)]
            public float? NoiseThresholdNrs { get; set; }

            /// <summary>
            /// Time at which the noise threshold should become active daily.
            /// </summary>
            [DataMember(Name = "starts_daily_at", IsRequired = false, EmitDefaultValue = false)]
            public string? StartsDailyAt { get; set; }

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
        /// Updates a [noise threshold](https://docs.seam.co/capability-guides/noise-sensors/configure-noise-threshold-settings) for a [noise sensor](https://docs.seam.co/capability-guides/noise-sensors).
        /// </summary>
        public void Update(UpdateRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            _seam.Post<object>("/noise_sensors/noise_thresholds/update", requestOptions);
        }

        /// <summary>
        /// Updates a [noise threshold](https://docs.seam.co/capability-guides/noise-sensors/configure-noise-threshold-settings) for a [noise sensor](https://docs.seam.co/capability-guides/noise-sensors).
        /// </summary>
        public void Update(
            string deviceId = default,
            string? endsDailyAt = default,
            string? name = default,
            float? noiseThresholdDecibels = default,
            string noiseThresholdId = default,
            float? noiseThresholdNrs = default,
            string? startsDailyAt = default
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
                    startsDailyAt: startsDailyAt
                )
            );
        }

        /// <summary>
        /// Updates a [noise threshold](https://docs.seam.co/capability-guides/noise-sensors/configure-noise-threshold-settings) for a [noise sensor](https://docs.seam.co/capability-guides/noise-sensors).
        /// </summary>
        public async Task UpdateAsync(UpdateRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            await _seam.PostAsync<object>("/noise_sensors/noise_thresholds/update", requestOptions);
        }

        /// <summary>
        /// Updates a [noise threshold](https://docs.seam.co/capability-guides/noise-sensors/configure-noise-threshold-settings) for a [noise sensor](https://docs.seam.co/capability-guides/noise-sensors).
        /// </summary>
        public async Task UpdateAsync(
            string deviceId = default,
            string? endsDailyAt = default,
            string? name = default,
            float? noiseThresholdDecibels = default,
            string noiseThresholdId = default,
            float? noiseThresholdNrs = default,
            string? startsDailyAt = default
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
                    startsDailyAt: startsDailyAt
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
