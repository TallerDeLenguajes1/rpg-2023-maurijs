using System.Net;
using System.Text.Json;
using System;
using System.Collections.Generic;
using System.IO;


namespace EspacioPersonajes
{
    public class FabricaPersonajes
    {

        private Random random = new Random();

        public personaje CrearPersonaje(string nombre, string apodo, string familia, List<string> quotes)
        {

            personaje player = new personaje(); // este nuevo personaje retornara
            player.Nombre = nombre;
            player.Apodo = apodo;
            player.Familia = familia;
            player.Frases = new List<string>(quotes);
            player.Edad = numAleat(20, 60);

            switch (player.Familia)
            {
                case "House Targaryen of King's Landing":
                    player.Velocidad = numAleat(2, 6);
                    player.Destreza = numAleat(3,7 );
                    player.Fuerza = numAleat(6, 10);
                    player.Defensa = numAleat(4, 8);
                    break;
                case "House Stark of Winterfell":
                    player.Velocidad = numAleat(3, 7);
                    player.Destreza = numAleat(6, 10);
                    player.Fuerza = numAleat(4, 8);
                    player.Defensa = numAleat(2, 6);
                    break;
                case "House Lannister of Casterly Rock":
                    player.Velocidad = numAleat(3, 7);
                    player.Destreza = numAleat(3, 7);
                    player.Fuerza = numAleat(3, 7);
                    player.Defensa = numAleat(2, 6);
                    break;
                case "House Baratheon of Dragonstone":
                    player.Velocidad = numAleat(3, 7);
                    player.Destreza = numAleat(3, 7);
                    player.Fuerza = numAleat(3, 7);
                    player.Defensa = numAleat(2, 6);
                    break;
                // Para personajes de cualquier otra familia
                default:
                    player.Velocidad = numAleat(3, 7);
                    player.Destreza = numAleat(3, 7);
                    player.Fuerza = numAleat(3, 7);
                    player.Defensa = numAleat(3, 7);
                    break;
            }
            //Caracteristicas que no dependen de la familia
            player.Armadura = numAleat(1, 10);
            player.Efectividad = numAleat(1, 100);
            player.Nivel = numAleat(1, 10);
            player.FechaNac = new DateTime(DateTime.Now.Year - player.Edad, numAleat(1, 12), numAleat(1, 28));
            player.Salud = 100;
            player.Defensa = player.Armadura * player.Velocidad;
            player.Ataque = player.Destreza * player.Fuerza * player.Nivel;
            player.DanioCausado = ((player.Ataque * player.Efectividad) - player.Defensa) / constantes.constanteAjuste;

            return player;
        }

        public FabricaPersonajes()
        {
        }

        private int numAleat(int min, int max)
        {
            return random.Next(min, max + 1);
        }


        public List<personaje> GenerarListaPersonajes(int cantidad)
        {
            FabricaPersonajes fabrica = new FabricaPersonajes();
            //personaje personaje;
            var ListaPersonajes = new List<personaje>();
            var ListaGOT =  GetPersonajesGOT();

            if (ListaGOT == null)
            {
                // Si GetPersonajesGOT devuelve null, devolvemos una lista vacía para evitar problemas más adelante.
                Console.WriteLine("Error al obtener la lista de personajes de la API.");
                return ListaPersonajes;
            }
            int indexFrase;
            int indexRandom;
            int cantPersonajes = ListaGOT.Count;
            var IndexUsados = new List<int>();
            personajeGOT personaje;
            while (IndexUsados.Count < cantidad)
            {
                indexRandom = numAleat(0,  cantPersonajes);
            if (!IndexUsados.Contains(indexRandom))
                IndexUsados.Add(indexRandom);

            //Para que no se repitan los personajes
            personaje = ListaGOT[indexRandom];
            indexFrase = numAleat(0, personaje.quotes.Count);
            ListaPersonajes.Add(fabrica.CrearPersonaje(personaje.name, personaje.slug, personaje.house.name, personaje.quotes));
            IndexUsados.Add(indexRandom);
            }
            
            return ListaPersonajes;
        }

        private static List<personajeGOT> GetPersonajesGOT()
        {
            var url = $"https://api.gameofthronesquotes.xyz/v1/characters/";
            var request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "GET";
            request.ContentType = "application/json";
            request.Accept = "application/json";
            var ListCharacter = new List<personajeGOT>();
            try
            {
                using (WebResponse response = request.GetResponse())
                {
                    using (Stream strReader = response.GetResponseStream())
                    {
                        if (strReader == null) return ListCharacter;
                        using (StreamReader objReader = new StreamReader(strReader))
                        {
                            string responseBody = objReader.ReadToEnd();
                            ListCharacter = JsonSerializer.Deserialize<List<personajeGOT>>(responseBody);
                            foreach (var item in ListCharacter)
                            {
                                Console.WriteLine(item.name);
                            }
                            return ListCharacter;
                        }
                    }
                }
            }
            catch (WebException ex)
            {
                Console.WriteLine("Problemas de acceso a la API");
                return ListCharacter;
            }
        }
    }
}