using BE;
using BE.Metricas;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class MetricasDAL
    {
        /// <summary>
        /// Obtiene el conteo real de estudios de Radiología (Destino 3) y Laboratorio (Destino 4)
        /// agrupados por cada una de las 24 franjas horarias.
        /// </summary>
        public static List<DemandaHoraria> ObtenerDemandaHoraria(DateTime fechaDesde, DateTime fechaHasta, int? turno = null, int? prioridadId = null)
        {
            var lista = new List<DemandaHoraria>();

            for (int h = 0; h < 24; h++)
            {
                lista.Add(new DemandaHoraria
                {
                    Hora = h,
                    CantidadRayosReal = 0,
                    CantidadLabReal = 0,
                    CantidadProyectada = 0
                });
            }

            DAO dao = new DAO();
            string filtroExtra = ConstruirClausulaFiltros(turno, prioridadId);

            string sql = $@"
                SELECT 
                    DATEPART(HOUR, C.Consulta_FechaIngreso) AS Hora,
                    SUM(CASE WHEN AM.DestinoConsulta_Id = 3 THEN 1 ELSE 0 END) AS TotalRayos,
                    SUM(CASE WHEN AM.DestinoConsulta_Id = 4 THEN 1 ELSE 0 END) AS TotalLaboratorio
                FROM dbo.Consulta C
                INNER JOIN dbo.AtencionMedica AM ON AM.AtencionMedica_ConsultaId = C.Consulta_Id
                LEFT JOIN dbo.EvaluacionEnfermeria EE ON EE.EvaluacionEnfermeria_ConsultaId = C.Consulta_Id
                WHERE C.Consulta_FechaIngreso >= @FechaDesde 
                  AND C.Consulta_FechaIngreso < DATEADD(DAY, 1, @FechaHasta)
                  {filtroExtra}
                GROUP BY DATEPART(HOUR, C.Consulta_FechaIngreso)
                ORDER BY Hora ASC;";

            var parametros = new SqlParameter[]
            {
                new SqlParameter("@FechaDesde", fechaDesde.Date),
                new SqlParameter("@FechaHasta", fechaHasta.Date)
            };

            DataSet ds = dao.ExecuteDataSet(sql, parametros);

            if (ds != null && ds.Tables.Count > 0)
            {
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    int hora = Convert.ToInt32(row["Hora"]);
                    int rayos = Convert.ToInt32(row["TotalRayos"]);
                    int lab = Convert.ToInt32(row["TotalLaboratorio"]);

                    if (hora >= 0 && hora < 24)
                    {
                        lista[hora].CantidadRayosReal = rayos;
                        lista[hora].CantidadLabReal = lab;
                    }
                }
            }

            return lista;
        }

        /// <summary>
        /// Calcula demoras medias en minutos y tasa pico de arribos por hora (Lambda).
        /// </summary>
        public static (double esperaEnfermeria, double esperaConsultorio, double duracionAtencion, double tasaArriboPico)
            ObtenerTiemposPromedio(DateTime fechaDesde, DateTime fechaHasta, int? turno = null, int? prioridadId = null)
        {
            DAO dao = new DAO(); 
            // por turnos mañana tarde y noche y prioridad
            string filtroExtra = ConstruirClausulaFiltros(turno, prioridadId);

            string sql = $@"
                SELECT 
                    ISNULL(AVG(CAST(DATEDIFF(MINUTE, C.Consulta_FechaIngreso, EE.EvaluacionEnfermeria_FechaEvaluacion) AS FLOAT)), 0) AS EsperaEnfermeriaMinutos,
                    ISNULL(AVG(CAST(DATEDIFF(MINUTE, EE.EvaluacionEnfermeria_FechaEvaluacion, AM.AtencionMedica_FechaInicio) AS FLOAT)), 0) AS EsperaConsultorioMinutos,
                    ISNULL(AVG(CAST(DATEDIFF(MINUTE, AM.AtencionMedica_FechaInicio, AM.AtencionMedica_FechaFin) AS FLOAT)), 0) AS DuracionAtencionMinutos
                FROM dbo.Consulta C
                INNER JOIN dbo.EvaluacionEnfermeria EE ON EE.EvaluacionEnfermeria_ConsultaId = C.Consulta_Id
                INNER JOIN dbo.AtencionMedica AM ON AM.AtencionMedica_ConsultaId = C.Consulta_Id
                WHERE C.Consulta_FechaIngreso >= @FechaDesde 
                  AND C.Consulta_FechaIngreso < DATEADD(DAY, 1, @FechaHasta)
                  {filtroExtra};

                SELECT ISNULL(MAX(Sub.ArribosPorHora), 0) AS MaxArribosHora
                FROM (
                    SELECT COUNT(*) AS ArribosPorHora
                    FROM dbo.Consulta C
                    LEFT JOIN dbo.EvaluacionEnfermeria EE ON EE.EvaluacionEnfermeria_ConsultaId = C.Consulta_Id
                    WHERE C.Consulta_FechaIngreso >= @FechaDesde 
                      AND C.Consulta_FechaIngreso < DATEADD(DAY, 1, @FechaHasta)
                      {filtroExtra}
                    GROUP BY CAST(C.Consulta_FechaIngreso AS DATE), DATEPART(HOUR, C.Consulta_FechaIngreso)
                ) Sub;";

            var parametros = new SqlParameter[]
            {
                new SqlParameter("@FechaDesde", fechaDesde.Date),
                new SqlParameter("@FechaHasta", fechaHasta.Date)
            };

            DataSet ds = dao.ExecuteDataSet(sql, parametros);

            double esperaEnfermeria = 0, esperaConsultorio = 0, duracionAtencion = 0, tasaArribos = 0;

            if (ds != null && ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    DataRow r = ds.Tables[0].Rows[0];
                    esperaEnfermeria = Convert.ToDouble(r["EsperaEnfermeriaMinutos"]);
                    esperaConsultorio = Convert.ToDouble(r["EsperaConsultorioMinutos"]);
                    duracionAtencion = Convert.ToDouble(r["DuracionAtencionMinutos"]);
                }

                if (ds.Tables.Count > 1 && ds.Tables[1].Rows.Count > 0)
                {
                    tasaArribos = Convert.ToDouble(ds.Tables[1].Rows[0]["MaxArribosHora"]);
                }
            }

            return (esperaEnfermeria, esperaConsultorio, duracionAtencion, tasaArribos);
        }

        /// <summary>
        /// Agrupa y cuenta la cantidad total de consultas según su resolución clínica final (DestinoConsulta).
        /// </summary>
        public static Dictionary<DestinoConsulta, int> ObtenerDistribucionDestinos(DateTime fechaDesde, DateTime fechaHasta, int? turno = null, int? prioridadId = null)
        {
            var dic = new Dictionary<DestinoConsulta, int>();

            DAO dao = new DAO();
            string filtroExtra = ConstruirClausulaFiltros(turno, prioridadId);

            string sql = $@"
                SELECT 
                    AM.DestinoConsulta_Id,
                    COUNT(*) AS Cantidad
                FROM dbo.AtencionMedica AM
                INNER JOIN dbo.Consulta C ON C.Consulta_Id = AM.AtencionMedica_ConsultaId
                LEFT JOIN dbo.EvaluacionEnfermeria EE ON EE.EvaluacionEnfermeria_ConsultaId = C.Consulta_Id
                WHERE C.Consulta_FechaIngreso >= @FechaDesde 
                  AND C.Consulta_FechaIngreso < DATEADD(DAY, 1, @FechaHasta)
                  {filtroExtra}
                GROUP BY AM.DestinoConsulta_Id;";

            var parametros = new SqlParameter[]
            {
                new SqlParameter("@FechaDesde", fechaDesde.Date),
                new SqlParameter("@FechaHasta", fechaHasta.Date)
            };

            DataSet ds = dao.ExecuteDataSet(sql, parametros);

            if (ds != null && ds.Tables.Count > 0)
            {
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    if (row["DestinoConsulta_Id"] != DBNull.Value)
                    {
                        var destino = (DestinoConsulta)Convert.ToInt32(row["DestinoConsulta_Id"]);
                        dic[destino] = Convert.ToInt32(row["Cantidad"]);
                    }
                }
            }

            return dic;
        }

        private static string ConstruirClausulaFiltros(int? turno, int? prioridadId)
        {
            string clausula = "";

            if (prioridadId.HasValue && prioridadId.Value > 0)
            {
                clausula += $" AND EE.NivelPrioridad_IdFinal = {prioridadId.Value} ";
            }

            if (turno.HasValue && turno.Value > 0)
            {
                switch (turno.Value)
                {
                    case 1: // Mañana (06:00 a 13:59)
                        clausula += " AND DATEPART(HOUR, C.Consulta_FechaIngreso) >= 6 AND DATEPART(HOUR, C.Consulta_FechaIngreso) < 14 ";
                        break;
                    case 2: // Tarde (14:00 a 21:59)
                        clausula += " AND DATEPART(HOUR, C.Consulta_FechaIngreso) >= 14 AND DATEPART(HOUR, C.Consulta_FechaIngreso) < 22 ";
                        break;
                    case 3: // Noche (22:00 a 05:59)
                        clausula += " AND (DATEPART(HOUR, C.Consulta_FechaIngreso) >= 22 OR DATEPART(HOUR, C.Consulta_FechaIngreso) < 6) ";
                        break;
                }
            }

            return clausula;
        }
    }
}