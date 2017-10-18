using Sistemas.Dtos.Sitio;
using System.Collections.Generic;

namespace Sistemas.Servicios.Web
{
    public interface IPublicacionService
    {
        IList<PublicacionDto> ObtenerXTipo(string idTipoPublicacion);
        IList<PublicacionDto> ObtenerXTipoHistorico(string idTipoPublicacion, int anio);
        PublicacionDto ObtenerXId(long idPublicacion);
    }
}
