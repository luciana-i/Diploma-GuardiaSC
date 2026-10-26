using BE;
using BLL.Servicios;
using BLL.Servicios.Clases;
using DAL;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class DocumentoClinicoBL
    {
        private readonly BinarySerializator<DocumentoClinico> _serializador = new BinarySerializator<DocumentoClinico>();

        public string GenerarYSerializarDocumento(DocumentoClinico doc)
        {

            DocumentoClinico docExistente = DocumentoClinicoDAL.ObtenerPorConsultaYTipo(doc.ConsultaId, doc.Tipo);

            if (docExistente != null)
            {
                string rutaViejaAbsoluta = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, docExistente.RutaArchivo);
                if (File.Exists(rutaViejaAbsoluta))
                {
                    File.Delete(rutaViejaAbsoluta);
                }

                // Asignamos el ID existente al nuevo objeto para que el UPDATE sepa a quién apuntar
                doc.Id = docExistente.Id;
            }


            string rutaAbsoluta = (string)_serializador.Serializar(doc);

            // Extrae la ruta relativa respecto a la aplicación (ej: "DocumentoClinicos\Doc_xxx.dat")
            string basePath = AppDomain.CurrentDomain.BaseDirectory.TrimEnd('\\', '/');
            string rutaRelativa = rutaAbsoluta.Replace(basePath, "").TrimStart('\\', '/');

            doc.RutaArchivo = rutaRelativa;

            if (docExistente != null)
            {
                DocumentoClinicoDAL.Actualizar(doc);
            }
            else
            {
                DocumentoClinicoDAL.Insertar(doc);
            }

            return rutaRelativa;
        }

        public DocumentoClinico RecuperarDocumento(string rutaRelativa, DocumentoClinico docBD = null)
        {
            string rutaAbsoluta= "";
            
            if (!string.IsNullOrWhiteSpace(rutaRelativa))
                rutaAbsoluta = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, rutaRelativa);



            if (!File.Exists(rutaAbsoluta))
            {
                // Si viene el objeto desde el form, tenemos los datos para regenerarlo
                if (docBD != null)
                {
                    GenerarYSerializarDocumento(docBD);
                    // Actualizamos la ruta por si se generó con un nombre nuevo
                    rutaAbsoluta = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, docBD.RutaArchivo);
                }
            }

            using (var fs = new FileStream(rutaAbsoluta, FileMode.Open, FileAccess.Read))
            {
                return (DocumentoClinico)_serializador.Deserializar(fs);
            } 
        }

        public string GenerarPdfDocumento(DocumentoClinico doc, string nombrePaciente, string dniPaciente)
        {
            var modeloPdf = new PdfDocumento
            {
                Subtitulo = $"COMPROBANTE DE {doc.Tipo.ToString().ToUpper()}",
                PrefijoArchivo = $"Doc_{doc.Tipo}",
                Metadatos = new Dictionary<string, string>
                {
                    { "N° de Consulta:", $"#{doc.ConsultaId}" },
                    { "Fecha y Hora:", doc.FechaEmision.ToString("dd/MM/yyyy HH:mm") + " hs" },
                    { "Paciente:", nombrePaciente },
                    { "DNI:", dniPaciente }
                },
                Secciones = new List<SeccionPdf>
                {
                    new SeccionPdf("Diagnóstico Clínico Presuntivo:", doc.Diagnostico),
                    new SeccionPdf(
                        doc.Tipo == TipoDocumentoClinico.Derivacion
                            ? "Motivo y Detalle de Derivación / Traslado:"
                            : "Indicaciones Médicas y Tratamiento:",
                        doc.Contenido
                    )
                }
            };

            return GeneradorPdfService.GenerarPdf(modeloPdf);
        }

        public List<DocumentoClinico> ListarPorConsultaId(int id)
        {
            return DocumentoClinicoDAL.ListarPorConsultaId(id);
        }
    }
}
