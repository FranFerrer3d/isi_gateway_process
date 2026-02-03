using IsiGatewayProcess.DTOs.Channel;

namespace IsiGatewayProcess.Repositories;

public interface IPetitionStatusRepository
{
    Task<PetitionStatusDto?> GetAsync(Guid id);
    Task<IReadOnlyList<PetitionStatusDto>> ListAsync(int skip, int take);
    Task<int> CountAsync();
    Task<PetitionStatusDto> CreateAsync(PetitionStatusDto dto);
    Task<bool> UpdateAsync(Guid id, PetitionStatusDto dto);
    Task<bool> DeleteAsync(Guid id);
}
