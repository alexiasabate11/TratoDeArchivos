using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TratoDeArchivos
{
    internal class Equipos
    {
        static string nombreEquipo;
        static int puntuacionEquipo;
        List<Equipos> equiposAll;
        static string rutaArchivo = @"C:\Users\alexi\OneDrive\Escriptori\equiposFutbol.txt";

        public Equipos(string NombreEquipo, int PuntuacionEquipo)
        {
            nombreEquipo = NombreEquipo;
            puntuacionEquipo = PuntuacionEquipo;
        }

        public string NombreEquipo
        {
            get => nombreEquipo;
            set => nombreEquipo = value;
        }

        public int PuntuacionEquipo
        {
            get => puntuacionEquipo;
            set => puntuacionEquipo = value;
        }

        public List<Equipos> EquiposAll
        {
            get => equiposAll;
            set => equiposAll = value;
        }

        static string PedirNombreEquipo()
        {
            Console.WriteLine("Nombre del equipo: ");
            return Console.ReadLine().ToLower();
        }

        static int PedirPuntuacionEquipo()
        {
            Console.WriteLine("Número del puntuación: ");
            return Int32.Parse(Console.ReadLine());
        }

        public bool ComprobarSiExisteArchivoEquipos()
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
                    Equipos equipos = new Equipos(datos[0], Int32.Parse(datos[1]));
                    equiposAll.Add(equipos);
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

        public void IntroducirNuevoEquipo()
        {
            Console.WriteLine("Dar de alta a un jugador");

            Equipos equipoNuevo = new Equipos(PedirNombreEquipo(), PedirPuntuacionEquipo());
            equiposAll.Add(equipoNuevo);

            Console.WriteLine();
        }

        public void EliminarEquipo()
        {
            Console.WriteLine("Dar de baja a un jugador.");

            Equipos equipoEliminar = equiposAll.Find(j => j.NombreEquipo == PedirNombreEquipo());
            equiposAll.Remove(equipoEliminar);

            Console.WriteLine();
        }

        public void EditarPuntuacion()
        {
            Console.WriteLine("Modificar la dorsal de un equipo.");
            Equipos equipoAEditar = equiposAll.Find(j => j.NombreEquipo == PedirNombreEquipo());
            equipoAEditar.PuntuacionEquipo = PedirPuntuacionEquipo();
        }

        public void EditarEquipo()
        {
            Console.WriteLine("Modificar la dorsal de un equipo.");
            Equipos equipoAEditar = equiposAll.Find(j => j.NombreEquipo == PedirNombreEquipo());
            equipoAEditar.NombreEquipo = PedirNombreEquipo();
        }

        public void GuardarArchivoJugadores()
        {
            try
            {
                StreamWriter sw = new StreamWriter(rutaArchivo);

                foreach (Equipos equipo in equiposAll)
                    sw.WriteLine("{0},{1}", equipo.NombreEquipo, equipo.PuntuacionEquipo);

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
