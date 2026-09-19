using BE;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class PacienteDAL
    {
        private readonly DAO _dao;

        public PacienteDAL()
        {
            _dao = new DAO();
        }

        public PacienteDAL(DAO dao)
        {
            _dao = dao;
        }

        /// <summary>
        /// Inserta un nuevo paciente y retorna el ID autogenerado.
        /// </summary>
        public int Insertar(Paciente paciente)
        {
            string sql = @"
                INSERT INTO dbo.Paciente (
                    Paciente_dni,
                    Paciente_nombre,
                    Paciente_fecha_nac,
                    Paciente_telefono,
                    DVH
                )
                VALUES (
                    @Dni,
                    @Nombre,
                    @FechaNac,
                    @Telefono,
                    @DVH
                );
                SELECT CAST(SCOPE_IDENTITY() AS INT);";

            var parametros = new SqlParameter[]
            {
                new SqlParameter("@Dni", paciente.Dni ?? (object)DBNull.Value),
                new SqlParameter("@Nombre", paciente.Nombre ?? (object)DBNull.Value),
                new SqlParameter("@FechaNac", (object)paciente.FechaNacimiento ?? DBNull.Value),
                new SqlParameter("@Telefono", (object)paciente.Telefono ?? DBNull.Value),
                new SqlParameter("@DVH", (object)paciente.DVH ?? DBNull.Value)
            };

            object resultado = _dao.ExecuteScalarFunction(sql, parametros);
            paciente.Id = Convert.ToInt32(resultado);
            return paciente.Id;
        }

        /// <summary>
        /// Actualiza los datos de un paciente existente.
        /// </summary>
        public void Actualizar(Paciente paciente)
        {
            string sql = @"
                UPDATE dbo.Paciente
                SET Paciente_dni = @Dni,
                    Paciente_nombre = @Nombre,
                    Paciente_fecha_nac = @FechaNac,
                    Paciente_telefono = @Telefono,
                    DVH = @DVH
                WHERE Paciente_Id = @Paciente_Id;";

            var parametros = new SqlParameter[]
            {
                new SqlParameter("@Paciente_Id", paciente.Id),
                new SqlParameter("@Dni", paciente.Dni ?? (object)DBNull.Value),
                new SqlParameter("@Nombre", paciente.Nombre ?? (object)DBNull.Value),
                new SqlParameter("@FechaNac", (object)paciente.FechaNacimiento ?? DBNull.Value),
                new SqlParameter("@Telefono", (object)paciente.Telefono ?? DBNull.Value),
                new SqlParameter("@DVH", (object)paciente.DVH ?? DBNull.Value)
            };

            _dao.ExecuteNonQueryFuntion(sql, parametros);
        }

        /// <summary>
        /// Busca un paciente por su DNI (usado en AdmisionGuardiaForm).
        /// </summary>
        public Paciente ObtenerPorDni(string dni)
        {
            string sql = @"
                SELECT Paciente_Id, Paciente_dni, Paciente_nombre, Paciente_fecha_nac, Paciente_telefono, DVH
                FROM dbo.Paciente
                WHERE Paciente_dni = @Dni;";

            var param = new SqlParameter("@Dni", dni);
            DataSet ds = _dao.ExecuteDataSet(sql, param);

            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                return MapearPaciente(ds.Tables[0].Rows[0]);
            }

            return null;
        }

        /// <summary>
        /// Busca un paciente por su Clave Primaria.
        /// </summary>
        public Paciente ObtenerPorId(int pacienteId)
        {
            string sql = @"
                SELECT Paciente_Id, Paciente_dni, Paciente_nombre, Paciente_fecha_nac, Paciente_telefono, DVH
                FROM dbo.Paciente
                WHERE Paciente_Id = @Paciente_Id;";

            var param = new SqlParameter("@Paciente_Id", pacienteId);
            DataSet ds = _dao.ExecuteDataSet(sql, param);

            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                return MapearPaciente(ds.Tables[0].Rows[0]);
            }

            return null;
        }

        /// <summary>
        /// Mapea un DataRow a la entidad Paciente (heredada de Persona).
        /// </summary>
        private Paciente MapearPaciente(DataRow row)
        {
            return new Paciente
            {
                Id = Convert.ToInt32(row["Paciente_Id"]),
                Dni = row["Paciente_dni"] != DBNull.Value ? row["Paciente_dni"].ToString() : string.Empty,
                Nombre = row["Paciente_nombre"] != DBNull.Value ? row["Paciente_nombre"].ToString() : string.Empty,
                FechaNacimiento = row["Paciente_fecha_nac"] != DBNull.Value
                    ? Convert.ToDateTime(row["Paciente_fecha_nac"])
                    : (DateTime?)null,
                Telefono = row["Paciente_telefono"] != DBNull.Value ? row["Paciente_telefono"].ToString() : string.Empty,
                DVH = row["DVH"] != DBNull.Value ? Convert.ToInt32(row["DVH"]) : (int?)null
            };
        }
    }
}
