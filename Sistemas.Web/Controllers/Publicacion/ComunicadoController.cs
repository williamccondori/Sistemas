using Sistemas.Dtos.Http;
using Sistemas.Dtos.Sitio;
using Sistemas.Web.Controllers.Base;
using Sistemas.Web.Proxy;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Sistemas.Web.Controllers.Publicacion
{
    public class ComunicadoController : BaseController
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult ObtenerComunicados()
        {
            return Json(Ejecutar(() =>
            {
                Api api = new Api(_ruta);

                IList<PublicacionDto> comunicados = api.Ejecutar<IList<PublicacionDto>>("comunicado");

                return Response<IList<PublicacionDto>>.Correcto(comunicados);

            }), JsonRequestBehavior.AllowGet);
        }
    }
}