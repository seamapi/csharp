using System.Runtime.Serialization;
using System.Text;
using JsonSubTypes;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using Seam.Model;

namespace Seam.Model
{
    [DataContract(Name = "seamModel_phoneRegistration_model")]
    public class PhoneRegistration
    {
        [JsonConstructorAttribute]
        protected PhoneRegistration() { }

        public PhoneRegistration(
            bool isBeingActivated = default,
            string phoneRegistrationId = default,
            string? providerName = default,
            Object providerState = default
        )
        {
            IsBeingActivated = isBeingActivated;
            PhoneRegistrationId = phoneRegistrationId;
            ProviderName = providerName;
            ProviderState = providerState;
        }

        [DataMember(Name = "is_being_activated", IsRequired = true, EmitDefaultValue = false)]
        public bool IsBeingActivated { get; set; }

        [DataMember(Name = "phone_registration_id", IsRequired = true, EmitDefaultValue = false)]
        public string PhoneRegistrationId { get; set; }

        [DataMember(Name = "provider_name", IsRequired = false, EmitDefaultValue = false)]
        public string? ProviderName { get; set; }

        [DataMember(Name = "provider_state", IsRequired = false, EmitDefaultValue = false)]
        public Object ProviderState { get; set; }

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
