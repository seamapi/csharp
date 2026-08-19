using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

namespace Seam
{
    /// <summary>
    /// Fetches one page of a paginated list endpoint.
    /// </summary>
    /// <param name="pageCursor">
    /// The cursor of the page to fetch, or null for the first page.
    /// </param>
    /// <param name="cancellationToken">Cancels the fetch.</param>
    public delegate Task<SeamPage<TItem>> FetchPage<TItem>(
        string? pageCursor,
        CancellationToken cancellationToken
    );

    /// <summary>
    /// Iterates the pages of a paginated list endpoint.
    /// </summary>
    /// <remarks>
    /// Created by the <c>ListPager</c> method every paginated endpoint offers, e.g.
    /// <c>seam.Devices.ListPager(new() { Limit = 20 })</c>, or from any page-fetching function
    /// via <see cref="SeamClient.CreatePaginator{TItem}"/>.
    /// </remarks>
    public sealed class SeamPaginator<TItem>
    {
        private readonly FetchPage<TItem> _fetchPage;

        public SeamPaginator(FetchPage<TItem> fetchPage)
        {
            _fetchPage = fetchPage;
        }

        /// <summary>Fetches the first page.</summary>
        public Task<SeamPage<TItem>> FirstPageAsync(CancellationToken cancellationToken = default)
        {
            return _fetchPage(null, cancellationToken);
        }

        /// <summary>Fetches the page after the given cursor.</summary>
        public Task<SeamPage<TItem>> NextPageAsync(
            string nextPageCursor,
            CancellationToken cancellationToken = default
        )
        {
            if (string.IsNullOrEmpty(nextPageCursor))
                throw new ArgumentException(
                    "The next page cursor cannot be null or empty",
                    nameof(nextPageCursor)
                );

            return _fetchPage(nextPageCursor, cancellationToken);
        }

        /// <summary>Fetches every page and returns all items as one list.</summary>
        public async Task<List<TItem>> FlattenToListAsync(
            CancellationToken cancellationToken = default
        )
        {
            var items = new List<TItem>();

            await foreach (var item in Flatten(cancellationToken).ConfigureAwait(false))
            {
                items.Add(item);
            }

            return items;
        }

        /// <summary>Lazily iterates every item across all pages.</summary>
        public async IAsyncEnumerable<TItem> Flatten(
            [EnumeratorCancellation] CancellationToken cancellationToken = default
        )
        {
            await foreach (var page in Pages(cancellationToken).ConfigureAwait(false))
            {
                foreach (var item in page.Items)
                {
                    yield return item;
                }
            }
        }

        /// <summary>Lazily iterates every page.</summary>
        public async IAsyncEnumerable<SeamPage<TItem>> Pages(
            [EnumeratorCancellation] CancellationToken cancellationToken = default
        )
        {
            var page = await FirstPageAsync(cancellationToken).ConfigureAwait(false);
            yield return page;

            while (page.Pagination.HasNextPage)
            {
                page = await NextPageAsync(page.Pagination.NextPageCursor!, cancellationToken)
                    .ConfigureAwait(false);
                yield return page;
            }
        }
    }
}
