namespace SistemaTurnos
{
    partial class AdmisionGuardiaForm
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
            this.btnConfirmarIngreso = new System.Windows.Forms.Button();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.pnlEpisodio = new SistemaTurnos.DarkGroupBox();
            this.txtMotivoConsulta = new System.Windows.Forms.TextBox();
            this.lblFechaIngresoTitulo = new System.Windows.Forms.Label();
            this.lblMotivoConsulta = new System.Windows.Forms.Label();
            this.lblFechaIngresoValor = new System.Windows.Forms.Label();
            this.grpDatosFiliatorios = new SistemaTurnos.DarkGroupBox();
            this.btnModificarPaciente = new System.Windows.Forms.Button();
            this.lblNombre = new System.Windows.Forms.Label();
            this.txtTelefono = new System.Windows.Forms.TextBox();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.lblTelefono = new System.Windows.Forms.Label();
            this.lblApellido = new System.Windows.Forms.Label();
            this.dtpFecNac = new System.Windows.Forms.DateTimePicker();
            this.txtApellido = new System.Windows.Forms.TextBox();
            this.lblFecNac = new System.Windows.Forms.Label();
            this.pnlIdentificacion = new SistemaTurnos.DarkGroupBox();
            this.badgeEstado = new System.Windows.Forms.Button();
            this.lblDni = new System.Windows.Forms.Label();
            this.btnBuscarPaciente = new System.Windows.Forms.Button();
            this.txtDni = new System.Windows.Forms.TextBox();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.pnlMainContainer.SuspendLayout();
            this.pnlHeader.SuspendLayout();
            this.pnlEpisodio.SuspendLayout();
            this.grpDatosFiliatorios.SuspendLayout();
            this.pnlIdentificacion.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlMainContainer
            // 
            this.pnlMainContainer.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.pnlMainContainer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(242)))), ((int)(((byte)(246)))));
            this.pnlMainContainer.Controls.Add(this.btnCancelar);
            this.pnlMainContainer.Controls.Add(this.pnlHeader);
            this.pnlMainContainer.Controls.Add(this.pnlEpisodio);
            this.pnlMainContainer.Controls.Add(this.grpDatosFiliatorios);
            this.pnlMainContainer.Controls.Add(this.pnlIdentificacion);
            this.pnlMainContainer.Controls.Add(this.btnConfirmarIngreso);
            this.pnlMainContainer.Controls.Add(this.btnLimpiar);
            this.pnlMainContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMainContainer.Location = new System.Drawing.Point(0, 0);
            this.pnlMainContainer.Name = "pnlMainContainer";
            this.pnlMainContainer.Size = new System.Drawing.Size(778, 561);
            this.pnlMainContainer.TabIndex = 0;
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.White;
            this.pnlHeader.Controls.Add(this.lblHeader);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(778, 56);
            this.pnlHeader.TabIndex = 10;
            // 
            // lblHeader
            // 
            this.lblHeader.AutoSize = true;
            this.lblHeader.BackColor = System.Drawing.Color.White;
            this.lblHeader.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHeader.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.lblHeader.Location = new System.Drawing.Point(14, 22);
            this.lblHeader.Name = "lblHeader";
            this.lblHeader.Size = new System.Drawing.Size(318, 17);
            this.lblHeader.TabIndex = 2;
            this.lblHeader.Text = "Hospital Sagrado Corazón | Inicio Consulta Guardia";
            // 
            // btnConfirmarIngreso
            // 
            this.btnConfirmarIngreso.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(210)))), ((int)(((byte)(185)))));
            this.btnConfirmarIngreso.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnConfirmarIngreso.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(111)))), ((int)(((byte)(83)))));
            this.btnConfirmarIngreso.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConfirmarIngreso.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.btnConfirmarIngreso.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(62)))), ((int)(((byte)(48)))));
            this.btnConfirmarIngreso.Location = new System.Drawing.Point(509, 517);
            this.btnConfirmarIngreso.Name = "btnConfirmarIngreso";
            this.btnConfirmarIngreso.Size = new System.Drawing.Size(251, 32);
            this.btnConfirmarIngreso.TabIndex = 6;
            this.btnConfirmarIngreso.Text = "✓ Confirmar Ingreso a Guardia";
            this.btnConfirmarIngreso.UseVisualStyleBackColor = false;
            this.btnConfirmarIngreso.Click += new System.EventHandler(this.btnConfirmarIngreso_Click);
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(232)))), ((int)(((byte)(240)))));
            this.btnLimpiar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLimpiar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(213)))), ((int)(((byte)(225)))));
            this.btnLimpiar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLimpiar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(85)))), ((int)(((byte)(105)))));
            this.btnLimpiar.Location = new System.Drawing.Point(291, 517);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(157, 32);
            this.btnLimpiar.TabIndex = 5;
            this.btnLimpiar.Text = "Limpiar Campos";
            this.btnLimpiar.UseVisualStyleBackColor = false;
            this.btnLimpiar.Click += new System.EventHandler(this.btnCancelar_Click_1);
            // 
            // pnlEpisodio
            // 
            this.pnlEpisodio.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(51)))), ((int)(((byte)(57)))));
            this.pnlEpisodio.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(71)))), ((int)(((byte)(79)))));
            this.pnlEpisodio.BorderRadius = 8;
            this.pnlEpisodio.Controls.Add(this.txtMotivoConsulta);
            this.pnlEpisodio.Controls.Add(this.lblFechaIngresoTitulo);
            this.pnlEpisodio.Controls.Add(this.lblMotivoConsulta);
            this.pnlEpisodio.Controls.Add(this.lblFechaIngresoValor);
            this.pnlEpisodio.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnlEpisodio.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(210)))), ((int)(((byte)(185)))));
            this.pnlEpisodio.Location = new System.Drawing.Point(17, 336);
            this.pnlEpisodio.Name = "pnlEpisodio";
            this.pnlEpisodio.Padding = new System.Windows.Forms.Padding(16, 32, 16, 16);
            this.pnlEpisodio.Size = new System.Drawing.Size(743, 175);
            this.pnlEpisodio.TabIndex = 9;
            this.pnlEpisodio.Text = "REGISTRO  ASISTENCIAL";
            this.pnlEpisodio.TitleColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(210)))), ((int)(((byte)(185)))));
            // 
            // txtMotivoConsulta
            // 
            this.txtMotivoConsulta.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(40)))), ((int)(((byte)(45)))));
            this.txtMotivoConsulta.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMotivoConsulta.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.txtMotivoConsulta.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(245)))), ((int)(((byte)(249)))));
            this.txtMotivoConsulta.Location = new System.Drawing.Point(22, 77);
            this.txtMotivoConsulta.Multiline = true;
            this.txtMotivoConsulta.Name = "txtMotivoConsulta";
            this.txtMotivoConsulta.Size = new System.Drawing.Size(702, 69);
            this.txtMotivoConsulta.TabIndex = 19;
            // 
            // lblFechaIngresoTitulo
            // 
            this.lblFechaIngresoTitulo.AutoSize = true;
            this.lblFechaIngresoTitulo.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFechaIngresoTitulo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(159)))), ((int)(((byte)(176)))), ((int)(((byte)(184)))));
            this.lblFechaIngresoTitulo.Location = new System.Drawing.Point(14, 32);
            this.lblFechaIngresoTitulo.Name = "lblFechaIngresoTitulo";
            this.lblFechaIngresoTitulo.Size = new System.Drawing.Size(123, 17);
            this.lblFechaIngresoTitulo.TabIndex = 14;
            this.lblFechaIngresoTitulo.Text = "Fecha/Hora Ingreso";
            // 
            // lblMotivoConsulta
            // 
            this.lblMotivoConsulta.AutoSize = true;
            this.lblMotivoConsulta.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(40)))), ((int)(((byte)(45)))));
            this.lblMotivoConsulta.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMotivoConsulta.ForeColor = System.Drawing.Color.White;
            this.lblMotivoConsulta.Location = new System.Drawing.Point(19, 61);
            this.lblMotivoConsulta.Name = "lblMotivoConsulta";
            this.lblMotivoConsulta.Size = new System.Drawing.Size(122, 17);
            this.lblMotivoConsulta.TabIndex = 18;
            this.lblMotivoConsulta.Text = "Motivo de Consulta";
            // 
            // lblFechaIngresoValor
            // 
            this.lblFechaIngresoValor.AutoSize = true;
            this.lblFechaIngresoValor.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFechaIngresoValor.ForeColor = System.Drawing.Color.White;
            this.lblFechaIngresoValor.Location = new System.Drawing.Point(148, 32);
            this.lblFechaIngresoValor.Name = "lblFechaIngresoValor";
            this.lblFechaIngresoValor.Size = new System.Drawing.Size(43, 17);
            this.lblFechaIngresoValor.TabIndex = 15;
            this.lblFechaIngresoValor.Text = "label2";
            // 
            // grpDatosFiliatorios
            // 
            this.grpDatosFiliatorios.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(51)))), ((int)(((byte)(57)))));
            this.grpDatosFiliatorios.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(71)))), ((int)(((byte)(79)))));
            this.grpDatosFiliatorios.BorderRadius = 8;
            this.grpDatosFiliatorios.Controls.Add(this.btnModificarPaciente);
            this.grpDatosFiliatorios.Controls.Add(this.lblNombre);
            this.grpDatosFiliatorios.Controls.Add(this.txtTelefono);
            this.grpDatosFiliatorios.Controls.Add(this.txtNombre);
            this.grpDatosFiliatorios.Controls.Add(this.lblTelefono);
            this.grpDatosFiliatorios.Controls.Add(this.lblApellido);
            this.grpDatosFiliatorios.Controls.Add(this.dtpFecNac);
            this.grpDatosFiliatorios.Controls.Add(this.txtApellido);
            this.grpDatosFiliatorios.Controls.Add(this.lblFecNac);
            this.grpDatosFiliatorios.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.grpDatosFiliatorios.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(210)))), ((int)(((byte)(185)))));
            this.grpDatosFiliatorios.Location = new System.Drawing.Point(17, 170);
            this.grpDatosFiliatorios.Name = "grpDatosFiliatorios";
            this.grpDatosFiliatorios.Padding = new System.Windows.Forms.Padding(16, 32, 16, 16);
            this.grpDatosFiliatorios.Size = new System.Drawing.Size(743, 160);
            this.grpDatosFiliatorios.TabIndex = 8;
            this.grpDatosFiliatorios.Text = "DATOS PERSONALES";
            this.grpDatosFiliatorios.TitleColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(210)))), ((int)(((byte)(185)))));
            // 
            // btnModificarPaciente
            // 
            this.btnModificarPaciente.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(42)))), ((int)(((byte)(47)))));
            this.btnModificarPaciente.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnModificarPaciente.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(82)))), ((int)(((byte)(92)))));
            this.btnModificarPaciente.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnModificarPaciente.Location = new System.Drawing.Point(442, 116);
            this.btnModificarPaciente.Name = "btnModificarPaciente";
            this.btnModificarPaciente.Size = new System.Drawing.Size(271, 35);
            this.btnModificarPaciente.TabIndex = 13;
            this.btnModificarPaciente.Text = "Modificar / Alta Paciente";
            this.btnModificarPaciente.UseVisualStyleBackColor = false;
            this.btnModificarPaciente.Click += new System.EventHandler(this.btnModificarPaciente_Click);
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(40)))), ((int)(((byte)(45)))));
            this.lblNombre.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNombre.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(159)))), ((int)(((byte)(176)))), ((int)(((byte)(184)))));
            this.lblNombre.Location = new System.Drawing.Point(19, 53);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(57, 17);
            this.lblNombre.TabIndex = 5;
            this.lblNombre.Text = "Nombre";
            // 
            // txtTelefono
            // 
            this.txtTelefono.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(40)))), ((int)(((byte)(45)))));
            this.txtTelefono.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTelefono.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.txtTelefono.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(245)))), ((int)(((byte)(249)))));
            this.txtTelefono.Location = new System.Drawing.Point(514, 82);
            this.txtTelefono.Name = "txtTelefono";
            this.txtTelefono.Size = new System.Drawing.Size(199, 20);
            this.txtTelefono.TabIndex = 12;
            // 
            // txtNombre
            // 
            this.txtNombre.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(40)))), ((int)(((byte)(45)))));
            this.txtNombre.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.txtNombre.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(245)))), ((int)(((byte)(249)))));
            this.txtNombre.Location = new System.Drawing.Point(91, 53);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(160, 20);
            this.txtNombre.TabIndex = 6;
            // 
            // lblTelefono
            // 
            this.lblTelefono.AutoSize = true;
            this.lblTelefono.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(40)))), ((int)(((byte)(45)))));
            this.lblTelefono.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTelefono.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(159)))), ((int)(((byte)(176)))), ((int)(((byte)(184)))));
            this.lblTelefono.Location = new System.Drawing.Point(439, 85);
            this.lblTelefono.Name = "lblTelefono";
            this.lblTelefono.Size = new System.Drawing.Size(58, 17);
            this.lblTelefono.TabIndex = 11;
            this.lblTelefono.Text = "Teléfono";
            // 
            // lblApellido
            // 
            this.lblApellido.AutoSize = true;
            this.lblApellido.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(40)))), ((int)(((byte)(45)))));
            this.lblApellido.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblApellido.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(159)))), ((int)(((byte)(176)))), ((int)(((byte)(184)))));
            this.lblApellido.Location = new System.Drawing.Point(441, 49);
            this.lblApellido.Name = "lblApellido";
            this.lblApellido.Size = new System.Drawing.Size(56, 17);
            this.lblApellido.TabIndex = 7;
            this.lblApellido.Text = "Apellido";
            // 
            // dtpFecNac
            // 
            this.dtpFecNac.CalendarMonthBackground = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(40)))), ((int)(((byte)(45)))));
            this.dtpFecNac.CalendarTitleBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(51)))), ((int)(((byte)(57)))));
            this.dtpFecNac.CalendarTitleForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(210)))), ((int)(((byte)(185)))));
            this.dtpFecNac.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFecNac.Location = new System.Drawing.Point(91, 85);
            this.dtpFecNac.Name = "dtpFecNac";
            this.dtpFecNac.Size = new System.Drawing.Size(160, 24);
            this.dtpFecNac.TabIndex = 10;
            // 
            // txtApellido
            // 
            this.txtApellido.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(40)))), ((int)(((byte)(45)))));
            this.txtApellido.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtApellido.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.txtApellido.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(245)))), ((int)(((byte)(249)))));
            this.txtApellido.Location = new System.Drawing.Point(514, 50);
            this.txtApellido.Name = "txtApellido";
            this.txtApellido.Size = new System.Drawing.Size(199, 20);
            this.txtApellido.TabIndex = 8;
            // 
            // lblFecNac
            // 
            this.lblFecNac.AutoSize = true;
            this.lblFecNac.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(40)))), ((int)(((byte)(45)))));
            this.lblFecNac.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFecNac.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(159)))), ((int)(((byte)(176)))), ((int)(((byte)(184)))));
            this.lblFecNac.Location = new System.Drawing.Point(20, 91);
            this.lblFecNac.Name = "lblFecNac";
            this.lblFecNac.Size = new System.Drawing.Size(57, 17);
            this.lblFecNac.TabIndex = 9;
            this.lblFecNac.Text = "Fec. Nac";
            // 
            // pnlIdentificacion
            // 
            this.pnlIdentificacion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(51)))), ((int)(((byte)(57)))));
            this.pnlIdentificacion.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(71)))), ((int)(((byte)(79)))));
            this.pnlIdentificacion.BorderRadius = 8;
            this.pnlIdentificacion.Controls.Add(this.badgeEstado);
            this.pnlIdentificacion.Controls.Add(this.lblDni);
            this.pnlIdentificacion.Controls.Add(this.btnBuscarPaciente);
            this.pnlIdentificacion.Controls.Add(this.txtDni);
            this.pnlIdentificacion.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.pnlIdentificacion.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(210)))), ((int)(((byte)(185)))));
            this.pnlIdentificacion.Location = new System.Drawing.Point(17, 64);
            this.pnlIdentificacion.Name = "pnlIdentificacion";
            this.pnlIdentificacion.Padding = new System.Windows.Forms.Padding(16, 32, 16, 16);
            this.pnlIdentificacion.Size = new System.Drawing.Size(743, 100);
            this.pnlIdentificacion.TabIndex = 7;
            this.pnlIdentificacion.Text = "IDENTIFICACIÓN PACIENTE";
            this.pnlIdentificacion.TitleColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(210)))), ((int)(((byte)(185)))));
            // 
            // badgeEstado
            // 
            this.badgeEstado.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(54)))), ((int)(((byte)(43)))));
            this.badgeEstado.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(106)))), ((int)(((byte)(83)))));
            this.badgeEstado.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.badgeEstado.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(234)))), ((int)(((byte)(212)))));
            this.badgeEstado.Location = new System.Drawing.Point(546, 35);
            this.badgeEstado.Name = "badgeEstado";
            this.badgeEstado.Size = new System.Drawing.Size(167, 32);
            this.badgeEstado.TabIndex = 3;
            this.badgeEstado.Text = "✓ REGISTRADO";
            this.badgeEstado.UseVisualStyleBackColor = false;
            // 
            // lblDni
            // 
            this.lblDni.AutoSize = true;
            this.lblDni.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(40)))), ((int)(((byte)(45)))));
            this.lblDni.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDni.ForeColor = System.Drawing.Color.White;
            this.lblDni.Location = new System.Drawing.Point(20, 42);
            this.lblDni.Name = "lblDni";
            this.lblDni.Size = new System.Drawing.Size(118, 17);
            this.lblDni.TabIndex = 0;
            this.lblDni.Text = "DNI / Documento";
            // 
            // btnBuscarPaciente
            // 
            this.btnBuscarPaciente.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(74)))), ((int)(((byte)(86)))));
            this.btnBuscarPaciente.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBuscarPaciente.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(103)))), ((int)(((byte)(120)))));
            this.btnBuscarPaciente.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuscarPaciente.ForeColor = System.Drawing.Color.White;
            this.btnBuscarPaciente.Location = new System.Drawing.Point(361, 35);
            this.btnBuscarPaciente.Name = "btnBuscarPaciente";
            this.btnBuscarPaciente.Size = new System.Drawing.Size(162, 31);
            this.btnBuscarPaciente.TabIndex = 2;
            this.btnBuscarPaciente.Text = "🔍 Buscar Paciente";
            this.btnBuscarPaciente.UseVisualStyleBackColor = false;
            this.btnBuscarPaciente.Click += new System.EventHandler(this.btnBuscarPaciente_Click);
            // 
            // txtDni
            // 
            this.txtDni.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(40)))), ((int)(((byte)(45)))));
            this.txtDni.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDni.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.txtDni.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(245)))), ((int)(((byte)(249)))));
            this.txtDni.Location = new System.Drawing.Point(151, 42);
            this.txtDni.Name = "txtDni";
            this.txtDni.Size = new System.Drawing.Size(112, 20);
            this.txtDni.TabIndex = 1;
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(232)))), ((int)(((byte)(240)))));
            this.btnCancelar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancelar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(213)))), ((int)(((byte)(225)))));
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(85)))), ((int)(((byte)(105)))));
            this.btnCancelar.Location = new System.Drawing.Point(17, 517);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(148, 32);
            this.btnCancelar.TabIndex = 11;
            this.btnCancelar.Text = "✗ Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // AdmisionGuardiaForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(218)))), ((int)(((byte)(229)))));
            this.ClientSize = new System.Drawing.Size(778, 561);
            this.Controls.Add(this.pnlMainContainer);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(245)))), ((int)(((byte)(249)))));
            this.Name = "AdmisionGuardiaForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AdmisionGuardiaForm";
            this.pnlMainContainer.ResumeLayout(false);
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.pnlEpisodio.ResumeLayout(false);
            this.pnlEpisodio.PerformLayout();
            this.grpDatosFiliatorios.ResumeLayout(false);
            this.grpDatosFiliatorios.PerformLayout();
            this.pnlIdentificacion.ResumeLayout(false);
            this.pnlIdentificacion.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlMainContainer;
        private System.Windows.Forms.Label lblDni;
        private System.Windows.Forms.Button btnModificarPaciente;
        private System.Windows.Forms.TextBox txtTelefono;
        private System.Windows.Forms.Label lblTelefono;
        private System.Windows.Forms.DateTimePicker dtpFecNac;
        private System.Windows.Forms.Label lblFecNac;
        private System.Windows.Forms.TextBox txtApellido;
        private System.Windows.Forms.Label lblApellido;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.Button badgeEstado;
        private System.Windows.Forms.Button btnBuscarPaciente;
        private System.Windows.Forms.TextBox txtDni;
        private System.Windows.Forms.TextBox txtMotivoConsulta;
        private System.Windows.Forms.Label lblMotivoConsulta;
        private System.Windows.Forms.Label lblFechaIngresoValor;
        private System.Windows.Forms.Label lblFechaIngresoTitulo;
        private System.Windows.Forms.Button btnConfirmarIngreso;
        private System.Windows.Forms.Button btnLimpiar;
        private DarkGroupBox pnlIdentificacion;
        private DarkGroupBox grpDatosFiliatorios;
        private DarkGroupBox pnlEpisodio;
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblHeader;
        private System.Windows.Forms.Button btnCancelar;
    }
}