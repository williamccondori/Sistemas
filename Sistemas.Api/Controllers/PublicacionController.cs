using Sistemas.Api.Controllers.Base;
using Sistemas.Dtos.Http;
using Sistemas.Dtos.Sitio;
using Sistemas.Servicios.Implementacion.Sitio;
using Sistemas.Servicios.Sitio;
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
                IList<PublicacionDto> publicaciones = _publicacionService.ObtenerPorTipo(Publicacion);
                return Response<IList<PublicacionDto>>.Correcto(publicaciones);
            });
        }

        [Route("elementos/{numeroElementos}")]
        [HttpGet]
        public Response<IList<PublicacionDto>> Obtener(int numeroElementos)
        {
            return Ejecutar(() =>
            {
                _publicacionService = new PublicacionService();
                IList<PublicacionDto> publicaciones = _publicacionService.ObtenerPorTipo(Publicacion, numeroElementos);
                return Response<IList<PublicacionDto>>.Correcto(publicaciones);
            });
        }
    }
}
