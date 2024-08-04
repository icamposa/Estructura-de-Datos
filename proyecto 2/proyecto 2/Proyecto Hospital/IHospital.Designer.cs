namespace Proyecto_Hospital
{
    partial class IHospital
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

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
            this.txtNombre.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNombre.Location = new System.Drawing.Point(24, 183);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(110, 29);
            this.txtNombre.TabIndex = 0;
            // 
            // cmbGravedad
            // 
            this.cmbGravedad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbGravedad.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbGravedad.FormattingEnabled = true;
            this.cmbGravedad.Location = new System.Drawing.Point(149, 182);
            this.cmbGravedad.Name = "cmbGravedad";
            this.cmbGravedad.Size = new System.Drawing.Size(121, 30);
            this.cmbGravedad.TabIndex = 1;
            // 
            // btnAgregarPaciente
            // 
            this.btnAgregarPaciente.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAgregarPaciente.Location = new System.Drawing.Point(123, 318);
            this.btnAgregarPaciente.Name = "btnAgregarPaciente";
            this.btnAgregarPaciente.Size = new System.Drawing.Size(110, 29);
            this.btnAgregarPaciente.TabIndex = 2;
            this.btnAgregarPaciente.Text = "Agregar Paciente";
            this.btnAgregarPaciente.UseVisualStyleBackColor = true;
            this.btnAgregarPaciente.Click += new System.EventHandler(this.btnAgregarPaciente_Click_1);
            // 
            // btnAtenderPaciente
            // 
            this.btnAtenderPaciente.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAtenderPaciente.Location = new System.Drawing.Point(303, 318);
            this.btnAtenderPaciente.Name = "btnAtenderPaciente";
            this.btnAtenderPaciente.Size = new System.Drawing.Size(110, 32);
            this.btnAtenderPaciente.TabIndex = 3;
            this.btnAtenderPaciente.Text = "Atender Paciente";
            this.btnAtenderPaciente.UseVisualStyleBackColor = true;
            this.btnAtenderPaciente.Click += new System.EventHandler(this.btnAtenderPaciente_Click_1);
            // 
            // lstColaEspera
            // 
            this.lstColaEspera.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(250)))), ((int)(((byte)(205))))); // LemonChiffon
            this.lstColaEspera.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstColaEspera.FormattingEnabled = true;
            this.lstColaEspera.ItemHeight = 22;
            this.lstColaEspera.Location = new System.Drawing.Point(24, 12);
            this.lstColaEspera.Name = "lstColaEspera";
            this.lstColaEspera.Size = new System.Drawing.Size(389, 146);
            this.lstColaEspera.TabIndex = 4;
            // 
            // lblEstadistica
            // 
            this.lblEstadistica.AutoSize = true;
            this.lblEstadistica.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEstadistica.Location = new System.Drawing.Point(24, 242);
            this.lblEstadistica.Name = "lblEstadistica";
            this.lblEstadistica.Size = new System.Drawing.Size(78, 22);
            this.lblEstadistica.TabIndex = 5;
            this.lblEstadistica.Text = "Estadísticas";
            this.lblEstadistica.Click += new System.EventHandler(this.lblEstadistica_Click);
            // 
            // IHospital
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(444, 362);
            this.Controls.Add(this.lblEstadistica);
            this.Controls.Add(this.lstColaEspera);
            this.Controls.Add(this.btnAtenderPaciente);
            this.Controls.Add(this.btnAgregarPaciente);
            this.Controls.Add(this.cmbGravedad);
            this.Controls.Add(this.txtNombre);
            this.Name = "IHospital";
            this.Text = "Hospital";
            this.Load += new System.EventHandler(this.IHospital_Load);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.ComboBox cmbGravedad;
        private System.Windows.Forms.Button btnAgregarPaciente;
        private System.Windows.Forms.Button btnAtenderPaciente;
        private System.Windows.Forms.ListBox lstColaEspera;
        private System.Windows.Forms.Label lblEstadistica;
    }
}
