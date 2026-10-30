using BE;
using BLL.Servicios;
using LiveCharts;
using LiveCharts.Wpf;
using Seguridad;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Media;

namespace SistemaTurnos.Negocio
{
    public partial class DashboardMetricasForm : Form, IIdiomaObserver
    {
        private readonly MetricasService _metricasService = new MetricasService();
        private SnapshotMetricas _snapshotActual;

        public DashboardMetricasForm()
        {
            InitializeComponent();
            ConfigurarControlesIniciales();
            InicializarGraficoLiveCharts();
            InicializarDotacionActiva();

            IdiomaService.Suscribir(this);
            if (IdiomaService.TraduccionesActuales != null)
            {
                this.UpdateIdioma(IdiomaService.TraduccionesActuales);
            }
        }

        private void InicializarDotacionActiva()
        {
            nudMedicosSimulados.Value = 2;
            nudEnfermerosSimulados.Value = 1;
        }

        private void ConfigurarControlesIniciales()
        {
            // Rango de fechas por defecto (mes en curso)
            DateTime hoy = DateTime.Today;
            dtpFechaDesde.Value = new DateTime(hoy.Year, hoy.Month, 1);
            dtpFechaHasta.Value = hoy;

            // 1. Desplegable de Turnos Operativos
            cmbTurno.DataSource = new[]
            {
                new { Id = (int?)null, Nombre = "----" },
                new { Id = (int?)1,    Nombre = "Mañana" },
                new { Id = (int?)2,    Nombre = "Tarde" },
                new { Id = (int?)3,    Nombre = "Noche" }
            };
            cmbTurno.DisplayMember = "Nombre";
            cmbTurno.ValueMember = "Id";

            // 2. Desplegable de Prioridad (Enfermería)
            cmbPrioridad.DataSource = new[]
            {
                new { Id = (int?)null, Nombre = "----" },
                new { Id = (int?)1,    Nombre = "1 - Emergencia " },
                new { Id = (int?)2,    Nombre = "2 - Muy Urgente" },
                new { Id = (int?)3,    Nombre = "3 - Urgente" },
                new { Id = (int?)4,    Nombre = "4 - Poco Urgente" },
                new { Id = (int?)5,    Nombre = "5 - No Urgente" }
            };
            cmbPrioridad.DisplayMember = "Nombre";
            cmbPrioridad.ValueMember = "Id";

            // 3. Suscripción a eventos del Simulador What-If (Actualización interactiva)
            nudMedicosSimulados.ValueChanged += RecalcularSimulacionInteractiva;
            nudEnfermerosSimulados.ValueChanged += RecalcularSimulacionInteractiva;
        }

        private void InicializarGraficoLiveCharts()
        {
            cartesianChartDemanda.AxisX.Clear();
            cartesianChartDemanda.AxisY.Clear();

            // Eje X: 24 franjas horarias (00 a 23 hs)
            string[] horasLabels = new string[24];
            for (int i = 0; i < 24; i++)
            {
                horasLabels[i] = $"{i:D2}h";
            }

            cartesianChartDemanda.AxisX.Add(new Axis
            {
                Title = "Franja Horaria",
                Labels = horasLabels,
                Separator = new Separator { Step = 2, IsEnabled = false },
                Foreground = System.Windows.Media.Brushes.SlateGray
            });

            // Eje Y: Volumen de prácticas
            cartesianChartDemanda.AxisY.Add(new Axis
            {
                Title = "Cantidad de Estudios",
                MinValue = 0,
                Foreground = System.Windows.Media.Brushes.SlateGray,
                Separator = new Separator
                {
                    Stroke = new SolidColorBrush(System.Windows.Media.Color.FromRgb(51, 65, 85)), // #334155
                    StrokeDashArray = new DoubleCollection { 2 }
                }
            });

            cartesianChartDemanda.LegendLocation = LegendLocation.Top;

            if (cartesianChartDemanda.Base is LiveCharts.Wpf.CartesianChart wpfChart)
            {
                wpfChart.ChartLegend = new LiveCharts.Wpf.DefaultLegend
                {
                    Foreground = System.Windows.Media.Brushes.White,
                    FontSize = 11
                };
            }
        }

