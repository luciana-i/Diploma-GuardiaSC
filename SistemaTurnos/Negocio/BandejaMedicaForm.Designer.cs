namespace SistemaTurnos.Negocio
{
    partial class BandejaMedicaForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnlMainContainer = new System.Windows.Forms.Panel();
            this.grpEpisodiosActivos = new SistemaTurnos.DarkGroupBox();
            this.btnRefrescar = new System.Windows.Forms.Button();
            this.cmbFiltroEstado = new System.Windows.Forms.ComboBox();
            this.lblFiltrarPor = new System.Windows.Forms.Label();
            this.lblContadorActivas = new System.Windows.Forms.Label();
            this.dgvEpisodios = new System.Windows.Forms.DataGridView();
            this.colConsultaId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHora = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPaciente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMotivo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPrioridad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAcciones = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblTituloModulo = new System.Windows.Forms.Label();
            this.pnlMainContainer.SuspendLayout();
            this.grpEpisodiosActivos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEpisodios)).BeginInit();
            this.pnlHeader.SuspendLayout();
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
            this.pnlMainContainer.Margin = new System.Windows.Forms.Padding(4);
            this.pnlMainContainer.Name = "pnlMainContainer";
            this.pnlMainContainer.Size = new System.Drawing.Size(1099, 867);
            this.pnlMainContainer.TabIndex = 0;
            // 
            // grpEpisodiosActivos
            // 
            this.grpEpisodiosActivos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(51)))), ((int)(((byte)(57)))));
            this.grpEpisodiosActivos.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(71)))), ((int)(((byte)(79)))));
            this.grpEpisodiosActivos.BorderRadius = 8;
            this.grpEpisodiosActivos.Controls.Add(this.btnRefrescar);
            this.grpEpisodiosActivos.Controls.Add(this.cmbFiltroEstado);
            this.grpEpisodiosActivos.Controls.Add(this.lblFiltrarPor);
            this.grpEpisodiosActivos.Controls.Add(this.lblContadorActivas);
            this.grpEpisodiosActivos.Controls.Add(this.dgvEpisodios);
            this.grpEpisodiosActivos.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.grpEpisodiosActivos.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(210)))), ((int)(((byte)(185)))));
            this.grpEpisodiosActivos.Location = new System.Drawing.Point(18, 92);
            this.grpEpisodiosActivos.Margin = new System.Windows.Forms.Padding(4);
            this.grpEpisodiosActivos.Name = "grpEpisodiosActivos";
            this.grpEpisodiosActivos.Padding = new System.Windows.Forms.Padding(19, 42, 19, 21);
            this.grpEpisodiosActivos.Size = new System.Drawing.Size(1068, 710);
            this.grpEpisodiosActivos.TabIndex = 1;
            this.grpEpisodiosActivos.Text = "Pacientes En espera";
            this.grpEpisodiosActivos.TitleColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(210)))), ((int)(((byte)(185)))));
            // 
            // btnRefrescar
            // 
            this.btnRefrescar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(189)))), ((int)(((byte)(248)))));
            this.btnRefrescar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRefrescar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(189)))), ((int)(((byte)(248)))));
            this.btnRefrescar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefrescar.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnRefrescar.ForeColor = System.Drawing.Color.White;
            this.btnRefrescar.Location = new System.Drawing.Point(903, 61);
            this.btnRefrescar.Margin = new System.Windows.Forms.Padding(4);
            this.btnRefrescar.Name = "btnRefrescar";
            this.btnRefrescar.Size = new System.Drawing.Size(142, 39);
            this.btnRefrescar.TabIndex = 5;
            this.btnRefrescar.Text = "↻ Refrescar";
            this.btnRefrescar.UseVisualStyleBackColor = false;
            // 
            // cmbFiltroEstado
            // 
            this.cmbFiltroEstado.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(40)))), ((int)(((byte)(45)))));
            this.cmbFiltroEstado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFiltroEstado.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbFiltroEstado.ForeColor = System.Drawing.Color.White;
            this.cmbFiltroEstado.FormattingEnabled = true;
            this.cmbFiltroEstado.Location = new System.Drawing.Point(622, 61);
            this.cmbFiltroEstado.Margin = new System.Windows.Forms.Padding(4);
            this.cmbFiltroEstado.Name = "cmbFiltroEstado";
            this.cmbFiltroEstado.Size = new System.Drawing.Size(262, 25);
            this.cmbFiltroEstado.TabIndex = 4;
            // 
            // lblFiltrarPor
            // 
            this.lblFiltrarPor.AutoSize = true;
            this.lblFiltrarPor.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(159)))), ((int)(((byte)(176)))), ((int)(((byte)(184)))));
            this.lblFiltrarPor.Location = new System.Drawing.Point(462, 68);
            this.lblFiltrarPor.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblFiltrarPor.Name = "lblFiltrarPor";
            this.lblFiltrarPor.Size = new System.Drawing.Size(119, 17);
            this.lblFiltrarPor.TabIndex = 3;
            this.lblFiltrarPor.Text = "Filtrar por Estado:";
            // 
            // lblContadorActivas
            // 
            this.lblContadorActivas.AutoSize = true;
            this.lblContadorActivas.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(40)))), ((int)(((byte)(45)))));
            this.lblContadorActivas.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblContadorActivas.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(212)))), ((int)(((byte)(191)))));
            this.lblContadorActivas.Location = new System.Drawing.Point(22, 65);
            this.lblContadorActivas.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblContadorActivas.Name = "lblContadorActivas";
            this.lblContadorActivas.Size = new System.Drawing.Size(214, 17);
            this.lblContadorActivas.TabIndex = 2;
            this.lblContadorActivas.Text = "● Consultas Activas en Guardia: 0";
            this.lblContadorActivas.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // dgvEpisodios
            // 
            this.dgvEpisodios.AllowUserToAddRows = false;
            this.dgvEpisodios.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(51)))), ((int)(((byte)(57)))));
            this.dgvEpisodios.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvEpisodios.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(66)))), ((int)(((byte)(88)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvEpisodios.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvEpisodios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEpisodios.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colConsultaId,
            this.colHora,
            this.colPaciente,
            this.colMotivo,
            this.colPrioridad,
            this.colAcciones});
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(37)))), ((int)(((byte)(43)))));
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(210)))), ((int)(((byte)(185)))));
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(65)))), ((int)(((byte)(78)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvEpisodios.DefaultCellStyle = dataGridViewCellStyle4;
            this.dgvEpisodios.EnableHeadersVisualStyles = false;
            this.dgvEpisodios.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(71)))), ((int)(((byte)(79)))));
            this.dgvEpisodios.Location = new System.Drawing.Point(22, 114);
            this.dgvEpisodios.Margin = new System.Windows.Forms.Padding(4);
            this.dgvEpisodios.MultiSelect = false;
            this.dgvEpisodios.Name = "dgvEpisodios";
            this.dgvEpisodios.RowHeadersVisible = false;
            this.dgvEpisodios.RowTemplate.Height = 48;
            this.dgvEpisodios.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvEpisodios.Size = new System.Drawing.Size(1018, 456);
            this.dgvEpisodios.TabIndex = 0;
            this.dgvEpisodios.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvEpisodios_CellFormatting);
            // 
            // colConsultaId
            // 
            this.colConsultaId.HeaderText = "N° Consulta";
            this.colConsultaId.Name = "colConsultaId";
            this.colConsultaId.Width = 110;
            // 
            // colHora
            // 
            this.colHora.HeaderText = "Ingreso";
            this.colHora.Name = "colHora";
            this.colHora.Width = 110;
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
            this.colMotivo.Width = 150;
            // 
            // colPrioridad
            // 
            this.colPrioridad.HeaderText = "Prioridad";
            this.colPrioridad.Name = "colPrioridad";
            this.colPrioridad.Width = 120;
            // 
            // colAcciones
            // 
            this.colAcciones.HeaderText = "Acciones";
            this.colAcciones.Name = "colAcciones";
            this.colAcciones.Width = 230;
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.White;
            this.pnlHeader.Controls.Add(this.lblTituloModulo);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Margin = new System.Windows.Forms.Padding(4);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Padding = new System.Windows.Forms.Padding(18, 0, 18, 0);
            this.pnlHeader.Size = new System.Drawing.Size(1099, 68);
            this.pnlHeader.TabIndex = 0;
            // 
            // lblTituloModulo
            // 
            this.lblTituloModulo.AutoSize = true;
            this.lblTituloModulo.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTituloModulo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.lblTituloModulo.Location = new System.Drawing.Point(21, 20);
            this.lblTituloModulo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTituloModulo.Name = "lblTituloModulo";
            this.lblTituloModulo.Size = new System.Drawing.Size(336, 20);
            this.lblTituloModulo.TabIndex = 0;
            this.lblTituloModulo.Text = "Hospital Sagrado Corazón | Módulo de  Guardia";
            // 
            // BandejaMedicaForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(218)))), ((int)(((byte)(229)))));
            this.ClientSize = new System.Drawing.Size(1099, 867);
            this.Controls.Add(this.pnlMainContainer);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "BandejaMedicaForm";
            this.Text = "PacientesEnfermeriaForm";
            this.pnlMainContainer.ResumeLayout(false);
            this.grpEpisodiosActivos.ResumeLayout(false);
            this.grpEpisodiosActivos.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEpisodios)).EndInit();
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlMainContainer;
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblTituloModulo;
        private DarkGroupBox grpEpisodiosActivos;
        private System.Windows.Forms.DataGridView dgvEpisodios;
        private System.Windows.Forms.ComboBox cmbFiltroEstado;
        private System.Windows.Forms.Label lblFiltrarPor;
        private System.Windows.Forms.Label lblContadorActivas;
        private System.Windows.Forms.Button btnRefrescar;
        private System.Windows.Forms.DataGridViewTextBoxColumn colConsultaId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHora;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPaciente;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMotivo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPrioridad;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAcciones;
    }
}