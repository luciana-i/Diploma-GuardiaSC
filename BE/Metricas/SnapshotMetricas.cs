using BE.Metricas;
using System;
using System.Collections.Generic;

namespace BE
{
    [Serializable]
    public class SnapshotMetricas
    {
        // 1. Contexto de la consulta y filtros multidimensionales
        public DateTime FechaDesde { get; set; }
        public DateTime FechaHasta { get; set; }
        public DateTime FechaGeneracion { get; set; }
        public int? TurnoSeleccionado { get; set; }      // null: Todos, 1: Mañana, 2: Tarde, 3: Noche
        public int? PrioridadSeleccionada { get; set; }  // null: Todas, 1 a 5

        // 2. Paneles superiores (Tarjetas KPI)
        public double EsperaPromedioConsultorioMinutos { get; set; }
        public int PicoLaboratorioCantidad { get; set; }
        public int PicoLaboratorioHora { get; set; }
        public int PicoRayosCantidad { get; set; }
        public int PicoRayosHora { get; set; }
        public double TasaInternacionPorcentaje { get; set; }
        public int TotalConsultasAuditadas { get; set; }

        // 3. Panel lateral: Distribución de Destinos
        public int CantidadAltas { get; set; }
        public double PorcentajeAltas { get; set; }

        public int CantidadInternaciones { get; set; }
        public double PorcentajeInternaciones { get; set; }

        public int CantidadDerivaciones { get; set; }
        public double PorcentajeDerivaciones { get; set; }

        // 4. Detección de Cuello de Botella
        public string CuelloBotellaSector { get; set; }
        public string CuelloBotellaDetalle { get; set; }

        // 5. Análisis de Capacidad y Arribos (Teoría de Colas: Ley de Little y Poisson)
        public double TasaArriboLambda { get; set; }           // Pacientes por hora en pico (λ)
        public double PacientesEnEsperaLittle { get; set; }     // L = λ * W
        public double ProbabilidadColapsoP { get; set; }       // Poisson P(X >= Capacidad) en %

        // 6. Simulación de Escenarios ("What-If")
        public int MedicosSimulados { get; set; }
        public int EnfermerosSimulados { get; set; }
        public double DemoraSimuladaMinutos { get; set; }

        // 7. Gráfico LiveCharts (Curva de 24 horas: 00 a 23 hs)
        public List<DemandaHoraria> CurvaHoraria { get; set; } = new List<DemandaHoraria>();

        // 8. Panel inferior: Recomendación Gerencial
        public string RecomendacionDotacion { get; set; }
    }
}