using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TratoDeArchivos
{
    internal class Jugadores
    {
        int dorsal;
        string nombrejugador;
        string nombreEquipo;

        public int Dorsal { get => dorsal; set => dorsal = value; }
        public string Nombrejugador { get => nombrejugador; set => nombrejugador = value; }
        public string NombreEquipo { get => nombreEquipo; set => nombreEquipo = value; }
    }
}
