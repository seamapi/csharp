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
                CreateRequest.DeviceSelectionModeEnum? deviceSelectionMode = default,
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
                DeviceSelectionMode = deviceSelectionMode;
                ProviderCategory = providerCategory;
                WaitForDeviceCreation = waitForDeviceCreation;
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
                AccessControl = 4,
            }

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

                [EnumMember(Value = "lockly")]
                Lockly = 16,

                [EnumMember(Value = "ttlock")]
                Ttlock = 17,

                [EnumMember(Value = "linear")]
                Linear = 18,

                [EnumMember(Value = "noiseaware")]
                Noiseaware = 19,

                [EnumMember(Value = "nuki")]
                Nuki = 20,

                [EnumMember(Value = "seam_relay_admin")]
                SeamRelayAdmin = 21,

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

                [EnumMember(Value = "hubitat")]
                Hubitat = 30,

                [EnumMember(Value = "four_suites")]
                FourSuites = 31,

                [EnumMember(Value = "dormakaba_oracode")]
                DormakabaOracode = 32,

                [EnumMember(Value = "pti")]
                Pti = 33,

                [EnumMember(Value = "wyze")]
                Wyze = 34,

                [EnumMember(Value = "seam_passport")]
                SeamPassport = 35,

                [EnumMember(Value = "visionline")]
                Visionline = 36,

                [EnumMember(Value = "assa_abloy_credential_service")]
                AssaAbloyCredentialService = 37,

                [EnumMember(Value = "tedee")]
                Tedee = 38,

                [EnumMember(Value = "honeywell_resideo")]
                HoneywellResideo = 39,

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

                [EnumMember(Value = "kwikset2")]
                Kwikset2 = 47,

                [EnumMember(Value = "keynest")]
                Keynest = 48,

                [EnumMember(Value = "dormakaba_ambiance")]
                DormakabaAmbiance = 49,

                [EnumMember(Value = "yale_access")]
                YaleAccess = 50,

                [EnumMember(Value = "hid_cm")]
                HidCm = 51,

                [EnumMember(Value = "google_nest")]
                GoogleNest = 52,
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
                Multiple = 3,
            }

            [JsonConverter(typeof(SafeStringEnumConverter))]
            public enum ProviderCategoryEnum
            {
                [EnumMember(Value = "unrecognized")]
                Unrecognized = 0,

                [EnumMember(Value = "stable")]
                Stable = 1,

                [EnumMember(Value = "consumer_smartlocks")]
                ConsumerSmartlocks = 2,

                [EnumMember(Value = "thermostats")]
                Thermostats = 3,

                [EnumMember(Value = "noise_sensors")]
                NoiseSensors = 4,

                [EnumMember(Value = "access_control_systems")]
                AccessControlSystems = 5,

                [EnumMember(Value = "internal_beta")]
                InternalBeta = 6,
            }

            [DataMember(
                Name = "accepted_capabilities",
                IsRequired = false,
                EmitDefaultValue = false
            )]
            public List<CreateRequest.AcceptedCapabilitiesEnum>? AcceptedCapabilities { get; set; }

            [DataMember(Name = "accepted_providers", IsRequired = false, EmitDefaultValue = false)]
            public List<CreateRequest.AcceptedProvidersEnum>? AcceptedProviders { get; set; }

            [DataMember(
                Name = "automatically_manage_new_devices",
                IsRequired = false,
                EmitDefaultValue = false
            )]
            public bool? AutomaticallyManageNewDevices { get; set; }

            [DataMember(Name = "custom_metadata", IsRequired = false, EmitDefaultValue = false)]
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

            [DataMember(
                Name = "device_selection_mode",
                IsRequired = false,
                EmitDefaultValue = false
            )]
            public CreateRequest.DeviceSelectionModeEnum? DeviceSelectionMode { get; set; }

            [DataMember(Name = "provider_category", IsRequired = false, EmitDefaultValue = false)]
            public CreateRequest.ProviderCategoryEnum? ProviderCategory { get; set; }

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

        public ConnectWebview Create(CreateRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            return _seam
                .Post<CreateResponse>("/connect_webviews/create", requestOptions)
                .Data.ConnectWebview;
        }

        public ConnectWebview Create(
            List<CreateRequest.AcceptedCapabilitiesEnum>? acceptedCapabilities = default,
            List<CreateRequest.AcceptedProvidersEnum>? acceptedProviders = default,
            bool? automaticallyManageNewDevices = default,
            object? customMetadata = default,
            string? customRedirectFailureUrl = default,
            string? customRedirectUrl = default,
            string? customerKey = default,
            CreateRequest.DeviceSelectionModeEnum? deviceSelectionMode = default,
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
                    deviceSelectionMode: deviceSelectionMode,
                    providerCategory: providerCategory,
                    waitForDeviceCreation: waitForDeviceCreation
                )
            );
        }

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

        public async Task<ConnectWebview> CreateAsync(
            List<CreateRequest.AcceptedCapabilitiesEnum>? acceptedCapabilities = default,
            List<CreateRequest.AcceptedProvidersEnum>? acceptedProviders = default,
            bool? automaticallyManageNewDevices = default,
            object? customMetadata = default,
            string? customRedirectFailureUrl = default,
            string? customRedirectUrl = default,
            string? customerKey = default,
            CreateRequest.DeviceSelectionModeEnum? deviceSelectionMode = default,
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
                        deviceSelectionMode: deviceSelectionMode,
                        providerCategory: providerCategory,
                        waitForDeviceCreation: waitForDeviceCreation
                    )
                )
            );
        }

        [DataContract(Name = "deleteRequest_request")]
        public class DeleteRequest
        {
            [JsonConstructorAttribute]
            protected DeleteRequest() { }

            public DeleteRequest(string connectWebviewId = default)
            {
                ConnectWebviewId = connectWebviewId;
            }

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

        public void Delete(DeleteRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            _seam.Post<object>("/connect_webviews/delete", requestOptions);
        }

        public void Delete(string connectWebviewId = default)
        {
            Delete(new DeleteRequest(connectWebviewId: connectWebviewId));
        }

        public async Task DeleteAsync(DeleteRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            await _seam.PostAsync<object>("/connect_webviews/delete", requestOptions);
        }

        public async Task DeleteAsync(string connectWebviewId = default)
        {
            await DeleteAsync(new DeleteRequest(connectWebviewId: connectWebviewId));
        }

        [DataContract(Name = "getRequest_request")]
        public class GetRequest
        {
            [JsonConstructorAttribute]
            protected GetRequest() { }

            public GetRequest(string connectWebviewId = default)
            {
                ConnectWebviewId = connectWebviewId;
            }

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

        public ConnectWebview Get(GetRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            return _seam
                .Post<GetResponse>("/connect_webviews/get", requestOptions)
                .Data.ConnectWebview;
        }

        public ConnectWebview Get(string connectWebviewId = default)
        {
            return Get(new GetRequest(connectWebviewId: connectWebviewId));
        }

        public async Task<ConnectWebview> GetAsync(GetRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            return (await _seam.PostAsync<GetResponse>("/connect_webviews/get", requestOptions))
                .Data
                .ConnectWebview;
        }

        public async Task<ConnectWebview> GetAsync(string connectWebviewId = default)
        {
            return (await GetAsync(new GetRequest(connectWebviewId: connectWebviewId)));
        }

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
                string? userIdentifierKey = default
            )
            {
                CustomMetadataHas = customMetadataHas;
                CustomerKey = customerKey;
                Limit = limit;
                PageCursor = pageCursor;
                UserIdentifierKey = userIdentifierKey;
            }

            [DataMember(Name = "custom_metadata_has", IsRequired = false, EmitDefaultValue = false)]
            public object? CustomMetadataHas { get; set; }

            [DataMember(Name = "customer_key", IsRequired = false, EmitDefaultValue = false)]
            public string? CustomerKey { get; set; }

            [DataMember(Name = "limit", IsRequired = false, EmitDefaultValue = false)]
            public float? Limit { get; set; }

            [DataMember(Name = "page_cursor", IsRequired = false, EmitDefaultValue = false)]
            public string? PageCursor { get; set; }

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

        public List<ConnectWebview> List(ListRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            return _seam
                .Post<ListResponse>("/connect_webviews/list", requestOptions)
                .Data.ConnectWebviews;
        }

        public List<ConnectWebview> List(
            object? customMetadataHas = default,
            string? customerKey = default,
            float? limit = default,
            string? pageCursor = default,
            string? userIdentifierKey = default
        )
        {
            return List(
                new ListRequest(
                    customMetadataHas: customMetadataHas,
                    customerKey: customerKey,
                    limit: limit,
                    pageCursor: pageCursor,
                    userIdentifierKey: userIdentifierKey
                )
            );
        }

        public async Task<List<ConnectWebview>> ListAsync(ListRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            return (await _seam.PostAsync<ListResponse>("/connect_webviews/list", requestOptions))
                .Data
                .ConnectWebviews;
        }

        public async Task<List<ConnectWebview>> ListAsync(
            object? customMetadataHas = default,
            string? customerKey = default,
            float? limit = default,
            string? pageCursor = default,
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
