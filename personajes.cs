namespace EspacioPersonajes
{
    
    public class Constantes
    {
        public const int constanteAjuste = 500;
        //constructor 
        public Constantes()
        {

        }
    }


    public class Personaje //clases poco
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
        private int inteligencia;
        private int destreza;
        private int fuerza;
        private int poder;
        private int armadura;
        private int salud;
        private int defensa;
        private int ataque;
        private int astucia;
        private int danioCausado;

        //============= Caracteristicas =============================//

        public string Nombre { get => nombre; set => nombre = value; }
        public string Apodo { get => apodo; set => apodo = value; }
        public string Familia { get => familia; set => familia = value; }
        public DateTime FechaNac { get => fechaNac; set => fechaNac = value; }
        public int Edad { get => edad; set => edad = value; }
        public int Inteligencia { get => inteligencia; set => inteligencia = value; }
        public int Destreza { get => destreza; set => destreza = value; }
        public int Fuerza { get => fuerza; set => fuerza = value; }
        public int Poder { get => poder; set => poder = value; }
        public int Armadura { get => armadura; set => armadura = value; }
        public int Salud { get => salud; set => salud = value; }
        public int Defensa { get => defensa; set => defensa = value; }
        public int Ataque { get => ataque; set => ataque = value; }
        public int Astucia { get => astucia; set => astucia = value; }
        public int DanioCausado { get => danioCausado; set => danioCausado = value; }
        public bool IsAlive => Salud > 0;

        //==============================================================//
        public Personaje() // esta funcion la uso en el metodo de la fabrica
        {
        
        }
        public string mostrarDatos()
        {
            string fecha = fechaNac.ToString("dd/MM/yyyy"); // Ejemplo de formato: "dd/MM/yyyy"
            return "\n\n---------------Datos-------------\nNombre: " + Nombre + " - Apodo: " + Apodo +" - Edad: "+ Edad + " - Familia: " + familia + " - Fecha de Nacimiento: " + fecha + "\n------------Caracteristicas----------\nVelocidad: " + Inteligencia +" - Destreza: " + Destreza + " - Fuerza: " + Fuerza + " - Nivel: " + Poder + " - Armadura: " + Armadura + " - Salud: " + Salud + " - Ataque: " + Ataque + " - Defensa: " + Defensa + " - Efectividad: " + Astucia;
        }
    }
}