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

        public string[] apodoOrco = { "Colmillo Verde", "Demoledor", "Tragon", "Garra Salvaje", "Rugidor", "Devorador de Huesos", "Cabezon", "Espinas Negras", "Barriga de Hierro", "Peludo Descomunal", "Hedor Pestilente", "Punios de Roca", "Dientes Afilados", "Gigante Rugiente", "Triturador de Almas" };

        public string[] nombreElfo = { "Legolas", "Arwen", "Galadriel", "Elrond", "Celeborn","Thranduil","Eowyn","Haldir", "Luthien","Gil-galad","Tauriel", "Glorfindel","Cirdan","Finrod","Celebrian" };

        public string[] apodoElfo = { "Estrella Plateada", "Susurros del Bosque", "Luz Brillante", "Danzante de Hojas", "Suspiro Estelar", "Voz de Armonia", "Espiritu Agil", "Mirada Esmeralda", "Canto de la Aurora", "Alma Radiante", "Elegancia Silenciosa", "Guardian de los Secretos", "Serenidad Alada", "Lagrimas de Luna", "Eco de los Susurros" };
        
        public string[] nombreHumano = { "Juan", "Marco", "Emiliano", "Arturo", "Jorge", "Francisco", "Marcelo","Maximiliano","Manuel","Joaquin", "Ernesto", "Angel", "Nicolas", "Lionel", "Santiago" };

        public string[] apodoHumano = { "Espada de Acero", "Furia Indomable", "Martillo de Batalla", "Leon Valiente", "Sangre de Heroe", "Llama Ardiente", "Guardian Implacable", "Centinela Audaz", "Halcon de Guerra", "Escudo de Honor", "Venganza Justa", "Bravo Defensor", "Destello de Valor", "Corazon Intrepido", "Campeon Sin Temor" };

        public const int constanteAjuste = 500;
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
        private int defensa;
        private int ataque;
        private int efectividad;
        private int danioCausado;

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
        public int Defensa { get => defensa; set => defensa = value; }
        public int Ataque { get => ataque; set => ataque = value; }
        public int Efectividad { get => efectividad; set => efectividad = value; }
        public int DanioCausado { get => danioCausado; set => danioCausado = value; }
        //==============================================================//
        public personaje() // esta funcion la uso en el metodo de la fabrica
        {
        
        }
        public string mostrarDatos()
        {
            Console.WriteLine("====================================================================================================");
            string fecha = fechaNac.ToString("dd/MM/yyyy"); // Ejemplo de formato: "dd/MM/yyyy"
            return "\n---------------Datos-------------\nNombre: " + Nombre + " - Apodo: " + Apodo +" - Edad: "+ Edad + " - Raza: " + Tipo + " - Fecha de Nacimiento: " + fecha + "\n------------Caracteristicas----------\nVelocidad: " + Velocidad +" - Destreza: " + Destreza + " - Fuerza: " + Fuerza + " - Nivel: " + Nivel + " - Armadura: " + Armadura + " - Salud: " + Salud + " - Ataque: " + Ataque + " - Defensa: " + Defensa + " - Efectividad: " + Efectividad;
        }
    }
}