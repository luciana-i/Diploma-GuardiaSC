using BLL;
using BLL.Servicios;
using Seguridad;
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
    public partial class ModificarMailForm : Form, IIdiomaObserver
    {
        HistorialBL historialBL = new HistorialBL();
        public ModificarMailForm()
        {
            InitializeComponent();
            txtNombre.Text = SessionManager.getInstance().ObtenerUsuario().Username;
            IdiomaService.Suscribir(this);
            if (IdiomaService.TraduccionesActuales != null)
            {
                this.UpdateIdioma(IdiomaService.TraduccionesActuales);
            }
        }

        private void btnCambiar_Click(object sender, EventArgs e)
        {
            if (txtMail.Text.Length == 0) 
            { 
                MessageBox.Show("Debe completar el mail para poder agregar uno nuevo");
            }

            try
            {
                historialBL.Insertar(txtMail.Text);
                MessageBox.Show("Mail modificado exitosamente!", "Operacion realizada", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            
        }
        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
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
