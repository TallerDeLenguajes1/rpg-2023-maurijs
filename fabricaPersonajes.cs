namespace EspacioPersonajes
{
    public class FabricaPersonajes {

        private Random random = new Random(); 

        public personaje CrearPersonaje()
        {

            personaje nuevoPersonaje = new personaje(); // este nuevo personaje retornara y actualizara al original
            constantes constante = new constantes(); 
            int opcion = numAleat(0, 2);

            switch (opcion)
            {
                case 0:
                    nuevoPersonaje.Nombre = constante.nombreOrco[numAleat(0,14)];
                    nuevoPersonaje.Apodo = constante.apodoOrco[numAleat(0, 14)];
                    nuevoPersonaje.Tipo = TipoPersonaje.orco;
                    nuevoPersonaje.Velocidad = numAleat(1, 5);
                    nuevoPersonaje.Destreza = numAleat(3, 7);
                    nuevoPersonaje.Fuerza = numAleat(6, 10);
                    nuevoPersonaje.Nivel = numAleat(1, 10);
                    nuevoPersonaje.Armadura = numAleat(1, 7);
                    nuevoPersonaje.Salud = 100;
                    nuevoPersonaje.Edad = numAleat(30, 80);
                    nuevoPersonaje.Ataque = numAleat(4, 8);
                    nuevoPersonaje.Defensa = numAleat(2, 6);
                    nuevoPersonaje.FechaNac = new DateTime(DateTime.Now.Year - nuevoPersonaje.Edad, numAleat(1, 12), numAleat(1, 28));

                    break;
                case 1:
                    nuevoPersonaje.Nombre = constante.nombreElfo[numAleat(0,14)];
                    nuevoPersonaje.Apodo = constante.apodoElfo[numAleat(0, 14)];
                    nuevoPersonaje.Tipo = TipoPersonaje.elfo;
                    nuevoPersonaje.Velocidad = numAleat(6, 10);
                    nuevoPersonaje.Destreza = numAleat(1, 10);
                    nuevoPersonaje.Fuerza = numAleat(1, 5);
                    nuevoPersonaje.Nivel = numAleat(1, 10);
                    nuevoPersonaje.Armadura = numAleat(1, 5);
                    nuevoPersonaje.Salud = 100;
                    nuevoPersonaje.Edad = numAleat(200, 2000);
                    nuevoPersonaje.Ataque = numAleat(2, 6);
                    nuevoPersonaje.Defensa = numAleat(4, 8);
                    nuevoPersonaje.FechaNac = new DateTime(DateTime.Now.Year - nuevoPersonaje.Edad, numAleat(1, 12), numAleat(1, 28));
                    break;

                case 2:
                    nuevoPersonaje.Nombre = constante.nombreHumano[numAleat(0,14)];
                    nuevoPersonaje.Apodo = constante.apodoHumano[numAleat(0, 14)];
                    nuevoPersonaje.Tipo = TipoPersonaje.humano;
                    nuevoPersonaje.Velocidad = numAleat(3, 7);
                    nuevoPersonaje.Destreza = numAleat(3, 7);
                    nuevoPersonaje.Fuerza = numAleat(3, 7);
                    nuevoPersonaje.Nivel = numAleat(1, 10);
                    nuevoPersonaje.Armadura = numAleat(3, 7);
                    nuevoPersonaje.Salud = 100;
                    nuevoPersonaje.Edad = numAleat(20, 60);
                    nuevoPersonaje.Ataque = numAleat(2, 8);
                    nuevoPersonaje.Defensa = numAleat(2, 8);
                    nuevoPersonaje.FechaNac = new DateTime(DateTime.Now.Year - nuevoPersonaje.Edad, numAleat(1, 12), numAleat(1, 28));
                    break;
            }

            return nuevoPersonaje;
        }

        public FabricaPersonajes()
        {
        }

        private int numAleat(int min, int max)
        {
            return random.Next(min, max + 1);
        }

    }
}