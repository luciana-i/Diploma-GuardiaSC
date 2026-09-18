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
    /// este form modifica el idioma
    /// </summary>
    public partial class IdiomaForm : Form, IIdiomaObserver
    {
        IdiomaBL idiomaBL = new IdiomaBL();
        public IdiomaForm()
        {
            InitializeComponent();
            IdiomaService.Suscribir(this);
            if (IdiomaService.TraduccionesActuales != null)
            {
                this.UpdateIdioma(IdiomaService.TraduccionesActuales);
            }
        }

        private void IdiomaForm_Load(object sender, EventArgs e)
        {
            CargarTarjetasDeIdioma();
        }

        private void BotonCardIdioma_Click(object sender, EventArgs e)
        {
            Button botonPresionado = (Button)sender;

            int idIdioma = Convert.ToInt32(botonPresionado.Tag);
            IdiomaService.CambiarIdioma(idIdioma);
        }

        #region Carga Dinámica de interfaz
        private void CargarTarjetasDeIdioma()
        {
            flpTarjetas.Controls.Clear();

            List<Idioma> listaIdiomas = idiomaBL.Obtener();

            foreach (Idioma idioma in listaIdiomas)
            {
               
                Button btnCard = new Button();

                btnCard.Text = idioma.Nombre.ToUpper(); 
                btnCard.Size = new Size(160, 100);      
                btnCard.Font = new Font("Segoe UI", 11, FontStyle.Bold);
                btnCard.Cursor = Cursors.Hand;

                btnCard.FlatStyle = FlatStyle.Flat;
                btnCard.BackColor = Color.FromArgb(40, 50, 55); 
                btnCard.ForeColor = Color.FromArgb(160, 215, 190); 
                btnCard.FlatAppearance.BorderSize = 1;
                btnCard.FlatAppearance.BorderColor = Color.FromArgb(160, 215, 190);

                btnCard.Tag = idioma.Id;

                btnCard.Click += BotonCardIdioma_Click;

                flpTarjetas.Controls.Add(btnCard);
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
    }
}
