using IsiGatewayProcess.DTOs.Channel;
using IsiGatewayProcess.DTOs.Common;
using IsiGatewayProcess.DTOs.Channel.Requests;
using IsiGatewayProcess.Repositories;
using IsiGatewayProcess.Services.Common;

namespace IsiGatewayProcess.Services;

public class PetitionService : IPetitionService
{
    private readonly IPetitionRepository _repository;

    public PetitionService(IPetitionRepository repository)
    {
        _repository = repository;
    }

    public async Task<PetitionDto?> GetAsync(Guid id)
    {
        return await _repository.GetAsync(id);
    }

    public async Task<PagedResult<PetitionDto>> ListAsync(int page, int pageSize)
    {
        var (normalizedPage, normalizedPageSize) = PagingHelper.Normalize(page, pageSize);
        var skip = (normalizedPage - 1) * normalizedPageSize;
        var items = await _repository.ListAsync(skip, normalizedPageSize);
        var total = await _repository.CountAsync();
        return new PagedResult<PetitionDto>(items, normalizedPage, normalizedPageSize, total);
    }

    public async Task<PetitionDto> CreateAsync(CreatePetitionRequest request)
    {
        var id = Guid.NewGuid();
        var registrationDate = DateTimeOffset.UtcNow;
        var dto = new PetitionDto
        {
            Id = id,
            PetitionaryUserId = request.PetitionaryUserId,
            PetitionaryOrganizationId = request.PetitionaryOrganizationId,
            ReceiverOrganizationId = request.ReceiverOrganizationId,
            StatusId = request.StatusId,
            EstimatedTimeArrival = request.EstimatedTimeArrival,
            RegistrationDate = registrationDate,
            DeregistrationDate = null,
        };
        return await _repository.CreateAsync(dto);
    }

    public async Task<PetitionDto?> UpdateAsync(Guid id, UpdatePetitionRequest request)
    {
        var existing = await _repository.GetAsync(id);
        if (existing is null)
        {
            return null;
        }
        var dto = new PetitionDto
        {
            Id = id,
            PetitionaryUserId = request.PetitionaryUserId,
            PetitionaryOrganizationId = request.PetitionaryOrganizationId,
            ReceiverOrganizationId = request.ReceiverOrganizationId,
            StatusId = request.StatusId,
            EstimatedTimeArrival = request.EstimatedTimeArrival,
            RegistrationDate = existing.RegistrationDate,
            DeregistrationDate = request.DeregistrationDate,
        };
        var updated = await _repository.UpdateAsync(id, dto);
        return updated ? dto : null;
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        return await _repository.DeleteAsync(id);
    }
}
