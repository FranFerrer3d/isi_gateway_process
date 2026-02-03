using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using IsiGatewayProcess.Options;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace IsiGatewayProcess.Services.Security;

public sealed class JwtValidator : IJwtValidator
{
    private readonly TokenValidationParameters _validationParameters;

    public JwtValidator(IOptions<JwtOptions> options)
    {
        var jwtOptions = options.Value;
        _validationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ClockSkew = TimeSpan.FromSeconds(30),
            ValidIssuer = jwtOptions.Issuer,
            ValidAudience = jwtOptions.Audience,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtOptions.SigningKey)),
        };
    }

    public Task<ClaimsPrincipal?> ValidateAsync(string jwt, CancellationToken ct)
    {
        if (string.IsNullOrWhiteSpace(jwt))
        {
            return Task.FromResult<ClaimsPrincipal?>(null);
        }

        try
        {
            var handler = new JwtSecurityTokenHandler();
            var principal = handler.ValidateToken(jwt, _validationParameters, out _);
            return Task.FromResult<ClaimsPrincipal?>(principal);
        }
        catch
        {
            return Task.FromResult<ClaimsPrincipal?>(null);
        }
    }
}
