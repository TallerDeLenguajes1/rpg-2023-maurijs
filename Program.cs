using System;
using EspacioPersonajes;

public class Program
{
    public static void Main()
    {
        FabricaPersonajes fabrica = new FabricaPersonajes();
        personaje nuevoPersonaje = fabrica.CrearPersonaje();
        Console.WriteLine(nuevoPersonaje.mostrarDatos());

        
        return;
    }

}
