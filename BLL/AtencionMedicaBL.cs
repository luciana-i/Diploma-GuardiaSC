using BE;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class AtencionMedicaBL
    {
        public AtencionMedicaBL()
        {
            // Constructor logic here
        }

        public AtencionMedica RegistrarAtencion(Consulta consulta, Usuario medico )
        {
            AtencionMedica atencionMedica = new AtencionMedica(consulta, medico);   
            AtencionMedicaDAL.Insertar(atencionMedica);
            return atencionMedica;  
        }

        public void FinalizarAtencionMedica(AtencionMedica atencionMedica)
        {
            AtencionMedicaDAL.FinalizarAtencion(atencionMedica);
        }
    }
}
