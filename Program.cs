using System;
using EspacioPersonajes;
using System.Collections.Generic;
using System.Text.Json;
using TrabajandoJson;

public class Program
{
    public static void Main()
    {
        FabricaPersonajes fabrica = new FabricaPersonajes();
        personaje personaje;

        //Si no existe el constructor en el codigo de HelperDeJson, se considera un constructor sin argumentos
        var miHelperDeArchivos = new HelperDeJson();
        var ListaPersonajes = new List<personaje>();
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
            Console.WriteLine("\n--Mostrando los elementos de la lista--");
            MostrarPersonajes(ListaPersonajes);


            Console.WriteLine("\n--Creando archivo personajes.json--");
            //Guardo el archivo
            Console.WriteLine("\n--Serializando--");
            //Convierte la lista a tipo string
            string PersonajesJson = JsonSerializer.Serialize(ListaPersonajes);
            Console.WriteLine("\nArchivo Serializado : " + PersonajesJson);
            Console.WriteLine("\n--Guardando--");

            //Guarda el texto de PersonajesJson en el archivo personajes.json
            miHelperDeArchivos.GuardarArchivoTexto(NombreArchivo, PersonajesJson);

            //Abro el Archivo
            Console.WriteLine("\n--Abriendo--");
            string jsonDocument = miHelperDeArchivos.AbrirArchivoTexto(NombreArchivo);
            Console.WriteLine("\n--Deserializando--");
            var listadoPersonajesRecuperado = JsonSerializer.Deserialize<List<personaje>>(jsonDocument);
            Console.WriteLine("\n--Mostrando datos recuperados--\n");
            MostrarPersonajes(listadoPersonajesRecuperado);
        } else {
            Console.WriteLine("--Archivo personajes.json ya existente--");
            //Abro el Archivo
            Console.WriteLine("--Abriendo--");
            string jsonDocument = miHelperDeArchivos.AbrirArchivoTexto(NombreArchivo);
            Console.WriteLine("--Deserializando--");
            var listadoPersonajesRecuperado = JsonSerializer.Deserialize<List<personaje>>(jsonDocument);
            Console.WriteLine("--Mostrando datos recuperardos--");
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
