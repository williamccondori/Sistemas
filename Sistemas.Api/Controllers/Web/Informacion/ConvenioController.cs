using Sistemas.Api.Controllers.Base;
using Sistemas.Dtos.Http;
using Sistemas.Dtos.Sitio;
using Sistemas.Servicios.Implementacion.Web;
using Sistemas.Servicios.Web;
using System.Collections.Generic;
using System.Web.Http;

namespace Sistemas.Api.Controllers.Web.Publicacion
{
    [RoutePrefix("api/convenio")]
    public class ConvenioController : BaseController
    {
        private IPublicacionService _publicacionService;

        private const string _convenio = "CV";

        [Route(Predeterminado)]
        [HttpGet]
        public Response<IList<PublicacionDto>> ObtenerXTipo()
        {
            return Ejecutar(() =>
            {
                _publicacionService = new PublicacionService();

                IList<PublicacionDto> Convenios = _publicacionService.ObtenerXTipo(_convenio);

                return Response<IList<PublicacionDto>>.Correcto(Convenios);
            });
        }
    }
}
