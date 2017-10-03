using Sistemas.Dtos.Sitio;
using System.Collections.Generic;

namespace Sistemas.Servicios.Sitio
{
    public interface ITipoDetallePublicacionService
    {
        IList<TipoDetallePublicacionDto> ObtenerTodo();
        void Guardar(TipoDetallePublicacionDto tipoDetallePublicacionDto);
    }
}
