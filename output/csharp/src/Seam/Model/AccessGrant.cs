using System.Runtime.Serialization;
using System.Text;
using JsonSubTypes;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using Seam.Model;

namespace Seam.Model
{
    [DataContract(Name = "seamModel_accessGrant_model")]
    public class AccessGrant
    {
        [JsonConstructorAttribute]
        protected AccessGrant() { }

        public AccessGrant(
            string accessGrantId = default,
            List<string> accessMethodIds = default,
            string createdAt = default,
            string displayName = default,
            string? endsAt = default,
            string? instantKeyUrl = default,
            List<string> locationIds = default,
            List<AccessGrantRequestedAccessMethods> requestedAccessMethods = default,
            List<string> spaceIds = default,
            string? startsAt = default,
            string userIdentityId = default,
            string workspaceId = default
        )
        {
            AccessGrantId = accessGrantId;
            AccessMethodIds = accessMethodIds;
            CreatedAt = createdAt;
            DisplayName = displayName;
            EndsAt = endsAt;
            InstantKeyUrl = instantKeyUrl;
            LocationIds = locationIds;
            RequestedAccessMethods = requestedAccessMethods;
            SpaceIds = spaceIds;
            StartsAt = startsAt;
            UserIdentityId = userIdentityId;
            WorkspaceId = workspaceId;
        }

        [DataMember(Name = "access_grant_id", IsRequired = true, EmitDefaultValue = false)]
        public string AccessGrantId { get; set; }

        [DataMember(Name = "access_method_ids", IsRequired = true, EmitDefaultValue = false)]
        public List<string> AccessMethodIds { get; set; }

        [DataMember(Name = "created_at", IsRequired = true, EmitDefaultValue = false)]
        public string CreatedAt { get; set; }

        [DataMember(Name = "display_name", IsRequired = true, EmitDefaultValue = false)]
        public string DisplayName { get; set; }

        [DataMember(Name = "ends_at", IsRequired = false, EmitDefaultValue = false)]
        public string? EndsAt { get; set; }

        [DataMember(Name = "instant_key_url", IsRequired = false, EmitDefaultValue = false)]
        public string? InstantKeyUrl { get; set; }

        [DataMember(Name = "location_ids", IsRequired = true, EmitDefaultValue = false)]
        public List<string> LocationIds { get; set; }

        [DataMember(Name = "requested_access_methods", IsRequired = true, EmitDefaultValue = false)]
        public List<AccessGrantRequestedAccessMethods> RequestedAccessMethods { get; set; }

        [DataMember(Name = "space_ids", IsRequired = true, EmitDefaultValue = false)]
        public List<string> SpaceIds { get; set; }

        [DataMember(Name = "starts_at", IsRequired = false, EmitDefaultValue = false)]
        public string? StartsAt { get; set; }

        [DataMember(Name = "user_identity_id", IsRequired = true, EmitDefaultValue = false)]
        public string UserIdentityId { get; set; }

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

    [DataContract(Name = "seamModel_accessGrantRequestedAccessMethods_model")]
    public class AccessGrantRequestedAccessMethods
    {
        [JsonConstructorAttribute]
        protected AccessGrantRequestedAccessMethods() { }

        public AccessGrantRequestedAccessMethods(
            List<string> createdAccessMethodIds = default,
            string createdAt = default,
            string displayName = default,
            AccessGrantRequestedAccessMethods.ModeEnum mode = default
        )
        {
            CreatedAccessMethodIds = createdAccessMethodIds;
            CreatedAt = createdAt;
            DisplayName = displayName;
            Mode = mode;
        }

        [JsonConverter(typeof(SafeStringEnumConverter))]
        public enum ModeEnum
        {
            [EnumMember(Value = "unrecognized")]
            Unrecognized = 0,

            [EnumMember(Value = "code")]
            Code = 1,

            [EnumMember(Value = "card")]
            Card = 2,

            [EnumMember(Value = "mobile_key")]
            MobileKey = 3,
        }

        [DataMember(
            Name = "created_access_method_ids",
            IsRequired = true,
            EmitDefaultValue = false
        )]
        public List<string> CreatedAccessMethodIds { get; set; }

        [DataMember(Name = "created_at", IsRequired = true, EmitDefaultValue = false)]
        public string CreatedAt { get; set; }

        [DataMember(Name = "display_name", IsRequired = true, EmitDefaultValue = false)]
        public string DisplayName { get; set; }

        [DataMember(Name = "mode", IsRequired = true, EmitDefaultValue = false)]
        public AccessGrantRequestedAccessMethods.ModeEnum Mode { get; set; }

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
