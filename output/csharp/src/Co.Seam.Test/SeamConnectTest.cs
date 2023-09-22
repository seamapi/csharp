namespace Seam.Test;

using Seam.Client;

public class SeamConnectTest : IDisposable
{
    public Seam seam;

    private static readonly Random random = new();

    public SeamConnectTest()
    {
        var r = new string(
            Enumerable
                .Repeat("ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789", 10)
                .Select(s => s[random.Next(s.Length)])
                .ToArray()
        );

        seam = new Seam(
            basePath: string.Format("https://{0}.fakeseamconnect.seam.vc", r),
            apiToken: "seam_apikey1_token"
        );
    }

    public void Dispose()
    {
        seam.Dispose();
    }
}
