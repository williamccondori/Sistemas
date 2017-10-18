using Sistemas.Dtos.Sitio;
using System.Collections.Generic;

namespace Sistemas.Servicios.Web
{
    public interface IActualidadService
    {
        IList<PublicacionDto> Obtener();
        IList<PublicacionDto> ObtenerHistorico(int anio);
    }
}
