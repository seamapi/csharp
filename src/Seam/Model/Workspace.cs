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
    /// Represents a Seam [workspace](https://docs.seam.co/core-concepts/workspaces). A workspace is a top-level entity that encompasses all other resources below it, such as devices, connected accounts, and Connect Webviews. Seam provides two types of workspaces. A [sandbox workspace](https://docs.seam.co/core-concepts/workspaces#sandbox-workspaces) is a special type of workspace designed for testing code. Sandbox workspaces offer test device accounts and virtual devices that you can connect and control. This ability to work with virtual devices is quite handy because it removes the need to own physical devices from multiple brands. To connect real devices and systems to Seam, use a [production workspace](https://docs.seam.co/core-concepts/workspaces#production-workspaces).
    /// </summary>
    [DataContract(Name = "seamModel_workspace_model")]
    public class Workspace
    {
        [JsonConstructorAttribute]
        protected Workspace() { }

        public Workspace(
            string companyName = default,
            string? connectPartnerName = default,
            WorkspaceConnectWebviewCustomization connectWebviewCustomization = default,
            bool isPublishableKeyAuthEnabled = default,
            bool isSandbox = default,
            bool isSuspended = default,
            string name = default,
            string? organizationId = default,
            string? publishableKey = default,
            string workspaceId = default
        )
        {
            CompanyName = companyName;
            ConnectPartnerName = connectPartnerName;
            ConnectWebviewCustomization = connectWebviewCustomization;
            IsPublishableKeyAuthEnabled = isPublishableKeyAuthEnabled;
            IsSandbox = isSandbox;
            IsSuspended = isSuspended;
            Name = name;
            OrganizationId = organizationId;
            PublishableKey = publishableKey;
            WorkspaceId = workspaceId;
        }

        /// <summary>
        /// Company name associated with the [workspace](https://docs.seam.co/core-concepts/workspaces).
        /// </summary>
        [Obsolete("Use `connect_partner_name` instead.")]
        [DataMember(Name = "company_name", IsRequired = false, EmitDefaultValue = false)]
        public string CompanyName { get; set; }

        /// <summary>
        /// Seam Connect partner name associated with the [workspace](https://docs.seam.co/core-concepts/workspaces).
        /// </summary>
        [DataMember(Name = "connect_partner_name", IsRequired = false, EmitDefaultValue = false)]
        public string? ConnectPartnerName { get; set; }

        [DataMember(
            Name = "connect_webview_customization",
            IsRequired = false,
            EmitDefaultValue = false
        )]
        public WorkspaceConnectWebviewCustomization ConnectWebviewCustomization { get; set; }

        /// <summary>
        /// Indicates whether publishable key authentication is enabled for this workspace.
        /// </summary>
        [DataMember(
            Name = "is_publishable_key_auth_enabled",
            IsRequired = false,
            EmitDefaultValue = false
        )]
        public bool IsPublishableKeyAuthEnabled { get; set; }

        /// <summary>
        /// Indicates whether the workspace is a [sandbox workspace](https://docs.seam.co/core-concepts/workspaces#sandbox-workspaces).
        /// </summary>
        [DataMember(Name = "is_sandbox", IsRequired = false, EmitDefaultValue = false)]
        public bool IsSandbox { get; set; }

        /// <summary>
        /// Indicates whether the [sandbox workspace](https://docs.seam.co/core-concepts/workspaces#sandbox-workspaces) is suspended. Seam suspends sandbox workspaces that have not been accessed in 14 days.
        /// </summary>
        [DataMember(Name = "is_suspended", IsRequired = false, EmitDefaultValue = false)]
        public bool IsSuspended { get; set; }

        /// <summary>
        /// Name of the [workspace](https://docs.seam.co/core-concepts/workspaces).
        /// </summary>
        [DataMember(Name = "name", IsRequired = false, EmitDefaultValue = false)]
        public string Name { get; set; }

        /// <summary>
        /// ID of the organization to which the workspace belongs, or `null` if the workspace is not assigned to an organization.
        /// </summary>
        [DataMember(Name = "organization_id", IsRequired = false, EmitDefaultValue = false)]
        public string? OrganizationId { get; set; }

        /// <summary>
        /// Publishable key for the [workspace](https://docs.seam.co/core-concepts/workspaces). This key is used to identify the workspace in client-side applications.
        /// </summary>
        [DataMember(Name = "publishable_key", IsRequired = false, EmitDefaultValue = false)]
        public string? PublishableKey { get; set; }

        /// <summary>
        /// ID of the workspace.
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

    [DataContract(Name = "seamModel_workspaceConnectWebviewCustomization_model")]
    public class WorkspaceConnectWebviewCustomization
    {
        [JsonConstructorAttribute]
        protected WorkspaceConnectWebviewCustomization() { }

        public WorkspaceConnectWebviewCustomization(
            string? inviterLogoUrl = default,
            WorkspaceConnectWebviewCustomization.LogoShapeEnum? logoShape = default,
            string? primaryButtonColor = default,
            string? primaryButtonTextColor = default,
            string? successMessage = default
        )
        {
            InviterLogoUrl = inviterLogoUrl;
            LogoShape = logoShape;
            PrimaryButtonColor = primaryButtonColor;
            PrimaryButtonTextColor = primaryButtonTextColor;
            SuccessMessage = successMessage;
        }

        /// <summary>
        /// Logo shape for [Connect Webviews](https://docs.seam.co/core-concepts/connect-webviews) in the workspace. See also [Customize the Look and Feel of Your Connect Webviews](https://docs.seam.co/core-concepts/connect-webviews/customizing-connect-webviews#customize-the-look-and-feel-of-your-connect-webviews).
        /// </summary>
        [JsonConverter(typeof(SafeStringEnumConverter))]
        public enum LogoShapeEnum
        {
            [EnumMember(Value = "unrecognized")]
            Unrecognized = 0,

            [EnumMember(Value = "circle")]
            Circle = 1,

            [EnumMember(Value = "square")]
            Square = 2,
        }

        /// <summary>
        /// URL of the inviter logo for [Connect Webviews](https://docs.seam.co/core-concepts/connect-webviews) in the workspace. See also [Customize the Look and Feel of Your Connect Webviews](https://docs.seam.co/core-concepts/connect-webviews/customizing-connect-webviews#customize-the-look-and-feel-of-your-connect-webviews).
        /// </summary>
        [DataMember(Name = "inviter_logo_url", IsRequired = false, EmitDefaultValue = false)]
        public string? InviterLogoUrl { get; set; }

        /// <summary>
        /// Logo shape for [Connect Webviews](https://docs.seam.co/core-concepts/connect-webviews) in the workspace. See also [Customize the Look and Feel of Your Connect Webviews](https://docs.seam.co/core-concepts/connect-webviews/customizing-connect-webviews#customize-the-look-and-feel-of-your-connect-webviews).
        /// </summary>
        [DataMember(Name = "logo_shape", IsRequired = false, EmitDefaultValue = false)]
        public WorkspaceConnectWebviewCustomization.LogoShapeEnum? LogoShape { get; set; }

        /// <summary>
        /// Primary button color for [Connect Webviews](https://docs.seam.co/core-concepts/connect-webviews) in the workspace. See also [Customize the Look and Feel of Your Connect Webviews](https://docs.seam.co/core-concepts/connect-webviews/customizing-connect-webviews#customize-the-look-and-feel-of-your-connect-webviews).
        /// </summary>
        [DataMember(Name = "primary_button_color", IsRequired = false, EmitDefaultValue = false)]
        public string? PrimaryButtonColor { get; set; }

        /// <summary>
        /// Primary button text color for [Connect Webviews](https://docs.seam.co/core-concepts/connect-webviews) in the workspace. See also [Customize the Look and Feel of Your Connect Webviews](https://docs.seam.co/core-concepts/connect-webviews/customizing-connect-webviews#customize-the-look-and-feel-of-your-connect-webviews).
        /// </summary>
        [DataMember(
            Name = "primary_button_text_color",
            IsRequired = false,
            EmitDefaultValue = false
        )]
        public string? PrimaryButtonTextColor { get; set; }

        /// <summary>
        /// Success message for [Connect Webviews](https://docs.seam.co/core-concepts/connect-webviews) in the workspace. See also [Customize the Look and Feel of Your Connect Webviews](https://docs.seam.co/core-concepts/connect-webviews/customizing-connect-webviews#customize-the-look-and-feel-of-your-connect-webviews).
        /// </summary>
        [DataMember(Name = "success_message", IsRequired = false, EmitDefaultValue = false)]
        public string? SuccessMessage { get; set; }

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
