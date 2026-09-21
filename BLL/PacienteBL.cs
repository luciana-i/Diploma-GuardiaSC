using BE;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class PacienteBL
    {

        public PacienteBL() { }

        public List<Paciente> Obtener()
        {
            return PacienteDAL.ListarPacientes();
        }

        public Paciente ObtenerPorDNI(string dni)
        {
            return PacienteDAL.ObtenerPorDni(dni);
        }

        public int AgregarPaciente(Paciente paciente)
        {
            return PacienteDAL.Insertar(paciente);
        }

        public void ActualizarPaciente(Paciente paciente)
        {
            PacienteDAL.Actualizar(paciente);
        }
       
    }
}
