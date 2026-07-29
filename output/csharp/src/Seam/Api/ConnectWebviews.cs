using System.Runtime.Serialization;
using System.Text;
using JsonSubTypes;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using Seam.Client;
using Seam.Model;

namespace Seam.Api
{
    public class ConnectWebviews
    {
        private ISeamClient _seam;

        public ConnectWebviews(ISeamClient seam)
        {
            _seam = seam;
        }

        /// <summary>
        /// Request parameters for Create a Connect Webview.
        /// </summary>
        [DataContract(Name = "createRequest_request")]
        public class CreateRequest
        {
            [JsonConstructorAttribute]
            protected CreateRequest() { }

            public CreateRequest(
                List<CreateRequest.AcceptedCapabilitiesEnum>? acceptedCapabilities = default,
                List<CreateRequest.AcceptedProvidersEnum>? acceptedProviders = default,
                bool? automaticallyManageNewDevices = default,
                object? customMetadata = default,
                string? customRedirectFailureUrl = default,
                string? customRedirectUrl = default,
                string? customerKey = default,
                List<string>? excludedProviders = default,
                CreateRequest.ProviderCategoryEnum? providerCategory = default,
                bool? waitForDeviceCreation = default
            )
            {
                AcceptedCapabilities = acceptedCapabilities;
                AcceptedProviders = acceptedProviders;
                AutomaticallyManageNewDevices = automaticallyManageNewDevices;
                CustomMetadata = customMetadata;
                CustomRedirectFailureUrl = customRedirectFailureUrl;
                CustomRedirectUrl = customRedirectUrl;
                CustomerKey = customerKey;
                ExcludedProviders = excludedProviders;
                ProviderCategory = providerCategory;
                WaitForDeviceCreation = waitForDeviceCreation;
            }

            /// <summary>
            /// List of accepted device capabilities that restrict the types of devices that can be connected through the Connect Webview. If not provided, defaults will be determined based on the accepted providers.
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
            /// Accepted device provider keys as an alternative to `provider_category`. Use this parameter to specify accepted providers explicitly. See [Customize the Brands to Display in Your Connect Webviews](https://docs.seam.co/core-concepts/connect-webviews/customizing-connect-webviews#customize-the-brands-to-display-in-your-connect-webviews). To list all provider keys, use [`/devices/list_device_providers`](https://docs.seam.co/api/devices/list_device_providers) with no filters.
            /// </summary>
            [JsonConverter(typeof(SafeStringEnumConverter))]
            public enum AcceptedProvidersEnum
            {
                [EnumMember(Value = "unrecognized")]
                Unrecognized = 0,

                [EnumMember(Value = "hotek")]
                Hotek = 1,

                [EnumMember(Value = "dormakaba_community")]
                DormakabaCommunity = 2,

                [EnumMember(Value = "legic_connect")]
                LegicConnect = 3,

                [EnumMember(Value = "akuvox")]
                Akuvox = 4,

                [EnumMember(Value = "august")]
                August = 5,

                [EnumMember(Value = "avigilon_alta")]
                AvigilonAlta = 6,

                [EnumMember(Value = "brivo")]
                Brivo = 7,

                [EnumMember(Value = "butterflymx")]
                Butterflymx = 8,

                [EnumMember(Value = "schlage")]
                Schlage = 9,

                [EnumMember(Value = "smartthings")]
                Smartthings = 10,

                [EnumMember(Value = "yale")]
                Yale = 11,

                [EnumMember(Value = "genie")]
                Genie = 12,

                [EnumMember(Value = "doorking")]
                Doorking = 13,

                [EnumMember(Value = "salto")]
                Salto = 14,

                [EnumMember(Value = "salto_ks")]
                SaltoKs = 15,

                [EnumMember(Value = "salto_ks_accept")]
                SaltoKsAccept = 16,

                [EnumMember(Value = "lockly")]
                Lockly = 17,

                [EnumMember(Value = "ttlock")]
                Ttlock = 18,

                [EnumMember(Value = "linear")]
                Linear = 19,

                [EnumMember(Value = "noiseaware")]
                Noiseaware = 20,

                [EnumMember(Value = "nuki")]
                Nuki = 21,

                [EnumMember(Value = "igloo")]
                Igloo = 22,

                [EnumMember(Value = "kwikset")]
                Kwikset = 23,

                [EnumMember(Value = "minut")]
                Minut = 24,

