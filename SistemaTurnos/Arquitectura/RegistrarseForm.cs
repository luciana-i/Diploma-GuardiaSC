using BE;
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
    /// Creacion de usuarios se le asignan permisos si no el usuario se crea y no puede hacer nada
    /// </summary>
    public partial class RegistrarseForm : Form, IIdiomaObserver
    {
        AdministrarPermisosService admPermisosService = new AdministrarPermisosService();
        public RegistrarseForm()
        {
            InitializeComponent();
            this.Load += new System.EventHandler(this.RegistrarseForm_Load);
            IdiomaService.Suscribir(this);
            if (IdiomaService.TraduccionesActuales != null)
            {
                this.UpdateIdioma(IdiomaService.TraduccionesActuales);
            }

        }
        private UsuarioBL usuarioBL = new UsuarioBL();
        private void RegistrarseForm_Load(object sender, EventArgs e)
        {
            ActualizarTreeViewFamilias();
            //ConfigurarEstilo(); //TODO: ponerle estilos a este form
        }
        #region Carga de Datos e Inicialización de Estructuras
        private void ActualizarTreeViewFamilias()
        {
            treeView1.Nodes.Clear();

            // familias "Raíz" (las que no son hijas de nadie)
            List<Perfil> familiasRaiz = admPermisosService.ObtenerFamiliasRaiz();

            foreach (var f in familiasRaiz)
            {
                TreeNode nodoRaiz = new TreeNode(f.Nombre);
                nodoRaiz.Tag = f;
                treeView1.Nodes.Add(nodoRaiz);

                // cargamos los hijos con info de la base de datos de forma recursiva
                CargarHijosRecursivos(nodoRaiz, (Familia)f);
            }
        }

        private void CargarHijosRecursivos(TreeNode nodoPadre, Familia familiaPadre)
        {
            // Buscamos los hijos de esta familia en la BD 
            List<Perfil> hijos = admPermisosService.ObtenerHijosDeFamilia(familiaPadre.Id);

            foreach (var hijo in hijos)
            {
                familiaPadre.AgregarHijo(hijo);

                TreeNode nodoHijo = new TreeNode(hijo.Nombre);
                nodoHijo.Tag = hijo;
                nodoPadre.Nodes.Add(nodoHijo);

                // Si el hijo es otra familia, se carga de forma recursiva
                if (hijo is Familia subFamilia)
                {
                    CargarHijosRecursivos(nodoHijo, subFamilia);
                }
            }
        }

        #endregion

        // registrarse
        private void button1_Click(object sender, EventArgs e)
        {
            if(treeView1.SelectedNode == null)
            {
                MessageBox.Show("Debe seleccionar un perfil para asignar al usuario nuevo");
                return;
            }

            if (textBox1.Text.Length == 0 || textBox2.Text.Length == 0 || textBox3.Text.Length == 0)
            {
                MessageBox.Show("Debe ingresar usuario, contraseña y mail para continuar");
                return;
            }


            try
            {
                int id = usuarioBL.CrearUsuario(textBox1.Text, textBox2.Text, textBox3.Text);

                Perfil perfilPadre = (Perfil)treeView1.SelectedNode.Tag;
                admPermisosService.AsignarRolAUsuario(id, perfilPadre.Id);

                MessageBox.Show("¡Usuario creado con Exito!", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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

        private void ConfigurarEstilo() /// volver a hacer
        {

            this.BackColor = Color.FromArgb(190, 220, 230);
            this.Size = new Size(450, 500);
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Sistema Sagrado Corazón- Registrarme";


            label3.ForeColor = Color.White;
            label3.Font = new Font("Segoe UI", 16, FontStyle.Bold);

            label4.ForeColor = Color.FromArgb(170, 185, 190);
            label4.Font = new Font("Segoe UI", 9, FontStyle.Regular);

            label1.ForeColor = Color.FromArgb(160, 215, 190);
            label1.Font = new Font("Segoe UI", 9, FontStyle.Bold);

            label2.ForeColor = Color.FromArgb(160, 215, 190);
            label2.Font = new Font("Segoe UI", 9, FontStyle.Bold);


            textBox1.BackColor = Color.FromArgb(43, 54, 59);
            textBox1.ForeColor = Color.FromArgb(160, 215, 190);
            textBox1.Font = new Font("Segoe UI", 11);
            textBox1.BorderStyle = BorderStyle.FixedSingle;

            textBox2.BackColor = Color.FromArgb(43, 54, 59);
            textBox2.ForeColor = Color.FromArgb(160, 215, 190);
            textBox2.Font = new Font("Segoe UI", 11);
            textBox2.BorderStyle = BorderStyle.FixedSingle;
            textBox2.UseSystemPasswordChar = true;


            button1.FlatStyle = FlatStyle.Flat;
            button1.FlatAppearance.BorderSize = 1;
            button1.BackColor = Color.FromArgb(160, 215, 190);
            button1.ForeColor = Color.FromArgb(40, 50, 55);
            button1.FlatAppearance.BorderColor = Color.FromArgb(0, 102, 102);
            button1.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            button1.Cursor = Cursors.Hand;


            this.AcceptButton = button1;
        }
    }
}
