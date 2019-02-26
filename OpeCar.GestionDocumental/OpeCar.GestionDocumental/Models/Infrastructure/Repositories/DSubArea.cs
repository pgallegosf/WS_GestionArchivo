using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using OpeCar.GestionDocumental.Models.Entities;

namespace OpeCar.GestionDocumental.Models.Infrastructure.Repositories
{
    public class DSubArea
    {
        public static IEnumerable<ESubArea> Listar(int idArea)
        {
            var lista = new List<ESubArea>();
            using (var db = new OpeCarEntities())
            {
                try
                {
                    var query = (from s in db.SubArea
                                 join sh in db.SubAreaHist
                                     on s.IdSubArea equals sh.IdSubArea
                                 orderby sh.IdHistorial descending
                                 where (s.IdArea == idArea
                                 && sh.IndicadorHabilitado
                                 && sh.IdHistorial == db.SubAreaHist.Where(x => x.IdSubArea == s.IdSubArea).Max(x => x.IdHistorial))
                                 select new
                                 {
                                     s.IdArea,
                                     s.IdSubArea,
                                     sh.Descripcion,
                                     s.IdPadre,
                                     sh.EsUltimo,
                                     sh.IdHistorial,
                                     s.IdUsuarioCreacion,
                                     s.FechaCreacion,
                                     sh.IndicadorHabilitado
                                 });

                    {
                        foreach (var item in query)
                        {
                            var result = new ESubArea
                            {
                                IdArea = item.IdArea,
                                Codigo = item.IdSubArea,
                                Descripcion = item.Descripcion,
                                IdPadre = item.IdPadre,
                                EsUltimo = item.EsUltimo,
                                IdHistorial = item.IdHistorial,
                                IdUsuarioCreacion = item.IdUsuarioCreacion,
                                FechaCreacion = item.FechaCreacion,
                                IndicadorHabilitado = item.IndicadorHabilitado
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
            return lista;
        }
        public static bool Registrar(ESubAreaRequest request)
        {
            
            using (var db = new OpeCarEntities())
            {
                try
                {
                    var idHistorico = request.Codigo != null ? db.SubAreaHist.Where(x => x.IdSubArea == request.Codigo).Select(x => x.IdHistorial).Max() : 1;
                    var idSubArea = 1;
                    if (request.Codigo == null)
                    {
                        var tbSubArea = db.SubArea.Count();
                        if (tbSubArea != 0)
                        {
                            idSubArea =
                                db.SubArea.OrderByDescending(x => x.IdSubArea)
                                    .First()
                                    .IdSubArea + 1;
                        }
                    }
                    else
                    {
                        idSubArea = (int)request.Codigo;
                    }

                    var subAreaNew = new SubArea
                    {

                        IdSubArea = idSubArea,
                        IdUsuarioCreacion = request.IdUsuario,
                        FechaCreacion = request.FechaTransaccion,
                        IdArea = request.IdArea,
                        IdPadre = request.IdPadre
                        
                    };

                    var subAreaHistNew = new SubAreaHist
                    {

                        IdSubArea = idSubArea,
                        IdHistorial = idHistorico,
                        Descripcion = request.Descripcion,
                        FechaModificacion = request.FechaTransaccion,
                        IdUsuarioModificacion = request.IdUsuario,
                        EsUltimo = request.EsUltimo,
                        IndicadorHabilitado = request.IndicadorHabilitado
                        };

                    if (request.Codigo != null)
                    {
                        
                        var subAreaHist = db.SubAreaHist.Where(x =>
                            x.IdSubArea == idSubArea
                            && x.IdHistorial == idHistorico
                            ).Select(x => x).FirstOrDefault();
                        if (subAreaHist != null)
                        {
                            subAreaHistNew.IdHistorial = idHistorico + 1;
                        }
                        db.SubAreaHist.Add(subAreaHistNew);
                    }
                    else
                    {
                        db.SubArea.Add(subAreaNew);
                        db.SubAreaHist.Add(subAreaHistNew);
                    }
                    db.SaveChanges();
                    return true;
                }
                catch (Exception ex)
                {

                    throw ex;
                    return false;
                }

            }
        }
    }
}