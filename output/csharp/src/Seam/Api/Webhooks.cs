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
    public class Webhooks
    {
        private ISeamClient _seam;

        public Webhooks(ISeamClient seam)
        {
            _seam = seam;
        }

        [DataContract(Name = "createRequest_request")]
        public class CreateRequest
        {
            [JsonConstructorAttribute]
            protected CreateRequest() { }

            public CreateRequest(List<string>? eventTypes = default, string url = default)
            {
                EventTypes = eventTypes;
                Url = url;
            }

            [DataMember(Name = "event_types", IsRequired = false, EmitDefaultValue = false)]
            public List<string>? EventTypes { get; set; }

            [DataMember(Name = "url", IsRequired = true, EmitDefaultValue = false)]
            public string Url { get; set; }

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

            public CreateResponse(Webhook webhook = default)
            {
                Webhook = webhook;
            }

            [DataMember(Name = "webhook", IsRequired = false, EmitDefaultValue = false)]
            public Webhook Webhook { get; set; }

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

        public Webhook Create(CreateRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            return _seam.Post<CreateResponse>("/webhooks/create", requestOptions).Data.Webhook;
        }

        public Webhook Create(List<string>? eventTypes = default, string url = default)
        {
            return Create(new CreateRequest(eventTypes: eventTypes, url: url));
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
            List<string>? eventTypes = default,
            string url = default
        )
        {
            return (await CreateAsync(new CreateRequest(eventTypes: eventTypes, url: url)));
        }

        [DataContract(Name = "deleteRequest_request")]
        public class DeleteRequest
        {
            [JsonConstructorAttribute]
            protected DeleteRequest() { }

            public DeleteRequest(string webhookId = default)
            {
                WebhookId = webhookId;
            }

            [DataMember(Name = "webhook_id", IsRequired = true, EmitDefaultValue = false)]
            public string WebhookId { get; set; }

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
            _seam.Post<object>("/webhooks/delete", requestOptions);
        }

        public void Delete(string webhookId = default)
        {
            Delete(new DeleteRequest(webhookId: webhookId));
        }

        public async Task DeleteAsync(DeleteRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            await _seam.PostAsync<object>("/webhooks/delete", requestOptions);
        }

        public async Task DeleteAsync(string webhookId = default)
        {
            await DeleteAsync(new DeleteRequest(webhookId: webhookId));
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

            public GetResponse(Webhook webhook = default)
            {
                Webhook = webhook;
            }

            [DataMember(Name = "webhook", IsRequired = false, EmitDefaultValue = false)]
            public Webhook Webhook { get; set; }

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

        [DataContract(Name = "listRequest_request")]
        public class ListRequest
        {
            [JsonConstructorAttribute]
            public ListRequest() { }

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

            public ListResponse(List<Webhook> webhooks = default)
            {
                Webhooks = webhooks;
            }

            [DataMember(Name = "webhooks", IsRequired = false, EmitDefaultValue = false)]
            public List<Webhook> Webhooks { get; set; }

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

        public List<Webhook> List(ListRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            return _seam.Post<ListResponse>("/webhooks/list", requestOptions).Data.Webhooks;
        }

        public List<Webhook> List()
        {
            return List(new ListRequest());
        }

        public async Task<List<Webhook>> ListAsync(ListRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            return (await _seam.PostAsync<ListResponse>("/webhooks/list", requestOptions))
                .Data
                .Webhooks;
        }

        public async Task<List<Webhook>> ListAsync()
        {
            return (await ListAsync(new ListRequest()));
        }

        [DataContract(Name = "updateRequest_request")]
        public class UpdateRequest
        {
            [JsonConstructorAttribute]
            protected UpdateRequest() { }

            public UpdateRequest(List<string> eventTypes = default, string webhookId = default)
            {
                EventTypes = eventTypes;
                WebhookId = webhookId;
            }

            [DataMember(Name = "event_types", IsRequired = true, EmitDefaultValue = false)]
            public List<string> EventTypes { get; set; }

            [DataMember(Name = "webhook_id", IsRequired = true, EmitDefaultValue = false)]
            public string WebhookId { get; set; }

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
            _seam.Post<object>("/webhooks/update", requestOptions);
        }

        public void Update(List<string> eventTypes = default, string webhookId = default)
        {
            Update(new UpdateRequest(eventTypes: eventTypes, webhookId: webhookId));
        }

        public async Task UpdateAsync(UpdateRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            await _seam.PostAsync<object>("/webhooks/update", requestOptions);
        }

        public async Task UpdateAsync(List<string> eventTypes = default, string webhookId = default)
        {
            await UpdateAsync(new UpdateRequest(eventTypes: eventTypes, webhookId: webhookId));
        }
    }
}

namespace Seam.Client
{
    public partial class SeamClient
    {
        public Api.Webhooks Webhooks => new(this);
    }

    public partial interface ISeamClient
    {
        public Api.Webhooks Webhooks { get; }
    }
}
