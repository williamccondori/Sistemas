using Sistemas.Web.Models.Nosotros;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sistemas.Web.Controllers
{
    public class NosotrosController : Controller
    {
        
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Director()
        {
            return View();
        }

        public ActionResult MisionVision()
        {
            MisionVisionModel model = MisionVisionModel.Obtener();
            return View(model);
        }

        public ActionResult Objetivo()
        {
            ObjetivoModel model = ObjetivoModel.Obtener();
            return View(model);
        }

        public ActionResult PerfilProfesional()
        {
            PerfilProfesionalModel model = PerfilProfesionalModel.Obtener();
            return View(model);
        }

        public ActionResult ObjetivoEducacional()
        {
            ObjetivoEducacionalModel model = ObjetivoEducacionalModel.Obtener();
            return View(model);
        }

        public ActionResult ResultadoAprendizaje()
        {
            ResultadoModel model = ResultadoModel.Obtener();
            return View(model);
        }
    }
}