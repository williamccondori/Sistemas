using Sistemas.Api.Controllers.Base;
using Sistemas.Dtos.Http;
using Sistemas.Dtos.Sitio;
using Sistemas.Servicios.Implementacion.Web;
using Sistemas.Servicios.Web;
using System.Collections.Generic;
using System.Web.Http;

namespace Sistemas.Api.Controllers.Web.Publicacion
{
    [RoutePrefix("api/galeria_video")]
    public class GaleriaVideoController : BaseController
    {
        private IPublicacionService _publicacionService;

        private const string _galeriaVideo = "GV";

        [Route(Predeterminado)]
        [HttpGet]
        public Response<IList<PublicacionDto>> ObtenerXTipo()
        {
            return Ejecutar(() =>
            {
                _publicacionService = new PublicacionService();

                IList<PublicacionDto> galeriasVideo = _publicacionService.ObtenerXTipo(_galeriaVideo);

                return Response<IList<PublicacionDto>>.Correcto(galeriasVideo);
            });
        }

        [Route("historico/{anio}")]
        [HttpGet]
        public Response<IList<PublicacionDto>> ObtenerHistoricoXTipo(int anio)
        {
            return Ejecutar(() =>
            {
                _publicacionService = new PublicacionService();

                IList<PublicacionDto> galeriasVideo = _publicacionService.ObtenerHistoricoXTipo(_galeriaVideo, anio);

                return Response<IList<PublicacionDto>>.Correcto(galeriasVideo);
            });
        }
    }
}
