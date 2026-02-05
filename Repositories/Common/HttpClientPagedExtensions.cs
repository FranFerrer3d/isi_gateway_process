using System.Net.Http.Json;
using IsiGatewayProcess.DTOs.Common;

namespace IsiGatewayProcess.Repositories.Common;

public static class HttpClientPagedExtensions
{
    public static async Task<PagedResult<T>> GetPagedAsync<T>(this HttpClient httpClient, string endpoint, CancellationToken cancellationToken = default)
    {
        using var response = await httpClient.GetAsync(endpoint, cancellationToken);
        await EnsureSuccessStatusCodeAsync(response, endpoint, cancellationToken);

        var result = await response.Content.ReadFromJsonAsync<PagedResult<T>>(cancellationToken: cancellationToken);
        if (result is null)
        {
            throw new InvalidOperationException($"Response from '{endpoint}' was empty.");
        }

        return result;
    }

    public static async Task<IReadOnlyList<T>> GetPagedItemsAsync<T>(this HttpClient httpClient, string endpoint, CancellationToken cancellationToken = default)
    {
        var result = await httpClient.GetPagedAsync<T>(endpoint, cancellationToken);
        return result.Items;
    }

    private static async Task EnsureSuccessStatusCodeAsync(HttpResponseMessage response, string endpoint, CancellationToken cancellationToken)
    {
        if (response.IsSuccessStatusCode)
        {
            return;
        }

        var body = await response.Content.ReadAsStringAsync(cancellationToken);
        throw new HttpRequestException(
            $"Request to '{endpoint}' failed with status code {(int)response.StatusCode} ({response.StatusCode}). Body: {body}");
    }
}
