using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using JsonSubTypes;

namespace Seam.Model
{
    [DataContract(Name = "coSeamModel_acsSystem_model")]
    public class AcsSystem
    {
        [JsonConstructorAttribute]
        protected AcsSystem() { }

        public AcsSystem(
            string acsSystemId = default,
            AcsSystem.SystemTypeEnum systemType = default,
            string systemTypeDisplayName = default,
            string name = default,
            string createdAt = default
        )
        {
            AcsSystemId = acsSystemId;
            SystemType = systemType;
            SystemTypeDisplayName = systemTypeDisplayName;
            Name = name;
            CreatedAt = createdAt;
        }

        [JsonConverter(typeof(StringEnumConverter))]
        public enum SystemTypeEnum
        {
            [EnumMember(Value = "pti_site")]
            PtiSite = 0,

            [EnumMember(Value = "alta_org")]
            AltaOrg = 1
        }

        [DataMember(Name = "acs_system_id", IsRequired = true, EmitDefaultValue = false)]
        public string AcsSystemId { get; set; }

        [DataMember(Name = "system_type", IsRequired = true, EmitDefaultValue = false)]
        public AcsSystem.SystemTypeEnum SystemType { get; set; }

        [DataMember(Name = "system_type_display_name", IsRequired = true, EmitDefaultValue = false)]
        public string SystemTypeDisplayName { get; set; }

        [DataMember(Name = "name", IsRequired = true, EmitDefaultValue = false)]
        public string Name { get; set; }

        [DataMember(Name = "created_at", IsRequired = true, EmitDefaultValue = false)]
        public string CreatedAt { get; set; }
    }
}
