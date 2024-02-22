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
  public class Events
  {
    private ISeamClient _seam;

    public Events(ISeamClient seam)
    {
      _seam = seam;
    }

    [DataContract(Name = "getRequest_request")]
    public class GetRequest
    {
      [JsonConstructorAttribute]
      protected GetRequest() { }

      public GetRequest(
        string? eventId = default,
        string? eventType = default,
        string? deviceId = default
      )
      {
        EventId = eventId;
        EventType = eventType;
        DeviceId = deviceId;
      }

      [DataMember(Name = "event_id", IsRequired = false, EmitDefaultValue = false)]
      public string? EventId { get; set; }

      [DataMember(Name = "event_type", IsRequired = false, EmitDefaultValue = false)]
      public string? EventType { get; set; }

      [DataMember(Name = "device_id", IsRequired = false, EmitDefaultValue = false)]
      public string? DeviceId { get; set; }

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

      public GetResponse(Event? event_ = default)
      {
        Event = event_;
      }

      [DataMember(Name = "event", IsRequired = false, EmitDefaultValue = false)]
      public Event? Event { get; set; }

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

    public Event Get(GetRequest request)
    {
      var requestOptions = new RequestOptions();
      requestOptions.Data = request;
      return _seam.Post<GetResponse>("/events/get", requestOptions).Data.Event;
    }

    public Event Get(
      string? eventId = default,
      string? eventType = default,
      string? deviceId = default
    )
    {
      return Get(new GetRequest(eventId: eventId, eventType: eventType, deviceId: deviceId));
    }

    public async Task<Event> GetAsync(GetRequest request)
    {
      var requestOptions = new RequestOptions();
      requestOptions.Data = request;
      return (await _seam.PostAsync<GetResponse>("/events/get", requestOptions)).Data.Event;
    }

    public async Task<Event> GetAsync(
      string? eventId = default,
      string? eventType = default,
      string? deviceId = default
    )
    {
      return (
        await GetAsync(new GetRequest(eventId: eventId, eventType: eventType, deviceId: deviceId))
      );
    }

    [DataContract(Name = "listRequest_request")]
    public class ListRequest
    {
      [JsonConstructorAttribute]
      protected ListRequest() { }

      public ListRequest(
        string? since = default,
        List<string>? between = default,
        string? deviceId = default,
        List<string>? deviceIds = default,
        string? accessCodeId = default,
        List<string>? accessCodeIds = default,
        ListRequest.EventTypeEnum? eventType = default,
        List<ListRequest.EventTypesEnum>? eventTypes = default,
        string? connectedAccountId = default
      )
      {
        Since = since;
        Between = between;
        DeviceId = deviceId;
        DeviceIds = deviceIds;
        AccessCodeId = accessCodeId;
        AccessCodeIds = accessCodeIds;
        EventType = eventType;
        EventTypes = eventTypes;
        ConnectedAccountId = connectedAccountId;
      }

      [JsonConverter(typeof(StringEnumConverter))]
      public enum EventTypeEnum
      {
        [EnumMember(Value = "device.connected")]
        DeviceConnected = 0,

        [EnumMember(Value = "device.unmanaged.connected")]
        DeviceUnmanagedConnected = 1,

        [EnumMember(Value = "device.disconnected")]
        DeviceDisconnected = 2,

        [EnumMember(Value = "device.unmanaged.disconnected")]
        DeviceUnmanagedDisconnected = 3,

        [EnumMember(Value = "device.converted_to_unmanaged")]
        DeviceConvertedToUnmanaged = 4,

        [EnumMember(Value = "device.unmanaged.converted_to_managed")]
        DeviceUnmanagedConvertedToManaged = 5,

        [EnumMember(Value = "device.removed")]
        DeviceRemoved = 6,

        [EnumMember(Value = "device.tampered")]
        DeviceTampered = 7,

        [EnumMember(Value = "device.low_battery")]
        DeviceLowBattery = 8,

        [EnumMember(Value = "device.battery_status_changed")]
        DeviceBatteryStatusChanged = 9,

        [EnumMember(Value = "device.third_party_integration_detected")]
        DeviceThirdPartyIntegrationDetected = 10,

        [EnumMember(Value = "device.third_party_integration_no_longer_detected")]
        DeviceThirdPartyIntegrationNoLongerDetected = 11,

        [EnumMember(Value = "device.salto.privacy_mode_activated")]
        DeviceSaltoPrivacyModeActivated = 12,

        [EnumMember(Value = "device.salto.privacy_mode_deactivated")]
        DeviceSaltoPrivacyModeDeactivated = 13,

        [EnumMember(Value = "device.connection_became_flaky")]
        DeviceConnectionBecameFlaky = 14,

        [EnumMember(Value = "device.connection_stabilized")]
        DeviceConnectionStabilized = 15,

        [EnumMember(Value = "device.error.subscription_required")]
        DeviceErrorSubscriptionRequired = 16,

        [EnumMember(Value = "device.error.subscription_required.resolved")]
        DeviceErrorSubscriptionRequiredResolved = 17,

        [EnumMember(Value = "access_code.created")]
        AccessCodeCreated = 18,

        [EnumMember(Value = "access_code.changed")]
        AccessCodeChanged = 19,

        [EnumMember(Value = "access_code.scheduled_on_device")]
        AccessCodeScheduledOnDevice = 20,

        [EnumMember(Value = "access_code.set_on_device")]
        AccessCodeSetOnDevice = 21,

        [EnumMember(Value = "access_code.deleted")]
        AccessCodeDeleted = 22,

        [EnumMember(Value = "access_code.removed_from_device")]
        AccessCodeRemovedFromDevice = 23,

        [EnumMember(Value = "access_code.failed_to_set_on_device")]
        AccessCodeFailedToSetOnDevice = 24,

        [EnumMember(Value = "access_code.delay_in_setting_on_device")]
        AccessCodeDelayInSettingOnDevice = 25,

        [EnumMember(Value = "access_code.failed_to_remove_from_device")]
        AccessCodeFailedToRemoveFromDevice = 26,

        [EnumMember(Value = "access_code.delay_in_removing_from_device")]
        AccessCodeDelayInRemovingFromDevice = 27,

        [EnumMember(Value = "access_code.deleted_external_to_seam")]
        AccessCodeDeletedExternalToSeam = 28,

        [EnumMember(Value = "access_code.modified_external_to_seam")]
        AccessCodeModifiedExternalToSeam = 29,

        [EnumMember(Value = "access_code.unmanaged.converted_to_managed")]
        AccessCodeUnmanagedConvertedToManaged = 30,

        [EnumMember(Value = "access_code.unmanaged.failed_to_convert_to_managed")]
        AccessCodeUnmanagedFailedToConvertToManaged = 31,

        [EnumMember(Value = "access_code.unmanaged.created")]
        AccessCodeUnmanagedCreated = 32,

        [EnumMember(Value = "access_code.unmanaged.removed")]
        AccessCodeUnmanagedRemoved = 33,

        [EnumMember(Value = "lock.locked")]
        LockLocked = 34,

        [EnumMember(Value = "lock.unlocked")]
        LockUnlocked = 35,

        [EnumMember(Value = "phone.deactivated")]
        PhoneDeactivated = 36,

        [EnumMember(Value = "connected_account.connected")]
        ConnectedAccountConnected = 37,

        [EnumMember(Value = "connected_account.successful_login")]
        ConnectedAccountSuccessfulLogin = 38,

        [EnumMember(Value = "connected_account.created")]
        ConnectedAccountCreated = 39,

        [EnumMember(Value = "connected_account.deleted")]
        ConnectedAccountDeleted = 40,

        [EnumMember(Value = "connected_account.disconnected")]
        ConnectedAccountDisconnected = 41,

        [EnumMember(Value = "connected_account.completed_first_sync")]
        ConnectedAccountCompletedFirstSync = 42,

        [EnumMember(Value = "connected_account.completed_first_sync_after_reconnection")]
        ConnectedAccountCompletedFirstSyncAfterReconnection = 43,

        [EnumMember(Value = "noise_sensor.noise_threshold_triggered")]
        NoiseSensorNoiseThresholdTriggered = 44,

        [EnumMember(Value = "access_code.backup_access_code_pulled")]
        AccessCodeBackupAccessCodePulled = 45
      }

      [JsonConverter(typeof(StringEnumConverter))]
      public enum EventTypesEnum
      {
        [EnumMember(Value = "device.connected")]
        DeviceConnected = 0,

        [EnumMember(Value = "device.unmanaged.connected")]
        DeviceUnmanagedConnected = 1,

        [EnumMember(Value = "device.disconnected")]
        DeviceDisconnected = 2,

        [EnumMember(Value = "device.unmanaged.disconnected")]
        DeviceUnmanagedDisconnected = 3,

        [EnumMember(Value = "device.converted_to_unmanaged")]
        DeviceConvertedToUnmanaged = 4,

        [EnumMember(Value = "device.unmanaged.converted_to_managed")]
        DeviceUnmanagedConvertedToManaged = 5,

        [EnumMember(Value = "device.removed")]
        DeviceRemoved = 6,

        [EnumMember(Value = "device.tampered")]
        DeviceTampered = 7,

        [EnumMember(Value = "device.low_battery")]
        DeviceLowBattery = 8,

        [EnumMember(Value = "device.battery_status_changed")]
        DeviceBatteryStatusChanged = 9,

        [EnumMember(Value = "device.third_party_integration_detected")]
        DeviceThirdPartyIntegrationDetected = 10,

        [EnumMember(Value = "device.third_party_integration_no_longer_detected")]
        DeviceThirdPartyIntegrationNoLongerDetected = 11,

        [EnumMember(Value = "device.salto.privacy_mode_activated")]
        DeviceSaltoPrivacyModeActivated = 12,

        [EnumMember(Value = "device.salto.privacy_mode_deactivated")]
        DeviceSaltoPrivacyModeDeactivated = 13,

        [EnumMember(Value = "device.connection_became_flaky")]
        DeviceConnectionBecameFlaky = 14,

        [EnumMember(Value = "device.connection_stabilized")]
        DeviceConnectionStabilized = 15,

        [EnumMember(Value = "device.error.subscription_required")]
        DeviceErrorSubscriptionRequired = 16,

        [EnumMember(Value = "device.error.subscription_required.resolved")]
        DeviceErrorSubscriptionRequiredResolved = 17,

        [EnumMember(Value = "access_code.created")]
        AccessCodeCreated = 18,

        [EnumMember(Value = "access_code.changed")]
        AccessCodeChanged = 19,

        [EnumMember(Value = "access_code.scheduled_on_device")]
        AccessCodeScheduledOnDevice = 20,

        [EnumMember(Value = "access_code.set_on_device")]
        AccessCodeSetOnDevice = 21,

        [EnumMember(Value = "access_code.deleted")]
        AccessCodeDeleted = 22,

        [EnumMember(Value = "access_code.removed_from_device")]
        AccessCodeRemovedFromDevice = 23,

        [EnumMember(Value = "access_code.failed_to_set_on_device")]
        AccessCodeFailedToSetOnDevice = 24,

        [EnumMember(Value = "access_code.delay_in_setting_on_device")]
        AccessCodeDelayInSettingOnDevice = 25,

        [EnumMember(Value = "access_code.failed_to_remove_from_device")]
        AccessCodeFailedToRemoveFromDevice = 26,

        [EnumMember(Value = "access_code.delay_in_removing_from_device")]
        AccessCodeDelayInRemovingFromDevice = 27,

        [EnumMember(Value = "access_code.deleted_external_to_seam")]
        AccessCodeDeletedExternalToSeam = 28,

        [EnumMember(Value = "access_code.modified_external_to_seam")]
        AccessCodeModifiedExternalToSeam = 29,

        [EnumMember(Value = "access_code.unmanaged.converted_to_managed")]
        AccessCodeUnmanagedConvertedToManaged = 30,

        [EnumMember(Value = "access_code.unmanaged.failed_to_convert_to_managed")]
        AccessCodeUnmanagedFailedToConvertToManaged = 31,

        [EnumMember(Value = "access_code.unmanaged.created")]
        AccessCodeUnmanagedCreated = 32,

        [EnumMember(Value = "access_code.unmanaged.removed")]
        AccessCodeUnmanagedRemoved = 33,

        [EnumMember(Value = "lock.locked")]
        LockLocked = 34,

        [EnumMember(Value = "lock.unlocked")]
        LockUnlocked = 35,

        [EnumMember(Value = "phone.deactivated")]
        PhoneDeactivated = 36,

        [EnumMember(Value = "connected_account.connected")]
        ConnectedAccountConnected = 37,

        [EnumMember(Value = "connected_account.successful_login")]
        ConnectedAccountSuccessfulLogin = 38,

        [EnumMember(Value = "connected_account.created")]
        ConnectedAccountCreated = 39,

        [EnumMember(Value = "connected_account.deleted")]
        ConnectedAccountDeleted = 40,

        [EnumMember(Value = "connected_account.disconnected")]
        ConnectedAccountDisconnected = 41,

        [EnumMember(Value = "connected_account.completed_first_sync")]
        ConnectedAccountCompletedFirstSync = 42,

        [EnumMember(Value = "connected_account.completed_first_sync_after_reconnection")]
        ConnectedAccountCompletedFirstSyncAfterReconnection = 43,

        [EnumMember(Value = "noise_sensor.noise_threshold_triggered")]
        NoiseSensorNoiseThresholdTriggered = 44,

        [EnumMember(Value = "access_code.backup_access_code_pulled")]
        AccessCodeBackupAccessCodePulled = 45
      }

      [DataMember(Name = "since", IsRequired = false, EmitDefaultValue = false)]
      public string? Since { get; set; }

      [DataMember(Name = "between", IsRequired = false, EmitDefaultValue = false)]
      public List<string>? Between { get; set; }

      [DataMember(Name = "device_id", IsRequired = false, EmitDefaultValue = false)]
      public string? DeviceId { get; set; }

      [DataMember(Name = "device_ids", IsRequired = false, EmitDefaultValue = false)]
      public List<string>? DeviceIds { get; set; }

      [DataMember(Name = "access_code_id", IsRequired = false, EmitDefaultValue = false)]
      public string? AccessCodeId { get; set; }

      [DataMember(Name = "access_code_ids", IsRequired = false, EmitDefaultValue = false)]
      public List<string>? AccessCodeIds { get; set; }

      [DataMember(Name = "event_type", IsRequired = false, EmitDefaultValue = false)]
      public ListRequest.EventTypeEnum? EventType { get; set; }

      [DataMember(Name = "event_types", IsRequired = false, EmitDefaultValue = false)]
      public List<ListRequest.EventTypesEnum>? EventTypes { get; set; }

      [DataMember(Name = "connected_account_id", IsRequired = false, EmitDefaultValue = false)]
      public string? ConnectedAccountId { get; set; }

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

      public ListResponse(List<Event?>? events = default)
      {
        Events = events;
      }

      [DataMember(Name = "events", IsRequired = false, EmitDefaultValue = false)]
      public List<Event?>? Events { get; set; }

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

    public List<Event?> List(ListRequest request)
    {
      var requestOptions = new RequestOptions();
      requestOptions.Data = request;
      return _seam.Post<ListResponse>("/events/list", requestOptions).Data.Events;
    }

    public List<Event?> List(
      string? since = default,
      List<string>? between = default,
      string? deviceId = default,
      List<string>? deviceIds = default,
      string? accessCodeId = default,
      List<string>? accessCodeIds = default,
      ListRequest.EventTypeEnum? eventType = default,
      List<ListRequest.EventTypesEnum>? eventTypes = default,
      string? connectedAccountId = default
    )
    {
      return List(
        new ListRequest(
          since: since,
          between: between,
          deviceId: deviceId,
          deviceIds: deviceIds,
          accessCodeId: accessCodeId,
          accessCodeIds: accessCodeIds,
          eventType: eventType,
          eventTypes: eventTypes,
          connectedAccountId: connectedAccountId
        )
      );
    }

    public async Task<List<Event?>> ListAsync(ListRequest request)
    {
      var requestOptions = new RequestOptions();
      requestOptions.Data = request;
      return (await _seam.PostAsync<ListResponse>("/events/list", requestOptions)).Data.Events;
    }

    public async Task<List<Event?>> ListAsync(
      string? since = default,
      List<string>? between = default,
      string? deviceId = default,
      List<string>? deviceIds = default,
      string? accessCodeId = default,
      List<string>? accessCodeIds = default,
      ListRequest.EventTypeEnum? eventType = default,
      List<ListRequest.EventTypesEnum>? eventTypes = default,
      string? connectedAccountId = default
    )
    {
      return (
        await ListAsync(
          new ListRequest(
            since: since,
            between: between,
            deviceId: deviceId,
            deviceIds: deviceIds,
            accessCodeId: accessCodeId,
            accessCodeIds: accessCodeIds,
            eventType: eventType,
            eventTypes: eventTypes,
            connectedAccountId: connectedAccountId
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
    public Api.Events Events => new(this);
  }

  public partial interface ISeamClient
  {
    public Api.Events Events { get; }
  }
}
