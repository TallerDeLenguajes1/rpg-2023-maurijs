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

        const string NombreArchivo = "personajes.json";
        if (!File.Exists(NombreArchivo))
        {    

            Console.WriteLine("--Creando archivo personajes.json--");
            //Guardo el archivo
            Console.WriteLine("--Serializando--");
            //Convierte la lista a tipo string
            string PersonajesJson = JsonSerializer.Serialize(ListaPersonajes);
            Console.WriteLine("Archivo Serializado : " + PersonajesJson);
            Console.WriteLine("--Guardando--");

            //Guarda el texto de PersonajesJson en el archivo personajes.json
            miHelperDeArchivos.GuardarArchivoTexto(NombreArchivo, PersonajesJson);

            //Abro el Archivo
            Console.WriteLine("--Abriendo--");
            string jsonDocument = miHelperDeArchivos.AbrirArchivoTexto(NombreArchivo);
            Console.WriteLine("--Deserializando--");
            var listadoPersonajesRecuperado = JsonSerializer.Deserialize<List<personaje>>(jsonDocument);
            Console.WriteLine("--Mostrando datos recuperardos--");
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
            Console.WriteLine(player.mostrarDatos());
        }
        return;
    }

}
