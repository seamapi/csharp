using System.Runtime.Serialization;
using System.Text;
using JsonSubTypes;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using Seam.Model;

namespace Seam.Model
{
    [JsonConverter(typeof(JsonSubtypes), "event_type")]
    [JsonSubtypes.FallBackSubType(typeof(EventUnrecognized))]
    [JsonSubtypes.KnownSubType(typeof(EventSpaceDeleted), "space.deleted")]
    [JsonSubtypes.KnownSubType(typeof(EventSpaceCreated), "space.created")]
    [JsonSubtypes.KnownSubType(
        typeof(EventSpaceDeviceMembershipChanged),
        "space.device_membership_changed"
    )]
    [JsonSubtypes.KnownSubType(typeof(EventPhoneDeactivated), "phone.deactivated")]
    [JsonSubtypes.KnownSubType(typeof(EventDeviceDoorbellRang), "device.doorbell_rang")]
    [JsonSubtypes.KnownSubType(typeof(EventCameraActivated), "camera.activated")]
    [JsonSubtypes.KnownSubType(typeof(EventDeviceNameChanged), "device.name_changed")]
    [JsonSubtypes.KnownSubType(
        typeof(EventThermostatTemperatureChanged),
        "thermostat.temperature_changed"
    )]
    [JsonSubtypes.KnownSubType(
        typeof(EventThermostatTemperatureReachedSetPoint),
        "thermostat.temperature_reached_set_point"
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
        typeof(EventActionAttemptSimulateManualLockViaKeypadFailed),
        "action_attempt.simulate_manual_lock_via_keypad.failed"
    )]
    [JsonSubtypes.KnownSubType(
        typeof(EventActionAttemptSimulateManualLockViaKeypadSucceeded),
        "action_attempt.simulate_manual_lock_via_keypad.succeeded"
    )]
    [JsonSubtypes.KnownSubType(
        typeof(EventActionAttemptSimulateKeypadCodeEntryFailed),
        "action_attempt.simulate_keypad_code_entry.failed"
    )]
    [JsonSubtypes.KnownSubType(
        typeof(EventActionAttemptSimulateKeypadCodeEntrySucceeded),
        "action_attempt.simulate_keypad_code_entry.succeeded"
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
        typeof(EventConnectedAccountReauthorizationRequested),
        "connected_account.reauthorization_requested"
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
    [JsonSubtypes.KnownSubType(typeof(EventAcsEntranceRemoved), "acs_entrance.removed")]
    [JsonSubtypes.KnownSubType(typeof(EventAcsEntranceAdded), "acs_entrance.added")]
    [JsonSubtypes.KnownSubType(typeof(EventAcsAccessGroupDeleted), "acs_access_group.deleted")]
    [JsonSubtypes.KnownSubType(typeof(EventAcsEncoderRemoved), "acs_encoder.removed")]
    [JsonSubtypes.KnownSubType(typeof(EventAcsEncoderAdded), "acs_encoder.added")]
    [JsonSubtypes.KnownSubType(typeof(EventAcsUserDeleted), "acs_user.deleted")]
    [JsonSubtypes.KnownSubType(typeof(EventAcsUserCreated), "acs_user.created")]
    [JsonSubtypes.KnownSubType(typeof(EventAcsCredentialInvalidated), "acs_credential.invalidated")]
    [JsonSubtypes.KnownSubType(typeof(EventAcsCredentialReissued), "acs_credential.reissued")]
    [JsonSubtypes.KnownSubType(typeof(EventAcsCredentialIssued), "acs_credential.issued")]
    [JsonSubtypes.KnownSubType(typeof(EventAcsCredentialDeleted), "acs_credential.deleted")]
    [JsonSubtypes.KnownSubType(typeof(EventAcsSystemDisconnected), "acs_system.disconnected")]
    [JsonSubtypes.KnownSubType(typeof(EventAcsSystemAdded), "acs_system.added")]
    [JsonSubtypes.KnownSubType(typeof(EventAcsSystemConnected), "acs_system.connected")]
    [JsonSubtypes.KnownSubType(
        typeof(EventAccessMethodFailedToIssue),
        "access_method.failed_to_issue"
    )]
    [JsonSubtypes.KnownSubType(
        typeof(EventAccessMethodDelayInIssuing),
        "access_method.delay_in_issuing"
    )]
    [JsonSubtypes.KnownSubType(typeof(EventAccessMethodCreated), "access_method.created")]
    [JsonSubtypes.KnownSubType(typeof(EventAccessMethodReissued), "access_method.reissued")]
    [JsonSubtypes.KnownSubType(typeof(EventAccessMethodDeleted), "access_method.deleted")]
    [JsonSubtypes.KnownSubType(
        typeof(EventAccessMethodCardEncodingRequired),
        "access_method.card_encoding_required"
    )]
    [JsonSubtypes.KnownSubType(typeof(EventAccessMethodRevoked), "access_method.revoked")]
    [JsonSubtypes.KnownSubType(typeof(EventAccessMethodIssued), "access_method.issued")]
    [JsonSubtypes.KnownSubType(
        typeof(EventAccessGrantCouldNotCreateRequestedAccessMethods),
        "access_grant.could_not_create_requested_access_methods"
    )]
    [JsonSubtypes.KnownSubType(
        typeof(EventAccessGrantAccessTimesChanged),
        "access_grant.access_times_changed"
    )]
    [JsonSubtypes.KnownSubType(
        typeof(EventAccessGrantAccessToDoorLost),
        "access_grant.access_to_door_lost"
    )]
    [JsonSubtypes.KnownSubType(
        typeof(EventAccessGrantAccessGrantedToDoor),
        "access_grant.access_granted_to_door"
    )]
    [JsonSubtypes.KnownSubType(
        typeof(EventAccessGrantAccessGrantedToAllDoors),
        "access_grant.access_granted_to_all_doors"
    )]
    [JsonSubtypes.KnownSubType(typeof(EventAccessGrantDeleted), "access_grant.deleted")]
    [JsonSubtypes.KnownSubType(typeof(EventAccessGrantCreated), "access_grant.created")]
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
    [JsonSubtypes.KnownSubType(
        typeof(EventAccessCodeMutationsRequested),
        "access_code.mutations_requested"
    )]
    [JsonSubtypes.KnownSubType(
        typeof(EventAccessCodeTimeFrameChanged),
        "access_code.time_frame_changed"
    )]
    [JsonSubtypes.KnownSubType(typeof(EventAccessCodeCodeChanged), "access_code.code_changed")]
    [JsonSubtypes.KnownSubType(typeof(EventAccessCodeNameChanged), "access_code.name_changed")]
    [JsonSubtypes.KnownSubType(typeof(EventAccessCodeChanged), "access_code.changed")]
    [JsonSubtypes.KnownSubType(typeof(EventAccessCodeCreated), "access_code.created")]
    public abstract class Event
    {
        public abstract string EventType { get; }

        public abstract string CreatedAt { get; set; }

        public abstract string? EventDescription { get; set; }

        public abstract string EventId { get; set; }

        public abstract string OccurredAt { get; set; }

        public abstract string WorkspaceId { get; set; }

        public abstract override string ToString();
    }

    /// <summary>
    /// An [access code](https://docs.seam.co/low-level-apis/smart-locks/access-codes) was created.
    /// </summary>
    [DataContract(Name = "seamModel_eventAccessCodeCreated_model")]
    public class EventAccessCodeCreated : Event
    {
        [JsonConstructorAttribute]
        protected EventAccessCodeCreated() { }

        public EventAccessCodeCreated(
            string accessCodeId = default,
            object? connectedAccountCustomMetadata = default,
            string connectedAccountId = default,
            string createdAt = default,
            object? deviceCustomMetadata = default,
            string deviceId = default,
            string? eventDescription = default,
            string eventId = default,
            string eventType = default,
            string occurredAt = default,
            string workspaceId = default
        )
        {
            AccessCodeId = accessCodeId;
            ConnectedAccountCustomMetadata = connectedAccountCustomMetadata;
            ConnectedAccountId = connectedAccountId;
            CreatedAt = createdAt;
            DeviceCustomMetadata = deviceCustomMetadata;
            DeviceId = deviceId;
            EventDescription = eventDescription;
            EventId = eventId;
            EventType = eventType;
            OccurredAt = occurredAt;
            WorkspaceId = workspaceId;
        }

        /// <summary>
        /// ID of the affected access code.
        /// </summary>
        [DataMember(Name = "access_code_id", IsRequired = false, EmitDefaultValue = false)]
        public string AccessCodeId { get; set; }

        /// <summary>
        /// Custom metadata of the connected account, present when connected_account_id is provided.
        /// </summary>
        [DataMember(
            Name = "connected_account_custom_metadata",
            IsRequired = false,
            EmitDefaultValue = false
        )]
        public object? ConnectedAccountCustomMetadata { get; set; }

        /// <summary>
        /// ID of the connected account associated with the affected access code.
        /// </summary>
        [DataMember(Name = "connected_account_id", IsRequired = false, EmitDefaultValue = false)]
        public string ConnectedAccountId { get; set; }

        /// <summary>
        /// Date and time at which the event was created.
        /// </summary>
        [DataMember(Name = "created_at", IsRequired = false, EmitDefaultValue = false)]
        public override string CreatedAt { get; set; }

        /// <summary>
        /// Custom metadata of the device, present when device_id is provided.
        /// </summary>
        [DataMember(Name = "device_custom_metadata", IsRequired = false, EmitDefaultValue = false)]
        public object? DeviceCustomMetadata { get; set; }

        /// <summary>
        /// ID of the device associated with the affected access code.
        /// </summary>
        [DataMember(Name = "device_id", IsRequired = false, EmitDefaultValue = false)]
        public string DeviceId { get; set; }

        /// <summary>
        /// Human-readable description of the event. Persisted when the event is created (so the creating code, including a provider, can supply a tailored description) and otherwise derived from the event.
        /// </summary>
        [DataMember(Name = "event_description", IsRequired = false, EmitDefaultValue = false)]
        public override string? EventDescription { get; set; }

        /// <summary>
        /// ID of the event.
        /// </summary>
        [DataMember(Name = "event_id", IsRequired = false, EmitDefaultValue = false)]
        public override string EventId { get; set; }

        [DataMember(Name = "event_type", IsRequired = true, EmitDefaultValue = false)]
        public override string EventType { get; } = "access_code.created";

        /// <summary>
        /// Date and time at which the event occurred.
        /// </summary>
        [DataMember(Name = "occurred_at", IsRequired = false, EmitDefaultValue = false)]
        public override string OccurredAt { get; set; }

        /// <summary>
        /// ID of the workspace associated with the event.
        /// </summary>
        [DataMember(Name = "workspace_id", IsRequired = false, EmitDefaultValue = false)]
        public override string WorkspaceId { get; set; }

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
    /// An [access code](https://docs.seam.co/low-level-apis/smart-locks/access-codes) was changed.
    /// </summary>
    [DataContract(Name = "seamModel_eventAccessCodeChanged_model")]
    public class EventAccessCodeChanged : Event
    {
        [JsonConstructorAttribute]
        protected EventAccessCodeChanged() { }

        public EventAccessCodeChanged(
            string accessCodeId = default,
            string? changeReason = default,
            List<EventAccessCodeChangedChangedProperties>? changedProperties = default,
            object? connectedAccountCustomMetadata = default,
            string connectedAccountId = default,
            string createdAt = default,
            object? deviceCustomMetadata = default,
            string deviceId = default,
            string? eventDescription = default,
            string eventId = default,
            string eventType = default,
            string occurredAt = default,
            string workspaceId = default
        )
        {
            AccessCodeId = accessCodeId;
            ChangeReason = changeReason;
            ChangedProperties = changedProperties;
            ConnectedAccountCustomMetadata = connectedAccountCustomMetadata;
            ConnectedAccountId = connectedAccountId;
            CreatedAt = createdAt;
            DeviceCustomMetadata = deviceCustomMetadata;
            DeviceId = deviceId;
            EventDescription = eventDescription;
            EventId = eventId;
            EventType = eventType;
            OccurredAt = occurredAt;
            WorkspaceId = workspaceId;
        }

        /// <summary>
        /// ID of the affected access code.
        /// </summary>
        [DataMember(Name = "access_code_id", IsRequired = false, EmitDefaultValue = false)]
        public string AccessCodeId { get; set; }

        /// <summary>
        /// Human-readable reason for the change (e.g. `ongoing code auto-renewed`).
        /// </summary>
        [DataMember(Name = "change_reason", IsRequired = false, EmitDefaultValue = false)]
        public string? ChangeReason { get; set; }

        /// <summary>
        /// List of properties that changed on the access code.
        /// </summary>
        [DataMember(Name = "changed_properties", IsRequired = false, EmitDefaultValue = false)]
        public List<EventAccessCodeChangedChangedProperties>? ChangedProperties { get; set; }

        /// <summary>
        /// Custom metadata of the connected account, present when connected_account_id is provided.
        /// </summary>
        [DataMember(
            Name = "connected_account_custom_metadata",
            IsRequired = false,
            EmitDefaultValue = false
        )]
        public object? ConnectedAccountCustomMetadata { get; set; }

        /// <summary>
        /// ID of the connected account associated with the affected access code.
        /// </summary>
        [DataMember(Name = "connected_account_id", IsRequired = false, EmitDefaultValue = false)]
        public string ConnectedAccountId { get; set; }

        /// <summary>
        /// Date and time at which the event was created.
        /// </summary>
        [DataMember(Name = "created_at", IsRequired = false, EmitDefaultValue = false)]
        public override string CreatedAt { get; set; }

        /// <summary>
        /// Custom metadata of the device, present when device_id is provided.
        /// </summary>
        [DataMember(Name = "device_custom_metadata", IsRequired = false, EmitDefaultValue = false)]
        public object? DeviceCustomMetadata { get; set; }

        /// <summary>
        /// ID of the device associated with the affected access code.
        /// </summary>
        [DataMember(Name = "device_id", IsRequired = false, EmitDefaultValue = false)]
        public string DeviceId { get; set; }

        /// <summary>
        /// Human-readable description of the event. Persisted when the event is created (so the creating code, including a provider, can supply a tailored description) and otherwise derived from the event.
        /// </summary>
        [DataMember(Name = "event_description", IsRequired = false, EmitDefaultValue = false)]
        public override string? EventDescription { get; set; }

        /// <summary>
        /// ID of the event.
        /// </summary>
        [DataMember(Name = "event_id", IsRequired = false, EmitDefaultValue = false)]
        public override string EventId { get; set; }

        [DataMember(Name = "event_type", IsRequired = true, EmitDefaultValue = false)]
        public override string EventType { get; } = "access_code.changed";

        /// <summary>
        /// Date and time at which the event occurred.
        /// </summary>
        [DataMember(Name = "occurred_at", IsRequired = false, EmitDefaultValue = false)]
        public override string OccurredAt { get; set; }

        /// <summary>
        /// ID of the workspace associated with the event.
        /// </summary>
        [DataMember(Name = "workspace_id", IsRequired = false, EmitDefaultValue = false)]
        public override string WorkspaceId { get; set; }

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

    [DataContract(Name = "seamModel_eventAccessCodeChangedChangedProperties_model")]
    public class EventAccessCodeChangedChangedProperties
    {
        [JsonConstructorAttribute]
        protected EventAccessCodeChangedChangedProperties() { }

        public EventAccessCodeChangedChangedProperties(
            string? from = default,
            string property = default,
            string? to = default
        )
        {
            From = from;
            Property = property;
            To = to;
        }

        /// <summary>
        /// Previous value of the property, or null if not set.
        /// </summary>
        [DataMember(Name = "from", IsRequired = false, EmitDefaultValue = false)]
        public string? From { get; set; }

        /// <summary>
        /// Name of the property that changed (e.g. `code`).
        /// </summary>
        [DataMember(Name = "property", IsRequired = false, EmitDefaultValue = false)]
        public string Property { get; set; }

        /// <summary>
        /// New value of the property, or null if cleared.
        /// </summary>
        [DataMember(Name = "to", IsRequired = false, EmitDefaultValue = false)]
        public string? To { get; set; }

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
    /// The name of an [access code](https://docs.seam.co/low-level-apis/smart-locks/access-codes) was changed on the device.
    /// </summary>
    [DataContract(Name = "seamModel_eventAccessCodeNameChanged_model")]
    public class EventAccessCodeNameChanged : Event
    {
        [JsonConstructorAttribute]
        protected EventAccessCodeNameChanged() { }

        public EventAccessCodeNameChanged(
            string accessCodeId = default,
            object? connectedAccountCustomMetadata = default,
            string connectedAccountId = default,
            string createdAt = default,
            string description = default,
            object? deviceCustomMetadata = default,
            string deviceId = default,
            string? eventDescription = default,
            string eventId = default,
            string eventType = default,
            EventAccessCodeNameChangedFrom from = default,
            string occurredAt = default,
            EventAccessCodeNameChangedTo to = default,
            string workspaceId = default
        )
        {
            AccessCodeId = accessCodeId;
            ConnectedAccountCustomMetadata = connectedAccountCustomMetadata;
            ConnectedAccountId = connectedAccountId;
            CreatedAt = createdAt;
            Description = description;
            DeviceCustomMetadata = deviceCustomMetadata;
            DeviceId = deviceId;
            EventDescription = eventDescription;
            EventId = eventId;
            EventType = eventType;
            From = from;
            OccurredAt = occurredAt;
            To = to;
            WorkspaceId = workspaceId;
        }

        /// <summary>
        /// ID of the affected access code.
        /// </summary>
        [DataMember(Name = "access_code_id", IsRequired = false, EmitDefaultValue = false)]
        public string AccessCodeId { get; set; }

        /// <summary>
        /// Custom metadata of the connected account, present when connected_account_id is provided.
        /// </summary>
        [DataMember(
            Name = "connected_account_custom_metadata",
            IsRequired = false,
            EmitDefaultValue = false
        )]
        public object? ConnectedAccountCustomMetadata { get; set; }

        /// <summary>
        /// ID of the connected account associated with the affected access code.
        /// </summary>
        [DataMember(Name = "connected_account_id", IsRequired = false, EmitDefaultValue = false)]
        public string ConnectedAccountId { get; set; }

        /// <summary>
        /// Date and time at which the event was created.
        /// </summary>
        [DataMember(Name = "created_at", IsRequired = false, EmitDefaultValue = false)]
        public override string CreatedAt { get; set; }

        /// <summary>
        /// Human-readable description of the change and its source.
        /// </summary>
        [DataMember(Name = "description", IsRequired = false, EmitDefaultValue = false)]
        public string Description { get; set; }

        /// <summary>
        /// Custom metadata of the device, present when device_id is provided.
        /// </summary>
        [DataMember(Name = "device_custom_metadata", IsRequired = false, EmitDefaultValue = false)]
        public object? DeviceCustomMetadata { get; set; }

        /// <summary>
        /// ID of the device associated with the affected access code.
        /// </summary>
        [DataMember(Name = "device_id", IsRequired = false, EmitDefaultValue = false)]
        public string DeviceId { get; set; }

        /// <summary>
        /// Human-readable description of the event. Persisted when the event is created (so the creating code, including a provider, can supply a tailored description) and otherwise derived from the event.
        /// </summary>
        [DataMember(Name = "event_description", IsRequired = false, EmitDefaultValue = false)]
        public override string? EventDescription { get; set; }

        /// <summary>
        /// ID of the event.
        /// </summary>
        [DataMember(Name = "event_id", IsRequired = false, EmitDefaultValue = false)]
        public override string EventId { get; set; }

        [DataMember(Name = "event_type", IsRequired = true, EmitDefaultValue = false)]
        public override string EventType { get; } = "access_code.name_changed";

        /// <summary>
        /// Previous access code name configuration.
        /// </summary>
        [DataMember(Name = "from", IsRequired = false, EmitDefaultValue = false)]
        public EventAccessCodeNameChangedFrom From { get; set; }

        /// <summary>
        /// Date and time at which the event occurred.
        /// </summary>
        [DataMember(Name = "occurred_at", IsRequired = false, EmitDefaultValue = false)]
        public override string OccurredAt { get; set; }

        /// <summary>
        /// New access code name configuration.
        /// </summary>
        [DataMember(Name = "to", IsRequired = false, EmitDefaultValue = false)]
        public EventAccessCodeNameChangedTo To { get; set; }

        /// <summary>
        /// ID of the workspace associated with the event.
        /// </summary>
        [DataMember(Name = "workspace_id", IsRequired = false, EmitDefaultValue = false)]
        public override string WorkspaceId { get; set; }

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

    [DataContract(Name = "seamModel_eventAccessCodeNameChangedFrom_model")]
    public class EventAccessCodeNameChangedFrom
    {
        [JsonConstructorAttribute]
        protected EventAccessCodeNameChangedFrom() { }

        public EventAccessCodeNameChangedFrom(string? name = default)
        {
            Name = name;
        }

        /// <summary>
        /// Previous name of the access code.
        /// </summary>
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

    [DataContract(Name = "seamModel_eventAccessCodeNameChangedTo_model")]
    public class EventAccessCodeNameChangedTo
    {
        [JsonConstructorAttribute]
        protected EventAccessCodeNameChangedTo() { }

        public EventAccessCodeNameChangedTo(string? name = default)
        {
            Name = name;
        }

        /// <summary>
        /// New name of the access code.
        /// </summary>
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

    /// <summary>
    /// The pin code of an [access code](https://docs.seam.co/low-level-apis/smart-locks/access-codes) was changed on the device.
    /// </summary>
    [DataContract(Name = "seamModel_eventAccessCodeCodeChanged_model")]
    public class EventAccessCodeCodeChanged : Event
    {
        [JsonConstructorAttribute]
        protected EventAccessCodeCodeChanged() { }

        public EventAccessCodeCodeChanged(
            string accessCodeId = default,
            object? connectedAccountCustomMetadata = default,
            string connectedAccountId = default,
            string createdAt = default,
            string description = default,
            object? deviceCustomMetadata = default,
            string deviceId = default,
            string? eventDescription = default,
            string eventId = default,
            string eventType = default,
            EventAccessCodeCodeChangedFrom from = default,
            string occurredAt = default,
            EventAccessCodeCodeChangedTo to = default,
            string workspaceId = default
        )
        {
            AccessCodeId = accessCodeId;
            ConnectedAccountCustomMetadata = connectedAccountCustomMetadata;
            ConnectedAccountId = connectedAccountId;
            CreatedAt = createdAt;
            Description = description;
            DeviceCustomMetadata = deviceCustomMetadata;
            DeviceId = deviceId;
            EventDescription = eventDescription;
            EventId = eventId;
            EventType = eventType;
            From = from;
            OccurredAt = occurredAt;
            To = to;
            WorkspaceId = workspaceId;
        }

        /// <summary>
        /// ID of the affected access code.
        /// </summary>
        [DataMember(Name = "access_code_id", IsRequired = false, EmitDefaultValue = false)]
        public string AccessCodeId { get; set; }

        /// <summary>
        /// Custom metadata of the connected account, present when connected_account_id is provided.
        /// </summary>
        [DataMember(
            Name = "connected_account_custom_metadata",
            IsRequired = false,
            EmitDefaultValue = false
        )]
        public object? ConnectedAccountCustomMetadata { get; set; }

        /// <summary>
        /// ID of the connected account associated with the affected access code.
        /// </summary>
        [DataMember(Name = "connected_account_id", IsRequired = false, EmitDefaultValue = false)]
        public string ConnectedAccountId { get; set; }

        /// <summary>
        /// Date and time at which the event was created.
        /// </summary>
        [DataMember(Name = "created_at", IsRequired = false, EmitDefaultValue = false)]
        public override string CreatedAt { get; set; }

        /// <summary>
        /// Human-readable description of the change and its source.
        /// </summary>
        [DataMember(Name = "description", IsRequired = false, EmitDefaultValue = false)]
        public string Description { get; set; }

        /// <summary>
        /// Custom metadata of the device, present when device_id is provided.
        /// </summary>
        [DataMember(Name = "device_custom_metadata", IsRequired = false, EmitDefaultValue = false)]
        public object? DeviceCustomMetadata { get; set; }

        /// <summary>
        /// ID of the device associated with the affected access code.
        /// </summary>
        [DataMember(Name = "device_id", IsRequired = false, EmitDefaultValue = false)]
        public string DeviceId { get; set; }

        /// <summary>
        /// Human-readable description of the event. Persisted when the event is created (so the creating code, including a provider, can supply a tailored description) and otherwise derived from the event.
        /// </summary>
        [DataMember(Name = "event_description", IsRequired = false, EmitDefaultValue = false)]
        public override string? EventDescription { get; set; }

        /// <summary>
        /// ID of the event.
        /// </summary>
        [DataMember(Name = "event_id", IsRequired = false, EmitDefaultValue = false)]
        public override string EventId { get; set; }

        [DataMember(Name = "event_type", IsRequired = true, EmitDefaultValue = false)]
        public override string EventType { get; } = "access_code.code_changed";

        /// <summary>
        /// Previous pin code configuration.
        /// </summary>
        [DataMember(Name = "from", IsRequired = false, EmitDefaultValue = false)]
        public EventAccessCodeCodeChangedFrom From { get; set; }

        /// <summary>
        /// Date and time at which the event occurred.
        /// </summary>
        [DataMember(Name = "occurred_at", IsRequired = false, EmitDefaultValue = false)]
        public override string OccurredAt { get; set; }

        /// <summary>
        /// New pin code configuration.
        /// </summary>
        [DataMember(Name = "to", IsRequired = false, EmitDefaultValue = false)]
        public EventAccessCodeCodeChangedTo To { get; set; }

        /// <summary>
        /// ID of the workspace associated with the event.
        /// </summary>
        [DataMember(Name = "workspace_id", IsRequired = false, EmitDefaultValue = false)]
        public override string WorkspaceId { get; set; }

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

    [DataContract(Name = "seamModel_eventAccessCodeCodeChangedFrom_model")]
    public class EventAccessCodeCodeChangedFrom
    {
        [JsonConstructorAttribute]
        protected EventAccessCodeCodeChangedFrom() { }

        public EventAccessCodeCodeChangedFrom(string? code = default)
        {
            Code = code;
        }

        /// <summary>
        /// Previous pin code.
        /// </summary>
        [DataMember(Name = "code", IsRequired = false, EmitDefaultValue = false)]
        public string? Code { get; set; }

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

    [DataContract(Name = "seamModel_eventAccessCodeCodeChangedTo_model")]
    public class EventAccessCodeCodeChangedTo
    {
        [JsonConstructorAttribute]
        protected EventAccessCodeCodeChangedTo() { }

        public EventAccessCodeCodeChangedTo(string? code = default)
        {
            Code = code;
        }

        /// <summary>
        /// New pin code.
        /// </summary>
        [DataMember(Name = "code", IsRequired = false, EmitDefaultValue = false)]
        public string? Code { get; set; }

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
    /// The time frame of an [access code](https://docs.seam.co/low-level-apis/smart-locks/access-codes) was changed on the device.
    /// </summary>
    [DataContract(Name = "seamModel_eventAccessCodeTimeFrameChanged_model")]
    public class EventAccessCodeTimeFrameChanged : Event
    {
        [JsonConstructorAttribute]
        protected EventAccessCodeTimeFrameChanged() { }

        public EventAccessCodeTimeFrameChanged(
            string accessCodeId = default,
            object? connectedAccountCustomMetadata = default,
            string connectedAccountId = default,
            string createdAt = default,
            string description = default,
            object? deviceCustomMetadata = default,
            string deviceId = default,
            string? eventDescription = default,
            string eventId = default,
            string eventType = default,
            EventAccessCodeTimeFrameChangedFrom from = default,
            string occurredAt = default,
            EventAccessCodeTimeFrameChangedTo to = default,
            string workspaceId = default
        )
        {
            AccessCodeId = accessCodeId;
            ConnectedAccountCustomMetadata = connectedAccountCustomMetadata;
            ConnectedAccountId = connectedAccountId;
            CreatedAt = createdAt;
            Description = description;
            DeviceCustomMetadata = deviceCustomMetadata;
            DeviceId = deviceId;
            EventDescription = eventDescription;
            EventId = eventId;
            EventType = eventType;
            From = from;
            OccurredAt = occurredAt;
            To = to;
            WorkspaceId = workspaceId;
        }

        /// <summary>
        /// ID of the affected access code.
        /// </summary>
        [DataMember(Name = "access_code_id", IsRequired = false, EmitDefaultValue = false)]
        public string AccessCodeId { get; set; }

        /// <summary>
        /// Custom metadata of the connected account, present when connected_account_id is provided.
        /// </summary>
        [DataMember(
            Name = "connected_account_custom_metadata",
            IsRequired = false,
            EmitDefaultValue = false
        )]
        public object? ConnectedAccountCustomMetadata { get; set; }

        /// <summary>
        /// ID of the connected account associated with the affected access code.
        /// </summary>
        [DataMember(Name = "connected_account_id", IsRequired = false, EmitDefaultValue = false)]
        public string ConnectedAccountId { get; set; }

        /// <summary>
        /// Date and time at which the event was created.
        /// </summary>
        [DataMember(Name = "created_at", IsRequired = false, EmitDefaultValue = false)]
        public override string CreatedAt { get; set; }

        /// <summary>
        /// Human-readable description of the change and its source.
        /// </summary>
        [DataMember(Name = "description", IsRequired = false, EmitDefaultValue = false)]
        public string Description { get; set; }

        /// <summary>
        /// Custom metadata of the device, present when device_id is provided.
        /// </summary>
        [DataMember(Name = "device_custom_metadata", IsRequired = false, EmitDefaultValue = false)]
        public object? DeviceCustomMetadata { get; set; }

        /// <summary>
        /// ID of the device associated with the affected access code.
        /// </summary>
        [DataMember(Name = "device_id", IsRequired = false, EmitDefaultValue = false)]
        public string DeviceId { get; set; }

        /// <summary>
        /// Human-readable description of the event. Persisted when the event is created (so the creating code, including a provider, can supply a tailored description) and otherwise derived from the event.
        /// </summary>
        [DataMember(Name = "event_description", IsRequired = false, EmitDefaultValue = false)]
        public override string? EventDescription { get; set; }

        /// <summary>
        /// ID of the event.
        /// </summary>
        [DataMember(Name = "event_id", IsRequired = false, EmitDefaultValue = false)]
        public override string EventId { get; set; }

        [DataMember(Name = "event_type", IsRequired = true, EmitDefaultValue = false)]
        public override string EventType { get; } = "access_code.time_frame_changed";

        /// <summary>
        /// Previous time frame configuration.
        /// </summary>
        [DataMember(Name = "from", IsRequired = false, EmitDefaultValue = false)]
        public EventAccessCodeTimeFrameChangedFrom From { get; set; }

        /// <summary>
        /// Date and time at which the event occurred.
        /// </summary>
        [DataMember(Name = "occurred_at", IsRequired = false, EmitDefaultValue = false)]
        public override string OccurredAt { get; set; }

        /// <summary>
        /// New time frame configuration.
        /// </summary>
        [DataMember(Name = "to", IsRequired = false, EmitDefaultValue = false)]
        public EventAccessCodeTimeFrameChangedTo To { get; set; }

        /// <summary>
        /// ID of the workspace associated with the event.
        /// </summary>
        [DataMember(Name = "workspace_id", IsRequired = false, EmitDefaultValue = false)]
        public override string WorkspaceId { get; set; }

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

    [DataContract(Name = "seamModel_eventAccessCodeTimeFrameChangedFrom_model")]
    public class EventAccessCodeTimeFrameChangedFrom
    {
        [JsonConstructorAttribute]
        protected EventAccessCodeTimeFrameChangedFrom() { }

        public EventAccessCodeTimeFrameChangedFrom(
            string? endsAt = default,
            string? startsAt = default
        )
        {
            EndsAt = endsAt;
            StartsAt = startsAt;
        }

        /// <summary>
        /// Previous end time.
        /// </summary>
        [DataMember(Name = "ends_at", IsRequired = false, EmitDefaultValue = false)]
        public string? EndsAt { get; set; }

        /// <summary>
        /// Previous start time.
        /// </summary>
        [DataMember(Name = "starts_at", IsRequired = false, EmitDefaultValue = false)]
        public string? StartsAt { get; set; }

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

    [DataContract(Name = "seamModel_eventAccessCodeTimeFrameChangedTo_model")]
    public class EventAccessCodeTimeFrameChangedTo
    {
        [JsonConstructorAttribute]
        protected EventAccessCodeTimeFrameChangedTo() { }

        public EventAccessCodeTimeFrameChangedTo(
            string? endsAt = default,
            string? startsAt = default
        )
        {
            EndsAt = endsAt;
            StartsAt = startsAt;
        }

        /// <summary>
        /// New end time.
        /// </summary>
        [DataMember(Name = "ends_at", IsRequired = false, EmitDefaultValue = false)]
        public string? EndsAt { get; set; }

        /// <summary>
        /// New start time.
        /// </summary>
        [DataMember(Name = "starts_at", IsRequired = false, EmitDefaultValue = false)]
        public string? StartsAt { get; set; }

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
    /// Mutations were requested on an [access code](https://docs.seam.co/low-level-apis/smart-locks/access-codes). This event fires at request time, before the change is confirmed on the device.
    /// </summary>
    [DataContract(Name = "seamModel_eventAccessCodeMutationsRequested_model")]
    public class EventAccessCodeMutationsRequested : Event
    {
        [JsonConstructorAttribute]
        protected EventAccessCodeMutationsRequested() { }

        public EventAccessCodeMutationsRequested(
            string accessCodeId = default,
            object? connectedAccountCustomMetadata = default,
            string connectedAccountId = default,
            string createdAt = default,
            object? deviceCustomMetadata = default,
            string deviceId = default,
            string? eventDescription = default,
            string eventId = default,
            string eventType = default,
            string occurredAt = default,
            List<EventAccessCodeMutationsRequestedRequestedMutations> requestedMutations = default,
            string workspaceId = default
        )
        {
            AccessCodeId = accessCodeId;
            ConnectedAccountCustomMetadata = connectedAccountCustomMetadata;
            ConnectedAccountId = connectedAccountId;
            CreatedAt = createdAt;
            DeviceCustomMetadata = deviceCustomMetadata;
            DeviceId = deviceId;
            EventDescription = eventDescription;
            EventId = eventId;
            EventType = eventType;
            OccurredAt = occurredAt;
            RequestedMutations = requestedMutations;
            WorkspaceId = workspaceId;
        }

        /// <summary>
        /// ID of the affected access code.
        /// </summary>
        [DataMember(Name = "access_code_id", IsRequired = false, EmitDefaultValue = false)]
        public string AccessCodeId { get; set; }

        /// <summary>
        /// Custom metadata of the connected account, present when connected_account_id is provided.
        /// </summary>
        [DataMember(
            Name = "connected_account_custom_metadata",
            IsRequired = false,
            EmitDefaultValue = false
        )]
        public object? ConnectedAccountCustomMetadata { get; set; }

        /// <summary>
        /// ID of the connected account associated with the affected access code.
        /// </summary>
        [DataMember(Name = "connected_account_id", IsRequired = false, EmitDefaultValue = false)]
        public string ConnectedAccountId { get; set; }

        /// <summary>
        /// Date and time at which the event was created.
        /// </summary>
        [DataMember(Name = "created_at", IsRequired = false, EmitDefaultValue = false)]
        public override string CreatedAt { get; set; }

        /// <summary>
        /// Custom metadata of the device, present when device_id is provided.
        /// </summary>
        [DataMember(Name = "device_custom_metadata", IsRequired = false, EmitDefaultValue = false)]
        public object? DeviceCustomMetadata { get; set; }

        /// <summary>
        /// ID of the device associated with the affected access code.
        /// </summary>
        [DataMember(Name = "device_id", IsRequired = false, EmitDefaultValue = false)]
        public string DeviceId { get; set; }

        /// <summary>
        /// Human-readable description of the event. Persisted when the event is created (so the creating code, including a provider, can supply a tailored description) and otherwise derived from the event.
        /// </summary>
        [DataMember(Name = "event_description", IsRequired = false, EmitDefaultValue = false)]
        public override string? EventDescription { get; set; }

        /// <summary>
        /// ID of the event.
        /// </summary>
        [DataMember(Name = "event_id", IsRequired = false, EmitDefaultValue = false)]
        public override string EventId { get; set; }

        [DataMember(Name = "event_type", IsRequired = true, EmitDefaultValue = false)]
        public override string EventType { get; } = "access_code.mutations_requested";

        /// <summary>
        /// Date and time at which the event occurred.
        /// </summary>
        [DataMember(Name = "occurred_at", IsRequired = false, EmitDefaultValue = false)]
        public override string OccurredAt { get; set; }

        /// <summary>
        /// Array of mutations requested on the access code, each containing the mutation type and from/to values.
        /// </summary>
        [DataMember(Name = "requested_mutations", IsRequired = false, EmitDefaultValue = false)]
        public List<EventAccessCodeMutationsRequestedRequestedMutations> RequestedMutations { get; set; }

        /// <summary>
        /// ID of the workspace associated with the event.
        /// </summary>
        [DataMember(Name = "workspace_id", IsRequired = false, EmitDefaultValue = false)]
        public override string WorkspaceId { get; set; }

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

    [DataContract(Name = "seamModel_eventAccessCodeMutationsRequestedRequestedMutations_model")]
    public class EventAccessCodeMutationsRequestedRequestedMutations
    {
        [JsonConstructorAttribute]
        protected EventAccessCodeMutationsRequestedRequestedMutations() { }

        public EventAccessCodeMutationsRequestedRequestedMutations(
            object? from = default,
            EventAccessCodeMutationsRequestedRequestedMutations.MutationCodeEnum mutationCode =
                default,
            object? to = default
        )
        {
            From = from;
            MutationCode = mutationCode;
            To = to;
        }

        /// <summary>
        /// Code identifying the type of mutation requested, such as `updating_name`, `updating_code`, `updating_time_frame`, or `deleting`.
        /// </summary>
        [JsonConverter(typeof(SafeStringEnumConverter))]
        public enum MutationCodeEnum
        {
            [EnumMember(Value = "unrecognized")]
            Unrecognized = 0,

            [EnumMember(Value = "updating_name")]
            UpdatingName = 1,

            [EnumMember(Value = "updating_code")]
            UpdatingCode = 2,

            [EnumMember(Value = "updating_time_frame")]
            UpdatingTimeFrame = 3,

            [EnumMember(Value = "deleting")]
            Deleting = 4,

            [EnumMember(Value = "creating")]
            Creating = 5,

            [EnumMember(Value = "deferring_creation")]
            DeferringCreation = 6,
        }

        /// <summary>
        /// Previous property values before the requested change. Keys depend on the mutation type. Absent for non-property mutations like `deleting`.
        /// </summary>
        [DataMember(Name = "from", IsRequired = false, EmitDefaultValue = false)]
        public object? From { get; set; }

        /// <summary>
        /// Code identifying the type of mutation requested, such as `updating_name`, `updating_code`, `updating_time_frame`, or `deleting`.
        /// </summary>
        [DataMember(Name = "mutation_code", IsRequired = false, EmitDefaultValue = false)]
        public EventAccessCodeMutationsRequestedRequestedMutations.MutationCodeEnum MutationCode { get; set; }

        /// <summary>
        /// New property values after the requested change. Keys depend on the mutation type. Absent for non-property mutations like `deleting`.
        /// </summary>
        [DataMember(Name = "to", IsRequired = false, EmitDefaultValue = false)]
        public object? To { get; set; }

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
    /// An [access code](https://docs.seam.co/low-level-apis/smart-locks/access-codes) was [scheduled natively](https://docs.seam.co/low-level-apis/smart-locks/access-codes#native-scheduling) on a device.
    /// </summary>
    [DataContract(Name = "seamModel_eventAccessCodeScheduledOnDevice_model")]
    public class EventAccessCodeScheduledOnDevice : Event
    {
        [JsonConstructorAttribute]
        protected EventAccessCodeScheduledOnDevice() { }

        public EventAccessCodeScheduledOnDevice(
            string accessCodeId = default,
            string code = default,
            object? connectedAccountCustomMetadata = default,
            string connectedAccountId = default,
            string createdAt = default,
            object? deviceCustomMetadata = default,
            string deviceId = default,
            string? eventDescription = default,
            string eventId = default,
            string eventType = default,
            string occurredAt = default,
            string workspaceId = default
        )
        {
            AccessCodeId = accessCodeId;
            Code = code;
            ConnectedAccountCustomMetadata = connectedAccountCustomMetadata;
            ConnectedAccountId = connectedAccountId;
            CreatedAt = createdAt;
            DeviceCustomMetadata = deviceCustomMetadata;
            DeviceId = deviceId;
            EventDescription = eventDescription;
            EventId = eventId;
            EventType = eventType;
            OccurredAt = occurredAt;
            WorkspaceId = workspaceId;
        }

        /// <summary>
        /// ID of the affected access code.
        /// </summary>
        [DataMember(Name = "access_code_id", IsRequired = false, EmitDefaultValue = false)]
        public string AccessCodeId { get; set; }

        /// <summary>
        /// Code for the affected access code.
        /// </summary>
        [DataMember(Name = "code", IsRequired = false, EmitDefaultValue = false)]
        public string Code { get; set; }

        /// <summary>
        /// Custom metadata of the connected account, present when connected_account_id is provided.
        /// </summary>
        [DataMember(
            Name = "connected_account_custom_metadata",
            IsRequired = false,
            EmitDefaultValue = false
        )]
        public object? ConnectedAccountCustomMetadata { get; set; }

        /// <summary>
        /// ID of the connected account associated with the affected access code.
        /// </summary>
        [DataMember(Name = "connected_account_id", IsRequired = false, EmitDefaultValue = false)]
        public string ConnectedAccountId { get; set; }

        /// <summary>
        /// Date and time at which the event was created.
        /// </summary>
        [DataMember(Name = "created_at", IsRequired = false, EmitDefaultValue = false)]
        public override string CreatedAt { get; set; }

        /// <summary>
        /// Custom metadata of the device, present when device_id is provided.
        /// </summary>
        [DataMember(Name = "device_custom_metadata", IsRequired = false, EmitDefaultValue = false)]
        public object? DeviceCustomMetadata { get; set; }

        /// <summary>
        /// ID of the device associated with the affected access code.
        /// </summary>
        [DataMember(Name = "device_id", IsRequired = false, EmitDefaultValue = false)]
        public string DeviceId { get; set; }

        /// <summary>
        /// Human-readable description of the event. Persisted when the event is created (so the creating code, including a provider, can supply a tailored description) and otherwise derived from the event.
        /// </summary>
        [DataMember(Name = "event_description", IsRequired = false, EmitDefaultValue = false)]
        public override string? EventDescription { get; set; }

        /// <summary>
        /// ID of the event.
        /// </summary>
        [DataMember(Name = "event_id", IsRequired = false, EmitDefaultValue = false)]
        public override string EventId { get; set; }

        [DataMember(Name = "event_type", IsRequired = true, EmitDefaultValue = false)]
        public override string EventType { get; } = "access_code.scheduled_on_device";

        /// <summary>
        /// Date and time at which the event occurred.
        /// </summary>
        [DataMember(Name = "occurred_at", IsRequired = false, EmitDefaultValue = false)]
        public override string OccurredAt { get; set; }

        /// <summary>
        /// ID of the workspace associated with the event.
        /// </summary>
        [DataMember(Name = "workspace_id", IsRequired = false, EmitDefaultValue = false)]
        public override string WorkspaceId { get; set; }

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
    /// An [access code](https://docs.seam.co/low-level-apis/smart-locks/access-codes) was set on a device.
    /// </summary>
    [DataContract(Name = "seamModel_eventAccessCodeSetOnDevice_model")]
    public class EventAccessCodeSetOnDevice : Event
    {
        [JsonConstructorAttribute]
        protected EventAccessCodeSetOnDevice() { }

        public EventAccessCodeSetOnDevice(
            string accessCodeId = default,
            string code = default,
            object? connectedAccountCustomMetadata = default,
            string connectedAccountId = default,
            string createdAt = default,
            object? deviceCustomMetadata = default,
            string deviceId = default,
            string? eventDescription = default,
            string eventId = default,
            string eventType = default,
            string occurredAt = default,
            string workspaceId = default
        )
        {
            AccessCodeId = accessCodeId;
            Code = code;
            ConnectedAccountCustomMetadata = connectedAccountCustomMetadata;
            ConnectedAccountId = connectedAccountId;
            CreatedAt = createdAt;
            DeviceCustomMetadata = deviceCustomMetadata;
            DeviceId = deviceId;
            EventDescription = eventDescription;
            EventId = eventId;
            EventType = eventType;
            OccurredAt = occurredAt;
            WorkspaceId = workspaceId;
        }

        /// <summary>
        /// ID of the affected access code.
        /// </summary>
        [DataMember(Name = "access_code_id", IsRequired = false, EmitDefaultValue = false)]
        public string AccessCodeId { get; set; }

        /// <summary>
        /// Code for the affected access code.
        /// </summary>
        [DataMember(Name = "code", IsRequired = false, EmitDefaultValue = false)]
        public string Code { get; set; }

        /// <summary>
        /// Custom metadata of the connected account, present when connected_account_id is provided.
        /// </summary>
        [DataMember(
            Name = "connected_account_custom_metadata",
            IsRequired = false,
            EmitDefaultValue = false
        )]
        public object? ConnectedAccountCustomMetadata { get; set; }

        /// <summary>
        /// ID of the connected account associated with the affected access code.
        /// </summary>
        [DataMember(Name = "connected_account_id", IsRequired = false, EmitDefaultValue = false)]
        public string ConnectedAccountId { get; set; }

        /// <summary>
        /// Date and time at which the event was created.
        /// </summary>
        [DataMember(Name = "created_at", IsRequired = false, EmitDefaultValue = false)]
        public override string CreatedAt { get; set; }

        /// <summary>
        /// Custom metadata of the device, present when device_id is provided.
        /// </summary>
        [DataMember(Name = "device_custom_metadata", IsRequired = false, EmitDefaultValue = false)]
        public object? DeviceCustomMetadata { get; set; }

        /// <summary>
        /// ID of the device associated with the affected access code.
        /// </summary>
        [DataMember(Name = "device_id", IsRequired = false, EmitDefaultValue = false)]
        public string DeviceId { get; set; }

        /// <summary>
        /// Human-readable description of the event. Persisted when the event is created (so the creating code, including a provider, can supply a tailored description) and otherwise derived from the event.
        /// </summary>
        [DataMember(Name = "event_description", IsRequired = false, EmitDefaultValue = false)]
        public override string? EventDescription { get; set; }

        /// <summary>
        /// ID of the event.
        /// </summary>
        [DataMember(Name = "event_id", IsRequired = false, EmitDefaultValue = false)]
        public override string EventId { get; set; }

        [DataMember(Name = "event_type", IsRequired = true, EmitDefaultValue = false)]
        public override string EventType { get; } = "access_code.set_on_device";

        /// <summary>
        /// Date and time at which the event occurred.
        /// </summary>
        [DataMember(Name = "occurred_at", IsRequired = false, EmitDefaultValue = false)]
        public override string OccurredAt { get; set; }

        /// <summary>
        /// ID of the workspace associated with the event.
        /// </summary>
        [DataMember(Name = "workspace_id", IsRequired = false, EmitDefaultValue = false)]
        public override string WorkspaceId { get; set; }

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
    /// An [access code](https://docs.seam.co/low-level-apis/smart-locks/access-codes) was removed from a device.
    /// </summary>
    [DataContract(Name = "seamModel_eventAccessCodeRemovedFromDevice_model")]
    public class EventAccessCodeRemovedFromDevice : Event
    {
        [JsonConstructorAttribute]
        protected EventAccessCodeRemovedFromDevice() { }

        public EventAccessCodeRemovedFromDevice(
            string accessCodeId = default,
            object? connectedAccountCustomMetadata = default,
            string connectedAccountId = default,
            string createdAt = default,
            object? deviceCustomMetadata = default,
            string deviceId = default,
            string? eventDescription = default,
            string eventId = default,
            string eventType = default,
            string occurredAt = default,
            string workspaceId = default
        )
        {
            AccessCodeId = accessCodeId;
            ConnectedAccountCustomMetadata = connectedAccountCustomMetadata;
            ConnectedAccountId = connectedAccountId;
            CreatedAt = createdAt;
            DeviceCustomMetadata = deviceCustomMetadata;
            DeviceId = deviceId;
            EventDescription = eventDescription;
            EventId = eventId;
            EventType = eventType;
            OccurredAt = occurredAt;
            WorkspaceId = workspaceId;
        }

        /// <summary>
        /// ID of the affected access code.
        /// </summary>
        [DataMember(Name = "access_code_id", IsRequired = false, EmitDefaultValue = false)]
        public string AccessCodeId { get; set; }

        /// <summary>
        /// Custom metadata of the connected account, present when connected_account_id is provided.
        /// </summary>
        [DataMember(
            Name = "connected_account_custom_metadata",
            IsRequired = false,
            EmitDefaultValue = false
        )]
        public object? ConnectedAccountCustomMetadata { get; set; }

        /// <summary>
        /// ID of the connected account associated with the affected access code.
        /// </summary>
        [DataMember(Name = "connected_account_id", IsRequired = false, EmitDefaultValue = false)]
        public string ConnectedAccountId { get; set; }

        /// <summary>
        /// Date and time at which the event was created.
        /// </summary>
        [DataMember(Name = "created_at", IsRequired = false, EmitDefaultValue = false)]
        public override string CreatedAt { get; set; }

        /// <summary>
        /// Custom metadata of the device, present when device_id is provided.
        /// </summary>
        [DataMember(Name = "device_custom_metadata", IsRequired = false, EmitDefaultValue = false)]
        public object? DeviceCustomMetadata { get; set; }

        /// <summary>
        /// ID of the device associated with the affected access code.
        /// </summary>
        [DataMember(Name = "device_id", IsRequired = false, EmitDefaultValue = false)]
        public string DeviceId { get; set; }

        /// <summary>
        /// Human-readable description of the event. Persisted when the event is created (so the creating code, including a provider, can supply a tailored description) and otherwise derived from the event.
        /// </summary>
        [DataMember(Name = "event_description", IsRequired = false, EmitDefaultValue = false)]
        public override string? EventDescription { get; set; }

        /// <summary>
        /// ID of the event.
        /// </summary>
        [DataMember(Name = "event_id", IsRequired = false, EmitDefaultValue = false)]
        public override string EventId { get; set; }

        [DataMember(Name = "event_type", IsRequired = true, EmitDefaultValue = false)]
        public override string EventType { get; } = "access_code.removed_from_device";

        /// <summary>
        /// Date and time at which the event occurred.
        /// </summary>
        [DataMember(Name = "occurred_at", IsRequired = false, EmitDefaultValue = false)]
        public override string OccurredAt { get; set; }

        /// <summary>
        /// ID of the workspace associated with the event.
        /// </summary>
        [DataMember(Name = "workspace_id", IsRequired = false, EmitDefaultValue = false)]
        public override string WorkspaceId { get; set; }

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
    /// There was an unusually long delay in setting an [access code](https://docs.seam.co/low-level-apis/smart-locks/access-codes) on a device.
    /// </summary>
    [DataContract(Name = "seamModel_eventAccessCodeDelayInSettingOnDevice_model")]
    public class EventAccessCodeDelayInSettingOnDevice : Event
    {
        [JsonConstructorAttribute]
        protected EventAccessCodeDelayInSettingOnDevice() { }

        public EventAccessCodeDelayInSettingOnDevice(
            List<EventAccessCodeDelayInSettingOnDeviceAccessCodeErrors> accessCodeErrors = default,
            string accessCodeId = default,
            List<EventAccessCodeDelayInSettingOnDeviceAccessCodeWarnings> accessCodeWarnings =
                default,
            object? connectedAccountCustomMetadata = default,
            List<EventAccessCodeDelayInSettingOnDeviceConnectedAccountErrors> connectedAccountErrors =
                default,
            string connectedAccountId = default,
            List<EventAccessCodeDelayInSettingOnDeviceConnectedAccountWarnings> connectedAccountWarnings =
                default,
            string createdAt = default,
            object? deviceCustomMetadata = default,
            List<EventAccessCodeDelayInSettingOnDeviceDeviceErrors> deviceErrors = default,
            string deviceId = default,
            List<EventAccessCodeDelayInSettingOnDeviceDeviceWarnings> deviceWarnings = default,
            string? eventDescription = default,
            string eventId = default,
            string eventType = default,
            string occurredAt = default,
            string workspaceId = default
        )
        {
            AccessCodeErrors = accessCodeErrors;
            AccessCodeId = accessCodeId;
            AccessCodeWarnings = accessCodeWarnings;
            ConnectedAccountCustomMetadata = connectedAccountCustomMetadata;
            ConnectedAccountErrors = connectedAccountErrors;
            ConnectedAccountId = connectedAccountId;
            ConnectedAccountWarnings = connectedAccountWarnings;
            CreatedAt = createdAt;
            DeviceCustomMetadata = deviceCustomMetadata;
            DeviceErrors = deviceErrors;
            DeviceId = deviceId;
            DeviceWarnings = deviceWarnings;
            EventDescription = eventDescription;
            EventId = eventId;
            EventType = eventType;
            OccurredAt = occurredAt;
            WorkspaceId = workspaceId;
        }

        /// <summary>
        /// Errors associated with the access code.
        /// </summary>
        [DataMember(Name = "access_code_errors", IsRequired = false, EmitDefaultValue = false)]
        public List<EventAccessCodeDelayInSettingOnDeviceAccessCodeErrors> AccessCodeErrors { get; set; }

        /// <summary>
        /// ID of the affected access code.
        /// </summary>
        [DataMember(Name = "access_code_id", IsRequired = false, EmitDefaultValue = false)]
        public string AccessCodeId { get; set; }

        /// <summary>
        /// Warnings associated with the access code.
        /// </summary>
        [DataMember(Name = "access_code_warnings", IsRequired = false, EmitDefaultValue = false)]
        public List<EventAccessCodeDelayInSettingOnDeviceAccessCodeWarnings> AccessCodeWarnings { get; set; }

        /// <summary>
        /// Custom metadata of the connected account, present when connected_account_id is provided.
        /// </summary>
        [DataMember(
            Name = "connected_account_custom_metadata",
            IsRequired = false,
            EmitDefaultValue = false
        )]
        public object? ConnectedAccountCustomMetadata { get; set; }

        /// <summary>
        /// Errors associated with the connected account.
        /// </summary>
        [DataMember(
            Name = "connected_account_errors",
            IsRequired = false,
            EmitDefaultValue = false
        )]
        public List<EventAccessCodeDelayInSettingOnDeviceConnectedAccountErrors> ConnectedAccountErrors { get; set; }

        /// <summary>
        /// ID of the connected account associated with the affected access code.
        /// </summary>
        [DataMember(Name = "connected_account_id", IsRequired = false, EmitDefaultValue = false)]
        public string ConnectedAccountId { get; set; }

        /// <summary>
        /// Warnings associated with the connected account.
        /// </summary>
        [DataMember(
            Name = "connected_account_warnings",
            IsRequired = false,
            EmitDefaultValue = false
        )]
        public List<EventAccessCodeDelayInSettingOnDeviceConnectedAccountWarnings> ConnectedAccountWarnings { get; set; }

        /// <summary>
        /// Date and time at which the event was created.
        /// </summary>
        [DataMember(Name = "created_at", IsRequired = false, EmitDefaultValue = false)]
        public override string CreatedAt { get; set; }

        /// <summary>
        /// Custom metadata of the device, present when device_id is provided.
        /// </summary>
        [DataMember(Name = "device_custom_metadata", IsRequired = false, EmitDefaultValue = false)]
        public object? DeviceCustomMetadata { get; set; }

        /// <summary>
        /// Errors associated with the device.
        /// </summary>
        [DataMember(Name = "device_errors", IsRequired = false, EmitDefaultValue = false)]
        public List<EventAccessCodeDelayInSettingOnDeviceDeviceErrors> DeviceErrors { get; set; }

        /// <summary>
        /// ID of the device associated with the affected access code.
        /// </summary>
        [DataMember(Name = "device_id", IsRequired = false, EmitDefaultValue = false)]
        public string DeviceId { get; set; }

        /// <summary>
        /// Warnings associated with the device.
        /// </summary>
        [DataMember(Name = "device_warnings", IsRequired = false, EmitDefaultValue = false)]
        public List<EventAccessCodeDelayInSettingOnDeviceDeviceWarnings> DeviceWarnings { get; set; }

        /// <summary>
        /// Human-readable description of the event. Persisted when the event is created (so the creating code, including a provider, can supply a tailored description) and otherwise derived from the event.
        /// </summary>
        [DataMember(Name = "event_description", IsRequired = false, EmitDefaultValue = false)]
        public override string? EventDescription { get; set; }

        /// <summary>
        /// ID of the event.
        /// </summary>
        [DataMember(Name = "event_id", IsRequired = false, EmitDefaultValue = false)]
        public override string EventId { get; set; }

        [DataMember(Name = "event_type", IsRequired = true, EmitDefaultValue = false)]
        public override string EventType { get; } = "access_code.delay_in_setting_on_device";

        /// <summary>
        /// Date and time at which the event occurred.
        /// </summary>
        [DataMember(Name = "occurred_at", IsRequired = false, EmitDefaultValue = false)]
        public override string OccurredAt { get; set; }

        /// <summary>
        /// ID of the workspace associated with the event.
        /// </summary>
        [DataMember(Name = "workspace_id", IsRequired = false, EmitDefaultValue = false)]
        public override string WorkspaceId { get; set; }

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

    [DataContract(Name = "seamModel_eventAccessCodeDelayInSettingOnDeviceAccessCodeErrors_model")]
    public class EventAccessCodeDelayInSettingOnDeviceAccessCodeErrors
    {
        [JsonConstructorAttribute]
        protected EventAccessCodeDelayInSettingOnDeviceAccessCodeErrors() { }

        public EventAccessCodeDelayInSettingOnDeviceAccessCodeErrors(
            string createdAt = default,
            string errorCode = default,
            string message = default
        )
        {
            CreatedAt = createdAt;
            ErrorCode = errorCode;
            Message = message;
        }

        /// <summary>
        /// Date and time at which Seam created the error.
        /// </summary>
        [DataMember(Name = "created_at", IsRequired = false, EmitDefaultValue = false)]
        public string CreatedAt { get; set; }

        /// <summary>
        /// Unique identifier of the type of error. Enables quick recognition and categorization of the issue.
        /// </summary>
        [DataMember(Name = "error_code", IsRequired = false, EmitDefaultValue = false)]
        public string ErrorCode { get; set; }

        /// <summary>
        /// Detailed description of the error. Provides insights into the issue and potentially how to rectify it.
        /// </summary>
        [DataMember(Name = "message", IsRequired = false, EmitDefaultValue = false)]
        public string Message { get; set; }

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

    [DataContract(Name = "seamModel_eventAccessCodeDelayInSettingOnDeviceAccessCodeWarnings_model")]
    public class EventAccessCodeDelayInSettingOnDeviceAccessCodeWarnings
    {
        [JsonConstructorAttribute]
        protected EventAccessCodeDelayInSettingOnDeviceAccessCodeWarnings() { }

        public EventAccessCodeDelayInSettingOnDeviceAccessCodeWarnings(
            string createdAt = default,
            string message = default,
            string warningCode = default
        )
        {
            CreatedAt = createdAt;
            Message = message;
            WarningCode = warningCode;
        }

        /// <summary>
        /// Date and time at which Seam created the warning.
        /// </summary>
        [DataMember(Name = "created_at", IsRequired = false, EmitDefaultValue = false)]
        public string CreatedAt { get; set; }

        /// <summary>
        /// Detailed description of the warning. Provides insights into the issue and potentially how to rectify it.
        /// </summary>
        [DataMember(Name = "message", IsRequired = false, EmitDefaultValue = false)]
        public string Message { get; set; }

        /// <summary>
        /// Unique identifier of the type of warning. Enables quick recognition and categorization of the issue.
        /// </summary>
        [DataMember(Name = "warning_code", IsRequired = false, EmitDefaultValue = false)]
        public string WarningCode { get; set; }

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
        Name = "seamModel_eventAccessCodeDelayInSettingOnDeviceConnectedAccountErrors_model"
    )]
    public class EventAccessCodeDelayInSettingOnDeviceConnectedAccountErrors
    {
        [JsonConstructorAttribute]
        protected EventAccessCodeDelayInSettingOnDeviceConnectedAccountErrors() { }

        public EventAccessCodeDelayInSettingOnDeviceConnectedAccountErrors(
            string createdAt = default,
            string errorCode = default,
            string message = default
        )
        {
            CreatedAt = createdAt;
            ErrorCode = errorCode;
            Message = message;
        }

        /// <summary>
        /// Date and time at which Seam created the error.
        /// </summary>
        [DataMember(Name = "created_at", IsRequired = false, EmitDefaultValue = false)]
        public string CreatedAt { get; set; }

        /// <summary>
        /// Unique identifier of the type of error. Enables quick recognition and categorization of the issue.
        /// </summary>
        [DataMember(Name = "error_code", IsRequired = false, EmitDefaultValue = false)]
        public string ErrorCode { get; set; }

        /// <summary>
        /// Detailed description of the error. Provides insights into the issue and potentially how to rectify it.
        /// </summary>
        [DataMember(Name = "message", IsRequired = false, EmitDefaultValue = false)]
        public string Message { get; set; }

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
        Name = "seamModel_eventAccessCodeDelayInSettingOnDeviceConnectedAccountWarnings_model"
    )]
    public class EventAccessCodeDelayInSettingOnDeviceConnectedAccountWarnings
    {
        [JsonConstructorAttribute]
        protected EventAccessCodeDelayInSettingOnDeviceConnectedAccountWarnings() { }

        public EventAccessCodeDelayInSettingOnDeviceConnectedAccountWarnings(
            string createdAt = default,
            string message = default,
            string warningCode = default
        )
        {
            CreatedAt = createdAt;
            Message = message;
            WarningCode = warningCode;
        }

        /// <summary>
        /// Date and time at which Seam created the warning.
        /// </summary>
        [DataMember(Name = "created_at", IsRequired = false, EmitDefaultValue = false)]
        public string CreatedAt { get; set; }

        /// <summary>
        /// Detailed description of the warning. Provides insights into the issue and potentially how to rectify it.
        /// </summary>
        [DataMember(Name = "message", IsRequired = false, EmitDefaultValue = false)]
        public string Message { get; set; }

        /// <summary>
        /// Unique identifier of the type of warning. Enables quick recognition and categorization of the issue.
        /// </summary>
        [DataMember(Name = "warning_code", IsRequired = false, EmitDefaultValue = false)]
        public string WarningCode { get; set; }

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

    [DataContract(Name = "seamModel_eventAccessCodeDelayInSettingOnDeviceDeviceErrors_model")]
    public class EventAccessCodeDelayInSettingOnDeviceDeviceErrors
    {
        [JsonConstructorAttribute]
        protected EventAccessCodeDelayInSettingOnDeviceDeviceErrors() { }

        public EventAccessCodeDelayInSettingOnDeviceDeviceErrors(
            string createdAt = default,
            string errorCode = default,
            string message = default
        )
        {
            CreatedAt = createdAt;
            ErrorCode = errorCode;
            Message = message;
        }

        /// <summary>
        /// Date and time at which Seam created the error.
        /// </summary>
        [DataMember(Name = "created_at", IsRequired = false, EmitDefaultValue = false)]
        public string CreatedAt { get; set; }

        /// <summary>
        /// Unique identifier of the type of error. Enables quick recognition and categorization of the issue.
        /// </summary>
        [DataMember(Name = "error_code", IsRequired = false, EmitDefaultValue = false)]
        public string ErrorCode { get; set; }

        /// <summary>
        /// Detailed description of the error. Provides insights into the issue and potentially how to rectify it.
        /// </summary>
        [DataMember(Name = "message", IsRequired = false, EmitDefaultValue = false)]
        public string Message { get; set; }

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

    [DataContract(Name = "seamModel_eventAccessCodeDelayInSettingOnDeviceDeviceWarnings_model")]
    public class EventAccessCodeDelayInSettingOnDeviceDeviceWarnings
    {
        [JsonConstructorAttribute]
        protected EventAccessCodeDelayInSettingOnDeviceDeviceWarnings() { }

        public EventAccessCodeDelayInSettingOnDeviceDeviceWarnings(
            string createdAt = default,
            string message = default,
            string warningCode = default
        )
        {
            CreatedAt = createdAt;
            Message = message;
            WarningCode = warningCode;
        }

        /// <summary>
        /// Date and time at which Seam created the warning.
        /// </summary>
        [DataMember(Name = "created_at", IsRequired = false, EmitDefaultValue = false)]
        public string CreatedAt { get; set; }

        /// <summary>
        /// Detailed description of the warning. Provides insights into the issue and potentially how to rectify it.
        /// </summary>
        [DataMember(Name = "message", IsRequired = false, EmitDefaultValue = false)]
        public string Message { get; set; }

        /// <summary>
        /// Unique identifier of the type of warning. Enables quick recognition and categorization of the issue.
        /// </summary>
        [DataMember(Name = "warning_code", IsRequired = false, EmitDefaultValue = false)]
        public string WarningCode { get; set; }

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
    /// An [access code](https://docs.seam.co/low-level-apis/smart-locks/access-codes) failed to be set on a device.
    /// </summary>
    [DataContract(Name = "seamModel_eventAccessCodeFailedToSetOnDevice_model")]
    public class EventAccessCodeFailedToSetOnDevice : Event
    {
        [JsonConstructorAttribute]
        protected EventAccessCodeFailedToSetOnDevice() { }

        public EventAccessCodeFailedToSetOnDevice(
            List<EventAccessCodeFailedToSetOnDeviceAccessCodeErrors> accessCodeErrors = default,
            string accessCodeId = default,
            List<EventAccessCodeFailedToSetOnDeviceAccessCodeWarnings> accessCodeWarnings = default,
            object? connectedAccountCustomMetadata = default,
            List<EventAccessCodeFailedToSetOnDeviceConnectedAccountErrors> connectedAccountErrors =
                default,
            string connectedAccountId = default,
            List<EventAccessCodeFailedToSetOnDeviceConnectedAccountWarnings> connectedAccountWarnings =
                default,
            string createdAt = default,
            object? deviceCustomMetadata = default,
            List<EventAccessCodeFailedToSetOnDeviceDeviceErrors> deviceErrors = default,
            string deviceId = default,
            List<EventAccessCodeFailedToSetOnDeviceDeviceWarnings> deviceWarnings = default,
            string? eventDescription = default,
            string eventId = default,
            string eventType = default,
            string occurredAt = default,
            string workspaceId = default
        )
        {
            AccessCodeErrors = accessCodeErrors;
            AccessCodeId = accessCodeId;
            AccessCodeWarnings = accessCodeWarnings;
            ConnectedAccountCustomMetadata = connectedAccountCustomMetadata;
            ConnectedAccountErrors = connectedAccountErrors;
            ConnectedAccountId = connectedAccountId;
            ConnectedAccountWarnings = connectedAccountWarnings;
            CreatedAt = createdAt;
            DeviceCustomMetadata = deviceCustomMetadata;
            DeviceErrors = deviceErrors;
            DeviceId = deviceId;
            DeviceWarnings = deviceWarnings;
            EventDescription = eventDescription;
            EventId = eventId;
            EventType = eventType;
            OccurredAt = occurredAt;
            WorkspaceId = workspaceId;
        }

        /// <summary>
        /// Errors associated with the access code.
        /// </summary>
        [DataMember(Name = "access_code_errors", IsRequired = false, EmitDefaultValue = false)]
        public List<EventAccessCodeFailedToSetOnDeviceAccessCodeErrors> AccessCodeErrors { get; set; }

        /// <summary>
        /// ID of the affected access code.
        /// </summary>
        [DataMember(Name = "access_code_id", IsRequired = false, EmitDefaultValue = false)]
        public string AccessCodeId { get; set; }

        /// <summary>
        /// Warnings associated with the access code.
        /// </summary>
        [DataMember(Name = "access_code_warnings", IsRequired = false, EmitDefaultValue = false)]
        public List<EventAccessCodeFailedToSetOnDeviceAccessCodeWarnings> AccessCodeWarnings { get; set; }

        /// <summary>
        /// Custom metadata of the connected account, present when connected_account_id is provided.
        /// </summary>
        [DataMember(
            Name = "connected_account_custom_metadata",
            IsRequired = false,
            EmitDefaultValue = false
        )]
        public object? ConnectedAccountCustomMetadata { get; set; }

        /// <summary>
        /// Errors associated with the connected account.
        /// </summary>
        [DataMember(
            Name = "connected_account_errors",
            IsRequired = false,
            EmitDefaultValue = false
        )]
        public List<EventAccessCodeFailedToSetOnDeviceConnectedAccountErrors> ConnectedAccountErrors { get; set; }

        /// <summary>
        /// ID of the connected account associated with the affected access code.
        /// </summary>
        [DataMember(Name = "connected_account_id", IsRequired = false, EmitDefaultValue = false)]
        public string ConnectedAccountId { get; set; }

        /// <summary>
        /// Warnings associated with the connected account.
        /// </summary>
        [DataMember(
            Name = "connected_account_warnings",
            IsRequired = false,
            EmitDefaultValue = false
        )]
        public List<EventAccessCodeFailedToSetOnDeviceConnectedAccountWarnings> ConnectedAccountWarnings { get; set; }

        /// <summary>
        /// Date and time at which the event was created.
        /// </summary>
        [DataMember(Name = "created_at", IsRequired = false, EmitDefaultValue = false)]
        public override string CreatedAt { get; set; }

        /// <summary>
        /// Custom metadata of the device, present when device_id is provided.
        /// </summary>
        [DataMember(Name = "device_custom_metadata", IsRequired = false, EmitDefaultValue = false)]
        public object? DeviceCustomMetadata { get; set; }

        /// <summary>
        /// Errors associated with the device.
        /// </summary>
        [DataMember(Name = "device_errors", IsRequired = false, EmitDefaultValue = false)]
        public List<EventAccessCodeFailedToSetOnDeviceDeviceErrors> DeviceErrors { get; set; }

        /// <summary>
        /// ID of the device associated with the affected access code.
        /// </summary>
        [DataMember(Name = "device_id", IsRequired = false, EmitDefaultValue = false)]
        public string DeviceId { get; set; }

        /// <summary>
        /// Warnings associated with the device.
        /// </summary>
        [DataMember(Name = "device_warnings", IsRequired = false, EmitDefaultValue = false)]
        public List<EventAccessCodeFailedToSetOnDeviceDeviceWarnings> DeviceWarnings { get; set; }

        /// <summary>
        /// Human-readable description of the event. Persisted when the event is created (so the creating code, including a provider, can supply a tailored description) and otherwise derived from the event.
        /// </summary>
        [DataMember(Name = "event_description", IsRequired = false, EmitDefaultValue = false)]
        public override string? EventDescription { get; set; }

        /// <summary>
        /// ID of the event.
        /// </summary>
        [DataMember(Name = "event_id", IsRequired = false, EmitDefaultValue = false)]
        public override string EventId { get; set; }

        [DataMember(Name = "event_type", IsRequired = true, EmitDefaultValue = false)]
        public override string EventType { get; } = "access_code.failed_to_set_on_device";

        /// <summary>
        /// Date and time at which the event occurred.
        /// </summary>
        [DataMember(Name = "occurred_at", IsRequired = false, EmitDefaultValue = false)]
        public override string OccurredAt { get; set; }

        /// <summary>
        /// ID of the workspace associated with the event.
        /// </summary>
        [DataMember(Name = "workspace_id", IsRequired = false, EmitDefaultValue = false)]
        public override string WorkspaceId { get; set; }

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

    [DataContract(Name = "seamModel_eventAccessCodeFailedToSetOnDeviceAccessCodeErrors_model")]
    public class EventAccessCodeFailedToSetOnDeviceAccessCodeErrors
    {
        [JsonConstructorAttribute]
        protected EventAccessCodeFailedToSetOnDeviceAccessCodeErrors() { }

        public EventAccessCodeFailedToSetOnDeviceAccessCodeErrors(
            string createdAt = default,
            string errorCode = default,
            string message = default
        )
        {
            CreatedAt = createdAt;
            ErrorCode = errorCode;
            Message = message;
        }

        /// <summary>
        /// Date and time at which Seam created the error.
        /// </summary>
        [DataMember(Name = "created_at", IsRequired = false, EmitDefaultValue = false)]
        public string CreatedAt { get; set; }

        /// <summary>
        /// Unique identifier of the type of error. Enables quick recognition and categorization of the issue.
        /// </summary>
        [DataMember(Name = "error_code", IsRequired = false, EmitDefaultValue = false)]
        public string ErrorCode { get; set; }

        /// <summary>
        /// Detailed description of the error. Provides insights into the issue and potentially how to rectify it.
        /// </summary>
        [DataMember(Name = "message", IsRequired = false, EmitDefaultValue = false)]
        public string Message { get; set; }

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

    [DataContract(Name = "seamModel_eventAccessCodeFailedToSetOnDeviceAccessCodeWarnings_model")]
    public class EventAccessCodeFailedToSetOnDeviceAccessCodeWarnings
    {
        [JsonConstructorAttribute]
        protected EventAccessCodeFailedToSetOnDeviceAccessCodeWarnings() { }

        public EventAccessCodeFailedToSetOnDeviceAccessCodeWarnings(
            string createdAt = default,
            string message = default,
            string warningCode = default
        )
        {
            CreatedAt = createdAt;
            Message = message;
            WarningCode = warningCode;
        }

        /// <summary>
        /// Date and time at which Seam created the warning.
        /// </summary>
        [DataMember(Name = "created_at", IsRequired = false, EmitDefaultValue = false)]
        public string CreatedAt { get; set; }

        /// <summary>
        /// Detailed description of the warning. Provides insights into the issue and potentially how to rectify it.
        /// </summary>
        [DataMember(Name = "message", IsRequired = false, EmitDefaultValue = false)]
        public string Message { get; set; }

        /// <summary>
        /// Unique identifier of the type of warning. Enables quick recognition and categorization of the issue.
        /// </summary>
        [DataMember(Name = "warning_code", IsRequired = false, EmitDefaultValue = false)]
        public string WarningCode { get; set; }

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
        Name = "seamModel_eventAccessCodeFailedToSetOnDeviceConnectedAccountErrors_model"
    )]
    public class EventAccessCodeFailedToSetOnDeviceConnectedAccountErrors
    {
        [JsonConstructorAttribute]
        protected EventAccessCodeFailedToSetOnDeviceConnectedAccountErrors() { }

        public EventAccessCodeFailedToSetOnDeviceConnectedAccountErrors(
            string createdAt = default,
            string errorCode = default,
            string message = default
        )
        {
            CreatedAt = createdAt;
            ErrorCode = errorCode;
            Message = message;
        }

        /// <summary>
        /// Date and time at which Seam created the error.
        /// </summary>
        [DataMember(Name = "created_at", IsRequired = false, EmitDefaultValue = false)]
        public string CreatedAt { get; set; }

        /// <summary>
        /// Unique identifier of the type of error. Enables quick recognition and categorization of the issue.
        /// </summary>
        [DataMember(Name = "error_code", IsRequired = false, EmitDefaultValue = false)]
        public string ErrorCode { get; set; }

        /// <summary>
        /// Detailed description of the error. Provides insights into the issue and potentially how to rectify it.
        /// </summary>
        [DataMember(Name = "message", IsRequired = false, EmitDefaultValue = false)]
        public string Message { get; set; }

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
        Name = "seamModel_eventAccessCodeFailedToSetOnDeviceConnectedAccountWarnings_model"
    )]
    public class EventAccessCodeFailedToSetOnDeviceConnectedAccountWarnings
    {
        [JsonConstructorAttribute]
        protected EventAccessCodeFailedToSetOnDeviceConnectedAccountWarnings() { }

        public EventAccessCodeFailedToSetOnDeviceConnectedAccountWarnings(
            string createdAt = default,
            string message = default,
            string warningCode = default
        )
        {
            CreatedAt = createdAt;
            Message = message;
            WarningCode = warningCode;
        }

        /// <summary>
        /// Date and time at which Seam created the warning.
        /// </summary>
        [DataMember(Name = "created_at", IsRequired = false, EmitDefaultValue = false)]
        public string CreatedAt { get; set; }

        /// <summary>
        /// Detailed description of the warning. Provides insights into the issue and potentially how to rectify it.
        /// </summary>
        [DataMember(Name = "message", IsRequired = false, EmitDefaultValue = false)]
        public string Message { get; set; }

        /// <summary>
        /// Unique identifier of the type of warning. Enables quick recognition and categorization of the issue.
        /// </summary>
        [DataMember(Name = "warning_code", IsRequired = false, EmitDefaultValue = false)]
        public string WarningCode { get; set; }

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

    [DataContract(Name = "seamModel_eventAccessCodeFailedToSetOnDeviceDeviceErrors_model")]
    public class EventAccessCodeFailedToSetOnDeviceDeviceErrors
    {
        [JsonConstructorAttribute]
        protected EventAccessCodeFailedToSetOnDeviceDeviceErrors() { }

        public EventAccessCodeFailedToSetOnDeviceDeviceErrors(
            string createdAt = default,
            string errorCode = default,
            string message = default
        )
        {
            CreatedAt = createdAt;
            ErrorCode = errorCode;
            Message = message;
        }

        /// <summary>
        /// Date and time at which Seam created the error.
        /// </summary>
        [DataMember(Name = "created_at", IsRequired = false, EmitDefaultValue = false)]
        public string CreatedAt { get; set; }

        /// <summary>
        /// Unique identifier of the type of error. Enables quick recognition and categorization of the issue.
        /// </summary>
        [DataMember(Name = "error_code", IsRequired = false, EmitDefaultValue = false)]
        public string ErrorCode { get; set; }

        /// <summary>
        /// Detailed description of the error. Provides insights into the issue and potentially how to rectify it.
        /// </summary>
        [DataMember(Name = "message", IsRequired = false, EmitDefaultValue = false)]
        public string Message { get; set; }

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

    [DataContract(Name = "seamModel_eventAccessCodeFailedToSetOnDeviceDeviceWarnings_model")]
    public class EventAccessCodeFailedToSetOnDeviceDeviceWarnings
    {
        [JsonConstructorAttribute]
        protected EventAccessCodeFailedToSetOnDeviceDeviceWarnings() { }

        public EventAccessCodeFailedToSetOnDeviceDeviceWarnings(
            string createdAt = default,
            string message = default,
            string warningCode = default
        )
        {
            CreatedAt = createdAt;
            Message = message;
            WarningCode = warningCode;
        }

        /// <summary>
        /// Date and time at which Seam created the warning.
        /// </summary>
        [DataMember(Name = "created_at", IsRequired = false, EmitDefaultValue = false)]
        public string CreatedAt { get; set; }

        /// <summary>
        /// Detailed description of the warning. Provides insights into the issue and potentially how to rectify it.
        /// </summary>
        [DataMember(Name = "message", IsRequired = false, EmitDefaultValue = false)]
        public string Message { get; set; }

        /// <summary>
        /// Unique identifier of the type of warning. Enables quick recognition and categorization of the issue.
        /// </summary>
        [DataMember(Name = "warning_code", IsRequired = false, EmitDefaultValue = false)]
        public string WarningCode { get; set; }

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
    /// An [access code](https://docs.seam.co/low-level-apis/smart-locks/access-codes) was deleted.
    /// </summary>
    [DataContract(Name = "seamModel_eventAccessCodeDeleted_model")]
    public class EventAccessCodeDeleted : Event
    {
        [JsonConstructorAttribute]
        protected EventAccessCodeDeleted() { }

        public EventAccessCodeDeleted(
            string accessCodeId = default,
            string? code = default,
            object? connectedAccountCustomMetadata = default,
            string connectedAccountId = default,
            string createdAt = default,
            object? deviceCustomMetadata = default,
            string deviceId = default,
            string? eventDescription = default,
            string eventId = default,
            string eventType = default,
            string occurredAt = default,
            string workspaceId = default
        )
        {
            AccessCodeId = accessCodeId;
            Code = code;
            ConnectedAccountCustomMetadata = connectedAccountCustomMetadata;
            ConnectedAccountId = connectedAccountId;
            CreatedAt = createdAt;
            DeviceCustomMetadata = deviceCustomMetadata;
            DeviceId = deviceId;
            EventDescription = eventDescription;
            EventId = eventId;
            EventType = eventType;
            OccurredAt = occurredAt;
            WorkspaceId = workspaceId;
        }

        /// <summary>
        /// ID of the affected access code.
        /// </summary>
        [DataMember(Name = "access_code_id", IsRequired = false, EmitDefaultValue = false)]
        public string AccessCodeId { get; set; }

        /// <summary>
        /// Code for the affected access code.
        /// </summary>
        [DataMember(Name = "code", IsRequired = false, EmitDefaultValue = false)]
        public string? Code { get; set; }

        /// <summary>
        /// Custom metadata of the connected account, present when connected_account_id is provided.
        /// </summary>
        [DataMember(
            Name = "connected_account_custom_metadata",
            IsRequired = false,
            EmitDefaultValue = false
        )]
        public object? ConnectedAccountCustomMetadata { get; set; }

        /// <summary>
        /// ID of the connected account associated with the affected access code.
        /// </summary>
        [DataMember(Name = "connected_account_id", IsRequired = false, EmitDefaultValue = false)]
        public string ConnectedAccountId { get; set; }

        /// <summary>
        /// Date and time at which the event was created.
        /// </summary>
        [DataMember(Name = "created_at", IsRequired = false, EmitDefaultValue = false)]
        public override string CreatedAt { get; set; }

        /// <summary>
        /// Custom metadata of the device, present when device_id is provided.
        /// </summary>
        [DataMember(Name = "device_custom_metadata", IsRequired = false, EmitDefaultValue = false)]
        public object? DeviceCustomMetadata { get; set; }

        /// <summary>
        /// ID of the device associated with the affected access code.
        /// </summary>
        [DataMember(Name = "device_id", IsRequired = false, EmitDefaultValue = false)]
        public string DeviceId { get; set; }

        /// <summary>
        /// Human-readable description of the event. Persisted when the event is created (so the creating code, including a provider, can supply a tailored description) and otherwise derived from the event.
        /// </summary>
        [DataMember(Name = "event_description", IsRequired = false, EmitDefaultValue = false)]
        public override string? EventDescription { get; set; }

        /// <summary>
        /// ID of the event.
        /// </summary>
        [DataMember(Name = "event_id", IsRequired = false, EmitDefaultValue = false)]
        public override string EventId { get; set; }

        [DataMember(Name = "event_type", IsRequired = true, EmitDefaultValue = false)]
        public override string EventType { get; } = "access_code.deleted";

        /// <summary>
        /// Date and time at which the event occurred.
        /// </summary>
        [DataMember(Name = "occurred_at", IsRequired = false, EmitDefaultValue = false)]
        public override string OccurredAt { get; set; }

        /// <summary>
        /// ID of the workspace associated with the event.
        /// </summary>
        [DataMember(Name = "workspace_id", IsRequired = false, EmitDefaultValue = false)]
        public override string WorkspaceId { get; set; }

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
    /// There was an unusually long delay in removing an [access code](https://docs.seam.co/low-level-apis/smart-locks/access-codes) from a device.
    /// </summary>
    [DataContract(Name = "seamModel_eventAccessCodeDelayInRemovingFromDevice_model")]
    public class EventAccessCodeDelayInRemovingFromDevice : Event
    {
        [JsonConstructorAttribute]
        protected EventAccessCodeDelayInRemovingFromDevice() { }

        public EventAccessCodeDelayInRemovingFromDevice(
            List<EventAccessCodeDelayInRemovingFromDeviceAccessCodeErrors> accessCodeErrors =
                default,
            string accessCodeId = default,
            List<EventAccessCodeDelayInRemovingFromDeviceAccessCodeWarnings> accessCodeWarnings =
                default,
            object? connectedAccountCustomMetadata = default,
            List<EventAccessCodeDelayInRemovingFromDeviceConnectedAccountErrors> connectedAccountErrors =
                default,
            string connectedAccountId = default,
            List<EventAccessCodeDelayInRemovingFromDeviceConnectedAccountWarnings> connectedAccountWarnings =
                default,
            string createdAt = default,
            object? deviceCustomMetadata = default,
            List<EventAccessCodeDelayInRemovingFromDeviceDeviceErrors> deviceErrors = default,
            string deviceId = default,
            List<EventAccessCodeDelayInRemovingFromDeviceDeviceWarnings> deviceWarnings = default,
            string? eventDescription = default,
            string eventId = default,
            string eventType = default,
            string occurredAt = default,
            string workspaceId = default
        )
        {
            AccessCodeErrors = accessCodeErrors;
            AccessCodeId = accessCodeId;
            AccessCodeWarnings = accessCodeWarnings;
            ConnectedAccountCustomMetadata = connectedAccountCustomMetadata;
            ConnectedAccountErrors = connectedAccountErrors;
            ConnectedAccountId = connectedAccountId;
            ConnectedAccountWarnings = connectedAccountWarnings;
            CreatedAt = createdAt;
            DeviceCustomMetadata = deviceCustomMetadata;
            DeviceErrors = deviceErrors;
            DeviceId = deviceId;
            DeviceWarnings = deviceWarnings;
            EventDescription = eventDescription;
            EventId = eventId;
            EventType = eventType;
            OccurredAt = occurredAt;
            WorkspaceId = workspaceId;
        }

        /// <summary>
        /// Errors associated with the access code.
        /// </summary>
        [DataMember(Name = "access_code_errors", IsRequired = false, EmitDefaultValue = false)]
        public List<EventAccessCodeDelayInRemovingFromDeviceAccessCodeErrors> AccessCodeErrors { get; set; }

        /// <summary>
        /// ID of the affected access code.
        /// </summary>
        [DataMember(Name = "access_code_id", IsRequired = false, EmitDefaultValue = false)]
        public string AccessCodeId { get; set; }

        /// <summary>
        /// Warnings associated with the access code.
        /// </summary>
        [DataMember(Name = "access_code_warnings", IsRequired = false, EmitDefaultValue = false)]
        public List<EventAccessCodeDelayInRemovingFromDeviceAccessCodeWarnings> AccessCodeWarnings { get; set; }

        /// <summary>
        /// Custom metadata of the connected account, present when connected_account_id is provided.
        /// </summary>
        [DataMember(
            Name = "connected_account_custom_metadata",
            IsRequired = false,
            EmitDefaultValue = false
        )]
        public object? ConnectedAccountCustomMetadata { get; set; }

        /// <summary>
        /// Errors associated with the connected account.
        /// </summary>
        [DataMember(
            Name = "connected_account_errors",
            IsRequired = false,
            EmitDefaultValue = false
        )]
        public List<EventAccessCodeDelayInRemovingFromDeviceConnectedAccountErrors> ConnectedAccountErrors { get; set; }

        /// <summary>
        /// ID of the connected account associated with the affected access code.
        /// </summary>
        [DataMember(Name = "connected_account_id", IsRequired = false, EmitDefaultValue = false)]
        public string ConnectedAccountId { get; set; }

        /// <summary>
        /// Warnings associated with the connected account.
        /// </summary>
        [DataMember(
            Name = "connected_account_warnings",
            IsRequired = false,
            EmitDefaultValue = false
        )]
        public List<EventAccessCodeDelayInRemovingFromDeviceConnectedAccountWarnings> ConnectedAccountWarnings { get; set; }

        /// <summary>
        /// Date and time at which the event was created.
        /// </summary>
        [DataMember(Name = "created_at", IsRequired = false, EmitDefaultValue = false)]
        public override string CreatedAt { get; set; }

        /// <summary>
        /// Custom metadata of the device, present when device_id is provided.
        /// </summary>
        [DataMember(Name = "device_custom_metadata", IsRequired = false, EmitDefaultValue = false)]
        public object? DeviceCustomMetadata { get; set; }

        /// <summary>
        /// Errors associated with the device.
        /// </summary>
        [DataMember(Name = "device_errors", IsRequired = false, EmitDefaultValue = false)]
        public List<EventAccessCodeDelayInRemovingFromDeviceDeviceErrors> DeviceErrors { get; set; }

        /// <summary>
        /// ID of the device associated with the affected access code.
        /// </summary>
        [DataMember(Name = "device_id", IsRequired = false, EmitDefaultValue = false)]
        public string DeviceId { get; set; }

        /// <summary>
        /// Warnings associated with the device.
        /// </summary>
        [DataMember(Name = "device_warnings", IsRequired = false, EmitDefaultValue = false)]
        public List<EventAccessCodeDelayInRemovingFromDeviceDeviceWarnings> DeviceWarnings { get; set; }

        /// <summary>
        /// Human-readable description of the event. Persisted when the event is created (so the creating code, including a provider, can supply a tailored description) and otherwise derived from the event.
        /// </summary>
        [DataMember(Name = "event_description", IsRequired = false, EmitDefaultValue = false)]
        public override string? EventDescription { get; set; }

        /// <summary>
        /// ID of the event.
        /// </summary>
        [DataMember(Name = "event_id", IsRequired = false, EmitDefaultValue = false)]
        public override string EventId { get; set; }

        [DataMember(Name = "event_type", IsRequired = true, EmitDefaultValue = false)]
        public override string EventType { get; } = "access_code.delay_in_removing_from_device";

        /// <summary>
        /// Date and time at which the event occurred.
        /// </summary>
        [DataMember(Name = "occurred_at", IsRequired = false, EmitDefaultValue = false)]
        public override string OccurredAt { get; set; }

        /// <summary>
        /// ID of the workspace associated with the event.
        /// </summary>
        [DataMember(Name = "workspace_id", IsRequired = false, EmitDefaultValue = false)]
        public override string WorkspaceId { get; set; }

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
        Name = "seamModel_eventAccessCodeDelayInRemovingFromDeviceAccessCodeErrors_model"
    )]
    public class EventAccessCodeDelayInRemovingFromDeviceAccessCodeErrors
    {
        [JsonConstructorAttribute]
        protected EventAccessCodeDelayInRemovingFromDeviceAccessCodeErrors() { }

        public EventAccessCodeDelayInRemovingFromDeviceAccessCodeErrors(
            string createdAt = default,
            string errorCode = default,
            string message = default
        )
        {
            CreatedAt = createdAt;
            ErrorCode = errorCode;
            Message = message;
        }

        /// <summary>
        /// Date and time at which Seam created the error.
        /// </summary>
        [DataMember(Name = "created_at", IsRequired = false, EmitDefaultValue = false)]
        public string CreatedAt { get; set; }

        /// <summary>
        /// Unique identifier of the type of error. Enables quick recognition and categorization of the issue.
        /// </summary>
        [DataMember(Name = "error_code", IsRequired = false, EmitDefaultValue = false)]
        public string ErrorCode { get; set; }

        /// <summary>
        /// Detailed description of the error. Provides insights into the issue and potentially how to rectify it.
        /// </summary>
        [DataMember(Name = "message", IsRequired = false, EmitDefaultValue = false)]
        public string Message { get; set; }

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
        Name = "seamModel_eventAccessCodeDelayInRemovingFromDeviceAccessCodeWarnings_model"
    )]
    public class EventAccessCodeDelayInRemovingFromDeviceAccessCodeWarnings
    {
        [JsonConstructorAttribute]
        protected EventAccessCodeDelayInRemovingFromDeviceAccessCodeWarnings() { }

        public EventAccessCodeDelayInRemovingFromDeviceAccessCodeWarnings(
            string createdAt = default,
            string message = default,
            string warningCode = default
        )
        {
            CreatedAt = createdAt;
            Message = message;
            WarningCode = warningCode;
        }

        /// <summary>
        /// Date and time at which Seam created the warning.
        /// </summary>
        [DataMember(Name = "created_at", IsRequired = false, EmitDefaultValue = false)]
        public string CreatedAt { get; set; }

        /// <summary>
        /// Detailed description of the warning. Provides insights into the issue and potentially how to rectify it.
        /// </summary>
        [DataMember(Name = "message", IsRequired = false, EmitDefaultValue = false)]
        public string Message { get; set; }

        /// <summary>
        /// Unique identifier of the type of warning. Enables quick recognition and categorization of the issue.
        /// </summary>
        [DataMember(Name = "warning_code", IsRequired = false, EmitDefaultValue = false)]
        public string WarningCode { get; set; }

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
        Name = "seamModel_eventAccessCodeDelayInRemovingFromDeviceConnectedAccountErrors_model"
    )]
    public class EventAccessCodeDelayInRemovingFromDeviceConnectedAccountErrors
    {
        [JsonConstructorAttribute]
        protected EventAccessCodeDelayInRemovingFromDeviceConnectedAccountErrors() { }

        public EventAccessCodeDelayInRemovingFromDeviceConnectedAccountErrors(
            string createdAt = default,
            string errorCode = default,
            string message = default
        )
        {
            CreatedAt = createdAt;
            ErrorCode = errorCode;
            Message = message;
        }

        /// <summary>
        /// Date and time at which Seam created the error.
        /// </summary>
        [DataMember(Name = "created_at", IsRequired = false, EmitDefaultValue = false)]
        public string CreatedAt { get; set; }

        /// <summary>
        /// Unique identifier of the type of error. Enables quick recognition and categorization of the issue.
        /// </summary>
        [DataMember(Name = "error_code", IsRequired = false, EmitDefaultValue = false)]
        public string ErrorCode { get; set; }

        /// <summary>
        /// Detailed description of the error. Provides insights into the issue and potentially how to rectify it.
        /// </summary>
        [DataMember(Name = "message", IsRequired = false, EmitDefaultValue = false)]
        public string Message { get; set; }

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
        Name = "seamModel_eventAccessCodeDelayInRemovingFromDeviceConnectedAccountWarnings_model"
    )]
    public class EventAccessCodeDelayInRemovingFromDeviceConnectedAccountWarnings
    {
        [JsonConstructorAttribute]
        protected EventAccessCodeDelayInRemovingFromDeviceConnectedAccountWarnings() { }

        public EventAccessCodeDelayInRemovingFromDeviceConnectedAccountWarnings(
            string createdAt = default,
            string message = default,
            string warningCode = default
        )
        {
            CreatedAt = createdAt;
            Message = message;
            WarningCode = warningCode;
        }

        /// <summary>
        /// Date and time at which Seam created the warning.
        /// </summary>
        [DataMember(Name = "created_at", IsRequired = false, EmitDefaultValue = false)]
        public string CreatedAt { get; set; }

        /// <summary>
        /// Detailed description of the warning. Provides insights into the issue and potentially how to rectify it.
        /// </summary>
        [DataMember(Name = "message", IsRequired = false, EmitDefaultValue = false)]
        public string Message { get; set; }

        /// <summary>
        /// Unique identifier of the type of warning. Enables quick recognition and categorization of the issue.
        /// </summary>
        [DataMember(Name = "warning_code", IsRequired = false, EmitDefaultValue = false)]
        public string WarningCode { get; set; }

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

    [DataContract(Name = "seamModel_eventAccessCodeDelayInRemovingFromDeviceDeviceErrors_model")]
    public class EventAccessCodeDelayInRemovingFromDeviceDeviceErrors
    {
        [JsonConstructorAttribute]
        protected EventAccessCodeDelayInRemovingFromDeviceDeviceErrors() { }

        public EventAccessCodeDelayInRemovingFromDeviceDeviceErrors(
            string createdAt = default,
            string errorCode = default,
            string message = default
        )
        {
            CreatedAt = createdAt;
            ErrorCode = errorCode;
            Message = message;
        }

        /// <summary>
        /// Date and time at which Seam created the error.
        /// </summary>
        [DataMember(Name = "created_at", IsRequired = false, EmitDefaultValue = false)]
        public string CreatedAt { get; set; }

        /// <summary>
        /// Unique identifier of the type of error. Enables quick recognition and categorization of the issue.
        /// </summary>
        [DataMember(Name = "error_code", IsRequired = false, EmitDefaultValue = false)]
        public string ErrorCode { get; set; }

        /// <summary>
        /// Detailed description of the error. Provides insights into the issue and potentially how to rectify it.
        /// </summary>
        [DataMember(Name = "message", IsRequired = false, EmitDefaultValue = false)]
        public string Message { get; set; }

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

    [DataContract(Name = "seamModel_eventAccessCodeDelayInRemovingFromDeviceDeviceWarnings_model")]
    public class EventAccessCodeDelayInRemovingFromDeviceDeviceWarnings
    {
        [JsonConstructorAttribute]
        protected EventAccessCodeDelayInRemovingFromDeviceDeviceWarnings() { }

        public EventAccessCodeDelayInRemovingFromDeviceDeviceWarnings(
            string createdAt = default,
            string message = default,
            string warningCode = default
        )
        {
            CreatedAt = createdAt;
            Message = message;
            WarningCode = warningCode;
        }

        /// <summary>
        /// Date and time at which Seam created the warning.
        /// </summary>
        [DataMember(Name = "created_at", IsRequired = false, EmitDefaultValue = false)]
        public string CreatedAt { get; set; }

        /// <summary>
        /// Detailed description of the warning. Provides insights into the issue and potentially how to rectify it.
        /// </summary>
        [DataMember(Name = "message", IsRequired = false, EmitDefaultValue = false)]
        public string Message { get; set; }

        /// <summary>
        /// Unique identifier of the type of warning. Enables quick recognition and categorization of the issue.
        /// </summary>
        [DataMember(Name = "warning_code", IsRequired = false, EmitDefaultValue = false)]
        public string WarningCode { get; set; }

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
    /// An [access code](https://docs.seam.co/low-level-apis/smart-locks/access-codes) failed to be removed from a device.
    /// </summary>
    [DataContract(Name = "seamModel_eventAccessCodeFailedToRemoveFromDevice_model")]
    public class EventAccessCodeFailedToRemoveFromDevice : Event
    {
        [JsonConstructorAttribute]
        protected EventAccessCodeFailedToRemoveFromDevice() { }

        public EventAccessCodeFailedToRemoveFromDevice(
            List<EventAccessCodeFailedToRemoveFromDeviceAccessCodeErrors> accessCodeErrors =
                default,
            string accessCodeId = default,
            List<EventAccessCodeFailedToRemoveFromDeviceAccessCodeWarnings> accessCodeWarnings =
                default,
            object? connectedAccountCustomMetadata = default,
            List<EventAccessCodeFailedToRemoveFromDeviceConnectedAccountErrors> connectedAccountErrors =
                default,
            string connectedAccountId = default,
            List<EventAccessCodeFailedToRemoveFromDeviceConnectedAccountWarnings> connectedAccountWarnings =
                default,
            string createdAt = default,
            object? deviceCustomMetadata = default,
            List<EventAccessCodeFailedToRemoveFromDeviceDeviceErrors> deviceErrors = default,
            string deviceId = default,
            List<EventAccessCodeFailedToRemoveFromDeviceDeviceWarnings> deviceWarnings = default,
            string? eventDescription = default,
            string eventId = default,
            string eventType = default,
            string occurredAt = default,
            string workspaceId = default
        )
        {
            AccessCodeErrors = accessCodeErrors;
            AccessCodeId = accessCodeId;
            AccessCodeWarnings = accessCodeWarnings;
            ConnectedAccountCustomMetadata = connectedAccountCustomMetadata;
            ConnectedAccountErrors = connectedAccountErrors;
            ConnectedAccountId = connectedAccountId;
            ConnectedAccountWarnings = connectedAccountWarnings;
            CreatedAt = createdAt;
            DeviceCustomMetadata = deviceCustomMetadata;
            DeviceErrors = deviceErrors;
            DeviceId = deviceId;
            DeviceWarnings = deviceWarnings;
            EventDescription = eventDescription;
            EventId = eventId;
            EventType = eventType;
            OccurredAt = occurredAt;
            WorkspaceId = workspaceId;
        }

        /// <summary>
        /// Errors associated with the access code.
        /// </summary>
        [DataMember(Name = "access_code_errors", IsRequired = false, EmitDefaultValue = false)]
        public List<EventAccessCodeFailedToRemoveFromDeviceAccessCodeErrors> AccessCodeErrors { get; set; }

        /// <summary>
        /// ID of the affected access code.
        /// </summary>
        [DataMember(Name = "access_code_id", IsRequired = false, EmitDefaultValue = false)]
        public string AccessCodeId { get; set; }

        /// <summary>
        /// Warnings associated with the access code.
        /// </summary>
        [DataMember(Name = "access_code_warnings", IsRequired = false, EmitDefaultValue = false)]
        public List<EventAccessCodeFailedToRemoveFromDeviceAccessCodeWarnings> AccessCodeWarnings { get; set; }

        /// <summary>
        /// Custom metadata of the connected account, present when connected_account_id is provided.
        /// </summary>
        [DataMember(
            Name = "connected_account_custom_metadata",
            IsRequired = false,
            EmitDefaultValue = false
        )]
        public object? ConnectedAccountCustomMetadata { get; set; }

        /// <summary>
        /// Errors associated with the connected account.
        /// </summary>
        [DataMember(
            Name = "connected_account_errors",
            IsRequired = false,
            EmitDefaultValue = false
        )]
        public List<EventAccessCodeFailedToRemoveFromDeviceConnectedAccountErrors> ConnectedAccountErrors { get; set; }

        /// <summary>
        /// ID of the connected account associated with the affected access code.
        /// </summary>
        [DataMember(Name = "connected_account_id", IsRequired = false, EmitDefaultValue = false)]
        public string ConnectedAccountId { get; set; }

        /// <summary>
        /// Warnings associated with the connected account.
        /// </summary>
        [DataMember(
            Name = "connected_account_warnings",
            IsRequired = false,
            EmitDefaultValue = false
        )]
        public List<EventAccessCodeFailedToRemoveFromDeviceConnectedAccountWarnings> ConnectedAccountWarnings { get; set; }

        /// <summary>
        /// Date and time at which the event was created.
        /// </summary>
        [DataMember(Name = "created_at", IsRequired = false, EmitDefaultValue = false)]
        public override string CreatedAt { get; set; }

        /// <summary>
        /// Custom metadata of the device, present when device_id is provided.
        /// </summary>
        [DataMember(Name = "device_custom_metadata", IsRequired = false, EmitDefaultValue = false)]
        public object? DeviceCustomMetadata { get; set; }

        /// <summary>
        /// Errors associated with the device.
        /// </summary>
        [DataMember(Name = "device_errors", IsRequired = false, EmitDefaultValue = false)]
        public List<EventAccessCodeFailedToRemoveFromDeviceDeviceErrors> DeviceErrors { get; set; }

        /// <summary>
        /// ID of the device associated with the affected access code.
        /// </summary>
        [DataMember(Name = "device_id", IsRequired = false, EmitDefaultValue = false)]
        public string DeviceId { get; set; }

        /// <summary>
        /// Warnings associated with the device.
        /// </summary>
        [DataMember(Name = "device_warnings", IsRequired = false, EmitDefaultValue = false)]
        public List<EventAccessCodeFailedToRemoveFromDeviceDeviceWarnings> DeviceWarnings { get; set; }

        /// <summary>
        /// Human-readable description of the event. Persisted when the event is created (so the creating code, including a provider, can supply a tailored description) and otherwise derived from the event.
        /// </summary>
        [DataMember(Name = "event_description", IsRequired = false, EmitDefaultValue = false)]
        public override string? EventDescription { get; set; }

        /// <summary>
        /// ID of the event.
        /// </summary>
        [DataMember(Name = "event_id", IsRequired = false, EmitDefaultValue = false)]
        public override string EventId { get; set; }

        [DataMember(Name = "event_type", IsRequired = true, EmitDefaultValue = false)]
        public override string EventType { get; } = "access_code.failed_to_remove_from_device";

        /// <summary>
        /// Date and time at which the event occurred.
        /// </summary>
        [DataMember(Name = "occurred_at", IsRequired = false, EmitDefaultValue = false)]
        public override string OccurredAt { get; set; }

        /// <summary>
        /// ID of the workspace associated with the event.
        /// </summary>
        [DataMember(Name = "workspace_id", IsRequired = false, EmitDefaultValue = false)]
        public override string WorkspaceId { get; set; }

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

    [DataContract(Name = "seamModel_eventAccessCodeFailedToRemoveFromDeviceAccessCodeErrors_model")]
    public class EventAccessCodeFailedToRemoveFromDeviceAccessCodeErrors
    {
        [JsonConstructorAttribute]
        protected EventAccessCodeFailedToRemoveFromDeviceAccessCodeErrors() { }

        public EventAccessCodeFailedToRemoveFromDeviceAccessCodeErrors(
            string createdAt = default,
            string errorCode = default,
            string message = default
        )
        {
            CreatedAt = createdAt;
            ErrorCode = errorCode;
            Message = message;
        }

        /// <summary>
        /// Date and time at which Seam created the error.
        /// </summary>
        [DataMember(Name = "created_at", IsRequired = false, EmitDefaultValue = false)]
        public string CreatedAt { get; set; }

        /// <summary>
        /// Unique identifier of the type of error. Enables quick recognition and categorization of the issue.
        /// </summary>
        [DataMember(Name = "error_code", IsRequired = false, EmitDefaultValue = false)]
        public string ErrorCode { get; set; }

        /// <summary>
        /// Detailed description of the error. Provides insights into the issue and potentially how to rectify it.
        /// </summary>
        [DataMember(Name = "message", IsRequired = false, EmitDefaultValue = false)]
        public string Message { get; set; }

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
        Name = "seamModel_eventAccessCodeFailedToRemoveFromDeviceAccessCodeWarnings_model"
    )]
    public class EventAccessCodeFailedToRemoveFromDeviceAccessCodeWarnings
    {
        [JsonConstructorAttribute]
        protected EventAccessCodeFailedToRemoveFromDeviceAccessCodeWarnings() { }

        public EventAccessCodeFailedToRemoveFromDeviceAccessCodeWarnings(
            string createdAt = default,
            string message = default,
            string warningCode = default
        )
        {
            CreatedAt = createdAt;
            Message = message;
            WarningCode = warningCode;
        }

        /// <summary>
        /// Date and time at which Seam created the warning.
        /// </summary>
        [DataMember(Name = "created_at", IsRequired = false, EmitDefaultValue = false)]
        public string CreatedAt { get; set; }

        /// <summary>
        /// Detailed description of the warning. Provides insights into the issue and potentially how to rectify it.
        /// </summary>
        [DataMember(Name = "message", IsRequired = false, EmitDefaultValue = false)]
        public string Message { get; set; }

        /// <summary>
        /// Unique identifier of the type of warning. Enables quick recognition and categorization of the issue.
        /// </summary>
        [DataMember(Name = "warning_code", IsRequired = false, EmitDefaultValue = false)]
        public string WarningCode { get; set; }

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
        Name = "seamModel_eventAccessCodeFailedToRemoveFromDeviceConnectedAccountErrors_model"
    )]
    public class EventAccessCodeFailedToRemoveFromDeviceConnectedAccountErrors
    {
        [JsonConstructorAttribute]
        protected EventAccessCodeFailedToRemoveFromDeviceConnectedAccountErrors() { }

        public EventAccessCodeFailedToRemoveFromDeviceConnectedAccountErrors(
            string createdAt = default,
            string errorCode = default,
            string message = default
        )
        {
            CreatedAt = createdAt;
            ErrorCode = errorCode;
            Message = message;
        }

        /// <summary>
        /// Date and time at which Seam created the error.
        /// </summary>
        [DataMember(Name = "created_at", IsRequired = false, EmitDefaultValue = false)]
        public string CreatedAt { get; set; }

        /// <summary>
        /// Unique identifier of the type of error. Enables quick recognition and categorization of the issue.
        /// </summary>
        [DataMember(Name = "error_code", IsRequired = false, EmitDefaultValue = false)]
        public string ErrorCode { get; set; }

        /// <summary>
        /// Detailed description of the error. Provides insights into the issue and potentially how to rectify it.
        /// </summary>
        [DataMember(Name = "message", IsRequired = false, EmitDefaultValue = false)]
        public string Message { get; set; }

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
        Name = "seamModel_eventAccessCodeFailedToRemoveFromDeviceConnectedAccountWarnings_model"
    )]
    public class EventAccessCodeFailedToRemoveFromDeviceConnectedAccountWarnings
    {
        [JsonConstructorAttribute]
        protected EventAccessCodeFailedToRemoveFromDeviceConnectedAccountWarnings() { }

        public EventAccessCodeFailedToRemoveFromDeviceConnectedAccountWarnings(
            string createdAt = default,
            string message = default,
            string warningCode = default
        )
        {
            CreatedAt = createdAt;
            Message = message;
            WarningCode = warningCode;
        }

        /// <summary>
        /// Date and time at which Seam created the warning.
        /// </summary>
        [DataMember(Name = "created_at", IsRequired = false, EmitDefaultValue = false)]
        public string CreatedAt { get; set; }

        /// <summary>
        /// Detailed description of the warning. Provides insights into the issue and potentially how to rectify it.
        /// </summary>
        [DataMember(Name = "message", IsRequired = false, EmitDefaultValue = false)]
        public string Message { get; set; }

        /// <summary>
        /// Unique identifier of the type of warning. Enables quick recognition and categorization of the issue.
        /// </summary>
        [DataMember(Name = "warning_code", IsRequired = false, EmitDefaultValue = false)]
        public string WarningCode { get; set; }

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

    [DataContract(Name = "seamModel_eventAccessCodeFailedToRemoveFromDeviceDeviceErrors_model")]
    public class EventAccessCodeFailedToRemoveFromDeviceDeviceErrors
    {
        [JsonConstructorAttribute]
        protected EventAccessCodeFailedToRemoveFromDeviceDeviceErrors() { }

        public EventAccessCodeFailedToRemoveFromDeviceDeviceErrors(
            string createdAt = default,
            string errorCode = default,
            string message = default
        )
        {
            CreatedAt = createdAt;
            ErrorCode = errorCode;
            Message = message;
        }

        /// <summary>
        /// Date and time at which Seam created the error.
        /// </summary>
        [DataMember(Name = "created_at", IsRequired = false, EmitDefaultValue = false)]
        public string CreatedAt { get; set; }

        /// <summary>
        /// Unique identifier of the type of error. Enables quick recognition and categorization of the issue.
        /// </summary>
        [DataMember(Name = "error_code", IsRequired = false, EmitDefaultValue = false)]
        public string ErrorCode { get; set; }

        /// <summary>
        /// Detailed description of the error. Provides insights into the issue and potentially how to rectify it.
        /// </summary>
        [DataMember(Name = "message", IsRequired = false, EmitDefaultValue = false)]
        public string Message { get; set; }

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

    [DataContract(Name = "seamModel_eventAccessCodeFailedToRemoveFromDeviceDeviceWarnings_model")]
    public class EventAccessCodeFailedToRemoveFromDeviceDeviceWarnings
    {
        [JsonConstructorAttribute]
        protected EventAccessCodeFailedToRemoveFromDeviceDeviceWarnings() { }

        public EventAccessCodeFailedToRemoveFromDeviceDeviceWarnings(
            string createdAt = default,
            string message = default,
            string warningCode = default
        )
        {
            CreatedAt = createdAt;
            Message = message;
            WarningCode = warningCode;
        }

        /// <summary>
        /// Date and time at which Seam created the warning.
        /// </summary>
        [DataMember(Name = "created_at", IsRequired = false, EmitDefaultValue = false)]
        public string CreatedAt { get; set; }

        /// <summary>
        /// Detailed description of the warning. Provides insights into the issue and potentially how to rectify it.
        /// </summary>
        [DataMember(Name = "message", IsRequired = false, EmitDefaultValue = false)]
        public string Message { get; set; }

        /// <summary>
        /// Unique identifier of the type of warning. Enables quick recognition and categorization of the issue.
        /// </summary>
        [DataMember(Name = "warning_code", IsRequired = false, EmitDefaultValue = false)]
        public string WarningCode { get; set; }

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
    /// An [access code](https://docs.seam.co/low-level-apis/smart-locks/access-codes) was modified outside of Seam.
    /// </summary>
    [DataContract(Name = "seamModel_eventAccessCodeModifiedExternalToSeam_model")]
    public class EventAccessCodeModifiedExternalToSeam : Event
    {
        [JsonConstructorAttribute]
        protected EventAccessCodeModifiedExternalToSeam() { }

        public EventAccessCodeModifiedExternalToSeam(
            string accessCodeId = default,
            object? connectedAccountCustomMetadata = default,
            string connectedAccountId = default,
            string createdAt = default,
            object? deviceCustomMetadata = default,
            string deviceId = default,
            string? eventDescription = default,
            string eventId = default,
            string eventType = default,
            string occurredAt = default,
            string workspaceId = default
        )
        {
            AccessCodeId = accessCodeId;
            ConnectedAccountCustomMetadata = connectedAccountCustomMetadata;
            ConnectedAccountId = connectedAccountId;
            CreatedAt = createdAt;
            DeviceCustomMetadata = deviceCustomMetadata;
            DeviceId = deviceId;
            EventDescription = eventDescription;
            EventId = eventId;
            EventType = eventType;
            OccurredAt = occurredAt;
            WorkspaceId = workspaceId;
        }

        /// <summary>
        /// ID of the affected access code.
        /// </summary>
        [DataMember(Name = "access_code_id", IsRequired = false, EmitDefaultValue = false)]
        public string AccessCodeId { get; set; }

        /// <summary>
        /// Custom metadata of the connected account, present when connected_account_id is provided.
        /// </summary>
        [DataMember(
            Name = "connected_account_custom_metadata",
            IsRequired = false,
            EmitDefaultValue = false
        )]
        public object? ConnectedAccountCustomMetadata { get; set; }

        /// <summary>
        /// ID of the connected account associated with the affected access code.
        /// </summary>
        [DataMember(Name = "connected_account_id", IsRequired = false, EmitDefaultValue = false)]
        public string ConnectedAccountId { get; set; }

        /// <summary>
        /// Date and time at which the event was created.
        /// </summary>
        [DataMember(Name = "created_at", IsRequired = false, EmitDefaultValue = false)]
        public override string CreatedAt { get; set; }

        /// <summary>
        /// Custom metadata of the device, present when device_id is provided.
        /// </summary>
        [DataMember(Name = "device_custom_metadata", IsRequired = false, EmitDefaultValue = false)]
        public object? DeviceCustomMetadata { get; set; }

        /// <summary>
        /// ID of the device associated with the affected access code.
        /// </summary>
        [DataMember(Name = "device_id", IsRequired = false, EmitDefaultValue = false)]
        public string DeviceId { get; set; }

        /// <summary>
        /// Human-readable description of the event. Persisted when the event is created (so the creating code, including a provider, can supply a tailored description) and otherwise derived from the event.
        /// </summary>
        [DataMember(Name = "event_description", IsRequired = false, EmitDefaultValue = false)]
        public override string? EventDescription { get; set; }

        /// <summary>
        /// ID of the event.
        /// </summary>
        [DataMember(Name = "event_id", IsRequired = false, EmitDefaultValue = false)]
        public override string EventId { get; set; }

        [DataMember(Name = "event_type", IsRequired = true, EmitDefaultValue = false)]
        public override string EventType { get; } = "access_code.modified_external_to_seam";

        /// <summary>
        /// Date and time at which the event occurred.
        /// </summary>
        [DataMember(Name = "occurred_at", IsRequired = false, EmitDefaultValue = false)]
        public override string OccurredAt { get; set; }

        /// <summary>
        /// ID of the workspace associated with the event.
        /// </summary>
        [DataMember(Name = "workspace_id", IsRequired = false, EmitDefaultValue = false)]
        public override string WorkspaceId { get; set; }

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
    /// An [access code](https://docs.seam.co/low-level-apis/smart-locks/access-codes) was deleted outside of Seam.
    /// </summary>
    [DataContract(Name = "seamModel_eventAccessCodeDeletedExternalToSeam_model")]
    public class EventAccessCodeDeletedExternalToSeam : Event
    {
        [JsonConstructorAttribute]
        protected EventAccessCodeDeletedExternalToSeam() { }

        public EventAccessCodeDeletedExternalToSeam(
            string accessCodeId = default,
            object? connectedAccountCustomMetadata = default,
            string connectedAccountId = default,
            string createdAt = default,
            object? deviceCustomMetadata = default,
            string deviceId = default,
            string? eventDescription = default,
            string eventId = default,
            string eventType = default,
            string occurredAt = default,
            string workspaceId = default
        )
        {
            AccessCodeId = accessCodeId;
            ConnectedAccountCustomMetadata = connectedAccountCustomMetadata;
            ConnectedAccountId = connectedAccountId;
            CreatedAt = createdAt;
            DeviceCustomMetadata = deviceCustomMetadata;
            DeviceId = deviceId;
            EventDescription = eventDescription;
            EventId = eventId;
            EventType = eventType;
            OccurredAt = occurredAt;
            WorkspaceId = workspaceId;
        }

        /// <summary>
        /// ID of the affected access code.
        /// </summary>
        [DataMember(Name = "access_code_id", IsRequired = false, EmitDefaultValue = false)]
        public string AccessCodeId { get; set; }

        /// <summary>
        /// Custom metadata of the connected account, present when connected_account_id is provided.
        /// </summary>
        [DataMember(
            Name = "connected_account_custom_metadata",
            IsRequired = false,
            EmitDefaultValue = false
        )]
        public object? ConnectedAccountCustomMetadata { get; set; }

        /// <summary>
        /// ID of the connected account associated with the affected access code.
        /// </summary>
        [DataMember(Name = "connected_account_id", IsRequired = false, EmitDefaultValue = false)]
        public string ConnectedAccountId { get; set; }

        /// <summary>
        /// Date and time at which the event was created.
        /// </summary>
        [DataMember(Name = "created_at", IsRequired = false, EmitDefaultValue = false)]
        public override string CreatedAt { get; set; }

        /// <summary>
        /// Custom metadata of the device, present when device_id is provided.
        /// </summary>
        [DataMember(Name = "device_custom_metadata", IsRequired = false, EmitDefaultValue = false)]
        public object? DeviceCustomMetadata { get; set; }

        /// <summary>
        /// ID of the device associated with the affected access code.
        /// </summary>
        [DataMember(Name = "device_id", IsRequired = false, EmitDefaultValue = false)]
        public string DeviceId { get; set; }

        /// <summary>
        /// Human-readable description of the event. Persisted when the event is created (so the creating code, including a provider, can supply a tailored description) and otherwise derived from the event.
        /// </summary>
        [DataMember(Name = "event_description", IsRequired = false, EmitDefaultValue = false)]
        public override string? EventDescription { get; set; }

        /// <summary>
        /// ID of the event.
        /// </summary>
        [DataMember(Name = "event_id", IsRequired = false, EmitDefaultValue = false)]
        public override string EventId { get; set; }

        [DataMember(Name = "event_type", IsRequired = true, EmitDefaultValue = false)]
        public override string EventType { get; } = "access_code.deleted_external_to_seam";

        /// <summary>
        /// Date and time at which the event occurred.
        /// </summary>
        [DataMember(Name = "occurred_at", IsRequired = false, EmitDefaultValue = false)]
        public override string OccurredAt { get; set; }

        /// <summary>
        /// ID of the workspace associated with the event.
        /// </summary>
        [DataMember(Name = "workspace_id", IsRequired = false, EmitDefaultValue = false)]
        public override string WorkspaceId { get; set; }

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
    /// A [backup access code](https://docs.seam.co/low-level-apis/smart-locks/access-codes/backup-access-codes) was pulled from the backup access code pool and set on a device.
    /// </summary>
    [DataContract(Name = "seamModel_eventAccessCodeBackupAccessCodePulled_model")]
    public class EventAccessCodeBackupAccessCodePulled : Event
    {
        [JsonConstructorAttribute]
        protected EventAccessCodeBackupAccessCodePulled() { }

        public EventAccessCodeBackupAccessCodePulled(
            string accessCodeId = default,
            string backupAccessCodeId = default,
            object? connectedAccountCustomMetadata = default,
            string connectedAccountId = default,
            string createdAt = default,
            object? deviceCustomMetadata = default,
            string deviceId = default,
            string? eventDescription = default,
            string eventId = default,
            string eventType = default,
            string occurredAt = default,
            string workspaceId = default
        )
        {
            AccessCodeId = accessCodeId;
            BackupAccessCodeId = backupAccessCodeId;
            ConnectedAccountCustomMetadata = connectedAccountCustomMetadata;
            ConnectedAccountId = connectedAccountId;
            CreatedAt = createdAt;
            DeviceCustomMetadata = deviceCustomMetadata;
            DeviceId = deviceId;
            EventDescription = eventDescription;
            EventId = eventId;
            EventType = eventType;
            OccurredAt = occurredAt;
            WorkspaceId = workspaceId;
        }

        /// <summary>
        /// ID of the affected access code.
        /// </summary>
        [DataMember(Name = "access_code_id", IsRequired = false, EmitDefaultValue = false)]
        public string AccessCodeId { get; set; }

        /// <summary>
        /// ID of the backup access code that was pulled from the pool.
        /// </summary>
        [DataMember(Name = "backup_access_code_id", IsRequired = false, EmitDefaultValue = false)]
        public string BackupAccessCodeId { get; set; }

        /// <summary>
        /// Custom metadata of the connected account, present when connected_account_id is provided.
        /// </summary>
        [DataMember(
            Name = "connected_account_custom_metadata",
            IsRequired = false,
            EmitDefaultValue = false
        )]
        public object? ConnectedAccountCustomMetadata { get; set; }

        /// <summary>
        /// ID of the connected account associated with the affected access code.
        /// </summary>
        [DataMember(Name = "connected_account_id", IsRequired = false, EmitDefaultValue = false)]
        public string ConnectedAccountId { get; set; }

        /// <summary>
        /// Date and time at which the event was created.
        /// </summary>
        [DataMember(Name = "created_at", IsRequired = false, EmitDefaultValue = false)]
        public override string CreatedAt { get; set; }

        /// <summary>
        /// Custom metadata of the device, present when device_id is provided.
        /// </summary>
        [DataMember(Name = "device_custom_metadata", IsRequired = false, EmitDefaultValue = false)]
        public object? DeviceCustomMetadata { get; set; }

        /// <summary>
        /// ID of the device associated with the affected access code.
        /// </summary>
        [DataMember(Name = "device_id", IsRequired = false, EmitDefaultValue = false)]
        public string DeviceId { get; set; }

        /// <summary>
        /// Human-readable description of the event. Persisted when the event is created (so the creating code, including a provider, can supply a tailored description) and otherwise derived from the event.
        /// </summary>
        [DataMember(Name = "event_description", IsRequired = false, EmitDefaultValue = false)]
        public override string? EventDescription { get; set; }

        /// <summary>
        /// ID of the event.
        /// </summary>
        [DataMember(Name = "event_id", IsRequired = false, EmitDefaultValue = false)]
        public override string EventId { get; set; }

        [DataMember(Name = "event_type", IsRequired = true, EmitDefaultValue = false)]
        public override string EventType { get; } = "access_code.backup_access_code_pulled";

        /// <summary>
        /// Date and time at which the event occurred.
        /// </summary>
        [DataMember(Name = "occurred_at", IsRequired = false, EmitDefaultValue = false)]
        public override string OccurredAt { get; set; }

        /// <summary>
        /// ID of the workspace associated with the event.
        /// </summary>
        [DataMember(Name = "workspace_id", IsRequired = false, EmitDefaultValue = false)]
        public override string WorkspaceId { get; set; }

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
    /// An [unmanaged access code](https://docs.seam.co/low-level-apis/smart-locks/access-codes/migrating-existing-access-codes) was converted successfully to a managed access code.
    /// </summary>
    [DataContract(Name = "seamModel_eventAccessCodeUnmanagedConvertedToManaged_model")]
    public class EventAccessCodeUnmanagedConvertedToManaged : Event
    {
        [JsonConstructorAttribute]
        protected EventAccessCodeUnmanagedConvertedToManaged() { }

        public EventAccessCodeUnmanagedConvertedToManaged(
            string accessCodeId = default,
            object? connectedAccountCustomMetadata = default,
            string connectedAccountId = default,
            string createdAt = default,
            object? deviceCustomMetadata = default,
            string deviceId = default,
            string? eventDescription = default,
            string eventId = default,
            string eventType = default,
            string occurredAt = default,
            string workspaceId = default
        )
        {
            AccessCodeId = accessCodeId;
            ConnectedAccountCustomMetadata = connectedAccountCustomMetadata;
            ConnectedAccountId = connectedAccountId;
            CreatedAt = createdAt;
            DeviceCustomMetadata = deviceCustomMetadata;
            DeviceId = deviceId;
            EventDescription = eventDescription;
            EventId = eventId;
            EventType = eventType;
            OccurredAt = occurredAt;
            WorkspaceId = workspaceId;
        }

        /// <summary>
        /// ID of the affected access code.
        /// </summary>
        [DataMember(Name = "access_code_id", IsRequired = false, EmitDefaultValue = false)]
        public string AccessCodeId { get; set; }

        /// <summary>
        /// Custom metadata of the connected account, present when connected_account_id is provided.
        /// </summary>
        [DataMember(
            Name = "connected_account_custom_metadata",
            IsRequired = false,
            EmitDefaultValue = false
        )]
        public object? ConnectedAccountCustomMetadata { get; set; }

        /// <summary>
        /// ID of the connected account associated with the affected access code.
        /// </summary>
        [DataMember(Name = "connected_account_id", IsRequired = false, EmitDefaultValue = false)]
        public string ConnectedAccountId { get; set; }

        /// <summary>
        /// Date and time at which the event was created.
        /// </summary>
        [DataMember(Name = "created_at", IsRequired = false, EmitDefaultValue = false)]
        public override string CreatedAt { get; set; }

        /// <summary>
        /// Custom metadata of the device, present when device_id is provided.
        /// </summary>
        [DataMember(Name = "device_custom_metadata", IsRequired = false, EmitDefaultValue = false)]
        public object? DeviceCustomMetadata { get; set; }

        /// <summary>
        /// ID of the device associated with the affected access code.
        /// </summary>
        [DataMember(Name = "device_id", IsRequired = false, EmitDefaultValue = false)]
        public string DeviceId { get; set; }

        /// <summary>
        /// Human-readable description of the event. Persisted when the event is created (so the creating code, including a provider, can supply a tailored description) and otherwise derived from the event.
        /// </summary>
        [DataMember(Name = "event_description", IsRequired = false, EmitDefaultValue = false)]
        public override string? EventDescription { get; set; }

        /// <summary>
        /// ID of the event.
        /// </summary>
        [DataMember(Name = "event_id", IsRequired = false, EmitDefaultValue = false)]
        public override string EventId { get; set; }

        [DataMember(Name = "event_type", IsRequired = true, EmitDefaultValue = false)]
        public override string EventType { get; } = "access_code.unmanaged.converted_to_managed";

        /// <summary>
        /// Date and time at which the event occurred.
        /// </summary>
        [DataMember(Name = "occurred_at", IsRequired = false, EmitDefaultValue = false)]
        public override string OccurredAt { get; set; }

        /// <summary>
        /// ID of the workspace associated with the event.
        /// </summary>
        [DataMember(Name = "workspace_id", IsRequired = false, EmitDefaultValue = false)]
        public override string WorkspaceId { get; set; }

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
    /// An [unmanaged access code](https://docs.seam.co/low-level-apis/smart-locks/access-codes/migrating-existing-access-codes) failed to be converted to a managed access code.
    /// </summary>
    [DataContract(Name = "seamModel_eventAccessCodeUnmanagedFailedToConvertToManaged_model")]
    public class EventAccessCodeUnmanagedFailedToConvertToManaged : Event
    {
        [JsonConstructorAttribute]
        protected EventAccessCodeUnmanagedFailedToConvertToManaged() { }

        public EventAccessCodeUnmanagedFailedToConvertToManaged(
            List<EventAccessCodeUnmanagedFailedToConvertToManagedAccessCodeErrors> accessCodeErrors =
                default,
            string accessCodeId = default,
            List<EventAccessCodeUnmanagedFailedToConvertToManagedAccessCodeWarnings> accessCodeWarnings =
                default,
            object? connectedAccountCustomMetadata = default,
            List<EventAccessCodeUnmanagedFailedToConvertToManagedConnectedAccountErrors> connectedAccountErrors =
                default,
            string connectedAccountId = default,
            List<EventAccessCodeUnmanagedFailedToConvertToManagedConnectedAccountWarnings> connectedAccountWarnings =
                default,
            string createdAt = default,
            object? deviceCustomMetadata = default,
            List<EventAccessCodeUnmanagedFailedToConvertToManagedDeviceErrors> deviceErrors =
                default,
            string deviceId = default,
            List<EventAccessCodeUnmanagedFailedToConvertToManagedDeviceWarnings> deviceWarnings =
                default,
            string? eventDescription = default,
            string eventId = default,
            string eventType = default,
            string occurredAt = default,
            string workspaceId = default
        )
        {
            AccessCodeErrors = accessCodeErrors;
            AccessCodeId = accessCodeId;
            AccessCodeWarnings = accessCodeWarnings;
            ConnectedAccountCustomMetadata = connectedAccountCustomMetadata;
            ConnectedAccountErrors = connectedAccountErrors;
            ConnectedAccountId = connectedAccountId;
            ConnectedAccountWarnings = connectedAccountWarnings;
            CreatedAt = createdAt;
            DeviceCustomMetadata = deviceCustomMetadata;
            DeviceErrors = deviceErrors;
            DeviceId = deviceId;
            DeviceWarnings = deviceWarnings;
            EventDescription = eventDescription;
            EventId = eventId;
            EventType = eventType;
            OccurredAt = occurredAt;
            WorkspaceId = workspaceId;
        }

        /// <summary>
        /// Errors associated with the access code.
        /// </summary>
        [DataMember(Name = "access_code_errors", IsRequired = false, EmitDefaultValue = false)]
        public List<EventAccessCodeUnmanagedFailedToConvertToManagedAccessCodeErrors> AccessCodeErrors { get; set; }

        /// <summary>
        /// ID of the affected access code.
        /// </summary>
        [DataMember(Name = "access_code_id", IsRequired = false, EmitDefaultValue = false)]
        public string AccessCodeId { get; set; }

        /// <summary>
        /// Warnings associated with the access code.
        /// </summary>
        [DataMember(Name = "access_code_warnings", IsRequired = false, EmitDefaultValue = false)]
        public List<EventAccessCodeUnmanagedFailedToConvertToManagedAccessCodeWarnings> AccessCodeWarnings { get; set; }

        /// <summary>
        /// Custom metadata of the connected account, present when connected_account_id is provided.
        /// </summary>
        [DataMember(
            Name = "connected_account_custom_metadata",
            IsRequired = false,
            EmitDefaultValue = false
        )]
        public object? ConnectedAccountCustomMetadata { get; set; }

        /// <summary>
        /// Errors associated with the connected account.
        /// </summary>
        [DataMember(
            Name = "connected_account_errors",
            IsRequired = false,
            EmitDefaultValue = false
        )]
        public List<EventAccessCodeUnmanagedFailedToConvertToManagedConnectedAccountErrors> ConnectedAccountErrors { get; set; }

        /// <summary>
        /// ID of the connected account associated with the affected access code.
        /// </summary>
        [DataMember(Name = "connected_account_id", IsRequired = false, EmitDefaultValue = false)]
        public string ConnectedAccountId { get; set; }

        /// <summary>
        /// Warnings associated with the connected account.
        /// </summary>
        [DataMember(
            Name = "connected_account_warnings",
            IsRequired = false,
            EmitDefaultValue = false
        )]
        public List<EventAccessCodeUnmanagedFailedToConvertToManagedConnectedAccountWarnings> ConnectedAccountWarnings { get; set; }

        /// <summary>
        /// Date and time at which the event was created.
        /// </summary>
        [DataMember(Name = "created_at", IsRequired = false, EmitDefaultValue = false)]
        public override string CreatedAt { get; set; }

        /// <summary>
        /// Custom metadata of the device, present when device_id is provided.
        /// </summary>
        [DataMember(Name = "device_custom_metadata", IsRequired = false, EmitDefaultValue = false)]
        public object? DeviceCustomMetadata { get; set; }

        /// <summary>
        /// Errors associated with the device.
        /// </summary>
        [DataMember(Name = "device_errors", IsRequired = false, EmitDefaultValue = false)]
        public List<EventAccessCodeUnmanagedFailedToConvertToManagedDeviceErrors> DeviceErrors { get; set; }

        /// <summary>
        /// ID of the device associated with the affected access code.
        /// </summary>
        [DataMember(Name = "device_id", IsRequired = false, EmitDefaultValue = false)]
        public string DeviceId { get; set; }

        /// <summary>
        /// Warnings associated with the device.
        /// </summary>
        [DataMember(Name = "device_warnings", IsRequired = false, EmitDefaultValue = false)]
        public List<EventAccessCodeUnmanagedFailedToConvertToManagedDeviceWarnings> DeviceWarnings { get; set; }

        /// <summary>
        /// Human-readable description of the event. Persisted when the event is created (so the creating code, including a provider, can supply a tailored description) and otherwise derived from the event.
        /// </summary>
        [DataMember(Name = "event_description", IsRequired = false, EmitDefaultValue = false)]
        public override string? EventDescription { get; set; }

        /// <summary>
        /// ID of the event.
        /// </summary>
        [DataMember(Name = "event_id", IsRequired = false, EmitDefaultValue = false)]
        public override string EventId { get; set; }

        [DataMember(Name = "event_type", IsRequired = true, EmitDefaultValue = false)]
        public override string EventType { get; } =
            "access_code.unmanaged.failed_to_convert_to_managed";

        /// <summary>
        /// Date and time at which the event occurred.
        /// </summary>
        [DataMember(Name = "occurred_at", IsRequired = false, EmitDefaultValue = false)]
        public override string OccurredAt { get; set; }

        /// <summary>
        /// ID of the workspace associated with the event.
        /// </summary>
        [DataMember(Name = "workspace_id", IsRequired = false, EmitDefaultValue = false)]
        public override string WorkspaceId { get; set; }

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
        Name = "seamModel_eventAccessCodeUnmanagedFailedToConvertToManagedAccessCodeErrors_model"
    )]
    public class EventAccessCodeUnmanagedFailedToConvertToManagedAccessCodeErrors
    {
        [JsonConstructorAttribute]
        protected EventAccessCodeUnmanagedFailedToConvertToManagedAccessCodeErrors() { }

        public EventAccessCodeUnmanagedFailedToConvertToManagedAccessCodeErrors(
            string createdAt = default,
            string errorCode = default,
            string message = default
        )
        {
            CreatedAt = createdAt;
            ErrorCode = errorCode;
            Message = message;
        }

        /// <summary>
        /// Date and time at which Seam created the error.
        /// </summary>
        [DataMember(Name = "created_at", IsRequired = false, EmitDefaultValue = false)]
        public string CreatedAt { get; set; }

        /// <summary>
        /// Unique identifier of the type of error. Enables quick recognition and categorization of the issue.
        /// </summary>
        [DataMember(Name = "error_code", IsRequired = false, EmitDefaultValue = false)]
        public string ErrorCode { get; set; }

        /// <summary>
        /// Detailed description of the error. Provides insights into the issue and potentially how to rectify it.
        /// </summary>
        [DataMember(Name = "message", IsRequired = false, EmitDefaultValue = false)]
        public string Message { get; set; }

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
        Name = "seamModel_eventAccessCodeUnmanagedFailedToConvertToManagedAccessCodeWarnings_model"
    )]
    public class EventAccessCodeUnmanagedFailedToConvertToManagedAccessCodeWarnings
    {
        [JsonConstructorAttribute]
        protected EventAccessCodeUnmanagedFailedToConvertToManagedAccessCodeWarnings() { }

        public EventAccessCodeUnmanagedFailedToConvertToManagedAccessCodeWarnings(
            string createdAt = default,
            string message = default,
            string warningCode = default
        )
        {
            CreatedAt = createdAt;
            Message = message;
            WarningCode = warningCode;
        }

        /// <summary>
        /// Date and time at which Seam created the warning.
        /// </summary>
        [DataMember(Name = "created_at", IsRequired = false, EmitDefaultValue = false)]
        public string CreatedAt { get; set; }

        /// <summary>
        /// Detailed description of the warning. Provides insights into the issue and potentially how to rectify it.
        /// </summary>
        [DataMember(Name = "message", IsRequired = false, EmitDefaultValue = false)]
        public string Message { get; set; }

        /// <summary>
        /// Unique identifier of the type of warning. Enables quick recognition and categorization of the issue.
        /// </summary>
        [DataMember(Name = "warning_code", IsRequired = false, EmitDefaultValue = false)]
        public string WarningCode { get; set; }

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
        Name = "seamModel_eventAccessCodeUnmanagedFailedToConvertToManagedConnectedAccountErrors_model"
    )]
    public class EventAccessCodeUnmanagedFailedToConvertToManagedConnectedAccountErrors
    {
        [JsonConstructorAttribute]
        protected EventAccessCodeUnmanagedFailedToConvertToManagedConnectedAccountErrors() { }

        public EventAccessCodeUnmanagedFailedToConvertToManagedConnectedAccountErrors(
            string createdAt = default,
            string errorCode = default,
            string message = default
        )
        {
            CreatedAt = createdAt;
            ErrorCode = errorCode;
            Message = message;
        }

        /// <summary>
        /// Date and time at which Seam created the error.
        /// </summary>
        [DataMember(Name = "created_at", IsRequired = false, EmitDefaultValue = false)]
        public string CreatedAt { get; set; }

        /// <summary>
        /// Unique identifier of the type of error. Enables quick recognition and categorization of the issue.
        /// </summary>
        [DataMember(Name = "error_code", IsRequired = false, EmitDefaultValue = false)]
        public string ErrorCode { get; set; }

        /// <summary>
        /// Detailed description of the error. Provides insights into the issue and potentially how to rectify it.
        /// </summary>
        [DataMember(Name = "message", IsRequired = false, EmitDefaultValue = false)]
        public string Message { get; set; }

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
        Name = "seamModel_eventAccessCodeUnmanagedFailedToConvertToManagedConnectedAccountWarnings_model"
    )]
    public class EventAccessCodeUnmanagedFailedToConvertToManagedConnectedAccountWarnings
    {
        [JsonConstructorAttribute]
        protected EventAccessCodeUnmanagedFailedToConvertToManagedConnectedAccountWarnings() { }

        public EventAccessCodeUnmanagedFailedToConvertToManagedConnectedAccountWarnings(
            string createdAt = default,
            string message = default,
            string warningCode = default
        )
        {
            CreatedAt = createdAt;
            Message = message;
            WarningCode = warningCode;
        }

        /// <summary>
        /// Date and time at which Seam created the warning.
        /// </summary>
        [DataMember(Name = "created_at", IsRequired = false, EmitDefaultValue = false)]
        public string CreatedAt { get; set; }

        /// <summary>
        /// Detailed description of the warning. Provides insights into the issue and potentially how to rectify it.
        /// </summary>
        [DataMember(Name = "message", IsRequired = false, EmitDefaultValue = false)]
        public string Message { get; set; }

        /// <summary>
        /// Unique identifier of the type of warning. Enables quick recognition and categorization of the issue.
        /// </summary>
        [DataMember(Name = "warning_code", IsRequired = false, EmitDefaultValue = false)]
        public string WarningCode { get; set; }

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
        Name = "seamModel_eventAccessCodeUnmanagedFailedToConvertToManagedDeviceErrors_model"
    )]
    public class EventAccessCodeUnmanagedFailedToConvertToManagedDeviceErrors
    {
        [JsonConstructorAttribute]
        protected EventAccessCodeUnmanagedFailedToConvertToManagedDeviceErrors() { }

        public EventAccessCodeUnmanagedFailedToConvertToManagedDeviceErrors(
            string createdAt = default,
            string errorCode = default,
            string message = default
        )
        {
            CreatedAt = createdAt;
            ErrorCode = errorCode;
            Message = message;
        }

        /// <summary>
        /// Date and time at which Seam created the error.
        /// </summary>
        [DataMember(Name = "created_at", IsRequired = false, EmitDefaultValue = false)]
        public string CreatedAt { get; set; }

        /// <summary>
        /// Unique identifier of the type of error. Enables quick recognition and categorization of the issue.
        /// </summary>
        [DataMember(Name = "error_code", IsRequired = false, EmitDefaultValue = false)]
        public string ErrorCode { get; set; }

        /// <summary>
        /// Detailed description of the error. Provides insights into the issue and potentially how to rectify it.
        /// </summary>
        [DataMember(Name = "message", IsRequired = false, EmitDefaultValue = false)]
        public string Message { get; set; }

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
        Name = "seamModel_eventAccessCodeUnmanagedFailedToConvertToManagedDeviceWarnings_model"
    )]
    public class EventAccessCodeUnmanagedFailedToConvertToManagedDeviceWarnings
    {
        [JsonConstructorAttribute]
        protected EventAccessCodeUnmanagedFailedToConvertToManagedDeviceWarnings() { }

        public EventAccessCodeUnmanagedFailedToConvertToManagedDeviceWarnings(
            string createdAt = default,
            string message = default,
            string warningCode = default
        )
        {
            CreatedAt = createdAt;
            Message = message;
            WarningCode = warningCode;
        }

        /// <summary>
        /// Date and time at which Seam created the warning.
        /// </summary>
        [DataMember(Name = "created_at", IsRequired = false, EmitDefaultValue = false)]
        public string CreatedAt { get; set; }

        /// <summary>
        /// Detailed description of the warning. Provides insights into the issue and potentially how to rectify it.
        /// </summary>
        [DataMember(Name = "message", IsRequired = false, EmitDefaultValue = false)]
        public string Message { get; set; }

        /// <summary>
        /// Unique identifier of the type of warning. Enables quick recognition and categorization of the issue.
        /// </summary>
        [DataMember(Name = "warning_code", IsRequired = false, EmitDefaultValue = false)]
        public string WarningCode { get; set; }

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
    /// An [unmanaged access code](https://docs.seam.co/low-level-apis/smart-locks/access-codes/migrating-existing-access-codes) was created on a device.
    /// </summary>
    [DataContract(Name = "seamModel_eventAccessCodeUnmanagedCreated_model")]
    public class EventAccessCodeUnmanagedCreated : Event
    {
        [JsonConstructorAttribute]
        protected EventAccessCodeUnmanagedCreated() { }

        public EventAccessCodeUnmanagedCreated(
            string accessCodeId = default,
            object? connectedAccountCustomMetadata = default,
            string connectedAccountId = default,
            string createdAt = default,
            object? deviceCustomMetadata = default,
            string deviceId = default,
            string? eventDescription = default,
            string eventId = default,
            string eventType = default,
            string occurredAt = default,
            string workspaceId = default
        )
        {
            AccessCodeId = accessCodeId;
            ConnectedAccountCustomMetadata = connectedAccountCustomMetadata;
            ConnectedAccountId = connectedAccountId;
            CreatedAt = createdAt;
            DeviceCustomMetadata = deviceCustomMetadata;
            DeviceId = deviceId;
            EventDescription = eventDescription;
            EventId = eventId;
            EventType = eventType;
            OccurredAt = occurredAt;
            WorkspaceId = workspaceId;
        }

        /// <summary>
        /// ID of the affected access code.
        /// </summary>
        [DataMember(Name = "access_code_id", IsRequired = false, EmitDefaultValue = false)]
        public string AccessCodeId { get; set; }

        /// <summary>
        /// Custom metadata of the connected account, present when connected_account_id is provided.
        /// </summary>
        [DataMember(
            Name = "connected_account_custom_metadata",
            IsRequired = false,
            EmitDefaultValue = false
        )]
        public object? ConnectedAccountCustomMetadata { get; set; }

        /// <summary>
        /// ID of the connected account associated with the affected access code.
        /// </summary>
        [DataMember(Name = "connected_account_id", IsRequired = false, EmitDefaultValue = false)]
        public string ConnectedAccountId { get; set; }

        /// <summary>
        /// Date and time at which the event was created.
        /// </summary>
        [DataMember(Name = "created_at", IsRequired = false, EmitDefaultValue = false)]
        public override string CreatedAt { get; set; }

        /// <summary>
        /// Custom metadata of the device, present when device_id is provided.
        /// </summary>
        [DataMember(Name = "device_custom_metadata", IsRequired = false, EmitDefaultValue = false)]
        public object? DeviceCustomMetadata { get; set; }

        /// <summary>
        /// ID of the device associated with the affected access code.
        /// </summary>
        [DataMember(Name = "device_id", IsRequired = false, EmitDefaultValue = false)]
        public string DeviceId { get; set; }

        /// <summary>
        /// Human-readable description of the event. Persisted when the event is created (so the creating code, including a provider, can supply a tailored description) and otherwise derived from the event.
        /// </summary>
        [DataMember(Name = "event_description", IsRequired = false, EmitDefaultValue = false)]
        public override string? EventDescription { get; set; }

        /// <summary>
        /// ID of the event.
        /// </summary>
        [DataMember(Name = "event_id", IsRequired = false, EmitDefaultValue = false)]
        public override string EventId { get; set; }

        [DataMember(Name = "event_type", IsRequired = true, EmitDefaultValue = false)]
        public override string EventType { get; } = "access_code.unmanaged.created";

        /// <summary>
        /// Date and time at which the event occurred.
        /// </summary>
        [DataMember(Name = "occurred_at", IsRequired = false, EmitDefaultValue = false)]
        public override string OccurredAt { get; set; }

        /// <summary>
        /// ID of the workspace associated with the event.
        /// </summary>
        [DataMember(Name = "workspace_id", IsRequired = false, EmitDefaultValue = false)]
        public override string WorkspaceId { get; set; }

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
    /// An [unmanaged access code](https://docs.seam.co/low-level-apis/smart-locks/access-codes/migrating-existing-access-codes) was removed from a device.
    /// </summary>
    [DataContract(Name = "seamModel_eventAccessCodeUnmanagedRemoved_model")]
    public class EventAccessCodeUnmanagedRemoved : Event
    {
        [JsonConstructorAttribute]
        protected EventAccessCodeUnmanagedRemoved() { }

        public EventAccessCodeUnmanagedRemoved(
            string accessCodeId = default,
            object? connectedAccountCustomMetadata = default,
            string connectedAccountId = default,
            string createdAt = default,
            object? deviceCustomMetadata = default,
            string deviceId = default,
            string? eventDescription = default,
            string eventId = default,
            string eventType = default,
            string occurredAt = default,
            string workspaceId = default
        )
        {
            AccessCodeId = accessCodeId;
            ConnectedAccountCustomMetadata = connectedAccountCustomMetadata;
            ConnectedAccountId = connectedAccountId;
            CreatedAt = createdAt;
            DeviceCustomMetadata = deviceCustomMetadata;
            DeviceId = deviceId;
            EventDescription = eventDescription;
            EventId = eventId;
            EventType = eventType;
            OccurredAt = occurredAt;
            WorkspaceId = workspaceId;
        }

        /// <summary>
        /// ID of the affected access code.
        /// </summary>
        [DataMember(Name = "access_code_id", IsRequired = false, EmitDefaultValue = false)]
        public string AccessCodeId { get; set; }

        /// <summary>
        /// Custom metadata of the connected account, present when connected_account_id is provided.
        /// </summary>
        [DataMember(
            Name = "connected_account_custom_metadata",
            IsRequired = false,
            EmitDefaultValue = false
        )]
        public object? ConnectedAccountCustomMetadata { get; set; }

        /// <summary>
        /// ID of the connected account associated with the affected access code.
        /// </summary>
        [DataMember(Name = "connected_account_id", IsRequired = false, EmitDefaultValue = false)]
        public string ConnectedAccountId { get; set; }

        /// <summary>
        /// Date and time at which the event was created.
        /// </summary>
        [DataMember(Name = "created_at", IsRequired = false, EmitDefaultValue = false)]
        public override string CreatedAt { get; set; }

        /// <summary>
        /// Custom metadata of the device, present when device_id is provided.
        /// </summary>
        [DataMember(Name = "device_custom_metadata", IsRequired = false, EmitDefaultValue = false)]
        public object? DeviceCustomMetadata { get; set; }

        /// <summary>
        /// ID of the device associated with the affected access code.
        /// </summary>
        [DataMember(Name = "device_id", IsRequired = false, EmitDefaultValue = false)]
        public string DeviceId { get; set; }

        /// <summary>
        /// Human-readable description of the event. Persisted when the event is created (so the creating code, including a provider, can supply a tailored description) and otherwise derived from the event.
        /// </summary>
        [DataMember(Name = "event_description", IsRequired = false, EmitDefaultValue = false)]
        public override string? EventDescription { get; set; }

        /// <summary>
        /// ID of the event.
        /// </summary>
        [DataMember(Name = "event_id", IsRequired = false, EmitDefaultValue = false)]
        public override string EventId { get; set; }

        [DataMember(Name = "event_type", IsRequired = true, EmitDefaultValue = false)]
        public override string EventType { get; } = "access_code.unmanaged.removed";

        /// <summary>
        /// Date and time at which the event occurred.
        /// </summary>
        [DataMember(Name = "occurred_at", IsRequired = false, EmitDefaultValue = false)]
        public override string OccurredAt { get; set; }

        /// <summary>
        /// ID of the workspace associated with the event.
        /// </summary>
        [DataMember(Name = "workspace_id", IsRequired = false, EmitDefaultValue = false)]
        public override string WorkspaceId { get; set; }

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
    /// An Access Grant was created.
    /// </summary>
    [DataContract(Name = "seamModel_eventAccessGrantCreated_model")]
    public class EventAccessGrantCreated : Event
    {
        [JsonConstructorAttribute]
        protected EventAccessGrantCreated() { }

        public EventAccessGrantCreated(
            string accessGrantId = default,
            string createdAt = default,
            string? eventDescription = default,
            string eventId = default,
            string eventType = default,
            string occurredAt = default,
            string workspaceId = default
        )
        {
            AccessGrantId = accessGrantId;
            CreatedAt = createdAt;
            EventDescription = eventDescription;
            EventId = eventId;
            EventType = eventType;
            OccurredAt = occurredAt;
            WorkspaceId = workspaceId;
        }

        /// <summary>
        /// ID of the affected Access Grant.
        /// </summary>
        [DataMember(Name = "access_grant_id", IsRequired = false, EmitDefaultValue = false)]
        public string AccessGrantId { get; set; }

        /// <summary>
        /// Date and time at which the event was created.
        /// </summary>
        [DataMember(Name = "created_at", IsRequired = false, EmitDefaultValue = false)]
        public override string CreatedAt { get; set; }

        /// <summary>
        /// Human-readable description of the event. Persisted when the event is created (so the creating code, including a provider, can supply a tailored description) and otherwise derived from the event.
        /// </summary>
        [DataMember(Name = "event_description", IsRequired = false, EmitDefaultValue = false)]
        public override string? EventDescription { get; set; }

        /// <summary>
        /// ID of the event.
        /// </summary>
        [DataMember(Name = "event_id", IsRequired = false, EmitDefaultValue = false)]
        public override string EventId { get; set; }

        [DataMember(Name = "event_type", IsRequired = true, EmitDefaultValue = false)]
        public override string EventType { get; } = "access_grant.created";

        /// <summary>
        /// Date and time at which the event occurred.
        /// </summary>
        [DataMember(Name = "occurred_at", IsRequired = false, EmitDefaultValue = false)]
        public override string OccurredAt { get; set; }

        /// <summary>
        /// ID of the workspace associated with the event.
        /// </summary>
        [DataMember(Name = "workspace_id", IsRequired = false, EmitDefaultValue = false)]
        public override string WorkspaceId { get; set; }

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
    /// An Access Grant was deleted.
    /// </summary>
    [DataContract(Name = "seamModel_eventAccessGrantDeleted_model")]
    public class EventAccessGrantDeleted : Event
    {
        [JsonConstructorAttribute]
        protected EventAccessGrantDeleted() { }

        public EventAccessGrantDeleted(
            string accessGrantId = default,
            string createdAt = default,
            string? eventDescription = default,
            string eventId = default,
            string eventType = default,
            string occurredAt = default,
            string workspaceId = default
        )
        {
            AccessGrantId = accessGrantId;
            CreatedAt = createdAt;
            EventDescription = eventDescription;
            EventId = eventId;
            EventType = eventType;
            OccurredAt = occurredAt;
            WorkspaceId = workspaceId;
        }

        /// <summary>
        /// ID of the affected Access Grant.
        /// </summary>
        [DataMember(Name = "access_grant_id", IsRequired = false, EmitDefaultValue = false)]
        public string AccessGrantId { get; set; }

        /// <summary>
        /// Date and time at which the event was created.
        /// </summary>
        [DataMember(Name = "created_at", IsRequired = false, EmitDefaultValue = false)]
        public override string CreatedAt { get; set; }

        /// <summary>
        /// Human-readable description of the event. Persisted when the event is created (so the creating code, including a provider, can supply a tailored description) and otherwise derived from the event.
        /// </summary>
        [DataMember(Name = "event_description", IsRequired = false, EmitDefaultValue = false)]
        public override string? EventDescription { get; set; }

        /// <summary>
        /// ID of the event.
        /// </summary>
        [DataMember(Name = "event_id", IsRequired = false, EmitDefaultValue = false)]
        public override string EventId { get; set; }

        [DataMember(Name = "event_type", IsRequired = true, EmitDefaultValue = false)]
        public override string EventType { get; } = "access_grant.deleted";

        /// <summary>
        /// Date and time at which the event occurred.
        /// </summary>
        [DataMember(Name = "occurred_at", IsRequired = false, EmitDefaultValue = false)]
        public override string OccurredAt { get; set; }

        /// <summary>
        /// ID of the workspace associated with the event.
        /// </summary>
        [DataMember(Name = "workspace_id", IsRequired = false, EmitDefaultValue = false)]
        public override string WorkspaceId { get; set; }

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
    /// All access requested for an Access Grant was successfully granted.
    /// </summary>
    [DataContract(Name = "seamModel_eventAccessGrantAccessGrantedToAllDoors_model")]
    public class EventAccessGrantAccessGrantedToAllDoors : Event
    {
        [JsonConstructorAttribute]
        protected EventAccessGrantAccessGrantedToAllDoors() { }

        public EventAccessGrantAccessGrantedToAllDoors(
            string accessGrantId = default,
            string createdAt = default,
            string? eventDescription = default,
            string eventId = default,
            string eventType = default,
            string occurredAt = default,
            string workspaceId = default
        )
        {
            AccessGrantId = accessGrantId;
            CreatedAt = createdAt;
            EventDescription = eventDescription;
            EventId = eventId;
            EventType = eventType;
            OccurredAt = occurredAt;
            WorkspaceId = workspaceId;
        }

        /// <summary>
        /// ID of the affected Access Grant.
        /// </summary>
        [DataMember(Name = "access_grant_id", IsRequired = false, EmitDefaultValue = false)]
        public string AccessGrantId { get; set; }

        /// <summary>
        /// Date and time at which the event was created.
        /// </summary>
        [DataMember(Name = "created_at", IsRequired = false, EmitDefaultValue = false)]
        public override string CreatedAt { get; set; }

        /// <summary>
        /// Human-readable description of the event. Persisted when the event is created (so the creating code, including a provider, can supply a tailored description) and otherwise derived from the event.
        /// </summary>
        [DataMember(Name = "event_description", IsRequired = false, EmitDefaultValue = false)]
        public override string? EventDescription { get; set; }

        /// <summary>
        /// ID of the event.
        /// </summary>
        [DataMember(Name = "event_id", IsRequired = false, EmitDefaultValue = false)]
        public override string EventId { get; set; }

        [DataMember(Name = "event_type", IsRequired = true, EmitDefaultValue = false)]
        public override string EventType { get; } = "access_grant.access_granted_to_all_doors";

        /// <summary>
        /// Date and time at which the event occurred.
        /// </summary>
        [DataMember(Name = "occurred_at", IsRequired = false, EmitDefaultValue = false)]
        public override string OccurredAt { get; set; }

        /// <summary>
        /// ID of the workspace associated with the event.
        /// </summary>
        [DataMember(Name = "workspace_id", IsRequired = false, EmitDefaultValue = false)]
        public override string WorkspaceId { get; set; }

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
    /// Access requested as part of an Access Grant to a particular door was successfully granted.
    /// </summary>
    [DataContract(Name = "seamModel_eventAccessGrantAccessGrantedToDoor_model")]
    public class EventAccessGrantAccessGrantedToDoor : Event
    {
        [JsonConstructorAttribute]
        protected EventAccessGrantAccessGrantedToDoor() { }

        public EventAccessGrantAccessGrantedToDoor(
            string accessGrantId = default,
            string acsEntranceId = default,
            string createdAt = default,
            string? eventDescription = default,
            string eventId = default,
            string eventType = default,
            string occurredAt = default,
            string workspaceId = default
        )
        {
            AccessGrantId = accessGrantId;
            AcsEntranceId = acsEntranceId;
            CreatedAt = createdAt;
            EventDescription = eventDescription;
            EventId = eventId;
            EventType = eventType;
            OccurredAt = occurredAt;
            WorkspaceId = workspaceId;
        }

        /// <summary>
        /// ID of the affected Access Grant.
        /// </summary>
        [DataMember(Name = "access_grant_id", IsRequired = false, EmitDefaultValue = false)]
        public string AccessGrantId { get; set; }

        /// <summary>
        /// ID of the affected [entrance](https://docs.seam.co/low-level-apis/access-systems/retrieving-entrance-details).
        /// </summary>
        [DataMember(Name = "acs_entrance_id", IsRequired = false, EmitDefaultValue = false)]
        public string AcsEntranceId { get; set; }

        /// <summary>
        /// Date and time at which the event was created.
        /// </summary>
        [DataMember(Name = "created_at", IsRequired = false, EmitDefaultValue = false)]
        public override string CreatedAt { get; set; }

        /// <summary>
        /// Human-readable description of the event. Persisted when the event is created (so the creating code, including a provider, can supply a tailored description) and otherwise derived from the event.
        /// </summary>
        [DataMember(Name = "event_description", IsRequired = false, EmitDefaultValue = false)]
        public override string? EventDescription { get; set; }

        /// <summary>
        /// ID of the event.
        /// </summary>
        [DataMember(Name = "event_id", IsRequired = false, EmitDefaultValue = false)]
        public override string EventId { get; set; }

        [DataMember(Name = "event_type", IsRequired = true, EmitDefaultValue = false)]
        public override string EventType { get; } = "access_grant.access_granted_to_door";

        /// <summary>
        /// Date and time at which the event occurred.
        /// </summary>
        [DataMember(Name = "occurred_at", IsRequired = false, EmitDefaultValue = false)]
        public override string OccurredAt { get; set; }

        /// <summary>
        /// ID of the workspace associated with the event.
        /// </summary>
        [DataMember(Name = "workspace_id", IsRequired = false, EmitDefaultValue = false)]
        public override string WorkspaceId { get; set; }

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
    /// Access to a particular door that was requested as part of an Access Grant was lost.
    /// </summary>
    [DataContract(Name = "seamModel_eventAccessGrantAccessToDoorLost_model")]
    public class EventAccessGrantAccessToDoorLost : Event
    {
        [JsonConstructorAttribute]
        protected EventAccessGrantAccessToDoorLost() { }

        public EventAccessGrantAccessToDoorLost(
            string accessGrantId = default,
            string acsEntranceId = default,
            string createdAt = default,
            string? eventDescription = default,
            string eventId = default,
            string eventType = default,
            string occurredAt = default,
            string workspaceId = default
        )
        {
            AccessGrantId = accessGrantId;
            AcsEntranceId = acsEntranceId;
            CreatedAt = createdAt;
            EventDescription = eventDescription;
            EventId = eventId;
            EventType = eventType;
            OccurredAt = occurredAt;
            WorkspaceId = workspaceId;
        }

        /// <summary>
        /// ID of the affected Access Grant.
        /// </summary>
        [DataMember(Name = "access_grant_id", IsRequired = false, EmitDefaultValue = false)]
        public string AccessGrantId { get; set; }

        /// <summary>
        /// ID of the affected [entrance](https://docs.seam.co/low-level-apis/access-systems/retrieving-entrance-details).
        /// </summary>
        [DataMember(Name = "acs_entrance_id", IsRequired = false, EmitDefaultValue = false)]
        public string AcsEntranceId { get; set; }

        /// <summary>
        /// Date and time at which the event was created.
        /// </summary>
        [DataMember(Name = "created_at", IsRequired = false, EmitDefaultValue = false)]
        public override string CreatedAt { get; set; }

        /// <summary>
        /// Human-readable description of the event. Persisted when the event is created (so the creating code, including a provider, can supply a tailored description) and otherwise derived from the event.
        /// </summary>
        [DataMember(Name = "event_description", IsRequired = false, EmitDefaultValue = false)]
        public override string? EventDescription { get; set; }

        /// <summary>
        /// ID of the event.
        /// </summary>
        [DataMember(Name = "event_id", IsRequired = false, EmitDefaultValue = false)]
        public override string EventId { get; set; }

        [DataMember(Name = "event_type", IsRequired = true, EmitDefaultValue = false)]
        public override string EventType { get; } = "access_grant.access_to_door_lost";

        /// <summary>
        /// Date and time at which the event occurred.
        /// </summary>
        [DataMember(Name = "occurred_at", IsRequired = false, EmitDefaultValue = false)]
        public override string OccurredAt { get; set; }

        /// <summary>
        /// ID of the workspace associated with the event.
        /// </summary>
        [DataMember(Name = "workspace_id", IsRequired = false, EmitDefaultValue = false)]
        public override string WorkspaceId { get; set; }

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
    /// An Access Grant&apos;s start or end time was changed.
    /// </summary>
    [DataContract(Name = "seamModel_eventAccessGrantAccessTimesChanged_model")]
    public class EventAccessGrantAccessTimesChanged : Event
    {
        [JsonConstructorAttribute]
        protected EventAccessGrantAccessTimesChanged() { }

        public EventAccessGrantAccessTimesChanged(
            string accessGrantId = default,
            string? accessGrantKey = default,
            string createdAt = default,
            string? endsAt = default,
            string? eventDescription = default,
            string eventId = default,
            string eventType = default,
            string occurredAt = default,
            string? startsAt = default,
            string workspaceId = default
        )
        {
            AccessGrantId = accessGrantId;
            AccessGrantKey = accessGrantKey;
            CreatedAt = createdAt;
            EndsAt = endsAt;
            EventDescription = eventDescription;
            EventId = eventId;
            EventType = eventType;
            OccurredAt = occurredAt;
            StartsAt = startsAt;
            WorkspaceId = workspaceId;
        }

        /// <summary>
        /// ID of the affected Access Grant.
        /// </summary>
        [DataMember(Name = "access_grant_id", IsRequired = false, EmitDefaultValue = false)]
        public string AccessGrantId { get; set; }

        /// <summary>
        /// Key of the affected Access Grant (if present).
        /// </summary>
        [DataMember(Name = "access_grant_key", IsRequired = false, EmitDefaultValue = false)]
        public string? AccessGrantKey { get; set; }

        /// <summary>
        /// Date and time at which the event was created.
        /// </summary>
        [DataMember(Name = "created_at", IsRequired = false, EmitDefaultValue = false)]
        public override string CreatedAt { get; set; }

        /// <summary>
        /// The new end time for the access grant.
        /// </summary>
        [DataMember(Name = "ends_at", IsRequired = false, EmitDefaultValue = false)]
        public string? EndsAt { get; set; }

        /// <summary>
        /// Human-readable description of the event. Persisted when the event is created (so the creating code, including a provider, can supply a tailored description) and otherwise derived from the event.
        /// </summary>
        [DataMember(Name = "event_description", IsRequired = false, EmitDefaultValue = false)]
        public override string? EventDescription { get; set; }

        /// <summary>
        /// ID of the event.
        /// </summary>
        [DataMember(Name = "event_id", IsRequired = false, EmitDefaultValue = false)]
        public override string EventId { get; set; }

        [DataMember(Name = "event_type", IsRequired = true, EmitDefaultValue = false)]
        public override string EventType { get; } = "access_grant.access_times_changed";

        /// <summary>
        /// Date and time at which the event occurred.
        /// </summary>
        [DataMember(Name = "occurred_at", IsRequired = false, EmitDefaultValue = false)]
        public override string OccurredAt { get; set; }

        /// <summary>
        /// The new start time for the access grant.
        /// </summary>
        [DataMember(Name = "starts_at", IsRequired = false, EmitDefaultValue = false)]
        public string? StartsAt { get; set; }

        /// <summary>
        /// ID of the workspace associated with the event.
        /// </summary>
        [DataMember(Name = "workspace_id", IsRequired = false, EmitDefaultValue = false)]
        public override string WorkspaceId { get; set; }

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
    /// One or more requested access methods could not be created for an Access Grant.
    /// </summary>
    [DataContract(Name = "seamModel_eventAccessGrantCouldNotCreateRequestedAccessMethods_model")]
    public class EventAccessGrantCouldNotCreateRequestedAccessMethods : Event
    {
        [JsonConstructorAttribute]
        protected EventAccessGrantCouldNotCreateRequestedAccessMethods() { }

        public EventAccessGrantCouldNotCreateRequestedAccessMethods(
            string accessGrantId = default,
            string createdAt = default,
            string errorMessage = default,
            string? eventDescription = default,
            string eventId = default,
            string eventType = default,
            List<string>? missingDeviceIds = default,
            string occurredAt = default,
            string workspaceId = default
        )
        {
            AccessGrantId = accessGrantId;
            CreatedAt = createdAt;
            ErrorMessage = errorMessage;
            EventDescription = eventDescription;
            EventId = eventId;
            EventType = eventType;
            MissingDeviceIds = missingDeviceIds;
            OccurredAt = occurredAt;
            WorkspaceId = workspaceId;
        }

        /// <summary>
        /// ID of the affected Access Grant.
        /// </summary>
        [DataMember(Name = "access_grant_id", IsRequired = false, EmitDefaultValue = false)]
        public string AccessGrantId { get; set; }

        /// <summary>
        /// Date and time at which the event was created.
        /// </summary>
        [DataMember(Name = "created_at", IsRequired = false, EmitDefaultValue = false)]
        public override string CreatedAt { get; set; }

        /// <summary>
        /// Description of why the access methods could not be created.
        /// </summary>
        [DataMember(Name = "error_message", IsRequired = false, EmitDefaultValue = false)]
        public string ErrorMessage { get; set; }

        /// <summary>
        /// Human-readable description of the event. Persisted when the event is created (so the creating code, including a provider, can supply a tailored description) and otherwise derived from the event.
        /// </summary>
        [DataMember(Name = "event_description", IsRequired = false, EmitDefaultValue = false)]
        public override string? EventDescription { get; set; }

        /// <summary>
        /// ID of the event.
        /// </summary>
        [DataMember(Name = "event_id", IsRequired = false, EmitDefaultValue = false)]
        public override string EventId { get; set; }

        [DataMember(Name = "event_type", IsRequired = true, EmitDefaultValue = false)]
        public override string EventType { get; } =
            "access_grant.could_not_create_requested_access_methods";

        /// <summary>
        /// IDs of the devices that did not receive a requested access method. Use these to identify which specific devices failed without having to fetch the Access Grant.
        /// </summary>
        [DataMember(Name = "missing_device_ids", IsRequired = false, EmitDefaultValue = false)]
        public List<string>? MissingDeviceIds { get; set; }

        /// <summary>
        /// Date and time at which the event occurred.
        /// </summary>
        [DataMember(Name = "occurred_at", IsRequired = false, EmitDefaultValue = false)]
        public override string OccurredAt { get; set; }

        /// <summary>
        /// ID of the workspace associated with the event.
        /// </summary>
        [DataMember(Name = "workspace_id", IsRequired = false, EmitDefaultValue = false)]
        public override string WorkspaceId { get; set; }

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
    /// An access method was issued.
    /// </summary>
    [DataContract(Name = "seamModel_eventAccessMethodIssued_model")]
    public class EventAccessMethodIssued : Event
    {
        [JsonConstructorAttribute]
        protected EventAccessMethodIssued() { }

        public EventAccessMethodIssued(
            List<string> accessGrantIds = default,
            List<string>? accessGrantKeys = default,
            string accessMethodId = default,
            string? code = default,
            string createdAt = default,
            string? eventDescription = default,
            string eventId = default,
            string eventType = default,
            bool? isBackupCode = default,
            string occurredAt = default,
            string workspaceId = default
        )
        {
            AccessGrantIds = accessGrantIds;
            AccessGrantKeys = accessGrantKeys;
            AccessMethodId = accessMethodId;
            Code = code;
            CreatedAt = createdAt;
            EventDescription = eventDescription;
            EventId = eventId;
            EventType = eventType;
            IsBackupCode = isBackupCode;
            OccurredAt = occurredAt;
            WorkspaceId = workspaceId;
        }

        /// <summary>
        /// IDs of the access grants associated with this access method.
        /// </summary>
        [DataMember(Name = "access_grant_ids", IsRequired = false, EmitDefaultValue = false)]
        public List<string> AccessGrantIds { get; set; }

        /// <summary>
        /// Keys of the access grants associated with this access method (if present).
        /// </summary>
        [DataMember(Name = "access_grant_keys", IsRequired = false, EmitDefaultValue = false)]
        public List<string>? AccessGrantKeys { get; set; }

        /// <summary>
        /// ID of the affected access method.
        /// </summary>
        [DataMember(Name = "access_method_id", IsRequired = false, EmitDefaultValue = false)]
        public string AccessMethodId { get; set; }

        /// <summary>
        /// The actual PIN code for code access methods (only present when mode is &apos;code&apos;).
        /// </summary>
        [DataMember(Name = "code", IsRequired = false, EmitDefaultValue = false)]
        public string? Code { get; set; }

        /// <summary>
        /// Date and time at which the event was created.
        /// </summary>
        [DataMember(Name = "created_at", IsRequired = false, EmitDefaultValue = false)]
        public override string CreatedAt { get; set; }

        /// <summary>
        /// Human-readable description of the event. Persisted when the event is created (so the creating code, including a provider, can supply a tailored description) and otherwise derived from the event.
        /// </summary>
        [DataMember(Name = "event_description", IsRequired = false, EmitDefaultValue = false)]
        public override string? EventDescription { get; set; }

        /// <summary>
        /// ID of the event.
        /// </summary>
        [DataMember(Name = "event_id", IsRequired = false, EmitDefaultValue = false)]
        public override string EventId { get; set; }

        [DataMember(Name = "event_type", IsRequired = true, EmitDefaultValue = false)]
        public override string EventType { get; } = "access_method.issued";

        /// <summary>
        /// Indicates whether the code is a backup code (only present when mode is &apos;code&apos; and a backup code was used).
        /// </summary>
        [DataMember(Name = "is_backup_code", IsRequired = false, EmitDefaultValue = false)]
        public bool? IsBackupCode { get; set; }

        /// <summary>
        /// Date and time at which the event occurred.
        /// </summary>
        [DataMember(Name = "occurred_at", IsRequired = false, EmitDefaultValue = false)]
        public override string OccurredAt { get; set; }

        /// <summary>
        /// ID of the workspace associated with the event.
        /// </summary>
        [DataMember(Name = "workspace_id", IsRequired = false, EmitDefaultValue = false)]
        public override string WorkspaceId { get; set; }

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
    /// An access method was revoked.
    /// </summary>
    [DataContract(Name = "seamModel_eventAccessMethodRevoked_model")]
    public class EventAccessMethodRevoked : Event
    {
        [JsonConstructorAttribute]
        protected EventAccessMethodRevoked() { }

        public EventAccessMethodRevoked(
            List<string> accessGrantIds = default,
            List<string>? accessGrantKeys = default,
            string accessMethodId = default,
            string createdAt = default,
            string? eventDescription = default,
            string eventId = default,
            string eventType = default,
            string occurredAt = default,
            string workspaceId = default
        )
        {
            AccessGrantIds = accessGrantIds;
            AccessGrantKeys = accessGrantKeys;
            AccessMethodId = accessMethodId;
            CreatedAt = createdAt;
            EventDescription = eventDescription;
            EventId = eventId;
            EventType = eventType;
            OccurredAt = occurredAt;
            WorkspaceId = workspaceId;
        }

        /// <summary>
        /// IDs of the access grants associated with this access method.
        /// </summary>
        [DataMember(Name = "access_grant_ids", IsRequired = false, EmitDefaultValue = false)]
        public List<string> AccessGrantIds { get; set; }

        /// <summary>
        /// Keys of the access grants associated with this access method (if present).
        /// </summary>
        [DataMember(Name = "access_grant_keys", IsRequired = false, EmitDefaultValue = false)]
        public List<string>? AccessGrantKeys { get; set; }

        /// <summary>
        /// ID of the affected access method.
        /// </summary>
        [DataMember(Name = "access_method_id", IsRequired = false, EmitDefaultValue = false)]
        public string AccessMethodId { get; set; }

        /// <summary>
        /// Date and time at which the event was created.
        /// </summary>
        [DataMember(Name = "created_at", IsRequired = false, EmitDefaultValue = false)]
        public override string CreatedAt { get; set; }

        /// <summary>
        /// Human-readable description of the event. Persisted when the event is created (so the creating code, including a provider, can supply a tailored description) and otherwise derived from the event.
        /// </summary>
        [DataMember(Name = "event_description", IsRequired = false, EmitDefaultValue = false)]
        public override string? EventDescription { get; set; }

        /// <summary>
        /// ID of the event.
        /// </summary>
        [DataMember(Name = "event_id", IsRequired = false, EmitDefaultValue = false)]
        public override string EventId { get; set; }

        [DataMember(Name = "event_type", IsRequired = true, EmitDefaultValue = false)]
        public override string EventType { get; } = "access_method.revoked";

        /// <summary>
        /// Date and time at which the event occurred.
        /// </summary>
        [DataMember(Name = "occurred_at", IsRequired = false, EmitDefaultValue = false)]
        public override string OccurredAt { get; set; }

        /// <summary>
        /// ID of the workspace associated with the event.
        /// </summary>
        [DataMember(Name = "workspace_id", IsRequired = false, EmitDefaultValue = false)]
        public override string WorkspaceId { get; set; }

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
    /// An access method representing a physical card requires encoding.
    /// </summary>
    [DataContract(Name = "seamModel_eventAccessMethodCardEncodingRequired_model")]
    public class EventAccessMethodCardEncodingRequired : Event
    {
        [JsonConstructorAttribute]
        protected EventAccessMethodCardEncodingRequired() { }

        public EventAccessMethodCardEncodingRequired(
            List<string> accessGrantIds = default,
            List<string>? accessGrantKeys = default,
            string accessMethodId = default,
            string createdAt = default,
            string? eventDescription = default,
            string eventId = default,
            string eventType = default,
            string occurredAt = default,
            string workspaceId = default
        )
        {
            AccessGrantIds = accessGrantIds;
            AccessGrantKeys = accessGrantKeys;
            AccessMethodId = accessMethodId;
            CreatedAt = createdAt;
            EventDescription = eventDescription;
            EventId = eventId;
            EventType = eventType;
            OccurredAt = occurredAt;
            WorkspaceId = workspaceId;
        }

        /// <summary>
        /// IDs of the access grants associated with this access method.
        /// </summary>
        [DataMember(Name = "access_grant_ids", IsRequired = false, EmitDefaultValue = false)]
        public List<string> AccessGrantIds { get; set; }

        /// <summary>
        /// Keys of the access grants associated with this access method (if present).
        /// </summary>
        [DataMember(Name = "access_grant_keys", IsRequired = false, EmitDefaultValue = false)]
        public List<string>? AccessGrantKeys { get; set; }

        /// <summary>
        /// ID of the affected access method.
        /// </summary>
        [DataMember(Name = "access_method_id", IsRequired = false, EmitDefaultValue = false)]
        public string AccessMethodId { get; set; }

        /// <summary>
        /// Date and time at which the event was created.
        /// </summary>
        [DataMember(Name = "created_at", IsRequired = false, EmitDefaultValue = false)]
        public override string CreatedAt { get; set; }

        /// <summary>
        /// Human-readable description of the event. Persisted when the event is created (so the creating code, including a provider, can supply a tailored description) and otherwise derived from the event.
        /// </summary>
        [DataMember(Name = "event_description", IsRequired = false, EmitDefaultValue = false)]
        public override string? EventDescription { get; set; }

        /// <summary>
        /// ID of the event.
        /// </summary>
        [DataMember(Name = "event_id", IsRequired = false, EmitDefaultValue = false)]
        public override string EventId { get; set; }

        [DataMember(Name = "event_type", IsRequired = true, EmitDefaultValue = false)]
        public override string EventType { get; } = "access_method.card_encoding_required";

        /// <summary>
        /// Date and time at which the event occurred.
        /// </summary>
        [DataMember(Name = "occurred_at", IsRequired = false, EmitDefaultValue = false)]
        public override string OccurredAt { get; set; }

        /// <summary>
        /// ID of the workspace associated with the event.
        /// </summary>
        [DataMember(Name = "workspace_id", IsRequired = false, EmitDefaultValue = false)]
        public override string WorkspaceId { get; set; }

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
    /// An access method was deleted.
    /// </summary>
    [DataContract(Name = "seamModel_eventAccessMethodDeleted_model")]
    public class EventAccessMethodDeleted : Event
    {
        [JsonConstructorAttribute]
        protected EventAccessMethodDeleted() { }

        public EventAccessMethodDeleted(
            List<string> accessGrantIds = default,
            List<string>? accessGrantKeys = default,
            string accessMethodId = default,
            string createdAt = default,
            string? eventDescription = default,
            string eventId = default,
            string eventType = default,
            string occurredAt = default,
            string workspaceId = default
        )
        {
            AccessGrantIds = accessGrantIds;
            AccessGrantKeys = accessGrantKeys;
            AccessMethodId = accessMethodId;
            CreatedAt = createdAt;
            EventDescription = eventDescription;
            EventId = eventId;
            EventType = eventType;
            OccurredAt = occurredAt;
            WorkspaceId = workspaceId;
        }

        /// <summary>
        /// IDs of the access grants associated with this access method.
        /// </summary>
        [DataMember(Name = "access_grant_ids", IsRequired = false, EmitDefaultValue = false)]
        public List<string> AccessGrantIds { get; set; }

        /// <summary>
        /// Keys of the access grants associated with this access method (if present).
        /// </summary>
        [DataMember(Name = "access_grant_keys", IsRequired = false, EmitDefaultValue = false)]
        public List<string>? AccessGrantKeys { get; set; }

        /// <summary>
        /// ID of the affected access method.
        /// </summary>
        [DataMember(Name = "access_method_id", IsRequired = false, EmitDefaultValue = false)]
        public string AccessMethodId { get; set; }

        /// <summary>
        /// Date and time at which the event was created.
        /// </summary>
        [DataMember(Name = "created_at", IsRequired = false, EmitDefaultValue = false)]
        public override string CreatedAt { get; set; }

        /// <summary>
        /// Human-readable description of the event. Persisted when the event is created (so the creating code, including a provider, can supply a tailored description) and otherwise derived from the event.
        /// </summary>
        [DataMember(Name = "event_description", IsRequired = false, EmitDefaultValue = false)]
        public override string? EventDescription { get; set; }

        /// <summary>
        /// ID of the event.
        /// </summary>
        [DataMember(Name = "event_id", IsRequired = false, EmitDefaultValue = false)]
        public override string EventId { get; set; }

        [DataMember(Name = "event_type", IsRequired = true, EmitDefaultValue = false)]
        public override string EventType { get; } = "access_method.deleted";

        /// <summary>
        /// Date and time at which the event occurred.
        /// </summary>
        [DataMember(Name = "occurred_at", IsRequired = false, EmitDefaultValue = false)]
        public override string OccurredAt { get; set; }

        /// <summary>
        /// ID of the workspace associated with the event.
        /// </summary>
        [DataMember(Name = "workspace_id", IsRequired = false, EmitDefaultValue = false)]
        public override string WorkspaceId { get; set; }

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
    /// An access method was reissued.
    /// </summary>
    [DataContract(Name = "seamModel_eventAccessMethodReissued_model")]
    public class EventAccessMethodReissued : Event
    {
        [JsonConstructorAttribute]
        protected EventAccessMethodReissued() { }

        public EventAccessMethodReissued(
            List<string> accessGrantIds = default,
            List<string>? accessGrantKeys = default,
            string accessMethodId = default,
            string? code = default,
            string createdAt = default,
            string? eventDescription = default,
            string eventId = default,
            string eventType = default,
            bool? isBackupCode = default,
            string occurredAt = default,
            string workspaceId = default
        )
        {
            AccessGrantIds = accessGrantIds;
            AccessGrantKeys = accessGrantKeys;
            AccessMethodId = accessMethodId;
            Code = code;
            CreatedAt = createdAt;
            EventDescription = eventDescription;
            EventId = eventId;
            EventType = eventType;
            IsBackupCode = isBackupCode;
            OccurredAt = occurredAt;
            WorkspaceId = workspaceId;
        }

        /// <summary>
        /// IDs of the access grants associated with this access method.
        /// </summary>
        [DataMember(Name = "access_grant_ids", IsRequired = false, EmitDefaultValue = false)]
        public List<string> AccessGrantIds { get; set; }

        /// <summary>
        /// Keys of the access grants associated with this access method (if present).
        /// </summary>
        [DataMember(Name = "access_grant_keys", IsRequired = false, EmitDefaultValue = false)]
        public List<string>? AccessGrantKeys { get; set; }

        /// <summary>
        /// ID of the affected access method.
        /// </summary>
        [DataMember(Name = "access_method_id", IsRequired = false, EmitDefaultValue = false)]
        public string AccessMethodId { get; set; }

        /// <summary>
        /// The actual PIN code for code access methods (only present when mode is &apos;code&apos;).
        /// </summary>
        [DataMember(Name = "code", IsRequired = false, EmitDefaultValue = false)]
        public string? Code { get; set; }

        /// <summary>
        /// Date and time at which the event was created.
        /// </summary>
        [DataMember(Name = "created_at", IsRequired = false, EmitDefaultValue = false)]
        public override string CreatedAt { get; set; }

        /// <summary>
        /// Human-readable description of the event. Persisted when the event is created (so the creating code, including a provider, can supply a tailored description) and otherwise derived from the event.
        /// </summary>
        [DataMember(Name = "event_description", IsRequired = false, EmitDefaultValue = false)]
        public override string? EventDescription { get; set; }

        /// <summary>
        /// ID of the event.
        /// </summary>
        [DataMember(Name = "event_id", IsRequired = false, EmitDefaultValue = false)]
        public override string EventId { get; set; }

        [DataMember(Name = "event_type", IsRequired = true, EmitDefaultValue = false)]
        public override string EventType { get; } = "access_method.reissued";

        /// <summary>
        /// Indicates whether the code is a backup code (only present when mode is &apos;code&apos; and a backup code was used).
        /// </summary>
        [DataMember(Name = "is_backup_code", IsRequired = false, EmitDefaultValue = false)]
        public bool? IsBackupCode { get; set; }

        /// <summary>
        /// Date and time at which the event occurred.
        /// </summary>
        [DataMember(Name = "occurred_at", IsRequired = false, EmitDefaultValue = false)]
        public override string OccurredAt { get; set; }

        /// <summary>
        /// ID of the workspace associated with the event.
        /// </summary>
        [DataMember(Name = "workspace_id", IsRequired = false, EmitDefaultValue = false)]
        public override string WorkspaceId { get; set; }

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
    /// An access method was created.
    /// </summary>
    [DataContract(Name = "seamModel_eventAccessMethodCreated_model")]
    public class EventAccessMethodCreated : Event
    {
        [JsonConstructorAttribute]
        protected EventAccessMethodCreated() { }

        public EventAccessMethodCreated(
            List<string> accessGrantIds = default,
            List<string>? accessGrantKeys = default,
            string accessMethodId = default,
            string createdAt = default,
            string? eventDescription = default,
            string eventId = default,
            string eventType = default,
            string occurredAt = default,
            string workspaceId = default
        )
        {
            AccessGrantIds = accessGrantIds;
            AccessGrantKeys = accessGrantKeys;
            AccessMethodId = accessMethodId;
            CreatedAt = createdAt;
            EventDescription = eventDescription;
            EventId = eventId;
            EventType = eventType;
            OccurredAt = occurredAt;
            WorkspaceId = workspaceId;
        }

        /// <summary>
        /// IDs of the access grants associated with this access method.
        /// </summary>
        [DataMember(Name = "access_grant_ids", IsRequired = false, EmitDefaultValue = false)]
        public List<string> AccessGrantIds { get; set; }

        /// <summary>
        /// Keys of the access grants associated with this access method (if present).
        /// </summary>
        [DataMember(Name = "access_grant_keys", IsRequired = false, EmitDefaultValue = false)]
        public List<string>? AccessGrantKeys { get; set; }

        /// <summary>
        /// ID of the affected access method.
        /// </summary>
        [DataMember(Name = "access_method_id", IsRequired = false, EmitDefaultValue = false)]
        public string AccessMethodId { get; set; }

        /// <summary>
        /// Date and time at which the event was created.
        /// </summary>
        [DataMember(Name = "created_at", IsRequired = false, EmitDefaultValue = false)]
        public override string CreatedAt { get; set; }

        /// <summary>
        /// Human-readable description of the event. Persisted when the event is created (so the creating code, including a provider, can supply a tailored description) and otherwise derived from the event.
        /// </summary>
        [DataMember(Name = "event_description", IsRequired = false, EmitDefaultValue = false)]
        public override string? EventDescription { get; set; }

        /// <summary>
        /// ID of the event.
        /// </summary>
        [DataMember(Name = "event_id", IsRequired = false, EmitDefaultValue = false)]
        public override string EventId { get; set; }

        [DataMember(Name = "event_type", IsRequired = true, EmitDefaultValue = false)]
        public override string EventType { get; } = "access_method.created";

        /// <summary>
        /// Date and time at which the event occurred.
        /// </summary>
        [DataMember(Name = "occurred_at", IsRequired = false, EmitDefaultValue = false)]
        public override string OccurredAt { get; set; }

        /// <summary>
        /// ID of the workspace associated with the event.
        /// </summary>
        [DataMember(Name = "workspace_id", IsRequired = false, EmitDefaultValue = false)]
        public override string WorkspaceId { get; set; }

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
    /// Seam has not yet issued this access method, even though its access grant is about to begin, so access may not be ready when the recipient arrives. Seam is still attempting to issue it, and the accompanying `delay_in_issuing` warning clears automatically once issuance succeeds.
    /// </summary>
    [DataContract(Name = "seamModel_eventAccessMethodDelayInIssuing_model")]
    public class EventAccessMethodDelayInIssuing : Event
    {
        [JsonConstructorAttribute]
        protected EventAccessMethodDelayInIssuing() { }

        public EventAccessMethodDelayInIssuing(
            List<string> accessGrantIds = default,
            List<string>? accessGrantKeys = default,
            string accessMethodId = default,
            string createdAt = default,
            string? eventDescription = default,
            string eventId = default,
            string eventType = default,
            string occurredAt = default,
            string workspaceId = default
        )
        {
            AccessGrantIds = accessGrantIds;
            AccessGrantKeys = accessGrantKeys;
            AccessMethodId = accessMethodId;
            CreatedAt = createdAt;
            EventDescription = eventDescription;
            EventId = eventId;
            EventType = eventType;
            OccurredAt = occurredAt;
            WorkspaceId = workspaceId;
        }

        /// <summary>
        /// IDs of the access grants associated with this access method.
        /// </summary>
        [DataMember(Name = "access_grant_ids", IsRequired = false, EmitDefaultValue = false)]
        public List<string> AccessGrantIds { get; set; }

        /// <summary>
        /// Keys of the access grants associated with this access method (if present).
        /// </summary>
        [DataMember(Name = "access_grant_keys", IsRequired = false, EmitDefaultValue = false)]
        public List<string>? AccessGrantKeys { get; set; }

        /// <summary>
        /// ID of the affected access method.
        /// </summary>
        [DataMember(Name = "access_method_id", IsRequired = false, EmitDefaultValue = false)]
        public string AccessMethodId { get; set; }

        /// <summary>
        /// Date and time at which the event was created.
        /// </summary>
        [DataMember(Name = "created_at", IsRequired = false, EmitDefaultValue = false)]
        public override string CreatedAt { get; set; }

        /// <summary>
        /// Human-readable description of the event. Persisted when the event is created (so the creating code, including a provider, can supply a tailored description) and otherwise derived from the event.
        /// </summary>
        [DataMember(Name = "event_description", IsRequired = false, EmitDefaultValue = false)]
        public override string? EventDescription { get; set; }

        /// <summary>
        /// ID of the event.
        /// </summary>
        [DataMember(Name = "event_id", IsRequired = false, EmitDefaultValue = false)]
        public override string EventId { get; set; }

        [DataMember(Name = "event_type", IsRequired = true, EmitDefaultValue = false)]
        public override string EventType { get; } = "access_method.delay_in_issuing";

        /// <summary>
        /// Date and time at which the event occurred.
        /// </summary>
        [DataMember(Name = "occurred_at", IsRequired = false, EmitDefaultValue = false)]
        public override string OccurredAt { get; set; }

        /// <summary>
        /// ID of the workspace associated with the event.
        /// </summary>
        [DataMember(Name = "workspace_id", IsRequired = false, EmitDefaultValue = false)]
        public override string WorkspaceId { get; set; }

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
    /// Seam was unable to issue this access method before its access grant started, so the recipient may be unable to access the space. This usually points to a problem that needs attention, such as an offline or disconnected device. Seam keeps retrying, and the accompanying `failed_to_issue` error clears automatically if the access method is eventually issued.
    /// </summary>
    [DataContract(Name = "seamModel_eventAccessMethodFailedToIssue_model")]
    public class EventAccessMethodFailedToIssue : Event
    {
        [JsonConstructorAttribute]
        protected EventAccessMethodFailedToIssue() { }

        public EventAccessMethodFailedToIssue(
            List<string> accessGrantIds = default,
            List<string>? accessGrantKeys = default,
            string accessMethodId = default,
            string createdAt = default,
            string? eventDescription = default,
            string eventId = default,
            string eventType = default,
            string occurredAt = default,
            string workspaceId = default
        )
        {
            AccessGrantIds = accessGrantIds;
            AccessGrantKeys = accessGrantKeys;
            AccessMethodId = accessMethodId;
            CreatedAt = createdAt;
            EventDescription = eventDescription;
            EventId = eventId;
            EventType = eventType;
            OccurredAt = occurredAt;
            WorkspaceId = workspaceId;
        }

        /// <summary>
        /// IDs of the access grants associated with this access method.
        /// </summary>
        [DataMember(Name = "access_grant_ids", IsRequired = false, EmitDefaultValue = false)]
        public List<string> AccessGrantIds { get; set; }

        /// <summary>
        /// Keys of the access grants associated with this access method (if present).
        /// </summary>
        [DataMember(Name = "access_grant_keys", IsRequired = false, EmitDefaultValue = false)]
        public List<string>? AccessGrantKeys { get; set; }

        /// <summary>
        /// ID of the affected access method.
        /// </summary>
        [DataMember(Name = "access_method_id", IsRequired = false, EmitDefaultValue = false)]
        public string AccessMethodId { get; set; }

        /// <summary>
        /// Date and time at which the event was created.
        /// </summary>
        [DataMember(Name = "created_at", IsRequired = false, EmitDefaultValue = false)]
        public override string CreatedAt { get; set; }

        /// <summary>
        /// Human-readable description of the event. Persisted when the event is created (so the creating code, including a provider, can supply a tailored description) and otherwise derived from the event.
        /// </summary>
        [DataMember(Name = "event_description", IsRequired = false, EmitDefaultValue = false)]
        public override string? EventDescription { get; set; }

        /// <summary>
        /// ID of the event.
        /// </summary>
        [DataMember(Name = "event_id", IsRequired = false, EmitDefaultValue = false)]
        public override string EventId { get; set; }

        [DataMember(Name = "event_type", IsRequired = true, EmitDefaultValue = false)]
        public override string EventType { get; } = "access_method.failed_to_issue";

        /// <summary>
        /// Date and time at which the event occurred.
        /// </summary>
        [DataMember(Name = "occurred_at", IsRequired = false, EmitDefaultValue = false)]
        public override string OccurredAt { get; set; }

        /// <summary>
        /// ID of the workspace associated with the event.
        /// </summary>
        [DataMember(Name = "workspace_id", IsRequired = false, EmitDefaultValue = false)]
        public override string WorkspaceId { get; set; }

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
    /// An [access system](https://docs.seam.co/low-level-apis/access-systems) was connected.
    /// </summary>
    [DataContract(Name = "seamModel_eventAcsSystemConnected_model")]
    public class EventAcsSystemConnected : Event
    {
        [JsonConstructorAttribute]
        protected EventAcsSystemConnected() { }

        public EventAcsSystemConnected(
            string acsSystemId = default,
            string? connectedAccountId = default,
            string createdAt = default,
            string? eventDescription = default,
            string eventId = default,
            string eventType = default,
            string occurredAt = default,
            string workspaceId = default
        )
        {
            AcsSystemId = acsSystemId;
            ConnectedAccountId = connectedAccountId;
            CreatedAt = createdAt;
            EventDescription = eventDescription;
            EventId = eventId;
            EventType = eventType;
            OccurredAt = occurredAt;
            WorkspaceId = workspaceId;
        }

        /// <summary>
        /// ID of the access system.
        /// </summary>
        [DataMember(Name = "acs_system_id", IsRequired = false, EmitDefaultValue = false)]
        public string AcsSystemId { get; set; }

        /// <summary>
        /// ID of the connected account.
        /// </summary>
        [DataMember(Name = "connected_account_id", IsRequired = false, EmitDefaultValue = false)]
        public string? ConnectedAccountId { get; set; }

        /// <summary>
        /// Date and time at which the event was created.
        /// </summary>
        [DataMember(Name = "created_at", IsRequired = false, EmitDefaultValue = false)]
        public override string CreatedAt { get; set; }

        /// <summary>
        /// Human-readable description of the event. Persisted when the event is created (so the creating code, including a provider, can supply a tailored description) and otherwise derived from the event.
        /// </summary>
        [DataMember(Name = "event_description", IsRequired = false, EmitDefaultValue = false)]
        public override string? EventDescription { get; set; }

        /// <summary>
        /// ID of the event.
        /// </summary>
        [DataMember(Name = "event_id", IsRequired = false, EmitDefaultValue = false)]
        public override string EventId { get; set; }

        [DataMember(Name = "event_type", IsRequired = true, EmitDefaultValue = false)]
        public override string EventType { get; } = "acs_system.connected";

        /// <summary>
        /// Date and time at which the event occurred.
        /// </summary>
        [DataMember(Name = "occurred_at", IsRequired = false, EmitDefaultValue = false)]
        public override string OccurredAt { get; set; }

        /// <summary>
        /// ID of the workspace associated with the event.
        /// </summary>
        [DataMember(Name = "workspace_id", IsRequired = false, EmitDefaultValue = false)]
        public override string WorkspaceId { get; set; }

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
    /// An [access system](https://docs.seam.co/low-level-apis/access-systems) was added.
    /// </summary>
    [DataContract(Name = "seamModel_eventAcsSystemAdded_model")]
    public class EventAcsSystemAdded : Event
    {
        [JsonConstructorAttribute]
        protected EventAcsSystemAdded() { }

        public EventAcsSystemAdded(
            string acsSystemId = default,
            string? connectedAccountId = default,
            string createdAt = default,
            string? eventDescription = default,
            string eventId = default,
            string eventType = default,
            string occurredAt = default,
            string workspaceId = default
        )
        {
            AcsSystemId = acsSystemId;
            ConnectedAccountId = connectedAccountId;
            CreatedAt = createdAt;
            EventDescription = eventDescription;
            EventId = eventId;
            EventType = eventType;
            OccurredAt = occurredAt;
            WorkspaceId = workspaceId;
        }

        /// <summary>
        /// ID of the access system.
        /// </summary>
        [DataMember(Name = "acs_system_id", IsRequired = false, EmitDefaultValue = false)]
        public string AcsSystemId { get; set; }

        /// <summary>
        /// ID of the connected account.
        /// </summary>
        [DataMember(Name = "connected_account_id", IsRequired = false, EmitDefaultValue = false)]
        public string? ConnectedAccountId { get; set; }

        /// <summary>
        /// Date and time at which the event was created.
        /// </summary>
        [DataMember(Name = "created_at", IsRequired = false, EmitDefaultValue = false)]
        public override string CreatedAt { get; set; }

        /// <summary>
        /// Human-readable description of the event. Persisted when the event is created (so the creating code, including a provider, can supply a tailored description) and otherwise derived from the event.
        /// </summary>
        [DataMember(Name = "event_description", IsRequired = false, EmitDefaultValue = false)]
        public override string? EventDescription { get; set; }

        /// <summary>
        /// ID of the event.
        /// </summary>
        [DataMember(Name = "event_id", IsRequired = false, EmitDefaultValue = false)]
        public override string EventId { get; set; }

        [DataMember(Name = "event_type", IsRequired = true, EmitDefaultValue = false)]
        public override string EventType { get; } = "acs_system.added";

        /// <summary>
        /// Date and time at which the event occurred.
        /// </summary>
        [DataMember(Name = "occurred_at", IsRequired = false, EmitDefaultValue = false)]
        public override string OccurredAt { get; set; }

        /// <summary>
        /// ID of the workspace associated with the event.
        /// </summary>
        [DataMember(Name = "workspace_id", IsRequired = false, EmitDefaultValue = false)]
        public override string WorkspaceId { get; set; }

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
    /// An [access system](https://docs.seam.co/low-level-apis/access-systems) was disconnected.
    /// </summary>
    [DataContract(Name = "seamModel_eventAcsSystemDisconnected_model")]
    public class EventAcsSystemDisconnected : Event
    {
        [JsonConstructorAttribute]
        protected EventAcsSystemDisconnected() { }

        public EventAcsSystemDisconnected(
            List<EventAcsSystemDisconnectedAcsSystemErrors> acsSystemErrors = default,
            string acsSystemId = default,
            List<EventAcsSystemDisconnectedAcsSystemWarnings> acsSystemWarnings = default,
            List<EventAcsSystemDisconnectedConnectedAccountErrors> connectedAccountErrors = default,
            string? connectedAccountId = default,
            List<EventAcsSystemDisconnectedConnectedAccountWarnings> connectedAccountWarnings =
                default,
            string createdAt = default,
            string? eventDescription = default,
            string eventId = default,
            string eventType = default,
            string occurredAt = default,
            string workspaceId = default
        )
        {
            AcsSystemErrors = acsSystemErrors;
            AcsSystemId = acsSystemId;
            AcsSystemWarnings = acsSystemWarnings;
            ConnectedAccountErrors = connectedAccountErrors;
            ConnectedAccountId = connectedAccountId;
            ConnectedAccountWarnings = connectedAccountWarnings;
            CreatedAt = createdAt;
            EventDescription = eventDescription;
            EventId = eventId;
            EventType = eventType;
            OccurredAt = occurredAt;
            WorkspaceId = workspaceId;
        }

        /// <summary>
        /// Errors associated with the access control system.
        /// </summary>
        [DataMember(Name = "acs_system_errors", IsRequired = false, EmitDefaultValue = false)]
        public List<EventAcsSystemDisconnectedAcsSystemErrors> AcsSystemErrors { get; set; }

        /// <summary>
        /// ID of the access system.
        /// </summary>
        [DataMember(Name = "acs_system_id", IsRequired = false, EmitDefaultValue = false)]
        public string AcsSystemId { get; set; }

        /// <summary>
        /// Warnings associated with the access control system.
        /// </summary>
        [DataMember(Name = "acs_system_warnings", IsRequired = false, EmitDefaultValue = false)]
        public List<EventAcsSystemDisconnectedAcsSystemWarnings> AcsSystemWarnings { get; set; }

        /// <summary>
        /// Errors associated with the connected account.
        /// </summary>
        [DataMember(
            Name = "connected_account_errors",
            IsRequired = false,
            EmitDefaultValue = false
        )]
        public List<EventAcsSystemDisconnectedConnectedAccountErrors> ConnectedAccountErrors { get; set; }

        /// <summary>
        /// ID of the connected account.
        /// </summary>
        [DataMember(Name = "connected_account_id", IsRequired = false, EmitDefaultValue = false)]
        public string? ConnectedAccountId { get; set; }

        /// <summary>
        /// Warnings associated with the connected account.
        /// </summary>
        [DataMember(
            Name = "connected_account_warnings",
            IsRequired = false,
            EmitDefaultValue = false
        )]
        public List<EventAcsSystemDisconnectedConnectedAccountWarnings> ConnectedAccountWarnings { get; set; }

        /// <summary>
        /// Date and time at which the event was created.
        /// </summary>
        [DataMember(Name = "created_at", IsRequired = false, EmitDefaultValue = false)]
        public override string CreatedAt { get; set; }

        /// <summary>
        /// Human-readable description of the event. Persisted when the event is created (so the creating code, including a provider, can supply a tailored description) and otherwise derived from the event.
        /// </summary>
        [DataMember(Name = "event_description", IsRequired = false, EmitDefaultValue = false)]
        public override string? EventDescription { get; set; }

        /// <summary>
        /// ID of the event.
        /// </summary>
        [DataMember(Name = "event_id", IsRequired = false, EmitDefaultValue = false)]
        public override string EventId { get; set; }

        [DataMember(Name = "event_type", IsRequired = true, EmitDefaultValue = false)]
        public override string EventType { get; } = "acs_system.disconnected";

        /// <summary>
        /// Date and time at which the event occurred.
        /// </summary>
        [DataMember(Name = "occurred_at", IsRequired = false, EmitDefaultValue = false)]
        public override string OccurredAt { get; set; }

        /// <summary>
        /// ID of the workspace associated with the event.
        /// </summary>
        [DataMember(Name = "workspace_id", IsRequired = false, EmitDefaultValue = false)]
        public override string WorkspaceId { get; set; }

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

    [DataContract(Name = "seamModel_eventAcsSystemDisconnectedAcsSystemErrors_model")]
    public class EventAcsSystemDisconnectedAcsSystemErrors
    {
        [JsonConstructorAttribute]
        protected EventAcsSystemDisconnectedAcsSystemErrors() { }

        public EventAcsSystemDisconnectedAcsSystemErrors(
            string createdAt = default,
            string errorCode = default,
            string message = default
        )
        {
            CreatedAt = createdAt;
            ErrorCode = errorCode;
            Message = message;
        }

        /// <summary>
        /// Date and time at which Seam created the error.
        /// </summary>
        [DataMember(Name = "created_at", IsRequired = false, EmitDefaultValue = false)]
        public string CreatedAt { get; set; }

        /// <summary>
        /// Unique identifier of the type of error. Enables quick recognition and categorization of the issue.
        /// </summary>
        [DataMember(Name = "error_code", IsRequired = false, EmitDefaultValue = false)]
        public string ErrorCode { get; set; }

        /// <summary>
        /// Detailed description of the error. Provides insights into the issue and potentially how to rectify it.
        /// </summary>
        [DataMember(Name = "message", IsRequired = false, EmitDefaultValue = false)]
        public string Message { get; set; }

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

    [DataContract(Name = "seamModel_eventAcsSystemDisconnectedAcsSystemWarnings_model")]
    public class EventAcsSystemDisconnectedAcsSystemWarnings
    {
        [JsonConstructorAttribute]
        protected EventAcsSystemDisconnectedAcsSystemWarnings() { }

        public EventAcsSystemDisconnectedAcsSystemWarnings(
            string createdAt = default,
            string message = default,
            string warningCode = default
        )
        {
            CreatedAt = createdAt;
            Message = message;
            WarningCode = warningCode;
        }

        /// <summary>
        /// Date and time at which Seam created the warning.
        /// </summary>
        [DataMember(Name = "created_at", IsRequired = false, EmitDefaultValue = false)]
        public string CreatedAt { get; set; }

        /// <summary>
        /// Detailed description of the warning. Provides insights into the issue and potentially how to rectify it.
        /// </summary>
        [DataMember(Name = "message", IsRequired = false, EmitDefaultValue = false)]
        public string Message { get; set; }

        /// <summary>
        /// Unique identifier of the type of warning. Enables quick recognition and categorization of the issue.
        /// </summary>
        [DataMember(Name = "warning_code", IsRequired = false, EmitDefaultValue = false)]
        public string WarningCode { get; set; }

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

    [DataContract(Name = "seamModel_eventAcsSystemDisconnectedConnectedAccountErrors_model")]
    public class EventAcsSystemDisconnectedConnectedAccountErrors
    {
        [JsonConstructorAttribute]
        protected EventAcsSystemDisconnectedConnectedAccountErrors() { }

        public EventAcsSystemDisconnectedConnectedAccountErrors(
            string createdAt = default,
            string errorCode = default,
            string message = default
        )
        {
            CreatedAt = createdAt;
            ErrorCode = errorCode;
            Message = message;
        }

        /// <summary>
        /// Date and time at which Seam created the error.
        /// </summary>
        [DataMember(Name = "created_at", IsRequired = false, EmitDefaultValue = false)]
        public string CreatedAt { get; set; }

        /// <summary>
        /// Unique identifier of the type of error. Enables quick recognition and categorization of the issue.
        /// </summary>
        [DataMember(Name = "error_code", IsRequired = false, EmitDefaultValue = false)]
        public string ErrorCode { get; set; }

        /// <summary>
        /// Detailed description of the error. Provides insights into the issue and potentially how to rectify it.
        /// </summary>
        [DataMember(Name = "message", IsRequired = false, EmitDefaultValue = false)]
        public string Message { get; set; }

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

    [DataContract(Name = "seamModel_eventAcsSystemDisconnectedConnectedAccountWarnings_model")]
    public class EventAcsSystemDisconnectedConnectedAccountWarnings
    {
        [JsonConstructorAttribute]
        protected EventAcsSystemDisconnectedConnectedAccountWarnings() { }

        public EventAcsSystemDisconnectedConnectedAccountWarnings(
            string createdAt = default,
            string message = default,
            string warningCode = default
        )
        {
            CreatedAt = createdAt;
            Message = message;
            WarningCode = warningCode;
        }

        /// <summary>
        /// Date and time at which Seam created the warning.
        /// </summary>
        [DataMember(Name = "created_at", IsRequired = false, EmitDefaultValue = false)]
        public string CreatedAt { get; set; }

        /// <summary>
        /// Detailed description of the warning. Provides insights into the issue and potentially how to rectify it.
        /// </summary>
        [DataMember(Name = "message", IsRequired = false, EmitDefaultValue = false)]
        public string Message { get; set; }

        /// <summary>
        /// Unique identifier of the type of warning. Enables quick recognition and categorization of the issue.
        /// </summary>
        [DataMember(Name = "warning_code", IsRequired = false, EmitDefaultValue = false)]
        public string WarningCode { get; set; }

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
    /// An [access system credential](https://docs.seam.co/low-level-apis/access-systems/managing-credentials) was deleted.
    /// </summary>
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
            string? eventDescription = default,
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
            EventDescription = eventDescription;
            EventId = eventId;
            EventType = eventType;
            OccurredAt = occurredAt;
            WorkspaceId = workspaceId;
        }

        /// <summary>
        /// ID of the affected credential.
        /// </summary>
        [DataMember(Name = "acs_credential_id", IsRequired = false, EmitDefaultValue = false)]
        public string AcsCredentialId { get; set; }

        /// <summary>
        /// ID of the access system.
        /// </summary>
        [DataMember(Name = "acs_system_id", IsRequired = false, EmitDefaultValue = false)]
        public string AcsSystemId { get; set; }

        /// <summary>
        /// ID of the connected account.
        /// </summary>
        [DataMember(Name = "connected_account_id", IsRequired = false, EmitDefaultValue = false)]
        public string? ConnectedAccountId { get; set; }

        /// <summary>
        /// Date and time at which the event was created.
        /// </summary>
        [DataMember(Name = "created_at", IsRequired = false, EmitDefaultValue = false)]
        public override string CreatedAt { get; set; }

        /// <summary>
        /// Human-readable description of the event. Persisted when the event is created (so the creating code, including a provider, can supply a tailored description) and otherwise derived from the event.
        /// </summary>
        [DataMember(Name = "event_description", IsRequired = false, EmitDefaultValue = false)]
        public override string? EventDescription { get; set; }

        /// <summary>
        /// ID of the event.
        /// </summary>
        [DataMember(Name = "event_id", IsRequired = false, EmitDefaultValue = false)]
        public override string EventId { get; set; }

        [DataMember(Name = "event_type", IsRequired = true, EmitDefaultValue = false)]
        public override string EventType { get; } = "acs_credential.deleted";

        /// <summary>
        /// Date and time at which the event occurred.
        /// </summary>
        [DataMember(Name = "occurred_at", IsRequired = false, EmitDefaultValue = false)]
        public override string OccurredAt { get; set; }

        /// <summary>
        /// ID of the workspace associated with the event.
        /// </summary>
        [DataMember(Name = "workspace_id", IsRequired = false, EmitDefaultValue = false)]
        public override string WorkspaceId { get; set; }

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
    /// An [access system credential](https://docs.seam.co/low-level-apis/access-systems/managing-credentials) was issued.
    /// </summary>
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
            string? eventDescription = default,
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
            EventDescription = eventDescription;
            EventId = eventId;
            EventType = eventType;
            OccurredAt = occurredAt;
            WorkspaceId = workspaceId;
        }

        /// <summary>
        /// ID of the affected credential.
        /// </summary>
        [DataMember(Name = "acs_credential_id", IsRequired = false, EmitDefaultValue = false)]
        public string AcsCredentialId { get; set; }

        /// <summary>
        /// ID of the access system.
        /// </summary>
        [DataMember(Name = "acs_system_id", IsRequired = false, EmitDefaultValue = false)]
        public string AcsSystemId { get; set; }

        /// <summary>
        /// ID of the connected account.
        /// </summary>
        [DataMember(Name = "connected_account_id", IsRequired = false, EmitDefaultValue = false)]
        public string? ConnectedAccountId { get; set; }

        /// <summary>
        /// Date and time at which the event was created.
        /// </summary>
        [DataMember(Name = "created_at", IsRequired = false, EmitDefaultValue = false)]
        public override string CreatedAt { get; set; }

        /// <summary>
        /// Human-readable description of the event. Persisted when the event is created (so the creating code, including a provider, can supply a tailored description) and otherwise derived from the event.
        /// </summary>
        [DataMember(Name = "event_description", IsRequired = false, EmitDefaultValue = false)]
        public override string? EventDescription { get; set; }

        /// <summary>
        /// ID of the event.
        /// </summary>
        [DataMember(Name = "event_id", IsRequired = false, EmitDefaultValue = false)]
        public override string EventId { get; set; }

        [DataMember(Name = "event_type", IsRequired = true, EmitDefaultValue = false)]
        public override string EventType { get; } = "acs_credential.issued";

        /// <summary>
        /// Date and time at which the event occurred.
        /// </summary>
        [DataMember(Name = "occurred_at", IsRequired = false, EmitDefaultValue = false)]
        public override string OccurredAt { get; set; }

        /// <summary>
        /// ID of the workspace associated with the event.
        /// </summary>
        [DataMember(Name = "workspace_id", IsRequired = false, EmitDefaultValue = false)]
        public override string WorkspaceId { get; set; }

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
    /// An [access system credential](https://docs.seam.co/low-level-apis/access-systems/managing-credentials) was reissued.
    /// </summary>
    [DataContract(Name = "seamModel_eventAcsCredentialReissued_model")]
    public class EventAcsCredentialReissued : Event
    {
        [JsonConstructorAttribute]
        protected EventAcsCredentialReissued() { }

        public EventAcsCredentialReissued(
            string acsCredentialId = default,
            string acsSystemId = default,
            string? connectedAccountId = default,
            string createdAt = default,
            string? eventDescription = default,
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
            EventDescription = eventDescription;
            EventId = eventId;
            EventType = eventType;
            OccurredAt = occurredAt;
            WorkspaceId = workspaceId;
        }

        /// <summary>
        /// ID of the affected credential.
        /// </summary>
        [DataMember(Name = "acs_credential_id", IsRequired = false, EmitDefaultValue = false)]
        public string AcsCredentialId { get; set; }

        /// <summary>
        /// ID of the access system.
        /// </summary>
        [DataMember(Name = "acs_system_id", IsRequired = false, EmitDefaultValue = false)]
        public string AcsSystemId { get; set; }

        /// <summary>
        /// ID of the connected account.
        /// </summary>
        [DataMember(Name = "connected_account_id", IsRequired = false, EmitDefaultValue = false)]
        public string? ConnectedAccountId { get; set; }

        /// <summary>
        /// Date and time at which the event was created.
        /// </summary>
        [DataMember(Name = "created_at", IsRequired = false, EmitDefaultValue = false)]
        public override string CreatedAt { get; set; }

        /// <summary>
        /// Human-readable description of the event. Persisted when the event is created (so the creating code, including a provider, can supply a tailored description) and otherwise derived from the event.
        /// </summary>
        [DataMember(Name = "event_description", IsRequired = false, EmitDefaultValue = false)]
        public override string? EventDescription { get; set; }

        /// <summary>
        /// ID of the event.
        /// </summary>
        [DataMember(Name = "event_id", IsRequired = false, EmitDefaultValue = false)]
        public override string EventId { get; set; }

        [DataMember(Name = "event_type", IsRequired = true, EmitDefaultValue = false)]
        public override string EventType { get; } = "acs_credential.reissued";

        /// <summary>
        /// Date and time at which the event occurred.
        /// </summary>
        [DataMember(Name = "occurred_at", IsRequired = false, EmitDefaultValue = false)]
        public override string OccurredAt { get; set; }

        /// <summary>
        /// ID of the workspace associated with the event.
        /// </summary>
        [DataMember(Name = "workspace_id", IsRequired = false, EmitDefaultValue = false)]
        public override string WorkspaceId { get; set; }

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
    /// An [access system credential](https://docs.seam.co/low-level-apis/access-systems/managing-credentials) was invalidated. That is, the credential cannot be used anymore.
    /// </summary>
    [DataContract(Name = "seamModel_eventAcsCredentialInvalidated_model")]
    public class EventAcsCredentialInvalidated : Event
    {
        [JsonConstructorAttribute]
        protected EventAcsCredentialInvalidated() { }

        public EventAcsCredentialInvalidated(
            string acsCredentialId = default,
            string acsSystemId = default,
            string? connectedAccountId = default,
            string createdAt = default,
            string? eventDescription = default,
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
            EventDescription = eventDescription;
            EventId = eventId;
            EventType = eventType;
            OccurredAt = occurredAt;
            WorkspaceId = workspaceId;
        }

        /// <summary>
        /// ID of the affected credential.
        /// </summary>
        [DataMember(Name = "acs_credential_id", IsRequired = false, EmitDefaultValue = false)]
        public string AcsCredentialId { get; set; }

        /// <summary>
        /// ID of the access system.
        /// </summary>
        [DataMember(Name = "acs_system_id", IsRequired = false, EmitDefaultValue = false)]
        public string AcsSystemId { get; set; }

        /// <summary>
        /// ID of the connected account.
        /// </summary>
        [DataMember(Name = "connected_account_id", IsRequired = false, EmitDefaultValue = false)]
        public string? ConnectedAccountId { get; set; }

        /// <summary>
        /// Date and time at which the event was created.
        /// </summary>
        [DataMember(Name = "created_at", IsRequired = false, EmitDefaultValue = false)]
        public override string CreatedAt { get; set; }

        /// <summary>
        /// Human-readable description of the event. Persisted when the event is created (so the creating code, including a provider, can supply a tailored description) and otherwise derived from the event.
        /// </summary>
        [DataMember(Name = "event_description", IsRequired = false, EmitDefaultValue = false)]
        public override string? EventDescription { get; set; }

        /// <summary>
        /// ID of the event.
        /// </summary>
        [DataMember(Name = "event_id", IsRequired = false, EmitDefaultValue = false)]
        public override string EventId { get; set; }

        [DataMember(Name = "event_type", IsRequired = true, EmitDefaultValue = false)]
        public override string EventType { get; } = "acs_credential.invalidated";

        /// <summary>
        /// Date and time at which the event occurred.
        /// </summary>
        [DataMember(Name = "occurred_at", IsRequired = false, EmitDefaultValue = false)]
        public override string OccurredAt { get; set; }

        /// <summary>
        /// ID of the workspace associated with the event.
        /// </summary>
        [DataMember(Name = "workspace_id", IsRequired = false, EmitDefaultValue = false)]
        public override string WorkspaceId { get; set; }

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
    /// An [access system user](https://docs.seam.co/low-level-apis/access-systems/user-management) was created.
    /// </summary>
    [DataContract(Name = "seamModel_eventAcsUserCreated_model")]
    public class EventAcsUserCreated : Event
    {
        [JsonConstructorAttribute]
        protected EventAcsUserCreated() { }

        public EventAcsUserCreated(
            string acsSystemId = default,
            string acsUserId = default,
            string? connectedAccountId = default,
            string createdAt = default,
            string? eventDescription = default,
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
            EventDescription = eventDescription;
            EventId = eventId;
            EventType = eventType;
            OccurredAt = occurredAt;
            WorkspaceId = workspaceId;
        }

        /// <summary>
        /// ID of the access system.
        /// </summary>
        [DataMember(Name = "acs_system_id", IsRequired = false, EmitDefaultValue = false)]
        public string AcsSystemId { get; set; }

        /// <summary>
        /// ID of the affected access system user.
        /// </summary>
        [DataMember(Name = "acs_user_id", IsRequired = false, EmitDefaultValue = false)]
        public string AcsUserId { get; set; }

        /// <summary>
        /// ID of the connected account.
        /// </summary>
        [DataMember(Name = "connected_account_id", IsRequired = false, EmitDefaultValue = false)]
        public string? ConnectedAccountId { get; set; }

        /// <summary>
        /// Date and time at which the event was created.
        /// </summary>
        [DataMember(Name = "created_at", IsRequired = false, EmitDefaultValue = false)]
        public override string CreatedAt { get; set; }

        /// <summary>
        /// Human-readable description of the event. Persisted when the event is created (so the creating code, including a provider, can supply a tailored description) and otherwise derived from the event.
        /// </summary>
        [DataMember(Name = "event_description", IsRequired = false, EmitDefaultValue = false)]
        public override string? EventDescription { get; set; }

        /// <summary>
        /// ID of the event.
        /// </summary>
        [DataMember(Name = "event_id", IsRequired = false, EmitDefaultValue = false)]
        public override string EventId { get; set; }

        [DataMember(Name = "event_type", IsRequired = true, EmitDefaultValue = false)]
        public override string EventType { get; } = "acs_user.created";

        /// <summary>
        /// Date and time at which the event occurred.
        /// </summary>
        [DataMember(Name = "occurred_at", IsRequired = false, EmitDefaultValue = false)]
        public override string OccurredAt { get; set; }

        /// <summary>
        /// ID of the workspace associated with the event.
        /// </summary>
        [DataMember(Name = "workspace_id", IsRequired = false, EmitDefaultValue = false)]
        public override string WorkspaceId { get; set; }

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
    /// An [access system user](https://docs.seam.co/low-level-apis/access-systems/user-management) was deleted.
    /// </summary>
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
            string? eventDescription = default,
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
            EventDescription = eventDescription;
            EventId = eventId;
            EventType = eventType;
            OccurredAt = occurredAt;
            WorkspaceId = workspaceId;
        }

        /// <summary>
        /// ID of the access system.
        /// </summary>
        [DataMember(Name = "acs_system_id", IsRequired = false, EmitDefaultValue = false)]
        public string AcsSystemId { get; set; }

        /// <summary>
        /// ID of the affected access system user.
        /// </summary>
        [DataMember(Name = "acs_user_id", IsRequired = false, EmitDefaultValue = false)]
        public string AcsUserId { get; set; }

        /// <summary>
        /// ID of the connected account.
        /// </summary>
        [DataMember(Name = "connected_account_id", IsRequired = false, EmitDefaultValue = false)]
        public string? ConnectedAccountId { get; set; }

        /// <summary>
        /// Date and time at which the event was created.
        /// </summary>
        [DataMember(Name = "created_at", IsRequired = false, EmitDefaultValue = false)]
        public override string CreatedAt { get; set; }

        /// <summary>
        /// Human-readable description of the event. Persisted when the event is created (so the creating code, including a provider, can supply a tailored description) and otherwise derived from the event.
        /// </summary>
        [DataMember(Name = "event_description", IsRequired = false, EmitDefaultValue = false)]
        public override string? EventDescription { get; set; }

        /// <summary>
        /// ID of the event.
        /// </summary>
        [DataMember(Name = "event_id", IsRequired = false, EmitDefaultValue = false)]
        public override string EventId { get; set; }

        [DataMember(Name = "event_type", IsRequired = true, EmitDefaultValue = false)]
        public override string EventType { get; } = "acs_user.deleted";

        /// <summary>
        /// Date and time at which the event occurred.
        /// </summary>
        [DataMember(Name = "occurred_at", IsRequired = false, EmitDefaultValue = false)]
        public override string OccurredAt { get; set; }

        /// <summary>
        /// ID of the workspace associated with the event.
        /// </summary>
        [DataMember(Name = "workspace_id", IsRequired = false, EmitDefaultValue = false)]
        public override string WorkspaceId { get; set; }

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
    /// An [access system encoder](https://docs.seam.co/low-level-apis/access-systems/working-with-card-encoders-and-scanners) was added.
    /// </summary>
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
            string? eventDescription = default,
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
            EventDescription = eventDescription;
            EventId = eventId;
            EventType = eventType;
            OccurredAt = occurredAt;
            WorkspaceId = workspaceId;
        }

        /// <summary>
        /// ID of the affected encoder.
        /// </summary>
        [DataMember(Name = "acs_encoder_id", IsRequired = false, EmitDefaultValue = false)]
        public string AcsEncoderId { get; set; }

        /// <summary>
        /// ID of the access system.
        /// </summary>
        [DataMember(Name = "acs_system_id", IsRequired = false, EmitDefaultValue = false)]
        public string AcsSystemId { get; set; }

        /// <summary>
        /// ID of the connected account.
        /// </summary>
        [DataMember(Name = "connected_account_id", IsRequired = false, EmitDefaultValue = false)]
        public string? ConnectedAccountId { get; set; }

        /// <summary>
        /// Date and time at which the event was created.
        /// </summary>
        [DataMember(Name = "created_at", IsRequired = false, EmitDefaultValue = false)]
        public override string CreatedAt { get; set; }

        /// <summary>
        /// Human-readable description of the event. Persisted when the event is created (so the creating code, including a provider, can supply a tailored description) and otherwise derived from the event.
        /// </summary>
        [DataMember(Name = "event_description", IsRequired = false, EmitDefaultValue = false)]
        public override string? EventDescription { get; set; }

        /// <summary>
        /// ID of the event.
        /// </summary>
        [DataMember(Name = "event_id", IsRequired = false, EmitDefaultValue = false)]
        public override string EventId { get; set; }

        [DataMember(Name = "event_type", IsRequired = true, EmitDefaultValue = false)]
        public override string EventType { get; } = "acs_encoder.added";

        /// <summary>
        /// Date and time at which the event occurred.
        /// </summary>
        [DataMember(Name = "occurred_at", IsRequired = false, EmitDefaultValue = false)]
        public override string OccurredAt { get; set; }

        /// <summary>
        /// ID of the workspace associated with the event.
        /// </summary>
        [DataMember(Name = "workspace_id", IsRequired = false, EmitDefaultValue = false)]
        public override string WorkspaceId { get; set; }

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
    /// An [access system encoder](https://docs.seam.co/low-level-apis/access-systems/working-with-card-encoders-and-scanners) was removed.
    /// </summary>
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
            string? eventDescription = default,
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
            EventDescription = eventDescription;
            EventId = eventId;
            EventType = eventType;
            OccurredAt = occurredAt;
            WorkspaceId = workspaceId;
        }

        /// <summary>
        /// ID of the affected encoder.
        /// </summary>
        [DataMember(Name = "acs_encoder_id", IsRequired = false, EmitDefaultValue = false)]
        public string AcsEncoderId { get; set; }

        /// <summary>
        /// ID of the access system.
        /// </summary>
        [DataMember(Name = "acs_system_id", IsRequired = false, EmitDefaultValue = false)]
        public string AcsSystemId { get; set; }

        /// <summary>
        /// ID of the connected account.
        /// </summary>
        [DataMember(Name = "connected_account_id", IsRequired = false, EmitDefaultValue = false)]
        public string? ConnectedAccountId { get; set; }

        /// <summary>
        /// Date and time at which the event was created.
        /// </summary>
        [DataMember(Name = "created_at", IsRequired = false, EmitDefaultValue = false)]
        public override string CreatedAt { get; set; }

        /// <summary>
        /// Human-readable description of the event. Persisted when the event is created (so the creating code, including a provider, can supply a tailored description) and otherwise derived from the event.
        /// </summary>
        [DataMember(Name = "event_description", IsRequired = false, EmitDefaultValue = false)]
        public override string? EventDescription { get; set; }

        /// <summary>
        /// ID of the event.
        /// </summary>
        [DataMember(Name = "event_id", IsRequired = false, EmitDefaultValue = false)]
        public override string EventId { get; set; }

        [DataMember(Name = "event_type", IsRequired = true, EmitDefaultValue = false)]
        public override string EventType { get; } = "acs_encoder.removed";

        /// <summary>
        /// Date and time at which the event occurred.
        /// </summary>
        [DataMember(Name = "occurred_at", IsRequired = false, EmitDefaultValue = false)]
        public override string OccurredAt { get; set; }

        /// <summary>
        /// ID of the workspace associated with the event.
        /// </summary>
        [DataMember(Name = "workspace_id", IsRequired = false, EmitDefaultValue = false)]
        public override string WorkspaceId { get; set; }

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
    /// An ACS access group was deleted.
    /// </summary>
    [DataContract(Name = "seamModel_eventAcsAccessGroupDeleted_model")]
    public class EventAcsAccessGroupDeleted : Event
    {
        [JsonConstructorAttribute]
        protected EventAcsAccessGroupDeleted() { }

        public EventAcsAccessGroupDeleted(
            string acsAccessGroupId = default,
            string acsSystemId = default,
            string? connectedAccountId = default,
            string createdAt = default,
            string? eventDescription = default,
            string eventId = default,
            string eventType = default,
            string occurredAt = default,
            string workspaceId = default
        )
        {
            AcsAccessGroupId = acsAccessGroupId;
            AcsSystemId = acsSystemId;
            ConnectedAccountId = connectedAccountId;
            CreatedAt = createdAt;
            EventDescription = eventDescription;
            EventId = eventId;
            EventType = eventType;
            OccurredAt = occurredAt;
            WorkspaceId = workspaceId;
        }

        /// <summary>
        /// ID of the affected access group.
        /// </summary>
        [DataMember(Name = "acs_access_group_id", IsRequired = false, EmitDefaultValue = false)]
        public string AcsAccessGroupId { get; set; }

        /// <summary>
        /// ID of the access system.
        /// </summary>
        [DataMember(Name = "acs_system_id", IsRequired = false, EmitDefaultValue = false)]
        public string AcsSystemId { get; set; }

        /// <summary>
        /// ID of the connected account.
        /// </summary>
        [DataMember(Name = "connected_account_id", IsRequired = false, EmitDefaultValue = false)]
        public string? ConnectedAccountId { get; set; }

        /// <summary>
        /// Date and time at which the event was created.
        /// </summary>
        [DataMember(Name = "created_at", IsRequired = false, EmitDefaultValue = false)]
        public override string CreatedAt { get; set; }

        /// <summary>
        /// Human-readable description of the event. Persisted when the event is created (so the creating code, including a provider, can supply a tailored description) and otherwise derived from the event.
        /// </summary>
        [DataMember(Name = "event_description", IsRequired = false, EmitDefaultValue = false)]
        public override string? EventDescription { get; set; }

        /// <summary>
        /// ID of the event.
        /// </summary>
        [DataMember(Name = "event_id", IsRequired = false, EmitDefaultValue = false)]
        public override string EventId { get; set; }

        [DataMember(Name = "event_type", IsRequired = true, EmitDefaultValue = false)]
        public override string EventType { get; } = "acs_access_group.deleted";

        /// <summary>
        /// Date and time at which the event occurred.
        /// </summary>
        [DataMember(Name = "occurred_at", IsRequired = false, EmitDefaultValue = false)]
        public override string OccurredAt { get; set; }

        /// <summary>
        /// ID of the workspace associated with the event.
        /// </summary>
        [DataMember(Name = "workspace_id", IsRequired = false, EmitDefaultValue = false)]
        public override string WorkspaceId { get; set; }

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
    /// An [access system entrance](https://docs.seam.co/low-level-apis/access-systems/retrieving-entrance-details) was added.
    /// </summary>
    [DataContract(Name = "seamModel_eventAcsEntranceAdded_model")]
    public class EventAcsEntranceAdded : Event
    {
        [JsonConstructorAttribute]
        protected EventAcsEntranceAdded() { }

        public EventAcsEntranceAdded(
            string acsEntranceId = default,
            string acsSystemId = default,
            string? connectedAccountId = default,
            string createdAt = default,
            string? eventDescription = default,
            string eventId = default,
            string eventType = default,
            string occurredAt = default,
            string workspaceId = default
        )
        {
            AcsEntranceId = acsEntranceId;
            AcsSystemId = acsSystemId;
            ConnectedAccountId = connectedAccountId;
            CreatedAt = createdAt;
            EventDescription = eventDescription;
            EventId = eventId;
            EventType = eventType;
            OccurredAt = occurredAt;
            WorkspaceId = workspaceId;
        }

        /// <summary>
        /// ID of the affected entrance.
        /// </summary>
        [DataMember(Name = "acs_entrance_id", IsRequired = false, EmitDefaultValue = false)]
        public string AcsEntranceId { get; set; }

        /// <summary>
        /// ID of the access system.
        /// </summary>
        [DataMember(Name = "acs_system_id", IsRequired = false, EmitDefaultValue = false)]
        public string AcsSystemId { get; set; }

        /// <summary>
        /// ID of the connected account.
        /// </summary>
        [DataMember(Name = "connected_account_id", IsRequired = false, EmitDefaultValue = false)]
        public string? ConnectedAccountId { get; set; }

        /// <summary>
        /// Date and time at which the event was created.
        /// </summary>
        [DataMember(Name = "created_at", IsRequired = false, EmitDefaultValue = false)]
        public override string CreatedAt { get; set; }

        /// <summary>
        /// Human-readable description of the event. Persisted when the event is created (so the creating code, including a provider, can supply a tailored description) and otherwise derived from the event.
        /// </summary>
        [DataMember(Name = "event_description", IsRequired = false, EmitDefaultValue = false)]
        public override string? EventDescription { get; set; }

        /// <summary>
        /// ID of the event.
        /// </summary>
        [DataMember(Name = "event_id", IsRequired = false, EmitDefaultValue = false)]
        public override string EventId { get; set; }

        [DataMember(Name = "event_type", IsRequired = true, EmitDefaultValue = false)]
        public override string EventType { get; } = "acs_entrance.added";

        /// <summary>
        /// Date and time at which the event occurred.
        /// </summary>
        [DataMember(Name = "occurred_at", IsRequired = false, EmitDefaultValue = false)]
        public override string OccurredAt { get; set; }

        /// <summary>
        /// ID of the workspace associated with the event.
        /// </summary>
        [DataMember(Name = "workspace_id", IsRequired = false, EmitDefaultValue = false)]
        public override string WorkspaceId { get; set; }

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
    /// An [access system entrance](https://docs.seam.co/low-level-apis/access-systems/retrieving-entrance-details) was removed.
    /// </summary>
    [DataContract(Name = "seamModel_eventAcsEntranceRemoved_model")]
    public class EventAcsEntranceRemoved : Event
    {
        [JsonConstructorAttribute]
        protected EventAcsEntranceRemoved() { }

        public EventAcsEntranceRemoved(
            string acsEntranceId = default,
            string acsSystemId = default,
            string? connectedAccountId = default,
            string createdAt = default,
            string? eventDescription = default,
            string eventId = default,
            string eventType = default,
            string occurredAt = default,
            string workspaceId = default
        )
        {
            AcsEntranceId = acsEntranceId;
            AcsSystemId = acsSystemId;
            ConnectedAccountId = connectedAccountId;
            CreatedAt = createdAt;
            EventDescription = eventDescription;
            EventId = eventId;
            EventType = eventType;
            OccurredAt = occurredAt;
            WorkspaceId = workspaceId;
        }

        /// <summary>
        /// ID of the affected entrance.
        /// </summary>
        [DataMember(Name = "acs_entrance_id", IsRequired = false, EmitDefaultValue = false)]
        public string AcsEntranceId { get; set; }

        /// <summary>
        /// ID of the access system.
        /// </summary>
        [DataMember(Name = "acs_system_id", IsRequired = false, EmitDefaultValue = false)]
        public string AcsSystemId { get; set; }

        /// <summary>
        /// ID of the connected account.
        /// </summary>
        [DataMember(Name = "connected_account_id", IsRequired = false, EmitDefaultValue = false)]
        public string? ConnectedAccountId { get; set; }

        /// <summary>
        /// Date and time at which the event was created.
        /// </summary>
        [DataMember(Name = "created_at", IsRequired = false, EmitDefaultValue = false)]
        public override string CreatedAt { get; set; }

        /// <summary>
        /// Human-readable description of the event. Persisted when the event is created (so the creating code, including a provider, can supply a tailored description) and otherwise derived from the event.
        /// </summary>
        [DataMember(Name = "event_description", IsRequired = false, EmitDefaultValue = false)]
        public override string? EventDescription { get; set; }

        /// <summary>
        /// ID of the event.
        /// </summary>
        [DataMember(Name = "event_id", IsRequired = false, EmitDefaultValue = false)]
        public override string EventId { get; set; }

        [DataMember(Name = "event_type", IsRequired = true, EmitDefaultValue = false)]
        public override string EventType { get; } = "acs_entrance.removed";

        /// <summary>
        /// Date and time at which the event occurred.
        /// </summary>
        [DataMember(Name = "occurred_at", IsRequired = false, EmitDefaultValue = false)]
        public override string OccurredAt { get; set; }

        /// <summary>
        /// ID of the workspace associated with the event.
        /// </summary>
        [DataMember(Name = "workspace_id", IsRequired = false, EmitDefaultValue = false)]
        public override string WorkspaceId { get; set; }

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
    /// A client session was deleted.
    /// </summary>
    [DataContract(Name = "seamModel_eventClientSessionDeleted_model")]
    public class EventClientSessionDeleted : Event
    {
        [JsonConstructorAttribute]
        protected EventClientSessionDeleted() { }

        public EventClientSessionDeleted(
            string clientSessionId = default,
            string createdAt = default,
            string? eventDescription = default,
            string eventId = default,
            string eventType = default,
            string occurredAt = default,
            string workspaceId = default
        )
        {
            ClientSessionId = clientSessionId;
            CreatedAt = createdAt;
            EventDescription = eventDescription;
            EventId = eventId;
            EventType = eventType;
            OccurredAt = occurredAt;
            WorkspaceId = workspaceId;
        }

        /// <summary>
        /// ID of the affected client session.
        /// </summary>
        [DataMember(Name = "client_session_id", IsRequired = false, EmitDefaultValue = false)]
        public string ClientSessionId { get; set; }

        /// <summary>
        /// Date and time at which the event was created.
        /// </summary>
        [DataMember(Name = "created_at", IsRequired = false, EmitDefaultValue = false)]
        public override string CreatedAt { get; set; }

        /// <summary>
        /// Human-readable description of the event. Persisted when the event is created (so the creating code, including a provider, can supply a tailored description) and otherwise derived from the event.
        /// </summary>
        [DataMember(Name = "event_description", IsRequired = false, EmitDefaultValue = false)]
        public override string? EventDescription { get; set; }

        /// <summary>
        /// ID of the event.
        /// </summary>
        [DataMember(Name = "event_id", IsRequired = false, EmitDefaultValue = false)]
        public override string EventId { get; set; }

        [DataMember(Name = "event_type", IsRequired = true, EmitDefaultValue = false)]
        public override string EventType { get; } = "client_session.deleted";

        /// <summary>
        /// Date and time at which the event occurred.
        /// </summary>
        [DataMember(Name = "occurred_at", IsRequired = false, EmitDefaultValue = false)]
        public override string OccurredAt { get; set; }

        /// <summary>
        /// ID of the workspace associated with the event.
        /// </summary>
        [DataMember(Name = "workspace_id", IsRequired = false, EmitDefaultValue = false)]
        public override string WorkspaceId { get; set; }

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
    /// A connected account was connected for the first time or was reconnected after being disconnected.
    /// </summary>
    [DataContract(Name = "seamModel_eventConnectedAccountConnected_model")]
    public class EventConnectedAccountConnected : Event
    {
        [JsonConstructorAttribute]
        protected EventConnectedAccountConnected() { }

        public EventConnectedAccountConnected(
            string? connectWebviewId = default,
            object? connectedAccountCustomMetadata = default,
            string connectedAccountId = default,
            string createdAt = default,
            string? customerKey = default,
            string? eventDescription = default,
            string eventId = default,
            string eventType = default,
            string occurredAt = default,
            string workspaceId = default
        )
        {
            ConnectWebviewId = connectWebviewId;
            ConnectedAccountCustomMetadata = connectedAccountCustomMetadata;
            ConnectedAccountId = connectedAccountId;
            CreatedAt = createdAt;
            CustomerKey = customerKey;
            EventDescription = eventDescription;
            EventId = eventId;
            EventType = eventType;
            OccurredAt = occurredAt;
            WorkspaceId = workspaceId;
        }

        /// <summary>
        /// ID of the Connect Webview associated with the event.
        /// </summary>
        [DataMember(Name = "connect_webview_id", IsRequired = false, EmitDefaultValue = false)]
        public string? ConnectWebviewId { get; set; }

        /// <summary>
        /// Custom metadata of the connected account, present when connected_account_id is provided.
        /// </summary>
        [DataMember(
            Name = "connected_account_custom_metadata",
            IsRequired = false,
            EmitDefaultValue = false
        )]
        public object? ConnectedAccountCustomMetadata { get; set; }

        /// <summary>
        /// ID of the affected connected account.
        /// </summary>
        [DataMember(Name = "connected_account_id", IsRequired = false, EmitDefaultValue = false)]
        public string ConnectedAccountId { get; set; }

        /// <summary>
        /// Date and time at which the event was created.
        /// </summary>
        [DataMember(Name = "created_at", IsRequired = false, EmitDefaultValue = false)]
        public override string CreatedAt { get; set; }

        /// <summary>
        /// The customer key associated with this connected account, if any.
        /// </summary>
        [DataMember(Name = "customer_key", IsRequired = false, EmitDefaultValue = false)]
        public string? CustomerKey { get; set; }

        /// <summary>
        /// Human-readable description of the event. Persisted when the event is created (so the creating code, including a provider, can supply a tailored description) and otherwise derived from the event.
        /// </summary>
        [DataMember(Name = "event_description", IsRequired = false, EmitDefaultValue = false)]
        public override string? EventDescription { get; set; }

        /// <summary>
        /// ID of the event.
        /// </summary>
        [DataMember(Name = "event_id", IsRequired = false, EmitDefaultValue = false)]
        public override string EventId { get; set; }

        [DataMember(Name = "event_type", IsRequired = true, EmitDefaultValue = false)]
        public override string EventType { get; } = "connected_account.connected";

        /// <summary>
        /// Date and time at which the event occurred.
        /// </summary>
        [DataMember(Name = "occurred_at", IsRequired = false, EmitDefaultValue = false)]
        public override string OccurredAt { get; set; }

        /// <summary>
        /// ID of the workspace associated with the event.
        /// </summary>
        [DataMember(Name = "workspace_id", IsRequired = false, EmitDefaultValue = false)]
        public override string WorkspaceId { get; set; }

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
    /// A connected account was created.
    /// </summary>
    [DataContract(Name = "seamModel_eventConnectedAccountCreated_model")]
    public class EventConnectedAccountCreated : Event
    {
        [JsonConstructorAttribute]
        protected EventConnectedAccountCreated() { }

        public EventConnectedAccountCreated(
            string connectWebviewId = default,
            object? connectedAccountCustomMetadata = default,
            string connectedAccountId = default,
            string createdAt = default,
            string? eventDescription = default,
            string eventId = default,
            string eventType = default,
            string occurredAt = default,
            string workspaceId = default
        )
        {
            ConnectWebviewId = connectWebviewId;
            ConnectedAccountCustomMetadata = connectedAccountCustomMetadata;
            ConnectedAccountId = connectedAccountId;
            CreatedAt = createdAt;
            EventDescription = eventDescription;
            EventId = eventId;
            EventType = eventType;
            OccurredAt = occurredAt;
            WorkspaceId = workspaceId;
        }

        /// <summary>
        /// ID of the Connect Webview associated with the event.
        /// </summary>
        [DataMember(Name = "connect_webview_id", IsRequired = false, EmitDefaultValue = false)]
        public string ConnectWebviewId { get; set; }

        /// <summary>
        /// Custom metadata of the connected account, present when connected_account_id is provided.
        /// </summary>
        [DataMember(
            Name = "connected_account_custom_metadata",
            IsRequired = false,
            EmitDefaultValue = false
        )]
        public object? ConnectedAccountCustomMetadata { get; set; }

        /// <summary>
        /// ID of the affected connected account.
        /// </summary>
        [DataMember(Name = "connected_account_id", IsRequired = false, EmitDefaultValue = false)]
        public string ConnectedAccountId { get; set; }

        /// <summary>
        /// Date and time at which the event was created.
        /// </summary>
        [DataMember(Name = "created_at", IsRequired = false, EmitDefaultValue = false)]
        public override string CreatedAt { get; set; }

        /// <summary>
        /// Human-readable description of the event. Persisted when the event is created (so the creating code, including a provider, can supply a tailored description) and otherwise derived from the event.
        /// </summary>
        [DataMember(Name = "event_description", IsRequired = false, EmitDefaultValue = false)]
        public override string? EventDescription { get; set; }

        /// <summary>
        /// ID of the event.
        /// </summary>
        [DataMember(Name = "event_id", IsRequired = false, EmitDefaultValue = false)]
        public override string EventId { get; set; }

        [DataMember(Name = "event_type", IsRequired = true, EmitDefaultValue = false)]
        public override string EventType { get; } = "connected_account.created";

        /// <summary>
        /// Date and time at which the event occurred.
        /// </summary>
        [DataMember(Name = "occurred_at", IsRequired = false, EmitDefaultValue = false)]
        public override string OccurredAt { get; set; }

        /// <summary>
        /// ID of the workspace associated with the event.
        /// </summary>
        [DataMember(Name = "workspace_id", IsRequired = false, EmitDefaultValue = false)]
        public override string WorkspaceId { get; set; }

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
    /// A connected account had a successful login using a Connect Webview.
    /// </summary>
    [Obsolete("Use `connect_webview.login_succeeded`.")]
    [DataContract(Name = "seamModel_eventConnectedAccountSuccessfulLogin_model")]
    public class EventConnectedAccountSuccessfulLogin : Event
    {
        [JsonConstructorAttribute]
        protected EventConnectedAccountSuccessfulLogin() { }

        public EventConnectedAccountSuccessfulLogin(
            string connectWebviewId = default,
            object? connectedAccountCustomMetadata = default,
            string connectedAccountId = default,
            string createdAt = default,
            string? eventDescription = default,
            string eventId = default,
            string eventType = default,
            string occurredAt = default,
            string workspaceId = default
        )
        {
            ConnectWebviewId = connectWebviewId;
            ConnectedAccountCustomMetadata = connectedAccountCustomMetadata;
            ConnectedAccountId = connectedAccountId;
            CreatedAt = createdAt;
            EventDescription = eventDescription;
            EventId = eventId;
            EventType = eventType;
            OccurredAt = occurredAt;
            WorkspaceId = workspaceId;
        }

        /// <summary>
        /// ID of the Connect Webview associated with the event.
        /// </summary>
        [DataMember(Name = "connect_webview_id", IsRequired = false, EmitDefaultValue = false)]
        public string ConnectWebviewId { get; set; }

        /// <summary>
        /// Custom metadata of the connected account, present when connected_account_id is provided.
        /// </summary>
        [DataMember(
            Name = "connected_account_custom_metadata",
            IsRequired = false,
            EmitDefaultValue = false
        )]
        public object? ConnectedAccountCustomMetadata { get; set; }

        /// <summary>
        /// ID of the affected connected account.
        /// </summary>
        [DataMember(Name = "connected_account_id", IsRequired = false, EmitDefaultValue = false)]
        public string ConnectedAccountId { get; set; }

        /// <summary>
        /// Date and time at which the event was created.
        /// </summary>
        [DataMember(Name = "created_at", IsRequired = false, EmitDefaultValue = false)]
        public override string CreatedAt { get; set; }

        /// <summary>
        /// Human-readable description of the event. Persisted when the event is created (so the creating code, including a provider, can supply a tailored description) and otherwise derived from the event.
        /// </summary>
        [DataMember(Name = "event_description", IsRequired = false, EmitDefaultValue = false)]
        public override string? EventDescription { get; set; }

        /// <summary>
        /// ID of the event.
        /// </summary>
        [DataMember(Name = "event_id", IsRequired = false, EmitDefaultValue = false)]
        public override string EventId { get; set; }

        [DataMember(Name = "event_type", IsRequired = true, EmitDefaultValue = false)]
        public override string EventType { get; } = "connected_account.successful_login";

        /// <summary>
        /// Date and time at which the event occurred.
        /// </summary>
        [DataMember(Name = "occurred_at", IsRequired = false, EmitDefaultValue = false)]
        public override string OccurredAt { get; set; }

        /// <summary>
        /// ID of the workspace associated with the event.
        /// </summary>
        [DataMember(Name = "workspace_id", IsRequired = false, EmitDefaultValue = false)]
        public override string WorkspaceId { get; set; }

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
    /// A connected account was disconnected.
    /// </summary>
    [DataContract(Name = "seamModel_eventConnectedAccountDisconnected_model")]
    public class EventConnectedAccountDisconnected : Event
    {
        [JsonConstructorAttribute]
        protected EventConnectedAccountDisconnected() { }

        public EventConnectedAccountDisconnected(
            object? connectedAccountCustomMetadata = default,
            List<EventConnectedAccountDisconnectedConnectedAccountErrors> connectedAccountErrors =
                default,
            string connectedAccountId = default,
            List<EventConnectedAccountDisconnectedConnectedAccountWarnings> connectedAccountWarnings =
                default,
            string createdAt = default,
            string? eventDescription = default,
            string eventId = default,
            string eventType = default,
            string occurredAt = default,
            string workspaceId = default
        )
        {
            ConnectedAccountCustomMetadata = connectedAccountCustomMetadata;
            ConnectedAccountErrors = connectedAccountErrors;
            ConnectedAccountId = connectedAccountId;
            ConnectedAccountWarnings = connectedAccountWarnings;
            CreatedAt = createdAt;
            EventDescription = eventDescription;
            EventId = eventId;
            EventType = eventType;
            OccurredAt = occurredAt;
            WorkspaceId = workspaceId;
        }

        /// <summary>
        /// Custom metadata of the connected account, present when connected_account_id is provided.
        /// </summary>
        [DataMember(
            Name = "connected_account_custom_metadata",
            IsRequired = false,
            EmitDefaultValue = false
        )]
        public object? ConnectedAccountCustomMetadata { get; set; }

        /// <summary>
        /// Errors associated with the connected account.
        /// </summary>
        [DataMember(
            Name = "connected_account_errors",
            IsRequired = false,
            EmitDefaultValue = false
        )]
        public List<EventConnectedAccountDisconnectedConnectedAccountErrors> ConnectedAccountErrors { get; set; }

        /// <summary>
        /// ID of the affected connected account.
        /// </summary>
        [DataMember(Name = "connected_account_id", IsRequired = false, EmitDefaultValue = false)]
        public string ConnectedAccountId { get; set; }

        /// <summary>
        /// Warnings associated with the connected account.
        /// </summary>
        [DataMember(
            Name = "connected_account_warnings",
            IsRequired = false,
            EmitDefaultValue = false
        )]
        public List<EventConnectedAccountDisconnectedConnectedAccountWarnings> ConnectedAccountWarnings { get; set; }

        /// <summary>
        /// Date and time at which the event was created.
        /// </summary>
        [DataMember(Name = "created_at", IsRequired = false, EmitDefaultValue = false)]
        public override string CreatedAt { get; set; }

        /// <summary>
        /// Human-readable description of the event. Persisted when the event is created (so the creating code, including a provider, can supply a tailored description) and otherwise derived from the event.
        /// </summary>
        [DataMember(Name = "event_description", IsRequired = false, EmitDefaultValue = false)]
        public override string? EventDescription { get; set; }

        /// <summary>
        /// ID of the event.
        /// </summary>
        [DataMember(Name = "event_id", IsRequired = false, EmitDefaultValue = false)]
        public override string EventId { get; set; }

        [DataMember(Name = "event_type", IsRequired = true, EmitDefaultValue = false)]
        public override string EventType { get; } = "connected_account.disconnected";

        /// <summary>
        /// Date and time at which the event occurred.
        /// </summary>
        [DataMember(Name = "occurred_at", IsRequired = false, EmitDefaultValue = false)]
        public override string OccurredAt { get; set; }

        /// <summary>
        /// ID of the workspace associated with the event.
        /// </summary>
        [DataMember(Name = "workspace_id", IsRequired = false, EmitDefaultValue = false)]
        public override string WorkspaceId { get; set; }

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

    [DataContract(Name = "seamModel_eventConnectedAccountDisconnectedConnectedAccountErrors_model")]
    public class EventConnectedAccountDisconnectedConnectedAccountErrors
    {
        [JsonConstructorAttribute]
        protected EventConnectedAccountDisconnectedConnectedAccountErrors() { }

        public EventConnectedAccountDisconnectedConnectedAccountErrors(
            string createdAt = default,
            string errorCode = default,
            string message = default
        )
        {
            CreatedAt = createdAt;
            ErrorCode = errorCode;
            Message = message;
        }

        /// <summary>
        /// Date and time at which Seam created the error.
        /// </summary>
        [DataMember(Name = "created_at", IsRequired = false, EmitDefaultValue = false)]
        public string CreatedAt { get; set; }

        /// <summary>
        /// Unique identifier of the type of error. Enables quick recognition and categorization of the issue.
        /// </summary>
        [DataMember(Name = "error_code", IsRequired = false, EmitDefaultValue = false)]
        public string ErrorCode { get; set; }

        /// <summary>
        /// Detailed description of the error. Provides insights into the issue and potentially how to rectify it.
        /// </summary>
        [DataMember(Name = "message", IsRequired = false, EmitDefaultValue = false)]
        public string Message { get; set; }

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
        Name = "seamModel_eventConnectedAccountDisconnectedConnectedAccountWarnings_model"
    )]
    public class EventConnectedAccountDisconnectedConnectedAccountWarnings
    {
        [JsonConstructorAttribute]
        protected EventConnectedAccountDisconnectedConnectedAccountWarnings() { }

        public EventConnectedAccountDisconnectedConnectedAccountWarnings(
            string createdAt = default,
            string message = default,
            string warningCode = default
        )
        {
            CreatedAt = createdAt;
            Message = message;
            WarningCode = warningCode;
        }

        /// <summary>
        /// Date and time at which Seam created the warning.
        /// </summary>
        [DataMember(Name = "created_at", IsRequired = false, EmitDefaultValue = false)]
        public string CreatedAt { get; set; }

        /// <summary>
        /// Detailed description of the warning. Provides insights into the issue and potentially how to rectify it.
        /// </summary>
        [DataMember(Name = "message", IsRequired = false, EmitDefaultValue = false)]
        public string Message { get; set; }

        /// <summary>
        /// Unique identifier of the type of warning. Enables quick recognition and categorization of the issue.
        /// </summary>
        [DataMember(Name = "warning_code", IsRequired = false, EmitDefaultValue = false)]
        public string WarningCode { get; set; }

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
    /// A connected account completed the first sync with Seam, and the corresponding devices or systems are now available.
    /// </summary>
    [DataContract(Name = "seamModel_eventConnectedAccountCompletedFirstSync_model")]
    public class EventConnectedAccountCompletedFirstSync : Event
    {
        [JsonConstructorAttribute]
        protected EventConnectedAccountCompletedFirstSync() { }

        public EventConnectedAccountCompletedFirstSync(
            object? connectedAccountCustomMetadata = default,
            string connectedAccountId = default,
            string createdAt = default,
            string? eventDescription = default,
            string eventId = default,
            string eventType = default,
            string occurredAt = default,
            string workspaceId = default
        )
        {
            ConnectedAccountCustomMetadata = connectedAccountCustomMetadata;
            ConnectedAccountId = connectedAccountId;
            CreatedAt = createdAt;
            EventDescription = eventDescription;
            EventId = eventId;
            EventType = eventType;
            OccurredAt = occurredAt;
            WorkspaceId = workspaceId;
        }

        /// <summary>
        /// Custom metadata of the connected account, present when connected_account_id is provided.
        /// </summary>
        [DataMember(
            Name = "connected_account_custom_metadata",
            IsRequired = false,
            EmitDefaultValue = false
        )]
        public object? ConnectedAccountCustomMetadata { get; set; }

        /// <summary>
        /// ID of the affected connected account.
        /// </summary>
        [DataMember(Name = "connected_account_id", IsRequired = false, EmitDefaultValue = false)]
        public string ConnectedAccountId { get; set; }

        /// <summary>
        /// Date and time at which the event was created.
        /// </summary>
        [DataMember(Name = "created_at", IsRequired = false, EmitDefaultValue = false)]
        public override string CreatedAt { get; set; }

        /// <summary>
        /// Human-readable description of the event. Persisted when the event is created (so the creating code, including a provider, can supply a tailored description) and otherwise derived from the event.
        /// </summary>
        [DataMember(Name = "event_description", IsRequired = false, EmitDefaultValue = false)]
        public override string? EventDescription { get; set; }

        /// <summary>
        /// ID of the event.
        /// </summary>
        [DataMember(Name = "event_id", IsRequired = false, EmitDefaultValue = false)]
        public override string EventId { get; set; }

        [DataMember(Name = "event_type", IsRequired = true, EmitDefaultValue = false)]
        public override string EventType { get; } = "connected_account.completed_first_sync";

        /// <summary>
        /// Date and time at which the event occurred.
        /// </summary>
        [DataMember(Name = "occurred_at", IsRequired = false, EmitDefaultValue = false)]
        public override string OccurredAt { get; set; }

        /// <summary>
        /// ID of the workspace associated with the event.
        /// </summary>
        [DataMember(Name = "workspace_id", IsRequired = false, EmitDefaultValue = false)]
        public override string WorkspaceId { get; set; }

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
    /// A connected account was deleted.
    /// </summary>
    [DataContract(Name = "seamModel_eventConnectedAccountDeleted_model")]
    public class EventConnectedAccountDeleted : Event
    {
        [JsonConstructorAttribute]
        protected EventConnectedAccountDeleted() { }

        public EventConnectedAccountDeleted(
            object? connectedAccountCustomMetadata = default,
            string connectedAccountId = default,
            string? connectedAccountType = default,
            string createdAt = default,
            string? customerKey = default,
            string? eventDescription = default,
            string eventId = default,
            string eventType = default,
            string occurredAt = default,
            string workspaceId = default
        )
        {
            ConnectedAccountCustomMetadata = connectedAccountCustomMetadata;
            ConnectedAccountId = connectedAccountId;
            ConnectedAccountType = connectedAccountType;
            CreatedAt = createdAt;
            CustomerKey = customerKey;
            EventDescription = eventDescription;
            EventId = eventId;
            EventType = eventType;
            OccurredAt = occurredAt;
            WorkspaceId = workspaceId;
        }

        /// <summary>
        /// Custom metadata of the connected account, present when connected_account_id is provided.
        /// </summary>
        [DataMember(
            Name = "connected_account_custom_metadata",
            IsRequired = false,
            EmitDefaultValue = false
        )]
        public object? ConnectedAccountCustomMetadata { get; set; }

        /// <summary>
        /// ID of the affected connected account.
        /// </summary>
        [DataMember(Name = "connected_account_id", IsRequired = false, EmitDefaultValue = false)]
        public string ConnectedAccountId { get; set; }

        /// <summary>
        /// undocumented: Unreleased.
        /// </summary>
        [DataMember(Name = "connected_account_type", IsRequired = false, EmitDefaultValue = false)]
        public string? ConnectedAccountType { get; set; }

        /// <summary>
        /// Date and time at which the event was created.
        /// </summary>
        [DataMember(Name = "created_at", IsRequired = false, EmitDefaultValue = false)]
        public override string CreatedAt { get; set; }

        /// <summary>
        /// The customer key associated with this connected account, if any.
        /// </summary>
        [DataMember(Name = "customer_key", IsRequired = false, EmitDefaultValue = false)]
        public string? CustomerKey { get; set; }

        /// <summary>
        /// Human-readable description of the event. Persisted when the event is created (so the creating code, including a provider, can supply a tailored description) and otherwise derived from the event.
        /// </summary>
        [DataMember(Name = "event_description", IsRequired = false, EmitDefaultValue = false)]
        public override string? EventDescription { get; set; }

        /// <summary>
        /// ID of the event.
        /// </summary>
        [DataMember(Name = "event_id", IsRequired = false, EmitDefaultValue = false)]
        public override string EventId { get; set; }

        [DataMember(Name = "event_type", IsRequired = true, EmitDefaultValue = false)]
        public override string EventType { get; } = "connected_account.deleted";

        /// <summary>
        /// Date and time at which the event occurred.
        /// </summary>
        [DataMember(Name = "occurred_at", IsRequired = false, EmitDefaultValue = false)]
        public override string OccurredAt { get; set; }

        /// <summary>
        /// ID of the workspace associated with the event.
        /// </summary>
        [DataMember(Name = "workspace_id", IsRequired = false, EmitDefaultValue = false)]
        public override string WorkspaceId { get; set; }

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
    /// A connected account completed the first sync after reconnection with Seam, and the corresponding devices or systems are now available.
    /// </summary>
    [DataContract(
        Name = "seamModel_eventConnectedAccountCompletedFirstSyncAfterReconnection_model"
    )]
    public class EventConnectedAccountCompletedFirstSyncAfterReconnection : Event
    {
        [JsonConstructorAttribute]
        protected EventConnectedAccountCompletedFirstSyncAfterReconnection() { }

        public EventConnectedAccountCompletedFirstSyncAfterReconnection(
            object? connectedAccountCustomMetadata = default,
            string connectedAccountId = default,
            string createdAt = default,
            string? eventDescription = default,
            string eventId = default,
            string eventType = default,
            string occurredAt = default,
            string workspaceId = default
        )
        {
            ConnectedAccountCustomMetadata = connectedAccountCustomMetadata;
            ConnectedAccountId = connectedAccountId;
            CreatedAt = createdAt;
            EventDescription = eventDescription;
            EventId = eventId;
            EventType = eventType;
            OccurredAt = occurredAt;
            WorkspaceId = workspaceId;
        }

        /// <summary>
        /// Custom metadata of the connected account, present when connected_account_id is provided.
        /// </summary>
        [DataMember(
            Name = "connected_account_custom_metadata",
            IsRequired = false,
            EmitDefaultValue = false
        )]
        public object? ConnectedAccountCustomMetadata { get; set; }

        /// <summary>
        /// ID of the affected connected account.
        /// </summary>
        [DataMember(Name = "connected_account_id", IsRequired = false, EmitDefaultValue = false)]
        public string ConnectedAccountId { get; set; }

        /// <summary>
        /// Date and time at which the event was created.
        /// </summary>
        [DataMember(Name = "created_at", IsRequired = false, EmitDefaultValue = false)]
        public override string CreatedAt { get; set; }

        /// <summary>
        /// Human-readable description of the event. Persisted when the event is created (so the creating code, including a provider, can supply a tailored description) and otherwise derived from the event.
        /// </summary>
        [DataMember(Name = "event_description", IsRequired = false, EmitDefaultValue = false)]
        public override string? EventDescription { get; set; }

        /// <summary>
        /// ID of the event.
        /// </summary>
        [DataMember(Name = "event_id", IsRequired = false, EmitDefaultValue = false)]
        public override string EventId { get; set; }

        [DataMember(Name = "event_type", IsRequired = true, EmitDefaultValue = false)]
        public override string EventType { get; } =
            "connected_account.completed_first_sync_after_reconnection";

        /// <summary>
        /// Date and time at which the event occurred.
        /// </summary>
        [DataMember(Name = "occurred_at", IsRequired = false, EmitDefaultValue = false)]
        public override string OccurredAt { get; set; }

        /// <summary>
        /// ID of the workspace associated with the event.
        /// </summary>
        [DataMember(Name = "workspace_id", IsRequired = false, EmitDefaultValue = false)]
        public override string WorkspaceId { get; set; }

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
    /// A connected account requires reauthorization using a new Connect Webview. The account is still connected, but cannot access new features. Delaying reauthorization too long will eventually cause the Connected Account to become disconnected.
    /// </summary>
    [DataContract(Name = "seamModel_eventConnectedAccountReauthorizationRequested_model")]
    public class EventConnectedAccountReauthorizationRequested : Event
    {
        [JsonConstructorAttribute]
        protected EventConnectedAccountReauthorizationRequested() { }

        public EventConnectedAccountReauthorizationRequested(
            object? connectedAccountCustomMetadata = default,
            List<EventConnectedAccountReauthorizationRequestedConnectedAccountErrors> connectedAccountErrors =
                default,
            string connectedAccountId = default,
            List<EventConnectedAccountReauthorizationRequestedConnectedAccountWarnings> connectedAccountWarnings =
                default,
            string createdAt = default,
            string? eventDescription = default,
            string eventId = default,
            string eventType = default,
            string occurredAt = default,
            string workspaceId = default
        )
        {
            ConnectedAccountCustomMetadata = connectedAccountCustomMetadata;
            ConnectedAccountErrors = connectedAccountErrors;
            ConnectedAccountId = connectedAccountId;
            ConnectedAccountWarnings = connectedAccountWarnings;
            CreatedAt = createdAt;
            EventDescription = eventDescription;
            EventId = eventId;
            EventType = eventType;
            OccurredAt = occurredAt;
            WorkspaceId = workspaceId;
        }

        /// <summary>
        /// Custom metadata of the connected account, present when connected_account_id is provided.
        /// </summary>
        [DataMember(
            Name = "connected_account_custom_metadata",
            IsRequired = false,
            EmitDefaultValue = false
        )]
        public object? ConnectedAccountCustomMetadata { get; set; }

        /// <summary>
        /// Errors associated with the connected account.
        /// </summary>
        [DataMember(
            Name = "connected_account_errors",
            IsRequired = false,
            EmitDefaultValue = false
        )]
        public List<EventConnectedAccountReauthorizationRequestedConnectedAccountErrors> ConnectedAccountErrors { get; set; }

        /// <summary>
        /// ID of the affected connected account.
        /// </summary>
        [DataMember(Name = "connected_account_id", IsRequired = false, EmitDefaultValue = false)]
        public string ConnectedAccountId { get; set; }

        /// <summary>
        /// Warnings associated with the connected account.
        /// </summary>
        [DataMember(
            Name = "connected_account_warnings",
            IsRequired = false,
            EmitDefaultValue = false
        )]
        public List<EventConnectedAccountReauthorizationRequestedConnectedAccountWarnings> ConnectedAccountWarnings { get; set; }

        /// <summary>
        /// Date and time at which the event was created.
        /// </summary>
        [DataMember(Name = "created_at", IsRequired = false, EmitDefaultValue = false)]
        public override string CreatedAt { get; set; }

        /// <summary>
        /// Human-readable description of the event. Persisted when the event is created (so the creating code, including a provider, can supply a tailored description) and otherwise derived from the event.
        /// </summary>
        [DataMember(Name = "event_description", IsRequired = false, EmitDefaultValue = false)]
        public override string? EventDescription { get; set; }

        /// <summary>
        /// ID of the event.
        /// </summary>
        [DataMember(Name = "event_id", IsRequired = false, EmitDefaultValue = false)]
        public override string EventId { get; set; }

        [DataMember(Name = "event_type", IsRequired = true, EmitDefaultValue = false)]
        public override string EventType { get; } = "connected_account.reauthorization_requested";

        /// <summary>
        /// Date and time at which the event occurred.
        /// </summary>
        [DataMember(Name = "occurred_at", IsRequired = false, EmitDefaultValue = false)]
        public override string OccurredAt { get; set; }

        /// <summary>
        /// ID of the workspace associated with the event.
        /// </summary>
        [DataMember(Name = "workspace_id", IsRequired = false, EmitDefaultValue = false)]
        public override string WorkspaceId { get; set; }

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
        Name = "seamModel_eventConnectedAccountReauthorizationRequestedConnectedAccountErrors_model"
    )]
    public class EventConnectedAccountReauthorizationRequestedConnectedAccountErrors
    {
        [JsonConstructorAttribute]
        protected EventConnectedAccountReauthorizationRequestedConnectedAccountErrors() { }

        public EventConnectedAccountReauthorizationRequestedConnectedAccountErrors(
            string createdAt = default,
            string errorCode = default,
            string message = default
        )
        {
            CreatedAt = createdAt;
            ErrorCode = errorCode;
            Message = message;
        }

        /// <summary>
        /// Date and time at which Seam created the error.
        /// </summary>
        [DataMember(Name = "created_at", IsRequired = false, EmitDefaultValue = false)]
        public string CreatedAt { get; set; }

        /// <summary>
        /// Unique identifier of the type of error. Enables quick recognition and categorization of the issue.
        /// </summary>
        [DataMember(Name = "error_code", IsRequired = false, EmitDefaultValue = false)]
        public string ErrorCode { get; set; }

        /// <summary>
        /// Detailed description of the error. Provides insights into the issue and potentially how to rectify it.
        /// </summary>
        [DataMember(Name = "message", IsRequired = false, EmitDefaultValue = false)]
        public string Message { get; set; }

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
        Name = "seamModel_eventConnectedAccountReauthorizationRequestedConnectedAccountWarnings_model"
    )]
    public class EventConnectedAccountReauthorizationRequestedConnectedAccountWarnings
    {
        [JsonConstructorAttribute]
        protected EventConnectedAccountReauthorizationRequestedConnectedAccountWarnings() { }

        public EventConnectedAccountReauthorizationRequestedConnectedAccountWarnings(
            string createdAt = default,
            string message = default,
            string warningCode = default
        )
        {
            CreatedAt = createdAt;
            Message = message;
            WarningCode = warningCode;
        }

        /// <summary>
        /// Date and time at which Seam created the warning.
        /// </summary>
        [DataMember(Name = "created_at", IsRequired = false, EmitDefaultValue = false)]
        public string CreatedAt { get; set; }

        /// <summary>
        /// Detailed description of the warning. Provides insights into the issue and potentially how to rectify it.
        /// </summary>
        [DataMember(Name = "message", IsRequired = false, EmitDefaultValue = false)]
        public string Message { get; set; }

        /// <summary>
        /// Unique identifier of the type of warning. Enables quick recognition and categorization of the issue.
        /// </summary>
        [DataMember(Name = "warning_code", IsRequired = false, EmitDefaultValue = false)]
        public string WarningCode { get; set; }

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
    /// A lock door action attempt succeeded.
    /// </summary>
    [DataContract(Name = "seamModel_eventActionAttemptLockDoorSucceeded_model")]
    public class EventActionAttemptLockDoorSucceeded : Event
    {
        [JsonConstructorAttribute]
        protected EventActionAttemptLockDoorSucceeded() { }

        public EventActionAttemptLockDoorSucceeded(
            string actionAttemptId = default,
            string actionType = default,
            string? connectedAccountId = default,
            string createdAt = default,
            string? deviceId = default,
            string? eventDescription = default,
            string eventId = default,
            string eventType = default,
            string occurredAt = default,
            string status = default,
            string workspaceId = default
        )
        {
            ActionAttemptId = actionAttemptId;
            ActionType = actionType;
            ConnectedAccountId = connectedAccountId;
            CreatedAt = createdAt;
            DeviceId = deviceId;
            EventDescription = eventDescription;
            EventId = eventId;
            EventType = eventType;
            OccurredAt = occurredAt;
            Status = status;
            WorkspaceId = workspaceId;
        }

        /// <summary>
        /// ID of the affected action attempt.
        /// </summary>
        [DataMember(Name = "action_attempt_id", IsRequired = false, EmitDefaultValue = false)]
        public string ActionAttemptId { get; set; }

        /// <summary>
        /// Type of the action.
        /// </summary>
        [DataMember(Name = "action_type", IsRequired = false, EmitDefaultValue = false)]
        public string ActionType { get; set; }

        /// <summary>
        /// ID of the connected account associated with the action attempt, if applicable.
        /// </summary>
        [DataMember(Name = "connected_account_id", IsRequired = false, EmitDefaultValue = false)]
        public string? ConnectedAccountId { get; set; }

        /// <summary>
        /// Date and time at which the event was created.
        /// </summary>
        [DataMember(Name = "created_at", IsRequired = false, EmitDefaultValue = false)]
        public override string CreatedAt { get; set; }

        /// <summary>
        /// ID of the device associated with the action attempt, if applicable.
        /// </summary>
        [DataMember(Name = "device_id", IsRequired = false, EmitDefaultValue = false)]
        public string? DeviceId { get; set; }

        /// <summary>
        /// Human-readable description of the event. Persisted when the event is created (so the creating code, including a provider, can supply a tailored description) and otherwise derived from the event.
        /// </summary>
        [DataMember(Name = "event_description", IsRequired = false, EmitDefaultValue = false)]
        public override string? EventDescription { get; set; }

        /// <summary>
        /// ID of the event.
        /// </summary>
        [DataMember(Name = "event_id", IsRequired = false, EmitDefaultValue = false)]
        public override string EventId { get; set; }

        [DataMember(Name = "event_type", IsRequired = true, EmitDefaultValue = false)]
        public override string EventType { get; } = "action_attempt.lock_door.succeeded";

        /// <summary>
        /// Date and time at which the event occurred.
        /// </summary>
        [DataMember(Name = "occurred_at", IsRequired = false, EmitDefaultValue = false)]
        public override string OccurredAt { get; set; }

        /// <summary>
        /// Status of the action.
        /// </summary>
        [DataMember(Name = "status", IsRequired = false, EmitDefaultValue = false)]
        public string Status { get; set; }

        /// <summary>
        /// ID of the workspace associated with the event.
        /// </summary>
        [DataMember(Name = "workspace_id", IsRequired = false, EmitDefaultValue = false)]
        public override string WorkspaceId { get; set; }

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
    /// A lock door action attempt failed.
    /// </summary>
    [DataContract(Name = "seamModel_eventActionAttemptLockDoorFailed_model")]
    public class EventActionAttemptLockDoorFailed : Event
    {
        [JsonConstructorAttribute]
        protected EventActionAttemptLockDoorFailed() { }

        public EventActionAttemptLockDoorFailed(
            string actionAttemptId = default,
            string actionType = default,
            string? connectedAccountId = default,
            string createdAt = default,
            string? deviceId = default,
            string? eventDescription = default,
            string eventId = default,
            string eventType = default,
            string occurredAt = default,
            string status = default,
            string workspaceId = default
        )
        {
            ActionAttemptId = actionAttemptId;
            ActionType = actionType;
            ConnectedAccountId = connectedAccountId;
            CreatedAt = createdAt;
            DeviceId = deviceId;
            EventDescription = eventDescription;
            EventId = eventId;
            EventType = eventType;
            OccurredAt = occurredAt;
            Status = status;
            WorkspaceId = workspaceId;
        }

        /// <summary>
        /// ID of the affected action attempt.
        /// </summary>
        [DataMember(Name = "action_attempt_id", IsRequired = false, EmitDefaultValue = false)]
        public string ActionAttemptId { get; set; }

        /// <summary>
        /// Type of the action.
        /// </summary>
        [DataMember(Name = "action_type", IsRequired = false, EmitDefaultValue = false)]
        public string ActionType { get; set; }

        /// <summary>
        /// ID of the connected account associated with the action attempt, if applicable.
        /// </summary>
        [DataMember(Name = "connected_account_id", IsRequired = false, EmitDefaultValue = false)]
        public string? ConnectedAccountId { get; set; }

        /// <summary>
        /// Date and time at which the event was created.
        /// </summary>
        [DataMember(Name = "created_at", IsRequired = false, EmitDefaultValue = false)]
        public override string CreatedAt { get; set; }

        /// <summary>
        /// ID of the device associated with the action attempt, if applicable.
        /// </summary>
        [DataMember(Name = "device_id", IsRequired = false, EmitDefaultValue = false)]
        public string? DeviceId { get; set; }

        /// <summary>
        /// Human-readable description of the event. Persisted when the event is created (so the creating code, including a provider, can supply a tailored description) and otherwise derived from the event.
        /// </summary>
        [DataMember(Name = "event_description", IsRequired = false, EmitDefaultValue = false)]
        public override string? EventDescription { get; set; }

        /// <summary>
        /// ID of the event.
        /// </summary>
        [DataMember(Name = "event_id", IsRequired = false, EmitDefaultValue = false)]
        public override string EventId { get; set; }

        [DataMember(Name = "event_type", IsRequired = true, EmitDefaultValue = false)]
        public override string EventType { get; } = "action_attempt.lock_door.failed";

        /// <summary>
        /// Date and time at which the event occurred.
        /// </summary>
        [DataMember(Name = "occurred_at", IsRequired = false, EmitDefaultValue = false)]
        public override string OccurredAt { get; set; }

        /// <summary>
        /// Status of the action.
        /// </summary>
        [DataMember(Name = "status", IsRequired = false, EmitDefaultValue = false)]
        public string Status { get; set; }

        /// <summary>
        /// ID of the workspace associated with the event.
        /// </summary>
        [DataMember(Name = "workspace_id", IsRequired = false, EmitDefaultValue = false)]
        public override string WorkspaceId { get; set; }

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
    /// An unlock door action attempt succeeded.
    /// </summary>
    [DataContract(Name = "seamModel_eventActionAttemptUnlockDoorSucceeded_model")]
    public class EventActionAttemptUnlockDoorSucceeded : Event
    {
        [JsonConstructorAttribute]
        protected EventActionAttemptUnlockDoorSucceeded() { }

        public EventActionAttemptUnlockDoorSucceeded(
            string actionAttemptId = default,
            string actionType = default,
            string? connectedAccountId = default,
            string createdAt = default,
            string? deviceId = default,
            string? eventDescription = default,
            string eventId = default,
            string eventType = default,
            string occurredAt = default,
            string status = default,
            string workspaceId = default
        )
        {
            ActionAttemptId = actionAttemptId;
            ActionType = actionType;
            ConnectedAccountId = connectedAccountId;
            CreatedAt = createdAt;
            DeviceId = deviceId;
            EventDescription = eventDescription;
            EventId = eventId;
            EventType = eventType;
            OccurredAt = occurredAt;
            Status = status;
            WorkspaceId = workspaceId;
        }

        /// <summary>
        /// ID of the affected action attempt.
        /// </summary>
        [DataMember(Name = "action_attempt_id", IsRequired = false, EmitDefaultValue = false)]
        public string ActionAttemptId { get; set; }

        /// <summary>
        /// Type of the action.
        /// </summary>
        [DataMember(Name = "action_type", IsRequired = false, EmitDefaultValue = false)]
        public string ActionType { get; set; }

        /// <summary>
        /// ID of the connected account associated with the action attempt, if applicable.
        /// </summary>
        [DataMember(Name = "connected_account_id", IsRequired = false, EmitDefaultValue = false)]
        public string? ConnectedAccountId { get; set; }

        /// <summary>
        /// Date and time at which the event was created.
        /// </summary>
        [DataMember(Name = "created_at", IsRequired = false, EmitDefaultValue = false)]
        public override string CreatedAt { get; set; }

        /// <summary>
        /// ID of the device associated with the action attempt, if applicable.
        /// </summary>
        [DataMember(Name = "device_id", IsRequired = false, EmitDefaultValue = false)]
        public string? DeviceId { get; set; }

        /// <summary>
        /// Human-readable description of the event. Persisted when the event is created (so the creating code, including a provider, can supply a tailored description) and otherwise derived from the event.
        /// </summary>
        [DataMember(Name = "event_description", IsRequired = false, EmitDefaultValue = false)]
        public override string? EventDescription { get; set; }

        /// <summary>
        /// ID of the event.
        /// </summary>
        [DataMember(Name = "event_id", IsRequired = false, EmitDefaultValue = false)]
        public override string EventId { get; set; }

        [DataMember(Name = "event_type", IsRequired = true, EmitDefaultValue = false)]
        public override string EventType { get; } = "action_attempt.unlock_door.succeeded";

        /// <summary>
        /// Date and time at which the event occurred.
        /// </summary>
        [DataMember(Name = "occurred_at", IsRequired = false, EmitDefaultValue = false)]
        public override string OccurredAt { get; set; }

        /// <summary>
        /// Status of the action.
        /// </summary>
        [DataMember(Name = "status", IsRequired = false, EmitDefaultValue = false)]
        public string Status { get; set; }

        /// <summary>
        /// ID of the workspace associated with the event.
        /// </summary>
        [DataMember(Name = "workspace_id", IsRequired = false, EmitDefaultValue = false)]
        public override string WorkspaceId { get; set; }

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
    /// An unlock door action attempt failed.
    /// </summary>
    [DataContract(Name = "seamModel_eventActionAttemptUnlockDoorFailed_model")]
    public class EventActionAttemptUnlockDoorFailed : Event
    {
        [JsonConstructorAttribute]
        protected EventActionAttemptUnlockDoorFailed() { }

        public EventActionAttemptUnlockDoorFailed(
            string actionAttemptId = default,
            string actionType = default,
            string? connectedAccountId = default,
            string createdAt = default,
            string? deviceId = default,
            string? eventDescription = default,
            string eventId = default,
            string eventType = default,
            string occurredAt = default,
            string status = default,
            string workspaceId = default
        )
        {
            ActionAttemptId = actionAttemptId;
            ActionType = actionType;
            ConnectedAccountId = connectedAccountId;
            CreatedAt = createdAt;
            DeviceId = deviceId;
            EventDescription = eventDescription;
            EventId = eventId;
            EventType = eventType;
            OccurredAt = occurredAt;
            Status = status;
            WorkspaceId = workspaceId;
        }

        /// <summary>
        /// ID of the affected action attempt.
        /// </summary>
        [DataMember(Name = "action_attempt_id", IsRequired = false, EmitDefaultValue = false)]
        public string ActionAttemptId { get; set; }

        /// <summary>
        /// Type of the action.
        /// </summary>
        [DataMember(Name = "action_type", IsRequired = false, EmitDefaultValue = false)]
        public string ActionType { get; set; }

        /// <summary>
        /// ID of the connected account associated with the action attempt, if applicable.
        /// </summary>
        [DataMember(Name = "connected_account_id", IsRequired = false, EmitDefaultValue = false)]
        public string? ConnectedAccountId { get; set; }

        /// <summary>
        /// Date and time at which the event was created.
        /// </summary>
        [DataMember(Name = "created_at", IsRequired = false, EmitDefaultValue = false)]
        public override string CreatedAt { get; set; }

        /// <summary>
        /// ID of the device associated with the action attempt, if applicable.
        /// </summary>
        [DataMember(Name = "device_id", IsRequired = false, EmitDefaultValue = false)]
        public string? DeviceId { get; set; }

        /// <summary>
        /// Human-readable description of the event. Persisted when the event is created (so the creating code, including a provider, can supply a tailored description) and otherwise derived from the event.
        /// </summary>
        [DataMember(Name = "event_description", IsRequired = false, EmitDefaultValue = false)]
        public override string? EventDescription { get; set; }

        /// <summary>
        /// ID of the event.
        /// </summary>
        [DataMember(Name = "event_id", IsRequired = false, EmitDefaultValue = false)]
        public override string EventId { get; set; }

        [DataMember(Name = "event_type", IsRequired = true, EmitDefaultValue = false)]
        public override string EventType { get; } = "action_attempt.unlock_door.failed";

        /// <summary>
        /// Date and time at which the event occurred.
        /// </summary>
        [DataMember(Name = "occurred_at", IsRequired = false, EmitDefaultValue = false)]
        public override string OccurredAt { get; set; }

        /// <summary>
        /// Status of the action.
        /// </summary>
        [DataMember(Name = "status", IsRequired = false, EmitDefaultValue = false)]
        public string Status { get; set; }

        /// <summary>
        /// ID of the workspace associated with the event.
        /// </summary>
        [DataMember(Name = "workspace_id", IsRequired = false, EmitDefaultValue = false)]
        public override string WorkspaceId { get; set; }

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
    /// A simulate keypad code entry action attempt succeeded.
    /// </summary>
    [DataContract(Name = "seamModel_eventActionAttemptSimulateKeypadCodeEntrySucceeded_model")]
    public class EventActionAttemptSimulateKeypadCodeEntrySucceeded : Event
    {
        [JsonConstructorAttribute]
        protected EventActionAttemptSimulateKeypadCodeEntrySucceeded() { }

        public EventActionAttemptSimulateKeypadCodeEntrySucceeded(
            string actionAttemptId = default,
            string actionType = default,
            string? connectedAccountId = default,
            string createdAt = default,
            string? deviceId = default,
            string? eventDescription = default,
            string eventId = default,
            string eventType = default,
            string occurredAt = default,
            string status = default,
            string workspaceId = default
        )
        {
            ActionAttemptId = actionAttemptId;
            ActionType = actionType;
            ConnectedAccountId = connectedAccountId;
            CreatedAt = createdAt;
            DeviceId = deviceId;
            EventDescription = eventDescription;
            EventId = eventId;
            EventType = eventType;
            OccurredAt = occurredAt;
            Status = status;
            WorkspaceId = workspaceId;
        }

        /// <summary>
        /// ID of the affected action attempt.
        /// </summary>
        [DataMember(Name = "action_attempt_id", IsRequired = false, EmitDefaultValue = false)]
        public string ActionAttemptId { get; set; }

        /// <summary>
        /// Type of the action.
        /// </summary>
        [DataMember(Name = "action_type", IsRequired = false, EmitDefaultValue = false)]
        public string ActionType { get; set; }

        /// <summary>
        /// ID of the connected account associated with the action attempt, if applicable.
        /// </summary>
        [DataMember(Name = "connected_account_id", IsRequired = false, EmitDefaultValue = false)]
        public string? ConnectedAccountId { get; set; }

        /// <summary>
        /// Date and time at which the event was created.
        /// </summary>
        [DataMember(Name = "created_at", IsRequired = false, EmitDefaultValue = false)]
        public override string CreatedAt { get; set; }

        /// <summary>
        /// ID of the device associated with the action attempt, if applicable.
        /// </summary>
        [DataMember(Name = "device_id", IsRequired = false, EmitDefaultValue = false)]
        public string? DeviceId { get; set; }

        /// <summary>
        /// Human-readable description of the event. Persisted when the event is created (so the creating code, including a provider, can supply a tailored description) and otherwise derived from the event.
        /// </summary>
        [DataMember(Name = "event_description", IsRequired = false, EmitDefaultValue = false)]
        public override string? EventDescription { get; set; }

        /// <summary>
        /// ID of the event.
        /// </summary>
        [DataMember(Name = "event_id", IsRequired = false, EmitDefaultValue = false)]
        public override string EventId { get; set; }

        [DataMember(Name = "event_type", IsRequired = true, EmitDefaultValue = false)]
        public override string EventType { get; } =
            "action_attempt.simulate_keypad_code_entry.succeeded";

        /// <summary>
        /// Date and time at which the event occurred.
        /// </summary>
        [DataMember(Name = "occurred_at", IsRequired = false, EmitDefaultValue = false)]
        public override string OccurredAt { get; set; }

        /// <summary>
        /// Status of the action.
        /// </summary>
        [DataMember(Name = "status", IsRequired = false, EmitDefaultValue = false)]
        public string Status { get; set; }

        /// <summary>
        /// ID of the workspace associated with the event.
        /// </summary>
        [DataMember(Name = "workspace_id", IsRequired = false, EmitDefaultValue = false)]
        public override string WorkspaceId { get; set; }

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
    /// A simulate keypad code entry action attempt failed.
    /// </summary>
    [DataContract(Name = "seamModel_eventActionAttemptSimulateKeypadCodeEntryFailed_model")]
    public class EventActionAttemptSimulateKeypadCodeEntryFailed : Event
    {
        [JsonConstructorAttribute]
        protected EventActionAttemptSimulateKeypadCodeEntryFailed() { }

        public EventActionAttemptSimulateKeypadCodeEntryFailed(
            string actionAttemptId = default,
            string actionType = default,
            string? connectedAccountId = default,
            string createdAt = default,
            string? deviceId = default,
            string? eventDescription = default,
            string eventId = default,
            string eventType = default,
            string occurredAt = default,
            string status = default,
            string workspaceId = default
        )
        {
            ActionAttemptId = actionAttemptId;
            ActionType = actionType;
            ConnectedAccountId = connectedAccountId;
            CreatedAt = createdAt;
            DeviceId = deviceId;
            EventDescription = eventDescription;
            EventId = eventId;
            EventType = eventType;
            OccurredAt = occurredAt;
            Status = status;
            WorkspaceId = workspaceId;
        }

        /// <summary>
        /// ID of the affected action attempt.
        /// </summary>
        [DataMember(Name = "action_attempt_id", IsRequired = false, EmitDefaultValue = false)]
        public string ActionAttemptId { get; set; }

        /// <summary>
        /// Type of the action.
        /// </summary>
        [DataMember(Name = "action_type", IsRequired = false, EmitDefaultValue = false)]
        public string ActionType { get; set; }

        /// <summary>
        /// ID of the connected account associated with the action attempt, if applicable.
        /// </summary>
        [DataMember(Name = "connected_account_id", IsRequired = false, EmitDefaultValue = false)]
        public string? ConnectedAccountId { get; set; }

        /// <summary>
        /// Date and time at which the event was created.
        /// </summary>
        [DataMember(Name = "created_at", IsRequired = false, EmitDefaultValue = false)]
        public override string CreatedAt { get; set; }

        /// <summary>
        /// ID of the device associated with the action attempt, if applicable.
        /// </summary>
        [DataMember(Name = "device_id", IsRequired = false, EmitDefaultValue = false)]
        public string? DeviceId { get; set; }

        /// <summary>
        /// Human-readable description of the event. Persisted when the event is created (so the creating code, including a provider, can supply a tailored description) and otherwise derived from the event.
        /// </summary>
        [DataMember(Name = "event_description", IsRequired = false, EmitDefaultValue = false)]
        public override string? EventDescription { get; set; }

        /// <summary>
        /// ID of the event.
        /// </summary>
        [DataMember(Name = "event_id", IsRequired = false, EmitDefaultValue = false)]
        public override string EventId { get; set; }

        [DataMember(Name = "event_type", IsRequired = true, EmitDefaultValue = false)]
        public override string EventType { get; } =
            "action_attempt.simulate_keypad_code_entry.failed";

        /// <summary>
        /// Date and time at which the event occurred.
        /// </summary>
        [DataMember(Name = "occurred_at", IsRequired = false, EmitDefaultValue = false)]
        public override string OccurredAt { get; set; }

        /// <summary>
        /// Status of the action.
        /// </summary>
        [DataMember(Name = "status", IsRequired = false, EmitDefaultValue = false)]
        public string Status { get; set; }

        /// <summary>
        /// ID of the workspace associated with the event.
        /// </summary>
        [DataMember(Name = "workspace_id", IsRequired = false, EmitDefaultValue = false)]
        public override string WorkspaceId { get; set; }

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
    /// A simulate manual lock via keypad action attempt succeeded.
    /// </summary>
    [DataContract(Name = "seamModel_eventActionAttemptSimulateManualLockViaKeypadSucceeded_model")]
    public class EventActionAttemptSimulateManualLockViaKeypadSucceeded : Event
    {
        [JsonConstructorAttribute]
        protected EventActionAttemptSimulateManualLockViaKeypadSucceeded() { }

        public EventActionAttemptSimulateManualLockViaKeypadSucceeded(
            string actionAttemptId = default,
            string actionType = default,
            string? connectedAccountId = default,
            string createdAt = default,
            string? deviceId = default,
            string? eventDescription = default,
            string eventId = default,
            string eventType = default,
            string occurredAt = default,
            string status = default,
            string workspaceId = default
        )
        {
            ActionAttemptId = actionAttemptId;
            ActionType = actionType;
            ConnectedAccountId = connectedAccountId;
            CreatedAt = createdAt;
            DeviceId = deviceId;
            EventDescription = eventDescription;
            EventId = eventId;
            EventType = eventType;
            OccurredAt = occurredAt;
            Status = status;
            WorkspaceId = workspaceId;
        }

        /// <summary>
        /// ID of the affected action attempt.
        /// </summary>
        [DataMember(Name = "action_attempt_id", IsRequired = false, EmitDefaultValue = false)]
        public string ActionAttemptId { get; set; }

        /// <summary>
        /// Type of the action.
        /// </summary>
        [DataMember(Name = "action_type", IsRequired = false, EmitDefaultValue = false)]
        public string ActionType { get; set; }

        /// <summary>
        /// ID of the connected account associated with the action attempt, if applicable.
        /// </summary>
        [DataMember(Name = "connected_account_id", IsRequired = false, EmitDefaultValue = false)]
        public string? ConnectedAccountId { get; set; }

        /// <summary>
        /// Date and time at which the event was created.
        /// </summary>
        [DataMember(Name = "created_at", IsRequired = false, EmitDefaultValue = false)]
        public override string CreatedAt { get; set; }

        /// <summary>
        /// ID of the device associated with the action attempt, if applicable.
        /// </summary>
        [DataMember(Name = "device_id", IsRequired = false, EmitDefaultValue = false)]
        public string? DeviceId { get; set; }

        /// <summary>
        /// Human-readable description of the event. Persisted when the event is created (so the creating code, including a provider, can supply a tailored description) and otherwise derived from the event.
        /// </summary>
        [DataMember(Name = "event_description", IsRequired = false, EmitDefaultValue = false)]
        public override string? EventDescription { get; set; }

        /// <summary>
        /// ID of the event.
        /// </summary>
        [DataMember(Name = "event_id", IsRequired = false, EmitDefaultValue = false)]
        public override string EventId { get; set; }

        [DataMember(Name = "event_type", IsRequired = true, EmitDefaultValue = false)]
        public override string EventType { get; } =
            "action_attempt.simulate_manual_lock_via_keypad.succeeded";

        /// <summary>
        /// Date and time at which the event occurred.
        /// </summary>
        [DataMember(Name = "occurred_at", IsRequired = false, EmitDefaultValue = false)]
        public override string OccurredAt { get; set; }

        /// <summary>
        /// Status of the action.
        /// </summary>
        [DataMember(Name = "status", IsRequired = false, EmitDefaultValue = false)]
        public string Status { get; set; }

        /// <summary>
        /// ID of the workspace associated with the event.
        /// </summary>
        [DataMember(Name = "workspace_id", IsRequired = false, EmitDefaultValue = false)]
        public override string WorkspaceId { get; set; }

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
    /// A simulate manual lock via keypad action attempt failed.
    /// </summary>
    [DataContract(Name = "seamModel_eventActionAttemptSimulateManualLockViaKeypadFailed_model")]
    public class EventActionAttemptSimulateManualLockViaKeypadFailed : Event
    {
        [JsonConstructorAttribute]
        protected EventActionAttemptSimulateManualLockViaKeypadFailed() { }

        public EventActionAttemptSimulateManualLockViaKeypadFailed(
            string actionAttemptId = default,
            string actionType = default,
            string? connectedAccountId = default,
            string createdAt = default,
            string? deviceId = default,
            string? eventDescription = default,
            string eventId = default,
            string eventType = default,
            string occurredAt = default,
            string status = default,
            string workspaceId = default
        )
        {
            ActionAttemptId = actionAttemptId;
            ActionType = actionType;
            ConnectedAccountId = connectedAccountId;
            CreatedAt = createdAt;
            DeviceId = deviceId;
            EventDescription = eventDescription;
            EventId = eventId;
            EventType = eventType;
            OccurredAt = occurredAt;
            Status = status;
            WorkspaceId = workspaceId;
        }

        /// <summary>
        /// ID of the affected action attempt.
        /// </summary>
        [DataMember(Name = "action_attempt_id", IsRequired = false, EmitDefaultValue = false)]
        public string ActionAttemptId { get; set; }

        /// <summary>
        /// Type of the action.
        /// </summary>
        [DataMember(Name = "action_type", IsRequired = false, EmitDefaultValue = false)]
        public string ActionType { get; set; }

        /// <summary>
        /// ID of the connected account associated with the action attempt, if applicable.
        /// </summary>
        [DataMember(Name = "connected_account_id", IsRequired = false, EmitDefaultValue = false)]
        public string? ConnectedAccountId { get; set; }

        /// <summary>
        /// Date and time at which the event was created.
        /// </summary>
        [DataMember(Name = "created_at", IsRequired = false, EmitDefaultValue = false)]
        public override string CreatedAt { get; set; }

        /// <summary>
        /// ID of the device associated with the action attempt, if applicable.
        /// </summary>
        [DataMember(Name = "device_id", IsRequired = false, EmitDefaultValue = false)]
        public string? DeviceId { get; set; }

        /// <summary>
        /// Human-readable description of the event. Persisted when the event is created (so the creating code, including a provider, can supply a tailored description) and otherwise derived from the event.
        /// </summary>
        [DataMember(Name = "event_description", IsRequired = false, EmitDefaultValue = false)]
        public override string? EventDescription { get; set; }

        /// <summary>
        /// ID of the event.
        /// </summary>
        [DataMember(Name = "event_id", IsRequired = false, EmitDefaultValue = false)]
        public override string EventId { get; set; }

        [DataMember(Name = "event_type", IsRequired = true, EmitDefaultValue = false)]
        public override string EventType { get; } =
            "action_attempt.simulate_manual_lock_via_keypad.failed";

        /// <summary>
        /// Date and time at which the event occurred.
        /// </summary>
        [DataMember(Name = "occurred_at", IsRequired = false, EmitDefaultValue = false)]
        public override string OccurredAt { get; set; }

        /// <summary>
        /// Status of the action.
        /// </summary>
        [DataMember(Name = "status", IsRequired = false, EmitDefaultValue = false)]
        public string Status { get; set; }

        /// <summary>
        /// ID of the workspace associated with the event.
        /// </summary>
        [DataMember(Name = "workspace_id", IsRequired = false, EmitDefaultValue = false)]
        public override string WorkspaceId { get; set; }

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
    /// A Connect Webview login succeeded.
    /// </summary>
    [DataContract(Name = "seamModel_eventConnectWebviewLoginSucceeded_model")]
    public class EventConnectWebviewLoginSucceeded : Event
    {
        [JsonConstructorAttribute]
        protected EventConnectWebviewLoginSucceeded() { }

        public EventConnectWebviewLoginSucceeded(
            string connectWebviewId = default,
            object? connectedAccountCustomMetadata = default,
            string connectedAccountId = default,
            string createdAt = default,
            string? customerKey = default,
            string? eventDescription = default,
            string eventId = default,
            string eventType = default,
            string occurredAt = default,
            string workspaceId = default
        )
        {
            ConnectWebviewId = connectWebviewId;
            ConnectedAccountCustomMetadata = connectedAccountCustomMetadata;
            ConnectedAccountId = connectedAccountId;
            CreatedAt = createdAt;
            CustomerKey = customerKey;
            EventDescription = eventDescription;
            EventId = eventId;
            EventType = eventType;
            OccurredAt = occurredAt;
            WorkspaceId = workspaceId;
        }

        /// <summary>
        /// ID of the affected Connect Webview.
        /// </summary>
        [DataMember(Name = "connect_webview_id", IsRequired = false, EmitDefaultValue = false)]
        public string ConnectWebviewId { get; set; }

        /// <summary>
        /// Custom metadata of the connected account; present when connected_account_id is provided.
        /// </summary>
        [DataMember(
            Name = "connected_account_custom_metadata",
            IsRequired = false,
            EmitDefaultValue = false
        )]
        public object? ConnectedAccountCustomMetadata { get; set; }

        /// <summary>
        /// ID of the connected account associated with the event.
        /// </summary>
        [DataMember(Name = "connected_account_id", IsRequired = false, EmitDefaultValue = false)]
        public string ConnectedAccountId { get; set; }

        /// <summary>
        /// Date and time at which the event was created.
        /// </summary>
        [DataMember(Name = "created_at", IsRequired = false, EmitDefaultValue = false)]
        public override string CreatedAt { get; set; }

        /// <summary>
        /// The customer key associated with this connect webview, if any.
        /// </summary>
        [DataMember(Name = "customer_key", IsRequired = false, EmitDefaultValue = false)]
        public string? CustomerKey { get; set; }

        /// <summary>
        /// Human-readable description of the event. Persisted when the event is created (so the creating code, including a provider, can supply a tailored description) and otherwise derived from the event.
        /// </summary>
        [DataMember(Name = "event_description", IsRequired = false, EmitDefaultValue = false)]
        public override string? EventDescription { get; set; }

        /// <summary>
        /// ID of the event.
        /// </summary>
        [DataMember(Name = "event_id", IsRequired = false, EmitDefaultValue = false)]
        public override string EventId { get; set; }

        [DataMember(Name = "event_type", IsRequired = true, EmitDefaultValue = false)]
        public override string EventType { get; } = "connect_webview.login_succeeded";

        /// <summary>
        /// Date and time at which the event occurred.
        /// </summary>
        [DataMember(Name = "occurred_at", IsRequired = false, EmitDefaultValue = false)]
        public override string OccurredAt { get; set; }

        /// <summary>
        /// ID of the workspace associated with the event.
        /// </summary>
        [DataMember(Name = "workspace_id", IsRequired = false, EmitDefaultValue = false)]
        public override string WorkspaceId { get; set; }

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
    /// A Connect Webview login failed.
    /// </summary>
    [DataContract(Name = "seamModel_eventConnectWebviewLoginFailed_model")]
    public class EventConnectWebviewLoginFailed : Event
    {
        [JsonConstructorAttribute]
        protected EventConnectWebviewLoginFailed() { }

        public EventConnectWebviewLoginFailed(
            string connectWebviewId = default,
            string createdAt = default,
            string? eventDescription = default,
            string eventId = default,
            string eventType = default,
            string occurredAt = default,
            string workspaceId = default
        )
        {
            ConnectWebviewId = connectWebviewId;
            CreatedAt = createdAt;
            EventDescription = eventDescription;
            EventId = eventId;
            EventType = eventType;
            OccurredAt = occurredAt;
            WorkspaceId = workspaceId;
        }

        /// <summary>
        /// ID of the affected Connect Webview.
        /// </summary>
        [DataMember(Name = "connect_webview_id", IsRequired = false, EmitDefaultValue = false)]
        public string ConnectWebviewId { get; set; }

        /// <summary>
        /// Date and time at which the event was created.
        /// </summary>
        [DataMember(Name = "created_at", IsRequired = false, EmitDefaultValue = false)]
        public override string CreatedAt { get; set; }

        /// <summary>
        /// Human-readable description of the event. Persisted when the event is created (so the creating code, including a provider, can supply a tailored description) and otherwise derived from the event.
        /// </summary>
        [DataMember(Name = "event_description", IsRequired = false, EmitDefaultValue = false)]
        public override string? EventDescription { get; set; }

        /// <summary>
        /// ID of the event.
        /// </summary>
        [DataMember(Name = "event_id", IsRequired = false, EmitDefaultValue = false)]
        public override string EventId { get; set; }

        [DataMember(Name = "event_type", IsRequired = true, EmitDefaultValue = false)]
        public override string EventType { get; } = "connect_webview.login_failed";

        /// <summary>
        /// Date and time at which the event occurred.
        /// </summary>
        [DataMember(Name = "occurred_at", IsRequired = false, EmitDefaultValue = false)]
        public override string OccurredAt { get; set; }

        /// <summary>
        /// ID of the workspace associated with the event.
        /// </summary>
        [DataMember(Name = "workspace_id", IsRequired = false, EmitDefaultValue = false)]
        public override string WorkspaceId { get; set; }

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
    /// The status of a device changed from offline to online. That is, the `device.properties.online` property changed from `false` to `true`. Note that some devices operate entirely in offline mode, so Seam never emits a `device.connected` event for these devices.
    /// </summary>
    [DataContract(Name = "seamModel_eventDeviceConnected_model")]
    public class EventDeviceConnected : Event
    {
        [JsonConstructorAttribute]
        protected EventDeviceConnected() { }

        public EventDeviceConnected(
            object? connectedAccountCustomMetadata = default,
            string connectedAccountId = default,
            string createdAt = default,
            string? customerKey = default,
            object? deviceCustomMetadata = default,
            string deviceId = default,
            string? eventDescription = default,
            string eventId = default,
            string eventType = default,
            string occurredAt = default,
            string workspaceId = default
        )
        {
            ConnectedAccountCustomMetadata = connectedAccountCustomMetadata;
            ConnectedAccountId = connectedAccountId;
            CreatedAt = createdAt;
            CustomerKey = customerKey;
            DeviceCustomMetadata = deviceCustomMetadata;
            DeviceId = deviceId;
            EventDescription = eventDescription;
            EventId = eventId;
            EventType = eventType;
            OccurredAt = occurredAt;
            WorkspaceId = workspaceId;
        }

        /// <summary>
        /// Custom metadata of the connected account, present when connected_account_id is provided.
        /// </summary>
        [DataMember(
            Name = "connected_account_custom_metadata",
            IsRequired = false,
            EmitDefaultValue = false
        )]
        public object? ConnectedAccountCustomMetadata { get; set; }

        /// <summary>
        /// ID of the connected account associated with the event.
        /// </summary>
        [DataMember(Name = "connected_account_id", IsRequired = false, EmitDefaultValue = false)]
        public string ConnectedAccountId { get; set; }

        /// <summary>
        /// Date and time at which the event was created.
        /// </summary>
        [DataMember(Name = "created_at", IsRequired = false, EmitDefaultValue = false)]
        public override string CreatedAt { get; set; }

        /// <summary>
        /// The customer key associated with the device, if any.
        /// </summary>
        [DataMember(Name = "customer_key", IsRequired = false, EmitDefaultValue = false)]
        public string? CustomerKey { get; set; }

        /// <summary>
        /// Custom metadata of the device, present when device_id is provided.
        /// </summary>
        [DataMember(Name = "device_custom_metadata", IsRequired = false, EmitDefaultValue = false)]
        public object? DeviceCustomMetadata { get; set; }

        /// <summary>
        /// ID of the affected device.
        /// </summary>
        [DataMember(Name = "device_id", IsRequired = false, EmitDefaultValue = false)]
        public string DeviceId { get; set; }

        /// <summary>
        /// Human-readable description of the event. Persisted when the event is created (so the creating code, including a provider, can supply a tailored description) and otherwise derived from the event.
        /// </summary>
        [DataMember(Name = "event_description", IsRequired = false, EmitDefaultValue = false)]
        public override string? EventDescription { get; set; }

        /// <summary>
        /// ID of the event.
        /// </summary>
        [DataMember(Name = "event_id", IsRequired = false, EmitDefaultValue = false)]
        public override string EventId { get; set; }

        [DataMember(Name = "event_type", IsRequired = true, EmitDefaultValue = false)]
        public override string EventType { get; } = "device.connected";

        /// <summary>
        /// Date and time at which the event occurred.
        /// </summary>
        [DataMember(Name = "occurred_at", IsRequired = false, EmitDefaultValue = false)]
        public override string OccurredAt { get; set; }

        /// <summary>
        /// ID of the workspace associated with the event.
        /// </summary>
        [DataMember(Name = "workspace_id", IsRequired = false, EmitDefaultValue = false)]
        public override string WorkspaceId { get; set; }

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
    /// A device was added to Seam or was re-added to Seam after having been removed.
    /// </summary>
    [DataContract(Name = "seamModel_eventDeviceAdded_model")]
    public class EventDeviceAdded : Event
    {
        [JsonConstructorAttribute]
        protected EventDeviceAdded() { }

        public EventDeviceAdded(
            object? connectedAccountCustomMetadata = default,
            string connectedAccountId = default,
            string createdAt = default,
            string? customerKey = default,
            object? deviceCustomMetadata = default,
            string deviceId = default,
            string? eventDescription = default,
            string eventId = default,
            string eventType = default,
            string occurredAt = default,
            string workspaceId = default
        )
        {
            ConnectedAccountCustomMetadata = connectedAccountCustomMetadata;
            ConnectedAccountId = connectedAccountId;
            CreatedAt = createdAt;
            CustomerKey = customerKey;
            DeviceCustomMetadata = deviceCustomMetadata;
            DeviceId = deviceId;
            EventDescription = eventDescription;
            EventId = eventId;
            EventType = eventType;
            OccurredAt = occurredAt;
            WorkspaceId = workspaceId;
        }

        /// <summary>
        /// Custom metadata of the connected account, present when connected_account_id is provided.
        /// </summary>
        [DataMember(
            Name = "connected_account_custom_metadata",
            IsRequired = false,
            EmitDefaultValue = false
        )]
        public object? ConnectedAccountCustomMetadata { get; set; }

        /// <summary>
        /// ID of the connected account associated with the event.
        /// </summary>
        [DataMember(Name = "connected_account_id", IsRequired = false, EmitDefaultValue = false)]
        public string ConnectedAccountId { get; set; }

        /// <summary>
        /// Date and time at which the event was created.
        /// </summary>
        [DataMember(Name = "created_at", IsRequired = false, EmitDefaultValue = false)]
        public override string CreatedAt { get; set; }

        /// <summary>
        /// The customer key associated with the device, if any.
        /// </summary>
        [DataMember(Name = "customer_key", IsRequired = false, EmitDefaultValue = false)]
        public string? CustomerKey { get; set; }

        /// <summary>
        /// Custom metadata of the device, present when device_id is provided.
        /// </summary>
        [DataMember(Name = "device_custom_metadata", IsRequired = false, EmitDefaultValue = false)]
        public object? DeviceCustomMetadata { get; set; }

        /// <summary>
        /// ID of the affected device.
        /// </summary>
        [DataMember(Name = "device_id", IsRequired = false, EmitDefaultValue = false)]
        public string DeviceId { get; set; }

        /// <summary>
        /// Human-readable description of the event. Persisted when the event is created (so the creating code, including a provider, can supply a tailored description) and otherwise derived from the event.
        /// </summary>
        [DataMember(Name = "event_description", IsRequired = false, EmitDefaultValue = false)]
        public override string? EventDescription { get; set; }

        /// <summary>
        /// ID of the event.
        /// </summary>
        [DataMember(Name = "event_id", IsRequired = false, EmitDefaultValue = false)]
        public override string EventId { get; set; }

        [DataMember(Name = "event_type", IsRequired = true, EmitDefaultValue = false)]
        public override string EventType { get; } = "device.added";

        /// <summary>
        /// Date and time at which the event occurred.
        /// </summary>
        [DataMember(Name = "occurred_at", IsRequired = false, EmitDefaultValue = false)]
        public override string OccurredAt { get; set; }

        /// <summary>
        /// ID of the workspace associated with the event.
        /// </summary>
        [DataMember(Name = "workspace_id", IsRequired = false, EmitDefaultValue = false)]
        public override string WorkspaceId { get; set; }

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
    /// A managed device was successfully converted to an [unmanaged device](https://docs.seam.co/core-concepts/devices/managed-and-unmanaged-devices).
    /// </summary>
    [DataContract(Name = "seamModel_eventDeviceConvertedToUnmanaged_model")]
    public class EventDeviceConvertedToUnmanaged : Event
    {
        [JsonConstructorAttribute]
        protected EventDeviceConvertedToUnmanaged() { }

        public EventDeviceConvertedToUnmanaged(
            object? connectedAccountCustomMetadata = default,
            string connectedAccountId = default,
            string createdAt = default,
            string? customerKey = default,
            object? deviceCustomMetadata = default,
            string deviceId = default,
            string? eventDescription = default,
            string eventId = default,
            string eventType = default,
            string occurredAt = default,
            string workspaceId = default
        )
        {
            ConnectedAccountCustomMetadata = connectedAccountCustomMetadata;
            ConnectedAccountId = connectedAccountId;
            CreatedAt = createdAt;
            CustomerKey = customerKey;
            DeviceCustomMetadata = deviceCustomMetadata;
            DeviceId = deviceId;
            EventDescription = eventDescription;
            EventId = eventId;
            EventType = eventType;
            OccurredAt = occurredAt;
            WorkspaceId = workspaceId;
        }

        /// <summary>
        /// Custom metadata of the connected account, present when connected_account_id is provided.
        /// </summary>
        [DataMember(
            Name = "connected_account_custom_metadata",
            IsRequired = false,
            EmitDefaultValue = false
        )]
        public object? ConnectedAccountCustomMetadata { get; set; }

        /// <summary>
        /// ID of the connected account associated with the event.
        /// </summary>
        [DataMember(Name = "connected_account_id", IsRequired = false, EmitDefaultValue = false)]
        public string ConnectedAccountId { get; set; }

        /// <summary>
        /// Date and time at which the event was created.
        /// </summary>
        [DataMember(Name = "created_at", IsRequired = false, EmitDefaultValue = false)]
        public override string CreatedAt { get; set; }

        /// <summary>
        /// The customer key associated with the device, if any.
        /// </summary>
        [DataMember(Name = "customer_key", IsRequired = false, EmitDefaultValue = false)]
        public string? CustomerKey { get; set; }

        /// <summary>
        /// Custom metadata of the device, present when device_id is provided.
        /// </summary>
        [DataMember(Name = "device_custom_metadata", IsRequired = false, EmitDefaultValue = false)]
        public object? DeviceCustomMetadata { get; set; }

        /// <summary>
        /// ID of the affected device.
        /// </summary>
        [DataMember(Name = "device_id", IsRequired = false, EmitDefaultValue = false)]
        public string DeviceId { get; set; }

        /// <summary>
        /// Human-readable description of the event. Persisted when the event is created (so the creating code, including a provider, can supply a tailored description) and otherwise derived from the event.
        /// </summary>
        [DataMember(Name = "event_description", IsRequired = false, EmitDefaultValue = false)]
        public override string? EventDescription { get; set; }

        /// <summary>
        /// ID of the event.
        /// </summary>
        [DataMember(Name = "event_id", IsRequired = false, EmitDefaultValue = false)]
        public override string EventId { get; set; }

        [DataMember(Name = "event_type", IsRequired = true, EmitDefaultValue = false)]
        public override string EventType { get; } = "device.converted_to_unmanaged";

        /// <summary>
        /// Date and time at which the event occurred.
        /// </summary>
        [DataMember(Name = "occurred_at", IsRequired = false, EmitDefaultValue = false)]
        public override string OccurredAt { get; set; }

        /// <summary>
        /// ID of the workspace associated with the event.
        /// </summary>
        [DataMember(Name = "workspace_id", IsRequired = false, EmitDefaultValue = false)]
        public override string WorkspaceId { get; set; }

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
    /// An [unmanaged device](https://docs.seam.co/core-concepts/devices/managed-and-unmanaged-devices) was successfully converted to a managed device.
    /// </summary>
    [DataContract(Name = "seamModel_eventDeviceUnmanagedConvertedToManaged_model")]
    public class EventDeviceUnmanagedConvertedToManaged : Event
    {
        [JsonConstructorAttribute]
        protected EventDeviceUnmanagedConvertedToManaged() { }

        public EventDeviceUnmanagedConvertedToManaged(
            object? connectedAccountCustomMetadata = default,
            string connectedAccountId = default,
            string createdAt = default,
            string? customerKey = default,
            object? deviceCustomMetadata = default,
            string deviceId = default,
            string? eventDescription = default,
            string eventId = default,
            string eventType = default,
            string occurredAt = default,
            string workspaceId = default
        )
        {
            ConnectedAccountCustomMetadata = connectedAccountCustomMetadata;
            ConnectedAccountId = connectedAccountId;
            CreatedAt = createdAt;
            CustomerKey = customerKey;
            DeviceCustomMetadata = deviceCustomMetadata;
            DeviceId = deviceId;
            EventDescription = eventDescription;
            EventId = eventId;
            EventType = eventType;
            OccurredAt = occurredAt;
            WorkspaceId = workspaceId;
        }

        /// <summary>
        /// Custom metadata of the connected account, present when connected_account_id is provided.
        /// </summary>
        [DataMember(
            Name = "connected_account_custom_metadata",
            IsRequired = false,
            EmitDefaultValue = false
        )]
        public object? ConnectedAccountCustomMetadata { get; set; }

        /// <summary>
        /// ID of the connected account associated with the event.
        /// </summary>
        [DataMember(Name = "connected_account_id", IsRequired = false, EmitDefaultValue = false)]
        public string ConnectedAccountId { get; set; }

        /// <summary>
        /// Date and time at which the event was created.
        /// </summary>
        [DataMember(Name = "created_at", IsRequired = false, EmitDefaultValue = false)]
        public override string CreatedAt { get; set; }

        /// <summary>
        /// The customer key associated with the device, if any.
        /// </summary>
        [DataMember(Name = "customer_key", IsRequired = false, EmitDefaultValue = false)]
        public string? CustomerKey { get; set; }

        /// <summary>
        /// Custom metadata of the device, present when device_id is provided.
        /// </summary>
        [DataMember(Name = "device_custom_metadata", IsRequired = false, EmitDefaultValue = false)]
        public object? DeviceCustomMetadata { get; set; }

        /// <summary>
        /// ID of the affected device.
        /// </summary>
        [DataMember(Name = "device_id", IsRequired = false, EmitDefaultValue = false)]
        public string DeviceId { get; set; }

        /// <summary>
        /// Human-readable description of the event. Persisted when the event is created (so the creating code, including a provider, can supply a tailored description) and otherwise derived from the event.
        /// </summary>
        [DataMember(Name = "event_description", IsRequired = false, EmitDefaultValue = false)]
        public override string? EventDescription { get; set; }

        /// <summary>
        /// ID of the event.
        /// </summary>
        [DataMember(Name = "event_id", IsRequired = false, EmitDefaultValue = false)]
        public override string EventId { get; set; }

        [DataMember(Name = "event_type", IsRequired = true, EmitDefaultValue = false)]
        public override string EventType { get; } = "device.unmanaged.converted_to_managed";

        /// <summary>
        /// Date and time at which the event occurred.
        /// </summary>
        [DataMember(Name = "occurred_at", IsRequired = false, EmitDefaultValue = false)]
        public override string OccurredAt { get; set; }

        /// <summary>
        /// ID of the workspace associated with the event.
        /// </summary>
        [DataMember(Name = "workspace_id", IsRequired = false, EmitDefaultValue = false)]
        public override string WorkspaceId { get; set; }

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
    /// The status of an [unmanaged device](https://docs.seam.co/core-concepts/devices/managed-and-unmanaged-devices) changed from offline to online. That is, the `device.properties.online` property changed from `false` to `true`.
    /// </summary>
    [DataContract(Name = "seamModel_eventDeviceUnmanagedConnected_model")]
    public class EventDeviceUnmanagedConnected : Event
    {
        [JsonConstructorAttribute]
        protected EventDeviceUnmanagedConnected() { }

        public EventDeviceUnmanagedConnected(
            object? connectedAccountCustomMetadata = default,
            string connectedAccountId = default,
            string createdAt = default,
            string? customerKey = default,
            object? deviceCustomMetadata = default,
            string deviceId = default,
            string? eventDescription = default,
            string eventId = default,
            string eventType = default,
            string occurredAt = default,
            string workspaceId = default
        )
        {
            ConnectedAccountCustomMetadata = connectedAccountCustomMetadata;
            ConnectedAccountId = connectedAccountId;
            CreatedAt = createdAt;
            CustomerKey = customerKey;
            DeviceCustomMetadata = deviceCustomMetadata;
            DeviceId = deviceId;
            EventDescription = eventDescription;
            EventId = eventId;
            EventType = eventType;
            OccurredAt = occurredAt;
            WorkspaceId = workspaceId;
        }

        /// <summary>
        /// Custom metadata of the connected account, present when connected_account_id is provided.
        /// </summary>
        [DataMember(
            Name = "connected_account_custom_metadata",
            IsRequired = false,
            EmitDefaultValue = false
        )]
        public object? ConnectedAccountCustomMetadata { get; set; }

        /// <summary>
        /// ID of the connected account associated with the event.
        /// </summary>
        [DataMember(Name = "connected_account_id", IsRequired = false, EmitDefaultValue = false)]
        public string ConnectedAccountId { get; set; }

        /// <summary>
        /// Date and time at which the event was created.
        /// </summary>
        [DataMember(Name = "created_at", IsRequired = false, EmitDefaultValue = false)]
        public override string CreatedAt { get; set; }

        /// <summary>
        /// The customer key associated with the device, if any.
        /// </summary>
        [DataMember(Name = "customer_key", IsRequired = false, EmitDefaultValue = false)]
        public string? CustomerKey { get; set; }

        /// <summary>
        /// Custom metadata of the device, present when device_id is provided.
        /// </summary>
        [DataMember(Name = "device_custom_metadata", IsRequired = false, EmitDefaultValue = false)]
        public object? DeviceCustomMetadata { get; set; }

        /// <summary>
        /// ID of the affected device.
        /// </summary>
        [DataMember(Name = "device_id", IsRequired = false, EmitDefaultValue = false)]
        public string DeviceId { get; set; }

        /// <summary>
        /// Human-readable description of the event. Persisted when the event is created (so the creating code, including a provider, can supply a tailored description) and otherwise derived from the event.
        /// </summary>
        [DataMember(Name = "event_description", IsRequired = false, EmitDefaultValue = false)]
        public override string? EventDescription { get; set; }

        /// <summary>
        /// ID of the event.
        /// </summary>
        [DataMember(Name = "event_id", IsRequired = false, EmitDefaultValue = false)]
        public override string EventId { get; set; }

        [DataMember(Name = "event_type", IsRequired = true, EmitDefaultValue = false)]
        public override string EventType { get; } = "device.unmanaged.connected";

        /// <summary>
        /// Date and time at which the event occurred.
        /// </summary>
        [DataMember(Name = "occurred_at", IsRequired = false, EmitDefaultValue = false)]
        public override string OccurredAt { get; set; }

        /// <summary>
        /// ID of the workspace associated with the event.
        /// </summary>
        [DataMember(Name = "workspace_id", IsRequired = false, EmitDefaultValue = false)]
        public override string WorkspaceId { get; set; }

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
    /// The status of a device changed from online to offline. That is, the `device.properties.online` property changed from `true` to `false`.
    /// </summary>
    [DataContract(Name = "seamModel_eventDeviceDisconnected_model")]
    public class EventDeviceDisconnected : Event
    {
        [JsonConstructorAttribute]
        protected EventDeviceDisconnected() { }

        public EventDeviceDisconnected(
            object? connectedAccountCustomMetadata = default,
            List<EventDeviceDisconnectedConnectedAccountErrors> connectedAccountErrors = default,
            string connectedAccountId = default,
            List<EventDeviceDisconnectedConnectedAccountWarnings> connectedAccountWarnings =
                default,
            string createdAt = default,
            string? customerKey = default,
            object? deviceCustomMetadata = default,
            List<EventDeviceDisconnectedDeviceErrors> deviceErrors = default,
            string deviceId = default,
            List<EventDeviceDisconnectedDeviceWarnings> deviceWarnings = default,
            EventDeviceDisconnected.ErrorCodeEnum errorCode = default,
            string? eventDescription = default,
            string eventId = default,
            string eventType = default,
            string occurredAt = default,
            string workspaceId = default
        )
        {
            ConnectedAccountCustomMetadata = connectedAccountCustomMetadata;
            ConnectedAccountErrors = connectedAccountErrors;
            ConnectedAccountId = connectedAccountId;
            ConnectedAccountWarnings = connectedAccountWarnings;
            CreatedAt = createdAt;
            CustomerKey = customerKey;
            DeviceCustomMetadata = deviceCustomMetadata;
            DeviceErrors = deviceErrors;
            DeviceId = deviceId;
            DeviceWarnings = deviceWarnings;
            ErrorCode = errorCode;
            EventDescription = eventDescription;
            EventId = eventId;
            EventType = eventType;
            OccurredAt = occurredAt;
            WorkspaceId = workspaceId;
        }

        /// <summary>
        /// Error code associated with the disconnection event, if any.
        /// </summary>
        [JsonConverter(typeof(SafeStringEnumConverter))]
        public enum ErrorCodeEnum
        {
            [EnumMember(Value = "unrecognized")]
            Unrecognized = 0,

            [EnumMember(Value = "account_disconnected")]
            AccountDisconnected = 1,

            [EnumMember(Value = "hub_disconnected")]
            HubDisconnected = 2,

            [EnumMember(Value = "device_disconnected")]
            DeviceDisconnected = 3,
        }

        /// <summary>
        /// Custom metadata of the connected account, present when connected_account_id is provided.
        /// </summary>
        [DataMember(
            Name = "connected_account_custom_metadata",
            IsRequired = false,
            EmitDefaultValue = false
        )]
        public object? ConnectedAccountCustomMetadata { get; set; }

        /// <summary>
        /// Errors associated with the connected account.
        /// </summary>
        [DataMember(
            Name = "connected_account_errors",
            IsRequired = false,
            EmitDefaultValue = false
        )]
        public List<EventDeviceDisconnectedConnectedAccountErrors> ConnectedAccountErrors { get; set; }

        /// <summary>
        /// ID of the connected account associated with the event.
        /// </summary>
        [DataMember(Name = "connected_account_id", IsRequired = false, EmitDefaultValue = false)]
        public string ConnectedAccountId { get; set; }

        /// <summary>
        /// Warnings associated with the connected account.
        /// </summary>
        [DataMember(
            Name = "connected_account_warnings",
            IsRequired = false,
            EmitDefaultValue = false
        )]
        public List<EventDeviceDisconnectedConnectedAccountWarnings> ConnectedAccountWarnings { get; set; }

        /// <summary>
        /// Date and time at which the event was created.
        /// </summary>
        [DataMember(Name = "created_at", IsRequired = false, EmitDefaultValue = false)]
        public override string CreatedAt { get; set; }

        /// <summary>
        /// The customer key associated with the device, if any.
        /// </summary>
        [DataMember(Name = "customer_key", IsRequired = false, EmitDefaultValue = false)]
        public string? CustomerKey { get; set; }

        /// <summary>
        /// Custom metadata of the device, present when device_id is provided.
        /// </summary>
        [DataMember(Name = "device_custom_metadata", IsRequired = false, EmitDefaultValue = false)]
        public object? DeviceCustomMetadata { get; set; }

        /// <summary>
        /// Errors associated with the device.
        /// </summary>
        [DataMember(Name = "device_errors", IsRequired = false, EmitDefaultValue = false)]
        public List<EventDeviceDisconnectedDeviceErrors> DeviceErrors { get; set; }

        /// <summary>
        /// ID of the affected device.
        /// </summary>
        [DataMember(Name = "device_id", IsRequired = false, EmitDefaultValue = false)]
        public string DeviceId { get; set; }

        /// <summary>
        /// Warnings associated with the device.
        /// </summary>
        [DataMember(Name = "device_warnings", IsRequired = false, EmitDefaultValue = false)]
        public List<EventDeviceDisconnectedDeviceWarnings> DeviceWarnings { get; set; }

        /// <summary>
        /// Error code associated with the disconnection event, if any.
        /// </summary>
        [DataMember(Name = "error_code", IsRequired = false, EmitDefaultValue = false)]
        public EventDeviceDisconnected.ErrorCodeEnum ErrorCode { get; set; }

        /// <summary>
        /// Human-readable description of the event. Persisted when the event is created (so the creating code, including a provider, can supply a tailored description) and otherwise derived from the event.
        /// </summary>
        [DataMember(Name = "event_description", IsRequired = false, EmitDefaultValue = false)]
        public override string? EventDescription { get; set; }

        /// <summary>
        /// ID of the event.
        /// </summary>
        [DataMember(Name = "event_id", IsRequired = false, EmitDefaultValue = false)]
        public override string EventId { get; set; }

        [DataMember(Name = "event_type", IsRequired = true, EmitDefaultValue = false)]
        public override string EventType { get; } = "device.disconnected";

        /// <summary>
        /// Date and time at which the event occurred.
        /// </summary>
        [DataMember(Name = "occurred_at", IsRequired = false, EmitDefaultValue = false)]
        public override string OccurredAt { get; set; }

        /// <summary>
        /// ID of the workspace associated with the event.
        /// </summary>
        [DataMember(Name = "workspace_id", IsRequired = false, EmitDefaultValue = false)]
        public override string WorkspaceId { get; set; }

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

    [DataContract(Name = "seamModel_eventDeviceDisconnectedConnectedAccountErrors_model")]
    public class EventDeviceDisconnectedConnectedAccountErrors
    {
        [JsonConstructorAttribute]
        protected EventDeviceDisconnectedConnectedAccountErrors() { }

        public EventDeviceDisconnectedConnectedAccountErrors(
            string createdAt = default,
            string errorCode = default,
            string message = default
        )
        {
            CreatedAt = createdAt;
            ErrorCode = errorCode;
            Message = message;
        }

        /// <summary>
        /// Date and time at which Seam created the error.
        /// </summary>
        [DataMember(Name = "created_at", IsRequired = false, EmitDefaultValue = false)]
        public string CreatedAt { get; set; }

        /// <summary>
        /// Unique identifier of the type of error. Enables quick recognition and categorization of the issue.
        /// </summary>
        [DataMember(Name = "error_code", IsRequired = false, EmitDefaultValue = false)]
        public string ErrorCode { get; set; }

        /// <summary>
        /// Detailed description of the error. Provides insights into the issue and potentially how to rectify it.
        /// </summary>
        [DataMember(Name = "message", IsRequired = false, EmitDefaultValue = false)]
        public string Message { get; set; }

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

    [DataContract(Name = "seamModel_eventDeviceDisconnectedConnectedAccountWarnings_model")]
    public class EventDeviceDisconnectedConnectedAccountWarnings
    {
        [JsonConstructorAttribute]
        protected EventDeviceDisconnectedConnectedAccountWarnings() { }

        public EventDeviceDisconnectedConnectedAccountWarnings(
            string createdAt = default,
            string message = default,
            string warningCode = default
        )
        {
            CreatedAt = createdAt;
            Message = message;
            WarningCode = warningCode;
        }

        /// <summary>
        /// Date and time at which Seam created the warning.
        /// </summary>
        [DataMember(Name = "created_at", IsRequired = false, EmitDefaultValue = false)]
        public string CreatedAt { get; set; }

        /// <summary>
        /// Detailed description of the warning. Provides insights into the issue and potentially how to rectify it.
        /// </summary>
        [DataMember(Name = "message", IsRequired = false, EmitDefaultValue = false)]
        public string Message { get; set; }

        /// <summary>
        /// Unique identifier of the type of warning. Enables quick recognition and categorization of the issue.
        /// </summary>
        [DataMember(Name = "warning_code", IsRequired = false, EmitDefaultValue = false)]
        public string WarningCode { get; set; }

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

    [DataContract(Name = "seamModel_eventDeviceDisconnectedDeviceErrors_model")]
    public class EventDeviceDisconnectedDeviceErrors
    {
        [JsonConstructorAttribute]
        protected EventDeviceDisconnectedDeviceErrors() { }

        public EventDeviceDisconnectedDeviceErrors(
            string createdAt = default,
            string errorCode = default,
            string message = default
        )
        {
            CreatedAt = createdAt;
            ErrorCode = errorCode;
            Message = message;
        }

        /// <summary>
        /// Date and time at which Seam created the error.
        /// </summary>
        [DataMember(Name = "created_at", IsRequired = false, EmitDefaultValue = false)]
        public string CreatedAt { get; set; }

        /// <summary>
        /// Unique identifier of the type of error. Enables quick recognition and categorization of the issue.
        /// </summary>
        [DataMember(Name = "error_code", IsRequired = false, EmitDefaultValue = false)]
        public string ErrorCode { get; set; }

        /// <summary>
        /// Detailed description of the error. Provides insights into the issue and potentially how to rectify it.
        /// </summary>
        [DataMember(Name = "message", IsRequired = false, EmitDefaultValue = false)]
        public string Message { get; set; }

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

    [DataContract(Name = "seamModel_eventDeviceDisconnectedDeviceWarnings_model")]
    public class EventDeviceDisconnectedDeviceWarnings
    {
        [JsonConstructorAttribute]
        protected EventDeviceDisconnectedDeviceWarnings() { }

        public EventDeviceDisconnectedDeviceWarnings(
            string createdAt = default,
            string message = default,
            string warningCode = default
        )
        {
            CreatedAt = createdAt;
            Message = message;
            WarningCode = warningCode;
        }

        /// <summary>
        /// Date and time at which Seam created the warning.
        /// </summary>
        [DataMember(Name = "created_at", IsRequired = false, EmitDefaultValue = false)]
        public string CreatedAt { get; set; }

        /// <summary>
        /// Detailed description of the warning. Provides insights into the issue and potentially how to rectify it.
        /// </summary>
        [DataMember(Name = "message", IsRequired = false, EmitDefaultValue = false)]
        public string Message { get; set; }

        /// <summary>
        /// Unique identifier of the type of warning. Enables quick recognition and categorization of the issue.
        /// </summary>
        [DataMember(Name = "warning_code", IsRequired = false, EmitDefaultValue = false)]
        public string WarningCode { get; set; }

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
    /// The status of an [unmanaged device](https://docs.seam.co/core-concepts/devices/managed-and-unmanaged-devices) changed from online to offline. That is, the `device.properties.online` property changed from `true` to `false`.
    /// </summary>
    [DataContract(Name = "seamModel_eventDeviceUnmanagedDisconnected_model")]
    public class EventDeviceUnmanagedDisconnected : Event
    {
        [JsonConstructorAttribute]
        protected EventDeviceUnmanagedDisconnected() { }

        public EventDeviceUnmanagedDisconnected(
            object? connectedAccountCustomMetadata = default,
            List<EventDeviceUnmanagedDisconnectedConnectedAccountErrors> connectedAccountErrors =
                default,
            string connectedAccountId = default,
            List<EventDeviceUnmanagedDisconnectedConnectedAccountWarnings> connectedAccountWarnings =
                default,
            string createdAt = default,
            string? customerKey = default,
            object? deviceCustomMetadata = default,
            List<EventDeviceUnmanagedDisconnectedDeviceErrors> deviceErrors = default,
            string deviceId = default,
            List<EventDeviceUnmanagedDisconnectedDeviceWarnings> deviceWarnings = default,
            EventDeviceUnmanagedDisconnected.ErrorCodeEnum errorCode = default,
            string? eventDescription = default,
            string eventId = default,
            string eventType = default,
            string occurredAt = default,
            string workspaceId = default
        )
        {
            ConnectedAccountCustomMetadata = connectedAccountCustomMetadata;
            ConnectedAccountErrors = connectedAccountErrors;
            ConnectedAccountId = connectedAccountId;
            ConnectedAccountWarnings = connectedAccountWarnings;
            CreatedAt = createdAt;
            CustomerKey = customerKey;
            DeviceCustomMetadata = deviceCustomMetadata;
            DeviceErrors = deviceErrors;
            DeviceId = deviceId;
            DeviceWarnings = deviceWarnings;
            ErrorCode = errorCode;
            EventDescription = eventDescription;
            EventId = eventId;
            EventType = eventType;
            OccurredAt = occurredAt;
            WorkspaceId = workspaceId;
        }

        /// <summary>
        /// Error code associated with the disconnection event, if any.
        /// </summary>
        [JsonConverter(typeof(SafeStringEnumConverter))]
        public enum ErrorCodeEnum
        {
            [EnumMember(Value = "unrecognized")]
            Unrecognized = 0,

            [EnumMember(Value = "account_disconnected")]
            AccountDisconnected = 1,

            [EnumMember(Value = "hub_disconnected")]
            HubDisconnected = 2,

            [EnumMember(Value = "device_disconnected")]
            DeviceDisconnected = 3,
        }

        /// <summary>
        /// Custom metadata of the connected account, present when connected_account_id is provided.
        /// </summary>
        [DataMember(
            Name = "connected_account_custom_metadata",
            IsRequired = false,
            EmitDefaultValue = false
        )]
        public object? ConnectedAccountCustomMetadata { get; set; }

        /// <summary>
        /// Errors associated with the connected account.
        /// </summary>
        [DataMember(
            Name = "connected_account_errors",
            IsRequired = false,
            EmitDefaultValue = false
        )]
        public List<EventDeviceUnmanagedDisconnectedConnectedAccountErrors> ConnectedAccountErrors { get; set; }

        /// <summary>
        /// ID of the connected account associated with the event.
        /// </summary>
        [DataMember(Name = "connected_account_id", IsRequired = false, EmitDefaultValue = false)]
        public string ConnectedAccountId { get; set; }

        /// <summary>
        /// Warnings associated with the connected account.
        /// </summary>
        [DataMember(
            Name = "connected_account_warnings",
            IsRequired = false,
            EmitDefaultValue = false
        )]
        public List<EventDeviceUnmanagedDisconnectedConnectedAccountWarnings> ConnectedAccountWarnings { get; set; }

        /// <summary>
        /// Date and time at which the event was created.
        /// </summary>
        [DataMember(Name = "created_at", IsRequired = false, EmitDefaultValue = false)]
        public override string CreatedAt { get; set; }

        /// <summary>
        /// The customer key associated with the device, if any.
        /// </summary>
        [DataMember(Name = "customer_key", IsRequired = false, EmitDefaultValue = false)]
        public string? CustomerKey { get; set; }

        /// <summary>
        /// Custom metadata of the device, present when device_id is provided.
        /// </summary>
        [DataMember(Name = "device_custom_metadata", IsRequired = false, EmitDefaultValue = false)]
        public object? DeviceCustomMetadata { get; set; }

        /// <summary>
        /// Errors associated with the device.
        /// </summary>
        [DataMember(Name = "device_errors", IsRequired = false, EmitDefaultValue = false)]
        public List<EventDeviceUnmanagedDisconnectedDeviceErrors> DeviceErrors { get; set; }

        /// <summary>
        /// ID of the affected device.
        /// </summary>
        [DataMember(Name = "device_id", IsRequired = false, EmitDefaultValue = false)]
        public string DeviceId { get; set; }

        /// <summary>
        /// Warnings associated with the device.
        /// </summary>
        [DataMember(Name = "device_warnings", IsRequired = false, EmitDefaultValue = false)]
        public List<EventDeviceUnmanagedDisconnectedDeviceWarnings> DeviceWarnings { get; set; }

        /// <summary>
        /// Error code associated with the disconnection event, if any.
        /// </summary>
        [DataMember(Name = "error_code", IsRequired = false, EmitDefaultValue = false)]
        public EventDeviceUnmanagedDisconnected.ErrorCodeEnum ErrorCode { get; set; }

        /// <summary>
        /// Human-readable description of the event. Persisted when the event is created (so the creating code, including a provider, can supply a tailored description) and otherwise derived from the event.
        /// </summary>
        [DataMember(Name = "event_description", IsRequired = false, EmitDefaultValue = false)]
        public override string? EventDescription { get; set; }

        /// <summary>
        /// ID of the event.
        /// </summary>
        [DataMember(Name = "event_id", IsRequired = false, EmitDefaultValue = false)]
        public override string EventId { get; set; }

        [DataMember(Name = "event_type", IsRequired = true, EmitDefaultValue = false)]
        public override string EventType { get; } = "device.unmanaged.disconnected";

        /// <summary>
        /// Date and time at which the event occurred.
        /// </summary>
        [DataMember(Name = "occurred_at", IsRequired = false, EmitDefaultValue = false)]
        public override string OccurredAt { get; set; }

        /// <summary>
        /// ID of the workspace associated with the event.
        /// </summary>
        [DataMember(Name = "workspace_id", IsRequired = false, EmitDefaultValue = false)]
        public override string WorkspaceId { get; set; }

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

    [DataContract(Name = "seamModel_eventDeviceUnmanagedDisconnectedConnectedAccountErrors_model")]
    public class EventDeviceUnmanagedDisconnectedConnectedAccountErrors
    {
        [JsonConstructorAttribute]
        protected EventDeviceUnmanagedDisconnectedConnectedAccountErrors() { }

        public EventDeviceUnmanagedDisconnectedConnectedAccountErrors(
            string createdAt = default,
            string errorCode = default,
            string message = default
        )
        {
            CreatedAt = createdAt;
            ErrorCode = errorCode;
            Message = message;
        }

        /// <summary>
        /// Date and time at which Seam created the error.
        /// </summary>
        [DataMember(Name = "created_at", IsRequired = false, EmitDefaultValue = false)]
        public string CreatedAt { get; set; }

        /// <summary>
        /// Unique identifier of the type of error. Enables quick recognition and categorization of the issue.
        /// </summary>
        [DataMember(Name = "error_code", IsRequired = false, EmitDefaultValue = false)]
        public string ErrorCode { get; set; }

        /// <summary>
        /// Detailed description of the error. Provides insights into the issue and potentially how to rectify it.
        /// </summary>
        [DataMember(Name = "message", IsRequired = false, EmitDefaultValue = false)]
        public string Message { get; set; }

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
        Name = "seamModel_eventDeviceUnmanagedDisconnectedConnectedAccountWarnings_model"
    )]
    public class EventDeviceUnmanagedDisconnectedConnectedAccountWarnings
    {
        [JsonConstructorAttribute]
        protected EventDeviceUnmanagedDisconnectedConnectedAccountWarnings() { }

        public EventDeviceUnmanagedDisconnectedConnectedAccountWarnings(
            string createdAt = default,
            string message = default,
            string warningCode = default
        )
        {
            CreatedAt = createdAt;
            Message = message;
            WarningCode = warningCode;
        }

        /// <summary>
        /// Date and time at which Seam created the warning.
        /// </summary>
        [DataMember(Name = "created_at", IsRequired = false, EmitDefaultValue = false)]
        public string CreatedAt { get; set; }

        /// <summary>
        /// Detailed description of the warning. Provides insights into the issue and potentially how to rectify it.
        /// </summary>
        [DataMember(Name = "message", IsRequired = false, EmitDefaultValue = false)]
        public string Message { get; set; }

        /// <summary>
        /// Unique identifier of the type of warning. Enables quick recognition and categorization of the issue.
        /// </summary>
        [DataMember(Name = "warning_code", IsRequired = false, EmitDefaultValue = false)]
        public string WarningCode { get; set; }

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

    [DataContract(Name = "seamModel_eventDeviceUnmanagedDisconnectedDeviceErrors_model")]
    public class EventDeviceUnmanagedDisconnectedDeviceErrors
    {
        [JsonConstructorAttribute]
        protected EventDeviceUnmanagedDisconnectedDeviceErrors() { }

        public EventDeviceUnmanagedDisconnectedDeviceErrors(
            string createdAt = default,
            string errorCode = default,
            string message = default
        )
        {
            CreatedAt = createdAt;
            ErrorCode = errorCode;
            Message = message;
        }

        /// <summary>
        /// Date and time at which Seam created the error.
        /// </summary>
        [DataMember(Name = "created_at", IsRequired = false, EmitDefaultValue = false)]
        public string CreatedAt { get; set; }

        /// <summary>
        /// Unique identifier of the type of error. Enables quick recognition and categorization of the issue.
        /// </summary>
        [DataMember(Name = "error_code", IsRequired = false, EmitDefaultValue = false)]
        public string ErrorCode { get; set; }

        /// <summary>
        /// Detailed description of the error. Provides insights into the issue and potentially how to rectify it.
        /// </summary>
        [DataMember(Name = "message", IsRequired = false, EmitDefaultValue = false)]
        public string Message { get; set; }

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

    [DataContract(Name = "seamModel_eventDeviceUnmanagedDisconnectedDeviceWarnings_model")]
    public class EventDeviceUnmanagedDisconnectedDeviceWarnings
    {
        [JsonConstructorAttribute]
        protected EventDeviceUnmanagedDisconnectedDeviceWarnings() { }

        public EventDeviceUnmanagedDisconnectedDeviceWarnings(
            string createdAt = default,
            string message = default,
            string warningCode = default
        )
        {
            CreatedAt = createdAt;
            Message = message;
            WarningCode = warningCode;
        }

        /// <summary>
        /// Date and time at which Seam created the warning.
        /// </summary>
        [DataMember(Name = "created_at", IsRequired = false, EmitDefaultValue = false)]
        public string CreatedAt { get; set; }

        /// <summary>
        /// Detailed description of the warning. Provides insights into the issue and potentially how to rectify it.
        /// </summary>
        [DataMember(Name = "message", IsRequired = false, EmitDefaultValue = false)]
        public string Message { get; set; }

        /// <summary>
        /// Unique identifier of the type of warning. Enables quick recognition and categorization of the issue.
        /// </summary>
        [DataMember(Name = "warning_code", IsRequired = false, EmitDefaultValue = false)]
        public string WarningCode { get; set; }

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
    /// A device detected that it was tampered with, for example, opened or moved.
    /// </summary>
    [DataContract(Name = "seamModel_eventDeviceTampered_model")]
    public class EventDeviceTampered : Event
    {
        [JsonConstructorAttribute]
        protected EventDeviceTampered() { }

        public EventDeviceTampered(
            object? connectedAccountCustomMetadata = default,
            string connectedAccountId = default,
            string createdAt = default,
            string? customerKey = default,
            object? deviceCustomMetadata = default,
            string deviceId = default,
            string? eventDescription = default,
            string eventId = default,
            string eventType = default,
            string occurredAt = default,
            string workspaceId = default
        )
        {
            ConnectedAccountCustomMetadata = connectedAccountCustomMetadata;
            ConnectedAccountId = connectedAccountId;
            CreatedAt = createdAt;
            CustomerKey = customerKey;
            DeviceCustomMetadata = deviceCustomMetadata;
            DeviceId = deviceId;
            EventDescription = eventDescription;
            EventId = eventId;
            EventType = eventType;
            OccurredAt = occurredAt;
            WorkspaceId = workspaceId;
        }

        /// <summary>
        /// Custom metadata of the connected account, present when connected_account_id is provided.
        /// </summary>
        [DataMember(
            Name = "connected_account_custom_metadata",
            IsRequired = false,
            EmitDefaultValue = false
        )]
        public object? ConnectedAccountCustomMetadata { get; set; }

        /// <summary>
        /// ID of the connected account associated with the event.
        /// </summary>
        [DataMember(Name = "connected_account_id", IsRequired = false, EmitDefaultValue = false)]
        public string ConnectedAccountId { get; set; }

        /// <summary>
        /// Date and time at which the event was created.
        /// </summary>
        [DataMember(Name = "created_at", IsRequired = false, EmitDefaultValue = false)]
        public override string CreatedAt { get; set; }

        /// <summary>
        /// The customer key associated with the device, if any.
        /// </summary>
        [DataMember(Name = "customer_key", IsRequired = false, EmitDefaultValue = false)]
        public string? CustomerKey { get; set; }

        /// <summary>
        /// Custom metadata of the device, present when device_id is provided.
        /// </summary>
        [DataMember(Name = "device_custom_metadata", IsRequired = false, EmitDefaultValue = false)]
        public object? DeviceCustomMetadata { get; set; }

        /// <summary>
        /// ID of the affected device.
        /// </summary>
        [DataMember(Name = "device_id", IsRequired = false, EmitDefaultValue = false)]
        public string DeviceId { get; set; }

        /// <summary>
        /// Human-readable description of the event. Persisted when the event is created (so the creating code, including a provider, can supply a tailored description) and otherwise derived from the event.
        /// </summary>
        [DataMember(Name = "event_description", IsRequired = false, EmitDefaultValue = false)]
        public override string? EventDescription { get; set; }

        /// <summary>
        /// ID of the event.
        /// </summary>
        [DataMember(Name = "event_id", IsRequired = false, EmitDefaultValue = false)]
        public override string EventId { get; set; }

        [DataMember(Name = "event_type", IsRequired = true, EmitDefaultValue = false)]
        public override string EventType { get; } = "device.tampered";

        /// <summary>
        /// Date and time at which the event occurred.
        /// </summary>
        [DataMember(Name = "occurred_at", IsRequired = false, EmitDefaultValue = false)]
        public override string OccurredAt { get; set; }

        /// <summary>
        /// ID of the workspace associated with the event.
        /// </summary>
        [DataMember(Name = "workspace_id", IsRequired = false, EmitDefaultValue = false)]
        public override string WorkspaceId { get; set; }

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
    /// A device battery level dropped below the low threshold.
    /// </summary>
    [DataContract(Name = "seamModel_eventDeviceLowBattery_model")]
    public class EventDeviceLowBattery : Event
    {
        [JsonConstructorAttribute]
        protected EventDeviceLowBattery() { }

        public EventDeviceLowBattery(
            float batteryLevel = default,
            object? connectedAccountCustomMetadata = default,
            string connectedAccountId = default,
            string createdAt = default,
            string? customerKey = default,
            object? deviceCustomMetadata = default,
            string deviceId = default,
            string? eventDescription = default,
            string eventId = default,
            string eventType = default,
            string occurredAt = default,
            string workspaceId = default
        )
        {
            BatteryLevel = batteryLevel;
            ConnectedAccountCustomMetadata = connectedAccountCustomMetadata;
            ConnectedAccountId = connectedAccountId;
            CreatedAt = createdAt;
            CustomerKey = customerKey;
            DeviceCustomMetadata = deviceCustomMetadata;
            DeviceId = deviceId;
            EventDescription = eventDescription;
            EventId = eventId;
            EventType = eventType;
            OccurredAt = occurredAt;
            WorkspaceId = workspaceId;
        }

        /// <summary>
        /// Number in the range 0 to 1.0 indicating the amount of battery in the affected device, as reported by the device.
        /// </summary>
        [DataMember(Name = "battery_level", IsRequired = false, EmitDefaultValue = false)]
        public float BatteryLevel { get; set; }

        /// <summary>
        /// Custom metadata of the connected account, present when connected_account_id is provided.
        /// </summary>
        [DataMember(
            Name = "connected_account_custom_metadata",
            IsRequired = false,
            EmitDefaultValue = false
        )]
        public object? ConnectedAccountCustomMetadata { get; set; }

        /// <summary>
        /// ID of the connected account associated with the event.
        /// </summary>
        [DataMember(Name = "connected_account_id", IsRequired = false, EmitDefaultValue = false)]
        public string ConnectedAccountId { get; set; }

        /// <summary>
        /// Date and time at which the event was created.
        /// </summary>
        [DataMember(Name = "created_at", IsRequired = false, EmitDefaultValue = false)]
        public override string CreatedAt { get; set; }

        /// <summary>
        /// The customer key associated with the device, if any.
        /// </summary>
        [DataMember(Name = "customer_key", IsRequired = false, EmitDefaultValue = false)]
        public string? CustomerKey { get; set; }

        /// <summary>
        /// Custom metadata of the device, present when device_id is provided.
        /// </summary>
        [DataMember(Name = "device_custom_metadata", IsRequired = false, EmitDefaultValue = false)]
        public object? DeviceCustomMetadata { get; set; }

        /// <summary>
        /// ID of the affected device.
        /// </summary>
        [DataMember(Name = "device_id", IsRequired = false, EmitDefaultValue = false)]
        public string DeviceId { get; set; }

        /// <summary>
        /// Human-readable description of the event. Persisted when the event is created (so the creating code, including a provider, can supply a tailored description) and otherwise derived from the event.
        /// </summary>
        [DataMember(Name = "event_description", IsRequired = false, EmitDefaultValue = false)]
        public override string? EventDescription { get; set; }

        /// <summary>
        /// ID of the event.
        /// </summary>
        [DataMember(Name = "event_id", IsRequired = false, EmitDefaultValue = false)]
        public override string EventId { get; set; }

        [DataMember(Name = "event_type", IsRequired = true, EmitDefaultValue = false)]
        public override string EventType { get; } = "device.low_battery";

        /// <summary>
        /// Date and time at which the event occurred.
        /// </summary>
        [DataMember(Name = "occurred_at", IsRequired = false, EmitDefaultValue = false)]
        public override string OccurredAt { get; set; }

        /// <summary>
        /// ID of the workspace associated with the event.
        /// </summary>
        [DataMember(Name = "workspace_id", IsRequired = false, EmitDefaultValue = false)]
        public override string WorkspaceId { get; set; }

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
    /// A device battery status changed since the last `battery_status_changed` event.
    /// </summary>
    [DataContract(Name = "seamModel_eventDeviceBatteryStatusChanged_model")]
    public class EventDeviceBatteryStatusChanged : Event
    {
        [JsonConstructorAttribute]
        protected EventDeviceBatteryStatusChanged() { }

        public EventDeviceBatteryStatusChanged(
            float batteryLevel = default,
            EventDeviceBatteryStatusChanged.BatteryStatusEnum batteryStatus = default,
            object? connectedAccountCustomMetadata = default,
            string connectedAccountId = default,
            string createdAt = default,
            string? customerKey = default,
            object? deviceCustomMetadata = default,
            string deviceId = default,
            string? eventDescription = default,
            string eventId = default,
            string eventType = default,
            string occurredAt = default,
            string workspaceId = default
        )
        {
            BatteryLevel = batteryLevel;
            BatteryStatus = batteryStatus;
            ConnectedAccountCustomMetadata = connectedAccountCustomMetadata;
            ConnectedAccountId = connectedAccountId;
            CreatedAt = createdAt;
            CustomerKey = customerKey;
            DeviceCustomMetadata = deviceCustomMetadata;
            DeviceId = deviceId;
            EventDescription = eventDescription;
            EventId = eventId;
            EventType = eventType;
            OccurredAt = occurredAt;
            WorkspaceId = workspaceId;
        }

        /// <summary>
        /// Battery status of the affected device, calculated from the numeric `battery_level` value.
        /// </summary>
        [JsonConverter(typeof(SafeStringEnumConverter))]
        public enum BatteryStatusEnum
        {
            [EnumMember(Value = "unrecognized")]
            Unrecognized = 0,

            [EnumMember(Value = "critical")]
            Critical = 1,

            [EnumMember(Value = "low")]
            Low = 2,

            [EnumMember(Value = "good")]
            Good = 3,

            [EnumMember(Value = "full")]
            Full = 4,
        }

        /// <summary>
        /// Number in the range 0 to 1.0 indicating the amount of battery in the affected device, as reported by the device.
        /// </summary>
        [DataMember(Name = "battery_level", IsRequired = false, EmitDefaultValue = false)]
        public float BatteryLevel { get; set; }

        /// <summary>
        /// Battery status of the affected device, calculated from the numeric `battery_level` value.
        /// </summary>
        [DataMember(Name = "battery_status", IsRequired = false, EmitDefaultValue = false)]
        public EventDeviceBatteryStatusChanged.BatteryStatusEnum BatteryStatus { get; set; }

        /// <summary>
        /// Custom metadata of the connected account, present when connected_account_id is provided.
        /// </summary>
        [DataMember(
            Name = "connected_account_custom_metadata",
            IsRequired = false,
            EmitDefaultValue = false
        )]
        public object? ConnectedAccountCustomMetadata { get; set; }

        /// <summary>
        /// ID of the connected account associated with the event.
        /// </summary>
        [DataMember(Name = "connected_account_id", IsRequired = false, EmitDefaultValue = false)]
        public string ConnectedAccountId { get; set; }

        /// <summary>
        /// Date and time at which the event was created.
        /// </summary>
        [DataMember(Name = "created_at", IsRequired = false, EmitDefaultValue = false)]
        public override string CreatedAt { get; set; }

        /// <summary>
        /// The customer key associated with the device, if any.
        /// </summary>
        [DataMember(Name = "customer_key", IsRequired = false, EmitDefaultValue = false)]
        public string? CustomerKey { get; set; }

        /// <summary>
        /// Custom metadata of the device, present when device_id is provided.
        /// </summary>
        [DataMember(Name = "device_custom_metadata", IsRequired = false, EmitDefaultValue = false)]
        public object? DeviceCustomMetadata { get; set; }

        /// <summary>
        /// ID of the affected device.
        /// </summary>
        [DataMember(Name = "device_id", IsRequired = false, EmitDefaultValue = false)]
        public string DeviceId { get; set; }

        /// <summary>
        /// Human-readable description of the event. Persisted when the event is created (so the creating code, including a provider, can supply a tailored description) and otherwise derived from the event.
        /// </summary>
        [DataMember(Name = "event_description", IsRequired = false, EmitDefaultValue = false)]
        public override string? EventDescription { get; set; }

        /// <summary>
        /// ID of the event.
        /// </summary>
        [DataMember(Name = "event_id", IsRequired = false, EmitDefaultValue = false)]
        public override string EventId { get; set; }

        [DataMember(Name = "event_type", IsRequired = true, EmitDefaultValue = false)]
        public override string EventType { get; } = "device.battery_status_changed";

        /// <summary>
        /// Date and time at which the event occurred.
        /// </summary>
        [DataMember(Name = "occurred_at", IsRequired = false, EmitDefaultValue = false)]
        public override string OccurredAt { get; set; }

        /// <summary>
        /// ID of the workspace associated with the event.
        /// </summary>
        [DataMember(Name = "workspace_id", IsRequired = false, EmitDefaultValue = false)]
        public override string WorkspaceId { get; set; }

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
    /// A device was removed externally from the connected account.
    /// </summary>
    [DataContract(Name = "seamModel_eventDeviceRemoved_model")]
    public class EventDeviceRemoved : Event
    {
        [JsonConstructorAttribute]
        protected EventDeviceRemoved() { }

        public EventDeviceRemoved(
            object? connectedAccountCustomMetadata = default,
            string connectedAccountId = default,
            string createdAt = default,
            string? customerKey = default,
            object? deviceCustomMetadata = default,
            string deviceId = default,
            string? eventDescription = default,
            string eventId = default,
            string eventType = default,
            string occurredAt = default,
            string workspaceId = default
        )
        {
            ConnectedAccountCustomMetadata = connectedAccountCustomMetadata;
            ConnectedAccountId = connectedAccountId;
            CreatedAt = createdAt;
            CustomerKey = customerKey;
            DeviceCustomMetadata = deviceCustomMetadata;
            DeviceId = deviceId;
            EventDescription = eventDescription;
            EventId = eventId;
            EventType = eventType;
            OccurredAt = occurredAt;
            WorkspaceId = workspaceId;
        }

        /// <summary>
        /// Custom metadata of the connected account, present when connected_account_id is provided.
        /// </summary>
        [DataMember(
            Name = "connected_account_custom_metadata",
            IsRequired = false,
            EmitDefaultValue = false
        )]
        public object? ConnectedAccountCustomMetadata { get; set; }

        /// <summary>
        /// ID of the connected account associated with the event.
        /// </summary>
        [DataMember(Name = "connected_account_id", IsRequired = false, EmitDefaultValue = false)]
        public string ConnectedAccountId { get; set; }

        /// <summary>
        /// Date and time at which the event was created.
        /// </summary>
        [DataMember(Name = "created_at", IsRequired = false, EmitDefaultValue = false)]
        public override string CreatedAt { get; set; }

        /// <summary>
        /// The customer key associated with the device, if any.
        /// </summary>
        [DataMember(Name = "customer_key", IsRequired = false, EmitDefaultValue = false)]
        public string? CustomerKey { get; set; }

        /// <summary>
        /// Custom metadata of the device, present when device_id is provided.
        /// </summary>
        [DataMember(Name = "device_custom_metadata", IsRequired = false, EmitDefaultValue = false)]
        public object? DeviceCustomMetadata { get; set; }

        /// <summary>
        /// ID of the affected device.
        /// </summary>
        [DataMember(Name = "device_id", IsRequired = false, EmitDefaultValue = false)]
        public string DeviceId { get; set; }

        /// <summary>
        /// Human-readable description of the event. Persisted when the event is created (so the creating code, including a provider, can supply a tailored description) and otherwise derived from the event.
        /// </summary>
        [DataMember(Name = "event_description", IsRequired = false, EmitDefaultValue = false)]
        public override string? EventDescription { get; set; }

        /// <summary>
        /// ID of the event.
        /// </summary>
        [DataMember(Name = "event_id", IsRequired = false, EmitDefaultValue = false)]
        public override string EventId { get; set; }

        [DataMember(Name = "event_type", IsRequired = true, EmitDefaultValue = false)]
        public override string EventType { get; } = "device.removed";

        /// <summary>
        /// Date and time at which the event occurred.
        /// </summary>
        [DataMember(Name = "occurred_at", IsRequired = false, EmitDefaultValue = false)]
        public override string OccurredAt { get; set; }

        /// <summary>
        /// ID of the workspace associated with the event.
        /// </summary>
        [DataMember(Name = "workspace_id", IsRequired = false, EmitDefaultValue = false)]
        public override string WorkspaceId { get; set; }

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
    /// A device was deleted.
    /// </summary>
    [DataContract(Name = "seamModel_eventDeviceDeleted_model")]
    public class EventDeviceDeleted : Event
    {
        [JsonConstructorAttribute]
        protected EventDeviceDeleted() { }

        public EventDeviceDeleted(
            object? connectedAccountCustomMetadata = default,
            string connectedAccountId = default,
            string createdAt = default,
            string? customerKey = default,
            object? deviceCustomMetadata = default,
            string deviceId = default,
            string? deviceName = default,
            string? eventDescription = default,
            string eventId = default,
            string eventType = default,
            string occurredAt = default,
            string workspaceId = default
        )
        {
            ConnectedAccountCustomMetadata = connectedAccountCustomMetadata;
            ConnectedAccountId = connectedAccountId;
            CreatedAt = createdAt;
            CustomerKey = customerKey;
            DeviceCustomMetadata = deviceCustomMetadata;
            DeviceId = deviceId;
            DeviceName = deviceName;
            EventDescription = eventDescription;
            EventId = eventId;
            EventType = eventType;
            OccurredAt = occurredAt;
            WorkspaceId = workspaceId;
        }

        /// <summary>
        /// Custom metadata of the connected account, present when connected_account_id is provided.
        /// </summary>
        [DataMember(
            Name = "connected_account_custom_metadata",
            IsRequired = false,
            EmitDefaultValue = false
        )]
        public object? ConnectedAccountCustomMetadata { get; set; }

        /// <summary>
        /// ID of the connected account associated with the event.
        /// </summary>
        [DataMember(Name = "connected_account_id", IsRequired = false, EmitDefaultValue = false)]
        public string ConnectedAccountId { get; set; }

        /// <summary>
        /// Date and time at which the event was created.
        /// </summary>
        [DataMember(Name = "created_at", IsRequired = false, EmitDefaultValue = false)]
        public override string CreatedAt { get; set; }

        /// <summary>
        /// The customer key associated with the device, if any.
        /// </summary>
        [DataMember(Name = "customer_key", IsRequired = false, EmitDefaultValue = false)]
        public string? CustomerKey { get; set; }

        /// <summary>
        /// Custom metadata of the device, present when device_id is provided.
        /// </summary>
        [DataMember(Name = "device_custom_metadata", IsRequired = false, EmitDefaultValue = false)]
        public object? DeviceCustomMetadata { get; set; }

        /// <summary>
        /// ID of the affected device.
        /// </summary>
        [DataMember(Name = "device_id", IsRequired = false, EmitDefaultValue = false)]
        public string DeviceId { get; set; }

        /// <summary>
        /// Name of the deleted device, captured at deletion time. The device record no longer exists when this event fires, so the name is preserved here. Null when the device had no resolvable name.
        /// </summary>
        [DataMember(Name = "device_name", IsRequired = false, EmitDefaultValue = false)]
        public string? DeviceName { get; set; }

        /// <summary>
        /// Human-readable description of the event. Persisted when the event is created (so the creating code, including a provider, can supply a tailored description) and otherwise derived from the event.
        /// </summary>
        [DataMember(Name = "event_description", IsRequired = false, EmitDefaultValue = false)]
        public override string? EventDescription { get; set; }

        /// <summary>
        /// ID of the event.
        /// </summary>
        [DataMember(Name = "event_id", IsRequired = false, EmitDefaultValue = false)]
        public override string EventId { get; set; }

        [DataMember(Name = "event_type", IsRequired = true, EmitDefaultValue = false)]
        public override string EventType { get; } = "device.deleted";

        /// <summary>
        /// Date and time at which the event occurred.
        /// </summary>
        [DataMember(Name = "occurred_at", IsRequired = false, EmitDefaultValue = false)]
        public override string OccurredAt { get; set; }

        /// <summary>
        /// ID of the workspace associated with the event.
        /// </summary>
        [DataMember(Name = "workspace_id", IsRequired = false, EmitDefaultValue = false)]
        public override string WorkspaceId { get; set; }

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
    /// Seam detected that a device is using a third-party integration that will interfere with Seam device management.
    /// </summary>
    [DataContract(Name = "seamModel_eventDeviceThirdPartyIntegrationDetected_model")]
    public class EventDeviceThirdPartyIntegrationDetected : Event
    {
        [JsonConstructorAttribute]
        protected EventDeviceThirdPartyIntegrationDetected() { }

        public EventDeviceThirdPartyIntegrationDetected(
            object? connectedAccountCustomMetadata = default,
            string connectedAccountId = default,
            string createdAt = default,
            string? customerKey = default,
            object? deviceCustomMetadata = default,
            string deviceId = default,
            string? eventDescription = default,
            string eventId = default,
            string eventType = default,
            string occurredAt = default,
            string workspaceId = default
        )
        {
            ConnectedAccountCustomMetadata = connectedAccountCustomMetadata;
            ConnectedAccountId = connectedAccountId;
            CreatedAt = createdAt;
            CustomerKey = customerKey;
            DeviceCustomMetadata = deviceCustomMetadata;
            DeviceId = deviceId;
            EventDescription = eventDescription;
            EventId = eventId;
            EventType = eventType;
            OccurredAt = occurredAt;
            WorkspaceId = workspaceId;
        }

        /// <summary>
        /// Custom metadata of the connected account, present when connected_account_id is provided.
        /// </summary>
        [DataMember(
            Name = "connected_account_custom_metadata",
            IsRequired = false,
            EmitDefaultValue = false
        )]
        public object? ConnectedAccountCustomMetadata { get; set; }

        /// <summary>
        /// ID of the connected account associated with the event.
        /// </summary>
        [DataMember(Name = "connected_account_id", IsRequired = false, EmitDefaultValue = false)]
        public string ConnectedAccountId { get; set; }

        /// <summary>
        /// Date and time at which the event was created.
        /// </summary>
        [DataMember(Name = "created_at", IsRequired = false, EmitDefaultValue = false)]
        public override string CreatedAt { get; set; }

        /// <summary>
        /// The customer key associated with the device, if any.
        /// </summary>
        [DataMember(Name = "customer_key", IsRequired = false, EmitDefaultValue = false)]
        public string? CustomerKey { get; set; }

        /// <summary>
        /// Custom metadata of the device, present when device_id is provided.
        /// </summary>
        [DataMember(Name = "device_custom_metadata", IsRequired = false, EmitDefaultValue = false)]
        public object? DeviceCustomMetadata { get; set; }

        /// <summary>
        /// ID of the affected device.
        /// </summary>
        [DataMember(Name = "device_id", IsRequired = false, EmitDefaultValue = false)]
        public string DeviceId { get; set; }

        /// <summary>
        /// Human-readable description of the event. Persisted when the event is created (so the creating code, including a provider, can supply a tailored description) and otherwise derived from the event.
        /// </summary>
        [DataMember(Name = "event_description", IsRequired = false, EmitDefaultValue = false)]
        public override string? EventDescription { get; set; }

        /// <summary>
        /// ID of the event.
        /// </summary>
        [DataMember(Name = "event_id", IsRequired = false, EmitDefaultValue = false)]
        public override string EventId { get; set; }

        [DataMember(Name = "event_type", IsRequired = true, EmitDefaultValue = false)]
        public override string EventType { get; } = "device.third_party_integration_detected";

        /// <summary>
        /// Date and time at which the event occurred.
        /// </summary>
        [DataMember(Name = "occurred_at", IsRequired = false, EmitDefaultValue = false)]
        public override string OccurredAt { get; set; }

        /// <summary>
        /// ID of the workspace associated with the event.
        /// </summary>
        [DataMember(Name = "workspace_id", IsRequired = false, EmitDefaultValue = false)]
        public override string WorkspaceId { get; set; }

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
    /// Seam detected that a device is no longer using a third-party integration that was interfering with Seam device management.
    /// </summary>
    [DataContract(Name = "seamModel_eventDeviceThirdPartyIntegrationNoLongerDetected_model")]
    public class EventDeviceThirdPartyIntegrationNoLongerDetected : Event
    {
        [JsonConstructorAttribute]
        protected EventDeviceThirdPartyIntegrationNoLongerDetected() { }

        public EventDeviceThirdPartyIntegrationNoLongerDetected(
            object? connectedAccountCustomMetadata = default,
            string connectedAccountId = default,
            string createdAt = default,
            string? customerKey = default,
            object? deviceCustomMetadata = default,
            string deviceId = default,
            string? eventDescription = default,
            string eventId = default,
            string eventType = default,
            string occurredAt = default,
            string workspaceId = default
        )
        {
            ConnectedAccountCustomMetadata = connectedAccountCustomMetadata;
            ConnectedAccountId = connectedAccountId;
            CreatedAt = createdAt;
            CustomerKey = customerKey;
            DeviceCustomMetadata = deviceCustomMetadata;
            DeviceId = deviceId;
            EventDescription = eventDescription;
            EventId = eventId;
            EventType = eventType;
            OccurredAt = occurredAt;
            WorkspaceId = workspaceId;
        }

        /// <summary>
        /// Custom metadata of the connected account, present when connected_account_id is provided.
        /// </summary>
        [DataMember(
            Name = "connected_account_custom_metadata",
            IsRequired = false,
            EmitDefaultValue = false
        )]
        public object? ConnectedAccountCustomMetadata { get; set; }

        /// <summary>
        /// ID of the connected account associated with the event.
        /// </summary>
        [DataMember(Name = "connected_account_id", IsRequired = false, EmitDefaultValue = false)]
        public string ConnectedAccountId { get; set; }

        /// <summary>
        /// Date and time at which the event was created.
        /// </summary>
        [DataMember(Name = "created_at", IsRequired = false, EmitDefaultValue = false)]
        public override string CreatedAt { get; set; }

        /// <summary>
        /// The customer key associated with the device, if any.
        /// </summary>
        [DataMember(Name = "customer_key", IsRequired = false, EmitDefaultValue = false)]
        public string? CustomerKey { get; set; }

        /// <summary>
        /// Custom metadata of the device, present when device_id is provided.
        /// </summary>
        [DataMember(Name = "device_custom_metadata", IsRequired = false, EmitDefaultValue = false)]
        public object? DeviceCustomMetadata { get; set; }

        /// <summary>
        /// ID of the affected device.
        /// </summary>
        [DataMember(Name = "device_id", IsRequired = false, EmitDefaultValue = false)]
        public string DeviceId { get; set; }

        /// <summary>
        /// Human-readable description of the event. Persisted when the event is created (so the creating code, including a provider, can supply a tailored description) and otherwise derived from the event.
        /// </summary>
        [DataMember(Name = "event_description", IsRequired = false, EmitDefaultValue = false)]
        public override string? EventDescription { get; set; }

        /// <summary>
        /// ID of the event.
        /// </summary>
        [DataMember(Name = "event_id", IsRequired = false, EmitDefaultValue = false)]
        public override string EventId { get; set; }

        [DataMember(Name = "event_type", IsRequired = true, EmitDefaultValue = false)]
        public override string EventType { get; } =
            "device.third_party_integration_no_longer_detected";

        /// <summary>
        /// Date and time at which the event occurred.
        /// </summary>
        [DataMember(Name = "occurred_at", IsRequired = false, EmitDefaultValue = false)]
        public override string OccurredAt { get; set; }

        /// <summary>
        /// ID of the workspace associated with the event.
        /// </summary>
        [DataMember(Name = "workspace_id", IsRequired = false, EmitDefaultValue = false)]
        public override string WorkspaceId { get; set; }

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
    /// A [Salto device](https://docs.seam.co/device-and-system-integration-guides/salto-locks) activated privacy mode.
    /// </summary>
    [DataContract(Name = "seamModel_eventDeviceSaltoPrivacyModeActivated_model")]
    public class EventDeviceSaltoPrivacyModeActivated : Event
    {
        [JsonConstructorAttribute]
        protected EventDeviceSaltoPrivacyModeActivated() { }

        public EventDeviceSaltoPrivacyModeActivated(
            object? connectedAccountCustomMetadata = default,
            string connectedAccountId = default,
            string createdAt = default,
            string? customerKey = default,
            object? deviceCustomMetadata = default,
            string deviceId = default,
            string? eventDescription = default,
            string eventId = default,
            string eventType = default,
            string occurredAt = default,
            string workspaceId = default
        )
        {
            ConnectedAccountCustomMetadata = connectedAccountCustomMetadata;
            ConnectedAccountId = connectedAccountId;
            CreatedAt = createdAt;
            CustomerKey = customerKey;
            DeviceCustomMetadata = deviceCustomMetadata;
            DeviceId = deviceId;
            EventDescription = eventDescription;
            EventId = eventId;
            EventType = eventType;
            OccurredAt = occurredAt;
            WorkspaceId = workspaceId;
        }

        /// <summary>
        /// Custom metadata of the connected account, present when connected_account_id is provided.
        /// </summary>
        [DataMember(
            Name = "connected_account_custom_metadata",
            IsRequired = false,
            EmitDefaultValue = false
        )]
        public object? ConnectedAccountCustomMetadata { get; set; }

        /// <summary>
        /// ID of the connected account associated with the event.
        /// </summary>
        [DataMember(Name = "connected_account_id", IsRequired = false, EmitDefaultValue = false)]
        public string ConnectedAccountId { get; set; }

        /// <summary>
        /// Date and time at which the event was created.
        /// </summary>
        [DataMember(Name = "created_at", IsRequired = false, EmitDefaultValue = false)]
        public override string CreatedAt { get; set; }

        /// <summary>
        /// The customer key associated with the device, if any.
        /// </summary>
        [DataMember(Name = "customer_key", IsRequired = false, EmitDefaultValue = false)]
        public string? CustomerKey { get; set; }

        /// <summary>
        /// Custom metadata of the device, present when device_id is provided.
        /// </summary>
        [DataMember(Name = "device_custom_metadata", IsRequired = false, EmitDefaultValue = false)]
        public object? DeviceCustomMetadata { get; set; }

        /// <summary>
        /// ID of the affected device.
        /// </summary>
        [DataMember(Name = "device_id", IsRequired = false, EmitDefaultValue = false)]
        public string DeviceId { get; set; }

        /// <summary>
        /// Human-readable description of the event. Persisted when the event is created (so the creating code, including a provider, can supply a tailored description) and otherwise derived from the event.
        /// </summary>
        [DataMember(Name = "event_description", IsRequired = false, EmitDefaultValue = false)]
        public override string? EventDescription { get; set; }

        /// <summary>
        /// ID of the event.
        /// </summary>
        [DataMember(Name = "event_id", IsRequired = false, EmitDefaultValue = false)]
        public override string EventId { get; set; }

        [DataMember(Name = "event_type", IsRequired = true, EmitDefaultValue = false)]
        public override string EventType { get; } = "device.salto.privacy_mode_activated";

        /// <summary>
        /// Date and time at which the event occurred.
        /// </summary>
        [DataMember(Name = "occurred_at", IsRequired = false, EmitDefaultValue = false)]
        public override string OccurredAt { get; set; }

        /// <summary>
        /// ID of the workspace associated with the event.
        /// </summary>
        [DataMember(Name = "workspace_id", IsRequired = false, EmitDefaultValue = false)]
        public override string WorkspaceId { get; set; }

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
    /// A [Salto device](https://docs.seam.co/device-and-system-integration-guides/salto-locks) deactivated privacy mode.
    /// </summary>
    [DataContract(Name = "seamModel_eventDeviceSaltoPrivacyModeDeactivated_model")]
    public class EventDeviceSaltoPrivacyModeDeactivated : Event
    {
        [JsonConstructorAttribute]
        protected EventDeviceSaltoPrivacyModeDeactivated() { }

        public EventDeviceSaltoPrivacyModeDeactivated(
            object? connectedAccountCustomMetadata = default,
            string connectedAccountId = default,
            string createdAt = default,
            string? customerKey = default,
            object? deviceCustomMetadata = default,
            string deviceId = default,
            string? eventDescription = default,
            string eventId = default,
            string eventType = default,
            string occurredAt = default,
            string workspaceId = default
        )
        {
            ConnectedAccountCustomMetadata = connectedAccountCustomMetadata;
            ConnectedAccountId = connectedAccountId;
            CreatedAt = createdAt;
            CustomerKey = customerKey;
            DeviceCustomMetadata = deviceCustomMetadata;
            DeviceId = deviceId;
            EventDescription = eventDescription;
            EventId = eventId;
            EventType = eventType;
            OccurredAt = occurredAt;
            WorkspaceId = workspaceId;
        }

        /// <summary>
        /// Custom metadata of the connected account, present when connected_account_id is provided.
        /// </summary>
        [DataMember(
            Name = "connected_account_custom_metadata",
            IsRequired = false,
            EmitDefaultValue = false
        )]
        public object? ConnectedAccountCustomMetadata { get; set; }

        /// <summary>
        /// ID of the connected account associated with the event.
        /// </summary>
        [DataMember(Name = "connected_account_id", IsRequired = false, EmitDefaultValue = false)]
        public string ConnectedAccountId { get; set; }

        /// <summary>
        /// Date and time at which the event was created.
        /// </summary>
        [DataMember(Name = "created_at", IsRequired = false, EmitDefaultValue = false)]
        public override string CreatedAt { get; set; }

        /// <summary>
        /// The customer key associated with the device, if any.
        /// </summary>
        [DataMember(Name = "customer_key", IsRequired = false, EmitDefaultValue = false)]
        public string? CustomerKey { get; set; }

        /// <summary>
        /// Custom metadata of the device, present when device_id is provided.
        /// </summary>
        [DataMember(Name = "device_custom_metadata", IsRequired = false, EmitDefaultValue = false)]
        public object? DeviceCustomMetadata { get; set; }

        /// <summary>
        /// ID of the affected device.
        /// </summary>
        [DataMember(Name = "device_id", IsRequired = false, EmitDefaultValue = false)]
        public string DeviceId { get; set; }

        /// <summary>
        /// Human-readable description of the event. Persisted when the event is created (so the creating code, including a provider, can supply a tailored description) and otherwise derived from the event.
        /// </summary>
        [DataMember(Name = "event_description", IsRequired = false, EmitDefaultValue = false)]
        public override string? EventDescription { get; set; }

        /// <summary>
        /// ID of the event.
        /// </summary>
        [DataMember(Name = "event_id", IsRequired = false, EmitDefaultValue = false)]
        public override string EventId { get; set; }

        [DataMember(Name = "event_type", IsRequired = true, EmitDefaultValue = false)]
        public override string EventType { get; } = "device.salto.privacy_mode_deactivated";

        /// <summary>
        /// Date and time at which the event occurred.
        /// </summary>
        [DataMember(Name = "occurred_at", IsRequired = false, EmitDefaultValue = false)]
        public override string OccurredAt { get; set; }

        /// <summary>
        /// ID of the workspace associated with the event.
        /// </summary>
        [DataMember(Name = "workspace_id", IsRequired = false, EmitDefaultValue = false)]
        public override string WorkspaceId { get; set; }

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
    /// Seam detected a flaky device connection.
    /// </summary>
    [DataContract(Name = "seamModel_eventDeviceConnectionBecameFlaky_model")]
    public class EventDeviceConnectionBecameFlaky : Event
    {
        [JsonConstructorAttribute]
        protected EventDeviceConnectionBecameFlaky() { }

        public EventDeviceConnectionBecameFlaky(
            object? connectedAccountCustomMetadata = default,
            List<EventDeviceConnectionBecameFlakyConnectedAccountErrors> connectedAccountErrors =
                default,
            string connectedAccountId = default,
            List<EventDeviceConnectionBecameFlakyConnectedAccountWarnings> connectedAccountWarnings =
                default,
            string createdAt = default,
            string? customerKey = default,
            object? deviceCustomMetadata = default,
            List<EventDeviceConnectionBecameFlakyDeviceErrors> deviceErrors = default,
            string deviceId = default,
            List<EventDeviceConnectionBecameFlakyDeviceWarnings> deviceWarnings = default,
            string? eventDescription = default,
            string eventId = default,
            string eventType = default,
            string occurredAt = default,
            string workspaceId = default
        )
        {
            ConnectedAccountCustomMetadata = connectedAccountCustomMetadata;
            ConnectedAccountErrors = connectedAccountErrors;
            ConnectedAccountId = connectedAccountId;
            ConnectedAccountWarnings = connectedAccountWarnings;
            CreatedAt = createdAt;
            CustomerKey = customerKey;
            DeviceCustomMetadata = deviceCustomMetadata;
            DeviceErrors = deviceErrors;
            DeviceId = deviceId;
            DeviceWarnings = deviceWarnings;
            EventDescription = eventDescription;
            EventId = eventId;
            EventType = eventType;
            OccurredAt = occurredAt;
            WorkspaceId = workspaceId;
        }

        /// <summary>
        /// Custom metadata of the connected account, present when connected_account_id is provided.
        /// </summary>
        [DataMember(
            Name = "connected_account_custom_metadata",
            IsRequired = false,
            EmitDefaultValue = false
        )]
        public object? ConnectedAccountCustomMetadata { get; set; }

        /// <summary>
        /// Errors associated with the connected account.
        /// </summary>
        [DataMember(
            Name = "connected_account_errors",
            IsRequired = false,
            EmitDefaultValue = false
        )]
        public List<EventDeviceConnectionBecameFlakyConnectedAccountErrors> ConnectedAccountErrors { get; set; }

        /// <summary>
        /// ID of the connected account associated with the event.
        /// </summary>
        [DataMember(Name = "connected_account_id", IsRequired = false, EmitDefaultValue = false)]
        public string ConnectedAccountId { get; set; }

        /// <summary>
        /// Warnings associated with the connected account.
        /// </summary>
        [DataMember(
            Name = "connected_account_warnings",
            IsRequired = false,
            EmitDefaultValue = false
        )]
        public List<EventDeviceConnectionBecameFlakyConnectedAccountWarnings> ConnectedAccountWarnings { get; set; }

        /// <summary>
        /// Date and time at which the event was created.
        /// </summary>
        [DataMember(Name = "created_at", IsRequired = false, EmitDefaultValue = false)]
        public override string CreatedAt { get; set; }

        /// <summary>
        /// The customer key associated with the device, if any.
        /// </summary>
        [DataMember(Name = "customer_key", IsRequired = false, EmitDefaultValue = false)]
        public string? CustomerKey { get; set; }

        /// <summary>
        /// Custom metadata of the device, present when device_id is provided.
        /// </summary>
        [DataMember(Name = "device_custom_metadata", IsRequired = false, EmitDefaultValue = false)]
        public object? DeviceCustomMetadata { get; set; }

        /// <summary>
        /// Errors associated with the device.
        /// </summary>
        [DataMember(Name = "device_errors", IsRequired = false, EmitDefaultValue = false)]
        public List<EventDeviceConnectionBecameFlakyDeviceErrors> DeviceErrors { get; set; }

        /// <summary>
        /// ID of the affected device.
        /// </summary>
        [DataMember(Name = "device_id", IsRequired = false, EmitDefaultValue = false)]
        public string DeviceId { get; set; }

        /// <summary>
        /// Warnings associated with the device.
        /// </summary>
        [DataMember(Name = "device_warnings", IsRequired = false, EmitDefaultValue = false)]
        public List<EventDeviceConnectionBecameFlakyDeviceWarnings> DeviceWarnings { get; set; }

        /// <summary>
        /// Human-readable description of the event. Persisted when the event is created (so the creating code, including a provider, can supply a tailored description) and otherwise derived from the event.
        /// </summary>
        [DataMember(Name = "event_description", IsRequired = false, EmitDefaultValue = false)]
        public override string? EventDescription { get; set; }

        /// <summary>
        /// ID of the event.
        /// </summary>
        [DataMember(Name = "event_id", IsRequired = false, EmitDefaultValue = false)]
        public override string EventId { get; set; }

        [DataMember(Name = "event_type", IsRequired = true, EmitDefaultValue = false)]
        public override string EventType { get; } = "device.connection_became_flaky";

        /// <summary>
        /// Date and time at which the event occurred.
        /// </summary>
        [DataMember(Name = "occurred_at", IsRequired = false, EmitDefaultValue = false)]
        public override string OccurredAt { get; set; }

        /// <summary>
        /// ID of the workspace associated with the event.
        /// </summary>
        [DataMember(Name = "workspace_id", IsRequired = false, EmitDefaultValue = false)]
        public override string WorkspaceId { get; set; }

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

    [DataContract(Name = "seamModel_eventDeviceConnectionBecameFlakyConnectedAccountErrors_model")]
    public class EventDeviceConnectionBecameFlakyConnectedAccountErrors
    {
        [JsonConstructorAttribute]
        protected EventDeviceConnectionBecameFlakyConnectedAccountErrors() { }

        public EventDeviceConnectionBecameFlakyConnectedAccountErrors(
            string createdAt = default,
            string errorCode = default,
            string message = default
        )
        {
            CreatedAt = createdAt;
            ErrorCode = errorCode;
            Message = message;
        }

        /// <summary>
        /// Date and time at which Seam created the error.
        /// </summary>
        [DataMember(Name = "created_at", IsRequired = false, EmitDefaultValue = false)]
        public string CreatedAt { get; set; }

        /// <summary>
        /// Unique identifier of the type of error. Enables quick recognition and categorization of the issue.
        /// </summary>
        [DataMember(Name = "error_code", IsRequired = false, EmitDefaultValue = false)]
        public string ErrorCode { get; set; }

        /// <summary>
        /// Detailed description of the error. Provides insights into the issue and potentially how to rectify it.
        /// </summary>
        [DataMember(Name = "message", IsRequired = false, EmitDefaultValue = false)]
        public string Message { get; set; }

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
        Name = "seamModel_eventDeviceConnectionBecameFlakyConnectedAccountWarnings_model"
    )]
    public class EventDeviceConnectionBecameFlakyConnectedAccountWarnings
    {
        [JsonConstructorAttribute]
        protected EventDeviceConnectionBecameFlakyConnectedAccountWarnings() { }

        public EventDeviceConnectionBecameFlakyConnectedAccountWarnings(
            string createdAt = default,
            string message = default,
            string warningCode = default
        )
        {
            CreatedAt = createdAt;
            Message = message;
            WarningCode = warningCode;
        }

        /// <summary>
        /// Date and time at which Seam created the warning.
        /// </summary>
        [DataMember(Name = "created_at", IsRequired = false, EmitDefaultValue = false)]
        public string CreatedAt { get; set; }

        /// <summary>
        /// Detailed description of the warning. Provides insights into the issue and potentially how to rectify it.
        /// </summary>
        [DataMember(Name = "message", IsRequired = false, EmitDefaultValue = false)]
        public string Message { get; set; }

        /// <summary>
        /// Unique identifier of the type of warning. Enables quick recognition and categorization of the issue.
        /// </summary>
        [DataMember(Name = "warning_code", IsRequired = false, EmitDefaultValue = false)]
        public string WarningCode { get; set; }

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

    [DataContract(Name = "seamModel_eventDeviceConnectionBecameFlakyDeviceErrors_model")]
    public class EventDeviceConnectionBecameFlakyDeviceErrors
    {
        [JsonConstructorAttribute]
        protected EventDeviceConnectionBecameFlakyDeviceErrors() { }

        public EventDeviceConnectionBecameFlakyDeviceErrors(
            string createdAt = default,
            string errorCode = default,
            string message = default
        )
        {
            CreatedAt = createdAt;
            ErrorCode = errorCode;
            Message = message;
        }

        /// <summary>
        /// Date and time at which Seam created the error.
        /// </summary>
        [DataMember(Name = "created_at", IsRequired = false, EmitDefaultValue = false)]
        public string CreatedAt { get; set; }

        /// <summary>
        /// Unique identifier of the type of error. Enables quick recognition and categorization of the issue.
        /// </summary>
        [DataMember(Name = "error_code", IsRequired = false, EmitDefaultValue = false)]
        public string ErrorCode { get; set; }

        /// <summary>
        /// Detailed description of the error. Provides insights into the issue and potentially how to rectify it.
        /// </summary>
        [DataMember(Name = "message", IsRequired = false, EmitDefaultValue = false)]
        public string Message { get; set; }

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

    [DataContract(Name = "seamModel_eventDeviceConnectionBecameFlakyDeviceWarnings_model")]
    public class EventDeviceConnectionBecameFlakyDeviceWarnings
    {
        [JsonConstructorAttribute]
        protected EventDeviceConnectionBecameFlakyDeviceWarnings() { }

        public EventDeviceConnectionBecameFlakyDeviceWarnings(
            string createdAt = default,
            string message = default,
            string warningCode = default
        )
        {
            CreatedAt = createdAt;
            Message = message;
            WarningCode = warningCode;
        }

        /// <summary>
        /// Date and time at which Seam created the warning.
        /// </summary>
        [DataMember(Name = "created_at", IsRequired = false, EmitDefaultValue = false)]
        public string CreatedAt { get; set; }

        /// <summary>
        /// Detailed description of the warning. Provides insights into the issue and potentially how to rectify it.
        /// </summary>
        [DataMember(Name = "message", IsRequired = false, EmitDefaultValue = false)]
        public string Message { get; set; }

        /// <summary>
        /// Unique identifier of the type of warning. Enables quick recognition and categorization of the issue.
        /// </summary>
        [DataMember(Name = "warning_code", IsRequired = false, EmitDefaultValue = false)]
        public string WarningCode { get; set; }

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
    /// Seam detected that a previously-flaky device connection stabilized.
    /// </summary>
    [DataContract(Name = "seamModel_eventDeviceConnectionStabilized_model")]
    public class EventDeviceConnectionStabilized : Event
    {
        [JsonConstructorAttribute]
        protected EventDeviceConnectionStabilized() { }

        public EventDeviceConnectionStabilized(
            object? connectedAccountCustomMetadata = default,
            string connectedAccountId = default,
            string createdAt = default,
            string? customerKey = default,
            object? deviceCustomMetadata = default,
            string deviceId = default,
            string? eventDescription = default,
            string eventId = default,
            string eventType = default,
            string occurredAt = default,
            string workspaceId = default
        )
        {
            ConnectedAccountCustomMetadata = connectedAccountCustomMetadata;
            ConnectedAccountId = connectedAccountId;
            CreatedAt = createdAt;
            CustomerKey = customerKey;
            DeviceCustomMetadata = deviceCustomMetadata;
            DeviceId = deviceId;
            EventDescription = eventDescription;
            EventId = eventId;
            EventType = eventType;
            OccurredAt = occurredAt;
            WorkspaceId = workspaceId;
        }

        /// <summary>
        /// Custom metadata of the connected account, present when connected_account_id is provided.
        /// </summary>
        [DataMember(
            Name = "connected_account_custom_metadata",
            IsRequired = false,
            EmitDefaultValue = false
        )]
        public object? ConnectedAccountCustomMetadata { get; set; }

        /// <summary>
        /// ID of the connected account associated with the event.
        /// </summary>
        [DataMember(Name = "connected_account_id", IsRequired = false, EmitDefaultValue = false)]
        public string ConnectedAccountId { get; set; }

        /// <summary>
        /// Date and time at which the event was created.
        /// </summary>
        [DataMember(Name = "created_at", IsRequired = false, EmitDefaultValue = false)]
        public override string CreatedAt { get; set; }

        /// <summary>
        /// The customer key associated with the device, if any.
        /// </summary>
        [DataMember(Name = "customer_key", IsRequired = false, EmitDefaultValue = false)]
        public string? CustomerKey { get; set; }

        /// <summary>
        /// Custom metadata of the device, present when device_id is provided.
        /// </summary>
        [DataMember(Name = "device_custom_metadata", IsRequired = false, EmitDefaultValue = false)]
        public object? DeviceCustomMetadata { get; set; }

        /// <summary>
        /// ID of the affected device.
        /// </summary>
        [DataMember(Name = "device_id", IsRequired = false, EmitDefaultValue = false)]
        public string DeviceId { get; set; }

        /// <summary>
        /// Human-readable description of the event. Persisted when the event is created (so the creating code, including a provider, can supply a tailored description) and otherwise derived from the event.
        /// </summary>
        [DataMember(Name = "event_description", IsRequired = false, EmitDefaultValue = false)]
        public override string? EventDescription { get; set; }

        /// <summary>
        /// ID of the event.
        /// </summary>
        [DataMember(Name = "event_id", IsRequired = false, EmitDefaultValue = false)]
        public override string EventId { get; set; }

        [DataMember(Name = "event_type", IsRequired = true, EmitDefaultValue = false)]
        public override string EventType { get; } = "device.connection_stabilized";

        /// <summary>
        /// Date and time at which the event occurred.
        /// </summary>
        [DataMember(Name = "occurred_at", IsRequired = false, EmitDefaultValue = false)]
        public override string OccurredAt { get; set; }

        /// <summary>
        /// ID of the workspace associated with the event.
        /// </summary>
        [DataMember(Name = "workspace_id", IsRequired = false, EmitDefaultValue = false)]
        public override string WorkspaceId { get; set; }

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
    /// A third-party subscription is required to use all device features.
    /// </summary>
    [DataContract(Name = "seamModel_eventDeviceErrorSubscriptionRequired_model")]
    public class EventDeviceErrorSubscriptionRequired : Event
    {
        [JsonConstructorAttribute]
        protected EventDeviceErrorSubscriptionRequired() { }

        public EventDeviceErrorSubscriptionRequired(
            object? connectedAccountCustomMetadata = default,
            List<EventDeviceErrorSubscriptionRequiredConnectedAccountErrors> connectedAccountErrors =
                default,
            string connectedAccountId = default,
            List<EventDeviceErrorSubscriptionRequiredConnectedAccountWarnings> connectedAccountWarnings =
                default,
            string createdAt = default,
            string? customerKey = default,
            object? deviceCustomMetadata = default,
            List<EventDeviceErrorSubscriptionRequiredDeviceErrors> deviceErrors = default,
            string deviceId = default,
            List<EventDeviceErrorSubscriptionRequiredDeviceWarnings> deviceWarnings = default,
            string? eventDescription = default,
            string eventId = default,
            string eventType = default,
            string occurredAt = default,
            string workspaceId = default
        )
        {
            ConnectedAccountCustomMetadata = connectedAccountCustomMetadata;
            ConnectedAccountErrors = connectedAccountErrors;
            ConnectedAccountId = connectedAccountId;
            ConnectedAccountWarnings = connectedAccountWarnings;
            CreatedAt = createdAt;
            CustomerKey = customerKey;
            DeviceCustomMetadata = deviceCustomMetadata;
            DeviceErrors = deviceErrors;
            DeviceId = deviceId;
            DeviceWarnings = deviceWarnings;
            EventDescription = eventDescription;
            EventId = eventId;
            EventType = eventType;
            OccurredAt = occurredAt;
            WorkspaceId = workspaceId;
        }

        /// <summary>
        /// Custom metadata of the connected account, present when connected_account_id is provided.
        /// </summary>
        [DataMember(
            Name = "connected_account_custom_metadata",
            IsRequired = false,
            EmitDefaultValue = false
        )]
        public object? ConnectedAccountCustomMetadata { get; set; }

        /// <summary>
        /// Errors associated with the connected account.
        /// </summary>
        [DataMember(
            Name = "connected_account_errors",
            IsRequired = false,
            EmitDefaultValue = false
        )]
        public List<EventDeviceErrorSubscriptionRequiredConnectedAccountErrors> ConnectedAccountErrors { get; set; }

        /// <summary>
        /// ID of the connected account associated with the event.
        /// </summary>
        [DataMember(Name = "connected_account_id", IsRequired = false, EmitDefaultValue = false)]
        public string ConnectedAccountId { get; set; }

        /// <summary>
        /// Warnings associated with the connected account.
        /// </summary>
        [DataMember(
            Name = "connected_account_warnings",
            IsRequired = false,
            EmitDefaultValue = false
        )]
        public List<EventDeviceErrorSubscriptionRequiredConnectedAccountWarnings> ConnectedAccountWarnings { get; set; }

        /// <summary>
        /// Date and time at which the event was created.
        /// </summary>
        [DataMember(Name = "created_at", IsRequired = false, EmitDefaultValue = false)]
        public override string CreatedAt { get; set; }

        /// <summary>
        /// The customer key associated with the device, if any.
        /// </summary>
        [DataMember(Name = "customer_key", IsRequired = false, EmitDefaultValue = false)]
        public string? CustomerKey { get; set; }

        /// <summary>
        /// Custom metadata of the device, present when device_id is provided.
        /// </summary>
        [DataMember(Name = "device_custom_metadata", IsRequired = false, EmitDefaultValue = false)]
        public object? DeviceCustomMetadata { get; set; }

        /// <summary>
        /// Errors associated with the device.
        /// </summary>
        [DataMember(Name = "device_errors", IsRequired = false, EmitDefaultValue = false)]
        public List<EventDeviceErrorSubscriptionRequiredDeviceErrors> DeviceErrors { get; set; }

        /// <summary>
        /// ID of the affected device.
        /// </summary>
        [DataMember(Name = "device_id", IsRequired = false, EmitDefaultValue = false)]
        public string DeviceId { get; set; }

        /// <summary>
        /// Warnings associated with the device.
        /// </summary>
        [DataMember(Name = "device_warnings", IsRequired = false, EmitDefaultValue = false)]
        public List<EventDeviceErrorSubscriptionRequiredDeviceWarnings> DeviceWarnings { get; set; }

        /// <summary>
        /// Human-readable description of the event. Persisted when the event is created (so the creating code, including a provider, can supply a tailored description) and otherwise derived from the event.
        /// </summary>
        [DataMember(Name = "event_description", IsRequired = false, EmitDefaultValue = false)]
        public override string? EventDescription { get; set; }

        /// <summary>
        /// ID of the event.
        /// </summary>
        [DataMember(Name = "event_id", IsRequired = false, EmitDefaultValue = false)]
        public override string EventId { get; set; }

        [DataMember(Name = "event_type", IsRequired = true, EmitDefaultValue = false)]
        public override string EventType { get; } = "device.error.subscription_required";

        /// <summary>
        /// Date and time at which the event occurred.
        /// </summary>
        [DataMember(Name = "occurred_at", IsRequired = false, EmitDefaultValue = false)]
        public override string OccurredAt { get; set; }

        /// <summary>
        /// ID of the workspace associated with the event.
        /// </summary>
        [DataMember(Name = "workspace_id", IsRequired = false, EmitDefaultValue = false)]
        public override string WorkspaceId { get; set; }

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
        Name = "seamModel_eventDeviceErrorSubscriptionRequiredConnectedAccountErrors_model"
    )]
    public class EventDeviceErrorSubscriptionRequiredConnectedAccountErrors
    {
        [JsonConstructorAttribute]
        protected EventDeviceErrorSubscriptionRequiredConnectedAccountErrors() { }

        public EventDeviceErrorSubscriptionRequiredConnectedAccountErrors(
            string createdAt = default,
            string errorCode = default,
            string message = default
        )
        {
            CreatedAt = createdAt;
            ErrorCode = errorCode;
            Message = message;
        }

        /// <summary>
        /// Date and time at which Seam created the error.
        /// </summary>
        [DataMember(Name = "created_at", IsRequired = false, EmitDefaultValue = false)]
        public string CreatedAt { get; set; }

        /// <summary>
        /// Unique identifier of the type of error. Enables quick recognition and categorization of the issue.
        /// </summary>
        [DataMember(Name = "error_code", IsRequired = false, EmitDefaultValue = false)]
        public string ErrorCode { get; set; }

        /// <summary>
        /// Detailed description of the error. Provides insights into the issue and potentially how to rectify it.
        /// </summary>
        [DataMember(Name = "message", IsRequired = false, EmitDefaultValue = false)]
        public string Message { get; set; }

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
        Name = "seamModel_eventDeviceErrorSubscriptionRequiredConnectedAccountWarnings_model"
    )]
    public class EventDeviceErrorSubscriptionRequiredConnectedAccountWarnings
    {
        [JsonConstructorAttribute]
        protected EventDeviceErrorSubscriptionRequiredConnectedAccountWarnings() { }

        public EventDeviceErrorSubscriptionRequiredConnectedAccountWarnings(
            string createdAt = default,
            string message = default,
            string warningCode = default
        )
        {
            CreatedAt = createdAt;
            Message = message;
            WarningCode = warningCode;
        }

        /// <summary>
        /// Date and time at which Seam created the warning.
        /// </summary>
        [DataMember(Name = "created_at", IsRequired = false, EmitDefaultValue = false)]
        public string CreatedAt { get; set; }

        /// <summary>
        /// Detailed description of the warning. Provides insights into the issue and potentially how to rectify it.
        /// </summary>
        [DataMember(Name = "message", IsRequired = false, EmitDefaultValue = false)]
        public string Message { get; set; }

        /// <summary>
        /// Unique identifier of the type of warning. Enables quick recognition and categorization of the issue.
        /// </summary>
        [DataMember(Name = "warning_code", IsRequired = false, EmitDefaultValue = false)]
        public string WarningCode { get; set; }

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

    [DataContract(Name = "seamModel_eventDeviceErrorSubscriptionRequiredDeviceErrors_model")]
    public class EventDeviceErrorSubscriptionRequiredDeviceErrors
    {
        [JsonConstructorAttribute]
        protected EventDeviceErrorSubscriptionRequiredDeviceErrors() { }

        public EventDeviceErrorSubscriptionRequiredDeviceErrors(
            string createdAt = default,
            string errorCode = default,
            string message = default
        )
        {
            CreatedAt = createdAt;
            ErrorCode = errorCode;
            Message = message;
        }

        /// <summary>
        /// Date and time at which Seam created the error.
        /// </summary>
        [DataMember(Name = "created_at", IsRequired = false, EmitDefaultValue = false)]
        public string CreatedAt { get; set; }

        /// <summary>
        /// Unique identifier of the type of error. Enables quick recognition and categorization of the issue.
        /// </summary>
        [DataMember(Name = "error_code", IsRequired = false, EmitDefaultValue = false)]
        public string ErrorCode { get; set; }

        /// <summary>
        /// Detailed description of the error. Provides insights into the issue and potentially how to rectify it.
        /// </summary>
        [DataMember(Name = "message", IsRequired = false, EmitDefaultValue = false)]
        public string Message { get; set; }

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

    [DataContract(Name = "seamModel_eventDeviceErrorSubscriptionRequiredDeviceWarnings_model")]
    public class EventDeviceErrorSubscriptionRequiredDeviceWarnings
    {
        [JsonConstructorAttribute]
        protected EventDeviceErrorSubscriptionRequiredDeviceWarnings() { }

        public EventDeviceErrorSubscriptionRequiredDeviceWarnings(
            string createdAt = default,
            string message = default,
            string warningCode = default
        )
        {
            CreatedAt = createdAt;
            Message = message;
            WarningCode = warningCode;
        }

        /// <summary>
        /// Date and time at which Seam created the warning.
        /// </summary>
        [DataMember(Name = "created_at", IsRequired = false, EmitDefaultValue = false)]
        public string CreatedAt { get; set; }

        /// <summary>
        /// Detailed description of the warning. Provides insights into the issue and potentially how to rectify it.
        /// </summary>
        [DataMember(Name = "message", IsRequired = false, EmitDefaultValue = false)]
        public string Message { get; set; }

        /// <summary>
        /// Unique identifier of the type of warning. Enables quick recognition and categorization of the issue.
        /// </summary>
        [DataMember(Name = "warning_code", IsRequired = false, EmitDefaultValue = false)]
        public string WarningCode { get; set; }

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
    /// A third-party subscription is active or no longer required to use all device features.
    /// </summary>
    [DataContract(Name = "seamModel_eventDeviceErrorSubscriptionRequiredResolved_model")]
    public class EventDeviceErrorSubscriptionRequiredResolved : Event
    {
        [JsonConstructorAttribute]
        protected EventDeviceErrorSubscriptionRequiredResolved() { }

        public EventDeviceErrorSubscriptionRequiredResolved(
            object? connectedAccountCustomMetadata = default,
            string connectedAccountId = default,
            string createdAt = default,
            string? customerKey = default,
            object? deviceCustomMetadata = default,
            string deviceId = default,
            string? eventDescription = default,
            string eventId = default,
            string eventType = default,
            string occurredAt = default,
            string workspaceId = default
        )
        {
            ConnectedAccountCustomMetadata = connectedAccountCustomMetadata;
            ConnectedAccountId = connectedAccountId;
            CreatedAt = createdAt;
            CustomerKey = customerKey;
            DeviceCustomMetadata = deviceCustomMetadata;
            DeviceId = deviceId;
            EventDescription = eventDescription;
            EventId = eventId;
            EventType = eventType;
            OccurredAt = occurredAt;
            WorkspaceId = workspaceId;
        }

        /// <summary>
        /// Custom metadata of the connected account, present when connected_account_id is provided.
        /// </summary>
        [DataMember(
            Name = "connected_account_custom_metadata",
            IsRequired = false,
            EmitDefaultValue = false
        )]
        public object? ConnectedAccountCustomMetadata { get; set; }

        /// <summary>
        /// ID of the connected account associated with the event.
        /// </summary>
        [DataMember(Name = "connected_account_id", IsRequired = false, EmitDefaultValue = false)]
        public string ConnectedAccountId { get; set; }

        /// <summary>
        /// Date and time at which the event was created.
        /// </summary>
        [DataMember(Name = "created_at", IsRequired = false, EmitDefaultValue = false)]
        public override string CreatedAt { get; set; }

        /// <summary>
        /// The customer key associated with the device, if any.
        /// </summary>
        [DataMember(Name = "customer_key", IsRequired = false, EmitDefaultValue = false)]
        public string? CustomerKey { get; set; }

        /// <summary>
        /// Custom metadata of the device, present when device_id is provided.
        /// </summary>
        [DataMember(Name = "device_custom_metadata", IsRequired = false, EmitDefaultValue = false)]
        public object? DeviceCustomMetadata { get; set; }

        /// <summary>
        /// ID of the affected device.
        /// </summary>
        [DataMember(Name = "device_id", IsRequired = false, EmitDefaultValue = false)]
        public string DeviceId { get; set; }

        /// <summary>
        /// Human-readable description of the event. Persisted when the event is created (so the creating code, including a provider, can supply a tailored description) and otherwise derived from the event.
        /// </summary>
        [DataMember(Name = "event_description", IsRequired = false, EmitDefaultValue = false)]
        public override string? EventDescription { get; set; }

        /// <summary>
        /// ID of the event.
        /// </summary>
        [DataMember(Name = "event_id", IsRequired = false, EmitDefaultValue = false)]
        public override string EventId { get; set; }

        [DataMember(Name = "event_type", IsRequired = true, EmitDefaultValue = false)]
        public override string EventType { get; } = "device.error.subscription_required.resolved";

        /// <summary>
        /// Date and time at which the event occurred.
        /// </summary>
        [DataMember(Name = "occurred_at", IsRequired = false, EmitDefaultValue = false)]
        public override string OccurredAt { get; set; }

        /// <summary>
        /// ID of the workspace associated with the event.
        /// </summary>
        [DataMember(Name = "workspace_id", IsRequired = false, EmitDefaultValue = false)]
        public override string WorkspaceId { get; set; }

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
    /// An accessory keypad was connected to a device.
    /// </summary>
    [DataContract(Name = "seamModel_eventDeviceAccessoryKeypadConnected_model")]
    public class EventDeviceAccessoryKeypadConnected : Event
    {
        [JsonConstructorAttribute]
        protected EventDeviceAccessoryKeypadConnected() { }

        public EventDeviceAccessoryKeypadConnected(
            object? connectedAccountCustomMetadata = default,
            string connectedAccountId = default,
            string createdAt = default,
            string? customerKey = default,
            object? deviceCustomMetadata = default,
            string deviceId = default,
            string? eventDescription = default,
            string eventId = default,
            string eventType = default,
            string occurredAt = default,
            string workspaceId = default
        )
        {
            ConnectedAccountCustomMetadata = connectedAccountCustomMetadata;
            ConnectedAccountId = connectedAccountId;
            CreatedAt = createdAt;
            CustomerKey = customerKey;
            DeviceCustomMetadata = deviceCustomMetadata;
            DeviceId = deviceId;
            EventDescription = eventDescription;
            EventId = eventId;
            EventType = eventType;
            OccurredAt = occurredAt;
            WorkspaceId = workspaceId;
        }

        /// <summary>
        /// Custom metadata of the connected account, present when connected_account_id is provided.
        /// </summary>
        [DataMember(
            Name = "connected_account_custom_metadata",
            IsRequired = false,
            EmitDefaultValue = false
        )]
        public object? ConnectedAccountCustomMetadata { get; set; }

        /// <summary>
        /// ID of the connected account associated with the event.
        /// </summary>
        [DataMember(Name = "connected_account_id", IsRequired = false, EmitDefaultValue = false)]
        public string ConnectedAccountId { get; set; }

        /// <summary>
        /// Date and time at which the event was created.
        /// </summary>
        [DataMember(Name = "created_at", IsRequired = false, EmitDefaultValue = false)]
        public override string CreatedAt { get; set; }

        /// <summary>
        /// The customer key associated with the device, if any.
        /// </summary>
        [DataMember(Name = "customer_key", IsRequired = false, EmitDefaultValue = false)]
        public string? CustomerKey { get; set; }

        /// <summary>
        /// Custom metadata of the device, present when device_id is provided.
        /// </summary>
        [DataMember(Name = "device_custom_metadata", IsRequired = false, EmitDefaultValue = false)]
        public object? DeviceCustomMetadata { get; set; }

        /// <summary>
        /// ID of the affected device.
        /// </summary>
        [DataMember(Name = "device_id", IsRequired = false, EmitDefaultValue = false)]
        public string DeviceId { get; set; }

        /// <summary>
        /// Human-readable description of the event. Persisted when the event is created (so the creating code, including a provider, can supply a tailored description) and otherwise derived from the event.
        /// </summary>
        [DataMember(Name = "event_description", IsRequired = false, EmitDefaultValue = false)]
        public override string? EventDescription { get; set; }

        /// <summary>
        /// ID of the event.
        /// </summary>
        [DataMember(Name = "event_id", IsRequired = false, EmitDefaultValue = false)]
        public override string EventId { get; set; }

        [DataMember(Name = "event_type", IsRequired = true, EmitDefaultValue = false)]
        public override string EventType { get; } = "device.accessory_keypad_connected";

        /// <summary>
        /// Date and time at which the event occurred.
        /// </summary>
        [DataMember(Name = "occurred_at", IsRequired = false, EmitDefaultValue = false)]
        public override string OccurredAt { get; set; }

        /// <summary>
        /// ID of the workspace associated with the event.
        /// </summary>
        [DataMember(Name = "workspace_id", IsRequired = false, EmitDefaultValue = false)]
        public override string WorkspaceId { get; set; }

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
    /// An accessory keypad was disconnected from a device.
    /// </summary>
    [DataContract(Name = "seamModel_eventDeviceAccessoryKeypadDisconnected_model")]
    public class EventDeviceAccessoryKeypadDisconnected : Event
    {
        [JsonConstructorAttribute]
        protected EventDeviceAccessoryKeypadDisconnected() { }

        public EventDeviceAccessoryKeypadDisconnected(
            object? connectedAccountCustomMetadata = default,
            List<EventDeviceAccessoryKeypadDisconnectedConnectedAccountErrors> connectedAccountErrors =
                default,
            string connectedAccountId = default,
            List<EventDeviceAccessoryKeypadDisconnectedConnectedAccountWarnings> connectedAccountWarnings =
                default,
            string createdAt = default,
            string? customerKey = default,
            object? deviceCustomMetadata = default,
            List<EventDeviceAccessoryKeypadDisconnectedDeviceErrors> deviceErrors = default,
            string deviceId = default,
            List<EventDeviceAccessoryKeypadDisconnectedDeviceWarnings> deviceWarnings = default,
            string? eventDescription = default,
            string eventId = default,
            string eventType = default,
            string occurredAt = default,
            string workspaceId = default
        )
        {
            ConnectedAccountCustomMetadata = connectedAccountCustomMetadata;
            ConnectedAccountErrors = connectedAccountErrors;
            ConnectedAccountId = connectedAccountId;
            ConnectedAccountWarnings = connectedAccountWarnings;
            CreatedAt = createdAt;
            CustomerKey = customerKey;
            DeviceCustomMetadata = deviceCustomMetadata;
            DeviceErrors = deviceErrors;
            DeviceId = deviceId;
            DeviceWarnings = deviceWarnings;
            EventDescription = eventDescription;
            EventId = eventId;
            EventType = eventType;
            OccurredAt = occurredAt;
            WorkspaceId = workspaceId;
        }

        /// <summary>
        /// Custom metadata of the connected account, present when connected_account_id is provided.
        /// </summary>
        [DataMember(
            Name = "connected_account_custom_metadata",
            IsRequired = false,
            EmitDefaultValue = false
        )]
        public object? ConnectedAccountCustomMetadata { get; set; }

        /// <summary>
        /// Errors associated with the connected account.
        /// </summary>
        [DataMember(
            Name = "connected_account_errors",
            IsRequired = false,
            EmitDefaultValue = false
        )]
        public List<EventDeviceAccessoryKeypadDisconnectedConnectedAccountErrors> ConnectedAccountErrors { get; set; }

        /// <summary>
        /// ID of the connected account associated with the event.
        /// </summary>
        [DataMember(Name = "connected_account_id", IsRequired = false, EmitDefaultValue = false)]
        public string ConnectedAccountId { get; set; }

        /// <summary>
        /// Warnings associated with the connected account.
        /// </summary>
        [DataMember(
            Name = "connected_account_warnings",
            IsRequired = false,
            EmitDefaultValue = false
        )]
        public List<EventDeviceAccessoryKeypadDisconnectedConnectedAccountWarnings> ConnectedAccountWarnings { get; set; }

        /// <summary>
        /// Date and time at which the event was created.
        /// </summary>
        [DataMember(Name = "created_at", IsRequired = false, EmitDefaultValue = false)]
        public override string CreatedAt { get; set; }

        /// <summary>
        /// The customer key associated with the device, if any.
        /// </summary>
        [DataMember(Name = "customer_key", IsRequired = false, EmitDefaultValue = false)]
        public string? CustomerKey { get; set; }

        /// <summary>
        /// Custom metadata of the device, present when device_id is provided.
        /// </summary>
        [DataMember(Name = "device_custom_metadata", IsRequired = false, EmitDefaultValue = false)]
        public object? DeviceCustomMetadata { get; set; }

        /// <summary>
        /// Errors associated with the device.
        /// </summary>
        [DataMember(Name = "device_errors", IsRequired = false, EmitDefaultValue = false)]
        public List<EventDeviceAccessoryKeypadDisconnectedDeviceErrors> DeviceErrors { get; set; }

        /// <summary>
        /// ID of the affected device.
        /// </summary>
        [DataMember(Name = "device_id", IsRequired = false, EmitDefaultValue = false)]
        public string DeviceId { get; set; }

        /// <summary>
        /// Warnings associated with the device.
        /// </summary>
        [DataMember(Name = "device_warnings", IsRequired = false, EmitDefaultValue = false)]
        public List<EventDeviceAccessoryKeypadDisconnectedDeviceWarnings> DeviceWarnings { get; set; }

        /// <summary>
        /// Human-readable description of the event. Persisted when the event is created (so the creating code, including a provider, can supply a tailored description) and otherwise derived from the event.
        /// </summary>
        [DataMember(Name = "event_description", IsRequired = false, EmitDefaultValue = false)]
        public override string? EventDescription { get; set; }

        /// <summary>
        /// ID of the event.
        /// </summary>
        [DataMember(Name = "event_id", IsRequired = false, EmitDefaultValue = false)]
        public override string EventId { get; set; }

        [DataMember(Name = "event_type", IsRequired = true, EmitDefaultValue = false)]
        public override string EventType { get; } = "device.accessory_keypad_disconnected";

        /// <summary>
        /// Date and time at which the event occurred.
        /// </summary>
        [DataMember(Name = "occurred_at", IsRequired = false, EmitDefaultValue = false)]
        public override string OccurredAt { get; set; }

        /// <summary>
        /// ID of the workspace associated with the event.
        /// </summary>
        [DataMember(Name = "workspace_id", IsRequired = false, EmitDefaultValue = false)]
        public override string WorkspaceId { get; set; }

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
        Name = "seamModel_eventDeviceAccessoryKeypadDisconnectedConnectedAccountErrors_model"
    )]
    public class EventDeviceAccessoryKeypadDisconnectedConnectedAccountErrors
    {
        [JsonConstructorAttribute]
        protected EventDeviceAccessoryKeypadDisconnectedConnectedAccountErrors() { }

        public EventDeviceAccessoryKeypadDisconnectedConnectedAccountErrors(
            string createdAt = default,
            string errorCode = default,
            string message = default
        )
        {
            CreatedAt = createdAt;
            ErrorCode = errorCode;
            Message = message;
        }

        /// <summary>
        /// Date and time at which Seam created the error.
        /// </summary>
        [DataMember(Name = "created_at", IsRequired = false, EmitDefaultValue = false)]
        public string CreatedAt { get; set; }

        /// <summary>
        /// Unique identifier of the type of error. Enables quick recognition and categorization of the issue.
        /// </summary>
        [DataMember(Name = "error_code", IsRequired = false, EmitDefaultValue = false)]
        public string ErrorCode { get; set; }

        /// <summary>
        /// Detailed description of the error. Provides insights into the issue and potentially how to rectify it.
        /// </summary>
        [DataMember(Name = "message", IsRequired = false, EmitDefaultValue = false)]
        public string Message { get; set; }

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
        Name = "seamModel_eventDeviceAccessoryKeypadDisconnectedConnectedAccountWarnings_model"
    )]
    public class EventDeviceAccessoryKeypadDisconnectedConnectedAccountWarnings
    {
        [JsonConstructorAttribute]
        protected EventDeviceAccessoryKeypadDisconnectedConnectedAccountWarnings() { }

        public EventDeviceAccessoryKeypadDisconnectedConnectedAccountWarnings(
            string createdAt = default,
            string message = default,
            string warningCode = default
        )
        {
            CreatedAt = createdAt;
            Message = message;
            WarningCode = warningCode;
        }

        /// <summary>
        /// Date and time at which Seam created the warning.
        /// </summary>
        [DataMember(Name = "created_at", IsRequired = false, EmitDefaultValue = false)]
        public string CreatedAt { get; set; }

        /// <summary>
        /// Detailed description of the warning. Provides insights into the issue and potentially how to rectify it.
        /// </summary>
        [DataMember(Name = "message", IsRequired = false, EmitDefaultValue = false)]
        public string Message { get; set; }

        /// <summary>
        /// Unique identifier of the type of warning. Enables quick recognition and categorization of the issue.
        /// </summary>
        [DataMember(Name = "warning_code", IsRequired = false, EmitDefaultValue = false)]
        public string WarningCode { get; set; }

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

    [DataContract(Name = "seamModel_eventDeviceAccessoryKeypadDisconnectedDeviceErrors_model")]
    public class EventDeviceAccessoryKeypadDisconnectedDeviceErrors
    {
        [JsonConstructorAttribute]
        protected EventDeviceAccessoryKeypadDisconnectedDeviceErrors() { }

        public EventDeviceAccessoryKeypadDisconnectedDeviceErrors(
            string createdAt = default,
            string errorCode = default,
            string message = default
        )
        {
            CreatedAt = createdAt;
            ErrorCode = errorCode;
            Message = message;
        }

        /// <summary>
        /// Date and time at which Seam created the error.
        /// </summary>
        [DataMember(Name = "created_at", IsRequired = false, EmitDefaultValue = false)]
        public string CreatedAt { get; set; }

        /// <summary>
        /// Unique identifier of the type of error. Enables quick recognition and categorization of the issue.
        /// </summary>
        [DataMember(Name = "error_code", IsRequired = false, EmitDefaultValue = false)]
        public string ErrorCode { get; set; }

        /// <summary>
        /// Detailed description of the error. Provides insights into the issue and potentially how to rectify it.
        /// </summary>
        [DataMember(Name = "message", IsRequired = false, EmitDefaultValue = false)]
        public string Message { get; set; }

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

    [DataContract(Name = "seamModel_eventDeviceAccessoryKeypadDisconnectedDeviceWarnings_model")]
    public class EventDeviceAccessoryKeypadDisconnectedDeviceWarnings
    {
        [JsonConstructorAttribute]
        protected EventDeviceAccessoryKeypadDisconnectedDeviceWarnings() { }

        public EventDeviceAccessoryKeypadDisconnectedDeviceWarnings(
            string createdAt = default,
            string message = default,
            string warningCode = default
        )
        {
            CreatedAt = createdAt;
            Message = message;
            WarningCode = warningCode;
        }

        /// <summary>
        /// Date and time at which Seam created the warning.
        /// </summary>
        [DataMember(Name = "created_at", IsRequired = false, EmitDefaultValue = false)]
        public string CreatedAt { get; set; }

        /// <summary>
        /// Detailed description of the warning. Provides insights into the issue and potentially how to rectify it.
        /// </summary>
        [DataMember(Name = "message", IsRequired = false, EmitDefaultValue = false)]
        public string Message { get; set; }

        /// <summary>
        /// Unique identifier of the type of warning. Enables quick recognition and categorization of the issue.
        /// </summary>
        [DataMember(Name = "warning_code", IsRequired = false, EmitDefaultValue = false)]
        public string WarningCode { get; set; }

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
    /// Extended periods of noise or noise exceeding a [threshold](https://docs.seam.co/capability-guides/noise-sensors#what-is-a-threshold) were detected.
    /// </summary>
    [DataContract(Name = "seamModel_eventNoiseSensorNoiseThresholdTriggered_model")]
    public class EventNoiseSensorNoiseThresholdTriggered : Event
    {
        [JsonConstructorAttribute]
        protected EventNoiseSensorNoiseThresholdTriggered() { }

        public EventNoiseSensorNoiseThresholdTriggered(
            object? connectedAccountCustomMetadata = default,
            string connectedAccountId = default,
            string createdAt = default,
            string? customerKey = default,
            object? deviceCustomMetadata = default,
            string deviceId = default,
            string? eventDescription = default,
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
            ConnectedAccountCustomMetadata = connectedAccountCustomMetadata;
            ConnectedAccountId = connectedAccountId;
            CreatedAt = createdAt;
            CustomerKey = customerKey;
            DeviceCustomMetadata = deviceCustomMetadata;
            DeviceId = deviceId;
            EventDescription = eventDescription;
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

        /// <summary>
        /// Custom metadata of the connected account, present when connected_account_id is provided.
        /// </summary>
        [DataMember(
            Name = "connected_account_custom_metadata",
            IsRequired = false,
            EmitDefaultValue = false
        )]
        public object? ConnectedAccountCustomMetadata { get; set; }

        /// <summary>
        /// ID of the connected account associated with the event.
        /// </summary>
        [DataMember(Name = "connected_account_id", IsRequired = false, EmitDefaultValue = false)]
        public string ConnectedAccountId { get; set; }

        /// <summary>
        /// Date and time at which the event was created.
        /// </summary>
        [DataMember(Name = "created_at", IsRequired = false, EmitDefaultValue = false)]
        public override string CreatedAt { get; set; }

        /// <summary>
        /// The customer key associated with the device, if any.
        /// </summary>
        [DataMember(Name = "customer_key", IsRequired = false, EmitDefaultValue = false)]
        public string? CustomerKey { get; set; }

        /// <summary>
        /// Custom metadata of the device, present when device_id is provided.
        /// </summary>
        [DataMember(Name = "device_custom_metadata", IsRequired = false, EmitDefaultValue = false)]
        public object? DeviceCustomMetadata { get; set; }

        /// <summary>
        /// ID of the affected device.
        /// </summary>
        [DataMember(Name = "device_id", IsRequired = false, EmitDefaultValue = false)]
        public string DeviceId { get; set; }

        /// <summary>
        /// Human-readable description of the event. Persisted when the event is created (so the creating code, including a provider, can supply a tailored description) and otherwise derived from the event.
        /// </summary>
        [DataMember(Name = "event_description", IsRequired = false, EmitDefaultValue = false)]
        public override string? EventDescription { get; set; }

        /// <summary>
        /// ID of the event.
        /// </summary>
        [DataMember(Name = "event_id", IsRequired = false, EmitDefaultValue = false)]
        public override string EventId { get; set; }

        [DataMember(Name = "event_type", IsRequired = true, EmitDefaultValue = false)]
        public override string EventType { get; } = "noise_sensor.noise_threshold_triggered";

        /// <summary>
        /// Metadata from Minut.
        /// </summary>
        [DataMember(Name = "minut_metadata", IsRequired = false, EmitDefaultValue = false)]
        public object? MinutMetadata { get; set; }

        /// <summary>
        /// Detected noise level in decibels.
        /// </summary>
        [DataMember(Name = "noise_level_decibels", IsRequired = false, EmitDefaultValue = false)]
        public float? NoiseLevelDecibels { get; set; }

        /// <summary>
        /// Detected noise level in Noiseaware Noise Risk Score (NRS).
        /// </summary>
        [DataMember(Name = "noise_level_nrs", IsRequired = false, EmitDefaultValue = false)]
        public float? NoiseLevelNrs { get; set; }

        /// <summary>
        /// ID of the noise threshold that was triggered.
        /// </summary>
        [DataMember(Name = "noise_threshold_id", IsRequired = false, EmitDefaultValue = false)]
        public string? NoiseThresholdId { get; set; }

        /// <summary>
        /// Name of the noise threshold that was triggered.
        /// </summary>
        [DataMember(Name = "noise_threshold_name", IsRequired = false, EmitDefaultValue = false)]
        public string? NoiseThresholdName { get; set; }

        /// <summary>
        /// Metadata from Noiseaware.
        /// </summary>
        [DataMember(Name = "noiseaware_metadata", IsRequired = false, EmitDefaultValue = false)]
        public object? NoiseawareMetadata { get; set; }

        /// <summary>
        /// Date and time at which the event occurred.
        /// </summary>
        [DataMember(Name = "occurred_at", IsRequired = false, EmitDefaultValue = false)]
        public override string OccurredAt { get; set; }

        /// <summary>
        /// ID of the workspace associated with the event.
        /// </summary>
        [DataMember(Name = "workspace_id", IsRequired = false, EmitDefaultValue = false)]
        public override string WorkspaceId { get; set; }

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
    /// A [lock](https://docs.seam.co/low-level-apis/smart-locks) was locked.
    /// </summary>
    [DataContract(Name = "seamModel_eventLockLocked_model")]
    public class EventLockLocked : Event
    {
        [JsonConstructorAttribute]
        protected EventLockLocked() { }

        public EventLockLocked(
            string? accessCodeId = default,
            bool? accessCodeIsManaged = default,
            string? acsEntranceId = default,
            string? acsSystemId = default,
            string? acsUserId = default,
            string? actionAttemptId = default,
            string? code = default,
            object? connectedAccountCustomMetadata = default,
            string connectedAccountId = default,
            string createdAt = default,
            string? customerKey = default,
            object? deviceCustomMetadata = default,
            string deviceId = default,
            string? eventDescription = default,
            string eventId = default,
            string eventType = default,
            bool? isViaBluetooth = default,
            bool? isViaNfc = default,
            EventLockLocked.MethodEnum method = default,
            string occurredAt = default,
            string? userIdentityId = default,
            string workspaceId = default
        )
        {
            AccessCodeId = accessCodeId;
            AccessCodeIsManaged = accessCodeIsManaged;
            AcsEntranceId = acsEntranceId;
            AcsSystemId = acsSystemId;
            AcsUserId = acsUserId;
            ActionAttemptId = actionAttemptId;
            Code = code;
            ConnectedAccountCustomMetadata = connectedAccountCustomMetadata;
            ConnectedAccountId = connectedAccountId;
            CreatedAt = createdAt;
            CustomerKey = customerKey;
            DeviceCustomMetadata = deviceCustomMetadata;
            DeviceId = deviceId;
            EventDescription = eventDescription;
            EventId = eventId;
            EventType = eventType;
            IsViaBluetooth = isViaBluetooth;
            IsViaNfc = isViaNfc;
            Method = method;
            OccurredAt = occurredAt;
            UserIdentityId = userIdentityId;
            WorkspaceId = workspaceId;
        }

        /// <summary>
        /// Method by which the lock was locked. `keycode`: an access code was used (see `access_code_id`). `manual`: a physical action such as a thumbturn or button press. `remote`: a remote action via an app, Bluetooth, or the Seam API (see `action_attempt_id` if Seam-initiated; see `is_via_bluetooth` or `is_via_nfc` for the transport). `automatic`: triggered automatically, for example by an auto-relock timer. `unknown`: could not be determined.
        /// </summary>
        [JsonConverter(typeof(SafeStringEnumConverter))]
        public enum MethodEnum
        {
            [EnumMember(Value = "unrecognized")]
            Unrecognized = 0,

            [EnumMember(Value = "keycode")]
            Keycode = 1,

            [EnumMember(Value = "manual")]
            Manual = 2,

            [EnumMember(Value = "automatic")]
            Automatic = 3,

            [EnumMember(Value = "unknown")]
            Unknown = 4,

            [EnumMember(Value = "remote")]
            Remote = 5,

            [EnumMember(Value = "card")]
            Card = 6,
        }

        /// <summary>
        /// ID of the access code that was used to lock the device.
        /// </summary>
        [DataMember(Name = "access_code_id", IsRequired = false, EmitDefaultValue = false)]
        public string? AccessCodeId { get; set; }

        /// <summary>
        /// Whether the access code is managed by Seam (true) or unmanaged (false). Only present when access_code_id is set.
        /// </summary>
        [DataMember(Name = "access_code_is_managed", IsRequired = false, EmitDefaultValue = false)]
        public bool? AccessCodeIsManaged { get; set; }

        /// <summary>
        /// undocumented: Unreleased.
        ///       ---
        ///       ID of the ACS entrance associated with the lock event.
        /// </summary>
        [DataMember(Name = "acs_entrance_id", IsRequired = false, EmitDefaultValue = false)]
        public string? AcsEntranceId { get; set; }

        /// <summary>
        /// undocumented: Unreleased.
        ///       ---
        ///       ID of the ACS system associated with the lock event.
        /// </summary>
        [DataMember(Name = "acs_system_id", IsRequired = false, EmitDefaultValue = false)]
        public string? AcsSystemId { get; set; }

        /// <summary>
        /// undocumented: Unreleased.
        ///       ---
        ///       ID of the ACS user associated with the lock event.
        /// </summary>
        [DataMember(Name = "acs_user_id", IsRequired = false, EmitDefaultValue = false)]
        public string? AcsUserId { get; set; }

        /// <summary>
        /// ID of the Seam action attempt that triggered this lock. Present only when the lock was initiated through Seam (via a `LOCK_DOOR` action attempt).
        /// </summary>
        [DataMember(Name = "action_attempt_id", IsRequired = false, EmitDefaultValue = false)]
        public string? ActionAttemptId { get; set; }

        /// <summary>
        /// Code (PIN) that was used to lock the device, if known. Taken from the matched managed or unmanaged access code, or from the code reported by the provider when no access code matched.
        /// </summary>
        [DataMember(Name = "code", IsRequired = false, EmitDefaultValue = false)]
        public string? Code { get; set; }

        /// <summary>
        /// Custom metadata of the connected account, present when connected_account_id is provided.
        /// </summary>
        [DataMember(
            Name = "connected_account_custom_metadata",
            IsRequired = false,
            EmitDefaultValue = false
        )]
        public object? ConnectedAccountCustomMetadata { get; set; }

        /// <summary>
        /// ID of the connected account associated with the event.
        /// </summary>
        [DataMember(Name = "connected_account_id", IsRequired = false, EmitDefaultValue = false)]
        public string ConnectedAccountId { get; set; }

        /// <summary>
        /// Date and time at which the event was created.
        /// </summary>
        [DataMember(Name = "created_at", IsRequired = false, EmitDefaultValue = false)]
        public override string CreatedAt { get; set; }

        /// <summary>
        /// The customer key associated with the device, if any.
        /// </summary>
        [DataMember(Name = "customer_key", IsRequired = false, EmitDefaultValue = false)]
        public string? CustomerKey { get; set; }

        /// <summary>
        /// Custom metadata of the device, present when device_id is provided.
        /// </summary>
        [DataMember(Name = "device_custom_metadata", IsRequired = false, EmitDefaultValue = false)]
        public object? DeviceCustomMetadata { get; set; }

        /// <summary>
        /// ID of the affected device.
        /// </summary>
        [DataMember(Name = "device_id", IsRequired = false, EmitDefaultValue = false)]
        public string DeviceId { get; set; }

        /// <summary>
        /// Human-readable description of the event. Persisted when the event is created (so the creating code, including a provider, can supply a tailored description) and otherwise derived from the event.
        /// </summary>
        [DataMember(Name = "event_description", IsRequired = false, EmitDefaultValue = false)]
        public override string? EventDescription { get; set; }

        /// <summary>
        /// ID of the event.
        /// </summary>
        [DataMember(Name = "event_id", IsRequired = false, EmitDefaultValue = false)]
        public override string EventId { get; set; }

        [DataMember(Name = "event_type", IsRequired = true, EmitDefaultValue = false)]
        public override string EventType { get; } = "lock.locked";

        /// <summary>
        /// Whether the lock action was performed over Bluetooth by a remote client (such as the provider&apos;s mobile app), rather than a direct physical interaction or a Seam-initiated remote action.
        /// </summary>
        [DataMember(Name = "is_via_bluetooth", IsRequired = false, EmitDefaultValue = false)]
        public bool? IsViaBluetooth { get; set; }

        /// <summary>
        /// Whether the lock action was performed by an NFC credential tap (such as an Apple Home Key or an NFC key fob) presented to the lock, rather than a direct physical interaction or a Seam-initiated remote action.
        /// </summary>
        [DataMember(Name = "is_via_nfc", IsRequired = false, EmitDefaultValue = false)]
        public bool? IsViaNfc { get; set; }

        /// <summary>
        /// Method by which the lock was locked. `keycode`: an access code was used (see `access_code_id`). `manual`: a physical action such as a thumbturn or button press. `remote`: a remote action via an app, Bluetooth, or the Seam API (see `action_attempt_id` if Seam-initiated; see `is_via_bluetooth` or `is_via_nfc` for the transport). `automatic`: triggered automatically, for example by an auto-relock timer. `unknown`: could not be determined.
        /// </summary>
        [DataMember(Name = "method", IsRequired = false, EmitDefaultValue = false)]
        public EventLockLocked.MethodEnum Method { get; set; }

        /// <summary>
        /// Date and time at which the event occurred.
        /// </summary>
        [DataMember(Name = "occurred_at", IsRequired = false, EmitDefaultValue = false)]
        public override string OccurredAt { get; set; }

        /// <summary>
        /// undocumented: Unreleased.
        ///       ---
        ///       ID of the user identity associated with the lock event.
        /// </summary>
        [DataMember(Name = "user_identity_id", IsRequired = false, EmitDefaultValue = false)]
        public string? UserIdentityId { get; set; }

        /// <summary>
        /// ID of the workspace associated with the event.
        /// </summary>
        [DataMember(Name = "workspace_id", IsRequired = false, EmitDefaultValue = false)]
        public override string WorkspaceId { get; set; }

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
    /// A [lock](https://docs.seam.co/low-level-apis/smart-locks) was unlocked.
    /// </summary>
    [DataContract(Name = "seamModel_eventLockUnlocked_model")]
    public class EventLockUnlocked : Event
    {
        [JsonConstructorAttribute]
        protected EventLockUnlocked() { }

        public EventLockUnlocked(
            string? accessCodeId = default,
            bool? accessCodeIsManaged = default,
            string? acsEntranceId = default,
            string? acsSystemId = default,
            string? acsUserId = default,
            string? actionAttemptId = default,
            string? code = default,
            object? connectedAccountCustomMetadata = default,
            string connectedAccountId = default,
            string createdAt = default,
            string? customerKey = default,
            object? deviceCustomMetadata = default,
            string? deviceId = default,
            string? eventDescription = default,
            string eventId = default,
            string eventType = default,
            bool? isViaBluetooth = default,
            bool? isViaNfc = default,
            EventLockUnlocked.MethodEnum method = default,
            string occurredAt = default,
            string? userIdentityId = default,
            string workspaceId = default
        )
        {
            AccessCodeId = accessCodeId;
            AccessCodeIsManaged = accessCodeIsManaged;
            AcsEntranceId = acsEntranceId;
            AcsSystemId = acsSystemId;
            AcsUserId = acsUserId;
            ActionAttemptId = actionAttemptId;
            Code = code;
            ConnectedAccountCustomMetadata = connectedAccountCustomMetadata;
            ConnectedAccountId = connectedAccountId;
            CreatedAt = createdAt;
            CustomerKey = customerKey;
            DeviceCustomMetadata = deviceCustomMetadata;
            DeviceId = deviceId;
            EventDescription = eventDescription;
            EventId = eventId;
            EventType = eventType;
            IsViaBluetooth = isViaBluetooth;
            IsViaNfc = isViaNfc;
            Method = method;
            OccurredAt = occurredAt;
            UserIdentityId = userIdentityId;
            WorkspaceId = workspaceId;
        }

        /// <summary>
        /// Method by which the lock was unlocked. `keycode`: an [access code](https://docs.seam.co/low-level-apis/smart-locks/access-codes) was used (see `access_code_id`). `manual`: a physical action such as a thumbturn or handle press. `remote`: a remote action via an app, Bluetooth, or the Seam API (see `action_attempt_id` if Seam-initiated; see `is_via_bluetooth` or `is_via_nfc` for the transport). `automatic`: triggered automatically, for example by a time-based schedule. `unknown`: could not be determined.
        /// </summary>
        [JsonConverter(typeof(SafeStringEnumConverter))]
        public enum MethodEnum
        {
            [EnumMember(Value = "unrecognized")]
            Unrecognized = 0,

            [EnumMember(Value = "keycode")]
            Keycode = 1,

            [EnumMember(Value = "manual")]
            Manual = 2,

            [EnumMember(Value = "automatic")]
            Automatic = 3,

            [EnumMember(Value = "unknown")]
            Unknown = 4,

            [EnumMember(Value = "remote")]
            Remote = 5,

            [EnumMember(Value = "card")]
            Card = 6,
        }

        /// <summary>
        /// ID of the access code that was used to unlock the affected device.
        /// </summary>
        [DataMember(Name = "access_code_id", IsRequired = false, EmitDefaultValue = false)]
        public string? AccessCodeId { get; set; }

        /// <summary>
        /// Whether the access code is managed by Seam (true) or unmanaged (false). Only present when access_code_id is set.
        /// </summary>
        [DataMember(Name = "access_code_is_managed", IsRequired = false, EmitDefaultValue = false)]
        public bool? AccessCodeIsManaged { get; set; }

        /// <summary>
        /// undocumented: Unreleased.
        ///       ---
        ///       ID of the ACS entrance associated with the unlock event.
        /// </summary>
        [DataMember(Name = "acs_entrance_id", IsRequired = false, EmitDefaultValue = false)]
        public string? AcsEntranceId { get; set; }

        /// <summary>
        /// undocumented: Unreleased.
        ///       ---
        ///       ID of the ACS system associated with the unlock event.
        /// </summary>
        [DataMember(Name = "acs_system_id", IsRequired = false, EmitDefaultValue = false)]
        public string? AcsSystemId { get; set; }

        /// <summary>
        /// undocumented: Unreleased.
        ///       ---
        ///       ID of the ACS user associated with the unlock event.
        /// </summary>
        [DataMember(Name = "acs_user_id", IsRequired = false, EmitDefaultValue = false)]
        public string? AcsUserId { get; set; }

        /// <summary>
        /// ID of the Seam action attempt that triggered this unlock. Present only when the unlock was initiated through Seam (via an `UNLOCK_DOOR` action attempt).
        /// </summary>
        [DataMember(Name = "action_attempt_id", IsRequired = false, EmitDefaultValue = false)]
        public string? ActionAttemptId { get; set; }

        /// <summary>
        /// Code (PIN) that was used to unlock the affected device, if known. Taken from the matched managed or unmanaged access code, or from the code reported by the provider when no access code matched.
        /// </summary>
        [DataMember(Name = "code", IsRequired = false, EmitDefaultValue = false)]
        public string? Code { get; set; }

        /// <summary>
        /// Custom metadata of the connected account, present when connected_account_id is provided.
        /// </summary>
        [DataMember(
            Name = "connected_account_custom_metadata",
            IsRequired = false,
            EmitDefaultValue = false
        )]
        public object? ConnectedAccountCustomMetadata { get; set; }

        /// <summary>
        /// ID of the connected account associated with the event.
        /// </summary>
        [DataMember(Name = "connected_account_id", IsRequired = false, EmitDefaultValue = false)]
        public string ConnectedAccountId { get; set; }

        /// <summary>
        /// Date and time at which the event was created.
        /// </summary>
        [DataMember(Name = "created_at", IsRequired = false, EmitDefaultValue = false)]
        public override string CreatedAt { get; set; }

        /// <summary>
        /// The customer key associated with the device, if any.
        /// </summary>
        [DataMember(Name = "customer_key", IsRequired = false, EmitDefaultValue = false)]
        public string? CustomerKey { get; set; }

        /// <summary>
        /// Custom metadata of the device, present when device_id is provided.
        /// </summary>
        [DataMember(Name = "device_custom_metadata", IsRequired = false, EmitDefaultValue = false)]
        public object? DeviceCustomMetadata { get; set; }

        /// <summary>
        /// ID of the affected device.
        /// </summary>
        [DataMember(Name = "device_id", IsRequired = false, EmitDefaultValue = false)]
        public string? DeviceId { get; set; }

        /// <summary>
        /// Human-readable description of the event. Persisted when the event is created (so the creating code, including a provider, can supply a tailored description) and otherwise derived from the event.
        /// </summary>
        [DataMember(Name = "event_description", IsRequired = false, EmitDefaultValue = false)]
        public override string? EventDescription { get; set; }

        /// <summary>
        /// ID of the event.
        /// </summary>
        [DataMember(Name = "event_id", IsRequired = false, EmitDefaultValue = false)]
        public override string EventId { get; set; }

        [DataMember(Name = "event_type", IsRequired = true, EmitDefaultValue = false)]
        public override string EventType { get; } = "lock.unlocked";

        /// <summary>
        /// Whether the unlock action was performed over Bluetooth by a remote client (such as the provider&apos;s mobile app), rather than a direct physical interaction or a Seam-initiated remote action.
        /// </summary>
        [DataMember(Name = "is_via_bluetooth", IsRequired = false, EmitDefaultValue = false)]
        public bool? IsViaBluetooth { get; set; }

        /// <summary>
        /// Whether the unlock action was performed by an NFC credential tap (such as an Apple Home Key or an NFC key fob) presented to the lock, rather than a direct physical interaction or a Seam-initiated remote action.
        /// </summary>
        [DataMember(Name = "is_via_nfc", IsRequired = false, EmitDefaultValue = false)]
        public bool? IsViaNfc { get; set; }

        /// <summary>
        /// Method by which the lock was unlocked. `keycode`: an [access code](https://docs.seam.co/low-level-apis/smart-locks/access-codes) was used (see `access_code_id`). `manual`: a physical action such as a thumbturn or handle press. `remote`: a remote action via an app, Bluetooth, or the Seam API (see `action_attempt_id` if Seam-initiated; see `is_via_bluetooth` or `is_via_nfc` for the transport). `automatic`: triggered automatically, for example by a time-based schedule. `unknown`: could not be determined.
        /// </summary>
        [DataMember(Name = "method", IsRequired = false, EmitDefaultValue = false)]
        public EventLockUnlocked.MethodEnum Method { get; set; }

        /// <summary>
        /// Date and time at which the event occurred.
        /// </summary>
        [DataMember(Name = "occurred_at", IsRequired = false, EmitDefaultValue = false)]
        public override string OccurredAt { get; set; }

        /// <summary>
        /// undocumented: Unreleased.
        ///       ---
        ///       ID of the user identity associated with the unlock event.
        /// </summary>
        [DataMember(Name = "user_identity_id", IsRequired = false, EmitDefaultValue = false)]
        public string? UserIdentityId { get; set; }

        /// <summary>
        /// ID of the workspace associated with the event.
        /// </summary>
        [DataMember(Name = "workspace_id", IsRequired = false, EmitDefaultValue = false)]
        public override string WorkspaceId { get; set; }

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
    /// The [lock](https://docs.seam.co/low-level-apis/smart-locks) denied access to a user after one or more consecutive invalid attempts to unlock the device.
    /// </summary>
    [DataContract(Name = "seamModel_eventLockAccessDenied_model")]
    public class EventLockAccessDenied : Event
    {
        [JsonConstructorAttribute]
        protected EventLockAccessDenied() { }

        public EventLockAccessDenied(
            string? accessCodeId = default,
            string? acsEntranceId = default,
            string? acsSystemId = default,
            string? acsUserId = default,
            object? connectedAccountCustomMetadata = default,
            string connectedAccountId = default,
            string createdAt = default,
            string? customerKey = default,
            object? deviceCustomMetadata = default,
            string? deviceId = default,
            string? eventDescription = default,
            string eventId = default,
            string eventType = default,
            string occurredAt = default,
            EventLockAccessDeniedReason? reason = default,
            string? userIdentityId = default,
            string workspaceId = default
        )
        {
            AccessCodeId = accessCodeId;
            AcsEntranceId = acsEntranceId;
            AcsSystemId = acsSystemId;
            AcsUserId = acsUserId;
            ConnectedAccountCustomMetadata = connectedAccountCustomMetadata;
            ConnectedAccountId = connectedAccountId;
            CreatedAt = createdAt;
            CustomerKey = customerKey;
            DeviceCustomMetadata = deviceCustomMetadata;
            DeviceId = deviceId;
            EventDescription = eventDescription;
            EventId = eventId;
            EventType = eventType;
            OccurredAt = occurredAt;
            Reason = reason;
            UserIdentityId = userIdentityId;
            WorkspaceId = workspaceId;
        }

        /// <summary>
        /// ID of the access code that was used in the unlock attempts.
        /// </summary>
        [DataMember(Name = "access_code_id", IsRequired = false, EmitDefaultValue = false)]
        public string? AccessCodeId { get; set; }

        /// <summary>
        /// undocumented: Unreleased.
        ///       ---
        ///       ID of the ACS entrance associated with the access-denied event.
        /// </summary>
        [DataMember(Name = "acs_entrance_id", IsRequired = false, EmitDefaultValue = false)]
        public string? AcsEntranceId { get; set; }

        /// <summary>
        /// undocumented: Unreleased.
        ///       ---
        ///       ID of the ACS system associated with the access-denied event.
        /// </summary>
        [DataMember(Name = "acs_system_id", IsRequired = false, EmitDefaultValue = false)]
        public string? AcsSystemId { get; set; }

        /// <summary>
        /// undocumented: Unreleased.
        ///       ---
        ///       ID of the ACS user associated with the access-denied event.
        /// </summary>
        [DataMember(Name = "acs_user_id", IsRequired = false, EmitDefaultValue = false)]
        public string? AcsUserId { get; set; }

        /// <summary>
        /// Custom metadata of the connected account, present when connected_account_id is provided.
        /// </summary>
        [DataMember(
            Name = "connected_account_custom_metadata",
            IsRequired = false,
            EmitDefaultValue = false
        )]
        public object? ConnectedAccountCustomMetadata { get; set; }

        /// <summary>
        /// ID of the connected account associated with the event.
        /// </summary>
        [DataMember(Name = "connected_account_id", IsRequired = false, EmitDefaultValue = false)]
        public string ConnectedAccountId { get; set; }

        /// <summary>
        /// Date and time at which the event was created.
        /// </summary>
        [DataMember(Name = "created_at", IsRequired = false, EmitDefaultValue = false)]
        public override string CreatedAt { get; set; }

        /// <summary>
        /// The customer key associated with the device, if any.
        /// </summary>
        [DataMember(Name = "customer_key", IsRequired = false, EmitDefaultValue = false)]
        public string? CustomerKey { get; set; }

        /// <summary>
        /// Custom metadata of the device, present when device_id is provided.
        /// </summary>
        [DataMember(Name = "device_custom_metadata", IsRequired = false, EmitDefaultValue = false)]
        public object? DeviceCustomMetadata { get; set; }

        /// <summary>
        /// ID of the affected device.
        /// </summary>
        [DataMember(Name = "device_id", IsRequired = false, EmitDefaultValue = false)]
        public string? DeviceId { get; set; }

        /// <summary>
        /// Human-readable description of the event. Persisted when the event is created (so the creating code, including a provider, can supply a tailored description) and otherwise derived from the event.
        /// </summary>
        [DataMember(Name = "event_description", IsRequired = false, EmitDefaultValue = false)]
        public override string? EventDescription { get; set; }

        /// <summary>
        /// ID of the event.
        /// </summary>
        [DataMember(Name = "event_id", IsRequired = false, EmitDefaultValue = false)]
        public override string EventId { get; set; }

        [DataMember(Name = "event_type", IsRequired = true, EmitDefaultValue = false)]
        public override string EventType { get; } = "lock.access_denied";

        /// <summary>
        /// Date and time at which the event occurred.
        /// </summary>
        [DataMember(Name = "occurred_at", IsRequired = false, EmitDefaultValue = false)]
        public override string OccurredAt { get; set; }

        /// <summary>
        /// Why access was denied, when the provider reports a determinable cause. Omitted when unknown.
        /// </summary>
        [DataMember(Name = "reason", IsRequired = false, EmitDefaultValue = false)]
        public EventLockAccessDeniedReason? Reason { get; set; }

        /// <summary>
        /// undocumented: Unreleased.
        ///       ---
        ///       ID of the user identity associated with the access-denied event.
        /// </summary>
        [DataMember(Name = "user_identity_id", IsRequired = false, EmitDefaultValue = false)]
        public string? UserIdentityId { get; set; }

        /// <summary>
        /// ID of the workspace associated with the event.
        /// </summary>
        [DataMember(Name = "workspace_id", IsRequired = false, EmitDefaultValue = false)]
        public override string WorkspaceId { get; set; }

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

    [DataContract(Name = "seamModel_eventLockAccessDeniedReason_model")]
    public class EventLockAccessDeniedReason
    {
        [JsonConstructorAttribute]
        protected EventLockAccessDeniedReason() { }

        public EventLockAccessDeniedReason(
            string message = default,
            EventLockAccessDeniedReason.ReasonCodeEnum reasonCode = default
        )
        {
            Message = message;
            ReasonCode = reasonCode;
        }

        /// <summary>
        /// Normalized reason a lock denied access. Provider-agnostic; not all providers report every value.
        /// </summary>
        [JsonConverter(typeof(SafeStringEnumConverter))]
        public enum ReasonCodeEnum
        {
            [EnumMember(Value = "unrecognized")]
            Unrecognized = 0,

            [EnumMember(Value = "unknown_code")]
            UnknownCode = 1,

            [EnumMember(Value = "expired_code")]
            ExpiredCode = 2,

            [EnumMember(Value = "blocklisted_code")]
            BlocklistedCode = 3,

            [EnumMember(Value = "too_many_attempts")]
            TooManyAttempts = 4,

            [EnumMember(Value = "blocked_by_privacy_mode")]
            BlockedByPrivacyMode = 5,

            [EnumMember(Value = "credential_error")]
            CredentialError = 6,
        }

        /// <summary>
        /// Human-readable explanation of why access was denied.
        /// </summary>
        [DataMember(Name = "message", IsRequired = false, EmitDefaultValue = false)]
        public string Message { get; set; }

        /// <summary>
        /// Normalized reason a lock denied access. Provider-agnostic; not all providers report every value.
        /// </summary>
        [DataMember(Name = "reason_code", IsRequired = false, EmitDefaultValue = false)]
        public EventLockAccessDeniedReason.ReasonCodeEnum ReasonCode { get; set; }

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
    /// A thermostat [climate preset](https://docs.seam.co/capability-guides/thermostats/creating-and-managing-climate-presets) was activated.
    /// </summary>
    [DataContract(Name = "seamModel_eventThermostatClimatePresetActivated_model")]
    public class EventThermostatClimatePresetActivated : Event
    {
        [JsonConstructorAttribute]
        protected EventThermostatClimatePresetActivated() { }

        public EventThermostatClimatePresetActivated(
            string climatePresetKey = default,
            object? connectedAccountCustomMetadata = default,
            string connectedAccountId = default,
            string createdAt = default,
            string? customerKey = default,
            object? deviceCustomMetadata = default,
            string deviceId = default,
            string? eventDescription = default,
            string eventId = default,
            string eventType = default,
            bool isFallbackClimatePreset = default,
            string occurredAt = default,
            string? thermostatScheduleId = default,
            string workspaceId = default
        )
        {
            ClimatePresetKey = climatePresetKey;
            ConnectedAccountCustomMetadata = connectedAccountCustomMetadata;
            ConnectedAccountId = connectedAccountId;
            CreatedAt = createdAt;
            CustomerKey = customerKey;
            DeviceCustomMetadata = deviceCustomMetadata;
            DeviceId = deviceId;
            EventDescription = eventDescription;
            EventId = eventId;
            EventType = eventType;
            IsFallbackClimatePreset = isFallbackClimatePreset;
            OccurredAt = occurredAt;
            ThermostatScheduleId = thermostatScheduleId;
            WorkspaceId = workspaceId;
        }

        /// <summary>
        /// Key of the climate preset that was activated.
        /// </summary>
        [DataMember(Name = "climate_preset_key", IsRequired = false, EmitDefaultValue = false)]
        public string ClimatePresetKey { get; set; }

        /// <summary>
        /// Custom metadata of the connected account, present when connected_account_id is provided.
        /// </summary>
        [DataMember(
            Name = "connected_account_custom_metadata",
            IsRequired = false,
            EmitDefaultValue = false
        )]
        public object? ConnectedAccountCustomMetadata { get; set; }

        /// <summary>
        /// ID of the connected account associated with the event.
        /// </summary>
        [DataMember(Name = "connected_account_id", IsRequired = false, EmitDefaultValue = false)]
        public string ConnectedAccountId { get; set; }

        /// <summary>
        /// Date and time at which the event was created.
        /// </summary>
        [DataMember(Name = "created_at", IsRequired = false, EmitDefaultValue = false)]
        public override string CreatedAt { get; set; }

        /// <summary>
        /// The customer key associated with the device, if any.
        /// </summary>
        [DataMember(Name = "customer_key", IsRequired = false, EmitDefaultValue = false)]
        public string? CustomerKey { get; set; }

        /// <summary>
        /// Custom metadata of the device, present when device_id is provided.
        /// </summary>
        [DataMember(Name = "device_custom_metadata", IsRequired = false, EmitDefaultValue = false)]
        public object? DeviceCustomMetadata { get; set; }

        /// <summary>
        /// ID of the affected device.
        /// </summary>
        [DataMember(Name = "device_id", IsRequired = false, EmitDefaultValue = false)]
        public string DeviceId { get; set; }

        /// <summary>
        /// Human-readable description of the event. Persisted when the event is created (so the creating code, including a provider, can supply a tailored description) and otherwise derived from the event.
        /// </summary>
        [DataMember(Name = "event_description", IsRequired = false, EmitDefaultValue = false)]
        public override string? EventDescription { get; set; }

        /// <summary>
        /// ID of the event.
        /// </summary>
        [DataMember(Name = "event_id", IsRequired = false, EmitDefaultValue = false)]
        public override string EventId { get; set; }

        [DataMember(Name = "event_type", IsRequired = true, EmitDefaultValue = false)]
        public override string EventType { get; } = "thermostat.climate_preset_activated";

        /// <summary>
        /// Indicates whether the climate preset that was activated is the fallback climate preset for the thermostat.
        /// </summary>
        [DataMember(
            Name = "is_fallback_climate_preset",
            IsRequired = false,
            EmitDefaultValue = false
        )]
        public bool IsFallbackClimatePreset { get; set; }

        /// <summary>
        /// Date and time at which the event occurred.
        /// </summary>
        [DataMember(Name = "occurred_at", IsRequired = false, EmitDefaultValue = false)]
        public override string OccurredAt { get; set; }

        /// <summary>
        /// ID of the thermostat schedule that prompted the affected climate preset to be activated.
        /// </summary>
        [DataMember(Name = "thermostat_schedule_id", IsRequired = false, EmitDefaultValue = false)]
        public string? ThermostatScheduleId { get; set; }

        /// <summary>
        /// ID of the workspace associated with the event.
        /// </summary>
        [DataMember(Name = "workspace_id", IsRequired = false, EmitDefaultValue = false)]
        public override string WorkspaceId { get; set; }

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
    /// A [thermostat](https://docs.seam.co/capability-guides/thermostats) was adjusted manually.
    /// </summary>
    [DataContract(Name = "seamModel_eventThermostatManuallyAdjusted_model")]
    public class EventThermostatManuallyAdjusted : Event
    {
        [JsonConstructorAttribute]
        protected EventThermostatManuallyAdjusted() { }

        public EventThermostatManuallyAdjusted(
            object? connectedAccountCustomMetadata = default,
            string connectedAccountId = default,
            float? coolingSetPointCelsius = default,
            float? coolingSetPointFahrenheit = default,
            string createdAt = default,
            string? customerKey = default,
            object? deviceCustomMetadata = default,
            string deviceId = default,
            string? eventDescription = default,
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
            ConnectedAccountCustomMetadata = connectedAccountCustomMetadata;
            ConnectedAccountId = connectedAccountId;
            CoolingSetPointCelsius = coolingSetPointCelsius;
            CoolingSetPointFahrenheit = coolingSetPointFahrenheit;
            CreatedAt = createdAt;
            CustomerKey = customerKey;
            DeviceCustomMetadata = deviceCustomMetadata;
            DeviceId = deviceId;
            EventDescription = eventDescription;
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

        /// <summary>
        /// Desired [fan mode setting](https://docs.seam.co/capability-guides/thermostats/configure-current-climate-settings#fan-mode-settings), such as `on`, `auto`, or `circulate`.
        /// </summary>
        [JsonConverter(typeof(SafeStringEnumConverter))]
        public enum FanModeSettingEnum
        {
            [EnumMember(Value = "unrecognized")]
            Unrecognized = 0,

            [EnumMember(Value = "auto")]
            Auto = 1,

            [EnumMember(Value = "on")]
            On = 2,

            [EnumMember(Value = "circulate")]
            Circulate = 3,
        }

        /// <summary>
        /// Desired [HVAC mode](https://docs.seam.co/capability-guides/thermostats/understanding-thermostat-concepts/hvac-mode) setting, such as `heat`, `cool`, `heat_cool`, or `off`.
        /// </summary>
        [JsonConverter(typeof(SafeStringEnumConverter))]
        public enum HvacModeSettingEnum
        {
            [EnumMember(Value = "unrecognized")]
            Unrecognized = 0,

            [EnumMember(Value = "off")]
            Off = 1,

            [EnumMember(Value = "heat")]
            Heat = 2,

            [EnumMember(Value = "cool")]
            Cool = 3,

            [EnumMember(Value = "heat_cool")]
            HeatCool = 4,

            [EnumMember(Value = "eco")]
            Eco = 5,
        }

        /// <summary>
        /// Method used to adjust the affected thermostat manually. `seam` indicates that the Seam API, Seam CLI, or Seam Console was used to adjust the thermostat.
        /// </summary>
        [JsonConverter(typeof(SafeStringEnumConverter))]
        public enum MethodEnum
        {
            [EnumMember(Value = "unrecognized")]
            Unrecognized = 0,

            [EnumMember(Value = "seam")]
            Seam = 1,

            [EnumMember(Value = "external")]
            External = 2,
        }

        /// <summary>
        /// Custom metadata of the connected account, present when connected_account_id is provided.
        /// </summary>
        [DataMember(
            Name = "connected_account_custom_metadata",
            IsRequired = false,
            EmitDefaultValue = false
        )]
        public object? ConnectedAccountCustomMetadata { get; set; }

        /// <summary>
        /// ID of the connected account associated with the event.
        /// </summary>
        [DataMember(Name = "connected_account_id", IsRequired = false, EmitDefaultValue = false)]
        public string ConnectedAccountId { get; set; }

        /// <summary>
        /// Temperature to which the thermostat should cool (in °C). See also [Set Points](https://docs.seam.co/capability-guides/thermostats/understanding-thermostat-concepts/set-points).
        /// </summary>
        [DataMember(
            Name = "cooling_set_point_celsius",
            IsRequired = false,
            EmitDefaultValue = false
        )]
        public float? CoolingSetPointCelsius { get; set; }

        /// <summary>
        /// Temperature to which the thermostat should cool (in °F). See also [Set Points](https://docs.seam.co/capability-guides/thermostats/understanding-thermostat-concepts/set-points).
        /// </summary>
        [DataMember(
            Name = "cooling_set_point_fahrenheit",
            IsRequired = false,
            EmitDefaultValue = false
        )]
        public float? CoolingSetPointFahrenheit { get; set; }

        /// <summary>
        /// Date and time at which the event was created.
        /// </summary>
        [DataMember(Name = "created_at", IsRequired = false, EmitDefaultValue = false)]
        public override string CreatedAt { get; set; }

        /// <summary>
        /// The customer key associated with the device, if any.
        /// </summary>
        [DataMember(Name = "customer_key", IsRequired = false, EmitDefaultValue = false)]
        public string? CustomerKey { get; set; }

        /// <summary>
        /// Custom metadata of the device, present when device_id is provided.
        /// </summary>
        [DataMember(Name = "device_custom_metadata", IsRequired = false, EmitDefaultValue = false)]
        public object? DeviceCustomMetadata { get; set; }

        /// <summary>
        /// ID of the affected device.
        /// </summary>
        [DataMember(Name = "device_id", IsRequired = false, EmitDefaultValue = false)]
        public string DeviceId { get; set; }

        /// <summary>
        /// Human-readable description of the event. Persisted when the event is created (so the creating code, including a provider, can supply a tailored description) and otherwise derived from the event.
        /// </summary>
        [DataMember(Name = "event_description", IsRequired = false, EmitDefaultValue = false)]
        public override string? EventDescription { get; set; }

        /// <summary>
        /// ID of the event.
        /// </summary>
        [DataMember(Name = "event_id", IsRequired = false, EmitDefaultValue = false)]
        public override string EventId { get; set; }

        [DataMember(Name = "event_type", IsRequired = true, EmitDefaultValue = false)]
        public override string EventType { get; } = "thermostat.manually_adjusted";

        /// <summary>
        /// Desired [fan mode setting](https://docs.seam.co/capability-guides/thermostats/configure-current-climate-settings#fan-mode-settings), such as `on`, `auto`, or `circulate`.
        /// </summary>
        [DataMember(Name = "fan_mode_setting", IsRequired = false, EmitDefaultValue = false)]
        public EventThermostatManuallyAdjusted.FanModeSettingEnum? FanModeSetting { get; set; }

        /// <summary>
        /// Temperature to which the thermostat should heat (in °C). See also [Set Points](https://docs.seam.co/capability-guides/thermostats/understanding-thermostat-concepts/set-points).
        /// </summary>
        [DataMember(
            Name = "heating_set_point_celsius",
            IsRequired = false,
            EmitDefaultValue = false
        )]
        public float? HeatingSetPointCelsius { get; set; }

        /// <summary>
        /// Temperature to which the thermostat should heat (in °F). See also [Set Points](https://docs.seam.co/capability-guides/thermostats/understanding-thermostat-concepts/set-points).
        /// </summary>
        [DataMember(
            Name = "heating_set_point_fahrenheit",
            IsRequired = false,
            EmitDefaultValue = false
        )]
        public float? HeatingSetPointFahrenheit { get; set; }

        /// <summary>
        /// Desired [HVAC mode](https://docs.seam.co/capability-guides/thermostats/understanding-thermostat-concepts/hvac-mode) setting, such as `heat`, `cool`, `heat_cool`, or `off`.
        /// </summary>
        [DataMember(Name = "hvac_mode_setting", IsRequired = false, EmitDefaultValue = false)]
        public EventThermostatManuallyAdjusted.HvacModeSettingEnum? HvacModeSetting { get; set; }

        /// <summary>
        /// Method used to adjust the affected thermostat manually. `seam` indicates that the Seam API, Seam CLI, or Seam Console was used to adjust the thermostat.
        /// </summary>
        [DataMember(Name = "method", IsRequired = false, EmitDefaultValue = false)]
        public EventThermostatManuallyAdjusted.MethodEnum Method { get; set; }

        /// <summary>
        /// Date and time at which the event occurred.
        /// </summary>
        [DataMember(Name = "occurred_at", IsRequired = false, EmitDefaultValue = false)]
        public override string OccurredAt { get; set; }

        /// <summary>
        /// ID of the workspace associated with the event.
        /// </summary>
        [DataMember(Name = "workspace_id", IsRequired = false, EmitDefaultValue = false)]
        public override string WorkspaceId { get; set; }

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
    /// A [thermostat&apos;s](https://docs.seam.co/capability-guides/thermostats) temperature reading exceeded the set [threshold](https://docs.seam.co/capability-guides/thermostats/setting-and-monitoring-temperature-thresholds).
    /// </summary>
    [DataContract(Name = "seamModel_eventThermostatTemperatureThresholdExceeded_model")]
    public class EventThermostatTemperatureThresholdExceeded : Event
    {
        [JsonConstructorAttribute]
        protected EventThermostatTemperatureThresholdExceeded() { }

        public EventThermostatTemperatureThresholdExceeded(
            object? connectedAccountCustomMetadata = default,
            string connectedAccountId = default,
            string createdAt = default,
            string? customerKey = default,
            object? deviceCustomMetadata = default,
            string deviceId = default,
            string? eventDescription = default,
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
            ConnectedAccountCustomMetadata = connectedAccountCustomMetadata;
            ConnectedAccountId = connectedAccountId;
            CreatedAt = createdAt;
            CustomerKey = customerKey;
            DeviceCustomMetadata = deviceCustomMetadata;
            DeviceId = deviceId;
            EventDescription = eventDescription;
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

        /// <summary>
        /// Custom metadata of the connected account, present when connected_account_id is provided.
        /// </summary>
        [DataMember(
            Name = "connected_account_custom_metadata",
            IsRequired = false,
            EmitDefaultValue = false
        )]
        public object? ConnectedAccountCustomMetadata { get; set; }

        /// <summary>
        /// ID of the connected account associated with the event.
        /// </summary>
        [DataMember(Name = "connected_account_id", IsRequired = false, EmitDefaultValue = false)]
        public string ConnectedAccountId { get; set; }

        /// <summary>
        /// Date and time at which the event was created.
        /// </summary>
        [DataMember(Name = "created_at", IsRequired = false, EmitDefaultValue = false)]
        public override string CreatedAt { get; set; }

        /// <summary>
        /// The customer key associated with the device, if any.
        /// </summary>
        [DataMember(Name = "customer_key", IsRequired = false, EmitDefaultValue = false)]
        public string? CustomerKey { get; set; }

        /// <summary>
        /// Custom metadata of the device, present when device_id is provided.
        /// </summary>
        [DataMember(Name = "device_custom_metadata", IsRequired = false, EmitDefaultValue = false)]
        public object? DeviceCustomMetadata { get; set; }

        /// <summary>
        /// ID of the affected device.
        /// </summary>
        [DataMember(Name = "device_id", IsRequired = false, EmitDefaultValue = false)]
        public string DeviceId { get; set; }

        /// <summary>
        /// Human-readable description of the event. Persisted when the event is created (so the creating code, including a provider, can supply a tailored description) and otherwise derived from the event.
        /// </summary>
        [DataMember(Name = "event_description", IsRequired = false, EmitDefaultValue = false)]
        public override string? EventDescription { get; set; }

        /// <summary>
        /// ID of the event.
        /// </summary>
        [DataMember(Name = "event_id", IsRequired = false, EmitDefaultValue = false)]
        public override string EventId { get; set; }

        [DataMember(Name = "event_type", IsRequired = true, EmitDefaultValue = false)]
        public override string EventType { get; } = "thermostat.temperature_threshold_exceeded";

        /// <summary>
        /// Lower temperature limit, in °C, defined by the set threshold.
        /// </summary>
        [DataMember(Name = "lower_limit_celsius", IsRequired = false, EmitDefaultValue = false)]
        public float? LowerLimitCelsius { get; set; }

        /// <summary>
        /// Lower temperature limit, in °F, defined by the set threshold.
        /// </summary>
        [DataMember(Name = "lower_limit_fahrenheit", IsRequired = false, EmitDefaultValue = false)]
        public float? LowerLimitFahrenheit { get; set; }

        /// <summary>
        /// Date and time at which the event occurred.
        /// </summary>
        [DataMember(Name = "occurred_at", IsRequired = false, EmitDefaultValue = false)]
        public override string OccurredAt { get; set; }

        /// <summary>
        /// Temperature, in °C, reported by the affected thermostat.
        /// </summary>
        [DataMember(Name = "temperature_celsius", IsRequired = false, EmitDefaultValue = false)]
        public float TemperatureCelsius { get; set; }

        /// <summary>
        /// Temperature, in °F, reported by the affected thermostat.
        /// </summary>
        [DataMember(Name = "temperature_fahrenheit", IsRequired = false, EmitDefaultValue = false)]
        public float TemperatureFahrenheit { get; set; }

        /// <summary>
        /// Upper temperature limit, in °C, defined by the set threshold.
        /// </summary>
        [DataMember(Name = "upper_limit_celsius", IsRequired = false, EmitDefaultValue = false)]
        public float? UpperLimitCelsius { get; set; }

        /// <summary>
        /// Upper temperature limit, in °F, defined by the set threshold.
        /// </summary>
        [DataMember(Name = "upper_limit_fahrenheit", IsRequired = false, EmitDefaultValue = false)]
        public float? UpperLimitFahrenheit { get; set; }

        /// <summary>
        /// ID of the workspace associated with the event.
        /// </summary>
        [DataMember(Name = "workspace_id", IsRequired = false, EmitDefaultValue = false)]
        public override string WorkspaceId { get; set; }

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
    /// A [thermostat&apos;s](https://docs.seam.co/capability-guides/thermostats) temperature reading no longer exceeds the set [threshold](https://docs.seam.co/capability-guides/thermostats/setting-and-monitoring-temperature-thresholds).
    /// </summary>
    [DataContract(Name = "seamModel_eventThermostatTemperatureThresholdNoLongerExceeded_model")]
    public class EventThermostatTemperatureThresholdNoLongerExceeded : Event
    {
        [JsonConstructorAttribute]
        protected EventThermostatTemperatureThresholdNoLongerExceeded() { }

        public EventThermostatTemperatureThresholdNoLongerExceeded(
            object? connectedAccountCustomMetadata = default,
            string connectedAccountId = default,
            string createdAt = default,
            string? customerKey = default,
            object? deviceCustomMetadata = default,
            string deviceId = default,
            string? eventDescription = default,
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
            ConnectedAccountCustomMetadata = connectedAccountCustomMetadata;
            ConnectedAccountId = connectedAccountId;
            CreatedAt = createdAt;
            CustomerKey = customerKey;
            DeviceCustomMetadata = deviceCustomMetadata;
            DeviceId = deviceId;
            EventDescription = eventDescription;
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

        /// <summary>
        /// Custom metadata of the connected account, present when connected_account_id is provided.
        /// </summary>
        [DataMember(
            Name = "connected_account_custom_metadata",
            IsRequired = false,
            EmitDefaultValue = false
        )]
        public object? ConnectedAccountCustomMetadata { get; set; }

        /// <summary>
        /// ID of the connected account associated with the event.
        /// </summary>
        [DataMember(Name = "connected_account_id", IsRequired = false, EmitDefaultValue = false)]
        public string ConnectedAccountId { get; set; }

        /// <summary>
        /// Date and time at which the event was created.
        /// </summary>
        [DataMember(Name = "created_at", IsRequired = false, EmitDefaultValue = false)]
        public override string CreatedAt { get; set; }

        /// <summary>
        /// The customer key associated with the device, if any.
        /// </summary>
        [DataMember(Name = "customer_key", IsRequired = false, EmitDefaultValue = false)]
        public string? CustomerKey { get; set; }

        /// <summary>
        /// Custom metadata of the device, present when device_id is provided.
        /// </summary>
        [DataMember(Name = "device_custom_metadata", IsRequired = false, EmitDefaultValue = false)]
        public object? DeviceCustomMetadata { get; set; }

        /// <summary>
        /// ID of the affected device.
        /// </summary>
        [DataMember(Name = "device_id", IsRequired = false, EmitDefaultValue = false)]
        public string DeviceId { get; set; }

        /// <summary>
        /// Human-readable description of the event. Persisted when the event is created (so the creating code, including a provider, can supply a tailored description) and otherwise derived from the event.
        /// </summary>
        [DataMember(Name = "event_description", IsRequired = false, EmitDefaultValue = false)]
        public override string? EventDescription { get; set; }

        /// <summary>
        /// ID of the event.
        /// </summary>
        [DataMember(Name = "event_id", IsRequired = false, EmitDefaultValue = false)]
        public override string EventId { get; set; }

        [DataMember(Name = "event_type", IsRequired = true, EmitDefaultValue = false)]
        public override string EventType { get; } =
            "thermostat.temperature_threshold_no_longer_exceeded";

        /// <summary>
        /// Lower temperature limit, in °C, defined by the set threshold.
        /// </summary>
        [DataMember(Name = "lower_limit_celsius", IsRequired = false, EmitDefaultValue = false)]
        public float? LowerLimitCelsius { get; set; }

        /// <summary>
        /// Lower temperature limit, in °F, defined by the set threshold.
        /// </summary>
        [DataMember(Name = "lower_limit_fahrenheit", IsRequired = false, EmitDefaultValue = false)]
        public float? LowerLimitFahrenheit { get; set; }

        /// <summary>
        /// Date and time at which the event occurred.
        /// </summary>
        [DataMember(Name = "occurred_at", IsRequired = false, EmitDefaultValue = false)]
        public override string OccurredAt { get; set; }

        /// <summary>
        /// Temperature, in °C, reported by the affected thermostat.
        /// </summary>
        [DataMember(Name = "temperature_celsius", IsRequired = false, EmitDefaultValue = false)]
        public float TemperatureCelsius { get; set; }

        /// <summary>
        /// Temperature, in °F, reported by the affected thermostat.
        /// </summary>
        [DataMember(Name = "temperature_fahrenheit", IsRequired = false, EmitDefaultValue = false)]
        public float TemperatureFahrenheit { get; set; }

        /// <summary>
        /// Upper temperature limit, in °C, defined by the set threshold.
        /// </summary>
        [DataMember(Name = "upper_limit_celsius", IsRequired = false, EmitDefaultValue = false)]
        public float? UpperLimitCelsius { get; set; }

        /// <summary>
        /// Upper temperature limit, in °F, defined by the set threshold.
        /// </summary>
        [DataMember(Name = "upper_limit_fahrenheit", IsRequired = false, EmitDefaultValue = false)]
        public float? UpperLimitFahrenheit { get; set; }

        /// <summary>
        /// ID of the workspace associated with the event.
        /// </summary>
        [DataMember(Name = "workspace_id", IsRequired = false, EmitDefaultValue = false)]
        public override string WorkspaceId { get; set; }

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
    /// A [thermostat&apos;s](https://docs.seam.co/capability-guides/thermostats) temperature reading is within 1 °C of the configured cooling or heating [set point](https://docs.seam.co/capability-guides/thermostats/understanding-thermostat-concepts/set-points).
    /// </summary>
    [DataContract(Name = "seamModel_eventThermostatTemperatureReachedSetPoint_model")]
    public class EventThermostatTemperatureReachedSetPoint : Event
    {
        [JsonConstructorAttribute]
        protected EventThermostatTemperatureReachedSetPoint() { }

        public EventThermostatTemperatureReachedSetPoint(
            object? connectedAccountCustomMetadata = default,
            string connectedAccountId = default,
            string createdAt = default,
            string? customerKey = default,
            float? desiredTemperatureCelsius = default,
            float? desiredTemperatureFahrenheit = default,
            object? deviceCustomMetadata = default,
            string deviceId = default,
            string? eventDescription = default,
            string eventId = default,
            string eventType = default,
            string occurredAt = default,
            float temperatureCelsius = default,
            float temperatureFahrenheit = default,
            string workspaceId = default
        )
        {
            ConnectedAccountCustomMetadata = connectedAccountCustomMetadata;
            ConnectedAccountId = connectedAccountId;
            CreatedAt = createdAt;
            CustomerKey = customerKey;
            DesiredTemperatureCelsius = desiredTemperatureCelsius;
            DesiredTemperatureFahrenheit = desiredTemperatureFahrenheit;
            DeviceCustomMetadata = deviceCustomMetadata;
            DeviceId = deviceId;
            EventDescription = eventDescription;
            EventId = eventId;
            EventType = eventType;
            OccurredAt = occurredAt;
            TemperatureCelsius = temperatureCelsius;
            TemperatureFahrenheit = temperatureFahrenheit;
            WorkspaceId = workspaceId;
        }

        /// <summary>
        /// Custom metadata of the connected account, present when connected_account_id is provided.
        /// </summary>
        [DataMember(
            Name = "connected_account_custom_metadata",
            IsRequired = false,
            EmitDefaultValue = false
        )]
        public object? ConnectedAccountCustomMetadata { get; set; }

        /// <summary>
        /// ID of the connected account associated with the event.
        /// </summary>
        [DataMember(Name = "connected_account_id", IsRequired = false, EmitDefaultValue = false)]
        public string ConnectedAccountId { get; set; }

        /// <summary>
        /// Date and time at which the event was created.
        /// </summary>
        [DataMember(Name = "created_at", IsRequired = false, EmitDefaultValue = false)]
        public override string CreatedAt { get; set; }

        /// <summary>
        /// The customer key associated with the device, if any.
        /// </summary>
        [DataMember(Name = "customer_key", IsRequired = false, EmitDefaultValue = false)]
        public string? CustomerKey { get; set; }

        /// <summary>
        /// Desired temperature, in °C, defined by the affected thermostat&apos;s cooling or heating set point.
        /// </summary>
        [DataMember(
            Name = "desired_temperature_celsius",
            IsRequired = false,
            EmitDefaultValue = false
        )]
        public float? DesiredTemperatureCelsius { get; set; }

        /// <summary>
        /// Desired temperature, in °F, defined by the affected thermostat&apos;s cooling or heating set point.
        /// </summary>
        [DataMember(
            Name = "desired_temperature_fahrenheit",
            IsRequired = false,
            EmitDefaultValue = false
        )]
        public float? DesiredTemperatureFahrenheit { get; set; }

        /// <summary>
        /// Custom metadata of the device, present when device_id is provided.
        /// </summary>
        [DataMember(Name = "device_custom_metadata", IsRequired = false, EmitDefaultValue = false)]
        public object? DeviceCustomMetadata { get; set; }

        /// <summary>
        /// ID of the affected device.
        /// </summary>
        [DataMember(Name = "device_id", IsRequired = false, EmitDefaultValue = false)]
        public string DeviceId { get; set; }

        /// <summary>
        /// Human-readable description of the event. Persisted when the event is created (so the creating code, including a provider, can supply a tailored description) and otherwise derived from the event.
        /// </summary>
        [DataMember(Name = "event_description", IsRequired = false, EmitDefaultValue = false)]
        public override string? EventDescription { get; set; }

        /// <summary>
        /// ID of the event.
        /// </summary>
        [DataMember(Name = "event_id", IsRequired = false, EmitDefaultValue = false)]
        public override string EventId { get; set; }

        [DataMember(Name = "event_type", IsRequired = true, EmitDefaultValue = false)]
        public override string EventType { get; } = "thermostat.temperature_reached_set_point";

        /// <summary>
        /// Date and time at which the event occurred.
        /// </summary>
        [DataMember(Name = "occurred_at", IsRequired = false, EmitDefaultValue = false)]
        public override string OccurredAt { get; set; }

        /// <summary>
        /// Temperature, in °C, reported by the affected thermostat.
        /// </summary>
        [DataMember(Name = "temperature_celsius", IsRequired = false, EmitDefaultValue = false)]
        public float TemperatureCelsius { get; set; }

        /// <summary>
        /// Temperature, in °F, reported by the affected thermostat.
        /// </summary>
        [DataMember(Name = "temperature_fahrenheit", IsRequired = false, EmitDefaultValue = false)]
        public float TemperatureFahrenheit { get; set; }

        /// <summary>
        /// ID of the workspace associated with the event.
        /// </summary>
        [DataMember(Name = "workspace_id", IsRequired = false, EmitDefaultValue = false)]
        public override string WorkspaceId { get; set; }

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
    /// A [thermostat&apos;s](https://docs.seam.co/capability-guides/thermostats) reported temperature changed by at least 1 °C.
    /// </summary>
    [DataContract(Name = "seamModel_eventThermostatTemperatureChanged_model")]
    public class EventThermostatTemperatureChanged : Event
    {
        [JsonConstructorAttribute]
        protected EventThermostatTemperatureChanged() { }

        public EventThermostatTemperatureChanged(
            object? connectedAccountCustomMetadata = default,
            string connectedAccountId = default,
            string createdAt = default,
            string? customerKey = default,
            object? deviceCustomMetadata = default,
            string deviceId = default,
            string? eventDescription = default,
            string eventId = default,
            string eventType = default,
            string occurredAt = default,
            float temperatureCelsius = default,
            float temperatureFahrenheit = default,
            string workspaceId = default
        )
        {
            ConnectedAccountCustomMetadata = connectedAccountCustomMetadata;
            ConnectedAccountId = connectedAccountId;
            CreatedAt = createdAt;
            CustomerKey = customerKey;
            DeviceCustomMetadata = deviceCustomMetadata;
            DeviceId = deviceId;
            EventDescription = eventDescription;
            EventId = eventId;
            EventType = eventType;
            OccurredAt = occurredAt;
            TemperatureCelsius = temperatureCelsius;
            TemperatureFahrenheit = temperatureFahrenheit;
            WorkspaceId = workspaceId;
        }

        /// <summary>
        /// Custom metadata of the connected account, present when connected_account_id is provided.
        /// </summary>
        [DataMember(
            Name = "connected_account_custom_metadata",
            IsRequired = false,
            EmitDefaultValue = false
        )]
        public object? ConnectedAccountCustomMetadata { get; set; }

        /// <summary>
        /// ID of the connected account associated with the event.
        /// </summary>
        [DataMember(Name = "connected_account_id", IsRequired = false, EmitDefaultValue = false)]
        public string ConnectedAccountId { get; set; }

        /// <summary>
        /// Date and time at which the event was created.
        /// </summary>
        [DataMember(Name = "created_at", IsRequired = false, EmitDefaultValue = false)]
        public override string CreatedAt { get; set; }

        /// <summary>
        /// The customer key associated with the device, if any.
        /// </summary>
        [DataMember(Name = "customer_key", IsRequired = false, EmitDefaultValue = false)]
        public string? CustomerKey { get; set; }

        /// <summary>
        /// Custom metadata of the device, present when device_id is provided.
        /// </summary>
        [DataMember(Name = "device_custom_metadata", IsRequired = false, EmitDefaultValue = false)]
        public object? DeviceCustomMetadata { get; set; }

        /// <summary>
        /// ID of the affected device.
        /// </summary>
        [DataMember(Name = "device_id", IsRequired = false, EmitDefaultValue = false)]
        public string DeviceId { get; set; }

        /// <summary>
        /// Human-readable description of the event. Persisted when the event is created (so the creating code, including a provider, can supply a tailored description) and otherwise derived from the event.
        /// </summary>
        [DataMember(Name = "event_description", IsRequired = false, EmitDefaultValue = false)]
        public override string? EventDescription { get; set; }

        /// <summary>
        /// ID of the event.
        /// </summary>
        [DataMember(Name = "event_id", IsRequired = false, EmitDefaultValue = false)]
        public override string EventId { get; set; }

        [DataMember(Name = "event_type", IsRequired = true, EmitDefaultValue = false)]
        public override string EventType { get; } = "thermostat.temperature_changed";

        /// <summary>
        /// Date and time at which the event occurred.
        /// </summary>
        [DataMember(Name = "occurred_at", IsRequired = false, EmitDefaultValue = false)]
        public override string OccurredAt { get; set; }

        /// <summary>
        /// Temperature, in °C, reported by the affected thermostat.
        /// </summary>
        [DataMember(Name = "temperature_celsius", IsRequired = false, EmitDefaultValue = false)]
        public float TemperatureCelsius { get; set; }

        /// <summary>
        /// Temperature, in °F, reported by the affected thermostat.
        /// </summary>
        [DataMember(Name = "temperature_fahrenheit", IsRequired = false, EmitDefaultValue = false)]
        public float TemperatureFahrenheit { get; set; }

        /// <summary>
        /// ID of the workspace associated with the event.
        /// </summary>
        [DataMember(Name = "workspace_id", IsRequired = false, EmitDefaultValue = false)]
        public override string WorkspaceId { get; set; }

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
    /// The name of a device was changed.
    /// </summary>
    [DataContract(Name = "seamModel_eventDeviceNameChanged_model")]
    public class EventDeviceNameChanged : Event
    {
        [JsonConstructorAttribute]
        protected EventDeviceNameChanged() { }

        public EventDeviceNameChanged(
            object? connectedAccountCustomMetadata = default,
            string connectedAccountId = default,
            string createdAt = default,
            string? customerKey = default,
            object? deviceCustomMetadata = default,
            string deviceId = default,
            string deviceName = default,
            string? eventDescription = default,
            string eventId = default,
            string eventType = default,
            string occurredAt = default,
            string workspaceId = default
        )
        {
            ConnectedAccountCustomMetadata = connectedAccountCustomMetadata;
            ConnectedAccountId = connectedAccountId;
            CreatedAt = createdAt;
            CustomerKey = customerKey;
            DeviceCustomMetadata = deviceCustomMetadata;
            DeviceId = deviceId;
            DeviceName = deviceName;
            EventDescription = eventDescription;
            EventId = eventId;
            EventType = eventType;
            OccurredAt = occurredAt;
            WorkspaceId = workspaceId;
        }

        /// <summary>
        /// Custom metadata of the connected account, present when connected_account_id is provided.
        /// </summary>
        [DataMember(
            Name = "connected_account_custom_metadata",
            IsRequired = false,
            EmitDefaultValue = false
        )]
        public object? ConnectedAccountCustomMetadata { get; set; }

        /// <summary>
        /// ID of the connected account associated with the event.
        /// </summary>
        [DataMember(Name = "connected_account_id", IsRequired = false, EmitDefaultValue = false)]
        public string ConnectedAccountId { get; set; }

        /// <summary>
        /// Date and time at which the event was created.
        /// </summary>
        [DataMember(Name = "created_at", IsRequired = false, EmitDefaultValue = false)]
        public override string CreatedAt { get; set; }

        /// <summary>
        /// The customer key associated with the device, if any.
        /// </summary>
        [DataMember(Name = "customer_key", IsRequired = false, EmitDefaultValue = false)]
        public string? CustomerKey { get; set; }

        /// <summary>
        /// Custom metadata of the device, present when device_id is provided.
        /// </summary>
        [DataMember(Name = "device_custom_metadata", IsRequired = false, EmitDefaultValue = false)]
        public object? DeviceCustomMetadata { get; set; }

        /// <summary>
        /// ID of the affected device.
        /// </summary>
        [DataMember(Name = "device_id", IsRequired = false, EmitDefaultValue = false)]
        public string DeviceId { get; set; }

        /// <summary>
        /// The new name of the affected device.
        /// </summary>
        [DataMember(Name = "device_name", IsRequired = false, EmitDefaultValue = false)]
        public string DeviceName { get; set; }

        /// <summary>
        /// Human-readable description of the event. Persisted when the event is created (so the creating code, including a provider, can supply a tailored description) and otherwise derived from the event.
        /// </summary>
        [DataMember(Name = "event_description", IsRequired = false, EmitDefaultValue = false)]
        public override string? EventDescription { get; set; }

        /// <summary>
        /// ID of the event.
        /// </summary>
        [DataMember(Name = "event_id", IsRequired = false, EmitDefaultValue = false)]
        public override string EventId { get; set; }

        [DataMember(Name = "event_type", IsRequired = true, EmitDefaultValue = false)]
        public override string EventType { get; } = "device.name_changed";

        /// <summary>
        /// Date and time at which the event occurred.
        /// </summary>
        [DataMember(Name = "occurred_at", IsRequired = false, EmitDefaultValue = false)]
        public override string OccurredAt { get; set; }

        /// <summary>
        /// ID of the workspace associated with the event.
        /// </summary>
        [DataMember(Name = "workspace_id", IsRequired = false, EmitDefaultValue = false)]
        public override string WorkspaceId { get; set; }

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
    /// A camera was activated, for example, by motion detection.
    /// </summary>
    [DataContract(Name = "seamModel_eventCameraActivated_model")]
    public class EventCameraActivated : Event
    {
        [JsonConstructorAttribute]
        protected EventCameraActivated() { }

        public EventCameraActivated(
            EventCameraActivated.ActivationReasonEnum activationReason = default,
            object? connectedAccountCustomMetadata = default,
            string connectedAccountId = default,
            string createdAt = default,
            string? customerKey = default,
            object? deviceCustomMetadata = default,
            string deviceId = default,
            string? eventDescription = default,
            string eventId = default,
            string eventType = default,
            string? imageUrl = default,
            EventCameraActivated.MotionSubTypeEnum? motionSubType = default,
            string occurredAt = default,
            string? videoUrl = default,
            string workspaceId = default
        )
        {
            ActivationReason = activationReason;
            ConnectedAccountCustomMetadata = connectedAccountCustomMetadata;
            ConnectedAccountId = connectedAccountId;
            CreatedAt = createdAt;
            CustomerKey = customerKey;
            DeviceCustomMetadata = deviceCustomMetadata;
            DeviceId = deviceId;
            EventDescription = eventDescription;
            EventId = eventId;
            EventType = eventType;
            ImageUrl = imageUrl;
            MotionSubType = motionSubType;
            OccurredAt = occurredAt;
            VideoUrl = videoUrl;
            WorkspaceId = workspaceId;
        }

        /// <summary>
        /// The reason the camera was activated.
        /// </summary>
        [JsonConverter(typeof(SafeStringEnumConverter))]
        public enum ActivationReasonEnum
        {
            [EnumMember(Value = "unrecognized")]
            Unrecognized = 0,

            [EnumMember(Value = "motion_detected")]
            MotionDetected = 1,
        }

        /// <summary>
        /// Sub-type of motion detected, if available.
        /// </summary>
        [JsonConverter(typeof(SafeStringEnumConverter))]
        public enum MotionSubTypeEnum
        {
            [EnumMember(Value = "unrecognized")]
            Unrecognized = 0,

            [EnumMember(Value = "human")]
            Human = 1,

            [EnumMember(Value = "vehicle")]
            Vehicle = 2,

            [EnumMember(Value = "package")]
            Package = 3,

            [EnumMember(Value = "other")]
            Other = 4,
        }

        /// <summary>
        /// The reason the camera was activated.
        /// </summary>
        [DataMember(Name = "activation_reason", IsRequired = false, EmitDefaultValue = false)]
        public EventCameraActivated.ActivationReasonEnum ActivationReason { get; set; }

        /// <summary>
        /// Custom metadata of the connected account, present when connected_account_id is provided.
        /// </summary>
        [DataMember(
            Name = "connected_account_custom_metadata",
            IsRequired = false,
            EmitDefaultValue = false
        )]
        public object? ConnectedAccountCustomMetadata { get; set; }

        /// <summary>
        /// ID of the connected account associated with the event.
        /// </summary>
        [DataMember(Name = "connected_account_id", IsRequired = false, EmitDefaultValue = false)]
        public string ConnectedAccountId { get; set; }

        /// <summary>
        /// Date and time at which the event was created.
        /// </summary>
        [DataMember(Name = "created_at", IsRequired = false, EmitDefaultValue = false)]
        public override string CreatedAt { get; set; }

        /// <summary>
        /// The customer key associated with the device, if any.
        /// </summary>
        [DataMember(Name = "customer_key", IsRequired = false, EmitDefaultValue = false)]
        public string? CustomerKey { get; set; }

        /// <summary>
        /// Custom metadata of the device, present when device_id is provided.
        /// </summary>
        [DataMember(Name = "device_custom_metadata", IsRequired = false, EmitDefaultValue = false)]
        public object? DeviceCustomMetadata { get; set; }

        /// <summary>
        /// ID of the affected device.
        /// </summary>
        [DataMember(Name = "device_id", IsRequired = false, EmitDefaultValue = false)]
        public string DeviceId { get; set; }

        /// <summary>
        /// Human-readable description of the event. Persisted when the event is created (so the creating code, including a provider, can supply a tailored description) and otherwise derived from the event.
        /// </summary>
        [DataMember(Name = "event_description", IsRequired = false, EmitDefaultValue = false)]
        public override string? EventDescription { get; set; }

        /// <summary>
        /// ID of the event.
        /// </summary>
        [DataMember(Name = "event_id", IsRequired = false, EmitDefaultValue = false)]
        public override string EventId { get; set; }

        [DataMember(Name = "event_type", IsRequired = true, EmitDefaultValue = false)]
        public override string EventType { get; } = "camera.activated";

        /// <summary>
        /// URL to a thumbnail image captured at the time of activation.
        /// </summary>
        [DataMember(Name = "image_url", IsRequired = false, EmitDefaultValue = false)]
        public string? ImageUrl { get; set; }

        /// <summary>
        /// Sub-type of motion detected, if available.
        /// </summary>
        [DataMember(Name = "motion_sub_type", IsRequired = false, EmitDefaultValue = false)]
        public EventCameraActivated.MotionSubTypeEnum? MotionSubType { get; set; }

        /// <summary>
        /// Date and time at which the event occurred.
        /// </summary>
        [DataMember(Name = "occurred_at", IsRequired = false, EmitDefaultValue = false)]
        public override string OccurredAt { get; set; }

        /// <summary>
        /// URL to a short video clip captured at the time of activation.
        /// </summary>
        [DataMember(Name = "video_url", IsRequired = false, EmitDefaultValue = false)]
        public string? VideoUrl { get; set; }

        /// <summary>
        /// ID of the workspace associated with the event.
        /// </summary>
        [DataMember(Name = "workspace_id", IsRequired = false, EmitDefaultValue = false)]
        public override string WorkspaceId { get; set; }

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
    /// A doorbell button was pressed on a device.
    /// </summary>
    [DataContract(Name = "seamModel_eventDeviceDoorbellRang_model")]
    public class EventDeviceDoorbellRang : Event
    {
        [JsonConstructorAttribute]
        protected EventDeviceDoorbellRang() { }

        public EventDeviceDoorbellRang(
            object? connectedAccountCustomMetadata = default,
            string connectedAccountId = default,
            string createdAt = default,
            string? customerKey = default,
            object? deviceCustomMetadata = default,
            string deviceId = default,
            string? eventDescription = default,
            string eventId = default,
            string eventType = default,
            string? imageUrl = default,
            string occurredAt = default,
            string? videoUrl = default,
            string workspaceId = default
        )
        {
            ConnectedAccountCustomMetadata = connectedAccountCustomMetadata;
            ConnectedAccountId = connectedAccountId;
            CreatedAt = createdAt;
            CustomerKey = customerKey;
            DeviceCustomMetadata = deviceCustomMetadata;
            DeviceId = deviceId;
            EventDescription = eventDescription;
            EventId = eventId;
            EventType = eventType;
            ImageUrl = imageUrl;
            OccurredAt = occurredAt;
            VideoUrl = videoUrl;
            WorkspaceId = workspaceId;
        }

        /// <summary>
        /// Custom metadata of the connected account, present when connected_account_id is provided.
        /// </summary>
        [DataMember(
            Name = "connected_account_custom_metadata",
            IsRequired = false,
            EmitDefaultValue = false
        )]
        public object? ConnectedAccountCustomMetadata { get; set; }

        /// <summary>
        /// ID of the connected account associated with the event.
        /// </summary>
        [DataMember(Name = "connected_account_id", IsRequired = false, EmitDefaultValue = false)]
        public string ConnectedAccountId { get; set; }

        /// <summary>
        /// Date and time at which the event was created.
        /// </summary>
        [DataMember(Name = "created_at", IsRequired = false, EmitDefaultValue = false)]
        public override string CreatedAt { get; set; }

        /// <summary>
        /// The customer key associated with the device, if any.
        /// </summary>
        [DataMember(Name = "customer_key", IsRequired = false, EmitDefaultValue = false)]
        public string? CustomerKey { get; set; }

        /// <summary>
        /// Custom metadata of the device, present when device_id is provided.
        /// </summary>
        [DataMember(Name = "device_custom_metadata", IsRequired = false, EmitDefaultValue = false)]
        public object? DeviceCustomMetadata { get; set; }

        /// <summary>
        /// ID of the affected device.
        /// </summary>
        [DataMember(Name = "device_id", IsRequired = false, EmitDefaultValue = false)]
        public string DeviceId { get; set; }

        /// <summary>
        /// Human-readable description of the event. Persisted when the event is created (so the creating code, including a provider, can supply a tailored description) and otherwise derived from the event.
        /// </summary>
        [DataMember(Name = "event_description", IsRequired = false, EmitDefaultValue = false)]
        public override string? EventDescription { get; set; }

        /// <summary>
        /// ID of the event.
        /// </summary>
        [DataMember(Name = "event_id", IsRequired = false, EmitDefaultValue = false)]
        public override string EventId { get; set; }

        [DataMember(Name = "event_type", IsRequired = true, EmitDefaultValue = false)]
        public override string EventType { get; } = "device.doorbell_rang";

        /// <summary>
        /// URL to a thumbnail image captured at the time the doorbell was pressed.
        /// </summary>
        [DataMember(Name = "image_url", IsRequired = false, EmitDefaultValue = false)]
        public string? ImageUrl { get; set; }

        /// <summary>
        /// Date and time at which the event occurred.
        /// </summary>
        [DataMember(Name = "occurred_at", IsRequired = false, EmitDefaultValue = false)]
        public override string OccurredAt { get; set; }

        /// <summary>
        /// URL to a short video clip captured at the time the doorbell was pressed.
        /// </summary>
        [DataMember(Name = "video_url", IsRequired = false, EmitDefaultValue = false)]
        public string? VideoUrl { get; set; }

        /// <summary>
        /// ID of the workspace associated with the event.
        /// </summary>
        [DataMember(Name = "workspace_id", IsRequired = false, EmitDefaultValue = false)]
        public override string WorkspaceId { get; set; }

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
    /// A phone device was deactivated.
    /// </summary>
    [DataContract(Name = "seamModel_eventPhoneDeactivated_model")]
    public class EventPhoneDeactivated : Event
    {
        [JsonConstructorAttribute]
        protected EventPhoneDeactivated() { }

        public EventPhoneDeactivated(
            string createdAt = default,
            object? deviceCustomMetadata = default,
            string deviceId = default,
            string? eventDescription = default,
            string eventId = default,
            string eventType = default,
            string occurredAt = default,
            string workspaceId = default
        )
        {
            CreatedAt = createdAt;
            DeviceCustomMetadata = deviceCustomMetadata;
            DeviceId = deviceId;
            EventDescription = eventDescription;
            EventId = eventId;
            EventType = eventType;
            OccurredAt = occurredAt;
            WorkspaceId = workspaceId;
        }

        /// <summary>
        /// Date and time at which the event was created.
        /// </summary>
        [DataMember(Name = "created_at", IsRequired = false, EmitDefaultValue = false)]
        public override string CreatedAt { get; set; }

        /// <summary>
        /// Custom metadata of the device; present when device_id is provided.
        /// </summary>
        [DataMember(Name = "device_custom_metadata", IsRequired = false, EmitDefaultValue = false)]
        public object? DeviceCustomMetadata { get; set; }

        /// <summary>
        /// ID of the affected phone device.
        /// </summary>
        [DataMember(Name = "device_id", IsRequired = false, EmitDefaultValue = false)]
        public string DeviceId { get; set; }

        /// <summary>
        /// Human-readable description of the event. Persisted when the event is created (so the creating code, including a provider, can supply a tailored description) and otherwise derived from the event.
        /// </summary>
        [DataMember(Name = "event_description", IsRequired = false, EmitDefaultValue = false)]
        public override string? EventDescription { get; set; }

        /// <summary>
        /// ID of the event.
        /// </summary>
        [DataMember(Name = "event_id", IsRequired = false, EmitDefaultValue = false)]
        public override string EventId { get; set; }

        [DataMember(Name = "event_type", IsRequired = true, EmitDefaultValue = false)]
        public override string EventType { get; } = "phone.deactivated";

        /// <summary>
        /// Date and time at which the event occurred.
        /// </summary>
        [DataMember(Name = "occurred_at", IsRequired = false, EmitDefaultValue = false)]
        public override string OccurredAt { get; set; }

        /// <summary>
        /// ID of the workspace associated with the event.
        /// </summary>
        [DataMember(Name = "workspace_id", IsRequired = false, EmitDefaultValue = false)]
        public override string WorkspaceId { get; set; }

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
    /// A device was added or removed from a space.
    /// </summary>
    [DataContract(Name = "seamModel_eventSpaceDeviceMembershipChanged_model")]
    public class EventSpaceDeviceMembershipChanged : Event
    {
        [JsonConstructorAttribute]
        protected EventSpaceDeviceMembershipChanged() { }

        public EventSpaceDeviceMembershipChanged(
            List<string> acsEntranceIds = default,
            string createdAt = default,
            List<string> deviceIds = default,
            string? eventDescription = default,
            string eventId = default,
            string eventType = default,
            string occurredAt = default,
            string spaceId = default,
            string? spaceKey = default,
            string workspaceId = default
        )
        {
            AcsEntranceIds = acsEntranceIds;
            CreatedAt = createdAt;
            DeviceIds = deviceIds;
            EventDescription = eventDescription;
            EventId = eventId;
            EventType = eventType;
            OccurredAt = occurredAt;
            SpaceId = spaceId;
            SpaceKey = spaceKey;
            WorkspaceId = workspaceId;
        }

        /// <summary>
        /// IDs of all ACS entrances currently attached to the space.
        /// </summary>
        [DataMember(Name = "acs_entrance_ids", IsRequired = false, EmitDefaultValue = false)]
        public List<string> AcsEntranceIds { get; set; }

        /// <summary>
        /// Date and time at which the event was created.
        /// </summary>
        [DataMember(Name = "created_at", IsRequired = false, EmitDefaultValue = false)]
        public override string CreatedAt { get; set; }

        /// <summary>
        /// IDs of all devices currently attached to the space.
        /// </summary>
        [DataMember(Name = "device_ids", IsRequired = false, EmitDefaultValue = false)]
        public List<string> DeviceIds { get; set; }

        /// <summary>
        /// Human-readable description of the event. Persisted when the event is created (so the creating code, including a provider, can supply a tailored description) and otherwise derived from the event.
        /// </summary>
        [DataMember(Name = "event_description", IsRequired = false, EmitDefaultValue = false)]
        public override string? EventDescription { get; set; }

        /// <summary>
        /// ID of the event.
        /// </summary>
        [DataMember(Name = "event_id", IsRequired = false, EmitDefaultValue = false)]
        public override string EventId { get; set; }

        [DataMember(Name = "event_type", IsRequired = true, EmitDefaultValue = false)]
        public override string EventType { get; } = "space.device_membership_changed";

        /// <summary>
        /// Date and time at which the event occurred.
        /// </summary>
        [DataMember(Name = "occurred_at", IsRequired = false, EmitDefaultValue = false)]
        public override string OccurredAt { get; set; }

        /// <summary>
        /// ID of the affected space.
        /// </summary>
        [DataMember(Name = "space_id", IsRequired = false, EmitDefaultValue = false)]
        public string SpaceId { get; set; }

        /// <summary>
        /// Unique key for the space within the workspace.
        /// </summary>
        [DataMember(Name = "space_key", IsRequired = false, EmitDefaultValue = false)]
        public string? SpaceKey { get; set; }

        /// <summary>
        /// ID of the workspace associated with the event.
        /// </summary>
        [DataMember(Name = "workspace_id", IsRequired = false, EmitDefaultValue = false)]
        public override string WorkspaceId { get; set; }

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
    /// A space was created.
    /// </summary>
    [DataContract(Name = "seamModel_eventSpaceCreated_model")]
    public class EventSpaceCreated : Event
    {
        [JsonConstructorAttribute]
        protected EventSpaceCreated() { }

        public EventSpaceCreated(
            List<string> acsEntranceIds = default,
            string createdAt = default,
            List<string> deviceIds = default,
            string? eventDescription = default,
            string eventId = default,
            string eventType = default,
            string occurredAt = default,
            string spaceId = default,
            string? spaceKey = default,
            string workspaceId = default
        )
        {
            AcsEntranceIds = acsEntranceIds;
            CreatedAt = createdAt;
            DeviceIds = deviceIds;
            EventDescription = eventDescription;
            EventId = eventId;
            EventType = eventType;
            OccurredAt = occurredAt;
            SpaceId = spaceId;
            SpaceKey = spaceKey;
            WorkspaceId = workspaceId;
        }

        /// <summary>
        /// IDs of all ACS entrances attached to the space when it was created.
        /// </summary>
        [DataMember(Name = "acs_entrance_ids", IsRequired = false, EmitDefaultValue = false)]
        public List<string> AcsEntranceIds { get; set; }

        /// <summary>
        /// Date and time at which the event was created.
        /// </summary>
        [DataMember(Name = "created_at", IsRequired = false, EmitDefaultValue = false)]
        public override string CreatedAt { get; set; }

        /// <summary>
        /// IDs of all devices attached to the space when it was created.
        /// </summary>
        [DataMember(Name = "device_ids", IsRequired = false, EmitDefaultValue = false)]
        public List<string> DeviceIds { get; set; }

        /// <summary>
        /// Human-readable description of the event. Persisted when the event is created (so the creating code, including a provider, can supply a tailored description) and otherwise derived from the event.
        /// </summary>
        [DataMember(Name = "event_description", IsRequired = false, EmitDefaultValue = false)]
        public override string? EventDescription { get; set; }

        /// <summary>
        /// ID of the event.
        /// </summary>
        [DataMember(Name = "event_id", IsRequired = false, EmitDefaultValue = false)]
        public override string EventId { get; set; }

        [DataMember(Name = "event_type", IsRequired = true, EmitDefaultValue = false)]
        public override string EventType { get; } = "space.created";

        /// <summary>
        /// Date and time at which the event occurred.
        /// </summary>
        [DataMember(Name = "occurred_at", IsRequired = false, EmitDefaultValue = false)]
        public override string OccurredAt { get; set; }

        /// <summary>
        /// ID of the affected space.
        /// </summary>
        [DataMember(Name = "space_id", IsRequired = false, EmitDefaultValue = false)]
        public string SpaceId { get; set; }

        /// <summary>
        /// Unique key for the space within the workspace.
        /// </summary>
        [DataMember(Name = "space_key", IsRequired = false, EmitDefaultValue = false)]
        public string? SpaceKey { get; set; }

        /// <summary>
        /// ID of the workspace associated with the event.
        /// </summary>
        [DataMember(Name = "workspace_id", IsRequired = false, EmitDefaultValue = false)]
        public override string WorkspaceId { get; set; }

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
    /// A space was deleted.
    /// </summary>
    [DataContract(Name = "seamModel_eventSpaceDeleted_model")]
    public class EventSpaceDeleted : Event
    {
        [JsonConstructorAttribute]
        protected EventSpaceDeleted() { }

        public EventSpaceDeleted(
            List<string> acsEntranceIds = default,
            string createdAt = default,
            List<string> deviceIds = default,
            string? eventDescription = default,
            string eventId = default,
            string eventType = default,
            string occurredAt = default,
            string spaceId = default,
            string? spaceKey = default,
            string workspaceId = default
        )
        {
            AcsEntranceIds = acsEntranceIds;
            CreatedAt = createdAt;
            DeviceIds = deviceIds;
            EventDescription = eventDescription;
            EventId = eventId;
            EventType = eventType;
            OccurredAt = occurredAt;
            SpaceId = spaceId;
            SpaceKey = spaceKey;
            WorkspaceId = workspaceId;
        }

        /// <summary>
        /// IDs of all ACS entrances currently attached to the space when it was deleted.
        /// </summary>
        [DataMember(Name = "acs_entrance_ids", IsRequired = false, EmitDefaultValue = false)]
        public List<string> AcsEntranceIds { get; set; }

        /// <summary>
        /// Date and time at which the event was created.
        /// </summary>
        [DataMember(Name = "created_at", IsRequired = false, EmitDefaultValue = false)]
        public override string CreatedAt { get; set; }

        /// <summary>
        /// IDs of all devices attached to the space when it was deleted.
        /// </summary>
        [DataMember(Name = "device_ids", IsRequired = false, EmitDefaultValue = false)]
        public List<string> DeviceIds { get; set; }

        /// <summary>
        /// Human-readable description of the event. Persisted when the event is created (so the creating code, including a provider, can supply a tailored description) and otherwise derived from the event.
        /// </summary>
        [DataMember(Name = "event_description", IsRequired = false, EmitDefaultValue = false)]
        public override string? EventDescription { get; set; }

        /// <summary>
        /// ID of the event.
        /// </summary>
        [DataMember(Name = "event_id", IsRequired = false, EmitDefaultValue = false)]
        public override string EventId { get; set; }

        [DataMember(Name = "event_type", IsRequired = true, EmitDefaultValue = false)]
        public override string EventType { get; } = "space.deleted";

        /// <summary>
        /// Date and time at which the event occurred.
        /// </summary>
        [DataMember(Name = "occurred_at", IsRequired = false, EmitDefaultValue = false)]
        public override string OccurredAt { get; set; }

        /// <summary>
        /// ID of the affected space.
        /// </summary>
        [DataMember(Name = "space_id", IsRequired = false, EmitDefaultValue = false)]
        public string SpaceId { get; set; }

        /// <summary>
        /// Unique key for the space within the workspace.
        /// </summary>
        [DataMember(Name = "space_key", IsRequired = false, EmitDefaultValue = false)]
        public string? SpaceKey { get; set; }

        /// <summary>
        /// ID of the workspace associated with the event.
        /// </summary>
        [DataMember(Name = "workspace_id", IsRequired = false, EmitDefaultValue = false)]
        public override string WorkspaceId { get; set; }

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

    [DataContract(Name = "seamModel_eventUnrecognized_model")]
    public class EventUnrecognized : Event
    {
        [JsonConstructorAttribute]
        protected EventUnrecognized() { }

        public EventUnrecognized(
            string eventType = default,
            string createdAt = default,
            string? eventDescription = default,
            string eventId = default,
            string occurredAt = default,
            string workspaceId = default
        )
        {
            EventType = eventType;
            CreatedAt = createdAt;
            EventDescription = eventDescription;
            EventId = eventId;
            OccurredAt = occurredAt;
            WorkspaceId = workspaceId;
        }

        [DataMember(Name = "event_type", IsRequired = true, EmitDefaultValue = false)]
        public override string EventType { get; } = "unrecognized";

        /// <summary>
        /// Date and time at which the event was created.
        /// </summary>
        [DataMember(Name = "created_at", IsRequired = false, EmitDefaultValue = false)]
        public override string CreatedAt { get; set; }

        /// <summary>
        /// Human-readable description of the event. Persisted when the event is created (so the creating code, including a provider, can supply a tailored description) and otherwise derived from the event.
        /// </summary>
        [DataMember(Name = "event_description", IsRequired = false, EmitDefaultValue = false)]
        public override string? EventDescription { get; set; }

        /// <summary>
        /// ID of the event.
        /// </summary>
        [DataMember(Name = "event_id", IsRequired = false, EmitDefaultValue = false)]
        public override string EventId { get; set; }

        /// <summary>
        /// Date and time at which the event occurred.
        /// </summary>
        [DataMember(Name = "occurred_at", IsRequired = false, EmitDefaultValue = false)]
        public override string OccurredAt { get; set; }

        /// <summary>
        /// ID of the workspace associated with the event.
        /// </summary>
        [DataMember(Name = "workspace_id", IsRequired = false, EmitDefaultValue = false)]
        public override string WorkspaceId { get; set; }

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
