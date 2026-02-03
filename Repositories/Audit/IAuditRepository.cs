using IsiGatewayProcess.DTOs.Audit;

namespace IsiGatewayProcess.Repositories;

public interface IAuditRepository
{
    Task<AuditDto?> GetAsync(Guid id);
    Task<IReadOnlyList<AuditDto>> ListAsync(int skip, int take);
    Task<int> CountAsync();
    Task<AuditDto> CreateAsync(AuditDto dto);
    Task<bool> UpdateAsync(Guid id, AuditDto dto);
    Task<bool> DeleteAsync(Guid id);
}
