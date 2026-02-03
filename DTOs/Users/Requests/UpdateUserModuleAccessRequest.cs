namespace IsiGatewayProcess.DTOs.Users.Requests;

public record class UpdateUserModuleAccessRequest
{
    public Guid PurchasedModuleId { get; init; }
    public Guid UserId { get; init; }
    public Guid ActionId { get; init; }
    public DateTimeOffset? DeregistrationDate { get; init; }
}
