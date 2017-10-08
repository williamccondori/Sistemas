using Sistemas.Dtos.Sitio;
using System.Collections.Generic;

namespace Sistemas.Servicios.Sitio
{
    public interface IResenaService
    {
        void Guardar(ResenaDto resenaDto);
        IList<ResenaDto> ObtenerTodo();
        IList<ResenaDto> ObtenerPorTipo(string idTipoResena);
    }
}
