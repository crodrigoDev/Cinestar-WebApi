using Microsoft.AspNetCore.Mvc;
using Cinestar_WebApi.DAO;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Cinestar_WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CinestarController : ControllerBase
    {
        private readonly ICinestarDao _dao;

        public CinestarController(ICinestarDao dao) => _dao = dao;

        [HttpGet]
        public IActionResult GetCines()
        {
            var lista = _dao.getCines();
            return Ok(lista);
        }

        [HttpGet("{id}")]
        public IActionResult GetCine(int id)
        {
            var lista = _dao.getCine(id);
            return Ok(lista);
        }
    }
}
