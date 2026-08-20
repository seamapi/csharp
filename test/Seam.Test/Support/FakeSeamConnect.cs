using System.Diagnostics;
using System.Net.Sockets;
using System.Text.Json;

namespace Seam.Test.Support;

/// <summary>
/// Runs a fake Seam Connect server for the duration of a single test.
/// </summary>
/// <remarks>
/// Prefer this over stubbing HTTP responses: the fake exercises the SDK against a real server
/// and seeded records. Use <see cref="RecordingHandler"/> only for the things the fake cannot
/// do: asserting what goes out on the wire, counting retries, and serving malformed responses.
/// </remarks>
public sealed class FakeSeamConnect : IAsyncDisposable
{
    private static readonly TimeSpan StartupTimeout = TimeSpan.FromSeconds(30);

    private static readonly TimeSpan PollInterval = TimeSpan.FromMilliseconds(50);

    private static readonly HttpClient Http = new() { Timeout = TimeSpan.FromSeconds(5) };

    private Process? _process;

    private JsonElement _seed;

    public string Endpoint { get; private set; } = "";

    /// <summary>An id or token of a seeded record, e.g. <c>seam_apikey1_token</c>.</summary>
    public string Seed(string key) => _seed.GetProperty(key).GetString()!;

    public static async Task<FakeSeamConnect> StartAsync()
    {
        var fake = new FakeSeamConnect();
        await fake.RunAsync();

        return fake;
    }

    private async Task RunAsync()
    {
        var binary = FindBinary();
        var port = UnusedPort();
        Endpoint = $"http://127.0.0.1:{port}";

        // The binary is spawned directly rather than through npm so the process handle is the
        // server itself and stopping it does not leave an orphan behind. PORT goes to the child
        // only, leaving the parent environment alone for the tests that read it.
        var startInfo = new ProcessStartInfo
        {
            FileName = binary,
            ArgumentList = { "--seed" },
            UseShellExecute = false,
            RedirectStandardOutput = true,
            RedirectStandardError = true,
        };
        startInfo.Environment["PORT"] = port.ToString();

        _process =
            Process.Start(startInfo)
            ?? throw new InvalidOperationException("Could not start Fake Seam Connect.");

        // Drain the output pipes so the server never blocks on a full buffer.
        _process.OutputDataReceived += (_, _) => { };
        _process.ErrorDataReceived += (_, _) => { };
        _process.BeginOutputReadLine();
        _process.BeginErrorReadLine();

        await WaitForHealthAsync();
        _seed = await FetchSeedAsync();
    }

    public async ValueTask DisposeAsync()
    {
        if (_process == null)
            return;

        try
        {
            _process.Kill(entireProcessTree: true);
            await _process.WaitForExitAsync();
        }
        catch (InvalidOperationException)
        {
            // The process already exited.
        }

        _process.Dispose();
        _process = null;
    }

    private async Task WaitForHealthAsync()
    {
        var startup = Stopwatch.StartNew();

        while (startup.Elapsed < StartupTimeout)
        {
            if (_process!.HasExited)
                throw new InvalidOperationException(
                    "Fake Seam Connect exited before becoming healthy."
                );

            if (await GetAsync("/health") != null)
                return;

            await Task.Delay(PollInterval);
        }

        throw new TimeoutException(
            $"Fake Seam Connect did not become healthy within {StartupTimeout.TotalSeconds}s."
        );
    }

    private async Task<JsonElement> FetchSeedAsync()
    {
        var body =
            await GetAsync("/_fake/default_seed")
            ?? throw new InvalidOperationException(
                "Could not read the seed from Fake Seam Connect."
            );

        using var document = JsonDocument.Parse(body);

        return document.RootElement.Clone();
    }

    private async Task<string?> GetAsync(string path)
    {
        try
        {
            using var response = await Http.GetAsync(Endpoint + path);

            return response.IsSuccessStatusCode ? await response.Content.ReadAsStringAsync() : null;
        }
        catch (HttpRequestException)
        {
            return null;
        }
        catch (TaskCanceledException)
        {
            return null;
        }
    }

    private static string FindBinary()
    {
        // Walk up from the test assembly to the repository root holding node_modules.
        for (
            var directory = new DirectoryInfo(AppContext.BaseDirectory);
            directory != null;
            directory = directory.Parent
        )
        {
            var binary = Path.Combine(
                directory.FullName,
                "node_modules",
                ".bin",
                OperatingSystem.IsWindows() ? "fake-seam-connect.cmd" : "fake-seam-connect"
            );

            if (File.Exists(binary))
                return binary;
        }

        throw new FileNotFoundException(
            "Could not find fake-seam-connect, run npm install before the tests."
        );
    }

    private static int UnusedPort()
    {
        var listener = new TcpListener(System.Net.IPAddress.Loopback, 0);
        listener.Start();
        var port = ((System.Net.IPEndPoint)listener.LocalEndpoint).Port;
        listener.Stop();

        return port;
    }
}
