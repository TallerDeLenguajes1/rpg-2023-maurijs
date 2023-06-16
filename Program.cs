using System;
using EspacioPersonajes;

public class Program
{
    public static void Main()
    {
        FabricaPersonajes fabrica = new FabricaPersonajes();
        personaje personaje;
        var ListaPersonajes = new List<personaje>();

        for (int i = 0; i < 10; i++)
        {
            Console.WriteLine("Creacion del personaje " + (i+1));
            personaje = fabrica.CrearPersonaje();

            Console.WriteLine(personaje.mostrarDatos());
            
            ListaPersonajes.Add(personaje);
            
            Console.WriteLine("===============================");
        }

        Console.WriteLine("Mostrando los elementos de la lista");
        MostrarPersonajes(ListaPersonajes);
        return;
    }

    public static void MostrarPersonajes(List<personaje> Lista)
    {
        foreach (var player in Lista)
        {
            Console.WriteLine(player.mostrarDatos());
        }
        return;
    }

}
