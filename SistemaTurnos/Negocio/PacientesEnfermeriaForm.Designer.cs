namespace SistemaTurnos.Negocio
{
    partial class PacientesEnfermeriaForm
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
            this.pnlMainContainer = new System.Windows.Forms.Panel();
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblTituloModulo = new System.Windows.Forms.Label();
            this.grpEpisodiosActivos = new SistemaTurnos.DarkGroupBox();
            this.pnlModalAbandono = new System.Windows.Forms.Panel();
            this.pnlModalHeader = new System.Windows.Forms.Panel();
            this.lblModalTitulo = new System.Windows.Forms.Label();
            this.btnModalConfirmar = new System.Windows.Forms.Button();
            this.btnModalCancelar = new System.Windows.Forms.Button();
            this.pnlModalResumen = new System.Windows.Forms.Panel();
            this.lblModalPaciente = new System.Windows.Forms.Label();
            this.lblModalEpisodioDni = new System.Windows.Forms.Label();
            this.lblModalPregunta = new System.Windows.Forms.Label();
            this.dgvEpisodios = new System.Windows.Forms.DataGridView();
            this.colId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colIngreso = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPaciente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMotivo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEstado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAcciones = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlMainContainer.SuspendLayout();
            this.pnlHeader.SuspendLayout();
            this.grpEpisodiosActivos.SuspendLayout();
            this.pnlModalAbandono.SuspendLayout();
            this.pnlModalHeader.SuspendLayout();
            this.pnlModalResumen.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEpisodios)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlMainContainer
            // 
            this.pnlMainContainer.BackColor = System.Drawing.Color.White;
            this.pnlMainContainer.Controls.Add(this.grpEpisodiosActivos);
            this.pnlMainContainer.Controls.Add(this.pnlHeader);
            this.pnlMainContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMainContainer.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnlMainContainer.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(213)))), ((int)(((byte)(225)))));
            this.pnlMainContainer.Location = new System.Drawing.Point(0, 0);
            this.pnlMainContainer.Name = "pnlMainContainer";
            this.pnlMainContainer.Size = new System.Drawing.Size(942, 663);
            this.pnlMainContainer.TabIndex = 0;
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.White;
            this.pnlHeader.Controls.Add(this.lblTituloModulo);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Padding = new System.Windows.Forms.Padding(15, 0, 15, 0);
            this.pnlHeader.Size = new System.Drawing.Size(942, 52);
            this.pnlHeader.TabIndex = 0;
            // 
            // lblTituloModulo
            // 
            this.lblTituloModulo.AutoSize = true;
            this.lblTituloModulo.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTituloModulo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.lblTituloModulo.Location = new System.Drawing.Point(18, 15);
            this.lblTituloModulo.Name = "lblTituloModulo";
            this.lblTituloModulo.Size = new System.Drawing.Size(412, 20);
            this.lblTituloModulo.TabIndex = 0;
            this.lblTituloModulo.Text = "Hospital Sagrado Corazón | Módulo de Admisión y Guardia";
            // 
            // grpEpisodiosActivos
            // 
            this.grpEpisodiosActivos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(51)))), ((int)(((byte)(57)))));
            this.grpEpisodiosActivos.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(71)))), ((int)(((byte)(79)))));
            this.grpEpisodiosActivos.BorderRadius = 8;
            this.grpEpisodiosActivos.Controls.Add(this.pnlModalAbandono);
            this.grpEpisodiosActivos.Controls.Add(this.dgvEpisodios);
            this.grpEpisodiosActivos.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.grpEpisodiosActivos.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(210)))), ((int)(((byte)(185)))));
            this.grpEpisodiosActivos.Location = new System.Drawing.Point(15, 70);
            this.grpEpisodiosActivos.Name = "grpEpisodiosActivos";
            this.grpEpisodiosActivos.Padding = new System.Windows.Forms.Padding(16, 32, 16, 16);
            this.grpEpisodiosActivos.Size = new System.Drawing.Size(915, 436);
            this.grpEpisodiosActivos.TabIndex = 1;
            this.grpEpisodiosActivos.Text = "Pacientes En espera - Enfermeria";
            this.grpEpisodiosActivos.TitleColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(210)))), ((int)(((byte)(185)))));
            // 
            // pnlModalAbandono
            // 
            this.pnlModalAbandono.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pnlModalAbandono.Controls.Add(this.pnlModalHeader);
            this.pnlModalAbandono.Controls.Add(this.btnModalConfirmar);
            this.pnlModalAbandono.Controls.Add(this.btnModalCancelar);
            this.pnlModalAbandono.Controls.Add(this.pnlModalResumen);
            this.pnlModalAbandono.Controls.Add(this.lblModalPregunta);
            this.pnlModalAbandono.Location = new System.Drawing.Point(173, 148);
            this.pnlModalAbandono.Name = "pnlModalAbandono";
            this.pnlModalAbandono.Padding = new System.Windows.Forms.Padding(1);
            this.pnlModalAbandono.Size = new System.Drawing.Size(464, 270);
            this.pnlModalAbandono.TabIndex = 1;
            this.pnlModalAbandono.Visible = false;
            // 
            // pnlModalHeader
            // 
            this.pnlModalHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            this.pnlModalHeader.Controls.Add(this.lblModalTitulo);
            this.pnlModalHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlModalHeader.Location = new System.Drawing.Point(1, 1);
            this.pnlModalHeader.Name = "pnlModalHeader";
            this.pnlModalHeader.Size = new System.Drawing.Size(462, 46);
            this.pnlModalHeader.TabIndex = 4;
            // 
            // lblModalTitulo
            // 
            this.lblModalTitulo.AutoSize = true;
            this.lblModalTitulo.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Bold);
            this.lblModalTitulo.ForeColor = System.Drawing.Color.White;
            this.lblModalTitulo.Location = new System.Drawing.Point(20, 15);
            this.lblModalTitulo.Name = "lblModalTitulo";
            this.lblModalTitulo.Size = new System.Drawing.Size(299, 19);
            this.lblModalTitulo.TabIndex = 0;
            this.lblModalTitulo.Text = "⚠ Confirmación de Registro de Abandono";
            // 
            // btnModalConfirmar
            // 
            this.btnModalConfirmar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            this.btnModalConfirmar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnModalConfirmar.FlatAppearance.BorderSize = 0;
            this.btnModalConfirmar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnModalConfirmar.ForeColor = System.Drawing.Color.White;
            this.btnModalConfirmar.Location = new System.Drawing.Point(272, 175);
            this.btnModalConfirmar.Name = "btnModalConfirmar";
            this.btnModalConfirmar.Size = new System.Drawing.Size(140, 34);
            this.btnModalConfirmar.TabIndex = 3;
            this.btnModalConfirmar.Text = "Confirmar";
            this.btnModalConfirmar.UseVisualStyleBackColor = false;
            // 
            // btnModalCancelar
            // 
            this.btnModalCancelar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(245)))), ((int)(((byte)(249)))));
            this.btnModalCancelar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnModalCancelar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(213)))), ((int)(((byte)(225)))));
            this.btnModalCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnModalCancelar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(85)))), ((int)(((byte)(105)))));
            this.btnModalCancelar.Location = new System.Drawing.Point(24, 175);
            this.btnModalCancelar.Name = "btnModalCancelar";
            this.btnModalCancelar.Size = new System.Drawing.Size(141, 34);
            this.btnModalCancelar.TabIndex = 2;
            this.btnModalCancelar.Text = "Cancelar";
            this.btnModalCancelar.UseVisualStyleBackColor = false;
            // 
            // pnlModalResumen
            // 
            this.pnlModalResumen.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            this.pnlModalResumen.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlModalResumen.Controls.Add(this.lblModalPaciente);
            this.pnlModalResumen.Controls.Add(this.lblModalEpisodioDni);
            this.pnlModalResumen.Location = new System.Drawing.Point(23, 88);
            this.pnlModalResumen.Name = "pnlModalResumen";
            this.pnlModalResumen.Size = new System.Drawing.Size(389, 70);
            this.pnlModalResumen.TabIndex = 2;
            // 
            // lblModalPaciente
            // 
            this.lblModalPaciente.AutoSize = true;
            this.lblModalPaciente.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Bold);
            this.lblModalPaciente.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.lblModalPaciente.Location = new System.Drawing.Point(12, 39);
            this.lblModalPaciente.Name = "lblModalPaciente";
            this.lblModalPaciente.Size = new System.Drawing.Size(50, 19);
            this.lblModalPaciente.TabIndex = 1;
            this.lblModalPaciente.Text = "label1";
            // 
            // lblModalEpisodioDni
            // 
            this.lblModalEpisodioDni.AutoSize = true;
            this.lblModalEpisodioDni.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblModalEpisodioDni.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.lblModalEpisodioDni.Location = new System.Drawing.Point(12, 11);
            this.lblModalEpisodioDni.Name = "lblModalEpisodioDni";
            this.lblModalEpisodioDni.Size = new System.Drawing.Size(38, 15);
            this.lblModalEpisodioDni.TabIndex = 0;
            this.lblModalEpisodioDni.Text = "label1";
            // 
            // lblModalPregunta
            // 
            this.lblModalPregunta.AutoSize = true;
            this.lblModalPregunta.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblModalPregunta.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.lblModalPregunta.Location = new System.Drawing.Point(21, 54);
            this.lblModalPregunta.Name = "lblModalPregunta";
            this.lblModalPregunta.Size = new System.Drawing.Size(426, 19);
            this.lblModalPregunta.TabIndex = 1;
            this.lblModalPregunta.Text = "¿Está seguro de que desea registrar el abandono del paciente?";
            // 
            // dgvEpisodios
            // 
            this.dgvEpisodios.AllowUserToAddRows = false;
            this.dgvEpisodios.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(51)))), ((int)(((byte)(57)))));
            this.dgvEpisodios.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvEpisodios.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(66)))), ((int)(((byte)(88)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvEpisodios.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvEpisodios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEpisodios.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colId,
            this.colIngreso,
            this.colPaciente,
            this.colMotivo,
            this.colEstado,
            this.colAcciones});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(37)))), ((int)(((byte)(43)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(210)))), ((int)(((byte)(185)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(65)))), ((int)(((byte)(78)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvEpisodios.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvEpisodios.EnableHeadersVisualStyles = false;
            this.dgvEpisodios.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(71)))), ((int)(((byte)(79)))));
            this.dgvEpisodios.Location = new System.Drawing.Point(23, 46);
            this.dgvEpisodios.MultiSelect = false;
            this.dgvEpisodios.Name = "dgvEpisodios";
            this.dgvEpisodios.RowHeadersVisible = false;
            this.dgvEpisodios.RowTemplate.Height = 48;
            this.dgvEpisodios.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvEpisodios.Size = new System.Drawing.Size(873, 349);
            this.dgvEpisodios.TabIndex = 0;
            // 
            // colId
            // 
            this.colId.HeaderText = "ID";
            this.colId.Name = "colId";
            // 
            // colIngreso
            // 
            this.colIngreso.HeaderText = "Ingreso";
            this.colIngreso.Name = "colIngreso";
            // 
            // colPaciente
            // 
            this.colPaciente.HeaderText = "Paciente";
            this.colPaciente.Name = "colPaciente";
            this.colPaciente.Width = 180;
            // 
            // colMotivo
            // 
            this.colMotivo.HeaderText = "Motivo Consulta";
            this.colMotivo.Name = "colMotivo";
            this.colMotivo.Width = 90;
            // 
            // colEstado
            // 
            this.colEstado.HeaderText = "Estado";
            this.colEstado.Name = "colEstado";
            // 
            // colAcciones
            // 
            this.colAcciones.HeaderText = "Acciones";
            this.colAcciones.Name = "colAcciones";
            this.colAcciones.Width = 230;
            // 
            // PacientesEnfermeriaForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(218)))), ((int)(((byte)(229)))));
            this.ClientSize = new System.Drawing.Size(942, 663);
            this.Controls.Add(this.pnlMainContainer);
            this.Name = "PacientesEnfermeriaForm";
            this.Text = "PacientesEnfermeriaForm";
            this.pnlMainContainer.ResumeLayout(false);
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.grpEpisodiosActivos.ResumeLayout(false);
            this.pnlModalAbandono.ResumeLayout(false);
            this.pnlModalAbandono.PerformLayout();
            this.pnlModalHeader.ResumeLayout(false);
            this.pnlModalHeader.PerformLayout();
            this.pnlModalResumen.ResumeLayout(false);
            this.pnlModalResumen.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEpisodios)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlMainContainer;
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblTituloModulo;
        private DarkGroupBox grpEpisodiosActivos;
        private System.Windows.Forms.DataGridView dgvEpisodios;
        private System.Windows.Forms.Panel pnlModalAbandono;
        private System.Windows.Forms.Button btnModalConfirmar;
        private System.Windows.Forms.Button btnModalCancelar;
        private System.Windows.Forms.Panel pnlModalResumen;
        private System.Windows.Forms.Label lblModalPaciente;
        private System.Windows.Forms.Label lblModalEpisodioDni;
        private System.Windows.Forms.Label lblModalPregunta;
        private System.Windows.Forms.Label lblModalTitulo;
        private System.Windows.Forms.Panel pnlModalHeader;
        private System.Windows.Forms.DataGridViewTextBoxColumn colId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIngreso;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPaciente;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMotivo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEstado;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAcciones;
    }
}