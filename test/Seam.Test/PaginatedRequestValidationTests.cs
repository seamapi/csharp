namespace Seam.Test;

using Seam.Http;

public class PaginatedRequestValidationTests
{
    private static (SeamPaginator<object> Paginator, Func<int> FetchCount) CreatePaginator()
    {
        var fetchCount = 0;
        var paginator = new SeamPaginator<object>(
            (_, _) =>
            {
                RequestParameters.RequireAtLeastOne("/test/list", false);
                fetchCount++;
                return Task.FromResult(
                    new SeamPage<object>([], new Pagination { HasNextPage = false })
                );
            }
        );

        return (paginator, () => fetchCount);
    }

    private static async Task AssertValidatesBeforeFetchingAsync(
        Func<SeamPaginator<object>, Task> request
    )
    {
        var (paginator, fetchCount) = CreatePaginator();

        var exception = await Assert.ThrowsAsync<ArgumentException>(() => request(paginator));

        Assert.Equal("At least one parameter is required for /test/list", exception.Message);
        Assert.Equal(0, fetchCount());
    }

    [Fact]
    public Task FirstPageValidatesTheRequest()
    {
        return AssertValidatesBeforeFetchingAsync(paginator => paginator.FirstPageAsync());
    }

    [Fact]
    public Task NextPageValidatesTheRequest()
    {
        return AssertValidatesBeforeFetchingAsync(paginator => paginator.NextPageAsync("c1"));
    }

    [Fact]
    public Task FlattenToListValidatesTheRequest()
    {
        return AssertValidatesBeforeFetchingAsync(paginator => paginator.FlattenToListAsync());
    }

    [Fact]
    public Task FlattenValidatesTheRequest()
    {
        return AssertValidatesBeforeFetchingAsync(async paginator =>
        {
            await foreach (var _ in paginator.Flatten()) { }
        });
    }

    [Fact]
    public Task PagesValidatesTheRequest()
    {
        return AssertValidatesBeforeFetchingAsync(async paginator =>
        {
            await foreach (var _ in paginator.Pages()) { }
        });
    }
}
