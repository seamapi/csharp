using System.Runtime.Serialization;
using System.Text;
using JsonSubTypes;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using Seam.Model;

namespace Seam.Model
{
    [DataContract(Name = "seamModel_customizationProfile_model")]
    public class CustomizationProfile
    {
        [JsonConstructorAttribute]
        protected CustomizationProfile() { }

        public CustomizationProfile(
            string createdAt = default,
            string customizationProfileId = default,
            string? logoUrl = default,
            string? name = default,
            string? primaryColor = default,
            string? secondaryColor = default,
            string workspaceId = default
        )
        {
            CreatedAt = createdAt;
            CustomizationProfileId = customizationProfileId;
            LogoUrl = logoUrl;
            Name = name;
            PrimaryColor = primaryColor;
            SecondaryColor = secondaryColor;
            WorkspaceId = workspaceId;
        }

        [DataMember(Name = "created_at", IsRequired = true, EmitDefaultValue = false)]
        public string CreatedAt { get; set; }

        [DataMember(Name = "customization_profile_id", IsRequired = true, EmitDefaultValue = false)]
        public string CustomizationProfileId { get; set; }

        [DataMember(Name = "logo_url", IsRequired = false, EmitDefaultValue = false)]
        public string? LogoUrl { get; set; }

        [DataMember(Name = "name", IsRequired = false, EmitDefaultValue = false)]
        public string? Name { get; set; }

        [DataMember(Name = "primary_color", IsRequired = false, EmitDefaultValue = false)]
        public string? PrimaryColor { get; set; }

        [DataMember(Name = "secondary_color", IsRequired = false, EmitDefaultValue = false)]
        public string? SecondaryColor { get; set; }

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
