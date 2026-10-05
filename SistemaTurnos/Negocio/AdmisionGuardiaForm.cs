using BE;
using BLL;
using BLL.Servicios;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Net;
using System.Windows.Forms;

namespace SistemaTurnos
{
    public partial class AdmisionGuardiaForm : Form
    {

        PacienteBL pacienteBL = new PacienteBL();
        ConsultaBL consultaBL = new ConsultaBL();
        Paciente _paciente = new Paciente();
        public AdmisionGuardiaForm()
        {
            InitializeComponent();
            lblFechaIngresoValor.Text = DateTime.Now.ToString("dd/MM/yyyy - HH:mm") + " hs";

            // 1. Redondeo sutil de botones
            Redondear(btnConfirmarIngreso, 8);
            Redondear(btnLimpiar, 8);
            Redondear(btnBuscarPaciente, 8);
            if (btnModificarPaciente != null) Redondear(btnModificarPaciente, 6);
            if (badgeEstado != null) Redondear(badgeEstado, 6);

            // 2. Suscribir el pintado plano oscuro de los GroupBoxes
            pnlIdentificacion.Paint += GroupBox_DarkPaint;
            grpDatosFiliatorios.Paint += GroupBox_DarkPaint;
            pnlEpisodio.Paint += GroupBox_DarkPaint;

            // BADGE    Estado Neutro / Inicial (Gris)
            badgeEstado.Text = "SIN BUSCAR";
            badgeEstado.BackColor = Color.FromArgb(30, 40, 45);     
            badgeEstado.ForeColor = Color.FromArgb(159, 176, 184);  
        }

        // Dibuja el borde sutil oscuro y el título verde menta del GroupBox
        private void GroupBox_DarkPaint(object sender, PaintEventArgs e)
        {
            GroupBox box = sender as GroupBox;
            if (box == null) return;

            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            SizeF textSize = e.Graphics.MeasureString(box.Text, box.Font);
            int topOffset = (int)(textSize.Height / 2);
            Rectangle borderRect = new Rectangle(0, topOffset, box.Width - 1, box.Height - topOffset - 1);

            // Fondo plano
            using (Brush bgBrush = new SolidBrush(box.BackColor))
                e.Graphics.FillRectangle(bgBrush, 0, 0, box.Width, box.Height);

            // Borde oscuro fino (#36474F)
            using (Pen pen = new Pen(ColorTranslator.FromHtml("#36474F"), 1.2f))
                e.Graphics.DrawRectangle(pen, borderRect);

            // Título con parche de fondo
            if (!string.IsNullOrEmpty(box.Text))
            {
                Rectangle textBg = new Rectangle(12, 0, (int)textSize.Width + 6, (int)textSize.Height);
                using (Brush bgBrush = new SolidBrush(box.BackColor))
                    e.Graphics.FillRectangle(bgBrush, textBg);

                using (Brush textBrush = new SolidBrush(ColorTranslator.FromHtml("#9BD2B9")))
                    e.Graphics.DrawString(box.Text, box.Font, textBrush, 15, 0);
            }
        }

        // Helper genérico para redondear cualquier control
        private void Redondear(Control ctrl, int radio)
        {
            if (ctrl == null) return;
            using (var path = new GraphicsPath())
            {
                int d = radio * 2;
                path.AddArc(0, 0, d, d, 180, 90);
                path.AddArc(ctrl.Width - d, 0, d, d, 270, 90);
                path.AddArc(ctrl.Width - d, ctrl.Height - d, d, d, 0, 90);
                path.AddArc(0, ctrl.Height - d, d, d, 90, 90);
                path.CloseFigure();
                ctrl.Region = new Region(path);
            }
        }

        private void btnCancelar_Click_1(object sender, EventArgs e)
        {
            LimpiarCamposPaciente();
        }

