using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Hospital.Clases
{
    //Se crea la cola de pacientes
    public class ColaDePacientes
    {
        private Queue<Pacientes> cola = new Queue<Pacientes>();

        public void AgregarPaciente(Pacientes paciente)
        {
            cola.Enqueue(paciente); //Se agregan los pacientes a la cola
        }

        public Pacientes ObtenerSiguientePaciente()
        {
            return cola.Count > 0 ? cola.Dequeue() : null; //Se determina el siguiente paciente en la cola
        }

        public int ObtenerCantidadPacientes()
        {
            return cola.Count; //Se obtiene la cantidad de pacientes en la cola
        }

        public IEnumerable<Pacientes> ObtenerPacientesEnCola()
        {
            return cola;
        }

        public bool TienePacientes()
        {
            return cola.Count > 0; //Se determina si la cola está vacía o no
        }
    }
}
