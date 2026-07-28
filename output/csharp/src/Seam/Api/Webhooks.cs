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

        /// <summary>
        /// Request parameters for Create a Webhook.
        /// </summary>
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

            /// <summary>
            /// Types of events that you want the new webhook to receive.
            /// </summary>
            [DataMember(Name = "event_types", IsRequired = false, EmitDefaultValue = false)]
            public List<string>? EventTypes { get; set; }

            /// <summary>
            /// URL for the new webhook.
            /// </summary>
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

            /// <summary>
            /// OK
            /// </summary>
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

        /// <summary>
        /// Creates a new [webhook](https://docs.seam.co/developer-tools/webhooks).
        /// </summary>
        public Webhook Create(CreateRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            return _seam.Post<CreateResponse>("/webhooks/create", requestOptions).Data.Webhook;
        }

        /// <summary>
        /// Creates a new [webhook](https://docs.seam.co/developer-tools/webhooks).
        /// </summary>
        public Webhook Create(List<string>? eventTypes = default, string url = default)
        {
            return Create(new CreateRequest(eventTypes: eventTypes, url: url));
        }

        /// <summary>
        /// Creates a new [webhook](https://docs.seam.co/developer-tools/webhooks).
        /// </summary>
        public async Task<Webhook> CreateAsync(CreateRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            return (await _seam.PostAsync<CreateResponse>("/webhooks/create", requestOptions))
                .Data
                .Webhook;
        }

        /// <summary>
        /// Creates a new [webhook](https://docs.seam.co/developer-tools/webhooks).
        /// </summary>
        public async Task<Webhook> CreateAsync(
            List<string>? eventTypes = default,
            string url = default
        )
        {
            return (await CreateAsync(new CreateRequest(eventTypes: eventTypes, url: url)));
        }

        /// <summary>
        /// Request parameters for Delete a Webhook.
        /// </summary>
        [DataContract(Name = "deleteRequest_request")]
        public class DeleteRequest
        {
            [JsonConstructorAttribute]
            protected DeleteRequest() { }

            public DeleteRequest(string webhookId = default)
            {
                WebhookId = webhookId;
            }

            /// <summary>
            /// ID of the webhook that you want to delete.
            /// </summary>
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

        /// <summary>
        /// Deletes a specified [webhook](https://docs.seam.co/developer-tools/webhooks).
        /// </summary>
        public void Delete(DeleteRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            _seam.Post<object>("/webhooks/delete", requestOptions);
        }

        /// <summary>
        /// Deletes a specified [webhook](https://docs.seam.co/developer-tools/webhooks).
        /// </summary>
        public void Delete(string webhookId = default)
        {
            Delete(new DeleteRequest(webhookId: webhookId));
        }

        /// <summary>
        /// Deletes a specified [webhook](https://docs.seam.co/developer-tools/webhooks).
        /// </summary>
        public async Task DeleteAsync(DeleteRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            await _seam.PostAsync<object>("/webhooks/delete", requestOptions);
        }

        /// <summary>
        /// Deletes a specified [webhook](https://docs.seam.co/developer-tools/webhooks).
        /// </summary>
        public async Task DeleteAsync(string webhookId = default)
        {
            await DeleteAsync(new DeleteRequest(webhookId: webhookId));
        }

        /// <summary>
        /// Request parameters for Get a Webhook.
        /// </summary>
        [DataContract(Name = "getRequest_request")]
        public class GetRequest
        {
            [JsonConstructorAttribute]
            protected GetRequest() { }

            public GetRequest(string webhookId = default)
            {
                WebhookId = webhookId;
            }

            /// <summary>
            /// ID of the webhook that you want to get.
            /// </summary>
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

            /// <summary>
            /// OK
            /// </summary>
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

        /// <summary>
        /// Gets a specified [webhook](https://docs.seam.co/developer-tools/webhooks).
        /// </summary>
        public Webhook Get(GetRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            return _seam.Post<GetResponse>("/webhooks/get", requestOptions).Data.Webhook;
        }

        /// <summary>
        /// Gets a specified [webhook](https://docs.seam.co/developer-tools/webhooks).
        /// </summary>
        public Webhook Get(string webhookId = default)
        {
            return Get(new GetRequest(webhookId: webhookId));
        }

        /// <summary>
        /// Gets a specified [webhook](https://docs.seam.co/developer-tools/webhooks).
        /// </summary>
        public async Task<Webhook> GetAsync(GetRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            return (await _seam.PostAsync<GetResponse>("/webhooks/get", requestOptions))
                .Data
                .Webhook;
        }

        /// <summary>
        /// Gets a specified [webhook](https://docs.seam.co/developer-tools/webhooks).
        /// </summary>
        public async Task<Webhook> GetAsync(string webhookId = default)
        {
            return (await GetAsync(new GetRequest(webhookId: webhookId)));
        }

        /// <summary>
        /// Request parameters for List Webhooks.
        /// </summary>
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

            /// <summary>
            /// OK
            /// </summary>
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

        /// <summary>
        /// Returns a list of all [webhooks](https://docs.seam.co/developer-tools/webhooks).
        /// </summary>
        public List<Webhook> List(ListRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            return _seam.Post<ListResponse>("/webhooks/list", requestOptions).Data.Webhooks;
        }

        /// <summary>
        /// Returns a list of all [webhooks](https://docs.seam.co/developer-tools/webhooks).
        /// </summary>
        public List<Webhook> List()
        {
            return List(new ListRequest());
        }

        /// <summary>
        /// Returns a list of all [webhooks](https://docs.seam.co/developer-tools/webhooks).
        /// </summary>
        public async Task<List<Webhook>> ListAsync(ListRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            return (await _seam.PostAsync<ListResponse>("/webhooks/list", requestOptions))
                .Data
                .Webhooks;
        }

        /// <summary>
        /// Returns a list of all [webhooks](https://docs.seam.co/developer-tools/webhooks).
        /// </summary>
        public async Task<List<Webhook>> ListAsync()
        {
            return (await ListAsync(new ListRequest()));
        }

        /// <summary>
        /// Request parameters for Update a Webhook.
        /// </summary>
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

            /// <summary>
            /// Types of events that you want the webhook to receive.
            /// </summary>
            [DataMember(Name = "event_types", IsRequired = true, EmitDefaultValue = false)]
            public List<string> EventTypes { get; set; }

            /// <summary>
            /// ID of the webhook that you want to update.
            /// </summary>
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

        /// <summary>
        /// Updates a specified [webhook](https://docs.seam.co/developer-tools/webhooks).
        /// </summary>
        public void Update(UpdateRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            _seam.Post<object>("/webhooks/update", requestOptions);
        }

        /// <summary>
        /// Updates a specified [webhook](https://docs.seam.co/developer-tools/webhooks).
        /// </summary>
        public void Update(List<string> eventTypes = default, string webhookId = default)
        {
            Update(new UpdateRequest(eventTypes: eventTypes, webhookId: webhookId));
        }

        /// <summary>
        /// Updates a specified [webhook](https://docs.seam.co/developer-tools/webhooks).
        /// </summary>
        public async Task UpdateAsync(UpdateRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            await _seam.PostAsync<object>("/webhooks/update", requestOptions);
        }

        /// <summary>
        /// Updates a specified [webhook](https://docs.seam.co/developer-tools/webhooks).
        /// </summary>
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
