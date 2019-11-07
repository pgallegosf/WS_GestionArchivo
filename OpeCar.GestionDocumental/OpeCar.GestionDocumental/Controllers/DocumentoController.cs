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
    public class DocumentoController : ApiController
    {
        [HttpGet]
        [Route("api/Documento/Listar/{idArea}")]
        public IHttpActionResult Listar(int idArea)
        {
            var resul = DDocumento.Listar(idArea);
            return Ok(resul);
        }

        [HttpPost]
        [Route("api/Documento/Registrar")]
        public IHttpActionResult Registrar([FromBody] EDocumentoRequest request)
        {
            var resul = DDocumento.Registrar(request);
            return Ok(resul);
        }
        [HttpGet]
        [Route("api/Documento/Eliminar/{idDocumento}")]
        public IHttpActionResult Eliminar(int idDocumento)
        {
            var resul = DDocumento.Eliminar(idDocumento);
            return Ok(resul);
        }
    }
}
