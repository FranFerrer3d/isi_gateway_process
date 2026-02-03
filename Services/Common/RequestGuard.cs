namespace IsiGatewayProcess.Services.Common;

public static class RequestGuard
{
    public static void EnsureRequiredString(string? value, string fieldName)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            throw new ArgumentException($"{fieldName} is required.", fieldName);
        }
    }
}
