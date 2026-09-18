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
    /// <summary>
    /// el form asigna perfiles a usuarios
    /// </summary>
    public partial class AsignarPerfilesUsuarioForm : Form, IIdiomaObserver
    {
        AdministrarPermisosService admPermisosService = new AdministrarPermisosService();
        UsuarioBL usuarioBL = new UsuarioBL();
        // esta variable existe por si cambio el combo de usuarios mientras tenia la informacion de los perfiles del usuario anterior. se modifica al hacer click en buscar usuario y al agregar el perfil
        int usuarioId = 0;
        
        public AsignarPerfilesUsuarioForm()
        {
            InitializeComponent();
            IdiomaService.Suscribir(this);

            if (IdiomaService.TraduccionesActuales != null)
            {
                this.UpdateIdioma(IdiomaService.TraduccionesActuales);
            }
        }

        private void AsignarPerfilesUsuarioForm_Load(object sender, EventArgs e)
        {
            ConfigurarEstilos();
            CargarUsuarios();
        }
        #region Carga de Datos e Inicialización
        private void CargarUsuarios()
        {
             cbUsuarios.DataSource = null;
             cbUsuarios.DataSource = usuarioBL.ObtenerUsuarios();
             cbUsuarios.DisplayMember = "Username"; 
             cbUsuarios.ValueMember = "Id";
             cbUsuarios.SelectedIndex = -1;
        }
        private void ListarPerfilesEnTreeView()
        {
            treeView1.Nodes.Clear();
            List<Perfil> perfilesUsuario = admPermisosService.ObtenerArbolUsuario(usuarioId);

            foreach (var perfil in perfilesUsuario)
            {
                TreeNode nodoRaiz = new TreeNode(perfil.Nombre);
                nodoRaiz.Tag = perfil;
                treeView1.Nodes.Add(nodoRaiz);

                // Si es una familia, disparamos la recursividad polimófica para dibujar sus ramas internas
                if (perfil is Familia familia)
                {
                    CargarHijosEnTreeView(nodoRaiz, familia);
                }
            }

            treeView1.ExpandAll();
        }

        private void CargarHijosEnTreeView(TreeNode nodoPadre, Familia familiaPadre)
        {
            if (!familiaPadre.ObtenerPerfiles().Any())
            {
                List<Perfil> hijosBD = admPermisosService.ObtenerHijosDeFamilia(familiaPadre.Id);
                foreach (var h in hijosBD) familiaPadre.AgregarHijo(h);
            }

            foreach (var hijo in familiaPadre.ObtenerPerfiles())
            {
                TreeNode nodoHijo = new TreeNode(hijo.Nombre);
                nodoHijo.Tag = hijo;
                nodoPadre.Nodes.Add(nodoHijo);

                if (hijo is Familia subFamilia)
                {
                    CargarHijosEnTreeView(nodoHijo, subFamilia);
                }
            }
        }

        #endregion
        #region Eventos de Controles
        private void btnBuscarPerfil_Click(object sender, EventArgs e)
        {
            if (cbUsuarios.SelectedIndex == -1)
            {
                MessageBox.Show("Por favor, seleccione un usuario.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            usuarioId = Convert.ToInt32(cbUsuarios.SelectedValue);
            cbPermisos.DataSource = null;
            List<Perfil> todosLosPerfiles = admPermisosService.ObtenerTodosLosPerfiles(Convert.ToInt32(cbUsuarios.SelectedValue));
            cbPermisos.DataSource = todosLosPerfiles;
            cbPermisos.DisplayMember = "Nombre";
            cbPermisos.ValueMember = "Id";
            // Mostrar el treeview con los perfiles que tiene el usuario
            ListarPerfilesEnTreeView();


        }

        private void btnAgregarPerfil_Click(object sender, EventArgs e)
        {
            if (cbPermisos.SelectedIndex == -1)
            {
                MessageBox.Show("Por favor, seleccione un perfil.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            //Asignar el perfil al usuario
            admPermisosService.AsignarRolAUsuario(usuarioId, Convert.ToInt32(cbPermisos.SelectedValue));

            // Mostrar el treeview con los perfiles que tiene el usuario
            ListarPerfilesEnTreeView();
            // limpio el usuario id
            usuarioId = 0;
        }

        

        private void btnEliminarPerfil_Click(object sender, EventArgs e)
        {
            if (treeView1.SelectedNode == null)
            {
                MessageBox.Show("Por favor, seleccione del árbol el perfil que desea revocarle al usuario.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            TreeNode nodoSeleccionado = treeView1.SelectedNode;

            // Si tiene un Parent (padre) en el árbol, significa que vino adentro de una Familia.
            if (nodoSeleccionado.Parent != null)
            {
                MessageBox.Show("No se puede eliminar este perfil porque no es un permiso padre.", "Operación Inválida", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            Perfil perfilARevocar = (Perfil)nodoSeleccionado.Tag;

            DialogResult confirmacion = MessageBox.Show(
             $"¿Está seguro de que desea revocarle el perfil '{perfilARevocar.Nombre}' al usuario '{cbUsuarios.Text}'?",
             "Confirmar Revocación",
             MessageBoxButtons.YesNo,
             MessageBoxIcon.Question
            );

            if (confirmacion == DialogResult.No) return;

            try
            {
                admPermisosService.QuitarPerfilAUsuario(Convert.ToInt32(cbUsuarios.SelectedValue), perfilARevocar.Id);

                MessageBox.Show($"El perfil '{perfilARevocar.Nombre}' fue revocado con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                btnBuscarPerfil_Click(sender, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al revocar el perfil en la base de datos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
        private void ConfigurarEstilos()
        {
            // ---- CONFIGURACIÓN DE COLORES BASE ----
            Color fondoOscuroPrincipal = Color.FromArgb(27, 38, 49);
            Color fondoContenedores = Color.FromArgb(36, 49, 60);
            Color verdeAguamarina = Color.FromArgb(73, 211, 164);
            Color textoClaro = Color.FromArgb(220, 220, 220);

            // ---- ESTILO DEL FORMULARIO ----
            this.BackColor = fondoOscuroPrincipal;
            this.Font = new Font("Segoe UI", 9.75f);


            // ---- ESTILO DE LABELS ----
            AsignarEstiloLabelsRecursivo(this, Color.FromArgb(236, 240, 241));

            // ---- ESTILO DE COMBOBOXES ----
            // Reemplazá por los nombres de tus combos si son distintos
            var comboList = new List<ComboBox> { cbPermisos, cbUsuarios };
            foreach (var cmb in comboList)
            {
                cmb.BackColor = fondoContenedores;
                cmb.ForeColor = Color.White;
                cmb.FlatStyle = FlatStyle.Flat;
            }

            // ---- ESTILO DEL TREEVIEW ----
            // Reemplazá 'treeView1' por el nombre de tu TreeView
            treeView1.BackColor = fondoContenedores;
            treeView1.ForeColor = Color.White;
            treeView1.LineColor = verdeAguamarina;
            treeView1.BorderStyle = BorderStyle.FixedSingle;

            // ---- ESTILO DE BOTONES PRINCIPALES (VERDES) ----
            // Reemplazá por tus nombres de botones de acción
            var botonesVerdes = new List<Button> { btnBuscarPerfil, btnAgregarPerfil };
            foreach (var btn in botonesVerdes)
            {
                btn.FlatStyle = FlatStyle.Flat;
                btn.BackColor = verdeAguamarina;
                btn.ForeColor = fondoOscuroPrincipal;
                btn.Font = new Font("Segoe UI", 9.75f, FontStyle.Bold);
                btn.FlatAppearance.BorderSize = 0;
            }

            // ---- ESTILO DE BOTÓN ELIMINAR (OSCURO CON BORDE) ----
            btnEliminarPerfil.FlatStyle = FlatStyle.Flat;
            btnEliminarPerfil.FlatAppearance.BorderSize = 1;
            btnEliminarPerfil.FlatAppearance.BorderColor = textoClaro; // Borde fino claro
            btnEliminarPerfil.BackColor = fondoOscuroPrincipal;        // Fondo igual al del formulario
            btnEliminarPerfil.ForeColor = Color.FromArgb(127, 140, 141);    // Texto gris apagado
            btnEliminarPerfil.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
        }

        private void AsignarEstiloLabelsRecursivo(Control contenedor, Color color)
        {
            foreach (Control c in contenedor.Controls)
            {
                if (c is Label lbl)
                {
                    lbl.ForeColor = color; // Forzamos el verde aguamarina
                    lbl.Font = new Font("Segoe UI", 10f, FontStyle.Bold); // Un toque más grueso para que resalte
                }

                // Si el label está dentro de un panel o groupbox, entramos a buscarlo
                if (c.HasChildren)
                {
                    AsignarEstiloLabelsRecursivo(c, color);
                }
            }
        }

       
    }
}
