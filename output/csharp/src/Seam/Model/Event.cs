using System.Runtime.Serialization;
using System.Text;
using JsonSubTypes;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;

namespace Seam.Model
{
    [JsonConverter(typeof(JsonSubtypes), "event_type")]
    [JsonSubtypes.KnownSubType(typeof(EventPhoneDeactivated), "phone.deactivated")]
    [JsonSubtypes.KnownSubType(
        typeof(EventEnrollmentAutomationDeleted),
        "enrollment_automation.deleted"
    )]
    [JsonSubtypes.KnownSubType(
        typeof(EventThermostatTemperatureThresholdNoLongerExceeded),
        "thermostat.temperature_threshold_no_longer_exceeded"
    )]
    [JsonSubtypes.KnownSubType(
        typeof(EventThermostatTemperatureThresholdExceeded),
        "thermostat.temperature_threshold_exceeded"
    )]
    [JsonSubtypes.KnownSubType(
        typeof(EventThermostatManuallyAdjusted),
        "thermostat.manually_adjusted"
    )]
    [JsonSubtypes.KnownSubType(
        typeof(EventThermostatClimatePresetActivated),
        "thermostat.climate_preset_activated"
    )]
    [JsonSubtypes.KnownSubType(typeof(EventLockAccessDenied), "lock.access_denied")]
    [JsonSubtypes.KnownSubType(typeof(EventLockUnlocked), "lock.unlocked")]
    [JsonSubtypes.KnownSubType(typeof(EventLockLocked), "lock.locked")]
    [JsonSubtypes.KnownSubType(
        typeof(EventNoiseSensorNoiseThresholdTriggered),
        "noise_sensor.noise_threshold_triggered"
    )]
    [JsonSubtypes.KnownSubType(
        typeof(EventDeviceAccessoryKeypadDisconnected),
        "device.accessory_keypad_disconnected"
    )]
    [JsonSubtypes.KnownSubType(
        typeof(EventDeviceAccessoryKeypadConnected),
        "device.accessory_keypad_connected"
    )]
    [JsonSubtypes.KnownSubType(
        typeof(EventDeviceErrorSubscriptionRequiredResolved),
        "device.error.subscription_required.resolved"
    )]
    [JsonSubtypes.KnownSubType(
        typeof(EventDeviceErrorSubscriptionRequired),
        "device.error.subscription_required"
    )]
    [JsonSubtypes.KnownSubType(
        typeof(EventDeviceConnectionStabilized),
        "device.connection_stabilized"
    )]
    [JsonSubtypes.KnownSubType(
        typeof(EventDeviceConnectionBecameFlaky),
        "device.connection_became_flaky"
    )]
    [JsonSubtypes.KnownSubType(
        typeof(EventDeviceSaltoPrivacyModeDeactivated),
        "device.salto.privacy_mode_deactivated"
    )]
    [JsonSubtypes.KnownSubType(
        typeof(EventDeviceSaltoPrivacyModeActivated),
        "device.salto.privacy_mode_activated"
    )]
    [JsonSubtypes.KnownSubType(
        typeof(EventDeviceThirdPartyIntegrationNoLongerDetected),
        "device.third_party_integration_no_longer_detected"
    )]
    [JsonSubtypes.KnownSubType(
        typeof(EventDeviceThirdPartyIntegrationDetected),
        "device.third_party_integration_detected"
    )]
    [JsonSubtypes.KnownSubType(typeof(EventDeviceDeleted), "device.deleted")]
    [JsonSubtypes.KnownSubType(typeof(EventDeviceRemoved), "device.removed")]
    [JsonSubtypes.KnownSubType(
        typeof(EventDeviceBatteryStatusChanged),
        "device.battery_status_changed"
    )]
    [JsonSubtypes.KnownSubType(typeof(EventDeviceLowBattery), "device.low_battery")]
    [JsonSubtypes.KnownSubType(typeof(EventDeviceTampered), "device.tampered")]
    [JsonSubtypes.KnownSubType(
        typeof(EventDeviceUnmanagedDisconnected),
        "device.unmanaged.disconnected"
    )]
    [JsonSubtypes.KnownSubType(typeof(EventDeviceDisconnected), "device.disconnected")]
    [JsonSubtypes.KnownSubType(typeof(EventDeviceUnmanagedConnected), "device.unmanaged.connected")]
    [JsonSubtypes.KnownSubType(
        typeof(EventDeviceUnmanagedConvertedToManaged),
        "device.unmanaged.converted_to_managed"
    )]
    [JsonSubtypes.KnownSubType(
        typeof(EventDeviceConvertedToUnmanaged),
        "device.converted_to_unmanaged"
    )]
    [JsonSubtypes.KnownSubType(typeof(EventDeviceAdded), "device.added")]
    [JsonSubtypes.KnownSubType(typeof(EventDeviceConnected), "device.connected")]
    [JsonSubtypes.KnownSubType(
        typeof(EventConnectWebviewLoginFailed),
        "connect_webview.login_failed"
    )]
    [JsonSubtypes.KnownSubType(
        typeof(EventConnectWebviewLoginSucceeded),
        "connect_webview.login_succeeded"
    )]
    [JsonSubtypes.KnownSubType(
        typeof(EventActionAttemptUnlockDoorFailed),
        "action_attempt.unlock_door.failed"
    )]
    [JsonSubtypes.KnownSubType(
        typeof(EventActionAttemptUnlockDoorSucceeded),
        "action_attempt.unlock_door.succeeded"
    )]
    [JsonSubtypes.KnownSubType(
        typeof(EventActionAttemptLockDoorFailed),
        "action_attempt.lock_door.failed"
    )]
    [JsonSubtypes.KnownSubType(
        typeof(EventActionAttemptLockDoorSucceeded),
        "action_attempt.lock_door.succeeded"
    )]
    [JsonSubtypes.KnownSubType(
        typeof(EventConnectedAccountCompletedFirstSyncAfterReconnection),
        "connected_account.completed_first_sync_after_reconnection"
    )]
    [JsonSubtypes.KnownSubType(typeof(EventConnectedAccountDeleted), "connected_account.deleted")]
    [JsonSubtypes.KnownSubType(
        typeof(EventConnectedAccountCompletedFirstSync),
        "connected_account.completed_first_sync"
    )]
    [JsonSubtypes.KnownSubType(
        typeof(EventConnectedAccountDisconnected),
        "connected_account.disconnected"
    )]
    [JsonSubtypes.KnownSubType(
        typeof(EventConnectedAccountSuccessfulLogin),
        "connected_account.successful_login"
    )]
    [JsonSubtypes.KnownSubType(typeof(EventConnectedAccountCreated), "connected_account.created")]
    [JsonSubtypes.KnownSubType(
        typeof(EventConnectedAccountConnected),
        "connected_account.connected"
    )]
    [JsonSubtypes.KnownSubType(typeof(EventClientSessionDeleted), "client_session.deleted")]
    [JsonSubtypes.KnownSubType(typeof(EventAcsEncoderRemoved), "acs_encoder.removed")]
    [JsonSubtypes.KnownSubType(typeof(EventAcsEncoderAdded), "acs_encoder.added")]
    [JsonSubtypes.KnownSubType(typeof(EventAcsUserDeleted), "acs_user.deleted")]
    [JsonSubtypes.KnownSubType(typeof(EventAcsCredentialIssued), "acs_credential.issued")]
    [JsonSubtypes.KnownSubType(typeof(EventAcsCredentialDeleted), "acs_credential.deleted")]
    [JsonSubtypes.KnownSubType(typeof(EventAcsSystemDisconnected), "acs_system.disconnected")]
    [JsonSubtypes.KnownSubType(typeof(EventAcsSystemAdded), "acs_system.added")]
    [JsonSubtypes.KnownSubType(typeof(EventAcsSystemConnected), "acs_system.connected")]
    [JsonSubtypes.KnownSubType(
        typeof(EventAccessCodeUnmanagedRemoved),
        "access_code.unmanaged.removed"
    )]
    [JsonSubtypes.KnownSubType(
        typeof(EventAccessCodeUnmanagedCreated),
        "access_code.unmanaged.created"
    )]
    [JsonSubtypes.KnownSubType(
        typeof(EventAccessCodeUnmanagedFailedToConvertToManaged),
        "access_code.unmanaged.failed_to_convert_to_managed"
    )]
    [JsonSubtypes.KnownSubType(
        typeof(EventAccessCodeUnmanagedConvertedToManaged),
        "access_code.unmanaged.converted_to_managed"
    )]
    [JsonSubtypes.KnownSubType(
        typeof(EventAccessCodeBackupAccessCodePulled),
        "access_code.backup_access_code_pulled"
    )]
    [JsonSubtypes.KnownSubType(
        typeof(EventAccessCodeDeletedExternalToSeam),
        "access_code.deleted_external_to_seam"
    )]
    [JsonSubtypes.KnownSubType(
        typeof(EventAccessCodeModifiedExternalToSeam),
        "access_code.modified_external_to_seam"
    )]
    [JsonSubtypes.KnownSubType(
        typeof(EventAccessCodeFailedToRemoveFromDevice),
        "access_code.failed_to_remove_from_device"
    )]
    [JsonSubtypes.KnownSubType(
        typeof(EventAccessCodeDelayInRemovingFromDevice),
        "access_code.delay_in_removing_from_device"
    )]
    [JsonSubtypes.KnownSubType(typeof(EventAccessCodeDeleted), "access_code.deleted")]
    [JsonSubtypes.KnownSubType(
        typeof(EventAccessCodeFailedToSetOnDevice),
        "access_code.failed_to_set_on_device"
    )]
    [JsonSubtypes.KnownSubType(
        typeof(EventAccessCodeDelayInSettingOnDevice),
        "access_code.delay_in_setting_on_device"
    )]
    [JsonSubtypes.KnownSubType(
        typeof(EventAccessCodeRemovedFromDevice),
        "access_code.removed_from_device"
    )]
    [JsonSubtypes.KnownSubType(typeof(EventAccessCodeSetOnDevice), "access_code.set_on_device")]
    [JsonSubtypes.KnownSubType(
        typeof(EventAccessCodeScheduledOnDevice),
        "access_code.scheduled_on_device"
    )]
    [JsonSubtypes.KnownSubType(typeof(EventAccessCodeChanged), "access_code.changed")]
    [JsonSubtypes.KnownSubType(typeof(EventAccessCodeCreated), "access_code.created")]
    public abstract class Event
    {
        public abstract string EventType { get; }

        public abstract override string ToString();
    }

    [DataContract(Name = "seamModel_eventAccessCodeCreated_model")]
    public class EventAccessCodeCreated : Event
    {
        [JsonConstructorAttribute]
        protected EventAccessCodeCreated() { }

        public EventAccessCodeCreated(
            string accessCodeId = default,
            string connectedAccountId = default,
            string createdAt = default,
            string deviceId = default,
            string eventId = default,
            string eventType = default,
            string occurredAt = default,
            string workspaceId = default
        )
        {
            AccessCodeId = accessCodeId;
            ConnectedAccountId = connectedAccountId;
            CreatedAt = createdAt;
            DeviceId = deviceId;
            EventId = eventId;
            EventType = eventType;
            OccurredAt = occurredAt;
            WorkspaceId = workspaceId;
        }

        [DataMember(Name = "access_code_id", IsRequired = true, EmitDefaultValue = false)]
        public string AccessCodeId { get; set; }

        [DataMember(Name = "connected_account_id", IsRequired = true, EmitDefaultValue = false)]
        public string ConnectedAccountId { get; set; }

        [DataMember(Name = "created_at", IsRequired = true, EmitDefaultValue = false)]
        public string CreatedAt { get; set; }

        [DataMember(Name = "device_id", IsRequired = true, EmitDefaultValue = false)]
        public string DeviceId { get; set; }

        [DataMember(Name = "event_id", IsRequired = true, EmitDefaultValue = false)]
        public string EventId { get; set; }

        [DataMember(Name = "event_type", IsRequired = true, EmitDefaultValue = false)]
        public override string EventType { get; } = "access_code.created";

        [DataMember(Name = "occurred_at", IsRequired = true, EmitDefaultValue = false)]
        public string OccurredAt { get; set; }

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

    [DataContract(Name = "seamModel_eventAccessCodeChanged_model")]
    public class EventAccessCodeChanged : Event
    {
        [JsonConstructorAttribute]
        protected EventAccessCodeChanged() { }

        public EventAccessCodeChanged(
            string accessCodeId = default,
            string connectedAccountId = default,
            string createdAt = default,
            string deviceId = default,
            string eventId = default,
            string eventType = default,
            string occurredAt = default,
            string workspaceId = default
        )
        {
            AccessCodeId = accessCodeId;
            ConnectedAccountId = connectedAccountId;
            CreatedAt = createdAt;
            DeviceId = deviceId;
            EventId = eventId;
            EventType = eventType;
            OccurredAt = occurredAt;
            WorkspaceId = workspaceId;
        }

        [DataMember(Name = "access_code_id", IsRequired = true, EmitDefaultValue = false)]
        public string AccessCodeId { get; set; }

        [DataMember(Name = "connected_account_id", IsRequired = true, EmitDefaultValue = false)]
        public string ConnectedAccountId { get; set; }

        [DataMember(Name = "created_at", IsRequired = true, EmitDefaultValue = false)]
        public string CreatedAt { get; set; }

        [DataMember(Name = "device_id", IsRequired = true, EmitDefaultValue = false)]
        public string DeviceId { get; set; }

        [DataMember(Name = "event_id", IsRequired = true, EmitDefaultValue = false)]
        public string EventId { get; set; }

        [DataMember(Name = "event_type", IsRequired = true, EmitDefaultValue = false)]
        public override string EventType { get; } = "access_code.changed";

        [DataMember(Name = "occurred_at", IsRequired = true, EmitDefaultValue = false)]
        public string OccurredAt { get; set; }

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

    [DataContract(Name = "seamModel_eventAccessCodeScheduledOnDevice_model")]
    public class EventAccessCodeScheduledOnDevice : Event
    {
        [JsonConstructorAttribute]
        protected EventAccessCodeScheduledOnDevice() { }

        public EventAccessCodeScheduledOnDevice(
            string accessCodeId = default,
            string code = default,
            string connectedAccountId = default,
            string createdAt = default,
            string deviceId = default,
            string eventId = default,
            string eventType = default,
            string occurredAt = default,
            string workspaceId = default
        )
        {
            AccessCodeId = accessCodeId;
            Code = code;
            ConnectedAccountId = connectedAccountId;
            CreatedAt = createdAt;
            DeviceId = deviceId;
            EventId = eventId;
            EventType = eventType;
            OccurredAt = occurredAt;
            WorkspaceId = workspaceId;
        }

        [DataMember(Name = "access_code_id", IsRequired = true, EmitDefaultValue = false)]
        public string AccessCodeId { get; set; }

        [DataMember(Name = "code", IsRequired = true, EmitDefaultValue = false)]
        public string Code { get; set; }

        [DataMember(Name = "connected_account_id", IsRequired = true, EmitDefaultValue = false)]
        public string ConnectedAccountId { get; set; }

        [DataMember(Name = "created_at", IsRequired = true, EmitDefaultValue = false)]
        public string CreatedAt { get; set; }

        [DataMember(Name = "device_id", IsRequired = true, EmitDefaultValue = false)]
        public string DeviceId { get; set; }

        [DataMember(Name = "event_id", IsRequired = true, EmitDefaultValue = false)]
        public string EventId { get; set; }

        [DataMember(Name = "event_type", IsRequired = true, EmitDefaultValue = false)]
        public override string EventType { get; } = "access_code.scheduled_on_device";

        [DataMember(Name = "occurred_at", IsRequired = true, EmitDefaultValue = false)]
        public string OccurredAt { get; set; }

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

    [DataContract(Name = "seamModel_eventAccessCodeSetOnDevice_model")]
    public class EventAccessCodeSetOnDevice : Event
    {
        [JsonConstructorAttribute]
        protected EventAccessCodeSetOnDevice() { }

        public EventAccessCodeSetOnDevice(
            string accessCodeId = default,
            string code = default,
            string connectedAccountId = default,
            string createdAt = default,
            string deviceId = default,
            string eventId = default,
            string eventType = default,
            string occurredAt = default,
            string workspaceId = default
        )
        {
            AccessCodeId = accessCodeId;
            Code = code;
            ConnectedAccountId = connectedAccountId;
            CreatedAt = createdAt;
            DeviceId = deviceId;
            EventId = eventId;
            EventType = eventType;
            OccurredAt = occurredAt;
            WorkspaceId = workspaceId;
        }

        [DataMember(Name = "access_code_id", IsRequired = true, EmitDefaultValue = false)]
        public string AccessCodeId { get; set; }

        [DataMember(Name = "code", IsRequired = true, EmitDefaultValue = false)]
        public string Code { get; set; }

        [DataMember(Name = "connected_account_id", IsRequired = true, EmitDefaultValue = false)]
        public string ConnectedAccountId { get; set; }

        [DataMember(Name = "created_at", IsRequired = true, EmitDefaultValue = false)]
        public string CreatedAt { get; set; }

        [DataMember(Name = "device_id", IsRequired = true, EmitDefaultValue = false)]
        public string DeviceId { get; set; }

        [DataMember(Name = "event_id", IsRequired = true, EmitDefaultValue = false)]
        public string EventId { get; set; }

