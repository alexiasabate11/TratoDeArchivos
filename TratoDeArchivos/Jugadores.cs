using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TratoDeArchivos
{
    internal class Jugadores
    {
        int dorsal;
        string nombreJugador;
        string nombreEquipo;
        List<Jugadores> jugadores;

        public Jugadores(int Dorsal, string NombreJugador, string NombreEquipo) 
        {
            dorsal = Dorsal;
            nombreJugador = NombreJugador;
            nombreEquipo = NombreEquipo;
        }

        public int Dorsal 
        { 
            get => dorsal; 
            set => dorsal = value; 
        }

        public string Nombrejugador 
        { 
            get => nombreJugador; 
            set => nombreJugador = value; 
        }

        public string NombreEquipo 
        { 
            get => nombreEquipo; 
            set => nombreEquipo = value; 
        }

        public bool ComprobarSiExisteArchivoJugadores(string rutaArchivo)
        {
            if (!File.Exists(rutaArchivo))
                return false;

            try
            {
                String linea;
                StreamReader sr = new StreamReader(rutaArchivo);
                while ((linea = sr.ReadLine()) != null)
                {
                    string[] datos = linea.Split(',');
                    Jugadores jugador = new Jugadores(Int32.Parse(datos[0]), datos[1], datos[2]);
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

        public void IntroducirNuevoJugador()
        {
            Console.WriteLine("Dar de alta a un jugador");

            Console.WriteLine("Nombre del jugador:");
            string nombre = Console.ReadLine();

            Console.WriteLine("Numero de dorsal del jugador:");
            int dorsal = Int32.Parse(Console.ReadLine());

            Console.WriteLine("Nombre del equipo del jugador:");
            string equipo = Console.ReadLine();

            Jugadores jugadorNuevo = new Jugadores(dorsal, nombre, equipo);
            jugadores.Add(jugadorNuevo);
        }

        public void Eliminar()
        {
            Console.WriteLine("Dar de baja a un jugador.");

            Console.WriteLine("Nombre del jugador:");
            Jugadores jugadorAEliminar = jugadores.Find(j => j.Nombrejugador == Console.ReadLine());
            jugadores.Remove(jugadorAEliminar);

            Console.WriteLine();
        }
    }
}
