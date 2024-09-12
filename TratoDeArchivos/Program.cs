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
        static Dictionary<string, Jugadores[]> equipos = new Dictionary<string, Jugadores[]>();
        static Jugadores jugadores;
        static Jugadores[] todosJugadores;
        static string rutaArchivoEquipos = @"C:\Users\alexi\OneDrive\Escriptori\equiposFutbol.txt";


        static void Main(string[] args)
        {
            Console.WriteLine();
            do
            {
                switch (jugadores.ComprobarSiExisteArchivoJugadores() ? Menu() : 1)
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
                        jugadores.MostrarJugadores();
                        break;
                    case 0:
                        return;
                }
                jugadores.GuardarArchivoJugadores();
                Console.WriteLine();
            } 
            while(true);
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
            return PedirNumero();
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
                    break;
                case 2:
                    Console.WriteLine(@"
Que quieres editar?
    1. Dorsal.
    2. Equipo.
");
                    Int32.TryParse(Console.ReadLine(), out int editar);
                    switch (editar)
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
            Console.WriteLine("Dar de baja a un equipo.");
            Console.WriteLine(@"
Dar de baja a:
    1. Un equipo.
    2. Un jugador. 
");
            Int32.TryParse(Console.ReadLine(), out int tipo);
            switch (tipo)
            {
                case 1:
                    break;
                case 2:
                    jugadores.EliminarJugador();
                    break;
            }
        }

        static string PedirNombre()
        {
            Console.WriteLine("Dime el nombre del equipo: ");
            return Console.ReadLine().ToLower();
        }

        static int PedirNumero()
        {
            int numero;

            do
            {
                numero = Int32.TryParse(Console.ReadLine(), out int result) ? result : -1;

                if (numero == -1)
                    Console.WriteLine("Error: Introduce un numero");
            }
            while (numero != -1);
            
            return numero;
        }

    }
}
