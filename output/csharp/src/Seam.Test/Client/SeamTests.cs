namespace Seam.Test;

using Newtonsoft.Json;
using Seam.Client;
using Seam.Model;

public class UnitTest1 : SeamConnectTest
{
    [Fact]
    public void TestGetDeviceList()
    {
        var device = seam
            .Devices.List()
            .First(d => d.DeviceType == Device.DeviceTypeEnum.AugustLock);

        Assert.NotNull(device);
        Assert.Equal("Fake August Lock 1", device.Properties.Name);
    }

    [Fact]
    public async void TestGetDeviceListAsync()
    {
        var device = (await seam.Devices.ListAsync()).First(d =>
            d.DeviceType == Device.DeviceTypeEnum.AugustLock
        );

        Assert.NotNull(device);
        Assert.Equal("Fake August Lock 1", device.Properties.Name);
    }

    [Fact]
    public void TestCreateAccessCode()
    {
        var device = seam
            .Devices.List()
            .First(d => d.DeviceType == Device.DeviceTypeEnum.AugustLock);

        var access_code = seam.AccessCodes.Create(deviceId: device.DeviceId, code: "1234");

        Assert.Equal(AccessCode.StatusEnum.Setting, access_code.Status);
        Assert.Equal("1234", access_code.Code);
    }

    [Fact]
    public async void TestCreateAccessCodeAsync()
    {
        var device = seam
            .Devices.List()
            .First(d => d.DeviceType == Device.DeviceTypeEnum.AugustLock);

        var access_code = await seam.AccessCodes.CreateAsync(
            deviceId: device.DeviceId,
            code: "1234"
        );

        Assert.Equal(AccessCode.StatusEnum.Setting, access_code.Status);
        Assert.Equal("1234", access_code.Code);
    }

    [Fact]
    public void TestLockDoor()
    {
        var device = seam
            .Devices.List()
            .First(d => d.DeviceType == Device.DeviceTypeEnum.AugustLock);

        var action_attempt = seam.Locks.LockDoor(deviceId: device.DeviceId);

        Assert.IsType<ActionAttemptLockDoor>(action_attempt);
        Assert.Equal("LOCK_DOOR", (action_attempt as ActionAttemptLockDoor)!.ActionType);
    }

    [Fact]
    public async void TestLockDoorAsync()
    {
        var device = seam
            .Devices.List()
            .First(d => d.DeviceType == Device.DeviceTypeEnum.AugustLock);

        var action_attempt = await seam.Locks.LockDoorAsync(deviceId: device.DeviceId);

        Assert.IsType<ActionAttemptLockDoor>(action_attempt);
        Assert.Equal("LOCK_DOOR", (action_attempt as ActionAttemptLockDoor)!.ActionType);
    }

    [Fact]
    public void Test()
    {
        Assert.Throws<SeamException>(() => seam.AccessCodes.Get(accessCodeId: "nonexistent"));
    }

    [Fact]
    public void TestUnknownEnumValue()
    {
        var json =
            @"{
            ""device_type"": ""unknown_device_type"",
            ""device_id"": ""test"",
            ""capabilities_supported"": [""unknown_capability"", ""access_code""],
            ""properties"": {
                ""available_fan_mode_settings"": [""unknown_mode"", ""auto""]
            },
            connected_account_id: ""test"",
            created_at: ""test"",
            device_id: ""test"",
            device_type: ""unknown_device_type"",
            display_name: ""test"",
            errors: [],
            is_managed: false,
            warnings: [],
            workspace_id: ""test"",
            properties: {
                ""available_fan_mode_settings"": [""unknown_mode"", ""auto""]
            },
            custom_metadata: {},
            space_ids: []
        }";

        var settings = new JsonSerializerSettings
        {
            Converters = new List<JsonConverter> { new SafeStringEnumConverter() },
        };
        var device = JsonConvert.DeserializeObject<Device>(json, settings);

        // Unknown values should be mapped to first enum value (Unrecognized = 0)
        Assert.NotNull(device);
        Assert.Equal(Device.DeviceTypeEnum.Unrecognized, device.DeviceType);
        Assert.Equal(
            Device.CapabilitiesSupportedEnum.Unrecognized,
            device.CapabilitiesSupported[0]
        );
        Assert.NotNull(device.Properties.AvailableFanModeSettings);
        Assert.Equal(
            DeviceProperties.AvailableFanModeSettingsEnum.Unrecognized,
            device.Properties.AvailableFanModeSettings[0]
        );

