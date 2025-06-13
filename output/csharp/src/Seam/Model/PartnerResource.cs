using System.Runtime.Serialization;
using System.Text;
using JsonSubTypes;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using Seam.Model;

namespace Seam.Model
{
    [DataContract(Name = "seamModel_partnerResource_model")]
    public class PartnerResource
    {
        [JsonConstructorAttribute]
        protected PartnerResource() { }

        public PartnerResource(
            object? customMetadata = default,
            string customerKey = default,
            string? description = default,
            string? emailAddress = default,
            string? endsAt = default,
            List<string>? locationKeys = default,
            string? name = default,
            string partnerResourceKey = default,
            string partnerResourceType = default,
            string? phoneNumber = default,
            string? startsAt = default,
            string? userIdentityKey = default
        )
        {
            CustomMetadata = customMetadata;
            CustomerKey = customerKey;
            Description = description;
            EmailAddress = emailAddress;
            EndsAt = endsAt;
            LocationKeys = locationKeys;
            Name = name;
            PartnerResourceKey = partnerResourceKey;
            PartnerResourceType = partnerResourceType;
            PhoneNumber = phoneNumber;
            StartsAt = startsAt;
            UserIdentityKey = userIdentityKey;
        }

        [DataMember(Name = "custom_metadata", IsRequired = false, EmitDefaultValue = false)]
        public object? CustomMetadata { get; set; }

        [DataMember(Name = "customer_key", IsRequired = true, EmitDefaultValue = false)]
        public string CustomerKey { get; set; }

        [DataMember(Name = "description", IsRequired = false, EmitDefaultValue = false)]
        public string? Description { get; set; }

        [DataMember(Name = "email_address", IsRequired = false, EmitDefaultValue = false)]
        public string? EmailAddress { get; set; }

        [DataMember(Name = "ends_at", IsRequired = false, EmitDefaultValue = false)]
        public string? EndsAt { get; set; }

        [DataMember(Name = "location_keys", IsRequired = false, EmitDefaultValue = false)]
        public List<string>? LocationKeys { get; set; }

        [DataMember(Name = "name", IsRequired = false, EmitDefaultValue = false)]
        public string? Name { get; set; }

        [DataMember(Name = "partner_resource_key", IsRequired = true, EmitDefaultValue = false)]
        public string PartnerResourceKey { get; set; }

        [DataMember(Name = "partner_resource_type", IsRequired = true, EmitDefaultValue = false)]
        public string PartnerResourceType { get; set; }

        [DataMember(Name = "phone_number", IsRequired = false, EmitDefaultValue = false)]
        public string? PhoneNumber { get; set; }

        [DataMember(Name = "starts_at", IsRequired = false, EmitDefaultValue = false)]
        public string? StartsAt { get; set; }

        [DataMember(Name = "user_identity_key", IsRequired = false, EmitDefaultValue = false)]
        public string? UserIdentityKey { get; set; }

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
