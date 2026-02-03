using IsiGatewayProcess.DTOs.Channel;
using IsiGatewayProcess.Repositories.Common;

namespace IsiGatewayProcess.Repositories;

public class InMemoryPetitionStatusRepository : InMemoryRepositoryBase<PetitionStatusDto>, IPetitionStatusRepository
{
    public Task<PetitionStatusDto> CreateAsync(PetitionStatusDto dto)
    {
        return AddAsync(dto.Id, dto);
    }
}
