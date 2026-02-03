using IsiGatewayProcess.DTOs.Channel;

namespace IsiGatewayProcess.Repositories;

public interface IPetitionDetailRepository
{
    Task<PetitionDetailDto?> GetAsync(Guid id);
    Task<IReadOnlyList<PetitionDetailDto>> ListAsync(int skip, int take);
    Task<int> CountAsync();
    Task<PetitionDetailDto> CreateAsync(PetitionDetailDto dto);
    Task<bool> UpdateAsync(Guid id, PetitionDetailDto dto);
    Task<bool> DeleteAsync(Guid id);
}
