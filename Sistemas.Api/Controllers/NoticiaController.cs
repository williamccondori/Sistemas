using Sistemas.Api.Controllers.Base;
using Sistemas.Dtos.Http;
using Sistemas.Dtos.Sitio;
using Sistemas.Servicios.Implementacion.Sitio;
using Sistemas.Servicios.Sitio;
using System.Collections.Generic;
using System.Web.Http;

namespace Sistemas.Api.Controllers
{
    [RoutePrefix("api/noticia")]
    public class NoticiaController : BaseController
    {
        private IPublicacionService _publicacionService;

        [Route(Predeterminado)]
        [HttpGet]
        public Response<IList<PublicacionDto>> Obtener()
        {
            return Ejecutar(() =>
            {
                _publicacionService = new PublicacionService();
                IList<PublicacionDto> noticias = _publicacionService.ObtenerTodo();
                return Response<IList<PublicacionDto>>.Correcto(noticias);
            });
        }

        [Route("elementos/{numeroElementos}")]
        [HttpGet]
        public Response<IList<PublicacionDto>> Obtener(int numeroElementos)
        {
            return Ejecutar(() =>
            {
                _publicacionService = new PublicacionService();
                IList<PublicacionDto> noticias = _publicacionService.ObtenerTodo(numeroElementos);
                return Response<IList<PublicacionDto>>.Correcto(noticias);
            });
        }
    }
}
