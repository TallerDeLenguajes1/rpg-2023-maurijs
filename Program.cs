using System;
using EspacioPersonajes;
using System.Collections.Generic;
using System.Text.Json;

public class Program
{
    public static void Main()
    {
        FabricaPersonajes fabrica = new FabricaPersonajes();
        personaje personaje;

        //Si no existe el constructor en el codigo de HelperDeJson, se considera un constructor sin argumentos
        var TrabajandoJson = new PersonajesJson();
        var ListaPersonajes = new List<personaje>();
        var listadoPersonajesRecuperado = new List<personaje>();
        const string NombreArchivo = "personajes.json";

        //Si el archivo json no existe
        if (!File.Exists(NombreArchivo))
        {
            Console.WriteLine("Archivo personajes.json no encontrado\n");
            //Creo los 10 personajes
            Console.WriteLine("--Creamos aleatoriamente los personajes--\n");
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("Creacion del personaje " + (i+1) + ":");
                personaje = fabrica.CrearPersonaje();

                Console.WriteLine(personaje.mostrarDatos());

                //Guardo cada personaje en la lista
                ListaPersonajes.Add(personaje);
                Console.WriteLine("======================================================");
            }
            // Pruebo mostrar la lista
            Console.WriteLine("\n--Guardamos los personajes en una lista--\n");
            Console.WriteLine("\n--Mostramos los elementos de la lista--");
            MostrarPersonajes(ListaPersonajes);



            Console.WriteLine("\n--Creando archivo personajes.json--");
            //Guarda el texto de PersonajesJson en el archivo personajes.json
            TrabajandoJson.GuardarPersonajes(NombreArchivo, ListaPersonajes);

            Console.WriteLine("\n--Deserializando personajes.json y guardando en una lista--");
            listadoPersonajesRecuperado = TrabajandoJson.LeerPersonajes(NombreArchivo); 
            Console.WriteLine("--Mostrando listado de personajes recuperado--\n");
            MostrarPersonajes(listadoPersonajesRecuperado);

        } else {
            Console.WriteLine("--Archivo personajes.json ya existente--");

            listadoPersonajesRecuperado = TrabajandoJson.LeerPersonajes(NombreArchivo);
            Console.WriteLine("--Mostrando listado de personajes recuperado--\n");
            MostrarPersonajes(listadoPersonajesRecuperado);
        }
 
        return;
    }

    public static void MostrarPersonajes(List<personaje> Lista)
    {
        foreach (var player in Lista)
        {
            Console.WriteLine("\n"+player.mostrarDatos());
        }
        return;
    }

}
