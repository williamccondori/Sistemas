using Sistemas.Dtos.Sitio;
using System.Collections.Generic;

namespace Sistemas.Servicios.Sitio
{
    public interface IPublicacionService
    {
        IList<PublicacionDto> ObtenerPorTipo(string idTipoPublicacion);
        void Guardar(PublicacionDto publicacionDto);
        IList<PublicacionDto> ObtenerTodo(int numeroElementos = 0);
    }
}