        [DataMember(Name = "event_type", IsRequired = true, EmitDefaultValue = false)]
        public override string EventType { get; } = "access_code.set_on_device";

        [DataMember(Name = "occurred_at", IsRequired = true, EmitDefaultValue = false)]
        public string OccurredAt { get; set; }

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

    [DataContract(Name = "seamModel_eventAccessCodeRemovedFromDevice_model")]
    public class EventAccessCodeRemovedFromDevice : Event
    {
        [JsonConstructorAttribute]
        protected EventAccessCodeRemovedFromDevice() { }

        public EventAccessCodeRemovedFromDevice(
            string accessCodeId = default,
            string connectedAccountId = default,
            string createdAt = default,
            string deviceId = default,
            string eventId = default,
            string eventType = default,
            string occurredAt = default,
            string workspaceId = default
        )
        {
            AccessCodeId = accessCodeId;
            ConnectedAccountId = connectedAccountId;
            CreatedAt = createdAt;
            DeviceId = deviceId;
            EventId = eventId;
            EventType = eventType;
            OccurredAt = occurredAt;
            WorkspaceId = workspaceId;
        }

        [DataMember(Name = "access_code_id", IsRequired = true, EmitDefaultValue = false)]
        public string AccessCodeId { get; set; }

        [DataMember(Name = "connected_account_id", IsRequired = true, EmitDefaultValue = false)]
        public string ConnectedAccountId { get; set; }

        [DataMember(Name = "created_at", IsRequired = true, EmitDefaultValue = false)]
        public string CreatedAt { get; set; }

        [DataMember(Name = "device_id", IsRequired = true, EmitDefaultValue = false)]
        public string DeviceId { get; set; }

        [DataMember(Name = "event_id", IsRequired = true, EmitDefaultValue = false)]
        public string EventId { get; set; }

        [DataMember(Name = "event_type", IsRequired = true, EmitDefaultValue = false)]
        public override string EventType { get; } = "access_code.removed_from_device";

        [DataMember(Name = "occurred_at", IsRequired = true, EmitDefaultValue = false)]
        public string OccurredAt { get; set; }

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

    [DataContract(Name = "seamModel_eventAccessCodeDelayInSettingOnDevice_model")]
    public class EventAccessCodeDelayInSettingOnDevice : Event
    {
        [JsonConstructorAttribute]
        protected EventAccessCodeDelayInSettingOnDevice() { }

        public EventAccessCodeDelayInSettingOnDevice(
            string accessCodeId = default,
            string connectedAccountId = default,
            string createdAt = default,
            string deviceId = default,
            string eventId = default,
            string eventType = default,
            string occurredAt = default,
            string workspaceId = default
        )
        {
            AccessCodeId = accessCodeId;
            ConnectedAccountId = connectedAccountId;
            CreatedAt = createdAt;
            DeviceId = deviceId;
            EventId = eventId;
            EventType = eventType;
            OccurredAt = occurredAt;
            WorkspaceId = workspaceId;
        }

        [DataMember(Name = "access_code_id", IsRequired = true, EmitDefaultValue = false)]
        public string AccessCodeId { get; set; }

        [DataMember(Name = "connected_account_id", IsRequired = true, EmitDefaultValue = false)]
        public string ConnectedAccountId { get; set; }

        [DataMember(Name = "created_at", IsRequired = true, EmitDefaultValue = false)]
        public string CreatedAt { get; set; }

        [DataMember(Name = "device_id", IsRequired = true, EmitDefaultValue = false)]
        public string DeviceId { get; set; }

        [DataMember(Name = "event_id", IsRequired = true, EmitDefaultValue = false)]
        public string EventId { get; set; }

        [DataMember(Name = "event_type", IsRequired = true, EmitDefaultValue = false)]
        public override string EventType { get; } = "access_code.delay_in_setting_on_device";

        [DataMember(Name = "occurred_at", IsRequired = true, EmitDefaultValue = false)]
        public string OccurredAt { get; set; }

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

    [DataContract(Name = "seamModel_eventAccessCodeFailedToSetOnDevice_model")]
    public class EventAccessCodeFailedToSetOnDevice : Event
    {
        [JsonConstructorAttribute]
        protected EventAccessCodeFailedToSetOnDevice() { }

        public EventAccessCodeFailedToSetOnDevice(
            string accessCodeId = default,
            string connectedAccountId = default,
            string createdAt = default,
            string deviceId = default,
            string eventId = default,
            string eventType = default,
            string occurredAt = default,
            string workspaceId = default
        )
        {
            AccessCodeId = accessCodeId;
            ConnectedAccountId = connectedAccountId;
            CreatedAt = createdAt;
            DeviceId = deviceId;
            EventId = eventId;
            EventType = eventType;
            OccurredAt = occurredAt;
            WorkspaceId = workspaceId;
        }

        [DataMember(Name = "access_code_id", IsRequired = true, EmitDefaultValue = false)]
        public string AccessCodeId { get; set; }

        [DataMember(Name = "connected_account_id", IsRequired = true, EmitDefaultValue = false)]
        public string ConnectedAccountId { get; set; }

        [DataMember(Name = "created_at", IsRequired = true, EmitDefaultValue = false)]
        public string CreatedAt { get; set; }

        [DataMember(Name = "device_id", IsRequired = true, EmitDefaultValue = false)]
        public string DeviceId { get; set; }

        [DataMember(Name = "event_id", IsRequired = true, EmitDefaultValue = false)]
        public string EventId { get; set; }

        [DataMember(Name = "event_type", IsRequired = true, EmitDefaultValue = false)]
        public override string EventType { get; } = "access_code.failed_to_set_on_device";

        [DataMember(Name = "occurred_at", IsRequired = true, EmitDefaultValue = false)]
        public string OccurredAt { get; set; }

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

    [DataContract(Name = "seamModel_eventAccessCodeDeleted_model")]
    public class EventAccessCodeDeleted : Event
    {
        [JsonConstructorAttribute]
        protected EventAccessCodeDeleted() { }

        public EventAccessCodeDeleted(
            string accessCodeId = default,
            string? code = default,
            string connectedAccountId = default,
            string createdAt = default,
            string deviceId = default,
            string eventId = default,
            string eventType = default,
            string occurredAt = default,
            string workspaceId = default
        )
        {
            AccessCodeId = accessCodeId;
            Code = code;
            ConnectedAccountId = connectedAccountId;
            CreatedAt = createdAt;
            DeviceId = deviceId;
            EventId = eventId;
            EventType = eventType;
            OccurredAt = occurredAt;
            WorkspaceId = workspaceId;
        }

        [DataMember(Name = "access_code_id", IsRequired = true, EmitDefaultValue = false)]
        public string AccessCodeId { get; set; }

        [DataMember(Name = "code", IsRequired = false, EmitDefaultValue = false)]
        public string? Code { get; set; }

        [DataMember(Name = "connected_account_id", IsRequired = true, EmitDefaultValue = false)]
        public string ConnectedAccountId { get; set; }

        [DataMember(Name = "created_at", IsRequired = true, EmitDefaultValue = false)]
        public string CreatedAt { get; set; }

        [DataMember(Name = "device_id", IsRequired = true, EmitDefaultValue = false)]
        public string DeviceId { get; set; }

        [DataMember(Name = "event_id", IsRequired = true, EmitDefaultValue = false)]
        public string EventId { get; set; }

        [DataMember(Name = "event_type", IsRequired = true, EmitDefaultValue = false)]
        public override string EventType { get; } = "access_code.deleted";

        [DataMember(Name = "occurred_at", IsRequired = true, EmitDefaultValue = false)]
        public string OccurredAt { get; set; }

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

    [DataContract(Name = "seamModel_eventAccessCodeDelayInRemovingFromDevice_model")]
    public class EventAccessCodeDelayInRemovingFromDevice : Event
    {
        [JsonConstructorAttribute]
        protected EventAccessCodeDelayInRemovingFromDevice() { }

        public EventAccessCodeDelayInRemovingFromDevice(
            string accessCodeId = default,
            string connectedAccountId = default,
            string createdAt = default,
            string deviceId = default,
            string eventId = default,
            string eventType = default,
            string occurredAt = default,
            string workspaceId = default
        )
        {
            AccessCodeId = accessCodeId;
            ConnectedAccountId = connectedAccountId;
            CreatedAt = createdAt;
            DeviceId = deviceId;
            EventId = eventId;
            EventType = eventType;
            OccurredAt = occurredAt;
            WorkspaceId = workspaceId;
        }

        [DataMember(Name = "access_code_id", IsRequired = true, EmitDefaultValue = false)]
        public string AccessCodeId { get; set; }

        [DataMember(Name = "connected_account_id", IsRequired = true, EmitDefaultValue = false)]
        public string ConnectedAccountId { get; set; }

        [DataMember(Name = "created_at", IsRequired = true, EmitDefaultValue = false)]
        public string CreatedAt { get; set; }

        [DataMember(Name = "device_id", IsRequired = true, EmitDefaultValue = false)]
        public string DeviceId { get; set; }

        [DataMember(Name = "event_id", IsRequired = true, EmitDefaultValue = false)]
        public string EventId { get; set; }

        [DataMember(Name = "event_type", IsRequired = true, EmitDefaultValue = false)]
        public override string EventType { get; } = "access_code.delay_in_removing_from_device";

        [DataMember(Name = "occurred_at", IsRequired = true, EmitDefaultValue = false)]
        public string OccurredAt { get; set; }

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

    [DataContract(Name = "seamModel_eventAccessCodeFailedToRemoveFromDevice_model")]
    public class EventAccessCodeFailedToRemoveFromDevice : Event
    {
        [JsonConstructorAttribute]
        protected EventAccessCodeFailedToRemoveFromDevice() { }

        public EventAccessCodeFailedToRemoveFromDevice(
            string accessCodeId = default,
            string connectedAccountId = default,
            string createdAt = default,
            string deviceId = default,
            string eventId = default,
            string eventType = default,
            string occurredAt = default,
            string workspaceId = default
        )
        {
            AccessCodeId = accessCodeId;
            ConnectedAccountId = connectedAccountId;
            CreatedAt = createdAt;
            DeviceId = deviceId;
            EventId = eventId;
            EventType = eventType;
            OccurredAt = occurredAt;
            WorkspaceId = workspaceId;
        }

        [DataMember(Name = "access_code_id", IsRequired = true, EmitDefaultValue = false)]
        public string AccessCodeId { get; set; }

        [DataMember(Name = "connected_account_id", IsRequired = true, EmitDefaultValue = false)]
        public string ConnectedAccountId { get; set; }

        [DataMember(Name = "created_at", IsRequired = true, EmitDefaultValue = false)]
        public string CreatedAt { get; set; }

        [DataMember(Name = "device_id", IsRequired = true, EmitDefaultValue = false)]
        public string DeviceId { get; set; }

        [DataMember(Name = "event_id", IsRequired = true, EmitDefaultValue = false)]
        public string EventId { get; set; }

        [DataMember(Name = "event_type", IsRequired = true, EmitDefaultValue = false)]
        public override string EventType { get; } = "access_code.failed_to_remove_from_device";

        [DataMember(Name = "occurred_at", IsRequired = true, EmitDefaultValue = false)]
        public string OccurredAt { get; set; }

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

    [DataContract(Name = "seamModel_eventAccessCodeModifiedExternalToSeam_model")]
    public class EventAccessCodeModifiedExternalToSeam : Event
    {
        [JsonConstructorAttribute]
        protected EventAccessCodeModifiedExternalToSeam() { }

        public EventAccessCodeModifiedExternalToSeam(
            string accessCodeId = default,
            string connectedAccountId = default,
            string createdAt = default,
            string deviceId = default,
            string eventId = default,
            string eventType = default,
            string occurredAt = default,
            string workspaceId = default
        )
        {
            AccessCodeId = accessCodeId;
            ConnectedAccountId = connectedAccountId;
            CreatedAt = createdAt;
            DeviceId = deviceId;
            EventId = eventId;
            EventType = eventType;
            OccurredAt = occurredAt;
            WorkspaceId = workspaceId;
        }

        [DataMember(Name = "access_code_id", IsRequired = true, EmitDefaultValue = false)]
        public string AccessCodeId { get; set; }

        [DataMember(Name = "connected_account_id", IsRequired = true, EmitDefaultValue = false)]
        public string ConnectedAccountId { get; set; }

        [DataMember(Name = "created_at", IsRequired = true, EmitDefaultValue = false)]
        public string CreatedAt { get; set; }

        [DataMember(Name = "device_id", IsRequired = true, EmitDefaultValue = false)]
        public string DeviceId { get; set; }

        [DataMember(Name = "event_id", IsRequired = true, EmitDefaultValue = false)]
        public string EventId { get; set; }

        [DataMember(Name = "event_type", IsRequired = true, EmitDefaultValue = false)]
        public override string EventType { get; } = "access_code.modified_external_to_seam";

        [DataMember(Name = "occurred_at", IsRequired = true, EmitDefaultValue = false)]
        public string OccurredAt { get; set; }

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

    [DataContract(Name = "seamModel_eventAccessCodeDeletedExternalToSeam_model")]
    public class EventAccessCodeDeletedExternalToSeam : Event
    {
        [JsonConstructorAttribute]
        protected EventAccessCodeDeletedExternalToSeam() { }

        public EventAccessCodeDeletedExternalToSeam(
            string accessCodeId = default,
            string connectedAccountId = default,
            string createdAt = default,
            string deviceId = default,
            string eventId = default,
            string eventType = default,
            string occurredAt = default,
            string workspaceId = default
        )
        {
            AccessCodeId = accessCodeId;
            ConnectedAccountId = connectedAccountId;
            CreatedAt = createdAt;
            DeviceId = deviceId;
            EventId = eventId;
            EventType = eventType;
            OccurredAt = occurredAt;
            WorkspaceId = workspaceId;
        }

        [DataMember(Name = "access_code_id", IsRequired = true, EmitDefaultValue = false)]
        public string AccessCodeId { get; set; }

        [DataMember(Name = "connected_account_id", IsRequired = true, EmitDefaultValue = false)]
        public string ConnectedAccountId { get; set; }

        [DataMember(Name = "created_at", IsRequired = true, EmitDefaultValue = false)]
        public string CreatedAt { get; set; }

        [DataMember(Name = "device_id", IsRequired = true, EmitDefaultValue = false)]
        public string DeviceId { get; set; }

        [DataMember(Name = "event_id", IsRequired = true, EmitDefaultValue = false)]
        public string EventId { get; set; }

        [DataMember(Name = "event_type", IsRequired = true, EmitDefaultValue = false)]
        public override string EventType { get; } = "access_code.deleted_external_to_seam";

        [DataMember(Name = "occurred_at", IsRequired = true, EmitDefaultValue = false)]
        public string OccurredAt { get; set; }

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

    [DataContract(Name = "seamModel_eventAccessCodeBackupAccessCodePulled_model")]
    public class EventAccessCodeBackupAccessCodePulled : Event
    {
        [JsonConstructorAttribute]
        protected EventAccessCodeBackupAccessCodePulled() { }

        public EventAccessCodeBackupAccessCodePulled(
            string accessCodeId = default,
            string backupAccessCodeId = default,
            string connectedAccountId = default,
            string createdAt = default,
            string deviceId = default,
            string eventId = default,
            string eventType = default,
            string occurredAt = default,
            string workspaceId = default
        )
        {
            AccessCodeId = accessCodeId;
            BackupAccessCodeId = backupAccessCodeId;
            ConnectedAccountId = connectedAccountId;
            CreatedAt = createdAt;
            DeviceId = deviceId;
            EventId = eventId;
            EventType = eventType;
            OccurredAt = occurredAt;
            WorkspaceId = workspaceId;
        }

        [DataMember(Name = "access_code_id", IsRequired = true, EmitDefaultValue = false)]
        public string AccessCodeId { get; set; }

        [DataMember(Name = "backup_access_code_id", IsRequired = true, EmitDefaultValue = false)]
        public string BackupAccessCodeId { get; set; }

        [DataMember(Name = "connected_account_id", IsRequired = true, EmitDefaultValue = false)]
        public string ConnectedAccountId { get; set; }

        [DataMember(Name = "created_at", IsRequired = true, EmitDefaultValue = false)]
        public string CreatedAt { get; set; }

        [DataMember(Name = "device_id", IsRequired = true, EmitDefaultValue = false)]
        public string DeviceId { get; set; }

        [DataMember(Name = "event_id", IsRequired = true, EmitDefaultValue = false)]
        public string EventId { get; set; }

        [DataMember(Name = "event_type", IsRequired = true, EmitDefaultValue = false)]
        public override string EventType { get; } = "access_code.backup_access_code_pulled";

        [DataMember(Name = "occurred_at", IsRequired = true, EmitDefaultValue = false)]
        public string OccurredAt { get; set; }

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

    [DataContract(Name = "seamModel_eventAccessCodeUnmanagedConvertedToManaged_model")]
    public class EventAccessCodeUnmanagedConvertedToManaged : Event
    {
        [JsonConstructorAttribute]
        protected EventAccessCodeUnmanagedConvertedToManaged() { }

