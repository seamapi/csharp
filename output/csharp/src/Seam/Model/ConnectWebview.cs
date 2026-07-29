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
    /// Represents a [Connect Webview](https://docs.seam.co/core-concepts/connect-webviews).
    ///
    /// Connect Webviews are fully-embedded client-side components that you add to your app. Your users interact with your embedded Connect Webviews to link their IoT device or system accounts to Seam. That is, Connect Webviews walk your users through the process of logging in to their device or system accounts. Seam handles all the authentication steps, and—once your user has completed the authorization through your app—you can access and control their devices or systems using the Seam API.
    ///
    /// Connect Webviews perform credential validation, multifactor authentication (when applicable), and error handling for each brand that Seam supports. Further, Connect Webviews work across all modern browsers and platforms, including Chrome, Safari, and Firefox.
    ///
    /// To enable a user to connect their device or system account to Seam through your app, first create a `connect_webview`. Once created, this `connect_webview` includes a URL that you can use to open an [iframe](https://www.w3schools.com/html/html_iframe.asp) or new window containing the Connect Webview for your user.
    ///
    /// When you create a Connect Webview, specify the desired provider category key in the `provider_category` parameter. Alternately, to specify a list of providers explicitly, use the `accepted_providers` parameter with a list of device provider keys.
    ///
    /// To list all providers within a category, use `/devices/list_device_providers` with the desired `provider_category` filter. To list all provider keys, use `/devices/list_device_providers` with no filters.
    /// </summary>
    [DataContract(Name = "seamModel_connectWebview_model")]
    public class ConnectWebview
    {
        [JsonConstructorAttribute]
        protected ConnectWebview() { }

        public ConnectWebview(
            List<ConnectWebview.AcceptedCapabilitiesEnum> acceptedCapabilities = default,
            List<string> acceptedProviders = default,
            bool anyProviderAllowed = default,
            string? authorizedAt = default,
            bool automaticallyManageNewDevices = default,
            string connectWebviewId = default,
            string? connectedAccountId = default,
            string createdAt = default,
            object customMetadata = default,
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
            AcceptedProviders = acceptedProviders;
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

        /// <summary>
        /// High-level device capabilities that the Connect Webview can accept. When creating a Connect Webview, you can specify the types of devices that it can connect to Seam. If you do not set custom `accepted_capabilities`, Seam uses a default set of `accepted_capabilities` for each provider. For example, if you create a Connect Webview that accepts SmartThing devices, without specifying `accepted_capabilities`, Seam accepts only SmartThings locks. To connect SmartThings thermostats and locks to Seam, create a Connect Webview and include both `thermostat` and `lock` in the `accepted_capabilities`.
        /// </summary>
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
            AccessControl = 4,

            [EnumMember(Value = "camera")]
            Camera = 5,
        }

        /// <summary>
        /// Device selection mode of the Connect Webview. Supported values: `none`, `single`, `multiple`.
        /// </summary>
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
            Multiple = 3,
        }

        /// <summary>
        /// Status of the Connect Webview. `authorized` indicates that the user has successfully logged into their device or system account, thereby completing the Connect Webview.
        /// </summary>
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
            Authorized = 3,
        }

        /// <summary>
        /// High-level device capabilities that the Connect Webview can accept. When creating a Connect Webview, you can specify the types of devices that it can connect to Seam. If you do not set custom `accepted_capabilities`, Seam uses a default set of `accepted_capabilities` for each provider. For example, if you create a Connect Webview that accepts SmartThing devices, without specifying `accepted_capabilities`, Seam accepts only SmartThings locks. To connect SmartThings thermostats and locks to Seam, create a Connect Webview and include both `thermostat` and `lock` in the `accepted_capabilities`.
        /// </summary>
        [DataMember(Name = "accepted_capabilities", IsRequired = false, EmitDefaultValue = false)]
        public List<ConnectWebview.AcceptedCapabilitiesEnum> AcceptedCapabilities { get; set; }

        /// <summary>
        /// List of accepted [provider keys](https://docs.seam.co/core-concepts/connect-webviews/customizing-connect-webviews#customize-the-brands-to-display-in-your-connect-webviews).
        /// </summary>
        [DataMember(Name = "accepted_providers", IsRequired = false, EmitDefaultValue = false)]
        public List<string> AcceptedProviders { get; set; }

        /// <summary>
        /// Indicates whether any provider is allowed.
        /// </summary>
        [DataMember(Name = "any_provider_allowed", IsRequired = false, EmitDefaultValue = false)]
        public bool AnyProviderAllowed { get; set; }

        /// <summary>
        /// Date and time at which the user authorized (through the Connect Webview) the management of their devices.
        /// </summary>
        [DataMember(Name = "authorized_at", IsRequired = false, EmitDefaultValue = false)]
        public string? AuthorizedAt { get; set; }

        /// <summary>
        /// Indicates whether Seam should [import all new devices](https://docs.seam.co/core-concepts/connect-webviews/customizing-connect-webviews#automatically_manage_new_devices) for the connected account to make these devices available for use and management by the Seam API.
        /// </summary>
        [DataMember(
            Name = "automatically_manage_new_devices",
            IsRequired = false,
            EmitDefaultValue = false
        )]
        public bool AutomaticallyManageNewDevices { get; set; }

        /// <summary>
        /// ID of the Connect Webview.
        /// </summary>
        [DataMember(Name = "connect_webview_id", IsRequired = false, EmitDefaultValue = false)]
        public string ConnectWebviewId { get; set; }

        /// <summary>
        /// ID of the connected account associated with the Connect Webview.
        /// </summary>
        [DataMember(Name = "connected_account_id", IsRequired = false, EmitDefaultValue = false)]
        public string? ConnectedAccountId { get; set; }

        /// <summary>
        /// Date and time at which the Connect Webview was created.
        /// </summary>
        [DataMember(Name = "created_at", IsRequired = false, EmitDefaultValue = false)]
        public string CreatedAt { get; set; }

        /// <summary>
        /// Set of key:value pairs. Adding custom metadata to a resource, such as a [Connect Webview](https://docs.seam.co/core-concepts/connect-webviews/attaching-custom-data-to-the-connect-webview), [connected account](https://docs.seam.co/core-concepts/connected-accounts/adding-custom-metadata-to-a-connected-account), or [device](https://docs.seam.co/core-concepts/devices/adding-custom-metadata-to-a-device), enables you to store custom information, like customer details or internal IDs from your application.
        /// </summary>
        [DataMember(Name = "custom_metadata", IsRequired = false, EmitDefaultValue = false)]
        public object CustomMetadata { get; set; }

        /// <summary>
        /// URL to which the Connect Webview should redirect when an unexpected error occurs.
        /// </summary>
        [DataMember(
            Name = "custom_redirect_failure_url",
            IsRequired = false,
            EmitDefaultValue = false
        )]
        public string? CustomRedirectFailureUrl { get; set; }

        /// <summary>
        /// URL to which the Connect Webview should redirect when the user successfully pairs a device or system. If you do not set the `custom_redirect_failure_url`, the Connect Webview redirects to the `custom_redirect_url` when an unexpected error occurs.
        /// </summary>
        [DataMember(Name = "custom_redirect_url", IsRequired = false, EmitDefaultValue = false)]
        public string? CustomRedirectUrl { get; set; }

        /// <summary>
        /// The customer key associated with this webview, if any.
        /// </summary>
        [DataMember(Name = "customer_key", IsRequired = false, EmitDefaultValue = false)]
        public string? CustomerKey { get; set; }

        /// <summary>
        /// Device selection mode of the Connect Webview. Supported values: `none`, `single`, `multiple`.
        /// </summary>
        [DataMember(Name = "device_selection_mode", IsRequired = false, EmitDefaultValue = false)]
        public ConnectWebview.DeviceSelectionModeEnum DeviceSelectionMode { get; set; }

        /// <summary>
        /// Indicates whether the user logged in successfully using the Connect Webview.
        /// </summary>
        [DataMember(Name = "login_successful", IsRequired = false, EmitDefaultValue = false)]
        public bool LoginSuccessful { get; set; }

        /// <summary>
        /// Selected provider of the Connect Webview, one of the [provider keys](https://docs.seam.co/core-concepts/connect-webviews/customizing-connect-webviews#customize-the-brands-to-display-in-your-connect-webviews).
        /// </summary>
        [DataMember(Name = "selected_provider", IsRequired = false, EmitDefaultValue = false)]
        public string? SelectedProvider { get; set; }

        /// <summary>
        /// Status of the Connect Webview. `authorized` indicates that the user has successfully logged into their device or system account, thereby completing the Connect Webview.
        /// </summary>
        [DataMember(Name = "status", IsRequired = false, EmitDefaultValue = false)]
        public ConnectWebview.StatusEnum Status { get; set; }

        /// <summary>
        /// URL for the Connect Webview. You use the URL to display the Connect Webview flow to your user.
        /// </summary>
        [DataMember(Name = "url", IsRequired = false, EmitDefaultValue = false)]
        public string Url { get; set; }

        /// <summary>
        /// Indicates whether Seam should [finish syncing all devices](https://docs.seam.co/core-concepts/connect-webviews/customizing-connect-webviews#wait_for_device_creation) in a newly-connected account before completing the associated Connect Webview.
        /// </summary>
        [DataMember(
            Name = "wait_for_device_creation",
            IsRequired = false,
            EmitDefaultValue = false
        )]
        public bool WaitForDeviceCreation { get; set; }

        /// <summary>
        /// ID of the workspace that contains the Connect Webview.
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
}
