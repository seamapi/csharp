namespace Seam.Test;

using System.Net;
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

public class PaginatorLoopGuardTests
{
    private const string PinnedCursorPage = """
        {"connected_accounts":[{}],"pagination":{"has_next_page":true,"next_page_cursor":"c1"}}
        """;

    private const string NullCursorPage = """
        {"connected_accounts":[{}],"pagination":{"has_next_page":true,"next_page_cursor":null}}
        """;

    private const string FirstDevicesPage = """
        {"devices":[{}],"pagination":{"has_next_page":true,"next_page_cursor":"c1"}}
        """;

    private const string LastDevicesPage = """
        {"devices":[{}],"pagination":{"has_next_page":false,"next_page_cursor":null}}
        """;

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

    [Fact]
    public async Task StopsWhenTheCursorRepeats()
    {
        var handler = new RecordingHandler().RespondWith(HttpStatusCode.OK, PinnedCursorPage);
        using var seam = CreateSeam(handler);
        using var cancellation = new CancellationTokenSource(TimeSpan.FromSeconds(10));

        var accounts = await seam
            .ConnectedAccounts.ListPager()
            .FlattenToListAsync(cancellation.Token);

        Assert.Equal(2, accounts.Count);
        Assert.Equal(2, handler.AttemptCount);
        Assert.DoesNotContain("page_cursor", handler.Requests[0].Uri.Query);
        Assert.Contains("page_cursor=c1", handler.Requests[1].Uri.Query);
    }

    [Fact]
    public async Task StopsWhenTheCursorIsNull()
    {
        var handler = new RecordingHandler().RespondWith(HttpStatusCode.OK, NullCursorPage);
        using var seam = CreateSeam(handler);

        var pages = new List<SeamPage<Models.ConnectedAccount>>();
        await foreach (var page in seam.ConnectedAccounts.ListPager().Pages())
        {
            pages.Add(page);
        }

        Assert.Single(pages);
        Assert.Equal(1, handler.AttemptCount);
    }

    [Fact]
    public async Task SendsThePageCursorWhenTheRequestHasNoParameters()
    {
        var handler = new RecordingHandler()
            .RespondWith(HttpStatusCode.OK, FirstDevicesPage)
            .RespondWith(HttpStatusCode.OK, LastDevicesPage);
        using var seam = CreateSeam(handler);

        var devices = await seam.Devices.ListPager().FlattenToListAsync();

        Assert.Equal(2, devices.Count);
        Assert.Equal(2, handler.AttemptCount);
        Assert.Equal(HttpMethod.Get, handler.Requests[1].Method);
        Assert.Equal("", handler.Requests[1].Body);
        Assert.Contains("page_cursor=c1", handler.Requests[1].Uri.Query);
        Assert.Contains("_strict=true", handler.Requests[1].Uri.Query);
    }
}
