using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using JsonSubTypes;
using Seam.Client;
using Seam.Model;

namespace Seam.Api
{
    public class Webhooks
    {
        private ISeam _seam;

        public Webhooks(ISeam seam)
        {
            _seam = seam;
        }

        [DataContract(Name = "createRequest_request")]
        public class CreateRequest
        {
            [JsonConstructorAttribute]
            protected CreateRequest() { }

            public CreateRequest(string url = default, List<string>? eventTypes = default)
            {
                Url = url;
                EventTypes = eventTypes;
            }

            [DataMember(Name = "url", IsRequired = true, EmitDefaultValue = false)]
            public string Url { get; set; }

            [DataMember(Name = "event_types", IsRequired = false, EmitDefaultValue = false)]
            public List<string>? EventTypes { get; set; }
        }

        [DataContract(Name = "createResponse_response")]
        public class CreateResponse
        {
            [JsonConstructorAttribute]
            protected CreateResponse() { }

            public CreateResponse(Webhook webhook = default)
            {
                Webhook = webhook;
            }

            [DataMember(Name = "webhook", IsRequired = false, EmitDefaultValue = false)]
            public Webhook Webhook { get; set; }
        }

        public Webhook Create(CreateRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            return _seam.Post<CreateResponse>("/webhooks/create", requestOptions).Data.Webhook;
        }

        public Webhook Create(string url = default, List<string>? eventTypes = default)
        {
            return Create(new CreateRequest(url: url, eventTypes: eventTypes));
        }

        public async Task<Webhook> CreateAsync(CreateRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            return (await _seam.PostAsync<CreateResponse>("/webhooks/create", requestOptions))
                .Data
                .Webhook;
        }

        public async Task<Webhook> CreateAsync(
            string url = default,
            List<string>? eventTypes = default
        )
        {
            return (await CreateAsync(new CreateRequest(url: url, eventTypes: eventTypes)));
        }

        [DataContract(Name = "getRequest_request")]
        public class GetRequest
        {
            [JsonConstructorAttribute]
            protected GetRequest() { }

            public GetRequest(string webhookId = default)
            {
                WebhookId = webhookId;
            }

            [DataMember(Name = "webhook_id", IsRequired = true, EmitDefaultValue = false)]
            public string WebhookId { get; set; }
        }

        [DataContract(Name = "getResponse_response")]
        public class GetResponse
        {
            [JsonConstructorAttribute]
            protected GetResponse() { }

            public GetResponse(Webhook webhook = default)
            {
                Webhook = webhook;
            }

            [DataMember(Name = "webhook", IsRequired = false, EmitDefaultValue = false)]
            public Webhook Webhook { get; set; }
        }

        public Webhook Get(GetRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            return _seam.Post<GetResponse>("/webhooks/get", requestOptions).Data.Webhook;
        }

        public Webhook Get(string webhookId = default)
        {
            return Get(new GetRequest(webhookId: webhookId));
        }

        public async Task<Webhook> GetAsync(GetRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            return (await _seam.PostAsync<GetResponse>("/webhooks/get", requestOptions))
                .Data
                .Webhook;
        }

        public async Task<Webhook> GetAsync(string webhookId = default)
        {
            return (await GetAsync(new GetRequest(webhookId: webhookId)));
        }
    }
}

namespace Seam.Client
{
    public partial class Seam
    {
        public Api.Webhooks Webhooks => new(this);
    }

    public partial interface ISeam
    {
        public Api.Webhooks Webhooks { get; }
    }
}