                [EnumMember(Value = "my_2n")]
                My_2n = 25,

                [EnumMember(Value = "controlbyweb")]
                Controlbyweb = 26,

                [EnumMember(Value = "nest")]
                Nest = 27,

                [EnumMember(Value = "igloohome")]
                Igloohome = 28,

                [EnumMember(Value = "ecobee")]
                Ecobee = 29,

                [EnumMember(Value = "four_suites")]
                FourSuites = 30,

                [EnumMember(Value = "dormakaba_oracode")]
                DormakabaOracode = 31,

                [EnumMember(Value = "pti")]
                Pti = 32,

                [EnumMember(Value = "wyze")]
                Wyze = 33,

                [EnumMember(Value = "seam_passport")]
                SeamPassport = 34,

                [EnumMember(Value = "visionline")]
                Visionline = 35,

                [EnumMember(Value = "assa_abloy_credential_service")]
                AssaAbloyCredentialService = 36,

                [EnumMember(Value = "tedee")]
                Tedee = 37,

                [EnumMember(Value = "honeywell_resideo")]
                HoneywellResideo = 38,

                [EnumMember(Value = "first_alert")]
                FirstAlert = 39,

                [EnumMember(Value = "latch")]
                Latch = 40,

                [EnumMember(Value = "akiles")]
                Akiles = 41,

                [EnumMember(Value = "assa_abloy_vostio")]
                AssaAbloyVostio = 42,

                [EnumMember(Value = "assa_abloy_vostio_credential_service")]
                AssaAbloyVostioCredentialService = 43,

                [EnumMember(Value = "tado")]
                Tado = 44,

                [EnumMember(Value = "salto_space")]
                SaltoSpace = 45,

                [EnumMember(Value = "sensi")]
                Sensi = 46,

                [EnumMember(Value = "keynest")]
                Keynest = 47,

                [EnumMember(Value = "korelock")]
                Korelock = 48,

                [EnumMember(Value = "keyincode")]
                Keyincode = 49,

                [EnumMember(Value = "dormakaba_ambiance")]
                DormakabaAmbiance = 50,

                [EnumMember(Value = "ultraloq")]
                Ultraloq = 51,

                [EnumMember(Value = "dusaw")]
                Dusaw = 52,

                [EnumMember(Value = "sifely")]
                Sifely = 53,

                [EnumMember(Value = "thirty_three_lock")]
                ThirtyThreeLock = 54,

                [EnumMember(Value = "ring")]
                Ring = 55,

                [EnumMember(Value = "ical")]
                Ical = 56,

                [EnumMember(Value = "lodgify")]
                Lodgify = 57,

                [EnumMember(Value = "hostaway")]
                Hostaway = 58,

                [EnumMember(Value = "guesty")]
                Guesty = 59,

                [EnumMember(Value = "acuity_scheduling")]
                AcuityScheduling = 60,

                [EnumMember(Value = "omnitec")]
                Omnitec = 61,

                [EnumMember(Value = "kisi")]
                Kisi = 62,

                [EnumMember(Value = "yale_access")]
                YaleAccess = 63,

                [EnumMember(Value = "hid_cm")]
                HidCm = 64,

                [EnumMember(Value = "google_nest")]
                GoogleNest = 65,

                [EnumMember(Value = "slack")]
                Slack = 66,
            }

            /// <summary>
            /// Specifies the category of providers that you want to include. To list all providers within a category, use [`/devices/list_device_providers`](https://docs.seam.co/api/devices/list_device_providers) with the desired `provider_category` filter.
            /// </summary>
            [JsonConverter(typeof(SafeStringEnumConverter))]
            public enum ProviderCategoryEnum
            {
                [EnumMember(Value = "unrecognized")]
                Unrecognized = 0,

                [EnumMember(Value = "stable")]
                Stable = 1,

                [EnumMember(Value = "consumer_smartlocks")]
                ConsumerSmartlocks = 2,

                [EnumMember(Value = "beta")]
                Beta = 3,

                [EnumMember(Value = "thermostats")]
                Thermostats = 4,

                [EnumMember(Value = "noise_sensors")]
                NoiseSensors = 5,

                [EnumMember(Value = "access_control_systems")]
                AccessControlSystems = 6,

                [EnumMember(Value = "cameras")]
                Cameras = 7,

                [EnumMember(Value = "connectors")]
                Connectors = 8,

                [EnumMember(Value = "internal_beta")]
                InternalBeta = 9,
            }

