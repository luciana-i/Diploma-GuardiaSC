using BE;
using BLL;
using BLL.Servicios;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace SistemaTurnos.Negocio
{
    public partial class EvaluacionYClasificacionForm : Form
    {
        private Consulta _consultaActual;
        private readonly AsignacionPrioridadService asignacionPrioridadService = new AsignacionPrioridadService();
        private NivelPrioridad _prioridadSugerida;
        private ConsultaBL consultaBL = new ConsultaBL();
        private EvaluacionEnfermeriaBL evaluacionEnfermeriaBL = new EvaluacionEnfermeriaBL();

         public EvaluacionYClasificacionForm(Consulta consulta)
        {
            InitializeComponent();

            // 1. Redondeo de botones
            Redondear(btnCalcularPrioridad, 8);
            Redondear(btnConfirmarTriage, 8);
            Redondear(btnCancelar, 8);

            // 2. Suscribir GroupBoxes al pintado oscuro
            grpPacienteEspera.Paint += GroupBox_DarkPaint;
            grpEvaluacionClinica.Paint += GroupBox_DarkPaint;
            grpDeterminacionPrioridad.Paint += GroupBox_DarkPaint;

            _consultaActual = consulta;
            CargarDatosCabecera();
        }

        private void CargarDatosCabecera()
        {
            if (_consultaActual == null) return;

            // 1. PACIENTE / DNI
            if (_consultaActual.Paciente != null)
            {
                lblPacienteNombre.Text = $"{_consultaActual.Paciente.Apellido}, {_consultaActual.Paciente.Nombre}";
                lblPacienteDni.Text = $"(DNI: {_consultaActual.Paciente.Dni})";
            }

            // 2. N° Consulta
            lblNumeroConsulta.Text = $"#{_consultaActual.Id}";

            // 3. Hora Consulta
            lblHoraConsulta.Text = _consultaActual.FechaIngreso.ToString("HH:mm") + " hs";
        }

        // Dibuja el borde plano oscuro y el título verde menta institucional
        private void GroupBox_DarkPaint(object sender, PaintEventArgs e)
        {
            GroupBox box = sender as GroupBox;
            if (box == null) return;

            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            SizeF textSize = e.Graphics.MeasureString(box.Text, box.Font);
            int topOffset = (int)(textSize.Height / 2);
            Rectangle borderRect = new Rectangle(0, topOffset, box.Width - 1, box.Height - topOffset - 1);

            using (Brush bgBrush = new SolidBrush(box.BackColor))
                e.Graphics.FillRectangle(bgBrush, 0, 0, box.Width, box.Height);

            using (Pen pen = new Pen(ColorTranslator.FromHtml("#36474F"), 1.2f))
                e.Graphics.DrawRectangle(pen, borderRect);

            if (!string.IsNullOrEmpty(box.Text))
            {
                Rectangle textBg = new Rectangle(12, 0, (int)textSize.Width + 6, (int)textSize.Height);
                using (Brush bgBrush = new SolidBrush(box.BackColor))
                    e.Graphics.FillRectangle(bgBrush, textBg);

                using (Brush textBrush = new SolidBrush(ColorTranslator.FromHtml("#9BD2B9")))
                    e.Graphics.DrawString(box.Text, box.Font, textBrush, 15, 0);
            }
        }

        // Helper para esquinas redondeadas
        private void Redondear(Control ctrl, int radio)
        {
            if (ctrl == null) return;
            using (var path = new GraphicsPath())
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

        // Dibuja los círculos de color oficiales del semáforo de triage en el desplegable
        private void cmbPrioridadFinal_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index < 0) return;

            ComboBox cmb = (ComboBox)sender;
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            bool isSelected = (e.State & DrawItemState.Selected) == DrawItemState.Selected;
            Color bgFondo = isSelected ? ColorTranslator.FromHtml("#2E4A56") : ColorTranslator.FromHtml("#1E282D");

            using (Brush brushBg = new SolidBrush(bgFondo))
                e.Graphics.FillRectangle(brushBg, e.Bounds);

            Color[] coloresTriage = {
                ColorTranslator.FromHtml("#EF4444"), // 1. Rojo
                ColorTranslator.FromHtml("#F97316"), // 2. Naranja
                ColorTranslator.FromHtml("#EAB308"), // 3. Amarillo
                ColorTranslator.FromHtml("#10B981"), // 4. Verde
                ColorTranslator.FromHtml("#3B82F6")  // 5. Azul
            };

            Color colorNivel = (e.Index < coloresTriage.Length) ? coloresTriage[e.Index] : Color.Gray;

            // Círculo indicador
            int circleSize = 10;
            int circleY = e.Bounds.Y + (e.Bounds.Height - circleSize) / 2;
            using (Brush brushCircle = new SolidBrush(colorNivel))
                e.Graphics.FillEllipse(brushCircle, e.Bounds.X + 8, circleY, circleSize, circleSize);

            // Texto
            using (Brush brushText = new SolidBrush(ColorTranslator.FromHtml("#F1F5F9")))
                e.Graphics.DrawString(cmb.Items[e.Index].ToString(), cmb.Font, brushText, e.Bounds.X + 24, e.Bounds.Y + 3);
        }

        private void btnVerHistoriaClinica_Click(object sender, EventArgs e)
        {
            using (var formHC = new HistoriaClinicaForm(_consultaActual.Paciente))
            {
                formHC.ShowDialog(this);
            }
        }

        private void btnCalcularPrioridad_Click(object sender, EventArgs e)
        {
            if (!ValidarCamposSignosVitales()) return;

            // 1. Obtener valores de la vista
            int? fc = int.TryParse(txtFc.Text.Trim(), out int valFc) ? valFc : (int?)null;
            decimal? temp = decimal.TryParse(txtTemperatura.Text.Trim().Replace('.', ','), out decimal valTemp) ? valTemp : (decimal?)null;
            int? sat = int.TryParse(txtSaturacion.Text.Trim(), out int valSat) ? valSat : (int?)null;
            string pa = txtPresion.Text.Trim();
            bool esAdmin = chkConsultaAdministrativa != null && chkConsultaAdministrativa.Checked;

            // 2. Ejecutar cálculo en el Service
            _prioridadSugerida = asignacionPrioridadService.CalcularPrioridadSugerida(fc, temp, sat, pa, esAdmin);

            // 3. Pintar en pantalla usando el método limpio nativo
            ActualizarTarjetaPrioridad(_prioridadSugerida);

            // 4. Preseleccionar en el ComboBox de Prioridad Final (índice 0 a 4)
            int nivelNumero = (int)_prioridadSugerida;
            cmbPrioridadFinal.SelectedIndex = nivelNumero - 1;
        }

        private bool ValidarCamposSignosVitales()
        {
            bool esRenovacion = chkConsultaAdministrativa != null && chkConsultaAdministrativa.Checked;

            // Si es renovación de recetas / trámite administrativo, no se exigen signos vitales completos
            if (esRenovacion)
            {
                if (string.IsNullOrWhiteSpace(txtSintomas.Text))
                {
                    MessageBox.Show(
                        "Para consultas administrativas o renovación de recetas, indique brevemente el detalle en 'Síntomas Observados'.",
                        "Campo Requerido",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    txtSintomas.Focus();
                    return false;
                }
                return true;
            }

            // 1. FRECUENCIA CARDÍACA (lpm)
            if (string.IsNullOrWhiteSpace(txtFc.Text) || !int.TryParse(txtFc.Text.Trim(), out int fc) || fc < 20 || fc > 300)
            {
                MessageBox.Show("Por favor, ingrese un valor válido para la Frecuencia Cardíaca (ej. entre 30 y 250 lpm).",
                    "Dato Requerido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtFc.Focus();
                return false;
            }

            // 2. TEMPERATURA (°C)
            string tempStr = txtTemperatura.Text.Trim().Replace('.', ',');
            if (string.IsNullOrWhiteSpace(txtTemperatura.Text) || !decimal.TryParse(tempStr, out decimal temp) || temp < 30m || temp > 45m)
            {
                MessageBox.Show("Por favor, ingrese una Temperatura corporal válida (ej. 36.5 °C).",
                    "Dato Requerido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTemperatura.Focus();
                return false;
            }

            // 3. SATURACIÓN DE OXÍGENO (%)
            if (string.IsNullOrWhiteSpace(txtSaturacion.Text) || !int.TryParse(txtSaturacion.Text.Trim(), out int sat) || sat < 50 || sat > 100)
            {
                MessageBox.Show("Por favor, ingrese una Saturación de Oxígeno válida (entre 50% y 100%).",
                    "Dato Requerido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSaturacion.Focus();
                return false;
            }

            // 4. PRESIÓN ARTERIAL (PA - formato Sistólica/Diastólica)
            string pa = txtPresion.Text.Trim();
            if (string.IsNullOrWhiteSpace(pa) || !pa.Contains("/"))
            {
                MessageBox.Show("Ingrese la Presión Arterial en el formato estándar Sistólica/Diastólica (ej. 120/80).",
                    "Dato Requerido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPresion.Focus();
                return false;
            }

            string[] partesPa = pa.Split('/');
            if (partesPa.Length != 2 ||
                !int.TryParse(partesPa[0].Trim(), out int sistolica) ||
                !int.TryParse(partesPa[1].Trim(), out int diastolica) ||
                sistolica < 40 || sistolica > 280 || diastolica < 20 || diastolica > 180)
            {
                MessageBox.Show("Los valores de Presión Arterial son inconsistentes. Verifique los datos (ej. 120/80).",
                    "Dato Requerido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPresion.Focus();
                return false;
            }

            // 5. SÍNTOMAS OBSERVADOS
            if (string.IsNullOrWhiteSpace(txtSintomas.Text))
            {
                MessageBox.Show("Debe ingresar los Síntomas Observados o la descripción del cuadro por el que consulta el paciente.",
                    "Dato Requerido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSintomas.Focus();
                return false;
            }

            return true;
        }

        private void ActualizarTarjetaPrioridad(NivelPrioridad prioridad)
        {
            string textoNivel;
            Color colorTexto;
            Color colorFondo;

            switch (prioridad)
            {
                case NivelPrioridad.Emergencia: // 1 - Rojo
                    textoNivel = "NIVEL 1 (EMERGENCIA / REANIMACIÓN)";
                    colorTexto = ColorTranslator.FromHtml("#EF4444");
                    colorFondo = ColorTranslator.FromHtml("#3B1B1F");
                    break;

                case NivelPrioridad.MuyUrgente: // 2 - Naranja
                    textoNivel = "NIVEL 2 (MUY URGENTE)";
                    colorTexto = ColorTranslator.FromHtml("#FB923C");
                    colorFondo = ColorTranslator.FromHtml("#3A2216");
                    break;

                case NivelPrioridad.Urgente: // 3 - Amarillo
                    textoNivel = "NIVEL 3 (URGENTE)";
                    colorTexto = ColorTranslator.FromHtml("#FDE047");
                    colorFondo = ColorTranslator.FromHtml("#2E2B16");
                    break;

                case NivelPrioridad.PocoUrgente: // 4 - Verde
                    textoNivel = "NIVEL 4 (POCO URGENTE)";
                    colorTexto = ColorTranslator.FromHtml("#4ADE80");
                    colorFondo = ColorTranslator.FromHtml("#162E24");
                    break;

                case NivelPrioridad.NoUrgente: // 5 - Azul
                default:
                    textoNivel = "NIVEL 5 (NO URGENTE)";
                    colorTexto = ColorTranslator.FromHtml("#60A5FA");
                    colorFondo = ColorTranslator.FromHtml("#17253B");
                    break;
            }

            // 1. Panel: solo fondo y borde nativo directo
            pnlPrioridadSugerida.BackColor = colorFondo;
            pnlPrioridadSugerida.BorderStyle = BorderStyle.FixedSingle;

            // 2. Textos
            lblSugerenciaHeader.ForeColor = ColorTranslator.FromHtml("#CBD5E1");
            lblSugerenciaHeader.BackColor = Color.Transparent;

            lblNivelSugerido.Text = textoNivel;
            lblNivelSugerido.ForeColor = colorTexto;
            lblNivelSugerido.BackColor = Color.Transparent;
        }

        private void btnConfirmarTriage_Click(object sender, EventArgs e)
        {
            if (!ValidarCamposSignosVitales()) return;

            // 2. Validar que se haya calculado la prioridad sugerida
            if ((int)_prioridadSugerida == 0)
            {
                MessageBox.Show("Debe presionar 'Calcular Prioridad' antes de confirmar el Triage.",
                    "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                btnCalcularPrioridad.Focus();
                return;
            }

            // 3. Obtener la prioridad final elegida por el enfermero (Combo índice 0 = Nivel 1)
            if (cmbPrioridadFinal.SelectedIndex < 0)
            {
                MessageBox.Show("Debe seleccionar una Prioridad Final Asignada.",
                    "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbPrioridadFinal.Focus();
                return;
            }

            NivelPrioridad prioridadFinal = (NivelPrioridad)(cmbPrioridadFinal.SelectedIndex + 1);
            string justificacion = txtJustificacion.Text.Trim();

            // 4. Regla de negocio: si difiere de la sugerencia, la justificación es obligatoria
            if (prioridadFinal != _prioridadSugerida && string.IsNullOrWhiteSpace(justificacion))
            {
                MessageBox.Show(
                    "Ha asignado un nivel distinto al sugerido por el sistema.\nDebe ingresar una Justificación de Discrepancia.",
                    "Justificación Obligatoria",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                txtJustificacion.Focus();
                return;
            }

            var confirmacion = MessageBox.Show(
                $"¿Confirma asignar la prioridad {prioridadFinal.ToString().ToUpper()} al paciente?\n\nEl episodio quedará en espera de atención médica.",
                "Confirmación de Clasificación de Triage",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirmacion != DialogResult.Yes) return;

            try
            {
                bool esAdministrativa = chkConsultaAdministrativa != null && chkConsultaAdministrativa.Checked;
                int? fc = int.TryParse(txtFc.Text.Trim(), out int valFc) ? valFc : (int?)null;
                decimal? temp = decimal.TryParse(txtTemperatura.Text.Trim().Replace('.', ','), out decimal valTemp) ? valTemp : (decimal?)null;
                int? sat = int.TryParse(txtSaturacion.Text.Trim(), out int valSat) ? valSat : (int?)null;
                string pa = txtPresion.Text.Trim();
                string sintomas = txtSintomas.Text.Trim();

                var evaluacion = new EvaluacionEnfermeria(
                     _consultaActual,
                     fc,
                     temp,
                     sat,
                     pa,
                     sintomas,
                     esAdministrativa,
                     _prioridadSugerida,
                     prioridadFinal,
                     justificacion 
                 );

                evaluacionEnfermeriaBL.Insertar(evaluacion);

                consultaBL.AvanzarSiguienteEstado(_consultaActual);

                MessageBox.Show("Evaluación de Enfermeria registrada exitosamente. El paciente está disponible para llamada médica.",
                    "Atencion de Enfermeria Completada", MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al registrar La atencion de enfermeria: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}