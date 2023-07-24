namespace EspacioPersonajes
{
    public class FabricaPersonajes {

        private Random random = new Random(); 

        public personaje CrearPersonaje()
        {

            personaje player = new personaje(); // este nuevo personaje retornara y actualizara al original
            constantes constante = new constantes(); 
            int opcion = numAleat(0, 2);
        
            switch (opcion)
            {
                //Caracteristicas que dependen de la raza
                case 0:
                    player.Nombre = constante.nombreOrco[numAleat(0,14)];
                    player.Apodo = constante.apodoOrco[numAleat(0, 14)];
                    player.Tipo = TipoPersonaje.orco;
                    player.Velocidad = numAleat(1, 5);
                    player.Destreza = numAleat(3, 7);
                    player.Fuerza = numAleat(6, 10);
                    player.Edad = numAleat(30, 80);
                    player.Defensa = numAleat(2, 6);
                    break;
                    
                case 1:
                    player.Nombre = constante.nombreElfo[numAleat(0,14)];
                    player.Apodo = constante.apodoElfo[numAleat(0, 14)];
                    player.Tipo = TipoPersonaje.elfo;
                    player.Velocidad = numAleat(6, 10);
                    player.Destreza = numAleat(1, 10);
                    player.Fuerza = numAleat(1, 5);
                    player.Edad = numAleat(200, 2000);
                    player.Defensa = numAleat(4, 8);
                    break;

                case 2:
                    player.Nombre = constante.nombreHumano[numAleat(0,14)];
                    player.Apodo = constante.apodoHumano[numAleat(0, 14)];
                    player.Tipo = TipoPersonaje.humano;
                    player.Velocidad = numAleat(3, 7);
                    player.Destreza = numAleat(3, 7);
                    player.Fuerza = numAleat(3, 7);
                    player.Edad = numAleat(20, 60);
                    break;
            }
            //Caracteristicas que no dependen de la raaza
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
            for (int i = 0; i < cantidad; i++)
            {
                //personaje = fabrica.CrearPersonaje();
                //ListaPersonajes.Add(personaje);
                ListaPersonajes.Add(fabrica.CrearPersonaje());
            }
            return ListaPersonajes;
        }

    }
}