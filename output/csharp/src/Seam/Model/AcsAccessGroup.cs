using System.Runtime.Serialization;
using System.Text;
using JsonSubTypes;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using Seam.Model;

namespace Seam.Model
{
    [DataContract(Name = "seamModel_acsAccessGroup_model")]
    public class AcsAccessGroup
    {
        [JsonConstructorAttribute]
        protected AcsAccessGroup() { }

        public AcsAccessGroup(
            AcsAccessGroup.AccessGroupTypeEnum accessGroupType = default,
            string accessGroupTypeDisplayName = default,
            string acsAccessGroupId = default,
            string acsSystemId = default,
            string connectedAccountId = default,
            string createdAt = default,
            string displayName = default,
            AcsAccessGroup.ExternalTypeEnum externalType = default,
            string externalTypeDisplayName = default,
            bool isManaged = default,
            string name = default,
            List<AcsAccessGroupWarnings> warnings = default,
            string workspaceId = default
        )
        {
            AccessGroupType = accessGroupType;
            AccessGroupTypeDisplayName = accessGroupTypeDisplayName;
            AcsAccessGroupId = acsAccessGroupId;
            AcsSystemId = acsSystemId;
            ConnectedAccountId = connectedAccountId;
            CreatedAt = createdAt;
            DisplayName = displayName;
            ExternalType = externalType;
            ExternalTypeDisplayName = externalTypeDisplayName;
            IsManaged = isManaged;
            Name = name;
            Warnings = warnings;
            WorkspaceId = workspaceId;
        }

        [JsonConverter(typeof(SafeStringEnumConverter))]
        public enum AccessGroupTypeEnum
        {
            [EnumMember(Value = "unrecognized")]
            Unrecognized = 0,

            [EnumMember(Value = "pti_unit")]
            PtiUnit = 1,

            [EnumMember(Value = "pti_access_level")]
            PtiAccessLevel = 2,

            [EnumMember(Value = "salto_ks_access_group")]
            SaltoKsAccessGroup = 3,

            [EnumMember(Value = "brivo_group")]
            BrivoGroup = 4,

            [EnumMember(Value = "salto_space_group")]
            SaltoSpaceGroup = 5,

            [EnumMember(Value = "dormakaba_community_access_group")]
            DormakabaCommunityAccessGroup = 6,

            [EnumMember(Value = "dormakaba_ambiance_access_group")]
            DormakabaAmbianceAccessGroup = 7,
        }

        [JsonConverter(typeof(SafeStringEnumConverter))]
        public enum ExternalTypeEnum
        {
            [EnumMember(Value = "unrecognized")]
            Unrecognized = 0,

            [EnumMember(Value = "pti_unit")]
            PtiUnit = 1,

            [EnumMember(Value = "pti_access_level")]
            PtiAccessLevel = 2,

            [EnumMember(Value = "salto_ks_access_group")]
            SaltoKsAccessGroup = 3,

            [EnumMember(Value = "brivo_group")]
            BrivoGroup = 4,

            [EnumMember(Value = "salto_space_group")]
            SaltoSpaceGroup = 5,

            [EnumMember(Value = "dormakaba_community_access_group")]
            DormakabaCommunityAccessGroup = 6,

            [EnumMember(Value = "dormakaba_ambiance_access_group")]
            DormakabaAmbianceAccessGroup = 7,
        }

        [DataMember(Name = "access_group_type", IsRequired = true, EmitDefaultValue = false)]
        public AcsAccessGroup.AccessGroupTypeEnum AccessGroupType { get; set; }

        [DataMember(
            Name = "access_group_type_display_name",
            IsRequired = true,
            EmitDefaultValue = false
        )]
        public string AccessGroupTypeDisplayName { get; set; }

        [DataMember(Name = "acs_access_group_id", IsRequired = true, EmitDefaultValue = false)]
        public string AcsAccessGroupId { get; set; }

        [DataMember(Name = "acs_system_id", IsRequired = true, EmitDefaultValue = false)]
        public string AcsSystemId { get; set; }

        [DataMember(Name = "connected_account_id", IsRequired = true, EmitDefaultValue = false)]
        public string ConnectedAccountId { get; set; }

        [DataMember(Name = "created_at", IsRequired = true, EmitDefaultValue = false)]
        public string CreatedAt { get; set; }

        [DataMember(Name = "display_name", IsRequired = true, EmitDefaultValue = false)]
        public string DisplayName { get; set; }

        [DataMember(Name = "external_type", IsRequired = true, EmitDefaultValue = false)]
        public AcsAccessGroup.ExternalTypeEnum ExternalType { get; set; }

        [DataMember(
            Name = "external_type_display_name",
            IsRequired = true,
            EmitDefaultValue = false
        )]
        public string ExternalTypeDisplayName { get; set; }

        [DataMember(Name = "is_managed", IsRequired = true, EmitDefaultValue = false)]
        public bool IsManaged { get; set; }

        [DataMember(Name = "name", IsRequired = true, EmitDefaultValue = false)]
        public string Name { get; set; }

        [DataMember(Name = "warnings", IsRequired = true, EmitDefaultValue = false)]
        public List<AcsAccessGroupWarnings> Warnings { get; set; }

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

    [DataContract(Name = "seamModel_acsAccessGroupWarnings_model")]
    public class AcsAccessGroupWarnings
    {
        [JsonConstructorAttribute]
        protected AcsAccessGroupWarnings() { }

        public AcsAccessGroupWarnings(
            string createdAt = default,
            string message = default,
            AcsAccessGroupWarnings.WarningCodeEnum warningCode = default
        )
        {
            CreatedAt = createdAt;
            Message = message;
            WarningCode = warningCode;
        }

        [JsonConverter(typeof(SafeStringEnumConverter))]
        public enum WarningCodeEnum
        {
            [EnumMember(Value = "unrecognized")]
            Unrecognized = 0,

            [EnumMember(Value = "unknown_issue_with_acs_access_group")]
            UnknownIssueWithAcsAccessGroup = 1,
        }

        [DataMember(Name = "created_at", IsRequired = true, EmitDefaultValue = false)]
        public string CreatedAt { get; set; }

        [DataMember(Name = "message", IsRequired = true, EmitDefaultValue = false)]
        public string Message { get; set; }

        [DataMember(Name = "warning_code", IsRequired = true, EmitDefaultValue = false)]
        public AcsAccessGroupWarnings.WarningCodeEnum WarningCode { get; set; }

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
