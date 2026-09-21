using BE;
using BLL;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Windows.Forms;

namespace SistemaTurnos.Negocio
{
    public partial class BandejaEnfermeriaForm : BaseEsperaGuardiaForm
    {
        private List<Consulta> _consultasActivas = new List<Consulta>();
        private List<Consulta> _consultasVisibles = new List<Consulta>();
        private ConsultaBL consultaBL = new ConsultaBL();

        public BandejaEnfermeriaForm()
        {
            InitializeComponent();

            // 1. Suscripción a eventos de grilla (Ya no manejamos el panel modal acá dentro)
            dgvEpisodios.CellPainting += Dgv_CellPainting_Acciones;
            dgvEpisodios.CellClick += DgvEpisodios_CellClick;

            // 2. Inicializar combos, filtros y carga de BD
            ConfigurarFiltroEstados();
        }

        private void ConfigurarFiltroEstados()
        {
            var opciones = new[]
            {
                new { Id = (int?)null,                     Nombre = "-- Todas las Activas --" },
                new { Id = (int?)EstadoConsulta.EnEsperaEnfermeria,    Nombre = "Para Atencion Enfermería" },
                new { Id = (int?)EstadoConsulta.EnEnfermeria,          Nombre = "En Enfermería" },
                new { Id = (int?)EstadoConsulta.EnEsperaAtencionMedica, Nombre = "Para Atención Médica" },
                new { Id = (int?)EstadoConsulta.EnAtencionMedica,      Nombre = "En Guardia Médica" }
            };

            cmbFiltroEstado.DisplayMember = "Nombre";
            cmbFiltroEstado.ValueMember = "Id";
            cmbFiltroEstado.DataSource = opciones;
            cmbFiltroEstado.SelectedValue = (int)EstadoConsulta.EnEsperaEnfermeria;

            cmbFiltroEstado.SelectedIndexChanged += (s, e) => AplicarFiltroEnMemoria();
            btnRefrescar.Click += (s, e) => CargarConsultas();

            CargarConsultas();
        }

        public void CargarConsultas()
        {
            try
            {
                _consultasActivas = consultaBL.ObtenerConsultasActivas();
                AplicarFiltroEnMemoria();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al consultar los episodios activos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AplicarFiltroEnMemoria()
        {
            int? estadoSeleccionado = cmbFiltroEstado.SelectedValue as int?;
            _consultasVisibles = _consultasActivas
                .Where(x => !estadoSeleccionado.HasValue || (int)x.EstadoConsulta == estadoSeleccionado.Value)
                .ToList();

            MostrarEnGrilla(_consultasVisibles);
        }

        private void MostrarEnGrilla(List<Consulta> lista)
        {
            dgvEpisodios.Rows.Clear();

            foreach (var c in lista)
            {
                string idFormateado = $"#{c.Id}";
                string horaIngreso = c.FechaIngreso.ToString("HH:mm") + " hs";
                string pacienteCompleto = $"{c.Paciente.Apellido}, {c.Paciente.Nombre}";

                string estadoTexto;
                switch (c.EstadoConsulta)
                {
                    case EstadoConsulta.EnEsperaEnfermeria: estadoTexto = "En Espera"; break;
                    case EstadoConsulta.EnEnfermeria: estadoTexto = "En Atención Enfermería"; break;
                    case EstadoConsulta.EnEsperaAtencionMedica: estadoTexto = "Para Atención"; break;
                    case EstadoConsulta.EnAtencionMedica: estadoTexto = "En Atención Médica"; break;
                    default: estadoTexto = c.EstadoConsulta.ToString(); break;
                }

                dgvEpisodios.Rows.Add(idFormateado, horaIngreso, pacienteCompleto, c.MotivoIngreso, estadoTexto, "");
            }

            if (lblContadorActivas != null)
                lblContadorActivas.Text = $"● Activas en Guardia: {lista.Count}";

            dgvEpisodios.ClearSelection();
        }

        private void Dgv_CellPainting_Acciones(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;
            if (dgvEpisodios.Columns[e.ColumnIndex].Name != "colAcciones" && e.ColumnIndex != dgvEpisodios.Columns.Count - 1) return;

            e.PaintBackground(e.ClipBounds, true);

            int btnHeight = 28;
            int btnY = e.CellBounds.Y + (e.CellBounds.Height - btnHeight) / 2;
            int gap = 8;
            int btnWidth = (e.CellBounds.Width - 20 - gap) / 2;

            Rectangle rectAtender = new Rectangle(e.CellBounds.X + 10, btnY, btnWidth, btnHeight);
            Rectangle rectAbandono = new Rectangle(rectAtender.Right + gap, btnY, btnWidth, btnHeight);

            DibujarBotonGrilla(e.Graphics, rectAtender, "#134E4A", "#2DD4BF", "▶ Atender");
            DibujarBotonGrilla(e.Graphics, rectAbandono, "#7F1D1D", "#DC2626", "✕ Abandono");

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

        private void DgvEpisodios_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.RowIndex >= _consultasVisibles.Count) return;
            if (dgvEpisodios.Columns[e.ColumnIndex].Name != "colAcciones" && e.ColumnIndex != dgvEpisodios.Columns.Count - 1) return;

            var consultaSeleccionada = _consultasVisibles[e.RowIndex];
            string paciente = $"{consultaSeleccionada.Paciente.Apellido}, {consultaSeleccionada.Paciente.Nombre}";
            string dni = consultaSeleccionada.Paciente.Dni;

            Point cursorEnGrilla = dgvEpisodios.PointToClient(Cursor.Position);
            Rectangle cellRect = dgvEpisodios.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, false);

            if (cursorEnGrilla.X < (cellRect.X + (cellRect.Width / 2)))
            {
                // ATENDER
                var respuesta = MessageBox.Show(
                    $"¿Confirma iniciar la atención para el paciente:\n\n{paciente} (DNI: {dni})?",
                    "Iniciar Atención",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (respuesta == DialogResult.Yes)
                {
                    try
                    {
                        consultaBL.AvanzarSiguienteEstado(consultaSeleccionada);
                        consultaSeleccionada.EstadoConsulta = EstadoConsulta.EnEnfermeria;

                        using (var formTriage = new EvaluacionYClasificacionForm(consultaSeleccionada))
                        {
                            formTriage.ShowDialog(this);
                        }

                        CargarConsultas();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error al iniciar la atención: {ex.Message}", "Error de Concurrencia", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                // ABANDONO: Abre el nuevo formulario independiente como diálogo modal
                using (var formAbandono = new CancelarGuardiaForm(consultaSeleccionada.Id, dni, paciente))
                {
                    if (formAbandono.ShowDialog(this) == DialogResult.OK)
                    {
                        CargarConsultas(); // Refresca la grilla al confirmar la baja
                    }
                }
            }
        }

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
    }
}