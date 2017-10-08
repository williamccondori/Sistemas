using System.Collections.Generic;

namespace Sistemas.Repositorios.Base
{
    public interface ILecturaRepository<T>
    {
        T Buscar(object idEntidad);
        ICollection<T> ObtenerTodo();
    }
}
