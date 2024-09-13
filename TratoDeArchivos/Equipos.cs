using System;

namespace TratoDeArchivos
{
    public class Equipos
    {
        private string nombreEquipo;
        private int puntuacionEquipo;

        public Equipos(string NombreEquipo, int PuntuacionEquipo)
        {
            this.nombreEquipo = NombreEquipo;
            this.puntuacionEquipo = PuntuacionEquipo;
        }

        public string NombreEquipo
        {
            get { return nombreEquipo; }
            set { nombreEquipo = value; }
        }

        public int PuntuacionEquipo
        { 
            get { return puntuacionEquipo; }
            set
            {
                if (value >=0)
                    puntuacionEquipo = value;
                else
                    throw new ArgumentException("La puntuación no puede ser negativa");
            }
        }

        public void MostrarInformacion()
        {
            Console.WriteLine($"Equipo: {nombreEquipo}, Puntuacion: {puntuacionEquipo}");
        }
    }
}