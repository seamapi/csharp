using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using JsonSubTypes;

namespace Seam.Model
{
    [DataContract(Name = "coSeamModel_webhook_model")]
    public class Webhook
    {
        [JsonConstructorAttribute]
        protected Webhook() { }

        public Webhook(
            string webhookId = default,
            string url = default,
            List<string>? eventTypes = default,
            string? secret = default
        )
        {
            WebhookId = webhookId;
            Url = url;
            EventTypes = eventTypes;
            Secret = secret;
        }

        [DataMember(Name = "webhook_id", IsRequired = true, EmitDefaultValue = false)]
        public string WebhookId { get; set; }

        [DataMember(Name = "url", IsRequired = true, EmitDefaultValue = false)]
        public string Url { get; set; }

        [DataMember(Name = "event_types", IsRequired = false, EmitDefaultValue = false)]
        public List<string>? EventTypes { get; set; }

        [DataMember(Name = "secret", IsRequired = false, EmitDefaultValue = false)]
        public string? Secret { get; set; }
    }
}
