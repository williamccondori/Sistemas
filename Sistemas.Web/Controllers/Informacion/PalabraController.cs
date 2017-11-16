using Sistemas.Dtos.Sitio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sistemas.Web.Controllers.Informacion
{
    public class PalabraModel
    {
        public ResenaDto Resena { get; set; }
    }

    public class PalabraController : Controller
    {
        
        public ActionResult Index()
        {
            PalabraModel model = new PalabraModel();
            model.Resena = new ResenaDto();
            return View(model);
        }
    }
}