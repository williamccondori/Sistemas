using System.Collections.Generic;
using Sistemas.Dtos.Sitio;

namespace Sistemas.Servicios.Sitio
{
    public interface IAutorResenaService
    {
        void Guardar(AutorResenaDto autorResenaDto);
        IList<AutorResenaDto> ObtenerTodo();
    }
}
