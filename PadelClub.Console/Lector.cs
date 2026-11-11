using PadelClub.Domain.Enums;
using System.Globalization;

namespace Consola;

internal static class Lector
{
    public static string LeerTexto(string etiqueta)
    {
        while (true)
        {
            Console.Write($"{etiqueta}: ");
            var texto = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(texto))
                return texto.Trim();
            Console.WriteLine("Ingresá un valor.");
        }
    }

    public static string LeerTextoLibre(string etiqueta)
    {
        Console.Write($"{etiqueta}: ");
        return Console.ReadLine() ?? "";
    }

    public static int LeerEntero(string etiqueta)
    {
        while (true)
        {
            Console.Write($"{etiqueta}: ");
            if (int.TryParse(Console.ReadLine(), out var número))
                return número;
            Console.WriteLine("Ingresá un número.");
        }
    }

    public static decimal LeerDecimal(string etiqueta)
    {
        while (true)
        {
            Console.Write($"{etiqueta}: ");
            if (decimal.TryParse(Console.ReadLine()?.Trim(), NumberStyles.AllowDecimalPoint | NumberStyles.AllowLeadingSign, CultureInfo.CurrentCulture, out var número))
                return número;
            Console.WriteLine("Ingresá un número, con coma para los decimales.");
        }
    }

    public static bool LeerSíNo(string etiqueta)
    {
        while (true)
        {
            Console.Write($"{etiqueta} (s/n): ");
            var texto = Console.ReadLine()?.Trim().ToLowerInvariant();
            if (texto is "s" or "si" or "sí")
                return true;
            if (texto is "n" or "no")
                return false;
            Console.WriteLine("Respondé s o n.");
        }
    }

    public static TipoCancha LeerTipo()
    {
        while (true)
        {
            Console.Write("Tipo (1 Cristal, 2 Muro): ");
            var texto = Console.ReadLine()?.Trim();
            if (texto == "1")
                return TipoCancha.Cristal;
            if (texto == "2")
                return TipoCancha.Muro;
            Console.WriteLine("Ingresá 1 o 2.");
        }
    }

    public static DateTime LeerInicio()
    {
        while (true)
        {
            Console.Write("Fecha (dd/MM/aaaa): ");
            var fechaTexto = Console.ReadLine();
            Console.Write("Hora (HH:mm): ");
            var horaTexto = Console.ReadLine();
            if (DateTime.TryParseExact(fechaTexto, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out var fecha)
                && TimeOnly.TryParseExact(horaTexto, "HH:mm", CultureInfo.InvariantCulture, DateTimeStyles.None, out var hora))
                return fecha.Date.Add(hora.ToTimeSpan());
            Console.WriteLine("La fecha o la hora no se entiende. Probá de nuevo.");
        }
    }

    public static DateOnly LeerFecha(string etiqueta)
    {
        while (true)
        {
            Console.Write($"{etiqueta} (dd/MM/aaaa): ");
            if (DateOnly.TryParseExact(Console.ReadLine(), "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out var fecha))
                return fecha;
            Console.WriteLine("La fecha no se entiende. Probá de nuevo.");
        }
    }
}
