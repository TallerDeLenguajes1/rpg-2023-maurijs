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

        public string[] apodoOrco = { "Colmillo Verde", "Gruñidor", "Tragón", "Garra Salvaje", "Rugidor", "Devorador de Huesos", "Cabezón", "Espinas Negras", "Barriga de Hierro", "Peludo Descomunal", "Hedor Pestilente", "Puños de Roca", "Dientes Afilados", "Gigante Rugiente", "Triturador de Almas" };

        public string[] nombreElfo = { "Legolas", "Arwen", "Galadriel", "Elrond", "Celeborn","Thranduil","Eowyn","Haldir", "Lúthien","Gil-galad","Tauriel", "Glorfindel","Círdan","Finrod","Celebrían" };

        public string[] apodoElfo = { "Estrella Plateada", "Susurros del Bosque", "Luz Brillante", "Danzante de Hojas", "Suspiro Estelar", "Voz de Armonía", "Espíritu Ágil", "Mirada Esmeralda", "Canto de la Aurora", "Alma Radiante", "Elegancia Silenciosa", "Guardián de los Secretos", "Serenidad Alada", "Lágrimas de Luna", "Eco de los Susurros" };
        
        public string[] nombreHumano = { "Juan", "Marco", "Emiliano", "Arturo", "Jorge", "Francisco", "Marcelo","Maximiliano","Manuel","Joaquin", "Ernesto", "Angel", "Nicolas", "Lionel", "Santiago" };

        public string[] apodoHumano = { "Espada de Acero", "Furia Indomable", "Martillo de Batalla", "León Valiente", "Sangre de Héroe", "Llama Ardiente", "Guardián Implacable", "Centinela Audaz", "Halcón de Guerra", "Escudo de Honor", "Venganza Justa", "Bravo Defensor", "Destello de Valor", "Corazón Intrépido", "Campeón Sin Temor" };

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

        public personaje() // esta funcion la uso en el metodo de la fabrica
        {
        
        }
        public string mostrarDatos()
        {
            return "Nombre:" + Nombre + " - Apodo:" + Apodo +" - Edad:"+ Edad + " - Raza:" + Tipo;
        }
    }
}