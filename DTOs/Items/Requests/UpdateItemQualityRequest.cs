namespace IsiGatewayProcess.DTOs.Items.Requests;

public record class UpdateItemQualityRequest
{
    public string Name { get; init; } = default!;
    public string? Description { get; init; }
}
