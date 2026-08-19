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
    public class ActionAttempts
    {
        private ISeamClient _seam;

        public ActionAttempts(ISeamClient seam)
        {
            _seam = seam;
        }

        /// <summary>
        /// Request parameters for Get an Action Attempt.
        /// </summary>
        [DataContract(Name = "getRequest_request")]
        public class GetRequest
        {
            [JsonConstructorAttribute]
            protected GetRequest() { }

            public GetRequest(string actionAttemptId = default)
            {
                ActionAttemptId = actionAttemptId;
            }

            /// <summary>
            /// ID of the action attempt that you want to get.
            /// </summary>
            [DataMember(Name = "action_attempt_id", IsRequired = true, EmitDefaultValue = false)]
            public string ActionAttemptId { get; set; }

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

            public GetResponse(ActionAttempt actionAttempt = default)
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
        /// Returns a specified [action attempt](https://docs.seam.co/core-concepts/action-attempts).
        /// </summary>
        public ActionAttempt Get(GetRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            return _seam
                .Get<GetResponse>("/action_attempts/get", requestOptions)
                .EnsureData("/action_attempts/get")
                .ActionAttempt;
        }

        /// <summary>
        /// Returns a specified [action attempt](https://docs.seam.co/core-concepts/action-attempts).
        /// </summary>
        public ActionAttempt Get(string actionAttemptId = default)
        {
            return Get(new GetRequest(actionAttemptId: actionAttemptId));
        }

        /// <summary>
        /// Returns a specified [action attempt](https://docs.seam.co/core-concepts/action-attempts).
        /// </summary>
        public async Task<ActionAttempt> GetAsync(GetRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            return (await _seam.GetAsync<GetResponse>("/action_attempts/get", requestOptions))
                .EnsureData("/action_attempts/get")
                .ActionAttempt;
        }

        /// <summary>
        /// Returns a specified [action attempt](https://docs.seam.co/core-concepts/action-attempts).
        /// </summary>
        public async Task<ActionAttempt> GetAsync(string actionAttemptId = default)
        {
            return (await GetAsync(new GetRequest(actionAttemptId: actionAttemptId)));
        }

        /// <summary>
        /// Request parameters for List Action Attempts.
        /// </summary>
        [DataContract(Name = "listRequest_request")]
        public class ListRequest
        {
            [JsonConstructorAttribute]
            protected ListRequest() { }

            public ListRequest(
                List<string>? actionAttemptIds = default,
                string? deviceId = default,
                int? limit = default,
                string? pageCursor = default
            )
            {
                ActionAttemptIds = actionAttemptIds;
                DeviceId = deviceId;
                Limit = limit;
                PageCursor = pageCursor;
            }

            /// <summary>
            /// IDs of the action attempts that you want to retrieve.
            /// </summary>
            [DataMember(Name = "action_attempt_ids", IsRequired = false, EmitDefaultValue = false)]
            public List<string>? ActionAttemptIds { get; set; }

            /// <summary>
            /// ID of the device to filter action attempts by.
            /// </summary>
            [DataMember(Name = "device_id", IsRequired = false, EmitDefaultValue = false)]
            public string? DeviceId { get; set; }

            /// <summary>
            /// Maximum number of records to return per page.
            /// </summary>
            [DataMember(Name = "limit", IsRequired = false, EmitDefaultValue = false)]
            public int? Limit { get; set; }

            /// <summary>
            /// Identifies the specific page of results to return, obtained from the previous page&apos;s `next_page_cursor`.
            /// </summary>
            [DataMember(Name = "page_cursor", IsRequired = false, EmitDefaultValue = false)]
            public string? PageCursor { get; set; }

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

            public ListResponse(List<ActionAttempt> actionAttempts = default)
            {
                ActionAttempts = actionAttempts;
            }

            /// <summary>
            /// OK
            /// </summary>
            [DataMember(Name = "action_attempts", IsRequired = false, EmitDefaultValue = false)]
            public List<ActionAttempt> ActionAttempts { get; set; }

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
        /// Returns a list of the [action attempts](https://docs.seam.co/core-concepts/action-attempts) that you specify as an array of `action_attempt_id`s.
        /// </summary>
        public List<ActionAttempt> List(ListRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            return _seam
                .Get<ListResponse>("/action_attempts/list", requestOptions)
                .EnsureData("/action_attempts/list")
                .ActionAttempts;
        }

        /// <summary>
        /// Returns a list of the [action attempts](https://docs.seam.co/core-concepts/action-attempts) that you specify as an array of `action_attempt_id`s.
        /// </summary>
        public List<ActionAttempt> List(
            List<string>? actionAttemptIds = default,
            string? deviceId = default,
            int? limit = default,
            string? pageCursor = default
        )
        {
            return List(
                new ListRequest(
                    actionAttemptIds: actionAttemptIds,
                    deviceId: deviceId,
                    limit: limit,
                    pageCursor: pageCursor
                )
            );
        }

        /// <summary>
        /// Returns a list of the [action attempts](https://docs.seam.co/core-concepts/action-attempts) that you specify as an array of `action_attempt_id`s.
        /// </summary>
        public async Task<List<ActionAttempt>> ListAsync(ListRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            return (await _seam.GetAsync<ListResponse>("/action_attempts/list", requestOptions))
                .EnsureData("/action_attempts/list")
                .ActionAttempts;
        }

        /// <summary>
        /// Returns a list of the [action attempts](https://docs.seam.co/core-concepts/action-attempts) that you specify as an array of `action_attempt_id`s.
        /// </summary>
        public async Task<List<ActionAttempt>> ListAsync(
            List<string>? actionAttemptIds = default,
            string? deviceId = default,
            int? limit = default,
            string? pageCursor = default
        )
        {
            return (
                await ListAsync(
                    new ListRequest(
                        actionAttemptIds: actionAttemptIds,
                        deviceId: deviceId,
                        limit: limit,
                        pageCursor: pageCursor
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
        public Api.ActionAttempts ActionAttempts => new(this);
    }

    public partial interface ISeamClient
    {
        public Api.ActionAttempts ActionAttempts { get; }
    }
}
