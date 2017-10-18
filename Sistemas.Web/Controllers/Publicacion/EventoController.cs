using Sistemas.Dtos.Http;
using Sistemas.Dtos.Sitio;
using Sistemas.Web.Controllers.Base;
using Sistemas.Web.Proxy;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Sistemas.Web.Controllers.Publicacion
{
    public class EventoController : BaseController
    {
        public ActionResult Index(string Evento)
        {
            return View();
        }

        public ActionResult Detalle(string id)
        {
            ViewBag.IdPublicacion = ObtenerIdPublicacion(id);

            return View();
        }

        [HttpPost]
        public JsonResult ObtenerEventos()
        {
            return Json(Ejecutar(() =>
            {
                Api api = new Api(_ruta);

                IList<EventoDto> eventos = api.Ejecutar<IList<EventoDto>>("eventos");

                return Response<IList<EventoDto>>.Correcto(eventos);

            }), JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult BuscarEvento(long idPublicacion)
        {
            return Json(Ejecutar(() =>
            {
                Api api = new Api(_ruta);

                EventoDto evento = api.Ejecutar<EventoDto>(string.Format("evento/buscar/{0}", idPublicacion));

                return Response<EventoDto>.Correcto(evento);

            }), JsonRequestBehavior.AllowGet);
        }
    }
}