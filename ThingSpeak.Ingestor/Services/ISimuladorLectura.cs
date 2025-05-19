using ThingSpeak.Shared.Models;

namespace ThingSpeak.Ingestor.Services;

public interface ISimuladorLectura
{
    Lectura SimularLectura(Dispositivo dispositivo);
}
