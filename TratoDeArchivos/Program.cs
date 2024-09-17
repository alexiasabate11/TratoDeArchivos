using System;
using System.CodeDom;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Permissions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TratoDeArchivos
{
    internal class Program
    {
        static Jugadores jugadores = new Jugadores();
        static Equipos equipos = new Equipos();
        static int menu;

        static void Main(string[] args)
        {
            Console.WriteLine();
            if (!jugadores.ComprobarSiExisteArchivoJugadores() || !equipos.ComprobarSiExisteArchivoEquipos())
            {
                equipos.IntroducirNuevoEquipo();
                jugadores.IntroducirNuevoJugador();
            }
            do
            {
                menu = Menu();

                switch (menu)
                {
                    case 1:
                        IntroducirNuevo();
                        break;
                    case 2:
                        Eliminar();
                        break;
                    case 3:
                        Editar();
                        break;
                    case 4:
                        MostrarTodo();
                        break;
                    case 0:
                        equipos.GuardarArchivoEquipos();
                        jugadores.GuardarArchivoJugadores();
                        break;
                }                
                Console.WriteLine();
            }
            while (menu != 0);
        }

        static int Menu()
        {
            Console.WriteLine(@"
Que quieres hacer?
    1. Dar de alta a un equipo o jugador.
    2. Dar de baja a un equipo o jugador.
    3. Modificar contenido de un equipo o jugador
    4. Ver todos los equipos y sus jugadores
    0. Salir
    ");

            while (true)
            {
                menu = Int32.TryParse(Console.ReadLine(), out int result) ? result : -1;

                if (menu == -1)
                    Console.WriteLine("Error: Introduce un numero");
                else
                    break;
            }
            return menu;
        }

        
        static void IntroducirNuevo()
        {
            Console.WriteLine(@"
Dar de alta a:
    1. Un equipo.
    2. Un jugador. 
");
            Int32.TryParse(Console.ReadLine(), out int tipo);
            switch (tipo)
            {
                case 1:
                    equipos.IntroducirNuevoEquipo();
                    break;
                case 2:
                    jugadores.IntroducirNuevoJugador();
                    break;
            }
        }

        static void Editar()
        {
            Console.WriteLine(@"
Editar:
    1. Un equipo.
    2. Un jugador. 
");
            Int32.TryParse(Console.ReadLine(), out int tipo);
            switch (tipo)
            {
                case 1:
                    Console.WriteLine(@"
Que quieres editar?
    1. Equipo.
    2. Puntuacion.
");
                    Int32.TryParse(Console.ReadLine(), out int editarEquipo);
                    switch (editarEquipo)
                    {
                        case 1:
                            equipos.EditarEquipo();
                            break;
                        case 2:
                            equipos.EditarPuntuacion();
                            break;
                    }
                    break;
                case 2:
                    Console.WriteLine(@"
Que quieres editar?
    1. Dorsal.
    2. Equipo.
");
                    Int32.TryParse(Console.ReadLine(), out int editarJugador);
                    switch (editarJugador)
                    {
                        case 1:
                            jugadores.EditarDorsal();
                            break;
                        case 2:
                            jugadores.EditarEquipo();
                            break;
                    }
                    break;
            }
        }

        static void Eliminar()
        {
            Console.WriteLine(@"
Dar de baja a:
    1. Un equipo.
    2. Un jugador. 
");
            Int32.TryParse(Console.ReadLine(), out int tipo);
            switch (tipo)
            {
                case 1:
                    equipos.EliminarEquipo();
                    break;
                case 2:
                    jugadores.EliminarJugador();
                    break;
            }
        }

        static void MostrarTodo()
        {
            List<Equipos> todosEquipos = equipos.EquiposAll;
            List<Jugadores> todosJugadores = jugadores.JugadoresAll;

            foreach (Equipos equipo in todosEquipos)
            {
                Console.WriteLine("{0},{1}", equipo.NombreEquipo, equipo.PuntuacionEquipo);
                Console.WriteLine("--------------------------");

                for (int i = 0; i < todosJugadores.Count; i++)
                {
                    Jugadores jugadorAEquipo = todosJugadores.Find(j => j.NombreEquipo == equipo.NombreEquipo);

                    if (jugadorAEquipo != null)
                        Console.WriteLine("\t{0},{1}", jugadorAEquipo.Nombrejugador, jugadorAEquipo.Dorsal);
                }
            }
            Console.WriteLine();
        }
    }
}
