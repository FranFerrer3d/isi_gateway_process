using System.Security.Claims;

namespace IsiGatewayProcess.Services.Security;

public interface IJwtValidator
{
    Task<ClaimsPrincipal?> ValidateAsync(string jwt, CancellationToken ct);
}
