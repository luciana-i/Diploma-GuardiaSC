using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Empleado : Persona
    {
        public int Id { get; set; }
        public TipoEmpleadoEnum TipoEmpleado { get; set; }
        public string Matricula { get; set; }
        public bool Activo { get; set; } = true;
        public Usuario EmpleadoUsuario { get; set; }

        public override string ToString() =>
     string.IsNullOrWhiteSpace(Matricula)
         ? $"{NombreCompleto} - {TipoEmpleado}"
         : $"{NombreCompleto} - {TipoEmpleado} (Mat. {Matricula})";
    }
}
