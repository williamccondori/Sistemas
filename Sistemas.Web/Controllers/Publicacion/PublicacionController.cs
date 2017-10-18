using Sistemas.Dtos.Http;
using Sistemas.Dtos.Sitio;
using Sistemas.Web.Controllers.Base;
using Sistemas.Web.Proxy;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Sistemas.Web.Controllers.Publicacion
{
    public class PublicacionController : BaseController
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult ObtenerPublicaciones()
        {
            return Json(Ejecutar(() =>
            {
                Api api = new Api(_ruta);

                IList<PublicacionDto> publicaciones = api.Ejecutar<IList<PublicacionDto>>("publicacion");

                return Response<IList<PublicacionDto>>.Correcto(publicaciones);

            }), JsonRequestBehavior.AllowGet);
        }
    }
}