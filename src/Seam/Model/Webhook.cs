using System.Runtime.Serialization;
using System.Text;
using JsonSubTypes;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using Seam.Model;

namespace Seam.Model
{
    /// <summary>
    /// Represents a [webhook](https://docs.seam.co/developer-tools/webhooks) that enables you to receive notifications of events. When you create a webhook, specify the endpoint URL at which you want to receive events and the set of event types that you want to receive.
    /// </summary>
    [DataContract(Name = "seamModel_webhook_model")]
    public class Webhook
    {
        [JsonConstructorAttribute]
        protected Webhook() { }

        public Webhook(
            List<string>? eventTypes = default,
            string? secret = default,
            string url = default,
            string webhookId = default
        )
        {
            EventTypes = eventTypes;
            Secret = secret;
            Url = url;
            WebhookId = webhookId;
        }

        /// <summary>
        /// Types of events that the [webhook](https://docs.seam.co/developer-tools/webhooks) should receive.
        /// </summary>
        [DataMember(Name = "event_types", IsRequired = false, EmitDefaultValue = false)]
        public List<string>? EventTypes { get; set; }

        /// <summary>
        /// Secret associated with the [webhook](https://docs.seam.co/developer-tools/webhooks).
        /// </summary>
        [DataMember(Name = "secret", IsRequired = false, EmitDefaultValue = false)]
        public string? Secret { get; set; }

        /// <summary>
        /// URL for the [webhook](https://docs.seam.co/developer-tools/webhooks).
        /// </summary>
        [DataMember(Name = "url", IsRequired = false, EmitDefaultValue = false)]
        public string Url { get; set; }

        /// <summary>
        /// ID of the webhook.
        /// </summary>
        [DataMember(Name = "webhook_id", IsRequired = false, EmitDefaultValue = false)]
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
}
