using BE;
using BLL;
using BLL.Servicios;
using Seguridad;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace SistemaTurnos
{
    /// <summary>
    /// el form hace la administracion de los perfiles, crea, edita y elimina (PREGUNTAR)
    /// </summary>
    public partial class AdministrarPerfilesForm : Form, IIdiomaObserver
    {
        AdministrarPermisosService admPermisosService = new AdministrarPermisosService();
        public AdministrarPerfilesForm()
        {
            InitializeComponent();
            CargarTodoElSistemaEnTreeView();
            CargarCombo();
            CargarEstilos();

            IdiomaService.Suscribir(this);
            if (IdiomaService.TraduccionesActuales != null)
            {
                this.UpdateIdioma(IdiomaService.TraduccionesActuales);
            }
        }

        #region Carga de Datos e Inicialización
        private void CargarCombo()
        {
            comboBox1.DataSource = null;
            //obtengo los permisos reales que vincula la bd con los permisos de la app
            comboBox1.DataSource = admPermisosService.ObtenerTagsPermisos();
            comboBox1.SelectedIndex = -1;
        }

        private void CargarTodoElSistemaEnTreeView()
        {
            treeViewPerfilesPosibles.Nodes.Clear();

            try
            {
                List<Perfil> todosLosPerfiles = admPermisosService.ListarPerfiles();

                foreach (var perfil in todosLosPerfiles)
                {
                    TreeNode nodoRaiz = new TreeNode(perfil.Nombre);
                    nodoRaiz.Tag = perfil;
                    treeViewPerfilesPosibles.Nodes.Add(nodoRaiz);

                    if (perfil is Familia familia)
                    {
                        PoblarRamasEstructura(nodoRaiz, familia);
                    }
                }
                treeViewPerfilesPosibles.ExpandAll();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar la estructura general: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void PoblarRamasEstructura(TreeNode nodoVisualPadre, Familia familiaPadre)
        {
            if (!familiaPadre.ObtenerPerfiles().Any())
            {
                List<Perfil> hijosBD = admPermisosService.ObtenerHijosDeFamilia(familiaPadre.Id);
                foreach (var h in hijosBD) familiaPadre.AgregarHijo(h);
            }


            foreach (var hijo in familiaPadre.ObtenerPerfiles())
            {
                TreeNode nodoVisualHijo = new TreeNode(hijo.Nombre);
                nodoVisualHijo.Tag = hijo;
                nodoVisualPadre.Nodes.Add(nodoVisualHijo);

                if (hijo is Familia subFamilia)
                {
                    PoblarRamasEstructura(nodoVisualHijo, subFamilia);
                }
            }
        }
        #endregion


        #region Eventos de Controles (Actions)      

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarIngresos();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (treeViewPerfilesPosibles.SelectedNode == null)
            {
                MessageBox.Show("Por favor, para editar seleccione un perfil de la lista perfiles posibles a elegir. ", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Perfil perfilAEditar = (Perfil)treeViewPerfilesPosibles.SelectedNode.Tag;

            try
            {
                admPermisosService.EditarPerfil(perfilAEditar.Id, textBox1.Text);

                MessageBox.Show("Perfil editado con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                CargarTodoElSistemaEnTreeView();
                LimpiarIngresos();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }
        // copia el nombre en el cuadro de texto para que pueda editarlo o eliminarlo
        private void treeViewPerfilesPosibles_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node == null) return;

            if (e.Node.Tag is Perfil perfilSeleccionado)
            {
                textBox1.Text = perfilSeleccionado.Nombre;
            }
            else
            {
                textBox1.Text = e.Node.Text;
            }
        }

        
        private void btnGuardarPerfil_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtNombre.Text) || (rbFamilia.Checked == false && rbPerfilSimple.Checked == false))
            {
                MessageBox.Show("Debe ingresar Nombre y tipo paracontinuar", "Faltan datos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (comboBox1.SelectedIndex == -1)
            {
                MessageBox.Show("Debe seleccionar el permiso a otorgar", "Faltan datos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            string tagSeleccionado = comboBox1.SelectedItem.ToString();
            string tipo = rbFamilia.Checked ? "Familia" : "Patente";

            admPermisosService.CrearPerfil(txtNombre.Text, tagSeleccionado, tipo);

            CargarTodoElSistemaEnTreeView();

            LimpiarIngresos();
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
        private void LimpiarIngresos()
        {
            textBox1.Clear();
            txtNombre.Clear();
            rbFamilia.Checked = false;
            rbPerfilSimple.Checked = false;
            comboBox1.SelectedIndex = -1;
        }


        #region Estilos de Interfaz (UI)
        private void CargarEstilos()
        {
            // ---- CONFIGURACIÓN DE COLORES BASE ----
            Color fondoOscuroPrincipal = Color.FromArgb(27, 38, 49);
            Color fondoContenedores = Color.FromArgb(36, 49, 60);
            Color verdeAguamarina = Color.FromArgb(73, 211, 164);
            Color textoClaro = Color.FromArgb(220, 220, 220);

            // ---- ESTILO DEL FORMULARIO ----
            this.BackColor = fondoOscuroPrincipal;
            this.Font = new Font("Segoe UI", 9.75f);

            // ---- ESTILO RECURSIVO DE LABELS Y GROUPBOXES ----
            // Forzamos a todos los textos informativos a usar el verde aguamarina
            AsignarEstiloControlesRecursivo(this, verdeAguamarina);

            // ---- ESTILO DE TEXTBOXES ----
            var listaTextBoxes = new List<System.Windows.Forms.TextBox> { textBox1, txtNombre };
            foreach (var txt in listaTextBoxes)
            {
                txt.BackColor = fondoContenedores;
                txt.ForeColor = Color.White;
                txt.BorderStyle = BorderStyle.FixedSingle;
                txt.Font = new Font("Segoe UI", 10f);
            }

            // ---- ESTILO DE CONTENEDORES DE LISTAS (TREEVIEW / LISTBOX) ----
            // Poné acá el control grande blanco que usás para mostrar los perfiles a elegir
            // (Sea un TreeView o un ListBox, va a tomar el mismo estilo oscuro)
            treeViewPerfilesPosibles.BackColor = fondoContenedores;
            treeViewPerfilesPosibles.ForeColor = Color.White;
            if (treeViewPerfilesPosibles is System.Windows.Forms.TreeView tv) tv.LineColor = verdeAguamarina;
            treeViewPerfilesPosibles.BorderStyle = BorderStyle.FixedSingle;

            // ---- ESTILO DE BOTONES PRINCIPALES (ACCIONES DE CARGA/EDICIÓN) ----
            var botonesVerdes = new List<System.Windows.Forms.Button> { btnEditar, btnGuardarPerfil };
            foreach (var btn in botonesVerdes)
            {
                btn.FlatStyle = FlatStyle.Flat;
                btn.BackColor = verdeAguamarina;
                btn.ForeColor = fondoOscuroPrincipal;
                btn.Font = new Font("Segoe UI", 9.75f, FontStyle.Bold);
                btn.FlatAppearance.BorderSize = 0;
            }

            // ---- ESTILO DE BOTONES DE CONTROL (ELIMINAR / LIMPIAR) ----
            // El botón de acción destructiva (Eliminar) y el neutral (Limpiar) van delineados
            var botonesDelineados = new List<System.Windows.Forms.Button> { btnLimpiar };
            foreach (var btn in botonesDelineados)
            {
                btn.FlatStyle = FlatStyle.Flat;
                btn.BackColor = fondoOscuroPrincipal;
                btn.ForeColor = verdeAguamarina;
                btn.Font = new Font("Segoe UI", 9.75f, FontStyle.Bold);
                btn.FlatAppearance.BorderColor = verdeAguamarina;
                btn.FlatAppearance.BorderSize = 1;
            }
        }

        // Función auxiliar para pintar de verde aguamarina todos los Labels, GroupBoxes y RadioButtons del form
        private void AsignarEstiloControlesRecursivo(Control contenedor, Color colorVerde)
        {
            foreach (Control c in contenedor.Controls)
            {
                if (c is Label lbl)
                {
                    lbl.ForeColor = colorVerde;
                    lbl.Font = new Font("Segoe UI", 9.75f, FontStyle.Bold);
                }
                else if (c is GroupBox gb)
                {
                    gb.ForeColor = colorVerde;
                    gb.Font = new Font("Segoe UI", 9.75f, FontStyle.Bold);
                }
                else if (c is RadioButton rb)
                {
                    rb.ForeColor = Color.FromArgb(220, 220, 220); // El texto del radio en blanco suave
                    rb.Font = new Font("Segoe UI", 9.75f, FontStyle.Regular);
                }

                // Si el control tiene hijos (como el GroupBox), entramos a buscar más adentro
                if (c.HasChildren)
                {
                    AsignarEstiloControlesRecursivo(c, colorVerde);
                }
            }
        }
        #endregion
    }
}
