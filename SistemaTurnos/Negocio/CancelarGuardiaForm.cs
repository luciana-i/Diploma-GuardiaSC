using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using BLL;

namespace SistemaTurnos.Negocio
{
    public partial class CancelarGuardiaForm : Form
    {
        private readonly int _consultaId;
        private ConsultaBL consultaBL = new ConsultaBL();

        // Constructor que recibe el ID, DNI y Nombre del paciente desde la bandeja
        public CancelarGuardiaForm(int consultaId, string dni, string pacienteNombre)
        {
            InitializeComponent();
            _consultaId = consultaId;

            // Mapeamos los datos a los labels que se ven en tu captura
            // (Asegurate de renombrar tus labels del diseñador o usá los nombres reales)
            lblModalEpisodioDni.Text = $"Episodio: #{consultaId} | DNI: {dni}";
            lblModalPaciente.Text = $"Paciente: {pacienteNombre}";

            // Estilos de botones y esquinas redondeadas
            Redondear(btnModalCancelar, 6);
            Redondear(btnModalConfirmar, 6);

            btnModalCancelar.Click += (s, e) => { this.DialogResult = DialogResult.Cancel; this.Close(); };
            btnModalConfirmar.Click += BtnModalConfirmar_Click;
        }

        private void BtnModalConfirmar_Click(object sender, EventArgs e)
        {
            try
            {
                // Aquí llamás a la lógica de negocio para registrar el abandono/cancelación en la BD
                // Ej: consultaBL.RegistrarAbandono(_consultaId);

                MessageBox.Show($"Se registró el abandono del episodio #{_consultaId}", "Abandono Confirmado", MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al registrar el abandono: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Helpers de diseño para mantener la estética limpia
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
    }
}