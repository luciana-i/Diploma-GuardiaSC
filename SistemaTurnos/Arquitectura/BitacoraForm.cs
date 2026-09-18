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
    /// Formulario de auditoría que permite visualizar la bitácora con filtros combinados
    /// de Severidad y Nombre de Usuario.
    /// </summary>
    public partial class BitacoraForm : Form, IIdiomaObserver
    {
        private BitacoraBL bitacoraBL = new BitacoraBL();
        private List<Bitacora> DatosListado { get; set; }

        public BitacoraForm()
        {
            InitializeComponent();
        }

        private void BitacoraForm_Load(object sender, EventArgs e)
        {
            CargarDatos();

            cmbFiltro = ConfigurarFiltroSeveridad();
            comboBox1 = ConfigurarFiltroUsername();

            ConfigurarGrid();

            IdiomaService.Suscribir(this);
            if (IdiomaService.TraduccionesActuales != null)
            {
                this.UpdateIdioma(IdiomaService.TraduccionesActuales);
            }
        }

        #region Carga y Inicialización de Filtros

        public void CargarDatos()
        {
            try
            {
                DatosListado = bitacoraBL.ObtenerBitacora();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar la bitácora desde la base de datos: {ex.Message}",
                                "Error de Conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);

                DatosListado = new List<Bitacora>();
            }
        }

        /// <summary>
        /// Configura el ComboBox de filtrado por severidad del log.
        /// </summary>
        private ComboBox ConfigurarFiltroSeveridad()
        {
            cmbFiltro.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbFiltro.Font = new System.Drawing.Font("Segoe UI", 9F);

            cmbFiltro.Items.Clear();
            cmbFiltro.Items.Add("Todos");
            foreach (var name in Enum.GetNames(typeof(SeveridadLog)))
            {
                cmbFiltro.Items.Add(name);
            }
            cmbFiltro.SelectedIndex = 0;

            cmbFiltro.SelectedIndexChanged += (sender, e) => ConfigurarGrid();

            return cmbFiltro;
        }

        /// <summary>
        /// Configura el ComboBox (comboBox1) para filtrar dinámicamente por usuario.
        /// Extrae los usernames únicos presentes en la lista de logs cargada.
        /// </summary>
        private ComboBox ConfigurarFiltroUsername()
        {
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox1.Font = new System.Drawing.Font("Segoe UI", 9F);

            comboBox1.Items.Clear();
            comboBox1.Items.Add("Todos");

            if (DatosListado != null && DatosListado.Count > 0)
            {
                var usernamesUnicos = DatosListado
                    .Where(x => !string.IsNullOrEmpty(x.Usuario_Username))
                    .Select(x => x.Usuario_Username)
                    .Distinct()
                    .OrderBy(name => name);

                foreach (var username in usernamesUnicos)
                {
                    comboBox1.Items.Add(username);
                }
            }

            comboBox1.SelectedIndex = 0;

            comboBox1.SelectedIndexChanged += (sender, e) => ConfigurarGrid();

            return comboBox1;
        }

        #endregion

        #region Configuración, Filtrado Combinado y Formato del DataGridView (UI)

        public void ConfigurarGrid()
        {
            this.StartPosition = FormStartPosition.CenterScreen;
            dgv.AllowUserToAddRows = false;
            dgv.ReadOnly = true;
            dgv.BackgroundColor = System.Drawing.Color.White;
            dgv.RowHeadersVisible = false;
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(245, 247, 250);

            dgv.EnableHeadersVisualStyles = false;
            dgv.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(44, 62, 80);
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.White;
            dgv.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            dgv.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv.ColumnHeadersHeight = 35;


            string seleccionSeveridad = cmbFiltro.SelectedItem?.ToString() ?? "Todos";
            string seleccionUsuario = comboBox1.SelectedItem?.ToString() ?? "Todos";

            IEnumerable<Bitacora> query = DatosListado;

            if (seleccionSeveridad != "Todos")
            {
                query = query.Where(x => x.Severidad.HasValue && x.Severidad.Value.ToString() == seleccionSeveridad);
            }

            if (seleccionUsuario != "Todos")
            {
                query = query.Where(x => x.Usuario_Username == seleccionUsuario);
            }

            dgv.DataSource = query.ToList();

            FormatearColumnas();
        }

        private void FormatearColumnas()
        {
            if (dgv.Columns.Count == 0) return;

            if (dgv.Columns["FechaUTC"] != null) dgv.Columns["FechaUTC"].HeaderText = "Fecha";
            if (dgv.Columns["Usuario_Username"] != null) dgv.Columns["Usuario_Username"].HeaderText = "Usuario";
            if (dgv.Columns["Accion"] != null) dgv.Columns["Accion"].HeaderText = "Acción";
            if (dgv.Columns["Severidad"] != null) dgv.Columns["Severidad"].HeaderText = "Severidad";
            if (dgv.Columns["Mensaje"] != null) dgv.Columns["Mensaje"].HeaderText = "Mensaje";
            if (dgv.Columns["Detalle"] != null) dgv.Columns["Detalle"].Visible = false;
            if (dgv.Columns["Origen"] != null) dgv.Columns["Origen"].HeaderText = "Origen";
            if (dgv.Columns["Host"] != null) dgv.Columns["Host"].HeaderText = "Host";
            if (dgv.Columns["IP"] != null) dgv.Columns["IP"].HeaderText = "Dirección IP";

            dgv.Columns["FechaUTC"].Width = 130;
            dgv.Columns["Usuario_Username"].Width = 90;
            dgv.Columns["Severidad"].Width = 80;
            dgv.Columns["IP"].Width = 90;

            dgv.Columns["Usuario_ID"].Visible = false;
            dgv.Columns["Accion"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgv.Columns["Mensaje"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
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
    }
}