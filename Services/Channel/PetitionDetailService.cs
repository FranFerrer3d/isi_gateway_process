using IsiGatewayProcess.DTOs.Channel;
using IsiGatewayProcess.DTOs.Common;
using IsiGatewayProcess.DTOs.Channel.Requests;
using IsiGatewayProcess.Repositories;
using IsiGatewayProcess.Services.Common;

namespace IsiGatewayProcess.Services;

public class PetitionDetailService : IPetitionDetailService
{
    private readonly IPetitionDetailRepository _repository;

    public PetitionDetailService(IPetitionDetailRepository repository)
    {
        _repository = repository;
    }

    public async Task<PetitionDetailDto?> GetAsync(Guid id)
    {
        return await _repository.GetAsync(id);
    }

    public async Task<PagedResult<PetitionDetailDto>> ListAsync(int page, int pageSize)
    {
        var (normalizedPage, normalizedPageSize) = PagingHelper.Normalize(page, pageSize);
        var skip = (normalizedPage - 1) * normalizedPageSize;
        var items = await _repository.ListAsync(skip, normalizedPageSize);
        var total = await _repository.CountAsync();
        return new PagedResult<PetitionDetailDto>(items, normalizedPage, normalizedPageSize, total);
    }

    public async Task<PetitionDetailDto> CreateAsync(CreatePetitionDetailRequest request)
    {
        var id = Guid.NewGuid();
        var dto = new PetitionDetailDto
        {
            Id = id,
            PetitionId = request.PetitionId,
            ItemId = request.ItemId,
            Quantity = request.Quantity,
            Amount = request.Amount,
        };
        return await _repository.CreateAsync(dto);
    }

    public async Task<PetitionDetailDto?> UpdateAsync(Guid id, UpdatePetitionDetailRequest request)
    {
        var existing = await _repository.GetAsync(id);
        if (existing is null)
        {
            return null;
        }
        var dto = new PetitionDetailDto
        {
            Id = id,
            PetitionId = request.PetitionId,
            ItemId = request.ItemId,
            Quantity = request.Quantity,
            Amount = request.Amount,
        };
        var updated = await _repository.UpdateAsync(id, dto);
        return updated ? dto : null;
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        return await _repository.DeleteAsync(id);
    }
}
