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
    public partial class HistoriaClinicaForm : Form
    {
        public HistoriaClinicaForm()
        {
            InitializeComponent();
            CargarMock();
        }

        

        private void CargarMock()
        {
            // Si no creaste las columnas desde el diseñador, se crean acá
            if (dgvHistoriaClinica.Columns.Count == 0)
            {
                dgvHistoriaClinica.Columns.Add("colFecha", "FECHA REGISTRO");
                dgvHistoriaClinica.Columns.Add("colAntecedente", "ANTECEDENTE / CONDICIÓN");
                dgvHistoriaClinica.Columns.Add("colObservacion", "OBSERVACIONES / DETALLE CLÍNICO");
            }

            dgvHistoriaClinica.Rows.Clear();

            // Row 1
            dgvHistoriaClinica.Rows.Add(
                "18/04/2025",
                "⚠ Alergia a Penicilina",
                "Reacción anafiláctica moderada con edema facial y urticaria generalizada."
            );

            // Row 2
            dgvHistoriaClinica.Rows.Add(
                "10/11/2023",
                "Hipertensión Arterial (HTA)",
                "Diagnosticada en guardia clínica. Actualmente en tratamiento con Enalapril 10mg/día."
            );
        }

      

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
