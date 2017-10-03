using Sistemas.Dtos.Sitio;
using System.Collections.Generic;

namespace Sistemas.Servicios.Sitio
{
    public interface ITipoPublicacionService
    {
        IList<TipoPublicacionDto> ObtenerTodo();
        void Guardar(TipoPublicacionDto tipoPublicacionDto);
    }
}