        public EventAccessCodeUnmanagedConvertedToManaged(
            string accessCodeId = default,
            string connectedAccountId = default,
            string createdAt = default,
            string deviceId = default,
            string eventId = default,
            string eventType = default,
            string occurredAt = default,
            string workspaceId = default
        )
        {
            AccessCodeId = accessCodeId;
            ConnectedAccountId = connectedAccountId;
            CreatedAt = createdAt;
            DeviceId = deviceId;
            EventId = eventId;
            EventType = eventType;
            OccurredAt = occurredAt;
            WorkspaceId = workspaceId;
        }

        [DataMember(Name = "access_code_id", IsRequired = true, EmitDefaultValue = false)]
        public string AccessCodeId { get; set; }

        [DataMember(Name = "connected_account_id", IsRequired = true, EmitDefaultValue = false)]
        public string ConnectedAccountId { get; set; }

        [DataMember(Name = "created_at", IsRequired = true, EmitDefaultValue = false)]
        public string CreatedAt { get; set; }

        [DataMember(Name = "device_id", IsRequired = true, EmitDefaultValue = false)]
        public string DeviceId { get; set; }

        [DataMember(Name = "event_id", IsRequired = true, EmitDefaultValue = false)]
        public string EventId { get; set; }

        [DataMember(Name = "event_type", IsRequired = true, EmitDefaultValue = false)]
        public override string EventType { get; } = "access_code.unmanaged.converted_to_managed";

        [DataMember(Name = "occurred_at", IsRequired = true, EmitDefaultValue = false)]
        public string OccurredAt { get; set; }

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

    [DataContract(Name = "seamModel_eventAccessCodeUnmanagedFailedToConvertToManaged_model")]
    public class EventAccessCodeUnmanagedFailedToConvertToManaged : Event
    {
        [JsonConstructorAttribute]
        protected EventAccessCodeUnmanagedFailedToConvertToManaged() { }

        public EventAccessCodeUnmanagedFailedToConvertToManaged(
            string accessCodeId = default,
            string connectedAccountId = default,
            string createdAt = default,
            string deviceId = default,
            string eventId = default,
            string eventType = default,
            string occurredAt = default,
            string workspaceId = default
        )
        {
            AccessCodeId = accessCodeId;
            ConnectedAccountId = connectedAccountId;
            CreatedAt = createdAt;
            DeviceId = deviceId;
            EventId = eventId;
            EventType = eventType;
            OccurredAt = occurredAt;
            WorkspaceId = workspaceId;
        }

        [DataMember(Name = "access_code_id", IsRequired = true, EmitDefaultValue = false)]
        public string AccessCodeId { get; set; }

        [DataMember(Name = "connected_account_id", IsRequired = true, EmitDefaultValue = false)]
        public string ConnectedAccountId { get; set; }

        [DataMember(Name = "created_at", IsRequired = true, EmitDefaultValue = false)]
        public string CreatedAt { get; set; }

        [DataMember(Name = "device_id", IsRequired = true, EmitDefaultValue = false)]
        public string DeviceId { get; set; }

        [DataMember(Name = "event_id", IsRequired = true, EmitDefaultValue = false)]
        public string EventId { get; set; }

        [DataMember(Name = "event_type", IsRequired = true, EmitDefaultValue = false)]
        public override string EventType { get; } =
            "access_code.unmanaged.failed_to_convert_to_managed";

        [DataMember(Name = "occurred_at", IsRequired = true, EmitDefaultValue = false)]
        public string OccurredAt { get; set; }

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

    [DataContract(Name = "seamModel_eventAccessCodeUnmanagedCreated_model")]
    public class EventAccessCodeUnmanagedCreated : Event
    {
        [JsonConstructorAttribute]
        protected EventAccessCodeUnmanagedCreated() { }

        public EventAccessCodeUnmanagedCreated(
            string accessCodeId = default,
            string connectedAccountId = default,
            string createdAt = default,
            string deviceId = default,
            string eventId = default,
            string eventType = default,
            string occurredAt = default,
            string workspaceId = default
        )
        {
            AccessCodeId = accessCodeId;
            ConnectedAccountId = connectedAccountId;
            CreatedAt = createdAt;
            DeviceId = deviceId;
            EventId = eventId;
            EventType = eventType;
            OccurredAt = occurredAt;
            WorkspaceId = workspaceId;
        }

        [DataMember(Name = "access_code_id", IsRequired = true, EmitDefaultValue = false)]
        public string AccessCodeId { get; set; }

        [DataMember(Name = "connected_account_id", IsRequired = true, EmitDefaultValue = false)]
        public string ConnectedAccountId { get; set; }

        [DataMember(Name = "created_at", IsRequired = true, EmitDefaultValue = false)]
        public string CreatedAt { get; set; }

        [DataMember(Name = "device_id", IsRequired = true, EmitDefaultValue = false)]
        public string DeviceId { get; set; }

        [DataMember(Name = "event_id", IsRequired = true, EmitDefaultValue = false)]
        public string EventId { get; set; }

        [DataMember(Name = "event_type", IsRequired = true, EmitDefaultValue = false)]
        public override string EventType { get; } = "access_code.unmanaged.created";

        [DataMember(Name = "occurred_at", IsRequired = true, EmitDefaultValue = false)]
        public string OccurredAt { get; set; }

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

    [DataContract(Name = "seamModel_eventAccessCodeUnmanagedRemoved_model")]
    public class EventAccessCodeUnmanagedRemoved : Event
    {
        [JsonConstructorAttribute]
        protected EventAccessCodeUnmanagedRemoved() { }

        public EventAccessCodeUnmanagedRemoved(
            string accessCodeId = default,
            string connectedAccountId = default,
            string createdAt = default,
            string deviceId = default,
            string eventId = default,
            string eventType = default,
            string occurredAt = default,
            string workspaceId = default
        )
        {
            AccessCodeId = accessCodeId;
            ConnectedAccountId = connectedAccountId;
            CreatedAt = createdAt;
            DeviceId = deviceId;
            EventId = eventId;
            EventType = eventType;
            OccurredAt = occurredAt;
            WorkspaceId = workspaceId;
        }

        [DataMember(Name = "access_code_id", IsRequired = true, EmitDefaultValue = false)]
        public string AccessCodeId { get; set; }

        [DataMember(Name = "connected_account_id", IsRequired = true, EmitDefaultValue = false)]
        public string ConnectedAccountId { get; set; }

        [DataMember(Name = "created_at", IsRequired = true, EmitDefaultValue = false)]
        public string CreatedAt { get; set; }

        [DataMember(Name = "device_id", IsRequired = true, EmitDefaultValue = false)]
        public string DeviceId { get; set; }

        [DataMember(Name = "event_id", IsRequired = true, EmitDefaultValue = false)]
        public string EventId { get; set; }

        [DataMember(Name = "event_type", IsRequired = true, EmitDefaultValue = false)]
        public override string EventType { get; } = "access_code.unmanaged.removed";

        [DataMember(Name = "occurred_at", IsRequired = true, EmitDefaultValue = false)]
        public string OccurredAt { get; set; }

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

    [DataContract(Name = "seamModel_eventAcsSystemConnected_model")]
    public class EventAcsSystemConnected : Event
    {
        [JsonConstructorAttribute]
        protected EventAcsSystemConnected() { }

        public EventAcsSystemConnected(
            string acsSystemId = default,
            string? connectedAccountId = default,
            string createdAt = default,
            string eventId = default,
            string eventType = default,
            string occurredAt = default,
            string workspaceId = default
        )
        {
            AcsSystemId = acsSystemId;
            ConnectedAccountId = connectedAccountId;
            CreatedAt = createdAt;
            EventId = eventId;
            EventType = eventType;
            OccurredAt = occurredAt;
            WorkspaceId = workspaceId;
        }

        [DataMember(Name = "acs_system_id", IsRequired = true, EmitDefaultValue = false)]
        public string AcsSystemId { get; set; }

        [DataMember(Name = "connected_account_id", IsRequired = false, EmitDefaultValue = false)]
        public string? ConnectedAccountId { get; set; }

        [DataMember(Name = "created_at", IsRequired = true, EmitDefaultValue = false)]
        public string CreatedAt { get; set; }

        [DataMember(Name = "event_id", IsRequired = true, EmitDefaultValue = false)]
        public string EventId { get; set; }

        [DataMember(Name = "event_type", IsRequired = true, EmitDefaultValue = false)]
        public override string EventType { get; } = "acs_system.connected";

        [DataMember(Name = "occurred_at", IsRequired = true, EmitDefaultValue = false)]
        public string OccurredAt { get; set; }

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

    [DataContract(Name = "seamModel_eventAcsSystemAdded_model")]
    public class EventAcsSystemAdded : Event
    {
        [JsonConstructorAttribute]
        protected EventAcsSystemAdded() { }

        public EventAcsSystemAdded(
            string acsSystemId = default,
            string? connectedAccountId = default,
            string createdAt = default,
            string eventId = default,
            string eventType = default,
            string occurredAt = default,
            string workspaceId = default
        )
        {
            AcsSystemId = acsSystemId;
            ConnectedAccountId = connectedAccountId;
            CreatedAt = createdAt;
            EventId = eventId;
            EventType = eventType;
            OccurredAt = occurredAt;
            WorkspaceId = workspaceId;
        }

        [DataMember(Name = "acs_system_id", IsRequired = true, EmitDefaultValue = false)]
        public string AcsSystemId { get; set; }

        [DataMember(Name = "connected_account_id", IsRequired = false, EmitDefaultValue = false)]
        public string? ConnectedAccountId { get; set; }

        [DataMember(Name = "created_at", IsRequired = true, EmitDefaultValue = false)]
        public string CreatedAt { get; set; }

        [DataMember(Name = "event_id", IsRequired = true, EmitDefaultValue = false)]
        public string EventId { get; set; }

        [DataMember(Name = "event_type", IsRequired = true, EmitDefaultValue = false)]
        public override string EventType { get; } = "acs_system.added";

        [DataMember(Name = "occurred_at", IsRequired = true, EmitDefaultValue = false)]
        public string OccurredAt { get; set; }

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

    [DataContract(Name = "seamModel_eventAcsSystemDisconnected_model")]
    public class EventAcsSystemDisconnected : Event
    {
        [JsonConstructorAttribute]
        protected EventAcsSystemDisconnected() { }

        public EventAcsSystemDisconnected(
            string acsSystemId = default,
            string? connectedAccountId = default,
            string createdAt = default,
            string eventId = default,
            string eventType = default,
            string occurredAt = default,
            string workspaceId = default
        )
        {
            AcsSystemId = acsSystemId;
            ConnectedAccountId = connectedAccountId;
            CreatedAt = createdAt;
            EventId = eventId;
            EventType = eventType;
            OccurredAt = occurredAt;
            WorkspaceId = workspaceId;
        }

        [DataMember(Name = "acs_system_id", IsRequired = true, EmitDefaultValue = false)]
        public string AcsSystemId { get; set; }

        [DataMember(Name = "connected_account_id", IsRequired = false, EmitDefaultValue = false)]
        public string? ConnectedAccountId { get; set; }

        [DataMember(Name = "created_at", IsRequired = true, EmitDefaultValue = false)]
        public string CreatedAt { get; set; }

        [DataMember(Name = "event_id", IsRequired = true, EmitDefaultValue = false)]
        public string EventId { get; set; }

        [DataMember(Name = "event_type", IsRequired = true, EmitDefaultValue = false)]
        public override string EventType { get; } = "acs_system.disconnected";

        [DataMember(Name = "occurred_at", IsRequired = true, EmitDefaultValue = false)]
        public string OccurredAt { get; set; }

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

    [DataContract(Name = "seamModel_eventAcsCredentialDeleted_model")]
    public class EventAcsCredentialDeleted : Event
    {
        [JsonConstructorAttribute]
        protected EventAcsCredentialDeleted() { }

        public EventAcsCredentialDeleted(
            string acsCredentialId = default,
            string acsSystemId = default,
            string? connectedAccountId = default,
            string createdAt = default,
            string eventId = default,
            string eventType = default,
            string occurredAt = default,
            string workspaceId = default
        )
        {
            AcsCredentialId = acsCredentialId;
            AcsSystemId = acsSystemId;
            ConnectedAccountId = connectedAccountId;
            CreatedAt = createdAt;
            EventId = eventId;
            EventType = eventType;
            OccurredAt = occurredAt;
            WorkspaceId = workspaceId;
        }

        [DataMember(Name = "acs_credential_id", IsRequired = true, EmitDefaultValue = false)]
        public string AcsCredentialId { get; set; }

        [DataMember(Name = "acs_system_id", IsRequired = true, EmitDefaultValue = false)]
        public string AcsSystemId { get; set; }

        [DataMember(Name = "connected_account_id", IsRequired = false, EmitDefaultValue = false)]
        public string? ConnectedAccountId { get; set; }

        [DataMember(Name = "created_at", IsRequired = true, EmitDefaultValue = false)]
        public string CreatedAt { get; set; }

        [DataMember(Name = "event_id", IsRequired = true, EmitDefaultValue = false)]
        public string EventId { get; set; }

        [DataMember(Name = "event_type", IsRequired = true, EmitDefaultValue = false)]
        public override string EventType { get; } = "acs_credential.deleted";

        [DataMember(Name = "occurred_at", IsRequired = true, EmitDefaultValue = false)]
        public string OccurredAt { get; set; }

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

    [DataContract(Name = "seamModel_eventAcsCredentialIssued_model")]
    public class EventAcsCredentialIssued : Event
    {
        [JsonConstructorAttribute]
        protected EventAcsCredentialIssued() { }

        public EventAcsCredentialIssued(
            string acsCredentialId = default,
            string acsSystemId = default,
            string? connectedAccountId = default,
            string createdAt = default,
            string eventId = default,
            string eventType = default,
            string occurredAt = default,
            string workspaceId = default
        )
        {
            AcsCredentialId = acsCredentialId;
            AcsSystemId = acsSystemId;
            ConnectedAccountId = connectedAccountId;
            CreatedAt = createdAt;
            EventId = eventId;
            EventType = eventType;
            OccurredAt = occurredAt;
            WorkspaceId = workspaceId;
        }

        [DataMember(Name = "acs_credential_id", IsRequired = true, EmitDefaultValue = false)]
        public string AcsCredentialId { get; set; }

        [DataMember(Name = "acs_system_id", IsRequired = true, EmitDefaultValue = false)]
        public string AcsSystemId { get; set; }

        [DataMember(Name = "connected_account_id", IsRequired = false, EmitDefaultValue = false)]
        public string? ConnectedAccountId { get; set; }

        [DataMember(Name = "created_at", IsRequired = true, EmitDefaultValue = false)]
        public string CreatedAt { get; set; }

        [DataMember(Name = "event_id", IsRequired = true, EmitDefaultValue = false)]
        public string EventId { get; set; }

        [DataMember(Name = "event_type", IsRequired = true, EmitDefaultValue = false)]
        public override string EventType { get; } = "acs_credential.issued";

        [DataMember(Name = "occurred_at", IsRequired = true, EmitDefaultValue = false)]
        public string OccurredAt { get; set; }

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

    [DataContract(Name = "seamModel_eventAcsUserDeleted_model")]
    public class EventAcsUserDeleted : Event
    {
        [JsonConstructorAttribute]
        protected EventAcsUserDeleted() { }

        public EventAcsUserDeleted(
            string acsSystemId = default,
            string acsUserId = default,
            string? connectedAccountId = default,
            string createdAt = default,
            string eventId = default,
            string eventType = default,
            string occurredAt = default,
            string workspaceId = default
        )
        {
            AcsSystemId = acsSystemId;
            AcsUserId = acsUserId;
            ConnectedAccountId = connectedAccountId;
            CreatedAt = createdAt;
            EventId = eventId;
            EventType = eventType;
            OccurredAt = occurredAt;
            WorkspaceId = workspaceId;
        }

        [DataMember(Name = "acs_system_id", IsRequired = true, EmitDefaultValue = false)]
        public string AcsSystemId { get; set; }

        [DataMember(Name = "acs_user_id", IsRequired = true, EmitDefaultValue = false)]
        public string AcsUserId { get; set; }

        [DataMember(Name = "connected_account_id", IsRequired = false, EmitDefaultValue = false)]
        public string? ConnectedAccountId { get; set; }

        [DataMember(Name = "created_at", IsRequired = true, EmitDefaultValue = false)]
        public string CreatedAt { get; set; }

        [DataMember(Name = "event_id", IsRequired = true, EmitDefaultValue = false)]
        public string EventId { get; set; }

        [DataMember(Name = "event_type", IsRequired = true, EmitDefaultValue = false)]
        public override string EventType { get; } = "acs_user.deleted";

        [DataMember(Name = "occurred_at", IsRequired = true, EmitDefaultValue = false)]
        public string OccurredAt { get; set; }

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

    [DataContract(Name = "seamModel_eventAcsEncoderAdded_model")]
    public class EventAcsEncoderAdded : Event
    {
        [JsonConstructorAttribute]
        protected EventAcsEncoderAdded() { }

        public EventAcsEncoderAdded(
            string acsEncoderId = default,
            string acsSystemId = default,
            string? connectedAccountId = default,
            string createdAt = default,
            string eventId = default,
            string eventType = default,
            string occurredAt = default,
            string workspaceId = default
        )
        {
            AcsEncoderId = acsEncoderId;
            AcsSystemId = acsSystemId;
            ConnectedAccountId = connectedAccountId;
            CreatedAt = createdAt;
            EventId = eventId;
            EventType = eventType;
            OccurredAt = occurredAt;
            WorkspaceId = workspaceId;
        }

