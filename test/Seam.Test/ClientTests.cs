namespace Seam.Test;

using System.Net;
using System.Net.Http.Headers;
using Seam.Http;
using Seam.Models;
using Seam.Test.Support;

public class ClientTests : FakeSeamConnectTest
{
    [Fact]
    public async Task ClientPropertyMakesAuthorizedRequests()
    {
        using var seam = CreateSeam();

        using var response = await seam.Client.GetAsync("/devices/list");

        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    }

    [Fact]
    public async Task FromHttpClientNeedsNoCredentials()
    {
        using var client = new HttpClient { BaseAddress = new Uri(Endpoint) };
        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(
            "Bearer",
            Seed("seam_apikey1_token")
        );

        using var seam = SeamClient.FromHttpClient(client);

        Assert.Same(client, seam.Client);
        Assert.NotEmpty(await seam.Devices.ListAsync());
    }

    [Fact]
    public void HttpClientOptionRejectsAnyOtherOption()
    {
        using var client = new HttpClient { BaseAddress = new Uri(Endpoint) };

        var exception = Assert.Throws<SeamInvalidOptionsException>(
            () =>
                new SeamClient(
                    new SeamClientOptions { HttpClient = client, ApiKey = "seam_apikey1_token" }
                )
        );

        Assert.Contains(
            "The ApiKey option cannot be used with the HttpClient option",
            exception.Message
        );
    }

    [Fact]
    public void HttpClientOptionRequiresABaseAddress()
    {
        using var client = new HttpClient();

        Assert.Throws<SeamInvalidOptionsException>(() => SeamClient.FromHttpClient(client));
    }

    [Fact]
    public async Task FromHttpClientStillTakesAWaitForActionAttemptDefault()
    {
        using var client = new HttpClient { BaseAddress = new Uri(Endpoint) };
        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(
            "Bearer",
            Seed("seam_apikey1_token")
        );

        using var seam = SeamClient.FromHttpClient(client, waitForActionAttempt: false);

        var actionAttempt = await seam.Locks.UnlockDoorAsync(
            new() { DeviceId = Seed("august_device_1") }
        );

        Assert.Equal(ActionAttemptStatus.Pending, actionAttempt.Status);
    }

    [Fact]
    public async Task AnInjectedHandlerStillGetsTheErrorMapping()
    {
        var handler = new RecordingHandler().RespondWith(HttpStatusCode.Unauthorized);
        using var seam = CreateSeam(httpMessageHandler: handler);

        await Assert.ThrowsAsync<SeamHttpUnauthorizedException>(() => seam.Devices.ListAsync());
    }

    [Fact]
    public void TimeoutDefaultsToThirtySecondsPerAttempt()
    {
        Assert.Equal(TimeSpan.FromSeconds(30), SeamHttpClientFactory.DefaultTimeout);
    }

    [Fact]
    public void RetriesDefaultToTwo()
    {
        Assert.Equal(2, SeamRetryHandler.DefaultMaxRetries);
    }

    [Fact]
    public async Task DisposeReleasesAnOwnedClient()
    {
        var seam = CreateSeam();
        seam.Dispose();

        await Assert.ThrowsAsync<ObjectDisposedException>(() => seam.Devices.ListAsync());
    }
}
