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
    public class ClimateSettingSchedulesThermostats
    {
        private ISeamClient _seam;

        public ClimateSettingSchedulesThermostats(ISeamClient seam)
        {
            _seam = seam;
        }

        [DataContract(Name = "createRequest_request")]
        public class CreateRequest
        {
            [JsonConstructorAttribute]
            protected CreateRequest() { }

            public CreateRequest(
                CreateRequest.ScheduleTypeEnum? scheduleType = default,
                string deviceId = default,
                string? name = default,
                string scheduleStartsAt = default,
                string scheduleEndsAt = default,
                bool? automaticHeatingEnabled = default,
                bool? automaticCoolingEnabled = default,
                CreateRequest.HvacModeSettingEnum? hvacModeSetting = default,
                float? coolingSetPointCelsius = default,
                float? heatingSetPointCelsius = default,
                float? coolingSetPointFahrenheit = default,
                float? heatingSetPointFahrenheit = default,
                bool? manualOverrideAllowed = default
            )
            {
                ScheduleType = scheduleType;
                DeviceId = deviceId;
                Name = name;
                ScheduleStartsAt = scheduleStartsAt;
                ScheduleEndsAt = scheduleEndsAt;
                AutomaticHeatingEnabled = automaticHeatingEnabled;
                AutomaticCoolingEnabled = automaticCoolingEnabled;
                HvacModeSetting = hvacModeSetting;
                CoolingSetPointCelsius = coolingSetPointCelsius;
                HeatingSetPointCelsius = heatingSetPointCelsius;
                CoolingSetPointFahrenheit = coolingSetPointFahrenheit;
                HeatingSetPointFahrenheit = heatingSetPointFahrenheit;
                ManualOverrideAllowed = manualOverrideAllowed;
            }

            [JsonConverter(typeof(StringEnumConverter))]
            public enum ScheduleTypeEnum
            {
                [EnumMember(Value = "time_bound")]
                TimeBound = 0,
            }

            [JsonConverter(typeof(StringEnumConverter))]
            public enum HvacModeSettingEnum
            {
                [EnumMember(Value = "off")]
                Off = 0,

                [EnumMember(Value = "heat")]
                Heat = 1,

                [EnumMember(Value = "cool")]
                Cool = 2,

                [EnumMember(Value = "heat_cool")]
                HeatCool = 3,
            }

            [DataMember(Name = "schedule_type", IsRequired = false, EmitDefaultValue = false)]
            public CreateRequest.ScheduleTypeEnum? ScheduleType { get; set; }

            [DataMember(Name = "device_id", IsRequired = true, EmitDefaultValue = false)]
            public string DeviceId { get; set; }

            [DataMember(Name = "name", IsRequired = false, EmitDefaultValue = false)]
            public string? Name { get; set; }

            [DataMember(Name = "schedule_starts_at", IsRequired = true, EmitDefaultValue = false)]
            public string ScheduleStartsAt { get; set; }

            [DataMember(Name = "schedule_ends_at", IsRequired = true, EmitDefaultValue = false)]
            public string ScheduleEndsAt { get; set; }

            [DataMember(
                Name = "automatic_heating_enabled",
                IsRequired = false,
                EmitDefaultValue = false
            )]
            public bool? AutomaticHeatingEnabled { get; set; }

            [DataMember(
                Name = "automatic_cooling_enabled",
                IsRequired = false,
                EmitDefaultValue = false
            )]
            public bool? AutomaticCoolingEnabled { get; set; }

            [DataMember(Name = "hvac_mode_setting", IsRequired = false, EmitDefaultValue = false)]
            public CreateRequest.HvacModeSettingEnum? HvacModeSetting { get; set; }

            [DataMember(
                Name = "cooling_set_point_celsius",
                IsRequired = false,
                EmitDefaultValue = false
            )]
            public float? CoolingSetPointCelsius { get; set; }

            [DataMember(
                Name = "heating_set_point_celsius",
                IsRequired = false,
                EmitDefaultValue = false
            )]
            public float? HeatingSetPointCelsius { get; set; }

            [DataMember(
                Name = "cooling_set_point_fahrenheit",
                IsRequired = false,
                EmitDefaultValue = false
            )]
            public float? CoolingSetPointFahrenheit { get; set; }

            [DataMember(
                Name = "heating_set_point_fahrenheit",
                IsRequired = false,
                EmitDefaultValue = false
            )]
            public float? HeatingSetPointFahrenheit { get; set; }

            [DataMember(
                Name = "manual_override_allowed",
                IsRequired = false,
                EmitDefaultValue = false
            )]
            public bool? ManualOverrideAllowed { get; set; }

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

            public CreateResponse(ClimateSettingSchedule climateSettingSchedule = default)
            {
                ClimateSettingSchedule = climateSettingSchedule;
            }

            [DataMember(
                Name = "climate_setting_schedule",
                IsRequired = false,
                EmitDefaultValue = false
            )]
            public ClimateSettingSchedule ClimateSettingSchedule { get; set; }

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

        public ClimateSettingSchedule Create(CreateRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            return _seam
                .Post<CreateResponse>(
                    "/thermostats/climate_setting_schedules/create",
                    requestOptions
                )
                .Data.ClimateSettingSchedule;
        }

        public ClimateSettingSchedule Create(
            CreateRequest.ScheduleTypeEnum? scheduleType = default,
            string deviceId = default,
            string? name = default,
            string scheduleStartsAt = default,
            string scheduleEndsAt = default,
            bool? automaticHeatingEnabled = default,
            bool? automaticCoolingEnabled = default,
            CreateRequest.HvacModeSettingEnum? hvacModeSetting = default,
            float? coolingSetPointCelsius = default,
            float? heatingSetPointCelsius = default,
            float? coolingSetPointFahrenheit = default,
            float? heatingSetPointFahrenheit = default,
            bool? manualOverrideAllowed = default
        )
        {
            return Create(
                new CreateRequest(
                    scheduleType: scheduleType,
                    deviceId: deviceId,
                    name: name,
                    scheduleStartsAt: scheduleStartsAt,
                    scheduleEndsAt: scheduleEndsAt,
                    automaticHeatingEnabled: automaticHeatingEnabled,
                    automaticCoolingEnabled: automaticCoolingEnabled,
                    hvacModeSetting: hvacModeSetting,
                    coolingSetPointCelsius: coolingSetPointCelsius,
                    heatingSetPointCelsius: heatingSetPointCelsius,
                    coolingSetPointFahrenheit: coolingSetPointFahrenheit,
                    heatingSetPointFahrenheit: heatingSetPointFahrenheit,
                    manualOverrideAllowed: manualOverrideAllowed
                )
            );
        }

        public async Task<ClimateSettingSchedule> CreateAsync(CreateRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            return (
                await _seam.PostAsync<CreateResponse>(
                    "/thermostats/climate_setting_schedules/create",
                    requestOptions
                )
            )
                .Data
                .ClimateSettingSchedule;
        }

        public async Task<ClimateSettingSchedule> CreateAsync(
            CreateRequest.ScheduleTypeEnum? scheduleType = default,
            string deviceId = default,
            string? name = default,
            string scheduleStartsAt = default,
            string scheduleEndsAt = default,
            bool? automaticHeatingEnabled = default,
            bool? automaticCoolingEnabled = default,
            CreateRequest.HvacModeSettingEnum? hvacModeSetting = default,
            float? coolingSetPointCelsius = default,
            float? heatingSetPointCelsius = default,
            float? coolingSetPointFahrenheit = default,
            float? heatingSetPointFahrenheit = default,
            bool? manualOverrideAllowed = default
        )
        {
            return (
                await CreateAsync(
                    new CreateRequest(
                        scheduleType: scheduleType,
                        deviceId: deviceId,
                        name: name,
                        scheduleStartsAt: scheduleStartsAt,
                        scheduleEndsAt: scheduleEndsAt,
                        automaticHeatingEnabled: automaticHeatingEnabled,
                        automaticCoolingEnabled: automaticCoolingEnabled,
                        hvacModeSetting: hvacModeSetting,
                        coolingSetPointCelsius: coolingSetPointCelsius,
                        heatingSetPointCelsius: heatingSetPointCelsius,
                        coolingSetPointFahrenheit: coolingSetPointFahrenheit,
                        heatingSetPointFahrenheit: heatingSetPointFahrenheit,
                        manualOverrideAllowed: manualOverrideAllowed
                    )
                )
            );
        }

        [DataContract(Name = "deleteRequest_request")]
        public class DeleteRequest
        {
            [JsonConstructorAttribute]
            protected DeleteRequest() { }

            public DeleteRequest(string climateSettingScheduleId = default)
            {
                ClimateSettingScheduleId = climateSettingScheduleId;
            }

            [DataMember(
                Name = "climate_setting_schedule_id",
                IsRequired = true,
                EmitDefaultValue = false
            )]
            public string ClimateSettingScheduleId { get; set; }

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
            _seam.Post<object>("/thermostats/climate_setting_schedules/delete", requestOptions);
        }

        public void Delete(string climateSettingScheduleId = default)
        {
            Delete(new DeleteRequest(climateSettingScheduleId: climateSettingScheduleId));
        }

        public async Task DeleteAsync(DeleteRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            await _seam.PostAsync<object>(
                "/thermostats/climate_setting_schedules/delete",
                requestOptions
            );
        }

        public async Task DeleteAsync(string climateSettingScheduleId = default)
        {
            await DeleteAsync(
                new DeleteRequest(climateSettingScheduleId: climateSettingScheduleId)
            );
        }

        [DataContract(Name = "getRequest_request")]
        public class GetRequest
        {
            [JsonConstructorAttribute]
            protected GetRequest() { }

            public GetRequest(
                string? climateSettingScheduleId = default,
                string? deviceId = default
            )
            {
                ClimateSettingScheduleId = climateSettingScheduleId;
                DeviceId = deviceId;
            }

            [DataMember(
                Name = "climate_setting_schedule_id",
                IsRequired = false,
                EmitDefaultValue = false
            )]
            public string? ClimateSettingScheduleId { get; set; }

            [DataMember(Name = "device_id", IsRequired = false, EmitDefaultValue = false)]
            public string? DeviceId { get; set; }

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

            public GetResponse(ClimateSettingSchedule climateSettingSchedule = default)
            {
                ClimateSettingSchedule = climateSettingSchedule;
            }

            [DataMember(
                Name = "climate_setting_schedule",
                IsRequired = false,
                EmitDefaultValue = false
            )]
            public ClimateSettingSchedule ClimateSettingSchedule { get; set; }

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

        public ClimateSettingSchedule Get(GetRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            return _seam
                .Post<GetResponse>("/thermostats/climate_setting_schedules/get", requestOptions)
                .Data.ClimateSettingSchedule;
        }

        public ClimateSettingSchedule Get(
            string? climateSettingScheduleId = default,
            string? deviceId = default
        )
        {
            return Get(
                new GetRequest(
                    climateSettingScheduleId: climateSettingScheduleId,
                    deviceId: deviceId
                )
            );
        }

        public async Task<ClimateSettingSchedule> GetAsync(GetRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            return (
                await _seam.PostAsync<GetResponse>(
                    "/thermostats/climate_setting_schedules/get",
                    requestOptions
                )
            )
                .Data
                .ClimateSettingSchedule;
        }

        public async Task<ClimateSettingSchedule> GetAsync(
            string? climateSettingScheduleId = default,
            string? deviceId = default
        )
        {
            return (
                await GetAsync(
                    new GetRequest(
                        climateSettingScheduleId: climateSettingScheduleId,
                        deviceId: deviceId
                    )
                )
            );
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

            public ListResponse(List<ClimateSettingSchedule> climateSettingSchedules = default)
            {
                ClimateSettingSchedules = climateSettingSchedules;
            }

            [DataMember(
                Name = "climate_setting_schedules",
                IsRequired = false,
                EmitDefaultValue = false
            )]
            public List<ClimateSettingSchedule> ClimateSettingSchedules { get; set; }

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

        public List<ClimateSettingSchedule> List(ListRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            return _seam
                .Post<ListResponse>("/thermostats/climate_setting_schedules/list", requestOptions)
                .Data.ClimateSettingSchedules;
        }

        public List<ClimateSettingSchedule> List(
            string deviceId = default,
            string? userIdentifierKey = default
        )
        {
            return List(new ListRequest(deviceId: deviceId, userIdentifierKey: userIdentifierKey));
        }

        public async Task<List<ClimateSettingSchedule>> ListAsync(ListRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            return (
                await _seam.PostAsync<ListResponse>(
                    "/thermostats/climate_setting_schedules/list",
                    requestOptions
                )
            )
                .Data
                .ClimateSettingSchedules;
        }

        public async Task<List<ClimateSettingSchedule>> ListAsync(
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
                string climateSettingScheduleId = default,
                UpdateRequest.ScheduleTypeEnum? scheduleType = default,
                string? name = default,
                string? scheduleStartsAt = default,
                string? scheduleEndsAt = default,
                bool? automaticHeatingEnabled = default,
                bool? automaticCoolingEnabled = default,
                UpdateRequest.HvacModeSettingEnum? hvacModeSetting = default,
                float? coolingSetPointCelsius = default,
                float? heatingSetPointCelsius = default,
                float? coolingSetPointFahrenheit = default,
                float? heatingSetPointFahrenheit = default,
                bool? manualOverrideAllowed = default
            )
            {
                ClimateSettingScheduleId = climateSettingScheduleId;
                ScheduleType = scheduleType;
                Name = name;
                ScheduleStartsAt = scheduleStartsAt;
                ScheduleEndsAt = scheduleEndsAt;
                AutomaticHeatingEnabled = automaticHeatingEnabled;
                AutomaticCoolingEnabled = automaticCoolingEnabled;
                HvacModeSetting = hvacModeSetting;
                CoolingSetPointCelsius = coolingSetPointCelsius;
                HeatingSetPointCelsius = heatingSetPointCelsius;
                CoolingSetPointFahrenheit = coolingSetPointFahrenheit;
                HeatingSetPointFahrenheit = heatingSetPointFahrenheit;
                ManualOverrideAllowed = manualOverrideAllowed;
            }

            [JsonConverter(typeof(StringEnumConverter))]
            public enum ScheduleTypeEnum
            {
                [EnumMember(Value = "time_bound")]
                TimeBound = 0,
            }

            [JsonConverter(typeof(StringEnumConverter))]
            public enum HvacModeSettingEnum
            {
                [EnumMember(Value = "off")]
                Off = 0,

                [EnumMember(Value = "heat")]
                Heat = 1,

                [EnumMember(Value = "cool")]
                Cool = 2,

                [EnumMember(Value = "heat_cool")]
                HeatCool = 3,
            }

            [DataMember(
                Name = "climate_setting_schedule_id",
                IsRequired = true,
                EmitDefaultValue = false
            )]
            public string ClimateSettingScheduleId { get; set; }

            [DataMember(Name = "schedule_type", IsRequired = false, EmitDefaultValue = false)]
            public UpdateRequest.ScheduleTypeEnum? ScheduleType { get; set; }

            [DataMember(Name = "name", IsRequired = false, EmitDefaultValue = false)]
            public string? Name { get; set; }

            [DataMember(Name = "schedule_starts_at", IsRequired = false, EmitDefaultValue = false)]
            public string? ScheduleStartsAt { get; set; }

            [DataMember(Name = "schedule_ends_at", IsRequired = false, EmitDefaultValue = false)]
            public string? ScheduleEndsAt { get; set; }

            [DataMember(
                Name = "automatic_heating_enabled",
                IsRequired = false,
                EmitDefaultValue = false
            )]
            public bool? AutomaticHeatingEnabled { get; set; }

            [DataMember(
                Name = "automatic_cooling_enabled",
                IsRequired = false,
                EmitDefaultValue = false
            )]
            public bool? AutomaticCoolingEnabled { get; set; }

            [DataMember(Name = "hvac_mode_setting", IsRequired = false, EmitDefaultValue = false)]
            public UpdateRequest.HvacModeSettingEnum? HvacModeSetting { get; set; }

            [DataMember(
                Name = "cooling_set_point_celsius",
                IsRequired = false,
                EmitDefaultValue = false
            )]
            public float? CoolingSetPointCelsius { get; set; }

            [DataMember(
                Name = "heating_set_point_celsius",
                IsRequired = false,
                EmitDefaultValue = false
            )]
            public float? HeatingSetPointCelsius { get; set; }

            [DataMember(
                Name = "cooling_set_point_fahrenheit",
                IsRequired = false,
                EmitDefaultValue = false
            )]
            public float? CoolingSetPointFahrenheit { get; set; }

            [DataMember(
                Name = "heating_set_point_fahrenheit",
                IsRequired = false,
                EmitDefaultValue = false
            )]
            public float? HeatingSetPointFahrenheit { get; set; }

            [DataMember(
                Name = "manual_override_allowed",
                IsRequired = false,
                EmitDefaultValue = false
            )]
            public bool? ManualOverrideAllowed { get; set; }

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

        [DataContract(Name = "updateResponse_response")]
        public class UpdateResponse
        {
            [JsonConstructorAttribute]
            protected UpdateResponse() { }

            public UpdateResponse(ClimateSettingSchedule climateSettingSchedule = default)
            {
                ClimateSettingSchedule = climateSettingSchedule;
            }

            [DataMember(
                Name = "climate_setting_schedule",
                IsRequired = false,
                EmitDefaultValue = false
            )]
            public ClimateSettingSchedule ClimateSettingSchedule { get; set; }

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

        public ClimateSettingSchedule Update(UpdateRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            return _seam
                .Post<UpdateResponse>(
                    "/thermostats/climate_setting_schedules/update",
                    requestOptions
                )
                .Data.ClimateSettingSchedule;
        }

        public ClimateSettingSchedule Update(
            string climateSettingScheduleId = default,
            UpdateRequest.ScheduleTypeEnum? scheduleType = default,
            string? name = default,
            string? scheduleStartsAt = default,
            string? scheduleEndsAt = default,
            bool? automaticHeatingEnabled = default,
            bool? automaticCoolingEnabled = default,
            UpdateRequest.HvacModeSettingEnum? hvacModeSetting = default,
            float? coolingSetPointCelsius = default,
            float? heatingSetPointCelsius = default,
            float? coolingSetPointFahrenheit = default,
            float? heatingSetPointFahrenheit = default,
            bool? manualOverrideAllowed = default
        )
        {
            return Update(
                new UpdateRequest(
                    climateSettingScheduleId: climateSettingScheduleId,
                    scheduleType: scheduleType,
                    name: name,
                    scheduleStartsAt: scheduleStartsAt,
                    scheduleEndsAt: scheduleEndsAt,
                    automaticHeatingEnabled: automaticHeatingEnabled,
                    automaticCoolingEnabled: automaticCoolingEnabled,
                    hvacModeSetting: hvacModeSetting,
                    coolingSetPointCelsius: coolingSetPointCelsius,
                    heatingSetPointCelsius: heatingSetPointCelsius,
                    coolingSetPointFahrenheit: coolingSetPointFahrenheit,
                    heatingSetPointFahrenheit: heatingSetPointFahrenheit,
                    manualOverrideAllowed: manualOverrideAllowed
                )
            );
        }

        public async Task<ClimateSettingSchedule> UpdateAsync(UpdateRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            return (
                await _seam.PostAsync<UpdateResponse>(
                    "/thermostats/climate_setting_schedules/update",
                    requestOptions
                )
            )
                .Data
                .ClimateSettingSchedule;
        }

        public async Task<ClimateSettingSchedule> UpdateAsync(
            string climateSettingScheduleId = default,
            UpdateRequest.ScheduleTypeEnum? scheduleType = default,
            string? name = default,
            string? scheduleStartsAt = default,
            string? scheduleEndsAt = default,
            bool? automaticHeatingEnabled = default,
            bool? automaticCoolingEnabled = default,
            UpdateRequest.HvacModeSettingEnum? hvacModeSetting = default,
            float? coolingSetPointCelsius = default,
            float? heatingSetPointCelsius = default,
            float? coolingSetPointFahrenheit = default,
            float? heatingSetPointFahrenheit = default,
            bool? manualOverrideAllowed = default
        )
        {
            return (
                await UpdateAsync(
                    new UpdateRequest(
                        climateSettingScheduleId: climateSettingScheduleId,
                        scheduleType: scheduleType,
                        name: name,
                        scheduleStartsAt: scheduleStartsAt,
                        scheduleEndsAt: scheduleEndsAt,
                        automaticHeatingEnabled: automaticHeatingEnabled,
                        automaticCoolingEnabled: automaticCoolingEnabled,
                        hvacModeSetting: hvacModeSetting,
                        coolingSetPointCelsius: coolingSetPointCelsius,
                        heatingSetPointCelsius: heatingSetPointCelsius,
                        coolingSetPointFahrenheit: coolingSetPointFahrenheit,
                        heatingSetPointFahrenheit: heatingSetPointFahrenheit,
                        manualOverrideAllowed: manualOverrideAllowed
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
        public Api.ClimateSettingSchedulesThermostats ClimateSettingSchedulesThermostats =>
            new(this);
    }

    public partial interface ISeamClient
    {
        public Api.ClimateSettingSchedulesThermostats ClimateSettingSchedulesThermostats { get; }
    }
}
