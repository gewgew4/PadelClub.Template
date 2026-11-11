using PadelClub.Application.Abstracciones;
using PadelClub.Domain;
using PadelClub.Domain.Comun;
using PadelClub.Domain.Entidades;
using PadelClub.Domain.Enums;
using PadelClub.Domain.Repositorios;

namespace PadelClub.Application.Canchas;

public sealed record CanchaDto(int Id, int Número, TipoCancha Tipo, bool Techada, decimal PrecioPorTurno, bool Habilitada);

public sealed class CanchaServicio(ICanchaRepositorio repositorio, IUnidadDeTrabajo unidad)
{
    public async Task<Result<IReadOnlyList<CanchaDto>>> ListarAsync(CancellationToken ct = default)
    {
        var canchas = await repositorio.ListarAsync(ct);
        IReadOnlyList<CanchaDto> lista = canchas
            .Select(c => new CanchaDto(c.Id, c.Número, c.Tipo, c.Techada, c.PrecioPorTurno, c.Habilitada))
            .ToList();
        return Result.Éxito(lista);
    }

    public async Task<Result<CanchaDto>> CrearAsync(int número, TipoCancha tipo, bool techada, decimal precio, CancellationToken ct = default)
    {
        var creada = Cancha.Crear(número, tipo, techada, precio);
        if (creada.EsFallo)
            return Result.Fallo<CanchaDto>(creada.Error);

        if (await repositorio.ExisteNúmeroAsync(creada.Valor.Número, ct))
            return Result.Fallo<CanchaDto>(Errores.Cancha.NúmeroDuplicado);

        repositorio.Agregar(creada.Valor);
        await unidad.GuardarAsync(ct);
        var cancha = creada.Valor;
        return Result.Éxito(new CanchaDto(cancha.Id, cancha.Número, cancha.Tipo, cancha.Techada, cancha.PrecioPorTurno, cancha.Habilitada));
    }

    public async Task<Result> ModificarAsync(int número, TipoCancha tipo, bool techada, decimal precio, CancellationToken ct = default)
    {
        var cancha = await repositorio.ObtenerPorNúmeroAsync(número, ct);
        if (cancha is null)
            return Result.Fallo(Errores.Cancha.NoEncontrada);

        var modificado = cancha.Modificar(tipo, techada, precio);
        if (modificado.EsFallo)
            return modificado;

        await unidad.GuardarAsync(ct);
        return Result.Éxito();
    }

    public async Task<Result> DeshabilitarAsync(int número, CancellationToken ct = default)
    {
        var cancha = await repositorio.ObtenerPorNúmeroAsync(número, ct);
        if (cancha is null)
            return Result.Fallo(Errores.Cancha.NoEncontrada);

        // TODO: Validar regla C4 (Cancha.TieneReservasFuturas) antes de deshabilitar.

        cancha.Deshabilitar();
        await unidad.GuardarAsync(ct);
        return Result.Éxito();
    }
}
