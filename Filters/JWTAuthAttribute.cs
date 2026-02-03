using IsiGatewayProcess.Services.Security;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Net.Http.Headers;

namespace IsiGatewayProcess.Filters;

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
public sealed class JWTAuthAttribute : Attribute, IAsyncAuthorizationFilter
{
    public async Task OnAuthorizationAsync(AuthorizationFilterContext context)
    {
        if (context.ActionDescriptor.EndpointMetadata.OfType<AllowAnonymousAttribute>().Any())
        {
            return;
        }

        var request = context.HttpContext.Request;
        if (!request.Headers.TryGetValue(HeaderNames.Authorization, out var headerValue))
        {
            context.Result = new UnauthorizedObjectResult(new
            {
                error = "unauthorized",
                message = "Missing Authorization header.",
            });
            return;
        }

        if (!TryGetBearerToken(headerValue.ToString(), out var token))
        {
            context.Result = new UnauthorizedObjectResult(new
            {
                error = "unauthorized",
                message = "Invalid Authorization header.",
            });
            return;
        }

        var validator = context.HttpContext.RequestServices.GetRequiredService<IJwtValidator>();
        var principal = await validator.ValidateAsync(token, context.HttpContext.RequestAborted);
        if (principal is null)
        {
            context.Result = new UnauthorizedObjectResult(new
            {
                error = "unauthorized",
                message = "Invalid or expired token.",
            });
            return;
        }

        context.HttpContext.User = principal;
    }

    private static bool TryGetBearerToken(string headerValue, out string token)
    {
        token = string.Empty;
        if (string.IsNullOrWhiteSpace(headerValue))
        {
            return false;
        }

        const string prefix = "Bearer ";
        if (!headerValue.StartsWith(prefix, StringComparison.OrdinalIgnoreCase))
        {
            return false;
        }

        token = headerValue[prefix.Length..].Trim();
        return !string.IsNullOrWhiteSpace(token);
    }
}
