using BE;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class PacienteDAL
    {
        public static List<Paciente> ListarPacientes()
        {
            DAO dao = new DAO();
            string sql = @"
                SELECT 
                    Paciente_Id, 
                    Paciente_dni, 
                    Paciente_nombre,
                    Paciente_apellido,
                    Paciente_fecha_nac, 
                    Paciente_telefono
                FROM dbo.Paciente
                ORDER BY Paciente_apellido ASC, Paciente_nombre ASC;";

            var ds = dao.ExecuteDataSet(sql);

            var lista = new List<Paciente>();
            if (ds != null && ds.Tables.Count > 0)
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    lista.Add(MapearPaciente(dr));
                }
            }
            return lista;
        }

        /// <summary>
        /// Inserta un nuevo paciente y retorna el ID autogenerado.
        /// </summary>
        public static int Insertar(Paciente paciente)
        {
            DAO dao = new DAO();
            string sql = @"
                INSERT INTO dbo.Paciente (
                    Paciente_dni,
                    Paciente_nombre,
                    Paciente_apellido,
                    Paciente_fecha_nac,
                    Paciente_telefono
                )
                VALUES (
                    @Dni,
                    @Nombre,
                    @Apellido,
                    @FechaNac,
                    @Telefono
                );
                SELECT CAST(SCOPE_IDENTITY() AS INT);";

            var parametros = new SqlParameter[]
            {
                new SqlParameter("@Dni", paciente.Dni ?? (object)DBNull.Value),
                new SqlParameter("@Nombre", paciente.Nombre ?? (object)DBNull.Value),
                new SqlParameter("@Apellido", paciente.Apellido ?? (object)DBNull.Value),
                new SqlParameter("@FechaNac", (object)paciente.FechaNacimiento ?? DBNull.Value),
                new SqlParameter("@Telefono", (object)paciente.Telefono ?? DBNull.Value)
            };

            object resultado = dao.ExecuteScalarFunction(sql, parametros);
            paciente.Id = Convert.ToInt32(resultado);
            return paciente.Id;
        }

        /// <summary>
        /// Actualiza los datos de un paciente existente.
        /// </summary>
        public static void Actualizar(Paciente paciente)
        {
            DAO dao = new DAO();
            string sql = @"
                UPDATE dbo.Paciente
                SET Paciente_dni = @Dni,
                    Paciente_nombre = @Nombre,
                    Paciente_apellido = @Apellido,
                    Paciente_fecha_nac = @FechaNac,
                    Paciente_telefono = @Telefono
                WHERE Paciente_Id = @Paciente_Id;";

            var parametros = new SqlParameter[]
            {
                new SqlParameter("@Paciente_Id", paciente.Id),
                new SqlParameter("@Dni", paciente.Dni ?? (object)DBNull.Value),
                new SqlParameter("@Nombre", paciente.Nombre ?? (object)DBNull.Value),
                new SqlParameter("@Apellido", paciente.Apellido ?? (object)DBNull.Value),
                new SqlParameter("@FechaNac", (object)paciente.FechaNacimiento ?? DBNull.Value),
                new SqlParameter("@Telefono", (object)paciente.Telefono ?? DBNull.Value)
            };

            dao.ExecuteNonQueryFuntion(sql, parametros);
        }

        /// <summary>
        /// Busca un paciente por su DNI (usado en AdmisionGuardiaForm).
        /// </summary>
        public static Paciente ObtenerPorDni(string dni)
        {
            DAO dao = new DAO();
            string sql = @"
                SELECT Paciente_Id, Paciente_dni, Paciente_nombre, Paciente_apellido, Paciente_fecha_nac, Paciente_telefono
                FROM dbo.Paciente
                WHERE Paciente_dni = @Dni;";

            var param = new SqlParameter("@Dni", dni);
            DataSet ds = dao.ExecuteDataSet(sql, param);

            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                return MapearPaciente(ds.Tables[0].Rows[0]);
            }

            return null;
        }

        /// <summary>
        /// Busca un paciente por su Clave Primaria.
        /// </summary>
        public static Paciente ObtenerPorId(int pacienteId)
        {
            DAO dao = new DAO();
            string sql = @"
                SELECT Paciente_Id, Paciente_dni, Paciente_nombre, Paciente_apellido, Paciente_fecha_nac, Paciente_telefono
                FROM dbo.Paciente
                WHERE Paciente_Id = @Paciente_Id;";

            var param = new SqlParameter("@Paciente_Id", pacienteId);
            DataSet ds = dao.ExecuteDataSet(sql, param);

            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                return MapearPaciente(ds.Tables[0].Rows[0]);
            }

            return null;
        }

        /// <summary>
        /// Mapea un DataRow a la entidad Paciente (heredada de Persona).
        /// </summary>
        public static Paciente MapearPaciente(DataRow row)
        {
            return new Paciente
            {
                Id = Convert.ToInt32(row["Paciente_Id"]),
                Dni = row["Paciente_dni"] != DBNull.Value ? row["Paciente_dni"].ToString() : string.Empty,
                Nombre = row["Paciente_nombre"] != DBNull.Value ? row["Paciente_nombre"].ToString() : string.Empty,
                Apellido = row.Table.Columns.Contains("Paciente_apellido") && row["Paciente_apellido"] != DBNull.Value
                    ? row["Paciente_apellido"].ToString()
                    : string.Empty,
                FechaNacimiento = row["Paciente_fecha_nac"] != DBNull.Value
                    ? Convert.ToDateTime(row["Paciente_fecha_nac"])
                    : (DateTime?)null,
                Telefono = row["Paciente_telefono"] != DBNull.Value ? row["Paciente_telefono"].ToString() : string.Empty
            };
        }
    }
}