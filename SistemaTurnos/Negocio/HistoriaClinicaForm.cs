using BE;
using BLL;
using BLL.Servicios;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
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
        List<AtencionMedica> lista;
        HistoriaClinica historiaClinica;
        public HistoriaClinicaForm(Paciente paciente)
        {
            InitializeComponent();
            _pacienteActual = paciente;
            CargarHistorialAntecedentes();
            CargarHistorialAntecedentesClinicos();
            CargarDatosPaciente();
           
            Usuario usuario = new UsuarioBL().ObtenerPermisos(SessionManager.getInstance().ObtenerUsuario());
            if (usuario.TienePermiso("MEDICO"))
            {
                ConfigurarModoConsulta(true);
            }
            else
            {
                ConfigurarModoConsulta(false);
            }

            
        }

        private void CargarHistorialAntecedentesClinicos()
        {
            historiaClinica = historiaClinicaBLL.ObtenerPorPaciente(_pacienteActual.Id);

            txtAlergias.Text = historiaClinica?.Alergias ?? string.Empty;
            txtAntecedente.Text = historiaClinica?.Antecedente ?? string.Empty;
            txtObservacion.Text = historiaClinica?.Observacion ?? string.Empty;
        }

        /// <summary>
        /// Oculta el panel/grupo de agregar antecedentes si entra un enfermero en modo solo lectura.
        /// </summary>
        public void ConfigurarModoConsulta(bool soloLectura)
        {
             grpCondicionesBase.Enabled = soloLectura;
        }

        private void CargarDatosPaciente()
        {
            lblPacienteNombre.Text = _pacienteActual.NombreCompleto;
            lblPacienteDni.Text = _pacienteActual.Dni;
            lblPacienteFecNac.Text = _pacienteActual.FechaNacimiento.ToString();
            lblPacienteTelefono.Text = _pacienteActual.Telefono;
        }

        private void CargarHistorialAntecedentes()
        {
            dgvAtencionMedicas.Rows.Clear();

            if (_pacienteActual == null || _pacienteActual.Id <= 0) return;

            try
            {
                lista =  new AtencionMedicaBL().ObtenerAtencionesMedicasPorPaciente(_pacienteActual.Id);

                foreach (var item in lista)
                {
                    dgvAtencionMedicas.Rows.Add(
                        item.FechaInicio.ToString("dd/MM/yyyy HH:mm"),
                        item.Diagnostico,
                        item.Indicaciones,
                        item.Destino 
                    );
                }

                dgvAtencionMedicas.ClearSelection();
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

        private void btnGuardarCondiciones_Click(object sender, EventArgs e)
        {
            if(txtAlergias.Text == null || txtAntecedente == null || txtObservacion== null)
            {
                MessageBox.Show("Debe completar los campos de antecedentes");
                return;
            }
           
            HistoriaClinica hClinica = new HistoriaClinica(_pacienteActual, txtAntecedente.Text, txtAlergias.Text, txtObservacion.Text);
            try
            {
                if (historiaClinicaBLL.ObtenerPorPaciente(_pacienteActual.Id)==null)
                {
                    historiaClinicaBLL.Insertar(hClinica);
                }else
                {
                    historiaClinicaBLL.Actualizar(hClinica);
                }
                MessageBox.Show("Se agregaron los antecedentes del paciente");

            }
            catch (Exception ex )
            {
                MessageBox.Show("Hubo un error al ingresar la historia clinica"+  ex.Message);
                return;
            }
            

        }
    }
}
