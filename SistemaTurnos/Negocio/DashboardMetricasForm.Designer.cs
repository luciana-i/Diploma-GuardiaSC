namespace SistemaTurnos.Negocio
{
    partial class DashboardMetricasForm
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
            this.pnlFiltros = new System.Windows.Forms.Panel();
            this.btnExportarSnapshot = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.dtpFechaHasta = new System.Windows.Forms.DateTimePicker();
            this.lblSeparador = new System.Windows.Forms.Label();
            this.dtpFechaDesde = new System.Windows.Forms.DateTimePicker();
            this.lblPeriodo = new System.Windows.Forms.Label();
            this.pnlKpiEspera = new System.Windows.Forms.Panel();
            this.lblKpiEsperaValor = new System.Windows.Forms.Label();
            this.lblKpiEsperaTitulo = new System.Windows.Forms.Label();
            this.pnlKpiLab = new System.Windows.Forms.Panel();
            this.lblKpiLabValor = new System.Windows.Forms.Label();
            this.lblKpiLabTitulo = new System.Windows.Forms.Label();
            this.pnlKpiInternacion = new System.Windows.Forms.Panel();
            this.lblKpiInternacionValor = new System.Windows.Forms.Label();
            this.lblKpiInternacionTitulo = new System.Windows.Forms.Label();
            this.pnlKpiTotal = new System.Windows.Forms.Panel();
            this.lblKpiTotalValor = new System.Windows.Forms.Label();
            this.lblKpiTotalTitulo = new System.Windows.Forms.Label();
            this.pnlContenedorGrafico = new System.Windows.Forms.Panel();
            this.lblGraficoTitulo = new System.Windows.Forms.Label();
            this.pnlContenedorDestinos = new System.Windows.Forms.Panel();
            this.pnlAlertaCuelloBotella = new System.Windows.Forms.Panel();
            this.lblAlertaDetalle = new System.Windows.Forms.Label();
            this.lblAlertaSector = new System.Windows.Forms.Label();
            this.lblAlertaTitulo = new System.Windows.Forms.Label();
            this.lblValorDerivaciones = new System.Windows.Forms.Label();
            this.pnlFondoBarraDerivaciones = new System.Windows.Forms.Panel();
            this.pnlBarraDerivaciones = new System.Windows.Forms.Panel();
            this.lblDerivacion = new System.Windows.Forms.Label();
            this.pnlFondoBarraInternaciones = new System.Windows.Forms.Panel();
            this.pnlBarraInternaciones = new System.Windows.Forms.Panel();
            this.lblValorInternaciones = new System.Windows.Forms.Label();
            this.lblInternacion = new System.Windows.Forms.Label();
            this.pnlFondoBarraAltas = new System.Windows.Forms.Panel();
            this.pnlBarraAltas = new System.Windows.Forms.Panel();
            this.lblValorAltas = new System.Windows.Forms.Label();
            this.lblAltas = new System.Windows.Forms.Label();
            this.lblDestinosTitulo = new System.Windows.Forms.Label();
            this.pnlRecomendaciones = new System.Windows.Forms.Panel();
            this.txtRecomendaciones = new System.Windows.Forms.TextBox();
            this.lblRecomendacionHeader = new System.Windows.Forms.Label();
            this.cartesianChartDemanda = new LiveCharts.WinForms.CartesianChart();
            this.pnlFiltros.SuspendLayout();
            this.pnlKpiEspera.SuspendLayout();
            this.pnlKpiLab.SuspendLayout();
            this.pnlKpiInternacion.SuspendLayout();
            this.pnlKpiTotal.SuspendLayout();
            this.pnlContenedorGrafico.SuspendLayout();
            this.pnlContenedorDestinos.SuspendLayout();
            this.pnlAlertaCuelloBotella.SuspendLayout();
            this.pnlFondoBarraDerivaciones.SuspendLayout();
            this.pnlFondoBarraInternaciones.SuspendLayout();
            this.pnlFondoBarraAltas.SuspendLayout();
            this.pnlRecomendaciones.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlFiltros
            // 
            this.pnlFiltros.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.pnlFiltros.Controls.Add(this.btnExportarSnapshot);
            this.pnlFiltros.Controls.Add(this.button1);
            this.pnlFiltros.Controls.Add(this.dtpFechaHasta);
            this.pnlFiltros.Controls.Add(this.lblSeparador);
            this.pnlFiltros.Controls.Add(this.dtpFechaDesde);
            this.pnlFiltros.Controls.Add(this.lblPeriodo);
            this.pnlFiltros.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlFiltros.Location = new System.Drawing.Point(0, 0);
            this.pnlFiltros.Name = "pnlFiltros";
            this.pnlFiltros.Padding = new System.Windows.Forms.Padding(10);
            this.pnlFiltros.Size = new System.Drawing.Size(1026, 65);
            this.pnlFiltros.TabIndex = 0;
            // 
            // btnExportarSnapshot
            // 
            this.btnExportarSnapshot.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExportarSnapshot.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(189)))), ((int)(((byte)(248)))));
            this.btnExportarSnapshot.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExportarSnapshot.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExportarSnapshot.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(189)))), ((int)(((byte)(248)))));
            this.btnExportarSnapshot.Location = new System.Drawing.Point(850, 26);
            this.btnExportarSnapshot.Name = "btnExportarSnapshot";
            this.btnExportarSnapshot.Size = new System.Drawing.Size(155, 30);
            this.btnExportarSnapshot.TabIndex = 5;
            this.btnExportarSnapshot.Text = "Exportar Snapshot";
            this.btnExportarSnapshot.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(78)))), ((int)(((byte)(74)))));
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(212)))), ((int)(((byte)(191)))));
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(320, 26);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 30);
            this.button1.TabIndex = 4;
            this.button1.Text = "Analizar";
            this.button1.UseVisualStyleBackColor = false;
            // 
            // dtpFechaHasta
            // 
            this.dtpFechaHasta.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFechaHasta.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaHasta.Location = new System.Drawing.Point(175, 28);
            this.dtpFechaHasta.Name = "dtpFechaHasta";
            this.dtpFechaHasta.Size = new System.Drawing.Size(130, 25);
            this.dtpFechaHasta.TabIndex = 3;
            // 
            // lblSeparador
            // 
            this.lblSeparador.AutoSize = true;
            this.lblSeparador.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(163)))), ((int)(((byte)(184)))));
            this.lblSeparador.Location = new System.Drawing.Point(156, 32);
            this.lblSeparador.Name = "lblSeparador";
            this.lblSeparador.Size = new System.Drawing.Size(15, 17);
            this.lblSeparador.TabIndex = 2;
            this.lblSeparador.Text = "a";
            // 
            // dtpFechaDesde
            // 
            this.dtpFechaDesde.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFechaDesde.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaDesde.Location = new System.Drawing.Point(20, 28);
            this.dtpFechaDesde.Name = "dtpFechaDesde";
            this.dtpFechaDesde.Size = new System.Drawing.Size(130, 25);
            this.dtpFechaDesde.TabIndex = 1;
            // 
            // lblPeriodo
            // 
            this.lblPeriodo.AutoSize = true;
            this.lblPeriodo.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPeriodo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(163)))), ((int)(((byte)(184)))));
            this.lblPeriodo.Location = new System.Drawing.Point(20, 12);
            this.lblPeriodo.Name = "lblPeriodo";
            this.lblPeriodo.Size = new System.Drawing.Size(125, 13);
            this.lblPeriodo.TabIndex = 0;
            this.lblPeriodo.Text = "PERÍODO ASISTENCIAL";
            // 
            // pnlKpiEspera
            // 
            this.pnlKpiEspera.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.pnlKpiEspera.Controls.Add(this.lblKpiEsperaValor);
            this.pnlKpiEspera.Controls.Add(this.lblKpiEsperaTitulo);
            this.pnlKpiEspera.Location = new System.Drawing.Point(20, 75);
            this.pnlKpiEspera.Name = "pnlKpiEspera";
            this.pnlKpiEspera.Size = new System.Drawing.Size(230, 75);
            this.pnlKpiEspera.TabIndex = 1;
            // 
            // lblKpiEsperaValor
            // 
            this.lblKpiEsperaValor.AutoSize = true;
            this.lblKpiEsperaValor.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblKpiEsperaValor.Location = new System.Drawing.Point(19, 36);
            this.lblKpiEsperaValor.Name = "lblKpiEsperaValor";
            this.lblKpiEsperaValor.Size = new System.Drawing.Size(72, 30);
            this.lblKpiEsperaValor.TabIndex = 4;
            this.lblKpiEsperaValor.Text = "label1";
            // 
            // lblKpiEsperaTitulo
            // 
            this.lblKpiEsperaTitulo.AutoSize = true;
            this.lblKpiEsperaTitulo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(163)))), ((int)(((byte)(184)))));
            this.lblKpiEsperaTitulo.Location = new System.Drawing.Point(19, 19);
            this.lblKpiEsperaTitulo.Name = "lblKpiEsperaTitulo";
            this.lblKpiEsperaTitulo.Size = new System.Drawing.Size(142, 17);
            this.lblKpiEsperaTitulo.TabIndex = 4;
            this.lblKpiEsperaTitulo.Text = "ESPERA CONSULTORIO";
            // 
            // pnlKpiLab
            // 
            this.pnlKpiLab.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.pnlKpiLab.Controls.Add(this.lblKpiLabValor);
            this.pnlKpiLab.Controls.Add(this.lblKpiLabTitulo);
            this.pnlKpiLab.Location = new System.Drawing.Point(265, 75);
            this.pnlKpiLab.Name = "pnlKpiLab";
            this.pnlKpiLab.Size = new System.Drawing.Size(230, 75);
            this.pnlKpiLab.TabIndex = 2;
            // 
            // lblKpiLabValor
            // 
            this.lblKpiLabValor.AutoSize = true;
            this.lblKpiLabValor.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblKpiLabValor.Location = new System.Drawing.Point(17, 36);
            this.lblKpiLabValor.Name = "lblKpiLabValor";
            this.lblKpiLabValor.Size = new System.Drawing.Size(72, 30);
            this.lblKpiLabValor.TabIndex = 1;
            this.lblKpiLabValor.Text = "label1";
            // 
            // lblKpiLabTitulo
            // 
            this.lblKpiLabTitulo.AutoSize = true;
            this.lblKpiLabTitulo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(163)))), ((int)(((byte)(184)))));
            this.lblKpiLabTitulo.Location = new System.Drawing.Point(19, 19);
            this.lblKpiLabTitulo.Name = "lblKpiLabTitulo";
            this.lblKpiLabTitulo.Size = new System.Drawing.Size(136, 17);
            this.lblKpiLabTitulo.TabIndex = 0;
            this.lblKpiLabTitulo.Text = "PICO LABORAT./HORA";
            // 
            // pnlKpiInternacion
            // 
            this.pnlKpiInternacion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.pnlKpiInternacion.Controls.Add(this.lblKpiInternacionValor);
            this.pnlKpiInternacion.Controls.Add(this.lblKpiInternacionTitulo);
            this.pnlKpiInternacion.Location = new System.Drawing.Point(510, 75);
            this.pnlKpiInternacion.Name = "pnlKpiInternacion";
            this.pnlKpiInternacion.Size = new System.Drawing.Size(230, 75);
            this.pnlKpiInternacion.TabIndex = 3;
            // 
            // lblKpiInternacionValor
            // 
            this.lblKpiInternacionValor.AutoSize = true;
            this.lblKpiInternacionValor.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblKpiInternacionValor.Location = new System.Drawing.Point(13, 36);
            this.lblKpiInternacionValor.Name = "lblKpiInternacionValor";
            this.lblKpiInternacionValor.Size = new System.Drawing.Size(72, 30);
            this.lblKpiInternacionValor.TabIndex = 1;
            this.lblKpiInternacionValor.Text = "label1";
            // 
            // lblKpiInternacionTitulo
            // 
            this.lblKpiInternacionTitulo.AutoSize = true;
            this.lblKpiInternacionTitulo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(163)))), ((int)(((byte)(184)))));
            this.lblKpiInternacionTitulo.Location = new System.Drawing.Point(15, 19);
            this.lblKpiInternacionTitulo.Name = "lblKpiInternacionTitulo";
            this.lblKpiInternacionTitulo.Size = new System.Drawing.Size(125, 17);
            this.lblKpiInternacionTitulo.TabIndex = 0;
            this.lblKpiInternacionTitulo.Text = "TASA INTERNACIÓN";
            // 
            // pnlKpiTotal
            // 
            this.pnlKpiTotal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.pnlKpiTotal.Controls.Add(this.lblKpiTotalValor);
            this.pnlKpiTotal.Controls.Add(this.lblKpiTotalTitulo);
            this.pnlKpiTotal.Location = new System.Drawing.Point(759, 75);
            this.pnlKpiTotal.Name = "pnlKpiTotal";
            this.pnlKpiTotal.Size = new System.Drawing.Size(250, 75);
            this.pnlKpiTotal.TabIndex = 3;
            // 
            // lblKpiTotalValor
            // 
            this.lblKpiTotalValor.AutoSize = true;
            this.lblKpiTotalValor.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblKpiTotalValor.Location = new System.Drawing.Point(19, 36);
            this.lblKpiTotalValor.Name = "lblKpiTotalValor";
            this.lblKpiTotalValor.Size = new System.Drawing.Size(72, 30);
            this.lblKpiTotalValor.TabIndex = 1;
            this.lblKpiTotalValor.Text = "label1";
            // 
            // lblKpiTotalTitulo
            // 
            this.lblKpiTotalTitulo.AutoSize = true;
            this.lblKpiTotalTitulo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(163)))), ((int)(((byte)(184)))));
            this.lblKpiTotalTitulo.Location = new System.Drawing.Point(21, 19);
            this.lblKpiTotalTitulo.Name = "lblKpiTotalTitulo";
            this.lblKpiTotalTitulo.Size = new System.Drawing.Size(117, 17);
            this.lblKpiTotalTitulo.TabIndex = 0;
            this.lblKpiTotalTitulo.Text = "TOTAL CONSULTAS";
            // 
            // pnlContenedorGrafico
            // 
            this.pnlContenedorGrafico.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.pnlContenedorGrafico.Controls.Add(this.cartesianChartDemanda);
            this.pnlContenedorGrafico.Controls.Add(this.lblGraficoTitulo);
            this.pnlContenedorGrafico.Location = new System.Drawing.Point(20, 160);
            this.pnlContenedorGrafico.Name = "pnlContenedorGrafico";
            this.pnlContenedorGrafico.Size = new System.Drawing.Size(690, 300);
            this.pnlContenedorGrafico.TabIndex = 4;
            // 
            // lblGraficoTitulo
            // 
            this.lblGraficoTitulo.AutoSize = true;
            this.lblGraficoTitulo.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGraficoTitulo.Location = new System.Drawing.Point(21, 23);
            this.lblGraficoTitulo.Name = "lblGraficoTitulo";
            this.lblGraficoTitulo.Size = new System.Drawing.Size(328, 17);
            this.lblGraficoTitulo.TabIndex = 0;
            this.lblGraficoTitulo.Text = "Curva de Demanda Horaria de Prácticas (00 a 23 hs)";
            // 
            // pnlContenedorDestinos
            // 
            this.pnlContenedorDestinos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.pnlContenedorDestinos.Controls.Add(this.pnlAlertaCuelloBotella);
            this.pnlContenedorDestinos.Controls.Add(this.lblValorDerivaciones);
            this.pnlContenedorDestinos.Controls.Add(this.pnlFondoBarraDerivaciones);
            this.pnlContenedorDestinos.Controls.Add(this.lblDerivacion);
            this.pnlContenedorDestinos.Controls.Add(this.pnlFondoBarraInternaciones);
            this.pnlContenedorDestinos.Controls.Add(this.lblValorInternaciones);
            this.pnlContenedorDestinos.Controls.Add(this.lblInternacion);
            this.pnlContenedorDestinos.Controls.Add(this.pnlFondoBarraAltas);
            this.pnlContenedorDestinos.Controls.Add(this.lblValorAltas);
            this.pnlContenedorDestinos.Controls.Add(this.lblAltas);
            this.pnlContenedorDestinos.Controls.Add(this.lblDestinosTitulo);
            this.pnlContenedorDestinos.Location = new System.Drawing.Point(725, 160);
            this.pnlContenedorDestinos.Name = "pnlContenedorDestinos";
            this.pnlContenedorDestinos.Size = new System.Drawing.Size(284, 300);
            this.pnlContenedorDestinos.TabIndex = 5;
            // 
            // pnlAlertaCuelloBotella
            // 
            this.pnlAlertaCuelloBotella.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.pnlAlertaCuelloBotella.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlAlertaCuelloBotella.Controls.Add(this.lblAlertaDetalle);
            this.pnlAlertaCuelloBotella.Controls.Add(this.lblAlertaSector);
            this.pnlAlertaCuelloBotella.Controls.Add(this.lblAlertaTitulo);
            this.pnlAlertaCuelloBotella.Location = new System.Drawing.Point(15, 205);
            this.pnlAlertaCuelloBotella.Name = "pnlAlertaCuelloBotella";
            this.pnlAlertaCuelloBotella.Size = new System.Drawing.Size(250, 75);
            this.pnlAlertaCuelloBotella.TabIndex = 6;
            // 
            // lblAlertaDetalle
            // 
            this.lblAlertaDetalle.AutoSize = true;
            this.lblAlertaDetalle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(163)))), ((int)(((byte)(184)))));
            this.lblAlertaDetalle.Location = new System.Drawing.Point(10, 50);
            this.lblAlertaDetalle.Name = "lblAlertaDetalle";
            this.lblAlertaDetalle.Size = new System.Drawing.Size(43, 17);
            this.lblAlertaDetalle.TabIndex = 2;
            this.lblAlertaDetalle.Text = "label1";
            // 
            // lblAlertaSector
            // 
            this.lblAlertaSector.AutoSize = true;
            this.lblAlertaSector.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAlertaSector.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(232)))), ((int)(((byte)(240)))));
            this.lblAlertaSector.Location = new System.Drawing.Point(10, 30);
            this.lblAlertaSector.Name = "lblAlertaSector";
            this.lblAlertaSector.Size = new System.Drawing.Size(45, 17);
            this.lblAlertaSector.TabIndex = 1;
            this.lblAlertaSector.Text = "label1";
            // 
            // lblAlertaTitulo
            // 
            this.lblAlertaTitulo.AutoSize = true;
            this.lblAlertaTitulo.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAlertaTitulo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(113)))), ((int)(((byte)(113)))));
            this.lblAlertaTitulo.Location = new System.Drawing.Point(10, 8);
            this.lblAlertaTitulo.Name = "lblAlertaTitulo";
            this.lblAlertaTitulo.Size = new System.Drawing.Size(180, 17);
            this.lblAlertaTitulo.TabIndex = 0;
            this.lblAlertaTitulo.Text = "Cuello de Botella Detectado";
            // 
            // lblValorDerivaciones
            // 
            this.lblValorDerivaciones.AutoSize = true;
            this.lblValorDerivaciones.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblValorDerivaciones.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(191)))), ((int)(((byte)(36)))));
            this.lblValorDerivaciones.Location = new System.Drawing.Point(220, 144);
            this.lblValorDerivaciones.Name = "lblValorDerivaciones";
            this.lblValorDerivaciones.Size = new System.Drawing.Size(45, 17);
            this.lblValorDerivaciones.TabIndex = 9;
            this.lblValorDerivaciones.Text = "label1";
            // 
            // pnlFondoBarraDerivaciones
            // 
            this.pnlFondoBarraDerivaciones.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.pnlFondoBarraDerivaciones.Controls.Add(this.pnlBarraDerivaciones);
            this.pnlFondoBarraDerivaciones.Location = new System.Drawing.Point(15, 164);
            this.pnlFondoBarraDerivaciones.Name = "pnlFondoBarraDerivaciones";
            this.pnlFondoBarraDerivaciones.Size = new System.Drawing.Size(250, 12);
            this.pnlFondoBarraDerivaciones.TabIndex = 8;
            // 
            // pnlBarraDerivaciones
            // 
            this.pnlBarraDerivaciones.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(158)))), ((int)(((byte)(11)))));
            this.pnlBarraDerivaciones.Location = new System.Drawing.Point(0, 0);
            this.pnlBarraDerivaciones.Name = "pnlBarraDerivaciones";
            this.pnlBarraDerivaciones.Size = new System.Drawing.Size(0, 12);
            this.pnlBarraDerivaciones.TabIndex = 10;
            // 
            // lblDerivacion
            // 
            this.lblDerivacion.AutoSize = true;
            this.lblDerivacion.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDerivacion.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(213)))), ((int)(((byte)(225)))));
            this.lblDerivacion.Location = new System.Drawing.Point(15, 144);
            this.lblDerivacion.Name = "lblDerivacion";
            this.lblDerivacion.Size = new System.Drawing.Size(124, 17);
            this.lblDerivacion.TabIndex = 7;
            this.lblDerivacion.Text = "Derivación Externa";
            // 
            // pnlFondoBarraInternaciones
            // 
            this.pnlFondoBarraInternaciones.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.pnlFondoBarraInternaciones.Controls.Add(this.pnlBarraInternaciones);
            this.pnlFondoBarraInternaciones.Location = new System.Drawing.Point(15, 116);
            this.pnlFondoBarraInternaciones.Name = "pnlFondoBarraInternaciones";
            this.pnlFondoBarraInternaciones.Size = new System.Drawing.Size(250, 12);
            this.pnlFondoBarraInternaciones.TabIndex = 6;
            // 
            // pnlBarraInternaciones
            // 
            this.pnlBarraInternaciones.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));
            this.pnlBarraInternaciones.Location = new System.Drawing.Point(0, 0);
            this.pnlBarraInternaciones.Name = "pnlBarraInternaciones";
            this.pnlBarraInternaciones.Size = new System.Drawing.Size(0, 12);
            this.pnlBarraInternaciones.TabIndex = 7;
            // 
            // lblValorInternaciones
            // 
            this.lblValorInternaciones.AutoSize = true;
            this.lblValorInternaciones.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblValorInternaciones.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(113)))), ((int)(((byte)(113)))));
            this.lblValorInternaciones.Location = new System.Drawing.Point(220, 96);
            this.lblValorInternaciones.Name = "lblValorInternaciones";
            this.lblValorInternaciones.Size = new System.Drawing.Size(45, 17);
            this.lblValorInternaciones.TabIndex = 5;
            this.lblValorInternaciones.Text = "label1";
            // 
            // lblInternacion
            // 
            this.lblInternacion.AutoSize = true;
            this.lblInternacion.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInternacion.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(213)))), ((int)(((byte)(225)))));
            this.lblInternacion.Location = new System.Drawing.Point(15, 96);
            this.lblInternacion.Name = "lblInternacion";
            this.lblInternacion.Size = new System.Drawing.Size(78, 17);
            this.lblInternacion.TabIndex = 4;
            this.lblInternacion.Text = "Internación";
            // 
            // pnlFondoBarraAltas
            // 
            this.pnlFondoBarraAltas.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.pnlFondoBarraAltas.Controls.Add(this.pnlBarraAltas);
            this.pnlFondoBarraAltas.Location = new System.Drawing.Point(15, 68);
            this.pnlFondoBarraAltas.Name = "pnlFondoBarraAltas";
            this.pnlFondoBarraAltas.Size = new System.Drawing.Size(250, 12);
            this.pnlFondoBarraAltas.TabIndex = 3;
            // 
            // pnlBarraAltas
            // 
            this.pnlBarraAltas.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(185)))), ((int)(((byte)(129)))));
            this.pnlBarraAltas.Location = new System.Drawing.Point(0, 0);
            this.pnlBarraAltas.Name = "pnlBarraAltas";
            this.pnlBarraAltas.Size = new System.Drawing.Size(0, 12);
            this.pnlBarraAltas.TabIndex = 0;
            // 
            // lblValorAltas
            // 
            this.lblValorAltas.AutoSize = true;
            this.lblValorAltas.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblValorAltas.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(211)))), ((int)(((byte)(153)))));
            this.lblValorAltas.Location = new System.Drawing.Point(220, 48);
            this.lblValorAltas.Name = "lblValorAltas";
            this.lblValorAltas.Size = new System.Drawing.Size(45, 17);
            this.lblValorAltas.TabIndex = 2;
            this.lblValorAltas.Text = "label1";
            // 
            // lblAltas
            // 
            this.lblAltas.AutoSize = true;
            this.lblAltas.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAltas.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(213)))), ((int)(((byte)(225)))));
            this.lblAltas.Location = new System.Drawing.Point(15, 48);
            this.lblAltas.Name = "lblAltas";
            this.lblAltas.Size = new System.Drawing.Size(81, 17);
            this.lblAltas.TabIndex = 1;
            this.lblAltas.Text = "Alta Médica";
            // 
            // lblDestinosTitulo
            // 
            this.lblDestinosTitulo.AutoSize = true;
            this.lblDestinosTitulo.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDestinosTitulo.Location = new System.Drawing.Point(15, 15);
            this.lblDestinosTitulo.Name = "lblDestinosTitulo";
            this.lblDestinosTitulo.Size = new System.Drawing.Size(191, 17);
            this.lblDestinosTitulo.TabIndex = 0;
            this.lblDestinosTitulo.Text = "Resolución y Destinos Finales";
            // 
            // pnlRecomendaciones
            // 
            this.pnlRecomendaciones.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(43)))), ((int)(((byte)(42)))));
            this.pnlRecomendaciones.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlRecomendaciones.Controls.Add(this.txtRecomendaciones);
            this.pnlRecomendaciones.Controls.Add(this.lblRecomendacionHeader);
            this.pnlRecomendaciones.Location = new System.Drawing.Point(20, 475);
            this.pnlRecomendaciones.Name = "pnlRecomendaciones";
            this.pnlRecomendaciones.Size = new System.Drawing.Size(985, 110);
            this.pnlRecomendaciones.TabIndex = 6;
            // 
            // txtRecomendaciones
            // 
            this.txtRecomendaciones.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(43)))), ((int)(((byte)(42)))));
            this.txtRecomendaciones.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtRecomendaciones.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(232)))), ((int)(((byte)(240)))));
            this.txtRecomendaciones.Location = new System.Drawing.Point(15, 35);
            this.txtRecomendaciones.Multiline = true;
            this.txtRecomendaciones.Name = "txtRecomendaciones";
            this.txtRecomendaciones.ReadOnly = true;
            this.txtRecomendaciones.Size = new System.Drawing.Size(955, 65);
            this.txtRecomendaciones.TabIndex = 1;
            // 
            // lblRecomendacionHeader
            // 
            this.lblRecomendacionHeader.AutoSize = true;
            this.lblRecomendacionHeader.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRecomendacionHeader.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(212)))), ((int)(((byte)(191)))));
            this.lblRecomendacionHeader.Location = new System.Drawing.Point(15, 10);
            this.lblRecomendacionHeader.Name = "lblRecomendacionHeader";
            this.lblRecomendacionHeader.Size = new System.Drawing.Size(411, 17);
            this.lblRecomendacionHeader.TabIndex = 0;
            this.lblRecomendacionHeader.Text = "RECOMENDACIÓN GERENCIAL PARA CRONOGRAMA Y DOTACIÓN";
            // 
            // cartesianChartDemanda
            // 
            this.cartesianChartDemanda.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cartesianChartDemanda.Location = new System.Drawing.Point(10, 40);
            this.cartesianChartDemanda.Name = "cartesianChartDemanda";
            this.cartesianChartDemanda.Size = new System.Drawing.Size(670, 250);
            this.cartesianChartDemanda.TabIndex = 1;
            this.cartesianChartDemanda.Text = "cartesianChart1";
            // 
            // DashboardMetricasForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.ClientSize = new System.Drawing.Size(1026, 603);
            this.Controls.Add(this.pnlRecomendaciones);
            this.Controls.Add(this.pnlContenedorDestinos);
            this.Controls.Add(this.pnlContenedorGrafico);
            this.Controls.Add(this.pnlKpiInternacion);
            this.Controls.Add(this.pnlKpiTotal);
            this.Controls.Add(this.pnlKpiLab);
            this.Controls.Add(this.pnlKpiEspera);
            this.Controls.Add(this.pnlFiltros);
            this.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.ForeColor = System.Drawing.Color.White;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "DashboardMetricasForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Gestión de Métricas y Optimización - Guardia Médica";
            this.pnlFiltros.ResumeLayout(false);
            this.pnlFiltros.PerformLayout();
            this.pnlKpiEspera.ResumeLayout(false);
            this.pnlKpiEspera.PerformLayout();
            this.pnlKpiLab.ResumeLayout(false);
            this.pnlKpiLab.PerformLayout();
            this.pnlKpiInternacion.ResumeLayout(false);
            this.pnlKpiInternacion.PerformLayout();
            this.pnlKpiTotal.ResumeLayout(false);
            this.pnlKpiTotal.PerformLayout();
            this.pnlContenedorGrafico.ResumeLayout(false);
            this.pnlContenedorGrafico.PerformLayout();
            this.pnlContenedorDestinos.ResumeLayout(false);
            this.pnlContenedorDestinos.PerformLayout();
            this.pnlAlertaCuelloBotella.ResumeLayout(false);
            this.pnlAlertaCuelloBotella.PerformLayout();
            this.pnlFondoBarraDerivaciones.ResumeLayout(false);
            this.pnlFondoBarraInternaciones.ResumeLayout(false);
            this.pnlFondoBarraAltas.ResumeLayout(false);
            this.pnlRecomendaciones.ResumeLayout(false);
            this.pnlRecomendaciones.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlFiltros;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DateTimePicker dtpFechaHasta;
        private System.Windows.Forms.Label lblSeparador;
        private System.Windows.Forms.DateTimePicker dtpFechaDesde;
        private System.Windows.Forms.Label lblPeriodo;
        private System.Windows.Forms.Button btnExportarSnapshot;
        private System.Windows.Forms.Panel pnlKpiEspera;
        private System.Windows.Forms.Panel pnlKpiLab;
        private System.Windows.Forms.Panel pnlKpiInternacion;
        private System.Windows.Forms.Panel pnlKpiTotal;
        private System.Windows.Forms.Label lblKpiEsperaValor;
        private System.Windows.Forms.Label lblKpiEsperaTitulo;
        private System.Windows.Forms.Label lblKpiLabTitulo;
        private System.Windows.Forms.Label lblKpiLabValor;
        private System.Windows.Forms.Label lblKpiInternacionTitulo;
        private System.Windows.Forms.Label lblKpiInternacionValor;
        private System.Windows.Forms.Label lblKpiTotalValor;
        private System.Windows.Forms.Label lblKpiTotalTitulo;
        private System.Windows.Forms.Panel pnlContenedorGrafico;
        private System.Windows.Forms.Label lblGraficoTitulo;
        private System.Windows.Forms.Panel pnlContenedorDestinos;
        private System.Windows.Forms.Label lblDestinosTitulo;
        private System.Windows.Forms.Label lblAltas;
        private System.Windows.Forms.Panel pnlFondoBarraAltas;
        private System.Windows.Forms.Panel pnlBarraAltas;
        private System.Windows.Forms.Label lblValorAltas;
        private System.Windows.Forms.Panel pnlFondoBarraInternaciones;
        private System.Windows.Forms.Panel pnlBarraInternaciones;
        private System.Windows.Forms.Label lblValorInternaciones;
        private System.Windows.Forms.Label lblInternacion;
        private System.Windows.Forms.Label lblValorDerivaciones;
        private System.Windows.Forms.Panel pnlFondoBarraDerivaciones;
        private System.Windows.Forms.Label lblDerivacion;
        private System.Windows.Forms.Panel pnlAlertaCuelloBotella;
        private System.Windows.Forms.Label lblAlertaSector;
        private System.Windows.Forms.Label lblAlertaTitulo;
        private System.Windows.Forms.Panel pnlBarraDerivaciones;
        private System.Windows.Forms.Label lblAlertaDetalle;
        private System.Windows.Forms.Panel pnlRecomendaciones;
        private System.Windows.Forms.TextBox txtRecomendaciones;
        private System.Windows.Forms.Label lblRecomendacionHeader;
        private LiveCharts.WinForms.CartesianChart cartesianChartDemanda;
    }
}