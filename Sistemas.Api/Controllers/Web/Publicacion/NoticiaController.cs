using Sistemas.Api.Controllers.Base;
using Sistemas.Dtos.Http;
using Sistemas.Dtos.Sitio;
using Sistemas.Servicios.Implementacion.Web;
using Sistemas.Servicios.Web;
using System.Collections.Generic;
using System.Web.Http;

namespace Sistemas.Api.Controllers.Web.Publicacion
{
    [RoutePrefix("api/noticia")]
    public class NoticiaController : BaseController
    {
        private IPublicacionService _publicacionService;

        private const string _noticia = "NO";

        [Route(Predeterminado)]
        [HttpGet]
        public Response<IList<PublicacionDto>> ObtenerXTipo()
        {
            return Ejecutar(() =>
            {
                _publicacionService = new PublicacionService();

                IList<PublicacionDto> noticias = _publicacionService.ObtenerXTipo(_noticia);

                return Response<IList<PublicacionDto>>.Correcto(noticias);
            });
        }

        [Route("historico/{anio}")]
        [HttpGet]
        public Response<IList<PublicacionDto>> ObtenerHistoricoXTipo(int anio)
        {
            return Ejecutar(() =>
            {
                _publicacionService = new PublicacionService();

                IList<PublicacionDto> noticias = _publicacionService.ObtenerHistoricoXTipo(_noticia, anio);

                return Response<IList<PublicacionDto>>.Correcto(noticias);
            });
        }
    }
}
