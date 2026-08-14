namespace Seam.Test;

using Newtonsoft.Json;
using Seam.Client;

public class NullTests
{
    [Fact]
    public void SerializesToJsonNull()
    {
        Assert.Equal("null", JsonConvert.SerializeObject(Null.Value));
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
            JsonConvert.SerializeObject(body)
        );
    }

    [Fact]
    public void SerializesToJsonNullUnderTheClientSerializerSettings()
    {
        var request = new Api.Devices.UpdateRequest(
            deviceId: "device1",
            customMetadata: new Dictionary<string, object?> { ["sync"] = Null.Value }
        );

        var json = JsonConvert.SerializeObject(
            request,
            new SeamClient(apiToken: "seam_apikey").SerializerSettings
        );

        Assert.Equal("{\"custom_metadata\":{\"sync\":null},\"device_id\":\"device1\"}", json);
    }

    [Fact]
    public void IsASingleton()
    {
        Assert.Same(Null.Value, Null.Value);
        Assert.Equal("null", Null.Value.ToString());
    }
}
