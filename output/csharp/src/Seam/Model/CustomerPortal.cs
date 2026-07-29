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
    /// Represents a Customer Portal. Customer Portal is a hosted, customizable interface for managing device access. It enables you to embed secure, pre-authenticated access flows into your product—either by sharing a link with users or embedding a view in an iframe.
    ///
    /// With Customer Portal, you no longer need to build out frontend experiences for physical access, thermostats, and sensors. Instead, you can ship enterprise-grade access control experiences in a fraction of the time, while maintaining your product&apos;s branding and user experience.
    ///
    /// Seam hosts these flows, handling everything from account connection and device mapping to full-featured device control.
    /// </summary>
    [DataContract(Name = "seamModel_customerPortal_model")]
    public class CustomerPortal
    {
        [JsonConstructorAttribute]
        protected CustomerPortal() { }

        public CustomerPortal(
            string createdAt = default,
            string customerKey = default,
            string expiresAt = default,
            string url = default,
            string workspaceId = default
        )
        {
            CreatedAt = createdAt;
            CustomerKey = customerKey;
            ExpiresAt = expiresAt;
            Url = url;
            WorkspaceId = workspaceId;
        }

        /// <summary>
        /// Date and time at which the customer portal link was created.
        /// </summary>
        [DataMember(Name = "created_at", IsRequired = false, EmitDefaultValue = false)]
        public string CreatedAt { get; set; }

        /// <summary>
        /// Customer key for the customer portal.
        /// </summary>
        [DataMember(Name = "customer_key", IsRequired = false, EmitDefaultValue = false)]
        public string CustomerKey { get; set; }

        /// <summary>
        /// Date and time at which the customer portal link expires.
        /// </summary>
        [DataMember(Name = "expires_at", IsRequired = false, EmitDefaultValue = false)]
        public string ExpiresAt { get; set; }

        /// <summary>
        /// URL for the customer portal.
        /// </summary>
        [DataMember(Name = "url", IsRequired = false, EmitDefaultValue = false)]
        public string Url { get; set; }

        /// <summary>
        /// ID of the workspace associated with the customer portal.
        /// </summary>
        [DataMember(Name = "workspace_id", IsRequired = false, EmitDefaultValue = false)]
        public string WorkspaceId { get; set; }

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
