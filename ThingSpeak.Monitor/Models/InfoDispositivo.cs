namespace ThingSpeak.Monitor.Models;

public class InfoDispositivo
{
    public string Id { get; set; } = string.Empty;
    public string Nombre { get; set; } = string.Empty;
    public string Ubicacion { get; set; } = string.Empty;
    public DateTime UltimaLectura { get; set; }
}
