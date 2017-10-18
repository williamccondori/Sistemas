using Sistemas.Dtos.Http;
using Sistemas.Dtos.Sitio;
using Sistemas.Web.Controllers.Base;
using Sistemas.Web.Proxy;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Sistemas.Web.Controllers.Publicacion
{
    public class NoticiaController : BaseController
    {
        public ActionResult Index(string noticia)
        {
            return View();
        }

        public ActionResult Detalle(string id)
        {
            ViewBag.IdPublicacion = ObtenerIdPublicacion(id);

            return View();
        }

        [HttpPost]
        public JsonResult ObtenerNoticias()
        {
            return Json(Ejecutar(() =>
            {
                Api api = new Api(_ruta);

                IList<PublicacionDto> noticias = api.Ejecutar<IList<PublicacionDto>>("noticia");

                return Response<IList<PublicacionDto>>.Correcto(noticias);

            }), JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult BuscarNoticia(long idPublicacion)
        {
            return Json(Ejecutar(() =>
            {
                Api api = new Api(_ruta);

                PublicacionDto noticia = api.Ejecutar<PublicacionDto>(string.Format("noticia/buscar/{0}", idPublicacion));

                return Response<PublicacionDto>.Correcto(noticia);

            }), JsonRequestBehavior.AllowGet);
        }
    }
}