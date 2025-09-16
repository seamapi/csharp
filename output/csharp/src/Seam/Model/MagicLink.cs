using System.Runtime.Serialization;
using System.Text;
using JsonSubTypes;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using Seam.Model;

namespace Seam.Model
{
    [DataContract(Name = "seamModel_magicLink_model")]
    public class MagicLink
    {
        [JsonConstructorAttribute]
        protected MagicLink() { }

        public MagicLink(
            MagicLink.BuildingBlockTypeEnum buildingBlockType = default,
            string createdAt = default,
            string customerKey = default,
            string expiresAt = default,
            string url = default,
            string workspaceId = default
        )
        {
            BuildingBlockType = buildingBlockType;
            CreatedAt = createdAt;
            CustomerKey = customerKey;
            ExpiresAt = expiresAt;
            Url = url;
            WorkspaceId = workspaceId;
        }

        [JsonConverter(typeof(SafeStringEnumConverter))]
        public enum BuildingBlockTypeEnum
        {
            [EnumMember(Value = "unrecognized")]
            Unrecognized = 0,

            [EnumMember(Value = "connect_accounts")]
            ConnectAccounts = 1,

            [EnumMember(Value = "manage_devices")]
            ManageDevices = 2,

            [EnumMember(Value = "organize_spaces")]
            OrganizeSpaces = 3,

            [EnumMember(Value = "console")]
            Console = 4,
        }

        [DataMember(Name = "building_block_type", IsRequired = true, EmitDefaultValue = false)]
        public MagicLink.BuildingBlockTypeEnum BuildingBlockType { get; set; }

        [DataMember(Name = "created_at", IsRequired = true, EmitDefaultValue = false)]
        public string CreatedAt { get; set; }

        [DataMember(Name = "customer_key", IsRequired = true, EmitDefaultValue = false)]
        public string CustomerKey { get; set; }

        [DataMember(Name = "expires_at", IsRequired = true, EmitDefaultValue = false)]
        public string ExpiresAt { get; set; }

        [DataMember(Name = "url", IsRequired = true, EmitDefaultValue = false)]
        public string Url { get; set; }

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
