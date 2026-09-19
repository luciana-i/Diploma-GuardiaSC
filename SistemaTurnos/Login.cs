using BE;
using BLL.Servicios;
using SistemaTurnos;
using System;
using System.Configuration;
using System.Drawing;
using System.Windows.Forms;
using Seguridad;
using BLL;
using System.Collections.Generic;
using SistemaTurnos.Negocio;

namespace SistemaTurnosUI
{/// <summary>
/// entrada de la app, selecciona idioma y login, CAMBIO! YA NO ESTA SUSCRIPTA AL IDIOMA
/// </summary>
    public partial class Login : Form
    {
        private ComboBox cmbIdiomas;
        private Label lblSeleccioneIdioma;
        private AuthService authService = new AuthService();
        private IdiomaBL IdiomaBL = new IdiomaBL();
        private DVVBL DVVBL = new DVVBL();
        public Login()
        {
            InitializeComponent();
            EvaluarIntegridad();
            
        }

        private void EvaluarIntegridad()
        {
            try
            {
                DVVBL.EvaluarInconsistencia();
            }
            catch(Exception ex) 
            {
                MessageBox.Show(ex.Message, "Falla de Integridad", MessageBoxButtons.OK, MessageBoxIcon.Error);
                
            }
            
             
        }

        private void Login_Load(object sender, EventArgs e)
        {
            ConfigurarEstilo();
            ConfigurarSelectorIdioma();
        }
   

        #region Eventos de Controles (Actions)
        //iniciar sesion
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Length > 0 && textBox2.Text.Length > 0)
            {
                try
                {
                    var result = authService.Login(textBox1.Text, textBox2.Text, Convert.ToInt32(comboBox1.SelectedValue), checkBox1.Checked);
                    ManejarResult(result);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Debe ingresar usuario y contraseña para continuar");
            }
        }

