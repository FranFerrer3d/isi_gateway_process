using IsiGatewayProcess.DTOs.Inventory;
using IsiGatewayProcess.Repositories.Common;

namespace IsiGatewayProcess.Repositories;

public class InMemoryStorageRepository : InMemoryRepositoryBase<StorageDto>, IStorageRepository
{
    public Task<StorageDto> CreateAsync(StorageDto dto)
    {
        return AddAsync(dto.Id, dto);
    }
}
