using System.Runtime.Serialization;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using JsonSubTypes;

namespace Seam.Model
{
    [DataContract(Name = "seamModel_acsAccessGroup_model")]
    public class AcsAccessGroup
    {
        [JsonConstructorAttribute]
        protected AcsAccessGroup() { }

        public AcsAccessGroup(
            string acsAccessGroupId = default,
            string acsSystemId = default,
            string workspaceId = default,
            string name = default,
            AcsAccessGroup.AccessGroupTypeEnum accessGroupType = default,
            string accessGroupTypeDisplayName = default,
            AcsAccessGroup.ExternalTypeEnum externalType = default,
            string externalTypeDisplayName = default,
            string createdAt = default
        )
        {
            AcsAccessGroupId = acsAccessGroupId;
            AcsSystemId = acsSystemId;
            WorkspaceId = workspaceId;
            Name = name;
            AccessGroupType = accessGroupType;
            AccessGroupTypeDisplayName = accessGroupTypeDisplayName;
            ExternalType = externalType;
            ExternalTypeDisplayName = externalTypeDisplayName;
            CreatedAt = createdAt;
        }

        [JsonConverter(typeof(StringEnumConverter))]
        public enum AccessGroupTypeEnum
        {
            [EnumMember(Value = "pti_unit")]
            PtiUnit = 0,

            [EnumMember(Value = "pti_access_level")]
            PtiAccessLevel = 1,

            [EnumMember(Value = "salto_access_group")]
            SaltoAccessGroup = 2,

            [EnumMember(Value = "brivo_group")]
            BrivoGroup = 3
        }

        [JsonConverter(typeof(StringEnumConverter))]
        public enum ExternalTypeEnum
        {
            [EnumMember(Value = "pti_unit")]
            PtiUnit = 0,

            [EnumMember(Value = "pti_access_level")]
            PtiAccessLevel = 1,

            [EnumMember(Value = "salto_access_group")]
            SaltoAccessGroup = 2,

            [EnumMember(Value = "brivo_group")]
            BrivoGroup = 3
        }

        [DataMember(Name = "acs_access_group_id", IsRequired = true, EmitDefaultValue = false)]
        public string AcsAccessGroupId { get; set; }

        [DataMember(Name = "acs_system_id", IsRequired = true, EmitDefaultValue = false)]
        public string AcsSystemId { get; set; }

        [DataMember(Name = "workspace_id", IsRequired = true, EmitDefaultValue = false)]
        public string WorkspaceId { get; set; }

        [DataMember(Name = "name", IsRequired = true, EmitDefaultValue = false)]
        public string Name { get; set; }

        [DataMember(Name = "access_group_type", IsRequired = true, EmitDefaultValue = false)]
        public AcsAccessGroup.AccessGroupTypeEnum AccessGroupType { get; set; }

        [DataMember(
            Name = "access_group_type_display_name",
            IsRequired = true,
            EmitDefaultValue = false
        )]
        public string AccessGroupTypeDisplayName { get; set; }

        [DataMember(Name = "external_type", IsRequired = true, EmitDefaultValue = false)]
        public AcsAccessGroup.ExternalTypeEnum ExternalType { get; set; }

        [DataMember(
            Name = "external_type_display_name",
            IsRequired = true,
            EmitDefaultValue = false
        )]
        public string ExternalTypeDisplayName { get; set; }

        [DataMember(Name = "created_at", IsRequired = true, EmitDefaultValue = false)]
        public string CreatedAt { get; set; }

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
