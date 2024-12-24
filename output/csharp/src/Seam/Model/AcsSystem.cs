using System.Runtime.Serialization;
using System.Text;
using JsonSubTypes;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using Seam.Model;

namespace Seam.Model
{
    [DataContract(Name = "seamModel_acsSystem_model")]
    public class AcsSystem
    {
        [JsonConstructorAttribute]
        protected AcsSystem() { }

        public AcsSystem(
            string acsSystemId = default,
            bool? canAddAcsUsersToAcsAccessGroups = default,
            bool? canAutomateEnrollment = default,
            bool? canCreateAcsAccessGroups = default,
            bool? canRemoveAcsUsersFromAcsAccessGroups = default,
            string connectedAccountId = default,
            List<string> connectedAccountIds = default,
            string createdAt = default,
            string? defaultCredentialManagerAcsSystemId = default,
            List<JObject> errors = default,
            AcsSystem.ExternalTypeEnum? externalType = default,
            string? externalTypeDisplayName = default,
            string imageAltText = default,
            string imageUrl = default,
            bool isCredentialManager = default,
            AcsSystemLocation location = default,
            string name = default,
            AcsSystem.SystemTypeEnum? systemType = default,
            string? systemTypeDisplayName = default,
            AcsSystemVisionlineMetadata? visionlineMetadata = default,
            List<JObject> warnings = default,
            string workspaceId = default
        )
        {
            AcsSystemId = acsSystemId;
            CanAddAcsUsersToAcsAccessGroups = canAddAcsUsersToAcsAccessGroups;
            CanAutomateEnrollment = canAutomateEnrollment;
            CanCreateAcsAccessGroups = canCreateAcsAccessGroups;
            CanRemoveAcsUsersFromAcsAccessGroups = canRemoveAcsUsersFromAcsAccessGroups;
            ConnectedAccountId = connectedAccountId;
            ConnectedAccountIds = connectedAccountIds;
            CreatedAt = createdAt;
            DefaultCredentialManagerAcsSystemId = defaultCredentialManagerAcsSystemId;
            Errors = errors;
            ExternalType = externalType;
            ExternalTypeDisplayName = externalTypeDisplayName;
            ImageAltText = imageAltText;
            ImageUrl = imageUrl;
            IsCredentialManager = isCredentialManager;
            Location = location;
            Name = name;
            SystemType = systemType;
            SystemTypeDisplayName = systemTypeDisplayName;
            VisionlineMetadata = visionlineMetadata;
            Warnings = warnings;
            WorkspaceId = workspaceId;
        }

        [JsonConverter(typeof(SafeStringEnumConverter))]
        public enum ExternalTypeEnum
        {
            [EnumMember(Value = "unrecognized")]
            Unrecognized = 0,

            [EnumMember(Value = "pti_site")]
            PtiSite = 1,

            [EnumMember(Value = "alta_org")]
            AltaOrg = 2,

            [EnumMember(Value = "salto_ks_site")]
            SaltoKsSite = 3,

            [EnumMember(Value = "salto_space_system")]
            SaltoSpaceSystem = 4,

            [EnumMember(Value = "brivo_account")]
            BrivoAccount = 5,

            [EnumMember(Value = "hid_credential_manager_organization")]
            HidCredentialManagerOrganization = 6,

            [EnumMember(Value = "visionline_system")]
            VisionlineSystem = 7,

            [EnumMember(Value = "assa_abloy_credential_service")]
            AssaAbloyCredentialService = 8,

            [EnumMember(Value = "latch_building")]
            LatchBuilding = 9,

            [EnumMember(Value = "dormakaba_community_site")]
            DormakabaCommunitySite = 10,

            [EnumMember(Value = "legic_connect_credential_service")]
            LegicConnectCredentialService = 11,

            [EnumMember(Value = "assa_abloy_vostio")]
            AssaAbloyVostio = 12,

            [EnumMember(Value = "assa_abloy_vostio_credential_service")]
            AssaAbloyVostioCredentialService = 13,
        }

        [JsonConverter(typeof(SafeStringEnumConverter))]
        public enum SystemTypeEnum
        {
            [EnumMember(Value = "unrecognized")]
            Unrecognized = 0,

            [EnumMember(Value = "pti_site")]
            PtiSite = 1,

            [EnumMember(Value = "alta_org")]
            AltaOrg = 2,

            [EnumMember(Value = "salto_ks_site")]
            SaltoKsSite = 3,

            [EnumMember(Value = "salto_space_system")]
            SaltoSpaceSystem = 4,

            [EnumMember(Value = "brivo_account")]
            BrivoAccount = 5,

            [EnumMember(Value = "hid_credential_manager_organization")]
            HidCredentialManagerOrganization = 6,

            [EnumMember(Value = "visionline_system")]
            VisionlineSystem = 7,

            [EnumMember(Value = "assa_abloy_credential_service")]
            AssaAbloyCredentialService = 8,

            [EnumMember(Value = "latch_building")]
            LatchBuilding = 9,

            [EnumMember(Value = "dormakaba_community_site")]
            DormakabaCommunitySite = 10,

