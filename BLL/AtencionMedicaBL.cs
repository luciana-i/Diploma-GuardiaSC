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

        public AtencionMedica RegistrarAtencion(Consulta consulta,Usuario usuario )
        {
            EmpleadoBL empleadoBL=new EmpleadoBL();
            Empleado empleado = empleadoBL.ObtenerEmpleado(usuario);
            AtencionMedica atencionMedica = new AtencionMedica(consulta, empleado);   
            AtencionMedicaDAL.Insertar(atencionMedica);
            return atencionMedica;  
        }

        public void FinalizarAtencionMedica(AtencionMedica atencionMedica)
        {
            atencionMedica.FechaFin = DateTime.Now;
            AtencionMedicaDAL.FinalizarAtencion(atencionMedica);
            new ConsultaBL().AvanzarSiguienteEstado(atencionMedica.Consulta); 
        }

        public List<AtencionMedica> ObtenerAtencionesMedicasPorPaciente(int pacienteId)
        {
            return AtencionMedicaDAL.ObtenerAtencionesMedicasPorPaciente(pacienteId);
        }
    }
}
