using System.Web.Http;
using OpeCar.GestionDocumental.Models.Entities;
using OpeCar.GestionDocumental.Models.Infrastructure.Repositories;

namespace OpeCar.GestionDocumental.Controllers
{
    public class EnlaceController : ApiController
    {
        [HttpGet]
        [Route("api/Enlace/Listar")]
        public IHttpActionResult Listar()
        {
            var resul = DEnlace.Listar();
            return Ok(resul);
        }

        [HttpPost]
        [Route("api/Enlace/Registrar")]
        public IHttpActionResult Registrar([FromBody] EEnlaceRequest request)
        {
            var resul = DEnlace.Registrar(request);
            return Ok(resul);
        }

        [HttpPost]
        [Route("api/Enlace/Eliminar")]
        public IHttpActionResult Eliminar(EEnlaceRequest request)
        {
            var resul = DEnlace.Eliminar(request);
            return Ok(resul);
        }
    }
}
