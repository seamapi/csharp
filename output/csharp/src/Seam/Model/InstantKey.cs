using System.Runtime.Serialization;
using System.Text;
using JsonSubTypes;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using Seam.Model;

namespace Seam.Model
{
    [DataContract(Name = "seamModel_instantKey_model")]
    public class InstantKey
    {
        [JsonConstructorAttribute]
        protected InstantKey() { }

        public InstantKey(
            string clientSessionId = default,
            string createdAt = default,
            InstantKeyCustomization? customization = default,
            string? customizationProfileId = default,
            string expiresAt = default,
            string instantKeyId = default,
            string instantKeyUrl = default,
            string userIdentityId = default,
            string workspaceId = default
        )
        {
            ClientSessionId = clientSessionId;
            CreatedAt = createdAt;
            Customization = customization;
            CustomizationProfileId = customizationProfileId;
            ExpiresAt = expiresAt;
            InstantKeyId = instantKeyId;
            InstantKeyUrl = instantKeyUrl;
            UserIdentityId = userIdentityId;
            WorkspaceId = workspaceId;
        }

        [DataMember(Name = "client_session_id", IsRequired = true, EmitDefaultValue = false)]
        public string ClientSessionId { get; set; }

        [DataMember(Name = "created_at", IsRequired = true, EmitDefaultValue = false)]
        public string CreatedAt { get; set; }

        [DataMember(Name = "customization", IsRequired = false, EmitDefaultValue = false)]
        public InstantKeyCustomization? Customization { get; set; }

        [DataMember(
            Name = "customization_profile_id",
            IsRequired = false,
            EmitDefaultValue = false
        )]
        public string? CustomizationProfileId { get; set; }

        [DataMember(Name = "expires_at", IsRequired = true, EmitDefaultValue = false)]
        public string ExpiresAt { get; set; }

        [DataMember(Name = "instant_key_id", IsRequired = true, EmitDefaultValue = false)]
        public string InstantKeyId { get; set; }

        [DataMember(Name = "instant_key_url", IsRequired = true, EmitDefaultValue = false)]
        public string InstantKeyUrl { get; set; }

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

    [DataContract(Name = "seamModel_instantKeyCustomization_model")]
    public class InstantKeyCustomization
    {
        [JsonConstructorAttribute]
        protected InstantKeyCustomization() { }

        public InstantKeyCustomization(
            string? logoUrl = default,
            string? primaryColor = default,
            string? secondaryColor = default
        )
        {
            LogoUrl = logoUrl;
            PrimaryColor = primaryColor;
            SecondaryColor = secondaryColor;
        }

        [DataMember(Name = "logo_url", IsRequired = false, EmitDefaultValue = false)]
        public string? LogoUrl { get; set; }

        [DataMember(Name = "primary_color", IsRequired = false, EmitDefaultValue = false)]
        public string? PrimaryColor { get; set; }

        [DataMember(Name = "secondary_color", IsRequired = false, EmitDefaultValue = false)]
        public string? SecondaryColor { get; set; }

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
