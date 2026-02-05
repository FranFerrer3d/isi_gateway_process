using IsiGatewayProcess.Services.Security;
using Microsoft.Net.Http.Headers;

namespace IsiGatewayProcess.Middlewares;

public sealed class JwtAuthMiddleware
{
    private readonly RequestDelegate _next;

    public JwtAuthMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context, IJwtValidator validator)
    {
        if (IsAnonymousPath(context.Request.Path))
        {
            await _next(context);
            return;
        }

        //if (context.Request.Headers.TryGetValue(HeaderNames.Authorization, out var headerValue))
        //{
        //    if (!TryGetBearerToken(headerValue.ToString(), out var token))
        //    {
        //        await WriteUnauthorizedAsync(context, "Invalid Authorization header.");
        //        return;
        //    }

        //    var principal = await validator.ValidateAsync(token, context.RequestAborted);
        //    if (principal is null)
        //    {
        //        await WriteUnauthorizedAsync(context, "Invalid or expired token.");
        //        return;
        //    }

        //    context.User = principal;
        //}

        await _next(context);
    }

    private static bool IsAnonymousPath(PathString path)
    {
        return path.Equals("/api/v1/auth/login", StringComparison.OrdinalIgnoreCase)
            || path.Equals("/api/v1/auth/refresh", StringComparison.OrdinalIgnoreCase);
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

    private static async Task WriteUnauthorizedAsync(HttpContext context, string message)
    {
        context.Response.StatusCode = StatusCodes.Status401Unauthorized;
        context.Response.ContentType = "application/json";
        await context.Response.WriteAsJsonAsync(new
        {
            error = "unauthorized",
            message,
        }, context.RequestAborted);
    }
}
