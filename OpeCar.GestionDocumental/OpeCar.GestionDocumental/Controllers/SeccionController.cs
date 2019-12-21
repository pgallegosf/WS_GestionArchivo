using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Net.Http.Headers;

using OpeCar.GestionDocumental.Models.Entities;
using OpeCar.GestionDocumental.Models.Infrastructure.Repositories;
using System.Web;

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

        // We implement MultipartFormDataStreamProvider to override the filename of File which
        // will be stored on server, or else the default name will be of the format like Body-
        // Part_{GUID}. In the following implementation we simply get the FileName from 
        // ContentDisposition Header of the Request Body.
        public class CustomMultipartFormDataStreamProvider : MultipartFormDataStreamProvider
        {
            public CustomMultipartFormDataStreamProvider(string path) : base(path) { }

            public override string GetLocalFileName(HttpContentHeaders headers)
            {
                return headers.ContentDisposition.FileName.Replace("\"", string.Empty);
            }
        }
    }
}
