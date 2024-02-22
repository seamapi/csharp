using Seam.Client;

namespace Seam.Test;

public class SeamConnectTest : IDisposable
{
  public SeamClient seam;

  private static readonly Random random = new();

  public SeamConnectTest()
  {
    var r = new string(
      Enumerable
        .Repeat("ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789", 10)
        .Select(s => s[random.Next(s.Length)])
        .ToArray()
    );

    seam = new SeamClient(
      basePath: string.Format("https://{0}.fakeseamconnect.seam.vc", r),
      apiToken: "seam_apikey1_token"
    );
  }

  public void Dispose()
  {
    seam.Dispose();
  }
}
