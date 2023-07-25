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
        Console.WriteLine("Menu:\n 1-Nuevos personajes\n2-Personajes ya existentes");

        int opcion;
        if (int.TryParse(Console.ReadLine(), out opcion)) {
            //Borramos el archivo json
            if (opcion == 1) {
                if (File.Exists(FileJsonPath)) {
                    try {
                        File.Delete(FileJsonPath);
                    }
                    catch (Exception e) {
                        Console.WriteLine("No se pudo borrar: {0}", e.Message);
                    }
                }
                else {
                    Console.WriteLine("El archivo no existe");
                }   
            }
        }

        //Si el archivo json no existe
        if (!TrabajandoJson.Existe(FileJsonPath))
        {
            Console.WriteLine("Archivo personajes.json no encontrado\n");
            //Creo los 10 personajes
            Console.WriteLine("--Creamos aleatoriamente los personajes--\n");
            Console.WriteLine("--Ingrese la cantidad de personajes (2, 4, 8):--\n");
            if (int.TryParse(Console.ReadLine(), out cantidad) && cantidad % 2 == 0 && cantidad<10 && cantidad >0 && cantidad !=6)
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

            ListaPersonajes = TrabajandoJson.LeerPersonajes(FileJsonPath);
            Console.WriteLine("--Mostrando listado de personajes recuperado--");
            MostrarDatosPersonajes(ListaPersonajes);
        }
        do
        {
            ListaPersonajes = Batallas(ListaPersonajes);
            
        } while (ListaPersonajes.Count>1);
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

    public static List<Personaje> Batallas(List<Personaje> Lista)
    {

        int cantidad = Lista.Count;
        if (cantidad>=10 || cantidad<0 || cantidad % 2 != 0 || Lista == null  )
        {
            return Lista;
        }
        switch (cantidad)
        {
            case 2:
                Console.WriteLine(Lista[0].Nombre + " ⚔️  " + Lista[1].Nombre);
                Lista = UpdateAfterFight(Lista, 0, 1);
                Ganador(Lista[0]);
                break;
            case 4:
                Console.WriteLine(Lista[2].Nombre +  " ⚔️  "+ Lista[3].Nombre);
                Lista = UpdateAfterFight(Lista, 2, 3);
                Console.WriteLine(Lista[0].Nombre +  " ⚔️  "+ Lista[1].Nombre);
                Lista = UpdateAfterFight(Lista, 0, 1);
                break;
            case 8:
                Console.WriteLine(Lista[6].Nombre +  " ⚔️  "+ Lista[7].Nombre);
                Lista = UpdateAfterFight(Lista, 6, 7);
                Console.WriteLine(Lista[4].Nombre +  " ⚔️  "+ Lista[5].Nombre);
                Lista = UpdateAfterFight(Lista, 4, 5);
                Console.WriteLine(Lista[2].Nombre +  " ⚔️  "+ Lista[3].Nombre);
                Lista = UpdateAfterFight(Lista, 2, 3);
                Console.WriteLine(Lista[0].Nombre +  " ⚔️  "+ Lista[1].Nombre);
                Lista = UpdateAfterFight(Lista, 0, 1);
                break;
        }
        return Lista;
    }

    private static void Ganador(Personaje player)
    {
        Random random = new Random();
        int indiceRandom = random.Next(0, player.Frases.Count);
        string FraseRandom = player.Frases[indiceRandom];
        Console.WriteLine("============= GANADOR DEL TRONO ===============");
        Console.WriteLine(player.Nombre + " - Familia: " + player.Familia);
        Console.WriteLine("'" + FraseRandom + "'");
    }

    // Realiza la pelea entre dos oponentes y me devuelve la lista actualizada al eliminar al perdedor
    public static List<Personaje> UpdateAfterFight(List<Personaje> Lista, int player1, int player2)
    {
        int i = 1;
        Random random = new Random();
        do
        {
            Console.WriteLine("\nRonda "+i+"\n"+ Lista[player1].Nombre + " - Salud:"+Lista[player1].Salud+"\n"+Lista[player2].Nombre + " - Salud:"+Lista[player2].Salud);
            Lista[player1].Salud = Lista[player1].Salud - Lista[player2].DanioCausado;
            Lista[player2].Salud = Lista[player2].Salud - Lista[player1].DanioCausado;
            i++;
        // Mientras ambos jugadores tengan vida
        } while (Lista[player1].IsAlive && Lista[player2].IsAlive);
        
       
        int indiceRandom;
        string FraseRandom;
        // Gana el primer jugador
        if (Lista[player1].IsAlive)
        {
            Console.WriteLine("\nRonda "+i+"\n"+ Lista[player1].Nombre + " - Salud:"+Lista[player1].Salud+"\n"+Lista[player2].Nombre + " - Salud:0");
            indiceRandom = random.Next(Lista[player1].Frases.Count);
            FraseRandom = Lista[player1].Frases[indiceRandom];

            Console.WriteLine("Ganador del Combate: " + Lista[player1].Nombre);
            Console.WriteLine(Lista[player1].Nombre +": '" + FraseRandom + "'");
            Lista.RemoveAt(player2);
        // Gana el segundo jugador
        } else
        {
            Console.WriteLine("\nRonda "+i+"\n"+ Lista[player1].Nombre + " - Salud:0"+"\n"+Lista[player2].Nombre + " - Salud:"+Lista[player2].Salud);
            indiceRandom = random.Next(Lista[player2].Frases.Count);
            FraseRandom = Lista[player2].Frases[indiceRandom];
            Console.WriteLine("Ganador del Combate: " + Lista[player2].Nombre);
            Console.WriteLine(Lista[player2].Nombre +": '" + FraseRandom + "'");
            Lista.RemoveAt(player1);    
        }
        return Lista;
    }
}


/*
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
        }*/