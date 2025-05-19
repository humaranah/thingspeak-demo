using ThingSpeak.Monitor.Models;

namespace ThingSpeak.Monitor.Services;

public interface IClienteMonitor
{
    /// <summary>
    /// Obtiene todos los datos de mediciones desde ThingSpeak.
    /// </summary>
    /// <param name="url">
    /// URL del canal de ThingSpeak.
    /// </param>
    /// <param name="cancellationToken">
    /// Token de cancelación para la tarea asincrónica.
    /// </param>
    /// <returns>
    /// Un objeto <see cref="CanalResponse"/> que contiene la información del canal y las mediciones.
    /// </returns>
    Task<CanalResponse> ObtenerMedicionesAsync(string url, CancellationToken cancellationToken = default);

    /// <summary>
    /// Obtiene los ultimos datos de mediciones desde ThingSpeak.
    /// </summary>
    /// <param name="url">
    /// URL del canal de ThingSpeak.
    /// </param>
    /// <param name="ultimos">
    /// Número de mediciones a obtener.
    /// </param>
    /// <param name="cancellationToken">
    /// Token de cancelación para la tarea asincrónica.
    /// </param>
    /// <returns>
    /// Un objeto <see cref="CanalResponse"/> que contiene la información del canal y las mediciones.
    /// </returns>
    Task<CanalResponse> ObtenerMedicionesAsync(string url, int ultimos, CancellationToken cancellationToken = default);
}
