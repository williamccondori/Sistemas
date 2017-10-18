using Sistemas.Dtos.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace Sistemas.Web.Controllers.Base
{
    public class BaseController : Controller
    {
        protected string _ruta = "http://localhost:53036/";

        protected Response<T> Ejecutar<T>(Func<Response<T>> funcion)
        {
            try
            {
                return funcion();
            }
            catch (Exception excepcion)
            {
                return Response<T>.Incorrecto(excepcion.Message, excepcion.StackTrace);
            }
        }

        protected long ObtenerIdPublicacion(string enlace)
        {
            try
            {
                IEnumerable<string> claves = enlace.Split('-');

                string idNoticia = claves.LastOrDefault();

                long idPublicacion = Convert.ToInt64(idNoticia);

                return idPublicacion;
            }
            catch (Exception)
            {
                return 0;
            }
        }

    }
}