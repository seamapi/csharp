namespace Seam.Test;

using Seam.Test.Support;

public class ApiKeyTests : FakeSeamConnectTest
{
    [Fact]
    public async Task FromApiKeyReturnsAnAuthorizedClient()
    {
        using var seam = SeamClient.FromApiKey(
            Seed("seam_apikey1_token"),
            new SeamClientOptions { Endpoint = Endpoint }
        );

        var devices = await seam.Devices.ListAsync();

        Assert.NotEmpty(devices);
    }

    [Fact]
    public async Task ConstructorReturnsAnAuthorizedClient()
    {
        using var seam = new SeamClient(
            new SeamClientOptions { ApiKey = Seed("seam_apikey1_token"), Endpoint = Endpoint }
        );

        var devices = await seam.Devices.ListAsync();

        Assert.NotEmpty(devices);
    }

    [Fact]
    public async Task InvalidApiKeyIsRejectedByTheServer()
    {
        using var seam = new SeamClient(
            new SeamClientOptions { ApiKey = "seam_invalid_api_key", Endpoint = Endpoint }
        );

        await Assert.ThrowsAsync<SeamHttpUnauthorizedException>(() => seam.Devices.ListAsync());
    }
}

public class ApiKeyFormatTests
{
    [Theory]
    [InlineData("seam_at1_token", "An Access Token cannot be used as an ApiKey")]
    [InlineData("seam_cst1_token", "A Client Session Token cannot be used as an ApiKey")]
    [InlineData("seam_pk1_token", "A Publishable Key cannot be used as an ApiKey")]
    [InlineData("ey_json_web_token", "A JWT cannot be used as an ApiKey")]
    [InlineData("not-a-token", "Unknown or invalid ApiKey format")]
    public void ApiKeyFormatIsChecked(string apiKey, string message)
    {
        var exception = Assert.Throws<SeamInvalidTokenException>(() => new SeamClient(apiKey));

        Assert.Contains(message, exception.Message);
        Assert.StartsWith("Seam received an invalid token:", exception.Message);
    }
}
