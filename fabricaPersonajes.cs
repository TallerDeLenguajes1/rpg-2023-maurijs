using System.Net;
using System.Text.Json;

namespace EspacioPersonajes
{
    public class FabricaPersonajes
    {
        private Random random = new Random();
        private int numAleat(int min, int max)
        {
            return random.Next(min, max + 1);
        }

        public Personaje CrearPersonaje(string nombre, string apodo, string familia, List<string> quotes)
        {

            Personaje player = new Personaje(); // este nuevo personaje retornara
            player.Nombre = nombre;
            player.Apodo = apodo;
            player.Familia = familia;
            player.Frases = new List<string>(quotes);
            player.Edad = numAleat(20, 60);

            switch (player.Familia)
            {
                case "House Targaryen of King's Landing":
                    player.Inteligencia = numAleat(3, 7);
                    player.Destreza = numAleat(3,7 );
                    player.Fuerza = numAleat(6, 10);
                    player.Defensa = numAleat(2, 6);
                    break;
                case "House Stark of Winterfell":
                    player.Inteligencia = numAleat(3, 7);
                    player.Destreza = numAleat(6, 10);
                    player.Fuerza = numAleat(4, 8);
                    player.Defensa = numAleat(2, 5);
                    break;
                case "House Lannister of Casterly Rock":
                    player.Inteligencia = numAleat(3, 6);
                    player.Destreza = numAleat(4, 8);
                    player.Fuerza = numAleat(3, 7);
                    player.Defensa = numAleat(2, 8);
                    break;
                case "House Baratheon of Dragonstone":
                    player.Inteligencia = numAleat(4, 8);
                    player.Destreza = numAleat(2, 6);
                    player.Fuerza = numAleat(6, 10);
                    player.Defensa = numAleat(2, 6);
                    break;
                // Para personajes de cualquier otra familia
                default:
                    player.Inteligencia = numAleat(2, 6);
                    player.Destreza = numAleat(2, 6);
                    player.Fuerza = numAleat(2, 6);
                    player.Defensa = numAleat(2, 6);
                    break;
            }
            //Caracteristicas que no dependen de la familia
            player.Armadura = numAleat(2, 8);
            player.Astucia = numAleat(2, 8);
            player.Poder = numAleat(2, 8);
            player.FechaNac = new DateTime(DateTime.Now.Year - player.Edad, numAleat(1, 12), numAleat(1, 28));
            player.Salud = 100;
            player.Defensa = player.Armadura * player.Inteligencia;
            player.Ataque = player.Destreza * player.Fuerza * player.Poder;
            player.DanioCausado = ((player.Ataque * player.Astucia) - player.Defensa) / Constantes.constanteAjuste;

            return player;
        }

        public List<Personaje> GenerarListaPersonajes(int cantidad)
        {
            FabricaPersonajes fabrica = new FabricaPersonajes();
            var ListaPersonajes = new List<Personaje>();
            var ListaGOT =  GetPersonajesGOT();
            if (ListaGOT == null)
            {
                // Si GetPersonajesGOT devuelve null, devolvemos una lista vacía para evitar problemas más adelante.
                Console.WriteLine("Error al obtener la lista de personajes de la API.");
                return ListaPersonajes;
            }
           
            var IndexUsados = new List<int>();
            for (int i = 0; i < cantidad; i++)
            {
                //Para que no se repitan los personajes
                int indexRandom = GetRandomIndex(ListaGOT.Count, IndexUsados);
                PersonajeGOT personaje = GetPersonajeByIndex(ListaGOT, indexRandom);
                IndexUsados.Add(indexRandom);
                var familia = GetHouse(personaje);
                ListaPersonajes.Add(fabrica.CrearPersonaje(personaje.name, personaje.slug, familia, personaje.quotes));
            }

            return ListaPersonajes;
        }

        private static PersonajeGOT GetPersonajeByIndex(List<PersonajeGOT> ListaGOT, int indexRandom)
        {
            return ListaGOT[indexRandom];
        }

        private int GetRandomIndex(int cantPersonajes, List<int> IndexUsados)
        {
            int indexRandom;
            do
            {
                indexRandom = numAleat(0, cantPersonajes - 1);

            } while (IndexUsados.Contains(indexRandom));
            return indexRandom;
        }

        private static string GetHouse(PersonajeGOT personaje)
        {
            if (!personaje.hasHouse) return "Desconocida";           
            return personaje.GetHouse();
        }

        private static List<PersonajeGOT> GetPersonajesGOT()
        {
            var url = $"https://api.gameofthronesquotes.xyz/v1/characters/";
            var request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "GET";
            request.ContentType = "application/json";
            request.Accept = "application/json";
            var ListCharacter = new List<PersonajeGOT>();
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
                            ListCharacter = JsonSerializer.Deserialize<List<PersonajeGOT>>(responseBody);
                            return ListCharacter;
                        }
                    }
                }
            }
            catch (WebException ex)
            {
                Console.WriteLine("Problemas de acceso a la API: {0}", ex.Message);
                return ListCharacter;
            }
        }
    }

    
}
