using Cinestar_WebApi.Models;
using Cinestar_WebApi.Config;
using System.Data;
using Microsoft.Data.SqlClient;

namespace Cinestar_WebApi.DAO
{
    public class CinestarDao : ICinestarDao
    {
        private readonly clsBD _bd;
        public CinestarDao(clsBD bd) => _bd = bd;

        public List<Cine> getCines()
        {
            DataTable dt = _bd.getDataTable("sp_getCines");
            List<Cine> cines = new();

            foreach(DataRow row in dt.Rows)
            {
                cines.Add(new Cine
                {
                    idCine = (int)row["id"],
                    RazonSocial = row["RazonSocial"].ToString().Trim(),
                    Salas = (int)row["Salas"],
                    idDistrito = (int)row["idDistrito"],
                    Direccion = row["Direccion"].ToString().Trim(),
                    Telefonos = row["Telefonos"].ToString().Trim(),
                    Detalle = row["Detalle"].ToString().Trim()
                });
            }
            return cines;
        }

        public Cine getCine(int id)
        {
            List<SqlParameter> parametros = new() { new SqlParameter("@id", id) };
            DataTable dt = _bd.getDataTable("sp_getCine", parametros);
            if (dt.Rows.Count == 0) return null;

            DataRow row = dt.Rows[0];
            return new Cine
            {
                idCine = (int)row["id"],
                RazonSocial = row["RazonSocial"].ToString().Trim(),
                Salas = (int)row["Salas"],
                idDistrito = (int)row["idDistrito"],
                Direccion = row["Direccion"].ToString().Trim(),
                Telefonos = row["Telefonos"].ToString().Trim(),
                Detalle = row["Detalle"].ToString().Trim()
            };
        }

        
    }
}
