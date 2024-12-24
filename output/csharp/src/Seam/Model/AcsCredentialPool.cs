using System.Runtime.Serialization;
using System.Text;
using JsonSubTypes;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using Seam.Model;

namespace Seam.Model
{
    [DataContract(Name = "seamModel_acsCredentialPool_model")]
    public class AcsCredentialPool
    {
        [JsonConstructorAttribute]
        protected AcsCredentialPool() { }

        public AcsCredentialPool(
            string acsCredentialPoolId = default,
            string acsSystemId = default,
            string createdAt = default,
            string displayName = default,
            AcsCredentialPool.ExternalTypeEnum externalType = default,
            string externalTypeDisplayName = default,
            string workspaceId = default
        )
        {
            AcsCredentialPoolId = acsCredentialPoolId;
            AcsSystemId = acsSystemId;
            CreatedAt = createdAt;
            DisplayName = displayName;
            ExternalType = externalType;
            ExternalTypeDisplayName = externalTypeDisplayName;
            WorkspaceId = workspaceId;
        }

        [JsonConverter(typeof(SafeStringEnumConverter))]
        public enum ExternalTypeEnum
        {
            [EnumMember(Value = "unrecognized")]
            Unrecognized = 0,

            [EnumMember(Value = "hid_part_number")]
            HidPartNumber = 1,
        }

        [DataMember(Name = "acs_credential_pool_id", IsRequired = true, EmitDefaultValue = false)]
        public string AcsCredentialPoolId { get; set; }

        [DataMember(Name = "acs_system_id", IsRequired = true, EmitDefaultValue = false)]
        public string AcsSystemId { get; set; }

        [DataMember(Name = "created_at", IsRequired = true, EmitDefaultValue = false)]
        public string CreatedAt { get; set; }

        [DataMember(Name = "display_name", IsRequired = true, EmitDefaultValue = false)]
        public string DisplayName { get; set; }

        [DataMember(Name = "external_type", IsRequired = true, EmitDefaultValue = false)]
        public AcsCredentialPool.ExternalTypeEnum ExternalType { get; set; }

        [DataMember(
            Name = "external_type_display_name",
            IsRequired = true,
            EmitDefaultValue = false
        )]
        public string ExternalTypeDisplayName { get; set; }

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
