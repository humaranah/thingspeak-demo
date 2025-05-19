using Newtonsoft.Json;

namespace ThingSpeak.Models;

public class Canal
{
    [JsonProperty("id")]
    public int Id { get; set; }

    [JsonProperty("name")]
    public string Nombre { get; set; } = "";

    [JsonProperty("description")]
    public string Descripcion { get; set; } = "";

    [JsonProperty("latitude")]
    public double Latitud { get; set; }

    [JsonProperty("longitude")]
    public double Longitud { get; set; }

    [JsonProperty("field1")]
    public string Campo1 { get; set; } = "";

    [JsonProperty("field2")]
    public string Campo2 { get; set; } = "";

    [JsonProperty("field3")]
    public string Campo3 { get; set; } = "";

    [JsonProperty("field4")]
    public string Campo4 { get; set; } = "";

    [JsonProperty("field5")]
    public string Campo5 { get; set; } = "";

    [JsonProperty("field6")]
    public string Campo6 { get; set; } = "";

    [JsonProperty("created_at")]
    public DateTime FechaCreacion { get; set; }

    [JsonProperty("updated_at")]
    public DateTime FechaActualizacion { get; set; }

    [JsonProperty("last_entry_id")]
    public int UltimoIdEntrada { get; set; }
}
