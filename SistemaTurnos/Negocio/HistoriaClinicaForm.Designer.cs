namespace SistemaTurnos
{
    partial class HistoriaClinicaForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnlMainContainer = new System.Windows.Forms.Panel();
            this.grpCondicionesBase = new SistemaTurnos.DarkGroupBox();
            this.btnGuardarCondiciones = new System.Windows.Forms.Button();
            this.txtObservacion = new System.Windows.Forms.TextBox();
            this.txtAntecedente = new System.Windows.Forms.TextBox();
            this.txtAlergias = new System.Windows.Forms.TextBox();
            this.lblObservaciones = new System.Windows.Forms.Label();
            this.lblAntecedentes = new System.Windows.Forms.Label();
            this.lblAlergias = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.grpHistorial = new SistemaTurnos.DarkGroupBox();
            this.dgvHistoriaClinica = new System.Windows.Forms.DataGridView();
            this.colFecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAntecedente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colObservacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.grpPaciente = new SistemaTurnos.DarkGroupBox();
            this.lblPacienteTelefono = new System.Windows.Forms.Label();
            this.lblPacienteFecNac = new System.Windows.Forms.Label();
            this.lblTitTelefono = new System.Windows.Forms.Label();
            this.lblTitFecNac = new System.Windows.Forms.Label();
            this.lblPacienteDni = new System.Windows.Forms.Label();
            this.lblTitDni = new System.Windows.Forms.Label();
            this.lblPacienteNombre = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.pnlMainContainer.SuspendLayout();
            this.grpCondicionesBase.SuspendLayout();
            this.grpHistorial.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHistoriaClinica)).BeginInit();
            this.grpPaciente.SuspendLayout();
            this.pnlHeader.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlMainContainer
            // 
            this.pnlMainContainer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(242)))), ((int)(((byte)(246)))));
            this.pnlMainContainer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlMainContainer.Controls.Add(this.grpCondicionesBase);
            this.pnlMainContainer.Controls.Add(this.button1);
            this.pnlMainContainer.Controls.Add(this.grpHistorial);
            this.pnlMainContainer.Controls.Add(this.grpPaciente);
            this.pnlMainContainer.Controls.Add(this.pnlHeader);
            this.pnlMainContainer.Location = new System.Drawing.Point(1, 2);
            this.pnlMainContainer.Name = "pnlMainContainer";
            this.pnlMainContainer.Size = new System.Drawing.Size(800, 685);
            this.pnlMainContainer.TabIndex = 0;
            // 
            // grpCondicionesBase
            // 
            this.grpCondicionesBase.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(51)))), ((int)(((byte)(57)))));
            this.grpCondicionesBase.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(71)))), ((int)(((byte)(79)))));
            this.grpCondicionesBase.BorderRadius = 14;
            this.grpCondicionesBase.Controls.Add(this.btnGuardarCondiciones);
            this.grpCondicionesBase.Controls.Add(this.txtObservacion);
            this.grpCondicionesBase.Controls.Add(this.txtAntecedente);
            this.grpCondicionesBase.Controls.Add(this.txtAlergias);
            this.grpCondicionesBase.Controls.Add(this.lblObservaciones);
            this.grpCondicionesBase.Controls.Add(this.lblAntecedentes);
            this.grpCondicionesBase.Controls.Add(this.lblAlergias);
            this.grpCondicionesBase.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.grpCondicionesBase.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(210)))), ((int)(((byte)(185)))));
            this.grpCondicionesBase.Location = new System.Drawing.Point(10, 153);
            this.grpCondicionesBase.Name = "grpCondicionesBase";
            this.grpCondicionesBase.Padding = new System.Windows.Forms.Padding(16, 32, 16, 16);
            this.grpCondicionesBase.Size = new System.Drawing.Size(778, 184);
            this.grpCondicionesBase.TabIndex = 8;
            this.grpCondicionesBase.Text = "Condiciones Medicas";
            this.grpCondicionesBase.TitleColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(210)))), ((int)(((byte)(185)))));
            // 
            // btnGuardarCondiciones
            // 
            this.btnGuardarCondiciones.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(148)))), ((int)(((byte)(136)))));
            this.btnGuardarCondiciones.ForeColor = System.Drawing.Color.White;
            this.btnGuardarCondiciones.Location = new System.Drawing.Point(453, 114);
            this.btnGuardarCondiciones.Name = "btnGuardarCondiciones";
            this.btnGuardarCondiciones.Size = new System.Drawing.Size(306, 35);
            this.btnGuardarCondiciones.TabIndex = 10;
            this.btnGuardarCondiciones.Text = "Actualizar";
            this.btnGuardarCondiciones.UseVisualStyleBackColor = false;
            // 
            // txtObservacion
            // 
            this.txtObservacion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(40)))), ((int)(((byte)(45)))));
            this.txtObservacion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtObservacion.ForeColor = System.Drawing.Color.White;
            this.txtObservacion.Location = new System.Drawing.Point(19, 102);
            this.txtObservacion.Multiline = true;
            this.txtObservacion.Name = "txtObservacion";
            this.txtObservacion.Size = new System.Drawing.Size(388, 63);
            this.txtObservacion.TabIndex = 9;
            // 
            // txtAntecedente
            // 
            this.txtAntecedente.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(40)))), ((int)(((byte)(45)))));
            this.txtAntecedente.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAntecedente.ForeColor = System.Drawing.Color.White;
            this.txtAntecedente.Location = new System.Drawing.Point(436, 54);
            this.txtAntecedente.Name = "txtAntecedente";
            this.txtAntecedente.Size = new System.Drawing.Size(323, 24);
            this.txtAntecedente.TabIndex = 8;
            // 
            // txtAlergias
            // 
            this.txtAlergias.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(40)))), ((int)(((byte)(45)))));
            this.txtAlergias.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAlergias.ForeColor = System.Drawing.Color.White;
            this.txtAlergias.Location = new System.Drawing.Point(19, 54);
            this.txtAlergias.Name = "txtAlergias";
            this.txtAlergias.Size = new System.Drawing.Size(388, 24);
            this.txtAlergias.TabIndex = 5;
            // 
            // lblObservaciones
            // 
            this.lblObservaciones.AutoSize = true;
            this.lblObservaciones.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblObservaciones.Location = new System.Drawing.Point(20, 83);
            this.lblObservaciones.Name = "lblObservaciones";
            this.lblObservaciones.Size = new System.Drawing.Size(88, 15);
            this.lblObservaciones.TabIndex = 7;
            this.lblObservaciones.Text = "Observaciones";
            // 
            // lblAntecedentes
            // 
            this.lblAntecedentes.AutoSize = true;
            this.lblAntecedentes.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblAntecedentes.Location = new System.Drawing.Point(433, 36);
            this.lblAntecedentes.Name = "lblAntecedentes";
            this.lblAntecedentes.Size = new System.Drawing.Size(157, 15);
            this.lblAntecedentes.TabIndex = 4;
            this.lblAntecedentes.Text = "Antecedentes Importantes";
            // 
            // lblAlergias
            // 
            this.lblAlergias.AutoSize = true;
            this.lblAlergias.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblAlergias.Location = new System.Drawing.Point(20, 36);
            this.lblAlergias.Name = "lblAlergias";
            this.lblAlergias.Size = new System.Drawing.Size(51, 15);
            this.lblAlergias.TabIndex = 0;
            this.lblAlergias.Text = "Alergias";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.White;
            this.button1.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button1.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(213)))), ((int)(((byte)(225)))));
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(85)))), ((int)(((byte)(105)))));
            this.button1.Location = new System.Drawing.Point(611, 626);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(175, 38);
            this.button1.TabIndex = 4;
            this.button1.Text = "Cerrar Ventana";
            this.button1.UseVisualStyleBackColor = false;
            // 
            // grpHistorial
            // 
            this.grpHistorial.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(51)))), ((int)(((byte)(57)))));
            this.grpHistorial.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(71)))), ((int)(((byte)(79)))));
            this.grpHistorial.BorderRadius = 14;
            this.grpHistorial.Controls.Add(this.dgvHistoriaClinica);
            this.grpHistorial.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.grpHistorial.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(210)))), ((int)(((byte)(185)))));
            this.grpHistorial.Location = new System.Drawing.Point(9, 343);
            this.grpHistorial.Name = "grpHistorial";
            this.grpHistorial.Padding = new System.Windows.Forms.Padding(16, 32, 16, 16);
            this.grpHistorial.Size = new System.Drawing.Size(777, 277);
            this.grpHistorial.TabIndex = 2;
            this.grpHistorial.Text = "Registro de Atenciones Previas";
            this.grpHistorial.TitleColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(210)))), ((int)(((byte)(185)))));
            // 
            // dgvHistoriaClinica
            // 
            this.dgvHistoriaClinica.AllowUserToAddRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(44)))), ((int)(((byte)(51)))));
            this.dgvHistoriaClinica.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvHistoriaClinica.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(37)))), ((int)(((byte)(43)))));
            this.dgvHistoriaClinica.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvHistoriaClinica.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(66)))), ((int)(((byte)(88)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvHistoriaClinica.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvHistoriaClinica.ColumnHeadersHeight = 32;
            this.dgvHistoriaClinica.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvHistoriaClinica.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colFecha,
            this.colAntecedente,
            this.colObservacion});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(37)))), ((int)(((byte)(43)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(210)))), ((int)(((byte)(185)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(78)))), ((int)(((byte)(74)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvHistoriaClinica.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvHistoriaClinica.EnableHeadersVisualStyles = false;
            this.dgvHistoriaClinica.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(71)))), ((int)(((byte)(79)))));
            this.dgvHistoriaClinica.Location = new System.Drawing.Point(22, 51);
            this.dgvHistoriaClinica.Name = "dgvHistoriaClinica";
            this.dgvHistoriaClinica.ReadOnly = true;
            this.dgvHistoriaClinica.RowHeadersVisible = false;
            this.dgvHistoriaClinica.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvHistoriaClinica.Size = new System.Drawing.Size(736, 198);
            this.dgvHistoriaClinica.TabIndex = 0;
            // 
            // colFecha
            // 
            this.colFecha.HeaderText = "Fecha Registro";
            this.colFecha.Name = "colFecha";
            this.colFecha.ReadOnly = true;
            this.colFecha.Width = 130;
            // 
            // colAntecedente
            // 
            this.colAntecedente.HeaderText = "Antecedente / Condicion";
            this.colAntecedente.Name = "colAntecedente";
            this.colAntecedente.ReadOnly = true;
            this.colAntecedente.Width = 240;
            // 
            // colObservacion
            // 
            this.colObservacion.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colObservacion.HeaderText = "Observaciones";
            this.colObservacion.Name = "colObservacion";
            this.colObservacion.ReadOnly = true;
            // 
            // grpPaciente
            // 
            this.grpPaciente.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(51)))), ((int)(((byte)(57)))));
            this.grpPaciente.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(71)))), ((int)(((byte)(79)))));
            this.grpPaciente.BorderRadius = 14;
            this.grpPaciente.Controls.Add(this.lblPacienteTelefono);
            this.grpPaciente.Controls.Add(this.lblPacienteFecNac);
            this.grpPaciente.Controls.Add(this.lblTitTelefono);
            this.grpPaciente.Controls.Add(this.lblTitFecNac);
            this.grpPaciente.Controls.Add(this.lblPacienteDni);
            this.grpPaciente.Controls.Add(this.lblTitDni);
            this.grpPaciente.Controls.Add(this.lblPacienteNombre);
            this.grpPaciente.Controls.Add(this.label2);
            this.grpPaciente.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.grpPaciente.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(210)))), ((int)(((byte)(185)))));
            this.grpPaciente.Location = new System.Drawing.Point(10, 58);
            this.grpPaciente.Name = "grpPaciente";
            this.grpPaciente.Padding = new System.Windows.Forms.Padding(16, 32, 16, 16);
            this.grpPaciente.Size = new System.Drawing.Size(778, 89);
            this.grpPaciente.TabIndex = 1;
            this.grpPaciente.Text = "Paciente en Consulta";
            this.grpPaciente.TitleColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(210)))), ((int)(((byte)(185)))));
            // 
            // lblPacienteTelefono
            // 
            this.lblPacienteTelefono.AutoSize = true;
            this.lblPacienteTelefono.ForeColor = System.Drawing.Color.White;
            this.lblPacienteTelefono.Location = new System.Drawing.Point(653, 55);
            this.lblPacienteTelefono.Name = "lblPacienteTelefono";
            this.lblPacienteTelefono.Size = new System.Drawing.Size(45, 17);
            this.lblPacienteTelefono.TabIndex = 7;
            this.lblPacienteTelefono.Text = "label4";
            // 
            // lblPacienteFecNac
            // 
            this.lblPacienteFecNac.AutoSize = true;
            this.lblPacienteFecNac.ForeColor = System.Drawing.Color.White;
            this.lblPacienteFecNac.Location = new System.Drawing.Point(450, 55);
            this.lblPacienteFecNac.Name = "lblPacienteFecNac";
            this.lblPacienteFecNac.Size = new System.Drawing.Size(45, 17);
            this.lblPacienteFecNac.TabIndex = 6;
            this.lblPacienteFecNac.Text = "label3";
            // 
            // lblTitTelefono
            // 
            this.lblTitTelefono.AutoSize = true;
            this.lblTitTelefono.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblTitTelefono.Location = new System.Drawing.Point(653, 36);
            this.lblTitTelefono.Name = "lblTitTelefono";
            this.lblTitTelefono.Size = new System.Drawing.Size(56, 15);
            this.lblTitTelefono.TabIndex = 5;
            this.lblTitTelefono.Text = "Telefono";
            // 
            // lblTitFecNac
            // 
            this.lblTitFecNac.AutoSize = true;
            this.lblTitFecNac.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblTitFecNac.Location = new System.Drawing.Point(450, 36);
            this.lblTitFecNac.Name = "lblTitFecNac";
            this.lblTitFecNac.Size = new System.Drawing.Size(106, 15);
            this.lblTitFecNac.TabIndex = 4;
            this.lblTitFecNac.Text = "Fecha Nacimiento";
            // 
            // lblPacienteDni
            // 
            this.lblPacienteDni.AutoSize = true;
            this.lblPacienteDni.ForeColor = System.Drawing.Color.White;
            this.lblPacienteDni.Location = new System.Drawing.Point(247, 55);
            this.lblPacienteDni.Name = "lblPacienteDni";
            this.lblPacienteDni.Size = new System.Drawing.Size(45, 17);
            this.lblPacienteDni.TabIndex = 3;
            this.lblPacienteDni.Text = "label3";
            // 
            // lblTitDni
            // 
            this.lblTitDni.AutoSize = true;
            this.lblTitDni.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblTitDni.Location = new System.Drawing.Point(247, 36);
            this.lblTitDni.Name = "lblTitDni";
            this.lblTitDni.Size = new System.Drawing.Size(29, 15);
            this.lblTitDni.TabIndex = 2;
            this.lblTitDni.Text = "DNI";
            // 
            // lblPacienteNombre
            // 
            this.lblPacienteNombre.AutoSize = true;
            this.lblPacienteNombre.ForeColor = System.Drawing.Color.White;
            this.lblPacienteNombre.Location = new System.Drawing.Point(23, 55);
            this.lblPacienteNombre.Name = "lblPacienteNombre";
            this.lblPacienteNombre.Size = new System.Drawing.Size(45, 17);
            this.lblPacienteNombre.TabIndex = 1;
            this.lblPacienteNombre.Text = "label3";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(20, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(110, 15);
            this.label2.TabIndex = 0;
            this.label2.Text = "Apellido y Nombre";
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.White;
            this.pnlHeader.Controls.Add(this.label1);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(798, 52);
            this.pnlHeader.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.label1.Location = new System.Drawing.Point(19, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(459, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Hospital Sagrado Corazón  |  Historia Clínica y Antecedentes del Paciente";
            // 
            // HistoriaClinicaForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 684);
            this.Controls.Add(this.pnlMainContainer);
            this.Name = "HistoriaClinicaForm";
            this.Text = "HistoriaClinicaForm";
            this.pnlMainContainer.ResumeLayout(false);
            this.grpCondicionesBase.ResumeLayout(false);
            this.grpCondicionesBase.PerformLayout();
            this.grpHistorial.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvHistoriaClinica)).EndInit();
            this.grpPaciente.ResumeLayout(false);
            this.grpPaciente.PerformLayout();
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlMainContainer;
        private DarkGroupBox grpPaciente;
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private DarkGroupBox grpHistorial;
        private System.Windows.Forms.Label lblPacienteTelefono;
        private System.Windows.Forms.Label lblPacienteFecNac;
        private System.Windows.Forms.Label lblTitTelefono;
        private System.Windows.Forms.Label lblTitFecNac;
        private System.Windows.Forms.Label lblPacienteDni;
        private System.Windows.Forms.Label lblTitDni;
        private System.Windows.Forms.Label lblPacienteNombre;
        private System.Windows.Forms.DataGridView dgvHistoriaClinica;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFecha;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAntecedente;
        private System.Windows.Forms.DataGridViewTextBoxColumn colObservacion;
        private System.Windows.Forms.Button button1;
        private DarkGroupBox grpCondicionesBase;
        private System.Windows.Forms.Label lblAntecedentes;
        private System.Windows.Forms.Label lblAlergias;
        private System.Windows.Forms.Label lblObservaciones;
        private System.Windows.Forms.TextBox txtAlergias;
        private System.Windows.Forms.Button btnGuardarCondiciones;
        private System.Windows.Forms.TextBox txtObservacion;
        private System.Windows.Forms.TextBox txtAntecedente;
    }
}