using Sistemas.Entidades;
using System.Collections.Generic;

namespace Sistemas.Repositorios
{
    public interface ITipoDetallePublicacionRepository
    {
        void Crear(TipoDetallePublicacionEntity tipoDetallePublicacion);
        ICollection<TipoDetallePublicacionEntity> ObtenerTodo();
    }
}
