using Sistemas.Dtos.Sitio;
using System.Collections.Generic;

namespace Sistemas.Servicios.Sitio
{
    public interface ITipoResenaService
    {
        IList<TipoResenaDto> ObtenerTodo();
        void Guardar(TipoResenaDto tipoResenaDto);
    }
}