        private void btnBuscarPaciente_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtDni.Text.Trim()))
            {
                MessageBox.Show("Por favor, ingrese un número de DNI.", "Campo Requerido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDni.Focus();
                return;
            }

            try
            {
                _paciente = pacienteBL.ObtenerPorDNI(txtDni.Text.Trim());

                if(_paciente != null)
                {
                    ActualizarBadgeEstado(true);
                    txtNombre.Text = _paciente.Nombre;
                    txtApellido.Text = _paciente.Apellido; 
                    txtTelefono.Text = _paciente.Telefono;
                    if (_paciente.FechaNacimiento.HasValue)
                    {
                        dtpFecNac.Value = _paciente.FechaNacimiento.Value;
                    }
                    btnModificarPaciente.Text = "Modificar Paciente";
                }
                else
                {
                    ActualizarBadgeEstado(false);
                    HabilitarCamposPaciente(true);
                    btnModificarPaciente.Text = "Alta Paciente";
                    txtNombre.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocurrió un error al consultar el paciente: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnModificarPaciente_Click(object sender, EventArgs e)
        {
            if(_paciente != null)
            {
                if (string.IsNullOrWhiteSpace(txtTelefono.Text) || dtpFecNac.Value.Date >= DateTime.Today)
                {
                    MessageBox.Show("Complete el teléfono y la fecha de nacimiento.", "Campo Requerido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtTelefono.Focus();
                    return;
                }

                _paciente.FechaNacimiento = dtpFecNac.Value;
                _paciente.Telefono = txtTelefono.Text.Trim();
                try
                {
                    pacienteBL.ActualizarPaciente(_paciente);
                    MessageBox.Show("Se actualizaron los datos");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ocurrió un error al actualizar el paciente: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            else
            {
                if (string.IsNullOrWhiteSpace(txtDni.Text) ||
                    string.IsNullOrWhiteSpace(txtNombre.Text) ||
                    string.IsNullOrWhiteSpace(txtApellido.Text) ||
                    string.IsNullOrWhiteSpace(txtTelefono.Text) || dtpFecNac.Value.Date >= DateTime.Today)
                {
                    MessageBox.Show("Debe completar todos los datos personales del paciente.", "Campos Incompletos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                _paciente = new Paciente
                {
                    Dni = txtDni.Text.Trim(),
                    Nombre = txtNombre.Text.Trim(),
                    Apellido = txtApellido.Text.Trim(), 
                    FechaNacimiento = dtpFecNac.Value,
                    Telefono = txtTelefono.Text.Trim()
                };
                try
                {
                    pacienteBL.AgregarPaciente(_paciente);
                    HabilitarCamposPaciente(false);
                    MessageBox.Show("Se agrego el nuevo paciente");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ocurrió un error al agregar un paciente: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnConfirmarIngreso_Click(object sender, EventArgs e)
        {
            if (_paciente == null || _paciente.Id <= 0)
            {
                MessageBox.Show("Debe buscar o dar de alta al paciente antes de confirmar el ingreso.", "Paciente Requerido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDni.Focus();
                return;
            }

            string motivo = txtMotivoConsulta.Text.Trim();
            if (string.IsNullOrWhiteSpace(motivo))
            {
                MessageBox.Show("Por favor, ingrese el motivo de consulta del paciente.", "Campo Obligatorio", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMotivoConsulta.Focus();
                return;
            }

            try
            {
                var nuevaConsulta = new Consulta
                {
                    Paciente = _paciente,
                    FechaIngreso = DateTime.Now,
                    MotivoIngreso = motivo,
                    EstadoConsulta = BE.EstadoConsulta.EnEsperaEnfermeria,
                    UsuarioIngreso = SessionManager.getInstance().ObtenerUsuario()
                };
                try
                {
                    consultaBL.AgregarConsulta(nuevaConsulta);
                    MessageBox.Show("Se ingreso la consulta de guardia correctamente");
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ocurrió un error al agregar una consulta: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocurrió un error al agregar un paciente: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

            private void HabilitarCamposPaciente(bool habilitar)
        {
            txtNombre.Enabled = habilitar;
            txtApellido.Enabled = habilitar;
            dtpFecNac.Enabled = habilitar;
            txtTelefono.Enabled = habilitar;
            btnModificarPaciente.Enabled = true;
        }

        private void LimpiarCamposPaciente()
        {
            txtNombre.Clear();
            txtApellido.Clear();
            txtTelefono.Clear();
            dtpFecNac.Value = DateTime.Today;
            _paciente = null;
        }

        private void ActualizarBadgeEstado(bool? estaRegistrado)
        {
            if (badgeEstado == null) return;

            else if (estaRegistrado.Value)
            {
                // Estado Registrado 
                badgeEstado.Text = "✓ REGISTRADO";
                badgeEstado.BackColor = Color.FromArgb(19, 42, 31);      
                badgeEstado.ForeColor = Color.FromArgb(46, 213, 115);   
                badgeEstado.FlatAppearance.BorderColor = Color.FromArgb(30, 107, 65);                                                          
            }
            else
            {
                // Estado No Registrado
                badgeEstado.Text = "⚠ NO REGISTRADO";
                badgeEstado.BackColor = Color.FromArgb(46, 33, 20);      
                badgeEstado.ForeColor = Color.FromArgb(250, 177, 60);    
                badgeEstado.FlatAppearance.BorderColor = Color.FromArgb(180, 100, 20);                                                            
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void lblTelefono_Click(object sender, EventArgs e)
        {

        }
    }
}