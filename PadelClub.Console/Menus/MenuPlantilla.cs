namespace Consola.Menus;

internal abstract class MenuPlantilla
{
    public async Task EjecutarAsync()
    {
        while (true)
        {
            Console.WriteLine();
            MostrarOpciones();
            var opcion = Lector.LeerTexto("Opción");
            if (opcion == "0")
                return;

            await EjecutarOpcionAsync(opcion);
            Console.WriteLine();
            Console.WriteLine("Enter para continuar.");
            Console.ReadLine();
        }
    }

    protected abstract void MostrarOpciones();
    protected abstract Task EjecutarOpcionAsync(string opcion);
}
