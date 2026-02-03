namespace IsiGatewayProcess.DTOs.Common;

public record class PagedResult<T>(IReadOnlyList<T> Items, int Page, int PageSize, int TotalCount);
