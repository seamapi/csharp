namespace Seam.Test;

using System.Net;
using System.Text.Json;
using Seam.Test.Support;

// A response that is not a Seam error envelope must surface as the transport's own error, never
// as a fabricated Seam exception.
public class MalformedResponseTests
{
    private static readonly Dictionary<string, string> RequestIdHeader =
        new() { ["seam-request-id"] = "request1" };

    private static SeamClient CreateSeam(RecordingHandler handler)
    {
        return new SeamClient(
            new SeamClientOptions
            {
                ApiKey = "seam_apikey1_token",
                Endpoint = "https://example.com",
                HttpMessageHandler = handler,
                MaxRetries = 0,
                WaitForActionAttempt = false,
            }
        );
    }

    private static async Task<SeamHttpInvalidResponseException> ListDevicesAsync(string body)
    {
        var handler = new RecordingHandler().RespondWith(
            HttpStatusCode.OK,
            body,
            headers: RequestIdHeader
        );
        using var seam = CreateSeam(handler);

        return await Assert.ThrowsAsync<SeamHttpInvalidResponseException>(
            () => seam.Devices.ListAsync()
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
    public async Task EmptySuccessBodyRaisesAnInvalidResponseException()
    {
        var exception = await ListDevicesAsync("");

        Assert.Equal(
            "Seam returned an invalid response for /devices/list: expected \"devices\", got an empty body",
            exception.Message
        );
        Assert.Equal("/devices/list", exception.Path);
        Assert.Equal("devices", exception.ResponseKey);
        Assert.Equal(200, exception.StatusCode);
        Assert.Equal("request1", exception.RequestId);
        Assert.Equal("", exception.ResponseBody);
        Assert.Null(exception.InnerException);
        Assert.IsAssignableFrom<SeamException>(exception);
    }

    [Fact]
    public async Task NonJsonSuccessBodyRaisesAnInvalidResponseException()
    {
        var exception = await ListDevicesAsync("not json at all");

        Assert.Equal(
            "Seam returned an invalid response for /devices/list: expected \"devices\", which could not be deserialized",
            exception.Message
        );
        Assert.IsAssignableFrom<JsonException>(exception.InnerException);
        Assert.Equal("not json at all", exception.ResponseBody);
        Assert.Equal(200, exception.StatusCode);
        Assert.Equal("request1", exception.RequestId);
    }

    [Fact]
    public async Task WrongTypeResponseKeyRaisesAnInvalidResponseException()
    {
        var exception = await ListDevicesAsync("{\"devices\":5}");

        Assert.Equal(
            "Seam returned an invalid response for /devices/list: expected \"devices\", which could not be deserialized",
            exception.Message
        );
        Assert.IsAssignableFrom<JsonException>(exception.InnerException);
        Assert.Equal("{\"devices\":5}", exception.ResponseBody);
    }

    [Fact]
    public async Task NullSuccessBodyRaisesAnInvalidResponseException()
    {
        var exception = await ListDevicesAsync("null");

        Assert.Equal(
            "Seam returned an invalid response for /devices/list: expected \"devices\", got null instead of a response object",
            exception.Message
        );
        Assert.Equal("null", exception.ResponseBody);
    }

    [Theory]
    [InlineData("{}")]
    [InlineData("{\"devices\":null}")]
    [InlineData("{\"device\":[]}")]
    public async Task MissingResponseKeyRaisesAnInvalidResponseException(string body)
    {
        var exception = await ListDevicesAsync(body);

        Assert.Equal(
            "Seam returned an invalid response for /devices/list: expected \"devices\", which is missing or null",
            exception.Message
        );
        Assert.Equal(body, exception.ResponseBody);
        Assert.Equal(200, exception.StatusCode);
        Assert.Equal("request1", exception.RequestId);
    }

    [Fact]
    public async Task ActionAttemptResponseWithoutAnActionAttemptRaisesAnInvalidResponseException()
    {
        var handler = new RecordingHandler().RespondWith(HttpStatusCode.OK, "{}");
        using var seam = CreateSeam(handler);

        var exception = await Assert.ThrowsAsync<SeamHttpInvalidResponseException>(
            () => seam.Locks.UnlockDoorAsync(new() { DeviceId = "device1" })
        );

        Assert.Equal(
            "Seam returned an invalid response for /locks/unlock_door: expected \"action_attempt\", which is missing or null",
            exception.Message
        );
    }

    [Fact]
    public async Task ActionAttemptPollWithoutAnActionAttemptRaisesAnInvalidResponseException()
    {
        var handler = new RecordingHandler()
            .RespondWith(
                HttpStatusCode.OK,
                """
                {"action_attempt":{"action_type":"UNLOCK_DOOR","action_attempt_id":"attempt1","status":"pending"}}
                """
            )
            .RespondWith(HttpStatusCode.OK, "{}");
        using var seam = CreateSeam(handler);

        var exception = await Assert.ThrowsAsync<SeamHttpInvalidResponseException>(
            () =>
                seam.Locks.UnlockDoorAsync(
                    new() { DeviceId = "device1" },
                    waitForActionAttempt: new ActionAttemptWait
                    {
                        PollingInterval = TimeSpan.FromMilliseconds(10),
                    }
                )
        );

        Assert.Equal(
            "Seam returned an invalid response for /action_attempts/get: expected \"action_attempt\", which is missing or null",
            exception.Message
        );
        Assert.Equal(2, handler.AttemptCount);
    }

    [Fact]
    public async Task PageWithoutPaginationRaisesAnInvalidResponseException()
    {
        var handler = new RecordingHandler().RespondWith(
            HttpStatusCode.OK,
            "{\"connected_accounts\":[]}"
        );
        using var seam = CreateSeam(handler);

        var exception = await Assert.ThrowsAsync<SeamHttpInvalidResponseException>(
            () => seam.ConnectedAccounts.ListPageAsync()
        );

        Assert.Equal(
            "Seam returned an invalid response for /connected_accounts/list: expected \"pagination\", which is missing or null",
            exception.Message
        );
        Assert.Equal("pagination", exception.ResponseKey);
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
