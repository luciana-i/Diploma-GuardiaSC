using BE;
using BLL;
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
        public AtencionMedicaForm()
        {
            InitializeComponent();

            // 1. Suscribir el pintado custom de los 3 GroupBoxes para el título con parche
            grpContextoTriage.Paint += GroupBox_CustomPaint;
            grpEvolucionMedica.Paint += GroupBox_CustomPaint;
            grpDestinoAsistencial.Paint += GroupBox_CustomPaint;

            // 2. Redondear los botones y cargar datos de prueba al iniciar
            this.Load += (s, e) =>
            {
                RedondearControl(btnFinalizarAtencion, 6);
                RedondearControl(btnVerHistoriaClinica, 4);
                _consultaActual = ObtenerConsultaMockDePrueba(); // <--- Carga la consulta simulada aquí
                CargarDatosMock(); // <--- Carga los datos simulados aquí
                                   // se da inicio a la consulta, se registra en AtencionMedica con fecha de inicio y estado en curso
                atencionMedica = atencionMedicaBL.RegistrarAtencion(_consultaActual, new Usuario { Id = 1 }); // Simulación: ID del médico que atiende (en un caso real, se obtiene del usuario logueado)

            };
        }

        public AtencionMedicaForm(Consulta consultaSeleccionada)
        {
            InitializeComponent();
            _consultaActual = consultaSeleccionada;
            atencionMedica = atencionMedicaBL.RegistrarAtencion(_consultaActual, new Usuario { Id = 1 }); // Simulación: ID del médico que atiende (en un caso real, se obtiene del usuario logueado)
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
        }

        public static Consulta ObtenerConsultaMockDePrueba()
        {
            return new Consulta
            {
                Id = 1042,
                FechaIngreso = DateTime.Now.AddMinutes(-35), // Ingresó hace 35 minutos
                MotivoIngreso = "Dolor torácico opresivo y dificultad respiratoria",
                DVH = 123456789, // O null si no se usa DVH en este punto
                EstadoConsulta = EstadoConsulta.EnEsperaAtencionMedica,

                // Composición del Paciente
                Paciente = new Paciente
                {
                    Id = 1,
                    Nombre = "Juan Manuel",
                    Apellido = "Gómez Fernández",
                    Dni = "38452190"
                },

                // Usuario que realizó el ingreso en Admisión
                UsuarioIngreso = new Usuario
                {
                    Id = 1,
                    Username = "Admisionista Turno Mañana"
                },

                // Composición de Triage (EvaluacionEnfermeria con prioridad asignada)
                EvaluacionEnfermeria = new EvaluacionEnfermeria
                {
                    FrecuenciaCardiaca = 115,
                    Temperatura = 37.8m,
                    SaturacionOxigeno = 91,
                    PresionArterial = "140/90",
                    PrioridadFinal = NivelPrioridad.MuyUrgente // Nivel 2
                },

                // AtencionMedica se mantiene en null hasta que el médico la inicie y finalice en el consultorio
                AtencionMedica = null
            };
        }

        // Método para simular y asignar los datos en los Labels del panel superior
        private void CargarDatosMock()
        {
            if (_consultaActual == null) return;

            // 1. Datos del Paciente y Motivo de Ingreso
            if (_consultaActual.Paciente != null)
            {
                lblPacienteDatos.Text = $"{_consultaActual.Paciente.Apellido}, {_consultaActual.Paciente.Nombre} (DNI: {_consultaActual.Paciente.Dni})";
            }

            lblMotivoValor.Text = !string.IsNullOrWhiteSpace(_consultaActual.MotivoIngreso)
                ? _consultaActual.MotivoIngreso
                : "Sin motivo especificado";

            // 2. Signos Vitales y Prioridad desde la composición (EvaluacionEnfermeria)
            if (_consultaActual.EvaluacionEnfermeria != null)
            {
                var eval = _consultaActual.EvaluacionEnfermeria;

                // Frecuencia Cardíaca
                lblFcValor.Text = eval.FrecuenciaCardiaca.HasValue
                    ? $"{eval.FrecuenciaCardiaca.Value} lpm"
                    : "-- lpm";

                // Temperatura (con alerta visual si es mayor o igual a 38°C)
                if (eval.Temperatura.HasValue)
                {
                    decimal temp = eval.Temperatura.Value;
                    lblTempVal.Text = temp >= 38.0m ? $"{temp:0.1} °C (Febril)" : $"{temp:0.1} °C";
                    lblTempVal.ForeColor = temp >= 38.0m ? ColorTranslator.FromHtml("#EF4444") : Color.White;
                }
                else
                {
                    lblTempVal.Text = "-- °C";
                }

                // Saturación de Oxígeno (con alerta si es menor al 92%)
                if (eval.SaturacionOxigeno.HasValue)
                {
                    int sat = eval.SaturacionOxigeno.Value;
                    lblSatValor.Text = $"{sat} %";
                    lblSatValor.ForeColor = sat < 92 ? ColorTranslator.FromHtml("#EF4444") : Color.White;
                }
                else
                {
                    lblSatValor.Text = "-- %";
                }

                // Presión Arterial
                lblPaValor.Text = !string.IsNullOrWhiteSpace(eval.PresionArterial)
                    ? $"{eval.PresionArterial} mmHg"
                    : "-- mmHg";

                // Prioridad de Triage Final con sus respectivos colores institucionales del semáforo
                ConfigurarBadgePrioridad(eval.PrioridadFinal);
            }
            else
            {
                // Valores por defecto si la consulta aún no tiene Triage registrado
                lblFcValor.Text = "-- lpm";
                lblTempVal.Text = "-- °C";
                lblSatValor.Text = "-- %";
                lblPaValor.Text = "-- mmHg";
                lblPrioridadValor.Text = "Sin Triage Asignado";
                lblPrioridadValor.ForeColor = Color.Gray;
            }
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
                // En Triage (enfermería) solo es para consultar antecedentes
                formHC.ConfigurarModoConsulta(soloLectura: true);
                formHC.ShowDialog(this);
            }
        }

        private void btnFinalizarAtencion_Click(object sender, EventArgs e)
        {
            string diagnostico = txtDiagnostico.Text.Trim();
            string indicaciones = txtIndicaciones.Text.Trim();
            string destinoSeleccionado = cmbDestino.SelectedItem?.ToString();
            string detalleDestino = txtDetalleDestino.Text.Trim();

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
                // si hay detalle o pautas de alarma,va a indicaciones
                string indicacionesFinales = string.IsNullOrWhiteSpace(detalleDestino)
                ? indicaciones
                : $"{indicaciones}\r\n[Detalle/Pautas de Alarma]: {detalleDestino}";
                /*
                                atencionMedica = {
                                    FechaFin = DateTime.Now, 
                                    Diagnostico = diagnostico,
                                    Indicaciones = indicacionesFinales,
                                    Destino = destinoSeleccionado
                                }


                                new AtencionMedicaBL().RegistrarAtencion(atencionMedica);
                                consultaBL.CambiarEstado(_consultaActual.Id, EstadoConsulta.Finalizado);

                                MessageBox.Show(
                                    "La atención médica se ha registrado y finalizado con éxito.\nEl episodio ha concluido.",
                                    "Atención Concluida",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);
                */
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