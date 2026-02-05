using System.Text.Json.Serialization;

namespace IsiGatewayProcess.DTOs.Common;

public record class PagedResult<T>
{
    [JsonPropertyName("page")]
    public int Page { get; init; }

    [JsonPropertyName("pageSize")]
    public int PageSize { get; init; }

    [JsonPropertyName("totalItems")]
    public int TotalItems { get; init; }

    [JsonPropertyName("totalPages")]
    public int TotalPages { get; init; }

    [JsonPropertyName("items")]
    public IReadOnlyList<T> Items { get; init; } = Array.Empty<T>();

    public PagedResult()
    {
    }

    public PagedResult(IReadOnlyList<T> items, int page, int pageSize, int totalItems, int totalPages)
    {
        Items = items;
        Page = page;
        PageSize = pageSize;
        TotalItems = totalItems;
        TotalPages = totalPages;
    }
}
