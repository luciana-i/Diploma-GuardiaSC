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
        private readonly DAO _dao;

        public EmpleadoDAL()
        {
            _dao = new DAO();
        }

        public EmpleadoDAL(DAO dao)
        {
            _dao = dao;
        }

        /// <summary>
        /// Inserta un empleado y retorna el Empleado_Id generado.
        /// </summary>
        public int Insertar(Empleado empleado)
        {
            string sql = @"
                INSERT INTO dbo.Empleado (
                    EmpleadoUsuario_Id,
                    Empleado_Matricula,
                    Empleado_TipoEmpleadoId,
                    Empleado_Activo
                )
                VALUES (
                    @UsuarioId,
                    @Matricula,
                    @TipoEmpleadoId,
                    @Activo
                );
                SELECT CAST(SCOPE_IDENTITY() AS INT);";

            var parametros = new SqlParameter[]
            {
                new SqlParameter("@UsuarioId", empleado.EmpleadoUsuario != null ? (object)empleado.EmpleadoUsuario.Id : DBNull.Value),
                new SqlParameter("@Matricula", !string.IsNullOrWhiteSpace(empleado.Matricula) ? (object)empleado.Matricula : DBNull.Value),
                new SqlParameter("@TipoEmpleadoId", (int)empleado.TipoEmpleado),
                new SqlParameter("@Activo", empleado.Activo)
            };

            object resultado = _dao.ExecuteScalarFunction(sql, parametros);
            empleado.Id = Convert.ToInt32(resultado);
            return empleado.Id;
        }

        /// <summary>
        /// Actualiza los datos de un empleado.
        /// </summary>
        public void Actualizar(Empleado empleado)
        {
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

            _dao.ExecuteNonQueryFuntion(sql, parametros);
        }

        /// <summary>
        /// Obtiene un empleado por su ID con los datos de su cuenta de usuario vinculada si existe.
        /// </summary>
        public Empleado ObtenerPorId(int empleadoId)
        {
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
            DataSet ds = _dao.ExecuteDataSet(sql, param);

            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                return MapearEmpleado(ds.Tables[0].Rows[0]);
            }

            return null;
        }

        /// <summary>
        /// Obtiene el registro de empleado vinculado a un usuario logueado en el sistema.
        /// </summary>
        public Empleado ObtenerPorUsuarioId(int usuarioId)
        {
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
            DataSet ds = _dao.ExecuteDataSet(sql, param);

            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                return MapearEmpleado(ds.Tables[0].Rows[0]);
            }

            return null;
        }

        /// <summary>
        /// Lista empleados activos filtrados por tipo (Médicos o Enfermeros).
        /// </summary>
        public List<Empleado> ListarPorTipo(TipoEmpleadoEnum tipo)
        {
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
            DataSet ds = _dao.ExecuteDataSet(sql, param);

            if (ds != null && ds.Tables.Count > 0)
            {
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    lista.Add(MapearEmpleado(row));
                }
            }

            return lista;
        }

        private Empleado MapearEmpleado(DataRow row)
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
    }
}
