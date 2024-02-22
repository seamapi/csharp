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
        CreateRequest.DeviceSelectionModeEnum? deviceSelectionMode = default,
        string? customRedirectUrl = default,
        string? customRedirectFailureUrl = default,
        List<CreateRequest.AcceptedProvidersEnum>? acceptedProviders = default,
        CreateRequest.ProviderCategoryEnum? providerCategory = default,
        object? customMetadata = default,
        bool? automaticallyManageNewDevices = default,
        bool? waitForDeviceCreation = default
      )
      {
        DeviceSelectionMode = deviceSelectionMode;
        CustomRedirectUrl = customRedirectUrl;
        CustomRedirectFailureUrl = customRedirectFailureUrl;
        AcceptedProviders = acceptedProviders;
        ProviderCategory = providerCategory;
        CustomMetadata = customMetadata;
        AutomaticallyManageNewDevices = automaticallyManageNewDevices;
        WaitForDeviceCreation = waitForDeviceCreation;
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
      public enum AcceptedProvidersEnum
      {
        [EnumMember(Value = "akuvox")]
        Akuvox = 0,

        [EnumMember(Value = "august")]
        August = 1,

        [EnumMember(Value = "avigilon_alta")]
        AvigilonAlta = 2,

        [EnumMember(Value = "brivo")]
        Brivo = 3,

        [EnumMember(Value = "butterflymx")]
        Butterflymx = 4,

        [EnumMember(Value = "schlage")]
        Schlage = 5,

        [EnumMember(Value = "smartthings")]
        Smartthings = 6,

        [EnumMember(Value = "yale")]
        Yale = 7,

        [EnumMember(Value = "genie")]
        Genie = 8,

        [EnumMember(Value = "doorking")]
        Doorking = 9,

        [EnumMember(Value = "salto")]
        Salto = 10,

        [EnumMember(Value = "lockly")]
        Lockly = 11,

        [EnumMember(Value = "ttlock")]
        Ttlock = 12,

        [EnumMember(Value = "linear")]
        Linear = 13,

        [EnumMember(Value = "noiseaware")]
        Noiseaware = 14,

        [EnumMember(Value = "nuki")]
        Nuki = 15,

        [EnumMember(Value = "seam_relay_admin")]
        SeamRelayAdmin = 16,

        [EnumMember(Value = "igloo")]
        Igloo = 17,

        [EnumMember(Value = "kwikset")]
        Kwikset = 18,

        [EnumMember(Value = "minut")]
        Minut = 19,

        [EnumMember(Value = "my_2n")]
        My_2n = 20,

        [EnumMember(Value = "controlbyweb")]
        Controlbyweb = 21,

        [EnumMember(Value = "nest")]
        Nest = 22,

        [EnumMember(Value = "igloohome")]
        Igloohome = 23,

        [EnumMember(Value = "ecobee")]
        Ecobee = 24,

        [EnumMember(Value = "hubitat")]
        Hubitat = 25,

        [EnumMember(Value = "four_suites")]
        FourSuites = 26,

        [EnumMember(Value = "dormakaba_oracode")]
        DormakabaOracode = 27,

        [EnumMember(Value = "pti")]
        Pti = 28,

        [EnumMember(Value = "wyze")]
        Wyze = 29,

        [EnumMember(Value = "seam_passport")]
        SeamPassport = 30,

        [EnumMember(Value = "visionline")]
        Visionline = 31,

        [EnumMember(Value = "assa_abloy_credential_service")]
        AssaAbloyCredentialService = 32,

        [EnumMember(Value = "seam_bridge")]
        SeamBridge = 33,

        [EnumMember(Value = "tedee")]
        Tedee = 34,

        [EnumMember(Value = "honeywell")]
        Honeywell = 35,

        [EnumMember(Value = "yale_access")]
        YaleAccess = 36,

        [EnumMember(Value = "hid_cm")]
        HidCm = 37,

        [EnumMember(Value = "google_nest")]
        GoogleNest = 38
      }

      [JsonConverter(typeof(StringEnumConverter))]
      public enum ProviderCategoryEnum
      {
        [EnumMember(Value = "stable")]
        Stable = 0,

        [EnumMember(Value = "consumer_smartlocks")]
        ConsumerSmartlocks = 1,

        [EnumMember(Value = "internal_beta")]
        InternalBeta = 2
      }

      [DataMember(Name = "device_selection_mode", IsRequired = false, EmitDefaultValue = false)]
      public CreateRequest.DeviceSelectionModeEnum? DeviceSelectionMode { get; set; }

      [DataMember(Name = "custom_redirect_url", IsRequired = false, EmitDefaultValue = false)]
      public string? CustomRedirectUrl { get; set; }

      [DataMember(
        Name = "custom_redirect_failure_url",
        IsRequired = false,
        EmitDefaultValue = false
      )]
      public string? CustomRedirectFailureUrl { get; set; }

      [DataMember(Name = "accepted_providers", IsRequired = false, EmitDefaultValue = false)]
      public List<CreateRequest.AcceptedProvidersEnum>? AcceptedProviders { get; set; }

      [DataMember(Name = "provider_category", IsRequired = false, EmitDefaultValue = false)]
      public CreateRequest.ProviderCategoryEnum? ProviderCategory { get; set; }

      [DataMember(Name = "custom_metadata", IsRequired = false, EmitDefaultValue = false)]
      public object? CustomMetadata { get; set; }

      [DataMember(
        Name = "automatically_manage_new_devices",
        IsRequired = false,
        EmitDefaultValue = false
      )]
      public bool? AutomaticallyManageNewDevices { get; set; }

      [DataMember(Name = "wait_for_device_creation", IsRequired = false, EmitDefaultValue = false)]
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
      CreateRequest.DeviceSelectionModeEnum? deviceSelectionMode = default,
      string? customRedirectUrl = default,
      string? customRedirectFailureUrl = default,
      List<CreateRequest.AcceptedProvidersEnum>? acceptedProviders = default,
      CreateRequest.ProviderCategoryEnum? providerCategory = default,
      object? customMetadata = default,
      bool? automaticallyManageNewDevices = default,
      bool? waitForDeviceCreation = default
    )
    {
      return Create(
        new CreateRequest(
          deviceSelectionMode: deviceSelectionMode,
          customRedirectUrl: customRedirectUrl,
          customRedirectFailureUrl: customRedirectFailureUrl,
          acceptedProviders: acceptedProviders,
          providerCategory: providerCategory,
          customMetadata: customMetadata,
          automaticallyManageNewDevices: automaticallyManageNewDevices,
          waitForDeviceCreation: waitForDeviceCreation
        )
      );
    }

    public async Task<ConnectWebview> CreateAsync(CreateRequest request)
    {
      var requestOptions = new RequestOptions();
      requestOptions.Data = request;
      return (await _seam.PostAsync<CreateResponse>("/connect_webviews/create", requestOptions))
        .Data
        .ConnectWebview;
    }

    public async Task<ConnectWebview> CreateAsync(
      CreateRequest.DeviceSelectionModeEnum? deviceSelectionMode = default,
      string? customRedirectUrl = default,
      string? customRedirectFailureUrl = default,
      List<CreateRequest.AcceptedProvidersEnum>? acceptedProviders = default,
      CreateRequest.ProviderCategoryEnum? providerCategory = default,
      object? customMetadata = default,
      bool? automaticallyManageNewDevices = default,
      bool? waitForDeviceCreation = default
    )
    {
      return (
        await CreateAsync(
          new CreateRequest(
            deviceSelectionMode: deviceSelectionMode,
            customRedirectUrl: customRedirectUrl,
            customRedirectFailureUrl: customRedirectFailureUrl,
            acceptedProviders: acceptedProviders,
            providerCategory: providerCategory,
            customMetadata: customMetadata,
            automaticallyManageNewDevices: automaticallyManageNewDevices,
            waitForDeviceCreation: waitForDeviceCreation
          )
        )
      );
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
      return _seam.Post<GetResponse>("/connect_webviews/get", requestOptions).Data.ConnectWebview;
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

      public ListRequest(string? userIdentifierKey = default, object? customMetadataHas = default)
      {
        UserIdentifierKey = userIdentifierKey;
        CustomMetadataHas = customMetadataHas;
      }

      [DataMember(Name = "user_identifier_key", IsRequired = false, EmitDefaultValue = false)]
      public string? UserIdentifierKey { get; set; }

      [DataMember(Name = "custom_metadata_has", IsRequired = false, EmitDefaultValue = false)]
      public object? CustomMetadataHas { get; set; }

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
      string? userIdentifierKey = default,
      object? customMetadataHas = default
    )
    {
      return List(
        new ListRequest(userIdentifierKey: userIdentifierKey, customMetadataHas: customMetadataHas)
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
      string? userIdentifierKey = default,
      object? customMetadataHas = default
    )
    {
      return (
        await ListAsync(
          new ListRequest(
            userIdentifierKey: userIdentifierKey,
            customMetadataHas: customMetadataHas
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
