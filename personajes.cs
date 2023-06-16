namespace EspacioPersonajes
{
    
    public enum TipoPersonaje
    {
        orco,
        elfo,
        humano,
    }

    public class constantes
    {
        public string[] nombreOrco = { "Grom", "Thrum", "Drog", "Gorrum", "Harg", "Thurg", "Karg", "Doomhammer", "Deadeye", "Forebinder", "Elfkiller", "Skullsplitter", "Axeripper", "Tearshorn", "Fistcrusher"};
        public string[] nombreElfo = { "Legolas", "Arwen", "Galadriel", "Elrond", "Celeborn","Thranduil","Eowyn","Haldir", "Lúthien","Gil-galad","Tauriel", "Glorfindel","Círdan","Finrod","Celebrían" };
        public string[] nombreHumano = { "Juan", "Marco", "Emiliano", "Arturo", "Jorge", "Francisco", "Marcelo","Maximiliano","Manuel","Joaquin", "Ernesto", "Angel", "Nicolas", "Lionel", "Santiago" };

        //constructor 
        public constantes()
        {

        }
    }


    public class personaje
    {
        //============== Datos =====================================//
        private string nombre;
        private string apodo;

        TipoPersonaje tipo;

        private DateTime fechaNac;

        private int edad;

        //============== Datos =====================================//

        //============= Caracteristicas =============================//
         private int velocidad;
        private int destreza;

        private int fuerza;
        private int nivel;
        private int armadura;
        private int salud;
        //============= Caracteristicas =============================//


        public string Nombre { get => nombre; set => nombre = value; }
        public string Apodo { get => apodo; set => apodo = value; }
        public TipoPersonaje Tipo { get => tipo; set => tipo = value; }
        public DateTime FechaNac { get => fechaNac; set => fechaNac = value; }
        public int Edad { get => edad; set => edad = value; }
        public int Velocidad { get => velocidad; set => velocidad = value; }
        public int Destreza { get => destreza; set => destreza = value; }
        public int Fuerza { get => fuerza; set => fuerza = value; }
        public int Nivel { get => nivel; set => nivel = value; }
        public int Armadura { get => armadura; set => armadura = value; }
        public int Salud { get => salud; set => salud = value; }


        public personaje() // esta funcion la uso en el metodo de la fabrica
        {
        
        }
    }
}