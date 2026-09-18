using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace SistemaTurnos
{
    public class DarkGroupBox : Panel
    {
        public Color BorderColor { get; set; } = ColorTranslator.FromHtml("#36474F");
        public Color TitleColor { get; set; } = ColorTranslator.FromHtml("#9BD2B9");
        public int BorderRadius { get; set; } = 14; // Curvatura visible y moderna

        public DarkGroupBox()
        {
            this.DoubleBuffered = true;
            this.SetStyle(ControlStyles.UserPaint |
                          ControlStyles.AllPaintingInWmPaint |
                          ControlStyles.OptimizedDoubleBuffer |
                          ControlStyles.ResizeRedraw, true);

            this.BackColor = ColorTranslator.FromHtml("#263339");
            this.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            this.ForeColor = TitleColor;
            this.Padding = new Padding(16, 32, 16, 16); // Deja 32px arriba para que el título respire
        }

        protected override void OnResize(EventArgs eventargs)
        {
            base.OnResize(eventargs);
            ActualizarRegionRedondeada();
        }

        private void ActualizarRegionRedondeada()
        {
            if (this.Width <= 0 || this.Height <= 0) return;
            using (GraphicsPath path = CrearRutaRedondeada(new Rectangle(0, 0, this.Width, this.Height), BorderRadius))
            {
                // Esto recorta físicamente las 4 esquinas del control
                this.Region = new Region(path);
            }
            this.Invalidate();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.PixelOffsetMode = PixelOffsetMode.HighQuality;

            Rectangle rect = new Rectangle(0, 0, this.Width - 1, this.Height - 1);

            // 1. Relleno y borde redondeado
            using (GraphicsPath path = CrearRutaRedondeada(rect, BorderRadius))
            {
                using (Brush bg = new SolidBrush(this.BackColor))
                {
                    g.FillPath(bg, path);
                }

                using (Pen pen = new Pen(BorderColor, 1.4f))
                {
                    g.DrawPath(pen, path);
                }
            }

            // 2. Título interno elegante
            if (!string.IsNullOrEmpty(this.Text))
            {
                using (Brush textBrush = new SolidBrush(TitleColor))
                {
                    g.DrawString(this.Text, this.Font, textBrush, 18, 12);
                }
            }
        }

        private GraphicsPath CrearRutaRedondeada(Rectangle r, int radio)
        {
            int d = radio * 2;
            GraphicsPath path = new GraphicsPath();
            path.AddArc(r.X, r.Y, d, d, 180, 90);
            path.AddArc(r.Right - d, r.Y, d, d, 270, 90);
            path.AddArc(r.Right - d, r.Bottom - d, d, d, 0, 90);
            path.AddArc(r.X, r.Bottom - d, d, d, 90, 90);
            path.CloseFigure();
            return path;
        }
    }
}