using Sistemas.Administracion.Infraestructura;
using Sistemas.Dtos.Http;
using System;
using System.Web.Mvc;

namespace Sistemas.Administracion.Controllers.Shared
{
    public class BaseController : Controller
    {
        protected string _usuario;

        public BaseController()
        {
            try
            {
                _usuario = Sesion.Usuario();
            }
            catch (Exception excepcion)
            {
                TempData["Error"] = excepcion.Message;

                RedirectToAction("Index", "Login");
            }
        }

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

        protected override void OnActionExecuting(ActionExecutingContext context)
        {
            try
            {
                string controlador = context.ActionDescriptor.ControllerDescriptor.ControllerName;

                string accion = context.ActionDescriptor.ActionName;

                bool tienePermiso = Sesion.ValidarSesion();

                if (controlador == "Login")
                {
                    if (tienePermiso)
                    {
                        context.Result = new RedirectResult("~/Portada");
                    }
                    else
                    {
                        return;
                    }
                }
                else
                {
                    if (context.HttpContext.Request.Headers["X-Requested-With"] == "XMLHttpRequest")
                    {
                        return;
                    }
                    else
                    {
                        if (!tienePermiso)
                        {
                            throw new Exception("La sesión del usuario ha caducado o no existe");
                        }
                    }
                }
            }
            catch (Exception excepcion)
            {
                MostrarMensajeError(excepcion.Message);

                context.Result = new RedirectResult("~/Login");
            }
        }

        protected void MostrarMensajeError(string mensaje)
        {
            TempData["Error"] = mensaje;
        }
    }
}