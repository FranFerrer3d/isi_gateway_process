namespace IsiGatewayProcess.DTOs.Common;

public record class RegistrableEntityDto : EntityDto
{
    public DateTimeOffset RegistrationDate { get; init; }
    public DateTimeOffset? DeregistrationDate { get; init; }
}
