using Sistemas.Web.Controllers.Base;
using Sistemas.Web.Models.Investigacion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sistemas.Web.Controllers
{
    public class InvestigacionController : BaseController
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Trabajo()
        {
            TrabajoModel model = TrabajoModel.Obtener();
            return View(model);
        }
    }
}