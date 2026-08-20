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
    public class Workspaces
    {
        private ISeamClient _seam;

        public Workspaces(ISeamClient seam)
        {
            _seam = seam;
        }

        /// <summary>
        /// Request parameters for Create a Workspace.
        /// </summary>
        [DataContract(Name = "createRequest_request")]
        public class CreateRequest
        {
            [JsonConstructorAttribute]
            protected CreateRequest() { }

            public CreateRequest(
                string? companyName = default,
                string? connectPartnerName = default,
                CreateRequestConnectWebviewCustomization? connectWebviewCustomization = default,
                bool? isSandbox = default,
                string name = default,
                string? organizationId = default,
                CreateRequest.WebviewLogoShapeEnum? webviewLogoShape = default,
                string? webviewPrimaryButtonColor = default,
                string? webviewPrimaryButtonTextColor = default,
                string? webviewSuccessMessage = default
            )
            {
                CompanyName = companyName;
                ConnectPartnerName = connectPartnerName;
                ConnectWebviewCustomization = connectWebviewCustomization;
                IsSandbox = isSandbox;
                Name = name;
                OrganizationId = organizationId;
                WebviewLogoShape = webviewLogoShape;
                WebviewPrimaryButtonColor = webviewPrimaryButtonColor;
                WebviewPrimaryButtonTextColor = webviewPrimaryButtonTextColor;
                WebviewSuccessMessage = webviewSuccessMessage;
            }

            [JsonConverter(typeof(SafeStringEnumConverter))]
            public enum WebviewLogoShapeEnum
            {
                [EnumMember(Value = "unrecognized")]
                Unrecognized = 0,

                [EnumMember(Value = "circle")]
                Circle = 1,

                [EnumMember(Value = "square")]
                Square = 2,
            }

            /// <summary>
            /// Company name for the new workspace.
            /// </summary>
            [Obsolete("Use `connect_partner_name` instead.")]
            [DataMember(Name = "company_name", IsRequired = false, EmitDefaultValue = false)]
            public string? CompanyName { get; set; }

            /// <summary>
            /// Connect partner name for the new workspace.
            /// </summary>
            [DataMember(
                Name = "connect_partner_name",
                IsRequired = false,
                EmitDefaultValue = false
            )]
            public string? ConnectPartnerName { get; set; }

            /// <summary>
            /// [Connect Webview](https://docs.seam.co/core-concepts/connect-webviews) customizations for the new workspace. See also [Customize the Look and Feel of Your Connect Webviews](https://docs.seam.co/core-concepts/connect-webviews/customizing-connect-webviews#customize-the-look-and-feel-of-your-connect-webviews).
            /// </summary>
            [DataMember(
                Name = "connect_webview_customization",
                IsRequired = false,
                EmitDefaultValue = false
            )]
            public CreateRequestConnectWebviewCustomization? ConnectWebviewCustomization { get; set; }

            /// <summary>
            /// Indicates whether the new workspace is a [sandbox workspace](https://docs.seam.co/core-concepts/workspaces#sandbox-workspaces).
            /// </summary>
            [DataMember(Name = "is_sandbox", IsRequired = false, EmitDefaultValue = false)]
            public bool? IsSandbox { get; set; }

            /// <summary>
            /// Name of the new workspace.
            /// </summary>
            [DataMember(Name = "name", IsRequired = true, EmitDefaultValue = false)]
            public string Name { get; set; }

            /// <summary>
            /// ID of the organization to associate with the new workspace.
            /// </summary>
            [DataMember(Name = "organization_id", IsRequired = false, EmitDefaultValue = false)]
            public string? OrganizationId { get; set; }

            [Obsolete("Use `connect_webview_customization.webview_logo_shape` instead.")]
            [DataMember(Name = "webview_logo_shape", IsRequired = false, EmitDefaultValue = false)]
            public CreateRequest.WebviewLogoShapeEnum? WebviewLogoShape { get; set; }

            [Obsolete("Use `connect_webview_customization.webview_primary_button_color` instead.")]
            [DataMember(
                Name = "webview_primary_button_color",
                IsRequired = false,
                EmitDefaultValue = false
            )]
            public string? WebviewPrimaryButtonColor { get; set; }

            [Obsolete(
                "Use `connect_webview_customization.webview_primary_button_text_color` instead."
            )]
            [DataMember(
                Name = "webview_primary_button_text_color",
                IsRequired = false,
                EmitDefaultValue = false
            )]
            public string? WebviewPrimaryButtonTextColor { get; set; }

            [Obsolete("Use `connect_webview_customization.webview_success_message` instead.")]
            [DataMember(
                Name = "webview_success_message",
                IsRequired = false,
                EmitDefaultValue = false
            )]
            public string? WebviewSuccessMessage { get; set; }

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

        [DataContract(Name = "createRequestConnectWebviewCustomization_model")]
        public class CreateRequestConnectWebviewCustomization
        {
            [JsonConstructorAttribute]
            protected CreateRequestConnectWebviewCustomization() { }

            public CreateRequestConnectWebviewCustomization(
                CreateRequestConnectWebviewCustomization.LogoShapeEnum? logoShape = default,
                string? primaryButtonColor = default,
                string? primaryButtonTextColor = default,
                string? successMessage = default
            )
            {
                LogoShape = logoShape;
                PrimaryButtonColor = primaryButtonColor;
                PrimaryButtonTextColor = primaryButtonTextColor;
                SuccessMessage = successMessage;
            }

            /// <summary>
            /// Logo shape for [Connect Webviews](https://docs.seam.co/core-concepts/connect-webviews) in the new workspace. See also [Customize the Look and Feel of Your Connect Webviews](https://docs.seam.co/core-concepts/connect-webviews/customizing-connect-webviews#customize-the-look-and-feel-of-your-connect-webviews).
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
            /// Logo shape for [Connect Webviews](https://docs.seam.co/core-concepts/connect-webviews) in the new workspace. See also [Customize the Look and Feel of Your Connect Webviews](https://docs.seam.co/core-concepts/connect-webviews/customizing-connect-webviews#customize-the-look-and-feel-of-your-connect-webviews).
            /// </summary>
            [DataMember(Name = "logo_shape", IsRequired = false, EmitDefaultValue = false)]
            public CreateRequestConnectWebviewCustomization.LogoShapeEnum? LogoShape { get; set; }

            /// <summary>
            /// Primary button color for [Connect Webviews](https://docs.seam.co/core-concepts/connect-webviews) in the new workspace. See also [Customize the Look and Feel of Your Connect Webviews](https://docs.seam.co/core-concepts/connect-webviews/customizing-connect-webviews#customize-the-look-and-feel-of-your-connect-webviews).
            /// </summary>
            [DataMember(
                Name = "primary_button_color",
                IsRequired = false,
                EmitDefaultValue = false
            )]
            public string? PrimaryButtonColor { get; set; }

            /// <summary>
            /// Primary button text color for [Connect Webviews](https://docs.seam.co/core-concepts/connect-webviews) in the new workspace. See also [Customize the Look and Feel of Your Connect Webviews](https://docs.seam.co/core-concepts/connect-webviews/customizing-connect-webviews#customize-the-look-and-feel-of-your-connect-webviews).
            /// </summary>
            [DataMember(
                Name = "primary_button_text_color",
                IsRequired = false,
                EmitDefaultValue = false
            )]
            public string? PrimaryButtonTextColor { get; set; }

            /// <summary>
            /// Success message for [Connect Webviews](https://docs.seam.co/core-concepts/connect-webviews) in the new workspace. See also [Customize the Look and Feel of Your Connect Webviews](https://docs.seam.co/core-concepts/connect-webviews/customizing-connect-webviews#customize-the-look-and-feel-of-your-connect-webviews).
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

        [DataContract(Name = "createResponse_response")]
        public class CreateResponse
        {
            [JsonConstructorAttribute]
            protected CreateResponse() { }

            public CreateResponse(Workspace workspace = default)
            {
                Workspace = workspace;
            }

            /// <summary>
            /// OK
            /// </summary>
            [DataMember(Name = "workspace", IsRequired = false, EmitDefaultValue = false)]
            public Workspace Workspace { get; set; }

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
        /// Creates a new [workspace](https://docs.seam.co/core-concepts/workspaces).
        /// </summary>
        public Workspace Create(CreateRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            return _seam
                .Post<CreateResponse>("/workspaces/create", requestOptions)
                .EnsureData("/workspaces/create")
                .Workspace;
        }

        /// <summary>
        /// Creates a new [workspace](https://docs.seam.co/core-concepts/workspaces).
        /// </summary>
        public Workspace Create(
            string? companyName = default,
            string? connectPartnerName = default,
            CreateRequestConnectWebviewCustomization? connectWebviewCustomization = default,
            bool? isSandbox = default,
            string name = default,
            string? organizationId = default,
            CreateRequest.WebviewLogoShapeEnum? webviewLogoShape = default,
            string? webviewPrimaryButtonColor = default,
            string? webviewPrimaryButtonTextColor = default,
            string? webviewSuccessMessage = default
        )
        {
            return Create(
                new CreateRequest(
                    companyName: companyName,
                    connectPartnerName: connectPartnerName,
                    connectWebviewCustomization: connectWebviewCustomization,
                    isSandbox: isSandbox,
                    name: name,
                    organizationId: organizationId,
                    webviewLogoShape: webviewLogoShape,
                    webviewPrimaryButtonColor: webviewPrimaryButtonColor,
                    webviewPrimaryButtonTextColor: webviewPrimaryButtonTextColor,
                    webviewSuccessMessage: webviewSuccessMessage
                )
            );
        }

        /// <summary>
        /// Creates a new [workspace](https://docs.seam.co/core-concepts/workspaces).
        /// </summary>
        public async Task<Workspace> CreateAsync(CreateRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            return (await _seam.PostAsync<CreateResponse>("/workspaces/create", requestOptions))
                .EnsureData("/workspaces/create")
                .Workspace;
        }

        /// <summary>
        /// Creates a new [workspace](https://docs.seam.co/core-concepts/workspaces).
        /// </summary>
        public async Task<Workspace> CreateAsync(
            string? companyName = default,
            string? connectPartnerName = default,
            CreateRequestConnectWebviewCustomization? connectWebviewCustomization = default,
            bool? isSandbox = default,
            string name = default,
            string? organizationId = default,
            CreateRequest.WebviewLogoShapeEnum? webviewLogoShape = default,
            string? webviewPrimaryButtonColor = default,
            string? webviewPrimaryButtonTextColor = default,
            string? webviewSuccessMessage = default
        )
        {
            return (
                await CreateAsync(
                    new CreateRequest(
                        companyName: companyName,
                        connectPartnerName: connectPartnerName,
                        connectWebviewCustomization: connectWebviewCustomization,
                        isSandbox: isSandbox,
                        name: name,
                        organizationId: organizationId,
                        webviewLogoShape: webviewLogoShape,
                        webviewPrimaryButtonColor: webviewPrimaryButtonColor,
                        webviewPrimaryButtonTextColor: webviewPrimaryButtonTextColor,
                        webviewSuccessMessage: webviewSuccessMessage
                    )
                )
            );
        }

        /// <summary>
        /// Request parameters for Get a Workspace.
        /// </summary>
        [DataContract(Name = "getRequest_request")]
        public class GetRequest
        {
            [JsonConstructorAttribute]
            public GetRequest() { }

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

            public GetResponse(Workspace workspace = default)
            {
                Workspace = workspace;
            }

            /// <summary>
            /// OK
            /// </summary>
            [DataMember(Name = "workspace", IsRequired = false, EmitDefaultValue = false)]
            public Workspace Workspace { get; set; }

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
        /// Returns the [workspace](https://docs.seam.co/core-concepts/workspaces) associated with the authentication value.
        /// </summary>
        public Workspace Get(GetRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            return _seam
                .Get<GetResponse>("/workspaces/get", requestOptions)
                .EnsureData("/workspaces/get")
                .Workspace;
        }

        /// <summary>
        /// Returns the [workspace](https://docs.seam.co/core-concepts/workspaces) associated with the authentication value.
        /// </summary>
        public Workspace Get()
        {
            return Get(new GetRequest());
        }

        /// <summary>
        /// Returns the [workspace](https://docs.seam.co/core-concepts/workspaces) associated with the authentication value.
        /// </summary>
        public async Task<Workspace> GetAsync(GetRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            return (await _seam.GetAsync<GetResponse>("/workspaces/get", requestOptions))
                .EnsureData("/workspaces/get")
                .Workspace;
        }

        /// <summary>
        /// Returns the [workspace](https://docs.seam.co/core-concepts/workspaces) associated with the authentication value.
        /// </summary>
        public async Task<Workspace> GetAsync()
        {
            return (await GetAsync(new GetRequest()));
        }

        /// <summary>
        /// Request parameters for List Workspaces.
        /// </summary>
        [DataContract(Name = "listRequest_request")]
        public class ListRequest
        {
            [JsonConstructorAttribute]
            public ListRequest() { }

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

            public ListResponse(List<Workspace> workspaces = default)
            {
                Workspaces = workspaces;
            }

            /// <summary>
            /// OK
            /// </summary>
            [DataMember(Name = "workspaces", IsRequired = false, EmitDefaultValue = false)]
            public List<Workspace> Workspaces { get; set; }

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
        /// Returns a list of [workspaces](https://docs.seam.co/core-concepts/workspaces) associated with the authentication value.
        /// </summary>
        public List<Workspace> List(ListRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            return _seam
                .Get<ListResponse>("/workspaces/list", requestOptions)
                .EnsureData("/workspaces/list")
                .Workspaces;
        }

        /// <summary>
        /// Returns a list of [workspaces](https://docs.seam.co/core-concepts/workspaces) associated with the authentication value.
        /// </summary>
        public List<Workspace> List()
        {
            return List(new ListRequest());
        }

        /// <summary>
        /// Returns a list of [workspaces](https://docs.seam.co/core-concepts/workspaces) associated with the authentication value.
        /// </summary>
        public async Task<List<Workspace>> ListAsync(ListRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            return (await _seam.GetAsync<ListResponse>("/workspaces/list", requestOptions))
                .EnsureData("/workspaces/list")
                .Workspaces;
        }

        /// <summary>
        /// Returns a list of [workspaces](https://docs.seam.co/core-concepts/workspaces) associated with the authentication value.
        /// </summary>
        public async Task<List<Workspace>> ListAsync()
        {
            return (await ListAsync(new ListRequest()));
        }

        /// <summary>
        /// Request parameters for Reset a Sandbox Workspace.
        /// </summary>
        [DataContract(Name = "resetSandboxRequest_request")]
        public class ResetSandboxRequest
        {
            [JsonConstructorAttribute]
            public ResetSandboxRequest() { }

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

        [DataContract(Name = "resetSandboxResponse_response")]
        public class ResetSandboxResponse
        {
            [JsonConstructorAttribute]
            protected ResetSandboxResponse() { }

            public ResetSandboxResponse(ActionAttempt actionAttempt = default)
            {
                ActionAttempt = actionAttempt;
            }

            /// <summary>
            /// OK
            /// </summary>
            [DataMember(Name = "action_attempt", IsRequired = false, EmitDefaultValue = false)]
            public ActionAttempt ActionAttempt { get; set; }

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
        /// Resets the [sandbox workspace](https://docs.seam.co/core-concepts/workspaces#sandbox-workspaces) associated with the authentication value. Note that this endpoint is only available for sandbox workspaces.
        /// </summary>
        public ActionAttempt ResetSandbox(ResetSandboxRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            return _seam
                .Post<ResetSandboxResponse>("/workspaces/reset_sandbox", requestOptions)
                .EnsureData("/workspaces/reset_sandbox")
                .ActionAttempt;
        }

        /// <summary>
        /// Resets the [sandbox workspace](https://docs.seam.co/core-concepts/workspaces#sandbox-workspaces) associated with the authentication value. Note that this endpoint is only available for sandbox workspaces.
        /// </summary>
        public ActionAttempt ResetSandbox()
        {
            return ResetSandbox(new ResetSandboxRequest());
        }

        /// <summary>
        /// Resets the [sandbox workspace](https://docs.seam.co/core-concepts/workspaces#sandbox-workspaces) associated with the authentication value. Note that this endpoint is only available for sandbox workspaces.
        /// </summary>
        public async Task<ActionAttempt> ResetSandboxAsync(ResetSandboxRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            return (
                await _seam.PostAsync<ResetSandboxResponse>(
                    "/workspaces/reset_sandbox",
                    requestOptions
                )
            )
                .EnsureData("/workspaces/reset_sandbox")
                .ActionAttempt;
        }

        /// <summary>
        /// Resets the [sandbox workspace](https://docs.seam.co/core-concepts/workspaces#sandbox-workspaces) associated with the authentication value. Note that this endpoint is only available for sandbox workspaces.
        /// </summary>
        public async Task<ActionAttempt> ResetSandboxAsync()
        {
            return (await ResetSandboxAsync(new ResetSandboxRequest()));
        }

        /// <summary>
        /// Request parameters for Update a Workspace.
        /// </summary>
        [DataContract(Name = "updateRequest_request")]
        public class UpdateRequest
        {
            [JsonConstructorAttribute]
            protected UpdateRequest() { }

            public UpdateRequest(
                string? connectPartnerName = default,
                UpdateRequestConnectWebviewCustomization? connectWebviewCustomization = default,
                bool? isPublishableKeyAuthEnabled = default,
                bool? isSuspended = default,
                string? name = default,
                string? organizationId = default
            )
            {
                ConnectPartnerName = connectPartnerName;
                ConnectWebviewCustomization = connectWebviewCustomization;
                IsPublishableKeyAuthEnabled = isPublishableKeyAuthEnabled;
                IsSuspended = isSuspended;
                Name = name;
                OrganizationId = organizationId;
            }

            /// <summary>
            /// Connect partner name for the workspace.
            /// </summary>
            [DataMember(
                Name = "connect_partner_name",
                IsRequired = false,
                EmitDefaultValue = false
            )]
            public string? ConnectPartnerName { get; set; }

            /// <summary>
            /// [Connect Webview](https://docs.seam.co/core-concepts/connect-webviews) customizations for the workspace. See also [Customize the Look and Feel of Your Connect Webviews](https://docs.seam.co/core-concepts/connect-webviews/customizing-connect-webviews#customize-the-look-and-feel-of-your-connect-webviews).
            /// </summary>
            [DataMember(
                Name = "connect_webview_customization",
                IsRequired = false,
                EmitDefaultValue = false
            )]
            public UpdateRequestConnectWebviewCustomization? ConnectWebviewCustomization { get; set; }

            /// <summary>
            /// Indicates whether publishable key authentication is enabled for this workspace.
            /// </summary>
            [DataMember(
                Name = "is_publishable_key_auth_enabled",
                IsRequired = false,
                EmitDefaultValue = false
            )]
            public bool? IsPublishableKeyAuthEnabled { get; set; }

            /// <summary>
            /// Indicates whether the workspace is suspended.
            /// </summary>
            [DataMember(Name = "is_suspended", IsRequired = false, EmitDefaultValue = false)]
            public bool? IsSuspended { get; set; }

            /// <summary>
            /// Name of the workspace.
            /// </summary>
            [DataMember(Name = "name", IsRequired = false, EmitDefaultValue = false)]
            public string? Name { get; set; }

            /// <summary>
            /// ID of the organization to assign the workspace to. The authenticated user must be the owner of the workspace and an admin of the target organization.
            /// </summary>
            [DataMember(Name = "organization_id", IsRequired = false, EmitDefaultValue = false)]
            public string? OrganizationId { get; set; }

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

        [DataContract(Name = "updateRequestConnectWebviewCustomization_model")]
        public class UpdateRequestConnectWebviewCustomization
        {
            [JsonConstructorAttribute]
            protected UpdateRequestConnectWebviewCustomization() { }

            public UpdateRequestConnectWebviewCustomization(
                UpdateRequestConnectWebviewCustomization.LogoShapeEnum? logoShape = default,
                string? primaryButtonColor = default,
                string? primaryButtonTextColor = default,
                string? successMessage = default
            )
            {
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
            /// Logo shape for [Connect Webviews](https://docs.seam.co/core-concepts/connect-webviews) in the workspace. See also [Customize the Look and Feel of Your Connect Webviews](https://docs.seam.co/core-concepts/connect-webviews/customizing-connect-webviews#customize-the-look-and-feel-of-your-connect-webviews).
            /// </summary>
            [DataMember(Name = "logo_shape", IsRequired = false, EmitDefaultValue = false)]
            public UpdateRequestConnectWebviewCustomization.LogoShapeEnum? LogoShape { get; set; }

            /// <summary>
            /// Primary button color for [Connect Webviews](https://docs.seam.co/core-concepts/connect-webviews) in the workspace. See also [Customize the Look and Feel of Your Connect Webviews](https://docs.seam.co/core-concepts/connect-webviews/customizing-connect-webviews#customize-the-look-and-feel-of-your-connect-webviews).
            /// </summary>
            [DataMember(
                Name = "primary_button_color",
                IsRequired = false,
                EmitDefaultValue = false
            )]
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

        /// <summary>
        /// Updates the [workspace](https://docs.seam.co/core-concepts/workspaces) associated with the authentication value.
        /// </summary>
        public void Update(UpdateRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            _seam.Patch<object>("/workspaces/update", requestOptions);
        }

        /// <summary>
        /// Updates the [workspace](https://docs.seam.co/core-concepts/workspaces) associated with the authentication value.
        /// </summary>
        public void Update(
            string? connectPartnerName = default,
            UpdateRequestConnectWebviewCustomization? connectWebviewCustomization = default,
            bool? isPublishableKeyAuthEnabled = default,
            bool? isSuspended = default,
            string? name = default,
            string? organizationId = default
        )
        {
            Update(
                new UpdateRequest(
                    connectPartnerName: connectPartnerName,
                    connectWebviewCustomization: connectWebviewCustomization,
                    isPublishableKeyAuthEnabled: isPublishableKeyAuthEnabled,
                    isSuspended: isSuspended,
                    name: name,
                    organizationId: organizationId
                )
            );
        }

        /// <summary>
        /// Updates the [workspace](https://docs.seam.co/core-concepts/workspaces) associated with the authentication value.
        /// </summary>
        public async Task UpdateAsync(UpdateRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            await _seam.PatchAsync<object>("/workspaces/update", requestOptions);
        }

        /// <summary>
        /// Updates the [workspace](https://docs.seam.co/core-concepts/workspaces) associated with the authentication value.
        /// </summary>
        public async Task UpdateAsync(
            string? connectPartnerName = default,
            UpdateRequestConnectWebviewCustomization? connectWebviewCustomization = default,
            bool? isPublishableKeyAuthEnabled = default,
            bool? isSuspended = default,
            string? name = default,
            string? organizationId = default
        )
        {
            await UpdateAsync(
                new UpdateRequest(
                    connectPartnerName: connectPartnerName,
                    connectWebviewCustomization: connectWebviewCustomization,
                    isPublishableKeyAuthEnabled: isPublishableKeyAuthEnabled,
                    isSuspended: isSuspended,
                    name: name,
                    organizationId: organizationId
                )
            );
        }
    }
}

namespace Seam.Client
{
    public partial class SeamClient
    {
        public Api.Workspaces Workspaces => new(this);
    }

    public partial interface ISeamClient
    {
        public Api.Workspaces Workspaces { get; }
    }
}
