using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using BE;

namespace DAL
{
    public class UsuarioDAL
    {

        public static int InsertarUsuario(Usuario nuevoUsuario) 
        {
            var dao = new DAO();


            string userEsc = dao.Esc(nuevoUsuario.Username);
            string passEsc = dao.Esc(nuevoUsuario.Password);
            string mailEsc = dao.Esc(nuevoUsuario.Mail);
            string idiomaValue = (nuevoUsuario.IdiomaDefault != null)
                ? nuevoUsuario.IdiomaDefault.Id.ToString()
                : "NULL";

            // Seteamos explícitamente IntentosFallidos en 0 y Bloqueado en 0 para el alta
            string sqlInsert = $@"
            INSERT INTO Usuario (
                Usuario_Username,
                Usuario_Password,
                Usuario_Mail,
                Usuario_IntentosFallidos,
                Usuario_Bloqueado,
                Usuario_IdiomaDefault,
                DVH 
            )
            VALUES (
                N'{userEsc}',
                '{passEsc}',
                '{mailEsc}',
                0,
                0,
                {idiomaValue},
                {nuevoUsuario.DVH}
            );
            SELECT SCOPE_IDENTITY();";


            object resultado = dao.ExecuteScalarFunction(sqlInsert);

            if (resultado != null && resultado != DBNull.Value)
            {
                return Convert.ToInt32(resultado);
            }

            return 0; 
        }
      
        public static Usuario ObtenerPorId(int id)
        {
            var dao = new DAO();

            string sql = $@"
            SELECT Usuario_ID, Usuario_Username, Usuario_Password, Usuario_Mail ,Usuario_IntentosFallidos, Usuario_Bloqueado, Usuario_IdiomaDefault
            FROM Usuario
            WHERE Usuario_ID = {id};";

            DataSet ds = dao.ExecuteDataSet(sql);

            if (ds.Tables.Count == 0 || ds.Tables[0].Rows.Count == 0)
                return null;

            return MapUsuario(ds.Tables[0].Rows[0]);
        }

        public static Usuario ObtenerPorNombre(string username)
        {
            var dao = new DAO();

            string sql = $@"
            SELECT Usuario_ID, Usuario_Username, Usuario_Password, Usuario_Mail,Usuario_IntentosFallidos, Usuario_Bloqueado, Usuario_IdiomaDefault
            FROM Usuario
            WHERE Usuario_Username = N'{dao.Esc(username)}';";

            DataSet ds = dao.ExecuteDataSet(sql);

            if (ds.Tables.Count == 0 || ds.Tables[0].Rows.Count == 0)
                return null;

            return MapUsuario(ds.Tables[0].Rows[0]);
        }

        public static void ActualizarPorId(Usuario usuario)
        {
            var dao = new DAO();
            int idiomaValue = (usuario.IdiomaDefault != null)
                ? usuario.IdiomaDefault.Id
                : 0;

            string sqlUpdate = $@"
            UPDATE Usuario SET
                Usuario_Username = N'{dao.Esc(usuario.Username)}',
                Usuario_Password = N'{dao.Esc(usuario.Password)}',
                Usuario_Mail = N'{dao.Esc(usuario.Mail)}', 
                Usuario_IntentosFallidos = {usuario.IntentosFallidos},
                Usuario_Bloqueado = {dao.BoolToBit(usuario.Bloqueado)},
                Usuario_IdiomaDefault = {idiomaValue},
                DVH = {usuario.DVH}
            WHERE Usuario_ID = {usuario.Id};";

            dao.ExecuteNonQueryFuntion(sqlUpdate);
        }
        // no se usa, pero no se descarta usarlo eventualmente
        public static int Eliminar(Usuario usuario)  // Elimina el usuario.
        {
            var dao = new DAO();

            string sqlDeleteRelacion = @"
        DELETE FROM Usuario_Perfil 
        WHERE Usuario_ID = @IdUsuario;";

            SqlParameter[] p1 = {
            new SqlParameter("@IdUsuario", usuario.Id)
            };

            dao.ExecuteNonQueryFuntion(sqlDeleteRelacion, p1); // primero la tabla intermedia

            string sqlDeleteUsuario = @"
        DELETE FROM Usuario 
        WHERE Usuario_ID = @IdUsuario;";

            SqlParameter[] p2 = {
        new SqlParameter("@IdUsuario", usuario.Id)
        };

            int filas = dao.ExecuteNonQueryFuntion(sqlDeleteUsuario, p2);

            return filas;
        }

        public static List<Usuario> Listar() 
        {
            var dao = new DAO();

            string sql = @"
SELECT Usuario_ID, Usuario_Username, Usuario_Password, Usuario_Mail ,Usuario_IntentosFallidos, Usuario_Bloqueado,Usuario_IdiomaDefault
FROM Usuario
ORDER BY Usuario_ID;
";
            DataSet ds = dao.ExecuteDataSet(sql);
            var lista = new List<Usuario>();

            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                lista.Add(MapUsuario(dr));
            }

            return lista;
        }

        public static long CalcularDVVUsuario() 
        {

            var dao = new DAO();

            string sqlSuma = "SELECT ISNULL(SUM(CAST(DVH AS BIGINT)), 0) FROM Usuario;";

            object resultado = dao.ExecuteScalarFunction(sqlSuma);

            return Convert.ToInt64(resultado);
        }

        public static long UpdateDvH(int id, long suma) 
        {

            var dao = new DAO();

            string sqlUpdateDVH = $@"
            UPDATE Usuario 
            SET DVH = {suma} 
            WHERE Usuario_Id = {id};";

            return dao.ExecuteNonQueryFuntion(sqlUpdateDVH);
        }


        private static Usuario MapUsuario(DataRow dr) 
        {
            return new Usuario
            {
                Id = Convert.ToInt32(dr["Usuario_ID"]),
                Username = dr["Usuario_Username"] != DBNull.Value ? dr["Usuario_Username"].ToString() : string.Empty,
                Password = dr["Usuario_Password"] != DBNull.Value ? dr["Usuario_Password"].ToString() : string.Empty,
                Mail = dr["Usuario_Mail"] != DBNull.Value ? dr["Usuario_Mail"].ToString() : string.Empty,
                IntentosFallidos = dr["Usuario_IntentosFallidos"] != DBNull.Value ? Convert.ToInt32(dr["Usuario_IntentosFallidos"]) : 0,
                Bloqueado = dr["Usuario_Bloqueado"] != DBNull.Value && Convert.ToBoolean(dr["Usuario_Bloqueado"]),
                //busco idioma si existe el default
                IdiomaDefault = dr["Usuario_IdiomaDefault"] != DBNull.Value
                ? IdiomaDAL.ListarIdiomas().FirstOrDefault(x => x.Id == Convert.ToInt32(dr["Usuario_IdiomaDefault"]))
                : null

            };
        }

        



    }
}
