using ThingSpeak.Models;

namespace ThingSpeak.Services;

public interface IClienteMonitor
{
    Task<CanalResponse> SendAsync(string url, CanalRequest request, CancellationToken cancellationToken);
}
