# ThingSpeak Demo

Creado por: Humberto Arana

Proyecto de demostración de aplicaciones conectadas a un canal de ThingSpeak.

El proyecto consta de, principalmente, dos aplicaciones:

|Aplicación|Descripción|
|-|-|
|**ThingSpeak.Ingestor**|Aplicación de consola que simula dispositivos IoT y envía información al endpoint de ingesta|
|**ThingSpeak.Monitor**|Aplicación Blazor (WebAssembly) de monitoreo de datos|

## Pre requisitos

Antes de compilar y ejecutar la aplicación, es necesario tener instalado el SDK de .NET 8.0, el cual puede descargarse desde el siguiente enlace:

- [Descargar .NET 8.0 (Linux, macOS y Windows) | .NET](https://dotnet.microsoft.com/es-es/download/dotnet/8.0)

## Compilación

Para compilar la aplicación, basta con estar en la carpeta raíz y ejecutar el siguiente comando:

```bash
dotnet build
```

El comando mencionado restaurará los paquetes NuGet y compilará el proyecto de forma automática.

## Ejecución

Para ejecutar el proyecto, se debe ejecutar el script correspondiente, dependiendo del proyecto:

### ThingSpeak.Ingestor

Para ejecutar la aplicación de ingesta, se debe ejecutar el siguiente comando desde la carpeta raíz:

```bash
dotnet run --project .\ThingSpeak.Ingestor
```

### ThingSpeak.Monitor

Para ejecutar la aplicación de monitoreo, se debe ejecutar el siguiente comando desde la carpeta raíz:

```bash
dotnet run --project .\ThingSpeak.Monitor
```
