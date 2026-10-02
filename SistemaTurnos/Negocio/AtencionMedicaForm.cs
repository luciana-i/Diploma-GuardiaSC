using BE;
using BLL;
using BLL.Servicios;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace SistemaTurnos.Negocio
{
    public partial class AtencionMedicaForm : Form
    {

        Consulta _consultaActual;
        AtencionMedicaBL atencionMedicaBL = new AtencionMedicaBL();
        AtencionMedica atencionMedica;
        public AtencionMedicaForm(Consulta consultaSeleccionada)
        {
            InitializeComponent();
            _consultaActual = consultaSeleccionada;
            atencionMedica = atencionMedicaBL.RegistrarAtencion(_consultaActual, SessionManager.getInstance().ObtenerUsuario()); 
            // 1. Suscribir el pintado custom de los 3 GroupBoxes para el título con parche
            grpContextoTriage.Paint += GroupBox_CustomPaint;
            grpEvolucionMedica.Paint += GroupBox_CustomPaint;
            grpDestinoAsistencial.Paint += GroupBox_CustomPaint;

            // 2. Redondear los botones y cargar datos de prueba al iniciar
            this.Load += (s, e) =>
            {
                RedondearControl(btnFinalizarAtencion, 6);
                RedondearControl(btnVerHistoriaClinica, 4);
            };

            lblPacienteDatos.Text=_consultaActual.Paciente.NombreCompleto;
            lblMotivoValor.Text=_consultaActual.MotivoIngreso.ToString();
            
            EvaluacionEnfermeriaBL evaluacionBL = new EvaluacionEnfermeriaBL();

            EvaluacionEnfermeria enfermeria = evaluacionBL.ObtenerPorConsultaId(_consultaActual.Id);
            lblFcValor.Text = enfermeria.FrecuenciaCardiaca.ToString();
            lblPaValor.Text = enfermeria.PresionArterial.ToString();
            lblSatValor.Text= enfermeria.SaturacionOxigeno.ToString();
            lblTempVal.Text=enfermeria.Temperatura.ToString();
            ConfigurarBadgePrioridad(enfermeria.PrioridadFinal);
            cmbDestino.DataSource = Enum.GetValues(typeof(DestinoConsulta)).Cast<DestinoConsulta>().ToList();
        }

        // Helper auxiliar para pintar dinámicamente el badge de prioridad según el nivel de Triage
        private void ConfigurarBadgePrioridad(NivelPrioridad prioridad)
        {
            switch (prioridad)
            {
                case NivelPrioridad.Emergencia: // 1 - Rojo
                    lblPrioridadValor.Text = "NIVEL 1 - ROJO (Emergencia)";
                    lblPrioridadValor.ForeColor = ColorTranslator.FromHtml("#EF4444");
                    break;
                case NivelPrioridad.MuyUrgente: // 2 - Naranja
                    lblPrioridadValor.Text = "NIVEL 2 - NARANJA (Muy Urgente)";
                    lblPrioridadValor.ForeColor = ColorTranslator.FromHtml("#FB923C");
                    break;
                case NivelPrioridad.Urgente: // 3 - Amarillo
                    lblPrioridadValor.Text = "NIVEL 3 - AMARILLO (Urgente)";
                    lblPrioridadValor.ForeColor = ColorTranslator.FromHtml("#FDE047");
                    break;
                case NivelPrioridad.PocoUrgente: // 4 - Verde
                    lblPrioridadValor.Text = "NIVEL 4 - VERDE (Poco Urgente)";
                    lblPrioridadValor.ForeColor = ColorTranslator.FromHtml("#4ADE80");
                    break;
                case NivelPrioridad.NoUrgente: // 5 - Azul
                default:
                    lblPrioridadValor.Text = "NIVEL 5 - AZUL (No Urgente)";
                    lblPrioridadValor.ForeColor = ColorTranslator.FromHtml("#60A5FA");
                    break;
            }
        }

        // Dibuja el borde oscuro y el parche de fondo para el texto en verde menta
        private void GroupBox_CustomPaint(object sender, PaintEventArgs e)
        {
            GroupBox box = sender as GroupBox;
            if (box == null) return;

            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            SizeF textSize = g.MeasureString(box.Text, box.Font);
            int topOffset = (int)(textSize.Height / 2);
            Rectangle borderRect = new Rectangle(0, topOffset, box.Width - 1, box.Height - topOffset - 1);

            // Borde oscuro
            using (Pen pen = new Pen(Color.FromArgb(54, 71, 79), 1.2f)) // #36474F
            {
                g.DrawRectangle(pen, borderRect);
            }

            // Parche oscuro para que el título no quede tachado por el borde
            if (!string.IsNullOrEmpty(box.Text))
            {
                Rectangle textBgRect = new Rectangle(15, 0, (int)textSize.Width + 8, (int)textSize.Height);
                using (Brush patchBrush = new SolidBrush(Color.FromArgb(32, 44, 49))) // #202C31
                {
                    g.FillRectangle(patchBrush, textBgRect);
                }

                using (Brush textBrush = new SolidBrush(box.ForeColor))
                {
                    g.DrawString(box.Text, box.Font, textBrush, 18, 0);
                }
            }
        }

        // Aplica esquinas redondeadas suaves
        private void RedondearControl(Control ctrl, int radio)
        {
            if (ctrl == null) return;
            using (GraphicsPath path = new GraphicsPath())
            {
                int d = radio * 2;
                path.AddArc(0, 0, d, d, 180, 90);
                path.AddArc(ctrl.Width - d, 0, d, d, 270, 90);
                path.AddArc(ctrl.Width - d, ctrl.Height - d, d, d, 0, 90);
                path.AddArc(0, ctrl.Height - d, d, d, 90, 90);
                path.CloseFigure();
                ctrl.Region = new Region(path);
            }
        }

        private void btnVerHistoriaClinica_Click(object sender, EventArgs e)
        {
            using (var formHC = new HistoriaClinicaForm(_consultaActual.Paciente))
            {
                formHC.ConfigurarModoConsulta(soloLectura: true);
                formHC.ShowDialog(this);
            }
        }

        private void btnFinalizarAtencion_Click(object sender, EventArgs e)
        {
            string diagnostico = txtDiagnostico.Text.Trim();
            string indicaciones = txtIndicaciones.Text.Trim();
            string destinoSeleccionado = cmbDestino.SelectedItem?.ToString();

            if (string.IsNullOrWhiteSpace(diagnostico) || string.IsNullOrWhiteSpace(indicaciones) || string.IsNullOrWhiteSpace(destinoSeleccionado))
            {
                MessageBox.Show("Debe completar todos los campos obligatorios:\n\n• Diagnóstico Clínico\n• Indicaciones Terapéuticas\n• Destino Asistencial",
                    "Campos Incompletos", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                if (string.IsNullOrWhiteSpace(diagnostico))
                    txtDiagnostico.Focus();
                else if (string.IsNullOrWhiteSpace(indicaciones))
                    txtIndicaciones.Focus();
                else
                    cmbDestino.Focus();

                return;
            }

            var confirmacion = MessageBox.Show(
            $"¿Confirma finalizar la atención médica con destino:\n\n'{destinoSeleccionado}'?",
            "Confirmación de Cierre Clínico",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Question);

            if (confirmacion != DialogResult.Yes) return;

            try
            {
                atencionMedica.Diagnostico = diagnostico;
                atencionMedica.Indicaciones = indicaciones;
                atencionMedica.Destino = (DestinoConsulta)Enum.Parse(typeof(DestinoConsulta), destinoSeleccionado);


                atencionMedicaBL.FinalizarAtencionMedica(atencionMedica);

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al intentar registrar la atención médica: {ex.Message}", "Error de Persistencia", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}