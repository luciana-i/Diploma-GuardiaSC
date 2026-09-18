using BLL;
using BLL.Servicios;
using Seguridad;
using SistemaTurnosUI;
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

    /// <summary>
    /// este form cambia la clave
    /// </summary>
    public partial class CambiarClaveForm : Form, IIdiomaObserver
    {
        private UsuarioBL usuarioBL = new UsuarioBL();

        // Paleta de colores / Estilos globales
        private readonly Color _fondoOscuro = Color.FromArgb(40, 50, 55);
        private readonly Color _fondoInput = Color.FromArgb(60, 70, 75);
        private readonly Color _acentoTurquesa = Color.FromArgb(100, 200, 180);
        private readonly Color _textoBlanco = Color.White;
        private readonly Color _textoGris = Color.FromArgb(180, 180, 180);
        public CambiarClaveForm()
        {
            InitializeComponent();
            // suscripcion y obtener las traducciones segun el idioma
            IdiomaService.Suscribir(this);
            if (IdiomaService.TraduccionesActuales != null)
            {
                this.UpdateIdioma(IdiomaService.TraduccionesActuales);
            }
        }

        #region Eventos del Formulario
        private void CambiarClaveForm_Load(object sender, EventArgs e)
        {
            this.BackColor = _fondoOscuro;
            EnsamblarPanelFondo();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtVieja.Text) || string.IsNullOrWhiteSpace(txtNueva.Text))
            {
                MessageBox.Show("Por favor, complete todos los campos antes de continuar.", "Campos Incompletos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                usuarioBL.ActualizarContraseña(txtVieja.Text, txtNueva.Text);
                MessageBox.Show("Se modificó la contraseña exitosamente", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Cambio de clave con error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.Close();
        }

        #endregion

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

        #region Inicialización y Estilos de Interfaz (UI)
        private void EnsamblarPanelFondo()
        {
            pnlFondo.Name = "panelDarkClave";

            titulolbl.ForeColor = _acentoTurquesa;
            titulolbl.Font = new Font("Segoe UI", 12, FontStyle.Bold);
             

            contActualLbl.ForeColor = _acentoTurquesa;
            contActualLbl.Font = new Font("Segoe UI", 9, FontStyle.Bold);
            contActualLbl.AutoSize = true;

            txtVieja.Size = new Size(310, 25);
            txtVieja.BackColor = _fondoInput;
            txtVieja.ForeColor = _textoBlanco;
            txtVieja.BorderStyle = BorderStyle.FixedSingle;
            txtVieja.Font = new Font("Segoe UI", 11);
            txtVieja.UseSystemPasswordChar = true;

            contNuevaLbl.ForeColor = _acentoTurquesa;
            contNuevaLbl.Font = new Font("Segoe UI", 9, FontStyle.Bold);
            contNuevaLbl.AutoSize = true;

            txtNueva.Size = new Size(310, 25);
            txtNueva.BackColor = _fondoInput;
            txtNueva.ForeColor = _textoBlanco;
            txtNueva.BorderStyle = BorderStyle.FixedSingle;
            txtNueva.Font = new Font("Segoe UI", 11);
            txtNueva.UseSystemPasswordChar = true;

            btnAceptar.Size = new Size(450, 40);
            btnAceptar.BackColor = _acentoTurquesa;
            btnAceptar.ForeColor = _fondoOscuro;
            btnAceptar.FlatStyle = FlatStyle.Flat;
            btnAceptar.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            btnAceptar.Cursor = Cursors.Hand;

            btnCancelar.Size = new Size(450, 40);
            btnCancelar.FlatStyle = FlatStyle.Flat;
            btnCancelar.FlatAppearance.BorderSize = 1;
            btnCancelar.BackColor = Color.Transparent;
            btnCancelar.ForeColor = Color.FromArgb(100, 110, 120);
            btnCancelar.FlatAppearance.BorderColor = Color.FromArgb(180, 185, 190);
            btnCancelar.Font = new Font("Segoe UI", 8, FontStyle.Bold);
            btnCancelar.Cursor = Cursors.Hand;
            btnCancelar.MouseEnter += (s, e) => btnCancelar.Font = new Font("Segoe UI", 9, FontStyle.Underline);
            btnCancelar.MouseLeave += (s, e) => btnCancelar.Font = new Font("Segoe UI", 9, FontStyle.Regular);

        }
        #endregion
    }
}
