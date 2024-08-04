using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Proyecto_Hospital.Clases.Pacientes;

namespace Proyecto_Hospital.Clases
{
    public class Hospital : IEstadisticas
    {
        private ColaDePacientes colaDePacientes = new ColaDePacientes();
        private PilaDeClasificacion pilaDeUrgencia = new PilaDeClasificacion();
        private PilaDeClasificacion pilaDePrioridadNormal = new PilaDeClasificacion();
        private PilaDeClasificacion pilaDeBajaPrioridad = new PilaDeClasificacion();

        private List<Pacientes> pacientesAtendidos = new List<Pacientes>();

        public void LlegadaPaciente(string nombre, NivelDeGravedad gravedad, DateTime dateTime)
        {
            Pacientes nuevoPaciente = new Pacientes(nombre, gravedad, dateTime);
            colaDePacientes.AgregarPaciente(nuevoPaciente);
           ClasificarPaciente(nuevoPaciente);
        }

        public void ClasificarPaciente(Pacientes paciente)
        {
            switch (paciente.Gravedad)
            {
                case NivelDeGravedad.Urgencia:
                    pilaDeUrgencia.ClasificarPaciente(paciente);
                    break;
                case NivelDeGravedad.PrioridadNormal:
                    pilaDePrioridadNormal.ClasificarPaciente(paciente);
                    break;
                case NivelDeGravedad.BajaPrioridad:
                    pilaDeBajaPrioridad.ClasificarPaciente(paciente);
                    break;
            }
        }

        public void AtenderPaciente()
        {
            Pacientes paciente = null;

            if (pilaDeUrgencia.ObtenerCantidadPacientes() > 0)
                paciente = pilaDeUrgencia.AtenderPaciente();
            else if (pilaDePrioridadNormal.ObtenerCantidadPacientes() > 0)
                paciente = pilaDePrioridadNormal.AtenderPaciente();
            else if (pilaDeBajaPrioridad.ObtenerCantidadPacientes() > 0)
                paciente = pilaDeBajaPrioridad.AtenderPaciente();

            if (paciente != null)
            {
                paciente.TiempoDeAtencion = DateTime.Now;
                pacientesAtendidos.Add(paciente);
            }
        }

        public double CalcularTiempoEsperaPromedio()
         {
             if (pacientesAtendidos.Count == 0) return 0;
             double tiempoTotalEspera = pacientesAtendidos.Sum(p => (p.TiempoDeAtencion - p.TiempoDeLlegada).TotalMinutes);
             return tiempoTotalEspera / pacientesAtendidos.Count;
         }

         public int ObtenerCantidadPacientesAtendidos(NivelDeGravedad gravedad)
         {
             return pacientesAtendidos.Count(p => p.Gravedad == gravedad);
         }
    }

    public interface IEstadisticas
    {
        double CalcularTiempoEsperaPromedio();
        int ObtenerCantidadPacientesAtendidos(NivelDeGravedad gravedad);
    }
}
