using BE;
using System;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class EvaluacionEnfermeriaDAL
    {
        public static int Insertar(EvaluacionEnfermeria evaluacion)
        {
            DAO dao = new DAO();
            string sql = @"
                INSERT INTO dbo.EvaluacionEnfermeria (
                    EvaluacionEnfermeria_ConsultaId,
                    EvaluacionEnfermeria_FrecuenciaCardiaca,
                    EvaluacionEnfermeria_Temperatura,
                    EvaluacionEnfermeria_SaturacionOxigeno,
                    EvaluacionEnfermeria_PresionArterial,
                    EvaluacionEnfermeria_SintomasObservados,
                    EvaluacionEnfermeria_EsConsultaAdministrativa,
                    NivelPrioridad_IdSugerido,
                    NivelPrioridad_IdFinal,
                    EvaluacionEnfermeria_JustificacionCambio,
                    Usuario_Id,
                    EvaluacionEnfermeria_FechaEvaluacion
                )
                VALUES (
                    @ConsultaId,
                    @FrecuenciaCardiaca,
                    @Temperatura,
                    @SaturacionOxigeno,
                    @PresionArterial,
                    @SintomasObservados,
                    @EsConsultaAdministrativa,
                    @NivelPrioridadIdSugerido,
                    @NivelPrioridadIdFinal,
                    @JustificacionCambio,
                    @UsuarioId,
                    @FechaEvaluacion
                );
                SELECT CAST(SCOPE_IDENTITY() AS INT);";

            var parametros = new SqlParameter[]
            {
                new SqlParameter("@ConsultaId", evaluacion.Consulta != null ? (object)evaluacion.Consulta.Id : DBNull.Value),
                new SqlParameter("@FrecuenciaCardiaca", evaluacion.FrecuenciaCardiaca.HasValue ? (object)evaluacion.FrecuenciaCardiaca.Value : DBNull.Value),
                new SqlParameter("@Temperatura", evaluacion.Temperatura.HasValue ? (object)evaluacion.Temperatura.Value : DBNull.Value),
                new SqlParameter("@SaturacionOxigeno", evaluacion.SaturacionOxigeno.HasValue ? (object)evaluacion.SaturacionOxigeno.Value : DBNull.Value),
                new SqlParameter("@PresionArterial", !string.IsNullOrWhiteSpace(evaluacion.PresionArterial) ? (object)evaluacion.PresionArterial : DBNull.Value),
                new SqlParameter("@SintomasObservados", !string.IsNullOrWhiteSpace(evaluacion.SintomasObservados) ? (object)evaluacion.SintomasObservados : DBNull.Value),
                new SqlParameter("@EsConsultaAdministrativa", evaluacion.EsConsultaAdministrativa),
                new SqlParameter("@NivelPrioridadIdSugerido", (int)evaluacion.PrioridadSugerida),
                new SqlParameter("@NivelPrioridadIdFinal", (int)evaluacion.PrioridadFinal),
                new SqlParameter("@JustificacionCambio", !string.IsNullOrWhiteSpace(evaluacion.JustificacionCambio) ? (object)evaluacion.JustificacionCambio : DBNull.Value),
                new SqlParameter("@UsuarioId", evaluacion.Enfermero != null ? (object)evaluacion.Enfermero.Id : DBNull.Value),
                new SqlParameter("@FechaEvaluacion", evaluacion.FechaEvaluacion),
            };

            object resultado = dao.ExecuteScalarFunction(sql, parametros);
            evaluacion.Id = Convert.ToInt32(resultado);
            return evaluacion.Id;
        }

        public static EvaluacionEnfermeria ObtenerPorConsultaId(int consultaId)
        {
            DAO dao = new DAO();
            string sql = @"
                SELECT 
                    EvaluacionEnfermeria_Id,
                    EvaluacionEnfermeria_ConsultaId,
                    EvaluacionEnfermeria_FrecuenciaCardiaca,
                    EvaluacionEnfermeria_Temperatura,
                    EvaluacionEnfermeria_SaturacionOxigeno,
                    EvaluacionEnfermeria_PresionArterial,
                    EvaluacionEnfermeria_SintomasObservados,
                    EvaluacionEnfermeria_EsConsultaAdministrativa,
                    NivelPrioridad_IdSugerido,
                    NivelPrioridad_IdFinal,
                    EvaluacionEnfermeria_JustificacionCambio,
                    Usuario_Id,
                    EvaluacionEnfermeria_FechaEvaluacion
                FROM dbo.EvaluacionEnfermeria
                WHERE EvaluacionEnfermeria_ConsultaId = @ConsultaId;";

            var param = new SqlParameter("@ConsultaId", consultaId);
            DataSet ds = dao.ExecuteDataSet(sql, param);

            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                return MapearEvaluacion(ds.Tables[0].Rows[0]);
            }

            return null;
        }

        public static EvaluacionEnfermeria ObtenerPorId(int evaluacionId)
        {
            DAO dao = new DAO();
            string sql = @"
                SELECT 
                    EvaluacionEnfermeria_Id,
                    EvaluacionEnfermeria_ConsultaId,
                    EvaluacionEnfermeria_FrecuenciaCardiaca,
                    EvaluacionEnfermeria_Temperatura,
                    EvaluacionEnfermeria_SaturacionOxigeno,
                    EvaluacionEnfermeria_PresionArterial,
                    EvaluacionEnfermeria_SintomasObservados,
                    EvaluacionEnfermeria_EsConsultaAdministrativa,
                    NivelPrioridad_IdSugerido,
                    NivelPrioridad_IdFinal,
                    EvaluacionEnfermeria_JustificacionCambio,
                    Usuario_Id,
                    EvaluacionEnfermeria_FechaEvaluacion
                FROM dbo.EvaluacionEnfermeria
                WHERE EvaluacionEnfermeria_Id = @EvaluacionId;";

            var param = new SqlParameter("@EvaluacionId", evaluacionId);
            DataSet ds = dao.ExecuteDataSet(sql, param);

            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                return MapearEvaluacion(ds.Tables[0].Rows[0]);
            }

            return null;
        }

        public static EvaluacionEnfermeria MapearEvaluacion(DataRow row)
        {
            return new EvaluacionEnfermeria
            {
                Id = Convert.ToInt32(row["EvaluacionEnfermeria_Id"]),
                Consulta = row["EvaluacionEnfermeria_ConsultaId"] != DBNull.Value
                    ? new Consulta { Id = Convert.ToInt32(row["EvaluacionEnfermeria_ConsultaId"]) }
                    : null,
                FrecuenciaCardiaca = row["EvaluacionEnfermeria_FrecuenciaCardiaca"] != DBNull.Value
                    ? Convert.ToInt32(row["EvaluacionEnfermeria_FrecuenciaCardiaca"])
                    : (int?)null,
                Temperatura = row["EvaluacionEnfermeria_Temperatura"] != DBNull.Value
                    ? Convert.ToDecimal(row["EvaluacionEnfermeria_Temperatura"])
                    : (decimal?)null,
                SaturacionOxigeno = row["EvaluacionEnfermeria_SaturacionOxigeno"] != DBNull.Value
                    ? Convert.ToInt32(row["EvaluacionEnfermeria_SaturacionOxigeno"])
                    : (int?)null,
                PresionArterial = row["EvaluacionEnfermeria_PresionArterial"] != DBNull.Value
                    ? row["EvaluacionEnfermeria_PresionArterial"].ToString()
                    : null,
                SintomasObservados = row["EvaluacionEnfermeria_SintomasObservados"] != DBNull.Value
                    ? row["EvaluacionEnfermeria_SintomasObservados"].ToString()
                    : null,
                EsConsultaAdministrativa = row["EvaluacionEnfermeria_EsConsultaAdministrativa"] != DBNull.Value
                    && Convert.ToBoolean(row["EvaluacionEnfermeria_EsConsultaAdministrativa"]),
                PrioridadSugerida = (NivelPrioridad)Convert.ToInt32(row["NivelPrioridad_IdSugerido"]),
                PrioridadFinal = (NivelPrioridad)Convert.ToInt32(row["NivelPrioridad_IdFinal"]),
                JustificacionCambio = row["EvaluacionEnfermeria_JustificacionCambio"] != DBNull.Value
                    ? row["EvaluacionEnfermeria_JustificacionCambio"].ToString()
                    : null,
                Enfermero = row["Usuario_Id"] != DBNull.Value
                    ? new Usuario { Id = Convert.ToInt32(row["Usuario_Id"]) }
                    : null,
                FechaEvaluacion = Convert.ToDateTime(row["EvaluacionEnfermeria_FechaEvaluacion"]),
            };
        }
    }
}