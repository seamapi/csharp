namespace Seam.Test;

using System.Text.RegularExpressions;
using Seam.Http;

public class VersionTests
{
    [Fact]
    public void VersionIsReadFromTheAssembly()
    {
        Assert.Matches(new Regex(@"^\d+\.\d+\.\d+"), SeamVersion.Value);
    }

    [Fact]
    public void VersionMatchesThePackageVersion()
    {
        var informational = typeof(SeamClient)
            .Assembly.GetCustomAttributes(
                typeof(System.Reflection.AssemblyInformationalVersionAttribute),
                false
            )
            .Cast<System.Reflection.AssemblyInformationalVersionAttribute>()
            .Single()
            .InformationalVersion;

        Assert.StartsWith(SeamVersion.Value, informational);
    }
}
