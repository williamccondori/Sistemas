using Sistemas.Api.Controllers.Base;
using Sistemas.Dtos.Http;
using Sistemas.Dtos.Sitio;
using Sistemas.Servicios.Implementacion.Sitio;
using Sistemas.Servicios.Sitio;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace Sistemas.Api.Controllers
{
    [RoutePrefix("api/presentacion")]
    public class PresentacionController : BaseController
    {
        private IResenaService _resenaService;

        private const string Presentacion = "PR";

        [Route(Predeterminado)]
        [HttpGet]
        public Response<ResenaDto> Obtener()
        {
            return Ejecutar(() =>
            {
                _resenaService = new ResenaService();
                IList<ResenaDto> presentaciones = _resenaService.ObtenerPorTipo(Presentacion);
                ResenaDto presentacion = presentaciones.FirstOrDefault();
                return Response<ResenaDto>.Correcto(presentacion);
            });
        }
    }
}