            /// <summary>
            /// List of accepted device capabilities that restrict the types of devices that can be connected through the Connect Webview. If not provided, defaults will be determined based on the accepted providers.
            /// </summary>
            [DataMember(
                Name = "accepted_capabilities",
                IsRequired = false,
                EmitDefaultValue = false
            )]
            public List<CreateRequest.AcceptedCapabilitiesEnum>? AcceptedCapabilities { get; set; }

            /// <summary>
            /// Accepted device provider keys as an alternative to `provider_category`. Use this parameter to specify accepted providers explicitly. See [Customize the Brands to Display in Your Connect Webviews](https://docs.seam.co/core-concepts/connect-webviews/customizing-connect-webviews#customize-the-brands-to-display-in-your-connect-webviews). To list all provider keys, use [`/devices/list_device_providers`](https://docs.seam.co/api/devices/list_device_providers) with no filters.
            /// </summary>
            [DataMember(Name = "accepted_providers", IsRequired = false, EmitDefaultValue = false)]
            public List<CreateRequest.AcceptedProvidersEnum>? AcceptedProviders { get; set; }

            /// <summary>
            /// Indicates whether newly-added devices should appear as [managed devices](https://docs.seam.co/core-concepts/devices/managed-and-unmanaged-devices). See also: [Customize the Behavior Settings of Your Connect Webviews](https://docs.seam.co/core-concepts/connect-webviews/customizing-connect-webviews#customize-the-behavior-settings-of-your-connect-webviews).
            /// </summary>
            [DataMember(
                Name = "automatically_manage_new_devices",
                IsRequired = false,
                EmitDefaultValue = false
            )]
            public bool? AutomaticallyManageNewDevices { get; set; }

            /// <summary>
            /// Custom metadata that you want to associate with the Connect Webview. Supports up to 50 JSON key:value pairs. [Adding custom metadata to a Connect Webview](https://docs.seam.co/core-concepts/connect-webviews/attaching-custom-data-to-the-connect-webview) enables you to store custom information, like customer details or internal IDs from your application. The custom metadata is then transferred to any [connected accounts](https://docs.seam.co/core-concepts/connected-accounts) that were connected using the Connect Webview, making it easy to find and filter these resources in your [workspace](https://docs.seam.co/core-concepts/workspaces). You can also [filter Connect Webviews by custom metadata](https://docs.seam.co/core-concepts/connect-webviews/filtering-connect-webviews-by-custom-metadata).
            /// </summary>
            [DataMember(Name = "custom_metadata", IsRequired = false, EmitDefaultValue = false)]
            public object? CustomMetadata { get; set; }

            /// <summary>
            /// Alternative URL that you want to redirect the user to on an error. If you do not set this parameter, the Connect Webview falls back to the `custom_redirect_url`.
            /// </summary>
            [DataMember(
                Name = "custom_redirect_failure_url",
                IsRequired = false,
                EmitDefaultValue = false
            )]
            public string? CustomRedirectFailureUrl { get; set; }

            /// <summary>
            /// URL that you want to redirect the user to after the provider login is complete.
            /// </summary>
            [DataMember(Name = "custom_redirect_url", IsRequired = false, EmitDefaultValue = false)]
            public string? CustomRedirectUrl { get; set; }

            /// <summary>
            /// Associate the Connect Webview, the connected account, and all resources under the connected account with a customer. If the connected account already exists, it will be associated with the customer. If the connected account already exists, but is already associated with a customer, the Connect Webview will show an error.
            /// </summary>
            [DataMember(Name = "customer_key", IsRequired = false, EmitDefaultValue = false)]
            public string? CustomerKey { get; set; }

            /// <summary>
            /// List of provider keys to exclude from the Connect Webview. These providers will not be shown when the user tries to connect an account.
            /// </summary>
            [DataMember(Name = "excluded_providers", IsRequired = false, EmitDefaultValue = false)]
            public List<string>? ExcludedProviders { get; set; }

            /// <summary>
            /// Specifies the category of providers that you want to include. To list all providers within a category, use [`/devices/list_device_providers`](https://docs.seam.co/api/devices/list_device_providers) with the desired `provider_category` filter.
            /// </summary>
            [DataMember(Name = "provider_category", IsRequired = false, EmitDefaultValue = false)]
            public CreateRequest.ProviderCategoryEnum? ProviderCategory { get; set; }

