using BE;
using BE.Metricas;
using BLL.Servicios.Clases;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BLL.Servicios
{
    public class MetricasService
    {
        private const double UMBRAL_ESPERA_CONSULTORIO_MINUTOS = 20.0;
        private const int CAPACIDAD_MAXIMA_LAB_POR_TECNICO = 5;
        private const int CAPACIDAD_MAXIMA_RAYOS_POR_TECNICO = 4;
        private const double CAPACIDAD_ATENCION_POR_MEDICO_HORA = 3.5; // ~17 min promedio por paciente

        /// <summary>
        /// Orquesta el cálculo analítico, probabilístico y las sugerencias de dotación.
        /// </summary>
        public SnapshotMetricas AnalizarPeriodo(DateTime fechaDesde, DateTime fechaHasta, int? turno = null, int? prioridadId = null, int medicosSim = 2, int enfermerosSim = 1)
        {
            var snapshot = new SnapshotMetricas
            {
                FechaDesde = fechaDesde.Date,
                FechaHasta = fechaHasta.Date,
                FechaGeneracion = DateTime.Now,
                TurnoSeleccionado = turno,
                PrioridadSeleccionada = prioridadId,
                MedicosSimulados = medicosSim,
                EnfermerosSimulados = enfermerosSim
            };

            // 1. Obtener datos crudos agrupados desde la DAL aplicando filtros
            var tiempos = MetricasDAL.ObtenerTiemposPromedio(fechaDesde, fechaHasta, turno, prioridadId);
            var demandaHoraria = MetricasDAL.ObtenerDemandaHoraria(fechaDesde, fechaHasta, turno, prioridadId);
            var destinos = MetricasDAL.ObtenerDistribucionDestinos(fechaDesde, fechaHasta, turno, prioridadId);

            // 2. Procesar Tiempos de Ciclo y KPIs
            snapshot.EsperaPromedioConsultorioMinutos = Math.Round(tiempos.esperaConsultorio, 1);

            // 3. Procesar Distribución de Destinos Finales
            ProcesarDestinos(snapshot, destinos);

            // 4. Proyección de Demanda Horaria y Picos de Prácticas
            ProcesarCurvaYProyeccion(snapshot, demandaHoraria);

            // 5. Análisis de Teoría de Colas (Little y Poisson)
            ProcesarTeoriaColas(snapshot, tiempos.tasaArriboPico, tiempos.esperaEnfermeria, tiempos.esperaConsultorio);

            // 6. Simulación de Escenarios ("What-If")
            SimularEscenario(snapshot, medicosSim, enfermerosSim);

            // 7. Diagnóstico de Cuellos de Botella y Recomendación de Dotación
            EvaluarCuelloDeBotella(snapshot, tiempos.esperaEnfermeria, tiempos.esperaConsultorio);
            GenerarRecomendacionStaffing(snapshot);

            return snapshot;
        }

        private void ProcesarDestinos(SnapshotMetricas snapshot, Dictionary<DestinoConsulta, int> destinos)
        {
            snapshot.CantidadAltas = destinos.ContainsKey(DestinoConsulta.AltaMedica) ? destinos[DestinoConsulta.AltaMedica] : 0;
            snapshot.CantidadInternaciones = destinos.ContainsKey(DestinoConsulta.Internacion) ? destinos[DestinoConsulta.Internacion] : 0;
            snapshot.CantidadDerivaciones = destinos.ContainsKey(DestinoConsulta.DerivacionExterna) ? destinos[DestinoConsulta.DerivacionExterna] : 0;

            snapshot.TotalConsultasAuditadas = destinos.Values.Sum();

            if (snapshot.TotalConsultasAuditadas > 0)
            {
                snapshot.PorcentajeAltas = Math.Round((snapshot.CantidadAltas * 100.0) / snapshot.TotalConsultasAuditadas, 1);
                snapshot.PorcentajeInternaciones = Math.Round((snapshot.CantidadInternaciones * 100.0) / snapshot.TotalConsultasAuditadas, 1);
                snapshot.PorcentajeDerivaciones = Math.Round((snapshot.CantidadDerivaciones * 100.0) / snapshot.TotalConsultasAuditadas, 1);
                snapshot.TasaInternacionPorcentaje = snapshot.PorcentajeInternaciones;
            }
            else
            {
                snapshot.PorcentajeAltas = 0;
                snapshot.PorcentajeInternaciones = 0;
                snapshot.PorcentajeDerivaciones = 0;
                snapshot.TasaInternacionPorcentaje = 0;
            }
        }

        private void ProcesarCurvaYProyeccion(SnapshotMetricas snapshot, List<DemandaHoraria> demandaHoraria)
        {
            snapshot.CurvaHoraria = demandaHoraria;

            // Pico Laboratorio
            var puntoMaxLab = demandaHoraria.OrderByDescending(d => d.CantidadLabReal).FirstOrDefault();
            if (puntoMaxLab != null && puntoMaxLab.CantidadLabReal > 0)
            {
                snapshot.PicoLaboratorioCantidad = puntoMaxLab.CantidadLabReal;
                snapshot.PicoLaboratorioHora = puntoMaxLab.Hora;
            }

            // Pico Radiología
            var puntoMaxRayos = demandaHoraria.OrderByDescending(d => d.CantidadRayosReal).FirstOrDefault();
            if (puntoMaxRayos != null && puntoMaxRayos.CantidadRayosReal > 0)
            {
                snapshot.PicoRayosCantidad = puntoMaxRayos.CantidadRayosReal;
                snapshot.PicoRayosHora = puntoMaxRayos.Hora;
            }

            // Proyección estocástica combinada con margen de contingencia (15%)
            foreach (var punto in snapshot.CurvaHoraria)
            {
                double totalEstudios = punto.CantidadLabReal + punto.CantidadRayosReal;
                punto.CantidadProyectada = Math.Round(totalEstudios * 1.15, 1);
            }
        }

        private void ProcesarTeoriaColas(SnapshotMetricas snapshot, double tasaArriboPico, double esperaEnf, double esperaCons)
        {
            // Tasa media de arribos (Lambda: pacientes/hora)
            snapshot.TasaArriboLambda = Math.Round(tasaArriboPico > 0 ? tasaArriboPico : 4.0, 1);

            // Tiempo medio en el sistema W (en horas)
            double tiempoEsperaHoras = (esperaEnf + esperaCons) / 60.0;

            // Ley de Little: L = Lambda * W (pacientes en espera simultánea)
            snapshot.PacientesEnEsperaLittle = Math.Round(snapshot.TasaArriboLambda * tiempoEsperaHoras, 1);

            // Capacidad de resolución del turno base (2 médicos estándar)
            int capacidadNominal = (int)Math.Floor(2 * CAPACIDAD_ATENCION_POR_MEDICO_HORA);

            // Distribución de Poisson: Probabilidad de que la demanda supere la capacidad instalada
            snapshot.ProbabilidadColapsoP = Math.Round(CalcularProbabilidadPoissonSaturacion(snapshot.TasaArriboLambda, capacidadNominal) * 100, 1);
        }

        /// <summary>
        /// Recalcula en memoria el impacto en la demora ante modificaciones del staffing.
        /// </summary>
       public void SimularEscenario(SnapshotMetricas snapshot, int medicos, int enfermeros)
        {
            snapshot.MedicosSimulados = medicos;
            snapshot.EnfermerosSimulados = enfermeros;

            // Relación de capacidad médica (base de 2 médicos)
            double factorMedicos = 2.0 / Math.Max(medicos, 1);
            double demoraAjustada = snapshot.EsperaPromedioConsultorioMinutos * factorMedicos;

            // Aceleración si se refuerza la enfermería (más de 1 enfermero activo)
            if (enfermeros > 1)
            {
                demoraAjustada *= 0.90; // Reducción del 10% por mayor agilidad en clasificación
            }

            snapshot.DemoraSimuladaMinutos = Math.Max(Math.Round(demoraAjustada, 1), 5.0);
        }

        private double CalcularProbabilidadPoissonSaturacion(double lambda, int capacidad)
        {
            if (lambda <= 0) return 0.0;

            double sumaAcumulada = 0;
            for (int k = 0; k <= capacidad; k++)
            {
                sumaAcumulada += (Math.Pow(lambda, k) * Math.Exp(-lambda)) / Factorial(k);
            }

            double pSaturacion = 1.0 - sumaAcumulada;
            return Math.Max(0.0, Math.Min(1.0, pSaturacion));
        }

        private double Factorial(int n)
        {
            if (n <= 1) return 1.0;
            double res = 1.0;
            for (int i = 2; i <= n; i++) res *= i;
            return res;
        }

        private void EvaluarCuelloDeBotella(SnapshotMetricas snapshot, double esperaEnfermeria, double esperaConsultorio)
        {
            if (esperaConsultorio > UMBRAL_ESPERA_CONSULTORIO_MINUTOS)
            {
                snapshot.CuelloBotellaSector = "Espera Enfermería ➔ Consultorio Médico";
                snapshot.CuelloBotellaDetalle = $"Demora media crítica: {Math.Round(esperaConsultorio, 1)} min";
            }
            else if (esperaEnfermeria > 15.0)
            {
                snapshot.CuelloBotellaSector = "Admisión ➔ Espera Enfermería";
                snapshot.CuelloBotellaDetalle = $"Demora media de ingreso: {Math.Round(esperaEnfermeria, 1)} min";
            }
            else
            {
                snapshot.CuelloBotellaSector = "Sin congestión crítica detectada";
                snapshot.CuelloBotellaDetalle = "Tiempos de espera dentro de los límites estándar";
            }
        }

        private void GenerarRecomendacionStaffing(SnapshotMetricas snapshot)
        {
            var recomendaciones = new List<string>();

            // 1. Laboratorio
            if (snapshot.PicoLaboratorioCantidad > CAPACIDAD_MAXIMA_LAB_POR_TECNICO)
            {
                recomendaciones.Add(
                    $"• Servicio de Laboratorio: Se detectó pico de {snapshot.PicoLaboratorioCantidad} análisis en la franja de las {snapshot.PicoLaboratorioHora:D2}:00 hs (capacidad nominal: {CAPACIDAD_MAXIMA_LAB_POR_TECNICO}/h). Se sugiere asignar 1 técnico/bioquímico de refuerzo para ese turno.");
            }
            else
            {
                recomendaciones.Add("• Servicio de Laboratorio: Carga de trabajo dentro de los parámetros operativos normales.");
            }

            // 2. Radiología
            if (snapshot.PicoRayosCantidad > CAPACIDAD_MAXIMA_RAYOS_POR_TECNICO)
            {
                recomendaciones.Add(
                    $"• Servicio de Radiología: Se detectó pico de {snapshot.PicoRayosCantidad} estudios a las {snapshot.PicoRayosHora:D2}:00 hs (capacidad nominal: {CAPACIDAD_MAXIMA_RAYOS_POR_TECNICO}/h). Se sugiere reforzar técnico radiólogo.");
            }
            else
            {
                recomendaciones.Add("• Servicio de Radiología: Demanda de placas dentro de la capacidad nominal del servicio.");
            }

            // 3. Consultorios Médicos
            if (snapshot.EsperaPromedioConsultorioMinutos > UMBRAL_ESPERA_CONSULTORIO_MINUTOS)
            {
                recomendaciones.Add(
                    $"• Consultorios Médicos: Tiempo de espera hacia médico ({snapshot.EsperaPromedioConsultorioMinutos} min) supera el umbral normativo ({UMBRAL_ESPERA_CONSULTORIO_MINUTOS} min). Se aconseja habilitar consultorio de refuerzo pasivo.");
            }
            else
            {
                recomendaciones.Add("• Consultorios Médicos: Tiempos de atención estables sin necesidad de consultorios adicionales.");
            }

            snapshot.RecomendacionDotacion = string.Join(Environment.NewLine, recomendaciones);
        }

        /// <summary>
        /// Mapea el Snapshot a la clase base de PDF existente y genera el reporte formal.
        /// </summary>
        public string ExportarSnapshotPdf(SnapshotMetricas s)
        {
            string labTexto = s.PicoLaboratorioCantidad > 0
                ? $"{s.PicoLaboratorioCantidad} est/h ({s.PicoLaboratorioHora:D2}hs)"
                : "0 est/h";

            string rayosTexto = s.PicoRayosCantidad > 0
                ? $"{s.PicoRayosCantidad} est/h ({s.PicoRayosHora:D2}hs)"
                : "0 est/h";

            string turnoTexto = s.TurnoSeleccionado.HasValue ? $"Turno #{s.TurnoSeleccionado.Value}" : "Todos los Turnos";
            string prioridadTexto = s.PrioridadSeleccionada.HasValue ? $"Nivel #{s.PrioridadSeleccionada.Value}" : "Todas las Prioridades";

            var doc = new PdfDocumento
            {
                SubCarpeta = "ReportesExportados",
                PrefijoArchivo = "Snapshot_Guardia",
                TituloInstitucional = "CLÍNICA SAGRADO CORAZÓN - AUDITORÍA DE GUARDIA",
                Subtitulo = "REPORTE DE CAPACIDAD OPERATIVA Y ASIGNACIÓN DE RECURSOS",
                Metadatos = new Dictionary<string, string>
                {
                    { "Período Asistencial:", $"{s.FechaDesde:dd/MM/yyyy} a {s.FechaHasta:dd/MM/yyyy}" },
                    { "Fecha Emisión:", $"{s.FechaGeneracion:dd/MM/yyyy HH:mm} hs" },
                    { "Turno:", turnoTexto },
                    { "Prioridad:", prioridadTexto },
                    { "Espera Consultorio:", $"{s.EsperaPromedioConsultorioMinutos} min" },
                    { "Pico Laboratorio:", labTexto },
                    { "Pico Radiología:", rayosTexto },
                    { "Tasa Internación:", $"{s.TasaInternacionPorcentaje} %" },
                    { "Total Consultas:", $"{s.TotalConsultasAuditadas} pac." }
                },
                Secciones = new List<SeccionPdf>
                {
                    new SeccionPdf("Resolución y Destinos Finales:",
                        $"• Altas Médicas: {s.CantidadAltas} ({s.PorcentajeAltas}%)\n" +
                        $"• Internaciones: {s.CantidadInternaciones} ({s.PorcentajeInternaciones}%)\n" +
                        $"• Derivaciones Externas: {s.CantidadDerivaciones} ({s.PorcentajeDerivaciones}%)"),

                    new SeccionPdf("Modelado de Capacidad y Teoría de Colas:",
                        $"• Tasa Arribos Pico (λ): {s.TasaArriboLambda} pac/h\n" +
                        $"• Espera Simultánea en Sala (Ley de Little - L): {s.PacientesEnEsperaLittle} pac.\n" +
                        $"• Probabilidad de Saturación (Poisson - P): {s.ProbabilidadColapsoP} %\n" +
                        $"• Cuello de Botella Detectado: {s.CuelloBotellaSector}"),

                    new SeccionPdf("Escenario Simulado Activo (\"What-If\"): ",
                        $"• Dotación: {s.MedicosSimulados} médico(s) y {s.EnfermerosSimulados} enfermero(s).\n" +
                        $"• Demora Proyectada Resultante: {s.DemoraSimuladaMinutos} min."),

                    new SeccionPdf("Dictamen Gerencial para Cronograma y Dotación:",
                        s.RecomendacionDotacion)
                },
                PieFirma = "Firma Autorizada Dirección Médica / RRHH"
            };

            // Reutiliza directo tu generador sin duplicar nada
            return GeneradorPdfService.GenerarPdf(doc);
        }
    }
}