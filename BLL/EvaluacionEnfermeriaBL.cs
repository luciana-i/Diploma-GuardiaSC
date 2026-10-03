using BE;
using BLL.Servicios;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class EvaluacionEnfermeriaBL
    {


        public void Insertar(EvaluacionEnfermeria evaluacion)
        {
            evaluacion.Enfermero = new EmpleadoBL().ObtenerEmpleado(SessionManager.getInstance().ObtenerUsuario());
            EvaluacionEnfermeriaDAL.Insertar(evaluacion);
        }

        public EvaluacionEnfermeria ObtenerPorConsultaId(int id)
        {
            return EvaluacionEnfermeriaDAL.ObtenerPorConsultaId(id);
        }
    }
}
