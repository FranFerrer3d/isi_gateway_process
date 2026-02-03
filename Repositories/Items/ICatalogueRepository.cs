using IsiGatewayProcess.DTOs.Items;

namespace IsiGatewayProcess.Repositories;

public interface ICatalogueRepository
{
    Task<CatalogueDto?> GetAsync(Guid id);
    Task<IReadOnlyList<CatalogueDto>> ListAsync(int skip, int take);
    Task<int> CountAsync();
    Task<CatalogueDto> CreateAsync(CatalogueDto dto);
    Task<bool> UpdateAsync(Guid id, CatalogueDto dto);
    Task<bool> DeleteAsync(Guid id);
}
