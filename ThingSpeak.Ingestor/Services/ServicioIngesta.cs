using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using ThingSpeak.Ingestor.Models;
using ThingSpeak.Shared.Services;

namespace ThingSpeak.Ingestor.Services;

/// <summary>
/// Clase que representa el servicio de ingesta.
/// </summary>
/// <param name="settings">
/// Configuración de la aplicación.
/// </param>
public sealed class ServicioIngesta(
    IOptions<IngestaConfig> settings,
    ISimuladorLectura simulador,
    IClienteIngesta cliente,
    ILogger<ServicioIngesta> logger) : IServicioIngesta
{
    private readonly IngestaConfig _config = settings.Value;

    /// <summary>
    /// Envía los datos de los dispositivos a la URL de ingesta configurada.
    /// </summary>
    /// <param name="cancellationToken"></param>
    public async Task EjecutarAsync(CancellationToken cancellationToken)
    {
        while (!cancellationToken.IsCancellationRequested)
        {
            logger.LogInformation("Ejecutando ingesta de datos...");
            await EnviarDatosAsync(cancellationToken);
        }
    }

    private async Task EnviarDatosAsync(CancellationToken cancellationToken)
    {
        var dispositivos = _config.Dispositivos;
        foreach (var dispositivo in dispositivos)
        {
            var lectura = simulador.SimularLectura(dispositivo);
            await cliente.EnviarAsync(_config.UrlIngesta, lectura, cancellationToken);
            await Task.Delay(TimeSpan.FromSeconds(_config.IntervaloEnvio), cancellationToken);
        }
    }
}
