using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace SistemaTurnos.Negocio
{
    public partial class PacientesEnfermeriaForm : Form
    {
        private string idEpisodioSeleccionado = "";

        public PacientesEnfermeriaForm()
        {
            InitializeComponent();

            // 1. Redondeo de controles del modal
            Redondear(pnlModalAbandono, 10);
            Redondear(pnlModalResumen, 6);
            Redondear(btnModalCancelar, 6);
            Redondear(btnModalConfirmar, 6);

            // 2. Suscripción a eventos de grilla y modal
            dgvEpisodios.CellPainting += Dgv_CellPainting_Acciones;
            dgvEpisodios.CellClick += DgvEpisodios_CellClick;

            btnModalCancelar.Click += (s, e) => pnlModalAbandono.Visible = false;
            btnModalConfirmar.Click += BtnModalConfirmar_Click;

            CargarDatosMock();
        }

        // ==========================================
        // DIBUJO DE LOS BOTONES "ATENDER" Y "ABANDONO"
        // ==========================================
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

            // 1. Botón "▶ Atender" (Teal clínico)
            DibujarBotonGrilla(e.Graphics, rectAtender, "#134E4A", "#2DD4BF", "▶ Atender");

            // 2. Botón "✕ Abandono" (Rojo vino alerta)
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

        // ==========================================
        // DETECCIÓN DE CLIC: ATENDER VS ABANDONO
        // ==========================================
        private void DgvEpisodios_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            if (dgvEpisodios.Columns[e.ColumnIndex].Name != "colAcciones" && e.ColumnIndex != dgvEpisodios.Columns.Count - 1) return;

            var row = dgvEpisodios.Rows[e.RowIndex];
            idEpisodioSeleccionado = row.Cells[0].Value?.ToString() ?? "#1042";
            string paciente = row.Cells.Count > 2 ? row.Cells[2].Value?.ToString() ?? "" : "";
            string dni = row.Cells.Count > 3 ? row.Cells[3].Value?.ToString() ?? "" : "";

            Point cursorEnGrilla = dgvEpisodios.PointToClient(Cursor.Position);
            Rectangle cellRect = dgvEpisodios.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, false);

            if (cursorEnGrilla.X < (cellRect.X + (cellRect.Width / 2)))
            {
                // CU03: Abrir Evaluación y Clasificación
                using (var formTriage = new EvaluacionYClasificacionForm())
                {
                    formTriage.ShowDialog();
                }
            }
            else
            {
                // Mostrar Modal de Abandono centrado
                lblModalEpisodioDni.Text = $"Episodio: {idEpisodioSeleccionado} | DNI: {dni}";
                lblModalPaciente.Text = $"Paciente: {paciente}";

                pnlModalAbandono.BringToFront();
                pnlModalAbandono.Location = new Point(
                    (this.ClientSize.Width - pnlModalAbandono.Width) / 2,
                    (this.ClientSize.Height - pnlModalAbandono.Height) / 2
                );
                pnlModalAbandono.Visible = true;
            }
        }

        private void BtnModalConfirmar_Click(object sender, EventArgs e)
        {
            pnlModalAbandono.Visible = false;
            MessageBox.Show($"Se registró el abandono del episodio {idEpisodioSeleccionado}", "Abandono Confirmado", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void Redondear(Control ctrl, int radio)
        {
            if (ctrl == null) return;
            using (var path = CrearRutaRedondeada(new Rectangle(0, 0, ctrl.Width, ctrl.Height), radio))
            {
                ctrl.Region = new Region(path);
            }
        }

        private void CargarDatosMock()
        {
            dgvEpisodios.Rows.Clear();
            // Columnas: ID, Ingreso, Paciente, Motivo Consulta, Estado, Acciones
            dgvEpisodios.Rows.Add("#1042", "11:45 hs", "Gómez, Martín Eduardo", "Dolor abdominal agudo", "En Espera", "");
            dgvEpisodios.Rows.Add("#1043", "12:05 hs", "Álvarez, Sofía Belén", "Cefalea intensa y mareos", "En Triage", "");
            dgvEpisodios.Rows.Add("#1044", "12:12 hs", "Pérez, Juan Carlos", "Traumatismo en miembro inferior", "En Espera", "");
        }
    }
}