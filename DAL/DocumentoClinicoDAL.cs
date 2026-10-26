using BE;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DocumentoClinicoDAL
    {
        /// <summary>
        /// Inserta un nuevo documento clínico en la base de datos (3FN).
        /// Retorna el Documento_Id generado.
        /// </summary>
        public static int Insertar(DocumentoClinico doc)
        {
            DAO dao = new DAO();
            string sql = @"
            INSERT INTO dbo.DocumentoClinico (
                Consulta_Id,
                TipoDocumento_Id,
                FechaEmision,
                Diagnostico,
                Contenido,
                Documento_RutaArchivo
            )
            VALUES (
                @ConsultaId,
                @TipoDocumentoId,
                @FechaEmision,
                @Diagnostico,
                @Contenido,
                @RutaArchivo
            );
            SELECT CAST(SCOPE_IDENTITY() AS INT);";

            var parametros = new SqlParameter[]
            {
                new SqlParameter("@ConsultaId", doc.ConsultaId),
                new SqlParameter("@TipoDocumentoId", (int)doc.Tipo),
                new SqlParameter("@FechaEmision", doc.FechaEmision),
                new SqlParameter("@Diagnostico", string.IsNullOrWhiteSpace(doc.Diagnostico) ? (object)DBNull.Value : doc.Diagnostico.Trim()),
                new SqlParameter("@Contenido", string.IsNullOrWhiteSpace(doc.Contenido) ? (object)DBNull.Value : doc.Contenido.Trim()),
                new SqlParameter("@RutaArchivo", string.IsNullOrWhiteSpace(doc.RutaArchivo) ? (object)DBNull.Value : doc.RutaArchivo.Trim())
            };

            object resultado = dao.ExecuteScalarFunction(sql, parametros);
            doc.Id = Convert.ToInt32(resultado);
            return doc.Id;
        }

        /// <summary>
        /// Obtiene todos los documentos clínicos emitidos para una consulta médica específica.
        /// </summary>
        public static List<DocumentoClinico> ListarPorConsultaId(int consultaId)
        {
            DAO dao = new DAO();
            var lista = new List<DocumentoClinico>();

            string sql = @"
                SELECT 
                    Documento_Id,
                    Consulta_Id,
                    TipoDocumento_Id,
                    FechaEmision,
                    Diagnostico,
                    Contenido, Documento_RutaArchivo
                FROM dbo.DocumentoClinico
                WHERE Consulta_Id = @ConsultaId
                ORDER BY FechaEmision DESC;";

            var param = new SqlParameter("@ConsultaId", consultaId);
            DataSet ds = dao.ExecuteDataSet(sql, param);

            if (ds != null && ds.Tables.Count > 0)
            {
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    lista.Add(MapearDocumentoClinico(row));
                }
            }

            return lista;
        }

        /// <summary>
        /// Obtiene un documento clínico puntual por su identificador único.
        /// </summary>
        public static DocumentoClinico ObtenerPorId(int documentoId)
        {
            DAO dao = new DAO();
            string sql = @"
                SELECT 
                    Documento_Id,
                    Consulta_Id,
                    TipoDocumento_Id,
                    FechaEmision,
                    Diagnostico,
                    Contenido, Documento_RutaArchivo
                FROM dbo.DocumentoClinico
                WHERE Documento_Id = @DocumentoId;";

            var param = new SqlParameter("@DocumentoId", documentoId);
            DataSet ds = dao.ExecuteDataSet(sql, param);

            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                return MapearDocumentoClinico(ds.Tables[0].Rows[0]);
            }

            return null;
        }

        public static DocumentoClinico ObtenerPorConsultaYTipo(int consultaId, TipoDocumentoClinico tipo)
        {
            DAO dao = new DAO();
            string sql = @"
                SELECT 
                    Documento_Id, Consulta_Id, TipoDocumento_Id, 
                    FechaEmision, Diagnostico, Contenido, Documento_RutaArchivo
                FROM dbo.DocumentoClinico
                WHERE Consulta_Id = @ConsultaId AND TipoDocumento_Id = @TipoId;";

            var parametros = new SqlParameter[]
            {
                new SqlParameter("@ConsultaId", consultaId),
                new SqlParameter("@TipoId", (int)tipo)
            };

            DataSet ds = dao.ExecuteDataSet(sql, parametros);

            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                return MapearDocumentoClinico(ds.Tables[0].Rows[0]);
            }

            return null;
        }

        public static void Actualizar(DocumentoClinico doc)
        {
            DAO dao = new DAO();
            string sql = @"
                UPDATE dbo.DocumentoClinico
                SET FechaEmision = @FechaEmision,
                    Diagnostico = @Diagnostico,
                    Contenido = @Contenido,
                    Documento_RutaArchivo = @RutaArchivo
                WHERE Documento_Id = @DocumentoId;";

            var parametros = new SqlParameter[]
            {
                new SqlParameter("@DocumentoId", doc.Id),
                new SqlParameter("@FechaEmision", doc.FechaEmision),
                new SqlParameter("@Diagnostico", string.IsNullOrWhiteSpace(doc.Diagnostico) ? (object)DBNull.Value : doc.Diagnostico.Trim()),
                new SqlParameter("@Contenido", string.IsNullOrWhiteSpace(doc.Contenido) ? (object)DBNull.Value : doc.Contenido.Trim()),
                new SqlParameter("@RutaArchivo", string.IsNullOrWhiteSpace(doc.RutaArchivo) ? (object)DBNull.Value : doc.RutaArchivo.Trim())
            };

            dao.ExecuteNonQueryFuntion(sql, parametros);
        }

        public static DocumentoClinico MapearDocumentoClinico(DataRow row)
        {
            return new DocumentoClinico
            {
                Id = Convert.ToInt32(row["Documento_Id"]),
                ConsultaId = Convert.ToInt32(row["Consulta_Id"]),
                Tipo = (TipoDocumentoClinico)Convert.ToInt32(row["TipoDocumento_Id"]),
                FechaEmision = Convert.ToDateTime(row["FechaEmision"]),
                Diagnostico = row["Diagnostico"] != DBNull.Value ? row["Diagnostico"].ToString() : string.Empty,
                Contenido = row["Contenido"] != DBNull.Value ? row["Contenido"].ToString() : string.Empty,
                RutaArchivo = row.Table.Columns.Contains("Documento_RutaArchivo") && row["Documento_RutaArchivo"] != DBNull.Value
                              ? row["Documento_RutaArchivo"].ToString()
                              : string.Empty
            };
        }
    }
}
