using Sistemas.Administracion.Controllers.Shared;
using Sistemas.Dtos.Http;
using Sistemas.Dtos.Sitio;
using Sistemas.Servicios.Implementacion.Sitio;
using Sistemas.Servicios.Sitio;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Sistemas.Administracion.Controllers
{
    public class SitioController : BaseController
    {
        private IPublicacionService _publicacionService;
        private ITipoPublicacionService _tipoPublicacionService;
        private ITipoDetallePublicacionService _tipoDetallePublicacionService;
        private ITipoResenaService _tipoResenaService;
        private IGradoAcademicoService _gradoAcademicoService;
        private IAutorResenaService _autorResenaService;
        private IResenaService _resenaService;

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Publicacion()
        {
            return View();
        }

        public ActionResult Resena()
        {
            return View();
        }

        public ActionResult Configuracion()
        {
            return View();
        }

        [HttpPost]
        public JsonResult GuardarTipoPublicacion(TipoPublicacionDto tipoPublicacionDto)
        {
            return Json(Ejecutar(() =>
            {
                _tipoPublicacionService = new TipoPublicacionService();
                tipoPublicacionDto.Usuario = _usuario;
                _tipoPublicacionService.Guardar(tipoPublicacionDto);
                return Response<bool>.Correcto(true);
            }), JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult ObtenerTiposPublicacion()
        {
            return Json(Ejecutar(() =>
            {
                _tipoPublicacionService = new TipoPublicacionService();
                IList<TipoPublicacionDto> tipoPublicacionesDto = _tipoPublicacionService.ObtenerTodo();
                return Response<IList<TipoPublicacionDto>>.Correcto(tipoPublicacionesDto);
            }), JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult GuardarTipoDetallePublicacion(TipoDetallePublicacionDto tiposDetallePublicacionDto)
        {
            return Json(Ejecutar(() =>
            {
                _tipoDetallePublicacionService = new TipoDetallePublicacionService();
                tiposDetallePublicacionDto.Usuario = _usuario;
                _tipoDetallePublicacionService.Guardar(tiposDetallePublicacionDto);
                return Response<bool>.Correcto(true);
            }), JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult ObtenerTiposDetallePublicacion()
        {
            return Json(Ejecutar(() =>
            {
                _tipoDetallePublicacionService = new TipoDetallePublicacionService();
                IList<TipoDetallePublicacionDto> tiposDetallePublicacionDto = _tipoDetallePublicacionService.ObtenerTodo();
                return Response<IList<TipoDetallePublicacionDto>>.Correcto(tiposDetallePublicacionDto);
            }), JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult GuardarTipoResena(TipoResenaDto tipoResenaDto)
        {
            return Json(Ejecutar(() =>
            {
                _tipoResenaService = new TipoResenaService();
                tipoResenaDto.Usuario = _usuario;
                _tipoResenaService.Guardar(tipoResenaDto);
                return Response<bool>.Correcto(true);
            }), JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult ObtenerTiposResena()
        {
            return Json(Ejecutar(() =>
            {
                _tipoResenaService = new TipoResenaService();
                IList<TipoResenaDto> tiposResenaDto = _tipoResenaService.ObtenerTodo();
                return Response<IList<TipoResenaDto>>.Correcto(tiposResenaDto);
            }), JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult GuardarGradoAcademico(GradoAcademicoDto gradoAcademicoDto)
        {
            return Json(Ejecutar(() =>
            {
                _gradoAcademicoService = new GradoAcademicoService();
                gradoAcademicoDto.Usuario = _usuario;
                _gradoAcademicoService.Guardar(gradoAcademicoDto);
                return Response<bool>.Correcto(true);
            }), JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult ObtenerGradosAcademicos()
        {
            return Json(Ejecutar(() =>
            {
                _gradoAcademicoService = new GradoAcademicoService();
                IList<GradoAcademicoDto> gradosAcademicosDto = _gradoAcademicoService.ObtenerTodo();
                return Response<IList<GradoAcademicoDto>>.Correcto(gradosAcademicosDto);
            }), JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult GuardarAutorResena(AutorResenaDto autorResenaDto)
        {
            return Json(Ejecutar(() =>
            {
                _autorResenaService = new AutorResenaService();
                autorResenaDto.Usuario = _usuario;
                _autorResenaService.Guardar(autorResenaDto);
                return Response<bool>.Correcto(true);
            }), JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult ObtenerAutoresResena()
        {
            return Json(Ejecutar(() =>
            {
                _autorResenaService = new AutorResenaService();
                IList<AutorResenaDto> autoresResenaDto = _autorResenaService.ObtenerTodo();
                return Response<IList<AutorResenaDto>>.Correcto(autoresResenaDto);
            }), JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult ObtenerPublicaciones()
        {
            return Json(Ejecutar(() =>
            {
                _publicacionService = new PublicacionService();
                IList<PublicacionDto> publicacionesDto = _publicacionService.ObtenerTodo();
                return Response<IList<PublicacionDto>>.Correcto(publicacionesDto);
            }), JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult ObtenerPublicacionesPorTipo(string idTipoPublicacion)
        {
            return Json(Ejecutar(() =>
            {
                _publicacionService = new PublicacionService();
                IList<PublicacionDto> publicacionesDto = _publicacionService.ObtenerPorTipo(idTipoPublicacion);
                return Response<IList<PublicacionDto>>.Correcto(publicacionesDto);
            }), JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult GuardarPublicacion(PublicacionDto publicacionDto)
        {
            return Json(Ejecutar(() =>
            {
                _publicacionService = new PublicacionService();
                publicacionDto.Usuario = _usuario;
                _publicacionService.Guardar(publicacionDto);
                return Response<bool>.Correcto(true);
            }), JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult ObtenerResenas()
        {
            return Json(Ejecutar(() =>
            {
                _resenaService = new ResenaService();
                IList<ResenaDto> resenasDto = _resenaService.ObtenerTodo();
                return Response<IList<ResenaDto>>.Correcto(resenasDto);
            }), JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult ObtenerResenasPorTipo(string idTipoResena)
        {
            return Json(Ejecutar(() =>
            {
                _resenaService = new ResenaService();
                IList<ResenaDto> ResenaesDto = _resenaService.ObtenerPorTipo(idTipoResena);
                return Response<IList<ResenaDto>>.Correcto(ResenaesDto);
            }), JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult GuardarResena(ResenaDto resenaDto)
        {
            return Json(Ejecutar(() =>
            {
                _resenaService = new ResenaService();
                resenaDto.Usuario = _usuario;
                _resenaService.Guardar(resenaDto);
                return Response<bool>.Correcto(true);
            }), JsonRequestBehavior.AllowGet);
        }
    }
}