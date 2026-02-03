using IsiGatewayProcess.DTOs.Items;
using IsiGatewayProcess.Repositories.Common;

namespace IsiGatewayProcess.Repositories;

public class InMemoryCatalogueRepository : InMemoryRepositoryBase<CatalogueDto>, ICatalogueRepository
{
    public Task<CatalogueDto> CreateAsync(CatalogueDto dto)
    {
        return AddAsync(dto.Id, dto);
    }
}
