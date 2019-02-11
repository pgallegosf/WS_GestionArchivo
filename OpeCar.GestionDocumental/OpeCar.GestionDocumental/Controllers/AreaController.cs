using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using OpeCar.GestionDocumental.Models.Infrastructure.Repositories;

namespace OpeCar.GestionDocumental.Controllers
{
    public class AreaController : ApiController
    {
        [HttpGet]
        [Route("api/Area/Listar/{idTipo}")]
        public IHttpActionResult Listar(int idTipo)
        {
            var resul = DArea.Listar(idTipo);
            return Ok(resul);
        }
    }
}
