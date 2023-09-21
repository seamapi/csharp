using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using JsonSubTypes;

namespace Co.Seam.Model
{
    [DataContract(Name = "coSeamModel_serviceHealth_model")]
    public class ServiceHealth
    {
        [JsonConstructorAttribute]
        protected ServiceHealth() { }

        public ServiceHealth(
            string service = default,
            ServiceHealth.StatusEnum status = default,
            string description = default
        )
        {
            Service = service;
            Status = status;
            Description = description;
        }

        [JsonConverter(typeof(StringEnumConverter))]
        public enum StatusEnum
        {
            [EnumMember(Value = "healthy")]
            Healthy = 0,

            [EnumMember(Value = "degraded")]
            Degraded = 1,

            [EnumMember(Value = "down")]
            Down = 2
        }

        [DataMember(Name = "service", IsRequired = true, EmitDefaultValue = false)]
        public string Service { get; set; }

        [DataMember(Name = "status", IsRequired = true, EmitDefaultValue = false)]
        public ServiceHealth.StatusEnum Status { get; set; }

        [DataMember(Name = "description", IsRequired = true, EmitDefaultValue = false)]
        public string Description { get; set; }
    }
}
