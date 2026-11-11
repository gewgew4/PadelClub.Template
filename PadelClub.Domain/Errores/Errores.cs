using PadelClub.Domain.Comun;

namespace PadelClub.Domain;

public static class Errores
{
    public static class Cancha
    {
        public static readonly Error NúmeroInválido =
            new("Cancha.NumeroInvalido", "El número de cancha debe estar entre 1 y 99.");

        public static readonly Error NúmeroDuplicado =
            new("Cancha.NumeroDuplicado", "Ya existe una cancha con ese número.");

        public static readonly Error PrecioInválido =
            new("Cancha.PrecioInvalido", "El precio por turno debe ser mayor a 0.");

        public static readonly Error TieneReservasFuturas =
            new("Cancha.TieneReservasFuturas", "No se puede deshabilitar: tiene reservas activas futuras.");

        public static readonly Error NoEncontrada =
            new("Cancha.NoEncontrada", "No existe esa cancha.");
    }

    public static class Socio
    {
        // Completar S1 a S7 con los códigos exactos de la tabla del parcial.
    }

    public static class Reserva
    {
        // Completar R2 a R10 con los códigos exactos de la tabla del parcial.
    }
}
