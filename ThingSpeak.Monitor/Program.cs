using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using ThingSpeak.Monitor;
using ThingSpeak.Monitor.Models;
using ThingSpeak.Monitor.Services;

// Cargar configuración desde appsettings.json
var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.Configuration.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
builder.Services.Configure<MonitorConfig>(builder.Configuration.GetSection("Monitor"));
builder.Services.AddScoped<IClienteMonitor, ClienteMonitor>();
builder.Services.AddScoped<IServicioMonitor, ServicioMonitor>();
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

await builder.Build().RunAsync();
