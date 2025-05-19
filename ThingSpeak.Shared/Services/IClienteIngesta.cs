using ThingSpeak.Shared.Models;

namespace ThingSpeak.Shared.Services;

public interface IClienteIngesta
{
    Task EnviarAsync(string urlIngesta, Lectura datos, CancellationToken cancellationToken);
}
