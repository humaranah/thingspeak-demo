using Newtonsoft.Json;
using ThingSpeak.Shared.Models;

namespace ThingSpeak.Monitor.Models;

public class CanalResponse
{
    [JsonProperty("channel")]
    public Canal Canal { get; set; } = new();

    [JsonProperty("feeds")]
    public List<Lectura> Mediciones { get; set; } = [];
}
