namespace IsiGatewayProcess.Services.Common;

public static class PagingHelper
{
    public static (int Page, int PageSize) Normalize(int page, int pageSize)
    {
        var normalizedPage = page < 1 ? 1 : page;
        var normalizedPageSize = pageSize < 1 ? 25 : pageSize;
        if (normalizedPageSize > 100)
        {
            normalizedPageSize = 100;
        }

        return (normalizedPage, normalizedPageSize);
    }
}
