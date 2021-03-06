﻿using Sistemas.Dtos.Http;
using Sistemas.Dtos.Sitio;
using Sistemas.Web.Controllers.Base;
using Sistemas.Web.Proxy;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Sistemas.Web.Controllers.Publicacion
{
    public class ActualidadController : BaseController
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult ObtenerActualidades()
        {
            return Json(Ejecutar(() =>
            {
                Api api = new Api(_ruta);

                IList<PublicacionDto> actualidades = api.Ejecutar<IList<PublicacionDto>>("actualidad");

                return Response<IList<PublicacionDto>>.Correcto(actualidades);

            }), JsonRequestBehavior.AllowGet);
        }
    }
}