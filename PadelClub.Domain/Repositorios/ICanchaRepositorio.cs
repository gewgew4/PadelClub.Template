using PadelClub.Domain.Entidades;

namespace PadelClub.Domain.Repositorios;

public interface ICanchaRepositorio
{
    Task<IReadOnlyList<Cancha>> ListarAsync(CancellationToken ct = default);
    Task<Cancha?> ObtenerPorNúmeroAsync(int número, CancellationToken ct = default);
    Task<bool> ExisteNúmeroAsync(int número, CancellationToken ct = default);
    void Agregar(Cancha cancha);
}