            [EnumMember(Value = "legic_connect_credential_service")]
            LegicConnectCredentialService = 11,

            [EnumMember(Value = "assa_abloy_vostio")]
            AssaAbloyVostio = 12,

            [EnumMember(Value = "assa_abloy_vostio_credential_service")]
            AssaAbloyVostioCredentialService = 13,
        }

        [DataMember(Name = "acs_system_id", IsRequired = true, EmitDefaultValue = false)]
        public string AcsSystemId { get; set; }

        [DataMember(
            Name = "can_add_acs_users_to_acs_access_groups",
            IsRequired = false,
            EmitDefaultValue = false
        )]
        public bool? CanAddAcsUsersToAcsAccessGroups { get; set; }

        [DataMember(Name = "can_automate_enrollment", IsRequired = false, EmitDefaultValue = false)]
        public bool? CanAutomateEnrollment { get; set; }

        [DataMember(
            Name = "can_create_acs_access_groups",
            IsRequired = false,
            EmitDefaultValue = false
        )]
        public bool? CanCreateAcsAccessGroups { get; set; }

        [DataMember(
            Name = "can_remove_acs_users_from_acs_access_groups",
            IsRequired = false,
            EmitDefaultValue = false
        )]
        public bool? CanRemoveAcsUsersFromAcsAccessGroups { get; set; }

        [DataMember(Name = "connected_account_id", IsRequired = true, EmitDefaultValue = false)]
        public string ConnectedAccountId { get; set; }

        [DataMember(Name = "connected_account_ids", IsRequired = true, EmitDefaultValue = false)]
        public List<string> ConnectedAccountIds { get; set; }

        [DataMember(Name = "created_at", IsRequired = true, EmitDefaultValue = false)]
        public string CreatedAt { get; set; }

        [DataMember(
            Name = "default_credential_manager_acs_system_id",
            IsRequired = false,
            EmitDefaultValue = false
        )]
        public string? DefaultCredentialManagerAcsSystemId { get; set; }

        [DataMember(Name = "errors", IsRequired = true, EmitDefaultValue = false)]
        public List<JObject> Errors { get; set; }

        [DataMember(Name = "external_type", IsRequired = false, EmitDefaultValue = false)]
        public AcsSystem.ExternalTypeEnum? ExternalType { get; set; }

        [DataMember(
            Name = "external_type_display_name",
            IsRequired = false,
            EmitDefaultValue = false
        )]
        public string? ExternalTypeDisplayName { get; set; }

        [DataMember(Name = "image_alt_text", IsRequired = true, EmitDefaultValue = false)]
        public string ImageAltText { get; set; }

        [DataMember(Name = "image_url", IsRequired = true, EmitDefaultValue = false)]
        public string ImageUrl { get; set; }

        [DataMember(Name = "is_credential_manager", IsRequired = true, EmitDefaultValue = false)]
        public bool IsCredentialManager { get; set; }

        [DataMember(Name = "location", IsRequired = true, EmitDefaultValue = false)]
        public AcsSystemLocation Location { get; set; }

        [DataMember(Name = "name", IsRequired = true, EmitDefaultValue = false)]
        public string Name { get; set; }

        [DataMember(Name = "system_type", IsRequired = false, EmitDefaultValue = false)]
        public AcsSystem.SystemTypeEnum? SystemType { get; set; }

        [DataMember(
            Name = "system_type_display_name",
            IsRequired = false,
            EmitDefaultValue = false
        )]
        public string? SystemTypeDisplayName { get; set; }

        [DataMember(Name = "visionline_metadata", IsRequired = false, EmitDefaultValue = false)]
        public AcsSystemVisionlineMetadata? VisionlineMetadata { get; set; }

        [DataMember(Name = "warnings", IsRequired = true, EmitDefaultValue = false)]
        public List<JObject> Warnings { get; set; }

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

    [DataContract(Name = "seamModel_acsSystemLocation_model")]
    public class AcsSystemLocation
    {
        [JsonConstructorAttribute]
        protected AcsSystemLocation() { }

        public AcsSystemLocation(string? timeZone = default)
        {
            TimeZone = timeZone;
        }

        [DataMember(Name = "time_zone", IsRequired = false, EmitDefaultValue = false)]
        public string? TimeZone { get; set; }

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

    [DataContract(Name = "seamModel_acsSystemVisionlineMetadata_model")]
    public class AcsSystemVisionlineMetadata
    {
        [JsonConstructorAttribute]
        protected AcsSystemVisionlineMetadata() { }

        public AcsSystemVisionlineMetadata(
            string lanAddress = default,
            string mobileAccessUuid = default,
            string systemId = default
        )
        {
            LanAddress = lanAddress;
            MobileAccessUuid = mobileAccessUuid;
            SystemId = systemId;
        }

        [DataMember(Name = "lan_address", IsRequired = true, EmitDefaultValue = false)]
        public string LanAddress { get; set; }

        [DataMember(Name = "mobile_access_uuid", IsRequired = true, EmitDefaultValue = false)]
        public string MobileAccessUuid { get; set; }

        [DataMember(Name = "system_id", IsRequired = true, EmitDefaultValue = false)]
        public string SystemId { get; set; }

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