        [DataMember(Name = "acs_encoder_id", IsRequired = true, EmitDefaultValue = false)]
        public string AcsEncoderId { get; set; }

        [DataMember(Name = "acs_system_id", IsRequired = true, EmitDefaultValue = false)]
        public string AcsSystemId { get; set; }

        [DataMember(Name = "connected_account_id", IsRequired = false, EmitDefaultValue = false)]
        public string? ConnectedAccountId { get; set; }

        [DataMember(Name = "created_at", IsRequired = true, EmitDefaultValue = false)]
        public string CreatedAt { get; set; }

        [DataMember(Name = "event_id", IsRequired = true, EmitDefaultValue = false)]
        public string EventId { get; set; }

        [DataMember(Name = "event_type", IsRequired = true, EmitDefaultValue = false)]
        public override string EventType { get; } = "acs_encoder.added";

        [DataMember(Name = "occurred_at", IsRequired = true, EmitDefaultValue = false)]
        public string OccurredAt { get; set; }

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

    [DataContract(Name = "seamModel_eventAcsEncoderRemoved_model")]
    public class EventAcsEncoderRemoved : Event
    {
        [JsonConstructorAttribute]
        protected EventAcsEncoderRemoved() { }

        public EventAcsEncoderRemoved(
            string acsEncoderId = default,
            string acsSystemId = default,
            string? connectedAccountId = default,
            string createdAt = default,
            string eventId = default,
            string eventType = default,
            string occurredAt = default,
            string workspaceId = default
        )
        {
            AcsEncoderId = acsEncoderId;
            AcsSystemId = acsSystemId;
            ConnectedAccountId = connectedAccountId;
            CreatedAt = createdAt;
            EventId = eventId;
            EventType = eventType;
            OccurredAt = occurredAt;
            WorkspaceId = workspaceId;
        }

        [DataMember(Name = "acs_encoder_id", IsRequired = true, EmitDefaultValue = false)]
        public string AcsEncoderId { get; set; }

        [DataMember(Name = "acs_system_id", IsRequired = true, EmitDefaultValue = false)]
        public string AcsSystemId { get; set; }

        [DataMember(Name = "connected_account_id", IsRequired = false, EmitDefaultValue = false)]
        public string? ConnectedAccountId { get; set; }

        [DataMember(Name = "created_at", IsRequired = true, EmitDefaultValue = false)]
        public string CreatedAt { get; set; }

        [DataMember(Name = "event_id", IsRequired = true, EmitDefaultValue = false)]
        public string EventId { get; set; }

        [DataMember(Name = "event_type", IsRequired = true, EmitDefaultValue = false)]
        public override string EventType { get; } = "acs_encoder.removed";

        [DataMember(Name = "occurred_at", IsRequired = true, EmitDefaultValue = false)]
        public string OccurredAt { get; set; }

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

    [DataContract(Name = "seamModel_eventClientSessionDeleted_model")]
    public class EventClientSessionDeleted : Event
    {
        [JsonConstructorAttribute]
        protected EventClientSessionDeleted() { }

        public EventClientSessionDeleted(
            string clientSessionId = default,
            string createdAt = default,
            string eventId = default,
            string eventType = default,
            string occurredAt = default,
            string workspaceId = default
        )
        {
            ClientSessionId = clientSessionId;
            CreatedAt = createdAt;
            EventId = eventId;
            EventType = eventType;
            OccurredAt = occurredAt;
            WorkspaceId = workspaceId;
        }

        [DataMember(Name = "client_session_id", IsRequired = true, EmitDefaultValue = false)]
        public string ClientSessionId { get; set; }

        [DataMember(Name = "created_at", IsRequired = true, EmitDefaultValue = false)]
        public string CreatedAt { get; set; }

        [DataMember(Name = "event_id", IsRequired = true, EmitDefaultValue = false)]
        public string EventId { get; set; }

        [DataMember(Name = "event_type", IsRequired = true, EmitDefaultValue = false)]
        public override string EventType { get; } = "client_session.deleted";

        [DataMember(Name = "occurred_at", IsRequired = true, EmitDefaultValue = false)]
        public string OccurredAt { get; set; }

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

    [DataContract(Name = "seamModel_eventConnectedAccountConnected_model")]
    public class EventConnectedAccountConnected : Event
    {
        [JsonConstructorAttribute]
        protected EventConnectedAccountConnected() { }

        public EventConnectedAccountConnected(
            string connectWebviewId = default,
            string connectedAccountId = default,
            string createdAt = default,
            string eventId = default,
            string eventType = default,
            string occurredAt = default,
            string workspaceId = default
        )
        {
            ConnectWebviewId = connectWebviewId;
            ConnectedAccountId = connectedAccountId;
            CreatedAt = createdAt;
            EventId = eventId;
            EventType = eventType;
            OccurredAt = occurredAt;
            WorkspaceId = workspaceId;
        }

        [DataMember(Name = "connect_webview_id", IsRequired = true, EmitDefaultValue = false)]
        public string ConnectWebviewId { get; set; }

        [DataMember(Name = "connected_account_id", IsRequired = true, EmitDefaultValue = false)]
        public string ConnectedAccountId { get; set; }

        [DataMember(Name = "created_at", IsRequired = true, EmitDefaultValue = false)]
        public string CreatedAt { get; set; }

        [DataMember(Name = "event_id", IsRequired = true, EmitDefaultValue = false)]
        public string EventId { get; set; }

        [DataMember(Name = "event_type", IsRequired = true, EmitDefaultValue = false)]
        public override string EventType { get; } = "connected_account.connected";

        [DataMember(Name = "occurred_at", IsRequired = true, EmitDefaultValue = false)]
        public string OccurredAt { get; set; }

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

    [DataContract(Name = "seamModel_eventConnectedAccountCreated_model")]
    public class EventConnectedAccountCreated : Event
    {
        [JsonConstructorAttribute]
        protected EventConnectedAccountCreated() { }

        public EventConnectedAccountCreated(
            string connectWebviewId = default,
            string connectedAccountId = default,
            string createdAt = default,
            string eventId = default,
            string eventType = default,
            string occurredAt = default,
            string workspaceId = default
        )
        {
            ConnectWebviewId = connectWebviewId;
            ConnectedAccountId = connectedAccountId;
            CreatedAt = createdAt;
            EventId = eventId;
            EventType = eventType;
            OccurredAt = occurredAt;
            WorkspaceId = workspaceId;
        }

        [DataMember(Name = "connect_webview_id", IsRequired = true, EmitDefaultValue = false)]
        public string ConnectWebviewId { get; set; }

        [DataMember(Name = "connected_account_id", IsRequired = true, EmitDefaultValue = false)]
        public string ConnectedAccountId { get; set; }

        [DataMember(Name = "created_at", IsRequired = true, EmitDefaultValue = false)]
        public string CreatedAt { get; set; }

        [DataMember(Name = "event_id", IsRequired = true, EmitDefaultValue = false)]
        public string EventId { get; set; }

        [DataMember(Name = "event_type", IsRequired = true, EmitDefaultValue = false)]
        public override string EventType { get; } = "connected_account.created";

        [DataMember(Name = "occurred_at", IsRequired = true, EmitDefaultValue = false)]
        public string OccurredAt { get; set; }

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

    [DataContract(Name = "seamModel_eventConnectedAccountSuccessfulLogin_model")]
    public class EventConnectedAccountSuccessfulLogin : Event
    {
        [JsonConstructorAttribute]
        protected EventConnectedAccountSuccessfulLogin() { }

        public EventConnectedAccountSuccessfulLogin(
            string connectWebviewId = default,
            string connectedAccountId = default,
            string createdAt = default,
            string eventId = default,
            string eventType = default,
            string occurredAt = default,
            string workspaceId = default
        )
        {
            ConnectWebviewId = connectWebviewId;
            ConnectedAccountId = connectedAccountId;
            CreatedAt = createdAt;
            EventId = eventId;
            EventType = eventType;
            OccurredAt = occurredAt;
            WorkspaceId = workspaceId;
        }

        [DataMember(Name = "connect_webview_id", IsRequired = true, EmitDefaultValue = false)]
        public string ConnectWebviewId { get; set; }

        [DataMember(Name = "connected_account_id", IsRequired = true, EmitDefaultValue = false)]
        public string ConnectedAccountId { get; set; }

        [DataMember(Name = "created_at", IsRequired = true, EmitDefaultValue = false)]
        public string CreatedAt { get; set; }

        [DataMember(Name = "event_id", IsRequired = true, EmitDefaultValue = false)]
        public string EventId { get; set; }

        [DataMember(Name = "event_type", IsRequired = true, EmitDefaultValue = false)]
        public override string EventType { get; } = "connected_account.successful_login";

        [DataMember(Name = "occurred_at", IsRequired = true, EmitDefaultValue = false)]
        public string OccurredAt { get; set; }

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

    [DataContract(Name = "seamModel_eventConnectedAccountDisconnected_model")]
    public class EventConnectedAccountDisconnected : Event
    {
        [JsonConstructorAttribute]
        protected EventConnectedAccountDisconnected() { }

        public EventConnectedAccountDisconnected(
            string connectedAccountId = default,
            string createdAt = default,
            string eventId = default,
            string eventType = default,
            string occurredAt = default,
            string workspaceId = default
        )
        {
            ConnectedAccountId = connectedAccountId;
            CreatedAt = createdAt;
            EventId = eventId;
            EventType = eventType;
            OccurredAt = occurredAt;
            WorkspaceId = workspaceId;
        }

        [DataMember(Name = "connected_account_id", IsRequired = true, EmitDefaultValue = false)]
        public string ConnectedAccountId { get; set; }

        [DataMember(Name = "created_at", IsRequired = true, EmitDefaultValue = false)]
        public string CreatedAt { get; set; }

        [DataMember(Name = "event_id", IsRequired = true, EmitDefaultValue = false)]
        public string EventId { get; set; }

        [DataMember(Name = "event_type", IsRequired = true, EmitDefaultValue = false)]
        public override string EventType { get; } = "connected_account.disconnected";

        [DataMember(Name = "occurred_at", IsRequired = true, EmitDefaultValue = false)]
        public string OccurredAt { get; set; }

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

    [DataContract(Name = "seamModel_eventConnectedAccountCompletedFirstSync_model")]
    public class EventConnectedAccountCompletedFirstSync : Event
    {
        [JsonConstructorAttribute]
        protected EventConnectedAccountCompletedFirstSync() { }

        public EventConnectedAccountCompletedFirstSync(
            string connectedAccountId = default,
            string createdAt = default,
            string eventId = default,
            string eventType = default,
            string occurredAt = default,
            string workspaceId = default
        )
        {
            ConnectedAccountId = connectedAccountId;
            CreatedAt = createdAt;
            EventId = eventId;
            EventType = eventType;
            OccurredAt = occurredAt;
            WorkspaceId = workspaceId;
        }

        [DataMember(Name = "connected_account_id", IsRequired = true, EmitDefaultValue = false)]
        public string ConnectedAccountId { get; set; }

        [DataMember(Name = "created_at", IsRequired = true, EmitDefaultValue = false)]
        public string CreatedAt { get; set; }

        [DataMember(Name = "event_id", IsRequired = true, EmitDefaultValue = false)]
        public string EventId { get; set; }

        [DataMember(Name = "event_type", IsRequired = true, EmitDefaultValue = false)]
        public override string EventType { get; } = "connected_account.completed_first_sync";

        [DataMember(Name = "occurred_at", IsRequired = true, EmitDefaultValue = false)]
        public string OccurredAt { get; set; }

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

    [DataContract(Name = "seamModel_eventConnectedAccountDeleted_model")]
    public class EventConnectedAccountDeleted : Event
    {
        [JsonConstructorAttribute]
        protected EventConnectedAccountDeleted() { }

        public EventConnectedAccountDeleted(
            string connectedAccountId = default,
            string createdAt = default,
            string eventId = default,
            string eventType = default,
            string occurredAt = default,
            string workspaceId = default
        )
        {
            ConnectedAccountId = connectedAccountId;
            CreatedAt = createdAt;
            EventId = eventId;
            EventType = eventType;
            OccurredAt = occurredAt;
            WorkspaceId = workspaceId;
        }

        [DataMember(Name = "connected_account_id", IsRequired = true, EmitDefaultValue = false)]
        public string ConnectedAccountId { get; set; }

        [DataMember(Name = "created_at", IsRequired = true, EmitDefaultValue = false)]
        public string CreatedAt { get; set; }

        [DataMember(Name = "event_id", IsRequired = true, EmitDefaultValue = false)]
        public string EventId { get; set; }

        [DataMember(Name = "event_type", IsRequired = true, EmitDefaultValue = false)]
        public override string EventType { get; } = "connected_account.deleted";

        [DataMember(Name = "occurred_at", IsRequired = true, EmitDefaultValue = false)]
        public string OccurredAt { get; set; }

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

    [DataContract(
        Name = "seamModel_eventConnectedAccountCompletedFirstSyncAfterReconnection_model"
    )]
    public class EventConnectedAccountCompletedFirstSyncAfterReconnection : Event
    {
        [JsonConstructorAttribute]
        protected EventConnectedAccountCompletedFirstSyncAfterReconnection() { }

        public EventConnectedAccountCompletedFirstSyncAfterReconnection(
            string connectedAccountId = default,
            string createdAt = default,
            string eventId = default,
            string eventType = default,
            string occurredAt = default,
            string workspaceId = default
        )
        {
            ConnectedAccountId = connectedAccountId;
            CreatedAt = createdAt;
            EventId = eventId;
            EventType = eventType;
            OccurredAt = occurredAt;
            WorkspaceId = workspaceId;
        }

        [DataMember(Name = "connected_account_id", IsRequired = true, EmitDefaultValue = false)]
        public string ConnectedAccountId { get; set; }

        [DataMember(Name = "created_at", IsRequired = true, EmitDefaultValue = false)]
        public string CreatedAt { get; set; }

        [DataMember(Name = "event_id", IsRequired = true, EmitDefaultValue = false)]
        public string EventId { get; set; }

        [DataMember(Name = "event_type", IsRequired = true, EmitDefaultValue = false)]
        public override string EventType { get; } =
            "connected_account.completed_first_sync_after_reconnection";

        [DataMember(Name = "occurred_at", IsRequired = true, EmitDefaultValue = false)]
        public string OccurredAt { get; set; }

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

    [DataContract(Name = "seamModel_eventActionAttemptLockDoorSucceeded_model")]
    public class EventActionAttemptLockDoorSucceeded : Event
    {
        [JsonConstructorAttribute]
        protected EventActionAttemptLockDoorSucceeded() { }

        public EventActionAttemptLockDoorSucceeded(
            string actionAttemptId = default,
            string actionType = default,
            string createdAt = default,
            string eventId = default,
            string eventType = default,
            string occurredAt = default,
            string status = default,
            string workspaceId = default
        )
        {
            ActionAttemptId = actionAttemptId;
            ActionType = actionType;
            CreatedAt = createdAt;
            EventId = eventId;
            EventType = eventType;
            OccurredAt = occurredAt;
            Status = status;
            WorkspaceId = workspaceId;
        }

        [DataMember(Name = "action_attempt_id", IsRequired = true, EmitDefaultValue = false)]
        public string ActionAttemptId { get; set; }

        [DataMember(Name = "action_type", IsRequired = true, EmitDefaultValue = false)]
        public string ActionType { get; set; }

        [DataMember(Name = "created_at", IsRequired = true, EmitDefaultValue = false)]
        public string CreatedAt { get; set; }

        [DataMember(Name = "event_id", IsRequired = true, EmitDefaultValue = false)]
        public string EventId { get; set; }

        [DataMember(Name = "event_type", IsRequired = true, EmitDefaultValue = false)]
        public override string EventType { get; } = "action_attempt.lock_door.succeeded";

        [DataMember(Name = "occurred_at", IsRequired = true, EmitDefaultValue = false)]
        public string OccurredAt { get; set; }

        [DataMember(Name = "status", IsRequired = true, EmitDefaultValue = false)]
        public string Status { get; set; }

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

    [DataContract(Name = "seamModel_eventActionAttemptLockDoorFailed_model")]
    public class EventActionAttemptLockDoorFailed : Event
    {
        [JsonConstructorAttribute]
        protected EventActionAttemptLockDoorFailed() { }

        public EventActionAttemptLockDoorFailed(
            string actionAttemptId = default,
            string actionType = default,
            string createdAt = default,
            string eventId = default,
            string eventType = default,
            string occurredAt = default,
            string status = default,
            string workspaceId = default
        )
        {
            ActionAttemptId = actionAttemptId;
            ActionType = actionType;
            CreatedAt = createdAt;
            EventId = eventId;
            EventType = eventType;
            OccurredAt = occurredAt;
            Status = status;
            WorkspaceId = workspaceId;
        }

        [DataMember(Name = "action_attempt_id", IsRequired = true, EmitDefaultValue = false)]
        public string ActionAttemptId { get; set; }

        [DataMember(Name = "action_type", IsRequired = true, EmitDefaultValue = false)]
        public string ActionType { get; set; }

        [DataMember(Name = "created_at", IsRequired = true, EmitDefaultValue = false)]
        public string CreatedAt { get; set; }

        [DataMember(Name = "event_id", IsRequired = true, EmitDefaultValue = false)]
        public string EventId { get; set; }

