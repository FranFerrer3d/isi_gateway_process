namespace IsiGatewayProcess.DTOs.Actions.Requests;

public record class UpdateActionRequest
{
    public string Code { get; init; } = default!;
    public string Name { get; init; } = default!;
    public string? Description { get; init; }
}
