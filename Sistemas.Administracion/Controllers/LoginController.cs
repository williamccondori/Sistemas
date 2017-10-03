using Sistemas.Administracion.Controllers.Shared;
using Sistemas.Administracion.Infraestructura;
using Sistemas.Dtos.Administracion;
using Sistemas.Servicios.Administracion;
using Sistemas.Servicios.Implementacion.Administracion;
using System;
using System.Web.Mvc;

namespace Sistemas.Administracion.Controllers
{
    public class LoginController : BaseController
    {
        private IUsuarioService _usuarioService;

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult IniciarSesion(UsuarioDto usuarioDto)
        {
            try
            {
                _usuarioService = new UsuarioService();

                _usuarioService.IniciarSesion(usuarioDto);

                Sesion.IniciarSesion(usuarioDto.Username);

                return RedirectToAction("Index", "Portada");
            }
            catch (Exception excepcion)
            {
                MostrarMensajeError(excepcion.Message);

                return RedirectToAction("Index");
            }
        }
    }
}