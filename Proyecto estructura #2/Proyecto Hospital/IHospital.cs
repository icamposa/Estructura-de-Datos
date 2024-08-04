using Proyecto_Hospital.Clases;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Proyecto_Hospital.Clases.Pacientes;

namespace Proyecto_Hospital
{
    public partial class IHospital : Form
    {
        public IHospital()
        {
            InitializeComponent();
            cmbGravedad.DataSource = Enum.GetValues(typeof(NivelDeGravedad));

        }

        private void IHospital_Load(object sender, EventArgs e)
        {
            ActualizarEstadisticas();
        }

        Hospital hospital = new Hospital();
        PilaDeClasificacion control_pila = new PilaDeClasificacion();
        ColaDePacientes control_cola = new ColaDePacientes();

        private void btnAgregarPaciente_Click(object sender, EventArgs e)
        {
           
        }

        private void btnAtenderPaciente_Click(object sender, EventArgs e)
        {
            hospital.AtenderPaciente();
            ActualizarCola();
            ActualizarEstadisticas();
        }

        private void ActualizarCola()
        {
            lstColaEspera.Items.Clear();
            foreach (var paciente in control_cola.ObtenerPacientesEnCola())
            {
                lstColaEspera.Items.Add($"{paciente.Nombre} - {paciente.Gravedad} - {paciente.TiempoDeLlegada.TimeOfDay}");
            }
        }

        private void ActualizarEstadisticas()
        {
            lblEstadistica.Text = $"Tiempo de espera promedio: {hospital.CalcularTiempoEsperaPromedio():F2} minutos\n" +
                                   $"Pacientes atendidos (Urgencia): {hospital.ObtenerCantidadPacientesAtendidos(NivelDeGravedad.Urgencia)}\n" +
                                   $"Pacientes atendidos (Prioridad Normal): {hospital.ObtenerCantidadPacientesAtendidos(NivelDeGravedad.PrioridadNormal)}\n" +
                                   $"Pacientes atendidos (Baja Prioridad): {hospital.ObtenerCantidadPacientesAtendidos(NivelDeGravedad.BajaPrioridad)}";
        }

        private void btnAgregarPaciente_Click_1(object sender, EventArgs e)
        {
            string nombre = txtNombre.Text;
            if (string.IsNullOrEmpty(nombre))
            {
                MessageBox.Show("El nombre del paciente no puede estar vacío.");
                return;
            }

            if (cmbGravedad.SelectedItem == null)
            {
                MessageBox.Show("Por favor, seleccione un nivel de gravedad.");
                return;
            }

            NivelDeGravedad gravedad = (NivelDeGravedad)cmbGravedad.SelectedItem;
            DateTime dateTime = DateTime.Now;
            control_cola.AgregarPaciente(new Pacientes(nombre, gravedad, DateTime.Now));
            hospital.ClasificarPaciente(new Pacientes(nombre, gravedad, DateTime.Now));
            MessageBox.Show($"Paciente {nombre} con gravedad {gravedad} agregado a la cola.");
            ActualizarCola();
        }

        private void btnAtenderPaciente_Click_1(object sender, EventArgs e)
        {
            if (control_cola.TienePacientes())
            {
                hospital.AtenderPaciente();
                ActualizarCola();
                ActualizarEstadisticas();
            }
            else
            {
                MessageBox.Show("La cola no tiene pacientes.");
            }
        }
    }
}