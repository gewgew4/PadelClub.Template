namespace PadelClub.Application.Abstracciones;

public interface IUnidadDeTrabajo
{
    Task GuardarAsync(CancellationToken ct = default);
}
