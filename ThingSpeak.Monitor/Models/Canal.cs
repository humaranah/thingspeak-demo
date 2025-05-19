using Newtonsoft.Json;

namespace ThingSpeak.Monitor.Models;

public class Canal
{

    [JsonProperty("id")]
    public int Id { get; set; }

    [JsonProperty("name")]
    public string NombreCanal { get; set; } = string.Empty;

    [JsonProperty("description")]
    public string DescripcionCanal { get; set; } = string.Empty;

    [JsonProperty("latitude")]
    public string Latitud { get; set; } = string.Empty;

    [JsonProperty("longitude")]
    public string Longitud { get; set; } = string.Empty;

    [JsonProperty("field1")]
    public string Campo1 { get; set; } = string.Empty;

    [JsonProperty("field2")]
    public string Campo2 { get; set; } = string.Empty;

    [JsonProperty("field3")]
    public string Campo3 { get; set; } = string.Empty;

    [JsonProperty("field4")]
    public string Campo4 { get; set; } = string.Empty;

    [JsonProperty("field5")]
    public string Campo5 { get; set; } = string.Empty;

    [JsonProperty("field6")]
    public string Campo6 { get; set; } = string.Empty;

    [JsonProperty("created_at")]
    public DateTime FechaCreacion { get; set; }

    [JsonProperty("updated_at")]
    public DateTime FechaActualizacion { get; set; }

    [JsonProperty("last_entry_id")]
    public int UltimoIdEntrada { get; set; }
}
