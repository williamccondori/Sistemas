using Sistemas.Api.Controllers.Base;
using Sistemas.Dtos.Http;
using Sistemas.Dtos.Sitio;
using Sistemas.Servicios.Implementacion.Web;
using Sistemas.Servicios.Web;
using System.Collections.Generic;
using System.Web.Http;

namespace Sistemas.Api.Controllers
{
    [RoutePrefix("api/comunicado")]
    public class ComunicadoController : BaseController
    {
        private IPublicacionService _publicacionService;

        private const string Comunicado = "CO";

        [Route(Predeterminado)]
        [HttpGet]
        public Response<IList<PublicacionDto>> Obtener()
        {
            return Ejecutar(() =>
            {
                _publicacionService = new PublicacionService();
                IList<PublicacionDto> comunicados = _publicacionService.ObtenerXTipo(Comunicado);
                return Response<IList<PublicacionDto>>.Correcto(comunicados);
            });
        }

        [Route("historico/{anio}")]
        [HttpGet]
        public Response<IList<PublicacionDto>> Obtener(int anio)
        {
            return Ejecutar(() =>
            {
                _publicacionService = new PublicacionService();
                IList<PublicacionDto> comunicados = _publicacionService.ObtenerXTipoHistorico(Comunicado, anio);
                return Response<IList<PublicacionDto>>.Correcto(comunicados);
            });
        }
    }
}
