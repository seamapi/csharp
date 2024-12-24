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

        [DataContract(Name = "createRequest_request")]
        public class CreateRequest
        {
            [JsonConstructorAttribute]
            protected CreateRequest() { }

            public CreateRequest(
                string? companyName = default,
                string? connectPartnerName = default,
                bool? isSandbox = default,
                string name = default,
                CreateRequest.WebviewLogoShapeEnum? webviewLogoShape = default,
                string? webviewPrimaryButtonColor = default,
                string? webviewPrimaryButtonTextColor = default
            )
            {
                CompanyName = companyName;
                ConnectPartnerName = connectPartnerName;
                IsSandbox = isSandbox;
                Name = name;
                WebviewLogoShape = webviewLogoShape;
                WebviewPrimaryButtonColor = webviewPrimaryButtonColor;
                WebviewPrimaryButtonTextColor = webviewPrimaryButtonTextColor;
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

            [DataMember(Name = "company_name", IsRequired = false, EmitDefaultValue = false)]
            public string? CompanyName { get; set; }

            [DataMember(
                Name = "connect_partner_name",
                IsRequired = false,
                EmitDefaultValue = false
            )]
            public string? ConnectPartnerName { get; set; }

            [DataMember(Name = "is_sandbox", IsRequired = false, EmitDefaultValue = false)]
            public bool? IsSandbox { get; set; }

            [DataMember(Name = "name", IsRequired = true, EmitDefaultValue = false)]
            public string Name { get; set; }

            [DataMember(Name = "webview_logo_shape", IsRequired = false, EmitDefaultValue = false)]
            public CreateRequest.WebviewLogoShapeEnum? WebviewLogoShape { get; set; }

            [DataMember(
                Name = "webview_primary_button_color",
                IsRequired = false,
                EmitDefaultValue = false
            )]
            public string? WebviewPrimaryButtonColor { get; set; }

            [DataMember(
                Name = "webview_primary_button_text_color",
                IsRequired = false,
                EmitDefaultValue = false
            )]
            public string? WebviewPrimaryButtonTextColor { get; set; }

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

        public Workspace Create(CreateRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            return _seam.Post<CreateResponse>("/workspaces/create", requestOptions).Data.Workspace;
        }

        public Workspace Create(
            string? companyName = default,
            string? connectPartnerName = default,
            bool? isSandbox = default,
            string name = default,
            CreateRequest.WebviewLogoShapeEnum? webviewLogoShape = default,
            string? webviewPrimaryButtonColor = default,
            string? webviewPrimaryButtonTextColor = default
        )
        {
            return Create(
                new CreateRequest(
                    companyName: companyName,
                    connectPartnerName: connectPartnerName,
                    isSandbox: isSandbox,
                    name: name,
                    webviewLogoShape: webviewLogoShape,
                    webviewPrimaryButtonColor: webviewPrimaryButtonColor,
                    webviewPrimaryButtonTextColor: webviewPrimaryButtonTextColor
                )
            );
        }

        public async Task<Workspace> CreateAsync(CreateRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            return (await _seam.PostAsync<CreateResponse>("/workspaces/create", requestOptions))
                .Data
                .Workspace;
        }

        public async Task<Workspace> CreateAsync(
            string? companyName = default,
            string? connectPartnerName = default,
            bool? isSandbox = default,
            string name = default,
            CreateRequest.WebviewLogoShapeEnum? webviewLogoShape = default,
            string? webviewPrimaryButtonColor = default,
            string? webviewPrimaryButtonTextColor = default
        )
        {
            return (
                await CreateAsync(
                    new CreateRequest(
                        companyName: companyName,
                        connectPartnerName: connectPartnerName,
                        isSandbox: isSandbox,
                        name: name,
                        webviewLogoShape: webviewLogoShape,
                        webviewPrimaryButtonColor: webviewPrimaryButtonColor,
                        webviewPrimaryButtonTextColor: webviewPrimaryButtonTextColor
                    )
                )
            );
        }

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

        public Workspace Get(GetRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            return _seam.Post<GetResponse>("/workspaces/get", requestOptions).Data.Workspace;
        }

        public Workspace Get()
        {
            return Get(new GetRequest());
        }

        public async Task<Workspace> GetAsync(GetRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            return (await _seam.PostAsync<GetResponse>("/workspaces/get", requestOptions))
                .Data
                .Workspace;
        }

        public async Task<Workspace> GetAsync()
        {
            return (await GetAsync(new GetRequest()));
        }

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

        public List<Workspace> List(ListRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            return _seam.Post<ListResponse>("/workspaces/list", requestOptions).Data.Workspaces;
        }

        public List<Workspace> List()
        {
            return List(new ListRequest());
        }

        public async Task<List<Workspace>> ListAsync(ListRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            return (await _seam.PostAsync<ListResponse>("/workspaces/list", requestOptions))
                .Data
                .Workspaces;
        }

        public async Task<List<Workspace>> ListAsync()
        {
            return (await ListAsync(new ListRequest()));
        }

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

        public ActionAttempt ResetSandbox(ResetSandboxRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            return _seam
                .Post<ResetSandboxResponse>("/workspaces/reset_sandbox", requestOptions)
                .Data.ActionAttempt;
        }

        public ActionAttempt ResetSandbox()
        {
            return ResetSandbox(new ResetSandboxRequest());
        }

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
                .Data
                .ActionAttempt;
        }

        public async Task<ActionAttempt> ResetSandboxAsync()
        {
            return (await ResetSandboxAsync(new ResetSandboxRequest()));
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
