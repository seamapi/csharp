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
    public class SchedulesThermostats
    {
        private ISeamClient _seam;

        public SchedulesThermostats(ISeamClient seam)
        {
            _seam = seam;
        }

        [DataContract(Name = "createRequest_request")]
        public class CreateRequest
        {
            [JsonConstructorAttribute]
            protected CreateRequest() { }

            public CreateRequest(
                string climatePresetKey = default,
                string deviceId = default,
                string endsAt = default,
                bool? isOverrideAllowed = default,
                int? maxOverridePeriodMinutes = default,
                string? name = default,
                string startsAt = default
            )
            {
                ClimatePresetKey = climatePresetKey;
                DeviceId = deviceId;
                EndsAt = endsAt;
                IsOverrideAllowed = isOverrideAllowed;
                MaxOverridePeriodMinutes = maxOverridePeriodMinutes;
                Name = name;
                StartsAt = startsAt;
            }

            [DataMember(Name = "climate_preset_key", IsRequired = true, EmitDefaultValue = false)]
            public string ClimatePresetKey { get; set; }

            [DataMember(Name = "device_id", IsRequired = true, EmitDefaultValue = false)]
            public string DeviceId { get; set; }

            [DataMember(Name = "ends_at", IsRequired = true, EmitDefaultValue = false)]
            public string EndsAt { get; set; }

            [DataMember(Name = "is_override_allowed", IsRequired = false, EmitDefaultValue = false)]
            public bool? IsOverrideAllowed { get; set; }

            [DataMember(
                Name = "max_override_period_minutes",
                IsRequired = false,
                EmitDefaultValue = false
            )]
            public int? MaxOverridePeriodMinutes { get; set; }

            [DataMember(Name = "name", IsRequired = false, EmitDefaultValue = false)]
            public string? Name { get; set; }

            [DataMember(Name = "starts_at", IsRequired = true, EmitDefaultValue = false)]
            public string StartsAt { get; set; }

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

            public CreateResponse(ThermostatSchedule thermostatSchedule = default)
            {
                ThermostatSchedule = thermostatSchedule;
            }

            [DataMember(Name = "thermostat_schedule", IsRequired = false, EmitDefaultValue = false)]
            public ThermostatSchedule ThermostatSchedule { get; set; }

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

        public ThermostatSchedule Create(CreateRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            return _seam
                .Post<CreateResponse>("/thermostats/schedules/create", requestOptions)
                .Data.ThermostatSchedule;
        }

        public ThermostatSchedule Create(
            string climatePresetKey = default,
            string deviceId = default,
            string endsAt = default,
            bool? isOverrideAllowed = default,
            int? maxOverridePeriodMinutes = default,
            string? name = default,
            string startsAt = default
        )
        {
            return Create(
                new CreateRequest(
                    climatePresetKey: climatePresetKey,
                    deviceId: deviceId,
                    endsAt: endsAt,
                    isOverrideAllowed: isOverrideAllowed,
                    maxOverridePeriodMinutes: maxOverridePeriodMinutes,
                    name: name,
                    startsAt: startsAt
                )
            );
        }

        public async Task<ThermostatSchedule> CreateAsync(CreateRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            return (
                await _seam.PostAsync<CreateResponse>(
                    "/thermostats/schedules/create",
                    requestOptions
                )
            )
                .Data
                .ThermostatSchedule;
        }

        public async Task<ThermostatSchedule> CreateAsync(
            string climatePresetKey = default,
            string deviceId = default,
            string endsAt = default,
            bool? isOverrideAllowed = default,
            int? maxOverridePeriodMinutes = default,
            string? name = default,
            string startsAt = default
        )
        {
            return (
                await CreateAsync(
                    new CreateRequest(
                        climatePresetKey: climatePresetKey,
                        deviceId: deviceId,
                        endsAt: endsAt,
                        isOverrideAllowed: isOverrideAllowed,
                        maxOverridePeriodMinutes: maxOverridePeriodMinutes,
                        name: name,
                        startsAt: startsAt
                    )
                )
            );
        }

        [DataContract(Name = "deleteRequest_request")]
        public class DeleteRequest
        {
            [JsonConstructorAttribute]
            protected DeleteRequest() { }

            public DeleteRequest(string thermostatScheduleId = default)
            {
                ThermostatScheduleId = thermostatScheduleId;
            }

            [DataMember(
                Name = "thermostat_schedule_id",
                IsRequired = true,
                EmitDefaultValue = false
            )]
            public string ThermostatScheduleId { get; set; }

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
            _seam.Post<object>("/thermostats/schedules/delete", requestOptions);
        }

        public void Delete(string thermostatScheduleId = default)
        {
            Delete(new DeleteRequest(thermostatScheduleId: thermostatScheduleId));
        }

        public async Task DeleteAsync(DeleteRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            await _seam.PostAsync<object>("/thermostats/schedules/delete", requestOptions);
        }

        public async Task DeleteAsync(string thermostatScheduleId = default)
        {
            await DeleteAsync(new DeleteRequest(thermostatScheduleId: thermostatScheduleId));
        }

        [DataContract(Name = "getRequest_request")]
        public class GetRequest
        {
            [JsonConstructorAttribute]
            protected GetRequest() { }

            public GetRequest(string thermostatScheduleId = default)
            {
                ThermostatScheduleId = thermostatScheduleId;
            }

            [DataMember(
                Name = "thermostat_schedule_id",
                IsRequired = true,
                EmitDefaultValue = false
            )]
            public string ThermostatScheduleId { get; set; }

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

            public GetResponse(ThermostatSchedule thermostatSchedule = default)
            {
                ThermostatSchedule = thermostatSchedule;
            }

            [DataMember(Name = "thermostat_schedule", IsRequired = false, EmitDefaultValue = false)]
            public ThermostatSchedule ThermostatSchedule { get; set; }

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

        public ThermostatSchedule Get(GetRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            return _seam
                .Post<GetResponse>("/thermostats/schedules/get", requestOptions)
                .Data.ThermostatSchedule;
        }

        public ThermostatSchedule Get(string thermostatScheduleId = default)
        {
            return Get(new GetRequest(thermostatScheduleId: thermostatScheduleId));
        }

        public async Task<ThermostatSchedule> GetAsync(GetRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            return (
                await _seam.PostAsync<GetResponse>("/thermostats/schedules/get", requestOptions)
            )
                .Data
                .ThermostatSchedule;
        }

        public async Task<ThermostatSchedule> GetAsync(string thermostatScheduleId = default)
        {
            return (await GetAsync(new GetRequest(thermostatScheduleId: thermostatScheduleId)));
        }

        [DataContract(Name = "listRequest_request")]
        public class ListRequest
        {
            [JsonConstructorAttribute]
            protected ListRequest() { }

            public ListRequest(string deviceId = default, string? userIdentifierKey = default)
            {
                DeviceId = deviceId;
                UserIdentifierKey = userIdentifierKey;
            }

            [DataMember(Name = "device_id", IsRequired = true, EmitDefaultValue = false)]
            public string DeviceId { get; set; }

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

            public ListResponse(List<ThermostatSchedule> thermostatSchedules = default)
            {
                ThermostatSchedules = thermostatSchedules;
            }

            [DataMember(
                Name = "thermostat_schedules",
                IsRequired = false,
                EmitDefaultValue = false
            )]
            public List<ThermostatSchedule> ThermostatSchedules { get; set; }

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

        public List<ThermostatSchedule> List(ListRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            return _seam
                .Post<ListResponse>("/thermostats/schedules/list", requestOptions)
                .Data.ThermostatSchedules;
        }

        public List<ThermostatSchedule> List(
            string deviceId = default,
            string? userIdentifierKey = default
        )
        {
            return List(new ListRequest(deviceId: deviceId, userIdentifierKey: userIdentifierKey));
        }

        public async Task<List<ThermostatSchedule>> ListAsync(ListRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            return (
                await _seam.PostAsync<ListResponse>("/thermostats/schedules/list", requestOptions)
            )
                .Data
                .ThermostatSchedules;
        }

        public async Task<List<ThermostatSchedule>> ListAsync(
            string deviceId = default,
            string? userIdentifierKey = default
        )
        {
            return (
                await ListAsync(
                    new ListRequest(deviceId: deviceId, userIdentifierKey: userIdentifierKey)
                )
            );
        }

        [DataContract(Name = "updateRequest_request")]
        public class UpdateRequest
        {
            [JsonConstructorAttribute]
            protected UpdateRequest() { }

            public UpdateRequest(
                string? climatePresetKey = default,
                string? endsAt = default,
                bool? isOverrideAllowed = default,
                int? maxOverridePeriodMinutes = default,
                string? name = default,
                string? startsAt = default,
                string thermostatScheduleId = default
            )
            {
                ClimatePresetKey = climatePresetKey;
                EndsAt = endsAt;
                IsOverrideAllowed = isOverrideAllowed;
                MaxOverridePeriodMinutes = maxOverridePeriodMinutes;
                Name = name;
                StartsAt = startsAt;
                ThermostatScheduleId = thermostatScheduleId;
            }

            [DataMember(Name = "climate_preset_key", IsRequired = false, EmitDefaultValue = false)]
            public string? ClimatePresetKey { get; set; }

            [DataMember(Name = "ends_at", IsRequired = false, EmitDefaultValue = false)]
            public string? EndsAt { get; set; }

            [DataMember(Name = "is_override_allowed", IsRequired = false, EmitDefaultValue = false)]
            public bool? IsOverrideAllowed { get; set; }

            [DataMember(
                Name = "max_override_period_minutes",
                IsRequired = false,
                EmitDefaultValue = false
            )]
            public int? MaxOverridePeriodMinutes { get; set; }

            [DataMember(Name = "name", IsRequired = false, EmitDefaultValue = false)]
            public string? Name { get; set; }

            [DataMember(Name = "starts_at", IsRequired = false, EmitDefaultValue = false)]
            public string? StartsAt { get; set; }

            [DataMember(
                Name = "thermostat_schedule_id",
                IsRequired = true,
                EmitDefaultValue = false
            )]
            public string ThermostatScheduleId { get; set; }

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
            _seam.Post<object>("/thermostats/schedules/update", requestOptions);
        }

        public void Update(
            string? climatePresetKey = default,
            string? endsAt = default,
            bool? isOverrideAllowed = default,
            int? maxOverridePeriodMinutes = default,
            string? name = default,
            string? startsAt = default,
            string thermostatScheduleId = default
        )
        {
            Update(
                new UpdateRequest(
                    climatePresetKey: climatePresetKey,
                    endsAt: endsAt,
                    isOverrideAllowed: isOverrideAllowed,
                    maxOverridePeriodMinutes: maxOverridePeriodMinutes,
                    name: name,
                    startsAt: startsAt,
                    thermostatScheduleId: thermostatScheduleId
                )
            );
        }

        public async Task UpdateAsync(UpdateRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            await _seam.PostAsync<object>("/thermostats/schedules/update", requestOptions);
        }

        public async Task UpdateAsync(
            string? climatePresetKey = default,
            string? endsAt = default,
            bool? isOverrideAllowed = default,
            int? maxOverridePeriodMinutes = default,
            string? name = default,
            string? startsAt = default,
            string thermostatScheduleId = default
        )
        {
            await UpdateAsync(
                new UpdateRequest(
                    climatePresetKey: climatePresetKey,
                    endsAt: endsAt,
                    isOverrideAllowed: isOverrideAllowed,
                    maxOverridePeriodMinutes: maxOverridePeriodMinutes,
                    name: name,
                    startsAt: startsAt,
                    thermostatScheduleId: thermostatScheduleId
                )
            );
        }
    }
}

namespace Seam.Client
{
    public partial class SeamClient
    {
        public Api.SchedulesThermostats SchedulesThermostats => new(this);
    }

    public partial interface ISeamClient
    {
        public Api.SchedulesThermostats SchedulesThermostats { get; }
    }
}