        [DataMember(Name = "event_type", IsRequired = true, EmitDefaultValue = false)]
        public override string EventType { get; } = "action_attempt.lock_door.failed";

        [DataMember(Name = "occurred_at", IsRequired = true, EmitDefaultValue = false)]
        public string OccurredAt { get; set; }

        [DataMember(Name = "status", IsRequired = true, EmitDefaultValue = false)]
        public string Status { get; set; }

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

    [DataContract(Name = "seamModel_eventActionAttemptUnlockDoorSucceeded_model")]
    public class EventActionAttemptUnlockDoorSucceeded : Event
    {
        [JsonConstructorAttribute]
        protected EventActionAttemptUnlockDoorSucceeded() { }

        public EventActionAttemptUnlockDoorSucceeded(
            string actionAttemptId = default,
            string actionType = default,
            string createdAt = default,
            string eventId = default,
            string eventType = default,
            string occurredAt = default,
            string status = default,
            string workspaceId = default
        )
        {
            ActionAttemptId = actionAttemptId;
            ActionType = actionType;
            CreatedAt = createdAt;
            EventId = eventId;
            EventType = eventType;
            OccurredAt = occurredAt;
            Status = status;
            WorkspaceId = workspaceId;
        }

        [DataMember(Name = "action_attempt_id", IsRequired = true, EmitDefaultValue = false)]
        public string ActionAttemptId { get; set; }

        [DataMember(Name = "action_type", IsRequired = true, EmitDefaultValue = false)]
        public string ActionType { get; set; }

        [DataMember(Name = "created_at", IsRequired = true, EmitDefaultValue = false)]
        public string CreatedAt { get; set; }

        [DataMember(Name = "event_id", IsRequired = true, EmitDefaultValue = false)]
        public string EventId { get; set; }

        [DataMember(Name = "event_type", IsRequired = true, EmitDefaultValue = false)]
        public override string EventType { get; } = "action_attempt.unlock_door.succeeded";

        [DataMember(Name = "occurred_at", IsRequired = true, EmitDefaultValue = false)]
        public string OccurredAt { get; set; }

        [DataMember(Name = "status", IsRequired = true, EmitDefaultValue = false)]
        public string Status { get; set; }

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

    [DataContract(Name = "seamModel_eventActionAttemptUnlockDoorFailed_model")]
    public class EventActionAttemptUnlockDoorFailed : Event
    {
        [JsonConstructorAttribute]
        protected EventActionAttemptUnlockDoorFailed() { }

        public EventActionAttemptUnlockDoorFailed(
            string actionAttemptId = default,
            string actionType = default,
            string createdAt = default,
            string eventId = default,
            string eventType = default,
            string occurredAt = default,
            string status = default,
            string workspaceId = default
        )
        {
            ActionAttemptId = actionAttemptId;
            ActionType = actionType;
            CreatedAt = createdAt;
            EventId = eventId;
            EventType = eventType;
            OccurredAt = occurredAt;
            Status = status;
            WorkspaceId = workspaceId;
        }

        [DataMember(Name = "action_attempt_id", IsRequired = true, EmitDefaultValue = false)]
        public string ActionAttemptId { get; set; }

        [DataMember(Name = "action_type", IsRequired = true, EmitDefaultValue = false)]
        public string ActionType { get; set; }

        [DataMember(Name = "created_at", IsRequired = true, EmitDefaultValue = false)]
        public string CreatedAt { get; set; }

        [DataMember(Name = "event_id", IsRequired = true, EmitDefaultValue = false)]
        public string EventId { get; set; }

        [DataMember(Name = "event_type", IsRequired = true, EmitDefaultValue = false)]
        public override string EventType { get; } = "action_attempt.unlock_door.failed";

        [DataMember(Name = "occurred_at", IsRequired = true, EmitDefaultValue = false)]
        public string OccurredAt { get; set; }

        [DataMember(Name = "status", IsRequired = true, EmitDefaultValue = false)]
        public string Status { get; set; }

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

    [DataContract(Name = "seamModel_eventConnectWebviewLoginSucceeded_model")]
    public class EventConnectWebviewLoginSucceeded : Event
    {
        [JsonConstructorAttribute]
        protected EventConnectWebviewLoginSucceeded() { }

        public EventConnectWebviewLoginSucceeded(
            string connectWebviewId = default,
            string connectedAccountId = default,
            string createdAt = default,
            string eventId = default,
            string eventType = default,
            string occurredAt = default,
            string workspaceId = default
        )
        {
            ConnectWebviewId = connectWebviewId;
            ConnectedAccountId = connectedAccountId;
            CreatedAt = createdAt;
            EventId = eventId;
            EventType = eventType;
            OccurredAt = occurredAt;
            WorkspaceId = workspaceId;
        }

        [DataMember(Name = "connect_webview_id", IsRequired = true, EmitDefaultValue = false)]
        public string ConnectWebviewId { get; set; }

        [DataMember(Name = "connected_account_id", IsRequired = true, EmitDefaultValue = false)]
        public string ConnectedAccountId { get; set; }

        [DataMember(Name = "created_at", IsRequired = true, EmitDefaultValue = false)]
        public string CreatedAt { get; set; }

        [DataMember(Name = "event_id", IsRequired = true, EmitDefaultValue = false)]
        public string EventId { get; set; }

        [DataMember(Name = "event_type", IsRequired = true, EmitDefaultValue = false)]
        public override string EventType { get; } = "connect_webview.login_succeeded";

        [DataMember(Name = "occurred_at", IsRequired = true, EmitDefaultValue = false)]
        public string OccurredAt { get; set; }

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

    [DataContract(Name = "seamModel_eventConnectWebviewLoginFailed_model")]
    public class EventConnectWebviewLoginFailed : Event
    {
        [JsonConstructorAttribute]
        protected EventConnectWebviewLoginFailed() { }

        public EventConnectWebviewLoginFailed(
            string connectWebviewId = default,
            string createdAt = default,
            string eventId = default,
            string eventType = default,
            string occurredAt = default,
            string workspaceId = default
        )
        {
            ConnectWebviewId = connectWebviewId;
            CreatedAt = createdAt;
            EventId = eventId;
            EventType = eventType;
            OccurredAt = occurredAt;
            WorkspaceId = workspaceId;
        }

        [DataMember(Name = "connect_webview_id", IsRequired = true, EmitDefaultValue = false)]
        public string ConnectWebviewId { get; set; }

        [DataMember(Name = "created_at", IsRequired = true, EmitDefaultValue = false)]
        public string CreatedAt { get; set; }

        [DataMember(Name = "event_id", IsRequired = true, EmitDefaultValue = false)]
        public string EventId { get; set; }

        [DataMember(Name = "event_type", IsRequired = true, EmitDefaultValue = false)]
        public override string EventType { get; } = "connect_webview.login_failed";

        [DataMember(Name = "occurred_at", IsRequired = true, EmitDefaultValue = false)]
        public string OccurredAt { get; set; }

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

    [DataContract(Name = "seamModel_eventDeviceConnected_model")]
    public class EventDeviceConnected : Event
    {
        [JsonConstructorAttribute]
        protected EventDeviceConnected() { }

        public EventDeviceConnected(
            string connectedAccountId = default,
            string createdAt = default,
            string deviceId = default,
            string eventId = default,
            string eventType = default,
            string occurredAt = default,
            string workspaceId = default
        )
        {
            ConnectedAccountId = connectedAccountId;
            CreatedAt = createdAt;
            DeviceId = deviceId;
            EventId = eventId;
            EventType = eventType;
            OccurredAt = occurredAt;
            WorkspaceId = workspaceId;
        }

        [DataMember(Name = "connected_account_id", IsRequired = true, EmitDefaultValue = false)]
        public string ConnectedAccountId { get; set; }

        [DataMember(Name = "created_at", IsRequired = true, EmitDefaultValue = false)]
        public string CreatedAt { get; set; }

        [DataMember(Name = "device_id", IsRequired = true, EmitDefaultValue = false)]
        public string DeviceId { get; set; }

        [DataMember(Name = "event_id", IsRequired = true, EmitDefaultValue = false)]
        public string EventId { get; set; }

        [DataMember(Name = "event_type", IsRequired = true, EmitDefaultValue = false)]
        public override string EventType { get; } = "device.connected";

        [DataMember(Name = "occurred_at", IsRequired = true, EmitDefaultValue = false)]
        public string OccurredAt { get; set; }

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

    [DataContract(Name = "seamModel_eventDeviceAdded_model")]
    public class EventDeviceAdded : Event
    {
        [JsonConstructorAttribute]
        protected EventDeviceAdded() { }

        public EventDeviceAdded(
            string connectedAccountId = default,
            string createdAt = default,
            string deviceId = default,
            string eventId = default,
            string eventType = default,
            string occurredAt = default,
            string workspaceId = default
        )
        {
            ConnectedAccountId = connectedAccountId;
            CreatedAt = createdAt;
            DeviceId = deviceId;
            EventId = eventId;
            EventType = eventType;
            OccurredAt = occurredAt;
            WorkspaceId = workspaceId;
        }

        [DataMember(Name = "connected_account_id", IsRequired = true, EmitDefaultValue = false)]
        public string ConnectedAccountId { get; set; }

        [DataMember(Name = "created_at", IsRequired = true, EmitDefaultValue = false)]
        public string CreatedAt { get; set; }

        [DataMember(Name = "device_id", IsRequired = true, EmitDefaultValue = false)]
        public string DeviceId { get; set; }

        [DataMember(Name = "event_id", IsRequired = true, EmitDefaultValue = false)]
        public string EventId { get; set; }

        [DataMember(Name = "event_type", IsRequired = true, EmitDefaultValue = false)]
        public override string EventType { get; } = "device.added";

        [DataMember(Name = "occurred_at", IsRequired = true, EmitDefaultValue = false)]
        public string OccurredAt { get; set; }

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

    [DataContract(Name = "seamModel_eventDeviceConvertedToUnmanaged_model")]
    public class EventDeviceConvertedToUnmanaged : Event
    {
        [JsonConstructorAttribute]
        protected EventDeviceConvertedToUnmanaged() { }

        public EventDeviceConvertedToUnmanaged(
            string connectedAccountId = default,
            string createdAt = default,
            string deviceId = default,
            string eventId = default,
            string eventType = default,
            string occurredAt = default,
            string workspaceId = default
        )
        {
            ConnectedAccountId = connectedAccountId;
            CreatedAt = createdAt;
            DeviceId = deviceId;
            EventId = eventId;
            EventType = eventType;
            OccurredAt = occurredAt;
            WorkspaceId = workspaceId;
        }

        [DataMember(Name = "connected_account_id", IsRequired = true, EmitDefaultValue = false)]
        public string ConnectedAccountId { get; set; }

        [DataMember(Name = "created_at", IsRequired = true, EmitDefaultValue = false)]
        public string CreatedAt { get; set; }

        [DataMember(Name = "device_id", IsRequired = true, EmitDefaultValue = false)]
        public string DeviceId { get; set; }

        [DataMember(Name = "event_id", IsRequired = true, EmitDefaultValue = false)]
        public string EventId { get; set; }

        [DataMember(Name = "event_type", IsRequired = true, EmitDefaultValue = false)]
        public override string EventType { get; } = "device.converted_to_unmanaged";

        [DataMember(Name = "occurred_at", IsRequired = true, EmitDefaultValue = false)]
        public string OccurredAt { get; set; }

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

    [DataContract(Name = "seamModel_eventDeviceUnmanagedConvertedToManaged_model")]
    public class EventDeviceUnmanagedConvertedToManaged : Event
    {
        [JsonConstructorAttribute]
        protected EventDeviceUnmanagedConvertedToManaged() { }

        public EventDeviceUnmanagedConvertedToManaged(
            string connectedAccountId = default,
            string createdAt = default,
            string deviceId = default,
            string eventId = default,
            string eventType = default,
            string occurredAt = default,
            string workspaceId = default
        )
        {
            ConnectedAccountId = connectedAccountId;
            CreatedAt = createdAt;
            DeviceId = deviceId;
            EventId = eventId;
            EventType = eventType;
            OccurredAt = occurredAt;
            WorkspaceId = workspaceId;
        }

        [DataMember(Name = "connected_account_id", IsRequired = true, EmitDefaultValue = false)]
        public string ConnectedAccountId { get; set; }

        [DataMember(Name = "created_at", IsRequired = true, EmitDefaultValue = false)]
        public string CreatedAt { get; set; }

        [DataMember(Name = "device_id", IsRequired = true, EmitDefaultValue = false)]
        public string DeviceId { get; set; }

        [DataMember(Name = "event_id", IsRequired = true, EmitDefaultValue = false)]
        public string EventId { get; set; }

        [DataMember(Name = "event_type", IsRequired = true, EmitDefaultValue = false)]
        public override string EventType { get; } = "device.unmanaged.converted_to_managed";

        [DataMember(Name = "occurred_at", IsRequired = true, EmitDefaultValue = false)]
        public string OccurredAt { get; set; }

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

    [DataContract(Name = "seamModel_eventDeviceUnmanagedConnected_model")]
    public class EventDeviceUnmanagedConnected : Event
    {
        [JsonConstructorAttribute]
        protected EventDeviceUnmanagedConnected() { }

        public EventDeviceUnmanagedConnected(
            string connectedAccountId = default,
            string createdAt = default,
            string deviceId = default,
            string eventId = default,
            string eventType = default,
            string occurredAt = default,
            string workspaceId = default
        )
        {
            ConnectedAccountId = connectedAccountId;
            CreatedAt = createdAt;
            DeviceId = deviceId;
            EventId = eventId;
            EventType = eventType;
            OccurredAt = occurredAt;
            WorkspaceId = workspaceId;
        }

        [DataMember(Name = "connected_account_id", IsRequired = true, EmitDefaultValue = false)]
        public string ConnectedAccountId { get; set; }

        [DataMember(Name = "created_at", IsRequired = true, EmitDefaultValue = false)]
        public string CreatedAt { get; set; }

        [DataMember(Name = "device_id", IsRequired = true, EmitDefaultValue = false)]
        public string DeviceId { get; set; }

        [DataMember(Name = "event_id", IsRequired = true, EmitDefaultValue = false)]
        public string EventId { get; set; }

        [DataMember(Name = "event_type", IsRequired = true, EmitDefaultValue = false)]
        public override string EventType { get; } = "device.unmanaged.connected";

        [DataMember(Name = "occurred_at", IsRequired = true, EmitDefaultValue = false)]
        public string OccurredAt { get; set; }

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

    [DataContract(Name = "seamModel_eventDeviceDisconnected_model")]
    public class EventDeviceDisconnected : Event
    {
        [JsonConstructorAttribute]
        protected EventDeviceDisconnected() { }

        public EventDeviceDisconnected(
            string connectedAccountId = default,
            string createdAt = default,
            string deviceId = default,
            EventDeviceDisconnected.ErrorCodeEnum errorCode = default,
            string eventId = default,
            string eventType = default,
            string occurredAt = default,
            string workspaceId = default
        )
        {
            ConnectedAccountId = connectedAccountId;
            CreatedAt = createdAt;
            DeviceId = deviceId;
            ErrorCode = errorCode;
            EventId = eventId;
            EventType = eventType;
            OccurredAt = occurredAt;
            WorkspaceId = workspaceId;
        }

        [JsonConverter(typeof(StringEnumConverter))]
        public enum ErrorCodeEnum
        {
            [EnumMember(Value = "account_disconnected")]
            AccountDisconnected = 0,

            [EnumMember(Value = "hub_disconnected")]
            HubDisconnected = 1,

            [EnumMember(Value = "device_disconnected")]
            DeviceDisconnected = 2,
        }

        [DataMember(Name = "connected_account_id", IsRequired = true, EmitDefaultValue = false)]
        public string ConnectedAccountId { get; set; }

        [DataMember(Name = "created_at", IsRequired = true, EmitDefaultValue = false)]
        public string CreatedAt { get; set; }

        [DataMember(Name = "device_id", IsRequired = true, EmitDefaultValue = false)]
        public string DeviceId { get; set; }

        [DataMember(Name = "error_code", IsRequired = true, EmitDefaultValue = false)]
        public EventDeviceDisconnected.ErrorCodeEnum ErrorCode { get; set; }

        [DataMember(Name = "event_id", IsRequired = true, EmitDefaultValue = false)]
        public string EventId { get; set; }

        [DataMember(Name = "event_type", IsRequired = true, EmitDefaultValue = false)]
        public override string EventType { get; } = "device.disconnected";

        [DataMember(Name = "occurred_at", IsRequired = true, EmitDefaultValue = false)]
        public string OccurredAt { get; set; }

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

    [DataContract(Name = "seamModel_eventDeviceUnmanagedDisconnected_model")]
    public class EventDeviceUnmanagedDisconnected : Event
    {
        [JsonConstructorAttribute]
        protected EventDeviceUnmanagedDisconnected() { }

        public EventDeviceUnmanagedDisconnected(
            string connectedAccountId = default,
            string createdAt = default,
            string deviceId = default,
            EventDeviceUnmanagedDisconnected.ErrorCodeEnum errorCode = default,
            string eventId = default,
            string eventType = default,
            string occurredAt = default,
            string workspaceId = default
        )
        {
            ConnectedAccountId = connectedAccountId;
            CreatedAt = createdAt;
            DeviceId = deviceId;
            ErrorCode = errorCode;
            EventId = eventId;
            EventType = eventType;
            OccurredAt = occurredAt;
            WorkspaceId = workspaceId;
        }

