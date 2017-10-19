using Sistemas.Dtos.Sitio;
using System.Collections.Generic;

namespace Sistemas.Servicios.Web
{
    public interface IEventoService
    {
        IList<EventoDto> Obtener();
        IList<EventoDto> ObtenerHistorico(int anio);
    }
}
