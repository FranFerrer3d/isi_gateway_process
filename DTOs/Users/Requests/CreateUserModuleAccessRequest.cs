namespace IsiGatewayProcess.DTOs.Users.Requests;

public record class CreateUserModuleAccessRequest
{
    public Guid PurchasedModuleId { get; init; }
    public Guid UserId { get; init; }
    public Guid ActionId { get; init; }
}
