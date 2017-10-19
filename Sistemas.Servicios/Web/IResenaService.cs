using Sistemas.Dtos.Sitio;

namespace Sistemas.Servicios.Web
{
    public interface IResenaService
    {
        ResenaDto BuscarXTipo(string idTipoResena);
    }
}
