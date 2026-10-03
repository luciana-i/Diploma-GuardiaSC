using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Windows.Forms;
using BE;
using BLL;

namespace SistemaTurnos.Negocio
{
    public partial class BandejaMedicaForm : Form
    {
        private List<Consulta> _consultasActivas = new List<Consulta>();
        private List<Consulta> _consultasVisibles = new List<Consulta>();
        private ConsultaBL consultaBL = new ConsultaBL();

        public BandejaMedicaForm()
        {
            InitializeComponent();

            //  Suscripción a eventos de grilla
            dgvEpisodios.CellPainting += Dgv_CellPainting_Acciones;
            dgvEpisodios.CellClick += DgvEpisodios_CellClick;

            ConfigurarFiltroEstados();
        }

        // ==========================================
        // CONFIGURACIÓN DE FILTROS Y CARGA ORDENADA
        // ==========================================
        private void ConfigurarFiltroEstados()
        {
            var opciones = new[]
            {
                new { Id = (int?)EstadoConsulta.EnEsperaAtencionMedica, Nombre = "Para Atención Médica (En Espera)" },
                new { Id = (int?)EstadoConsulta.EnAtencionMedica,      Nombre = "En Guardia Médica (En Atención)" },
                new { Id = (int?)null,                                Nombre = "-- Todas las Activas --" }
            };

            cmbFiltroEstado.DisplayMember = "Nombre";
            cmbFiltroEstado.ValueMember = "Id";
            cmbFiltroEstado.DataSource = opciones;

            // Por defecto: Para Atención Médica
            cmbFiltroEstado.SelectedValue = (int)EstadoConsulta.EnEsperaAtencionMedica;

            cmbFiltroEstado.SelectedIndexChanged += (s, e) => AplicarFiltroEnMemoria();
            btnRefrescar.Click += (s, e) => CargarConsultas();

            CargarConsultas();
        }

