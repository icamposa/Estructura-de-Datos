using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Hospital.Clases
{
    
    public class ColaDePacientes
    {
        private Queue<Pacientes> cola = new Queue<Pacientes>();

        public void AgregarPaciente(Pacientes paciente)
        {
            cola.Enqueue(paciente);
        }

        public Pacientes ObtenerSiguientePaciente()
        {
            return cola.Count > 0 ? cola.Dequeue() : null;
        }

        public int ObtenerCantidadPacientes()
        {

            return cola.Count;
        }

        public IEnumerable<Pacientes> ObtenerPacientesEnCola()
        {
            return cola;

        }
        public bool TienePacientes()
        { 
            return cola.Count > 0;
        }



    }

    public class PilaDeClasificacion
    {
        private Stack<Pacientes> pila = new Stack<Pacientes>();

        public void ClasificarPaciente(Pacientes paciente)
        {
            pila.Push(paciente);
        }

        public Pacientes AtenderPaciente()
        {
            return pila.Count > 0 ? pila.Pop() : null;
        }

        public int ObtenerCantidadPacientes()
        {
            return pila.Count;
        }

   
    }

    /*public class ControlCola
    {
        private Queue<Pacientes> colaPacientes;

        public ControlCola()
        {
            colaPacientes = new Queue<Pacientes>();
        }

        public void AgregarPaciente(Pacientes paciente)
        {
            colaPacientes.Enqueue(paciente);
        }

        public IEnumerable<Pacientes> ObtenerPacientesEnCola()
        {
            return colaPacientes;
        }

        public Pacientes AtenderPaciente()
        {
            if (colaPacientes.Count > 0)
            {
                return colaPacientes.Dequeue();
            }
            return null; // o lanzar una excepción
        }
        public bool TienePacientes()
        {
            return colaPacientes.Count > 0;
        }
    }
    */
}