        // Evento Click del botón Analizar 
        private void button1_Click(object sender, EventArgs e)
        {
            nudMedicosSimulados.Value = 2;
            nudEnfermerosSimulados.Value = 1;
            try
            {
                Cursor = Cursors.WaitCursor;

                DateTime desde = dtpFechaDesde.Value.Date;
                DateTime hasta = dtpFechaHasta.Value.Date;

                if (desde > hasta)
                {
                    MessageBox.Show("La fecha desde no puede ser mayor a la fecha hasta.",
                                    "Filtro Inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Captura de filtros multidimensionales y parámetros de simulación
                int? turno = cmbTurno.SelectedValue as int?;
                int? prioridad = cmbPrioridad.SelectedValue as int?;
                int medicos = (int)nudMedicosSimulados.Value;
                int enfermeros = (int)nudEnfermerosSimulados.Value;
                
                _snapshotActual = _metricasService.AnalizarPeriodo(desde, hasta, turno, prioridad, medicos, enfermeros);

                
                MostrarDatosEnPantalla(_snapshotActual);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al procesar las métricas de la guardia: {ex.Message}",
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        private void MostrarDatosEnPantalla(SnapshotMetricas s)
        {
            if (s == null) return;

            // 1. Tarjetas KPI superiores (5 tarjetas independientes)
            lblKpiEsperaValor.Text = $"{s.EsperaPromedioConsultorioMinutos} min";
            lblKpiLabValor.Text = s.PicoLaboratorioCantidad > 0
                ? $"{s.PicoLaboratorioCantidad} est/h ({s.PicoLaboratorioHora:D2}hs)"
                : "0 est/h";
            lblValorRayosHora.Text = s.PicoRayosCantidad > 0
                ? $"{s.PicoRayosCantidad} est/h ({s.PicoRayosHora:D2}hs)"
                : "0 est/h";
            lblKpiInternacionValor.Text = $"{s.TasaInternacionPorcentaje} %";
            lblKpiTotalValor.Text = $"{s.TotalConsultasAuditadas} pac.";

            // 2. Destinos Finales (Valores numéricos independientes para multi-idioma)
            lblValorAltas.Text = $"{s.CantidadAltas} ({s.PorcentajeAltas}%)";
            lblValorInternaciones.Text = $"{s.CantidadInternaciones} ({s.PorcentajeInternaciones}%)";
            lblValorDerivaciones.Text = $"{s.CantidadDerivaciones} ({s.PorcentajeDerivaciones}%)";

            // Barras horizontales proporcionales
            int anchoBase = pnlFondoBarraAltas.Width;
            pnlBarraAltas.Width = (int)((s.PorcentajeAltas / 100.0) * anchoBase);
            pnlBarraInternaciones.Width = (int)((s.PorcentajeInternaciones / 100.0) * anchoBase);
            pnlBarraDerivaciones.Width = (int)((s.PorcentajeDerivaciones / 100.0) * anchoBase);

            // 3. Cuello de botella
            lblAlertaSector.Text = s.CuelloBotellaSector;
            lblAlertaDetalle.Text = s.CuelloBotellaDetalle;

            // 4. Análisis de Capacidad y Arribos (Teoría de Colas - Camino 1)
            lblValorLambda.Text = $"{s.TasaArriboLambda} pac/h";
            lblValorLittle.Text = $"{s.PacientesEnEsperaLittle} pac.";
            lblValorPoisson.Text = $"{s.ProbabilidadColapsoP} %";

            // 5. Simulación de Escenarios (Camino 3)
            lblValorDemoraSimulada.Text = $"{s.DemoraSimuladaMinutos} min";

            // 6. Panel inferior: Recomendación Gerencial
            txtRecomendaciones.Text = s.RecomendacionDotacion;

            // 7. Renderizar curvas en LiveCharts
            CargarGraficoDemanda(s);
        }

        private void RecalcularSimulacionInteractiva(object sender, EventArgs e)
        {
            if (_snapshotActual == null) return;

            int medicos = (int)nudMedicosSimulados.Value;
            int enfermeros = (int)nudEnfermerosSimulados.Value;

            // 1. Recalcula demoras, Little y Poisson en memoria
            _metricasService.SimularEscenario(_snapshotActual, medicos, enfermeros);

            // 2. Refresca los indicadores de Teoría de Colas
            lblValorLittle.Text = $"{_snapshotActual.PacientesEnEsperaLittle} pac.";
            lblValorPoisson.Text = $"{_snapshotActual.ProbabilidadColapsoP} %";

            // 3. Semáforo visual en el resultado de simulación
            if (_snapshotActual.DemoraSimuladaMinutos <= 20.0)
            {
                lblValorDemoraSimulada.ForeColor = System.Drawing.Color.FromArgb(52, 211, 153); // Verde esmeralda (#34D399)
                lblValorDemoraSimulada.Text = $"{_snapshotActual.DemoraSimuladaMinutos} min (Mitigado ✓)";
            }
            else
            {
                lblValorDemoraSimulada.ForeColor = System.Drawing.Color.FromArgb(248, 113, 113); // Rojo suave (#F87171)
                lblValorDemoraSimulada.Text = $"{_snapshotActual.DemoraSimuladaMinutos} min (Crítico ⚠)";
            }

            // 4. Actualiza la recomendación textual integrando el impacto de la simulación
            string textoSimulacion = _snapshotActual.DemoraSimuladaMinutos <= 20.0
                ? $"• Simulación Activa: Con {medicos} médico(s) y {enfermeros} enfermero(s), la espera proyectada baja a {_snapshotActual.DemoraSimuladaMinutos} min. Capacidad suficiente para normalizar la guardia."
                : $"• Simulación Activa: Con {medicos} médico(s) y {enfermeros} enfermero(s), la demora sigue superando la norma (20 min). Se sugiere dotación mayor.";

            txtRecomendaciones.Text = _snapshotActual.RecomendacionDotacion + Environment.NewLine + textoSimulacion;
        }

        private void CargarGraficoDemanda(SnapshotMetricas s)
        {
            var valoresLab = new ChartValues<int>();
            var valoresRayos = new ChartValues<int>();
            var valoresProyectados = new ChartValues<double>();

            foreach (var punto in s.CurvaHoraria)
            {
                valoresLab.Add(punto.CantidadLabReal);
                valoresRayos.Add(punto.CantidadRayosReal);
                valoresProyectados.Add(punto.CantidadProyectada);
            }

            cartesianChartDemanda.Series = new SeriesCollection
            {
                // Curva de Laboratorio (Celeste)
                new LineSeries
                {
                    Title = "Laboratorio",
                    Values = valoresLab,
                    Stroke = new SolidColorBrush(System.Windows.Media.Color.FromRgb(56, 189, 248)), // #38BDF8
                    Fill = System.Windows.Media.Brushes.Transparent,
                    PointGeometrySize = 6,
                    LineSmoothness = 0.5
                },
                // Curva de Radiología (Ámbar)
                new LineSeries
                {
                    Title = "Radiología",
                    Values = valoresRayos,
                    Stroke = new SolidColorBrush(System.Windows.Media.Color.FromRgb(245, 158, 11)), // #F59E0B
                    Fill = System.Windows.Media.Brushes.Transparent,
                    PointGeometrySize = 6,
                    LineSmoothness = 0.5
                },
                // Curva Proyectada (Violeta punteada)
                new LineSeries
                {
                    Title = "Proyección",
                    Values = valoresProyectados,
                    Stroke = new SolidColorBrush(System.Windows.Media.Color.FromRgb(168, 85, 247)), // #A855F7
                    StrokeDashArray = new DoubleCollection { 4, 3 },
                    Fill = System.Windows.Media.Brushes.Transparent,
                    PointGeometrySize = 4,
                    LineSmoothness = 0.5
                }
            };
        }

        private void btnExportarSnapshot_Click(object sender, EventArgs e)
        {
            if (_snapshotActual == null || _snapshotActual.TotalConsultasAuditadas == 0)
            {
                MessageBox.Show("Debe ejecutar un análisis antes de exportar el informe formal.",
                                "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            try
            {
                Cursor = Cursors.WaitCursor;

                // 1. Invoca a la BLL usando tu PdfDocumento existente
                string rutaPdf = _metricasService.ExportarSnapshotPdf(_snapshotActual);

                // 2. Abre el PDF en Windows
                System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo(rutaPdf) { UseShellExecute = true });
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocurrió un error al generar el PDF: {ex.Message}",
                                "Error de Exportación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        #region Implementación del Patrón Observer (IIdiomaObserver)

        public void UpdateIdioma(Dictionary<string, string> traducciones)
        {
            if (this.Tag != null && traducciones.ContainsKey(this.Tag.ToString()))
            {
                this.Text = traducciones[this.Tag.ToString()];
            }

            TraducirControlesRecursivo(this, traducciones);
        }

        private void TraducirControlesRecursivo(Control contenedor, Dictionary<string, string> traducciones)
        {
            foreach (Control c in contenedor.Controls)
            {
                if (c.Tag != null && traducciones.ContainsKey(c.Tag.ToString()))
                {
                    c.Text = traducciones[c.Tag.ToString()];
                }

                if (c.HasChildren)
                {
                    TraducirControlesRecursivo(c, traducciones);
                }
            }
        }


        #endregion

    }
}