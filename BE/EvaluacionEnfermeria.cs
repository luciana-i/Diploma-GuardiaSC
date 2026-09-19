using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class EvaluacionEnfermeria
    {
        public int Id { get; set; }
        public Consulta Consulta { get; set; }
        public int? FrecuenciaCardiaca { get; set; }
        public decimal? Temperatura { get; set; }
        public int? SaturacionOxigeno { get; set; }
        public string PresionArterial { get; set; }
        public string SintomasObservados { get; set; }
        public bool EsConsultaAdministrativa { get; set; }
        public string JustificacionCambio { get; set; }
        public DateTime FechaEvaluacion { get; set; }
        public long? DVH { get; set; }

        public NivelPrioridad PrioridadSugerida { get; set; }
        public NivelPrioridad PrioridadFinal { get; set; }

        public Usuario Enfermero { get; set; }

        public EvaluacionEnfermeria()
        {
            FechaEvaluacion = DateTime.Now;
        }

        public override string ToString() =>
            $"Enfermeria #{Consulta.Id} - Nivel Final: {PrioridadFinal}";
    }
}
