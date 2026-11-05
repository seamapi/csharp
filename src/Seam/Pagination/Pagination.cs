using System.Text.Json.Serialization;

namespace Seam
{
    /// <summary>
    /// The pagination metadata a paginated list endpoint returns alongside its items.
    /// </summary>
    public sealed record Pagination
    {
        [JsonPropertyName("has_next_page")]
        public required bool HasNextPage { get; init; }

        [JsonPropertyName("next_page_cursor")]
        public string? NextPageCursor { get; init; }

        [JsonPropertyName("next_page_url")]
        public string? NextPageUrl { get; init; }
    }
}
