namespace IsiGatewayProcess.DTOs.Permissions;

public record class PermissionDto
{
    public string ModuleCode { get; init; } = default!;
    public string ActionCode { get; init; } = default!;
}
