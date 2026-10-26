using BE;
using BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaTurnos.Negocio
{
    public partial class ListadoPacientesForm : Form
    {
        private List<Consulta> _consultasFiltradas = new List<Consulta>();
        private readonly ConsultaBL _consultaBL = new ConsultaBL();

        PacienteBL pacienteBL = new PacienteBL();

        private List<Paciente> pacientes = new List<Paciente>();

        public ListadoPacientesForm()
        {
            InitializeComponent();
            dtpFechaAtencion.Value = DateTime.Today;
            pacientes=pacienteBL.Obtener();
            CargarCombo();

        }

        private void CargarCombo()
        {
           cmbPacientes.DataSource = null;
           cmbPacientes.DataSource = pacientes;
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime fechaSeleccionada = dtpFechaAtencion.Value.Date;

                int? pacienteId = null;
                if (cmbPacientes.SelectedValue != null && int.TryParse(cmbPacientes.SelectedValue.ToString(), out int id) && id > 0)
                {
                    pacienteId = id;
                }

                // La base de datos ya devuelve solo las filas que cumplen los filtros
                _consultasFiltradas = _consultaBL.ObtenerPacientesAtendidos(fechaSeleccionada, pacienteId);

                MostrarEnGrilla(_consultasFiltradas);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al consultar pacientes: {ex.Message}",
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Clic en la columna DOCUMENTOS de la fila seleccionada
        private void dgvPacientes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex < 0) return;

            if (dgvPacientes.Columns[e.ColumnIndex].Name == "colDocumentos")
            {
                if (e.RowIndex < _consultasFiltradas.Count)
                {
                    var consultaSeleccionada = _consultasFiltradas[e.RowIndex];

                    // 1. Instanciamos la BLL que ya configuramos en los pasos anteriores
                    DocumentoClinicoBL docBL = new DocumentoClinicoBL();

                    try
                    {
                       
                        List<DocumentoClinico> documentosEmitidos = docBL.ListarPorConsultaId(consultaSeleccionada.Id);
                      
                        string nombreCompleto = $"{consultaSeleccionada.Paciente?.Apellido}, {consultaSeleccionada.Paciente?.Nombre}";
                        string dni = consultaSeleccionada.Paciente?.Dni;

                        foreach (var docBD in documentosEmitidos)
                        {
                           
                           var docRecuperado = docBL.RecuperarDocumento(docBD.RutaArchivo, docBD);

                           if (docRecuperado != null)
                           {
                               string rutaPdf = docBL.GenerarPdfDocumento(docRecuperado, nombreCompleto, dni);

                                Process.Start(new ProcessStartInfo(rutaPdf) { UseShellExecute = true });
                           }
                        }
                        
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error al recuperar los documentos: {ex.Message}", "Error de Deserialización", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void MostrarEnGrilla(List<Consulta> lista)
        {
            dgvPacientes.Rows.Clear();

            foreach (var item in lista)
            {
                string dni = item.Paciente?.Dni ?? "-";
                string paciente = item.Paciente != null ? $"{item.Paciente.Apellido}, {item.Paciente.Nombre}" : "-";
                string fechaHora = item.FechaIngreso.ToString("dd/MM/yyyy HH:mm") + " hs";
                string diagnostico = item.AtencionMedica?.Diagnostico ?? "Sin registro";
                string destino = "Alta Médica";
                if (item.AtencionMedica != null)
                {
                    switch (item.AtencionMedica.Destino)
                    {
                        case DestinoConsulta.Internacion:
                            destino = "Internación";
                            break;
                        case DestinoConsulta.EstudiosRadiologicos:
                            destino = "Estudios Radiológicos";
                            break;
                        case DestinoConsulta.EstudiosLaboratorio:
                            destino = "Estudios Laboratorio";
                            break;
                        case DestinoConsulta.DerivacionExterna:
                            destino = "Derivación Externa";
                            break;
                        default:
                            destino = "Alta Médica";
                            break;
                    }
                }

                dgvPacientes.Rows.Add(dni, paciente, fechaHora, diagnostico, destino, "📄");
            }

            dgvPacientes.ClearSelection();
        }
    }
}
