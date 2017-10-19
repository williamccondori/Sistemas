using Sistemas.Api.Controllers.Base;
using Sistemas.Dtos.Http;
using Sistemas.Dtos.Sitio;
using Sistemas.Servicios.Implementacion.Web;
using Sistemas.Servicios.Web;
using System.Web.Http;

namespace Sistemas.Api.Controllers.Web.Nosotros
{
    [RoutePrefix("api/auto_evaluacion")]
    public class AutoEvaluacionController : BaseController
    {
        private IResenaService _resenaService;

        private const string _autoEvaluacion = "AE";

        [Route(Predeterminado)]
        [HttpGet]
        public Response<ResenaDto> ObtenerXTipo()
        {
            return Ejecutar(() =>
            {
                _resenaService = new ResenaService();

                ResenaDto autoEvaluacion = _resenaService.BuscarXTipo(_autoEvaluacion);

                return Response<ResenaDto>.Correcto(autoEvaluacion);
            });
        }
    }
}