using IsiGatewayProcess.DTOs.Users;
using IsiGatewayProcess.DTOs.Common;
using IsiGatewayProcess.DTOs.Users.Requests;
using IsiGatewayProcess.Repositories;
using IsiGatewayProcess.Services.Common;

namespace IsiGatewayProcess.Services;

public class UserRoleService : IUserRoleService
{
    private readonly IUserRoleRepository _repository;

    public UserRoleService(IUserRoleRepository repository)
    {
        _repository = repository;
    }

    public async Task<UserRoleDto?> GetAsync(Guid id)
    {
        return await _repository.GetAsync(id);
    }

    public async Task<PagedResult<UserRoleDto>> ListAsync(int page, int pageSize)
    {
        var (normalizedPage, normalizedPageSize) = PagingHelper.Normalize(page, pageSize);
        var skip = (normalizedPage - 1) * normalizedPageSize;
        var items = await _repository.ListAsync(skip, normalizedPageSize);
        var total = await _repository.CountAsync();
        return new PagedResult<UserRoleDto>(items, normalizedPage, normalizedPageSize, total);
    }

    public async Task<UserRoleDto> CreateAsync(CreateUserRoleRequest request)
    {
        RequestGuard.EnsureRequiredString(request.Code, nameof(request.Code));
        var id = Guid.NewGuid();
        var dto = new UserRoleDto
        {
            Id = id,
            Code = request.Code,
            Description = request.Description,
            OrganizationId = request.OrganizationId,
        };
        return await _repository.CreateAsync(dto);
    }

    public async Task<UserRoleDto?> UpdateAsync(Guid id, UpdateUserRoleRequest request)
    {
        var existing = await _repository.GetAsync(id);
        if (existing is null)
        {
            return null;
        }
        RequestGuard.EnsureRequiredString(request.Code, nameof(request.Code));
        var dto = new UserRoleDto
        {
            Id = id,
            Code = request.Code,
            Description = request.Description,
            OrganizationId = request.OrganizationId,
        };
        var updated = await _repository.UpdateAsync(id, dto);
        return updated ? dto : null;
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        return await _repository.DeleteAsync(id);
    }
}