        public void CargarConsultas()
        {
            try
            {
                _consultasActivas = consultaBL.ObtenerConsultasParaMedcicosConPrioridad();
                _consultasVisibles = _consultasActivas; 

                MostrarEnGrilla(_consultasVisibles);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al consultar la cola médica: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AplicarFiltroEnMemoria()
        {
            int? estadoSeleccionado = cmbFiltroEstado.SelectedValue as int?;

            // 1. Filtramos las activas según el combo
            var filtradas = consultaBL.ObtenerConsultasConPrioridad()
                .Where(x => !estadoSeleccionado.HasValue || (int)x.EstadoConsulta == estadoSeleccionado.Value)
                .ToList();

            //    Primero por el nivel de prioridad (si es null, toma 99 para mandarlo al final) y luego por fecha.
            _consultasVisibles = filtradas
                .OrderBy(c => c.EvaluacionEnfermeria?.PrioridadFinal != null ? (int)c.EvaluacionEnfermeria.PrioridadFinal : 99)
                .ThenBy(c => c.FechaIngreso)
                .ToList();

            MostrarEnGrilla(_consultasVisibles);
        }

        // ==========================================
        // RENDERIZADO DEL DATAGRIDVIEW
        // ==========================================
        private void MostrarEnGrilla(List<Consulta> lista)
        {
            dgvEpisodios.Rows.Clear();

            foreach (var c in lista)
            {
                string idFormateado = $"#{c.Id}";
                string horaIngreso = c.FechaIngreso.ToString("HH:mm") + " hs";
                string pacienteCompleto = $"{c.Paciente.Apellido}, {c.Paciente.Nombre}";

                string triageTexto = c.EvaluacionEnfermeria != null
                    ? $"Nivel {(int)c.EvaluacionEnfermeria.PrioridadFinal} - {c.EvaluacionEnfermeria.PrioridadFinal}"
                    : "Sin Evaluacion";

                string estadoTexto;
                switch (c.EstadoConsulta)
                {
                    case EstadoConsulta.EnEsperaAtencionMedica:
                        estadoTexto = "Para Atención";
                        break;
                    case EstadoConsulta.EnAtencionMedica:
                        estadoTexto = "En Atención";
                        break;
                    default:
                        estadoTexto = c.EstadoConsulta.ToString();
                        break;
                }

                // Mapeo exacto a tus 6 columnas de la grilla del médico
                dgvEpisodios.Rows.Add(
                    idFormateado,          // colConsultaId
                    horaIngreso,           // colHora
                    pacienteCompleto,      // colPaciente
                    c.MotivoIngreso,       // colMotivo
                    triageTexto,           // colPrioridad
                    ""                     // colAcciones (Botón "Llamar y Atender")
                );
            }

            if (lblContadorActivas != null)
                lblContadorActivas.Text = $"● Cola Médica Activa: {lista.Count}";

            dgvEpisodios.ClearSelection();
        }

        // ==========================================
        // DIBUJO DEL BOTÓN EXCLUSIVO DEL MÉDICO ("🩺 Llamar y Atender")
        // ==========================================
        private void Dgv_CellPainting_Acciones(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;
            if (dgvEpisodios.Columns[e.ColumnIndex].Name != "colAcciones" && e.ColumnIndex != dgvEpisodios.Columns.Count - 1) return;

            e.PaintBackground(e.ClipBounds, true);

            int btnHeight = 28;
            int btnY = e.CellBounds.Y + (e.CellBounds.Height - btnHeight) / 2;
            Rectangle rectAtender = new Rectangle(e.CellBounds.X + 10, btnY, e.CellBounds.Width - 20, btnHeight);

            DibujarBotonGrilla(e.Graphics, rectAtender, "#1D4ED8", "#60A5FA", "🩺 Llamar y Atender");

            e.Handled = true;
        }

        private void DibujarBotonGrilla(Graphics g, Rectangle rect, string hexBg, string hexBorder, string texto)
        {
            g.SmoothingMode = SmoothingMode.AntiAlias;
            using (var path = CrearRutaRedondeada(rect, 5))
            {
                using (var b = new SolidBrush(ColorTranslator.FromHtml(hexBg))) g.FillPath(b, path);
                using (var p = new Pen(ColorTranslator.FromHtml(hexBorder), 1f)) g.DrawPath(p, path);
            }
            TextRenderer.DrawText(g, texto, new Font("Segoe UI", 9F, FontStyle.Bold), rect, Color.White,
                TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);
        }

        // ==========================================
        // ACCIÓN: LLAMAR AL PACIENTE A CONSULTORIO
        // ==========================================
        private void DgvEpisodios_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.RowIndex >= _consultasVisibles.Count) return;
            if (dgvEpisodios.Columns[e.ColumnIndex].Name != "colAcciones" && e.ColumnIndex != dgvEpisodios.Columns.Count - 1) return;

            var consultaSeleccionada = _consultasVisibles[e.RowIndex];
            string paciente = $"{consultaSeleccionada.Paciente.Apellido}, {consultaSeleccionada.Paciente.Nombre}";
            string dni = consultaSeleccionada.Paciente.Dni;

            var respuesta = MessageBox.Show(
                $"¿Confirma llamar al paciente a consultorio:\n\n{paciente} (DNI: {dni})?",
                "Llamado a Consultorio",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (respuesta == DialogResult.Yes)
            {
                try
                {
                    consultaBL.AvanzarSiguienteEstado(consultaSeleccionada);

                    using (var form = new AtencionMedicaForm(consultaSeleccionada))
                    {
                        form.ShowDialog(this);
                    }

                    CargarConsultas();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al iniciar la atención: {ex.Message}", "Error de Concurrencia", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // ==========================================
        // HELPERS
        // ==========================================
        private GraphicsPath CrearRutaRedondeada(Rectangle r, int radio)
        {
            int d = radio * 2;
            var path = new GraphicsPath();
            path.AddArc(r.X, r.Y, d, d, 180, 90);
            path.AddArc(r.Right - d, r.Y, d, d, 270, 90);
            path.AddArc(r.Right - d, r.Bottom - d, d, d, 0, 90);
            path.AddArc(r.X, r.Bottom - d, d, d, 90, 90);
            path.CloseFigure();
            return path;
        }

        private void dgvEpisodios_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
      
            if (dgvEpisodios.Columns[e.ColumnIndex].Name == "colPrioridad" && e.Value != null)
            {
                string prioridad = e.Value.ToString().ToLower();

                // Evaluamos según el nivel que contenga el texto
                if (prioridad.Contains("nivel 1"))
                {
                    e.CellStyle.ForeColor = Color.Red;
                }
                else if (prioridad.Contains("nivel 2"))
                {
                    e.CellStyle.ForeColor = Color.DarkOrange;
                }
                else if (prioridad.Contains("nivel 3"))
                {
                    e.CellStyle.ForeColor = Color.Gold;
                }
                else if (prioridad.Contains("nivel 4"))
                {
                    e.CellStyle.ForeColor = Color.YellowGreen;
                }
                else if (prioridad.Contains("nivel 5"))
                {
                    e.CellStyle.ForeColor = Color.LightGreen;
                }
            }
        }
    }
}