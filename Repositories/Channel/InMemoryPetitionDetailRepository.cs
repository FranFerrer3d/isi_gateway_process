using IsiGatewayProcess.DTOs.Channel;
using IsiGatewayProcess.Repositories.Common;

namespace IsiGatewayProcess.Repositories;

public class InMemoryPetitionDetailRepository : InMemoryRepositoryBase<PetitionDetailDto>, IPetitionDetailRepository
{
    public Task<PetitionDetailDto> CreateAsync(PetitionDetailDto dto)
    {
        return AddAsync(dto.Id, dto);
    }
}
