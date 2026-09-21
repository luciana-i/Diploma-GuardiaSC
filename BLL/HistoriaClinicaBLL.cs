using BE;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class HistoriaClinicaBLL
    {
        public List<HistoriaClinica> ListarPorPaciente(int id)
        {
            return HistoriaClinicaDAL.ListarPorPacienteId(id);
        }
    }
}