        // Known values should still work
        Assert.Equal(Device.CapabilitiesSupportedEnum.AccessCode, device.CapabilitiesSupported[1]);
        Assert.Equal(
            DeviceProperties.AvailableFanModeSettingsEnum.Auto,
            device.Properties.AvailableFanModeSettings[1]
        );
    }

    [Fact]
    public void TestDiscriminatedUnionArrayWithUnknownTypes()
    {
        var json =
            @"{
            ""connected_account_id"": ""test-account-id"",
            ""account_type"": ""august"",
            ""account_type_display_name"": ""August Lock"",
            ""automatically_manage_new_devices"": true,
            ""created_at"": ""2024-01-15T10:00:00Z"",
            ""accepted_capabilities"": [],
            ""custom_metadata"": {},
            ""errors"": [
                {
                    ""error_code"": ""unknown_error_type"",
                    ""message"": ""An unknown error occurred"",
                    ""created_at"": ""2024-01-15T10:00:00Z""
                }
            ],
            ""warnings"": [
                {
                    ""warning_code"": ""unknown_warning_type"",
                    ""message"": ""An unknown warning occurred"",
                    ""created_at"": ""2024-01-15T10:00:00Z""
                }
            ]
        }";

        var settings = new JsonSerializerSettings
        {
            Converters = new List<JsonConverter> { new SafeStringEnumConverter() },
            MissingMemberHandling = MissingMemberHandling.Ignore,
        };

        // Unknown discriminated union types should fall back to unrecognized type
        var account = JsonConvert.DeserializeObject<ConnectedAccount>(json, settings);

        Assert.NotNull(account);
        Assert.NotNull(account.Errors);
        Assert.Single(account.Errors);

        // The unknown error type should fall back to an unrecognized error type
        var error = account.Errors[0];
        Assert.Equal("unrecognized", error.ErrorCode);
        Assert.Equal("An unknown error occurred", error.Message);
    }

    [Fact]
    public void TestEventArrayWithUnknownTypes()
    {
        var json =
            @"[
            {
                ""event_id"": ""event-1"",
                ""event_type"": ""device.connected"",
                ""created_at"": ""2024-01-15T10:00:00Z"",
                ""occurred_at"": ""2024-01-15T10:00:00Z"",
                ""device_id"": ""device-123"",
                ""connected_account_id"": ""account-123"",
                ""workspace_id"": ""workspace-123""
            },
            {
                ""event_id"": ""event-2"",
                ""event_type"": ""unknown_event_type"",
                ""created_at"": ""2024-01-15T10:00:00Z"",
                ""custom_field"": ""custom_value""
            }
        ]";

        var settings = new JsonSerializerSettings
        {
            Converters = new List<JsonConverter> { new SafeStringEnumConverter() },
            MissingMemberHandling = MissingMemberHandling.Ignore,
        };

        // Unknown event types should fall back to unrecognized type
        var events = JsonConvert.DeserializeObject<List<Event>>(json, settings);

        Assert.NotNull(events);
        Assert.Equal(2, events.Count);

        // First event should deserialize normally
        Assert.IsType<EventDeviceConnected>(events[0]);

        // Second event with unknown type should fall back to unrecognized
        var unknownEvent = events[1];
        Assert.IsType<EventUnrecognized>(unknownEvent);
        Assert.Equal("unrecognized", unknownEvent.EventType);
    }

    [Fact]
    public void TestActionAttemptWithUnknownType()
    {
        // Test case for ActionAttempt with unknown action types
        var json =
            @"{
            ""action_attempt_id"": ""attempt-123"",
            ""action_type"": ""UNKNOWN_ACTION"",
            ""status"": ""success"",
            ""result"": {},
            ""error"": null
        }";

        var settings = new JsonSerializerSettings
        {
            Converters = new List<JsonConverter> { new SafeStringEnumConverter() },
            MissingMemberHandling = MissingMemberHandling.Ignore,
        };

        // Unknown action types should fall back to unrecognized type
        var actionAttempt = JsonConvert.DeserializeObject<ActionAttempt>(json, settings);

        Assert.NotNull(actionAttempt);
        Assert.Equal("unrecognized", actionAttempt.ActionType);
    }

    [Fact]
    public void TestAllDiscriminatedUnionsHasFallbackAutomatically()
    {
        // Automatically discover and test all discriminated unions in the SDK
        var assembly = typeof(ActionAttempt).Assembly;
        var discriminatedUnionTypes = assembly
            .GetTypes()
            .Where(t =>
                t.IsAbstract
                && t.GetCustomAttributes(false)
                    .Any(attr => attr.GetType().Name == "JsonConverterAttribute")
            )
            .ToList();

        Assert.NotEmpty(discriminatedUnionTypes); // Ensure we found at least one
        foreach (var baseType in discriminatedUnionTypes)
        {
            // Find the JsonConverter attribute to get the discriminator property name
            var jsonConverterAttr = baseType
                .GetCustomAttributes(false)
                .FirstOrDefault(attr => attr.GetType().Name == "JsonConverterAttribute");

            Assert.NotNull(jsonConverterAttr);

            // Get discriminator property name from the attribute constructor args
            var discriminatorProperty =
                jsonConverterAttr
                    .GetType()
                    .GetProperty("ConverterParameters")
                    ?.GetValue(jsonConverterAttr) as object[];

            string discriminatorName =
                discriminatorProperty?.FirstOrDefault()?.ToString() ?? "status";
            // Find the Unrecognized fallback type
            var unrecognizedType = assembly
                .GetTypes()
                .FirstOrDefault(t =>
                    t.Name == baseType.Name + "Unrecognized" && baseType.IsAssignableFrom(t)
                );

            Assert.NotNull(unrecognizedType);

            // Create test JSON with unrecognized discriminator value
            var testJson =
                $@"{{
                ""{discriminatorName}"": ""test_unrecognized_value"",
                ""test_property"": ""test_value"",
                ""unknown_field"": 123,
                ""message"": ""test_message""
            }}";
            // Deserialize and verify fallback behavior
            var deserializeMethod = typeof(JsonConvert)
                .GetMethods()
                .First(m =>
                    m.Name == "DeserializeObject"
                    && m.IsGenericMethod
                    && m.GetParameters().Length == 1
                )
                .MakeGenericMethod(baseType);
            var result = deserializeMethod.Invoke(null, new object[] { testJson });
            Assert.NotNull(result);
            Assert.IsType(unrecognizedType, result);
            // Verify discriminator property is preserved
            var discriminatorProp = baseType.GetProperty(
                discriminatorName.Replace("_", ""),
                System.Reflection.BindingFlags.Public
                    | System.Reflection.BindingFlags.Instance
                    | System.Reflection.BindingFlags.IgnoreCase
            );

            Assert.NotNull(discriminatorProp);

            var discriminatorValue = discriminatorProp.GetValue(result)?.ToString();
            Assert.Equal("unrecognized", discriminatorValue);
        }
    }
}
