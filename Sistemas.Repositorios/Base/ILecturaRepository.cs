using System.Collections.Generic;

namespace Sistemas.Repositorios.Base
{
    public interface ILecturaRepository<T>
    {
        ICollection<T> ObtenerTodo();
    }
}
