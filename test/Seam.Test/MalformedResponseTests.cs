namespace Seam.Test;

using System.Net;
using Seam.Test.Support;

// A response that is not a Seam error envelope must surface as the transport's own error, never
// as a fabricated Seam exception.
public class MalformedResponseTests
{
    private static SeamClient CreateSeam(RecordingHandler handler)
    {
        return new SeamClient(
            new SeamClientOptions
            {
                ApiKey = "seam_apikey1_token",
                Endpoint = "https://example.com",
                HttpMessageHandler = handler,
                MaxRetries = 0,
            }
        );
    }

    [Theory]
    [InlineData("<html>Bad Gateway</html>", "text/html")]
    [InlineData("not json at all", "application/json")]
    [InlineData("{\"message\":\"no error envelope\"}", "application/json")]
    [InlineData("{\"error\":\"a string, not an object\"}", "application/json")]
    [InlineData("{\"error\":{\"type\":42}}", "application/json")]
    public async Task NonSeamErrorResponsesSurfaceTheTransportError(string body, string contentType)
    {
        var handler = new RecordingHandler().RespondWith(
            HttpStatusCode.BadGateway,
            body,
            contentType
        );
        using var seam = CreateSeam(handler);

        var exception = await Assert.ThrowsAsync<HttpRequestException>(
            () => seam.Devices.ListAsync()
        );

        Assert.Equal(HttpStatusCode.BadGateway, exception.StatusCode);
    }

    [Fact]
    public async Task MalformedSuccessBodyRaisesAJsonException()
    {
        var handler = new RecordingHandler().RespondWith(HttpStatusCode.OK, "not json at all");
        using var seam = CreateSeam(handler);

        await Assert.ThrowsAsync<System.Text.Json.JsonException>(() => seam.Devices.ListAsync());
    }

    [Fact]
    public async Task RedirectIsNotTreatedAsSuccess()
    {
        var handler = new RecordingHandler().RespondWith(
            HttpStatusCode.Found,
            "",
            headers: new Dictionary<string, string> { ["Location"] = "https://example.com/" }
        );
        using var seam = CreateSeam(handler);

        await Assert.ThrowsAsync<HttpRequestException>(() => seam.Devices.ListAsync());
    }
}
