namespace Seam.Test;

using System.Net;
using Seam.Test.Support;

// Wire-level assertions: GET and DELETE carry their parameters as URL search parameters per the
// Seam serialization standard with strict mode enabled, everything else sends a JSON body.
public class SearchParamsTests
{
    private static (SeamClient Seam, RecordingHandler Handler) CreateSeam(string body = "{}")
    {
        var handler = new RecordingHandler().RespondWith(HttpStatusCode.OK, body);
        var seam = new SeamClient(
            new SeamClientOptions
            {
                ApiKey = "seam_apikey1_token",
                Endpoint = "https://example.com",
                HttpMessageHandler = handler,
                WaitForActionAttempt = false,
            }
        );

        return (seam, handler);
    }

    [Fact]
    public async Task GetCarriesParametersInTheQuery()
    {
        var (seam, handler) = CreateSeam("{\"devices\":[]}");

        await seam.Devices.ListAsync(
            new()
            {
                Limit = 2,
                DeviceIds = new List<string> { "device1", "device2" },
            }
        );

        var request = Assert.Single(handler.Requests);
        Assert.Equal(HttpMethod.Get, request.Method);
        Assert.Equal("/devices/list", request.Uri.AbsolutePath);
        Assert.Contains("limit=2", request.Uri.Query);
        Assert.Contains("device_ids=device1", request.Uri.Query);
        Assert.Contains("device_ids=device2", request.Uri.Query);
        Assert.Contains("_strict=true", request.Uri.Query);
        Assert.Equal("", request.Body);
    }

    [Fact]
    public async Task GetWithoutParametersHasAnEmptyQuery()
    {
        var (seam, handler) = CreateSeam("{\"devices\":[]}");

        await seam.Devices.ListAsync();

        var request = Assert.Single(handler.Requests);
        Assert.Equal("", request.Uri.Query);
    }

    [Fact]
    public async Task DeleteCarriesParametersInTheQuery()
    {
        var (seam, handler) = CreateSeam();

        await seam.AccessCodes.DeleteAsync(new() { AccessCodeId = "access_code1" });

        var request = Assert.Single(handler.Requests);
        Assert.Equal(HttpMethod.Delete, request.Method);
        Assert.Equal("/access_codes/delete", request.Uri.AbsolutePath);
        Assert.Contains("access_code_id=access_code1", request.Uri.Query);
        Assert.Contains("_strict=true", request.Uri.Query);
        Assert.Equal("", request.Body);
    }

    [Fact]
    public async Task PostSendsAJsonBody()
    {
        var (seam, handler) = CreateSeam(
            """
            {"action_attempt":{"action_type":"UNLOCK_DOOR","action_attempt_id":"attempt1","status":"pending"}}
            """
        );

        await seam.Locks.UnlockDoorAsync(new() { DeviceId = "device1" });

        var request = Assert.Single(handler.Requests);
        Assert.Equal(HttpMethod.Post, request.Method);
        Assert.Equal("", request.Uri.Query);
        Assert.Contains("\"device_id\":\"device1\"", request.Body);
    }

    [Fact]
    public async Task OmittedParametersAreAbsentFromTheBody()
    {
        var (seam, handler) = CreateSeam(
            """
            {"action_attempt":{"action_type":"UNLOCK_DOOR","action_attempt_id":"attempt1","status":"pending"}}
            """
        );

        await seam.Locks.UnlockDoorAsync(new() { DeviceId = "device1" });

        var request = Assert.Single(handler.Requests);
        Assert.Equal("{\"device_id\":\"device1\"}", request.Body);
    }

    [Fact]
    public async Task AtLeastOneParameterIsRequiredLocally()
    {
        var (seam, handler) = CreateSeam();

        var exception = await Assert.ThrowsAsync<ArgumentException>(
            () => seam.Devices.GetAsync(new())
        );

        Assert.Contains("At least one parameter is required", exception.Message);
        Assert.Empty(handler.Requests);
    }
}
