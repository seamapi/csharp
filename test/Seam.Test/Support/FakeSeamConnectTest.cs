using System.Text;
using System.Text.Json;

namespace Seam.Test.Support;

/// <summary>
/// Base class for tests that run against a fake Seam Connect server. A fresh server is started
/// for every test so no test can observe another's mutations.
/// </summary>
public abstract class FakeSeamConnectTest : IAsyncLifetime
{
    protected FakeSeamConnect Fake { get; private set; } = null!;

    protected string Endpoint => Fake.Endpoint;

    protected string Seed(string key) => Fake.Seed(key);

    public async Task InitializeAsync()
    {
        Fake = await FakeSeamConnect.StartAsync();
    }

    public async Task DisposeAsync()
    {
        await Fake.DisposeAsync();
    }

    /// <summary>
    /// A client authorized against the fake with the seeded API key.
    /// </summary>
    protected SeamClient CreateSeam(
        ActionAttemptWait? waitForActionAttempt = null,
        int? maxRetries = null,
        TimeSpan? timeout = null,
        HttpMessageHandler? httpMessageHandler = null
    )
    {
        return new SeamClient(
            new SeamClientOptions
            {
                ApiKey = Seed("seam_apikey1_token"),
                Endpoint = Endpoint,
                WaitForActionAttempt = waitForActionAttempt,
                MaxRetries = maxRetries,
                Timeout = timeout,
                HttpMessageHandler = httpMessageHandler,
            }
        );
    }

    /// <summary>
    /// Calls one of the fake's own /_fake control endpoints.
    /// </summary>
    protected async Task PostFakeAsync(SeamClient seam, string path, object payload)
    {
        using var content = new StringContent(
            JsonSerializer.Serialize(payload),
            Encoding.UTF8,
            "application/json"
        );
        using var response = await seam.Client.PostAsync(path, content);
        response.EnsureSuccessStatusCode();
    }
}
