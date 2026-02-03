using IsiGatewayProcess.DTOs.Audit;
using IsiGatewayProcess.DTOs.Common;
using IsiGatewayProcess.DTOs.Audit.Requests;

namespace IsiGatewayProcess.Services;

public interface IAuditService
{
    Task<AuditDto?> GetAsync(Guid id);
    Task<PagedResult<AuditDto>> ListAsync(int page, int pageSize);
    Task<AuditDto> CreateAsync(CreateAuditRequest request);
    Task<AuditDto?> UpdateAsync(Guid id, UpdateAuditRequest request);
    Task<bool> DeleteAsync(Guid id);
}
