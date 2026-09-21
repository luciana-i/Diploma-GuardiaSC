using BE;
using BLL.Servicios;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Servicios
{
    public class AsignacionPrioridadService
    {
        /// <summary>
        /// Evalúa los parámetros clínicos y retorna el enum NivelPrioridad sugerido.
        /// </summary>
        public NivelPrioridad CalcularPrioridadSugerida(
            int? frecuenciaCardiaca,
            decimal? temperatura,
            int? saturacionOxigeno,
            string presionArterial,
            bool esConsultaAdministrativa)
        {
            // 1. Consulta Administrativa / Vía Rápida -> Nivel 5 (Azul)
            if (esConsultaAdministrativa)
            {
                return NivelPrioridad.NoUrgente;
            }

            // Parsear Presión Arterial Sistólica (ej: "120/80")
            int sistolica = 0;
            if (!string.IsNullOrWhiteSpace(presionArterial))
            {
                string[] partes = presionArterial.Split('/');
                if (partes.Length > 0)
                {
                    int.TryParse(partes[0].Trim(), out sistolica);
                }
            }

            // 2. NIVEL 1 - ROJO (Riesgo vital inminente)
            if ((saturacionOxigeno.HasValue && saturacionOxigeno.Value < 85) ||
                (frecuenciaCardiaca.HasValue && (frecuenciaCardiaca.Value < 40 || frecuenciaCardiaca.Value > 150)) ||
                (sistolica > 0 && sistolica < 70))
            {
                return NivelPrioridad.Emergencia;
            }

            // 3. NIVEL 2 - NARANJA (Muy Urgente)
            if ((saturacionOxigeno.HasValue && saturacionOxigeno.Value < 90) ||
                (frecuenciaCardiaca.HasValue && (frecuenciaCardiaca.Value < 50 || frecuenciaCardiaca.Value > 120)) ||
                (temperatura.HasValue && temperatura.Value >= 40.0m) ||
                (sistolica > 0 && (sistolica >= 200 || sistolica < 80)))
            {
                return NivelPrioridad.MuyUrgente;
            }

            // 4. NIVEL 3 - AMARILLO (Urgente)
            if ((saturacionOxigeno.HasValue && saturacionOxigeno.Value <= 94) ||
                (frecuenciaCardiaca.HasValue && frecuenciaCardiaca.Value > 100) ||
                (temperatura.HasValue && temperatura.Value >= 38.0m) ||
                (sistolica > 0 && (sistolica >= 160 || sistolica < 90)))
            {
                return NivelPrioridad.Urgente;
            }

            // 5. NIVEL 4 - VERDE (Poco Urgente)
            return NivelPrioridad.PocoUrgente;
        }

        public static string ObtenerColorHex(NivelPrioridad nivel)
        {
            switch (nivel)
            {
                case NivelPrioridad.Emergencia: return "#EF4444"; // Rojo
                case NivelPrioridad.MuyUrgente: return "#F97316"; // Naranja
                case NivelPrioridad.Urgente: return "#EAB308"; // Amarillo
                case NivelPrioridad.PocoUrgente: return "#10B981"; // Verde
                case NivelPrioridad.NoUrgente: return "#3B82F6"; // Azul
                default: return "#9FB0B8";
            }
        }

        public static string ObtenerTiempoEsperaTexto(NivelPrioridad nivel)
        {
            switch (nivel)
            {
                case NivelPrioridad.Emergencia: return "Atención Inmediata (0 min)";
                case NivelPrioridad.MuyUrgente: return "Tiempo máx. espera: 15 min";
                case NivelPrioridad.Urgente: return "Tiempo máx. espera: 60 min";
                case NivelPrioridad.PocoUrgente: return "Tiempo máx. espera: 120 min";
                case NivelPrioridad.NoUrgente: return "Tiempo máx. espera: 240 min";
                default: return string.Empty;
            }
        }
    }
}
