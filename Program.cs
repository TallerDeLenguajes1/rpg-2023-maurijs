using System;
using EspacioPersonajes;
using System.Collections.Generic;
using System.Text.Json;

public class Program
{
    public static void Main()
    {
        var fabrica = new FabricaPersonajes();
        var TrabajandoJson = new PersonajesJson();
        var ListaPersonajes = new List<Personaje>();
        var ListaPersonajesRecup = new List<Personaje>();
        int cantidad;
        const string FileJsonPath = "personajes.json";
        LogoInicial();
        Console.WriteLine("Enter para continuar...");
        Console.ReadLine();
        if (TrabajandoJson.Existe(FileJsonPath))
        {
            Console.WriteLine("--Archivo personajes.json ya existente--\n");

            Console.WriteLine("Menu:\n 1-Nuevos personajes\n 2-Personajes ya existentes");

            int opcion;
            if (int.TryParse(Console.ReadLine(), out opcion) && (opcion == 1 || opcion == 2))
            {

                //Borramos el archivo json
                if (opcion == 1)
                {
                    try
                    {
                        File.Delete(FileJsonPath);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("No se pudo borrar: {0}", e.Message);
                    }

                    Console.WriteLine("-Ingrese la cantidad de personajes (2, 4 u 8):\n");
                    if (int.TryParse(Console.ReadLine(), out cantidad) && cantidad % 2 == 0 && cantidad < 10 && cantidad > 0 && cantidad != 6)
                    {
                        //Guardamos los personajes en una lista y mostramos los elementos de la lista
                        ListaPersonajes = fabrica.GenerarListaPersonajes(cantidad);
                        MostrarDatosPersonajes(ListaPersonajes);
                        Console.WriteLine("Enter para continuar...");
                        Console.ReadLine();
                        //Creo el archivo personajes.json y guardo los datos de la lista en el
                        TrabajandoJson.GuardarPersonajes(FileJsonPath, ListaPersonajes);
                    }
                    //Opcion 2
                }
                else
                {
                    Console.WriteLine("--Cargando datos guardados--\n");
                    //Deserializando personajes.json y guardando en una lista
                    ListaPersonajes = TrabajandoJson.LeerPersonajes(FileJsonPath);
                    Console.WriteLine("--Mostrando listado de personajes recuperado--");
                    MostrarDatosPersonajes(ListaPersonajes);
                    Console.WriteLine("Enter para continuar...");
                    Console.ReadLine();
                }
            }
            // Si personajes.json no existe
        }
        else
        {
            //Creo los personajes aleatoriamente
            Console.WriteLine("-Ingrese la cantidad de personajes (2, 4 u 8):\n");
            if (int.TryParse(Console.ReadLine(), out cantidad) && cantidad % 2 == 0 && cantidad < 10 && cantidad > 0 && cantidad != 6)
            {
                //Guardamos los personajes en una lista y mostramos los elementos de la lista
                ListaPersonajes = fabrica.GenerarListaPersonajes(cantidad);
                MostrarDatosPersonajes(ListaPersonajes);
                Console.WriteLine("Enter para continuar...");
                Console.ReadLine();
                //Creo el archivo personajes.json y guardo los datos de la lista en el
                TrabajandoJson.GuardarPersonajes(FileJsonPath, ListaPersonajes);
            }
            // Batallas del juego
        }
        do
        {
            ListaPersonajes = Batallas(ListaPersonajes);
            Console.WriteLine("Enter para continuar...");
            Console.ReadLine();
        } while (ListaPersonajes.Count > 1);
        return;
    }

    private static void LogoInicial()
    {
        Console.WriteLine("\n");          
        Console.WriteLine("                 ░║█░             ");
        Console.WriteLine("               ░║█████░           ");
        Console.WriteLine("                 ░║█░             ");
        Console.WriteLine("                 ░║█░             ");
        Console.WriteLine("      ░██████╗░░██████╗░████████╗");
        Console.WriteLine("      ██╔════╝░██╔══ ██╗╚══██╔══╝");
        Console.WriteLine("===== ██║░░██╗░██║░░ ██║░░░██║░░░ =====");
        Console.WriteLine("      ██║░░╚██╗██║░░ ██║░░░██║░░░");
        Console.WriteLine("      ╚██████╔╝╚██████╔╝░░░██║░░░");
        Console.WriteLine("      ░╚═════╝░░╚═███═╝░░░░╚═╝░░░");
        Console.WriteLine("                 ░║█░             ");
        Console.WriteLine("                 ░║█░             ");
        Console.WriteLine("                 ░╚═░             ");
    }                                     
    

