using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Servicios.Clases
{
    public class SeccionPdf
    {
        public string Titulo { get; set; }
        public string Contenido { get; set; }

        public SeccionPdf(string titulo, string contenido)
        {
            Titulo = titulo;
            Contenido = contenido;
        }
    }
}
