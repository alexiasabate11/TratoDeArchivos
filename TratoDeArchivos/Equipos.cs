using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TratoDeArchivos
{
    internal class Equipos
    {
        static string nombreEquipo;
        static int puntuacionEquipo;

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

        public void MostrarInformacion()
        {
            Console.WriteLine($"Equipo: {nombreEquipo}, Puntuacion: {puntuacionEquipo}");
        }

    }
}
