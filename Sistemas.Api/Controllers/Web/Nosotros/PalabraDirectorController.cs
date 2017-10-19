using Sistemas.Api.Controllers.Base;
using Sistemas.Dtos.Http;
using Sistemas.Dtos.Sitio;
using Sistemas.Servicios.Implementacion.Web;
using Sistemas.Servicios.Web;
using System.Web.Http;

namespace Sistemas.Api.Controllers.Web.Nosotros
{
    [RoutePrefix("api/palabra_director")]
    public class PalabraDirectorController : BaseController
    {
        private IResenaService _resenaService;

        private const string _palabraDirector = "PA";

        [Route(Predeterminado)]
        [HttpGet]
        public Response<ResenaDto> ObtenerXTipo()
        {
            return Ejecutar(() =>
            {
                _resenaService = new ResenaService();

                ResenaDto palabra = _resenaService.BuscarXTipo(_palabraDirector);

                return Response<ResenaDto>.Correcto(palabra); ;
            });
        }
    }
}