using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Consulta
    {
        public int Id { get; set; }
        public DateTime FechaIngreso { get; set; }
        public string MotivoIngreso { get; set; }
        public long? DVH { get; set; }

        public EstadoConsulta EstadoConsulta { get; set; } = EstadoConsulta.EnEsperaEnfermeria;

        public Paciente Paciente { get; set; }
        public Usuario UsuarioIngreso { get; set; }

        // Composición asistencial (1 a 0..1)
        public EvaluacionEnfermeria EvaluacionEnfermeria { get; set; }
        public AtencionMedica AtencionMedica { get; set; }

        public Consulta()
        {
            FechaIngreso = DateTime.Now;
        }

        public override string ToString() =>
            $"Consulta #{Id} - {Paciente?.NombreCompleto ?? "Sin Paciente"} ({EstadoConsulta})";
    }
}
