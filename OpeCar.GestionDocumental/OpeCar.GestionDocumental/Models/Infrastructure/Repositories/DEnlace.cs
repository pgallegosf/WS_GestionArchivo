using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using OpeCar.GestionDocumental.Models.Entities;

namespace OpeCar.GestionDocumental.Models.Infrastructure.Repositories
{
    public class DEnlace
    {
        public static IEnumerable<EEnlace> Listar()
        {
            var lista = new List<EEnlace>();
            using (var db = new OpeCarEntities())
            {
                try
                {
                    var query = (from s in db.Enlace
                                 where (s.IndicadorHabilitado)
                                 select new
                                 {
                                     s.IdEnlace,
                                     s.Descripcion,
                                     s.UrlEnlace,
                                     s.ImgEnlace,
                                     s.IdUsuarioCreacion,
                                     s.FechaCreacion
                                 });

                    {
                        foreach (var item in query)
                        {
                            var result = new EEnlace
                            {
                                IdEnlace = item.IdEnlace,
                                Descripcion = item.Descripcion,
                                UrlEnlace = item.UrlEnlace,
                                ImgEnlace = item.ImgEnlace,
                                IdUsuarioCreacion = item.IdUsuarioCreacion,
                                FechaCreacion = item.FechaCreacion
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
            return lista.OrderBy(x => x.Descripcion);
        }
        public static bool Registrar(EEnlaceRequest request)
        {
            using (var db = new OpeCarEntities())
            {
                try
                {
                    var idEnlace = 1;
                    if (request.IdEnlace == null)
                    {
                        var tbSeccion = db.Enlace.Count();
                        if (tbSeccion != 0)
                        {
                            idEnlace =
                                db.Enlace.OrderByDescending(x => x.IdEnlace)
                                    .First()
                                    .IdEnlace + 1;
                        }
                    }
                    else
                    {
                        idEnlace = (int)request.IdEnlace;
                    }
                    var enlaceNew = new Enlace
                    {
                        IdEnlace = idEnlace,
                        IdUsuarioCreacion = request.IdUsuario,
                        FechaCreacion = DateTime.Now,
                        Descripcion = request.Descripcion,
                        UrlEnlace = request.UrlEnlace,
                        ImgEnlace = request.ImgEnlace,
                        IndicadorHabilitado = true
                    };



                    if (request.IdEnlace != null)
                    {
                        var enlace = db.Enlace.FirstOrDefault(x => x.IdEnlace == request.IdEnlace);

                        if (enlace != null)
                        {
                            enlace.Descripcion = request.Descripcion;
                            enlace.UrlEnlace = request.UrlEnlace;
                            if (request.ImgEnlace != "") { 
                                enlace.ImgEnlace = request.ImgEnlace;
                            }
                            enlace.IdUsuarioModificacion = request.IdUsuario;
                            enlace.FechaModificacion = DateTime.Now;
                        }

                    }
                    else
                    {
                        db.Enlace.Add(enlaceNew);
                    }
                    db.SaveChanges();
                    return true;
                }
                catch (Exception ex)
                {

                    return false;
                }

            }
        }
        public static bool Eliminar(EEnlaceRequest request)
        {

            using (var db = new OpeCarEntities())
            {
                try
                {
                    var enlace = db.Enlace.FirstOrDefault(x => x.IdEnlace == request.IdEnlace);
                    if (enlace != null)
                    {
                        enlace.IndicadorHabilitado = false;
                        enlace.IdUsuarioModificacion = request.IdUsuario;
                        enlace.FechaModificacion = DateTime.Now;
                    }

                    db.SaveChanges();

                    return true;
                }
                catch (Exception ex)
                {

                    return false;
                }

            }
        }
    }
}