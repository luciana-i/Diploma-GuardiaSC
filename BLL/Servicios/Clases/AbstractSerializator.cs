using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Servicios
{
    public abstract class AbstractSerializator
    {
        public abstract object Deserializar(Stream str);
        public abstract object Serializar(object que);
    }
}
