using Consola.Menus;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using PadelClub.Application.Canchas;
using PadelClub.Infrastructure;
using Serilog;
using System.Globalization;
using System.Text;

namespace Consola;

internal class Program
{
    static async Task Main(string[] args)
    {
        Console.OutputEncoding = Encoding.UTF8;
        var cultura = new CultureInfo("es-AR");
        CultureInfo.CurrentCulture = cultura;
        CultureInfo.CurrentUICulture = cultura;

        var builder = Host.CreateApplicationBuilder(new HostApplicationBuilderSettings { Args = args, ContentRootPath = AppContext.BaseDirectory });
        var logsDirectory = Path.Combine(FindSolutionRoot(AppContext.BaseDirectory), "Logs");
        Directory.CreateDirectory(logsDirectory);
        builder.Configuration["Serilog:WriteTo:0:Args:path"] = Path.Combine(logsDirectory, "log-.txt");

        builder.Logging.ClearProviders();
        builder.Services.AddSerilog((_, loggerConfiguration) =>
            loggerConfiguration.ReadFrom.Configuration(builder.Configuration));

        var cadena = builder.Configuration.GetConnectionString("PadelClub") ?? "";
        builder.Services.AgregarInfraestructura(cadena);
        builder.Services.AddScoped<CanchaServicio>();
        builder.Services.AddScoped<MenuCanchas>();

        using var host = builder.Build();
        var logger = host.Services.GetRequiredService<ILogger<Program>>();
        logger.LogInformation("PadelClub application started.");

        // TODO (Punto 6): Capturar las fallas técnicas en un único try/catch dentro del loop principal,
        // registrarlas con logger y mostrar un mensaje amigable sin cerrar la aplicación.
        while (true)
        {
            Console.WriteLine();
            Console.WriteLine("===================================");
            Console.WriteLine("        PADELCLUB v1.0");
            Console.WriteLine("===================================");
            Console.WriteLine(" 1. Canchas");
            Console.WriteLine(" 2. Socios");
            Console.WriteLine(" 3. Reservas");
            Console.WriteLine(" 0. Salir");
            Console.WriteLine("-----------------------------------");
            var opcion = Lector.LeerTexto("Opción");
            if (opcion == "0")
                return;

            using var alcance = host.Services.CreateScope();
            var proveedor = alcance.ServiceProvider;
            switch (opcion)
            {
                case "1":
                    await proveedor.GetRequiredService<MenuCanchas>().EjecutarAsync();
                    break;
                case "2":
                    Console.WriteLine("Módulo de Socios pendiente de implementar.");
                    break;
                case "3":
                    Console.WriteLine("Módulo de Reservas pendiente de implementar.");
                    break;
                default:
                    Console.WriteLine("Opción inválida.");
                    break;
            }
        }
    }

    static string FindSolutionRoot(string startPath)
    {
        for (var directory = new DirectoryInfo(startPath); directory is not null; directory = directory.Parent)
        {
            if (directory.EnumerateFiles("*.sln").Any())
                return directory.FullName;
        }

        return startPath;
    }
}
