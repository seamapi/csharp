namespace Seam.Test;

using Seam.Test.Support;

public class PersonalAccessTokenTests : FakeSeamConnectTest
{
    [Fact]
    public async Task FromPersonalAccessTokenReturnsAnAuthorizedClient()
    {
        using var seam = SeamClient.FromPersonalAccessToken(
            Seed("seam_at1_token"),
            Seed("seed_workspace_1"),
            new SeamClientOptions { Endpoint = Endpoint }
        );

        var devices = await seam.Devices.ListAsync();

        Assert.NotEmpty(devices);
    }

    [Fact]
    public async Task ConstructorReturnsAnAuthorizedClient()
    {
        using var seam = new SeamClient(
            new SeamClientOptions
            {
                PersonalAccessToken = Seed("seam_at1_token"),
                WorkspaceId = Seed("seed_workspace_1"),
                Endpoint = Endpoint,
            }
        );

        var devices = await seam.Devices.ListAsync();

        Assert.NotEmpty(devices);
    }

    [Fact]
    public void WorkspaceIdIsRequired()
    {
        using var env = new EnvGuard();

        var exception = Assert.Throws<SeamInvalidOptionsException>(
            () => new SeamClient(new SeamClientOptions { PersonalAccessToken = "seam_at1_token" })
        );

        Assert.Contains("Must pass a WorkspaceId", exception.Message);
    }

    [Fact]
    public void ApiKeyCannotBeCombinedWithAPersonalAccessToken()
    {
        var exception = Assert.Throws<SeamInvalidOptionsException>(
            () =>
                new SeamClient(
                    new SeamClientOptions
                    {
                        ApiKey = "seam_apikey1_token",
                        PersonalAccessToken = "seam_at1_token",
                        WorkspaceId = "workspace1",
                    }
                )
        );

        Assert.Contains(
            "The PersonalAccessToken option cannot be used with the ApiKey option",
            exception.Message
        );
    }

    [Theory]
    [InlineData(
        "seam_cst1_token",
        "A Client Session Token cannot be used as a PersonalAccessToken"
    )]
    [InlineData("seam_pk1_token", "A Publishable Key cannot be used as a PersonalAccessToken")]
    [InlineData("ey_json_web_token", "A JWT cannot be used as a PersonalAccessToken")]
    [InlineData("seam_apikey1_token", "Unknown or invalid PersonalAccessToken format")]
    public void PersonalAccessTokenFormatIsChecked(string token, string message)
    {
        var exception = Assert.Throws<SeamInvalidTokenException>(
            () =>
                new SeamClient(
                    new SeamClientOptions
                    {
                        PersonalAccessToken = token,
                        WorkspaceId = "workspace1",
                    }
                )
        );

        Assert.Contains(message, exception.Message);
    }

    [Fact]
    public async Task WithoutWorkspaceClientListsWorkspaces()
    {
        using var seam = SeamWithoutWorkspaceClient.FromPersonalAccessToken(
            Seed("seam_at1_token"),
            endpoint: Endpoint
        );

        var workspaces = await seam.Workspaces.ListAsync();

        Assert.NotEmpty(workspaces);
    }

    [Fact]
    public async Task WithoutWorkspaceConstructorListsWorkspaces()
    {
        using var seam = new SeamWithoutWorkspaceClient(Seed("seam_at1_token"), endpoint: Endpoint);

        var workspaces = await seam.Workspaces.ListAsync();

        Assert.NotEmpty(workspaces);
    }

    [Fact]
    public async Task WithoutWorkspaceClientCreatesAWorkspace()
    {
        using var seam = new SeamWithoutWorkspaceClient(Seed("seam_at1_token"), endpoint: Endpoint);

        // The pinned blueprint still marks connect_partner_name obsolete; its deprecation is
        // being reversed upstream, so the pragma goes away on a future regeneration.
#pragma warning disable CS0618
        var workspace = await seam.Workspaces.CreateAsync(
            new()
            {
                Name = "Test Workspace",
                ConnectPartnerName = "Test Partner",
                IsSandbox = true,
            }
        );
#pragma warning restore CS0618

        Assert.NotNull(workspace.WorkspaceId);
    }

    [Fact]
    public void WithoutWorkspaceClientRequiresAToken()
    {
        using var env = new EnvGuard();

        var exception = Assert.Throws<SeamInvalidOptionsException>(
            () => new SeamWithoutWorkspaceClient()
        );

        Assert.Contains("Must specify a PersonalAccessToken", exception.Message);
    }

    [Fact]
    public void WithoutWorkspaceClientChecksTheTokenFormat()
    {
        Assert.Throws<SeamInvalidTokenException>(
            () => new SeamWithoutWorkspaceClient("seam_apikey1_token")
        );
    }
}
