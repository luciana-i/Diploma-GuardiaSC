using BE;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
    
    namespace DAL
    {
        public class ConsultaDAL
        {
            private readonly DAO _dao;
            public ConsultaDAL()
            {
                _dao = new DAO();
            }

            public ConsultaDAL(DAO dao)
            {
                _dao = dao;
            }

            /// <summary>
            /// Inserta una nueva consulta/episodio en recepción y devuelve el Consulta_Id generado.
            /// </summary>
            public int Insertar(Consulta consulta)
            {
                string sql = @"
                INSERT INTO dbo.Consulta (
                    Consulta_PacienteId,
                    EstadoConsulta_Id,
                    Consulta_FechaIngreso,
                    Consulta_MotivoIngreso,
                    Consulta_UsuarioId,
                    DVH
                )
                VALUES (
                    @PacienteId,
                    @EstadoId,
                    @FechaIngreso,
                    @MotivoIngreso,
                    @UsuarioId,
                    @DVH
                );
                SELECT CAST(SCOPE_IDENTITY() AS INT);";

                var parametros = new SqlParameter[]
                {
                new SqlParameter("@PacienteId", consulta.Paciente.Id),
                new SqlParameter("@EstadoId", (int)consulta.EstadoConsulta),
                new SqlParameter("@FechaIngreso", consulta.FechaIngreso),
                new SqlParameter("@MotivoIngreso", consulta.MotivoIngreso ?? string.Empty),
                new SqlParameter("@UsuarioId", consulta.UsuarioIngreso != null ? (object)consulta.UsuarioIngreso.Id : DBNull.Value),
                new SqlParameter("@DVH", (object)consulta.DVH ?? DBNull.Value)
                };

                object res = _dao.ExecuteScalarFunction(sql, parametros);
                consulta.Id = Convert.ToInt32(res);
                return consulta.Id;
            }

            /// <summary>
            /// Cambia el estado del episodio asistencial (En Espera, En Enfermería, Cancelado/Abandono, etc.).
            /// </summary>
            public void CambiarEstado(int consultaId, EstadoConsulta nuevoEstado, int? nuevoDVH = null)
            {
                string sql = @"
                UPDATE dbo.Consulta
                SET EstadoConsulta_Id = @EstadoId,
                    DVH = @DVH
                WHERE Consulta_Id = @ConsultaId;";

                var parametros = new SqlParameter[]
                {
                new SqlParameter("@ConsultaId", consultaId),
                new SqlParameter("@EstadoId", (int)nuevoEstado),
                new SqlParameter("@DVH", (object)nuevoDVH ?? DBNull.Value)
                };

                _dao.ExecuteNonQueryFuntion(sql, parametros);
            }

            /// <summary>
            /// Obtiene una consulta completa con su paciente asociado por ID.
            /// </summary>
            public Consulta ObtenerPorId(int consultaId)
            {
                string sql = @"
                SELECT 
                    c.Consulta_Id,
                    c.Consulta_PacienteId,
                    c.EstadoConsulta_Id,
                    c.Consulta_FechaIngreso,
                    c.Consulta_MotivoIngreso,
                    c.Consulta_UsuarioId,
                    c.DVH,
                    p.Paciente_dni,
                    p.Paciente_nombre,
                    p.Paciente_fecha_nac,
                    p.Paciente_telefono,
                    p.DVH AS Paciente_DVH
                FROM dbo.Consulta c
                INNER JOIN dbo.Paciente p ON c.Consulta_PacienteId = p.Paciente_Id
                WHERE c.Consulta_Id = @ConsultaId;";

                var param = new SqlParameter("@ConsultaId", consultaId);
                DataSet ds = _dao.ExecuteDataSet(sql, param);

                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    return MapearConsulta(ds.Tables[0].Rows[0]);
                }

                return null;
            }

            /// <summary>
            /// Obtiene todos los episodios activos para la bandeja de PacientesEnfermeriaForm.
            /// </summary>
            public List<Consulta> ListarActivos()
            {
                var lista = new List<Consulta>();

                string sql = @"
                SELECT 
                    c.Consulta_Id,
                    c.Consulta_PacienteId,
                    c.EstadoConsulta_Id,
                    c.Consulta_FechaIngreso,
                    c.Consulta_MotivoIngreso,
                    c.Consulta_UsuarioId,
                    c.DVH,
                    p.Paciente_dni,
                    p.Paciente_nombre,
                    p.Paciente_fecha_nac,
                    p.Paciente_telefono,
                    p.DVH AS Paciente_DVH
                FROM dbo.Consulta c
                INNER JOIN dbo.Paciente p ON c.Consulta_PacienteId = p.Paciente_Id
                WHERE c.EstadoConsulta_Id IN (@EnEspera, @EnEnfermeria, @ParaAtencionMedica)
                ORDER BY c.Consulta_FechaIngreso ASC;";

                var parametros = new SqlParameter[]
                {
                new SqlParameter("@EnEsperaEnfermeria", (int)EstadoConsulta.EnEsperaEnfermeria),
                new SqlParameter("@EnEnfermeria", (int)EstadoConsulta.EnEnfermeria),
                new SqlParameter("@EnEsperaAtencionMedica", (int)EstadoConsulta.EnEsperaAtencionMedica)
                };

                DataSet ds = _dao.ExecuteDataSet(sql, parametros);

                if (ds != null && ds.Tables.Count > 0)
                {
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        lista.Add(MapearConsulta(row));
                    }
                }

                return lista;
            }

            private Consulta MapearConsulta(DataRow row)
            {
                var consulta = new Consulta
                {
                    Id = Convert.ToInt32(row["Consulta_Id"]),
                    EstadoConsulta = (EstadoConsulta)Convert.ToInt32(row["EstadoConsulta_Id"]),
                    FechaIngreso = Convert.ToDateTime(row["Consulta_FechaIngreso"]),
                    MotivoIngreso = row["Consulta_MotivoIngreso"].ToString(),
                    DVH = row["DVH"] != DBNull.Value ? Convert.ToInt32(row["DVH"]) : (int?)null,
                    Paciente = new Paciente
                    {
                        Id = Convert.ToInt32(row["Consulta_PacienteId"]),
                        Dni = row["Paciente_dni"] != DBNull.Value ? row["Paciente_dni"].ToString() : string.Empty,
                        Nombre = row["Paciente_nombre"] != DBNull.Value ? row["Paciente_nombre"].ToString() : string.Empty,
                        FechaNacimiento = row["Paciente_fecha_nac"] != DBNull.Value ? Convert.ToDateTime(row["Paciente_fecha_nac"]) : (DateTime?)null,
                        Telefono = row["Paciente_telefono"] != DBNull.Value ? row["Paciente_telefono"].ToString() : string.Empty,
                        DVH = row.Table.Columns.Contains("Paciente_DVH") && row["Paciente_DVH"] != DBNull.Value ? Convert.ToInt32(row["DVH"]) : (int?)null
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
