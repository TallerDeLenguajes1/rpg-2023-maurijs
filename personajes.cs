namespace EspacioPersonajes
{
    
    public class constantes
    {
        public const int constanteAjuste = 500;
        //constructor 
        public constantes()
        {

        }
    }


    public class personaje //clases poco
    {
        //============== Datos =====================================//
        private string nombre;
        private string apodo;
        private string familia;
        public List<string> Frases { get; set; } = new List<string>();
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
        public string Familia { get => familia; set => familia = value; }
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
            return "\n---------------Datos-------------\nNombre: " + Nombre + " - Apodo: " + Apodo +" - Edad: "+ Edad + " - Familia: " + familia + " - Fecha de Nacimiento: " + fecha + "\n------------Caracteristicas----------\nVelocidad: " + Velocidad +" - Destreza: " + Destreza + " - Fuerza: " + Fuerza + " - Nivel: " + Nivel + " - Armadura: " + Armadura + " - Salud: " + Salud + " - Ataque: " + Ataque + " - Defensa: " + Defensa + " - Efectividad: " + Efectividad;
        }
    }
}