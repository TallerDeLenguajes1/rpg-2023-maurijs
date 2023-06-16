using System.Text.Json;

namespace EspacioPersonajes
{
    public class PersonajesJson
    {

        public List<personaje>  LeerPersonajes(string nombreArchivo)
        {
            
            List<personaje> ListaPersonajes = new List<personaje>();
            using (var archivoOpen = new FileStream(nombreArchivo, FileMode.Open))
            {
                using (var strReader = new StreamReader(archivoOpen))
                {
                    string personajesJson = strReader.ReadToEnd();
                    ListaPersonajes = JsonSerializer.Deserialize<List<personaje>>(personajesJson);
                    archivoOpen.Close();
                }
            }
            return ListaPersonajes;
        }

        public void GuardarPersonajes(string nombreArchivo, List<personaje> ListaPersonajes)
        {
            //Serializando
            string PersonajesJson = JsonSerializer.Serialize(ListaPersonajes);

            using(var archivo = new FileStream(nombreArchivo, FileMode.Create))
            {
                using (var strWriter = new StreamWriter(archivo))
                {
                    strWriter.WriteLine("{0}", PersonajesJson);
                    strWriter.Close();
                }
            }
        }
    }
}
