using BE;
using BLL;
using BLL.Servicios;
using Seguridad;
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
    public partial class HistorialCambiosForm : Form, IIdiomaObserver
    {
        UsuarioBL usuarioBl = new UsuarioBL();
        HistorialBL histBl = new HistorialBL();
        List<Historial> listaHistorial = new List<Historial>();  
        public HistorialCambiosForm()
        {
            InitializeComponent();
            CargarUsuarios();
            IdiomaService.Suscribir(this);
            if (IdiomaService.TraduccionesActuales != null)
            {
                this.UpdateIdioma(IdiomaService.TraduccionesActuales);
            }
        }

        private void CargarUsuarios()
        {
            cbUsuarios.DataSource = null;
            cbUsuarios.DataSource = usuarioBl.ObtenerUsuarios();
            cbUsuarios.DisplayMember = "Username";
            cbUsuarios.ValueMember = "Id";
            cbUsuarios.SelectedIndex = -1;
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (cbUsuarios.SelectedIndex == -1)
            {
                MessageBox.Show("Por favor, seleccione un usuario.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int usuarioId = Convert.ToInt32(cbUsuarios.SelectedValue);

            listaHistorial = histBl.ObtenerPorUsuario(usuarioId);
            CargarDataGridViewHistorial();

        }

        private void CargarDataGridViewHistorial()
        {
            dgvHistorial.DataSource = null; 
            dgvHistorial.DataSource = listaHistorial;

            if (dgvHistorial.Columns.Count > 0)
            {
                dgvHistorial.Columns["Id"].HeaderText = "ID Registro";
                dgvHistorial.Columns["UsuarioID"].HeaderText = "ID Usuario";
                dgvHistorial.Columns["Mail"].HeaderText = "Correo Electrónico";
                dgvHistorial.Columns["Fecha"].HeaderText = "Fecha de Modificación";

                dgvHistorial.Columns["Fecha"].DefaultCellStyle.Format = "dd/MM/yyyy";

                dgvHistorial.Columns["UsuarioID"].Visible = false;
                dgvHistorial.Columns["Id"].Visible = false;
                dgvHistorial.Columns["Mail"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            }
        }

        private void btnCambiar_Click(object sender, EventArgs e)
        {
            if (dgvHistorial.CurrentRow == null)
            {
                MessageBox.Show("Por favor, seleccione una fila del historial.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
           
            try
            {
                Historial historialSeleccionado = (Historial)dgvHistorial.CurrentRow.DataBoundItem;
                usuarioBl.CambiarMailHistorialCambios(historialSeleccionado.UsuarioID, historialSeleccionado.Mail);
                MessageBox.Show("¡Mail cambiado con Exito!", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
           

        }
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


    }
}
