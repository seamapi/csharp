using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using JsonSubTypes;
using Co.Seam.Client;
using Co.Seam.Model;

namespace Co.Seam.Api
{
    public class ActionAttempts
    {
        private ISeam _seam;

        public ActionAttempts(ISeam seam)
        {
            _seam = seam;
        }

        [DataContract(Name = "getRequest_request")]
        public class GetRequest
        {
            [JsonConstructorAttribute]
            protected GetRequest() { }

            public GetRequest(string actionAttemptId = default)
            {
                ActionAttemptId = actionAttemptId;
            }

            [DataMember(Name = "action_attempt_id", IsRequired = true, EmitDefaultValue = false)]
            public string ActionAttemptId { get; set; }
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

            [DataMember(Name = "action_attempt", IsRequired = false, EmitDefaultValue = false)]
            public ActionAttempt ActionAttempt { get; set; }
        }

        public ActionAttempt Get(GetRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            return _seam
                .Post<GetResponse>("/action_attempts/get", requestOptions)
                .Data.ActionAttempt;
        }

        public ActionAttempt Get(string actionAttemptId = default)
        {
            return Get(new GetRequest(actionAttemptId: actionAttemptId));
        }

        public async Task<ActionAttempt> GetAsync(GetRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            return (await _seam.PostAsync<GetResponse>("/action_attempts/get", requestOptions))
                .Data
                .ActionAttempt;
        }

        public async Task<ActionAttempt> GetAsync(string actionAttemptId = default)
        {
            return (await GetAsync(new GetRequest(actionAttemptId: actionAttemptId)));
        }

        [DataContract(Name = "listRequest_request")]
        public class ListRequest
        {
            [JsonConstructorAttribute]
            protected ListRequest() { }

            public ListRequest(List<string> actionAttemptIds = default)
            {
                ActionAttemptIds = actionAttemptIds;
            }

            [DataMember(Name = "action_attempt_ids", IsRequired = true, EmitDefaultValue = false)]
            public List<string> ActionAttemptIds { get; set; }
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

            [DataMember(Name = "action_attempts", IsRequired = false, EmitDefaultValue = false)]
            public List<ActionAttempt> ActionAttempts { get; set; }
        }

        public List<ActionAttempt> List(ListRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            return _seam
                .Post<ListResponse>("/action_attempts/list", requestOptions)
                .Data.ActionAttempts;
        }

        public List<ActionAttempt> List(List<string> actionAttemptIds = default)
        {
            return List(new ListRequest(actionAttemptIds: actionAttemptIds));
        }

        public async Task<List<ActionAttempt>> ListAsync(ListRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            return (await _seam.PostAsync<ListResponse>("/action_attempts/list", requestOptions))
                .Data
                .ActionAttempts;
        }

        public async Task<List<ActionAttempt>> ListAsync(List<string> actionAttemptIds = default)
        {
            return (await ListAsync(new ListRequest(actionAttemptIds: actionAttemptIds)));
        }
    }
}

namespace Co.Seam.Client
{
    public partial class Seam
    {
        public Api.ActionAttempts ActionAttempts => new(this);
    }

    public partial interface ISeam
    {
        public Api.ActionAttempts ActionAttempts { get; }
    }
}
