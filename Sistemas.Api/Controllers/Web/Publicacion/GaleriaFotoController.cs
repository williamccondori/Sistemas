using Sistemas.Api.Controllers.Base;
using Sistemas.Dtos.Http;
using Sistemas.Dtos.Sitio;
using Sistemas.Servicios.Implementacion.Web;
using Sistemas.Servicios.Web;
using System.Collections.Generic;
using System.Web.Http;

namespace Sistemas.Api.Controllers.Web.Publicacion
{
    [RoutePrefix("api/galeria_foto")]
    public class GaleriaFotoController : BaseController
    {
        private IPublicacionService _publicacionService;

        private const string _galeriaFoto = "GF";

        [Route(Predeterminado)]
        [HttpGet]
        public Response<IList<PublicacionDto>> ObtenerXTipo()
        {
            return Ejecutar(() =>
            {
                _publicacionService = new PublicacionService();

                IList<PublicacionDto> galeriasFoto = _publicacionService.ObtenerXTipo(_galeriaFoto);

                return Response<IList<PublicacionDto>>.Correcto(galeriasFoto);
            });
        }

        [Route("historico/{anio}")]
        [HttpGet]
        public Response<IList<PublicacionDto>> ObtenerHistoricoXTipo(int anio)
        {
            return Ejecutar(() =>
            {
                _publicacionService = new PublicacionService();

                IList<PublicacionDto> galeriasFoto = _publicacionService.ObtenerHistoricoXTipo(_galeriaFoto, anio);

                return Response<IList<PublicacionDto>>.Correcto(galeriasFoto);
            });
        }
    }
}
