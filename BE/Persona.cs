using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public abstract class Persona
    {
        public string Dni { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public DateTime? FechaNacimiento { get; set; }
        public string Telefono { get; set; }
        public string NombreCompleto => $"{Apellido}, {Nombre}".Trim(' ', ',');
        public string NombreConDni => $"{NombreCompleto} (DNI: {Dni})";

        public override string ToString() => NombreConDni;
    }
}
