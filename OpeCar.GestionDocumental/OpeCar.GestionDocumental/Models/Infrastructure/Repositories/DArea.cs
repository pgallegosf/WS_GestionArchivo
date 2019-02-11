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
            using (OpeCarEntities db = new OpeCarEntities())
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
                            ah.IdHistorial
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
            return lista;
        }
    }
}