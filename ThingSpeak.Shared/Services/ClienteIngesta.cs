using Microsoft.Extensions.Logging;
using System.Text;
using ThingSpeak.Shared.Models;

namespace ThingSpeak.Shared.Services;

public class ClienteIngesta(ILogger<ClienteIngesta> logger) : IClienteIngesta
{
    public async Task EnviarAsync(string urlIngesta, Lectura datos, CancellationToken cancellationToken)
    {
        var url = ConstruirUrlEnvio(urlIngesta, datos);
        logger.LogInformation("Enviando datos: {Url}", url);
        try
        {
            using var client = new HttpClient(); // 'using' libera el cliente al finalizar el bloque
            var response = await client.GetAsync(url, cancellationToken);
            response.EnsureSuccessStatusCode();
            logger.LogInformation("Datos enviados correctamente");
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Error al enviar datos: {Message}", ex.Message);
        }
    }

    private static string ConstruirUrlEnvio(string urlIngesta, Lectura lectura)
    {
        return new StringBuilder(urlIngesta)
            .AppendFormat("&field1={0}", lectura.IdDispositivo)
            .AppendFormat("&field2={0}", lectura.FechaHora)
            .AppendFormat("&field3={0}", lectura.Consumo)
            .AppendFormat("&field4={0}", lectura.Estado)
            .AppendFormat("&field5={0}", lectura.Nombre)
            .AppendFormat("&field6={0}", lectura.Ubicacion)
            .ToString();
    }
}
