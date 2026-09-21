using BE;
using BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaTurnos
{
    public partial class HistoriaClinicaForm : Form
    {
        Paciente _pacienteActual;

        HistoriaClinicaBLL historiaClinicaBLL = new HistoriaClinicaBLL();
        public HistoriaClinicaForm()
        {
            InitializeComponent();
           // CargarMock();
            _pacienteActual = new Paciente
            {
                Id = 1,
                Dni = "2222",
                Apellido = "Gomez",
                Nombre = "Maria",
                FechaNacimiento = new DateTime(1990, 1, 1),
                Telefono = "333"
            };

            ConfigurarModoConsulta(true);
            CargarHistorialAntecedentes();
        }

        public HistoriaClinicaForm(Paciente paciente)
        {
            InitializeComponent();
            //CargarMock();
            _pacienteActual = paciente;
            CargarHistorialAntecedentes();
        }

        /// <summary>
        /// Oculta el panel/grupo de agregar antecedentes si entra un enfermero en modo solo lectura.
        /// </summary>
        public void ConfigurarModoConsulta(bool soloLectura)
        {
             grpCondicionesBase.Enabled = !soloLectura;
        }

        private void CargarDatosPaciente()
        {
            if (_pacienteActual == null) return;

            if (lblPacienteNombre != null)
                lblPacienteNombre.Text = $"{_pacienteActual.Apellido}, {_pacienteActual.Nombre}";

            if (lblPacienteDni != null)
                lblPacienteDni.Text = $"DNI {_pacienteActual.Dni}";

            if (lblPacienteFecNac != null)
            {
                lblPacienteFecNac.Text = _pacienteActual.FechaNacimiento.HasValue
                    ? _pacienteActual.FechaNacimiento.Value.ToString("dd/MM/yyyy")
                    : "S/D";
            }

            if (lblPacienteTelefono != null)
                lblPacienteTelefono.Text = !string.IsNullOrWhiteSpace(_pacienteActual.Telefono)
                    ? _pacienteActual.Telefono
                    : "Sin teléfono";
        }

        private void CargarMock()
        {
            // Si no creaste las columnas desde el diseñador, se crean acá
            if (dgvHistoriaClinica.Columns.Count == 0)
            {
                dgvHistoriaClinica.Columns.Add("colFecha", "FECHA REGISTRO");
                dgvHistoriaClinica.Columns.Add("colAntecedente", "ANTECEDENTE / CONDICIÓN");
                dgvHistoriaClinica.Columns.Add("colObservacion", "OBSERVACIONES / DETALLE CLÍNICO");
            }

            dgvHistoriaClinica.Rows.Clear();

            // Row 1
            dgvHistoriaClinica.Rows.Add(
                "18/04/2025",
                "⚠ Alergia a Penicilina",
                "Reacción anafiláctica moderada con edema facial y urticaria generalizada."
            );

            // Row 2
            dgvHistoriaClinica.Rows.Add(
                "10/11/2023",
                "Hipertensión Arterial (HTA)",
                "Diagnosticada en guardia clínica. Actualmente en tratamiento con Enalapril 10mg/día."
            );
        }


        private void CargarHistorialAntecedentes()
        {
            dgvHistoriaClinica.Rows.Clear();

            if (_pacienteActual == null || _pacienteActual.Id <= 0) return;

            try
            {
                List<HistoriaClinica> lista = historiaClinicaBLL.ListarPorPaciente(_pacienteActual.Id);

                foreach (var item in lista)
                {
                    dgvHistoriaClinica.Rows.Add(
                        item.FechaAtencion.ToString("dd/MM/yyyy HH:mm"),
                        item.Antecedente,
                        item.Observacion ?? item.Alergias ?? string.Empty
                    );
                }

                dgvHistoriaClinica.ClearSelection();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar antecedentes: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
