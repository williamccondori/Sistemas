using Sistemas.Entidades;
using System.Collections.Generic;

namespace Sistemas.Repositorios
{
    public interface ITipoResenaRepository
    {
        void Crear(TipoResenaEntity tipoResena);
        ICollection<TipoResenaEntity> ObtenerTodo();
    }
}
