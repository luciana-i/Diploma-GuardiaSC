using BE;
using BLL;
using BLL.Servicios;
using Seguridad;
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
    public partial class ListadoPacientesForm : Form, IIdiomaObserver
    {
        private List<Consulta> _consultasFiltradas = new List<Consulta>();
        private readonly ConsultaBL _consultaBL = new ConsultaBL();

        PacienteBL pacienteBL = new PacienteBL();

        private List<Paciente> pacientes = new List<Paciente>();

        public ListadoPacientesForm()
        {
            InitializeComponent();

            setearTagDGV();
            dtpFechaAtencion.Value = new DateTime(1900, 1, 1);
            pacientes=pacienteBL.Obtener();

            CargarCombo();

            IdiomaService.Suscribir(this);
            if (IdiomaService.TraduccionesActuales != null)
            {
                this.UpdateIdioma(IdiomaService.TraduccionesActuales);
            }

        }

        private void setearTagDGV()
        {
            colDni.Tag = "PACCOLDNI";
            colPaciente.Tag = "PACCOLPAC";
            colFechaHora.Tag = "PACCOLFECHA";
            colDiagnostico.Tag = "PACCOLDIAG";
            colDestino.Tag = "PACCOLDEST";
            colDocumentos.Tag = "PACCOLDOC";
        }

        private void CargarCombo()
        {
            pacientes.Insert(0, new BE.Paciente
            {
                Id = 0,
                Nombre = "Todos los pacientes",
                Apellido = ""
            });

            cmbPacientes.DataSource = null;
            cmbPacientes.DisplayMember = "NombreCompleto";
            cmbPacientes.ValueMember = "Id";
            cmbPacientes.DataSource = pacientes;

            cmbPacientes.SelectedValue = 0;
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                int? pacienteId = null;
                DateTime fechaSeleccionada;

                bool buscarPorPaciente =
                    dtpFechaAtencion.Value.Date == new DateTime(1900, 1, 1);

                if (buscarPorPaciente)
                {
                    if (cmbPacientes.SelectedValue == null ||
                        Convert.ToInt32(cmbPacientes.SelectedValue) == 0)
                    {
                        MessageBox.Show("Seleccione un paciente para realizar la búsqueda.",
                            "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    pacienteId = Convert.ToInt32(cmbPacientes.SelectedValue);
                    fechaSeleccionada = new DateTime(1900, 1, 1);
                }
                else
                {
                    // Si hay una fecha seleccionada, el paciente es opcional.
                    fechaSeleccionada = dtpFechaAtencion.Value.Date;

                    if (cmbPacientes.SelectedValue != null)
                    {
                        int idSeleccionado = Convert.ToInt32(cmbPacientes.SelectedValue);

                        if (idSeleccionado != 0)
                            pacienteId = idSeleccionado;
                    }
                }

                _consultasFiltradas = _consultaBL.ObtenerPacientesAtendidos(
                    fechaSeleccionada, pacienteId);

                if (_consultasFiltradas.Count == 0)
                {
                    MessageBox.Show(
                        "No se encontraron atenciones finalizadas con los criterios seleccionados.",
                        "Sin resultados", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

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
