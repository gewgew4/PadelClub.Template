using PadelClub.Application.Abstracciones;

namespace PadelClub.Infrastructure.Persistencia;

public sealed class UnidadDeTrabajo(PadelClubDbContext db) : IUnidadDeTrabajo
{
    public Task GuardarAsync(CancellationToken ct = default) => db.SaveChangesAsync(ct);
}
