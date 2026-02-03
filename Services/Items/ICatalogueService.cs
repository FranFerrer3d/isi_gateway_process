using IsiGatewayProcess.DTOs.Items;
using IsiGatewayProcess.DTOs.Common;
using IsiGatewayProcess.DTOs.Items.Requests;

namespace IsiGatewayProcess.Services;

public interface ICatalogueService
{
    Task<CatalogueDto?> GetAsync(Guid id);
    Task<PagedResult<CatalogueDto>> ListAsync(int page, int pageSize);
    Task<CatalogueDto> CreateAsync(CreateCatalogueRequest request);
    Task<CatalogueDto?> UpdateAsync(Guid id, UpdateCatalogueRequest request);
    Task<bool> DeleteAsync(Guid id);
}
