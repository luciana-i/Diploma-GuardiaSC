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
    public class EmpleadoDAL
    {
     

        /// <summary>
        /// Inserta un empleado y retorna el Empleado_Id generado.
        /// </summary>
        public static int Insertar(Empleado empleado)
        {
            DAO dao = new DAO();
            string sql = @"
        INSERT INTO dbo.Empleado (
            Empleado_Dni,
            Empleado_Nombre,
            Empleado_Apellido,
            Empleado_FechaNac,
            Empleado_Telefono,
            EmpleadoUsuario_Id,
            Empleado_Matricula,
            Empleado_TipoEmpleadoId,
            Empleado_Activo
        )
        VALUES (
            @Dni,
            @Nombre,
            @Apellido,
            @FechaNac,
            @Telefono,
            @UsuarioId,
            @Matricula,
            @TipoEmpleadoId,
            @Activo
        );
        SELECT CAST(SCOPE_IDENTITY() AS INT);";

            var parametros = new SqlParameter[]
            {
        // Campos heredados de Persona
        new SqlParameter("@Dni", !string.IsNullOrWhiteSpace(empleado.Dni) ? (object)empleado.Dni : DBNull.Value),
        new SqlParameter("@Nombre", !string.IsNullOrWhiteSpace(empleado.Nombre) ? (object)empleado.Nombre : DBNull.Value),
        new SqlParameter("@Apellido", !string.IsNullOrWhiteSpace(empleado.Apellido) ? (object)empleado.Apellido : DBNull.Value),
        new SqlParameter("@FechaNac", empleado.FechaNacimiento.HasValue ? (object)empleado.FechaNacimiento.Value : DBNull.Value),
        new SqlParameter("@Telefono", !string.IsNullOrWhiteSpace(empleado.Telefono) ? (object)empleado.Telefono : DBNull.Value),
        
        // Campos propios de Empleado
        new SqlParameter("@UsuarioId", empleado.EmpleadoUsuario != null ? (object)empleado.EmpleadoUsuario.Id : DBNull.Value),
        new SqlParameter("@Matricula", !string.IsNullOrWhiteSpace(empleado.Matricula) ? (object)empleado.Matricula : DBNull.Value),
        new SqlParameter("@TipoEmpleadoId", (int)empleado.TipoEmpleado),
        new SqlParameter("@Activo", empleado.Activo)
            };

            object resultado = dao.ExecuteScalarFunction(sql, parametros);
            empleado.Id = Convert.ToInt32(resultado);
            return empleado.Id;
        }

        /// <summary>
        /// Actualiza los datos de un empleado.
        /// </summary>
        public static void Actualizar(Empleado empleado)
        {
            DAO dao = new DAO();
            string sql = @"
                UPDATE dbo.Empleado
                SET EmpleadoUsuario_Id = @UsuarioId,
                    Empleado_Matricula = @Matricula,
                    Empleado_TipoEmpleadoId = @TipoEmpleadoId,
                    Empleado_Activo = @Activo
                WHERE Empleado_Id = @Empleado_Id;";

            var parametros = new SqlParameter[]
            {
                new SqlParameter("@Empleado_Id", empleado.Id),
                new SqlParameter("@UsuarioId", empleado.EmpleadoUsuario != null ? (object)empleado.EmpleadoUsuario.Id : DBNull.Value),
                new SqlParameter("@Matricula", !string.IsNullOrWhiteSpace(empleado.Matricula) ? (object)empleado.Matricula : DBNull.Value),
                new SqlParameter("@TipoEmpleadoId", (int)empleado.TipoEmpleado),
                new SqlParameter("@Activo", empleado.Activo)
            };

            dao.ExecuteNonQueryFuntion(sql, parametros);
        }

        /// <summary>
        /// Obtiene un empleado por su ID con los datos de su cuenta de usuario vinculada si existe.
        /// </summary>
        public static Empleado ObtenerPorId(int empleadoId)
        {
            DAO dao = new DAO();
            string sql = @"
                SELECT 
                    e.Empleado_Id,
                    e.EmpleadoUsuario_Id,
                    e.Empleado_Matricula,
                    e.Empleado_TipoEmpleadoId,
                    e.Empleado_Activo,
                    u.Usuario_Username,
                    u.Usuario_Mail
                FROM dbo.Empleado e
                LEFT JOIN dbo.Usuario u ON e.EmpleadoUsuario_Id = u.Usuario_ID
                WHERE e.Empleado_Id = @Empleado_Id;";

            var param = new SqlParameter("@Empleado_Id", empleadoId);
            DataSet ds = dao.ExecuteDataSet(sql, param);

            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                return MapearEmpleado(ds.Tables[0].Rows[0]);
            }

            return null;
        }

        /// <summary>
        /// Lista empleados activos filtrados por tipo (Médicos o Enfermeros).
        /// </summary>
        public static List<Empleado> ListarPorTipo(TipoEmpleadoEnum tipo)
        {
            DAO dao = new DAO();
            var lista = new List<Empleado>();
            string sql = @"
                SELECT 
                    e.Empleado_Id,
                    e.EmpleadoUsuario_Id,
                    e.Empleado_Matricula,
                    e.Empleado_TipoEmpleadoId,
                    e.Empleado_Activo,
                    u.Usuario_Username,
                    u.Usuario_Mail
                FROM dbo.Empleado e
                LEFT JOIN dbo.Usuario u ON e.EmpleadoUsuario_Id = u.Usuario_ID
                WHERE e.Empleado_TipoEmpleadoId = @TipoId AND e.Empleado_Activo = 1;";

            var param = new SqlParameter("@TipoId", (int)tipo);
            DataSet ds = dao.ExecuteDataSet(sql, param);

            if (ds != null && ds.Tables.Count > 0)
            {
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    lista.Add(MapearEmpleado(row));
                }
            }

            return lista;
        }

        private static Empleado MapearEmpleado(DataRow row)
        {
            var emp = new Empleado
            {
                Id = Convert.ToInt32(row["Empleado_Id"]),
                Matricula = row["Empleado_Matricula"] != DBNull.Value ? row["Empleado_Matricula"].ToString() : null,
                TipoEmpleado = (TipoEmpleadoEnum)Convert.ToInt32(row["Empleado_TipoEmpleadoId"]),
                Activo = row["Empleado_Activo"] != DBNull.Value && Convert.ToBoolean(row["Empleado_Activo"])
            };

            // Si tiene usuario asociado en la base
            if (row["EmpleadoUsuario_Id"] != DBNull.Value)
            {
                emp.EmpleadoUsuario = new Usuario
                {
                    Id = Convert.ToInt32(row["EmpleadoUsuario_Id"]),
                    Username = row.Table.Columns.Contains("Usuario_Username") && row["Usuario_Username"] != DBNull.Value
                        ? row["Usuario_Username"].ToString()
                        : string.Empty,
                    Mail = row.Table.Columns.Contains("Usuario_Mail") && row["Usuario_Mail"] != DBNull.Value
                        ? row["Usuario_Mail"].ToString()
                        : string.Empty
                };

                emp.Nombre = emp.EmpleadoUsuario.Username;
            }

            return emp;
        }

        public static Empleado ObtenerPorUsuarioId(int usuarioId)
        {
            DAO dao = new DAO();
            string sql = @"
            SELECT 
            e.Empleado_Id,
            e.EmpleadoUsuario_Id,
            e.Empleado_Matricula,
            e.Empleado_TipoEmpleadoId,
            e.Empleado_Activo,
            u.Usuario_Username,
            u.Usuario_Mail
            FROM dbo.Empleado e
            INNER JOIN dbo.Usuario u ON e.EmpleadoUsuario_Id = u.Usuario_ID
            WHERE e.EmpleadoUsuario_Id = @UsuarioId;";

            var param = new SqlParameter("@UsuarioId", usuarioId);
            DataSet ds = dao.ExecuteDataSet(sql, param);

            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                return MapearEmpleado(ds.Tables[0].Rows[0]);
            }

            return null;
        }
    }
}
