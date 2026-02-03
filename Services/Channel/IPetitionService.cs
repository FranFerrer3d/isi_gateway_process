using IsiGatewayProcess.DTOs.Channel;
using IsiGatewayProcess.DTOs.Common;
using IsiGatewayProcess.DTOs.Channel.Requests;

namespace IsiGatewayProcess.Services;

public interface IPetitionService
{
    Task<PetitionDto?> GetAsync(Guid id);
    Task<PagedResult<PetitionDto>> ListAsync(int page, int pageSize);
    Task<PetitionDto> CreateAsync(CreatePetitionRequest request);
    Task<PetitionDto?> UpdateAsync(Guid id, UpdatePetitionRequest request);
    Task<bool> DeleteAsync(Guid id);
}
