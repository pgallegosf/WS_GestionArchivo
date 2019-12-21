using OpeCar.GestionDocumental.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OpeCar.GestionDocumental.Models.Infrastructure.Repositories
{
    public class DMantenimiento
    {
        public static IEnumerable<EMantenimiento> Listar()
        {
            var lista = new List<EMantenimiento>();
            using (var db = new OpeCarEntities())
            {
                try
                {
                    var query = (from m in db.Mantenimiento
                                 select new
                                 {
                                     m.MantenimientoId,
                                     m.MantenimientoLogo,
                                     m.MantenimientoMenuFooter,
                                     m.MantenimientoSobreNosotros,
                                     m.MantenimientoDerechosReservados,
                                     m.MantenimientoTelefono,
                                     m.MantenimientoFechaActualizacion                                     
                                 });

                    {
                        foreach (var item in query)
                        {
                            var result = new EMantenimiento
                            {
                                MantenimientoId = item.MantenimientoId,
                                MantenimientoLogo = item.MantenimientoLogo,
                                MantenimientoMenuFooter = item.MantenimientoMenuFooter,
                                MantenimientoSobreNosotros = item.MantenimientoSobreNosotros,
                                MantenimientoDerechosReservados = item.MantenimientoDerechosReservados,
                                MantenimientoTelefono = item.MantenimientoTelefono,
                                MantenimientoFechaActualizacion = item.MantenimientoFechaActualizacion
                            };
                            lista.Add(result);
                        }
                    }
                }
                catch (Exception ex)
                {

                    throw ex;
                }

            }
            return lista.OrderBy(x => x.MantenimientoId);
        }

        public static bool Guardar(EMantenimiento request)
        {
            using (var db = new OpeCarEntities())
            {
                try
                {                    
                    var mantenimiento = db.Mantenimiento.FirstOrDefault(x => x.MantenimientoId == request.MantenimientoId);
                    if (mantenimiento != null)
                    {
                        mantenimiento.MantenimientoTelefono = request.MantenimientoTelefono;
                        mantenimiento.MantenimientoSobreNosotros = request.MantenimientoSobreNosotros;
                        mantenimiento.MantenimientoDerechosReservados = request.MantenimientoDerechosReservados;
                        mantenimiento.MantenimientoFechaActualizacion = DateTime.Now;
                    }                    
                    db.SaveChanges();                    
                }
                catch (Exception ex)
                {                   
                    return false;
                }
                return true;
            }
        }
    }
}