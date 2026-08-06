namespace Seam.Test;

using System.Net;
using Seam.Client;

public class ApiResponseTests
{
    [Fact]
    public void EnsureDataReturnsDataWhenPresent()
    {
        var data = new Api.Locks.ListResponse(devices: new List<Model.Device>());
        var response = new ApiResponse<Api.Locks.ListResponse>(HttpStatusCode.OK, data, "{}");

        Assert.Same(data, response.EnsureData("/locks/list"));
    }

    [Fact]
    public void EnsureDataThrowsSeamExceptionWhenDataIsNull()
    {
        var headers = new Multimap<string, string> { { "seam-request-id", "req-123" } };
        var response = new ApiResponse<Api.Locks.ListResponse>(
            HttpStatusCode.OK,
            headers,
            null!,
            "<html>unexpected body</html>"
        );

        var exception = Assert.Throws<SeamException>(() => response.EnsureData("/locks/list"));

        Assert.Equal(200, exception.ErrorCode);
        Assert.Contains("/locks/list", exception.Message);
        Assert.Contains("HTTP 200", exception.Message);
        Assert.Equal("<html>unexpected body</html>", exception.ErrorContent);
        Assert.Equal(headers, exception.Headers);
    }

    [Fact]
    public void EnsureDataIncludesErrorTextInMessageWhenSet()
    {
        var response = new ApiResponse<Api.Locks.ListResponse>(HttpStatusCode.OK, null!, "not json")
        {
            ErrorText = "Error deserializing response",
        };

        var exception = Assert.Throws<SeamException>(() => response.EnsureData("/locks/list"));

        Assert.Contains("Error deserializing response", exception.Message);
        Assert.Equal("not json", exception.ErrorContent);
    }
}
