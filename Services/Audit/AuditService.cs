using IsiGatewayProcess.DTOs.Audit;
using IsiGatewayProcess.DTOs.Common;
using IsiGatewayProcess.DTOs.Audit.Requests;
using IsiGatewayProcess.Repositories;
using IsiGatewayProcess.Services.Common;

namespace IsiGatewayProcess.Services;

public class AuditService : IAuditService
{
    private readonly IAuditRepository _repository;

    public AuditService(IAuditRepository repository)
    {
        _repository = repository;
    }

    public async Task<AuditDto?> GetAsync(Guid id)
    {
        return await _repository.GetAsync(id);
    }

    public async Task<PagedResult<AuditDto>> ListAsync(int page, int pageSize)
    {
        var (normalizedPage, normalizedPageSize) = PagingHelper.Normalize(page, pageSize);
        var skip = (normalizedPage - 1) * normalizedPageSize;
        var items = await _repository.ListAsync(skip, normalizedPageSize);
        var total = await _repository.CountAsync();
        return new PagedResult<AuditDto>(items, normalizedPage, normalizedPageSize, total);
    }

    public async Task<AuditDto> CreateAsync(CreateAuditRequest request)
    {
        var id = Guid.NewGuid();
        var dto = new AuditDto
        {
            Id = id,
            ModuleId = request.ModuleId,
            ActionId = request.ActionId,
            UserId = request.UserId,
            OperationTime = request.OperationTime,
            AffectedElementId = request.AffectedElementId,
            AffectedElementInformation = request.AffectedElementInformation,
        };
        return await _repository.CreateAsync(dto);
    }

    public async Task<AuditDto?> UpdateAsync(Guid id, UpdateAuditRequest request)
    {
        var existing = await _repository.GetAsync(id);
        if (existing is null)
        {
            return null;
        }
        var dto = new AuditDto
        {
            Id = id,
            ModuleId = request.ModuleId,
            ActionId = request.ActionId,
            UserId = request.UserId,
            OperationTime = request.OperationTime,
            AffectedElementId = request.AffectedElementId,
            AffectedElementInformation = request.AffectedElementInformation,
        };
        var updated = await _repository.UpdateAsync(id, dto);
        return updated ? dto : null;
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        return await _repository.DeleteAsync(id);
    }
}
