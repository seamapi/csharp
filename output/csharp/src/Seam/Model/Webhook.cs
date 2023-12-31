using System.Runtime.Serialization;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using JsonSubTypes;

namespace Seam.Model
{
    [DataContract(Name = "seamModel_webhook_model")]
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
