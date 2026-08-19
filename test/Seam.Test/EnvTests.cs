namespace Seam.Test;

using Seam.Test.Support;

public class EnvTests : FakeSeamConnectTest
{
    [Fact]
    public async Task ReadsTheApiKeyFromTheEnvironment()
    {
        using var env = new EnvGuard();
        env.Set("SEAM_API_KEY", Seed("seam_apikey1_token"));
        env.Set("SEAM_ENDPOINT", Endpoint);

        using var seam = new SeamClient();

        Assert.NotEmpty(await seam.Devices.ListAsync());
    }

    [Fact]
    public async Task ReadsTheEndpointFromTheEnvironment()
    {
        using var env = new EnvGuard();
        env.Set("SEAM_ENDPOINT", Endpoint);

        using var seam = new SeamClient(Seed("seam_apikey1_token"));

        Assert.NotEmpty(await seam.Devices.ListAsync());
    }

    [Fact]
    public void FallsBackToTheDefaultEndpoint()
    {
        using var env = new EnvGuard();

        using var seam = new SeamClient("seam_apikey1_token");

        Assert.Equal("https://connect.getseam.com/", seam.Client.BaseAddress!.ToString());
    }

    [Fact]
    public async Task EndpointOptionWinsOverTheEnvironment()
    {
        using var env = new EnvGuard();
        env.Set("SEAM_ENDPOINT", "http://127.0.0.1:1");

        using var seam = new SeamClient(
            new SeamClientOptions { ApiKey = Seed("seam_apikey1_token"), Endpoint = Endpoint }
        );

        Assert.NotEmpty(await seam.Devices.ListAsync());
    }

    [Fact]
    public async Task ReadsThePersonalAccessTokenAndWorkspaceIdFromTheEnvironment()
    {
        using var env = new EnvGuard();
        env.Set("SEAM_PERSONAL_ACCESS_TOKEN", Seed("seam_at1_token"));
        env.Set("SEAM_WORKSPACE_ID", Seed("seed_workspace_1"));
        env.Set("SEAM_ENDPOINT", Endpoint);

        using var seam = new SeamClient();

        Assert.Equal(
            Seed("august_device_1"),
            (await seam.Devices.GetAsync(new() { DeviceId = Seed("august_device_1") })).DeviceId
        );
    }

    [Fact]
    public async Task ReadsOnlyTheWorkspaceIdFromTheEnvironment()
    {
        using var env = new EnvGuard();
        env.Set("SEAM_WORKSPACE_ID", Seed("seed_workspace_1"));

        using var seam = new SeamClient(
            new SeamClientOptions
            {
                PersonalAccessToken = Seed("seam_at1_token"),
                Endpoint = Endpoint,
            }
        );

        Assert.Equal(
            Seed("august_device_1"),
            (await seam.Devices.GetAsync(new() { DeviceId = Seed("august_device_1") })).DeviceId
        );
    }

    [Fact]
    public async Task WorkspaceIdOptionWinsOverTheEnvironment()
    {
        using var env = new EnvGuard();
        env.Set("SEAM_WORKSPACE_ID", "nonexistent-workspace");

        using var seam = new SeamClient(
            new SeamClientOptions
            {
                PersonalAccessToken = Seed("seam_at1_token"),
                WorkspaceId = Seed("seed_workspace_1"),
                Endpoint = Endpoint,
            }
        );

        Assert.Equal(
            Seed("august_device_1"),
            (await seam.Devices.GetAsync(new() { DeviceId = Seed("august_device_1") })).DeviceId
        );
    }

    [Fact]
    public void FailsWhenBothCredentialEnvironmentVariablesAreSet()
    {
        using var env = new EnvGuard();
        env.Set("SEAM_API_KEY", "seam_apikey1_token");
        env.Set("SEAM_PERSONAL_ACCESS_TOKEN", "seam_at1_token");

        var exception = Assert.Throws<SeamInvalidOptionsException>(() => new SeamClient());

        Assert.Contains("Both SEAM_API_KEY and SEAM_PERSONAL_ACCESS_TOKEN", exception.Message);
    }

    [Fact]
    public void FailsWhenNoCredentialsAreAvailable()
    {
        using var env = new EnvGuard();

        var exception = Assert.Throws<SeamInvalidOptionsException>(() => new SeamClient());

        Assert.Contains("Must specify an ApiKey or PersonalAccessToken", exception.Message);
    }

    [Fact]
    public async Task ApiKeyEnvironmentVariableIsIgnoredForAPersonalAccessToken()
    {
        using var env = new EnvGuard();
        env.Set("SEAM_API_KEY", "seam_apikey_from_env");

        using var seam = new SeamClient(
            new SeamClientOptions
            {
                PersonalAccessToken = Seed("seam_at1_token"),
                WorkspaceId = Seed("seed_workspace_1"),
                Endpoint = Endpoint,
            }
        );

        Assert.Equal(
            Seed("august_device_1"),
            (await seam.Devices.GetAsync(new() { DeviceId = Seed("august_device_1") })).DeviceId
        );
    }

    [Fact]
    public async Task PersonalAccessTokenEnvironmentVariableIsIgnoredForAnApiKey()
    {
        using var env = new EnvGuard();
        env.Set("SEAM_PERSONAL_ACCESS_TOKEN", "seam_at_from_env");

        using var seam = new SeamClient(
            new SeamClientOptions { ApiKey = Seed("seam_apikey1_token"), Endpoint = Endpoint }
        );

        Assert.NotEmpty(await seam.Devices.ListAsync());
    }

    [Fact]
    public async Task WithoutWorkspaceReadsThePersonalAccessTokenFromTheEnvironment()
    {
        using var env = new EnvGuard();
        env.Set("SEAM_PERSONAL_ACCESS_TOKEN", Seed("seam_at1_token"));

        using var seam = new SeamWithoutWorkspaceClient(endpoint: Endpoint);

        Assert.NotEmpty(await seam.Workspaces.ListAsync());
    }

    [Fact]
    public void EmptyEnvironmentVariablesAreTreatedAsUnset()
    {
        using var env = new EnvGuard();
        env.Set("SEAM_API_KEY", "");
        env.Set("SEAM_PERSONAL_ACCESS_TOKEN", "");

        Assert.Throws<SeamInvalidOptionsException>(() => new SeamClient());
    }
}
