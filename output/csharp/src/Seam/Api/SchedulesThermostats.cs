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

        /// <summary>
        /// Request parameters for Create a Thermostat Schedule.
        /// </summary>
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

            /// <summary>
            /// Key of the [climate preset](https://docs.seam.co/capability-guides/thermostats/creating-and-managing-climate-presets) to use for the new thermostat schedule.
            /// </summary>
            [DataMember(Name = "climate_preset_key", IsRequired = true, EmitDefaultValue = false)]
            public string ClimatePresetKey { get; set; }

            /// <summary>
            /// ID of the thermostat device for which you want to create a schedule.
            /// </summary>
            [DataMember(Name = "device_id", IsRequired = true, EmitDefaultValue = false)]
            public string DeviceId { get; set; }

            /// <summary>
            /// Date and time at which the new thermostat schedule ends, in [ISO 8601](https://www.iso.org/iso-8601-date-and-time-format.html) format.
            /// </summary>
            [DataMember(Name = "ends_at", IsRequired = true, EmitDefaultValue = false)]
            public string EndsAt { get; set; }

            /// <summary>
            /// Indicates whether a person at the thermostat or using the API can change the thermostat&apos;s settings while the new schedule is active. See also [Specifying Manual Override Permissions](https://docs.seam.co/capability-guides/thermostats/creating-and-managing-thermostat-schedules#specifying-manual-override-permissions).
            /// </summary>
            [DataMember(Name = "is_override_allowed", IsRequired = false, EmitDefaultValue = false)]
            public bool? IsOverrideAllowed { get; set; }

            /// <summary>
            /// Number of minutes for which a person at the thermostat or using the API can change the thermostat&apos;s settings after the activation of the scheduled climate preset. See also [Specifying Manual Override Permissions](https://docs.seam.co/capability-guides/thermostats/creating-and-managing-thermostat-schedules#specifying-manual-override-permissions).
            /// </summary>
            [DataMember(
                Name = "max_override_period_minutes",
                IsRequired = false,
                EmitDefaultValue = false
            )]
            public int? MaxOverridePeriodMinutes { get; set; }

            /// <summary>
            /// Name of the thermostat schedule.
            /// </summary>
            [DataMember(Name = "name", IsRequired = false, EmitDefaultValue = false)]
            public string? Name { get; set; }

            /// <summary>
            /// Date and time at which the new thermostat schedule starts, in [ISO 8601](https://www.iso.org/iso-8601-date-and-time-format.html) format.
            /// </summary>
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

            /// <summary>
            /// OK
            /// </summary>
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

        /// <summary>
        /// Creates a new [thermostat schedule](https://docs.seam.co/capability-guides/thermostats/creating-and-managing-thermostat-schedules) for a specified [thermostat](https://docs.seam.co/capability-guides/thermostats).
        /// </summary>
        public ThermostatSchedule Create(CreateRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            return _seam
                .Post<CreateResponse>("/thermostats/schedules/create", requestOptions)
                .EnsureData("/thermostats/schedules/create")
                .ThermostatSchedule;
        }

        /// <summary>
        /// Creates a new [thermostat schedule](https://docs.seam.co/capability-guides/thermostats/creating-and-managing-thermostat-schedules) for a specified [thermostat](https://docs.seam.co/capability-guides/thermostats).
        /// </summary>
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

        /// <summary>
        /// Creates a new [thermostat schedule](https://docs.seam.co/capability-guides/thermostats/creating-and-managing-thermostat-schedules) for a specified [thermostat](https://docs.seam.co/capability-guides/thermostats).
        /// </summary>
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
                .EnsureData("/thermostats/schedules/create")
                .ThermostatSchedule;
        }

        /// <summary>
        /// Creates a new [thermostat schedule](https://docs.seam.co/capability-guides/thermostats/creating-and-managing-thermostat-schedules) for a specified [thermostat](https://docs.seam.co/capability-guides/thermostats).
        /// </summary>
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

        /// <summary>
        /// Request parameters for Delete a Thermostat Schedule.
        /// </summary>
        [DataContract(Name = "deleteRequest_request")]
        public class DeleteRequest
        {
            [JsonConstructorAttribute]
            protected DeleteRequest() { }

            public DeleteRequest(string thermostatScheduleId = default)
            {
                ThermostatScheduleId = thermostatScheduleId;
            }

            /// <summary>
            /// ID of the thermostat schedule that you want to delete.
            /// </summary>
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

        /// <summary>
        /// Deletes a [thermostat schedule](https://docs.seam.co/capability-guides/thermostats/creating-and-managing-thermostat-schedules) for a specified [thermostat](https://docs.seam.co/capability-guides/thermostats).
        /// </summary>
        public void Delete(DeleteRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            _seam.Delete<object>("/thermostats/schedules/delete", requestOptions);
        }

        /// <summary>
        /// Deletes a [thermostat schedule](https://docs.seam.co/capability-guides/thermostats/creating-and-managing-thermostat-schedules) for a specified [thermostat](https://docs.seam.co/capability-guides/thermostats).
        /// </summary>
        public void Delete(string thermostatScheduleId = default)
        {
            Delete(new DeleteRequest(thermostatScheduleId: thermostatScheduleId));
        }

        /// <summary>
        /// Deletes a [thermostat schedule](https://docs.seam.co/capability-guides/thermostats/creating-and-managing-thermostat-schedules) for a specified [thermostat](https://docs.seam.co/capability-guides/thermostats).
        /// </summary>
        public async Task DeleteAsync(DeleteRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            await _seam.DeleteAsync<object>("/thermostats/schedules/delete", requestOptions);
        }

        /// <summary>
        /// Deletes a [thermostat schedule](https://docs.seam.co/capability-guides/thermostats/creating-and-managing-thermostat-schedules) for a specified [thermostat](https://docs.seam.co/capability-guides/thermostats).
        /// </summary>
        public async Task DeleteAsync(string thermostatScheduleId = default)
        {
            await DeleteAsync(new DeleteRequest(thermostatScheduleId: thermostatScheduleId));
        }

        /// <summary>
        /// Request parameters for Get a Thermostat Schedule.
        /// </summary>
        [DataContract(Name = "getRequest_request")]
        public class GetRequest
        {
            [JsonConstructorAttribute]
            protected GetRequest() { }

            public GetRequest(string thermostatScheduleId = default)
            {
                ThermostatScheduleId = thermostatScheduleId;
            }

            /// <summary>
            /// ID of the thermostat schedule that you want to get.
            /// </summary>
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

            /// <summary>
            /// OK
            /// </summary>
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

        /// <summary>
        /// Returns a specified [thermostat schedule](https://docs.seam.co/capability-guides/thermostats/creating-and-managing-thermostat-schedules).
        /// </summary>
        public ThermostatSchedule Get(GetRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            return _seam
                .Get<GetResponse>("/thermostats/schedules/get", requestOptions)
                .EnsureData("/thermostats/schedules/get")
                .ThermostatSchedule;
        }

        /// <summary>
        /// Returns a specified [thermostat schedule](https://docs.seam.co/capability-guides/thermostats/creating-and-managing-thermostat-schedules).
        /// </summary>
        public ThermostatSchedule Get(string thermostatScheduleId = default)
        {
            return Get(new GetRequest(thermostatScheduleId: thermostatScheduleId));
        }

        /// <summary>
        /// Returns a specified [thermostat schedule](https://docs.seam.co/capability-guides/thermostats/creating-and-managing-thermostat-schedules).
        /// </summary>
        public async Task<ThermostatSchedule> GetAsync(GetRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            return (await _seam.GetAsync<GetResponse>("/thermostats/schedules/get", requestOptions))
                .EnsureData("/thermostats/schedules/get")
                .ThermostatSchedule;
        }

        /// <summary>
        /// Returns a specified [thermostat schedule](https://docs.seam.co/capability-guides/thermostats/creating-and-managing-thermostat-schedules).
        /// </summary>
        public async Task<ThermostatSchedule> GetAsync(string thermostatScheduleId = default)
        {
            return (await GetAsync(new GetRequest(thermostatScheduleId: thermostatScheduleId)));
        }

        /// <summary>
        /// Request parameters for List Thermostat Schedules.
        /// </summary>
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

            /// <summary>
            /// ID of the thermostat device for which you want to list schedules.
            /// </summary>
            [DataMember(Name = "device_id", IsRequired = true, EmitDefaultValue = false)]
            public string DeviceId { get; set; }

            /// <summary>
            /// User identifier key by which to filter the list of returned thermostat schedules.
            /// </summary>
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

            /// <summary>
            /// OK
            /// </summary>
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

        /// <summary>
        /// Returns a list of all [thermostat schedules](https://docs.seam.co/capability-guides/thermostats/creating-and-managing-thermostat-schedules) for a specified [thermostat](https://docs.seam.co/capability-guides/thermostats).
        /// </summary>
        public List<ThermostatSchedule> List(ListRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            return _seam
                .Get<ListResponse>("/thermostats/schedules/list", requestOptions)
                .EnsureData("/thermostats/schedules/list")
                .ThermostatSchedules;
        }

        /// <summary>
        /// Returns a list of all [thermostat schedules](https://docs.seam.co/capability-guides/thermostats/creating-and-managing-thermostat-schedules) for a specified [thermostat](https://docs.seam.co/capability-guides/thermostats).
        /// </summary>
        public List<ThermostatSchedule> List(
            string deviceId = default,
            string? userIdentifierKey = default
        )
        {
            return List(new ListRequest(deviceId: deviceId, userIdentifierKey: userIdentifierKey));
        }

        /// <summary>
        /// Returns a list of all [thermostat schedules](https://docs.seam.co/capability-guides/thermostats/creating-and-managing-thermostat-schedules) for a specified [thermostat](https://docs.seam.co/capability-guides/thermostats).
        /// </summary>
        public async Task<List<ThermostatSchedule>> ListAsync(ListRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            return (
                await _seam.GetAsync<ListResponse>("/thermostats/schedules/list", requestOptions)
            )
                .EnsureData("/thermostats/schedules/list")
                .ThermostatSchedules;
        }

        /// <summary>
        /// Returns a list of all [thermostat schedules](https://docs.seam.co/capability-guides/thermostats/creating-and-managing-thermostat-schedules) for a specified [thermostat](https://docs.seam.co/capability-guides/thermostats).
        /// </summary>
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

        /// <summary>
        /// Request parameters for Update a Thermostat Schedule.
        /// </summary>
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

            /// <summary>
            /// Key of the [climate preset](https://docs.seam.co/capability-guides/thermostats/creating-and-managing-climate-presets) to use for the thermostat schedule.
            /// </summary>
            [DataMember(Name = "climate_preset_key", IsRequired = false, EmitDefaultValue = false)]
            public string? ClimatePresetKey { get; set; }

            /// <summary>
            /// Date and time at which the thermostat schedule ends, in [ISO 8601](https://www.iso.org/iso-8601-date-and-time-format.html) format.
            /// </summary>
            [DataMember(Name = "ends_at", IsRequired = false, EmitDefaultValue = false)]
            public string? EndsAt { get; set; }

            /// <summary>
            /// Indicates whether a person at the thermostat or using the API can change the thermostat&apos;s settings while the schedule is active. See also [Specifying Manual Override Permissions](https://docs.seam.co/capability-guides/thermostats/creating-and-managing-thermostat-schedules#specifying-manual-override-permissions).
            /// </summary>
            [DataMember(Name = "is_override_allowed", IsRequired = false, EmitDefaultValue = false)]
            public bool? IsOverrideAllowed { get; set; }

            /// <summary>
            /// Number of minutes for which a person at the thermostat or using the API can change the thermostat&apos;s settings after the activation of the scheduled climate preset. See also [Specifying Manual Override Permissions](https://docs.seam.co/capability-guides/thermostats/creating-and-managing-thermostat-schedules#specifying-manual-override-permissions).
            /// </summary>
            [DataMember(
                Name = "max_override_period_minutes",
                IsRequired = false,
                EmitDefaultValue = false
            )]
            public int? MaxOverridePeriodMinutes { get; set; }

            /// <summary>
            /// Name of the thermostat schedule.
            /// </summary>
            [DataMember(Name = "name", IsRequired = false, EmitDefaultValue = false)]
            public string? Name { get; set; }

            /// <summary>
            /// Date and time at which the thermostat schedule starts, in [ISO 8601](https://www.iso.org/iso-8601-date-and-time-format.html) format.
            /// </summary>
            [DataMember(Name = "starts_at", IsRequired = false, EmitDefaultValue = false)]
            public string? StartsAt { get; set; }

            /// <summary>
            /// ID of the thermostat schedule that you want to update.
            /// </summary>
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

        /// <summary>
        /// Updates a specified [thermostat schedule](https://docs.seam.co/capability-guides/thermostats/creating-and-managing-thermostat-schedules).
        /// </summary>
        public void Update(UpdateRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            _seam.Patch<object>("/thermostats/schedules/update", requestOptions);
        }

        /// <summary>
        /// Updates a specified [thermostat schedule](https://docs.seam.co/capability-guides/thermostats/creating-and-managing-thermostat-schedules).
        /// </summary>
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

        /// <summary>
        /// Updates a specified [thermostat schedule](https://docs.seam.co/capability-guides/thermostats/creating-and-managing-thermostat-schedules).
        /// </summary>
        public async Task UpdateAsync(UpdateRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            await _seam.PatchAsync<object>("/thermostats/schedules/update", requestOptions);
        }

        /// <summary>
        /// Updates a specified [thermostat schedule](https://docs.seam.co/capability-guides/thermostats/creating-and-managing-thermostat-schedules).
        /// </summary>
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
