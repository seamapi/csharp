namespace Seam.Test;

using System.Net;
using System.Text;
using Seam.Client;

/// <summary>
/// Exercises what the client puts on the wire for each preferred HTTP method.
/// </summary>
public class RequestTransportTests : IDisposable
{
    private readonly HttpListener _listener;
    private readonly string _basePath;

    private string _method = "";
    private string _url = "";
    private string _body = "";

    public RequestTransportTests()
    {
        var port = GetAvailablePort();
        _basePath = $"http://127.0.0.1:{port}";
        _listener = new HttpListener();
        _listener.Prefixes.Add($"{_basePath}/");
        _listener.Start();
    }

    public void Dispose()
    {
        _listener.Close();
        GC.SuppressFinalize(this);
    }

    private static int GetAvailablePort()
    {
        var listener = new System.Net.Sockets.TcpListener(IPAddress.Loopback, 0);
        listener.Start();
        var port = ((IPEndPoint)listener.LocalEndpoint).Port;
        listener.Stop();

        return port;
    }

    private SeamClient CreateClient(string responseBody)
    {
        _ = Task.Run(() =>
        {
            var context = _listener.GetContext();
            _method = context.Request.HttpMethod;
            _url = context.Request.RawUrl ?? "";

            using (var reader = new StreamReader(context.Request.InputStream))
            {
                _body = reader.ReadToEnd();
            }

            var bytes = Encoding.UTF8.GetBytes(responseBody);
            context.Response.ContentType = "application/json";
            context.Response.ContentLength64 = bytes.Length;
            context.Response.OutputStream.Write(bytes, 0, bytes.Length);
            context.Response.Close();
        });

        return new SeamClient(basePath: _basePath, apiToken: "seam_apikey_token");
    }

    [Fact]
    public void SendsGetParamsAsSortedSearchParams()
    {
        var seam = CreateClient("{\"acs_encoders\":[]}");

        seam.EncodersAcs.List(acsSystemIds: new List<string> { "system1", "system2" }, limit: 20);

        Assert.Equal("GET", _method);
        Assert.Equal(
            "/acs/encoders/list?acs_system_ids=system1&acs_system_ids=system2&limit=20&_strict=true",
            _url
        );
        Assert.Equal("", _body);
    }

    [Fact]
    public void SendsGetParamsOfEveryPrimitiveType()
    {
        var seam = CreateClient("{\"acs_credentials\":[]}");

        seam.CredentialsAcs.List(
            acsUserId: "user1",
            isMultiPhoneSyncCredential: true,
            limit: 20,
            search: "a b*~"
        );

        Assert.Equal("GET", _method);

        // `~` reaches the wire unescaped rather than as `%7E`, because Uri normalizes a
        // percent-encoded unreserved character back to its literal form. Both decode to the
        // same param.
        Assert.Equal(
            "/acs/credentials/list?acs_user_id=user1&is_multi_phone_sync_credential=true"
                + "&limit=20&search=a+b*~&_strict=true",
            _url
        );
    }

    [Fact]
    public void SendsAGetWithNoParamsWithoutAQuery()
    {
        var seam = CreateClient("{\"workspaces\":[]}");

        seam.Workspaces.List();

        Assert.Equal("GET", _method);
        Assert.Equal("/workspaces/list", _url);
    }

    [Fact]
    public void SendsTheNullSentinelAsAnEmptySearchParamValue()
    {
        var seam = CreateClient("{\"workspace\":{}}");

        seam.Get<Api.Workspaces.GetResponse>(
            "/workspaces/get",
            new RequestOptions
            {
                Data = new Dictionary<string, object?> { ["workspace_id"] = Null.Value },
            }
        );

        Assert.Equal("GET", _method);
        Assert.Equal("/workspaces/get?workspace_id=&_strict=true", _url);
    }

    [Fact]
    public void SendsDeleteParamsAsSearchParams()
    {
        var seam = CreateClient("{}");

        seam.AccessMethods.Delete(accessMethodId: "method1");

        Assert.Equal("DELETE", _method);
        Assert.Equal("/access_methods/delete?access_method_id=method1&_strict=true", _url);
        Assert.Equal("", _body);
    }

    [Fact]
    public void SendsPostParamsAsAJsonBody()
    {
        var seam = CreateClient("{}");

        seam.ConnectedAccounts.Sync(connectedAccountId: "account1");

        Assert.Equal("POST", _method);
        Assert.Equal("/connected_accounts/sync", _url);
        Assert.Equal("{\"connected_account_id\":\"account1\"}", _body);
    }

    [Fact]
    public void SendsPatchParamsAsAJsonBody()
    {
        var seam = CreateClient("{}");

        seam.AccessGrants.Update(accessGrantId: "grant1", startsAt: "2025-02-24T18:44:39.000Z");

        Assert.Equal("PATCH", _method);
        Assert.Equal("/access_grants/update", _url);
        Assert.Equal(
            "{\"access_grant_id\":\"grant1\",\"starts_at\":\"2025-02-24T18:44:39.000Z\"}",
            _body
        );
    }
}
