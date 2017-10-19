using Sistemas.Api.Controllers.Base;
using Sistemas.Dtos.Http;
using Sistemas.Dtos.Sitio;
using Sistemas.Servicios.Implementacion.Web;
using Sistemas.Servicios.Web;
using System.Web.Http;

namespace Sistemas.Api.Controllers.Web.Nosotros
{
    [RoutePrefix("api/presentacion")]
    public class PresentacionController : BaseController
    {
        private IResenaService _resenaService;

        private const string _presentacion = "PR";

        [Route(Predeterminado)]
        [HttpGet]
        public Response<ResenaDto> ObtenerXTipo()
        {
            return Ejecutar(() =>
            {
                _resenaService = new ResenaService();

                ResenaDto resena = _resenaService.BuscarXTipo(_presentacion);

                return Response<ResenaDto>.Correcto(resena);
            });
        }
    }
}