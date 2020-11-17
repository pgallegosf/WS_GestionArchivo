using System.Web.Http;
using OpeCar.GestionDocumental.Models.Entities;
using OpeCar.GestionDocumental.Models.Infrastructure.Repositories;

namespace OpeCar.GestionDocumental.Controllers
{
    public class LogController : ApiController
    {
        [HttpPost]
        [Route("api/Log/Listar")]
        public IHttpActionResult Listar([FromBody] ELogRequest request)
        {
            var resul = DLog.Listar(request);
            return Ok(resul);
        }
        [HttpPost]
        [Route("api/Log/Registrar")]
        public IHttpActionResult Registrar([FromBody] ELogRequest request)
        {
            var resul = DLog.Registrar(request);
            return Ok(resul);
        }
    }
}
