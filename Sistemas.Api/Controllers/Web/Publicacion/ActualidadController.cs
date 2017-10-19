using Sistemas.Api.Controllers.Base;
using Sistemas.Dtos.Http;
using Sistemas.Dtos.Sitio;
using Sistemas.Servicios.Implementacion.Web;
using Sistemas.Servicios.Web;
using System.Collections.Generic;
using System.Web.Http;

namespace Sistemas.Api.Controllers.Web.Publicacion
{
    [RoutePrefix("api/actualidad")]
    public class ActualidadController : BaseController
    {
        private IActualidadService _actualidadService;

        [Route(Predeterminado)]
        [HttpGet]
        public Response<IList<PublicacionDto>> Obtener()
        {
            return Ejecutar(() =>
            {
                _actualidadService = new ActualidadService();

                IList<PublicacionDto> actualidades = _actualidadService.Obtener();

                return Response<IList<PublicacionDto>>.Correcto(actualidades);
            });
        }

        [Route("historico/{anio}")]
        [HttpGet]
        public Response<IList<PublicacionDto>> ObtenerHistorico(int anio)
        {
            return Ejecutar(() =>
            {
                _actualidadService = new ActualidadService();

                IList<PublicacionDto> actualidades = _actualidadService.ObtenerHistorico(anio);

                return Response<IList<PublicacionDto>>.Correcto(actualidades);
            });
        }
    }
}
