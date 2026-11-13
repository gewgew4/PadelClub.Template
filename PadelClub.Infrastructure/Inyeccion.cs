using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using PadelClub.Application.Abstracciones;
using PadelClub.Domain.Repositorios;
using PadelClub.Infrastructure.Persistencia;
using PadelClub.Infrastructure.Repositorios;

namespace PadelClub.Infrastructure;

public static class Inyeccion
{
    public static IServiceCollection AgregarInfraestructura(this IServiceCollection services, string cadena)
    {
        services.AddDbContext<PadelClubDbContext>(opciones => opciones.UseSqlServer(cadena));
        services.AddScoped<ICanchaRepositorio, CanchaRepositorio>();
        services.AddScoped<IUnidadDeTrabajo, UnidadDeTrabajo>();
        return services;
    }

    /// <summary>
    /// Crea la base de datos si no existe y aplica las migraciones pendientes de Entity Framework Core.
    /// </summary>
    public static async Task InicializarBaseDeDatosAsync(this IServiceProvider services)
    {
        await using var alcance = services.CreateAsyncScope();
        var contexto = alcance.ServiceProvider.GetRequiredService<PadelClubDbContext>();
        var pendientes = await contexto.Database.GetPendingMigrationsAsync();
        if (pendientes.Any())
            await contexto.Database.MigrateAsync();
    }
}
