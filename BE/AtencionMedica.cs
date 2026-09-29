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
        public string Destino { get; set; } // 'Alta', 'Internación', 'Derivación'
        public long? DVH { get; set; }

        public Usuario Medico { get; set; }

        public AtencionMedica()
        {
        }

        public AtencionMedica(Consulta consulta, Usuario medico)
        {
            Consulta = consulta;
            Medico = medico;    
            FechaInicio = DateTime.Now;
        }

        public override string ToString() =>
            $"Atención Médica #{Consulta.Id} - Destino: {Destino ?? "En Curso"}";
    }
}
