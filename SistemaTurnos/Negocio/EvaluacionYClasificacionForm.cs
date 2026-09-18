using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace SistemaTurnos.Negocio
{
    public partial class EvaluacionYClasificacionForm : Form
    {
        public EvaluacionYClasificacionForm()
        {
            InitializeComponent();

            // 1. Redondeo de botones
            Redondear(btnCalcularPrioridad, 8);
            Redondear(btnConfirmarTriage, 8);
            Redondear(btnCancelar, 8);

            // 2. Suscribir GroupBoxes al pintado oscuro
            grpPacienteEspera.Paint += GroupBox_DarkPaint;
            grpEvaluacionClinica.Paint += GroupBox_DarkPaint;
            grpDeterminacionPrioridad.Paint += GroupBox_DarkPaint;
        }

        // Dibuja el borde plano oscuro y el título verde menta institucional
        private void GroupBox_DarkPaint(object sender, PaintEventArgs e)
        {
            GroupBox box = sender as GroupBox;
            if (box == null) return;

            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            SizeF textSize = e.Graphics.MeasureString(box.Text, box.Font);
            int topOffset = (int)(textSize.Height / 2);
            Rectangle borderRect = new Rectangle(0, topOffset, box.Width - 1, box.Height - topOffset - 1);

            using (Brush bgBrush = new SolidBrush(box.BackColor))
                e.Graphics.FillRectangle(bgBrush, 0, 0, box.Width, box.Height);

            using (Pen pen = new Pen(ColorTranslator.FromHtml("#36474F"), 1.2f))
                e.Graphics.DrawRectangle(pen, borderRect);

            if (!string.IsNullOrEmpty(box.Text))
            {
                Rectangle textBg = new Rectangle(12, 0, (int)textSize.Width + 6, (int)textSize.Height);
                using (Brush bgBrush = new SolidBrush(box.BackColor))
                    e.Graphics.FillRectangle(bgBrush, textBg);

                using (Brush textBrush = new SolidBrush(ColorTranslator.FromHtml("#9BD2B9")))
                    e.Graphics.DrawString(box.Text, box.Font, textBrush, 15, 0);
            }
        }

        // Helper para esquinas redondeadas
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

        // Dibuja los círculos de color oficiales del semáforo de triage en el desplegable
        private void cmbPrioridadFinal_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index < 0) return;

            ComboBox cmb = (ComboBox)sender;
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            bool isSelected = (e.State & DrawItemState.Selected) == DrawItemState.Selected;
            Color bgFondo = isSelected ? ColorTranslator.FromHtml("#2E4A56") : ColorTranslator.FromHtml("#1E282D");

            using (Brush brushBg = new SolidBrush(bgFondo))
                e.Graphics.FillRectangle(brushBg, e.Bounds);

            Color[] coloresTriage = {
                ColorTranslator.FromHtml("#EF4444"), // 1. Rojo
                ColorTranslator.FromHtml("#F97316"), // 2. Naranja
                ColorTranslator.FromHtml("#EAB308"), // 3. Amarillo
                ColorTranslator.FromHtml("#10B981"), // 4. Verde
                ColorTranslator.FromHtml("#3B82F6")  // 5. Azul
            };

            Color colorNivel = (e.Index < coloresTriage.Length) ? coloresTriage[e.Index] : Color.Gray;

            // Círculo indicador
            int circleSize = 10;
            int circleY = e.Bounds.Y + (e.Bounds.Height - circleSize) / 2;
            using (Brush brushCircle = new SolidBrush(colorNivel))
                e.Graphics.FillEllipse(brushCircle, e.Bounds.X + 8, circleY, circleSize, circleSize);

            // Texto
            using (Brush brushText = new SolidBrush(ColorTranslator.FromHtml("#F1F5F9")))
                e.Graphics.DrawString(cmb.Items[e.Index].ToString(), cmb.Font, brushText, e.Bounds.X + 24, e.Bounds.Y + 3);
        }

    }
}