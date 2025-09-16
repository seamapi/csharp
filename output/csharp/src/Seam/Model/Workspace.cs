using System.Runtime.Serialization;
using System.Text;
using JsonSubTypes;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using Seam.Model;

namespace Seam.Model
{
    [DataContract(Name = "seamModel_workspace_model")]
    public class Workspace
    {
        [JsonConstructorAttribute]
        protected Workspace() { }

        public Workspace(
            string companyName = default,
            string? connectPartnerName = default,
            WorkspaceConnectWebviewCustomization connectWebviewCustomization = default,
            bool isSandbox = default,
            bool isSuspended = default,
            string name = default,
            string workspaceId = default
        )
        {
            CompanyName = companyName;
            ConnectPartnerName = connectPartnerName;
            ConnectWebviewCustomization = connectWebviewCustomization;
            IsSandbox = isSandbox;
            IsSuspended = isSuspended;
            Name = name;
            WorkspaceId = workspaceId;
        }

        [DataMember(Name = "company_name", IsRequired = true, EmitDefaultValue = false)]
        public string CompanyName { get; set; }

        [DataMember(Name = "connect_partner_name", IsRequired = false, EmitDefaultValue = false)]
        public string? ConnectPartnerName { get; set; }

        [DataMember(
            Name = "connect_webview_customization",
            IsRequired = true,
            EmitDefaultValue = false
        )]
        public WorkspaceConnectWebviewCustomization ConnectWebviewCustomization { get; set; }

        [DataMember(Name = "is_sandbox", IsRequired = true, EmitDefaultValue = false)]
        public bool IsSandbox { get; set; }

        [DataMember(Name = "is_suspended", IsRequired = true, EmitDefaultValue = false)]
        public bool IsSuspended { get; set; }

        [DataMember(Name = "name", IsRequired = true, EmitDefaultValue = false)]
        public string Name { get; set; }

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

        [JsonConverter(typeof(SafeStringEnumConverter))]
        public enum LogoShapeEnum
        {
            [EnumMember(Value = "unrecognized")]
            Unrecognized = 0,

            [EnumMember(Value = "circle")]
            Circle = 1,

            [EnumMember(Value = "square")]
            Square = 2
        }

        [DataMember(Name = "inviter_logo_url", IsRequired = false, EmitDefaultValue = false)]
        public string? InviterLogoUrl { get; set; }

        [DataMember(Name = "logo_shape", IsRequired = false, EmitDefaultValue = false)]
        public WorkspaceConnectWebviewCustomization.LogoShapeEnum? LogoShape { get; set; }

        [DataMember(Name = "primary_button_color", IsRequired = false, EmitDefaultValue = false)]
        public string? PrimaryButtonColor { get; set; }

        [DataMember(
            Name = "primary_button_text_color",
            IsRequired = false,
            EmitDefaultValue = false
        )]
        public string? PrimaryButtonTextColor { get; set; }

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