        private void CmbIdiomas_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (cmbIdiomas.SelectedIndex != -1)
            {
                string idiomaSeleccionado = cmbIdiomas.SelectedItem.ToString();
                // cambio idioma segun seleccion
                IdiomaService.CambiarIdioma(Convert.ToInt32(cmbIdiomas.SelectedValue));
                // esconder seleccion y visibilizar el login
                cmbIdiomas.Visible = false;
                panelLogin.Visible = true;
            }

        }

        #endregion
        
        private void ManejarResult(LoginResult result)
        {
            switch (result)
            {
                case LoginResult.Exito:
                    MessageBox.Show("¡Bienvenido al sistema!", "Inicio de Sesión", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Hide();
                    MenuPrincipalForm menuForm = new MenuPrincipalForm();
                    menuForm.ShowDialog();
                    this.Close();
                    break;

                case LoginResult.CredencialesInvalidas:
                    MessageBox.Show("Usuario o contraseña incorrectos. Por favor, intente nuevamente.", "Error de Autenticación", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    textBox2.Clear();
                    textBox2.Focus();
                    break;

                case LoginResult.UsuarioBloqueado:
                    MessageBox.Show("Esta cuenta se encuentra bloqueada por superar el límite de intentos fallidos. Contacte al administrador.", "Cuenta Bloqueada", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    break;

                case LoginResult.UsuarioNoEncontrado:
                    MessageBox.Show("Usuario o contraseña incorrectos.", "Error de Autenticación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
                case LoginResult.IntegridadViolada:
                    MessageBox.Show("Error de Integridad del Sistema" + "\r\n" + "Se ha detectado una inconsistencia en los dígitos verificadores de la base de datos (Tabla: Usuario)." + "\r\n" + "La información ha sido alterada o no coincide con los registros de control esperados (DVH/DVV)." + "\r\\n" + "Por motivos de seguridad, la operación actual ha sido bloqueada. Por favor, contacte al administrador" + "\r\n" + "para recalcular los dígitos verificadores.", "Error de Autenticación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;

                default:
                    MessageBox.Show("Ocurrió un estado inesperado durante el inicio de sesión.", "Error Desconocido", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
            }
        }



        private void ConfigurarSelectorIdioma()
        {
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox1.Font = new Font("Segoe UI", 11);
            comboBox1.Size = new Size(200, 30);

            comboBox1.DataSource = null;
            comboBox1.DataSource = IdiomaBL.Obtener();
            comboBox1.DisplayMember = "Nombre";
            comboBox1.ValueMember = "Id";
            comboBox1.SelectedIndex = -1;
        }


        #region Inicialización y Estilos de Interfaz (UI)
        private void ConfigurarEstilo()
        {
            this.BackColor = Color.FromArgb(190, 220, 230);
            this.Size = new Size(450, 520); 
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.StartPosition = FormStartPosition.CenterScreen;

            panelLogin.BackColor = Color.FromArgb(40, 50, 55);
            panelLogin.Size = new Size(350, 420);
            panelLogin.BorderStyle = BorderStyle.None;

            panelLogin.Location = new Point(
                (this.ClientSize.Width - panelLogin.Width) / 2,
                (this.ClientSize.Height - panelLogin.Height) / 2
            );

            label3.ForeColor = Color.White;
            label3.Font = new Font("Segoe UI", 16, FontStyle.Bold);

            label4.ForeColor = Color.FromArgb(170, 185, 190);
            label4.Font = new Font("Segoe UI", 9, FontStyle.Regular);

            label1.ForeColor = Color.FromArgb(160, 215, 190);
            label1.Font = new Font("Segoe UI", 9, FontStyle.Bold);

            label2.ForeColor = Color.FromArgb(160, 215, 190);
            label2.Font = new Font("Segoe UI", 9, FontStyle.Bold);

            label5.ForeColor = Color.FromArgb(160, 215, 190);
            label5.Font = new Font("Segoe UI", 9, FontStyle.Bold);

            // Entradas de texto
            textBox1.BackColor = Color.FromArgb(43, 54, 59);
            textBox1.ForeColor = Color.FromArgb(160, 215, 190);
            textBox1.Font = new Font("Segoe UI", 11);
            textBox1.BorderStyle = BorderStyle.FixedSingle;

            textBox2.BackColor = Color.FromArgb(43, 54, 59);
            textBox2.ForeColor = Color.FromArgb(160, 215, 190);
            textBox2.Font = new Font("Segoe UI", 11);
            textBox2.BorderStyle = BorderStyle.FixedSingle;
            textBox2.UseSystemPasswordChar = true;

            // Estilo para el ComboBox1 (Selector de idiomas integrado)
            comboBox1.BackColor = Color.FromArgb(43, 54, 59);
            comboBox1.ForeColor = Color.FromArgb(160, 215, 190);
            comboBox1.Font = new Font("Segoe UI", 11);
            comboBox1.FlatStyle = FlatStyle.Flat;

            checkBox1.ForeColor = Color.FromArgb(170, 185, 190);
            checkBox1.Font = new Font("Segoe UI", 9, FontStyle.Regular);
            checkBox1.BackColor = Color.Transparent;

            button1.FlatStyle = FlatStyle.Flat;
            button1.FlatAppearance.BorderSize = 1;
            button1.BackColor = Color.FromArgb(160, 215, 190);
            button1.ForeColor = Color.FromArgb(40, 50, 55);
            button1.FlatAppearance.BorderColor = Color.FromArgb(0, 102, 102);
            button1.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            button1.Cursor = Cursors.Hand;

            this.AcceptButton = button1;
        }
        #endregion

        private void button2_Click(object sender, EventArgs e)
        {
            AdmisionGuardiaForm admisionGuardiaForm = new AdmisionGuardiaForm();
            admisionGuardiaForm.ShowDialog();
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            EvaluacionYClasificacionForm admisionGuardiaForm = new EvaluacionYClasificacionForm();
            admisionGuardiaForm.ShowDialog();
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            PacientesEnfermeriaForm admisionGuardiaForm = new PacientesEnfermeriaForm();
            admisionGuardiaForm.ShowDialog();
            this.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            HistoriaClinicaForm admisionGuardiaForm = new HistoriaClinicaForm();
            admisionGuardiaForm.ShowDialog();
            this.Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            AtencionMedicaForm admisionGuardiaForm = new AtencionMedicaForm();
            admisionGuardiaForm.ShowDialog();
            this.Close();
        }
    }
}
