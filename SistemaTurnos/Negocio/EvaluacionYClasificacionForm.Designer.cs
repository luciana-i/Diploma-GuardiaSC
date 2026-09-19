namespace SistemaTurnos.Negocio
{
    partial class EvaluacionYClasificacionForm
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
            this.pnlMainContainer = new System.Windows.Forms.Panel();
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblHeader = new System.Windows.Forms.Label();
            this.btnConfirmarTriage = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.grpDeterminacionPrioridad = new SistemaTurnos.DarkGroupBox();
            this.txtJustificacion = new System.Windows.Forms.TextBox();
            this.lblJustificacionTitulo = new System.Windows.Forms.Label();
            this.cmbPrioridadFinal = new System.Windows.Forms.ComboBox();
            this.lblPrioridadFinalTitulo = new System.Windows.Forms.Label();
            this.pnlPrioridadSugerida = new System.Windows.Forms.Panel();
            this.lblNivelSugerido = new System.Windows.Forms.Label();
            this.lblSugerenciaHeader = new System.Windows.Forms.Label();
            this.btnCalcularPrioridad = new System.Windows.Forms.Button();
            this.grpEvaluacionClinica = new SistemaTurnos.DarkGroupBox();
            this.chkConsultaAdministrativa = new System.Windows.Forms.CheckBox();
            this.txtSintomas = new System.Windows.Forms.TextBox();
            this.lblSintomasTitulo = new System.Windows.Forms.Label();
            this.txtPresion = new System.Windows.Forms.TextBox();
            this.txtSaturacion = new System.Windows.Forms.TextBox();
            this.txtTemperatura = new System.Windows.Forms.TextBox();
            this.lblPresion = new System.Windows.Forms.Label();
            this.lblSaturacion = new System.Windows.Forms.Label();
            this.lblTemperatura = new System.Windows.Forms.Label();
            this.txtFc = new System.Windows.Forms.TextBox();
            this.lblFc = new System.Windows.Forms.Label();
            this.grpPacienteEspera = new SistemaTurnos.DarkGroupBox();
            this.lblHoraArriboValor = new System.Windows.Forms.Label();
            this.lblHoraArriboTitulo = new System.Windows.Forms.Label();
            this.lblEpisodioValor = new System.Windows.Forms.Label();
            this.lblEpisodioTitulo = new System.Windows.Forms.Label();
            this.lblPacienteDni = new System.Windows.Forms.Label();
            this.lblPacienteNombre = new System.Windows.Forms.Label();
            this.lblPacienteTitulo = new System.Windows.Forms.Label();
            this.btnVerHistoriaClinica = new System.Windows.Forms.Button();
            this.pnlMainContainer.SuspendLayout();
            this.pnlHeader.SuspendLayout();
            this.grpDeterminacionPrioridad.SuspendLayout();
            this.pnlPrioridadSugerida.SuspendLayout();
            this.grpEvaluacionClinica.SuspendLayout();
            this.grpPacienteEspera.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlMainContainer
            // 
            this.pnlMainContainer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(242)))), ((int)(((byte)(246)))));
            this.pnlMainContainer.Controls.Add(this.btnVerHistoriaClinica);
            this.pnlMainContainer.Controls.Add(this.pnlHeader);
            this.pnlMainContainer.Controls.Add(this.btnConfirmarTriage);
            this.pnlMainContainer.Controls.Add(this.grpDeterminacionPrioridad);
            this.pnlMainContainer.Controls.Add(this.btnCancelar);
            this.pnlMainContainer.Controls.Add(this.grpEvaluacionClinica);
            this.pnlMainContainer.Controls.Add(this.grpPacienteEspera);
            this.pnlMainContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMainContainer.Location = new System.Drawing.Point(0, 0);
            this.pnlMainContainer.Name = "pnlMainContainer";
            this.pnlMainContainer.Size = new System.Drawing.Size(793, 825);
            this.pnlMainContainer.TabIndex = 0;
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.White;
            this.pnlHeader.Controls.Add(this.lblHeader);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(793, 49);
            this.pnlHeader.TabIndex = 3;
            // 
            // lblHeader
            // 
            this.lblHeader.AutoSize = true;
            this.lblHeader.BackColor = System.Drawing.Color.White;
            this.lblHeader.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHeader.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.lblHeader.Location = new System.Drawing.Point(29, 21);
            this.lblHeader.Name = "lblHeader";
            this.lblHeader.Size = new System.Drawing.Size(330, 17);
            this.lblHeader.TabIndex = 1;
            this.lblHeader.Text = "Hospital Sagrado Corazón | Evaluación de Enfermería";
            // 
            // btnConfirmarTriage
            // 
            this.btnConfirmarTriage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(210)))), ((int)(((byte)(185)))));
            this.btnConfirmarTriage.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnConfirmarTriage.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(111)))), ((int)(((byte)(83)))));
            this.btnConfirmarTriage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConfirmarTriage.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConfirmarTriage.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(62)))), ((int)(((byte)(48)))));
            this.btnConfirmarTriage.Location = new System.Drawing.Point(597, 757);
            this.btnConfirmarTriage.Name = "btnConfirmarTriage";
            this.btnConfirmarTriage.Size = new System.Drawing.Size(169, 37);
            this.btnConfirmarTriage.TabIndex = 2;
            this.btnConfirmarTriage.Text = "✓ Confirmar";
            this.btnConfirmarTriage.UseVisualStyleBackColor = false;
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(232)))), ((int)(((byte)(240)))));
            this.btnCancelar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancelar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(213)))), ((int)(((byte)(225)))));
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(85)))), ((int)(((byte)(105)))));
            this.btnCancelar.Location = new System.Drawing.Point(311, 757);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(178, 37);
            this.btnCancelar.TabIndex = 1;
            this.btnCancelar.Text = "✗ Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = false;
            // 
            // grpDeterminacionPrioridad
            // 
            this.grpDeterminacionPrioridad.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(51)))), ((int)(((byte)(57)))));
            this.grpDeterminacionPrioridad.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(71)))), ((int)(((byte)(79)))));
            this.grpDeterminacionPrioridad.BorderRadius = 8;
            this.grpDeterminacionPrioridad.Controls.Add(this.txtJustificacion);
            this.grpDeterminacionPrioridad.Controls.Add(this.lblJustificacionTitulo);
            this.grpDeterminacionPrioridad.Controls.Add(this.cmbPrioridadFinal);
            this.grpDeterminacionPrioridad.Controls.Add(this.lblPrioridadFinalTitulo);
            this.grpDeterminacionPrioridad.Controls.Add(this.pnlPrioridadSugerida);
            this.grpDeterminacionPrioridad.Controls.Add(this.btnCalcularPrioridad);
            this.grpDeterminacionPrioridad.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.grpDeterminacionPrioridad.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(210)))), ((int)(((byte)(185)))));
            this.grpDeterminacionPrioridad.Location = new System.Drawing.Point(26, 430);
            this.grpDeterminacionPrioridad.Name = "grpDeterminacionPrioridad";
            this.grpDeterminacionPrioridad.Padding = new System.Windows.Forms.Padding(16, 32, 16, 16);
            this.grpDeterminacionPrioridad.Size = new System.Drawing.Size(740, 301);
            this.grpDeterminacionPrioridad.TabIndex = 2;
            this.grpDeterminacionPrioridad.Text = "Selección de Nivel y Validación";
            this.grpDeterminacionPrioridad.TitleColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(210)))), ((int)(((byte)(185)))));
            // 
            // txtJustificacion
            // 
            this.txtJustificacion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(40)))), ((int)(((byte)(45)))));
            this.txtJustificacion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtJustificacion.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtJustificacion.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(245)))), ((int)(((byte)(249)))));
            this.txtJustificacion.Location = new System.Drawing.Point(21, 236);
            this.txtJustificacion.Multiline = true;
            this.txtJustificacion.Name = "txtJustificacion";
            this.txtJustificacion.Size = new System.Drawing.Size(687, 44);
            this.txtJustificacion.TabIndex = 5;
            // 
            // lblJustificacionTitulo
            // 
            this.lblJustificacionTitulo.AutoSize = true;
            this.lblJustificacionTitulo.Location = new System.Drawing.Point(27, 216);
            this.lblJustificacionTitulo.Name = "lblJustificacionTitulo";
            this.lblJustificacionTitulo.Size = new System.Drawing.Size(85, 17);
            this.lblJustificacionTitulo.TabIndex = 4;
            this.lblJustificacionTitulo.Text = "Justificación";
            // 
            // cmbPrioridadFinal
            // 
            this.cmbPrioridadFinal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(40)))), ((int)(((byte)(45)))));
            this.cmbPrioridadFinal.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbPrioridadFinal.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPrioridadFinal.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbPrioridadFinal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(245)))), ((int)(((byte)(249)))));
            this.cmbPrioridadFinal.FormattingEnabled = true;
            this.cmbPrioridadFinal.ItemHeight = 24;
            this.cmbPrioridadFinal.Items.AddRange(new object[] {
            "Nivel 1 - Rojo (Resucitación)",
            "Nivel 2 - Naranja (Emergencia)",
            "Nivel 3 - Amarillo (Urgente)",
            "Nivel 4 - Verde (Poco Urgente)",
            "Nivel 5 - Azul (No Urgente)"});
            this.cmbPrioridadFinal.Location = new System.Drawing.Point(311, 187);
            this.cmbPrioridadFinal.Name = "cmbPrioridadFinal";
            this.cmbPrioridadFinal.Size = new System.Drawing.Size(261, 30);
            this.cmbPrioridadFinal.TabIndex = 3;
            this.cmbPrioridadFinal.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.cmbPrioridadFinal_DrawItem);
            // 
            // lblPrioridadFinalTitulo
            // 
            this.lblPrioridadFinalTitulo.AutoSize = true;
            this.lblPrioridadFinalTitulo.ForeColor = System.Drawing.Color.White;
            this.lblPrioridadFinalTitulo.Location = new System.Drawing.Point(27, 187);
            this.lblPrioridadFinalTitulo.Name = "lblPrioridadFinalTitulo";
            this.lblPrioridadFinalTitulo.Size = new System.Drawing.Size(222, 17);
            this.lblPrioridadFinalTitulo.TabIndex = 2;
            this.lblPrioridadFinalTitulo.Text = "Prioridad Asignada por Enfermería";
            // 
            // pnlPrioridadSugerida
            // 
            this.pnlPrioridadSugerida.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(41)))), ((int)(((byte)(26)))));
            this.pnlPrioridadSugerida.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlPrioridadSugerida.Controls.Add(this.lblNivelSugerido);
            this.pnlPrioridadSugerida.Controls.Add(this.lblSugerenciaHeader);
            this.pnlPrioridadSugerida.Location = new System.Drawing.Point(21, 93);
            this.pnlPrioridadSugerida.Name = "pnlPrioridadSugerida";
            this.pnlPrioridadSugerida.Size = new System.Drawing.Size(681, 70);
            this.pnlPrioridadSugerida.TabIndex = 1;
            // 
            // lblNivelSugerido
            // 
            this.lblNivelSugerido.AutoSize = true;
            this.lblNivelSugerido.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(240)))), ((int)(((byte)(138)))));
            this.lblNivelSugerido.Location = new System.Drawing.Point(20, 42);
            this.lblNivelSugerido.Name = "lblNivelSugerido";
            this.lblNivelSugerido.Size = new System.Drawing.Size(45, 17);
            this.lblNivelSugerido.TabIndex = 1;
            this.lblNivelSugerido.Text = "label1";
            // 
            // lblSugerenciaHeader
            // 
            this.lblSugerenciaHeader.AutoSize = true;
            this.lblSugerenciaHeader.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(204)))), ((int)(((byte)(21)))));
            this.lblSugerenciaHeader.Location = new System.Drawing.Point(20, 14);
            this.lblSugerenciaHeader.Name = "lblSugerenciaHeader";
            this.lblSugerenciaHeader.Size = new System.Drawing.Size(146, 17);
            this.lblSugerenciaHeader.TabIndex = 0;
            this.lblSugerenciaHeader.Text = "PRIORIDAD SUGERIDA";
            // 
            // btnCalcularPrioridad
            // 
            this.btnCalcularPrioridad.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(78)))), ((int)(((byte)(216)))));
            this.btnCalcularPrioridad.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCalcularPrioridad.FlatAppearance.BorderSize = 0;
            this.btnCalcularPrioridad.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCalcularPrioridad.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCalcularPrioridad.ForeColor = System.Drawing.Color.White;
            this.btnCalcularPrioridad.Location = new System.Drawing.Point(21, 35);
            this.btnCalcularPrioridad.Name = "btnCalcularPrioridad";
            this.btnCalcularPrioridad.Size = new System.Drawing.Size(681, 31);
            this.btnCalcularPrioridad.TabIndex = 0;
            this.btnCalcularPrioridad.Text = "⚡ Calcular Prioridad";
            this.btnCalcularPrioridad.UseVisualStyleBackColor = false;
            // 
            // grpEvaluacionClinica
            // 
            this.grpEvaluacionClinica.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(51)))), ((int)(((byte)(57)))));
            this.grpEvaluacionClinica.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(71)))), ((int)(((byte)(79)))));
            this.grpEvaluacionClinica.BorderRadius = 8;
            this.grpEvaluacionClinica.Controls.Add(this.chkConsultaAdministrativa);
            this.grpEvaluacionClinica.Controls.Add(this.txtSintomas);
            this.grpEvaluacionClinica.Controls.Add(this.lblSintomasTitulo);
            this.grpEvaluacionClinica.Controls.Add(this.txtPresion);
            this.grpEvaluacionClinica.Controls.Add(this.txtSaturacion);
            this.grpEvaluacionClinica.Controls.Add(this.txtTemperatura);
            this.grpEvaluacionClinica.Controls.Add(this.lblPresion);
            this.grpEvaluacionClinica.Controls.Add(this.lblSaturacion);
            this.grpEvaluacionClinica.Controls.Add(this.lblTemperatura);
            this.grpEvaluacionClinica.Controls.Add(this.txtFc);
            this.grpEvaluacionClinica.Controls.Add(this.lblFc);
            this.grpEvaluacionClinica.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpEvaluacionClinica.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(210)))), ((int)(((byte)(185)))));
            this.grpEvaluacionClinica.Location = new System.Drawing.Point(26, 206);
            this.grpEvaluacionClinica.Name = "grpEvaluacionClinica";
            this.grpEvaluacionClinica.Padding = new System.Windows.Forms.Padding(16, 32, 16, 16);
            this.grpEvaluacionClinica.Size = new System.Drawing.Size(740, 209);
            this.grpEvaluacionClinica.TabIndex = 1;
            this.grpEvaluacionClinica.Text = "Signos Vitales y Síntomas";
            this.grpEvaluacionClinica.TitleColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(210)))), ((int)(((byte)(185)))));
            // 
            // chkConsultaAdministrativa
            // 
            this.chkConsultaAdministrativa.AutoSize = true;
            this.chkConsultaAdministrativa.Location = new System.Drawing.Point(21, 179);
            this.chkConsultaAdministrativa.Name = "chkConsultaAdministrativa";
            this.chkConsultaAdministrativa.Size = new System.Drawing.Size(164, 21);
            this.chkConsultaAdministrativa.TabIndex = 10;
            this.chkConsultaAdministrativa.Text = "Renovación de recetas";
            this.chkConsultaAdministrativa.UseVisualStyleBackColor = true;
            // 
            // txtSintomas
            // 
            this.txtSintomas.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(40)))), ((int)(((byte)(45)))));
            this.txtSintomas.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSintomas.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSintomas.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(245)))), ((int)(((byte)(249)))));
            this.txtSintomas.Location = new System.Drawing.Point(21, 118);
            this.txtSintomas.Multiline = true;
            this.txtSintomas.Name = "txtSintomas";
            this.txtSintomas.Size = new System.Drawing.Size(681, 54);
            this.txtSintomas.TabIndex = 9;
            // 
            // lblSintomasTitulo
            // 
            this.lblSintomasTitulo.AutoSize = true;
            this.lblSintomasTitulo.ForeColor = System.Drawing.Color.White;
            this.lblSintomasTitulo.Location = new System.Drawing.Point(18, 98);
            this.lblSintomasTitulo.Name = "lblSintomasTitulo";
            this.lblSintomasTitulo.Size = new System.Drawing.Size(142, 17);
            this.lblSintomasTitulo.TabIndex = 8;
            this.lblSintomasTitulo.Text = "Síntomas Observados";
            // 
            // txtPresion
            // 
            this.txtPresion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(40)))), ((int)(((byte)(45)))));
            this.txtPresion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPresion.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPresion.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(245)))), ((int)(((byte)(249)))));
            this.txtPresion.Location = new System.Drawing.Point(552, 62);
            this.txtPresion.Name = "txtPresion";
            this.txtPresion.Size = new System.Drawing.Size(150, 27);
            this.txtPresion.TabIndex = 7;
            this.txtPresion.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtSaturacion
            // 
            this.txtSaturacion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(40)))), ((int)(((byte)(45)))));
            this.txtSaturacion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSaturacion.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSaturacion.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(245)))), ((int)(((byte)(249)))));
            this.txtSaturacion.Location = new System.Drawing.Point(378, 62);
            this.txtSaturacion.Name = "txtSaturacion";
            this.txtSaturacion.Size = new System.Drawing.Size(145, 27);
            this.txtSaturacion.TabIndex = 6;
            this.txtSaturacion.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtTemperatura
            // 
            this.txtTemperatura.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(40)))), ((int)(((byte)(45)))));
            this.txtTemperatura.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTemperatura.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTemperatura.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(245)))), ((int)(((byte)(249)))));
            this.txtTemperatura.Location = new System.Drawing.Point(221, 59);
            this.txtTemperatura.Name = "txtTemperatura";
            this.txtTemperatura.Size = new System.Drawing.Size(100, 27);
            this.txtTemperatura.TabIndex = 5;
            this.txtTemperatura.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblPresion
            // 
            this.lblPresion.AutoSize = true;
            this.lblPresion.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(159)))), ((int)(((byte)(176)))), ((int)(((byte)(184)))));
            this.lblPresion.Location = new System.Drawing.Point(549, 38);
            this.lblPresion.Name = "lblPresion";
            this.lblPresion.Size = new System.Drawing.Size(134, 17);
            this.lblPresion.TabIndex = 4;
            this.lblPresion.Text = "Presión Arterial (PA)";
            // 
            // lblSaturacion
            // 
            this.lblSaturacion.AutoSize = true;
            this.lblSaturacion.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(159)))), ((int)(((byte)(176)))), ((int)(((byte)(184)))));
            this.lblSaturacion.Location = new System.Drawing.Point(375, 38);
            this.lblSaturacion.Name = "lblSaturacion";
            this.lblSaturacion.Size = new System.Drawing.Size(148, 17);
            this.lblSaturacion.TabIndex = 3;
            this.lblSaturacion.Text = "Saturación de Oxígeno";
            // 
            // lblTemperatura
            // 
            this.lblTemperatura.AutoSize = true;
            this.lblTemperatura.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(159)))), ((int)(((byte)(176)))), ((int)(((byte)(184)))));
            this.lblTemperatura.Location = new System.Drawing.Point(215, 38);
            this.lblTemperatura.Name = "lblTemperatura";
            this.lblTemperatura.Size = new System.Drawing.Size(86, 17);
            this.lblTemperatura.TabIndex = 2;
            this.lblTemperatura.Text = "Temperatura";
            // 
            // txtFc
            // 
            this.txtFc.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(40)))), ((int)(((byte)(45)))));
            this.txtFc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtFc.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFc.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(245)))), ((int)(((byte)(249)))));
            this.txtFc.Location = new System.Drawing.Point(21, 58);
            this.txtFc.Name = "txtFc";
            this.txtFc.Size = new System.Drawing.Size(100, 27);
            this.txtFc.TabIndex = 1;
            this.txtFc.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblFc
            // 
            this.lblFc.AutoSize = true;
            this.lblFc.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(159)))), ((int)(((byte)(176)))), ((int)(((byte)(184)))));
            this.lblFc.Location = new System.Drawing.Point(18, 38);
            this.lblFc.Name = "lblFc";
            this.lblFc.Size = new System.Drawing.Size(129, 17);
            this.lblFc.TabIndex = 0;
            this.lblFc.Text = "Frecuencia Cardíaca";
            // 
            // grpPacienteEspera
            // 
            this.grpPacienteEspera.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(51)))), ((int)(((byte)(57)))));
            this.grpPacienteEspera.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(71)))), ((int)(((byte)(79)))));
            this.grpPacienteEspera.BorderRadius = 8;
            this.grpPacienteEspera.Controls.Add(this.lblHoraArriboValor);
            this.grpPacienteEspera.Controls.Add(this.lblHoraArriboTitulo);
            this.grpPacienteEspera.Controls.Add(this.lblEpisodioValor);
            this.grpPacienteEspera.Controls.Add(this.lblEpisodioTitulo);
            this.grpPacienteEspera.Controls.Add(this.lblPacienteDni);
            this.grpPacienteEspera.Controls.Add(this.lblPacienteNombre);
            this.grpPacienteEspera.Controls.Add(this.lblPacienteTitulo);
            this.grpPacienteEspera.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.grpPacienteEspera.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(210)))), ((int)(((byte)(185)))));
            this.grpPacienteEspera.Location = new System.Drawing.Point(26, 68);
            this.grpPacienteEspera.Name = "grpPacienteEspera";
            this.grpPacienteEspera.Padding = new System.Windows.Forms.Padding(16, 32, 16, 16);
            this.grpPacienteEspera.Size = new System.Drawing.Size(740, 111);
            this.grpPacienteEspera.TabIndex = 0;
            this.grpPacienteEspera.Text = "Datos del Paciente en Espera";
            this.grpPacienteEspera.TitleColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(210)))), ((int)(((byte)(185)))));
            // 
            // lblHoraArriboValor
            // 
            this.lblHoraArriboValor.AutoSize = true;
            this.lblHoraArriboValor.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(159)))), ((int)(((byte)(176)))), ((int)(((byte)(184)))));
            this.lblHoraArriboValor.Location = new System.Drawing.Point(568, 67);
            this.lblHoraArriboValor.Name = "lblHoraArriboValor";
            this.lblHoraArriboValor.Size = new System.Drawing.Size(45, 17);
            this.lblHoraArriboValor.TabIndex = 6;
            this.lblHoraArriboValor.Text = "label1";
            // 
            // lblHoraArriboTitulo
            // 
            this.lblHoraArriboTitulo.AutoSize = true;
            this.lblHoraArriboTitulo.Location = new System.Drawing.Point(568, 37);
            this.lblHoraArriboTitulo.Name = "lblHoraArriboTitulo";
            this.lblHoraArriboTitulo.Size = new System.Drawing.Size(96, 17);
            this.lblHoraArriboTitulo.TabIndex = 5;
            this.lblHoraArriboTitulo.Text = "Hora Consulta";
            // 
            // lblEpisodioValor
            // 
            this.lblEpisodioValor.AutoSize = true;
            this.lblEpisodioValor.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblEpisodioValor.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(210)))), ((int)(((byte)(185)))));
            this.lblEpisodioValor.Location = new System.Drawing.Point(387, 67);
            this.lblEpisodioValor.Name = "lblEpisodioValor";
            this.lblEpisodioValor.Size = new System.Drawing.Size(50, 19);
            this.lblEpisodioValor.TabIndex = 4;
            this.lblEpisodioValor.Text = "label1";
            // 
            // lblEpisodioTitulo
            // 
            this.lblEpisodioTitulo.AutoSize = true;
            this.lblEpisodioTitulo.Location = new System.Drawing.Point(387, 37);
            this.lblEpisodioTitulo.Name = "lblEpisodioTitulo";
            this.lblEpisodioTitulo.Size = new System.Drawing.Size(85, 17);
            this.lblEpisodioTitulo.TabIndex = 3;
            this.lblEpisodioTitulo.Text = "N° Consulta:";
            // 
            // lblPacienteDni
            // 
            this.lblPacienteDni.AutoSize = true;
            this.lblPacienteDni.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(159)))), ((int)(((byte)(176)))), ((int)(((byte)(184)))));
            this.lblPacienteDni.Location = new System.Drawing.Point(215, 67);
            this.lblPacienteDni.Name = "lblPacienteDni";
            this.lblPacienteDni.Size = new System.Drawing.Size(45, 17);
            this.lblPacienteDni.TabIndex = 2;
            this.lblPacienteDni.Text = "label1";
            // 
            // lblPacienteNombre
            // 
            this.lblPacienteNombre.AutoSize = true;
            this.lblPacienteNombre.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(159)))), ((int)(((byte)(176)))), ((int)(((byte)(184)))));
            this.lblPacienteNombre.Location = new System.Drawing.Point(27, 67);
            this.lblPacienteNombre.Name = "lblPacienteNombre";
            this.lblPacienteNombre.Size = new System.Drawing.Size(126, 17);
            this.lblPacienteNombre.TabIndex = 1;
            this.lblPacienteNombre.Text = "lblPacienteNombre";
            // 
            // lblPacienteTitulo
            // 
            this.lblPacienteTitulo.AutoSize = true;
            this.lblPacienteTitulo.Location = new System.Drawing.Point(27, 37);
            this.lblPacienteTitulo.Name = "lblPacienteTitulo";
            this.lblPacienteTitulo.Size = new System.Drawing.Size(106, 17);
            this.lblPacienteTitulo.TabIndex = 0;
            this.lblPacienteTitulo.Text = "PACIENTE / DNI";
            // 
            // btnVerHistoriaClinica
            // 
            this.btnVerHistoriaClinica.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnVerHistoriaClinica.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnVerHistoriaClinica.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(189)))), ((int)(((byte)(248)))));
            this.btnVerHistoriaClinica.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVerHistoriaClinica.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(132)))), ((int)(((byte)(199)))));
            this.btnVerHistoriaClinica.Location = new System.Drawing.Point(26, 758);
            this.btnVerHistoriaClinica.Name = "btnVerHistoriaClinica";
            this.btnVerHistoriaClinica.Size = new System.Drawing.Size(178, 37);
            this.btnVerHistoriaClinica.TabIndex = 4;
            this.btnVerHistoriaClinica.Text = "📋 Historia Clínica";
            this.btnVerHistoriaClinica.UseVisualStyleBackColor = false;
            this.btnVerHistoriaClinica.Click += new System.EventHandler(this.btnVerHistoriaClinica_Click);
            // 
            // EvaluacionYClasificacionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(218)))), ((int)(((byte)(229)))));
            this.ClientSize = new System.Drawing.Size(793, 825);
            this.Controls.Add(this.pnlMainContainer);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(245)))), ((int)(((byte)(249)))));
            this.Name = "EvaluacionYClasificacionForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "EvaluacionYClasificacionForm";
            this.pnlMainContainer.ResumeLayout(false);
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.grpDeterminacionPrioridad.ResumeLayout(false);
            this.grpDeterminacionPrioridad.PerformLayout();
            this.pnlPrioridadSugerida.ResumeLayout(false);
            this.pnlPrioridadSugerida.PerformLayout();
            this.grpEvaluacionClinica.ResumeLayout(false);
            this.grpEvaluacionClinica.PerformLayout();
            this.grpPacienteEspera.ResumeLayout(false);
            this.grpPacienteEspera.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlMainContainer;
        private DarkGroupBox grpDeterminacionPrioridad;
        private DarkGroupBox grpEvaluacionClinica;
        private DarkGroupBox grpPacienteEspera;
        private System.Windows.Forms.Label lblHoraArriboValor;
        private System.Windows.Forms.Label lblHoraArriboTitulo;
        private System.Windows.Forms.Label lblEpisodioValor;
        private System.Windows.Forms.Label lblEpisodioTitulo;
        private System.Windows.Forms.Label lblPacienteDni;
        private System.Windows.Forms.Label lblPacienteNombre;
        private System.Windows.Forms.Label lblPacienteTitulo;
        private System.Windows.Forms.TextBox txtFc;
        private System.Windows.Forms.Label lblFc;
        private System.Windows.Forms.TextBox txtSintomas;
        private System.Windows.Forms.Label lblSintomasTitulo;
        private System.Windows.Forms.TextBox txtPresion;
        private System.Windows.Forms.TextBox txtSaturacion;
        private System.Windows.Forms.TextBox txtTemperatura;
        private System.Windows.Forms.Label lblPresion;
        private System.Windows.Forms.Label lblSaturacion;
        private System.Windows.Forms.Label lblTemperatura;
        private System.Windows.Forms.ComboBox cmbPrioridadFinal;
        private System.Windows.Forms.Label lblPrioridadFinalTitulo;
        private System.Windows.Forms.Panel pnlPrioridadSugerida;
        private System.Windows.Forms.Label lblNivelSugerido;
        private System.Windows.Forms.Label lblSugerenciaHeader;
        private System.Windows.Forms.Button btnCalcularPrioridad;
        private System.Windows.Forms.TextBox txtJustificacion;
        private System.Windows.Forms.Label lblJustificacionTitulo;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnConfirmarTriage;
        private System.Windows.Forms.CheckBox chkConsultaAdministrativa;
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblHeader;
        private System.Windows.Forms.Button btnVerHistoriaClinica;
    }
}