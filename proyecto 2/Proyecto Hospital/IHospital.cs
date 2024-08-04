using Proyecto_Hospital.Clases;
using System;
using System.Drawing;
using System.Windows.Forms;
using static Proyecto_Hospital.Clases.Pacientes;

namespace Proyecto_Hospital
{
    public partial class IHospital : Form
    {
        private Hospital hospital;

        public IHospital()
        {
            InitializeComponent();
            cmbGravedad.DataSource = Enum.GetValues(typeof(Pacientes.NivelDeGravedad));
            hospital = new Hospital();

            // Establecer la fuente para el formulario y todos sus controles
            this.Font = new Font("Times New Roman", 10);

            // Establecer colores de fondo pastel para controles
            this.BackColor = Color.FromArgb(144, 238, 144); // LightGreen
            lstColaEspera.BackColor = Color.FromArgb(240, 248, 255); // AliceBlue
            txtNombre.BackColor = Color.FromArgb(255, 245, 238); // Seashell
            cmbGravedad.BackColor = Color.FromArgb(255, 250, 240); // FloralWhite
            lblEstadistica.BackColor = Color.FromArgb(144, 238, 144); // LightGreen

            lstColaEspera.DrawMode = DrawMode.OwnerDrawFixed; // Configurar ListBox para dibujo personalizado
            lstColaEspera.DrawItem += lstColaEspera_DrawItem; // Suscribirse al evento DrawItem
        }

        private void IHospital_Load(object sender, EventArgs e)
        {
            ActualizarEstadisticas();
        }

        private void ActualizarCola()
        {
            lstColaEspera.Items.Clear(); // Limpiar lista de espera
            foreach (var paciente in hospital.ObtenerPacientesEnCola())
            {
                // Añadir paciente a la lista de espera
                lstColaEspera.Items.Add(paciente);
            }
        }

        private void ActualizarEstadisticas()
        {
            lblEstadistica.Text = $"Tiempo de espera promedio: {hospital.CalcularTiempoEsperaPromedio()} minutos\n" +
                                   $"Pacientes atendidos (Urgencia): {hospital.ObtenerCantidadPacientesAtendidos(Pacientes.NivelDeGravedad.Urgencia)}\n" +
                                   $"Pacientes atendidos (Prioridad Normal): {hospital.ObtenerCantidadPacientesAtendidos(Pacientes.NivelDeGravedad.PrioridadNormal)}\n" +
                                   $"Pacientes atendidos (Baja Prioridad): {hospital.ObtenerCantidadPacientesAtendidos(Pacientes.NivelDeGravedad.BajaPrioridad)}";
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

            Pacientes.NivelDeGravedad gravedad = (Pacientes.NivelDeGravedad)cmbGravedad.SelectedItem;
            hospital.LlegadaPaciente(nombre, gravedad); // Añadir paciente al hospital
            MessageBox.Show($"Paciente {nombre} de {gravedad} agregado a la cola.");
            ActualizarCola();
        }

        private void btnAtenderPaciente_Click_1(object sender, EventArgs e)
        {
            if (hospital.HayPacientesEnEspera())
            {
                hospital.AtenderPaciente(); // Atender paciente
                ActualizarCola();
                ActualizarEstadisticas();
            }
            else
            {
                MessageBox.Show("La cola no tiene pacientes.");
            }
        }

        private void lstColaEspera_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index < 0)
                return;

            // Obtener el paciente actual
            Pacientes paciente = (Pacientes)lstColaEspera.Items[e.Index];

            // Configurar el color del texto según el nivel de gravedad
            Color textColor;
            switch (paciente.Gravedad)
            {
                case Pacientes.NivelDeGravedad.Urgencia:
                    textColor = Color.Red;
                    break;
                case Pacientes.NivelDeGravedad.PrioridadNormal:
                    textColor = Color.Orange;
                    break;
                case Pacientes.NivelDeGravedad.BajaPrioridad:
                    textColor = Color.Green;
                    break;
                default:
                    textColor = Color.Black;
                    break;
            }

            e.DrawBackground();
            using (Brush backgroundBrush = new SolidBrush(Color.FromArgb(255, 250, 205))) // LemonChiffon
            {
                e.Graphics.FillRectangle(backgroundBrush, e.Bounds);
            }

            using (Font font = new Font("Times New Roman", 10))
            using (Brush brush = new SolidBrush(textColor))
            {
                e.Graphics.DrawString($"{paciente.Nombre} - {paciente.Gravedad} - {paciente.TiempoDeLlegada:HH:mm}", font, brush, e.Bounds);
            }

            // Dibujar el borde del elemento
            e.DrawFocusRectangle();
        }

        private void lblEstadistica_Click(object sender, EventArgs e)
        {
            // Aquí puedes agregar el comportamiento deseado para cuando se haga clic en lblEstadistica
        }
    }
}
