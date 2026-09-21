using BE;
using System;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class AtencionMedicaDAL
    {
        /// <summary>
        /// Registra el inicio de atención médica para un paciente en box/consultorio.
        /// Retorna el AtencionMedica_Id generado por la base de datos.
        /// </summary>
        public static int Insertar(AtencionMedica atencion)
        {
            DAO dao = new DAO();
            string sql = @"
                INSERT INTO dbo.AtencionMedica (
                    Consulta_Id,
                    AtencionMedica_UsuarioId,
                    AtencionMedica_FechaInicio,
                    AtencionMedica_FechaFin,
                    AtencionMedica_Diagnostico,
                    AtencionMedica_Indicaciones,
                    AtencionMedica_Destino
                )
                VALUES (
                    @ConsultaId,
                    @UsuarioId,
                    @FechaInicio,
                    @FechaFin,
                    @Diagnostico,
                    @Indicaciones,
                    @Destino
                );
                SELECT CAST(SCOPE_IDENTITY() AS INT);";

            var parametros = new SqlParameter[]
            {
                new SqlParameter("@ConsultaId", atencion.Consulta != null ? (object)atencion.Consulta.Id : DBNull.Value),
                new SqlParameter("@UsuarioId", atencion.Medico != null ? (object)atencion.Medico.Id : DBNull.Value),
                new SqlParameter("@FechaInicio", atencion.FechaInicio),
                new SqlParameter("@FechaFin", (object)atencion.FechaFin ?? DBNull.Value),
                new SqlParameter("@Diagnostico", atencion.Diagnostico ?? string.Empty),
                new SqlParameter("@Indicaciones", (object)atencion.Indicaciones ?? DBNull.Value),
                new SqlParameter("@Destino", atencion.Destino ?? string.Empty),
            };

            object resultado = dao.ExecuteScalarFunction(sql, parametros);
            atencion.Id = Convert.ToInt32(resultado);
            return atencion.Id;
        }

        /// <summary>
        /// Finaliza la atención médica con el diagnóstico final, indicaciones y destino.
        /// </summary>
        public static void FinalizarAtencion(AtencionMedica atencion)
        {
            DAO dao = new DAO();
            string sql = @"
                UPDATE dbo.AtencionMedica
                SET AtencionMedica_FechaFin = @FechaFin,
                    AtencionMedica_Diagnostico = @Diagnostico,
                    AtencionMedica_Indicaciones = @Indicaciones,
                    AtencionMedica_Destino = @Destino
                WHERE AtencionMedica_Id = @AtencionMedicaId;";

            var parametros = new SqlParameter[]
            {
                new SqlParameter("@AtencionMedicaId", atencion.Id),
                new SqlParameter("@FechaFin", atencion.FechaFin ?? DateTime.Now),
                new SqlParameter("@Diagnostico", atencion.Diagnostico ?? string.Empty),
                new SqlParameter("@Indicaciones", (object)atencion.Indicaciones ?? DBNull.Value),
                new SqlParameter("@Destino", atencion.Destino ?? string.Empty),
            };

            dao.ExecuteNonQueryFuntion(sql, parametros);
        }

        /// <summary>
        /// Obtiene la atención médica asociada a una consulta específica.
        /// </summary>
        public static AtencionMedica ObtenerPorConsultaId(int consultaId)
        {
            DAO dao = new DAO();
            string sql = @"
                SELECT 
                    AtencionMedica_Id,
                    Consulta_Id,
                    AtencionMedica_UsuarioId,
                    AtencionMedica_FechaInicio,
                    AtencionMedica_FechaFin,
                    AtencionMedica_Diagnostico,
                    AtencionMedica_Indicaciones,
                    AtencionMedica_Destino
                FROM dbo.AtencionMedica
                WHERE Consulta_Id = @ConsultaId;";

            var param = new SqlParameter("@ConsultaId", consultaId);
            DataSet ds = dao.ExecuteDataSet(sql, param);

            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                return MapearAtencion(ds.Tables[0].Rows[0]);
            }

            return null;
        }

        /// <summary>
        /// Obtiene una atención médica por su clave primaria directa.
        /// </summary>
        public static AtencionMedica ObtenerPorId(int atencionMedicaId)
        {
            DAO dao = new DAO();
            string sql = @"
                SELECT 
                    AtencionMedica_Id,
                    Consulta_Id,
                    AtencionMedica_UsuarioId,
                    AtencionMedica_FechaInicio,
                    AtencionMedica_FechaFin,
                    AtencionMedica_Diagnostico,
                    AtencionMedica_Indicaciones,
                    AtencionMedica_Destino
                FROM dbo.AtencionMedica
                WHERE AtencionMedica_Id = @AtencionMedicaId;";

            var param = new SqlParameter("@AtencionMedicaId", atencionMedicaId);
            DataSet ds = dao.ExecuteDataSet(sql, param);

            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                return MapearAtencion(ds.Tables[0].Rows[0]);
            }

            return null;
        }

        public static AtencionMedica MapearAtencion(DataRow row)
        {
            return new AtencionMedica
            {
                Id = Convert.ToInt32(row["AtencionMedica_Id"]),
                FechaInicio = Convert.ToDateTime(row["AtencionMedica_FechaInicio"]),
                FechaFin = row["AtencionMedica_FechaFin"] != DBNull.Value ? Convert.ToDateTime(row["AtencionMedica_FechaFin"]) : (DateTime?)null,
                Diagnostico = row["AtencionMedica_Diagnostico"] != DBNull.Value ? row["AtencionMedica_Diagnostico"].ToString() : string.Empty,
                Indicaciones = row["AtencionMedica_Indicaciones"] != DBNull.Value ? row["AtencionMedica_Indicaciones"].ToString() : null,
                Destino = row["AtencionMedica_Destino"] != DBNull.Value ? row["AtencionMedica_Destino"].ToString() : string.Empty,

                // Mapeo orientado a objetos:
                Consulta = row["Consulta_Id"] != DBNull.Value ? new Consulta { Id = Convert.ToInt32(row["Consulta_Id"]) } : null,
                Medico = row["AtencionMedica_UsuarioId"] != DBNull.Value ? new Usuario { Id = Convert.ToInt32(row["AtencionMedica_UsuarioId"]) } : null
            };
        }
    }
}