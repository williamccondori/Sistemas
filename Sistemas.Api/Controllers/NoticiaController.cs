using Sistemas.Api.Controllers.Base;
using Sistemas.Dtos.Http;
using Sistemas.Dtos.Sitio;
using Sistemas.Servicios.Implementacion.Web;
using Sistemas.Servicios.Web;
using System.Collections.Generic;
using System.Web.Http;

namespace Sistemas.Api.Controllers
{
    [RoutePrefix("api/noticia")]
    public class NoticiaController : BaseController
    {
        private IPublicacionService _publicacionService;

        private const string Noticia = "NO";

        [Route(Predeterminado)]
        [HttpGet]
        public Response<IList<PublicacionDto>> Obtener()
        {
            return Ejecutar(() =>
            {
                _publicacionService = new PublicacionService();
                IList<PublicacionDto> noticias = _publicacionService.ObtenerXTipo(Noticia);
                return Response<IList<PublicacionDto>>.Correcto(noticias);
            });
        }

        [Route("buscar/{idPublicacion}")]
        [HttpGet]
        public Response<PublicacionDto> Buscar(long idPublicacion)
        {
            return Ejecutar(() =>
            {
                _publicacionService = new PublicacionService();
                PublicacionDto noticia = _publicacionService.ObtenerXId(idPublicacion);
                return Response<PublicacionDto>.Correcto(noticia);
            });
        }

        [Route("historico/{anio}")]
        [HttpGet]
        public Response<IList<PublicacionDto>> Obtener(int anio)
        {
            return Ejecutar(() =>
            {
                _publicacionService = new PublicacionService();
                IList<PublicacionDto> noticias = _publicacionService.ObtenerXTipoHistorico(Noticia, anio);
                return Response<IList<PublicacionDto>>.Correcto(noticias);
            });
        }
    }
}
