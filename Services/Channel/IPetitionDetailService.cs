using IsiGatewayProcess.DTOs.Channel;
using IsiGatewayProcess.DTOs.Common;
using IsiGatewayProcess.DTOs.Channel.Requests;

namespace IsiGatewayProcess.Services;

public interface IPetitionDetailService
{
    Task<PetitionDetailDto?> GetAsync(Guid id);
    Task<PagedResult<PetitionDetailDto>> ListAsync(int page, int pageSize);
    Task<PetitionDetailDto> CreateAsync(CreatePetitionDetailRequest request);
    Task<PetitionDetailDto?> UpdateAsync(Guid id, UpdatePetitionDetailRequest request);
    Task<bool> DeleteAsync(Guid id);
}
