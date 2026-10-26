using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    [Serializable]
    public class DocumentoClinico
    {
        public int Id { get; set; }
        public int ConsultaId { get; set; }
        public TipoDocumentoClinico Tipo { get; set; }
        public DateTime FechaEmision { get; set; }
        public string Diagnostico { get; set; }
        public string Contenido { get; set; }
        public string RutaArchivo { get; set; }
    }
}
