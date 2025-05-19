using Newtonsoft.Json;
using ThingSpeak.Monitor.Models;

namespace ThingSpeak.Monitor.Services;

public sealed class ClienteMonitor : IClienteMonitor, IDisposable
{
    private readonly HttpClient _httpClient = new();

    private static readonly JsonSerializerSettings _jsonSettings = new()
    {
        Error = (s, a) => a.ErrorContext.Handled = true
    };

    public async Task<CanalResponse> ObtenerMedicionesAsync(string url, CancellationToken cancellationToken = default)
    {
        var request = new HttpRequestMessage(HttpMethod.Get, url);
        var response = await _httpClient.SendAsync(request, cancellationToken);
        if (!response.IsSuccessStatusCode)
        {
            throw new HttpRequestException($"Error al obtener datos de ThingSpeak: {response.StatusCode}");
        }
        var json = await response.Content.ReadAsStringAsync(cancellationToken);
        return JsonConvert.DeserializeObject<CanalResponse>(json, _jsonSettings) ??
            throw new JsonSerializationException("Error al deserializar la respuesta JSON.");
    }

    public async Task<CanalResponse> ObtenerMedicionesAsync(string url, int ultimos, CancellationToken cancellationToken = default)
    {
        var request = new HttpRequestMessage(HttpMethod.Get, $"{url}?results={ultimos}");
        var response = await _httpClient.SendAsync(request, cancellationToken);
        if (!response.IsSuccessStatusCode)
        {
            throw new HttpRequestException($"Error al obtener datos de ThingSpeak: {response.StatusCode}");
        }
        var json = await response.Content.ReadAsStringAsync(cancellationToken);
        return JsonConvert.DeserializeObject<CanalResponse>(json, _jsonSettings) ??
            throw new JsonSerializationException("Error al deserializar la respuesta JSON.");
    }

    public void Dispose()
    {
        _httpClient.Dispose();
    }
}
