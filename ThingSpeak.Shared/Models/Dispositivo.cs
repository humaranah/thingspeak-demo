namespace ThingSpeak.Shared.Models;

/// <summary>
/// Clase que representa un dispositivo IoT.
/// </summary>
public class Dispositivo
{
    /// <summary>
    /// Identificador único del dispositivo IoT.
    /// </summary>
    public required string Id { get; set; }

    /// <summary>
    /// Nombre del equipo conectado al dispositivo IoT.
    /// </summary>
    public required string Nombre { get; set; }

    /// <summary>
    /// Ubicación donde se ha instalado el dispositivo IoT.
    /// </summary>
    public required string Ubicacion { get; set; }
}
