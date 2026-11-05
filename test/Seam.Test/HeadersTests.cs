namespace Seam.Test;

using System.Text.RegularExpressions;
using Seam.Test.Support;

public class HeadersTests
{
    private static async Task<RecordedRequest> RecordAsync(SeamClientOptions options)
    {
        var handler = new RecordingHandler().RespondWith(
            System.Net.HttpStatusCode.OK,
            "{\"devices\":[]}"
        );
        using var seam = new SeamClient(options with { HttpMessageHandler = handler });

        await seam.Devices.ListAsync();

        return Assert.Single(handler.Requests);
    }

    [Fact]
    public async Task SendsDefaultHeaders()
    {
        var request = await RecordAsync(
            new SeamClientOptions
            {
                ApiKey = "seam_apikey1_token",
                Endpoint = "https://example.com",
            }
        );

        Assert.Equal("Bearer seam_apikey1_token", request.Headers["Authorization"]);
        Assert.Equal("seamapi/csharp", request.Headers["seam-sdk-name"]);
        Assert.Matches(new Regex(@"^\d+\.\d+\.\d+"), request.Headers["seam-sdk-version"]);
        Assert.False(request.Headers.ContainsKey("seam-workspace"));
    }

    [Fact]
    public async Task SendsWorkspaceHeaderWithAPersonalAccessToken()
    {
        var request = await RecordAsync(
            new SeamClientOptions
            {
                PersonalAccessToken = "seam_at1_token",
                WorkspaceId = "workspace1",
                Endpoint = "https://example.com",
            }
        );

        Assert.Equal("Bearer seam_at1_token", request.Headers["Authorization"]);
        Assert.Equal("workspace1", request.Headers["seam-workspace"]);
    }

    [Fact]
    public async Task SdkVersionHeaderMatchesThePackageVersion()
    {
        var request = await RecordAsync(
            new SeamClientOptions
            {
                ApiKey = "seam_apikey1_token",
                Endpoint = "https://example.com",
            }
        );

        Assert.Equal(Seam.Http.SeamVersion.Value, request.Headers["seam-sdk-version"]);
    }
}
