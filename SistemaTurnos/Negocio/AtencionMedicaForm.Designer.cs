namespace SistemaTurnos.Negocio
{
    partial class AtencionMedicaForm
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
            this.btnFinalizarAtencion = new System.Windows.Forms.Button();
            this.grpDestinoAsistencial = new SistemaTurnos.DarkGroupBox();
            this.cmbDestino = new System.Windows.Forms.ComboBox();
            this.lblTitDiagnostico = new System.Windows.Forms.Label();
            this.grpEvolucionMedica = new SistemaTurnos.DarkGroupBox();
            this.txtIndicaciones = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtDiagnostico = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.grpContextoTriage = new SistemaTurnos.DarkGroupBox();
            this.pnlTriageBadge = new System.Windows.Forms.Panel();
            this.lblPrioridadValor = new System.Windows.Forms.Label();
            this.lblTitTriageBadge = new System.Windows.Forms.Label();
            this.pnlChipPa = new System.Windows.Forms.Panel();
            this.lblPaValor = new System.Windows.Forms.Label();
            this.lblTitPa = new System.Windows.Forms.Label();
            this.pnlChipSat = new System.Windows.Forms.Panel();
            this.lblSatValor = new System.Windows.Forms.Label();
            this.lblTitSat = new System.Windows.Forms.Label();
            this.pnlChipTemp = new System.Windows.Forms.Panel();
            this.lblTempVal = new System.Windows.Forms.Label();
            this.lblTitTemp = new System.Windows.Forms.Label();
            this.pnlChipFc = new System.Windows.Forms.Panel();
            this.lblFcValor = new System.Windows.Forms.Label();
            this.lblTitFc = new System.Windows.Forms.Label();
            this.btnVerHistoriaClinica = new System.Windows.Forms.Button();
            this.lblMotivoValor = new System.Windows.Forms.Label();
            this.lblTitMotivo = new System.Windows.Forms.Label();
            this.lblPacienteDatos = new System.Windows.Forms.Label();
            this.lblTitPaciente = new System.Windows.Forms.Label();
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblTituloModulo = new System.Windows.Forms.Label();
            this.pnlMainContainer.SuspendLayout();
            this.grpDestinoAsistencial.SuspendLayout();
            this.grpEvolucionMedica.SuspendLayout();
            this.grpContextoTriage.SuspendLayout();
            this.pnlTriageBadge.SuspendLayout();
            this.pnlChipPa.SuspendLayout();
            this.pnlChipSat.SuspendLayout();
            this.pnlChipTemp.SuspendLayout();
            this.pnlChipFc.SuspendLayout();
            this.pnlHeader.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlMainContainer
            // 
            this.pnlMainContainer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(242)))), ((int)(((byte)(246)))));
            this.pnlMainContainer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlMainContainer.Controls.Add(this.btnFinalizarAtencion);
            this.pnlMainContainer.Controls.Add(this.grpDestinoAsistencial);
            this.pnlMainContainer.Controls.Add(this.grpEvolucionMedica);
            this.pnlMainContainer.Controls.Add(this.grpContextoTriage);
            this.pnlMainContainer.Controls.Add(this.pnlHeader);
            this.pnlMainContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMainContainer.Location = new System.Drawing.Point(0, 0);
            this.pnlMainContainer.Name = "pnlMainContainer";
            this.pnlMainContainer.Size = new System.Drawing.Size(1101, 783);
            this.pnlMainContainer.TabIndex = 0;
            // 
            // btnFinalizarAtencion
            // 
            this.btnFinalizarAtencion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(210)))), ((int)(((byte)(185)))));
            this.btnFinalizarAtencion.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnFinalizarAtencion.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(213)))), ((int)(((byte)(225)))));
            this.btnFinalizarAtencion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFinalizarAtencion.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFinalizarAtencion.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(85)))), ((int)(((byte)(105)))));
            this.btnFinalizarAtencion.Location = new System.Drawing.Point(913, 723);
            this.btnFinalizarAtencion.Name = "btnFinalizarAtencion";
            this.btnFinalizarAtencion.Size = new System.Drawing.Size(175, 38);
            this.btnFinalizarAtencion.TabIndex = 5;
            this.btnFinalizarAtencion.Text = "Finalizar Atención Médica";
            this.btnFinalizarAtencion.UseVisualStyleBackColor = false;
            this.btnFinalizarAtencion.Click += new System.EventHandler(this.btnFinalizarAtencion_Click);
            // 
            // grpDestinoAsistencial
            // 
            this.grpDestinoAsistencial.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(51)))), ((int)(((byte)(57)))));
            this.grpDestinoAsistencial.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(71)))), ((int)(((byte)(79)))));
            this.grpDestinoAsistencial.BorderRadius = 14;
            this.grpDestinoAsistencial.Controls.Add(this.cmbDestino);
            this.grpDestinoAsistencial.Controls.Add(this.lblTitDiagnostico);
            this.grpDestinoAsistencial.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.grpDestinoAsistencial.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(210)))), ((int)(((byte)(185)))));
            this.grpDestinoAsistencial.Location = new System.Drawing.Point(12, 558);
            this.grpDestinoAsistencial.Name = "grpDestinoAsistencial";
            this.grpDestinoAsistencial.Padding = new System.Windows.Forms.Padding(16, 32, 16, 16);
            this.grpDestinoAsistencial.Size = new System.Drawing.Size(1076, 143);
            this.grpDestinoAsistencial.TabIndex = 4;
            this.grpDestinoAsistencial.Text = "Destino Asistencial de guardia";
            this.grpDestinoAsistencial.TitleColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(210)))), ((int)(((byte)(185)))));
            // 
            // cmbDestino
            // 
            this.cmbDestino.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(40)))), ((int)(((byte)(45)))));
            this.cmbDestino.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDestino.ForeColor = System.Drawing.Color.White;
            this.cmbDestino.FormattingEnabled = true;
            this.cmbDestino.Items.AddRange(new object[] {
            "Alta Médica",
            "Internación en Observación",
            "Derivacion Externa",
            "Solicitud de Estudios"});
            this.cmbDestino.Location = new System.Drawing.Point(19, 63);
            this.cmbDestino.Name = "cmbDestino";
            this.cmbDestino.Size = new System.Drawing.Size(466, 25);
            this.cmbDestino.TabIndex = 17;
            // 
            // lblTitDiagnostico
            // 
            this.lblTitDiagnostico.AutoSize = true;
            this.lblTitDiagnostico.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(40)))), ((int)(((byte)(45)))));
            this.lblTitDiagnostico.ForeColor = System.Drawing.Color.White;
            this.lblTitDiagnostico.Location = new System.Drawing.Point(16, 43);
            this.lblTitDiagnostico.Name = "lblTitDiagnostico";
            this.lblTitDiagnostico.Size = new System.Drawing.Size(173, 17);
            this.lblTitDiagnostico.TabIndex = 13;
            this.lblTitDiagnostico.Text = "Destino / Conducta Clínica";
            // 
            // grpEvolucionMedica
            // 
            this.grpEvolucionMedica.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(51)))), ((int)(((byte)(57)))));
            this.grpEvolucionMedica.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(71)))), ((int)(((byte)(79)))));
            this.grpEvolucionMedica.BorderRadius = 14;
            this.grpEvolucionMedica.Controls.Add(this.txtIndicaciones);
            this.grpEvolucionMedica.Controls.Add(this.label3);
            this.grpEvolucionMedica.Controls.Add(this.txtDiagnostico);
            this.grpEvolucionMedica.Controls.Add(this.label2);
            this.grpEvolucionMedica.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.grpEvolucionMedica.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(210)))), ((int)(((byte)(185)))));
            this.grpEvolucionMedica.Location = new System.Drawing.Point(12, 242);
            this.grpEvolucionMedica.Name = "grpEvolucionMedica";
            this.grpEvolucionMedica.Padding = new System.Windows.Forms.Padding(16, 32, 16, 16);
            this.grpEvolucionMedica.Size = new System.Drawing.Size(1076, 309);
            this.grpEvolucionMedica.TabIndex = 3;
            this.grpEvolucionMedica.Text = "Evaluacion e Indicaciones";
            this.grpEvolucionMedica.TitleColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(210)))), ((int)(((byte)(185)))));
            // 
            // txtIndicaciones
            // 
            this.txtIndicaciones.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(40)))), ((int)(((byte)(45)))));
            this.txtIndicaciones.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtIndicaciones.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(245)))), ((int)(((byte)(249)))));
            this.txtIndicaciones.Location = new System.Drawing.Point(19, 138);
            this.txtIndicaciones.Multiline = true;
            this.txtIndicaciones.Name = "txtIndicaciones";
            this.txtIndicaciones.Size = new System.Drawing.Size(1028, 152);
            this.txtIndicaciones.TabIndex = 15;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(40)))), ((int)(((byte)(45)))));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(19, 118);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(401, 17);
            this.label3.TabIndex = 14;
            this.label3.Text = "Indicaciones Terapéuticas, Medicación y Solicitud de Estudios: *";
            // 
            // txtDiagnostico
            // 
            this.txtDiagnostico.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(40)))), ((int)(((byte)(45)))));
            this.txtDiagnostico.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDiagnostico.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(245)))), ((int)(((byte)(249)))));
            this.txtDiagnostico.Location = new System.Drawing.Point(19, 74);
            this.txtDiagnostico.Name = "txtDiagnostico";
            this.txtDiagnostico.Size = new System.Drawing.Size(1028, 24);
            this.txtDiagnostico.TabIndex = 13;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(40)))), ((int)(((byte)(45)))));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(19, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(278, 17);
            this.label2.TabIndex = 12;
            this.label2.Text = "Diagnóstico Clínico Presuntivo / Definitivo:";
            // 
            // grpContextoTriage
            // 
            this.grpContextoTriage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(51)))), ((int)(((byte)(57)))));
            this.grpContextoTriage.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(71)))), ((int)(((byte)(79)))));
            this.grpContextoTriage.BorderRadius = 14;
            this.grpContextoTriage.Controls.Add(this.pnlTriageBadge);
            this.grpContextoTriage.Controls.Add(this.pnlChipPa);
            this.grpContextoTriage.Controls.Add(this.pnlChipSat);
            this.grpContextoTriage.Controls.Add(this.pnlChipTemp);
            this.grpContextoTriage.Controls.Add(this.pnlChipFc);
            this.grpContextoTriage.Controls.Add(this.btnVerHistoriaClinica);
            this.grpContextoTriage.Controls.Add(this.lblMotivoValor);
            this.grpContextoTriage.Controls.Add(this.lblTitMotivo);
            this.grpContextoTriage.Controls.Add(this.lblPacienteDatos);
            this.grpContextoTriage.Controls.Add(this.lblTitPaciente);
            this.grpContextoTriage.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.grpContextoTriage.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(210)))), ((int)(((byte)(185)))));
            this.grpContextoTriage.Location = new System.Drawing.Point(12, 69);
            this.grpContextoTriage.Name = "grpContextoTriage";
            this.grpContextoTriage.Padding = new System.Windows.Forms.Padding(16, 32, 16, 16);
            this.grpContextoTriage.Size = new System.Drawing.Size(1076, 153);
            this.grpContextoTriage.TabIndex = 2;
            this.grpContextoTriage.Text = "Datos del paciente y consulta de Enfermeria";
            this.grpContextoTriage.TitleColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(210)))), ((int)(((byte)(185)))));
            // 
            // pnlTriageBadge
            // 
            this.pnlTriageBadge.Controls.Add(this.lblPrioridadValor);
            this.pnlTriageBadge.Controls.Add(this.lblTitTriageBadge);
            this.pnlTriageBadge.Location = new System.Drawing.Point(684, 83);
            this.pnlTriageBadge.Name = "pnlTriageBadge";
            this.pnlTriageBadge.Size = new System.Drawing.Size(373, 51);
            this.pnlTriageBadge.TabIndex = 11;
            // 
            // lblPrioridadValor
            // 
            this.lblPrioridadValor.AutoSize = true;
            this.lblPrioridadValor.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(204)))), ((int)(((byte)(21)))));
            this.lblPrioridadValor.Location = new System.Drawing.Point(119, 27);
            this.lblPrioridadValor.Name = "lblPrioridadValor";
            this.lblPrioridadValor.Size = new System.Drawing.Size(126, 17);
            this.lblPrioridadValor.TabIndex = 1;
            this.lblPrioridadValor.Text = "Prioridad Asignada";
            // 
            // lblTitTriageBadge
            // 
            this.lblTitTriageBadge.AutoSize = true;
            this.lblTitTriageBadge.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(240)))), ((int)(((byte)(138)))));
            this.lblTitTriageBadge.Location = new System.Drawing.Point(119, 10);
            this.lblTitTriageBadge.Name = "lblTitTriageBadge";
            this.lblTitTriageBadge.Size = new System.Drawing.Size(126, 17);
            this.lblTitTriageBadge.TabIndex = 0;
            this.lblTitTriageBadge.Text = "Prioridad Asignada";
            // 
            // pnlChipPa
            // 
            this.pnlChipPa.Controls.Add(this.lblPaValor);
            this.pnlChipPa.Controls.Add(this.lblTitPa);
            this.pnlChipPa.Location = new System.Drawing.Point(515, 83);
            this.pnlChipPa.Name = "pnlChipPa";
            this.pnlChipPa.Size = new System.Drawing.Size(133, 51);
            this.pnlChipPa.TabIndex = 10;
            // 
            // lblPaValor
            // 
            this.lblPaValor.AutoSize = true;
            this.lblPaValor.ForeColor = System.Drawing.Color.White;
            this.lblPaValor.Location = new System.Drawing.Point(20, 27);
            this.lblPaValor.Name = "lblPaValor";
            this.lblPaValor.Size = new System.Drawing.Size(93, 17);
            this.lblPaValor.TabIndex = 7;
            this.lblPaValor.Text = "Frec. Cardíaca";
            // 
            // lblTitPa
            // 
            this.lblTitPa.AutoSize = true;
            this.lblTitPa.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(159)))), ((int)(((byte)(176)))), ((int)(((byte)(184)))));
            this.lblTitPa.Location = new System.Drawing.Point(20, 10);
            this.lblTitPa.Name = "lblTitPa";
            this.lblTitPa.Size = new System.Drawing.Size(104, 17);
            this.lblTitPa.TabIndex = 6;
            this.lblTitPa.Text = "Presión Arterial";
            // 
            // pnlChipSat
            // 
            this.pnlChipSat.Controls.Add(this.lblSatValor);
            this.pnlChipSat.Controls.Add(this.lblTitSat);
            this.pnlChipSat.Location = new System.Drawing.Point(352, 83);
            this.pnlChipSat.Name = "pnlChipSat";
            this.pnlChipSat.Size = new System.Drawing.Size(133, 51);
            this.pnlChipSat.TabIndex = 9;
            // 
            // lblSatValor
            // 
            this.lblSatValor.AutoSize = true;
            this.lblSatValor.ForeColor = System.Drawing.Color.White;
            this.lblSatValor.Location = new System.Drawing.Point(20, 27);
            this.lblSatValor.Name = "lblSatValor";
            this.lblSatValor.Size = new System.Drawing.Size(93, 17);
            this.lblSatValor.TabIndex = 7;
            this.lblSatValor.Text = "Frec. Cardíaca";
            // 
            // lblTitSat
            // 
            this.lblTitSat.AutoSize = true;
            this.lblTitSat.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(159)))), ((int)(((byte)(176)))), ((int)(((byte)(184)))));
            this.lblTitSat.Location = new System.Drawing.Point(20, 10);
            this.lblTitSat.Name = "lblTitSat";
            this.lblTitSat.Size = new System.Drawing.Size(94, 17);
            this.lblTitSat.TabIndex = 6;
            this.lblTitSat.Text = "Saturación O2";
            // 
            // pnlChipTemp
            // 
            this.pnlChipTemp.Controls.Add(this.lblTempVal);
            this.pnlChipTemp.Controls.Add(this.lblTitTemp);
            this.pnlChipTemp.Location = new System.Drawing.Point(187, 83);
            this.pnlChipTemp.Name = "pnlChipTemp";
            this.pnlChipTemp.Size = new System.Drawing.Size(133, 51);
            this.pnlChipTemp.TabIndex = 8;
            // 
            // lblTempVal
            // 
            this.lblTempVal.AutoSize = true;
            this.lblTempVal.ForeColor = System.Drawing.Color.White;
            this.lblTempVal.Location = new System.Drawing.Point(20, 27);
            this.lblTempVal.Name = "lblTempVal";
            this.lblTempVal.Size = new System.Drawing.Size(93, 17);
            this.lblTempVal.TabIndex = 7;
            this.lblTempVal.Text = "Frec. Cardíaca";
            // 
            // lblTitTemp
            // 
            this.lblTitTemp.AutoSize = true;
            this.lblTitTemp.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(159)))), ((int)(((byte)(176)))), ((int)(((byte)(184)))));
            this.lblTitTemp.Location = new System.Drawing.Point(20, 10);
            this.lblTitTemp.Name = "lblTitTemp";
            this.lblTitTemp.Size = new System.Drawing.Size(86, 17);
            this.lblTitTemp.TabIndex = 6;
            this.lblTitTemp.Text = "Temperatura";
            // 
            // pnlChipFc
            // 
            this.pnlChipFc.Controls.Add(this.lblFcValor);
            this.pnlChipFc.Controls.Add(this.lblTitFc);
            this.pnlChipFc.Location = new System.Drawing.Point(23, 83);
            this.pnlChipFc.Name = "pnlChipFc";
            this.pnlChipFc.Size = new System.Drawing.Size(133, 51);
            this.pnlChipFc.TabIndex = 5;
            // 
            // lblFcValor
            // 
            this.lblFcValor.AutoSize = true;
            this.lblFcValor.ForeColor = System.Drawing.Color.White;
            this.lblFcValor.Location = new System.Drawing.Point(20, 27);
            this.lblFcValor.Name = "lblFcValor";
            this.lblFcValor.Size = new System.Drawing.Size(93, 17);
            this.lblFcValor.TabIndex = 7;
            this.lblFcValor.Text = "Frec. Cardíaca";
            // 
            // lblTitFc
            // 
            this.lblTitFc.AutoSize = true;
            this.lblTitFc.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(159)))), ((int)(((byte)(176)))), ((int)(((byte)(184)))));
            this.lblTitFc.Location = new System.Drawing.Point(20, 10);
            this.lblTitFc.Name = "lblTitFc";
            this.lblTitFc.Size = new System.Drawing.Size(93, 17);
            this.lblTitFc.TabIndex = 6;
            this.lblTitFc.Text = "Frec. Cardíaca";
            // 
            // btnVerHistoriaClinica
            // 
            this.btnVerHistoriaClinica.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(66)))), ((int)(((byte)(88)))));
            this.btnVerHistoriaClinica.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(189)))), ((int)(((byte)(248)))));
            this.btnVerHistoriaClinica.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVerHistoriaClinica.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(189)))), ((int)(((byte)(248)))));
            this.btnVerHistoriaClinica.Location = new System.Drawing.Point(817, 26);
            this.btnVerHistoriaClinica.Name = "btnVerHistoriaClinica";
            this.btnVerHistoriaClinica.Size = new System.Drawing.Size(240, 36);
            this.btnVerHistoriaClinica.TabIndex = 4;
            this.btnVerHistoriaClinica.Text = "📋 Historia Clínica";
            this.btnVerHistoriaClinica.UseVisualStyleBackColor = false;
            this.btnVerHistoriaClinica.Click += new System.EventHandler(this.btnVerHistoriaClinica_Click);
            // 
            // lblMotivoValor
            // 
            this.lblMotivoValor.AutoSize = true;
            this.lblMotivoValor.ForeColor = System.Drawing.Color.White;
            this.lblMotivoValor.Location = new System.Drawing.Point(456, 36);
            this.lblMotivoValor.Name = "lblMotivoValor";
            this.lblMotivoValor.Size = new System.Drawing.Size(45, 17);
            this.lblMotivoValor.TabIndex = 3;
            this.lblMotivoValor.Text = "label1";
            // 
            // lblTitMotivo
            // 
            this.lblTitMotivo.AutoSize = true;
            this.lblTitMotivo.Location = new System.Drawing.Point(398, 36);
            this.lblTitMotivo.Name = "lblTitMotivo";
            this.lblTitMotivo.Size = new System.Drawing.Size(52, 17);
            this.lblTitMotivo.TabIndex = 2;
            this.lblTitMotivo.Text = "Motivo";
            // 
            // lblPacienteDatos
            // 
            this.lblPacienteDatos.AutoSize = true;
            this.lblPacienteDatos.ForeColor = System.Drawing.Color.White;
            this.lblPacienteDatos.Location = new System.Drawing.Point(86, 36);
            this.lblPacienteDatos.Name = "lblPacienteDatos";
            this.lblPacienteDatos.Size = new System.Drawing.Size(60, 17);
            this.lblPacienteDatos.TabIndex = 1;
            this.lblPacienteDatos.Text = "Paciente";
            // 
            // lblTitPaciente
            // 
            this.lblTitPaciente.AutoSize = true;
            this.lblTitPaciente.Location = new System.Drawing.Point(20, 36);
            this.lblTitPaciente.Name = "lblTitPaciente";
            this.lblTitPaciente.Size = new System.Drawing.Size(60, 17);
            this.lblTitPaciente.TabIndex = 0;
            this.lblTitPaciente.Text = "Paciente";
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.White;
            this.pnlHeader.Controls.Add(this.lblTituloModulo);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Padding = new System.Windows.Forms.Padding(15, 0, 15, 0);
            this.pnlHeader.Size = new System.Drawing.Size(1099, 52);
            this.pnlHeader.TabIndex = 1;
            // 
            // lblTituloModulo
            // 
            this.lblTituloModulo.AutoSize = true;
            this.lblTituloModulo.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTituloModulo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.lblTituloModulo.Location = new System.Drawing.Point(18, 15);
            this.lblTituloModulo.Name = "lblTituloModulo";
            this.lblTituloModulo.Size = new System.Drawing.Size(444, 20);
            this.lblTituloModulo.TabIndex = 0;
            this.lblTituloModulo.Text = "Hospital Sagrado Corazón | Box de Atención Médica de Guardia";
            // 
            // AtencionMedicaForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(218)))), ((int)(((byte)(229)))));
            this.ClientSize = new System.Drawing.Size(1101, 783);
            this.Controls.Add(this.pnlMainContainer);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "AtencionMedicaForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AtencionMedicaForm";
            this.pnlMainContainer.ResumeLayout(false);
            this.grpDestinoAsistencial.ResumeLayout(false);
            this.grpDestinoAsistencial.PerformLayout();
            this.grpEvolucionMedica.ResumeLayout(false);
            this.grpEvolucionMedica.PerformLayout();
            this.grpContextoTriage.ResumeLayout(false);
            this.grpContextoTriage.PerformLayout();
            this.pnlTriageBadge.ResumeLayout(false);
            this.pnlTriageBadge.PerformLayout();
            this.pnlChipPa.ResumeLayout(false);
            this.pnlChipPa.PerformLayout();
            this.pnlChipSat.ResumeLayout(false);
            this.pnlChipSat.PerformLayout();
            this.pnlChipTemp.ResumeLayout(false);
            this.pnlChipTemp.PerformLayout();
            this.pnlChipFc.ResumeLayout(false);
            this.pnlChipFc.PerformLayout();
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlMainContainer;
        private DarkGroupBox grpContextoTriage;
        private System.Windows.Forms.Label lblTitMotivo;
        private System.Windows.Forms.Label lblPacienteDatos;
        private System.Windows.Forms.Label lblTitPaciente;
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblTituloModulo;
        private System.Windows.Forms.Panel pnlChipFc;
        private System.Windows.Forms.Label lblFcValor;
        private System.Windows.Forms.Label lblTitFc;
        private System.Windows.Forms.Button btnVerHistoriaClinica;
        private System.Windows.Forms.Label lblMotivoValor;
        private System.Windows.Forms.Panel pnlTriageBadge;
        private System.Windows.Forms.Panel pnlChipPa;
        private System.Windows.Forms.Label lblPaValor;
        private System.Windows.Forms.Label lblTitPa;
        private System.Windows.Forms.Panel pnlChipSat;
        private System.Windows.Forms.Label lblSatValor;
        private System.Windows.Forms.Label lblTitSat;
        private System.Windows.Forms.Panel pnlChipTemp;
        private System.Windows.Forms.Label lblTempVal;
        private System.Windows.Forms.Label lblTitTemp;
        private DarkGroupBox grpEvolucionMedica;
        private System.Windows.Forms.TextBox txtDiagnostico;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblPrioridadValor;
        private System.Windows.Forms.Label lblTitTriageBadge;
        private DarkGroupBox grpDestinoAsistencial;
        private System.Windows.Forms.Label lblTitDiagnostico;
        private System.Windows.Forms.TextBox txtIndicaciones;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbDestino;
        private System.Windows.Forms.Button btnFinalizarAtencion;
    }
}