using System;
using OpeCar.GestionDocumental.Models.Entities;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Cryptography;

namespace OpeCar.GestionDocumental.Models.Infrastructure.Repositories
{
    public class DArea
    {
        public static IEnumerable<EArea> Listar(int idTipoArea)
        {
            var lista = new List<EArea>();
            using (var db = new OpeCarEntities())
            {
                try
                {
                    var query = (from a in db.Area
                        join ah in db.AreaHist
                            on a.IdArea equals ah.IdArea
                        orderby ah.IdHistorial descending
                        where (a.IdTipoArea==idTipoArea 
                        && ah.IndicadorHabilitado 
                        && ah.IdHistorial==db.AreaHist.Where(x=>x.IdArea==a.IdArea ).Max(x => x.IdHistorial))
                        select new
                        {
                            a.IdArea,
                            a.IdTipoArea,
                            ah.Descripcion,
                            ah.UrlImg,
                            ah.IdHistorial,
                            ah.IndicadorHabilitado
                        });

                    {
                        foreach (var item in query)
                        {
                            var result = new EArea
                            {
                                IdArea = item.IdArea,
                                IdTipoArea = item.IdTipoArea,
                                Descripcion = item.Descripcion,
                                UrlImg = item.UrlImg,
                                IdHistorial=item.IdHistorial
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
            return lista.OrderBy(x=>x.Descripcion);
        }
        public static bool Registrar(EAreaRequest request)
        {
            using (var db = new OpeCarEntities())
            {
                try
                {
                    var idHistorico = request.Codigo != null ? db.AreaHist.Where(x => x.IdArea == request.Codigo).Select(x => x.IdHistorial).Max() : 1;
                    var idArea = 1;
                    if (request.Codigo == null)
                    {
                        var tbArea = db.Area.Count();
                        if (tbArea != 0)
                        {
                            idArea =
                                db.Area.OrderByDescending(x => x.IdArea)
                                    .First()
                                    .IdArea + 1;
                        }
                    }
                    else
                    {
                        idArea = (int)request.Codigo;
                    }
                    var areaNew = new Area
                    {
                        IdArea = idArea,
                        IdUsuarioCreacion = request.IdUsuario,
                        FechaCreacion = request.FechaTransaccion,
                        IdTipoArea=request.IdTipoArea
                    };

                    var areaHistNew = new AreaHist
                    {
                        IdArea = idArea,
                        IdHistorial = idHistorico,
                        Descripcion = request.Descripcion,
                        UrlImg = request.UrlImg,
                        FechaModificacion = request.FechaTransaccion,
                        IdUsuarioModificacion = request.IdUsuario,
                        IndicadorHabilitado = request.IndicadorHabilitado
                    };

                    if (request.Codigo != null)
                    {
                        areaHistNew.IdArea = (int) request.Codigo;
                        var areaHist = db.AreaHist.Where(x =>
                            x.IdArea == request.Codigo
                            && x.IdHistorial == idHistorico
                            ).Select(x => x).FirstOrDefault();
                        if (areaHist != null)
                        {
                            areaHistNew.IdHistorial = idHistorico + 1;
                        }
                        db.AreaHist.Add(areaHistNew);
                    }
                    else
                    {
                        db.Area.Add(areaNew);
                        db.AreaHist.Add(areaHistNew);
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
        public static bool Eliminar(EAreaRequest request)
        {

            using (var db = new OpeCarEntities())
            {
                try
                {
                    var idHistorico = db.AreaHist.Where(x => x.IdArea == request.Codigo).Select(x => x.IdHistorial).Max();
                    var area = db.AreaHist.FirstOrDefault(x => x.IdArea == request.Codigo && x.IdHistorial == idHistorico);
                    if (area != null)
                    {
                        area.IndicadorHabilitado = false;
                        area.IdUsuarioModificacion = request.IdUsuario;
                        area.FechaModificacion = DateTime.Now;
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
        public static bool Editar(EAreaRequest request)
        {

            using (var db = new OpeCarEntities())
            {
                try
                {
                    var idHistorico = db.AreaHist.Where(x => x.IdArea == request.Codigo).Select(x => x.IdHistorial).Max();
                    var area = db.AreaHist.FirstOrDefault(x => x.IdArea == request.Codigo && x.IdHistorial == idHistorico);
                    if (area != null)
                    {
                        area.IndicadorHabilitado = false;
                        area.IdUsuarioModificacion = request.IdUsuario;
                        area.FechaModificacion = request.FechaTransaccion;
                    }
                    idHistorico+=1;
                    var areaHist = new AreaHist
                    {

                        IdArea = (int)request.Codigo,
                        IdHistorial = idHistorico,
                        Descripcion = request.Descripcion,
                        FechaModificacion = request.FechaTransaccion,
                        IdUsuarioModificacion = request.IdUsuario,
                        UrlImg = area.UrlImg,
                        IndicadorHabilitado = true
                    };
                    db.AreaHist.Add(areaHist);
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