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

        /// <summary>
        /// Request parameters for Create a Thermostat Daily Program.
        /// </summary>
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

            /// <summary>
            /// ID of the thermostat device for which you want to create a daily program.
            /// </summary>
            [DataMember(Name = "device_id", IsRequired = true, EmitDefaultValue = false)]
            public string DeviceId { get; set; }

            /// <summary>
            /// Name of the thermostat daily program.
            /// </summary>
            [DataMember(Name = "name", IsRequired = true, EmitDefaultValue = false)]
            public string Name { get; set; }

            /// <summary>
            /// Array of thermostat daily program periods.
            /// </summary>
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
                string? climatePresetKey = default,
                string? startsAtTime = default
            )
            {
                ClimatePresetKey = climatePresetKey;
                StartsAtTime = startsAtTime;
            }

            /// <summary>
            /// Key of the [climate preset](https://docs.seam.co/capability-guides/thermostats/creating-and-managing-climate-presets) to activate at the `starts_at_time`.
            /// </summary>
            [DataMember(Name = "climate_preset_key", IsRequired = false, EmitDefaultValue = false)]
            public string? ClimatePresetKey { get; set; }

            /// <summary>
            /// Time at which the thermostat daily program period starts, in [ISO 8601](https://www.iso.org/iso-8601-date-and-time-format.html) format.
            /// </summary>
            [DataMember(Name = "starts_at_time", IsRequired = false, EmitDefaultValue = false)]
            public string? StartsAtTime { get; set; }

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

            /// <summary>
            /// OK
            /// </summary>
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

        /// <summary>
        /// Creates a new thermostat daily program. A daily program consists of a set of periods, where each period includes a start time and the key of a configured climate preset. Once you have defined a daily program, you can assign it to one or more days within a weekly program.
        /// </summary>
        public ThermostatDailyProgram Create(CreateRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            return _seam
                .Post<CreateResponse>("/thermostats/daily_programs/create", requestOptions)
                .EnsureData("/thermostats/daily_programs/create")
                .ThermostatDailyProgram;
        }

        /// <summary>
        /// Creates a new thermostat daily program. A daily program consists of a set of periods, where each period includes a start time and the key of a configured climate preset. Once you have defined a daily program, you can assign it to one or more days within a weekly program.
        /// </summary>
        public ThermostatDailyProgram Create(
            string deviceId = default,
            string name = default,
            List<CreateRequestPeriods> periods = default
        )
        {
            return Create(new CreateRequest(deviceId: deviceId, name: name, periods: periods));
        }

        /// <summary>
        /// Creates a new thermostat daily program. A daily program consists of a set of periods, where each period includes a start time and the key of a configured climate preset. Once you have defined a daily program, you can assign it to one or more days within a weekly program.
        /// </summary>
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
                .EnsureData("/thermostats/daily_programs/create")
                .ThermostatDailyProgram;
        }

        /// <summary>
        /// Creates a new thermostat daily program. A daily program consists of a set of periods, where each period includes a start time and the key of a configured climate preset. Once you have defined a daily program, you can assign it to one or more days within a weekly program.
        /// </summary>
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

        /// <summary>
        /// Request parameters for Delete a Thermostat Daily Program.
        /// </summary>
        [DataContract(Name = "deleteRequest_request")]
        public class DeleteRequest
        {
            [JsonConstructorAttribute]
            protected DeleteRequest() { }

            public DeleteRequest(string thermostatDailyProgramId = default)
            {
                ThermostatDailyProgramId = thermostatDailyProgramId;
            }

            /// <summary>
            /// ID of the thermostat daily program that you want to delete.
            /// </summary>
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

        /// <summary>
        /// Deletes a thermostat daily program.
        /// </summary>
        public void Delete(DeleteRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            _seam.Delete<object>("/thermostats/daily_programs/delete", requestOptions);
        }

        /// <summary>
        /// Deletes a thermostat daily program.
        /// </summary>
        public void Delete(string thermostatDailyProgramId = default)
        {
            Delete(new DeleteRequest(thermostatDailyProgramId: thermostatDailyProgramId));
        }

        /// <summary>
        /// Deletes a thermostat daily program.
        /// </summary>
        public async Task DeleteAsync(DeleteRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            await _seam.DeleteAsync<object>("/thermostats/daily_programs/delete", requestOptions);
        }

        /// <summary>
        /// Deletes a thermostat daily program.
        /// </summary>
        public async Task DeleteAsync(string thermostatDailyProgramId = default)
        {
            await DeleteAsync(
                new DeleteRequest(thermostatDailyProgramId: thermostatDailyProgramId)
            );
        }

        /// <summary>
        /// Request parameters for Update a Thermostat Daily Program.
        /// </summary>
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

            /// <summary>
            /// Name of the thermostat daily program that you want to update.
            /// </summary>
            [DataMember(Name = "name", IsRequired = true, EmitDefaultValue = false)]
            public string Name { get; set; }

            /// <summary>
            /// Array of thermostat daily program periods. The periods that you specify overwrite any existing periods for the daily program.
            /// </summary>
            [DataMember(Name = "periods", IsRequired = true, EmitDefaultValue = false)]
            public List<UpdateRequestPeriods> Periods { get; set; }

            /// <summary>
            /// ID of the thermostat daily program that you want to update.
            /// </summary>
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
                string? climatePresetKey = default,
                string? startsAtTime = default
            )
            {
                ClimatePresetKey = climatePresetKey;
                StartsAtTime = startsAtTime;
            }

            /// <summary>
            /// Key of the [climate preset](https://docs.seam.co/capability-guides/thermostats/creating-and-managing-climate-presets) to activate at the `starts_at_time`.
            /// </summary>
            [DataMember(Name = "climate_preset_key", IsRequired = false, EmitDefaultValue = false)]
            public string? ClimatePresetKey { get; set; }

            /// <summary>
            /// Time at which the thermostat daily program period starts, in [ISO 8601](https://www.iso.org/iso-8601-date-and-time-format.html) format.
            /// </summary>
            [DataMember(Name = "starts_at_time", IsRequired = false, EmitDefaultValue = false)]
            public string? StartsAtTime { get; set; }

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

            /// <summary>
            /// OK
            /// </summary>
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

        /// <summary>
        /// Updates a specified thermostat daily program. The periods that you specify overwrite any existing periods for the daily program.
        /// </summary>
        public ActionAttempt Update(UpdateRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            return _seam
                .Patch<UpdateResponse>("/thermostats/daily_programs/update", requestOptions)
                .EnsureData("/thermostats/daily_programs/update")
                .ActionAttempt;
        }

        /// <summary>
        /// Updates a specified thermostat daily program. The periods that you specify overwrite any existing periods for the daily program.
        /// </summary>
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

        /// <summary>
        /// Updates a specified thermostat daily program. The periods that you specify overwrite any existing periods for the daily program.
        /// </summary>
        public async Task<ActionAttempt> UpdateAsync(UpdateRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            return (
                await _seam.PatchAsync<UpdateResponse>(
                    "/thermostats/daily_programs/update",
                    requestOptions
                )
            )
                .EnsureData("/thermostats/daily_programs/update")
                .ActionAttempt;
        }

        /// <summary>
        /// Updates a specified thermostat daily program. The periods that you specify overwrite any existing periods for the daily program.
        /// </summary>
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
