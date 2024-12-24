using System.Runtime.Serialization;
using System.Text;
using JsonSubTypes;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using Seam.Model;

namespace Seam.Model
{
    [DataContract(Name = "seamModel_serviceHealth_model")]
    public class ServiceHealth
    {
        [JsonConstructorAttribute]
        protected ServiceHealth() { }

        public ServiceHealth(
            string description = default,
            string service = default,
            ServiceHealth.StatusEnum status = default
        )
        {
            Description = description;
            Service = service;
            Status = status;
        }

        [JsonConverter(typeof(SafeStringEnumConverter))]
        public enum StatusEnum
        {
            [EnumMember(Value = "unrecognized")]
            Unrecognized = 0,

            [EnumMember(Value = "healthy")]
            Healthy = 1,

            [EnumMember(Value = "degraded")]
            Degraded = 2,

            [EnumMember(Value = "down")]
            Down = 3,
        }

        [DataMember(Name = "description", IsRequired = true, EmitDefaultValue = false)]
        public string Description { get; set; }

        [DataMember(Name = "service", IsRequired = true, EmitDefaultValue = false)]
        public string Service { get; set; }

        [DataMember(Name = "status", IsRequired = true, EmitDefaultValue = false)]
        public ServiceHealth.StatusEnum Status { get; set; }

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