        [JsonConverter(typeof(StringEnumConverter))]
        public enum ErrorCodeEnum
        {
            [EnumMember(Value = "account_disconnected")]
            AccountDisconnected = 0,

            [EnumMember(Value = "hub_disconnected")]
            HubDisconnected = 1,

            [EnumMember(Value = "device_disconnected")]
            DeviceDisconnected = 2,
        }

        [DataMember(Name = "connected_account_id", IsRequired = true, EmitDefaultValue = false)]
        public string ConnectedAccountId { get; set; }

        [DataMember(Name = "created_at", IsRequired = true, EmitDefaultValue = false)]
        public string CreatedAt { get; set; }

        [DataMember(Name = "device_id", IsRequired = true, EmitDefaultValue = false)]
        public string DeviceId { get; set; }

        [DataMember(Name = "error_code", IsRequired = true, EmitDefaultValue = false)]
        public EventDeviceUnmanagedDisconnected.ErrorCodeEnum ErrorCode { get; set; }

        [DataMember(Name = "event_id", IsRequired = true, EmitDefaultValue = false)]
        public string EventId { get; set; }

        [DataMember(Name = "event_type", IsRequired = true, EmitDefaultValue = false)]
        public override string EventType { get; } = "device.unmanaged.disconnected";

        [DataMember(Name = "occurred_at", IsRequired = true, EmitDefaultValue = false)]
        public string OccurredAt { get; set; }

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

    [DataContract(Name = "seamModel_eventDeviceTampered_model")]
    public class EventDeviceTampered : Event
    {
        [JsonConstructorAttribute]
        protected EventDeviceTampered() { }

        public EventDeviceTampered(
            string connectedAccountId = default,
            string createdAt = default,
            string deviceId = default,
            string eventId = default,
            string eventType = default,
            string occurredAt = default,
            string workspaceId = default
        )
        {
            ConnectedAccountId = connectedAccountId;
            CreatedAt = createdAt;
            DeviceId = deviceId;
            EventId = eventId;
            EventType = eventType;
            OccurredAt = occurredAt;
            WorkspaceId = workspaceId;
        }

        [DataMember(Name = "connected_account_id", IsRequired = true, EmitDefaultValue = false)]
        public string ConnectedAccountId { get; set; }

        [DataMember(Name = "created_at", IsRequired = true, EmitDefaultValue = false)]
        public string CreatedAt { get; set; }

        [DataMember(Name = "device_id", IsRequired = true, EmitDefaultValue = false)]
        public string DeviceId { get; set; }

        [DataMember(Name = "event_id", IsRequired = true, EmitDefaultValue = false)]
        public string EventId { get; set; }

        [DataMember(Name = "event_type", IsRequired = true, EmitDefaultValue = false)]
        public override string EventType { get; } = "device.tampered";

        [DataMember(Name = "occurred_at", IsRequired = true, EmitDefaultValue = false)]
        public string OccurredAt { get; set; }

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

    [DataContract(Name = "seamModel_eventDeviceLowBattery_model")]
    public class EventDeviceLowBattery : Event
    {
        [JsonConstructorAttribute]
        protected EventDeviceLowBattery() { }

        public EventDeviceLowBattery(
            float batteryLevel = default,
            string connectedAccountId = default,
            string createdAt = default,
            string deviceId = default,
            string eventId = default,
            string eventType = default,
            string occurredAt = default,
            string workspaceId = default
        )
        {
            BatteryLevel = batteryLevel;
            ConnectedAccountId = connectedAccountId;
            CreatedAt = createdAt;
            DeviceId = deviceId;
            EventId = eventId;
            EventType = eventType;
            OccurredAt = occurredAt;
            WorkspaceId = workspaceId;
        }

        [DataMember(Name = "battery_level", IsRequired = true, EmitDefaultValue = false)]
        public float BatteryLevel { get; set; }

        [DataMember(Name = "connected_account_id", IsRequired = true, EmitDefaultValue = false)]
        public string ConnectedAccountId { get; set; }

        [DataMember(Name = "created_at", IsRequired = true, EmitDefaultValue = false)]
        public string CreatedAt { get; set; }

        [DataMember(Name = "device_id", IsRequired = true, EmitDefaultValue = false)]
        public string DeviceId { get; set; }

        [DataMember(Name = "event_id", IsRequired = true, EmitDefaultValue = false)]
        public string EventId { get; set; }

        [DataMember(Name = "event_type", IsRequired = true, EmitDefaultValue = false)]
        public override string EventType { get; } = "device.low_battery";

        [DataMember(Name = "occurred_at", IsRequired = true, EmitDefaultValue = false)]
        public string OccurredAt { get; set; }

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

    [DataContract(Name = "seamModel_eventDeviceBatteryStatusChanged_model")]
    public class EventDeviceBatteryStatusChanged : Event
    {
        [JsonConstructorAttribute]
        protected EventDeviceBatteryStatusChanged() { }

        public EventDeviceBatteryStatusChanged(
            float batteryLevel = default,
            EventDeviceBatteryStatusChanged.BatteryStatusEnum batteryStatus = default,
            string connectedAccountId = default,
            string createdAt = default,
            string deviceId = default,
            string eventId = default,
            string eventType = default,
            string occurredAt = default,
            string workspaceId = default
        )
        {
            BatteryLevel = batteryLevel;
            BatteryStatus = batteryStatus;
            ConnectedAccountId = connectedAccountId;
            CreatedAt = createdAt;
            DeviceId = deviceId;
            EventId = eventId;
            EventType = eventType;
            OccurredAt = occurredAt;
            WorkspaceId = workspaceId;
        }

        [JsonConverter(typeof(StringEnumConverter))]
        public enum BatteryStatusEnum
        {
            [EnumMember(Value = "critical")]
            Critical = 0,

            [EnumMember(Value = "low")]
            Low = 1,

            [EnumMember(Value = "good")]
            Good = 2,

            [EnumMember(Value = "full")]
            Full = 3,
        }

        [DataMember(Name = "battery_level", IsRequired = true, EmitDefaultValue = false)]
        public float BatteryLevel { get; set; }

        [DataMember(Name = "battery_status", IsRequired = true, EmitDefaultValue = false)]
        public EventDeviceBatteryStatusChanged.BatteryStatusEnum BatteryStatus { get; set; }

        [DataMember(Name = "connected_account_id", IsRequired = true, EmitDefaultValue = false)]
        public string ConnectedAccountId { get; set; }

        [DataMember(Name = "created_at", IsRequired = true, EmitDefaultValue = false)]
        public string CreatedAt { get; set; }

        [DataMember(Name = "device_id", IsRequired = true, EmitDefaultValue = false)]
        public string DeviceId { get; set; }

        [DataMember(Name = "event_id", IsRequired = true, EmitDefaultValue = false)]
        public string EventId { get; set; }

        [DataMember(Name = "event_type", IsRequired = true, EmitDefaultValue = false)]
        public override string EventType { get; } = "device.battery_status_changed";

        [DataMember(Name = "occurred_at", IsRequired = true, EmitDefaultValue = false)]
        public string OccurredAt { get; set; }

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

    [DataContract(Name = "seamModel_eventDeviceRemoved_model")]
    public class EventDeviceRemoved : Event
    {
        [JsonConstructorAttribute]
        protected EventDeviceRemoved() { }

        public EventDeviceRemoved(
            string connectedAccountId = default,
            string createdAt = default,
            string deviceId = default,
            string eventId = default,
            string eventType = default,
            string occurredAt = default,
            string workspaceId = default
        )
        {
            ConnectedAccountId = connectedAccountId;
            CreatedAt = createdAt;
            DeviceId = deviceId;
            EventId = eventId;
            EventType = eventType;
            OccurredAt = occurredAt;
            WorkspaceId = workspaceId;
        }

        [DataMember(Name = "connected_account_id", IsRequired = true, EmitDefaultValue = false)]
        public string ConnectedAccountId { get; set; }

        [DataMember(Name = "created_at", IsRequired = true, EmitDefaultValue = false)]
        public string CreatedAt { get; set; }

        [DataMember(Name = "device_id", IsRequired = true, EmitDefaultValue = false)]
        public string DeviceId { get; set; }

        [DataMember(Name = "event_id", IsRequired = true, EmitDefaultValue = false)]
        public string EventId { get; set; }

        [DataMember(Name = "event_type", IsRequired = true, EmitDefaultValue = false)]
        public override string EventType { get; } = "device.removed";

        [DataMember(Name = "occurred_at", IsRequired = true, EmitDefaultValue = false)]
        public string OccurredAt { get; set; }

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

    [DataContract(Name = "seamModel_eventDeviceDeleted_model")]
    public class EventDeviceDeleted : Event
    {
        [JsonConstructorAttribute]
        protected EventDeviceDeleted() { }

        public EventDeviceDeleted(
            string connectedAccountId = default,
            string createdAt = default,
            string deviceId = default,
            string eventId = default,
            string eventType = default,
            string occurredAt = default,
            string workspaceId = default
        )
        {
            ConnectedAccountId = connectedAccountId;
            CreatedAt = createdAt;
            DeviceId = deviceId;
            EventId = eventId;
            EventType = eventType;
            OccurredAt = occurredAt;
            WorkspaceId = workspaceId;
        }

        [DataMember(Name = "connected_account_id", IsRequired = true, EmitDefaultValue = false)]
        public string ConnectedAccountId { get; set; }

        [DataMember(Name = "created_at", IsRequired = true, EmitDefaultValue = false)]
        public string CreatedAt { get; set; }

        [DataMember(Name = "device_id", IsRequired = true, EmitDefaultValue = false)]
        public string DeviceId { get; set; }

        [DataMember(Name = "event_id", IsRequired = true, EmitDefaultValue = false)]
        public string EventId { get; set; }

        [DataMember(Name = "event_type", IsRequired = true, EmitDefaultValue = false)]
        public override string EventType { get; } = "device.deleted";

        [DataMember(Name = "occurred_at", IsRequired = true, EmitDefaultValue = false)]
        public string OccurredAt { get; set; }

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

    [DataContract(Name = "seamModel_eventDeviceThirdPartyIntegrationDetected_model")]
    public class EventDeviceThirdPartyIntegrationDetected : Event
    {
        [JsonConstructorAttribute]
        protected EventDeviceThirdPartyIntegrationDetected() { }

        public EventDeviceThirdPartyIntegrationDetected(
            string connectedAccountId = default,
            string createdAt = default,
            string deviceId = default,
            string eventId = default,
            string eventType = default,
            string occurredAt = default,
            string workspaceId = default
        )
        {
            ConnectedAccountId = connectedAccountId;
            CreatedAt = createdAt;
            DeviceId = deviceId;
            EventId = eventId;
            EventType = eventType;
            OccurredAt = occurredAt;
            WorkspaceId = workspaceId;
        }

        [DataMember(Name = "connected_account_id", IsRequired = true, EmitDefaultValue = false)]
        public string ConnectedAccountId { get; set; }

        [DataMember(Name = "created_at", IsRequired = true, EmitDefaultValue = false)]
        public string CreatedAt { get; set; }

        [DataMember(Name = "device_id", IsRequired = true, EmitDefaultValue = false)]
        public string DeviceId { get; set; }

        [DataMember(Name = "event_id", IsRequired = true, EmitDefaultValue = false)]
        public string EventId { get; set; }

        [DataMember(Name = "event_type", IsRequired = true, EmitDefaultValue = false)]
        public override string EventType { get; } = "device.third_party_integration_detected";

        [DataMember(Name = "occurred_at", IsRequired = true, EmitDefaultValue = false)]
        public string OccurredAt { get; set; }

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

    [DataContract(Name = "seamModel_eventDeviceThirdPartyIntegrationNoLongerDetected_model")]
    public class EventDeviceThirdPartyIntegrationNoLongerDetected : Event
    {
        [JsonConstructorAttribute]
        protected EventDeviceThirdPartyIntegrationNoLongerDetected() { }

        public EventDeviceThirdPartyIntegrationNoLongerDetected(
            string connectedAccountId = default,
            string createdAt = default,
            string deviceId = default,
            string eventId = default,
            string eventType = default,
            string occurredAt = default,
            string workspaceId = default
        )
        {
            ConnectedAccountId = connectedAccountId;
            CreatedAt = createdAt;
            DeviceId = deviceId;
            EventId = eventId;
            EventType = eventType;
            OccurredAt = occurredAt;
            WorkspaceId = workspaceId;
        }

        [DataMember(Name = "connected_account_id", IsRequired = true, EmitDefaultValue = false)]
        public string ConnectedAccountId { get; set; }

        [DataMember(Name = "created_at", IsRequired = true, EmitDefaultValue = false)]
        public string CreatedAt { get; set; }

        [DataMember(Name = "device_id", IsRequired = true, EmitDefaultValue = false)]
        public string DeviceId { get; set; }

        [DataMember(Name = "event_id", IsRequired = true, EmitDefaultValue = false)]
        public string EventId { get; set; }

        [DataMember(Name = "event_type", IsRequired = true, EmitDefaultValue = false)]
        public override string EventType { get; } =
            "device.third_party_integration_no_longer_detected";

        [DataMember(Name = "occurred_at", IsRequired = true, EmitDefaultValue = false)]
        public string OccurredAt { get; set; }

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

    [DataContract(Name = "seamModel_eventDeviceSaltoPrivacyModeActivated_model")]
    public class EventDeviceSaltoPrivacyModeActivated : Event
    {
        [JsonConstructorAttribute]
        protected EventDeviceSaltoPrivacyModeActivated() { }

        public EventDeviceSaltoPrivacyModeActivated(
            string connectedAccountId = default,
            string createdAt = default,
            string deviceId = default,
            string eventId = default,
            string eventType = default,
            string occurredAt = default,
            string workspaceId = default
        )
        {
            ConnectedAccountId = connectedAccountId;
            CreatedAt = createdAt;
            DeviceId = deviceId;
            EventId = eventId;
            EventType = eventType;
            OccurredAt = occurredAt;
            WorkspaceId = workspaceId;
        }

        [DataMember(Name = "connected_account_id", IsRequired = true, EmitDefaultValue = false)]
        public string ConnectedAccountId { get; set; }

        [DataMember(Name = "created_at", IsRequired = true, EmitDefaultValue = false)]
        public string CreatedAt { get; set; }

        [DataMember(Name = "device_id", IsRequired = true, EmitDefaultValue = false)]
        public string DeviceId { get; set; }

        [DataMember(Name = "event_id", IsRequired = true, EmitDefaultValue = false)]
        public string EventId { get; set; }

        [DataMember(Name = "event_type", IsRequired = true, EmitDefaultValue = false)]
        public override string EventType { get; } = "device.salto.privacy_mode_activated";

        [DataMember(Name = "occurred_at", IsRequired = true, EmitDefaultValue = false)]
        public string OccurredAt { get; set; }

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

    [DataContract(Name = "seamModel_eventDeviceSaltoPrivacyModeDeactivated_model")]
    public class EventDeviceSaltoPrivacyModeDeactivated : Event
    {
        [JsonConstructorAttribute]
        protected EventDeviceSaltoPrivacyModeDeactivated() { }

        public EventDeviceSaltoPrivacyModeDeactivated(
            string connectedAccountId = default,
            string createdAt = default,
            string deviceId = default,
            string eventId = default,
            string eventType = default,
            string occurredAt = default,
            string workspaceId = default
        )
        {
            ConnectedAccountId = connectedAccountId;
            CreatedAt = createdAt;
            DeviceId = deviceId;
            EventId = eventId;
            EventType = eventType;
            OccurredAt = occurredAt;
            WorkspaceId = workspaceId;
        }

        [DataMember(Name = "connected_account_id", IsRequired = true, EmitDefaultValue = false)]
        public string ConnectedAccountId { get; set; }

        [DataMember(Name = "created_at", IsRequired = true, EmitDefaultValue = false)]
        public string CreatedAt { get; set; }

        [DataMember(Name = "device_id", IsRequired = true, EmitDefaultValue = false)]
        public string DeviceId { get; set; }

        [DataMember(Name = "event_id", IsRequired = true, EmitDefaultValue = false)]
        public string EventId { get; set; }

        [DataMember(Name = "event_type", IsRequired = true, EmitDefaultValue = false)]
        public override string EventType { get; } = "device.salto.privacy_mode_deactivated";

        [DataMember(Name = "occurred_at", IsRequired = true, EmitDefaultValue = false)]
        public string OccurredAt { get; set; }

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

    [DataContract(Name = "seamModel_eventDeviceConnectionBecameFlaky_model")]
    public class EventDeviceConnectionBecameFlaky : Event
    {
        [JsonConstructorAttribute]
        protected EventDeviceConnectionBecameFlaky() { }

        public EventDeviceConnectionBecameFlaky(
            string connectedAccountId = default,
            string createdAt = default,
            string deviceId = default,
            string eventId = default,
            string eventType = default,
            string occurredAt = default,
            string workspaceId = default
        )
        {
            ConnectedAccountId = connectedAccountId;
            CreatedAt = createdAt;
            DeviceId = deviceId;
            EventId = eventId;
            EventType = eventType;
            OccurredAt = occurredAt;
            WorkspaceId = workspaceId;
        }

