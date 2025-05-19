using ThingSpeak.Shared.Models;

namespace ThingSpeak.Ingestor.Services;

public class SimuladorLectura : ISimuladorLectura
{
    private readonly Random _random = new(DateTime.Now.Millisecond);

    public Lectura SimularLectura(Dispositivo dispositivo)
    {
        var fechaHora = DateTime.Now;
        var estado = (Estado)_random.Next(0, 2); // Simula un estado aleatorio
        var consumo = estado == Estado.Encendido ? _random.Next(10, 30) * 10 : 0; // Simula un consumo aleatorio
        return new Lectura
        {
            IdDispositivo = dispositivo.Id,
            FechaHora = fechaHora,
            Estado = estado.ToString(),
            Consumo = consumo,
            Nombre = dispositivo.Nombre,
            Ubicacion = dispositivo.Ubicacion
        };
    }
}
