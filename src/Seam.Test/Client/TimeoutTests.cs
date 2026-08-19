namespace Seam.Test;

using Seam.Client;

public class TimeoutTests
{
    [Fact]
    public void DefaultTimeoutIs30Seconds()
    {
        Assert.Equal(30000, SeamRequestConfiguration.DefaultTimeout);
    }

    [Fact]
    public void NewConfigurationUsesTheDefaultTimeout()
    {
        var configuration = new SeamRequestConfiguration();

        Assert.Equal(SeamRequestConfiguration.DefaultTimeout, configuration.Timeout);
    }

    [Fact]
    public void GlobalConfigurationUsesTheDefaultTimeout()
    {
        Assert.Equal(
            SeamRequestConfiguration.DefaultTimeout,
            GlobalSeamRequestConfiguration.Instance.Timeout
        );
    }

    [Fact]
    public void ConfigurationTimeoutCanBeOverridden()
    {
        var configuration = new SeamRequestConfiguration { Timeout = 60000 };

        Assert.Equal(60000, configuration.Timeout);
    }

    [Fact]
    public void MergedConfigurationTakesTheTimeoutFromTheSecondConfiguration()
    {
        var first = new SeamRequestConfiguration { Timeout = 60000 };
        var second = new SeamRequestConfiguration { Timeout = 5000 };

        var merged = SeamRequestConfiguration.MergeConfigurations(first, second);

        Assert.Equal(5000, merged.Timeout);
    }

    [Fact]
    public void ClientAcceptsATimeout()
    {
        var seam = new SeamClient(apiToken: "seam_apikey_token", timeout: 60000);

        Assert.NotNull(seam);
    }
}
