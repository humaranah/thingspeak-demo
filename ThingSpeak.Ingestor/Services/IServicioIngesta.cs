namespace ThingSpeak.Ingestor.Services;

public interface IServicioIngesta
{
    Task EjecutarAsync(CancellationToken cancellationToken);
}
