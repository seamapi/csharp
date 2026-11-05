namespace Seam.Test.Support;

/// <summary>
/// Clears the SEAM_* environment variables for the duration of a test and restores whatever was
/// set before, so environment-driven construction is deterministic.
/// </summary>
public sealed class EnvGuard : IDisposable
{
    private static readonly string[] Names =
    {
        "SEAM_API_KEY",
        "SEAM_PERSONAL_ACCESS_TOKEN",
        "SEAM_WORKSPACE_ID",
        "SEAM_ENDPOINT",
    };

    private readonly Dictionary<string, string?> _saved = new();

    public EnvGuard()
    {
        foreach (var name in Names)
        {
            _saved[name] = Environment.GetEnvironmentVariable(name);
            Environment.SetEnvironmentVariable(name, null);
        }
    }

    public void Set(string name, string value)
    {
        Environment.SetEnvironmentVariable(name, value);
    }

    public void Dispose()
    {
        foreach (var (name, value) in _saved)
        {
            Environment.SetEnvironmentVariable(name, value);
        }
    }
}