            /// <summary>
            /// Indicates whether Seam should finish syncing all devices in a newly-connected account before completing the associated Connect Webview. See also: [Customize the Behavior Settings of Your Connect Webviews](https://docs.seam.co/core-concepts/connect-webviews/customizing-connect-webviews#customize-the-behavior-settings-of-your-connect-webviews).
            /// </summary>
            [DataMember(
                Name = "wait_for_device_creation",
                IsRequired = false,
                EmitDefaultValue = false
            )]
            public bool? WaitForDeviceCreation { get; set; }

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

        [DataContract(Name = "createResponse_response")]
        public class CreateResponse
        {
            [JsonConstructorAttribute]
            protected CreateResponse() { }

            public CreateResponse(ConnectWebview connectWebview = default)
            {
                ConnectWebview = connectWebview;
            }

            /// <summary>
            /// OK
            /// </summary>
            [DataMember(Name = "connect_webview", IsRequired = false, EmitDefaultValue = false)]
            public ConnectWebview ConnectWebview { get; set; }

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

        /// <summary>
        /// Creates a new [Connect Webview](https://docs.seam.co/core-concepts/connect-webviews).
        ///
        /// To enable a user to connect their devices or systems to Seam, they must sign in to their device or system account. To enable a user to sign in, you create a `connect_webview`. After creating the Connect Webview, you receive a URL that you can use to display the visual component of this Connect Webview for your user. You can open an iframe or new window to display the Connect Webview.
        ///
        /// You should make a new `connect_webview` for each unique login request. Each `connect_webview` tracks the user that signed in with it. You receive an error if you reuse a Connect Webview for the same user twice or if you use the same Connect Webview for multiple users.
        ///
        /// See also: [Connect Webview Process](https://docs.seam.co/core-concepts/connect-webviews/connect-webview-process).
        /// </summary>
        public ConnectWebview Create(CreateRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            return _seam
                .Post<CreateResponse>("/connect_webviews/create", requestOptions)
                .Data.ConnectWebview;
        }

        /// <summary>
        /// Creates a new [Connect Webview](https://docs.seam.co/core-concepts/connect-webviews).
        ///
        /// To enable a user to connect their devices or systems to Seam, they must sign in to their device or system account. To enable a user to sign in, you create a `connect_webview`. After creating the Connect Webview, you receive a URL that you can use to display the visual component of this Connect Webview for your user. You can open an iframe or new window to display the Connect Webview.
        ///
        /// You should make a new `connect_webview` for each unique login request. Each `connect_webview` tracks the user that signed in with it. You receive an error if you reuse a Connect Webview for the same user twice or if you use the same Connect Webview for multiple users.
        ///
        /// See also: [Connect Webview Process](https://docs.seam.co/core-concepts/connect-webviews/connect-webview-process).
        /// </summary>
        public ConnectWebview Create(
            List<CreateRequest.AcceptedCapabilitiesEnum>? acceptedCapabilities = default,
            List<CreateRequest.AcceptedProvidersEnum>? acceptedProviders = default,
            bool? automaticallyManageNewDevices = default,
            object? customMetadata = default,
            string? customRedirectFailureUrl = default,
            string? customRedirectUrl = default,
            string? customerKey = default,
            List<string>? excludedProviders = default,
            CreateRequest.ProviderCategoryEnum? providerCategory = default,
            bool? waitForDeviceCreation = default
        )
        {
            return Create(
                new CreateRequest(
                    acceptedCapabilities: acceptedCapabilities,
                    acceptedProviders: acceptedProviders,
                    automaticallyManageNewDevices: automaticallyManageNewDevices,
                    customMetadata: customMetadata,
                    customRedirectFailureUrl: customRedirectFailureUrl,
                    customRedirectUrl: customRedirectUrl,
                    customerKey: customerKey,
                    excludedProviders: excludedProviders,
                    providerCategory: providerCategory,
                    waitForDeviceCreation: waitForDeviceCreation
                )
            );
        }

