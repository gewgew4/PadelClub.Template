using PadelClub.Domain.Comun;

namespace Consola;

internal static class Salida
{
    public static bool MostrarSiFallo(Result resultado)
    {
        if (resultado.EsÉxito)
            return false;

        Console.WriteLine($"[{resultado.Error.Código}] {resultado.Error.Mensaje}");
        return true;
    }
}
