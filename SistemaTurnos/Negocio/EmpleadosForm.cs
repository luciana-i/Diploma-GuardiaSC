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

namespace SistemaTurnos.Negocio
{
    public partial class EmpleadosForm : Form
    {
        private Empleado _empleadoActual;
        private readonly EmpleadoBL _empleadoBL;
        private readonly UsuarioBL _usuarioBL;
        public EmpleadosForm()
        {
            InitializeComponent();
            _empleadoBL = new EmpleadoBL();
            _usuarioBL = new UsuarioBL();

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if(!ValidarCamposObligatorios()) return;

            try
            {
                // Si es nulo, es un Alta. Si ya existe, es Modificación.
                bool esNuevo = false;
                if (_empleadoActual == null)
                {
                    _empleadoActual = new Empleado();
                    esNuevo = true;
                }

                // Mapear de la UI a la Entidad
                _empleadoActual.Dni = txtDni.Text.Trim();
                _empleadoActual.Nombre = txtNombre.Text.Trim();
                _empleadoActual.Apellido = txtApellido.Text.Trim();
                _empleadoActual.FechaNacimiento = dtpFecNac.Value;
                _empleadoActual.Telefono = txtTelefono.Text.Trim();

                _empleadoActual.TipoEmpleado = (TipoEmpleadoEnum)cmbTipoEmpleado.SelectedItem;
                _empleadoActual.Matricula = txtMatricula.Text.Trim();
                _empleadoActual.Activo = chkActivo.Checked;

                // Asignar el usuario solo si seleccionó uno real (Id > 0)
                int usuarioId = (int)cmbUsuario.SelectedValue;
                _empleadoActual.EmpleadoUsuario = usuarioId > 0 ? new Usuario { Id = usuarioId } : null;

                // Enviar a la capa de negocio
                if (esNuevo)
                {
                    _empleadoBL.Agregar(_empleadoActual);
                    MessageBox.Show("Empleado registrado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    _empleadoBL.Actualizar(_empleadoActual);
                    MessageBox.Show("Empleado actualizado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocurrió un error al guardar: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool ValidarCamposObligatorios()
        {
            if (string.IsNullOrWhiteSpace(txtDni.Text) ||
                 string.IsNullOrWhiteSpace(txtNombre.Text) ||
                 string.IsNullOrWhiteSpace(txtApellido.Text))
            {
                MessageBox.Show("DNI, Nombre y Apellido son campos obligatorios.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            var tipoSeleccionado = (TipoEmpleadoEnum)cmbTipoEmpleado.SelectedItem;
            if ((tipoSeleccionado == TipoEmpleadoEnum.Medico ) &&
                string.IsNullOrWhiteSpace(txtMatricula.Text))
            {
                MessageBox.Show("El personal médico y de enfermería debe ingresar una matrícula obligatoriamente.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        private void pnlMainContainer_Paint(object sender, PaintEventArgs e)
        {
            CargarCombos();

            if (_empleadoActual != null)
            {
                CargarDatosEnPantalla();
                this.Text = "Modificación de Empleado";
            }
            else
            {
                this.Text = "Alta de Empleado";
                chkActivo.Checked = true; // Por defecto activo al dar de alta
            }
        }

        private void CargarCombos()
        {
            // 1. Cargar Enum de TipoEmpleado (usando tipado fuerte)
            cmbTipoEmpleado.DataSource = Enum.GetValues(typeof(TipoEmpleadoEnum));

            // 2. Cargar Usuarios desde BLL
            try
            {
                var listaUsuarios = _usuarioBL.ObtenerUsuarios();

                // Opción en blanco por si el empleado no tiene usuario de sistema
                listaUsuarios.Insert(0, new Usuario { Id = 0, Username = "-- Sin Usuario --" });

                cmbUsuario.DataSource = listaUsuarios;
                cmbUsuario.DisplayMember = "Username";
                cmbUsuario.ValueMember = "Id";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar usuarios: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarDatosEnPantalla()
        {
            txtDni.Text = _empleadoActual.Dni;
            txtNombre.Text = _empleadoActual.Nombre;
            txtApellido.Text = _empleadoActual.Apellido;

            if (_empleadoActual.FechaNacimiento.HasValue)
                dtpFecNac.Value = _empleadoActual.FechaNacimiento.Value;

            txtTelefono.Text = _empleadoActual.Telefono;

            // Datos propios de Empleado
            cmbTipoEmpleado.SelectedItem = _empleadoActual.TipoEmpleado;
            txtMatricula.Text = _empleadoActual.Matricula;
            chkActivo.Checked = _empleadoActual.Activo;

            if (_empleadoActual.EmpleadoUsuario != null)
                cmbUsuario.SelectedValue = _empleadoActual.EmpleadoUsuario.Id;
            else
                cmbUsuario.SelectedValue = 0;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
