using Microsoft.Extensions.Options;
using ThingSpeak.Monitor.Models;
using ThingSpeak.Shared.Models;

namespace ThingSpeak.Monitor.Services;

public class ServicioMonitor(
    IOptions<MonitorConfig> options,
    IClienteMonitor cliente) : IServicioMonitor
{
    private readonly MonitorConfig _config = options.Value;

    public async Task<List<InfoDispositivo>> ObtenerDispositivosAsync()
    {
        var clientResponse = await cliente.ObtenerMedicionesAsync(_config.UrlMonitor);
        var validos = clientResponse.Mediciones
            .Where(x => x.IdDispositivo != null)
            .ToList();
        return [.. validos
            .GroupBy(x => x.IdDispositivo)
            .Select(x => new
            {
                x.Key,
                UltimaLectura = x.First()
            })
            .Select(x => new InfoDispositivo
            {
                Id = x.Key,
                Nombre = x.UltimaLectura.Nombre,
                Ubicacion = x.UltimaLectura.Ubicacion,
                UltimaLectura = x.UltimaLectura.FechaHora
            })];
    }

    public async Task<List<Lectura>> ListarLecturas()
    {
        var clientResponse = await cliente.ObtenerMedicionesAsync(_config.UrlMonitor);
        return [.. clientResponse.Mediciones
            .Where(x => x.IdDispositivo != null)
            .Select(x => new Lectura
            {
                IdDispositivo = x.IdDispositivo,
                FechaHora = x.FechaHora,
                Consumo = x.Consumo,
                Estado = x.Estado,
                Nombre = x.Nombre,
                Ubicacion = x.Ubicacion,
                IdEntrada = x.IdEntrada,
                FechCreacion = x.FechCreacion
            })
            .OrderByDescending(x => x.FechaHora)];
    }
}
