using Sistemas.Entidades;
using System.Collections.Generic;

namespace Sistemas.Repositorios
{
    public interface IPublicacionRepository
    {
        void Crear(PublicacionEntity publicacion);
        ICollection<PublicacionEntity> ObtenerPorTipo(string idTipoPublicacion);
        ICollection<PublicacionEntity> ObtenerTodo();
    }
}
