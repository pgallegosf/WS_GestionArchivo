using OpeCar.GestionDocumental.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OpeCar.GestionDocumental.Models.Infrastructure.Repositories
{
    public class DMenuFooter
    {
        public static IEnumerable<EMenuFooter> Listar(int mantenimientoId)
        {
            var lista = new List<EMenuFooter>();
            using (var db = new OpeCarEntities())
            {
                try
                {
                    var query = (from m in db.MenuFooter
                                 where (m.MantenimientoId == mantenimientoId)
                                 orderby m.MenuFooterPosition ascending
                                 select new
                                 {
                                     m.MenuFooterId,
                                     m.MantenimientoId,
                                     m.MenuFooterName,
                                     m.MenuFooterUrl,
                                     m.MenuFooterPosition,
                                     m.MenuFooterIsSuperAdmin,
                                     m.MenuFooterStatus
                                 });

                    {
                        foreach (var item in query)
                        {
                            var result = new EMenuFooter
                            {
                                MenuFooterId = item.MenuFooterId,
                                MantenimientoId = item.MantenimientoId,
                                MenuFooterName = item.MenuFooterName,
                                MenuFooterUrl = item.MenuFooterUrl,
                                MenuFooterPosition = item.MenuFooterPosition,
                                MenuFooterIsSuperAdmin = item.MenuFooterIsSuperAdmin,
                                MenuFooterStatus = item.MenuFooterStatus
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

        public static bool Guardar(EMenuFooter request)
        {
            using (var db = new OpeCarEntities())
            {
                try
                {
                    if (request.MenuFooterId != null)
                    {                       
                        var menuFooter = db.MenuFooter.FirstOrDefault(x => x.MenuFooterId == request.MenuFooterId);

                        if (menuFooter != null)
                        {
                            menuFooter.MenuFooterName = request.MenuFooterName;
                            menuFooter.MenuFooterUrl = request.MenuFooterUrl;
                            menuFooter.MenuFooterPosition = request.MenuFooterPosition;
                            menuFooter.MenuFooterStatus = request.MenuFooterStatus;
                            menuFooter.MenuFooterIsSuperAdmin = request.MenuFooterIsSuperAdmin;
                        }
                    }
                    else
                    {                        
                        var menuFooterNew = new MenuFooter
                        {
                            MantenimientoId = request.MantenimientoId,
                            MenuFooterName = request.MenuFooterName,
                            MenuFooterUrl = request.MenuFooterUrl,
                            MenuFooterPosition = request.MenuFooterPosition,
                            MenuFooterStatus = request.MenuFooterStatus,
                            MenuFooterIsSuperAdmin = request.MenuFooterIsSuperAdmin
                        };
                        db.MenuFooter.Add(menuFooterNew);                       
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