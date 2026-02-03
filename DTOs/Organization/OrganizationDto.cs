namespace IsiGatewayProcess.DTOs.Organization;

public record class OrganizationDto
{
    public Guid Id { get; init; }
    public string Name { get; init; } = default!;
    public string? Description { get; init; }
    public Guid OrganizationTypeId { get; init; }
    public Guid CompanyId { get; init; }
    public int MaxPurchasedUsers { get; init; }
    public string? Address { get; init; }
    public string? City { get; init; }
    public string? Region { get; init; }
    public string? Country { get; init; }
    public string Email { get; init; } = default!;
    public string? PhoneNumber { get; init; }
    public DateTimeOffset RegistrationDate { get; init; }
    public DateTimeOffset? DeregistrationDate { get; init; }
}
