using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using OpeCar.GestionDocumental.Models.Entities;
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

        [HttpPost]
        [Route("api/Area/Registrar")]
        public IHttpActionResult Registrar([FromBody] EAreaRequest request)
        {
            var resul = DArea.Registrar(request);
            return Ok(resul);
        }

        [HttpPost]
        [Route("api/Area/Eliminar")]
        public IHttpActionResult Eliminar(EAreaRequest request)
        {
            var resul = DArea.Eliminar(request);
            return Ok(resul);
        }

        [HttpPost]
        [Route("api/Area/Editar")]
        public IHttpActionResult Editar([FromBody] EAreaRequest request)
        {
            var resul = DArea.Editar(request);
            return Ok(resul);
        }
    }
}
