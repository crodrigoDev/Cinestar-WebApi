using Cinestar_WebApi.Models;
using System.Data;

namespace Cinestar_WebApi.Mapper
{
    public static class CinestarMapper
    {
        public static Cine CineMap(DataRow row)
        {
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
        public static CinePelicula CinePeliculasMap(DataRow row)
        {
            return new CinePelicula
            {
                Titulo = row["Titulo"].ToString().Trim(),
                Horarios = row["Horarios"].ToString().Trim()
            };
        }

        public static CineTarifa CineTarifaMap(DataRow row)
        {
            return new CineTarifa
            {
                DiasSemana = row["DiasSemana"].ToString().Trim(),
                Precio = row["Precio"].ToString().Trim()
            };
        }
    }
}
