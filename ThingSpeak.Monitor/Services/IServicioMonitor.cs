using ThingSpeak.Monitor.Models;
using ThingSpeak.Shared.Models;

namespace ThingSpeak.Monitor.Services;

public interface IServicioMonitor
{
    Task<List<InfoDispositivo>> ObtenerDispositivosAsync();
    Task<List<Lectura>> ListarLecturas();
}