    public static void MostrarDatosPersonajes(List<Personaje> Lista)
    {
        int indice = 1;
        foreach (var player in Lista)
        {
            Console.WriteLine("\nPersonaje N°"+ indice + player.mostrarDatos());
            indice++;
        }
        return;
    }

    public static List<Personaje> Batallas(List<Personaje> Lista)
    {

        int cantidad = Lista.Count;
        if (cantidad>=10 || cantidad<0 || cantidad % 2 != 0 || Lista == null  )
        {
            return Lista;
        }
        switch (cantidad)
        {
            case 2:
                Console.WriteLine("\n=================== BATALLA FINAL  ===============================");
                Console.WriteLine("\n"+Lista[0].Nombre + " ⚔️  " + Lista[1].Nombre+"\n");
                Console.WriteLine("Enter para continuar...");
                Console.ReadLine();
                Lista = UpdateAfterFight(Lista, 0, 1);
                Ganador(Lista[0]);
                break;
            case 4:
                Console.WriteLine("\n=================== TABLA DE COMBATES 📜 ===============================");
                Console.WriteLine("\n"+Lista[2].Nombre +  " ⚔️  "+ Lista[3].Nombre);
                Console.WriteLine("\n"+Lista[0].Nombre +  " ⚔️  "+ Lista[1].Nombre+"\n\n");
                Console.WriteLine("Enter para continuar...");
                Console.ReadLine();

                Console.WriteLine("\n=================== Primera Batalla ===============================");
                Console.WriteLine("\n"+Lista[2].Nombre +  " ⚔️  "+ Lista[3].Nombre+"\n");
                Console.WriteLine("Enter para continuar...");
                Console.ReadLine();
                Lista = UpdateAfterFight(Lista, 2, 3);
                Console.WriteLine("\n=================== Segunda Batalla ===============================");
                Console.WriteLine("\n"+Lista[0].Nombre +  " ⚔️  "+ Lista[1].Nombre+"\n");
                Console.WriteLine("Enter para continuar...");
                Console.ReadLine();
                Lista = UpdateAfterFight(Lista, 0, 1);
                break;
            case 8:
                Console.WriteLine("\n=================== TABLA DE COMBATES 📜 ===============================");
                Console.WriteLine("\n"+Lista[6].Nombre +  " ⚔️  "+ Lista[7].Nombre);
                Console.WriteLine("\n"+Lista[4].Nombre +  " ⚔️  "+ Lista[5].Nombre);
                Console.WriteLine("\n"+Lista[2].Nombre +  " ⚔️  "+ Lista[3].Nombre);
                Console.WriteLine("\n"+Lista[0].Nombre +  " ⚔️  "+ Lista[1].Nombre+"\n");
                Console.ReadLine();
                Console.WriteLine("\n=================== Primera Batalla ===============================");
                Console.WriteLine("\n"+Lista[6].Nombre +  " ⚔️  "+ Lista[7].Nombre+"\n");
                Lista = UpdateAfterFight(Lista, 6, 7);
                Console.WriteLine("\n=================== Segunda Batalla ===============================");
                Console.WriteLine("\n"+Lista[4].Nombre +  " ⚔️  "+ Lista[5].Nombre+"\n");
                Lista = UpdateAfterFight(Lista, 4, 5);
                Console.WriteLine("\n=================== Tercera Batalla ===============================");
                Console.WriteLine("\n"+Lista[2].Nombre +  " ⚔️  "+ Lista[3].Nombre+"\n");
                Lista = UpdateAfterFight(Lista, 2, 3);
                Console.WriteLine("\n=================== Cuarta Batalla ===============================");
                Console.WriteLine("\n"+Lista[0].Nombre +  " ⚔️  "+ Lista[1].Nombre+"\n");
                Console.ReadLine();
                Lista = UpdateAfterFight(Lista, 0, 1);
                break;
        }
        return Lista;
    }

