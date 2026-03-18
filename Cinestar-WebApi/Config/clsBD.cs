using System.Data;
using Microsoft.Data.SqlClient;

namespace Cinestar_WebApi.Config
{
    public class clsBD
    {
        private readonly string _cadenaConexion;

        public clsBD(IConfiguration config) => _cadenaConexion = config.GetConnectionString("AzureConnection");

        internal DataTable getDataTable(string query, List<SqlParameter> parameters = null)
        {
            DataTable dt = new();
            using SqlConnection cn = new(_cadenaConexion);
            using SqlCommand cmd = new(query, cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandTimeout = 200;

            if (parameters != null) cmd.Parameters.AddRange([.. parameters]);

            using SqlDataAdapter da = new(cmd);

            da.Fill(dt);

            return dt;
        }
    }
}
