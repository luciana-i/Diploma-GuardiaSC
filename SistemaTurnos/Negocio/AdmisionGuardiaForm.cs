using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace SistemaTurnos
{
    public partial class AdmisionGuardiaForm : Form
    {
        public AdmisionGuardiaForm()
        {
            InitializeComponent();
            lblFechaIngresoValor.Text = DateTime.Now.ToString("dd/MM/yyyy - HH:mm") + " hs";

            // 1. Redondeo sutil de botones
            Redondear(btnConfirmarIngreso, 8);
            Redondear(btnCancelar, 8);
            Redondear(btnBuscarPaciente, 8);
            if (btnModificarPaciente != null) Redondear(btnModificarPaciente, 6);
            if (badgeEstado != null) Redondear(badgeEstado, 6);

            // 2. Suscribir el pintado plano oscuro de los GroupBoxes
            pnlIdentificacion.Paint += GroupBox_DarkPaint;
            grpDatosFiliatorios.Paint += GroupBox_DarkPaint;
            pnlEpisodio.Paint += GroupBox_DarkPaint;
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
            this.Close();
        }

    
    }
}