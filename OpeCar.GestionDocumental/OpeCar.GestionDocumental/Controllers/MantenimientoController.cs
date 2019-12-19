using OpeCar.GestionDocumental.Models.Entities;
using OpeCar.GestionDocumental.Models.Infrastructure.Repositories;
using System.Web.Http;

namespace OpeCar.GestionDocumental.Controllers
{
    public class MantenimientoController : ApiController
    {
        [HttpGet]
        [Route("api/Mantenimiento/Listar")]
        public IHttpActionResult Listar()
        {
            var resul = DMantenimiento.Listar();
            return Ok(resul);
        }

        [HttpGet]
        [Route("api/Mantenimiento/ListarMenuFooter/{mantenimientoId}")]
        public IHttpActionResult ListarMenuFooter(int mantenimientoId)
        {
            var resul = DMenuFooter.Listar(mantenimientoId);
            return Ok(resul);
        }

        [HttpPost]
        [Route("api/Mantenimiento/Guardar")]
        public IHttpActionResult Guardar(EMantenimiento mantenimiento)
        {
            var resul = DMantenimiento.Guardar(mantenimiento);
            return Ok(resul);
        }

        [HttpPost]
        [Route("api/Mantenimiento/GuardarMenuFooter")]
        public IHttpActionResult GuardarMenuFooter(EMenuFooter menuFooter)
        {
            var resul = DMenuFooter.Guardar(menuFooter);
            return Ok(resul);
        }
    }
}
