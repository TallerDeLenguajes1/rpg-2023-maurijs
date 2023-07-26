using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace EspacioPersonajes
{
    public class House
    {
        [JsonPropertyName("slug")]
        public string slug { get; set; }

        [JsonPropertyName("name")]
        public string name { get; set; }
    }

    public class PersonajeGOT //Dao / DTO -> data transfer object 
    {
        [JsonPropertyName("name")]
        public string name { get; set; }

        [JsonPropertyName("slug")]
        public string slug { get; set; }

        [JsonPropertyName("house")]
        public House house { get; set; }

        [JsonPropertyName("quotes")]
        public List<string> quotes { get; set; }
        
        public bool hasHouse => house != null;

        public string GetHouse() => house.name;
        
    }    
}
