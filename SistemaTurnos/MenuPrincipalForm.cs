using BE;
using BLL;
using BLL.Servicios;
using Seguridad;
using SistemaTurnos.Negocio;
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
{/// <summary>
/// menu principal
/// </summary>
    public partial class MenuPrincipalForm : Form, IIdiomaObserver
    {

        private AuthService authService = new AuthService();
        private UsuarioBL usuarioBL = new UsuarioBL();
        private DVVBL dVVBL = new DVVBL();
        public MenuPrincipalForm( )
        {
            InitializeComponent();
            IdiomaService.Suscribir(this);
            CargarPermisosUser();
            this.WindowState = FormWindowState.Maximized;

        }
        #region Gestión de Permisos y Seguridad

        private void CargarPermisosUser()
        {
            Usuario usuario= SessionManager.getInstance().ObtenerUsuario();
            if (this.menuStrip1 != null)
            {
                EvaluarPermisosMenu(this.menuStrip1.Items, usuario);
            }
        }

        private void EvaluarPermisosMenu(ToolStripItemCollection items, object usuarioActual)
        {
            foreach (ToolStripItem item in items)
            {
                if (item is ToolStripSeparator) continue;

                
                bool esMenuPadre = item is ToolStripMenuItem menuPrincipal && menuPrincipal.HasDropDownItems;

                if (item.Tag != null && !string.IsNullOrEmpty(item.Tag.ToString()))
                {
                    string tagControl = item.Tag.ToString();

                    if (esMenuPadre)
                    {

                        item.Enabled = true;
                    }
                    else
                    {

                        item.Enabled = SessionManager.getInstance().ObtenerUsuario().TienePermiso(tagControl);
                    }
                }
                else
                {
                    // queda habilitado
                    item.Enabled = true;
                }

                // recursivo para recorrer todo el menu
                if (esMenuPadre)
                {
                    ToolStripMenuItem menuPadre = (ToolStripMenuItem)item;
                    EvaluarPermisosMenu(menuPadre.DropDownItems, SessionManager.getInstance().ObtenerUsuario());
                }
            }
        }
        #endregion


        #region Eventos del Formulario
        private void MenuForm_Load(object sender, EventArgs e)
        {
            this.BackColor = Color.FromArgb(190, 220, 230);
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.menuStrip1.RenderMode = ToolStripRenderMode.System;
            this.menuStrip1.BackColor = SystemColors.Control;
            this.menuStrip1.Padding = new Padding(6, 6, 6, 6);
            this.menuStrip1.Font = new Font("Segoe UI", 9F, FontStyle.Regular);
            IdiomaService.CambiarIdioma(SessionManager.getInstance().IdiomaActual);
            EvaluarInconsistencia();
        }

        private bool EvaluarInconsistencia()
        {
            // si es admin y hay inconsistencia
            if(SessionManager.getInstance().ObtenerUsuario() !=null && SessionManager.getInstance().ObtenerUsuario().listaReadonlyPerfiles.Any(x=> x.Tag.Equals("ADMIN_FULL")) && SessionManager.getInstance().IntegridadBaseDatos)
            {
                DialogResult resultado = MessageBox.Show(
                "Error de Integridad del Sistema" + "\r\n" + "Se ha detectado una inconsistencia en los dígitos verificadores de la base de datos (Tabla: Usuario). Debe subsanarla para continuar", 
                    "Inconsistencia de Datos",                                                              
                    MessageBoxButtons.YesNo,                                                            
                    MessageBoxIcon.Warning                                                                 
                    );

                if (resultado == DialogResult.Yes)
                {
                   // dVVBL.RestaurarIntegridad();
                    MessageBox.Show("Se restaurara la integridad de la base de datos");
                    return true; 
                }
                else
                {
                    return false;
                }
            }
            return true;
        }

        private void cerrarSesionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CerrarFormulario();
            
        }

        private void CerrarFormulario()
        {
            if (!EvaluarInconsistencia())
            {
                MessageBox.Show("Debe corregir el error de integridad para que otros usuarios puedan utilizar la aplicacion", "Desconectarse", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {

                authService.Logout();
                MessageBox.Show("Se desconecto exitosamente", "Desconectado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Hide();
                Login menu = new Login();
                menu.ShowDialog();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Desconectarse", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void bitacoraToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            BitacoraForm bitacoraForm = new BitacoraForm();
            bitacoraForm.MdiParent = this;
            bitacoraForm.Show();
        }

        private void cambiarClaveToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            CambiarClaveForm cambiarClave = new CambiarClaveForm();
            cambiarClave.MdiParent = this;
            cambiarClave.Show();
        }

        private void seleccionarIdiomaToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            IdiomaForm idiomaForm = new IdiomaForm();
            idiomaForm.Show();
        }


        private void desbloqueoDeUsuarioToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Pronto", "Pronto", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void restaurarIntegridadToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            EvaluarInconsistencia();
        }

        private void crearUsuariosToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            RegistrarseForm menu = new RegistrarseForm();
            menu.MdiParent = this;
            menu.Show();
        }

        private void gestionarPerfilesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AdministrarPerfilesForm eliminarPerfiles = new AdministrarPerfilesForm();
            eliminarPerfiles.MdiParent = this;
            eliminarPerfiles.Show();
        }

        private void asignarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GestionPerfilForm perfilForm = new GestionPerfilForm();
            perfilForm.MdiParent = this;
            perfilForm.Show();
        }

        private void asignarPerfilesAUsuarioToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            AsignarPerfilesUsuarioForm perfilForm = new AsignarPerfilesUsuarioForm();
            perfilForm.MdiParent = this;
            perfilForm.Show();
        }

        private void gestionarIdiomaToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            AgregarIdiomaForm perfilForm = new AgregarIdiomaForm();
            perfilForm.MdiParent = this;
            perfilForm.Show();
        }

        private void restaurarMailAnteriorToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            HistorialCambiosForm histForm = new HistorialCambiosForm();
            histForm.MdiParent = this;
            histForm.Show();
        }

        private void modificarMailToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ModificarMailForm modificarMail = new ModificarMailForm();
            modificarMail.MdiParent = this;
            modificarMail.Show();
        }

        private void MenuPrincipalForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.ContainsFocus) // importante, si no pongo esto se ejecuta siempre que se cierra un formulario
            {
                CerrarFormulario();
            }
         
        }

        #endregion

        #region Implementación del Patrón Observer (IIdiomaObserver)
        public void UpdateIdioma(Dictionary<string, string> traducciones)
        {
            if (this.Tag != null && traducciones.ContainsKey(this.Tag.ToString()))
            {
                this.Text = traducciones[this.Tag.ToString()];
            }
            // el menu tiene botones
            TraducirControlesRecursivo(this, traducciones);

            if (this.MainMenuStrip != null)
            {   // el menu tiene submenus
                TraducirMenuStripRecursivo(this.MainMenuStrip.Items, traducciones);
            }
        }
        private void TraducirMenuStripRecursivo(ToolStripItemCollection items, Dictionary<string, string> traducciones)
        {
            foreach (ToolStripItem item in items)
            {
                if (item.Tag != null && traducciones.ContainsKey(item.Tag.ToString()))
                {
                    item.Text = traducciones[item.Tag.ToString()];
                }

                if (item is ToolStripMenuItem menuPrincipal)
                {
                    if (menuPrincipal.HasDropDownItems)
                    {
                        TraducirMenuStripRecursivo(menuPrincipal.DropDownItems, traducciones);
                    }
                }
            }
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

        private void administradorToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void admisionGuardiaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AdmisionGuardiaForm admisionGuardiaForm = new AdmisionGuardiaForm();
            admisionGuardiaForm.MdiParent = this;
            admisionGuardiaForm.Show();
        }

        private void listaEsperaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BandejaEnfermeriaForm bEnfermeria = new BandejaEnfermeriaForm();
            bEnfermeria.MdiParent = this;
            bEnfermeria.Show();
        }

        private void listaEsperaToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            BandejaMedicaForm admisionGuardiaForm = new BandejaMedicaForm();
            admisionGuardiaForm.MdiParent = this;
            admisionGuardiaForm.Show();
        }
        private void agregarEmpleadosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EmpleadosForm eForm = new EmpleadosForm();
            eForm.MdiParent = this;
            eForm.Show();
        }
    }
}
