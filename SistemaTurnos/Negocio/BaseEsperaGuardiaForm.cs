using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaTurnos.Negocio
{
    public class BaseEsperaGuardiaForm : Form
    {
        // Paleta de colores unificada compartida
        protected readonly Color ColorFondoExterior = ColorTranslator.FromHtml("#BEDAE5");
        protected readonly Color ColorFondoPrincipal = ColorTranslator.FromHtml("#1C252A");

        public BaseEsperaGuardiaForm()
        {
            // Configuración general de la ventana
            this.BackColor = ColorFondoExterior;
            this.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular);
            this.ForeColor = Color.White;
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        // Método compartido para dejar la grilla idéntica en ambas pantallas
        protected void AplicarEstilosGrilla(DataGridView dgv)
        {
            if (dgv == null) return;

            dgv.BackgroundColor = ColorTranslator.FromHtml("#1B252B");
            dgv.BorderStyle = BorderStyle.None;
            dgv.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgv.EnableHeadersVisualStyles = false;
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv.MultiSelect = false;
            dgv.RowHeadersVisible = false;
            dgv.AllowUserToAddRows = false;
            dgv.ReadOnly = true;

            dgv.ColumnHeadersHeight = 38;
            dgv.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#1E4258");
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);

            dgv.DefaultCellStyle.BackColor = ColorTranslator.FromHtml("#1B252B");
            dgv.DefaultCellStyle.ForeColor = ColorTranslator.FromHtml("#F1F5F9");
            dgv.DefaultCellStyle.SelectionBackColor = ColorTranslator.FromHtml("#134E4A");
            dgv.DefaultCellStyle.SelectionForeColor = Color.White;
            dgv.RowTemplate.Height = 42;
        }
    }
}
