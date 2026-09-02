namespace Seam.Test;

using Seam.Test.Support;

public class PaginatedRequestValidationTests
{
    private static SeamClient CreateSeam(RecordingHandler handler)
    {
        return new SeamClient(
            new SeamClientOptions
            {
                ApiKey = "seam_apikey1_token",
                Endpoint = "https://example.com",
                HttpMessageHandler = handler,
                MaxRetries = 0,
            }
        );
    }

    private static async Task AssertValidatesBeforeSendingAsync(Func<SeamClient, Task> request)
    {
        var handler = new RecordingHandler();
        using var seam = CreateSeam(handler);

        var exception = await Assert.ThrowsAsync<ArgumentException>(() => request(seam));

        Assert.Equal(
            "At least one parameter is required for /access_codes/list",
            exception.Message
        );
        Assert.Equal(0, handler.AttemptCount);
    }

    [Fact]
    public Task PageMethodValidatesTheRequest()
    {
        return AssertValidatesBeforeSendingAsync(seam => seam.AccessCodes.ListPageAsync(new()));
    }

    [Fact]
    public Task FirstPageValidatesTheRequest()
    {
        return AssertValidatesBeforeSendingAsync(seam =>
            seam.AccessCodes.ListPager(new()).FirstPageAsync()
        );
    }

    [Fact]
    public Task FlattenToListValidatesTheRequest()
    {
        return AssertValidatesBeforeSendingAsync(seam =>
            seam.AccessCodes.ListPager(new()).FlattenToListAsync()
        );
    }
}
