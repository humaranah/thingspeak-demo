using ThingSpeak.Shared.Models;

namespace ThingSpeak.Ingestor.Models;

/// <summary>
/// Clase que representa la configuración de la aplicación.
/// </summary>
public class IngestaConfig
{
    /// <summary>
    /// URL del canal de ThingSpeak donde se enviarán los datos.
    /// </summary>
    public string UrlIngesta { get; set; } = string.Empty;

    /// <summary>
    /// Intervalo de lectura en segundos.
    /// </summary>
    public int IntervaloEnvio { get; set; }

    /// <summary>
    /// Lista de dispositivos IoT que se van a leer y enviar datos.
    /// </summary>
    public List<Dispositivo> Dispositivos { get; set; } = [];
}
