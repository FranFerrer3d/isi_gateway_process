using IsiGatewayProcess.DTOs.Channel;
using IsiGatewayProcess.DTOs.Common;
using IsiGatewayProcess.DTOs.Channel.Requests;
using IsiGatewayProcess.Repositories;
using IsiGatewayProcess.Services.Common;

namespace IsiGatewayProcess.Services;

public class PetitionStatusService : IPetitionStatusService
{
    private readonly IPetitionStatusRepository _repository;

    public PetitionStatusService(IPetitionStatusRepository repository)
    {
        _repository = repository;
    }

    public async Task<PetitionStatusDto?> GetAsync(Guid id)
    {
        return await _repository.GetAsync(id);
    }

    public async Task<PagedResult<PetitionStatusDto>> ListAsync(int page, int pageSize)
    {
        var (normalizedPage, normalizedPageSize) = PagingHelper.Normalize(page, pageSize);
        var skip = (normalizedPage - 1) * normalizedPageSize;
        var items = await _repository.ListAsync(skip, normalizedPageSize);
        var total = await _repository.CountAsync();
        return new PagedResult<PetitionStatusDto>(items, normalizedPage, normalizedPageSize, total);
    }

    public async Task<PetitionStatusDto> CreateAsync(CreatePetitionStatusRequest request)
    {
        RequestGuard.EnsureRequiredString(request.Code, nameof(request.Code));
        var id = Guid.NewGuid();
        var dto = new PetitionStatusDto
        {
            Id = id,
            Code = request.Code,
            Description = request.Description,
        };
        return await _repository.CreateAsync(dto);
    }

    public async Task<PetitionStatusDto?> UpdateAsync(Guid id, UpdatePetitionStatusRequest request)
    {
        var existing = await _repository.GetAsync(id);
        if (existing is null)
        {
            return null;
        }
        RequestGuard.EnsureRequiredString(request.Code, nameof(request.Code));
        var dto = new PetitionStatusDto
        {
            Id = id,
            Code = request.Code,
            Description = request.Description,
        };
        var updated = await _repository.UpdateAsync(id, dto);
        return updated ? dto : null;
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        return await _repository.DeleteAsync(id);
    }
}
