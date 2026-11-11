using Microsoft.EntityFrameworkCore;
using PadelClub.Domain.Entidades;

namespace PadelClub.Infrastructure.Persistencia;

public sealed class PadelClubDbContext(DbContextOptions<PadelClubDbContext> opciones) : DbContext(opciones)
{
    public DbSet<Cancha> Canchas => Set<Cancha>();

    protected override void OnModelCreating(ModelBuilder modelBuilder) =>
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(PadelClubDbContext).Assembly);
}
