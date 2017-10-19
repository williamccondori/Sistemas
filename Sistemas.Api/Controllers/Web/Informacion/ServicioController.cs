using Sistemas.Api.Controllers.Base;
using Sistemas.Dtos.Http;
using Sistemas.Dtos.Sitio;
using Sistemas.Servicios.Implementacion.Web;
using Sistemas.Servicios.Web;
using System.Collections.Generic;
using System.Web.Http;

namespace Sistemas.Api.Controllers.Web.Publicacion
{
    [RoutePrefix("api/servicio")]
    public class ServicioController : BaseController
    {
        private IPublicacionService _publicacionService;

        private const string _servicio = "SE";

        [Route(Predeterminado)]
        [HttpGet]
        public Response<IList<PublicacionDto>> ObtenerXTipo()
        {
            return Ejecutar(() =>
            {
                _publicacionService = new PublicacionService();

                IList<PublicacionDto> servicios = _publicacionService.ObtenerXTipo(_servicio);

                return Response<IList<PublicacionDto>>.Correcto(servicios);
            });
        }
    }
}
