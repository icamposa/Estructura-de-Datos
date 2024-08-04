using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Hospital.Clases
{
    public class Pacientes
    { 
        public string Nombre { get; set; }
        public NivelDeGravedad Gravedad { get; set; }
        public DateTime TiempoDeLlegada { get; set; }
        public DateTime TiempoDeAtencion { get; set; }

        //Inicialización de una nueva instancia de la clase pacientes
        public Pacientes(string nombre, NivelDeGravedad gravedad, DateTime tiempoDeLlegada)
        {
            Nombre = nombre;
            Gravedad = gravedad;
            TiempoDeLlegada = tiempoDeLlegada;
        }

        public enum NivelDeGravedad //Niveles de gravedad a valorar
        {
            Urgencia,
            PrioridadNormal,
            BajaPrioridad
        }
    }
}
