namespace IsiGatewayProcess.DTOs.Users;

public record class UserModuleAccessDto
{
    public Guid Id { get; init; }
    public Guid PurchasedModuleId { get; init; }
    public Guid UserId { get; init; }
    public Guid ActionId { get; init; }
    public DateTimeOffset RegistrationDate { get; init; }
    public DateTimeOffset? DeregistrationDate { get; init; }
}
