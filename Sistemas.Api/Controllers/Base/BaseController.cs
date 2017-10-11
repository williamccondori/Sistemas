using Sistemas.Dtos.Http;
using System;
using System.Web.Http;

namespace Sistemas.Api.Controllers.Base
{
    public class BaseController : ApiController
    {
        protected const string Predeterminado = "";

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
    }
}