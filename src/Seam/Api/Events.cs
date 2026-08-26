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

        /// <summary>
        /// Request parameters for Get an Event.
        /// </summary>
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

            /// <summary>
            /// Unique identifier for the device that triggered the event that you want to get.
            /// </summary>
            [DataMember(Name = "device_id", IsRequired = false, EmitDefaultValue = false)]
            public string? DeviceId { get; set; }

            /// <summary>
            /// Unique identifier for the event that you want to get.
            /// </summary>
            [DataMember(Name = "event_id", IsRequired = false, EmitDefaultValue = false)]
            public string? EventId { get; set; }

            /// <summary>
            /// Type of the event that you want to get.
            /// </summary>
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

            public GetResponse(Event event_ = default)
            {
                Event = event_;
            }

            /// <summary>
            /// OK
            /// </summary>
            [DataMember(Name = "event", IsRequired = false, EmitDefaultValue = false)]
            public Event Event { get; set; }

            public override string ToString()
            {
                JsonSerializer jsonSerializer = JsonSerializer.CreateDefault(null);

                StringWriter stringWriter = new StringWriter(
                    new StringBuilder(256),
                    System.Globalization.CultureInfo.InvariantCulture
                );
                using (JsonTextWriter jsonTextWriter = new JsonTextWriter(stringWriter))
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
        /// Returns a specified event. This endpoint returns the same event that would be sent to a [webhook](https://docs.seam.co/developer-tools/webhooks), but it enables you to retrieve an event that already took place.
        /// </summary>
        public Event Get(GetRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            return _seam
                .Get<GetResponse>("/events/get", requestOptions)
                .EnsureData("/events/get")
                .Event;
        }

        /// <summary>
        /// Returns a specified event. This endpoint returns the same event that would be sent to a [webhook](https://docs.seam.co/developer-tools/webhooks), but it enables you to retrieve an event that already took place.
        /// </summary>
        public Event Get(
            string? deviceId = default,
            string? eventId = default,
            string? eventType = default
        )
        {
            return Get(new GetRequest(deviceId: deviceId, eventId: eventId, eventType: eventType));
        }

        /// <summary>
        /// Returns a specified event. This endpoint returns the same event that would be sent to a [webhook](https://docs.seam.co/developer-tools/webhooks), but it enables you to retrieve an event that already took place.
        /// </summary>
        public async Task<Event> GetAsync(GetRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            return (await _seam.GetAsync<GetResponse>("/events/get", requestOptions))
                .EnsureData("/events/get")
                .Event;
        }

        /// <summary>
        /// Returns a specified event. This endpoint returns the same event that would be sent to a [webhook](https://docs.seam.co/developer-tools/webhooks), but it enables you to retrieve an event that already took place.
        /// </summary>
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

        /// <summary>
        /// Request parameters for List Events.
        /// </summary>
        [DataContract(Name = "listRequest_request")]
        public class ListRequest
        {
            [JsonConstructorAttribute]
            protected ListRequest() { }

            public ListRequest(
                string? accessCodeId = default,
                List<string>? accessCodeIds = default,
                string? accessGrantId = default,
                List<string>? accessGrantIds = default,
                string? accessMethodId = default,
                List<string>? accessMethodIds = default,
                string? acsAccessGroupId = default,
                string? acsCredentialId = default,
                string? acsEncoderId = default,
                string? acsEntranceId = default,
                string? acsSystemId = default,
                List<string>? acsSystemIds = default,
                string? acsUserId = default,
                List<string>? between = default,
                string? connectWebviewId = default,
                string? connectedAccountId = default,
                string? customerKey = default,
                string? deviceId = default,
                List<string>? deviceIds = default,
                List<string>? eventIds = default,
                ListRequest.EventTypeEnum? eventType = default,
                List<ListRequest.EventTypesEnum>? eventTypes = default,
                float? limit = default,
                string? since = default,
                string? spaceId = default,
                List<string>? spaceIds = default,
                float? unstableOffset = default,
                string? userIdentityId = default
            )
            {
                AccessCodeId = accessCodeId;
                AccessCodeIds = accessCodeIds;
                AccessGrantId = accessGrantId;
                AccessGrantIds = accessGrantIds;
                AccessMethodId = accessMethodId;
                AccessMethodIds = accessMethodIds;
                AcsAccessGroupId = acsAccessGroupId;
                AcsCredentialId = acsCredentialId;
                AcsEncoderId = acsEncoderId;
                AcsEntranceId = acsEntranceId;
                AcsSystemId = acsSystemId;
                AcsSystemIds = acsSystemIds;
                AcsUserId = acsUserId;
                Between = between;
                ConnectWebviewId = connectWebviewId;
                ConnectedAccountId = connectedAccountId;
                CustomerKey = customerKey;
                DeviceId = deviceId;
                DeviceIds = deviceIds;
                EventIds = eventIds;
                EventType = eventType;
                EventTypes = eventTypes;
                Limit = limit;
                Since = since;
                SpaceId = spaceId;
                SpaceIds = spaceIds;
                UnstableOffset = unstableOffset;
                UserIdentityId = userIdentityId;
            }

            /// <summary>
            /// Type of the events that you want to list.
            /// </summary>
            [JsonConverter(typeof(SafeStringEnumConverter))]
            public enum EventTypeEnum
            {
                [EnumMember(Value = "unrecognized")]
                Unrecognized = 0,

                [EnumMember(Value = "access_code.created")]
                AccessCodeCreated = 1,

                [EnumMember(Value = "access_code.changed")]
                AccessCodeChanged = 2,

                [EnumMember(Value = "access_code.name_changed")]
                AccessCodeNameChanged = 3,

                [EnumMember(Value = "access_code.code_changed")]
                AccessCodeCodeChanged = 4,

                [EnumMember(Value = "access_code.time_frame_changed")]
                AccessCodeTimeFrameChanged = 5,

                [EnumMember(Value = "access_code.mutations_requested")]
                AccessCodeMutationsRequested = 6,

                [EnumMember(Value = "access_code.scheduled_on_device")]
                AccessCodeScheduledOnDevice = 7,

                [EnumMember(Value = "access_code.set_on_device")]
                AccessCodeSetOnDevice = 8,

                [EnumMember(Value = "access_code.removed_from_device")]
                AccessCodeRemovedFromDevice = 9,

                [EnumMember(Value = "access_code.delay_in_setting_on_device")]
                AccessCodeDelayInSettingOnDevice = 10,

                [EnumMember(Value = "access_code.failed_to_set_on_device")]
                AccessCodeFailedToSetOnDevice = 11,

                [EnumMember(Value = "access_code.issued")]
                AccessCodeIssued = 12,

                [EnumMember(Value = "access_code.delay_in_issuing")]
                AccessCodeDelayInIssuing = 13,

                [EnumMember(Value = "access_code.failed_to_issue")]
                AccessCodeFailedToIssue = 14,

                [EnumMember(Value = "access_code.failed_to_update")]
                AccessCodeFailedToUpdate = 15,

                [EnumMember(Value = "access_code.failed_to_expire")]
                AccessCodeFailedToExpire = 16,

                [EnumMember(Value = "access_code.deleted")]
                AccessCodeDeleted = 17,

                [EnumMember(Value = "access_code.delay_in_removing_from_device")]
                AccessCodeDelayInRemovingFromDevice = 18,

                [EnumMember(Value = "access_code.failed_to_remove_from_device")]
                AccessCodeFailedToRemoveFromDevice = 19,

                [EnumMember(Value = "access_code.modified_external_to_seam")]
                AccessCodeModifiedExternalToSeam = 20,

                [EnumMember(Value = "access_code.deleted_external_to_seam")]
                AccessCodeDeletedExternalToSeam = 21,

                [EnumMember(Value = "access_code.backup_access_code_pulled")]
                AccessCodeBackupAccessCodePulled = 22,

                [EnumMember(Value = "access_code.unmanaged.converted_to_managed")]
                AccessCodeUnmanagedConvertedToManaged = 23,

                [EnumMember(Value = "access_code.unmanaged.failed_to_convert_to_managed")]
                AccessCodeUnmanagedFailedToConvertToManaged = 24,

                [EnumMember(Value = "access_code.unmanaged.created")]
                AccessCodeUnmanagedCreated = 25,

                [EnumMember(Value = "access_code.unmanaged.removed")]
                AccessCodeUnmanagedRemoved = 26,

                [EnumMember(Value = "access_grant.created")]
                AccessGrantCreated = 27,

                [EnumMember(Value = "access_grant.deleted")]
                AccessGrantDeleted = 28,

                [EnumMember(Value = "access_grant.access_granted_to_all_doors")]
                AccessGrantAccessGrantedToAllDoors = 29,

                [EnumMember(Value = "access_grant.access_granted_to_door")]
                AccessGrantAccessGrantedToDoor = 30,

                [EnumMember(Value = "access_grant.access_to_door_lost")]
                AccessGrantAccessToDoorLost = 31,

                [EnumMember(Value = "access_grant.access_times_changed")]
                AccessGrantAccessTimesChanged = 32,

                [EnumMember(Value = "access_grant.could_not_create_requested_access_methods")]
                AccessGrantCouldNotCreateRequestedAccessMethods = 33,

                [EnumMember(Value = "access_method.issued")]
                AccessMethodIssued = 34,

                [EnumMember(Value = "access_method.revoked")]
                AccessMethodRevoked = 35,

                [EnumMember(Value = "access_method.card_encoding_required")]
                AccessMethodCardEncodingRequired = 36,

                [EnumMember(Value = "access_method.deleted")]
                AccessMethodDeleted = 37,

                [EnumMember(Value = "access_method.reissued")]
                AccessMethodReissued = 38,

                [EnumMember(Value = "access_method.created")]
                AccessMethodCreated = 39,

                [EnumMember(Value = "access_method.delay_in_issuing")]
                AccessMethodDelayInIssuing = 40,

                [EnumMember(Value = "access_method.failed_to_issue")]
                AccessMethodFailedToIssue = 41,

                [EnumMember(Value = "acs_system.connected")]
                AcsSystemConnected = 42,

                [EnumMember(Value = "acs_system.added")]
                AcsSystemAdded = 43,

                [EnumMember(Value = "acs_system.disconnected")]
                AcsSystemDisconnected = 44,

                [EnumMember(Value = "acs_credential.deleted")]
                AcsCredentialDeleted = 45,

                [EnumMember(Value = "acs_credential.issued")]
                AcsCredentialIssued = 46,

                [EnumMember(Value = "acs_credential.reissued")]
                AcsCredentialReissued = 47,

                [EnumMember(Value = "acs_credential.invalidated")]
                AcsCredentialInvalidated = 48,

                [EnumMember(Value = "acs_user.created")]
                AcsUserCreated = 49,

                [EnumMember(Value = "acs_user.deleted")]
                AcsUserDeleted = 50,

                [EnumMember(Value = "acs_encoder.added")]
                AcsEncoderAdded = 51,

                [EnumMember(Value = "acs_encoder.removed")]
                AcsEncoderRemoved = 52,

                [EnumMember(Value = "acs_access_group.deleted")]
                AcsAccessGroupDeleted = 53,

                [EnumMember(Value = "acs_entrance.added")]
                AcsEntranceAdded = 54,

                [EnumMember(Value = "acs_entrance.removed")]
                AcsEntranceRemoved = 55,

                [EnumMember(Value = "client_session.deleted")]
                ClientSessionDeleted = 56,

                [EnumMember(Value = "connected_account.connected")]
                ConnectedAccountConnected = 57,

                [EnumMember(Value = "connected_account.created")]
                ConnectedAccountCreated = 58,

                [EnumMember(Value = "connected_account.successful_login")]
                ConnectedAccountSuccessfulLogin = 59,

                [EnumMember(Value = "connected_account.disconnected")]
                ConnectedAccountDisconnected = 60,

                [EnumMember(Value = "connected_account.completed_first_sync")]
                ConnectedAccountCompletedFirstSync = 61,

                [EnumMember(Value = "connected_account.deleted")]
                ConnectedAccountDeleted = 62,

                [EnumMember(Value = "connected_account.completed_first_sync_after_reconnection")]
                ConnectedAccountCompletedFirstSyncAfterReconnection = 63,

                [EnumMember(Value = "connected_account.reauthorization_requested")]
                ConnectedAccountReauthorizationRequested = 64,

                [EnumMember(Value = "action_attempt.lock_door.succeeded")]
                ActionAttemptLockDoorSucceeded = 65,

                [EnumMember(Value = "action_attempt.lock_door.failed")]
                ActionAttemptLockDoorFailed = 66,

                [EnumMember(Value = "action_attempt.unlock_door.succeeded")]
                ActionAttemptUnlockDoorSucceeded = 67,

                [EnumMember(Value = "action_attempt.unlock_door.failed")]
                ActionAttemptUnlockDoorFailed = 68,

                [EnumMember(Value = "action_attempt.simulate_keypad_code_entry.succeeded")]
                ActionAttemptSimulateKeypadCodeEntrySucceeded = 69,

                [EnumMember(Value = "action_attempt.simulate_keypad_code_entry.failed")]
                ActionAttemptSimulateKeypadCodeEntryFailed = 70,

                [EnumMember(Value = "action_attempt.simulate_manual_lock_via_keypad.succeeded")]
                ActionAttemptSimulateManualLockViaKeypadSucceeded = 71,

                [EnumMember(Value = "action_attempt.simulate_manual_lock_via_keypad.failed")]
                ActionAttemptSimulateManualLockViaKeypadFailed = 72,

                [EnumMember(Value = "connect_webview.login_succeeded")]
                ConnectWebviewLoginSucceeded = 73,

                [EnumMember(Value = "connect_webview.login_failed")]
                ConnectWebviewLoginFailed = 74,

                [EnumMember(Value = "device.connected")]
                DeviceConnected = 75,

                [EnumMember(Value = "device.added")]
                DeviceAdded = 76,

                [EnumMember(Value = "device.converted_to_unmanaged")]
                DeviceConvertedToUnmanaged = 77,

                [EnumMember(Value = "device.unmanaged.converted_to_managed")]
                DeviceUnmanagedConvertedToManaged = 78,

                [EnumMember(Value = "device.unmanaged.connected")]
                DeviceUnmanagedConnected = 79,

                [EnumMember(Value = "device.disconnected")]
                DeviceDisconnected = 80,

                [EnumMember(Value = "device.unmanaged.disconnected")]
                DeviceUnmanagedDisconnected = 81,

                [EnumMember(Value = "device.tampered")]
                DeviceTampered = 82,

                [EnumMember(Value = "device.low_battery")]
                DeviceLowBattery = 83,

                [EnumMember(Value = "device.battery_status_changed")]
                DeviceBatteryStatusChanged = 84,

                [EnumMember(Value = "device.removed")]
                DeviceRemoved = 85,

                [EnumMember(Value = "device.deleted")]
                DeviceDeleted = 86,

                [EnumMember(Value = "device.third_party_integration_detected")]
                DeviceThirdPartyIntegrationDetected = 87,

                [EnumMember(Value = "device.third_party_integration_no_longer_detected")]
                DeviceThirdPartyIntegrationNoLongerDetected = 88,

                [EnumMember(Value = "device.salto.privacy_mode_activated")]
                DeviceSaltoPrivacyModeActivated = 89,

                [EnumMember(Value = "device.salto.privacy_mode_deactivated")]
                DeviceSaltoPrivacyModeDeactivated = 90,

                [EnumMember(Value = "device.connection_became_flaky")]
                DeviceConnectionBecameFlaky = 91,

                [EnumMember(Value = "device.connection_stabilized")]
                DeviceConnectionStabilized = 92,

                [EnumMember(Value = "device.error.subscription_required")]
                DeviceErrorSubscriptionRequired = 93,

                [EnumMember(Value = "device.error.subscription_required.resolved")]
                DeviceErrorSubscriptionRequiredResolved = 94,

                [EnumMember(Value = "device.accessory_keypad_connected")]
                DeviceAccessoryKeypadConnected = 95,

                [EnumMember(Value = "device.accessory_keypad_disconnected")]
                DeviceAccessoryKeypadDisconnected = 96,

                [EnumMember(Value = "noise_sensor.noise_threshold_triggered")]
                NoiseSensorNoiseThresholdTriggered = 97,

                [EnumMember(Value = "lock.locked")]
                LockLocked = 98,

                [EnumMember(Value = "lock.unlocked")]
                LockUnlocked = 99,

                [EnumMember(Value = "lock.access_denied")]
                LockAccessDenied = 100,

                [EnumMember(Value = "thermostat.climate_preset_activated")]
                ThermostatClimatePresetActivated = 101,

                [EnumMember(Value = "thermostat.manually_adjusted")]
                ThermostatManuallyAdjusted = 102,

                [EnumMember(Value = "thermostat.temperature_threshold_exceeded")]
                ThermostatTemperatureThresholdExceeded = 103,

                [EnumMember(Value = "thermostat.temperature_threshold_no_longer_exceeded")]
                ThermostatTemperatureThresholdNoLongerExceeded = 104,

                [EnumMember(Value = "thermostat.temperature_reached_set_point")]
                ThermostatTemperatureReachedSetPoint = 105,

                [EnumMember(Value = "thermostat.temperature_changed")]
                ThermostatTemperatureChanged = 106,

                [EnumMember(Value = "device.name_changed")]
                DeviceNameChanged = 107,

                [EnumMember(Value = "camera.activated")]
                CameraActivated = 108,

                [EnumMember(Value = "device.doorbell_rang")]
                DeviceDoorbellRang = 109,

                [EnumMember(Value = "enrollment_automation.deleted")]
                EnrollmentAutomationDeleted = 110,

                [EnumMember(Value = "phone.deactivated")]
                PhoneDeactivated = 111,

                [EnumMember(Value = "space.device_membership_changed")]
                SpaceDeviceMembershipChanged = 112,

                [EnumMember(Value = "space.created")]
                SpaceCreated = 113,

                [EnumMember(Value = "space.deleted")]
                SpaceDeleted = 114,
            }

            /// <summary>
            /// Types of the events that you want to list.
            /// </summary>
            [JsonConverter(typeof(SafeStringEnumConverter))]
            public enum EventTypesEnum
            {
                [EnumMember(Value = "unrecognized")]
                Unrecognized = 0,

                [EnumMember(Value = "access_code.created")]
                AccessCodeCreated = 1,

                [EnumMember(Value = "access_code.changed")]
                AccessCodeChanged = 2,

                [EnumMember(Value = "access_code.name_changed")]
                AccessCodeNameChanged = 3,

                [EnumMember(Value = "access_code.code_changed")]
                AccessCodeCodeChanged = 4,

                [EnumMember(Value = "access_code.time_frame_changed")]
                AccessCodeTimeFrameChanged = 5,

                [EnumMember(Value = "access_code.mutations_requested")]
                AccessCodeMutationsRequested = 6,

                [EnumMember(Value = "access_code.scheduled_on_device")]
                AccessCodeScheduledOnDevice = 7,

                [EnumMember(Value = "access_code.set_on_device")]
                AccessCodeSetOnDevice = 8,

                [EnumMember(Value = "access_code.removed_from_device")]
                AccessCodeRemovedFromDevice = 9,

                [EnumMember(Value = "access_code.delay_in_setting_on_device")]
                AccessCodeDelayInSettingOnDevice = 10,

                [EnumMember(Value = "access_code.failed_to_set_on_device")]
                AccessCodeFailedToSetOnDevice = 11,

                [EnumMember(Value = "access_code.issued")]
                AccessCodeIssued = 12,

                [EnumMember(Value = "access_code.delay_in_issuing")]
                AccessCodeDelayInIssuing = 13,

                [EnumMember(Value = "access_code.failed_to_issue")]
                AccessCodeFailedToIssue = 14,

                [EnumMember(Value = "access_code.failed_to_update")]
                AccessCodeFailedToUpdate = 15,

                [EnumMember(Value = "access_code.failed_to_expire")]
                AccessCodeFailedToExpire = 16,

                [EnumMember(Value = "access_code.deleted")]
                AccessCodeDeleted = 17,

                [EnumMember(Value = "access_code.delay_in_removing_from_device")]
                AccessCodeDelayInRemovingFromDevice = 18,

                [EnumMember(Value = "access_code.failed_to_remove_from_device")]
                AccessCodeFailedToRemoveFromDevice = 19,

                [EnumMember(Value = "access_code.modified_external_to_seam")]
                AccessCodeModifiedExternalToSeam = 20,

                [EnumMember(Value = "access_code.deleted_external_to_seam")]
                AccessCodeDeletedExternalToSeam = 21,

                [EnumMember(Value = "access_code.backup_access_code_pulled")]
                AccessCodeBackupAccessCodePulled = 22,

                [EnumMember(Value = "access_code.unmanaged.converted_to_managed")]
                AccessCodeUnmanagedConvertedToManaged = 23,

                [EnumMember(Value = "access_code.unmanaged.failed_to_convert_to_managed")]
                AccessCodeUnmanagedFailedToConvertToManaged = 24,

                [EnumMember(Value = "access_code.unmanaged.created")]
                AccessCodeUnmanagedCreated = 25,

                [EnumMember(Value = "access_code.unmanaged.removed")]
                AccessCodeUnmanagedRemoved = 26,

                [EnumMember(Value = "access_grant.created")]
                AccessGrantCreated = 27,

                [EnumMember(Value = "access_grant.deleted")]
                AccessGrantDeleted = 28,

                [EnumMember(Value = "access_grant.access_granted_to_all_doors")]
                AccessGrantAccessGrantedToAllDoors = 29,

                [EnumMember(Value = "access_grant.access_granted_to_door")]
                AccessGrantAccessGrantedToDoor = 30,

                [EnumMember(Value = "access_grant.access_to_door_lost")]
                AccessGrantAccessToDoorLost = 31,

                [EnumMember(Value = "access_grant.access_times_changed")]
                AccessGrantAccessTimesChanged = 32,

                [EnumMember(Value = "access_grant.could_not_create_requested_access_methods")]
                AccessGrantCouldNotCreateRequestedAccessMethods = 33,

                [EnumMember(Value = "access_method.issued")]
                AccessMethodIssued = 34,

                [EnumMember(Value = "access_method.revoked")]
                AccessMethodRevoked = 35,

                [EnumMember(Value = "access_method.card_encoding_required")]
                AccessMethodCardEncodingRequired = 36,

                [EnumMember(Value = "access_method.deleted")]
                AccessMethodDeleted = 37,

                [EnumMember(Value = "access_method.reissued")]
                AccessMethodReissued = 38,

                [EnumMember(Value = "access_method.created")]
                AccessMethodCreated = 39,

                [EnumMember(Value = "access_method.delay_in_issuing")]
                AccessMethodDelayInIssuing = 40,

                [EnumMember(Value = "access_method.failed_to_issue")]
                AccessMethodFailedToIssue = 41,

                [EnumMember(Value = "acs_system.connected")]
                AcsSystemConnected = 42,

                [EnumMember(Value = "acs_system.added")]
                AcsSystemAdded = 43,

                [EnumMember(Value = "acs_system.disconnected")]
                AcsSystemDisconnected = 44,

                [EnumMember(Value = "acs_credential.deleted")]
                AcsCredentialDeleted = 45,

                [EnumMember(Value = "acs_credential.issued")]
                AcsCredentialIssued = 46,

                [EnumMember(Value = "acs_credential.reissued")]
                AcsCredentialReissued = 47,

                [EnumMember(Value = "acs_credential.invalidated")]
                AcsCredentialInvalidated = 48,

                [EnumMember(Value = "acs_user.created")]
                AcsUserCreated = 49,

                [EnumMember(Value = "acs_user.deleted")]
                AcsUserDeleted = 50,

                [EnumMember(Value = "acs_encoder.added")]
                AcsEncoderAdded = 51,

                [EnumMember(Value = "acs_encoder.removed")]
                AcsEncoderRemoved = 52,

                [EnumMember(Value = "acs_access_group.deleted")]
                AcsAccessGroupDeleted = 53,

                [EnumMember(Value = "acs_entrance.added")]
                AcsEntranceAdded = 54,

                [EnumMember(Value = "acs_entrance.removed")]
                AcsEntranceRemoved = 55,

                [EnumMember(Value = "client_session.deleted")]
                ClientSessionDeleted = 56,

                [EnumMember(Value = "connected_account.connected")]
                ConnectedAccountConnected = 57,

                [EnumMember(Value = "connected_account.created")]
                ConnectedAccountCreated = 58,

                [EnumMember(Value = "connected_account.successful_login")]
                ConnectedAccountSuccessfulLogin = 59,

                [EnumMember(Value = "connected_account.disconnected")]
                ConnectedAccountDisconnected = 60,

                [EnumMember(Value = "connected_account.completed_first_sync")]
                ConnectedAccountCompletedFirstSync = 61,

                [EnumMember(Value = "connected_account.deleted")]
                ConnectedAccountDeleted = 62,

                [EnumMember(Value = "connected_account.completed_first_sync_after_reconnection")]
                ConnectedAccountCompletedFirstSyncAfterReconnection = 63,

                [EnumMember(Value = "connected_account.reauthorization_requested")]
                ConnectedAccountReauthorizationRequested = 64,

                [EnumMember(Value = "action_attempt.lock_door.succeeded")]
                ActionAttemptLockDoorSucceeded = 65,

                [EnumMember(Value = "action_attempt.lock_door.failed")]
                ActionAttemptLockDoorFailed = 66,

                [EnumMember(Value = "action_attempt.unlock_door.succeeded")]
                ActionAttemptUnlockDoorSucceeded = 67,

                [EnumMember(Value = "action_attempt.unlock_door.failed")]
                ActionAttemptUnlockDoorFailed = 68,

                [EnumMember(Value = "action_attempt.simulate_keypad_code_entry.succeeded")]
                ActionAttemptSimulateKeypadCodeEntrySucceeded = 69,

                [EnumMember(Value = "action_attempt.simulate_keypad_code_entry.failed")]
                ActionAttemptSimulateKeypadCodeEntryFailed = 70,

                [EnumMember(Value = "action_attempt.simulate_manual_lock_via_keypad.succeeded")]
                ActionAttemptSimulateManualLockViaKeypadSucceeded = 71,

                [EnumMember(Value = "action_attempt.simulate_manual_lock_via_keypad.failed")]
                ActionAttemptSimulateManualLockViaKeypadFailed = 72,

                [EnumMember(Value = "connect_webview.login_succeeded")]
                ConnectWebviewLoginSucceeded = 73,

                [EnumMember(Value = "connect_webview.login_failed")]
                ConnectWebviewLoginFailed = 74,

                [EnumMember(Value = "device.connected")]
                DeviceConnected = 75,

                [EnumMember(Value = "device.added")]
                DeviceAdded = 76,

                [EnumMember(Value = "device.converted_to_unmanaged")]
                DeviceConvertedToUnmanaged = 77,

                [EnumMember(Value = "device.unmanaged.converted_to_managed")]
                DeviceUnmanagedConvertedToManaged = 78,

                [EnumMember(Value = "device.unmanaged.connected")]
                DeviceUnmanagedConnected = 79,

                [EnumMember(Value = "device.disconnected")]
                DeviceDisconnected = 80,

                [EnumMember(Value = "device.unmanaged.disconnected")]
                DeviceUnmanagedDisconnected = 81,

                [EnumMember(Value = "device.tampered")]
                DeviceTampered = 82,

                [EnumMember(Value = "device.low_battery")]
                DeviceLowBattery = 83,

                [EnumMember(Value = "device.battery_status_changed")]
                DeviceBatteryStatusChanged = 84,

                [EnumMember(Value = "device.removed")]
                DeviceRemoved = 85,

                [EnumMember(Value = "device.deleted")]
                DeviceDeleted = 86,

                [EnumMember(Value = "device.third_party_integration_detected")]
                DeviceThirdPartyIntegrationDetected = 87,

                [EnumMember(Value = "device.third_party_integration_no_longer_detected")]
                DeviceThirdPartyIntegrationNoLongerDetected = 88,

                [EnumMember(Value = "device.salto.privacy_mode_activated")]
                DeviceSaltoPrivacyModeActivated = 89,

                [EnumMember(Value = "device.salto.privacy_mode_deactivated")]
                DeviceSaltoPrivacyModeDeactivated = 90,

                [EnumMember(Value = "device.connection_became_flaky")]
                DeviceConnectionBecameFlaky = 91,

                [EnumMember(Value = "device.connection_stabilized")]
                DeviceConnectionStabilized = 92,

                [EnumMember(Value = "device.error.subscription_required")]
                DeviceErrorSubscriptionRequired = 93,

                [EnumMember(Value = "device.error.subscription_required.resolved")]
                DeviceErrorSubscriptionRequiredResolved = 94,

                [EnumMember(Value = "device.accessory_keypad_connected")]
                DeviceAccessoryKeypadConnected = 95,

                [EnumMember(Value = "device.accessory_keypad_disconnected")]
                DeviceAccessoryKeypadDisconnected = 96,

                [EnumMember(Value = "noise_sensor.noise_threshold_triggered")]
                NoiseSensorNoiseThresholdTriggered = 97,

                [EnumMember(Value = "lock.locked")]
                LockLocked = 98,

                [EnumMember(Value = "lock.unlocked")]
                LockUnlocked = 99,

                [EnumMember(Value = "lock.access_denied")]
                LockAccessDenied = 100,

                [EnumMember(Value = "thermostat.climate_preset_activated")]
                ThermostatClimatePresetActivated = 101,

                [EnumMember(Value = "thermostat.manually_adjusted")]
                ThermostatManuallyAdjusted = 102,

                [EnumMember(Value = "thermostat.temperature_threshold_exceeded")]
                ThermostatTemperatureThresholdExceeded = 103,

                [EnumMember(Value = "thermostat.temperature_threshold_no_longer_exceeded")]
                ThermostatTemperatureThresholdNoLongerExceeded = 104,

                [EnumMember(Value = "thermostat.temperature_reached_set_point")]
                ThermostatTemperatureReachedSetPoint = 105,

                [EnumMember(Value = "thermostat.temperature_changed")]
                ThermostatTemperatureChanged = 106,

                [EnumMember(Value = "device.name_changed")]
                DeviceNameChanged = 107,

                [EnumMember(Value = "camera.activated")]
                CameraActivated = 108,

                [EnumMember(Value = "device.doorbell_rang")]
                DeviceDoorbellRang = 109,

                [EnumMember(Value = "enrollment_automation.deleted")]
                EnrollmentAutomationDeleted = 110,

                [EnumMember(Value = "phone.deactivated")]
                PhoneDeactivated = 111,

                [EnumMember(Value = "space.device_membership_changed")]
                SpaceDeviceMembershipChanged = 112,

                [EnumMember(Value = "space.created")]
                SpaceCreated = 113,

                [EnumMember(Value = "space.deleted")]
                SpaceDeleted = 114,
            }

            /// <summary>
            /// ID of the access code for which you want to list events.
            /// </summary>
            [DataMember(Name = "access_code_id", IsRequired = false, EmitDefaultValue = false)]
            public string? AccessCodeId { get; set; }

            /// <summary>
            /// IDs of the access codes for which you want to list events.
            /// </summary>
            [DataMember(Name = "access_code_ids", IsRequired = false, EmitDefaultValue = false)]
            public List<string>? AccessCodeIds { get; set; }

            /// <summary>
            /// ID of the access grant for which you want to list events.
            /// </summary>
            [DataMember(Name = "access_grant_id", IsRequired = false, EmitDefaultValue = false)]
            public string? AccessGrantId { get; set; }

            /// <summary>
            /// IDs of the access grants for which you want to list events.
            /// </summary>
            [DataMember(Name = "access_grant_ids", IsRequired = false, EmitDefaultValue = false)]
            public List<string>? AccessGrantIds { get; set; }

            /// <summary>
            /// ID of the access method for which you want to list events.
            /// </summary>
            [DataMember(Name = "access_method_id", IsRequired = false, EmitDefaultValue = false)]
            public string? AccessMethodId { get; set; }

            /// <summary>
            /// IDs of the access methods for which you want to list events.
            /// </summary>
            [DataMember(Name = "access_method_ids", IsRequired = false, EmitDefaultValue = false)]
            public List<string>? AccessMethodIds { get; set; }

            /// <summary>
            /// ID of the ACS access group for which you want to list events.
            /// </summary>
            [DataMember(Name = "acs_access_group_id", IsRequired = false, EmitDefaultValue = false)]
            public string? AcsAccessGroupId { get; set; }

            /// <summary>
            /// ID of the ACS credential for which you want to list events.
            /// </summary>
            [DataMember(Name = "acs_credential_id", IsRequired = false, EmitDefaultValue = false)]
            public string? AcsCredentialId { get; set; }

            /// <summary>
            /// ID of the ACS encoder for which you want to list events.
            /// </summary>
            [DataMember(Name = "acs_encoder_id", IsRequired = false, EmitDefaultValue = false)]
            public string? AcsEncoderId { get; set; }

            /// <summary>
            /// ID of the ACS entrance for which you want to list events.
            /// </summary>
            [DataMember(Name = "acs_entrance_id", IsRequired = false, EmitDefaultValue = false)]
            public string? AcsEntranceId { get; set; }

            /// <summary>
            /// ID of the access system for which you want to list events.
            /// </summary>
            [DataMember(Name = "acs_system_id", IsRequired = false, EmitDefaultValue = false)]
            public string? AcsSystemId { get; set; }

            /// <summary>
            /// IDs of the access systems for which you want to list events.
            /// </summary>
            [DataMember(Name = "acs_system_ids", IsRequired = false, EmitDefaultValue = false)]
            public List<string>? AcsSystemIds { get; set; }

            /// <summary>
            /// ID of the ACS user for which you want to list events.
            /// </summary>
            [DataMember(Name = "acs_user_id", IsRequired = false, EmitDefaultValue = false)]
            public string? AcsUserId { get; set; }

            /// <summary>
            /// Lower and upper timestamps to define an exclusive interval containing the events that you want to list. You must include `since` or `between`.
            /// </summary>
            [DataMember(Name = "between", IsRequired = false, EmitDefaultValue = false)]
            public List<string>? Between { get; set; }

            /// <summary>
            /// ID of the Connect Webview for which you want to list events.
            /// </summary>
            [DataMember(Name = "connect_webview_id", IsRequired = false, EmitDefaultValue = false)]
            public string? ConnectWebviewId { get; set; }

            /// <summary>
            /// ID of the connected account for which you want to list events.
            /// </summary>
            [DataMember(
                Name = "connected_account_id",
                IsRequired = false,
                EmitDefaultValue = false
            )]
            public string? ConnectedAccountId { get; set; }

            /// <summary>
            /// Customer key for which you want to list events.
            /// </summary>
            [DataMember(Name = "customer_key", IsRequired = false, EmitDefaultValue = false)]
            public string? CustomerKey { get; set; }

            /// <summary>
            /// ID of the device for which you want to list events.
            /// </summary>
            [DataMember(Name = "device_id", IsRequired = false, EmitDefaultValue = false)]
            public string? DeviceId { get; set; }

            /// <summary>
            /// IDs of the devices for which you want to list events.
            /// </summary>
            [DataMember(Name = "device_ids", IsRequired = false, EmitDefaultValue = false)]
            public List<string>? DeviceIds { get; set; }

            /// <summary>
            /// IDs of the events that you want to list.
            /// </summary>
            [DataMember(Name = "event_ids", IsRequired = false, EmitDefaultValue = false)]
            public List<string>? EventIds { get; set; }

            /// <summary>
            /// Type of the events that you want to list.
            /// </summary>
            [DataMember(Name = "event_type", IsRequired = false, EmitDefaultValue = false)]
            public ListRequest.EventTypeEnum? EventType { get; set; }

            /// <summary>
            /// Types of the events that you want to list.
            /// </summary>
            [DataMember(Name = "event_types", IsRequired = false, EmitDefaultValue = false)]
            public List<ListRequest.EventTypesEnum>? EventTypes { get; set; }

            /// <summary>
            /// Numerical limit on the number of events to return.
            /// </summary>
            [DataMember(Name = "limit", IsRequired = false, EmitDefaultValue = false)]
            public float? Limit { get; set; }

            /// <summary>
            /// Timestamp to indicate the beginning generation time for the events that you want to list. You must include `since` or `between`.
            /// </summary>
            [DataMember(Name = "since", IsRequired = false, EmitDefaultValue = false)]
            public string? Since { get; set; }

            /// <summary>
            /// ID of the space for which you want to list events.
            /// </summary>
            [DataMember(Name = "space_id", IsRequired = false, EmitDefaultValue = false)]
            public string? SpaceId { get; set; }

            /// <summary>
            /// IDs of the spaces for which you want to list events.
            /// </summary>
            [DataMember(Name = "space_ids", IsRequired = false, EmitDefaultValue = false)]
            public List<string>? SpaceIds { get; set; }

            /// <summary>
            /// Offset for the events that you want to list.
            /// </summary>
            [DataMember(Name = "unstable_offset", IsRequired = false, EmitDefaultValue = false)]
            public float? UnstableOffset { get; set; }

            /// <summary>
            /// ID of the user identity for which you want to list events.
            /// </summary>
            [DataMember(Name = "user_identity_id", IsRequired = false, EmitDefaultValue = false)]
            public string? UserIdentityId { get; set; }

            public override string ToString()
            {
                JsonSerializer jsonSerializer = JsonSerializer.CreateDefault(null);

                StringWriter stringWriter = new StringWriter(
                    new StringBuilder(256),
                    System.Globalization.CultureInfo.InvariantCulture
                );
                using (JsonTextWriter jsonTextWriter = new JsonTextWriter(stringWriter))
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

            /// <summary>
            /// OK
            /// </summary>
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

        /// <summary>
        /// Returns a list of all events. This endpoint returns the same events that would be sent to a [webhook](https://docs.seam.co/developer-tools/webhooks), but it enables you to filter or see events that already took place.
        /// </summary>
        public List<Event> List(ListRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            return _seam
                .Get<ListResponse>("/events/list", requestOptions)
                .EnsureData("/events/list")
                .Events;
        }

        /// <summary>
        /// Returns a list of all events. This endpoint returns the same events that would be sent to a [webhook](https://docs.seam.co/developer-tools/webhooks), but it enables you to filter or see events that already took place.
        /// </summary>
        public List<Event> List(
            string? accessCodeId = default,
            List<string>? accessCodeIds = default,
            string? accessGrantId = default,
            List<string>? accessGrantIds = default,
            string? accessMethodId = default,
            List<string>? accessMethodIds = default,
            string? acsAccessGroupId = default,
            string? acsCredentialId = default,
            string? acsEncoderId = default,
            string? acsEntranceId = default,
            string? acsSystemId = default,
            List<string>? acsSystemIds = default,
            string? acsUserId = default,
            List<string>? between = default,
            string? connectWebviewId = default,
            string? connectedAccountId = default,
            string? customerKey = default,
            string? deviceId = default,
            List<string>? deviceIds = default,
            List<string>? eventIds = default,
            ListRequest.EventTypeEnum? eventType = default,
            List<ListRequest.EventTypesEnum>? eventTypes = default,
            float? limit = default,
            string? since = default,
            string? spaceId = default,
            List<string>? spaceIds = default,
            float? unstableOffset = default,
            string? userIdentityId = default
        )
        {
            return List(
                new ListRequest(
                    accessCodeId: accessCodeId,
                    accessCodeIds: accessCodeIds,
                    accessGrantId: accessGrantId,
                    accessGrantIds: accessGrantIds,
                    accessMethodId: accessMethodId,
                    accessMethodIds: accessMethodIds,
                    acsAccessGroupId: acsAccessGroupId,
                    acsCredentialId: acsCredentialId,
                    acsEncoderId: acsEncoderId,
                    acsEntranceId: acsEntranceId,
                    acsSystemId: acsSystemId,
                    acsSystemIds: acsSystemIds,
                    acsUserId: acsUserId,
                    between: between,
                    connectWebviewId: connectWebviewId,
                    connectedAccountId: connectedAccountId,
                    customerKey: customerKey,
                    deviceId: deviceId,
                    deviceIds: deviceIds,
                    eventIds: eventIds,
                    eventType: eventType,
                    eventTypes: eventTypes,
                    limit: limit,
                    since: since,
                    spaceId: spaceId,
                    spaceIds: spaceIds,
                    unstableOffset: unstableOffset,
                    userIdentityId: userIdentityId
                )
            );
        }

        /// <summary>
        /// Returns a list of all events. This endpoint returns the same events that would be sent to a [webhook](https://docs.seam.co/developer-tools/webhooks), but it enables you to filter or see events that already took place.
        /// </summary>
        public async Task<List<Event>> ListAsync(ListRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            return (await _seam.GetAsync<ListResponse>("/events/list", requestOptions))
                .EnsureData("/events/list")
                .Events;
        }

        /// <summary>
        /// Returns a list of all events. This endpoint returns the same events that would be sent to a [webhook](https://docs.seam.co/developer-tools/webhooks), but it enables you to filter or see events that already took place.
        /// </summary>
        public async Task<List<Event>> ListAsync(
            string? accessCodeId = default,
            List<string>? accessCodeIds = default,
            string? accessGrantId = default,
            List<string>? accessGrantIds = default,
            string? accessMethodId = default,
            List<string>? accessMethodIds = default,
            string? acsAccessGroupId = default,
            string? acsCredentialId = default,
            string? acsEncoderId = default,
            string? acsEntranceId = default,
            string? acsSystemId = default,
            List<string>? acsSystemIds = default,
            string? acsUserId = default,
            List<string>? between = default,
            string? connectWebviewId = default,
            string? connectedAccountId = default,
            string? customerKey = default,
            string? deviceId = default,
            List<string>? deviceIds = default,
            List<string>? eventIds = default,
            ListRequest.EventTypeEnum? eventType = default,
            List<ListRequest.EventTypesEnum>? eventTypes = default,
            float? limit = default,
            string? since = default,
            string? spaceId = default,
            List<string>? spaceIds = default,
            float? unstableOffset = default,
            string? userIdentityId = default
        )
        {
            return (
                await ListAsync(
                    new ListRequest(
                        accessCodeId: accessCodeId,
                        accessCodeIds: accessCodeIds,
                        accessGrantId: accessGrantId,
                        accessGrantIds: accessGrantIds,
                        accessMethodId: accessMethodId,
                        accessMethodIds: accessMethodIds,
                        acsAccessGroupId: acsAccessGroupId,
                        acsCredentialId: acsCredentialId,
                        acsEncoderId: acsEncoderId,
                        acsEntranceId: acsEntranceId,
                        acsSystemId: acsSystemId,
                        acsSystemIds: acsSystemIds,
                        acsUserId: acsUserId,
                        between: between,
                        connectWebviewId: connectWebviewId,
                        connectedAccountId: connectedAccountId,
                        customerKey: customerKey,
                        deviceId: deviceId,
                        deviceIds: deviceIds,
                        eventIds: eventIds,
                        eventType: eventType,
                        eventTypes: eventTypes,
                        limit: limit,
                        since: since,
                        spaceId: spaceId,
                        spaceIds: spaceIds,
                        unstableOffset: unstableOffset,
                        userIdentityId: userIdentityId
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
