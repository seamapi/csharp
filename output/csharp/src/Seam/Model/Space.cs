using System.Runtime.Serialization;
using System.Text;
using JsonSubTypes;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using Seam.Model;

namespace Seam.Model
{
    [DataContract(Name = "seamModel_space_model")]
    public class Space
    {
        [JsonConstructorAttribute]
        protected Space() { }

        public Space(
            float acsEntranceCount = default,
            string createdAt = default,
            float deviceCount = default,
            string displayName = default,
            string name = default,
            string spaceId = default,
            string workspaceId = default
        )
        {
            AcsEntranceCount = acsEntranceCount;
            CreatedAt = createdAt;
            DeviceCount = deviceCount;
            DisplayName = displayName;
            Name = name;
            SpaceId = spaceId;
            WorkspaceId = workspaceId;
        }

        [DataMember(Name = "acs_entrance_count", IsRequired = true, EmitDefaultValue = false)]
        public float AcsEntranceCount { get; set; }

        [DataMember(Name = "created_at", IsRequired = true, EmitDefaultValue = false)]
        public string CreatedAt { get; set; }

        [DataMember(Name = "device_count", IsRequired = true, EmitDefaultValue = false)]
        public float DeviceCount { get; set; }

        [DataMember(Name = "display_name", IsRequired = true, EmitDefaultValue = false)]
        public string DisplayName { get; set; }

        [DataMember(Name = "name", IsRequired = true, EmitDefaultValue = false)]
        public string Name { get; set; }

        [DataMember(Name = "space_id", IsRequired = true, EmitDefaultValue = false)]
        public string SpaceId { get; set; }

        [DataMember(Name = "workspace_id", IsRequired = true, EmitDefaultValue = false)]
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
