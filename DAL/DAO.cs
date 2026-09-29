using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Text.Json;

namespace DAL
{

    public class DAO
    {
        private readonly string _connectionString;
        /*
                public DAO()
                {

                    _connectionString = "Data Source=WIN-O7CAF1FNCVK;Initial Catalog=Proyecto_Ing_softw;Integrated Security=True;TrustServerCertificate=True;";
                }

                protected SqlConnection GetConnection()
                {
                    return new SqlConnection(_connectionString);
                }

                public DAO(string connectionString)
                {
                    _connectionString = connectionString;
                }
                */
        public DAO()
        {
            string rutaArchivo = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "appsettings.json");
            string cadenaBase;

            if (File.Exists(rutaArchivo))
            {
                // 1. Lee el contenido del archivo JSON
                string jsonString = File.ReadAllText(rutaArchivo);

                // 2. Deserializa el JSON a un diccionario para extraer el valor
                var config = JsonSerializer.Deserialize<Dictionary<string, string>>(jsonString);
                cadenaBase = config["ConnectionString"];
            }
            else
            {
                cadenaBase = @"Data Source=.;Initial Catalog=Proyecto_Ing_softw;Integrated Security=True";
            }

            var builder = new SqlConnectionStringBuilder(cadenaBase);
            _connectionString = builder.ConnectionString;
        }
        private SqlConnection GetConnection()
        {
            return new SqlConnection(_connectionString);
        }
        public DataSet ExecuteDataSet(string sql, params SqlParameter[] parameters)
        {
            var ds = new DataSet();

            using (var cn = GetConnection())
            using (var cmd = new SqlCommand(sql, cn))
            {
                if (parameters != null && parameters.Length > 0)
                    cmd.Parameters.AddRange(parameters);

                using (var da = new SqlDataAdapter(cmd))
                {
                    da.Fill(ds);
                }
            }

            return ds;
        }


        public int ExecuteNonQueryFuntion(string sql, params SqlParameter[] parameters)
        {
            using (var cn = GetConnection())
            using (var cmd = new SqlCommand(sql, cn))
            {
                if (parameters != null && parameters.Length > 0)
                    cmd.Parameters.AddRange(parameters);

                cn.Open();
                return cmd.ExecuteNonQuery();
            }
        }

        public int ExecuteStoredProcedure(string spName, params SqlParameter[] parameters)
        {
            using (var cn = GetConnection())
            using (var cmd = new SqlCommand(spName, cn))
            {
                cmd.CommandType = CommandType.StoredProcedure;

                if (parameters != null && parameters.Length > 0)
                    cmd.Parameters.AddRange(parameters);

                cn.Open();
                return cmd.ExecuteNonQuery();
            }
        }



        public object ExecuteScalarFunction(string sql, params SqlParameter[] parameters)
        {
            using (var cn = GetConnection())
            using (var cmd = new SqlCommand(sql, cn))
            {
                if (parameters != null && parameters.Length > 0)
                    cmd.Parameters.AddRange(parameters);

                cn.Open();
                return cmd.ExecuteScalar();
            }
        }

        public int ObtenerUltimoId(string tabla)
        {
            string columnaId = tabla + "_ID";
            string sql = $"SELECT ISNULL(MAX({columnaId}), 0) FROM {tabla};";

            object value = ExecuteScalarFunction(sql);
            return Convert.ToInt32(value);
        }


        internal string Esc(string texto)
        {
            if (string.IsNullOrEmpty(texto))
                return string.Empty;

            return texto.Replace("'", "''");
        }

        internal int BoolToBit(bool valor)
        {
            return valor ? 1 : 0;
        }
    }
}

