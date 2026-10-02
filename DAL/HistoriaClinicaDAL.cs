using BE;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class HistoriaClinicaDAL
    {
        /// <summary>
        /// Inserta una entrada de antecedente/historia clínica vinculada al paciente.
        /// Retorna el HistoriaClinica_Id generado.
        /// </summary>
        public static int Insertar(HistoriaClinica hc)
        {
            DAO dao = new DAO();
            string sql = @"
                INSERT INTO dbo.HistoriaClinica (
                    Paciente_Id,
                    HistoriaClinica_FechaAtencion,
                    HistoriaClinica_Antecedente,
                    HistoriaClinica_Observacion,
                    HistoriaClinica_Alergias
                )
                VALUES (
                    @PacienteId,
                    @FechaAtencion,
                    @Antecedente,
                    @Observacion,
                    @Alergias
                );
                SELECT CAST(SCOPE_IDENTITY() AS INT);";

            var parametros = new SqlParameter[]
            {
                new SqlParameter("@PacienteId", hc.Paciente != null ? (object)hc.Paciente.Id : DBNull.Value),
                new SqlParameter("@FechaAtencion", hc.FechaAtencion),
                new SqlParameter("@Antecedente", hc.Antecedente ?? string.Empty),
                new SqlParameter("@Observacion", (object)hc.Observacion ?? DBNull.Value),
                new SqlParameter("@Alergias", (object)hc.Alergias ?? DBNull.Value)
            };

            object resultado = dao.ExecuteScalarFunction(sql, parametros);
            hc.Id = Convert.ToInt32(resultado);
            return hc.Id;
        }

        /// <summary>
        /// Obtiene todos los registros de antecedentes de la historia clínica de un paciente.
        /// </summary>
        public static List<HistoriaClinica> ListarPorPacienteId(int pacienteId)
        {
            DAO dao = new DAO();
            var lista = new List<HistoriaClinica>();

            string sql = @"
                SELECT 
                    hc.HistoriaClinica_Id,
                    hc.Paciente_Id,
                    hc.HistoriaClinica_FechaAtencion,
                    hc.HistoriaClinica_Antecedente,
                    hc.HistoriaClinica_Observacion,
                    hc.HistoriaClinica_Alergias,
                    p.Paciente_dni,
                    p.Paciente_nombre,
                    p.Paciente_fecha_nac,
                    p.Paciente_telefono
                FROM dbo.HistoriaClinica hc
                INNER JOIN dbo.Paciente p ON hc.Paciente_Id = p.Paciente_Id
                WHERE hc.Paciente_Id = @PacienteId
                ORDER BY hc.HistoriaClinica_FechaAtencion DESC;";

            var param = new SqlParameter("@PacienteId", pacienteId);
            DataSet ds = dao.ExecuteDataSet(sql, param);

            if (ds != null && ds.Tables.Count > 0)
            {
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    lista.Add(MapearHistoriaClinica(row));
                }
            }

            return lista;
        }


        public static HistoriaClinica ObtenerPorPaciente(int pacienteId)
        {
            DAO dao = new DAO();
            string sql = @"
                SELECT 
                    hc.HistoriaClinica_Id,
                    hc.Paciente_Id,
                    hc.HistoriaClinica_FechaAtencion,
                    hc.HistoriaClinica_Antecedente,
                    hc.HistoriaClinica_Observacion,
                    hc.HistoriaClinica_Alergias,
                    p.Paciente_dni,
                    p.Paciente_nombre,
                    p.Paciente_fecha_nac,
                    p.Paciente_telefono
                FROM dbo.HistoriaClinica hc
                INNER JOIN dbo.Paciente p ON hc.Paciente_Id = p.Paciente_Id
                WHERE hc.Paciente_Id = @Paciente_Id;";

            var param = new SqlParameter("@Paciente_Id", pacienteId);
            DataSet ds = dao.ExecuteDataSet(sql, param);

            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                return MapearHistoriaClinica(ds.Tables[0].Rows[0]);
            }

            return null;
        }

        public static void Actualizar(HistoriaClinica hc)
        {

            DAO dao = new DAO();
            string sql = @"
                UPDATE dbo.HistoriaClinica
                SET Paciente_Id = @PacienteId,
                    HistoriaClinica_FechaAtencion = @FechaAtencion,
                    HistoriaClinica_Antecedente = @Antecedente,
                    HistoriaClinica_Observacion = @Observacion,
                    HistoriaClinica_Alergias = @Alergias
                WHERE HistoriaClinica_Id = @HistoriaClinicaId;";

            var parametros = new SqlParameter[]
            {
                new SqlParameter("@HistoriaClinicaId", hc.Id),
                new SqlParameter("@PacienteId", hc.Paciente != null ? (object)hc.Paciente.Id : DBNull.Value),
                new SqlParameter("@FechaAtencion", hc.FechaAtencion),
                new SqlParameter("@Antecedente", hc.Antecedente ?? string.Empty),
                new SqlParameter("@Observacion", (object)hc.Observacion ?? DBNull.Value),
                new SqlParameter("@Alergias", (object)hc.Alergias ?? DBNull.Value),
            };

            dao.ExecuteNonQueryFuntion(sql, parametros);
        }

        public static HistoriaClinica MapearHistoriaClinica(DataRow row)
        {
            return new HistoriaClinica
            {
                Id = Convert.ToInt32(row["HistoriaClinica_Id"]),
                FechaAtencion = Convert.ToDateTime(row["HistoriaClinica_FechaAtencion"]),
                Antecedente = row["HistoriaClinica_Antecedente"].ToString(),
                Observacion = row["HistoriaClinica_Observacion"] != DBNull.Value ? row["HistoriaClinica_Observacion"].ToString() : null,
                Alergias = row["HistoriaClinica_Alergias"] != DBNull.Value ? row["HistoriaClinica_Alergias"].ToString() : null,
                Paciente = new Paciente
                {
                    Id = Convert.ToInt32(row["Paciente_Id"]),
                    Dni = row.Table.Columns.Contains("Paciente_dni") && row["Paciente_dni"] != DBNull.Value ? row["Paciente_dni"].ToString() : string.Empty,
                    Nombre = row.Table.Columns.Contains("Paciente_nombre") && row["Paciente_nombre"] != DBNull.Value ? row["Paciente_nombre"].ToString() : string.Empty,
                    FechaNacimiento = row.Table.Columns.Contains("Paciente_fecha_nac") && row["Paciente_fecha_nac"] != DBNull.Value ? Convert.ToDateTime(row["Paciente_fecha_nac"]) : (DateTime?)null,
                    Telefono = row.Table.Columns.Contains("Paciente_telefono") && row["Paciente_telefono"] != DBNull.Value ? row["Paciente_telefono"].ToString() : string.Empty
                }
            };
        }
    }
}