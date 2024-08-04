using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Proyecto_Hospital.Clases.Pacientes;

namespace Proyecto_Hospital.Clases
{
    //Aquí se maneja la atención de pacientes
    public class Hospital : IEstadisticas
    {
        private Queue<Pacientes> colaDePacientes; //Cola principal para el orden de llegada y atención
        private List<Pacientes> pacientesAtendidos; //Lista de pacientes que ya han sido atendidos

        public Hospital() //Se inicializa una nueva instancia de la clase Hospital
        {
            colaDePacientes = new Queue<Pacientes>();
            pacientesAtendidos = new List<Pacientes>();
        }

        //Registro de llegada de pacientes
        public void LlegadaPaciente(string nombre, Pacientes.NivelDeGravedad gravedad)
        {
            Pacientes nuevoPaciente = new Pacientes(nombre, gravedad, DateTime.Now);
            colaDePacientes.Enqueue(nuevoPaciente); //Se añade a la cola de llegada
        }

        public void AtenderPaciente()
        {
            if (colaDePacientes.Count == 0)
                return;

            //Obtenemos el siguiente paciente a atender basándonos en la prioridad de gravedad
            Pacientes pacienteAAtender = ObtenerSiguientePaciente();

            if (pacienteAAtender != null)
            {
                pacienteAAtender.TiempoDeAtencion = DateTime.Now;
                pacientesAtendidos.Add(pacienteAAtender);
                EliminarDeCola(pacienteAAtender);
            }
        }

        private Pacientes ObtenerSiguientePaciente()
        {
            return colaDePacientes
                .OrderBy(p => p.Gravedad) // Ordenar por nivel de gravedad (Urgencia primero)
                .ThenBy(p => p.TiempoDeLlegada) // Ordenar por tiempo de llegada
                .FirstOrDefault();
        }

        private void EliminarDeCola(Pacientes paciente)
        {
            // Eliminar paciente de la cola de llegada
            colaDePacientes = new Queue<Pacientes>(colaDePacientes.Where(p => p != paciente));
        }

        public double CalcularTiempoEsperaPromedio()
        {
            if (pacientesAtendidos.Count == 0) return 0;
            double tiempoTotalEspera = pacientesAtendidos.Sum(p => (p.TiempoDeAtencion - p.TiempoDeLlegada).TotalMinutes);
            return Math.Round(tiempoTotalEspera / pacientesAtendidos.Count, 0); // Redondear a minutos completos
        }

        //Se determina la cantidad de pacientes antendidos
        public int ObtenerCantidadPacientesAtendidos(Pacientes.NivelDeGravedad gravedad)
        {
            return pacientesAtendidos.Count(p => p.Gravedad == gravedad);
        }

        //Se obtiene el número de pacientes en la cola
        public IEnumerable<Pacientes> ObtenerPacientesEnCola()
        {
            return colaDePacientes;
        }

        public bool HayPacientesEnEspera()
        {
            return colaDePacientes.Count > 0;
        }
    }

    //Se determinan las estadísticas del hospital
    public interface IEstadisticas
    {
        double CalcularTiempoEsperaPromedio();
        int ObtenerCantidadPacientesAtendidos(Pacientes.NivelDeGravedad gravedad);
    }
}