namespace Seam.Test;

using System.Net;
using Seam.Test.Support;

public class HttpErrorTests : FakeSeamConnectTest
{
    [Fact]
    public async Task ThrowsUnauthorizedException()
    {
        using var seam = new SeamClient(
            new SeamClientOptions { ApiKey = "seam_invalid_api_key", Endpoint = Endpoint }
        );

        var exception = await Assert.ThrowsAsync<SeamHttpUnauthorizedException>(
            () => seam.Devices.ListAsync()
        );

        Assert.Equal(401, exception.StatusCode);
        Assert.Equal("unauthorized", exception.Code);
        Assert.StartsWith("request", exception.RequestId);
    }

    [Fact]
    public async Task ThrowsApiExceptionOnStandardErrorResponse()
    {
        using var seam = CreateSeam();

        var exception = await Assert.ThrowsAsync<SeamHttpApiException>(
            () => seam.Devices.GetAsync(new() { DeviceId = "unknown-device" })
        );

        Assert.Equal(404, exception.StatusCode);
        Assert.Equal("device_not_found", exception.Code);
        Assert.StartsWith("request", exception.RequestId);
    }

    // A workspace outage answers with a 503 that is not a Seam error envelope, so it surfaces as
    // the underlying transport error rather than a fabricated Seam exception.
    [Fact]
    public async Task WorkspaceOutageSurfacesTheTransportError()
    {
        using var seam = CreateSeam(maxRetries: 0);

        await PostFakeAsync(
            seam,
            "/_fake/simulate_workspace_outage",
            new { workspace_id = Seed("seed_workspace_1"), routes = new[] { "/devices/list" } }
        );

        var exception = await Assert.ThrowsAsync<HttpRequestException>(
            () => seam.Devices.ListAsync()
        );

        Assert.Equal(HttpStatusCode.ServiceUnavailable, exception.StatusCode);
    }
}

public class InvalidInputTests
{
    private static readonly string InvalidInputBody = """
        {
          "error": {
            "type": "invalid_input",
            "message": "Invalid input",
            "validation_errors": {
              "_errors": ["Request is invalid"],
              "device_ids": { "_errors": ["Expected array, received number"] }
            },
            "request_id": "request1"
          }
        }
        """;

    private static SeamClient CreateSeam(RecordingHandler handler)
    {
        return new SeamClient(
            new SeamClientOptions
            {
                ApiKey = "seam_apikey1_token",
                Endpoint = "https://example.com",
                HttpMessageHandler = handler,
            }
        );
    }

    [Fact]
    public async Task ThrowsInvalidInputExceptionWithValidationMessages()
    {
        var handler = new RecordingHandler().RespondWith(
            HttpStatusCode.BadRequest,
            InvalidInputBody,
            headers: new Dictionary<string, string> { ["seam-request-id"] = "request1" }
        );
        using var seam = CreateSeam(handler);

        var exception = await Assert.ThrowsAsync<SeamHttpInvalidInputException>(
            () => seam.Devices.ListAsync()
        );

        Assert.Equal(400, exception.StatusCode);
        Assert.Equal("invalid_input", exception.Code);
        Assert.Equal("request1", exception.RequestId);
        Assert.Equal(
            new[] { "Expected array, received number" },
            exception.GetValidationErrorMessages("device_ids")
        );
        var validationError = Assert.Single(exception.ValidationErrors);
        Assert.Equal("device_ids", validationError.ParameterName);
        Assert.Equal(new[] { "Expected array, received number" }, validationError.ErrorMessages);
    }

    [Fact]
    public async Task ValidationMessagesAreEmptyForAnUnknownParam()
    {
        var handler = new RecordingHandler().RespondWith(
            HttpStatusCode.BadRequest,
            InvalidInputBody
        );
        using var seam = CreateSeam(handler);

        var exception = await Assert.ThrowsAsync<SeamHttpInvalidInputException>(
            () => seam.Devices.ListAsync()
        );

        Assert.Empty(exception.GetValidationErrorMessages("non_existent_param"));
    }

    [Fact]
    public async Task RequestIdIsNullWhenTheHeaderIsAbsent()
    {
        var handler = new RecordingHandler().RespondWith(
            HttpStatusCode.BadRequest,
            InvalidInputBody
        );
        using var seam = CreateSeam(handler);

        var exception = await Assert.ThrowsAsync<SeamHttpInvalidInputException>(
            () => seam.Devices.ListAsync()
        );

        Assert.Null(exception.RequestId);
    }
}
