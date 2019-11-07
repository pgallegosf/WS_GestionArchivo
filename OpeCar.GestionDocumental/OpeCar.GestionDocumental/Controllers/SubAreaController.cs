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
    public class SubAreaController : ApiController
    {
        [HttpGet]
        [Route("api/SubArea/Listar/{idArea}")]
        public IHttpActionResult Listar(int idArea)
        {
            var resul = DSubArea.Listar(idArea);
            return Ok(resul);
        }

        [HttpPost]
        [Route("api/SubArea/Registrar")]
        public IHttpActionResult Registrar([FromBody] ESubAreaRequest request)
        {
            var resul = DSubArea.Registrar(request);
            return Ok(resul);
        }
        [HttpPost]
        [Route("api/SubArea/Eliminar")]
        public IHttpActionResult Eliminar([FromBody] ESubAreaRequest request)
        {
            var resul = DSubArea.Eliminar(request);
            return Ok(resul);
        }
        [HttpPost]
        [Route("api/SubArea/Editar")]
        public IHttpActionResult Editar([FromBody] ESubAreaRequest request)
        {
            var resul = DSubArea.Editar(request);
            return Ok(resul);
        }
    }
}
