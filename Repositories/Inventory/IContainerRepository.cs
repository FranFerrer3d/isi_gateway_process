using IsiGatewayProcess.DTOs.Inventory;

namespace IsiGatewayProcess.Repositories;

public interface IContainerRepository
{
    Task<ContainerDto?> GetAsync(Guid id);
    Task<IReadOnlyList<ContainerDto>> ListAsync(int skip, int take);
    Task<int> CountAsync();
    Task<ContainerDto> CreateAsync(ContainerDto dto);
    Task<bool> UpdateAsync(Guid id, ContainerDto dto);
    Task<bool> DeleteAsync(Guid id);
}