        /// <summary>
        /// Creates a new [Connect Webview](https://docs.seam.co/core-concepts/connect-webviews).
        ///
        /// To enable a user to connect their devices or systems to Seam, they must sign in to their device or system account. To enable a user to sign in, you create a `connect_webview`. After creating the Connect Webview, you receive a URL that you can use to display the visual component of this Connect Webview for your user. You can open an iframe or new window to display the Connect Webview.
        ///
        /// You should make a new `connect_webview` for each unique login request. Each `connect_webview` tracks the user that signed in with it. You receive an error if you reuse a Connect Webview for the same user twice or if you use the same Connect Webview for multiple users.
        ///
        /// See also: [Connect Webview Process](https://docs.seam.co/core-concepts/connect-webviews/connect-webview-process).
        /// </summary>
        public async Task<ConnectWebview> CreateAsync(CreateRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            return (
                await _seam.PostAsync<CreateResponse>("/connect_webviews/create", requestOptions)
            )
                .Data
                .ConnectWebview;
        }

        /// <summary>
        /// Creates a new [Connect Webview](https://docs.seam.co/core-concepts/connect-webviews).
        ///
        /// To enable a user to connect their devices or systems to Seam, they must sign in to their device or system account. To enable a user to sign in, you create a `connect_webview`. After creating the Connect Webview, you receive a URL that you can use to display the visual component of this Connect Webview for your user. You can open an iframe or new window to display the Connect Webview.
        ///
        /// You should make a new `connect_webview` for each unique login request. Each `connect_webview` tracks the user that signed in with it. You receive an error if you reuse a Connect Webview for the same user twice or if you use the same Connect Webview for multiple users.
        ///
        /// See also: [Connect Webview Process](https://docs.seam.co/core-concepts/connect-webviews/connect-webview-process).
        /// </summary>
        public async Task<ConnectWebview> CreateAsync(
            List<CreateRequest.AcceptedCapabilitiesEnum>? acceptedCapabilities = default,
            List<CreateRequest.AcceptedProvidersEnum>? acceptedProviders = default,
            bool? automaticallyManageNewDevices = default,
            object? customMetadata = default,
            string? customRedirectFailureUrl = default,
            string? customRedirectUrl = default,
            string? customerKey = default,
            List<string>? excludedProviders = default,
            CreateRequest.ProviderCategoryEnum? providerCategory = default,
            bool? waitForDeviceCreation = default
        )
        {
            return (
                await CreateAsync(
                    new CreateRequest(
                        acceptedCapabilities: acceptedCapabilities,
                        acceptedProviders: acceptedProviders,
                        automaticallyManageNewDevices: automaticallyManageNewDevices,
                        customMetadata: customMetadata,
                        customRedirectFailureUrl: customRedirectFailureUrl,
                        customRedirectUrl: customRedirectUrl,
                        customerKey: customerKey,
                        excludedProviders: excludedProviders,
                        providerCategory: providerCategory,
                        waitForDeviceCreation: waitForDeviceCreation
                    )
                )
            );
        }

        /// <summary>
        /// Request parameters for Delete a Connect Webview.
        /// </summary>
        [DataContract(Name = "deleteRequest_request")]
        public class DeleteRequest
        {
            [JsonConstructorAttribute]
            protected DeleteRequest() { }

            public DeleteRequest(string connectWebviewId = default)
            {
                ConnectWebviewId = connectWebviewId;
            }

            /// <summary>
            /// ID of the Connect Webview that you want to delete.
            /// </summary>
            [DataMember(Name = "connect_webview_id", IsRequired = true, EmitDefaultValue = false)]
            public string ConnectWebviewId { get; set; }

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

        /// <summary>
        /// Deletes a [Connect Webview](https://docs.seam.co/core-concepts/connect-webviews).
        ///
        /// You do not need to delete a Connect Webview once a user completes it. Instead, you can simply ignore completed Connect Webviews.
        /// </summary>
        public void Delete(DeleteRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            _seam.Post<object>("/connect_webviews/delete", requestOptions);
        }

        /// <summary>
        /// Deletes a [Connect Webview](https://docs.seam.co/core-concepts/connect-webviews).
        ///
        /// You do not need to delete a Connect Webview once a user completes it. Instead, you can simply ignore completed Connect Webviews.
        /// </summary>
        public void Delete(string connectWebviewId = default)
        {
            Delete(new DeleteRequest(connectWebviewId: connectWebviewId));
        }

        /// <summary>
        /// Deletes a [Connect Webview](https://docs.seam.co/core-concepts/connect-webviews).
        ///
        /// You do not need to delete a Connect Webview once a user completes it. Instead, you can simply ignore completed Connect Webviews.
        /// </summary>
        public async Task DeleteAsync(DeleteRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            await _seam.PostAsync<object>("/connect_webviews/delete", requestOptions);
        }

