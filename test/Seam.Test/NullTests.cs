namespace Seam.Test;

using System.Text.Json;

public class NullTests
{
    [Fact]
    public void SerializesToJsonNull()
    {
        Assert.Equal("null", JsonSerializer.Serialize(Null.Value, SeamJson.Options));
    }

    [Fact]
    public void SerializesToJsonNullInsideARequestBody()
    {
        var body = new Dictionary<string, object?>
        {
            ["name"] = Null.Value,
            ["limit"] = 20,
            ["nested"] = new Dictionary<string, object?> { ["key"] = Null.Value },
            ["list"] = new object?[] { Null.Value },
        };

        Assert.Equal(
            "{\"name\":null,\"limit\":20,\"nested\":{\"key\":null},\"list\":[null]}",
            JsonSerializer.Serialize(body, SeamJson.Options)
        );
    }

    [Fact]
    public void SerializesToJsonNullInsideAGeneratedRequest()
    {
        var request = new Routes.Devices.UpdateRequest
        {
            DeviceId = "device1",
            CustomMetadata = new Dictionary<string, object?> { ["sync"] = Null.Value },
        };

        var json = JsonSerializer.Serialize(request, SeamJson.Options);

        Assert.Contains("\"custom_metadata\":{\"sync\":null}", json);
        Assert.Contains("\"device_id\":\"device1\"", json);
    }

    [Fact]
    public void IsASingleton()
    {
        Assert.Same(Null.Value, Null.Value);
        Assert.Equal("null", Null.Value.ToString());
    }
}
