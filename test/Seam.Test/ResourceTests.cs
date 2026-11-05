namespace Seam.Test;

using Seam.Test.Support;

public class ResourceTests : FakeSeamConnectTest
{
    [Fact]
    public async Task DevicesDeserializeIntoTypedModels()
    {
        using var seam = CreateSeam();

        var device = await seam.Devices.GetAsync(new() { DeviceId = Seed("august_device_1") });

        Assert.Equal(Seed("august_device_1"), device.DeviceId);
        Assert.Equal(Seed("seed_workspace_1"), device.WorkspaceId);
        Assert.NotNull(device.Properties);
        Assert.False(string.IsNullOrEmpty(device.DisplayName));
    }

    [Fact]
    public async Task ListEndpointsReturnTypedLists()
    {
        using var seam = CreateSeam();

        var devices = await seam.Devices.ListAsync();

        Assert.All(devices, device => Assert.False(string.IsNullOrEmpty(device.DeviceId)));
    }

    [Fact]
    public async Task NestedRouteNamespacesAreReachable()
    {
        using var seam = CreateSeam();

        var systems = await seam.Acs.Systems.ListAsync();

        Assert.All(systems, system => Assert.False(string.IsNullOrEmpty(system.AcsSystemId)));
    }
}
