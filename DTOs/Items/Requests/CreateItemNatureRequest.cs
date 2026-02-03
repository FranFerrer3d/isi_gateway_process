namespace IsiGatewayProcess.DTOs.Items.Requests;

public record class CreateItemNatureRequest
{
    public string Name { get; init; } = default!;
    public string? Description { get; init; }
}