        /// <summary>
        /// Deletes a [Connect Webview](https://docs.seam.co/core-concepts/connect-webviews).
        ///
        /// You do not need to delete a Connect Webview once a user completes it. Instead, you can simply ignore completed Connect Webviews.
        /// </summary>
        public async Task DeleteAsync(string connectWebviewId = default)
        {
            await DeleteAsync(new DeleteRequest(connectWebviewId: connectWebviewId));
        }

        /// <summary>
        /// Request parameters for Get a Connect Webview.
        /// </summary>
        [DataContract(Name = "getRequest_request")]
        public class GetRequest
        {
            [JsonConstructorAttribute]
            protected GetRequest() { }

            public GetRequest(string connectWebviewId = default)
            {
                ConnectWebviewId = connectWebviewId;
            }

            /// <summary>
            /// ID of the Connect Webview that you want to get.
            /// </summary>
            [DataMember(Name = "connect_webview_id", IsRequired = true, EmitDefaultValue = false)]
            public string ConnectWebviewId { get; set; }

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

        [DataContract(Name = "getResponse_response")]
        public class GetResponse
        {
            [JsonConstructorAttribute]
            protected GetResponse() { }

            public GetResponse(ConnectWebview connectWebview = default)
            {
                ConnectWebview = connectWebview;
            }

            /// <summary>
            /// OK
            /// </summary>
            [DataMember(Name = "connect_webview", IsRequired = false, EmitDefaultValue = false)]
            public ConnectWebview ConnectWebview { get; set; }

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

        /// <summary>
        /// Returns a specified [Connect Webview](https://docs.seam.co/core-concepts/connect-webviews).
        ///
        /// Unless you&apos;re using a `custom_redirect_url`, you should poll a newly-created `connect_webview` to find out if the user has signed in or to get details about what devices they&apos;ve connected.
        /// </summary>
        public ConnectWebview Get(GetRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            return _seam
                .Post<GetResponse>("/connect_webviews/get", requestOptions)
                .Data.ConnectWebview;
        }

        /// <summary>
        /// Returns a specified [Connect Webview](https://docs.seam.co/core-concepts/connect-webviews).
        ///
        /// Unless you&apos;re using a `custom_redirect_url`, you should poll a newly-created `connect_webview` to find out if the user has signed in or to get details about what devices they&apos;ve connected.
        /// </summary>
        public ConnectWebview Get(string connectWebviewId = default)
        {
            return Get(new GetRequest(connectWebviewId: connectWebviewId));
        }

        /// <summary>
        /// Returns a specified [Connect Webview](https://docs.seam.co/core-concepts/connect-webviews).
        ///
        /// Unless you&apos;re using a `custom_redirect_url`, you should poll a newly-created `connect_webview` to find out if the user has signed in or to get details about what devices they&apos;ve connected.
        /// </summary>
        public async Task<ConnectWebview> GetAsync(GetRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            return (await _seam.PostAsync<GetResponse>("/connect_webviews/get", requestOptions))
                .Data
                .ConnectWebview;
        }

        /// <summary>
        /// Returns a specified [Connect Webview](https://docs.seam.co/core-concepts/connect-webviews).
        ///
        /// Unless you&apos;re using a `custom_redirect_url`, you should poll a newly-created `connect_webview` to find out if the user has signed in or to get details about what devices they&apos;ve connected.
        /// </summary>
        public async Task<ConnectWebview> GetAsync(string connectWebviewId = default)
        {
            return (await GetAsync(new GetRequest(connectWebviewId: connectWebviewId)));
        }

        /// <summary>
        /// Request parameters for List Connect Webviews.
        /// </summary>
        [DataContract(Name = "listRequest_request")]
        public class ListRequest
        {
            [JsonConstructorAttribute]
            protected ListRequest() { }

            public ListRequest(
                object? customMetadataHas = default,
                string? customerKey = default,
                float? limit = default,
                string? pageCursor = default,
                string? search = default,
                string? userIdentifierKey = default
            )
            {
                CustomMetadataHas = customMetadataHas;
                CustomerKey = customerKey;
                Limit = limit;
                PageCursor = pageCursor;
                Search = search;
                UserIdentifierKey = userIdentifierKey;
            }

