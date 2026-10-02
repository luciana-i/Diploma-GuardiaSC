using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class AtencionMedica
    {
        public int Id { get; set; }
        public Consulta Consulta { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime? FechaFin { get; set; }
        public string Diagnostico { get; set; }
        public string Indicaciones { get; set; }
        public Usuario Usuario { get; set; }
        public Empleado Medico { get; set; }

        public DestinoConsulta? Destino { get; set; }

        public AtencionMedica()
        {
        }

        public AtencionMedica(Consulta consulta, Empleado medico, Usuario usuario)
        {
            Consulta = consulta;
            Medico = medico;    
            FechaInicio = DateTime.Now;
        }

       
    }
}
