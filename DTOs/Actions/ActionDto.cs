using IsiGatewayProcess.DTOs.Common;

namespace IsiGatewayProcess.DTOs.Actions;

public record class ActionDto : EntityDto
{
    public string Code { get; init; } = default!;
    public string Name { get; init; } = default!;
    public string? Description { get; init; }
}
