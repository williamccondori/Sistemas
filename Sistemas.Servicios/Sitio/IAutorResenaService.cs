using Sistemas.Dtos.Sitio;
using System.Collections.Generic;

namespace Sistemas.Servicios.Sitio
{
    public interface IAutorResenaService
    {
        void Guardar(AutorResenaDto autorResenaDto);
        IList<AutorResenaDto> ObtenerTodo();
    }
}
