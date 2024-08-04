using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Hospital.Clases
{
    namespace Proyecto_Hospital.Clases
    {
        //Se crea la pila en la que se clasifica el nivel de atención de los pacientes
        public class PilaDeClasificacion
        {
            private Stack<Pacientes> pila = new Stack<Pacientes>();

            public void ClasificarPaciente(Pacientes paciente)
            {
                pila.Push(paciente); //Se introduce el paciente
            }

            public Pacientes AtenderPaciente()
            {
                return pila.Count > 0 ? pila.Pop() : null; //Se atiende el paciente
            }

            public int ObtenerCantidadPacientes()
            {
                return pila.Count; //Se obtiene la cantidad de pacientes en la pila
            }
        }
    }
}
