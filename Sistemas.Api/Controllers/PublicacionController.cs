using Sistemas.Api.Controllers.Base;
using Sistemas.Dtos.Http;
using Sistemas.Dtos.Sitio;
using Sistemas.Servicios.Implementacion.Web;
using Sistemas.Servicios.Web;
using System.Collections.Generic;
using System.Web.Http;

namespace Sistemas.Api.Controllers
{
    [RoutePrefix("api/publicacion")]
    public class PublicacionController : BaseController
    {
        private IPublicacionService _publicacionService;

        private const string Publicacion = "PU";

        [Route(Predeterminado)]
        [HttpGet]
        public Response<IList<PublicacionDto>> Obtener()
        {
            return Ejecutar(() =>
            {
                _publicacionService = new PublicacionService();
                IList<PublicacionDto> publicaciones = _publicacionService.ObtenerXTipo(Publicacion);
                return Response<IList<PublicacionDto>>.Correcto(publicaciones);
            });
        }

        [Route("historico/{anio}")]
        [HttpGet]
        public Response<IList<PublicacionDto>> ObtenerHistorico(int anio)
        {
            return Ejecutar(() =>
            {
                _publicacionService = new PublicacionService();
                IList<PublicacionDto> publicaciones = _publicacionService.ObtenerXTipoHistorico(Publicacion, anio);
                return Response<IList<PublicacionDto>>.Correcto(publicaciones);
            });
        }
    }
}
