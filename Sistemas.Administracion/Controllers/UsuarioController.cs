using Sistemas.Administracion.Controllers.Shared;
using Sistemas.Dtos.Administracion;
using Sistemas.Dtos.Http;
using Sistemas.Servicios.Administracion;
using Sistemas.Servicios.Implementacion.Administracion;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Sistemas.Administracion.Controllers
{
    public class UsuarioController : BaseController
    {
        private IUsuarioService _usuarioService;

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult GuardarUsuario(UsuarioDto usuarioDto)
        {
            return Json(Ejecutar(() =>
            {
                _usuarioService = new UsuarioService();
                usuarioDto.Usuario = _usuario;
                _usuarioService.Guardar(usuarioDto);
                return Response<bool>.Correcto(true);
            }), JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult ObtenerUsuarios()
        {
            return Json(Ejecutar(() =>
            {
                _usuarioService = new UsuarioService();
                IList<UsuarioDto> usuariosDto = _usuarioService.ObtenerTodo();
                return Response<IList<UsuarioDto>>.Correcto(usuariosDto);
            }), JsonRequestBehavior.AllowGet);
        }
    }
}