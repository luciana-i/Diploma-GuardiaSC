using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    [Serializable]
    public enum TipoDocumentoClinico
    {
        Indicaciones = 1,
        Derivacion = 2,
        SolicitudEstudios = 3
    }
}
