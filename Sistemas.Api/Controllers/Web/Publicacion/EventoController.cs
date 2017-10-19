using Sistemas.Api.Controllers.Base;
using Sistemas.Dtos.Http;
using Sistemas.Dtos.Sitio;
using Sistemas.Servicios.Implementacion.Web;
using Sistemas.Servicios.Web;
using System.Collections.Generic;
using System.Web.Http;

namespace Sistemas.Api.Controllers.Web.Evento
{
    [RoutePrefix("api/evento")]
    public class EventoController : BaseController
    {
        private IEventoService _eventoService;

        [Route(Predeterminado)]
        [HttpGet]
        public Response<IList<EventoDto>> Obtener()
        {
            return Ejecutar(() =>
            {
                _eventoService = new EventoService();

                IList<EventoDto> eventos = _eventoService.Obtener();

                return Response<IList<EventoDto>>.Correcto(eventos);
            });
        }

        [Route("historico/{anio}")]
        [HttpGet]
        public Response<IList<EventoDto>> ObtenerHistorico(int anio)
        {
            return Ejecutar(() =>
            {
                _eventoService = new EventoService();

                IList<EventoDto> eventos = _eventoService.ObtenerHistorico(anio);

                return Response<IList<EventoDto>>.Correcto(eventos);
            });
        }
    }
}
