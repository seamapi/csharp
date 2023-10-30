namespace Seam.Test;

using Seam.Model;
using Seam.Client;

public class UnitTest1 : SeamConnectTest
{
    [Fact]
    public void TestGetDeviceList()
    {
        var device = seam.Devices
            .List()
            .First(d => d.DeviceType == Device.DeviceTypeEnum.AugustLock);

        Assert.NotNull(device);
        Assert.Equal("Fake August Lock 1", device.Properties.Name);
    }

    [Fact]
    public async void TestGetDeviceListAsync()
    {
        var device = (await seam.Devices.ListAsync()).First(
            d => d.DeviceType == Device.DeviceTypeEnum.AugustLock
        );

        Assert.NotNull(device);
        Assert.Equal("Fake August Lock 1", device.Properties.Name);
    }

    [Fact]
    public void TestCreateAccessCode()
    {
        var device = seam.Devices
            .List()
            .First(d => d.DeviceType == Device.DeviceTypeEnum.AugustLock);

        var access_code = seam.AccessCodes.Create(deviceId: device.DeviceId, code: "1234");

        Assert.Equal(AccessCode.StatusEnum.Setting, access_code.Status);
        Assert.Equal("1234", access_code.Code);
    }

    [Fact]
    public async void TestCreateAccessCodeAsync()
    {
        var device = seam.Devices
            .List()
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
        var device = seam.Devices
            .List()
            .First(d => d.DeviceType == Device.DeviceTypeEnum.AugustLock);

        var action_attempt = seam.Locks.LockDoor(deviceId: device.DeviceId);

        Assert.IsType<ActionAttemptPending>(action_attempt);
        Assert.Equal("LOCK_DOOR", (action_attempt as ActionAttemptPending)!.ActionType);
    }

    [Fact]
    public async void TestLockDoorAsync()
    {
        var device = seam.Devices
            .List()
            .First(d => d.DeviceType == Device.DeviceTypeEnum.AugustLock);

        var action_attempt = await seam.Locks.LockDoorAsync(deviceId: device.DeviceId);

        Assert.IsType<ActionAttemptPending>(action_attempt);
        Assert.Equal("LOCK_DOOR", (action_attempt as ActionAttemptPending)!.ActionType);
    }

    [Fact]
    public void Test()
    {
        Assert.Throws<SeamException>(() => seam.AccessCodes.Get(accessCodeId: "nonexistent"));
    }
}
