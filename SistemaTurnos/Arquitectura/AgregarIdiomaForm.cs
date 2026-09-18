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
    public partial class AgregarIdiomaForm : Form,IIdiomaObserver
    {
        TraduccionBL traduccionBL =new TraduccionBL();
        IdiomaBL idiomaBL = new IdiomaBL();
        List<Traduccion> listaTraducciones = new List<Traduccion>();
        List<Idioma> listaIdiomas = new List<Idioma>();
        private DataTable dtMatriz;
        public AgregarIdiomaForm()
        {
            InitializeComponent();
            IdiomaService.Suscribir(this);
            if (IdiomaService.TraduccionesActuales != null)
            {
                this.UpdateIdioma(IdiomaService.TraduccionesActuales);
            }
        }

        private void AgregarIdioma_Load(object sender, EventArgs e)
        {
            CargarDatos();
           // ConfigurarGrid();
        }
        public void CargarDatos()
        {
            listaIdiomas = idiomaBL.Obtener();
            listaTraducciones = traduccionBL.Listar();



            dtMatriz = new DataTable();
            dtMatriz.Columns.Add("Idioma", typeof(Idioma));

            var etiquetasUnicas = listaTraducciones
                            .Select(t => t.Etiqueta)
                            .Distinct()
                            .OrderBy(e => e)
                            .ToList();

            foreach (var etiqueta in etiquetasUnicas)
            {
                dtMatriz.Columns.Add(etiqueta, typeof(string));
            }

            foreach (var unIdioma in listaIdiomas)
            {
                DataRow fila = dtMatriz.NewRow();

                fila["Idioma"] = unIdioma;

                var traduccionesDelIdioma = listaTraducciones.Where(t => t.Idioma != null && t.Idioma.Id == unIdioma.Id);

                foreach (var trad in traduccionesDelIdioma)
                {
                    if (dtMatriz.Columns.Contains(trad.Etiqueta))
                    {
                        fila[trad.Etiqueta] = trad.Texto;
                    }
                }

                dtMatriz.Rows.Add(fila);
            }
            
            dataGridView1.DataSource = dtMatriz;
            dataGridView1.Columns["Idioma"].Visible = false;

            if (dataGridView1.Columns.Contains("Idioma"))
            {
                dataGridView1.Columns["Idioma"].Frozen = true;
                dataGridView1.Columns["Idioma"].DefaultCellStyle.BackColor = Color.FromArgb(235, 240, 245);
                dataGridView1.Columns["Idioma"].DefaultCellStyle.Font = new Font("Segoe UI", 9f, FontStyle.Bold);
            }

            //// combo
            comboBox1.DataSource = null;
            comboBox1.DataSource = listaIdiomas;
            comboBox1.DisplayMember = "Nombre";
            comboBox1.ValueMember = "Id";
            comboBox1.SelectedIndex = -1;
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox1.Font = new System.Drawing.Font("Segoe UI", 9F);
            comboBox1.SelectedIndex = 0;
        }
        /*
        private void FiltrarColumnasPorPestaña(TabPage paginaActiva)
        {
            // Obtenemos el prefijo de la pestaña activa (ej: "Adm")
            string prefijoClave = paginaActiva.Tag?.ToString();

            if (string.IsNullOrEmpty(prefijoClave)) return;

            // Evitamos el parpadeo de la pantalla suspendiendo el rediseño temporalmente
            dataGridView1.SuspendLayout();

            foreach (DataGridViewColumn columna in dataGridView1.Columns)
            {
                // La columna "Idioma" la dejamos SIEMPRE oculta pase lo que pase
                if (columna.Name == "Idioma")
                {
                    columna.Visible = false;
                    continue;
                }

                // Si la etiqueta empieza con el prefijo de la pestaña (ej: "AdmNombre" empieza con "Adm")
                if (columna.Name.StartsWith(prefijoClave, StringComparison.OrdinalIgnoreCase))
                {
                    columna.Visible = true;
                }
                else
                {
                    columna.Visible = false;
                }
            }

            dataGridView1.ResumeLayout();
        }
        */
        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text))
            {
                MessageBox.Show("Por favor, ingrese el nombre del idioma.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Idioma nuevoIdioma = new Idioma();
            nuevoIdioma.Nombre = textBox1.Text.Trim();

            try 
            {
                nuevoIdioma.Id = idiomaBL.AgregarIdioma(nuevoIdioma);

                listaIdiomas.Add(nuevoIdioma);

                DataRow nuevaFila = dtMatriz.NewRow();

                nuevaFila["Idioma"] = nuevoIdioma;

                foreach (DataColumn columna in dtMatriz.Columns)
                {
                    if (columna.ColumnName != "Idioma")
                    {
                        nuevaFila[columna.ColumnName] = string.Empty;
                    }
                }

                dtMatriz.Rows.Add(nuevaFila);

                textBox1.Clear();

                int indiceUltimaFila = dataGridView1.Rows.Count - 1;
                dataGridView1.CurrentCell = dataGridView1.Rows[indiceUltimaFila].Cells[1]; // Celda de la primera etiqueta visible
                dataGridView1.Focus();

                MessageBox.Show($"Idioma '{nuevoIdioma.Nombre}' agregado. Ya puede escribir las traducciones correspondientes en la grilla.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex) 
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;

            try
            {
                DataGridViewRow filaGrid = dataGridView1.Rows[e.RowIndex];
                DataRowView filaDataView = (DataRowView)filaGrid.DataBoundItem;
                DataRow filaData = filaDataView.Row;
                Idioma idiomaActual = (Idioma)filaData["Idioma"];

                string etiquetaModificada = dataGridView1.Columns[e.ColumnIndex].Name;

                // el texto que el usuario modifico/agrego
                string nuevoTexto = filaGrid.Cells[e.ColumnIndex].Value?.ToString() ?? string.Empty;

                Traduccion traduccionAEditar = new Traduccion(idiomaActual, etiquetaModificada, nuevoTexto);

                bool existe = listaTraducciones.Any(t => t.Idioma != null && 
                                                   t.Idioma.Id == idiomaActual.Id && 
                                                   t.Etiqueta.Equals(etiquetaModificada, StringComparison.OrdinalIgnoreCase));
                
                if (existe)
                {
                    traduccionBL.Actualizar(traduccionAEditar);

                    var tradMemoria = listaTraducciones.First(t => t.Idioma.Id == idiomaActual.Id && t.Etiqueta.Equals(etiquetaModificada, StringComparison.OrdinalIgnoreCase));
                    tradMemoria.Texto = nuevoTexto;
                }
                else
                {
                    traduccionBL.InsertarTraduccion(traduccionAEditar);
                    listaTraducciones.Add(traduccionAEditar);
                }

                MessageBox.Show("Se agrego la traduccion con exito", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"No se pudieron guardar los cambios en la celda: {ex.Message}", "Error al guardar", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

       

        private void button2_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == -1)
            {
                MessageBox.Show("Debe seleccionar idioma a eliminar", "Faltan datos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (SessionManager.getInstance().IdiomaActual == Convert.ToInt32(comboBox1.SelectedValue))
            {
                MessageBox.Show("No puede eliminar el idioma que esta utilizando en este momento", "Faltan datos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult resultado = MessageBox.Show(
             "¿Está seguro de que desea eliminar este idioma de forma permanente? Esta acción no se puede deshacer.",
             "Confirmar Eliminación",
             MessageBoxButtons.YesNo,
             MessageBoxIcon.Warning
             );

            if (resultado == DialogResult.Yes)
            {
                try
                {
                    idiomaBL.EliminarIdioma(Convert.ToInt32(comboBox1.SelectedValue));
                    MessageBox.Show("El idioma ha sido eliminado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    CargarDatos();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ocurrió un error al intentar eliminar: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
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
