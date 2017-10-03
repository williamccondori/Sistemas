using Sistemas.Entidades;
using System.Collections.Generic;

namespace Sistemas.Repositorios
{
    public interface ITipoPublicacionRepository
    {
        void Crear(TipoPublicacionEntity tipoPublicacion);
        ICollection<TipoPublicacionEntity> ObtenerTodo();
    }
}
