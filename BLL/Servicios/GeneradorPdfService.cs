using BE;
using PdfSharp.Drawing;
using PdfSharp.Drawing.Layout;
using PdfSharp.Pdf;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Servicios
{
    public class GeneradorPdfService
    {
        public static string GenerarPdf(PdfDocumento modelo)
        {
            // 1. Crear directorios y nombre
            string carpetaDestino = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, modelo.SubCarpeta);
            if (!Directory.Exists(carpetaDestino))
                Directory.CreateDirectory(carpetaDestino);

            string nombreArchivo = $"{modelo.PrefijoArchivo}_{DateTime.Now:yyyyMMdd_HHmmss}_{Guid.NewGuid().ToString().Substring(0, 5)}.pdf";
            string rutaCompleta = Path.Combine(carpetaDestino, nombreArchivo);

            // 2. Armar el documento
            using (var doc = new PdfDocument())
            {
                doc.Info.Title = modelo.Subtitulo;

                // Formato A5 institucional
                PdfPage page = doc.AddPage();
                page.Size = PdfSharp.PageSize.A5;

                using (XGraphics gfx = XGraphics.FromPdfPage(page))
                {
                    // Tipografías
                    var fontTitulo = new XFont("Arial", 12);
                    var fontSub = new XFont("Arial", 9);
                    var fontLabel = new XFont("Arial", 9);
                    var fontValor = new XFont("Arial", 9);

                    var penSeparador = new XPen(XColors.LightGray, 1);

                    // Formateador para que los textos largos bajen de renglón solos
                    var textFormatter = new XTextFormatter(gfx);

                    double y = 30;
                    double margenIzq = 30;
                    double anchoMax = page.Width - (margenIzq * 2);

                    // Encabezado
                    gfx.DrawString(modelo.TituloInstitucional, fontTitulo, XBrushes.DarkSlateGray, new XRect(0, y, page.Width, 20), XStringFormats.TopCenter);
                    y += 22;

                    if (!string.IsNullOrWhiteSpace(modelo.Subtitulo))
                    {
                        gfx.DrawString(modelo.Subtitulo.ToUpper(), fontSub, XBrushes.Gray, new XRect(0, y, page.Width, 18), XStringFormats.TopCenter);
                        y += 25;
                    }

                    // Grilla Clave/Valor (Metadatos)
                    if (modelo.Metadatos != null)
                    {
                        foreach (var kvp in modelo.Metadatos)
                        {
                            gfx.DrawString(kvp.Key, fontLabel, XBrushes.Black, margenIzq, y);
                            gfx.DrawString(kvp.Value, fontValor, XBrushes.Black, margenIzq + 90, y);
                            y += 16;
                        }
                    }

                    // Línea divisoria
                    y += 6;
                    gfx.DrawLine(penSeparador, margenIzq, y, page.Width - margenIzq, y);
                    y += 14;

                    // Secciones (Diagnóstico, Indicaciones)
                    if (modelo.Secciones != null)
                    {
                        foreach (var sec in modelo.Secciones)
                        {
                            gfx.DrawString(sec.Titulo, fontLabel, XBrushes.Black, margenIzq, y);
                            y += 14;

                            string contenido = string.IsNullOrWhiteSpace(sec.Contenido) ? "Sin registro" : sec.Contenido;

                            // Se define un recuadro imaginario para que el texto haga word-wrap automático
                            var rectTexto = new XRect(margenIzq, y, anchoMax, page.Height - y - 60);
                            textFormatter.DrawString(contenido, fontValor, XBrushes.Black, rectTexto, XStringFormats.TopLeft);

                            // Espaciado fijo entre secciones para evitar solapamientos
                            y += 50;
                        }
                    }

                    // Firma al pie
                    if (!string.IsNullOrWhiteSpace(modelo.PieFirma))
                    {
                        y = page.Height - 60;
                        gfx.DrawLine(penSeparador, page.Width - 190, y, page.Width - margenIzq, y);
                        gfx.DrawString(modelo.PieFirma, fontValor, XBrushes.DarkGray, new XRect(page.Width - 210, y + 4, 180, 20), XStringFormats.TopRight);
                    }
                }

                doc.Save(rutaCompleta);
            }

            return rutaCompleta;
        }
    }
}
