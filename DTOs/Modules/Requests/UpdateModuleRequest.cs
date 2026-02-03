namespace IsiGatewayProcess.DTOs.Modules.Requests;

public record class UpdateModuleRequest
{
    public string Code { get; init; } = default!;
    public string Name { get; init; } = default!;
    public string? Description { get; init; }
}
