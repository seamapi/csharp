namespace Seam.Test;

using Seam.Test.Support;

public class PaginatorTests : FakeSeamConnectTest
{
    private (SeamClient Seam, SeamPaginator<Models.ConnectedAccount> Pages) CreatePaginator(
        int limit = 2
    )
    {
        var seam = CreateSeam();

        return (seam, seam.ConnectedAccounts.ListPager(new() { Limit = limit }));
    }

    [Fact]
    public async Task FirstPageReturnsTheFirstPage()
    {
        var (_, pages) = CreatePaginator();

        var (accounts, pagination) = await pages.FirstPageAsync();

        Assert.Equal(2, accounts.Count);
        Assert.True(pagination.HasNextPage);
        Assert.NotNull(pagination.NextPageCursor);
    }

    [Fact]
    public async Task NextPageReturnsTheNextPage()
    {
        var (_, pages) = CreatePaginator();

        var (first, pagination) = await pages.FirstPageAsync();
        var (second, _) = await pages.NextPageAsync(pagination.NextPageCursor!);

        Assert.NotEmpty(second);

        var firstIds = first.Select(account => account.ConnectedAccountId).ToHashSet();
        Assert.DoesNotContain(second, account => firstIds.Contains(account.ConnectedAccountId));
    }

    [Fact]
    public async Task NextPageRequiresACursor()
    {
        var (_, pages) = CreatePaginator();

        await Assert.ThrowsAsync<ArgumentException>(() => pages.NextPageAsync(null!));
    }

    [Fact]
    public async Task NextPageRejectsAnEmptyCursor()
    {
        var (_, pages) = CreatePaginator();

        await Assert.ThrowsAsync<ArgumentException>(() => pages.NextPageAsync(""));
    }

    [Fact]
    public async Task LastPageHasNoNextPage()
    {
        var (_, pages) = CreatePaginator(limit: 100);

        var (_, pagination) = await pages.FirstPageAsync();

        Assert.False(pagination.HasNextPage);
        Assert.Null(pagination.NextPageCursor);
    }

    [Fact]
    public async Task FlattenToListReturnsEveryResource()
    {
        var (seam, pages) = CreatePaginator();

        var all = await pages.FlattenToListAsync();
        var expected = await seam.ConnectedAccounts.ListAsync();

        Assert.Equal(expected.Count, all.Count);
    }

    [Fact]
    public async Task FlattenIteratesEveryResource()
    {
        var (seam, pages) = CreatePaginator();

        var ids = new List<string>();
        await foreach (var account in pages.Flatten())
        {
            ids.Add(account.ConnectedAccountId);
        }

        var expected = await seam.ConnectedAccounts.ListAsync();

        Assert.Equal(expected.Count, ids.Count);
        Assert.Equal(ids.Distinct().Count(), ids.Count);
    }

    [Fact]
    public async Task PagesIteratesEveryPage()
    {
        var (_, pages) = CreatePaginator();

        var pageCount = 0;
        await foreach (var page in pages.Pages())
        {
            Assert.NotNull(page.Pagination);
            pageCount++;
        }

        Assert.True(pageCount > 1);
    }

    [Fact]
    public async Task CreatePaginatorAcceptsAnyPageFetcher()
    {
        var seam = CreateSeam();

        var pages = seam.CreatePaginator(
            (pageCursor, cancellationToken) =>
                seam.ConnectedAccounts.ListPageAsync(
                    new()
                    {
                        Limit = 2,
                        PageCursor = pageCursor == null ? Optional<string>.Unset : pageCursor,
                    },
                    cancellationToken
                )
        );

        var (accounts, _) = await pages.FirstPageAsync();

        Assert.Equal(2, accounts.Count);
    }

    // The unpaginated-endpoint guard is compile-time in this SDK: an endpoint without
    // pagination simply has no pager method.
    [Fact]
    public void UnpaginatedEndpointsHaveNoPager()
    {
        Assert.Null(typeof(Routes.Workspaces).GetMethod("ListPager"));
        Assert.NotNull(typeof(Routes.ConnectedAccounts).GetMethod("ListPager"));
    }
}
