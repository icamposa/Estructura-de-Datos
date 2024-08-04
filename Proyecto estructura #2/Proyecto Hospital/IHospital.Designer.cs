namespace Proyecto_Hospital
{
    partial class IHospital
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.cmbGravedad = new System.Windows.Forms.ComboBox();
            this.btnAgregarPaciente = new System.Windows.Forms.Button();
            this.btnAtenderPaciente = new System.Windows.Forms.Button();
            this.lstColaEspera = new System.Windows.Forms.ListBox();
            this.lblEstadistica = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(34, 148);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(110, 20);
            this.txtNombre.TabIndex = 0;
            // 
            // cmbGravedad
            // 
            this.cmbGravedad.FormattingEnabled = true;
            this.cmbGravedad.Location = new System.Drawing.Point(164, 147);
            this.cmbGravedad.Name = "cmbGravedad";
            this.cmbGravedad.Size = new System.Drawing.Size(121, 21);
            this.cmbGravedad.TabIndex = 1;
            // 
            // btnAgregarPaciente
            // 
            this.btnAgregarPaciente.Location = new System.Drawing.Point(34, 272);
            this.btnAgregarPaciente.Name = "btnAgregarPaciente";
            this.btnAgregarPaciente.Size = new System.Drawing.Size(110, 29);
            this.btnAgregarPaciente.TabIndex = 2;
            this.btnAgregarPaciente.Text = "Agregar Paciente";
            this.btnAgregarPaciente.UseVisualStyleBackColor = true;
            this.btnAgregarPaciente.Click += new System.EventHandler(this.btnAgregarPaciente_Click_1);
            // 
            // btnAtenderPaciente
            // 
            this.btnAtenderPaciente.Location = new System.Drawing.Point(34, 331);
            this.btnAtenderPaciente.Name = "btnAtenderPaciente";
            this.btnAtenderPaciente.Size = new System.Drawing.Size(110, 32);
            this.btnAtenderPaciente.TabIndex = 3;
            this.btnAtenderPaciente.Text = "Atender Paciente";
            this.btnAtenderPaciente.UseVisualStyleBackColor = true;
            this.btnAtenderPaciente.Click += new System.EventHandler(this.btnAtenderPaciente_Click_1);
            // 
            // lstColaEspera
            // 
            this.lstColaEspera.FormattingEnabled = true;
            this.lstColaEspera.Location = new System.Drawing.Point(303, 30);
            this.lstColaEspera.Name = "lstColaEspera";
            this.lstColaEspera.Size = new System.Drawing.Size(215, 173);
            this.lstColaEspera.TabIndex = 4;
            // 
            // lblEstadistica
            // 
            this.lblEstadistica.AutoSize = true;
            this.lblEstadistica.Location = new System.Drawing.Point(45, 30);
            this.lblEstadistica.Name = "lblEstadistica";
            this.lblEstadistica.Size = new System.Drawing.Size(35, 13);
            this.lblEstadistica.TabIndex = 5;
            this.lblEstadistica.Text = "label2";
            // 
            // IHospital
            // 
            this.ClientSize = new System.Drawing.Size(553, 419);
            this.Controls.Add(this.lblEstadistica);
            this.Controls.Add(this.lstColaEspera);
            this.Controls.Add(this.btnAtenderPaciente);
            this.Controls.Add(this.btnAgregarPaciente);
            this.Controls.Add(this.cmbGravedad);
            this.Controls.Add(this.txtNombre);
            this.Name = "IHospital";
            this.Load += new System.EventHandler(this.IHospital_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.ComboBox cmbGravedad;
        private System.Windows.Forms.Button btnAgregarPaciente;
        private System.Windows.Forms.Button btnAtenderPaciente;
        private System.Windows.Forms.ListBox lstColaEspera;
        private System.Windows.Forms.Label lblEstadistica;
    }
}