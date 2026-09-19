using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public enum EstadoConsulta
    {
        EnEsperaEnfermeria = 1,
        EnEnfermeria = 2,
        EnEsperaAtencionMedica = 3,
        EnAtencionMedica = 4,
        Cancelado = 5,
        Finalizado = 6
    }
}
