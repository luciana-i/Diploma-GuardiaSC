using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaTurnos.Negocio
{
    public partial class AtencionMedicaForm : Form
    {
        public AtencionMedicaForm()
        {
            InitializeComponent();

            // 1. Suscribir el pintado custom de los 3 GroupBoxes para el título con parche
            grpContextoTriage.Paint += GroupBox_CustomPaint;
            grpEvolucionMedica.Paint += GroupBox_CustomPaint;
            grpDestinoAsistencial.Paint += GroupBox_CustomPaint;

            // 2. Redondear los botones al cargar el formulario
            this.Load += (s, e) =>
            {
                RedondearControl(btnFinalizarAtencion, 6);
                RedondearControl(btnVerHistoriaClinica, 4);
            };
        }

        // Dibuja el borde oscuro y el parche de fondo para el texto en verde menta
        private void GroupBox_CustomPaint(object sender, PaintEventArgs e)
        {
            GroupBox box = sender as GroupBox;
            if (box == null) return;

            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            SizeF textSize = g.MeasureString(box.Text, box.Font);
            int topOffset = (int)(textSize.Height / 2);
            Rectangle borderRect = new Rectangle(0, topOffset, box.Width - 1, box.Height - topOffset - 1);

            // Borde oscuro
            using (Pen pen = new Pen(Color.FromArgb(54, 71, 79), 1.2f)) // #36474F
            {
                g.DrawRectangle(pen, borderRect);
            }

            // Parche oscuro para que el título no quede tachado por el borde
            if (!string.IsNullOrEmpty(box.Text))
            {
                Rectangle textBgRect = new Rectangle(15, 0, (int)textSize.Width + 8, (int)textSize.Height);
                using (Brush patchBrush = new SolidBrush(Color.FromArgb(32, 44, 49))) // #202C31
                {
                    g.FillRectangle(patchBrush, textBgRect);
                }

                using (Brush textBrush = new SolidBrush(box.ForeColor))
                {
                    g.DrawString(box.Text, box.Font, textBrush, 18, 0);
                }
            }
        }

        // Aplica esquinas redondeadas suaves
        private void RedondearControl(Control ctrl, int radio)
        {
            if (ctrl == null) return;
            using (GraphicsPath path = new GraphicsPath())
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
    }
}
