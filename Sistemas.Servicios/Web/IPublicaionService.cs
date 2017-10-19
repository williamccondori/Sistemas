using Sistemas.Dtos.Sitio;
using System.Collections.Generic;

namespace Sistemas.Servicios.Web
{
    public interface IPublicacionService
    {
        IList<PublicacionDto> ObtenerXTipo(string idTipoPublicacion);
        IList<PublicacionDto> ObtenerHistoricoXTipo(string idTipoPublicacion, int anio);
        PublicacionDto BuscarXId(long idPublicacion);
    }
}
