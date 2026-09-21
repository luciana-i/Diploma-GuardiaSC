using BE;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class ConsultaDAL
    {
        /// <summary>
        /// Inserta una nueva consulta/episodio en recepción y devuelve el Consulta_Id generado.
        /// </summary>
        public static int Insertar(Consulta consulta)
        {
            DAO dao = new DAO();
            string sql = @"
                INSERT INTO dbo.Consulta (
                    Consulta_PacienteId,
                    EstadoConsulta_Id,
                    Consulta_FechaIngreso,
                    Consulta_MotivoIngreso,
                    Consulta_UsuarioId
                )
                VALUES (
                    @PacienteId,
                    @EstadoId,
                    @FechaIngreso,
                    @MotivoIngreso,
                    @UsuarioId
                );
                SELECT CAST(SCOPE_IDENTITY() AS INT);";

            var parametros = new SqlParameter[]
            {
                new SqlParameter("@PacienteId", consulta.Paciente != null ? (object)consulta.Paciente.Id : DBNull.Value),
                new SqlParameter("@EstadoId", (int)consulta.EstadoConsulta),
                new SqlParameter("@FechaIngreso", consulta.FechaIngreso),
                new SqlParameter("@MotivoIngreso", consulta.MotivoIngreso ?? string.Empty),
                new SqlParameter("@UsuarioId", consulta.UsuarioIngreso != null ? (object)consulta.UsuarioIngreso.Id : DBNull.Value)
            };

            object res = dao.ExecuteScalarFunction(sql, parametros);
            consulta.Id = Convert.ToInt32(res);
            return consulta.Id;
        }

        /// <summary>
        /// Cambia el estado del episodio asistencial (En Espera, En Enfermería, Cancelado/Abandono, etc.).
        /// </summary>
        public static void CambiarEstado(int consultaId, EstadoConsulta nuevoEstado)
        {
            DAO dao = new DAO();
            string sql = @"
                UPDATE dbo.Consulta
                SET EstadoConsulta_Id = @EstadoId
                WHERE Consulta_Id = @ConsultaId;";

            var parametros = new SqlParameter[]
            {
                new SqlParameter("@ConsultaId", consultaId),
                new SqlParameter("@EstadoId", (int)nuevoEstado),
            };

            dao.ExecuteNonQueryFuntion(sql, parametros);
        }

        /// <summary>
        /// Obtiene una consulta completa con su paciente asociado por ID.
        /// </summary>
        public static Consulta ObtenerPorId(int consultaId)
        {
            DAO dao = new DAO();
            string sql = @"
                SELECT 
                    c.Consulta_Id,
                    c.Consulta_PacienteId,
                    c.EstadoConsulta_Id,
                    c.Consulta_FechaIngreso,
                    c.Consulta_MotivoIngreso,
                    c.Consulta_UsuarioId,
                    p.Paciente_dni,
                    p.Paciente_nombre,
                    p.Paciente_apellido,
                    p.Paciente_fecha_nac,
                    p.Paciente_telefono
                FROM dbo.Consulta c
                INNER JOIN dbo.Paciente p ON c.Consulta_PacienteId = p.Paciente_Id
                WHERE c.Consulta_Id = @ConsultaId;";

            var param = new SqlParameter("@ConsultaId", consultaId);
            DataSet ds = dao.ExecuteDataSet(sql, param);

            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                return MapearConsulta(ds.Tables[0].Rows[0]);
            }

            return null;
        }

        /// <summary>
        /// Obtiene todos los episodios activos para la bandeja de espera.
        /// </summary>
        public static List<Consulta> ListarConsultasActivas()
        {
            DAO dao = new DAO();
            var lista = new List<Consulta>();

            string sql = @"
                SELECT 
                    c.Consulta_Id,
                    c.Consulta_PacienteId,
                    c.EstadoConsulta_Id,
                    c.Consulta_FechaIngreso,
                    c.Consulta_MotivoIngreso,
                    c.Consulta_UsuarioId,
                    p.Paciente_dni,
                    p.Paciente_nombre,
                    p.Paciente_apellido,
                    p.Paciente_fecha_nac,
                    p.Paciente_telefono
                FROM dbo.Consulta c
                INNER JOIN dbo.Paciente p ON c.Consulta_PacienteId = p.Paciente_Id
                WHERE c.EstadoConsulta_Id IN (@EnEspera, @EnEnfermeria, @ParaAtencionMedica)
                ORDER BY c.Consulta_FechaIngreso ASC;";

            var parametros = new SqlParameter[]
            {
                new SqlParameter("@EnEspera", (int)EstadoConsulta.EnEsperaEnfermeria),
                new SqlParameter("@EnEnfermeria", (int)EstadoConsulta.EnEnfermeria),
                new SqlParameter("@ParaAtencionMedica", (int)EstadoConsulta.EnEsperaAtencionMedica)
            };

            DataSet ds = dao.ExecuteDataSet(sql, parametros);

            if (ds != null && ds.Tables.Count > 0)
            {
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    lista.Add(MapearConsulta(row));
                }
            }

            return lista;
        }

        public static List<Consulta> ListarConsultasParaAtencionMedica()
        {
            DAO dao = new DAO();
            var lista = new List<Consulta>();

            string sql = @"
        SELECT 
            c.Consulta_Id,
            c.Consulta_PacienteId,
            c.EstadoConsulta_Id,
            c.Consulta_FechaIngreso,
            c.Consulta_MotivoIngreso,
            c.Consulta_UsuarioId,
            p.Paciente_dni,
            p.Paciente_nombre,
            p.Paciente_apellido,
            p.Paciente_fecha_nac,
            p.Paciente_telefono,
            ISNULL(e.NivelPrioridad_IdFinal, 99) AS NivelPrioridad
        FROM dbo.Consulta c
        INNER JOIN dbo.Paciente p ON c.Consulta_PacienteId = p.Paciente_Id
        LEFT JOIN dbo.EvaluacionEnfermeria e ON c.Consulta_Id = e.EvaluacionEnfermeria_ConsultaId
        WHERE c.EstadoConsulta_Id = 3 -- 3: Para Atención Médica
        ORDER BY NivelPrioridad ASC, c.Consulta_FechaIngreso ASC;";

            DataSet ds = dao.ExecuteDataSet(sql);

            if (ds != null && ds.Tables.Count > 0)
            {
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    var consulta = MapearConsulta(row);

                    // Si necesitamos guardar temporalmente el nivel para mostrarlo o usarlo
                    int nivelPrioridadId = Convert.ToInt32(row["NivelPrioridad"]);

                    lista.Add(consulta);
                }
            }

            return lista;
        }

        public static Consulta MapearConsulta(DataRow row)
        {
            var consulta = new Consulta
            {
                Id = Convert.ToInt32(row["Consulta_Id"]),
                EstadoConsulta = (EstadoConsulta)Convert.ToInt32(row["EstadoConsulta_Id"]),
                FechaIngreso = Convert.ToDateTime(row["Consulta_FechaIngreso"]),
                MotivoIngreso = row["Consulta_MotivoIngreso"].ToString(),
                Paciente = new Paciente
                {
                    Id = Convert.ToInt32(row["Consulta_PacienteId"]),
                    Dni = row["Paciente_dni"] != DBNull.Value ? row["Paciente_dni"].ToString() : string.Empty,
                    Nombre = row["Paciente_nombre"] != DBNull.Value ? row["Paciente_nombre"].ToString() : string.Empty,
                    Apellido = row.Table.Columns.Contains("Paciente_apellido") && row["Paciente_apellido"] != DBNull.Value
                        ? row["Paciente_apellido"].ToString()
                        : string.Empty,
                    FechaNacimiento = row["Paciente_fecha_nac"] != DBNull.Value ? Convert.ToDateTime(row["Paciente_fecha_nac"]) : (DateTime?)null,
                    Telefono = row["Paciente_telefono"] != DBNull.Value ? row["Paciente_telefono"].ToString() : string.Empty
                }
            };

            if (row["Consulta_UsuarioId"] != DBNull.Value)
            {
                consulta.UsuarioIngreso = new Usuario
                {
                    Id = Convert.ToInt32(row["Consulta_UsuarioId"])
                };
            }

            return consulta;
        }
    }
}