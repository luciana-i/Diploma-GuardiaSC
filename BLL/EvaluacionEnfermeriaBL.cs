using BE;
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
            EvaluacionEnfermeriaDAL.Insertar(evaluacion);
        }

        public EvaluacionEnfermeria ObtenerPorConsultaId(int id)
        {
            return EvaluacionEnfermeriaDAL.ObtenerPorConsultaId(id);
        }
    }
}
