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
                string? deviceId = default,
                string? eventId = default,
                string? eventType = default
            )
            {
                DeviceId = deviceId;
                EventId = eventId;
                EventType = eventType;
            }

            [DataMember(Name = "device_id", IsRequired = false, EmitDefaultValue = false)]
            public string? DeviceId { get; set; }

            [DataMember(Name = "event_id", IsRequired = false, EmitDefaultValue = false)]
            public string? EventId { get; set; }

            [DataMember(Name = "event_type", IsRequired = false, EmitDefaultValue = false)]
            public string? EventType { get; set; }

            public override string ToString()
            {
                JsonSerializer jsonSerializer = JsonSerializer.CreateDefault(null);

                StringWriter stringWriter = new StringWriter(
                    new StringBuilder(256),
                    System.Globalization.CultureInfo.InvariantCulture
                );
                using (JsonTextWriter jsonTextWriter = new JsonTextWriter(stringWriter))
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
            string? deviceId = default,
            string? eventId = default,
            string? eventType = default
        )
        {
            return Get(new GetRequest(deviceId: deviceId, eventId: eventId, eventType: eventType));
        }

        public async Task<Event> GetAsync(GetRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            return (await _seam.PostAsync<GetResponse>("/events/get", requestOptions)).Data.Event;
        }

        public async Task<Event> GetAsync(
            string? deviceId = default,
            string? eventId = default,
            string? eventType = default
        )
        {
            return (
                await GetAsync(
                    new GetRequest(deviceId: deviceId, eventId: eventId, eventType: eventType)
                )
            );
        }

        [DataContract(Name = "listRequest_request")]
        public class ListRequest
        {
            [JsonConstructorAttribute]
            protected ListRequest() { }

            public ListRequest(
                string? accessCodeId = default,
                List<string>? accessCodeIds = default,
                string? acsSystemId = default,
                List<string>? acsSystemIds = default,
                List<string>? between = default,
                string? connectWebviewId = default,
                string? connectedAccountId = default,
                string? deviceId = default,
                List<string>? deviceIds = default,
                List<string>? eventIds = default,
                ListRequest.EventTypeEnum? eventType = default,
                List<ListRequest.EventTypesEnum>? eventTypes = default,
                float? limit = default,
                string? since = default,
                float? unstableOffset = default
            )
            {
                AccessCodeId = accessCodeId;
                AccessCodeIds = accessCodeIds;
                AcsSystemId = acsSystemId;
                AcsSystemIds = acsSystemIds;
                Between = between;
                ConnectWebviewId = connectWebviewId;
                ConnectedAccountId = connectedAccountId;
                DeviceId = deviceId;
                DeviceIds = deviceIds;
                EventIds = eventIds;
                EventType = eventType;
                EventTypes = eventTypes;
                Limit = limit;
                Since = since;
                UnstableOffset = unstableOffset;
            }

            [JsonConverter(typeof(SafeStringEnumConverter))]
            public enum EventTypeEnum
            {
                [EnumMember(Value = "unrecognized")]
                Unrecognized = 0,

                [EnumMember(Value = "access_code.created")]
                AccessCodeCreated = 1,

                [EnumMember(Value = "access_code.changed")]
                AccessCodeChanged = 2,

                [EnumMember(Value = "access_code.scheduled_on_device")]
                AccessCodeScheduledOnDevice = 3,

                [EnumMember(Value = "access_code.set_on_device")]
                AccessCodeSetOnDevice = 4,

                [EnumMember(Value = "access_code.removed_from_device")]
                AccessCodeRemovedFromDevice = 5,

                [EnumMember(Value = "access_code.delay_in_setting_on_device")]
                AccessCodeDelayInSettingOnDevice = 6,

                [EnumMember(Value = "access_code.failed_to_set_on_device")]
                AccessCodeFailedToSetOnDevice = 7,

                [EnumMember(Value = "access_code.deleted")]
                AccessCodeDeleted = 8,

                [EnumMember(Value = "access_code.delay_in_removing_from_device")]
                AccessCodeDelayInRemovingFromDevice = 9,

                [EnumMember(Value = "access_code.failed_to_remove_from_device")]
                AccessCodeFailedToRemoveFromDevice = 10,

                [EnumMember(Value = "access_code.modified_external_to_seam")]
                AccessCodeModifiedExternalToSeam = 11,

                [EnumMember(Value = "access_code.deleted_external_to_seam")]
                AccessCodeDeletedExternalToSeam = 12,

                [EnumMember(Value = "access_code.backup_access_code_pulled")]
                AccessCodeBackupAccessCodePulled = 13,

                [EnumMember(Value = "access_code.unmanaged.converted_to_managed")]
                AccessCodeUnmanagedConvertedToManaged = 14,

                [EnumMember(Value = "access_code.unmanaged.failed_to_convert_to_managed")]
                AccessCodeUnmanagedFailedToConvertToManaged = 15,

                [EnumMember(Value = "access_code.unmanaged.created")]
                AccessCodeUnmanagedCreated = 16,

                [EnumMember(Value = "access_code.unmanaged.removed")]
                AccessCodeUnmanagedRemoved = 17,

                [EnumMember(Value = "acs_system.connected")]
                AcsSystemConnected = 18,

                [EnumMember(Value = "acs_system.added")]
                AcsSystemAdded = 19,

                [EnumMember(Value = "acs_system.disconnected")]
                AcsSystemDisconnected = 20,

                [EnumMember(Value = "acs_credential.deleted")]
                AcsCredentialDeleted = 21,

                [EnumMember(Value = "acs_credential.issued")]
                AcsCredentialIssued = 22,

                [EnumMember(Value = "acs_credential.reissued")]
                AcsCredentialReissued = 23,

                [EnumMember(Value = "acs_user.deleted")]
                AcsUserDeleted = 24,

                [EnumMember(Value = "acs_encoder.added")]
                AcsEncoderAdded = 25,

                [EnumMember(Value = "acs_encoder.removed")]
                AcsEncoderRemoved = 26,

                [EnumMember(Value = "acs_access_group.deleted")]
                AcsAccessGroupDeleted = 27,

                [EnumMember(Value = "client_session.deleted")]
                ClientSessionDeleted = 28,

                [EnumMember(Value = "connected_account.connected")]
                ConnectedAccountConnected = 29,

                [EnumMember(Value = "connected_account.created")]
                ConnectedAccountCreated = 30,

                [EnumMember(Value = "connected_account.successful_login")]
                ConnectedAccountSuccessfulLogin = 31,

                [EnumMember(Value = "connected_account.disconnected")]
                ConnectedAccountDisconnected = 32,

                [EnumMember(Value = "connected_account.completed_first_sync")]
                ConnectedAccountCompletedFirstSync = 33,

                [EnumMember(Value = "connected_account.deleted")]
                ConnectedAccountDeleted = 34,

                [EnumMember(Value = "connected_account.completed_first_sync_after_reconnection")]
                ConnectedAccountCompletedFirstSyncAfterReconnection = 35,

                [EnumMember(Value = "action_attempt.lock_door.succeeded")]
                ActionAttemptLockDoorSucceeded = 36,

                [EnumMember(Value = "action_attempt.lock_door.failed")]
                ActionAttemptLockDoorFailed = 37,

                [EnumMember(Value = "action_attempt.unlock_door.succeeded")]
                ActionAttemptUnlockDoorSucceeded = 38,

                [EnumMember(Value = "action_attempt.unlock_door.failed")]
                ActionAttemptUnlockDoorFailed = 39,

                [EnumMember(Value = "connect_webview.login_succeeded")]
                ConnectWebviewLoginSucceeded = 40,

                [EnumMember(Value = "connect_webview.login_failed")]
                ConnectWebviewLoginFailed = 41,

                [EnumMember(Value = "device.connected")]
                DeviceConnected = 42,

                [EnumMember(Value = "device.added")]
                DeviceAdded = 43,

                [EnumMember(Value = "device.converted_to_unmanaged")]
                DeviceConvertedToUnmanaged = 44,

                [EnumMember(Value = "device.unmanaged.converted_to_managed")]
                DeviceUnmanagedConvertedToManaged = 45,

                [EnumMember(Value = "device.unmanaged.connected")]
                DeviceUnmanagedConnected = 46,

                [EnumMember(Value = "device.disconnected")]
                DeviceDisconnected = 47,

                [EnumMember(Value = "device.unmanaged.disconnected")]
                DeviceUnmanagedDisconnected = 48,

                [EnumMember(Value = "device.tampered")]
                DeviceTampered = 49,

                [EnumMember(Value = "device.low_battery")]
                DeviceLowBattery = 50,

                [EnumMember(Value = "device.battery_status_changed")]
                DeviceBatteryStatusChanged = 51,

                [EnumMember(Value = "device.removed")]
                DeviceRemoved = 52,

                [EnumMember(Value = "device.deleted")]
                DeviceDeleted = 53,

                [EnumMember(Value = "device.third_party_integration_detected")]
                DeviceThirdPartyIntegrationDetected = 54,

                [EnumMember(Value = "device.third_party_integration_no_longer_detected")]
                DeviceThirdPartyIntegrationNoLongerDetected = 55,

                [EnumMember(Value = "device.salto.privacy_mode_activated")]
                DeviceSaltoPrivacyModeActivated = 56,

                [EnumMember(Value = "device.salto.privacy_mode_deactivated")]
                DeviceSaltoPrivacyModeDeactivated = 57,

                [EnumMember(Value = "device.connection_became_flaky")]
                DeviceConnectionBecameFlaky = 58,

                [EnumMember(Value = "device.connection_stabilized")]
                DeviceConnectionStabilized = 59,

                [EnumMember(Value = "device.error.subscription_required")]
                DeviceErrorSubscriptionRequired = 60,

                [EnumMember(Value = "device.error.subscription_required.resolved")]
                DeviceErrorSubscriptionRequiredResolved = 61,

                [EnumMember(Value = "device.accessory_keypad_connected")]
                DeviceAccessoryKeypadConnected = 62,

                [EnumMember(Value = "device.accessory_keypad_disconnected")]
                DeviceAccessoryKeypadDisconnected = 63,

                [EnumMember(Value = "noise_sensor.noise_threshold_triggered")]
                NoiseSensorNoiseThresholdTriggered = 64,

                [EnumMember(Value = "lock.locked")]
                LockLocked = 65,

                [EnumMember(Value = "lock.unlocked")]
                LockUnlocked = 66,

                [EnumMember(Value = "lock.access_denied")]
                LockAccessDenied = 67,

                [EnumMember(Value = "thermostat.climate_preset_activated")]
                ThermostatClimatePresetActivated = 68,

                [EnumMember(Value = "thermostat.manually_adjusted")]
                ThermostatManuallyAdjusted = 69,

                [EnumMember(Value = "thermostat.temperature_threshold_exceeded")]
                ThermostatTemperatureThresholdExceeded = 70,

                [EnumMember(Value = "thermostat.temperature_threshold_no_longer_exceeded")]
                ThermostatTemperatureThresholdNoLongerExceeded = 71,

                [EnumMember(Value = "thermostat.temperature_reached_set_point")]
                ThermostatTemperatureReachedSetPoint = 72,

                [EnumMember(Value = "thermostat.temperature_changed")]
                ThermostatTemperatureChanged = 73,

                [EnumMember(Value = "enrollment_automation.deleted")]
                EnrollmentAutomationDeleted = 74,

                [EnumMember(Value = "phone.deactivated")]
                PhoneDeactivated = 75,
            }

            [JsonConverter(typeof(SafeStringEnumConverter))]
            public enum EventTypesEnum
            {
                [EnumMember(Value = "unrecognized")]
                Unrecognized = 0,

                [EnumMember(Value = "access_code.created")]
                AccessCodeCreated = 1,

                [EnumMember(Value = "access_code.changed")]
                AccessCodeChanged = 2,

                [EnumMember(Value = "access_code.scheduled_on_device")]
                AccessCodeScheduledOnDevice = 3,

                [EnumMember(Value = "access_code.set_on_device")]
                AccessCodeSetOnDevice = 4,

                [EnumMember(Value = "access_code.removed_from_device")]
                AccessCodeRemovedFromDevice = 5,

                [EnumMember(Value = "access_code.delay_in_setting_on_device")]
                AccessCodeDelayInSettingOnDevice = 6,

                [EnumMember(Value = "access_code.failed_to_set_on_device")]
                AccessCodeFailedToSetOnDevice = 7,

                [EnumMember(Value = "access_code.deleted")]
                AccessCodeDeleted = 8,

                [EnumMember(Value = "access_code.delay_in_removing_from_device")]
                AccessCodeDelayInRemovingFromDevice = 9,

                [EnumMember(Value = "access_code.failed_to_remove_from_device")]
                AccessCodeFailedToRemoveFromDevice = 10,

                [EnumMember(Value = "access_code.modified_external_to_seam")]
                AccessCodeModifiedExternalToSeam = 11,

                [EnumMember(Value = "access_code.deleted_external_to_seam")]
                AccessCodeDeletedExternalToSeam = 12,

                [EnumMember(Value = "access_code.backup_access_code_pulled")]
                AccessCodeBackupAccessCodePulled = 13,

                [EnumMember(Value = "access_code.unmanaged.converted_to_managed")]
                AccessCodeUnmanagedConvertedToManaged = 14,

                [EnumMember(Value = "access_code.unmanaged.failed_to_convert_to_managed")]
                AccessCodeUnmanagedFailedToConvertToManaged = 15,

                [EnumMember(Value = "access_code.unmanaged.created")]
                AccessCodeUnmanagedCreated = 16,

                [EnumMember(Value = "access_code.unmanaged.removed")]
                AccessCodeUnmanagedRemoved = 17,

                [EnumMember(Value = "acs_system.connected")]
                AcsSystemConnected = 18,

                [EnumMember(Value = "acs_system.added")]
                AcsSystemAdded = 19,

                [EnumMember(Value = "acs_system.disconnected")]
                AcsSystemDisconnected = 20,

                [EnumMember(Value = "acs_credential.deleted")]
                AcsCredentialDeleted = 21,

                [EnumMember(Value = "acs_credential.issued")]
                AcsCredentialIssued = 22,

                [EnumMember(Value = "acs_credential.reissued")]
                AcsCredentialReissued = 23,

                [EnumMember(Value = "acs_user.deleted")]
                AcsUserDeleted = 24,

                [EnumMember(Value = "acs_encoder.added")]
                AcsEncoderAdded = 25,

                [EnumMember(Value = "acs_encoder.removed")]
                AcsEncoderRemoved = 26,

                [EnumMember(Value = "acs_access_group.deleted")]
                AcsAccessGroupDeleted = 27,

                [EnumMember(Value = "client_session.deleted")]
                ClientSessionDeleted = 28,

                [EnumMember(Value = "connected_account.connected")]
                ConnectedAccountConnected = 29,

                [EnumMember(Value = "connected_account.created")]
                ConnectedAccountCreated = 30,

                [EnumMember(Value = "connected_account.successful_login")]
                ConnectedAccountSuccessfulLogin = 31,

                [EnumMember(Value = "connected_account.disconnected")]
                ConnectedAccountDisconnected = 32,

                [EnumMember(Value = "connected_account.completed_first_sync")]
                ConnectedAccountCompletedFirstSync = 33,

                [EnumMember(Value = "connected_account.deleted")]
                ConnectedAccountDeleted = 34,

                [EnumMember(Value = "connected_account.completed_first_sync_after_reconnection")]
                ConnectedAccountCompletedFirstSyncAfterReconnection = 35,

                [EnumMember(Value = "action_attempt.lock_door.succeeded")]
                ActionAttemptLockDoorSucceeded = 36,

                [EnumMember(Value = "action_attempt.lock_door.failed")]
                ActionAttemptLockDoorFailed = 37,

                [EnumMember(Value = "action_attempt.unlock_door.succeeded")]
                ActionAttemptUnlockDoorSucceeded = 38,

                [EnumMember(Value = "action_attempt.unlock_door.failed")]
                ActionAttemptUnlockDoorFailed = 39,

                [EnumMember(Value = "connect_webview.login_succeeded")]
                ConnectWebviewLoginSucceeded = 40,

                [EnumMember(Value = "connect_webview.login_failed")]
                ConnectWebviewLoginFailed = 41,

                [EnumMember(Value = "device.connected")]
                DeviceConnected = 42,

                [EnumMember(Value = "device.added")]
                DeviceAdded = 43,

                [EnumMember(Value = "device.converted_to_unmanaged")]
                DeviceConvertedToUnmanaged = 44,

                [EnumMember(Value = "device.unmanaged.converted_to_managed")]
                DeviceUnmanagedConvertedToManaged = 45,

                [EnumMember(Value = "device.unmanaged.connected")]
                DeviceUnmanagedConnected = 46,

                [EnumMember(Value = "device.disconnected")]
                DeviceDisconnected = 47,

                [EnumMember(Value = "device.unmanaged.disconnected")]
                DeviceUnmanagedDisconnected = 48,

                [EnumMember(Value = "device.tampered")]
                DeviceTampered = 49,

                [EnumMember(Value = "device.low_battery")]
                DeviceLowBattery = 50,

                [EnumMember(Value = "device.battery_status_changed")]
                DeviceBatteryStatusChanged = 51,

                [EnumMember(Value = "device.removed")]
                DeviceRemoved = 52,

                [EnumMember(Value = "device.deleted")]
                DeviceDeleted = 53,

                [EnumMember(Value = "device.third_party_integration_detected")]
                DeviceThirdPartyIntegrationDetected = 54,

                [EnumMember(Value = "device.third_party_integration_no_longer_detected")]
                DeviceThirdPartyIntegrationNoLongerDetected = 55,

                [EnumMember(Value = "device.salto.privacy_mode_activated")]
                DeviceSaltoPrivacyModeActivated = 56,

                [EnumMember(Value = "device.salto.privacy_mode_deactivated")]
                DeviceSaltoPrivacyModeDeactivated = 57,

                [EnumMember(Value = "device.connection_became_flaky")]
                DeviceConnectionBecameFlaky = 58,

                [EnumMember(Value = "device.connection_stabilized")]
                DeviceConnectionStabilized = 59,

                [EnumMember(Value = "device.error.subscription_required")]
                DeviceErrorSubscriptionRequired = 60,

                [EnumMember(Value = "device.error.subscription_required.resolved")]
                DeviceErrorSubscriptionRequiredResolved = 61,

                [EnumMember(Value = "device.accessory_keypad_connected")]
                DeviceAccessoryKeypadConnected = 62,

                [EnumMember(Value = "device.accessory_keypad_disconnected")]
                DeviceAccessoryKeypadDisconnected = 63,

                [EnumMember(Value = "noise_sensor.noise_threshold_triggered")]
                NoiseSensorNoiseThresholdTriggered = 64,

                [EnumMember(Value = "lock.locked")]
                LockLocked = 65,

                [EnumMember(Value = "lock.unlocked")]
                LockUnlocked = 66,

                [EnumMember(Value = "lock.access_denied")]
                LockAccessDenied = 67,

                [EnumMember(Value = "thermostat.climate_preset_activated")]
                ThermostatClimatePresetActivated = 68,

                [EnumMember(Value = "thermostat.manually_adjusted")]
                ThermostatManuallyAdjusted = 69,

                [EnumMember(Value = "thermostat.temperature_threshold_exceeded")]
                ThermostatTemperatureThresholdExceeded = 70,

                [EnumMember(Value = "thermostat.temperature_threshold_no_longer_exceeded")]
                ThermostatTemperatureThresholdNoLongerExceeded = 71,

                [EnumMember(Value = "thermostat.temperature_reached_set_point")]
                ThermostatTemperatureReachedSetPoint = 72,

                [EnumMember(Value = "thermostat.temperature_changed")]
                ThermostatTemperatureChanged = 73,

                [EnumMember(Value = "enrollment_automation.deleted")]
                EnrollmentAutomationDeleted = 74,

                [EnumMember(Value = "phone.deactivated")]
                PhoneDeactivated = 75,
            }

            [DataMember(Name = "access_code_id", IsRequired = false, EmitDefaultValue = false)]
            public string? AccessCodeId { get; set; }

            [DataMember(Name = "access_code_ids", IsRequired = false, EmitDefaultValue = false)]
            public List<string>? AccessCodeIds { get; set; }

            [DataMember(Name = "acs_system_id", IsRequired = false, EmitDefaultValue = false)]
            public string? AcsSystemId { get; set; }

            [DataMember(Name = "acs_system_ids", IsRequired = false, EmitDefaultValue = false)]
            public List<string>? AcsSystemIds { get; set; }

            [DataMember(Name = "between", IsRequired = false, EmitDefaultValue = false)]
            public List<string>? Between { get; set; }

            [DataMember(Name = "connect_webview_id", IsRequired = false, EmitDefaultValue = false)]
            public string? ConnectWebviewId { get; set; }

            [DataMember(
                Name = "connected_account_id",
                IsRequired = false,
                EmitDefaultValue = false
            )]
            public string? ConnectedAccountId { get; set; }

            [DataMember(Name = "device_id", IsRequired = false, EmitDefaultValue = false)]
            public string? DeviceId { get; set; }

            [DataMember(Name = "device_ids", IsRequired = false, EmitDefaultValue = false)]
            public List<string>? DeviceIds { get; set; }

            [DataMember(Name = "event_ids", IsRequired = false, EmitDefaultValue = false)]
            public List<string>? EventIds { get; set; }

            [DataMember(Name = "event_type", IsRequired = false, EmitDefaultValue = false)]
            public ListRequest.EventTypeEnum? EventType { get; set; }

            [DataMember(Name = "event_types", IsRequired = false, EmitDefaultValue = false)]
            public List<ListRequest.EventTypesEnum>? EventTypes { get; set; }

            [DataMember(Name = "limit", IsRequired = false, EmitDefaultValue = false)]
            public float? Limit { get; set; }

            [DataMember(Name = "since", IsRequired = false, EmitDefaultValue = false)]
            public string? Since { get; set; }

            [DataMember(Name = "unstable_offset", IsRequired = false, EmitDefaultValue = false)]
            public float? UnstableOffset { get; set; }

            public override string ToString()
            {
                JsonSerializer jsonSerializer = JsonSerializer.CreateDefault(null);

                StringWriter stringWriter = new StringWriter(
                    new StringBuilder(256),
                    System.Globalization.CultureInfo.InvariantCulture
                );
                using (JsonTextWriter jsonTextWriter = new JsonTextWriter(stringWriter))
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

            public ListResponse(List<Event> events = default)
            {
                Events = events;
            }

            [DataMember(Name = "events", IsRequired = false, EmitDefaultValue = false)]
            public List<Event> Events { get; set; }

            public override string ToString()
            {
                JsonSerializer jsonSerializer = JsonSerializer.CreateDefault(null);

                StringWriter stringWriter = new StringWriter(
                    new StringBuilder(256),
                    System.Globalization.CultureInfo.InvariantCulture
                );
                using (JsonTextWriter jsonTextWriter = new JsonTextWriter(stringWriter))
                {
                    jsonTextWriter.IndentChar = ' ';
                    jsonTextWriter.Indentation = 2;
                    jsonTextWriter.Formatting = Formatting.Indented;
                    jsonSerializer.Serialize(jsonTextWriter, this, null);
                }

                return stringWriter.ToString();
            }
        }

        public List<Event> List(ListRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            return _seam.Post<ListResponse>("/events/list", requestOptions).Data.Events;
        }

        public List<Event> List(
            string? accessCodeId = default,
            List<string>? accessCodeIds = default,
            string? acsSystemId = default,
            List<string>? acsSystemIds = default,
            List<string>? between = default,
            string? connectWebviewId = default,
            string? connectedAccountId = default,
            string? deviceId = default,
            List<string>? deviceIds = default,
            List<string>? eventIds = default,
            ListRequest.EventTypeEnum? eventType = default,
            List<ListRequest.EventTypesEnum>? eventTypes = default,
            float? limit = default,
            string? since = default,
            float? unstableOffset = default
        )
        {
            return List(
                new ListRequest(
                    accessCodeId: accessCodeId,
                    accessCodeIds: accessCodeIds,
                    acsSystemId: acsSystemId,
                    acsSystemIds: acsSystemIds,
                    between: between,
                    connectWebviewId: connectWebviewId,
                    connectedAccountId: connectedAccountId,
                    deviceId: deviceId,
                    deviceIds: deviceIds,
                    eventIds: eventIds,
                    eventType: eventType,
                    eventTypes: eventTypes,
                    limit: limit,
                    since: since,
                    unstableOffset: unstableOffset
                )
            );
        }

        public async Task<List<Event>> ListAsync(ListRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            return (await _seam.PostAsync<ListResponse>("/events/list", requestOptions))
                .Data
                .Events;
        }

        public async Task<List<Event>> ListAsync(
            string? accessCodeId = default,
            List<string>? accessCodeIds = default,
            string? acsSystemId = default,
            List<string>? acsSystemIds = default,
            List<string>? between = default,
            string? connectWebviewId = default,
            string? connectedAccountId = default,
            string? deviceId = default,
            List<string>? deviceIds = default,
            List<string>? eventIds = default,
            ListRequest.EventTypeEnum? eventType = default,
            List<ListRequest.EventTypesEnum>? eventTypes = default,
            float? limit = default,
            string? since = default,
            float? unstableOffset = default
        )
        {
            return (
                await ListAsync(
                    new ListRequest(
                        accessCodeId: accessCodeId,
                        accessCodeIds: accessCodeIds,
                        acsSystemId: acsSystemId,
                        acsSystemIds: acsSystemIds,
                        between: between,
                        connectWebviewId: connectWebviewId,
                        connectedAccountId: connectedAccountId,
                        deviceId: deviceId,
                        deviceIds: deviceIds,
                        eventIds: eventIds,
                        eventType: eventType,
                        eventTypes: eventTypes,
                        limit: limit,
                        since: since,
                        unstableOffset: unstableOffset
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
