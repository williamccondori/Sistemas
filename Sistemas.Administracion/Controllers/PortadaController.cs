using Sistemas.Administracion.Controllers.Shared;
using Sistemas.Administracion.Infraestructura;
using System.Web.Mvc;

namespace Sistemas.Administracion.Controllers
{
    public class PortadaController : BaseController
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Configuracion()
        {
            return View();
        }

        public ActionResult Modulos()
        {
            return View();
        }

        public ActionResult CerrarSesion()
        {
            Sesion.CerrarSesion();

            return RedirectToAction("Index", "Login");
        }
    }
}