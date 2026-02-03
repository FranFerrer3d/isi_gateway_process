using IsiGatewayProcess.DTOs.Users;
using IsiGatewayProcess.DTOs.Common;
using IsiGatewayProcess.DTOs.Users.Requests;
using IsiGatewayProcess.Repositories;
using IsiGatewayProcess.Services.Common;

namespace IsiGatewayProcess.Services;

public class UserModuleAccessService : IUserModuleAccessService
{
    private readonly IUserModuleAccessRepository _repository;

    public UserModuleAccessService(IUserModuleAccessRepository repository)
    {
        _repository = repository;
    }

    public async Task<UserModuleAccessDto?> GetAsync(Guid id)
    {
        return await _repository.GetAsync(id);
    }

    public async Task<PagedResult<UserModuleAccessDto>> ListAsync(int page, int pageSize)
    {
        var (normalizedPage, normalizedPageSize) = PagingHelper.Normalize(page, pageSize);
        var skip = (normalizedPage - 1) * normalizedPageSize;
        var items = await _repository.ListAsync(skip, normalizedPageSize);
        var total = await _repository.CountAsync();
        return new PagedResult<UserModuleAccessDto>(items, normalizedPage, normalizedPageSize, total);
    }

    public async Task<UserModuleAccessDto> CreateAsync(CreateUserModuleAccessRequest request)
    {
        var id = Guid.NewGuid();
        var registrationDate = DateTimeOffset.UtcNow;
        var dto = new UserModuleAccessDto
        {
            Id = id,
            PurchasedModuleId = request.PurchasedModuleId,
            UserId = request.UserId,
            ActionId = request.ActionId,
            RegistrationDate = registrationDate,
            DeregistrationDate = null,
        };
        return await _repository.CreateAsync(dto);
    }

    public async Task<UserModuleAccessDto?> UpdateAsync(Guid id, UpdateUserModuleAccessRequest request)
    {
        var existing = await _repository.GetAsync(id);
        if (existing is null)
        {
            return null;
        }
        var dto = new UserModuleAccessDto
        {
            Id = id,
            PurchasedModuleId = request.PurchasedModuleId,
            UserId = request.UserId,
            ActionId = request.ActionId,
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
