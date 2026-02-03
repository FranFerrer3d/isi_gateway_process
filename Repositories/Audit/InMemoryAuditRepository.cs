using IsiGatewayProcess.DTOs.Audit;
using IsiGatewayProcess.Repositories.Common;

namespace IsiGatewayProcess.Repositories;

public class InMemoryAuditRepository : InMemoryRepositoryBase<AuditDto>, IAuditRepository
{
    public Task<AuditDto> CreateAsync(AuditDto dto)
    {
        return AddAsync(dto.Id, dto);
    }
}
