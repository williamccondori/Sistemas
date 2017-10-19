using Sistemas.Api.Controllers.Base;
using Sistemas.Dtos.Http;
using Sistemas.Dtos.Sitio;
using Sistemas.Servicios.Implementacion.Web;
using Sistemas.Servicios.Web;
using System.Collections.Generic;
using System.Web.Http;

namespace Sistemas.Api.Controllers.Web.Publicacion
{
    [RoutePrefix("api/comunicado")]
    public class ComunicadoController : BaseController
    {
        private IPublicacionService _publicacionService;

        private const string _comunicado = "NO";

        [Route(Predeterminado)]
        [HttpGet]
        public Response<IList<PublicacionDto>> ObtenerXTipo()
        {
            return Ejecutar(() =>
            {
                _publicacionService = new PublicacionService();

                IList<PublicacionDto> comunicados = _publicacionService.ObtenerXTipo(_comunicado);

                return Response<IList<PublicacionDto>>.Correcto(comunicados);
            });
        }

        [Route("historico/{anio}")]
        [HttpGet]
        public Response<IList<PublicacionDto>> ObtenerHistoricoXTipo(int anio)
        {
            return Ejecutar(() =>
            {
                _publicacionService = new PublicacionService();

                IList<PublicacionDto> comunicados = _publicacionService.ObtenerHistoricoXTipo(_comunicado, anio);

                return Response<IList<PublicacionDto>>.Correcto(comunicados);
            });
        }
    }
}
