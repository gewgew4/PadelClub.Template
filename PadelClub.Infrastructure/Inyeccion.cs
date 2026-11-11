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
}
