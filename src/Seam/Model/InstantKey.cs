using System.Runtime.Serialization;
using System.Text;
using JsonSubTypes;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using Seam.Model;

namespace Seam.Model
{
    /// <summary>
    /// Represents a Seam Instant Key. For issuing Bluetooth mobile keys, Instant Keys are the fastest way to share access. With a single API call, you can create a mobile key and send it through text or email or embed it in your own app.
    ///
    /// There’s no app to install, nor account to create. Your user just taps a link and gets a lightweight, native-feeling experience using iOS App Clip or Instant Apps on Android. Further, Instant Keys work offline, so even in areas with poor cellular or Wi-Fi, like elevator banks or concrete-walled hallways, the Instant Keys still work.
    /// </summary>
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

        /// <summary>
        /// ID of the client session associated with the Instant Key.
        /// </summary>
        [DataMember(Name = "client_session_id", IsRequired = false, EmitDefaultValue = false)]
        public string ClientSessionId { get; set; }

        /// <summary>
        /// Date and time at which the Instant Key was created.
        /// </summary>
        [DataMember(Name = "created_at", IsRequired = false, EmitDefaultValue = false)]
        public string CreatedAt { get; set; }

        /// <summary>
        /// Customization applied to the Instant Key UI.
        /// </summary>
        [DataMember(Name = "customization", IsRequired = false, EmitDefaultValue = false)]
        public InstantKeyCustomization? Customization { get; set; }

        /// <summary>
        /// ID of the customization profile associated with the Instant Key.
        /// </summary>
        [DataMember(
            Name = "customization_profile_id",
            IsRequired = false,
            EmitDefaultValue = false
        )]
        public string? CustomizationProfileId { get; set; }

        /// <summary>
        /// Date and time at which the Instant Key expires.
        /// </summary>
        [DataMember(Name = "expires_at", IsRequired = false, EmitDefaultValue = false)]
        public string ExpiresAt { get; set; }

        /// <summary>
        /// ID of the Instant Key.
        /// </summary>
        [DataMember(Name = "instant_key_id", IsRequired = false, EmitDefaultValue = false)]
        public string InstantKeyId { get; set; }

        /// <summary>
        /// Shareable URL for the Instant Key. Use the URL to deliver the Instant Key to your user through a link in a text message or email or by embedding it in your web app.
        /// </summary>
        [DataMember(Name = "instant_key_url", IsRequired = false, EmitDefaultValue = false)]
        public string InstantKeyUrl { get; set; }

        /// <summary>
        /// ID of the user identity associated with the Instant Key.
        /// </summary>
        [DataMember(Name = "user_identity_id", IsRequired = false, EmitDefaultValue = false)]
        public string UserIdentityId { get; set; }

        /// <summary>
        /// ID of the workspace that contains the Instant Key.
        /// </summary>
        [DataMember(Name = "workspace_id", IsRequired = false, EmitDefaultValue = false)]
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

        /// <summary>
        /// URL of the logo displayed on the Instant Key.
        /// </summary>
        [DataMember(Name = "logo_url", IsRequired = false, EmitDefaultValue = false)]
        public string? LogoUrl { get; set; }

        /// <summary>
        /// Primary color used in the Instant Key UI.
        /// </summary>
        [DataMember(Name = "primary_color", IsRequired = false, EmitDefaultValue = false)]
        public string? PrimaryColor { get; set; }

        /// <summary>
        /// Secondary color used in the Instant Key UI.
        /// </summary>
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
