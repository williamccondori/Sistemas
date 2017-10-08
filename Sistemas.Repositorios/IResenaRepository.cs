using Sistemas.Entidades;
using Sistemas.Repositorios.Base;
using System.Collections.Generic;

namespace Sistemas.Repositorios
{
    public interface IResenaRepository : IBaseRepository<ResenaEntity>
    {
        ICollection<ResenaEntity> ObtenerPorTipo(string idTipoResena);
    }
}
