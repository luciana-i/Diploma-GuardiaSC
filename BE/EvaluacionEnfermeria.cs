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

        public EvaluacionEnfermeria(
            Consulta consulta,
            int? frecuenciaCardiaca,
            decimal? temperatura,
            int? saturacionOxigeno,
            string presionArterial,
            string sintomasObservados,
            bool esConsultaAdministrativa,
            NivelPrioridad prioridadSugerida,
            NivelPrioridad prioridadFinal,
            string justificacionCambio,
            Usuario enfermero)
        {
            Consulta = consulta;
            FrecuenciaCardiaca = frecuenciaCardiaca;
            Temperatura = temperatura;
            SaturacionOxigeno = saturacionOxigeno;
            PresionArterial = string.IsNullOrWhiteSpace(presionArterial) ? null : presionArterial;
            SintomasObservados = sintomasObservados;
            EsConsultaAdministrativa = esConsultaAdministrativa;
            PrioridadSugerida = prioridadSugerida;
            PrioridadFinal = prioridadFinal;
            JustificacionCambio = string.IsNullOrWhiteSpace(justificacionCambio) ? null : justificacionCambio;
            Enfermero = enfermero;
            FechaEvaluacion = DateTime.Now;
        }

        public override string ToString() =>
            $"Enfermeria #{Consulta.Id} - Nivel Final: {PrioridadFinal}";
    }
}
