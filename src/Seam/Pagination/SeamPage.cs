using System.Collections.Generic;

namespace Seam
{
    /// <summary>
    /// One page of results from a paginated list endpoint.
    /// </summary>
    public sealed record SeamPage<TItem>(IReadOnlyList<TItem> Items, Pagination Pagination);
}
