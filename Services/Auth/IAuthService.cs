using IsiGatewayProcess.DTOs.Auth;

namespace IsiGatewayProcess.Services;

public interface IAuthService
{
    Task<LoginResponse?> LoginAsync(LoginRequest request);
    Task<LoginResponse?> RefreshAsync(RefreshRequest request);
    Task<bool> RevokeAsync(RevokeRequest request);
}
