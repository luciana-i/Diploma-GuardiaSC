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
        public HistoriaClinica ObtenerPorPaciente(int id)
        {
            return HistoriaClinicaDAL.ObtenerPorPaciente(id);
        }

        public void Insertar(HistoriaClinica historiaClinica)
        {
            HistoriaClinicaDAL.Insertar(historiaClinica);
        }

        public void Actualizar(HistoriaClinica historiaClinica)
        {
            HistoriaClinicaDAL.Actualizar(historiaClinica);
        }
    }
}
