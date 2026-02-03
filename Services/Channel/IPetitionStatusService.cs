using IsiGatewayProcess.DTOs.Channel;
using IsiGatewayProcess.DTOs.Common;
using IsiGatewayProcess.DTOs.Channel.Requests;

namespace IsiGatewayProcess.Services;

public interface IPetitionStatusService
{
    Task<PetitionStatusDto?> GetAsync(Guid id);
    Task<PagedResult<PetitionStatusDto>> ListAsync(int page, int pageSize);
    Task<PetitionStatusDto> CreateAsync(CreatePetitionStatusRequest request);
    Task<PetitionStatusDto?> UpdateAsync(Guid id, UpdatePetitionStatusRequest request);
    Task<bool> DeleteAsync(Guid id);
}
