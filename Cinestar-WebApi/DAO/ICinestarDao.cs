using Cinestar_WebApi.Models;
namespace Cinestar_WebApi.DAO
{
    public interface ICinestarDao
    {
        List<Cine> getCines();
        Cine getCine(int id);
        List<CinePelicula> getCinePeliculas(int id);
        List<CineTarifa> getCineTarifas(int id);
    }
}
