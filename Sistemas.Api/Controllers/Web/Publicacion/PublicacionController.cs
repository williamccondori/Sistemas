using Sistemas.Api.Controllers.Base;
using Sistemas.Dtos.Http;
using Sistemas.Dtos.Sitio;
using Sistemas.Servicios.Implementacion.Web;
using Sistemas.Servicios.Web;
using System.Collections.Generic;
using System.Web.Http;

namespace Sistemas.Api.Controllers.Web.Publicacion
{
    [RoutePrefix("api/publicacion")]
    public class PublicacionController : BaseController
    {
        private IPublicacionService _publicacionService;

        private const string _publicacion = "PU";

        [Route(Predeterminado)]
        [HttpGet]
        public Response<IList<PublicacionDto>> ObtenerXTipo()
        {
            return Ejecutar(() =>
            {
                _publicacionService = new PublicacionService();

                IList<PublicacionDto> publicaciones = _publicacionService.ObtenerXTipo(_publicacion);

                return Response<IList<PublicacionDto>>.Correcto(publicaciones);
            });
        }

        [Route("historico/{anio}")]
        [HttpGet]
        public Response<IList<PublicacionDto>> ObtenerHistoricoXTipo(int anio)
        {
            return Ejecutar(() =>
            {
                _publicacionService = new PublicacionService();

                IList<PublicacionDto> publicaciones = _publicacionService.ObtenerHistoricoXTipo(_publicacion, anio);

                return Response<IList<PublicacionDto>>.Correcto(publicaciones);
            });
        }

        [Route("buscar/{idPublicacion}")]
        [HttpGet]
        public Response<PublicacionDto> BuscarXId(long idPublicacion)
        {
            return Ejecutar(() =>
            {
                _publicacionService = new PublicacionService();

                PublicacionDto publicacion = _publicacionService.BuscarXId(idPublicacion);

                return Response<PublicacionDto>.Correcto(publicacion);
            });
        }
    }
}