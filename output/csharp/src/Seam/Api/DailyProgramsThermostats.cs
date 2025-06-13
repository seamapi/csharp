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
    public class DailyProgramsThermostats
    {
        private ISeamClient _seam;

        public DailyProgramsThermostats(ISeamClient seam)
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
                string name = default,
                List<CreateRequestPeriods> periods = default
            )
            {
                DeviceId = deviceId;
                Name = name;
                Periods = periods;
            }

            [DataMember(Name = "device_id", IsRequired = true, EmitDefaultValue = false)]
            public string DeviceId { get; set; }

            [DataMember(Name = "name", IsRequired = true, EmitDefaultValue = false)]
            public string Name { get; set; }

            [DataMember(Name = "periods", IsRequired = true, EmitDefaultValue = false)]
            public List<CreateRequestPeriods> Periods { get; set; }

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

        [DataContract(Name = "createRequestPeriods_model")]
        public class CreateRequestPeriods
        {
            [JsonConstructorAttribute]
            protected CreateRequestPeriods() { }

            public CreateRequestPeriods(
                string climatePresetKey = default,
                string startsAtTime = default
            )
            {
                ClimatePresetKey = climatePresetKey;
                StartsAtTime = startsAtTime;
            }

            [DataMember(Name = "climate_preset_key", IsRequired = true, EmitDefaultValue = false)]
            public string ClimatePresetKey { get; set; }

            [DataMember(Name = "starts_at_time", IsRequired = true, EmitDefaultValue = false)]
            public string StartsAtTime { get; set; }

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

            public CreateResponse(ThermostatDailyProgram thermostatDailyProgram = default)
            {
                ThermostatDailyProgram = thermostatDailyProgram;
            }

            [DataMember(
                Name = "thermostat_daily_program",
                IsRequired = false,
                EmitDefaultValue = false
            )]
            public ThermostatDailyProgram ThermostatDailyProgram { get; set; }

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

        public ThermostatDailyProgram Create(CreateRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            return _seam
                .Post<CreateResponse>("/thermostats/daily_programs/create", requestOptions)
                .Data.ThermostatDailyProgram;
        }

        public ThermostatDailyProgram Create(
            string deviceId = default,
            string name = default,
            List<CreateRequestPeriods> periods = default
        )
        {
            return Create(new CreateRequest(deviceId: deviceId, name: name, periods: periods));
        }

        public async Task<ThermostatDailyProgram> CreateAsync(CreateRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            return (
                await _seam.PostAsync<CreateResponse>(
                    "/thermostats/daily_programs/create",
                    requestOptions
                )
            )
                .Data
                .ThermostatDailyProgram;
        }

        public async Task<ThermostatDailyProgram> CreateAsync(
            string deviceId = default,
            string name = default,
            List<CreateRequestPeriods> periods = default
        )
        {
            return (
                await CreateAsync(
                    new CreateRequest(deviceId: deviceId, name: name, periods: periods)
                )
            );
        }

        [DataContract(Name = "deleteRequest_request")]
        public class DeleteRequest
        {
            [JsonConstructorAttribute]
            protected DeleteRequest() { }

            public DeleteRequest(string thermostatDailyProgramId = default)
            {
                ThermostatDailyProgramId = thermostatDailyProgramId;
            }

            [DataMember(
                Name = "thermostat_daily_program_id",
                IsRequired = true,
                EmitDefaultValue = false
            )]
            public string ThermostatDailyProgramId { get; set; }

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
            _seam.Post<object>("/thermostats/daily_programs/delete", requestOptions);
        }

        public void Delete(string thermostatDailyProgramId = default)
        {
            Delete(new DeleteRequest(thermostatDailyProgramId: thermostatDailyProgramId));
        }

        public async Task DeleteAsync(DeleteRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            await _seam.PostAsync<object>("/thermostats/daily_programs/delete", requestOptions);
        }

        public async Task DeleteAsync(string thermostatDailyProgramId = default)
        {
            await DeleteAsync(
                new DeleteRequest(thermostatDailyProgramId: thermostatDailyProgramId)
            );
        }

        [DataContract(Name = "updateRequest_request")]
        public class UpdateRequest
        {
            [JsonConstructorAttribute]
            protected UpdateRequest() { }

            public UpdateRequest(
                string name = default,
                List<UpdateRequestPeriods> periods = default,
                string thermostatDailyProgramId = default
            )
            {
                Name = name;
                Periods = periods;
                ThermostatDailyProgramId = thermostatDailyProgramId;
            }

            [DataMember(Name = "name", IsRequired = true, EmitDefaultValue = false)]
            public string Name { get; set; }

            [DataMember(Name = "periods", IsRequired = true, EmitDefaultValue = false)]
            public List<UpdateRequestPeriods> Periods { get; set; }

            [DataMember(
                Name = "thermostat_daily_program_id",
                IsRequired = true,
                EmitDefaultValue = false
            )]
            public string ThermostatDailyProgramId { get; set; }

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

        [DataContract(Name = "updateRequestPeriods_model")]
        public class UpdateRequestPeriods
        {
            [JsonConstructorAttribute]
            protected UpdateRequestPeriods() { }

            public UpdateRequestPeriods(
                string climatePresetKey = default,
                string startsAtTime = default
            )
            {
                ClimatePresetKey = climatePresetKey;
                StartsAtTime = startsAtTime;
            }

            [DataMember(Name = "climate_preset_key", IsRequired = true, EmitDefaultValue = false)]
            public string ClimatePresetKey { get; set; }

            [DataMember(Name = "starts_at_time", IsRequired = true, EmitDefaultValue = false)]
            public string StartsAtTime { get; set; }

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

            public UpdateResponse(ActionAttempt actionAttempt = default)
            {
                ActionAttempt = actionAttempt;
            }

            [DataMember(Name = "action_attempt", IsRequired = false, EmitDefaultValue = false)]
            public ActionAttempt ActionAttempt { get; set; }

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

        public ActionAttempt Update(UpdateRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            return _seam
                .Post<UpdateResponse>("/thermostats/daily_programs/update", requestOptions)
                .Data.ActionAttempt;
        }

        public ActionAttempt Update(
            string name = default,
            List<UpdateRequestPeriods> periods = default,
            string thermostatDailyProgramId = default
        )
        {
            return Update(
                new UpdateRequest(
                    name: name,
                    periods: periods,
                    thermostatDailyProgramId: thermostatDailyProgramId
                )
            );
        }

        public async Task<ActionAttempt> UpdateAsync(UpdateRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            return (
                await _seam.PostAsync<UpdateResponse>(
                    "/thermostats/daily_programs/update",
                    requestOptions
                )
            )
                .Data
                .ActionAttempt;
        }

        public async Task<ActionAttempt> UpdateAsync(
            string name = default,
            List<UpdateRequestPeriods> periods = default,
            string thermostatDailyProgramId = default
        )
        {
            return (
                await UpdateAsync(
                    new UpdateRequest(
                        name: name,
                        periods: periods,
                        thermostatDailyProgramId: thermostatDailyProgramId
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
        public Api.DailyProgramsThermostats DailyProgramsThermostats => new(this);
    }

    public partial interface ISeamClient
    {
        public Api.DailyProgramsThermostats DailyProgramsThermostats { get; }
    }
}
