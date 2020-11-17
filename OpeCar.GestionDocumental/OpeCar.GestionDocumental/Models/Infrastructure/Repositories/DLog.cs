using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using OpeCar.GestionDocumental.Models.Entities;

namespace OpeCar.GestionDocumental.Models.Infrastructure.Repositories
{
    public class DLog
    {
        public static IEnumerable<ELog> Listar(ELogRequest request)
        {
            var lista = new List<ELog>();
            using (var db = new OpeCarEntities())
            {
                try
                {
                    var query = (from l in db.Log
                                 where ((String.IsNullOrEmpty(request.Usuario.Trim()) || l.Usuario.Equals(request.Usuario))
                                 && (String.IsNullOrEmpty(request.TipoLog.Trim()) || l.TipoLog.Equals(request.TipoLog))
                                 && (String.IsNullOrEmpty(request.Funcion.Trim()) || l.Funcion.Equals(request.Funcion)))
                                 select new 
                                 {
                                    l.IDLog,
                                    l.Usuario,
                                    l.TipoLog,
                                    l.Funcion,
                                    l.RegistroLog,
                                    l.RequestLog,
                                    l.FechaLog
                                 });

                    {
                        foreach (var item in query)
                        {
                            var result = new ELog
                            {
                                IDLog = item.IDLog,
                                Usuario = item.Usuario,
                                TipoLog = item.TipoLog,
                                Funcion = item.Funcion,
                                RegistroLog = item.RegistroLog,
                                RequestLog = item.RequestLog,
                                FechaLog=item.FechaLog
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
            return lista.OrderBy(x => x.IDLog);
        }

        public static bool Registrar(ELogRequest request)
        {
            using (var db = new OpeCarEntities())
            {
                try
                {
                    var log = new Log
                    {
                        Usuario = request.Usuario,
                        TipoLog = request.TipoLog,
                        Funcion = request.Funcion,
                        RegistroLog = request.RegistroLog,
                        RequestLog = request.RequestLog,
                        FechaLog = DateTime.Now
                    };
                    db.Log.Add(log);
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