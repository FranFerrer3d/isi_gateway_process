using IsiGatewayProcess.DTOs.Channel;
using IsiGatewayProcess.Repositories.Common;

namespace IsiGatewayProcess.Repositories;

public class InMemoryPetitionRepository : InMemoryRepositoryBase<PetitionDto>, IPetitionRepository
{
    public Task<PetitionDto> CreateAsync(PetitionDto dto)
    {
        return AddAsync(dto.Id, dto);
    }
}
