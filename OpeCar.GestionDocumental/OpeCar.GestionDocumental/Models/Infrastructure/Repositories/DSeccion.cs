using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using OpeCar.GestionDocumental.Models.Entities;

namespace OpeCar.GestionDocumental.Models.Infrastructure.Repositories
{
    public class DSeccion
    {
        public static IEnumerable<ESeccion> Listar(int idTipoSeccion)
        {
            var lista = new List<ESeccion>();
            using (var db = new OpeCarEntities())
            {
                try
                {
                    var query = (from s in db.Seccion
                                 where (s.IdTipoSeccion == idTipoSeccion
                                 && s.IndicadorHabilitado)
                                 select new
                                 {
                                     s.IdSeccion,
                                     s.IdTipoSeccion,
                                     s.Titulo,
                                     s.Contenido,
                                     s.RutaMultimedia,
                                     s.Posicion,
                                     s.IdUsuarioCreacion,
                                     s.FechaCreacion,
                                     s.IdUsuarioModificacion,
                                     s.FechaModificacion
                                 });

                    {
                        foreach (var item in query)
                        {
                            var result = new ESeccion
                            {
                                IdSeccion=item.IdSeccion,
                                IdTipoSeccion = item.IdTipoSeccion,
                                Titulo = item.Titulo,
                                Contenido = item.Contenido,
                                RutaMultimedia = item.RutaMultimedia,
                                Posicion = item.Posicion,
                                IdUsuarioCreacion = item.IdUsuarioCreacion,
                                FechaCreacion = item.FechaCreacion,
                                IdUsuarioModificacion = item.IdUsuarioModificacion,
                                FechaModificacion = item.FechaModificacion
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
            return lista.OrderBy(x => x.Posicion);
        }
        public static bool Registrar(ESeccionRequest request)
        {
            using (var db = new OpeCarEntities())
            {
                try
                {
                    var idSeccion = 1;
                    if (request.IdSeccion == null)
                    {
                        var tbSeccion = db.Seccion.Count();
                        if (tbSeccion != 0)
                        {
                            idSeccion =
                                db.Seccion.OrderByDescending(x => x.IdSeccion)
                                    .First()
                                    .IdSeccion + 1;
                        }
                    }
                    else
                    {
                        idSeccion = (int)request.IdSeccion;
                    }
                    var seccionNew = new Seccion
                    {
                        IdSeccion = idSeccion,
                        IdUsuarioCreacion = request.IdUsuario,
                        FechaCreacion = DateTime.Now,
                        IdTipoSeccion = request.IdTipoSeccion,
                        Titulo = request.Titulo,
                        Contenido = request.Contenido,
                        RutaMultimedia = request.RutaMultimedia,
                        Posicion = request.Posicion,
                        IndicadorHabilitado = true
                    };

                    

                    if (request.IdSeccion != null)
                    {
                        var seccion = db.Seccion.FirstOrDefault(x => x.IdSeccion == request.IdSeccion);

                        if (seccion != null)
                        {
                            seccion.Titulo = request.Titulo;
                            seccion.Contenido = request.Contenido;
                            if (request.RutaMultimedia != "")
                            {
                                seccion.RutaMultimedia = request.RutaMultimedia;
                            }
                            seccion.Posicion = request.Posicion;
                            seccion.IdUsuarioModificacion = request.IdUsuario;
                            seccion.FechaModificacion = DateTime.Now;
                        }
                        
                    }
                    else
                    {
                        db.Seccion.Add(seccionNew);
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
        public static bool Eliminar(ESeccionRequest request)
        {

            using (var db = new OpeCarEntities())
            {
                try
                {
                    var seccion = db.Seccion.FirstOrDefault(x => x.IdSeccion == request.IdSeccion);
                    if (seccion != null)
                    {
                        seccion.IndicadorHabilitado = false;
                        seccion.IdUsuarioModificacion = request.IdUsuario;
                        seccion.FechaModificacion = DateTime.Now;
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
        //public static bool Editar(EAreaRequest request)
        //{

        //    using (var db = new OpeCarEntities())
        //    {
        //        try
        //        {
        //            var idHistorico = db.AreaHist.Where(x => x.IdArea == request.Codigo).Select(x => x.IdHistorial).Max();
        //            var area = db.AreaHist.FirstOrDefault(x => x.IdArea == request.Codigo && x.IdHistorial == idHistorico);
        //            if (area != null)
        //            {
        //                area.IndicadorHabilitado = false;
        //                area.IdUsuarioModificacion = request.IdUsuario;
        //                area.FechaModificacion = request.FechaTransaccion;
        //            }
        //            idHistorico += 1;
        //            var areaHist = new AreaHist
        //            {

        //                IdArea = (int)request.Codigo,
        //                IdHistorial = idHistorico,
        //                Descripcion = request.Descripcion,
        //                FechaModificacion = request.FechaTransaccion,
        //                IdUsuarioModificacion = request.IdUsuario,
        //                UrlImg = area.UrlImg,
        //                IndicadorHabilitado = true
        //            };
        //            db.AreaHist.Add(areaHist);
        //            db.SaveChanges();

        //            return true;
        //        }
        //        catch (Exception ex)
        //        {

        //            throw ex;
        //            return false;
        //        }

        //    }
        //}
    }
}