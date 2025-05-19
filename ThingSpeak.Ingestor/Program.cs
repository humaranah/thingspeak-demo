using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using ThingSpeak.Ingestor.Models;
using ThingSpeak.Ingestor.Services;
using ThingSpeak.Shared.Services;

// Carga la configuración desde el archivo 'appsettings.json'
var configuration = new ConfigurationBuilder()
    .SetBasePath(AppContext.BaseDirectory)
    .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
    .Build();

// Configura la inyección de dependencias y construye el contenedor
var serviceProvider = new ServiceCollection()
    .Configure<IngestaConfig>(configuration.GetSection("Ingesta"))
    .AddSingleton<IConfiguration>(configuration)
    .AddSingleton<ISimuladorLectura, SimuladorLectura>()
    .AddSingleton<IClienteIngesta, ClienteIngesta>()
    .AddSingleton<IServicioIngesta, ServicioIngesta>()
    .AddLogging(builder =>
    {
        builder.AddConfiguration(configuration.GetSection("Logging"));
        builder.AddSimpleConsole();
    })
    .BuildServiceProvider();

var logger = serviceProvider.GetRequiredService<ILogger<Program>>();
logger.LogInformation("Iniciando la aplicación de ingesta...");

Console.ForegroundColor = ConsoleColor.Cyan;
Console.WriteLine("Aplicación de ingesta iniciada. Presiona cualquier tecla para salir.");
Console.ResetColor();

// Obtiene el servicio y lo ejecuta
using var cancellationTokenSource = new CancellationTokenSource();
var ingesta = serviceProvider.GetRequiredService<IServicioIngesta>();
_ = ingesta.EjecutarAsync(cancellationTokenSource.Token); // Ejecución 'fire-and-forget'

Console.ReadKey();
await cancellationTokenSource.CancelAsync();
