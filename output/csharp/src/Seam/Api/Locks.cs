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
  public class Locks
  {
    private ISeamClient _seam;

    public Locks(ISeamClient seam)
    {
      _seam = seam;
    }

    [DataContract(Name = "getRequest_request")]
    public class GetRequest
    {
      [JsonConstructorAttribute]
      protected GetRequest() { }

      public GetRequest(string? deviceId = default, string? name = default)
      {
        DeviceId = deviceId;
        Name = name;
      }

      [DataMember(Name = "device_id", IsRequired = false, EmitDefaultValue = false)]
      public string? DeviceId { get; set; }

      [DataMember(Name = "name", IsRequired = false, EmitDefaultValue = false)]
      public string? Name { get; set; }

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

      public GetResponse(Device device = default)
      {
        Device = device;
      }

      [DataMember(Name = "device", IsRequired = false, EmitDefaultValue = false)]
      public Device Device { get; set; }

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

    public Device Get(GetRequest request)
    {
      var requestOptions = new RequestOptions();
      requestOptions.Data = request;
      return _seam.Post<GetResponse>("/locks/get", requestOptions).Data.Device;
    }

    public Device Get(string? deviceId = default, string? name = default)
    {
      return Get(new GetRequest(deviceId: deviceId, name: name));
    }

    public async Task<Device> GetAsync(GetRequest request)
    {
      var requestOptions = new RequestOptions();
      requestOptions.Data = request;
      return (await _seam.PostAsync<GetResponse>("/locks/get", requestOptions)).Data.Device;
    }

    public async Task<Device> GetAsync(string? deviceId = default, string? name = default)
    {
      return (await GetAsync(new GetRequest(deviceId: deviceId, name: name)));
    }

    [DataContract(Name = "listRequest_request")]
    public class ListRequest
    {
      [JsonConstructorAttribute]
      protected ListRequest() { }

      public ListRequest(
        string? connectedAccountId = default,
        List<string>? connectedAccountIds = default,
        string? connectWebviewId = default,
        ListRequest.DeviceTypeEnum? deviceType = default,
        List<ListRequest.DeviceTypesEnum>? deviceTypes = default,
        ListRequest.ManufacturerEnum? manufacturer = default,
        List<string>? deviceIds = default,
        float? limit = default,
        string? createdBefore = default,
        string? userIdentifierKey = default,
        object? customMetadataHas = default
      )
      {
        ConnectedAccountId = connectedAccountId;
        ConnectedAccountIds = connectedAccountIds;
        ConnectWebviewId = connectWebviewId;
        DeviceType = deviceType;
        DeviceTypes = deviceTypes;
        Manufacturer = manufacturer;
        DeviceIds = deviceIds;
        Limit = limit;
        CreatedBefore = createdBefore;
        UserIdentifierKey = userIdentifierKey;
        CustomMetadataHas = customMetadataHas;
      }

      [JsonConverter(typeof(StringEnumConverter))]
      public enum DeviceTypeEnum
      {
        [EnumMember(Value = "akuvox_lock")]
        AkuvoxLock = 0,

        [EnumMember(Value = "august_lock")]
        AugustLock = 1,

        [EnumMember(Value = "brivo_access_point")]
        BrivoAccessPoint = 2,

        [EnumMember(Value = "butterflymx_panel")]
        ButterflymxPanel = 3,

        [EnumMember(Value = "avigilon_alta_entry")]
        AvigilonAltaEntry = 4,

        [EnumMember(Value = "doorking_lock")]
        DoorkingLock = 5,

        [EnumMember(Value = "genie_door")]
        GenieDoor = 6,

        [EnumMember(Value = "igloo_lock")]
        IglooLock = 7,

        [EnumMember(Value = "linear_lock")]
        LinearLock = 8,

        [EnumMember(Value = "lockly_lock")]
        LocklyLock = 9,

        [EnumMember(Value = "kwikset_lock")]
        KwiksetLock = 10,

        [EnumMember(Value = "nuki_lock")]
        NukiLock = 11,

        [EnumMember(Value = "salto_lock")]
        SaltoLock = 12,

        [EnumMember(Value = "schlage_lock")]
        SchlageLock = 13,

        [EnumMember(Value = "seam_relay")]
        SeamRelay = 14,

        [EnumMember(Value = "smartthings_lock")]
        SmartthingsLock = 15,

        [EnumMember(Value = "wyze_lock")]
        WyzeLock = 16,

        [EnumMember(Value = "yale_lock")]
        YaleLock = 17,

        [EnumMember(Value = "two_n_intercom")]
        TwoNIntercom = 18,

        [EnumMember(Value = "controlbyweb_device")]
        ControlbywebDevice = 19,

        [EnumMember(Value = "ttlock_lock")]
        TtlockLock = 20,

        [EnumMember(Value = "igloohome_lock")]
        IgloohomeLock = 21,

        [EnumMember(Value = "hubitat_lock")]
        HubitatLock = 22,

        [EnumMember(Value = "four_suites_door")]
        FourSuitesDoor = 23,

        [EnumMember(Value = "dormakaba_oracode_door")]
        DormakabaOracodeDoor = 24,

        [EnumMember(Value = "tedee_lock")]
        TedeeLock = 25,

        [EnumMember(Value = "noiseaware_activity_zone")]
        NoiseawareActivityZone = 26,

        [EnumMember(Value = "minut_sensor")]
        MinutSensor = 27,

        [EnumMember(Value = "ecobee_thermostat")]
        EcobeeThermostat = 28,

        [EnumMember(Value = "nest_thermostat")]
        NestThermostat = 29,

        [EnumMember(Value = "honeywell_thermostat")]
        HoneywellThermostat = 30,

        [EnumMember(Value = "ios_phone")]
        IosPhone = 31,

        [EnumMember(Value = "android_phone")]
        AndroidPhone = 32
      }

      [JsonConverter(typeof(StringEnumConverter))]
      public enum DeviceTypesEnum
      {
        [EnumMember(Value = "akuvox_lock")]
        AkuvoxLock = 0,

        [EnumMember(Value = "august_lock")]
        AugustLock = 1,

        [EnumMember(Value = "brivo_access_point")]
        BrivoAccessPoint = 2,

        [EnumMember(Value = "butterflymx_panel")]
        ButterflymxPanel = 3,

        [EnumMember(Value = "avigilon_alta_entry")]
        AvigilonAltaEntry = 4,

        [EnumMember(Value = "doorking_lock")]
        DoorkingLock = 5,

        [EnumMember(Value = "genie_door")]
        GenieDoor = 6,

        [EnumMember(Value = "igloo_lock")]
        IglooLock = 7,

        [EnumMember(Value = "linear_lock")]
        LinearLock = 8,

        [EnumMember(Value = "lockly_lock")]
        LocklyLock = 9,

        [EnumMember(Value = "kwikset_lock")]
        KwiksetLock = 10,

        [EnumMember(Value = "nuki_lock")]
        NukiLock = 11,

        [EnumMember(Value = "salto_lock")]
        SaltoLock = 12,

        [EnumMember(Value = "schlage_lock")]
        SchlageLock = 13,

        [EnumMember(Value = "seam_relay")]
        SeamRelay = 14,

        [EnumMember(Value = "smartthings_lock")]
        SmartthingsLock = 15,

        [EnumMember(Value = "wyze_lock")]
        WyzeLock = 16,

        [EnumMember(Value = "yale_lock")]
        YaleLock = 17,

        [EnumMember(Value = "two_n_intercom")]
        TwoNIntercom = 18,

        [EnumMember(Value = "controlbyweb_device")]
        ControlbywebDevice = 19,

        [EnumMember(Value = "ttlock_lock")]
        TtlockLock = 20,

        [EnumMember(Value = "igloohome_lock")]
        IgloohomeLock = 21,

        [EnumMember(Value = "hubitat_lock")]
        HubitatLock = 22,

        [EnumMember(Value = "four_suites_door")]
        FourSuitesDoor = 23,

        [EnumMember(Value = "dormakaba_oracode_door")]
        DormakabaOracodeDoor = 24,

        [EnumMember(Value = "tedee_lock")]
        TedeeLock = 25,

        [EnumMember(Value = "noiseaware_activity_zone")]
        NoiseawareActivityZone = 26,

        [EnumMember(Value = "minut_sensor")]
        MinutSensor = 27,

        [EnumMember(Value = "ecobee_thermostat")]
        EcobeeThermostat = 28,

        [EnumMember(Value = "nest_thermostat")]
        NestThermostat = 29,

        [EnumMember(Value = "honeywell_thermostat")]
        HoneywellThermostat = 30,

        [EnumMember(Value = "ios_phone")]
        IosPhone = 31,

        [EnumMember(Value = "android_phone")]
        AndroidPhone = 32
      }

      [JsonConverter(typeof(StringEnumConverter))]
      public enum ManufacturerEnum
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

        [EnumMember(Value = "doorking")]
        Doorking = 5,

        [EnumMember(Value = "four_suites")]
        FourSuites = 6,

        [EnumMember(Value = "genie")]
        Genie = 7,

        [EnumMember(Value = "igloo")]
        Igloo = 8,

        [EnumMember(Value = "keywe")]
        Keywe = 9,

        [EnumMember(Value = "kwikset")]
        Kwikset = 10,

        [EnumMember(Value = "linear")]
        Linear = 11,

        [EnumMember(Value = "lockly")]
        Lockly = 12,

        [EnumMember(Value = "nuki")]
        Nuki = 13,

        [EnumMember(Value = "philia")]
        Philia = 14,

        [EnumMember(Value = "salto")]
        Salto = 15,

        [EnumMember(Value = "samsung")]
        Samsung = 16,

        [EnumMember(Value = "schlage")]
        Schlage = 17,

        [EnumMember(Value = "seam")]
        Seam = 18,

        [EnumMember(Value = "unknown")]
        Unknown = 19,

        [EnumMember(Value = "wyze")]
        Wyze = 20,

        [EnumMember(Value = "yale")]
        Yale = 21,

        [EnumMember(Value = "minut")]
        Minut = 22,

        [EnumMember(Value = "two_n")]
        TwoN = 23,

        [EnumMember(Value = "ttlock")]
        Ttlock = 24,

        [EnumMember(Value = "nest")]
        Nest = 25,

        [EnumMember(Value = "igloohome")]
        Igloohome = 26,

        [EnumMember(Value = "ecobee")]
        Ecobee = 27,

        [EnumMember(Value = "hubitat")]
        Hubitat = 28,

        [EnumMember(Value = "controlbyweb")]
        Controlbyweb = 29,

        [EnumMember(Value = "smartthings")]
        Smartthings = 30,

        [EnumMember(Value = "dormakaba_oracode")]
        DormakabaOracode = 31,

        [EnumMember(Value = "tedee")]
        Tedee = 32,

        [EnumMember(Value = "honeywell")]
        Honeywell = 33
      }

      [DataMember(Name = "connected_account_id", IsRequired = false, EmitDefaultValue = false)]
      public string? ConnectedAccountId { get; set; }

      [DataMember(Name = "connected_account_ids", IsRequired = false, EmitDefaultValue = false)]
      public List<string>? ConnectedAccountIds { get; set; }

      [DataMember(Name = "connect_webview_id", IsRequired = false, EmitDefaultValue = false)]
      public string? ConnectWebviewId { get; set; }

      [DataMember(Name = "device_type", IsRequired = false, EmitDefaultValue = false)]
      public ListRequest.DeviceTypeEnum? DeviceType { get; set; }

      [DataMember(Name = "device_types", IsRequired = false, EmitDefaultValue = false)]
      public List<ListRequest.DeviceTypesEnum>? DeviceTypes { get; set; }

      [DataMember(Name = "manufacturer", IsRequired = false, EmitDefaultValue = false)]
      public ListRequest.ManufacturerEnum? Manufacturer { get; set; }

      [DataMember(Name = "device_ids", IsRequired = false, EmitDefaultValue = false)]
      public List<string>? DeviceIds { get; set; }

      [DataMember(Name = "limit", IsRequired = false, EmitDefaultValue = false)]
      public float? Limit { get; set; }

      [DataMember(Name = "created_before", IsRequired = false, EmitDefaultValue = false)]
      public string? CreatedBefore { get; set; }

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

      public ListResponse(List<Device> devices = default)
      {
        Devices = devices;
      }

      [DataMember(Name = "devices", IsRequired = false, EmitDefaultValue = false)]
      public List<Device> Devices { get; set; }

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

    public List<Device> List(ListRequest request)
    {
      var requestOptions = new RequestOptions();
      requestOptions.Data = request;
      return _seam.Post<ListResponse>("/locks/list", requestOptions).Data.Devices;
    }

    public List<Device> List(
      string? connectedAccountId = default,
      List<string>? connectedAccountIds = default,
      string? connectWebviewId = default,
      ListRequest.DeviceTypeEnum? deviceType = default,
      List<ListRequest.DeviceTypesEnum>? deviceTypes = default,
      ListRequest.ManufacturerEnum? manufacturer = default,
      List<string>? deviceIds = default,
      float? limit = default,
      string? createdBefore = default,
      string? userIdentifierKey = default,
      object? customMetadataHas = default
    )
    {
      return List(
        new ListRequest(
          connectedAccountId: connectedAccountId,
          connectedAccountIds: connectedAccountIds,
          connectWebviewId: connectWebviewId,
          deviceType: deviceType,
          deviceTypes: deviceTypes,
          manufacturer: manufacturer,
          deviceIds: deviceIds,
          limit: limit,
          createdBefore: createdBefore,
          userIdentifierKey: userIdentifierKey,
          customMetadataHas: customMetadataHas
        )
      );
    }

    public async Task<List<Device>> ListAsync(ListRequest request)
    {
      var requestOptions = new RequestOptions();
      requestOptions.Data = request;
      return (await _seam.PostAsync<ListResponse>("/locks/list", requestOptions)).Data.Devices;
    }

    public async Task<List<Device>> ListAsync(
      string? connectedAccountId = default,
      List<string>? connectedAccountIds = default,
      string? connectWebviewId = default,
      ListRequest.DeviceTypeEnum? deviceType = default,
      List<ListRequest.DeviceTypesEnum>? deviceTypes = default,
      ListRequest.ManufacturerEnum? manufacturer = default,
      List<string>? deviceIds = default,
      float? limit = default,
      string? createdBefore = default,
      string? userIdentifierKey = default,
      object? customMetadataHas = default
    )
    {
      return (
        await ListAsync(
          new ListRequest(
            connectedAccountId: connectedAccountId,
            connectedAccountIds: connectedAccountIds,
            connectWebviewId: connectWebviewId,
            deviceType: deviceType,
            deviceTypes: deviceTypes,
            manufacturer: manufacturer,
            deviceIds: deviceIds,
            limit: limit,
            createdBefore: createdBefore,
            userIdentifierKey: userIdentifierKey,
            customMetadataHas: customMetadataHas
          )
        )
      );
    }

    [DataContract(Name = "lockDoorRequest_request")]
    public class LockDoorRequest
    {
      [JsonConstructorAttribute]
      protected LockDoorRequest() { }

      public LockDoorRequest(string deviceId = default, bool? sync = default)
      {
        DeviceId = deviceId;
        Sync = sync;
      }

      [DataMember(Name = "device_id", IsRequired = true, EmitDefaultValue = false)]
      public string DeviceId { get; set; }

      [DataMember(Name = "sync", IsRequired = false, EmitDefaultValue = false)]
      public bool? Sync { get; set; }

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

    [DataContract(Name = "lockDoorResponse_response")]
    public class LockDoorResponse
    {
      [JsonConstructorAttribute]
      protected LockDoorResponse() { }

      public LockDoorResponse(ActionAttempt actionAttempt = default)
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

    public ActionAttempt LockDoor(LockDoorRequest request)
    {
      var requestOptions = new RequestOptions();
      requestOptions.Data = request;
      return _seam.Post<LockDoorResponse>("/locks/lock_door", requestOptions).Data.ActionAttempt;
    }

    public ActionAttempt LockDoor(string deviceId = default, bool? sync = default)
    {
      return LockDoor(new LockDoorRequest(deviceId: deviceId, sync: sync));
    }

    public async Task<ActionAttempt> LockDoorAsync(LockDoorRequest request)
    {
      var requestOptions = new RequestOptions();
      requestOptions.Data = request;
      return (await _seam.PostAsync<LockDoorResponse>("/locks/lock_door", requestOptions))
        .Data
        .ActionAttempt;
    }

    public async Task<ActionAttempt> LockDoorAsync(string deviceId = default, bool? sync = default)
    {
      return (await LockDoorAsync(new LockDoorRequest(deviceId: deviceId, sync: sync)));
    }

    [DataContract(Name = "unlockDoorRequest_request")]
    public class UnlockDoorRequest
    {
      [JsonConstructorAttribute]
      protected UnlockDoorRequest() { }

      public UnlockDoorRequest(string deviceId = default, bool? sync = default)
      {
        DeviceId = deviceId;
        Sync = sync;
      }

      [DataMember(Name = "device_id", IsRequired = true, EmitDefaultValue = false)]
      public string DeviceId { get; set; }

      [DataMember(Name = "sync", IsRequired = false, EmitDefaultValue = false)]
      public bool? Sync { get; set; }

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

    [DataContract(Name = "unlockDoorResponse_response")]
    public class UnlockDoorResponse
    {
      [JsonConstructorAttribute]
      protected UnlockDoorResponse() { }

      public UnlockDoorResponse(ActionAttempt actionAttempt = default)
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

    public ActionAttempt UnlockDoor(UnlockDoorRequest request)
    {
      var requestOptions = new RequestOptions();
      requestOptions.Data = request;
      return _seam
        .Post<UnlockDoorResponse>("/locks/unlock_door", requestOptions)
        .Data.ActionAttempt;
    }

    public ActionAttempt UnlockDoor(string deviceId = default, bool? sync = default)
    {
      return UnlockDoor(new UnlockDoorRequest(deviceId: deviceId, sync: sync));
    }

    public async Task<ActionAttempt> UnlockDoorAsync(UnlockDoorRequest request)
    {
      var requestOptions = new RequestOptions();
      requestOptions.Data = request;
      return (await _seam.PostAsync<UnlockDoorResponse>("/locks/unlock_door", requestOptions))
        .Data
        .ActionAttempt;
    }

    public async Task<ActionAttempt> UnlockDoorAsync(
      string deviceId = default,
      bool? sync = default
    )
    {
      return (await UnlockDoorAsync(new UnlockDoorRequest(deviceId: deviceId, sync: sync)));
    }
  }
}

namespace Seam.Client
{
  public partial class SeamClient
  {
    public Api.Locks Locks => new(this);
  }

  public partial interface ISeamClient
  {
    public Api.Locks Locks { get; }
  }
}
