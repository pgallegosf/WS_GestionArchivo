using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using OpeCar.GestionDocumental.Models.Entities;

namespace OpeCar.GestionDocumental.Models.Infrastructure.Repositories
{
    public class DDocumento
    {
        public static IEnumerable<EDocumento> Listar(int idArea)
        {
            var lista = new List<EDocumento>();
            using (var db = new OpeCarEntities())
            {
                try
                {
                    var query = (from d in db.Documento
                                 join dh in db.DocumentoHist
                                     on d.IdDocumento equals dh.IdDocumento
                                     join s in db.SubArea
                                     on d.IdSubArea equals s.IdSubArea
                                 orderby dh.IdHistorico descending
                                 where (s.IdArea == idArea
                                 && dh.IndicadorHabilitado
                                 && dh.IdHistorico == db.DocumentoHist.Where(x => x.IdDocumento == d.IdDocumento).Max(x => x.IdHistorico))
                                 select new
                                 {
                                     d.IdSubArea,
                                     d.IdDocumento,
                                     d.IdTipoDocumento,
                                     dh.NombreDocumento,
                                     dh.UrlDocumento,
                                     dh.IndicadorHabilitado,
                                     dh.IdHistorico
                                 });

                    {
                        foreach (var item in query)
                        {
                            var result = new EDocumento
                            {
                                IdSubArea = item.IdSubArea,
                                Codigo = item.IdDocumento,
                                Descripcion = item.NombreDocumento,
                                IdTipoDocumento = item.IdTipoDocumento,
                                UrlDocumento = item.UrlDocumento,
                                IndicadorHabilitado = item.IndicadorHabilitado,
                                IdHistorico = item.IdHistorico
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
        public static bool Registrar(EDocumentoRequest request)
        {
            using (var db = new OpeCarEntities())
            {
                try
                {
                    var idHistorico = request.Codigo != null ? db.DocumentoHist.Where(x => x.IdDocumento == request.Codigo).Select(x => x.IdHistorico).Max() : 1;
                    var idDocumento = 1;
                    if (request.Codigo == null)
                    {
                        var tbDocumento = db.Documento.Count();
                        if (tbDocumento != 0)
                        {
                            idDocumento =
                                db.Documento.OrderByDescending(x => x.IdDocumento)
                                    .First()
                                    .IdDocumento + 1;
                        }
                    }
                    else
                    {
                        idDocumento = (int)request.Codigo;
                    }
                    var documentoNew = new Documento
                    {
                        IdDocumento = idDocumento,
                        IdUsuarioCreacion = request.IdUsuario,
                        FechaCreacion = request.FechaTransaccion,
                        IdSubArea = request.IdSubArea,
                        IdTipoDocumento=request.IdTipoDocumento
                    };

                    var documentoHistNew = new DocumentoHist
                    {
                        IdDocumento = idDocumento,
                        IdHistorico = idHistorico,
                        NombreDocumento = request.Descripcion,
                        FechaModificacion = request.FechaTransaccion,
                        UrlDocumento=request.UrlDocumento,
                        IdUsuarioModificacion = request.IdUsuario,
                        IndicadorHabilitado = request.IndicadorHabilitado
                    };

                    if (request.Codigo != null)
                    {
                        documentoHistNew.IdDocumento = (int)request.Codigo;
                        var documentoHist = db.DocumentoHist.Where(x =>
                            x.IdDocumento == request.Codigo
                            && x.IdHistorico == idHistorico
                            ).Select(x => x).FirstOrDefault();
                        if (documentoHist != null)
                        {
                            documentoHistNew.IdHistorico = idHistorico + 1;
                        }
                        db.DocumentoHist.Add(documentoHistNew);
                    }
                    else
                    {
                        db.Documento.Add(documentoNew);
                        db.DocumentoHist.Add(documentoHistNew);
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