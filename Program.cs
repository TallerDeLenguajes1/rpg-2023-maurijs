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
        var personajesRecup = new List<personaje>();
        int cantidad;
        const string NombreArchivo = "personajes.json";

        //Si el archivo json no existe
        if (!TrabajandoJson.Existe(NombreArchivo))
        {
            Console.WriteLine("Archivo personajes.json no encontrado\n");
            //Creo los 10 personajes
            Console.WriteLine("--Creamos aleatoriamente los personajes--\n");
            Console.WriteLine("--Ingrese la cantidad de jugadores (2, 4, 5, 8 u 10):--\n");
            if (int.TryParse(Console.ReadLine(), out cantidad) && cantidad % 2 == 0 && cantidad<11 && cantidad>0)
            {    
                for (int i = 0; i < cantidad; i++)
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
                MostrarDatosPersonajes(ListaPersonajes);
            }


            Console.WriteLine("\n--Creando archivo personajes.json--");

            //Guarda el texto de PersonajesJson en el archivo personajes.json
            TrabajandoJson.GuardarPersonajes(NombreArchivo, ListaPersonajes);

            Console.WriteLine("\n--Deserializando personajes.json y guardando en una lista--");
            personajesRecup = TrabajandoJson.LeerPersonajes(NombreArchivo); 

            Console.WriteLine("--Mostrando listado de personajes recuperado--\n");
            MostrarDatosPersonajes(personajesRecup);

        } else {
            Console.WriteLine("--Archivo personajes.json ya existente--\n");

            personajesRecup = TrabajandoJson.LeerPersonajes(NombreArchivo);
            Console.WriteLine("--Mostrando listado de personajes recuperado--");
            MostrarDatosPersonajes(personajesRecup);
        }

        int opcion, opcion2;
        Console.WriteLine("\nIngrese el indice del personaje para el jugador 1 (1 al 10):");
        if (int.TryParse(Console.ReadLine(), out opcion) && opcion>0 && opcion<11)
        {
            Console.WriteLine("\nJugador 1:");
            Console.WriteLine("Nombre: " + personajesRecup[opcion - 1].Nombre + " - Apodo: " + personajesRecup[opcion - 1].Apodo);
            
        } else
        {
            Console.WriteLine("\nOpcion invalida");
        }

        Console.WriteLine("\nIngrese el indice (distinto al del jugador 1) del personaje para el jugador 2 (1 al 10):");
        if (int.TryParse(Console.ReadLine(), out opcion2) && opcion2>0 && opcion2<11 && opcion != opcion2)
        {
            Console.WriteLine("\nJugador 2:");
            Console.WriteLine("Nombre: " + personajesRecup[opcion2 - 1].Nombre + " Apodo: " + personajesRecup[opcion2 - 1].Apodo);
            
        } else
        {
            Console.WriteLine("\nOpcion invalida");
        }
        
        
 
        return;
    }

    public static void MostrarDatosPersonajes(List<personaje> Lista)
    {
        int indice = 1;
        foreach (var player in Lista)
        {
            Console.WriteLine("\nPersonaje N°"+ indice + player.mostrarDatos());
            indice++;
        }
        return;
    }

    public static void NombresPersonajes(List<personaje> Lista)
    {
        foreach (var personaje in Lista)
        {
            Console.WriteLine("1- ");
        }
    }

}
