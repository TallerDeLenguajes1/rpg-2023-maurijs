using System;
using EspacioPersonajes;
using System.Collections.Generic;
using System.Text.Json;

public class Program
{
    public static void Main()
    {
        FabricaPersonajes fabrica = new FabricaPersonajes();
        //Si no existe el constructor en el codigo de HelperDeJson, se considera un constructor sin argumentos
        var TrabajandoJson = new PersonajesJson();
        var ListaPersonajes = new List<Personaje>();
        var ListaPersonajesRecup = new List<Personaje>();
        int cantidad;
        const string FileJsonPath = "personajes.json";

        //Si el archivo json no existe
        if (!TrabajandoJson.Existe(FileJsonPath))
        {
            Console.WriteLine("Archivo personajes.json no encontrado\n");
            //Creo los 10 personajes
            Console.WriteLine("--Creamos aleatoriamente los personajes--\n");
            Console.WriteLine("--Ingrese la cantidad de personajes (2, 4, 6, 8 o 10):--\n");
            if (int.TryParse(Console.ReadLine(), out cantidad) && cantidad % 2 == 0)
            {
                //cantidad de personajes
                ListaPersonajes = fabrica.GenerarListaPersonajes(cantidad);  
                
                Console.WriteLine("\n--Guardamos los personajes en una lista--\n");
                Console.WriteLine("\n--Mostramos los elementos de la lista--");
                MostrarDatosPersonajes(ListaPersonajes);

                Console.WriteLine("\n--Creando archivo personajes.json--");

                //Creo el archivo personajes.josn y guarda los datos de la lista en el
                TrabajandoJson.GuardarPersonajes(FileJsonPath, ListaPersonajes);

                Console.WriteLine("\n--Deserializando personajes.json y guardando en una lista--");
                ListaPersonajesRecup = TrabajandoJson.LeerPersonajes(FileJsonPath); 

                Console.WriteLine("--Mostrando listado de personajes recuperado--\n");
                MostrarDatosPersonajes(ListaPersonajesRecup);
            }

        } else {
            Console.WriteLine("--Archivo personajes.json ya existente--\n");

            ListaPersonajesRecup = TrabajandoJson.LeerPersonajes(FileJsonPath);
            Console.WriteLine("--Mostrando listado de personajes recuperado--");
            MostrarDatosPersonajes(ListaPersonajesRecup);
        }

        int opcion, opcion2;
        Console.WriteLine("\nIngrese el indice del personaje para el jugador 1:");
        if (int.TryParse(Console.ReadLine(), out opcion) && opcion>0 && opcion<11)
        {
            Console.WriteLine("\nJugador 1:");
            Console.WriteLine("Nombre: " + ListaPersonajesRecup[opcion - 1].Nombre + " - Apodo: " + ListaPersonajesRecup[opcion - 1].Apodo + " - Familia: " + ListaPersonajesRecup[opcion - 1].Familia);
            
        } else
        {
            Console.WriteLine("\nOpcion invalida");
        }

        Console.WriteLine("\nIngrese el indice del personaje para el jugador 2:");
        if (int.TryParse(Console.ReadLine(), out opcion2) && opcion2>0 && opcion2<11 && opcion != opcion2)
        {
            Console.WriteLine("\nJugador 2:");
            Console.WriteLine("Nombre: " + ListaPersonajesRecup[opcion2 - 1].Nombre + " Apodo: " + ListaPersonajesRecup[opcion2 - 1].Apodo + " - Familia: " + ListaPersonajesRecup[opcion2 - 1].Familia);
            
        } else
        {
            Console.WriteLine("\nOpcion invalida");
        }
        return;
    }

    public static void MostrarDatosPersonajes(List<Personaje> Lista)
    {
        int indice = 1;
        foreach (var player in Lista)
        {
            Console.WriteLine("\nPersonaje N°"+ indice + player.mostrarDatos());
            indice++;
        }
        return;
    }

    public static void NombresPersonajes(List<Personaje> Lista)
    {
        foreach (var personaje in Lista)
        {
            Console.WriteLine("1- ");
        }
    }

    public static List<Personaje> TablaBatallas(int cantidad, List<Personaje> Lista)
    {

        int perdedor = 0;
        switch (cantidad)
        {
            case 2:
                Console.WriteLine(Lista[0].Nombre +  " ⚔️ "+ Lista[1].Nombre);
                Lista = UpdateAfterFight(Lista, 0, 1);
                break;
            case 4:
                Console.WriteLine(Lista[0].Nombre +  " ⚔️ "+ Lista[1].Nombre);
                Console.WriteLine(Lista[2].Nombre +  " ⚔️ "+ Lista[3].Nombre);
                break;
            case 6:
                Console.WriteLine(Lista[0].Nombre +  " ⚔️ "+ Lista[1].Nombre);
                Console.WriteLine(Lista[2].Nombre +  " ⚔️ "+ Lista[3].Nombre);
                Console.WriteLine(Lista[0].Nombre +  " ⚔️ "+ Lista[1].Nombre);
                break;
            case 8:
                Console.WriteLine(Lista[0].Nombre +  " ⚔️ "+ Lista[1].Nombre);
                Console.WriteLine(Lista[2].Nombre +  " ⚔️ "+ Lista[3].Nombre);
                Console.WriteLine(Lista[4].Nombre +  " ⚔️ "+ Lista[5].Nombre);
                Console.WriteLine(Lista[6].Nombre +  " ⚔️ "+ Lista[7].Nombre);
                break;
        }

        Console.WriteLine("");
        return Lista;
    }

    public static List<Personaje> UpdateAfterFight(List<Personaje> Lista, int player1, int player2)
    {
        int i = 1;
        Random random = new Random(); 
    

        // Mientras ambos jugadores tengan vida
        while (Lista[player1].IsAlive && Lista[player1].IsAlive )
        {
            Console.WriteLine("\nRonda "+i+"\n"+ Lista[player1].Nombre + "- Salud:"+Lista[player1].Salud+"\n"+Lista[player1].Nombre + "- Salud:"+Lista[player1].Salud);

            Lista[player1].Salud = -((Lista[player2].Ataque * Lista[player2].Astucia) - Lista[player2].Defensa) / Constantes.             constanteAjuste;
            Lista[player2].Salud = -((Lista[player1].Ataque * Lista[player1].Astucia) - Lista[player1].Defensa) / Constantes.             constanteAjuste;
            i++;
        }
        // Gana el primer jugador
        int indiceRandom;
        string FraseRandom;
        if (Lista[player1].IsAlive)
        {
            indiceRandom = random.Next(Lista[player1].Frases.Count);
            FraseRandom = Lista[player1].Frases[indiceRandom];

            Console.WriteLine("Ganador del Combate: " + Lista[player1].Nombre);
            Console.WriteLine(Lista[player1].Nombre +": '" + FraseRandom + "'");
            Lista.RemoveAt(player2);
        // Gana el segundo jugador
        } else
        {
            indiceRandom = random.Next(Lista[player2].Frases.Count);
            FraseRandom = Lista[player1].Frases[indiceRandom];

            Console.WriteLine("Ganador del Combate: " + Lista[player2].Nombre);
            Console.WriteLine(Lista[player2].Nombre +": '" + FraseRandom + "'");
            Lista.RemoveAt(player1);    
        }
        return Lista;
    }
}
