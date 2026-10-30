using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Servicios
{
    public class BinarySerializator<T> : AbstractSerializator
    {
        public override object Deserializar(Stream str)
        {
            var formatter = new BinaryFormatter();
            return formatter.Deserialize(str);
        }

        public override object Serializar(object que)
        {
            // Usa el nombre de la clase serializable DocumentoClinico o DemandaHoraria como subcarpeta y prefijo
            string tipoNombre = typeof(T).Name;
            var fs = FileStreamManager.Instance.CreateFile("dat", subCarpeta: tipoNombre + "s", prefijo: tipoNombre);

            var formatter = new BinaryFormatter();
            formatter.Serialize(fs, que);
            fs.Close();

            return fs.Name; // Devuelve la ruta completa del archivo creado
        }
    }
}
