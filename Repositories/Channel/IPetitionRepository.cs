using IsiGatewayProcess.DTOs.Channel;

namespace IsiGatewayProcess.Repositories;

public interface IPetitionRepository
{
    Task<PetitionDto?> GetAsync(Guid id);
    Task<IReadOnlyList<PetitionDto>> ListAsync(int skip, int take);
    Task<int> CountAsync();
    Task<PetitionDto> CreateAsync(PetitionDto dto);
    Task<bool> UpdateAsync(Guid id, PetitionDto dto);
    Task<bool> DeleteAsync(Guid id);
}
