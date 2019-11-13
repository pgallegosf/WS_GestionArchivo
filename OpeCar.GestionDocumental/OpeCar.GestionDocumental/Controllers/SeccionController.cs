using System.Web.Http;
using OpeCar.GestionDocumental.Models.Entities;
using OpeCar.GestionDocumental.Models.Infrastructure.Repositories;

namespace OpeCar.GestionDocumental.Controllers
{
    public class SeccionController : ApiController
    {
        [HttpGet]
        [Route("api/Seccion/Listar/{idTipoSeccion}")]
        public IHttpActionResult Listar(int idTipoSeccion)
        {
            var resul = DSeccion.Listar(idTipoSeccion);
            return Ok(resul);
        }

        [HttpPost]
        [Route("api/Seccion/Registrar")]
        public IHttpActionResult Registrar([FromBody] ESeccionRequest request)
        {
            var resul = DSeccion.Registrar(request);
            return Ok(resul);
        }

        [HttpPost]
        [Route("api/Seccion/Eliminar")]
        public IHttpActionResult Eliminar(ESeccionRequest request)
        {
            var resul = DSeccion.Eliminar(request);
            return Ok(resul);
        }

        
    }
}