    private static void Ganador(Personaje player)
    {
        Random random = new Random();
        int indiceRandom = random.Next(0, player.Frases.Count);
        string FraseRandom = player.Frases[indiceRandom];
        Console.ReadLine();
        Console.WriteLine("\n============= 👑 GANADOR DEL TRONO DE HIERRO 👑 ===============\n");
        Console.ReadLine();
        Console.WriteLine(player.Nombre + " - Familia: " + player.Familia);
        Console.WriteLine("'" + FraseRandom + "'\n");
        Console.ReadLine();
        LogoFamilia(player.Familia);
        Console.WriteLine("\n============= FIN DEL JUEGO ===============================\n");

    }

    private static void LogoFamilia(string familia)
    {
        switch (familia)
        {
            case "House Targaryen of King's Landing":
                    Console.WriteLine("                    ⢀⠰⢶⣶⣿⣷⣮⣄⠀⢀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀");
                    Console.WriteLine("         ⠀⠀⠀⠀⠀⢀⣤⣾⣿⣶⣦⠘⠿⠛⠙⠁⣿⣿⠈⢛⣿⣦⣀⠀⠀⠀⠀⠀⠀⠀");
                    Console.WriteLine("         ⠀⠀⠀⢀⣠⣿⣿⠟⠈⠹⣿⣇⠀⠀⢀⣴⣿⡟⠰⣿⠋⢉⣿⢻⣦⣀⠀⠀⠀⠀");
                    Console.WriteLine("         ⠀⠀⠀⠸⠁⠹⠏⠀⠀⠀⣿⡯⣠⣾⡿⠟⠃⠀⢀⣹⣷⠿⠋⠈⠹⣿⣦⠀⠀⠀");
                    Console.WriteLine("         ⠀⢰⢠⣤⣶⣶⣤⣤⡀⢠⣿⣿⡿⠋⠠⣶⣿⣿⣿⣿⣿⣿⣶⣤⡀⠈⢿⣷⡀⠀");
                    Console.WriteLine("         ⢠⣿⣿⡟⠉⠉⠛⢿⣿⣾⣿⣿⠃⠀⠀⠘⣿⣿⠿⠿⡟⠛⢿⣿⣿⣷⡌⢻⣧⠀");
                    Console.WriteLine("         ⢸⣿⣏⠀⠀⠀⠀⡀⢹⣿⣿⣿⣷⣤⣄⣴⣿⠟⠃⠀⢠⣶⣦⡉⠈⢿⣿⣆⢿⡇");
                    Console.WriteLine("         ⠛⡅⠛⠀⠀⣼⣿⣿⠀⢻⣿⣿⣿⣿⣿⣿⣿⣿⣿⣶⣿⣿⣿⣿⡄⠸⣿⣿⡎⣷");
                    Console.WriteLine("         ⢰⡇⢀⣠⣄⡀⠙⣿⣆⠀⠹⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⡄⠉⢻⣿⠘");
                    Console.WriteLine("         ⠸⣧⡟⠉⠙⢷⡆⣿⠹⣦⣀⠀⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⡿⢿⣿⣷⠀⣸⣿⠀");
                    Console.WriteLine("         ⠀⢻⣇⡀⢀⣼⡟⠀⠀⠈⠙⠿⣿⣿⠃⣿⣿⣿⣿⣿⣿⣿⡏⢸⣿⣿⠀⢻⡿⠀");
                    Console.WriteLine("         ⠀⠈⣿⡋⠛⠉⠀⠀⢤⣷⡀⠀⠘⠁⠀⠘⣿⣿⠏⣿⣿⣿⡆⠘⣿⡿⠀⣸⠃⠀");
                    Console.WriteLine("         ⠀⠀⠈⢷⣄⠀⠀⠀⠛⠛⢿⣶⠦⠤⢶⣾⠿⢿⢃⣿⣿⡿⢀⣼⣿⠃⡰⠃⠀⠀");
                    Console.WriteLine("         ⠀⠀⠀⠀⠻⣦⣄⠀⠀⠀⠀⠷⠀⠀⠀⠀⠀⣠⣾⣿⠟⠀⢹⡿⢃⠞⠁⠀⠀⠀");
                    Console.WriteLine("         ⠀⠀⠀⠀⠀⠈⠙⠿⢶⣤⣤⣤⣤⣤⣤⣶⡿⠿⠋⣡⣤⡶⠋⠀⠀⠀⠀⠀⠀⠀");
                    Console.WriteLine("         ⠀⠀⠀⠀⠀⠀⠀⠀⠈⠉⠉⠛⠉⢛⣃⣉⣠⠤⠾⠛⠉⠀⠀⠀⠀⠀⠀⠀⠀⠀");
                break;
                
            case "House Stark of Winterfell":
                    Console.WriteLine("                  ⡀⢦⠄⣀⡀⠠⢤⣀⣀⠀⠀⠀⠀⠀⠀  ");
                    Console.WriteLine("     ⠀⠀⠀⠀⠀⠀⠀⠀⠠⣄⠬⢫⠩⠽⡒⣂⢓⠀⠀⠀⢐⣛⣳⢦⣀⡀⠀⠀⠀  ");
                    Console.WriteLine("          ⠠⣄⣒⡙⠉⢍⡀⡐⢔⠘⠄⠬⠑⠂⠆⢁⡬⠒⢈⡁⠉⢍⠲⡲  ");
                    Console.WriteLine("     ⠀⠀⠀⢒⣌⣉⠇⢀⠗⠒⡆⠀⡇⠀⡉⠊⠩⠁⠠⢊⠔⣯⢕⡠⢄⡃⠀⡐⠁ ");
                    Console.WriteLine("     ⠀⡹⢥⣴⢁⡜⠉⡭⠤⠴⠉⢹⠁⠀⣇⠀⡀⠀⠰⠙⠶⣤⢁⠉⠑⠹⠉⠀⠀");
                    Console.WriteLine("     ⠑⣤⣁⣀⡰⠃⢲⠀⣀⠧⠄⡞⠀⠙⠁⢀⣇⡀⠄⡀⠁⠨⠑⠻⡪⠃⠀⠀ ");
                    Console.WriteLine("    ⠀⠀⠸⠀⢤⠧⠤⡎⠉⢸⢀⣠⠧⢤⠋⢹⣉⣱⢡⠊⠀ ⠰⢴⠠⠁⠀⠀⠀ ");
                    Console.WriteLine("    ⠀⠀⠀⠀⣸⡀⢤⠓⢲⠋⠀⠇⠀⣸⡀⠤⡇⠞⠇⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀ ");
                    Console.WriteLine("    ⠀⠀⠀⠀⠀⠀⣄⣀⢼⠄⠒⡟⠉⢀⡇⡜⠹⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀");
                    Console.WriteLine("    ⠀⠀⠀⠀⠀⠀⠀⠀⢘⣀⣠⠓⢺⠡⠻⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀");
                    Console.WriteLine("    ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢸⢠⠚⠇⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀");
                    Console.WriteLine("    ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠈⠆⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀");
                break;
            case "House Lannister of Casterly Rock":
                    Console.WriteLine("             ⠀⣤⣷⣦⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀               ");
                    Console.WriteLine("         ⠀⠀⠀⠀⣙⣿⣿⠀⠀⠀⠀⢀⣀⣠⣶⣶⣼⣤⡄⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀");
                    Console.WriteLine("         ⠀⠀⠀⠀⣿⣿⣿⡄⠀⢴⣆⣘⠟⣿⣿⣿⣿⣿⣿⡂⠀⠀⢀⣀⣀⡀⣀⣠⠀⠀");
                    Console.WriteLine("         ⠀⠀⠀⠀⠉⡿⣿⣿⣦⡀⠀⠐⠛⣿⣿⣿⣿⣿⣿⡄⢀⡴⠋⠉⣹⣿⣿⣷⣖⣠");
                    Console.WriteLine("         ⠀⠀⠀⠀⠀⠀⠹⣿⣿⣷⣿⣿⣿⣿⣿⣿⣿⣿⡿⠇⣼⠃⠀⠉⡁⣹⣿⣿⡟⠃");
                    Console.WriteLine("         ⠀⠀⠀⠀⠀⠀⠚⢽⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⠛⠀⢿⡄⠀⠀⠉⣿⠃⡽⠃⠀");
                    Console.WriteLine("         ⢠⣤⣄⣀⠀⢀⣰⣼⣿⣿⣿⣿⣿⣿⣿⣿⣿⡿⠤⠀⠸⣇⣠⣴⣦⡉⠀⠀⠀⠀");
                    Console.WriteLine("         ⠽⠿⢟⣿⢿⣿⠿⡿⢿⢿⠻⣿⣿⣿⣿⣿⣿⡗⠀⢠⣴⣿⣿⣇⠀⠁⠀⠀⠀⠀");
                    Console.WriteLine("         ⠀⠀⠀⠀⠀⠈⠁⠀⠈⠀⠀⠙⢿⣿⣿⣿⣿⡆⠀⠉⠸⢻⠿⣿⠀⠀⠀⠀⠀⠀");
                    Console.WriteLine("         ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠙⢿⣿⣿⣷⠀⠀⢀⠀⢀⣼⣧⡀⠀⠀⠀⠀");
                    Console.WriteLine("         ⠀⠀⠀⠀⠀⠀⠀⠀⢀⣤⣴⣶⣶⣦⣄⣻⣿⣿⣧⠀⠸⣦⣴⣿⣿⣿⡆⠀⠀⠀");
                    Console.WriteLine("         ⠀⠀⠀⠀⠀⠀⠐⣶⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣇⠀⠀⠀⢸⡿⠿⠋⠀⠀⠀");
                    Console.WriteLine("         ⠀⠀⠀⠀⠀⠀⠈⠉⣿⣿⣿⣿⠻⢻⣿⣿⣿⣿⡿⠙⠛⠿⠛⠋⠀⠀⠀⠀⠀⠀");
                    Console.WriteLine("         ⠀⠀⠀⠀⠀⠀⠀⣀⣫⣿⣿⣿⡀⣼⣿⣿⣿⣿⡟⠁⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀");
                    Console.WriteLine("         ⠀⠀⠀⠀⠀⣴⣿⣿⣿⣿⠻⠟⠁⣿⢿⣿⣿⣿⣿⣇⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀");
                    Console.WriteLine("         ⠀⠀⠀⠀⠀⠈⠹⠉⠘⠁⠀⠀⠐⠉⠀⠙⢿⣿⣿⣷⡶⠀⠀⠀⠀⠀⠀⠀⠀⠀");
                    Console.WriteLine("         ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣸⣿⣿⣿⠿⠃⠀⠀⠀⠀⠀⠀⠀⠀");
                    Console.WriteLine("         ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢀⣴⣿⣿⢿⡟⠋⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀");
                    Console.WriteLine("         ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠈⠟⢿⠁⠈⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀");
                break;
            case "House Baratheon of Dragonstone":

                    Console.WriteLine("                                   ⢠⡀⠀⠀⠀⠀⢢⠀");
                    Console.WriteLine("         ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢀⠀⢱⡄⠀⠀⢄⣠⣧");
                    Console.WriteLine("         ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢀⠀⠀⢡⠀⢀⠀⠙⣿⡇⠀⢄⠀⢹⣿");
                    Console.WriteLine("         ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⡀⠀⠄⠀⠀⠀⢢⠀⢨⡇⢠⠈⢻⣿⣧⠀⢈⣿⣿⠃");
                    Console.WriteLine("         ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠈⠢⢬⣲⣤⣶⣚⣟⡛⠓⣾⣶⠼⠯⠿⠤⠞⠋⠁⠀");
                    Console.WriteLine("         ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣘⣧⣼⣿⣍⠉⠉⠉⠉⠉⠁⠀⠀⠀⠀⠀⠀⠀⠀");
                    Console.WriteLine("         ⠀⠀⠀⠀⠀⠀⠀⠀⣤⣴⣾⣿⣿⣿⣿⣯⠁⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀");
                    Console.WriteLine("         ⠀⠀⠀⠀⠀⠀⠀⠀⠀⡍⢉⣽⣿⣿⣿⡇⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀");
                    Console.WriteLine("         ⠀⠀⠀⠀⠀⠀⠀⠀⣠⡙⠛⣾⣿⣿⡟⠁⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀");
                    Console.WriteLine("         ⠀⠀⠀⠀⣀⡀⠀⣼⣿⣿⣿⣭⡄⡯⠤⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀");
                    Console.WriteLine("         ⠀⠀⣠⡾⣛⣷⣬⣿⣿⣿⣿⣿⣿⡄⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀");
                    Console.WriteLine("         ⢠⡾⠃⠀⣿⠻⢾⣿⣿⣿⣿⣿⣿⣿⣦⡀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀");
                    Console.WriteLine("         ⠀⠀⠀⠀⣿⠀⠀⠺⣿⣿⣿⣿⣿⣿⣿⣿⣶⣄⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀");
                    Console.WriteLine("         ⠀⠀⠀⠀⢿⠄⠀⠀⠈⠙⠻⢿⣿⣿⣿⣿⣿⣿⣿⣦⡀⠀⠀⠀⠀⠀⠀⠀⠀⠀");
                    Console.WriteLine("         ⠀⠀⠀⠀⠈⠀⠀⠀⠀⠀⠀⠀⠉⠙⣿⣿⣿⣿⣿⣿⣷⡀⠀⠀⠀⠀⠀⠀⠀⠀");
                    Console.WriteLine("         ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠰⣿⣿⣿⣿⣿⣿⡿⣧⠀⠀⠀⠀⠀⠀⠀⠀");
                    Console.WriteLine("         ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢻⣿⢿⣿⣿⡟⠀⠉⠀⠀⠀⠀⠀⠀⠀⠀");
                    Console.WriteLine("         ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢀⣀⣀⣤⣤⣿⠌⢿⣿⡃⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀");
                    Console.WriteLine("         ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠉⠉⠁⠀⠀⠀⠀⠈⠻⣷⡀⠀⠀⠀⠀⠀⠀⠀⠀⠀");
                    Console.WriteLine("         ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣿⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀");
                    Console.WriteLine("         ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⡟⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀");
                    Console.WriteLine("         ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢀⣼⠃⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀");
                break;
            default:
                    Console.WriteLine("              ⠀⣠⣄⣀⣀⣀⡀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀");
                    Console.WriteLine("         ⠀⠀⠀⠀⠀⠀⠙⠛⠛⠛⢉⣠⣤⣤⣤⣤⣤⣄⣀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀");
                    Console.WriteLine("         ⠀⢀⣤⣤⣶⣶⣶⣶⣶⣾⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣷⣄⣀⣀⠀⠀⠀⠀⠀⠀");
                    Console.WriteLine("         ⠀⠙⠿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⡿⠿⠿⠿⢿⣿⣿⣿⣿⣿⣿⣶⣶⣦⣄");
                    Console.WriteLine("         ⠀⠀⠀⠈⠙⠻⢿⣿⠿⠛⣿⣿⣿⣿⣿⣿⣦⣤⣶⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⡏");
                    Console.WriteLine("         ⠀⠀⣀⣤⣴⣦⣤⣤⣤⣾⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⠃");
                    Console.WriteLine("         ⠀⠀⠛⢿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⡟⠁⠀⠟⠹⣿⢿⣿⣿⣿⣿⣿⣿⠃⠀");
                    Console.WriteLine("         ⠀⢀⣠⣾⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⡅⠀⡀⠀⠀⠁⠚⠁⢹⣿⠋⠉⠁⠀⠀");
                    Console.WriteLine("         ⠀⠛⠿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣷⣿⣴⣆⣠⣾⠘⠁⠀⠀⠀⠀⠀");
                    Console.WriteLine("         ⠀⢀⣼⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣷⣄⠀⠀⠀⠀⠀");
                    Console.WriteLine("         ⢴⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⡿⠿⢿⣿⣿⣿⣿⠟⠀⠀⠀⠀⠀");
                    Console.WriteLine("         ⠀⠉⠛⠿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣇⠀⠀⠀⠸⠋⠁⠀⠀⠀⠀⠀⠀");
                    Console.WriteLine("         ⠀⠀⠀⠀⠀⠉⠛⠻⢿⣿⣿⣿⣿⣿⣿⡿⠿⠿⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀");
                    Console.WriteLine("         ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠈⠙⠛⠿⣿⣿⣧⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀");
                    Console.WriteLine("          ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠉⠙⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀");
                break;
        }
    }

