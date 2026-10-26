using BLL.Servicios.Clases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Servicios
{
    public class PdfDocumento
    {
        // Configuración y archivo
        public string SubCarpeta { get; set; } = "DocumentosPdf";
        public string PrefijoArchivo { get; set; } = "Doc";

        // Encabezado
        public string TituloInstitucional { get; set; } = "CLÍNICA SAGRADO CORAZÓN - SERVICIO DE GUARDIA";
        public string Subtitulo { get; set; }

        // Metadatos en formato Clave/Valor (ej: Paciente, DNI, N° Consulta, Fecha, etc.)
        public Dictionary<string, string> Metadatos { get; set; } = new Dictionary<string, string>();

        // Bloques o secciones de texto libre (ej: Diagnóstico, Indicaciones, Traslado, etc.)
        public List<SeccionPdf> Secciones { get; set; } = new List<SeccionPdf>();

        // Pie de página / Firma (opcional: si es null, no dibuja la línea de firma)
        public string PieFirma { get; set; } = "Firma y Sello del Profesional Actuante";
    }
}

