using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using JsonSubTypes;

namespace Seam.Model
{
    [DataContract(Name = "coSeamModel_connectWebview_model")]
    public class ConnectWebview
    {
        [JsonConstructorAttribute]
        protected ConnectWebview() { }

        public ConnectWebview(
            string connectWebviewId = default,
            string? connectedAccountId = default,
            string url = default,
            string workspaceId = default,
            ConnectWebview.DeviceSelectionModeEnum deviceSelectionMode = default,
            List<string> acceptedProviders = default,
            List<string> acceptedDevices = default,
            bool anyProviderAllowed = default,
            bool anyDeviceAllowed = default,
            string createdAt = default,
            bool loginSuccessful = default,
            ConnectWebview.StatusEnum status = default
        )
        {
            ConnectWebviewId = connectWebviewId;
            ConnectedAccountId = connectedAccountId;
            Url = url;
            WorkspaceId = workspaceId;
            DeviceSelectionMode = deviceSelectionMode;
            AcceptedProviders = acceptedProviders;
            AcceptedDevices = acceptedDevices;
            AnyProviderAllowed = anyProviderAllowed;
            AnyDeviceAllowed = anyDeviceAllowed;
            CreatedAt = createdAt;
            LoginSuccessful = loginSuccessful;
            Status = status;
        }

        [JsonConverter(typeof(StringEnumConverter))]
        public enum DeviceSelectionModeEnum
        {
            [EnumMember(Value = "none")]
            None = 0,

            [EnumMember(Value = "single")]
            Single = 1,

            [EnumMember(Value = "multiple")]
            Multiple = 2
        }

        [JsonConverter(typeof(StringEnumConverter))]
        public enum StatusEnum
        {
            [EnumMember(Value = "pending")]
            Pending = 0,

            [EnumMember(Value = "failed")]
            Failed = 1,

            [EnumMember(Value = "authorized")]
            Authorized = 2
        }

        [DataMember(Name = "connect_webview_id", IsRequired = true, EmitDefaultValue = false)]
        public string ConnectWebviewId { get; set; }

        [DataMember(Name = "connected_account_id", IsRequired = false, EmitDefaultValue = false)]
        public string? ConnectedAccountId { get; set; }

        [DataMember(Name = "url", IsRequired = true, EmitDefaultValue = false)]
        public string Url { get; set; }

        [DataMember(Name = "workspace_id", IsRequired = true, EmitDefaultValue = false)]
        public string WorkspaceId { get; set; }

        [DataMember(Name = "device_selection_mode", IsRequired = true, EmitDefaultValue = false)]
        public ConnectWebview.DeviceSelectionModeEnum DeviceSelectionMode { get; set; }

        [DataMember(Name = "accepted_providers", IsRequired = true, EmitDefaultValue = false)]
        public List<string> AcceptedProviders { get; set; }

        [DataMember(Name = "accepted_devices", IsRequired = true, EmitDefaultValue = false)]
        public List<string> AcceptedDevices { get; set; }

        [DataMember(Name = "any_provider_allowed", IsRequired = true, EmitDefaultValue = false)]
        public bool AnyProviderAllowed { get; set; }

        [DataMember(Name = "any_device_allowed", IsRequired = true, EmitDefaultValue = false)]
        public bool AnyDeviceAllowed { get; set; }

        [DataMember(Name = "created_at", IsRequired = true, EmitDefaultValue = false)]
        public string CreatedAt { get; set; }

        [DataMember(Name = "login_successful", IsRequired = true, EmitDefaultValue = false)]
        public bool LoginSuccessful { get; set; }

        [DataMember(Name = "status", IsRequired = true, EmitDefaultValue = false)]
        public ConnectWebview.StatusEnum Status { get; set; }
    }
}
