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
        static Dictionary<string, int> equipos = new Dictionary<string, int>();

        static string rutaArchivo = @"C:\Users\alexi\OneDrive\Escriptori\ligaFutbol.txt";


        static void Main(string[] args)
        {



            Console.WriteLine();
            do
            {
                switch (!ComprobarSiExisteArchivo() ? 1 : Menu())
                {
                    case 1:
                        IntroducirNuevoEquipo();
                        break;
                    case 2:
                        EliminarEquipo();
                        break;
                    case 3:
                        EditarPuntuacionEquipo();
                        break;
                    case 4:
                        MostrarEquiposYPuntuacion();
                        break;
                    case 0:
                        return;
                }
                GuardarArchivo();
                Console.WriteLine();
            } 
            while(true);
        }

        static int Menu()
        {
            Console.WriteLine(@"
Que quieres hacer?
    1. Dar de alta a un equipo
    2. Dar de baja a un equipo
    3. Modificar la puntuación
    4. Ver todos los equipos y su puntuacion
    0. Salir
    ");
            return PedirNumero();
        }

        static bool ComprobarSiExisteArchivo()
        {
            if (!File.Exists(rutaArchivo))
                return false;
            
            try
            {
                String linea;
                StreamReader sr = new StreamReader(rutaArchivo);
                while ((linea = sr.ReadLine()) != null)
                {
                    string[] equipo = linea.Split(',');
                    equipos.Add(equipo[0], Int32.Parse(equipo[1]));
                }
                sr.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
                Console.ReadKey();
            }

            return true;
        }
        static void IntroducirNuevoEquipo()
        {
            Console.WriteLine("Dar de alta a un equipo.");
            string nombreEquipo = PedirNombreEquipo();

            equipos.Add(nombreEquipo, 0);
        }

        static void EditarPuntuacionEquipo()
        {
            Console.WriteLine("Modificar la puntuacion de un equipo.");
            string equipo = PedirNombreEquipo();

            Console.WriteLine();

            Console.WriteLine("Que puntuación le quieres poner?");
            int puntuacion = PedirNumero();

            Console.WriteLine();

            equipos[equipo] = puntuacion;
        }

        static void EliminarEquipo()
        {
            Console.WriteLine("Dar de baja a un equipo.");
            string equipo = PedirNombreEquipo();

            Console.WriteLine();

            equipos.Remove(equipo);
        }

        static void GuardarArchivo()
        {
            try
            {
                StreamWriter sw = new StreamWriter(rutaArchivo);

                foreach (KeyValuePair<string, int> equipo in equipos)
                    sw.WriteLine("{0},{1}",equipo.Key, equipo.Value);

                sw.Close();

                Console.WriteLine("Guardado!");
                Console.WriteLine();
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
        }

        static string PedirNombreEquipo()
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

        static void MostrarEquiposYPuntuacion()
        {
            foreach (KeyValuePair<string, int> equipo in equipos)
                Console.WriteLine("{0},{1}",equipo.Key,equipo.Value);

            Console.WriteLine();
        }
    }
}
