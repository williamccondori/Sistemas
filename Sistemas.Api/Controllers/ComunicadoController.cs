using Sistemas.Api.Controllers.Base;
using Sistemas.Dtos.Http;
using Sistemas.Dtos.Sitio;
using Sistemas.Servicios.Implementacion.Sitio;
using Sistemas.Servicios.Sitio;
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
                IList<PublicacionDto> comunicados = _publicacionService.ObtenerPorTipo(Comunicado);
                return Response<IList<PublicacionDto>>.Correcto(comunicados);
            });
        }

        [Route("elementos/{numeroElementos}")]
        [HttpGet]
        public Response<IList<PublicacionDto>> Obtener(int numeroElementos)
        {
            return Ejecutar(() =>
            {
                _publicacionService = new PublicacionService();
                IList<PublicacionDto> comunicados = _publicacionService.ObtenerPorTipo(Comunicado, numeroElementos);
                return Response<IList<PublicacionDto>>.Correcto(comunicados);
            });
        }
    }
}
