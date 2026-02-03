using IsiGatewayProcess.DTOs.Common;

namespace IsiGatewayProcess.DTOs.Modules;

public record class ModuleDto : EntityDto
{
    public string Code { get; init; } = default!;
    public string Name { get; init; } = default!;
    public string? Description { get; init; }
}
