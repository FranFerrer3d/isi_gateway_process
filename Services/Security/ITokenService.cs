using IsiGatewayProcess.DTOs.Users;

namespace IsiGatewayProcess.Services;

public interface ITokenService
{
    (string Token, DateTimeOffset ExpiresAt) GenerateAccessToken(UserDto user);
    RefreshTokenResult GenerateRefreshToken();
    string HashRefreshToken(string refreshToken);
}

public record struct RefreshTokenResult(string Token, string TokenHash, DateTimeOffset ExpiresAt);
