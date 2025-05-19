using Newtonsoft.Json;

namespace ThingSpeak.Shared.Models;

/// <summary>
/// Clase que representa la lectura de un dispositivo IoT.
/// </summary>
public class Lectura
{
    /// <summary>
    /// Identificador único del dispositivo IoT.
    /// </summary>
    [JsonProperty("field1")]
    public required string IdDispositivo { get; set; }

    /// <summary>
    /// Fecha y hora de la medición.
    /// </summary>
    [JsonProperty("field2")]
    public DateTime FechaHora { get; set; }

    /// <summary>
    /// Consumo eléctrico medido por el dispositivo IoT.
    /// </summary>
    [JsonProperty("field3")]
    public double Consumo { get; set; }

    /// <summary>
    /// Estado del equipo conectado al dispositivo.
    /// </summary>
    [JsonProperty("field4")]
    public required string Estado { get; set; }

    /// <summary>
    /// Nombre del equipo conectado al dispositivo IoT.
    /// </summary>
    [JsonProperty("field5")]
    public required string Nombre { get; set; }

    /// <summary>
    /// Ubicación donde se ha instalado el dispositivo IoT.
    /// </summary>
    [JsonProperty("field6")]
    public required string Ubicacion { get; set; }

    /// <summary>
    /// Identificador único de la entrada de datos en ThingSpeak.
    /// </summary>
    [JsonProperty("entry_id")]
    public int IdEntrada { get; set; }

    /// <summary>
    /// Fecha y hora de creación de la entrada de datos en ThingSpeak.
    /// </summary>
    [JsonProperty("created_at")]
    public DateTime FechCreacion { get; set; }
}
