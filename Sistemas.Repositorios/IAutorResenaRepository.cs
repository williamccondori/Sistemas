using System.Collections.Generic;
using Sistemas.Entidades;

namespace Sistemas.Repositorios
{
    public interface IAutorResenaRepository
    {
        void Crear(AutorResenaEntity autorResena);
        ICollection<AutorResenaEntity> ObtenerTodo();
    }
}
