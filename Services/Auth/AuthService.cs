using IsiGatewayProcess.DTOs.Auth;
using IsiGatewayProcess.Repositories;
using IsiGatewayProcess.Services.Common;

namespace IsiGatewayProcess.Services;

public class AuthService : IAuthService
{
    private readonly IUserRepository _userRepository;
    private readonly IUserCredentialRepository _credentialRepository;
    private readonly IRefreshTokenRepository _refreshTokenRepository;
    private readonly IPasswordHasher _passwordHasher;
    private readonly ITokenService _tokenService;

    public AuthService(
        IUserRepository userRepository,
        IUserCredentialRepository credentialRepository,
        IRefreshTokenRepository refreshTokenRepository,
        IPasswordHasher passwordHasher,
        ITokenService tokenService)
    {
        _userRepository = userRepository;
        _credentialRepository = credentialRepository;
        _refreshTokenRepository = refreshTokenRepository;
        _passwordHasher = passwordHasher;
        _tokenService = tokenService;
    }

    public async Task<LoginResponse?> LoginAsync(LoginRequest request)
    {
        RequestGuard.EnsureRequiredString(request.UserNameOrEmail, nameof(request.UserNameOrEmail));
        RequestGuard.EnsureRequiredString(request.Password, nameof(request.Password));

        var user = await _userRepository.FindByUserNameOrEmailAsync(request.UserNameOrEmail);
        if (user is null)
        {
            return null;
        }

        var passwordHash = await _credentialRepository.GetPasswordHashAsync(user.Id);
        if (string.IsNullOrWhiteSpace(passwordHash) || !_passwordHasher.Verify(request.Password, passwordHash))
        {
            return null;
        }

        return await CreateLoginResponseAsync(user);
    }

    public async Task<LoginResponse?> RefreshAsync(RefreshRequest request)
    {
        RequestGuard.EnsureRequiredString(request.RefreshToken, nameof(request.RefreshToken));
        var tokenHash = _tokenService.HashRefreshToken(request.RefreshToken);
        var now = DateTimeOffset.UtcNow;
        var record = await _refreshTokenRepository.FindValidAsync(tokenHash, now);
        if (record is null)
        {
            return null;
        }

        var user = await _userRepository.GetAsync(record.UserId);
        if (user is null)
        {
            return null;
        }

        var refreshToken = _tokenService.GenerateRefreshToken();
        await _refreshTokenRepository.RevokeAsync(record.Id, now, refreshToken.TokenHash);
        await _refreshTokenRepository.AddAsync(new RefreshTokenRecord
        {
            Id = Guid.NewGuid(),
            UserId = user.Id,
            TokenHash = refreshToken.TokenHash,
            CreatedAt = now,
            ExpiresAt = refreshToken.ExpiresAt,
            RevokedAt = null,
            ReplacedByTokenHash = null,
        });

        var accessToken = _tokenService.GenerateAccessToken(user);
        return new LoginResponse
        {
            AccessToken = accessToken.Token,
            AccessTokenExpiresAt = accessToken.ExpiresAt,
            RefreshToken = refreshToken.Token,
            RefreshTokenExpiresAt = refreshToken.ExpiresAt,
        };
    }

    public async Task<bool> RevokeAsync(RevokeRequest request)
    {
        RequestGuard.EnsureRequiredString(request.RefreshToken, nameof(request.RefreshToken));
        var tokenHash = _tokenService.HashRefreshToken(request.RefreshToken);
        var record = await _refreshTokenRepository.FindByTokenHashAsync(tokenHash);
        if (record is null || record.RevokedAt is not null)
        {
            return false;
        }

        await _refreshTokenRepository.RevokeAsync(record.Id, DateTimeOffset.UtcNow, null);
        return true;
    }

    private async Task<LoginResponse> CreateLoginResponseAsync(DTOs.Users.UserDto user)
    {
        var now = DateTimeOffset.UtcNow;
        var accessToken = _tokenService.GenerateAccessToken(user);
        var refreshToken = _tokenService.GenerateRefreshToken();

        await _refreshTokenRepository.AddAsync(new RefreshTokenRecord
        {
            Id = Guid.NewGuid(),
            UserId = user.Id,
            TokenHash = refreshToken.TokenHash,
            CreatedAt = now,
            ExpiresAt = refreshToken.ExpiresAt,
            RevokedAt = null,
            ReplacedByTokenHash = null,
        });

        return new LoginResponse
        {
            AccessToken = accessToken.Token,
            AccessTokenExpiresAt = accessToken.ExpiresAt,
            RefreshToken = refreshToken.Token,
            RefreshTokenExpiresAt = refreshToken.ExpiresAt,
        };
    }
}
