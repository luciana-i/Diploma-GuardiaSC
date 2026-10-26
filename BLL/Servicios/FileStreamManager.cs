using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Servicios
{
    public class FileStreamManager
    {
            private static FileStreamManager _instance;
            public static FileStreamManager Instance => _instance ?? (_instance = new FileStreamManager());

            private FileStreamManager() { }

            /// <summary>
            /// Crea un archivo con nombre dinámico según el tipo de documento o entidad a persistir.
            /// </summary>
            /// <param name="extension">Extensión del archivo (ej: "dat", "bin", "json").</param>
            /// <param name="subCarpeta">Subcarpeta destino dentro de la aplicación (por defecto "ArchivosSistema").</param>
            /// <param name="prefijo">Prefijo del nombre (ej: "DocClinico", "Snapshot", "Config").</param>
            public FileStream CreateFile(string extension, string subCarpeta = "DocumentosSistema", string prefijo = "Data")
            {
                string carpetaDestino = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, subCarpeta);

                if (!Directory.Exists(carpetaDestino))
                    Directory.CreateDirectory(carpetaDestino);

                // Genera nombre único: Prefijo_Timestamp_Guid.ext
                string nombreArchivo = $"{prefijo}_{DateTime.Now:yyyyMMdd_HHmmss}_{Guid.NewGuid().ToString().Substring(0, 5)}.{extension}";
                string rutaCompleta = Path.Combine(carpetaDestino, nombreArchivo);

                return new FileStream(rutaCompleta, FileMode.Create, FileAccess.Write);
            }
    }
}
