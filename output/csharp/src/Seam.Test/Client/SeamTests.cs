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
    public void TestDelete()
    {
        var device = seam
            .Devices.List()
            .First(d => d.DeviceType == Device.DeviceTypeEnum.AugustLock);

        Assert.NotNull(device);

        seam.Devices.Delete(deviceId: device.DeviceId);

        var device2 = seam
            .Devices.List()
            .First(d => d.DeviceType == Device.DeviceTypeEnum.AugustLock);

        Assert.NotEqual(device.DeviceId, device2.DeviceId);
    }

    [Fact]
    public async void TestDeleteAsync()
    {
        var device = (await seam.Devices.ListAsync()).First(d =>
            d.DeviceType == Device.DeviceTypeEnum.AugustLock
        );

        Assert.NotNull(device);

        await seam.Devices.DeleteAsync(deviceId: device.DeviceId);

        var device2 = (await seam.Devices.ListAsync()).First(d =>
            d.DeviceType == Device.DeviceTypeEnum.AugustLock
        );

        Assert.NotEqual(device.DeviceId, device2.DeviceId);
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
            custom_metadata: {}
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
}
