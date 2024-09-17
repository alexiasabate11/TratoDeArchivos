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
        List<Jugadores> jugadoresAll = new List<Jugadores>();
        string rutaArchivo = @"C:\Users\alexi\OneDrive\Escriptori\jugadoresFutbol.txt";

        public Jugadores(int Dorsal, string NombreJugador, string NombreEquipo) 
        {
            dorsal = Dorsal;
            nombreJugador = NombreJugador;
            nombreEquipo = NombreEquipo;
        }

        public Jugadores() { }

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

        public List<Jugadores> JugadoresAll
        {
            get => jugadoresAll;
            set => jugadoresAll = value;
        }

        public bool ComprobarSiExisteArchivoJugadores()
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
                    jugadoresAll.Add(jugador);
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

            Jugadores jugadorNuevo = new Jugadores(PedirNumeroDorsal(), PedirNombreJugador(), PedirNombreEquipo());
            jugadoresAll.Add(jugadorNuevo);

            Console.WriteLine();
        }

        public void EliminarJugador()
        {
            Console.WriteLine("Dar de baja a un jugador.");

            Jugadores jugadorAEliminar = jugadoresAll.Find(j => j.Nombrejugador == PedirNombreJugador());
            jugadoresAll.Remove(jugadorAEliminar);

            Console.WriteLine();
        }

        public void EditarDorsal()
        {
            Console.WriteLine("Modificar la dorsal de un equipo.");
            Jugadores jugadorAEditar = jugadoresAll.Find(j => j.Nombrejugador == PedirNombreJugador());
            jugadorAEditar.Dorsal = PedirNumeroDorsal();
        }

        public void EditarEquipo()
        {
            Console.WriteLine("Modificar la dorsal de un equipo.");
            Jugadores jugadorAEditar = jugadoresAll.Find(j => j.Nombrejugador == PedirNombreJugador());
            jugadorAEditar.NombreEquipo = PedirNombreEquipo();
        }

        static string PedirNombreJugador()
        {
            Console.WriteLine("Nombre del jugador: ");
            return Console.ReadLine().ToLower();
        }

        static string PedirNombreEquipo()
        {
            Console.WriteLine("Nombre del equipo: ");
            return Console.ReadLine().ToLower();
        }

        static int PedirNumeroDorsal() 
        {
            Console.WriteLine("Numero de dorsal: ");
            return Int32.Parse(Console.ReadLine()); ;
        }

        public void GuardarArchivoJugadores()
        {
            try
            {
                StreamWriter sw = new StreamWriter(rutaArchivo);

                foreach (Jugadores jugador in jugadoresAll)
                    sw.WriteLine("{0},{1},{2}", jugador.Dorsal, jugador.Nombrejugador, jugador.NombreEquipo);

                sw.Close();

                Console.WriteLine("Guardado!");
                Console.WriteLine();
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
        }
    }
}
