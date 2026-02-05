using System.Text.Json;
using IsiGatewayProcess.DTOs.Common;
using Xunit;

namespace IsiGatewayProcess.Tests;

public class PagedResultTests
{
    [Fact]
    public void DeserializePagedResultFromJson()
    {
        const string json = """
        {
          "page": 1,
          "pageSize": 25,
          "totalItems": 4,
          "totalPages": 1,
          "items": [
            { "id": "9e28bba4-22b7-4b07-8f42-46b9c83f5a40", "name": "Item 1" },
            { "id": "7c99bd52-d65a-4b7b-99e9-5ed2a6b8f2a9", "name": "Item 2" }
          ]
        }
        """;

        var result = JsonSerializer.Deserialize<PagedResult<TestItem>>(json);

        Assert.NotNull(result);
        Assert.Equal(1, result!.Page);
        Assert.Equal(25, result.PageSize);
        Assert.Equal(4, result.TotalItems);
        Assert.Equal(1, result.TotalPages);
        Assert.Equal(2, result.Items.Count);
        Assert.Equal("Item 1", result.Items[0].Name);
    }

    [Fact]
    public void DeserializePagedResultWithEmptyItems()
    {
        const string json = """
        {
          "page": 2,
          "pageSize": 10,
          "totalItems": 0,
          "totalPages": 0,
          "items": []
        }
        """;

        var result = JsonSerializer.Deserialize<PagedResult<TestItem>>(json);

        Assert.NotNull(result);
        Assert.Empty(result!.Items);
        Assert.Equal(2, result.Page);
        Assert.Equal(10, result.PageSize);
        Assert.Equal(0, result.TotalItems);
        Assert.Equal(0, result.TotalPages);
    }

    private sealed record TestItem(Guid Id, string Name);
}