        [DataMember(Name = "connected_account_id", IsRequired = true, EmitDefaultValue = false)]
        public string ConnectedAccountId { get; set; }

        [DataMember(Name = "created_at", IsRequired = true, EmitDefaultValue = false)]
        public string CreatedAt { get; set; }

        [DataMember(Name = "device_id", IsRequired = true, EmitDefaultValue = false)]
        public string DeviceId { get; set; }

        [DataMember(Name = "event_id", IsRequired = true, EmitDefaultValue = false)]
        public string EventId { get; set; }

        [DataMember(Name = "event_type", IsRequired = true, EmitDefaultValue = false)]
        public override string EventType { get; } = "device.connection_became_flaky";

        [DataMember(Name = "occurred_at", IsRequired = true, EmitDefaultValue = false)]
        public string OccurredAt { get; set; }

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

    [DataContract(Name = "seamModel_eventDeviceConnectionStabilized_model")]
    public class EventDeviceConnectionStabilized : Event
    {
        [JsonConstructorAttribute]
        protected EventDeviceConnectionStabilized() { }

        public EventDeviceConnectionStabilized(
            string connectedAccountId = default,
            string createdAt = default,
            string deviceId = default,
            string eventId = default,
            string eventType = default,
            string occurredAt = default,
            string workspaceId = default
        )
        {
            ConnectedAccountId = connectedAccountId;
            CreatedAt = createdAt;
            DeviceId = deviceId;
            EventId = eventId;
            EventType = eventType;
            OccurredAt = occurredAt;
            WorkspaceId = workspaceId;
        }

        [DataMember(Name = "connected_account_id", IsRequired = true, EmitDefaultValue = false)]
        public string ConnectedAccountId { get; set; }

        [DataMember(Name = "created_at", IsRequired = true, EmitDefaultValue = false)]
        public string CreatedAt { get; set; }

        [DataMember(Name = "device_id", IsRequired = true, EmitDefaultValue = false)]
        public string DeviceId { get; set; }

        [DataMember(Name = "event_id", IsRequired = true, EmitDefaultValue = false)]
        public string EventId { get; set; }

        [DataMember(Name = "event_type", IsRequired = true, EmitDefaultValue = false)]
        public override string EventType { get; } = "device.connection_stabilized";

        [DataMember(Name = "occurred_at", IsRequired = true, EmitDefaultValue = false)]
        public string OccurredAt { get; set; }

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

    [DataContract(Name = "seamModel_eventDeviceErrorSubscriptionRequired_model")]
    public class EventDeviceErrorSubscriptionRequired : Event
    {
        [JsonConstructorAttribute]
        protected EventDeviceErrorSubscriptionRequired() { }

        public EventDeviceErrorSubscriptionRequired(
            string connectedAccountId = default,
            string createdAt = default,
            string deviceId = default,
            string eventId = default,
            string eventType = default,
            string occurredAt = default,
            string workspaceId = default
        )
        {
            ConnectedAccountId = connectedAccountId;
            CreatedAt = createdAt;
            DeviceId = deviceId;
            EventId = eventId;
            EventType = eventType;
            OccurredAt = occurredAt;
            WorkspaceId = workspaceId;
        }

        [DataMember(Name = "connected_account_id", IsRequired = true, EmitDefaultValue = false)]
        public string ConnectedAccountId { get; set; }

        [DataMember(Name = "created_at", IsRequired = true, EmitDefaultValue = false)]
        public string CreatedAt { get; set; }

        [DataMember(Name = "device_id", IsRequired = true, EmitDefaultValue = false)]
        public string DeviceId { get; set; }

        [DataMember(Name = "event_id", IsRequired = true, EmitDefaultValue = false)]
        public string EventId { get; set; }

        [DataMember(Name = "event_type", IsRequired = true, EmitDefaultValue = false)]
        public override string EventType { get; } = "device.error.subscription_required";

        [DataMember(Name = "occurred_at", IsRequired = true, EmitDefaultValue = false)]
        public string OccurredAt { get; set; }

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

    [DataContract(Name = "seamModel_eventDeviceErrorSubscriptionRequiredResolved_model")]
    public class EventDeviceErrorSubscriptionRequiredResolved : Event
    {
        [JsonConstructorAttribute]
        protected EventDeviceErrorSubscriptionRequiredResolved() { }

        public EventDeviceErrorSubscriptionRequiredResolved(
            string connectedAccountId = default,
            string createdAt = default,
            string deviceId = default,
            string eventId = default,
            string eventType = default,
            string occurredAt = default,
            string workspaceId = default
        )
        {
            ConnectedAccountId = connectedAccountId;
            CreatedAt = createdAt;
            DeviceId = deviceId;
            EventId = eventId;
            EventType = eventType;
            OccurredAt = occurredAt;
            WorkspaceId = workspaceId;
        }

        [DataMember(Name = "connected_account_id", IsRequired = true, EmitDefaultValue = false)]
        public string ConnectedAccountId { get; set; }

        [DataMember(Name = "created_at", IsRequired = true, EmitDefaultValue = false)]
        public string CreatedAt { get; set; }

        [DataMember(Name = "device_id", IsRequired = true, EmitDefaultValue = false)]
        public string DeviceId { get; set; }

        [DataMember(Name = "event_id", IsRequired = true, EmitDefaultValue = false)]
        public string EventId { get; set; }

        [DataMember(Name = "event_type", IsRequired = true, EmitDefaultValue = false)]
        public override string EventType { get; } = "device.error.subscription_required.resolved";

        [DataMember(Name = "occurred_at", IsRequired = true, EmitDefaultValue = false)]
        public string OccurredAt { get; set; }

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

    [DataContract(Name = "seamModel_eventDeviceAccessoryKeypadConnected_model")]
    public class EventDeviceAccessoryKeypadConnected : Event
    {
        [JsonConstructorAttribute]
        protected EventDeviceAccessoryKeypadConnected() { }

        public EventDeviceAccessoryKeypadConnected(
            string connectedAccountId = default,
            string createdAt = default,
            string deviceId = default,
            string eventId = default,
            string eventType = default,
            string occurredAt = default,
            string workspaceId = default
        )
        {
            ConnectedAccountId = connectedAccountId;
            CreatedAt = createdAt;
            DeviceId = deviceId;
            EventId = eventId;
            EventType = eventType;
            OccurredAt = occurredAt;
            WorkspaceId = workspaceId;
        }

        [DataMember(Name = "connected_account_id", IsRequired = true, EmitDefaultValue = false)]
        public string ConnectedAccountId { get; set; }

        [DataMember(Name = "created_at", IsRequired = true, EmitDefaultValue = false)]
        public string CreatedAt { get; set; }

        [DataMember(Name = "device_id", IsRequired = true, EmitDefaultValue = false)]
        public string DeviceId { get; set; }

        [DataMember(Name = "event_id", IsRequired = true, EmitDefaultValue = false)]
        public string EventId { get; set; }

        [DataMember(Name = "event_type", IsRequired = true, EmitDefaultValue = false)]
        public override string EventType { get; } = "device.accessory_keypad_connected";

        [DataMember(Name = "occurred_at", IsRequired = true, EmitDefaultValue = false)]
        public string OccurredAt { get; set; }

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

    [DataContract(Name = "seamModel_eventDeviceAccessoryKeypadDisconnected_model")]
    public class EventDeviceAccessoryKeypadDisconnected : Event
    {
        [JsonConstructorAttribute]
        protected EventDeviceAccessoryKeypadDisconnected() { }

        public EventDeviceAccessoryKeypadDisconnected(
            string connectedAccountId = default,
            string createdAt = default,
            string deviceId = default,
            string eventId = default,
            string eventType = default,
            string occurredAt = default,
            string workspaceId = default
        )
        {
            ConnectedAccountId = connectedAccountId;
            CreatedAt = createdAt;
            DeviceId = deviceId;
            EventId = eventId;
            EventType = eventType;
            OccurredAt = occurredAt;
            WorkspaceId = workspaceId;
        }

        [DataMember(Name = "connected_account_id", IsRequired = true, EmitDefaultValue = false)]
        public string ConnectedAccountId { get; set; }

        [DataMember(Name = "created_at", IsRequired = true, EmitDefaultValue = false)]
        public string CreatedAt { get; set; }

        [DataMember(Name = "device_id", IsRequired = true, EmitDefaultValue = false)]
        public string DeviceId { get; set; }

        [DataMember(Name = "event_id", IsRequired = true, EmitDefaultValue = false)]
        public string EventId { get; set; }

        [DataMember(Name = "event_type", IsRequired = true, EmitDefaultValue = false)]
        public override string EventType { get; } = "device.accessory_keypad_disconnected";

        [DataMember(Name = "occurred_at", IsRequired = true, EmitDefaultValue = false)]
        public string OccurredAt { get; set; }

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

    [DataContract(Name = "seamModel_eventNoiseSensorNoiseThresholdTriggered_model")]
    public class EventNoiseSensorNoiseThresholdTriggered : Event
    {
        [JsonConstructorAttribute]
        protected EventNoiseSensorNoiseThresholdTriggered() { }

        public EventNoiseSensorNoiseThresholdTriggered(
            string connectedAccountId = default,
            string createdAt = default,
            string deviceId = default,
            string eventId = default,
            string eventType = default,
            object? minutMetadata = default,
            float? noiseLevelDecibels = default,
            float? noiseLevelNrs = default,
            string? noiseThresholdId = default,
            string? noiseThresholdName = default,
            object? noiseawareMetadata = default,
            string occurredAt = default,
            string workspaceId = default
        )
        {
            ConnectedAccountId = connectedAccountId;
            CreatedAt = createdAt;
            DeviceId = deviceId;
            EventId = eventId;
            EventType = eventType;
            MinutMetadata = minutMetadata;
            NoiseLevelDecibels = noiseLevelDecibels;
            NoiseLevelNrs = noiseLevelNrs;
            NoiseThresholdId = noiseThresholdId;
            NoiseThresholdName = noiseThresholdName;
            NoiseawareMetadata = noiseawareMetadata;
            OccurredAt = occurredAt;
            WorkspaceId = workspaceId;
        }

        [DataMember(Name = "connected_account_id", IsRequired = true, EmitDefaultValue = false)]
        public string ConnectedAccountId { get; set; }

        [DataMember(Name = "created_at", IsRequired = true, EmitDefaultValue = false)]
        public string CreatedAt { get; set; }

        [DataMember(Name = "device_id", IsRequired = true, EmitDefaultValue = false)]
        public string DeviceId { get; set; }

        [DataMember(Name = "event_id", IsRequired = true, EmitDefaultValue = false)]
        public string EventId { get; set; }

        [DataMember(Name = "event_type", IsRequired = true, EmitDefaultValue = false)]
        public override string EventType { get; } = "noise_sensor.noise_threshold_triggered";

        [DataMember(Name = "minut_metadata", IsRequired = false, EmitDefaultValue = false)]
        public object? MinutMetadata { get; set; }

        [DataMember(Name = "noise_level_decibels", IsRequired = false, EmitDefaultValue = false)]
        public float? NoiseLevelDecibels { get; set; }

        [DataMember(Name = "noise_level_nrs", IsRequired = false, EmitDefaultValue = false)]
        public float? NoiseLevelNrs { get; set; }

        [DataMember(Name = "noise_threshold_id", IsRequired = false, EmitDefaultValue = false)]
        public string? NoiseThresholdId { get; set; }

        [DataMember(Name = "noise_threshold_name", IsRequired = false, EmitDefaultValue = false)]
        public string? NoiseThresholdName { get; set; }

        [DataMember(Name = "noiseaware_metadata", IsRequired = false, EmitDefaultValue = false)]
        public object? NoiseawareMetadata { get; set; }

        [DataMember(Name = "occurred_at", IsRequired = true, EmitDefaultValue = false)]
        public string OccurredAt { get; set; }

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

    [DataContract(Name = "seamModel_eventLockLocked_model")]
    public class EventLockLocked : Event
    {
        [JsonConstructorAttribute]
        protected EventLockLocked() { }

        public EventLockLocked(
            string? accessCodeId = default,
            string? actionAttemptId = default,
            string connectedAccountId = default,
            string createdAt = default,
            string deviceId = default,
            string eventId = default,
            string eventType = default,
            EventLockLocked.MethodEnum method = default,
            string occurredAt = default,
            string workspaceId = default
        )
        {
            AccessCodeId = accessCodeId;
            ActionAttemptId = actionAttemptId;
            ConnectedAccountId = connectedAccountId;
            CreatedAt = createdAt;
            DeviceId = deviceId;
            EventId = eventId;
            EventType = eventType;
            Method = method;
            OccurredAt = occurredAt;
            WorkspaceId = workspaceId;
        }

        [JsonConverter(typeof(StringEnumConverter))]
        public enum MethodEnum
        {
            [EnumMember(Value = "keycode")]
            Keycode = 0,

            [EnumMember(Value = "manual")]
            Manual = 1,

            [EnumMember(Value = "automatic")]
            Automatic = 2,

            [EnumMember(Value = "unknown")]
            Unknown = 3,

            [EnumMember(Value = "seamapi")]
            Seamapi = 4,
        }

        [DataMember(Name = "access_code_id", IsRequired = false, EmitDefaultValue = false)]
        public string? AccessCodeId { get; set; }

        [DataMember(Name = "action_attempt_id", IsRequired = false, EmitDefaultValue = false)]
        public string? ActionAttemptId { get; set; }

        [DataMember(Name = "connected_account_id", IsRequired = true, EmitDefaultValue = false)]
        public string ConnectedAccountId { get; set; }

        [DataMember(Name = "created_at", IsRequired = true, EmitDefaultValue = false)]
        public string CreatedAt { get; set; }

        [DataMember(Name = "device_id", IsRequired = true, EmitDefaultValue = false)]
        public string DeviceId { get; set; }

        [DataMember(Name = "event_id", IsRequired = true, EmitDefaultValue = false)]
        public string EventId { get; set; }

        [DataMember(Name = "event_type", IsRequired = true, EmitDefaultValue = false)]
        public override string EventType { get; } = "lock.locked";

        [DataMember(Name = "method", IsRequired = true, EmitDefaultValue = false)]
        public EventLockLocked.MethodEnum Method { get; set; }

        [DataMember(Name = "occurred_at", IsRequired = true, EmitDefaultValue = false)]
        public string OccurredAt { get; set; }

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

    [DataContract(Name = "seamModel_eventLockUnlocked_model")]
    public class EventLockUnlocked : Event
    {
        [JsonConstructorAttribute]
        protected EventLockUnlocked() { }

        public EventLockUnlocked(
            string? accessCodeId = default,
            string? actionAttemptId = default,
            string connectedAccountId = default,
            string createdAt = default,
            string deviceId = default,
            string eventId = default,
            string eventType = default,
            EventLockUnlocked.MethodEnum method = default,
            string occurredAt = default,
            string workspaceId = default
        )
        {
            AccessCodeId = accessCodeId;
            ActionAttemptId = actionAttemptId;
            ConnectedAccountId = connectedAccountId;
            CreatedAt = createdAt;
            DeviceId = deviceId;
            EventId = eventId;
            EventType = eventType;
            Method = method;
            OccurredAt = occurredAt;
            WorkspaceId = workspaceId;
        }

        [JsonConverter(typeof(StringEnumConverter))]
        public enum MethodEnum
        {
            [EnumMember(Value = "keycode")]
            Keycode = 0,

            [EnumMember(Value = "manual")]
            Manual = 1,

            [EnumMember(Value = "automatic")]
            Automatic = 2,

            [EnumMember(Value = "unknown")]
            Unknown = 3,

            [EnumMember(Value = "seamapi")]
            Seamapi = 4,
        }

        [DataMember(Name = "access_code_id", IsRequired = false, EmitDefaultValue = false)]
        public string? AccessCodeId { get; set; }

        [DataMember(Name = "action_attempt_id", IsRequired = false, EmitDefaultValue = false)]
        public string? ActionAttemptId { get; set; }

        [DataMember(Name = "connected_account_id", IsRequired = true, EmitDefaultValue = false)]
        public string ConnectedAccountId { get; set; }

        [DataMember(Name = "created_at", IsRequired = true, EmitDefaultValue = false)]
        public string CreatedAt { get; set; }

        [DataMember(Name = "device_id", IsRequired = true, EmitDefaultValue = false)]
        public string DeviceId { get; set; }

        [DataMember(Name = "event_id", IsRequired = true, EmitDefaultValue = false)]
        public string EventId { get; set; }

        [DataMember(Name = "event_type", IsRequired = true, EmitDefaultValue = false)]
        public override string EventType { get; } = "lock.unlocked";

        [DataMember(Name = "method", IsRequired = true, EmitDefaultValue = false)]
        public EventLockUnlocked.MethodEnum Method { get; set; }

        [DataMember(Name = "occurred_at", IsRequired = true, EmitDefaultValue = false)]
        public string OccurredAt { get; set; }

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

    [DataContract(Name = "seamModel_eventLockAccessDenied_model")]
    public class EventLockAccessDenied : Event
    {
        [JsonConstructorAttribute]
        protected EventLockAccessDenied() { }

