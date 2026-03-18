using Cinestar_WebApi.Models;
using Cinestar_WebApi.Config;
using System.Data;
using Microsoft.Data.SqlClient;
using Cinestar_WebApi.Mapper;

namespace Cinestar_WebApi.DAO
{
    public class CinestarDao : ICinestarDao
    {
        private readonly clsBD _bd;
        public CinestarDao(clsBD bd) => _bd = bd;

        // Metodos para obtener datos de los cines
        public List<Cine> getCines()
        {
            DataTable dt = _bd.getDataTable("sp_getCines");
            List<Cine> cines = new();

            foreach(DataRow row in dt.Rows)
            {
                Cine cine = CinestarMapper.CineMap(row);
                cines.Add(cine);
            }
            return cines;
        }

        public Cine getCine(int id)
        {
            List<SqlParameter> parametros = new() { new SqlParameter("@id", id) };
            DataTable dt = _bd.getDataTable("sp_getCine", parametros);
            if (dt.Rows.Count == 0) return null;
            return CinestarMapper.CineMap(dt.Rows[0]);
        }

        public List<CinePelicula> getCinePeliculas(int id)
        {
            List<SqlParameter> parametros = new() { new SqlParameter("@idCine", id) };
            DataTable dt = _bd.getDataTable("sp_getCinePeliculas", parametros);
            List<CinePelicula> cinespeliculas = new();

            foreach(DataRow row in dt.Rows)
            {
                CinePelicula cnpeli = CinestarMapper.CinePeliculasMap(row);
                cinespeliculas.Add(cnpeli);
            }
            return cinespeliculas;
        }

        public List<CineTarifa> getCineTarifas(int id)
        {
            List<SqlParameter> parametros = new() { new SqlParameter("@idCine", id) };
            DataTable dt = _bd.getDataTable("sp_getCineTarifas", parametros);
            List<CineTarifa> cinetarifas = new();

            foreach(DataRow row in dt.Rows)
            {
                CineTarifa cntarifa = CinestarMapper.CineTarifaMap(row);
                cinetarifas.Add(cntarifa);
            }
            return cinetarifas;
        }

        // Metodos para obtener las peliculas
        public List<Pelicula> getPeliculas(int id)
        {
            List<SqlParameter> parametros = new() { new SqlParameter("@idEstado", id) };
            DataTable dt = _bd.getDataTable("sp_getPeliculas", parametros);
            List<Pelicula> peliculas = new();

            foreach(DataRow row in dt.Rows)
            {
                Pelicula pelis = CinestarMapper.PeliculaMap(row);
                peliculas.Add(pelis);
            }
            return peliculas;
        }

        public Pelicula getPelicula(int id)
        {
            List<SqlParameter> parametros = new() { new SqlParameter("@id", id) };
            DataTable dt = _bd.getDataTable("sp_getPelicula", parametros);
            if (dt.Rows.Count == 0) return null;
            return CinestarMapper.PeliculaMap(dt.Rows[0]);
        }
        
    }
}