            /// <summary>
            /// Custom metadata pairs by which you want to [filter Connect Webviews](https://docs.seam.co/core-concepts/connect-webviews/filtering-connect-webviews-by-custom-metadata). Returns Connect Webviews with `custom_metadata` that contains all of the provided key:value pairs.
            /// </summary>
            [DataMember(Name = "custom_metadata_has", IsRequired = false, EmitDefaultValue = false)]
            public object? CustomMetadataHas { get; set; }

            /// <summary>
            /// Customer key for which you want to list connect webviews.
            /// </summary>
            [DataMember(Name = "customer_key", IsRequired = false, EmitDefaultValue = false)]
            public string? CustomerKey { get; set; }

            /// <summary>
            /// Maximum number of records to return per page.
            /// </summary>
            [DataMember(Name = "limit", IsRequired = false, EmitDefaultValue = false)]
            public float? Limit { get; set; }

            /// <summary>
            /// Identifies the specific page of results to return, obtained from the previous page&apos;s `next_page_cursor`.
            /// </summary>
            [DataMember(Name = "page_cursor", IsRequired = false, EmitDefaultValue = false)]
            public string? PageCursor { get; set; }

            /// <summary>
            /// String for which to search. Filters returned Connect Webviews to include all records that satisfy a partial match using `connect_webview_id`, `accepted_providers`, `custom_metadata`, or `customer_key`.
            /// </summary>
            [DataMember(Name = "search", IsRequired = false, EmitDefaultValue = false)]
            public string? Search { get; set; }

            /// <summary>
            /// Your user ID for the user by which you want to filter Connect Webviews.
            /// </summary>
            [DataMember(Name = "user_identifier_key", IsRequired = false, EmitDefaultValue = false)]
            public string? UserIdentifierKey { get; set; }

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

        [DataContract(Name = "listResponse_response")]
        public class ListResponse
        {
            [JsonConstructorAttribute]
            protected ListResponse() { }

            public ListResponse(List<ConnectWebview> connectWebviews = default)
            {
                ConnectWebviews = connectWebviews;
            }

            /// <summary>
            /// OK
            /// </summary>
            [DataMember(Name = "connect_webviews", IsRequired = false, EmitDefaultValue = false)]
            public List<ConnectWebview> ConnectWebviews { get; set; }

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

        /// <summary>
        /// Returns a list of all [Connect Webviews](https://docs.seam.co/core-concepts/connect-webviews).
        /// </summary>
        public List<ConnectWebview> List(ListRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            return _seam
                .Post<ListResponse>("/connect_webviews/list", requestOptions)
                .Data.ConnectWebviews;
        }

        /// <summary>
        /// Returns a list of all [Connect Webviews](https://docs.seam.co/core-concepts/connect-webviews).
        /// </summary>
        public List<ConnectWebview> List(
            object? customMetadataHas = default,
            string? customerKey = default,
            float? limit = default,
            string? pageCursor = default,
            string? search = default,
            string? userIdentifierKey = default
        )
        {
            return List(
                new ListRequest(
                    customMetadataHas: customMetadataHas,
                    customerKey: customerKey,
                    limit: limit,
                    pageCursor: pageCursor,
                    search: search,
                    userIdentifierKey: userIdentifierKey
                )
            );
        }

        /// <summary>
        /// Returns a list of all [Connect Webviews](https://docs.seam.co/core-concepts/connect-webviews).
        /// </summary>
        public async Task<List<ConnectWebview>> ListAsync(ListRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            return (await _seam.PostAsync<ListResponse>("/connect_webviews/list", requestOptions))
                .Data
                .ConnectWebviews;
        }

        /// <summary>
        /// Returns a list of all [Connect Webviews](https://docs.seam.co/core-concepts/connect-webviews).
        /// </summary>
        public async Task<List<ConnectWebview>> ListAsync(
            object? customMetadataHas = default,
            string? customerKey = default,
            float? limit = default,
            string? pageCursor = default,
            string? search = default,
            string? userIdentifierKey = default
        )
        {
            return (
                await ListAsync(
                    new ListRequest(
                        customMetadataHas: customMetadataHas,
                        customerKey: customerKey,
                        limit: limit,
                        pageCursor: pageCursor,
                        search: search,
                        userIdentifierKey: userIdentifierKey
                    )
                )
            );
        }
    }
}

namespace Seam.Client
{
    public partial class SeamClient
    {
        public Api.ConnectWebviews ConnectWebviews => new(this);
    }

    public partial interface ISeamClient
    {
        public Api.ConnectWebviews ConnectWebviews { get; }
    }
}
