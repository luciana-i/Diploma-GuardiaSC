using BE;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class EmpleadoBL
    {
        public void Actualizar(Empleado empleadoActual)
        {
            EmpleadoDAL.Actualizar(empleadoActual);
        }

        public void Agregar(Empleado empleadoActual)
        {
            EmpleadoDAL.Insertar(empleadoActual);
        }

        public Empleado ObtenerEmpleado (Usuario usuario)
        {
            return EmpleadoDAL.ObtenerPorUsuarioId(usuario.Id);
        }
    }
}