        public EventLockAccessDenied(
            string? accessCodeId = default,
            string connectedAccountId = default,
            string createdAt = default,
            string deviceId = default,
            string eventId = default,
            string eventType = default,
            string occurredAt = default,
            string workspaceId = default
        )
        {
            AccessCodeId = accessCodeId;
            ConnectedAccountId = connectedAccountId;
            CreatedAt = createdAt;
            DeviceId = deviceId;
            EventId = eventId;
            EventType = eventType;
            OccurredAt = occurredAt;
            WorkspaceId = workspaceId;
        }

        [DataMember(Name = "access_code_id", IsRequired = false, EmitDefaultValue = false)]
        public string? AccessCodeId { get; set; }

        [DataMember(Name = "connected_account_id", IsRequired = true, EmitDefaultValue = false)]
        public string ConnectedAccountId { get; set; }

        [DataMember(Name = "created_at", IsRequired = true, EmitDefaultValue = false)]
        public string CreatedAt { get; set; }

        [DataMember(Name = "device_id", IsRequired = true, EmitDefaultValue = false)]
        public string DeviceId { get; set; }

        [DataMember(Name = "event_id", IsRequired = true, EmitDefaultValue = false)]
        public string EventId { get; set; }

        [DataMember(Name = "event_type", IsRequired = true, EmitDefaultValue = false)]
        public override string EventType { get; } = "lock.access_denied";

        [DataMember(Name = "occurred_at", IsRequired = true, EmitDefaultValue = false)]
        public string OccurredAt { get; set; }

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

    [DataContract(Name = "seamModel_eventThermostatClimatePresetActivated_model")]
    public class EventThermostatClimatePresetActivated : Event
    {
        [JsonConstructorAttribute]
        protected EventThermostatClimatePresetActivated() { }

        public EventThermostatClimatePresetActivated(
            string climatePresetKey = default,
            string connectedAccountId = default,
            string createdAt = default,
            string deviceId = default,
            string eventId = default,
            string eventType = default,
            bool isFallbackClimatePreset = default,
            string occurredAt = default,
            string? thermostatScheduleId = default,
            string workspaceId = default
        )
        {
            ClimatePresetKey = climatePresetKey;
            ConnectedAccountId = connectedAccountId;
            CreatedAt = createdAt;
            DeviceId = deviceId;
            EventId = eventId;
            EventType = eventType;
            IsFallbackClimatePreset = isFallbackClimatePreset;
            OccurredAt = occurredAt;
            ThermostatScheduleId = thermostatScheduleId;
            WorkspaceId = workspaceId;
        }

        [DataMember(Name = "climate_preset_key", IsRequired = true, EmitDefaultValue = false)]
        public string ClimatePresetKey { get; set; }

        [DataMember(Name = "connected_account_id", IsRequired = true, EmitDefaultValue = false)]
        public string ConnectedAccountId { get; set; }

        [DataMember(Name = "created_at", IsRequired = true, EmitDefaultValue = false)]
        public string CreatedAt { get; set; }

        [DataMember(Name = "device_id", IsRequired = true, EmitDefaultValue = false)]
        public string DeviceId { get; set; }

        [DataMember(Name = "event_id", IsRequired = true, EmitDefaultValue = false)]
        public string EventId { get; set; }

        [DataMember(Name = "event_type", IsRequired = true, EmitDefaultValue = false)]
        public override string EventType { get; } = "thermostat.climate_preset_activated";

        [DataMember(
            Name = "is_fallback_climate_preset",
            IsRequired = true,
            EmitDefaultValue = false
        )]
        public bool IsFallbackClimatePreset { get; set; }

        [DataMember(Name = "occurred_at", IsRequired = true, EmitDefaultValue = false)]
        public string OccurredAt { get; set; }

        [DataMember(Name = "thermostat_schedule_id", IsRequired = false, EmitDefaultValue = false)]
        public string? ThermostatScheduleId { get; set; }

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

    [DataContract(Name = "seamModel_eventThermostatManuallyAdjusted_model")]
    public class EventThermostatManuallyAdjusted : Event
    {
        [JsonConstructorAttribute]
        protected EventThermostatManuallyAdjusted() { }

        public EventThermostatManuallyAdjusted(
            string connectedAccountId = default,
            float? coolingSetPointCelsius = default,
            float? coolingSetPointFahrenheit = default,
            string createdAt = default,
            string deviceId = default,
            string eventId = default,
            string eventType = default,
            EventThermostatManuallyAdjusted.FanModeSettingEnum? fanModeSetting = default,
            float? heatingSetPointCelsius = default,
            float? heatingSetPointFahrenheit = default,
            EventThermostatManuallyAdjusted.HvacModeSettingEnum? hvacModeSetting = default,
            EventThermostatManuallyAdjusted.MethodEnum method = default,
            string occurredAt = default,
            string workspaceId = default
        )
        {
            ConnectedAccountId = connectedAccountId;
            CoolingSetPointCelsius = coolingSetPointCelsius;
            CoolingSetPointFahrenheit = coolingSetPointFahrenheit;
            CreatedAt = createdAt;
            DeviceId = deviceId;
            EventId = eventId;
            EventType = eventType;
            FanModeSetting = fanModeSetting;
            HeatingSetPointCelsius = heatingSetPointCelsius;
            HeatingSetPointFahrenheit = heatingSetPointFahrenheit;
            HvacModeSetting = hvacModeSetting;
            Method = method;
            OccurredAt = occurredAt;
            WorkspaceId = workspaceId;
        }

        [JsonConverter(typeof(StringEnumConverter))]
        public enum FanModeSettingEnum
        {
            [EnumMember(Value = "auto")]
            Auto = 0,

            [EnumMember(Value = "on")]
            On = 1,

            [EnumMember(Value = "circulate")]
            Circulate = 2,
        }

        [JsonConverter(typeof(StringEnumConverter))]
        public enum HvacModeSettingEnum
        {
            [EnumMember(Value = "off")]
            Off = 0,

            [EnumMember(Value = "heat")]
            Heat = 1,

            [EnumMember(Value = "cool")]
            Cool = 2,

            [EnumMember(Value = "heat_cool")]
            HeatCool = 3,
        }

        [JsonConverter(typeof(StringEnumConverter))]
        public enum MethodEnum
        {
            [EnumMember(Value = "seam")]
            Seam = 0,

            [EnumMember(Value = "external")]
            External = 1,
        }

        [DataMember(Name = "connected_account_id", IsRequired = true, EmitDefaultValue = false)]
        public string ConnectedAccountId { get; set; }

        [DataMember(
            Name = "cooling_set_point_celsius",
            IsRequired = false,
            EmitDefaultValue = false
        )]
        public float? CoolingSetPointCelsius { get; set; }

        [DataMember(
            Name = "cooling_set_point_fahrenheit",
            IsRequired = false,
            EmitDefaultValue = false
        )]
        public float? CoolingSetPointFahrenheit { get; set; }

        [DataMember(Name = "created_at", IsRequired = true, EmitDefaultValue = false)]
        public string CreatedAt { get; set; }

        [DataMember(Name = "device_id", IsRequired = true, EmitDefaultValue = false)]
        public string DeviceId { get; set; }

        [DataMember(Name = "event_id", IsRequired = true, EmitDefaultValue = false)]
        public string EventId { get; set; }

        [DataMember(Name = "event_type", IsRequired = true, EmitDefaultValue = false)]
        public override string EventType { get; } = "thermostat.manually_adjusted";

        [DataMember(Name = "fan_mode_setting", IsRequired = false, EmitDefaultValue = false)]
        public EventThermostatManuallyAdjusted.FanModeSettingEnum? FanModeSetting { get; set; }

        [DataMember(
            Name = "heating_set_point_celsius",
            IsRequired = false,
            EmitDefaultValue = false
        )]
        public float? HeatingSetPointCelsius { get; set; }

        [DataMember(
            Name = "heating_set_point_fahrenheit",
            IsRequired = false,
            EmitDefaultValue = false
        )]
        public float? HeatingSetPointFahrenheit { get; set; }

        [DataMember(Name = "hvac_mode_setting", IsRequired = false, EmitDefaultValue = false)]
        public EventThermostatManuallyAdjusted.HvacModeSettingEnum? HvacModeSetting { get; set; }

        [DataMember(Name = "method", IsRequired = true, EmitDefaultValue = false)]
        public EventThermostatManuallyAdjusted.MethodEnum Method { get; set; }

        [DataMember(Name = "occurred_at", IsRequired = true, EmitDefaultValue = false)]
        public string OccurredAt { get; set; }

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

    [DataContract(Name = "seamModel_eventThermostatTemperatureThresholdExceeded_model")]
    public class EventThermostatTemperatureThresholdExceeded : Event
    {
        [JsonConstructorAttribute]
        protected EventThermostatTemperatureThresholdExceeded() { }

        public EventThermostatTemperatureThresholdExceeded(
            string connectedAccountId = default,
            string createdAt = default,
            string deviceId = default,
            string eventId = default,
            string eventType = default,
            float? lowerLimitCelsius = default,
            float? lowerLimitFahrenheit = default,
            string occurredAt = default,
            float temperatureCelsius = default,
            float temperatureFahrenheit = default,
            float? upperLimitCelsius = default,
            float? upperLimitFahrenheit = default,
            string workspaceId = default
        )
        {
            ConnectedAccountId = connectedAccountId;
            CreatedAt = createdAt;
            DeviceId = deviceId;
            EventId = eventId;
            EventType = eventType;
            LowerLimitCelsius = lowerLimitCelsius;
            LowerLimitFahrenheit = lowerLimitFahrenheit;
            OccurredAt = occurredAt;
            TemperatureCelsius = temperatureCelsius;
            TemperatureFahrenheit = temperatureFahrenheit;
            UpperLimitCelsius = upperLimitCelsius;
            UpperLimitFahrenheit = upperLimitFahrenheit;
            WorkspaceId = workspaceId;
        }

        [DataMember(Name = "connected_account_id", IsRequired = true, EmitDefaultValue = false)]
        public string ConnectedAccountId { get; set; }

        [DataMember(Name = "created_at", IsRequired = true, EmitDefaultValue = false)]
        public string CreatedAt { get; set; }

        [DataMember(Name = "device_id", IsRequired = true, EmitDefaultValue = false)]
        public string DeviceId { get; set; }

        [DataMember(Name = "event_id", IsRequired = true, EmitDefaultValue = false)]
        public string EventId { get; set; }

        [DataMember(Name = "event_type", IsRequired = true, EmitDefaultValue = false)]
        public override string EventType { get; } = "thermostat.temperature_threshold_exceeded";

        [DataMember(Name = "lower_limit_celsius", IsRequired = false, EmitDefaultValue = false)]
        public float? LowerLimitCelsius { get; set; }

        [DataMember(Name = "lower_limit_fahrenheit", IsRequired = false, EmitDefaultValue = false)]
        public float? LowerLimitFahrenheit { get; set; }

        [DataMember(Name = "occurred_at", IsRequired = true, EmitDefaultValue = false)]
        public string OccurredAt { get; set; }

        [DataMember(Name = "temperature_celsius", IsRequired = true, EmitDefaultValue = false)]
        public float TemperatureCelsius { get; set; }

        [DataMember(Name = "temperature_fahrenheit", IsRequired = true, EmitDefaultValue = false)]
        public float TemperatureFahrenheit { get; set; }

        [DataMember(Name = "upper_limit_celsius", IsRequired = false, EmitDefaultValue = false)]
        public float? UpperLimitCelsius { get; set; }

        [DataMember(Name = "upper_limit_fahrenheit", IsRequired = false, EmitDefaultValue = false)]
        public float? UpperLimitFahrenheit { get; set; }

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

    [DataContract(Name = "seamModel_eventThermostatTemperatureThresholdNoLongerExceeded_model")]
    public class EventThermostatTemperatureThresholdNoLongerExceeded : Event
    {
        [JsonConstructorAttribute]
        protected EventThermostatTemperatureThresholdNoLongerExceeded() { }

        public EventThermostatTemperatureThresholdNoLongerExceeded(
            string connectedAccountId = default,
            string createdAt = default,
            string deviceId = default,
            string eventId = default,
            string eventType = default,
            float? lowerLimitCelsius = default,
            float? lowerLimitFahrenheit = default,
            string occurredAt = default,
            float temperatureCelsius = default,
            float temperatureFahrenheit = default,
            float? upperLimitCelsius = default,
            float? upperLimitFahrenheit = default,
            string workspaceId = default
        )
        {
            ConnectedAccountId = connectedAccountId;
            CreatedAt = createdAt;
            DeviceId = deviceId;
            EventId = eventId;
            EventType = eventType;
            LowerLimitCelsius = lowerLimitCelsius;
            LowerLimitFahrenheit = lowerLimitFahrenheit;
            OccurredAt = occurredAt;
            TemperatureCelsius = temperatureCelsius;
            TemperatureFahrenheit = temperatureFahrenheit;
            UpperLimitCelsius = upperLimitCelsius;
            UpperLimitFahrenheit = upperLimitFahrenheit;
            WorkspaceId = workspaceId;
        }

        [DataMember(Name = "connected_account_id", IsRequired = true, EmitDefaultValue = false)]
        public string ConnectedAccountId { get; set; }

        [DataMember(Name = "created_at", IsRequired = true, EmitDefaultValue = false)]
        public string CreatedAt { get; set; }

        [DataMember(Name = "device_id", IsRequired = true, EmitDefaultValue = false)]
        public string DeviceId { get; set; }

        [DataMember(Name = "event_id", IsRequired = true, EmitDefaultValue = false)]
        public string EventId { get; set; }

        [DataMember(Name = "event_type", IsRequired = true, EmitDefaultValue = false)]
        public override string EventType { get; } =
            "thermostat.temperature_threshold_no_longer_exceeded";

        [DataMember(Name = "lower_limit_celsius", IsRequired = false, EmitDefaultValue = false)]
        public float? LowerLimitCelsius { get; set; }

        [DataMember(Name = "lower_limit_fahrenheit", IsRequired = false, EmitDefaultValue = false)]
        public float? LowerLimitFahrenheit { get; set; }

        [DataMember(Name = "occurred_at", IsRequired = true, EmitDefaultValue = false)]
        public string OccurredAt { get; set; }

        [DataMember(Name = "temperature_celsius", IsRequired = true, EmitDefaultValue = false)]
        public float TemperatureCelsius { get; set; }

        [DataMember(Name = "temperature_fahrenheit", IsRequired = true, EmitDefaultValue = false)]
        public float TemperatureFahrenheit { get; set; }

        [DataMember(Name = "upper_limit_celsius", IsRequired = false, EmitDefaultValue = false)]
        public float? UpperLimitCelsius { get; set; }

        [DataMember(Name = "upper_limit_fahrenheit", IsRequired = false, EmitDefaultValue = false)]
        public float? UpperLimitFahrenheit { get; set; }

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

    [DataContract(Name = "seamModel_eventEnrollmentAutomationDeleted_model")]
    public class EventEnrollmentAutomationDeleted : Event
    {
        [JsonConstructorAttribute]
        protected EventEnrollmentAutomationDeleted() { }

        public EventEnrollmentAutomationDeleted(
            string createdAt = default,
            string enrollmentAutomationId = default,
            string eventId = default,
            string eventType = default,
            string occurredAt = default,
            string workspaceId = default
        )
        {
            CreatedAt = createdAt;
            EnrollmentAutomationId = enrollmentAutomationId;
            EventId = eventId;
            EventType = eventType;
            OccurredAt = occurredAt;
            WorkspaceId = workspaceId;
        }

        [DataMember(Name = "created_at", IsRequired = true, EmitDefaultValue = false)]
        public string CreatedAt { get; set; }

        [DataMember(Name = "enrollment_automation_id", IsRequired = true, EmitDefaultValue = false)]
        public string EnrollmentAutomationId { get; set; }

        [DataMember(Name = "event_id", IsRequired = true, EmitDefaultValue = false)]
        public string EventId { get; set; }

        [DataMember(Name = "event_type", IsRequired = true, EmitDefaultValue = false)]
        public override string EventType { get; } = "enrollment_automation.deleted";

        [DataMember(Name = "occurred_at", IsRequired = true, EmitDefaultValue = false)]
        public string OccurredAt { get; set; }

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

    [DataContract(Name = "seamModel_eventPhoneDeactivated_model")]
    public class EventPhoneDeactivated : Event
    {
        [JsonConstructorAttribute]
        protected EventPhoneDeactivated() { }

        public EventPhoneDeactivated(
            string createdAt = default,
            string deviceId = default,
            string eventId = default,
            string eventType = default,
            string occurredAt = default,
            string workspaceId = default
        )
        {
            CreatedAt = createdAt;
            DeviceId = deviceId;
            EventId = eventId;
            EventType = eventType;
            OccurredAt = occurredAt;
            WorkspaceId = workspaceId;
        }

        [DataMember(Name = "created_at", IsRequired = true, EmitDefaultValue = false)]
        public string CreatedAt { get; set; }

        [DataMember(Name = "device_id", IsRequired = true, EmitDefaultValue = false)]
        public string DeviceId { get; set; }

        [DataMember(Name = "event_id", IsRequired = true, EmitDefaultValue = false)]
        public string EventId { get; set; }

        [DataMember(Name = "event_type", IsRequired = true, EmitDefaultValue = false)]
        public override string EventType { get; } = "phone.deactivated";

        [DataMember(Name = "occurred_at", IsRequired = true, EmitDefaultValue = false)]
        public string OccurredAt { get; set; }

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
