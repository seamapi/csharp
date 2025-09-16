using System.Runtime.Serialization;
using System.Text;
using JsonSubTypes;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using Seam.Model;

namespace Seam.Model
{
    [DataContract(Name = "seamModel_connectWebview_model")]
    public class ConnectWebview
    {
        [JsonConstructorAttribute]
        protected ConnectWebview() { }

        public ConnectWebview(
            List<ConnectWebview.AcceptedCapabilitiesEnum> acceptedCapabilities = default,
            List<string> acceptedDevices = default,
            List<string> acceptedProviders = default,
            bool anyDeviceAllowed = default,
            bool anyProviderAllowed = default,
            string? authorizedAt = default,
            bool automaticallyManageNewDevices = default,
            string connectWebviewId = default,
            string? connectedAccountId = default,
            string createdAt = default,
            object? customMetadata = default,
            string? customRedirectFailureUrl = default,
            string? customRedirectUrl = default,
            string? customerKey = default,
            ConnectWebview.DeviceSelectionModeEnum deviceSelectionMode = default,
            bool loginSuccessful = default,
            string? selectedProvider = default,
            ConnectWebview.StatusEnum status = default,
            string url = default,
            bool waitForDeviceCreation = default,
            string workspaceId = default
        )
        {
            AcceptedCapabilities = acceptedCapabilities;
            AcceptedDevices = acceptedDevices;
            AcceptedProviders = acceptedProviders;
            AnyDeviceAllowed = anyDeviceAllowed;
            AnyProviderAllowed = anyProviderAllowed;
            AuthorizedAt = authorizedAt;
            AutomaticallyManageNewDevices = automaticallyManageNewDevices;
            ConnectWebviewId = connectWebviewId;
            ConnectedAccountId = connectedAccountId;
            CreatedAt = createdAt;
            CustomMetadata = customMetadata;
            CustomRedirectFailureUrl = customRedirectFailureUrl;
            CustomRedirectUrl = customRedirectUrl;
            CustomerKey = customerKey;
            DeviceSelectionMode = deviceSelectionMode;
            LoginSuccessful = loginSuccessful;
            SelectedProvider = selectedProvider;
            Status = status;
            Url = url;
            WaitForDeviceCreation = waitForDeviceCreation;
            WorkspaceId = workspaceId;
        }

        [JsonConverter(typeof(SafeStringEnumConverter))]
        public enum AcceptedCapabilitiesEnum
        {
            [EnumMember(Value = "unrecognized")]
            Unrecognized = 0,

            [EnumMember(Value = "lock")]
            Lock = 1,

            [EnumMember(Value = "thermostat")]
            Thermostat = 2,

            [EnumMember(Value = "noise_sensor")]
            NoiseSensor = 3,

            [EnumMember(Value = "access_control")]
            AccessControl = 4
        }

        [JsonConverter(typeof(SafeStringEnumConverter))]
        public enum DeviceSelectionModeEnum
        {
            [EnumMember(Value = "unrecognized")]
            Unrecognized = 0,

            [EnumMember(Value = "none")]
            None = 1,

            [EnumMember(Value = "single")]
            Single = 2,

            [EnumMember(Value = "multiple")]
            Multiple = 3
        }

        [JsonConverter(typeof(SafeStringEnumConverter))]
        public enum StatusEnum
        {
            [EnumMember(Value = "unrecognized")]
            Unrecognized = 0,

            [EnumMember(Value = "pending")]
            Pending = 1,

            [EnumMember(Value = "failed")]
            Failed = 2,

            [EnumMember(Value = "authorized")]
            Authorized = 3
        }

        [DataMember(Name = "accepted_capabilities", IsRequired = true, EmitDefaultValue = false)]
        public List<ConnectWebview.AcceptedCapabilitiesEnum> AcceptedCapabilities { get; set; }

        [DataMember(Name = "accepted_devices", IsRequired = true, EmitDefaultValue = false)]
        public List<string> AcceptedDevices { get; set; }

        [DataMember(Name = "accepted_providers", IsRequired = true, EmitDefaultValue = false)]
        public List<string> AcceptedProviders { get; set; }

        [DataMember(Name = "any_device_allowed", IsRequired = true, EmitDefaultValue = false)]
        public bool AnyDeviceAllowed { get; set; }

        [DataMember(Name = "any_provider_allowed", IsRequired = true, EmitDefaultValue = false)]
        public bool AnyProviderAllowed { get; set; }

        [DataMember(Name = "authorized_at", IsRequired = false, EmitDefaultValue = false)]
        public string? AuthorizedAt { get; set; }

        [DataMember(
            Name = "automatically_manage_new_devices",
            IsRequired = true,
            EmitDefaultValue = false
        )]
        public bool AutomaticallyManageNewDevices { get; set; }

        [DataMember(Name = "connect_webview_id", IsRequired = true, EmitDefaultValue = false)]
        public string ConnectWebviewId { get; set; }

        [DataMember(Name = "connected_account_id", IsRequired = false, EmitDefaultValue = false)]
        public string? ConnectedAccountId { get; set; }

        [DataMember(Name = "created_at", IsRequired = true, EmitDefaultValue = false)]
        public string CreatedAt { get; set; }

        [DataMember(Name = "custom_metadata", IsRequired = true, EmitDefaultValue = false)]
        public object? CustomMetadata { get; set; }

        [DataMember(
            Name = "custom_redirect_failure_url",
            IsRequired = false,
            EmitDefaultValue = false
        )]
        public string? CustomRedirectFailureUrl { get; set; }

        [DataMember(Name = "custom_redirect_url", IsRequired = false, EmitDefaultValue = false)]
        public string? CustomRedirectUrl { get; set; }

        [DataMember(Name = "customer_key", IsRequired = false, EmitDefaultValue = false)]
        public string? CustomerKey { get; set; }

        [DataMember(Name = "device_selection_mode", IsRequired = true, EmitDefaultValue = false)]
        public ConnectWebview.DeviceSelectionModeEnum DeviceSelectionMode { get; set; }

        [DataMember(Name = "login_successful", IsRequired = true, EmitDefaultValue = false)]
        public bool LoginSuccessful { get; set; }

        [DataMember(Name = "selected_provider", IsRequired = false, EmitDefaultValue = false)]
        public string? SelectedProvider { get; set; }

        [DataMember(Name = "status", IsRequired = true, EmitDefaultValue = false)]
        public ConnectWebview.StatusEnum Status { get; set; }

        [DataMember(Name = "url", IsRequired = true, EmitDefaultValue = false)]
        public string Url { get; set; }

        [DataMember(Name = "wait_for_device_creation", IsRequired = true, EmitDefaultValue = false)]
        public bool WaitForDeviceCreation { get; set; }

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
