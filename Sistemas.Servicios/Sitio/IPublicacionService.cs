using Sistemas.Dtos.Sitio;
using System.Collections.Generic;

namespace Sistemas.Servicios.Sitio
{
    public interface IPublicacionService
    {
        IList<PublicacionDto> ObtenerPorTipo(string idTipoPublicacion, int numeroElementos = 0);
        void Guardar(PublicacionDto publicacionDto);
        IList<PublicacionDto> ObtenerTodo(int numeroElementos = 0);
    }
}