    public static List<Personaje> UpdateAfterFight(List<Personaje> Lista, int player1, int player2)
    {
        int i = 1;
        Random random = new Random();
        Console.WriteLine(Lista[player1].Nombre + " - Salud:"+Lista[player1].Salud);
        Console.WriteLine(Lista[player2].Nombre + " - Salud:"+Lista[player2].Salud);
        do
        {
            Console.WriteLine("\nRonda " + i);
            //Ataca el jugador 1
            Ataque(Lista, player1, player2);
            //Si el jugador 2 se queda sin vida sale para evitar conflictos si mueren ambos
            if (!Lista[player2].IsAlive)
            {
                //Para que no tenga un valor negativo
                Console.WriteLine(Lista[player2].Nombre + " - Salud:0");
                Console.WriteLine(Lista[player1].Nombre + " - Salud:" + Lista[player1].Salud);
                break;
            }
            //Ataca el jugador 2
            Ataque(Lista, player2, player1);
            //Para que no tenga un valor negativo
            if (!Lista[player1].IsAlive) Lista[player1].Salud = 0;

            Console.WriteLine(Lista[player2].Nombre + " - Salud:" + Lista[player2].Salud);
            Console.WriteLine(Lista[player1].Nombre + " - Salud:" + Lista[player1].Salud);
            i++;
            // Mientras ambos jugadores tengan vida
        } while (Lista[player1].IsAlive && Lista[player2].IsAlive);
        
       
        int indiceRandom;
        string FraseRandom;
        if (Lista[player1].IsAlive)
        {
            indiceRandom = random.Next(Lista[player1].Frases.Count);
            FraseRandom = Lista[player1].Frases[indiceRandom];

            Console.WriteLine("\n"+Lista[player1].Nombre + " ha derrotado a " + Lista[player2].Nombre + "!!☠️ ");
            Console.WriteLine(Lista[player1].Nombre + ": '" + FraseRandom + "'");
            MejoraHabilidades(Lista, player1);
            Lista.RemoveAt(player2);
        }
        else
        {
            indiceRandom = random.Next(Lista[player2].Frases.Count);
            FraseRandom = Lista[player2].Frases[indiceRandom];

            Console.WriteLine("\n"+Lista[player2].Nombre + " ha derrotado a " + Lista[player1].Nombre + "!!☠️ ");
            Console.WriteLine("- "+FraseRandom+" -");
            MejoraHabilidades(Lista, player2);
            Lista.RemoveAt(player1);    
        }
        //Si no es la final
        if (Lista.Count >= 2) {
            Console.WriteLine("\nSalud recuperada!🚑❤️  - Fuerza⬆️ ⬆️  - Poder⬆️ ⬆️  - Inteligencia⬆️ ⬆️  - Destreza⬆️ ⬆️  - Armadura⬆️ ⬆️");
        }
        return Lista;
    }

    private static void Ataque(List<Personaje> Lista, int player1, int player2)
    {
        Lista[player2].Salud -= ((Lista[player1].Ataque * Lista[player1].Astucia) - Lista[player2].Defensa) / Constantes.constanteAjuste;
    }

    private static void MejoraHabilidades(List<Personaje> Lista, int player)
    {
        Lista[player].Salud = 100;
        Lista[player].Fuerza += 2;
        Lista[player].Poder += 2;
        Lista[player].Inteligencia += 2;
        Lista[player].Destreza += 2;
        Lista[player].Armadura += 2;
    }
}
